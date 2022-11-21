
using System.Collections.Generic;

public class Question 
{
    public int Id { get; }
    public string Text { get; }
    public List<int> SymptomCodes { get; }

    public Question(int Id, string Text,List<int> SymptomCodes)
    {
        this.Id = Id;
        this.Text = Text;
        this.SymptomCodes = SymptomCodes;
    }

    ~Question()
    {
        SymptomCodes.Clear();
    }
}
