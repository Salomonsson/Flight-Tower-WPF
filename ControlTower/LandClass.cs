using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ControlTower
{
    public class LandClass : RunWayClass
    {
        public void Subscribe(RunWayClass m)
        {
            m.Book += new RunWayClass.eventHandlerBook(Landing);
        }


        private void Landing(RunWayClass m, EventArgs e)
        {

            MessageBox.Show("Airplane preparing for landing");
            //System.Threading.Thread.Sleep(3000);

            MessageBox.Show("Runway is free of use");

        }
    }
}
