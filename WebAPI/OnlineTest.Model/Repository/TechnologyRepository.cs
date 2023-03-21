using Azure.Core.Pipeline;
using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class TechnologyRepository :ITechnologyRepository
    {
        #region Field 
        private readonly OnlineTestContext _context;

        #endregion

        #region cntrl
        public TechnologyRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods

       public IEnumerable<Technology> GetTechnology()
        {
            return _context.Technology.ToList();
        }

        public Technology GetTechnologyById(int id)
        {
            return _context.Technology.FirstOrDefault(x => x.Id == id);
        }
        public Technology GetTechnologyByName(string name)
        {
            return _context.Technology.FirstOrDefault(x => x.TechName == name.Trim());
        }
        public bool AddTechnology(Technology technology)
        {
            _context.Technology.Add(technology);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateTechnology(Technology technology)
        {
            _context.Technology.Update(technology);
            return _context.SaveChanges()>0;
        }
        //public bool DeleteTechnology(int Id)
        //{
        //    var del = _context.Technology.Find(Id);
        //    if (del != null)
        //    {
        //        _context.Technology.Remove(del);
        //    }
        //        return _context.SaveChanges() > 0;
        //}
        public IEnumerable<Technology> TechPagination(int page, int content)
        {
            return _context.Technology.Skip((page-1)*content).Take(content).ToList();
        }
        //public IEnumerable<Technology> SearchTechnology(int Id,string techName, int cretedby, DateTime createdon,int modifiedbty, DateTime modifiedon)
        //{
        //    return _context.Technology.ToList();
        //}

        //IEnumerable<Technology> ITechnologyRepository.SearchTechnology(int Id, string techName, int createdby, DateTime createdon, int modifiedby, int modifiedon)
        //{
        //    // throw new NotImplementedException();
        //    return _context.Technology.ToList();
        //}

        #endregion
    }
}
