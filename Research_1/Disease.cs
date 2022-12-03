using System;
using System.Collections.Generic;

[Serializable]
public class Disease 
{
    public int Id { get; }
    public string Name { get; }
    private int MaxStage;
    public int StagePercent { get; private set; }
    private int Brain=0;
    private int Heart=0;
    private int Intestines=0;
    private int Liver=0;
    private int Lungs=0;
    private int Stomach=0;
    public bool Temperature { get; private set; }
    private List<SymptomManifest> SymptomsManifest;

    public Disease(int Id, string Name,int MaxStage, List<SymptomManifest> SymptomsManifest)
    {
        this.Id = Id;
        this.Name = Name;
        this.MaxStage = MaxStage;
        StagePercent = 10;
        this.SymptomsManifest = SymptomsManifest;
    }

    public void setParamOrgan(List<int>list,bool chenge)
    {
        if (list.Count > 0)
            Brain = list[0];
        if (list.Count > 1)
            Heart = list[1];
        if (list.Count > 2)
            Intestines = list[2];
        if (list.Count > 3)
            Liver = list[3];
        if (list.Count > 4)
            Lungs = list[4];
        if (list.Count > 5)
            Stomach = list[5];
        Temperature = chenge;
    }
    public void raiseStage()
    {
        Random rand = new Random();
        StagePercent += rand.Next(5, 30);
        if (StagePercent > 100)
            StagePercent = 100;
    }

    public void downStage()
    {
        Random rand = new Random();
        StagePercent -= rand.Next(5, 30);
        if (StagePercent < 0)
            StagePercent = 0;
    }

    public int getStage()
    {
        return StagePercent/(100/MaxStage);
    }

    public List<SymptomManifest> getListSymptom()
    {
        return SymptomsManifest;
    }
    ~Disease()
    {
        SymptomsManifest.Clear();
    }
    public void destroyOrgans(Patient patient)
    {
        int k = 100 / 6;
        int currentStage = StagePercent / (100 / MaxStage)+1;
        for (int i = 0; i < 4; i++)
        {

        }
        if (patient.Brain - Brain >= 0)
            patient.Brain -= Brain;
        else
            patient.Brain = 0;
        if (patient.Heart - Heart >= 0)
            patient.Heart -= Heart;
        else
            patient.Heart = 0;
        if (patient.Liver - Liver >= 0)
            patient.Liver -= Liver;
        else
            patient.Liver = 0;
        if (patient.Lungs - Lungs >= 0)
            patient.Lungs -= Lungs;
        else
            patient.Lungs = 0;
        if (patient.Stomach - Stomach >= 0)
            patient.Stomach -= Stomach;
        else
            patient.Stomach = 0;
        if (patient.Intestines - Intestines >= 0) 
            patient.Intestines -= Intestines;
        else
            patient.Intestines = 0;
    }
}
