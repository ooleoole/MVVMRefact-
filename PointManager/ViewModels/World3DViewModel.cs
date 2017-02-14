﻿using System;
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
        private enum MoveMent
        {
            Negative = -1, None = 0, Positive = 1,
        }
        private Camera _cameraPostition;
        private const double Steps = 1;
        private MoveMent _walk, _strafe;
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
            World3DModel = new World3DModel { ActualWorldHeight = 800, ActuaWorldWidth = 1200 };
            InitializeCommands();
            //World3DModel.Viewport3D1 = new Viewport3D();
            World3DModel.Model3DGroup = new Model3DGroup();
            World3DModel.Model3DGroup.Children.Add(new AmbientLight() { Color = Color.FromRgb(128, 128, 128) });
            World3DModel.Model3DGroup.Children.Add(new DirectionalLight() { Color = Color.FromRgb(128, 128, 128), Direction = new Vector3D(-1.0, 0, 1.0) });
            World3DModel.Model3DGroup.Children.Add(new DirectionalLight() { Color = Color.FromRgb(128, 128, 128), Direction = new Vector3D(1.0, 0, 1.0) });
        }
        private void InitializeCommands()
        {
            Loaded = new SaveCameraPositionCommand(Window1_Loaded);
        }
        private void PrintCameraData()
        {

            World3DModel.XCameraPosition = (Math.Round(_cameraPostition.X, 2)).ToString();
            World3DModel.YCameraPosition = (Math.Round(_cameraPostition.Y, 2)).ToString();
            World3DModel.ZCameraPosition = (Math.Round(_cameraPostition.Z, 2)).ToString();
            World3DModel.VCameraDirection = (Math.Round(_cameraPostition.DegreeVertical, 2)).ToString();
            World3DModel.HCameraDirection = (Math.Round(_cameraPostition.DegreeHorizontal, 2)).ToString();
        }

        //private void Window1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    switch (e.Key)
        //    {
        //        case Key.Up: _walk = MoveMent.Positive; break;
        //        case Key.Down: _walk = MoveMent.Negative; break;
        //        case Key.Left: _strafe = MoveMent.Negative; break;
        //        case Key.Right: _strafe = MoveMent.Positive; break;
        //        case Key.Z: _cameraPostition.Y += 0.1; break;
        //        case Key.X: _cameraPostition.Y -= 0.1; break;
        //    }
        //}

        //private void Window1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    switch (e.Key)
        //    {
        //        case Key.Up: _walk = MoveMent.None; break;
        //        case Key.Down: _walk = _walk = MoveMent.None; break;
        //        case Key.Left: _strafe = MoveMent.None; break;
        //        case Key.Right: _strafe = MoveMent.None; break;
        //    }
        //}

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_walk != MoveMent.None) _cameraPostition.Move((double)_walk * Steps * 0.1);
            if (_strafe != MoveMent.None) _cameraPostition.Strafe((double)_strafe * Steps * 0.1);
            _newPerspectivCamera.Position = _cameraPostition.Position;
            _newPerspectivCamera.LookDirection = new Vector3D(_cameraPostition.Look.X, _cameraPostition.Look.Y, _cameraPostition.Look.Z);
            PrintCameraData();
        }

        private void Window1_Loaded()
        {
            World3DModel.Camera = _newPerspectivCamera;
            _cameraPostition = new Camera() { X = 1, Y = 0.5, Z = 0 }; //CamPos.degH = CamPos.degV =0;
            _newPerspectivCamera.Position = _cameraPostition.Position;
            _newPerspectivCamera.LookDirection = new Vector3D(_cameraPostition.Look.X, _cameraPostition.Look.Y, _cameraPostition.Look.Z);
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
                _cameraPostition.DegreeVertical = 360 - 90 * proc;
            }
            // Vert: up:  0-90
            if (point.Y < middle)
            {
                var proc = point.Y / middle;
                _cameraPostition.DegreeVertical = 90 - 90 * proc;
            }
            var proc2 = point.X / this.World3DModel.ActuaWorldWidth;
            _cameraPostition.DegreeHorizontal = 720 - 720 * proc2;
        }



        private void Window1_MouseMove(object sender, MouseEventArgs e)
        {
            SetCameraAngles(e.GetPosition(null));
        }
    }
}
