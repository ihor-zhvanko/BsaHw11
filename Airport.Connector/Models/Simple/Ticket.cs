namespace Airport.Connector.Models
{
  public class Ticket
  {
    public int Id { get; set; }
    public double Price { get; set; }
    public int FlightId { get; set; }
  }
}