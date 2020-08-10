using mapledotnet.ContractModel;
using mapledotnet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mapledotnet.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public void AddContract(Contracts contract)
        {
            _contractRepository.AddContract(contract);
        }
    }
}
