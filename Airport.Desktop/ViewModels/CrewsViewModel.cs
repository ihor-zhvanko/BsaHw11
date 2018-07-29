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
    public class CrewsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private AirportConnector airportConnector;

        public ObservableCollection<Airhostess> Crews { get; private set; }

        public CrewsViewModel()
        {
            Title = "Crews";
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            Crews = new ObservableCollection<Airhostess>();
        }

        public async Task Update()
        {
            var res = await airportConnector.AirhostessEndpoint.GetAll();
            foreach(var item in res)
            {
                Crews.Add(item);
            }
        }
    
    }
}
