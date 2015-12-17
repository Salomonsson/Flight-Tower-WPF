using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    class EnumFlightTower
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
            deg1,
            deg20,
            no
        }
    }
}
