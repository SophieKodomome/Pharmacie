using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical;
using connect;
using Npgsql;

namespace Pharmacie.Pages;

public class TraitementModel : PageModel
{
    public DBConnect connect;

    public List<Symptom> listSymptoms;
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
        string concatSymptomName = TempData["symptom"].ToString();
        string concatSymptomId = TempData["symptomId"].ToString();
        string concatSymptomValues = TempData["severity"].ToString();

        char[] delimiter = new char[] { '-' };

        string[] symptomName=concatSymptomName.Split(delimiter);
        int[] symptomId=Array.ConvertAll(concatSymptomId.Split(delimiter),int.Parse);
        int[] symptomValues=Array.ConvertAll(concatSymptomValues.Split(delimiter),int.Parse);

        for(int i=0;i<symptomValues.Length;i++){
            
        }
    }
    else
    {
        // Handle the case where TempData["severity"] is null
        Console.WriteLine("TempData['severity'] is null");

    }
    }
}