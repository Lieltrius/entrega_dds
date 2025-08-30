namespace Shin_Megami_Tensei.Models;

using System.Linq;

public class TeamValidator
{
    public static bool IsValid(Team team)
    {
        if (team.SamuraiCounter != 1) return false;
        
        if (team.Units.Count > 8) return false;
        
        if (team.SamuraiSkills.Count > 8) return false;

        if (team.Units.Count != team.Units.Distinct().Count()) return false;
        
        if (team.SamuraiSkills.Count != team.SamuraiSkills.Distinct().Count()) return false;
        
        return true;
    }
}