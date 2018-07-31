using Airport.Connector;
using Airport.Connector.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BsaHw11.ViewModels
{
    public class AirhostessesViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<Airhostess> airhostesses;
        public ObservableCollection<Airhostess> Airhostesses {
            get
            {
                return airhostesses;
            }
            set
            {
                airhostesses = value;
                RaisePropertyChanged(() => Airhostesses);
            }
        }

        private Airhostess selectedAirhostess;
        public Airhostess SelectedAirhostess
        {
            get
            {
                return selectedAirhostess;
            }
            set
            {
                selectedAirhostess = value;
                RaisePropertyChanged(() => SelectedAirhostess);
            }
        }

        private Airhostess newAirhostess;
        public Airhostess NewAirhostess
        {
            get { return newAirhostess; }
            set
            {
                newAirhostess = value;
                RaisePropertyChanged(() => NewAirhostess);
            }
        }

        public AirhostessesViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreateAirhostess = new RelayCommand(Create);
            DeleteAirhostess = new RelayCommand(Delete);
            UpdateAirhostess = new RelayCommand(Update);

            NewAirhostess = new Airhostess();
            Airhostesses = new ObservableCollection<Airhostess>();

            LoadData().ConfigureAwait(false);
        }

        public ICommand CreateAirhostess { get; private set; }
        public ICommand DeleteAirhostess { get; private set; }
        public ICommand UpdateAirhostess { get; private set; }
         
        private async void Create()
        {
            var created = await airportConnector.AirhostessEndpoint.Create(newAirhostess);
            Airhostesses.Add(created);
            newAirhostess = new Airhostess();
            RaisePropertyChanged(() => Airhostesses);
            RaisePropertyChanged(() => NewAirhostess);
        }

        private async void Update()
        {
            if (selectedAirhostess == null)
                return;

            await airportConnector.AirhostessEndpoint.Update(selectedAirhostess.Id, selectedAirhostess);
            
            Airhostesses = new ObservableCollection<Airhostess>(Airhostesses);
            RaisePropertyChanged(() => Airhostesses);
        }

        private async void Delete()
        {
            if (selectedAirhostess == null)
                return;

            await airportConnector.AirhostessEndpoint.Delete(selectedAirhostess.Id);
            Airhostesses.Remove(selectedAirhostess);
            selectedAirhostess = null;
            RaisePropertyChanged(() => Airhostesses);
            RaisePropertyChanged(() => SelectedAirhostess);
        }

        private async Task LoadData()
        {
            var all = await airportConnector.AirhostessEndpoint.GetAll();
            var newAirhostesses = new ObservableCollection<Airhostess>(all);
            Airhostesses = newAirhostesses;
        }
    }
}
