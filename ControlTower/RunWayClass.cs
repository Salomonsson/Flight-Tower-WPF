using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class RunWayClass
    {
        public event eventHandlerBook Book;
        public EventArgs e = null;
        public delegate void eventHandlerBook(RunWayClass m, EventArgs e);
        public void runwayBooked()
        {
            //System.Threading.Thread.Sleep(3000);
            if (Book != null)
            {
                Book(this, e);
            }
        }


    }



}
