using SurveyDemo.Models;

namespace SurveyDemo.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetById(int id);
        Task<Question?> GetFirstQuestion(int surveyId);
        Task<int> GetNextQuestionId(int surveyId, int currentQuestionNumber);
    }
}