//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書発行(総括)
// プログラム概要   : 請求書発行(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/06/08  修正内容 : 障害・改良対応７月リリース分 No.547対応
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
    /// PMHNB02254P_02A4C_DrawingDtl の概要の説明です。
    /// <br>Update Note : 2010/06/08 呉元嘯 障害・改良対応７月リリース分 No.547対応</br>
    /// </summary>
    public partial class DrawingDetail : DataDynamics.ActiveReports.ActiveReport3
    {
        // --------ADD 2010/06/08--------->>>>>
        // 総括得意先内訳
        private int _sumCustDtl;

        // 残高入金内訳
        private int _balanceDepositDtl;
        // --------ADD 2010/06/08---------<<<<<
        public DrawingDetail()
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();
        }

        /// <summary>
        /// アクセスクラスコンストラクター
        /// </summary>
        /// <param name="sumCustDtl">総括得意先内訳</param>
        /// <param name="balanceDepositDtl">残高入金内訳</param>
        /// <remarks>
        /// <br>Note       : アクセスクラスの新しいインスタンスを作成します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public DrawingDetail(int sumCustDtl, int balanceDepositDtl)
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();
            this._sumCustDtl = sumCustDtl;
            this._balanceDepositDtl = balanceDepositDtl;
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
            // --- DEL m.suzuki 2011/04/12 ---------->>>>>
            //// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            //PrintCommonLibrary.ConvertReportString(this.Detail);
            // --- DEL m.suzuki 2011/04/12 ----------<<<<<
        }

        /// <summary>
        /// レポートスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       :レポートの生成処理が開始されたときに発生します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DrawingDetail_ReportStart(object sender, EventArgs e)
        {
            // 総括得意先内訳と残高入金内訳が印字する場合
            if ((_sumCustDtl == 0) && (_balanceDepositDtl == 0))
            {
                AcpOdrTtl3TmBfBlDmd.Visible = true;//前々々回
                AcpOdrTtl2TmBfBlDmd.Visible = true;//前々回
                LastTimeDemand.Visible = true;//前回
                MoneyKindDiv101.Visible = true;//現金
                MoneyKindDiv102.Visible = true;//振込
                MoneyKindDiv107.Visible = true;//小切手
                MoneyKindDiv105.Visible = true;//手形
                MoneyKindDiv106.Visible = true;//相殺
                MoneyKindDiv109.Visible = true;//口座振替
                MoneyKindDiv112.Visible = true;//その他
                ThisTimeFeeDmdNrml.Visible = true;//手数料
                ThisTimeDisDmdNrml.Visible = true;//値引
            }
            else
            {
                AcpOdrTtl3TmBfBlDmd.Visible = false;//前々々回
                AcpOdrTtl2TmBfBlDmd.Visible = false;//前々回
                LastTimeDemand.Visible = false;//前回
                MoneyKindDiv101.Visible = false;//現金
                MoneyKindDiv102.Visible = false;//振込
                MoneyKindDiv107.Visible = false;//小切手
                MoneyKindDiv105.Visible = false;//手形
                MoneyKindDiv106.Visible = false;//相殺
                MoneyKindDiv109.Visible = false;//口座振替
                MoneyKindDiv112.Visible = false;//その他
                ThisTimeFeeDmdNrml.Visible = false;//手数料
                ThisTimeDisDmdNrml.Visible = false;//値引
            }
        }

    }
}
