//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ復旧ＵＩ処理 明細コントロールクラス
// プログラム概要   : ＵＯＥ復旧処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 : 【要件No.4】
//                                   処理区分の入力制御を行う
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 楊明俊
// 修 正 日  2010/03/08  修正内容 : PM1006 処理区分の入力制御の対応
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
    /// ＵＯＥ復旧処理 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＵＯＥ復旧処理の明細入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/12/01</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/01/19 照田 貴志　不具合対応[9932]</br>
    /// <br>             2009/01/26 照田 貴志　不具合対応[10464]</br>
    /// <br>UpdateNote : 2010/03/08 楊明俊　PM1006</br>
    /// <br>             処理区分の入力制御の対応</br>
    /// </remarks>
	public partial class PMUOE01401UB : UserControl 
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constroctors
		/// <summary>
		/// 入力明細入力コントロールクラス デフォルトコンストラクタ
		/// </summary>
		public PMUOE01401UB()
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

		//グリッド更新前の値
        private string _beforeStringValue = string.Empty;
        private double _brforeDoubleValue = 0;
        private int _beforeIntValue = 0;

        //エラー発生(True：エラーあり、False：エラーなし)
        private bool _gridInputValueIsError = false;

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
		private int _businessCode = ctTerminalDiv_Restore;

        //ヘッダー部画面入力クラス
        private InpHedDisplay _inpHedDisplay = null;

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//入力メッセージ
        private const string MESSAGE_ProcessDiv = "処理区分を選択してください。";
        private const string MESSAGE_AnswerPartsNo = "回答品番を入力してください。";
        private const string MESSAGE_AcceptAnOrderCnt = "数量を入力してください。";
        private const string MESSAGE_AnswerListPrice = "定価を入力してください。";
        private const string MESSAGE_AnswerSalesUnitCost = "単価を入力してください。";
        private const string MESSAGE_UOESectionSlipNo = "UOE拠点伝票番号を入力してください。";
        private const string MESSAGE_UOESectOutGoodsCnt = "UOE拠点出庫数を入力してください。";
        private const string MESSAGE_BOSlipNo1 = "BO伝票番号1を入力してください。";
        private const string MESSAGE_BOShipmentCnt1 = "BO出庫数1を入力してください。";
        private const string MESSAGE_BOSlipNo2 = "BO伝票番号2を入力してください。";
        private const string MESSAGE_BOShipmentCnt2 = "BO出庫数2を入力してください。";
        private const string MESSAGE_BOSlipNo3 = "BO伝票番号3を入力してください。";
        private const string MESSAGE_BOShipmentCnt3 = "BO出庫数3を入力してください。";
        private const string MESSAGE_MakerFollowCnt = "メーカーフォロー数を入力してください。";
        private const string MESSAGE_BOManagementNo = "BO管理番号を入力してください。";
        private const string MESSAGE_EOAlwcCount = "EO引当数を入力してください。";

		//業務区分
        private const Int32 ctTerminalDiv_Restore = 1;	//復旧
        private const Int32 ctTerminalDiv_Cancel = 2;//取消処理
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
            if ((cell.Column.Key == this._orderDataTable.AnswerPartsNoColumn.ColumnName)            //回答品番
            //||  (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)      //数量                //DEL 2009/01/19 不具合対応[9932]
            ||  (cell.Column.Key == this._orderDataTable.AnswerListPriceColumn.ColumnName)          //定価
            ||  (cell.Column.Key == this._orderDataTable.AnswerSalesUnitCostColumn.ColumnName)      //単価
            ||  (cell.Column.Key == this._orderDataTable.UOESectionSlipNoColumn.ColumnName)         //UOE拠点伝票番号
            ||  (cell.Column.Key == this._orderDataTable.UOESectOutGoodsCntColumn.ColumnName)       //UOE拠点出庫数
            ||  (cell.Column.Key == this._orderDataTable.BOSlipNo1Column.ColumnName)                //BO伝票番号1
            ||  (cell.Column.Key == this._orderDataTable.BOShipmentCnt1Column.ColumnName)           //BO出庫数1
            ||  (cell.Column.Key == this._orderDataTable.BOSlipNo2Column.ColumnName)                //BO伝票番号2
            ||  (cell.Column.Key == this._orderDataTable.BOShipmentCnt2Column.ColumnName)           //BO出庫数2
            ||  (cell.Column.Key == this._orderDataTable.BOSlipNo3Column.ColumnName)                //BO伝票番号3
            ||  (cell.Column.Key == this._orderDataTable.BOShipmentCnt3Column.ColumnName)           //BO出庫数3
            ||  (cell.Column.Key == this._orderDataTable.MakerFollowCntColumn.ColumnName)           //メーカーフォロー数
            ||  (cell.Column.Key == this._orderDataTable.BOManagementNoColumn.ColumnName)           //BO管理番号
            ||  (cell.Column.Key == this._orderDataTable.EOAlwcCountColumn.ColumnName))             //EO引当数
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                if (this._gridInputValueIsError)
                {
                    this._gridInputValueIsError = false;
                }
                else
                {
                    canMove = this.MoveNextAllowEditCell(false);
                }
            }         
            // 次入力可能セル移動処理
            else
            {
                canMove = this.MoveNextAllowEditCell(false);
            }
            
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
            // Mode 1:発注 2:取消処理

			//[番号]
			# region [番号]
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoDisplayColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OrderNoDisplayColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[選択]
			# region [選択]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpSelectColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpSelectColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[端末]
            # region [端末]
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[端末2]
            # region [端末2]
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNo2Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CashRegisterNo2Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, true);
            # endregion

            //[呼出番号]
            # region [呼出番号]
            this._productStockRowVisibleControl.Add(this._orderDataTable.OnlineNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.OnlineNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[エラー内容]
            # region [エラー内容]
            this._productStockRowVisibleControl.Add(this._orderDataTable.DataSendErrMsgColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.DataSendErrMsgColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[入力日]
			# region [入力日]
			//[発注日] OrderDataCreateDate
            this._productStockRowVisibleControl.Add(this._orderDataTable.InputDayColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InputDayColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[得意先]
			# region [得意先]
            this._productStockRowVisibleControl.Add(this._orderDataTable.CustomerSnmColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.CustomerSnmColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[発注先名]
			# region [発注先名]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOESupplierNameColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOESupplierNameColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, true);
            # endregion

			//[品番]
			# region [品番]
			//[商品コード] GoodsNo
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[ﾒｰｶｰ]
			# region [ﾒｰｶｰ]
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[品名]
			# region [品名]
			//[商品名] GoodsName
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNameColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.GoodsNameColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[処理区分]
            # region [処理区分]
            //[処理区分] ProcessDiv
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpProcessDivColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpProcessDivColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[回答品番]
            # region [回答品番]
            //[回答品番] GoodsNo
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAnswerPartsNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAnswerPartsNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[数量]
			# region [数量]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[定価]
            # region [定価]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAnswerListPriceColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAnswerListPriceColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[単価]
            # region [単価]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[伝票番号1]
            # region [伝票番号1]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[出荷数1]
            # region [出荷数1]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[伝票番号2]
            # region [伝票番号2]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOSlipNo1Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOSlipNo1Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[出荷数2]
            # region [出荷数2]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOShipmentCnt1Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOShipmentCnt1Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[伝票番号3]
            # region [伝票番号3]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOSlipNo2Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOSlipNo2Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[出荷数3]
            # region [出荷数3]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOShipmentCnt2Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOShipmentCnt2Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[伝票番号4]
            # region [伝票番号4]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOSlipNo3Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOSlipNo3Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[出荷数4]
            # region [出荷数4]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOShipmentCnt3Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOShipmentCnt3Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[メーカーフォロー]
            # region [メーカーフォロー]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerFollowCntColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpMakerFollowCntColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[EO]
            # region [EO]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOManagementNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpBOManagementNoColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

            //[EO出荷数]
            # region [EO出荷数]
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpEOAlwcCountColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, false);
            this._productStockRowVisibleControl.Add(this._orderDataTable.InpEOAlwcCountColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, false);
            # endregion

			//[リマーク１]
			# region [リマーク１]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark1Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark1Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, true);
            # endregion

			//[リマーク２]
			# region [リマーク２]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark2Column.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UoeRemark2Column.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, true);
            # endregion

			//[拠点]
			# region [拠点]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEResvdSectionColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEResvdSectionColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, true);
            # endregion

			//[納品区分]
			# region [納品区分]
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, true);
            # endregion

			//[Ｈ納品区分]
			# region [Ｈ納品区分]
            this._productStockRowVisibleControl.Add(this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName, StatusType.Default, ctTerminalDiv_Restore, true);
            this._productStockRowVisibleControl.Add(this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName, StatusType.Default, ctTerminalDiv_Cancel, true);
            # endregion
		}
		# endregion

        # region 明細グリッド設定処理
        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        /// <param name="businessCode">業務区分</param>
        internal void SettingGrid(int businessCode)
		{
            BusinessCode = businessCode;
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

				// 描画が必要な明細件数を取得する。
				int cnt = this._orderDataTable.Count;

				// 各行ごとの設定
                int onlineNoBf = -1;
                string processDivBf = "";
				for (int i = 0; i < cnt; i++)
				{
                    if (onlineNoBf == this._orderDataTable[i].OnlineNo)
                    {
                        //前行とオンライン番号が同じ
                        this.SettingGridRow(i, processDivBf, false);
                    }
                    else
                    {
                        //前行とオンライン番号が異なる
                        this.SettingGridRow(i, this._orderDataTable[i].InpProcessDiv, true);
                        processDivBf = this._orderDataTable[i].InpProcessDiv;
                    }
                    onlineNoBf = this._orderDataTable[i].OnlineNo;
                }

				// 表示用行番号調整処理
				this._stockInputAcs.AdjustRowNo();

                // セルアクティブ時ボタン有効無効コントロール処理
                this.ActiveCellButtonEnabledControl(0, null);

                //View設定
                string viewString = "";
                
                // 行フィルタがバンドに基づいている場合、バンドの列フィルタを外す。
                Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;
                columnFilters.ClearAllFilters();
                viewString = "";

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
		# endregion

        # region 明細グリッド・行単位でのセル設定
        /// <summary>
		/// 明細グリッド・行単位でのセル設定
		/// </summary>
		/// <param name="rowIndex">対象行インデックス</param>
        /// <param name="processDiv">処理区分</param>
        /// <remarks>
        /// <br>UpdateNote  : 2010/03/08 楊明俊 処理区分の入力制御の対応</br>
        /// </remarks>
		private void SettingGridRow(int rowIndex, string processDiv, bool processDivEnable)
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

			// 行ステータスを取得
			//int rowStatus = 0;

            string commAssemblyId = string.Empty; // ADD 2009/12/29

			// 指定行の全ての列に対して設定を行う。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// セル情報を取得
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
				if (cell == null) continue;

    			cell.Row.Hidden = false;

                // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
                if (col.Key == this._orderDataTable.CommAssemblyIdColumn.ColumnName)
                {
                    commAssemblyId = cell.Value.ToString();
                }
                // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
				//業務区分
                switch (BusinessCode)
                {
                    //-----------------------------------------------------------
                    // 発注
                    //-----------------------------------------------------------
                    case ctTerminalDiv_Restore:
                        {
                            # region 業務区分＝発注
                            //選択
                            if (col.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                            }
                            //処理区分
                            else if (col.Key == this._orderDataTable.InpProcessDivColumn.ColumnName)
                            {
                                //前のデータとオンライン番号が同一
                                if (processDivEnable == false)
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    cell.Appearance.BackColor = DISABLE_COLOR;
                                    continue;
                                }
                                else if (string.IsNullOrEmpty(processDiv))
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                }
                                else
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                }
                                // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
                                // ---UPD 2010/03/08 ---------------------------------------->>>>>                               
                                //if (commAssemblyId == "0103")
                                if (StockInputAcs.IsWritingAnswerOnly(commAssemblyId))
                                // ---UPD 2010/03/08 ----------------------------------------<<<<<
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    //リスト設定
                                    Infragistics.Win.ValueList processList = new Infragistics.Win.ValueList();

                                    processList.ValueListItems.Add("2", "回答埋込");
                                    cell.ValueList = processList;
                                    if (cell.Value != null)
                                    {
                                        cell.Value = 2;
                                    }
                                }
                                // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
 
                            }
                            //回答品番、数量、定価、単価、伝票番号1～4、出荷数1～4、メーカーフォロー、EO、EO出荷数
                            else if ((col.Key == this._orderDataTable.InpAnswerPartsNoColumn.ColumnName)
                                  //|| (col.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)           //DEL 2009/01/19 不具合対応[9932]
                                  || (col.Key == this._orderDataTable.InpAnswerListPriceColumn.ColumnName)
                                  || (col.Key == this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName)
                                  || (col.Key == this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName)
                                  || (col.Key == this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName)
                                  || (col.Key == this._orderDataTable.InpBOSlipNo1Column.ColumnName)
                                  || (col.Key == this._orderDataTable.InpBOShipmentCnt1Column.ColumnName)
                                  || (col.Key == this._orderDataTable.InpBOSlipNo2Column.ColumnName)
                                  || (col.Key == this._orderDataTable.InpBOShipmentCnt2Column.ColumnName)
                                  || (col.Key == this._orderDataTable.InpBOSlipNo3Column.ColumnName)
                                  || (col.Key == this._orderDataTable.InpBOShipmentCnt3Column.ColumnName)
                                  || (col.Key == this._orderDataTable.InpMakerFollowCntColumn.ColumnName)
                                  || (col.Key == this._orderDataTable.InpBOManagementNoColumn.ColumnName)
                                  || (col.Key == this._orderDataTable.InpEOAlwcCountColumn.ColumnName))
                            {
                                // 処理区分：発注
                                if (processDiv == "1")
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                }
                                // 処理区分：回答埋込
                                else if (processDiv == "2")
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                }
                                else
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                }
                            }
                            //他項目
                            else
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                            }
                            break;
                            # endregion
                        }
                    //-----------------------------------------------------------
                    // 取消処理
                    //-----------------------------------------------------------
                    case ctTerminalDiv_Cancel:
                        # region 業務区分＝取消処理
       					//選択
                        if (col.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        }
                        //処理区分
                        else if (col.Key == this._orderDataTable.InpProcessDivColumn.ColumnName)
                        {
                            //前のデータとオンライン番号が同一
                            if (processDivEnable == false)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                cell.Appearance.BackColor = DISABLE_COLOR;
                                continue;
                            }
                            else
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                            }
                            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
                            // ---UPD 2010/03/08 ---------------------------------------->>>>>
                            //if (commAssemblyId == "0103")
                            if (StockInputAcs.IsWritingAnswerOnly(commAssemblyId))
                            // ---UPD 2010/03/08 ----------------------------------------<<<<<
                            {
                                //リスト設定
                                Infragistics.Win.ValueList processList = new Infragistics.Win.ValueList();

                                processList.ValueListItems.Add("2", "回答埋込");
                                cell.ValueList = processList;
                                if (cell.Value != null)
                                {
                                    cell.Value = 2;
                                }
                            }
                            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
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
					cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
					cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

                    //編集不可
					if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
						(cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
					{
						cell.Appearance.BackColor = READONLY_CELL_COLOR;
					}
                    //編集可
					else
					{
						cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
					}
				}
                # endregion
			}

            UltraGridRow row = this.uGrid_Details.Rows[rowIndex];
            if (processDiv == "1")
            {
                // 処理区分：発注　時、初期値に戻す
                row.Cells[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].Value = row.Cells[this._orderDataTable.AnswerPartsNoColumn.ColumnName].Value;
                row.Cells[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].Value = row.Cells[this._orderDataTable.AnswerListPriceColumn.ColumnName].Value;
                row.Cells[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].Value = row.Cells[this._orderDataTable.AnswerSalesUnitCostColumn.ColumnName].Value;
                row.Cells[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].Value = row.Cells[this._orderDataTable.UOESectionSlipNoColumn.ColumnName].Value;
                row.Cells[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].Value = row.Cells[this._orderDataTable.UOESectOutGoodsCntColumn.ColumnName].Value;
                row.Cells[this._orderDataTable.InpBOSlipNo1Column.ColumnName].Value = row.Cells[this._orderDataTable.BOSlipNo1Column.ColumnName].Value;
                row.Cells[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].Value = row.Cells[this._orderDataTable.BOShipmentCnt1Column.ColumnName].Value;
                row.Cells[this._orderDataTable.InpBOSlipNo2Column.ColumnName].Value = row.Cells[this._orderDataTable.BOSlipNo2Column.ColumnName].Value;
                row.Cells[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].Value = row.Cells[this._orderDataTable.BOShipmentCnt2Column.ColumnName].Value;
                row.Cells[this._orderDataTable.InpBOSlipNo3Column.ColumnName].Value = row.Cells[this._orderDataTable.BOSlipNo3Column.ColumnName].Value;
                row.Cells[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].Value = row.Cells[this._orderDataTable.BOShipmentCnt3Column.ColumnName].Value;
                row.Cells[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].Value = row.Cells[this._orderDataTable.MakerFollowCntColumn.ColumnName].Value;
                row.Cells[this._orderDataTable.InpBOManagementNoColumn.ColumnName].Value = row.Cells[this._orderDataTable.BOManagementNoColumn.ColumnName].Value;
                row.Cells[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].Value = row.Cells[this._orderDataTable.EOAlwcCountColumn.ColumnName].Value;
            }
            if (processDiv == "2")
            {
                // 処理区分：回答埋込　時、品番を初期値とする
                row.Cells[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].Value = row.Cells[this._orderDataTable.GoodsNoColumn.ColumnName].Value;
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
			this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

			//Appearance.Image
			this.uButton_Select.Appearance.Image = (int)Size16_Index.SELECT;
			this.uButton_Cancell.Appearance.Image = (int)Size16_Index.DELETE;

			//選択許可設定
			this.uButton_Select.Enabled = false;
			this.uButton_Cancell.Enabled = false;

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
            #region Enterキー設定
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion

            //----- Shift + Enterキー
            #region Shift + Enterキー設定
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.AltCtrl,
				Infragistics.Win.SpecialKeys.Shift,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion

            //----- ↑キー
            #region ↑キー設定１
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Up,
				Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            #region ↑キー設定２
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Up,
				Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            #region ↓キー設定１
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Down,
				Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion

            //----- ↓キー
            #region ↓キー設定２
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Down,
				Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion

            //----- 前頁キー
            #region PageUpキー設定
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Prior,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion

            //----- 次頁キー
            #region PageDownキー設定
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Next,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
            #endregion
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
		}
		# endregion
		# endregion

        // ===================================================================================== //
        // ヘッダー部処理
        // ===================================================================================== //
        # region ヘッダー部処理
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
            // 発注先
            uLabel_UOESupplierName.Text = _inpHedDisplay.UOESupplierName;

            // リマーク1
            uLabel_UOERemark1.Text = _inpHedDisplay.UoeRemark1;

            // リマーク2
            uLabel_UOERemark2.Text = _inpHedDisplay.UoeRemark2;

            // 納品区分
            uLabel_UOEDeliGoodsDiv.Text = _inpHedDisplay.DeliveredGoodsDivNm;

            // Ｈ納品区分
            uLabel_FollowDeliGoodsDiv.Text = _inpHedDisplay.FollowDeliGoodsDivNm;

            // 指定拠点
            uLabel_UOEResvdSection.Text = _inpHedDisplay.UOEResvdSectionNm;

            // 依頼者
            uLabel_EmployeeCode.Text = _inpHedDisplay.EmployeeName;

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
            uLabel_UOEDeliGoodsDiv.Text = string.Empty;     // 納品区分
            uLabel_FollowDeliGoodsDiv.Text = string.Empty;	// Ｈ納品区分
            uLabel_UOEResvdSection.Text = string.Empty;     // 指定拠点
            uLabel_UOERemark1.Text = string.Empty;          // リマーク１
            uLabel_UOERemark2.Text = string.Empty;          // リマーク２
            uLabel_EmployeeCode.Text = string.Empty;        // 依頼者
            uLabel_UOESupplierName.Text = string.Empty;     // 発注先
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
                inpHedDisplay.OnlineNo = (int)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.OnlineNoColumn.ColumnName].Value);
                inpHedDisplay.OnlineRowNo = (int)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.OnlineRowNoColumn.ColumnName].Value);
                inpHedDisplay.UOESupplierCd = (int)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.UOESupplierCdColumn.ColumnName].Value);
                inpHedDisplay.UOESupplierName = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.UOESupplierNameColumn.ColumnName].Value);
                inpHedDisplay.UoeRemark1 = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.UoeRemark1Column.ColumnName].Value);
                inpHedDisplay.UoeRemark2 = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.UoeRemark2Column.ColumnName].Value);
                inpHedDisplay.UOEDeliGoodsDiv = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Value);
                inpHedDisplay.DeliveredGoodsDivNm = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.DeliveredGoodsDivNmColumn.ColumnName].Value);
                inpHedDisplay.FollowDeliGoodsDiv = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Value);
                inpHedDisplay.FollowDeliGoodsDivNm = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName].Value);
                inpHedDisplay.UOEResvdSection = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Value);
                inpHedDisplay.UOEResvdSectionNm = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.UOEResvdSectionNmColumn.ColumnName].Value);
                inpHedDisplay.EmployeeCode = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.EmployeeCodeColumn.ColumnName].Value);
                inpHedDisplay.EmployeeName = (string)(this.uGrid_Details.ActiveRow.Cells[this._orderDataTable.EmployeeNameColumn.ColumnName].Value);
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

            this.uLabel_UOEDeliGoodsDiv.Text = string.Empty;		//納品区分
            this.uLabel_FollowDeliGoodsDiv.Text = string.Empty;	    //フォロー納品区分
            this.uLabel_UOEResvdSection.Text = string.Empty;		//UOE指定拠点
            this.uLabel_EmployeeCode.Text =string.Empty ;			//依頼者コード
            this.uLabel_UOERemark1.Text = string.Empty;				//ＵＯＥリマーク１
            this.uLabel_UOERemark2.Text = string.Empty;				//ＵＯＥリマーク２
            this.uLabel_UOESupplierName.Text = string.Empty;        // 発注先
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
        # endregion

        // ===================================================================================== //
        // 明細部処理
        // ===================================================================================== //
        #region 明細部処理
        #region ■明細部のフォーカス設定(処理区分固定)
        public void SetFocusProcessDiv(int orderNo, string columnName)
        {
            // 同一オンライン番号を見つける(現在行は含まない)
            DataView orderDataView = new DataView(this._orderDataTable);
            orderDataView.RowFilter = String.Format("{0} = {1}"
                                                    , this._orderDataTable.OrderNoColumn.ColumnName
                                                    , orderNo);
            orderDataView.Sort = String.Format("{0}", this._orderDataTable.OrderNoColumn.ColumnName);

            // 現在行以外の同一オンライン番号に対して使用可不可を設定
            if (orderDataView.Count > 0)
            {
                StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[0].Row);

                this.uGrid_Details.Rows[dataRow.OrderNo - 1].Cells[columnName].Activated = true;
            }
        }
        #endregion
        #endregion

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
        #endregion

		#region ■グリッド列初期設定処理
		/// <summary>
        /// グリッド列初期設定処理
        /// </summary>
		private void InitialSettingGridCol(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
			//表示順番
			int currentPosition = 0;

			//フォーマット設定
			string codeFormat = "#;";
            string codeFormat_GoodsMakerCd = "0000;";
            string codeFormat_CashRegisterNo = "000;";
            string codeFormat_OnlineNo = "000000000;";
            string numFormat = "#,###;";
			string dateFormat = "yyyy/MM/dd";

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
			#region [No.]設定
			//表示順位
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
            Columns[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Width = 34;
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
			#region [選択]設定
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

            //端末
            #region [端末]設定
            //表示順位
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Width = 44;
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
            //CellAppearance
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //送信端末番号
            #region [送信端末番号]設定(非表示)
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
            //CellAppearance
            Columns[this._orderDataTable.CashRegisterNo2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //呼出番号
            #region [呼出番号]設定
            //表示順位
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Width = 80;
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
            //CellAppearance
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //エラー内容
            #region [エラー内容]設定
            //表示順位
            Columns[this._orderDataTable.DataSendErrMsgColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.DataSendErrMsgColumn.ColumnName].Width = 90;
            //固定列
            Columns[this._orderDataTable.DataSendErrMsgColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.DataSendErrMsgColumn.ColumnName].Header.Caption = "エラー内容";
            //入力許可
            Columns[this._orderDataTable.DataSendErrMsgColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.DataSendErrMsgColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //CellAppearance
            Columns[this._orderDataTable.DataSendErrMsgColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            #endregion

			//入力日
			#region [入力日]設定
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
			Columns[this._orderDataTable.InputDayColumn.ColumnName].Format = dateFormat;
			//CellAppearance
			Columns[this._orderDataTable.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			#endregion
            
			//得意先
			#region [得意先]設定
			//表示順位
			Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Width = 160;
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
			#region [発注先]設定
			//表示順位
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Width = 100;
			//固定列
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Header.Caption = "発注先名";
			//入力許可
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			//Style
			Columns[this._orderDataTable.UOESupplierNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			#endregion

			//品番
			#region [品番]設定
			//表示順位
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Width = 160;
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
			//CellAppearance
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
			#endregion

			//メーカー
			#region [メーカー]設定
			//表示順位
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Width = 44;
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
			//CellAppearance
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			#endregion

			//品名
			#region [品名]設定
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

			// CellAppearance設定
			Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			#endregion

            //処理区分
            #region [処理区分]設定
            //表示順位
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].Width = 90;
            //固定列
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].Header.Caption = "処理区分";
            //入力許可
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //入力スタイル設定
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //リスト設定
            Infragistics.Win.ValueList processList = new Infragistics.Win.ValueList();
            processList.ValueListItems.Add("1", "発注");
            processList.ValueListItems.Add("2", "回答埋込");
            Columns[this._orderDataTable.InpProcessDivColumn.ColumnName].ValueList = processList;

           #endregion

            //回答品番
            #region [回答品番]設定
            //表示順位
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].Width = 210;
            //固定列
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].Header.Caption = "回答品番";
            //入力許可
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength設定
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].MaxLength = 24;
            //CellAppearance
            Columns[this._orderDataTable.InpAnswerPartsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            #endregion

			//数量
			#region [数量]設定
			//表示順位
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Header.VisiblePosition = currentPosition++;
			//表示幅
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Width = 60;
			//固定列
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Header.Fixed = false;
			//タイトル名称
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Header.Caption = "数量";
			//入力許可
			//Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;       //DEL 2009/01/19 不具合対応[9932]
            Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;            //ADD 2009/01/19
            //Style
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			// フォーマット設定
            Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].Format = numFormat;
			// MaxLength設定
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].MaxLength = 5;
			//CellAppearance
			Columns[this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			#endregion

            //定価
            #region [定価]設定
            //表示順位
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].Width = 80;
            //固定列
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].Header.Caption = "定価";
            //入力許可
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].MaxLength = 7;
            //CellAppearance
            Columns[this._orderDataTable.InpAnswerListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //単価
            #region [単価]設定
            //表示順位
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].Width = 80;
            //固定列
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].Header.Caption = "単価";
            //入力許可
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].MaxLength = 7;
            //CellAppearance
            Columns[this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //UOE拠点伝票番号
            #region [UOE拠点伝票番号]設定
            //表示順位
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].Width = 124;
            //固定列
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].Header.Fixed = false;
            //タイトル名称(可変)
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].Header.Caption = "UOE拠点伝票番号";
            //入力許可
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength設定
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].MaxLength = 7;
            //CellAppearance
            Columns[this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //UOE拠点出庫数
            #region [UOE拠点出庫数]設定
            //表示順位
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].Width = 110;
            //固定列
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].Header.Fixed = false;
            //タイトル名称(可変)
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].Header.Caption = "UOE拠点出庫数";
            //入力許可
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].MaxLength = 5;
            //CellAppearance
            Columns[this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO伝票番号1
            #region [BO伝票番号1]設定
            //表示順位
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].Width = 94;
            //固定列
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].Header.Caption = "BO伝票番号1";
            //入力許可
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength設定
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].MaxLength = 7;
            //CellAppearance
            Columns[this._orderDataTable.InpBOSlipNo1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO出庫数1
            #region [BO出庫数1]設定
            //表示順位
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].Width = 80;
            //固定列
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].Header.Caption = "BO出庫数1";
            //入力許可
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].MaxLength = 5;
            //CellAppearance
            Columns[this._orderDataTable.InpBOShipmentCnt1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO伝票番号2
            #region [BO伝票番号2]設定
            //表示順位
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].Width = 94;
            //固定列
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].Header.Caption = "BO伝票番号2";
            //入力許可
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength設定
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].MaxLength = 7;
            //CellAppearance
            Columns[this._orderDataTable.InpBOSlipNo2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO出庫数2
            #region [BO出庫数2]設定
            //表示順位
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].Width = 80;
            //固定列
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].Header.Caption = "BO出庫数2";
            //入力許可
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].MaxLength = 5;
            //CellAppearance
            Columns[this._orderDataTable.InpBOShipmentCnt2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO伝票番号3
            #region [BO伝票番号3]設定
            //表示順位
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].Width = 94;
            //固定列
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].Header.Caption = "BO伝票番号3";
            //入力許可
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength設定
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].MaxLength = 7;
            //CellAppearance
            Columns[this._orderDataTable.InpBOSlipNo3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO出庫数3
            #region [BO出庫数3]設定
            //表示順位
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].Width = 80;
            //固定列
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].Header.Caption = "BO出庫数3";
            //入力許可
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].MaxLength = 5;
            //CellAppearance
            Columns[this._orderDataTable.InpBOShipmentCnt3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //メーカーフォロー数
            #region [メーカーフォロー数]設定
            //表示順位
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].Width = 100;
            //固定列
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].Header.Caption = "ﾒｰｶｰﾌｫﾛｰ数";
            //入力許可
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].MaxLength = 5;
            //CellAppearance
            Columns[this._orderDataTable.InpMakerFollowCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO管理番号
            #region [BO管理番号]設定
            //表示順位
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].Width = 88;
            //固定列
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].Header.Caption = "BO管理番号";
            //入力許可
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength設定
            //Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].MaxLength = 7;       //DEL 2009/01/26 不具合対応[10464]
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].MaxLength = 6;         //ADD 2009/01/26 不具合対応[10464]
            //CellAppearance
            Columns[this._orderDataTable.InpBOManagementNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //EO引当数
            #region [EO引当数]設定
            //表示順位
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].Width = 74;
            //固定列
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].Header.Caption = "EO引当数";
            //入力許可
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].MaxLength = 5;
            //CellAppearance
            Columns[this._orderDataTable.InpEOAlwcCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

			//ヘッダー部
			//リマーク１
			#region [リマーク１]設定
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
			#endregion

			//リマーク２
			#region [リマーク２]設定
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
			#endregion

			//納品区分
			#region [納品区分]設定
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
			#endregion

			//Ｈ納品区分
			#region [Ｈ納品区分]設定
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
			#endregion

			//拠点
			#region [拠点]設定
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
			#endregion
        }
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
                        //Shift + ↓キー
                        case Keys.Down:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        //Shift + ↑キー
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
                        //Homeキー
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        //Endキー
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                    }
                    //ドロップダウンリスト以外
                    if ((this.uGrid_Details.ActiveCell != null) && (!this.uGrid_Details.ActiveCell.DroppedDown))
                    {
                        //一番上の行
                        if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                        {
                            if (e.KeyCode == Keys.Up)
                            {
                                //PMUOE01401UAで記述されている内容を実行
                                if (this.GridKeyDownTopRow != null)
                                {
                                    this.GridKeyDownTopRow(this, new EventArgs());
                                    e.Handled = true;
                                }
                            }
                        }
                        //一番下の行
                        else if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                        {
                            if (e.KeyCode == Keys.Down)
                            {
                                //PMUOE01401UAで記述されている内容を実行
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
            //アクティブセルが無い場合
            else if (this.uGrid_Details.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                //一番上の行
                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        //PMUOE01401UAで記述されている内容を実行
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
                //一番下の行
                else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        //PMUOE01401UAで記述されている内容を実行
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
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            if (cell.IsInEditMode == false)
            {
                return;
            }

            // 数値チェック
            //if ((cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)      //数量            //DEL 2009/01/19 不具合対応[9932]
            //|| (cell.Column.Key == this._orderDataTable.InpAnswerListPriceColumn.ColumnName)        //定価            //DEL 2009/01/19 不具合対応[9932]
            if ((cell.Column.Key == this._orderDataTable.InpAnswerListPriceColumn.ColumnName)        //定価             //ADD 2009/01/19 不具合対応[9932]
            || (cell.Column.Key == this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName)    //単価
            || (cell.Column.Key == this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName)     //UOE拠点出庫数
            || (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt1Column.ColumnName)         //BO出庫数1
            || (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt2Column.ColumnName)         //BO出庫数2
            || (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt3Column.ColumnName)         //BO出庫数3
            || (cell.Column.Key == this._orderDataTable.InpMakerFollowCntColumn.ColumnName)         //メーカーフォロー数
            || (cell.Column.Key == this._orderDataTable.InpEOAlwcCountColumn.ColumnName))           //EO引当数
            {
                if (!this.KeyPressNumCheck(cell.Column.MaxLength, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
		}
        #endregion

        #region ■グリッド内イベント（セル内容変更関連）
        /// <summary>
        /// グリッドセルチェンジイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            //処理区分
            if (e.Cell.Column.Key == this._orderDataTable.InpProcessDivColumn.ColumnName)
            {
                //項目の使用可不可設定
                this.SettingGridRow(e.Cell.Row.Index, e.Cell.EditorResolved.Value.ToString(), true);

                // 同一オンライン番号を見つける(現在行は含まない)
                DataView orderDataView = new DataView(this._orderDataTable);
                int onlineNo = (int)e.Cell.Row.Cells[this._orderDataTable.OnlineNoColumn.ColumnName].Value;
                orderDataView.RowFilter = String.Format("({0} = {1}) AND ({2} <> {3})"
                                                        , this._orderDataTable.OnlineNoColumn.ColumnName
                                                        , onlineNo
                                                        , this._orderDataTable.OrderNoDisplayColumn.ColumnName
                                                        , e.Cell.Row.Cells[this._orderDataTable.OrderNoDisplayColumn.ColumnName].Value);

                // 現在行以外の同一オンライン番号に対して使用可不可を設定
                for (int i = 0; i <= orderDataView.Count - 1; i++)
                {
                    StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[i].Row);

                    this.SettingGridRow(dataRow.OrderNoDisplay - 1, e.Cell.EditorResolved.Value.ToString(), false);
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

            // ActiveCellがDouble型の場合
            //if ((cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)          //数量        //DEL 2009/01/19 不具合対応[9932]
            //|| (cell.Column.Key == this._orderDataTable.InpAnswerListPriceColumn.ColumnName)            //定価        //DEL 2009/01/19 不具合対応[9932]
            if ((cell.Column.Key == this._orderDataTable.InpAnswerListPriceColumn.ColumnName)            //定価         //ADD 2009/01/19 不具合対応[9932]
            || (cell.Column.Key == this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName))       //単価
            {
                if ((e.Cell.Value != null) && (e.Cell.Value != DBNull.Value) && (e.Cell.Value.ToString() != ""))
                {
                    _brforeDoubleValue = (double)e.Cell.Value;
                    if (_brforeDoubleValue < 0)
                    {
                        _brforeDoubleValue = _brforeDoubleValue * -1;
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    _brforeDoubleValue = 0;
                }
            }
            // ActivrCellがInt型の場合
            else if ((cell.Column.Key == this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName)   //UOE拠点出庫数
                || (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt1Column.ColumnName)         //BO出庫数1
                || (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt2Column.ColumnName)         //BO出庫数2
                || (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt3Column.ColumnName)         //BO出庫数3
                || (cell.Column.Key == this._orderDataTable.InpMakerFollowCntColumn.ColumnName)         //メーカーフォロー数
                || (cell.Column.Key == this._orderDataTable.InpEOAlwcCountColumn.ColumnName))           //EO引当数
            {
                if ((e.Cell.Value != null) && (e.Cell.Value != DBNull.Value) && (e.Cell.Value.ToString() != ""))
                {
                    _beforeIntValue = (int)e.Cell.Value;
                    if (_beforeIntValue < 0)
                    {
                        _beforeIntValue = _beforeIntValue * -1;
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    _beforeIntValue = 0;
                }
            }
            //ActiveCellがString型の場合
            else if ((cell.Column.Key == this._orderDataTable.InpAnswerPartsNoColumn.ColumnName)        //回答品番
               || (cell.Column.Key == this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName)        //UOE拠点伝票番号
               || (cell.Column.Key == this._orderDataTable.InpBOSlipNo1Column.ColumnName)               //BO伝票番号1
               || (cell.Column.Key == this._orderDataTable.InpBOSlipNo2Column.ColumnName)               //BO伝票番号2
               || (cell.Column.Key == this._orderDataTable.InpBOSlipNo3Column.ColumnName)               //BO伝票番号3
               || (cell.Column.Key == this._orderDataTable.InpBOManagementNoColumn.ColumnName))         //BO管理番号
            {
                if (e.Cell.Value != null)
                {
                    this._beforeStringValue = e.Cell.Value.ToString();
                }
                else
                {
                    this._beforeStringValue = "";
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

			this._gridInputValueIsError = false;

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

            int rowIndex = e.Cell.Row.Index;    //対象行
            //-----------------------------------------------------------
            // 回答品番
            //-----------------------------------------------------------
            if (e.Cell.Column.Key == this._orderDataTable.InpAnswerPartsNoColumn.ColumnName)
            {
                # region 回答品番
                string columnData = (string)e.Cell.Value;
                this._orderDataTable[rowIndex].InpAnswerPartsNo = columnData;
                //this._orderDataTable[rowIndex].AnswerPartsNo = columnData;                        //DEL 2009/01/19 不具合対応[9934]
                # endregion
            }
            /* ---DEL 2009/01/19 不具合対応[9932] ------------------------------------------------>>>>>
            //-----------------------------------------------------------
            // 数量
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
            {
				# region 数量
				double columnData = (double)e.Cell.Value;	//入力値

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

					// 数量を元に戻す
                    this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = this._brforeDoubleValue;
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = this._brforeDoubleValue;
                    this._gridInputValueIsError = true;
				}
				else
				{
                    this._orderDataTable[rowIndex].InpAcceptAnOrderCnt = columnData;
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = columnData;
                }
				# endregion
            }
               ---DEL 2009/01/19 不具合対応[9932] ------------------------------------------------<<<<< */
            //-----------------------------------------------------------
            // 定価
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpAnswerListPriceColumn.ColumnName)
            {
                # region 定価
                double columnData = (double)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "定価の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // 定価を元に戻す
                    this._orderDataTable[rowIndex].InpAnswerListPrice = this._brforeDoubleValue;
                    //this._orderDataTable[rowIndex].AnswerListPrice = this._brforeDoubleValue;     //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpAnswerListPrice = columnData;
                    //this._orderDataTable[rowIndex].AnswerListPrice = columnData;                  //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
            //-----------------------------------------------------------
            // 単価
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName)
            {
                # region 単価
                double columnData = (double)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "単価の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // 単価を元に戻す
                    this._orderDataTable[rowIndex].InpAnswerSalesUnitCost = this._brforeDoubleValue;
                    //this._orderDataTable[rowIndex].AnswerSalesUnitCost = this._brforeDoubleValue; //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpAnswerSalesUnitCost = columnData;
                    //this._orderDataTable[rowIndex].AnswerSalesUnitCost = columnData;              //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
            //-----------------------------------------------------------
            // UOE拠点伝票番号
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName)
            {
                # region UOE拠点伝票番号
                string columnData = (string)e.Cell.Value;
                this._orderDataTable[rowIndex].InpUOESectionSlipNo = columnData;
                //this._orderDataTable[rowIndex].UOESectionSlipNo = columnData;                     //DEL 2009/01/19 不具合対応[9934]
                # endregion
            }
            //-----------------------------------------------------------
            // UOE拠点出庫数
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName)
            {
                # region UOE拠点出庫数
                int columnData = (int)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "UOE拠点出庫数の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // UOE拠点出庫数を元に戻す
                    this._orderDataTable[rowIndex].InpUOESectOutGoodsCnt = this._beforeIntValue;
                    //this._orderDataTable[rowIndex].UOESectOutGoodsCnt = this._beforeIntValue;     //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpUOESectOutGoodsCnt = columnData;
                    //this._orderDataTable[rowIndex].UOESectOutGoodsCnt = columnData;               //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
            //-----------------------------------------------------------
            // BO伝票番号1
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpBOSlipNo1Column.ColumnName)
            {
                # region BO伝票番号1
                string columnData = (string)e.Cell.Value;
                this._orderDataTable[rowIndex].InpBOSlipNo1 = columnData;
                //this._orderDataTable[rowIndex].BOSlipNo1 = columnData;                            //DEL 2009/01/19 不具合対応[9934]
                # endregion
            }
            //-----------------------------------------------------------
            // BO出庫数1
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpBOShipmentCnt1Column.ColumnName)
            {
                # region BO出庫数1
                int columnData = (int)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "BO出庫数1の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // BO出庫数1を元に戻す
                    this._orderDataTable[rowIndex].InpBOShipmentCnt1 = this._beforeIntValue;
                    //this._orderDataTable[rowIndex].BOShipmentCnt1 = this._beforeIntValue;         //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpBOShipmentCnt1 = columnData;
                    //this._orderDataTable[rowIndex].BOShipmentCnt1 = columnData;                   //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
            //-----------------------------------------------------------
            // BO伝票番号2
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpBOSlipNo2Column.ColumnName)
            {
                # region BO伝票番号2
                string columnData = (string)e.Cell.Value;
                this._orderDataTable[rowIndex].InpBOSlipNo2 = columnData;
                //this._orderDataTable[rowIndex].BOSlipNo2 = columnData;                            //DEL 2009/01/19 不具合対応[9934]
                # endregion
            }
            //-----------------------------------------------------------
            // BO出庫数2
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpBOShipmentCnt2Column.ColumnName)
            {
                # region BO出庫数2
                int columnData = (int)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "BO出庫数2の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // BO出庫数2を元に戻す
                    this._orderDataTable[rowIndex].InpBOShipmentCnt2 = this._beforeIntValue;
                    //this._orderDataTable[rowIndex].BOShipmentCnt2 = this._beforeIntValue;         //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpBOShipmentCnt2 = columnData;
                    //this._orderDataTable[rowIndex].BOShipmentCnt2 = columnData;                   //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
            //-----------------------------------------------------------
            // BO伝票番号3
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpBOSlipNo3Column.ColumnName)
            {
                # region BO伝票番号3
                string columnData = (string)e.Cell.Value;
                this._orderDataTable[rowIndex].InpBOSlipNo3 = columnData;
                //this._orderDataTable[rowIndex].BOSlipNo3 = columnData;                            //DEL 2009/01/19 不具合対応[9934]
                # endregion
            }
            //-----------------------------------------------------------
            // BO出庫数3
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpBOShipmentCnt3Column.ColumnName)
            {
                # region BO出庫数3
                int columnData = (int)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "BO出庫数3の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // BO出庫数3を元に戻す
                    this._orderDataTable[rowIndex].InpBOShipmentCnt3 = this._beforeIntValue;
                    //this._orderDataTable[rowIndex].BOShipmentCnt3 = this._beforeIntValue;         //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpBOShipmentCnt3 = columnData;
                    //this._orderDataTable[rowIndex].BOShipmentCnt3 = columnData;                   //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
            //-----------------------------------------------------------
            // メーカーフォロー数
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpMakerFollowCntColumn.ColumnName)
            {
                # region メーカーフォロー数
                int columnData = (int)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "メーカーフォロー数の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // メーカーフォロー数を元に戻す
                    this._orderDataTable[rowIndex].InpMakerFollowCnt = this._beforeIntValue;
                    //this._orderDataTable[rowIndex].MakerFollowCnt = this._beforeIntValue;         //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpMakerFollowCnt = columnData;
                    //this._orderDataTable[rowIndex].MakerFollowCnt = columnData;                   //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
            //-----------------------------------------------------------
            // BO管理番号
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpBOManagementNoColumn.ColumnName)
            {
                # region BO管理番号
                string columnData = (string)e.Cell.Value;
                this._orderDataTable[rowIndex].InpBOManagementNo = columnData;
                //this._orderDataTable[rowIndex].BOManagementNo = columnData;                       //DEL 2009/01/19 不具合対応[9934]
                # endregion
            }
            //-----------------------------------------------------------
            // EO引当数
            //-----------------------------------------------------------
            else if (e.Cell.Column.Key == this._orderDataTable.InpEOAlwcCountColumn.ColumnName)
            {
                # region EO引当数
                int columnData = (int)e.Cell.Value;	//入力値

                //入力エラー時
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "EO引当数の入力値がマイナスです。",
                        -1,
                        MessageBoxButtons.OK);

                    // EO引当数を元に戻す
                    this._orderDataTable[rowIndex].InpEOAlwcCount = this._beforeIntValue;
                    //this._orderDataTable[rowIndex].EOAlwcCount = this._beforeIntValue;            //DEL 2009/01/19 不具合対応[9934]
                    this._gridInputValueIsError = true;
                }
                else
                {
                    this._orderDataTable[rowIndex].InpEOAlwcCount = columnData;
                    //this._orderDataTable[rowIndex].EOAlwcCount = columnData;                      //DEL 2009/01/19 不具合対応[9934]
                }
                # endregion
            }
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
            //処理区分
            else if (cell.Column.Key == this._orderDataTable.InpProcessDivColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_ProcessDiv);
            }
            //回答品番
            else if (cell.Column.Key == this._orderDataTable.InpAnswerPartsNoColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_AnswerPartsNo);
            }
            /* ---DEL 2009/01/19 不具合対応[9932] ------------------------------------------------>>>>>
            //数量
            else if (cell.Column.Key == this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_AcceptAnOrderCnt);
            }
               ---DEL 2009/01/19 不具合対応[9932] ------------------------------------------------<<<<< */
            //定価
            else if (cell.Column.Key == this._orderDataTable.InpAnswerListPriceColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_AnswerListPrice);
            }
            //単価
            else if (cell.Column.Key == this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_AnswerSalesUnitCost);
            }
            //UOE拠点伝票番号
            else if (cell.Column.Key == this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_UOESectionSlipNo);
            }
            //UOE拠点出庫数
            else if (cell.Column.Key == this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_UOESectOutGoodsCnt);
            }
            //BO伝票番号1
            else if (cell.Column.Key == this._orderDataTable.InpBOSlipNo1Column.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_BOSlipNo1);
            }
            //BO出庫数1
            else if (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt1Column.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_BOShipmentCnt1);
            }
            //BO伝票番号2
            else if (cell.Column.Key == this._orderDataTable.InpBOSlipNo2Column.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_BOSlipNo2);
            }
            //BO出庫数2
            else if (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt2Column.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_BOShipmentCnt2);
            }
            //BO伝票番号3
            else if (cell.Column.Key == this._orderDataTable.InpBOSlipNo3Column.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_BOSlipNo3);
            }
            //BO出庫数3
            else if (cell.Column.Key == this._orderDataTable.InpBOShipmentCnt3Column.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_BOShipmentCnt3);
            }
            //メーカーフォロー数
            else if (cell.Column.Key == this._orderDataTable.InpMakerFollowCntColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_MakerFollowCnt);
            }
            //BO管理番号
            else if (cell.Column.Key == this._orderDataTable.InpBOManagementNoColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_BOManagementNo);
            }
            //EO引当数
            else if (cell.Column.Key == this._orderDataTable.InpEOAlwcCountColumn.ColumnName)
            {
                this.StatusBarMessageSetting(this, MESSAGE_EOAlwcCount);
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

			this._gridInputValueIsError = false;        //初期化
            
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

			// 横スクロールバー位置設定
			// this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;

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
            }
        }
        #endregion

        #endregion

    }
}
