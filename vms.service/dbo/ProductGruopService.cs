using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vms.entity.models;
using vms.repository.dbo;

namespace vms.service.dbo
{

    public interface IProductGruopService : IServiceBase<ProductGruop>
    {
        Task<IEnumerable<ProductGruop>> GetUsers(int p_orgId);
        Task<ProductGruop> GetUser(int id);
    }

    public class ProductGruopService : ServiceBase<ProductGruop>, IProductGruopService
    {
        public IProductGruopRepository _repository { get; }
        public ProductGruopService(IProductGruopRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProductGruop>> GetUsers(int p_orgId)
        {
            return await _repository.GetUsers(p_orgId);
        }
        public async Task<ProductGruop> GetUser(int id)
        {
            return await _repository.GetUser(id);
        }
    }
}
