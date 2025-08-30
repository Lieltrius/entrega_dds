using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Models;
using Shin_Megami_Tensei.Parsers;

namespace Shin_Megami_Tensei;

public class Game
{
    private View _view;
    private readonly string _teamsFolder;
    
    private List<string> _teamFiles = new();
    private int _selectedIndexTeam = -1;
    private string? _selectedFilePathTeam;
    
    private List<string> _team1RawLines = new();
    private List<string> _team2RawLines = new();
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }
    
    public void Play()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        _teamFiles = Directory.GetFiles(_teamsFolder, "*.txt")
            .OrderBy(p => Path.GetFileName(p))
            .ToList();
        
        // Mostrar en pantalla los archivos que contiene los equipos a elegir
        for (int i = 0; i < _teamFiles.Count; i++) { _view.WriteLine($"{i}: { Path.GetFileName(_teamFiles[i])}"); }
        
        var userInputTeam = _view.ReadLine();
        if (!int.TryParse(userInputTeam, out _selectedIndexTeam)) return;
        if (_selectedIndexTeam < 0 || _selectedIndexTeam >= _teamFiles.Count) return;

        _selectedFilePathTeam = _teamFiles[_selectedIndexTeam];

        TeamParser.ParseTeamsFile(_selectedFilePathTeam, out _team1RawLines, out _team2RawLines);
        
        var team1Lines = TeamParser.BuildTeamFromLines(_team1RawLines);
        var team2Lines = TeamParser.BuildTeamFromLines(_team2RawLines);
        
        if (!TeamValidator.IsValid(team1Lines) || !TeamValidator.IsValid(team2Lines))
        {
            _view.WriteLine("Archivo de equipos inválido");
            return;
        }

        return;
    }
}

