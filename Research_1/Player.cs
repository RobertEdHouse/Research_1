
using System.Collections.Generic;

public class Player
{
    public int Karma { get; private set; }
    public int Money { get; private set; }
    public List<Medicine> Medicines { get; private set; }
    private List<Dialog> Dialogs;

    public Player(List<Medicine> Medicines,int Money)
    {
        Karma = 3;
        this.Money = Money;
        this.Medicines = Medicines;
        Dialogs = new List<Dialog>();
    }

    ~Player()
    {
        Dialogs.Clear();
        Medicines.Clear();
    }

    public bool buyMedicine(Medicine medicine)
    {
        if (medicine.Price > this.Money)
        {
            return false;
        }
        this.Money -= medicine.Price;
        foreach(Medicine m in Medicines)
        {
            if (m.Equals(medicine.Type))
            {
                m.add(medicine.Count);
            }
        }
        Medicines.Add(medicine);
        return true;
    }
    public void giveMedicine(Patient patient,Medicine medicine)
    {
        patient.takeMedicine(medicine);
        medicine.used();
    }

    public Answer ask(Question question,Patient patient,int Day)
    {
        Answer answer = patient.answer(question);
        Dialog newDialog = new Dialog(patient, question.Text, answer.Text, Day);
        addDialog(newDialog);
        return answer;
    }

    public Dialog getDialog(Patient patient)
    {
        foreach(Dialog dialog in Dialogs)
        {
            if (dialog.getPatient().Equals(patient))
            {
                return dialog;
            }
        }
        return null;
    }
    public Dialog getDialog(int dialogId)
    {
        return Dialogs[dialogId];
    }

    public List<Dialog> getDialogs(Patient patient)
    {
        List<Dialog> dialogs = new List<Dialog>();
        foreach (Dialog dialog in Dialogs)
        {
            if (dialog.getPatient().Equals(patient))
            {
                dialogs.Add(dialog);
            }
        }
        return dialogs;
    }
    public void addDialog(Dialog dialog)
    {
        Dialogs.Add(dialog);
    }
    


}
