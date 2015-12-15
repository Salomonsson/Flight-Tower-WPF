using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ControlTower
{
    public class TakeOffClass : RunWayClass
    {

        public void TakeOffConfirmitation(RunWayClass m, EventArgs e)
        {
            MessageBox.Show("Airplaine Preparing for take off");
            //System.Threading.Thread.Sleep(3000);
            MessageBox.Show("Runway is free of use");

        }
    }
}
