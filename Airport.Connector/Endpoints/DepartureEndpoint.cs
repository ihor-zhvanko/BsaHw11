using System;
using System.Threading.Tasks;

using Airport.Connector.Models;

namespace Airport.Connector.Endpoints
{
    public interface IDepartureEndpoint : IEndpoint<Departure, Departure>
    {
    }

    public class DepartureEndpoint : Endpoint<Departure, Departure>, IDepartureEndpoint
    {
        public DepartureEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }

        public async Task<DepartureDetails> Details(int id)
        {
            return await Get<DepartureDetails>($"/{id}/details");
        }
    }
}
