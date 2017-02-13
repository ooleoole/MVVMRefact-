using PointManager.Data;
using System.Collections.Generic;

namespace PointManager.Services
{
    public interface ICameraPositionRepository
    {
        List<CameraPosition> GetCameraPositions();
        CameraPosition GetCameraPosition(int id);
        CameraPosition AddCameraPosition(CameraPosition cameraPosition);
        CameraPosition UpdateCameraPosition(CameraPosition cameraPosition);
        void  DeleteCameraPosition(CameraPosition cameraPosition);
    }
}