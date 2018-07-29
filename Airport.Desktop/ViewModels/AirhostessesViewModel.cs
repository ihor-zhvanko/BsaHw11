using Airport.Connector;
using Airport.Connector.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Desktop.ViewModels
{
    public class AirhostessesViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private AirportConnector airportConnector;

        public ObservableCollection<Airhostess> Airhostesses { get; private set; }

        public AirhostessesViewModel()
        {
            Title = "Airhostesses";
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            Airhostesses = new ObservableCollection<Airhostess>();
        }

        public async Task Update()
        {
            var res = await airportConnector.AirhostessEndpoint.GetAll();
            foreach(var item in res)
            {
                Airhostesses.Add(item);
            }
        }
    
    }
}
