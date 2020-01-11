using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vms.entity.models;
using vms.entity.viewModels;

namespace vms.repository.dbo
{

    public interface IProductGruopRepository : IRepositoryBase<ProductGruop>
    {
        Task<IEnumerable<ProductGruop>> GetUsers(int p_orgId);
        Task<ProductGruop> GetUser(int id);
    }
    public class ProductGruopRepository : RepositoryBase<ProductGruop>, IProductGruopRepository
    {
        private readonly DbContext _context;
        private readonly IDataProtectionProvider _protectionProvider;
        private readonly PurposeStringConstants _purposeStringConstants;
        private IDataProtector _dataProtector;
        public ProductGruopRepository(DbContext context, IDataProtectionProvider p_protectionProvider, PurposeStringConstants p_purposeStringConstants) : base(context)
        {
            this._context = context;
            _protectionProvider = p_protectionProvider;
            _purposeStringConstants = p_purposeStringConstants;
            _dataProtector = _protectionProvider.CreateProtector(_purposeStringConstants.UserIdQueryString);
        }
        public async Task<IEnumerable<ProductGruop>> GetUsers(int p_orgId)
        {
            var users = await this.Query().SelectAsync();
          
            return users;
        }
        public async Task<ProductGruop> GetUser(int ids)
        {
            int id = ids;
            var user = await this.Query()
             
                .SingleOrDefaultAsync(x => x.GroupId == id, System.Threading.CancellationToken.None);
           

            return user;
        }
    }


     
}
