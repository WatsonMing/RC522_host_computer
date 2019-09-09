namespace NFC
{
    partial class NFC
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NFC));
            this.cboPort = new System.Windows.Forms.ListBox();
            this.readport = new System.Windows.Forms.Button();
            this.connectport = new System.Windows.Forms.Button();
            this.activation = new System.Windows.Forms.Button();
            this.CardID = new System.Windows.Forms.TextBox();
            this.ReadCardData = new System.Windows.Forms.Button();
            this.PasswordCheck = new System.Windows.Forms.Button();
            this.WriteD = new System.Windows.Forms.Button();
            this.ReadD = new System.Windows.Forms.Button();
            this.WriteData = new System.Windows.Forms.TextBox();
            this.ReadData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.testw = new System.Windows.Forms.TextBox();
            this.testr = new System.Windows.Forms.TextBox();
            this.Test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPort
            // 
            this.cboPort.BackColor = System.Drawing.Color.White;
            this.cboPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboPort.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPort.FormattingEnabled = true;
            this.cboPort.ItemHeight = 16;
            this.cboPort.Location = new System.Drawing.Point(290, 54);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(91, 82);
            this.cboPort.TabIndex = 42;
            // 
            // readport
            // 
            this.readport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.readport.BackColor = System.Drawing.Color.White;
            this.readport.Cursor = System.Windows.Forms.Cursors.Default;
            this.readport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readport.ForeColor = System.Drawing.Color.Black;
            this.readport.Location = new System.Drawing.Point(401, 54);
            this.readport.Name = "readport";
            this.readport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.readport.Size = new System.Drawing.Size(100, 30);
            this.readport.TabIndex = 43;
            this.readport.Text = "读取端口";
            this.readport.UseVisualStyleBackColor = false;
            this.readport.Click += new System.EventHandler(this.readport_Click);
            // 
            // connectport
            // 
            this.connectport.BackColor = System.Drawing.Color.White;
            this.connectport.Cursor = System.Windows.Forms.Cursors.Default;
            this.connectport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connectport.ForeColor = System.Drawing.Color.Black;
            this.connectport.Location = new System.Drawing.Point(401, 106);
            this.connectport.Name = "connectport";
            this.connectport.Size = new System.Drawing.Size(100, 30);
            this.connectport.TabIndex = 44;
            this.connectport.Text = "连接设备";
            this.connectport.UseVisualStyleBackColor = false;
            this.connectport.Click += new System.EventHandler(this.connectport_Click_1);
            // 
            // activation
            // 
            this.activation.BackColor = System.Drawing.Color.White;
            this.activation.Cursor = System.Windows.Forms.Cursors.Default;
            this.activation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.activation.ForeColor = System.Drawing.Color.Black;
            this.activation.Location = new System.Drawing.Point(401, 167);
            this.activation.Name = "activation";
            this.activation.Size = new System.Drawing.Size(130, 30);
            this.activation.TabIndex = 45;
            this.activation.Text = "激活NFC设备";
            this.activation.UseVisualStyleBackColor = false;
            this.activation.Click += new System.EventHandler(this.button1_Click);
            // 
            // CardID
            // 
            this.CardID.BackColor = System.Drawing.Color.White;
            this.CardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CardID.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CardID.Location = new System.Drawing.Point(551, 242);
            this.CardID.Name = "CardID";
            this.CardID.ReadOnly = true;
            this.CardID.Size = new System.Drawing.Size(277, 26);
            this.CardID.TabIndex = 46;
            // 
            // ReadCardData
            // 
            this.ReadCardData.BackColor = System.Drawing.Color.White;
            this.ReadCardData.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReadCardData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadCardData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReadCardData.ForeColor = System.Drawing.Color.Black;
            this.ReadCardData.Location = new System.Drawing.Point(401, 242);
            this.ReadCardData.Name = "ReadCardData";
            this.ReadCardData.Size = new System.Drawing.Size(100, 30);
            this.ReadCardData.TabIndex = 47;
            this.ReadCardData.Text = "读取卡号";
            this.ReadCardData.UseVisualStyleBackColor = false;
            this.ReadCardData.Click += new System.EventHandler(this.ReadCardData_Click);
            // 
            // PasswordCheck
            // 
            this.PasswordCheck.BackColor = System.Drawing.Color.White;
            this.PasswordCheck.Cursor = System.Windows.Forms.Cursors.Default;
            this.PasswordCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordCheck.ForeColor = System.Drawing.Color.Black;
            this.PasswordCheck.Location = new System.Drawing.Point(401, 327);
            this.PasswordCheck.Name = "PasswordCheck";
            this.PasswordCheck.Size = new System.Drawing.Size(100, 30);
            this.PasswordCheck.TabIndex = 48;
            this.PasswordCheck.Text = "密码验证";
            this.PasswordCheck.UseVisualStyleBackColor = false;
            this.PasswordCheck.Click += new System.EventHandler(this.PasswordCheck_Click);
            // 
            // WriteD
            // 
            this.WriteD.BackColor = System.Drawing.Color.White;
            this.WriteD.Cursor = System.Windows.Forms.Cursors.Default;
            this.WriteD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WriteD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WriteD.ForeColor = System.Drawing.Color.Black;
            this.WriteD.Location = new System.Drawing.Point(401, 400);
            this.WriteD.Name = "WriteD";
            this.WriteD.Size = new System.Drawing.Size(100, 30);
            this.WriteD.TabIndex = 49;
            this.WriteD.Text = "写数据";
            this.WriteD.UseVisualStyleBackColor = false;
            this.WriteD.Click += new System.EventHandler(this.WriteD_Click);
            // 
            // ReadD
            // 
            this.ReadD.BackColor = System.Drawing.Color.White;
            this.ReadD.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReadD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReadD.ForeColor = System.Drawing.Color.Black;
            this.ReadD.Location = new System.Drawing.Point(401, 476);
            this.ReadD.Name = "ReadD";
            this.ReadD.Size = new System.Drawing.Size(100, 30);
            this.ReadD.TabIndex = 50;
            this.ReadD.Text = "读数据";
            this.ReadD.UseVisualStyleBackColor = false;
            this.ReadD.Click += new System.EventHandler(this.ReadD_Click);
            // 
            // WriteData
            // 
            this.WriteData.BackColor = System.Drawing.Color.White;
            this.WriteData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WriteData.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WriteData.Location = new System.Drawing.Point(540, 400);
            this.WriteData.Name = "WriteData";
            this.WriteData.Size = new System.Drawing.Size(412, 26);
            this.WriteData.TabIndex = 51;
            // 
            // ReadData
            // 
            this.ReadData.BackColor = System.Drawing.Color.White;
            this.ReadData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReadData.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReadData.Location = new System.Drawing.Point(540, 476);
            this.ReadData.Name = "ReadData";
            this.ReadData.ReadOnly = true;
            this.ReadData.Size = new System.Drawing.Size(412, 26);
            this.ReadData.TabIndex = 52;
            this.ReadData.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(548, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "卡号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(537, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "输入准备写入数据：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(537, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "卡内数据：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::NFC.Properties.Resources.bg;
            this.pictureBox1.Location = new System.Drawing.Point(34, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 236);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // testw
            // 
            this.testw.Location = new System.Drawing.Point(75, 375);
            this.testw.Name = "testw";
            this.testw.Size = new System.Drawing.Size(235, 21);
            this.testw.TabIndex = 57;
            // 
            // testr
            // 
            this.testr.Location = new System.Drawing.Point(75, 423);
            this.testr.Name = "testr";
            this.testr.Size = new System.Drawing.Size(235, 21);
            this.testr.TabIndex = 58;
            // 
            // Test
            // 
            this.Test.Location = new System.Drawing.Point(151, 467);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(75, 23);
            this.Test.TabIndex = 59;
            this.Test.Text = "测试";
            this.Test.UseVisualStyleBackColor = true;
            this.Test.Click += new System.EventHandler(this.Test_Click);
            // 
            // NFC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Controls.Add(this.Test);
            this.Controls.Add(this.testr);
            this.Controls.Add(this.testw);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReadData);
            this.Controls.Add(this.WriteData);
            this.Controls.Add(this.ReadD);
            this.Controls.Add(this.WriteD);
            this.Controls.Add(this.PasswordCheck);
            this.Controls.Add(this.ReadCardData);
            this.Controls.Add(this.CardID);
            this.Controls.Add(this.activation);
            this.Controls.Add(this.connectport);
            this.Controls.Add(this.readport);
            this.Controls.Add(this.cboPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NFC";
            this.Text = "NFC读写工具（试用PN532）-黄东明";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cboPort;
        private System.Windows.Forms.Button readport;
        private System.Windows.Forms.Button connectport;
        private System.Windows.Forms.Button activation;
        private System.Windows.Forms.TextBox CardID;
        private System.Windows.Forms.Button ReadCardData;
        private System.Windows.Forms.Button PasswordCheck;
        private System.Windows.Forms.Button WriteD;
        private System.Windows.Forms.Button ReadD;
        private System.Windows.Forms.TextBox WriteData;
        private System.Windows.Forms.TextBox ReadData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox testw;
        private System.Windows.Forms.TextBox testr;
        private System.Windows.Forms.Button Test;
    }
}

