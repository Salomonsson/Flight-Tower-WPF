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

        public event EventHandler<ChangeRouteArgs> EventChange_Route;
        public event EventHandler<StartEventArgs> EventStartOff;
        public event EventHandler<LandEventArgs> EventLanding;

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
            ListFlightObject.Items.Add("Flight NR:" + objPlane.FlightNumber + "     Status: " + objPlane.statusProperty);

            ///If the object got no image then set imgMissing.jpg as image of the object. 
            ///The object image is set in every class. Which is simply very logical.. ????
            if (objPlane.imgPlane() == null)
            {
                string imgMissingVariable = "img/imgMissing.jpg";
                AirplaneImg.Source = new BitmapImage(new Uri(imgMissingVariable, UriKind.Relative));
                LabelImgStatus.Content = "Img saknas";
            }
            else
            {
                ///so the image was not empty, then set the image from inherited class.
                AirplaneImg.Source = new BitmapImage(new Uri(objPlane.imgPlane().ToString(), UriKind.Relative));
                LabelImgStatus.Content =  "flightnr: " + objPlane.FlightNumber;
            }
            

            //get all routes
            ChangeRouteComboBox.Items.Clear();
            foreach (var item in (Enum.GetNames(typeof(EnumFlightTower.ChangeRoutes))))
            {
                ChangeRouteComboBox.Items.Add(item);
            }
            //comboBox1.Items.Add(new Item("Nobugz", 666));
            //ChangeRouteComboBox.Items.Add(("test", 1);
             //ChangeRouteComboBox.Items.Add(new Item("Blue", 1));

        }

        public void START_Click(object sender, RoutedEventArgs e)
        {
            //Change properties of the object
            objPlane.statusProperty = EnumFlightTower.EnumStatus.TakeOff.ToString();

            if (EventStartOff != null)   // Kolla att det finns en prenumeration
                    EventStartOff(this, new StartEventArgs(objPlane.Id.ToString()));


            //Update GUI
            InitializeGUI();
         
        }


        private void LAND_Click(object sender, RoutedEventArgs e)
        {
            //OnRunWay_Booked_Landing(objPlane);
            if (EventLanding != null)  
                EventLanding(this, new LandEventArgs(objPlane));

            //Update GUI
            InitializeGUI();
        }


        private void ChangeRouteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Change properties of the object
            EnumFlightTower.ChangeRoutes getEnum = GetEnumChangedRoute(ChangeRouteComboBox.Text);
            //setChangedDegree = changedDegree;
            objPlane.statusProperty = getEnum.ToString();



            if (EventChange_Route != null)
                EventChange_Route(this, new ChangeRouteArgs(objPlane.Id.ToString()));

            ChangeRouteComboBox.Items.Clear();
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


        public EnumFlightTower.ChangeRoutes GetEnumChangedRoute(string incomeArgument)
        {
            //set default value
            EnumFlightTower.ChangeRoutes get = EnumFlightTower.ChangeRoutes.D10;
            switch (incomeArgument)
            {
                case "D10":
                    //ChangeRouteComboBox.SelectedIndex = (int)EnumFlightTower.ChangeRoutes.no;
                    get = EnumFlightTower.ChangeRoutes.D10;
                    break;
                case "D20":
                    get = EnumFlightTower.ChangeRoutes.D20;
                    break;
                case "D60":
                    get = EnumFlightTower.ChangeRoutes.D60;
                    break;
                case "D100":
                    get = EnumFlightTower.ChangeRoutes.D100;
                    break;
                default:
                    // MessageBox.Show("Default");
                    break;
            }
            return get;
        }

    }
}

