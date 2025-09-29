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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 在庫･倉庫移動確認表(簡易)印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 在庫･倉庫移動確認表(簡易)のフォームクラスです。</br>
	/// <br>Programmer	: 22013 久保　将太</br>
	/// <br>Date		: 2007.03.16</br>
	/// <br></br>
	/// <br>UpdateNote	: 2007.06.01 22013 kubo</br>
	/// <br>			:	・サプレスの条件を「メーカーコードと商品コードが前行と同じ」に変更</br>
    /// <br>UpdateNote	: 2008/10/02       照田 貴志</br>
    /// <br>			:	・バグ修正、仕様変更対応</br>
    /// </remarks>
	public class MAZAI02032P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫･倉庫移動確認表(簡易)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 在庫･倉庫移動確認表(簡易)フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
		/// </remarks>
		public MAZAI02032P_01A4C()
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

		private	StockMoveCndtn		_stockMoveCndtn;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

        // 明細が最初に印字されるかどうかの判定用
        private string printFirst = string.Empty;       //ADD 2008/10/02

		// 伝票ヘッダサプレスバッファ
        //string _slipSuppresBuf = "";          // DEL 2008.08.12
		#region // 2007.06.01 kubo del
		//// 移動伝票行番号情報サプレスバッファ
		////string _stockMoveRowNo = "";
		#endregion

		// 2007.06.01 kubo add ---------------->
		// メーカー情報サプレスバッファ
        //string _makerSuppresBuf = "";         // DEL 2008.08.12
        private Label Lb_BfSection;
        private Label Lb_BfEnterWareh;
        private Label Lb_BfShelfNo;
        private Label Lb_ShipmentScdlDay;
        private Label Lb_ShipmentFixDay;
        private Label Lb_ArrivalGoodsDay;
        private Label Lb_StockMoveSlipNo;
        private Label Lb_AfSection;
        private Label Lb_AfEnterWareh;
        private Label Lb_AfShelfNo;
        private Label Lb_GoodsNo;
        private Label Lb_GoodsName;
        private Label Lb_ListPriceFl;
        private Label Lb_StockUnitPriceFl;
        private Label Lb_MoveCount;
        private Label Lb_MovePrice;
        private Label Lb_InputDay;
        private TextBox BfSectionCode;
        private TextBox BfSectionGuideSnm;
        private TextBox BfEnterWarehName;
        private TextBox BfShelfNo;
        private TextBox ShipmentScdlDay;
        private TextBox ShipmentFixDay;
        private TextBox ArrivalGoodsDay;
        private TextBox StockMoveSlipNo;
        private TextBox AfSectionCode;
        private TextBox AfSectionGuideSnm;
        private TextBox AfEnterWarehName;
        private TextBox AfShelfNo;
        private TextBox GoodsName;
        private TextBox GoodsNo;
        private TextBox ListPriceFl;
        private TextBox StockUnitPriceFl;
        private TextBox MoveCount;
        private TextBox MovePrice;
        private TextBox InputDay;
        private Label Lb_AfSection_Dm;
        private Label Lb_AfEnterWareh_Dm;
        private Label Lb_AfShelfNo_Dm;
        private Label Lb_BfSection_Dm;
        private Label Lb_BfEnterWareh_Dm;
        private Label Lb_BfShelfNo_Dm;
        private TextBox BfSectionCode_Dm;
        private TextBox BfSectionGuideSnm_Dm;
        private TextBox BfEnterWarehName_Dm;
        private TextBox AfSectionGuideSnm_Dm;
        private TextBox AfSectionCode_Dm;
        private TextBox AfEnterWarehName_Dm;
        private GroupHeader SlipHeader;
        private GroupFooter SlipFooter;
        private TextBox SLIPTOTALTITLE;
        private TextBox Sl_MovingTotalStock;
        private TextBox Sl_StockPrice;
        private Line line2;
        private TextBox AfShelfNo_Dm;
        private TextBox tb_PrintSortOrder;
        private Line Line37;
        private Line line3;
        private TextBox BfShelfNo_Dm;
		// 商品情報サプレスバッファ
        //string _goodsSuppresBuf = "";         // DEL 2008.08.12
		// 2007.06.01 kubo add <----------------
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
				this._stockMoveCndtn	= (StockMoveCndtn)this._printInfo.jyoken;
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
				// TODO:  MAZAI02032P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAZAI02032P_01A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;

            // --- ADD 2008/10/02 --------------------------------------------------------->>>>>
            this.SectionHeader.DataField = "BfSectionCode";
            this.WareHouseHeader.DataField = "BfEnterWarehName";

            // 改頁：拠点
            if (this._stockMoveCndtn.NewPage == StockMoveCndtn.NewPageDivState.Section)
            {
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.WareHouseHeader.NewPage = NewPage.None;
                this.WareHouseHeader.RepeatStyle = RepeatStyle.None;
            }
            // 改頁：倉庫
            else if (this._stockMoveCndtn.NewPage == StockMoveCndtn.NewPageDivState.Warehouse)
            {
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.WareHouseHeader.NewPage = NewPage.Before;
                this.WareHouseHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            // 改頁：しない
            else
            {
                this.SectionHeader.NewPage = NewPage.None;
                this.SectionHeader.RepeatStyle = RepeatStyle.None;
                this.WareHouseHeader.NewPage = NewPage.None;
                this.WareHouseHeader.RepeatStyle = RepeatStyle.None;
            }
            // --- ADD 2008/10/02 ---------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 印字設定 --------------------------------------------------------------------------------------
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._stockMoveCndtn.IsOptSection )
            //{
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._stockMoveCndtn.BfAfSectionCd.Length < 2 ) || 
            //        this._stockMoveCndtn.IsSelectAllSection )
            //    {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else
            //    {
            //        // 移動先と移動元を変える
            //        SectionHeader.DataField = MAZAI02034EA.ct_Col_MainSectionCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else
            //{
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}		

            //SectionHeader.DataField = MAZAI02034EA.ct_Col_MainSectionCode;    // DEL 2008.08.12
            SectionHeader.DataField = MAZAI02034EA.ct_Col_BfSectionCode;        // ADD 2008.08.12
            SectionHeader.Visible = true;
            SectionFooter.Visible = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

			// Todo: 拠点タイトル、日付タイトルを設定する。
            //--- DEL 2008/08/12 ---------->>>>>
            //Lb_MainSection.Text = string.Format( "{0}拠点", this._stockMoveCndtn.MainExtractTitle );			// 主拠点
            //Lb_MainWareHouse.Text = string.Format( "{0}倉庫", this._stockMoveCndtn.MainExtractTitle );		// 主倉庫
            //Lb_ExtractSection.Text = string.Format( "{0}拠点", this._stockMoveCndtn.ExtractTitle );		// 絞込み拠点
            //Lb_ExtractWareHouse.Text = string.Format( "{0}倉庫", this._stockMoveCndtn.ExtractTitle );	// 絞込み倉庫
            //Lb_ExtractDate.Text = this._stockMoveCndtn.ExtractDateTitle;	// 日付
            //--- DEL 2008/08/12 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 帳票によって出す項目と出さない項目が切り替わる。
            //if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
            //{
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //if ( this._stockMoveCndtn.GrossPrintDiv == StockMoveCndtn.GrossPrintDivState.ProductNo )
            //    //{
            //    //    // 在庫移動確認表 製造番号単位
            //    //    // 絞込み拠点:表示、仕入先:表示、製番:表示、電話番号:表示、移動単価:表示
            //    //    SetInitialVisibled( true, true, true, true, true );
            //    //}
            //    //else
            //    //{
            //    //    // 在庫移動確認表 商品単位
            //    //    // 絞込み拠点:表示、仕入先:非表示、製番:非表示、電話番号:非表示、移動単価:
            //    //    SetInitialVisibled( true, false, false, false, false );
            //    //}
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //    // 在庫移動確認表
            //    // 絞込み拠点:表示、仕入先:表示、製番:非表示、電話番号:非表示、移動単価:表示
            //    SetInitialVisibled(true, true, false, false, true);
            //}
            //else if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.WareHouseMove )
            //{
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //if ( this._stockMoveCndtn.GrossPrintDiv == StockMoveCndtn.GrossPrintDivState.ProductNo )
            //    //{
            //    //    // 倉庫移動確認表 製造番号単位
            //    //    // 絞込み拠点:非表示、仕入先:表示、製番:表示、電話番号:表示、移動単価:表示
            //    //    SetInitialVisibled( false, true, true, true, true );
            //    //}
            //    //else
            //    //{
            //    //    // 倉庫移動確認表 商品単位
            //    //    // 絞込み拠点:非表示、仕入先:非表示、製番:非表示、電話番号:非表示、移動単価:非表示
            //    //    SetInitialVisibled( false, false, false, false, false );
            //    //}

            //    // 倉庫移動確認表 商品単位
            //    // 絞込み拠点:非表示、仕入先:表示、製番:非表示、電話番号:非表示、移動単価:表示
            //    SetInitialVisibled(false, true, false, false, true);
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            //else
            //{
            //    // 絞込み拠点:非表示、仕入先:非表示、製番:非表示、電話番号:非表示、移動単価:非表示
            //    SetInitialVisibled( false, false, false, false, false );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //--- ADD 2008.08.12 ---------->>>>>
            #region ＜＜　出庫・入庫別レイアウト制御　＞＞
            //------------------------------------------------------------------------
            // 作成時のデフォルトの配置は出庫のレイアウトになっています。
            // 「入庫」が選択されている場合は、入庫レイアウトに動的に組み替えます。
            // (ex. WarehouseShelfNo.Left ← WarehouseShelfNo_Dm.Leftをセット)
            //------------------------------------------------------------------------

            if (this._stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeAf)
            {
                // タイトル項目
                Lb_BfSection.Left       = Lb_BfSection_Dm.Left;
                Lb_BfEnterWareh.Left    = Lb_BfEnterWareh_Dm.Left;
                Lb_BfShelfNo.Left       = Lb_BfShelfNo_Dm.Left;
                Lb_AfSection.Left       = Lb_AfSection_Dm.Left;
                Lb_AfEnterWareh.Left    = Lb_AfEnterWareh_Dm.Left;
                Lb_AfShelfNo.Left       = Lb_AfShelfNo_Dm.Left;

                // 明細項目
                BfSectionCode.Left      = BfSectionCode_Dm.Left;
                BfSectionGuideSnm.Left  = BfSectionGuideSnm_Dm.Left;
                BfEnterWarehName.Left   = BfEnterWarehName_Dm.Left;
                BfShelfNo.Left          = BfShelfNo_Dm.Left;
                AfSectionCode.Left      = AfSectionCode_Dm.Left;
                AfSectionGuideSnm.Left  = AfSectionGuideSnm_Dm.Left;
                AfEnterWarehName.Left   = AfEnterWarehName_Dm.Left;
                AfShelfNo.Left          = AfShelfNo_Dm.Left;
            }
            #endregion ＜＜　仕入先別・棚番別レイアウト制御　＞＞

            #region ＜＜　金額指定レイアウト制御　＞＞
            switch (this._stockMoveCndtn.PriceDesignat)
            {
                case StockMoveCndtn.PriceDesignatDivState.StockUnitPriceAndMovePrice:
                    // タイトル項目
                    Lb_StockUnitPriceFl.Visible = true;
                    Lb_MovePrice.Visible        = true;
                    // 明細項目
                    StockUnitPriceFl.Visible    = true;
                    MovePrice.Visible           = true;
                    Sl_StockPrice.Visible       = true;
                    Wh_StockPrice.Visible       = true;
                    Sec_StockPrice.Visible      = true;
                    GrandTtl_StockPrice.Visible = true;
                    break;
                case StockMoveCndtn.PriceDesignatDivState.StockUnitPrice:
                    // タイトル項目
                    Lb_StockUnitPriceFl.Visible = true;
                    Lb_MovePrice.Visible        = false;
                    // 明細項目
                    StockUnitPriceFl.Visible    = true;
                    MovePrice.Visible           = false;
                    Sl_StockPrice.Visible       = false;
                    Wh_StockPrice.Visible       = false;
                    Sec_StockPrice.Visible      = false;
                    GrandTtl_StockPrice.Visible = false;
                    break;
                case StockMoveCndtn.PriceDesignatDivState.MovePrice:
                    // タイトル項目
                    Lb_StockUnitPriceFl.Visible = false;
                    Lb_MovePrice.Visible        = true;
                    // 明細項目
                    StockUnitPriceFl.Visible    = false;
                    MovePrice.Visible           = true;
                    Sl_StockPrice.Visible       = true;
                    Wh_StockPrice.Visible       = true;
                    Sec_StockPrice.Visible      = true;
                    GrandTtl_StockPrice.Visible = true;
                    break;
                case StockMoveCndtn.PriceDesignatDivState.None:
                    // タイトル項目
                    Lb_StockUnitPriceFl.Visible = false;
                    Lb_MovePrice.Visible        = false;
                    // 明細項目
                    StockUnitPriceFl.Visible    = false;
                    MovePrice.Visible           = false;
                    Sl_StockPrice.Visible       = false;
                    Wh_StockPrice.Visible       = false;
                    Sec_StockPrice.Visible      = false;
                    GrandTtl_StockPrice.Visible = false;
                    break;
            }

            if (this._stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeAf)
            {
                // タイトル項目
                Lb_BfSection.Left = Lb_BfSection_Dm.Left;
                Lb_BfEnterWareh.Left = Lb_BfEnterWareh_Dm.Left;
                Lb_BfShelfNo.Left = Lb_BfShelfNo_Dm.Left;
                Lb_AfSection.Left = Lb_AfSection_Dm.Left;
                Lb_AfEnterWareh.Left = Lb_AfEnterWareh_Dm.Left;
                Lb_AfShelfNo.Left = Lb_AfShelfNo_Dm.Left;

                // 明細項目
                BfSectionCode.Left = BfSectionCode_Dm.Left;
                BfSectionGuideSnm.Left = BfSectionGuideSnm_Dm.Left;
                BfEnterWarehName.Left = BfEnterWarehName_Dm.Left;
                BfShelfNo.Left = BfShelfNo_Dm.Left;
                AfSectionCode.Left = AfSectionCode_Dm.Left;
                AfSectionGuideSnm.Left = AfSectionGuideSnm_Dm.Left;
                AfEnterWarehName.Left = AfEnterWarehName_Dm.Left;
                AfShelfNo.Left = AfShelfNo_Dm.Left;
            }
            #endregion ＜＜　金額指定レイアウト制御　＞＞
            //--- ADD 2008.08.12 ----------<<<<<
        }
		#endregion ◆ レポート要素出力設定

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //#region ◆ 項目表示設定
        ///// <summary>
        ///// 項目表示設定
        ///// </summary>
        ///// <param name="isExtrSection">絞込み拠点</param>
        ///// <param name="isCustomer">仕入先</param>
        ///// <param name="isProductNo">製番</param>
        ///// <param name="isTelNo">電話番号</param>
        ///// <param name="isStockUnitPrice">移動単価</param>
        //private void SetInitialVisibled( bool isExtrSection, bool isCustomer, bool isProductNo, bool isTelNo, bool isStockUnitPrice )
        //{
        //    // 絞り込み拠点
        //    Lb_ExtractSection.Visible = isExtrSection;
        //    ExtractSectionName.Visible = isExtrSection;
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// 仕入先
        //    //// 製造番号
        //    //Lb_ProDuctNumber.Visible = isProductNo;
        //    //ProductNumber.Visible = isProductNo;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    // 移動単価
        //    Lb_StockUnitPrice.Visible = isStockUnitPrice;
        //    StockUnitPrice.Visible = isStockUnitPrice;
        //}
        //#endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{
            //--- DEL 2008/08/12 ---------->>>>>
            //#region // 2007.06.01 kubo del
            //// 主拠点、主倉庫、抽出日付、絞込み拠点、絞込み倉庫は1つの伝票で同じなのでサプレスのキーは伝票番号のみとし、
            //// 伝票番号の変更により表示を切り替える

            //// 前回出力した伝票ヘッダ情報とバッファの値が同じなら出力しない。
            //if ( this.StockMoveSlipNo.Text.Trim().CompareTo(this._slipSuppresBuf) == 0 )
            //{
            //    // 非表示
            //    StockMoveSlipNo.Visible = false;		// 移動伝票番号
            //    Sec_MainSectionCode.Visible = false;    // 主拠点コード
            //    MainSectionName.Visible = false;		// 主拠点名称
            //    MainWhareHouseName.Visible = false;		// 主倉庫名称
            //    ExtractDate.Visible = false;			// 抽出日付
            //    ExtractSectionName.Visible = false;		// 抽出拠点名称(在庫移動でも倉庫移動でもとにかくfalse)
            //    ExtractWhareHouseName.Visible = false;	// 抽出倉庫名称

            //    #region // 2007.06.01 kubo del
            //    //if ( this.StockMoveRowNo.Text.Trim().CompareTo(this._stockMoveRowNo) == 0 )
            //    //{
            //    //    MakerName.Visible = false;			// メーカー名称	
            //    //    GoodsCode.Visible = false;			// 商品コード
            //    //    GoodsName.Visible = false;			// 商品名称
            //    //}
            //    //else
            //    //{
            //    //    MakerName.Visible = true;			// メーカー名称	
            //    //    GoodsCode.Visible = true;			// 商品コード
            //    //    GoodsName.Visible = true;			// 商品名称
            //    //}
            //    #endregion
            //    // 2007.06.01 kubo add ---------------->
            //    // メーカー、商品のサプレス判断(メーカー、商品が同じときだけサプレス) 
            //    if ( ( this.GoodsMakerCd.Text.Trim().CompareTo( this._makerSuppresBuf ) == 0 ) &&
            //        ( this.GoodsNo.Text.Trim().CompareTo( this._goodsSuppresBuf ) == 0 ) )
            //    {
            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //        //// 製番が無かったら有無を言わさず出力
            //        //if ( this.ProductNumber.Text.Trim().CompareTo("") == 0 )
            //        //{
            //        //    MakerName.Visible = true;			// メーカー名称	
            //        //    GoodsCode.Visible = true;			// 商品コード
            //        //    GoodsName.Visible = true;			// 商品名称
            //        //}
            //        //else
            //        //{
            //        //    MakerName.Visible = false;			// メーカー名称	
            //        //    GoodsCode.Visible = false;			// 商品コード
            //        //    GoodsName.Visible = false;			// 商品名称
            //        //}
            //        MakerName.Visible = false;			// メーカー名称	
            //        GoodsNo.Visible = false;			// 商品コード
            //        GoodsName.Visible = false;			// 商品名称
            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    }
            //    else
            //    {
            //        MakerName.Visible = true;			// メーカー名称	
            //        GoodsNo.Visible = true;		    	// 商品コード
            //        GoodsName.Visible = true;			// 商品名称
            //    }
            //    // 2007.06.01 kubo add <----------------

            //}
            //else
            //{
            //    // 表示 伝票が変わったら全ての情報を表示
            //    StockMoveSlipNo.Visible = true;		// 移動伝票番号
            //    Sec_MainSectionCode.Visible = true; // 主拠点コード
            //    MainSectionName.Visible = true;		// 主拠点名称
            //    MainWhareHouseName.Visible = true;	// 主倉庫名称
            //    ExtractDate.Visible = true;			// 抽出日付
            //    //--- DEL 2008/08/12 ---------->>>>>
            //    //if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
            //    //{
            //    //    ExtractSectionName.Visible = true;		// 抽出拠点名称(在庫移動のときだけtrueに。)
            //    //}
            //    //--- DEL 2008/08/12 ----------<<<<<
            //    ExtractWhareHouseName.Visible = true;	// 抽出倉庫名称
            //    MakerName.Visible = true;				// メーカー名称	
            //    GoodsNo.Visible = true;			    	// 商品コード
            //    GoodsName.Visible = true;				// 商品名称

            //}
            //this._slipSuppresBuf = this.StockMoveSlipNo.Text.Trim();
            //// 2007.06.01 kubo add ------------------------------------->
            //this._makerSuppresBuf = this.GoodsMakerCd.Text.Trim();
            //this._goodsSuppresBuf = this.GoodsNo.Text.Trim();
            //// 2007.06.01 kubo add <-------------------------------------
 
            ////this._stockMoveRowNo = this.StockMoveRowNo.Text.Trim(); 
            //#endregion
            //--- DEL 2008/08/12 ----------<<<<<
        }
		#endregion
		#endregion
		#endregion

		#region ■ Control Event

		#region ◎ MAZAI02032P_01A4C_ReportStart Event
		/// <summary>
		/// MAZAI02032P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ MAZAI02032P_01A4C_PageEnd Event
		/// <summary>
		/// MAZAI02032P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: MAZAI02032P_01A4C_PageEnd Event</br>
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
			#region // 2007.06.01 kubo del
			// this._stockMoveRowNo = "";
			#endregion
            //this._slipSuppresBuf = "";    // DEL 2008.08.12
			// 2007.06.01 kubo add ---------------->
            //this._makerSuppresBuf = "";   // DEL 2008.08.12
            //this._goodsSuppresBuf = "";   // DEL 2008.08.12
			// 2007.06.01 kubo add <----------------

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
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
            // ソート順表示
            this.tb_PrintSortOrder.Text = string.Format("[ {0} ]", this._pageHeaderSortOderTitle);      //ADD 2008/10/02
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
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
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
				// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
				this._rptExtraHeader.DataSource = null;
			}

			// 拠点オプション有無判定
            //--- DEL 2008.08.14 ---------->>>>>
            //string sectionTitle = string.Format( "{0}拠点：", this._stockMoveCndtn.MainExtractTitle );
            //if ( this._stockMoveCndtn.IsOptSection )
            //{
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //if ( this._stockMoveCndtn.IsSelectAllSection )
            //    //{
            //    //    this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
            //    //}
            //    //else
            //    //{
            //    //    this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    //}
            //    this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            //--- DEL 2008.08.14 ----------<<<<<

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
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
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製番単位のときは製番が入っているかどうかを見て単価の表示を切り替える
            //if ( this._stockMoveCndtn.GrossPrintDiv == StockMoveCndtn.GrossPrintDivState.ProductNo )
            //{
            //    if ( ProductNumber.Text.Trim().CompareTo( "" ) == 0 )
            //        StockUnitPrice.Visible = false;	// 製番が空なら非表示
            //    else
            //        StockUnitPrice.Visible = true;	// 製番が入力されていれば表示
            //}
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
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
			// グループサプレスの判断
			//this.CheckGroupSuppression();         //DEL 2008/10/02
            // --- ADD 2008/10/02 ----------------------------->>>>>
            // 一番上が明細の時のみ罫線を印字
            if (string.IsNullOrEmpty(this.printFirst))
            {
                line3.Visible = true;
            }
            else
            {
                line3.Visible = false;
            }
            this.printFirst = "BeforePrint";
            // --- ADD 2008/10/02 -----------------------------<<<<<

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
		/// <br>Programmer  : 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
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

        //--- DEL 2008/08/12 ---------->>>>>
		#region ◎ DailyFooter_Format Event
        ///// <summary>
        ///// DailyFooter_Format Event
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="eArgs">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note		: DailyFooter_Format Event</br>
        ///// <br>Programmer	: 22013 久保　将太</br>
        ///// <br>Date		: 2007.03.16</br>
        ///// </remarks>
        //private void DailyFooter_Format(object sender, System.EventArgs eArgs)
        //{
        //    // 日計が出た後はバッファをクリアして、明細に出力する。
        //    #region // 2007.06.01 kubo del
        //    // this._stockMoveRowNo = "";
        //    #endregion
        //    this._slipSuppresBuf = "";

        //    // 2007.06.01 kubo add ---------------->
        //    this._makerSuppresBuf = "";
        //    this._goodsSuppresBuf = "";
        //    // 2007.06.01 kubo add <----------------

        //}
		#endregion
        //--- DEL 2008/08/12 ----------<<<<<

		#region ◎ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PageFooterグループのフォーマットイベント。</br>
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.16</br>
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
					// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
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
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupHeader WareHouseHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.GroupFooter WareHouseFooter;
		private DataDynamics.ActiveReports.TextBox WAREHOUSETOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Wh_MovingTotalStock;
		private DataDynamics.ActiveReports.TextBox Wh_StockPrice;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SECTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Sec_MovingTotalStock;
		private DataDynamics.ActiveReports.TextBox Sec_StockPrice;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox GrandTtl_MovingTotalStock;
		private DataDynamics.ActiveReports.TextBox GrandTtl_StockPrice;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02032P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.ListPriceFl = new DataDynamics.ActiveReports.TextBox();
            this.StockUnitPriceFl = new DataDynamics.ActiveReports.TextBox();
            this.MoveCount = new DataDynamics.ActiveReports.TextBox();
            this.MovePrice = new DataDynamics.ActiveReports.TextBox();
            this.InputDay = new DataDynamics.ActiveReports.TextBox();
            this.BfSectionCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BfSectionGuideSnm_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BfEnterWarehName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionGuideSnm_Dm = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.AfEnterWarehName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.AfShelfNo_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BfShelfNo_Dm = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.BfSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.BfSectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.BfEnterWarehName = new DataDynamics.ActiveReports.TextBox();
            this.BfShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentScdlDay = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentFixDay = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalGoodsDay = new DataDynamics.ActiveReports.TextBox();
            this.StockMoveSlipNo = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.AfEnterWarehName = new DataDynamics.ActiveReports.TextBox();
            this.AfShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_PrintSortOrder = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_BfSection = new DataDynamics.ActiveReports.Label();
            this.Lb_BfEnterWareh = new DataDynamics.ActiveReports.Label();
            this.Lb_BfShelfNo = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentScdlDay = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentFixDay = new DataDynamics.ActiveReports.Label();
            this.Lb_ArrivalGoodsDay = new DataDynamics.ActiveReports.Label();
            this.Lb_StockMoveSlipNo = new DataDynamics.ActiveReports.Label();
            this.Lb_AfSection = new DataDynamics.ActiveReports.Label();
            this.Lb_AfEnterWareh = new DataDynamics.ActiveReports.Label();
            this.Lb_AfShelfNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_ListPriceFl = new DataDynamics.ActiveReports.Label();
            this.Lb_StockUnitPriceFl = new DataDynamics.ActiveReports.Label();
            this.Lb_MoveCount = new DataDynamics.ActiveReports.Label();
            this.Lb_MovePrice = new DataDynamics.ActiveReports.Label();
            this.Lb_InputDay = new DataDynamics.ActiveReports.Label();
            this.Lb_AfSection_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_AfEnterWareh_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_AfShelfNo_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_BfSection_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_BfEnterWareh_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_BfShelfNo_Dm = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.GrandTtl_MovingTotalStock = new DataDynamics.ActiveReports.TextBox();
            this.GrandTtl_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Sec_MovingTotalStock = new DataDynamics.ActiveReports.TextBox();
            this.Sec_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WareHouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WAREHOUSETOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Wh_MovingTotalStock = new DataDynamics.ActiveReports.TextBox();
            this.Wh_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.SlipHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SlipFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SLIPTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Sl_MovingTotalStock = new DataDynamics.ActiveReports.TextBox();
            this.Sl_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentScdlDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentFixDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalGoodsDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMoveSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintSortOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentScdlDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentFixDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ArrivalGoodsDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockMoveSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ListPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockUnitPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MovePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InputDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_MovingTotalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_MovingTotalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WAREHOUSETOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MovingTotalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLIPTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_MovingTotalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsName,
            this.GoodsNo,
            this.ListPriceFl,
            this.StockUnitPriceFl,
            this.MoveCount,
            this.MovePrice,
            this.InputDay,
            this.BfSectionCode_Dm,
            this.BfSectionGuideSnm_Dm,
            this.BfEnterWarehName_Dm,
            this.AfSectionGuideSnm_Dm,
            this.AfSectionCode_Dm,
            this.AfEnterWarehName_Dm,
            this.AfShelfNo_Dm,
            this.BfShelfNo_Dm,
            this.line3});
            this.Detail.Height = 0.375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.GoodsName.Height = 0.15625F;
            this.GoodsName.Left = 1.375F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 2.275F;
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
            this.GoodsNo.Height = 0.15625F;
            this.GoodsNo.Left = 0F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.405F;
            // 
            // ListPriceFl
            // 
            this.ListPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.ListPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.ListPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceFl.DataField = "ListPriceFl";
            this.ListPriceFl.Height = 0.15625F;
            this.ListPriceFl.Left = 3.6875F;
            this.ListPriceFl.MultiLine = false;
            this.ListPriceFl.Name = "ListPriceFl";
            this.ListPriceFl.OutputFormat = resources.GetString("ListPriceFl.OutputFormat");
            this.ListPriceFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.ListPriceFl.Text = "12345678";
            this.ListPriceFl.Top = 0F;
            this.ListPriceFl.Width = 0.75F;
            // 
            // StockUnitPriceFl
            // 
            this.StockUnitPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.DataField = "StockUnitPriceFl";
            this.StockUnitPriceFl.Height = 0.15625F;
            this.StockUnitPriceFl.Left = 4.5F;
            this.StockUnitPriceFl.MultiLine = false;
            this.StockUnitPriceFl.Name = "StockUnitPriceFl";
            this.StockUnitPriceFl.OutputFormat = resources.GetString("StockUnitPriceFl.OutputFormat");
            this.StockUnitPriceFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.StockUnitPriceFl.Text = "12,345,678.99";
            this.StockUnitPriceFl.Top = 0F;
            this.StockUnitPriceFl.Width = 0.75F;
            // 
            // MoveCount
            // 
            this.MoveCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.Border.RightColor = System.Drawing.Color.Black;
            this.MoveCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.Border.TopColor = System.Drawing.Color.Black;
            this.MoveCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.DataField = "MoveCount";
            this.MoveCount.Height = 0.15625F;
            this.MoveCount.Left = 5.25F;
            this.MoveCount.MultiLine = false;
            this.MoveCount.Name = "MoveCount";
            this.MoveCount.OutputFormat = resources.GetString("MoveCount.OutputFormat");
            this.MoveCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.MoveCount.Text = "1,234,567.99";
            this.MoveCount.Top = 0F;
            this.MoveCount.Width = 0.75F;
            // 
            // MovePrice
            // 
            this.MovePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MovePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MovePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.Border.RightColor = System.Drawing.Color.Black;
            this.MovePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.Border.TopColor = System.Drawing.Color.Black;
            this.MovePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.DataField = "StockPrice";
            this.MovePrice.Height = 0.15625F;
            this.MovePrice.Left = 6F;
            this.MovePrice.MultiLine = false;
            this.MovePrice.Name = "MovePrice";
            this.MovePrice.OutputFormat = resources.GetString("MovePrice.OutputFormat");
            this.MovePrice.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.MovePrice.Text = "12345678";
            this.MovePrice.Top = 0F;
            this.MovePrice.Width = 0.969F;
            // 
            // InputDay
            // 
            this.InputDay.Border.BottomColor = System.Drawing.Color.Black;
            this.InputDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay.Border.LeftColor = System.Drawing.Color.Black;
            this.InputDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay.Border.RightColor = System.Drawing.Color.Black;
            this.InputDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay.Border.TopColor = System.Drawing.Color.Black;
            this.InputDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay.DataField = "InputDay";
            this.InputDay.Height = 0.15625F;
            this.InputDay.Left = 7F;
            this.InputDay.MultiLine = false;
            this.InputDay.Name = "InputDay";
            this.InputDay.OutputFormat = resources.GetString("InputDay.OutputFormat");
            this.InputDay.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.InputDay.Text = "99/99/99";
            this.InputDay.Top = 0F;
            this.InputDay.Width = 0.75F;
            // 
            // BfSectionCode_Dm
            // 
            this.BfSectionCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.DataField = "MainSectionName";
            this.BfSectionCode_Dm.Height = 0.15625F;
            this.BfSectionCode_Dm.Left = 6.25F;
            this.BfSectionCode_Dm.MultiLine = false;
            this.BfSectionCode_Dm.Name = "BfSectionCode_Dm";
            this.BfSectionCode_Dm.OutputFormat = resources.GetString("BfSectionCode_Dm.OutputFormat");
            this.BfSectionCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfSectionCode_Dm.Text = "12";
            this.BfSectionCode_Dm.Top = 0.1875F;
            this.BfSectionCode_Dm.Visible = false;
            this.BfSectionCode_Dm.Width = 0.2F;
            // 
            // BfSectionGuideSnm_Dm
            // 
            this.BfSectionGuideSnm_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.DataField = "MainSectionName";
            this.BfSectionGuideSnm_Dm.Height = 0.15625F;
            this.BfSectionGuideSnm_Dm.Left = 6.4375F;
            this.BfSectionGuideSnm_Dm.MultiLine = false;
            this.BfSectionGuideSnm_Dm.Name = "BfSectionGuideSnm_Dm";
            this.BfSectionGuideSnm_Dm.OutputFormat = resources.GetString("BfSectionGuideSnm_Dm.OutputFormat");
            this.BfSectionGuideSnm_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfSectionGuideSnm_Dm.Text = "あいうえおかきくけこ";
            this.BfSectionGuideSnm_Dm.Top = 0.1875F;
            this.BfSectionGuideSnm_Dm.Visible = false;
            this.BfSectionGuideSnm_Dm.Width = 1.2F;
            // 
            // BfEnterWarehName_Dm
            // 
            this.BfEnterWarehName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.DataField = "MainSectionName";
            this.BfEnterWarehName_Dm.Height = 0.15625F;
            this.BfEnterWarehName_Dm.Left = 7.625F;
            this.BfEnterWarehName_Dm.MultiLine = false;
            this.BfEnterWarehName_Dm.Name = "BfEnterWarehName_Dm";
            this.BfEnterWarehName_Dm.OutputFormat = resources.GetString("BfEnterWarehName_Dm.OutputFormat");
            this.BfEnterWarehName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfEnterWarehName_Dm.Text = "あいうえおかきくけこ";
            this.BfEnterWarehName_Dm.Top = 0.1875F;
            this.BfEnterWarehName_Dm.Visible = false;
            this.BfEnterWarehName_Dm.Width = 1.2F;
            // 
            // AfSectionGuideSnm_Dm
            // 
            this.AfSectionGuideSnm_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.DataField = "MainSectionName";
            this.AfSectionGuideSnm_Dm.Height = 0.15625F;
            this.AfSectionGuideSnm_Dm.Left = 0.1875F;
            this.AfSectionGuideSnm_Dm.MultiLine = false;
            this.AfSectionGuideSnm_Dm.Name = "AfSectionGuideSnm_Dm";
            this.AfSectionGuideSnm_Dm.OutputFormat = resources.GetString("AfSectionGuideSnm_Dm.OutputFormat");
            this.AfSectionGuideSnm_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfSectionGuideSnm_Dm.Text = "あいうえおかきくけこ";
            this.AfSectionGuideSnm_Dm.Top = 0.1875F;
            this.AfSectionGuideSnm_Dm.Visible = false;
            this.AfSectionGuideSnm_Dm.Width = 1.2F;
            // 
            // AfSectionCode_Dm
            // 
            this.AfSectionCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.DataField = "MainSectionName";
            this.AfSectionCode_Dm.Height = 0.15625F;
            this.AfSectionCode_Dm.Left = 0F;
            this.AfSectionCode_Dm.MultiLine = false;
            this.AfSectionCode_Dm.Name = "AfSectionCode_Dm";
            this.AfSectionCode_Dm.OutputFormat = resources.GetString("AfSectionCode_Dm.OutputFormat");
            this.AfSectionCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfSectionCode_Dm.Text = "12";
            this.AfSectionCode_Dm.Top = 0.1875F;
            this.AfSectionCode_Dm.Visible = false;
            this.AfSectionCode_Dm.Width = 0.2F;
            // 
            // AfEnterWarehName_Dm
            // 
            this.AfEnterWarehName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.DataField = "MainSectionName";
            this.AfEnterWarehName_Dm.Height = 0.15625F;
            this.AfEnterWarehName_Dm.Left = 1.375F;
            this.AfEnterWarehName_Dm.MultiLine = false;
            this.AfEnterWarehName_Dm.Name = "AfEnterWarehName_Dm";
            this.AfEnterWarehName_Dm.OutputFormat = resources.GetString("AfEnterWarehName_Dm.OutputFormat");
            this.AfEnterWarehName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfEnterWarehName_Dm.Text = "あいうえおかきくけこ";
            this.AfEnterWarehName_Dm.Top = 0.1875F;
            this.AfEnterWarehName_Dm.Visible = false;
            this.AfEnterWarehName_Dm.Width = 1.2F;
            // 
            // AfShelfNo_Dm
            // 
            this.AfShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo_Dm.DataField = "BfShelfNo";
            this.AfShelfNo_Dm.Height = 0.15625F;
            this.AfShelfNo_Dm.Left = 2.625F;
            this.AfShelfNo_Dm.MultiLine = false;
            this.AfShelfNo_Dm.Name = "AfShelfNo_Dm";
            this.AfShelfNo_Dm.OutputFormat = resources.GetString("AfShelfNo_Dm.OutputFormat");
            this.AfShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfShelfNo_Dm.Text = "12345678";
            this.AfShelfNo_Dm.Top = 0.1875F;
            this.AfShelfNo_Dm.Visible = false;
            this.AfShelfNo_Dm.Width = 0.75F;
            // 
            // BfShelfNo_Dm
            // 
            this.BfShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo_Dm.DataField = "BfShelfNo";
            this.BfShelfNo_Dm.Height = 0.15625F;
            this.BfShelfNo_Dm.Left = 8.875F;
            this.BfShelfNo_Dm.MultiLine = false;
            this.BfShelfNo_Dm.Name = "BfShelfNo_Dm";
            this.BfShelfNo_Dm.OutputFormat = resources.GetString("BfShelfNo_Dm.OutputFormat");
            this.BfShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfShelfNo_Dm.Text = "12345678";
            this.BfShelfNo_Dm.Top = 0.1875F;
            this.BfShelfNo_Dm.Visible = false;
            this.BfShelfNo_Dm.Width = 0.75F;
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
            this.line3.Width = 10.75F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.75F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // Line37
            // 
            this.Line37.Border.BottomColor = System.Drawing.Color.Black;
            this.Line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.LeftColor = System.Drawing.Color.Black;
            this.Line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.RightColor = System.Drawing.Color.Black;
            this.Line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.TopColor = System.Drawing.Color.Black;
            this.Line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Height = 0F;
            this.Line37.Left = 0F;
            this.Line37.LineWeight = 1F;
            this.Line37.Name = "Line37";
            this.Line37.Top = 0F;
            this.Line37.Width = 10.75F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.75F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // BfSectionCode
            // 
            this.BfSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.DataField = "BfSectionCode";
            this.BfSectionCode.Height = 0.15625F;
            this.BfSectionCode.Left = 0F;
            this.BfSectionCode.MultiLine = false;
            this.BfSectionCode.Name = "BfSectionCode";
            this.BfSectionCode.OutputFormat = resources.GetString("BfSectionCode.OutputFormat");
            this.BfSectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BfSectionCode.Text = "12";
            this.BfSectionCode.Top = 0.0625F;
            this.BfSectionCode.Width = 0.2F;
            // 
            // BfSectionGuideSnm
            // 
            this.BfSectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.DataField = "BfSectionGuideSnm";
            this.BfSectionGuideSnm.Height = 0.15625F;
            this.BfSectionGuideSnm.Left = 0.125F;
            this.BfSectionGuideSnm.MultiLine = false;
            this.BfSectionGuideSnm.Name = "BfSectionGuideSnm";
            this.BfSectionGuideSnm.OutputFormat = resources.GetString("BfSectionGuideSnm.OutputFormat");
            this.BfSectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BfSectionGuideSnm.Text = "あいうえおかきくけこ";
            this.BfSectionGuideSnm.Top = 0.0625F;
            this.BfSectionGuideSnm.Width = 1.2F;
            // 
            // BfEnterWarehName
            // 
            this.BfEnterWarehName.Border.BottomColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.Border.LeftColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.Border.RightColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.Border.TopColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.DataField = "BfEnterWarehName";
            this.BfEnterWarehName.Height = 0.15625F;
            this.BfEnterWarehName.Left = 1.3125F;
            this.BfEnterWarehName.MultiLine = false;
            this.BfEnterWarehName.Name = "BfEnterWarehName";
            this.BfEnterWarehName.OutputFormat = resources.GetString("BfEnterWarehName.OutputFormat");
            this.BfEnterWarehName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BfEnterWarehName.Text = "あいうえおかきくけこ";
            this.BfEnterWarehName.Top = 0.0625F;
            this.BfEnterWarehName.Width = 1.2F;
            // 
            // BfShelfNo
            // 
            this.BfShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.BfShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.BfShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.BfShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.BfShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfShelfNo.DataField = "BfShelfNo";
            this.BfShelfNo.Height = 0.15625F;
            this.BfShelfNo.Left = 2.5F;
            this.BfShelfNo.MultiLine = false;
            this.BfShelfNo.Name = "BfShelfNo";
            this.BfShelfNo.OutputFormat = resources.GetString("BfShelfNo.OutputFormat");
            this.BfShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BfShelfNo.Text = "12345678";
            this.BfShelfNo.Top = 0.0625F;
            this.BfShelfNo.Width = 0.75F;
            // 
            // ShipmentScdlDay
            // 
            this.ShipmentScdlDay.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentScdlDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentScdlDay.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentScdlDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentScdlDay.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentScdlDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentScdlDay.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentScdlDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentScdlDay.DataField = "ShipmentScdlDay";
            this.ShipmentScdlDay.Height = 0.15625F;
            this.ShipmentScdlDay.Left = 3.25F;
            this.ShipmentScdlDay.MultiLine = false;
            this.ShipmentScdlDay.Name = "ShipmentScdlDay";
            this.ShipmentScdlDay.OutputFormat = resources.GetString("ShipmentScdlDay.OutputFormat");
            this.ShipmentScdlDay.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ShipmentScdlDay.Text = "99/99/99";
            this.ShipmentScdlDay.Top = 0.0625F;
            this.ShipmentScdlDay.Width = 0.75F;
            // 
            // ShipmentFixDay
            // 
            this.ShipmentFixDay.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentFixDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentFixDay.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentFixDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentFixDay.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentFixDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentFixDay.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentFixDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentFixDay.DataField = "ShipmentFixDay";
            this.ShipmentFixDay.Height = 0.15625F;
            this.ShipmentFixDay.Left = 4F;
            this.ShipmentFixDay.MultiLine = false;
            this.ShipmentFixDay.Name = "ShipmentFixDay";
            this.ShipmentFixDay.OutputFormat = resources.GetString("ShipmentFixDay.OutputFormat");
            this.ShipmentFixDay.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ShipmentFixDay.Text = "99/99/99";
            this.ShipmentFixDay.Top = 0.0625F;
            this.ShipmentFixDay.Width = 0.75F;
            // 
            // ArrivalGoodsDay
            // 
            this.ArrivalGoodsDay.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalGoodsDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalGoodsDay.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalGoodsDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalGoodsDay.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalGoodsDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalGoodsDay.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalGoodsDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalGoodsDay.DataField = "ArrivalGoodsDay";
            this.ArrivalGoodsDay.Height = 0.15625F;
            this.ArrivalGoodsDay.Left = 4.75F;
            this.ArrivalGoodsDay.MultiLine = false;
            this.ArrivalGoodsDay.Name = "ArrivalGoodsDay";
            this.ArrivalGoodsDay.OutputFormat = resources.GetString("ArrivalGoodsDay.OutputFormat");
            this.ArrivalGoodsDay.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ArrivalGoodsDay.Text = "99/99/99";
            this.ArrivalGoodsDay.Top = 0.0625F;
            this.ArrivalGoodsDay.Width = 0.75F;
            // 
            // StockMoveSlipNo
            // 
            this.StockMoveSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.StockMoveSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.StockMoveSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.StockMoveSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.StockMoveSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveSlipNo.DataField = "StockMoveSlipNo";
            this.StockMoveSlipNo.Height = 0.15625F;
            this.StockMoveSlipNo.Left = 5.5F;
            this.StockMoveSlipNo.MultiLine = false;
            this.StockMoveSlipNo.Name = "StockMoveSlipNo";
            this.StockMoveSlipNo.OutputFormat = resources.GetString("StockMoveSlipNo.OutputFormat");
            this.StockMoveSlipNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.StockMoveSlipNo.Text = "123456789";
            this.StockMoveSlipNo.Top = 0.0625F;
            this.StockMoveSlipNo.Width = 0.625F;
            // 
            // AfSectionCode
            // 
            this.AfSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.DataField = "AfSectionCode";
            this.AfSectionCode.Height = 0.15625F;
            this.AfSectionCode.Left = 6.125F;
            this.AfSectionCode.MultiLine = false;
            this.AfSectionCode.Name = "AfSectionCode";
            this.AfSectionCode.OutputFormat = resources.GetString("AfSectionCode.OutputFormat");
            this.AfSectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.AfSectionCode.Text = "12";
            this.AfSectionCode.Top = 0.0625F;
            this.AfSectionCode.Width = 0.2F;
            // 
            // AfSectionGuideSnm
            // 
            this.AfSectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.DataField = "AfSectionGuideSnm";
            this.AfSectionGuideSnm.Height = 0.15625F;
            this.AfSectionGuideSnm.Left = 6.375F;
            this.AfSectionGuideSnm.MultiLine = false;
            this.AfSectionGuideSnm.Name = "AfSectionGuideSnm";
            this.AfSectionGuideSnm.OutputFormat = resources.GetString("AfSectionGuideSnm.OutputFormat");
            this.AfSectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.AfSectionGuideSnm.Text = "あいうえおかきくけこ";
            this.AfSectionGuideSnm.Top = 0.0625F;
            this.AfSectionGuideSnm.Width = 1.2F;
            // 
            // AfEnterWarehName
            // 
            this.AfEnterWarehName.Border.BottomColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.Border.LeftColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.Border.RightColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.Border.TopColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.DataField = "AfEnterWarehName";
            this.AfEnterWarehName.Height = 0.15625F;
            this.AfEnterWarehName.Left = 7.5625F;
            this.AfEnterWarehName.MultiLine = false;
            this.AfEnterWarehName.Name = "AfEnterWarehName";
            this.AfEnterWarehName.OutputFormat = resources.GetString("AfEnterWarehName.OutputFormat");
            this.AfEnterWarehName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.AfEnterWarehName.Text = "あいうえおかきくけこ";
            this.AfEnterWarehName.Top = 0.0625F;
            this.AfEnterWarehName.Width = 1.2F;
            // 
            // AfShelfNo
            // 
            this.AfShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.AfShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.AfShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.AfShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.AfShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfShelfNo.DataField = "AfShelfNo";
            this.AfShelfNo.Height = 0.15625F;
            this.AfShelfNo.Left = 8.75F;
            this.AfShelfNo.MultiLine = false;
            this.AfShelfNo.Name = "AfShelfNo";
            this.AfShelfNo.OutputFormat = resources.GetString("AfShelfNo.OutputFormat");
            this.AfShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.AfShelfNo.Text = "12345678";
            this.AfShelfNo.Top = 0.0625F;
            this.AfShelfNo.Width = 0.5F;
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
            this.tb_ReportTitle,
            this.tb_PrintSortOrder});
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
            this.tb_ReportTitle.Height = 0.22F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "在庫移動確認表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.3125F;
            // 
            // tb_PrintSortOrder
            // 
            this.tb_PrintSortOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Height = 0.125F;
            this.tb_PrintSortOrder.Left = 2.625F;
            this.tb_PrintSortOrder.MultiLine = false;
            this.tb_PrintSortOrder.Name = "tb_PrintSortOrder";
            this.tb_PrintSortOrder.OutputFormat = resources.GetString("tb_PrintSortOrder.OutputFormat");
            this.tb_PrintSortOrder.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.tb_PrintSortOrder.Text = "あいうえおかきくけこ";
            this.tb_PrintSortOrder.Top = 0.0625F;
            this.tb_PrintSortOrder.Width = 1.1875F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2388889F;
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
            this.Footer_SubReport.Visible = false;
            this.Footer_SubReport.Width = 10.8F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // Header_SubReport
            // 
            this.Header_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.CloseBorder = false;
            this.Header_SubReport.Height = 0.5F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0.01041667F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line42,
            this.Lb_BfSection,
            this.Lb_BfEnterWareh,
            this.Lb_BfShelfNo,
            this.Lb_ShipmentScdlDay,
            this.Lb_ShipmentFixDay,
            this.Lb_ArrivalGoodsDay,
            this.Lb_StockMoveSlipNo,
            this.Lb_AfSection,
            this.Lb_AfEnterWareh,
            this.Lb_AfShelfNo,
            this.Lb_GoodsNo,
            this.Lb_GoodsName,
            this.Lb_ListPriceFl,
            this.Lb_StockUnitPriceFl,
            this.Lb_MoveCount,
            this.Lb_MovePrice,
            this.Lb_InputDay,
            this.Lb_AfSection_Dm,
            this.Lb_AfEnterWareh_Dm,
            this.Lb_AfShelfNo_Dm,
            this.Lb_BfSection_Dm,
            this.Lb_BfEnterWareh_Dm,
            this.Lb_BfShelfNo_Dm});
            this.TitleHeader.Height = 0.5416667F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.AfterPrint += new System.EventHandler(this.TitleHeader_AfterPrint);
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
            // Lb_BfSection
            // 
            this.Lb_BfSection.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Height = 0.15625F;
            this.Lb_BfSection.HyperLink = "";
            this.Lb_BfSection.Left = 0F;
            this.Lb_BfSection.MultiLine = false;
            this.Lb_BfSection.Name = "Lb_BfSection";
            this.Lb_BfSection.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfSection.Text = "出庫拠点";
            this.Lb_BfSection.Top = 0.01041667F;
            this.Lb_BfSection.Width = 1.4F;
            // 
            // Lb_BfEnterWareh
            // 
            this.Lb_BfEnterWareh.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Height = 0.15625F;
            this.Lb_BfEnterWareh.HyperLink = "";
            this.Lb_BfEnterWareh.Left = 1.395833F;
            this.Lb_BfEnterWareh.MultiLine = false;
            this.Lb_BfEnterWareh.Name = "Lb_BfEnterWareh";
            this.Lb_BfEnterWareh.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfEnterWareh.Text = "出庫倉庫";
            this.Lb_BfEnterWareh.Top = 0.01041667F;
            this.Lb_BfEnterWareh.Width = 1.2F;
            // 
            // Lb_BfShelfNo
            // 
            this.Lb_BfShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo.Height = 0.15625F;
            this.Lb_BfShelfNo.HyperLink = "";
            this.Lb_BfShelfNo.Left = 2.59375F;
            this.Lb_BfShelfNo.MultiLine = false;
            this.Lb_BfShelfNo.Name = "Lb_BfShelfNo";
            this.Lb_BfShelfNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfShelfNo.Text = "出庫棚番";
            this.Lb_BfShelfNo.Top = 0.01041667F;
            this.Lb_BfShelfNo.Width = 0.75F;
            // 
            // Lb_ShipmentScdlDay
            // 
            this.Lb_ShipmentScdlDay.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentScdlDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentScdlDay.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentScdlDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentScdlDay.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentScdlDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentScdlDay.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentScdlDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentScdlDay.Height = 0.15625F;
            this.Lb_ShipmentScdlDay.HyperLink = "";
            this.Lb_ShipmentScdlDay.Left = 3.34375F;
            this.Lb_ShipmentScdlDay.MultiLine = false;
            this.Lb_ShipmentScdlDay.Name = "Lb_ShipmentScdlDay";
            this.Lb_ShipmentScdlDay.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentScdlDay.Text = "出荷予定日";
            this.Lb_ShipmentScdlDay.Top = 0.01041667F;
            this.Lb_ShipmentScdlDay.Width = 0.75F;
            // 
            // Lb_ShipmentFixDay
            // 
            this.Lb_ShipmentFixDay.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentFixDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentFixDay.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentFixDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentFixDay.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentFixDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentFixDay.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentFixDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentFixDay.Height = 0.15625F;
            this.Lb_ShipmentFixDay.HyperLink = "";
            this.Lb_ShipmentFixDay.Left = 4.09375F;
            this.Lb_ShipmentFixDay.MultiLine = false;
            this.Lb_ShipmentFixDay.Name = "Lb_ShipmentFixDay";
            this.Lb_ShipmentFixDay.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentFixDay.Text = "出荷確定日";
            this.Lb_ShipmentFixDay.Top = 0.01041667F;
            this.Lb_ShipmentFixDay.Width = 0.75F;
            // 
            // Lb_ArrivalGoodsDay
            // 
            this.Lb_ArrivalGoodsDay.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ArrivalGoodsDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ArrivalGoodsDay.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ArrivalGoodsDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ArrivalGoodsDay.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ArrivalGoodsDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ArrivalGoodsDay.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ArrivalGoodsDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ArrivalGoodsDay.Height = 0.15625F;
            this.Lb_ArrivalGoodsDay.HyperLink = "";
            this.Lb_ArrivalGoodsDay.Left = 4.84375F;
            this.Lb_ArrivalGoodsDay.MultiLine = false;
            this.Lb_ArrivalGoodsDay.Name = "Lb_ArrivalGoodsDay";
            this.Lb_ArrivalGoodsDay.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ArrivalGoodsDay.Text = "入荷日";
            this.Lb_ArrivalGoodsDay.Top = 0.01041667F;
            this.Lb_ArrivalGoodsDay.Width = 0.75F;
            // 
            // Lb_StockMoveSlipNo
            // 
            this.Lb_StockMoveSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockMoveSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMoveSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockMoveSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMoveSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockMoveSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMoveSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockMoveSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMoveSlipNo.Height = 0.15625F;
            this.Lb_StockMoveSlipNo.HyperLink = "";
            this.Lb_StockMoveSlipNo.Left = 5.59375F;
            this.Lb_StockMoveSlipNo.MultiLine = false;
            this.Lb_StockMoveSlipNo.Name = "Lb_StockMoveSlipNo";
            this.Lb_StockMoveSlipNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockMoveSlipNo.Text = "伝票番号";
            this.Lb_StockMoveSlipNo.Top = 0.01041667F;
            this.Lb_StockMoveSlipNo.Width = 0.625F;
            // 
            // Lb_AfSection
            // 
            this.Lb_AfSection.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Height = 0.15625F;
            this.Lb_AfSection.HyperLink = "";
            this.Lb_AfSection.Left = 6.21875F;
            this.Lb_AfSection.MultiLine = false;
            this.Lb_AfSection.Name = "Lb_AfSection";
            this.Lb_AfSection.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfSection.Text = "入庫拠点";
            this.Lb_AfSection.Top = 0.01041667F;
            this.Lb_AfSection.Width = 1.4F;
            // 
            // Lb_AfEnterWareh
            // 
            this.Lb_AfEnterWareh.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Height = 0.15625F;
            this.Lb_AfEnterWareh.HyperLink = "";
            this.Lb_AfEnterWareh.Left = 7.614583F;
            this.Lb_AfEnterWareh.MultiLine = false;
            this.Lb_AfEnterWareh.Name = "Lb_AfEnterWareh";
            this.Lb_AfEnterWareh.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfEnterWareh.Text = "入庫倉庫";
            this.Lb_AfEnterWareh.Top = 0.01041667F;
            this.Lb_AfEnterWareh.Width = 1.2F;
            // 
            // Lb_AfShelfNo
            // 
            this.Lb_AfShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo.Height = 0.15625F;
            this.Lb_AfShelfNo.HyperLink = "";
            this.Lb_AfShelfNo.Left = 8.8125F;
            this.Lb_AfShelfNo.MultiLine = false;
            this.Lb_AfShelfNo.Name = "Lb_AfShelfNo";
            this.Lb_AfShelfNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfShelfNo.Text = "入庫棚番";
            this.Lb_AfShelfNo.Top = 0.01041667F;
            this.Lb_AfShelfNo.Width = 0.75F;
            // 
            // Lb_GoodsNo
            // 
            this.Lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Height = 0.15625F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 0F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.1875F;
            this.Lb_GoodsNo.Width = 1.405F;
            // 
            // Lb_GoodsName
            // 
            this.Lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Height = 0.15625F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 1.40625F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.1875F;
            this.Lb_GoodsName.Width = 2.275F;
            // 
            // Lb_ListPriceFl
            // 
            this.Lb_ListPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ListPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ListPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ListPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ListPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceFl.Height = 0.15625F;
            this.Lb_ListPriceFl.HyperLink = "";
            this.Lb_ListPriceFl.Left = 3.677083F;
            this.Lb_ListPriceFl.MultiLine = false;
            this.Lb_ListPriceFl.Name = "Lb_ListPriceFl";
            this.Lb_ListPriceFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ListPriceFl.Text = "標準価格";
            this.Lb_ListPriceFl.Top = 0.1875F;
            this.Lb_ListPriceFl.Width = 0.75F;
            // 
            // Lb_StockUnitPriceFl
            // 
            this.Lb_StockUnitPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPriceFl.Height = 0.15625F;
            this.Lb_StockUnitPriceFl.HyperLink = "";
            this.Lb_StockUnitPriceFl.Left = 4.5F;
            this.Lb_StockUnitPriceFl.MultiLine = false;
            this.Lb_StockUnitPriceFl.Name = "Lb_StockUnitPriceFl";
            this.Lb_StockUnitPriceFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockUnitPriceFl.Text = "移動単価";
            this.Lb_StockUnitPriceFl.Top = 0.1875F;
            this.Lb_StockUnitPriceFl.Width = 0.75F;
            // 
            // Lb_MoveCount
            // 
            this.Lb_MoveCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Height = 0.15625F;
            this.Lb_MoveCount.HyperLink = "";
            this.Lb_MoveCount.Left = 5.25F;
            this.Lb_MoveCount.MultiLine = false;
            this.Lb_MoveCount.Name = "Lb_MoveCount";
            this.Lb_MoveCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MoveCount.Text = "移動数";
            this.Lb_MoveCount.Top = 0.1875F;
            this.Lb_MoveCount.Width = 0.75F;
            // 
            // Lb_MovePrice
            // 
            this.Lb_MovePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Height = 0.15625F;
            this.Lb_MovePrice.HyperLink = "";
            this.Lb_MovePrice.Left = 6F;
            this.Lb_MovePrice.MultiLine = false;
            this.Lb_MovePrice.Name = "Lb_MovePrice";
            this.Lb_MovePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MovePrice.Text = "移動金額";
            this.Lb_MovePrice.Top = 0.1875F;
            this.Lb_MovePrice.Width = 0.969F;
            // 
            // Lb_InputDay
            // 
            this.Lb_InputDay.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_InputDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InputDay.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_InputDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InputDay.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_InputDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InputDay.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_InputDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_InputDay.Height = 0.15625F;
            this.Lb_InputDay.HyperLink = "";
            this.Lb_InputDay.Left = 7F;
            this.Lb_InputDay.MultiLine = false;
            this.Lb_InputDay.Name = "Lb_InputDay";
            this.Lb_InputDay.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_InputDay.Text = "入力日付";
            this.Lb_InputDay.Top = 0.1875F;
            this.Lb_InputDay.Width = 0.75F;
            // 
            // Lb_AfSection_Dm
            // 
            this.Lb_AfSection_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Height = 0.15625F;
            this.Lb_AfSection_Dm.HyperLink = "";
            this.Lb_AfSection_Dm.Left = 0F;
            this.Lb_AfSection_Dm.MultiLine = false;
            this.Lb_AfSection_Dm.Name = "Lb_AfSection_Dm";
            this.Lb_AfSection_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfSection_Dm.Text = "入庫拠点";
            this.Lb_AfSection_Dm.Top = 0.375F;
            this.Lb_AfSection_Dm.Visible = false;
            this.Lb_AfSection_Dm.Width = 1.4F;
            // 
            // Lb_AfEnterWareh_Dm
            // 
            this.Lb_AfEnterWareh_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Height = 0.15625F;
            this.Lb_AfEnterWareh_Dm.HyperLink = "";
            this.Lb_AfEnterWareh_Dm.Left = 1.395833F;
            this.Lb_AfEnterWareh_Dm.MultiLine = false;
            this.Lb_AfEnterWareh_Dm.Name = "Lb_AfEnterWareh_Dm";
            this.Lb_AfEnterWareh_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfEnterWareh_Dm.Text = "入庫倉庫";
            this.Lb_AfEnterWareh_Dm.Top = 0.375F;
            this.Lb_AfEnterWareh_Dm.Visible = false;
            this.Lb_AfEnterWareh_Dm.Width = 1.2F;
            // 
            // Lb_AfShelfNo_Dm
            // 
            this.Lb_AfShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfShelfNo_Dm.Height = 0.15625F;
            this.Lb_AfShelfNo_Dm.HyperLink = "";
            this.Lb_AfShelfNo_Dm.Left = 2.59375F;
            this.Lb_AfShelfNo_Dm.MultiLine = false;
            this.Lb_AfShelfNo_Dm.Name = "Lb_AfShelfNo_Dm";
            this.Lb_AfShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfShelfNo_Dm.Text = "入庫棚番";
            this.Lb_AfShelfNo_Dm.Top = 0.375F;
            this.Lb_AfShelfNo_Dm.Visible = false;
            this.Lb_AfShelfNo_Dm.Width = 0.75F;
            // 
            // Lb_BfSection_Dm
            // 
            this.Lb_BfSection_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Height = 0.15625F;
            this.Lb_BfSection_Dm.HyperLink = "";
            this.Lb_BfSection_Dm.Left = 6.219F;
            this.Lb_BfSection_Dm.MultiLine = false;
            this.Lb_BfSection_Dm.Name = "Lb_BfSection_Dm";
            this.Lb_BfSection_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfSection_Dm.Text = "出庫拠点";
            this.Lb_BfSection_Dm.Top = 0.375F;
            this.Lb_BfSection_Dm.Visible = false;
            this.Lb_BfSection_Dm.Width = 1.4F;
            // 
            // Lb_BfEnterWareh_Dm
            // 
            this.Lb_BfEnterWareh_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Height = 0.15625F;
            this.Lb_BfEnterWareh_Dm.HyperLink = "";
            this.Lb_BfEnterWareh_Dm.Left = 7.614583F;
            this.Lb_BfEnterWareh_Dm.MultiLine = false;
            this.Lb_BfEnterWareh_Dm.Name = "Lb_BfEnterWareh_Dm";
            this.Lb_BfEnterWareh_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfEnterWareh_Dm.Text = "出庫倉庫";
            this.Lb_BfEnterWareh_Dm.Top = 0.375F;
            this.Lb_BfEnterWareh_Dm.Visible = false;
            this.Lb_BfEnterWareh_Dm.Width = 1.2F;
            // 
            // Lb_BfShelfNo_Dm
            // 
            this.Lb_BfShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfShelfNo_Dm.Height = 0.15625F;
            this.Lb_BfShelfNo_Dm.HyperLink = "";
            this.Lb_BfShelfNo_Dm.Left = 8.8125F;
            this.Lb_BfShelfNo_Dm.MultiLine = false;
            this.Lb_BfShelfNo_Dm.Name = "Lb_BfShelfNo_Dm";
            this.Lb_BfShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfShelfNo_Dm.Text = "出庫棚番";
            this.Lb_BfShelfNo_Dm.Top = 0.375F;
            this.Lb_BfShelfNo_Dm.Visible = false;
            this.Lb_BfShelfNo_Dm.Width = 0.75F;
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
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ALLTOTALTITLE,
            this.Line43,
            this.GrandTtl_MovingTotalStock,
            this.GrandTtl_StockPrice});
            this.GrandTotalFooter.Height = 0.2388889F;
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
            this.ALLTOTALTITLE.Height = 0.219F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 2.875F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.03125F;
            this.ALLTOTALTITLE.Width = 0.5625F;
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
            // GrandTtl_MovingTotalStock
            // 
            this.GrandTtl_MovingTotalStock.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.DataField = "MoveCount";
            this.GrandTtl_MovingTotalStock.Height = 0.219F;
            this.GrandTtl_MovingTotalStock.Left = 5.25F;
            this.GrandTtl_MovingTotalStock.MultiLine = false;
            this.GrandTtl_MovingTotalStock.Name = "GrandTtl_MovingTotalStock";
            this.GrandTtl_MovingTotalStock.OutputFormat = resources.GetString("GrandTtl_MovingTotalStock.OutputFormat");
            this.GrandTtl_MovingTotalStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTtl_MovingTotalStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTtl_MovingTotalStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTtl_MovingTotalStock.Text = "12345";
            this.GrandTtl_MovingTotalStock.Top = 0.03125F;
            this.GrandTtl_MovingTotalStock.Width = 0.75F;
            // 
            // GrandTtl_StockPrice
            // 
            this.GrandTtl_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.DataField = "StockPrice";
            this.GrandTtl_StockPrice.Height = 0.219F;
            this.GrandTtl_StockPrice.Left = 6F;
            this.GrandTtl_StockPrice.MultiLine = false;
            this.GrandTtl_StockPrice.Name = "GrandTtl_StockPrice";
            this.GrandTtl_StockPrice.OutputFormat = resources.GetString("GrandTtl_StockPrice.OutputFormat");
            this.GrandTtl_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTtl_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTtl_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTtl_StockPrice.Text = "1,234,567,890";
            this.GrandTtl_StockPrice.Top = 0.03125F;
            this.GrandTtl_StockPrice.Width = 0.96875F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Height = 0.01041667F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.Sec_MovingTotalStock,
            this.Sec_StockPrice});
            this.SectionFooter.Height = 0.2597222F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
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
            // SECTOTALTITLE
            // 
            this.SECTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Height = 0.219F;
            this.SECTOTALTITLE.Left = 2.875F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "拠点計";
            this.SECTOTALTITLE.Top = 0.03125F;
            this.SECTOTALTITLE.Width = 0.5625F;
            // 
            // Sec_MovingTotalStock
            // 
            this.Sec_MovingTotalStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.DataField = "MoveCount";
            this.Sec_MovingTotalStock.Height = 0.219F;
            this.Sec_MovingTotalStock.Left = 5.25F;
            this.Sec_MovingTotalStock.MultiLine = false;
            this.Sec_MovingTotalStock.Name = "Sec_MovingTotalStock";
            this.Sec_MovingTotalStock.OutputFormat = resources.GetString("Sec_MovingTotalStock.OutputFormat");
            this.Sec_MovingTotalStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_MovingTotalStock.SummaryGroup = "SectionHeader";
            this.Sec_MovingTotalStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_MovingTotalStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_MovingTotalStock.Text = "12345";
            this.Sec_MovingTotalStock.Top = 0.03125F;
            this.Sec_MovingTotalStock.Width = 0.75F;
            // 
            // Sec_StockPrice
            // 
            this.Sec_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.DataField = "StockPrice";
            this.Sec_StockPrice.Height = 0.219F;
            this.Sec_StockPrice.Left = 6F;
            this.Sec_StockPrice.MultiLine = false;
            this.Sec_StockPrice.Name = "Sec_StockPrice";
            this.Sec_StockPrice.OutputFormat = resources.GetString("Sec_StockPrice.OutputFormat");
            this.Sec_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_StockPrice.SummaryGroup = "SectionHeader";
            this.Sec_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_StockPrice.Text = "1,234,567,890";
            this.Sec_StockPrice.Top = 0.03125F;
            this.Sec_StockPrice.Width = 0.96875F;
            // 
            // WareHouseHeader
            // 
            this.WareHouseHeader.CanShrink = true;
            this.WareHouseHeader.DataField = "BfEnterWarehName";
            this.WareHouseHeader.Height = 0F;
            this.WareHouseHeader.Name = "WareHouseHeader";
            // 
            // WareHouseFooter
            // 
            this.WareHouseFooter.CanShrink = true;
            this.WareHouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WAREHOUSETOTALTITLE,
            this.Wh_MovingTotalStock,
            this.Wh_StockPrice,
            this.Line});
            this.WareHouseFooter.Height = 0.25F;
            this.WareHouseFooter.KeepTogether = true;
            this.WareHouseFooter.Name = "WareHouseFooter";
            // 
            // WAREHOUSETOTALTITLE
            // 
            this.WAREHOUSETOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.WAREHOUSETOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.WAREHOUSETOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.WAREHOUSETOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.WAREHOUSETOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETOTALTITLE.Height = 0.219F;
            this.WAREHOUSETOTALTITLE.Left = 2.875F;
            this.WAREHOUSETOTALTITLE.MultiLine = false;
            this.WAREHOUSETOTALTITLE.Name = "WAREHOUSETOTALTITLE";
            this.WAREHOUSETOTALTITLE.OutputFormat = resources.GetString("WAREHOUSETOTALTITLE.OutputFormat");
            this.WAREHOUSETOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WAREHOUSETOTALTITLE.Text = "倉庫計";
            this.WAREHOUSETOTALTITLE.Top = 0.03125F;
            this.WAREHOUSETOTALTITLE.Width = 0.6875F;
            // 
            // Wh_MovingTotalStock
            // 
            this.Wh_MovingTotalStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.DataField = "MoveCount";
            this.Wh_MovingTotalStock.Height = 0.219F;
            this.Wh_MovingTotalStock.Left = 5.25F;
            this.Wh_MovingTotalStock.MultiLine = false;
            this.Wh_MovingTotalStock.Name = "Wh_MovingTotalStock";
            this.Wh_MovingTotalStock.OutputFormat = resources.GetString("Wh_MovingTotalStock.OutputFormat");
            this.Wh_MovingTotalStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_MovingTotalStock.SummaryGroup = "WareHouseHeader";
            this.Wh_MovingTotalStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_MovingTotalStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_MovingTotalStock.Text = "12345";
            this.Wh_MovingTotalStock.Top = 0.03125F;
            this.Wh_MovingTotalStock.Width = 0.75F;
            // 
            // Wh_StockPrice
            // 
            this.Wh_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.DataField = "StockPrice";
            this.Wh_StockPrice.Height = 0.219F;
            this.Wh_StockPrice.Left = 6F;
            this.Wh_StockPrice.MultiLine = false;
            this.Wh_StockPrice.Name = "Wh_StockPrice";
            this.Wh_StockPrice.OutputFormat = resources.GetString("Wh_StockPrice.OutputFormat");
            this.Wh_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_StockPrice.SummaryGroup = "WareHouseHeader";
            this.Wh_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_StockPrice.Text = "1,234,567,890";
            this.Wh_StockPrice.Top = 0.03125F;
            this.Wh_StockPrice.Width = 0.96875F;
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
            this.Line.Top = 0F;
            this.Line.Width = 10.8F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.8F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // SlipHeader
            // 
            this.SlipHeader.CanShrink = true;
            this.SlipHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.BfSectionGuideSnm,
            this.BfSectionCode,
            this.Line37,
            this.BfEnterWarehName,
            this.BfShelfNo,
            this.ShipmentScdlDay,
            this.ShipmentFixDay,
            this.ArrivalGoodsDay,
            this.StockMoveSlipNo,
            this.AfSectionCode,
            this.AfSectionGuideSnm,
            this.AfEnterWarehName,
            this.AfShelfNo});
            this.SlipHeader.DataField = "StockMoveSlipNo";
            this.SlipHeader.Height = 0.2604167F;
            this.SlipHeader.KeepTogether = true;
            this.SlipHeader.Name = "SlipHeader";
            this.SlipHeader.AfterPrint += new System.EventHandler(this.SlipHeader_AfterPrint);
            // 
            // SlipFooter
            // 
            this.SlipFooter.CanShrink = true;
            this.SlipFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SLIPTOTALTITLE,
            this.Sl_MovingTotalStock,
            this.Sl_StockPrice,
            this.line2});
            this.SlipFooter.Height = 0.25F;
            this.SlipFooter.KeepTogether = true;
            this.SlipFooter.Name = "SlipFooter";
            // 
            // SLIPTOTALTITLE
            // 
            this.SLIPTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SLIPTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SLIPTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SLIPTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SLIPTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SLIPTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SLIPTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SLIPTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SLIPTOTALTITLE.Height = 0.219F;
            this.SLIPTOTALTITLE.Left = 2.875F;
            this.SLIPTOTALTITLE.MultiLine = false;
            this.SLIPTOTALTITLE.Name = "SLIPTOTALTITLE";
            this.SLIPTOTALTITLE.OutputFormat = resources.GetString("SLIPTOTALTITLE.OutputFormat");
            this.SLIPTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SLIPTOTALTITLE.Text = "伝票計";
            this.SLIPTOTALTITLE.Top = 0.03F;
            this.SLIPTOTALTITLE.Width = 0.6875F;
            // 
            // Sl_MovingTotalStock
            // 
            this.Sl_MovingTotalStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Sl_MovingTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_MovingTotalStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Sl_MovingTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_MovingTotalStock.Border.RightColor = System.Drawing.Color.Black;
            this.Sl_MovingTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_MovingTotalStock.Border.TopColor = System.Drawing.Color.Black;
            this.Sl_MovingTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_MovingTotalStock.DataField = "MoveCount";
            this.Sl_MovingTotalStock.Height = 0.219F;
            this.Sl_MovingTotalStock.Left = 5.25F;
            this.Sl_MovingTotalStock.MultiLine = false;
            this.Sl_MovingTotalStock.Name = "Sl_MovingTotalStock";
            this.Sl_MovingTotalStock.OutputFormat = resources.GetString("Sl_MovingTotalStock.OutputFormat");
            this.Sl_MovingTotalStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sl_MovingTotalStock.SummaryGroup = "SlipHeader";
            this.Sl_MovingTotalStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sl_MovingTotalStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sl_MovingTotalStock.Text = "12345";
            this.Sl_MovingTotalStock.Top = 0.03F;
            this.Sl_MovingTotalStock.Width = 0.75F;
            // 
            // Sl_StockPrice
            // 
            this.Sl_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sl_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sl_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sl_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sl_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_StockPrice.DataField = "StockPrice";
            this.Sl_StockPrice.Height = 0.219F;
            this.Sl_StockPrice.Left = 6F;
            this.Sl_StockPrice.MultiLine = false;
            this.Sl_StockPrice.Name = "Sl_StockPrice";
            this.Sl_StockPrice.OutputFormat = resources.GetString("Sl_StockPrice.OutputFormat");
            this.Sl_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sl_StockPrice.SummaryGroup = "SlipHeader";
            this.Sl_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sl_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sl_StockPrice.Text = "1,234,567,890";
            this.Sl_StockPrice.Top = 0.03F;
            this.Sl_StockPrice.Width = 0.969F;
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
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // MAZAI02032P_01A4C
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
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WareHouseHeader);
            this.Sections.Add(this.SlipHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SlipFooter);
            this.Sections.Add(this.WareHouseFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02032P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02032P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentScdlDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentFixDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalGoodsDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMoveSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintSortOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentScdlDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentFixDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ArrivalGoodsDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockMoveSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ListPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockUnitPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MovePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_InputDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_MovingTotalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_MovingTotalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WAREHOUSETOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MovingTotalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLIPTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_MovingTotalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void TitleHeader_AfterPrint(object sender, EventArgs e)
        {
            // ヘッダー印字時に初期化
            this.printFirst = string.Empty;     //ADD 2008/10/02
        }

        private void SlipHeader_AfterPrint(object sender, EventArgs e)
        {
            // 伝票番号単位のヘッダー印字時に値を入れる
            this.printFirst = "SlipHeader";     //ADD 2008/10/02
        }
	}
}
