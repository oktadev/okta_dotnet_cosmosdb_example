using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Okta_CosmosDb.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        Services.IScrubService _scrubService;
        Services.ICosmosService _cosmosService;

        public ImportController(
            Services.IScrubService scrubService,
            Services.ICosmosService cosmosService
            )
        {
            _scrubService = scrubService;
            _cosmosService = cosmosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile csvFile)
        {
            List<Models.Person> persons = new List<Models.Person>();

            using (var stream = csvFile.OpenReadStream())
            using (StreamReader sr = new StreamReader(stream))
            {
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadToEnd().Split(Environment.NewLine);          
                    
                    for(int i =0; i < rows.Length; i++)
                    {
                       if(i == 0)
                        {
                            //header row
                            continue;
                        }

                        var row = rows[i].Split(',');

                        persons.Add(new Models.Person()
                        {
                            Name = row[0],
                            SSN = row[1]
                        });
                    }
                }
            }

            List<Models.ScrubResult> results = new List<Models.ScrubResult>();

            foreach(var person in persons)
            {
                results.Add(await _scrubService.ScrubAsync(person));
            }

            foreach(var result in results)
            {
                _cosmosService.SaveResultAsync(result);
            }


            return View(results);
        }
    }
}
