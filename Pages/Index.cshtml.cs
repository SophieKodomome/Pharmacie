using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical;
using connect;

namespace Pharmacie.Pages;

public class IndexModel : PageModel
{
    public DBConnect connect{get;set;}
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        connect = new DBConnect();
        Console.WriteLine(connect.Test + "from index View");
    }
}
