using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Connector.Models
{
    public class CrewInputModel
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public IList<int> AirhostessIds { get; set; }
    }
}
