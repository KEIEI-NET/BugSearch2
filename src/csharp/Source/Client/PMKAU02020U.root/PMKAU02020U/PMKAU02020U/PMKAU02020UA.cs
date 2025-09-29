//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 電子帳簿連携設定
// プログラム概要   : 電子帳簿連携設定
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00 作成担当 : 3H 尹安
// 作 成 日  2022/03/25  新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using System.IO;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 電子帳簿連携設定
    /// </summary>
    /// <remarks>
    /// <br>Note        : 電子帳簿連携設定を行います。</br>
    /// <br>Programmer	: 3H 尹安</br>
    /// <br>Date		: 2022/03/25</br>  
    /// </remarks>
    public partial class PMKAU02020UA : Form
    {
        # region Private Constant
        // プログラムID
        private const string ct_PGID = "PMKAU02020U";
        # endregion

        # region Private Members
        private EbooksLinkSetAcs _ebooksLinkSetAcs;
        #endregion

        #region Constractor
        /// <summary>
        /// 電子帳簿連携設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 電子帳簿連携設定の新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 3H 尹安</br>
        /// <br>Date		: 2022/03/25</br>
        /// </remarks>
        public PMKAU02020UA()
        {
            InitializeComponent();

            if (_ebooksLinkSetAcs == null)
                _ebooksLinkSetAcs = new EbooksLinkSetAcs();
        }
        # endregion

        #region Private Methods
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、初期設定処理を行います。</br>
        /// <br>Programmer	: 3H 尹安</br>
        /// <br>Date		: 2022/03/25</br>
        /// </remarks> 
        private void InitilSetting()
        {
            // ボタンのイメージ設定
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.OK_Button.ImageList = imageList24;
            this.OK_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;


            // ガイドボタンのイメージ設定
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.EBooksFolderGuide_ultraButton.ImageList = imageList16;
            this.CustomFolderGuide_ultraButton.ImageList = imageList16;
            this.EBooksFolderGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;
            this.CustomFolderGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // フォルダパス初期表示
            EBooksLinkSetInfo eBooksLinkSetInfo = new EBooksLinkSetInfo();
            _ebooksLinkSetAcs.GetEBooksFolderPath(out eBooksLinkSetInfo);

            this.EBooksFolderPath_tEdit.Text = eBooksLinkSetInfo.EBooksFolder;
            this.CustomFolderPath_tEdit.Text = eBooksLinkSetInfo.CustomFolder;
        }

        /// <summary>
        /// フォルダパス入力チェック
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : フォルダパスの入力チェックを行います。</br>
        /// <br>Programmer : 尹安</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private bool FolderPathCheck()
        {
            bool checkFlg = true;

            string eBooksFolderPath = this.EBooksFolderPath_tEdit.Text.TrimEnd();
            string customFolderPath = this.CustomFolderPath_tEdit.Text.TrimEnd();

            #region [フォルダチェック]
            // 電子帳簿受け渡しフォルダ 設定有無
            if (string.IsNullOrEmpty(eBooksFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, 　　　　       // エラーレベル
                              ct_PGID, 						    　　　　         // アセンブリＩＤまたはクラスＩＤ
                              "電子帳簿受け渡しフォルダを設定して下さい。",      // 表示するメッセージ
                              0, 							　　　　　　　　     // ステータス値
                              MessageBoxButtons.OK);				　　　　     // 表示するボタン
                EBooksFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            // 電子帳簿受け渡しフォルダ 存在チェック
            else if (!Directory.Exists(eBooksFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, 　　　　                              // エラーレベル
                              ct_PGID, 						    　　　　                                // アセンブリＩＤまたはクラスＩＤ
                              "指定されたフォルダが存在しません。(電子帳簿受け渡しフォルダ)",           // 表示するメッセージ
                              0, 							　　　　　　 　　                           // ステータス値
                              MessageBoxButtons.OK);                                                    // 表示するボタン
                EBooksFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            // 取引先リスト受け渡しフォルダ　設定有無
            else if (string.IsNullOrEmpty(customFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, 　　　　      // エラーレベル
                              ct_PGID, 						    　　　　        // アセンブリＩＤまたはクラスＩＤ
                              "取引先リスト受け渡しフォルダを設定して下さい。", // 表示するメッセージ
                              0, 							　　　　　　　　    // ステータス値
                              MessageBoxButtons.OK);				　　　　    // 表示するボタン
                CustomFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            // 取引先リスト受け渡しフォルダ　存在チェック
            else if (!Directory.Exists(customFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, 　　　　                                  // エラーレベル
                              ct_PGID, 						    　　　　                                   // アセンブリＩＤまたはクラスＩＤ
                              "指定されたフォルダが存在しません。(取引先リスト受け渡しフォルダ)",   	   // 表示するメッセージ
                              0, 							　　　　　　　　                               // ステータス値
                              MessageBoxButtons.OK);				　　　　                               // 表示するボタン
                CustomFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            #endregion

            return checkFlg;
        }
        # endregion

        #region Private Methods (Control Event)
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロードイベント処理を行います。</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void PMKAU02010U_Load(object sender, EventArgs e)
        {
            InitilSetting();
        }

        /// <summary>
        /// 初期化Focus処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 初期化Focus処理を行います。</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void PMKAU02010UA_Shown(object sender, EventArgs e)
        {
            this.EBooksFolderPath_tEdit.Focus();
        }

        /// <summary>
        ///  Control.Click イベント(Guide_ultraButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : Guide_ultraButtonボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 尹安</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void FolderGuide_ultraButton_Click(object sender, EventArgs e)
        {
            // 電子帳簿受け渡しフォルダガイドの場合
            if (sender == this.EBooksFolderGuide_ultraButton)
            {
                folderBrowserDialog1.SelectedPath = EBooksFolderPath_tEdit.Text;
                folderBrowserDialog1.Description = "受け渡しフォルダの場所を指定してください。";

                DialogResult dRet = folderBrowserDialog1.ShowDialog();
                if (dRet == DialogResult.OK)
                {
                    this.EBooksFolderPath_tEdit.Text = System.IO.Path.GetFullPath(folderBrowserDialog1.SelectedPath);
                    this.CustomFolderPath_tEdit.Focus();
                }
                else
                {
                    this.EBooksFolderGuide_ultraButton.Focus();
                }
            }
            // 取引先リスト受け渡しフォルダガイドの場合
            else if (sender == this.CustomFolderGuide_ultraButton)
            {
                folderBrowserDialog1.SelectedPath = CustomFolderPath_tEdit.Text;
                folderBrowserDialog1.Description = "受け渡しフォルダの場所を指定してください。";

                DialogResult dRet = folderBrowserDialog1.ShowDialog();
                if (dRet == DialogResult.OK)
                {
                    this.CustomFolderPath_tEdit.Text = System.IO.Path.GetFullPath(folderBrowserDialog1.SelectedPath);

                    this.OK_Button.Focus();
                }
                else
                {
                    this.CustomFolderGuide_ultraButton.Focus();
                }
            }
        }

        /// <summary>
        /// Ok_Button.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : OKボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 尹安</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (this.FolderPathCheck() == false)
                return;

            EBooksLinkSetInfo eBooksLinkSetInfo = new EBooksLinkSetInfo();
            eBooksLinkSetInfo.CustomFolder = this.CustomFolderPath_tEdit.Text.Trim();
            eBooksLinkSetInfo.EBooksFolder = this.EBooksFolderPath_tEdit.Text.Trim();

            int status = _ebooksLinkSetAcs.WriteEBooksFolderPath(ref eBooksLinkSetInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                MessageBox.Show("保存しました。", "保存確認", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOPDISP, 　　　   　         // エラーレベル
                        ct_PGID, 						    　　　　         // アセンブリＩＤまたはクラスＩＤ
                        "電子帳簿連携設定の保存時にエラーが発生しました。",  // 表示するメッセージ
                        status, 							　　　　         // ステータス値
                        MessageBoxButtons.OK);				　　　　         // 表示するボタン

            }

            this.Close();
        }

        /// <summary>
        /// Cancel_Button.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : Cancelボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 尹安</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
