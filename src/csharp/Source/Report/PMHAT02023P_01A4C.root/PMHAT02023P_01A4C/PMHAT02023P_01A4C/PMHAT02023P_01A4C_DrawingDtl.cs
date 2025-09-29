//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMHAT02023P_01A4C_DrawingDtl帳票クラス
// プログラム概要   : 発注点設定マスタリスト帳票を生成する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// DrawingDetail帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 特になし</br>
    /// <br>Programmer	: 呉元嘯</br>
    /// <br>Date		: 2009.05.06</br>
    /// </remarks> 
    public partial class DrawingDetail : DataDynamics.ActiveReports.ActiveReport3
    {
        /// <summary>
        /// DrawingDetail帳票クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : DrawingDetail帳票クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.06</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
    }
}
