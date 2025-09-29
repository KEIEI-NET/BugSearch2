//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信ＵＩ処理 明細コントロールクラス
// プログラム概要   : ＵＯＥ手入力発注を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 袁磊
// 修 正 日  2012/08/30  修正内容 : 2012/09/12配信分、Redmine#31884 
//                                  手入力発注処理修正の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＵＯＥ手入力発注 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＵＯＥ手入力発注の明細入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2008.05.12</br>
    /// <br></br>
    /// <br>UpdateNote :</br>
    /// <br>Update Note: 2012/08/30 袁磊</br>
    /// <br>管理番号   : 10801804-00 2012/09/12配信分</br>
    /// <br>             Redmine#31884 手入力発注処理修正の対応</br>
    /// <br></br>
    /// </remarks>
	public partial class PMUOE01101UB : UserControl 
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constroctors
		/// <summary>
		/// 明細入力コントロールクラス デフォルトコンストラクタ
		/// </summary>
		public PMUOE01101UB()
		{
			InitializeComponent();

			// ボタン初期化
			this._rowInsertButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowInsert"];
			this._rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowDelete"];
			this._rowCutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCut"];
			this._rowCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCopy"];
			this._rowPasteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowPaste"];

			//イメージ初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			// アクセスクラス初期化
			this._stockInputAcs = StockInputAcs.GetInstance();
			this._stockInputInitDataAcs = StockInputInitDataAcs.GetInstance();

			//データテーブル初期化
			this._orderDataTable = this._stockInputAcs.orderDataTable;

			//データテーブル列表示設定クラスセッティング処理
			this.SettingStockExpansionRowVisibleControl();           
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//環境値
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _updEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
		private string _updEmployeeName = LoginInfoAcquisition.Employee.Name.Trim();

		//アクセスクラス
		private StockInputAcs _stockInputAcs;
		private StockInputInitDataAcs _stockInputInitDataAcs;

		//データテーブル
		private StockInputDataSet.OrderExpansionDataTable _orderDataTable;
		private ProductStockRowVisibleControl _productStockRowVisibleControl = new ProductStockRowVisibleControl();
		private int _verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;

		//グリッド入力前値
		private string	_beforeGoodsNo = "";			//品番
		private double	_beforeAcceptAnOrderCnt = 0;	//数量
		private string	_beforeBoCode = "";				//ＢＯ区分
		private string	_beforeGoodsMakerCd = "";		//メーカー(優良)
		private Int32	_beforeMakerName = 0;			//メーカー(純正)
		private Int32	_beforeBLGoodsCode = 0;			//BL商品コード
		private string	_beforeGoodsName = "";			//品名

		//グリッド移動可能値
		private bool _cannotGoodsNo = false;			//品番
		private bool _cannotAcceptAnOrderCnt = false;	//数量
		private bool _cannotBoCode = false;				//ＢＯ区分
		private bool _cannotGoodsMakerCd = false;		//メーカー(優良)
		private bool _cannotMakerName = false;			//メーカー(純正)
		private bool _cannotBLGoodsCode = false;		//BL商品コード
		private bool _cannotGoodsName = false;			//品名

		//ガイド表示時の選択行index
		private int _selectedRowBeforeGuide = 0;

		// BO区分 表示初期値
		private string _defaultBoCode = "";

		//グリッド初期表示
		// 1:優良 2:純正
		private int _defaultSettingGridCol = 2;

        // 業務区分
        private StatusType _defaultStatusType = StatusType.ct_Order;


		//発注先コード
		private int _defaultUOESupplierCd = 0;

		// 発注可能メーカーコード
		private List<int> _defaultEnableOdrMakerCd = new List<int>();

		//ボタン定義
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowInsertButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDeleteButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCutButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCopyButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowPasteButton;

		//イメージ定義
		private ImageList _imageList16 = null;
		private Image _guideButtonImage;

		//カラー定義
		private static readonly Color DISABLE_COLOR = Color.Gainsboro;
		private static readonly Color DISABLE_FONT_COLOR = Color.Black;
		private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
		private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
		private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
		private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
		private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//入力メッセージ
		private const string MESSAGE_GoodsNo = "品番を入力してください。";			//品番
		private const string MESSAGE_AcceptAnOrderCnt = "数量を入力してください。";	//数量
        private const string MESSAGE_BoCode = "ＢＯ区分を入力してください。";		//ＢＯ区分
		private const string MESSAGE_GoodsMakerCd = "メーカーを入力してください。";	//メーカー(優良)
		private const string MESSAGE_MakerName = "メーカーを選択してください。";	//メーカー(純正)
		private const string MESSAGE_BLGoodsCode = "ＢＬコードを入力してください。";//BL商品コード
		private const string MESSAGE_GoodsName = "品名を入力してください。";		//品名
		# endregion

		// ===================================================================================== //
			// デリゲート
		// ===================================================================================== //
		# region Delegate
		/// <summary>
		/// ステータスバーメッセージ表示デリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="message">表示メッセージ</param>
		internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);

		/// <summary>
		/// フォーカス設定デリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="itemName">項目名称</param>
		internal delegate void SettingFocusEventHandler(object sender, string itemName);

		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>グリッド最上位行キーダウンイベント</summary>
		internal event EventHandler GridKeyDownTopRow;
		
		/// <summary>グリッド最下層行キーダウンイベント</summary>
		internal event EventHandler GridKeyDownButtomRow;
		
		/// <summary>ステータスバーメッセージ表示イベント</summary>
		internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;

		/// <summary>フォーカス設定イベント</summary>
		internal event SettingFocusEventHandler FocusSetting;

		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		# endregion

		// ===================================================================================== //
		// プライベート・インターナルメソッド
		// ===================================================================================== //
		# region Private Methods and Internal Methods

		# region Returnキーダウン処理
		/// <summary>
		/// Returnキーダウン処理
		/// </summary>
		/// <returns>true:セル移動完了 false:セル移動失敗</returns>
		internal bool ReturnKeyDown()
		{
			if (this.uGrid_Details.ActiveCell == null) return false;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

			bool canMove = true;

			# region 商品コード
			// ActiveCellが商品コードの場合 -----------------------------------------------------------
			if (cell.Column.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				// ActiveCellが変更していない場合はNextCellを実行する
				if (this.uGrid_Details.ActiveCell.Column.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
				{
					if (this._orderDataTable[cell.Row.Index].InpGoodsNo == "")
					{
						if (this._cannotGoodsNo)
						{
							// 商品情報の取得に失敗した場合はPerformActionを実行しない
							this._cannotGoodsNo = false;
						}
						else
						{
							canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
						}
					}
					else
					{
						//数量へ移動
						canMove = this.MoveNextAllowEditCell(false);

						//this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName];
						//this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
					}
				}
			}
			# endregion

			# region 数量
			// 数量
			else if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
            {
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				if (this._cannotAcceptAnOrderCnt)
                {
					this._cannotAcceptAnOrderCnt = false;
                }
                else
                {
                    canMove = this.MoveNextAllowEditCell(false);
                }
			}
			# endregion

			# region ＢＯ区分
			//ＢＯ区分
			else if (cell.Column.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				// ActiveCellが変更していない場合はNextCellを実行する
				if (this.uGrid_Details.ActiveCell.Column.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
				{
					if (this._orderDataTable[cell.Row.Index].InpBoCode == "")
					{
						// ＢＯ区分の取得に失敗した場合はPerformActionを実行しない
						if (this._cannotBoCode)
						{
							this._cannotBoCode = false;
						}
						else
						{
							canMove = this.MoveNextAllowEditCell(false);
						}
					}
					else
					{
						canMove = this.MoveNextAllowEditCell(false);
					}
				}
			}
			# endregion

			# region メーカー(優良)
			// メーカー(優良)の場合 -----------------------------------------------------------
			else if (cell.Column.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				// ActiveCellが変更していない場合はNextCellを実行する
				if (this.uGrid_Details.ActiveCell.Column.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
				{
					if (this._orderDataTable[cell.Row.Index].GoodsMakerCd == 0)
					{
						if (this._cannotGoodsMakerCd)
						{
							// メーカー情報の取得に失敗した場合はPerformActionを実行しない
							this._cannotGoodsMakerCd = false;
						}
						else
						{
							canMove = this.MoveNextAllowEditCell(false);
						}
					}
					else
					{
						//this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName];
						//this.MoveNextAllowEditCell(true);
						canMove = this.MoveNextAllowEditCell(false);
					}
				}
			}
			# endregion

			# region メーカー(純正)
			// メーカー(純正)の場合 -----------------------------------------------------------
			else if (cell.Column.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				// ActiveCellが変更していない場合はNextCellを実行する
				if (this.uGrid_Details.ActiveCell.Column.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
				{
					if (this._orderDataTable[cell.Row.Index].MakerName == "")
					{
						if (this._cannotMakerName)
						{
							// メーカー情報の取得に失敗した場合はPerformActionを実行しない
							this._cannotMakerName = false;
						}
						else
						{
							canMove = this.MoveNextAllowEditCell(false);
						}
					}
					else
					{
						canMove = this.MoveNextAllowEditCell(false);
					}
				}
			}
			# endregion

			# region ＢＬコード
			// ＢＬコードの場合 -----------------------------------------------------------
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				// ActiveCellが変更していない場合はNextCellを実行する
				if (this.uGrid_Details.ActiveCell.Column.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
				{
					if (this._orderDataTable[cell.Row.Index].InpBLGoodsCode == 0)
					{
						if (this._cannotBLGoodsCode)
						{
							// 情報の取得に失敗した場合はPerformActionを実行しない
							this._cannotBLGoodsCode = false;
						}
						else
						{
							canMove = this.MoveNextAllowEditCell(false);
						}
					}
					else
					{
						//this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName];
						//this.MoveNextAllowEditCell(true);
						canMove = this.MoveNextAllowEditCell(false);
					}
				}
			}
			# endregion

			# region 商品名称
			// ActiveCellが商品名称の場合 -------------------------------------------------------------
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName)
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				// ActiveCellが変更していない場合はNextCellを実行する
				if (this.uGrid_Details.ActiveCell.Column.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName)
				{
					if (this._orderDataTable[cell.Row.Index].InpBLGoodsName == "")
					{
						// 取得に失敗した場合はPerformActionを実行しない
						if (this._cannotGoodsName)
						{
							this._cannotGoodsName = false;
						}
						else
						{
							canMove = this.MoveNextAllowEditCell(false);
						}
					}
					else
					{
						canMove = this.MoveNextAllowEditCell(false);
					}
				}
			}
			# endregion

			# region 次入力可能セル移動処理
			// 次入力可能セル移動処理
			else
            {
                canMove = this.MoveNextAllowEditCell(false);
            }
			# endregion

			return canMove;
		}
		# endregion

		# region 次入力可能セル移動処理
		/// <summary>
		/// 次入力可能セル移動処理
		/// </summary>
		/// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
		/// <returns>true:セル移動完了 false:セル移動失敗</returns>
		private bool MoveNextAllowEditCell(bool activeCellCheck)
		{
            bool moved = false;
			bool performActionResult = false;

            try {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

			    if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
			    {
				    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
					    (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
					    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
				    {
					    moved = true;
				    }
			    }

			    while (!moved)
			    {
				    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

				    if (performActionResult)
				    {
					    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
						    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
					    {
						    moved = true;
					    }
					    else
					    {
						    moved = false;
					    }
				    }
				    else
				    {
					    break;
				    }
			    }

			    if (moved)
			    {
				    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
			    }
            }
            finally {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

			return performActionResult;
		}
		# endregion

		# region データテーブル列表示設定クラスセッティング処理
		/// <summary>
		/// データテーブル列表示設定クラスセッティング処理
		/// </summary>
		private void SettingStockExpansionRowVisibleControl()
		{
            //ColumunName , Type , Mode , Hidden
			//1:優良 2:純正

			//[番号]
			# region [番号]
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion

			//[品番]
			# region [品番]
			//[品番]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion

			//[商品ガイド] 
			# region [商品ガイド]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName, StatusType.ct_Order, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName, StatusType.ct_Order, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName, StatusType.ct_Estmt, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName, StatusType.ct_Estmt, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName, StatusType.ct_Stock, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName, StatusType.ct_Stock, 2, true);
            # endregion

			//[数量]
			# region [数量]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.ct_Estmt, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.ct_Stock, 2, true);
            # endregion

			//[ＢＯ区分]
			# region [ＢＯ区分]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.ct_Estmt, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.ct_Estmt, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.ct_Stock, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.ct_Stock, 2, true);
            # endregion

			//[ﾒｰｶｰ(優良)]
			# region [ﾒｰｶｰ(優良)]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsMakerCdColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsMakerCdColumn.ColumnName, StatusType.ct_Order, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsMakerCdColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsMakerCdColumn.ColumnName, StatusType.ct_Estmt, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsMakerCdColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpGoodsMakerCdColumn.ColumnName, StatusType.ct_Stock, 2, true);
            # endregion

			//[ﾒｰｶｰ(純正)]
			# region [ﾒｰｶｰ(純正)]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerNameColumn.ColumnName, StatusType.ct_Order, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerNameColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerNameColumn.ColumnName, StatusType.ct_Estmt, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerNameColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerNameColumn.ColumnName, StatusType.ct_Stock, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerNameColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion

			//[ＢＬコード]
			# region [ＢＬコード]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsCodeColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsCodeColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsCodeColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsCodeColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsCodeColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsCodeColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion

			//[品名]
			# region [品名]
			//[品名]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsNameColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsNameColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsNameColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsNameColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsNameColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBLGoodsNameColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion

			//[現在庫数]
			# region [現在庫数]
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspStockCntColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspStockCntColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspStockCntColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspStockCntColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspStockCntColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspStockCntColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion

			//[倉庫]
			# region [倉庫]
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseNameColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseNameColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseNameColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseNameColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseNameColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseNameColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion

			//[棚番]
			# region [棚番]
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName, StatusType.ct_Order, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName, StatusType.ct_Order, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName, StatusType.ct_Estmt, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName, StatusType.ct_Estmt, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName, StatusType.ct_Stock, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName, StatusType.ct_Stock, 2, false);
            # endregion
		}
		# endregion

		# region  グリッド列表示幅設定処理
		/// <summary>
		/// グリッド列表示幅設定処理
		/// </summary>
		private void SettingGridColWidth()
		{
			int totalWidth = this.uGrid_Details.DisplayLayout.Override.RowSelectorWidth;
			int lastColumnIndex = 0;
			int visiblePosition = 0;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
			{
				if (!column.Hidden)
				{
					totalWidth += column.Width;

					if (visiblePosition < column.Header.VisiblePosition)
					{
						visiblePosition = column.Header.VisiblePosition;
						lastColumnIndex = column.Index;
					}
				}
			}

			int difference = (this.uGrid_Details.Width - this._verticalScrollBarWidth) - totalWidth - 2;		// -2は微調整

			if ((difference > 0) && (difference < this._verticalScrollBarWidth))
			{
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[lastColumnIndex].Width += difference;
			}
		}
		# endregion

        # region 明細グリッド設定処理
        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        /// <param name="statusType">業務区分</param>
        /// <param name="settingGridCol">1:優良 2:純正</param>
        internal void SettingGrid(StatusType statusType, int settingGridCol)
        {
            _defaultStatusType = statusType;
            _defaultSettingGridCol = settingGridCol;
            SettingGrid();
        }

        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        internal void SettingGrid()
		{
			try
			{
				// 描画を一時停止
				this.uGrid_Details.BeginUpdate();

    			this.tToolbarsManager_Main.Enabled = true;

				// グリッド列表示非表示設定処理
                this.SettingGridColVisible(_defaultStatusType, _defaultSettingGridCol);

				// 描画が必要な明細件数を取得する。
				int cnt = this._orderDataTable.Count;

				// 各行ごとの設定
				for (int i = 0; i < cnt; i++)
				{
                    this.SettingGridRow(i);
				}

				// 表示用行番号調整処理
				this._stockInputAcs.AdjustRowNo();
			}
			finally
			{
				// 描画を開始
				this.uGrid_Details.EndUpdate();
			}
		}
		# endregion

		# region グリッドのリストセット処理
		/// <summary>
		/// グリッドのリストセット処理
		/// </summary>
		public void SetGridList(UOESupplier uOESupplier)
		{
			_defaultEnableOdrMakerCd.Clear();

			if (uOESupplier != null)
			{
				_defaultUOESupplierCd = uOESupplier.UOESupplierCd;	// UOE発注先コード

				// 発注可能メーカーコード
				for (int i = 0; i < 6; i++)
				{
					int makerCd = 0;
					switch (i)
					{
						case 0:
							makerCd = uOESupplier.EnableOdrMakerCd1;
							break;
						case 1:
							makerCd = uOESupplier.EnableOdrMakerCd2;
							break;
						case 2:
							makerCd = uOESupplier.EnableOdrMakerCd3;
							break;
						case 3:
							makerCd = uOESupplier.EnableOdrMakerCd4;
							break;
						case 4:
							makerCd = uOESupplier.EnableOdrMakerCd5;
							break;
						case 5:
							makerCd = uOESupplier.EnableOdrMakerCd6;
							break;
					}
					if (makerCd == 0) continue;

					//メーカー名取得
					_defaultEnableOdrMakerCd.Add(makerCd);
				}
			}
			else
			{
				_defaultUOESupplierCd = 0;
			}

            //ＢＯ区分
            _defaultBoCode = "";	//BO区分(初期値)
            List<UOEGuideName> ListBoCode = this._stockInputInitDataAcs.GetList_FromUOEGuideName(1, _defaultUOESupplierCd);
            if (ListBoCode.Count > 0)
            {
                _defaultBoCode = this._stockInputInitDataAcs.GetDefaultUOEGuideCode(ListBoCode, uOESupplier.BoCode);
            }

			//メーカー
			Infragistics.Win.ValueList enableOdrMakerList;
			this._stockInputInitDataAcs.SetEnableOdrMakerCdComboEditor(out enableOdrMakerList, _defaultEnableOdrMakerCd);
			enableOdrMakerList.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
			enableOdrMakerList.DropDownListMinWidth = 0;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].ValueList = enableOdrMakerList;
		}
		# endregion

		# region 明細グリッド・行単位でのセル設定
		/// <summary>
		/// 明細グリッド・行単位でのセル設定
		/// </summary>
		/// <param name="rowIndex">対象行インデックス</param>
		/// <param name="stockExpansion">仕入データクラスオブジェクト</param>
		    private void SettingGridRow(int rowIndex)
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

			// 商品名称を取得
			string goodsName = this._orderDataTable[rowIndex].InpGoodsNo;

			// 変更可能ステータスを取得
			int editStatus = this._orderDataTable[rowIndex].EditStatus;

			// 行ステータスを取得
			int rowStatus = this._orderDataTable[rowIndex].RowStatus;

			// 指定行の全ての列に対して設定を行う。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// セル情報を取得
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
				if (cell == null) continue;

    			cell.Row.Hidden = false;

				//全て非表示
				if (editStatus == StockInputAcs.EDITSTATUS_AllDisable)
				{
					cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
				}
				//全て入力禁止
				//else if (editStatus == StockInputAcs.EDITSTATUS_AllReadOnly)
				else if( _defaultUOESupplierCd == 0)
				{
					if (col.Key == this._orderDataTable.OrderNoDisplayColumn.ColumnName)
					{
						//
					}
					else
					{
						cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
					}
				}

				//新規入力処理
				else
				{
					if ((col.Key == this._orderDataTable.OrderNoDisplayColumn.ColumnName)
					||	(col.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName))
					{
						cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
					}
					else
					{
						// 商品名称が入力されていない場合は「商品コード」「商品ガイドボタン」以外を無効にする
						if (goodsName.Trim() == "")
						{
							cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
						}
						else
						{
                            switch (_defaultStatusType)
                            {
                                //発注
                                case StatusType.ct_Order:
                                    //品番・数量・ＢＯ・メーカーコード・ＢＬコード・品名 
                                    if ((col.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
                                    || (col.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
                                    || (col.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
                                    || (col.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
                                    || (col.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
                                    || (col.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
                                    || (col.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                    break;
                                //見積
                                case StatusType.ct_Estmt:
                                    //優良
                                    if (_defaultSettingGridCol == 1)
                                    {
                                        //品番・メーカーコード・ＢＬコード・品名 
                                        if ((col.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                    //純正
                                    else
                                    {
                                        //品番・数量・メーカーコード・ＢＬコード・品名 
                                        if ((col.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                    break;
                                //在庫
                                case StatusType.ct_Stock:
                                    //優良
                                    if (_defaultSettingGridCol == 1)
                                    {
                                        //品番・数量・メーカーコード・ＢＬコード・品名 
                                        if ((col.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                    //純正
                                    else
                                    {
                                        //品番・メーカーコード・ＢＬコード・品名 
                                        if ((col.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
                                        || (col.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                    break;
                            }
						}
					}
				}
				//Appearanceの設定
                if ((cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled) &&
					(cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
				{
					//BackColor ForeColor設定
					if (rowStatus == StockInputAcs.ROWSTATUS_COPY)
					{
						cell.Appearance.BackColor = ROWSTATUS_COPY_COLOR;
						cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
					}
					else if (rowStatus == StockInputAcs.ROWSTATUS_CUT)
					{
						cell.Appearance.BackColor = ROWSTATUS_COPY_COLOR;
						cell.Appearance.ForeColor = ROWSTATUS_CUT_COLOR;
					}
					else
					{
						cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
						cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

						if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
							(cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
						{
							cell.Appearance.BackColor = READONLY_CELL_COLOR;
						}
						else
						{
							cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
						}
        			}
				}
			}
		}
		# endregion

		# region ボタン初期設定処理
		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			//ImageList
			this.uButton_RowDelete.ImageList = this._imageList16;
			this.uButton_RowCopy.ImageList = this._imageList16;
			this.uButton_RowPaste.ImageList = this._imageList16;
			this.uButton_RowInsert.ImageList = this._imageList16;
			this.uButton_RowCut.ImageList = this._imageList16;
			this.uButton_Guide.ImageList = this._imageList16;
			this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

			//Appearance.Image
			this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
			this.uButton_RowCopy.Appearance.Image = (int)Size16_Index.ROWCOPY;
			this.uButton_RowPaste.Appearance.Image = (int)Size16_Index.ROWPASTE;
			this.uButton_RowInsert.Appearance.Image = (int)Size16_Index.ROWINSERT;
			this.uButton_RowCut.Appearance.Image = (int)Size16_Index.ROWCUT;
			this.uButton_Guide.Appearance.Image = (int)Size16_Index.GUIDE;

			//選択許可設定
			this.uButton_RowDelete.Enabled = false;
			this.uButton_RowCopy.Enabled = false;
			this.uButton_RowPaste.Enabled = false;

			this.uButton_RowInsert.Enabled = false;
			this.uButton_RowCut.Enabled = false;

			this.uButton_Guide.Enabled = false;

			this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

			//Appearance.Image
			this._rowInsertButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWINSERT;
			this._rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
			this._rowCutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCUT;
			this._rowCopyButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCOPY;
			this._rowPasteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWPASTE;
		}
		# endregion

		# region ツールチップ初期設定処理
		/// <summary>
		/// ツールチップ初期設定処理
		/// </summary>
		private void ToolTipInfoInitialSetting()
		{
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo_uGrid_Details = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
            ultraToolTipInfo_uGrid_Details.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            ultraToolTipInfo_uGrid_Details.ToolTipTitle = "";
            ultraToolTipInfo_uGrid_Details.ToolTipText = "";
            ultraToolTipInfo_uGrid_Details.Appearance.FontData.Name = "ＭＳ ゴシック";
            this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Details, ultraToolTipInfo_uGrid_Details);

            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo_uGrid_Details2 = this.uToolTipManager_Hint.GetUltraToolTip(this.uGrid_Details);
            ultraToolTipInfo_uGrid_Details2.ToolTipImage = Infragistics.Win.ToolTipImage.None;
            ultraToolTipInfo_uGrid_Details2.ToolTipTitle = "";
            ultraToolTipInfo_uGrid_Details2.ToolTipText = "";
            ultraToolTipInfo_uGrid_Details2.Appearance.FontData.Name = "ＭＳ ゴシック";
            this.uToolTipManager_Hint.SetUltraToolTip(this.uGrid_Details, ultraToolTipInfo_uGrid_Details2);

		}
		# endregion

		# region グリッドキーマッピング設定処理
		/// <summary>
		/// グリッドキーマッピング設定処理
		/// </summary>
		/// <param name="grid">設定対象のグリッド</param>
		private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
		{
			Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

			//----- Enterキー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- Shift + Enterキー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.AltCtrl,
				Infragistics.Win.SpecialKeys.Shift,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↑キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Up,
				Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Up,
				Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Down,
				Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↓キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Down,
				Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- 前頁キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Prior,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- 次頁キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Next,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
		}
		# endregion

		# region 選択済み仕入行番号リスト取得処理
		/// <summary>
		/// 選択済み仕入行番号リスト取得処理
		/// </summary>
		/// <returns>選択済み仕入行番号リスト</returns>
		public List<int> GetSelectedStockRowNoList()
		{
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
			Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
			if ((cell == null) && (rows == null)) return null;

			List<int> selectedStockRowNoList = new List<int>();
			List<int> selectedIndexList = new List<int>();
			
			if (cell != null)
			{
				selectedStockRowNoList.Add(this._orderDataTable[cell.Row.Index].OrderNo);
				selectedIndexList.Add(cell.Row.Index);
				//return null;
			}
			else if (rows != null)
			{
				foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
				{
					selectedStockRowNoList.Add(this._orderDataTable[row.Index].OrderNo);
					selectedIndexList.Add(row.Index);
				}
			}

			return selectedStockRowNoList;
		}
		# endregion

		# region ActiveRowインデックス取得処理
		/// <summary>
		/// ActiveRowインデックス取得処理
		/// </summary>
		/// <returns>ActiveRowインデックス</returns>
		private int GetActiveRowIndex()
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				return this.uGrid_Details.ActiveCell.Row.Index;
			}
			else if (this.uGrid_Details.ActiveRow != null)
			{
				return this.uGrid_Details.ActiveRow.Index;
			}
			else
			{
				return -1;
			}
		}
		# endregion

		# region 画面初期化処理
		/// <summary>
		/// 画面初期化処理
		/// </summary>
		internal void Clear()
		{
			// データ変更フラグプロパティをfalseにする
			this._stockInputAcs.IsDataChanged = false;

			// DataTable行クリア処理
			this._orderDataTable.Rows.Clear();

			// グリッド行初期設定処理			
			this._stockInputAcs.OrderRowInitialSetting(99);

			// 明細グリッドセル設定処理
			this.SettingGrid();
		}
		# endregion

		# region フォーカス設定イベントコール処理
		/// <summary>
		/// フォーカス設定イベントコール処理
		/// </summary>
		/// <param name="name">項目名称</param>
		private void SettingFocusEventCall(string itemName)
		{
			if (this.FocusSetting != null)
			{
				this.FocusSetting(this, itemName);
			}
		}
		# endregion

		# region 数値入力チェック処理
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
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (!Char.IsDigit(key))
			{
				// 小数点または、マイナス以外
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// 小数点のチェック
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

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
				int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
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
		# endregion

		# region 表示行数取得処理
		/// <summary>
		/// 表示行数取得処理
		/// </summary>
		/// <returns>表示行数</returns>
		private int GetVisibleRowCount()
		{
			int count = 0;
			
			foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
			{
				if (!row.Hidden)
				{
					count++;
				}
			}

			return count;
		}
		# endregion

		# region セルアクティブ時ボタン有効無効コントロール処理
		/// <summary>
		/// セルアクティブ時ボタン有効無効コントロール処理
		/// </summary>
		/// <param name="index">行インデックス</param>
		/// <param name="colKey">セルキー文字列</param>
		private void ActiveCellButtonEnabledControl(int index, string colKey)
		{
			// 行操作ボタンの有効無効を設定する
			string goodsCode = this._orderDataTable[index].GoodsNo;
			string goodsName = this._orderDataTable[index].GoodsName;

			int editStatus = this._orderDataTable[index].EditStatus;

			// 行操作ボタンの有効無効チェック
			this.uButton_RowInsert.Enabled = true;

			if (goodsName == "")
			{
				this.uButton_RowDelete.Enabled = true;
				this.uButton_RowCopy.Enabled = false;
				this.uButton_RowCut.Enabled = false;
				this.uButton_RowPaste.Enabled = false;
			}
			else if (editStatus == StockInputAcs.EDITSTATUS_AllReadOnly)
			{
				this.uButton_RowDelete.Enabled = false;
				this.uButton_RowCopy.Enabled = false;
				this.uButton_RowCut.Enabled = false;
				this.uButton_RowPaste.Enabled = false;
			}
			else
			{
				this.uButton_RowDelete.Enabled = true;
				this.uButton_RowCopy.Enabled = true;
				this.uButton_RowCut.Enabled = true;
			}

			// コピー在庫マスタ行存在チェック処理
			if ((this._stockInputAcs.ExistCopyProductStockRow()) && (editStatus != StockInputAcs.EDITSTATUS_AllReadOnly))
			{
				this.uButton_RowPaste.Enabled = true;
			}
			else
			{
				this.uButton_RowPaste.Enabled = false;
			}

			// 入力補助ボタンの有効無効チェック
			if (this._orderDataTable[index].EditStatus == StockInputAcs.EDITSTATUS_AllDisable)
			{
				this.uButton_Guide.Enabled = false;
			}
			else if (editStatus == StockInputAcs.EDITSTATUS_AllReadOnly)
			{
				this.uButton_Guide.Enabled = false;
			}
			else if (this._orderDataTable[index].EditStatus == (int)StockInputAcs.EDITSTATUS_StockCountOnly)
			{
				this.uButton_Guide.Enabled = false;
			}
			else
			{
				// ガイドボタンの有効無効を設定する
				if ((colKey != null) &&
                    //ＢＯ区分ガイド
                    (colKey == this._orderDataTable.InpBoCodeColumn.ColumnName) ||
                    //ＢＬコードガイド
					(colKey == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName) ||
					//メーカーガイド
					(colKey == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName))
				{
					this.uButton_Guide.Enabled = true;
					this.uButton_Guide.Tag = colKey;
				}
				else
				{
					this.uButton_Guide.Enabled = false;
				}
			}
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// 各コントロールイベント処理
		// ===================================================================================== //
		# region private Control Event Methods

        #region ■Loadイベント
        /// <summary>
		/// コントロールロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void InputDetails_Load(object sender, EventArgs e)
		{
			//this.uGrid_Details.DataSource = this._orderDataTable;
			this.uGrid_Details.DataSource = this._orderDataTable;

			// ボタン初期設定処理
			this.ButtonInitialSetting();

            // ツールチップ初期設定処理
            this.ToolTipInfoInitialSetting();

            // グリッドキーマッピング設定処理
			this.MakeKeyMappingForGrid(this.uGrid_Details);

			// クリア処理
			this.Clear();
        }
        #endregion

        #region ■グリッド内イベント（初期レイアウト設定）
        /// <summary>
		/// グリッド初期レイアウト設定イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// グリッド列初期設定処理
			this.InitialSettingGridCol(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
		}

		#region ■グリッド列初期設定処理
		/// <summary>
        /// グリッド列初期設定処理
        /// </summary>
		private void InitialSettingGridCol(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
			//表示順番
			int currentPosition = 0;

			//フォーマット設定
            //string moneyFormat = "#,##0;-#,##0;''";
			//string moneyFormat_Zero = "#,##0;-#,##0;'0'";
			//string _dateFormat = "yyyy/MM/dd";
			string codeFormat = "#;";
            string codeFormat_bl = "00000;-#;#";
            //string doubleFormat = "#,##0.00;-#,##0.00;''";
			string doubleFormat = "##0;-##0;''";

			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if ( editBand == null ) return;

			// 全ての列をいったん非表示にする。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				col.Hidden = true;

				// 「No列」以外の全てのセルのDiabledColorを設定する。
				if (col.Key != this._orderDataTable.OrderNoDisplayColumn.ColumnName)
				{
					col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
					col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
				}
			}

            // グリッド列表示非表示設定処理
            this.SettingGridColVisible(_defaultStatusType, _defaultSettingGridCol);

			// 明細部
			//[No.]
			#region [No.]
			//表示順位
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].Width = 44;
			//固定列
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.Fixed = true;
			//タイトル名称
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.Caption = "No.";
			//入力許可
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			// CellAppearance設定
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			#endregion

			//品番
			#region [品番]
			//表示順位
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].Width = 200;
			//固定列
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].Header.Fixed = true;
			//タイトル名称
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].Header.Caption = "品番";
			//入力許可
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			// フォーマット設定
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].Format = codeFormat;

            // MaxLength設定
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].MaxLength = 24;
			//CellAppearance
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[this._orderDataTable.InpGoodsNoColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
			#endregion

			//商品ガイド
			#region [商品ガイド]
			//[商品ガイド]
			//表示順位
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].Width = 25;
			//固定列
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].Header.Fixed = true;

			// Button用個別設定
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;

			//Style
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
			// CellAppearance設定
			Columns[this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			#endregion

			//数量
			#region [数量]
			//[数量] InpAcceptAnOrderCnt
			//表示順位
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Width = 50;
			//固定列
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Header.Caption = "数量";
			//入力許可
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Format = doubleFormat;
			// MaxLength設定
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].MaxLength = 3;
			//CellAppearance
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			#endregion

			//ＢＯ区分
			#region [ＢＯ区分]
			//表示順位
			Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].Width = 60;
			//固定列
			Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].Header.Caption = "BO区分";
			//入力許可
			Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //CellAppearance
            Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // MaxLength設定
            Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].MaxLength = 1;
            #endregion

			//メーカー(優良)
			#region [メーカー(優良)]
			//[メーカーコード]
			//表示順位
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].Width = 120;
			//固定列
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].Header.Caption = "メーカー";
			//入力許可
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].MaxLength = 4;
			//CellAppearance
			Columns[this._orderDataTable.InpGoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			#endregion

			//メーカー(純正)
			#region [メーカー(純正)]
			//表示順位
			Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].Width = 120;
			//固定列
			Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].Header.Caption = "メーカー";
			//入力許可
			Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

			// DropDownList設定
			Infragistics.Win.ValueList makerDivList = new Infragistics.Win.ValueList();
			makerDivList.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
			makerDivList.DropDownListMinWidth = 0;
			makerDivList.MaxDropDownItems = 10;
			Columns[this._orderDataTable.InpMakerNameColumn.ColumnName].ValueList = makerDivList;
			#endregion

			//ＢＬコード
			#region [ＢＬコード]
			//表示順位
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].Width = 55;
			//固定列
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
			//入力許可
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
            Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].Format = codeFormat_bl;
			// MaxLength設定
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].MaxLength = 5;
			//CellAppearance
			Columns[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			#endregion

			//品名
			#region [品名]
			//表示順位
			Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].Width = 190;
			//固定列
			Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].Header.Caption = "品名";
			//入力許可
			Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// MaxLength設定
			Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].MaxLength = 100;
			
			//// CellAppearance設定
			//Columns[this._orderDataTable.InpBLGoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			#endregion

			//現在庫数
			#region [現在庫数]
			//表示順位
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].Width = 60;
			//固定列
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].Header.Fixed = false;
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].Header.Caption = "現在庫数";
			//入力許可
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].Format = doubleFormat;
			// MaxLength設定
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].MaxLength = 8;
			//CellAppearance
			Columns[this._orderDataTable.DspStockCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			#endregion

			//倉庫
			#region [倉庫]
			//表示順位
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].Header.Caption = "倉庫";
			//入力許可
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//Style
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].MaxLength = 6;
			//CellAppearance
			Columns[this._orderDataTable.DspWarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			#endregion

			//棚番
			#region [棚番]
			//表示順位
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].Header.Caption = "棚番";
			//入力許可
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//Style
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].MaxLength = 6;
			//CellAppearance
			Columns[this._orderDataTable.DspWarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			#endregion
		}
		# endregion

        /// <summary>
        /// グリッド列表示非表示設定処理
        /// </summary>
        /// <param name="statusType">ステータスタイププロパティ</param>
        /// <param name="value">値</param>
        private void SettingGridColVisible ( StatusType statusType, int value )
        {
            // すべての列の表示非表示設定
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if ( editBand == null ) return;

            // 指定行の全ての列に対して設定を行う。
            foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns ) {
                bool hidden;
                if ( this._productStockRowVisibleControl.GetHidden(col.Key, statusType, value, out hidden) == 0 ) {
                    col.Hidden = hidden;
                }
            }
        }
        #endregion

        #region ■グリッド内イベント（アクション処理関連）
        /// <summary>
		/// Gridアクション処理前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforePerformAction(object sender, Infragistics.Win.UltraWinGrid.BeforeUltraGridPerformActionEventArgs e)
		{
			//
		}

		/// <summary>
		/// Gridアクション処理後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
		{
			switch (e.UltraGridAction)
			{
				case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:
				
				// アクティブなセルがあるか？または編集可能セルか？
				if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
				{
					// アクティブセルのスタイルを取得
					switch (this.uGrid_Details.ActiveCell.StyleResolved)
					{
						// エディット系スタイル
						case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
						case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
						case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
						{
							// 編集モードにある？
							if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
							{
								if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
								{
									// 全選択状態にする。
									this.uGrid_Details.ActiveCell.SelStart = 0;
									this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
								}
							}
							break;
						}
						default:
						{
							// エディット系以外のスタイルであれば、編集状態にする。
							this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
							break;
						}
					}
				}
				break;
			}
        }
        #endregion

        #region ■グリッド内イベント（セル編集関連）
        /// <summary>
		/// グリッドセル編集モード終了時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
		{
			//
		}

		/// <summary>
		/// グリッドセル編集モード終了前発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			//
        }
        #endregion

        #region ■グリッド内イベント（キー関連）
        /// <summary>
		/// グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

				if (e.KeyCode == Keys.Escape)
				{
					// 製番在庫マスタテーブルRowStatus列初期化処理					
                    this._stockInputAcs.InitializeProductStockRowStatusColumn();

					// 明細グリッドセル設定処理
					this.SettingGrid();
				}

				if (e.Shift)
				{
					switch (e.KeyCode)
					{
						case Keys.Down:
						{
							this.uGrid_Details.ActiveCell = null;
							this.uGrid_Details.ActiveRow = cell.Row;
							this.uGrid_Details.Selected.Rows.Clear();
							this.uGrid_Details.Selected.Rows.Add(cell.Row);
                            break;
						}
						case Keys.Up:
						{
							this.uGrid_Details.ActiveCell = null;
							this.uGrid_Details.ActiveRow = cell.Row;
							this.uGrid_Details.Selected.Rows.Clear();
							this.uGrid_Details.Selected.Rows.Add(cell.Row);
							break;
						}
					}
				}
				else if (e.Alt)
				{
					switch (e.KeyCode)
					{
						case Keys.Down:
						{
							if ((cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown) &&
								(cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList) &&
								(cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate))
							{
								((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);
							}

							break;
						}
					}
				}
				else
				{
					// 編集中であった場合
					if (cell.IsInEditMode)
					{
						// セルのスタイルにて判定
						switch (this.uGrid_Details.ActiveCell.StyleResolved)
						{
							// テキストボックス・テキストボックス(ボタン付)
							case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
							case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
							{
								switch (e.KeyData)
								{
									// ←キー
									case Keys.Left:
									if (this.uGrid_Details.ActiveCell.SelStart == 0)
									{
										this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
										e.Handled = true;
									}
									break;
									// →キー
									case Keys.Right:
									if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
									{
										this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
										e.Handled = true;
									}
									break;
								}
								break;
							}
							// 上記以外のスタイル
							default:
							{
								switch (e.KeyData)
								{
									// ←キー
									case Keys.Left:
									{
										this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
										e.Handled = true;
									}
									break;
									// →キー
									case Keys.Right:
									{
										this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
										e.Handled = true;
									}
									break;
								}
								break;
							}
						}
					}

					switch (e.KeyCode)
					{
						case Keys.Home:
						{
							this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
							this.MoveNextAllowEditCell(true);
							break;
						}
						case Keys.End:
						{
							this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
							this.MoveNextAllowEditCell(true);
							break;
						}
					}

					if ((this.uGrid_Details.ActiveCell != null) && (!this.uGrid_Details.ActiveCell.DroppedDown))
					{
						if (this.uGrid_Details.ActiveCell.Row.Index == 0)
						{
							if (e.KeyCode == Keys.Up)
							{
								if (this.GridKeyDownTopRow != null)
								{
									this.GridKeyDownTopRow(this, new EventArgs());
									e.Handled = true;
								}
							}
						}
						else if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
						{
							if (e.KeyCode == Keys.Down)
							{
								if (this.GridKeyDownButtomRow != null)
								{
									this.GridKeyDownButtomRow(this, new EventArgs());
									e.Handled = true;
								}
							}
						}
					}
				}
			}
			else if (this.uGrid_Details.ActiveRow != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

				//switch (e.KeyCode)
				//{
				//	case Keys.Delete:
				//	{
				//		this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
				//		break;
				//	}
				//}

				if (this.uGrid_Details.ActiveRow.Index == 0)
				{
					if (e.KeyCode == Keys.Up)
					{
						if (this.GridKeyDownTopRow != null)
						{
							this.GridKeyDownTopRow(this, new EventArgs());
							e.Handled = true;
						}
					}
				}
				else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
				{
					if (e.KeyCode == Keys.Down)
					{
						if (this.GridKeyDownButtomRow != null)
						{
							this.GridKeyDownButtomRow(this, new EventArgs());
							e.Handled = true;
						}
					}
				}
			}
		}

		/// <summary>
		/// グリッドキーアップイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

			// ActiveCellが商品ガイドボタンの場合
			if (cell.Column.Key == this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName)
			{
				if (e.KeyCode == Keys.Space)
				{
					Infragistics.Win.UltraWinGrid.CellEventArgs ce = new Infragistics.Win.UltraWinGrid.CellEventArgs(cell);
					this.uGrid_Details_ClickCellButton(this.uGrid_Details, ce);
				}
			}
		}

		/// <summary>
		/// グリッドキープレスイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;


            // ActiveCellが数量の場合
            if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // ActiveCellがＢＬコードの場合
            else if (cell.Column.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            //ActiveCellが「メーカー(優良)」の場合
			else if (cell.Column.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }
        #endregion

        #region ■グリッド内イベント（セルアップデート関連）
        /// <summary>
		/// グリッドセルアップデート前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
		{
			if (e.Cell == null) return;

			Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
                        
			// ActiveCellが「品番」の場合
			if (cell.Column.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
			{
				if (e.Cell.Value != null)
				{
					this._beforeGoodsNo = e.Cell.Value.ToString();
				}
				else
				{
					this._beforeGoodsNo = "";
				}
			}
			//ActiveCellが「数量」の場合
			else if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
			{
				if ((e.Cell.Value != null) && (e.Cell.Value != DBNull.Value) && (e.Cell.Value.ToString() != ""))
				{
					_beforeAcceptAnOrderCnt = (double)e.Cell.Value;

					if (_beforeAcceptAnOrderCnt < 0)
					{
						_beforeAcceptAnOrderCnt = _beforeAcceptAnOrderCnt * -1;
						e.Cancel = true;
						return;
					}
				}
				else
				{
					_beforeAcceptAnOrderCnt = 0;
				}
			}
			//ActiveCellが「ＢＯコード」
			else if (cell.Column.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
			{
				if (e.Cell.Value != null)
				{
					this._beforeBoCode = e.Cell.Value.ToString();
				}
				else
				{
					this._beforeBoCode = "";
				}
			}
			//ActiveCellが「メーカー(優良)」
			else if (cell.Column.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
			{
				if ((e.Cell.Value != null) && (e.Cell.Value != DBNull.Value) && (e.Cell.Value.ToString() != ""))
				{
					this._beforeGoodsMakerCd = e.Cell.Value.ToString();
				}
				else
				{
					this._beforeGoodsMakerCd = "";
				}
			}
			//ActiveCellが「メーカー(純正)」
			else if (cell.Column.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
			{
				if (e.Cell.Value != null)
				{
					this._beforeMakerName = (int)e.Cell.Value;
				}
				else
				{
					this._beforeMakerName = 0;
				}
			}
			//ActiveCellが「ＢＬコード」の場合
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
			{
				if ((e.Cell.Value != null) && (e.Cell.Value != DBNull.Value) && (e.Cell.Value.ToString() != ""))
				{
					this._beforeBLGoodsCode = (int)e.Cell.Value;
				}
				else
				{
					this._beforeBLGoodsCode = 0;
				}
			}
			//ActiveCellが「品名」の場合
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName)
			{
				if (e.Cell.Value != null)
				{
					this._beforeGoodsName = e.Cell.Value.ToString();
				}
				else
				{
					this._beforeGoodsName = "";
				}
			}
		}

		/// <summary>
		/// グリッドセルアップデート後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (e.Cell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
			int OrderNo = this._orderDataTable[cell.Row.Index].OrderNo;            
			int rowIndex = e.Cell.Row.Index;

			this._cannotGoodsNo = false;			//品番
			this._cannotAcceptAnOrderCnt = false;	//数量
			this._cannotBoCode = false;				//ＢＯ区分
			this._cannotGoodsMakerCd = false;		//メーカー(優良)
			this._cannotMakerName = false;			//メーカー(純正)
			this._cannotBLGoodsCode = false;		//BL商品コード
			this._cannotGoodsName = false;			//品名

			if (e.Cell.Value is DBNull) 
			{
				if ((e.Cell.Column.DataType == typeof(Int32)) ||
					(e.Cell.Column.DataType == typeof(Int64)))					
				{
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(double))
                {
					e.Cell.Value = 0.0;
				}
				else if (e.Cell.Column.DataType == typeof(string))
				{
					e.Cell.Value = "";
				}
			}

			// 品番
			if (cell.Column.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
			{
				# region 品番
				string goodsCode = (string)this._orderDataTable[rowIndex].InpGoodsNo;

				//品番削除
				if (String.IsNullOrEmpty(goodsCode))
				{
					this._stockInputAcs.ClearStockRow(OrderNo);
				}
				//品番入力
				else
				{
					if (SearchPartsFromGoodsNoMain(rowIndex) == 0)
					{
						// 最終行に商品名称が設定されている場合は１行追加
						if (this._orderDataTable[this._orderDataTable.Count - 1].InpGoodsNo != "")
						{
							this._stockInputAcs.AddStockRow();

							// 表示用行番号調整処理
							this._stockInputAcs.AdjustRowNo();

							// 明細グリッド・行単位でのセル設定
							this.SettingGridRow(rowIndex + 1);
						}
					}
					//入力エラー
					else 
					{
						this._cannotGoodsNo = true;
						this._orderDataTable[cell.Row.Index].InpGoodsNo = this._beforeGoodsNo;
					}
				}
				# endregion
			}
			// 数量
			else if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
			{
				# region 数量
				double columnData = (double)cell.Value;	//入力値

				//入力エラー時
				if (columnData < 0)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"入力値がマイナスです。",
						-1,
						MessageBoxButtons.OK);

					// 数量を元に戻す
					this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = this._beforeAcceptAnOrderCnt;
					this._cannotAcceptAnOrderCnt = true;
				}
				else
				{
					this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = columnData;
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = columnData;
				}
				# endregion
			}
			// ＢＯ区分
			else if (cell.Column.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
			{
				# region ＢＯ区分
   				string boCode = (string)this._orderDataTable[rowIndex].InpBoCode;

                if (this._stockInputInitDataAcs.UOEGuideExists(1, _defaultUOESupplierCd, boCode) == true)
				{
			        //ＢＯ区分(画面)
			        this._orderDataTable[rowIndex].InpBoCode = (string)cell.Value;

			        //ＢＯ区分
                    this._orderDataTable[rowIndex].BoCode = (string)cell.Value;
                }
				//入力エラー
                else
                {
                    //ＢＯ区分入力なし
                    if (String.IsNullOrEmpty(boCode))
                    {
                        //ＢＯ区分(画面)
                        this._orderDataTable[rowIndex].InpBoCode = "";

                        //ＢＯ区分
                        this._orderDataTable[rowIndex].BoCode = "";
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "UOEガイド名称マスタに存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // ＢＯ区分を元に戻す
                        this._orderDataTable[rowIndex].InpBoCode = this._beforeBoCode;
                        this._cannotBoCode = true;
                    }
                }
                # endregion
                }
			// メーカー(優良)
			else if (cell.Column.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
			{
				# region メーカー(優良)
				int goodsMakerCd = 0;
				bool statusBool = UoeCommonFnc.ToInt32FromString((string)cell.Text, out goodsMakerCd);

				if (statusBool != true)
				{
                    if (goodsMakerCd == 0)
                    {
                        this._orderDataTable[rowIndex].InpGoodsMakerCd = "";// (画面)メーカーコード
                        this._orderDataTable[rowIndex].GoodsMakerCd = 0;
                        this._orderDataTable[rowIndex].MakerKanaName = "";
                        this._orderDataTable[rowIndex].MakerName = "";

                        //品番検索
                        SearchPartsFromGoodsNoMainForMkCd(rowIndex);
                    }
                    else
                    {
                        this._orderDataTable[rowIndex].InpGoodsMakerCd = this._beforeGoodsMakerCd;// (画面)メーカーコード
                        this._cannotGoodsMakerCd = true;
                    }
                }
                else
                {
                    // メーカーコード取得
                    MakerUMnt makerUMnt = null;
                    int status = _stockInputInitDataAcs.GetMakerInf(goodsMakerCd, out makerUMnt);

                    // メーカーコードが存在する
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    && (makerUMnt != null))
                    {
                        this._orderDataTable[rowIndex].InpGoodsMakerCd = makerUMnt.MakerName;// (画面)メーカーコード
                        this._orderDataTable[rowIndex].GoodsMakerCd = makerUMnt.GoodsMakerCd;	// メーカーコード
                        this._orderDataTable[rowIndex].MakerName = makerUMnt.MakerName;			// メーカー名称

                        //品番検索
                        SearchPartsFromGoodsNoMainForMkCd(rowIndex);
                    }
                    // メーカーコードが存在しない
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "メーカー [" + goodsMakerCd + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // メーカーコードを元に戻す
                        this._orderDataTable[cell.Row.Index].InpGoodsMakerCd = this._beforeGoodsMakerCd;
                        this._cannotGoodsMakerCd = true;
                    }
                }
				# endregion
			}
            // メーカー(純正)
			else if (cell.Column.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
			{
				# region メーカー(純正)
				this._orderDataTable[rowIndex].InpMakerName = (int)cell.Value;

				this._orderDataTable[rowIndex].GoodsMakerCd = (int)cell.Value;	// メーカーコード
				this._orderDataTable[rowIndex].MakerName = (string)cell.Text;	// メーカー名称

                //品番検索
                SearchPartsFromGoodsNoMainForMkCd(rowIndex);
				# endregion
			}
			// BL商品コード
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
			{
				# region BL商品コード
				int bLGoodsCode = (Int32)cell.Value;
	
				if (bLGoodsCode == 0)
				{
					this._orderDataTable[rowIndex].InpBLGoodsCode = 0;	// (画面)BL商品コード
					this._orderDataTable[rowIndex].InpBLGoodsName = "";	// (画面)BL商品名称
                    this._orderDataTable[rowIndex].BLGoodsCode = 0;	    // BL商品コード
                    this._orderDataTable[rowIndex].GoodsName = "";		// BL商品名称
				}
				else
				{
					// BL商品コード取得
					BLGoodsCdUMnt bLGoodsCdUMnt = null;
					int status = _stockInputInitDataAcs.GetBLGoodsCdInf(bLGoodsCode, out bLGoodsCdUMnt);

					// BL商品コードが存在する
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					&& (bLGoodsCdUMnt != null))
					{
						this._orderDataTable[rowIndex].InpBLGoodsCode = bLGoodsCode;					// (画面)BL商品コード
						this._orderDataTable[rowIndex].InpBLGoodsName = bLGoodsCdUMnt.BLGoodsFullName;	// (画面)BL商品名称
                        this._orderDataTable[rowIndex].BLGoodsCode = bLGoodsCode;	                    // BL商品コード
                        this._orderDataTable[rowIndex].GoodsName = bLGoodsCdUMnt.BLGoodsFullName;		// BL商品名称
					}
					// BL商品コードが存在しない
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"BLｺｰﾄﾞ [" + bLGoodsCode + "] に該当するデータが存在しません。",
							-1,
							MessageBoxButtons.OK);

						// BL商品コードを元に戻す
						this._orderDataTable[cell.Row.Index].InpBLGoodsCode = this._beforeBLGoodsCode;

						this._cannotBLGoodsCode = true;
					}
				}
				# endregion
			}
			// 品名
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName)
			{
				# region 品名
				this._orderDataTable[rowIndex].InpBLGoodsName = (string)cell.Text;
				this._orderDataTable[rowIndex].GoodsName = (string)cell.Text;
				# endregion
			}

			// 明細グリッド・行単位でのセル設定
			this.SettingGridRow(rowIndex);
        }
        #endregion

        #region ■グリッド内イベント（グリッド進入・脱出関連）
        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter ( object sender, EventArgs e )
        {
            if ( this.uGrid_Details.ActiveCell == null ) {
                if ( !this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || ( this.uGrid_Details.ActiveCell == null ) ) {
                    if ( this.uGrid_Details.Rows.Count > 0 ) {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._orderDataTable.InpGoodsNoColumn.ColumnName];
                        // 次入力可能セル移動処理
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if ( this.uGrid_Details.ActiveCell != null ) {
                if ( ( !this.uGrid_Details.ActiveCell.IsInEditMode ) && ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) && ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) ) {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else {
                    // 次入力可能セル移動処理
                    this.MoveNextAllowEditCell(true);
                }
            }

            // グリッドセルアクティブ後発生イベント
            this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
        }
        /// <summary>
        /// グリッドリーヴイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Leave ( object sender, EventArgs e )
        {
            if ( this.StatusBarMessageSetting != null ) {
                this.StatusBarMessageSetting(this, "");
            }
        }
        #endregion

        #region ■グリッド内イベント（セルアクティブ関連）
        /// <summary>
		/// グリッドセルアクティブ化前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
		{
			// セル単位でのIME制御
			if (e.Cell.Column.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName)
			{
				// IMEをひらがなモードにする
				this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			}
			else
			{
				// IMEを起動しない
				this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
			}
		}

		# region グリッドセルアクティブ後発生イベント
		/// <summary>
		/// グリッドセルアクティブ後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

			// StatusBarメッセージ表示設定
			//if (this.StatusBarMessageSetting != null)
			//{
			//	this.StatusBarMessageSetting(this, MESSAGE_GoodsNo);
			//}
			//品番
			if (cell.Column.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
			{
				this.StatusBarMessageSetting(this, MESSAGE_GoodsNo);
			}
			//数量
			else if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
			{
				this.StatusBarMessageSetting(this, MESSAGE_AcceptAnOrderCnt);
			}
			//ＢＯ区分
			else if (cell.Column.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
			{
				this.StatusBarMessageSetting(this, MESSAGE_BoCode);
			}
			//メーカーコード(優良)
			else if (cell.Column.Key == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
			{
				this.StatusBarMessageSetting(this, MESSAGE_GoodsMakerCd);
			}
			//メーカーコード(純正)
			else if (cell.Column.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
			{
				this.StatusBarMessageSetting(this, MESSAGE_MakerName);
			}
			//ＢＬコード
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
			{
				this.StatusBarMessageSetting(this, MESSAGE_BLGoodsCode);
			}
			//品名
			else if (cell.Column.Key == this._orderDataTable.InpBLGoodsNameColumn.ColumnName)
			{
				this.StatusBarMessageSetting(this, MESSAGE_GoodsName);
			}
			//その他
			else
			{
				this.StatusBarMessageSetting(this, "");
			}

			// セルアクティブ時ボタン有効無効コントロール処理
			this.ActiveCellButtonEnabledControl(cell.Row.Index, cell.Column.Key);

			// 横スクロールバー位置設定
			if (cell.Column.Key == this._orderDataTable.InpGoodsNoColumn.ColumnName)
			{
				this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
			}

			//グリッド移動可能値
			this._cannotGoodsNo = false;			//品番
			this._cannotAcceptAnOrderCnt = false;	//数量
			this._cannotBoCode = false;				//ＢＯ区分
			this._cannotGoodsMakerCd = false;		//メーカー(優良)
			this._cannotMakerName = false;			//メーカー(純正)
			this._cannotBLGoodsCode = false;		//BL商品コード
			this._cannotGoodsName = false;			//品名
		}
		# endregion

		/// <summary>
		/// グリッド行アクティブ後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
		{
			if (this.uGrid_Details.ActiveRow == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

			// セルアクティブ時ボタン有効無効コントロール処理
			this.ActiveCellButtonEnabledControl(row.Index, null);

			this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// グリッドセル非アクティブ化前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellDeactivate ( object sender, CancelEventArgs e )
        {
        }

        #endregion

        #region ■グリッド内イベント（エラー発生）
        /// <summary>
		/// グリッドデータエラー発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				// 数値項目の場合
				if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
					(this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
					(this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
				{
					Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

					// 未入力は0にする
					if (editorBase.CurrentEditText.Trim() == "")
					{
						editorBase.Value = 0;				// 0をセット
						this.uGrid_Details.ActiveCell.Value = 0;
					}
					// 数値項目に「-」or「.」だけしか入ってなかったら駄目です
					else if ((editorBase.CurrentEditText.Trim() == "-") ||
						(editorBase.CurrentEditText.Trim() == ".") ||
						(editorBase.CurrentEditText.Trim() == "-."))
					{
						editorBase.Value = 0;				// 0をセット
						this.uGrid_Details.ActiveCell.Value = 0;
					}
					// 通常入力
					else
					{
						try
						{
							editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
							this.uGrid_Details.ActiveCell.Value = editorBase.Value;
						}
						catch
						{
							editorBase.Value = 0;
							this.uGrid_Details.ActiveCell.Value = 0;
						}
					}
					e.RaiseErrorEvent = false;			// エラーイベントは発生させない
					e.RestoreOriginalValue = false;		// セルの値を元に戻さない
					e.StayInEditMode = false;			// 編集モードは抜ける
				}
			}
        }
        #endregion

        #region ■グリッド内イベント（マウス関連）
        /// <summary>
		/// グリッドマウスクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
		{
			// 右クリック以外の場合
			if (e.Button != MouseButtons.Right) return;

			System.Drawing.Point nowPos = new Point(e.X, e.Y);

			Infragistics.Win.UIElement objElement = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(nowPos);

			// クリック位置が列ヘッダーか判定
			bool isColumnHeader = false;

			if (objElement != null)
			{
				if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
					(objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
				{
					isColumnHeader = true;
					// string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
				}
			}

			if (isColumnHeader)
			{
				// 列ヘッダー右クリック時は何もしない
			}
			else
			{
				// それ以外で右クリックされた場合は、編集のポップアップを表示する
				((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

				if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow != null))
				{
					this.uGrid_Details.Selected.Rows.Clear();
					this.uGrid_Details.ActiveRow.Selected = true;
				}
			}
		}

		/// <summary>
		/// グリッドマウスエンターエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
            try
            {
                Infragistics.Win.UIElement element = e.Element;
                object oContextCell = null;

                oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                if (oContextCell != null)
                {
                    if (this._stockInputAcs == null) return;

                    Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;

                    if (cell.Column.Key == this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName)
                    {
                        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = this.uToolTipManager_Hint.GetUltraToolTip(this.uGrid_Details);
                        if (ultraToolTipInfo != null)
                        {
                            ultraToolTipInfo.ToolTipTitle = "";
                            ultraToolTipInfo.ToolTipText = "商品検索";
                            this.uToolTipManager_Hint.Enabled = true;
                        }
					
                        this.uToolTipManager_Information.Enabled = false;
                        this.uToolTipManager_Information.HideToolTip();
                    }
                    else
                    {
                        this.uToolTipManager_Information.Enabled = false;
                        this.uToolTipManager_Information.HideToolTip();

                        this.uToolTipManager_Hint.Enabled = false;
                        this.uToolTipManager_Hint.HideToolTip();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + " ");
            }
		}

		/// <summary>
		/// グリッドマウスリーヴエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
            try
            {
                this.uToolTipManager_Hint.Enabled = false;
                this.uToolTipManager_Hint.HideToolTip();
                this.uToolTipManager_Information.Enabled = false;
                this.uToolTipManager_Information.HideToolTip();

                Infragistics.Win.UIElement element = e.Element;
                object oContextCell = null;

                oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                if (oContextCell != null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message+ "  ");
            }
        }
        #endregion

		#region ■グリッド内イベント（セルボタンクリック）
        /// <summary>
		/// セルボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = e.Cell.Row.Index;
			if (rowIndex == -1) return;

			// 行番号を取得
			int OrderNo = this._orderDataTable[rowIndex].OrderNo;

			if (SearchPartsFromGoodsNoMain(rowIndex) == 0)
			{
				// 最終行に商品名称が設定されている場合は１行追加
				if (this._orderDataTable[this._orderDataTable.Count - 1].InpGoodsNo != "")
				{
					this._stockInputAcs.AddStockRow();

					// 表示用行番号調整処理
					this._stockInputAcs.AdjustRowNo();

					// 明細グリッド・行単位でのセル設定
					this.SettingGridRow(rowIndex + 1);
				}
			}
		}
        #endregion

        #region ■ボタンクリックイベント
		# region 挿入ボタンクリックイベント
		/// <summary>
		/// 挿入ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowInsert_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			//if (rowIndex == -1) return;

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 在庫マスタ行挿入処理
				this._stockInputAcs.InsertProductStockRow(rowIndex);

				// 明細グリッドセル設定処理
				this.SettingGrid();

				// 次入力可能セル移動処理
				this.MoveNextAllowEditCell(true);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		# endregion

		# region 削除ボタンクリックイベント
		/// <summary>
		/// 削除ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowDelete_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// 選択済み行番号リスト取得処理
			List<int> selectedStockRowNoList = this.GetSelectedStockRowNoList();
			if (selectedStockRowNoList == null) return;
			if (selectedStockRowNoList.Count <= 0) return;

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"選択行を削除してもよろしいですか？",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button1);

			if (dialogResult != DialogResult.Yes)
			{
				return;
			}

			RowDelete(selectedStockRowNoList);
		}
		# endregion

		# region 削除処理
		/// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="selectedStockRowNoList"></param>
		public void RowDelete(List<int> selectedStockRowNoList)
		{
			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 行削除処理
				this._stockInputAcs.DeleteProductStockRow(selectedStockRowNoList);

				// 明細グリッドセル設定処理
				this.SettingGrid();

				if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
				{
					this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._orderDataTable.InpGoodsNoColumn.ColumnName];

					if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
						(this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
					{
						this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
					}
				}

				// 次入力可能セル移動処理
				this.MoveNextAllowEditCell(true);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		# endregion

		# region 切り取りボタンクリックイベント
		/// <summary>
		/// 切り取りボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCut_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// 選択済み仕入行番号リスト取得処理
			List<int> selectedStockRowNoList = this.GetSelectedStockRowNoList();
			if (selectedStockRowNoList == null) return;

			// データテーブルRowStatus列初期化処理
			this._stockInputAcs.InitializeProductStockRowStatusColumn();

			// データテーブルRowStatus列値設定処理
			this._stockInputAcs.SetProductStockRowStatusColumn(selectedStockRowNoList, StockInputAcs.ROWSTATUS_CUT);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 次入力可能セル移動処理
			this.MoveNextAllowEditCell(true);
		}
		# endregion

		# region コピーボタンクリックイベント
		/// <summary>
		/// コピーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCopy_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// 選択済み仕入行番号リスト取得処理
			List<int> selectedStockRowNoList = this.GetSelectedStockRowNoList();
			if (selectedStockRowNoList == null) return;

			// データテーブルRowStatus列初期化処理
			this._stockInputAcs.InitializeProductStockRowStatusColumn();

			// データテーブルRowStatus列値設定処理
			this._stockInputAcs.SetProductStockRowStatusColumn(selectedStockRowNoList, StockInputAcs.ROWSTATUS_COPY);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 次入力可能セル移動処理
			this.MoveNextAllowEditCell(true);
		}
		# endregion

		# region 貼り付けボタンクリックイベント
		/// <summary>
		/// 貼り付けボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowPaste_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

			// コピー行番号取得処理
			List<int> copyStockRowNoList = this._stockInputAcs.GetCopyProductStockRowNo();
			if (copyStockRowNoList == null) return;

			// 表示行数取得処理
			int prevVisibleRowCount = this.GetVisibleRowCount();

			// 行貼り付け処理
			this._stockInputAcs.PasteProductStockRow(copyStockRowNoList, rowIndex);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 次入力可能セル移動処理
			this.MoveNextAllowEditCell(true);

			// 表示行数取得処理
			int afterVisibleRowCount = this.GetVisibleRowCount();

			// 表示する行数が減った場合、調整する
			if (afterVisibleRowCount < prevVisibleRowCount)
			{
				for (int i = afterVisibleRowCount; i < prevVisibleRowCount; i++)
				{
					this._stockInputAcs.AddStockRow();
				}

				// 明細グリッドセル設定処理
				//this.SettingGrid();
			}

            // データテーブルRowStatus列値設定処理
            this._stockInputAcs.SetProductStockRowStatusColumn(copyStockRowNoList, StockInputAcs.ROWSTATUS_NORMAL);

            // 明細グリッドセル設定処理
            this.SettingGrid();

			this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
		}
		# endregion

		# region ガイドボタンクリックイベント
		/// <summary>
		/// ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Guide_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;
			if (this.uButton_Guide.Tag == null) return;

			this._selectedRowBeforeGuide = rowIndex;

			//-----------------------------------------------------------------------------------
			//品番検索
			//-----------------------------------------------------------------------------------
			if (
				(this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpGoodsNoColumn.ColumnName) ||
				(this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpGoodsNoGuideButtonColumn.ColumnName) ||
				(this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpBLGoodsNameColumn.ColumnName))
			{
				if (SearchPartsFromGoodsNoMain(rowIndex) == 0)
				{
					// 最終行に商品名称が設定されている場合は１行追加
					if (this._orderDataTable[this._orderDataTable.Count - 1].InpGoodsNo != "")
					{
						this._stockInputAcs.AddStockRow();

					    	// 表示用行番号調整処理
						this._stockInputAcs.AdjustRowNo();

						// 明細グリッド・行単位でのセル設定
						this.SettingGridRow(rowIndex + 1);
					}
				}
			}
			//-----------------------------------------------------------------------------------
			//メーカーガイド
			//-----------------------------------------------------------------------------------
			else if (this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpGoodsMakerCdColumn.ColumnName)
			{
				MakerAcs makerAcs = new MakerAcs();
				MakerUMnt makerUMnt = null;

				int status = makerAcs.ExecuteGuid(_enterpriseCode, out makerUMnt);
				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				&& (makerUMnt != null))
				{
					//メーカーコード(画面)
					this._orderDataTable[rowIndex].InpGoodsMakerCd = makerUMnt.MakerName;
					//メーカーコード
					this._orderDataTable[rowIndex].GoodsMakerCd = makerUMnt.GoodsMakerCd;
					//メーカー名称
					this._orderDataTable[rowIndex].MakerName = makerUMnt.MakerName;

					this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName];

                    //品番検索処理
                    SearchPartsFromGoodsNoMainForMkCd(rowIndex);
                }
			}
			//-----------------------------------------------------------------------------------
			//ＢＬガイド
			//-----------------------------------------------------------------------------------
			else if((this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpBLGoodsCodeColumn.ColumnName)
				 || (this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpBLGoodsNameColumn.ColumnName))
			{
				BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
				BLGoodsCdUMnt bLGoodsCdUMnt = null;

				int status = bLGoodsCdAcs.ExecuteGuid(_enterpriseCode, out bLGoodsCdUMnt);
				if((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				&& (bLGoodsCdUMnt != null))
				{
					//BL商品コード(画面)
					this._orderDataTable[rowIndex].InpBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
					//BL商品コード名称(画面)
					this._orderDataTable[rowIndex].InpBLGoodsName = bLGoodsCdUMnt.BLGoodsFullName;
					//BL商品コード名称
					this._orderDataTable[rowIndex].GoodsName = bLGoodsCdUMnt.BLGoodsFullName;

                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._orderDataTable.InpBLGoodsCodeColumn.ColumnName];
                }
			}
            //-----------------------------------------------------------------------------------
            //ＢＯ区分ガイド
            //-----------------------------------------------------------------------------------
            else if (this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpBoCodeColumn.ColumnName)
            {
                UOEGuideName uoeGuideName = null;
                UOEGuideName inUOEGuideName = new UOEGuideName();
                inUOEGuideName.UOEGuideDivCd = 1;
                inUOEGuideName.EnterpriseCode = _enterpriseCode;
                inUOEGuideName.SectionCode = _loginSectionCode;
                inUOEGuideName.UOESupplierCd = _defaultUOESupplierCd;

                int status = this._stockInputInitDataAcs.uOEGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uoeGuideName != null))
                {
                    //ＢＯ区分(画面)
                    this._orderDataTable[rowIndex].InpBoCode = uoeGuideName.UOEGuideCode;

                    //ＢＯ区分
                    this._orderDataTable[rowIndex].BoCode = uoeGuideName.UOEGuideCode;

                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._orderDataTable.InpBoCodeColumn.ColumnName];
                }
            }
            this.uGrid_Details.Focus();
        }
		# endregion

		#region 品番検索メイン処理
        /// <summary>
        /// 品番検索メイン処理（メーカーコード用）
        /// </summary>
        /// <param name="rowIndex">テーブル行インディックス</param>
        /// <returns>0:正常 -1:選択なし</returns>
        /// <br>Update Note: 2012/08/30 袁磊</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分</br>
        /// <br>             Redmine#31884 手入力発注処理修正の対応</br>
        private int SearchPartsFromGoodsNoMainForMkCd(int rowIndex)
        {
            string goodsCode = (string)this._orderDataTable[rowIndex].InpGoodsNo;
            int goodsMakerCd = (int)this._orderDataTable[rowIndex].GoodsMakerCd;
            int orderNo = this._orderDataTable[rowIndex].OrderNo;
            List<GoodsUnitData> list = null;
            int status = 1; //0:該当あり 1:該当品番なし -1:選択なし

            if (goodsCode.Trim() == "") return (-1);

            //メーカーコードクリア
            if (goodsMakerCd == 0)
            {
                status = 1;
            }
            //品番検索
            else
            {
                status = _stockInputInitDataAcs.SearchPartsFromGoodsNoForMstInf(goodsCode, goodsMakerCd, _defaultEnableOdrMakerCd, out list);
            }
            
            //選択なし
            if (status == -1)
            {
                return (-1);

            }
            else if (status == 1)
            {
                //-----------------------------------------------------------
                // 該当品番なし
                //-----------------------------------------------------------
                # region 該当品番なし
                //明細部入力判定
                this._stockInputAcs.IsDataChanged = true;

                //-----------------------------------------------------------
                // 商品情報
                //-----------------------------------------------------------
                # region 商品情報
                //商品属性
                this._orderDataTable[rowIndex].GoodsKindCode = 0;

                //商品名称カナ
                this._orderDataTable[rowIndex].GoodsNameKana = "";

                //商品大分類コード
                this._orderDataTable[rowIndex].GoodsLGroup = 0;

                //商品大分類名称
                this._orderDataTable[rowIndex].GoodsLGroupName = "";

                //商品中分類コード
                this._orderDataTable[rowIndex].GoodsMGroup = 0;

                //商品中分類名称
                this._orderDataTable[rowIndex].GoodsMGroupName = "";

                //BLグループコード
                this._orderDataTable[rowIndex].BLGroupCode = 0;

                //BLグループコード名称
                this._orderDataTable[rowIndex].BLGroupName = "";

                //BL商品コード名称（全角）
                this._orderDataTable[rowIndex].BLGoodsFullName = "";

                //BL商品コード（掛率）
                this._orderDataTable[rowIndex].RateBLGoodsCode = 0;

                //BL商品コード名称（掛率）
                this._orderDataTable[rowIndex].RateBLGoodsName = "";

                //仕入在庫取寄せ区分
                this._orderDataTable[rowIndex].StockOrderDivCd = 0; //0:取寄せ,1:在庫

                //課税区分 0:課税,1:非課税,2:課税（内税）
                this._orderDataTable[rowIndex].TaxationCode = 0;
                #endregion

                //-----------------------------------------------------------
                // 価格情報のクリア
                //-----------------------------------------------------------
                # region 価格情報
                // 定価（浮動）
                this._orderDataTable[rowIndex].ListPrice = 0;

                // 原価単価
                this._orderDataTable[rowIndex].SalesUnitCost = 0;

                //オープン価格区分
                this._orderDataTable[rowIndex].OpenPriceDiv = 0;

                //定価（税抜，浮動）
                this._orderDataTable[rowIndex].ListPriceTaxExcFl = 0;

                //定価（税込，浮動）
                this._orderDataTable[rowIndex].ListPriceTaxIncFl = 0;

                //変更前定価
                this._orderDataTable[rowIndex].BfListPrice = 0;
                #endregion

                //-----------------------------------------------------------
                // 在庫情報のクリア
                //-----------------------------------------------------------
                # region 在庫情報
                //現在庫数(画面)
                //this._orderDataTable[rowIndex].DspStockCnt = 0; // DEL 袁磊 2012/08/30 redmine#31884
                this._orderDataTable[rowIndex].DspStockCnt = ""; // ADD 袁磊 2012/08/30 redmine#31884

                //倉庫コード
                this._orderDataTable[rowIndex].WarehouseCode = "";

                //倉庫名称(画面)
                this._orderDataTable[rowIndex].DspWarehouseName = "";

                //倉庫名称
                this._orderDataTable[rowIndex].WarehouseName = "";

                //棚番(画面)
                this._orderDataTable[rowIndex].DspWarehouseShelfNo = "";

                //棚番
                this._orderDataTable[rowIndex].WarehouseShelfNo = "";
                #endregion
                #endregion
            }
            else
            {
                //-----------------------------------------------------------
                // 該当品番あり
                //-----------------------------------------------------------
                # region 該当品番あり
                //-----------------------------------------------------------
                // 品番検索の結果算出
                //-----------------------------------------------------------
                # region 品番検索の結果算出
                //明細部入力判定
                this._stockInputAcs.IsDataChanged = true;

                //クラス設定
                GoodsUnitData goodsUnitData = list[0];
                List<Stock> stockList = list[0].StockList;
                List<GoodsPrice> goodsPriceList = list[0].GoodsPriceList;

                //拠点倉庫の在庫情報
                Stock stock = _stockInputInitDataAcs.GetStock_FromSecInfoSet(stockList, goodsUnitData.SelectedWarehouseCode);

                //価格マスタの取得
                GoodsPrice goodsPrice = _stockInputInitDataAcs.GetGoodsPrice_FromGoodsPriceList(goodsPriceList);
                #endregion

                //-----------------------------------------------------------
                // 商品情報
                //-----------------------------------------------------------
                # region 商品情報
                //品番(画面)
                this._orderDataTable[rowIndex].InpGoodsNo = goodsUnitData.GoodsNo;

                //品番
                this._orderDataTable[rowIndex].GoodsNo = goodsUnitData.GoodsNo;

                //品名(画面)
                this._orderDataTable[rowIndex].InpBLGoodsName = goodsUnitData.GoodsName;

                //品名
                this._orderDataTable[rowIndex].GoodsName = goodsUnitData.GoodsName;

                //BL商品コード(画面)
                this._orderDataTable[rowIndex].InpBLGoodsCode = goodsUnitData.BLGoodsCode;

                //メーカーコード(画面)
                this._orderDataTable[rowIndex].InpGoodsMakerCd = goodsUnitData.MakerName;

                //メーカー(優良)
                this._orderDataTable[rowIndex].GoodsMakerCd = goodsUnitData.GoodsMakerCd;

                //メーカー名(純正)
                this._orderDataTable[rowIndex].InpMakerName = goodsUnitData.GoodsMakerCd;

                //メーカー名
                this._orderDataTable[rowIndex].MakerName = goodsUnitData.MakerName;

                // ハイフン無商品番号
                this._orderDataTable[rowIndex].GoodsNoNoneHyphen = goodsUnitData.GoodsNoNoneHyphen;

                //商品属性
                this._orderDataTable[rowIndex].GoodsKindCode = goodsUnitData.GoodsKindCode;

                //メーカーカナ名称
                this._orderDataTable[rowIndex].MakerKanaName = goodsUnitData.MakerKanaName;

                //商品名称カナ
                this._orderDataTable[rowIndex].GoodsNameKana = goodsUnitData.GoodsNameKana;

                //商品大分類コード
                this._orderDataTable[rowIndex].GoodsLGroup = goodsUnitData.GoodsLGroup;

                //商品大分類名称
                this._orderDataTable[rowIndex].GoodsLGroupName = goodsUnitData.GoodsLGroupName;

                //商品中分類コード
                this._orderDataTable[rowIndex].GoodsMGroup = goodsUnitData.GoodsMGroup;

                //商品中分類名称
                this._orderDataTable[rowIndex].GoodsMGroupName = goodsUnitData.GoodsMGroupName;

                //BLグループコード
                this._orderDataTable[rowIndex].BLGroupCode = goodsUnitData.BLGroupCode;

                //BLグループコード名称
                this._orderDataTable[rowIndex].BLGroupName = goodsUnitData.BLGroupName;

                //BL商品コード
                this._orderDataTable[rowIndex].BLGoodsCode = goodsUnitData.BLGoodsCode;

                //BL商品コード名称（全角）
                this._orderDataTable[rowIndex].BLGoodsFullName = goodsUnitData.BLGoodsFullName;

                //BL商品コード（掛率）
                this._orderDataTable[rowIndex].RateBLGoodsCode = goodsUnitData.BLGoodsCode;

                //BL商品コード名称（掛率）
                this._orderDataTable[rowIndex].RateBLGoodsName = goodsUnitData.BLGoodsFullName;

                //仕入在庫取寄せ区分
                this._orderDataTable[rowIndex].StockOrderDivCd = stock.WarehouseCode.Trim() == "" ? 0 : 1; //0:取寄せ,1:在庫

                //課税区分 0:課税,1:非課税,2:課税（内税）
                this._orderDataTable[rowIndex].TaxationCode = goodsUnitData.TaxationDivCd;
                #endregion

                //-----------------------------------------------------------
                // 価格情報
                //-----------------------------------------------------------
                # region 価格情報
                if (goodsPrice != null)
                {
                    // 定価（浮動）
                    this._orderDataTable[rowIndex].ListPrice = goodsPrice.ListPrice;

                    // 原価単価
                    this._orderDataTable[rowIndex].SalesUnitCost = goodsPrice.SalesUnitCost;

                    //オープン価格区分
                    this._orderDataTable[rowIndex].OpenPriceDiv = goodsPrice.OpenPriceDiv;

                    //定価（税抜，浮動）
                    this._orderDataTable[rowIndex].ListPriceTaxExcFl = goodsPrice.ListPrice;

                    //定価（税込，浮動）
                    this._orderDataTable[rowIndex].ListPriceTaxIncFl =
                        _stockInputInitDataAcs.GetStockPriceTaxInc(goodsPrice.ListPrice, goodsUnitData.TaxationDivCd, goodsUnitData.StockCnsTaxFrcProcCd);

                    //変更前定価
                    this._orderDataTable[rowIndex].BfListPrice = goodsPrice.ListPrice;
                }
                else
                {
                    // 定価（浮動）
                    this._orderDataTable[rowIndex].ListPrice = 0;

                    // 原価単価
                    this._orderDataTable[rowIndex].SalesUnitCost = 0;

                    //オープン価格区分
                    this._orderDataTable[rowIndex].OpenPriceDiv = 0;

                    //定価（税抜，浮動）
                    this._orderDataTable[rowIndex].ListPriceTaxExcFl = 0;

                    //定価（税込，浮動）
                    this._orderDataTable[rowIndex].ListPriceTaxIncFl = 0;

                    //変更前定価
                    this._orderDataTable[rowIndex].BfListPrice = 0;
                }
                #endregion

                //-----------------------------------------------------------
                // 在庫情報
                //-----------------------------------------------------------
                # region 在庫情報
                if (stock != null)
                {
                    //現在庫数(画面)
                    //this._orderDataTable[rowIndex].DspStockCnt = stock.SupplierStock; // DEL 袁磊 2012/08/30 redmine#31884
                    // ---- ADD 袁磊 2012/08/30 redmine#31884 --------->>>>>
                    //現在庫数は「SupplierStock：仕入在庫数」ではなく「ShipmentPosCnt:出荷可能数」です。
                    if (string.IsNullOrEmpty(stock.WarehouseCode))
                    {
                        this._orderDataTable[rowIndex].DspStockCnt = "";
                    }
                    else
                    {
                        this._orderDataTable[rowIndex].DspStockCnt = stock.ShipmentPosCnt.ToString();
                    }
                    // ---- ADD 袁磊 2012/08/30 redmine#31884 ---------<<<<<

                    //倉庫コード
                    this._orderDataTable[rowIndex].WarehouseCode = stock.WarehouseCode;

                    //倉庫名称(画面)
                    this._orderDataTable[rowIndex].DspWarehouseName = stock.WarehouseName;

                    //倉庫名称
                    this._orderDataTable[rowIndex].WarehouseName = stock.WarehouseName;

                    //棚番(画面)
                    this._orderDataTable[rowIndex].DspWarehouseShelfNo = stock.WarehouseShelfNo;

                    //棚番
                    this._orderDataTable[rowIndex].WarehouseShelfNo = stock.WarehouseShelfNo;
                }
                else
                {
                    //現在庫数(画面)
                    //this._orderDataTable[rowIndex].DspStockCnt = 0; // DEL 袁磊 2012/08/30 redmine#31884
                    this._orderDataTable[rowIndex].DspStockCnt = ""; // ADD 袁磊 2012/08/30 redmine#31884

                    //倉庫コード
                    this._orderDataTable[rowIndex].WarehouseCode = "";

                    //倉庫名称(画面)
                    this._orderDataTable[rowIndex].DspWarehouseName = "";

                    //倉庫名称
                    this._orderDataTable[rowIndex].WarehouseName = "";

                    //棚番(画面)
                    this._orderDataTable[rowIndex].DspWarehouseShelfNo = "";

                    //棚番
                    this._orderDataTable[rowIndex].WarehouseShelfNo = "";
                }
                #endregion
                #endregion
            }
            return (0);
        }

		/// <summary>
		/// 品番検索メイン処理
		/// </summary>
		/// <param name="rowIndex">テーブル行インディックス</param>
		/// <returns>0:正常 -1:選択なし</returns>
        /// <br>Update Note: 2012/08/30 袁磊</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分</br>
        /// <br>             Redmine#31884 手入力発注処理修正の対応</br>
		private int SearchPartsFromGoodsNoMain(int rowIndex)
		{
			string goodsCode = (string)this._orderDataTable[rowIndex].InpGoodsNo;
            int goodsMakerCd = (int)this._orderDataTable[rowIndex].GoodsMakerCd;
			int orderNo = this._orderDataTable[rowIndex].OrderNo;

			if (goodsCode.Trim() == "") return (-1);

			List<GoodsUnitData> list = null;
			int status = _stockInputInitDataAcs.SearchPartsFromGoodsNoForMstInf(goodsCode, goodsMakerCd, _defaultEnableOdrMakerCd, out list);

			//選択なし
			if(status == -1)
			{
				return (-1);

			}
			//該当品番なし
			else if (status == 1)
			{
                # region 該当品番なし
                //明細部入力判定
				this._stockInputAcs.IsDataChanged = true;

				//初期化処理
				_stockInputAcs.ClearStockRow(orderNo);

				//品番(画面)
				this._orderDataTable[rowIndex].InpGoodsNo = goodsCode;

				//品番
				this._orderDataTable[rowIndex].GoodsNo = goodsCode;
                this._orderDataTable[rowIndex].GoodsNoNoneHyphen = UoeCommonFnc.GetNoNoneHyphenString(goodsCode);

				//ＢＯ区分(画面)
				this._orderDataTable[rowIndex].InpBoCode = _defaultBoCode;

				//ＢＯ区分
				this._orderDataTable[rowIndex].BoCode = _defaultBoCode;

                //数量
                if ((double)this._orderDataTable[rowIndex].InpAcceptAnOrderCnt == 0)
                {
                    this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = 1;
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = 1;
                }

                #endregion
            }
			//該当品番あり
			else
            {
                # region 該当品番あり
                //明細部入力判定
				this._stockInputAcs.IsDataChanged = true;

				//初期化処理
				_stockInputAcs.ClearStockRow(orderNo);

				//クラス設定
				GoodsUnitData goodsUnitData = list[0];
				List<Stock> stockList = list[0].StockList;
                List<GoodsPrice> goodsPriceList = list[0].GoodsPriceList; 

				//拠点倉庫の在庫情報
                Stock stock = _stockInputInitDataAcs.GetStock_FromSecInfoSet(stockList, goodsUnitData.SelectedWarehouseCode);

                //価格マスタの取得
                GoodsPrice goodsPrice = _stockInputInitDataAcs.GetGoodsPrice_FromGoodsPriceList(goodsPriceList);

                # region 商品情報
                //商品情報 -------------------------------------------------------------------------------------------------------
                //品番(画面)
				this._orderDataTable[rowIndex].InpGoodsNo = goodsUnitData.GoodsNo;

				//品番
				this._orderDataTable[rowIndex].GoodsNo = goodsUnitData.GoodsNo;

				//ＢＯ区分(画面)
				this._orderDataTable[rowIndex].InpBoCode = _defaultBoCode;

				//ＢＯ区分
				this._orderDataTable[rowIndex].BoCode = _defaultBoCode;

                //数量
                if ((double)this._orderDataTable[rowIndex].InpAcceptAnOrderCnt == 0)
                {
                    this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = 1;
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = 1;
                }

				//品名(画面)
				this._orderDataTable[rowIndex].InpBLGoodsName = goodsUnitData.GoodsName;

				//品名
				this._orderDataTable[rowIndex].GoodsName = goodsUnitData.GoodsName;

				//BL商品コード(画面)
				this._orderDataTable[rowIndex].InpBLGoodsCode = goodsUnitData.BLGoodsCode;

				//メーカーコード(画面)
				this._orderDataTable[rowIndex].InpGoodsMakerCd = goodsUnitData.MakerName;

				//メーカー(優良)
				this._orderDataTable[rowIndex].GoodsMakerCd = goodsUnitData.GoodsMakerCd;

				//メーカー名(純正)
				this._orderDataTable[rowIndex].InpMakerName = goodsUnitData.GoodsMakerCd;

				//メーカー名
				this._orderDataTable[rowIndex].MakerName = goodsUnitData.MakerName;

                // ハイフン無商品番号
                this._orderDataTable[rowIndex].GoodsNoNoneHyphen = goodsUnitData.GoodsNoNoneHyphen;

                //商品属性
                this._orderDataTable[rowIndex].GoodsKindCode = goodsUnitData.GoodsKindCode;

                //メーカーカナ名称
                this._orderDataTable[rowIndex].MakerKanaName = goodsUnitData.MakerKanaName;

                //商品名称カナ
                this._orderDataTable[rowIndex].GoodsNameKana = goodsUnitData.GoodsNameKana;

                //商品大分類コード
                this._orderDataTable[rowIndex].GoodsLGroup = goodsUnitData.GoodsLGroup;

                //商品大分類名称
                this._orderDataTable[rowIndex].GoodsLGroupName = goodsUnitData.GoodsLGroupName;

                //商品中分類コード
                this._orderDataTable[rowIndex].GoodsMGroup = goodsUnitData.GoodsMGroup;

                //商品中分類名称
                this._orderDataTable[rowIndex].GoodsMGroupName = goodsUnitData.GoodsMGroupName;

                //BLグループコード
                this._orderDataTable[rowIndex].BLGroupCode = goodsUnitData.BLGroupCode;

                //BLグループコード名称
                this._orderDataTable[rowIndex].BLGroupName = goodsUnitData.BLGroupName;

                //BL商品コード
                this._orderDataTable[rowIndex].BLGoodsCode = goodsUnitData.BLGoodsCode;

                //BL商品コード名称（全角）
                this._orderDataTable[rowIndex].BLGoodsFullName = goodsUnitData.BLGoodsFullName;

                //BL商品コード（掛率）
                this._orderDataTable[rowIndex].RateBLGoodsCode = goodsUnitData.BLGoodsCode;

                //BL商品コード名称（掛率）
                this._orderDataTable[rowIndex].RateBLGoodsName = goodsUnitData.BLGoodsFullName;

                //仕入在庫取寄せ区分
                this._orderDataTable[rowIndex].StockOrderDivCd = stock.WarehouseCode.Trim() == "" ? 0 : 1; //0:取寄せ,1:在庫

                //課税区分 0:課税,1:非課税,2:課税（内税）
                this._orderDataTable[rowIndex].TaxationCode = goodsUnitData.TaxationDivCd;
                #endregion

                # region 価格情報
                //価格情報 -------------------------------------------------------------------------------------------------------
                if (goodsPrice != null)
                {
                    // 定価（浮動）
                    this._orderDataTable[rowIndex].ListPrice = goodsPrice.ListPrice;

                    // 原価単価
                    this._orderDataTable[rowIndex].SalesUnitCost = goodsPrice.SalesUnitCost;

                    //オープン価格区分
                    this._orderDataTable[rowIndex].OpenPriceDiv = goodsPrice.OpenPriceDiv;

                    //定価（税抜，浮動）
                    this._orderDataTable[rowIndex].ListPriceTaxExcFl = goodsPrice.ListPrice;

                    //定価（税込，浮動）
                    this._orderDataTable[rowIndex].ListPriceTaxIncFl =
                        _stockInputInitDataAcs.GetStockPriceTaxInc(goodsPrice.ListPrice, goodsUnitData.TaxationDivCd, goodsUnitData.StockCnsTaxFrcProcCd);

                    //変更前定価
                    this._orderDataTable[rowIndex].BfListPrice = goodsPrice.ListPrice;
                }
                #endregion

                # region 在庫情報
                //在庫情報 -------------------------------------------------------------------------------------------------------
                if (stock != null)
                {
                    //現在庫数(画面)
                    //this._orderDataTable[rowIndex].DspStockCnt = stock.SupplierStock; // DEL 袁磊 2012/08/30 redmine#31884
                    // ---- ADD 袁磊 2012/08/30 redmine#31884 --------->>>>>>>>>>>>>>>
                    //現在庫数は「SupplierStock：仕入在庫数」ではなく「ShipmentPosCnt:出荷可能数」です。
                    if (string.IsNullOrEmpty(stock.WarehouseCode))
                    {
                        this._orderDataTable[rowIndex].DspStockCnt = "";
                    }
                    else
                    {
                        this._orderDataTable[rowIndex].DspStockCnt = stock.ShipmentPosCnt.ToString();
                    }
                    // ---- ADD 袁磊 2012/08/30 redmine#31884 ---------<<<<<<<<<<<<<<<<

                    //倉庫コード
                    this._orderDataTable[rowIndex].WarehouseCode = stock.WarehouseCode;

                    //倉庫名称(画面)
                    this._orderDataTable[rowIndex].DspWarehouseName = stock.WarehouseName;

                    //倉庫名称
                    this._orderDataTable[rowIndex].WarehouseName = stock.WarehouseName;

                    //棚番(画面)
                    this._orderDataTable[rowIndex].DspWarehouseShelfNo = stock.WarehouseShelfNo;

                    //棚番
                    this._orderDataTable[rowIndex].WarehouseShelfNo = stock.WarehouseShelfNo;
                }
                #endregion
                #endregion
            }
			return (0);
		}
        #endregion

        #endregion

        #region ■ボタンEnabled変更後イベント
		/// <summary>
		/// 挿入ボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowInsert_EnabledChanged(object sender, EventArgs e)
		{
			this._rowInsertButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// 削除ボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
		{
			this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// 切り取りボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCut_EnabledChanged(object sender, EventArgs e)
		{
			this._rowCutButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// コピーボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCopy_EnabledChanged(object sender, EventArgs e)
		{
			this._rowCopyButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// 貼り付けボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowPaste_EnabledChanged(object sender, EventArgs e)
		{
			this._rowPasteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}
		# endregion

		#endregion

		#region ■ツールバーイベント
		/// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				//挿入
				case "ButtonTool_RowInsert":
					{
						this.uButton_RowInsert_Click(this.uButton_RowInsert, new EventArgs());
						break;
					}
				//削除
				case "ButtonTool_RowDelete":
					{
						this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
						break;
					}
				//複写
				case "ButtonTool_RowCopy":
					{
						this.uButton_RowCopy_Click(this.uButton_RowCopy, new EventArgs());
						break;
					}
				//切取
				case "ButtonTool_RowCut":
					{
						this.uButton_RowCut_Click(this.uButton_RowCut, new EventArgs());
						break;
					}
				//貼付
				case "ButtonTool_RowPaste":
					{
						this.uButton_RowPaste_Click(this.uButton_RowPaste, new EventArgs());

                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        break;
					}
			}
		}
        #endregion

        private void uGrid_Details_CellListSelect(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            // メーカー(純正)
			if (cell.Column.Key == this._orderDataTable.InpMakerNameColumn.ColumnName)
			{
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
 			}
        }
	}
}
