namespace SurveyDemo.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<Question> Questions { get; set; } = [];
    }
}