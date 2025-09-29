//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   仕入先総括マスタ一覧表 テンプレートクラス       //
//                  :   PMKAK09013P_01A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   FSI菅原　要                                     //
// Date             :   2012/09/07                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.                 //
//**********************************************************************//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using System.Collections.Specialized;
using System.Data;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 仕入先総括マスタ一覧表リストテンプレートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 仕入先総括マスタリストテンプレートクラス。</br>
    /// <br>Programmer	: FSI菅原　要</br>
    /// <br>Date		: 2012/09/07</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKAK09013P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 仕入先総括マスタマスタリストテンプレートクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 仕入先総括マスタマスタリストテンプレートクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: FSI菅原　要</br>
        /// <br>Date		: 2012/09/07</br>
        /// </remarks>
        public PMKAK09013P_01A4C()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        // 印刷件数用カウンタ
        private int _printCount;
        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;
        // 抽出条件	
        private StringCollection _extraConditions;
        // フッター出力区分	
        private int _pageFooterOutCode;
        // フッターメッセージ	
        private StringCollection _pageFooters;
        // 印刷情報クラス			
        private SFCMN06002C _printInfo;
        // ソート順			
        private string _pageHeaderSortOderTitle;
        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        // 総括拠点コード表示フラグ
        private bool _isSumSectionCd = true;

        // 総括仕入先コード表示フラグ
        private bool _isSumSupplierCd = true;

        // DataSource参照用
        DataTable _printDataTable;

        // 総括拠点コード比較用バッファ
        string _sumSectionCode;

        // 総括仕入先コード比較用バッファ
        int _sumSupplierCode;

        #endregion ■ Private Member

        #region ■ IPrintActiveReportTypeList メンバ
        #region ◆ Public Property
        /// <summary> ページヘッダソート順タイトル項目</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>ページヘッダソート順タイトル項目セットプロパティ </remarks> 
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]セットプロパティ </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary> 抽出条件ヘッダー項目</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>抽出条件ヘッダー項目セットプロパティ </remarks> 
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }

        /// <summary> フッター出力区分</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>フッター出力区分セットプロパティ </remarks> 
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }

        /// <summary> フッタ出力文</summary>
        /// <value>PageFooters</value>               
        /// <remarks>フッタ出力文セットプロパティ </remarks> 
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }

        /// <summary>印刷条件</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>印刷条件セットプロパティ </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
            }
        }

        /// <summary>その他データ</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>その他データセットプロパティ </remarks> 
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>サブヘッダタイトル</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>サブヘッダタイトルセットプロパティ </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }

        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region ■IPrintActiveReportTypeCommon メンバ
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
        #endregion ■IPrintActiveReportTypeCommon メンバ

        #region ■ Private Method
        #region ◆ レポート要素出力設定
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: FSI菅原　要</br>
        /// <br>Date		: 2012/09/07</br>
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = this._printInfo.prpnm;
        }

        #endregion ◆ レポート要素出力設定
        #endregion ■ Private Method

        #region ■ Control Event

        #region ◎ PMKAK09013P_01A4C_ReportStart Event
        /// <summary>
        /// PMKAK09013P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: FSI菅原　要</br>
        /// <br>Date		: 2012/09/07</br>
        /// </remarks>
        private void PMKAK09013P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();

            // 罫線の印字判定の為、DataSourceを取得
            DataView dv = (DataView)this.DataSource;
            _printDataTable = dv.Table;
            DataRow dr = _printDataTable.Rows[0];

            // 先頭レコードの総括拠点コード、総括仕入先コードを取得
            _sumSectionCode = (string)dr[PMKAK09015EA.ct_Col_SumSectionCd];
            _sumSupplierCode = (int)dr[PMKAK09015EA.ct_Col_SumSupplierCd];
        }
        #endregion

        #region ◎ PageHeader_Format Event
        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: FSI菅原　要</br>
        /// <br>Date		: 2012/09/07</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 作成日付
            DateTime now = DateTime.Now;
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.tb_PrintTime.Text = TDateTime.DateTimeToString("HH:MM", now);
            // ソート順表示もあればここで

            // 総括仕入先コード表示フラグを立てる
            this._isSumSupplierCd = true;
            // 総括拠点コード表示フラグを立てる
            this._isSumSectionCd = true;
        }
        #endregion

        #region ◎ ExtraHeader_Format Event
        /// <summary>
        /// ExtraHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ExtraHeaderグループのフォーマットイベント。</br>
        /// <br>Programmer	: FSI菅原　要</br>
        /// <br>Date		: 2012/09/07</br>
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

            // 抽出条件罫線印字判定
            if (this._extraConditions.Count > 0)
            {
                // 抽出条件が指定された場合は印字
                line6.Visible = true;
            }
            else
            {
                // 抽出条件未指定であれば印字せず
                line6.Visible = false;
            }
        }
        #endregion

        #region ◎ Detail_AfterPrint Event
        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: FSI菅原　要</br>
        /// <br>Date		: 2012/09/07</br>
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
        #endregion

        #region ◆ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : FSI菅原　要</br>                                   
        /// <br>Date        : 2012/09/07</br>                                       
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            #region [罫線の印字制御]

            // 罫線はDetailセクションに定義されている
            // 罫線として印字するのは、line4、line3、line2のlineコントロール
            //  line4:総括拠点コード、総括拠点名テキストボックスの下に印字
            //  line3:総括仕入先コード、総括仕入先名テキストボックスの下に印字
            //  line2:拠点コード～仕入先名テキストボックスの下に印字
            // 　　　 line2は常に印字する

            // line3、line4の印字制御
            if (_printCount == (_printDataTable.Rows.Count - 1))
            {
                // 印刷件数用カウンタがDataSourceの件数に到達したら、すべて印字
                line3.Visible = true;
                line4.Visible = true;
            }
            else
            {
                // Detailセクションに描画される次のデータをDataSourceから取得
                DataRow dr = _printDataTable.Rows[_printCount + 1];

                // line3の制御
                // 総括拠点コード、総括仕入先コードを取得し、変化するか確認
                int supplierCode = (int)dr[PMKAK09015EA.ct_Col_SumSupplierCd];
                string sectionCode = (string)dr[PMKAK09015EA.ct_Col_SumSectionCd];
                if (_sumSupplierCode != supplierCode)
                {
                    // 総括仕入先が変化する場合は、line3を印字
                    line3.Visible = true;

                    _sumSupplierCode = supplierCode;
                }
                else
                {
                    // 総括仕入先が変化しない場合は、さらに総括拠点が変化するか確認
                    if (_sumSectionCode != sectionCode)
                    {
                        // 総括拠点が変化する場合は、line3を印字
                        line3.Visible = true;
                    }
                    else
                    {
                        // 総括拠点も変化しない場合は、line3を印字しない
                        line3.Visible = false;
                    }
                }

                // line4の制御
                // 総括拠点が変化するか確認
                if (_sumSectionCode != sectionCode)
                {
                    // 総括拠点が変化する場合は、line4を印字
                    line4.Visible = true;

                    _sumSectionCode = sectionCode;
                }
                else
                {
                    // 総括拠点が変化しない場合は、line4を印字しない
                    line4.Visible = false;
                }
            }
            #endregion [罫線の印字制御]

            #region [総括拠点、総括仕入先印字制御]

            // 同じ総括拠点を表示させない対応
            if (this._isSumSectionCd)
            {
                // 次行は表示させない
                this._isSumSectionCd = false;
            }
            else
            {
                // 総括拠点コード、総括拠点名は空にする
                textBox_SumSectionCd.Text = string.Empty;
                textBox_SumSectionGuideSnm.Text = string.Empty;
            }

            // 同じ総括仕入先を表示させない対応
            if (this._isSumSupplierCd)
            {
                // 次行は表示させない
                this._isSumSupplierCd = false;
            }
            else
            {
                // 総括仕入先コード、総括仕入先名は空にする
                textBox_SumSupplierCd.Text = string.Empty;
                textBox_SumSupplierNm1.Text = string.Empty;
                textBox_SumSupplierNm2.Text = string.Empty;
            }

            #endregion [総括拠点、総括仕入先印字制御]

            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion ◆ Detail_BeforePrint Event

        #region ◆ groupHeader1_Format Event
        /// <summary>
        /// groupHeader1_Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : グループセクション(総括拠点コード)フォーマットイベントです。</br>
        /// <br>Programmer  : FSI菅原　要</br>                                   
        /// <br>Date        : 2012/09/07</br> 	
        /// </remarks>
        private void groupHeader1_Format(object sender, EventArgs e)
        {
            // 総括拠点コード表示フラグを立てる
            this._isSumSectionCd = true;

            // 総括仕入先コード表示フラグを立てる
            this._isSumSupplierCd = true;

        }
        #endregion ◆ groupHeader1_Format Event

        #region ◆ groupHeader2_Format Event
        /// <summary>
        /// groupHeader2_Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : グループセクション(総括仕入先コード)フォーマットイベントです。</br>
        /// <br>Programmer  : FSI菅原　要</br>                                   
        /// <br>Date        : 2012/09/07</br> 	
        /// </remarks>
        private void groupHeader2_Format(object sender, EventArgs e)
        {
            // 総括仕入先コード表示フラグを立てる
            this._isSumSupplierCd = true;
        }
        #endregion ◆ groupHeader2_Format Event

        #endregion ■ Control Event
    }
}
