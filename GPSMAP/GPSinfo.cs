using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace GPSMAP
{
    class GPSinfo
    {
        public static GPSPosition[] ReadPositionList(string strJsonText)
        {
            List<GPSPosition> List_clsGPSPosition = new List<GPSPosition>();
            string[] strGPSPosition = strJsonText.Split(new string[] { "[{", "},{", "}]" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string strGps in strGPSPosition)
            {
                string strGpsText = Regex.Replace(strGps, "\" {0,3}\"", "null");
                string[] strGpsDetail = strGpsText.Split(new string[] { "\":", "\"", "," }, StringSplitOptions.RemoveEmptyEntries);
                GPSPosition clsGPS = new GPSPosition();
                clsGPS.ID = strGpsDetail[1] != null ? strGpsDetail[1] : null;
                clsGPS.CreateTime = strGpsDetail[3] != null ? strGpsDetail[3] : null;
                clsGPS.PersonType = strGpsDetail[5] != null ? int.Parse(strGpsDetail[5]) : -1;
                clsGPS.ModifyTime = strGpsDetail[7] != null ? strGpsDetail[7] : null;
                clsGPS.ProductionCount = strGpsDetail[9] != null ? int.Parse(strGpsDetail[9]) : -1;
                clsGPS.Floor = strGpsDetail[11] != null ? int.Parse(strGpsDetail[11]) : -1;
                clsGPS.TagPower = strGpsDetail[13] != null ? int.Parse(strGpsDetail[13]) : -1;
                clsGPS.Longitude = strGpsDetail[15] != null ? double.Parse(strGpsDetail[15]) : -1;
                clsGPS.Latitude = strGpsDetail[17] != null ? double.Parse(strGpsDetail[17]) : -1;
                clsGPS.PersonKey = strGpsDetail[19] != null ? strGpsDetail[19] : null;
                clsGPS.Name = strGpsDetail[21] != null ? strGpsDetail[21] : null;
                clsGPS.Picture = strGpsDetail[23] != null ? strGpsDetail[23] : null;
                clsGPS.Division = strGpsDetail[25] != null ? strGpsDetail[25] : null;
                clsGPS.DivisionCode = strGpsDetail[27] != null ? strGpsDetail[27] : null;
                clsGPS.Department = strGpsDetail[29] != null ? strGpsDetail[29] : null;
                clsGPS.DepartmentCode = strGpsDetail[31] != null ? strGpsDetail[31] : null;
                clsGPS.Section = strGpsDetail[33] != null ? strGpsDetail[33] : null;
                clsGPS.SectionCode = strGpsDetail[35] != null ? strGpsDetail[35] : null;
                clsGPS.Group = strGpsDetail[37] != null ? strGpsDetail[37] : null;
                clsGPS.GroupCode = strGpsDetail[39] != null ? strGpsDetail[39] : null;
                clsGPS.Title = strGpsDetail[41] != null ? strGpsDetail[41] : null;
                clsGPS.Sex = strGpsDetail[43] != null ? strGpsDetail[43] : null;
                clsGPS.MobileTel = strGpsDetail[45] != null ? strGpsDetail[45] : null;
                clsGPS.OfficeTel = strGpsDetail[47] != null ? strGpsDetail[47] : null;
                clsGPS.EmergencyContact = strGpsDetail[49] != null ? strGpsDetail[49] : null;
                clsGPS.EmergencyContactPhone = strGpsDetail[51] != null ? strGpsDetail[51] : null;
                clsGPS.Account = strGpsDetail[53] != null ? strGpsDetail[53] : null;
                clsGPS.Mail = strGpsDetail[55] != null ? strGpsDetail[55] : null;
                clsGPS.Shift = strGpsDetail[57] != null ? strGpsDetail[57] : null;
                clsGPS.Competency = strGpsDetail[59] != null ? strGpsDetail[59] : null;
                clsGPS.CompetencyCode = strGpsDetail[61] != null ? strGpsDetail[61] : null;
                clsGPS.Dispatch = strGpsDetail[63] != null ? strGpsDetail[63] : null;
                clsGPS.Label = strGpsDetail[65] != null ? strGpsDetail[65] : null;
                clsGPS.EntryTime = strGpsDetail[67] != null ? strGpsDetail[67] : null;
                clsGPS.TagSerial = strGpsDetail[69] != null ? int.Parse(strGpsDetail[69]) : -1;
                clsGPS.RingColor = strGpsDetail[71] != null ? strGpsDetail[71] : null;
                clsGPS.Memo = strGpsDetail[73] != null ? strGpsDetail[73] : null;
                clsGPS.CoordinateUpdateTime = strGpsDetail[75] != null ? strGpsDetail[75] : null;
                clsGPS.Color = strGpsDetail[77] != null ? strGpsDetail[77] : null;
                clsGPS.MapName = strGpsDetail[79] != null ? strGpsDetail[79] : null;
                List_clsGPSPosition.Add(clsGPS);
            }
            return List_clsGPSPosition.ToArray();
        }

        public static string ReadWebText(string strWebUri)
        {
            string strJsonText = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strWebUri);
                HttpWebResponse webresponse = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(webresponse.GetResponseStream(), Encoding.UTF8);
                strJsonText = streamReader.ReadToEnd();
                webresponse.Close();
                return strJsonText;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    [Serializable]
    class GPSPosition
    {
        public string ID;
        public string CreateTime;
        public int PersonType;
        public string ModifyTime;
        public int ProductionCount;
        public int Floor;
        public int TagPower;
        public double Longitude;
        public double Latitude;
        public string PersonKey;
        public string Name;
        public string Picture;
        public string Division;
        public string DivisionCode;
        public string Department;
        public string DepartmentCode;
        public string Section;
        public string SectionCode;
        public string Group;
        public string GroupCode;
        public string Title;
        public string Sex;
        public string MobileTel;
        public string OfficeTel;
        public string EmergencyContact;
        public string EmergencyContactPhone;
        public string Account;
        public string Mail;
        public string Shift;
        public string Competency;
        public string CompetencyCode;
        public string Dispatch;
        public string Label;
        public string EntryTime;
        public int TagSerial;
        public string RingColor;
        public string Memo;
        public string CoordinateUpdateTime;
        public string Color;
        public string MapName;
    }
}
