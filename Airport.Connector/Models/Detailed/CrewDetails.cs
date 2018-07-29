using System;
using System.Linq;
using System.Collections.Generic;

namespace Airport.Connector.Models
{
  public class CrewDetails
  {
    public int Id { get; set; }
    public Pilot Pilot { get; set; }
    public IList<Airhostess> Airhostesses { get; set; }
  }
}