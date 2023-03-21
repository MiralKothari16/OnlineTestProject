using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineTest.Model;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;


namespace OnlineTest.Services.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<User, GetUserDTO>();
            CreateMap<AddUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            #endregion

            #region Technology
            CreateMap<Technology, GetTechnologyDTO>();
            CreateMap<AddTechnologyDTO, Technology>();
            CreateMap<UpdateTechnologyDTO,Technology>();
            #endregion

            #region Test
            CreateMap<Test, GetTestDTO>();
            CreateMap<AddTestDTO, Test>();
            CreateMap<UpdateTestDTO,Test>();
            #endregion

            #region Question
            CreateMap<Questions,GetQuestionDTO>();
            CreateMap<AddQuestionDTO,Questions>();
            CreateMap<UpdateQuestionDTO,Questions>();
            #endregion

            #region Ansawer
            CreateMap<Answer,GetAnswerDTO>();
            CreateMap<AddAnswerDTO,Answer>();   
            CreateMap<UpdateAnswerDTO,Answer>();
            #endregion
        }
    }
}
