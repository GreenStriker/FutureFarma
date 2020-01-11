using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vms.entity.viewModels;
using vms.repository.dbo.StoredProcedure;
using vms.entity.StoredProcedureModel;
namespace vms.service.dbo.StoredProdecure
{
    public interface IStoreProcedureService
    {
        Task<bool> InsertCredit(vmCreditNote vm);
        Task<bool> InsertDebit(vmDebitNote vm);
        Task<List<Spstock>> StockList(int BranchID);
    }
   public class StoreProcedureService: IStoreProcedureService
    {
        private readonly IStoreProcedureRepository _repository;

        public StoreProcedureService(IStoreProcedureRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> InsertCredit(vmCreditNote vm)
        {
            return await _repository.InsertCredit(vm);
        }

        public async Task<bool> InsertDebit(vmDebitNote vm)
        {
            return await _repository.InsertDebit(vm);
        }

        public async Task<List<Spstock>> StockList(int BranchID)
        {

            return await _repository.StockList(BranchID);
        }
    }
}
