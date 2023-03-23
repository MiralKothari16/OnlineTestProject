using AutoMapper;
using Microsoft.EntityFrameworkCore.Update;
using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Model.Repository;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class AnswerService : IAnswerService
    {
        #region Field
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionAnswerMappingRepository _questionAnswerMappingRepository;
        #endregion  
        #region Const
        public AnswerService(IAnswerRepository answerRepository, ITestRepository testRepository, IQuestionRepository questionRepository, IQuestionAnswerMappingRepository questionAnswerMappingRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _questionAnswerMappingRepository = questionAnswerMappingRepository;
        }
        #endregion

        #region Methods

        public ResponseDTO GetAnswer()
        {
            var response = new ResponseDTO();
            try
            {
                var getAns = _mapper.Map<List<GetAnswerDTO>>(_answerRepository.GetAnswer().ToList());
                if (getAns.Count() > 0)
                {
                    response.Status = 200;
                    response.Data = getAns;
                    response.Message = "OK";
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "No data found.";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO GetAnswerById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var getAnsById = _answerRepository.GetAnswerById(id);
                if (getAnsById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "No data found.";
                }
                else
                {
                    var result = _mapper.Map<GetAnswerDTO>(getAnsById);
                    response.Status = 200;
                    response.Data = result;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO AddAnswer(AddAnswerDTO answer)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(answer.TestId);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test not found";
                    return response;
                }
                var questionById = _questionRepository.GetQuestionById(answer.QuestionId);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                var isansexist = _answerRepository.isAnswerExist(answer.TestId, answer.QuestionId, answer.Answers);
                if (isansexist)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Answer is already added.";
                    return response;
                }
                var addans = _answerRepository.AddAnswer(_mapper.Map<Answer>(answer));
                if (addans > 0)
                {
                    response.Status = 204;
                    response.Message = "Answer Created.";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Created.";
                    response.Error = "Answer is not added.";
                }
                var map = new QuestionAnswerMapping
                {
                    TestId = answer.TestId,
                    QuestionId = answer.QuestionId,
                    AnswerId = Convert.ToInt32(addans),
                    Active = true,
                    CreateBy = answer.CreatedBy,
                    CreatedOn = answer.CreatedOn,
                };
                _questionAnswerMappingRepository.AddQAMapping(map);
                response.Status = 201;
                response.Message = "Created";
                response.Data = Convert.ToInt32(addans);

            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO UpdateAnswer(UpdateAnswerDTO answer)
        {
            var response = new ResponseDTO();
            try
            {
                var answerById = _answerRepository.GetAnswerById(answer.Id);
                if (answerById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Answer not found";
                    return response;
                }
                var updateAns = _answerRepository.UpdateAnswer(_mapper.Map<Answer>(answer));
                if (updateAns != null)
                {
                    response.Status = 204;
                    response.Message = "Answer Updated.";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated.";
                    response.Error = "Answer is not updated.";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO Pagination(int page, int content)
        {
            var response = new ResponseDTO();
            try
            {
                var pg = _mapper.Map<List<GetAnswerDTO>>(_answerRepository.Pagination(page, content).ToList());
                if (pg != null)
                {
                    response.Status = 200;
                    response.Data = pg;
                    response.Message = "OK";
                }
                //else
                //{
                //    response.Status = 404;
                //    response.Message = "No data found.";
                //    response.Error = "No content found for this page.";
                //}
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }
        #endregion

    }
}
