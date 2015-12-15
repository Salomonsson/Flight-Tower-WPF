using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class RadarManager : ManagerAirplanes<Airplane> 
    {


        private int setID = 0;

        //Konstruktor - skapa objekten som ingår som variabler 
        /// <summary>
        /// Default constructor - create the Animal list
        /// </summary>
        public RadarManager()
        {

        }

        /// <summary>
        /// Add the animal object to listmanagaer. And use listmanagars full potential
        /// </summary>
        /// <param name="an">type of object</param>
        public void AddAirplane(Airplane an)
        {
            an.Id = setID++;
            this.Add(an);
        }

        //public void AddNewAirplane(FlightWindowObject an)
        //{
        //    an.Id = setID++;
        //    this.Add(an);
        //}
    }
}
