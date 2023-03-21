using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class RTokenService :IRTokenService
    {
        private readonly IRTokenRepository _rtokenRepository;

        public RTokenService(IRTokenRepository rtokenRepository)
        {
            _rtokenRepository = rtokenRepository;
        }
        public bool AddToken(RToken token)
        {
            return _rtokenRepository.Add(token);
        }
        public bool ExpireToken(RToken token)
        {
            return _rtokenRepository.Expire(token);
        }
        public RToken GetToken(string refreshToken)
        {
            return _rtokenRepository.Get(refreshToken);
        }
    }
}
