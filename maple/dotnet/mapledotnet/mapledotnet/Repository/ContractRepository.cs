using mapledotnet.ContractModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mapledotnet.Repository
{
    public class ContractRepository : IContractRepository
    {
        public void AddContract(Contracts contract)
        {
            using (ContractDataContext context = new ContractDataContext())
            {
                context.Database.ExecuteSqlRaw("sp_createcontract @p0, @p1,@p2,@p3,@p4,@p5",  new object[] { contract.CustomerName,
                    contract.CustomerAddress,contract.CustomerGender, contract.CustomerCountry,contract.CustomerDob });
            }   
        }
    }
}
