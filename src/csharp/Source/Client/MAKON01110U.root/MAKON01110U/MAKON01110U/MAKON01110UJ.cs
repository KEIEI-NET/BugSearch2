using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using Broadleaf.Library.Resources;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入データ取込フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 2020/06/22 陳艶丹</br>
    /// <br>管理番号   : 11670231-00</br>
    /// <br>           : PMKOBETSU-4017 東邦車両サービス(仕入データテキスト入力)</br>
    /// <br></br>
    /// </remarks>
    public partial class MAKON01110UJ : Form
    {
        // アクセスクラス
        private StockSlipInputAcs StockSlipInputDataAcs;
        // クラスID
        private const string CtClassID = "MAKON01110UJA";
        // クラス名
        private string CtPrintName = "データ取込";
        // イメージリスト
        private ImageList ImageList16 = null;
        // ファイル名の正確性チェック
        private char[] FileCharArr = new char[10] { '\\', '/', ':', ';', '*', '?', '"', '<', '>', '|' };

        #region エラーメッセージ
        private const string CtFileNotInput = "取込元ファイルを指定してください。";
        private const string CtFilePathError = "指定されたフォルダが存在しません。";
        private const string CtFileAccessError = "取込元ファイルへのアクセスが拒否されました。";
        private const string CtFileAlrdyError = "指定されたファイルが他で使用中です。";
        private const string CtFileExpendError = "ファイル名が不正です。";
        private const string CtFileNameError = "指定されたファイルが存在しません。";
        private const string CtErrMsg = "取込に失敗しました。";
        private const string CtCaptureFail = "取込に失敗したデータがあります。" + "\n" + "\n" + "エラーファイルを確認してください。";
        private const string CtCaptureSuccess = "取込を完了しました。";
        #endregion

        #region ■列挙体
        /// <summary>
        /// ファイルは使用フラグ
        /// </summary>
        private enum FileLocked_Status
        {
            //ファイルは使用できる
            FileLocked_NORMAL = 0,
            //ファイルが他で使用中です
            FileLocked_LOCKED = 1,
            // ファイルがアクセスできない。
            FileLocked_CANNOTACCESS = 2,
            // その他エラー
            FileLocked_EOF = 3,
        }
        #endregion
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">取込ファイル名</param>
        /// <remarks>
        /// <br>Note       : コンストラクタ生成</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        public MAKON01110UJ()
        {
            InitializeComponent();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
            this.ImageList16 = IconResourceManagement.ImageList16;
            this.ButtonInitialSetting();

            // アクセスクラス生成
            this.StockSlipInputDataAcs = StockSlipInputAcs.GetInstance();

            // 初期フォーカス設定
            this.tEdit_FolderName.Select(0, 0);

            // 件数初期化
            this.CountClear();
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// ボタン初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ生成</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.ultraButton_FolderName.ImageList = this.ImageList16;
            this.ultraButton_FolderName.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// 確定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 確定ボタンクリック時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            // エラーメッセージ
            string errMsg = string.Empty;
            string exErrMsg = string.Empty;
            // エラーデータファイルパス
            string errListPath = string.Empty;
            // 読込件数
            int readNum = 0;
            // エラー件数
            int errorNum = 0;
            // 取込ファイル名
            string stockFileName = this.tEdit_FolderName.Text.Trim();

            // ファイルチェック
            string fileCheckError = FileCheck(stockFileName);

            // ファイルチェックNGの場合
            if (fileCheckError != string.Empty)
            {
                TMsgDisp.Show(
                 this,
                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                 this.Name,
                 fileCheckError,
                 status,
                 MessageBoxButtons.OK);
                this.tEdit_FolderName.Focus();

                // 画面件数クリア
                CountClear();
            }
            // ファイルチェックOKの場合
            else
            {
                // 画面件数クリア
                CountClear();

                // 取込み処理
                status = this.StockSlipInputDataAcs.SearchStockData(stockFileName, out errorNum, out readNum, out errListPath, out errMsg, out exErrMsg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    this.tEdit_FolderName.Focus();
                    // 画面件数クリア
                    CountClear();

                    // 例外が発生する場合
                    if (!string.IsNullOrEmpty(exErrMsg))
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, CtErrMsg, 0);
                    }
                    // チェックエラーが発生する場合
                    else
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                    }
                }
                else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                {
                    this.tEdit_FolderName.Focus();
                    // 画面件数クリア
                    CountClear();
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    this.tEdit_FolderName.Focus();
                    // 画面件数クリア
                    CountClear();
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                }
                else
                {
                    // 取込件数
                    this.readCount.Text = string.Format("{0:###,##0}", readNum) + " 件";
                    // エラー件数
                    this.errorCount.Text = string.Format("{0:###,##0}", errorNum) + " 件";
                    // チェックNGのデータがあるが、仕入画面に展開できるデータがある場合
                    if (errorNum != 0)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(CtCaptureFail + "\n" + "{0}", errListPath), 0);
                    }
                    // チェックNGのデータがないで、仕入画面に展開できるデータがある場合
                    else if (readNum != 0 && errorNum == 0)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, CtCaptureSuccess, 0);
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }

            this.uiMemInput1.WriteMemInput();
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,                             // エラーレベル
                CtClassID,                         // アセンブリＩＤまたはクラスＩＤ
                CtPrintName,                       // プログラム名称
                "",                                 // 処理名称
                "",                                 // オペレーション
                message,                            // 表示するメッセージ
                status,                             // ステータス値
                null,                               // エラーが発生したオブジェクト
                MessageBoxButtons.OK,               // 表示するボタン
                MessageBoxDefaultButton.Button1);   // 初期表示ボタン
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンクリック時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // エンターまたはタブキーを押下する場合
            if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
            {
                switch (e.PrevCtrl.Name)
                {
                    // 取込ファイル名指定の場合、データ取込ボタンにフォーカス移動する
                    case "tEdit_FolderName":
                        {
                            if (!string.IsNullOrEmpty(this.tEdit_FolderName.Text))
                            {
                                e.NextCtrl = this.uButton_Save;
                            }
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 画面件数クリア
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面件数クリア</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void CountClear()
        {
            // 読込件数
            this.readCount.Text = " 0 件";
            // エラー件数
            this.errorCount.Text = " 0 件";
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 入力ファイル名ボタンをクリックした時に発生します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private void ultraButton_FolderName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ファイル選択ダイアログ
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;

                // 拡張子
                dialog.Filter = "テキストファイル|*.txt;*.csv";

                // 確定の場合
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.tEdit_FolderName.Text = dialog.FileName;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ファイルチェック
        /// </summary>
        /// <param name="folderName">フォルダ名称</param>
        /// <returns>errorメッセージ</returns>
        /// <remarks>
        /// <br>Note       : 指定フォルダに対象ファイルが存在チェック</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private string FileCheck(string stockFileName)
        {
            string errorMsg = string.Empty;

            int stockFileNameStatus = 0;
            // 取込元ファイルを指定チェック
            if (string.IsNullOrEmpty(stockFileName)) return CtFileNotInput;

            // ファイル名が未入力の場合
            // バス存在チェック_ファイル存在チェック
            if (stockFileName.EndsWith("\\"))
            {
                return CtFileExpendError;
            }

            // ファイル名に使用禁止文字混在の場合
            bool fileNameErrFlg = true;
            string str = stockFileName.Substring(stockFileName.LastIndexOf("\\") + 1);
            int suffixIndex = str.LastIndexOf(".");
            if (suffixIndex > 0 && !str.Substring(0, 1).Equals(" "))
            {
                if (CheckFileStr(str))
                {
                    fileNameErrFlg = false;
                }
            }
            else
            {
                fileNameErrFlg = false;
            }
            if (!fileNameErrFlg)
            {
                return CtFileExpendError;
            }

            // 指定されたフォルダが存在チェック
            string folderName = System.IO.Path.GetDirectoryName(stockFileName);
            if (!Directory.Exists(folderName)) return CtFilePathError;

            // 指定されたファイルが存在チェック
            if (!File.Exists(stockFileName)) return CtFileNameError;

            // ファイル排他チェック
            stockFileNameStatus = IsFileLocked(stockFileName);
            if (stockFileNameStatus == 2 || stockFileNameStatus == 3)
            {
                return CtFileAccessError;
            }
            else if (stockFileNameStatus == 1)
            {
                return CtFileAlrdyError;
            }
            return errorMsg;
        }


        /// ファイル名の正確性チェック
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ファイル名の正確性チェック。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private bool CheckFileStr(string fileName)
        {
            bool errFlg = false;
            List<char> fileCharList = new List<char>(FileCharArr);

            foreach (char c in fileName)
            {
                if (fileCharList.Contains(c))
                {
                    errFlg = true;
                    break;
                }
            }

            return errFlg;
        }

        /// <summary>
        /// 指定したファイルは使用するかどうかをチェックしている
        /// </summary>
        /// <param name="fileNm">ファイル名</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 指定したファイルは使用するかどうかをチェックしている</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
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
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();
            // 取込ファイル名
            saveCtrAry.Add(this.tEdit_FolderName);

            this.uiMemInput1.TargetControls = saveCtrAry;
        }

        /// <summary>
        /// MAKON01110UJ_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void MAKON01110UJ_Load(object sender, EventArgs e)
        {
            this.uiMemInput1.ReadMemInput();
        }
        #endregion

    }
}