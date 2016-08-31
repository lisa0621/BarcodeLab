using BarcodeLab.Report.ViewModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarcodeLab.Report.ASPX
{
    public partial class BarcodeList : System.Web.UI.Page
    {
        private readonly ReportDocument report = new ReportDocument();

        protected void Page_Init(object sender, EventArgs e)
        {
            int count = 100;
            AddReportArray(count);
        }

        private void AddReportArray(int count)
        {
            List<BarCodeViewModel> result = new List<BarCodeViewModel>();

            for (int i = 1; i <= count; i++)
            {
                string no = "F" + DateTime.Now.ToString("yyyyMMdd") + i.ToString("0000");
                var model = new BarCodeViewModel();
                model.barCodeNo = no;
                result.Add(model);
            }

            report.Load(Path.Combine(Server.MapPath("~/Report/RPT"), "BarcodeList.rpt"));
            report.SetDataSource(result);

            SetReport(crBarcodeList, report);
        }

        private void SetReport(CrystalReportViewer reportViewer, ReportDocument reportDataSet)
        {
            reportViewer.AutoDataBind = true;
            reportViewer.EnableDatabaseLogonPrompt = false; // 資料庫登入設定
            reportViewer.EnableParameterPrompt = false; // 報表參數設定
            reportViewer.HasCrystalLogo = false; // cr 公司圖示
            reportViewer.ToolPanelView = ToolPanelViewType.None; // 隱藏工具面版
            reportViewer.HasToggleGroupTreeButton = false; // 群組樹狀結構切換按鈕
            reportViewer.HasToggleParameterPanelButton = false; // 參數面版切換按鈕
            reportViewer.HasSearchButton = false; // 搜尋按鈕
            reportViewer.HasDrillUpButton = false; // 往上擷取
            reportViewer.HasZoomFactorList = false; // 縮放係數
            reportViewer.PrintMode = PrintMode.ActiveX;
            reportViewer.ReportSource = reportDataSet;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            report.Close();
            report.Dispose();
        }
    }
}