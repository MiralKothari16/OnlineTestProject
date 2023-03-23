using AutoMapper;
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
        private readonly IMapper _mapper;

        public RTokenService(IRTokenRepository rtokenRepository,IMapper mapper)
        {
            _rtokenRepository = rtokenRepository;
            _mapper = mapper;
        }
        public bool AddToken(RToken token)
        {
         //   return _rtokenRepository.Add(token);
            return _rtokenRepository.Add(_mapper.Map<RToken>(token));
        }
        public bool ExpireToken(RToken token)
        {
           // return _rtokenRepository.Expire(token);
            return _rtokenRepository.Expire(_mapper.Map<RToken>(token));
        }
        public RToken GetToken(string refreshToken)
        {
            return _rtokenRepository.Get(refreshToken);
        }
    }
}
