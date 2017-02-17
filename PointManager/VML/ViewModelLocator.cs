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
        public static World3DViewModel World3DViewModel { get; }

        static ViewModelLocator()
        {
           World3DViewModel = new World3DViewModel();
        }
    }
}
