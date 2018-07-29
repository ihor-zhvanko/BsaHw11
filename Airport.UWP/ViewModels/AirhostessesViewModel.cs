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

namespace Airport.UWP.ViewModels
{
    public class AirhostessesViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<Airhostess> Airhostesses;

        public AirhostessesViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreateAirhostess = new RelayCommand(Create);
            ReadAirhostess = new RelayCommand(Read);
            DeleteAirhostess = new RelayCommand(Delete);
            UpdateAirhostess = new RelayCommand(Update);

            NewAirhostess = new Airhostess();
            Airhostesses = new ObservableCollection<Airhostess>();

            LoadData();
        }

        public ICommand CreateAirhostess { get; private set; }
        public ICommand ReadAirhostess { get; private set; }
        public ICommand DeleteAirhostess { get; private set; }
        public ICommand UpdateAirhostess { get; private set; }
        
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

        private async void Create()
        {
            await airportConnector.AirhostessEndpoint.Create(newAirhostess);
            Airhostesses.Add(newAirhostess);
            newAirhostess = new Airhostess();
        }

        private async void Update()
        {
            await airportConnector.AirhostessEndpoint.Update(selectedAirhostess.Id, selectedAirhostess);
            Airhostesses.Remove(selectedAirhostess);
            Airhostesses.Add(selectedAirhostess);
            newAirhostess = new Airhostess();
        }

        private async void Delete()
        {
            await airportConnector.AirhostessEndpoint.Delete(selectedAirhostess.Id);
            Airhostesses.Remove(selectedAirhostess);
        }

        private void Read()
        {

        }

        private async void LoadData()
        {
            var all = await airportConnector.AirhostessEndpoint.GetAll().ConfigureAwait(false);
            Airhostesses.Clear();
            foreach (var airhostess in all)
            {
                Airhostesses.Add(airhostess);
            }
        }
    }
}
