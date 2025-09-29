//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/06/19  修正内容 : 画面締日の日>=28時、31とします
//                                  画面の拠点範囲指定は削除（非表示）へ変更
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 李侠
// 修 正 日  2014/04/18  修正内容 : PM.NS仕掛一覧No2370
//                                  Redmine#42500 テキスト項目が８個未満の対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : WUPF
// 修 正 日  2014/10/30  修正内容 : Redmine#43866
//                                  スペースがセットされていると不一致 障害対応の修正の修正
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 呉鵬飛
// 修 正 日  2014/12/26  修正内容 : Redmine43866 #17
//                                  スペースがセットされていると不一致 障害対応の修正の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入チェックリストUIクラス                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入チェックリストUIで、抽出条件を入力します。</br>       
    /// <br>Programmer : 張莉莉</br>                                   
    /// <br>Date       : 2009.05.10</br> 
    /// <br>Update Note: 2014/04/18 李侠</br>
    /// <br>管理番号   ：10904597-00 PM.NS仕掛一覧No2370</br>
    /// <br>             Redmine#42500　テキスト項目が８個未満の対応</br>
    /// </remarks>
    public partial class PMKOU02050UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 仕入チェックリストUIクラスコンストラクタ　　　　　　　　　　　　　　　　　　 　
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入チェックリストUI初期化およびインスタンスの生成を行う</br>                 
        /// <br>Programmer : 張莉莉</br>                                  
        /// <br>Date       : 2009.05.10</br>                                     
        /// </remarks>
        public PMKOU02050UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点を取得
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
            this._billAllStAcs = new BillAllStAcs();
            this._billAllStDic = new Dictionary<string, BillAllSt>();

            // 請求全体設定マスタ読込
            LoadBillAllSt();
        }

        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member

        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;
        // 設定ボタン表示有無プロパティ
        private bool _visibledSetButton = true;
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        // ログイン情報
        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private StockSlipCndtn _stockSlipCndtn;

        //日付取得部品
        private DateGetAcs _dateGet;

        //エラーチェック
        private bool hasCheckError = false;

        //ファイルデータ
        private ArrayList _csvData;

        private DateTime stData_st;
        private DateTime stData_ed;

        private Dictionary<string, BillAllSt> _billAllStDic;

        private BillAllStAcs _billAllStAcs;

        // 抽出条件前回入力値(更新有無チェック用)
        private Int32 _tmpSupplierCode;
        // 現在のコントロール
        private Control _prevControl = null;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        // クラスID
        private const string ct_ClassID = "PMKOU02050UA";
        // プログラムID
        private const string ct_PGID = "PMKOU02050U";
        // 帳票名称
        private const string PDF_PRINT_NAME = "仕入チェックリスト";
        private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "156cc2cb-3afc-45bc-ac54-5017c884fa2f";
        private string _printKey = PDF_PRINT_KEY;
        #endregion ◆ Interface member

        /// <summary>PMKHN09022A)仕入先</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>PMKHN09021E)仕入先情報データクラス</summary>
        private Supplier _supplier = null;

        //エラー条件メッセージ
        const string ct_InputError = "は正しくありません。";
        const string ct_NoInput = "を指定してください。";
        const string ct_RangeError = "の範囲に誤りがあります。";

        #endregion

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// <summary> 抽出ボタン状態取得プロパティ </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF出力ボタン状態取得プロパティ </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> 印刷ボタン状態取得プロパティ </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無プロパティ </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示プロパティ </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        /// <summary> 設定ボタン表示プロパティ </summary>
        public bool VisibledSetButton
        {
            get { return this._visibledSetButton; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
            return 0;
        }
        #endregion

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            int status = -1;
            if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 0)
            {
                this._csvData = null;
                //ファイルデータ
                if (null == this._csvData || 0 == this._csvData.Count)
                {
                    status = this.GetCsvData(out _csvData);
                }
                else
                {
                    status = 0;
                }

                if (status == -1)
                {

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "指定されたファイルは存在しません。",
                        status,
                        MessageBoxButtons.OK);
                    this.tEdit_FileName.Focus();
                    return status;
                }
                if (status == -2)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "テキスト形式が異なります。",
                       status,
                       MessageBoxButtons.OK);
                    this.tComboEditor_TextTypeDiv.Focus();
                    return status;
                }
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._stockSlipCndtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion


        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_CheckSectionDiv);
            saveCtrAry.Add(this.tComboEditor_TextTypeDiv);
            saveCtrAry.Add(this.tComboEditor_SupDayCheckDiv);
            saveCtrAry.Add(this.tComboEditor_SectionCdCheckDiv);
            saveCtrAry.Add(this.tComboEditor_SlipNumCheckDiv);
            saveCtrAry.Add(this.tComboEditor_PrintDiv);
            saveCtrAry.Add(this.tEdit_FileName);
            saveCtrAry.Add(this.tNedit_SupplierCd);
            saveCtrAry.Add(this.tEdit_SupplierName);
            saveCtrAry.Add(this.ultraButton_SectionChangeSet);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            if (this._prevControl != null)
            {
                hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            bool status = true;

            if (hasCheckError)
            {
                status = false;
                return status;
            }

            string errMessage = "";
            Control errComponent = null;

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
        #endregion

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypeSelectedSection メンバ
        #region ◆ Public Property

        /// <summary> 本社機能プロパティ </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> 拠点オプションプロパティ </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> 計上拠点選択表示取得プロパティ </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method

        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // 拠点を選択した時
            if (checkState == CheckState.Checked)
            {
                // 全社が選択された場合
                if (sectionCode == "0")
                {
                    this._selectedSectionList.Clear();

                }

                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, sectionCode);
                }
            }
            // 拠点選択を解除した時
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #region ◎ 初期選択拠点設定処理
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // 選択リスト初期化
            this._selectedSectionList.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, wk);
            }
        }
        #endregion

        #region ◎ 初期拠点選択表示チェック処理
        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
        /// <remarks>
        /// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
        /// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            //return isDefaultState;
            return false;  // UPD 2009/06/18 画面の拠点範囲指定は削除（非表示）へ変更
        }
        #endregion

        #region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypeSelectedSection メンバ

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return _printName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tEdit_FileName.DataText = string.Empty;
                this.tNedit_SupplierCd.DataText = string.Empty;

                // 初期値セット・ドロップダウンリスト
                Infragistics.Win.ValueListItem listItem;
                // チェック区分
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "ＰＭ／仕入先";
                this.tComboEditor_CheckSectionDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "仕入データ重複";
                this.tComboEditor_CheckSectionDiv.Items.Add(listItem);

                this.tComboEditor_CheckSectionDiv.Value = 0;

                // テキスト形式
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "CSV";
                this.tComboEditor_TextTypeDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "TAB";
                this.tComboEditor_TextTypeDiv.Items.Add(listItem);

                this.tComboEditor_TextTypeDiv.Value = 0;

                // 仕入日チェック
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "なし";
                this.tComboEditor_SupDayCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "あり";
                this.tComboEditor_SupDayCheckDiv.Items.Add(listItem);

                this.tComboEditor_SupDayCheckDiv.Value = 0;

                // 拠点チェック
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "なし";
                this.tComboEditor_SectionCdCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "あり";
                this.tComboEditor_SectionCdCheckDiv.Items.Add(listItem);

                this.tComboEditor_SectionCdCheckDiv.Value = 0;

                // 伝票番号チェック
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "通常";
                this.tComboEditor_SlipNumCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "上6桁のみ";
                this.tComboEditor_SlipNumCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "下6桁のみ";
                this.tComboEditor_SlipNumCheckDiv.Items.Add(listItem);

                this.tComboEditor_SlipNumCheckDiv.Value = 0;

                // 印刷区分
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "全て";
                this.tComboEditor_PrintDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "不一致分";
                this.tComboEditor_PrintDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "一致分";
                this.tComboEditor_PrintDiv.Items.Add(listItem);

                this.tComboEditor_PrintDiv.Value = 0;

                // 日付
                // 画面締日を元に「締日算出モジュール」を使用して、支払締日の開始日～終了日を取得する。

                TotalDayCalculator ttlDayCalc = TotalDayCalculator.GetInstance();
                status = ttlDayCalc.InitializeHisPayment();
                DateTime stDate;
                DateTime edDate;
                int convert;
                // 締日取得処理
                status = ttlDayCalc.GetHisTotalDayPayment(string.Empty, out stDate, out edDate, out convert, out stData_st);

                stData_ed = stDate;

                this.tde_St_AddUpDate.SetDateTime(stData_st);
                this.tde_Ed_AddUpDate.SetDateTime(stDate);
                this.tde_TotalDay.SetDateTime(stDate);

                // ボタン設定
                this.SetIconImage(this.ultraButton_FileName, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SupplierGuide, Size16_Index.STAR1);

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();
                if (!string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
                {
                    this._tmpSupplierCode = Convert.ToInt32(this.tNedit_SupplierCd.Text.Trim());
                }
                else
                {
                    this._tmpSupplierCode = 0;
                }


                // 初期フォーカスセット
                this.tComboEditor_CheckSectionDiv.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 印刷前処理
        #region ◎ 入力チェック処理

        /// <summary>
        /// 日付範囲チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;

            int checkCode = (int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue;

            // 対象日付（開始～終了）
            if (checkCode == 0 && CallCheckDateRange(out cdrResult, ref tde_St_AddUpDate, ref tde_Ed_AddUpDate) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("対象日付(開始){0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("対象日付(開始){0}", ct_InputError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("対象日付(終了){0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("対象日付(終了){0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象日付{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                }
                status = false;
                this.tde_St_AddUpDate.ResetText();
                this.tde_Ed_AddUpDate.ResetText();
                return status;
            }

            // 締日
            if (checkCode == 0)
            {
                if (this.tde_TotalDay.GetLongDate() == 0)
                {
                    errMessage = string.Format("締日{0}", ct_NoInput);
                    errComponent = this.tde_TotalDay;
                    status = false;
                    this.tde_TotalDay.ResetText();
                    return status;
                }
            }
            // 締日
            if ((this.tde_TotalDay.GetLongDate() != 0) && (TDateTime.IsAvailableDate(this.tde_TotalDay.GetDateTime()) == false))
            {
                errMessage = string.Format("締日{0}", ct_InputError);
                errComponent = this.tde_TotalDay;
                status = false;
                this.tde_TotalDay.ResetText();
                return status;
            }
            // 入力値の「日」が請求全体設定の「処理対象締日」に存在しない場合、エラーメッセージ表示する。
            if (this.tde_TotalDay.GetLongDate() != 0)
            {
                int day = this.tde_TotalDay.GetDateDay();

                BillAllSt billAllSt;
                // 対象拠点の請求全体設定マスタを取得
                billAllSt = this._billAllStDic["00"];

                if (day >= 28)
                {
                    if ((28 > billAllSt.CustomerTotalDay1) && (28 > billAllSt.CustomerTotalDay2) &&
                        (28 > billAllSt.CustomerTotalDay3) && (28 > billAllSt.CustomerTotalDay4) &&
                        (28 > billAllSt.CustomerTotalDay5) && (28 > billAllSt.CustomerTotalDay6) &&
                        (28 > billAllSt.CustomerTotalDay7) && (28 > billAllSt.CustomerTotalDay8) &&
                        (28 > billAllSt.CustomerTotalDay9) && (28 > billAllSt.CustomerTotalDay10) &&
                        (28 > billAllSt.CustomerTotalDay11) && (28 > billAllSt.CustomerTotalDay12))
                    {
                        errMessage = "請求全体設定の処理対象締日に該当締日がありません。";
                        errComponent = this.tde_TotalDay;
                        return (false);
                    }
                }
                else
                {
                    if ((day != billAllSt.SupplierTotalDay1) && (day != billAllSt.SupplierTotalDay2) &&
                        (day != billAllSt.SupplierTotalDay3) && (day != billAllSt.SupplierTotalDay4) &&
                        (day != billAllSt.SupplierTotalDay5) && (day != billAllSt.SupplierTotalDay6) &&
                        (day != billAllSt.SupplierTotalDay7) && (day != billAllSt.SupplierTotalDay8) &&
                        (day != billAllSt.SupplierTotalDay9) && (day != billAllSt.SupplierTotalDay10) &&
                        (day != billAllSt.SupplierTotalDay11) && (day != billAllSt.SupplierTotalDay12))
                    {
                        errMessage = "請求全体設定の処理対象締日に該当締日がありません。";
                        errComponent = this.tde_TotalDay;
                        return (false);
                    }
                }
            }

            // テキストファイル名 
            if (checkCode == 0 && string.IsNullOrEmpty(this.tEdit_FileName.Text))
            {
                //errMessage = "ファイルが未入力のため、出力できない。";
                errMessage = "ファイル名が未入力の為、出力できません。";
                errComponent = this.tEdit_FileName;
                status = false;
                return status;
            }

            // 仕入先 
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
            {
                errMessage = string.Format("仕入先{0}", ct_NoInput);
                errComponent = this.tNedit_SupplierCd;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// 請求全体設定マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定マスタを取得します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private int LoadBillAllSt()
        {
            int status = 0;

            try
            {
                ArrayList retList;

                status = this._billAllStAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BillAllSt billAllSt in retList)
                    {
                        this._billAllStDic.Add(billAllSt.SectionCode.Trim(), billAllSt);
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #endregion

        #region ◎ CSVファイル処理

        /// <summary>
        /// CSV情報取得処理
        /// </summary>
        /// <param name="data">ファイルデータ</param>
        /// <returns>STATUS（-1:ファイル存在しない,-2:テキスト形式が異なる）</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// <br>Update Note: 2014/04/18 李侠</br>
        /// <br>管理番号   ：10904597-00 PM.NS仕掛一覧No2370</br>
        /// <br>             Redmine#42500　テキスト項目が８個未満の対応</br>
        /// <br>Update Note: 2014/10/30 WUPF</br>
        /// <br>管理番号   ：11070149-00  Redmine#43866</br>
        /// <br>           ：スペースがセットされていると不一致 障害対応の修正の修正</br>
        /// <br>Update Note: 2014/12/26 呉鵬飛</br>
        /// <br>管理番号   ：11070149-00  Redmine43866 #17</br>
        /// <br>           ：スペースがセットされていると不一致 障害対応の修正の修正</br>
        /// </remarks>
        public int GetCsvData(out ArrayList data)
        {
            data = new ArrayList();
            string fileName = this.tEdit_FileName.Text;
            // テキストファイル存在しなかった場合
            if (!File.Exists(fileName))
            {
                return -1;
            }
            StreamReader sr;

            char splitStr;
            // テキストファイルの形式
            if ((int)this.tComboEditor_TextTypeDiv.SelectedItem.DataValue == 0)
            {
                // カンマ区切り
                splitStr = ',';

            }
            else
            {
                // TAB区切り
                splitStr = '	';
            }

            try
            {
                sr = new StreamReader(fileName, Encoding.GetEncoding("shift_jis"));

                StockSlipTextData stockSlipTextData = null;
                string nowYear1 = DateTime.Now.ToString("yyyyMMdd").Substring(0, 3);
                string nowYear2 = DateTime.Now.ToString("yyyyMMdd").Substring(0, 2);

                while (sr.Peek() >= 0)
                {
                    string lineText = sr.ReadLine();

                    if (lineText.Trim().Length != 0)
                    {
                        stockSlipTextData = new StockSlipTextData();
                        string[] csvData = new string[10];
                        csvData = lineText.Split(splitStr);
                        // 仕入日
                        // ADD 呉鵬飛 2014/12/26 Redmine43866 #17 スペースがセットされていると不一致 障害対応の修正の修正 ---->>>>>
                        if (csvData[2] != null)
                        {
                            csvData[2] = csvData[2].Trim();
                        }
                        // ADD 呉鵬飛 2014/12/26 Redmine43866 #17 スペースがセットされていると不一致 障害対応の修正の修正 ----<<<<<
                        bool dateIsNum = IsNum(csvData[2]);
                        if (dateIsNum)
                        {
                            // 仕入日変換
                            if (csvData[2].Length == 5)
                            {
                                stockSlipTextData.StockDate = nowYear1 + csvData[2];
                            }
                            else if (csvData[2].Length == 6)
                            {
                                stockSlipTextData.StockDate = nowYear2 + csvData[2];
                            }
                            else if (csvData[2].Length == 8)
                            {
                                stockSlipTextData.StockDate = csvData[2];
                            }
                            else
                            {
                                stockSlipTextData.StockDate = "17000101";
                            }

                            try
                            {
                                DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                            }
                            catch
                            {
                                stockSlipTextData.StockDate = "17000101";
                            }
                        }
                        else
                        {
                            stockSlipTextData.StockDate = "17000101";
                        }

                        // 仕入伝票№
                        //stockSlipTextData.SupplierSlipNo = csvData[3];// DEL WUPF 2014/10/30 Redmine#43866 スペースがセットされていると不一致 障害対応の修正の修正

                        // ADD WUPF 2014/10/30 Redmine#43866 スペースがセットされていると不一致 障害対応の修正の修正 ---->>>>>
                        if (csvData[3] != null)
                        {
                            stockSlipTextData.SupplierSlipNo = csvData[3].Trim();
                        }
                        else
                        {
                            stockSlipTextData.SupplierSlipNo = csvData[3];
                        }
                        // ADD WUPF 2014/10/30 Redmine#43866 スペースがセットされていると不一致 障害対応の修正の修正 ----<<<<<

                        // 仕入金額
                        stockSlipTextData.StockPrice = Convert.ToInt64(csvData[4]);
                        // 営業所コード
                        string zero = "0000000000";
                        // --- ADD 2014/04/18 PM.NS仕掛一覧No2370  テキスト項目が８個未満の対応---------->>>>>
                        if (csvData.Length <= 6)
                        {
                            stockSlipTextData.StockSectionCd = zero;
                        }
                        else
                        {
                        // --- ADD 2014/04/18 PM.NS仕掛一覧No2370  テキスト項目が８個未満の対応---------->>>>>
                            if (!string.IsNullOrEmpty(csvData[6]))
                            {
                                bool cdIsNum = IsNum(csvData[6].Trim());
                                if (cdIsNum)
                                {
                                    if (csvData[6].Trim().Length < 10)
                                    {
                                        stockSlipTextData.StockSectionCd = zero.Substring(0, (10 - csvData[6].Trim().Length)) + csvData[6].Trim();
                                    }
                                    else
                                    {
                                        stockSlipTextData.StockSectionCd = csvData[6].Trim().Substring(0, 10);
                                    }

                                }
                                else
                                {
                                    stockSlipTextData.StockSectionCd = zero;
                                }
                            }
                            else
                            {
                                stockSlipTextData.StockSectionCd = zero;
                            }
                        }//ADD 2014/04/18 PM.NS仕掛一覧No2370  テキスト項目が８個未満の対応

                        // --- DEL 2014/04/18 PM.NS仕掛一覧No2370  テキスト項目が８個未満の対応---------->>>>>
                        //// 備考
                        //stockSlipTextData.Note = csvData[7];
                        // --- DEL 2014/04/18 PM.NS仕掛一覧No2370  テキスト項目が８個未満の対応----------<<<<<
                        // --- ADD 2014/04/18 PM.NS仕掛一覧No2370  テキスト項目が８個未満の対応---------->>>>>
                        try
                        {
                            // 備考
                            stockSlipTextData.Note = csvData[7];
                        }
                        catch
                        {
                            // 備考
                            stockSlipTextData.Note = string.Empty;
                        }
                        // --- ADD 2014/04/18 PM.NS仕掛一覧No2370  テキスト項目が８個未満の対応----------<<<<<

                        stockSlipTextData.IsChecked = false;
                        // 仕入先からの請求データ(テキストファイル)の抽出範囲を設定
                        if (DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null) >= this.tde_St_AddUpDate.GetDateTime()
                            && DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null) <= this.tde_Ed_AddUpDate.GetDateTime())
                        {
                            data.Add(stockSlipTextData);
                        }

                    }
                }
                return 0;
            }
            catch
            {
                return -2;
            }
        }


        /// <summary>
        /// 全てNUMの判断処理
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>false：NUM以外存在；true：全てNUM</returns>
        /// <remarks>
        /// <br>Note       : 全てNUMの判断処理する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public bool IsNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str, i))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion ◎ CSVファイル処理

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._stockSlipCndtn = new StockSlipCndtn();
            try
            {
                // 企業コード
                this._stockSlipCndtn.EnterpriseCode = this._enterpriseCode;
                // 「全拠点」が選択されている場合はリストをクリア
                bool allSections = false;

                foreach (object obj in _selectedSectionList.Values)
                {
                    if (obj is string)
                    {
                        if ((obj as string) == "0")
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if (allSections)
                {
                    _selectedSectionList.Clear();
                }

                // 拠点オプション
                this._stockSlipCndtn.IsOptSection = this._isOptSection;
                // 計上拠点コード（複数指定）
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._stockSlipCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // チェック区分
                this._stockSlipCndtn.CheckSectionDiv = (StockSlipCndtn.CheckSectionDivState)this.tComboEditor_CheckSectionDiv.Value;

                // 対象日付
                if (!DateTime.MinValue.Equals(this.tde_TotalDay.GetDateTime()))
                {
                    int day = this.tde_TotalDay.GetDateDay();
                    
                    if (day >= 28)
                    {
                        this._stockSlipCndtn.St_addUpDate = this.tde_TotalDay.GetDateTime().AddDays(1-day);
                        this._stockSlipCndtn.Ed_addUpDate = this.tde_TotalDay.GetDateTime().AddDays(1 - day).AddMonths(1).AddDays(-1);
                    }
                    else
                    {
                        this._stockSlipCndtn.St_addUpDate = this.tde_TotalDay.GetDateTime().AddMonths(-1).AddDays(1);
                        this._stockSlipCndtn.Ed_addUpDate = this.tde_TotalDay.GetDateTime();
                    }
                    
                }
                else
                {
                    this._stockSlipCndtn.St_addUpDate = this.stData_ed.AddDays(1);

                }

                this._stockSlipCndtn.St_addUpDateShow = this.tde_St_AddUpDate.GetDateTime();
                this._stockSlipCndtn.Ed_addUpDateShow = this.tde_Ed_AddUpDate.GetDateTime();


                // 締日
                this._stockSlipCndtn.TotalDay = this.tde_TotalDay.GetDateTime();

                // 仕入日チェック
                this._stockSlipCndtn.SupDayCheckDiv = (StockSlipCndtn.SupDayCheckDivState)this.tComboEditor_SupDayCheckDiv.SelectedItem.DataValue;

                // 拠点チェック
                this._stockSlipCndtn.SectionCdCheckDiv = (StockSlipCndtn.SectionCdCheckDivState)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue;

                // 伝票番号チェック
                this._stockSlipCndtn.SlipNumCheckDiv = (StockSlipCndtn.SlipNumCheckDivState)this.tComboEditor_SlipNumCheckDiv.SelectedItem.DataValue;

                // 印刷区分
                this._stockSlipCndtn.PrintDiv = (StockSlipCndtn.PrintDivState)this.tComboEditor_PrintDiv.SelectedItem.DataValue;

                // 仕入先コード
                this._stockSlipCndtn.SupplierCd = this.tNedit_SupplierCd.GetInt();

                // 仕入先名
                this._stockSlipCndtn.SupplierNm = this.tEdit_SupplierName.Text;

                // CSVデータ
                this._stockSlipCndtn.CsvData = this._csvData;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion ◆ 印刷前処理

        #region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
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
        #endregion

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
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
        #endregion
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #endregion ■ Private Method

        # region Control Events

        /// <summary>
        /// PMKOU02050UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void PMKOU02050UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ガイドボタンのアイコン設定
            this.SetIconImage(this.ultraButton_FileName, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SupplierGuide, Size16_Index.STAR1);

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);
        }
        # endregion

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 入力ファイル名ボタンをクリックした時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // タイトルバーの文字列
                    openFileDialog.Title = "仕入先請求データファイル選択";
                    openFileDialog.RestoreDirectory = true;
                    if (this.tEdit_FileName.Text.Trim() == string.Empty)
                    {
                        openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                    }
                    else
                    {
                        openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_FileName.Text);
                        openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_FileName.Text);
                    }

                    //「ファイルの種類」を指定
                    openFileDialog.Filter = "テキストファイル (*.TXT)|*.TXT|すべてのファイル (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_FileName.Text = openFileDialog.FileName;
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 仕入先ガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_SupplierGuide_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド表示
            int status = 0;
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }
            status = this._supplierAcs.ExecuteGuid(out _supplier, this._enterpriseCode, "");

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd.SetInt(_supplier.SupplierCd);
                this.tEdit_SupplierName.Text = _supplier.SupplierSnm.Trim();
                _tmpSupplierCode = _supplier.SupplierCd;
                this.tComboEditor_CheckSectionDiv.Focus();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Text = "";
            }
        }

        /// <summary>
        /// チェック区分　変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CheckSectionDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 1)
            {
                // チェック区分が仕入データ重複の場合
                this.tde_St_AddUpDate.Enabled = false;
                this.tde_Ed_AddUpDate.Enabled = false;
                this.tComboEditor_TextTypeDiv.Enabled = false;
                this.tEdit_FileName.Enabled = false;
                this.ultraButton_FileName.Enabled = false;
                this.ultraButton_SectionChangeSet.Enabled = false;
                this.tComboEditor_SlipNumCheckDiv.Enabled = false;
                this.tComboEditor_PrintDiv.Enabled = false;
            }
            else if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 0)
            {
                // チェック区分がPM/仕入先の場合
                this.tde_St_AddUpDate.Enabled = true;
                this.tde_Ed_AddUpDate.Enabled = true;
                this.tComboEditor_TextTypeDiv.Enabled = true;
                this.tEdit_FileName.Enabled = true;
                this.ultraButton_FileName.Enabled = true;
                this.tComboEditor_SlipNumCheckDiv.Enabled = true;
                // 拠点チェックがありの場合
                this.ultraButton_SectionChangeSet.Enabled = true;
                this.tComboEditor_PrintDiv.Enabled = true;

                if (this.tComboEditor_SectionCdCheckDiv.SelectedItem != null)
                {
                    if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 0)
                    {
                        // 拠点チェックがなしの場合
                        this.ultraButton_SectionChangeSet.Enabled = false;
                    }
                    else if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 1)
                    {
                        // 拠点チェックがありの場合
                        this.ultraButton_SectionChangeSet.Enabled = true;
                    }
                }

            }
        }

        /// <summary>
        /// 拠点チェック　変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SectionCdCheckDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 0)
            {
                if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 0)
                {
                    // 拠点チェックがなしの場合
                    this.ultraButton_SectionChangeSet.Enabled = false;
                }
                else if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 1)
                {
                    // 拠点チェックがありの場合
                    this.ultraButton_SectionChangeSet.Enabled = true;
                }
            }

        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            if (e.NextCtrl != this.ueb_MainExplorerBar)
            {
                this._prevControl = e.NextCtrl;
            }
            switch (e.PrevCtrl.Name)
            {
                // 仕入先コード
                case "tNedit_SupplierCd":
                    {
                        int code = this.tNedit_SupplierCd.GetInt();
                        string name = this.tEdit_SupplierName.Text.Trim();

                        if (this._tmpSupplierCode != code)
                        {
                            if (code == 0)
                            {
                                this._tmpSupplierCode = code;
                                name = "";

                                this.tNedit_SupplierCd.SetInt(code);
                                this.tEdit_SupplierName.Text = name;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.ub_SupplierGuide;
                                }
                            }
                            else
                            {
                                Supplier supplier;
                                if (this._supplierAcs == null)
                                {
                                    this._supplierAcs = new SupplierAcs();
                                }
                                int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._tmpSupplierCode = code;
                                    this.tNedit_SupplierCd.SetInt(code);
                                    this.tEdit_SupplierName.Text = supplier.SupplierSnm;
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tComboEditor_CheckSectionDiv;
                                    }

                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "仕入先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    hasCheckError = true;
                                    this.tNedit_SupplierCd.SetInt(_tmpSupplierCode);

                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                        // e.NextCtrl = this.ub_SupplierGuide;
                                        e.NextCtrl = e.PrevCtrl;
                                        // ↑ 2009.07.07 劉洋 modify
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "仕入先の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);
                                    hasCheckError = true;
                                    this.tNedit_SupplierCd.SetInt(_tmpSupplierCode);
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.ub_SupplierGuide;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (code == 0)
                            {
                                this._tmpSupplierCode = code;
                                name = "";

                                this.tNedit_SupplierCd.SetInt(code);
                                this.tEdit_SupplierName.Text = name;

                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.ub_SupplierGuide;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 1)
                                        {
                                            e.NextCtrl = this.tComboEditor_SectionCdCheckDiv;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ultraButton_FileName;
                                        }

                                    }
                                }


                            }
                        }
                        break;
                    }
                case "ub_SupplierGuide":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {

                                e.NextCtrl = this.tNedit_SupplierCd;
                            }
                        }
                        break;
                    }
                case "tComboEditor_CheckSectionDiv":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.ub_SupplierGuide;
                            }
                        }
                        break;
                    }
            }

        }

        /// <summary>
        /// Control.Click イベント(New_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 新規ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 張莉莉</br>
        /// <br>Date        : 2009.05.10</br>
        /// </remarks>
        private void ultraButton_SectionChangeSet_Click(object sender, EventArgs e)
        {
            PMKOU02050UB pmkou02050 = new PMKOU02050UB();
            DialogResult dialogResult = pmkou02050.ShowDialog(this);
        }

        /// <summary>
        /// エクスプローラーバー グループ縮小 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// エクスプローラーバー グループ展開 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが展開される前に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

    }
}
