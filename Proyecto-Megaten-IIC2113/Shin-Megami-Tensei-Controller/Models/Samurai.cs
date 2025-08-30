namespace Shin_Megami_Tensei.Models;

public class Samurai : Unit
{
    public List<string> ChosenSkills { get; } = new();

    public Samurai() { }

    public Samurai(string name, Stats stats, Affinity affinity, IEnumerable<string>? chosenSkills = null)
        : base(name, stats, affinity)
    {
        if (chosenSkills != null) ChosenSkills.AddRange(chosenSkills);
    }
}
