using System;
using System.Collections.Generic;

[Serializable]
public class Medicine 
{
    public int Id { get; }
    public string Type { get; }
    public int Count { get; private set; }
    public int Price { get; }
    private int Brain = 0;
    private int Heart = 0;
    private int Intestines = 0;
    private int Liver = 0;
    private int Lungs = 0;
    private int Stomach = 0;
    public Medicine(int Id, string Type, int Count, int Price)
    {
        this.Type = Type;
        this.Count = Count;
        this.Price = Price;
    }
    public void setParamOrgan(List<int> list)
    {
        if(list.Count>0)
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
    }
    public void used()
    {
        Count--;
    }
    public void add(int count)
    {
        Count+=count;
    }

    public void treatOrgans(Patient patient)
    {
        if (patient.Brain + Brain <= 10)
            patient.Brain += Brain;
        else
            patient.Brain = 10;
        if (patient.Heart + Heart <= 10)
            patient.Heart += Heart;
        else
            patient.Heart = 10;
        if (patient.Liver + Liver <= 10)
            patient.Liver += Liver;
        else
            patient.Liver = 10;
        if (patient.Lungs + Lungs <= 10)
            patient.Lungs += Lungs;
        else
            patient.Lungs = 10;
        if (patient.Stomach + Stomach <= 10)
            patient.Stomach += Stomach;
        else
            patient.Stomach = 10;
        if (patient.Intestines + Intestines <= 10)
            patient.Intestines += Intestines;
        else
            patient.Intestines = 10;
    }
}
