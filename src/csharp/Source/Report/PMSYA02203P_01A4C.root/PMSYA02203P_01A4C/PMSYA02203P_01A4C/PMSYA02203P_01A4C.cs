//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷対応表
// プログラム概要   : 型式別出荷対応表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note : 2010.05.19 zhangsf Redmine #7784の対応
//             : ・型式別出荷対応表／各種修正
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
    /// PMSYA02203P_01A4C帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 特になし</br>
    /// <br>Programmer	: 王海立</br>
    /// <br>Date		: 2010/04/22</br>
    /// </remarks>
    public partial class PMSYA02203P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
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
        private ModelShipRsltListCndtn _extrInfo;

        // ページ
        private int page = 0;

        #endregion

        /// <summary>
        /// ProgressBarUpEvent
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>
        /// PMSYA02203P_01A4C帳票コンストラクタ
        /// </summary>
        public PMSYA02203P_01A4C()
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
        /// <br>Date		: 2010/04/22</br>
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
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void PMSYA02203P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Date		: 2010/04/22</br>
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
        /// <br>Date		: 2010/04/22</br>
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
                _extrInfo = (ModelShipRsltListCndtn)this._printInfo.jyoken;
            }
        }

        #endregion

        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/22</br>																
        /// </remarks>																
        private void SetOfReportMembersOutput()
        {
            // 改頁
            if ((int)this._extrInfo.NewPageDiv == 0)
            {
                FullModelHeader.NewPage = NewPage.None;
                SectionHeader.NewPage = NewPage.None;
            }
            else if ((int)this._extrInfo.NewPageDiv == 1)
            {
                //全社以外の場合
                if ((int)_extrInfo.GroupBySectionDiv != 0)
                {
                    FullModelHeader.NewPage = NewPage.None;
                    SectionHeader.NewPage = NewPage.Before;
                }
                else
                {
                    FullModelHeader.NewPage = NewPage.None;
                    SectionHeader.NewPage = NewPage.None;
                }
            }
            else
            {
                FullModelHeader.NewPage = NewPage.Before;
                SectionHeader.NewPage = NewPage.None;
            }
        }

        /// <summary>
        /// Detail_Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 明細セクションのフォーマットイベントです。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/22</br>		
        /// </remarks>
        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            DataView dv = this.DataSource as DataView;
            DataTable data = dv.Table;

            string bLGoodsCode = string.Empty;
            string makerCode = string.Empty;
            string resultsAddUpSecCdRF = string.Empty;
            string makerCodeRF = string.Empty;
            string modelCodeRF = string.Empty;
            string modelSubCodeRF = string.Empty;
            string fullModelRF = string.Empty;

            foreach (DataRow row in data.Rows)
            {
                if (page == this.PageNumber
                    && bLGoodsCode == (string)row["BLGoodsCodeRF"]
                    && makerCode == (string)row["GoodsMakerCd1RF"]
                    && resultsAddUpSecCdRF == (string)row["ResultsAddUpSecCdRF"]
                    && makerCodeRF == (string)row["MakerCodeRF"]
                    && modelCodeRF == (string)row["ModelCodeRF"]
                    && modelSubCodeRF == (string)row["ModelSubCodeRF"]
                    && fullModelRF == (string)row["FullModelRF"])
                {
                    row["BLGoodsCodeRF"] = string.Empty;
                    row["BLGoodsHalfNameRF"] = string.Empty;
                    row["GoodsMakerCd1RF"] = string.Empty;
                    row["GoodsMakerName1RF"] = string.Empty;
                }
                else
                {
                    bLGoodsCode = (string)row["BLGoodsCodeRF"];
                    makerCode = (string)row["GoodsMakerCd1RF"];
                    resultsAddUpSecCdRF = (string)row["ResultsAddUpSecCdRF"];
                    makerCodeRF = (string)row["MakerCodeRF"];
                    modelCodeRF = (string)row["ModelCodeRF"];
                    modelSubCodeRF = (string)row["ModelSubCodeRF"];
                    fullModelRF = (string)row["FullModelRF"];
                    page = this.PageNumber;
                }
            }
        }

        // ADD 2010.05.19 zhangsf FOR Redmine #7784 *-------------------->>>
        /// <summary>
        /// Detail_BeforePrint イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 明細セクションのフォーマットイベントです。</br>
        /// <br>Programmer : zhangsf</br>
        /// <br>Date       : 2010/05/19</br>		
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            if (detail==null)
                return;

            // メーカーコードの印字
            if (tb_GoodsMakerCd1.Text == "0000")
                tb_GoodsMakerCd1.Text = "";

            // 現在庫数の印字
            if (tb_SupplierStock.Text == "0.00")
            {
                // 印字判定フラグ
                bool blnNotprint = true;

                // 現在庫数印字条件判断
                if (_extraConditions != null && tb_WarehouseShelfNo.Text != null)
                {
                    if (tb_WarehouseShelfNo.Text.Trim() != "")
                    {
                        foreach (string strCdn in _extraConditions)
                        {
                            if (strCdn.IndexOf("倉庫") > 0)
                            {
                                blnNotprint = false;
                            }
                        }
                    }
                }
                // 印字しない
                if (blnNotprint)
                    tb_SupplierStock.Text = "";
            }
        }
        // ADD 2010.05.19 zhangsf FOR Redmine #7784 <<<--------------------*
    }
}
