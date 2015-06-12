using System;
using System.Collections.Generic;
using System.Text;

namespace BusIndia_Universal.Models
{
   public class PassengerInfoDetails
    {
       private List<string> _passengerName = new List<string>();
       public List<string> passengerName
       {
           get { return _passengerName; }
           set
           {
               _passengerName = value;
               OnPropertyChanged("passengerName");
           }
       }
       private List<string> _passengerAge= new List<string>();
       public List<string> passengerAge
       {
           get { return _passengerAge; }
           set
           {
               _passengerAge = value;
               OnPropertyChanged("passengerAge");
           }
       }

       private List<string> _passengerGender = new List<string>();
       public List<string> passengerGender
       {
           get { return _passengerGender; }
           set
           {
               _passengerGender = value;
               OnPropertyChanged("passengerGender");
           }
       }

       private void OnPropertyChanged(string p)
       {
           throw new NotImplementedException();
       }
    }
}
