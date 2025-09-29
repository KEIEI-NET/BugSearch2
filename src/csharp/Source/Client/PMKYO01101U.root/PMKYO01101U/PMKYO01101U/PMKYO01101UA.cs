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
// 作 成 日  2011/07/28  修正内容 : SCM対応 拠点管理(10704767-00) 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/24  修正内容 : Redmine #23808ソースレビュー結果の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/27  修正内容 : Redmine #23890 受信データがない場合について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/29  修正内容 : Redmine #8136 拠点管理／受信処理の締チェック処理変更
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Threading;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
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
    /// <br>UpDate     : 劉洋 2009.04.30 データ追加</br>
    /// <br>2008.05.21 men 新規作成(DC.NSから流用)</br>
    /// </remarks>
    public partial class PMKYO01101UA : Form
    {

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 受信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        public PMKYO01101UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoginName"];
            // ログイン担当者
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();

            // 画面初期化
            this._dataReceiveInputAcs.ReadInitData();
            this._dataReceiveInputAcs.GetSecMngSendData(this._erterpriseCode);

            // 画面グリッド
            this._dataReceiveResult = new PMKYO01101UB();
            this._dataReceiveCondition = new PMKYO01101UC();

            this._controlScreenSkin = new ControlScreenSkin();
        }

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private PMKYO01101UB _dataReceiveResult;
        private PMKYO01101UC _dataReceiveCondition;
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private Control _prevControl = null;									// 現在のコントロール

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;            // 更新ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;             // クリアボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称
        private ControlScreenSkin _controlScreenSkin;
        private int _connectPointDiv = 0;
        private string _erterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        #endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region ■Const Members
        private const string ctTOOLBAR_BUTTONTOOL_CLOSE_KEY = "ButtonTool_Close";
        private const string ctTOOLBAR_BUTTONTOOL_UPDATE_KEY = "ButtonTool_Update";
        private const string ctTOOLBAR_BUTTONTOOL_CLEAR_KEY = "ButtonTool_Clear";

        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
		/// ボタン初期設定処理
		/// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        private void Clear()
        {
            // 画面初期化
            this._dataReceiveInputAcs.ReadInitData();
            this._dataReceiveInputAcs.GetSecMngSendData(this._erterpriseCode);
            // グリッドを更新する
            this._dataReceiveInputAcs.DataSetAgain();

            // 画面初期化処理
            this._dataReceiveResult.Clear();
            this._dataReceiveCondition.Clear();

            // グリッド設定
            this._dataReceiveResult.uGrid_Result.DataSource = this._dataReceiveInputAcs.DataReceive.Tables["DataReceiveResult"];
            this._dataReceiveCondition.uGrid_Condition.DataSource = this._dataReceiveInputAcs.DataReceive.DataReceiveCondition;

            // 初期化フォーカス設定
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
        }

        /// <summary>
        /// 画面保存
        /// </summary>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
            if (this._dataReceiveCondition.uGrid_Condition.ActiveCell != null)
            {
                this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }

            // 保存チェック
            bool check = this.CheckSaveData();

            if (!check)
            {
                return;
            }

            //ADD 2011/07/28 SCM対応-拠点管理 ----------------->>>>>
            ArrayList errMsgList;
            string errMsg = "";
            check = this._dataReceiveInputAcs.CheckData(out errMsgList, ref errMsg);
            if (!check)
            {
                PMKYO01101UD errForm = new PMKYO01101UD(errMsgList);  // ADD 2011/11/29

                if (errMsgList.Count > 0)
                {
                    //PMKYO01101UD errForm = new PMKYO01101UD(errMsgList);  // DEL 2011/11/29
                    //errForm.Show();     // DEL 2011/11/29
                    errForm.ShowDialog();  // ADD 2011/11/29
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        errMsg,
                        status,
                        MessageBoxButtons.OK);
                }

                // --- ADD 2011/11/29 --- >>>
                if (!errForm._continueFlg)
                {
                    return;
                }
                // --- ADD 2011/11/29 --- <<<
            }            
            //ADD 2011/07/28 SCM対応-拠点管理 -----------------<<<<<

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "受信処理中";
            msgForm.Message = "受信処理中です";

            try
            {
                msgForm.Show();
                // 変更処理
                //status = this._dataReceiveInputAcs.SaveData(this._connectPointDiv);            // DEL 2011/11/29
                status = this._dataReceiveInputAcs.SaveData(errMsgList, this._connectPointDiv);  // ADD 2011/11/29
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                msgForm.Close();
            }


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    //"抽出対象のデータが存在しません。",//DEL 2011/08/27  修正内容 : #23890 受信データがない場合について
                    "受信対象のデータが存在しません。",//ADD 2011/08/27  修正内容 : #23890 受信データがない場合について
                    status,
                    MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "処理が込み合っているためタイムアウトしました。\r\n"
                   + "再試行するか、しばらく待ってから再度処理を行ってください。",
                   status,
                   MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   "排他処理に失敗しました。",
                   status,
                   MessageBoxButtons.OK);

            }
        }

        /// <summary>
        /// 保存前チェック
        /// </summary>
        public bool CheckSaveData()
        {
            #region DEL 2011/07/28 SCM対応-拠点管理
            //DEL 2011/07/28 SCM対応-拠点管理 -------------------------------------------------------------------------------------------------------<<<<< 
            //// 更新結果チェック
            //if (this._dataReceiveResult.uGrid_Result.Rows.Count == 0)
            //{
            //    TMsgDisp.Show(
            //      this,
            //      emErrorLevel.ERR_LEVEL_INFO,
            //      this.Name,
            //      "送受信対象設定マスタが設定されていません。",
            //      -1,
            //      MessageBoxButtons.OK);
            //    return false;
            //}

            //// 拠点チェック
            //if (this._dataReceiveInputAcs.SecMngSetWorkList.Count == 0)
            //{
            //    TMsgDisp.Show(
            //      this,
            //      emErrorLevel.ERR_LEVEL_INFO,
            //      this.Name,
            //      "受信対象拠点が設定されていません。",
            //      -1,
            //      MessageBoxButtons.OK);
            //    return false;
            //}

            //if (this._dataReceiveInputAcs.DataReceive.DataReceiveCondition != null)
            //{
            //    this.ultraTabControl2.Tabs[1].Selected = true;

            //    int rowIndex = 0;
            //    // 拠点チェック
            //    foreach (DataReceive.DataReceiveConditionRow row in this._dataReceiveInputAcs.DataReceive.DataReceiveCondition)
            //    {
            //        // 開始日付未入力チェック
            //        if (this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2].Value is DBNull)
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "抽出開始日付が未入力です。",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2];
            //            return false;
            //        }

            //        // 開始時間未入力チェック
            //        if (string.IsNullOrEmpty(this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[3].Value.ToString()))
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "抽出開始時間が未入力です。",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[3];
            //            return false;
            //        }

            //        // 終了日付未入力チェック
            //        if (this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[4].Value is DBNull)
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "抽出終了日付が未入力です。",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[4];
            //            return false;
            //        }

            //        // 終了時間未入力チェック
            //        if (string.IsNullOrEmpty(this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[5].Value.ToString()))
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "抽出終了時間が未入力です。",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[5];
            //            return false;
            //        }

            //        // 時間範囲チェック
            //        // シック時間チェック
                    
            //        APSecMngSetWork secMngSetWork = (APSecMngSetWork)this._dataReceiveInputAcs.SecMngSetWorkList[rowIndex];                    
            //        DateTime startDateTime = new DateTime();
            //        if (secMngSetWork..SyncExecDate.Year == row.ConditionStartDate.Year
            //            && secMngSetWork.SyncExecDate.Month == row.ConditionStartDate.Month
            //            && secMngSetWork.SyncExecDate.Day == row.ConditionStartDate.Day
            //            && secMngSetWork.SyncExecDate.Hour == Convert.ToInt32(row.ConditionStartTime.Substring(0, 2))
            //            && secMngSetWork.SyncExecDate.Minute == Convert.ToInt32(row.ConditionStartTime.Substring(3, 2))
            //            && secMngSetWork.SyncExecDate.Second == Convert.ToInt32(row.ConditionStartTime.Substring(6, 2)))
            //        {
            //            startDateTime = secMngSetWork.SyncExecDate;
            //        }
            //        else
            //        {
            //            startDateTime = new DateTime(row.ConditionStartDate.Year, row.ConditionStartDate.Month, row.ConditionStartDate.Day,
            //                Convert.ToInt32(row.ConditionStartTime.Substring(0, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(3, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(6, 2)));
            //        }
            //        DateTime endDateTime = new DateTime(row.ConditionEndDate.Year, row.ConditionEndDate.Month, row.ConditionEndDate.Day,
            //            Convert.ToInt32(row.ConditionEndTime.Substring(0, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(3, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(6, 2)));
            //        if (startDateTime > endDateTime)                    
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "抽出日付の範囲が不正です。",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2];
            //            return false;
            //        }

            //        // 情報を再取得する
            //        this._dataReceiveInputAcs.ReadInitData();

            //        bool isExistFlg = false;
            //        foreach (APSecMngSetWork secMngSet in this._dataReceiveInputAcs.SecMngSetWorkList)                   
            //        {
            //            if (secMngSet.SectionCode == row.ConditionSectionCd)
            //            {
            //                isExistFlg = true;
            //                secMngSetWork = secMngSet;
            //            }
            //        }

            //        // 取得ないの場合
            //        if (!isExistFlg)
            //        {
            //            TMsgDisp.Show(
            //             this,
            //             emErrorLevel.ERR_LEVEL_INFO,
            //             this.Name,
            //             "受信対象拠点が設定されていません。",
            //             -1,
            //             MessageBoxButtons.OK);
            //            return false;
            //        }

            //        // 開始日付の変更時は同一月内のみ設定が可能です
            //        if (startDateTime < secMngSetWork.SyncExecDate)
            //        {
            //            if (startDateTime.Month != endDateTime.Month
            //                || startDateTime.Year != endDateTime.Year)
            //            {
            //                TMsgDisp.Show(
            //                  this,
            //                  emErrorLevel.ERR_LEVEL_INFO,
            //                  this.Name,
            //                  "開始日付の変更時は同一月内のみ設定が可能です。",
            //                  -1,
            //                  MessageBoxButtons.OK);
            //                this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2];
            //                return false;
            //            }
            //        }                    
            //        rowIndex++;
            //    }

            //    this.ultraTabControl2.Tabs[0].Selected = true;
            //}
            //DEL 2011/07/28 SCM対応-拠点管理 -------------------------------------------------------------------------------------------------------<<<<<
            #endregion

            // ↓ 2009.04.30 liuyang add
            // 接続先チェック
            string errMessage = null;
            if (!_dataReceiveInputAcs.CheckConnect(_erterpriseCode, out _connectPointDiv, out errMessage, 0))
            {
                TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_INFO,
                  this.Name,
                  errMessage,
                  -1,
                  MessageBoxButtons.OK);
                return false;
            }
            return true;
            // ↑ 2009.04.30 liuyang add
        }
        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region ■Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKYO01101UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._dataReceiveResult);
            this._controlScreenSkin.SettingScreenSkin(this._dataReceiveCondition);

            // グリッド設定
            this.panel_Result.Controls.Add(this._dataReceiveResult);
            this.panel_Condition.Controls.Add(this._dataReceiveCondition);
            this._dataReceiveResult.Dock = DockStyle.Fill;
            this._dataReceiveCondition.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 画面初期化検索
            // this._dataReceiveInputAcs.ReadInitData();

            // 明細グリッド設定
            this._dataReceiveResult.Clear();
            this._dataReceiveCondition.Clear();

            // 初期化フォーカス設定
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];

            // ↓ 2009.04.30 liuyang add
            this.timer_Slide.Enabled = true;
            // ↑ 2009.04.30 liuyang add
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case ctTOOLBAR_BUTTONTOOL_CLOSE_KEY:
                    {
                        this.Close();
                        break;
                    }
                case ctTOOLBAR_BUTTONTOOL_UPDATE_KEY:
                    {
                        this.Save();
                        break;
                    }
                case ctTOOLBAR_BUTTONTOOL_CLEAR_KEY:
                    {
                        this.Clear();
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            //DEL 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------>>>>>
            //switch (e.PrevCtrl.Name)
            //{
            //    case "uGrid_Condition":
            //        {
            //            switch (e.Key)
            //            {
            //                case Keys.Return:
            //                    {
            //                        if (this._dataReceiveCondition.uGrid_Condition.ActiveCell != null)
            //                        {
            //                            if (this._dataReceiveCondition.ReturnKeyDown())
            //                            {
            //                                e.NextCtrl = null;
            //                            }
            //                            else if (this._dataReceiveCondition.uGrid_Condition.Rows[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.Count - 1].Cells[5].Activated)
            //                            {
            //                                e.NextCtrl = null;
            //                                this._dataReceiveCondition.uGrid_Condition.Rows[0].Cells[2].Activate();
            //                                this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            //                            }
            //                            else
            //                            {
            //                                e.NextCtrl = e.PrevCtrl;
            //                            }
            //                        }

            //                        break;
            //                    }
            //                case Keys.Tab:
            //                    {
            //                        if (this._dataReceiveCondition.ReturnKeyDown())
            //                        {
            //                            e.NextCtrl = null;
            //                        }
            //                        else if (this._dataReceiveCondition.uGrid_Condition.Rows[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.Count - 1].Cells[5].Activated)
            //                        {
            //                            e.NextCtrl = null;
            //                            this._dataReceiveCondition.uGrid_Condition.Rows[0].Cells[2].Activate();
            //                            this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            //                        }
            //                        else
            //                        {
            //                            e.NextCtrl = e.PrevCtrl;
            //                        }

            //                        break;
            //                    }
            //            }
            //            break;
            //        }
            //}
            //DEL 2011/07/28 SCM対応-拠点管理 ------------------------------------------------------<<<<<
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // フォーカス設定
            if (e.Tab == this.ultraTabControl2.Tabs[1])
            {
                if (this._dataReceiveCondition.uGrid_Condition.Rows.Count != 0)
                {
                    this._dataReceiveCondition.uGrid_Condition.Focus();
                    this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[0].Cells[2];
                    this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }

			// ADD 2011.08.24---------->>>>>
			if (e.Tab.Key.Equals("ReceivedInfo"))
			{
				ultraLabel1.Visible = true;
			}
			else
			{
				ultraLabel1.Visible = false;
			}
			// ADD 2011.08.24----------<<<<<
        }


        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_Slide_Tick(object sender, EventArgs e)
        {

            this.timer_Slide.Enabled = false;

            // 接続先チェック
            string errMsg = null;
            if (!_dataReceiveInputAcs.CheckConnect(LoginInfoAcquisition.EnterpriseCode, out _connectPointDiv, out errMsg, 0))
            {
                TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_INFO,
                  this.Name,
                  errMsg,
                  -1,
                  MessageBoxButtons.OK);
                return;
            }
        }

        #endregion
    }
}