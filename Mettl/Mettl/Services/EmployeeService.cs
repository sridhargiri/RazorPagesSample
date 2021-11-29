using Mettl.Models;
using Mettl.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mettl.Services

{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        private List<EmployeeModel> list = new List<EmployeeModel>();
        public bool Add(EmployeeModel employeeModel)
        {
            try
            {
                list.Add(employeeModel);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
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
        public IEnumerable<EmployeeModel> GetAll()
        {
            return list;
        }
    }
}
