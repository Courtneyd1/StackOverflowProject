using Microsoft.AspNetCore.Mvc;
using StackOverflowProject.Models;

namespace StackOverflowProject.Controllers;

public class StackoverflowController : Controller
{
    public class ViewModel
    {
        public List<Question> Questions { get; set; } = [];
        public List<Answer> Answers { get; set; } = [];
    }

    public IActionResult Index()
    {
        var questions = new List<Question>
    {
        new Question
        {
            QuestionID = 1,
            Title = "I am a question.",
            AnswerCount = 3,
        },
        new Question
        {
            QuestionID = 2,
            Title = "How do you write a string.",
            AnswerCount = 3,
        }
    };

        var answers = new List<Answer>
    {
        new Answer { AnswerID = 1, QuestionID = 1, Body = "I am an answer.", AcceptedAnswer = true },
        new Answer { AnswerID = 2, QuestionID = 1, Body = "i am the wrong answer", AcceptedAnswer = false },
        new Answer { AnswerID = 3, QuestionID = 1, Body = "also the wrong answer", AcceptedAnswer = false },

        new Answer { AnswerID = 4, QuestionID = 2, Body = "var string = something between quotes", AcceptedAnswer = true },
        new Answer { AnswerID = 5, QuestionID = 2, Body = "string = string", AcceptedAnswer = false },
        new Answer { AnswerID = 6, QuestionID = 2, Body = "string", AcceptedAnswer = false },
    };

        foreach (var question in questions)
        {
            question.Answers = answers
                .Where(a => a.QuestionID == question.QuestionID)
                .ToList();
        }

        var model = new ViewModel
        {
            Questions = questions
        };

        return View(model);
    }
}
