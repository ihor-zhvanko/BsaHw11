using System;

namespace Airport.Connector.Models
{
  public class Plane
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public TimeSpan ServiceLife { get; set; }
    public int PlaneTypeId { get; set; }

  }
}