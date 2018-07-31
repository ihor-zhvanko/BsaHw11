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
    public class PilotsViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<Pilot> pilots;
        public ObservableCollection<Pilot> Pilots
        {
            get
            {
                return pilots;
            }
            set
            {
                pilots = value;
                RaisePropertyChanged(() => Pilots);
            }
        }

        private Pilot selectedPilot;
        public Pilot SelectedPilot
        {
            get
            {
                return selectedPilot;
            }
            set
            {
                selectedPilot = value;
                RaisePropertyChanged(() => SelectedPilot);
            }
        }

        private Pilot newPilot;
        public Pilot NewPilot
        {
            get { return newPilot; }
            set
            {
                newPilot = value;
                RaisePropertyChanged(() => NewPilot);
            }
        }

        public PilotsViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreatePilot = new RelayCommand(Create);
            DeletePilot = new RelayCommand(Delete);
            UpdatePilot = new RelayCommand(Update);

            NewPilot = new Pilot();
            Pilots = new ObservableCollection<Pilot>();

            LoadData().ConfigureAwait(false);
        }

        public ICommand CreatePilot { get; private set; }
        public ICommand DeletePilot { get; private set; }
        public ICommand UpdatePilot { get; private set; }

        private async void Create()
        {
            var created = await airportConnector.PilotEndpoint.Create(newPilot);
            Pilots.Add(created);
            newPilot = new Pilot();
            RaisePropertyChanged(() => Pilots);
            RaisePropertyChanged(() => NewPilot);
        }

        private async void Update()
        {
            if (selectedPilot == null)
                return;

            await airportConnector.PilotEndpoint.Update(selectedPilot.Id, selectedPilot);

            Pilots = new ObservableCollection<Pilot>(Pilots);
            RaisePropertyChanged(() => Pilots);
        }

        private async void Delete()
        {
            if (selectedPilot == null)
                return;

            await airportConnector.PilotEndpoint.Delete(selectedPilot.Id);
            Pilots.Remove(selectedPilot);
            selectedPilot = null;
            RaisePropertyChanged(() => Pilots);
            RaisePropertyChanged(() => SelectedPilot);
        }

        private async Task LoadData()
        {
            var all = await airportConnector.PilotEndpoint.GetAll();
            var newPilots = new ObservableCollection<Pilot>(all);
            Pilots = newPilots;
        }
    }
}
