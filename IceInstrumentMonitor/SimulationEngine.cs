using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceInstrumentMonitor
{
    public partial class SimulationEngine : Form
    {
        #region Private Variables
        private Dictionary<string, List<TickerItem>> _tickerInfos;
        private List<string> _sourceName;
        private delegate void UpdateTickerInfoDelegate();
        #endregion
        
        #region Property
        public bool IsRunning { get; private set; }
        public Dictionary<string, List<TickerItem>> TickerInfos 
        {
            get 
            {
                if (_tickerInfos == null)
                {
                    _tickerInfos = new Dictionary<string, List<TickerItem>>();
                }
                return _tickerInfos;
            } 
        }
        public List<string> SourceNames
        {
            get
            {
                if (_sourceName == null)
                {
                    _sourceName = new List<string>();
                }
                return _sourceName;
            }
        }
        #endregion 

        #region Constructor
        public SimulationEngine()
        {
            InitializeComponent();
            StartEngine();
            //btnStop.Enabled = false;
        }
        #endregion

        #region Event Handlers
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartEngine();
        }
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTickerId.Text))
            {
                if (listboxTickerInfo.Items.Contains(txtTickerId.Text.ToUpper()))
                {
                    lblStatus.Text = "Ticker already exist";
                    return;
                }
                listboxTickerInfo.Items.Add(txtTickerId.Text.ToUpper());
            }
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTickerId.Text))
            {
                if (!listboxTickerInfo.Items.Contains(txtTickerId.Text.ToUpper()))
                {
                    lblStatus.Text = "Ticker does not exist";
                    return;
                }
                listboxTickerInfo.Items.Remove(txtTickerId.Text.ToUpper());
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopService();
        }

        
        private void SimulationEngine_Load(object sender, EventArgs e)
        {             
            listboxTickerInfo.Items.Add("ADT");
            listboxTickerInfo.Items.Add("WMT");
            listboxTickerInfo.Items.Add("INTC");
            listboxTickerInfo.Items.Add("AMZN");
            listBoxSource.Items.Add("S&P");
            engineTimer.Enabled = true;
        }

        private void engineTimer_Tick(object sender, EventArgs e)
        {
            Thread worker;
            engineTimer.Enabled = false;
            UpdateTickerInfoDelegate updateDelegate = new UpdateTickerInfoDelegate(UpdateTickerInfo);
            WorkerClass wc = new WorkerClass(this, updateDelegate);
            worker = new Thread(new ThreadStart(wc.RunProcess));
            worker.IsBackground = true;
            worker.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSourceName.Text))
            {
                if (listboxTickerInfo.Items.Contains(textBoxSourceName.Text.ToUpper()))
                {
                    lblStatus.Text = "Source already exist";
                    return;
                }
                listBoxSource.Items.Add(textBoxSourceName.Text.ToUpper());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSourceName.Text))
            {
                if (listBoxSource.Items.Count == 1 && listBoxSource.Items.Contains(textBoxSourceName.Text.ToUpper()))
                {
                    lblStatus.Text = "Can not delete the only source.";
                    return;
                }
                if (!listBoxSource.Items.Contains(textBoxSourceName.Text.ToUpper()))
                {
                    lblStatus.Text = "Source does not exist";
                    return;
                }
                listBoxSource.Items.Remove(textBoxSourceName.Text.ToUpper());
            }
        }

        private void SimulationEngine_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopService();
        }
        #endregion

        #region Private Methods

        private void StopService()
        {
            engineTimer.Stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            TickerInfos.Clear();
            lblStatus.Text = "Engine stopped";
            IsRunning = false;
        }        

        /// <summary>
        /// Generates the dummy data.
        /// </summary>
        private void UpdateTickerInfo()
        {
            Random rand = new Random();
            TickerItem newItem;
            TickerInfos.Clear();
            foreach (string tickerId in listboxTickerInfo.Items)
            {
                if (!TickerInfos.ContainsKey(tickerId))
                {
                    List<TickerItem> newItems = new List<TickerItem>();
                    foreach (string source in listBoxSource.Items)
                    {
                        newItems.Add(new TickerItem(tickerId, source, rand.Next(1, 999), rand.Next(1, 999)));
                        
                    }
                    TickerInfos.Add(tickerId, newItems);
                    
                } 
            }
            lblStatus.Text = "Updated at: " + System.DateTime.Now.ToString();
            engineTimer.Enabled = true;
        }
        private void StartEngine()
        {
            IsRunning = true;
            engineTimer.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "Engine started";
            //update the ticker info when the timer starts so it doesn't have to wait for the first tick
            UpdateTickerInfo();
        }
        #endregion
        
    }
}
