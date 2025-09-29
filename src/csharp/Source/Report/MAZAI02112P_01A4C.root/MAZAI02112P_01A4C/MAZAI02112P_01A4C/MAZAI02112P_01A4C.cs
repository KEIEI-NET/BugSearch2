using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 棚卸記入表印刷(簡易)フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 棚卸記入表のフォームクラスです。</br>
	/// <br>Programmer	: 23010　中村　仁</br>
	/// <br>Date		: 2007.04.10</br>
    /// <br>Update Note : 2007.09.05 980035 金沢 貞義</br>
    /// <br>			  ・DC.NS対応</br>
    /// <br>Update Note : 2008.02.13 980035 金沢 貞義</br>
    /// <br>			  ・不具合対応（DC.NS対応）</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : PM.NS対応</br>
    /// <br>Programmer  : 30413 犬飼</br>
    /// <br>Date	    : 2008.10.14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : MANTIS対応(13918)</br>
    /// <br>Programmer  : 22008 長内</br>
    /// <br>Date	    : 2009/09/16</br>
    /// <br>UpdateNote  : 不具合対応(PM.NS保守依頼③対応)</br>
    /// <br>Programmer  : 呉元嘯</br>
    /// <br>Date	    : 2009/12/07</br>
    /// <br>UpdateNote  : Redmine#1969対応</br>
    /// <br>Programmer  : 呉元嘯</br>
    /// <br>Date	    : 2009/12/17</br>
    /// <br>UpdateNote  : 不具合対応(PM1005)</br>
    /// <br>Programmer  : 呉元嘯</br>
    /// <br>Date	    : 2010/02/20</br>
    /// <br>UpdateNote  : 2013/01/16配信分、Redmine#33271  印字制御の区分の追加</br>
    /// <br>Programmer  : 李亜博</br>
    /// <br>Date	    : 2012/11/14</br>
    /// </remarks>
	public class MAZAI02112P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region Constructor
        /// <summary>
		/// 棚卸記入表(簡易)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 棚卸記入表(簡易)フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 23010　中村　仁</br>
		/// <br>Date		: 2007.04.10</br>
		/// </remarks>
		public MAZAI02112P_01A4C()
		{
			InitializeComponent();
        }
        #endregion

        #region Private Member
        private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			 _otherDataList;				// その他データ
	
		private	InventSearchCndtnUI _extrInfo;					// 抽出条件クラス

        // その他データ格納項目		
		private int					 _printCount;					// ページ数カウント用
       
		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
		ListCommon_PageFooter _rptPageFooter	= null;

        //サプレス用バッファ(倉庫)
        //private string _warehouseBuff = "";
        // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
        ////サプレス用バッファ(事業者)
        //private string _CarrierEpBuff = "";
        ////サプレス用バッファ(商品大分類)
        //private string _largeGoodsBuff = "";
        ////サプレス用バッファ(商品中分類)
        //private string _mediumGoodsBuff = "";
        //サプレス用バッファ(棚番)
        //private string _warehouseShelfNoBuff = "";
        // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
        //サプレス用バッファ(メーカー)
        //private string _makerBuff = "";
        // 2009.02.16 30413 犬飼 グループサプレス制御を追加 >>>>>>START
        private string _groupSuppres = "";
        // 2009.02.16 30413 犬飼 グループサプレス制御を追加 <<<<<<END
        private string _groupSuppresWarehouseShelfNo = ""; //ADD 2009/12/17
        private TextBox StockSectionCode;
        private Label Maker_Title;
        private Label SupplierCd_Title;
        private Label BLGoodsCode_Title;
        private Label BLGroupCode_Title;
        private TextBox InventStockCount_TextBox;
        private TextBox MakerCode_TextBox;
        private TextBox SupplierCd_TextBox;
        private TextBox BLGoodsCode_TextBox;
        private TextBox BLGroupCode_TextBox;
        private TextBox InventorySeqNo_TextBox;
        private Line line3;
        private Line Line_PageFooter;
        private TextBox PageFooters0;
        private TextBox PageFooters1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox BlankShowFlag;
        private TextBox InvStockCntFlag;
        private TextBox WareInventStockCount_TextBox;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox GrandInventStockCount_TextBox;
        private TextBox textBox8;
        private Line line6;

		// Disposeチェック用フラグ
		bool disposed = false;

		#endregion PrivateMembers

		#region Dispose(override)
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
		#endregion

		#region Public Property
		#region IPrintActiveReportTypeList メンバ
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
				this._printInfo = value;
				this._extrInfo = (InventSearchCndtnUI)this._printInfo.jyoken;
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
			}
		}

		/// <summary>
		/// 帳票サブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderSubtitle = value;}
		}

		/// <summary>
		///	印刷件数カウントアップイベント
		/// </summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;        
		#endregion
		#region IPrintActiveReportTypeCommon メンバ

		/// <summary>
		/// 背景透過設定値プロパティ
		/// </summary>
		public int WatermarkMode
		{
			get{return 0;}
			set{}
		}

		#endregion
		#endregion

		#region Private Method

        #region レポート要素出力設定
        /// <summary>
		/// レポート要素出力設定
		/// </summary>
 		/// <remarks>
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
        /// <br>Update Note: 2010/02/20 呉元嘯</br>
        /// <br>			 不具合対応(PM1005)</br>
        /// <br>Update Note: 2012/11/14 李亜博</br>
        ///	<br>			 Redmine#33271 印字制御の区分の追加</br>
        /// </remarks>
		private void SetOfReportMembersOutput()
		{
            // 2008.10.31 30413 犬飼 未登録プロパティのため削除 >>>>>>START
            ////帳簿数印字区分
            //if(this._extrInfo.StockCntPrintDiv == 1)
            //{
            //    //帳簿数を印字しない
            //    ScreenPermitionControl(false);
            //    this.StockCount_Title.Text = "棚卸数";
            //    this.InventStockCount_Title.Text = "メモ記入欄";
            //}
            //else
            //{
            //    //帳簿数を印字する
            //    ScreenPermitionControl(true);
            //    this.StockCount_Title.Text = "帳簿数";
            //    this.InventStockCount_Title.Text = "棚卸数";
            //}
            // 2008.10.31 30413 犬飼 未登録プロパティのため削除 <<<<<<END
		    
            // 項目の名称をセット
			SortTitle.Text	= this._pageHeaderSortOderTitle;	// ソート条件    

            // 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
            // 改ページ指定区分
            if (this._extrInfo.TurnOoverThePagesDiv == 2)
            {
                // 改ページなし
                //this.WarehouseHeader.DataField = "";
                this.WarehouseHeader.NewPage = NewPage.None;
                this.MakerHeader.NewPage = NewPage.None;
                this.GoodsHeader.NewPage = NewPage.None;
                // -----------ADD 2010/02/20------------>>>>>
                // 計印字「する」の場合
                if (this._extrInfo.SubtotalPrintDivTemp == 1)
                {
                    this.WarehouseFooter.Visible = true;
                    this.GrandTotalFooter.Visible = true;
                }
                else
                {
                    this.WarehouseFooter.Visible = false;
                    this.GrandTotalFooter.Visible = false;
                }
                // -----------ADD 2010/02/20------------<<<<<
            }
            else if (this._extrInfo.TurnOoverThePagesDiv == 1)
            {
                // 出力順
                if (this._extrInfo.SortDiv == 0)
                {
                    // 倉庫→棚番
                    this.MakerHeader.DataField = "WarehouseShelfNo_Print";
                }
                else if (this._extrInfo.SortDiv == 1)
                {
                    // 倉庫→仕入先
                    this.MakerHeader.DataField = "SupplierCd";
                }
                else if (this._extrInfo.SortDiv == 2)
                {
                    // 倉庫→ＢＬコード
                    this.MakerHeader.DataField = "BLGoodsCode";
                }
                else if (this._extrInfo.SortDiv == 3)
                {
                    // 倉庫→グループ
                    this.MakerHeader.DataField = "BLGroupCode";
                }
                else if (this._extrInfo.SortDiv == 4)
                {
                    // 倉庫→メーカー
                    this.MakerHeader.DataField = "GoodsMakerCd";
                }
                else if (this._extrInfo.SortDiv == 5)
                {
                    // 倉庫→仕入先→棚番
                    this.MakerHeader.DataField = "SupplierCd";
                    this.GoodsHeader.DataField = "WarehouseShelfNo_Print";
                }
                else if (this._extrInfo.SortDiv == 6)
                {
                    // 倉庫→仕入先→メーカー
                    this.MakerHeader.DataField = "SupplierCd";
                    this.GoodsHeader.DataField = "GoodsMakerCd";
                }
                // -----------ADD 2010/02/20------------>>>>>
                // 計印字「する」の場合
                if (this._extrInfo.SubtotalPrintDivTemp == 1)
                {
                    this.WarehouseFooter.Visible = true;
                    this.GrandTotalFooter.Visible = true;
                }
                else
                {
                    this.WarehouseFooter.Visible = false;
                    this.GrandTotalFooter.Visible = false;
                }
                // -----------ADD 2010/02/20------------<<<<<
            }
            // 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<
            // -----------ADD 2010/02/20------------>>>>>
            // [改ページ指定区分:倉庫]の場合
            else
            {
                // 計印字「する」の場合
                if (this._extrInfo.SubtotalPrintDivTemp == 1)
                {
                    this.WarehouseFooter.Visible = true;
                    this.GrandTotalFooter.Visible = true;
                }
                else
                {
                    this.WarehouseFooter.Visible = false;
                    this.GrandTotalFooter.Visible = false;
                }
            }
            // -----------ADD 2010/02/20------------<<<<<
            // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
            //罫線印字区分
            if (this._extrInfo.LineMaSqOfChDiv == 0)
            {
                //罫線印字する
                this.Line.Visible = true;
                this.Line2.Visible = true;
                this.line3.Visible = true;
                this.Line37.Visible = true;
                this.Line5.Visible = true;
                this.Line44.Visible = true;
                this.line6.Visible = false;
            }
            else
            {
                //罫線印字しない
                this.Line.Visible = false;
                this.Line2.Visible = false;
                this.line3.Visible = false;
                this.Line37.Visible = false;
                this.Line5.Visible = false;
                this.Line44.Visible = false;
                this.line6.Visible = true;
            }
            // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

        }

        #endregion

        #region 出力順での印字パターン変更処理
        /// <summary>
        /// 出力順での印字パターン変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力順に合わせて、印字パターンを変更します</br>
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2008.10.16</br>
        /// <br>Update Note: 2009/12/07 呉元嘯</br>
        /// <br>			 不具合対応(PM.NS保守依頼③対応)</br>
        /// <br>Update Note: 2009/12/17 呉元嘯</br>
        /// <br>			 Redmine#1969対応</br>
        /// <br>Update Note: 2010/02/20 呉元嘯</br>
        /// <br>			 不具合対応(PM1005)</br>
        /// </remarks>
        private void SetOutputPrintPattern()
        {
            switch (this._extrInfo.SortDiv)
            {
                // ---------------- UPD 2009/12/07 ---------------->>>>>
                case 1:     // 仕入先順
                case 5:     // 仕入先・棚番順
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// 明細タイトル
                        //SupplierCd_Title.Left = 0.0F;               // 仕入先
                        //WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        //GoodsNo_Title.Left = 1.063F;              // 品番
                        //GoodsName_Title.Left = 2.5F;                // 品名
                        //StockCount_Title.Left = 3.688F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.125F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 4.875F;         // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_Title.Left = 5.688F;            // BLコード
                        ////BLGroupCode_Title.Left = 6.125F;            // グループコード
                        ////Maker_Title.Left = 6.563F;                  // メーカー
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_Title.Left = 5.788F;            // BLコード
                        //BLGroupCode_Title.Left = 6.225F;            // グループコード
                        //Maker_Title.Left = 6.663F;                  // メーカー
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// 明細行
                        //SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.063F;            // 品番
                        //GoodsName_TextBox.Left = 2.5F;              // 品名
                        //StockCount_TextBox.Left = 3.688F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.125F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 4.875F;       // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_TextBox.Left = 5.688F;          // BLコード
                        ////BLGroupCode_TextBox.Left = 6.125F;          // グループコード
                        ////MakerCode_TextBox.Left = 6.563F;            // メーカー
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_TextBox.Left = 5.788F;          // BLコード
                        //BLGroupCode_TextBox.Left = 6.225F;          // グループコード
                        //MakerCode_TextBox.Left = 6.663F;            // メーカー
                        //// --- ADD 2009/03/12 --------------------------------<<<<<
                        // -- UPD 2009/09/16 ----------------------------<<<

                        //// 明細タイトル
                        //SupplierCd_Title.Left = 0.0F;               // 仕入先
                        //WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        //GoodsNo_Title.Left = 1.063F;              // 品番
                        //GoodsName_Title.Left = 2.5F;                // 品名
                        //StockCount_Title.Left = 3.688F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.275F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 5.025F;         // 原単価
                        //BLGoodsCode_Title.Left = 5.878F;            // BLコード
                        //BLGroupCode_Title.Left = 6.265F;            // グループコード
                        //Maker_Title.Left = 6.653F;                  // メーカー

                        //// 明細行
                        //SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.063F;            // 品番
                        //GoodsName_TextBox.Left = 2.5F;              // 品名
                        //StockCount_TextBox.Left = 3.688F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.275F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 5.025F;       // 原単価
                        //BLGoodsCode_TextBox.Left = 5.878F;          // BLコード
                        //BLGroupCode_TextBox.Left = 6.265F;          // グループコード
                        //MakerCode_TextBox.Left = 6.653F;            // メーカー

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //SupplierCd_Title.Left = 0.0F;                  // 仕入先
                        //WarehouseShelfNo_Title.Left = 0.433F;         // 棚番
                        //GoodsNo_Title.Left = 1.126F;                  // 品番
                        //GoodsName_Title.Left = 3.659F;                // 品名
                        //StockCount_Title.Left = 4.872F;              // 帳簿数
                        //InventStockCount_Title.Left = 5.542F;        // 棚卸数
                        //StockUnitPrice_Title.Left = 6.425F;         // 原単価
                        //BLGoodsCode_Title.Left = 7.188F;            // BLコード
                        //BLGroupCode_Title.Left = 7.621F;            // グループコード
                        //Maker_Title.Left = 8.054F;                  // メーカー

                        //// 明細行
                        //SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        //WarehouseShelfNo_TextBox.Left = 0.433F;    // 棚番
                        //GoodsNo_TextBox.Left = 1.126F;            // 品番
                        //GoodsName_TextBox.Left = 3.659F;              // 品名
                        //StockCount_TextBox.Left = 4.872F;           // 帳簿数
                        //textBox1.Left = 5.472F;                      // (
                        //InventStockCount_TextBox.Left = 5.542F;     // 棚卸数
                        //textBox2.Left = 6.355F;                      // )
                        //StockUnitPrice_TextBox.Left = 6.425F;       // 原単価
                        //BLGoodsCode_TextBox.Left = 7.188F;          // BLコード
                        //BLGroupCode_TextBox.Left = 7.621F;          // グループコード
                        //MakerCode_TextBox.Left = 8.054F;            // メーカー
                        //// --- ADD 2009/03/12 --------------------------------<<<<<
                        SupplierCd_Title.Left = 0.0F;                  // 仕入先
                        WarehouseShelfNo_Title.Left = 0.388F;         // 棚番
                        GoodsNo_Title.Left = 1.01F;                  // 品番
                        GoodsName_Title.Left = 3.273F;                // 品名
                        StockCount_Title.Left = 4.357F;              // 帳簿数
                        InventStockCount_Title.Left = 4.951F;        // 棚卸数
                        StockUnitPrice_Title.Left = 5.565F;         // 原単価
                        BLGoodsCode_Title.Left = 6.289F;            // BLコード
                        BLGroupCode_Title.Left = 6.611F;            // グループコード
                        Maker_Title.Left = 6.939F;                  // メーカー

                        // 明細行
                        SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        WarehouseShelfNo_TextBox.Left = 0.388F;    // 棚番
                        GoodsNo_TextBox.Left = 1.01F;            // 品番
                        GoodsName_TextBox.Left = 3.273F;              // 品名
                        StockCount_TextBox.Left = 4.357F;           // 帳簿数
                        textBox1.Left = 4.919F;                      // (
                        InventStockCount_TextBox.Left = 4.951F;     // 棚卸数
                        textBox2.Left = 5.534F;                      // )
                        StockUnitPrice_TextBox.Left = 5.565F;       // 原単価
                        BLGoodsCode_TextBox.Left = 6.289F;          // BLコード
                        BLGroupCode_TextBox.Left = 6.611F;          // グループコード
                        MakerCode_TextBox.Left = 6.939F;            // メーカー
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.273F;
                        this.textBox5.Left = 4.919F;
                        this.WareStockCount_TextBox.Left = 4.357F;
                        this.WareInventStockCount_TextBox.Left = 4.951F;
                        this.textBox6.Left = 5.534F;
                        this.GrandTotal_Title.Left = 3.273F;
                        this.textBox4.Left = 4.919F;
                        this.GrandStockCount_TextBox.Left = 4.357F;
                        this.GrandInventStockCount_TextBox.Left = 4.951F;
                        this.textBox8.Left = 5.534F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 2:     // BLコード順
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// 明細タイトル
                        //BLGoodsCode_Title.Left = 0.0F;              // BLコード
                        //WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        //GoodsNo_Title.Left = 1.063F;              // 品番
                        //GoodsName_Title.Left = 2.5F;                // 品名
                        //StockCount_Title.Left = 3.688F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.125F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 4.875F;         // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_Title.Left = 5.688F;             // 仕入先
                        ////BLGroupCode_Title.Left = 6.125F;            // グループコード
                        ////Maker_Title.Left = 6.563F;                  // メーカー
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_Title.Left = 5.788F;             // 仕入先
                        //BLGroupCode_Title.Left = 6.225F;            // グループコード
                        //Maker_Title.Left = 6.663F;                  // メーカー
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// 明細行
                        //BLGoodsCode_TextBox.Left = 0.0F;            // BLコード
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.063F;            // 品番
                        //GoodsName_TextBox.Left = 2.5F;              // 品名
                        //StockCount_TextBox.Left = 3.688F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.125F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 4.875F;       // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_TextBox.Left = 5.688F;           // 仕入先
                        ////BLGroupCode_TextBox.Left = 6.125F;          // グループコード
                        ////MakerCode_TextBox.Left = 6.563F;            // メーカー
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_TextBox.Left = 5.788F;           // 仕入先
                        //BLGroupCode_TextBox.Left = 6.225F;          // グループコード
                        //MakerCode_TextBox.Left = 6.663F;            // メーカー
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        // 明細タイトル
                        //BLGoodsCode_Title.Left = 0.0F;              // BLコード
                        //WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        //GoodsNo_Title.Left = 1.063F;              // 品番
                        //GoodsName_Title.Left = 2.5F;                // 品名
                        //StockCount_Title.Left = 3.688F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.275F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 5.025F;         // 原単価
                        //SupplierCd_Title.Left = 5.878F;             // 仕入先
                        //BLGroupCode_Title.Left = 6.305F;            // グループコード
                        //Maker_Title.Left = 6.653F;                  // メーカー

                        //// 明細行
                        //BLGoodsCode_TextBox.Left = 0.0F;            // BLコード
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.063F;            // 品番
                        //GoodsName_TextBox.Left = 2.5F;              // 品名
                        //StockCount_TextBox.Left = 3.688F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.275F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 5.025F;       // 原単価
                        //SupplierCd_TextBox.Left = 5.878F;           // 仕入先
                        //BLGroupCode_TextBox.Left = 6.305F;          // グループコード
                        //MakerCode_TextBox.Left = 6.653F;            // メーカー

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //BLGoodsCode_Title.Left = 0.0F;              // BLコード
                        //WarehouseShelfNo_Title.Left = 0.433F;         // 棚番
                        //GoodsNo_Title.Left = 1.126F;                  // 品番
                        //GoodsName_Title.Left = 3.659F;                // 品名
                        //StockCount_Title.Left = 4.872F;              // 帳簿数
                        //InventStockCount_Title.Left = 5.542F;        // 棚卸数
                        //StockUnitPrice_Title.Left = 6.425F;         // 原単価
                        //SupplierCd_Title.Left = 7.188F;             // 仕入先
                        //BLGroupCode_Title.Left = 7.621F;            // グループコード
                        //Maker_Title.Left = 8.054F;                  // メーカー

                        //// 明細行
                        //BLGoodsCode_TextBox.Left = 0.0F;            // BLコード
                        //WarehouseShelfNo_TextBox.Left = 0.433F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.126F;            // 品番
                        //GoodsName_TextBox.Left = 3.659F;              // 品名
                        //StockCount_TextBox.Left = 4.872F;           // 帳簿数
                        //textBox1.Left = 5.472F;                      // (
                        //InventStockCount_TextBox.Left = 5.542F;     // 棚卸数
                        //textBox2.Left = 6.355F;                      // )
                        //StockUnitPrice_TextBox.Left = 6.425F;       // 原単価
                        //SupplierCd_TextBox.Left = 7.188F;           // 仕入先
                        //BLGroupCode_TextBox.Left = 7.621F;          // グループコード
                        //MakerCode_TextBox.Left = 8.054F;            // メーカー
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        BLGoodsCode_Title.Left = 0.0F;              // BLコード
                        WarehouseShelfNo_Title.Left = 0.322F;         // 棚番
                        GoodsNo_Title.Left = 0.947F;                  // 品番
                        GoodsName_Title.Left = 3.207F;                // 品名
                        StockCount_Title.Left = 4.291F;              // 帳簿数
                        InventStockCount_Title.Left = 4.887F;        // 棚卸数
                        StockUnitPrice_Title.Left = 5.501F;         // 原単価
                        SupplierCd_Title.Left = 6.225F;             // 仕入先
                        BLGroupCode_Title.Left = 6.613F;            // グループコード
                        Maker_Title.Left = 6.941F;                  // メーカー

                        // 明細行
                        BLGoodsCode_TextBox.Left = 0.0F;            // BLコード
                        WarehouseShelfNo_TextBox.Left = 0.322F;       // 棚番
                        GoodsNo_TextBox.Left = 0.947F;            // 品番
                        GoodsName_TextBox.Left = 3.207F;              // 品名
                        StockCount_TextBox.Left = 4.291F;           // 帳簿数
                        textBox1.Left = 4.855F;                      // (
                        InventStockCount_TextBox.Left = 4.887F;     // 棚卸数
                        textBox2.Left = 5.47F;                      // )
                        StockUnitPrice_TextBox.Left = 5.501F;       // 原単価
                        SupplierCd_TextBox.Left = 6.225F;           // 仕入先
                        BLGroupCode_TextBox.Left = 6.613F;          // グループコード
                        MakerCode_TextBox.Left = 6.941F;            // メーカー
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.207F;
                        this.textBox5.Left = 4.855F;
                        this.WareStockCount_TextBox.Left = 4.291F;
                        this.WareInventStockCount_TextBox.Left = 4.887F;
                        this.textBox6.Left = 5.47F;
                        this.GrandTotal_Title.Left = 3.207F;
                        this.textBox4.Left = 4.855F;
                        this.GrandStockCount_TextBox.Left = 4.291F;
                        this.GrandInventStockCount_TextBox.Left = 4.887F;
                        this.textBox8.Left = 5.47F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 3:     // グループコード順
                    {

                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// 明細タイトル
                        //BLGroupCode_Title.Left = 0.0F;              // グループコード
                        //WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        //GoodsNo_Title.Left = 1.063F;              // 品番
                        //GoodsName_Title.Left = 2.5F;                // 品名
                        //StockCount_Title.Left = 3.688F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.125F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 4.875F;         // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_Title.Left = 5.688F;             // 仕入先
                        ////BLGoodsCode_Title.Left = 6.125F;            // BLコード
                        ////Maker_Title.Left = 6.563F;                  // メーカー
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_Title.Left = 5.788F;             // 仕入先
                        //BLGoodsCode_Title.Left = 6.225F;            // BLコード
                        //Maker_Title.Left = 6.663F;                  // メーカー
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// 明細行
                        //BLGroupCode_TextBox.Left = 0.0F;            // グループコード
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.063F;            // 品番
                        //GoodsName_TextBox.Left = 2.5F;              // 品名
                        //StockCount_TextBox.Left = 3.688F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.125F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 4.875F;       // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_TextBox.Left = 5.688F;           // 仕入先
                        ////BLGoodsCode_TextBox.Left = 6.125F;          // BLコード
                        ////MakerCode_TextBox.Left = 6.563F;            // メーカー
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_TextBox.Left = 5.788F;           // 仕入先
                        //BLGoodsCode_TextBox.Left = 6.225F;          // BLコード
                        //MakerCode_TextBox.Left = 6.663F;            // メーカー
                        //// --- ADD 2009/03/12 --------------------------------<<<<<
                        // 明細タイトル
                        //BLGroupCode_Title.Left = 0.0F;              // グループコード
                        //WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        //GoodsNo_Title.Left = 1.063F;              // 品番
                        //GoodsName_Title.Left = 2.5F;                // 品名
                        //StockCount_Title.Left = 3.688F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.275F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 5.025F;         // 原単価
                        //SupplierCd_Title.Left = 5.878F;             // 仕入先
                        //BLGoodsCode_Title.Left = 6.305F;            // BLコード
                        //Maker_Title.Left = 6.653F;                  // メーカー

                        //// 明細行
                        //BLGroupCode_TextBox.Left = 0.0F;            // グループコード
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.063F;            // 品番
                        //GoodsName_TextBox.Left = 2.5F;              // 品名
                        //StockCount_TextBox.Left = 3.688F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.275F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 5.025F;       // 原単価
                        //SupplierCd_TextBox.Left = 5.878F;           // 仕入先
                        //BLGoodsCode_TextBox.Left = 6.305F;          // BLコード
                        //MakerCode_TextBox.Left = 6.653F;            // メーカー

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //BLGroupCode_Title.Left = 0.0F;              // グループコード
                        //WarehouseShelfNo_Title.Left = 0.433F;         // 棚番
                        //GoodsNo_Title.Left = 1.126F;                  // 品番
                        //GoodsName_Title.Left = 3.659F;                // 品名
                        //StockCount_Title.Left = 4.872F;              // 帳簿数
                        //InventStockCount_Title.Left = 5.542F;        // 棚卸数
                        //StockUnitPrice_Title.Left = 6.425F;         // 原単価
                        //SupplierCd_Title.Left = 7.188F;             // 仕入先
                        //BLGoodsCode_Title.Left = 7.621F;            // BLコード
                        //Maker_Title.Left = 8.054F;                  // メーカー

                        //// 明細行
                        //BLGroupCode_TextBox.Left = 0.0F;            // グループコード
                        //WarehouseShelfNo_TextBox.Left = 0.433F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.126F;            // 品番
                        //GoodsName_TextBox.Left = 3.659F;              // 品名
                        //StockCount_TextBox.Left = 4.872F;           // 帳簿数
                        //textBox1.Left = 5.472F;                      // (
                        //InventStockCount_TextBox.Left = 5.542F;     // 棚卸数
                        //textBox2.Left = 6.355F;                      // )
                        //StockUnitPrice_TextBox.Left = 6.425F;       // 原単価
                        //SupplierCd_TextBox.Left = 7.188F;           // 仕入先
                        //BLGoodsCode_TextBox.Left = 7.621F;          // BLコード
                        //MakerCode_TextBox.Left = 8.054F;            // メーカー
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        BLGroupCode_Title.Left = 0.0F;              // グループコード
                        WarehouseShelfNo_Title.Left = 0.328F;         // 棚番
                        GoodsNo_Title.Left = 0.953F;                  // 品番
                        GoodsName_Title.Left = 3.213F;                // 品名
                        StockCount_Title.Left = 4.297F;              // 帳簿数
                        InventStockCount_Title.Left = 4.891F;        // 棚卸数
                        StockUnitPrice_Title.Left = 5.505F;         // 原単価
                        SupplierCd_Title.Left = 6.229F;             // 仕入先
                        BLGoodsCode_Title.Left = 6.617F;            // BLコード
                        Maker_Title.Left = 6.945F;                  // メーカー

                        // 明細行
                        BLGroupCode_TextBox.Left = 0.0F;            // グループコード
                        WarehouseShelfNo_TextBox.Left = 0.328F;       // 棚番
                        GoodsNo_TextBox.Left = 0.953F;            // 品番
                        GoodsName_TextBox.Left = 3.213F;              // 品名
                        StockCount_TextBox.Left = 4.297F;           // 帳簿数
                        textBox1.Left = 4.859F;                      // (
                        InventStockCount_TextBox.Left = 4.891F;     // 棚卸数
                        textBox2.Left = 5.474F;                      // )
                        StockUnitPrice_TextBox.Left = 5.505F;       // 原単価
                        SupplierCd_TextBox.Left = 6.229F;           // 仕入先
                        BLGoodsCode_TextBox.Left = 6.617F;          // BLコード
                        MakerCode_TextBox.Left = 6.945F;            // メーカー
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.213F;
                        this.textBox5.Left = 4.859F;
                        this.WareStockCount_TextBox.Left = 4.297F;
                        this.WareInventStockCount_TextBox.Left = 4.891F;
                        this.textBox6.Left = 5.474F;
                        this.GrandTotal_Title.Left = 3.213F;
                        this.textBox4.Left = 4.859F;
                        this.GrandStockCount_TextBox.Left = 4.297F;
                        this.GrandInventStockCount_TextBox.Left = 4.891F;
                        this.textBox8.Left = 5.474F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 4:     // メーカー順
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// 明細タイトル
                        //Maker_Title.Left = 0.0F;                    // メーカー
                        //WarehouseShelfNo_Title.Left = 0.375F;       // 棚番
                        //GoodsNo_Title.Left = 0.938F;              // 品番
                        //GoodsName_Title.Left = 2.375F;              // 品名
                        //StockCount_Title.Left = 3.563F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.0F;         // 棚卸数
                        //StockUnitPrice_Title.Left = 4.75F;          // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_Title.Left = 5.563F;             // 仕入先
                        ////BLGoodsCode_Title.Left = 6.0F;              // BLコード
                        ////BLGroupCode_Title.Left = 6.438F;            // グループコード
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_Title.Left = 5.663F;             // 仕入先
                        //BLGoodsCode_Title.Left = 6.1F;              // BLコード
                        //BLGroupCode_Title.Left = 6.538F;            // グループコード
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// 明細行
                        //MakerCode_TextBox.Left = 0.0F;              // メーカー
                        //WarehouseShelfNo_TextBox.Left = 0.375F;     // 棚番
                        //GoodsNo_TextBox.Left = 0.938F;            // 品番
                        //GoodsName_TextBox.Left = 2.375F;            // 品名
                        //StockCount_TextBox.Left = 3.563F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.0F;       // 棚卸数
                        //StockUnitPrice_TextBox.Left = 4.75F;        // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_TextBox.Left = 5.563F;           // 仕入先
                        ////BLGoodsCode_TextBox.Left = 6.0F;            // BLコード
                        ////BLGroupCode_TextBox.Left = 6.438F;          // グループコード
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_TextBox.Left = 5.663F;           // 仕入先
                        //BLGoodsCode_TextBox.Left = 6.1F;            // BLコード
                        //BLGroupCode_TextBox.Left = 6.538F;          // グループコード
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        // 明細タイトル
                        //Maker_Title.Left = 0.0F;                    // メーカー
                        //WarehouseShelfNo_Title.Left = 0.375F;       // 棚番
                        //GoodsNo_Title.Left = 1.063F;              // 品番
                        //GoodsName_Title.Left = 2.5F;              // 品名
                        //StockCount_Title.Left = 3.688F;             // 帳簿数
                        //InventStockCount_Title.Left = 4.275F;         // 棚卸数
                        //StockUnitPrice_Title.Left = 5.025F;          // 原単価
                        //SupplierCd_Title.Left = 5.828F;             // 仕入先
                        //BLGoodsCode_Title.Left = 6.255F;              // BLコード
                        //BLGroupCode_Title.Left = 6.603F;            // グループコード

                        //// 明細行
                        //MakerCode_TextBox.Left = 0.0F;              // メーカー
                        //WarehouseShelfNo_TextBox.Left = 0.375F;     // 棚番
                        //GoodsNo_TextBox.Left = 1.063F;            // 品番
                        //GoodsName_TextBox.Left = 2.5F;            // 品名
                        //StockCount_TextBox.Left = 3.688F;           // 帳簿数
                        //InventStockCount_TextBox.Left = 4.275F;       // 棚卸数
                        //StockUnitPrice_TextBox.Left = 5.025F;        // 原単価
                        //SupplierCd_TextBox.Left = 5.828F;           // 仕入先
                        //BLGoodsCode_TextBox.Left = 6.255F;            // BLコード
                        //BLGroupCode_TextBox.Left = 6.603F;          // グループコード

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //Maker_Title.Left = 0.0F;                    // メーカー
                        //WarehouseShelfNo_Title.Left = 0.323F;         // 棚番
                        //GoodsNo_Title.Left = 1.016F;                  // 品番
                        //GoodsName_Title.Left = 3.549F;                // 品名
                        //StockCount_Title.Left = 4.762F;              // 帳簿数
                        //InventStockCount_Title.Left = 5.432F;        // 棚卸数
                        //StockUnitPrice_Title.Left = 6.315F;         // 原単価
                        //SupplierCd_Title.Left = 7.078F;             // 仕入先
                        //BLGoodsCode_Title.Left = 7.511F;              // BLコード
                        //BLGroupCode_Title.Left = 7.944F;            // グループコード

                        //// 明細行
                        //MakerCode_TextBox.Left = 0.0F;              // メーカー
                        //WarehouseShelfNo_TextBox.Left = 0.323F;       // 棚番
                        //GoodsNo_TextBox.Left = 1.016F;            // 品番
                        //GoodsName_TextBox.Left = 3.549F;              // 品名
                        //StockCount_TextBox.Left = 4.762F;           // 帳簿数
                        //textBox1.Left = 5.362F;                      // (
                        //InventStockCount_TextBox.Left = 5.432F;     // 棚卸数
                        //textBox2.Left = 6.245F;                           // )
                        //StockUnitPrice_TextBox.Left = 6.315F;       // 原単価
                        //SupplierCd_TextBox.Left = 7.078F;           // 仕入先
                        //BLGoodsCode_TextBox.Left = 7.511F;            // BLコード
                        //BLGroupCode_TextBox.Left = 7.944F;          // グループコード
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        Maker_Title.Left = 0.0F;                    // メーカー
                        WarehouseShelfNo_Title.Left = 0.269F;         // 棚番
                        GoodsNo_Title.Left = 0.894F;                  // 品番
                        GoodsName_Title.Left = 3.154F;                // 品名
                        StockCount_Title.Left = 4.238F;              // 帳簿数
                        InventStockCount_Title.Left = 4.832F;        // 棚卸数
                        StockUnitPrice_Title.Left = 5.446F;         // 原単価
                        SupplierCd_Title.Left = 6.17F;             // 仕入先
                        BLGoodsCode_Title.Left = 6.558F;              // BLコード
                        BLGroupCode_Title.Left = 6.88F;            // グループコード

                        // 明細行
                        MakerCode_TextBox.Left = 0.0F;              // メーカー
                        WarehouseShelfNo_TextBox.Left = 0.269F;       // 棚番
                        GoodsNo_TextBox.Left = 0.894F;            // 品番
                        GoodsName_TextBox.Left = 3.154F;              // 品名
                        StockCount_TextBox.Left = 4.238F;           // 帳簿数
                        textBox1.Left = 4.8F;                      // (
                        InventStockCount_TextBox.Left = 4.832F;     // 棚卸数
                        textBox2.Left = 5.415F;                     // )
                        StockUnitPrice_TextBox.Left = 5.446F;       // 原単価
                        SupplierCd_TextBox.Left = 6.17F;           // 仕入先
                        BLGoodsCode_TextBox.Left = 6.558F;            // BLコード
                        BLGroupCode_TextBox.Left = 6.88F;          // グループコード
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.154F;
                        this.textBox5.Left = 4.8F;
                        this.WareStockCount_TextBox.Left = 4.238F;
                        this.WareInventStockCount_TextBox.Left = 4.832F;
                        this.textBox6.Left = 5.415F;
                        this.GrandTotal_Title.Left = 3.154F;
                        this.textBox4.Left = 4.8F;
                        this.GrandStockCount_TextBox.Left = 4.238F;
                        this.GrandInventStockCount_TextBox.Left = 4.832F;
                        this.textBox8.Left = 5.415F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 6:     // 仕入先・メーカー順
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// 明細タイトル
                        //SupplierCd_Title.Left = 0.0F;               // 仕入先
                        //Maker_Title.Left = 0.5F;                    // メーカー
                        //WarehouseShelfNo_Title.Left = 0.813F;       // 棚番
                        //GoodsNo_Title.Left = 1.375F;              // 品番
                        //GoodsName_Title.Left = 2.813F;              // 品名
                        //StockCount_Title.Left = 4.0F;               // 帳簿数
                        //InventStockCount_Title.Left = 4.438F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 5.188F;         // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_Title.Left = 6.0F;              // BLコード
                        ////BLGroupCode_Title.Left = 6.438F;            // グループコード
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_Title.Left = 6.1F;              // BLコード
                        //BLGroupCode_Title.Left = 6.538F;            // グループコード
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// 明細行
                        //SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        //MakerCode_TextBox.Left = 0.5F;              // メーカー
                        //WarehouseShelfNo_TextBox.Left = 0.813F;     // 棚番
                        //GoodsNo_TextBox.Left = 1.375F;            // 品番
                        //GoodsName_TextBox.Left = 2.813F;            // 品名
                        //StockCount_TextBox.Left = 4.0F;             // 帳簿数
                        //InventStockCount_TextBox.Left = 4.438F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 5.188F;       // 原単価
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_TextBox.Left = 6.0F;            // BLコード
                        ////BLGroupCode_TextBox.Left = 6.438F;          // グループコード
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_TextBox.Left = 6.1F;            // BLコード
                        //BLGroupCode_TextBox.Left = 6.538F;          // グループコード
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        // 明細タイトル
                        //SupplierCd_Title.Left = 0.0F;               // 仕入先
                        //Maker_Title.Left = 0.5F;                    // メーカー
                        //WarehouseShelfNo_Title.Left = 0.813F;       // 棚番
                        //GoodsNo_Title.Left = 1.375F;              // 品番
                        //GoodsName_Title.Left = 2.813F;              // 品名
                        //StockCount_Title.Left = 4.0F;               // 帳簿数
                        //InventStockCount_Title.Left = 4.587F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 5.337F;         // 原単価
                        //BLGoodsCode_Title.Left = 6.255F;              // BLコード
                        //BLGroupCode_Title.Left = 6.603F;            // グループコード

                        //// 明細行
                        //SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        //MakerCode_TextBox.Left = 0.5F;              // メーカー
                        //WarehouseShelfNo_TextBox.Left = 0.813F;     // 棚番
                        //GoodsNo_TextBox.Left = 1.375F;            // 品番
                        //GoodsName_TextBox.Left = 2.813F;            // 品名
                        //StockCount_TextBox.Left = 4.0F;             // 帳簿数
                        //InventStockCount_TextBox.Left = 4.587F;     // 棚卸数
                        //StockUnitPrice_TextBox.Left = 5.337F;       // 原単価
                        //BLGoodsCode_TextBox.Left = 6.255F;            // BLコード
                        //BLGroupCode_TextBox.Left = 6.603F;          // グループコード

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //SupplierCd_Title.Left = 0.0F;               // 仕入先
                        //Maker_Title.Left = 0.433F;                    // メーカー
                        //WarehouseShelfNo_Title.Left = 0.756F;       // 棚番
                        //GoodsNo_Title.Left = 1.449F;              // 品番
                        //GoodsName_Title.Left = 3.982F;              // 品名
                        //StockCount_Title.Left = 5.195F;               // 帳簿数
                        //InventStockCount_Title.Left = 5.865F;       // 棚卸数
                        //StockUnitPrice_Title.Left = 6.748F;         // 原単価
                        //BLGoodsCode_Title.Left = 7.511F;              // BLコード
                        //BLGroupCode_Title.Left = 7.944F;            // グループコード

                        //// 明細行
                        //SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        //MakerCode_TextBox.Left = 0.433F;              // メーカー
                        //WarehouseShelfNo_TextBox.Left = 0.756F;     // 棚番
                        //GoodsNo_TextBox.Left = 1.449F;            // 品番
                        //GoodsName_TextBox.Left = 3.982F;            // 品名
                        //StockCount_TextBox.Left = 5.195F;           // 帳簿数
                        //textBox1.Left = 5.795F;                      // (
                        //InventStockCount_TextBox.Left = 5.865F;     // 棚卸数
                        //textBox2.Left = 6.678F;                           // )
                        //StockUnitPrice_TextBox.Left = 6.748F;       // 原単価
                        //BLGoodsCode_TextBox.Left = 7.511F;            // BLコード
                        //BLGroupCode_TextBox.Left = 7.944F;          // グループコード
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        SupplierCd_Title.Left = 0.0F;               // 仕入先
                        Maker_Title.Left = 0.388F;                    // メーカー
                        WarehouseShelfNo_Title.Left = 0.657F;       // 棚番
                        GoodsNo_Title.Left = 1.282F;              // 品番
                        GoodsName_Title.Left = 3.542F;              // 品名
                        StockCount_Title.Left = 4.626F;               // 帳簿数
                        InventStockCount_Title.Left = 5.22F;       // 棚卸数
                        StockUnitPrice_Title.Left = 5.834F;         // 原単価
                        BLGoodsCode_Title.Left = 6.558F;              // BLコード
                        BLGroupCode_Title.Left = 6.886F;            // グループコード

                        // 明細行
                        SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        MakerCode_TextBox.Left = 0.388F;              // メーカー
                        WarehouseShelfNo_TextBox.Left = 0.657F;     // 棚番
                        GoodsNo_TextBox.Left = 1.282F;            // 品番
                        GoodsName_TextBox.Left = 3.542F;            // 品名
                        StockCount_TextBox.Left = 4.626F;           // 帳簿数
                        textBox1.Left = 5.188F;                      // (
                        InventStockCount_TextBox.Left = 5.22F;     // 棚卸数
                        textBox2.Left = 5.803F;                           // )
                        StockUnitPrice_TextBox.Left = 5.834F;       // 原単価
                        BLGoodsCode_TextBox.Left = 6.558F;            // BLコード
                        BLGroupCode_TextBox.Left = 6.886F;          // グループコード
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.542F;
                        this.textBox5.Left = 5.188F;
                        this.WareStockCount_TextBox.Left = 4.626F;
                        this.WareInventStockCount_TextBox.Left = 5.22F;
                        this.textBox6.Left = 5.803F;
                        this.GrandTotal_Title.Left = 3.542F;
                        this.textBox4.Left = 5.188F;
                        this.GrandStockCount_TextBox.Left = 4.626F;
                        this.GrandInventStockCount_TextBox.Left = 5.22F;
                        this.textBox8.Left = 5.803F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                default:
                    {
                        break;
                    }
                // ---------------- UPD 2009/12/07 ----------------<<<<<
            }
        }
        #endregion

        #region 画面状態変更処理
        /// <summary>
		/// 画面状態変更処理
		/// </summary>
		/// <param name="conditon"></param>
		/// <remarks>
		/// <br>Note       : 帳簿数印字区分に合わせた画面状態変更処理を行います</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
        private void ScreenPermitionControl(bool conditon)
        {
            //フッタ
            this.GrandTotalFooter.Visible = conditon;
            this.WarehouseFooter.Visible = conditon;
            this.MakerFooter.Visible = conditon;
            // 2007.09.05 削除 >>>>>>>>>>>>>>>>>>>>
            //this.CellphoneModelFooter.Visible = conditon;
            // 2007.09.05 削除 <<<<<<<<<<<<<<<<<<<<
            this.GoodsFooter.Visible = conditon;
            //帳簿在庫数
            this.InventorySeqNo_Title.Visible = conditon;
            this.StockCount_TextBox.Visible = conditon;
            //this.StockCount_Title.Visible = conditon;

        }
        #endregion

        #region バッファクリア処理
        /// <summary>
        /// バッファクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス用のバッファを初期化します</br>
        /// <br>Programer : 23010 中村　仁</br>
        /// <br>Date      : 2007.04.10</br>
        /// </remarks>
        private void BufferClear()
        {
            //this._warehouseBuff = "";
            // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
            //this._CarrierEpBuff = "";
            //this._largeGoodsBuff = "";
            //this._mediumGoodsBuff = "";
            //this._warehouseShelfNoBuff = "";
            // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
            //this._makerBuff = "";

            // 2009.02.16 30413 犬飼 グループサプレス制御を追加 >>>>>>START
            this._groupSuppres = "";
            // 2009.02.16 30413 犬飼 グループサプレス制御を追加 <<<<<<END
        }

        #endregion

        #region グループサプレス処理
        /// <summary>
        /// グループサプレス処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス処理を行います</br>
        /// <br>Programer : 23010 中村　仁</br>
        /// <br>Date      : 2007.04.10</br>
        /// </remarks>    
        private void SetOfGroupSuppres()
        {      
            // 2009.02.16 30413 犬飼 未使用なので削除 >>>>>>START
            //TextBoxにNullが入ることがあるので一応Null判定を入れておく
            //グループサプレス処理(倉庫)    
            //if(this.WarehouseCode_TextBox.Text != null)
            //{               
            //    if(this.WarehouseCode_TextBox.Text.CompareTo(this._warehouseBuff) == 0)
            //    {
            //        this.Warehouse_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Warehouse_TextBox.Visible = true;
            //        //バッファ更新
            //        this._warehouseBuff = this.WarehouseCode_TextBox.Text;
            //    }            
            //}
            //else
            //{
            //    //例外的な場合
            //    //nullの場合は空文字と見なす
            //    if(this._warehouseBuff == string.Empty)
            //    {
            //        this.Warehouse_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Warehouse_TextBox.Visible = true;
            //        //バッファを空文字で更新
            //        this._warehouseBuff = string.Empty;
            //    }               
            //}
            // 2009.02.16 30413 犬飼 未使用なので削除 <<<<<<END
            
            // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////グループサプレス処理(事業者)
            //if(this.CarrierEpCode_TextBox.Text != null)
            //{               
            //    //比べるのはキャリアコード(int)
            //    if(this.CarrierEpCode_TextBox.Text.CompareTo(this._CarrierEpBuff) == 0)
            //    {
            //        this.CarrierEp_TextBox.Visible = false;                 
            //    }
            //    else
            //    {
            //        this.CarrierEp_TextBox.Visible = true;                  
            //        //バッファ更新
            //        this._CarrierEpBuff = this.CarrierEpCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //例外的な場合
            //    //nullの場合は空文字と見なす
            //    if(this._CarrierEpBuff == string.Empty)
            //    {
            //         this.CarrierEp_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.CarrierEp_TextBox.Visible = true;
            //        //バッファを空文字で更新
			//        this._CarrierEpBuff = string.Empty;
            //    }            
            //}
            ////グループサプレス処理(商品大分類)
            //if (this.LgGoosCode_TextBox.Text != null)
            //{
            //    if (this.LgGoosCode_TextBox.Text.CompareTo(this._largeGoodsBuff) == 0)
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = true;
            //        //バッファ更新
            //        this._largeGoodsBuff = this.LgGoosCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //例外的な場合
            //    //nullの場合は空文字と見なす
            //    if (this._largeGoodsBuff == string.Empty)
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = true;
            //        //バッファを空文字で更新
            //        this._largeGoodsBuff = string.Empty;
            //    }
            //}
            //
            ////グループサプレス処理(商品中分類)
            //if (this.MdGoodsCode_TextBox.Text != null)
            //{
            //    if (this.MdGoodsCode_TextBox.Text.CompareTo(this._mediumGoodsBuff) == 0)
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = true;
            //        //バッファ更新
            //        this._mediumGoodsBuff = MdGoodsCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //例外的な場合
            //    //nullの場合は空文字と見なす
            //    if (this._mediumGoodsBuff == string.Empty)
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = true;
            //        //バッファを空文字で更新
            //        this._mediumGoodsBuff = string.Empty;
            //    }
            //}
            //
            // 2009.02.16 30413 犬飼 未使用なので削除 >>>>>>START
            ////グループサプレス処理(棚番)
            //if (this.WarehouseShelfNo_TextBox.Text != null)
            //{
            //    //比べるのは事業者コード(int)
            //    if (this.WarehouseShelfNo_TextBox.Text.CompareTo(this._warehouseShelfNoBuff) == 0)
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = true;
            //        //バッファ更新
            //        this._warehouseShelfNoBuff = this.WarehouseShelfNo_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //例外的な場合
            //    //nullの場合は空文字と見なす
            //    if (this._warehouseShelfNoBuff == string.Empty)
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = true;
            //        //バッファを空文字で更新
            //        this._warehouseShelfNoBuff = string.Empty;
            //    }
            //}
            // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
            // 2009.02.16 30413 犬飼 未使用なので削除 <<<<<<END

            // 2009.02.16 30413 犬飼 グループサプレス制御を追加 >>>>>>START
            // 出力順でグループサプレス処理
            if (this._extrInfo.SortDiv == 0)
            {
                // 倉庫→棚番
                this.SetSuppres(this.WarehouseShelfNo_TextBox);
            }
            else if (this._extrInfo.SortDiv == 1)
            {
                // 倉庫→仕入先
                this.SetSuppres(this.SupplierCd_TextBox);
            }
            else if (this._extrInfo.SortDiv == 2)
            {
                // 倉庫→ＢＬコード
                this.SetSuppres(this.BLGoodsCode_TextBox);
            }
            else if (this._extrInfo.SortDiv == 3)
            {
                // 倉庫→グループ
                this.SetSuppres(this.BLGroupCode_TextBox);
            }
            else if (this._extrInfo.SortDiv == 4)
            {
                // 倉庫→メーカー
                this.SetSuppres(this.MakerCode_TextBox);
            }
            else if (this._extrInfo.SortDiv == 5)
            {
                // 倉庫→仕入先→棚番
                this.SetSuppres(this.SupplierCd_TextBox);
            }
            else if (this._extrInfo.SortDiv == 6)
            {
                // 倉庫→仕入先→メーカー
                this.SetSuppres(this.SupplierCd_TextBox);
            }
            // 2009.02.16 30413 犬飼 グループサプレス制御を追加 <<<<<<END
        
            // 2008.10.31 30413 犬飼 未登録プロパティのため削除 >>>>>>START
            //if (this.MakerCode_TextBox.Text != null)
            //{
            //     //グループサプレス処理(メーカー)
            //    if(this.MakerCode_TextBox.Text.CompareTo(this._makerBuff) == 0)
            //    {
            //        this.Maker_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Maker_TextBox.Visible = true;
            //        //バッファ更新
            //        this._makerBuff = this.MakerCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //例外的な場合
            //    //nullの場合は空文字と見なす
            //    if(this._makerBuff == string.Empty)
            //    {
            //        this.Maker_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Maker_TextBox.Visible = true;
            //        //バッファを空文字で更新
            //        this._makerBuff = string.Empty;       
            //    }                                  
            //}
            // 2008.10.31 30413 犬飼 未登録プロパティのため削除 <<<<<<END
        }

        /// <summary>
        /// グループサプレス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレスのチェックと設定を行います。</br>
        /// <br>Programer : 30413 犬飼</br>
        /// <br>Date      : 2009.02.16</br>
        /// </remarks>    
        private void SetSuppres(TextBox textBox)
        {
            if (textBox.Text != null)
            {
                // バッファと比較
                //if (textBox.Text.CompareTo(this._groupSuppres) == 0)
                if (textBox.Text.CompareTo(this._groupSuppres) == 0
                    && (WarehouseCode_TextBox.Text.CompareTo(_groupSuppresWarehouseShelfNo)) == 0) // ADD 2009/12/17
                {
                    textBox.Visible = false;
                }
                else
                {
                    textBox.Visible = true;
                    //バッファ更新
                    this._groupSuppres = textBox.Text;
                    this._groupSuppresWarehouseShelfNo = WarehouseCode_TextBox.Text;// ADD 2009/12/17
                }
            }
            else
            {
                //例外的な場合
                //nullの場合は空文字と見なす
                if (this._groupSuppres == string.Empty)
                {
                    textBox.Visible = false;
                }
                else
                {
                    textBox.Visible = true;
                    //バッファを空文字で更新
                    this._groupSuppres = string.Empty;
                }
            }
        }
        #endregion

		#endregion

        #region Event

        #region Detail_BeforePrintイベント
        /// <summary>
		/// Detail_BeforePrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
            // 2009.02.16 30413 犬飼 グループサプレス処理を追加 >>>>>>START
            // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
            ////グループサプレス処理
            SetOfGroupSuppres();
            // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<
            // 2009.02.16 30413 犬飼 グループサプレス処理を追加 <<<<<<END
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

        }

        #endregion

        #region MAZAI02112P_01A4C_PageEndイベント
        /// <summary>
		/// MAZAI02112P_01A4C_PageEndイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : １ページの出力が終了したときに発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void MAZAI02112P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
		    //バッファクリア
			BufferClear();
        }

        #endregion

        #region ExtraHeader_Formatイベント
        /// <summary>
		/// ExtraHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
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
			

			if ( this._rptExtraHeader == null )
			{
				this._rptExtraHeader = new ListCommon_ExtraHeader();
			}
			else
			{
				this._rptExtraHeader.DataSource = null;
			}

            // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
            //// 拠点オプション有無判定
            //if (this._extrInfo.IsOptSection)
            //{
            //    
            //    this._rptExtraHeader.SectionCondition.Text = "棚卸拠点： " + this.StockSectionName.Text;
            //    
            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            //this._rptExtraHeader.SectionCondition.Text = "棚卸拠点： " + this.StockSectionName.Text;
            //this._rptExtraHeader.SectionCondition.Text = "棚卸拠点： " + this.StockSectionCode.Text + " " + this.StockSectionName.Text;
            // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;

			this.Header_SubReport.Report = this._rptExtraHeader;
        }

        #endregion

        #region PageFooter_Formatイベント
        /// <summary>
		/// PageFooter_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2009.03.18 30413 犬飼 フッター部の印字変更 >>>>>>START
            //// フッター出力する？
            //if (this._pageFooterOutCode == 0)
            //{
            //    // インスタンスが作成されていなければ作成
            //    if (this._rptPageFooter == null)
            //    {
            //        this._rptPageFooter = new ListCommon_PageFooter();
            //    }
            //    else
            //    {
            //        // インスタンスが作成されていれば、データソースを初期化する
            //        // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
            //        this._rptPageFooter.DataSource = null;
            //    }

            //    // フッター印字項目設定
            //    if (this._pageFooters[0] != null)
            //    {
            //        this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
            //    }
            //    if (this._pageFooters[1] != null)
            //    {
            //        this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
            //    }

            //    this.Footer_SubReport.Report = this._rptPageFooter;
            //}
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッター罫線印字設定
                Line_PageFooter.Visible = true;

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    PageFooters0.Visible = true;
                    PageFooters0.Text = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    PageFooters1.Visible = true;
                    PageFooters1.Value = this._pageFooters[1];
                }
            }
            else
            {
                // フッター罫線印字設定
                Line_PageFooter.Visible = false;

                PageFooters0.Visible = false;
                PageFooters1.Visible = false;
            }
            // 2009.03.18 30413 犬飼 フッター部の印字変更 <<<<<<END
        }

        #endregion

        #region MAZAI02112P_01A4C_ReportStartイベント
        /// <summary>
		/// MAZAI02112P_01A4C_ReportStartイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : MAZAI02112P_01A4C_ReportStartの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void MAZAI02112P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();

            // 印字パターン変更
            SetOutputPrintPattern();
        }

        #endregion

        #region PageHeader_Formatイベント
        /// <summary>
		/// PageHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付           
            //現在の時刻を取得
			DateTime now = DateTime.Now;
            //作成日(西暦で表示)
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);			
			// 作成時間
			this.PrintTime.Text   = now.ToString("HH:mm");
        }

        #endregion

        #region Detail_AfterPrintイベント
        /// <summary>
		/// 明細アフタープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 23010　中村　仁</br>
		/// <br>Date        : 2007.04.10</br>
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

        #region GoodsFooter_AfterPrintイベント
        /// <summary>
		/// GoodsFooter_AfterPrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : GoodsFooterセクションの印刷後に発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void GoodsFooter_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//バッファをクリア
			BufferClear();
		}
        #endregion

        // 2007.09.05 削除 >>>>>>>>>>>>>>>>>>>>
        //#region CellphoneModelFooter_AfterPrintイベント
        ///// <summary>
		///// CellphoneModelFooter_AfterPrintイベント
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="eArgs">イベントパラメータ</param>
		///// <remarks>
		///// <br>Note       : CellphoneModelFooter_AfterPrintセクションの印刷後に発生するイベントです。</br>
		///// <br>Programmer : 23010　中村　仁</br>
		///// <br>Date       : 2007.04.10</br>
		///// </remarks>
		//private void CellphoneModelFooter_AfterPrint(object sender, System.EventArgs eArgs)
		//{
		//	//バッファをクリア
		//	BufferClear();
		//}
        //#endregion
        // 2007.09.05 削除 <<<<<<<<<<<<<<<<<<<<

        #region MakerFooter_AfterPrintイベント
        /// <summary>
		/// MakerFooter_AfterPrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : MakerFooterセクションの印刷後に発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void MakerFooter_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//バッファをクリア
			BufferClear();
		}

        #endregion

        #region WarehouseFooter_AfterPrintイベント
        /// <summary>
		/// WarehouseFooter_AfterPrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : WarehouseFooterセクションの印刷後に発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.16</br>
        /// </remarks>
		private void WarehouseFooter_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//バッファをクリア
			BufferClear();
		}

        #endregion

        #endregion
        
		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox PRINTPAGE;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox SortTitle;
		private DataDynamics.ActiveReports.TextBox PrintTime;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Label GoodsNo_Title;
		private DataDynamics.ActiveReports.Line Line4;
        private DataDynamics.ActiveReports.Label StockUnitPrice_Title;
		private DataDynamics.ActiveReports.Label GoodsName_Title;
        private DataDynamics.ActiveReports.Label StockCount_Title;
		private DataDynamics.ActiveReports.Label WarehouseShelfNo_Title;
		private DataDynamics.ActiveReports.Label InventStockCount_Title;
		private DataDynamics.ActiveReports.Label InventorySeqNo_Title;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.TextBox StockSectionName;
		private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
		private DataDynamics.ActiveReports.GroupHeader MakerHeader;
		private DataDynamics.ActiveReports.GroupHeader GoodsHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox StockCount_TextBox;
        private DataDynamics.ActiveReports.Line Line37;
        private DataDynamics.ActiveReports.TextBox GoodsName_TextBox;
        private DataDynamics.ActiveReports.TextBox StockUnitPrice_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsNo_TextBox;
		private DataDynamics.ActiveReports.TextBox Warehouse_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseCode_TextBox;
		private DataDynamics.ActiveReports.GroupFooter GoodsFooter;
		private DataDynamics.ActiveReports.Line Line44;
		private DataDynamics.ActiveReports.TextBox GoodsTotal_Title;
		private DataDynamics.ActiveReports.TextBox GoosTotal_TextBox;
		private DataDynamics.ActiveReports.GroupFooter MakerFooter;
		private DataDynamics.ActiveReports.Line Line5;
		private DataDynamics.ActiveReports.TextBox MakerTotal_Title;
		private DataDynamics.ActiveReports.TextBox MakerTotal_TextBox;
		private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.TextBox WareStockCount_TextBox;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.TextBox WarehouseTotal_Title;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotal_Title;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox GrandStockCount_TextBox;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02112P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.StockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.GoodsName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockUnitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.InventStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MakerCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.InventorySeqNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.BlankShowFlag = new DataDynamics.ActiveReports.TextBox();
            this.InvStockCntFlag = new DataDynamics.ActiveReports.TextBox();
            this.Warehouse_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PRINTPAGE = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.SortTitle = new DataDynamics.ActiveReports.TextBox();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Line_PageFooter = new DataDynamics.ActiveReports.Line();
            this.PageFooters0 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooters1 = new DataDynamics.ActiveReports.TextBox();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.StockUnitPrice_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.StockCount_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.InventStockCount_Title = new DataDynamics.ActiveReports.Label();
            this.InventorySeqNo_Title = new DataDynamics.ActiveReports.Label();
            this.Maker_Title = new DataDynamics.ActiveReports.Label();
            this.SupplierCd_Title = new DataDynamics.ActiveReports.Label();
            this.BLGoodsCode_Title = new DataDynamics.ActiveReports.Label();
            this.BLGroupCode_Title = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotal_Title = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.GrandStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.GrandInventStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.StockSectionName = new DataDynamics.ActiveReports.TextBox();
            this.StockSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WareStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.WarehouseTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.WareInventStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.MakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.MakerTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.MakerTotal_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.GoodsTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.GoosTotal_TextBox = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlankShowFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvStockCntFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandInventStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareInventStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoosTotal_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StockCount_TextBox,
            this.Line37,
            this.GoodsName_TextBox,
            this.StockUnitPrice_TextBox,
            this.GoodsNo_TextBox,
            this.WarehouseShelfNo_TextBox,
            this.InventStockCount_TextBox,
            this.MakerCode_TextBox,
            this.SupplierCd_TextBox,
            this.BLGoodsCode_TextBox,
            this.BLGroupCode_TextBox,
            this.InventorySeqNo_TextBox,
            this.textBox1,
            this.textBox2,
            this.BlankShowFlag,
            this.InvStockCntFlag});
            this.Detail.Height = 0.4375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // StockCount_TextBox
            // 
            this.StockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.DataField = "StockTotal";
            this.StockCount_TextBox.Height = 0.125F;
            this.StockCount_TextBox.Left = 3.96875F;
            this.StockCount_TextBox.MultiLine = false;
            this.StockCount_TextBox.Name = "StockCount_TextBox";
            this.StockCount_TextBox.OutputFormat = resources.GetString("StockCount_TextBox.OutputFormat");
            this.StockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockCount_TextBox.Text = "123,456.99";
            this.StockCount_TextBox.Top = 0F;
            this.StockCount_TextBox.Width = 0.6F;
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
            this.Line37.Width = 7.677F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 7.677F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // GoodsName_TextBox
            // 
            this.GoodsName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.DataField = "GoodsName";
            this.GoodsName_TextBox.Height = 0.125F;
            this.GoodsName_TextBox.Left = 2.885417F;
            this.GoodsName_TextBox.MultiLine = false;
            this.GoodsName_TextBox.Name = "GoodsName_TextBox";
            this.GoodsName_TextBox.OutputFormat = resources.GetString("GoodsName_TextBox.OutputFormat");
            this.GoodsName_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName_TextBox.Text = "あいうえおかきくけこ";
            this.GoodsName_TextBox.Top = 0F;
            this.GoodsName_TextBox.Width = 1.14F;
            // 
            // StockUnitPrice_TextBox
            // 
            this.StockUnitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.DataField = "StockUnitPriceFl";
            this.StockUnitPrice_TextBox.Height = 0.125F;
            this.StockUnitPrice_TextBox.Left = 5.177083F;
            this.StockUnitPrice_TextBox.MultiLine = false;
            this.StockUnitPrice_TextBox.Name = "StockUnitPrice_TextBox";
            this.StockUnitPrice_TextBox.OutputFormat = resources.GetString("StockUnitPrice_TextBox.OutputFormat");
            this.StockUnitPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockUnitPrice_TextBox.Text = "1,234,567.00";
            this.StockUnitPrice_TextBox.Top = 0F;
            this.StockUnitPrice_TextBox.Width = 0.7F;
            // 
            // GoodsNo_TextBox
            // 
            this.GoodsNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.DataField = "GoodsNo";
            this.GoodsNo_TextBox.Height = 0.25F;
            this.GoodsNo_TextBox.Left = 0.625F;
            this.GoodsNo_TextBox.MultiLine = false;
            this.GoodsNo_TextBox.Name = "GoodsNo_TextBox";
            this.GoodsNo_TextBox.OutputFormat = resources.GetString("GoodsNo_TextBox.OutputFormat");
            this.GoodsNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 13pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNo_TextBox.Text = "1234567890123456789012345";
            this.GoodsNo_TextBox.Top = 0F;
            this.GoodsNo_TextBox.Width = 2.29F;
            // 
            // WarehouseShelfNo_TextBox
            // 
            this.WarehouseShelfNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo_TextBox.Height = 0.1875F;
            this.WarehouseShelfNo_TextBox.Left = 0F;
            this.WarehouseShelfNo_TextBox.MultiLine = false;
            this.WarehouseShelfNo_TextBox.Name = "WarehouseShelfNo_TextBox";
            this.WarehouseShelfNo_TextBox.OutputFormat = resources.GetString("WarehouseShelfNo_TextBox.OutputFormat");
            this.WarehouseShelfNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 10.8pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.WarehouseShelfNo_TextBox.Text = "XXXXXXXX";
            this.WarehouseShelfNo_TextBox.Top = 0F;
            this.WarehouseShelfNo_TextBox.Width = 0.628F;
            // 
            // InventStockCount_TextBox
            // 
            this.InventStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.DataField = "InventoryStockCnt";
            this.InventStockCount_TextBox.Height = 0.125F;
            this.InventStockCount_TextBox.Left = 4.5625F;
            this.InventStockCount_TextBox.MultiLine = false;
            this.InventStockCount_TextBox.Name = "InventStockCount_TextBox";
            this.InventStockCount_TextBox.OutputFormat = resources.GetString("InventStockCount_TextBox.OutputFormat");
            this.InventStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.InventStockCount_TextBox.Text = "123,456.99";
            this.InventStockCount_TextBox.Top = 0F;
            this.InventStockCount_TextBox.Width = 0.6F;
            // 
            // MakerCode_TextBox
            // 
            this.MakerCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.DataField = "MakerCode_Print";
            this.MakerCode_TextBox.Height = 0.125F;
            this.MakerCode_TextBox.Left = 6.93875F;
            this.MakerCode_TextBox.MultiLine = false;
            this.MakerCode_TextBox.Name = "MakerCode_TextBox";
            this.MakerCode_TextBox.OutputFormat = resources.GetString("MakerCode_TextBox.OutputFormat");
            this.MakerCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.MakerCode_TextBox.Text = "1234";
            this.MakerCode_TextBox.Top = 0F;
            this.MakerCode_TextBox.Width = 0.253F;
            // 
            // SupplierCd_TextBox
            // 
            this.SupplierCd_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.DataField = "SupplierCd_Print";
            this.SupplierCd_TextBox.Height = 0.125F;
            this.SupplierCd_TextBox.Left = 5.900833F;
            this.SupplierCd_TextBox.MultiLine = false;
            this.SupplierCd_TextBox.Name = "SupplierCd_TextBox";
            this.SupplierCd_TextBox.OutputFormat = resources.GetString("SupplierCd_TextBox.OutputFormat");
            this.SupplierCd_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SupplierCd_TextBox.Text = "123456";
            this.SupplierCd_TextBox.Top = 0F;
            this.SupplierCd_TextBox.Width = 0.363F;
            // 
            // BLGoodsCode_TextBox
            // 
            this.BLGoodsCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.DataField = "BLGoodsCode_Print";
            this.BLGoodsCode_TextBox.Height = 0.125F;
            this.BLGoodsCode_TextBox.Left = 6.28875F;
            this.BLGoodsCode_TextBox.MultiLine = false;
            this.BLGoodsCode_TextBox.Name = "BLGoodsCode_TextBox";
            this.BLGoodsCode_TextBox.OutputFormat = resources.GetString("BLGoodsCode_TextBox.OutputFormat");
            this.BLGoodsCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGoodsCode_TextBox.Text = "12345";
            this.BLGoodsCode_TextBox.Top = 0F;
            this.BLGoodsCode_TextBox.Width = 0.363F;
            // 
            // BLGroupCode_TextBox
            // 
            this.BLGroupCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.DataField = "BLGroupCode_Print";
            this.BLGroupCode_TextBox.Height = 0.125F;
            this.BLGroupCode_TextBox.Left = 6.61075F;
            this.BLGroupCode_TextBox.MultiLine = false;
            this.BLGroupCode_TextBox.Name = "BLGroupCode_TextBox";
            this.BLGroupCode_TextBox.OutputFormat = resources.GetString("BLGroupCode_TextBox.OutputFormat");
            this.BLGroupCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGroupCode_TextBox.Text = "12345";
            this.BLGroupCode_TextBox.Top = 0F;
            this.BLGroupCode_TextBox.Width = 0.363F;
            // 
            // InventorySeqNo_TextBox
            // 
            this.InventorySeqNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.DataField = "InventorySeqNo";
            this.InventorySeqNo_TextBox.Height = 0.125F;
            this.InventorySeqNo_TextBox.Left = 7.208333F;
            this.InventorySeqNo_TextBox.MultiLine = false;
            this.InventorySeqNo_TextBox.Name = "InventorySeqNo_TextBox";
            this.InventorySeqNo_TextBox.OutputFormat = resources.GetString("InventorySeqNo_TextBox.OutputFormat");
            this.InventorySeqNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.InventorySeqNo_TextBox.Text = "12345678";
            this.InventorySeqNo_TextBox.Top = 0F;
            this.InventorySeqNo_TextBox.Width = 0.48F;
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
            this.textBox1.Left = 4.53125F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox1.Text = "(";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.125F;
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
            this.textBox2.Height = 0.188F;
            this.textBox2.Left = 5.145833F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox2.Text = ")";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.125F;
            // 
            // BlankShowFlag
            // 
            this.BlankShowFlag.Border.BottomColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.Border.LeftColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.Border.RightColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.Border.TopColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.DataField = "BlankShowFlag_Print";
            this.BlankShowFlag.Height = 0.125F;
            this.BlankShowFlag.Left = 0.6875F;
            this.BlankShowFlag.MultiLine = false;
            this.BlankShowFlag.Name = "BlankShowFlag";
            this.BlankShowFlag.OutputFormat = resources.GetString("BlankShowFlag.OutputFormat");
            this.BlankShowFlag.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.BlankShowFlag.Text = "123,456.99";
            this.BlankShowFlag.Top = 0.3125F;
            this.BlankShowFlag.Visible = false;
            this.BlankShowFlag.Width = 0.6F;
            // 
            // InvStockCntFlag
            // 
            this.InvStockCntFlag.Border.BottomColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.Border.LeftColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.Border.RightColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.Border.TopColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.DataField = "InvStockCntFlag_Print";
            this.InvStockCntFlag.Height = 0.125F;
            this.InvStockCntFlag.Left = 3.25F;
            this.InvStockCntFlag.MultiLine = false;
            this.InvStockCntFlag.Name = "InvStockCntFlag";
            this.InvStockCntFlag.OutputFormat = resources.GetString("InvStockCntFlag.OutputFormat");
            this.InvStockCntFlag.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.InvStockCntFlag.Text = null;
            this.InvStockCntFlag.Top = 0.25F;
            this.InvStockCntFlag.Visible = false;
            this.InvStockCntFlag.Width = 0.25F;
            // 
            // Warehouse_TextBox
            // 
            this.Warehouse_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.DataField = "WarehouseName";
            this.Warehouse_TextBox.Height = 0.125F;
            this.Warehouse_TextBox.Left = 0.375F;
            this.Warehouse_TextBox.MultiLine = false;
            this.Warehouse_TextBox.Name = "Warehouse_TextBox";
            this.Warehouse_TextBox.OutputFormat = resources.GetString("Warehouse_TextBox.OutputFormat");
            this.Warehouse_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Warehouse_TextBox.Text = "倉庫名称";
            this.Warehouse_TextBox.Top = 0F;
            this.Warehouse_TextBox.Width = 1.1875F;
            // 
            // WarehouseCode_TextBox
            // 
            this.WarehouseCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.DataField = "WarehouseCode_Print";
            this.WarehouseCode_TextBox.Height = 0.125F;
            this.WarehouseCode_TextBox.Left = 0F;
            this.WarehouseCode_TextBox.MultiLine = false;
            this.WarehouseCode_TextBox.Name = "WarehouseCode_TextBox";
            this.WarehouseCode_TextBox.OutputFormat = resources.GetString("WarehouseCode_TextBox.OutputFormat");
            this.WarehouseCode_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.WarehouseCode_TextBox.Text = "5000";
            this.WarehouseCode_TextBox.Top = 0F;
            this.WarehouseCode_TextBox.Width = 0.3125F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.Label3,
            this.PrintDate,
            this.Label2,
            this.PRINTPAGE,
            this.Line1,
            this.SortTitle,
            this.PrintTime});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.21875F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 0.21875F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.Label1.Text = "棚卸調査表";
            this.Label1.Top = 0.01041667F;
            this.Label1.Width = 2.09375F;
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
            this.Label3.Left = 4.854167F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.08333334F;
            this.Label3.Width = 0.625F;
            // 
            // PrintDate
            // 
            this.PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.CanShrink = true;
            this.PrintDate.Height = 0.1875F;
            this.PrintDate.Left = 5.479167F;
            this.PrintDate.MultiLine = false;
            this.PrintDate.Name = "PrintDate";
            this.PrintDate.OutputFormat = resources.GetString("PrintDate.OutputFormat");
            this.PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintDate.Text = "平成17年11月 5日";
            this.PrintDate.Top = 0.08333334F;
            this.PrintDate.Width = 0.9375F;
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
            this.Label2.Left = 6.854167F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.08333334F;
            this.Label2.Width = 0.5F;
            // 
            // PRINTPAGE
            // 
            this.PRINTPAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.CanShrink = true;
            this.PRINTPAGE.Height = 0.1875F;
            this.PRINTPAGE.Left = 7.354167F;
            this.PRINTPAGE.MultiLine = false;
            this.PRINTPAGE.Name = "PRINTPAGE";
            this.PRINTPAGE.OutputFormat = resources.GetString("PRINTPAGE.OutputFormat");
            this.PRINTPAGE.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PRINTPAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PRINTPAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PRINTPAGE.Text = "123";
            this.PRINTPAGE.Top = 0.08333334F;
            this.PRINTPAGE.Width = 0.3125F;
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
            this.Line1.Width = 7.677F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 7.677F;
            this.Line1.Y1 = 0.2085F;
            this.Line1.Y2 = 0.2085F;
            // 
            // SortTitle
            // 
            this.SortTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SortTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SortTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SortTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SortTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.CanShrink = true;
            this.SortTitle.Height = 0.125F;
            this.SortTitle.Left = 2.125F;
            this.SortTitle.MultiLine = false;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.SortTitle.Text = "[ソート条件]";
            this.SortTitle.Top = 0.08333334F;
            this.SortTitle.Width = 2.25F;
            // 
            // PrintTime
            // 
            this.PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Height = 0.125F;
            this.PrintTime.Left = 6.354167F;
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.PrintTime.Text = "11時20分";
            this.PrintTime.Top = 0.08333334F;
            this.PrintTime.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line_PageFooter,
            this.PageFooters0,
            this.PageFooters1});
            this.PageFooter.Height = 0.3020833F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Line_PageFooter
            // 
            this.Line_PageFooter.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.RightColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.TopColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Height = 0F;
            this.Line_PageFooter.Left = 0F;
            this.Line_PageFooter.LineWeight = 2F;
            this.Line_PageFooter.Name = "Line_PageFooter";
            this.Line_PageFooter.Top = 0F;
            this.Line_PageFooter.Width = 7.677F;
            this.Line_PageFooter.X1 = 0F;
            this.Line_PageFooter.X2 = 7.677F;
            this.Line_PageFooter.Y1 = 0F;
            this.Line_PageFooter.Y2 = 0F;
            // 
            // PageFooters0
            // 
            this.PageFooters0.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Height = 0.125F;
            this.PageFooters0.Left = 0F;
            this.PageFooters0.MultiLine = false;
            this.PageFooters0.Name = "PageFooters0";
            this.PageFooters0.OutputFormat = resources.GetString("PageFooters0.OutputFormat");
            this.PageFooters0.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.PageFooters0.Text = null;
            this.PageFooters0.Top = 0F;
            this.PageFooters0.Width = 3F;
            // 
            // PageFooters1
            // 
            this.PageFooters1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Height = 0.125F;
            this.PageFooters1.Left = 4.5F;
            this.PageFooters1.MultiLine = false;
            this.PageFooters1.Name = "PageFooters1";
            this.PageFooters1.OutputFormat = resources.GetString("PageFooters1.OutputFormat");
            this.PageFooters1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PageFooters1.Text = null;
            this.PageFooters1.Top = 0F;
            this.PageFooters1.Width = 3F;
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
            this.Header_SubReport.Width = 7.625F;
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
            this.GoodsNo_Title,
            this.Line4,
            this.StockUnitPrice_Title,
            this.GoodsName_Title,
            this.StockCount_Title,
            this.WarehouseShelfNo_Title,
            this.InventStockCount_Title,
            this.InventorySeqNo_Title,
            this.Maker_Title,
            this.SupplierCd_Title,
            this.BLGoodsCode_Title,
            this.BLGroupCode_Title,
            this.line6});
            this.TitleHeader.Height = 0.28125F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // GoodsNo_Title
            // 
            this.GoodsNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Height = 0.1875F;
            this.GoodsNo_Title.HyperLink = "";
            this.GoodsNo_Title.Left = 0.625F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsNo_Title.Text = "品番";
            this.GoodsNo_Title.Top = 0F;
            this.GoodsNo_Title.Width = 2.29F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0F;
            this.Line4.Left = 0F;
            this.Line4.LineWeight = 2F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 7.677F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 7.677F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0F;
            // 
            // StockUnitPrice_Title
            // 
            this.StockUnitPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Height = 0.1875F;
            this.StockUnitPrice_Title.HyperLink = "";
            this.StockUnitPrice_Title.Left = 5.177F;
            this.StockUnitPrice_Title.MultiLine = false;
            this.StockUnitPrice_Title.Name = "StockUnitPrice_Title";
            this.StockUnitPrice_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.StockUnitPrice_Title.Text = "原単価";
            this.StockUnitPrice_Title.Top = 0F;
            this.StockUnitPrice_Title.Width = 0.7F;
            // 
            // GoodsName_Title
            // 
            this.GoodsName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Height = 0.1875F;
            this.GoodsName_Title.HyperLink = "";
            this.GoodsName_Title.Left = 2.885F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsName_Title.Text = "品名";
            this.GoodsName_Title.Top = 0F;
            this.GoodsName_Title.Width = 1.14F;
            // 
            // StockCount_Title
            // 
            this.StockCount_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Height = 0.1875F;
            this.StockCount_Title.HyperLink = "";
            this.StockCount_Title.Left = 3.969F;
            this.StockCount_Title.MultiLine = false;
            this.StockCount_Title.Name = "StockCount_Title";
            this.StockCount_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.StockCount_Title.Text = "帳簿数";
            this.StockCount_Title.Top = 0F;
            this.StockCount_Title.Width = 0.6F;
            // 
            // WarehouseShelfNo_Title
            // 
            this.WarehouseShelfNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Height = 0.1875F;
            this.WarehouseShelfNo_Title.HyperLink = "";
            this.WarehouseShelfNo_Title.Left = 0F;
            this.WarehouseShelfNo_Title.MultiLine = false;
            this.WarehouseShelfNo_Title.Name = "WarehouseShelfNo_Title";
            this.WarehouseShelfNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.WarehouseShelfNo_Title.Text = "棚番";
            this.WarehouseShelfNo_Title.Top = 0F;
            this.WarehouseShelfNo_Title.Width = 0.628F;
            // 
            // InventStockCount_Title
            // 
            this.InventStockCount_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Border.RightColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Border.TopColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Height = 0.1875F;
            this.InventStockCount_Title.HyperLink = "";
            this.InventStockCount_Title.Left = 4.563F;
            this.InventStockCount_Title.MultiLine = false;
            this.InventStockCount_Title.Name = "InventStockCount_Title";
            this.InventStockCount_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.InventStockCount_Title.Text = "棚卸数　";
            this.InventStockCount_Title.Top = 0F;
            this.InventStockCount_Title.Width = 0.6F;
            // 
            // InventorySeqNo_Title
            // 
            this.InventorySeqNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Height = 0.1875F;
            this.InventorySeqNo_Title.HyperLink = "";
            this.InventorySeqNo_Title.Left = 7.208F;
            this.InventorySeqNo_Title.MultiLine = false;
            this.InventorySeqNo_Title.Name = "InventorySeqNo_Title";
            this.InventorySeqNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.InventorySeqNo_Title.Text = "棚卸連番";
            this.InventorySeqNo_Title.Top = 0F;
            this.InventorySeqNo_Title.Width = 0.48F;
            // 
            // Maker_Title
            // 
            this.Maker_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Height = 0.1875F;
            this.Maker_Title.HyperLink = "";
            this.Maker_Title.Left = 6.939F;
            this.Maker_Title.MultiLine = false;
            this.Maker_Title.Name = "Maker_Title";
            this.Maker_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Maker_Title.Text = "ﾒｰｶｰ";
            this.Maker_Title.Top = 0F;
            this.Maker_Title.Width = 0.253F;
            // 
            // SupplierCd_Title
            // 
            this.SupplierCd_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Height = 0.1875F;
            this.SupplierCd_Title.HyperLink = "";
            this.SupplierCd_Title.Left = 5.901F;
            this.SupplierCd_Title.MultiLine = false;
            this.SupplierCd_Title.Name = "SupplierCd_Title";
            this.SupplierCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.SupplierCd_Title.Text = "仕入先";
            this.SupplierCd_Title.Top = 0F;
            this.SupplierCd_Title.Width = 0.363F;
            // 
            // BLGoodsCode_Title
            // 
            this.BLGoodsCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Height = 0.1875F;
            this.BLGoodsCode_Title.HyperLink = "";
            this.BLGoodsCode_Title.Left = 6.289F;
            this.BLGoodsCode_Title.MultiLine = false;
            this.BLGoodsCode_Title.Name = "BLGoodsCode_Title";
            this.BLGoodsCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.BLGoodsCode_Title.Text = "BLｺｰﾄﾞ";
            this.BLGoodsCode_Title.Top = 0F;
            this.BLGoodsCode_Title.Width = 0.363F;
            // 
            // BLGroupCode_Title
            // 
            this.BLGroupCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Height = 0.1875F;
            this.BLGroupCode_Title.HyperLink = "";
            this.BLGroupCode_Title.Left = 6.611F;
            this.BLGroupCode_Title.MultiLine = false;
            this.BLGroupCode_Title.Name = "BLGroupCode_Title";
            this.BLGroupCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.BLGroupCode_Title.Text = "ｸﾞﾙｰﾌﾟ";
            this.BLGroupCode_Title.Top = 0F;
            this.BLGroupCode_Title.Width = 0.363F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0.1875F;
            this.line6.Width = 7.677F;
            this.line6.X1 = 0F;
            this.line6.X2 = 7.677F;
            this.line6.Y1 = 0.1875F;
            this.line6.Y2 = 0.1875F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
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
            this.Line41.Width = 7.677F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 7.677F;
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
            this.GrandTotal_Title,
            this.Line,
            this.GrandStockCount_TextBox,
            this.textBox4,
            this.GrandInventStockCount_TextBox,
            this.textBox8});
            this.GrandTotalFooter.Height = 0.21875F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Visible = false;
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // GrandTotal_Title
            // 
            this.GrandTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Height = 0.1875F;
            this.GrandTotal_Title.HyperLink = "";
            this.GrandTotal_Title.Left = 2.885F;
            this.GrandTotal_Title.MultiLine = false;
            this.GrandTotal_Title.Name = "GrandTotal_Title";
            this.GrandTotal_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotal_Title.Text = "総合計";
            this.GrandTotal_Title.Top = 0F;
            this.GrandTotal_Title.Width = 0.5625F;
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
            this.Line.Width = 7.677F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.677F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // GrandStockCount_TextBox
            // 
            this.GrandStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.DataField = "StockTotal";
            this.GrandStockCount_TextBox.Height = 0.125F;
            this.GrandStockCount_TextBox.Left = 3.969F;
            this.GrandStockCount_TextBox.MultiLine = false;
            this.GrandStockCount_TextBox.Name = "GrandStockCount_TextBox";
            this.GrandStockCount_TextBox.OutputFormat = resources.GetString("GrandStockCount_TextBox.OutputFormat");
            this.GrandStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandStockCount_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandStockCount_TextBox.Text = "123,456.99";
            this.GrandStockCount_TextBox.Top = 0F;
            this.GrandStockCount_TextBox.Width = 0.6F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 4.53125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox4.Text = "(";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.125F;
            // 
            // GrandInventStockCount_TextBox
            // 
            this.GrandInventStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.DataField = "InventoryStockCnt";
            this.GrandInventStockCount_TextBox.Height = 0.125F;
            this.GrandInventStockCount_TextBox.Left = 4.563F;
            this.GrandInventStockCount_TextBox.MultiLine = false;
            this.GrandInventStockCount_TextBox.Name = "GrandInventStockCount_TextBox";
            this.GrandInventStockCount_TextBox.OutputFormat = resources.GetString("GrandInventStockCount_TextBox.OutputFormat");
            this.GrandInventStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandInventStockCount_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandInventStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandInventStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandInventStockCount_TextBox.Text = "123,456.99";
            this.GrandInventStockCount_TextBox.Top = 0F;
            this.GrandInventStockCount_TextBox.Width = 0.6F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 5.146F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox8.Text = ")";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.125F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StockSectionName,
            this.StockSectionCode});
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.Visible = false;
            // 
            // StockSectionName
            // 
            this.StockSectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.Border.RightColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.Border.TopColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.CanShrink = true;
            this.StockSectionName.DataField = "SectionGuideNm";
            this.StockSectionName.Height = 0.15F;
            this.StockSectionName.Left = 0.1F;
            this.StockSectionName.MultiLine = false;
            this.StockSectionName.Name = "StockSectionName";
            this.StockSectionName.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.StockSectionName.Text = null;
            this.StockSectionName.Top = 0.05F;
            this.StockSectionName.Visible = false;
            this.StockSectionName.Width = 0.75F;
            // 
            // StockSectionCode
            // 
            this.StockSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.CanShrink = true;
            this.StockSectionCode.DataField = "SectionCode";
            this.StockSectionCode.Height = 0.15F;
            this.StockSectionCode.Left = 0.9375F;
            this.StockSectionCode.MultiLine = false;
            this.StockSectionCode.Name = "StockSectionCode";
            this.StockSectionCode.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.StockSectionCode.Text = null;
            this.StockSectionCode.Top = 0.0625F;
            this.StockSectionCode.Visible = false;
            this.StockSectionCode.Width = 0.75F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Height = 0F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Visible = false;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Warehouse_TextBox,
            this.WarehouseCode_TextBox,
            this.line3});
            this.WarehouseHeader.DataField = "WarehouseCode";
            this.WarehouseHeader.Height = 0.1979167F;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
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
            this.line3.Width = 7.677F;
            this.line3.X1 = 0F;
            this.line3.X2 = 7.677F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WareStockCount_TextBox,
            this.Line2,
            this.WarehouseTotal_Title,
            this.WareInventStockCount_TextBox,
            this.textBox5,
            this.textBox6});
            this.WarehouseFooter.Height = 0.219F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.Visible = false;
            this.WarehouseFooter.AfterPrint += new System.EventHandler(this.WarehouseFooter_AfterPrint);
            this.WarehouseFooter.BeforePrint += new System.EventHandler(this.WarehouseFooter_BeforePrint);
            // 
            // WareStockCount_TextBox
            // 
            this.WareStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.DataField = "StockTotal";
            this.WareStockCount_TextBox.Height = 0.125F;
            this.WareStockCount_TextBox.Left = 3.969F;
            this.WareStockCount_TextBox.MultiLine = false;
            this.WareStockCount_TextBox.Name = "WareStockCount_TextBox";
            this.WareStockCount_TextBox.OutputFormat = resources.GetString("WareStockCount_TextBox.OutputFormat");
            this.WareStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WareStockCount_TextBox.SummaryGroup = "WarehouseHeader";
            this.WareStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WareStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WareStockCount_TextBox.Text = "123,456.99";
            this.WareStockCount_TextBox.Top = 0F;
            this.WareStockCount_TextBox.Width = 0.6F;
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
            this.Line2.Width = 7.677F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 7.677F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0F;
            // 
            // WarehouseTotal_Title
            // 
            this.WarehouseTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Height = 0.1875F;
            this.WarehouseTotal_Title.Left = 2.875F;
            this.WarehouseTotal_Title.MultiLine = false;
            this.WarehouseTotal_Title.Name = "WarehouseTotal_Title";
            this.WarehouseTotal_Title.OutputFormat = resources.GetString("WarehouseTotal_Title.OutputFormat");
            this.WarehouseTotal_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseTotal_Title.Text = "倉庫計";
            this.WarehouseTotal_Title.Top = 0F;
            this.WarehouseTotal_Title.Width = 0.563F;
            // 
            // WareInventStockCount_TextBox
            // 
            this.WareInventStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.DataField = "InventoryStockCnt";
            this.WareInventStockCount_TextBox.Height = 0.125F;
            this.WareInventStockCount_TextBox.Left = 4.563F;
            this.WareInventStockCount_TextBox.MultiLine = false;
            this.WareInventStockCount_TextBox.Name = "WareInventStockCount_TextBox";
            this.WareInventStockCount_TextBox.OutputFormat = resources.GetString("WareInventStockCount_TextBox.OutputFormat");
            this.WareInventStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WareInventStockCount_TextBox.SummaryGroup = "WarehouseHeader";
            this.WareInventStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WareInventStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WareInventStockCount_TextBox.Text = "123,456.99";
            this.WareInventStockCount_TextBox.Top = 0F;
            this.WareInventStockCount_TextBox.Width = 0.6F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 4.53125F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox5.Text = "(";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.125F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 5.146F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox6.Text = ")";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.125F;
            // 
            // MakerHeader
            // 
            this.MakerHeader.CanShrink = true;
            this.MakerHeader.Height = 0F;
            this.MakerHeader.Name = "MakerHeader";
            this.MakerHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.MakerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // MakerFooter
            // 
            this.MakerFooter.CanShrink = true;
            this.MakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line5,
            this.MakerTotal_Title,
            this.MakerTotal_TextBox});
            this.MakerFooter.Height = 0F;
            this.MakerFooter.KeepTogether = true;
            this.MakerFooter.Name = "MakerFooter";
            this.MakerFooter.Visible = false;
            this.MakerFooter.AfterPrint += new System.EventHandler(this.MakerFooter_AfterPrint);
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
            this.Line5.Width = 7.677F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 7.677F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // MakerTotal_Title
            // 
            this.MakerTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Height = 0.15625F;
            this.MakerTotal_Title.Left = 5.5F;
            this.MakerTotal_Title.MultiLine = false;
            this.MakerTotal_Title.Name = "MakerTotal_Title";
            this.MakerTotal_Title.OutputFormat = resources.GetString("MakerTotal_Title.OutputFormat");
            this.MakerTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 10.8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.MakerTotal_Title.Text = "メーカー計";
            this.MakerTotal_Title.Top = 0F;
            this.MakerTotal_Title.Width = 0.9999993F;
            // 
            // MakerTotal_TextBox
            // 
            this.MakerTotal_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.DataField = "StockCnt";
            this.MakerTotal_TextBox.Height = 0.125F;
            this.MakerTotal_TextBox.Left = 6.375F;
            this.MakerTotal_TextBox.MultiLine = false;
            this.MakerTotal_TextBox.Name = "MakerTotal_TextBox";
            this.MakerTotal_TextBox.OutputFormat = resources.GetString("MakerTotal_TextBox.OutputFormat");
            this.MakerTotal_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakerTotal_TextBox.SummaryGroup = "MakerHeader";
            this.MakerTotal_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakerTotal_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakerTotal_TextBox.Text = "12345678";
            this.MakerTotal_TextBox.Top = 0F;
            this.MakerTotal_TextBox.Width = 0.8125F;
            // 
            // GoodsHeader
            // 
            this.GoodsHeader.CanShrink = true;
            this.GoodsHeader.Height = 0F;
            this.GoodsHeader.Name = "GoodsHeader";
            this.GoodsHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.GoodsHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // GoodsFooter
            // 
            this.GoodsFooter.CanShrink = true;
            this.GoodsFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.GoodsTotal_Title,
            this.GoosTotal_TextBox});
            this.GoodsFooter.Height = 0F;
            this.GoodsFooter.KeepTogether = true;
            this.GoodsFooter.Name = "GoodsFooter";
            this.GoodsFooter.Visible = false;
            this.GoodsFooter.AfterPrint += new System.EventHandler(this.GoodsFooter_AfterPrint);
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
            this.Line44.Width = 7.677F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 7.677F;
            this.Line44.Y1 = 0F;
            this.Line44.Y2 = 0F;
            // 
            // GoodsTotal_Title
            // 
            this.GoodsTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Height = 0.15625F;
            this.GoodsTotal_Title.Left = 5.75F;
            this.GoodsTotal_Title.MultiLine = false;
            this.GoodsTotal_Title.Name = "GoodsTotal_Title";
            this.GoodsTotal_Title.OutputFormat = resources.GetString("GoodsTotal_Title.OutputFormat");
            this.GoodsTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 10.8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsTotal_Title.Text = "商品計";
            this.GoodsTotal_Title.Top = 0F;
            this.GoodsTotal_Title.Width = 0.5625F;
            // 
            // GoosTotal_TextBox
            // 
            this.GoosTotal_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.DataField = "StockCnt";
            this.GoosTotal_TextBox.Height = 0.125F;
            this.GoosTotal_TextBox.Left = 6.4375F;
            this.GoosTotal_TextBox.MultiLine = false;
            this.GoosTotal_TextBox.Name = "GoosTotal_TextBox";
            this.GoosTotal_TextBox.OutputFormat = resources.GetString("GoosTotal_TextBox.OutputFormat");
            this.GoosTotal_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GoosTotal_TextBox.SummaryGroup = "GoodsHeader";
            this.GoosTotal_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GoosTotal_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GoosTotal_TextBox.Text = "12,345,678.90";
            this.GoosTotal_TextBox.Top = 0F;
            this.GoosTotal_TextBox.Width = 0.8125F;
            // 
            // MAZAI02112P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 7.677083F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.MakerHeader);
            this.Sections.Add(this.GoodsHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GoodsFooter);
            this.Sections.Add(this.MakerFooter);
            this.Sections.Add(this.WarehouseFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02112P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02112P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlankShowFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvStockCntFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandInventStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareInventStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoosTotal_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion   

         /// <summary>
         /// 明細アフタープリントイベント
         /// </summary>
         /// <param name="sender">イベントソース</param>
         /// <param name="eArgs">イベントデータ</param>
         /// <remarks>
         /// <br>Note        : セクションがページに描画された後に発生します。</br>
         /// <br>Programmer  : 張凱</br>
         /// <br>Date        : 2009.12.07</br>
         /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // 重複棚番1,重複棚番2場合、棚卸数、原単価、帳薄数は空白です
            if (1 == (int)this.BlankShowFlag.Value)
            {
                this.StockCount_TextBox.Text = string.Empty;
                this.InventStockCount_TextBox.Text = string.Empty;
                this.StockUnitPrice_TextBox.Text = string.Empty;
                this.InventorySeqNo_TextBox.Text = string.Empty;
                this.textBox1.Text = string.Empty;
                this.textBox2.Text = string.Empty;
                this.GoodsNo_TextBox.Text = string.Empty;
            }
            else
            {
                this.textBox1.Text = "(";
                this.textBox2.Text = ")";
            }
            // ----------UPD 2010/02/20---------->>>>>
            //if (0.0 == (double)this.InventStockCount_TextBox.Value)
            //{
            //    this.InventStockCount_TextBox.Text = string.Empty;
            //}
            //棚卸実施日(InventoryDayRF)＝NULLの場合、棚卸数を印刷しない（空白）
            if (1 == (int)this.InvStockCntFlag.Value)
            {
                this.InventStockCount_TextBox.Text = string.Empty;
            }
            // ----------UPD 2010/02/20----------<<<<<
        }

        /// <summary>
        /// WarehouseFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2010/02/20</br>                                       
        /// </remarks>
        private void WarehouseFooter_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.WarehouseFooter);

        }

        /// <summary>
        /// GrandTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2010/02/20</br>                                       
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.GrandTotalFooter);

        }
    }
}
