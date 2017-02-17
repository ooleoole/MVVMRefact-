using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace PointManager.Models
{
    public class World3DModel : ModelBase
    {
        private double _actualWorldHeight;
        private double _actuaWorldWidth;
        private string _xCameraPosition;
        private string _yCameraPosition;
        private string _zCameraPosition;
        private string _vCameraDirection;
        private string _hCameraDirection;
        private Model3DGroup _model3DGroup;
        private PerspectiveCamera _camera;

        public Model3DGroup Model3DGroup
        {
            get
            {
                return _model3DGroup;
            }
            set
            {
                if (_model3DGroup != value)
                {
                    _model3DGroup = value;
                    OnPropertyChanged("Model3DGroup");
                }
            }
        }


        public PerspectiveCamera Camera
        {
            get
            {
                return _camera;
            }
            set
            {
                if (_camera != value)
                {
                    _camera = value;
                    OnPropertyChanged("Camera");
                }
            }
        }

        public double ActualWorldHeight
        {
            get
            {
                return _actualWorldHeight;

            }
            set
            {
                if (_actualWorldHeight != value)
                {
                    _actualWorldHeight = value;
                    OnPropertyChanged("ActualWorldHeight");
                }

            }
        }

        public double ActuaWorldWidth
        {
            get { return _actuaWorldWidth; }
            set
            {
                if (_actuaWorldWidth != value)
                {
                    _actuaWorldWidth = value;
                    OnPropertyChanged("ActuaWorldWidth");
                }
            }
        }
        public string XCameraPosition
        {
            get { return _xCameraPosition; }
            set
            {
                if (_xCameraPosition != value)
                {
                    _xCameraPosition = value;
                    OnPropertyChanged("XCameraPosition");
                }
            }
        }

        public string YCameraPosition
        {
            get { return _yCameraPosition; }
            set
            {
                if (_yCameraPosition != value)
                {
                    _yCameraPosition = value;
                    OnPropertyChanged("YCameraPosition");
                }
            }
        }

        public string ZCameraPosition
        {
            get { return _zCameraPosition; }
            set
            {
                if (_zCameraPosition != value)
                {
                    _zCameraPosition = value;
                    OnPropertyChanged("ZCameraPosition");
                }
            }
        }

        public string VCameraDirection
        {
            get { return _vCameraDirection; }
            set
            {
                if (_vCameraDirection != value)
                {
                    _vCameraDirection = value;
                    OnPropertyChanged("VCameraDirection");
                }
            }
        }

        public string HCameraDirection
        {
            get
            {
                return _hCameraDirection;
            }
            set
            {
                if (_hCameraDirection != value)
                {
                    _hCameraDirection = value;
                    OnPropertyChanged("HCameraDirection");
                }
            }
        }


    }
}