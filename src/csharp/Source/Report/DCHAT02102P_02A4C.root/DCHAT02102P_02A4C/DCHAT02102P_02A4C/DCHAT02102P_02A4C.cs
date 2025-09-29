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
	/// 発注一覧表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 発注一覧表のフォームクラスです。</br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2007.09.19</br>
    /// <br></br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : PM.NS対応(DCHAT02102P_01A4Cがベース)</br>
    /// <br>Programmer   : 犬飼</br>
    /// <br>Date	     : 2008.09.04</br>
    /// <br></br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : Mantis:14894　フォントサイズを大きくし明細毎に罫線が引かれるように変更（デザイン修正のみ）</br>
    /// <br>Programmer   : 夏野 駿希</br>
    /// <br>Date	     : 2009/01/18</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date	     : 2017/09/14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : ㈱ダイサブの対応</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date         : 2019/11/05</br>
    /// <br>管理番号     : 11570226-00</br>
    /// -----------------------------------------------------------------------------------
    /// </remarks>
	public class DCHAT02102P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 発注一覧表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note         : 発注一覧表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer   : 22018　鈴木　正臣</br>
		/// <br>Date         : 2007.09.19</br>
        /// -----------------------------------------------------------------------------------
        /// <br>UpdateNote   : PM.NS対応</br>
        /// <br>Programmer   : 犬飼</br>
        /// <br>Date	     : 2008.09.03</br>
        /// </remarks>
		public DCHAT02102P_02A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									// 印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				// 抽出条件
		private int					_pageFooterOutCode;				// フッター出力区分
		private StringCollection	_pageFooters;					// フッターメッセージ
		private	SFCMN06002C			_printInfo;						// 印刷情報クラス
		private string				_pageHeaderTitle;				// フォームタイトル
		private string				_pageHeaderSortOderTitle;		// ソート順

        private OrderListCndtn _orderListCndtn;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Label Lb_OrderFormPrintDate;
        private GroupHeader Header1;
        private GroupFooter Footer1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox ProcessDay;
        private TextBox SectionCode;
        private TextBox SectionGuideSnm;
        private TextBox WarehouseCode;
        private TextBox EnterpriseName1;
        private TextBox EnterpriseName2;
        private Label label16;
        private TextBox EnterpriseTel;
        private Label label17;
        private TextBox EnterpriseFax;
        private Label Lb_MinStockCount;
        private Label Lb_MaxStockCount;
        private Label Lb_ShipmentCnt;
        private TextBox SupplierCodePrint;
        private Line line10;
        private TextBox SupplierName;
        private TextBox ShipmentPosCnt;
        private TextBox MinimumStockCnt;
        private TextBox MaximumStockCnt;
        private TextBox ShipmentCnt;
        private TextBox DetailCount;
        private TextBox f_SalesOrderCountLotCalc;
        private Label label1;
        private TextBox WarehouseName;
        private Line line2;
        private Barcode BC_SupplierSeqNo;
        private TextBox textBox_Space;
        private GroupHeader groupHeader_MakeCd;
        private GroupFooter groupFooter1;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Line line3;
        private Label label_MakeCd;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label18;
        private Label label19;

		// Disposeチェック用フラグ
		bool disposed = false;

		#endregion ■ Private Member

		#region ■ Dispose(override)
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						// ヘッダ用サブレポート後処理実行
						if (this._rptExtraHeader != null)
						{
							this._rptExtraHeader.Dispose();
						}

						// フッタ用サブレポート後処理実行
						if (this._rptPageFooter != null)
						{
							this._rptPageFooter.Dispose();
						}
					}

					this.disposed = true;
				}
				finally
				{
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
			set{ _pageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{ _extraCondHeadOutDiv = value; }
		}
		
		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set{ this._extraConditions = value; }
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set{ this._pageFooterOutCode = value; }
		}
		
		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set{ this._pageFooters = value; }
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo			= value;
				this._orderListCndtn	= (OrderListCndtn)this._printInfo.jyoken;
			}
		}

		/// <summary>
		/// その他データ
		/// </summary>
		public ArrayList OtherDataList
		{
			set	{ }
		}

		/// <summary>
		/// 帳票サブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderTitle = value;}
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
				// TODO:  DCZAI02163P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  DCZAI02163P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// <br>Note        : ㈱ダイサブの対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2019/11/05</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            #region ＜＜　合計行の印字有無制御　＞＞
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._orderListCndtn.IsOptSection ) {
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._orderListCndtn.SectionCodes.Length < 2 ) ||
            //        this._orderListCndtn.IsSelectAllSection ) {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else {
            //        SectionHeader.DataField = DCHAT02105EA.ct_Col_Sort_SectionCode;
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

            // 一度、全ての計を無効にする

            // 2008.09.03 30413 犬飼 削除項目 >>>>>>START
            //// 希望納期
            //ExpectDeliveryDateHeader.DataField = string.Empty;
            //ExpectDeliveryDateHeader.Visible = false;
            //ExpectDeliveryDateFooter.Visible = false;
            //// メーカー
            //MakerHeader.DataField = string.Empty;
            //MakerHeader.Visible = false;
            //MakerFooter.Visible = false;
            //// 商品番号
            //GoodsNoHeader.DataField = string.Empty;
            //GoodsNoHeader.Visible = false;
            //GoodsNoFooter.Visible = false;
            //// 発注日（発注書発行日）
            //Header1.DataField = string.Empty;
            //Header1.Visible = false;
            //Footer1.Visible = false;
            //// 入力日
            //OrderDataCreateDateHeader.DataField = string.Empty;
            //OrderDataCreateDateHeader.Visible = false;
            //OrderDataCreateDateFooter.Visible = false;
            //// 発注先
            //SupplierHeader.DataField = string.Empty;
            //SupplierHeader.Visible = false;
            //SupplierFooter.Visible = false;
            
            
            //// 画面指定に従い、対応する計を有効にする
            //switch ( _orderListCndtn.PrintSortDiv )
            //{
            //    case OrderListCndtn.PrintSortDivState.ByExpectDeliveryDate:
            //        // 希望納期
            //        ExpectDeliveryDateHeader.DataField = DCHAT02104EA.ct_Col_ExpectDeliveryDate;
            //        ExpectDeliveryDateHeader.Visible = true;
            //        ExpectDeliveryDateFooter.Visible = true;
            //        break;
            //    case OrderListCndtn.PrintSortDivState.ByMakerGoodsSalesOrderDate:
            //        // メーカー
            //        MakerHeader.DataField = DCHAT02104EA.ct_Col_GoodsMakerCd;
            //        MakerHeader.Visible = true;
            //        MakerFooter.Visible = true;
            //        // 商品番号
            //        GoodsNoHeader.DataField = DCHAT02104EA.ct_Col_GoodsNo;
            //        GoodsNoHeader.Visible = true;
            //        GoodsNoFooter.Visible = true;
            //        // 発注日（発注書発行日）
            //        Header1.DataField = DCHAT02104EA.ct_Col_OrderFormPrintDate;
            //        Header1.Visible = true;
            //        Footer1.Visible = true;
            //        break;
            //    case OrderListCndtn.PrintSortDivState.ByOrderDataCreateDate:
            //        // 入力日
            //        OrderDataCreateDateHeader.DataField = DCHAT02104EA.ct_Col_OrderDataCreateDate;
            //        OrderDataCreateDateHeader.Visible = true;
            //        OrderDataCreateDateFooter.Visible = true;
            //        break;
            //    case OrderListCndtn.PrintSortDivState.ByOrderFormPrintDate:
            //        // 発注日（発注書発行日）
            //        Header1.DataField = DCHAT02104EA.ct_Col_OrderFormPrintDate;
            //        Header1.Visible = true;
            //        Footer1.Visible = true;
            //        break;
            //    case OrderListCndtn.PrintSortDivState.BySupplierSalesOrderDate:
            //        // 発注先
            //        SupplierHeader.DataField = DCHAT02104EA.ct_Col_SupplierCd;
            //        SupplierHeader.Visible = true;
            //        SupplierFooter.Visible = true;
            //        // 発注日（発注書発行日）
            //        Header1.DataField = DCHAT02104EA.ct_Col_OrderFormPrintDate;
            //        Header1.Visible = true;
            //        Footer1.Visible = true;
            //        break;
            //    default:
            //        break;
            //}
            // 2008.09.03 30413 犬飼 削除項目 <<<<<<END
            
            #endregion ＜＜　合計行の印字有無制御　＞＞

            // 2008.09.03 30413 犬飼 削除項目 >>>>>>START
            //# region ＜＜　メモ印刷有無　＞＞
            //if (this._orderListCndtn.NotePrintDiv == OrderListCndtn.NotePrintDivState.None) {
            //    // メモ印刷しない
            //    Lb_SlipMemo1.Visible = false;
            //    Lb_SlipMemo2.Visible = false;
            //    Lb_SlipMemo3.Visible = false;
            //    Lb_SlipMemo4.Visible = false;
            //    Lb_SlipMemo5.Visible = false;
            //    Lb_SlipMemo6.Visible = false;
            //    Lb_InsideMemo1.Visible = false;
            //    Lb_InsideMemo2.Visible = false;
            //    Lb_InsideMemo3.Visible = false;
            //    Lb_InsideMemo4.Visible = false;
            //    Lb_InsideMemo5.Visible = false;
            //    Lb_InsideMemo6.Visible = false;

            //    //SlipMemo1.Visible = false;
            //    //SlipMemo2.Visible = false;
            //    //SlipMemo3.Visible = false;
            //    //SlipMemo4.Visible = false;
            //    //SlipMemo5.Visible = false;
            //    //SlipMemo6.Visible = false;
            //    //InsideMemo1.Visible = false;
            //    //InsideMemo2.Visible = false;
            //    //InsideMemo3.Visible = false;
            //    //InsideMemo4.Visible = false;
            //    //InsideMemo5.Visible = false;
            //    //InsideMemo6.Visible = false;
            //}
            //else {
            //    // メモ印刷する
            //    Lb_SlipMemo1.Visible = true;
            //    Lb_SlipMemo2.Visible = true;
            //    Lb_SlipMemo3.Visible = true;
            //    Lb_SlipMemo4.Visible = true;
            //    Lb_SlipMemo5.Visible = true;
            //    Lb_SlipMemo6.Visible = true;
            //    Lb_InsideMemo1.Visible = true;
            //    Lb_InsideMemo2.Visible = true;
            //    Lb_InsideMemo3.Visible = true;
            //    Lb_InsideMemo4.Visible = true;
            //    Lb_InsideMemo5.Visible = true;
            //    Lb_InsideMemo6.Visible = true;

            //    //SlipMemo1.Visible = true;
            //    //SlipMemo2.Visible = true;
            //    //SlipMemo3.Visible = true;
            //    //SlipMemo4.Visible = true;
            //    //SlipMemo5.Visible = true;
            //    //SlipMemo6.Visible = true;
            //    //InsideMemo1.Visible = true;
            //    //InsideMemo2.Visible = true;
            //    //InsideMemo3.Visible = true;
            //    //InsideMemo4.Visible = true;
            //    //InsideMemo5.Visible = true;
            //    //InsideMemo6.Visible = true;
            //}
            //# endregion ＜＜　メモ印刷有無　＞＞
            // 2008.09.03 30413 犬飼 削除項目 <<<<<<END

            // 2008.09.03 30413 犬飼 印字制御の追加 >>>>>>START
            if (this._orderListCndtn.NewPageDiv == 1)
            {
                // 改頁しない
                //Header1.DataField = "";
                Header1.NewPage = NewPage.None;
            }
            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
            if (this._orderListCndtn.MakerCdDiv == 1)
            {
                groupHeader_MakeCd.Visible = false;
                label_MakeCd.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
            }
            else
            {
                Lb_OrderFormPrintDate.Visible = false;
                Lb_ExpectDeliveryDate.Visible = false;
                Lb_MakerName.Visible = false;
                Lb_OrderAndAdjustCnt.Visible = false;
                Lb_ShipmentPosCnt.Visible = false;
                Lb_MinStockCount.Visible = false;
                Lb_MaxStockCount.Visible = false;
                Lb_ShipmentCnt.Visible = false;
            }
            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<

            if (this._orderListCndtn.StockMinMaxPrintDiv == 1)
            {
                // 現在庫・最低・最高を印字しない
                Lb_ShipmentPosCnt.Visible = false;
                Lb_MinStockCount.Visible = false;
                Lb_MaxStockCount.Visible = false;
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                label8.Visible = false;
                label9.Visible = false;
                label18.Visible = false;
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                ShipmentPosCnt.Visible = false;
                MinimumStockCnt.Visible = false;
                MaximumStockCnt.Visible = false;
            }

            if (this._orderListCndtn.LendCntPrintDiv == 1)
            {
                // 貸出数を印字しない
                Lb_ShipmentCnt.Visible = false;
                ShipmentCnt.Visible = false;
                label19.Visible = false; // ADD 2019/11/05 譚洪 ㈱ダイサブの対応
            }
            // 2008.09.03 30413 犬飼 印字制御の追加 <<<<<<END
            
        }
		#endregion ◆ レポート要素出力設定


		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。
		}
		#endregion
		#endregion
		#endregion

		#region ■ Control Event

        #region ◎ DCHAT02102P_02A4C_ReportStart Event
        /// <summary>
        /// DCHAT02102P_02A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void DCHAT02102P_02A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

        #region ◎ DCHAT02102P_02A4C_PageEnd Event
        /// <summary>
        /// DCHAT02102P_02A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: DCZAI02163P_01A4C_PageEnd Event</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void DCHAT02102P_02A4C_PageEnd(object sender, System.EventArgs eArgs)
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
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( OrderListCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
            // 2008.09.03 30413 犬飼 削除項目 >>>>>>START
            //// 印刷順
            //this.tb_ReportSort.Text = string.Format( "[ {0} ]", this._pageHeaderSortOderTitle );
            // 2008.09.03 30413 犬飼 削除項目 <<<<<<END
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
			if ( this._rptExtraHeader == null)
			{
				this._rptExtraHeader = new ListCommon_ExtraHeader();
			}
			else
			{
				// インスタンスが作成されていれば、データソースを初期化する
				// (バインドするデータソースが同じデータであっても、一度初期化しないとうまく印刷されない為。)
				this._rptExtraHeader.DataSource = null;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 拠点オプション有無判定
            //string sectionTitle = string.Format( "{0}拠点：", this._orderListCndtn.MainExtractTitle );
            //if ( this._orderListCndtn.IsOptSection )
            //{
            //    if ( this._orderListCndtn.IsSelectAllSection )
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

            // 2008.09.03 30413 犬飼 削除項目 >>>>>>START
            //// 抽出条件印字項目設定
            //this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
            //this.Header_SubReport.Report = this._rptExtraHeader;
            // 2008.09.03 30413 犬飼 削除項目 <<<<<<END
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
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // 2008.09.03 30413 犬飼 削除項目 >>>>>>START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////--------------------------------------------
            //// 未発注マークのセット ("未")
            ////--------------------------------------------
            //// 区分値取得
            //int orderFormIssuedDivValue = 0;
            //try
            //{
            //    if ( Int32.Parse( OrderFormIssuedDiv.Text ) == 0 )
            //    {
            //        orderFormIssuedDivValue = 0;
            //    }
            //    else
            //    {
            //        orderFormIssuedDivValue = 1;
            //    }
            //}
            //catch
            //{
            //    orderFormIssuedDivValue = 0;
            //}
            //// マークセット
            //if ( orderFormIssuedDivValue == 0 )
            //{
            //    OrderFormIssuedDivMark.Text = "未";
            //}
            //else
            //{
            //    OrderFormIssuedDivMark.Text = "";
            //}
            // 2008.09.03 30413 犬飼 削除項目 <<<<<<END
            
            //--------------------------------------------
            // メモがなければ印字しない
            //--------------------------------------------

            //List<string> memoList = new List<string>();
            //memoList.AddRange( new string[] {   DCHAT02104EA.ct_Col_SlipMemo1, DCHAT02104EA.ct_Col_SlipMemo2, DCHAT02104EA.ct_Col_SlipMemo3,
            //                                    DCHAT02104EA.ct_Col_SlipMemo4, DCHAT02104EA.ct_Col_SlipMemo5, DCHAT02104EA.ct_Col_SlipMemo6,
            //                                    DCHAT02104EA.ct_Col_InsideMemo1, DCHAT02104EA.ct_Col_InsideMemo2, DCHAT02104EA.ct_Col_InsideMemo3,
            //                                    DCHAT02104EA.ct_Col_InsideMemo4, DCHAT02104EA.ct_Col_InsideMemo5, DCHAT02104EA.ct_Col_InsideMemo6 } );
            //List<TextBox> tbMemoList = new List<TextBox>();
            //tbMemoList.AddRange( new TextBox[] { SlipMemo1, SlipMemo2, SlipMemo3, SlipMemo4, SlipMemo5, SlipMemo6 } );
            //tbMemoList.AddRange( new TextBox[] { InsideMemo1, InsideMemo2, InsideMemo3, InsideMemo4, InsideMemo5, InsideMemo6 } );

            //bool printMemo = false;

            //if ( this._orderListCndtn.NotePrintDiv == OrderListCndtn.NotePrintDivState.Print )
            //{
            //    // メモ有無チェック
            //    foreach ( string memoField in memoList )
            //    {
            //        if ( (string)Fields[memoField].Value != string.Empty )
            //        {
            //            printMemo = true;
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    printMemo = false;
            //}

            //// すべてのメモのVisibleを設定
            //foreach ( TextBox tbMemo in tbMemoList )
            //{
            //    tbMemo.Visible = printMemo;
            //}

            // 2008.09.03 30413 犬飼 削除項目 >>>>>>START
            //List<TextBox> tbMemoList = new List<TextBox>();
            //tbMemoList.AddRange( new TextBox[] { SlipMemo1, SlipMemo2, SlipMemo3, SlipMemo4, SlipMemo5, SlipMemo6 } );
            //tbMemoList.AddRange( new TextBox[] { InsideMemo1, InsideMemo2, InsideMemo3, InsideMemo4, InsideMemo5, InsideMemo6 } );

            //if ( this._orderListCndtn.NotePrintDiv == OrderListCndtn.NotePrintDivState.Print )
            //{
            //    // メモ印刷する（Textがあるもののみ印字）
            //    foreach ( TextBox tbMemo in tbMemoList )
            //    {
            //        if ( string.IsNullOrEmpty( tbMemo.Text ) )
            //        {
            //            tbMemo.Visible = false;
            //        }
            //        else
            //        {
            //            tbMemo.Visible = true;
            //        }
            //    }
            //}
            //else
            //{
            //    // メモ印刷しない
            //    foreach ( TextBox tbMemo in tbMemoList )
            //    {
            //        tbMemo.Visible = false;
            //    }
            //}
            // 2008.09.03 30413 犬飼 削除項目 <<<<<<END
            
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
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
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			// フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
				// インスタンスが作成されていなければ作成
				if ( _rptPageFooter == null)
				{
					_rptPageFooter = new ListCommon_PageFooter();
				}
				else
				{
					// インスタンスが作成されていれば、データソースを初期化する
					// (バインドするデータソースが同じデータであっても、一度初期化しないとうまく印刷されない為。)
					_rptPageFooter.DataSource = null;
				}
		
				// フッター印字項目設定
				if (this._pageFooters[0] != null)
				{
					_rptPageFooter.PrintFooter1 = this._pageFooters[0];
				}
				if (this._pageFooters[1] != null)
				{
					_rptPageFooter.PrintFooter2 = this._pageFooters[1];
				}

                // 2009.03.17 30413 犬飼 フッター部の印字変更 >>>>>>START
                // 2008.11.10 30413 犬飼 最下行の罫線を印字しないようにサブレポートの設定をコメント化 >>>>>>START
                this.Footer_SubReport.Report = _rptPageFooter;
                // 2008.11.10 30413 犬飼 最下行の罫線を印字しないようにサブレポートの設定をコメント化 <<<<<<END
                // 2009.03.17 30413 犬飼 フッター部の印字変更 <<<<<<END
            }
		}
		#endregion

        #region ◎ ExtraHeader_BeforePrint Event
        /// <summary>
        /// ExtraHeader_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ExtraHeaderグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.09.03</br>
        /// </remarks>
        private void ExtraHeader_BeforePrint(object sender, EventArgs e)
        {
            // 集計グループをExtraHeaderに設定
            this.DetailCount.SummaryGroup = "ExtraHeader";
            this.f_SalesOrderCountLotCalc.SummaryGroup = "ExtraHeader";
        }
        #endregion

        #region ◎ Header1_BeforePrint Event
        /// <summary>
        /// Header1_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Header1グループのBeforePrintイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.09.03</br>
        /// </remarks>
        private void Header1_BeforePrint(object sender, EventArgs e)
        {
            // 集計グループをHeader1に設定
            this.DetailCount.SummaryGroup = "Header1";
            this.f_SalesOrderCountLotCalc.SummaryGroup = "Header1";
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
        private DataDynamics.ActiveReports.Label Lb_OrderAndAdjustCnt;
		private DataDynamics.ActiveReports.Label Lb_ExpectDeliveryDate;
		private DataDynamics.ActiveReports.Label Lb_MakerName;
		private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Label Lb_OrderNumber;
        private DataDynamics.ActiveReports.Label Lb_ShipmentPosCnt;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox WarehouseShelfNo;
        private DataDynamics.ActiveReports.TextBox GoodsName;
        private DataDynamics.ActiveReports.TextBox GoodsNo;
        private DataDynamics.ActiveReports.TextBox SalesOrderCountLotCalc;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
        private DataDynamics.ActiveReports.Line Line43;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHAT02102P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.SalesOrderCountLotCalc = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
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
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.ProcessDay = new DataDynamics.ActiveReports.TextBox();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.EnterpriseName1 = new DataDynamics.ActiveReports.TextBox();
            this.EnterpriseName2 = new DataDynamics.ActiveReports.TextBox();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.EnterpriseTel = new DataDynamics.ActiveReports.TextBox();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.EnterpriseFax = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_OrderAndAdjustCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_OrderFormPrintDate = new DataDynamics.ActiveReports.Label();
            this.Lb_ExpectDeliveryDate = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerName = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Lb_OrderNumber = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentPosCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_MinStockCount = new DataDynamics.ActiveReports.Label();
            this.Lb_MaxStockCount = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.label_MakeCd = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.DetailCount = new DataDynamics.ActiveReports.TextBox();
            this.f_SalesOrderCountLotCalc = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Header1 = new DataDynamics.ActiveReports.GroupHeader();
            this.SupplierCodePrint = new DataDynamics.ActiveReports.TextBox();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.SupplierName = new DataDynamics.ActiveReports.TextBox();
            this.BC_SupplierSeqNo = new DataDynamics.ActiveReports.Barcode();
            this.textBox_Space = new DataDynamics.ActiveReports.TextBox();
            this.Footer1 = new DataDynamics.ActiveReports.GroupFooter();
            this.groupHeader_MakeCd = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCountLotCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderAndAdjustCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderFormPrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ExpectDeliveryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinStockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaxStockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_MakeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_SalesOrderCountLotCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCodePrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Space)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanGrow = false;
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseShelfNo,
            this.GoodsName,
            this.GoodsNo,
            this.SalesOrderCountLotCalc,
            this.ShipmentPosCnt,
            this.MinimumStockCnt,
            this.MaximumStockCnt,
            this.ShipmentCnt,
            this.line2,
            this.textBox3});
            this.Detail.Height = 0.1916667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // WarehouseShelfNo
            // 
            this.WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo.Height = 0.1875F;
            this.WarehouseShelfNo.Left = 0.125F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0F;
            this.WarehouseShelfNo.Width = 0.6875F;
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
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.1875F;
            this.GoodsName.Left = 3F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: top; ";
            this.GoodsName.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.625F;
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
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.1875F;
            this.GoodsNo.Left = 0.875F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.9375F;
            // 
            // SalesOrderCountLotCalc
            // 
            this.SalesOrderCountLotCalc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesOrderCountLotCalc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCountLotCalc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesOrderCountLotCalc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCountLotCalc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesOrderCountLotCalc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCountLotCalc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesOrderCountLotCalc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCountLotCalc.DataField = "SalesOrderCountLotCalc";
            this.SalesOrderCountLotCalc.Height = 0.1875F;
            this.SalesOrderCountLotCalc.Left = 4.625F;
            this.SalesOrderCountLotCalc.MultiLine = false;
            this.SalesOrderCountLotCalc.Name = "SalesOrderCountLotCalc";
            this.SalesOrderCountLotCalc.OutputFormat = resources.GetString("SalesOrderCountLotCalc.OutputFormat");
            this.SalesOrderCountLotCalc.Style = "ddo-char-set: 128; text-align: right; font-size: 11.25pt; font-family: ＭＳ ゴシック; v" +
                "ertical-align: top; ";
            this.SalesOrderCountLotCalc.Text = "123,45678.00";
            this.SalesOrderCountLotCalc.Top = 0F;
            this.SalesOrderCountLotCalc.Width = 1F;
            // 
            // ShipmentPosCnt
            // 
            this.ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.ShipmentPosCnt.Height = 0.1875F;
            this.ShipmentPosCnt.Left = 5.75F;
            this.ShipmentPosCnt.MultiLine = false;
            this.ShipmentPosCnt.Name = "ShipmentPosCnt";
            this.ShipmentPosCnt.OutputFormat = resources.GetString("ShipmentPosCnt.OutputFormat");
            this.ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 11.25pt; font-family: ＭＳ ゴシック; v" +
                "ertical-align: top; ";
            this.ShipmentPosCnt.Text = "123,456.00";
            this.ShipmentPosCnt.Top = 0F;
            this.ShipmentPosCnt.Width = 0.8125F;
            // 
            // MinimumStockCnt
            // 
            this.MinimumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.DataField = "MinimumStockCnt";
            this.MinimumStockCnt.Height = 0.1875F;
            this.MinimumStockCnt.Left = 6.6875F;
            this.MinimumStockCnt.MultiLine = false;
            this.MinimumStockCnt.Name = "MinimumStockCnt";
            this.MinimumStockCnt.OutputFormat = resources.GetString("MinimumStockCnt.OutputFormat");
            this.MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 11.25pt; font-family: ＭＳ ゴシック; v" +
                "ertical-align: top; ";
            this.MinimumStockCnt.Text = "123,456.00";
            this.MinimumStockCnt.Top = 0F;
            this.MinimumStockCnt.Width = 0.8125F;
            // 
            // MaximumStockCnt
            // 
            this.MaximumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.DataField = "MaximumStockCnt";
            this.MaximumStockCnt.Height = 0.1875F;
            this.MaximumStockCnt.Left = 7.625F;
            this.MaximumStockCnt.MultiLine = false;
            this.MaximumStockCnt.Name = "MaximumStockCnt";
            this.MaximumStockCnt.OutputFormat = resources.GetString("MaximumStockCnt.OutputFormat");
            this.MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 11.25pt; font-family: ＭＳ ゴシック; v" +
                "ertical-align: top; ";
            this.MaximumStockCnt.Text = "123,456.00";
            this.MaximumStockCnt.Top = 0F;
            this.MaximumStockCnt.Width = 0.8125F;
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
            this.ShipmentCnt.DataField = "ShipmentCnt";
            this.ShipmentCnt.Height = 0.1875F;
            this.ShipmentCnt.Left = 8.5625F;
            this.ShipmentCnt.MultiLine = false;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 11.25pt; font-family: ＭＳ ゴシック; v" +
                "ertical-align: top; ";
            this.ShipmentCnt.Text = "123,456.00";
            this.ShipmentCnt.Top = 0F;
            this.ShipmentCnt.Width = 0.8125F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 10.8125F;
            this.line2.X2 = 0F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "GoodsMakerCd";
            this.textBox3.Height = 0.128F;
            this.textBox3.Left = 9.4375F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox3.Text = "1234";
            this.textBox3.Top = 0F;
            this.textBox3.Visible = false;
            this.textBox3.Width = 0.2F;
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
            this.PageHeader.Height = 0.25F;
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
            this.Label3.Height = 0.1875F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.5625F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 128; font-size: 9.75pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.75F;
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
            this.tb_PrintDate.Height = 0.1875F;
            this.tb_PrintDate.Left = 8.25F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 128; font-size: 9.75pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 1.125F;
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
            this.Label2.Height = 0.1875F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 128; font-size: 9.75pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.625F;
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
            this.tb_PrintPage.Style = "ddo-char-set: 128; text-align: right; font-size: 9.75pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: top; ";
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
            this.tb_PrintTime.Left = 9.333333F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 128; font-size: 9.75pt; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.625F;
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
            this.tb_ReportTitle.Text = "発注一覧表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.302F;
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
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.ProcessDay,
            this.SectionCode,
            this.SectionGuideSnm,
            this.WarehouseCode,
            this.EnterpriseName1,
            this.EnterpriseName2,
            this.label16,
            this.EnterpriseTel,
            this.label17,
            this.EnterpriseFax,
            this.WarehouseName});
            this.ExtraHeader.DataField = "SectionWareHouse";
            this.ExtraHeader.Height = 0.5625F;
            this.ExtraHeader.KeepTogether = true;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            this.ExtraHeader.BeforePrint += new System.EventHandler(this.ExtraHeader_BeforePrint);
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
            this.label10.HyperLink = "";
            this.label10.Left = 0F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label10.Text = "処理日";
            this.label10.Top = 0F;
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
            this.label11.HyperLink = "";
            this.label11.Left = 0F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label11.Text = "拠点";
            this.label11.Top = 0.1875F;
            this.label11.Width = 0.5625F;
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
            this.label12.Left = 0F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label12.Text = "倉庫";
            this.label12.Top = 0.375F;
            this.label12.Width = 0.5625F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.1875F;
            this.label13.HyperLink = "";
            this.label13.Left = 0.5625F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label13.Text = "：";
            this.label13.Top = 0.375F;
            this.label13.Width = 0.1875F;
            // 
            // label14
            // 
            this.label14.Border.BottomColor = System.Drawing.Color.Black;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftColor = System.Drawing.Color.Black;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightColor = System.Drawing.Color.Black;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopColor = System.Drawing.Color.Black;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Height = 0.1875F;
            this.label14.HyperLink = "";
            this.label14.Left = 0.5625F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label14.Text = "：";
            this.label14.Top = 0.1875F;
            this.label14.Width = 0.1875F;
            // 
            // label15
            // 
            this.label15.Border.BottomColor = System.Drawing.Color.Black;
            this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.LeftColor = System.Drawing.Color.Black;
            this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.RightColor = System.Drawing.Color.Black;
            this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.TopColor = System.Drawing.Color.Black;
            this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Height = 0.1875F;
            this.label15.HyperLink = "";
            this.label15.Left = 0.5625F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label15.Text = "：";
            this.label15.Top = 0F;
            this.label15.Width = 0.1875F;
            // 
            // ProcessDay
            // 
            this.ProcessDay.Border.BottomColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.Border.LeftColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.Border.RightColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.Border.TopColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.DataField = "ProcessDay";
            this.ProcessDay.Height = 0.1875F;
            this.ProcessDay.Left = 0.75F;
            this.ProcessDay.MultiLine = false;
            this.ProcessDay.Name = "ProcessDay";
            this.ProcessDay.OutputFormat = resources.GetString("ProcessDay.OutputFormat");
            this.ProcessDay.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.ProcessDay.Text = "9999/99/99";
            this.ProcessDay.Top = 0F;
            this.ProcessDay.Width = 0.8125F;
            // 
            // SectionCode
            // 
            this.SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.DataField = "SectionCode";
            this.SectionCode.Height = 0.1875F;
            this.SectionCode.Left = 0.75F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.SectionCode.Text = "12";
            this.SectionCode.Top = 0.1875F;
            this.SectionCode.Width = 0.1875F;
            // 
            // SectionGuideSnm
            // 
            this.SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.DataField = "SectionGuideSnm";
            this.SectionGuideSnm.Height = 0.1875F;
            this.SectionGuideSnm.Left = 1.125F;
            this.SectionGuideSnm.MultiLine = false;
            this.SectionGuideSnm.Name = "SectionGuideSnm";
            this.SectionGuideSnm.OutputFormat = resources.GetString("SectionGuideSnm.OutputFormat");
            this.SectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.SectionGuideSnm.Text = "あいうえおかきくけこ";
            this.SectionGuideSnm.Top = 0.1875F;
            this.SectionGuideSnm.Width = 1.625F;
            // 
            // WarehouseCode
            // 
            this.WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.DataField = "WarehouseCode";
            this.WarehouseCode.Height = 0.1875F;
            this.WarehouseCode.Left = 0.75F;
            this.WarehouseCode.MultiLine = false;
            this.WarehouseCode.Name = "WarehouseCode";
            this.WarehouseCode.OutputFormat = resources.GetString("WarehouseCode.OutputFormat");
            this.WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.WarehouseCode.Text = "1234";
            this.WarehouseCode.Top = 0.375F;
            this.WarehouseCode.Width = 0.375F;
            // 
            // EnterpriseName1
            // 
            this.EnterpriseName1.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.DataField = "EnterpriseName1";
            this.EnterpriseName1.Height = 0.188F;
            this.EnterpriseName1.Left = 7.313F;
            this.EnterpriseName1.MultiLine = false;
            this.EnterpriseName1.Name = "EnterpriseName1";
            this.EnterpriseName1.OutputFormat = resources.GetString("EnterpriseName1.OutputFormat");
            this.EnterpriseName1.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.EnterpriseName1.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.EnterpriseName1.Top = 0F;
            this.EnterpriseName1.Width = 3.188F;
            // 
            // EnterpriseName2
            // 
            this.EnterpriseName2.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.DataField = "EnterpriseName2";
            this.EnterpriseName2.Height = 0.188F;
            this.EnterpriseName2.Left = 7.3125F;
            this.EnterpriseName2.MultiLine = false;
            this.EnterpriseName2.Name = "EnterpriseName2";
            this.EnterpriseName2.OutputFormat = resources.GetString("EnterpriseName2.OutputFormat");
            this.EnterpriseName2.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.EnterpriseName2.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.EnterpriseName2.Top = 0.1875F;
            this.EnterpriseName2.Width = 3.188F;
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
            this.label16.Left = 7.3125F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label16.Text = "TEL：";
            this.label16.Top = 0.375F;
            this.label16.Width = 0.4375F;
            // 
            // EnterpriseTel
            // 
            this.EnterpriseTel.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.DataField = "EnterpriseTel";
            this.EnterpriseTel.Height = 0.1875F;
            this.EnterpriseTel.Left = 7.6875F;
            this.EnterpriseTel.MultiLine = false;
            this.EnterpriseTel.Name = "EnterpriseTel";
            this.EnterpriseTel.OutputFormat = resources.GetString("EnterpriseTel.OutputFormat");
            this.EnterpriseTel.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.EnterpriseTel.Text = "1234567890123456";
            this.EnterpriseTel.Top = 0.375F;
            this.EnterpriseTel.Width = 1.3125F;
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
            this.label17.Left = 9F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label17.Text = "FAX：";
            this.label17.Top = 0.375F;
            this.label17.Width = 0.4375F;
            // 
            // EnterpriseFax
            // 
            this.EnterpriseFax.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.DataField = "EnterpriseFax";
            this.EnterpriseFax.Height = 0.1875F;
            this.EnterpriseFax.Left = 9.375F;
            this.EnterpriseFax.MultiLine = false;
            this.EnterpriseFax.Name = "EnterpriseFax";
            this.EnterpriseFax.OutputFormat = resources.GetString("EnterpriseFax.OutputFormat");
            this.EnterpriseFax.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.EnterpriseFax.Text = "1234567890123456";
            this.EnterpriseFax.Top = 0.375F;
            this.EnterpriseFax.Width = 1.3125F;
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
            this.WarehouseName.DataField = "WarehouseName";
            this.WarehouseName.Height = 0.1875F;
            this.WarehouseName.Left = 1.125F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.OutputFormat = resources.GetString("WarehouseName.OutputFormat");
            this.WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: middle; ";
            this.WarehouseName.Text = "あいうえおかきくけこ";
            this.WarehouseName.Top = 0.375F;
            this.WarehouseName.Width = 1.625F;
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
            this.Lb_OrderAndAdjustCnt,
            this.Lb_OrderFormPrintDate,
            this.Lb_ExpectDeliveryDate,
            this.Lb_MakerName,
            this.Line5,
            this.Lb_OrderNumber,
            this.Lb_ShipmentPosCnt,
            this.Lb_MinStockCount,
            this.Lb_MaxStockCount,
            this.Lb_ShipmentCnt,
            this.label_MakeCd,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label18,
            this.label19});
            this.TitleHeader.Height = 0.578F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Lb_OrderAndAdjustCnt
            // 
            this.Lb_OrderAndAdjustCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_OrderAndAdjustCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderAndAdjustCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_OrderAndAdjustCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderAndAdjustCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_OrderAndAdjustCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderAndAdjustCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_OrderAndAdjustCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderAndAdjustCnt.Height = 0.1875F;
            this.Lb_OrderAndAdjustCnt.HyperLink = "";
            this.Lb_OrderAndAdjustCnt.Left = 4.875F;
            this.Lb_OrderAndAdjustCnt.MultiLine = false;
            this.Lb_OrderAndAdjustCnt.Name = "Lb_OrderAndAdjustCnt";
            this.Lb_OrderAndAdjustCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_OrderAndAdjustCnt.Text = "発注数";
            this.Lb_OrderAndAdjustCnt.Top = 0.1875F;
            this.Lb_OrderAndAdjustCnt.Width = 0.75F;
            // 
            // Lb_OrderFormPrintDate
            // 
            this.Lb_OrderFormPrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Height = 0.1875F;
            this.Lb_OrderFormPrintDate.HyperLink = "";
            this.Lb_OrderFormPrintDate.Left = 0.875F;
            this.Lb_OrderFormPrintDate.MultiLine = false;
            this.Lb_OrderFormPrintDate.Name = "Lb_OrderFormPrintDate";
            this.Lb_OrderFormPrintDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_OrderFormPrintDate.Text = "品番";
            this.Lb_OrderFormPrintDate.Top = 0.1875F;
            this.Lb_OrderFormPrintDate.Width = 0.5625F;
            // 
            // Lb_ExpectDeliveryDate
            // 
            this.Lb_ExpectDeliveryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Height = 0.1875F;
            this.Lb_ExpectDeliveryDate.HyperLink = "";
            this.Lb_ExpectDeliveryDate.Left = 3F;
            this.Lb_ExpectDeliveryDate.MultiLine = false;
            this.Lb_ExpectDeliveryDate.Name = "Lb_ExpectDeliveryDate";
            this.Lb_ExpectDeliveryDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_ExpectDeliveryDate.Text = "品名";
            this.Lb_ExpectDeliveryDate.Top = 0.1875F;
            this.Lb_ExpectDeliveryDate.Width = 0.5625F;
            // 
            // Lb_MakerName
            // 
            this.Lb_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Height = 0.1875F;
            this.Lb_MakerName.HyperLink = "";
            this.Lb_MakerName.Left = 0.125F;
            this.Lb_MakerName.MultiLine = false;
            this.Lb_MakerName.Name = "Lb_MakerName";
            this.Lb_MakerName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_MakerName.Text = "棚番";
            this.Lb_MakerName.Top = 0.1875F;
            this.Lb_MakerName.Width = 0.5625F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0F;
            this.Line5.Left = 0F;
            this.Line5.LineWeight = 2F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 10.8125F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.8125F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // Lb_OrderNumber
            // 
            this.Lb_OrderNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Height = 0.1875F;
            this.Lb_OrderNumber.HyperLink = "";
            this.Lb_OrderNumber.Left = 0F;
            this.Lb_OrderNumber.MultiLine = false;
            this.Lb_OrderNumber.Name = "Lb_OrderNumber";
            this.Lb_OrderNumber.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_OrderNumber.Text = "仕入先";
            this.Lb_OrderNumber.Top = 0F;
            this.Lb_OrderNumber.Width = 0.5625F;
            // 
            // Lb_ShipmentPosCnt
            // 
            this.Lb_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Height = 0.1875F;
            this.Lb_ShipmentPosCnt.HyperLink = "";
            this.Lb_ShipmentPosCnt.Left = 5.8125F;
            this.Lb_ShipmentPosCnt.MultiLine = false;
            this.Lb_ShipmentPosCnt.Name = "Lb_ShipmentPosCnt";
            this.Lb_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_ShipmentPosCnt.Text = "現在庫数";
            this.Lb_ShipmentPosCnt.Top = 0.1875F;
            this.Lb_ShipmentPosCnt.Width = 0.75F;
            // 
            // Lb_MinStockCount
            // 
            this.Lb_MinStockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Height = 0.1875F;
            this.Lb_MinStockCount.HyperLink = "";
            this.Lb_MinStockCount.Left = 6.75F;
            this.Lb_MinStockCount.MultiLine = false;
            this.Lb_MinStockCount.Name = "Lb_MinStockCount";
            this.Lb_MinStockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_MinStockCount.Text = "最低在庫数";
            this.Lb_MinStockCount.Top = 0.1875F;
            this.Lb_MinStockCount.Width = 0.75F;
            // 
            // Lb_MaxStockCount
            // 
            this.Lb_MaxStockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Height = 0.1875F;
            this.Lb_MaxStockCount.HyperLink = "";
            this.Lb_MaxStockCount.Left = 7.6875F;
            this.Lb_MaxStockCount.MultiLine = false;
            this.Lb_MaxStockCount.Name = "Lb_MaxStockCount";
            this.Lb_MaxStockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_MaxStockCount.Text = "最高在庫数";
            this.Lb_MaxStockCount.Top = 0.1875F;
            this.Lb_MaxStockCount.Width = 0.75F;
            // 
            // Lb_ShipmentCnt
            // 
            this.Lb_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Height = 0.1875F;
            this.Lb_ShipmentCnt.HyperLink = "";
            this.Lb_ShipmentCnt.Left = 8.625F;
            this.Lb_ShipmentCnt.MultiLine = false;
            this.Lb_ShipmentCnt.Name = "Lb_ShipmentCnt";
            this.Lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_ShipmentCnt.Text = "貸出数";
            this.Lb_ShipmentCnt.Top = 0.1875F;
            this.Lb_ShipmentCnt.Width = 0.75F;
            // 
            // label_MakeCd
            // 
            this.label_MakeCd.Border.BottomColor = System.Drawing.Color.Black;
            this.label_MakeCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_MakeCd.Border.LeftColor = System.Drawing.Color.Black;
            this.label_MakeCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_MakeCd.Border.RightColor = System.Drawing.Color.Black;
            this.label_MakeCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_MakeCd.Border.TopColor = System.Drawing.Color.Black;
            this.label_MakeCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_MakeCd.Height = 0.1875F;
            this.label_MakeCd.HyperLink = "";
            this.label_MakeCd.Left = 0F;
            this.label_MakeCd.MultiLine = false;
            this.label_MakeCd.Name = "label_MakeCd";
            this.label_MakeCd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label_MakeCd.Text = "メーカー";
            this.label_MakeCd.Top = 0.1875F;
            this.label_MakeCd.Width = 0.75F;
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
            this.label4.Left = 0.125F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label4.Text = "棚番";
            this.label4.Top = 0.375F;
            this.label4.Width = 0.5625F;
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
            this.label5.Left = 0.875F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label5.Text = "品番";
            this.label5.Top = 0.375F;
            this.label5.Width = 0.5625F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = "";
            this.label6.Left = 3F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label6.Text = "品名";
            this.label6.Top = 0.375F;
            this.label6.Width = 0.5625F;
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
            this.label7.Left = 4.875F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.label7.Text = "発注数";
            this.label7.Top = 0.375F;
            this.label7.Width = 0.75F;
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
            this.label8.Left = 5.8125F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.label8.Text = "現在庫数";
            this.label8.Top = 0.375F;
            this.label8.Width = 0.75F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.1875F;
            this.label9.HyperLink = "";
            this.label9.Left = 6.75F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.label9.Text = "最低在庫数";
            this.label9.Top = 0.375F;
            this.label9.Width = 0.75F;
            // 
            // label18
            // 
            this.label18.Border.BottomColor = System.Drawing.Color.Black;
            this.label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.LeftColor = System.Drawing.Color.Black;
            this.label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.RightColor = System.Drawing.Color.Black;
            this.label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.TopColor = System.Drawing.Color.Black;
            this.label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Height = 0.1875F;
            this.label18.HyperLink = "";
            this.label18.Left = 7.6875F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.label18.Text = "最高在庫数";
            this.label18.Top = 0.375F;
            this.label18.Width = 0.75F;
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
            this.label19.Left = 8.625F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ 明朝; vertical-align: middle; ";
            this.label19.Text = "貸出数";
            this.label19.Top = 0.375F;
            this.label19.Width = 0.75F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
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
            this.GrandTotalFooter.Height = 0F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // ALLTOTALTITLE
            // 
            this.ALLTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Height = 0.1875F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 1.6875F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 12pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "仕入先計";
            this.ALLTOTALTITLE.Top = 0F;
            this.ALLTOTALTITLE.Width = 0.75F;
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
            this.Line43.Width = 10.8125F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.8125F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // DetailCount
            // 
            this.DetailCount.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Border.RightColor = System.Drawing.Color.Black;
            this.DetailCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Border.TopColor = System.Drawing.Color.Black;
            this.DetailCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Height = 0.1875F;
            this.DetailCount.Left = 2.625F;
            this.DetailCount.MultiLine = false;
            this.DetailCount.Name = "DetailCount";
            this.DetailCount.OutputFormat = resources.GetString("DetailCount.OutputFormat");
            this.DetailCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.DetailCount.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.DetailCount.SummaryGroup = "Header1";
            this.DetailCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.DetailCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DetailCount.Text = "123,456";
            this.DetailCount.Top = 0F;
            this.DetailCount.Width = 0.625F;
            // 
            // f_SalesOrderCountLotCalc
            // 
            this.f_SalesOrderCountLotCalc.Border.BottomColor = System.Drawing.Color.Black;
            this.f_SalesOrderCountLotCalc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCountLotCalc.Border.LeftColor = System.Drawing.Color.Black;
            this.f_SalesOrderCountLotCalc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCountLotCalc.Border.RightColor = System.Drawing.Color.Black;
            this.f_SalesOrderCountLotCalc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCountLotCalc.Border.TopColor = System.Drawing.Color.Black;
            this.f_SalesOrderCountLotCalc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCountLotCalc.DataField = "SalesOrderCountLotCalc";
            this.f_SalesOrderCountLotCalc.Height = 0.1875F;
            this.f_SalesOrderCountLotCalc.Left = 4.5625F;
            this.f_SalesOrderCountLotCalc.MultiLine = false;
            this.f_SalesOrderCountLotCalc.Name = "f_SalesOrderCountLotCalc";
            this.f_SalesOrderCountLotCalc.OutputFormat = resources.GetString("f_SalesOrderCountLotCalc.OutputFormat");
            this.f_SalesOrderCountLotCalc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 11.25pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.f_SalesOrderCountLotCalc.SummaryGroup = "Header1";
            this.f_SalesOrderCountLotCalc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.f_SalesOrderCountLotCalc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f_SalesOrderCountLotCalc.Text = "123,456789.00";
            this.f_SalesOrderCountLotCalc.Top = 0F;
            this.f_SalesOrderCountLotCalc.Width = 1.0625F;
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
            this.label1.Left = 3.25F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label1.Text = "件";
            this.label1.Top = 0F;
            this.label1.Width = 0.1875F;
            // 
            // Header1
            // 
            this.Header1.CanShrink = true;
            this.Header1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupplierCodePrint,
            this.line10,
            this.SupplierName,
            this.BC_SupplierSeqNo,
            this.textBox_Space});
            this.Header1.DataField = "SupplierCodePrint";
            this.Header1.Height = 0.3229167F;
            this.Header1.KeepTogether = true;
            this.Header1.Name = "Header1";
            this.Header1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.Header1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.Header1.Format += new System.EventHandler(this.Header1_Format);
            this.Header1.BeforePrint += new System.EventHandler(this.Header1_BeforePrint);
            // 
            // SupplierCodePrint
            // 
            this.SupplierCodePrint.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.DataField = "SupplierCodePrint";
            this.SupplierCodePrint.Height = 0.1875F;
            this.SupplierCodePrint.Left = 0F;
            this.SupplierCodePrint.MultiLine = false;
            this.SupplierCodePrint.Name = "SupplierCodePrint";
            this.SupplierCodePrint.OutputFormat = resources.GetString("SupplierCodePrint.OutputFormat");
            this.SupplierCodePrint.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.SupplierCodePrint.Text = "123456";
            this.SupplierCodePrint.Top = 0F;
            this.SupplierCodePrint.Width = 0.5F;
            // 
            // line10
            // 
            this.line10.Border.BottomColor = System.Drawing.Color.Black;
            this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.LeftColor = System.Drawing.Color.Black;
            this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.RightColor = System.Drawing.Color.Black;
            this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.TopColor = System.Drawing.Color.Black;
            this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Height = 0F;
            this.line10.Left = 0F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0F;
            this.line10.Width = 10.81F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.81F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0F;
            // 
            // SupplierName
            // 
            this.SupplierName.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.DataField = "SupplierName";
            this.SupplierName.Height = 0.1875F;
            this.SupplierName.Left = 0.5F;
            this.SupplierName.MultiLine = false;
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.OutputFormat = resources.GetString("SupplierName.OutputFormat");
            this.SupplierName.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: top; ";
            this.SupplierName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupplierName.Top = 0F;
            this.SupplierName.Width = 3.1875F;
            // 
            // BC_SupplierSeqNo
            // 
            this.BC_SupplierSeqNo.Border.BottomColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.Border.LeftColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.Border.RightColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.Border.TopColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.CheckSumEnabled = false;
            this.BC_SupplierSeqNo.DataField = "SupplierSeqNoForBarCode";
            this.BC_SupplierSeqNo.Font = new System.Drawing.Font("ＭＳ 明朝", 16F);
            this.BC_SupplierSeqNo.Height = 0.2F;
            this.BC_SupplierSeqNo.Left = 4.313F;
            this.BC_SupplierSeqNo.Name = "BC_SupplierSeqNo";
            this.BC_SupplierSeqNo.Style = DataDynamics.ActiveReports.BarCodeStyle.Code39;
            this.BC_SupplierSeqNo.Text = "barcode1";
            this.BC_SupplierSeqNo.Top = 0.05F;
            this.BC_SupplierSeqNo.Width = 2.9F;
            // 
            // textBox_Space
            // 
            this.textBox_Space.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Height = 0.3F;
            this.textBox_Space.Left = 3.8125F;
            this.textBox_Space.MultiLine = false;
            this.textBox_Space.Name = "textBox_Space";
            this.textBox_Space.OutputFormat = resources.GetString("textBox_Space.OutputFormat");
            this.textBox_Space.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.textBox_Space.Text = null;
            this.textBox_Space.Top = 0F;
            this.textBox_Space.Width = 0.438F;
            // 
            // Footer1
            // 
            this.Footer1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line43,
            this.ALLTOTALTITLE,
            this.DetailCount,
            this.f_SalesOrderCountLotCalc,
            this.label1});
            this.Footer1.Height = 0.1875F;
            this.Footer1.KeepTogether = true;
            this.Footer1.Name = "Footer1";
            // 
            // groupHeader_MakeCd
            // 
            this.groupHeader_MakeCd.CanShrink = true;
            this.groupHeader_MakeCd.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.line3});
            this.groupHeader_MakeCd.DataField = "GoodsMakerCd";
            this.groupHeader_MakeCd.Height = 0.25F;
            this.groupHeader_MakeCd.Name = "groupHeader_MakeCd";
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
            this.textBox1.DataField = "GoodsMakerCd";
            this.textBox1.Height = 0.188F;
            this.textBox1.Left = 0F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.textBox1.Text = "1234";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.5F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.CanShrink = true;
            this.textBox2.DataField = "MakerName";
            this.textBox2.Height = 0.188F;
            this.textBox2.Left = 0.5F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: left; font-size: 11.25pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: top; ";
            this.textBox2.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 3.1875F;
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
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 10.8125F;
            this.line3.X2 = 0F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.Visible = false;
            // 
            // DCHAT02102P_02A4C
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
            this.Sections.Add(this.Header1);
            this.Sections.Add(this.groupHeader_MakeCd);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.Footer1);
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
            this.PageEnd += new System.EventHandler(this.DCHAT02102P_02A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCHAT02102P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCountLotCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderAndAdjustCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderFormPrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ExpectDeliveryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinStockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaxStockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_MakeCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_SalesOrderCountLotCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCodePrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Space)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// Header1_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ヘッダーセクションがページに描画される前に発生する。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date	    : 2017/09/14</br>
        /// </remarks>
        private void Header1_Format(object sender, EventArgs e)
        {
            // バーコードデータがある場合、空行を追加します。
            if (string.IsNullOrEmpty(this.BC_SupplierSeqNo.Text))
            {
                this.textBox_Space.Visible = false;
                this.BC_SupplierSeqNo.Visible = false;
            }
            else
            {
                this.textBox_Space.Visible = true;
                this.BC_SupplierSeqNo.Visible = true;
            }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
	}
}
