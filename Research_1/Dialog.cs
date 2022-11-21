public class Dialog
{
    public int Id { get; }
    public string Question { get; }
    public string Answer { get; }
    private Patient PatientI;
    public int Day { get; }

    public Dialog(Patient patient, string question, string answer, int Day)
    {
        PatientI = patient;
        Answer = answer;
        Question = question;
        this.Day = Day;
    }

    ~Dialog()
    {
    }

    public Patient getPatient()
    {
        return PatientI;
    }

}
