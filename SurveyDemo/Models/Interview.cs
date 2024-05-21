namespace SurveyDemo.Models
{
    public class Interview
    {
        public int Id { get; set; }
        public string FullPersonName { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
    }
}
