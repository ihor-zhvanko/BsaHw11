using Airport.Connector;
using Airport.Connector.Models;
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
    public class CrewsViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<CrewDetails> crews;
        public ObservableCollection<CrewDetails> Crews
        {
            get
            {
                return crews;
            }
            set
            {
                crews = value;
                RaisePropertyChanged(() => Crews);
            }
        }

        public ICommand CreateCrew { get; private set; }
        public ICommand ReadCrew { get; private set; }
        public ICommand DeleteCrew { get; private set; }
        public ICommand UpdateCrew { get; private set; }
        
        

        private CrewDetails crewDetails;
        //public CrewDetails CrewDetails
        //{
        //    get
        //    {
        //        return _ccrewDetailsrew;
        //    }
        //    set
        //    {
        //        crewDetails = value;
        //        if (CrewDetails != null)
        //        {
        //            CrewId = CrewDetails.Id;
        //        }
        //        RaisePropertyChanged(() => Crew);
        //    }
        //}

        //int _crewId = 0;
        //public int CrewId
        //{
        //    get { return _crewId; }
        //    set
        //    {
        //        _crewId = value;
        //        RaisePropertyChanged(() => CrewId);
        //    }
        //}

        //private Crew _selectedCrew;
        //public Crew SelectedCrew
        //{
        //    get { return _selectedCrew; }
        //    set
        //    {
        //        _selectedCrew = value;
        //        Crew = _selectedCrew;

        //        RaisePropertyChanged(() => SelectedCrew);
        //    }
        //}


        //public CrewsViewModel(INavigationService navigationService)
        //{
        //    airportConnector = new AirportConnector("https://localhost:5001/api/");
        //    this.navigationService = navigationService;

        //    CreateCrew = new RelayCommand(Create);
        //    ReadCrew = new RelayCommand(Read);
        //    DeleteCrew = new RelayCommand(Delete);
        //    UpdateCrew = new RelayCommand(Update);
            

        //    LoadCrews().ConfigureAwait(false);
        //    Crew = new Crew();
        //}

        //async void Create()
        //{
        //    await airportConnector.CrewEndpoint.Create(Crew);
        //    await LoadCrews().ConfigureAwait(false);
        //}

        //async void Update()
        //{
        //    await _crewService.Update(Crew);
        //    await LoadCrews().ConfigureAwait(false);
        //}

        //async void Delete()
        //{
        //    await airportConnector.CrewEndpoint.Delete(CrewDe.Id);
        //    Crew = new Crew();
        //    await LoadCrews().ConfigureAwait(false);
        //}


        //private async Task LoadData()
        //{
        //    Crews.Clear();
        //    foreach (var crew in await airportConnector.CrewEndpoint.GetAll())
        //    {
        //        Crews.Add(crew);
        //    }
        //}

    }
}
