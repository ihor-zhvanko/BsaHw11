using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Endpoints
{
    public interface IPlaneEndpoint : IEndpoint<Plane, Plane>
    {
    }

    public class PlaneEndpoint : Endpoint<Plane, Plane>, IPlaneEndpoint
    {
        public PlaneEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }

        public async Task<PlaneDetails> Details(int id)
        {
            return await Get<PlaneDetails>($"/{id}/details");
        }
    }
}
