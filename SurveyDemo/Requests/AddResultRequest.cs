namespace SurveyDemo.Requests
{
    public class AddResultRequest
    {
        public int InterviewId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int QuestionNumber { get; set; } = 1;
    }
}