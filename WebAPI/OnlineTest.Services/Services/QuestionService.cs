using AutoMapper;
using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class QuestionService : IQuestionService
    {
        #region Fields
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Const
        public QuestionService(IQuestionRepository questionRepository, ITestRepository testRepository, IUserRepository userRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _testRepository = testRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        #endregion

        public ResponseDTO GetQuestions()
        {
            var response = new ResponseDTO();
            try
            {
                var getQues = _mapper.Map<List<GetQuestionDTO>>(_questionRepository.GetQuestions().ToList());
                if (getQues.Count > 0)
                {
                    response.Status = 200;
                    response.Data = getQues;
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

        public ResponseDTO GetQuestionById(int Id)
        {
            var response = new ResponseDTO();
            try
            {
                var resultQuesById = _questionRepository.GetQuestionById(Id);
                if (resultQuesById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "Question not found.";
                }
                else
                {
                    var result = _mapper.Map<GetQuestionDTO>(resultQuesById);
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

        public ResponseDTO GetQuestionByTestId(int testId)
        {
            var response = new ResponseDTO();
            try
            {
                var resultQueByTestId = _questionRepository.GetQuestionByTestId(testId);
                if (resultQueByTestId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "Question not found.";
                }
                else
                {
                    var result = _mapper.Map<GetQuestionDTO>(resultQueByTestId);
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

        public ResponseDTO AddQuestions(AddQuestionDTO question)
        {
            var response = new ResponseDTO();
            try
            {
                var resultCrId = _userRepository.GetUserById(question.CreateBy);
                if (resultCrId == null)
                {
                    response.Status = 404;
                    response.Message = "Bad Request.";
                    response.Error = "User not found.";
                }
                var resulttestId = _testRepository.GetTestById(question.TestId);
                if (resulttestId == null)
                {
                    response.Status = 404;
                    response.Message = "Bad Request.";
                    response.Error = "Test not found.";
                }
                if (resultCrId != null && resulttestId != null)
                {
                    var addQues = _questionRepository.AddQuestions(_mapper.Map<Questions>(question));
                    if (addQues!= null )
                    {
                        response.Status = 204;
                        response.Message = "Question is created;";
                    }
                    else
                    {
                        response.Status = 400;
                        response.Message = "Not Created.";
                        response.Error = "Question is not added.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO UpdateQuestions(UpdateQuestionDTO question)
        {
            var response = new ResponseDTO();
            try
            {
                var resulttestId = _testRepository.GetTestById(question.TestId);
                if (resulttestId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "Test not found.";
                }
                var questionById = _questionRepository.GetQuestionById(question.Id);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                if (resulttestId != null && questionById!=null)
                {
                    var updateQuestion = _questionRepository.UpdateQuestions(_mapper.Map<Questions>(question));

                    if (updateQuestion)
                    {
                        response.Status = 204;
                        response.Message = "Question is Updated;";
                    }
                    else
                    {
                        response.Status = 400;
                        response.Message = "Not Updated.";
                        response.Error = "Question is not Updated.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO Pagination(int page, int content)
        {
            var response = new ResponseDTO();
            try
            {
                var pg =_mapper.Map<List<GetQuestionDTO>>(_questionRepository.Paginnation(page, content).ToList());
                if (pg.Count > 0)
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
                response.Message = "Internal server error";
                response.Error = ex.Message;
            }
            return response;
        }
    }
}
