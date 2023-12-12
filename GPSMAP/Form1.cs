using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; 
using System.Net; 
using Microsoft.VisualBasic.PowerPacks;
using GeneralUtility;
using MySql.Data.MySqlClient;


namespace GPSMAP
{
    public partial class MainForm : Form
    {
        private MySqlConnection _clsSqlConn;
        private string _dbHost = "10.84.143.226";//資料庫位址
        private string _dbUser = "Dispatch";//資料庫使用者帳號
        private string _dbPass = "minchieh";//資料庫使用者密碼
        private string _dbName = "mod3";//資料庫名稱

        private const string MOD3GPSURI = @"http://mod3gps.cminl.oa/Api/Position/ListOnlineByFloor?floor=1";
        private const string NOIMGFOUND = @"http://mod3gps.cminl.oa/Images/none_photo.jpg";

        private double _OriginPointX = 35.7873324734250;
        private double _OriginPointY = 65.3089203248202;
        private double _OriginWidth = 0.0039505089498;
        private double _OriginHeight = 0.0008854612188;

        private GPSPosition _clsSelectedTag = null;

        
        public MainForm()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            BaseTool.CheckRepeat("重複執行", true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string connStr = "server=" + _dbHost + ";port=20" + ";uid=" + _dbUser + ";pwd=" + _dbPass + ";database=" + _dbName;
            _clsSqlConn = new MySqlConnection(connStr);
            _clsSqlConn.Open();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            tmrUpdate_Tick(null, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            DateTime clsNow = DateTime.Now;
            labDate.Text = clsNow.Year + " 年 " + clsNow.Month + " 月 " + clsNow.Day + "日     " + getChtWeek(clsNow);

            GPSPosition[] clsGPSs = GPSinfo.ReadPositionList(GPSinfo.ReadWebText(MOD3GPSURI));
            UpdateGPSPosition(clsGPSs, pnlGPSlocation);

            var SortedGPS = clsGPSs.OrderBy(a => a.TagPower);
            lvShowPower.Items.Clear();
            foreach (GPSPosition gps in SortedGPS)
            {
                string strimgkey = "";
                if (gps.TagPower > 75) strimgkey = "100";
                else if (gps.TagPower > 50) strimgkey = "75";
                else if (gps.TagPower > 30) strimgkey = "50";
                else strimgkey = "30";
                ListViewItem item = new ListViewItem();
                item.ImageKey = strimgkey;
                item.Text = gps.PersonKey + " : " + gps.Name;
                item.Tag = gps; 
                //lvShowPower.Items.Add(new ListViewItem { ImageKey = strimgkey, Text = gps.PersonKey + " : " + gps.Name });
                lvShowPower.Items.Add(item);
            }
        }

        private void UpdateGPSPosition(GPSPosition[] clsGPSPositionList, Panel ParentPanel)
        {
            ParentPanel.Controls.Clear();

            ShapeContainer shapeContainer = new ShapeContainer();
            shapeContainer.Size = ParentPanel.Size;
            Shape[] clsshapes = new Shape[clsGPSPositionList.Count()];
            int index = 0;
            foreach (GPSPosition clsGPSPosition in clsGPSPositionList)
            {
                int positionX = (int)((clsGPSPosition.Longitude - _OriginPointX) * ParentPanel.Width / _OriginWidth);
                int positionY = (int)((clsGPSPosition.Latitude * (-1) - _OriginPointY) * ParentPanel.Height / _OriginHeight);
                
                if (_clsSelectedTag != null)
                {
                    if (_clsSelectedTag.PersonKey == clsGPSPosition.PersonKey) 
                    {
                        Microsoft.VisualBasic.PowerPacks.RectangleShape clsRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
                        clsRect.Size = new Size(20, 20);
                        clsRect.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                        clsRect.BackColor = Color.Red;
                        if (clsGPSPosition.RingColor != "null") clsRect.BorderColor = ColorTranslator.FromHtml(clsGPSPosition.RingColor);
                        else clsRect.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        clsRect.Location = new Point(positionX, positionY);
                        clsRect.Tag = clsGPSPosition;
                        clsRect.Click += new EventHandler(clsshape_Click);
                        clsshapes[index] = clsRect;
                        index++;
                        continue; 
                    }
                }
                
                Microsoft.VisualBasic.PowerPacks.OvalShape clsDot = new Microsoft.VisualBasic.PowerPacks.OvalShape();
                clsDot.Size = new Size(15, 15);
                clsDot.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                clsDot.BackColor = (clsGPSPosition.Color == "#EBEEE8") ? Color.Blue : ColorTranslator.FromHtml(clsGPSPosition.Color);
                if (clsGPSPosition.RingColor != "null") clsDot.BorderColor = ColorTranslator.FromHtml(clsGPSPosition.RingColor);
                else clsDot.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                clsDot.Location = new Point(positionX, positionY);
                clsDot.Tag = clsGPSPosition;
                clsDot.Click += new EventHandler(clsshape_Click);
                clsshapes[index] = clsDot;
                index++;
            }
            shapeContainer.Shapes.AddRange(clsshapes);
            ParentPanel.Controls.Add(shapeContainer);
        }

        private void clsshape_Click(object sender, EventArgs e)
        {
            Microsoft.VisualBasic.PowerPacks.OvalShape dotselected = (Microsoft.VisualBasic.PowerPacks.OvalShape)sender;
            GPSPosition clsGPS = (GPSPosition)dotselected.Tag;
            _clsSelectedTag = clsGPS; 

            lblGPSName.Text = clsGPS.Name;
            lblGPSPersonKey.Text = clsGPS.PersonKey;
            lblGPSSection.Text = clsGPS.Section;
            lblGPSCompetency.Text = clsGPS.Title;
            lblGPSTagSerial.Text = clsGPS.TagSerial.ToString();
            lblGPSTagPower.Text = "Power: " + clsGPS.TagPower.ToString();

            picGPSPic.Image = ReadImgSQL(clsGPS.PersonKey);
        }

        private void lvShowPower_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            GPSPosition clsGPS = (GPSPosition)e.Item.Tag;
            _clsSelectedTag = clsGPS;

            lblGPSName.Text = clsGPS.Name;
            lblGPSPersonKey.Text = clsGPS.PersonKey;
            lblGPSSection.Text = clsGPS.Section;
            lblGPSCompetency.Text = clsGPS.Title;
            lblGPSTagSerial.Text = clsGPS.TagSerial.ToString();
            lblGPSTagPower.Text = "Power: " + clsGPS.TagPower.ToString();

            picGPSPic.Image = ReadImgSQL(clsGPS.PersonKey);
        }

        private Image ReadImgSQL(string strPersonID)
        {
            byte[] Picbuffer;
            if (!_clsSqlConn.Ping()) _clsSqlConn.Open();
            String cmdText = "SELECT Photo FROM factory WHERE ID = " + strPersonID;
            MySqlCommand cmd = new MySqlCommand(cmdText, _clsSqlConn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Picbuffer = new byte[reader.GetBytes(0, 0, null, 0, int.MaxValue)];
                    reader.GetBytes(0, 0, Picbuffer, 0, Picbuffer.Length);
                    Bitmap bm = new Bitmap(new MemoryStream(Picbuffer));
                    reader.Close();
                    Picbuffer = null;
                    return bm;
                }
                else
                {
                    reader.Close();
                    return ReadImgWebUri(NOIMGFOUND);
                }
            }
            catch
            {
                return ReadImgWebUri(NOIMGFOUND);
            }
        }

        private Image ReadImgWebUri(string strWebUri)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");//网页编码==Encoding.UTF8
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(strWebUri));
            req.Method = "GET";
            req.UserAgent = " Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
            req.Accept = "image/png, image/svg+xml, image/*;q=0.8, */*;q=0.5";
            req.Headers.Add("X-HttpWatch-RID", " 46990-10314");
            req.Headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.8,en-US;q=0.5,en;q=0.3");
            try
            {
                HttpWebResponse ress = (HttpWebResponse)req.GetResponse();
                Stream sstreamRes = ress.GetResponseStream();
                return System.Drawing.Image.FromStream(sstreamRes);
            }
            catch
            {
                return null;
            }
        }

        #region "Methods others"
        private string getChtWeek(DateTime inputDT)
        {
            switch (inputDT.DayOfWeek.ToString())
            {
                case "Monday": return "星期一";
                case "Tuesday": return "星期二";
                case "Wednesday": return "星期三";
                case "Thursday": return "星期四";
                case "Friday": return "星期五";
                case "Saturday": return "星期六";
                case "Sunday": return "星期日";
                default: return "系統無法判斷";
            }
        }

        /// <summary> 封装创建控件时所需的信息(解决动态添加控件时，控件闪烁的问题) </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        

        
    }
}
