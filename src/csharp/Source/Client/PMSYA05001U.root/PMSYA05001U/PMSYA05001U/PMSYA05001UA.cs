//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車検期日更新
// プログラム概要   : 車検期日更新フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
// Update Note : 2010/05/08 王海立 REDMINE #7111の対応
// 　　　　　　: 確認のメッセージの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 車検期日更新
    /// </summary>
    /// <remarks>
    /// Note       : 車検期日更新処理です。<br />
    /// Programmer : 王海立<br />
    /// Date       : 2010/04/21<br />
    /// </remarks>
    public partial class PMSYA05001UA : Form
    {
        #region ■ Const Memebers ■
        private const string PROGRAM_ID = "PMSYA05000U";
        #endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: コンストラクタの処理化を行う。</br>
        /// <br>Programmer	: 王海立</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        public PMSYA05001UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._inspectDateUpdAcs = InspectDateUpdAcs.GetInstance();
        }
        # endregion

        # region ■ private field ■
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executionButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode;                         // 企業コード
        private InspectDateUpdAcs _inspectDateUpdAcs;
        #endregion

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 王海立</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void PMKHN09270UA_Load(object sender, EventArgs e)
        {
            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 画面データの初期化設定
            this.InitializeScreen();
        }

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this.Main_UTabControl.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2];
        }
        # endregion

        #region ■ 画面データの初期化処理 ■
        /// <summary>
        /// 画面データの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面データのを行う</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/21</br>
        /// <br>Update Note: 2010/05/08 王海立 確認のメッセージの変更</br>
        /// </remarks>
        private void InitializeScreen()
        {
            this.UpdateDate_tDateEdit.SetDateTime(DateTime.Today);
        }
        #endregion
       
        #endregion

        #region ■ 車検期日更新処理メッソド関連 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 王海立</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Run":
                    {
                        bool inputCheck = this.ExecutBeforeCheck();

                        if (inputCheck)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            // --- UPD 2010/05/08 ---------->>>>>
                            //"車検期日の更新を行います。\r\nよるしいですか？",
                            "車検期日の更新を行います。\r\nよろしいですか？",
                            // --- UPD 2010/05/08 ----------<<<<<
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // 実行処理
                                this.ExecuteProcess();
                            }
                        }
                    }
                    break;
            }
        }

        #region ■ 入力チェック処理 ■
        /// <summary>
        /// 車検期日更新前チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 車検期日更新前チェック処理を行う。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);


                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="errControl">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string message, ref Control errControl)
        {
            message = "";
            errControl = null;

            //入力日付を数値型で取得
            int date = this.UpdateDate_tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;

            if (yy == 0 || mm > 12 || mm == 0)
            {
                message = "更新年月の入力が不正です。";
                errControl = this.UpdateDate_tDateEdit;
                return false;
            }

            return true;
        }
        #endregion
        #endregion

        #region ■ 車検期日更新 ■
        /// <summary>
        /// 車検期日更新処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 車検期日更新処理を行う。</br>
        /// <br>Programmer	: 王海立</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void ExecuteProcess()
        {


            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "車検期日更新";
            form.Message = "現在、車検期日の更新処理中です。\r\nしばらくお待ちください";

            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            form.Show();

            int date = this.UpdateDate_tDateEdit.GetLongDate();
            int day = DateTime.DaysInMonth(date / 10000, (date / 100) % 100);
            //TODO 画面指定 更新年月(末日)以前
            int status = _inspectDateUpdAcs.InspectDateUpdProc(this._enterpriseCode, date / 100 * 100 + day);

            // ダイアログを閉じる
            form.Close();
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "処理が完了しました。",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "該当データがありません。",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "処理中にエラーが発生しました。（" + status.ToString() + "）",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion
    }
}