using System.Text.Json.Serialization;

namespace StackOverflowProject.Models
{
    public class Answer
    {
        [JsonPropertyName("answer_id")]
        public int AnswerID { get; set; }

        [JsonPropertyName("question_id")]
        public int QuestionID { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; } = string.Empty;

        //not sure if i want to add a score or not- just something fun to think about.
        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}