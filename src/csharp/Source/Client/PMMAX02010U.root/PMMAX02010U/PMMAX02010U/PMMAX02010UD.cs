//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新 設定画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/16   修正内容 : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    public partial class PMMAX02010UD : Form
    {
        #region private Member
        // 企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _loginSectionCode;

        // 共通クラス
        PMMAX02000UC _pMMAX02000UC;
        PMMAX02010UC _pMMAX02010UC;
        // ユーザーIDとパースワード保存用
        private DataSet menuDataSet = null;
        // ガイドのIcon
        private ImageList _imageList16 = null;
        // チェックリスト出力先パース
        private string _outPutPath = string.Empty;
        // 保存するかどうかフラグ
        private bool _didSave = false;

        private string _changeBefOutpuPath = "";// 変更前チェックリスト出力先 // Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応
        #endregion

        #region CONST
        // クラス名
        private const string ct_PRINTNAME = "出品一括更新";
        private const string CT_PGID = "PMMAX02010UD";
        /// <summary>
        /// チェックリスト出力先
        /// </summary>
        public const string CHECKL_FILE_PATH = @"CSV\";
        #endregion

        #region Public Property
        /// <summary>
        /// チェックリスト出力先パース
        /// </summary>
        public string OutPutPath
        {
            get { return this._outPutPath; }
        }
        #endregion Public Property

        #region コンストラクタ
        /// <summary>
        /// 設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public PMMAX02010UD()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            // 共通クラス
            _pMMAX02000UC = new PMMAX02000UC();
            _pMMAX02010UC = new PMMAX02010UC();

            // 企業コード
            this._enterpriseCode = _pMMAX02000UC.EnterpriseCode;
            // ログイン拠点コード
            this._loginSectionCode = _pMMAX02000UC.LoginSectionCode;

            // ボタンアイコン設定
            this.SetGuidButtonIcon();
        }

        /// <summary>
        /// コンストラクタ　Nunit用
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : 出品・在庫一括更新フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public PMMAX02010UD(string param)
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

        #region Public Method
        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public void InitialScreenData()
        {
            this.tEdit_ChecklistOutpuPath.Focus();

            // チェックリスト出力先の表示処理
            this.CheckFilePathShow();
            // ユーザー情報の表示処理
            this.UserInfoShow();
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
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_ChecklistOutpuPath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_FileSelect.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // チェックリスト出力先ガイド
        }
        
        /// <summary>
        /// チェックリスト出力先の表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : チェックリスト出力先の表示処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/16</br>
        /// <br>           : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応</br>
        /// </remarks>
        private void CheckFilePathShow()
        {
            // 保存ボタンーを押した場合、メモリーにのチェックリスト出力先と出荷日付範囲を使用し、画面に表示する
            if (_didSave)
            {
                // チェックリスト出力先
                this.tEdit_ChecklistOutpuPath.Text = this._outPutPath;
                _changeBefOutpuPath = this.tEdit_ChecklistOutpuPath.Text; // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応
                return;
            }
            // XMLファイルを読み込む
            _pMMAX02010UC.Deserialize();
            ExportSalesData exportSalesDataList = _pMMAX02010UC.ExportSalesDataList;
            // チェックリスト出力先
            string checkFilePath = string.Empty;
            foreach (ExportSalesFormSaveItems saveItems in exportSalesDataList.ExportSalesDataList)
            {
                if (saveItems.EnterPriseCode == this._enterpriseCode && saveItems.LoginSectionCode == this._loginSectionCode)
                {
                    // チェックリスト出力先の設定
                    checkFilePath = saveItems.CheckFilePath;
                    break;
                }
            }
            // XMLファイルにユーザー情報がある場合
            if (!string.IsNullOrEmpty(checkFilePath))
            {
                this.tEdit_ChecklistOutpuPath.Text = checkFilePath;
            }
            // XMLファイルにユーザー情報がない場合
            else
            {
                this.tEdit_ChecklistOutpuPath.Text = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.PRTOUT, CHECKL_FILE_PATH));
            }

            _changeBefOutpuPath = this.tEdit_ChecklistOutpuPath.Text; // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応
        }

        /// <summary>
        /// ユーザー情報の表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー情報の表示処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void UserInfoShow()
        {
            // ユーザー情報
            string userID;
            string userPassWord;
            bool userExistFlag = false;
            // DATファイルから、ユーザー情報を取得する
            _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
            // 該当するユーザーを設定した場合
            if (userExistFlag)
            {
                // DATファイルにのIDとパースワードを使用し、表示する
                this.tEdit_LoginID.Text = userID.Trim();
                this.tEdit_Password.Text = userPassWord.Trim();
            }
            // 該当するユーザーを設定しない場合
            else
            {
                this.tEdit_LoginID.Text = string.Empty;
                this.tEdit_Password.Text = string.Empty;
            }
        }

        /// <summary>
        /// 設定画面の保存処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 設定画面の保存処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/16</br>
        /// <br>           : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            // 画面項目のチェック
            bool checkFlag = MuneItemsCheck(this.tEdit_ChecklistOutpuPath.Text.Trim());
            // チェックリスト保存先は存在しないか、書込み権限がない場合
            if (!checkFlag)
            {
                // DATファイルの保存(ログインIDとパスワード)
                this.DatFileSave();

                // チェックリスト出力先パース
                this._outPutPath = this.tEdit_ChecklistOutpuPath.Text.Trim();
                _didSave = true;

                this.DialogResult = DialogResult.OK;
                // 画面を閉める
                this.Close();
            }
            else
            {
                this.tEdit_ChecklistOutpuPath.Text = _changeBefOutpuPath; // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応
                this.tEdit_ChecklistOutpuPath.Focus();
                return;
            }
        }

        /// <summary>
        /// 設定画面のチェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 設定画面のチェック処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/16</br>
        /// <br>           : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応</br>
        /// </remarks>
        private bool MuneItemsCheck(string filePath)
        {
            bool errorFlag = false;

            try
            {
                // パースが存在しない場合
                // UPD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ---->>>>>
                // if (!Directory.Exists(filePath)) 
                if (!Directory.Exists(filePath) || !PMMAX02010UD.CheckDirectoryAccess(filePath))
                // UPD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ----<<<<<
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, ct_PRINTNAME, "", "", PMMAX02010UE.M_007, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    errorFlag = true;
                }
            }
            catch
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, ct_PRINTNAME, "", "", PMMAX02010UE.M_007, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errorFlag = true;
            }
            return errorFlag;
        }

        // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ---->>>>>
        /// <summary>
        /// チェックリスト出力先に書き込む権限チェック
        /// </summary>
        /// <param name="directory">チェックリスト出力先パス</param>
        /// <returns>フラグ: true: 書き込む権限ある   false:書き込む権限なし</returns>
        /// <remarks>
        /// <br>Note       :  チェックリスト出力先に書き込む権限チェック処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/02/16</br>
        /// </remarks>
        public static bool CheckDirectoryAccess(string directory)
        {
            string tempFile = "\\" + DateTime.Now.Ticks.ToString() + ".tmp";
            bool success = false;
            string fullPath = directory + tempFile;

            if (Directory.Exists(directory))
            {
                try
                {
                    using (FileStream fs = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        fs.WriteByte(0xff);
                    }

                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                        success = true;
                    }
                }
                catch (Exception)
                {
                    success = false;
                }
            }

            return success;
        }
        // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ----<<<<<

        /// <summary>
        /// ユーザー情報の保存
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー情報の保存の保存</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void DatFileSave()
        {
            // ユーザー情報
            string userID;
            string userPassWord;
            bool userExistFlag = false;
            // DATファイルから、ユーザー情報を取得する
            this.menuDataSet = _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
            // ユーザー情報を新規登録する
            if (!userExistFlag)
            {
                // ユーザー情報保存用DateTableの作成
                _pMMAX02000UC.CreatUserDateTable(ref this.menuDataSet, this.tEdit_LoginID.Text.Trim(), this.tEdit_Password.Text.Trim());
            }
            // ユーザー情報更新
            else
            {
                _pMMAX02000UC.ReSetDateTable(ref this.menuDataSet, this.tEdit_LoginID.Text.Trim(), this.tEdit_Password.Text.Trim());
            }
            _pMMAX02000UC.SetDateToDat(this.menuDataSet);
        }

        /// <summary>
        /// 設定画面のキャンセル処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 設定画面のキャンセル処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            // 画面を閉める
            this.Close();
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                #region [チェックリスト出力先]
                case "tEdit_ChecklistOutpuPath":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // キャンセルボタン
                                        e.NextCtrl = uButton_Cancel;
                                    }
                                    break;
                            }
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_ChecklistOutpuPath.Text.Trim()))
                                        {
                                            // チェックリスト出力先ガイド
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                        else
                                        {
                                            // ログインID
                                            e.NextCtrl = tEdit_LoginID;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_FileSelect":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                case Keys.Down:
                                    {
                                        // ログインID
                                        e.NextCtrl = tEdit_LoginID;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [ログインID]
                case "tEdit_LoginID":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // ガイド
                                        e.NextCtrl = uButton_FileSelect;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [パスワード]
                case "tEdit_Password":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                case Keys.Down:
                                    {
                                        // 保存ボタン
                                        e.NextCtrl = uButton_Save;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [保存ボタン]
                case "uButton_Save":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // パスワード
                                        e.NextCtrl = tEdit_Password;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [キャンセルボタン]
                case "uButton_Cancel":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // パスワード
                                        e.NextCtrl = tEdit_ChecklistOutpuPath;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        #endregion
    }
}