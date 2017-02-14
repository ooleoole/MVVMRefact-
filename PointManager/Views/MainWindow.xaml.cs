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

        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            _world3DView.Window1_KeyDown(sender, e);
        }

        public void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            _world3DView.Window1_KeyUp(sender, e);
        }
    }
}