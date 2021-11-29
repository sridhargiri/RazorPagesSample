using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mettl.Models;

namespace Mettl.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<EmployeeModel> list = new List<EmployeeModel>();
        public void Add(EmployeeModel employeeModel)
        {
            list.Add(employeeModel);
        }
        public EmployeeModel GetById(int id)
        {
            var found = list.Find(x => x.Id == id);
            if (found != null)
            {
                return found;
            }
            return null;
        }
    }
}
