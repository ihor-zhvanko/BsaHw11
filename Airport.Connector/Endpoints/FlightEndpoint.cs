using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Endpoints
{
    public interface IFlightEndpoint : IEndpoint<Flight, Flight>
    {
    }

    public class FlightEndpoint : Endpoint<Flight, Flight>, IFlightEndpoint
    {
        public FlightEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }
    }
}
