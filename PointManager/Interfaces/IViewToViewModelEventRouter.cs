using PointManager.ViewModels;
using System.Windows;

namespace PointManager.Interfaces
{
    public interface IViewToViewModelEventRouter
    {
        void EventRouter(object sender, RoutedEventArgs e);
    }

   
}
