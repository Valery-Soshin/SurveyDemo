using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SurveyDemo.Interfaces;
using SurveyDemo.Models;
using SurveyDemo.Requests;

namespace SurveyDemo.Controllers
{
    [ApiController]
    [Route("/api/surveys/{surveyId}/results")]
    public class ResultsController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<ResultsController> _logger;

        public ResultsController(IResultRepository resultRepository,
                                 IQuestionRepository questionRepository,
                                 ILogger<ResultsController> logger)
        {
            _resultRepository = resultRepository;
            _questionRepository = questionRepository;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Add([FromRoute] int surveyId, AddResultRequest request)
        {
            try
            {
                var result = new Result()
                {
                    InterviewId = request.InterviewId,
                    QuestionId = request.QuestionId,
                    AnswerId = request.AnswerId
                };
                if (!await _resultRepository.Add(result))
                {
                    return BadRequest();
                }

                int nextQuestionId = await _questionRepository.GetNextQuestionId(
                    surveyId, request.QuestionNumber);

                return CreatedAtAction(nameof(Add), nextQuestionId);
            }
            catch (PostgresException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}