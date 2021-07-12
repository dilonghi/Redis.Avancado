using Diego.Redis.WebApi.Context;
using Diego.Redis.WebApi.Interface;
using Diego.Redis.WebApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diego.Redis.WebApi.Repositories
{
    public class TrajetoPrevistoRepository : ITrajetoPrevistoRepository
    {
        protected readonly ApiDbContext Db;
        protected readonly DbSet<TrajetoPrevisto> DbSet;

        // private readonly
        public TrajetoPrevistoRepository(ApiDbContext db)
        {
            Db = db;
            DbSet = db.Set<TrajetoPrevisto>();
        }


        public async Task PopularTabela()
        {
            var trajetoId = Guid.NewGuid();

            var trajeto = new TrajetoPrevisto()
            {
                Id = trajetoId,
                DataCadastro = DateTime.Now,
                RotaId = Guid.NewGuid(),
                Tracejados = new List<TrajetoPrevistoTracejado>()
                 {
                     new TrajetoPrevistoTracejado{ Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.09916450"), Longitude=Convert.ToDecimal("-51.18355460"), Ordem=1 , Hora=new TimeSpan(01,02,38)},
                     new TrajetoPrevistoTracejado{ Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.09866950"), Longitude=Convert.ToDecimal("-51.18404450"), Ordem=2 , Hora=new TimeSpan(01,02,53)},
                     new TrajetoPrevistoTracejado{ Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.09829300"), Longitude=Convert.ToDecimal("-51.18506940"), Ordem=3 , Hora=new TimeSpan(01,03,11)},
                     new TrajetoPrevistoTracejado{ Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.09876690"), Longitude=Convert.ToDecimal("-51.18679390"), Ordem=4 , Hora=new TimeSpan(01,04,08) },
                     new TrajetoPrevistoTracejado{ Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.10036560"), Longitude=Convert.ToDecimal("-51.18738950"), Ordem=5 , Hora=new TimeSpan(01,04,26) },
                     new TrajetoPrevistoTracejado{ Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.10260090"), Longitude=Convert.ToDecimal("-51.18816840"), Ordem=6 , Hora=new TimeSpan(01,04,42) },
                          new TrajetoPrevistoTracejado{ Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.10541600"), Longitude=Convert.ToDecimal("-51.18860880"), Ordem=6 , Hora=new TimeSpan(01,04,59) }
                 },
                Paradas = new List<TrajetoPrevistoParada>()
                {
                    new TrajetoPrevistoParada { Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.09917860"), Longitude=Convert.ToDecimal("-51.18355740"), Ordem=1, Tipo=1, Hora=new TimeSpan(00,50,52)},
                    new TrajetoPrevistoParada { Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.09929770"), Longitude=Convert.ToDecimal("-51.18356200"), Ordem=2, Tipo=1, Hora=new TimeSpan(01,00,10)},
                    new TrajetoPrevistoParada { Id =Guid.NewGuid(), TrajetoPrevistoId = trajetoId, Latitude=Convert.ToDecimal("-29.17991460"), Longitude=Convert.ToDecimal("-51.15796210"), Ordem=3, Tipo=1, Hora= new TimeSpan(01,43,41)}
                }

            };

            await DbSet.AddAsync(trajeto);
            await Db.SaveChangesAsync();
            Db.ChangeTracker.Clear();

        }
    }
}
