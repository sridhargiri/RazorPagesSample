using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W1.Models;

namespace W1
{
    public interface IDataRepository
    {
        IEnumerable<StudentData> GetAll();
    }
}
