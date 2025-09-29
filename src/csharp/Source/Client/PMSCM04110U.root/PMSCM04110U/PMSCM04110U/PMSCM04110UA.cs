//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期状況確認メインフレームクラス
// プログラム概要   : 同期状況確認メインフレームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/08/01   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/09/12   修正内容 : Redmine#43532
//                                   クライアントログの出力、アイコンの指摘を対応する
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Threading;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 同期状況確認メインフレーム
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期状況確認メインフレームです。</br>
    /// <br>Programer  : 田建委</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br>Update Note: 2014/09/12 田建委</br>
    /// <br>管理番号   : 11070136-00 Redmine#43532</br>
    /// <br>           : クライアントログの出力、アイコンの指摘を対応する</br>
    /// </remarks>
    public partial class PMSCM04110UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 同期状況確認コンストラクタ</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public PMSCM04110UA()
        {
            InitializeComponent();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            //同期状況確認アクセス
            _synchConfirmAcs = new SynchConfirmAcs();
            //同期実行アクセス
            _synchExecuteAcs = new SynchExecuteAcs();

            grid_SynchConfirm.DataSource = _synchConfirmAcs.SynchConfirmDataTable;

        }
        # endregion

        # region プライベイトメンバ
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>同期状況確認アクセス</summary>
        private SynchConfirmAcs _synchConfirmAcs;
        /// <summary>同期実行アクセス</summary>
        private SynchExecuteAcs _synchExecuteAcs;
        /// <summary>同期モード（0：手動モード　1：再同期モード）</summary>
        private int _syncMode;
        /// <summary>同期エラー有無（true：エラーあり　false：エラーなし）</summary>
        private bool _isError;
        /// <summary>エラー発生する一番古い時間（画面で表示用）</summary>
        private DateTime _errStTime;
        /// <summary>エラーステータス（画面で表示用）</summary>
        private int _errStatus;
        /// <summary>エラー内容（画面で表示用）</summary>
        private string _errMessage;
        /// <summary>XMLからの関連するマスタ情報</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOn;
        /// <summary>XMLからの関連するマスタ情報</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOff;
        /// <summary>再処理時</summary>
        public event EventHandler RetetEvent;

        /// <summary>手動送受信</summary>
        private const int SYNC_MANUAL = 0;
        /// <summary>送受信再開</summary>
        private const int SYNC_RESTART = 1;
        # endregion

        /// <summary>
        /// フォームのLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 同期状況確認コンストラクタ</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void PMSCM04110UA_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        /// <summary>
        /// timer1_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            //同期管理マスタ情報を取得
            GetSyncMngData();
        }

        /// <summary>
        /// 同期管理マスタ情報の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 同期管理マスタ情報を取得する</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/12 田建委</br>
        /// <br>管理番号   : 11070136-00 Redmine#43532</br>
        /// <br>           : クライアントログの出力、アイコンの指摘を対応する</br>
        /// </remarks>
        private int GetSyncMngData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            string errMessage = string.Empty;

            try
            {
                //同期管理マスタ情報の取得
                status = _synchConfirmAcs.Search(this._enterpriseCode, out errMessage);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    //関連するマスタ情報
                    _tableIDDicForCheckOn = _synchConfirmAcs.TableIDDicForCheckOn;
                    _tableIDDicForCheckOff = _synchConfirmAcs.TableIDDicForCheckOff;
                    //同期モード（0：手動モード　1：再同期モード）
                    _syncMode = _synchConfirmAcs.SyncMode;
                    //同期エラー有無（true：エラーあり　false：エラーなし）
                    _isError = _synchConfirmAcs.IsError;
                    //エラー発生する一番古い時間（画面で表示用）
                    _errStTime = _synchConfirmAcs.ErrStTime;
                    //エラーステータス（画面で表示用）
                    _errStatus = _synchConfirmAcs.ErrStatus;
                    //エラー内容（画面で表示用）
                    _errMessage = _synchConfirmAcs.ErrMessage;

                    grid_SynchConfirm.Focus();
                    grid_SynchConfirm.Rows[0].Activate();
                    grid_SynchConfirm.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessage = ex.Message;
                WriteErrorLog(ex, "PMSCM04110UA.GetSyncMngData", status); // ADD 2014/09/12 田建委 Redmine#43532
            }
            finally
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (string.IsNullOrEmpty(errMessage))
                    {
                        errMessage = "該当するデータがありません。";
                    }

                    WriteErrorLog(null, errMessage, status); // ADD 2014/09/12 田建委 Redmine#43532

                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                    errMessage, 0, MessageBoxButtons.OK);
                }
            }

            //各ボタンの設定
            setContorlEnable();

            return status;
        }

        /// <summary>
        /// 各ボタンの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 各ボタンの設定を行う</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void setContorlEnable()
        {
            if (_syncMode == SYNC_RESTART)
            {
                this.btn_SelectAll.Enabled = false; //全て選択
                this.btn_CancelAll.Enabled = false; //全て解除
                this.btn_ReRead.Enabled = false; //再読み込み

                SetGridEnable(false);

                btn_SelectAll_Click(this, null);

                string errorMessage = _errStTime.ToString("yyyy年MM月dd日 HH:mm") + "以降 " + _errMessage + " ST=" + _errStatus + "\nエラー原因復旧後に「再送信」ボタンを押してください。";
                this.lable_ErrorMessage.Text = errorMessage;
                this.lable_ErrorMessage.Visible = true; //エラー内容
            }
            else
            {
                this.btn_SelectAll.Enabled = true; //全て選択
                this.btn_CancelAll.Enabled = true; //全て解除
                this.btn_ReRead.Enabled = true; //再読み込み

                SetGridEnable(true);

                btn_CancelAll_Click(this, null);

                this.lable_ErrorMessage.Text = string.Empty;
                this.lable_ErrorMessage.Visible = false; //エラー内容
            }
        }

        /// <summary>
        /// グリッド選択可能の設定
        /// </summary>
        /// <param name="enable">グリッド操作可能フラグ</param>
        /// <remarks>
        /// <br>Note       : グリッド選択可能の設定を行う</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetGridEnable(bool enable)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.grid_SynchConfirm.DisplayLayout.Bands[0].Columns;
            if (!enable)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
                {
                    column.CellActivation = Activation.Disabled;
                }
            }
            else
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
                {
                    column.CellActivation = Activation.ActivateOnly;
                }
            }
        }

        /// <summary>
        /// データグリッドの初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : データグリッドの初期化を行う</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void grid_SynchConfirm_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ColumnsCollection column = e.Layout.Bands[0].Columns;

            column[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.ErrorStatusColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.ErrorContentsColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.SyncCndtinStaColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName].Hidden = true;


            column[_synchConfirmAcs.SynchConfirmDataTable.TableNameColumn.ColumnName].Width = 350;
            column[_synchConfirmAcs.SynchConfirmDataTable.LastSyncUpdDtTmColumn.ColumnName].Width = 200;
            column[_synchConfirmAcs.SynchConfirmDataTable.SyncCndtinDivColumn.ColumnName].Width = 300;
            column[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Width = 100;

            column[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].CellAppearance.ImageHAlign = HAlign.Center;
        }

        /// <summary>
        /// 再読み込み処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 再読み込み処理を行う</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_ReRead_Click(object sender, EventArgs e)
        {
            int status = GetSyncMngData();

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                "再読み込みが成功しました。", 0, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 送受信処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 送受信処理を行う</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_Synch_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (_synchConfirmAcs.SynchConfirmDataTable.Rows.Count == 0)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text,
                "初回同期処理が完了していません。\n初回同期処理が完了後、確認が行えるようになります。", 0, MessageBoxButtons.OK);
                return;
            }

            if (_syncMode == SYNC_RESTART)
            {
                //再同期モード
                status = _synchExecuteAcs.SyncReqReExecute();
            }
            else
            {
                //手動同期モード
                ArrayList tableIDList = new ArrayList();
                foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
                {
                    if ((bool)row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] == true)
                    {
                        string tableID = row[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].ToString();

                        if (!tableIDList.Contains(tableID))
                        {
                            tableIDList.Add(tableID);
                        }
                    }
                }

                if (tableIDList.Count == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text,
                    "再送信テーブルを選択して下さい。", 0, MessageBoxButtons.OK);
                    return;
                }

                //送受信処理
                status = _synchExecuteAcs.SyncReqExecuteForTable(this._enterpriseCode, tableIDList);
            }

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (RetetEvent != null)
                {
                    RetetEvent(this,null);
                }
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                "再送信処理に成功しました。", 0, MessageBoxButtons.OK);

                GetSyncMngData();
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text,
                "再送信処理に失敗しました。", 0, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 画面を閉じる</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// グリッドの全て選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グリッドの全て選択処理を行う</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
            {
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = true;
            }
        }

        /// <summary>
        /// グリッドの全て解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グリッドの全て解除処理を行う</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_CancelAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
            {
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = DBNull.Value;
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = false;
            }
        }

        /// <summary>
        /// グリッドにダブルクリックにより選択のON、OFFが切り替わる。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グリッドにダブルクリックにより選択のON、OFFが切り替わる。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void grid_SynchConfirm_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow activeRow = grid_SynchConfirm.ActiveRow;
            SetSelectValue(activeRow);

            grid_SynchConfirm.UpdateData();
        }

        /// <summary>
        /// グリッドに選択のON、OFFが切り替わる
        /// </summary>
        /// <param name="row"></param>
        /// <remarks>
        /// <br>Note       : グリッドに選択のON、OFFが切り替わる</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetSelectValue(UltraGridRow row)
        {
            //手動モードのみ、グリッドを選択する
            if (_syncMode == SYNC_MANUAL && row != null)
            {
                CellsCollection cells = row.Cells;

                string tableID = cells[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].Value.ToString();

                // 選択/非選択の切り替え
                if (cells[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Value != DBNull.Value)
                {
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Value = DBNull.Value;
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName].Value = false;

                    //関連するマスタの非選択
                    SetRelatedTblCheckOff(tableID);
                }
                else
                {
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName].Value = true;

                    //関連するマスタの選択
                    SetRelatedTblCheckOn(tableID);
                }
            }
        }

        /// <summary>
        /// 関連するマスタの選択ON
        /// </summary>
        /// <param name="mainTable">テーブルID</param>
        /// <param name="checkFlag"></param>
        /// <remarks>
        /// <br>Note       : 関連するマスタの選択ON</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetRelatedTblCheckOn(string mainTable)
        {
            if (_tableIDDicForCheckOn.ContainsKey(mainTable))
            {
                foreach (ReferenceTable subTableID in _tableIDDicForCheckOn[mainTable])
                {
                    foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
                    {
                        if (row[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].ToString().Equals(subTableID.ReferenceTableID))
                        {
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 関連するマスタの選択の解除
        /// </summary>
        /// <param name="subTableID">テーブルID</param>
        /// <remarks>
        /// <br>Note       : 関連するマスタの選択の解除</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetRelatedTblCheckOff(string subTableID)
        {
            if (_tableIDDicForCheckOff.ContainsKey(subTableID))
            {
                foreach (ReferenceTable mainTableID in _tableIDDicForCheckOff[subTableID])
                {
                    foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
                    {
                        if (row[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].ToString().Equals(mainTableID.ReferenceTableID))
                        {
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = DBNull.Value;
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// グリッドに各キーを押下する動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グリッドに各キーを押下する動作。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void grid_SynchConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (grid_SynchConfirm.ActiveRow != null)
            {
                int activeRowIndex = grid_SynchConfirm.ActiveRow.Index;

                switch (e.KeyCode)
                {
                    case Keys.Space://スペースキー
                        {
                            UltraGridRow activeRow = grid_SynchConfirm.ActiveRow;
                            SetSelectValue(activeRow);

                            grid_SynchConfirm.UpdateData();
                            break;
                        }
                    case Keys.Left: //←キー
                    case Keys.Right: //→キー
                        {
                            e.Handled = true;
                            break;
                        }
                    case Keys.Up: //↑キー
                        {
                            if (activeRowIndex == 0)
                            {
                                this.btn_SelectAll.Focus();
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = true;
                                this.grid_SynchConfirm.Rows[activeRowIndex - 1].Activate();
                                this.grid_SynchConfirm.Rows[activeRowIndex - 1].Selected = true;
                            }
                            break;
                        }
                    case Keys.Down: //↓キー
                        {
                            if (activeRowIndex == grid_SynchConfirm.Rows.Count - 1)
                            {
                                this.btn_ReRead.Focus();
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = true;
                                this.grid_SynchConfirm.Rows[activeRowIndex + 1].Activate();
                                this.grid_SynchConfirm.Rows[activeRowIndex + 1].Selected = true;
                            }
                            break;
                        }

                }
            }
        }

        /// <summary>
        /// grid_SynchConfirm_Leaveイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void grid_SynchConfirm_Leave(object sender, EventArgs e)
        {
            if (grid_SynchConfirm.ActiveRow != null)
            {
                grid_SynchConfirm.ActiveRow.Selected = false;
                grid_SynchConfirm.ActiveRow = null;
                grid_SynchConfirm.Invalidate();
            }
        }

        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note	   : ChangeFocus時に発生します。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // グリッド
            if (e.NextCtrl == this.grid_SynchConfirm)
            {
                switch (e.Key)
                {
                    case Keys.Up:
                        {
                            if (this.grid_SynchConfirm.Rows.Count != 0)
                            {
                                this.grid_SynchConfirm.Rows[this.grid_SynchConfirm.Rows.Count - 1].Activate();
                                this.grid_SynchConfirm.Rows[this.grid_SynchConfirm.Rows.Count - 1].Selected = true;
                            }
                            break;
                        }
                    case Keys.Down:
                    case Keys.Enter:
                    case Keys.Tab:
                        {
                            if (this.grid_SynchConfirm.Rows.Count != 0)
                            {
                                this.grid_SynchConfirm.Rows[0].Activate();
                                this.grid_SynchConfirm.Rows[0].Selected = true;
                            }
                            break;
                        }

                }
            }
        }

        //----- ADD 2014/09/12 田建委 Redmine#43532 ---------->>>>>
        #region [エラーログ出力処理]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorText">errorText</param>
        /// <param name="status">status</param>
        /// <remarks>
        /// <br>Note       : エラーログ出力処理を行う。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/09/12</br>
        /// </remarks>
        public static void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                new ClientLogTextOut().Output(ex.Source, message, status, ex);
            }
            else
            {
                new ClientLogTextOut().Output("PMSCM04110U", errorText, status);
            }
        }
        #endregion
        //----- ADD 2014/09/12 田建委 Redmine#43532 ----------<<<<<
    }
}