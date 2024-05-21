namespace SurveyDemo.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int SurveyId { get; set; }
        public List<Answer> Answers { get; set; } = [];
    }
}