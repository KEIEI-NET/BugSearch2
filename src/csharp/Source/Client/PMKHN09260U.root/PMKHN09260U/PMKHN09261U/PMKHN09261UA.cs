using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 与信額設定処理
    /// </summary>
    ///<remarks>
    /// <br>Note        : 与信額設定処理UIフォームクラス</br>
    /// <br>Programmer  : 30418 徳永</br>
    /// <br>Date        : 2008/12/02</br>
    /// <br>Update Note : 2009/03/12 30414 忍 障害ID:12310対応</br>
    /// <br>UpdateNote  : 2013/05/13 zhuhh</br>
    /// <br>            : 2013/06/18配信分</br>
    /// <br>            : Redmine #35501 与信額設定待機仕様の追加</br>
    /// <br>UpDate Note : 王君 2013/05/28</br>
    /// <br>            : Redmine#35501 #10の対応</br>
    /// <br>UpDate Note : 王君 2013/06/24</br>
    /// <br>            : Redmine#35501 #14の対応</br>
    /// <br>UpDate Note : gezh 2013/08/20</br>
    /// <br>            : Redmine#35501 #18の対応</br>
    /// </remarks>
    public partial class PMKHN09261UA : Form
    {

        #region プライベート変数

        #region クラス

        /// <summary>与信額設定処理 抽出条件クラス</summary>
        private CustCreditCndtn _custCreditCndtn = null;

        /// <summary>与信額設定処理 アクセスクラス</summary>
        private CustomerCreditAcs _customerCreditAcs = null;

        /// <summary>得意先検索アクセスクラス</summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>得意先情報データクラス</summary>
        private CustomerInfo _customerInfo;

        /// <summary>MACMN00001C)UIスキン設定コントロール</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        #region データセット

        /// <summary>与信額設定処理 結果データセット</summary>
        private CustomerChangeDataSet _dataSet = null;

        #endregion // データセット

        #endregion // クラス

        /// <summary>ボタン用イメージリスト</summary>
        private ImageList _imageList16 = null;

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = string.Empty;

        /// <summary>ログインユーザーコード</summary>
        private string _loginUserCd = string.Empty;

        /// <summary>ログインユーザー名</summary>
        private string _loginUserName = string.Empty;

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>得意先コード</summary>
        private int _customerCode = 0;

        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
        /// <summary>カウンター</summary>
        private int counter = 0;
        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<

        // ----- ADD 王君 2013/06/24 for Redmine#35501 ----->>>>>
        private bool _waitFlag;
        // ----- ADD 王君 2013/06/24 for Redmine#35501 -----<<<<<
        #endregion // プライベート変数

        #region メッセージ定数

        /// <summary>エラーメッセージ：「得意先が選択されていません。」</summary>
        private const string CT_EMPTY_CUSTOMER_CODE = "得意先が選択されていません。";

        /// <summary>エラーメッセージ：「得意先（開始）は得意先（終了）よりも小さなコードを指定してください。」</summary>
        private const string CT_INVALID_CUSTOMER_CODE = "得意先（開始）は得意先（終了）よりも小さなコードを指定してください。";

        /// <summary>エラーメッセージ：「与信額クリアの対象項目が選択されていません。」</summary>
        private const string CT_MISSING_CLEAR_TARGET = "与信額クリアの対象項目が選択されていません。";

        /// <summary>エラーメッセージ：「開始得意先コードが選択されていません。」</summary>
        private const string CT_CUSTOMER_RANGE_START_MISSING = "開始得意先コードが選択されていません。";

        /// <summary>エラーメッセージ：「終了得意先コードが選択されていません。」</summary>
        private const string CT_CUSTOMER_RANGE_END_MISSING = "終了得意先コードが選択されていません。";

        /// <summary>エラーメッセージ：「指定された得意先コードは存在しません。」</summary>
        private const string CT_CUSTOMER_NOT_FOUND = "指定された得意先コードは存在しません。";

        /// <summary>エラーメッセージ：「更新対象のデータがありません。」</summary>
        private const string CT_RESULT_NOT_FOUND = "更新対象のデータがありません。";

        /// <summary>エラーメッセージ：「 件のデータを処理しました。」</summary>
        private const string CT_RESULT_PROCESSED_COUNT = " 件のデータを処理しました。";

        /// <summary>メッセージ：「更新しても宜しいですか？」</summary>
        private const string CT_READY_TO_PROCESS = "更新しても宜しいですか？";

        // --- ADD 2009/01/15 障害ID:10087対応------------------------------------------------------>>>>>
        /// <summary>エラーメッセージ：「得意先締日の値が不正です。」</summary>
        private const string CT_TOTALDAY_ERROR = "得意先締日の値が不正です。";
        // --- ADD 2009/01/15 障害ID:10087対応------------------------------------------------------<<<<<

        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
        /// <summary>メッセージ：「待機処理を開始してよろしいですか？」</summary>
        private const string CT_READY_TO_WAITNOW = "待機処理を開始してよろしいですか？";

        /// <summary>メッセージ：「待機処理を開始してよろしいですか(処理開始時間は翌日です)？」</summary>
        private const string CT_READY_TO_WAITTOMORROW = "待機処理を開始してよろしいですか？\r\n(処理開始時間は翌日です)";
        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
        #endregion // メッセージ定数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN09261UA()
        {
            InitializeComponent();
            
            // 初期設定
            InitializeVariable();
        }

        /// <summary>
        /// フォーム表示後イベント（初期フォーカス関連）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN09261UA_Shown(object sender, System.EventArgs e)
        {
            // 初期フォーカス（得意先開始）
            this.tNedit_CustomerCd_St.Focus();
        }

        // ----- ADD 王君　2013/06/24　Redmine#35501 ----->>>>>
        /// <summary>
        /// 待機Flag
        /// </summary>
        public bool WaitFlag
        {
            get { return this._waitFlag; }
        }
        // ----- ADD 王君　2013/06/24　Redmine#35501 -----<<<<<
        #endregion // コンストラクタ

        #region 初期配置

        /// <summary>
        /// コントロール類初期配置
        /// </summary>
        private void InitializeVariable()
        {

            #region クラス初期化

            // アクセスクラスを初期化し、データセットを取得
            this._customerCreditAcs = new CustomerCreditAcs();
            this._dataSet = this._customerCreditAcs.DataSet;

            // 検索条件クラス作成
            this._custCreditCndtn = new CustCreditCndtn();

            // アクセスクラス初期化
            this._customerInfoAcs = new CustomerInfoAcs();

            this._waitFlag = false; // ADD 王君 2013/06/24 Redmine#35501
            #endregion // クラス初期化

            #region ボタンイメージ設定

            // イメージリストを指定(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // ボタンイメージを設定
            this.uButton_CustomerCdSingleGuide.ImageList = this._imageList16;
            this.uButton_CustomerCdSingleGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerStGuide.ImageList = this._imageList16;
            this.uButton_CustomerStGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerEdGuide.ImageList = this._imageList16;
            this.uButton_CustomerEdGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // ツールバーアイコン
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 障害ID:12310対応------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SAVE;
            // --- CHG 2009/03/12 障害ID:12310対応------------------------------------------------------<<<<<

            #endregion // ボタンイメージ設定

            #region ログイン情報取得

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // 企業コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // 自拠点コード
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ログインユーザーコード
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ログインユーザー名

            #endregion // ログイン情報取得

            #region コントロールスキン対応

            // UIスキン設定コントロール初期化
            this._controlScreenSkin = new ControlScreenSkin();

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExplorerBar_Main.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // コントロールスキン対応

            // 画面クリア
            InitializeScreen();

        }

        #endregion // 初期配置

        #region 画面の初期化

        /// <summary>
        /// 画面の初期化
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote  : 2013/05/13 zhuhh</br>
        /// <br>            : 2013/06/18配信分</br>
        /// <br>            : Redmine #35501 与信額設定待機仕様の追加</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 全ての項目をクリア
            this.tNedit_CustomerCd_St.Clear();
            this.tNedit_CustomerCd_Ed.Clear();
            this.tNedit_CustomerCd01.Clear();
            this.tNedit_CustomerCd02.Clear();
            this.tNedit_CustomerCd03.Clear();
            this.tNedit_CustomerCd04.Clear();
            this.tNedit_CustomerCd05.Clear();
            this.tNedit_CustomerCd06.Clear();
            this.tNedit_TotalDay.Clear();
            this.uCheckEditor_TargetItem1.Checked = false;
            this.uCheckEditor_TargetItem2.Checked = false;
            this.uCheckEditor_TargetItem3.Checked = false;

            // 件数ラベルをクリア
            this.uLabel_ProcessCount.Text = "0";

            // データセットもクリア
            this._dataSet.CustomerChange.Clear();

            // コンボボックスを初期値に戻す
            this.tComboEditor_CustomerSelectDiv.SelectedIndex = 0;
            this.tComboEditor_ProcessDiv.SelectedIndex = 0;

            // フィールドの有効化
            this.tComboEditor_CustomerSelectDiv_ValueChanged(null, null);

            // ログインユーザー名表示
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;

            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
            this.ultraButton_Prepare.Visible = true;
            this.ultraButton_StopPrepare.Visible = false;
            this.ultraLabel_Message.Visible = false;
            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
        }

        #endregion // 画面の初期化

        #region 画面→パラメータ作成

        /// <summary>
        /// 画面→パラメータ作成
        /// </summary>
        private void GetParameters()
        {
            // パラメータをクリア
            this._custCreditCndtn.EnterpriseCode = string.Empty;
            this._custCreditCndtn.St_CustomerCode = 0;
            this._custCreditCndtn.Ed_CustomerCode = 0;
            this._custCreditCndtn.CustomerCodes = null;
            this._custCreditCndtn.ProcDiv = 0;
            this._custCreditCndtn.TotalDay = 0;
            this._custCreditCndtn.WarningCrdMnyFrg = false;
            this._custCreditCndtn.AccRecDiv = false;
            this._custCreditCndtn.CreditMoneyFlg = false;

            // 企業コード
            this._custCreditCndtn.EnterpriseCode = this._enterpriseCode;

            // 得意先区分から取得するパラメータを判断
            if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0) // 範囲
            {
                // 範囲
                this._custCreditCndtn.St_CustomerCode = this.tNedit_CustomerCd_St.GetInt();
                this._custCreditCndtn.Ed_CustomerCode = this.tNedit_CustomerCd_Ed.GetInt();
            }
            else
            {
                // 単独(６つまで)
                ArrayList array = new ArrayList();
                int custCd;

                custCd = this.tNedit_CustomerCd01.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd02.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd03.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd04.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd05.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd06.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }

                // 配列に変換
                int[] custCodes = new int[array.Count];
                for (int count = 0; count < array.Count; count++)
                {
                    custCodes[count] = (int)array[count];
                }
                this._custCreditCndtn.CustomerCodes = custCodes;
            }

            // 締日
            if (this.tNedit_TotalDay.GetInt() > 0)
            {
                this._custCreditCndtn.TotalDay = this.tNedit_TotalDay.GetInt();
            }

            // 処理区分
            this._custCreditCndtn.ProcDiv = (int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue;

            // 与信額フラグ
            this._custCreditCndtn.CreditMoneyFlg = this.uCheckEditor_TargetItem1.Checked;

            // 警告与信額フラグ
            this._custCreditCndtn.WarningCrdMnyFrg = this.uCheckEditor_TargetItem2.Checked;

            // 現在売掛残高フラグ
            this._custCreditCndtn.AccRecDiv = this.uCheckEditor_TargetItem3.Checked;

        }

        #endregion // 画面→パラメータ作成

        #region パラメータチェック

        /// <summary>
        /// パラメータチェック関数
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private Control CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // パラメータが必須のものをチェック

            // 得意先がない [9180]
            //if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
            //{
            //    if (this._custCreditCndtn.St_CustomerCode == 0
            //    && this._custCreditCndtn.Ed_CustomerCode == 0)
            //    {
            //        errorMsg = CT_EMPTY_CUSTOMER_CODE;
            //        return this.tNedit_CustomerCd_St;
            //    }
            //}
            //else
            //{
            //    if (this._custCreditCndtn.CustomerCodes.Length == 0)
            //    {
            //        errorMsg = CT_EMPTY_CUSTOMER_CODE;
            //        return this.tNedit_CustomerCd01;
            //    }
            //}

            // 単独なのにひとつもない
            if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 1
                && this._custCreditCndtn.CustomerCodes.Length == 0)
            {
                errorMsg = CT_EMPTY_CUSTOMER_CODE;
                return this.tNedit_CustomerCd01;
            }

            // 与信額クリアなのにチェックされていない
            if (this._custCreditCndtn.ProcDiv == 1
                && !this._custCreditCndtn.CreditMoneyFlg
                && !this._custCreditCndtn.WarningCrdMnyFrg
                && !this._custCreditCndtn.AccRecDiv)
            {
                errorMsg = CT_MISSING_CLEAR_TARGET;
                return this.uCheckEditor_TargetItem1;
            }

            // 得意先の範囲チェック
            if (this._custCreditCndtn.St_CustomerCode > this._custCreditCndtn.Ed_CustomerCode)
            {
                errorMsg = CT_INVALID_CUSTOMER_CODE;
                return this.tNedit_CustomerCd_St;
            }

            // --- ADD 2009/01/15 障害ID:10087対応------------------------------------------------------>>>>>
            // 得意先締日チェック
            if (this.tNedit_TotalDay.GetInt() > 31)
            {
                errorMsg = CT_TOTALDAY_ERROR;
                return this.tNedit_TotalDay;
            }
            // --- ADD 2009/01/15 障害ID:10087対応------------------------------------------------------<<<<<

            return null;
        }

        #endregion // パラメータチェック

        #region 得意先存在チェック

        /// <summary>
        /// 得意先存在チェック
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private bool CustomerExistCheck(int customerCode)
        {
            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        #endregion // 得意先存在チェック

        #region 検索

        /// <summary>
        /// 検索
        /// </summary>
        private void Search()
        {
            // メッセージ消去
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;

            // 画面から検索条件クラスを作成
            GetParameters();

            // パラメータチェック
            string errorMsg = string.Empty;
            Control errorControl = CheckParameter(out errorMsg);
            if (errorControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                errorControl.Focus();
                return;
            }
            else
            {
                // 確認メッセージを表示 [9183] 順番を変更[9401]
                DialogResult result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, "PMKHN09261U",
                                                CT_READY_TO_PROCESS, 0, MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                int recordCount = 0;

                // データセットをクリア
                this._dataSet.CustomerChange.Clear();

                // 検索実行
                int status = this._customerCreditAcs.Search(this._custCreditCndtn, out recordCount);

                if (status == ((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    if (recordCount == 0)
                    {
                        // 処理件数が0の時は、該当データなしのメッセージを表示
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                        this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
                    }
                    else
                    {
                        // 処理件数を表示する場合は、このコメントを外す
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_RESULT_PROCESSED_COUNT;
                        this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0");

                        // 更新完了ダイアログを表示 [9184]
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                    }
                }
                else if (status == ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))         
                {
                    // 処理件数が0の時は、該当データなしのメッセージを表示 [9185]
                    this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                    this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
                }
                else
                {
                    // エラー時はメッセージ？
                }
            }
        }

        #endregion // 検索

        # region グループ圧縮・展開

        /// <summary>
        /// グループ圧縮イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uExplorerBar_Main_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uExplorerBar_Main_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // 常にキャンセル
            e.Cancel = true;
        }

        # endregion グループ圧縮・展開

        #region 得意先ガイドボタン

        /// <summary>
        /// 得意先ガイド（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerStGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 得意先コード受け取り
                this.tNedit_CustomerCd_St.SetInt(this._customerCode);
                this._customerCode = 0; //リセット
                this.tNedit_CustomerCd_Ed.Focus();
            }
        }

        /// <summary>
        /// 得意先ガイド（終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerEdGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 得意先コード受け取り
                this.tNedit_CustomerCd_Ed.SetInt(this._customerCode);
                this._customerCode = 0; //リセット
                this.tNedit_TotalDay.Focus();
            }
        }

        /// <summary>
        /// 得意先ガイド(単独)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCdSingleGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 得意先コード受け取り
                if (this._customerCode > 0)
                {
                    if (this.tNedit_CustomerCd01.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd01.SetInt(this._customerCode);
                        this._customerCode = 0; //リセット
                        this.tNedit_CustomerCd02.Focus();
                    }
                    else if (this.tNedit_CustomerCd02.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd02.SetInt(this._customerCode);
                        this._customerCode = 0; //リセット
                        this.tNedit_CustomerCd03.Focus();
                    }
                    else if (this.tNedit_CustomerCd03.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd03.SetInt(this._customerCode);
                        this._customerCode = 0; //リセット
                        this.tNedit_CustomerCd04.Focus();
                    }
                    else if (this.tNedit_CustomerCd04.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd04.SetInt(this._customerCode);
                        this._customerCode = 0; //リセット
                        this.tNedit_CustomerCd05.Focus();
                    }
                    else if (this.tNedit_CustomerCd05.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd05.SetInt(this._customerCode);
                        this._customerCode = 0; //リセット
                        this.tNedit_CustomerCd06.Focus();
                    }
                    else if (this.tNedit_CustomerCd06.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd06.SetInt(this._customerCode);
                        this._customerCode = 0; //リセット
                        this.tNedit_TotalDay.Focus();
                    }
                    else
                    {
                        // 6つとも埋まっていた場合はスルー
                    }
                }
            }
        }

        #endregion // 得意先ガイドボタン

        #region 得意先選択ガイドボタンクリック時イベント

        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out this._customerInfo);

            // ステータスによりエラーメッセージを出力
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (_customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "選択した得意先は既に削除されています。",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "得意先情報の取得に失敗しました。",
                    status, MessageBoxButtons.OK);
                return;
            }

            // 得意先情報を変数に設定
            this._customerCode = _customerInfo.CustomerCode;
        }

        #endregion // 得意先選択ガイドボタンクリック時イベント

        #region 得意先選択区分切替

        /// <summary>
        /// 得意先選択区分切替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustomerSelectDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
            {
                // 範囲
                this.tNedit_CustomerCd01.Enabled = false;
                this.tNedit_CustomerCd02.Enabled = false;
                this.tNedit_CustomerCd03.Enabled = false;
                this.tNedit_CustomerCd04.Enabled = false;
                this.tNedit_CustomerCd05.Enabled = false;
                this.tNedit_CustomerCd06.Enabled = false;
                this.uButton_CustomerCdSingleGuide.Enabled = false;

                this.tNedit_CustomerCd_St.Enabled = true;
                this.tNedit_CustomerCd_Ed.Enabled = true;
                this.uButton_CustomerStGuide.Enabled = true;
                this.uButton_CustomerEdGuide.Enabled = true;
            }
            else
            {
                // 単独
                this.tNedit_CustomerCd_St.Enabled = false;
                this.tNedit_CustomerCd_Ed.Enabled = false;
                this.uButton_CustomerStGuide.Enabled = false;
                this.uButton_CustomerEdGuide.Enabled = false;

                this.tNedit_CustomerCd01.Enabled = true;
                this.tNedit_CustomerCd02.Enabled = true;
                this.tNedit_CustomerCd03.Enabled = true;
                this.tNedit_CustomerCd04.Enabled = true;
                this.tNedit_CustomerCd05.Enabled = true;
                this.tNedit_CustomerCd06.Enabled = true;
                this.uButton_CustomerCdSingleGuide.Enabled = true;
            }
        }

        #endregion // 得意先選択区分切替

        #region 処理区分切替

        /// <summary>
        /// 処理区分切替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ProcessDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue == 0)
            {
                // 現在売掛残高設定
                if (this.uCheckEditor_TargetItem1.Checked) this.uCheckEditor_TargetItem1.Checked = false;
                if (this.uCheckEditor_TargetItem2.Checked) this.uCheckEditor_TargetItem2.Checked = false;
                if (this.uCheckEditor_TargetItem3.Checked) this.uCheckEditor_TargetItem3.Checked = false;
                this.uCheckEditor_TargetItem1.Enabled = false;
                this.uCheckEditor_TargetItem2.Enabled = false;
                this.uCheckEditor_TargetItem3.Enabled = false;
            }
            else
            {
                // 与信額クリア
                this.uCheckEditor_TargetItem1.Enabled = true;
                this.uCheckEditor_TargetItem2.Enabled = true;
                this.uCheckEditor_TargetItem3.Enabled = true;
            }
        }

        #endregion  // 処理区分切替

        #region ツールバー

        /// <summary>
        /// ツールバー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region 終了ボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                #endregion // 終了ボタン

                #region 確定ボタン
                case "ButtonTool_Decision":
                    {
                        Search();
                        break;
                    }
                #endregion // 確定ボタン

                default: break;
            }
        }

        #endregion // ツールバー

        #region アローキーコントロール

        /// <summary>
        /// アローキーコントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>UpdateNote  : 2013/05/13 zhuhh</br>
        /// <br>            : 2013/06/18配信分</br>
        /// <br>            : Redmine #35501 与信額設定待機仕様の追加</br>
        /// <br>UpdateNote  : 王君 2013/05/28</br>
        /// <br>            : Redmine#35501 #10の対応</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 名前により分岐
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // フィールド間移動
                //---------------------------------------------------------------

                #region 得意先（開始）
                case "tNedit_CustomerCd_St":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                            // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        if (this.tNedit_CustomerCd_St.GetInt() > 0)
                                        {
                                            //if (CustomerExistCheck(this.tNedit_CustomerCd_St.GetInt()))
                                            //{
                                            e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                            //}
                                            //else
                                            //{
                                            //    // 存在しなければエラーメッセージを表示
                                            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                            //        CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                            //    // 入力された値をクリア
                                            //    this.tNedit_CustomerCd_St.Clear();

                                            //    // ガイドへ遷移
                                            //    e.NextCtrl = this.uButton_CustomerStGuide;
                                            //}
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerStGuide;
                                        }
                                        break;
                                    }
                            }
                            // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else
                        {
                            // -----ADD　王君 2013/05/28  Redmine#35501 ----->>>>>
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.ultraButton_Prepare;
                                        break;
                                    }
                            }
                            // -----ADD 王君 2013/05/28 for Redmine#35501 -----<<<<<
                            // e.NextCtrl = null; // DEL 王君 2013/05/28 for Redmine#35501
                        }
                         // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 得意先（開始）

                #region 得意先（開始）ガイド
                case "uButton_CustomerStGuide":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                    break;
                                }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd_St;
                                        break;
                                    }
                            }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 得意先（開始）ガイド

                #region 得意先（終了）
                case "tNedit_CustomerCd_Ed":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (this.tNedit_CustomerCd_Ed.GetInt() > 0)
                                    {
                                        //if (CustomerExistCheck(this.tNedit_CustomerCd_Ed.GetInt()))
                                        //{
                                            e.NextCtrl = this.tNedit_TotalDay;
                                        //}
                                        //else
                                        //{
                                        //    // 存在しなければエラーメッセージを表示
                                        //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                        //        CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                        //    // 入力された値をクリア
                                        //    this.tNedit_CustomerCd_Ed.Clear();

                                        //    // ガイドへ遷移
                                        //    e.NextCtrl = this.uButton_CustomerEdGuide;

                                            //// 存在しなければガイドを開く
                                            //this.tNedit_CustomerCd_Ed.Clear();
                                            //this.uButton_CustomerStGuide_Click(null, null);
                                            //if (this.tNedit_CustomerCd_Ed.GetInt() > 0)
                                            //{
                                            //    e.NextCtrl = this.tNedit_TotalDay;
                                            //}
                                            //else
                                            //{
                                            //    e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                            //}
                                        //}
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_CustomerEdGuide;
                                    }
                                    break;
                                }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.uButton_CustomerStGuide;
                                        break;
                                    }
                            }                            
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 得意先（終了）

                #region 得意先（終了）ガイド
                case "uButton_CustomerEdGuide":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                    break;
                                }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:

                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                        break;
                                    }
                            }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 得意先（終了）ガイド

                #region 得意先（単独）1
                case "tNedit_CustomerCd01":
                    {
                        // Shift + Tab/Enterで逆進行
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd01.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd01.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd02;
                                            }
                                            else
                                            {
                                                // 存在しなければエラーメッセージを表示
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // 入力された値をクリア
                                                this.tNedit_CustomerCd01.Clear();

                                                // ガイドへ遷移
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd02;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 得意先（単独）1

                #region 得意先（単独）2
                case "tNedit_CustomerCd02":
                    {
                        // Shift + Tab/Enterで逆進行
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd02.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd02.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd03;
                                            }
                                            else
                                            {
                                                // 存在しなければエラーメッセージを表示
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // 入力された値をクリア
                                                this.tNedit_CustomerCd02.Clear();

                                                // ガイドへ遷移
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd03;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd01;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 得意先（単独）2

                #region 得意先（単独）3
                case "tNedit_CustomerCd03":
                    {
                        // Shift + Tab/Enterで逆進行
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd03.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd03.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd04;
                                            }
                                            else
                                            {
                                                // 存在しなければエラーメッセージを表示
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // 入力された値をクリア
                                                this.tNedit_CustomerCd03.Clear();

                                                // ガイドへ遷移
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd04;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd02;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 得意先（単独）3

                #region 得意先（単独）4
                case "tNedit_CustomerCd04":
                    {
                        // Shift + Tab/Enterで逆進行
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd04.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd04.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd05;
                                            }
                                            else
                                            {
                                                // 存在しなければエラーメッセージを表示
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // 入力された値をクリア
                                                this.tNedit_CustomerCd04.Clear();

                                                // ガイドへ遷移
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd05;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd03;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 得意先（単独）4

                #region 得意先（単独）5
                case "tNedit_CustomerCd05":
                    {
                        // Shift + Tab/Enterで逆進行
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd05.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd05.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd06;
                                            }
                                            else
                                            {
                                                // 存在しなければエラーメッセージを表示
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // 入力された値をクリア
                                                this.tNedit_CustomerCd05.Clear();

                                                // ガイドへ遷移
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd06;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd04;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 得意先（単独）5

                #region 得意先（単独）6
                case "tNedit_CustomerCd06":
                    {
                        // Shift + Tab/Enterで逆進行
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd06.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd06.GetInt()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                            else
                                            {
                                                // 存在しなければエラーメッセージを表示
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // 入力された値をクリア
                                                this.tNedit_CustomerCd06.Clear();

                                                // ガイドへ遷移
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        //e.NextCtrl = this.tNedit_CustomerCd06;// DEL zhuhh 2013/05/13 for Redmine#35501
                                        e.NextCtrl = this.tNedit_CustomerCd05;// ADD zhuhh 2013/05/13 for Redmine#35501
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 得意先（単独）6

                #region 得意先（単独）ガイド
                case "uButton_CustomerCdSingleGuide":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_TotalDay;
                                    break;
                                }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd06;
                                        break;
                                    }
                            } 
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 得意先（単独）ガイド

                #region 得意先選択区分
                case "tComboEditor_CustomerSelectDiv":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
                                        {
                                            // 範囲の時は単独項目は移動不可
                                            e.NextCtrl = this.tNedit_TotalDay;
                                        }
                                        else
                                        {
                                            // 単独の時はそちらへ
                                            e.NextCtrl = this.tNedit_CustomerCd01;
                                        }
                                        break;
                                    }
                            }
                            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
                                        {
                                            e.NextCtrl = this.uButton_CustomerEdGuide;
                                        }
                                        else
                                        {
                                            //e.NextCtrl = null;// DEL 王君 2013/05/28 Redmine#35501
                                            e.NextCtrl = this.ultraButton_Prepare;// ADD 王君 2013/05/28 Redmine#35501
                                        }
                                        break;
                                    }
                            }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 得意先選択区分

                #region 締日
                case "tNedit_TotalDay":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tComboEditor_ProcessDiv;
                                    break;
                                }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
                                        {
                                            e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                        }
                                        break;
                                    }
                            }    
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 締日

                #region 処理区分
                case "tComboEditor_ProcessDiv":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                case Keys.Down: // ADD zhuhh 2013/05/13 for Redmine#35501
                                {
                                    // 与信額クリア時以外はチェックに行かない
                                    if ((int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue == 0)
                                    {
                                            //e.NextCtrl = null;//DEL zhuhh 2013/05/13 for Redmine#35501
                                            e.NextCtrl = this.tEdit_Hour;// ADD zhuhh 2013/05/13 for Redmine#35501
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uCheckEditor_TargetItem1;
                                    }

                                    break;
                                }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_TotalDay;
                                        break;
                                    }
                            }     
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 処理区分

                #region 与信額クリア
                case "uCheckEditor_TargetItem1":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.uCheckEditor_TargetItem2;
                                    break;
                                }
                            case Keys.Space:
                                {
                                    // チェックボックスを反転して次へ
                                    this.uCheckEditor_TargetItem1.Checked = !this.uCheckEditor_TargetItem1.Checked;
                                    e.NextCtrl = this.uCheckEditor_TargetItem2;
                                    break;
                                }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tComboEditor_ProcessDiv;
                                        break;
                                    }
                            }   
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 与信額クリア

                #region 警告与信額
                case "uCheckEditor_TargetItem2":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.uCheckEditor_TargetItem3;
                                    break;
                                }
                            case Keys.Space:
                                {
                                    // チェックボックスを反転して次へ
                                    this.uCheckEditor_TargetItem2.Checked = !this.uCheckEditor_TargetItem2.Checked;
                                    e.NextCtrl = this.uCheckEditor_TargetItem3;
                                    break;
                                }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.uCheckEditor_TargetItem1;
                                        break;
                                    }
                            }   
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 警告与信額

                #region 現在売掛残高
                case "uCheckEditor_TargetItem3":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                        //e.NextCtrl = null;// DEL zhuhh 2013/05/13 for Redmine#35501
                                        e.NextCtrl = this.tEdit_Hour;// ADD zhuhh 2013/05/13 for Redmine#35501
                                    break;
                                }
                            case Keys.Space:
                                {
                                    // チェックボックスを反転して次へ
                                    this.uCheckEditor_TargetItem3.Checked = !this.uCheckEditor_TargetItem3.Checked;
                                    e.NextCtrl = null;
                                    break;
                                }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.uCheckEditor_TargetItem2;
                                        break;
                                    }
                            }   
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // 現在売掛残高

                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                #region 処理開始時間時
                case "tEdit_Hour":
                    {
                        // ----- ADD 王君 2013/05/28 Redmine#35501 ---->>>>>
                        string hour = this.tEdit_Hour.Text.Trim();
                        if (hour.Length == 1)
                        {
                            hour = hour.PadLeft(2, '0');
                            this.tEdit_Hour.Text = hour;
                        }
                        // ----- ADD 王君 2013/05/28 Redmine#35501 ----<<<<<
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_Minute;
                                        break;
                                    }
                            }
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue == 0)
                                        {
                                            e.NextCtrl = this.tComboEditor_ProcessDiv;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uCheckEditor_TargetItem3;
                                        }
                                        break;
                                    }
                            }                            
                        }
                        break;
                    }
                #endregion

                #region 処理開始時間分
                case "tEdit_Minute":
                    {
                        // ----- ADD 王君 2013/05/28 Redmine#35501 ---->>>>>
                        string mimute = this.tEdit_Minute.Text.Trim();
                        if (mimute.Length == 1)
                        {
                            mimute = mimute.PadLeft(2, '0');
                            this.tEdit_Minute.Text = mimute;
                        }
                        // ----- ADD 王君 2013/05/28 Redmine#35501 ----<<<<<
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.ultraButton_Prepare.Visible)
                                        {
                                            e.NextCtrl = this.ultraButton_Prepare;
                                        }
                                        else if (this.ultraButton_StopPrepare.Visible)
                                        {
                                            e.NextCtrl = this.ultraButton_StopPrepare;
                                        }
                                        break;
                                    }
                            }
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region 待機
                case "ultraButton_Prepare":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        //e.NextCtrl = null; // DEL 王君 2013/05/28 Redmine#35501
                                        // ----- ADD 王君 2013/05/28 Redmine#35501 ----->>>>>
                                        if (this.tNedit_CustomerCd_St.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd_St;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                        }
                                             // ----- ADD 王君 2013/05/28 Redmine#35501 -----<<<<<
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_Minute;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region 中止
                case "ultraButton_StopPrepare":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion
                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                default: break;
            }
        }

        #endregion // アローキーコントロール
          
        #region [待機]
        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 与信額設定待機処理を行います。</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: 王君 2013/05/28</br>
        /// <br>           : Redmine#35501 #10の対応</br>
        /// <br>UpDate Note: 王君 2013/06/24</br>
        /// <br>           : Redmine#35501 #14の対応</br>
        /// </remarks>
        private void ultraButton_Prepare_Click(object sender, EventArgs e)
        {
            DialogResult result;
            //ToolbarsSetting(false); DEL 王君 2013/05/28 Redmine#35501
            // 画面から検索条件クラスを作成
            GetParameters();
            // パラメータチェック
            string errorMsg = string.Empty;
            Control errorControl = CheckParameter(out errorMsg);
            if (errorControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09261U",
                               errorMsg, 0, MessageBoxButtons.OK);
                errorControl.Focus();
                ToolbarsSetting(true);
                return;
            }
            else 
            {
                if (checkStartTime(this.tEdit_Hour.Text, this.tEdit_Minute.Text))
                {
                    if ((Int32.Parse(this.tEdit_Hour.Text) > System.DateTime.Now.Hour) || (Int32.Parse(this.tEdit_Hour.Text) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.Text) >= System.DateTime.Now.Minute))
                    {
                        result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, "PMKHN09261U",
                                                    CT_READY_TO_WAITNOW, 0, MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, "PMKHN09261U",
                                                    CT_READY_TO_WAITTOMORROW, 0, MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        ToolbarsSetting(false); // ADD 王君 2013/05/28 Redmine#35501
                        // 得意先範囲
                        this.tNedit_CustomerCd_St.Enabled = false;
                        this.uButton_CustomerStGuide.Enabled = false;
                        this.tNedit_CustomerCd_Ed.Enabled = false;
                        this.uButton_CustomerEdGuide.Enabled = false;

                        //得意先単独
                        this.tComboEditor_CustomerSelectDiv.Enabled = false;
                        this.tNedit_CustomerCd01.Enabled = false;
                        this.tNedit_CustomerCd02.Enabled = false;
                        this.tNedit_CustomerCd03.Enabled = false;
                        this.tNedit_CustomerCd04.Enabled = false;
                        this.tNedit_CustomerCd05.Enabled = false;
                        this.tNedit_CustomerCd06.Enabled = false;
                        this.uButton_CustomerCdSingleGuide.Enabled = false;

                        //得意先締日
                        this.tNedit_TotalDay.Enabled = false;
                        //処理区分
                        this.tComboEditor_ProcessDiv.Enabled = false;
                        //対象項目
                        this.uCheckEditor_TargetItem1.Enabled = false;
                        this.uCheckEditor_TargetItem2.Enabled = false;
                        this.uCheckEditor_TargetItem3.Enabled = false;
                        //処理開始時間
                        this.tEdit_Hour.Enabled = false;
                        this.tEdit_Minute.Enabled = false;

                        this.ultraButton_Prepare.Visible = false;
                        this.ultraButton_StopPrepare.Visible = true;
                        this.ultraLabel_Message.Visible = true;
                        this.ultraButton_StopPrepare.Focus(); // ADD 王君 2013/05/28 Redmine#35501

                        this._waitFlag = true; // ADD 王君 2013/06/24 Redmine#35501

                        this.timer_ShowOrNot.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : Tick イベント</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: gezh 2013/08/20</br>
        /// <br>           : Redmine#35501 #18の対応</br>
        /// </remarks>
        private void timer_ShowOrNot_Tick(object sender, EventArgs e)
        {
            counter = counter + 1;
            if (Int32.Parse(this.tEdit_Hour.DataText.Trim()) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.DataText.Trim()) == System.DateTime.Now.Minute)
            {
                counter = 0;
                this.timer_ShowOrNot.Stop();
                if (this.tComboEditor_CustomerSelectDiv.SelectedIndex == 0)
                {
                    // 得意先範囲
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd_St.Enabled = true;
                    this.uButton_CustomerStGuide.Enabled = true;
                    this.tNedit_CustomerCd_Ed.Enabled = true;
                    this.uButton_CustomerEdGuide.Enabled = true;
                }
                else
                {
                    //得意先単独
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd01.Enabled = true;
                    this.tNedit_CustomerCd02.Enabled = true;
                    this.tNedit_CustomerCd03.Enabled = true;
                    this.tNedit_CustomerCd04.Enabled = true;
                    this.tNedit_CustomerCd05.Enabled = true;
                    this.tNedit_CustomerCd06.Enabled = true;
                    this.uButton_CustomerCdSingleGuide.Enabled = true;
                }
                if (this.tComboEditor_ProcessDiv.SelectedIndex == 0)
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                }
                else
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                    this.uCheckEditor_TargetItem1.Enabled = true;
                    this.uCheckEditor_TargetItem2.Enabled = true;
                    this.uCheckEditor_TargetItem3.Enabled = true;
                }
                //得意先締日
                this.tNedit_TotalDay.Enabled = true;
                //処理開始時間
                this.tEdit_Hour.Enabled = true;
                this.tEdit_Minute.Enabled = true;

                this.ultraButton_Prepare.Visible = true;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraLabel_Message.Visible = false;
                ToolbarsSetting(true);
                SearchAuto();
                this.tEdit_Hour.Focus();
                this._waitFlag = false; // ADD gezh 2013/08/20 Redmine#35501
            }
            else 
            {
                if (counter % 4 == 0)
                {
                    this.ultraLabel_Message.Visible = false;
                }
                else
                {
                    this.ultraLabel_Message.Visible = true;
                }
            }
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 月与信額設定処理待機状態の解除を行います。</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: 王君 2013/06/24</br>
        /// <br>           : Redmine#35501 #14の対応</br>
        /// </remarks>
        private void ultraButton_StopPrepare_Click(object sender, EventArgs e)
        {
            DialogResult result = TMsgDisp.Show(
                                 this, 								            // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_QUESTION, 		    // エラーレベル
                                 "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                 "待機処理を中止してよろしいですか？",     // 表示するメッセージ
                                 0, 									            // ステータス値
                                 MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // 表示するボタン
            if (result == DialogResult.No)
            {
                return;
            }
            else 
            {
                counter = 0;
                this.timer_ShowOrNot.Stop();
                this._waitFlag = false;// ADD 王君　2013/06/24 Redmine#35501
                if (this.tComboEditor_CustomerSelectDiv.SelectedIndex == 0)
                {
                    // 得意先範囲
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd_St.Enabled = true;
                    this.uButton_CustomerStGuide.Enabled = true;
                    this.tNedit_CustomerCd_Ed.Enabled = true;
                    this.uButton_CustomerEdGuide.Enabled = true;
                }
                else
                {
                    //得意先単独
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd01.Enabled = true;
                    this.tNedit_CustomerCd02.Enabled = true;
                    this.tNedit_CustomerCd03.Enabled = true;
                    this.tNedit_CustomerCd04.Enabled = true;
                    this.tNedit_CustomerCd05.Enabled = true;
                    this.tNedit_CustomerCd06.Enabled = true;
                    this.uButton_CustomerCdSingleGuide.Enabled = true;
                }
                if (this.tComboEditor_ProcessDiv.SelectedIndex == 0)
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                }
                else
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                    this.uCheckEditor_TargetItem1.Enabled = true;
                    this.uCheckEditor_TargetItem2.Enabled = true;
                    this.uCheckEditor_TargetItem3.Enabled = true;
                }
                //得意先締日
                this.tNedit_TotalDay.Enabled = true;
                //処理開始時間
                this.tEdit_Hour.Enabled = true;
                this.tEdit_Minute.Enabled = true;

                this.ultraButton_Prepare.Visible = true;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraLabel_Message.Visible = false;

                ToolbarsSetting(true);

                this.tEdit_Hour.Focus();
            }
        }

        /// <summary>
        /// タイマー入力チェック
        /// </summary>
        /// <br>Programer   : zhuhh</br>
        /// <br>Date	    : 2013/05/13</br>
        /// <returns>ステータス</returns>
        private bool checkStartTime(string hour, string minute)
        {
            bool checkFlg = true;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^\\d{2}$");
            if (!string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour) || !regex.IsMatch(minute))
                {
                    TMsgDisp.Show(
                                   this, 								            // 親ウィンドウフォーム
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                   "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                   "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                   0, 									            // ステータス値
                                   MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                0, 									            // ステータス値
                                MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(minute) < 0 || Int32.Parse(minute) > 59)
                {
                    TMsgDisp.Show(
                                this, 								            // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                0, 									            // ステータス値
                                MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Minute.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(hour) <= 5 || Int32.Parse(hour) >= 23 || (Int32.Parse(hour) == 6 && Int32.Parse(minute) == 0))
                {
                    TMsgDisp.Show(
                                 this, 								            // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                 "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                 "23時00分～06時00分はメンテナンス時間の為、設定出来ません。",     // 表示するメッセージ
                                 0, 									            // ステータス値
                                 MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
            }
            else if (string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                    this, 								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                    "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                    "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                    0, 									            // ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (!string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour))
                {
                    TMsgDisp.Show(
                                   this, 								            // 親ウィンドウフォーム
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                   "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                   "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                   0, 									            // ステータス値
                                   MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                0, 									            // ステータス値
                                MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                TMsgDisp.Show(
                                    this, 								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                    "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                    "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                    0, 									            // ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン
                this.tEdit_Minute.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                        this, 								            // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                        "PMKHN09261U", 						                // アセンブリＩＤまたはクラスＩＤ
                                        "処理開始時間を入力してください。",     // 表示するメッセージ
                                        0, 									            // ステータス値
                                        MessageBoxButtons.OK);				            // 表示するボタン
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }

            return checkFlg;
        }

        /// <summary>
        /// ツールバーの表示・有効設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの有効・無効設定を行います。</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// </remarks>
        private void ToolbarsSetting(bool flag)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonDecisionTool;
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonCloseTool;

            buttonDecisionTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            buttonCloseTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];

            buttonDecisionTool.SharedProps.Enabled = flag;
            buttonCloseTool.SharedProps.Enabled = flag;
        }

        /// <summary>
        /// 検索
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索を行います。</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: 王君 2013/05/28</br>
        /// <br>           : Redmine#35501 #10の対応</br>
        /// </remarks>
        private void SearchAuto()
        {
            // メッセージ消去
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;
          
            int recordCount = 0;

            // データセットをクリア
            this._dataSet.CustomerChange.Clear();

            // 検索実行
            int status = this._customerCreditAcs.Search(this._custCreditCndtn, out recordCount);

            if (status == ((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                if (recordCount == 0)
                {
                    // 処理件数が0の時は、該当データなしのメッセージを表示
                    this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                    this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
                }
                else
                {
                    // 処理件数を表示する場合は、このコメントを外す
                    this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_RESULT_PROCESSED_COUNT;
                    this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0");

                    // 更新完了ダイアログを表示 [9184]
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                }
            }
            else if (status == ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                // 処理件数が0の時は、該当データなしのメッセージを表示 [9185]
                this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
            }
            else
            {
                // エラー時はメッセージ？
            }
            // ----- ADD 王君 2013/05/28 Redmine#35501 ----->>>>>
            this.tEdit_Hour.Clear();
            this.tEdit_Minute.Clear();
            // ----- ADD 王君 2013/05/28 Redmine#35501 -----<<<<<
        }
        #endregion
    }
}