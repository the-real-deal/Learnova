namespace Learnova.Commons;

public class Grade
{
    public string description { get; set; } = "";
    public double value { get; set; } = 0;
    public int id { get; set; }
    public DateTime date { get; set; }

    public override bool Equals(object? obj)
    {
        return this.id == (obj as Grade).id;
    }
}