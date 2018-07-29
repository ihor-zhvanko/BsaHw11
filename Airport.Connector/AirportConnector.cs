using Airport.Connector.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector
{
    public interface IAirportConnector
    {
        IAirhostessEndpoint AirhostessEndpoint { get; }
        ICrewEndpoint CrewEndpoint { get; }
        IDepartureEndpoint DepartureEndpoint { get; }
        IFlightEndpoint FlightEndpoint { get; }
        IPilotEndpoint PilotEndpoint { get; }
        IPlaneEndpoint PlaneEndpoint { get; }
        IPlaneTypeEndpoint PlaneTypeEndpoint { get; }
        ITicketEndpoint TicketEndpoint { get; }
    }

    public class AirportConnector : IAirportConnector
    {
        public AirportConnector(string baseUrl)
        {
            var baseUri = new Uri(baseUrl);

            AirhostessEndpoint = new AirhostessEndpoint(baseUri, "airhostesses/");
            CrewEndpoint = new CrewEndpoint(baseUri, "crews/");
            PlaneEndpoint = new PlaneEndpoint(baseUri, "planes/");
            PlaneTypeEndpoint = new PlaneTypeEndpoint(baseUri, "planetypes/");
            TicketEndpoint = new TicketEndpoint(baseUri, "tickets/");
            PilotEndpoint = new PilotEndpoint(baseUri, "pilots/");
            FlightEndpoint = new FlightEndpoint(baseUri, "flights/");
            DepartureEndpoint = new DepartureEndpoint(baseUri, "departures/");
        }

        public IAirhostessEndpoint AirhostessEndpoint { get; }

        public ICrewEndpoint CrewEndpoint { get; }

        public IDepartureEndpoint DepartureEndpoint { get; }

        public IFlightEndpoint FlightEndpoint { get; }

        public IPilotEndpoint PilotEndpoint { get; }

        public IPlaneEndpoint PlaneEndpoint { get; }

        public IPlaneTypeEndpoint PlaneTypeEndpoint { get; }

        public ITicketEndpoint TicketEndpoint { get; }
    }
}
