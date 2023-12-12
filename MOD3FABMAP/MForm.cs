using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; 
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Net;
using Microsoft.VisualBasic.PowerPacks;
using MySql.Data.MySqlClient;
using HtmlAgilityPack;
using GeneralUtility; 

namespace MOD3FABMAP
{
    public partial class MForm : Form
    {
        private MySqlConnection _clsSqlConn;
        private string _dbHost = "10.84.143.226";//資料庫位址
        private string _dbUser = "Dispatch";//資料庫使用者帳號
        private string _dbPass = "minchieh";//資料庫使用者密碼
        private string _dbName = "mod3";//資料庫名稱

        private const string MOD3GPSURI = @"http://mod3gps.cminl.oa/Api/Position/ListOnlineByFloor?floor=1";
        private const string MFGREPORT = @"http://dlkpi.cminl.oa/MFGReport/PositioningReport/PositioningInfoReport.aspx?Shop=MOD3";
        private const string NOIMGFOUND = @"http://mod3gps.cminl.oa/Images/none_photo.jpg";

        private double _OriginPointX = 35.7873324734250;
        private double _OriginPointY = 65.3089203248202;
        private double _OriginWidth = 0.0039505089498;
        private double _OriginHeight = 0.0008854612188;

        #region "Methods - New"
        
        public MForm()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            BaseTool.CheckRepeat("重複執行", true);

            // 設定視窗自動縮放
            x = this.Width;
            y = this.Height;
            setTag(this);
            // 設定視窗顯示範圍
            this.Size = SystemInformation.PrimaryMonitorSize;
        }

        private void MForm_Load(object sender, EventArgs e)
        {
            //BaseTool.EnableAutoRun();

            //GPSPosition d = new GPSPosition();
            //d.Account = "123";
            //d.Dispatch = "122222";
            

            //GeneralUtility.IO.XFile.WriteXmlSerialize("D:\\123\\001.xml", d);

            //GPSPosition a = new GPSPosition();
            //GeneralUtility.IO.XFile.ReadXmlSerialize("D:\\123\\001.xml", ref a);

            string connStr = "server=" + _dbHost + ";port=20" + ";uid=" + _dbUser + ";pwd=" + _dbPass + ";database=" + _dbName;
            _clsSqlConn = new MySqlConnection(connStr);
            _clsSqlConn.Open();
        }

        private void MForm_Shown(object sender, EventArgs e)
        {
            tmrUpdate_Tick(null, null);
            tmrLoadWebData_Tick(null, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 控件大小随窗体大小等比例缩放

        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度

        /// <summary> 在子控件的Tag中寫入空間原本的位子參數 </summary>
        /// <param name="cons">父控件</param>
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }

        /// <summary> 設定控件的新位置參數 </summary>
        /// <param name="newx">寬度的缩放比例</param>
        /// <param name="newy">高度的缩放比例</param>
        /// <param name="cons">父控件</param>
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }

        /// <summary> 視窗改變大小事件 </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }

        #endregion

        #endregion

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            DateTime clsNow = DateTime.Now;
            labDate.Text = clsNow.Year + " 年 " + clsNow.Month + " 月 " + clsNow.Day + "日     " + getChtWeek(clsNow);

            GPSPosition[] clsGPSs = MOD3GPS.ReadPositionList(MOD3GPS.ReadWebText(MOD3GPSURI));
            UpdateGPSPosition(clsGPSs, pnl_FabBackgraund);

            var SortedGPS = clsGPSs.OrderBy(a => a.TagPower);
            lvShowPower.Items.Clear(); 
            foreach (GPSPosition gps in SortedGPS)
            {
                string strimgkey = "";
                if (gps.TagPower > 75) strimgkey = "100";
                else if (gps.TagPower > 50) strimgkey = "75";
                else if (gps.TagPower > 30) strimgkey = "50";
                else strimgkey = "30";
                lvShowPower.Items.Add(new ListViewItem { ImageKey = strimgkey, Text = gps.PersonKey +" : " + gps.Name});
            }
        }

        private void UpdateGPSPosition(GPSPosition[] clsGPSPositionList, Panel ParentPanel) 
        {
            pnl_FabBackgraund.Controls.Clear();

            ShapeContainer shapeContainer = new ShapeContainer();
            shapeContainer.Size = ParentPanel.Size;
            Shape[] clsDots = new Shape[clsGPSPositionList.Count()]; 
            int index = 0; 
            foreach (GPSPosition clsGPSPosition in clsGPSPositionList) 
            {
                Microsoft.VisualBasic.PowerPacks.OvalShape clsDot = new Microsoft.VisualBasic.PowerPacks.OvalShape();
                clsDot.Size = new Size(12, 12);
                clsDot.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                clsDot.BackColor = (clsGPSPosition.Color == "#EBEEE8")? Color.Blue : ColorTranslator.FromHtml(clsGPSPosition.Color);
                if (clsGPSPosition.RingColor != "null") clsDot.BorderColor = ColorTranslator.FromHtml(clsGPSPosition.RingColor);
                else clsDot.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom; 
                int positionX = (int)((clsGPSPosition.Longitude - _OriginPointX) * ParentPanel.Width / _OriginWidth);
                int positionY = (int)((clsGPSPosition.Latitude * (-1) - _OriginPointY) * ParentPanel.Height / _OriginHeight);
                clsDot.Location = new Point(positionX, positionY);
                clsDot.Tag = clsGPSPosition;
                clsDot.Click +=new EventHandler(clsDot_Click);
                clsDots[index] = clsDot;
                index++; 
            }
            shapeContainer.Shapes.AddRange(clsDots); 
            ParentPanel.Controls.Add(shapeContainer); 
        }

        private void clsDot_Click(object sender, EventArgs e)
        {
            Microsoft.VisualBasic.PowerPacks.OvalShape dotselected = (Microsoft.VisualBasic.PowerPacks.OvalShape)sender; 
            GPSPosition clsGPS = (GPSPosition)dotselected.Tag;
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

        private void LoadLocationSystem()
        {
            LocationWebScrapying clsWebScrpapying = new LocationWebScrapying(MFGREPORT);
            lblPowerPlan.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PowerPlan);
            lblCurrentShift.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.CurrentShift);
            lblTotalAttend.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.TotalAttend);
            lblmale.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.Male);
            lblfemale.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.Female);
            lblNationality.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.Nationality);
            lblForeign.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.Foreign);
            lblErtRequest.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.ErtRequest);
            lblErtExpectedAttend.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.ErtExpectedAttend);
            lblErtActualAttend.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.ErtActualAttend);
            lblSENormal.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.SENormal);
            lblSERisk.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.SERisk);
            lblPersonLeave.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PersonLeave);
            lblPersonSupport.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PersonSupport);
            lblPersonUnListed.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PersonUnListed);
            lblPersonChangeShift.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PersonChangeShift);
            lblPersonCurrentActual.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PersonCurrentActual);
            lblPersonOtherFab.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PersonOtherFab);
            lblPersonOvertime.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PersonOvertime);
            lblTotalInFab.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.TotalInFab);
            lblOtherGuest.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.OtherGuest);
            lblOtherUnit.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.OtherUnit);
            lblFabInIDL.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.FabInIDL);
            lblFabInDL.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.FabInDL);
            lblAttendPMAll.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.AttendPMAll);
            lblPMFabInDL.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PMFabInDL);
            lblPMFabOutDL.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PMFabOutDL);
            lblAttendMFGDLAll.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.AttendMFGDLAll);
            lblMFGFabInDL.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.MFGFabInDL);
            lblMFGFabOutDL.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.MFGFabOutDL);
            lblAType.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.AType);
            lblPType.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.PType);
            lblIType.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.IType);
            lblOType.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.OType);
            lblMFGFabInLogIn.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.MFGFabInLogIn);
            lblMFGFabInLogOff.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.MFGFabInLogOff);
            lblBeCareAll.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.BeCareAll);
            lblAbnormal.Text = clsWebScrpapying.GetInnerText(LocationSystemXPath.Abnormal);
        }

        private void tmrLoadWebData_Tick(object sender, EventArgs e)
        {
            Thread thrLoadData = new Thread(LoadLocationSystem);
            thrLoadData.IsBackground = true; 
            thrLoadData.Start();
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
