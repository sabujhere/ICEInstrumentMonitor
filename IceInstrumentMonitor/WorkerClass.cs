using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceInstrumentMonitor
{
    public class WorkerClass
    {
        #region Private Variables
        private ContainerControl _sender = null;
        private Delegate _senderDelegate = null;
        #endregion

        #region Constructor
        public WorkerClass( ContainerControl sender, Delegate senderDelegate)
		{
			_sender = sender;
			_senderDelegate = senderDelegate;
		}
        #endregion

        #region Methods

        public void RunProcess()
        {
            //Thread.Sleep(5000);
            Thread.CurrentThread.IsBackground = true;
            _sender.BeginInvoke(_senderDelegate);
            
        }

        #endregion
    }
}
