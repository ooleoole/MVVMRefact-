using System;
using System.Windows.Media.Media3D;
namespace PointManager
{
    public class Camera
    {
        public Point3D Position { get { return _position; } set { _position = value; } }
        public double DegreeHorizontal { get { return _degreeHorizontal; } set { _degreeHorizontal = AngleInterval(value); } }
        public double DegreeVertical { get { return _degreeVertical; } set { _degreeVertical = AngleInterval(value); } }

        public double X { get { return _position.X; } set { _position.X = value; } }
        public double Y { get { return _position.Y; } set { _position.Y = value; } }
        public double Z { get { return _position.Z; } set { _position.Z = value; } }

        public Point3D Look
        {
            get
            {
                const int dist = 3;
                double katetX1 = Math.Sin(DegreeHorizontal * oneDegreeInRadiants) * dist,
                    katetZ1 = Math.Cos(DegreeHorizontal * oneDegreeInRadiants) * dist;
                return new Point3D()
                {
                    Y = (Math.Sin(DegreeVertical * oneDegreeInRadiants) * dist),
                    Z = (Math.Cos(DegreeVertical * oneDegreeInRadiants) * katetZ1),
                    X = (Math.Cos(DegreeVertical * oneDegreeInRadiants) * katetX1)
                };
            }
        }

        public void Move(double Distance) { _position.X += Math.Sin(DegreeHorizontal * oneDegreeInRadiants) * Distance; _position.Z += Math.Cos(DegreeHorizontal * oneDegreeInRadiants) * Distance; }
        public void Strafe(double Distance)
        {
            var degreeX = Math.Sin(DegreeHorizontal * oneDegreeInRadiants) * Distance;
            var degreeZ = Math.Cos(DegreeHorizontal * oneDegreeInRadiants) * Distance;
            _position.X +=-degreeZ;
            _position.Z +=degreeX;
        }
        private const double oneDegreeInRadiants = Math.PI / 180;
        private Point3D _position;
        private double _degreeHorizontal, _degreeVertical;
        private double AngleInterval(double degrees) { if (degrees > 360) return degrees - 360; if (degrees < 0) return degrees + 360; return degrees; }
    }
}