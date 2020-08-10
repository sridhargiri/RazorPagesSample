using mapledotnet.ContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mapledotnet.Services
{
    public interface IContractService
    {
        void AddContract(Contracts contract);
    }
}
