using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical;
using connect;
using Npgsql;

namespace Pharmacie.Pages;

public class TraitementModel : PageModel
{
    private DBConnect connect;

    private List<Symptom> listSymptoms = new List<Symptom>();
    private List<Symptom> ListSymptoms { get; set; } = new List<Symptom>();
    private List<Illness> listIllnesses = new List<Illness>();
    private List<Illness> ListIllnesses {get;set;}=new List<Illness>();


    private readonly ILogger<TraitementModel> _logger;

    public TraitementModel(ILogger<TraitementModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        connect= new DBConnect();
        using(var connection=new NpgsqlConnection(connect.ConnectionString))
        {
            ListIllnesses=Illness.GetIllnessesFromDB(connection);
            for (int i = 0; i < ListIllnesses.Count; i++)
            {
                ListIllnesses[i].addListSymptoms(Symptom.getSymptomsForIllness(connection,i+1));
            }
        }

        if (TempData["severity"] != null)
        {
            string concatSymptomName = TempData["symptom"].ToString();
            string concatSymptomId = TempData["symptomId"].ToString();
            string concatSymptomValues = TempData["severity"].ToString();

            char[] delimiter = new char[] { '-' };

            string[] symptomName = concatSymptomName.Split(delimiter);
            int[] symptomId = Array.ConvertAll(concatSymptomId.Split(delimiter), int.Parse);
            int[] symptomValues = Array.ConvertAll(concatSymptomValues.Split(delimiter), int.Parse);

            ListSymptoms=ConstructListSymptom(symptomName,symptomId,symptomValues);

        }
        else
        {
            // Handle the case where TempData["severity"] is null
            Console.WriteLine("TempData['severity'] is null");

        }


    }
    private List<Symptom> ConstructListSymptom(string[] n,int[] id,int[] s){
            List<Symptom> ls=new List<Symptom>();
            for (int i = 0; i < s.Length; i++)
            {
                Symptom itemSymptoms = new Symptom();
                itemSymptoms.addSeverity(s[i]).addName(n[i]).addId(id[i]);
                ls.Add(itemSymptoms);
            }

            return ls;
    }
}