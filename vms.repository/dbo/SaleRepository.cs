using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using vms.entity.models;
using vms.entity.viewModels;

namespace vms.repository.dbo
{
    public interface ISaleRepository : IRepositoryBase<Sale>
    {
        Task<IEnumerable<Sale>> GetAll();
        Task<Sale> GetById(int id);
        
    }
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        private readonly DbContext _context;
        private readonly IDataProtectionProvider _protectionProvider;
        private readonly PurposeStringConstants _purposeStringConstants;
        private IDataProtector _dataProtector;
        public SaleRepository(DbContext context, IDataProtectionProvider p_protectionProvider, PurposeStringConstants p_purposeStringConstants) : base(context)
        {
            this._context = context;
            _protectionProvider = p_protectionProvider;
            _purposeStringConstants = p_purposeStringConstants;
            _dataProtector = _protectionProvider.CreateProtector(_purposeStringConstants.UserIdQueryString);
        }
        public async Task<IEnumerable<Sale>> GetAll()
        {
            var data = await this.Query().SelectAsync();

            return data;
        }
        public async Task<Sale> GetById(int ids)
        {
            int id = ids;
            var data = await this.Query().Include("SalesDetails.Product.Munit")
                .Include("SalePayments.PaymentMethod")
                .Include(c => c.SaleContents)
                .Include(c => c.Customer)
                .Include(c => c.Branch)
                .SingleOrDefaultAsync(x => x.SalesId == id, System.Threading.CancellationToken.None);

            return data;
        }
   
    }
}
