//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 買掛残高一覧表(総括) サブレポート
// プログラム概要   : 買掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI冨樫 紗由里
// 作 成 日  2012/09/14  修正内容 : 新規作成 仕入総括機能(個別)対応
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
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMKAK02023P_01A4C_DrawingDtl の概要の説明です。
    /// </summary>
    public partial class DrawingDetail : DataDynamics.ActiveReports.ActiveReport3
    {
        /// <summary>拠点締チェック</summary>
        public bool _monAddUpNonProc;
        private int _newPageType;

        /// <summary>
        /// 明細作成
        /// </summary>
        /// <param name="sumAccPaymentListCndtn"></param>
        public DrawingDetail(SumAccPaymentListCndtn sumAccPaymentListCndtn)
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();

            // 支払内訳
            if (sumAccPaymentListCndtn.PayDtlDiv == 1)
            {
                // 印字しない
                // 明細行
                CashPayment.Visible = false;
                TrfrPayment.Visible = false;
                CheckPayment.Visible = false;
                DraftPayment.Visible = false;
                OffsetPayment.Visible = false;
                FundTransferPayment.Visible = false;
                OthsPayment.Visible = false;
                ThisTimeFeePayNrml.Visible = false;
                ThisTimeDisPayNrml.Visible = false;

                this.Detail.Height = 0.115F;
            }

            // 改ページ有無の値をセット
            this._newPageType = sumAccPaymentListCndtn.NewPageType;
            _monAddUpNonProc = false;
        }

        /// <summary>
        /// 明細ビフォープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画される前に発生します。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // 文字が途切れる対応(設定に応じてCanShrinkをセット)
            if (this._newPageType != 1)
            {
                // 改ページしない以外は、メインレポートの月次計上有無値をセット
                this.Detail.CanShrink = !this._monAddUpNonProc;
            }
            else
            {
                // 改ページしない場合はCanShrinkをtrue
                this.Detail.CanShrink = true;
            }

            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
    }
}
