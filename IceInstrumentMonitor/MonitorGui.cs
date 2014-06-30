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
    public partial class MonitorGui : Form
    {
        #region Private Variables
        private SimulationEngine _currentSimulationEngine;
        private Dictionary<string, string> _tickerInfos;
        private delegate void ShowUpdateFromSimulationEngineDelegate();
        private BindingSource _source;
        #endregion

        #region Constructor
        public MonitorGui(SimulationEngine simulationEngine)
        {
            InitializeComponent();
            _currentSimulationEngine = simulationEngine;
        }
        #endregion        

        #region Event handler
        private void MonitorGui_Load(object sender, EventArgs e)
        {
            _tickerInfos = new Dictionary<string, string>();

            lblUpdateStatus.Text = "Loading... ";
            BindingList<TickerItem> bindinglist = new BindingList<TickerItem>(_currentSimulationEngine.TickerInfos.Values.SelectMany(i => i).ToList());
            _source = new BindingSource(bindinglist, null);
            dataGridTickerInfos.DataSource = _source;
            lblUpdateStatus.Text = "Updated at: " + System.DateTime.Now.ToString();  
            guiTimer.Start();
        }

        private void guiTimer_Tick(object sender, EventArgs e)
        {
            Thread worker;            
            ShowUpdateFromSimulationEngineDelegate updateDelegate = new ShowUpdateFromSimulationEngineDelegate(UpdateFromSimulationEngine);
            WorkerClass wc = new WorkerClass(this, updateDelegate);
            worker = new Thread(new ThreadStart(wc.RunProcess));
            worker.IsBackground = true; 
            worker.Start();

        }
        #endregion

        #region private Methods
        private void UpdateFromSimulationEngine()
        {
            guiTimer.Enabled = false;
            BindingList<TickerItem>  bindinglist = new BindingList<TickerItem>(_currentSimulationEngine.TickerInfos.Values.SelectMany(i => i).ToList());
            if (bindinglist.Count() != 0)
            {
                _source.DataSource = bindinglist;
                lblUpdateStatus.Text = "Updated at: " + System.DateTime.Now.ToString();                
            }
            guiTimer.Enabled = true;
        }
        #endregion
    }
}
