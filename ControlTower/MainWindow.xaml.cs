﻿using System;
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

        public string status = null;

        Airplane newFlight1 = new Airbus(1, "f4463f1", "SAS");
        Airplane newFlight2 = new Boeing(2, "f4463f2", "Air France");
        Airplane newFlight3 = new Boeing(3, "f4463f3", "AA");
        Airplane newFlight4 = new Airbus(4, "f4463f4", "SAS");
        
        RadarManager mngrRadar = null;
        

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Flight Control Application";

            mngrRadar = new RadarManager();

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
            
            //listFlightRadar.Items.Clear();
            //foreach (var item in mngrRadar.ToStringArray())
            //{
            //    listFlightRadar.Items.Add(item.ToString());
            //}

            listFlightRadarControl.Items.Clear();
            foreach (var item in mngrRadar.ToStringArray())
            {
                listFlightRadarControl.Items.Add(item.ToString());
            }
        }



        private void btnRunway_Click(object sender, RoutedEventArgs e)
        {
            
            //if (listFlightRadar.SelectedIndex >= 0)
            if (listFlightRadarControl.SelectedIndex >= 0)
            {
                
                    //Get selected object
                    //Airplane airplaneObject = mngrRadar.GetAt(listFlightRadar.SelectedIndex);
                     Airplane airplaneObject = mngrRadar.GetAt(listFlightRadarControl.SelectedIndex);

                    //Open new window, pass the object
                    FlightWindowObject newFlightWindowObj = new FlightWindowObject(airplaneObject);
                    newFlightWindowObj.EventStartOff += HandlerStartOff;
                    newFlightWindowObj.EventLanding += HandlerLanding;
                    newFlightWindowObj.EventChange_Route += HandlerChangedRoute;

                    //newFlightWindowObj.ShowDialog();
                    newFlightWindowObj.Show();
            }
            else
            {
                MessageBox.Show("Du må välja ett av objekten. ");
            }
        }


        public void HandlerStartOff(object sender, StartEventArgs e)
        {
            //Update the flight by the income string
            Airplane updateFlight = mngrRadar.GetAt(Int32.Parse(e.objStart));

            //Set time of change to the object
            DateTime setTime = DateTime.Now;
            //updateFlight.statusTime = setTime;
            listFlightRadar.Items.Add(updateFlight + " ändrad tid: " + setTime.ToString());

            //mngrRadar.DeleteAt(Int32.Parse(e.objStart));
            //Update the flight Control logger
            updateFlightRadar();
        }

        public void HandlerLanding(object sender, LandEventArgs e)
        {
            //set time for change - update the income object
            DateTime setTime = DateTime.Now;
            //e.objLanding.statusTime = setTime;
            //listFlightRadar.Items.Add();
            
            listFlightRadar.Items.Add(e.objLanding + "  ändrat: " + setTime.ToString());

            //Update the flight Control logger
            updateFlightRadar();
        }

        public void HandlerChangedRoute(object sender, ChangeRouteArgs e)
        {

            DateTime setTime = DateTime.Now;
            //Airplane updateFlight = mngrRadar.GetAt(Int32.Parse(e.objChangeRoute));
            //updateFlight.statusTime = setTime;

            //MessageBox.Show(updateFlight.ToString());

            //Update the flight by the income string
            Airplane updateFlight = mngrRadar.GetAt(Int32.Parse(e.objChangeRoute));

            listFlightRadar.Items.Add(updateFlight + " Ändrad tid: " + setTime.ToString());


            //Update the flight Control logger
            updateFlightRadar();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listFlightRadarControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



    }
}
