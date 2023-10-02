using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace BotQnA1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("getresult")]
        public IActionResult GetResult([FromBody] string prompt)
        {
            string apikey = "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";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apikey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 200;
            var result = openai.Completions.CreateCompletionsAsync(completion);
            if (result!=null)
            {
                foreach (var item in result.Result.Completions)
                {
                    answer = item.Text;
                }
                return Ok(answer);

            }
            else
            {
                return BadRequest("Not Found");
            }
        }
    }
}
