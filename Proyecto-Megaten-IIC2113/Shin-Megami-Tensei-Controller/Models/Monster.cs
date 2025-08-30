namespace Shin_Megami_Tensei.Models;

public class Monster : Unit
{
    public List<string> Skills { get; } = new();

    public Monster() { }

    public Monster(string name, Stats stats, Affinity affinity, IEnumerable<string>? skills = null)
        : base(name, stats, affinity)
    {
        if (skills != null) Skills.AddRange(skills);
    }
}
