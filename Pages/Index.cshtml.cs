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
        string[] arraySymptomLabel=Request.Form["symptom"];
        string[] arraySymptomValues = Request.Form["severity"];
        string[] arraySymptomId = Request.Form["symptomId"];

        //Console.WriteLine("size "+arraySymptomLabel.Length);
        string separator = "-";

        string concatSymptomValues = string.Join(separator, arraySymptomValues);
        string concatSymptomlabel =string.Join(separator,arraySymptomLabel);
        string concatSymptomId =string.Join(separator,arraySymptomId);

        TempData["symptom"] = concatSymptomlabel;
        TempData["symptomId"] = concatSymptomId;
        TempData["severity"] = concatSymptomValues;

        return RedirectToPage("/Traitement");
    }
}
