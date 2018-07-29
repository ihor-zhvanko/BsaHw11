using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Endpoints
{
    public interface ICrewEndpoint : IEndpoint<CrewDetails, CrewInputModel>
    {
    }

    public class CrewEndpoint : Endpoint<CrewDetails, CrewInputModel>, ICrewEndpoint
    {
        public CrewEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }
    }
}
