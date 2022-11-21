
public class SymptomManifest 
{
    public int Code { get; }
    public int Probability { get; }

    public SymptomManifest(int Code, int Probability)
    {
        this.Code = Code;
        this.Probability = Probability;
    }

}
