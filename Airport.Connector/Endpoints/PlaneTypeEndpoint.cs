using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Endpoints
{
    public interface IPlaneTypeEndpoint : IEndpoint<PlaneType, PlaneType>
    {
    }

    public class PlaneTypeEndpoint : Endpoint<PlaneType, PlaneType>, IPlaneTypeEndpoint
    {
        public PlaneTypeEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }
    }
}
