using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Endpoints
{
    public interface IPilotEndpoint : IEndpoint<Pilot, Pilot>
    {
    }

    public class PilotEndpoint : Endpoint<Pilot, Pilot>, IPilotEndpoint
    {
        public PilotEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }
    }
}
