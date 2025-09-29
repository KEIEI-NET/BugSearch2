//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫一覧表
// プログラム概要   : 在庫一覧表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村　仁
// 作 成 日  2007/03/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/10/05  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/01/24  修正内容 : DC.NS対応（不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/03  修正内容 : 障害対応12030
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/13  修正内容 : 不具合対応[12371][12375]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/24  修正内容 : 不具合対応[12696]　※12371の修正ミス
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/26  修正内容 : 不具合対応[12832]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/03  修正内容 : 不具合対応[12797][13000]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 不具合対応[13151]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/27  修正内容 : 不具合対応[13372]
//                                  ・GrandTotalHeaderとWarehouseHeaderのRepeatStyleプロパティをOnPageIncludeNoDetailに変更
//----------------------------------------------------------------------------//
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
	/// 在庫一覧表印刷(詳細)フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 在庫一覧表のフォームクラスです。</br>
	/// <br>Programmer	: 23010　中村　仁</br>
	/// <br>Date		: 2007.03.22</br>
    /// <br>Update Note : 2007.10.05 980035 金沢 貞義</br>
    /// <br>			  ・DC.NS対応</br>
    /// <br>Update Note : 2008.01.24 980035 金沢 貞義</br>
    /// <br>			  ・DC.NS対応（不具合対応）</br>
    /// <br>Update Note : 2009/03/03 30452 上野 俊治</br>
    /// <br>             ・障害対応12030</br>
    /// <br>            : 2009/03/13       照田 貴志</br>
    /// <br>             ・不具合対応[12371][12375]</br>
    /// <br>            : 2009/03/24       照田 貴志</br>
    /// <br>             ・不具合対応[12696]　※12371の修正ミス</br>
    /// <br>            : 2009/03/26       照田 貴志　不具合対応[12832]</br>
    /// <br>            : 2009/04/03       照田 貴志　不具合対応[12797][13000]</br>
    /// <br>            : 2009/04/07       上野 俊治　不具合対応[13151]</br>
    /// <br>            : 2009/05/27       照田 貴志　不具合対応[13372]</br>
    /// <br>              ・GrandTotalHeaderとWarehouseHeaderのRepeatStyleプロパティをOnPageIncludeNoDetailに変更</br>
    /// </remarks>
	public class MAZAI02072P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		/// <summary>
		/// 在庫一覧表(詳細)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 在庫一覧表(詳細)フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 23010　中村　仁</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		public MAZAI02072P_02A4C()
		{
			InitializeComponent();       
		}

		#region Private Member
		private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			 _otherDataList;				// その他データ
	
		private	StockListCndtn _extrInfo;					        // 抽出条件クラス

        private string _beforeCode = string.Empty;                  // 前回値(グループサプレス用)   //ADD 2008/10/08

		// その他データ格納項目		
		private int					 _printCount;					// ページ数カウント用
       
		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
        ListCommon_PageFooter _rptPageFooter = null;
        private Label Lb_GoodsName;
        private Label Lb_ShipmentCntBefore2;
        private Label Lb_WarehouseShelfNo;
        private Label Lb_Customer;
        private Label Lb_Warehouse;
        private Label Lb_GoodsMaker;
        private Label Lb_BLGoodsCode;
        private Label Lb_MinimumStockCnt;
        private Label Lb_MaximumStockCnt;
        private Label Lb_ShipmentPosCnt;
        private Label Lb_StockCreateDate;
        private Label Lb_GoodsNo_Dm;
        private Label Lb_GoodsName_Dm;
        private Label Lb_GoodsMaker_Dm;
        private Label Lb_BLGoodsCode_Dm;
        private Label Lb_PartsManagementDivide2;
        private Label Lb_PartsManagementDivide1;
        private Label Lb_ShipmentCntBefore1;
        private Label Lb_GoodsNo;
        private Label Lb_ShipmentCnt;
        private GroupHeader WarehouseHeader;
        private GroupFooter WarehouseFooter;
        private GroupHeader SupplierHeader;
        private GroupFooter SupplierFooter;
        private GroupHeader WarehouseShelfNoHeader;
        private GroupFooter WarehouseShelfNoFooter;
        private TextBox CustomerCode;
        private TextBox GoodsName;
        private TextBox WarehouseShelfNo;
        private TextBox StockCreateDate;
        private TextBox MinimumStockCnt;
        private TextBox MaximumStockCnt;
        private TextBox GoodsNo;
        private TextBox CustomerName;
        private TextBox GoodsMakerCd;
        private TextBox MakerName;
        private TextBox BLGoodsCode;
        private TextBox ShipmentPosCnt;
        private TextBox GoodsNo_Dm;
        private TextBox GoodsName_Dm;
        private TextBox GoodsMakerCd_Dm;
        private TextBox MakerName_Dm;
        private TextBox BLGoodsCode_Dm;
        private TextBox PartsManagementDivide1;
        private TextBox PartsManagementDivide2;
        private TextBox ShipmentCnt;
        private TextBox ShipmentCntBefore1;
        private TextBox ShipmentCntBefore2;
        private TextBox ShipmentCntBefore3;
        private TextBox PartsManagementDivide1_Dm;
        private TextBox PartsManagementDivide2_Dm;
        private TextBox ShipmentCntBeforeTotal;
        private Line line2;
        private Line line3;
        private Line line5;
        private Label ALLTOTALTITLE;
        private TextBox Ttl_ShipmentPosCnt;
        private TextBox Ttl_ShipmentCnt;
        private TextBox Ttl_ShipmentCntBefore1;
        private TextBox Ttl_ShipmentCntBefore2;
        private TextBox Ttl_ShipmentCntBefore3;
        private TextBox Ttl_ShipmentCntBeforeTotal;
        private TextBox SECTOTALTITLE;
        private TextBox Wh_ShipmentPosCnt;
        private TextBox Wh_ShipmentCnt;
        private TextBox Wh_ShipmentCntBefore1;
        private TextBox Wh_ShipmentCntBefore2;
        private TextBox Wh_ShipmentCntBefore3;
        private TextBox Wh_ShipmentCntBeforeTotal;
        private TextBox TextBox3;
        private TextBox Sp_ShipmentPosCnt;
        private TextBox Sp_ShipmentCnt;
        private TextBox Sp_ShipmentCntBefore1;
        private TextBox Sp_ShipmentCntBefore2;
        private TextBox Sp_ShipmentCntBefore3;
        private TextBox Sp_ShipmentCntBeforeTotal;
        private TextBox TextBox20;
        private TextBox Ws_ShipmentPosCnt;
        private TextBox Ws_ShipmentCnt;
        private TextBox Ws_ShipmentCntBefore1;
        private TextBox Ws_ShipmentCntBefore2;
        private TextBox Ws_ShipmentCntBefore3;
        private TextBox Ws_ShipmentCntBeforeTotal;
        private TextBox Wh_WarehouseName;
        private TextBox Wh_WarehouseCode;
        private Line Line37;
        private Label Lb_PartsManagementDivide1_Dm;
        private Label Lb_PartsManagementDivide2_Dm;
        private Label Lb_WarehouseShelfNo_Dm;
        private Label Lb_Customer_Dm;
        private Label Lb_ShipmentCntBefore3;
        private Label Lb_ShipmentCntBeforeTotal;
        private TextBox WarehouseShelfNo_Dm;
        private TextBox CustomerCode_Dm;
        private TextBox CustomerName_Dm;
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
				this._extrInfo = (StockListCndtn)this._printInfo.jyoken;
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
		/// <summary>
		/// レポート要素出力設定
		/// </summary>
 		/// <remarks>
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{

            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////拠点オプションチェック
	        //if (this._extrInfo.IsOptSection)
			//{              
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if (this._extrInfo.DepositStockSecCodeList.Length <= 1)					
			//	{                
			//		SectionHeader.DataField = "";
            //        SectionHeader.Height = 0F;
            //        SectionFooter.Height = 0F;
			//		SectionHeader.Visible = false;
			//		SectionFooter.Visible = false;
			//	}
			//	else
			//	{					
            //        SectionHeader.DataField = MAZAI02074EA.ctCol_SectionCode;
            //        SectionHeader.Visible = true;
			//		SectionFooter.Visible = true;
			//	}
            //
			//}
			//else
			//{
			//	// 拠点無
			//	SectionHeader.DataField = "";
			//	SectionHeader.Visible = false;
			//	SectionFooter.Visible = false;          
			//}
            /* ---DEL 2009/03/26 不具合対応[12832] -------------------------------------------------->>>>>
            // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            if (this._extrInfo.DepositStockSecCodeList.Length <= 1)
            {
                SectionHeader.DataField = "";
                SectionHeader.Height = 0F;
                SectionFooter.Height = 0F;
                SectionHeader.Visible = false;
                SectionFooter.Visible = false;
            }
            else
            {
                SectionHeader.DataField = MAZAI02074EA.ctCol_SectionCode;
                SectionHeader.Visible = true;
                SectionFooter.Visible = true;
            }
               ---DEL 2009/03/26 不具合対応[12832] --------------------------------------------------<<<<< */
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

            //全社選択されている場合は拠点名称をを表示
            //--- DEL 2008/08/01 ---------->>>>>
            //if (this._extrInfo.DepositStockSecCodeList.Length == 0)
            //{
            //    this.SectionName_Title.Visible = true;
            //    this.SectionName_TextBox.Visible = true;
            //}
            //else
            //{
            //    this.SectionName_Title.Visible = false;
            //    this.SectionName_TextBox.Visible = false;
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            //ソート順が商品大分類・中分類別の時
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //if (this._extrInfo.ChangePageDiv == (int)StockListCndtn.PageChangeDiv.Sort_LargeMediumGoodsGanreCode)
            //--- DEL 2008/08/01 ---------->>>>>
            //if (this._extrInfo.ChangePageDiv == (int)StockListCndtn.PageChangeDiv.Sort_LargeGoodsGanreCode)
            //// 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //    ////ソート順１のヘッダ・フッタを表示
            //    //this.SortDiv1Header.Visible = true; 
            //    //this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_MediumGoodsGanreCode;
            //    //this.SortDiv1Footer.Visible = true; 
            //    ////ソート順２のヘッダ・フッタを表示
            //    //this.SortDiv2Header.Visible = true;
            //    //this.SortDiv2Header.DataField = MAZAI02074EA.ctCol_LargeGoodsGanreCode;
            //    //this.SortDiv2Footer.Visible = true;
            //    //this.Sort2Total_Title.Visible = true;
            //    //this.Sort1Total_Title.Text = StockListCndtn.GetSortTotalName((int)StockListCndtn.PageChangeDivTitle.Sort_MediumGoodsGanreTitle);         
            //    //this.Sort2Total_Title.Text = StockListCndtn.GetSortTotalName((int)StockListCndtn.PageChangeDivTitle.Sort_LargeGoodsGanreTitle);

            //    //ソート順１のヘッダ・フッタを表示
            //    this.SortDiv1Header.Visible = true;
            //    this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_DetailGoodsGanreCode;
            //    this.SortDiv1Footer.Visible = true;
            //    //ソート順２のヘッダ・フッタを表示
            //    this.SortDiv2Header.Visible = true;
            //    this.SortDiv2Header.DataField = MAZAI02074EA.ctCol_MediumGoodsGanreCode;
            //    this.SortDiv2Footer.Visible = true;
            //    //ソート順３のヘッダ・フッタを表示
            //    this.SortDiv3Header.Visible = true;
            //    this.SortDiv3Header.DataField = MAZAI02074EA.ctCol_LargeGoodsGanreCode;
            //    this.SortDiv3Footer.Visible = true;
            //    this.Sort2Total_Title.Visible = true;
            //    this.Sort3Total_Title.Visible = true;
            //    this.Sort1Total_Title.Text = StockListCndtn.GetSortTotalName((int)StockListCndtn.PageChangeDivTitle.Sort_DetailGoodsGanreTitle);
            //    this.Sort2Total_Title.Text = StockListCndtn.GetSortTotalName((int)StockListCndtn.PageChangeDivTitle.Sort_MediumGoodsGanreTitle);
            //    this.Sort3Total_Title.Text = StockListCndtn.GetSortTotalName((int)StockListCndtn.PageChangeDivTitle.Sort_LargeGoodsGanreTitle);
            //    // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            //}
            ////ソート順が出荷可能数の場合
            //else if(this._extrInfo.ChangePageDiv == (int)StockListCndtn.PageChangeDiv.Sort_ShipmentPosCnt)
            //{
            //    //ソート計１,２を非表示
            //    this.SortDiv1Header.Visible = false;
            //    this.SortDiv1Header.DataField = "";
            //    this.SortDiv1Footer.Visible = false;
            //    this.SortDiv2Header.Visible = false;
            //    this.SortDiv2Header.DataField = "";
            //    this.SortDiv2Footer.Visible = false;
            //    // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
            //    //ソート計３を非表示
            //    this.SortDiv3Header.Visible = false;
            //    this.SortDiv3Header.DataField = "";
            //    this.SortDiv3Footer.Visible = false;
            //    // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
            //}
            //else
            //{
            //    //ソート順１のヘッダ・フッタを表示
            //    this.SortDiv1Header.Visible = true; 
            //    this.SortDiv1Footer.Visible = true;
            //    //ソート順
            //    switch(this._extrInfo.ChangePageDiv)
            //    {
            //        //メーカー
            //        case (int)StockListCndtn.PageChangeDiv.Sort_MakerCode:
            //        {
            //            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //            //this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_MakerCode;
            //            this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_GoodsMakerCd;
            //            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            //            break;
            //        }
            //        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            //        ////キャリア
            //        //case (int)StockListCndtn.PageChangeDiv.Sort_CarrierCode:
            //        //{
            //        //    this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_CarrierCode;
            //        //    break;
            //        //}
            //        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
            //        //最終仕入日
            //        case (int)StockListCndtn.PageChangeDiv.Sort_StockDate:
            //        {
            //            this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_LastStockDate_sort;
            //            break;
            //        }
            //        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //        ////機種
            //        //case (int)StockListCndtn.PageChangeDiv.Sort_CellPhoneModeleCode:
            //        //{
            //        //    this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_CellphoneModelCode;
            //        //    break;
            //        //}

            //        //倉庫コード
            //        case (int)StockListCndtn.PageChangeDiv.Sort_WarehouseCode:
            //        {
            //            this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_WarehouseCode;
            //            break;
            //        }
            //        //自社分類
            //        case (int)StockListCndtn.PageChangeDiv.Sort_EnterpriseGanreCode:
            //        {
            //            this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_EnterpriseGanreCode;
            //            break;
            //        }
            //        //ＢＬ商品コード
            //        case (int)StockListCndtn.PageChangeDiv.Sort_BLGoodsCode:
            //        {
            //            this.SortDiv1Header.DataField = MAZAI02074EA.ctCol_BLGoodsCode;
            //            break;
            //        }
            //        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            //        //出荷可能数は計を出さないので必要なし
            //    }
            //    this.Sort1Total_Title.Text = StockListCndtn.GetSortTotalName(this._extrInfo.ChangePageDiv);   
            //    //ソート順２のヘッダ・フッタを消す
            //    this.SortDiv2Header.Visible = false;
            //    this.SortDiv2Header.DataField = "";
            //    this.SortDiv2Footer.Visible = false;
            //    // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
            //    //ソート順３のヘッダ・フッタを消す
            //    this.SortDiv3Header.Visible = false;
            //    this.SortDiv3Header.DataField = "";
            //    this.SortDiv3Footer.Visible = false;
            //    // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            //在庫全体管理設定読込(1:最終仕入原価法,2:移動平均法,3:個別単価法)
            //在庫評価方法が3:個別単価法の場合のみ在庫原単価を表示
            //--- DEL 2008/08/01 ---------->>>>>
            //if (this._extrInfo.StockPointWay != 3)
            //{
            //    this.StockUnitPrice_TextBox.Visible = true;
            //    this.StockUnitPrice_Title.Visible = true;
            //}
            //else
            //{
            //    this.StockUnitPrice_TextBox.Visible = false;
            //    this.StockUnitPrice_Title.Visible = false;
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            // 項目の名称をセット
			SortTitle.Text	= this._pageHeaderSortOderTitle;	// ソート条件    

            //--- ADD 2008/08/04 ---------->>>>>
            #region ＜＜　合計行の印字有無制御　＞＞
            /* ---DEL 2009/04/03 不具合対応[13000] -------------------------------------->>>>>
            SectionHeader.DataField = MAZAI02074EA.ctCol_Sort_SectionCode;
            SectionHeader.Visible = true;
            SectionFooter.Visible = true;
               ---DEL 2009/04/03 不具合対応[13000] --------------------------------------<<<<< */

            // 仕入先順・棚番順の選択　及び　小計印字区分の選択　により印字する合計行を選択
            GroupHeader activeHeader = null;
            GroupFooter activeFooter = null;

            // 初期化
            SupplierHeader.Visible = false;
            SupplierFooter.Visible = false;
            WarehouseShelfNoHeader.Visible = false;
            WarehouseShelfNoFooter.Visible = false;

            // 出力順
            if (this._extrInfo.ChangePageDiv == 0)
            {
                // 仕入先順
                activeHeader = SupplierHeader;
                activeFooter = SupplierFooter;
                //WarehouseHeader.DataField = string.Empty;               //ADD 2009/03/13 不具合対応[12371]　→　DEL 2009/03/24 不具合対応[12696]
                WarehouseShelfNoHeader.DataField = string.Empty;    //ADD 2009/03/24 不具合対応[12696]
            }
            else
            {
                // 棚番順
                activeHeader = WarehouseShelfNoHeader;
                activeFooter = WarehouseShelfNoFooter;
                SupplierHeader.DataField = string.Empty;                //ADD 2009/03/13 不具合対応[12371]
            }

            if (activeHeader != null)
            {
                activeHeader.Visible = true;

                // 改ページ区分
                if (this._extrInfo.NewPageDiv == StockListCndtn.NewPageDivState.EachSummaly)
                {
                    // 小計毎改ページする
                    this.WarehouseHeader.NewPage = NewPage.Before;      //ADD 2008/10/08
                    activeHeader.NewPage = NewPage.Before;
                }
                else
                {
                    // 小計毎改ページしない
                    this.WarehouseHeader.NewPage = NewPage.None;        //ADD 2008/10/08
                    activeHeader.NewPage = NewPage.None;
                }
            }
            if (activeFooter != null)
            {
                activeFooter.Visible = true;
            }

            #endregion ＜＜　合計行の印字有無制御　＞＞

            #region ＜＜　仕入先別・棚番別レイアウト制御　＞＞
            //------------------------------------------------------------------------
            // 作成時のデフォルトの配置は仕入先別のレイアウトになっています。
            // 「棚番順」が選択されている場合は、棚番別レイアウトに動的に組み替えます。
            // (ex. WarehouseShelfNo.Left ← WarehouseShelfNo_Dm.Leftをセット)
            //------------------------------------------------------------------------

            if (this._extrInfo.ChangePageDiv == 1)
            {
                /* --- DEL 2008/10/08 レイアウト変更の為 ------------------------------------>>>>>
                // タイトル項目
                Lb_GoodsMaker.Left = Lb_GoodsMaker_Dm.Left;         // メーカー
                Lb_BLGoodsCode.Left = Lb_BLGoodsCode_Dm.Left;       // BLコード
                Lb_GoodsNo.Left = Lb_GoodsNo_Dm.Left;               // 品番
                Lb_GoodsName.Left = Lb_GoodsName_Dm.Left;           // 品名

                //Lb_MinimumStockCnt.Left = Lb_MaximumStockCnt_Dm.Left;       // 最低数     //DEL 2008/10/08 「最低数」と「最高数」が重なる為
                Lb_MinimumStockCnt.Left = Lb_MinimumStockCnt_Dm.Left;       // 最低数       //ADD 2008/10/08
                Lb_MaximumStockCnt.Left = Lb_MaximumStockCnt_Dm.Left;       // 最高数
                Lb_ShipmentPosCnt.Left = Lb_ShipmentPosCnt_Dm.Left;         // 現在庫
                Lb_ShipmentCnt.Left = Lb_ShipmentCnt_Dm.Left;               // 当月出荷
                Lb_ShipmentCntBefore1.Left = Lb_ShipmentCntBefore1_Dm.Left; // １ヶ月前
                Lb_ShipmentCntBefore2.Left = Lb_ShipmentCntBefore2_Dm.Left; // ２ヶ月前
                Lb_ShipmentCntBefore3.Left = Lb_ShipmentCntBefore3_Dm.Left; // ３ヶ月前
                Lb_ShipmentCntBeforeTotal.Left = Lb_ShipmentCntBeforeTotal_Dm.Left; // ６ヶ月合計
                Lb_StockCreateDate.Left = Lb_StockCreateDate_Dm.Left;       // 登録日

                Lb_PartsManagementDivide1.Left = Lb_PartsManagementDivide1_Dm.Left;
                Lb_PartsManagementDivide2.Left = Lb_PartsManagementDivide2_Dm.Left;

                Lb_Customer.Top = Lb_MaximumStockCnt.Top;
                Lb_WarehouseShelfNo.Top = Lb_GoodsMaker.Top;

                // 明細項目
                GoodsMakerCd.Left = GoodsMakerCd_Dm.Left;               // メーカーコード
                MakerName.Left = MakerName_Dm.Left;                     // メーカー名称
                BLGoodsCode.Left = BLGoodsCode_Dm.Left;                 // BLコード
                GoodsNo.Left = GoodsNo_Dm.Left;                         // 品番
                GoodsName.Left = GoodsName_Dm.Left;                     // 品名

                MinimumStockCnt.Left = MinimumStockCnt_Dm.Left;         // 最低数
                MaximumStockCnt.Left = MaximumStockCnt_Dm.Left;         // 最高数
                ShipmentPosCnt.Left = ShipmentPosCnt_Dm.Left;           // 現在庫
                ShipmentCnt.Left = ShipmentCnt_Dm.Left;                 // 当月出荷
                ShipmentCntBefore1.Left = ShipmentCntBefore1_Dm.Left;   // １ヶ月前
                ShipmentCntBefore2.Left = ShipmentCntBefore2_Dm.Left;   // ２ヶ月前
                ShipmentCntBefore3.Left = ShipmentCntBefore3_Dm.Left;   // ３ヶ月前
                ShipmentCntBeforeTotal.Left = ShipmentCntBeforeTotal_Dm.Left;   // ６ヶ月合計
                StockCreateDate.Left = StockCreateDate_Dm.Left;         // 登録日

                PartsManagementDivide1.Left = PartsManagementDivide1_Dm.Left;
                PartsManagementDivide2.Left = PartsManagementDivide2_Dm.Left;

                CustomerCode.Top = MaximumStockCnt.Top;
                CustomerName.Top = MaximumStockCnt.Top;
                WarehouseShelfNo.Top = GoodsMakerCd.Top;

                Wh_ShipmentPosCnt.Left = Wh_ShipmentPosCnt_Dm.Left;
                Wh_ShipmentCnt.Left = Wh_ShipmentCnt_Dm.Left;
                Wh_ShipmentCntBefore1.Left = Wh_ShipmentCntBefore1_Dm.Left;
                Wh_ShipmentCntBefore2.Left = Wh_ShipmentCntBefore2_Dm.Left;
                Wh_ShipmentCntBefore3.Left = Wh_ShipmentCntBefore3_Dm.Left;
                Wh_ShipmentCntBeforeTotal.Left = Wh_ShipmentCntBeforeTotal_Dm.Left;

                Ttl_ShipmentPosCnt.Left = Ttl_ShipmentPosCnt_Dm.Left;
                Ttl_ShipmentCnt.Left = Ttl_ShipmentCnt_Dm.Left;
                Ttl_ShipmentCntBefore1.Left = Ttl_ShipmentCntBefore1_Dm.Left;
                Ttl_ShipmentCntBefore2.Left = Ttl_ShipmentCntBefore2_Dm.Left;
                Ttl_ShipmentCntBefore3.Left = Ttl_ShipmentCntBefore3_Dm.Left;
                Ttl_ShipmentCntBeforeTotal.Left = Ttl_ShipmentCntBeforeTotal_Dm.Left;
                   --- DEL 2008/10/08 -------------------------------------------------------<<<<< */
                // --- ADD 2008/10/08 ------------------------------------------------------->>>>>
                // ヘッダー
                Lb_WarehouseShelfNo.Left = Lb_WarehouseShelfNo_Dm.Left;                 // 棚番
                Lb_GoodsMaker.Left = Lb_GoodsMaker_Dm.Left;                             // メーカー
                //Lb_PartsManagementDivide.Left = Lb_PartsManagementDivide1_Dm.Left;      // "管区"ラベル           //DEL 2009/03/26 不具合対応[12832]
                Lb_PartsManagementDivide1.Left = Lb_PartsManagementDivide1_Dm.Left;     // 管理区分1
                Lb_PartsManagementDivide2.Left = Lb_PartsManagementDivide2_Dm.Left;     // 管理区分2
                Lb_BLGoodsCode.Left = Lb_BLGoodsCode_Dm.Left;                           // BLコード
                Lb_GoodsNo.Left = Lb_GoodsNo_Dm.Left;                                   // 品番
                Lb_GoodsName.Left = Lb_GoodsName_Dm.Left;                               // 品名
                Lb_Customer.Left = Lb_Customer_Dm.Left;                                 // 仕入先
                // 明細
                WarehouseShelfNo.Left = WarehouseShelfNo_Dm.Left;                       // 棚番
                GoodsMakerCd.Left = GoodsMakerCd_Dm.Left;                               // メーカーコード
                MakerName.Left = MakerName_Dm.Left;                                     // メーカー名称
                PartsManagementDivide1.Left = PartsManagementDivide1_Dm.Left;           // 管理区分1
                PartsManagementDivide2.Left = PartsManagementDivide2_Dm.Left;           // 管理区分2
                BLGoodsCode.Left = BLGoodsCode_Dm.Left;                                 // BLコード
                GoodsNo.Left = GoodsNo_Dm.Left;                                         // 品番
                GoodsName.Left = GoodsName_Dm.Left;                                     // 品名
                CustomerCode.Left = CustomerCode_Dm.Left;                               // 仕入先コード
                CustomerName.Left = CustomerName_Dm.Left;                               // 仕入先名称
                // --- ADD 2008/10/08 -------------------------------------------------------<<<<<
            }
            #endregion ＜＜　仕入先別・棚番別レイアウト制御　＞＞
            //--- ADD 2008/08/04 ----------<<<<<
		}
		#endregion

		/// <summary>
		/// Detail_BeforePrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
            // グループサプレスの判断
            this.CheckGroupSuppression();           //ADD 2008/10/08 

			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

            /* ---DEL 2009/03/25 不具合対応[12797] -------------------------->>>>>
            // --- ADD 2009/03/03 -------------------------------->>>>>
            // ゼロ値は表示しない
            if (string.IsNullOrEmpty(this.CustomerCode.Text)
                || this.CustomerCode.Text.PadLeft(6, '0') == "000000")
            {
                this.CustomerCode.Text = "";
                this.CustomerName.Text = "";
            }

            if (string.IsNullOrEmpty(this.GoodsMakerCd.Text)
                || this.GoodsMakerCd.Text.PadLeft(4, '0') == "0000")
            {
                this.GoodsMakerCd.Text = "";
                this.MakerName.Text = "";
            }

            if (string.IsNullOrEmpty(this.BLGoodsCode.Text)
                || this.BLGoodsCode.Text.PadLeft(5, '0') == "00000")
            {
                this.BLGoodsCode.Text = "";
            }
            // --- ADD 2009/03/03 --------------------------------<<<<<
               ---DEL 2009/03/25 不具合対応[12797] --------------------------<<<<< */
        }

        // --- ADD 2008/10/08 ----------------------------------------------------------------->>>>>
        /// <summary>
        /// グループサプレス判断
        /// </summary>
        private void CheckGroupSuppression()
        {
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。

            if (this._extrInfo.ChangePageDiv == 1)
            {
                // 棚番順
                //if (this.WarehouseShelfNo.Text == this._beforeCode)               //DEL 2009/04/03 不具合対応[12797]
                if (this.WarehouseShelfNo.Value.ToString() == this._beforeCode)     //ADD 2009/04/03 不具合対応[12797]
                {
                    this.WarehouseShelfNo.Visible = false;
                }
                else
                {
                    this.WarehouseShelfNo.Visible = true;
                }
                //this._beforeCode = this.WarehouseShelfNo.Text;                    //DEL 2009/04/03 不具合対応[12797]
                this._beforeCode = this.WarehouseShelfNo.Value.ToString();          //ADD 2009/04/03 不具合対応[12797]
            }
            else
            {
                // 仕入順
                //if (this.CustomerCode.Text == this._beforeCode)                   //DEL 2009/04/03 不具合対応[12797]
                if (this.CustomerCode.Value.ToString() == this._beforeCode)         //ADD 2009/04/03 不具合対応[12797]
                {
                    this.CustomerCode.Visible = false;
                    this.CustomerName.Visible = false;
                }
                else
                {
                    this.CustomerCode.Visible = true;
                    this.CustomerName.Visible = true;
                }
                //this._beforeCode = this.CustomerCode.Text;                        //DEL 2009/04/03 不具合対応[12797]
                this._beforeCode = this.CustomerCode.Value.ToString();              //ADD 2009/04/03 不具合対応[12797]
            }

        }

        private void WarehouseShelfNoFooter_AfterPrint(object sender, EventArgs e)
        {
            // 棚番順
            if (this._extrInfo.ChangePageDiv == 1)
            {
                // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
                this._beforeCode = string.Empty;
            }
        }

        private void SupplierFooter_AfterPrint(object sender, EventArgs e)
        {
            // 仕入先順
            if (this._extrInfo.ChangePageDiv != 1)
            {
                // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
                this._beforeCode = string.Empty;
            }
        }

        private void WarehouseFooter_AfterPrint(object sender, EventArgs e)
        {
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
            this._beforeCode = string.Empty;
        }
        // --- ADD 2008/10/08 -----------------------------------------------------------------<<<<<
        
        /// <summary>
		/// MAZAI02072P_02A4C_PageEndイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : １ページの出力が終了したときに発生するイベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private void MAZAI02072P_02A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
            this._beforeCode = string.Empty;        //ADD 2008/10/08
		}

		/// <summary>
		/// ExtraHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
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

            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //// 拠点オプション有無判定
            //if (this._extrInfo.IsOptSection)
            //{
            //	//全社選択のときは、固定で「全社」と設定する
            //    if (this._extrInfo.DepositStockSecCodeList.Length == 0)
            //	{
            //		this._rptExtraHeader.SectionCondition.Text = "在庫拠点： 全社";
            //	}
            //	else
            //	{
            //		this._rptExtraHeader.SectionCondition.Text = "在庫拠点： " + this.StockSectionName.Text;
            //	}
            //} 
            //else 
            //{
            //	this._rptExtraHeader.SectionCondition.Text = "";
            //}
            //全社選択のときは、固定で「全社」と設定する
            //--- DEL 2008/08/01 ---------->>>>>
            //if (this._extrInfo.DepositStockSecCodeList.Length == 0)
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "在庫拠点： 全社";
            //}
            //else
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "在庫拠点： " + this.StockSectionName.Text;
            //}
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ----------<<<<<

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions         = this._extraConditions;

			this.Header_SubReport.Report = this._rptExtraHeader;
		}

		/// <summary>
		/// PageFooter_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2009.03.17 30413 犬飼 フッター部の印字変更 >>>>>>START
            // 2008.01.24 削除 >>>>>>>>>>>>>>>>>>>>
            //// フッター出力する？
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
            // 2008.01.24 削除 <<<<<<<<<<<<<<<<<<<<
            // 2009.03.17 30413 犬飼 フッター部の印字変更 <<<<<<END
        }

		/// <summary>
		/// MAZAI02072P_02A4C_ReportStartイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : MAZAI02072P_02A4C_ReportStartの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private void MAZAI02072P_02A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();
		}

		/// <summary>
		/// PageHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
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

		/// <summary>
		/// 明細アフタープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 23010　中村　仁</br>
		/// <br>Date        : 2005.11.26</br>
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

        // --- ADD 2009/03/03 -------------------------------->>>>>
        /// <summary>
        /// WarehouseHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader_BeforePrint(object sender, EventArgs e)
        {
            /* ---DEL 2009/03/25 不具合対応[12797] -------------------------->>>>>
            // ゼロ値は表示しない
            if (string.IsNullOrEmpty(this.Wh_WarehouseCode.Text)
                || this.Wh_WarehouseCode.Text.PadLeft(4, '0') == "0000")
            {
                this.Wh_WarehouseCode.Text = "";
                this.Wh_WarehouseName.Text = "";
            }
               ---DEL 2009/03/25 不具合対応[12797] --------------------------<<<<< */
        }
        // --- ADD 2009/03/03 --------------------------------<<<<<

        // ---ADD 2009/04/03 不具合対応[12797]-------------------------------->>>>>
        private void TitleHeader_AfterPrint(object sender, EventArgs e)
        {
            this._beforeCode = string.Empty;
        }
        // ---ADD 2009/04/03 不具合対応[12797]--------------------------------<<<<<


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
        private DataDynamics.ActiveReports.Line Line4;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02072P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.StockCreateDate = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo_Dm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd_Dm = new DataDynamics.ActiveReports.TextBox();
            this.MakerName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.PartsManagementDivide1 = new DataDynamics.ActiveReports.TextBox();
            this.PartsManagementDivide2 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCntBefore1 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCntBefore2 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCntBefore3 = new DataDynamics.ActiveReports.TextBox();
            this.PartsManagementDivide1_Dm = new DataDynamics.ActiveReports.TextBox();
            this.PartsManagementDivide2_Dm = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCntBeforeTotal = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_Dm = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
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
            this.Lb_Warehouse = new DataDynamics.ActiveReports.Label();
            this.Lb_MaximumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCntBefore2 = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseShelfNo = new DataDynamics.ActiveReports.Label();
            this.Lb_Customer = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMaker = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode = new DataDynamics.ActiveReports.Label();
            this.Lb_MinimumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentPosCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_StockCreateDate = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMaker_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_PartsManagementDivide2 = new DataDynamics.ActiveReports.Label();
            this.Lb_PartsManagementDivide1 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCntBefore1 = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCntBefore3 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCntBeforeTotal = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_PartsManagementDivide1_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_PartsManagementDivide2_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseShelfNo_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_Customer_Dm = new DataDynamics.ActiveReports.Label();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Ttl_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCntBefore1 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCntBefore2 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCntBefore3 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCntBeforeTotal = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Wh_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.Wh_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCntBefore1 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCntBefore2 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCntBefore3 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCntBeforeTotal = new DataDynamics.ActiveReports.TextBox();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.Sp_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sp_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sp_ShipmentCntBefore1 = new DataDynamics.ActiveReports.TextBox();
            this.Sp_ShipmentCntBefore2 = new DataDynamics.ActiveReports.TextBox();
            this.Sp_ShipmentCntBefore3 = new DataDynamics.ActiveReports.TextBox();
            this.Sp_ShipmentCntBeforeTotal = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNoHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseShelfNoFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.Ws_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ws_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ws_ShipmentCntBefore1 = new DataDynamics.ActiveReports.TextBox();
            this.Ws_ShipmentCntBefore2 = new DataDynamics.ActiveReports.TextBox();
            this.Ws_ShipmentCntBefore3 = new DataDynamics.ActiveReports.TextBox();
            this.Ws_ShipmentCntBeforeTotal = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBefore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBefore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBefore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide1_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide2_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBeforeTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBefore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBefore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBefore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBeforeTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide1_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide2_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBefore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBefore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBefore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBeforeTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBefore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBefore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBefore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBeforeTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBefore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBefore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBefore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBeforeTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBefore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBefore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBefore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBeforeTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CustomerCode,
            this.GoodsName,
            this.WarehouseShelfNo,
            this.StockCreateDate,
            this.MinimumStockCnt,
            this.MaximumStockCnt,
            this.GoodsNo,
            this.CustomerName,
            this.GoodsMakerCd,
            this.MakerName,
            this.BLGoodsCode,
            this.ShipmentPosCnt,
            this.GoodsNo_Dm,
            this.GoodsName_Dm,
            this.GoodsMakerCd_Dm,
            this.MakerName_Dm,
            this.BLGoodsCode_Dm,
            this.PartsManagementDivide1,
            this.PartsManagementDivide2,
            this.ShipmentCnt,
            this.ShipmentCntBefore1,
            this.ShipmentCntBefore2,
            this.ShipmentCntBefore3,
            this.PartsManagementDivide1_Dm,
            this.PartsManagementDivide2_Dm,
            this.ShipmentCntBeforeTotal,
            this.WarehouseShelfNo_Dm,
            this.CustomerCode_Dm,
            this.CustomerName_Dm,
            this.line6});
            this.Detail.Height = 0.3229167F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.CustomerCode.DataField = "StockSupplierCode";
            this.CustomerCode.Height = 0.125F;
            this.CustomerCode.Left = 0F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CustomerCode.Text = "123456";
            this.CustomerCode.Top = 0F;
            this.CustomerCode.Width = 0.375F;
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
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 3.72F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.19F;
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
            this.WarehouseShelfNo.Height = 0.125F;
            this.WarehouseShelfNo.Left = 4.89F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0F;
            this.WarehouseShelfNo.Width = 0.5F;
            // 
            // StockCreateDate
            // 
            this.StockCreateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.RightColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.TopColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.DataField = "StockCreateDate";
            this.StockCreateDate.Height = 0.125F;
            this.StockCreateDate.Left = 10.15F;
            this.StockCreateDate.MultiLine = false;
            this.StockCreateDate.Name = "StockCreateDate";
            this.StockCreateDate.OutputFormat = resources.GetString("StockCreateDate.OutputFormat");
            this.StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.StockCreateDate.Text = "9999/99/99";
            this.StockCreateDate.Top = 0F;
            this.StockCreateDate.Width = 0.625F;
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
            this.MinimumStockCnt.Height = 0.125F;
            this.MinimumStockCnt.Left = 5.28F;
            this.MinimumStockCnt.MultiLine = false;
            this.MinimumStockCnt.Name = "MinimumStockCnt";
            this.MinimumStockCnt.OutputFormat = resources.GetString("MinimumStockCnt.OutputFormat");
            this.MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MinimumStockCnt.Text = "12,345,678";
            this.MinimumStockCnt.Top = 0F;
            this.MinimumStockCnt.Width = 0.625F;
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
            this.MaximumStockCnt.Height = 0.125F;
            this.MaximumStockCnt.Left = 5.83F;
            this.MaximumStockCnt.MultiLine = false;
            this.MaximumStockCnt.Name = "MaximumStockCnt";
            this.MaximumStockCnt.OutputFormat = resources.GetString("MaximumStockCnt.OutputFormat");
            this.MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MaximumStockCnt.Text = "12,345,678";
            this.MaximumStockCnt.Top = 0F;
            this.MaximumStockCnt.Width = 0.625F;
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
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 2.33F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.38F;
            // 
            // CustomerName
            // 
            this.CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.DataField = "SupplierSnm";
            this.CustomerName.Height = 0.125F;
            this.CustomerName.Left = 0.34F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OutputFormat = resources.GetString("CustomerName.OutputFormat");
            this.CustomerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerName.Text = "あいうえお";
            this.CustomerName.Top = 0F;
            this.CustomerName.Width = 0.625F;
            // 
            // GoodsMakerCd
            // 
            this.GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.DataField = "GoodsMakerCd";
            this.GoodsMakerCd.Height = 0.125F;
            this.GoodsMakerCd.Left = 0.91F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0F;
            this.GoodsMakerCd.Width = 0.25F;
            // 
            // MakerName
            // 
            this.MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.DataField = "MakerName";
            this.MakerName.Height = 0.125F;
            this.MakerName.Left = 1.15F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "あいうえお";
            this.MakerName.Top = 0F;
            this.MakerName.Width = 0.625F;
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
            this.BLGoodsCode.DataField = "BLGoodsCode";
            this.BLGoodsCode.Height = 0.125F;
            this.BLGoodsCode.Left = 1.99F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0F;
            this.BLGoodsCode.Width = 0.3125F;
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
            this.ShipmentPosCnt.Height = 0.125F;
            this.ShipmentPosCnt.Left = 6.4F;
            this.ShipmentPosCnt.MultiLine = false;
            this.ShipmentPosCnt.Name = "ShipmentPosCnt";
            this.ShipmentPosCnt.OutputFormat = resources.GetString("ShipmentPosCnt.OutputFormat");
            this.ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentPosCnt.Text = "12,345,678";
            this.ShipmentPosCnt.Top = 0F;
            this.ShipmentPosCnt.Width = 0.625F;
            // 
            // GoodsNo_Dm
            // 
            this.GoodsNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.DataField = "GoodsNo";
            this.GoodsNo_Dm.Height = 0.125F;
            this.GoodsNo_Dm.Left = 1.91F;
            this.GoodsNo_Dm.MultiLine = false;
            this.GoodsNo_Dm.Name = "GoodsNo_Dm";
            this.GoodsNo_Dm.OutputFormat = resources.GetString("GoodsNo_Dm.OutputFormat");
            this.GoodsNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.GoodsNo_Dm.Text = "123456789012345678901234";
            this.GoodsNo_Dm.Top = 0.1875F;
            this.GoodsNo_Dm.Visible = false;
            this.GoodsNo_Dm.Width = 1.38F;
            // 
            // GoodsName_Dm
            // 
            this.GoodsName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.DataField = "GoodsName";
            this.GoodsName_Dm.Height = 0.125F;
            this.GoodsName_Dm.Left = 3.3F;
            this.GoodsName_Dm.MultiLine = false;
            this.GoodsName_Dm.Name = "GoodsName_Dm";
            this.GoodsName_Dm.OutputFormat = resources.GetString("GoodsName_Dm.OutputFormat");
            this.GoodsName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.GoodsName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.GoodsName_Dm.Text = "12345678901234567890";
            this.GoodsName_Dm.Top = 0.1875F;
            this.GoodsName_Dm.Visible = false;
            this.GoodsName_Dm.Width = 1.188F;
            // 
            // GoodsMakerCd_Dm
            // 
            this.GoodsMakerCd_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.DataField = "GoodsMakerCd";
            this.GoodsMakerCd_Dm.Height = 0.125F;
            this.GoodsMakerCd_Dm.Left = 0.49F;
            this.GoodsMakerCd_Dm.MultiLine = false;
            this.GoodsMakerCd_Dm.Name = "GoodsMakerCd_Dm";
            this.GoodsMakerCd_Dm.OutputFormat = resources.GetString("GoodsMakerCd_Dm.OutputFormat");
            this.GoodsMakerCd_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family:" +
                " ＭＳ 明朝; vertical-align: top; ";
            this.GoodsMakerCd_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.GoodsMakerCd_Dm.Text = "1234";
            this.GoodsMakerCd_Dm.Top = 0.1875F;
            this.GoodsMakerCd_Dm.Visible = false;
            this.GoodsMakerCd_Dm.Width = 0.25F;
            // 
            // MakerName_Dm
            // 
            this.MakerName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.DataField = "MakerName";
            this.MakerName_Dm.Height = 0.125F;
            this.MakerName_Dm.Left = 0.73F;
            this.MakerName_Dm.MultiLine = false;
            this.MakerName_Dm.Name = "MakerName_Dm";
            this.MakerName_Dm.OutputFormat = resources.GetString("MakerName_Dm.OutputFormat");
            this.MakerName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.MakerName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.MakerName_Dm.Text = "あいうえお";
            this.MakerName_Dm.Top = 0.1875F;
            this.MakerName_Dm.Visible = false;
            this.MakerName_Dm.Width = 0.625F;
            // 
            // BLGoodsCode_Dm
            // 
            this.BLGoodsCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.DataField = "BLGoodsCode";
            this.BLGoodsCode_Dm.Height = 0.125F;
            this.BLGoodsCode_Dm.Left = 1.57F;
            this.BLGoodsCode_Dm.MultiLine = false;
            this.BLGoodsCode_Dm.Name = "BLGoodsCode_Dm";
            this.BLGoodsCode_Dm.OutputFormat = resources.GetString("BLGoodsCode_Dm.OutputFormat");
            this.BLGoodsCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family:" +
                " ＭＳ 明朝; vertical-align: top; ";
            this.BLGoodsCode_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.BLGoodsCode_Dm.Text = "12345";
            this.BLGoodsCode_Dm.Top = 0.1875F;
            this.BLGoodsCode_Dm.Visible = false;
            this.BLGoodsCode_Dm.Width = 0.313F;
            // 
            // PartsManagementDivide1
            // 
            this.PartsManagementDivide1.Border.BottomColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1.Border.LeftColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1.Border.RightColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1.Border.TopColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1.DataField = "PartsManagementDivide1";
            this.PartsManagementDivide1.Height = 0.125F;
            this.PartsManagementDivide1.Left = 1.78F;
            this.PartsManagementDivide1.MultiLine = false;
            this.PartsManagementDivide1.Name = "PartsManagementDivide1";
            this.PartsManagementDivide1.OutputFormat = resources.GetString("PartsManagementDivide1.OutputFormat");
            this.PartsManagementDivide1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PartsManagementDivide1.Text = "1";
            this.PartsManagementDivide1.Top = 0F;
            this.PartsManagementDivide1.Width = 0.125F;
            // 
            // PartsManagementDivide2
            // 
            this.PartsManagementDivide2.Border.BottomColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2.Border.LeftColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2.Border.RightColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2.Border.TopColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2.DataField = "PartsManagementDivide2";
            this.PartsManagementDivide2.Height = 0.125F;
            this.PartsManagementDivide2.Left = 1.875F;
            this.PartsManagementDivide2.MultiLine = false;
            this.PartsManagementDivide2.Name = "PartsManagementDivide2";
            this.PartsManagementDivide2.OutputFormat = resources.GetString("PartsManagementDivide2.OutputFormat");
            this.PartsManagementDivide2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PartsManagementDivide2.Text = "1";
            this.PartsManagementDivide2.Top = 0F;
            this.PartsManagementDivide2.Width = 0.125F;
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
            this.ShipmentCnt.DataField = "ShipmentPrice";
            this.ShipmentCnt.Height = 0.125F;
            this.ShipmentCnt.Left = 6.97F;
            this.ShipmentCnt.MultiLine = false;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt.Text = "123,456,789";
            this.ShipmentCnt.Top = 0F;
            this.ShipmentCnt.Width = 0.6875F;
            // 
            // ShipmentCntBefore1
            // 
            this.ShipmentCntBefore1.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore1.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore1.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore1.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore1.DataField = "ShipmentPriceBefore1";
            this.ShipmentCntBefore1.Height = 0.125F;
            this.ShipmentCntBefore1.Left = 7.59F;
            this.ShipmentCntBefore1.MultiLine = false;
            this.ShipmentCntBefore1.Name = "ShipmentCntBefore1";
            this.ShipmentCntBefore1.OutputFormat = resources.GetString("ShipmentCntBefore1.OutputFormat");
            this.ShipmentCntBefore1.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCntBefore1.Text = "123,456,789";
            this.ShipmentCntBefore1.Top = 0F;
            this.ShipmentCntBefore1.Width = 0.6875F;
            // 
            // ShipmentCntBefore2
            // 
            this.ShipmentCntBefore2.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore2.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore2.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore2.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore2.DataField = "ShipmentPriceBefore2";
            this.ShipmentCntBefore2.Height = 0.125F;
            this.ShipmentCntBefore2.Left = 8.22F;
            this.ShipmentCntBefore2.MultiLine = false;
            this.ShipmentCntBefore2.Name = "ShipmentCntBefore2";
            this.ShipmentCntBefore2.OutputFormat = resources.GetString("ShipmentCntBefore2.OutputFormat");
            this.ShipmentCntBefore2.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCntBefore2.Text = "123,456,789";
            this.ShipmentCntBefore2.Top = 0F;
            this.ShipmentCntBefore2.Width = 0.6875F;
            // 
            // ShipmentCntBefore3
            // 
            this.ShipmentCntBefore3.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore3.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore3.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore3.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCntBefore3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBefore3.DataField = "ShipmentPriceBefore3";
            this.ShipmentCntBefore3.Height = 0.125F;
            this.ShipmentCntBefore3.Left = 8.84F;
            this.ShipmentCntBefore3.MultiLine = false;
            this.ShipmentCntBefore3.Name = "ShipmentCntBefore3";
            this.ShipmentCntBefore3.OutputFormat = resources.GetString("ShipmentCntBefore3.OutputFormat");
            this.ShipmentCntBefore3.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCntBefore3.Text = "123,456,789";
            this.ShipmentCntBefore3.Top = 0F;
            this.ShipmentCntBefore3.Width = 0.6875F;
            // 
            // PartsManagementDivide1_Dm
            // 
            this.PartsManagementDivide1_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.PartsManagementDivide1_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide1_Dm.DataField = "WarehouseShelfNo";
            this.PartsManagementDivide1_Dm.Height = 0.125F;
            this.PartsManagementDivide1_Dm.Left = 1.36F;
            this.PartsManagementDivide1_Dm.MultiLine = false;
            this.PartsManagementDivide1_Dm.Name = "PartsManagementDivide1_Dm";
            this.PartsManagementDivide1_Dm.OutputFormat = resources.GetString("PartsManagementDivide1_Dm.OutputFormat");
            this.PartsManagementDivide1_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.PartsManagementDivide1_Dm.Text = "1";
            this.PartsManagementDivide1_Dm.Top = 0.1875F;
            this.PartsManagementDivide1_Dm.Visible = false;
            this.PartsManagementDivide1_Dm.Width = 0.125F;
            // 
            // PartsManagementDivide2_Dm
            // 
            this.PartsManagementDivide2_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.PartsManagementDivide2_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsManagementDivide2_Dm.DataField = "WarehouseShelfNo";
            this.PartsManagementDivide2_Dm.Height = 0.125F;
            this.PartsManagementDivide2_Dm.Left = 1.46F;
            this.PartsManagementDivide2_Dm.MultiLine = false;
            this.PartsManagementDivide2_Dm.Name = "PartsManagementDivide2_Dm";
            this.PartsManagementDivide2_Dm.OutputFormat = resources.GetString("PartsManagementDivide2_Dm.OutputFormat");
            this.PartsManagementDivide2_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.PartsManagementDivide2_Dm.Text = "1";
            this.PartsManagementDivide2_Dm.Top = 0.1875F;
            this.PartsManagementDivide2_Dm.Visible = false;
            this.PartsManagementDivide2_Dm.Width = 0.125F;
            // 
            // ShipmentCntBeforeTotal
            // 
            this.ShipmentCntBeforeTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCntBeforeTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBeforeTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCntBeforeTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBeforeTotal.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCntBeforeTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBeforeTotal.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCntBeforeTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntBeforeTotal.DataField = "ShipmentPriceBeforeTotal";
            this.ShipmentCntBeforeTotal.Height = 0.125F;
            this.ShipmentCntBeforeTotal.Left = 9.47F;
            this.ShipmentCntBeforeTotal.MultiLine = false;
            this.ShipmentCntBeforeTotal.Name = "ShipmentCntBeforeTotal";
            this.ShipmentCntBeforeTotal.OutputFormat = resources.GetString("ShipmentCntBeforeTotal.OutputFormat");
            this.ShipmentCntBeforeTotal.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCntBeforeTotal.Text = "123,456,789";
            this.ShipmentCntBeforeTotal.Top = 0F;
            this.ShipmentCntBeforeTotal.Width = 0.6875F;
            // 
            // WarehouseShelfNo_Dm
            // 
            this.WarehouseShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo_Dm.Height = 0.125F;
            this.WarehouseShelfNo_Dm.Left = 0F;
            this.WarehouseShelfNo_Dm.MultiLine = false;
            this.WarehouseShelfNo_Dm.Name = "WarehouseShelfNo_Dm";
            this.WarehouseShelfNo_Dm.OutputFormat = resources.GetString("WarehouseShelfNo_Dm.OutputFormat");
            this.WarehouseShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseShelfNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.WarehouseShelfNo_Dm.Text = "12345678";
            this.WarehouseShelfNo_Dm.Top = 0.1875F;
            this.WarehouseShelfNo_Dm.Visible = false;
            this.WarehouseShelfNo_Dm.Width = 0.5F;
            // 
            // CustomerCode_Dm
            // 
            this.CustomerCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.DataField = "CustomerCode";
            this.CustomerCode_Dm.Height = 0.125F;
            this.CustomerCode_Dm.Left = 4.47F;
            this.CustomerCode_Dm.MultiLine = false;
            this.CustomerCode_Dm.Name = "CustomerCode_Dm";
            this.CustomerCode_Dm.OutputFormat = resources.GetString("CustomerCode_Dm.OutputFormat");
            this.CustomerCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.CustomerCode_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.CustomerCode_Dm.Text = "123456";
            this.CustomerCode_Dm.Top = 0.1875F;
            this.CustomerCode_Dm.Visible = false;
            this.CustomerCode_Dm.Width = 0.375F;
            // 
            // CustomerName_Dm
            // 
            this.CustomerName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.DataField = "CustomerName";
            this.CustomerName_Dm.Height = 0.125F;
            this.CustomerName_Dm.Left = 4.81F;
            this.CustomerName_Dm.MultiLine = false;
            this.CustomerName_Dm.Name = "CustomerName_Dm";
            this.CustomerName_Dm.OutputFormat = resources.GetString("CustomerName_Dm.OutputFormat");
            this.CustomerName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.CustomerName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.CustomerName_Dm.Text = "あいうえお";
            this.CustomerName_Dm.Top = 0.1875F;
            this.CustomerName_Dm.Visible = false;
            this.CustomerName_Dm.Width = 0.625F;
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
            this.line6.Top = 0F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
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
            this.Label1.Text = "在庫一覧表(金額)";
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
            this.SortTitle.Height = 0.15625F;
            this.SortTitle.Left = 2.325F;
            this.SortTitle.MultiLine = false;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.SortTitle.Text = "[ソート条件]";
            this.SortTitle.Top = 0.0625F;
            this.SortTitle.Width = 2.1875F;
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
            this.Lb_Warehouse,
            this.Lb_MaximumStockCnt,
            this.Lb_GoodsName,
            this.Lb_ShipmentCntBefore2,
            this.Lb_WarehouseShelfNo,
            this.Lb_Customer,
            this.Lb_GoodsMaker,
            this.Lb_BLGoodsCode,
            this.Lb_MinimumStockCnt,
            this.Lb_ShipmentPosCnt,
            this.Lb_StockCreateDate,
            this.Lb_GoodsNo_Dm,
            this.Lb_GoodsName_Dm,
            this.Lb_GoodsMaker_Dm,
            this.Lb_BLGoodsCode_Dm,
            this.Lb_PartsManagementDivide2,
            this.Lb_PartsManagementDivide1,
            this.Lb_ShipmentCntBefore1,
            this.Lb_GoodsNo,
            this.Lb_ShipmentCntBefore3,
            this.Lb_ShipmentCntBeforeTotal,
            this.Lb_ShipmentCnt,
            this.Lb_PartsManagementDivide1_Dm,
            this.Lb_PartsManagementDivide2_Dm,
            this.Lb_WarehouseShelfNo_Dm,
            this.Lb_Customer_Dm,
            this.Line4});
            this.TitleHeader.Height = 0.4583333F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.AfterPrint += new System.EventHandler(this.TitleHeader_AfterPrint);
            // 
            // Lb_Warehouse
            // 
            this.Lb_Warehouse.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Height = 0.125F;
            this.Lb_Warehouse.HyperLink = "";
            this.Lb_Warehouse.Left = 0F;
            this.Lb_Warehouse.MultiLine = false;
            this.Lb_Warehouse.Name = "Lb_Warehouse";
            this.Lb_Warehouse.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Warehouse.Text = "倉庫";
            this.Lb_Warehouse.Top = 0F;
            this.Lb_Warehouse.Width = 0.3125F;
            // 
            // Lb_MaximumStockCnt
            // 
            this.Lb_MaximumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Height = 0.125F;
            this.Lb_MaximumStockCnt.HyperLink = "";
            this.Lb_MaximumStockCnt.Left = 5.83F;
            this.Lb_MaximumStockCnt.MultiLine = false;
            this.Lb_MaximumStockCnt.Name = "Lb_MaximumStockCnt";
            this.Lb_MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MaximumStockCnt.Text = "最高数";
            this.Lb_MaximumStockCnt.Top = 0.125F;
            this.Lb_MaximumStockCnt.Width = 0.625F;
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
            this.Lb_GoodsName.Height = 0.125F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 3.72F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.125F;
            this.Lb_GoodsName.Width = 0.3125F;
            // 
            // Lb_ShipmentCntBefore2
            // 
            this.Lb_ShipmentCntBefore2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore2.Height = 0.125F;
            this.Lb_ShipmentCntBefore2.HyperLink = "";
            this.Lb_ShipmentCntBefore2.Left = 8.2825F;
            this.Lb_ShipmentCntBefore2.MultiLine = false;
            this.Lb_ShipmentCntBefore2.Name = "Lb_ShipmentCntBefore2";
            this.Lb_ShipmentCntBefore2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCntBefore2.Text = "２ヶ月前";
            this.Lb_ShipmentCntBefore2.Top = 0.125F;
            this.Lb_ShipmentCntBefore2.Width = 0.625F;
            // 
            // Lb_WarehouseShelfNo
            // 
            this.Lb_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Height = 0.125F;
            this.Lb_WarehouseShelfNo.HyperLink = "";
            this.Lb_WarehouseShelfNo.Left = 4.89F;
            this.Lb_WarehouseShelfNo.MultiLine = false;
            this.Lb_WarehouseShelfNo.Name = "Lb_WarehouseShelfNo";
            this.Lb_WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo.Text = "棚番";
            this.Lb_WarehouseShelfNo.Top = 0.125F;
            this.Lb_WarehouseShelfNo.Width = 0.3125F;
            // 
            // Lb_Customer
            // 
            this.Lb_Customer.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Height = 0.125F;
            this.Lb_Customer.HyperLink = "";
            this.Lb_Customer.Left = 0F;
            this.Lb_Customer.MultiLine = false;
            this.Lb_Customer.Name = "Lb_Customer";
            this.Lb_Customer.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Customer.Text = "仕入先";
            this.Lb_Customer.Top = 0.125F;
            this.Lb_Customer.Width = 0.375F;
            // 
            // Lb_GoodsMaker
            // 
            this.Lb_GoodsMaker.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Height = 0.125F;
            this.Lb_GoodsMaker.HyperLink = "";
            this.Lb_GoodsMaker.Left = 0.91F;
            this.Lb_GoodsMaker.MultiLine = false;
            this.Lb_GoodsMaker.Name = "Lb_GoodsMaker";
            this.Lb_GoodsMaker.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMaker.Text = "メーカー";
            this.Lb_GoodsMaker.Top = 0.125F;
            this.Lb_GoodsMaker.Width = 0.5625F;
            // 
            // Lb_BLGoodsCode
            // 
            this.Lb_BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Height = 0.125F;
            this.Lb_BLGoodsCode.HyperLink = "";
            this.Lb_BLGoodsCode.Left = 1.99F;
            this.Lb_BLGoodsCode.MultiLine = false;
            this.Lb_BLGoodsCode.Name = "Lb_BLGoodsCode";
            this.Lb_BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode.Text = "BLCD";
            this.Lb_BLGoodsCode.Top = 0.125F;
            this.Lb_BLGoodsCode.Width = 0.3125F;
            // 
            // Lb_MinimumStockCnt
            // 
            this.Lb_MinimumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Height = 0.125F;
            this.Lb_MinimumStockCnt.HyperLink = "";
            this.Lb_MinimumStockCnt.Left = 5.28F;
            this.Lb_MinimumStockCnt.MultiLine = false;
            this.Lb_MinimumStockCnt.Name = "Lb_MinimumStockCnt";
            this.Lb_MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MinimumStockCnt.Text = "最低数";
            this.Lb_MinimumStockCnt.Top = 0.125F;
            this.Lb_MinimumStockCnt.Width = 0.625F;
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
            this.Lb_ShipmentPosCnt.Height = 0.125F;
            this.Lb_ShipmentPosCnt.HyperLink = "";
            this.Lb_ShipmentPosCnt.Left = 6.4625F;
            this.Lb_ShipmentPosCnt.MultiLine = false;
            this.Lb_ShipmentPosCnt.Name = "Lb_ShipmentPosCnt";
            this.Lb_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentPosCnt.Text = "現在庫数";
            this.Lb_ShipmentPosCnt.Top = 0.125F;
            this.Lb_ShipmentPosCnt.Width = 0.5625F;
            // 
            // Lb_StockCreateDate
            // 
            this.Lb_StockCreateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Height = 0.125F;
            this.Lb_StockCreateDate.HyperLink = "";
            this.Lb_StockCreateDate.Left = 10.15F;
            this.Lb_StockCreateDate.MultiLine = false;
            this.Lb_StockCreateDate.Name = "Lb_StockCreateDate";
            this.Lb_StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockCreateDate.Text = "登録日";
            this.Lb_StockCreateDate.Top = 0.125F;
            this.Lb_StockCreateDate.Width = 0.5F;
            // 
            // Lb_GoodsNo_Dm
            // 
            this.Lb_GoodsNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Height = 0.125F;
            this.Lb_GoodsNo_Dm.HyperLink = "";
            this.Lb_GoodsNo_Dm.Left = 1.91F;
            this.Lb_GoodsNo_Dm.MultiLine = false;
            this.Lb_GoodsNo_Dm.Name = "Lb_GoodsNo_Dm";
            this.Lb_GoodsNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_GoodsNo_Dm.Text = "品番";
            this.Lb_GoodsNo_Dm.Top = 0.3125F;
            this.Lb_GoodsNo_Dm.Visible = false;
            this.Lb_GoodsNo_Dm.Width = 0.3125F;
            // 
            // Lb_GoodsName_Dm
            // 
            this.Lb_GoodsName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Height = 0.125F;
            this.Lb_GoodsName_Dm.HyperLink = "";
            this.Lb_GoodsName_Dm.Left = 3.3F;
            this.Lb_GoodsName_Dm.MultiLine = false;
            this.Lb_GoodsName_Dm.Name = "Lb_GoodsName_Dm";
            this.Lb_GoodsName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_GoodsName_Dm.Text = "品名";
            this.Lb_GoodsName_Dm.Top = 0.3125F;
            this.Lb_GoodsName_Dm.Visible = false;
            this.Lb_GoodsName_Dm.Width = 0.3125F;
            // 
            // Lb_GoodsMaker_Dm
            // 
            this.Lb_GoodsMaker_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Height = 0.125F;
            this.Lb_GoodsMaker_Dm.HyperLink = "";
            this.Lb_GoodsMaker_Dm.Left = 0.49F;
            this.Lb_GoodsMaker_Dm.MultiLine = false;
            this.Lb_GoodsMaker_Dm.Name = "Lb_GoodsMaker_Dm";
            this.Lb_GoodsMaker_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMaker_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_GoodsMaker_Dm.Text = "メーカー";
            this.Lb_GoodsMaker_Dm.Top = 0.3125F;
            this.Lb_GoodsMaker_Dm.Visible = false;
            this.Lb_GoodsMaker_Dm.Width = 0.5F;
            // 
            // Lb_BLGoodsCode_Dm
            // 
            this.Lb_BLGoodsCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Height = 0.125F;
            this.Lb_BLGoodsCode_Dm.HyperLink = "";
            this.Lb_BLGoodsCode_Dm.Left = 1.57F;
            this.Lb_BLGoodsCode_Dm.MultiLine = false;
            this.Lb_BLGoodsCode_Dm.Name = "Lb_BLGoodsCode_Dm";
            this.Lb_BLGoodsCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_BLGoodsCode_Dm.Text = "BLCD";
            this.Lb_BLGoodsCode_Dm.Top = 0.3125F;
            this.Lb_BLGoodsCode_Dm.Visible = false;
            this.Lb_BLGoodsCode_Dm.Width = 0.375F;
            // 
            // Lb_PartsManagementDivide2
            // 
            this.Lb_PartsManagementDivide2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2.Height = 0.125F;
            this.Lb_PartsManagementDivide2.HyperLink = "";
            this.Lb_PartsManagementDivide2.Left = 1.88F;
            this.Lb_PartsManagementDivide2.MultiLine = false;
            this.Lb_PartsManagementDivide2.Name = "Lb_PartsManagementDivide2";
            this.Lb_PartsManagementDivide2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PartsManagementDivide2.Text = "2";
            this.Lb_PartsManagementDivide2.Top = 0.125F;
            this.Lb_PartsManagementDivide2.Width = 0.125F;
            // 
            // Lb_PartsManagementDivide1
            // 
            this.Lb_PartsManagementDivide1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1.Height = 0.125F;
            this.Lb_PartsManagementDivide1.HyperLink = "";
            this.Lb_PartsManagementDivide1.Left = 1.78F;
            this.Lb_PartsManagementDivide1.MultiLine = false;
            this.Lb_PartsManagementDivide1.Name = "Lb_PartsManagementDivide1";
            this.Lb_PartsManagementDivide1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PartsManagementDivide1.Text = "1";
            this.Lb_PartsManagementDivide1.Top = 0.125F;
            this.Lb_PartsManagementDivide1.Width = 0.125F;
            // 
            // Lb_ShipmentCntBefore1
            // 
            this.Lb_ShipmentCntBefore1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore1.Height = 0.125F;
            this.Lb_ShipmentCntBefore1.HyperLink = "";
            this.Lb_ShipmentCntBefore1.Left = 7.6525F;
            this.Lb_ShipmentCntBefore1.MultiLine = false;
            this.Lb_ShipmentCntBefore1.Name = "Lb_ShipmentCntBefore1";
            this.Lb_ShipmentCntBefore1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCntBefore1.Text = "１ヶ月前";
            this.Lb_ShipmentCntBefore1.Top = 0.125F;
            this.Lb_ShipmentCntBefore1.Width = 0.625F;
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
            this.Lb_GoodsNo.Height = 0.125F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 2.33F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.125F;
            this.Lb_GoodsNo.Width = 0.3125F;
            // 
            // Lb_ShipmentCntBefore3
            // 
            this.Lb_ShipmentCntBefore3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBefore3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBefore3.Height = 0.125F;
            this.Lb_ShipmentCntBefore3.HyperLink = "";
            this.Lb_ShipmentCntBefore3.Left = 8.9025F;
            this.Lb_ShipmentCntBefore3.MultiLine = false;
            this.Lb_ShipmentCntBefore3.Name = "Lb_ShipmentCntBefore3";
            this.Lb_ShipmentCntBefore3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCntBefore3.Text = "３ヶ月前";
            this.Lb_ShipmentCntBefore3.Top = 0.125F;
            this.Lb_ShipmentCntBefore3.Width = 0.625F;
            // 
            // Lb_ShipmentCntBeforeTotal
            // 
            this.Lb_ShipmentCntBeforeTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBeforeTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBeforeTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBeforeTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBeforeTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBeforeTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBeforeTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntBeforeTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntBeforeTotal.Height = 0.125F;
            this.Lb_ShipmentCntBeforeTotal.HyperLink = "";
            this.Lb_ShipmentCntBeforeTotal.Left = 9.5325F;
            this.Lb_ShipmentCntBeforeTotal.MultiLine = false;
            this.Lb_ShipmentCntBeforeTotal.Name = "Lb_ShipmentCntBeforeTotal";
            this.Lb_ShipmentCntBeforeTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCntBeforeTotal.Text = "６ヶ月合計";
            this.Lb_ShipmentCntBeforeTotal.Top = 0.125F;
            this.Lb_ShipmentCntBeforeTotal.Width = 0.625F;
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
            this.Lb_ShipmentCnt.Height = 0.125F;
            this.Lb_ShipmentCnt.HyperLink = "";
            this.Lb_ShipmentCnt.Left = 7.0325F;
            this.Lb_ShipmentCnt.MultiLine = false;
            this.Lb_ShipmentCnt.Name = "Lb_ShipmentCnt";
            this.Lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCnt.Text = "当月出荷";
            this.Lb_ShipmentCnt.Top = 0.125F;
            this.Lb_ShipmentCnt.Width = 0.625F;
            // 
            // Lb_PartsManagementDivide1_Dm
            // 
            this.Lb_PartsManagementDivide1_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide1_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide1_Dm.Height = 0.125F;
            this.Lb_PartsManagementDivide1_Dm.HyperLink = "";
            this.Lb_PartsManagementDivide1_Dm.Left = 1.36F;
            this.Lb_PartsManagementDivide1_Dm.MultiLine = false;
            this.Lb_PartsManagementDivide1_Dm.Name = "Lb_PartsManagementDivide1_Dm";
            this.Lb_PartsManagementDivide1_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PartsManagementDivide1_Dm.Text = "1";
            this.Lb_PartsManagementDivide1_Dm.Top = 0.3125F;
            this.Lb_PartsManagementDivide1_Dm.Visible = false;
            this.Lb_PartsManagementDivide1_Dm.Width = 0.125F;
            // 
            // Lb_PartsManagementDivide2_Dm
            // 
            this.Lb_PartsManagementDivide2_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PartsManagementDivide2_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsManagementDivide2_Dm.Height = 0.125F;
            this.Lb_PartsManagementDivide2_Dm.HyperLink = "";
            this.Lb_PartsManagementDivide2_Dm.Left = 1.46F;
            this.Lb_PartsManagementDivide2_Dm.MultiLine = false;
            this.Lb_PartsManagementDivide2_Dm.Name = "Lb_PartsManagementDivide2_Dm";
            this.Lb_PartsManagementDivide2_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PartsManagementDivide2_Dm.Text = "2";
            this.Lb_PartsManagementDivide2_Dm.Top = 0.3125F;
            this.Lb_PartsManagementDivide2_Dm.Visible = false;
            this.Lb_PartsManagementDivide2_Dm.Width = 0.125F;
            // 
            // Lb_WarehouseShelfNo_Dm
            // 
            this.Lb_WarehouseShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Height = 0.125F;
            this.Lb_WarehouseShelfNo_Dm.HyperLink = "";
            this.Lb_WarehouseShelfNo_Dm.Left = 0F;
            this.Lb_WarehouseShelfNo_Dm.MultiLine = false;
            this.Lb_WarehouseShelfNo_Dm.Name = "Lb_WarehouseShelfNo_Dm";
            this.Lb_WarehouseShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_WarehouseShelfNo_Dm.Text = "棚番";
            this.Lb_WarehouseShelfNo_Dm.Top = 0.3125F;
            this.Lb_WarehouseShelfNo_Dm.Visible = false;
            this.Lb_WarehouseShelfNo_Dm.Width = 0.3125F;
            // 
            // Lb_Customer_Dm
            // 
            this.Lb_Customer_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Height = 0.125F;
            this.Lb_Customer_Dm.HyperLink = "";
            this.Lb_Customer_Dm.Left = 4.47F;
            this.Lb_Customer_Dm.MultiLine = false;
            this.Lb_Customer_Dm.Name = "Lb_Customer_Dm";
            this.Lb_Customer_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Customer_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_Customer_Dm.Text = "仕入先";
            this.Lb_Customer_Dm.Top = 0.3125F;
            this.Lb_Customer_Dm.Visible = false;
            this.Lb_Customer_Dm.Width = 0.375F;
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
            this.GrandTotalHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line,
            this.ALLTOTALTITLE,
            this.Ttl_ShipmentPosCnt,
            this.Ttl_ShipmentCnt,
            this.Ttl_ShipmentCntBefore1,
            this.Ttl_ShipmentCntBefore2,
            this.Ttl_ShipmentCntBefore3,
            this.Ttl_ShipmentCntBeforeTotal});
            this.GrandTotalFooter.Height = 0.25F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.ALLTOTALTITLE.Left = 5.5F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.03F;
            this.ALLTOTALTITLE.Width = 0.875F;
            // 
            // Ttl_ShipmentPosCnt
            // 
            this.Ttl_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Ttl_ShipmentPosCnt.Height = 0.125F;
            this.Ttl_ShipmentPosCnt.Left = 6.4F;
            this.Ttl_ShipmentPosCnt.MultiLine = false;
            this.Ttl_ShipmentPosCnt.Name = "Ttl_ShipmentPosCnt";
            this.Ttl_ShipmentPosCnt.OutputFormat = resources.GetString("Ttl_ShipmentPosCnt.OutputFormat");
            this.Ttl_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentPosCnt.Text = "12,345,678";
            this.Ttl_ShipmentPosCnt.Top = 0.03F;
            this.Ttl_ShipmentPosCnt.Width = 0.625F;
            // 
            // Ttl_ShipmentCnt
            // 
            this.Ttl_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.DataField = "ShipmentPrice";
            this.Ttl_ShipmentCnt.Height = 0.125F;
            this.Ttl_ShipmentCnt.Left = 6.97F;
            this.Ttl_ShipmentCnt.MultiLine = false;
            this.Ttl_ShipmentCnt.Name = "Ttl_ShipmentCnt";
            this.Ttl_ShipmentCnt.OutputFormat = resources.GetString("Ttl_ShipmentCnt.OutputFormat");
            this.Ttl_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt.Text = "123,456,789";
            this.Ttl_ShipmentCnt.Top = 0.03F;
            this.Ttl_ShipmentCnt.Width = 0.6875F;
            // 
            // Ttl_ShipmentCntBefore1
            // 
            this.Ttl_ShipmentCntBefore1.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore1.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore1.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore1.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore1.DataField = "ShipmentPriceBefore1";
            this.Ttl_ShipmentCntBefore1.Height = 0.125F;
            this.Ttl_ShipmentCntBefore1.Left = 7.59F;
            this.Ttl_ShipmentCntBefore1.MultiLine = false;
            this.Ttl_ShipmentCntBefore1.Name = "Ttl_ShipmentCntBefore1";
            this.Ttl_ShipmentCntBefore1.OutputFormat = resources.GetString("Ttl_ShipmentCntBefore1.OutputFormat");
            this.Ttl_ShipmentCntBefore1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCntBefore1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCntBefore1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCntBefore1.Text = "123,456,789";
            this.Ttl_ShipmentCntBefore1.Top = 0.03F;
            this.Ttl_ShipmentCntBefore1.Width = 0.6875F;
            // 
            // Ttl_ShipmentCntBefore2
            // 
            this.Ttl_ShipmentCntBefore2.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore2.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore2.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore2.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore2.DataField = "ShipmentPriceBefore2";
            this.Ttl_ShipmentCntBefore2.Height = 0.125F;
            this.Ttl_ShipmentCntBefore2.Left = 8.22F;
            this.Ttl_ShipmentCntBefore2.MultiLine = false;
            this.Ttl_ShipmentCntBefore2.Name = "Ttl_ShipmentCntBefore2";
            this.Ttl_ShipmentCntBefore2.OutputFormat = resources.GetString("Ttl_ShipmentCntBefore2.OutputFormat");
            this.Ttl_ShipmentCntBefore2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCntBefore2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCntBefore2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCntBefore2.Text = "123,456,789";
            this.Ttl_ShipmentCntBefore2.Top = 0.03F;
            this.Ttl_ShipmentCntBefore2.Width = 0.6875F;
            // 
            // Ttl_ShipmentCntBefore3
            // 
            this.Ttl_ShipmentCntBefore3.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore3.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore3.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore3.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBefore3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBefore3.DataField = "ShipmentPriceBefore3";
            this.Ttl_ShipmentCntBefore3.Height = 0.125F;
            this.Ttl_ShipmentCntBefore3.Left = 8.84F;
            this.Ttl_ShipmentCntBefore3.MultiLine = false;
            this.Ttl_ShipmentCntBefore3.Name = "Ttl_ShipmentCntBefore3";
            this.Ttl_ShipmentCntBefore3.OutputFormat = resources.GetString("Ttl_ShipmentCntBefore3.OutputFormat");
            this.Ttl_ShipmentCntBefore3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCntBefore3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCntBefore3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCntBefore3.Text = "123,456,789";
            this.Ttl_ShipmentCntBefore3.Top = 0.03F;
            this.Ttl_ShipmentCntBefore3.Width = 0.6875F;
            // 
            // Ttl_ShipmentCntBeforeTotal
            // 
            this.Ttl_ShipmentCntBeforeTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBeforeTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBeforeTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBeforeTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBeforeTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBeforeTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBeforeTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCntBeforeTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCntBeforeTotal.DataField = "ShipmentPriceBeforeTotal";
            this.Ttl_ShipmentCntBeforeTotal.Height = 0.125F;
            this.Ttl_ShipmentCntBeforeTotal.Left = 9.47F;
            this.Ttl_ShipmentCntBeforeTotal.MultiLine = false;
            this.Ttl_ShipmentCntBeforeTotal.Name = "Ttl_ShipmentCntBeforeTotal";
            this.Ttl_ShipmentCntBeforeTotal.OutputFormat = resources.GetString("Ttl_ShipmentCntBeforeTotal.OutputFormat");
            this.Ttl_ShipmentCntBeforeTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCntBeforeTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCntBeforeTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCntBeforeTotal.Text = "123,456,789";
            this.Ttl_ShipmentCntBeforeTotal.Top = 0.03F;
            this.Ttl_ShipmentCntBeforeTotal.Width = 0.6875F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Wh_WarehouseName,
            this.Wh_WarehouseCode,
            this.Line37});
            this.WarehouseHeader.DataField = "WarehouseCode";
            this.WarehouseHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.WarehouseHeader.Height = 0.1458333F;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.WarehouseHeader.BeforePrint += new System.EventHandler(this.WarehouseHeader_BeforePrint);
            // 
            // Wh_WarehouseName
            // 
            this.Wh_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.DataField = "WarehouseName";
            this.Wh_WarehouseName.Height = 0.125F;
            this.Wh_WarehouseName.Left = 0.25F;
            this.Wh_WarehouseName.MultiLine = false;
            this.Wh_WarehouseName.Name = "Wh_WarehouseName";
            this.Wh_WarehouseName.OutputFormat = resources.GetString("Wh_WarehouseName.OutputFormat");
            this.Wh_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Wh_WarehouseName.Text = "あいうえおかきくけこ";
            this.Wh_WarehouseName.Top = 0F;
            this.Wh_WarehouseName.Width = 1.1875F;
            // 
            // Wh_WarehouseCode
            // 
            this.Wh_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.DataField = "WarehouseCode";
            this.Wh_WarehouseCode.Height = 0.125F;
            this.Wh_WarehouseCode.Left = 0F;
            this.Wh_WarehouseCode.MultiLine = false;
            this.Wh_WarehouseCode.Name = "Wh_WarehouseCode";
            this.Wh_WarehouseCode.OutputFormat = resources.GetString("Wh_WarehouseCode.OutputFormat");
            this.Wh_WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.Wh_WarehouseCode.Text = "1234";
            this.Wh_WarehouseCode.Top = 0F;
            this.Wh_WarehouseCode.Width = 0.25F;
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
            this.Line37.LineWeight = 2F;
            this.Line37.Name = "Line37";
            this.Line37.Top = 0F;
            this.Line37.Width = 10.8F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.SECTOTALTITLE,
            this.Wh_ShipmentPosCnt,
            this.Wh_ShipmentCnt,
            this.Wh_ShipmentCntBefore1,
            this.Wh_ShipmentCntBefore2,
            this.Wh_ShipmentCntBefore3,
            this.Wh_ShipmentCntBeforeTotal});
            this.WarehouseFooter.Height = 0.25F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.AfterPrint += new System.EventHandler(this.WarehouseFooter_AfterPrint);
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
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
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
            this.SECTOTALTITLE.Left = 5.5F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "倉庫計";
            this.SECTOTALTITLE.Top = 0.03F;
            this.SECTOTALTITLE.Width = 0.875F;
            // 
            // Wh_ShipmentPosCnt
            // 
            this.Wh_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Wh_ShipmentPosCnt.Height = 0.125F;
            this.Wh_ShipmentPosCnt.Left = 6.4F;
            this.Wh_ShipmentPosCnt.MultiLine = false;
            this.Wh_ShipmentPosCnt.Name = "Wh_ShipmentPosCnt";
            this.Wh_ShipmentPosCnt.OutputFormat = resources.GetString("Wh_ShipmentPosCnt.OutputFormat");
            this.Wh_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentPosCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentPosCnt.Text = "12,345,678";
            this.Wh_ShipmentPosCnt.Top = 0.03F;
            this.Wh_ShipmentPosCnt.Width = 0.625F;
            // 
            // Wh_ShipmentCnt
            // 
            this.Wh_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.DataField = "ShipmentPrice";
            this.Wh_ShipmentCnt.Height = 0.125F;
            this.Wh_ShipmentCnt.Left = 6.97F;
            this.Wh_ShipmentCnt.MultiLine = false;
            this.Wh_ShipmentCnt.Name = "Wh_ShipmentCnt";
            this.Wh_ShipmentCnt.OutputFormat = resources.GetString("Wh_ShipmentCnt.OutputFormat");
            this.Wh_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt.Text = "123,456,789";
            this.Wh_ShipmentCnt.Top = 0.03F;
            this.Wh_ShipmentCnt.Width = 0.6875F;
            // 
            // Wh_ShipmentCntBefore1
            // 
            this.Wh_ShipmentCntBefore1.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore1.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore1.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore1.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore1.DataField = "ShipmentPriceBefore1";
            this.Wh_ShipmentCntBefore1.Height = 0.125F;
            this.Wh_ShipmentCntBefore1.Left = 7.59F;
            this.Wh_ShipmentCntBefore1.MultiLine = false;
            this.Wh_ShipmentCntBefore1.Name = "Wh_ShipmentCntBefore1";
            this.Wh_ShipmentCntBefore1.OutputFormat = resources.GetString("Wh_ShipmentCntBefore1.OutputFormat");
            this.Wh_ShipmentCntBefore1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCntBefore1.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCntBefore1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCntBefore1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCntBefore1.Text = "123,456,789";
            this.Wh_ShipmentCntBefore1.Top = 0.03F;
            this.Wh_ShipmentCntBefore1.Width = 0.6875F;
            // 
            // Wh_ShipmentCntBefore2
            // 
            this.Wh_ShipmentCntBefore2.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore2.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore2.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore2.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore2.DataField = "ShipmentPriceBefore2";
            this.Wh_ShipmentCntBefore2.Height = 0.125F;
            this.Wh_ShipmentCntBefore2.Left = 8.22F;
            this.Wh_ShipmentCntBefore2.MultiLine = false;
            this.Wh_ShipmentCntBefore2.Name = "Wh_ShipmentCntBefore2";
            this.Wh_ShipmentCntBefore2.OutputFormat = resources.GetString("Wh_ShipmentCntBefore2.OutputFormat");
            this.Wh_ShipmentCntBefore2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCntBefore2.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCntBefore2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCntBefore2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCntBefore2.Text = "123,456,789";
            this.Wh_ShipmentCntBefore2.Top = 0.03F;
            this.Wh_ShipmentCntBefore2.Width = 0.6875F;
            // 
            // Wh_ShipmentCntBefore3
            // 
            this.Wh_ShipmentCntBefore3.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore3.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore3.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore3.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBefore3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBefore3.DataField = "ShipmentPriceBefore3";
            this.Wh_ShipmentCntBefore3.Height = 0.125F;
            this.Wh_ShipmentCntBefore3.Left = 8.84F;
            this.Wh_ShipmentCntBefore3.MultiLine = false;
            this.Wh_ShipmentCntBefore3.Name = "Wh_ShipmentCntBefore3";
            this.Wh_ShipmentCntBefore3.OutputFormat = resources.GetString("Wh_ShipmentCntBefore3.OutputFormat");
            this.Wh_ShipmentCntBefore3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCntBefore3.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCntBefore3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCntBefore3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCntBefore3.Text = "123,456,789";
            this.Wh_ShipmentCntBefore3.Top = 0.03F;
            this.Wh_ShipmentCntBefore3.Width = 0.6875F;
            // 
            // Wh_ShipmentCntBeforeTotal
            // 
            this.Wh_ShipmentCntBeforeTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBeforeTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBeforeTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBeforeTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBeforeTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBeforeTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBeforeTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCntBeforeTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCntBeforeTotal.DataField = "ShipmentPriceBeforeTotal";
            this.Wh_ShipmentCntBeforeTotal.Height = 0.125F;
            this.Wh_ShipmentCntBeforeTotal.Left = 9.47F;
            this.Wh_ShipmentCntBeforeTotal.MultiLine = false;
            this.Wh_ShipmentCntBeforeTotal.Name = "Wh_ShipmentCntBeforeTotal";
            this.Wh_ShipmentCntBeforeTotal.OutputFormat = resources.GetString("Wh_ShipmentCntBeforeTotal.OutputFormat");
            this.Wh_ShipmentCntBeforeTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCntBeforeTotal.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCntBeforeTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCntBeforeTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCntBeforeTotal.Text = "123,456,789";
            this.Wh_ShipmentCntBeforeTotal.Top = 0.03F;
            this.Wh_ShipmentCntBeforeTotal.Width = 0.6875F;
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.DataField = "StockSupplierCode";
            this.SupplierHeader.Height = 0F;
            this.SupplierHeader.Name = "SupplierHeader";
            // 
            // SupplierFooter
            // 
            this.SupplierFooter.CanShrink = true;
            this.SupplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3,
            this.TextBox3,
            this.Sp_ShipmentPosCnt,
            this.Sp_ShipmentCnt,
            this.Sp_ShipmentCntBefore1,
            this.Sp_ShipmentCntBefore2,
            this.Sp_ShipmentCntBefore3,
            this.Sp_ShipmentCntBeforeTotal});
            this.SupplierFooter.Height = 0.25F;
            this.SupplierFooter.KeepTogether = true;
            this.SupplierFooter.Name = "SupplierFooter";
            this.SupplierFooter.AfterPrint += new System.EventHandler(this.SupplierFooter_AfterPrint);
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
            // TextBox3
            // 
            this.TextBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Height = 0.219F;
            this.TextBox3.Left = 5.5F;
            this.TextBox3.MultiLine = false;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox3.Text = "仕入先計";
            this.TextBox3.Top = 0.03F;
            this.TextBox3.Width = 0.875F;
            // 
            // Sp_ShipmentPosCnt
            // 
            this.Sp_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sp_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sp_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sp_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sp_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Sp_ShipmentPosCnt.Height = 0.125F;
            this.Sp_ShipmentPosCnt.Left = 6.4F;
            this.Sp_ShipmentPosCnt.MultiLine = false;
            this.Sp_ShipmentPosCnt.Name = "Sp_ShipmentPosCnt";
            this.Sp_ShipmentPosCnt.OutputFormat = resources.GetString("Sp_ShipmentPosCnt.OutputFormat");
            this.Sp_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sp_ShipmentPosCnt.SummaryGroup = "SupplierHeader";
            this.Sp_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sp_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sp_ShipmentPosCnt.Text = "12,345,678";
            this.Sp_ShipmentPosCnt.Top = 0.03F;
            this.Sp_ShipmentPosCnt.Width = 0.625F;
            // 
            // Sp_ShipmentCnt
            // 
            this.Sp_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCnt.DataField = "ShipmentPrice";
            this.Sp_ShipmentCnt.Height = 0.125F;
            this.Sp_ShipmentCnt.Left = 6.97F;
            this.Sp_ShipmentCnt.MultiLine = false;
            this.Sp_ShipmentCnt.Name = "Sp_ShipmentCnt";
            this.Sp_ShipmentCnt.OutputFormat = resources.GetString("Sp_ShipmentCnt.OutputFormat");
            this.Sp_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sp_ShipmentCnt.SummaryGroup = "SupplierHeader";
            this.Sp_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sp_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sp_ShipmentCnt.Text = "123,456,789";
            this.Sp_ShipmentCnt.Top = 0.03F;
            this.Sp_ShipmentCnt.Width = 0.6875F;
            // 
            // Sp_ShipmentCntBefore1
            // 
            this.Sp_ShipmentCntBefore1.Border.BottomColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore1.Border.LeftColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore1.Border.RightColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore1.Border.TopColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore1.DataField = "ShipmentPriceBefore1";
            this.Sp_ShipmentCntBefore1.Height = 0.125F;
            this.Sp_ShipmentCntBefore1.Left = 7.59F;
            this.Sp_ShipmentCntBefore1.MultiLine = false;
            this.Sp_ShipmentCntBefore1.Name = "Sp_ShipmentCntBefore1";
            this.Sp_ShipmentCntBefore1.OutputFormat = resources.GetString("Sp_ShipmentCntBefore1.OutputFormat");
            this.Sp_ShipmentCntBefore1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sp_ShipmentCntBefore1.SummaryGroup = "SupplierHeader";
            this.Sp_ShipmentCntBefore1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sp_ShipmentCntBefore1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sp_ShipmentCntBefore1.Text = "123,456,789";
            this.Sp_ShipmentCntBefore1.Top = 0.03F;
            this.Sp_ShipmentCntBefore1.Width = 0.6875F;
            // 
            // Sp_ShipmentCntBefore2
            // 
            this.Sp_ShipmentCntBefore2.Border.BottomColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore2.Border.LeftColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore2.Border.RightColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore2.Border.TopColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore2.DataField = "ShipmentPriceBefore2";
            this.Sp_ShipmentCntBefore2.Height = 0.125F;
            this.Sp_ShipmentCntBefore2.Left = 8.22F;
            this.Sp_ShipmentCntBefore2.MultiLine = false;
            this.Sp_ShipmentCntBefore2.Name = "Sp_ShipmentCntBefore2";
            this.Sp_ShipmentCntBefore2.OutputFormat = resources.GetString("Sp_ShipmentCntBefore2.OutputFormat");
            this.Sp_ShipmentCntBefore2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sp_ShipmentCntBefore2.SummaryGroup = "SupplierHeader";
            this.Sp_ShipmentCntBefore2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sp_ShipmentCntBefore2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sp_ShipmentCntBefore2.Text = "123,456,789";
            this.Sp_ShipmentCntBefore2.Top = 0.03F;
            this.Sp_ShipmentCntBefore2.Width = 0.6875F;
            // 
            // Sp_ShipmentCntBefore3
            // 
            this.Sp_ShipmentCntBefore3.Border.BottomColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore3.Border.LeftColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore3.Border.RightColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore3.Border.TopColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBefore3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBefore3.DataField = "ShipmentPriceBefore3";
            this.Sp_ShipmentCntBefore3.Height = 0.125F;
            this.Sp_ShipmentCntBefore3.Left = 8.84F;
            this.Sp_ShipmentCntBefore3.MultiLine = false;
            this.Sp_ShipmentCntBefore3.Name = "Sp_ShipmentCntBefore3";
            this.Sp_ShipmentCntBefore3.OutputFormat = resources.GetString("Sp_ShipmentCntBefore3.OutputFormat");
            this.Sp_ShipmentCntBefore3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sp_ShipmentCntBefore3.SummaryGroup = "SupplierHeader";
            this.Sp_ShipmentCntBefore3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sp_ShipmentCntBefore3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sp_ShipmentCntBefore3.Text = "123,456,789";
            this.Sp_ShipmentCntBefore3.Top = 0.03F;
            this.Sp_ShipmentCntBefore3.Width = 0.6875F;
            // 
            // Sp_ShipmentCntBeforeTotal
            // 
            this.Sp_ShipmentCntBeforeTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBeforeTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBeforeTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBeforeTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBeforeTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBeforeTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBeforeTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Sp_ShipmentCntBeforeTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sp_ShipmentCntBeforeTotal.DataField = "ShipmentPriceBeforeTotal";
            this.Sp_ShipmentCntBeforeTotal.Height = 0.125F;
            this.Sp_ShipmentCntBeforeTotal.Left = 9.47F;
            this.Sp_ShipmentCntBeforeTotal.MultiLine = false;
            this.Sp_ShipmentCntBeforeTotal.Name = "Sp_ShipmentCntBeforeTotal";
            this.Sp_ShipmentCntBeforeTotal.OutputFormat = resources.GetString("Sp_ShipmentCntBeforeTotal.OutputFormat");
            this.Sp_ShipmentCntBeforeTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sp_ShipmentCntBeforeTotal.SummaryGroup = "SupplierHeader";
            this.Sp_ShipmentCntBeforeTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sp_ShipmentCntBeforeTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sp_ShipmentCntBeforeTotal.Text = "123,456,789";
            this.Sp_ShipmentCntBeforeTotal.Top = 0.03F;
            this.Sp_ShipmentCntBeforeTotal.Width = 0.6875F;
            // 
            // WarehouseShelfNoHeader
            // 
            this.WarehouseShelfNoHeader.DataField = "WarehouseShelfNoBreak";
            this.WarehouseShelfNoHeader.Height = 0F;
            this.WarehouseShelfNoHeader.Name = "WarehouseShelfNoHeader";
            // 
            // WarehouseShelfNoFooter
            // 
            this.WarehouseShelfNoFooter.CanShrink = true;
            this.WarehouseShelfNoFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line5,
            this.TextBox20,
            this.Ws_ShipmentPosCnt,
            this.Ws_ShipmentCnt,
            this.Ws_ShipmentCntBefore1,
            this.Ws_ShipmentCntBefore2,
            this.Ws_ShipmentCntBefore3,
            this.Ws_ShipmentCntBeforeTotal});
            this.WarehouseShelfNoFooter.Height = 0.25F;
            this.WarehouseShelfNoFooter.KeepTogether = true;
            this.WarehouseShelfNoFooter.Name = "WarehouseShelfNoFooter";
            this.WarehouseShelfNoFooter.AfterPrint += new System.EventHandler(this.WarehouseShelfNoFooter_AfterPrint);
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
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // TextBox20
            // 
            this.TextBox20.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Height = 0.219F;
            this.TextBox20.Left = 5.5F;
            this.TextBox20.MultiLine = false;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox20.Text = "棚番計";
            this.TextBox20.Top = 0.03F;
            this.TextBox20.Width = 0.875F;
            // 
            // Ws_ShipmentPosCnt
            // 
            this.Ws_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Ws_ShipmentPosCnt.Height = 0.125F;
            this.Ws_ShipmentPosCnt.Left = 6.4F;
            this.Ws_ShipmentPosCnt.MultiLine = false;
            this.Ws_ShipmentPosCnt.Name = "Ws_ShipmentPosCnt";
            this.Ws_ShipmentPosCnt.OutputFormat = resources.GetString("Ws_ShipmentPosCnt.OutputFormat");
            this.Ws_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_ShipmentPosCnt.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_ShipmentPosCnt.Text = "12,345,678";
            this.Ws_ShipmentPosCnt.Top = 0.03F;
            this.Ws_ShipmentPosCnt.Width = 0.625F;
            // 
            // Ws_ShipmentCnt
            // 
            this.Ws_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCnt.DataField = "ShipmentPrice";
            this.Ws_ShipmentCnt.Height = 0.125F;
            this.Ws_ShipmentCnt.Left = 6.97F;
            this.Ws_ShipmentCnt.MultiLine = false;
            this.Ws_ShipmentCnt.Name = "Ws_ShipmentCnt";
            this.Ws_ShipmentCnt.OutputFormat = resources.GetString("Ws_ShipmentCnt.OutputFormat");
            this.Ws_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_ShipmentCnt.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_ShipmentCnt.Text = "123,456,789";
            this.Ws_ShipmentCnt.Top = 0.03F;
            this.Ws_ShipmentCnt.Width = 0.6875F;
            // 
            // Ws_ShipmentCntBefore1
            // 
            this.Ws_ShipmentCntBefore1.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore1.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore1.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore1.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore1.DataField = "ShipmentPriceBefore1";
            this.Ws_ShipmentCntBefore1.Height = 0.125F;
            this.Ws_ShipmentCntBefore1.Left = 7.59F;
            this.Ws_ShipmentCntBefore1.MultiLine = false;
            this.Ws_ShipmentCntBefore1.Name = "Ws_ShipmentCntBefore1";
            this.Ws_ShipmentCntBefore1.OutputFormat = resources.GetString("Ws_ShipmentCntBefore1.OutputFormat");
            this.Ws_ShipmentCntBefore1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_ShipmentCntBefore1.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_ShipmentCntBefore1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_ShipmentCntBefore1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_ShipmentCntBefore1.Text = "123,456,789";
            this.Ws_ShipmentCntBefore1.Top = 0.03F;
            this.Ws_ShipmentCntBefore1.Width = 0.6875F;
            // 
            // Ws_ShipmentCntBefore2
            // 
            this.Ws_ShipmentCntBefore2.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore2.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore2.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore2.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore2.DataField = "ShipmentPriceBefore2";
            this.Ws_ShipmentCntBefore2.Height = 0.125F;
            this.Ws_ShipmentCntBefore2.Left = 8.22F;
            this.Ws_ShipmentCntBefore2.MultiLine = false;
            this.Ws_ShipmentCntBefore2.Name = "Ws_ShipmentCntBefore2";
            this.Ws_ShipmentCntBefore2.OutputFormat = resources.GetString("Ws_ShipmentCntBefore2.OutputFormat");
            this.Ws_ShipmentCntBefore2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_ShipmentCntBefore2.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_ShipmentCntBefore2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_ShipmentCntBefore2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_ShipmentCntBefore2.Text = "123,456,789";
            this.Ws_ShipmentCntBefore2.Top = 0.03F;
            this.Ws_ShipmentCntBefore2.Width = 0.6875F;
            // 
            // Ws_ShipmentCntBefore3
            // 
            this.Ws_ShipmentCntBefore3.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore3.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore3.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore3.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBefore3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBefore3.DataField = "ShipmentPriceBefore3";
            this.Ws_ShipmentCntBefore3.Height = 0.125F;
            this.Ws_ShipmentCntBefore3.Left = 8.84F;
            this.Ws_ShipmentCntBefore3.MultiLine = false;
            this.Ws_ShipmentCntBefore3.Name = "Ws_ShipmentCntBefore3";
            this.Ws_ShipmentCntBefore3.OutputFormat = resources.GetString("Ws_ShipmentCntBefore3.OutputFormat");
            this.Ws_ShipmentCntBefore3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_ShipmentCntBefore3.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_ShipmentCntBefore3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_ShipmentCntBefore3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_ShipmentCntBefore3.Text = "123,456,789";
            this.Ws_ShipmentCntBefore3.Top = 0.03F;
            this.Ws_ShipmentCntBefore3.Width = 0.6875F;
            // 
            // Ws_ShipmentCntBeforeTotal
            // 
            this.Ws_ShipmentCntBeforeTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBeforeTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBeforeTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBeforeTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBeforeTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBeforeTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBeforeTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_ShipmentCntBeforeTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentCntBeforeTotal.DataField = "ShipmentPriceBeforeTotal";
            this.Ws_ShipmentCntBeforeTotal.Height = 0.125F;
            this.Ws_ShipmentCntBeforeTotal.Left = 9.47F;
            this.Ws_ShipmentCntBeforeTotal.MultiLine = false;
            this.Ws_ShipmentCntBeforeTotal.Name = "Ws_ShipmentCntBeforeTotal";
            this.Ws_ShipmentCntBeforeTotal.OutputFormat = resources.GetString("Ws_ShipmentCntBeforeTotal.OutputFormat");
            this.Ws_ShipmentCntBeforeTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_ShipmentCntBeforeTotal.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_ShipmentCntBeforeTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_ShipmentCntBeforeTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_ShipmentCntBeforeTotal.Text = "123,456,789";
            this.Ws_ShipmentCntBeforeTotal.Top = 0.03F;
            this.Ws_ShipmentCntBeforeTotal.Width = 0.6875F;
            // 
            // MAZAI02072P_02A4C
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
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.SupplierHeader);
            this.Sections.Add(this.WarehouseShelfNoHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.WarehouseShelfNoFooter);
            this.Sections.Add(this.SupplierFooter);
            this.Sections.Add(this.WarehouseFooter);
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
            this.ReportStart += new System.EventHandler(this.MAZAI02072P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBefore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBefore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBefore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide1_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsManagementDivide2_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntBeforeTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBefore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBefore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBefore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntBeforeTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide1_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsManagementDivide2_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBefore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBefore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBefore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCntBeforeTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBefore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBefore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBefore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCntBeforeTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBefore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBefore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBefore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_ShipmentCntBeforeTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBefore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBefore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBefore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentCntBeforeTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
