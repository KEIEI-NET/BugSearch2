//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＢＬコード層別変換処理
// プログラム概要   : ＢＬコード層別変換処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/01/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/01/25  修正内容 : Redmine#2603の対応
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
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.IO;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＢＬコード層別変換処理
    /// </summary>
    /// <remarks>
    /// <br>Note        : ＢＬコード層別変換処理です。<br/>
    /// <br>Programmer  : 呉元嘯<br/>
    /// <br>Date        : 2010/01/11<br/>
    /// <br>Update Note : 2010/01/25 呉元嘯 Redmine#2593の対応</br>
    /// </remarks>
    public partial class PMKHN09280UA : Form
    {
        #region ■ Const Memebers ■
        private const string ct_ClassID = "PMKHN09280UA";
        //掛率パラメータファイル
        private const string INI_FILE_RATE = "PMCV1200.INI";
        //商品パラメータファイル
        private const string INI_FILE_GOODS = "PMCV1100.INI";
        //部位パラメータファイル
        private const string INI_FILE_PARTS = "PMCV1160.INI";
        //優良設定パラメータファイル
        private const string INI_FILE_EXCELLENTSET = "PMCV1180.INI";
        #endregion ■ Const Memebers ■

        # region ■ private field ■

        private ImageList _imageList16 = null;
        // クローズボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        // 実行ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _runButton;
        // ログイン担当者
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        // ＢＬコード層別変換処理インターフェース対象
        private BlCodeLevelChangeAcs _blCodeLevelChangeAcs;
        // ログイン担当者名称
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        // デフォルト行の外観設定
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        # endregion ■ private field ■

        # region ■ Constructor ■
        /// <summary>
        /// ＢＬコード層別変換処理UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＢＬコード層別変換処理UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09280UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._runButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._blCodeLevelChangeAcs = new BlCodeLevelChangeAcs();

        }
        # endregion ■ Constructor ■

        #region  ■ Control Event ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private void PMKHN09280UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // ボタン初期化
            this.ButtonInitialSetting();

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

        }

        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/01/11</br>
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
                        string errMessage = "";
                        Control errComponent = null;
                        // 入力チェック処理
                        if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
                        {
                            // メッセージを表示
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMessage, 0);

                            // コントロールにフォーカスをセット
                            if (errComponent != null)
                            {
                                errComponent.Focus();
                            }
                            return;
                        }
                        // 実行確認メッセージ表示
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "処理を実行しますか？",
                            0,
                            MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // 実行処理
                            this.UpdateProcess();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// INIファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : INIファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/01/11</br>
        /// </remarks>
        private void uButton_IniTextFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "フォルダの参照";
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tEdit_IniTextFileName.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        /// <summary>
        /// Logファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : Logファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/01/11</br>
        /// </remarks>
        private void uButton_LogTextFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "フォルダの参照";
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tEdit_LogTextFileName.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        /// <summary>
        /// パイルのブロードの設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : パイルのブロードの設定を行う。</br> 
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/01/11</br>
        /// </remarks>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                        panel1.ClientRectangle,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid);
        }
        #endregion

        #region  ■ Private Method ■

        /// <summary>エラーメッセージ表示処理</summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <remarks>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                "ＢＬコード層別変換処理",			// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            string iniFileName = this.tEdit_IniTextFileName.DataText.Trim();
            string logFileName = this.tEdit_LogTextFileName.DataText.Trim();
            if (iniFileName == string.Empty)
            {
                errMessage = "INIファイル格納フォルダを入力して下さい。";
                errComponent = this.tEdit_IniTextFileName;
                status = false;
                return status;
            }
            if (!Directory.Exists(iniFileName))
            {
                errMessage = "INIファイル格納フォルダが存在しません。";
                errComponent = this.tEdit_IniTextFileName;
                status = false;
                return status;
            }
            if (Directory.Exists(iniFileName))
            {
                // -----------ADD 2010/01/25----------->>>>>
                //最後に"\"を付加する場合
                if (iniFileName.Substring(iniFileName.Length - 1).Equals("\\"))
                {
                    iniFileName = iniFileName.Remove(iniFileName.Length - 1);
                }
                // -----------ADD 2010/01/25-----------<<<<<
                string[] fileList = Directory.GetFiles(iniFileName);
                string iniFile_Rate = iniFileName + "\\" + INI_FILE_RATE;
                string iniFile_Goods = iniFileName + "\\" + INI_FILE_GOODS;
                string iniFile_Parts = iniFileName + "\\" + INI_FILE_PARTS;
                string iniFile_ExcellentSet = iniFileName + "\\" + INI_FILE_EXCELLENTSET;
                string message = "INIファイルが格納されているか\r\n" + "確認して下さい。\r\n\n" + INI_FILE_GOODS + "\n" + INI_FILE_PARTS + "\n" + INI_FILE_EXCELLENTSET + "\n" + INI_FILE_RATE + "\n";

                ArrayList al = new ArrayList();
                if (fileList == null)
                {
                    errMessage = "INIファイル格納フォルダが存在しません。";
                    errComponent = this.tEdit_IniTextFileName;
                    status = false;
                    return status;
                }
                else
                {
                    foreach (string file in fileList)
                    {
                        al.Add(file);
                    }
                    //フォルダ内に下記ファイルが１つでも不足している場合はエラー
                    if (!al.Contains(iniFile_Rate) || !al.Contains(iniFile_Goods) ||
                        !al.Contains(iniFile_Parts) || !al.Contains(iniFile_ExcellentSet))
                    {
                        errMessage = message;
                        errComponent = this.tEdit_IniTextFileName;
                        status = false;
                        return status;
                    }
                }
            }
            if (logFileName == string.Empty)
            {
                errMessage = "ログファイル格納フォルダを入力して下さい。";
                errComponent = this.tEdit_LogTextFileName;
                status = false;
                return status;
            }
            if (!Directory.Exists(logFileName))
            {
                errMessage = "ログファイル格納フォルダが存在しません。";
                errComponent = this.tEdit_LogTextFileName;
                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// ＢＬコード層別変換処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ＢＬコード層別変換処理を行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private void UpdateProcess()
        {
            // 抽出中画面部品のインスタンスを作成
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "ＢＬコード層別変換処理";
            form.Message = "現在、処理中です。";
            // ダイアログ表示
            form.Show();
            string errMsg = string.Empty;
            // ＢＬコード層別変換処理
            status = this._blCodeLevelChangeAcs.Update(this.tEdit_IniTextFileName.Text, this.tEdit_LogTextFileName.Text, out errMsg);
            // ダイアログを閉じる
            form.Close();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "処理が完了しました。",
                    -1,
                    MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "処理中にエラーが発生しました。(" + status + ")",
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            // 終了ボタン
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 実行ボタン
            this._runButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // ログイン担当者レーベル
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            //INIファイル格納フォルダ
            this.uButton_IniTextFileName.ImageList = this._imageList16;
            this.uButton_IniTextFileName.Appearance.Image = Size16_Index.STAR1;
            //ログファイル格納フォルダ
            this.uButton_LogTextFileName.ImageList = this._imageList16;
            this.uButton_LogTextFileName.Appearance.Image = Size16_Index.STAR1;
        }
        #endregion  ■ Private Method ■
    }
}