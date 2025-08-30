namespace Shin_Megami_Tensei.Parsers;

using Shin_Megami_Tensei.Models;

public static class TeamParser
{
    public static void ParseTeamsFile(string path, out List<string> player1Team, out List<string> player2Team)
    {
        player1Team = new();
        player2Team = new();

        const string p1 = "Player 1 Team";
        const string p2 = "Player 2 Team";

        List<string>? current = null;

        foreach (var raw in File.ReadLines(path))
        {
            var line = raw.Trim();
            if (line.Length == 0) continue;

            if (line.Equals(p1)) { current = player1Team; continue; }
            if (line.Equals(p2)) { current = player2Team; continue; }

            current.Add(line);
        }
    }
    
    private const string SamuraiHeader = "[Samurai]";

    public static Team BuildTeamFromLines(IEnumerable<string> teamLines)
    {
        var team = new Team();

        foreach (var raw in teamLines)
        {
            var line = raw?.Trim();
            
            if (TryParseSamuraiLine(line, out var name, out var skills))
            {
                team.SamuraiCounter++;
                team.SamuraiName = name;
                team.SamuraiSkills.AddRange(skills);

                if (!string.IsNullOrWhiteSpace(name))
                    team.Units.Add(name);

                continue;
            }

            team.Units.Add(line);
        }
        return team;
    }

    private static bool TryParseSamuraiLine(string line, out string name, out List<string> skills)
    {
        name = string.Empty;
        skills = new List<string>();

        if (!line.StartsWith(SamuraiHeader))
            return false;

        var body = line.Substring(SamuraiHeader.Length).Trim();

        var openParenthesis = body.IndexOf('(');
        if (openParenthesis == -1)
        {
            name = body.Trim();
            return true;
        }

        var closeParenthesis = body.IndexOf(')', openParenthesis + 1);

        name = body[..openParenthesis].Trim();

        var skillsString = body[(openParenthesis + 1)..closeParenthesis];
        foreach (var skillName in skillsString.Split(','))
            skills.Add(skillName.Trim());

        return true;
    }

}