using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Application.UIData;// ADD 2011/03/14
namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// MAKAU02020P_02A4C_DrawingDtl の概要の説明です。
    /// </summary>
    public partial class DrawingDetail : DataDynamics.ActiveReports.ActiveReport3
    {
        //---UPD 2011/03/14----->>>>>
        //public DrawingDetail()
        public DrawingDetail(ExtrInfo_DemandTotal dmdExtraInfo)
        //---UPD 2011/03/14----->>>>>
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();
            //---ADD 2011/03/14----->>>>>
            if (dmdExtraInfo.PrintBlLiDiv == 0)
            {
                this.textBox_null.Visible = true;
            }
            else
            {
                this.textBox_null.Visible = false;
            }
            //---ADD 2011/03/14-----<<<<<
        }

        /// <summary>
        /// 明細ビフォープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画される前に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // --- DEL m.suzuki 2011/04/07 ---------->>>>>
            //// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            //PrintCommonLibrary.ConvertReportString(this.Detail);
            // --- DEL m.suzuki 2011/04/07 ----------<<<<<
        }

    }
}
