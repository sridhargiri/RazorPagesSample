using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W1.Models;

namespace W1
{
    public class DataRepository : IDataRepository
    {
        private readonly exerciseContext _dbContext;
        public DataRepository(exerciseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<StudentData> GetAll()
        {
            var result = _dbContext.StudentData.ToList();
            return result;
        }
    }
}
