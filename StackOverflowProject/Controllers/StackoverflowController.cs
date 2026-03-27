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

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        string questionsUrl = "2.3/search/advanced" +
                              "?order=desc" +
                              "&sort=activity" +
                              "&accepted=true" +
                              "&answers=2" +
                              "&pagesize=25" +
                              "&site=stackoverflow";

        var questionsJson = client.GetStringAsync(questionsUrl).Result;

        var questionResponse = JsonSerializer.Deserialize<StackExchangeResponse<Question>>(questionsJson, options);

        var questions = questionResponse?.Items ?? [];

        questions = questions
            .Where(q => q.AnswerCount > 1)
            .ToList();

        var allAnswers = new List<Answer>();
        var questionIds = questions.Select(q => q.QuestionID).ToList();

        if (questionIds.Count > 0)
        {
            string ids = string.Join(";", questionIds);

            string answersUrl = $"2.3/questions/{ids}/answers" +
                                "?order=desc" +
                                "&sort=votes" +
                                "&pagesize=100" +
                                "&site=stackoverflow" +
                                "&filter=withbody";

            var answersJson = client.GetStringAsync(answersUrl).Result;

            var answerResponse = JsonSerializer.Deserialize<StackExchangeResponse<Answer>>(answersJson, options);

            allAnswers = answerResponse?.Items ?? [];

            foreach (var question in questions)
            {
                var answersForQuestion = allAnswers
                    .Where(a => a.QuestionID == question.QuestionID)
                    .ToList();

                ShuffleInPlace(answersForQuestion);
                question.Answers = answersForQuestion;
            }
            questions = questions
                .Where(q => q.Answers.Count > 0)
                .ToList();
        }

        var model = new ViewModel
        {
            Questions = questions,
            Answers = allAnswers
        };

        return View(model);
    }

    //randomizing the lit of questions so the first answer is not always the right one.
    private static void ShuffleInPlace(List<Answer> answers)
    {
        for (int i = answers.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (answers[i], answers[j]) = (answers[j], answers[i]);
        }
    }
}

public class StackExchangeResponse<T>
{
    public List<T> Items { get; set; } = [];
}