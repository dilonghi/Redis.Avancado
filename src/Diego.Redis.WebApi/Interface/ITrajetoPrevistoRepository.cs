using Diego.Redis.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diego.Redis.WebApi.Interface
{
    public interface ITrajetoPrevistoRepository 
    {
        Task<TrajetoPrevisto> ObterTrajetoPorId(Guid id);
        Task PopularTabela();

        string[] ObterKeys(string filtro);


        Task<TrajetoPrevisto> AdicionarListaParadas(Guid id);
        IEnumerable<TrajetoPrevistoParada> ObterListaDEParadas(Guid id);
    }
}
