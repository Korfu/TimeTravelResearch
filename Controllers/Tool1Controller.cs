using Microsoft.AspNetCore.Mvc;
using TimeTravelResearch.Models;

namespace TimeTravelResearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Tool1Controller : ControllerBase
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
            var universities = new[]
            {
                new { Name = "Uniwersytet Jagielloński", Location = "Kraków" },
                new { Name = "Politechnika Warszawska", Location = "Warszawa" },
                new { Name = "Uniwersytet Warszawski", Location = "Warszawa" }
            };

            return Ok(new WebhookResponse { Output = System.Text.Json.JsonSerializer.Serialize(universities) });
        }
    }
} 