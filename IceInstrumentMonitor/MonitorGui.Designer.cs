namespace IceInstrumentMonitor
{
    partial class MonitorGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.guiTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridTickerInfos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTickerInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Location = new System.Drawing.Point(13, 296);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(131, 13);
            this.lblUpdateStatus.TabIndex = 1;
            this.lblUpdateStatus.Text = "Shows last updated status";
            // 
            // guiTimer
            // 
            this.guiTimer.Interval = 2000;
            this.guiTimer.Tick += new System.EventHandler(this.guiTimer_Tick);
            // 
            // dataGridTickerInfos
            // 
            this.dataGridTickerInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTickerInfos.Location = new System.Drawing.Point(12, 12);
            this.dataGridTickerInfos.Name = "dataGridTickerInfos";
            this.dataGridTickerInfos.Size = new System.Drawing.Size(627, 269);
            this.dataGridTickerInfos.TabIndex = 2;
            // 
            // MonitorGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 329);
            this.Controls.Add(this.dataGridTickerInfos);
            this.Controls.Add(this.lblUpdateStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitorGui";
            this.Text = "ICE Instrument Monitor";
            this.Load += new System.EventHandler(this.MonitorGui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTickerInfos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.Timer guiTimer;
        private System.Windows.Forms.DataGridView dataGridTickerInfos;
    }
}