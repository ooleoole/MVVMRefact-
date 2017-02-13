using System.Collections.Generic;
namespace PointManager.Data
{
    public class Fake_DBContext
    {
        public Fake_DBContext()
        {
            GenerateFakeData();
        }

        public List<CameraPosition> CameraPositions { get; set; }

        private void GenerateFakeData()
        {
            CameraPositions = new List<CameraPosition>()
            {
                new CameraPosition() { Id = 1, PositionName =  "Alfa", cameraX = 1, cameraY = 2,  cameraZ = 0, cameraDegH = 30, cameraDegV = 31 },
                new CameraPosition() { Id = 1, PositionName =  "Beta", cameraX = 2, cameraY = 3,  cameraZ = 1, cameraDegH = 40, cameraDegV = 41 },
                new CameraPosition() { Id = 1, PositionName = "Delta", cameraX = 3, cameraY = 4,  cameraZ = 2, cameraDegH = 50, cameraDegV = 51 },
                new CameraPosition() { Id = 1, PositionName = "Gamma", cameraX = 4, cameraY = 5,  cameraZ = 3, cameraDegH = 60, cameraDegV = 61 },
            };
        }      
    }
}