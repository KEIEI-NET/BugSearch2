//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMKAK02003P_01A4C_DrawingDtl の概要の説明です。
    /// </summary>
    public partial class DrawingDetail : DataDynamics.ActiveReports.ActiveReport3
    {
        /// <summary>
        /// 支払一覧表（総括）DrawingDetailクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 支払一覧表（総括）DrawingDetailクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        public DrawingDetail(SumSuplierPayMainCndtn sumSuplierPayMainCndtn)
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();

            if (sumSuplierPayMainCndtn.BalancePayeeDetail == 1)
            {
                // 残高支払内訳を印字しない
                // 明細
                StockTtl3TmBfBlPay.Visible = false;
                StockTtl2TmBfBlPay.Visible = false;
                LastTimePayment.Visible = false;
                CashPayment.Visible = false;
                TrfrPayment.Visible = false;
                CheckPayment.Visible = false;
                DraftPayment.Visible = false;
                OffsetPayment.Visible = false;
                OthsPayment.Visible = false;
                FundTransferPayment.Visible = false;
                ThisTimeFeePayNrml.Visible = false;
                ThisTimeDisPayNrml.Visible = false;
            }
        }

        /// <summary>
        /// 明細ビフォープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : セクションがページに描画される前に発生します。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012.09.08</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
    }
}
