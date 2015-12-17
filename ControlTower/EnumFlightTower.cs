using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class EnumFlightTower
    {
        public enum EnumStatus
        {
            TakeOff,
            Land,
            ChangeRoute,
            Unknown
        }

        public enum ChangeRoutes
        {
            D10,
            D20,
            D60,
            D100,

        }
    }
}
