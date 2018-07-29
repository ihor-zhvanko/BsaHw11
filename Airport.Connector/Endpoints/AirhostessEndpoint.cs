using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Endpoints
{
    public interface IAirhostessEndpoint : IEndpoint<Airhostess, Airhostess>
    {
    }

    public class AirhostessEndpoint : Endpoint<Airhostess, Airhostess>, IAirhostessEndpoint
    {
        public AirhostessEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }
    }
}
