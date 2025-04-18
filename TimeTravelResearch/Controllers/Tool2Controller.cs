using Microsoft.AspNetCore.Mvc;
using TimeTravelResearch.Models;

namespace TimeTravelResearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Tool2Controller : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] WebhookRequest request)
        {
            // Test verification
            if (request.Input.StartsWith("test"))
            {
                return Ok(new WebhookResponse { Output = request.Input });
            }

            // Sample data - in a real scenario, this would be a database query
            var researchData = new
            {
                University = "Uniwersytet Jagielloński",
                TeamMembers = new[]
                {
                    "Prof. dr hab. Jan Kowalski",
                    "Dr Anna Nowak",
                    "Mgr Piotr Wiśniewski",
                    "Dr hab. Maria Zielińska"
                },
                Sponsor = "Polska Agencja Kosmiczna"
            };

            return Ok(new WebhookResponse { Output = System.Text.Json.JsonSerializer.Serialize(researchData) });
        }
    }
} 