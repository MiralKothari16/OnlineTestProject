using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class RTokenRepository:IRTokenRepository
    {
        private readonly OnlineTestContext _context;

        public RTokenRepository(OnlineTestContext context)
        {
            _context = context;
        }
        public RToken Get(string refreshToken)
        {
            return _context.RTokens.FirstOrDefault(predicate: x => x.RefreshToken == refreshToken);
        }

        public bool Add(RToken token)
        {
            _context.RTokens.Add(token);
            return _context.SaveChanges()>0;
        }
        
        public bool Expire(RToken token) {
             _context.RTokens.Update(token);
            return _context.SaveChanges()>0;
        }
    }
}
