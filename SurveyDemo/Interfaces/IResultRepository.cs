using SurveyDemo.Models;

namespace SurveyDemo.Interfaces
{
    public interface IResultRepository
    {
        Task<bool> Add(Result result);
    }
}
