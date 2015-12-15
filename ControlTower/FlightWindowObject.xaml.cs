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

    //EventArgs
    public class LandEventArgs : EventArgs
    {
        public Airplane Landing { get; set; }
    }
    public class StartEventArgs : EventArgs
    {
        public Airplane Start { get; set; }
    }


    //Class RunWay, 
    public class RunWay
    {

        //public delegate void videoEncodedEventHandler(object source, EventArgs args);
        //public event videoEncodedEventHandler VideoEncoded;

        public event EventHandler<LandEventArgs> RunWayBookedLanding;
        public event EventHandler<StartEventArgs> RunWayBookedStartOff;

        public void runWay_Book(Airplane obj)
        {
            //MessageBox.Show("Booking runway...");

            OnRunWay_Booked_StartOff(obj);
            OnRunWay_Booked_Landing(obj);
        }


        protected virtual void OnRunWay_Booked_StartOff(Airplane obj)
        {
            //If not null, then the runway booked for start off
            if (RunWayBookedStartOff != null)
            {
                RunWayBookedStartOff(this, new StartEventArgs() { Start = obj });
            }
        }
        protected virtual void OnRunWay_Booked_Landing(Airplane obj)
        {
            //If not null, then the runway booked for landing
            if (RunWayBookedLanding != null)
            {
                RunWayBookedLanding(this, new LandEventArgs() { Landing = obj });
            }
        }


    }

    public class StartOff
    {
        /// <summary>
        /// Set the status property of the object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e">Airplane object</param>
        public void OnRunWay_Booked(object source, StartEventArgs e)
        {
            //Airplane test = GetAt(e.Start);
            e.Start.statusProperty = EnumFlightTower.EnumStatus.TakeOff.ToString();
            MessageBox.Show("Info: You changed the flight (" + e.Start.FlightNumber + ") status to: " + e.Start.statusProperty);
        }
    }

    public class Land
    {
        /// <summary>
        /// Set the status property of the object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e">Airplane object</param>
        public void OnRunWay_Booked(object source, LandEventArgs e)
        {
            e.Landing.statusProperty = EnumFlightTower.EnumStatus.Land.ToString();
            MessageBox.Show("Info: You changed the flight (" + e.Landing.FlightNumber + ") status to:" + e.Landing.statusProperty);
        }
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
        public string objImage  { get; set; }



        public FlightWindowObject(Airplane AirplaneObject)
        {

            //get the objects properties
            this.objPlane = AirplaneObject;
            this.objImage = AirplaneObject.imgPlane();

            
            InitializeComponent();
            
            //Update the GUI
            InitializeGUI();



        }


        public void InitializeGUI()
        {
            //Clear the textbox
            ListFlightObject.Items.Clear();

            //Set window title
            this.Title = "FlightNumber: " + objPlane.FlightNumber;

            //Add info about object to list
            ListFlightObject.Items.Add(objPlane.ToString());



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
            var runWay = new RunWay();//Publisher
            var runway_Start = new StartOff();//Subscriber

            
            runWay.RunWayBookedStartOff += runway_Start.OnRunWay_Booked;
            //runWay.RunWayBookedStartOff += null;


            runWay.runWay_Book(objPlane);


            //Update GUI
            InitializeGUI();
        }




        private void LAND_Click(object sender, RoutedEventArgs e)
        {

            var runWay = new RunWay();//Publisher
            var land = new Land();//Subscriber 

            //add subscription
            runWay.RunWayBookedLanding += land.OnRunWay_Booked;



            runWay.runWay_Book(objPlane);

            //Update GUI
            InitializeGUI();
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


//public class EventStart : EventArgs
//{
//    private string EventInfo;
//    private int p;
//    public EventStart(string Text)
//    {
//        EventInfo = Text;
//        MessageBox.Show("test2");
//        MessageBox.Show(EventInfo);
//        MessageBox.Show("End Test 2");
//    }

//}
//public class EventLAND : EventArgs
//{
//    private string EventInfo;
//    //RadarManager t = new RadarManager();
//    //private Airplane land;
//    public EventLAND(Airplane Text)
//    {
//        //EventInfo = Convert.ToInt32(Text.ToString());
//        //t.GetAt(Text.Id);

//        MessageBox.Show("test3-land");
//        MessageBox.Show(Text.ToString() + " test");
//        MessageBox.Show("End Test 3-land");
//    }


//}


//class MyClass
//{
//    public event EventHandler OnPropertyChanged;

//    string name = "";
//    Airplane land;
//    //string lstatus = "";

//    public string Name
//    {
//        get { return name; }
//        set
//        {
//            name = value;
//            OnPropertyChanged(this, new EventStart(name));

//        }
//    }

//    public Airplane Land
//    {
//        get { return land; }
//        set
//        {
//            land = value;
//            if (land != null)
//                OnPropertyChanged(this, new EventLAND(land));

//        }
//    }
//}

        ////EventHandler of the RunWay
        //eventHandlerBookAirplane evHan = null;

////delegate string stringChanger(string t);
//delegate void eventHandlerBookAirplane(Airplane m);
//class TestDelegateCLASS
//{
//    //public event eventHandlerBook Book;
//    //public EventArgs e = null;
//    //public delegate void eventHandlerBook(RunWayClass m, EventArgs e);

//    public static void eventStart(Airplane p)
//    {
//        if (p != null)
//            p.statusProperty = EnumFlightTower.EnumStatus.TakeOff.ToString();
//    }

//    public static void eventLand(Airplane p)
//    {
//        if (p != null)
//            p.statusProperty = EnumFlightTower.EnumStatus.Land.ToString();
//    }

//    public static void eventChangeRoute(Airplane p)
//    {
//        if (p != null)
//            p.statusProperty = EnumFlightTower.EnumStatus.ChangeRoute.ToString();
//    }

//    //public static object getNum()
//    //{
//    //    return num;
//    //}
//}




//            //stringChanger tDel;
//            //tDel1 = new stringChanger(TestDelegateCLASS.AddNum);
//            ////tDel = tDel1;
//            //tDel1(startValue);
            
//            //MessageBox.Show(TestDelegateCLASS.getNum());
            
           
//             //evHan = new eventHandlerBookAirplane(TestDelegateCLASS.AddNum);
//             //evHan(objPlane);

//            //set button values to false
//            //changeBtnValue();

//            //Book the Runway
//            runwayInstans = new RunWayClass();//Book flygbana

//            //Instance of class
//            TakeOffClass takeOffAirPlaine = new TakeOffClass();

//            //The runway is now booked. Let TakeOffClass know.
//            runwayInstans.Book += new RunWayClass.eventHandlerBook(takeOffAirPlaine.TakeOffConfirmitation);

//            //Runway is now booked
//            runwayInstans.runwayBooked();




//Method land

//            //MessageBox.Show(objPlane.FlightNumber);
//            //tDel1 = new stringChanger(TestDelegateCLASS.AddNum);
//            ////tDel = tDel1;
//            ////enum objStatus1 = EnumFlightTower.EnumStatus.Land;
//            //objStatus = "land-string";
//            //tDel1(objStatus);
            

//            //MessageBox.Show(TestDelegateCLASS.getNum());
//            //Book the runway
//            runwayInstans = new RunWayClass();//Book flygbana

            
//            LandClass Land = new LandClass();
//            //Let the landingClass know
//            Land.Subscribe(runwayInstans);

//            //Runway is now booked
//            runwayInstans.runwayBooked();