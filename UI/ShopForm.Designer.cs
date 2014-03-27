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
            this.lbl_vendor1 = new System.Windows.Forms.Label();
            this.lbl_vendor2 = new System.Windows.Forms.Label();
            this.lbl_vendor3 = new System.Windows.Forms.Label();
            this.lbl_vendor4 = new System.Windows.Forms.Label();
            this.lbl_vendor5 = new System.Windows.Forms.Label();
            this.lbl_vendor6 = new System.Windows.Forms.Label();
            this.lbl_vendor7 = new System.Windows.Forms.Label();
            this.lbl_vendor8 = new System.Windows.Forms.Label();
            this.lbl_vendor9 = new System.Windows.Forms.Label();
            this.lbl_vendor10 = new System.Windows.Forms.Label();
            this.lbl_vendor11 = new System.Windows.Forms.Label();
            this.label_moneyEarned = new System.Windows.Forms.Label();
            this.label_money = new System.Windows.Forms.Label();
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
            this.panelLog.Location = new System.Drawing.Point(97, 384);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(819, 168);
            this.panelLog.TabIndex = 4;
            // 
            // rtb_Log
            // 
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Log.Location = new System.Drawing.Point(3, 3);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Size = new System.Drawing.Size(809, 158);
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
            this.gb_Stand1.Tag = "Stand1";
            this.gb_Stand1.Text = "Stand 1 Time : 3 sec / Price : 7";
            // 
            // gb_Stand2
            // 
            this.gb_Stand2.Location = new System.Drawing.Point(218, 345);
            this.gb_Stand2.Name = "gb_Stand2";
            this.gb_Stand2.Size = new System.Drawing.Size(200, 20);
            this.gb_Stand2.TabIndex = 9;
            this.gb_Stand2.TabStop = false;
            this.gb_Stand2.Tag = "Stand2";
            this.gb_Stand2.Text = "Stand 2 Time: 5 sec / Price 11";
            // 
            // gb_Stand3
            // 
            this.gb_Stand3.Location = new System.Drawing.Point(424, 345);
            this.gb_Stand3.Name = "gb_Stand3";
            this.gb_Stand3.Size = new System.Drawing.Size(200, 20);
            this.gb_Stand3.TabIndex = 10;
            this.gb_Stand3.TabStop = false;
            this.gb_Stand3.Tag = "Stand3";
            this.gb_Stand3.Text = "Stand 3 Time: 10 sec / Price 20";
            // 
            // gb_Stand4
            // 
            this.gb_Stand4.Location = new System.Drawing.Point(630, 345);
            this.gb_Stand4.Name = "gb_Stand4";
            this.gb_Stand4.Size = new System.Drawing.Size(200, 20);
            this.gb_Stand4.TabIndex = 11;
            this.gb_Stand4.TabStop = false;
            this.gb_Stand4.Tag = "Stand4";
            this.gb_Stand4.Text = "Stand 4 Time: 1 sec / Price 3";
            // 
            // gb_Stand5
            // 
            this.gb_Stand5.Location = new System.Drawing.Point(836, 345);
            this.gb_Stand5.Name = "gb_Stand5";
            this.gb_Stand5.Size = new System.Drawing.Size(166, 20);
            this.gb_Stand5.TabIndex = 12;
            this.gb_Stand5.TabStop = false;
            this.gb_Stand5.Tag = "Stand5";
            this.gb_Stand5.Text = "Stand 5 Time: 8 sec / Price 15";
            // 
            // lbl_vendor1
            // 
            this.lbl_vendor1.AutoSize = true;
            this.lbl_vendor1.Location = new System.Drawing.Point(26, 368);
            this.lbl_vendor1.Name = "lbl_vendor1";
            this.lbl_vendor1.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor1.TabIndex = 13;
            this.lbl_vendor1.Tag = "Vendor1";
            this.lbl_vendor1.Text = "Vendor 1";
            // 
            // lbl_vendor2
            // 
            this.lbl_vendor2.AutoSize = true;
            this.lbl_vendor2.Location = new System.Drawing.Point(82, 368);
            this.lbl_vendor2.Name = "lbl_vendor2";
            this.lbl_vendor2.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor2.TabIndex = 14;
            this.lbl_vendor2.Tag = "Vendor2";
            this.lbl_vendor2.Text = "Vendor 2";
            // 
            // lbl_vendor3
            // 
            this.lbl_vendor3.AutoSize = true;
            this.lbl_vendor3.Location = new System.Drawing.Point(138, 368);
            this.lbl_vendor3.Name = "lbl_vendor3";
            this.lbl_vendor3.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor3.TabIndex = 15;
            this.lbl_vendor3.Tag = "Vendor3";
            this.lbl_vendor3.Text = "Vendor 3";
            // 
            // lbl_vendor4
            // 
            this.lbl_vendor4.AutoSize = true;
            this.lbl_vendor4.Location = new System.Drawing.Point(256, 368);
            this.lbl_vendor4.Name = "lbl_vendor4";
            this.lbl_vendor4.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor4.TabIndex = 16;
            this.lbl_vendor4.Tag = "Vendor4";
            this.lbl_vendor4.Text = "Vendor 4";
            // 
            // lbl_vendor5
            // 
            this.lbl_vendor5.AutoSize = true;
            this.lbl_vendor5.Location = new System.Drawing.Point(312, 368);
            this.lbl_vendor5.Name = "lbl_vendor5";
            this.lbl_vendor5.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor5.TabIndex = 17;
            this.lbl_vendor5.Tag = "Vendor5";
            this.lbl_vendor5.Text = "Vendor 5";
            // 
            // lbl_vendor6
            // 
            this.lbl_vendor6.AutoSize = true;
            this.lbl_vendor6.Location = new System.Drawing.Point(466, 368);
            this.lbl_vendor6.Name = "lbl_vendor6";
            this.lbl_vendor6.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor6.TabIndex = 18;
            this.lbl_vendor6.Tag = "Vendor6";
            this.lbl_vendor6.Text = "Vendor 6";
            // 
            // lbl_vendor7
            // 
            this.lbl_vendor7.AutoSize = true;
            this.lbl_vendor7.Location = new System.Drawing.Point(522, 368);
            this.lbl_vendor7.Name = "lbl_vendor7";
            this.lbl_vendor7.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor7.TabIndex = 19;
            this.lbl_vendor7.Tag = "Vendor7";
            this.lbl_vendor7.Text = "Vendor 7";
            // 
            // lbl_vendor8
            // 
            this.lbl_vendor8.AutoSize = true;
            this.lbl_vendor8.Location = new System.Drawing.Point(692, 368);
            this.lbl_vendor8.Name = "lbl_vendor8";
            this.lbl_vendor8.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor8.TabIndex = 20;
            this.lbl_vendor8.Tag = "Vendor8";
            this.lbl_vendor8.Text = "Vendor 8";
            // 
            // lbl_vendor9
            // 
            this.lbl_vendor9.AutoSize = true;
            this.lbl_vendor9.Location = new System.Drawing.Point(838, 368);
            this.lbl_vendor9.Name = "lbl_vendor9";
            this.lbl_vendor9.Size = new System.Drawing.Size(50, 13);
            this.lbl_vendor9.TabIndex = 21;
            this.lbl_vendor9.Tag = "Vendor9";
            this.lbl_vendor9.Text = "Vendor 9";
            // 
            // lbl_vendor10
            // 
            this.lbl_vendor10.AutoSize = true;
            this.lbl_vendor10.Location = new System.Drawing.Point(894, 368);
            this.lbl_vendor10.Name = "lbl_vendor10";
            this.lbl_vendor10.Size = new System.Drawing.Size(56, 13);
            this.lbl_vendor10.TabIndex = 22;
            this.lbl_vendor10.Tag = "Vendor10";
            this.lbl_vendor10.Text = "Vendor 10";
            // 
            // lbl_vendor11
            // 
            this.lbl_vendor11.AutoSize = true;
            this.lbl_vendor11.Location = new System.Drawing.Point(950, 368);
            this.lbl_vendor11.Name = "lbl_vendor11";
            this.lbl_vendor11.Size = new System.Drawing.Size(56, 13);
            this.lbl_vendor11.TabIndex = 23;
            this.lbl_vendor11.Tag = "Vendor11";
            this.lbl_vendor11.Text = "Vendor 11";
            // 
            // label_moneyEarned
            // 
            this.label_moneyEarned.AutoSize = true;
            this.label_moneyEarned.Location = new System.Drawing.Point(184, 13);
            this.label_moneyEarned.Name = "label_moneyEarned";
            this.label_moneyEarned.Size = new System.Drawing.Size(82, 13);
            this.label_moneyEarned.TabIndex = 24;
            this.label_moneyEarned.Text = "Money Earned :";
            // 
            // label_money
            // 
            this.label_money.AutoSize = true;
            this.label_money.Location = new System.Drawing.Point(184, 30);
            this.label_money.Name = "label_money";
            this.label_money.Size = new System.Drawing.Size(13, 13);
            this.label_money.TabIndex = 25;
            this.label_money.Text = "0";
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 556);
            this.Controls.Add(this.label_money);
            this.Controls.Add(this.label_moneyEarned);
            this.Controls.Add(this.lbl_vendor11);
            this.Controls.Add(this.lbl_vendor10);
            this.Controls.Add(this.lbl_vendor9);
            this.Controls.Add(this.lbl_vendor8);
            this.Controls.Add(this.lbl_vendor7);
            this.Controls.Add(this.lbl_vendor6);
            this.Controls.Add(this.lbl_vendor5);
            this.Controls.Add(this.lbl_vendor4);
            this.Controls.Add(this.lbl_vendor3);
            this.Controls.Add(this.lbl_vendor2);
            this.Controls.Add(this.lbl_vendor1);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Label lbl_vendor1;
        private System.Windows.Forms.Label lbl_vendor2;
        private System.Windows.Forms.Label lbl_vendor3;
        private System.Windows.Forms.Label lbl_vendor4;
        private System.Windows.Forms.Label lbl_vendor5;
        private System.Windows.Forms.Label lbl_vendor6;
        private System.Windows.Forms.Label lbl_vendor7;
        private System.Windows.Forms.Label lbl_vendor8;
        private System.Windows.Forms.Label lbl_vendor9;
        private System.Windows.Forms.Label lbl_vendor10;
        private System.Windows.Forms.Label lbl_vendor11;
        private System.Windows.Forms.Label label_moneyEarned;
        private System.Windows.Forms.Label label_money;
    }
}

