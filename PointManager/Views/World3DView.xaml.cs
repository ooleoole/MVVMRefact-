using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PointManager.ViewModels;

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
            _world3DViewModel = (World3DViewModel)DataContext;
        }

        //enum MoveMent
        //{
        //    Negative = -1, None = 0, Positive = 1
        //}
        //PerspectiveCamera newPerspectivCamera = new PerspectiveCamera();
        //System.Windows.Threading.DispatcherTimer timer;
       // MoveMent Walk, Strafe;
       // double Steps = 1;
        //Camera _cameraPosition;

        //private void PrintCameraData()
        //{



        //    //_world3DViewModel.World3DModel.XCameraPosition = (Math.Round(_cameraPosition.X, 2)).ToString();
        //    //_world3DViewModel.World3DModel.YCameraPosition = (Math.Round(_cameraPosition.Y, 2)).ToString();
        //    //_world3DViewModel.World3DModel.ZCameraPosition = (Math.Round(_cameraPosition.Z, 2)).ToString();
        //    //_world3DViewModel.World3DModel.VCameraDirection = (Math.Round(_cameraPosition.DegreeVertical, 2)).ToString();
        //    //_world3DViewModel.World3DModel.HCameraDirection = (Math.Round(_cameraPosition.DegreeHorizontal, 2)).ToString();
        //}

        public void Window1_KeyDown(object sender, KeyEventArgs e)
        {
            _world3DViewModel = (World3DViewModel)DataContext;
            switch (e.Key)
            {
                case Key.Up: _world3DViewModel.Walk = World3DViewModel.MoveMent.Positive; break;
                case Key.Down: _world3DViewModel.Walk = World3DViewModel.MoveMent.Negative; break;
                case Key.Left: _world3DViewModel.Strafe = World3DViewModel.MoveMent.Negative; break;
                case Key.Right: _world3DViewModel.Strafe = World3DViewModel.MoveMent.Positive; break;
                case Key.Z: _world3DViewModel.CameraPostition.Y += 0.1; break;
                case Key.X: _world3DViewModel.CameraPostition.Y -= 0.1; break;
            }
        }

        public void Window1_KeyUp(object sender, KeyEventArgs e)
        {
            _world3DViewModel = (World3DViewModel)DataContext;
            switch (e.Key)
            {
                case Key.Up: _world3DViewModel.Walk = World3DViewModel.MoveMent.None; break;
                case Key.Down: _world3DViewModel.Walk = World3DViewModel.MoveMent.None; break;
                case Key.Left: _world3DViewModel.Strafe = World3DViewModel.MoveMent.None; break;
                case Key.Right: _world3DViewModel.Strafe = World3DViewModel.MoveMent.None; break;
            }
        }

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    _world3DViewModel = (World3DViewModel) DataContext;
        //    if (_world3DViewModel.Walk != World3DViewModel.MoveMent.None) _cameraPosition.Move((double)_world3DViewModel.Walk * Steps * 0.1);
        //    //if (Walk != MoveMent.None) _world3DViewModel.CameraPostition.Move((double)Walk * Steps * 0.1);
        //    if (_world3DViewModel.Strafe != World3DViewModel.MoveMent.None) _cameraPosition.Strafe((double)_world3DViewModel.Strafe * Steps * 0.1);
        //    //if (Strafe != MoveMent.None) _world3DViewModel.CameraPostition.Strafe((double)Strafe * Steps * 0.1);
        //    newPerspectivCamera.Position = _cameraPosition.Position;
        //    newPerspectivCamera.LookDirection = new Vector3D(_cameraPosition.Look.X, _cameraPosition.Look.Y, _cameraPosition.Look.Z);
        //    PrintCameraData();
        //}

        //private void Window1_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //Viewport3D1.Camera = newPerspectivCamera;
        //    //_cameraPosition = new Camera() { X = 1, Y = 0.5, Z = 0 }; //CamPos.degH = CamPos.degV =0;
        //    //newPerspectivCamera.Position = _cameraPosition.Position;
        //    //newPerspectivCamera.LookDirection = new Vector3D(_cameraPosition.Look.X, _cameraPosition.Look.Y, _cameraPosition.Look.Z);
        //    //(new MazeGenerator()).MakeMaze(m3Dg);
        //    //timer = new System.Windows.Threading.DispatcherTimer();
        //    //timer.Interval = TimeSpan.FromMilliseconds(16);
        //    //timer.Tick += new EventHandler(Timer_Tick);
        //    //this.timer.Start();
        //}

        private void SetCameraAngles(Point point)
        {
            _world3DViewModel = (World3DViewModel)DataContext;
            var middle = this.ActualHeight / 2;
            // ned:  360-270.
            if (point.Y > middle)
            {
                var proc = (point.Y - middle) / middle;
               _world3DViewModel.CameraPostition.DegreeVertical = 360 - 90 * proc;
            }
            // Vert: up:  0-90
            if (point.Y < middle)
            {
                var proc = point.Y / middle;
                _world3DViewModel.CameraPostition.DegreeVertical = 90 - 90 * proc;
            }
            var proc2 = point.X / this.ActualWidth;
            _world3DViewModel.CameraPostition.DegreeHorizontal = 720 - 720 * proc2;
        }

        private void Window1_MouseMove(object sender, MouseEventArgs e)
        {
            SetCameraAngles(e.GetPosition(null));

        }
    }
}
