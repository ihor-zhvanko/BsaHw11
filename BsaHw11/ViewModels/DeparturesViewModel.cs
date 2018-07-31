using Airport.Connector;
using Airport.Connector.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BsaHw11.ViewModels
{
    public class DeparturesViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<Departure> departurees;
        public ObservableCollection<Departure> Departures
        {
            get
            {
                return departurees;
            }
            set
            {
                departurees = value;
                RaisePropertyChanged(() => Departures);
            }
        }

        private Departure selectedDeparture;
        public Departure SelectedDeparture
        {
            get
            {
                return selectedDeparture;
            }
            set
            {
                selectedDeparture = value;
                RaisePropertyChanged(() => SelectedDeparture);
            }
        }

        private Departure newDeparture;
        public Departure NewDeparture
        {
            get { return newDeparture; }
            set
            {
                newDeparture = value;
                RaisePropertyChanged(() => NewDeparture);
            }
        }

        public DeparturesViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreateDeparture = new RelayCommand(Create);
            DeleteDeparture = new RelayCommand(Delete);
            UpdateDeparture = new RelayCommand(Update);

            NewDeparture = new Departure();
            Departures = new ObservableCollection<Departure>();

            LoadData().ConfigureAwait(false);
        }

        public ICommand CreateDeparture { get; private set; }
        public ICommand DeleteDeparture { get; private set; }
        public ICommand UpdateDeparture { get; private set; }

        private async void Create()
        {
            var created = await airportConnector.DepartureEndpoint.Create(newDeparture);
            Departures.Add(created);
            newDeparture = new Departure();
            RaisePropertyChanged(() => Departures);
            RaisePropertyChanged(() => NewDeparture);
        }

        private async void Update()
        {
            if (selectedDeparture == null)
                return;
            await airportConnector.DepartureEndpoint.Update(selectedDeparture.Id, selectedDeparture);

            Departures = new ObservableCollection<Departure>(Departures);
            RaisePropertyChanged(() => Departures);
        }

        private async void Delete()
        {
            if (selectedDeparture == null)
                return;

            await airportConnector.DepartureEndpoint.Delete(selectedDeparture.Id);
            Departures.Remove(selectedDeparture);
            selectedDeparture = null;
            RaisePropertyChanged(() => Departures);
            RaisePropertyChanged(() => SelectedDeparture);
        }

        private async Task LoadData()
        {
            var all = await airportConnector.DepartureEndpoint.GetAll();
            var newDepartures = new ObservableCollection<Departure>(all);
            Departures = newDepartures;
        }
    }
}
