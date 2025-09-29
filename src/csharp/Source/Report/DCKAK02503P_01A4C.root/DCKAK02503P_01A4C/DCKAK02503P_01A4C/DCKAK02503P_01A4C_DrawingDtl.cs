using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// DCKAK02503P_01A4C_DrawingDtl の概要の説明です。
    /// </summary>
    public partial class DrawingDetail : DataDynamics.ActiveReports.ActiveReport3
    {

        public DrawingDetail()
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();
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
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
    }
}
