using BsaHw11.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BsaHw11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(AirhostessesView));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;

        }

        private void AirhostessesButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(AirhostessesView));
        }

        private void PilotsButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(PilotsView));
        }

        private void DeparturesButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(DeparturesView));
        }

        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void FlightsButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(FlightsView));
        }

        private void PlanesButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(PlanesView));
        }

        private void PlaneTypesButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(PlaneTypesView));
        }

        private void TicketsButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(TicketsView));
        }
    }
}
