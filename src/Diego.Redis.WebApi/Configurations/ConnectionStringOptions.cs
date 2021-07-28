using Microsoft.Extensions.Options;

namespace Diego.Redis.WebApi.Context
{
    public sealed class ConnectionStringOptions : IOptions<ConnectionStringOptions>
    {
        public string AppConfiguration { get; set; }
        public string Redis { get; set; }
        public ConnectionStringOptions Value => this;
    }

}
