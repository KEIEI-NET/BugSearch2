//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 商品バーコード一括登録                                  //
// プログラム概要   : 商品バーコード一括登録 テキスト出力確認UIクラス         //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊                                 //
// 作 成 日  2017/06/12  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード一括登録 テキスト出力確認UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品バーコード一括登録 テキスト出力確認UIクラス</br>
    /// <br>Programmer  : 3H 張小磊</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
    public partial class PMHND09210UC : Form
    {
        # region private field
        /// <summary>ユーザー設定</summary>
        private GoodsBarCodeRevnExtractTextUserConst _userSetting;
        #endregion

        #region Const Memebers
        /// <summary>設定XMLファイル名</summary>
        private const string ct_XML_FILE_NAME = "PMHND09210UC_Construction.XML";
        #endregion

        #region ユーザー設定情報複製処理
        /// <summary>
        /// テキスト出力ユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>テキスト出力ユーザー設定情報クラス</returns>
        public GoodsBarCodeRevnExtractTextUserConst UserSetting
        {
            get { return this._userSetting; }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public PMHND09210UC()
        {
            InitializeComponent();
            // テキスト出力ユーザー設定情報
            this._userSetting = new GoodsBarCodeRevnExtractTextUserConst();
        }
        #endregion

        #region ユーザー設定の保存・読み込み
        /// <summary>
        /// 商品バーコード一括登録ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品バーコード一括登録ユーザー設定シリアライズ処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // ユーザー設定の保存
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// 商品バーコード一括登録用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品バーコード一括登録用ユーザー設定デシリアライズ処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME)))
            {
                try
                {
                    // ユーザー設定の読み込み
                    this._userSetting = UserSettingController.DeserializeUserSetting<GoodsBarCodeRevnExtractTextUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new GoodsBarCodeRevnExtractTextUserConst();
                }
            }
        }
        #endregion

        #region 画面イベント
        /// <summary>
        /// 画面起動時処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面起動時処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UC_Load(object sender, EventArgs e)
        {
            // 商品バーコード一括登録用ユーザー設定デシリアライズ処理
            this.Deserialize();
            // ユーザー設定情報 ⇒ 画面
            SetUserSettingToScreen();
        }

        /// <summary>
        /// 設定ＵＩ初期表示イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 設定ＵＩ初期表示イベント処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UC_Shown(object sender, EventArgs e)
        {
            tEdit_TextFileName.Focus();
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br></br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ テキスト
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // テキスト→  キャンセル
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // キャンセル→  ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ キャンセル
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // キャンセル→  テキスト
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // テキスト→  ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
        }

        /// <summary>
        /// ファイル名変更された時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ファイル名変更された時発生します。</br> 
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            // ファイルパス+ファイル名
            this.uLabel_FileFullName.Text = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\") + this.tEdit_TextFileName.Text.Trim();
        }

        #endregion

        #region ボタンイベント
        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : キャンセルボタン。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
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
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : OKボタン。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // チェック
            if (!TextFileNameCheck())
            {
                return;
            }

            this.DialogResult = DialogResult.OK;
            // 画面 ⇒ ユーザー設定情報
            GetUserSettingFromScreen();
            // _userSettingは書き変わっているので設定XML更新
            this.Serialize();
            // 終了
            this.Close();
        }
        #endregion // ボタン

        #region 一般イベント

        /// <summary>
        /// ユーザー設定情報 ⇒ 画面
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー設定情報を画面にセット。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetUserSettingToScreen()
        {
            // ファイル名
            this.tEdit_TextFileName.Text = this._userSetting.OutputFileName;
            // ファイルパス+ファイル名
            this.uLabel_FileFullName.Text = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\") + this._userSetting.OutputFileName;
        }

        /// <summary>
        /// 画面 ⇒ ユーザー設定情報
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面でユーザー設定情報を取る。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetUserSettingFromScreen()
        {
            // ファイル名
            this._userSetting.OutputFileName = this.tEdit_TextFileName.Text.Trim();
            // ファイルパス
            this._userSetting.OutputFilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\");
        }

        /// <summary>
        /// ファイル名入力値チェック
        /// </summary>
        /// <returns>true:チェックOK false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : ファイル名入力値チェック。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool TextFileNameCheck()
        {
            string textFileName = this.tEdit_TextFileName.Text.Trim();
            // ファイル名未指定
            if (String.IsNullOrEmpty(textFileName))
            {
                // ファイル名が指定されていないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "出力ファイル名が指定されていません。", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // ファイル名無効
            if (textFileName.Contains("/") || textFileName.Contains(":") || textFileName.Contains("*") || textFileName.Contains("?") ||
                textFileName.Contains(@"\") || textFileName.Contains("<") || textFileName.Contains(">") || textFileName.Contains("|")
                || textFileName.Contains(";"))
            {
                // ファイル名が指定されていないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "出力ファイル名に無効な文字が含まれています。", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // フルファイル名
            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\") + textFileName;

            // ファイルが使用中チェック
            if (IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_LOCKED)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "出力ファイルが他で使用中です。", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // ファイルのアクセスチェック
            if (IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_CANNOTACCESS ||
                IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_EOF)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "出力ファイルへのアクセスが拒否されました。", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 指定したフルファイルは使用するかどうかをチェックしている
        /// </summary>
        /// <param name="fullFileName">フルファイル名</param>
        /// <returns>0:使用できる 1:他で使用中 2:アクセスできない 3その他エラー</returns>
        /// <remarks>
        /// <br>Note       : 指定したフルファイルは使用するかどうかをチェックしている。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int IsFileLocked(string fullFileName)
        {
            FileStream stream = null;

            // ファイルが存在しない場合、テキスト出力時に作成している
            if (!File.Exists(fullFileName))
                return (int)FileLocked_Status.FileLocked_NORMAL;

            try
            {
                // ファイルがOpen
                stream = File.Open(fullFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                // ファイルが他で使用中です
                return (int)FileLocked_Status.FileLocked_LOCKED;

            }
            catch (UnauthorizedAccessException)
            {
                // ファイルがアクセスできない。
                return (int)FileLocked_Status.FileLocked_CANNOTACCESS;
            }
            catch (Exception)
            {
                // その他エラー
                return (int)FileLocked_Status.FileLocked_EOF;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return (int)FileLocked_Status.FileLocked_NORMAL;
        }

        #endregion

        #region ■列挙体
        /// <summary>
        /// ファイルは使用フラグ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ファイルは使用フラグ</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
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
        #endregion

    }

    /// <summary>
    /// 商品バーコード一括登録用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード一括登録のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    [Serializable]
    public class GoodsBarCodeRevnExtractTextUserConst
    {
        #region プライベート変数
        // 出力パス
        private string _outputFilePath;
        // 出力ファイル名
        private string _outputFileName;
        #endregion

        #region プロパティ
        /// <summary>出力パス</summary>
        public string OutputFilePath
        {
            get { return _outputFilePath; }
            set { _outputFilePath = value; }
        }

        /// <summary>出力ファイル名</summary>
        public string OutputFileName
        {
            get { return _outputFileName; }
            set { _outputFileName = value; }
        }
        #endregion
    }
}