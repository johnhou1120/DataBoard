namespace GPSMAP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlbar = new System.Windows.Forms.Panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.labVer = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.labDate = new System.Windows.Forms.Label();
            this.Clock = new InxUserControl.PageClock();
            this.pnl_content = new System.Windows.Forms.Panel();
            this.pnlmap = new System.Windows.Forms.Panel();
            this.pnlGPSlocation = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvShowPower = new System.Windows.Forms.ListView();
            this.PowerImg = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlGPSInfo = new System.Windows.Forms.Panel();
            this.lblGPSTagPower = new System.Windows.Forms.Label();
            this.lblGPS = new System.Windows.Forms.Label();
            this.lblGPSTagSerial = new System.Windows.Forms.Label();
            this.picGPSPic = new System.Windows.Forms.PictureBox();
            this.lblGPSCompetency = new System.Windows.Forms.Label();
            this.lblGPSName = new System.Windows.Forms.Label();
            this.lblGPSPersonKey = new System.Windows.Forms.Label();
            this.lblGPSSection = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.printForm1 = new Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(this.components);
            this.pnlbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnl_content.SuspendLayout();
            this.pnlmap.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlGPSInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGPSPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlbar
            // 
            this.pnlbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlbar.Controls.Add(this.lbltitle);
            this.pnlbar.Controls.Add(this.labVer);
            this.pnlbar.Controls.Add(this.picLogo);
            this.pnlbar.Controls.Add(this.btnExit);
            this.pnlbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlbar.Location = new System.Drawing.Point(0, 0);
            this.pnlbar.Name = "pnlbar";
            this.pnlbar.Size = new System.Drawing.Size(1366, 43);
            this.pnlbar.TabIndex = 27;
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltitle.Font = new System.Drawing.Font("DFPLiShuW3-B5", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbltitle.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbltitle.Location = new System.Drawing.Point(103, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lbltitle.Size = new System.Drawing.Size(1071, 43);
            this.lbltitle.TabIndex = 5;
            this.lbltitle.Text = "MOD3    GPS    定位看板";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labVer
            // 
            this.labVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labVer.Dock = System.Windows.Forms.DockStyle.Right;
            this.labVer.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVer.ForeColor = System.Drawing.Color.Cornsilk;
            this.labVer.Location = new System.Drawing.Point(1174, 0);
            this.labVer.Name = "labVer";
            this.labVer.Size = new System.Drawing.Size(149, 43);
            this.labVer.TabIndex = 4;
            this.labVer.Text = "V21.02.01";
            this.labVer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(103, 43);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(1323, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(43, 43);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlBottom.Controls.Add(this.labDate);
            this.pnlBottom.Controls.Add(this.Clock);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 728);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlBottom.Size = new System.Drawing.Size(1366, 40);
            this.pnlBottom.TabIndex = 30;
            // 
            // labDate
            // 
            this.labDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.labDate.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDate.ForeColor = System.Drawing.Color.White;
            this.labDate.Location = new System.Drawing.Point(551, 0);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(500, 40);
            this.labDate.TabIndex = 7;
            this.labDate.Text = "2017 年 08 月 19日 Thourdayyyyy";
            this.labDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Clock
            // 
            this.Clock.BackColor = System.Drawing.Color.Transparent;
            this.Clock.Dock = System.Windows.Forms.DockStyle.Right;
            this.Clock.Location = new System.Drawing.Point(1051, 0);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(305, 40);
            this.Clock.TabIndex = 6;
            // 
            // pnl_content
            // 
            this.pnl_content.BackColor = System.Drawing.Color.Transparent;
            this.pnl_content.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl_content.Controls.Add(this.pnlmap);
            this.pnl_content.Controls.Add(this.panel1);
            this.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_content.Location = new System.Drawing.Point(0, 43);
            this.pnl_content.Name = "pnl_content";
            this.pnl_content.Padding = new System.Windows.Forms.Padding(20);
            this.pnl_content.Size = new System.Drawing.Size(1366, 685);
            this.pnl_content.TabIndex = 31;
            // 
            // pnlmap
            // 
            this.pnlmap.BackColor = System.Drawing.Color.Black;
            this.pnlmap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlmap.BackgroundImage")));
            this.pnlmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlmap.Controls.Add(this.pnlGPSlocation);
            this.pnlmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlmap.Location = new System.Drawing.Point(20, 20);
            this.pnlmap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlmap.Name = "pnlmap";
            this.pnlmap.Size = new System.Drawing.Size(976, 645);
            this.pnlmap.TabIndex = 44;
            // 
            // pnlGPSlocation
            // 
            this.pnlGPSlocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGPSlocation.BackColor = System.Drawing.Color.Transparent;
            this.pnlGPSlocation.Location = new System.Drawing.Point(0, 63);
            this.pnlGPSlocation.Name = "pnlGPSlocation";
            this.pnlGPSlocation.Size = new System.Drawing.Size(976, 518);
            this.pnlGPSlocation.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.lvShowPower);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlGPSInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(996, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(350, 645);
            this.panel1.TabIndex = 42;
            // 
            // lvShowPower
            // 
            this.lvShowPower.BackColor = System.Drawing.Color.Black;
            this.lvShowPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShowPower.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvShowPower.ForeColor = System.Drawing.Color.White;
            this.lvShowPower.LargeImageList = this.PowerImg;
            this.lvShowPower.Location = new System.Drawing.Point(10, 340);
            this.lvShowPower.MultiSelect = false;
            this.lvShowPower.Name = "lvShowPower";
            this.lvShowPower.Scrollable = false;
            this.lvShowPower.Size = new System.Drawing.Size(330, 295);
            this.lvShowPower.SmallImageList = this.PowerImg;
            this.lvShowPower.StateImageList = this.PowerImg;
            this.lvShowPower.TabIndex = 46;
            this.lvShowPower.UseCompatibleStateImageBehavior = false;
            this.lvShowPower.View = System.Windows.Forms.View.List;
            this.lvShowPower.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvShowPower_ItemSelectionChanged);
            // 
            // PowerImg
            // 
            this.PowerImg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PowerImg.ImageStream")));
            this.PowerImg.TransparentColor = System.Drawing.Color.Transparent;
            this.PowerImg.Images.SetKeyName(0, "30");
            this.PowerImg.Images.SetKeyName(1, "50");
            this.PowerImg.Images.SetKeyName(2, "75");
            this.PowerImg.Images.SetKeyName(3, "100");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 320);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 20);
            this.panel2.TabIndex = 45;
            // 
            // pnlGPSInfo
            // 
            this.pnlGPSInfo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlGPSInfo.Controls.Add(this.lblGPSTagPower);
            this.pnlGPSInfo.Controls.Add(this.lblGPS);
            this.pnlGPSInfo.Controls.Add(this.lblGPSTagSerial);
            this.pnlGPSInfo.Controls.Add(this.picGPSPic);
            this.pnlGPSInfo.Controls.Add(this.lblGPSCompetency);
            this.pnlGPSInfo.Controls.Add(this.lblGPSName);
            this.pnlGPSInfo.Controls.Add(this.lblGPSPersonKey);
            this.pnlGPSInfo.Controls.Add(this.lblGPSSection);
            this.pnlGPSInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGPSInfo.Location = new System.Drawing.Point(10, 10);
            this.pnlGPSInfo.Name = "pnlGPSInfo";
            this.pnlGPSInfo.Size = new System.Drawing.Size(330, 310);
            this.pnlGPSInfo.TabIndex = 44;
            // 
            // lblGPSTagPower
            // 
            this.lblGPSTagPower.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSTagPower.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGPSTagPower.ForeColor = System.Drawing.Color.White;
            this.lblGPSTagPower.Location = new System.Drawing.Point(173, 249);
            this.lblGPSTagPower.Name = "lblGPSTagPower";
            this.lblGPSTagPower.Size = new System.Drawing.Size(140, 31);
            this.lblGPSTagPower.TabIndex = 37;
            this.lblGPSTagPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGPS
            // 
            this.lblGPS.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGPS.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGPS.ForeColor = System.Drawing.Color.White;
            this.lblGPS.Location = new System.Drawing.Point(0, 0);
            this.lblGPS.Name = "lblGPS";
            this.lblGPS.Size = new System.Drawing.Size(330, 31);
            this.lblGPS.TabIndex = 31;
            this.lblGPS.Text = "人員資訊";
            this.lblGPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGPSTagSerial
            // 
            this.lblGPSTagSerial.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSTagSerial.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGPSTagSerial.ForeColor = System.Drawing.Color.White;
            this.lblGPSTagSerial.Location = new System.Drawing.Point(173, 199);
            this.lblGPSTagSerial.Name = "lblGPSTagSerial";
            this.lblGPSTagSerial.Size = new System.Drawing.Size(140, 31);
            this.lblGPSTagSerial.TabIndex = 36;
            this.lblGPSTagSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picGPSPic
            // 
            this.picGPSPic.BackColor = System.Drawing.Color.Transparent;
            this.picGPSPic.Location = new System.Drawing.Point(18, 58);
            this.picGPSPic.Name = "picGPSPic";
            this.picGPSPic.Size = new System.Drawing.Size(140, 177);
            this.picGPSPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGPSPic.TabIndex = 30;
            this.picGPSPic.TabStop = false;
            // 
            // lblGPSCompetency
            // 
            this.lblGPSCompetency.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSCompetency.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGPSCompetency.ForeColor = System.Drawing.Color.White;
            this.lblGPSCompetency.Location = new System.Drawing.Point(173, 152);
            this.lblGPSCompetency.Name = "lblGPSCompetency";
            this.lblGPSCompetency.Size = new System.Drawing.Size(140, 31);
            this.lblGPSCompetency.TabIndex = 35;
            this.lblGPSCompetency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGPSName
            // 
            this.lblGPSName.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSName.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGPSName.ForeColor = System.Drawing.Color.White;
            this.lblGPSName.Location = new System.Drawing.Point(173, 58);
            this.lblGPSName.Name = "lblGPSName";
            this.lblGPSName.Size = new System.Drawing.Size(140, 31);
            this.lblGPSName.TabIndex = 32;
            this.lblGPSName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGPSPersonKey
            // 
            this.lblGPSPersonKey.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSPersonKey.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGPSPersonKey.ForeColor = System.Drawing.Color.White;
            this.lblGPSPersonKey.Location = new System.Drawing.Point(18, 249);
            this.lblGPSPersonKey.Name = "lblGPSPersonKey";
            this.lblGPSPersonKey.Size = new System.Drawing.Size(140, 31);
            this.lblGPSPersonKey.TabIndex = 33;
            this.lblGPSPersonKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGPSSection
            // 
            this.lblGPSSection.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSSection.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGPSSection.ForeColor = System.Drawing.Color.White;
            this.lblGPSSection.Location = new System.Drawing.Point(173, 105);
            this.lblGPSSection.Name = "lblGPSSection";
            this.lblGPSSection.Size = new System.Drawing.Size(140, 31);
            this.lblGPSSection.TabIndex = 34;
            this.lblGPSSection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // printForm1
            // 
            this.printForm1.DocumentName = "document";
            this.printForm1.Form = this;
            this.printForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter;
            this.printForm1.PrinterSettings = ((System.Drawing.Printing.PrinterSettings)(resources.GetObject("printForm1.PrinterSettings")));
            this.printForm1.PrintFileName = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pnl_content);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MOD3 GPS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.pnlbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnl_content.ResumeLayout(false);
            this.pnlmap.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlGPSInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGPSPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlbar;
        private System.Windows.Forms.Label labVer;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label labDate;
        private InxUserControl.PageClock Clock;
        private System.Windows.Forms.Panel pnl_content;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlGPSInfo;
        private System.Windows.Forms.Label lblGPSTagPower;
        private System.Windows.Forms.Label lblGPS;
        private System.Windows.Forms.Label lblGPSTagSerial;
        private System.Windows.Forms.PictureBox picGPSPic;
        private System.Windows.Forms.Label lblGPSCompetency;
        private System.Windows.Forms.Label lblGPSName;
        private System.Windows.Forms.Label lblGPSPersonKey;
        private System.Windows.Forms.Label lblGPSSection;
        private System.Windows.Forms.Panel pnlmap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvShowPower;
        private System.Windows.Forms.Panel pnlGPSlocation;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.ImageList PowerImg;
        private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm printForm1;
    }
}

