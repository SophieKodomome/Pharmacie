using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical;
using connect;
using Npgsql;

namespace Pharmacie.Pages;

public class TraitementModel : PageModel
{
    public string concatSymptomValues {get;set;}
    public DBConnect connect;
    public List<Symptom> ListSymptoms { get; set; }
    private readonly ILogger<TraitementModel> _logger;

    public TraitementModel(ILogger<TraitementModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    if (TempData["severity"] != null)
    {
        concatSymptomValues = TempData["severity"].ToString();
        Console.WriteLine(concatSymptomValues);
    }
    else
    {
        // Handle the case where TempData["severity"] is null
        Console.WriteLine("TempData['severity'] is null");
    }
    }
}