using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
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
    public class TestService : ITestService
    {
        #region Field
        private readonly ITestRepository _testrepository;
        private readonly IUserRepository _userRepository;
        private readonly ITechnologyRepository _technologyRepository;
        // private readonly IQuestionAnswerMapping _questionAnswerMapping;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Cntr
        public TestService(ITestRepository testrepository, IUserRepository userRepository, ITechnologyRepository technologyRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, IMapper mapper)//IQuestionAnswerMapping questionAnswerMapping)
        {
            _testrepository = testrepository;
            _userRepository = userRepository;
            _technologyRepository = technologyRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
            // _questionAnswerMapping = questionAnswerMapping;
        }
        #endregion
        #region Methods
        public ResponseDTO GetTest()
        {
            var response = new ResponseDTO();
            try
            {
                var gettest = _mapper.Map<List<GetTestDTO>>(_testrepository.GetTest().ToList());
                if (gettest.Count == 0)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "No Data found.";
                }
                else
                {
                    response.Status = 200;
                    response.Data = gettest;
                    response.Error = "OK";
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
        public ResponseDTO GetTestById(int Id)
        {
            var response = new ResponseDTO();
            try
            {
                var resultTestById = _testrepository.GetTestById(Id);
                if (resultTestById == null)
                {
                    response.Status = 404;
                    response.Message = "Not found.";
                    response.Error = "Test not found.";
                    return response;
                }
                else
                {
                    var result = _mapper.Map<GetTestDTO>(resultTestById);
                    var Questions = _mapper.Map<List<GetQuestionDTO>>(_questionRepository.GetQuestionByTestId(resultTestById.Id).ToList());
                    foreach (var question in Questions)
                    {
                        var AnswerList = _mapper.Map<List<GetAnswerDTO>>(_answerRepository.GetAnswerByQuestionId(question.Id).ToList());
                        question.Answers = AnswerList;
                    }
                    result.Questions = Questions;
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

        public ResponseDTO GetTestByTechnologyId(int technologyId)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(technologyId);
                if (technologyById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }
               
                var data = _mapper.Map<List<GetTestDTO>>(_testrepository.GetTestByTechnologyId(technologyId)).ToList();
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception ex) 
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO AddTest(AddTestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var resultCrId = _userRepository.GetUserById(test.CreatedBy);
                if (resultCrId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "User not found.";
                    return response;
                }
                var resultTechId = _technologyRepository.GetTechnologyById(test.TechnologyId);
                if (resultTechId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "Technology not found.";
                }

                if (resultCrId != null && resultTechId != null)
                {
                    var addTest = _testrepository.AddTest(_mapper.Map<Test>(test));
                    if (addTest)
                    {
                        response.Status = 204;
                        response.Message = "Test is  Created.";
                    }
                    else
                    {
                        response.Status = 400;
                        response.Message = "Bad Request.";
                        response.Error = "Test is not created.";
                    }
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

        public ResponseDTO UpdateTest(UpdateTestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var testbyId = _testrepository.GetTestById(test.Id);
                if (testbyId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "Test not found.";
                    return response;
                }
                var UpdateTest = _testrepository.UpdateTest(_mapper.Map<Test>(test));
                if (UpdateTest != null)
                {
                    response.Status = 204;
                    response.Message = "Test Updated Successfully.";
                    return response;
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated.";
                    response.Error = "Test is not updated.";
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

        public ResponseDTO TestPagination(int page, int content)
        {
            var response = new ResponseDTO();
            try
            {
                var pg = _mapper.Map<List<GetTestDTO>>(_testrepository.TestPagination(page, content).ToList());
                if (pg.Count > 0)
                {
                    response.Status = 200;
                    response.Data = pg;
                    response.Message = "OK";
                }
                //else
                //{
                //    response.Status = 404;
                //    response.Message = "No Data Found";
                //    response.Error = "No content found for this page.";
                //}
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
