using System.Text.Json.Serialization;

namespace StackOverflowProject.Models
{
    public class Question
    {
        [JsonPropertyName("question_id")]
        public int QuestionID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("answer_count")]
        public int AnswerCount { get; set; }

        [JsonPropertyName("accepted_answer_id")]
        public int? AcceptedAnswerID { get; set; }

        public List<Answer> Answers { get; set; } = new();
    }
}