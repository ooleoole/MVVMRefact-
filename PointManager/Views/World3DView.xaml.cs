using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PointManager.ViewModels;
using PointManager.VML;

namespace PointManager.Views
{
    /// <summary>
    /// Interaction logic for World3DView.xaml
    /// </summary>
    public partial class World3DView : UserControl
    {
        private World3DViewModel _world3DViewModel;

        public World3DView()
        {
            InitializeComponent();


        }

        public void EventRouter(object sender, RoutedEventArgs e)
        {
            Router(sender, e);
        }

        private void Router(object sender, RoutedEventArgs e)
        {
            var eventRaiserName = e.RoutedEvent.Name;
            var viewModelType = DataContext.GetType();
            var targetMehtod = viewModelType.GetMethod(eventRaiserName+"Target");
            targetMehtod.Invoke(DataContext, new[] { sender, e });
        }
    }
}
