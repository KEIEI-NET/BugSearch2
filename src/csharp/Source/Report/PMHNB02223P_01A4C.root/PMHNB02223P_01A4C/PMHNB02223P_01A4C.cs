//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上不整合確認表
// プログラム概要   : 売上不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{

    /// <summary>
    /// 売上不整合確認表デザインクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上不整合確認表デザインクラスの概要の説明を行います。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.10</br>
    /// </remarks>
    public partial class PMHNB02223P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {

        //================================================================================
        //  Constructor
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 売上不整合確認表印刷帳票ActiveReportクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上不整合確認表印刷帳票ActiveReportクラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public PMHNB02223P_01A4C()
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();
        }
        #endregion

        //================================================================================
        //  内部変数
        //================================================================================
        #region private member
        // 拠点表示有無
        private bool _isSection;

        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;

        // ソート順タイトル
        private string _pageHeaderSortOderTitle;

        // 抽出条件印字項目
        private StringCollection _extraConditions;

        // フッター出力有無
        private int _pageFooterOutCode;

        // フッタメッセージ1
        private StringCollection _pageFooters;

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 関連データオブジェクト
        private ArrayList _otherDataList;

        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        // 印刷件数
        private int _printCount = 1;

        // 抽出条件クラス
        private SalesStockInfoMainCndtn _extrInfo;

        #endregion

        //================================================================================
        //  プロパティ
        //================================================================================
        #region public property

        #region IPrintActiveReportTypeList メンバ
        /// <summary> ページヘッダソート順タイトル項目</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>ページヘッダソート順タイトル項目セットプロパティ </remarks> 
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]セットプロパティ </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary> 抽出条件ヘッダー項目</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>抽出条件ヘッダー項目セットプロパティ </remarks> 
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }

        /// <summary> フッター出力区分</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>フッター出力区分セットプロパティ </remarks> 
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary> フッタ出力文</summary>
        /// <value>PageFooters</value>               
        /// <remarks>フッタ出力文セットプロパティ </remarks> 
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary>印刷条件</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>印刷条件セットプロパティ </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._extrInfo = (SalesStockInfoMainCndtn)this._printInfo.jyoken;
            }
        }

        /// <summary>その他データ</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>その他データセットプロパティ </remarks> 
        public ArrayList OtherDataList
        {
            set
            {
                this._otherDataList = value;
                if (this._otherDataList != null)
                {
                    if (this._otherDataList.Count > 0)
                    {
                        this._isSection = (bool)this._otherDataList[0];
                    }
                }
            }
        }

        /// <summary>サブヘッダタイトル</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>サブヘッダタイトルセットプロパティ </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }
        #endregion

        #region IPrintActiveReportTypeCommon メンバ
        /// <summary>プログレスバーカウントアップイベント</summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        /// <remarks>背景透かしモードセット又は取得プロパティ </remarks> 
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }
        #endregion
        #endregion

        //================================================================================
        //  イベント
        //================================================================================
        #region event
        /// <summary>
        /// レポートスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private void PMHNB02223P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // 印刷件数初期化
            this._printCount = 0;

        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private void pageHeader_Format(object sender, System.EventArgs eArgs)
        {

            //// ソート順
            this.SORTTITLE.Text = this._pageHeaderSortOderTitle;

            // 作成日付
            DateTime now = DateTime.Now;
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // 作成時間
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);
        }

        /// <summary>
        /// 拠点ヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {

            // ヘッダ出力制御
            if (this._extraCondHeadOutDiv == 0)
            {
                // 毎ページ出力
                this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;

            }
            else
            {
                // 先頭ページのみ
                this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            }
            // ヘッダーサブレポート作成
            ListCommon_ExtraHeader rpt = new ListCommon_ExtraHeader();

            // 抽出条件印字項目設定
            rpt.ExtraConditions = this._extraConditions;

            this.Extra_SubReport.Report = rpt;

        }


        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 汪千来</br>
        /// <br>Date        : 2009.04.10</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        #region Detail_Formatイベント
        /// <summary>
        /// 罫線表示非表示制御処理　Detail_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : lineをvisibleかどうか。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            if (lineFlag.Text.Equals("true") || lineFlag.Text.Equals("True"))
            {
                this.line5.Visible = true;
            }
            else
            {
                this.line5.Visible = false;
            }
        }
        #endregion

        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }

        #endregion

        // ===============================================================================
        // ActiveReportsデザイナで生成されたコード
        // ===============================================================================
        #region ActiveReports Designer generated code
        #endregion

    }
}
