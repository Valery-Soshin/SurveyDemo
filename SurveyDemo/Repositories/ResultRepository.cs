using Dapper;
using SurveyDemo.Interfaces;
using SurveyDemo.Models;

namespace SurveyDemo.Repositories
{
    public class ResultRepository : RepositoryBase, IResultRepository
    {
        public ResultRepository(IConfiguration configuration)
            : base(configuration) { }

        public async Task<bool> Add(Result result)
        {
            string sql = @"INSERT INTO result(interview_id, question_id, answer_id)
                           VALUES(@InterviewId, @QuestionId, @AnswerId);";

            var parms = new { result.InterviewId, result.QuestionId, result.AnswerId };

            var affectedRows = await _connection.ExecuteAsync(sql, parms);
            return affectedRows > 0;
        }
    }
}