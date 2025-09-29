//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMHAT02023P_01A4C帳票クラス
// プログラム概要   : 発注点設定マスタリスト帳票を生成する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
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
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using System.Collections.Specialized;
using Broadleaf.Application.UIData;
using System.Data;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMHAT02023P_01A4C帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 特になし</br>
    /// <br>Programmer	: 呉元嘯</br>
    /// <br>Date		: 2009.04.14</br>
    /// </remarks> 
    public partial class PMHAT02023P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {
        #region ■Constructor
        /// <summary>
        /// 発注点設定マスタリスト印刷帳票ActiveReportクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタリスト印刷帳票ActiveReportクラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public PMHAT02023P_01A4C()
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();

            // 内訳抽出用カウンタ
            this._outputCnt = 0;

        }
        #endregion　■Constructor

        #region  ■Private Members
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

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 文字列TOP
        private const string STR_TOP = "TOP";

        // 文字列END
        private const string STR_END = "END";

        // 抽出条件クラス
        OrderSetMasListPara _orderSetMasListPara = null;

        // ヘッダーサブレポート作成
        ListCommon_ExtraHeader _rptExtraHeader = new ListCommon_ExtraHeader();

        // 取得した印刷DataSet
        private DataSet _outputDs;

        // 印刷用DataSet
        private DataSet mergedDatSet;

        // 内訳抽出用カウンタ	
        private int _outputCnt;

        // 設定コード
        private string rowKey = string.Empty;

        // サブレポート用レポートクラス宣言
        DrawingDetail _rptDrawingDetail = null;

        // 発注点設定マスタテーブル名称
        private const string ct_OrderSetMasListTable = PMHAT02025EA.Tbl_OrderSetMasListReportData;
        #endregion　■Private Members

        #region ■ IPrintActiveReportTypeList メンバ
        #region ◆ Public Property

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

        /// <summary>サブヘッダタイトル</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>サブヘッダタイトルセットプロパティ </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }

        /// <summary>印刷条件</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>印刷条件セットプロパティ </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                //画面から抽出条件を取得する
                this._orderSetMasListPara = (OrderSetMasListPara)this._printInfo.jyoken;
                // DataSet
                this._outputDs = (DataSet)this._printInfo.rdData;

                MergeDateSet(_outputDs, out mergedDatSet);

                this._printInfo.rdData = this.mergedDatSet;

            }
        }

        /// <summary>プログレスバーカウントアップイベント
        /// <value>ProgressBarUpEventHandler</value>               
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region ■ IPrintActiveReportTypeCommon メンバ
        #region ◆ Public Property
        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ■ Private Method
        #region ◆ 印刷用内訳データを取得
        /// <summary>
        /// 発注点設定マスタ内訳データの取得
        /// </summary>
        /// <remarks>
        /// <br>Note        : 発注点設定マスタ内訳データを取得します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.06</br>
        /// </remarks>
        private DataView GetDrawingData()
        {
            DataRowView outputDr = null;
            DataView dr = null;

            // 現在印刷している行を取得
            outputDr = this.mergedDatSet.Tables[0].DefaultView[this._outputCnt];
            // 今回レコードの設定コードを取得
            string tempKey = outputDr[PMHAT02025EA.Col_SetCode].ToString();
            string sort = string.Empty;
            string filter = string.Empty;

            //　第一条レコード又は重複設定コードではない場合
            if (rowKey == string.Empty || rowKey != tempKey)
            {
                this._outputCnt++;

                // フィルタ条件
                filter = String.Format("{0} = '{1}'",
                            PMHAT02025EA.Col_SetCode,
                            outputDr[PMHAT02025EA.Col_SetCode]);

                // ソート順
                sort = PMHAT02025EA.Col_SetCode + " ASC,"
                     + PMHAT02025EA.Col_PatternNoDerivedNoRF + " ASC ";

                dr = new DataView(this._outputDs.Tables[ct_OrderSetMasListTable], filter, sort, DataViewRowState.CurrentRows);
                int count = this._outputDs.Tables[ct_OrderSetMasListTable].DefaultView.Count;

                // 今回レコードのキーを保存
                rowKey = tempKey;
            }
            //重複設定コードの場合
            else
            {
                // フィルタ条件
                filter = String.Format("{0} = '{1}'",
                            PMHAT02025EA.Col_SetCode,
                            outputDr[PMHAT02025EA.Col_SetCode]);

                // ソート順
                sort = PMHAT02025EA.Col_SetCode + " ASC,"
                     + PMHAT02025EA.Col_PatternNoDerivedNoRF + " ASC ";

                dr = new DataView(this._outputDs.Tables[ct_OrderSetMasListTable], filter, sort, DataViewRowState.CurrentRows);
            }

            return dr;
        }
        #endregion ◆ GetDrawingData

        #region ◆ 印刷用データを取得
        /// <summary>
        /// 発注点設定マスタ印刷用データの取得
        /// </summary>
        /// <param name="outputDs">取得した印刷データ</param>
        /// <param name="cloneSet">印刷用データ</param>
        /// <remarks>
        /// <br>Note        : 発注点設定マスタ印刷用データを取得します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.06</br>
        /// </remarks>
        private void MergeDateSet(DataSet outputDs, out DataSet cloneSet)
        {
            // 総レコード
            int sum = outputDs.Tables[ct_OrderSetMasListTable].DefaultView.Count;
            // 印刷用データ
            cloneSet = outputDs.Clone();
            // 臨時設定コード値
            string currKey = string.Empty;
            // 印刷用データ 
            DataTable dt = cloneSet.Tables[0];
            // 検索キーを設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[PMHAT02025EA.Col_SetCode] };

            dt.Clear();
            //  設定コードをキーに、重複設定コードのレコードを濾過
            for (int i = 0; i < sum; i++)
            {
                DataRow dr = outputDs.Tables[ct_OrderSetMasListTable].Rows[i];
                // 当用レコードの設定コードを保存
                string key = dr[PMHAT02025EA.Col_SetCode].ToString();
                // 当用設定コードと先レコードは等しい場合
                if (currKey == key) { continue; }

                DataRow foundRow = dt.Rows.Find(key);
                if (foundRow == null)
                {
                    DataRow newDr = null;
                    newDr = dt.NewRow();
                    // 設定コード
                    newDr[PMHAT02025EA.Col_SetCode] = dr[PMHAT02025EA.Col_SetCode];
                    // 倉庫コード
                    newDr[PMHAT02025EA.Col_WarehouseCodeRF] = dr[PMHAT02025EA.Col_WarehouseCodeRF];
                    // 倉庫名称
                    newDr[PMHAT02025EA.Col_WarehouseNameRF] = dr[PMHAT02025EA.Col_WarehouseNameRF];
                    // 仕入先コード
                    newDr[PMHAT02025EA.Col_SupplierCdRF] = dr[PMHAT02025EA.Col_SupplierCdRF];
                    // 仕入先名称
                    newDr[PMHAT02025EA.Col_SupplierNameRF] = dr[PMHAT02025EA.Col_SupplierNameRF];
                    // メーカーコード
                    newDr[PMHAT02025EA.Col_GoodsMakerCdRF] = dr[PMHAT02025EA.Col_GoodsMakerCdRF];
                    // メーカー名称
                    newDr[PMHAT02025EA.Col_GoodsMakerNameRF] = dr[PMHAT02025EA.Col_GoodsMakerNameRF];
                    // 中分類コード
                    newDr[PMHAT02025EA.Col_GoodsMGroupCdRF] = dr[PMHAT02025EA.Col_GoodsMGroupCdRF];
                    // 中分類名称
                    newDr[PMHAT02025EA.Col_GoodsMGroupNameRF] = dr[PMHAT02025EA.Col_GoodsMGroupNameRF];
                    // BLグループコード
                    newDr[PMHAT02025EA.Col_BLGroupCodeRF] = dr[PMHAT02025EA.Col_BLGroupCodeRF];
                    // BLグループ名称
                    newDr[PMHAT02025EA.Col_BLGroupNameRF] = dr[PMHAT02025EA.Col_BLGroupNameRF];
                    // BL商品コード
                    newDr[PMHAT02025EA.Col_BLGoodsCodeRF] = dr[PMHAT02025EA.Col_BLGoodsCodeRF];
                    // BL商品コード名称
                    newDr[PMHAT02025EA.Col_BLGoodsNameRF] = dr[PMHAT02025EA.Col_BLGoodsNameRF];
                    // 在庫出荷対象開始月
                    newDr[PMHAT02025EA.Col_StckShipMonthStRF] = dr[PMHAT02025EA.Col_StckShipMonthStRF];
                    // 在庫出荷対象終了月
                    newDr[PMHAT02025EA.Col_StckShipMonthEdRF] = dr[PMHAT02025EA.Col_StckShipMonthEdRF];
                    // 在庫登録日
                    newDr[PMHAT02025EA.Col_StockCreateDateRF] = dr[PMHAT02025EA.Col_StockCreateDateRF];
                    // 区分
                    newDr[PMHAT02025EA.Col_OrderApplyDivRF] = dr[PMHAT02025EA.Col_OrderApplyDivRF];
                    currKey = key;
                    dt.Rows.Add(newDr);
                }

            }

        }
        #endregion ◆ MergeDateSet
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ Detail_AfterPrint Event
        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.31</br>                                       
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
        #endregion ◆ Detail_AfterPrint Event

        #region ◆ ExtraHeader_Format Event
        /// <summary>
        /// 抽出データフォーマット処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 抽出データフォーマットを処理します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.31</br>                                       
        /// </remarks>
        private void ExtraHeader_Format(object sender, EventArgs e)
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
        #endregion　◆ ExtraHeader_Format Event

        #region ◆ PageHeader_Format Event
        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.04.14</br>                                       
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs e)
        {
            //現在の時刻を取得
            DateTime now = DateTime.Now;
            // 作成日付
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // 作成時間
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);
        }
        #endregion　◆ PageHeader_Format Event

        #region ◆ Detail_Format Event
        /// <summary>
        /// 明細フォーマットイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.05.06</br>                                       
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // 発注点設定マスタ内訳データ
            DataView dr = this.GetDrawingData();
            if (dr != null)
            {
                if (dr.Count > 0)
                {
                    // サブレポートのVisibleセット
                    DrawingDetail_SubReport.Visible = true;

                    // インスタンスが作成されていなければ作成
                    if (_rptDrawingDetail == null)
                    {
                        _rptDrawingDetail = new DrawingDetail();
                    }
                    else
                    {
                        // インスタンスが作成されていれば、データソースを初期化する
                        // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない)
                        _rptDrawingDetail.DataSource = null;
                    }

                    // データソースの設定
                    _rptDrawingDetail.DataSource = dr;      // バインドするデータをセット
                    // サブレポートにデータをセット
                    DrawingDetail_SubReport.Report = _rptDrawingDetail;
                }
                else
                {
                    // サブレポートのVisibleセット
                    DrawingDetail_SubReport.Visible = false;
                }

            }
        }
        #endregion ◆ Detail_Format Event

        #region ◆ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.05.06</br>                                       
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion ◆ Detail_BeforePrint Event

        #endregion ■ Control Event

    }
}
