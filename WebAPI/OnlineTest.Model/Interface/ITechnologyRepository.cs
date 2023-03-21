using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface ITechnologyRepository
    {
        IEnumerable<Technology> GetTechnology();
         bool AddTechnology(Technology technology); 
        bool UpdateTechnology(Technology technology);   
        Technology GetTechnologyById(int id);
      //  bool DeleteTechnology(int Id);

        Technology GetTechnologyByName(string name);
        IEnumerable<Technology> TechPagination(int page, int content);
        //IEnumerable<Technology> SearchTechnology(int Id,string techName, int createdby, DateTime createdon,int modifiedby, int modifiedon);
    }
}
