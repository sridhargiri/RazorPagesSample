using mapledotnet.ContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mapledotnet.Repository
{
    public interface IContractRepository
    {
        void AddContract(Contracts contract);
    }
}
