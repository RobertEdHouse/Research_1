

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

