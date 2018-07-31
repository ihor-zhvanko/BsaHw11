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
    public class PlaneTypesViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<PlaneType> planeTypees;
        public ObservableCollection<PlaneType> PlaneTypes
        {
            get
            {
                return planeTypees;
            }
            set
            {
                planeTypees = value;
                RaisePropertyChanged(() => PlaneTypes);
            }
        }

        private PlaneType selectedPlaneType;
        public PlaneType SelectedPlaneType
        {
            get
            {
                return selectedPlaneType;
            }
            set
            {
                selectedPlaneType = value;
                RaisePropertyChanged(() => SelectedPlaneType);
            }
        }

        private PlaneType newPlaneType;
        public PlaneType NewPlaneType
        {
            get { return newPlaneType; }
            set
            {
                newPlaneType = value;
                RaisePropertyChanged(() => NewPlaneType);
            }
        }

        public PlaneTypesViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreatePlaneType = new RelayCommand(Create);
            DeletePlaneType = new RelayCommand(Delete);
            UpdatePlaneType = new RelayCommand(Update);

            NewPlaneType = new PlaneType();
            PlaneTypes = new ObservableCollection<PlaneType>();

            LoadData().ConfigureAwait(false);
        }

        public ICommand CreatePlaneType { get; private set; }
        public ICommand DeletePlaneType { get; private set; }
        public ICommand UpdatePlaneType { get; private set; }

        private async void Create()
        {
            var created = await airportConnector.PlaneTypeEndpoint.Create(newPlaneType);
            PlaneTypes.Add(created);
            newPlaneType = new PlaneType();
            RaisePropertyChanged(() => PlaneTypes);
            RaisePropertyChanged(() => NewPlaneType);
        }

        private async void Update()
        {
            if (selectedPlaneType == null)
                return;

            await airportConnector.PlaneTypeEndpoint.Update(selectedPlaneType.Id, selectedPlaneType);

            PlaneTypes = new ObservableCollection<PlaneType>(PlaneTypes);
            RaisePropertyChanged(() => PlaneTypes);
        }

        private async void Delete()
        {
            if (selectedPlaneType == null)
                return;

            await airportConnector.PlaneTypeEndpoint.Delete(selectedPlaneType.Id);
            PlaneTypes.Remove(selectedPlaneType);
            selectedPlaneType = null;
            RaisePropertyChanged(() => PlaneTypes);
            RaisePropertyChanged(() => SelectedPlaneType);
        }

        private async Task LoadData()
        {
            var all = await airportConnector.PlaneTypeEndpoint.GetAll();
            var newPlaneTypes = new ObservableCollection<PlaneType>(all);
            PlaneTypes = newPlaneTypes;
        }
    }
}
