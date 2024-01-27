using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical;
using connect;
using Npgsql;
using System.Numerics;

namespace Pharmacie.Pages;

public class IndexModel : PageModel
{
    public DBConnect connect;
    public List<Symptom> listSymptoms = new List<Symptom>();


    private readonly ILogger<IndexModel> _logger;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        connect = new DBConnect();
        using (var connection = new NpgsqlConnection(connect.ConnectionString))
        {
            listSymptoms = new Symptom().getSymptomsFromDB(connection);
        }
        //ListSymptoms=listSymptoms;
    }

    public IActionResult OnPost()
    {
        var symptomValues = Request.Form["severity"];
        string[] stringSymptomValues = new string[symptomValues.Count];

        for (int i = 0; i < stringSymptomValues.Count(); i++)
        {
            stringSymptomValues[i] = symptomValues[i];
        }
        string separator = "-";
        string concatSymptomValues = string.Join(separator, stringSymptomValues);

        TempData["severity"] = concatSymptomValues;

        return RedirectToPage("/Traitement");
    }
}
