﻿using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Const
        public AnswerRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public IEnumerable<Answer> GetAnswer()
        {
            return _context.Answers.ToList();
        }

        public Answer GetAnswerById(int id)
        {
            return _context.Answers.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Answer> GetAnswerByQuestionId(int questionId)
        {
            var query = from quamap in _context.QuestionAnswerMapping
                        join a in _context.Answers on quamap.AnswerId equals a.Id
                        where quamap.QuestionId == questionId
                        select new Answer
                        {
                            Id = a.Id,
                            Answers = a.Answers,
                            Active = a.Active,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn
                        };
            return query.ToList();
        }
        public int AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            if (_context.SaveChanges() > 0) 
            { return answer.Id; }
            else { return 0; }
        }

        public bool UpdateAnswer(Answer answer)
        {
            _context.Entry(answer).Property("Answers").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Answer> Pagination(int page, int content)
        {
            return _context.Answers.Skip((page - 1) * content).Take(content).ToList();
        }

        bool IAnswerRepository.isAnswerExist(int testId, int quesId, string answ)
        {
            var exstans = (from ans in _context.Answers
                           join qamap in _context.QuestionAnswerMapping
                             on ans.Id equals qamap.AnswerId
                           where qamap.QuestionId == quesId && qamap.TestId == testId && ans.Answers == answ
                           select new { Id = qamap.Id }).FirstOrDefault();
            if (exstans != null)
            {
                return true;
            }
            else return false;
        }

        #endregion
    }
}
