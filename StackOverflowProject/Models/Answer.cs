namespace StackOverflowProject.Models
{
    public class Answer
    {
        public bool AcceptedAnswer { get; set; }
        public int AnswerID { get; set; }
        public string Body { get; set; } = string.Empty;
        public int QuestionID { get; set; }
    }
}
