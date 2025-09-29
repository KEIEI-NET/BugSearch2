//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員マスタ（エクスポート）
// プログラム概要   : 従業員マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 従業員マスタ（エクスポート）
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員マスタ（エクスポート）クラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public partial class PMKHN07210UA : Form, IExportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.20</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07210UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _employeeExportAcs = new EmployeeExportAcs();
            _employeeExportWork = new EmployeeExportWork();
            this._employeeAcs = new EmployeeAcs();
            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

        }
        #endregion

        #region ■ Private member
        // 従業員マスタ（エクスポート）アクセスクラス
        private EmployeeExportAcs _employeeExportAcs;
        // 従業員マスタ（エクスポート）クラス
        private EmployeeExportWork _employeeExportWork;

        // 企業コード
        private string _enterpriseCode;

        // 担当者ガイド用
        private EmployeeAcs _employeeAcs;

        #endregion ■ Private member

        #region  ■ Private cost
        //エラー条件メッセージ
        private const string ct_INPUTERROR = "が不正です。";
        private const string ct_NOINPUT = "を入力してください。";
        private const string ct_RANGEERROR = "の範囲指定に誤りがあります。";
        // クラスID
        private const string ct_CLASSID = "PMKHN07210UA";

        private const string PMKHN07210U_PRPID = "PMKHN07210U.xml";
        private const string PRINTSET_TABLE = "EmployeeExp";

        #endregion

        #region ■ IExportConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Method
        /// <summary>
        /// ｴｸｽﾎﾟｰﾄ前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ｴｸｽﾎﾟｰﾄ前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public bool ExportBeforeCheck()
        {
            bool status = true;

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

                status = false;
            }

            return status;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// 抽出データ処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this.uLabel_OutPutNum.Text = "0";
            // 画面→抽出条件クラス
            this.SetExtraInfoFromScreen();
            this.Bind_DataSet.Tables.Clear();
            DataTable dataTable;
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "エクスポート中";
            form.Message = "現在、データをエクスポート中です。";

            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                // 検索
                status = this._employeeExportAcs.Search(_employeeExportWork, out dataTable);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // BLコードクラスをデータセットへ展開する
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN07210U", 						// アセンブリＩＤまたはクラスＩＤ
                            "従業員マスタ（ｴｸｽﾎﾟｰﾄ）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._employeeExportAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// CSV出力情報処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07210U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// ｴｸｽﾎﾟｰﾄ完了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ｴｸｽﾎﾟｰﾄ完了処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");
        }
        #endregion  ◆ Public Method
        #endregion ■ IExportConditionInpType メンバ

        #region ■ Private Event
        #region ◆ ガイド検索
        /// <summary>
        /// 担当者ガイドクリック                                              
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 担当者ガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void ub_St_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.ub_St_EmployeeGuide)
                {
                    this.tEdit_EmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_TextFileName.Focus();
                }
            }
        }

        /// <summary>
        /// 拠点コードガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 拠点コードガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void ub_SectionCodeStGuid_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // 拠点ガイド表示
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (status == 0)
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this.tEdit_SectionCode_St;
                    nextControl = this.tEdit_SectionCode_Ed;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this.tEdit_SectionCode_Ed;
                    nextControl = this.tEdit_EmployeeCode_St;
                }
                else
                {
                    return;
                }
                // コード展開
                targetControl.DataText = secInfoSet.SectionCode.Trim();
                // フォーカス
                nextControl.Focus();
            }
            else
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.ub_SectionCodeStGuid;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    nextControl = this.ub_SectionCodeEdGuid;
                }
                nextControl.Focus();
            }
            
        }
        #endregion

        #region ◆ ファイルダイアログ
        /// <summary>
        /// CSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : CSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 朱宝軍</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // タイトルバーの文字列
                saveFileDialog.Title = "出力ファイル選択";
                saveFileDialog.RestoreDirectory = true;

                if (String.IsNullOrEmpty(this.tEdit_TextFileName.Text.Trim()))
                {
                    saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }

                //「ファイルの種類」を指定
                saveFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }
        #endregion

        #region ◆ ChangeFocus
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 矢印キーでのフォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // 拠点(開始)→拠点(終了)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // 拠点(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→ ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // ファイルダイアログ→ 拠点(開始)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }

                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // 拠点(開始)→ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // 拠点(終了)→拠点(開始)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者(開始)→拠点(終了)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→ 担当者(開始)
                        e.NextCtrl = tEdit_EmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ 担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // ファイルダイアログ→ ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            // Coopyチェック
            WordCoopyCheck();
        }
        #endregion

        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : フォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopyチェック
            WordCoopyCheck();
        }
        #endregion　■ Private Event

        #region ■ Control Event
        /// <summary>
        /// PMKHN07210UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void PMKHN07210UA_Load(object sender, EventArgs e)
        {
            this.InitializeScreen();
            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動 
        }
        #endregion

        #region ■ Private Method
        #region ◎ エラーメッセージ表示処理 ( +1のオーバーロード )
        /// <summary>エラーメッセージ表示処理</summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <remarks>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                "従業員マスタ（ｴｸｽﾎﾟｰﾄ）",			// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 画面初期化処理を行う</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 拠点
            this.tEdit_SectionCode_Ed.Clear();
            this.tEdit_SectionCode_St.Clear();
            // 担当者
            this.tEdit_EmployeeCode_St.Clear();
            this.tEdit_EmployeeCode_Ed.Clear();

            this.SetIconImage(this.ub_St_EmployeeGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_EmployeeGuide, Size16_Index.STAR1);

            this.SetIconImage(this.ub_SectionCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

            // 前回表示状態が保存されていれば上書き
            this.uiMemInput1.ReadMemInput();
            this.tEdit_SectionCode_St.Focus();
        }
        #endregion

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎ 検索情報処理
        /// <summary>
        /// 検索情報処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索情報処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // 企業コード
            _employeeExportWork.EnterpriseCode = this._enterpriseCode;
            // 拠点コード開始
            _employeeExportWork.SectionCdSt = this.tEdit_SectionCode_St.DataText.TrimEnd();

            // 拠点コード終了
            _employeeExportWork.SectionCdEd = this.tEdit_SectionCode_Ed.DataText.TrimEnd();

            // 担当者コード開始
            _employeeExportWork.EmployeeCdSt = AppendZero(this.tEdit_EmployeeCode_St.DataText.TrimEnd(),4);

            // 担当者コード終了
            _employeeExportWork.EmployeeCdEd = AppendZero(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd(),4);
        }
        #endregion

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // Coopyチェック
            WordCoopyCheck();
            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = "テキストファイル名を入力してください。";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            {
                errMessage = "CSVファイルパスが不正です。";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }
            // 拠点（開始～終了）
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText.TrimEnd()) &&
                !String.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.TrimEnd()) &&
                Int32.Parse(this.tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("拠点{0}", ct_RANGEERROR);
                errComponent = this.tEdit_SectionCode_St;
                status = false;
                return status;
            }

            // 担当者（開始～終了）
            string employeeSt = AppendZero(this.tEdit_EmployeeCode_St.DataText.TrimEnd(),4);
            string employeeEd = AppendZero(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd(),4);
            if (!String.IsNullOrEmpty(employeeSt) &&
                !String.IsNullOrEmpty(employeeEd) &&
                employeeSt.CompareTo(employeeEd) == 1)
            {
                errMessage = string.Format("担当者{0}", ct_RANGEERROR);
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
                return status;
            }


            return status;
        }

        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {

            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText.TrimEnd()) && !r.IsMatch(this.tEdit_SectionCode_St.DataText))
            {
                this.tEdit_SectionCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tEdit_SectionCode_Ed.DataText))
            {
                this.tEdit_SectionCode_Ed.Text = String.Empty;
            }
            Regex r1 = new Regex(@"^[\uFF61-\uFF9F-0-9]*$");
            if (!String.IsNullOrEmpty(this.tEdit_EmployeeCode_St.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_EmployeeCode_St.DataText))
            {
                this.tEdit_EmployeeCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_EmployeeCode_Ed.DataText))
            {
                this.tEdit_EmployeeCode_Ed.Text = String.Empty;
            }
        }

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコン設定処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }

        #endregion　■ Private Method


    }
}