//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : テキスト出力確認画面
// プログラム概要   : テキスト出力確認画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11202046-00   作成担当 : 時シン
// 作 成 日 : K2016/10/28   修正内容 : 神姫産業㈱ テキスト出力機能追加対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// テキスト出力確認画面のフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : テキスト出力確認画面のフォームクラス</br>
    /// <br>Programmer   : 時シン</br>
    /// <br>Date         : K2016/10/28</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09122UC : Form
    {
        #region 常数
        // クラス名
        private const string CT_PRINTNAME = "テキスト出力確認";
        private const string CT_PGID = "PMKHN09122UC";

        //エラー条件メッセージ
        private const string CT_NOINPUT = "を入力して下さい。";
        private const string CT_FILEALRDYERROR = "出力先ファイルが他で使用中です。";
        private const string CT_FILEPATHERROR = "指定されたフォルダが存在しません。";
        private const string CT_FILEEXPENDERROR = "指定されたファイル名は不正です。";
        private const string CT_FILEACCESSERROR = "出力先ファイルへのアクセスが拒否されました。";
        private const string CT_FILENAMEERROR = "パスに無効な文字が含まれています。";
        private const string CT_TXTFILTER_CSV = "CSV(*.CSV)|*.CSV|TXT(*.TXT)|*.TXT|その他(*.*)|*.*";
        private const string CT_TXTFILTER_TXT = "TXT(*.TXT)|*.TXT|CSV(*.CSV)|*.CSV|その他(*.*)|*.*";

        private const string TXTSTR = ".txt";
        private const string CSVSTR = ".csv";
        #endregion

        #region 子フォーム
        // 子フォーム対象
        ISecurityManagementForm SubForm;

        /// <summary>
        /// 子フォーム
        /// </summary>
        public ISecurityManagementForm GetSubForm
        {
            set { this.SubForm = value; }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// テキスト出力確認画面フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力確認画面フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        public PMKHN09122UC()
        {
            InitializeComponent();

            // 画面に項目値を覚える
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tEdit_TextOutpuPath);
            ctrlList.Add(this.tComboEditor_FileFormat);
            this.uiMemInput1.TargetControls = ctrlList;

            // ボタンアイコン設定
            this.SetGuidButtonIcon();

            // ファイル形式
            this.tComboEditor_FileFormat.SelectedIndex = 0;
        }

        /// <summary>
        /// コンストラクタ　Nunit用
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : テキスト出力確認画面フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        public PMKHN09122UC(string param)
        {
            try
            {
                if (("NUnit").Equals(param))
                {
                    // 初期化
                    InitializeComponent();
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 初期化
        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_FileSelect.ImageList = IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1; // チェックリスト出力先ガイド
        }
        #endregion

        #region Private Method
        /// <summary>
        /// チェックリスト出力先ガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        :チェックリスト出力先ガイドクリック</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // タイトルバーの文字列
                saveFileDialog.Title = "出力ファイル選択";
                saveFileDialog.RestoreDirectory = true;

                try
                {
                    if (string.IsNullOrEmpty(this.tEdit_TextOutpuPath.Text.Trim()))
                    {
                        saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    }
                    else
                    {
                        saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextOutpuPath.Text);
                        saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextOutpuPath.Text);
                    }
                }
                catch
                {
                    // 処理なし
                }
                finally
                {
                    if (string.IsNullOrEmpty(saveFileDialog.InitialDirectory))
                    {
                        saveFileDialog.FileName = string.Empty;
                        saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    }
                }

                //「ファイルの種類」を指定
                if ((Int32)this.tComboEditor_FileFormat.Value == 0)
                {
                    saveFileDialog.Filter = CT_TXTFILTER_CSV;
                }
                else
                {
                    saveFileDialog.Filter = CT_TXTFILTER_TXT;
                }
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextOutpuPath.DataText = saveFileDialog.FileName;
                }
                else
                {
                    // なし
                }
            }
            this.uButton_FileSelect.Focus();
        }
        
        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : テキスト出力処理</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void uButton_TextOut_Click(object sender, EventArgs e)
        {
            string errMessage = "";
            Control errComponent = null;

            // ファイルチェック処理
            if (!this.FileCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                return;
            }

            //　拡張子取得
            if (this.tEdit_TextOutpuPath.DataText.Trim().Length > 3)
            {
                // 拡張子
                string extension = System.IO.Path.GetExtension(this.tEdit_TextOutpuPath.DataText.Trim().Substring(3)).ToLower();

                // ファイル形式は「csv」場合
                if (this.tComboEditor_FileFormat.SelectedIndex == 0)
                {
                    // 拡張子は「csv」以外の場合
                    if (!CSVSTR.Equals(extension.ToLower()))
                    {
                        this.tEdit_TextOutpuPath.DataText = this.tEdit_TextOutpuPath.DataText.Trim() + CSVSTR;
                    }
                }
                // ファイル形式は「txt」場合
                else
                {
                    // 拡張子は「txt」以外の場合
                    if (!TXTSTR.Equals(extension.ToLower()))
                    {
                        this.tEdit_TextOutpuPath.DataText = this.tEdit_TextOutpuPath.DataText.Trim() + TXTSTR;
                    }
                }
            }

            bool fileCheckFlag;

            int status = (this.SubForm as IDoTextOutForm).DoTextOut(this.tEdit_TextOutpuPath.Text, this.tComboEditor_FileFormat.SelectedIndex, out fileCheckFlag, out errMessage);

            // ファイル排他チェック
            if (fileCheckFlag)
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                return;
            }

            emErrorLevel errLevel = emErrorLevel.ERR_LEVEL_INFO;
            switch (status)
            {
                // 処理成功
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;
                    errMessage = "テキスト出力処理を終了しました。";
                    break;
                // 出力対象データがない場合
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;
                    errMessage = "該当データが存在しません。";
                    break;
                // 異常が発生する場合
                default:
                    errLevel = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                    break;
            }

            // エラーが発生する場合
            if (!string.IsNullOrEmpty(errMessage))
            {
                MsgDispProc(errLevel
                            , errMessage
                            , status
                            , MessageBoxButtons.OK
                            , MessageBoxDefaultButton.Button1);
            }

            this.Close();
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージ表示処理を行い</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string message, int status, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel
                                , this.Name
                                , message
                                , status
                                , iButton
                                , iDefButton);
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージ表示処理を行い</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,                             // エラーレベル
                CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                CT_PRINTNAME,                       // プログラム名称
                "",                                 // 処理名称
                "",                                 // オペレーション
                message,                            // 表示するメッセージ
                status,                             // ステータス値
                null,                               // エラーが発生したオブジェクト
                MessageBoxButtons.OK,               // 表示するボタン
                MessageBoxDefaultButton.Button1);   // 初期表示ボタン
        }

        /// <summary>
        /// ファイルチェック処理を行う
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラーコントロール</param>
        /// <remarks>
        /// <br>Note       : ファイルチェック処理を行う</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool FileCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // 必須入力チェック
            // message: テキストファイル名を入力して下さい。
            if (string.IsNullOrEmpty(this.tEdit_TextOutpuPath.Text.Trim()))
            {
                errMessage = string.Format("ファイル名" + "{0}", CT_NOINPUT);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // バス存在チェック___ﾌｧｲﾙ存在チェック
            // message: 指定されたファイル名は不正です。
            if (this.tEdit_TextOutpuPath.DataText.ToString().Trim().EndsWith("\\"))
            {
                errMessage = string.Format("{0}", CT_FILEEXPENDERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // ファイル名に使用禁止文字混在チェック
            // message: パスに無効な文字が含まれています。
            if (this.tEdit_TextOutpuPath.DataText.Trim().Length > 3)
            {
                if (!FileNameCheck(this.tEdit_TextOutpuPath.DataText.Trim().Substring(3)))
                {
                    errMessage = string.Format("{0}", CT_FILENAMEERROR);
                    errComponent = this.tEdit_TextOutpuPath;
                    status = false;
                    return status;
                }
            }

            // バス存在チェック
            try
            {
                // message: 指定されたフォルダが存在しません。
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(this.tEdit_TextOutpuPath.Text.Trim())))
                {
                    errMessage = string.Format("{0}", CT_FILEPATHERROR);
                    errComponent = this.tEdit_TextOutpuPath;
                    status = false;
                    return status;
                }
            }
            catch
            {
                // 指定されたフォルダが存在しません。
                errMessage = string.Format("{0}", CT_FILEPATHERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // ファイル排他チェック
            // message: 指定されたファイルが他で使用中です。
            if (PMKHN09140UA.IsFileLocked(this.tEdit_TextOutpuPath.Text.Trim()) == 1)
            {
                errMessage = string.Format("{0}", CT_FILEALRDYERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // message: 出力先ファイルへのアクセスが拒否されました。
            else if (PMKHN09140UA.IsFileLocked(this.tEdit_TextOutpuPath.Text.Trim()) == 2 || PMKHN09140UA.IsFileLocked(this.tEdit_TextOutpuPath.Text.Trim()) == 3)
            {
                errMessage = string.Format("{0}", CT_FILEACCESSERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// パスに無効な文字チェック処理                                              
        /// </summary>
        /// <param name="str">メッセージ</param>
        /// <remarks>
        /// <br>Note　　　 : パスに無効な文字チェック</br>                  
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool FileNameCheck(string str)
        {
            try
            {
                int temp = str.LastIndexOf("\\");
                if (temp == str.Length)
                {
                    return true;
                }

                if (str.Contains("/") || str.Contains(":") || str.Contains("*") || str.Contains("?") ||
                    str.Contains("\"") || str.Contains("<") || str.Contains(">") || str.Contains("|")
                    || str.Contains(";"))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 設定画面のキャンセル処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 設定画面のキャンセル処理</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            // 画面を閉める
            this.Close();
        }
        #endregion
    }
}