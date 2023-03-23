using AutoMapper;
using OnlineTest.Model.Interface;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTest.Model;

namespace OnlineTest.Services.Services
{
    public class TestEmailLinksService : ITestEmailLinkService
    {
        #region fields
        private readonly ITestEmailLinkRepository _testEmailLinkRepository;
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Const
        public TestEmailLinksService(ITestEmailLinkRepository testEmailLinkRepository, ITestRepository testRepository, IUserRepository userRepository, IMapper mapper)
        {
            _testEmailLinkRepository = testEmailLinkRepository;
            _testRepository = testRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public ResponseDTO AddTestEmail(AddTestEmailLinkDTO addTestEmailLink)
        {
            var response = new ResponseDTO();
            try
            {
                //var resultCrId = _userRepository.GetUserByEmail(useremail);
                //if (resultCrId == null)
                //{
                //    response.Status = 404;
                //    response.Message = "Bad Request.";
                //    response.Error = "User not found.";
                //}
                var resulttestId = _testRepository.GetTestById(addTestEmailLink.TestId);
                if (resulttestId == null)
                {
                    response.Status = 404;
                    response.Message = "Bad Request.";
                    response.Error = "Test not found.";
                }
                var resultExistlink = _testEmailLinkRepository.IsLinkExist(addTestEmailLink.TestId, addTestEmailLink.UserId);
                if (resultExistlink != null)
                {
                    response.Status = 400;
                    response.Message = "Bad request.";
                    response.Error = "Question already exists.";
                }
                if ( resulttestId != null && resultExistlink == null)
                {
                    var addQues = _testEmailLinkRepository.AddTestEmail(_mapper.Map<TestEmailLink>(addTestEmailLink));
                    if (addQues > 0)
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
        #endregion
    }
}
