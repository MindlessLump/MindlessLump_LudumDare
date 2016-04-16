using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD35
{
    class Controller
    {
        private IView window;

        public Controller (IView window)
        {
            this.window = window;
        }
    }
}
