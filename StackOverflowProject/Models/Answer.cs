namespace StackOverflowProject.Models
{
    public class Answer
    {
        public bool AcceptedAnswer { get; set; }
        public int AnswerID { get; set; }
        public string Body { get; set; }
        public int QuestionID { get; set; }
    }
}
