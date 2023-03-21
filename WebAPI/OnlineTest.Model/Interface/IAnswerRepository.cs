﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswer();

        Answer GetAnswerById(int id);
        IEnumerable<Answer> GetAnswerByQuestionId(int questionId);
        bool  AddAnswer(Answer answer);
        bool UpdateAnswer(Answer answer);

        IEnumerable<Answer> Pagination(int page, int content);
    }
}