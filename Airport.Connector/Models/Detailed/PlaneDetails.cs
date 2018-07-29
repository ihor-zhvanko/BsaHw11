using System;

namespace Airport.Connector.Models
{
  public class PlaneDetails
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public TimeSpan ServiceLife { get; set; }

    public PlaneType PlaneType { get; set; }

  }
}