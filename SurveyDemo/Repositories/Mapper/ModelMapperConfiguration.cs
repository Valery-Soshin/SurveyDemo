using SurveyDemo.Models;

namespace SurveyDemo.Repositories.Mapper
{
    public static class ModelMapperConfiguration
    {
        public static void ConfigureModels()
        {
            var surveyMapper = new Mapper(typeof(Survey));
            surveyMapper.Map("id", "Id");
            surveyMapper.Map("title", "Title");
            surveyMapper.Confirm();

            var interviewMapper = new Mapper(typeof(Interview));
            interviewMapper.Map("id", "Id");
            interviewMapper.Map("full_person_name", "FullPersonName");
            interviewMapper.Confirm();

            var questionMapper = new Mapper(typeof(Question));
            questionMapper.Map("id", "Id");
            questionMapper.Map("content", "Content");
            questionMapper.Map("survey_id", "SurveyId");
            questionMapper.Confirm();

            var asnwerMapper = new Mapper(typeof(Answer));
            asnwerMapper.Map("id", "Id");
            asnwerMapper.Map("content", "Content");
            asnwerMapper.Map("survey_id", "SurveyId");
            asnwerMapper.Map("question_id", "QuestionId");
            asnwerMapper.Confirm();

            var resultMapper = new Mapper(typeof(Result));
            resultMapper.Map("id", "Id");
            resultMapper.Map("interview_id", "InterviewId");
            resultMapper.Map("question_id", "QuestionId");
            resultMapper.Map("answer_id", "AnswerId");
            resultMapper.Confirm();
        }
    }
}