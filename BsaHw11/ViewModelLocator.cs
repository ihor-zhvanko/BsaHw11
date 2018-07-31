using BsaHw11.ViewModels;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace BsaHw11
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(MainPage), typeof(MainPage));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }
            else
            {
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }

            SimpleIoc.Default.Register<AirhostessesViewModel>();
            SimpleIoc.Default.Register<PilotsViewModel>();
            SimpleIoc.Default.Register<DeparturesViewModel>();
            SimpleIoc.Default.Register<FlightsViewModel>();
            SimpleIoc.Default.Register<PlanesViewModel>();
            SimpleIoc.Default.Register<PlaneTypesViewModel>();
            SimpleIoc.Default.Register<TicketsViewModel>();
        }

        public AirhostessesViewModel AirhostessesVMInstance => ServiceLocator.Current.GetInstance<AirhostessesViewModel>();
        public PilotsViewModel PilotsVMInstance => ServiceLocator.Current.GetInstance<PilotsViewModel>();
        public DeparturesViewModel DeparturesVMInstance => ServiceLocator.Current.GetInstance<DeparturesViewModel>();
        public FlightsViewModel FlightsVMInstance => ServiceLocator.Current.GetInstance<FlightsViewModel>();
        public PlanesViewModel PlanesVMInstance => ServiceLocator.Current.GetInstance<PlanesViewModel>();
        public PlaneTypesViewModel PlaneTypesVMInstance => ServiceLocator.Current.GetInstance<PlaneTypesViewModel>();
        public TicketsViewModel TicketsVMInstance => ServiceLocator.Current.GetInstance<TicketsViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
