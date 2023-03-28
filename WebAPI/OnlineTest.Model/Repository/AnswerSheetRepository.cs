using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class AnswerSheetRepository :IAnswerSheetRepository
    {
        #region fields
        private readonly OnlineTestContext _context;
        #endregion
        #region Constr
        public AnswerSheetRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods 

        public bool AddAnswerSheet(List<AnswerSheet> answerSheet)
        {
            //_context.AnswersSheet.Add(answerSheet);
            _context.AddRange(answerSheet);
            return _context.SaveChanges() > 0;            
        }

        public IEnumerable<AnswerSheet> GetTestAnswers()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
