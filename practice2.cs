//Programming using .NET, advanced Course
//Event-delegate example
//Farid Naisan March 2011

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BidHouseWPFCS
{
/// <summary>
/// This class contains info about a bid event.
/// When en event is fired, this class is also sent with 
/// the event notifier (delegate)
/// </summary>
/// <remarks></remarks>
public class BidEventInfo : EventArgs
{
	private string m_name;      //name of the bidder	
	private decimal m_amount;   //amount bidded

	public BidEventInfo(string name, decimal amount)
	{
		m_name = name;
		m_amount = amount;
	}

	public string Bidder 
    {
		get { return m_name; }
		set { m_name = value; }
	}

	public decimal Amount 
    {
		get { return m_amount; }
		set { m_amount = value; }
	}


}

}
