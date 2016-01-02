using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ControlTower
{

    public class LandEventArgs : EventArgs
    {
        //public Airplane Landing { get; set; }
        
        public Airplane objLanding { get; set; }

        public LandEventArgs(Airplane obj)
        {
            objLanding = obj;

            objLanding.statusProperty = EnumFlightTower.EnumStatus.Land.ToString();
        }
    }
}
