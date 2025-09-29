using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 一式情報選択フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 一式情報選択のフォームクラスです。(一式明細追加時に使用)</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.11.12 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    public partial class MAHNB01010UI : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        public MAHNB01010UI()
        {
            InitializeComponent();

            _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            _salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();

            this._completeInfoDataTable = _salesSlipInputAcs.CompleteInfoDataTable;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Decision"];
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesInputDataSet.CompleteInfoDataTable _completeInfoDataTable;
        private DataView _completeInfoView = null;
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
        private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// フォームLoadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_Load(object sender, EventArgs e)
        {
            // ツールバーボタン初期設定
            this.ButtonInitialSetting();

            // 初期設定タイマー起動
            this.Initial_Timer.Enabled = true;

            // グリッド情報設定
            this._completeInfoView = this._completeInfoDataTable.DefaultView;
            this.uGrid_CompleteInfo.DataSource = this._completeInfoView;

        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。
        ///	                 この処理は、システムが提供するスレッド プール
        ///	                 スレッドで実行されます。</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // 初期設定タイマー解除
            this.Initial_Timer.Enabled = false;

            // 初期フォーカス位置指定
            this.uGrid_CompleteInfo.Focus();
            this.uGrid_CompleteInfo.Rows[0].Selected = true;
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // 明細部
                //---------------------------------------------------------------
                case "uGrid_CompleteInfo":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    int completeInfoIndex = uGrid_CompleteInfo.ActiveRow.Index;
                                    this._salesSlipInputAcs.TargetIndex = completeInfoIndex;
                                    this._salesSlipInputAcs.TargetRowNo = this._salesSlipInputAcs.GetCmpltSalesRowNo(completeInfoIndex);
                                    this.SetDialogRes(DialogResult.OK);
                                    this.CloseForm();
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {

                //--------------------------------------------
                // 終了
                //--------------------------------------------
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        this.CloseForm();
                        break;
                    }
                //--------------------------------------------
                // 確定
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {

                        int completeInfoIndex = uGrid_CompleteInfo.ActiveRow.Index;
                        this._salesSlipInputAcs.TargetIndex = completeInfoIndex;
                        this._salesSlipInputAcs.TargetRowNo = this._salesSlipInputAcs.GetCmpltSalesRowNo(completeInfoIndex);
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_CompleteInfo.DisplayLayout.Bands[0].Columns;


            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            this.uGrid_CompleteInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // №
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 一式名称
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Width = 100;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 数量
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Width = 80;
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 売上金額
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Width = 100;
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 固定列区切り線設定
            this.uGrid_CompleteInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// グリッドダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int completeInfoIndex = e.Row.Index;
            this._salesSlipInputAcs.TargetIndex = completeInfoIndex;
            this._salesSlipInputAcs.TargetRowNo = this._salesSlipInputAcs.GetCmpltSalesRowNo(completeInfoIndex);

            this.SetDialogRes(DialogResult.OK);
            this.CloseForm();
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }
        # endregion

    }
}