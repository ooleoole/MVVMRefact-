using System;

namespace PointManager.Commands
{
    public class SaveCameraPositionCommand : BaseCommand
    {
        public SaveCameraPositionCommand(Action updateCameraPosition)
        {
            _executeWhenButtonIsPressed = updateCameraPosition;
        }
    }
}