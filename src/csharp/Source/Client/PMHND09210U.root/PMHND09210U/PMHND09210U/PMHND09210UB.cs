//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 商品バーコード一括登録                                  //
// プログラム概要   : 商品バーコード一括登録 テキスト取込UIクラス     　　    //
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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード一括登録 テキスト取込UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品バーコード一括登録 テキスト取込UIクラス</br>
    /// <br>Programmer  : 3H 張小磊</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
    public partial class PMHND09210UB : Form
    {
        # region private field
        /// <summary>テキスト取込ユーザー設定</summary>
        private GoodsBarCodeRevnImportTextUserConst _userSetting;
        /// <summary>テキスト取込アクセス</summary>
        private GoodsBarCodeRevnImportAcs _goodsBarCodeRevnImportAcs;
        #endregion

        #region Const Memebers
        /// <summary>クラスID</summary>
        private const string ct_ClassID = "PMHND09210UB";
        /// <summary>クラス名称</summary>
        private const string ct_ClassName = "商品バーコード一括登録（テキスト取込）";
        /// <summary>設定XMLファイル名</summary>
        private const string ct_XML_FILE_NAME = "PMHND09210UB_Construction.XML";
        // エラーログが出力する時、確認メッセージ
        private const string ERRORLOG_EXPORT_MSG = "インポートに失敗した行があります。\r\n{0}を参照して下さい。";

        #region 処理区分
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "追加更新";
        private const string ct_AddNm = "追加";
        private const string ct_UpdNm = "更新";
        #endregion

        #region チェック区分
        private const int ct_DataCheckOn = 0;
        private const int ct_DataCheckOff = 1;
        private const string ct_DataCheckOnNm = "あり";
        private const string ct_DataCheckOffNm = "なし";
        #endregion

        #endregion

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	    : デフォルトコンストラクタ</br>
        /// <br>Programmer  : 3H 張小磊</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        public PMHND09210UB()
        {
            InitializeComponent();
            // コンボボックス初期化
            InitializeComboEditor();
            // テキスト取込アクセス
            this._goodsBarCodeRevnImportAcs = new GoodsBarCodeRevnImportAcs();
            // テキスト取込ユーザー設定
            this._userSetting = new GoodsBarCodeRevnImportTextUserConst();
        }

        #region ◆ 画面初期化処理
        /// <summary>
        /// コンボボックス初期化
        /// </summary>
        /// <remarks>
        /// <br>Note	    : コンボボックス初期化を行う</br>
        /// <br>Programmer  : 3H 張小磊</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        private void InitializeComboEditor()
        {
            try
            {
                this.tComboEditor_ProcessKbn.BeginUpdate();

                Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
                // 追加更新
                listItem0.DataValue = ct_AddUpdCd;
                listItem0.DisplayText = ct_AddUpdNm;

                // 追加
                Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
                listItem1.DataValue = ct_AddCd;
                listItem1.DisplayText = ct_AddNm;

                // 更新
                Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
                listItem2.DataValue = ct_UpdCd;
                listItem2.DisplayText = ct_UpdNm;

                this.tComboEditor_ProcessKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });

                // 「追加更新」を選択されています
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();

                this.tComboEditor_DataCheckKbn.BeginUpdate();
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                // あり
                listItem3.DataValue = ct_DataCheckOn;
                listItem3.DisplayText = ct_DataCheckOnNm;
                // なし
                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_DataCheckOff;
                listItem4.DisplayText = ct_DataCheckOffNm;
                this.tComboEditor_DataCheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });
                // 「あり」を選択されています
                this.tComboEditor_DataCheckKbn.SelectedIndex = 0;

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ﾃｷｽﾄﾌｧｲﾙ名
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;
                // エラーログファイル名
                this.uButton_ErrorLogFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ﾃｷｽﾄﾌｧｲﾙ名
                this.uButton_ErrorLogFileGuide.Appearance.Image = Size16_Index.STAR1;

                this.tComboEditor_ProcessKbn.EndUpdate();
                this.tComboEditor_DataCheckKbn.EndUpdate();

            }
            catch
            {
            }
        }
        #endregion ◎ 画面初期化処理

        #region ◆ 画面イベント
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
        private void PMHND09210UB_Load(object sender, EventArgs e)
        {
            // ボタン設定
            this.uButton_TextFileGuide.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_TextFileGuide.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            this.uButton_ErrorLogFileGuide.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_ErrorLogFileGuide.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            // 商品バーコード一括登録用ユーザー設定デシリアライズ処理
            this.Deserialize();
            // ユーザー設定情報 ⇒ 画面
            SetUserSettingToScreen();
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ファイルダイアログ表示。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_TextFileGuide_Click(object sender, EventArgs e)
        {
            // タイトルバーの文字列
            this.openFileDialog.Title = "取込ファイル選択";
            this.openFileDialog.RestoreDirectory = true;
            if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
            {
                this.openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
            else
            {
                this.openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                this.openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
            }
            //「ファイルの種類」を指定
            this.openFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // テキストファイル名
                this.tEdit_TextFileName.DataText = this.openFileDialog.FileName;
                // テキストファイル名変更された時発生イベント
                tEdit_TextFileName_ValueChanged(null, null);
            }
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ファイルダイアログ表示。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_ErrorLogFileGuide_Click(object sender, EventArgs e)
        {
            // タイトルバーの文字列
            this.saveFileDialog1.Title = "エラーログファイル選択";
            this.saveFileDialog1.RestoreDirectory = true;
            if (this.tEdit_ErrorLogFileName.Text.Trim() == string.Empty)
            {
                this.saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
            else
            {
                this.saveFileDialog1.FileName = System.IO.Path.GetFileName(this.tEdit_ErrorLogFileName.Text);
                this.saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_ErrorLogFileName.Text);
            }
            //「ファイルの種類」を指定
            this.saveFileDialog1.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_ErrorLogFileName.DataText = this.saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// テキストファイル名変更された時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : テキストファイル名変更された時発生します。</br> 
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            // テキストファイル名
            string textFileName = this.tEdit_TextFileName.DataText.Trim();
            if (!string.IsNullOrEmpty(textFileName))
            {
                try
                {
                    // テキストファイルパス
                    string textFilePath = textFileName.Substring(0, textFileName.LastIndexOf('\\'));
                    // テキストファイル名(パスなし)
                    string fileName = textFileName.Substring(textFileName.LastIndexOf('\\') + 1, textFileName.Length - 5 - textFileName.LastIndexOf('\\'));
                    // エラーログファイル名をセット
                    this.tEdit_ErrorLogFileName.DataText = textFilePath + "\\" + fileName + "_Error.CSV";
                }
                catch
                {
                    // 処理なし
                }
            }
        }

        /// <summary>
        /// テキスト取込処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : テキスト取込処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            string errMessage = string.Empty;
            string errorLogFileName = string.Empty;
            // 入力チェック処理
            if (!ScreenInputCheck(ref errMessage, out errorLogFileName))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                return;
            }
            // 画面 ⇒ ユーザー設定情報
            GetUserSettingFromScreen();
            // _userSettingは書き変わっているので設定XML更新
            this.Serialize();

            // テキスト取込中画面部品のインスタンスを作成
            SFCMN00299CA form = new SFCMN00299CA();
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // 表示文字を設定
                form.Title = "テキスト取込中";
                form.Message = "現在、データをテキスト取込中です．．．";
                // ダイアログ表示
                form.Show();

                this.uLabel_ReadCnt.Text = "0";
                this.uLabel_AddCnt.Text = "0";
                this.uLabel_UpdCnt.Text = "0";
                this.uLabel_ErrorCnt.Text = "0";

                // 取込件数
                int readCnt = 0;
                // 追加件数
                int addCnt = 0;
                // 更新件数
                int updCnt = 0;
                // エラー件数
                int errCnt = 0;
                // ファイルデータ
                List<GoodsBarCodeRevnFileWork> fileWorkList = new List<GoodsBarCodeRevnFileWork>();
                // ファイルデータ取得処理
                if (!GetTextFileData(this.tEdit_TextFileName.Text.Trim(), out fileWorkList, out errMessage))
                {
                    // ダイアログを閉じる
                    if (form != null) form.Close();
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                    return;
                }

                //インポート処理
                status = _goodsBarCodeRevnImportAcs.Import(fileWorkList, errorLogFileName, this._userSetting.ProcessKbn, this._userSetting.DataCheckKbn, out readCnt, out addCnt, out updCnt, out errCnt, out errMessage);

                // ダイアログを閉じる
                if (form != null) form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // 読込件数
                        this.uLabel_ReadCnt.Text = NumberFormat(readCnt);
                        if (addCnt > 0 || updCnt > 0)
                        {
                            // 追加件数
                            this.uLabel_AddCnt.Text = NumberFormat(addCnt);
                            // 更新件数
                            this.uLabel_UpdCnt.Text = NumberFormat(updCnt);
                            // エラー件数
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, errorLogFileName), status);
                            }
                        }
                        else
                        {
                            // エラー件数
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, errorLogFileName), status);
                            }
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当データ無し", status);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "テキスト取込に失敗しました。", (int)ConstantManagement.DB_Status.ctDB_ERROR);
                        break;
                }
            }
            catch
            {
                // ダイアログを閉じる
                if (form != null) form.Close();
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "テキスト取込に失敗しました。", (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }

        }

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
            // 終了
            this.Close();
        }

        #region フォーカス移動イベント
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 矢印キーでのフォーカス移動時に発生します</br>                 
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // 処理区分→チェック区分
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                    }
                    if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // チェック区分→ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→  エラーログファイル名
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // エラーログファイル名→  エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_ErrorLogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // エラーログファイルダイアログ→  取込
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // 取込→  キャンセル
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // キャンセル→  処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                }
                else if (e.Key == Keys.Right)
                {
                    if (e.PrevCtrl == this.tComboEditor_DataCheckKbn || e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                }
                else if (e.Key == Keys.Left)
                {
                    if (e.PrevCtrl == this.uButton_OK)
                    {
                        // 取込
                        e.NextCtrl = this.uButton_OK;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // 処理区分→ キャンセル
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // キャンセル→  取込
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // 取込→  エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_ErrorLogFileGuide;
                    }

                    else if (e.PrevCtrl == this.uButton_ErrorLogFileGuide)
                    {
                        // エラーログファイルダイアログ→エラーログファイル名
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // エラーログファイル名→ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // テキストファイル名→ チェック区分
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // チェック区分→処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region ◆ 入力ファイル名チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errorLogFileName">エラーログファイルバス</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note	   : 画面の入力チェックを行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, out string errorLogFileName)
        {
            // テキストファイル名
            string textFileName = tEdit_TextFileName.DataText.Trim();
            // エラーログファイル名
            errorLogFileName = tEdit_ErrorLogFileName.DataText.Trim();
            // パス入力しない場合
            if (string.IsNullOrEmpty(textFileName))
            {
                errMessage = "テキストファイル名を入力してください。";
                this.tEdit_TextFileName.Focus();
                return false;
            }
            // パス入力不正場合
            if (!File.Exists(textFileName))
            {
                errMessage = "テキストファイルパスが不正です。";
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // パス入力しない場合
            if (string.IsNullOrEmpty(errorLogFileName))
            {
                errMessage = "エラーログファイル名を入力してください。";
                this.tEdit_ErrorLogFileName.Focus();
                return false;
            }

            int dir_index = errorLogFileName.LastIndexOf("\\");
            int file_index = errorLogFileName.LastIndexOf(".");
            //ディレクトリ存在しない場合
            if (!Directory.Exists(errorLogFileName))
            {
                if (dir_index > 0 && file_index > 0)
                {
                    string errorLogFileDir = string.Empty;
                    if (file_index > dir_index)
                    {
                        errorLogFileDir = errorLogFileName.Substring(0, dir_index);
                    }
                    else
                    {
                        errorLogFileDir = errorLogFileName;
                    }
                    if (!Directory.Exists(errorLogFileDir))
                    {
                        errMessage = "エラーログファイルパスが不正です。";
                        this.tEdit_ErrorLogFileName.Focus();
                        return false;
                    }
                }
                else
                {
                    errMessage = "エラーログファイルパスが不正です。";
                    this.tEdit_ErrorLogFileName.Focus();
                    return false;
                }
            }
            else
            {
                if (dir_index + 1 == errorLogFileName.Length)
                {
                    errorLogFileName = errorLogFileName + "ErrLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".CSV";
                }
                else
                {
                    errorLogFileName = errorLogFileName + "\\" + "ErrLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".CSV";
                }
            }
            //同じパスの場合
            if (textFileName.ToUpper().Equals(errorLogFileName.ToUpper()))
            {
                errMessage = "テキストファイル名とエラーログファイル名は同一の指定は出来ません。";
                this.tEdit_ErrorLogFileName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ◆ テキストデータを読む
        /// <summary>
        /// テキストファイルデータ取得処理
        /// </summary>
        /// <param name="textFileName">ファイル名前</param>
        /// <param name="fileWorkList">テキストファイルデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>True:取得処理OK, False:取得処理NG</returns>
        /// <remarks>
        /// <br>Note	   : テキストファイルデータ取得処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool GetTextFileData(string textFileName, out List<GoodsBarCodeRevnFileWork> fileWorkList, out string errMsg)
        {
            errMsg = string.Empty;
            fileWorkList = new List<GoodsBarCodeRevnFileWork>();
            TextFieldParser parser = new TextFieldParser(textFileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
            try
            {
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    // 区切り文字はコンマ
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        // 1行読み込み
                        string[] row = parser.ReadFields();
                        GoodsBarCodeRevnFileWork work = new GoodsBarCodeRevnFileWork();
                        // 商品メーカーコード
                        work.GoodsMakerCd = ConvertToString(row, 0);
                        // 品番
                        work.GoodsNo = ConvertToString(row, 1);
                        // バーコード
                        work.GoodsBarCode = ConvertToString(row, 2);
                        // バーコード種別
                        work.GoodsBarCodeKind = ConvertToString(row, 3);
                        fileWorkList.Add(work);
                    }
                }
            }
            catch
            {
                errMsg = "テキストファイルの読み込みに失敗しました。" + parser.ErrorLineNumber + "行目の内容を確認してください。";
                return false;
            }
            // タイトル行
            if (fileWorkList.Count > 1)
            {
                fileWorkList.RemoveAt(0);
            }
            else
            {
                // レコードがない場合
                errMsg = "該当するデータがありません。";
                return false;
            }
            return true;
        }
        #endregion

        #region ◎ 文字項目へ変換処理
        /// <summary>
        /// 文字項目へ変換処理
        /// </summary>
        /// <param name="dataArr">txt項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>文字項目へ変換結果</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string ConvertToString(string[] dataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < dataArr.Length)
            {
                retContent = dataArr[index];
            }

            return retContent;
        }
        #endregion

        #region ◆ 数字のフォーマット
        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <returns>数字のフォーマット結果</returns>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                // 数字のフォーマット
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }

            return ret;
        }
        #endregion

        #region ◆ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_ClassName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region ◆ ユーザー設定の保存・読み込み
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
                    this._userSetting = UserSettingController.DeserializeUserSetting<GoodsBarCodeRevnImportTextUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new GoodsBarCodeRevnImportTextUserConst();
                }
            }
        }

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
            // 処理区分
            if (this.tComboEditor_ProcessKbn.Items.Count > this._userSetting.ProcessKbn && this._userSetting.ProcessKbn >= 0)
            {
                this.tComboEditor_ProcessKbn.SelectedIndex = this._userSetting.ProcessKbn;
            }
            // チェック区分
            if (this.tComboEditor_DataCheckKbn.Items.Count > this._userSetting.DataCheckKbn && this._userSetting.DataCheckKbn >= 0)
            {
                this.tComboEditor_DataCheckKbn.SelectedIndex = this._userSetting.DataCheckKbn;
            }
            // テキストファイル
            this.tEdit_TextFileName.Text = this._userSetting.TextFileName;
            // エラーログファイル
            this.tEdit_ErrorLogFileName.Text = this._userSetting.LogFileName;
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
            // 処理区分
            this._userSetting.ProcessKbn = this.tComboEditor_ProcessKbn.SelectedIndex;
            // チェック区分
            this._userSetting.DataCheckKbn = this.tComboEditor_DataCheckKbn.SelectedIndex;
            // テキストファイル
            this._userSetting.TextFileName = this.tEdit_TextFileName.Text;
            // エラーログファイル
            this._userSetting.LogFileName = this.tEdit_ErrorLogFileName.Text;

        }
        #endregion
    }
    /// <summary>
    /// 商品バーコード一括登録用テキスト取込ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード一括登録のテキスト取込ユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    [Serializable]
    public class GoodsBarCodeRevnImportTextUserConst
    {
        #region プライベート変数

        // 処理区分
        private int _processKbn;

        // チェック区分
        private int _dataCheckKbn;

        // テキストファイル
        private string _textFileName;

        // エラーログファイル
        private string _logFileName;

        #endregion

        #region プロパティ
        /// <summary>処理区分</summary>
        public int ProcessKbn
        {
            get { return _processKbn; }
            set { _processKbn = value; }
        }

        /// <summary>チェック区分</summary>
        public int DataCheckKbn
        {
            get { return _dataCheckKbn; }
            set { _dataCheckKbn = value; }
        }

        /// <summary>テキストファイル</summary>
        public string TextFileName
        {
            get { return _textFileName; }
            set { _textFileName = value; }
        }

        /// <summary>エラーログファイル</summary>
        public string LogFileName
        {
            get { return _logFileName; }
            set { _logFileName = value; }
        }
        #endregion
    }
}