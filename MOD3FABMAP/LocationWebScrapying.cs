using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack; 

namespace MOD3FABMAP
{
    class LocationWebScrapying
    {
        HtmlDocument clsHtmlDoc;

        public LocationWebScrapying(string strWebUrl) 
        {
            HtmlWeb webClient = new HtmlWeb(); //建立htmlweb
            //處理C# 連線 HTTPS 網站發生驗證失敗導致基礎連接已關閉
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            clsHtmlDoc = webClient.Load(strWebUrl); //載入網址資料  
        }

        public HtmlNode GetHtmlNod(string strXPath)
        {
            HtmlNode Node = clsHtmlDoc.DocumentNode.SelectSingleNode(strXPath); 
            return Node;
        }

        public string GetAttributes(string strXPath, string strAttributes) 
        {
            HtmlNode Node = clsHtmlDoc.DocumentNode.SelectSingleNode(strXPath);
            return Node.Attributes[strAttributes].Value;
        }

        public string GetInnerText(string strXPath)
        {
            string strReturn = clsHtmlDoc.DocumentNode.SelectSingleNode(strXPath).InnerText;
            strReturn = strReturn.Replace("&nbsp;", ""); 
            return strReturn; 
        }
    }

    class LocationSystemXPath 
    {
        public static string PowerPlan = "//*[@id=\"lblManPowerPlan\"]";
        public static string CurrentShift = "//*[@id=\"lblCurrentShift\"]";
        public static string TotalAttend = "//*[@id=\"lblHeaderFooterAll\"]";
        public static string PersonLeave = "//*[@id=\"lblPersonLeaveItem\"]";
        public static string PersonSupport = "//*[@id=\"lblPersonSupportOtherFab\"]";
        public static string PersonUnListed = "//*[@id=\"lblPersonUnListed\"]";
        public static string PersonChangeShift = "//*[@id=\"lblPersonChangeShift\"]";
        public static string PersonCurrentActual = "//*[@id=\"lblPersonCurrentActual\"]";
        public static string PersonOtherFab = "//*[@id=\"lblPersonOtherFabSupport\"]";
        public static string PersonOvertime = "//*[@id=\"lblPersonOvertime\"]";
        public static string Male = "//*[@id=\"lblMale\"]";
        public static string Female = "//*[@id=\"lblFemale\"]";
        public static string Nationality = "//*[@id=\"lblCountryItem_1\"]";
        public static string Foreign = "//*[@id=\"lblCountryItem_2\"]";
        public static string ErtRequest = "//*[@id=\"lblErtReq\"]";
        public static string ErtExpectedAttend = "//*[@id=\"lblErtExpectedAttend\"]";
        public static string ErtActualAttend = "//*[@id=\"lblErtActualAttend\"]";
        public static string SENormal = "//*[@id=\"lblSEItem_1\"]";
        public static string SERisk = "//*[@id=\"lblSEItem_2\"]";
        public static string TotalInFab = "//*[@id=\"lblHeaderFabInAll\"]";
        public static string OtherGuest = "//*[@id=\"lblHeaderOtherGuest\"]";
        public static string OtherUnit = "//*[@id=\"lblHeaderOtherUnit\"]";
        public static string FabInIDL = "//*[@id=\"lblHeaderFabInIDL\"]";
        public static string FabInDL = "//*[@id=\"lblHeaderFabInDL\"]";
        public static string AttendPMAll = "//*[@id=\"lblHeaderAttendPMAll\"]";
        public static string PMFabInDL = "//*[@id=\"lblHeaderPMFabInDL\"]";
        public static string PMFabOutDL = "//*[@id=\"lblHeaderPMFabOutDL\"]";
        public static string AttendMFGDLAll = "//*[@id=\"lblHeaderAttendMFGDLAll\"]";
        public static string MFGFabInDL = "//*[@id=\"lblHeaderMFGFabInDL\"]";
        public static string MFGFabOutDL = "//*[@id=\"lblHeaderMFGFabOutDL\"]";
        public static string AType = "//*[@id=\"lblHeaderFooterAType\"]";
        public static string PType = "//*[@id=\"lblHeaderFooterPType\"]";
        public static string IType = "//*[@id=\"lblHeaderFooterIType\"]";
        public static string OType = "//*[@id=\"lblHeaderFooterOType\"]";
        public static string MFGFabInLogIn = "//*[@id=\"lblHeaderMFGFabInLogIn\"]";
        public static string MFGFabInLogOff = "//*[@id=\"lblHeaderMFGFabInLogOff\"]";
        public static string BeCareAll = "//*[@id=\"lblHeaderBeCareAll\"]";
        public static string Abnormal = "//*[@id=\"lblHeaderAbnormal\"]";
    }
}
