using Dapper;
using SurveyDemo.Interfaces;
using SurveyDemo.Models;

namespace SurveyDemo.Repositories
{
    public class QuestionRepository : RepositoryBase, IQuestionRepository
    {
        public QuestionRepository(IConfiguration configuration)
            : base(configuration) { }

        public async Task<Question?> GetById(int id)
        {
            string selectQuestionSql = @"SELECT *
                                         FROM question
                                         WHERE id = @Id";

            var question = await _connection.QuerySingleOrDefaultAsync<Question>(
                selectQuestionSql, new { Id = id });

            if (question is null) return question;

            question.Answers = await GetAnswers(question.Id);
            return question;
        }
        public async Task<Question?> GetFirstQuestion(int surveyId)
        {
            string selectQuestionSql = @"SELECT *
                                         FROM question
                                         WHERE survey_id = @SurveyId
                                         LIMIT 1";

            var question = await _connection.QueryFirstOrDefaultAsync<Question>(
                selectQuestionSql, new { SurveyId = surveyId });

            if (question is null) return question;

            question.Answers = await GetAnswers(question.Id);
            return question;
        }
        public async Task<int> GetNextQuestionId(int surveyId, int currentQuestionNumber)
        {
            string sql = @"SELECT id
                           FROM question
                           WHERE survey_id = @SurveyId
                           OFFSET @QuestionNumber
                           LIMIT 1;";

            var parms = new { SurveyId = surveyId, QuestionNumber = currentQuestionNumber };
            int nextQuestionId = await _connection.QueryFirstAsync<int>(sql, parms);
            return nextQuestionId;
        }

        private async Task<List<Answer>> GetAnswers(int questionId)
        {
            string selectAnswersSql = @"SELECT *
                                        FROM answer 
                                        WHERE question_id = @QuestionId";

            var answers = await _connection.QueryAsync<Answer>(selectAnswersSql,
                new { QuestionId = questionId });

            return answers.ToList();
        }
    }
}