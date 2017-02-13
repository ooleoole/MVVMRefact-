namespace PointManager
{
    public class Surface
    {
        public Surface() { }
        public Surface(double _X1, double _Z1, double _X2, double _Z2) { X1 = _X1; Z1 = _Z1; X2 = _X2; Z2 = _Z2; }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Z1 { get; set; }
        public double Z2 { get; set; }
    }
}