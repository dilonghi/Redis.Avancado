using System;
using System.Threading.Tasks;

namespace Diego.Redis.WebApi.Interface
{
    public interface ITrajetoPrevistoRepository
    {
        Task PopularTabela();
    }
}
