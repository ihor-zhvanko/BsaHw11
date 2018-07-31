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
    public class TicketsViewModel : BaseViewModel
    {
        AirportConnector airportConnector;
        INavigationService navigationService;

        ObservableCollection<Ticket> tickets;
        public ObservableCollection<Ticket> Tickets
        {
            get
            {
                return tickets;
            }
            set
            {
                tickets = value;
                RaisePropertyChanged(() => Tickets);
            }
        }

        private Ticket selectedTicket;
        public Ticket SelectedTicket
        {
            get
            {
                return selectedTicket;
            }
            set
            {
                selectedTicket = value;
                RaisePropertyChanged(() => SelectedTicket);
            }
        }

        private Ticket newTicket;
        public Ticket NewTicket
        {
            get { return newTicket; }
            set
            {
                newTicket = value;
                RaisePropertyChanged(() => NewTicket);
            }
        }

        public TicketsViewModel(INavigationService navigationService)
        {
            airportConnector = new AirportConnector("https://localhost:5001/api/");
            this.navigationService = navigationService;

            CreateTicket = new RelayCommand(Create);
            DeleteTicket = new RelayCommand(Delete);
            UpdateTicket = new RelayCommand(Update);

            NewTicket = new Ticket();
            Tickets = new ObservableCollection<Ticket>();

            LoadData().ConfigureAwait(false);
        }

        public ICommand CreateTicket { get; private set; }
        public ICommand DeleteTicket { get; private set; }
        public ICommand UpdateTicket { get; private set; }

        private async void Create()
        {
            var created = await airportConnector.TicketEndpoint.Create(newTicket);
            Tickets.Add(created);
            newTicket = new Ticket();
            RaisePropertyChanged(() => Tickets);
            RaisePropertyChanged(() => NewTicket);
        }

        private async void Update()
        {
            if (selectedTicket == null)
                return;

            await airportConnector.TicketEndpoint.Update(selectedTicket.Id, selectedTicket);

            Tickets = new ObservableCollection<Ticket>(Tickets);
            RaisePropertyChanged(() => Tickets);
        }

        private async void Delete()
        {
            if (selectedTicket == null)
                return;

            await airportConnector.TicketEndpoint.Delete(selectedTicket.Id);
            Tickets.Remove(selectedTicket);
            selectedTicket = null;
            RaisePropertyChanged(() => Tickets);
            RaisePropertyChanged(() => SelectedTicket);
        }

        private async Task LoadData()
        {
            var all = await airportConnector.TicketEndpoint.GetAll();
            var newTickets = new ObservableCollection<Ticket>(all);
            Tickets = newTickets;
        }
    }
}
