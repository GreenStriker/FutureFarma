using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using vms.entity.StoredProcedureModel;

namespace vms.repository.dbo.StoredProcedure
{
    public interface IReportsRepository
    {
        Task<SpProfit> ProfitReport(DateTime from,DateTime to);
    }

    public class ReportsRepository : IReportsRepository
    {
        private readonly DbContext _context;

        public ReportsRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<SpProfit> ProfitReport(DateTime from,
            DateTime to)
        {
            try
            {
                return await  _context.Set<SpProfit>().FromSql("SPProfitLossReport @From={0}, @To={1}", from, to).SingleOrDefaultAsync(CancellationToken.None);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
