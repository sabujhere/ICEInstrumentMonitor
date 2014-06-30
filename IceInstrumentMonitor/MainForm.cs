using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceInstrumentMonitor
{
    public partial class MainForm : Form
    {
        #region Private Variables
        
        private SimulationEngine _curentSimulationEngine;
        private MonitorGui _currentMonitorGui;

        #endregion
        #region Properties
        public SimulationEngine CurentSimulationEngine
        {
            get
            {
                if (_curentSimulationEngine == null || _curentSimulationEngine.IsDisposed)
                {
                    _curentSimulationEngine = new SimulationEngine();
                }
                return _curentSimulationEngine;
            }
        }

        public MonitorGui CurentMonitorGui
        {
            get
            {
                if (_currentMonitorGui == null || _currentMonitorGui.IsDisposed)
                {
                    _currentMonitorGui = new MonitorGui(CurentSimulationEngine);
                }
                return _currentMonitorGui;
            }
        }
        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnLaunchEngine_Click(object sender, EventArgs e)
        {
            CurentSimulationEngine.Show();            
        }

        private void btnLaunchClientGui_Click(object sender, EventArgs e)
        {
            if (_curentSimulationEngine == null || !_curentSimulationEngine.IsRunning)
            {
                MessageBox.Show("Simulation Engine isn't running.  Please ensure the engine is running and try again.");
            }
            else 
            {
                CurentMonitorGui.Show();
            }
            
        }

        #endregion
    }
}
