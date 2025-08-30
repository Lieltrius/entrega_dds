namespace Shin_Megami_Tensei.Models;
public class Unit
{
    public string Name { get; init; } = "";
    public Stats Stats { get; init; } = new();
    public Affinity Affinity { get; init; } = new();

    // Estado en combate
    public int CurrentHP { get; private set; }
    public int CurrentMP { get; private set; }

    public bool IsAlive => CurrentHP > 0;

    public Unit() { }

    public Unit(string name, Stats stats, Affinity affinity)
    {
        Name = name;
        Stats = stats;
        Affinity = affinity;
        CurrentHP = stats.HP;
        CurrentMP = stats.MP;
    }

    public void Reset()
    {
        CurrentHP = Stats.HP;
        CurrentMP = Stats.MP;
    }

    public void TakeDamage(int dmg)
    {
        CurrentHP = Math.Max(0, CurrentHP - Math.Max(0, dmg));
    }

    public virtual int ComputeMeleeDamageAgainst(Unit target)
    {
        return Math.Max(1, (int)Math.Floor(Stats.Str * 0.32));
    }

    public virtual int ComputeGunDamageAgainst(Unit target)
    {
        return Math.Max(1, (int)Math.Floor(Stats.Skl * 0.4));
    }
}
