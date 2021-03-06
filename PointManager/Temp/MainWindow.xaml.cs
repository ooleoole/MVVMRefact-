﻿//using System;
//using System.Windows;
//using System.Windows.Media.Media3D;
//using System.Windows.Input;

//namespace PointManager
//{
//    public partial class World3DView : Window
//    {
//        public World3DView() { InitializeComponent(); }

//        enum MoveMent { Negative = -1, None = 0, Positive = 1 }
//        System.Windows.Media.Media3D.PerspectiveCamera newPerspectivCamera = new PerspectiveCamera();
//        System.Windows.Threading.DispatcherTimer timer;
//        MoveMent Walk, Strafe;
//        double Steps = 1;
//        Camera cameraPosition;

//        private void PrintCameraData()
//        {
//            XtextBox.Text = (Math.Round(cameraPosition.X, 2)).ToString();
//            YtextBox.Text = (Math.Round(cameraPosition.Y, 2)).ToString();
//            ZtextBox.Text = (Math.Round(cameraPosition.Z, 2)).ToString();
//            VtextBox.Text = (Math.Round(cameraPosition.DegreeVertical, 2)).ToString();
//            HtextBox.Text = (Math.Round(cameraPosition.DegreeHorizontal, 2)).ToString();
//        }

//        private void Window1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
//        {
//            switch (e.Key)
//            {
//                case Key.Up: Walk = MoveMent.Positive; break;
//                case Key.Down: Walk = MoveMent.Negative; break;
//                case Key.Left: Strafe = MoveMent.Negative; break;
//                case Key.Right: Strafe = MoveMent.Positive; break;
//                case Key.Z: cameraPosition.Y += 0.1; break;
//                case Key.X: cameraPosition.Y -= 0.1; break;
//            }
//        }

//        private void Window1_KeyUp(object sender, KeyEventArgs e)
//        {
//            switch (e.Key)
//            {
//                case Key.Up: Walk = MoveMent.None; break;
//                case Key.Down: Walk = Walk = MoveMent.None; break;
//                case Key.Left: Strafe = MoveMent.None; break;
//                case Key.Right: Strafe = MoveMent.None; break;
//            }
//        }

//        private void Timer_Tick(object sender, EventArgs e)
//        {
//            if (Walk != MoveMent.None) cameraPosition.Move((double)Walk * Steps * 0.1);
//            if (Strafe != MoveMent.None) cameraPosition.Strafe((double)Strafe * Steps * 0.1);
//            newPerspectivCamera.Position = cameraPosition.Position;
//            newPerspectivCamera.LookDirection = new Vector3D(cameraPosition.Look.X, cameraPosition.Look.Y, cameraPosition.Look.Z);
//            PrintCameraData();
//        }

//        private void Window1_Loaded(object sender, System.Windows.RoutedEventArgs e)
//        {
//            Viewport3D1.Camera = newPerspectivCamera;
//            cameraPosition = new Camera() { X = 1, Y = 0.5, Z = 0 }; //CamPos.degH = CamPos.degV =0;
//            newPerspectivCamera.Position = cameraPosition.Position;
//            newPerspectivCamera.LookDirection = new Vector3D(cameraPosition.Look.X, cameraPosition.Look.Y, cameraPosition.Look.Z);
//            (new MazeGenerator()).MakeMaze(m3Dg);
//            timer = new System.Windows.Threading.DispatcherTimer();
//            timer.Interval = TimeSpan.FromMilliseconds(16);
//            timer.Tick += new EventHandler(Timer_Tick);
//            this.timer.Start();
//        }

//        private void SetCameraAngles(Point point)
//        {
//            var middle = this.ActualHeight / 2;
//            // ned:  360-270.
//            if (point.Y > middle)
//            {
//                var proc = (point.Y - middle) / middle;
//                cameraPosition.DegreeVertical = 360 - 90 * proc;
//            }
//            // Vert: up:  0-90
//            if (point.Y < middle)
//            {
//                var proc = point.Y / middle;
//                cameraPosition.DegreeVertical = 90 - 90 * proc;
//            }
//            var proc2 = point.X / this.ActualWidth;
//            cameraPosition.DegreeHorizontal = 720 - 720 * proc2;
//        }

//        private void Window1_MouseMove(object sender, MouseEventArgs e) { SetCameraAngles(e.GetPosition(null)); }
//    }
//}