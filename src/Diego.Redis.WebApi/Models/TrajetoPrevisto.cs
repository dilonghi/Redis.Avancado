using System;
using System.Collections.Generic;

namespace Diego.Redis.WebApi.Models
{
    public class TrajetoPrevisto
    {
        public Guid Id { get; set; }
        public Guid RotaId { get; set; }
        public DateTime DataCadastro { get; set; }

        public IEnumerable<TrajetoPrevistoParada> Paradas{ get; set; }
        public IEnumerable<TrajetoPrevistoTracejado> Tracejados { get; set; }
    }
}
