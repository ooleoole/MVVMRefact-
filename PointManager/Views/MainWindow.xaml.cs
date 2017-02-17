using System;
using System.Windows;
using System.Windows.Input;
using PointManager.Views;

namespace PointManager
{
    public partial class MainWindow : Window
    {
        private readonly World3DView _world3DView;
        public MainWindow()
        {
            InitializeComponent();
            _world3DView = UCworld3DView;
        }

        private void RouteEventToWorld3DView(object sender, RoutedEventArgs e)
        {
            _world3DView.EventRouter(sender, e);
        }
        
    }
}