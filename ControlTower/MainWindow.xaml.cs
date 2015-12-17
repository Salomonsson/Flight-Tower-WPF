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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Airplane newFlight1 = new Airbus(1, "f4463f1", "SAS");
        Airplane newFlight2 = new Boeing(2, "f4463f2", "Air France");
        Airplane newFlight3 = new Boeing(3, "f4463f3", "AA");
        Airplane newFlight4 = new Airbus(4, "f4463f4", "SAS");
        //ManagerAirplanes mngrAirplanes = null;
        //ManagerAirplanes
        //ManagerAirplanes<List> mngAirplanes = new ManagerAirplanes();
        
        RadarManager mngrRadar = null;
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Flight Control Application";
            mngrRadar = new RadarManager();
            
            //ManagerAirplanes<T> mngrAiplanes = new ManagerAirplanes();
            ////Instantiate Test Values
            mngrRadar.AddAirplane(newFlight1);
            mngrRadar.AddAirplane(newFlight2);
            mngrRadar.AddAirplane(newFlight3);
            mngrRadar.AddAirplane(newFlight4);


            //Update GUI
            updateFlightRadar();
        }


        //Updates the GUI
        private void updateFlightRadar()
        {

            listFlightRadar.Items.Clear();
            foreach (var item in mngrRadar.ToStringArray())
            {
                listFlightRadar.Items.Add(item.ToString());
               
            }
        }


      

        private void btnRunway_Click(object sender, RoutedEventArgs e)
        {
            
            if (listFlightRadar.SelectedIndex >= 0)
            {
                
                    //Get selected object
                    Airplane airplaneObject = mngrRadar.GetAt(listFlightRadar.SelectedIndex);
                     
                    //Open new window, pass the object
                    FlightWindowObject newFlightWindowObj = new FlightWindowObject(airplaneObject);
                    newFlightWindowObj.ShowDialog();

                    //if (newFlightWindowObj.DialogResult == true)
                    //{
                    //    airplaneObject.FlightNumber = newFlightWindowObj.objFlightNR;

                    //    updateFlightRadar();
                    //    MessageBox.Show(airplaneObject.FlightNumber + "Hej");

                    //}
                    
            }
            updateFlightRadar();
        }

        private void PopulateGrid()
        {
            throw new NotImplementedException();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
