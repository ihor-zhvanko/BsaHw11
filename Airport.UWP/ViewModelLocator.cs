using Airport.UWP.ViewModels;
using Airport.UWP.Views;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.UWP
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(AirhostessesViewModel), typeof(AirhostessesView));
            navigationService.Configure(nameof(CrewsViewModel), typeof(CrewsView));
            navigationService.Configure(nameof(DeparturesViewModel), typeof(DeparturesView));
            navigationService.Configure(nameof(FlightsViewModel), typeof(FlightsView));
            navigationService.Configure(nameof(PilotsViewModel), typeof(PilotsView));
            navigationService.Configure(nameof(PlanesViewModel), typeof(PlanesView));
            navigationService.Configure(nameof(PlaneTypesViewModel), typeof(PlaneTypesView));
            navigationService.Configure(nameof(TicketsViewModel), typeof(TicketsView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<FlightsViewModel>();
            SimpleIoc.Default.Register<TicketsViewModel>();
            SimpleIoc.Default.Register<DeparturesViewModel>();
            SimpleIoc.Default.Register<AirhostessesViewModel>();
            SimpleIoc.Default.Register<PilotsViewModel>();
            SimpleIoc.Default.Register<CrewsViewModel>();
            SimpleIoc.Default.Register<PlanesViewModel>();
            SimpleIoc.Default.Register<PlaneTypesViewModel>();

        }

        public AirhostessesViewModel AirhostessesVMInstance => ServiceLocator.Current.GetInstance<AirhostessesViewModel>();
        public FlightsViewModel FlightsVMInstance => ServiceLocator.Current.GetInstance<FlightsViewModel>();
        public TicketsViewModel TicketsVMInstance => ServiceLocator.Current.GetInstance<TicketsViewModel>();
        public DeparturesViewModel DeparturesVMInstance => ServiceLocator.Current.GetInstance<DeparturesViewModel>();
        public PilotsViewModel PilotsVMInstance => ServiceLocator.Current.GetInstance<PilotsViewModel>();
        public CrewsViewModel CrewsVMInstance => ServiceLocator.Current.GetInstance<CrewsViewModel>();
        public PlanesViewModel PlanesVMInstance => ServiceLocator.Current.GetInstance<PlanesViewModel>();
        public PlaneTypesViewModel PlaneTypesVMInstance => ServiceLocator.Current.GetInstance<PlaneTypesViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
