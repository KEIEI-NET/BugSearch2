//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール送信履歴表示
// プログラム概要   : メール送信履歴表示一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : メール送信履歴表示
// 作 成 日  2010/05/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  2010/06/02  作成担当 : 呉元嘯
// 修 正 日              修正内容 : Redmine#8992対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メール送信履歴表示コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メール送信履歴表示を行うコントロールクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/05/25</br>
    /// <br>Update Note: 2010/06/02 呉元嘯 Redmine#8992対応</br>
    /// </remarks>
    public partial class PMKHN04151UB : UserControl
    {

        #region ■ Private Members

        /// <summary>メール送信履歴表示データセット</summary>
        /// <remarks></remarks>
        private MailHisResultDataSet _dataSet;

        /// <summary>メール送信履歴表示アクセス</summary>
        /// <remarks></remarks>
        private MailHistAcs _mailHistAcs;

        /// <summary>メール内容表示データセット</summary>
        /// <remarks></remarks>
        private PMKHN04151UC _detailContentDis;

        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        #endregion

        #region ■ Constroctors
        /// <summary>
        /// メール送信履歴表示クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール送信履歴表示クラスコンストラクタです。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04151UB()
        {
            InitializeComponent();
            this._mailHistAcs = MailHistAcs.GetInstance();
            this._dataSet = this._mailHistAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.MailHistResult;

        }
        #endregion

        #region ■ Event
        /// <summary>
        /// コントロールロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : コントロールロードイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void PMKHN04151UB_Load(object sender, EventArgs e)
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

            // グリッド行初期設定処理
            this.GridRowInitialSetting();

        }

        /// <summary>
        /// グリッドの初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期化イベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : グリッドキーダウンイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            // 最上行での↑キー
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (this.GridKeyDownTopRow != null)
                    {
                        this.GridKeyDownTopRow(this, new EventArgs());
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                    }
                    
                }
            }
            // →矢印キー
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // ←矢印キー
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    //
                }
                else
                {
                    // グリッド表示を左にスクロール
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

            // Homeキー
            if (e.KeyCode == Keys.Home)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // 先頭行に移動
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }

            // Endキー
            if (e.KeyCode == Keys.End)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // 最終行に移動
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }
        
        /// <summary>
        /// PMKHN04151UB_DoubleClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : PMKHN04151UB_DoubleClickイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        private void uGrid_Details_DoubleClick(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            //メール内容表示画面の表示
            int rowIndex = this.uGrid_Details.ActiveRow.Index;

            ShowMailContent(rowIndex);
        }
        #endregion

        #region ■ Private Methods

        /// <summary>
        /// メール内容表示
        /// </summary>
        /// <remarks>
        /// <param name="rowIndex">明細行</param>
        /// <br>Note       : メール内容表示画面を行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void ShowMailContent(int rowIndex)
        {
            string errMess = string.Empty;
            string textContent = string.Empty;
            int status = 0;

            string fileName = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.FileNameColumn.ColumnName].Value.ToString();
            
            status = this._mailHistAcs.GetMailHistDetail(fileName, out errMess, out textContent);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                QrMailHist _qrMailHist = new QrMailHist();
                //受信者名称
                _qrMailHist.EmployeeName = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Value.ToString();
                //CC情報
                _qrMailHist.CCInfo = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.CCInfoColumn.ColumnName].Value.ToString();
                //件名
                _qrMailHist.Title = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.TitleColumn.ColumnName].Value.ToString();
                //送信日付
                _qrMailHist.TransmitDate = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Value.ToString();
                //QRコード
                _qrMailHist.QRCode = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.QRCodeColumn.ColumnName].Value.ToString();
               
                _qrMailHist.MailText = textContent;

                _detailContentDis = new PMKHN04151UC(_qrMailHist);
                _detailContentDis.ShowDialog();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               this.Name,
                               "メール情報設定が存在しません。",
                               0,
                               MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
            {
                TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               this.Name,
                               "メール情報が存在しません。\r\n\r\n保存先フォルダの設定を確認して下さい。",
                               0,
                               MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_STOP,
                               this.Name,
                               errMess,
                               0,
                               MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <param name="Columns">Columns</param>
        /// <br>Note       : グリッド列初期設定処理を行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// <br>Update Note: 2010/06/02 呉元嘯 Redmine#8992対応</br>
        /// </remarks>
        private void GridColInitialSetting(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            int visiblePosition = 1;
            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                //入力許可設定
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            # region [カラム設定]
            //送信日
            // --------UPD 2010/06/02--------->>>>>
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Header.Caption = "送信日";
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Width = 200;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].MaxLength = 10;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Header.Caption = "送信日";
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Width = 200;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].MaxLength = 10;
            // --------UPD 2010/06/02---------<<<<<

            //受信者
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Header.Caption = "受信者";
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Width = 200;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].MaxLength = 10;

            //QR
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Header.Caption = "QR";
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Width = 100;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].MaxLength = 1;

            //件名
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Header.Caption = "件名";
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Width = 494;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].MaxLength = 256;
            
            # endregion

        }

        /// <summary>
        /// グリッド行初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド行初期設定を行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void GridRowInitialSetting()
        {
            this._dataSet.MailHistResult.Rows.Clear();
        }

        /// <summary>
        /// グリッド行初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド行初期設定を行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public void ShowMailContent()
        {
            //メール内容表示画面の表示
            int rowIndex = this.uGrid_Details.ActiveRow.Index;

            ShowMailContent(rowIndex);
        }

        #endregion

    }
}