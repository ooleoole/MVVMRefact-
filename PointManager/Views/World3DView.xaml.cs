using System.Windows;
using System.Windows.Controls;
using PointManager.Interfaces;

namespace PointManager.Views
{
    /// <summary>
    /// Interaction logic for World3DView.xaml
    /// </summary>
    public partial class World3DView : UserControl, IViewToViewModelEventRouter
    {
        public World3DView()
        {
            InitializeComponent();
        }

        public void EventRouter(object sender, RoutedEventArgs e)
        {
            var eventRaiserName = e.RoutedEvent.Name;
            var viewModelType = DataContext.GetType();
            var targetMehtod = viewModelType.GetMethod(eventRaiserName + "Target");
            var targetViewModel = DataContext;
            targetMehtod.Invoke(targetViewModel, new[] { sender, e });
        }
    }
}
