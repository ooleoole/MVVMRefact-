
namespace PointManager.Models
{
    public class CameraPosition : ModelBase
    {
        public int Id { get; set; }
        private string _PositionName;
        public string PositionName
        {
            get
            {
                return _PositionName;
            }
            set
            {
                _PositionName = value;
                OnPropertyChanged("PositionName");
            }
        }

        private double _cameraX;
        public double cameraX { get { return _cameraX; }
            set
            {
                _cameraX = value;
                OnPropertyChanged("cameraX");
            }
        }


        private double _cameraY;
        public double cameraY { get { return _cameraY; }
            set
            {
                _cameraY = value;
                OnPropertyChanged("cameraY");
            }
        }


        private double _cameraZ;
        public double cameraZ { get { return _cameraZ; }
            set
            {
                _cameraZ = value;
                OnPropertyChanged("cameraZ");
            }
        }


        private double _cameraDegH;
        public double cameraDegH { get { return _cameraDegH; }
            set
            {
                _cameraDegH = value;
                OnPropertyChanged("cameraDegH");
            }
        }


        private double _cameraDegV;
        public double cameraDegV { get { return _cameraDegV; }
            set
            {
                _cameraDegV = value;
                OnPropertyChanged("cameraDegV");
            }
        }
    }
}
