using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion
        #region Cnstr
        public QuestionRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region methods

        public IEnumerable<Questions> GetQuestions()
        {
            return _context.Questions.ToList();
        }

        public Questions GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(x=>x.Id==id && x.Active==true);            
        }

        public int AddQuestions(Questions question)
        {
            _context.Questions.Add(question);
            if (_context.SaveChanges() > 0) { return question.Id; }
            else { return 0; }
        }

        public bool UpdateQuestions(Questions question)
        {
            _context.Entry(question).Property("QuestionName").IsModified = true;
            _context.Entry(question).Property("Que").IsModified=true;
            _context.Entry(question).Property("SortOrder").IsModified = true;
            _context.Entry(question).Property("Weightage").IsModified = true;
            return _context.SaveChanges()>0;
        }

        public IEnumerable<Questions> Paginnation(int page, int content)
        {
            return _context.Questions.Skip((page-1)*content).Take(content);
        }

        IEnumerable<Questions> IQuestionRepository.GetQuestionByTestId(int testId)
        {
            return _context.Questions.Where(x => x.TestId == testId && x.Active == true).OrderBy(q=>q.SortOrder).ToList();
        }

        //bool IQuestionRepository.IsQuestionExist(int testid, string que)
        //{
        //    var result = _context.Questions.FirstOrDefault(x => x.TestId == testid && x.Que == que & x.Active == true);
        //    if (result != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public Questions IsQuestionExist(Questions question)
        {
            var result = _context.Questions.FirstOrDefault(x => x.TestId == question.TestId && x.Que == question.Que & x.Active == true);
            return result;
        }


        #endregion
    }
}
