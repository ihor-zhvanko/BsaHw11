using System;

namespace Airport.Connector.Models
{
  public class DepartureDetails
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public Flight Flight { get; set; }
    public PlaneDetails Plane { get; set; }
    public CrewDetails Crew { get; set; }


  }
}