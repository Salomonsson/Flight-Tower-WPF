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
        //public Airplane Landing { get; set; }
        private Airplane objChangeRoute = null;

        public ChangeRouteArgs(Airplane obj)
        {
            objChangeRoute = obj;
        }



        /// <summary>
        /// Set the status property of the object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e">Airplane object</param>
        public void OnRunWay_Booked(object source, ChangeRouteArgs e)
        {
            DateTime setTime = DateTime.Now;
            e.objChangeRoute.statusTime = setTime;
            e.objChangeRoute.statusProperty = EnumFlightTower.EnumStatus.ChangeRoute.ToString();
            MessageBox.Show("ROUTE IS CHANGED fOR THE FLYING OBJECT!!");
           // MessageBox.Show("Info: You changed the flight (" + e.objChangeRoute.FlightNumber + ") status to:" + e.objChangeRoute.statusProperty);
        }
    }
}
