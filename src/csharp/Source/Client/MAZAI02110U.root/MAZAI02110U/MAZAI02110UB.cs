//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   :信越自動車商会個別開発テキスト抽出                       //
// プログラム概要   :信越自動車商会個別開発テキスト抽出確認ＵＩクラス         //
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11000606-00  作成担当 : licb                                     //
// 作 成 日  K2014/03/10  修正内容 : 新規作成                                 //
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Common;     
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;

using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// テキスト出力確認ＵＩクラス
    /// </summary>
    /// <br>Note       : テキスト出力時にファイル名・出力タイプを選択する為のＵＩです。</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : K2014/03/10</br>
    /// <br></br>
    public partial class MAZAI02110UB : Form
    {
        
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAZAI02110UB()
        {
            InitializeComponent();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
        }
        #endregion

        #region Public Member

        /// <summary>
        /// 出力ファイルパス
        /// </summary>
        public string _outPutFileName = string.Empty;

        #endregion 

        #region  Private Member

        // クラスID
        private const string ct_ClassID = "MAZAI02110UB";
        // プログラム名称
        private const string ct_PGNAME = "テキスト出力";
        // メッセージ内容
        private const string ct_NOINPUT = "が未入力です。";
        private const string ct_FileAlrdyError = "出力先ファイルが他で使用中です。";
        private const string ct_FilePathError = "指定されたフォルダが存在しません。";
        private const string ct_FileExpendError = "指定されたファイル名は不正です。";
        private const string ct_INPUT_ERROR = "の入力が不正です。";
        private const string CT_FileNameError = "指定されたファイル名は不正です。";
        private const string ct_FILEACCESSERROR = "出力先ファイルへのアクセスが拒否されました。";
        // ファイル濾過
        private const string ct_TxtFilter = "CSV(*.CSV)|*.CSV|テキスト(*.TXT)|*.TXT|その他(*.*)|*.*";

        #endregion

        #region イベント

        /// <summary>
        /// 画面起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU04004UB_Load( object sender, EventArgs e )
        {  
            // ボタン設定
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
        }
   
        /// <summary>
        /// 設定ＵＩ初期表示イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU04004UA_Show( object sender, EventArgs e )
        {  
            // 前回表示状態が保存されていれば上書き
            this.uiMemInput1.OptionCode = "3";
            this.uiMemInput1.ReadMemInput();

            tEdit_SettingFileName.Focus();
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note	   : フォーカスを制御</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (!e.ShiftKey)
            {
                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                {
                    if (e.NextCtrl == uButton_FileSelect)
                    {
                        e.NextCtrl = uButton_OK;
                    }
                }
            }
            else
            {
                if (e.PrevCtrl == uButton_OK)
                {
                    if (e.NextCtrl == uButton_FileSelect)
                    {
                        e.NextCtrl = tEdit_SettingFileName;
                    }
                }
            }
        }
        /// <summary>
        /// ＵＩ入力保存コンポーネントの保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ＵＩ入力保存コンポーネントの保存処理を行う。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        public void WriteMemInput()
        {
            this.uiMemInput1.WriteMemInput();
        }
        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();
            saveCtrAry.Add(this.tEdit_SettingFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
            this.uiMemInput1.WriteOnClose = false;
        }
        #endregion

       
        #endregion 

        #region ボタン

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note	   : キャンセルボタン</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : OKボタン</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            string errMessage = "";
            Control errComponent = null;
            //出力前にチェック処理を行う
            if (this.ExportCheck(ref errMessage, ref errComponent))
            {

                //ファイル存在チェック
                if (File.Exists(this.tEdit_SettingFileName.Text.Trim()))
                {
                    string strMessage = "現在のファイルは破棄されます。よろしいですか？";

                    DialogResult dialogResult;
                    // メッセージを表示
                    dialogResult = TMsgDisp.Show(
                     emErrorLevel.ERR_LEVEL_QUESTION, 	// エラーレベル
                     ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                     ct_PGNAME,					    // プログラム名称
                     "", 								// 処理名称
                     "",									// オペレーション
                     strMessage,							// 表示するメッセージ
                     0, 							// ステータス値
                     null, 								// エラーが発生したオブジェクト
                     MessageBoxButtons.OKCancel, 				// 表示するボタン
                     MessageBoxDefaultButton.Button1);	// 初期表示ボタン  

                    if (dialogResult == DialogResult.Cancel)
                    {
                        this.tEdit_SettingFileName.Focus();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;

                        _outPutFileName = this.tEdit_SettingFileName.Text.ToString();

                        // 終了
                        this.Close();
                    }

                }
                else
                {

                    this.DialogResult = DialogResult.OK;

                    _outPutFileName = this.tEdit_SettingFileName.Text.ToString();

                    // 終了
                    this.Close();
                }
            }
            else
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }
            }
 
        }

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 入力項目の初期化を行う</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 初期フォーカスセット
            this.tEdit_SettingFileName.Focus();

        }
        #endregion ◎ 画面初期化処理

        /// <summary>
        /// 前回の表示状態用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 前回の表示状態用</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void MAZAI02110UB_VisibleChanged(object sender, EventArgs e)
        {
            // コントロール初期化
            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
        }
        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : 入力ファイル名ボタンをクリックした時に発生します</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    UltraButton btn = sender as UltraButton;
                    // タイトルバーの文字列
                    openFileDialog.RestoreDirectory = true;
                    string fileNm = string.Empty;

                    openFileDialog.Title = "出力ファイルを開く";
                    openFileDialog.CheckFileExists = false;
                    // ﾃｷｽﾄﾌｧｲﾙ名
                    fileNm = this.tEdit_SettingFileName.Text.Trim();
                    //「ファイルの種類」を指定
                    openFileDialog.Filter = ct_TxtFilter;
                    try
                    {
                        if (string.IsNullOrEmpty(fileNm))
                        {
                            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                            openFileDialog.FileName = System.IO.Path.GetFileName(fileNm);
                        }
                        else
                        {
                            openFileDialog.FileName = System.IO.Path.GetFileName(fileNm);
                            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(fileNm);
                        }

                        // 選択したファイル名を画面に設定している
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                         this.tEdit_SettingFileName.Text = openFileDialog.FileName;

                         _outPutFileName = this.tEdit_SettingFileName.Text;

                        }
                    }
                    catch
                    {
                        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            this.tEdit_SettingFileName.Text = openFileDialog.FileName;

                            _outPutFileName = this.tEdit_SettingFileName.Text;
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion // ボタン

        #region 出力前にチェックを行う
        /// <summary>
        /// 抽出前確認処理
        /// </summary>
        /// <param name="errComponent">エラーメッセージ</param>
        /// <param name="errMessage">エラー発生コンポーネント</param>
        /// <returns>0:エラーない</returns>
        /// <remarks>
        /// <br>Note	   : 抽出前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private bool ExportCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // 出力ファイル名 
            if (string.IsNullOrEmpty(tEdit_SettingFileName.Text.Trim()))
            {
                errMessage = "出力ファイル名" + ct_NOINPUT;
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            // 出力ファイル名に使用禁止文字混在の場合
            if (this.tEdit_SettingFileName.DataText.Trim().Length > 3)
            {
                if (!FileNameCheck(this.tEdit_SettingFileName.DataText.Trim().Substring(3)))
                {
                    errMessage = string.Format("{0}", CT_FileNameError);
                    errComponent = this.tEdit_SettingFileName;
                    status = false;
                    return status;
                }
            }

            // パス存在チェック
            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(this.tEdit_SettingFileName.Text.Trim())))
                {
                    errMessage = ct_FilePathError;
                    errComponent = this.tEdit_SettingFileName;
                    status = false;
                    return status;
                }
            }
            catch
            {
                errMessage = string.Format("{0}", ct_FilePathError);
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            // 出力ファイル名 ﾌｧｲﾙ存在チェック
            if (this.tEdit_SettingFileName.DataText.ToString().Trim().EndsWith("\\") || (!IsFileNameRight(this.tEdit_SettingFileName.DataText.ToString().Trim())))
            {
                errMessage = string.Format("{0}", ct_FileExpendError);
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            // ファイル排他チェック ﾃｷｽﾄﾌｧｲﾙ名
            if (IsFileLocked(this.tEdit_SettingFileName.Text.Trim()) == 1)
            {
                errMessage = ct_FileAlrdyError;
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }
            else if (IsFileLocked(this.tEdit_SettingFileName.Text.Trim()) == 2 || IsFileLocked(this.tEdit_SettingFileName.Text.Trim()) == 3)
            {
                errMessage = ct_FILEACCESSERROR;
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            return status;

        }

        /// <summary>
        /// 拡張子が設定をチェックしている
        /// </summary>
        /// <param name="fileName">ファイル名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 拡張子が設定をチェックしている</br>
        /// <br>Programmer : licb</br>
        /// <br>Date	   : K2014/03/10</br>
        /// </remarks>
        private bool IsFileNameRight(string fileName)
        {
            if (fileName.Length > 0)
            {
                int index = fileName.LastIndexOf("\\");
                string strName = fileName.Substring(index, fileName.Length - index);
                int pointIndex = -1;
                if (strName.Length > 0)
                {
                    pointIndex = strName.IndexOf(".");
                }
                if (pointIndex != -1)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
 
        }

        /// <summary>
        /// 指定したファイルは使用するかどうかをチェックしている
        /// </summary>
        /// <param name="fileNm">ファイル名</param>
        /// <remarks>
        /// <br>Note       : 指定ファイルは使用中しているかどうかをチェックしている</br>
        /// <br>Programmer : licb</br>
        /// <br>Date	   : K2014/03/10</br>
        /// </remarks>
        private int IsFileLocked(string fileNm)
        {
            FileStream stream = null;

            // ﾌｧｲﾙが存在しない場合、ﾃｷｽﾄ出力時に作成している
            if (!File.Exists(fileNm))
                return (int)FileLocked_Status.FileLocked_NORMAL;

            try
            {
                stream = File.Open(fileNm, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return (int)FileLocked_Status.FileLocked_LOCKED;

            }
            catch (UnauthorizedAccessException)
            {
                return (int)FileLocked_Status.FileLocked_CANNOTACCESS;
            }
            catch (Exception)
            {
                return (int)FileLocked_Status.FileLocked_EOF;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return (int)FileLocked_Status.FileLocked_NORMAL;

        }
        /// <summary>
        /// ファイルは使用フラグ
        /// </summary>
        private enum FileLocked_Status
        {
            //ファイルは使用できる
            FileLocked_NORMAL = 0,
            //ファイルが他で使用中です
            FileLocked_LOCKED = 1,
            //ファイルがアクセスできない。
            FileLocked_CANNOTACCESS = 2,
            //その他エラー
            FileLocked_EOF = 3,
        }

        /// <summary>
        /// パスに無効な文字チェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : パスに無効な文字チェック</br>                  
        /// <br>Programmer  : licb</br>                                    
        /// <br>Date        : K2014/03/10</br> 
        /// </remarks>
        private bool FileNameCheck(string str)
        {
            int temp = str.LastIndexOf("\\");
            if (temp == str.Length)
            {
                return true;
            }
            string strtemp = str.Substring(temp + 1);
            if (strtemp.LastIndexOf(".") != strtemp.IndexOf("."))
            {
                return false;
            }
            if (str.Contains("/") || str.Contains(":") || str.Contains("*") || str.Contains("?") || str.Contains("\"") || str.Contains("<") || str.Contains(">") || str.Contains("|")
                || str.Contains(";"))
            {
                return false;
            }
            int tempNo = 0;
            // 拡張子
            string extension = System.IO.Path.GetExtension(str).ToLower();
            // 拡張子は「txt」場合
            if (string.IsNullOrEmpty(extension))
            {
                tempNo = str.LastIndexOf("\\");
                str = str.Substring(tempNo + 1);
                if (str.Equals(".") || str.Equals(".."))
                {
                    return false;
                }

            }
            return true;
        }


        #endregion

        #region  エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
                TMsgDisp.Show(
                      iLevel, 							// エラーレベル
                      ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                      ct_PGNAME,					    // プログラム名称
                      "", 								// 処理名称
                      "",									// オペレーション
                      message,							// 表示するメッセージ
                      status, 							// ステータス値
                      null, 								// エラーが発生したオブジェクト
                      MessageBoxButtons.OK, 				// 表示するボタン
                      MessageBoxDefaultButton.Button1);	// 初期表示ボタン  
        }
        #endregion  エラーメッセージ表示処理

    }
}