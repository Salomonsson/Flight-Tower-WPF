using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlTower
{

    //delegate string stringChanger(string t);
    delegate void eventHandlerBookAirplane(Airplane m);
    class TestDelegateCLASS
    {
        //public event eventHandlerBook Book;
        //public EventArgs e = null;
        //public delegate void eventHandlerBook(RunWayClass m, EventArgs e);

        public static void eventStart(Airplane p)
        {
            if (p != null)
                p.statusProperty = EnumFlightTower.EnumStatus.TakeOff.ToString();
        }

        public static void eventLand(Airplane p)
        {
            if (p != null)
                p.statusProperty = EnumFlightTower.EnumStatus.Land.ToString();
        }

        public static void eventChangeRoute(Airplane p)
        {
            if (p != null)
                p.statusProperty = EnumFlightTower.EnumStatus.ChangeRoute.ToString();
        }

        //Not in use
        //public static object getNum()
        //{
        //    return num;
        //}
    }
    /// <summary>
    /// Interaction logic for FlightWindowObject.xaml
    /// </summary>
    public partial class FlightWindowObject : Window
    {

        /// <summary>
        /// Properties to handle instantiated object
        /// </summary>
        public Airplane objPlane;
        public object objName { get; set; }
        public string objFlightNR { get; set; }
        public object objAirplaneType { get; set; }
        public string objImage  { get; set; }
        public string objStatusPropert { get; set; }


        //EventHandler of the RunWay
        eventHandlerBookAirplane evHan = null;

        public FlightWindowObject(Airplane AirplaneObject)
        {
            //get the objects properties
            this.objPlane = AirplaneObject;
            this.objName = AirplaneObject.Company;
            this.objFlightNR = AirplaneObject.FlightNumber;
            this.objAirplaneType = AirplaneObject.GetAirplaneType();
            this.objImage = AirplaneObject.imgPlane();
            this.objStatusPropert = AirplaneObject.statusProperty;

            //this.objStatus = EnumFlightTower.EnumStatus.TakeOff;
            
            InitializeComponent();
            
            InitializeGUI();
        }


        public void InitializeGUI()
        {
            //Set window title
            this.Title = "FlightNumber: " + objPlane.FlightNumber;

            //Add info about object to list
            ListFlightObject.Items.Add(objName);
            ListFlightObject.Items.Add(objAirplaneType);



            //Default Image
            var uri = new Uri(@"C:\Users\Psylon\Desktop\imgMissing.jpg");
            //Set new image
            uri = new Uri(objImage.ToString());
            if (uri == null)//Not working propely
            {
                uri = new Uri(@"C:\Users\Psylon\Desktop\imgMissing.jpg");
            }
            var bitmap = new BitmapImage(uri);
            //Add image from object
            AirplaneImg.Source = bitmap;

        }




        
        private void START_Click(object sender, RoutedEventArgs e)
        {
            //Event delegation?
            evHan = new eventHandlerBookAirplane(TestDelegateCLASS.eventStart);
            evHan(objPlane);
        }

        private void LAND_Click(object sender, RoutedEventArgs e)
        {
            //Set status to land
            evHan = new eventHandlerBookAirplane(TestDelegateCLASS.eventLand);
            evHan(objPlane);
        }


        private void btnBackToFlightControl_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void changeBtnValue()
        {

            START.IsEnabled = false;
            LAND.IsEnabled = false;
            btnBackToFlightControl.IsEnabled = true;
        }
    }
}


