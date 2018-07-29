namespace Airport.Connector.Models
{ 
  public class TicketDetails
  {
    public int Id { get; set; }
    public double Price { get; set; }
    public Flight Flight { get; set; }

  }
}