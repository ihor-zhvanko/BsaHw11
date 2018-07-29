using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Endpoints
{
    public interface ITicketEndpoint : IEndpoint<Ticket, Ticket>
    {
    }

    public class TicketEndpoint : Endpoint<Ticket, Ticket>, ITicketEndpoint
    {
        public TicketEndpoint(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }

        public async Task<TicketDetails> Details(int id)
        {
            return await Get<TicketDetails>($"/{id}/details");
        }
    }
}
