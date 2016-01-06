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
            objStart = obj;
            //MessageBox.Show(objStart.ToString());
        }

        //public string TxtStatus { get { return objStart.statusProperty; } }




    }
}
