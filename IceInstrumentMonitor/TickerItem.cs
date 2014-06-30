using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceInstrumentMonitor
{
    public class TickerItem
    {
        #region Constructor
        
        public TickerItem(string name, string source, double initPrice, double currentPrice)
        {
            Name = name;
            Source = source;
            InitialPrice = initPrice;
            CurrentPrice = currentPrice;
        }
        #endregion

        #region Properties
        
        public string Name { get; private set; }
        public string Source { get; private set; }
        public double CurrentPrice { get; private set; }
        public double PriceChange 
        {
            get
            {
                return InitialPrice - CurrentPrice;
            }
        }
        public string Direction 
        {
            get
            {
                if (PriceChange < 0)
                    return "Down";
                else
                    return "Up";               
            }
        }
        public double InitialPrice { get; private set; }
        #endregion
    }
}
