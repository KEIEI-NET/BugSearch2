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
	/// 棚卸差異表印刷(簡易)フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 棚卸差異表のフォームクラスです。</br>
	/// <br>Programmer	: 23010　中村　仁</br>
	/// <br>Date		: 2007.04.11</br>
    /// <br>Update Note : 2007.09.05 980035 金沢 貞義</br>
    /// <br>			  ・DC.NS対応</br>
    /// <br>Update Note : 2008.02.13 980035 金沢 貞義</br>
    /// <br>			  ・棚卸実施日対応（DC.NS対応）</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : PM.NS対応</br>
    /// <br>Programmer  : 30413 犬飼</br>
    /// <br>Date	    : 2008.10.14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : MANTIS対応(13918)</br>
    /// <br>Programmer  : 22008 長内</br>
    /// <br>Date	    : 2009/09/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : 2013/01/16配信分、Redmine#33271 印字制御の区分の追加</br>
    /// <br>Programmer  : 李亜博</br>
    /// <br>Date	    : 2012/11/14</br>
    /// </remarks>
	public class MAZAI02112P_03A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region Constructor
        /// <summary>
		/// 棚卸差異表(簡易)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 棚卸差異表(簡易)フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 23010　中村　仁</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		public MAZAI02112P_03A4C()
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
        private string _warehouseBuff = "";
        // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
        ////サプレス用バッファ(事業者)
        //private string _CarrierEpBuff = "";
        ////サプレス用バッファ(商品大分類)
        //private string _largeGoodsBuff = "";
        ////サプレス用バッファ(商品中分類)
        //private string _mediumGoodsBuff = "";
        //サプレス用バッファ(棚番)
        private string _warehouseShelfNoBuff = "";
        // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
        //サプレス用バッファ(メーカー)
        private string _makerBuff = "";
        private TextBox StockSectionCode;
        private Label StockTotalExec_Title;
        private Label label6;
        private TextBox StockTotalExec_TextBox;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox SupplierCd_TextBox;
        private TextBox BLGoodsCode_TextBox;
        private TextBox BLGroupCode_TextBox;
        private Label SupplierCd_Title;
        private Label BLGoodsCode_Title;
        private Label BLGroupCode_Title;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox g_PlusInventoryTolerancCnt_TextBox;
        private TextBox g_MinusInventoryTolerancCnt_TextBox;
        private TextBox g_CalcInventoryTolerancCnt_TextBox;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox g_PlusInventoryTlrncPrice_TextBox;
        private TextBox g_MinusInventoryTlrncPrice_TextBox;
        private TextBox g_CalcInventoryTlrncPrice_TextBox;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox w_MinusInventoryTolerancCnt_TextBox;
        private TextBox w_PlusInventoryTolerancCnt_TextBox;
        private TextBox w_CalcInventoryTolerancCnt_TextBox;
        private Label label16;
        private Label label17;
        private Label label18;
        private TextBox w_PlusInventoryTlrncPrice_TextBox;
        private TextBox w_MinusInventoryTlrncPrice_TextBox;
        private TextBox w_CalcInventoryTlrncPrice_TextBox;
        private Label label19;
        private Label label20;
        private Label label21;
        private TextBox o_MinusInventoryTolerancCnt_TextBox;
        private TextBox o_PlusInventoryTolerancCnt_TextBox;
        private TextBox o_CalcInventoryTolerancCnt_TextBox;
        private Label label22;
        private Label label23;
        private Label label24;
        private TextBox o_PlusInventoryTlrncPrice_TextBox;
        private TextBox o_MinusInventoryTlrncPrice_TextBox;
        private TextBox o_CalcInventoryTlrncPrice_TextBox;
        private Line line3;
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
		/// <br>Date       : 2007.04.11</br>
        /// <br>Update Note: 2012/11/14 李亜博</br>
        ///	<br>			 Redmine#33271 印字制御の区分の追加</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{		    
            // 項目の名称をセット
			SortTitle.Text	= this._pageHeaderSortOderTitle;	// ソート条件    

            // 2008.11.27 30413 犬飼 出力順制御を修正 >>>>>>START
            // 2008.11.04 30413 犬飼 改頁制御を修正 >>>>>>START
            // 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
            // 改ページ指定区分
            if (this._extrInfo.TurnOoverThePagesDiv == 2)
            {
                // 改ページなし
                //this.WarehouseHeader.DataField = "";
                this.WarehouseHeader.NewPage = NewPage.None;
                this.SubTotalHeader.NewPage = NewPage.None;
            }
            //else if (this._extrInfo.TurnOoverThePagesDiv == 1)
            else
            {
                if (this._extrInfo.TurnOoverThePagesDiv == 1)
                {
                    // 小計
                    this.SubTotalHeader.NewPage = NewPage.Before;
                }
                else
                {
                    // 倉庫
                    this.SubTotalHeader.NewPage = NewPage.None;
                }

                //// 出力順
                //if (this._extrInfo.SortDiv == 0)
                //{
                //    // 倉庫→棚番
                //    this.SubTotalHeader.DataField = "WarehouseShelfNo_Print";
                //    this.SubTotal_Title.Text = "棚番計";
                //}
                //else if (this._extrInfo.SortDiv == 1)
                //{
                //    // 倉庫→仕入先
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    this.SubTotalHeader.DataField = "SupplierCd";
                //    this.SubTotal_Title.Text = "仕入先計";
                //}
                //else if (this._extrInfo.SortDiv == 2)
                //{
                //    // 倉庫→ＢＬコード
                //    this.SubTotalHeader.DataField = "BLGoodsCode";
                //    this.SubTotal_Title.Text = "BLｺｰﾄﾞ計";
                //}
                //else if (this._extrInfo.SortDiv == 3)
                //{
                //    //// 倉庫→メーカー
                //    //this.MakerHeader.DataField = "MakerCode";
                //    //this.MakerTotal_Title.Text = "ﾒｰｶｰ計";
                //    // 倉庫→グループ
                //    this.SubTotalHeader.DataField = "BLGroupCode";
                //    this.SubTotal_Title.Text = "ｸﾞﾙｰﾌﾟ計";
                //}
                //else if (this._extrInfo.SortDiv == 4)
                //{
                //    //// 倉庫→仕入先→棚番
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    //this.GoodsHeader.DataField = "WarehouseShelfNo_Print";
                //    // 倉庫→メーカー
                //    this.SubTotalHeader.DataField = "GoodsMakerCd";
                //    this.SubTotal_Title.Text = "ﾒｰｶｰ計";
                //}
                //else if (this._extrInfo.SortDiv == 5)
                //{
                //    //// 倉庫→仕入先→メーカー
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    //this.GoodsHeader.DataField = "MakerCode";
                //    // 倉庫→仕入先
                //    this.SubTotalHeader.DataField = "SupplierCd";
                //    this.SubTotal_Title.Text = "仕入先計";
                //}
                //else if (this._extrInfo.SortDiv == 6)
                //{
                //    //// 倉庫→仕入先→メーカー
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    //this.GoodsHeader.DataField = "MakerCode";
                //    // 倉庫→仕入先
                //    this.SubTotalHeader.DataField = "SupplierCd";
                //    this.SubTotal_Title.Text = "仕入先計";
                //}
            }
            // 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.11.04 30413 犬飼 改頁制御を修正 <<<<<<END

            // 出力順
            if (this._extrInfo.SortDiv == 0)
            {
                // 倉庫→棚番
                this.SubTotalHeader.DataField = "WarehouseShelfNo_Print";
                this.SubTotal_Title.Text = "棚番計";
            }
            else if (this._extrInfo.SortDiv == 1)
            {
                // 倉庫→仕入先
                this.SubTotalHeader.DataField = "SupplierCd";
                this.SubTotal_Title.Text = "仕入先計";
            }
            else if (this._extrInfo.SortDiv == 2)
            {
                // 倉庫→ＢＬコード
                this.SubTotalHeader.DataField = "BLGoodsCode";
                this.SubTotal_Title.Text = "BLｺｰﾄﾞ計";
            }
            else if (this._extrInfo.SortDiv == 3)
            {
                // 倉庫→グループ
                this.SubTotalHeader.DataField = "BLGroupCode";
                this.SubTotal_Title.Text = "ｸﾞﾙｰﾌﾟ計";
            }
            else if (this._extrInfo.SortDiv == 4)
            {
                // 倉庫→メーカー
                this.SubTotalHeader.DataField = "GoodsMakerCd";
                this.SubTotal_Title.Text = "ﾒｰｶｰ計";
            }
            else if (this._extrInfo.SortDiv == 5)
            {
                // 倉庫→仕入先
                this.SubTotalHeader.DataField = "SupplierCd";
                this.SubTotal_Title.Text = "仕入先計";
            }
            else if (this._extrInfo.SortDiv == 6)
            {
                // 倉庫→仕入先
                this.SubTotalHeader.DataField = "SupplierCd";
                this.SubTotal_Title.Text = "仕入先計";
            }
            // 2008.11.27 30413 犬飼 出力順制御を修正 <<<<<<END
            
            // 2008.11.04 30413 犬飼 小計印字制御 >>>>>>START
            // 小計印字
            if (this._extrInfo.SubtotalPrintDiv == 0)
            {
                // 小計印字する
                this.SubTotalFooter.Visible = true;
            }
            else
            {
                // 小計印字しない
                this.SubTotalFooter.Visible = false;
            }
            // 2008.11.04 30413 犬飼 小計印字制御 <<<<<<END
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
        /// <br>Note      : 出力順に合わせて、印字パターンを変更します</br>
        /// <br>Programer : 30413 犬飼</br>
        /// <br>Date      : 2008.10.14</br>
        /// </remarks>
        private void SetOutputPrintPattern()
        {
            switch (this._extrInfo.SortDiv)
            {
                case 1:     // 仕入先順
                case 5:     // 仕入先・棚番順
                    {
                        // 明細タイトル
                        SupplierCd_Title.Left = 0.0F;               // 仕入先
                        WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        GoodsNo_Title.Left = 1.063F;              // 品番
                        GoodsName_Title.Left = 2.5F;                // 品名
                        BLGoodsCode_Title.Left = 3.75F;             // BLコード
                        BLGroupCode_Title.Left = 4.25F;             // グループコード
                        Maker_Title.Left = 4.75F;                   // メーカー

                        // 明細行
                        SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        GoodsNo_TextBox.Left = 1.063F;            // 品番
                        GoodsName_TextBox.Left = 2.5F;              // 品名
                        BLGoodsCode_TextBox.Left = 3.75F;           // BLコード
                        BLGroupCode_TextBox.Left = 4.25F;           // グループコード
                        MakerCode_TextBox.Left = 4.75F;             // メーカー
                        break;
                    }
                case 2:     // BLコード順
                    {
                        // 明細タイトル
                        BLGoodsCode_Title.Left = 0.0F;              // BLコード
                        WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        GoodsNo_Title.Left = 1.063F;              // 品番
                        GoodsName_Title.Left = 2.5F;                // 品名
                        SupplierCd_Title.Left = 3.75F;              // 仕入先
                        BLGroupCode_Title.Left = 4.25F;             // グループコード
                        Maker_Title.Left = 4.75F;                   // メーカー

                        // 明細行
                        BLGoodsCode_TextBox.Left = 0.0F;            // BLコード
                        WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        GoodsNo_TextBox.Left = 1.063F;            // 品番
                        GoodsName_TextBox.Left = 2.5F;              // 品名
                        SupplierCd_TextBox.Left = 3.75F;            // 仕入先
                        BLGroupCode_TextBox.Left = 4.25F;           // グループコード
                        MakerCode_TextBox.Left = 4.75F;             // メーカー
                        break;
                    }
                case 3:     // グループコード順
                    {
                        // 明細タイトル
                        BLGroupCode_Title.Left = 0.0F;              // グループコード
                        WarehouseShelfNo_Title.Left = 0.5F;         // 棚番
                        GoodsNo_Title.Left = 1.063F;              // 品番
                        GoodsName_Title.Left = 2.5F;                // 品名
                        SupplierCd_Title.Left = 3.75F;              // 仕入先
                        BLGoodsCode_Title.Left = 4.25F;             // BLコード
                        Maker_Title.Left = 4.75F;                   // メーカー

                        // 明細行
                        BLGroupCode_TextBox.Left = 0.0F;            // グループコード
                        WarehouseShelfNo_TextBox.Left = 0.5F;       // 棚番
                        GoodsNo_TextBox.Left = 1.063F;            // 品番
                        GoodsName_TextBox.Left = 2.5F;              // 品名
                        SupplierCd_TextBox.Left = 3.75F;            // 仕入先
                        BLGoodsCode_TextBox.Left = 4.25F;           // BLコード
                        MakerCode_TextBox.Left = 4.75F;             // メーカー
                        break;
                    }
                case 4:     // メーカー順
                    {
                        // 明細タイトル
                        Maker_Title.Left = 0.0F;                    // メーカー
                        WarehouseShelfNo_Title.Left = 0.375F;       // 棚番
                        GoodsNo_Title.Left = 0.938F;              // 品番
                        GoodsName_Title.Left = 2.375F;              // 品名
                        SupplierCd_Title.Left = 3.625F;             // 仕入先
                        BLGoodsCode_Title.Left = 4.125F;            // BLコード
                        BLGroupCode_Title.Left = 4.625F;            // グループコード

                        // 明細行
                        MakerCode_TextBox.Left = 0.0F;              // メーカー
                        WarehouseShelfNo_TextBox.Left = 0.375F;     // 棚番
                        GoodsNo_TextBox.Left = 0.938F;            // 品番
                        GoodsName_TextBox.Left = 2.375F;            // 品名
                        SupplierCd_TextBox.Left = 3.625F;           // 仕入先
                        BLGoodsCode_TextBox.Left = 4.125F;          // BLコード
                        BLGroupCode_TextBox.Left = 4.625F;          // グループコード
                        break;
                    }
                case 6:     // 仕入先・メーカー順
                    {
                        // 明細タイトル
                        SupplierCd_Title.Left = 0.0F;               // 仕入先
                        Maker_Title.Left = 0.5F;                    // メーカー
                        WarehouseShelfNo_Title.Left = 0.875F;       // 棚番
                        GoodsNo_Title.Left = 1.438F;              // 品番
                        GoodsName_Title.Left = 2.875F;              // 品名
                        BLGoodsCode_Title.Left = 4.125F;            // BLコード
                        BLGroupCode_Title.Left = 4.625F;            // グループコード

                        // 明細行
                        SupplierCd_TextBox.Left = 0.0F;             // 仕入先
                        MakerCode_TextBox.Left = 0.5F;              // メーカー
                        WarehouseShelfNo_TextBox.Left = 0.875F;     // 棚番
                        GoodsNo_TextBox.Left = 1.438F;            // 品番
                        GoodsName_TextBox.Left = 2.875F;            // 品名
                        BLGoodsCode_TextBox.Left = 4.125F;          // BLコード
                        BLGroupCode_TextBox.Left = 4.625F;          // グループコード
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region バッファクリア処理
        /// <summary>
        /// バッファクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス用のバッファを初期化します</br>
        /// <br>Programer : 23010 中村　仁</br>
        /// <br>Date      : 2007.04.11</br>
        /// </remarks>
        private void BufferClear()
        {
            this._warehouseBuff = "";
            // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
            //this._CarrierEpBuff = "";
            //this._largeGoodsBuff = "";
            //this._mediumGoodsBuff = "";
            this._warehouseShelfNoBuff = "";
            // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
            this._makerBuff = "";         
        }

        #endregion

        #region グループサプレス処理
        /// <summary>
        /// グループサプレス処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス処理を行います</br>
        /// <br>Programer : 23010 中村　仁</br>
        /// <br>Date      : 2007.04.11</br>
        /// </remarks>    
        private void SetOfGroupSuppres()
        {            
            //TextBoxにNullが入ることがあるので一応Null判定を入れておく
            //グループサプレス処理(倉庫)    
            if(this.WarehouseCode_TextBox.Text != null)
            {               
                if(this.WarehouseCode_TextBox.Text.CompareTo(this._warehouseBuff) == 0)
                {
                    this.Warehouse_TextBox.Visible = false;
                }
                else
                {
                    this.Warehouse_TextBox.Visible = true;
                    //バッファ更新
                    this._warehouseBuff = this.WarehouseCode_TextBox.Text;
                }            
            }
            else
            {
                 //例外的な場合
                //nullの場合は空文字と見なす
                if(this._warehouseBuff == string.Empty)
                {
                    this.Warehouse_TextBox.Visible = false;
                }
                else
                {
                    this.Warehouse_TextBox.Visible = true;
                    //バッファを空文字で更新
			        this._warehouseBuff = string.Empty;
                }               
            }

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
            //
            //グループサプレス処理(商品大分類)
            //if(this.LgGoosCode_TextBox.Text != null)
            //{
            //    if(this.LgGoosCode_TextBox.Text.CompareTo(this._largeGoodsBuff) == 0)
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
            //    if(this._largeGoodsBuff == string.Empty)
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
            //if(this.MdGoodsCode_TextBox.Text != null)
            //{
            //    if(this.MdGoodsCode_TextBox.Text.CompareTo(this._mediumGoodsBuff) == 0)
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
            //    if(this._mediumGoodsBuff == string.Empty)
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
            //グループサプレス処理(棚番)
            if (this.WarehouseShelfNo_TextBox.Text != null)
            {
                //比べるのは事業者コード(int)
                if (this.WarehouseShelfNo_TextBox.Text.CompareTo(this._warehouseShelfNoBuff) == 0)
                {
                    this.WarehouseShelfNo_TextBox.Visible = false;
                }
                else
                {
                    this.WarehouseShelfNo_TextBox.Visible = true;
                    //バッファ更新
                    this._warehouseShelfNoBuff = this.WarehouseShelfNo_TextBox.Text;
                }
            }
            else
            {
                //例外的な場合
                //nullの場合は空文字と見なす
                if (this._warehouseShelfNoBuff == string.Empty)
                {
                    this.WarehouseShelfNo_TextBox.Visible = false;
                }
                else
                {
                    this.WarehouseShelfNo_TextBox.Visible = true;
                    //バッファを空文字で更新
                    this._warehouseShelfNoBuff = string.Empty;
                }
            }
            // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<

            // 2008.11.04 30413 犬飼 未使用 >>>>>>START
            //if(this.MakerCode_TextBox.Text != null)
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
            //     //例外的な場合
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
            // 2008.11.04 30413 犬飼 未使用 <<<<<<END
        }
        #endregion

		#endregion

        #region Ivent

        #region Detail_BeforePrintイベント
        /// <summary>
		/// Detail_BeforePrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{

            // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
            ////グループサプレス処理
            //SetOfGroupSuppres();
            // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

        }

        #endregion

        #region MAZAI02112P_03A4C_PageEndイベント
        /// <summary>
		/// MAZAI02112P_03A4C_PageEndイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : １ページの出力が終了したときに発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void MAZAI02112P_03A4C_PageEnd(object sender, System.EventArgs eArgs)
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
		/// <br>Date       : 2007.04.11</br>
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

            // 2008.11.27 30413 犬飼 拠点は印字しない >>>>>>START
            //// 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////// 拠点オプション有無判定
            ////if (this._extrInfo.IsOptSection)
            ////{
            ////    
            ////    this._rptExtraHeader.SectionCondition.Text = "棚卸拠点： " + this.StockSectionName.Text;
            ////    
            ////} 
            ////else 
            ////{
            ////    this._rptExtraHeader.SectionCondition.Text = "";
            ////}
            //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            ////this._rptExtraHeader.SectionCondition.Text = "棚卸拠点： " + this.StockSectionName.Text;
            //this._rptExtraHeader.SectionCondition.Text = "棚卸拠点： " + this.StockSectionCode.Text + " " + this.StockSectionName.Text;
            //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            //// 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.11.27 30413 犬飼 拠点は印字しない <<<<<<END
            
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
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // インスタンスが作成されていなければ作成
                if (this._rptPageFooter == null)
                {
                    this._rptPageFooter = new ListCommon_PageFooter();
                }
                else
                {
                    // インスタンスが作成されていれば、データソースを初期化する
                    // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                    this._rptPageFooter.DataSource = null;
                }

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = this._rptPageFooter;
            }
        }

        #endregion

        #region MAZAI02112P_03A4C_ReportStartイベント
        /// <summary>
		/// MAZAI02112P_03A4C_ReportStartイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : MAZAI02112P_03A4C_ReportStartの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void MAZAI02112P_03A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();

            // 2008.10.14 30413 犬飼 印字パターンの変更を追加 >>>>>>START
            // 出力順による印字パターン変更
            SetOutputPrintPattern();
            // 2008.10.14 30413 犬飼 印字パターンの変更を追加 <<<<<<END
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
		/// <br>Date       : 2007.04.11</br>
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
		/// <br>Date        : 2007.04.11</br>
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
		/// <br>Date       : 2007.04.11</br>
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
		///// <br>Date       : 2007.04.11</br>
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
		/// <br>Date       : 2007.04.11</br>
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

        #region GrandTotalFooter_BeforePrintイベント
        /// <summary>
        /// GrandTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 総合計セクションの印刷前に発生するイベントです。</br>
        /// <br>Programmer : 30413　犬飼</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 差異数の計算
            //double plusCnt = double.Parse(g_PlusInventoryTolerancCnt_TextBox.Text);
            //double minusCnt = double.Parse(g_MinusInventoryTolerancCnt_TextBox.Text);
            double plusCnt = (double)g_PlusInventoryTolerancCnt_TextBox.Value;
            double minusCnt = (double)g_MinusInventoryTolerancCnt_TextBox.Value;
            double calcCnt = plusCnt - minusCnt;

            g_CalcInventoryTolerancCnt_TextBox.Value = calcCnt;

            // 差異金額の計算
            //long plusPrice = long.Parse(g_PlusInventoryTlrncPrice_TextBox.Text);
            //long minusPrice = long.Parse(g_MinusInventoryTlrncPrice_TextBox.Text);
            long plusPrice = (long)((double)g_PlusInventoryTlrncPrice_TextBox.Value);
            long minusPrice = (long)((double)g_MinusInventoryTlrncPrice_TextBox.Value);
            long calcPrice = plusPrice - minusPrice;

            g_CalcInventoryTlrncPrice_TextBox.Value = calcPrice;
        }
        #endregion

        #region WarehouseFooter_BeforePrintイベント
        /// <summary>
        /// WarehouseFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫計セクションの印刷前に発生するイベントです。</br>
        /// <br>Programmer : 30413　犬飼</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private void WarehouseFooter_BeforePrint(object sender, EventArgs e)
        {
            // 差異数の計算
            //double plusCnt = double.Parse(w_PlusInventoryTolerancCnt_TextBox.Text);
            //double minusCnt = double.Parse(w_MinusInventoryTolerancCnt_TextBox.Text);
            double plusCnt = (double)w_PlusInventoryTolerancCnt_TextBox.Value;
            double minusCnt = (double)w_MinusInventoryTolerancCnt_TextBox.Value;
            double calcCnt = plusCnt - minusCnt;

            w_CalcInventoryTolerancCnt_TextBox.Value = calcCnt;

            // 差異金額の計算
            //long plusPrice = long.Parse(w_PlusInventoryTlrncPrice_TextBox.Text);
            //long minusPrice = long.Parse(w_MinusInventoryTlrncPrice_TextBox.Text);
            long plusPrice = (long)((double)w_PlusInventoryTlrncPrice_TextBox.Value);
            long minusPrice = (long)((double)w_MinusInventoryTlrncPrice_TextBox.Value);
            long calcPrice = plusPrice - minusPrice;

            w_CalcInventoryTlrncPrice_TextBox.Value = calcPrice;
        }
        #endregion

        #region SubTotalFooter_BeforePrintイベント
        /// <summary>
        /// SubTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 小計セクションの印刷前に発生するイベントです。</br>
        /// <br>Programmer : 30413　犬飼</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private void SubTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 差異数の計算
            //double plusCnt = double.Parse(o_PlusInventoryTolerancCnt_TextBox.Text);
            //double minusCnt = double.Parse(o_MinusInventoryTolerancCnt_TextBox.Text);
            double plusCnt = (double)o_PlusInventoryTolerancCnt_TextBox.Value;
            double minusCnt = (double)o_MinusInventoryTolerancCnt_TextBox.Value;
            double calcCnt = plusCnt - minusCnt;

            o_CalcInventoryTolerancCnt_TextBox.Value = calcCnt;

            // 差異金額の計算
            //long plusPrice = long.Parse(o_PlusInventoryTlrncPrice_TextBox.Text);
            //long minusPrice = long.Parse(o_MinusInventoryTlrncPrice_TextBox.Text);
            long plusPrice = (long)((double)o_PlusInventoryTlrncPrice_TextBox.Value);
            long minusPrice = (long)((double)o_MinusInventoryTlrncPrice_TextBox.Value);
            long calcPrice = plusPrice - minusPrice;

            o_CalcInventoryTlrncPrice_TextBox.Value = calcPrice;
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
		private DataDynamics.ActiveReports.Label Maker_Title;
		private DataDynamics.ActiveReports.Label GoodsNo_Title;
		private DataDynamics.ActiveReports.Line Line4;
        private DataDynamics.ActiveReports.Label StockUnitPrice_Title;
		private DataDynamics.ActiveReports.Label GoodsName_Title;
        private DataDynamics.ActiveReports.Label StockTotal_Title;
		private DataDynamics.ActiveReports.Label WarehouseShelfNo_Title;
        private DataDynamics.ActiveReports.Label InventStockCount_Title;
		private DataDynamics.ActiveReports.Label Label;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.TextBox StockSectionName;
		private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
        private DataDynamics.ActiveReports.GroupHeader SubTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader GoodsHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox StockTotal_TextBox;
        private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.TextBox GoodsName_TextBox;
        private DataDynamics.ActiveReports.TextBox StockUnitPriceFl_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsNo_TextBox;
		private DataDynamics.ActiveReports.TextBox Warehouse_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo_TextBox;
		private DataDynamics.ActiveReports.TextBox InventoryStockCnt_TextBox;
		private DataDynamics.ActiveReports.TextBox TolerancCnt_TextBox;
		private DataDynamics.ActiveReports.TextBox TolerancPrice_TextBox;
		private DataDynamics.ActiveReports.TextBox WarehouseCode_TextBox;
        private DataDynamics.ActiveReports.TextBox MakerCode_TextBox;
		private DataDynamics.ActiveReports.GroupFooter GoodsFooter;
		private DataDynamics.ActiveReports.Line Line44;
		private DataDynamics.ActiveReports.TextBox GoodsTotal_Title;
		private DataDynamics.ActiveReports.TextBox GoodsTotalStockCnt_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsTotalInventStockCnt_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsTotalTolerancCnt_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsTotalTolerancPrice_TextBox;
		private DataDynamics.ActiveReports.GroupFooter SubTotalFooter;
		private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.TextBox SubTotal_Title;
        private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.TextBox WarehouseTotal_Title;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotal_Title;
        private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02112P_03A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.StockTotal_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.GoodsName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockUnitPriceFl_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.InventoryStockCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TolerancPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MakerCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockTotalExec_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode_TextBox = new DataDynamics.ActiveReports.TextBox();
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
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Maker_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.StockUnitPrice_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.StockTotal_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.InventStockCount_Title = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.StockTotalExec_Title = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.SupplierCd_Title = new DataDynamics.ActiveReports.Label();
            this.BLGoodsCode_Title = new DataDynamics.ActiveReports.Label();
            this.BLGroupCode_Title = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotal_Title = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.g_PlusInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.g_MinusInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.g_CalcInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.g_PlusInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.g_MinusInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.g_CalcInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.StockSectionName = new DataDynamics.ActiveReports.TextBox();
            this.StockSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.WarehouseTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.w_MinusInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.w_PlusInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.w_CalcInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.w_PlusInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.w_MinusInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.w_CalcInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SubTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SubTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.SubTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.o_MinusInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.o_PlusInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.o_CalcInventoryTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.o_PlusInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.o_MinusInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.o_CalcInventoryTlrncPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.GoodsTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.GoodsTotalStockCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsTotalInventStockCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsTotalTolerancCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsTotalTolerancPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotal_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryStockCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TolerancPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PlusInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MinusInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CalcInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PlusInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MinusInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CalcInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MinusInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_PlusInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_CalcInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_PlusInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MinusInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_CalcInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_MinusInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_PlusInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_CalcInventoryTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_PlusInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_MinusInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_CalcInventoryTlrncPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalStockCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalInventStockCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalTolerancCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalTolerancPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StockTotal_TextBox,
            this.Line37,
            this.GoodsName_TextBox,
            this.StockUnitPriceFl_TextBox,
            this.GoodsNo_TextBox,
            this.WarehouseShelfNo_TextBox,
            this.InventoryStockCnt_TextBox,
            this.TolerancCnt_TextBox,
            this.TolerancPrice_TextBox,
            this.MakerCode_TextBox,
            this.StockTotalExec_TextBox,
            this.textBox2,
            this.SupplierCd_TextBox,
            this.BLGoodsCode_TextBox,
            this.BLGroupCode_TextBox});
            this.Detail.Height = 0.375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // StockTotal_TextBox
            // 
            this.StockTotal_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotal_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotal_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotal_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotal_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_TextBox.DataField = "StockTotal";
            this.StockTotal_TextBox.Height = 0.125F;
            this.StockTotal_TextBox.Left = 5.125F;
            this.StockTotal_TextBox.MultiLine = false;
            this.StockTotal_TextBox.Name = "StockTotal_TextBox";
            this.StockTotal_TextBox.OutputFormat = resources.GetString("StockTotal_TextBox.OutputFormat");
            this.StockTotal_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockTotal_TextBox.Text = "123456.99";
            this.StockTotal_TextBox.Top = 0F;
            this.StockTotal_TextBox.Width = 0.75F;
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
            this.Line37.Width = 10.8F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8F;
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
            this.GoodsName_TextBox.Left = 2F;
            this.GoodsName_TextBox.MultiLine = false;
            this.GoodsName_TextBox.Name = "GoodsName_TextBox";
            this.GoodsName_TextBox.OutputFormat = resources.GetString("GoodsName_TextBox.OutputFormat");
            this.GoodsName_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName_TextBox.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.GoodsName_TextBox.Top = 0F;
            this.GoodsName_TextBox.Width = 1.1875F;
            // 
            // StockUnitPriceFl_TextBox
            // 
            this.StockUnitPriceFl_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.DataField = "StockUnitPriceFl";
            this.StockUnitPriceFl_TextBox.Height = 0.125F;
            this.StockUnitPriceFl_TextBox.Left = 8.375F;
            this.StockUnitPriceFl_TextBox.MultiLine = false;
            this.StockUnitPriceFl_TextBox.Name = "StockUnitPriceFl_TextBox";
            this.StockUnitPriceFl_TextBox.OutputFormat = resources.GetString("StockUnitPriceFl_TextBox.OutputFormat");
            this.StockUnitPriceFl_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockUnitPriceFl_TextBox.Text = "12,345,678.00";
            this.StockUnitPriceFl_TextBox.Top = 0F;
            this.StockUnitPriceFl_TextBox.Width = 0.8125F;
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
            this.GoodsNo_TextBox.Height = 0.125F;
            this.GoodsNo_TextBox.Left = 0.5625F;
            this.GoodsNo_TextBox.MultiLine = false;
            this.GoodsNo_TextBox.Name = "GoodsNo_TextBox";
            this.GoodsNo_TextBox.OutputFormat = resources.GetString("GoodsNo_TextBox.OutputFormat");
            this.GoodsNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo_TextBox.Text = "123456789012345678901234567890";
            this.GoodsNo_TextBox.Top = 0F;
            this.GoodsNo_TextBox.Width = 1.375F;
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
            this.WarehouseShelfNo_TextBox.Height = 0.125F;
            this.WarehouseShelfNo_TextBox.Left = 0F;
            this.WarehouseShelfNo_TextBox.MultiLine = false;
            this.WarehouseShelfNo_TextBox.Name = "WarehouseShelfNo_TextBox";
            this.WarehouseShelfNo_TextBox.OutputFormat = resources.GetString("WarehouseShelfNo_TextBox.OutputFormat");
            this.WarehouseShelfNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo_TextBox.Text = "ABCDEFGH";
            this.WarehouseShelfNo_TextBox.Top = 0F;
            this.WarehouseShelfNo_TextBox.Width = 0.5F;
            // 
            // InventoryStockCnt_TextBox
            // 
            this.InventoryStockCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InventoryStockCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventoryStockCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InventoryStockCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventoryStockCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InventoryStockCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventoryStockCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InventoryStockCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventoryStockCnt_TextBox.DataField = "InventoryStockCnt";
            this.InventoryStockCnt_TextBox.Height = 0.125F;
            this.InventoryStockCnt_TextBox.Left = 6.75F;
            this.InventoryStockCnt_TextBox.MultiLine = false;
            this.InventoryStockCnt_TextBox.Name = "InventoryStockCnt_TextBox";
            this.InventoryStockCnt_TextBox.OutputFormat = resources.GetString("InventoryStockCnt_TextBox.OutputFormat");
            this.InventoryStockCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.InventoryStockCnt_TextBox.Text = "123456.99";
            this.InventoryStockCnt_TextBox.Top = 0F;
            this.InventoryStockCnt_TextBox.Width = 0.75F;
            // 
            // TolerancCnt_TextBox
            // 
            this.TolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancCnt_TextBox.DataField = "InventoryTolerancCnt";
            this.TolerancCnt_TextBox.Height = 0.125F;
            this.TolerancCnt_TextBox.Left = 7.5625F;
            this.TolerancCnt_TextBox.MultiLine = false;
            this.TolerancCnt_TextBox.Name = "TolerancCnt_TextBox";
            this.TolerancCnt_TextBox.OutputFormat = resources.GetString("TolerancCnt_TextBox.OutputFormat");
            this.TolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TolerancCnt_TextBox.Text = "123456.99";
            this.TolerancCnt_TextBox.Top = 0F;
            this.TolerancCnt_TextBox.Width = 0.75F;
            // 
            // TolerancPrice_TextBox
            // 
            this.TolerancPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TolerancPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TolerancPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TolerancPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TolerancPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TolerancPrice_TextBox.DataField = "InventoryTlrncPrice";
            this.TolerancPrice_TextBox.Height = 0.125F;
            this.TolerancPrice_TextBox.Left = 9.25F;
            this.TolerancPrice_TextBox.MultiLine = false;
            this.TolerancPrice_TextBox.Name = "TolerancPrice_TextBox";
            this.TolerancPrice_TextBox.OutputFormat = resources.GetString("TolerancPrice_TextBox.OutputFormat");
            this.TolerancPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TolerancPrice_TextBox.Text = "1,000,000,000";
            this.TolerancPrice_TextBox.Top = 0F;
            this.TolerancPrice_TextBox.Width = 0.8125F;
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
            this.MakerCode_TextBox.Left = 4.75F;
            this.MakerCode_TextBox.MultiLine = false;
            this.MakerCode_TextBox.Name = "MakerCode_TextBox";
            this.MakerCode_TextBox.OutputFormat = resources.GetString("MakerCode_TextBox.OutputFormat");
            this.MakerCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.MakerCode_TextBox.Text = "1234";
            this.MakerCode_TextBox.Top = 0F;
            this.MakerCode_TextBox.Width = 0.3125F;
            // 
            // StockTotalExec_TextBox
            // 
            this.StockTotalExec_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.DataField = "StockAmount";
            this.StockTotalExec_TextBox.Height = 0.125F;
            this.StockTotalExec_TextBox.Left = 5.9375F;
            this.StockTotalExec_TextBox.MultiLine = false;
            this.StockTotalExec_TextBox.Name = "StockTotalExec_TextBox";
            this.StockTotalExec_TextBox.OutputFormat = resources.GetString("StockTotalExec_TextBox.OutputFormat");
            this.StockTotalExec_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockTotalExec_TextBox.Text = "123456.99";
            this.StockTotalExec_TextBox.Top = 0F;
            this.StockTotalExec_TextBox.Width = 0.75F;
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
            this.textBox2.DataField = "InventoryDay_Print";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 10.125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox2.Text = "99/99/99";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.6F;
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
            this.SupplierCd_TextBox.Left = 3.25F;
            this.SupplierCd_TextBox.MultiLine = false;
            this.SupplierCd_TextBox.Name = "SupplierCd_TextBox";
            this.SupplierCd_TextBox.OutputFormat = resources.GetString("SupplierCd_TextBox.OutputFormat");
            this.SupplierCd_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SupplierCd_TextBox.Text = "123456";
            this.SupplierCd_TextBox.Top = 0F;
            this.SupplierCd_TextBox.Width = 0.4375F;
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
            this.BLGoodsCode_TextBox.Left = 3.75F;
            this.BLGoodsCode_TextBox.MultiLine = false;
            this.BLGoodsCode_TextBox.Name = "BLGoodsCode_TextBox";
            this.BLGoodsCode_TextBox.OutputFormat = resources.GetString("BLGoodsCode_TextBox.OutputFormat");
            this.BLGoodsCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGoodsCode_TextBox.Text = "12345";
            this.BLGoodsCode_TextBox.Top = 0F;
            this.BLGoodsCode_TextBox.Width = 0.4375F;
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
            this.BLGroupCode_TextBox.Left = 4.25F;
            this.BLGroupCode_TextBox.MultiLine = false;
            this.BLGroupCode_TextBox.Name = "BLGroupCode_TextBox";
            this.BLGroupCode_TextBox.OutputFormat = resources.GetString("BLGroupCode_TextBox.OutputFormat");
            this.BLGroupCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGroupCode_TextBox.Text = "12345";
            this.BLGroupCode_TextBox.Top = 0F;
            this.BLGroupCode_TextBox.Width = 0.4375F;
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
            this.Warehouse_TextBox.Width = 0.9375F;
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
            this.Label1.Text = "棚卸差異表";
            this.Label1.Top = 0F;
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
            this.PrintDate.Height = 0.15625F;
            this.PrintDate.Left = 8.5F;
            this.PrintDate.MultiLine = false;
            this.PrintDate.Name = "PrintDate";
            this.PrintDate.OutputFormat = resources.GetString("PrintDate.OutputFormat");
            this.PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintDate.Text = "平成17年11月 5日";
            this.PrintDate.Top = 0.0625F;
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
            this.PRINTPAGE.Height = 0.15625F;
            this.PRINTPAGE.Left = 10.4375F;
            this.PRINTPAGE.MultiLine = false;
            this.PRINTPAGE.Name = "PRINTPAGE";
            this.PRINTPAGE.OutputFormat = resources.GetString("PRINTPAGE.OutputFormat");
            this.PRINTPAGE.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PRINTPAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PRINTPAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PRINTPAGE.Text = "123";
            this.PRINTPAGE.Top = 0.0625F;
            this.PRINTPAGE.Width = 0.28125F;
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
            this.SortTitle.Height = 0.156F;
            this.SortTitle.Left = 2.325F;
            this.SortTitle.MultiLine = false;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.SortTitle.Text = "[ソート条件]";
            this.SortTitle.Top = 0.0625F;
            this.SortTitle.Width = 3F;
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
            this.PrintTime.Left = 9.4375F;
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.PrintTime.Text = "11時20分";
            this.PrintTime.Top = 0.0625F;
            this.PrintTime.Width = 0.5F;
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
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Maker_Title,
            this.GoodsNo_Title,
            this.Line4,
            this.StockUnitPrice_Title,
            this.GoodsName_Title,
            this.StockTotal_Title,
            this.WarehouseShelfNo_Title,
            this.InventStockCount_Title,
            this.Label,
            this.Label4,
            this.StockTotalExec_Title,
            this.label6,
            this.SupplierCd_Title,
            this.BLGoodsCode_Title,
            this.BLGroupCode_Title,
            this.line6});
            this.TitleHeader.Height = 0.3125F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Maker_Title.Left = 4.75F;
            this.Maker_Title.MultiLine = false;
            this.Maker_Title.Name = "Maker_Title";
            this.Maker_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Maker_Title.Text = "ﾒｰｶｰ";
            this.Maker_Title.Top = 0F;
            this.Maker_Title.Width = 0.3125F;
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
            this.GoodsNo_Title.Left = 0.5625F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsNo_Title.Text = "品番";
            this.GoodsNo_Title.Top = 0F;
            this.GoodsNo_Title.Width = 0.6875F;
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
            this.Line4.Width = 10.8F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 10.8F;
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
            this.StockUnitPrice_Title.Left = 8.375F;
            this.StockUnitPrice_Title.MultiLine = false;
            this.StockUnitPrice_Title.Name = "StockUnitPrice_Title";
            this.StockUnitPrice_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.StockUnitPrice_Title.Text = "原単価";
            this.StockUnitPrice_Title.Top = 0F;
            this.StockUnitPrice_Title.Width = 0.8125F;
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
            this.GoodsName_Title.Left = 2F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsName_Title.Text = "品名";
            this.GoodsName_Title.Top = 0F;
            this.GoodsName_Title.Width = 1.1875F;
            // 
            // StockTotal_Title
            // 
            this.StockTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal_Title.Height = 0.1875F;
            this.StockTotal_Title.HyperLink = "";
            this.StockTotal_Title.Left = 5.125F;
            this.StockTotal_Title.MultiLine = false;
            this.StockTotal_Title.Name = "StockTotal_Title";
            this.StockTotal_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.StockTotal_Title.Text = "帳簿数";
            this.StockTotal_Title.Top = 0F;
            this.StockTotal_Title.Width = 0.75F;
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
            this.WarehouseShelfNo_Title.Width = 0.5F;
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
            this.InventStockCount_Title.Left = 6.75F;
            this.InventStockCount_Title.MultiLine = false;
            this.InventStockCount_Title.Name = "InventStockCount_Title";
            this.InventStockCount_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.InventStockCount_Title.Text = "棚卸数";
            this.InventStockCount_Title.Top = 0F;
            this.InventStockCount_Title.Width = 0.75F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.1875F;
            this.Label.HyperLink = "";
            this.Label.Left = 7.5625F;
            this.Label.MultiLine = false;
            this.Label.Name = "Label";
            this.Label.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label.Text = "差異数";
            this.Label.Top = 0F;
            this.Label.Width = 0.75F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.1875F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 9.25F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label4.Text = "差異金額";
            this.Label4.Top = 0F;
            this.Label4.Width = 0.8125F;
            // 
            // StockTotalExec_Title
            // 
            this.StockTotalExec_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Height = 0.1875F;
            this.StockTotalExec_Title.HyperLink = "";
            this.StockTotalExec_Title.Left = 5.9375F;
            this.StockTotalExec_Title.MultiLine = false;
            this.StockTotalExec_Title.Name = "StockTotalExec_Title";
            this.StockTotalExec_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.StockTotalExec_Title.Text = "実施日帳簿数";
            this.StockTotalExec_Title.Top = 0F;
            this.StockTotalExec_Title.Width = 0.75F;
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
            this.label6.Left = 10.125F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label6.Text = "棚卸実施日";
            this.label6.Top = 0F;
            this.label6.Width = 0.625F;
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
            this.SupplierCd_Title.Left = 3.25F;
            this.SupplierCd_Title.MultiLine = false;
            this.SupplierCd_Title.Name = "SupplierCd_Title";
            this.SupplierCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.SupplierCd_Title.Text = "仕入先";
            this.SupplierCd_Title.Top = 0F;
            this.SupplierCd_Title.Width = 0.4375F;
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
            this.BLGoodsCode_Title.Left = 3.75F;
            this.BLGoodsCode_Title.MultiLine = false;
            this.BLGoodsCode_Title.Name = "BLGoodsCode_Title";
            this.BLGoodsCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.BLGoodsCode_Title.Text = "BLｺｰﾄﾞ";
            this.BLGoodsCode_Title.Top = 0F;
            this.BLGoodsCode_Title.Width = 0.4375F;
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
            this.BLGroupCode_Title.Left = 4.25F;
            this.BLGroupCode_Title.MultiLine = false;
            this.BLGroupCode_Title.Name = "BLGroupCode_Title";
            this.BLGroupCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.BLGroupCode_Title.Text = "ｸﾞﾙｰﾌﾟ";
            this.BLGroupCode_Title.Top = 0F;
            this.BLGroupCode_Title.Width = 0.4375F;
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
            this.GrandTotal_Title,
            this.Line,
            this.label7,
            this.label8,
            this.label9,
            this.g_PlusInventoryTolerancCnt_TextBox,
            this.g_MinusInventoryTolerancCnt_TextBox,
            this.g_CalcInventoryTolerancCnt_TextBox,
            this.label10,
            this.label11,
            this.label12,
            this.g_PlusInventoryTlrncPrice_TextBox,
            this.g_MinusInventoryTlrncPrice_TextBox,
            this.g_CalcInventoryTlrncPrice_TextBox});
            this.GrandTotalFooter.Height = 0.65625F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.GrandTotal_Title.Left = 5.125F;
            this.GrandTotal_Title.MultiLine = false;
            this.GrandTotal_Title.Name = "GrandTotal_Title";
            this.GrandTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.GrandTotal_Title.Text = "総合計";
            this.GrandTotal_Title.Top = 0F;
            this.GrandTotal_Title.Width = 1F;
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
            this.label7.Left = 6.75F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label7.Text = "＋";
            this.label7.Top = 0F;
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
            this.label8.Left = 6.75F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label8.Text = "－";
            this.label8.Top = 0.1875F;
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
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label9.Text = "差異";
            this.label9.Top = 0.375F;
            this.label9.Width = 0.75F;
            // 
            // g_PlusInventoryTolerancCnt_TextBox
            // 
            this.g_PlusInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTolerancCnt_TextBox.DataField = "PlusInventoryTolerancCnt";
            this.g_PlusInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.g_PlusInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.g_PlusInventoryTolerancCnt_TextBox.MultiLine = false;
            this.g_PlusInventoryTolerancCnt_TextBox.Name = "g_PlusInventoryTolerancCnt_TextBox";
            this.g_PlusInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("g_PlusInventoryTolerancCnt_TextBox.OutputFormat");
            this.g_PlusInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.g_PlusInventoryTolerancCnt_TextBox.SummaryGroup = "GrandTotalHeader";
            this.g_PlusInventoryTolerancCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_PlusInventoryTolerancCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_PlusInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.g_PlusInventoryTolerancCnt_TextBox.Top = 0F;
            this.g_PlusInventoryTolerancCnt_TextBox.Width = 0.75F;
            // 
            // g_MinusInventoryTolerancCnt_TextBox
            // 
            this.g_MinusInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTolerancCnt_TextBox.DataField = "MinusInventoryTolerancCnt";
            this.g_MinusInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.g_MinusInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.g_MinusInventoryTolerancCnt_TextBox.MultiLine = false;
            this.g_MinusInventoryTolerancCnt_TextBox.Name = "g_MinusInventoryTolerancCnt_TextBox";
            this.g_MinusInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("g_MinusInventoryTolerancCnt_TextBox.OutputFormat");
            this.g_MinusInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.g_MinusInventoryTolerancCnt_TextBox.SummaryGroup = "GrandTotalHeader";
            this.g_MinusInventoryTolerancCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MinusInventoryTolerancCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MinusInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.g_MinusInventoryTolerancCnt_TextBox.Top = 0.1875F;
            this.g_MinusInventoryTolerancCnt_TextBox.Width = 0.75F;
            // 
            // g_CalcInventoryTolerancCnt_TextBox
            // 
            this.g_CalcInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.g_CalcInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.g_CalcInventoryTolerancCnt_TextBox.MultiLine = false;
            this.g_CalcInventoryTolerancCnt_TextBox.Name = "g_CalcInventoryTolerancCnt_TextBox";
            this.g_CalcInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("g_CalcInventoryTolerancCnt_TextBox.OutputFormat");
            this.g_CalcInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.g_CalcInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.g_CalcInventoryTolerancCnt_TextBox.Top = 0.375F;
            this.g_CalcInventoryTolerancCnt_TextBox.Width = 0.75F;
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
            this.label10.Left = 8.4375F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label10.Text = "－";
            this.label10.Top = 0.1875F;
            this.label10.Width = 0.75F;
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
            this.label11.Left = 8.4375F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label11.Text = "＋";
            this.label11.Top = 0F;
            this.label11.Width = 0.75F;
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
            this.label12.Left = 8.4375F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label12.Text = "差異";
            this.label12.Top = 0.375F;
            this.label12.Width = 0.75F;
            // 
            // g_PlusInventoryTlrncPrice_TextBox
            // 
            this.g_PlusInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.g_PlusInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PlusInventoryTlrncPrice_TextBox.DataField = "PlusInventoryTlrncPrice";
            this.g_PlusInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.g_PlusInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.g_PlusInventoryTlrncPrice_TextBox.MultiLine = false;
            this.g_PlusInventoryTlrncPrice_TextBox.Name = "g_PlusInventoryTlrncPrice_TextBox";
            this.g_PlusInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("g_PlusInventoryTlrncPrice_TextBox.OutputFormat");
            this.g_PlusInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.g_PlusInventoryTlrncPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.g_PlusInventoryTlrncPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_PlusInventoryTlrncPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_PlusInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.g_PlusInventoryTlrncPrice_TextBox.Top = 0F;
            this.g_PlusInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // g_MinusInventoryTlrncPrice_TextBox
            // 
            this.g_MinusInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.g_MinusInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MinusInventoryTlrncPrice_TextBox.DataField = "MinusInventoryTlrncPrice";
            this.g_MinusInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.g_MinusInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.g_MinusInventoryTlrncPrice_TextBox.MultiLine = false;
            this.g_MinusInventoryTlrncPrice_TextBox.Name = "g_MinusInventoryTlrncPrice_TextBox";
            this.g_MinusInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("g_MinusInventoryTlrncPrice_TextBox.OutputFormat");
            this.g_MinusInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.g_MinusInventoryTlrncPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.g_MinusInventoryTlrncPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MinusInventoryTlrncPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MinusInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.g_MinusInventoryTlrncPrice_TextBox.Top = 0.1875F;
            this.g_MinusInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // g_CalcInventoryTlrncPrice_TextBox
            // 
            this.g_CalcInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.g_CalcInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.g_CalcInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.g_CalcInventoryTlrncPrice_TextBox.MultiLine = false;
            this.g_CalcInventoryTlrncPrice_TextBox.Name = "g_CalcInventoryTlrncPrice_TextBox";
            this.g_CalcInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("g_CalcInventoryTlrncPrice_TextBox.OutputFormat");
            this.g_CalcInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.g_CalcInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.g_CalcInventoryTlrncPrice_TextBox.Top = 0.375F;
            this.g_CalcInventoryTlrncPrice_TextBox.Width = 0.8125F;
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
            this.StockSectionName.Left = 0F;
            this.StockSectionName.MultiLine = false;
            this.StockSectionName.Name = "StockSectionName";
            this.StockSectionName.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.StockSectionName.Text = null;
            this.StockSectionName.Top = 0F;
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
            this.StockSectionCode.Left = 0.8125F;
            this.StockSectionCode.MultiLine = false;
            this.StockSectionCode.Name = "StockSectionCode";
            this.StockSectionCode.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.StockSectionCode.Text = null;
            this.StockSectionCode.Top = 0F;
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
            this.WarehouseHeader.Height = 0.1875F;
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
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line2,
            this.WarehouseTotal_Title,
            this.label13,
            this.label14,
            this.label15,
            this.w_MinusInventoryTolerancCnt_TextBox,
            this.w_PlusInventoryTolerancCnt_TextBox,
            this.w_CalcInventoryTolerancCnt_TextBox,
            this.label16,
            this.label17,
            this.label18,
            this.w_PlusInventoryTlrncPrice_TextBox,
            this.w_MinusInventoryTlrncPrice_TextBox,
            this.w_CalcInventoryTlrncPrice_TextBox});
            this.WarehouseFooter.Height = 0.65625F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.AfterPrint += new System.EventHandler(this.WarehouseFooter_AfterPrint);
            this.WarehouseFooter.BeforePrint += new System.EventHandler(this.WarehouseFooter_BeforePrint);
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
            this.WarehouseTotal_Title.Left = 5.125F;
            this.WarehouseTotal_Title.MultiLine = false;
            this.WarehouseTotal_Title.Name = "WarehouseTotal_Title";
            this.WarehouseTotal_Title.OutputFormat = resources.GetString("WarehouseTotal_Title.OutputFormat");
            this.WarehouseTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.WarehouseTotal_Title.Text = "倉庫計";
            this.WarehouseTotal_Title.Top = 0F;
            this.WarehouseTotal_Title.Width = 1F;
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
            this.label13.Left = 6.75F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label13.Text = "－";
            this.label13.Top = 0.1875F;
            this.label13.Width = 0.75F;
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
            this.label14.Left = 6.75F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label14.Text = "＋";
            this.label14.Top = 0F;
            this.label14.Width = 0.75F;
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
            this.label15.Left = 6.75F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label15.Text = "差異";
            this.label15.Top = 0.375F;
            this.label15.Width = 0.75F;
            // 
            // w_MinusInventoryTolerancCnt_TextBox
            // 
            this.w_MinusInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTolerancCnt_TextBox.DataField = "MinusInventoryTolerancCnt";
            this.w_MinusInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.w_MinusInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.w_MinusInventoryTolerancCnt_TextBox.MultiLine = false;
            this.w_MinusInventoryTolerancCnt_TextBox.Name = "w_MinusInventoryTolerancCnt_TextBox";
            this.w_MinusInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("w_MinusInventoryTolerancCnt_TextBox.OutputFormat");
            this.w_MinusInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.w_MinusInventoryTolerancCnt_TextBox.SummaryGroup = "WarehouseHeader";
            this.w_MinusInventoryTolerancCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MinusInventoryTolerancCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MinusInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.w_MinusInventoryTolerancCnt_TextBox.Top = 0.1875F;
            this.w_MinusInventoryTolerancCnt_TextBox.Width = 0.75F;
            // 
            // w_PlusInventoryTolerancCnt_TextBox
            // 
            this.w_PlusInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTolerancCnt_TextBox.DataField = "PlusInventoryTolerancCnt";
            this.w_PlusInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.w_PlusInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.w_PlusInventoryTolerancCnt_TextBox.MultiLine = false;
            this.w_PlusInventoryTolerancCnt_TextBox.Name = "w_PlusInventoryTolerancCnt_TextBox";
            this.w_PlusInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("w_PlusInventoryTolerancCnt_TextBox.OutputFormat");
            this.w_PlusInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.w_PlusInventoryTolerancCnt_TextBox.SummaryGroup = "WarehouseHeader";
            this.w_PlusInventoryTolerancCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_PlusInventoryTolerancCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_PlusInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.w_PlusInventoryTolerancCnt_TextBox.Top = 0F;
            this.w_PlusInventoryTolerancCnt_TextBox.Width = 0.75F;
            // 
            // w_CalcInventoryTolerancCnt_TextBox
            // 
            this.w_CalcInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.w_CalcInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.w_CalcInventoryTolerancCnt_TextBox.MultiLine = false;
            this.w_CalcInventoryTolerancCnt_TextBox.Name = "w_CalcInventoryTolerancCnt_TextBox";
            this.w_CalcInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("w_CalcInventoryTolerancCnt_TextBox.OutputFormat");
            this.w_CalcInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.w_CalcInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.w_CalcInventoryTolerancCnt_TextBox.Top = 0.375F;
            this.w_CalcInventoryTolerancCnt_TextBox.Width = 0.75F;
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
            this.label16.Left = 8.4375F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label16.Text = "－";
            this.label16.Top = 0.1875F;
            this.label16.Width = 0.75F;
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
            this.label17.Left = 8.4375F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label17.Text = "＋";
            this.label17.Top = 0F;
            this.label17.Width = 0.75F;
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
            this.label18.Left = 8.4375F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label18.Text = "差異";
            this.label18.Top = 0.375F;
            this.label18.Width = 0.75F;
            // 
            // w_PlusInventoryTlrncPrice_TextBox
            // 
            this.w_PlusInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.w_PlusInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_PlusInventoryTlrncPrice_TextBox.DataField = "PlusInventoryTlrncPrice";
            this.w_PlusInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.w_PlusInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.w_PlusInventoryTlrncPrice_TextBox.MultiLine = false;
            this.w_PlusInventoryTlrncPrice_TextBox.Name = "w_PlusInventoryTlrncPrice_TextBox";
            this.w_PlusInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("w_PlusInventoryTlrncPrice_TextBox.OutputFormat");
            this.w_PlusInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.w_PlusInventoryTlrncPrice_TextBox.SummaryGroup = "WarehouseHeader";
            this.w_PlusInventoryTlrncPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_PlusInventoryTlrncPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_PlusInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.w_PlusInventoryTlrncPrice_TextBox.Top = 0F;
            this.w_PlusInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // w_MinusInventoryTlrncPrice_TextBox
            // 
            this.w_MinusInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.w_MinusInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MinusInventoryTlrncPrice_TextBox.DataField = "MinusInventoryTlrncPrice";
            this.w_MinusInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.w_MinusInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.w_MinusInventoryTlrncPrice_TextBox.MultiLine = false;
            this.w_MinusInventoryTlrncPrice_TextBox.Name = "w_MinusInventoryTlrncPrice_TextBox";
            this.w_MinusInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("w_MinusInventoryTlrncPrice_TextBox.OutputFormat");
            this.w_MinusInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.w_MinusInventoryTlrncPrice_TextBox.SummaryGroup = "WarehouseHeader";
            this.w_MinusInventoryTlrncPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MinusInventoryTlrncPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MinusInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.w_MinusInventoryTlrncPrice_TextBox.Top = 0.1875F;
            this.w_MinusInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // w_CalcInventoryTlrncPrice_TextBox
            // 
            this.w_CalcInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.w_CalcInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_CalcInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.w_CalcInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.w_CalcInventoryTlrncPrice_TextBox.MultiLine = false;
            this.w_CalcInventoryTlrncPrice_TextBox.Name = "w_CalcInventoryTlrncPrice_TextBox";
            this.w_CalcInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("w_CalcInventoryTlrncPrice_TextBox.OutputFormat");
            this.w_CalcInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.w_CalcInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.w_CalcInventoryTlrncPrice_TextBox.Top = 0.375F;
            this.w_CalcInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // SubTotalHeader
            // 
            this.SubTotalHeader.CanShrink = true;
            this.SubTotalHeader.Height = 0F;
            this.SubTotalHeader.Name = "SubTotalHeader";
            this.SubTotalHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SubTotalHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SubTotalFooter
            // 
            this.SubTotalFooter.CanShrink = true;
            this.SubTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line5,
            this.SubTotal_Title,
            this.label19,
            this.label20,
            this.label21,
            this.o_MinusInventoryTolerancCnt_TextBox,
            this.o_PlusInventoryTolerancCnt_TextBox,
            this.o_CalcInventoryTolerancCnt_TextBox,
            this.label22,
            this.label23,
            this.label24,
            this.o_PlusInventoryTlrncPrice_TextBox,
            this.o_MinusInventoryTlrncPrice_TextBox,
            this.o_CalcInventoryTlrncPrice_TextBox});
            this.SubTotalFooter.Height = 0.65625F;
            this.SubTotalFooter.KeepTogether = true;
            this.SubTotalFooter.Name = "SubTotalFooter";
            this.SubTotalFooter.AfterPrint += new System.EventHandler(this.MakerFooter_AfterPrint);
            this.SubTotalFooter.BeforePrint += new System.EventHandler(this.SubTotalFooter_BeforePrint);
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
            this.Line5.Width = 10.8F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.8F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // SubTotal_Title
            // 
            this.SubTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Height = 0.1875F;
            this.SubTotal_Title.Left = 5.125F;
            this.SubTotal_Title.MultiLine = false;
            this.SubTotal_Title.Name = "SubTotal_Title";
            this.SubTotal_Title.OutputFormat = resources.GetString("SubTotal_Title.OutputFormat");
            this.SubTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.SubTotal_Title.Text = "出力順計";
            this.SubTotal_Title.Top = 0F;
            this.SubTotal_Title.Width = 1F;
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
            this.label19.Left = 6.75F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label19.Text = "＋";
            this.label19.Top = 0F;
            this.label19.Width = 0.75F;
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
            this.label20.Left = 6.75F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label20.Text = "－";
            this.label20.Top = 0.1875F;
            this.label20.Width = 0.75F;
            // 
            // label21
            // 
            this.label21.Border.BottomColor = System.Drawing.Color.Black;
            this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.LeftColor = System.Drawing.Color.Black;
            this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.RightColor = System.Drawing.Color.Black;
            this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.TopColor = System.Drawing.Color.Black;
            this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Height = 0.1875F;
            this.label21.HyperLink = "";
            this.label21.Left = 6.75F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label21.Text = "差異";
            this.label21.Top = 0.375F;
            this.label21.Width = 0.75F;
            // 
            // o_MinusInventoryTolerancCnt_TextBox
            // 
            this.o_MinusInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTolerancCnt_TextBox.DataField = "MinusInventoryTolerancCnt";
            this.o_MinusInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.o_MinusInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.o_MinusInventoryTolerancCnt_TextBox.MultiLine = false;
            this.o_MinusInventoryTolerancCnt_TextBox.Name = "o_MinusInventoryTolerancCnt_TextBox";
            this.o_MinusInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("o_MinusInventoryTolerancCnt_TextBox.OutputFormat");
            this.o_MinusInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.o_MinusInventoryTolerancCnt_TextBox.SummaryGroup = "SubTotalHeader";
            this.o_MinusInventoryTolerancCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.o_MinusInventoryTolerancCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.o_MinusInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.o_MinusInventoryTolerancCnt_TextBox.Top = 0.1875F;
            this.o_MinusInventoryTolerancCnt_TextBox.Width = 0.75F;
            // 
            // o_PlusInventoryTolerancCnt_TextBox
            // 
            this.o_PlusInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTolerancCnt_TextBox.DataField = "PlusInventoryTolerancCnt";
            this.o_PlusInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.o_PlusInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.o_PlusInventoryTolerancCnt_TextBox.MultiLine = false;
            this.o_PlusInventoryTolerancCnt_TextBox.Name = "o_PlusInventoryTolerancCnt_TextBox";
            this.o_PlusInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("o_PlusInventoryTolerancCnt_TextBox.OutputFormat");
            this.o_PlusInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.o_PlusInventoryTolerancCnt_TextBox.SummaryGroup = "SubTotalHeader";
            this.o_PlusInventoryTolerancCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.o_PlusInventoryTolerancCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.o_PlusInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.o_PlusInventoryTolerancCnt_TextBox.Top = 0F;
            this.o_PlusInventoryTolerancCnt_TextBox.Width = 0.75F;
            // 
            // o_CalcInventoryTolerancCnt_TextBox
            // 
            this.o_CalcInventoryTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTolerancCnt_TextBox.Height = 0.1875F;
            this.o_CalcInventoryTolerancCnt_TextBox.Left = 7.5625F;
            this.o_CalcInventoryTolerancCnt_TextBox.MultiLine = false;
            this.o_CalcInventoryTolerancCnt_TextBox.Name = "o_CalcInventoryTolerancCnt_TextBox";
            this.o_CalcInventoryTolerancCnt_TextBox.OutputFormat = resources.GetString("o_CalcInventoryTolerancCnt_TextBox.OutputFormat");
            this.o_CalcInventoryTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.o_CalcInventoryTolerancCnt_TextBox.Text = "123456.99";
            this.o_CalcInventoryTolerancCnt_TextBox.Top = 0.375F;
            this.o_CalcInventoryTolerancCnt_TextBox.Width = 0.75F;
            // 
            // label22
            // 
            this.label22.Border.BottomColor = System.Drawing.Color.Black;
            this.label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.LeftColor = System.Drawing.Color.Black;
            this.label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.RightColor = System.Drawing.Color.Black;
            this.label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.TopColor = System.Drawing.Color.Black;
            this.label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Height = 0.1875F;
            this.label22.HyperLink = "";
            this.label22.Left = 8.4375F;
            this.label22.MultiLine = false;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label22.Text = "－";
            this.label22.Top = 0.1875F;
            this.label22.Width = 0.75F;
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
            this.label23.Left = 8.4375F;
            this.label23.MultiLine = false;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label23.Text = "＋";
            this.label23.Top = 0F;
            this.label23.Width = 0.75F;
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
            this.label24.Left = 8.4375F;
            this.label24.MultiLine = false;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label24.Text = "差異";
            this.label24.Top = 0.375F;
            this.label24.Width = 0.75F;
            // 
            // o_PlusInventoryTlrncPrice_TextBox
            // 
            this.o_PlusInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.o_PlusInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_PlusInventoryTlrncPrice_TextBox.DataField = "PlusInventoryTlrncPrice";
            this.o_PlusInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.o_PlusInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.o_PlusInventoryTlrncPrice_TextBox.MultiLine = false;
            this.o_PlusInventoryTlrncPrice_TextBox.Name = "o_PlusInventoryTlrncPrice_TextBox";
            this.o_PlusInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("o_PlusInventoryTlrncPrice_TextBox.OutputFormat");
            this.o_PlusInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.o_PlusInventoryTlrncPrice_TextBox.SummaryGroup = "SubTotalHeader";
            this.o_PlusInventoryTlrncPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.o_PlusInventoryTlrncPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.o_PlusInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.o_PlusInventoryTlrncPrice_TextBox.Top = 0F;
            this.o_PlusInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // o_MinusInventoryTlrncPrice_TextBox
            // 
            this.o_MinusInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.o_MinusInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_MinusInventoryTlrncPrice_TextBox.DataField = "MinusInventoryTlrncPrice";
            this.o_MinusInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.o_MinusInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.o_MinusInventoryTlrncPrice_TextBox.MultiLine = false;
            this.o_MinusInventoryTlrncPrice_TextBox.Name = "o_MinusInventoryTlrncPrice_TextBox";
            this.o_MinusInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("o_MinusInventoryTlrncPrice_TextBox.OutputFormat");
            this.o_MinusInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.o_MinusInventoryTlrncPrice_TextBox.SummaryGroup = "SubTotalHeader";
            this.o_MinusInventoryTlrncPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.o_MinusInventoryTlrncPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.o_MinusInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.o_MinusInventoryTlrncPrice_TextBox.Top = 0.1875F;
            this.o_MinusInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // o_CalcInventoryTlrncPrice_TextBox
            // 
            this.o_CalcInventoryTlrncPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTlrncPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTlrncPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTlrncPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTlrncPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTlrncPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTlrncPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.o_CalcInventoryTlrncPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.o_CalcInventoryTlrncPrice_TextBox.Height = 0.1875F;
            this.o_CalcInventoryTlrncPrice_TextBox.Left = 9.25F;
            this.o_CalcInventoryTlrncPrice_TextBox.MultiLine = false;
            this.o_CalcInventoryTlrncPrice_TextBox.Name = "o_CalcInventoryTlrncPrice_TextBox";
            this.o_CalcInventoryTlrncPrice_TextBox.OutputFormat = resources.GetString("o_CalcInventoryTlrncPrice_TextBox.OutputFormat");
            this.o_CalcInventoryTlrncPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.o_CalcInventoryTlrncPrice_TextBox.Text = "1,000,000,000";
            this.o_CalcInventoryTlrncPrice_TextBox.Top = 0.375F;
            this.o_CalcInventoryTlrncPrice_TextBox.Width = 0.8125F;
            // 
            // GoodsHeader
            // 
            this.GoodsHeader.CanShrink = true;
            this.GoodsHeader.Height = 0F;
            this.GoodsHeader.Name = "GoodsHeader";
            this.GoodsHeader.Visible = false;
            // 
            // GoodsFooter
            // 
            this.GoodsFooter.CanShrink = true;
            this.GoodsFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.GoodsTotal_Title,
            this.GoodsTotalStockCnt_TextBox,
            this.GoodsTotalInventStockCnt_TextBox,
            this.GoodsTotalTolerancCnt_TextBox,
            this.GoodsTotalTolerancPrice_TextBox,
            this.textBox3});
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
            this.Line44.Width = 10.8F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 10.8F;
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
            this.GoodsTotal_Title.Left = 4.125F;
            this.GoodsTotal_Title.MultiLine = false;
            this.GoodsTotal_Title.Name = "GoodsTotal_Title";
            this.GoodsTotal_Title.OutputFormat = resources.GetString("GoodsTotal_Title.OutputFormat");
            this.GoodsTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 10.8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsTotal_Title.Text = "商品計";
            this.GoodsTotal_Title.Top = 0.031F;
            this.GoodsTotal_Title.Width = 0.5625F;
            // 
            // GoodsTotalStockCnt_TextBox
            // 
            this.GoodsTotalStockCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsTotalStockCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsTotalStockCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsTotalStockCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsTotalStockCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockCnt_TextBox.DataField = "StockCnt";
            this.GoodsTotalStockCnt_TextBox.Height = 0.125F;
            this.GoodsTotalStockCnt_TextBox.Left = 5.75F;
            this.GoodsTotalStockCnt_TextBox.MultiLine = false;
            this.GoodsTotalStockCnt_TextBox.Name = "GoodsTotalStockCnt_TextBox";
            this.GoodsTotalStockCnt_TextBox.OutputFormat = resources.GetString("GoodsTotalStockCnt_TextBox.OutputFormat");
            this.GoodsTotalStockCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GoodsTotalStockCnt_TextBox.SummaryGroup = "GoodsHeader";
            this.GoodsTotalStockCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GoodsTotalStockCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GoodsTotalStockCnt_TextBox.Text = "1,234,567.89";
            this.GoodsTotalStockCnt_TextBox.Top = 0.032F;
            this.GoodsTotalStockCnt_TextBox.Width = 0.75F;
            // 
            // GoodsTotalInventStockCnt_TextBox
            // 
            this.GoodsTotalInventStockCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsTotalInventStockCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalInventStockCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsTotalInventStockCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalInventStockCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsTotalInventStockCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalInventStockCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsTotalInventStockCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalInventStockCnt_TextBox.DataField = "InventoryStkCnt";
            this.GoodsTotalInventStockCnt_TextBox.Height = 0.125F;
            this.GoodsTotalInventStockCnt_TextBox.Left = 7.25F;
            this.GoodsTotalInventStockCnt_TextBox.MultiLine = false;
            this.GoodsTotalInventStockCnt_TextBox.Name = "GoodsTotalInventStockCnt_TextBox";
            this.GoodsTotalInventStockCnt_TextBox.OutputFormat = resources.GetString("GoodsTotalInventStockCnt_TextBox.OutputFormat");
            this.GoodsTotalInventStockCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GoodsTotalInventStockCnt_TextBox.SummaryGroup = "GoodsHeader";
            this.GoodsTotalInventStockCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GoodsTotalInventStockCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GoodsTotalInventStockCnt_TextBox.Text = "1,234,567.89";
            this.GoodsTotalInventStockCnt_TextBox.Top = 0.032F;
            this.GoodsTotalInventStockCnt_TextBox.Width = 0.75F;
            // 
            // GoodsTotalTolerancCnt_TextBox
            // 
            this.GoodsTotalTolerancCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancCnt_TextBox.DataField = "InventoryTolerancCnt";
            this.GoodsTotalTolerancCnt_TextBox.Height = 0.125F;
            this.GoodsTotalTolerancCnt_TextBox.Left = 8F;
            this.GoodsTotalTolerancCnt_TextBox.MultiLine = false;
            this.GoodsTotalTolerancCnt_TextBox.Name = "GoodsTotalTolerancCnt_TextBox";
            this.GoodsTotalTolerancCnt_TextBox.OutputFormat = resources.GetString("GoodsTotalTolerancCnt_TextBox.OutputFormat");
            this.GoodsTotalTolerancCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GoodsTotalTolerancCnt_TextBox.SummaryGroup = "GoodsHeader";
            this.GoodsTotalTolerancCnt_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GoodsTotalTolerancCnt_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GoodsTotalTolerancCnt_TextBox.Text = "123,456.78";
            this.GoodsTotalTolerancCnt_TextBox.Top = 0.032F;
            this.GoodsTotalTolerancCnt_TextBox.Width = 0.75F;
            // 
            // GoodsTotalTolerancPrice_TextBox
            // 
            this.GoodsTotalTolerancPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsTotalTolerancPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalTolerancPrice_TextBox.DataField = "TolerancPrice";
            this.GoodsTotalTolerancPrice_TextBox.Height = 0.125F;
            this.GoodsTotalTolerancPrice_TextBox.Left = 9.063F;
            this.GoodsTotalTolerancPrice_TextBox.MultiLine = false;
            this.GoodsTotalTolerancPrice_TextBox.Name = "GoodsTotalTolerancPrice_TextBox";
            this.GoodsTotalTolerancPrice_TextBox.OutputFormat = resources.GetString("GoodsTotalTolerancPrice_TextBox.OutputFormat");
            this.GoodsTotalTolerancPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GoodsTotalTolerancPrice_TextBox.SummaryGroup = "GoodsHeader";
            this.GoodsTotalTolerancPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GoodsTotalTolerancPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GoodsTotalTolerancPrice_TextBox.Text = "1,000,000";
            this.GoodsTotalTolerancPrice_TextBox.Top = 0.032F;
            this.GoodsTotalTolerancPrice_TextBox.Width = 1.0625F;
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
            this.textBox3.DataField = "StockTotalExec";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 6.5F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox3.SummaryGroup = "GoodsHeader";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox3.Text = "1,234,567.89";
            this.textBox3.Top = 0.032F;
            this.textBox3.Width = 0.75F;
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
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.1875F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0.1875F;
            this.line6.Y2 = 0.1875F;
            // 
            // MAZAI02112P_03A4C
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
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.SubTotalHeader);
            this.Sections.Add(this.GoodsHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GoodsFooter);
            this.Sections.Add(this.SubTotalFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02112P_03A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02112P_03A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.StockTotal_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryStockCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TolerancPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PlusInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MinusInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CalcInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PlusInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MinusInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CalcInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MinusInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_PlusInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_CalcInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_PlusInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MinusInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_CalcInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_MinusInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_PlusInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_CalcInventoryTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_PlusInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_MinusInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.o_CalcInventoryTlrncPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalStockCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalInventStockCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalTolerancCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalTolerancPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

    }
}
