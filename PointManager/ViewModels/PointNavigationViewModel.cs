using PointManager.Data;
using PointManager.Services;
using System.Collections.ObjectModel;

namespace PointManager.ViewModels
{
    public class PointNavigationViewModel : ViewModelBase
    {
        public PointNavigationViewModel()
        {
            LoadData();
        }

        public ObservableCollection<CameraPosition> CameraPositions { get; set; }

        public ICameraPositionRepository Repo { get; set; }

        private void LoadData()
        {
            Repo = new CameraPositionRepository();
            CameraPositions = new ObservableCollection<CameraPosition>(Repo.GetCameraPositions());
        }

    }
}