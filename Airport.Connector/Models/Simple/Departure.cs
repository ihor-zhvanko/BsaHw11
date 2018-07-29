using System;

namespace Airport.Connector.Models
{
  public class Departure
  {
    public int Id { get; set; }
    public int FlightId { get; set; }
    public DateTime Date { get; set; }
    public int CrewId { get; set; }
    public int PlaneId { get; set; }
  }
}