namespace PunchClock
{
    partial class Toast
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
            this.lblLabel = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Depth = 0;
            this.lblLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLabel.Location = new System.Drawing.Point(13, 78);
            this.lblLabel.MaximumSize = new System.Drawing.Size(550, 1200);
            this.lblLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(0, 24);
            this.lblLabel.TabIndex = 0;
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(350, 153);
            this.Controls.Add(this.lblLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Toast";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notification";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Toast_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblLabel;
    }
}