namespace UI
{
    partial class ShopForm
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
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Push = new System.Windows.Forms.Button();
            this.tb_PushCount = new System.Windows.Forms.TextBox();
            this.panelLog = new System.Windows.Forms.Panel();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.panelPush = new System.Windows.Forms.Panel();
            this.panelOpenClose = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gb_Stand1 = new System.Windows.Forms.GroupBox();
            this.gb_Stand2 = new System.Windows.Forms.GroupBox();
            this.gb_Stand3 = new System.Windows.Forms.GroupBox();
            this.gb_Stand4 = new System.Windows.Forms.GroupBox();
            this.gb_Stand5 = new System.Windows.Forms.GroupBox();
            this.gb_Overall = new System.Windows.Forms.GroupBox();
            this.panelLog.SuspendLayout();
            this.panelPush.SuspendLayout();
            this.panelOpenClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(87, 3);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 0;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(3, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Push
            // 
            this.btn_Push.Location = new System.Drawing.Point(3, 3);
            this.btn_Push.Name = "btn_Push";
            this.btn_Push.Size = new System.Drawing.Size(75, 23);
            this.btn_Push.TabIndex = 2;
            this.btn_Push.Text = "Push";
            this.btn_Push.UseVisualStyleBackColor = true;
            this.btn_Push.Click += new System.EventHandler(this.btn_Push_Click);
            // 
            // tb_PushCount
            // 
            this.tb_PushCount.Location = new System.Drawing.Point(84, 5);
            this.tb_PushCount.Name = "tb_PushCount";
            this.tb_PushCount.Size = new System.Drawing.Size(75, 20);
            this.tb_PushCount.TabIndex = 3;
            this.tb_PushCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // panelLog
            // 
            this.panelLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLog.Controls.Add(this.rtb_Log);
            this.panelLog.Location = new System.Drawing.Point(97, 371);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(819, 173);
            this.panelLog.TabIndex = 4;
            // 
            // rtb_Log
            // 
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Log.Location = new System.Drawing.Point(3, 3);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Size = new System.Drawing.Size(809, 163);
            this.rtb_Log.TabIndex = 0;
            this.rtb_Log.Text = "";
            // 
            // panelPush
            // 
            this.panelPush.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPush.Controls.Add(this.btn_Push);
            this.panelPush.Controls.Add(this.tb_PushCount);
            this.panelPush.Location = new System.Drawing.Point(12, 12);
            this.panelPush.Name = "panelPush";
            this.panelPush.Size = new System.Drawing.Size(165, 31);
            this.panelPush.TabIndex = 5;
            // 
            // panelOpenClose
            // 
            this.panelOpenClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOpenClose.Controls.Add(this.btn_Open);
            this.panelOpenClose.Controls.Add(this.btn_Close);
            this.panelOpenClose.Location = new System.Drawing.Point(837, 12);
            this.panelOpenClose.Name = "panelOpenClose";
            this.panelOpenClose.Size = new System.Drawing.Size(165, 31);
            this.panelOpenClose.TabIndex = 6;
            // 
            // gb_Stand1
            // 
            this.gb_Stand1.Location = new System.Drawing.Point(12, 345);
            this.gb_Stand1.Name = "gb_Stand1";
            this.gb_Stand1.Size = new System.Drawing.Size(200, 20);
            this.gb_Stand1.TabIndex = 8;
            this.gb_Stand1.TabStop = false;
            this.gb_Stand1.Text = "Stand 1";
            this.gb_Stand1.Tag = "Stand1";
            // 
            // gb_Stand2
            // 
            this.gb_Stand2.Location = new System.Drawing.Point(218, 345);
            this.gb_Stand2.Name = "gb_Stand2";
            this.gb_Stand2.Size = new System.Drawing.Size(200, 20);
            this.gb_Stand2.TabIndex = 9;
            this.gb_Stand2.TabStop = false;
            this.gb_Stand2.Text = "Stand 2";
            this.gb_Stand2.Tag = "Stand2";
            // 
            // gb_Stand3
            // 
            this.gb_Stand3.Location = new System.Drawing.Point(424, 345);
            this.gb_Stand3.Name = "gb_Stand3";
            this.gb_Stand3.Size = new System.Drawing.Size(200, 20);
            this.gb_Stand3.TabIndex = 10;
            this.gb_Stand3.TabStop = false;
            this.gb_Stand3.Text = "Stand 3";
            this.gb_Stand3.Tag = "Stand3";

            // 
            // gb_Stand4
            // 
            this.gb_Stand4.Location = new System.Drawing.Point(630, 345);
            this.gb_Stand4.Name = "gb_Stand4";
            this.gb_Stand4.Size = new System.Drawing.Size(200, 20);
            this.gb_Stand4.TabIndex = 11;
            this.gb_Stand4.TabStop = false;
            this.gb_Stand4.Text = "Stand 4";
            this.gb_Stand4.Tag = "Stand4";

            // 
            // gb_Stand5
            // 
            this.gb_Stand5.Location = new System.Drawing.Point(836, 345);
            this.gb_Stand5.Name = "gb_Stand5";
            this.gb_Stand5.Size = new System.Drawing.Size(166, 20);
            this.gb_Stand5.TabIndex = 12;
            this.gb_Stand5.TabStop = false;
            this.gb_Stand5.Text = "Stand 5";
            this.gb_Stand5.Tag = "Stand5";
            // 
            // gb_Overall
            // 
            this.gb_Overall.Location = new System.Drawing.Point(395, 138);
            this.gb_Overall.Name = "gb_Overall";
            this.gb_Overall.Size = new System.Drawing.Size(200, 20);
            this.gb_Overall.TabIndex = 13;
            this.gb_Overall.TabStop = false;
            this.gb_Overall.Text = "Shop";
            this.gb_Overall.Tag = "Overall";

            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 556);
            this.Controls.Add(this.gb_Overall);
            this.Controls.Add(this.gb_Stand5);
            this.Controls.Add(this.gb_Stand4);
            this.Controls.Add(this.gb_Stand3);
            this.Controls.Add(this.gb_Stand2);
            this.Controls.Add(this.gb_Stand1);
            this.Controls.Add(this.panelOpenClose);
            this.Controls.Add(this.panelPush);
            this.Controls.Add(this.panelLog);
            this.Name = "ShopForm";
            this.Text = "Shop";
            this.panelLog.ResumeLayout(false);
            this.panelPush.ResumeLayout(false);
            this.panelPush.PerformLayout();
            this.panelOpenClose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Push;
        private System.Windows.Forms.TextBox tb_PushCount;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Panel panelPush;
        private System.Windows.Forms.Panel panelOpenClose;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gb_Stand1;
        private System.Windows.Forms.GroupBox gb_Stand2;
        private System.Windows.Forms.GroupBox gb_Stand3;
        private System.Windows.Forms.GroupBox gb_Stand4;
        private System.Windows.Forms.GroupBox gb_Stand5;
        private System.Windows.Forms.GroupBox gb_Overall;
    }
}

