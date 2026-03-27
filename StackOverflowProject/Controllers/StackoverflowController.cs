using Microsoft.AspNetCore.Mvc;
using StackOverflowProject.Models;
using System.Text.Json;

namespace StackOverflowProject.Controllers;

public class StackoverflowController : Controller
{
    public class ViewModel
    {
        public List<Question> Questions { get; set; } = [];
        public List<Answer> Answers { get; set; } = [];
    }

    public IActionResult Index([FromServices] IHttpClientFactory factory)
    {
        var client = factory.CreateClient("StackExchange");

        string url = "2.3/search/advanced" +
                     "?order=desc" +
                     "&sort=activity" +
                     "&accepted=true" +
                     "&answers=2" +
                     "&site=stackoverflow";

        var json = client.GetStringAsync(url).Result;

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var apiResponse = JsonSerializer.Deserialize<StackExchangeResponse<Question>>(json, options);

        var model = new ViewModel
        {
            Questions = apiResponse?.Items ?? []
        };

        return View(model);
    }
}

public class StackExchangeResponse<T>
{
    public List<T> Items { get; set; } = [];
}