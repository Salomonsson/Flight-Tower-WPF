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
        private Airplane objLanding = null;
        DateTime setTime = DateTime.Now;

        public LandEventArgs(Airplane obj)
        {
            objLanding = obj;

            objLanding.statusProperty = EnumFlightTower.EnumStatus.Land.ToString();

            objLanding.statusTime = setTime;
        }

        //public string TxtStatus { get { return objLanding.statusProperty; } }

        ///// <summary>
        ///// Set the status property of the object
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="e">Airplane object</param>
        //public void OnRunWay_Booked(object source, LandEventArgs e)
        //{
        //    DateTime setTime = DateTime.Now;
        //    e.objLanding.statusTime = setTime;
        //    e.objLanding.statusProperty = EnumFlightTower.EnumStatus.Land.ToString();
        //    //MessageBox.Show("Info: You changed the flight (" + e.objLanding.FlightNumber + ") status to:" + e.objLanding.statusProperty);
        //}

    }



    //public class LandClass : RunWayClass
    //{
    //    //public void Subscribe(RunWayClass m)
    //    //{
    //    //    m.Book += new RunWayClass.eventHandlerBook(Landing);
    //    //}


    //    //private void Landing(RunWayClass m, EventArgs e)
    //    //{

    //    //    MessageBox.Show("Airplane preparing for landing");
    //    //    //System.Threading.Thread.Sleep(3000);

    //    //    MessageBox.Show("Runway is free of use");

    //    //}
    //}
}
