//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信ＵＩ処理 明細コントロールクラス
// プログラム概要   : ＵＯＥ送信処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10504551-00 作成担当 : 21024 佐々木
// 作 成 日  2009/09/16  修正内容 : MANTIS【0014302】対応
//                                  ・在庫一括発注を行う際に数量変更できるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/02  修正内容 : 既存の不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2012/11/21  修正内容 : 2013/01/16配信分　Redmine#33506
//                                  伝発発注、検索発注の場合、グリッドに発注先を追加する対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
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

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＵＯＥ送信処理 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＵＯＥ送信処理の明細入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2008.05.12</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/12/02 李占川 保守依頼③対応</br>
    /// <br>             既存の不具合修正</br>
    /// <br>UpdateNote : 2012/11/21 田建委</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
    /// </remarks>
	public partial class PMUOE01001UB : UserControl 
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constroctors
		/// <summary>
		/// 入力明細入力コントロールクラス デフォルトコンストラクタ
		/// </summary>
		public PMUOE01001UB()
		{
			InitializeComponent();

			// ボタン初期化
			this._rowSelectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowSelect"];
			this._rowCancellButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCancell"];

			this._stockInputAcs = StockInputAcs.GetInstance();
			this._stockInputInitDataAcs = StockInputInitDataAcs.GetInstance();
			this._orderDataTable = this._stockInputAcs.orderDataTable;

			this._imageList16 = IconResourceManagement.ImageList16;
			this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			this._memoButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			this._pStockInputAcs = StockInputAcs.GetInstance();

			//データテーブル列表示設定クラスセッティング処理
			this.SettingStockExpansionRowVisibleControl();

        }
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;									// イメージリスト        
		private StockInputAcs _stockInputAcs;
		private StockInputInitDataAcs _stockInputInitDataAcs;
		private StockInputDataSet.OrderExpansionDataTable _orderDataTable;
		private StockInputAcs _pStockInputAcs;
		private Image _guideButtonImage;
		private Image _memoButtonImage;
		private ProductStockRowVisibleControl _productStockRowVisibleControl = new ProductStockRowVisibleControl();
		private int _verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _updEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
        private string _updEmployeeName = LoginInfoAcquisition.Employee.Name.Trim();

		//グリッド入力前値
		private double _beforeAcceptAnOrderCnt = 0;	//数量
        private string _beforeBoCode = "";			//ＢＯ区分

		//グリッド移動可能値
		private bool _cannotAcceptAnOrderCnt = false;	//数量
        private bool _cannotBoCode = false;				//ＢＯ区分

		//ボタン定義
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowSelectButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCancellButton;

		//カラー定義
		private static readonly Color DISABLE_COLOR = Color.Gainsboro;
		private static readonly Color DISABLE_FONT_COLOR = Color.Black;
		private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
		private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
		private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
		private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
		private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

		//業務区分
		private int _businessCode = ctTerminalDiv_Order;

        //システム区分
        private int _systemDivCd = ctSysDiv_Slip;


        //ヘッダー部画面入力クラス
        private InpHedDisplay _inpHedDisplay = null;
        //private int _nowOnlineNo = 0;

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//入力メッセージ
		private const string MESSAGE_SupplierCd = "発注先を選択してください。";
		private const string MESSAGE_AcceptAnOrderCnt = "数量を入力してください。";
        private const string MESSAGE_BoCode = "ＢＯ区分を入力してください。";
		private const string MESSAGE_UoeRemark1 = "リマーク１を入力してください";
		private const string MESSAGE_UoeRemark2 = "リマーク２を入力してください";
		private const string MESSAGE_SectionCode = "拠点を選択してください。";
		private const string MESSAGE_DeliveredGoodsDiv = "納品区分を選択してください。";
		private const string MESSAGE_HDeliveredGoodsDiv = "Ｈ納品区分を選択してください。";

		//業務区分
        private const Int32 ctTerminalDiv_Order = 1;	//発注
        private const Int32 ctTerminalDiv_Estm = 2;	//見積
        private const Int32 ctTerminalDiv_Alloc = 3;	//在庫確認
        private const Int32 ctTerminalDiv_Cancel = 4;//取消処理

        //システム区分
        public const Int32 ctSysDiv_Slip = 1;	//伝発発注
        public const Int32 ctSysDiv_Srch = 2;	//検索発注
        public const Int32 ctSysDiv_stock = 3;	//在庫一括
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
		
		/// <summary>仕入金額変更後イベント</summary>
		//internal event EventHandler StockPriceChanged;
		
		/// <summary>ステータスバーメッセージ表示イベント</summary>
		internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;

		/// <summary>フォーカス設定イベント</summary>
		internal event SettingFocusEventHandler FocusSetting;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region 業務区分
        /// <summary>
		/// 業務区分
		/// </summary>
		public int BusinessCode
		{
			get
			{
				return this._businessCode;
			}
			set
			{
				this._businessCode = value;
			}
		}
		# endregion

        # region システム区分
        /// <summary>
		/// システム区分
		/// </summary>
		public int SystemDivCd
		{
			get
			{
				return this._systemDivCd;
			}
			set
			{
				this._systemDivCd = value;
			}
		}
		# endregion


        # region ＵＯＥ送受信ＪＮＬアクセスクラス
        /// <summary>
        /// ＵＯＥ送受信ＪＮＬアクセスクラス
        /// </summary>
        public UoeSndRcvJnlAcs uoeSndRcvJnlAcs
        {
            get { return _stockInputInitDataAcs.uoeSndRcvJnlAcs; }
        }
        # endregion

        # region UOE発注先マスタアクセスクラス
        /// <summary>
        /// UOE発注先マスタアクセスクラス
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return _stockInputInitDataAcs.uOESupplierAcs; }
        }
        # endregion

        # region ヘッダー部画面入力
        /// <summary>
        /// ヘッダー部画面入力
        /// </summary>
        public InpHedDisplay inpHedDisplay
        {
            get
            {
                return this._inpHedDisplay;
            }
            set
            {
                this._inpHedDisplay = value;
            }
        }
        # endregion

        # region グリッド検索結果データビュー
        /// <summary>
        /// グリッド検索結果データビュー
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        public DataView searchDataView
        {
            get { return this._stockInputAcs.searchDataView; }
            set { this._stockInputAcs.searchDataView = value; }
        }
        # endregion

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

			// 数量
			if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
            {
                # region 数量
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
                # endregion
            }

            //ＢＯ区分
            else if (cell.Column.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
            {
                # region ＢＯ区分
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
                # endregion
            }

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
        /// <remarks>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
		private void SettingStockExpansionRowVisibleControl()
		{
            //ColumunName , Type , Mode , Hidden
			// Mode 1:発注 2:見積 3:在庫確認 4:取消処理

			//[番号]
			# region [番号]
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoDisplayColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoDisplayColumn.ColumnName, StatusType.Default, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoDisplayColumn.ColumnName, StatusType.Default, 3, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoDisplayColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

			//[選択]
			# region [選択]
			this._productStockRowVisibleControl.Add(this._orderDataTable.InpSelectColumn.ColumnName, StatusType.Default, 1, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.InpSelectColumn.ColumnName, StatusType.Default, 2, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.InpSelectColumn.ColumnName, StatusType.Default, 3, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.InpSelectColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

            //[端末]
            # region [端末]
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNoColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNoColumn.ColumnName, StatusType.Default, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNoColumn.ColumnName, StatusType.Default, 3, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNoColumn.ColumnName, StatusType.Default, 4, false);
            # endregion

            //[端末2]
            # region [端末2]
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNo2Column.ColumnName, StatusType.Default, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNo2Column.ColumnName, StatusType.Default, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNo2Column.ColumnName, StatusType.Default, 3, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNo2Column.ColumnName, StatusType.Default, 4, true);
            # endregion

            //[呼出番号]
            # region [呼出番号]
            this._productStockRowVisibleControl.Add(this._orderDataTable.OnlineNoColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OnlineNoColumn.ColumnName, StatusType.Default, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OnlineNoColumn.ColumnName, StatusType.Default, 3, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OnlineNoColumn.ColumnName, StatusType.Default, 4, false);
            # endregion

			//[入力日]
			# region [入力日]
			//[発注日] OrderDataCreateDate
			this._productStockRowVisibleControl.Add(this._orderDataTable.InputDayColumn.ColumnName, StatusType.Default, 1, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.InputDayColumn.ColumnName, StatusType.Default, 2, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.InputDayColumn.ColumnName, StatusType.Default, 3, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.InputDayColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

            //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
            //[倉庫名]
            # region [倉庫名]
            this._productStockRowVisibleControl.Add(this._orderDataTable.WareHouseNameColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.WareHouseNameColumn.ColumnName, StatusType.Default, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.WareHouseNameColumn.ColumnName, StatusType.Default, 3, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.WareHouseNameColumn.ColumnName, StatusType.Default, 4, false);
            # endregion
            //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<

			//[得意先]
			# region [得意先]
			this._productStockRowVisibleControl.Add(this._orderDataTable.CustomerSnmColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CustomerSnmColumn.ColumnName, StatusType.Default, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CustomerSnmColumn.ColumnName, StatusType.Default, 3, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CustomerSnmColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

			//[発注先名]
			# region [発注先名]
			this._productStockRowVisibleControl.Add(this._orderDataTable.UOESupplierNameColumn.ColumnName, StatusType.Default, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOESupplierNameColumn.ColumnName, StatusType.Default, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOESupplierNameColumn.ColumnName, StatusType.Default, 3, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOESupplierNameColumn.ColumnName, StatusType.Default, 4, true);
			# endregion

			//[品番]
			# region [品番]
			//[商品コード] GoodsNo
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 1, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 2, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 3, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

			//[ﾒｰｶｰ]
			# region [ﾒｰｶｰ]
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 3, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

			//[品名]
			# region [品名]
			//[商品名] GoodsName
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 1, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 2, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 3, false);
			this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

			//[数量]
			# region [数量]
			this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.Default, 2, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.Default, 3, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.Default, 4, false);
			# endregion

			//[ＢＯ区分]
			# region [ＢＯ区分]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.Default, 1, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.Default, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.Default, 3, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBoCodeColumn.ColumnName, StatusType.Default, 4, true);
			# endregion

			//[リマーク１]
			# region [リマーク１]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark1Column.ColumnName, StatusType.Default, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark1Column.ColumnName, StatusType.Default, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark1Column.ColumnName, StatusType.Default, 3, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark1Column.ColumnName, StatusType.Default, 4, true);
			# endregion

			//[リマーク２]
			# region [リマーク２]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark2Column.ColumnName, StatusType.Default, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark2Column.ColumnName, StatusType.Default, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark2Column.ColumnName, StatusType.Default, 3, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark2Column.ColumnName, StatusType.Default, 4, true);
			# endregion

			//[拠点]
			# region [拠点]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEResvdSectionColumn.ColumnName, StatusType.Default, 1, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEResvdSectionColumn.ColumnName, StatusType.Default, 2, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEResvdSectionColumn.ColumnName, StatusType.Default, 3, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEResvdSectionColumn.ColumnName, StatusType.Default, 4, true);
			# endregion

			//[納品区分]
			# region [納品区分]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName, StatusType.Default, 1, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName, StatusType.Default, 2, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName, StatusType.Default, 3, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName, StatusType.Default, 4, true);
			# endregion

			//[Ｈ納品区分]
			# region [Ｈ納品区分]
            this._productStockRowVisibleControl.Add(this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName, StatusType.Default, 1, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName, StatusType.Default, 2, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName, StatusType.Default, 3, true);
			this._productStockRowVisibleControl.Add(this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName, StatusType.Default, 4, true);
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
        /// <param name="businessCode">業務区分</param>
        /// <param name="businessCode">システム区分</param>
        internal void SettingGrid(int businessCode, int systemDivCd)
		{
            BusinessCode = businessCode;
            SystemDivCd = systemDivCd;
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
				this.SettingGridColVisible(StatusType.Default, BusinessCode);
                this.SettingGridSupply(SystemDivCd); // ADD 2009/11/23

				// 描画が必要な明細件数を取得する。
				int cnt = this._orderDataTable.Count;

				// 各行ごとの設定
				for (int i = 0; i < cnt; i++)
				{
                    this.SettingGridRow(i);
				}

				// 表示用行番号調整処理
				this._stockInputAcs.AdjustRowNo();

                // セルアクティブ時ボタン有効無効コントロール処理
                this.ActiveCellButtonEnabledControl(0, null);

                //グリッドのリストセット処理
                //this.SetGridList();

                //View設定
                string viewString = "";
                if (BusinessCode == ctTerminalDiv_Estm)
                {
                    // 削除日列のindexを取得
                    int index = -1;
                    for (int i = 0; i < this._orderDataTable.Columns.Count; i++)
                    {
                        if(this._orderDataTable.Columns[i].ColumnName == this._orderDataTable.CommAssemblyIdColumn.ColumnName)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index >= 0)
                    {
                        // 行フィルタがバンドに基づいている場合、バンドの列フィルタを外す。
                        Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;
                        columnFilters.ClearAllFilters();
                        columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.LessThan, "1000");

                        viewString = string.Format("{0} < '1000'", this._orderDataTable.CommAssemblyIdColumn.ColumnName);
                    }
                }
                else
                {
                    // 行フィルタがバンドに基づいている場合、バンドの列フィルタを外す。
                    Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;
                    columnFilters.ClearAllFilters();
                    viewString = "";
                }

                //行番号の再設定
                this.searchDataView.RowFilter = viewString;
                for (int i = 0; i < this.searchDataView.Count; i++ )
                {
                    // 指定行の内容を取得
                    DataRow row = this.searchDataView[i].Row;
                    row[this._orderDataTable.OrderNoDisplayColumn.ColumnName] = i + 1;
                }

                //初期フォーカス位置
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
				this.MoveNextAllowEditCell(true);
            }
			finally
			{
				// 描画を開始
				this.uGrid_Details.EndUpdate();
			}
		}

        // --- ADD 2009/11/23 ---------->>>>>
        /// <summary>
        /// 明細グリッド設定処理(システム区分より)
        /// </summary>
        /// <remarks>
        /// <br>Note		: システム区分は変更の時、設定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// <br>Update Note : 2012/11/21 田建委</br>
        /// <br>管理番号    : 2013/01/16配信分</br>
        /// <br>              Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        internal void SettingGridSupply(int systemDivCd)
        {
            // すべての列の表示非表示設定
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            switch (systemDivCd)
            {
                case 3:
                    {
                        editBand.Columns["UOESupplierName"].Hidden = false;
                        editBand.Columns["CustomerSnm"].Hidden = true;
                        break;
                    }
                default:
                    {
                        //editBand.Columns["UOESupplierName"].Hidden = true; // DEL 2012/11/21 田建委 Redmine#33506
                        editBand.Columns["UOESupplierName"].Hidden = false; // ADD 2012/11/21 田建委 Redmine#33506
                        editBand.Columns["CustomerSnm"].Hidden = false;
                        break;
                    }
            }
        }
        // --- ADD 2009/11/23 ----------<<<<<
		# endregion

        //----- ADD 2012/11/21 田建委 Redmine#33506 -------------------->>>>>
        /// <summary>
        /// グリッドのフィルタされた状態の判断
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドのフィルタされた状態を判断する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/11/21</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        public bool IsColumnFilter()
        {
            bool isColumnFilter = false;
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];

            if (((FilterConditionsCollection)editBand.ColumnFilters[this._orderDataTable.UOESupplierNameColumn.ColumnName].FilterConditions).Count != 0)
            {
                isColumnFilter = true;
            }

            return isColumnFilter;
        }

        # region [グリッドカラム情報 保存・復元]
        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : グリッドカラム情報を保存する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/11/21</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        public void SaveGridColumnsSetting(out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : グリッドカラム情報を読み込み。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/11/21</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        public void LoadGridColumnsSetting(List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            // 一度、全てのカラムのFixedを解除する
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = this.uGrid_Details.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                    ultraGridColumn.Hidden = columnInfo.Hidden;
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }

            // 列並び換え後、まとめてFixedを設定する。
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = this.uGrid_Details.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }
        # endregion
        //----- ADD 2012/11/21 田建委 Redmine#33506 --------------------<<<<<

		# region グリッドのリストセット処理
        /// <summary>
        /// グリッドのリストセット処理
        /// </summary>
        internal void SetGridList()
		{
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Rows)
            {
                int defaultUOESupplierCd = (int)ultraGridRow.Cells[this._orderDataTable.UOESupplierCdColumn.ColumnName].Value;

                Infragistics.Win.ValueList boCodeList = null;
                this._stockInputInitDataAcs.SetUOEGuideNameComboEditor(out boCodeList, 1, defaultUOESupplierCd);
                boCodeList.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
                boCodeList.DropDownListMinWidth = 0;

                //設定処理
                ultraGridRow.Cells[this._orderDataTable.InpBoCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                ultraGridRow.Cells[this._orderDataTable.InpBoCodeColumn.ColumnName].ValueList = boCodeList;
            }
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

			//通信プログラムＩＤ
            string commAssemblyId = this._orderDataTable[rowIndex].CommAssemblyId;

			// 行ステータスを取得
			int rowStatus = 0;


			// 指定行の全ての列に対して設定を行う。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// セル情報を取得
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
				if (cell == null) continue;

    			cell.Row.Hidden = false;
				//業務区分＝取消処理
                switch (BusinessCode)
                {
                    //-----------------------------------------------------------
                    // 業務区分＝取消処理
                    //-----------------------------------------------------------
                    case ctTerminalDiv_Cancel:
                        # region 業務区分＝取消処理
       					//選択
                        if (col.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        }
                        //他項目
                        else
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        }
                        # endregion
                        break;

                    //-----------------------------------------------------------
                    // 発注
                    //-----------------------------------------------------------
                    case ctTerminalDiv_Order:
                        # region 業務区分＝発注
       					//選択
                        if (col.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                        }
	    				//数量
                        else if (col.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
                        {
                            // 2009/09/16 >>>
                            //cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                            // 一括発注の場合は数量変更可
                            if (SystemDivCd == ctSysDiv_stock)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                            }
                            else
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                            }
                            // 2009/09/16 <<<
                        }
                        //ＢＯ区分
                        else if (col.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        }
                        //他項目
                        else
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        }
                        # endregion
                        break;

                    //-----------------------------------------------------------
                    // 見積
                    //-----------------------------------------------------------
                    case ctTerminalDiv_Estm:
                        # region 業務区分＝見積
                        //選択
                        if (col.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                        }
                        //数量
                        else if (col.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
                        {
                            //純正
                            if (this.uoeSndRcvJnlAcs.ChkCommAssemblyId(commAssemblyId) == true)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                            }
                            //優良
                            else
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                            }
                        }
                        //ＢＯ区分
                        else if (col.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                        }
                        //他項目
			            else
			            {
				            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			            }
                        # endregion
                        break;

                    //-----------------------------------------------------------
                    // 在庫確認
                    //-----------------------------------------------------------
                    case ctTerminalDiv_Alloc:
                        # region 業務区分＝在庫確認
                        //選択
                        if (col.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                        }
                        //数量
                        else if (col.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
                        {
                            //純正
                            if (this.uoeSndRcvJnlAcs.ChkCommAssemblyId(commAssemblyId) == true)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                            }
                            //優良
                            else
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                            }
                        }
                        //ＢＯ区分
                        else if (col.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                        }
                        //他項目
			            else
			            {
				            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			            }
                        # endregion
                        break;
                }

                //-----------------------------------------------------------
                // Appearanceの設定
                //-----------------------------------------------------------
                # region Appearanceの設定
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
                # endregion
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
			this.uButton_Select.ImageList = this._imageList16;
			this.uButton_Cancell.ImageList = this._imageList16;
			this.uButton_Guide.ImageList = this._imageList16;
			this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

			//Appearance.Image
			this.uButton_Select.Appearance.Image = (int)Size16_Index.SELECT;
			this.uButton_Cancell.Appearance.Image = (int)Size16_Index.DELETE;
			this.uButton_Guide.Appearance.Image = (int)Size16_Index.GUIDE;

			//選択許可設定
			this.uButton_Select.Enabled = false;
			this.uButton_Cancell.Enabled = false;
			this.uButton_Guide.Enabled = false;

			//Appearance.Image
			this._rowSelectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SELECT;
			this._rowCancellButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
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
			//this._stockInputAcs.OrderRowInitialSetting(99);

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
			//業務区分＝取消処理
			if((BusinessCode == ctTerminalDiv_Cancel)
            && (this._stockInputAcs.IsDataChanged != false))
			{
				this.uButton_Select.Enabled = true;
				this.uButton_Cancell.Enabled = true;
			}
			else
			{
				this.uButton_Select.Enabled = false;
				this.uButton_Cancell.Enabled = false;
			}

            // ガイドボタンの有効無効を設定する
            if ((colKey != null) &&
                //ＢＯ区分ガイド
                (colKey == this._orderDataTable.InpBoCodeColumn.ColumnName))
            {
                this.uButton_Guide.Enabled = true;
                this.uButton_Guide.Tag = colKey;
            }
            else
            {
                this.uButton_Guide.Enabled = false;
            }
		}
		# endregion
		# endregion

        // ===================================================================================== //
        // ヘッダー部処理
        // ===================================================================================== //
        # region ヘッダー部処理
        # region ■ 発注先の変更チェック
        /// <summary>
        /// 発注先の変更チェック
        /// </summary>
        /// <param name="uOESupplier">発注先オブジェクト</param>
        /// <param name="enableOdrMakerCd">メーカーコード</param>
        /// <returns></returns>
        private bool ChangeUOESupplier(UOESupplier uOESupplier, Int32 makerCd)
        {
            //純正・優良→優良への変更時は可能とする
            if (this.uoeSndRcvJnlAcs.ChkCommAssemblyId(uOESupplier.CommAssemblyId) == false)
            {
                return(true);
            }

            List<Int32> enableOdrMakerCdList = new List<int>();
            enableOdrMakerCdList.Add(makerCd);
            return (this._stockInputInitDataAcs.ExistUOESupplierMaker(uOESupplier.UOESupplierCd, enableOdrMakerCdList));
        }
		# endregion

        # region ■（イベント）依頼者Ｅｎｔｅｒ
        /// <summary>
        /// （イベント）依頼者Ｅｎｔｅｒ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tEdit_EmployeeCode_Enter(object sender, EventArgs e)
        {
            if (inpHedDisplay == null) return;

            this.uButton_Guide.Enabled = true;
            this.uButton_Guide.Tag = "tEdit_EmployeeCode";
            this.tEdit_EmployeeCode.Text = inpHedDisplay.EmployeeCode;
        }
        # endregion

        # region ■（イベント）依頼者Ｌｅａｖｅ
        /// <summary>
        /// （イベント）依頼者Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tEdit_EmployeeCode_Leave(object sender, EventArgs e)
        {
            if (inpHedDisplay == null) return;

            bool bStatus = true;
            string setCd = inpHedDisplay.EmployeeCode;
            string setNm = inpHedDisplay.EmployeeName;

            //-----------------------------------------------------------
            //入力値が空白
            //-----------------------------------------------------------
            if (this.tEdit_EmployeeCode.Text == string.Empty)
            {
                # region 入力値が空白
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "依頼者を入力して下さい。",
                //    -1,
                //    MessageBoxButtons.OK);

                setCd = string.Empty;
                setNm = string.Empty;
                //bStatus = false;
                # endregion
            }
            //-----------------------------------------------------------
            //入力値の変更あり
            //-----------------------------------------------------------
            else if (this.tEdit_EmployeeCode.Text != inpHedDisplay.EmployeeCode)
            {
                //-----------------------------------------------------------
                //入力値の取得
                //-----------------------------------------------------------
                # region 入力値の変更あり
                //依頼者の取得
                int cd = 0;
                try
                {
                    cd = int.Parse(this.tEdit_EmployeeCode.Text);
                }
                catch (Exception)
                {
                    cd = 0;
                }
                string codeString = cd.ToString("d4");

                if (this._stockInputInitDataAcs.EmployeeExists(codeString) == true)
                {
                    setCd = codeString.Trim();
                    setNm = _stockInputInitDataAcs.GetName_FromEmployee(codeString);
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "依頼者が存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    bStatus = false;
                }
                # endregion
            }
            //-----------------------------------------------------------
            //値の設定
            //-----------------------------------------------------------
            _inpHedDisplay.EmployeeCode = setCd;
            _inpHedDisplay.EmployeeName = setNm;
            this._stockInputAcs.UpdtHedaerItem(_inpHedDisplay, 1);

            this.tEdit_EmployeeCode.Text = setNm;

            //-----------------------------------------------------------
            // エラー処理
            //-----------------------------------------------------------
            if (bStatus == false)
            {
                this.tEdit_EmployeeCode.Focus();
            }
        }
        # endregion

        # region ■（イベント）ＵＯＥ発注先Ｅｎｔｅｒ
        /// <summary>
        /// （イベント）ＵＯＥ発注先Ｅｎｔｅｒ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tEdit_UOESupplierCd_Enter(object sender, EventArgs e)
        {
            if (inpHedDisplay == null) return;

            this.uButton_Guide.Enabled = true;
            this.uButton_Guide.Tag = "tEdit_UOESupplierCd";
            this.tEdit_UOESupplierCd.Text = inpHedDisplay.UOESupplierCd.ToString("d6");
        }
        # endregion

        # region ■（イベント）ＵＯＥ発注先Ｌｅａｖｅ
        /// <summary>
        /// （イベント）ＵＯＥ発注先Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tEdit_UOESupplierCd_Leave(object sender, EventArgs e)
        {
            if (inpHedDisplay == null) return;

            bool bStatus = true; 
            int setCd = inpHedDisplay.UOESupplierCd;
            string setNm = inpHedDisplay.UOESupplierName;

            //-----------------------------------------------------------
            //入力値が空白
            //-----------------------------------------------------------
            if (this.tEdit_UOESupplierCd.Text == string.Empty)
            {
                # region 入力値が空白
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "発注先を入力して下さい。",
                    -1,
                    MessageBoxButtons.OK);
                bStatus = false;
                # endregion
            }
            //-----------------------------------------------------------
            //入力値の変更あり
            //-----------------------------------------------------------
            else if(this.tEdit_UOESupplierCd.Text != inpHedDisplay.UOESupplierCd.ToString())
            {
                //-----------------------------------------------------------
                //入力値の取得
                //-----------------------------------------------------------
                # region 入力値の変更あり
                int cd = 0;
                try
                {
                    cd = int.Parse(this.tEdit_UOESupplierCd.Text);
                }
                catch (Exception)
                {
                    cd = 0;
                }

                //ＵＯＥ発注先の取得
                if (this._stockInputInitDataAcs.UOESupplierExists(cd) == true)
                {
                    //ＵＯＥ発注先の取得
                    UOESupplier uOESupplier = this._stockInputInitDataAcs.GetUOESupplier(cd);

                    //メーカーコードの取得
                    Int32 makerCd = (Int32)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.GoodsMakerCdColumn.ColumnName].Value); ;
                    if (ChangeUOESupplier(uOESupplier, makerCd) == true)
                    {
                        setCd = uOESupplier.UOESupplierCd;
                        setNm = uOESupplier.UOESupplierName;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "変更先の発注先には、発注可能メーカーではありません。",
                            -1,
                            MessageBoxButtons.OK);
                        bStatus = false;
                    }
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "発注先が存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    bStatus = false;
                }
                # endregion

                //-----------------------------------------------------------
                //値の変更処理
                //-----------------------------------------------------------
                # region 値の変更処理
                if (inpHedDisplay.UOESupplierCd != setCd)
                {
                    // 発注先
                    inpHedDisplay.UOESupplierCd = setCd;
                    inpHedDisplay.UOESupplierName = setNm;

                    //リマーク１
                    // 優良の仕入受信ありの場合、「*Z」を設定
                    //ＵＯＥ発注先の取得
                    if((uoeSndRcvJnlAcs.ChkMeiji(inpHedDisplay.UOESupplierCd) == true)
                    && (inpHedDisplay.BusinessCode == ctTerminalDiv_Alloc))
                    {
                        inpHedDisplay.UoeRemark1 = "*Z";
                    }

                    // 納品区分
                    inpHedDisplay.UOEDeliGoodsDiv = string.Empty;

                    // Ｈ納品区分
                    inpHedDisplay.FollowDeliGoodsDiv = string.Empty;

                    // 指定拠点
                    inpHedDisplay.UOEResvdSection = string.Empty;

                    ReSettingUOESupplier();
                }
                # endregion
            }

            //-----------------------------------------------------------
            //値の設定
            //-----------------------------------------------------------
            inpHedDisplay.UOESupplierCd = setCd;
            inpHedDisplay.UOESupplierName = setNm;
            this.tEdit_UOESupplierCd.Text = setNm;

            this._stockInputAcs.UpdtHedaerItem(_inpHedDisplay, 0);

            //-----------------------------------------------------------
            // エラー処理
            //-----------------------------------------------------------
            if (bStatus == false)
            {
                this.tEdit_UOESupplierCd.Focus();
            }
        }
        # endregion

        # region ■（イベント）リマーク１Ｌｅａｖｅ
        /// <summary>
        /// （イベント）リマーク１Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tEdit_UoeRemark1_Leave(object sender, EventArgs e)
        {
            _inpHedDisplay.UoeRemark1 = tEdit_UoeRemark1.Text;
            this._stockInputAcs.UpdtHedaerItem(_inpHedDisplay, 1);
        }
        # endregion

        # region ■（イベント）リマーク２Ｌｅａｖｅ
        /// <summary>
        /// （イベント）リマーク２Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tEdit_UoeRemark2_Leave(object sender, EventArgs e)
        {
            _inpHedDisplay.UoeRemark2 = tEdit_UoeRemark2.Text;
            this._stockInputAcs.UpdtHedaerItem(_inpHedDisplay, 1);
        }
        # endregion

        # region ■（イベント）納品区分Ｌｅａｖｅ
        /// <summary>
        /// （イベント）納品区分Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tComboEditor_UOEDeliGoodsDiv_Leave(object sender, EventArgs e)
        {
            _inpHedDisplay.UOEDeliGoodsDiv = (string)tComboEditor_UOEDeliGoodsDiv.Value;
            _inpHedDisplay.DeliveredGoodsDivNm = this._stockInputInitDataAcs.GetName_FromUOEGuideName(2, _inpHedDisplay.UOESupplierCd, _inpHedDisplay.UOEDeliGoodsDiv);
            this._stockInputAcs.UpdtHedaerItem(_inpHedDisplay, 2);
        }
        # endregion

        # region ■（イベント）Ｈ納品区分Ｌｅａｖｅ
        /// <summary>
        /// （イベント）Ｈ納品区分Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tComboEditor_FollowDeliGoodsDiv_Leave(object sender, EventArgs e)
        {
            _inpHedDisplay.FollowDeliGoodsDiv = (string)tComboEditor_FollowDeliGoodsDiv.Value;
            _inpHedDisplay.FollowDeliGoodsDivNm = this._stockInputInitDataAcs.GetName_FromUOEGuideName(2, _inpHedDisplay.UOESupplierCd, _inpHedDisplay.FollowDeliGoodsDiv);
            this._stockInputAcs.UpdtHedaerItem(_inpHedDisplay, 2);
        }
        # endregion

        # region ■（イベント）ＵＯＥ拠点Ｌｅａｖｅ
        /// <summary>
        /// （イベント）ＵＯＥ拠点Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        private void tComboEditor_UOEResvdSection_Leave(object sender, EventArgs e)
        {
            _inpHedDisplay.UOEResvdSection = (string)tComboEditor_UOEResvdSection.Value;
            _inpHedDisplay.UOEResvdSectionNm = this._stockInputInitDataAcs.GetName_FromUOEGuideName(3, _inpHedDisplay.UOESupplierCd, _inpHedDisplay.UOEResvdSection);
            this._stockInputAcs.UpdtHedaerItem(_inpHedDisplay, 2);
        }
        # endregion

        # region ■ UOE発注先の変更時処理
        /// <summary>
        /// UOE発注先の変更時処理
        /// </summary>
        /// <returns>ステータス</returns>
        private bool ReSettingUOESupplier()
        {
            //-----------------------------------------------------------
            // ＵＯＥ発注先の取得
            //-----------------------------------------------------------
            # region ＵＯＥ発注先の取得
            // ＵＯＥ発注先の取得
            UOESupplier uOESupplier = null;
            if (this._stockInputInitDataAcs.UOESupplierExists(inpHedDisplay.UOESupplierCd) == true)
            {
                uOESupplier = this._stockInputInitDataAcs.GetUOESupplier(inpHedDisplay.UOESupplierCd);
            }

            // ヘッダー部の入力制御
            HedaerItemInputInit(uOESupplier);
            if (uOESupplier == null) return (false);
            # endregion

            //-----------------------------------------------------------
            // ヘッダー部のデータ設定
            //-----------------------------------------------------------
            # region ヘッダー部のデータ設定
            // 発注先
            tEdit_UOESupplierCd.Text = _inpHedDisplay.UOESupplierName;

            // リマーク1
            tEdit_UoeRemark1.Text = _inpHedDisplay.UoeRemark1;

            // リマーク2
            tEdit_UoeRemark2.Text = _inpHedDisplay.UoeRemark2;

            // 納品区分
            tComboEditor_UOEDeliGoodsDiv.Value = _inpHedDisplay.UOEDeliGoodsDiv;

            // Ｈ納品区分
            tComboEditor_FollowDeliGoodsDiv.Value = _inpHedDisplay.FollowDeliGoodsDiv;

            // 指定拠点
            tComboEditor_UOEResvdSection.Value = _inpHedDisplay.UOEResvdSection;

            // 依頼者
            tEdit_EmployeeCode.Text = _inpHedDisplay.EmployeeName;
            # endregion

            return (true);
        }
        # endregion

        # region ■ ヘッダー部の入力制御
        /// <summary>
        /// ヘッダー部の入力制御
        /// </summary>
        /// <param name="uOESupplier">ＵＯＥ発注先オブジェクト</param>
        private void HedaerItemInputInit(UOESupplier uOESupplier)
        {
            //-----------------------------------------------------------
            // クリア処理
            //-----------------------------------------------------------
            tComboEditor_UOEDeliGoodsDiv.Clear();		// 納品区分
            tComboEditor_FollowDeliGoodsDiv.Clear();	// Ｈ納品区分
            tComboEditor_UOEResvdSection.Clear();       // 指定拠点
            tEdit_UoeRemark1.Clear();                   // リマーク１
            tEdit_UoeRemark2.Clear();                   // リマーク２
            tEdit_EmployeeCode.Clear();                 // 依頼者
            tEdit_UOESupplierCd.Clear();                // 発注先

            //-----------------------------------------------------------
            // Enabled設定
            //-----------------------------------------------------------
            if (uOESupplier == null)
            {
                tComboEditor_UOEDeliGoodsDiv.Enabled = false;		// 納品区分
                tComboEditor_FollowDeliGoodsDiv.Enabled = false;	// Ｈ納品区分
                tComboEditor_UOEResvdSection.Enabled = false;       // 指定拠点
                tEdit_UoeRemark1.Enabled = false;                   // リマーク１
                tEdit_UoeRemark2.Enabled = false;                   // リマーク２
                tEdit_EmployeeCode.Enabled = false;                 // 依頼者
                tEdit_UOESupplierCd.Enabled = false;                // 発注先
            }
            else
            {
                switch (BusinessCode)
                {
                    //発注
                    case ctTerminalDiv_Order:
                        this.tComboEditor_UOEDeliGoodsDiv.Enabled = true;		//納品区分
                        this.tComboEditor_FollowDeliGoodsDiv.Enabled = UOESupplierAcs.EnabledFollowDeliGoodsDiv(uOESupplier.CommAssemblyId);
                        this.tComboEditor_UOEResvdSection.Enabled = true;		//UOE指定拠点
                        this.tEdit_EmployeeCode.Enabled = true;				    //依頼者コード
                        this.tEdit_UoeRemark1.Enabled = true;                   //ＵＯＥリマーク１
                        this.tEdit_UoeRemark2.Enabled = true;					//ＵＯＥリマーク２
                        this.tEdit_UOESupplierCd.Enabled = true;                // 発注先
                        break;
                    //取消
                    case ctTerminalDiv_Cancel:
                        this.tComboEditor_UOEDeliGoodsDiv.Enabled = false;		//納品区分
                        this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;	//フォロー納品区分
                        this.tComboEditor_UOEResvdSection.Enabled = false;		//UOE指定拠点
                        this.tEdit_EmployeeCode.Enabled = false;				//依頼者コード
                        this.tEdit_UoeRemark1.Enabled = false;					//ＵＯＥリマーク１
                        this.tEdit_UoeRemark2.Enabled = false;					//ＵＯＥリマーク２
                        this.tEdit_UOESupplierCd.Enabled = false;               // 発注先
                        break;

                    //見積・在庫
                    default:
                        this.tComboEditor_UOEDeliGoodsDiv.Enabled = false;		//納品区分
                        this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;	//フォロー納品区分
                        this.tComboEditor_UOEResvdSection.Enabled = false;		//UOE指定拠点
                        this.tEdit_EmployeeCode.Enabled = true;				    //依頼者コード
                        this.tEdit_UoeRemark1.Enabled = true;                   //ＵＯＥリマーク１
                        this.tEdit_UoeRemark2.Enabled = true;					//ＵＯＥリマーク２
                        this.tEdit_UOESupplierCd.Enabled = true;                // 発注先
                        break;
                }
                //-----------------------------------------------------------
                // リマーク１・リマーク２の設定
                //-----------------------------------------------------------
                # region リマーク１・リマーク２の設定
                if (BusinessCode != ctTerminalDiv_Cancel)
                {
                    //リマーク１(８桁)
                    this.tEdit_UoeRemark1.ExtEdit.Column = UOESupplierAcs.MaxLengthUOERemark1(uOESupplier.CommAssemblyId);
                    this.tEdit_UoeRemark1.Enabled = UOESupplierAcs.EnabledUOERemark1(uOESupplier.CommAssemblyId);

                    //リマーク２(１０桁)
                    this.tEdit_UoeRemark2.ExtEdit.Column = UOESupplierAcs.MaxLengthUOERemark2(uOESupplier.CommAssemblyId);
                    this.tEdit_UoeRemark2.Enabled = UOESupplierAcs.EnabledUOERemark2(uOESupplier.CommAssemblyId);
                }
                //リマーク１
                //＜優良・仕入受信あり＞
                //システム区分＝在庫一括の場合
                if ((uoeSndRcvJnlAcs.ChkMeiji(uOESupplier) == true)
                && (SystemDivCd == ctSysDiv_stock))
                {
                    this.tEdit_UoeRemark1.Enabled = false;
                }
                # endregion

                //-----------------------------------------------------------
                // 納品区分
                //-----------------------------------------------------------
                # region 納品区分・Ｈ納品区分
                if (BusinessCode == ctTerminalDiv_Order)
                {
                    List<UOEGuideName> ListUOEDeliGoodsDiv = this._stockInputInitDataAcs.GetList_FromUOEGuideName(2, uOESupplier.UOESupplierCd);

                    if (ListUOEDeliGoodsDiv.Count > 0)
                    {
                        //納品区分
                        SetUOEGuideNameComboEditor(ref this.tComboEditor_UOEDeliGoodsDiv, ListUOEDeliGoodsDiv);
                        _inpHedDisplay.UOEDeliGoodsDiv = _stockInputInitDataAcs.GetDefaultUOEGuideCode(ListUOEDeliGoodsDiv, _inpHedDisplay.UOEDeliGoodsDiv);

                        //Ｈ納品区分
                        if (this.tComboEditor_FollowDeliGoodsDiv.Enabled == true)
                        {
                            SetUOEGuideNameComboEditor(ref this.tComboEditor_FollowDeliGoodsDiv, ListUOEDeliGoodsDiv);
                            _inpHedDisplay.FollowDeliGoodsDiv = _stockInputInitDataAcs.GetDefaultUOEGuideCode(ListUOEDeliGoodsDiv, _inpHedDisplay.FollowDeliGoodsDiv);
                        }
                    }
                    else
                    {
                        tComboEditor_UOEDeliGoodsDiv.Enabled = false;		//納品区分
                        tComboEditor_FollowDeliGoodsDiv.Enabled = false;	//Ｈ納品区分
                    }
                }
                # endregion

                //-----------------------------------------------------------
                // 指定拠点
                //-----------------------------------------------------------
                # region 指定拠点
                if (BusinessCode == ctTerminalDiv_Order)
                {
                    List<UOEGuideName> ListUOEResvdSection = this._stockInputInitDataAcs.GetList_FromUOEGuideName(3, _inpHedDisplay.UOESupplierCd);
                    if (ListUOEResvdSection.Count > 0)
                    {
                        SetUOEGuideNameComboEditor(ref this.tComboEditor_UOEResvdSection, ListUOEResvdSection);
                        _inpHedDisplay.UOEResvdSection = _stockInputInitDataAcs.GetDefaultUOEGuideCode(ListUOEResvdSection, _inpHedDisplay.UOEResvdSection);
                    }
                    else
                    {
                        tComboEditor_UOEResvdSection.Enabled = false;
                    }
                }
                # endregion
            }
        }
        # endregion

        # region ■ ヘッダー部のデータ取得
        /// <summary>
        /// 現在のActiveRowよりヘッダー部のデータ取得
        /// </summary>
        /// <returns>ヘッダー部クラス</returns>
        private InpHedDisplay GetHedaerItemFromActiveRow()
        {
            InpHedDisplay inpHedDisplay = new InpHedDisplay();

            if(this.uGrid_Details.ActiveRow == null)
            {
                inpHedDisplay = null;
            }
            else
            {
                inpHedDisplay.BusinessCode = BusinessCode;
                inpHedDisplay.OnlineNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value);
                inpHedDisplay.OnlineRowNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineRowNoColumn.ColumnName].Value);
                inpHedDisplay.UOESupplierCd = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UOESupplierCdColumn.ColumnName].Value);
                inpHedDisplay.UOESupplierName = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UOESupplierNameColumn.ColumnName].Value);
                inpHedDisplay.UoeRemark1 = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UoeRemark1Column.ColumnName].Value);
                inpHedDisplay.UoeRemark2 = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UoeRemark2Column.ColumnName].Value);

                if (inpHedDisplay.BusinessCode == ctTerminalDiv_Order)
                {
                    string uOEDeliGoodsDiv = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Value);
                    inpHedDisplay.UOEDeliGoodsDiv = uOEDeliGoodsDiv.Trim();
                    
                    inpHedDisplay.DeliveredGoodsDivNm = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.DeliveredGoodsDivNmColumn.ColumnName].Value);

                    string followDeliGoodsDiv = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Value);
                    inpHedDisplay.FollowDeliGoodsDiv = followDeliGoodsDiv.Trim();

                    inpHedDisplay.FollowDeliGoodsDivNm = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName].Value);

                    string uOEResvdSection = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UOEResvdSectionColumn.ColumnName].Value);
                    inpHedDisplay.UOEResvdSection = uOEResvdSection.Trim();

                    inpHedDisplay.UOEResvdSectionNm = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UOEResvdSectionNmColumn.ColumnName].Value);
                }
                else
                {
                    inpHedDisplay.UOEDeliGoodsDiv = string.Empty;
                    inpHedDisplay.DeliveredGoodsDivNm = string.Empty;
                    inpHedDisplay.FollowDeliGoodsDiv = string.Empty;
                    inpHedDisplay.FollowDeliGoodsDivNm = string.Empty;
                    inpHedDisplay.UOEResvdSection = string.Empty;
                    inpHedDisplay.UOEResvdSectionNm = string.Empty;
                }

                string employeeCode = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.EmployeeCodeColumn.ColumnName].Value);
                inpHedDisplay.EmployeeCode = employeeCode.Trim();
                inpHedDisplay.EmployeeName = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.EmployeeNameColumn.ColumnName].Value);
            }
            return(inpHedDisplay);
        }
        # endregion

        # region ■ ヘッダー部のクリア
        /// <summary>
        /// ヘッダー部のクリア
        /// </summary>
        public void ClearHedaerItem()
        {
            _inpHedDisplay = null;

            this.tComboEditor_UOEDeliGoodsDiv.Clear();
            this.tComboEditor_FollowDeliGoodsDiv.Clear();
            this.tComboEditor_UOEResvdSection.Clear();
            this.tEdit_EmployeeCode.Clear();
            this.tEdit_UoeRemark1.Clear();
            this.tEdit_UoeRemark2.Clear();
            this.tEdit_UOESupplierCd.Clear();

            this.tComboEditor_UOEDeliGoodsDiv.Enabled = false;		//納品区分
            this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;	//フォロー納品区分
            this.tComboEditor_UOEResvdSection.Enabled = false;		//UOE指定拠点
            this.tEdit_EmployeeCode.Enabled = false;				//依頼者コード
            this.tEdit_UoeRemark1.Enabled = false;					//ＵＯＥリマーク１
            this.tEdit_UoeRemark2.Enabled = false;					//ＵＯＥリマーク２
            this.tEdit_UOESupplierCd.Enabled = false;               // 発注先
        }
        # endregion

        # region ■ ヘッダー部のデータ設定
        /// <summary>
        /// ■ ヘッダー部のデータ設定
        /// </summary>
        public void SettingHedaerItem(Int32 onlineNo, Int32 onlineRowNo)
        {
            //-----------------------------------------------------------
            // ヘッダー部情報の更新判定
            //-----------------------------------------------------------
            # region ヘッダー部情報の更新処理
            //現在編集中のヘッダー情報と同一の場合は何もしない
            if((_inpHedDisplay != null)
            && (_inpHedDisplay.BusinessCode == BusinessCode)
            && (onlineNo == _inpHedDisplay.OnlineNo)
            && (onlineRowNo == _inpHedDisplay.OnlineRowNo)) return;
            # endregion

            //-----------------------------------------------------------
            // ヘッダー部のデータ取得
            //-----------------------------------------------------------
            # region ヘッダー部のデータ取得
            // ヘッダー部のデータ取得
            _inpHedDisplay = GetHedaerItemFromActiveRow();
            ReSettingUOESupplier();
            # endregion
        }
        # endregion

        # region ■ コンボエディタリスト設定(納品区分・フォロー納品区分・UOE指定拠点) ■
        /// <summary>
        /// コンボエディタ設定(納品区分・フォロー納品区分・UOE指定拠点)
        /// </summary>
        /// <param name="sender">コンボエディタ</param>
        /// <param name="list">設定用リスト</param>
        public void SetUOEGuideNameComboEditor(ref TComboEditor sender, List<UOEGuideName> list)
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();

            if (list != null)
            {
                foreach (UOEGuideName uOEGuideName in list)
                {
                    Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();

                    secInfoItem.DataValue = uOEGuideName.UOEGuideCode;
                    secInfoItem.DisplayText = uOEGuideName.UOEGuideNm.Trim();
                    valueList.ValueListItems.Add(secInfoItem);
                }
            }

            if (valueList.ValueListItems.Count > 0)
            {
                sender.Items.Clear();
                for (int i = 0; i < valueList.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    sender.Items.Add(vlltem);
                }

                sender.MaxDropDownItems = valueList.ValueListItems.Count;
                sender.Value = 0;

            }
            else
            {
                sender.Enabled = false;
            }
        }
        # endregion ■ 納品区分 ■
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
        /// <remarks>
        /// <br>Update Note : 2012/11/21 田建委</br>
        /// <br>管理番号    : 2013/01/16配信分</br>
        /// <br>              Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
		private void InitialSettingGridCol(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
			//表示順番
			int currentPosition = 0;

			//フォーマット設定
            //string moneyFormat = "#,##0;-#,##0;''";
			//string moneyFormat_Zero = "#,##0;-#,##0;'0'";
			string codeFormat = "#;";
            string codeFormat_GoodsMakerCd = "0000;";
            string codeFormat_CashRegisterNo = "000;";
            string codeFormat_OnlineNo = "000000000;";
            //string doubleFormat = "#,##0.00;-#,##0.00;''";
            string numFormat = "##0;";

			string _dateFormat = "yyyy/MM/dd";

			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if ( editBand == null ) return;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;

				// 「No列」以外の全てのセルのDiabledColorを設定する。
				if (col.Key != this._orderDataTable.OrderNoDisplayColumn.ColumnName)
				{
					col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
					col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
				}
			}

            // グリッド列表示非表示設定処理
			this.SettingGridColVisible(StatusType.Default, BusinessCode);

			// 明細部
			//[No.]
			#region [No.]
			//表示順位
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Width = 44;
			//固定列
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Header.Fixed = true;
			//タイトル名称
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Header.Caption = "No.";
			//入力許可
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			// CellAppearance設定
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			#endregion

			//選択
			#region [選択]
			//表示順位
			Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpSelectColumn.ColumnName].Width = 44;
			//固定列
			Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.Fixed = true;			// 固定項目
			//タイトル名称
			Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.Caption = "選択";
			//Style
			Columns[this._orderDataTable.InpSelectColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			Columns[this._orderDataTable.InpSelectColumn.ColumnName].AutoEdit = true;
			#endregion

            #region [端末]
            //[端末]
            //表示順位
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Width = 50;
            //固定列
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.Caption = "端末";
            //入力許可
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Format = codeFormat_CashRegisterNo;
            // MaxLength設定
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].MaxLength = 3;
            //CellAppearance
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            #region [送信端末番号]
            //[送信端末番号]
            //表示順位
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].Width = 50;
            //固定列
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].Header.Caption = "送信端末番号";
            //入力許可
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].Format = codeFormat_CashRegisterNo;
            // MaxLength設定
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].MaxLength = 3;
            //CellAppearance
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            #region [呼出番号]
            //[呼出番号] OrderNumber
			//表示順位
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
            //Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Width = 80; // DEL wangyl 2013/02/06 Redmine#34578
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Width = 85; // ADD wangyl 2013/02/06 Redmine#34578
			//固定列
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.Caption = "呼出番号";
			//入力許可
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Format = codeFormat_OnlineNo;
			// MaxLength設定
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].MaxLength = 20;
			//CellAppearance
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			#endregion

			//入力日
			#region [入力日]
			//[発注日] OrderDataCreateDate
			//表示順位
			Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InputDayColumn.ColumnName].Width = 90;
			//固定列
			Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.Caption = "入力日";
			//入力許可
			Columns[this._orderDataTable.InputDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.InputDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
			Columns[this._orderDataTable.InputDayColumn.ColumnName].Format = _dateFormat;
			//CellAppearance
			Columns[this._orderDataTable.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			#endregion

            //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
            //倉庫名
            #region [倉庫]
            //[倉庫名] WareHouseName
            //表示順位
            Columns[this._orderDataTable.WareHouseNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.WareHouseNameColumn.ColumnName].Width = 100;
            //固定列
            Columns[this._orderDataTable.WareHouseNameColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.WareHouseNameColumn.ColumnName].Header.Caption = "倉庫";
            //入力許可
            Columns[this._orderDataTable.WareHouseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.WareHouseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            #endregion
            //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<

            //得意先
            #region [得意先名]
            //[得意先名] SalesCustomerSnm
            //表示順位
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            //Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Width = 130; // DEL wangyl 2013/02/06 Redmine#34578
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Width = 60; //ADD wangyl 2013/02/06 Redmine#34578
            //固定列
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.Caption = "得意先";
            //入力許可
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            #endregion

			//発注先
			#region [発注先名]
			//[発注先名] SupplierSnm
			//表示順位
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
            Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Width = 130; // UPD 2009/11/23
			//固定列
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			//Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Header.Caption = "発注先名"; // DEL 2009/11/23
            Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Header.Caption = "発注先"; // ADD 2009/11/23
			//入力許可
            Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // UPD 2009/11/23
			//Style
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //フィルター（AllowRowFiltering）
            Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True; // ADD 2012/11/21 田建委 Redmine#33506

			// フォーマット設定
			//Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			//Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].MaxLength = 8;
			#endregion

			//品番
			#region [品番]
			//表示順位
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			//Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Width = 160; // DEL wangyl 2013/02/06 Redmine#34578
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Width = 125; // ADD wangyl 2013/02/06 Redmine#34578 
			//固定列
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.Caption = "品番";
			//入力許可
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//Style
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].MaxLength = 40;
			//CellAppearance
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
			#endregion

			//メーカー
			#region [メーカー]
			//表示順位
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Width = 60;
			//固定列
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.Caption = "ﾒｰｶｰ";
			//入力許可
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Format = codeFormat_GoodsMakerCd;
			// MaxLength設定
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].MaxLength = 4;
			//CellAppearance
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			#endregion

			//品名
			#region [品名]
			//表示順位
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Width = 170;
			//固定列
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.Caption = "品名";
			//入力許可
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//Style
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// MaxLength設定
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].MaxLength = 100;
			// CellAppearance設定
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
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
            Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Format = numFormat;
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
            // MaxLength設定
            Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].MaxLength = 1;
            //CellAppearance
            Columns[this._orderDataTable.InpBoCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

			//ヘッダー部
			//リマーク１
			#region [リマーク１]
			//表示順位
			Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Header.Caption = "リマーク１";
			//入力許可
			Columns[this._orderDataTable.UoeRemark1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			//Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Format = codeFormat;
			// MaxLength設定
			//Columns[this._orderDataTable.UoeRemark1Column.ColumnName].MaxLength = 8;
			#endregion

			//リマーク２
			#region [リマーク２]
			//表示順位
			Columns[this._orderDataTable.UoeRemark2Column.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.UoeRemark2Column.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.UoeRemark2Column.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.UoeRemark2Column.ColumnName].Header.Caption = "リマーク２";
			//入力許可
			Columns[this._orderDataTable.UoeRemark2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.UoeRemark2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			//Columns[this._orderDataTable.UoeRemark2Column.ColumnName].Format = codeFormat;
			// MaxLength設定
			//Columns[this._orderDataTable.UoeRemark2Column.ColumnName].MaxLength = 8;
			#endregion

			//納品区分
			#region [納品区分]
			//表示順位
			Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Header.Caption = "納品区分";
			//入力許可
			Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			//Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			//Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].MaxLength = 8;
			#endregion

			//Ｈ納品区分
			#region [Ｈ納品区分]
			//表示順位
			Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Header.Caption = "Ｈ納品区分";
			//入力許可
			Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			//Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			//Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].MaxLength = 8;
			#endregion

			//拠点
			#region [拠点]
			//表示順位
			Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Header.Caption = "拠点";
			//入力許可
			Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
			//Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Format = codeFormat;
			// MaxLength設定
			//Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].MaxLength = 8;
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

        #region ■グリッドクリックイベント
        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void uGrid_Details_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
                if (objCell != null)
                {
                    if (objCell.Column.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                    {
                        int uniqueID = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value);
                        this._stockInputAcs.SelectedRow(uniqueID);
                    }
                }
            }
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

			// ActiveCellが数量の場合InpAcceptAnOrderCntColumn
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

            //ActiveCellが「数量」の場合
            if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
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

			this._cannotAcceptAnOrderCnt = false;	//数量
            this._cannotBoCode = false;				//ＢＯ区分

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

            //-----------------------------------------------------------
            // 数量
            //-----------------------------------------------------------
            if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
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
						"数量の入力値がマイナスです。",
						-1,
						MessageBoxButtons.OK);

					// 発注数を元に戻す
                    this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = this._beforeAcceptAnOrderCnt;
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = this._beforeAcceptAnOrderCnt;
                    this._cannotAcceptAnOrderCnt = true;
				}
				else
				{
                    this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = columnData;
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = columnData;
                }
				# endregion
            }
            //-----------------------------------------------------------
            // ＢＯ区分
            //-----------------------------------------------------------
            else if (cell.Column.Key == this._orderDataTable.InpBoCodeColumn.ColumnName)
            {
                # region ＢＯ区分
                string boCode = (string)this._orderDataTable[rowIndex].InpBoCode;
                int uOESupplierCd = (int)this._orderDataTable[rowIndex].UOESupplierCd;

                //ＢＯ区分入力なし
                if (String.IsNullOrEmpty(boCode))
                {
                    //ＢＯ区分(画面)
                    this._orderDataTable[rowIndex].InpBoCode = (string)cell.Value;

                    //ＢＯ区分
                    this._orderDataTable[rowIndex].BoCode = (string)cell.Value;
                }
                //ＢＯ区分入力あり
                else
                {
                    if (this._stockInputInitDataAcs.UOEGuideExists(1, uOESupplierCd, boCode) == true)
                    {
                        //ＢＯ区分(画面)
                        this._orderDataTable[rowIndex].InpBoCode = (string)cell.Value;

                        //ＢＯ区分
                        this._orderDataTable[rowIndex].BoCode = (string)cell.Value;
                    }
                    //入力エラー
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
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._orderDataTable.GoodsNoColumn.ColumnName];
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
            if (e.Cell.Column.Key == this._orderDataTable.GoodsNameColumn.ColumnName)
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
			if((this.StatusBarMessageSetting == null)
            || (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
            || (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
			{
				this.StatusBarMessageSetting(this, "");
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
			//その他
			else
			{
				this.StatusBarMessageSetting(this, "");
			}

            //ヘッダー部のデータ設定
            Int32 onlineNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value);
            Int32 onlineRowNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineRowNoColumn.ColumnName].Value);
            SettingHedaerItem(onlineNo, onlineRowNo);

			// セルアクティブ時ボタン有効無効コントロール処理
			this.ActiveCellButtonEnabledControl(cell.Row.Index, cell.Column.Key);

			// 横スクロールバー位置設定
			if (cell.Column.Key == this._orderDataTable.GoodsNoColumn.ColumnName)
			{
				this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
			}

			this._cannotAcceptAnOrderCnt = false;	//数量
            this._cannotBoCode = false;				//ＢＯ区分
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

			// 横スクロールバー位置設定
			// this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
        }

        /// <summary>
        /// グリッドセル非アクティブ化前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellDeactivate ( object sender, CancelEventArgs e )
        {
            //
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
		}
        #endregion

        #region ■ボタンクリックイベント
		#region ■全選択ボタンクリックイベント
		/// <summary>
		/// 全選択ボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_RowSelect_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// フィルター除外行を取得      
			Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
				this.uGrid_Details.Rows.GetFilteredInNonGroupByRows();

			// 表示行は存在するか？
			foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
			{
				int uniqueID = (int)_row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;
				this._stockInputAcs.SelectedRow(uniqueID, true);
			}
		}
		# endregion

        #region ■全解除ボタンクリックイベント
		/// <summary>
		/// 全解除ボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_RowCancell_Click(object sender, EventArgs e)
		{
			this._orderDataTable.AcceptChanges();

			// フィルター除外行を取得      
			Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
				this.uGrid_Details.Rows.GetFilteredInNonGroupByRows();

			// 表示行は存在するか？
			foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
			{
				int uniqueID = (int)_row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;
				this._stockInputAcs.SelectedRow(uniqueID, false);
			}
		}
		# endregion

		# region ガイドボタンクリックイベント
		/// <summary>
		/// ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote : 2009/12/02 李占川 保守依頼③対応</br>
        /// <br>             既存の不具合修正</br>
        /// </remarks>
		private void uButton_Guide_Click(object sender, EventArgs e)
		{
            int status = -1;
            Control control = null;

            this.uButton_Guide.Focus(); // ADD 2009/12/02

            this._orderDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();

			if (this.uButton_Guide.Tag == null) return;

            //-----------------------------------------------------------------------------------
            // 発注先ガイド
            //-----------------------------------------------------------------------------------
    		# region 発注先ガイド
            if (this.uButton_Guide.Tag.ToString() == "tEdit_UOESupplierCd")
            {
                //インスタンス生成
                UOESupplier uOESupplier = null;

                //ガイド起動
                status = uOESupplierAcs.ExecuteGuid(_enterpriseCode, _loginSectionCode, out uOESupplier);
                if (status == 0)
                {
                    //メーカーコードの取得
                    Int32 makerCd = (Int32)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.GoodsMakerCdColumn.ColumnName].Value); ;
                    if (ChangeUOESupplier(uOESupplier, makerCd) == true)
                    {
                        //項目に展開
                        // 発注先
                        inpHedDisplay.UOESupplierCd = uOESupplier.UOESupplierCd;
                        inpHedDisplay.UOESupplierName = uOESupplier.UOESupplierName;

                        // 納品区分
                        inpHedDisplay.UOEDeliGoodsDiv = string.Empty;

                        // Ｈ納品区分
                        inpHedDisplay.FollowDeliGoodsDiv = string.Empty;

                        // 指定拠点
                        inpHedDisplay.UOEResvdSection = string.Empty;

                        ReSettingUOESupplier();

                        //フォーカス設定
                        control = this.tEdit_UOESupplierCd;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "変更先の発注先には、発注可能メーカーではありません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    // 次フォーカス
                    control = this.tEdit_UOESupplierCd;
                }
                else
                {
                    //フォーカス設定
                    control = this.tEdit_UOESupplierCd;
                }
            }
    		# endregion

            //-----------------------------------------------------------------------------------
            // 依頼者ガイド
            //-----------------------------------------------------------------------------------
            # region 依頼者ガイド
            if (this.uButton_Guide.Tag.ToString() == "tEdit_EmployeeCode")
            {
                //インスタンス生成
                EmployeeAcs employeeAcs = new EmployeeAcs();
                Employee employee;

                //ガイド起動
                status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //項目に展開
                    inpHedDisplay.EmployeeCode = employee.EmployeeCode.Trim();
                    inpHedDisplay.EmployeeName = employee.Name;
                    this.tEdit_EmployeeCode.Text = inpHedDisplay.EmployeeName;

                    // 次フォーカス
                    control = this.tEdit_UOESupplierCd;
                }
                else
                {
                    // 次フォーカス
                    control = this.tEdit_EmployeeCode;
                }
            }
    		# endregion

            //-----------------------------------------------------------------------------------
            //ＢＯ区分ガイド
            //-----------------------------------------------------------------------------------
            # region ＢＯ区分ガイド
            if (this.uButton_Guide.Tag.ToString() == this._orderDataTable.InpBoCodeColumn.ColumnName)
            {
                if (rowIndex == -1) return;

                UOEGuideName uoeGuideName = null;
                UOEGuideName inUOEGuideName = new UOEGuideName();
                inUOEGuideName.UOEGuideDivCd = 1;
                inUOEGuideName.EnterpriseCode = _enterpriseCode;
                inUOEGuideName.SectionCode = _loginSectionCode;
                inUOEGuideName.UOESupplierCd = (int)(this.uGrid_Details.Rows[rowIndex].Cells[this._orderDataTable.UOESupplierCdColumn.ColumnName].Value);

                status = this._stockInputInitDataAcs.uOEGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uoeGuideName != null))
                {
                    //ＢＯ区分(画面)
                    this._orderDataTable[rowIndex].InpBoCode = uoeGuideName.UOEGuideCode;

                    //ＢＯ区分
                    this._orderDataTable[rowIndex].BoCode = uoeGuideName.UOEGuideCode;

                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._orderDataTable.InpBoCodeColumn.ColumnName];
                }

                control = this.uGrid_Details;
            }
    		# endregion

            //-----------------------------------------------------------------------------------
            // フォーカス移動
            //-----------------------------------------------------------------------------------
            if (control != null)
            {
                control.Focus();
            }
		}
		# endregion

        #region ■ボタンEnabled変更後イベント
        /// <summary>
        /// 全選択ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Select_EnabledChanged(object sender, EventArgs e)
        {
            this._rowSelectButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }
        /// <summary>
        /// 全解除ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancell_EnabledChanged(object sender, EventArgs e)
        {
            this._rowCancellButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }
        # endregion

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
                //全選択
                case "ButtonTool_RowSelect":
                    {
                        this.uButton_RowSelect_Click(this.uButton_Select, new EventArgs());
                        break;
                    }
                //全解除
                case "ButtonTool_RowCancell":
                    {
                        this.uButton_RowCancell_Click(this.uButton_Cancell, new EventArgs());
                        break;
                    }
                //ガイド
                case "uButton_Guide":
                    {
                        this.uButton_Guide_Click(this.uButton_Guide, new EventArgs());
                        break;
                    }
            }
        }
        #endregion

        #endregion

        #endregion

    }
}
