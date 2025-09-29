//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ（インポート）
// プログラム概要   : 商品管理情報マスタ（インポート）処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/06/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 修 正 日  2012/07/03  修正内容 : お客様の指摘の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/19  修正内容 : 障害一覧の指摘NO.110の対応
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品管理情報マスタ（インポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理情報マスタ（インポート） UIフォームクラス</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN07660UA : Form, IImportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// 商品管理情報マスタ（インポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07660UA()
        {
            InitializeComponent();

            // 商品管理情報マスタ（インポート）のアクセス
            this._goodsMngImportAcs = new GoodsMngImportAcs();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member
        //--IImportConditionInpTypeのプロパティ用変数 ----------------------------------
        #endregion ◆ Interface member
        // 商品管理情報マスタ（インポート）のアクセス
        private GoodsMngImportAcs _goodsMngImportAcs;
        // 企業コード
        private string _enterpriseCode = "";
        // 読込件数
        private Int32 _readCnt = 0;
        // 追加件数
        private Int32 _addCnt = 0;
        // 更新件数
        private Int32 _updCnt = 0;
        // エラー件数
        private Int32 _errCnt = 0;
        // エラーログファイルパス
        private string textFilePath = "";
        //エラーログファイルパス+エラーログファイル名
        private string textFilePathName = "";

        #endregion ■ Private Member

        #region ■ Private Const
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "追加更新";
        private const string ct_AddNm = "追加";
        private const string ct_UpdNm = "更新";
        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
        private const int ct_CheckCd = 0;
        private const int ct_NoCheckCd = 1;
        private const string ct_CheckNm = "あり";
        private const string ct_NoCheckNm = "なし";
        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
        // エラーログが出力する時、確認メッセージ
        private const string ERRORLOG_EXPORT_MSG = "インポートに失敗した行があります。\r\n{0}を参照して下さい。";
        // テーブル名称
        private const string PRINTSET_TABLE = "GoodsMngExp";
        // クラスID
        private const string ct_ClassID = "PMKHN07660UA";
        // プログラムID
        private const string ct_PGID = "PMKHN07660U";
        // CSV名称
        private string _printName = "商品管理情報マスタ（インポート）";
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
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // 画面表示
            this.Show();
            
            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = "0";

            return;
        }

        /// <summary>
        /// ベースでチェック処理を行うかどうか。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースでチェック処理を行うかどうか。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
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
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
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
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public bool ImportBeforeCheck()
        {
            // 実装しない
            return true;
        }

        /// <summary>
        /// ベースにチェックエラーがあれば、フォーカスの設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースにチェックエラーがあれば、フォーカスの設定を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = "0";
            this.uLabel_AddCnt.Text = "0";
            this.uLabel_UpdCnt.Text = "0";
            this.uLabel_ErroCnt.Text = "0";
            // テキストファイルのフォーカスの設定
            this.tEdit_TextFileName.Focus();
            return;
        }

        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="csvDataList">CSVファイル</param>
        /// <remarks>
        /// <br>Note	   : インポート処理を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            string errMessage = "";
            Control errComponent = null;

            // 入力チェック処理
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                return status;
            }

            try
            {
                // インポート中画面部品のインスタンスを作成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "インポート中";
                form.Message = "現在、データをインポート中です。";
                // ダイアログ表示
                form.Show();

                this.uLabel_ReadCnt.Text = "0";
                this.uLabel_AddCnt.Text = "0";
                this.uLabel_UpdCnt.Text = "0";
                this.uLabel_ErroCnt.Text = "0";

                // 処理区分とCSVデータを設定する
                ExtrInfo_GoodsMngImportWorkTbl importWorkTbl = new ExtrInfo_GoodsMngImportWorkTbl();
                importWorkTbl.EnterpriseCode = this._enterpriseCode;
                importWorkTbl.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
                importWorkTbl.CheckKbn = (int)this.tComboEditor_CheckKbn.Value;
                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
                importWorkTbl.CsvDataInfoList = (List<string[]>)csvDataList;
                importWorkTbl.ErrorLogFileName = this.tEdit_LogFileName.DataText.Trim();

                string errMsg = string.Empty;
                // インポート処理
                status = this._goodsMngImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out _errCnt, out errMsg);
                
                // ダイアログを閉じる
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // 読込件数
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        if (this._addCnt > 0 || this._updCnt > 0)
                        {
                            // 追加件数
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);
                            // 更新件数
                            this.uLabel_UpdCnt.Text = NumberFormat(this._updCnt);
                            //エラー件数
                            this.uLabel_ErroCnt.Text = NumberFormat(this._errCnt);
                            if (this._errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);
                            }
                        }
                        else
                        {
                            //エラー件数
                            this.uLabel_ErroCnt.Text = NumberFormat(this._errCnt);
                            if (this._errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);
                            }
                            // 追加件数と更新件数が全てゼロの場合、メッセージを表示する
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当データ無し", 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により削除されています。", 0);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により更新されています。", 0);
                        break;
                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "商品管理情報マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "商品管理情報マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

            return status;
        }
        #endregion  ◆ Public Method
        #endregion ■ IImportConditionInpType メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 入力項目の初期化を行う</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

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

                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
                this.tComboEditor_CheckKbn.BeginUpdate();

                // あり
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                listItem3.DataValue = ct_CheckCd;
                listItem3.DisplayText = ct_CheckNm;

                // なし
                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_NoCheckCd;
                listItem4.DisplayText = ct_NoCheckNm;

                this.tComboEditor_CheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });
                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<

                // 「追加更新」を選択されています
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();

                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
                this.tComboEditor_CheckKbn.SelectedIndex = 0;
                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                this.uButton_LogFileGuide.ImageList = IconResourceManagement.ImageList16;

                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;
                this.uButton_LogFileGuide.Appearance.Image = Size16_Index.STAR1;

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

                this.tComboEditor_ProcessKbn.EndUpdate();
                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
                this.tComboEditor_CheckKbn.EndUpdate();
                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
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
        /// <br>Programmer	: 張曼</br>
        /// <br>Date		: 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_ProcessKbn);
            // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
            saveCtrAry.Add(this.tComboEditor_CheckKbn);
            // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
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
        /// <br>Programmer	: 張曼</br>
        /// <br>Date		: 2012/06/04</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
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
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
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
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion ◆ エラーメッセージ表示処理

        #region ◆ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 張曼</br>
        /// <br>Date		: 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            string fileName = tEdit_TextFileName.DataText.Trim();
            string errorLogFileName = tEdit_LogFileName.DataText.Trim();

            if (errorLogFileName == string.Empty)
            {
                errMessage = "エラーログファイル名を入力してください。";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(errorLogFileName)))
            {
                //errMessage = "エラーログファイルパス不正です。";//---DEL 2012/07/03　張曼
                errMessage = "CSVファイルパスが不正です。";       //---ADD 2012/07/03　張曼
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            string fileNameU = fileName.ToUpper();
            string fileNameL = fileName.ToLower();

            string errorLogFileNameU = errorLogFileName.ToUpper();
            string errorLogFileNameL = errorLogFileName.ToLower();

            if (fileNameU.Equals(errorLogFileNameU) || fileNameL.Equals(errorLogFileNameL))
            {
                errMessage = "テキストファイル名とエラーログファイル名は同一の指定は出来ません。";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            return true;
        }
        #endregion ◆ 入力チェック処理
        #endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMKHN07620UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private void PMKHN07660UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer  : 張曼</br>
        /// <br>Date        : 2012/06/04</br>
        /// </remarks>
        private void uButton_TextFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // タイトルバーの文字列
                openFileDialog.Title = "取込ファイル選択";
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
                openFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = openFileDialog.FileName;
                    if (openFileDialog.FileName != string.Empty)
                    {
                        this.tEdit_LogFileName.DataText = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf(".")) + "_Error" + openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf("."));
                    }
                }                
            }
        }

        /// <summary>
        /// エラーログCSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : エラーログCSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 張曼</br>
        /// <br>Date        : 2012/06/04</br>
        /// </remarks>
        private void uButton_LogFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // タイトルバーの文字列
                openFileDialog.Title = "エラーログファイル選択";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_LogFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_LogFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_LogFileName.Text);
                }
                //「ファイルの種類」を指定
                openFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_LogFileName.DataText = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// テキストファイル名変更された時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : テキストファイル名変更された時発生します。</br> 
        /// <br>Programmer  : 張曼</br>
        /// <br>Date        : 2012/06/04</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.tEdit_TextFileName.DataText != string.Empty)
                {
                    textFilePath = this.tEdit_TextFileName.DataText.Substring(0, this.tEdit_TextFileName.DataText.LastIndexOf('\\'));
                    string textFileUpName = this.tEdit_TextFileName.DataText.Substring(this.tEdit_TextFileName.DataText.LastIndexOf('\\') + 1, this.tEdit_TextFileName.DataText.Length - 5 - this.tEdit_TextFileName.DataText.LastIndexOf('\\'));
                    textFilePathName = textFilePath + "\\" + textFileUpName + "_Error.CSV";
                    this.tEdit_LogFileName.DataText = textFilePathName;
                }
            }
            catch
            {
                return;
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
        /// <br>Programmer  : 張曼</br>                                   
        /// <br>Date        : 2012/06/04</br>                                       
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
                        // 処理区分→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // テキストファイル名→テキストファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // テキストファイルダイアログ→ エラーログフォルダ名
                        e.NextCtrl = this.tEdit_LogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // エラーログフォルダ名→ ログファイルダイアログ
                        e.NextCtrl = this.uButton_LogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        // テキストファイルダイアログ→  処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
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
                        // 処理区分→ログファイルダイアログ
                        e.NextCtrl = this.uButton_LogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        // ログファイルダイアログ→エラーログフォルダ名
                        e.NextCtrl = this.tEdit_LogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // エラーログフォルダ名→テキストファイル名
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // テキストファイル名→テキストファイルダイアログ
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // テキストファイル名→ 処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                }
            }
        }
        #endregion

        #endregion ■ Control Event

    }
}