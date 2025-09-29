using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸数入力 製番毎棚卸数入力画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 棚卸数入力 製番毎棚卸数入力画面</br>
	/// <br>Programmer	: 22013 kubo</br>
	/// <br>date		: 2007.07.25</br>
	/// </remarks>
	public partial class ProductNumInput : Form
	{
		#region ■ Constructor
		/// <summary>
		/// 棚卸数入力 製番毎棚卸数入力画面コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 棚卸数入力 製番毎棚卸数入力画面のインスタンスを生成</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		public ProductNumInput ()
		{
			InitializeComponent();

			// Private member初期化 -----------------------------------
			this._firstFlag		= true;							// 初回起動ﾌﾗｸﾞ初期化

			this._inventInputAcs = new InventInputAcs();
		}
		#endregion

		#region ■ Private Member
		/// <summary> 初回起動ﾌﾗｸﾞ </summary>
		private bool _firstFlag;
		DataTable _productDTable;// 入力用Table

		InventInputAcs _inventInputAcs;

		ArrayList _defPrdTelList = new ArrayList();
		#endregion ■ Private Member

		#region ■ Private Const
		// Toolbar Button Name -----------------------------------
		// MainToolbar Button -----------------------------------
		/// <summary> 確定ボタン </summary>
		private const string ct_Tool_Enter		= "Tool_Enter";
		/// <summary> 戻るボタン </summary>
		private const string ct_Tool_Close		= "Tool_Close";

		// DataViewToolbar Button -----------------------------------
		/// <summary> 棚卸数一括入力ポップアップメニュー </summary>
		private const string ct_tool_BatchInvCnt = "tool_BatchInvCnt";
		/// <summary> 棚卸一括入力 - 全て入力 </summary>
		private const string ct_tool_BIC_AllInput = "tool_BIC_AllInput";
		/// <summary> 棚卸一括入力 - 未入力のみ </summary>
		private const string ct_tool_BIC_NoInput = "tool_BIC_NoInput";
		/// <summary> 棚卸一括入力 - 全て削除 </summary>
		private const string ct_tool_BIC_AllCansel = "tool_BIC_AllCansel";

		/// <summary> 棚卸日一括設定ポップアップメニュー </summary>
		private const string ct_tool_BatchInvDay = "tool_BatchInvDay";
		/// <summary> 棚卸日一括設定 - 全て入力 </summary>
		private const string ct_tool_BID_AllInput = "tool_BID_AllInput";
		/// <summary> 棚卸日一括設定 - 未入力のみ </summary>
		private const string ct_tool_BID_NoInput = "tool_BID_NoInput";
		/// <summary> 棚卸日一括設定 - 全て削除 </summary>
		private const string ct_tool_BID_AllCansel = "tool_BID_AllCansel";
	
		// Sort Order -----------------------------------
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> ソート先頭条件(製番Asc) </summary>
		//private const string ct_SortOrder = InventInputResult.ct_Col_ProductNumber;
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

		// else -----------------------------------
		/// <summary> Class FullName </summary>
		private const string ct_ClassFullName = "Broadleaf.Windows.Forms.MAZAI05130UC";
		/// <summary> Class Name </summary>
		private const string ct_ClassName = "MAZAI05130UC";

		private Form _parentForm;
		#endregion ■ Private Const

		#region ■ Public Property
		/// <summary>
		/// 変更前製番、電話番号リスト
		/// </summary>
		public ArrayList DefPrdTelList
		{
			set{this._defPrdTelList = value;}
		}
		#endregion

		#region ■ Public Method
		#region ◎ 製番毎棚卸数入力画面起動メソッド
		/// <summary>
		/// 製番毎棚卸数入力画面起動メソッド
		/// </summary>
		/// <param name="productNumArray">製番格納</param>
		/// <param name="addNewRowCount">新規追加行数</param>
		/// <param name="parent">親フォーム</param>
		/// <returns>Status(MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: 製番毎棚卸数入力画面を起動する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		public int ShowProductInventInput ( out ArrayList productNumArray, double addNewRowCount, Form parent )
		{
            productNumArray = new ArrayList();
			
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			try
			{
				this._parentForm = parent;

				string message = string.Empty;

				InventInputResult.CreateDataTable( ref this._productDTable );
				DataRow addRow = null;
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //InventoryDataUpdateWork invWork = null;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                for (int tableIndex = 0; tableIndex < addNewRowCount; tableIndex++)
				{
					addRow = this._productDTable.NewRow();
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //addRow[InventInputResult.ct_Col_ProductStockGuid] = Guid.NewGuid();
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    addRow[InventInputResult.ct_Col_RowSelf] = addRow;

                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //if (this._defPrdTelList != null && this._defPrdTelList.Count > 0 && tableIndex < this._defPrdTelList.Count)
					//{
					//	invWork = (InventoryDataUpdateWork)this._defPrdTelList[tableIndex];
					//	addRow[InventInputResult.ct_Col_ProductNumber] = invWork.ProductNumber;
					//	addRow[InventInputResult.ct_Col_StockTelNo1] = invWork.StockTelNo1;
					//	addRow[InventInputResult.ct_Col_StockTelNo2] = invWork.StockTelNo2;
					//}
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    this._productDTable.Rows.Add(addRow);
				}

				// 初期表示位置を親コントロールの中心に配置。この後TMemPos部品により配置場所は変更される。
				this.StartPosition = FormStartPosition.CenterParent;
				
//				this.InitialScreen( );

				// 端末情報入力画面起動
				DialogResult formResult = this.ShowDialog();

				foreach( UltraGridRow ultraGridRow in this.ug_ProductInventInput.Rows )
				{
					productNumArray.Add ( (DataRow)ultraGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value );
				}
				// DialogResultから戻り値を設定
				switch ( formResult )
				{
					case DialogResult.OK:		
						{
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						}
					case DialogResult.Cancel:	{ status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;	break; }
					default:					{ status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;	break; }
				}
            }
			catch( Exception ex )
			{
				status = -1;
				MsgDispProc( 
					"製造番号入力処理にてエラーが発生しました。\r\n", 
					status, 
					"ShowProductInventInput", 
					ex, 
					emErrorLevel.ERR_LEVEL_STOPDISP);
			}
			return status;
		}
		#endregion
		#endregion  ■ Public Method

		#region ■ Private Method
		#region ◎ 初期化処理メイン
		/// <summary>
		/// 初期化処理メイン
		/// </summary>
		/// <returns>Status(MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: 画面初期化処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private int InitialScreen ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			try
			{
				// 初回起動時のみ画面設定
				if ( this._firstFlag  )
				{
					// Toolbars Setting
					InitialToolBarsSetting();

					// StatusBarsSetting
					InitializeStatusBarSetting();

					// UIGridにデータをバインド
					this.ug_ProductInventInput.DataSource = this._productDTable;

					// グリッドキーマッピング作成
					this.MakeGridKeyMapping( this.ug_ProductInventInput);

					// Grid Setting
					this.InitialInventInputGrid( this.ug_ProductInventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput] );

			        // 列幅をオートに設定
			        this.ug_ProductInventInput.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

					// インクリメントして初期化をしないようにする。
					this._firstFlag = false;
				}

                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //if (this.ug_ProductInventInput.Rows.Count > 0)
				//{
				//    //this.ug_ProductInventInput.Focus();
				//	this.ug_ProductInventInput.Rows[0].Cells[InventInputResult.ct_Col_ProductNumber].Activate();
                //
				//	//this.ug_ProductInventInput.PerformAction(UltraGridAction.EnterEditMode);
				//}
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			}
			finally
			{
			}

			return status;
		}
		#endregion

		#region ◎ ツールバー設定処理
		/// <summary>
		/// ツールバー設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ツールバーの設定を行う。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialToolBarsSetting ()
		{
			// アイコンリスト登録 ==============================================================3
			this.utm_MainToolBarsMng.ImageListSmall = IconResourceManagement.ImageList16;		// MainToolbar

			// MainToolBar ButtonImage Setting -----------------------------------------------
			// 確定ボタン
			ToolBarButtonToolImageSetting(utm_MainToolBarsMng, ct_Tool_Enter,		Size16_Index.DECISION);
			// 戻るボタン
			ToolBarButtonToolImageSetting(utm_MainToolBarsMng, ct_Tool_Close,		Size16_Index.BEFORE);

			// DataViewToolBar ButtonImage Setting -----------------------------------------------

		}
		#endregion

		#region ◎ ツールバーボタンアイコン設定処理
		/// <summary>
		/// ツールバーボタンアイコン設定処理
		/// </summary>
		/// <param name="targetToolBar">設定対象ツールバー</param>
		/// <param name="buttonName">ボタン名称</param>
		/// <param name="iconIndex">IconResourceManagement</param>
		/// <remarks>
		/// <br>Note		: ツールバーボタンのアイコンの設定を行う。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ToolBarButtonToolImageSetting ( 
			Infragistics.Win.UltraWinToolbars.UltraToolbarsManager targetToolBar, string buttonName, Size16_Index iconIndex )
		{
			// ボタンオブジェクトの取得
			Infragistics.Win.UltraWinToolbars.ButtonTool btnObject = targetToolBar.Tools[buttonName] as Infragistics.Win.UltraWinToolbars.ButtonTool;
			if ( btnObject != null )
			{
				btnObject.SharedProps.AppearancesSmall.Appearance.Image = iconIndex;
			}
		}
		#endregion

		#region ◎ ステータスバー初期処理
		/// <summary>
		/// ステータスバー初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ステータスバー初期化を行う</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitializeStatusBarSetting ()
		{
			// フォントサイズ変更コンボボックスの設定
			this.tce_FontSize.MaxDropDownItems = this.tce_FontSize.Items.Count;
			this.tce_FontSize.Value = 11;
		}

		#endregion

		#region ◎ データ表示UltraGrid初期処理
		/// <summary>
		/// データ表示UltraGrid初期処理
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			// 一旦すべての列を非表示にし、表示位置を統一させる
			foreach( UltraGridColumn column in band.Columns ) {
				column.Hidden = true;
				column.CellAppearance.TextHAlign  = HAlign.Left;
				column.CellAppearance.ImageHAlign = HAlign.Left;
				column.CellAppearance.ImageVAlign = VAlign.Middle;
			}

			//band.Columns[ InventInputResult.ct_Col_ProductNumber ]

            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
			this.InitialInventInputGrid_Hidden( band );				// 表示状態設定
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
            this.InitialInventInputGrid_Tag( band );				// Tag
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
			this.InitialInventInputGrid_CellActivation( band );		// 入力設定
			this.InitialInventInputGrid_Width( band );				// 幅設定
			this.InitialInventInputGrid_CellClickAction( band );	// CellClickAction
			this.InitialInventInputGrid_TabStop( band );			// TabStop
            this.InitialInventInputGrid_GroupSetting( band );		// GroupSetting
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            // 列ヘッダを非表示にする。
			band.ColHeadersVisible = false;

			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].CharacterCasing = CharacterCasing.Upper;

			this.ug_ProductInventInput.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
			this.ug_ProductInventInput.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;

			
			//// 列ヘッダを非表示にする。
			//band.ColHeadersVisible = false;
		}
		#endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ データ表示UltraGrid初期処理(Hiddenプロパティ)
		/// <summary>
		/// データ表示UltraGrid初期処理(Hiddenプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_Hidden( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 表示状態設定(Hidden)
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 表示項目 ------------------------------------------------------
			//// 製造番号
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Hidden = false;
			//// 電話番号1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Hidden = false;
			//// 電話番号2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Hidden = false;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			#endregion
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ データ表示UltraGrid初期処理(Tagプロパティ)
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// データ表示UltraGrid初期処理(Tagプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_Tag( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 表示状態設定(Tag)
			// 表示項目 ------------------------------------------------------
			// 作成日時
			band.Columns[ InventInputResult.ct_Col_CreateDateTime ].Tag = InventInputResult.ct_Col_CreateDateTime;
			// 更新日時
			band.Columns[ InventInputResult.ct_Col_UpdateDateTime ].Tag = InventInputResult.ct_Col_UpdateDateTime;
			// 企業コード
			band.Columns[ InventInputResult.ct_Col_EnterpriseCode ].Tag = InventInputResult.ct_Col_EnterpriseCode;
			// GUID
			band.Columns[ InventInputResult.ct_Col_FileHeaderGuid ].Tag = InventInputResult.ct_Col_FileHeaderGuid;
			// 更新従業員コード
			band.Columns[ InventInputResult.ct_Col_UpdEmployeeCode ].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
			// 更新アセンブリID1
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId1 ].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
			// 更新アセンブリID2
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId2 ].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
			// 論理削除区分
			band.Columns[ InventInputResult.ct_Col_LogicalDeleteCode ].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
			// 拠点コード
			band.Columns[ InventInputResult.ct_Col_SectionCode ].Tag = InventInputResult.ct_Col_SectionCode;
			// 拠点ガイド名称
			band.Columns[ InventInputResult.ct_Col_SectionGuideNm ].Tag = InventInputResult.ct_Col_SectionGuideNm;
			// 棚卸通番
			band.Columns[ InventInputResult.ct_Col_InventorySeqNo ].Tag = InventInputResult.ct_Col_InventorySeqNo;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番在庫マスタGUID
			//band.Columns[ InventInputResult.ct_Col_ProductStockGuid ].Tag = InventInputResult.ct_Col_ProductStockGuid;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 倉庫コード
			band.Columns[ InventInputResult.ct_Col_WarehouseCode ].Tag = InventInputResult.ct_Col_WarehouseCode;
			// 倉庫名称
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Tag = InventInputResult.ct_Col_WarehouseName;
            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // 重複棚番１
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // 重複棚番２
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
            // メーカーコード
			band.Columns[ InventInputResult.ct_Col_MakerCode ].Tag = InventInputResult.ct_Col_MakerCode;
			// メーカー名称
			band.Columns[ InventInputResult.ct_Col_MakerName ].Tag = InventInputResult.ct_Col_MakerName;
			// 品番
			band.Columns[ InventInputResult.ct_Col_GoodsNo ].Tag = InventInputResult.ct_Col_GoodsNo;
			// 品名
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Tag = InventInputResult.ct_Col_GoodsName;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 機種コード
            //band.Columns[ InventInputResult.ct_Col_CellphoneModelCode ].Tag = InventInputResult.ct_Col_CellphoneModelCode;
            //// 機種名称
            //band.Columns[ InventInputResult.ct_Col_CellphoneModelName ].Tag = InventInputResult.ct_Col_CellphoneModelName;
            //// キャリアコード
            //band.Columns[ InventInputResult.ct_Col_CarrierCode ].Tag = InventInputResult.ct_Col_CarrierCode;
            //// キャリア名称
            //band.Columns[ InventInputResult.ct_Col_CarrierName ].Tag = InventInputResult.ct_Col_CarrierName;
            //// 系統色コード
            //band.Columns[ InventInputResult.ct_Col_SystematicColorCd ].Tag = InventInputResult.ct_Col_SystematicColorCd;
            //// 系統色名称
            //band.Columns[ InventInputResult.ct_Col_SystematicColorNm ].Tag = InventInputResult.ct_Col_SystematicColorNm;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 商品大分類コード
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreCode ].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
			// 商品大分類名称
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreName ].Tag = InventInputResult.ct_Col_LargeGoodsGanreName;
			// 商品中分類コード
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreCode ].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
			// 商品中分類名称
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreName ].Tag = InventInputResult.ct_Col_MediumGoodsGanreName;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者コード
            //band.Columns[ InventInputResult.ct_Col_CarrierEpCode ].Tag = InventInputResult.ct_Col_CarrierEpCode;
            //// 事業者名称
            //band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Tag = InventInputResult.ct_Col_CarrierEpName;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 得意先コード
			band.Columns[ InventInputResult.ct_Col_CustomerCode ].Tag = InventInputResult.ct_Col_CustomerCode;
			// 得意先名称
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Tag = InventInputResult.ct_Col_CustomerName;
			// 得意先名称2
			band.Columns[ InventInputResult.ct_Col_CustomerName2 ].Tag = InventInputResult.ct_Col_CustomerName2;
			// 委託先コード
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// 委託先名称
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// 委託先名称2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 仕入日
            //band.Columns[ InventInputResult.ct_Col_StockDate ].Tag = InventInputResult.ct_Col_StockDate;
            //// 入荷日
            //band.Columns[ InventInputResult.ct_Col_ArrivalGoodsDay ].Tag = InventInputResult.ct_Col_ArrivalGoodsDay;
            //// 製造番号
            //band.Columns[ InventInputResult.ct_Col_ProductNumber ].Tag = InventInputResult.ct_Col_ProductNumber;
            //// 商品電話番号1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Tag = InventInputResult.ct_Col_StockTelNo1;
            //// 変更前商品電話番号1
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ].Tag = InventInputResult.ct_Col_BfStockTelNo1;
            //// 商品電話番号1変更フラグ
            //band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo1ChgFlg;
            //// 商品電話番号2
            //band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Tag = InventInputResult.ct_Col_StockTelNo2;
            //// 変更前商品電話番号2
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ].Tag = InventInputResult.ct_Col_BfStockTelNo2;
			//// 商品電話番号2変更フラグ
			//band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo2ChgFlg;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // JANコード
			band.Columns[ InventInputResult.ct_Col_Jan ].Tag = InventInputResult.ct_Col_Jan;
			// 仕入単価
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].Tag = InventInputResult.ct_Col_StockUnitPrice;
			// 変更前仕入単価
			band.Columns[ InventInputResult.ct_Col_BfStockUnitPrice ].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
			// 仕入単価変更フラグ
			band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
			// 在庫区分
			band.Columns[ InventInputResult.ct_Col_StockDiv ].Tag = InventInputResult.ct_Col_StockDiv;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫状態
			//band.Columns[ InventInputResult.ct_Col_StockState ].Tag = InventInputResult.ct_Col_StockState;
			//// 移動状態
			//band.Columns[ InventInputResult.ct_Col_MoveStatus ].Tag = InventInputResult.ct_Col_MoveStatus;
			//// 商品状態
			//band.Columns[ InventInputResult.ct_Col_GoodsCodeStatus ].Tag = InventInputResult.ct_Col_GoodsCodeStatus;
			//// 製番管理区分
			//band.Columns[ InventInputResult.ct_Col_PrdNumMngDiv ].Tag = InventInputResult.ct_Col_PrdNumMngDiv;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 最終仕入年月日
			band.Columns[ InventInputResult.ct_Col_LastStockDate ].Tag = InventInputResult.ct_Col_LastStockDate;
			// 在庫数
			band.Columns[ InventInputResult.ct_Col_StockTotal ].Tag = InventInputResult.ct_Col_StockTotal;
			// 委託先コード
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// 委託先名称
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// 委託先名称2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
			// 棚卸在庫数
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Tag = InventInputResult.ct_Col_InventoryStockCnt;
			// 棚卸過不足数
			band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
			// 棚卸準備処理日付
            band.Columns[InventInputResult.ct_Col_InventoryPreprDay].Tag = InventInputResult.ct_Col_InventoryPreprDay;
            // 棚卸準備処理時間
			band.Columns[ InventInputResult.ct_Col_InventoryPreprTim ].Tag = InventInputResult.ct_Col_InventoryPreprTim;
			// 棚卸実施日
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// 棚卸実施日
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// 棚卸実施日(DateTime)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Datetime ].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
			// 棚卸実施日(年 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].Tag = InventInputResult.ct_Col_InventoryDay_Year;
			// 棚卸実施日(年 ラベル)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
			// 棚卸実施日(月 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Tag = InventInputResult.ct_Col_InventoryDay_Month;
			// 棚卸実施日(月 ラベル)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
			// 棚卸実施日(日 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Tag = InventInputResult.ct_Col_InventoryDay_Day;
			// 棚卸実施日(日 ラベル)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Tag = InventInputResult.ct_Col_InventoryDay_DayL;

			// 棚卸更新日
			band.Columns[ InventInputResult.ct_Col_LastInventoryUpdate ].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
			// 棚卸新規追加区分
			band.Columns[ InventInputResult.ct_Col_InventoryNewDiv ].Tag = InventInputResult.ct_Col_InventoryNewDiv;
			// 棚卸新規追加区分名称
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].Tag = InventInputResult.ct_Col_InventoryNewDivName;
			// 在庫委託受託区分
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
			// 在庫委託受託区分名称
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
			// 集計区分
			band.Columns[ InventInputResult.ct_Col_GrossDiv ].Tag = InventInputResult.ct_Col_GrossDiv;
			// ボタン用カラム
			band.Columns[ InventInputResult.ct_Col_Button ].Tag = InventInputResult.ct_Col_Button;
			// 自行
			band.Columns[ InventInputResult.ct_Col_RowSelf ].Tag = InventInputResult.ct_Col_RowSelf;
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データ表示UltraGrid初期処理(Tagプロパティ)
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>date		: 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_Tag(Infragistics.Win.UltraWinGrid.UltraGridBand band)
        {
            #region// 表示状態設定(Tag)
            // 表示項目 ------------------------------------------------------
            // 作成日時
            band.Columns[InventInputResult.ct_Col_CreateDateTime].Tag = InventInputResult.ct_Col_CreateDateTime;
            // 更新日時
            band.Columns[InventInputResult.ct_Col_UpdateDateTime].Tag = InventInputResult.ct_Col_UpdateDateTime;
            // 企業コード
            band.Columns[InventInputResult.ct_Col_EnterpriseCode].Tag = InventInputResult.ct_Col_EnterpriseCode;
            // GUID
            band.Columns[InventInputResult.ct_Col_FileHeaderGuid].Tag = InventInputResult.ct_Col_FileHeaderGuid;
            // 更新従業員コード
            band.Columns[InventInputResult.ct_Col_UpdEmployeeCode].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
            // 更新アセンブリID1
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId1].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
            // 更新アセンブリID2
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId2].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
            // 論理削除区分
            band.Columns[InventInputResult.ct_Col_LogicalDeleteCode].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
            // 拠点コード
            band.Columns[InventInputResult.ct_Col_SectionCode].Tag = InventInputResult.ct_Col_SectionCode;
            // 棚卸通番
            band.Columns[InventInputResult.ct_Col_InventorySeqNo].Tag = InventInputResult.ct_Col_InventorySeqNo;
            // 倉庫コード
            band.Columns[InventInputResult.ct_Col_WarehouseCode].Tag = InventInputResult.ct_Col_WarehouseCode;
            // 倉庫名称
            band.Columns[InventInputResult.ct_Col_WarehouseName].Tag = InventInputResult.ct_Col_WarehouseName;
            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // メーカーコード
            band.Columns[InventInputResult.ct_Col_MakerCode].Tag = InventInputResult.ct_Col_MakerCode;
            // メーカー名称
            band.Columns[InventInputResult.ct_Col_MakerName].Tag = InventInputResult.ct_Col_MakerName;
            // 品番
            band.Columns[InventInputResult.ct_Col_GoodsNo].Tag = InventInputResult.ct_Col_GoodsNo;
            // 品名
            band.Columns[InventInputResult.ct_Col_GoodsName].Tag = InventInputResult.ct_Col_GoodsName;
            // 商品大分類コード
            band.Columns[InventInputResult.ct_Col_LargeGoodsGanreCode].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
            // 商品中分類コード
            band.Columns[InventInputResult.ct_Col_MediumGoodsGanreCode].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
            // 仕入先コード
            band.Columns[InventInputResult.ct_Col_SupplierCode].Tag = InventInputResult.ct_Col_SupplierCode;
            // 仕入先名称
            band.Columns[InventInputResult.ct_Col_SupplierName].Tag = InventInputResult.ct_Col_SupplierName;
            // 仕入先名称2
            band.Columns[InventInputResult.ct_Col_SupplierName2].Tag = InventInputResult.ct_Col_SupplierName2;
            // JANコード
            band.Columns[InventInputResult.ct_Col_Jan].Tag = InventInputResult.ct_Col_Jan;
            // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Tag = InventInputResult.ct_Col_StockUnitPrice;
            // 変更前仕入単価
            band.Columns[InventInputResult.ct_Col_BfStockUnitPrice].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
            // 仕入単価変更フラグ
            band.Columns[InventInputResult.ct_Col_StkUnitPriceChgFlg].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
            // 在庫区分
            band.Columns[InventInputResult.ct_Col_StockDiv].Tag = InventInputResult.ct_Col_StockDiv;
            // 最終仕入年月日
            band.Columns[InventInputResult.ct_Col_LastStockDate].Tag = InventInputResult.ct_Col_LastStockDate;
            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].Tag = InventInputResult.ct_Col_StockTotal;
            // 委託先コード
            band.Columns[InventInputResult.ct_Col_ShipCustomerCode].Tag = InventInputResult.ct_Col_ShipCustomerCode;
            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Tag = InventInputResult.ct_Col_InventoryStockCnt;
            // 棚卸過不足数
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            // 棚卸準備処理日付
            band.Columns[InventInputResult.ct_Col_InventoryPreprDay_Datetime].Tag = InventInputResult.ct_Col_InventoryPreprDay_Datetime;
            // 棚卸準備処理時間
            band.Columns[InventInputResult.ct_Col_InventoryPreprTim].Tag = InventInputResult.ct_Col_InventoryPreprTim;
            // 棚卸実施日
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // 棚卸実施日
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // 棚卸実施日(DateTime)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Tag = InventInputResult.ct_Col_InventoryDay_Year;
            // 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Tag = InventInputResult.ct_Col_InventoryDay_Month;
            // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Tag = InventInputResult.ct_Col_InventoryDay_Day;
            // 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Tag = InventInputResult.ct_Col_InventoryDay_DayL;
            // 棚卸更新日
            band.Columns[InventInputResult.ct_Col_LastInventoryUpdate].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
            // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_InventoryNewDiv].Tag = InventInputResult.ct_Col_InventoryNewDiv;
            // 棚卸新規追加区分名称
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Tag = InventInputResult.ct_Col_InventoryNewDivName;
            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDiv].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
            // 在庫委託受託区分名称
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
            // 集計区分
            band.Columns[InventInputResult.ct_Col_GrossDiv].Tag = InventInputResult.ct_Col_GrossDiv;
            // ボタン用カラム
            band.Columns[InventInputResult.ct_Col_Button].Tag = InventInputResult.ct_Col_Button;
            // 自行
            band.Columns[InventInputResult.ct_Col_RowSelf].Tag = InventInputResult.ct_Col_RowSelf;
            #endregion
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ データ表示UltraGrid初期処理(CellActivationプロパティ)
		/// <summary>
		/// データ表示UltraGrid初期処理(CellActivationプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_CellActivation( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 入力設定
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 入力設定 ------------------------------------------------------
            //// 製造番号
            //SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_ProductNumber );
            //// 商品電話番号1
            //SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo1 );
            //// 商品電話番号2
			//SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

		#region ◎ データ表示UltraGrid初期処理(Widthプロパティ)
		/// <summary>
		/// データ表示UltraGrid初期処理(Widthプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_Width( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 幅設定(コメントアウト中 )

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// Todo:幅設定コメントアウト中 ------------------------------------------------------
            //// 製造番号
            //band.Columns[ InventInputResult.ct_Col_ProductNumber ].Width = 200;
            //// 商品電話番号1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Width = 200;
            //// 商品電話番号2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Width = 200;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            #endregion

		}
		#endregion

		#region ◎ データ表示UltraGrid初期処理(CellClickActionプロパティ)
		/// <summary>
		/// データ表示UltraGrid初期処理(CellClickActionプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_CellClickAction( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// CellClickAction
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// CellClickAction ------------------------------------------------------
            //// 製造番号
            //SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_ProductNumber );
            //// 商品電話番号1
            //SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo1 );
            //// 商品電話番号2
			//SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

		#region ◎ データ表示UltraGrid初期処理(TabStopプロパティ)
		/// <summary>
		/// データ表示UltraGrid初期処理(TabStopプロパティ関連)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_TabStop( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// TabStop
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
            //band.Columns[ InventInputResult.ct_Col_ProductNumber ].TabStop = true;
            //// 電話番号1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].TabStop = true;
            //// 電話番号2
            //band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].TabStop = true;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

        #region ◆ カラムプロパティ設定処理
        #region ◎ CellActivationプロパティ設定処理
        /// <summary>
		/// CellActivationプロパティ設定処理
		/// </summary>
		/// <param name="columns">設定対象カラム</param>
		/// <param name="action">設定値</param>
		/// <param name="columnName">カラム名</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void SetCellActivation( ColumnsCollection columns, Infragistics.Win.UltraWinGrid.CellClickAction action, string columnName )
		{
			columns[ columnName ].CellClickAction = action;
		}
		#endregion

		#region ◎ CellClickActionプロパティ設定処理
		/// <summary>
		/// CellClickActionプロパティ設定処理
		/// </summary>
		/// <param name="columns">設定対象カラム</param>
		/// <param name="activation">設定値</param>
		/// <param name="columnName">カラム名</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void SetCellClickAction( ColumnsCollection columns, Infragistics.Win.UltraWinGrid.Activation activation, string columnName )
		{
			columns[ columnName ].CellActivation = activation;
		}
		#endregion

		#region ◎ データ表示UltraGrid初期処理(GroupSettingプロパティ関連)
		/// <summary>
		/// データ表示UltraGrid初期処理(GroupSettingプロパティ関連)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_GroupSetting( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// GroupSetting
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup;
            //
            //// 製造番号
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_ProductNumber ), band.Columns[InventInputResult.ct_Col_ProductNumber ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ProductNumber ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_ProductNumber;
            //
            //// 電話番号1
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo1 ), band.Columns[InventInputResult.ct_Col_StockTelNo1 ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo1 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo1;
            //
            //// 電話番号2
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo2 ), band.Columns[InventInputResult.ct_Col_StockTelNo2 ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo2 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo2;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion
        #endregion ◆ カラムプロパティ設定処理
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ ツールクリック処理
        /// <summary>
		/// ツールクリック処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">ツールクリックイベントで発生したイベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ツールバーがクリックされたときの処理を実行する。。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ToolBarsClickProc ( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			string clickButtonKey = e.Tool.Key;
			this.ug_ProductInventInput.PerformAction(UltraGridAction.ExitEditMode);
			try
			{
				switch ( e.Tool.Key )
				{
					case ct_Tool_Enter:			// MainToolBar - 確定
						{
							// メイン画面のクローズ
							this.DialogResult = DialogResult.OK;
							return;
						}
					case ct_Tool_Close:			// MainToolBar - 戻る
						{
							this.Close();
							break;
						}
				}
			}
			catch ( Exception ex )
			{
				this.MsgDispProc( ex.Message, (int)ConstantManagement.MethodResult.ctFNC_CANCEL, "SetAllRowSelecting", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
			}

		}
		#endregion

		#region ◎ キーマッピング設定処理
		/// <summary>
		/// グリッドキーマッピング作成処理
		/// </summary>
		/// <param name="grid">対象グリッド</param>
		/// <remarks>
		/// <br>Note       : グリッドに対してキーマッピングを作成します。</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void MakeGridKeyMapping( UltraGrid grid )
		{
			// wkKeyMapping = new GridKeyActionMapping( 
			//		Keys.Enter,							// 対象となるKey。このKeyが指定したときの動作を決める
			//		UltraGridAction.NextCellByTab,		// 対象のKeyが押されたときの動作
			//		UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox,	// Keyが押されても対象外となる場合の指定
			//		UltraGridState.Cell,				// 押された後のグリッドの状態
			//		SpecialKeys.All,					// 同時に押されても無視するKey。(このKeyが押されていると動作を実行しない。)
			//		SpecialKeys.Shift );				// 同時に押されないと動作をしないKey。(このKeyを同時に押したとき動作を実行する。)

//			grid.KeyActionMappings.Add( wkKeyMapping );

			
			GridKeyActionMapping wkKeyMapping = null;

			// Enterキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.NextCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Shift + Enterキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.PrevCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.AltCtrl, 
				SpecialKeys.Shift );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ↑キー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Up, 
				UltraGridAction.AboveCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ↓キー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Down, 
				UltraGridAction.BelowCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageUpキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Prior, 
				UltraGridAction.PageUpCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageDownキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Next, 
				UltraGridAction.PageDownCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Spaceキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Space, 
				UltraGridAction.ToggleRowSel, 
				0, 
				0, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

		}
		#endregion

		#region ◎ メッセージ表示処理
		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="iLevel">エラーレベル</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private DialogResult MsgDispProc( string message, emErrorLevel iLevel )
		{
			// メッセージ表示
			return TMsgDisp.Show( 
				this,                            // 親ウィンドウフォーム
				iLevel,                             // エラーレベル
				this.GetType().ToString(),          // アセンブリＩＤまたはクラスＩＤ
				message,                            // 表示するメッセージ
				0,                                  // ステータス値
				MessageBoxButtons.OK );             // 表示するボタン
		}

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="msg">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="proc">発生元メソッドID</param>
		/// <param name="iLevel">エラーレベル</param>
		/// <remarks>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, emErrorLevel iLevel )
		{
			return TMsgDisp.Show(
				iLevel,						        //エラーレベル
				"MAZAI05130UC",                       //UNIT　ID
				"棚卸入力",                            //プログラム名称
				proc,                               //プロセスID
				"",                                 //オペレーション
				msg,                                //メッセージ
				status,                             //ステータス
				null,                               //オブジェクト
				MessageBoxButtons.OK,               //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);
		}

		/// <summary>
		/// エラーMSG表示処理(Exception)
		/// </summary>
		/// <param name="msg">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="proc">発生元メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <param name="iLevel">エラーレベル</param>
		/// <remarks>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, Exception ex, emErrorLevel iLevel )
		{
			return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
		}
		#endregion

        #region DEl 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ KeyPress処理
		/// <summary>
		/// KeyPress処理
		/// </summary>
		/// <param name="sender">対象オブジェクト(Grid KeyDown Eventのsender)</param>
		/// <param name="e">イベントパラメータ</param>
		public void KeyPressProc( object sender, ref KeyPressEventArgs e )
		{
			//アクティブセル
			Infragistics.Win.UltraWinGrid.UltraGridCell	activeCell = ((UltraGrid)sender).ActiveCell;

			// グロス区分
			//アクティブセルがあったら
			if (activeCell != null)
			{
				if (activeCell.IsInEditMode == false) return;


                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //switch (activeCell.Column.Key)
				//{
				//	case InventInputResult.ct_Col_ProductNumber			:	// 製造番号
				//		// 入力文字が小文字か
				//		if ( Char.IsLower( e.KeyChar ) )
				//		{
				//			e.KeyChar = Char.ToUpper( e.KeyChar );
				//		}
				//		if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false ) == false)
				//		{
				//			e.Handled = true;
				//			return;
				//		}
				//		break;
				//	case InventInputResult.ct_Col_StockTelNo1			:	// 電話番号1
				//	case InventInputResult.ct_Col_StockTelNo2			:	// 電話番号2
				//		if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false ) == false)
				//		{
				//			e.Handled = true;
				//			return;
				//		}
				//		break;
				//}
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            }	
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEl 2008/09/01 使用していないのでコメントアウト

        #region ◎ KeyDownProc処理
        /// <summary>
		/// KeyDownProc処理
		/// </summary>
		/// <param name="sender">対象オブジェクト(Grid KeyDown Eventのsender)</param>
		/// <param name="e">イベントパラメータ</param>
		public void KeyDownProc( object sender, ref KeyEventArgs e )
		{
			// 編集中の場合
			UltraGrid targetGrid = (UltraGrid)sender;
			if( ( targetGrid.ActiveCell != null ) && ( targetGrid.ActiveCell.IsInEditMode == true ) ) 
			{
				// セルスタイルで判定
				switch( e.KeyData ) 
				{
					case Keys.Up	:	// ↑キー
					{								
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
						// アクティブになったセルを編集モードにする
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Down:
					{
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
						// アクティブになったセルを編集モードにする
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					// ←キー
					case Keys.Left:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// 編集中なら何もしない
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart != 0)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab );
						e.Handled = true;
						break;
					}
					// →キー
					case Keys.Right:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// 編集中なら何もしない
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart < targetGrid.ActiveCell.Text.Length)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab );
						e.Handled = true;
						break;
					}
					case Keys.Enter:
					{
						// EnterKeyが押されたときはTRetKeyContorolで制御される
						// アクティブになったセルを編集モードにする
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Escape:	// ESCキー
					{
						break;
					}
				}
			}
			else
			{
				switch( e.KeyData )
				{
					case Keys.Escape:	// ESCキー
					{
						break;
					}

				}
			}
		}
		#endregion

		#region ◎ 数値入力チェック処理
		/// <summary>
		/// 数値入力チェック処理
		/// </summary>
		/// <param name="keta">桁数(マイナス符号を含まず)</param>
		/// <param name="priod">小数点以下桁数</param>
		/// <param name="prevVal">現在の文字列</param>
		/// <param name="key">入力されたキー値</param>
		/// <param name="selstart">カーソル位置</param>
		/// <param name="sellength">選択文字長</param>
		/// <param name="minusFlg">マイナス入力可？</param>
		/// <returns>true=入力可,false=入力不可</returns>
		public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key) == true)
			{
			    return true;
			}
			//// 数値以外は、ＮＧ
			//if (Char.IsNumber(key) == false)
			//{
			//    return false;
			//}

			// キーが押されたと仮定した場合の文字列を生成する。
			string	_strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			//// マイナスのチェック
			//if (key == '-')
			//{
			//    if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
			//    {
			//        return false;
			//    }
			//}

			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart) 
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));

			// 桁数チェック！
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// 小数点以下のチェック
			if (priod > 0)
			{
				// 小数点の位置決定
				int _pointPos = _strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				int	_Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// 整数部の桁数をチェック
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (_pointPos != -1)
				{
					// 小数部の桁数を計算
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion

		#endregion ■ Private Method

		#region ■ Private Event
		#region ◆ MAZAI05130UC Event
		#region ◎ Load Event
		/// <summary>
		/// Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void MAZAI05130UC_Load ( object sender, EventArgs e )
		{
			// 画面初期処理
			InitialScreen();

			this.timer1.Enabled = true;
		}
		#endregion

		#region ◎ FormClosing Event
		/// <summary>
		/// MAZAI05130UC_FormClosing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォーム閉じるたびに発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void MAZAI05130UC_FormClosing ( object sender, FormClosingEventArgs e )
		{
		}
		#endregion
		#endregion ◆ MainForm Event

		#region ◆ tce_Fontsize ComboBox Event
		#region ◎ tce_FontSize_ValueChanged Event
		/// <summary>
		/// ValueChanged Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールの値が変更されたとき発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void tce_FontSize_ValueChanged ( object sender, EventArgs e )
		{
			// 文字サイズを変更
			this.ug_ProductInventInput.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tce_FontSize.Value;
		}
		#endregion
		#endregion ◆ Timer Event

		#region ◆ utm_MainToolBarsMng ToolBarsManage Event
		#region ◎ utm_DataViewToolBarsMng_ToolClick Event
		/// <summary>
		/// utm_DataViewToolBarsMng_ToolClick Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ツールがクリックされたとき発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void utm_MainToolBarsMng_ToolClick ( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			this.ToolBarsClickProc( sender, e );
		}
		#endregion
		#endregion ◆ utm_MainToolBarsMng ToolBarsManage Event

		#region ◆ utm_DataViewToolBarsMng ToolBarsManage Event
		#region ◎ utm_DataViewToolBarsMng_ToolClick Event
		/// <summary>
		/// utm_DataViewToolBarsMng_ToolClick Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ツールがクリックされたとき発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void utm_DataViewToolBarsMng_ToolClick ( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			this.ToolBarsClickProc( sender, e );
		}
		#endregion
		#endregion ◆ utm_DataViewToolBarsMng ToolBarsManage Event

		#region ◆ ug_ProductInventInput Event
		#region ◎ InitializeRow
		/// <summary>
		/// InitializeRow Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <returns>在庫状況</returns>
		/// <remarks>
		/// <br>Note		: 行が初期化されたときに発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_InitializeRow ( object sender, InitializeRowEventArgs e )
		{
		}
		#endregion

		#region ◎ CellChange Event
		/// <summary>
		/// CellChange Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 編集モードにあるセルの値をユーザーが変更したときに発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_CellChange ( object sender, CellEventArgs e )
		{
			//// アクティブセルが有効
			//if( this.ug_ProductInventInput.ActiveCell != null )
			//{
			//    // NetAdvantage 不具合のためのロジック
				
			//    // 現在のセルを取得
			//    UltraGridCell currentCell = this.ug_ProductInventInput.ActiveCell;

			//    // 現在のアクティブセルのスタイルがEditの場合
			//    if ( currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit )
			//    {
			//        // 変更された結果、Textが空白となった場合
			//        if( ( currentCell.Text == null ) || ( currentCell.Text.Trim() == "" ) ) 
			//        {
			//            // 現在のセルの型が、Int32、Int64、double型の場合
			//            if ((currentCell.Column.DataType == typeof(Int32)) ||
			//                (currentCell.Column.DataType == typeof(Int64)) ||
			//                (currentCell.Column.DataType == typeof(double)))
			//            {
			//                // 値を空白とはせずに、"0"をセットする
			//                currentCell.Value = 0;
			//            }
			//        }
			//    }

			//    // 棚卸数が変更されている場合に変更フラグをTrueにする
			//    if ( currentCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt ) == 0 )
			//    {
			//        this._isChangeInventStcCnt = true;
			//        this._isChangeInventDate = false;
			//    }
			//    // 棚卸日が変更されている場合には変更フラグをTrueにする
			//    else if ( ( currentCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year ) == 0 ) || 
			//        ( currentCell.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Month ) == 0 ) || 
			//        ( currentCell.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day ) == 0 ) )
			//    {
			//        this._isChangeInventStcCnt = false;
			//        this._isChangeInventDate = true;
			//    }

			//}
		}
		#endregion

		#region ◎ CellDataError Event
		/// <summary>
		/// uce_ColSizeAutoSetting_CheckedChanged Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 不正な値が入力された状態でセルを更新しようとすると発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_CellDataError ( object sender, CellDataErrorEventArgs e )
		{
			// アクティブセルが有効
			if( this.ug_ProductInventInput.ActiveCell != null )
			{
				// NetAdvantage 不具合のためのロジック
				
				// 現在のセルを取得
				UltraGridCell currentCell = this.ug_ProductInventInput.ActiveCell;

				// 現在のアクティブセルのスタイルがEditの場合
				if ( currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit )
				{
					// 変更された結果、Textが空白となった場合
					if( ( currentCell.Text == null ) || ( currentCell.Text.Trim() == "" ) ) 
					{
						// 現在のセルの型が、Int32、Int64、double型の場合
						if ((currentCell.Column.DataType == typeof(Int32)) ||
							(currentCell.Column.DataType == typeof(Int64)) ||
							(currentCell.Column.DataType == typeof(double)))
						{
							// 値を空白とはせずに、"0"をセットする
							currentCell.Value = 0;
							// 値を空白とせずに0をセットする
							e.RaiseErrorEvent		= false;
							e.RestoreOriginalValue	= true;
							e.StayInEditMode		= true;

						}
					}
				}
			}
		}
		#endregion

		#region ◎ AfterPerformAction Event
		/// <summary>
		/// AfterPerformAction Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: AfterPerformActionイベントは、キーアクションのマッピングに関連付けられたアクションが実行された後に発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_AfterPerformAction ( object sender, AfterUltraGridPerformActionEventArgs e )
		{
			switch( e.UltraGridAction ) 
			{
				case UltraGridAction.ActivateCell:
				case UltraGridAction.AboveCell:
				case UltraGridAction.BelowCell:
				case UltraGridAction.PrevCell:
				case UltraGridAction.NextCell:
				case UltraGridAction.PageUpCell:
				case UltraGridAction.PageDownCell:
				{
					// アクティブセルが有効
					if( this.ug_ProductInventInput.ActiveCell != null )
					{
						// 編集モードへ移行
						this.ug_ProductInventInput.PerformAction( UltraGridAction.EnterEditMode );
					}

					break;
				}
			}
		}

		#endregion

		#region ◎ KeyDown Event
		/// <summary>
		/// KeyDown Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールにフォーカスがあるときにキーが押されると発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_KeyDown ( object sender, KeyEventArgs e )
		{
			KeyDownProc( sender, ref e );
		}
		#endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ KeyPress Event
		/// <summary>
		/// KeyPress Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ug_ProductInventInput_KeyPress ( object sender, KeyPressEventArgs e )
		{
			KeyPressProc( sender, ref e );	
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ Enter Event
        /// <summary>
		/// Enter Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールが入力されると発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_Enter ( object sender, EventArgs e )
		{
			if( this.ug_ProductInventInput.ActiveCell == null ) {
				this.ug_ProductInventInput.PerformAction( UltraGridAction.EnterEditMode );
			}
		}
		#endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ ug_ProductInventInput_AfterExitEditMode
		/// <summary>
		/// ug_ProductInventInput_AfterExitEditMode
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セルが編集モードを終了したときに発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_AfterExitEditMode ( object sender, EventArgs e )
		{
			//Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.ug_ProductInventInput.ActiveCell;

			//if ( activeCell == null ) return;
			//try
			//{
			//    bool isShowProduct = false;

			//    ((MAZAI05130UB)this._parentForm).AfterExitEditModeProc( activeCell, sender, this._isChangeInventStcCnt, this._isChangeInventDate, isShowProduct );
			//}
			//finally
			//{
			//    this.ug_ProductInventInput.UpdateData();	// グリッドを更新
			//    this.ug_ProductInventInput.DataBind();		// データソースの再バインド
			//    this.ug_ProductInventInput.UpdateMode = UpdateMode.OnCellChange;
			//    this._isChangeInventStcCnt = false;
			//    this._isChangeInventDate = false;
			//}

		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト
        
        #region ◎ ug_ProductInventInput_AfterCellActivate
        /// <summary>
		/// ug_ProductInventInput_AfterCellActivate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note		: セルがアクティブになった後に発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_AfterCellActivate ( object sender, EventArgs e )
		{
			if ((((UltraGrid)sender).ActiveCell != null) &&
				(((UltraGrid)sender).ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
			{
				// 編集モードにする
				((UltraGrid)sender).PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
			}
		}
		#endregion
		#endregion ug_ProductInventInput Event

		#region ◆ tRetKeyControl　Event
		#region ◎ ChangeFocus Event
		/// <summary>
		/// ChangeFocus Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーカスが遷移する場合に発生する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void tRetKeyControl_ChangeFocus ( object sender, ChangeFocusEventArgs e )
		{
			
			if( ( e.PrevCtrl == null ) || 
			    ( e.NextCtrl == null ) ) {
			    return;
			}

			try
			{
			
				this.ug_ProductInventInput.BeginUpdate();

				// 抽出結果グリッドの場合
				if( e.PrevCtrl.Equals( this.ug_ProductInventInput ) == true )
				{
					// アクティブセルが有効
					if( this.ug_ProductInventInput.ActiveCell != null ) 
					{
						// 入力されたキーで判定
						// Enterキー
						if( ( e.Key == Keys.Enter ) && 
							( ( e.ShiftKey == false ) && ( e.ControlKey == false ) && ( e.AltKey == false ) ) ) 
						{

							if ( this.ug_ProductInventInput.ActiveRow.Index == this.ug_ProductInventInput.Rows.Count -1 )
							{
								// 最終行の電話番号2だったらカラムサイズコンボボックスに移動
                                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                //if (this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockTelNo2) == 0)
								//{
								//	this.tce_FontSize.Focus();
								//}
								//else
								//{
                                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                    //// 次のセルへ移動
									//this.ug_ProductInventInput.PerformAction( UltraGridAction.BelowCell );
									// キーが押されたときのActiveCellによって動作を変える
									switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
									{
                                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                        //case InventInputResult.ct_Col_ProductNumber:	// 製番在庫
										//case InventInputResult.ct_Col_StockTelNo1:	// 電話番号1
										//	this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell );	// 下に移動
										//	break;
										//case InventInputResult.ct_Col_StockTelNo2:	// 電話番号2
										//	// 製造番号をアクティブにしてから下に移動
										//	if ( this.ug_ProductInventInput.ActiveRow != null )
										//	{
										//		this.ug_ProductInventInput.ActiveRow.Cells[ InventInputResult.ct_Col_ProductNumber ].Activate();
                                        //		this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
                                        //	}
                                        //	break;
                                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                        default:
											this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
										break;
									}
								//}
							}
							else
							{
								//// 次のセルへ移動
								// キーが押されたときのActiveCellによって動作を変える
								switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
								{
                                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                    //case InventInputResult.ct_Col_ProductNumber:	// 製番在庫
                                    //case InventInputResult.ct_Col_StockTelNo1:	// 電話番号1
                                    //	this.ug_ProductInventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);	// 下に移動
                                    //	break;
									//case InventInputResult.ct_Col_StockTelNo2:	// 電話番号2
									//	// 製造番号をアクティブにしてから下に移動
									//	if ( this.ug_ProductInventInput.ActiveRow != null )
									//	{
                                    //		this.ug_ProductInventInput.ActiveRow.Cells[InventInputResult.ct_Col_ProductNumber].Activate();
                                    //		this.ug_ProductInventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                    //	}
                                    //	break;
                                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                    default:
										this.ug_ProductInventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
										break;
								}
							}
							e.NextCtrl = null;
						}
					}
					// Shift + Enterキー
					else if( ( e.Key == Keys.Enter ) && 
						( ( e.ShiftKey == true ) && ( e.ControlKey == false ) && ( e.AltKey == false ) ) ) 
					{
						if ( this.ug_ProductInventInput.ActiveRow.Index == 0 )
						{
							if ( ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year ) == 0 ) ||
								( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryTolerancCnt ) == 0 ))
							{
								// 先頭行の場合
								this.tce_FontSize.Focus();
							}
							else
							{
								//// 前のセルへ移動
								//this.ug_ProductInventInput.PerformAction( UltraGridAction.AboveCell );
								// キーが押されたときのActiveCellによって動作を変える
								switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
								{
                                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                    //case InventInputResult.ct_Col_ProductNumber:	// 製番在庫
									//	// 電話番号2をアクティブにしてから上に移動
									//	if ( this.ug_ProductInventInput.ActiveRow != null )
									//	{
                                    //		this.ug_ProductInventInput.ActiveRow.Cells[ InventInputResult.ct_Col_StockTelNo2 ].Activate();
                                    //		this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
                                    //	}
                                    //	break;
                                    //case InventInputResult.ct_Col_StockTelNo1:	// 電話番号1
                                    //case InventInputResult.ct_Col_StockTelNo2:	// 電話番号2
                                    //	this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell );	// 下に移動
                                    //	break;
                                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                    default:
										this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
										break;
								}
							}
						}
						else
						{
							//// 前のセルへ移動
							//this.ug_ProductInventInput.PerformAction( UltraGridAction.AboveCell );
							// キーが押されたときのActiveCellによって動作を変える
							switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
							{
                                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                //case InventInputResult.ct_Col_ProductNumber:	// 製番在庫
								//	// 電話番号2をアクティブにしてから上に移動
								//	if ( this.ug_ProductInventInput.ActiveRow != null )
								//	{
                                //		this.ug_ProductInventInput.ActiveRow.Cells[ InventInputResult.ct_Col_StockTelNo2 ].Activate();
                                //		this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
                                //	}
                                //	break;
                                //case InventInputResult.ct_Col_StockTelNo1:	// 電話番号1
                                //case InventInputResult.ct_Col_StockTelNo2:	// 電話番号2
                                //	this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell );	// 下に移動
                                //	break;
                                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                default:
									this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
									break;
							}
						}
						e.NextCtrl = null;
					}
				}
				else if ( e.NextCtrl.Equals( this.ug_ProductInventInput ) )
				{
					if ( e.PrevCtrl.Equals( this.tce_FontSize ) )
					{
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //// 最終行の棚卸数
						//if( this.ug_ProductInventInput.ActiveCell == null ) 
						//{
						//	this.ug_ProductInventInput.ActiveCell = 
						//		this.ug_ProductInventInput.Rows[ 0 ].Cells[InventInputResult.ct_Col_ProductNumber];
						//}
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        this.ug_ProductInventInput.PerformAction(UltraGridAction.EnterEditMode);
					}
				}
			}
			finally
			{
				this.ug_ProductInventInput.EndUpdate();
			}
			return;

		}
		#endregion
		#endregion ◆　tRetKeyControl　Event

		private void timer1_Tick ( object sender, EventArgs e )
		{
			this.timer1.Enabled = false;
			if (this.ug_ProductInventInput.ActiveCell != null)
			{
				if (ug_ProductInventInput.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
				{
					ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
				}
			}
		}

		#endregion ■ Private Event
	}
}