using System;
using System.Collections.Generic;


[Serializable]
public class WorldData
{
    public int CurrentDay;
    public int TotalDays;
    public Player Avatar;
    public List<Patient> Patients;
    public List<Patient> DeadPatients;

    public WorldData(int CurrentDay,int TotalDays, Player Avatar, List<Patient> Patients, List<Patient> DeadPatients)
    {
        this.CurrentDay=CurrentDay;
        this.TotalDays=TotalDays;
        this.Avatar=Avatar;
        this.Patients=Patients;
        this.DeadPatients=DeadPatients;
    }   
}
