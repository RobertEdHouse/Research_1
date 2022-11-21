

using System.Collections.Generic;

public class World 
{
    private int CurrentDay;
    private int TotalDays;
    private Player Avatar;
    private List<Patient> Patients;
    private List<Patient> DeadPatients;
    private List<Symptom> Symptoms;
    private List<Disease> Diseases;
    private List<Question> Questions;
    private List<Medicine> Medicines;

    public World()
    {
        //заполняем Symptoms, Diseases, Questions,
        //Medicines из файла конфигурации
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
        //заполнить случайными данными 
        return null;
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
            patient.nextDay();
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
        WorldData world = new WorldData(
            CurrentDay, TotalDays, Avatar, Patients, DeadPatients);
        SaveLoad.SaveData(world);
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
        //заполнить из файла конфигурации
        return null;
    }

    private List<Disease> loadDiseases()
    {
        //заполнить из файла конфигурации
        return null;
    }
    private List<Question> loadQuestions()
    {
        //заполнить из файла конфигурации
        return null;
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

