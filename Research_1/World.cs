

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
        //��������� Symptoms, Diseases, Questions,
        //Medicines �� ����� ������������
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
        //��������� ���������� ������� 
        return null;
    }
    private List<Medicine> getStandartMedicines()
    {
        //�������� ������ 4 ��������� � ���������
        //�������������� ����������� � ����������
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
        //���������� �������� � ����������� 
        //�� ���������� ��������
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
        //��������� �� ����� ������������
        return null;
    }

    private List<Disease> loadDiseases()
    {
        //��������� �� ����� ������������
        return null;
    }
    private List<Question> loadQuestions()
    {
        //��������� �� ����� ������������
        return null;
    }

    private List<Medicine> loadMedicines()
    {
        //��������� �� ����� ������������
        return null;
    }

    

    public void endGame(int Karma)
    {
        
    }
    public void gameOver()
    {

    }
}

