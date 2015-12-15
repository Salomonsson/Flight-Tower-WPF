using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    class Airbus : Airplane
    {
        protected string ImgPath = @"C:\Users\Psylon\Desktop\airBus380.jpg";
        public Airbus()
        {

        }

        public Airbus(int id, string flightNumber, string company)
            : base(id, flightNumber, company)
        {
            //STATUS = "NOT SET";
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
            return base.ToString() + " STATUS: " + statusProperty;
        }
    }
}
