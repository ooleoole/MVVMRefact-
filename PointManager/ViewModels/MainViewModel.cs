using System;
using PointManager.Models;
using System.Windows.Input;
using PointManager.Commands;
namespace PointManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            System.Diagnostics.Debug.WriteLine("MainViewModel instans skapad: "+DateTime.Now);
            LoadModelCameraPosition();
            InitializeCommands();
        }

        private CameraPosition _ModelCameraPosition;
        public CameraPosition ModelCameraPosition
        {
            get { return _ModelCameraPosition; }
            set
            {
                _ModelCameraPosition = value;
                OnPropertyChanged("ModelCameraPosition"); 
            }
        }

        private void LoadModelCameraPosition()
        {
            ModelCameraPosition = new CameraPosition()
            {
                Id = 1,
                PositionName = "Origo",
                cameraX = 0.35,
                cameraY = 0,
                cameraZ = 0,
                cameraDegH = 0,
                cameraDegV = 0
            };
        }

        // För att poängtera att namnet är valfritt
        // SaveCameraPositionCommand	
        // SCPC
        private ICommand _SCPC;
        public ICommand SCPC
        {
            get { return _SCPC; }
            set { _SCPC = value; OnPropertyChanged("SCPC"); }
        }


        private void UpdateCameraPositionFunction()
        {
            ModelCameraPosition.PositionName += " * ";
        }

        private void InitializeCommands()
        {
            SCPC = new SaveCameraPositionCommand(UpdateCameraPositionFunction);
        }


    }
}