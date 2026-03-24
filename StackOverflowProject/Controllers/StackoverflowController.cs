using Microsoft.AspNetCore.Mvc;

namespace StackOverflowProject.Controllers;

public class StackoverflowController : Controller
{

    public class ViewModel
    {
        public List<string> Questions { get; set; }
        public int QuestionID { get; set; }
        public int AnswerCount { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
    public IActionResult Index()
    {
        var model = new ViewModel();

        return View(model);
    }
}
