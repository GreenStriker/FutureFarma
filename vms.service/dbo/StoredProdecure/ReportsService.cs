using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vms.entity.StoredProcedureModel;
using vms.repository.dbo.StoredProcedure;

namespace vms.service.dbo.StoredProdecure
{
    public interface IReportsService
    {
        Task<SpProfit> ProfitReport(DateTime from,DateTime to);



    }
    public class ReportsService : IReportsService
    {
        private readonly IReportsRepository _autocompleteRepository;

        public ReportsService(IReportsRepository autocompleteRepository)
        {
            _autocompleteRepository = autocompleteRepository;
        }

        public async Task<SpProfit> ProfitReport(DateTime from,
            DateTime to)
        {
            return await _autocompleteRepository.ProfitReport(from, to);
        }
    }
}
