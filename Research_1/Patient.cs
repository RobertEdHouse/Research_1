
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

public class Patient 
{

    public string FirstName { get; }
    public string LastName { get; }
    public SexType Sex { get; }


    public State CurrentState { get; private set; }
    public float Temperature { get; private set; }
    private int Immunity;


    public int Brain { get; private set; }
    public int Heart { get; private set; }
    public int Intestines { get; private set; }
    public int Liver { get; private set; }
    public int Lungs { get; private set; }
    public int Stomach { get; private set; }


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
        Temperature += rand.Next(1,20)/10;
    }
    private void lowerTemperature()
    {
        Random rand = new Random();
        Temperature -= rand.Next(1, 20)/10;
    }

    public void takeMedicine(Medicine medicine)
    {
        Medicines.Add(medicine);
    }

    public void nextDay(List<Symptom>symptoms,List<Disease> diseases)
    {
        //применить лекарства
        //изменить состояния болезней
        updateSymptoms(symptoms);
        //изменить состояния органов
        //изменить температуру в зависимости от состояния болезни
    }

    private void updateSymptoms(List<Symptom> symptoms)
    {
        Symptoms.Clear();
        Disease randomDisease = Diseases[(new Random()).Next(Diseases.Count)];
        foreach(Symptom sym in symptoms)
        foreach(SymptomManifest symMan in randomDisease.getListSymptom())
        {
                if(sym.Id==symMan.Code)
                    Symptoms.Add(sym);
        }
        
       
        //на основе болезни обновить симптомы
    }

    public Answer answer(Question question)
    {
        List<Symptom> commonSymptoms=new List<Symptom>();
        foreach (int code in question.SymptomCodes)
        {
            foreach(Symptom symptom in Symptoms)
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
