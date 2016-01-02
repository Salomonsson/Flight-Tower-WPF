using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControlTower
{
    public class ChangeRouteArgs : EventArgs
    {
        public string objChangeRoute { get; set; }

        public ChangeRouteArgs(string obj)
        {
            objChangeRoute = obj.ToString();
            
        }
    }
}
