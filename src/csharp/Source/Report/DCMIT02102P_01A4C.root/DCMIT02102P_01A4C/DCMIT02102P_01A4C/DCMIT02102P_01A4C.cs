//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 見積確認表
// プログラム概要   : 見積確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木　正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/10/06  修正内容 : 帳票レイアウトのみ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/02  修正内容 : 障害対応10579(見積残数追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/13  修正内容 : 障害対応10579(見積残数ラベルの名称修正。出荷数項目を受注数に修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/02  修正内容 : 障害対応10232
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13153
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/07  修正内容 : MANTIS【13231】改頁時の拠点出力不具合を修正
//                                : 車種と型式を全角文字切れ(WordWrap)を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2013/11/15  修正内容 : システムテスト一覧№37対応（仕掛一覧 №2119）
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 作 成 日  2014/01/10  修正内容 : 行値引出力後に商品値引の数量・金額が出力されない障害を修正
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 見積確認表印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 見積確認表のフォームクラスです。</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2007.09.19</br>
    /// <br></br>
    /// <br>UpdateNote   :</br>
    /// <br>Programmer   : 980035 金沢 貞義</br>
    /// <br>Date         : 2008.10.06 帳票レイアウトのみ変更</br>
    /// <br>             :</br>
    /// <br>UpdateNote   :</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2009.02.02 障害対応10579(見積残数追加)</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2009.02.13 障害対応10579(見積残数ラベルの名称修正。出荷数項目を受注数に修正)</br>
    /// <br>UpdateNote   : 2009/04/02 30452 上野 俊治</br>
    /// <br>             : 障害対応10232</br>
    /// <br>UpdateNote   : 2009/04/07 30452 上野 俊治</br>
    /// <br>             : 障害対応13153</br>
    /// </remarks>
    public class DCMIT02102P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 見積確認表フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note         : 見積確認表フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 22018　鈴木　正臣</br>
        /// <br>Date         : 2007.09.19</br>
        /// </remarks>
        public DCMIT02102P_01A4C ()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        # region ■ Private enum
        /// <summary>
        /// 売上伝票区分(明細)
        /// </summary>
        private enum SalesSlipCdDtlState
        {
            /// <summary>売上</summary>
            Sales = 0,
            /// <summary>返品</summary>
            Return = 1,
            /// <summary>値引</summary>
            Discount = 2,
            /// <summary>注釈</summary>
            Notice = 3,
            /// <summary>小計</summary>
            Sum = 4,
        }
        # endregion

        #region ■ Private Member
        private int _printCount;									// 印刷件数用カウンタ

        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;				// 抽出条件
        private int _pageFooterOutCode;				// フッター出力区分
        private StringCollection _pageFooters;					// フッターメッセージ
        private SFCMN06002C _printInfo;						// 印刷情報クラス
        private string _pageHeaderTitle;				// フォームタイトル
        private string _pageHeaderSortOderTitle;		// ソート順

        private EstimateListCndtn _estimateListCndtn;				// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Line line4;
        private Line Line;
        private TextBox SlipMemo1;
        private TextBox SlipMemo2;
        private TextBox SlipMemo3;
        private TextBox InsideMemo2;
        private TextBox InsideMemo3;
        private TextBox InsideMemo1;
        private Label Lb_SlipMemo1;
        private Label Lb_SlipMemo2;
        private Label Lb_SlipMemo3;
        private Label Lb_InsideMemo1;
        private Label Lb_InsideMemo2;
        private Label Lb_InsideMemo3;
        private TextBox Extraction;
        private TextBox textBox12;
        private TextBox textBox48;
        private Line line17;
        private Label label8;
        private Label Label26;
        private Label Label6;
        private Label label19;
        private Label label23;
        private Label label12;
        private Label label24;
        private Label label28;
        private Label label38;
        private Label label16;
        private Label label17;
        private Label label1;
        private Label label20;
        private Label label35;
        private Label label48;
        private Label label4;
        private Label Label9;
        private Label Label13;
        private Label Label29;
        private Label Label31;
        private Label label25;
        private Label label36;
        private Label label27;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label42;
        private TextBox ModelFullName;
        private TextBox CategoryDtl;
        private TextBox FullModel;
        private TextBox CarMngCode;
        private TextBox FirstEntryDate;
        private TextBox SlipNote;
        private TextBox SlipNote2;
        private TextBox CustomerCode;
        private TextBox SalesSlipNum;
        private TextBox CustomerSnm;
        private TextBox SalesDate;
        private TextBox EstimateValidityDate;
        private TextBox SalesEmployeeNm;
        private TextBox SearchSlipDate;
        private TextBox EstimateFormNo;
        private TextBox EstimateDivideNm;
        private TextBox SalesCode;
        private TextBox BLGoodsCode;
        private TextBox GoodsNo;
        private TextBox GoodsName;
        private TextBox ListPriceTaxExcFl;
        private TextBox ShipmentCnt;
        private TextBox SalesUnitCost;
        private TextBox SalesUnPrcTaxExcFl;
        private TextBox SalesMoneyTaxExc;
        private TextBox SupplierCd;
        private TextBox WarehouseName;
        private TextBox SlipNote3;
        private TextBox SalesSlipCdDtl;
        private Label label5;
        private TextBox AcptAnOdrRemainCnt;
        private Label label7;
        private GroupHeader SalesDateHeader;
        private GroupFooter SalesDateFooter;
        private TextBox textBox1;
        private Line line3;
        private TextBox Sal_SalesMoneyTaxExc;
        private Line line5;
        private TextBox AutoAnswerDivSCMRF;
        private TextBox AcceptOrOrderKindRF;
        private Label label10;
        private Label label11;

        // Disposeチェック用フラグ
        bool disposed = false;

        #endregion ■ Private Member

        #region ■ Dispose(override)
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose ( bool disposing )
        {
            if ( !this.disposed ) {
                try {
                    if ( disposing ) {
                        // ヘッダ用サブレポート後処理実行
                        if ( this._rptExtraHeader != null ) {
                            this._rptExtraHeader.Dispose();
                        }

                        // フッタ用サブレポート後処理実行
                        if ( this._rptPageFooter != null ) {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this.disposed = true;
                }
                finally {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion ■ Dispose(override)

        #region ■ IPrintActiveReportTypeList メンバ
        #region ◆ Public Property
        /// <summary>
        /// ページヘッダソート順タイトル項目
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary>
        /// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary>
        /// 抽出条件ヘッダー項目
        /// </summary>
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }

        /// <summary>
        /// フッター出力区分
        /// </summary>
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }

        /// <summary>
        /// フッタ出力文
        /// </summary>
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }

        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._estimateListCndtn = ( EstimateListCndtn ) this._printInfo.jyoken;
            }
        }

        /// <summary>
        /// その他データ
        /// </summary>
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>
        /// 帳票サブタイトル
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderTitle = value; }
        }

        /// <summary>
        /// 印刷件数カウントアップイベント
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region ■ IPrintActiveReportTypeCommon メンバ
        #region ◆ Public Property
        /// <summary>
        /// 背景透過設定値プロパティ
        /// </summary>
        public int WatermarkMode
        {
            get
            {
                // TODO:  DCZAI02103P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  DCZAI02103P_01A4C.WatermarkMode setter 実装を追加します。
            }
        }
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ■ Private Method
        #region ◆ レポート要素出力設定
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void SetOfReportMembersOutput ()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。


            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._estimateListCndtn.IsOptSection ) {
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._estimateListCndtn.SectionCodes.Length < 2 ) ||
            //        this._estimateListCndtn.IsSelectAllSection ) {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else {
            //        SectionHeader.DataField = DCZAI02145EA.ct_Col_Sort_SectionCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else {
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}

            // 2008.08.06 30413 犬飼 改頁制御の追加 >>>>>>START
            // 改頁設定
            if (this._estimateListCndtn.NewPageType == 0)
            {
                // 拠点毎
                this.SectionHeader.NewPage = NewPage.Before;
            }
            else
            {
                // 改ページしない
                this.SectionHeader.NewPage = NewPage.None;
            }
            // 2008.08.06 30413 犬飼 改頁制御の追加 <<<<<<END

            // メモ印刷有無区分により、タイトル印字有無を制御
            if ( this._estimateListCndtn.MemoPrintDiv == EstimateListCndtn.MemoPrintDivState.Print )
            {
                // メモ印刷する
                this.Lb_SlipMemo1.Visible = true;
                this.Lb_SlipMemo2.Visible = true;
                this.Lb_SlipMemo3.Visible = true;
                // 2008.08.01 30413 犬飼 項目削除 >>>>>>START
                //this.Lb_SlipMemo4.Visible = true;
                //this.Lb_SlipMemo5.Visible = true;
                //this.Lb_SlipMemo6.Visible = true;
                // 2008.08.01 30413 犬飼 項目削除 <<<<<<END
                this.Lb_InsideMemo1.Visible = true;
                this.Lb_InsideMemo2.Visible = true;
                this.Lb_InsideMemo3.Visible = true;
                // 2008.08.01 30413 犬飼 項目削除 >>>>>>START
                //this.Lb_InsideMemo4.Visible = true;
                //this.Lb_InsideMemo5.Visible = true;
                //this.Lb_InsideMemo6.Visible = true;
                // 2008.08.01 30413 犬飼 項目削除 <<<<<<END
            }
            else
            {
                // メモ印刷しない
                this.Lb_SlipMemo1.Visible = false;
                this.Lb_SlipMemo2.Visible = false;
                this.Lb_SlipMemo3.Visible = false;
                // 2008.08.01 30413 犬飼 項目削除 >>>>>>START
                //this.Lb_SlipMemo4.Visible = false;
                //this.Lb_SlipMemo5.Visible = false;
                //this.Lb_SlipMemo6.Visible = false;
                // 2008.08.01 30413 犬飼 項目削除 <<<<<<END
                this.Lb_InsideMemo1.Visible = false;
                this.Lb_InsideMemo2.Visible = false;
                this.Lb_InsideMemo3.Visible = false;
                // 2008.08.01 30413 犬飼 項目削除 >>>>>>START
                //this.Lb_InsideMemo4.Visible = false;
                //this.Lb_InsideMemo5.Visible = false;
                //this.Lb_InsideMemo6.Visible = false;
                // 2008.08.01 30413 犬飼 項目削除 <<<<<<END
            }

            // --- ADD 2009/04/01 -------------------------------->>>>>
            // 日計印字
            if (this._estimateListCndtn.PrintDailyFooter == 0)
            {
                this.SalesDateFooter.Visible = false;
            }
            else
            {
                this.SalesDateFooter.Visible = true;
            }
            // --- ADD 2009/04/01 --------------------------------<<<<<
        }
        /// <summary>
        /// 範囲月数の取得処理
        /// </summary>
        /// <returns>範囲月数（ex.４月～６月ならば３）</returns>
        private int GetMonthRange ( DateTime stYearMonth, DateTime edYearMonth )
        {
            int stMonth = stYearMonth.Month;
            int edMonth = edYearMonth.Month;

            if ( edYearMonth.Year > stYearMonth.Year ) {
                edMonth += 12;
            }

            return ( edMonth - stMonth + 1 );
        }
        /// <summary>
        /// 月タイトル取得
        /// </summary>
        /// <param name="stYearMonth"></param>
        /// <param name="index"></param>
        /// <returns>月タイトル(ex.１月,２月…)</returns>
        private string GetMonthTitle ( DateTime stYearMonth, int index )
        {
            int month = stYearMonth.Month + index;

            if ( month > 12 ) month -= 12;

            return ( month.ToString() + "月" );
        }
        #endregion ◆ レポート要素出力設定


        #region ◆ グループサプレス関係
        #region ◎ グループサプレス判断
        /// <summary>
        /// グループサプレス判断
        /// </summary>
        private void CheckGroupSuppression ()
        {
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。
        }
        #endregion
        #endregion
        #endregion

        #region ■ Control Event

        #region ◎ DCMIT02102P_01A4C_ReportStart Event
        /// <summary>
        /// DCMIT02102P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCMIT02102P_01A4C_ReportStart ( object sender, System.EventArgs eArgs )
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ◎ DCMIT02102P_01A4C_PageEnd Event
        /// <summary>
        /// DCMIT02102P_01A4C_PageEnd Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DCZAI02103P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCMIT02102P_01A4C_PageEnd ( object sender, System.EventArgs eArgs )
        {
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void PageHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString(EstimateListCndtn.ct_DateFomat, DateTime.Now);
            // 作成時間
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");

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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void ExtraHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 抽出条件設定
            // ヘッダ出力制御
            if ( this._extraCondHeadOutDiv == 0 ) {
                // 毎ページ出力
                this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else {
                // 先頭ページのみ
                this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            }

            // インスタンスが作成されていなければ作成
            if ( this._rptExtraHeader == null ) {
                this._rptExtraHeader = new ListCommon_ExtraHeader();
            }
            else {
                // インスタンスが作成されていれば、データソースを初期化する
                // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                this._rptExtraHeader.DataSource = null;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 拠点オプション有無判定
            //string sectionTitle = string.Format( "{0}拠点：", this._estimateListCndtn.MainExtractTitle );
            //if ( this._estimateListCndtn.IsOptSection )
            //{
            //    if ( this._estimateListCndtn.IsSelectAllSection )
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
            //    }
            //    else
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    }

            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2008.08.01 30413 犬飼 抽出条件文字列取得の変更 >>>>>>START
            // 抽出条件印字項目設定
            //this._rptExtraHeader.ExtraConditions = this._extraConditions;

            //this.Header_SubReport.Report = this._rptExtraHeader;
            string extraBuf = "";
            for (int i = 0; i < this._extraConditions.Count; i++)
            {
                extraBuf = extraBuf + this._extraConditions[i];
            }
            this.Extraction.Text = extraBuf;
            // 2008.08.01 30413 犬飼 抽出条件文字列取得の変更 <<<<<<END
        }
        #endregion

        #region ◎ Detail_Format Event
        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Detailグループのフォーマットイベント。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_Format ( object sender, System.EventArgs eArgs )
        {
            //---------------------------------------------------------
            // メモ印刷制御
            //---------------------------------------------------------
            # region [メモ印刷制御]
            // メモTextBoxのリストを生成
            List<TextBox> memoList = new List<TextBox>();
            // 2008.08.01 30413 犬飼 メモ項目の変更 <<<<<<END
            //memoList.AddRange(new TextBox[] { SlipMemo1, SlipMemo2, SlipMemo3, SlipMemo4, SlipMemo5, SlipMemo6 });
            //memoList.AddRange( new TextBox[] { InsideMemo1, InsideMemo2, InsideMemo3, InsideMemo4, InsideMemo5, InsideMemo6 } );
            memoList.AddRange(new TextBox[] { SlipMemo1, SlipMemo2, SlipMemo3 });
            memoList.AddRange(new TextBox[] { InsideMemo1, InsideMemo2, InsideMemo3 });
            // 2008.08.01 30413 犬飼 メモ項目の変更 <<<<<<END
                
            if ( this._estimateListCndtn.MemoPrintDiv == EstimateListCndtn.MemoPrintDivState.Print )
            {
                // メモ印刷する
                foreach ( TextBox tbMemo in memoList )
                {
                    if ( string.IsNullOrEmpty( tbMemo.Text ) )
                    {
                        tbMemo.Visible = false;
                    }
                    else
                    {
                        tbMemo.Visible = true;
                    }
                }
            }
            else
            {
                // メモ印刷しない
                foreach ( TextBox tbMemo in memoList )
                {
                    tbMemo.Visible = false;
                }
            }
            # endregion

            //---------------------------------------------------------
            // 売上伝票区分(明細)による印字制御
            //---------------------------------------------------------
            # region [売上伝票区分(明細)による印字制御]
            // 区分値取得
            SalesSlipCdDtlState salesSlipCdDtlValue = (SalesSlipCdDtlState)GetSalesSlipCdDtl(SalesSlipCdDtl);
            switch (salesSlipCdDtlValue)
            {
                // 行値引行
                case SalesSlipCdDtlState.Discount:
                    {
                        # region [行値引行]

                        // ※金額・数量関連は金額のみ印字

                        // --- UPD 2014/01/10 T.Miyamoto ------------------------------>>>>>
                        //// --- ADD 2013/11/15 Y.Wakita ---------->>>>>
                        //if (BLGoodsCode.Text.Trim() == "")
                        //{
                        //// --- ADD 2013/11/05 Y.Wakita ----------<<<<<
                        //    // 定価
                        //    ListPriceTaxExcFl.Visible = false;
                        //    // 数量
                        //    ShipmentCnt.Visible = false;
                        //    // 見積残数
                        //    AcptAnOdrRemainCnt.Visible = false; // ADD 2009/02/02
                        //    // 原単価
                        //    SalesUnitCost.Visible = false;
                        //    // 単価
                        //    SalesUnPrcTaxExcFl.Visible = false;
                        //// --- ADD 2013/11/05 Y.Wakita ---------->>>>>
                        //}
                        //// --- ADD 2013/11/05 Y.Wakita ----------<<<<<
                        // ※数量がゼロ以外の場合は商品値引
                        // 定価
                        ListPriceTaxExcFl.Visible = (this.ShipmentCnt.Value.ToString().TrimEnd() != "0");
                        // 数量
                        ShipmentCnt.Visible = (this.ShipmentCnt.Value.ToString().TrimEnd() != "0");
                        // 見積残数
                        AcptAnOdrRemainCnt.Visible = (this.ShipmentCnt.Value.ToString().TrimEnd() != "0");
                        // 原単価
                        SalesUnitCost.Visible = (this.ShipmentCnt.Value.ToString().TrimEnd() != "0");
                        // 単価
                        SalesUnPrcTaxExcFl.Visible = (this.ShipmentCnt.Value.ToString().TrimEnd() != "0");
                        // --- UPD 2014/01/10 T.Miyamoto ------------------------------<<<<<

                        // 金額
                        SalesMoneyTaxExc.Visible = true;
                        # endregion
                    }
                    break;
                // 注釈行
                case SalesSlipCdDtlState.Notice:
                    {
                        # region [注釈行]

                        // ※金額・数量関連を印字しない

                        // 定価
                        ListPriceTaxExcFl.Visible = false;
                        // 数量
                        ShipmentCnt.Visible = false;
                        // 見積残数
                        AcptAnOdrRemainCnt.Visible = false; // ADD 2009/02/02
                        // 原単価
                        SalesUnitCost.Visible = false;
                        // 単価
                        SalesUnPrcTaxExcFl.Visible = false;
                        // 金額
                        SalesMoneyTaxExc.Visible = false;
                        # endregion
                    }
                    break;
                // 小計行
                case SalesSlipCdDtlState.Sum:
                    {
                        # region [小計行]

                        // ※金額・数量関連は金額のみ印字

                        // 定価
                        ListPriceTaxExcFl.Visible = false;
                        // 数量
                        ShipmentCnt.Visible = false;
                        // 見積残数
                        AcptAnOdrRemainCnt.Visible = false; // ADD 2009/02/02
                        // 原単価
                        SalesUnitCost.Visible = false;
                        // 単価
                        SalesUnPrcTaxExcFl.Visible = false;
                        // 金額
                        SalesMoneyTaxExc.Visible = true;
                        # endregion
                    }
                    break;
                // その他
                default:
                    {
                        # region [その他]

                        // ※金額・数量関連を印字

                        // 定価
                        ListPriceTaxExcFl.Visible = true;
                        // 数量
                        ShipmentCnt.Visible = true;
                        // 見積残数
                        AcptAnOdrRemainCnt.Visible = true; // ADD 2009/02/02
                        // 原単価
                        SalesUnitCost.Visible = true;
                        
                        // 2008.11.25 30413 犬飼 売単価の印字制御 >>>>>>START
                        // 単価
                        //SalesUnPrcTaxExcFl.Visible = true;
                        string salesUnPrcTaxExcFl = this.SalesUnPrcTaxExcFl.Value.ToString().TrimEnd();
                        if (salesUnPrcTaxExcFl == "0")
                        {
                            // 売単価が"0"の場合は非印字
                            SalesUnPrcTaxExcFl.Visible = false;
                        }
                        else
                        {
                            // 上記以外の場合は印字
                            SalesUnPrcTaxExcFl.Visible = true;
                        }
                        // 2008.11.25 30413 犬飼 売単価の印字制御 <<<<<<END

                        // 金額
                        SalesMoneyTaxExc.Visible = true;
                        # endregion
                    }
                    break;
            }
            # endregion
        }
        /// <summary>
        /// 売上伝票区分(明細)区分値取得
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private int GetSalesSlipCdDtl( TextBox textBox )
        {
            int divValue = 0;

            try
            {
                divValue = Int32.Parse( textBox.Text );
            }
            catch
            {
            }

            return divValue;
        }
        #endregion

        #region ◎ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
        {
            // グループサプレスの判断
            this.CheckGroupSuppression();
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
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
        /// <br>Programmer  : 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_AfterPrint ( object sender, System.EventArgs eArgs )
        {
            // 印刷件数カウントアップ
            this._printCount++;
#if DEBUG
            return;
#endif
            if ( this.ProgressBarUpEvent != null ) {
                this.ProgressBarUpEvent(this, this._printCount);
            }

        }
        #endregion

        #region ◎ DailyFooter_Format Event
        /// <summary>
        /// DailyFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DailyFooter_Format Event</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DailyFooter_Format ( object sender, System.EventArgs eArgs )
        {
            // TODO : 前行KEY退避をクリア（次明細はサプレス解除）
        }
        #endregion

        #region ◎ PageFooter_Format Event
        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void PageFooter_Format ( object sender, System.EventArgs eArgs )
        {
            // フッター出力する？
            if ( this._pageFooterOutCode == 0 ) {
                // インスタンスが作成されていなければ作成
                if ( _rptPageFooter == null ) {
                    _rptPageFooter = new ListCommon_PageFooter();
                }
                else {
                    // インスタンスが作成されていれば、データソースを初期化する
                    // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                    _rptPageFooter.DataSource = null;
                }

                // フッター印字項目設定
                if ( this._pageFooters[0] != null ) {
                    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if ( this._pageFooters[1] != null ) {
                    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
            }
        }
        #endregion

        #endregion ■ Control Event

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.GroupHeader SalesSlipHeader;
        private DataDynamics.ActiveReports.GroupHeader CustomerHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.GroupFooter CustomerFooter;
		private DataDynamics.ActiveReports.Line Line44;
        private DataDynamics.ActiveReports.TextBox Cus_Title;
        private DataDynamics.ActiveReports.TextBox Cus_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.GroupFooter SalesSlipFooter;
		private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.TextBox Sl_Title;
        private DataDynamics.ActiveReports.TextBox Sl_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.TextBox Sec_Title;
        private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.TextBox Sec_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label Ttl_Title;
        private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Ttl_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 自動生成
        /// </summary>
        public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCMIT02102P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SlipMemo1 = new DataDynamics.ActiveReports.TextBox();
            this.SlipMemo2 = new DataDynamics.ActiveReports.TextBox();
            this.SlipMemo3 = new DataDynamics.ActiveReports.TextBox();
            this.InsideMemo2 = new DataDynamics.ActiveReports.TextBox();
            this.InsideMemo3 = new DataDynamics.ActiveReports.TextBox();
            this.InsideMemo1 = new DataDynamics.ActiveReports.TextBox();
            this.SalesCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.ListPriceTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnitCost = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnPrcTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipCdDtl = new DataDynamics.ActiveReports.TextBox();
            this.AcptAnOdrRemainCnt = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Extraction = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox48 = new DataDynamics.ActiveReports.TextBox();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_SlipMemo1 = new DataDynamics.ActiveReports.Label();
            this.Lb_SlipMemo2 = new DataDynamics.ActiveReports.Label();
            this.Lb_SlipMemo3 = new DataDynamics.ActiveReports.Label();
            this.Lb_InsideMemo1 = new DataDynamics.ActiveReports.Label();
            this.Lb_InsideMemo2 = new DataDynamics.ActiveReports.Label();
            this.Lb_InsideMemo3 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label28 = new DataDynamics.ActiveReports.Label();
            this.label38 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label48 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.Label29 = new DataDynamics.ActiveReports.Label();
            this.Label31 = new DataDynamics.ActiveReports.Label();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.label39 = new DataDynamics.ActiveReports.Label();
            this.label40 = new DataDynamics.ActiveReports.Label();
            this.label41 = new DataDynamics.ActiveReports.Label();
            this.label42 = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Ttl_Title = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Sec_Title = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Sec_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.ModelFullName = new DataDynamics.ActiveReports.TextBox();
            this.CategoryDtl = new DataDynamics.ActiveReports.TextBox();
            this.FullModel = new DataDynamics.ActiveReports.TextBox();
            this.CarMngCode = new DataDynamics.ActiveReports.TextBox();
            this.FirstEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote2 = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.SalesDate = new DataDynamics.ActiveReports.TextBox();
            this.EstimateValidityDate = new DataDynamics.ActiveReports.TextBox();
            this.SalesEmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.SearchSlipDate = new DataDynamics.ActiveReports.TextBox();
            this.EstimateFormNo = new DataDynamics.ActiveReports.TextBox();
            this.EstimateDivideNm = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote3 = new DataDynamics.ActiveReports.TextBox();
            this.AcceptOrOrderKindRF = new DataDynamics.ActiveReports.TextBox();
            this.AutoAnswerDivSCMRF = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.Sl_Title = new DataDynamics.ActiveReports.TextBox();
            this.Sl_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.Cus_Title = new DataDynamics.ActiveReports.TextBox();
            this.Cus_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SalesDateHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SalesDateFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.Sal_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SlipMemo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipMemo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipMemo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsideMemo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsideMemo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsideMemo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCdDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcptAnOdrRemainCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SlipMemo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SlipMemo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SlipMemo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InsideMemo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InsideMemo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InsideMemo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarMngCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateValidityDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchSlipDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateFormNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateDivideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptOrOrderKindRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnswerDivSCMRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sal_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SlipMemo1,
            this.SlipMemo2,
            this.SlipMemo3,
            this.InsideMemo2,
            this.InsideMemo3,
            this.InsideMemo1,
            this.SalesCode,
            this.BLGoodsCode,
            this.GoodsNo,
            this.GoodsName,
            this.ListPriceTaxExcFl,
            this.ShipmentCnt,
            this.SalesUnitCost,
            this.SalesUnPrcTaxExcFl,
            this.SalesMoneyTaxExc,
            this.SupplierCd,
            this.WarehouseName,
            this.SalesSlipCdDtl,
            this.AcptAnOdrRemainCnt,
            this.line5,
            this.AcceptOrOrderKindRF,
            this.AutoAnswerDivSCMRF});
            this.Detail.Height = 0.53125F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // SlipMemo1
            // 
            this.SlipMemo1.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipMemo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo1.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipMemo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo1.Border.RightColor = System.Drawing.Color.Black;
            this.SlipMemo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo1.Border.TopColor = System.Drawing.Color.Black;
            this.SlipMemo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo1.DataField = "SlipMemo1";
            this.SlipMemo1.Height = 0.125F;
            this.SlipMemo1.Left = 2.322917F;
            this.SlipMemo1.MultiLine = false;
            this.SlipMemo1.Name = "SlipMemo1";
            this.SlipMemo1.OutputFormat = resources.GetString("SlipMemo1.OutputFormat");
            this.SlipMemo1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SlipMemo1.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SlipMemo1.Top = 0.1875F;
            this.SlipMemo1.Width = 2.3125F;
            // 
            // SlipMemo2
            // 
            this.SlipMemo2.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipMemo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo2.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipMemo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo2.Border.RightColor = System.Drawing.Color.Black;
            this.SlipMemo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo2.Border.TopColor = System.Drawing.Color.Black;
            this.SlipMemo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo2.DataField = "SlipMemo2";
            this.SlipMemo2.Height = 0.125F;
            this.SlipMemo2.Left = 4.635417F;
            this.SlipMemo2.MultiLine = false;
            this.SlipMemo2.Name = "SlipMemo2";
            this.SlipMemo2.OutputFormat = resources.GetString("SlipMemo2.OutputFormat");
            this.SlipMemo2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SlipMemo2.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SlipMemo2.Top = 0.1875F;
            this.SlipMemo2.Width = 2.25F;
            // 
            // SlipMemo3
            // 
            this.SlipMemo3.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipMemo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo3.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipMemo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo3.Border.RightColor = System.Drawing.Color.Black;
            this.SlipMemo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo3.Border.TopColor = System.Drawing.Color.Black;
            this.SlipMemo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipMemo3.DataField = "SlipMemo3";
            this.SlipMemo3.Height = 0.125F;
            this.SlipMemo3.Left = 6.947917F;
            this.SlipMemo3.MultiLine = false;
            this.SlipMemo3.Name = "SlipMemo3";
            this.SlipMemo3.OutputFormat = resources.GetString("SlipMemo3.OutputFormat");
            this.SlipMemo3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SlipMemo3.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SlipMemo3.Top = 0.1875F;
            this.SlipMemo3.Width = 2.25F;
            // 
            // InsideMemo2
            // 
            this.InsideMemo2.Border.BottomColor = System.Drawing.Color.Black;
            this.InsideMemo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo2.Border.LeftColor = System.Drawing.Color.Black;
            this.InsideMemo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo2.Border.RightColor = System.Drawing.Color.Black;
            this.InsideMemo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo2.Border.TopColor = System.Drawing.Color.Black;
            this.InsideMemo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo2.DataField = "InsideMemo2";
            this.InsideMemo2.Height = 0.125F;
            this.InsideMemo2.Left = 4.635417F;
            this.InsideMemo2.MultiLine = false;
            this.InsideMemo2.Name = "InsideMemo2";
            this.InsideMemo2.OutputFormat = resources.GetString("InsideMemo2.OutputFormat");
            this.InsideMemo2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.InsideMemo2.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.InsideMemo2.Top = 0.3125F;
            this.InsideMemo2.Width = 2.25F;
            // 
            // InsideMemo3
            // 
            this.InsideMemo3.Border.BottomColor = System.Drawing.Color.Black;
            this.InsideMemo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo3.Border.LeftColor = System.Drawing.Color.Black;
            this.InsideMemo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo3.Border.RightColor = System.Drawing.Color.Black;
            this.InsideMemo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo3.Border.TopColor = System.Drawing.Color.Black;
            this.InsideMemo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo3.DataField = "InsideMemo3";
            this.InsideMemo3.Height = 0.125F;
            this.InsideMemo3.Left = 6.947917F;
            this.InsideMemo3.MultiLine = false;
            this.InsideMemo3.Name = "InsideMemo3";
            this.InsideMemo3.OutputFormat = resources.GetString("InsideMemo3.OutputFormat");
            this.InsideMemo3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.InsideMemo3.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.InsideMemo3.Top = 0.3125F;
            this.InsideMemo3.Width = 2.25F;
            // 
            // InsideMemo1
            // 
            this.InsideMemo1.Border.BottomColor = System.Drawing.Color.Black;
            this.InsideMemo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo1.Border.LeftColor = System.Drawing.Color.Black;
            this.InsideMemo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo1.Border.RightColor = System.Drawing.Color.Black;
            this.InsideMemo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo1.Border.TopColor = System.Drawing.Color.Black;
            this.InsideMemo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InsideMemo1.DataField = "InsideMemo1";
            this.InsideMemo1.Height = 0.125F;
            this.InsideMemo1.Left = 2.322917F;
            this.InsideMemo1.MultiLine = false;
            this.InsideMemo1.Name = "InsideMemo1";
            this.InsideMemo1.OutputFormat = resources.GetString("InsideMemo1.OutputFormat");
            this.InsideMemo1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.InsideMemo1.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.InsideMemo1.Top = 0.3125F;
            this.InsideMemo1.Width = 2.3125F;
            // 
            // SalesCode
            // 
            this.SalesCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.CanGrow = false;
            this.SalesCode.DataField = "PrtSalesCode";
            this.SalesCode.Height = 0.125F;
            this.SalesCode.Left = 3.1875F;
            this.SalesCode.MultiLine = false;
            this.SalesCode.Name = "SalesCode";
            this.SalesCode.OutputFormat = resources.GetString("SalesCode.OutputFormat");
            this.SalesCode.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesCode.Text = "1234";
            this.SalesCode.Top = 0.0625F;
            this.SalesCode.Width = 0.5F;
            // 
            // BLGoodsCode
            // 
            this.BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.CanGrow = false;
            this.BLGoodsCode.DataField = "PrtBLGoodsCode";
            this.BLGoodsCode.Height = 0.125F;
            this.BLGoodsCode.Left = 0.125F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.BLGoodsCode.Text = "99999";
            this.BLGoodsCode.Top = 0.0625F;
            this.BLGoodsCode.Width = 0.375F;
            // 
            // GoodsNo
            // 
            this.GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.CanGrow = false;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 0.5625F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.4375F;
            // 
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.CanGrow = false;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 2F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.1875F;
            // 
            // ListPriceTaxExcFl
            // 
            this.ListPriceTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.CanGrow = false;
            this.ListPriceTaxExcFl.DataField = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.Height = 0.125F;
            this.ListPriceTaxExcFl.Left = 5.625F;
            this.ListPriceTaxExcFl.Name = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.OutputFormat = resources.GetString("ListPriceTaxExcFl.OutputFormat");
            this.ListPriceTaxExcFl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.ListPriceTaxExcFl.Text = "123,456,789";
            this.ListPriceTaxExcFl.Top = 0.0625F;
            this.ListPriceTaxExcFl.Width = 0.8125F;
            // 
            // ShipmentCnt
            // 
            this.ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.CanGrow = false;
            this.ShipmentCnt.DataField = "AcceptAnOrderCntPlusAdjustCnt";
            this.ShipmentCnt.Height = 0.125F;
            this.ShipmentCnt.Left = 6.5F;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.ShipmentCnt.Text = "1,234,567.00";
            this.ShipmentCnt.Top = 0.0625F;
            this.ShipmentCnt.Width = 0.75F;
            // 
            // SalesUnitCost
            // 
            this.SalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.CanGrow = false;
            this.SalesUnitCost.DataField = "SalesUnitCost";
            this.SalesUnitCost.Height = 0.125F;
            this.SalesUnitCost.Left = 8.125F;
            this.SalesUnitCost.Name = "SalesUnitCost";
            this.SalesUnitCost.OutputFormat = resources.GetString("SalesUnitCost.OutputFormat");
            this.SalesUnitCost.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesUnitCost.Text = "12,345,678.00";
            this.SalesUnitCost.Top = 0.0625F;
            this.SalesUnitCost.Width = 0.8125F;
            // 
            // SalesUnPrcTaxExcFl
            // 
            this.SalesUnPrcTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.CanGrow = false;
            this.SalesUnPrcTaxExcFl.DataField = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.Height = 0.125F;
            this.SalesUnPrcTaxExcFl.Left = 9F;
            this.SalesUnPrcTaxExcFl.Name = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.OutputFormat = resources.GetString("SalesUnPrcTaxExcFl.OutputFormat");
            this.SalesUnPrcTaxExcFl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesUnPrcTaxExcFl.Text = "12,345,678.00";
            this.SalesUnPrcTaxExcFl.Top = 0.0625F;
            this.SalesUnPrcTaxExcFl.Width = 0.8125F;
            // 
            // SalesMoneyTaxExc
            // 
            this.SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.CanGrow = false;
            this.SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.Height = 0.125F;
            this.SalesMoneyTaxExc.Left = 9.875F;
            this.SalesMoneyTaxExc.Name = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.OutputFormat = resources.GetString("SalesMoneyTaxExc.OutputFormat");
            this.SalesMoneyTaxExc.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesMoneyTaxExc.Text = "123,456,789";
            this.SalesMoneyTaxExc.Top = 0.0625F;
            this.SalesMoneyTaxExc.Width = 0.8125F;
            // 
            // SupplierCd
            // 
            this.SupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.CanGrow = false;
            this.SupplierCd.DataField = "PrtSupplierCd";
            this.SupplierCd.Height = 0.125F;
            this.SupplierCd.Left = 3.875F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SupplierCd.Text = "999999";
            this.SupplierCd.Top = 0.0625F;
            this.SupplierCd.Width = 0.4375F;
            // 
            // WarehouseName
            // 
            this.WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.CanGrow = false;
            this.WarehouseName.DataField = "WarehouseName";
            this.WarehouseName.Height = 0.125F;
            this.WarehouseName.Left = 4.3125F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.WarehouseName.Text = "ぜんかくぜんかくぜん";
            this.WarehouseName.Top = 0.0625F;
            this.WarehouseName.Width = 1.1875F;
            // 
            // SalesSlipCdDtl
            // 
            this.SalesSlipCdDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.DataField = "SalesSlipCdDtl";
            this.SalesSlipCdDtl.Height = 0.125F;
            this.SalesSlipCdDtl.Left = 1.885417F;
            this.SalesSlipCdDtl.MultiLine = false;
            this.SalesSlipCdDtl.Name = "SalesSlipCdDtl";
            this.SalesSlipCdDtl.OutputFormat = resources.GetString("SalesSlipCdDtl.OutputFormat");
            this.SalesSlipCdDtl.Style = "color: Gray; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ" +
                " 明朝; vertical-align: top; ";
            this.SalesSlipCdDtl.Tag = "※印字制御用です。";
            this.SalesSlipCdDtl.Text = "1";
            this.SalesSlipCdDtl.Top = 0.25F;
            this.SalesSlipCdDtl.Visible = false;
            this.SalesSlipCdDtl.Width = 0.25F;
            // 
            // AcptAnOdrRemainCnt
            // 
            this.AcptAnOdrRemainCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.Border.RightColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.Border.TopColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.CanGrow = false;
            this.AcptAnOdrRemainCnt.DataField = "AcptAnOdrRemainCnt";
            this.AcptAnOdrRemainCnt.Height = 0.125F;
            this.AcptAnOdrRemainCnt.Left = 7.3125F;
            this.AcptAnOdrRemainCnt.Name = "AcptAnOdrRemainCnt";
            this.AcptAnOdrRemainCnt.OutputFormat = resources.GetString("AcptAnOdrRemainCnt.OutputFormat");
            this.AcptAnOdrRemainCnt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.AcptAnOdrRemainCnt.Text = "1,234,567.00";
            this.AcptAnOdrRemainCnt.Top = 0.0625F;
            this.AcptAnOdrRemainCnt.Width = 0.75F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime,
            this.tb_ReportTitle});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.15625F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.9375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.625F;
            // 
            // tb_PrintDate
            // 
            this.tb_PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.CanShrink = true;
            this.tb_PrintDate.Height = 0.15625F;
            this.tb_PrintDate.Left = 8.5F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 0.9375F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.15625F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // tb_PrintPage
            // 
            this.tb_PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.CanShrink = true;
            this.tb_PrintPage.Height = 0.15625F;
            this.tb_PrintPage.Left = 10.4375F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0625F;
            this.tb_PrintPage.Width = 0.28125F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.2085F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.2085F;
            this.Line1.Y2 = 0.2085F;
            // 
            // tb_PrintTime
            // 
            this.tb_PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Height = 0.125F;
            this.tb_PrintTime.Left = 9.4375F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // tb_ReportTitle
            // 
            this.tb_ReportTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "見積確認表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.90625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Footer_SubReport
            // 
            this.Footer_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.CloseBorder = false;
            this.Footer_SubReport.Height = 0.239F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Extraction});
            this.ExtraHeader.Height = 0.34375F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // Extraction
            // 
            this.Extraction.Border.BottomColor = System.Drawing.Color.Black;
            this.Extraction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.LeftColor = System.Drawing.Color.Black;
            this.Extraction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.RightColor = System.Drawing.Color.Black;
            this.Extraction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.TopColor = System.Drawing.Color.Black;
            this.Extraction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.CanShrink = true;
            this.Extraction.Height = 0.25F;
            this.Extraction.Left = 0F;
            this.Extraction.Name = "Extraction";
            this.Extraction.Style = "color: Black; font-size: 8pt; vertical-align: top; ";
            this.Extraction.Text = null;
            this.Extraction.Top = 0F;
            this.Extraction.Width = 10.75F;
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightColor = System.Drawing.Color.Black;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopColor = System.Drawing.Color.Black;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.CanGrow = false;
            this.textBox12.DataField = "ResultsAddUpSecCd";
            this.textBox12.Height = 0.1875F;
            this.textBox12.Left = 0.3125F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox12.Text = "00";
            this.textBox12.Top = 0.0625F;
            this.textBox12.Width = 0.1875F;
            // 
            // textBox48
            // 
            this.textBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.RightColor = System.Drawing.Color.Black;
            this.textBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.TopColor = System.Drawing.Color.Black;
            this.textBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.DataField = "ResultsAddUpSecNm";
            this.textBox48.Height = 0.1875F;
            this.textBox48.Left = 0.5F;
            this.textBox48.Name = "textBox48";
            this.textBox48.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: inherit; vertical-align: top; ";
            this.textBox48.Text = "拠点名称５６７８９０";
            this.textBox48.Top = 0.0625F;
            this.textBox48.Width = 1.1875F;
            // 
            // line17
            // 
            this.line17.Border.BottomColor = System.Drawing.Color.Black;
            this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.LeftColor = System.Drawing.Color.Black;
            this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.RightColor = System.Drawing.Color.Black;
            this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.TopColor = System.Drawing.Color.Black;
            this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Height = 0F;
            this.line17.Left = 0F;
            this.line17.LineWeight = 1F;
            this.line17.Name = "line17";
            this.line17.Top = 0F;
            this.line17.Width = 10.8F;
            this.line17.X1 = 0F;
            this.line17.X2 = 10.8F;
            this.line17.Y1 = 0F;
            this.line17.Y2 = 0F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Lb_SlipMemo1,
            this.Lb_SlipMemo2,
            this.Lb_SlipMemo3,
            this.Lb_InsideMemo1,
            this.Lb_InsideMemo2,
            this.Lb_InsideMemo3,
            this.label8,
            this.Label26,
            this.Label6,
            this.label19,
            this.label23,
            this.label12,
            this.label24,
            this.label28,
            this.label38,
            this.label16,
            this.label17,
            this.label1,
            this.label20,
            this.label35,
            this.label48,
            this.label4,
            this.Label9,
            this.Label13,
            this.Label29,
            this.Label31,
            this.label25,
            this.label36,
            this.label27,
            this.label39,
            this.label40,
            this.label41,
            this.label42,
            this.Line42,
            this.label7,
            this.label10,
            this.label11});
            this.TitleHeader.Height = 1.114583F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Lb_SlipMemo1
            // 
            this.Lb_SlipMemo1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo1.Height = 0.1875F;
            this.Lb_SlipMemo1.HyperLink = "";
            this.Lb_SlipMemo1.Left = 2.322917F;
            this.Lb_SlipMemo1.MultiLine = false;
            this.Lb_SlipMemo1.Name = "Lb_SlipMemo1";
            this.Lb_SlipMemo1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SlipMemo1.Text = "伝票メモ１";
            this.Lb_SlipMemo1.Top = 0.625F;
            this.Lb_SlipMemo1.Width = 0.6875F;
            // 
            // Lb_SlipMemo2
            // 
            this.Lb_SlipMemo2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo2.Height = 0.1875F;
            this.Lb_SlipMemo2.HyperLink = "";
            this.Lb_SlipMemo2.Left = 4.635417F;
            this.Lb_SlipMemo2.MultiLine = false;
            this.Lb_SlipMemo2.Name = "Lb_SlipMemo2";
            this.Lb_SlipMemo2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SlipMemo2.Text = "伝票メモ２";
            this.Lb_SlipMemo2.Top = 0.625F;
            this.Lb_SlipMemo2.Width = 0.6875F;
            // 
            // Lb_SlipMemo3
            // 
            this.Lb_SlipMemo3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SlipMemo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SlipMemo3.Height = 0.1875F;
            this.Lb_SlipMemo3.HyperLink = "";
            this.Lb_SlipMemo3.Left = 6.947917F;
            this.Lb_SlipMemo3.MultiLine = false;
            this.Lb_SlipMemo3.Name = "Lb_SlipMemo3";
            this.Lb_SlipMemo3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SlipMemo3.Text = "伝票メモ３";
            this.Lb_SlipMemo3.Top = 0.625F;
            this.Lb_SlipMemo3.Width = 0.6875F;
            // 
            // Lb_InsideMemo1
            // 
            this.Lb_InsideMemo1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo1.Height = 0.1875F;
            this.Lb_InsideMemo1.HyperLink = "";
            this.Lb_InsideMemo1.Left = 2.322917F;
            this.Lb_InsideMemo1.MultiLine = false;
            this.Lb_InsideMemo1.Name = "Lb_InsideMemo1";
            this.Lb_InsideMemo1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_InsideMemo1.Text = "社内メモ１";
            this.Lb_InsideMemo1.Top = 0.8125F;
            this.Lb_InsideMemo1.Width = 0.6875F;
            // 
            // Lb_InsideMemo2
            // 
            this.Lb_InsideMemo2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo2.Height = 0.1875F;
            this.Lb_InsideMemo2.HyperLink = "";
            this.Lb_InsideMemo2.Left = 4.635417F;
            this.Lb_InsideMemo2.MultiLine = false;
            this.Lb_InsideMemo2.Name = "Lb_InsideMemo2";
            this.Lb_InsideMemo2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_InsideMemo2.Text = "社内メモ２";
            this.Lb_InsideMemo2.Top = 0.8125F;
            this.Lb_InsideMemo2.Width = 0.6875F;
            // 
            // Lb_InsideMemo3
            // 
            this.Lb_InsideMemo3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_InsideMemo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InsideMemo3.Height = 0.1875F;
            this.Lb_InsideMemo3.HyperLink = "";
            this.Lb_InsideMemo3.Left = 6.947917F;
            this.Lb_InsideMemo3.MultiLine = false;
            this.Lb_InsideMemo3.Name = "Lb_InsideMemo3";
            this.Lb_InsideMemo3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_InsideMemo3.Text = "社内メモ３";
            this.Lb_InsideMemo3.Top = 0.8125F;
            this.Lb_InsideMemo3.Width = 0.6875F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = "";
            this.label8.Left = 4.6875F;
            this.label8.Name = "label8";
            this.label8.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label8.Text = "見積タイプ";
            this.label8.Top = 0.0625F;
            this.label8.Width = 0.625F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.1875F;
            this.Label26.HyperLink = "";
            this.Label26.Left = 0.6875F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Label26.Text = "車種";
            this.Label26.Top = 0.25F;
            this.Label26.Width = 0.625F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.1875F;
            this.Label6.HyperLink = "";
            this.Label6.Left = 0F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Label6.Text = "類別";
            this.Label6.Top = 0.25F;
            this.Label6.Width = 0.625F;
            // 
            // label19
            // 
            this.label19.Border.BottomColor = System.Drawing.Color.Black;
            this.label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.LeftColor = System.Drawing.Color.Black;
            this.label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.RightColor = System.Drawing.Color.Black;
            this.label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.TopColor = System.Drawing.Color.Black;
            this.label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Height = 0.1875F;
            this.label19.HyperLink = "";
            this.label19.Left = 4.125F;
            this.label19.Name = "label19";
            this.label19.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label19.Text = "見積書No";
            this.label19.Top = 0.0625F;
            this.label19.Width = 0.5625F;
            // 
            // label23
            // 
            this.label23.Border.BottomColor = System.Drawing.Color.Black;
            this.label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.LeftColor = System.Drawing.Color.Black;
            this.label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.RightColor = System.Drawing.Color.Black;
            this.label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.TopColor = System.Drawing.Color.Black;
            this.label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Height = 0.1875F;
            this.label23.HyperLink = "";
            this.label23.Left = 0F;
            this.label23.Name = "label23";
            this.label23.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label23.Text = "得意先";
            this.label23.Top = 0.0625F;
            this.label23.Width = 0.5625F;
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.1875F;
            this.label12.HyperLink = "";
            this.label12.Left = 2.25F;
            this.label12.Name = "label12";
            this.label12.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label12.Text = "見積日";
            this.label12.Top = 0.0625F;
            this.label12.Width = 0.625F;
            // 
            // label24
            // 
            this.label24.Border.BottomColor = System.Drawing.Color.Black;
            this.label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.LeftColor = System.Drawing.Color.Black;
            this.label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.RightColor = System.Drawing.Color.Black;
            this.label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.TopColor = System.Drawing.Color.Black;
            this.label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Height = 0.1875F;
            this.label24.HyperLink = "";
            this.label24.Left = 3.5F;
            this.label24.Name = "label24";
            this.label24.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label24.Text = "有効期限";
            this.label24.Top = 0.0625F;
            this.label24.Width = 0.625F;
            // 
            // label28
            // 
            this.label28.Border.BottomColor = System.Drawing.Color.Black;
            this.label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.LeftColor = System.Drawing.Color.Black;
            this.label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.RightColor = System.Drawing.Color.Black;
            this.label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.TopColor = System.Drawing.Color.Black;
            this.label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Height = 0.1875F;
            this.label28.HyperLink = "";
            this.label28.Left = 5.375F;
            this.label28.Name = "label28";
            this.label28.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label28.Text = "担当者";
            this.label28.Top = 0.0625F;
            this.label28.Width = 0.8125F;
            // 
            // label38
            // 
            this.label38.Border.BottomColor = System.Drawing.Color.Black;
            this.label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.LeftColor = System.Drawing.Color.Black;
            this.label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.RightColor = System.Drawing.Color.Black;
            this.label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.TopColor = System.Drawing.Color.Black;
            this.label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Height = 0.1875F;
            this.label38.HyperLink = "";
            this.label38.Left = 2.875F;
            this.label38.Name = "label38";
            this.label38.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label38.Text = "入力日";
            this.label38.Top = 0.0625F;
            this.label38.Width = 0.625F;
            // 
            // label16
            // 
            this.label16.Border.BottomColor = System.Drawing.Color.Black;
            this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.LeftColor = System.Drawing.Color.Black;
            this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.RightColor = System.Drawing.Color.Black;
            this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.TopColor = System.Drawing.Color.Black;
            this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Height = 0.1875F;
            this.label16.HyperLink = "";
            this.label16.Left = 1.375F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label16.Text = "型式";
            this.label16.Top = 0.25F;
            this.label16.Width = 0.5625F;
            // 
            // label17
            // 
            this.label17.Border.BottomColor = System.Drawing.Color.Black;
            this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.LeftColor = System.Drawing.Color.Black;
            this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.RightColor = System.Drawing.Color.Black;
            this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.TopColor = System.Drawing.Color.Black;
            this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Height = 0.1875F;
            this.label17.HyperLink = "";
            this.label17.Left = 3.5F;
            this.label17.Name = "label17";
            this.label17.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label17.Text = "管理番号";
            this.label17.Top = 0.25F;
            this.label17.Width = 0.5625F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = "";
            this.label1.Left = 4.625F;
            this.label1.Name = "label1";
            this.label1.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label1.Text = "年式";
            this.label1.Top = 0.25F;
            this.label1.Width = 0.4375F;
            // 
            // label20
            // 
            this.label20.Border.BottomColor = System.Drawing.Color.Black;
            this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.LeftColor = System.Drawing.Color.Black;
            this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.RightColor = System.Drawing.Color.Black;
            this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.TopColor = System.Drawing.Color.Black;
            this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Height = 0.1875F;
            this.label20.HyperLink = "";
            this.label20.Left = 9.625F;
            this.label20.Name = "label20";
            this.label20.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label20.Text = "見積書番号";
            this.label20.Top = 0.0625F;
            this.label20.Visible = false;
            this.label20.Width = 0.625F;
            // 
            // label35
            // 
            this.label35.Border.BottomColor = System.Drawing.Color.Black;
            this.label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.LeftColor = System.Drawing.Color.Black;
            this.label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.RightColor = System.Drawing.Color.Black;
            this.label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.TopColor = System.Drawing.Color.Black;
            this.label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Height = 0.1875F;
            this.label35.HyperLink = "";
            this.label35.Left = 6.1875F;
            this.label35.Name = "label35";
            this.label35.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label35.Text = "備考";
            this.label35.Top = 0.0625F;
            this.label35.Width = 0.4375F;
            // 
            // label48
            // 
            this.label48.Border.BottomColor = System.Drawing.Color.Black;
            this.label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.LeftColor = System.Drawing.Color.Black;
            this.label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.RightColor = System.Drawing.Color.Black;
            this.label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.TopColor = System.Drawing.Color.Black;
            this.label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Height = 0.1875F;
            this.label48.HyperLink = "";
            this.label48.Left = 8.5F;
            this.label48.Name = "label48";
            this.label48.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label48.Text = "備考３";
            this.label48.Top = 0.25F;
            this.label48.Width = 0.4375F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = "";
            this.label4.Left = 6.1875F;
            this.label4.Name = "label4";
            this.label4.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label4.Text = "備考２";
            this.label4.Top = 0.25F;
            this.label4.Width = 0.4375F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.1875F;
            this.Label9.HyperLink = "";
            this.Label9.Left = 0.5625F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Label9.Text = "品番";
            this.Label9.Top = 0.4375F;
            this.Label9.Width = 0.375F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.1875F;
            this.Label13.HyperLink = "";
            this.Label13.Left = 3.875F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.Label13.Text = "仕入先";
            this.Label13.Top = 0.4375F;
            this.Label13.Width = 0.4375F;
            // 
            // Label29
            // 
            this.Label29.Border.BottomColor = System.Drawing.Color.Black;
            this.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.LeftColor = System.Drawing.Color.Black;
            this.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.RightColor = System.Drawing.Color.Black;
            this.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.TopColor = System.Drawing.Color.Black;
            this.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Height = 0.1875F;
            this.Label29.HyperLink = "";
            this.Label29.Left = 6.5F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.Label29.Text = "数量";
            this.Label29.Top = 0.4375F;
            this.Label29.Width = 0.75F;
            // 
            // Label31
            // 
            this.Label31.Border.BottomColor = System.Drawing.Color.Black;
            this.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.LeftColor = System.Drawing.Color.Black;
            this.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.RightColor = System.Drawing.Color.Black;
            this.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.TopColor = System.Drawing.Color.Black;
            this.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Height = 0.1875F;
            this.Label31.HyperLink = "";
            this.Label31.Left = 3.1875F;
            this.Label31.Name = "Label31";
            this.Label31.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Label31.Text = "販売区分";
            this.Label31.Top = 0.4375F;
            this.Label31.Width = 0.5F;
            // 
            // label25
            // 
            this.label25.Border.BottomColor = System.Drawing.Color.Black;
            this.label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.LeftColor = System.Drawing.Color.Black;
            this.label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.RightColor = System.Drawing.Color.Black;
            this.label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.TopColor = System.Drawing.Color.Black;
            this.label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Height = 0.1875F;
            this.label25.HyperLink = "";
            this.label25.Left = 4.3125F;
            this.label25.Name = "label25";
            this.label25.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label25.Text = "倉庫";
            this.label25.Top = 0.4375F;
            this.label25.Width = 0.5F;
            // 
            // label36
            // 
            this.label36.Border.BottomColor = System.Drawing.Color.Black;
            this.label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.LeftColor = System.Drawing.Color.Black;
            this.label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.RightColor = System.Drawing.Color.Black;
            this.label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.TopColor = System.Drawing.Color.Black;
            this.label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Height = 0.1875F;
            this.label36.HyperLink = "";
            this.label36.Left = 9.875F;
            this.label36.Name = "label36";
            this.label36.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label36.Text = "金額";
            this.label36.Top = 0.4375F;
            this.label36.Width = 0.8125F;
            // 
            // label27
            // 
            this.label27.Border.BottomColor = System.Drawing.Color.Black;
            this.label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.LeftColor = System.Drawing.Color.Black;
            this.label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.RightColor = System.Drawing.Color.Black;
            this.label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.TopColor = System.Drawing.Color.Black;
            this.label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Height = 0.1875F;
            this.label27.HyperLink = "";
            this.label27.Left = 0.125F;
            this.label27.Name = "label27";
            this.label27.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label27.Text = "BLｺｰﾄﾞ";
            this.label27.Top = 0.4375F;
            this.label27.Width = 0.375F;
            // 
            // label39
            // 
            this.label39.Border.BottomColor = System.Drawing.Color.Black;
            this.label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.LeftColor = System.Drawing.Color.Black;
            this.label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.RightColor = System.Drawing.Color.Black;
            this.label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.TopColor = System.Drawing.Color.Black;
            this.label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Height = 0.1875F;
            this.label39.HyperLink = "";
            this.label39.Left = 2F;
            this.label39.Name = "label39";
            this.label39.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label39.Text = "品名";
            this.label39.Top = 0.4375F;
            this.label39.Width = 0.375F;
            // 
            // label40
            // 
            this.label40.Border.BottomColor = System.Drawing.Color.Black;
            this.label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.LeftColor = System.Drawing.Color.Black;
            this.label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.RightColor = System.Drawing.Color.Black;
            this.label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.TopColor = System.Drawing.Color.Black;
            this.label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Height = 0.1875F;
            this.label40.HyperLink = "";
            this.label40.Left = 5.625F;
            this.label40.Name = "label40";
            this.label40.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label40.Text = "標準価格";
            this.label40.Top = 0.4375F;
            this.label40.Width = 0.8125F;
            // 
            // label41
            // 
            this.label41.Border.BottomColor = System.Drawing.Color.Black;
            this.label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.LeftColor = System.Drawing.Color.Black;
            this.label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.RightColor = System.Drawing.Color.Black;
            this.label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.TopColor = System.Drawing.Color.Black;
            this.label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Height = 0.1875F;
            this.label41.HyperLink = "";
            this.label41.Left = 8.125F;
            this.label41.Name = "label41";
            this.label41.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label41.Text = "原単価";
            this.label41.Top = 0.4375F;
            this.label41.Width = 0.8125F;
            // 
            // label42
            // 
            this.label42.Border.BottomColor = System.Drawing.Color.Black;
            this.label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.LeftColor = System.Drawing.Color.Black;
            this.label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.RightColor = System.Drawing.Color.Black;
            this.label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.TopColor = System.Drawing.Color.Black;
            this.label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Height = 0.1875F;
            this.label42.HyperLink = "";
            this.label42.Left = 9F;
            this.label42.Name = "label42";
            this.label42.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label42.Text = "売単価";
            this.label42.Top = 0.4375F;
            this.label42.Width = 0.8125F;
            // 
            // Line42
            // 
            this.Line42.Border.BottomColor = System.Drawing.Color.Black;
            this.Line42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.LeftColor = System.Drawing.Color.Black;
            this.Line42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.RightColor = System.Drawing.Color.Black;
            this.Line42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.TopColor = System.Drawing.Color.Black;
            this.Line42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Height = 0F;
            this.Line42.Left = 0F;
            this.Line42.LineWeight = 2F;
            this.Line42.Name = "Line42";
            this.Line42.Top = 0F;
            this.Line42.Width = 10.8F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.1875F;
            this.label7.HyperLink = "";
            this.label7.Left = 7.3125F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label7.Text = "見積残数";
            this.label7.Top = 0.4375F;
            this.label7.Width = 0.75F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.1875F;
            this.label10.HyperLink = null;
            this.label10.Left = 9.375F;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label10.Text = "連携種別";
            this.label10.Top = 0.625F;
            this.label10.Width = 0.5625F;
            // 
            // label11
            // 
            this.label11.Border.BottomColor = System.Drawing.Color.Black;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftColor = System.Drawing.Color.Black;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightColor = System.Drawing.Color.Black;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopColor = System.Drawing.Color.Black;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Height = 0.1875F;
            this.label11.HyperLink = null;
            this.label11.Left = 10.0625F;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label11.Text = "自動回答";
            this.label11.Top = 0.625F;
            this.label11.Width = 0.5625F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.1875F;
            this.label5.HyperLink = "";
            this.label5.Left = 0F;
            this.label5.Name = "label5";
            this.label5.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label5.Text = "拠点";
            this.label5.Top = 0.0625F;
            this.label5.Width = 0.3125F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // Line41
            // 
            this.Line41.Border.BottomColor = System.Drawing.Color.Black;
            this.Line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.LeftColor = System.Drawing.Color.Black;
            this.Line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.RightColor = System.Drawing.Color.Black;
            this.Line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.TopColor = System.Drawing.Color.Black;
            this.Line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Height = 0F;
            this.Line41.Left = 0F;
            this.Line41.LineWeight = 2F;
            this.Line41.Name = "Line41";
            this.Line41.Top = 0F;
            this.Line41.Width = 10.8F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 10.8F;
            this.Line41.Y1 = 0F;
            this.Line41.Y2 = 0F;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.CanShrink = true;
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Ttl_Title,
            this.Line43,
            this.Ttl_SalesMoneyTaxExc});
            this.GrandTotalFooter.Height = 0.3020833F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // Ttl_Title
            // 
            this.Ttl_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Height = 0.1875F;
            this.Ttl_Title.HyperLink = "";
            this.Ttl_Title.Left = 5.75F;
            this.Ttl_Title.MultiLine = false;
            this.Ttl_Title.Name = "Ttl_Title";
            this.Ttl_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Ttl_Title.Text = "総合計";
            this.Ttl_Title.Top = 0.0625F;
            this.Ttl_Title.Width = 0.5625F;
            // 
            // Line43
            // 
            this.Line43.Border.BottomColor = System.Drawing.Color.Black;
            this.Line43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.LeftColor = System.Drawing.Color.Black;
            this.Line43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.RightColor = System.Drawing.Color.Black;
            this.Line43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.TopColor = System.Drawing.Color.Black;
            this.Line43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Height = 0F;
            this.Line43.Left = 0F;
            this.Line43.LineWeight = 2F;
            this.Line43.Name = "Line43";
            this.Line43.Top = 0F;
            this.Line43.Width = 10.8F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.8F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // Ttl_SalesMoneyTaxExc
            // 
            this.Ttl_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Ttl_SalesMoneyTaxExc.Height = 0.125F;
            this.Ttl_SalesMoneyTaxExc.Left = 9.875F;
            this.Ttl_SalesMoneyTaxExc.MultiLine = false;
            this.Ttl_SalesMoneyTaxExc.Name = "Ttl_SalesMoneyTaxExc";
            this.Ttl_SalesMoneyTaxExc.OutputFormat = resources.GetString("Ttl_SalesMoneyTaxExc.OutputFormat");
            this.Ttl_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoneyTaxExc.Text = "123,456,789";
            this.Ttl_SalesMoneyTaxExc.Top = 0.0625F;
            this.Ttl_SalesMoneyTaxExc.Width = 0.8125F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line17,
            this.textBox48,
            this.textBox12,
            this.label5});
            this.SectionHeader.DataField = "ResultsAddUpSecCd";
            this.SectionHeader.Height = 0.2916667F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Sec_Title,
            this.Line2,
            this.Sec_SalesMoneyTaxExc});
            this.SectionFooter.Height = 0.3125F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // Sec_Title
            // 
            this.Sec_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Height = 0.1875F;
            this.Sec_Title.Left = 5.75F;
            this.Sec_Title.MultiLine = false;
            this.Sec_Title.Name = "Sec_Title";
            this.Sec_Title.OutputFormat = resources.GetString("Sec_Title.OutputFormat");
            this.Sec_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Sec_Title.Text = "拠点計";
            this.Sec_Title.Top = 0.0625F;
            this.Sec_Title.Width = 0.5625F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 2F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 10.8F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 10.8F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0F;
            // 
            // Sec_SalesMoneyTaxExc
            // 
            this.Sec_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Sec_SalesMoneyTaxExc.Height = 0.125F;
            this.Sec_SalesMoneyTaxExc.Left = 9.875F;
            this.Sec_SalesMoneyTaxExc.MultiLine = false;
            this.Sec_SalesMoneyTaxExc.Name = "Sec_SalesMoneyTaxExc";
            this.Sec_SalesMoneyTaxExc.OutputFormat = resources.GetString("Sec_SalesMoneyTaxExc.OutputFormat");
            this.Sec_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_SalesMoneyTaxExc.SummaryGroup = "SectionHeader";
            this.Sec_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_SalesMoneyTaxExc.Text = "123,456,789";
            this.Sec_SalesMoneyTaxExc.Top = 0.0625F;
            this.Sec_SalesMoneyTaxExc.Width = 0.8125F;
            // 
            // SalesSlipHeader
            // 
            this.SalesSlipHeader.CanShrink = true;
            this.SalesSlipHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line,
            this.line4,
            this.ModelFullName,
            this.CategoryDtl,
            this.FullModel,
            this.CarMngCode,
            this.FirstEntryDate,
            this.SlipNote,
            this.SlipNote2,
            this.CustomerCode,
            this.SalesSlipNum,
            this.CustomerSnm,
            this.SalesDate,
            this.EstimateValidityDate,
            this.SalesEmployeeNm,
            this.SearchSlipDate,
            this.EstimateFormNo,
            this.EstimateDivideNm,
            this.SlipNote3});
            this.SalesSlipHeader.DataField = "SalesSlipNum";
            this.SalesSlipHeader.Height = 0.5104167F;
            this.SalesSlipHeader.KeepTogether = true;
            this.SalesSlipHeader.Name = "SalesSlipHeader";
            this.SalesSlipHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SalesSlipHeader.BeforePrint += new System.EventHandler(this.SalesSlipHeader_BeforePrint);
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 0.3125F;
            this.Line.Visible = false;
            this.Line.Width = 10.75F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.75F;
            this.Line.Y1 = 0.3125F;
            this.Line.Y2 = 0.3125F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 2F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // ModelFullName
            // 
            this.ModelFullName.Border.BottomColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.LeftColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.RightColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.TopColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.CanGrow = false;
            this.ModelFullName.DataField = "ModelFullName";
            this.ModelFullName.Height = 0.125F;
            this.ModelFullName.Left = 0.6875F;
            this.ModelFullName.MultiLine = false;
            this.ModelFullName.Name = "ModelFullName";
            this.ModelFullName.OutputFormat = resources.GetString("ModelFullName.OutputFormat");
            this.ModelFullName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.ModelFullName.Text = "1234567890";
            this.ModelFullName.Top = 0.1875F;
            this.ModelFullName.Width = 0.625F;
            // 
            // CategoryDtl
            // 
            this.CategoryDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.Border.RightColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.Border.TopColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.CanGrow = false;
            this.CategoryDtl.DataField = "CategoryDtl";
            this.CategoryDtl.Height = 0.125F;
            this.CategoryDtl.Left = 0F;
            this.CategoryDtl.MultiLine = false;
            this.CategoryDtl.Name = "CategoryDtl";
            this.CategoryDtl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.CategoryDtl.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.CategoryDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CategoryDtl.Text = "00000-0000";
            this.CategoryDtl.Top = 0.1875F;
            this.CategoryDtl.Width = 0.625F;
            // 
            // FullModel
            // 
            this.FullModel.Border.BottomColor = System.Drawing.Color.Black;
            this.FullModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.LeftColor = System.Drawing.Color.Black;
            this.FullModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.RightColor = System.Drawing.Color.Black;
            this.FullModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.TopColor = System.Drawing.Color.Black;
            this.FullModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.CanGrow = false;
            this.FullModel.DataField = "FullModel";
            this.FullModel.Height = 0.125F;
            this.FullModel.Left = 1.375F;
            this.FullModel.MultiLine = false;
            this.FullModel.Name = "FullModel";
            this.FullModel.OutputFormat = resources.GetString("FullModel.OutputFormat");
            this.FullModel.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.FullModel.Text = "123456789012345678901234567890123456";
            this.FullModel.Top = 0.1875F;
            this.FullModel.Width = 2.0625F;
            // 
            // CarMngCode
            // 
            this.CarMngCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.RightColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.TopColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.CanGrow = false;
            this.CarMngCode.DataField = "CarMngCode";
            this.CarMngCode.Height = 0.125F;
            this.CarMngCode.Left = 3.5F;
            this.CarMngCode.MultiLine = false;
            this.CarMngCode.Name = "CarMngCode";
            this.CarMngCode.OutputFormat = resources.GetString("CarMngCode.OutputFormat");
            this.CarMngCode.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.CarMngCode.Text = "123456789012345678";
            this.CarMngCode.Top = 0.1875F;
            this.CarMngCode.Width = 1.0625F;
            // 
            // FirstEntryDate
            // 
            this.FirstEntryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.RightColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.TopColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.CanGrow = false;
            this.FirstEntryDate.DataField = "FirstEntryDate";
            this.FirstEntryDate.Height = 0.125F;
            this.FirstEntryDate.Left = 4.625F;
            this.FirstEntryDate.MultiLine = false;
            this.FirstEntryDate.Name = "FirstEntryDate";
            this.FirstEntryDate.OutputFormat = resources.GetString("FirstEntryDate.OutputFormat");
            this.FirstEntryDate.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.FirstEntryDate.Text = "9999/99";
            this.FirstEntryDate.Top = 0.1875F;
            this.FirstEntryDate.Width = 0.4375F;
            // 
            // SlipNote
            // 
            this.SlipNote.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.CanGrow = false;
            this.SlipNote.DataField = "SlipNote";
            this.SlipNote.Height = 0.125F;
            this.SlipNote.Left = 6.1875F;
            this.SlipNote.MultiLine = false;
            this.SlipNote.Name = "SlipNote";
            this.SlipNote.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.SlipNote.Text = "ぜんかくぜんかくぜんかくぜんかくぜんかくぜんかくぜんかくぜん";
            this.SlipNote.Top = 0.0625F;
            this.SlipNote.Width = 3.375F;
            // 
            // SlipNote2
            // 
            this.SlipNote2.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.CanGrow = false;
            this.SlipNote2.DataField = "SlipNote2";
            this.SlipNote2.Height = 0.125F;
            this.SlipNote2.Left = 6.1875F;
            this.SlipNote2.MultiLine = false;
            this.SlipNote2.Name = "SlipNote2";
            this.SlipNote2.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.SlipNote2.Text = "ぜんかくぜんかくぜんかくぜんかくぜんかく";
            this.SlipNote2.Top = 0.1875F;
            this.SlipNote2.Width = 2.25F;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.CanGrow = false;
            this.CustomerCode.DataField = "PrtCustomerCode";
            this.CustomerCode.Height = 0.125F;
            this.CustomerCode.Left = 0F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.CustomerCode.Text = "99999999";
            this.CustomerCode.Top = 0.0625F;
            this.CustomerCode.Width = 0.5F;
            // 
            // SalesSlipNum
            // 
            this.SalesSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.CanGrow = false;
            this.SalesSlipNum.DataField = "SalesSlipNum";
            this.SalesSlipNum.Height = 0.125F;
            this.SalesSlipNum.Left = 4.125F;
            this.SalesSlipNum.MultiLine = false;
            this.SalesSlipNum.Name = "SalesSlipNum";
            this.SalesSlipNum.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesSlipNum.Text = "999999999";
            this.SalesSlipNum.Top = 0.0625F;
            this.SalesSlipNum.Width = 0.5625F;
            // 
            // CustomerSnm
            // 
            this.CustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.CanGrow = false;
            this.CustomerSnm.DataField = "CustomerSnm";
            this.CustomerSnm.Height = 0.125F;
            this.CustomerSnm.Left = 0.5F;
            this.CustomerSnm.MultiLine = false;
            this.CustomerSnm.Name = "CustomerSnm";
            this.CustomerSnm.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.CustomerSnm.Text = "ぜんかくぜんかくぜんかくぜんか";
            this.CustomerSnm.Top = 0.0625F;
            this.CustomerSnm.Width = 1.75F;
            // 
            // SalesDate
            // 
            this.SalesDate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.CanGrow = false;
            this.SalesDate.DataField = "SalesDate";
            this.SalesDate.Height = 0.125F;
            this.SalesDate.Left = 2.25F;
            this.SalesDate.MultiLine = false;
            this.SalesDate.Name = "SalesDate";
            this.SalesDate.OutputFormat = resources.GetString("SalesDate.OutputFormat");
            this.SalesDate.Style = "color: Black; ddo-char-set: 128; text-align: left; font-weight: normal; font-size" +
                ": 8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.SalesDate.Text = "9999/99/99";
            this.SalesDate.Top = 0.0625F;
            this.SalesDate.Width = 0.625F;
            // 
            // EstimateValidityDate
            // 
            this.EstimateValidityDate.Border.BottomColor = System.Drawing.Color.Black;
            this.EstimateValidityDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateValidityDate.Border.LeftColor = System.Drawing.Color.Black;
            this.EstimateValidityDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateValidityDate.Border.RightColor = System.Drawing.Color.Black;
            this.EstimateValidityDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateValidityDate.Border.TopColor = System.Drawing.Color.Black;
            this.EstimateValidityDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateValidityDate.CanGrow = false;
            this.EstimateValidityDate.DataField = "EstimateValidityDate";
            this.EstimateValidityDate.Height = 0.125F;
            this.EstimateValidityDate.Left = 3.5F;
            this.EstimateValidityDate.MultiLine = false;
            this.EstimateValidityDate.Name = "EstimateValidityDate";
            this.EstimateValidityDate.OutputFormat = resources.GetString("EstimateValidityDate.OutputFormat");
            this.EstimateValidityDate.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.EstimateValidityDate.Text = "9999/99/99";
            this.EstimateValidityDate.Top = 0.0625F;
            this.EstimateValidityDate.Width = 0.625F;
            // 
            // SalesEmployeeNm
            // 
            this.SalesEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.CanGrow = false;
            this.SalesEmployeeNm.DataField = "SalesEmployeeNm";
            this.SalesEmployeeNm.Height = 0.125F;
            this.SalesEmployeeNm.Left = 5.375F;
            this.SalesEmployeeNm.MultiLine = false;
            this.SalesEmployeeNm.Name = "SalesEmployeeNm";
            this.SalesEmployeeNm.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; white-space: " +
                "inherit; vertical-align: top; ";
            this.SalesEmployeeNm.Text = "販売従業員名称";
            this.SalesEmployeeNm.Top = 0.0625F;
            this.SalesEmployeeNm.Width = 0.8125F;
            // 
            // SearchSlipDate
            // 
            this.SearchSlipDate.Border.BottomColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.LeftColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.RightColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.TopColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.CanGrow = false;
            this.SearchSlipDate.DataField = "SearchSlipDate";
            this.SearchSlipDate.Height = 0.125F;
            this.SearchSlipDate.Left = 2.875F;
            this.SearchSlipDate.MultiLine = false;
            this.SearchSlipDate.Name = "SearchSlipDate";
            this.SearchSlipDate.OutputFormat = resources.GetString("SearchSlipDate.OutputFormat");
            this.SearchSlipDate.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.SearchSlipDate.Text = "9999/99/99";
            this.SearchSlipDate.Top = 0.0625F;
            this.SearchSlipDate.Width = 0.625F;
            // 
            // EstimateFormNo
            // 
            this.EstimateFormNo.Border.BottomColor = System.Drawing.Color.Black;
            this.EstimateFormNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateFormNo.Border.LeftColor = System.Drawing.Color.Black;
            this.EstimateFormNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateFormNo.Border.RightColor = System.Drawing.Color.Black;
            this.EstimateFormNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateFormNo.Border.TopColor = System.Drawing.Color.Black;
            this.EstimateFormNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateFormNo.CanGrow = false;
            this.EstimateFormNo.DataField = "EstimateFormNo";
            this.EstimateFormNo.Height = 0.125F;
            this.EstimateFormNo.Left = 9.625F;
            this.EstimateFormNo.MultiLine = false;
            this.EstimateFormNo.Name = "EstimateFormNo";
            this.EstimateFormNo.OutputFormat = resources.GetString("EstimateFormNo.OutputFormat");
            this.EstimateFormNo.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: nowrap; vertical-align: top; ";
            this.EstimateFormNo.Text = "012345678901234";
            this.EstimateFormNo.Top = 0.0625F;
            this.EstimateFormNo.Visible = false;
            this.EstimateFormNo.Width = 1.125F;
            // 
            // EstimateDivideNm
            // 
            this.EstimateDivideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.EstimateDivideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateDivideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.EstimateDivideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateDivideNm.Border.RightColor = System.Drawing.Color.Black;
            this.EstimateDivideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateDivideNm.Border.TopColor = System.Drawing.Color.Black;
            this.EstimateDivideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EstimateDivideNm.CanGrow = false;
            this.EstimateDivideNm.DataField = "EstimateDivideNm";
            this.EstimateDivideNm.Height = 0.125F;
            this.EstimateDivideNm.Left = 4.6875F;
            this.EstimateDivideNm.MultiLine = false;
            this.EstimateDivideNm.Name = "EstimateDivideNm";
            this.EstimateDivideNm.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.EstimateDivideNm.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.EstimateDivideNm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EstimateDivideNm.Text = "検索見積分";
            this.EstimateDivideNm.Top = 0.0625F;
            this.EstimateDivideNm.Width = 0.625F;
            // 
            // SlipNote3
            // 
            this.SlipNote3.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.CanGrow = false;
            this.SlipNote3.DataField = "SlipNote3";
            this.SlipNote3.Height = 0.125F;
            this.SlipNote3.Left = 8.5F;
            this.SlipNote3.MultiLine = false;
            this.SlipNote3.Name = "SlipNote3";
            this.SlipNote3.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.SlipNote3.Text = "ぜんかくぜんかくぜんかくぜんかくぜんかく";
            this.SlipNote3.Top = 0.1875F;
            this.SlipNote3.Width = 2.25F;
            // 
            // AcceptOrOrderKindRF
            // 
            this.AcceptOrOrderKindRF.Border.BottomColor = System.Drawing.Color.Black;
            this.AcceptOrOrderKindRF.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptOrOrderKindRF.Border.LeftColor = System.Drawing.Color.Black;
            this.AcceptOrOrderKindRF.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptOrOrderKindRF.Border.RightColor = System.Drawing.Color.Black;
            this.AcceptOrOrderKindRF.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptOrOrderKindRF.Border.TopColor = System.Drawing.Color.Black;
            this.AcceptOrOrderKindRF.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptOrOrderKindRF.CanGrow = false;
            this.AcceptOrOrderKindRF.DataField = "AcceptOrOrderKindRF";
            this.AcceptOrOrderKindRF.Height = 0.15F;
            this.AcceptOrOrderKindRF.Left = 9.375F;
            this.AcceptOrOrderKindRF.MultiLine = false;
            this.AcceptOrOrderKindRF.Name = "AcceptOrOrderKindRF";
            this.AcceptOrOrderKindRF.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.AcceptOrOrderKindRF.Text = "123456789012";
            this.AcceptOrOrderKindRF.Top = 0.1875F;
            this.AcceptOrOrderKindRF.Width = 0.63F;
            // 
            // AutoAnswerDivSCMRF
            // 
            this.AutoAnswerDivSCMRF.Border.BottomColor = System.Drawing.Color.Black;
            this.AutoAnswerDivSCMRF.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AutoAnswerDivSCMRF.Border.LeftColor = System.Drawing.Color.Black;
            this.AutoAnswerDivSCMRF.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AutoAnswerDivSCMRF.Border.RightColor = System.Drawing.Color.Black;
            this.AutoAnswerDivSCMRF.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AutoAnswerDivSCMRF.Border.TopColor = System.Drawing.Color.Black;
            this.AutoAnswerDivSCMRF.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AutoAnswerDivSCMRF.CanGrow = false;
            this.AutoAnswerDivSCMRF.DataField = "AutoAnswerDivSCMRF";
            this.AutoAnswerDivSCMRF.Height = 0.15F;
            this.AutoAnswerDivSCMRF.Left = 10.0625F;
            this.AutoAnswerDivSCMRF.MultiLine = false;
            this.AutoAnswerDivSCMRF.Name = "AutoAnswerDivSCMRF";
            this.AutoAnswerDivSCMRF.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.AutoAnswerDivSCMRF.Text = "あいうえ1";
            this.AutoAnswerDivSCMRF.Top = 0.1875F;
            this.AutoAnswerDivSCMRF.Width = 0.46F;
            // 
            // SalesSlipFooter
            // 
            this.SalesSlipFooter.CanShrink = true;
            this.SalesSlipFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.Sl_Title,
            this.Sl_SalesMoneyTaxExc});
            this.SalesSlipFooter.Height = 0.3020833F;
            this.SalesSlipFooter.KeepTogether = true;
            this.SalesSlipFooter.Name = "SalesSlipFooter";
            // 
            // Line45
            // 
            this.Line45.Border.BottomColor = System.Drawing.Color.Black;
            this.Line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.LeftColor = System.Drawing.Color.Black;
            this.Line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.RightColor = System.Drawing.Color.Black;
            this.Line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.TopColor = System.Drawing.Color.Black;
            this.Line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Height = 0F;
            this.Line45.Left = 0F;
            this.Line45.LineWeight = 2F;
            this.Line45.Name = "Line45";
            this.Line45.Top = 0F;
            this.Line45.Width = 10.8F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // Sl_Title
            // 
            this.Sl_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Sl_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Sl_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Sl_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Sl_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_Title.Height = 0.1875F;
            this.Sl_Title.Left = 5.75F;
            this.Sl_Title.MultiLine = false;
            this.Sl_Title.Name = "Sl_Title";
            this.Sl_Title.OutputFormat = resources.GetString("Sl_Title.OutputFormat");
            this.Sl_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Sl_Title.Text = "伝票計";
            this.Sl_Title.Top = 0.0625F;
            this.Sl_Title.Width = 0.6875F;
            // 
            // Sl_SalesMoneyTaxExc
            // 
            this.Sl_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Sl_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Sl_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Sl_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Sl_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Sl_SalesMoneyTaxExc.Height = 0.125F;
            this.Sl_SalesMoneyTaxExc.Left = 9.875F;
            this.Sl_SalesMoneyTaxExc.MultiLine = false;
            this.Sl_SalesMoneyTaxExc.Name = "Sl_SalesMoneyTaxExc";
            this.Sl_SalesMoneyTaxExc.OutputFormat = resources.GetString("Sl_SalesMoneyTaxExc.OutputFormat");
            this.Sl_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sl_SalesMoneyTaxExc.SummaryGroup = "SalesSlipHeader";
            this.Sl_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sl_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sl_SalesMoneyTaxExc.Text = "123,456,789";
            this.Sl_SalesMoneyTaxExc.Top = 0.0625F;
            this.Sl_SalesMoneyTaxExc.Width = 0.8125F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.DataField = "CustomerCode";
            this.CustomerHeader.Height = 0F;
            this.CustomerHeader.Name = "CustomerHeader";
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.Cus_Title,
            this.Cus_SalesMoneyTaxExc});
            this.CustomerFooter.Height = 0.3020833F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
            // 
            // Line44
            // 
            this.Line44.Border.BottomColor = System.Drawing.Color.Black;
            this.Line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.LeftColor = System.Drawing.Color.Black;
            this.Line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.RightColor = System.Drawing.Color.Black;
            this.Line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.TopColor = System.Drawing.Color.Black;
            this.Line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Height = 0F;
            this.Line44.Left = 0F;
            this.Line44.LineWeight = 2F;
            this.Line44.Name = "Line44";
            this.Line44.Top = 0F;
            this.Line44.Width = 10.8F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 10.8F;
            this.Line44.Y1 = 0F;
            this.Line44.Y2 = 0F;
            // 
            // Cus_Title
            // 
            this.Cus_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Height = 0.1875F;
            this.Cus_Title.Left = 5.75F;
            this.Cus_Title.MultiLine = false;
            this.Cus_Title.Name = "Cus_Title";
            this.Cus_Title.OutputFormat = resources.GetString("Cus_Title.OutputFormat");
            this.Cus_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Cus_Title.Text = "得意先計";
            this.Cus_Title.Top = 0.0625F;
            this.Cus_Title.Width = 0.9375F;
            // 
            // Cus_SalesMoneyTaxExc
            // 
            this.Cus_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Cus_SalesMoneyTaxExc.Height = 0.125F;
            this.Cus_SalesMoneyTaxExc.Left = 9.875F;
            this.Cus_SalesMoneyTaxExc.MultiLine = false;
            this.Cus_SalesMoneyTaxExc.Name = "Cus_SalesMoneyTaxExc";
            this.Cus_SalesMoneyTaxExc.OutputFormat = resources.GetString("Cus_SalesMoneyTaxExc.OutputFormat");
            this.Cus_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_SalesMoneyTaxExc.SummaryGroup = "CustomerHeader";
            this.Cus_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_SalesMoneyTaxExc.Text = "123,456,789";
            this.Cus_SalesMoneyTaxExc.Top = 0.0625F;
            this.Cus_SalesMoneyTaxExc.Width = 0.8125F;
            // 
            // SalesDateHeader
            // 
            this.SalesDateHeader.CanShrink = true;
            this.SalesDateHeader.DataField = "SalesDate";
            this.SalesDateHeader.Height = 0.1666667F;
            this.SalesDateHeader.Name = "SalesDateHeader";
            // 
            // SalesDateFooter
            // 
            this.SalesDateFooter.CanShrink = true;
            this.SalesDateFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.line3,
            this.Sal_SalesMoneyTaxExc});
            this.SalesDateFooter.Height = 0.2916667F;
            this.SalesDateFooter.KeepTogether = true;
            this.SalesDateFooter.Name = "SalesDateFooter";
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 5.75F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox1.Text = "見積日計";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.6875F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // Sal_SalesMoneyTaxExc
            // 
            this.Sal_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Sal_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sal_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Sal_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sal_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Sal_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sal_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Sal_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sal_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Sal_SalesMoneyTaxExc.Height = 0.125F;
            this.Sal_SalesMoneyTaxExc.Left = 9.875F;
            this.Sal_SalesMoneyTaxExc.MultiLine = false;
            this.Sal_SalesMoneyTaxExc.Name = "Sal_SalesMoneyTaxExc";
            this.Sal_SalesMoneyTaxExc.OutputFormat = resources.GetString("Sal_SalesMoneyTaxExc.OutputFormat");
            this.Sal_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sal_SalesMoneyTaxExc.SummaryGroup = "SalesDateHeader";
            this.Sal_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sal_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sal_SalesMoneyTaxExc.Text = "123,456,789";
            this.Sal_SalesMoneyTaxExc.Top = 0.0625F;
            this.Sal_SalesMoneyTaxExc.Width = 0.8125F;
            // 
            // DCMIT02102P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 10.8125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.SalesDateHeader);
            this.Sections.Add(this.SalesSlipHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SalesSlipFooter);
            this.Sections.Add(this.SalesDateFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.PageEnd += new System.EventHandler(this.DCMIT02102P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCMIT02102P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.SlipMemo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipMemo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipMemo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsideMemo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsideMemo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsideMemo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCdDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcptAnOdrRemainCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SlipMemo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SlipMemo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SlipMemo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InsideMemo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InsideMemo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InsideMemo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarMngCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateValidityDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchSlipDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateFormNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateDivideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptOrOrderKindRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnswerDivSCMRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sal_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 伝票ヘッダ印字前イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesSlipHeader_BeforePrint( object sender, EventArgs e )
        {
            // 2008.08.01 30413 犬飼 非印字制御の変更 >>>>>>START
            //// 日付未入力は非印字
            //if (Sl_SalesDate.Text == DateTime.MinValue.ToString())
            //{
            //    Sl_SalesDate.Text = string.Empty;
            //}
            //// 日付未入力は非印字
            //if (Sl_SearchSlipDate.Text == DateTime.MinValue.ToString())
            //{
            //    Sl_SearchSlipDate.Text = string.Empty;
            //}
            // 見積日付未入力は非印字
            if ( SalesDate.Text == DateTime.MinValue.ToString() )
            {
                SalesDate.Text = string.Empty;
            }
            // 入力日付未入力は非印字
            if ( SearchSlipDate.Text == DateTime.MinValue.ToString() )
            {
                SearchSlipDate.Text = string.Empty;
            }
            // 2008.08.01 30413 犬飼 非印字制御の変更 <<<<<<END
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
	}
}
