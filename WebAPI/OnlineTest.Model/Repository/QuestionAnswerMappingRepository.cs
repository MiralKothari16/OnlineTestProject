using Microsoft.Identity.Client;
using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class QuestionAnswerMappingRepository : IQuestionAnswerMappingRepository
    {
        #region Field
        private readonly OnlineTestContext _context;

        #endregion
        #region Cnstr       
        public QuestionAnswerMappingRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods

       //public int  QuestionAnswerMappingRepository.AddQAMapping(Model.QuestionAnswerMapping questionanswerMapping)
       // {
       //     _context.QuestionAnswerMapping.Add(questionanswerMapping);
       //     return _context.SaveChanges() > 0;
       // }

        public int AddQAMapping(QuestionAnswerMapping questionAnswerMapping)
        {

            _context.QuestionAnswerMapping.Add(questionAnswerMapping);
            if( _context.SaveChanges() > 0) 
            { return questionAnswerMapping.Id; }
            else
            {
                return 0;
            }
        }

        //bool IQuestionAnswerMappingRepository.UpdateQAMapping(IQuestionAnswerMappingRepository questionAnswerMappingRepository)
        //{
        //  throw new NotImplementedException();
    //}
        //bool IQuestionAnswerMappingRepository.UpdateQAMapping(Model.QuestionAnswerMapping questionanswerMapping)
        //{
        //    _context.QuestionAnswerMapping.Update(questionanswerMapping);
        //    return _context.SaveChanges() > 0;
        //}

        //public bool IQuestionAnswerMapping.DeleteQAMapping(int Id)
        //{
        //    var del = _context.Technology.Find(Id);
        //    if (del != null)
        //    {
        //        _context.Technology.Remove(del);
        //    }
        //    return _context.SaveChanges() > 0;
        //}
        #endregion

    }
}
