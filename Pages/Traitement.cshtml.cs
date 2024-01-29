using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical;
using connect;
using Npgsql;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Pharmacie.Pages;

public class TraitementModel : PageModel
{
    private DBConnect connect;

    private List<Symptom> listSymptoms = new List<Symptom>();
    private List<Symptom> ListSymptoms { get; set; } = new List<Symptom>();
    private List<Illness> listIllnesses = new List<Illness>();
    private List<Illness> ListIllnesses { get; set; } = new List<Illness>();

    private Illness illness;

    private bool error = true;

    public bool Error { get; set; }
    private Med med;

    public Illness Illness { get; set; }
    public Med Med { get; set; }

    public int prix;

    public int total;
    public int quantite;
    public int Prix{get;set;}
    public int Total{get;set;}
    public int Quantite{get;set;}
    private readonly ILogger<TraitementModel> _logger;

    public TraitementModel(ILogger<TraitementModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Console.WriteLine("traitement");
        connect = new DBConnect();
        using (var connection = new NpgsqlConnection(connect.ConnectionString))
        {
            ListIllnesses = Illness.GetIllnessesFromDB(connection);
            for (int i = 0; i < ListIllnesses.Count; i++)
            {
                ListIllnesses[i].addListSymptoms(Symptom.getSymptomsForIllness(connection, i + 1));
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

            ListSymptoms = ConstructListSymptom(symptomName, symptomId, symptomValues);
            /*foreach (
                Symptom item in ListSymptoms)
            {
                Console.WriteLine(item.Name + " " + item.Id + " " + item.Severity);
            }
            Console.WriteLine("\n");*/
            Illness = DiagnosesIllness(ListIllnesses, ListSymptoms);
            using (var medConnection = new NpgsqlConnection(connect.ConnectionString))
            {
                    Med = new Med().getMedFromDB(medConnection, Illness.Id);
                    Prix=Med.Prix;
                    Quantite=Med.Quantite;
                    Total=Prix*Quantite;

            }

        }
        else
        {
            // Handle the case where TempData["severity"] is null
            Console.WriteLine("TempData['severity'] is null");

        }



    }
    private List<Symptom> ConstructListSymptom(string[] n, int[] id, int[] s)
    {
        List<Symptom> ls = new List<Symptom>();
        for (int i = 0; i < s.Length; i++)
        {
            Symptom itemSymptoms = new Symptom();
            itemSymptoms.addSeverity(s[i]).addName(n[i]).addId(id[i]);
            ls.Add(itemSymptoms);
        }

        return ls;
    }
    private Illness DiagnosesIllness(List<Illness> listIllnesses, List<Symptom> listSymptoms)
    {
        Illness result = new Illness();
        List<Symptom> n_listSymptoms = PurgeSymptoms(listSymptoms);
        List<Illness> n_listIllnesses = PurgeIllness(listIllnesses, n_listSymptoms);
        List<Illness> n2_listIllnesses = new List<Illness>();

        foreach (var item in n_listIllnesses)
        {
            if (CheckTrue(item.ListSymptoms) == true)
            {
                n2_listIllnesses.Add(item);
                Console.WriteLine(item.Name + " from idk");
            }
        }
        result = CompareIllnesses(n2_listIllnesses, n_listSymptoms);

        return result;
    }
    private List<Symptom> PurgeSymptoms(List<Symptom> listSymptoms)
    {
        List<Symptom> newList = new List<Symptom>();
        Console.WriteLine("from PurgeSymptoms");
        foreach (var item in listSymptoms)
        {
            if (item.Severity != 0)
            {
                newList.Add(item);
                Console.WriteLine(item.Name + " " + item.Severity + " from PurgeSymptoms");
            }
        }
        Console.WriteLine("\n");
        return newList;
    }
    private List<Illness> PurgeIllness(List<Illness> listIllnesses, List<Symptom> listSymptoms)
    {
        List<Illness> newList = new List<Illness>();
        Console.WriteLine("from PurgeIllness");
        foreach (var symptom in listSymptoms)
        {
            for (int i = 0; i < listIllnesses.Count; i++)
            {
                for (int j = 0; j < listIllnesses[i].ListSymptoms.Count; j++)
                {
                    if (listIllnesses[i].ListSymptoms[j].Id == symptom.Id)
                    {
                        if (newList.Contains(listIllnesses[i]))
                        {
                            listIllnesses[i].ListSymptoms[j].IsASymptom = true;
                            listIllnesses[i].ListSymptoms[j].addSeverity(symptom.Severity);
                            newList[newList.IndexOf(listIllnesses[i])] = listIllnesses[i];
                            Console.WriteLine(symptom.Severity);
                            Console.WriteLine(newList[newList.IndexOf(listIllnesses[i])].Name + " " + listIllnesses[i].ListSymptoms[j].Severity + " from PurgeIllness");
                        }
                        else
                        {
                            listIllnesses[i].ListSymptoms[j].IsASymptom = true;
                            listIllnesses[i].ListSymptoms[j].addSeverity(symptom.Severity);
                            newList.Add(listIllnesses[i]);
                        }
                    }
                }
            }
        }
        Console.WriteLine('\n');

        return newList;
    }
    private bool CheckTrue(List<Symptom> symptoms)
    {
        bool result = false;

        for (int i = 0; i < symptoms.Count; i++)
        {
            Console.WriteLine(symptoms[i].Name + " " + symptoms[i].Severity + " before check");
            if (symptoms[i].IsASymptom == true & symptoms[i].MaxPain >= symptoms[i].Severity && symptoms[i].MinPain <= symptoms[i].Severity)
            {
                Console.WriteLine(symptoms[i].Name + " " + symptoms[i].Severity);
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }

        return result;
    }
    private Illness CompareIllnesses(List<Illness> listIllnesses, List<Symptom> listSymptoms)
    {
        Illness result = new Illness();
        int initialValue = int.MaxValue;

        foreach (var illness in listIllnesses)
        {
            int difference = GetDifference(illness.ListSymptoms, listSymptoms);

            if (difference < initialValue)
            {
                initialValue = difference;
                result = illness;
            }
        }
        return result;
    }

    private int GetDifference(List<Symptom> illnessSymptoms, List<Symptom> patientSymptoms)
    {
        int maxDifference = 0;

        foreach (var illnessSymptom in illnessSymptoms)
        {
            foreach (var patientSymptom in patientSymptoms)
            {
                if (illnessSymptom.Id == patientSymptom.Id)
                {
                    int difference = Math.Abs(illnessSymptom.MaxPain - patientSymptom.Severity);
                    if (difference > maxDifference)
                    {
                        maxDifference = difference;
                    }
                }
            }
        }

        return maxDifference;
    }
}