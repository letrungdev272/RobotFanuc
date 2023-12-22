
namespace phan_loai_mau_arm_fanuc_lr
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btcontrol = new System.Windows.Forms.Button();
            this.btdisconnectcam = new System.Windows.Forms.Button();
            this.btconnectcam = new System.Windows.Forms.Button();
            this.btdisconnectplc = new System.Windows.Forms.Button();
            this.btconnectplc = new System.Windows.Forms.Button();
            this.cbcam = new System.Windows.Forms.ComboBox();
            this.txtip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btcontrol);
            this.groupBox1.Controls.Add(this.btdisconnectcam);
            this.groupBox1.Controls.Add(this.btconnectcam);
            this.groupBox1.Controls.Add(this.btdisconnectplc);
            this.groupBox1.Controls.Add(this.btconnectplc);
            this.groupBox1.Controls.Add(this.cbcam);
            this.groupBox1.Controls.Add(this.txtip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(57, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONNECT";
            // 
            // btcontrol
            // 
            this.btcontrol.Location = new System.Drawing.Point(526, 46);
            this.btcontrol.Name = "btcontrol";
            this.btcontrol.Size = new System.Drawing.Size(83, 20);
            this.btcontrol.TabIndex = 8;
            this.btcontrol.Text = "CONTROL";
            this.btcontrol.UseVisualStyleBackColor = true;
            this.btcontrol.Click += new System.EventHandler(this.btcontrol_Click);
            // 
            // btdisconnectcam
            // 
            this.btdisconnectcam.Location = new System.Drawing.Point(401, 62);
            this.btdisconnectcam.Name = "btdisconnectcam";
            this.btdisconnectcam.Size = new System.Drawing.Size(83, 20);
            this.btdisconnectcam.TabIndex = 7;
            this.btdisconnectcam.Text = "DISCONNECT";
            this.btdisconnectcam.UseVisualStyleBackColor = true;
            this.btdisconnectcam.Click += new System.EventHandler(this.btdisconnectcam_Click);
            // 
            // btconnectcam
            // 
            this.btconnectcam.Location = new System.Drawing.Point(299, 62);
            this.btconnectcam.Name = "btconnectcam";
            this.btconnectcam.Size = new System.Drawing.Size(75, 20);
            this.btconnectcam.TabIndex = 6;
            this.btconnectcam.Text = "CONNECT";
            this.btconnectcam.UseVisualStyleBackColor = true;
            this.btconnectcam.Click += new System.EventHandler(this.btconnectcam_Click);
            // 
            // btdisconnectplc
            // 
            this.btdisconnectplc.Location = new System.Drawing.Point(401, 36);
            this.btdisconnectplc.Name = "btdisconnectplc";
            this.btdisconnectplc.Size = new System.Drawing.Size(83, 20);
            this.btdisconnectplc.TabIndex = 5;
            this.btdisconnectplc.Text = "DISCONNECT";
            this.btdisconnectplc.UseVisualStyleBackColor = true;
            this.btdisconnectplc.Click += new System.EventHandler(this.button2_Click);
            // 
            // btconnectplc
            // 
            this.btconnectplc.Location = new System.Drawing.Point(299, 36);
            this.btconnectplc.Name = "btconnectplc";
            this.btconnectplc.Size = new System.Drawing.Size(75, 20);
            this.btconnectplc.TabIndex = 4;
            this.btconnectplc.Text = "CONNECT";
            this.btconnectplc.UseVisualStyleBackColor = true;
            this.btconnectplc.Click += new System.EventHandler(this.btconnectplc_Click);
            // 
            // cbcam
            // 
            this.cbcam.FormattingEnabled = true;
            this.cbcam.Location = new System.Drawing.Point(112, 63);
            this.cbcam.Name = "cbcam";
            this.cbcam.Size = new System.Drawing.Size(148, 21);
            this.cbcam.TabIndex = 3;
            // 
            // txtip
            // 
            this.txtip.Location = new System.Drawing.Point(112, 36);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(148, 20);
            this.txtip.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CAMERA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP PLC";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 592);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btdisconnectplc;
        private System.Windows.Forms.Button btconnectplc;
        private System.Windows.Forms.ComboBox cbcam;
        private System.Windows.Forms.TextBox txtip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btdisconnectcam;
        private System.Windows.Forms.Button btconnectcam;
        private System.Windows.Forms.Button btcontrol;
    }
}