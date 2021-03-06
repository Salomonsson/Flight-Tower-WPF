﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    class Boeing : Airplane
    {
        //protected string ImgPath = @"C:\Users\Psylon\Desktop\boeing.jpg";
       // protected string ImgPath = @"C:\Users\Psylon\documents\visual studio 2013\Projects\ControlTower\ControlTower\img\boeing.jpg";
        //protected string ImgPath = "img/boeinggg.jpg";
        //Image is missing
        protected string ImgPath;

        DateTime TimeNow = DateTime.Now;//Set current time
        public Boeing()
        {

        }

        public Boeing(int id, string flightNumber, string company)
            : base(id, flightNumber, company)
        {
            statusTime = TimeNow;
        }





        public override string GetAirplaneType()
        {
            return AirplaneEnumTypes.Airplanes.Boeing.ToString();
        }


        public override string imgPlane()
        {
            return this.ImgPath;
        }

        //Override the base toString, plus add extra info
        public override string ToString()
        {
            //return base.ToString() + " Ljud:" + Sound;
            //return base.ToString() + " TIME:  " + statusTime + "      STATUS: " + statusProperty;
            return base.ToString() + "Current Status: " + statusProperty;
        }
    }
}
