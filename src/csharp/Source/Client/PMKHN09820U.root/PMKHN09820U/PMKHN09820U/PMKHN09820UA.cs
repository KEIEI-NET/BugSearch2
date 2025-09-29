//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ（インポート）
// プログラム概要   : 掛率マスタ（インポート）処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率マスタ（インポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ（インポート） UIフォームクラス</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br>UpdateNote : </br>
    /// <br></br>
    /// <br>Update Note: 掛け率マスタインポート・エクスポート機能追加対応</br>
    /// <br>Programmer : 30521 T.MOTOYAMA</br>
    /// <br>Date       : 2013.10.28</br>
    /// </remarks>
    public partial class PMKHN09820UA : Form, ICSVImportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// 掛率マスタ（インポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率マスタ（インポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09820UA()
        {
            InitializeComponent();

            // 掛率マスタ（インポート）のアクセス
            this._DepsitMainRfImportAcs = new DepsitMainRfImportAcs();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member
        //--ICSVImportConditionInpTypeのプロパティ用変数 ----------------------------------
        #endregion ◆ Interface member
        // 掛率マスタ（インポート）のアクセス
        private DepsitMainRfImportAcs _DepsitMainRfImportAcs;
        // 企業コード
        private string _enterpriseCode = string.Empty;
        // 読込件数
        private Int32 _readCnt = 0;
        // 作成件数
        private Int32 _addCnt = 0;
        // エラー件数
        private Int32 _errCnt = 0;
        // CSV項目数
        private const Int32 _csvItemCnt = 24;
        #endregion ■ Private Member

        #region ■ Private Const
        // クラスID
        private const string ct_ClassID = "PMKHN09820UA";
        // プログラムID
        private const string ct_PGID = "PMKHN09820U";
        // プログラム名称
        private const string ct_PGNAME = "掛率マスタインポート";
        // プリントキー
        private const string ct_PRINTKEY = "39d707bb-f0b8-489f-b9e0-a95654b2998e";
        #endregion

        #region ■ IImportConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Method
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = "0";

            // 画面表示
            this.Show();

            return;
        }

        /// <summary>
        /// ベースでチェック処理を行うかどうか。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースでチェック処理を行うかどうか。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public bool IsUseBaseCheck()
        {
            // ベースでチェック処理を行う。
            return true;
        }

        /// <summary>
        /// チェックしたいテキストファイル名
        /// </summary>
        /// <remarks>
        /// <br>Note	   : チェックしたいテキストファイル名を戻る。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public string ImportFileName()
        {
            return this.tEdit_TextFileName.DataText;
        }

        /// <summary>
        /// 特にチェックがあれば実装する。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 特にチェックがあれば実装する、なければTrueを戻る。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public bool ImportBeforeCheck()
        {
            // 実装しない
            return true;
        }

        /// <summary>
        /// CSV読込項目数チェック
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 読み込んだCSVの1行目の項目数が妥当かどうかチェックをする。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public bool ItemCntCheck(int csvDataRowCnt)
        {
            if (csvDataRowCnt != _csvItemCnt)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// ベースにチェックエラーがあれば、フォーカスの設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースにチェックエラーがあれば、フォーカスの設定を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = Properties.Resources.LabelTxtInportNum;
            this.uLabel_AddCnt.Text = Properties.Resources.LabelTxtInportNum;
            this.uLabel_ErrCnt.Text = Properties.Resources.LabelTxtInportNum;
            // テキストファイルのフォーカスの設定
            this.tEdit_TextFileName.Focus();
            return;
        }

        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="csvDataList">CSVファイル</param>
        /// <remarks>
        /// <br>Note	   : インポート処理を行う。元PGからコールされる</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMsg = string.Empty;

            // インポート中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = Properties.Resources.TitleStrProgress;
            form.Message = Properties.Resources.MsgStrProgress;

            try
            {
                List<SetUpControlInfo> list = new List<SetUpControlInfo>();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, Properties.Resources.PrpID)))
                {
                    list = UserSettingController.DeserializeUserSetting<List<SetUpControlInfo>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, Properties.Resources.PrpID));
                }
                List<int[]> setUpControlInfoList = new List<int[]>();
                int[] setUpControlItem;
                for (int i = 0; i < list.Count; i++)
                {
                    setUpControlItem = new int[2] { list[i].ItemId, list[i].UpdateDiv };
                    setUpControlInfoList.Add(setUpControlItem);
                }

                // ダイアログ表示
                form.Show();

                this.uLabel_ReadCnt.Text = Properties.Resources.LabelTxtInportNum;
                this.uLabel_AddCnt.Text = Properties.Resources.LabelTxtInportNum;
                this.uLabel_ErrCnt.Text = Properties.Resources.LabelTxtInportNum;

                // この時点でcsvDataListの中にCSVデータがそのまま格納されている
                // チェックOKのリスト
                List<string[]> checkOKArrList = null;

                // データ妥当性チェックを行う
                // bool errFlg = this._DepsitMainRfImportAcs.ImportCheck(csvDataList, out checkOKArrList, out this._readCnt, out this._errCnt);            // Del 2013.10.28 T.MOTOYAMA
                bool errFlg = this._DepsitMainRfImportAcs.ImportCheck(csvDataList, out checkOKArrList, out this._readCnt, out this._errCnt, out errMsg);   // Add 2013.10.28 T.MOTOYAMA

                if (errFlg == true)
                {
                    // データの妥当性チェックがNGの場合はDBへのインポート処理は行わないのでエラー設定
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                else
                {
                    // CSVデータを設定する
                    DepsitMainRfImportWorkTbl importWorkTbl = new DepsitMainRfImportWorkTbl();
                    importWorkTbl.EnterpriseCode = this._enterpriseCode;

                    // データチェック後のリストをインスタンスに渡す
                    importWorkTbl.CsvDataInfoList = (List<string[]>)checkOKArrList;

                    // AクラスのImportメソッド
                    // status = this._DepsitMainRfImportAcs.Import(importWorkTbl, out this._addCnt, out errMsg);  // Del 2013.10.28 T.MOTOYAMA
                    status = this._DepsitMainRfImportAcs.Import(importWorkTbl, (int)this.ultraOptionSet_TakeInCond.CheckedItem.DataValue, out this._addCnt, out this._errCnt, out errMsg);  // Add 2013.10.28 T.MOTOYAMA

                }
                // ダイアログを閉じる
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // 読込件数
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        if (this._addCnt > 0)
                        {
                            // 取込完了後に画面の設定項目を保存する(PM7同等)
                            this.uiMemInput1.WriteMemInput();

                            // 追加件数
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);

                            // エラー件数
                            this.uLabel_ErrCnt.Text = NumberFormat(this._errCnt);
                            
                            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                            if (errMsg != "")
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                        }
                        else
                        {
                            // 追加件数がゼロの場合、メッセージを表示する
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, Properties.Resources.MsgStrNotExistData, 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, Properties.Resources.MsgStrAlreadyDelet, 0);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, Properties.Resources.MsgStrAlreadyUpdate, 0);
                        break;
                    //case (int)ConstantManagement.MethodResult.ctFNC_ERROR: // Del 2013.10.28 T.MOTOYAMA
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:       // Add 2013.10.28 T.MOTOYAMA
                        // データチェックでNGとなった場合
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, (int)ConstantManagement.MethodResult.ctFNC_ERROR);  // Add 2013.10.28 T.MOTOYAMA

                        #region Del 2013.10.28 T.MOTOYAMA
                        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
                        //if (this._errCnt > 0)
                        //{
                        //    // データ重複のエラーとなっても現状では何もしない
                        //}
                        //else
                        //{
                        //    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, Properties.Resources.MsgStrFailedImport, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        //}
                        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
                        #endregion
                        break;
                    default:
                        // 読込件数
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        if (this._addCnt > 0)
                        {
                            // 取込完了後に画面の設定項目を保存する(PM7同等)
                            this.uiMemInput1.WriteMemInput();

                            // 追加件数
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);

                            // エラー件数
                            this.uLabel_ErrCnt.Text = NumberFormat(this._errCnt);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            // 追加件数がゼロの場合、メッセージを表示する
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, Properties.Resources.MsgStrNotExistData, 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, Properties.Resources.MsgStrFailedImport, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                form.Close();
            }
            return status;
        }

        #endregion ◆ Public Method

        #endregion ■ IImportConditionInpType メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 入力項目の初期化を行う</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ﾃｷｽﾄﾌｧｲﾙ名
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;

                this.ultraOptionSet_TakeInCond.CheckedIndex = 0; // Add 2013.10.28 T.MOTOYAMA 

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 画面初期化処理

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date		: 2013/06/12</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.ultraOptionSet_TakeInCond);  // Add 2013.10.28 T.MOTOYAMA
            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;

            // 画面Close時に画面情報を保存しない(PM7同等)
            this.uiMemInput1.WriteOnClose = false;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 数字のフォーマット
        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date		: 2013/06/12</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format(Properties.Resources.LabelFmtImportNum, number);
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
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                Properties.Resources.ClassID,		// アセンブリＩＤまたはクラスＩＤ
                Properties.Resources.ProgramName,	// プログラム名称
                string.Empty, 						// 処理名称
                string.Empty,						// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + System.Environment.NewLine + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                Properties.Resources.ClassID,		// アセンブリＩＤまたはクラスＩＤ
                Properties.Resources.ProgramName,	// プログラム名称
                procnm, 							// 処理名称
                string.Empty,						// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion ◆ エラーメッセージ表示処理
        #endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMKHN09820UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09820UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }

        /// <summary>
        /// CSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : CSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// </remarks>
        private void uButton_TextFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // タイトルバーの文字列
                openFileDialog.Title = "インポートファイル選択";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }
                //「ファイルの種類」を指定
                openFileDialog.Filter = Properties.Resources.FilterStrLoadFileDialog;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = openFileDialog.FileName;
                }
            }
        }

        #region フォーカス移動イベント
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 矢印キーでのフォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 劉学智</br>                                   
        /// <br>Date        : 2013/06/12</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→ ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // テキストファイル名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                }
            }
        }
        #endregion
        #endregion ■ Control Event

    }
}