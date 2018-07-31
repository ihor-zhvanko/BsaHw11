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
    public class FlightsViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<Flight> flightes;
        public ObservableCollection<Flight> Flights
        {
            get
            {
                return flightes;
            }
            set
            {
                flightes = value;
                RaisePropertyChanged(() => Flights);
            }
        }

        private Flight selectedFlight;
        public Flight SelectedFlight
        {
            get
            {
                return selectedFlight;
            }
            set
            {
                selectedFlight = value;
                RaisePropertyChanged(() => SelectedFlight);
            }
        }

        private Flight newFlight;
        public Flight NewFlight
        {
            get { return newFlight; }
            set
            {
                newFlight = value;
                RaisePropertyChanged(() => NewFlight);
            }
        }

        public FlightsViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreateFlight = new RelayCommand(Create);
            DeleteFlight = new RelayCommand(Delete);
            UpdateFlight = new RelayCommand(Update);

            NewFlight = new Flight();
            Flights = new ObservableCollection<Flight>();

            LoadData().ConfigureAwait(false);
        }

        public ICommand CreateFlight { get; private set; }
        public ICommand DeleteFlight { get; private set; }
        public ICommand UpdateFlight { get; private set; }

        private async void Create()
        {
            var created = await airportConnector.FlightEndpoint.Create(newFlight);
            Flights.Add(created);
            newFlight = new Flight();
            RaisePropertyChanged(() => Flights);
            RaisePropertyChanged(() => NewFlight);
        }

        private async void Update()
        {
            if (selectedFlight == null)
                return;

            await airportConnector.FlightEndpoint.Update(selectedFlight.Id, selectedFlight);

            Flights = new ObservableCollection<Flight>(Flights);
            RaisePropertyChanged(() => Flights);
        }

        private async void Delete()
        {
            if (selectedFlight == null)
                return;

            await airportConnector.FlightEndpoint.Delete(selectedFlight.Id);
            Flights.Remove(selectedFlight);
            selectedFlight = null;
            RaisePropertyChanged(() => Flights);
            RaisePropertyChanged(() => SelectedFlight);
        }

        private async Task LoadData()
        {
            var all = await airportConnector.FlightEndpoint.GetAll();
            var newFlights = new ObservableCollection<Flight>(all);
            Flights = newFlights;
        }
    }
}
