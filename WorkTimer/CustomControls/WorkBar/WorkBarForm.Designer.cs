namespace WorkTimer.CustomControls.WorkBar
{
    partial class WorkBarForm
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
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.moveControlPanel = new System.Windows.Forms.Panel();
            this.controlTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mainControlButtonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.hoverButton = new WorkTimer.CustomControls.ImageButton();
            this.playPauseButton = new WorkTimer.CustomControls.ImageButton();
            this.settingsButton = new WorkTimer.CustomControls.ImageButton();
            this.clock1 = new WorkTimer.CustomControls.WorkBar.Clock();
            this.mainTableLayout.SuspendLayout();
            this.controlTableLayout.SuspendLayout();
            this.mainControlButtonsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoverButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.mainTableLayout.ColumnCount = 1;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.Controls.Add(this.moveControlPanel, 0, 1);
            this.mainTableLayout.Controls.Add(this.controlTableLayout, 0, 0);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 2;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.mainTableLayout.Size = new System.Drawing.Size(54, 267);
            this.mainTableLayout.TabIndex = 0;
            // 
            // moveControlPanel
            // 
            this.moveControlPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.moveControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moveControlPanel.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.moveControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveControlPanel.Location = new System.Drawing.Point(1, 255);
            this.moveControlPanel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.moveControlPanel.Name = "moveControlPanel";
            this.moveControlPanel.Size = new System.Drawing.Size(52, 6);
            this.moveControlPanel.TabIndex = 2;
            // 
            // controlTableLayout
            // 
            this.controlTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.controlTableLayout.ColumnCount = 2;
            this.controlTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.controlTableLayout.Controls.Add(this.mainControlButtonsTableLayout, 0, 3);
            this.controlTableLayout.Controls.Add(this.clock1, 0, 1);
            this.controlTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlTableLayout.Location = new System.Drawing.Point(1, 1);
            this.controlTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.controlTableLayout.Name = "controlTableLayout";
            this.controlTableLayout.RowCount = 4;
            this.controlTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.controlTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.controlTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.controlTableLayout.Size = new System.Drawing.Size(52, 248);
            this.controlTableLayout.TabIndex = 1;
            // 
            // mainControlButtonsTableLayout
            // 
            this.mainControlButtonsTableLayout.ColumnCount = 3;
            this.mainControlButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainControlButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainControlButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainControlButtonsTableLayout.Controls.Add(this.hoverButton, 0, 0);
            this.mainControlButtonsTableLayout.Controls.Add(this.playPauseButton, 0, 0);
            this.mainControlButtonsTableLayout.Controls.Add(this.settingsButton, 2, 0);
            this.mainControlButtonsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainControlButtonsTableLayout.Location = new System.Drawing.Point(1, 232);
            this.mainControlButtonsTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainControlButtonsTableLayout.Name = "mainControlButtonsTableLayout";
            this.mainControlButtonsTableLayout.RowCount = 1;
            this.mainControlButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainControlButtonsTableLayout.Size = new System.Drawing.Size(48, 15);
            this.mainControlButtonsTableLayout.TabIndex = 3;
            // 
            // hoverButton
            // 
            this.hoverButton.DownImage = global::WorkTimer.Properties.Resources.hide_hover;
            this.hoverButton.HoverImage = global::WorkTimer.Properties.Resources.hide_hover;
            this.hoverButton.Image = global::WorkTimer.Properties.Resources.hide;
            this.hoverButton.Location = new System.Drawing.Point(16, 0);
            this.hoverButton.Margin = new System.Windows.Forms.Padding(0);
            this.hoverButton.Name = "hoverButton";
            this.hoverButton.Size = new System.Drawing.Size(15, 15);
            this.hoverButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hoverButton.StaticImage = global::WorkTimer.Properties.Resources.hide;
            this.hoverButton.TabIndex = 2;
            this.hoverButton.TabStop = false;
            this.hoverButton.Click += new System.EventHandler(this.hoverButton_Click);
            // 
            // playPauseButton
            // 
            this.playPauseButton.DownImage = global::WorkTimer.Properties.Resources.play3_hover;
            this.playPauseButton.HoverImage = global::WorkTimer.Properties.Resources.play3_hover;
            this.playPauseButton.Image = global::WorkTimer.Properties.Resources.play3;
            this.playPauseButton.Location = new System.Drawing.Point(0, 0);
            this.playPauseButton.Margin = new System.Windows.Forms.Padding(0);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(15, 15);
            this.playPauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playPauseButton.StaticImage = global::WorkTimer.Properties.Resources.play3;
            this.playPauseButton.TabIndex = 1;
            this.playPauseButton.TabStop = false;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsButton.DownImage = global::WorkTimer.Properties.Resources.setting_hover;
            this.settingsButton.HoverImage = global::WorkTimer.Properties.Resources.setting_hover;
            this.settingsButton.Image = global::WorkTimer.Properties.Resources.setting;
            this.settingsButton.InitialImage = global::WorkTimer.Properties.Resources.setting;
            this.settingsButton.Location = new System.Drawing.Point(32, 0);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(16, 15);
            this.settingsButton.StaticImage = global::WorkTimer.Properties.Resources.setting;
            this.settingsButton.TabIndex = 3;
            this.settingsButton.TabStop = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // clock1
            // 
            this.clock1.BackColor = System.Drawing.Color.Black;
            this.clock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clock1.Location = new System.Drawing.Point(1, 50);
            this.clock1.Margin = new System.Windows.Forms.Padding(0);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(48, 48);
            this.clock1.TabIndex = 4;
            // 
            // WorkBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(54, 267);
            this.Controls.Add(this.mainTableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkBarForm";
            this.TopMost = true;
            this.mainTableLayout.ResumeLayout(false);
            this.controlTableLayout.ResumeLayout(false);
            this.mainControlButtonsTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hoverButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Panel moveControlPanel;
        private System.Windows.Forms.TableLayoutPanel controlTableLayout;
        private System.Windows.Forms.TableLayoutPanel mainControlButtonsTableLayout;
        private ImageButton hoverButton;
        private ImageButton playPauseButton;
        private Clock clock1;
        private ImageButton settingsButton;
    }
}