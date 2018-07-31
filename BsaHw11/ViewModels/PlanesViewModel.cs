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
    public class PlanesViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<Plane> planees;
        public ObservableCollection<Plane> Planes {
            get
            {
                return planees;
            }
            set
            {
                planees = value;
                RaisePropertyChanged(() => Planes);
            }
        }

        private Plane selectedPlane;
        public Plane SelectedPlane
        {
            get
            {
                return selectedPlane;
            }
            set
            {
                selectedPlane = value;
                RaisePropertyChanged(() => SelectedPlane);
            }
        }

        private Plane newPlane;
        public Plane NewPlane
        {
            get { return newPlane; }
            set
            {
                newPlane = value;
                RaisePropertyChanged(() => NewPlane);
            }
        }

        public PlanesViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreatePlane = new RelayCommand(Create);
            DeletePlane = new RelayCommand(Delete);
            UpdatePlane = new RelayCommand(Update);

            NewPlane = new Plane();
            Planes = new ObservableCollection<Plane>();

            LoadData().ConfigureAwait(false);
        }

        public ICommand CreatePlane { get; private set; }
        public ICommand DeletePlane { get; private set; }
        public ICommand UpdatePlane { get; private set; }
         
        private async void Create()
        {
            var created = await airportConnector.PlaneEndpoint.Create(newPlane);
            Planes.Add(created);
            newPlane = new Plane();
            RaisePropertyChanged(() => Planes);
            RaisePropertyChanged(() => NewPlane);
        }

        private async void Update()
        {
            if (selectedPlane == null)
                return;

            await airportConnector.PlaneEndpoint.Update(selectedPlane.Id, selectedPlane);
            
            Planes = new ObservableCollection<Plane>(Planes);
            RaisePropertyChanged(() => Planes);
        }

        private async void Delete()
        {
            if (selectedPlane == null)
                return;
            await airportConnector.PlaneEndpoint.Delete(selectedPlane.Id);
            Planes.Remove(selectedPlane);
            selectedPlane = null;
            RaisePropertyChanged(() => Planes);
            RaisePropertyChanged(() => SelectedPlane);
        }

        private async Task LoadData()
        {
            var all = await airportConnector.PlaneEndpoint.GetAll();
            var newPlanes = new ObservableCollection<Plane>(all);
            Planes = newPlanes;
        }
    }
}
