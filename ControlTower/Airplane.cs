using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public abstract class Airplane
    {
        protected int id;
        protected string flightNumber;
        protected string company;



        //konstruktor
        public Airplane()
        {

        }

        public Airplane(int id, string flightNumber, string company)
        {
            Id = id;
            FlightNumber = flightNumber;
            Company = company;


        }

        public int Id { get; set; } // generates an auto-property
        public string FlightNumber { get; set; } // generates an auto-property
        public string Company { get; set; } // generates an auto-property
        //public string statusProperty { get; set; }

        private string strProp = "default unknown";
        public string statusProperty
        {
            get { return strProp; }
            set { strProp = value; }
        }
        

        public DateTime statusTime { get; set; }



        public abstract string GetAirplaneType();
        public abstract string imgPlane();





        public override string ToString()
        {
            string strOut = String.Format("(id:{0}), FlightNumber: {1},   ", Id, FlightNumber);

            strOut = strOut.ToUpper();
            return strOut;
        }




    }
}
