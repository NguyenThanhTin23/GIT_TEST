
namespace DA_WINFORM
{
    partial class frmReportHD
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
            this.reportHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ControlClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SuspendLayout();
            // 
            // reportHD
            // 
            this.reportHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportHD.LocalReport.ReportEmbeddedResource = "DA_LTTQ.Report1.rdlc";
            this.reportHD.Location = new System.Drawing.Point(0, 0);
            this.reportHD.Margin = new System.Windows.Forms.Padding(4);
            this.reportHD.Name = "reportHD";
            this.reportHD.ServerReport.BearerToken = null;
            this.reportHD.Size = new System.Drawing.Size(867, 700);
            this.reportHD.TabIndex = 0;
            this.reportHD.Load += new System.EventHandler(this.reportHD_Load);
            // 
            // ControlClose
            // 
            this.ControlClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlClose.BackColor = System.Drawing.SystemColors.Control;
            this.ControlClose.BorderRadius = 5;
            this.ControlClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.ControlClose.HoverState.Parent = this.ControlClose;
            this.ControlClose.IconColor = System.Drawing.Color.White;
            this.ControlClose.Location = new System.Drawing.Point(839, 0);
            this.ControlClose.Margin = new System.Windows.Forms.Padding(4);
            this.ControlClose.Name = "ControlClose";
            this.ControlClose.ShadowDecoration.Parent = this.ControlClose;
            this.ControlClose.Size = new System.Drawing.Size(28, 25);
            this.ControlClose.TabIndex = 123;
            this.ControlClose.Click += new System.EventHandler(this.ControlClose_Click);
            // 
            // frmReportHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 700);
            this.Controls.Add(this.ControlClose);
            this.Controls.Add(this.reportHD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReportHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.frmReportHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportHD;
        public Guna.UI2.WinForms.Guna2ControlBox ControlClose;
    }
}