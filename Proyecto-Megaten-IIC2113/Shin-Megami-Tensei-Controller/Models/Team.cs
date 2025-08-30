namespace Shin_Megami_Tensei.Models;

/*
 * Cosas que debería tener la clase Team
 * 1. Samurai
 * 2. Lista de Montruos
 * 3. Lista de Skills
 */

public class Team
{
    public string SamuraiName { get; set; } = "";

    public int SamuraiCounter = 0;
    public List<string> SamuraiSkills { get; } = new();
    public List<string> Units { get; } = new();
}