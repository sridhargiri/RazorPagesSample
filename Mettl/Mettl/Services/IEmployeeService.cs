using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mettl.Models;

namespace Mettl.Services
{
    public interface IEmployeeService
    {
        bool Add(EmployeeModel employeeModel);
        EmployeeModel GetById(int id);
        IEnumerable<EmployeeModel> GetAll();
    }
}
