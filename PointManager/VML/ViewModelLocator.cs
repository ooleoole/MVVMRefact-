using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointManager.ViewModels;

namespace PointManager.VML
{
    public class ViewModelLocator
    {
        private static World3DViewModel _world3DViewModel;
        public static World3DViewModel World3DViewModel => _world3DViewModel;

        static ViewModelLocator()
        {
           _world3DViewModel = new World3DViewModel();
        }
    }
}
