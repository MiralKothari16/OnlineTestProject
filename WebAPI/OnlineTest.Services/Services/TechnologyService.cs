using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging.Abstractions;
using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Model.Repository;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OnlineTest.Services.Services
{
    public class TechnologyService : ITechnologyService
    {
        #region Fields
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Cntr
        public TechnologyService(ITechnologyRepository technologyRepository, IUserRepository userRepository,IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _userRepository = userRepository;
            _mapper = mapper;

        }
        //public UserService(UserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        #endregion
        #region Methods

        public ResponseDTO GetTechnology()
        {
            var response = new ResponseDTO();
            try
            {
                var tech =_mapper.Map<List<GetTechnologyDTO>>( _technologyRepository.GetTechnology().ToList());
                if (tech.Count>0)
                {
                    response.Status = 200;
                    response.Data = tech;
                    response.Message = "Ok";
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "No Data found.";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internl server. ";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO GetTechnologyById(int Id)
        {
            var response = new ResponseDTO();
            try
            {
                var resulttechId = _technologyRepository.GetTechnologyById(Id);
                if (resulttechId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "Technology not found.";
                    return response;
                }
                else
                {
                    var result = _mapper.Map<List<GetTechnologyDTO>>(resulttechId);
                    response.Status = 200;
                    response.Data = result;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO GetTechnologyByName(string name)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyByName = _technologyRepository.GetTechnologyByName(name);
                if (technologyByName == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }

                var result = _mapper.Map<GetTechnologyDTO>(technologyByName);

                response.Status = 200;
                response.Data = result;
                response.Message = "Ok";
            }
            catch(Exception ex) 
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO AddTechnology(AddTechnologyDTO technology)
        {
            var response = new ResponseDTO();
            try
            {
                var resultCrId = _userRepository.GetUserById(technology.CreatedBy);
                if (resultCrId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "User not found.";
                }
                var technm = _technologyRepository.GetTechnologyByName(technology.TechName);
                if (technm != null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request.";
                    response.Error = "Technology is already exist.";
                }
                if (resultCrId != null && technm == null)
                {
                    var addTechnology = _technologyRepository.AddTechnology(_mapper.Map<Technology>(technology));
                   
                    if (addTechnology>0)
                    {
                        response.Status = 204;
                        response.Message = "Technology Created.";
                    }
                    else
                    {
                        response.Status = 400;
                        response.Message = "Bad Request.";
                        response.Error = "Technology is not created.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO UpdateTechnology(UpdateTechnologyDTO technology)
        {
            var response = new ResponseDTO();
            try
            {
                var techId = _technologyRepository.GetTechnologyById(technology.Id);
                if (techId == null)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Technology not found";
                    return response;
                }
                var technm = _technologyRepository.GetTechnologyByName(technology.TechName);
                if (technm != null && techId.Id != technology.Id )
                //if(technm == null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request.";
                    response.Error = "Technology is already exist.";
                }
                if (technm != null && technm.Id == technology.Id)
                {
                    var UpdateTechnology = _technologyRepository.UpdateTechnology(_mapper.Map<Technology>(technology));
                    if (UpdateTechnology != null)
                    {
                        response.Status = 204;
                        response.Message = "Technology Updated Successfully.";
                        return response;
                    }
                    else
                    {
                        response.Status = 400;
                        response.Message = "Not Updated.";
                        response.Error = "Technology is not updated.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO TechPagination(int page, int content)
        {
            var response = new ResponseDTO();
            try
            {
                var pg =_mapper.Map<List<GetTechnologyDTO>>(_technologyRepository.TechPagination(page, content).ToList());
                if (pg.Count > 0)
                {
                    response.Status = 200;
                    response.Data = pg;
                    response.Message = "OK";
                }
                //else
                //{
                //    response.Status =404;
                //    response.Message = "No data found.";
                //    response.Error = "No content found for this page.";
                //}
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }

        #endregion
    }
}
