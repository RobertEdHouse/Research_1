using System;
using System.Collections.Generic;


public class Disease 
{
    public int Id { get; }
    public string Name { get; }
    private int Stage;
    private List<SymptomManifest> SymptomsManifest;

    public Disease(int Id, string Name, List<SymptomManifest> SymptomsManifest)
    {
        this.Id = Id;
        this.Name = Name;
        Stage = 10;
        this.SymptomsManifest = SymptomsManifest;
    }

    public void raiseStage()
    {
        Random rand = new Random();
        Stage+=rand.Next(5,20);
    }

    public void downStage()
    {
        Random rand = new Random();
        Stage -= rand.Next(5, 20);
    }

    public int getStage()
    {
        return Stage;
    }

    public List<SymptomManifest> getListSymptom()
    {
        return SymptomsManifest;
    }
    ~Disease()
    {
        SymptomsManifest.Clear();
    }

}
