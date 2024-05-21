namespace SurveyDemo.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}