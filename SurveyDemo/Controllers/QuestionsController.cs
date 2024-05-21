using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SurveyDemo.Interfaces;

namespace SurveyDemo.Controllers
{
    [ApiController]
    [Route("/api/surveys/{surveyId}/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<QuestionsController> _logger;

        public QuestionsController(IQuestionRepository surveyRepository,    
                                   ILogger<QuestionsController> logger)
        {
            _questionRepository = surveyRepository;
            _logger = logger;
        }
        
        [HttpGet("first")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFirstQuestion([FromRoute] int surveyId)
        {
            try
            {
                var survey = await _questionRepository.GetFirstQuestion(surveyId);
                if (survey is null)
                {
                    return BadRequest();
                }
                return Ok(survey);
            }
            catch(PostgresException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{questionsId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetQuestion([FromRoute] int questionsId)
        {
            try
            {
                var survey = await _questionRepository.GetById(questionsId);
                if (survey is null)
                {
                    return BadRequest();
                }
                return Ok(survey);
            }
            catch(PostgresException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}