
using System;
using System.Collections.Generic;

public enum State
{
    ALIVE,
    SICK,
    DEAD
}

public enum SexType
{
    MALE,
    FEMALE
}

[Serializable]
public class Patient
{

    public string FirstName { get; }
    public string LastName { get; }
    public SexType Sex { get; }


    public State CurrentState { get; private set; }
    public float Temperature { get; set; }
    private int Immunity;


    public int Brain { get; set; }
    public int Heart { get; set; }
    public int Intestines { get; set; }
    public int Liver { get; set; }
    public int Lungs { get; set; }
    public int Stomach { get; set; }


    private List<Disease> Diseases;
    private List<Symptom> Symptoms;
    private List<Medicine> Medicines;

    public Patient(string FirstName, string LastName, SexType Sex, int Immunity, Disease disease)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Sex = Sex;
        this.Immunity = Immunity;
        Symptoms = new List<Symptom>();
        Medicines = new List<Medicine>();
        Diseases = new List<Disease>();

        Diseases.Add(disease);


        CurrentState = State.ALIVE;
        Temperature = 36.7f;
        Brain = 10;
        Heart = 10;
        Intestines = 10;
        Liver = 10;
        Lungs = 10;
        Stomach = 10;
    }

    ~Patient()
    {
        Diseases.Clear();
        Symptoms.Clear();
        Medicines.Clear();
    }


    private void raiseTemperature()
    {
        Random rand = new Random();
        Temperature += (1 - (float)Immunity / 100) * ((rand.Next(3 - 1) + 1) );
    }
    private void lowerTemperature()
    {
        Random rand = new Random();
        float f = ((float)Immunity / 100) * ((rand.Next(3 - 1) + 1));
        if (Temperature - f < 36.6)
            Temperature = 36.6f;
        else {
            Temperature -= f;
        }
    }

    public void takeMedicine(Medicine medicine)
    {
        Medicines.Add(medicine);
    }

    
    public void nextDay(List<Symptom> symptoms, Dictionary<string, Disease> treat)
    {
        //применить лекарства
        //изменить состояния болезней
        List<Disease> activeDiseases = Diseases;
        foreach (Medicine med in Medicines)
        {
            foreach (Disease dis in Diseases)
            {
                Disease d = dis;
                if (treat.TryGetValue(med.Type, out d) == true)
                {
                    if (d.Temperature == true)
                        lowerTemperature();
                    med.treatOrgans(this);
                    activeDiseases.Remove(dis);
                    if (activeDiseases.Count == 0)
                        break;
                }
            }
        }

        List<Disease> diseases = Diseases;
        foreach (Disease dis in Diseases)
        {
            if (dis.StagePercent <= 0)
            {
                diseases.Remove(dis);
            }
        }
        Diseases = diseases;

        Disease randomDisease = null;
        if (activeDiseases.Count!=0)
            randomDisease = Diseases[(new Random()).Next(Diseases.Count)];
        
        foreach (Disease dis in activeDiseases)
        {
            if (randomDisease.Id == dis.Id)
            {
                randomDisease.destroyOrgans(this);
                if (randomDisease.Temperature)
                    raiseTemperature();
                changeState();
            }
            dis.raiseStage();
        }
        updateSymptoms(symptoms);
        
        //изменить состояния органов
        //изменить температуру в зависимости от состояния болезни
    }

    private void treat(Dictionary<string, Disease> treat)
    {
        
    }
    private bool getTreat(string s,ref Disease d)
    {
        return true;
    }
    private void changeState()
    {
        if (Brain == 0 || Heart == 0 || 
            Liver == 0 || Intestines == 0 || 
            Lungs == 0 || Stomach == 0 )
            this.CurrentState = State.DEAD;
        foreach(Disease dis in Diseases)
        {
            if(dis.getStage()>=100)
                this.CurrentState = State.DEAD;
        }
    }
    private void updateSymptoms(List<Symptom> symptoms)
    {
        Symptoms.Clear();

        foreach (Disease disease in Diseases)
            foreach (Symptom sym in symptoms)
                foreach (SymptomManifest symMan in disease.getListSymptom())
                {
                    if (sym.Id == symMan.Code)
                        Symptoms.Add(sym);
                }


        //на основе болезни обновить симптомы
    }

    public Answer answer(Question question)
    {
        List<Symptom> commonSymptoms = new List<Symptom>();
        foreach (int code in question.SymptomCodes)
        {
            foreach (Symptom symptom in Symptoms)
            {
                if (code == symptom.Id)
                    commonSymptoms.Add(symptom);
            }
        }
        Random rand = new Random();
        Symptom symptomRandom = commonSymptoms[rand.Next(commonSymptoms.Count)];
        return symptomRandom.getAnswer();
    }

}
