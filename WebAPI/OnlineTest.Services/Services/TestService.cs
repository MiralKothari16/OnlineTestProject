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
using static System.Net.Mime.MediaTypeNames;

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
        private readonly ITestEmailLinkRepository _testEmailLinkRepository;


        private readonly IMapper _mapper;
        #endregion
        #region Cntr
        public TestService(ITestRepository testrepository, IUserRepository userRepository, ITechnologyRepository technologyRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, ITestEmailLinkRepository testEmailLinkRepository, IMapper mapper)//IQuestionAnswerMapping questionAnswerMapping)
        {
            _testrepository = testrepository;
            _userRepository = userRepository;
            _technologyRepository = technologyRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _testEmailLinkRepository = testEmailLinkRepository;
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
                    if (addTest > 0)
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

        public ResponseDTO AddTestEmailLink(int adminId, int testId, string userEmail)
        {
            var response = new ResponseDTO();
            try
            {
                //check if user is exists or not.
                var resultuserByEmail = _userRepository.GetUserByEmail(userEmail);
                if (resultuserByEmail == null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "User not found";
                    return response;
                }

                //check if test is exists or not.
                var testById = _testrepository.GetTestById(testId);
                if (testById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test not found";
                    return response;
                }
                //check if link is already created and is not expired
                var existsFlag = _testEmailLinkRepository.IsLinkExist(testId, resultuserByEmail.Id);
                if (existsFlag)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test link already exists";
                    return response;
                }

                var testLink = new TestEmailLink
                {
                    TestId = testId,
                    UserId = resultuserByEmail.Id,  
                    Token = Guid.NewGuid(),
                    AccessCount = 0,
                    ExpireOn = DateTime.UtcNow.AddDays(7),
                    Active = true,
                    CreatedBy = adminId,
                    CreatedOn = DateTime.UtcNow,
                };

                var addTest = _testEmailLinkRepository.AddTestEmailLink(testLink);
                if (addTest == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test link is not added";
                    return response;
                }
                response.Status = 201;
                response.Message = "Created";
                response.Data = addTest;
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO GetTestEmailLink(string token, string email)
        {
            var response = new ResponseDTO();
            try
            {
                var testLink = _testEmailLinkRepository.GetTestEmailLink(Guid.Parse(token));
                if (testLink == null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test link is not exists or it is expired";
                    return response;
                }

                var userById = _userRepository.GetUserById(testLink.UserId);
                if (email.ToLower() != userById.Email.ToLower())
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Email is incorrect";
                    return response;
                }
                response = GetTestById(testLink.TestId);
                if (response.Status == 200)
                {
                    testLink.AccessedOn = DateTime.UtcNow;
                    _testEmailLinkRepository.UpdateTestEmailLink(testLink);
                }
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
