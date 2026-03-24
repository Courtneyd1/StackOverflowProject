namespace StackOverflowProject.Models;

public class StackoverflowGameViewModel
{
    public List<QuestionSummary> Questions { get; set; } = [];
    public long? SelectedQuestionId { get; set; }
    public string? SelectedQuestionTitle { get; set; }
    public string? SelectedQuestionLink { get; set; }
    public int? AcceptedAnswerId { get; set; }
    public int? GuessedAnswerId { get; set; }
    public bool? GuessWasCorrect { get; set; }
    public string? ErrorMessage { get; set; }
    public List<AnswerSummary> Answers { get; set; } = [];
}

public class QuestionSummary
{
    public long QuestionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public int AcceptedAnswerId { get; set; }
    public int AnswerCount { get; set; }
}

public class AnswerSummary
{
    public int AnswerId { get; set; }
    public string OwnerDisplayName { get; set; } = "Unknown";
    public int Score { get; set; }
    public string BodyHtml { get; set; } = string.Empty;
}
