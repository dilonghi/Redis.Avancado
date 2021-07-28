using System;
using System.Text.Json.Serialization;

namespace Diego.Redis.WebApi.Models
{
    public class TrajetoPrevistoParada
    {
        public Guid Id { get; set; }
        public Guid TrajetoPrevistoId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Tipo { get; set; }
        public int Ordem { get; set; }
        public TimeSpan Hora { get; set; }

        //[JsonIgnore]
        //public virtual TrajetoPrevisto TrajetoPrevisto { get; set; }

    }
}
