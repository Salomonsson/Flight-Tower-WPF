//Programming using .NET, advanced Course
//Event-delegate example
//Farid Naisan March 2011


//A publisher class - class firing events and notifying subscribers
//through a delegage

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BidHouseWPFCS
{
    /// <summary>
    /// Two ways to work: 
    /// 1. Using the generic, EventHandler Delegate
    /// 2. Define the delegate by yourself and an event based on the delegate. 
    /// Here we implement option 1 using EventHandler.
    /// 
    /// The publisher class doesn't need to be  GUI class.
    /// </summary>    
    /// 
    public partial class BidderIsPublisher : Window
    {
        private string myName = string.Empty;
        private string objectName = string.Empty;

        //This class could receive the bid object as product but
        //let's keep it simple
        public BidderIsPublisher(string myName, string objectName)
        {
            InitializeComponent();

            this.myName = myName;
            this.objectName = objectName;

            InitializeGUI();
        }

        public void InitializeGUI()
        {
            this.Title = myName + " -  bidding on " + objectName;
        }

        //########################################################################################
        //0. Create a class for holding info for en event (can be one each event)
        // 
        //1. Declare an event (of the generic type - the easiest way)
        public event EventHandler<BidEventInfo> NewBid;
        public event EventHandler<BidEventInfo> QuitBid;

        //2.  Determine when to raise the event. 
        //Note: The arguments here, neither the sender, nor the e is of any interest for us,
        //as these two belong to the button-click event.
        //We create a bidInfo  (correspondng to e) object and the sender is "this".
         private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            decimal newBid = ToDecimal.GetDecimal(txtAmount.Text);

            BidEventInfo bidInfo = new BidEventInfo(this.Title, newBid);
            OnNewBid(bidInfo);   //Rais event                    
        }

        //2. When to raise EndBid event
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
                if (MessageBox.Show("You'll not be able to place a bid through this session. Continue?", 
                     "Think twice", MessageBoxButton.YesNo) == MessageBoxResult.Yes)       
                {
                    BidEventInfo bidInfo = new BidEventInfo(this.Title, 0.0m);
                    OnEndBid(bidInfo);
                }
        }

       //3.  Raise Event 
        public void OnNewBid(BidEventInfo e)
        {
            if (NewBid != null)
                 NewBid(this, e);
        }

        //3.  Raise Event QuitBid
        private void OnEndBid(BidEventInfo e)
        {
            if (QuitBid != null)
                QuitBid(this, e);
        }

   

    }
}
