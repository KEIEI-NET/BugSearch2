//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ
// プログラム概要   : 自由検索型式マスタ帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMJKN02003P_01A4C帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 特になし</br>
    /// <br>Programmer	: 王海立</br>
    /// <br>Date		: 2010/04/27</br>
    /// </remarks>
    public partial class PMJKN02003P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {
        #region Private Members
        // 印刷件数
        private int _printCount = 0;

        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;

        // 関連データオブジェクト
        private ArrayList _otherDataList;

        // 抽出条件印字項目
        private StringCollection _extraConditions;

        // 拠点表示有無
        private bool _isSection;

        // フッター出力有無
        private int _pageFooterOutCode;

        // フッタメッセージ1
        private StringCollection _pageFooters;

        // ソート順タイトル
        private string _pageHeaderSortOderTitle;

        // Extra SubReport
        ListCommon_ExtraHeader _rptExtraHeader = new ListCommon_ExtraHeader();

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 表示条件クラス
        private FreeSearchModelPrint _extrInfo;

        #endregion

        /// <summary>
        /// ProgressBarUpEvent
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>
        /// PMJKN02003P_01A4C帳票コンストラクタ
        /// </summary>
        public PMJKN02003P_01A4C()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
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

        /// <summary>
        /// レポートスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private void PMJKN02003P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // レポート要素出力設定	
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs eArgs)
        {
            // 作成日付
            DateTime now = DateTime.Now;
            this.tb_PrintDate.Text = now.ToString("yyyy/MM/dd");
            this.tb_PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// 抽出データフォーマット処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 抽出データフォーマットを処理します。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 抽出条件設定
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

            // インスタンスが作成されていなければ作成
            if (this._rptExtraHeader == null)
            {
                this._rptExtraHeader = new ListCommon_ExtraHeader();
            }
            else
            {
                // インスタンスが作成されていれば、データソースを初期化する
                // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                this._rptExtraHeader.DataSource = null;
            }

            // 抽出条件印字項目設定
            this._rptExtraHeader.ExtraConditions = this._extraConditions;

            this.Header_SubReport.Report = this._rptExtraHeader;
        }

        #region IPrintActiveReportTypeCommon メンバ

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }

        #endregion

        #region IPrintActiveReportTypeList メンバ

        /// <summary>
        /// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary>
        /// 抽出条件ヘッダー項目
        /// </summary>
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }

        /// <summary>
        /// その他データ
        /// </summary>
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

        /// <summary>
        /// フッター出力区分
        /// </summary>
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary>
        /// フッタ出力文
        /// </summary>
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary>
        /// ページヘッダソート順タイトル項目
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { }
        }

        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                _extrInfo = (FreeSearchModelPrint)this._printInfo.jyoken;
            }
        }

        #endregion

        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>																
        /// </remarks>																
        private void SetOfReportMembersOutput()
        {
            // 改頁
            if ((int)this._extrInfo.NewPageDiv == 0)
            {
                CarModelHeader.NewPage = NewPage.None;
            }
            else if ((int)this._extrInfo.NewPageDiv == 1)
            {
                CarModelHeader.NewPage = NewPage.Before;
            }
        }        
    }
}
