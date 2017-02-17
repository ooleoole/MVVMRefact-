using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using PointManager.Commands;
using PointManager.Data;
using PointManager.Models;
using PointManager.Views;

namespace PointManager.ViewModels
{
    public class World3DViewModel : ViewModelBase
    {
        public enum MoveMent
        {
            Negative = -1, None = 0, Positive = 1,
        }


        public Camera CameraPostition;
        private const double Steps = 1;
        public MoveMent Walk, Strafe;
        private PerspectiveCamera _newPerspectivCamera = new PerspectiveCamera();
        private System.Windows.Threading.DispatcherTimer _timer;

        private ICommand _loaded;

        public ICommand Loaded
        {
            get
            {
                return _loaded;
            }
            set
            {
                _loaded = value;
                OnPropertyChanged("Loaded");
            }
        }

        public World3DModel World3DModel { get; set; }



        public World3DViewModel()
        {
            SetScreenSize();
            InitializeCommands();
            //World3DModel.Viewport3D1 = new Viewport3D();
            CreateModel3DGroup();
        }

        private void SetScreenSize()
        {
            var maxScreenWidth = SystemParameters.PrimaryScreenWidth;
            World3DModel = new World3DModel {ActualWorldHeight = 800, ActuaWorldWidth = maxScreenWidth - 300};
        }

        private void CreateModel3DGroup()
        {
            World3DModel.Model3DGroup = new Model3DGroup();
            World3DModel.Model3DGroup.Children.Add(new AmbientLight() {Color = Color.FromRgb(128, 128, 128)});
            World3DModel.Model3DGroup.Children.Add(new DirectionalLight()
            {
                Color = Color.FromRgb(128, 128, 128),
                Direction = new Vector3D(-1.0, 0, 1.0)
            });
            World3DModel.Model3DGroup.Children.Add(new DirectionalLight()
            {
                Color = Color.FromRgb(128, 128, 128),
                Direction = new Vector3D(1.0, 0, 1.0)
            });
        }

        private void InitializeCommands()
        {
            Loaded = new SaveCameraPositionCommand(Window1_Loaded);
        }
        private void PrintCameraData()
        {

            World3DModel.XCameraPosition = (Math.Round(CameraPostition.X, 2)).ToString();
            World3DModel.YCameraPosition = (Math.Round(CameraPostition.Y, 2)).ToString();
            World3DModel.ZCameraPosition = (Math.Round(CameraPostition.Z, 2)).ToString();
            World3DModel.VCameraDirection = (Math.Round(CameraPostition.DegreeVertical, 2)).ToString();
            World3DModel.HCameraDirection = (Math.Round(CameraPostition.DegreeHorizontal, 2)).ToString();
        }

        public void KeyDownTarget(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Walk = MoveMent.Positive; break;
                case Key.Down: Walk = MoveMent.Negative; break;
                case Key.Left: Strafe = MoveMent.Negative; break;
                case Key.Right: Strafe = MoveMent.Positive; break;
                case Key.Z: CameraPostition.Y += 0.1; break;
                case Key.X: CameraPostition.Y -= 0.1; break;
            }
        }

        public void KeyUpTarget(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Walk = MoveMent.None; break;
                case Key.Down: Walk = Walk = MoveMent.None; break;
                case Key.Left: Strafe = MoveMent.None; break;
                case Key.Right: Strafe = MoveMent.None; break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Walk != MoveMent.None) CameraPostition.Move((double)Walk * Steps * 0.1);
            if (Strafe != MoveMent.None) CameraPostition.Strafe((double)Strafe * Steps * 0.1);
            _newPerspectivCamera.Position = CameraPostition.Position;
            _newPerspectivCamera.LookDirection = new Vector3D(CameraPostition.Look.X, CameraPostition.Look.Y, CameraPostition.Look.Z);
            PrintCameraData();
        }

        private void Window1_Loaded()
        {
            World3DModel.Camera = _newPerspectivCamera;
            CameraPostition = new Camera() { X = 1, Y = 0.5, Z = 0 }; //CamPos.degH = CamPos.degV =0;
            World3DModel.Camera.Position = CameraPostition.Position;
            _newPerspectivCamera.LookDirection = new Vector3D(CameraPostition.Look.X, CameraPostition.Look.Y, CameraPostition.Look.Z);
            (new MazeGenerator()).MakeMaze(World3DModel.Model3DGroup);
            _timer = new System.Windows.Threading.DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(16);
            _timer.Tick += Timer_Tick;
            this._timer.Start();
        }



        private void SetCameraAngles(Point point)
        {
            var middle = this.World3DModel.ActualWorldHeight / 2;
            // ned:  360-270.
            if (point.Y > middle)
            {
                var proc = (point.Y - middle) / middle;
                CameraPostition.DegreeVertical = 360 - 90 * proc;
            }
            // Vert: up:  0-90
            if (point.Y < middle)
            {
                var proc = point.Y / middle;
                CameraPostition.DegreeVertical = 90 - 90 * proc;
            }
            var proc2 = point.X / this.World3DModel.ActuaWorldWidth;
            CameraPostition.DegreeHorizontal = 720 - 720 * proc2;
        }



        public void MouseMoveTarget(object sender, MouseEventArgs e)
        {
            SetCameraAngles(e.GetPosition(null));
        }
    }
}
