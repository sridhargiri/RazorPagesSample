using Mettl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mettl.Repository
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeModel employeeModel);
        EmployeeModel GetById(int id);
    }
}
