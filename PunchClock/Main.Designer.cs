namespace PunchClock
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialFlatButton();
            this.niNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblCurrentTime = new MaterialSkin.Controls.MaterialLabel();
            this.lblDayTime = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(598, 448);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(90, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(501, 448);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = false;
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // niNotifyIcon
            // 
            this.niNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.niNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("niNotifyIcon.Icon")));
            this.niNotifyIcon.Text = "Punch Clock";
            this.niNotifyIcon.Visible = true;
            this.niNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niNotifyIcon_MouseDoubleClick);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Depth = 0;
            this.lblCurrentTime.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCurrentTime.Location = new System.Drawing.Point(203, 419);
            this.lblCurrentTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(59, 24);
            this.lblCurrentTime.TabIndex = 2;
            this.lblCurrentTime.Text = "00:00";
            // 
            // lblDayTime
            // 
            this.lblDayTime.AutoSize = true;
            this.lblDayTime.Depth = 0;
            this.lblDayTime.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDayTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDayTime.Location = new System.Drawing.Point(203, 455);
            this.lblDayTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDayTime.Name = "lblDayTime";
            this.lblDayTime.Size = new System.Drawing.Size(59, 24);
            this.lblDayTime.TabIndex = 3;
            this.lblDayTime.Text = "00:00";
            // 
            // Main
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.lblDayTime);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Main";
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punch Clock";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton btnCancel;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private System.Windows.Forms.NotifyIcon niNotifyIcon;
        private MaterialSkin.Controls.MaterialLabel lblCurrentTime;
        private MaterialSkin.Controls.MaterialLabel lblDayTime;
    }
}

