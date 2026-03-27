namespace StackOverflowProject.Models
{
    public class Question
    {
        public int AnswerCount { get; set; }
        public int QuestionID { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; } = new();
    }
}
