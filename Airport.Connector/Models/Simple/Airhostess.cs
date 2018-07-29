using System;

namespace Airport.Connector.Models
{
  public class Airhostess
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int? CrewId { get; set; }

        public string FullName => $"{FirstName} {LastName}";
  }
}