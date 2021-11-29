using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mettl.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Designation { get; set; }
        public double BasicPay { get; set; }
        public double Salary
        {
            get
            {
                if (IsPermEmployee)
                {
                    return 2.0 * BasicPay;
                }
                else
                {
                    return 1.5 * BasicPay;
                }
            }
        }
        public bool IsPermEmployee { get; set; }
    }
}
