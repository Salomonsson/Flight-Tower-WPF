using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControlTower
{
    class Airbus : Airplane
    {
        //protected string ImgPath = @"C:\Users\Psylon\Desktop\airBus380.jpg";
        //protected string ImgPath = @"C:\Users\Psylon\documents\visual studio 2013\Projects\ControlTower\ControlTower\img\airBus380.jpg";
        protected string ImgPath = "img/airBus380.jpg";

        DateTime TimeNow = DateTime.Now;
        public Airbus()
        {
            
        }

        public Airbus(int id, string flightNumber, string company)
            : base(id, flightNumber, company)
        {
            statusTime = TimeNow;
        }



        public override string GetAirplaneType()
        {
            return AirplaneEnumTypes.Airplanes.Airbus.ToString();
        }

        public override string imgPlane()
        {
            return this.ImgPath;
        }

        //Override the base toString, plus add extra info
        public override string ToString()
        {
            //return base.ToString() + " Ljud:" + Sound;
            return base.ToString() + " TIME:  " + statusTime + "      STATUS: " + statusProperty;
        }
    }
}
