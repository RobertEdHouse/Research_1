public class Medicine 
{
    public int Id { get; }
    public string Type { get; }
    public int Count { get; private set; }
    public int Price { get; }

    public Medicine(int Id, string Type, int Count, int Price)
    {
        this.Type = Type;
        this.Count = Count;
        this.Price = Price;
    }
    public void used()
    {
        Count--;
    }
    public void add(int count)
    {
        Count+=count;
    }
}
