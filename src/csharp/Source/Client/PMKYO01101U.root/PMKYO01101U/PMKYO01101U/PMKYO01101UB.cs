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
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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
using Broadleaf.Application.Remoting.ParamData;

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
    public partial class PMKYO01101UB : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constroctors
        /// <summary>
        /// グリッド処理
        /// </summary>
        public PMKYO01101UB()
        {
            InitializeComponent();

            // 変数初期化
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();
            _datareceive = this._dataReceiveInputAcs.DataReceive;
            this._resultDataTable = _datareceive.Setting;
        }

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private DataReceive.SettingDataTable _resultDataTable;
        private DataReceive _datareceive;
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;

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
        private void PMKYO01101UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Result.DataSource = this._datareceive.Tables["DataReceiveResult"];
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ultraGridResult_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._resultDataTable.ResultRowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // 表示幅設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].Width = 30;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].Width = 204;

            // 固定列設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].Header.Fixed = true;	     // №
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].Header.Fixed = true;

            // CellAppearance設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // 入力許可設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;// No
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //DEL 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------>>>>>
            //foreach (APSecMngSetWork secMngSetWork in this._dataReceiveInputAcs.SecMngSetWorkList)
            //{
            //    this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.SectionCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //    this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.SectionCode].Width = 150;
            //}
            //DEL 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------<<<<<
            //ADD 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------<<<<<
            foreach (SndRcvHisWork secMngSetWork in this._dataReceiveInputAcs.SecMngSetWorkList)  
            {
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()].Width = 150;
            }
            this.uGrid_Result.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            //ADD 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        internal void Clear()
        {
            // データ受信DataTable行クリア処理
            this._resultDataTable.Rows.Clear();

            // グリッド行初期設定処理
            this._dataReceiveInputAcs.DataReceiveResultRowInitialSetting();
        }

        #endregion
    }
}
