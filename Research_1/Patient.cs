
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
        Brain = 100;
        Heart = 100;
        Intestines = 100;
        Liver = 100;
        Lungs = 100;
        Stomach = 100;
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

    public void nextDay()
    {
        //применить лекарства
        //изменить состояния болезней
        updateSymptoms();
        //изменить состояния органов
        //изменить температуру в зависимости от состояния болезни
    }

    private void updateSymptoms()
    {
        Symptoms.Clear();
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
        Symptom symptomRandom = commonSymptoms[rand.Next(0, commonSymptoms.Count - 1)];
        return symptomRandom.getAnswer();
    }
    
}
