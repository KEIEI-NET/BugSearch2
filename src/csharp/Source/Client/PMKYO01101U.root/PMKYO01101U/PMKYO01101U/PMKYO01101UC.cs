//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/07/28  修正内容 : SCM対応 拠点管理(10704767-00)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : redmine#26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 受信データフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入入力のフォームクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.21 men 新規作成(DC.NSから流用)</br>
    /// </remarks>
    public partial class PMKYO01101UC : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constroctors
        /// <summary>
        /// グリッド処理
        /// </summary>
        public PMKYO01101UC()
        {
            InitializeComponent();

            // 変数初期化
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();
        }

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;
        private DateTime dataTime = DateTime.MinValue;

        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members

        # endregion


        // ===================================================================================== //
        // プライベート・インターナルメソッド
        // ===================================================================================== //
        # region Private Methods and Internal Methods

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ultraGridCondition_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Condition.DisplayLayout.Bands[0];
            if (editBand == null) return;
            int iIndex = 1;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //UPD 2011/07/28 SCM対応-拠点管理 -------------------------------------------------------------------------->>>>>
                //// 「No列」以外の全てのセルのDiabledColorを設定する。
                //if (col.Key != this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName)
                //{
                //    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                //    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                //}
                if (col.Key != this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName
                    && col.Key != this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionCdColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
                else
                {
                    col.Hidden = true;
                }
                //UPD 2011/07/28 SCM対応-拠点管理 --------------------------------------------------------------------------<<<<<
               
                //if (iIndex > 6)//DEL 2011/07/28 SCM対応-拠点管理 
                //if (iIndex > 8)  //ADD 2011/07/28 SCM対応-拠点管理  //DEL 2011/11/01 xupz redmine#26228
                if (iIndex > 9)  //ADD 2011/11/01 xupz redmine#26228
                {
                    col.Hidden = true;
                }
                iIndex++;
            }

            // グリッド
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center; // ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;//ADD 2011.07.30 sundx

            // 表示幅設定
            //this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].Width = 70;   //DEL 2011.07.30 sundx
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].Width = 153;//ADD 2011.07.30 sundx
            //this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Width = 235;  //DEL 2011.07.30 sundx
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Width = 152;    //ADD 2011.07.30 sundx
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].Width = 140;    //ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Width = 134;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].Width = 133;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Width = 133;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].Width = 133;

            // 固定列設定
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;	     // №
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;  //ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;//ADD 2011.07.30 sundx

            // CellAppearance設定
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;//ADD 2011.07.30 sundx


            // 入力許可設定
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //ADD 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------>>>>>
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;//ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //ADD 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<

            // style
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKYO01101UC_Load(object sender, EventArgs e)
        {
            this.uGrid_Condition.DataSource = this._dataReceiveInputAcs.DataReceive.DataReceiveCondition;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        internal void Clear()
        {
            // データ受信DataTable行クリア処理
            this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.Rows.Clear();

            // グリッド行初期設定処理
            this._dataReceiveInputAcs.DataReceiveConditionRowInitialSetting();
        }

        /// <summary>
        /// Enterキーの処理
        /// </summary>
        /// <param name="sender">選択セル</param>
        /// <param name="e">モード</param>
        /// <remarks>
        /// <br>Note		: Enterキーをクッリクする時、処理を行います。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void uGrid_Condition_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();

                // 変換
                if (value.Length == 8)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionStartTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();

                // 変換
                if (value.Length == 8)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionEndTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ↓ 2009.05.20 liuyang add
            else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName
                    || cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName)
            {
                if (cell.Value is DBNull)
                {
                    this.dataTime = DateTime.MinValue;
                }
                else
                {
                    this.dataTime = Convert.ToDateTime(cell.Value);
                }
            }
            // ↑ 2009.05.20 liuyang add
        }

        /// <summary>
        /// Enterキーの処理
        /// </summary>
        /// <param name="sender">選択セル</param>
        /// <param name="e">モード</param>
        /// <remarks>
        /// <br>Note		: Enterキーをクッリクする時、処理を行います。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void uGrid_Condition_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                
                // 変換
                if (value.Length == 6)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionStartTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();

                // 変換
                if (value.Length == 6)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionEndTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Conditon_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

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

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName)
            {
                string startTime = cell.Value.ToString().Trim();
                // チェック処理
                if (!string.IsNullOrEmpty(startTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < startTime.Length; i++)
                    {
                        if (!char.IsNumber(startTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "開始時間は時間6桁で入力して下さい。",
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // 桁チェック
                        if (startTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始時間は時間6桁で入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // 時間有効性チェック
                            int hour = Convert.ToInt32(startTime.Substring(0, 2));
                            int minute = Convert.ToInt32(startTime.Substring(2, 2));
                            int second = Convert.ToInt32(startTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "開始時間は時間6桁で入力して下さい。",
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionStartTime = startTime.Substring(0, 2) + ":" +
                                    startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                            }
                        }
                    }
                }
            }
            else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                string endTime = cell.Value.ToString().Trim();
                // チェック処理
                if (!string.IsNullOrEmpty(endTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < endTime.Length; i++)
                    {
                        if (!char.IsNumber(endTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "終了時間は時間6桁で入力して下さい。",
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // 桁チェック
                        if (endTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "終了時間は時間6桁で入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // 時間有効性チェック
                            int hour = Convert.ToInt32(endTime.Substring(0, 2));
                            int minute = Convert.ToInt32(endTime.Substring(2, 2));
                            int second = Convert.ToInt32(endTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "終了時間は時間6桁で入力して下さい。",
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionEndTime = endTime.Substring(0, 2) + ":" +
                                    endTime.Substring(2, 2) + ":" + endTime.Substring(4, 2);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Condition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;

            // ActiveCellが単価の場合
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName
                || cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Conditon_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;
                // Shiftキーの場合
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Condition.ActiveCell = null;
                                this.uGrid_Condition.ActiveRow = cell.Row;
                                this.uGrid_Condition.Selected.Rows.Clear();
                                this.uGrid_Condition.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Condition.ActiveCell = null;
                                this.uGrid_Condition.ActiveRow = cell.Row;
                                this.uGrid_Condition.Selected.Rows.Clear();
                                this.uGrid_Condition.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                // EnterNextEditableCellDetail(cell, -1);
                                break;
                            }
                    }
                }
                // Altキーの場合
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                // s
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
                        switch (this.uGrid_Condition.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_Condition.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_Condition.ActiveCell.SelStart >= this.uGrid_Condition.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            // 上記以外のスタイル
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
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
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                // EnterNextEditableCellDetail(cell, 1);
                                break;
                            }
                    }
                }
            }

            else if (this.uGrid_Condition.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Condition.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            // Delキーの操作
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Enterキーの処理
        /// </summary>
        /// <param name="activeCell">選択セル</param>
        /// <param name="mode">モード</param>
        /// <remarks>
        /// <br>Note		: Enterキーをクッリクする時、処理を行います。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void EnterNextEditableCellDetail(Infragistics.Win.UltraWinGrid.UltraGridCell activeCell, int mode)
        {
            int curRowIndex = activeCell.Row.Index;
            int curColIndex = activeCell.Column.Index;
            int rowCount = this.uGrid_Condition.Rows.Count;
            int colCount = this.uGrid_Condition.Rows[curRowIndex].Cells.Count;
            switch (mode)
            {
                case -1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i >= 0; i--)
                        {
                            int j = colCount - 1;
                            if (i == curRowIndex && curColIndex > 0)
                            {
                                j = curColIndex - 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j >= 0; j--)
                            {
                                cell = this.uGrid_Condition.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i < rowCount; i++)
                        {
                            int j = 0;
                            if (i == curRowIndex)
                            {
                                j = curColIndex + 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j < colCount; j++)
                            {
                                cell = this.uGrid_Condition.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
            }
        }


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


        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        public bool ReturnKeyDown()
        {
            return MoveNextAllowEditCell(false);
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Condition.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Condition.ActiveCell != null))
            {
                if ((!this.uGrid_Condition.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Condition.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Condition.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_Condition.ActiveCell != null)
                //{
                //    //int editMode = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._dspcInstsDtlDataTable.EditStatusColumn.ColumnName].Value;
                //    int editMode = BODspcInstsDtlAcs.EDITSTATUS_AllOK;
                //    if ((editMode == BODspcInstsDtlAcs.EDITSTATUS_AllDisable) || (editMode == BODspcInstsDtlAcs.EDITSTATUS_AllReadOnly))
                //    {
                //        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if ((performActionResult) && (this.uGrid_Details.ActiveRow != null))
                //        {
                //            int index = this.uGrid_Details.ActiveRow.Index;

                //            if (!(this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dspcInstsDtlDataTable.GoodsCodeColumn.ColumnName].Hidden))
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._dspcInstsDtlDataTable.GoodsCodeColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._dspcInstsDtlDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // 再帰処理
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_Condition.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Condition.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Condition.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="sender">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <param name="e"></param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private void uGrid_Condition_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Condition.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Condition.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Condition.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Condition.ActiveCell.Value = 0;
                    }
                    // 通常入力				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Condition.ActiveCell.Column.DataType);
                            this.uGrid_Condition.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Condition.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
                else if (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(TimeSpan))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Condition.ActiveCell.EditorResolved;

                        if (editorBase.TextLength == 6)
                        {
                            string value = editorBase.CurrentEditText;

                            editorBase.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                            this.uGrid_Condition.ActiveCell.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "データ値を更新できません:エディタの値は無効です。",
                                -1,
                                MessageBoxButtons.OK);

                            editorBase.Value = null;
                            this.uGrid_Condition.ActiveCell.Value = null;
                        }
                    }
                    catch
                    {

                    }
                }
                // ↓ 2009.05.20 劉洋 add
                else if (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(DateTime))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Condition.ActiveCell.EditorResolved;
                        Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;

                        if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始日付は日付8桁で入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);

                            if (this.dataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.uGrid_Condition.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this.dataTime;
                                this.uGrid_Condition.ActiveCell.Value = this.dataTime;
                            }
                        }
                        else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "終了日付は日付8桁で入力して下さい。",
                               -1,
                               MessageBoxButtons.OK);

                            if (this.dataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.uGrid_Condition.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this.dataTime;
                                this.uGrid_Condition.ActiveCell.Value = this.dataTime;
                            }
                        }
                    }
                    catch
                    {

                    }

                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                }
                // ↑ 2009.05.20 劉洋 add
            }
        }

        #endregion
    }
}
