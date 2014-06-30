namespace IceInstrumentMonitor
{
    partial class MainForm
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
            this.btnLaunchEngine = new System.Windows.Forms.Button();
            this.btnLaunchClientGui = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLaunchEngine
            // 
            this.btnLaunchEngine.Location = new System.Drawing.Point(91, 12);
            this.btnLaunchEngine.Name = "btnLaunchEngine";
            this.btnLaunchEngine.Size = new System.Drawing.Size(109, 23);
            this.btnLaunchEngine.TabIndex = 0;
            this.btnLaunchEngine.Text = "Launch Engine";
            this.btnLaunchEngine.UseVisualStyleBackColor = true;
            this.btnLaunchEngine.Click += new System.EventHandler(this.btnLaunchEngine_Click);
            // 
            // btnLaunchClientGui
            // 
            this.btnLaunchClientGui.Location = new System.Drawing.Point(91, 55);
            this.btnLaunchClientGui.Name = "btnLaunchClientGui";
            this.btnLaunchClientGui.Size = new System.Drawing.Size(109, 23);
            this.btnLaunchClientGui.TabIndex = 1;
            this.btnLaunchClientGui.Text = "Launch GUI";
            this.btnLaunchClientGui.UseVisualStyleBackColor = true;
            this.btnLaunchClientGui.Click += new System.EventHandler(this.btnLaunchClientGui_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.btnLaunchClientGui);
            this.Controls.Add(this.btnLaunchEngine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLaunchEngine;
        private System.Windows.Forms.Button btnLaunchClientGui;
    }
}

