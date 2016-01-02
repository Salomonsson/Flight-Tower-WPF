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



        /// <summary>
        /// Set the status property of the object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e">Airplane object</param>
        //public void OnRunWay_Booked(object source, ChangeRouteArgs e)
        //{
        //    //e.objChangeRoute.statusTime;
        //    //MessageBox.Show(e.objChangeRoute.statusTime.ToString());
        //    DateTime r = e.objChangeRoute.statusTime;
        //    DateTime setTime = DateTime.Now;

        //    TimeSpan tid = setTime - r;
        //    System.TimeSpan diff1 = setTime.Subtract(r);
        //    e.objChangeRoute.statusTime = setTime;
                
        //    //MessageBox.Show((r.Subtract(setTime).TotalMinutes).ToString());

        //    string poke = (r.Subtract(setTime).TotalMinutes).ToString();

        //   // e.objChangeRoute.statusProperty = "You changed degree by " + e.setChangedDegree.ToString() + " (" + diff1 + " sekunder sedan)";
        //   // MessageBox.Show("Info: You changed the flight (" + e.objChangeRoute.FlightNumber + ") status to:" + e.objChangeRoute.statusProperty);
        //}
    }
}
