

using System;
using System.Collections.Generic;

public class World 
{
    public int CurrentDay { get; private set; }
    public int TotalDays { get; private set; }
    public Player Avatar { get; private set; }
    public List<Patient> Patients { get; private set; }
    public List<Patient> DeadPatients { get; private set; }
    public List<Symptom> Symptoms { get; private set; }
    public List<Disease> Diseases { get; private set; }
    public List<Question> Questions { get; private set; }
    public List<Medicine> Medicines { get; private set; }

    public World()
    {
        //заполняем Symptoms, Diseases, Questions,
        //Medicines из файла конфигурации
        
        Patients = new List<Patient>();
        DeadPatients = new List<Patient>();
        Symptoms = new List<Symptom>();
        Diseases = new List<Disease>();
        Questions = new List<Question>();
        Medicines = new List<Medicine>();
        loadFromConfig();
    }
    
    public void init(int CurrentDay,int TotalDays,int countPatient, int startMoney)
    {
        this.CurrentDay = CurrentDay;
        this.TotalDays = TotalDays;

        for (int i = 0; i < countPatient; i++)
        {
            Patients.Add(initPatient());
        }
        Avatar = new Player(getStandartMedicines(), startMoney);
    }   

    private Patient initPatient()
    {
        Random random = new Random();
        Patient newPatien = new Patient("Мартiн", "Септiм", SexType.MALE, 100, Diseases[random.Next(Diseases.Count)]); 
       
        return newPatien;
    }
    private List<Medicine> getStandartMedicines()
    {
        //выбираем первые 4 лекарства в случайном
        //количественном соотношении и возвращаем
        return null;
    }

    public void nextDay()
    {
        foreach (Patient patient in Patients)
        {
            patient.nextDay(Symptoms,null);
        }
        CurrentDay++;
        if (CurrentDay >= TotalDays)
        {
            endGame(Avatar.Karma);
        }
        else if (Patients.Count == 0)
        {
            gameOver();
        }
        //начислисть зарплату в зависимости 
        //от количества погибших
        if (Avatar.Money < 10 && Avatar.Medicines.Count == 0)
            gameOver();
    }

    public void SaveGame()
    {
        
        SaveLoad.SaveData(this);
    }
    public void LoadGame()
    {
        WorldData loadWorld = SaveLoad.LoadData();
        CurrentDay = loadWorld.CurrentDay;
        TotalDays = loadWorld.TotalDays;
        Avatar = loadWorld.Avatar;
        Patients = loadWorld.Patients;
        DeadPatients = loadWorld.DeadPatients;
    }


    private void loadFromConfig()
    {
        Symptoms = loadSymptoms();
        Diseases = loadDiseases();
        Questions = loadQuestions();
        Medicines = loadMedicines();
    }
    private List<Symptom> loadSymptoms()
    {
        List<int> answers = new List<int>();
        answers.Add(0);
        answers.Add(1);
        List<Symptom> symptoms = new List<Symptom>();
        symptoms.Add(new Symptom(0, "Головний бiль",answers));
        answers = new List<int>();
        answers.Add(2);
        answers.Add(3);
        symptoms.Add(new Symptom(1, "Бiль у животi", answers));
        answers = new List<int>();
        answers.Add(4);
        answers.Add(5);
        symptoms.Add(new Symptom(2, "Слабкість", answers));
        return symptoms;
    }

    private List<Disease> loadDiseases()
    {
        Random random = new Random();
        List<SymptomManifest> listSymptoms = new List<SymptomManifest>();
        listSymptoms.Add(new SymptomManifest(0, random.Next(100)));
        listSymptoms.Add(new SymptomManifest(1, random.Next(100)));
        listSymptoms.Add(new SymptomManifest(2, random.Next(100)));

        List<Disease> list = new List<Disease>();
        Disease disease1 = new Disease(0, "Отруєння", listSymptoms);
        list.Add(disease1);
        return list;
    }
    private List<Question> loadQuestions()
    {
        List<int> symptomes = new List<int>();
        symptomes.Add(0);
        symptomes.Add(1);
        
        List<Question> questions = new List<Question>();
        questions.Add(new Question(0, "Як себе почуваєте?", symptomes));
        symptomes = new List<int>();
        symptomes.Add(2);
        questions.Add(new Question(1, "Якi вiдчуття?", symptomes));
        return questions;
    }

    private List<Medicine> loadMedicines()
    {
        //заполнить из файла конфигурации
        return null;
    }

    

    public void endGame(int Karma)
    {
        
    }
    public void gameOver()
    {

    }
}

