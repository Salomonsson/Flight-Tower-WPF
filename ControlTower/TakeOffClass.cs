using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ControlTower
{

    public class StartEventArgs : EventArgs
    {
        //private Airplane objStart = null;
     


        public string objStart { get; set; }

        public StartEventArgs(string obj)
        {
            // TODO: Complete member initialization
            objStart = obj;
            //MessageBox.Show(objStart.ToString());

            
        }

        //public string TxtStatus { get { return objStart.statusProperty; } }

        /// <summary>
        /// Set the status property of the object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e">Airplane object</param>
        //public void OnRunWay_Booked(object source, StartEventArgs e)
        //{
        //    DateTime setTime = DateTime.Now;

        //    objStart.statusProperty = EnumFlightTower.EnumStatus.TakeOff.ToString();
        //    //MessageBox.Show(objStart.statusProperty.ToString());


        //    //e.objStart.statusProperty = EnumFlightTower.EnumStatus.TakeOff.ToString();
        //    e.objStart.statusTime = setTime;

        //    //MessageBox.Show("Info: You changed the flight (" + e.objStart.FlightNumber + ") status to: " + e.objStart.statusProperty);
        //}


    }


    //public class TakeOffClass : RunWayClass
    //{

    //    //public void TakeOffConfirmitation(RunWayClass m, EventArgs e)
    //    //{
    //    //    MessageBox.Show("Airplaine Preparing for take off");
    //    //    //System.Threading.Thread.Sleep(3000);
    //    //    MessageBox.Show("Runway is free of use");

    //    //}
    //}
}
