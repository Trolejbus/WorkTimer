namespace WorkTimer.CustomControls.WorkBar
{
    partial class BreakNotificationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chillingLabel = new System.Windows.Forms.Label();
            this.chillingAnimation = new System.Windows.Forms.Timer(this.components);
            this.breakTimeLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.breakTimeLabel);
            this.panel1.Controls.Add(this.chillingLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 107);
            this.panel1.TabIndex = 0;
            // 
            // chillingLabel
            // 
            this.chillingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chillingLabel.ForeColor = System.Drawing.Color.White;
            this.chillingLabel.Location = new System.Drawing.Point(84, 26);
            this.chillingLabel.Name = "chillingLabel";
            this.chillingLabel.Size = new System.Drawing.Size(192, 36);
            this.chillingLabel.TabIndex = 0;
            this.chillingLabel.Text = "Chilling...";
            this.chillingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chillingLabel.Click += ChillingLabel_Click;
            // 
            // chillingAnimation
            // 
            this.chillingAnimation.Enabled = true;
            this.chillingAnimation.Interval = 750;
            this.chillingAnimation.Tick += new System.EventHandler(this.chillingAnimation_Tick);
            // 
            // label1
            // 
            this.breakTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.breakTimeLabel.ForeColor = System.Drawing.Color.Wheat;
            this.breakTimeLabel.Location = new System.Drawing.Point(3, 62);
            this.breakTimeLabel.Name = "breakTimeLabel";
            this.breakTimeLabel.Size = new System.Drawing.Size(269, 23);
            this.breakTimeLabel.TabIndex = 1;
            this.breakTimeLabel.Text = "00:00:00";
            this.breakTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BreakNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 107);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BreakNotificationForm";
            this.Text = "BreakNotification";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label chillingLabel;
        private System.Windows.Forms.Timer chillingAnimation;
        private System.Windows.Forms.Label breakTimeLabel;
    }
}