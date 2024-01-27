using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical;
using connect;
using Npgsql;

namespace Pharmacie.Pages;

public class IndexModel : PageModel
{
    public DBConnect connect;
    public List<Symptom> listSymptoms = new List<Symptom>();

    //public List<Symptom> ListSymptoms{get;set;}
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
        
        Console.WriteLine(listSymptoms.Count);
        for(int i=0;i<listSymptoms.Count;i++){
            int j=i+1;
            double severity= double.Parse(Request.Form["Symptom"+j+"Value"])/100;
            listSymptoms[i].Severity=severity;
            Console.WriteLine("hi mom");
        }
        return RedirectToPage("/Traitement");
    }
}
