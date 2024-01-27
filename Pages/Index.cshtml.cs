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
    }
}
