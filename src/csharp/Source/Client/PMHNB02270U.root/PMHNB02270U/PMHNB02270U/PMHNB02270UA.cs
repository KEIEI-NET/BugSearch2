//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売掛残高一覧表(総括)
// プログラム概要   : 売掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/03/10     修正内容：Mantis.15089 処理月の初期表示が「現在処理月」にならない件の修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：liyp
// 修正日    2010/12/20     修正内容：初期表示の処理月が前回処理月になっていない件の修正
// ---------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;
// --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
using Broadleaf.Application.Resources;
using System.Text.RegularExpressions;
using System.IO;
// --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売掛残高一覧表(総括) UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高一覧表(総括) UIフォームクラス</br>
    /// <br></br>
    /// <br>UpdateNote :   11570208-00 軽減税率対応</br>
    /// <br>Programmer :   3H 劉星光</br>
    /// <br>Date	   :   2020/04/10</br>
    /// </remarks>
	public partial class PMHNB02270UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
        /// 売掛残高一覧表(総括) UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br></br>
		/// </remarks>
		public PMHNB02270UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 売掛残高一覧表(総括)アクセスクラス
            this._sumBillBalanceAcs = new SumBillBalanceAcs();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // ログイン担当者
            this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		#region ◆ Interface member
		//--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract				= false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf					= true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint					= true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton		= false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton			= true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton		= true;

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd		= false;
        // 拠点オプション有無
        private bool _isOptSection				= false;
        // 本社機能有無
        private bool _isMainOfficeFunc			= false;
		// 選択拠点リスト
        private Hashtable _selectedSectionList	= new Hashtable();
		#endregion ◆ Interface member

		// 拠点コード
		private string _enterpriseCode = "";
        // 売掛残高一覧表(総括)アクセスクラス
        private SumBillBalanceAcs _sumBillBalanceAcs;

        // 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 得意先ガイド用
		private string _customerTag = "";

        // 担当者ガイド
        private EmployeeAcs _employeeAcs;

        // ユーザーガイドアクセスクラス
        private UserGuideAcs _userGuideAcs;

        // 日付取得部品
        private DateGetAcs _dateGet;

        private Employee _loginEmployee = null;

        // 前回月次処理年月(これを基準とする)
        private DateTime _baseDate;
        
		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID = "PMHNB02270UA";
		// プログラムID
        private const string ct_PGID = "PMHNB02270U";
		// 帳票名称
        private const string ct_PrintName = "売掛残高一覧表(総括)";
        // 帳票キー	
        private const string ct_PrintKey        = "32dd64d0-337b-40fe-810f-cc6f416e21f9";
		#endregion ◆ Interface member

   		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintOderGroup			= "PrintOderGroup";			// ソート順
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
        private const string ct_ExBarGroupNm_SalesPrintGroup = "SalesPrintGroup";               // 売掛印刷条件

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        // 税率設定ファイル
        private const string ct_PrintXmlFileName = "TaxRate_UserSetting.XML";
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
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

		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 抽出処理
		/// <summary>
        /// 抽出処理
        /// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>0( 固定 )</returns>
		public int Extract ( ref object parameter )
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
        /// <br></br>
        /// <br>Update Note : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/04/10</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            // 税率内訳印字メッセージ追加
            if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_ClassID, "消費税率別の内訳を印字すると、処理が遅くなる可能性があります。\nよろしいですか？", 0, MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return -1;
                }
            }
            // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

			SFCMN06001U printDialog	= new SFCMN06001U();		// 帳票選択ガイド
			SFCMN06002C printInfo	= parameter as SFCMN06002C;	// 印刷情報パラメータ

			// 企業コードをセット
			printInfo.enterpriseCode	= this._enterpriseCode;
			printInfo.kidopgid			= ct_PGID;				// 起動PGID

			// PDF出力履歴用
			printInfo.key				= ct_PrintKey;
			printInfo.prpnm				= ct_PrintName;
			printInfo.PrintPaperSetCd	= 0;
			// 抽出条件クラス
            SumExtrInfo_BillBalance extrInfo = new SumExtrInfo_BillBalance();

			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen( extrInfo );
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= extrInfo;
			printDialog.PrintInfo		= printInfo;
			
			// 帳票選択ガイド
			DialogResult dialogResult = printDialog.ShowDialog();

			if( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) {
				MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0 );
			}

			 parameter = printInfo;

			return printInfo.status;
		}
		#endregion

		#region ◎ 印刷前確認処理
		/// <summary>
		/// 印刷前確認処理
		/// </summary>
		/// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br></br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

			if( !this.ScreenInputCheck( ref errMessage, ref errComponent ) )
			{
				// メッセージを表示
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

				// コントロールにフォーカスをセット
				if( errComponent != null ) {
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
        /// <br></br>
        /// </remarks>
		public void Show ( object parameter )
		{
			// Todo:起動パラメータを変更する場合はここで行う。
			this.Show();
			return;
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
        /// <br></br>
        /// </remarks>
		public void CheckedSection ( string sectionCode, CheckState checkState )
		{
            // 拠点を選択した時
            if ( checkState == CheckState.Checked )
            {
                // 全社が選択された場合
                if ( sectionCode == "0" )
                {
                    this._selectedSectionList.Clear();
                }

                if ( !this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Add( sectionCode, sectionCode );
                }
            }
            // 拠点選択を解除した時
            else if ( checkState == CheckState.Unchecked )
            {
                if ( this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Remove( sectionCode );
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
        /// <br></br>
        /// </remarks>
		public void InitSelectAddUpCd ( int addUpCd )
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
        /// <br></br>
        /// </remarks>
		public void InitSelectSection ( string[] sectionCodeLst )
		{
            // 選択リスト初期化
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
                this._selectedSectionList.Add( wk, wk );
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
        /// <br></br>
        /// </remarks>
		public bool InitVisibleCheckSection ( bool isDefaultState )
		{
            return isDefaultState;
		}
		#endregion

		#region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br></br>
        /// </remarks>
		public void SelectedAddUpCd (int addUpCd )
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
            get { return ct_PrintKey; }
		}

        /// <summary> 帳票名プロパティ </summary>
		public string PrintName
		{
            get { return ct_PrintName; }
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
        /// <br>Update Note : 2010/12/20 liyp </br>
        /// <br>  初期表示の処理月が前回処理月になっていない</br>
        /// <br></br>
        /// <br>Update Note : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/04/10</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

   			try
			{
                // 処理月の設定
                this.AddUpYearMonth_tDateEdit.DateFormat = emDateFormat.df4Y2M;
                
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                // 2010/03/10 >>>
                //totalDayCalculator.InitializeHisMonthly();
                //totalDayCalculator.GetHisTotalDayMonthly(this._loginEmployee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out this._baseDate, out currentTotalMonth);
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec("", out prevTotalDay, out currentTotalDay, out this._baseDate, out currentTotalMonth);
                // 2010/03/10 <<<
                // ------------UPD 2010/12/20 ------------>>>>>
                //if (currentTotalMonth != DateTime.MinValue)
                //{
                //    // 今回締処理月を設定
                //    this.AddUpYearMonth_tDateEdit.SetDateTime(currentTotalMonth);
                //}
                //else
                //{
                //    // 現在処理年月を設定
                //    DateTime nowYearMonth;
                //    _dateGet.GetThisYearMonth(out nowYearMonth);
                //    this.AddUpYearMonth_tDateEdit.SetDateTime(nowYearMonth);
                //}

                if (this._baseDate != DateTime.MinValue)
                {
                    // 前回締処理月を設定
                    this.AddUpYearMonth_tDateEdit.SetDateTime(this._baseDate);
                }
                else
                {
                    this.AddUpYearMonth_tDateEdit.SetDateTime(DateTime.MinValue);
                }
                // ------------UPD 2010/12/20 ------------<<<<<
                // 改頁
                this.tComboEditor_NewPageType.Value = 0;
                // 入金区分
                this.DepositDtl_tComboEditor.Value = 0;
                
                // 得意先コード
				this.tNedit_CustomerCode_St.Clear();
				this.tNedit_CustomerCode_Ed.Clear();
                // 販売エリアコード
                this.tNedit_SalesAreaCode_St.Clear();
                this.tNedit_SalesAreaCode_Ed.Clear();
                // 担当者コード
                this.tEdit_EmployeeCode_St.DataText = "";
                this.tEdit_EmployeeCode_Ed.DataText = "";
                // 担当者区分
                this.InitializeEmployeeKindDiv();
                // 金額出力
                this.tce_OutMoneyDiv.SelectedIndex = 0;

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 税別内訳印字区分
                this.tComboEditor_TaxPrintDiv.SelectedIndex = 1;
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

        #region ◎ 出力順初期化処理
        /// <summary>
        /// 出力順初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 出力順の初期化を行う</br>
        /// <br></br>
        /// </remarks>
        private void InitializeSortOrderDiv()
        {
            // 出力順
            this.tce_SortOrderDiv.Items.Clear();
            // 得意先順
            this.tce_SortOrderDiv.Items.Add(SumExtrInfo_BillBalance.SortOrderDivState.CustomerCode, SumExtrInfo_BillBalance.ct_SortOrderDiv_CustomerCode);
            // 担当者順
            this.tce_SortOrderDiv.Items.Add(SumExtrInfo_BillBalance.SortOrderDivState.EmployeeCode, SumExtrInfo_BillBalance.ct_SortOrderDiv_Employee);
            // 地区順
            this.tce_SortOrderDiv.Items.Add(SumExtrInfo_BillBalance.SortOrderDivState.SalesAreaCode, SumExtrInfo_BillBalance.ct_SortOrderDiv_SalesAreaCode);

            this.tce_SortOrderDiv.MaxDropDownItems = this.tce_SortOrderDiv.Items.Count;
            this.tce_SortOrderDiv.SelectedIndex = 0;
        }
        #endregion

        #region ◎ 担当者区分初期化処理
        /// <summary>
        /// 担当者区分初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 担当者区分の初期化を行う</br>
        /// <br></br>
        /// </remarks>
        private void InitializeEmployeeKindDiv()
        {
            // 担当者区分
            this.tce_EmployeeKindDiv.Items.Clear();
            // 顧客担当者
            this.tce_EmployeeKindDiv.Items.Add(SumExtrInfo_BillBalance.EmployeeKindDivState.Customer, SumExtrInfo_BillBalance.ct_EmployeeKindDiv_Customer);
            // 集金担当
            this.tce_EmployeeKindDiv.Items.Add(SumExtrInfo_BillBalance.EmployeeKindDivState.BillCollecter, SumExtrInfo_BillBalance.ct_EmployeeKindDiv_BillCollecter);

            this.tce_EmployeeKindDiv.MaxDropDownItems = this.tce_EmployeeKindDiv.Items.Count;
            this.tce_EmployeeKindDiv.SelectedIndex = 0;
        }
        #endregion

		#region ◎ ボタンアイコン設定処理
		/// <summary>
		/// ボタンアイコン設定処理
		/// </summary>
		/// <param name="settingControl">アイコンセットするコントロール</param>
		/// <param name="iconIndex">アイコンインデックス</param>
		private void SetIconImage ( object settingControl, Size16_Index iconIndex )
		{
			((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
		}
		#endregion
		#endregion ◆ 画面初期化関係

		#region ◆ 印刷前処理
		#region ◎ 入力チェック処理
		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <param name="errComponent">エラー発生コンポーネント</param>
		/// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br></br>
        /// <br>UpdateNote  : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/04/10</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
            bool status = true;

            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";

            // --- ADD START 3H 劉星光 2020/04/10 ----->>>>>
            // XMLの税率情報
            if (tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                string errMsg = string.Empty;
                TaxRatePrintInfo taxRatePrintInfo = null;
                Deserialize(out taxRatePrintInfo, out errMsg);
                if (errMsg != string.Empty)
                {
                    errMessage = errMsg;
                    errComponent = tComboEditor_TaxPrintDiv;
                    status = false;
                    return status;
                }
            }
            // --- ADD END 3H 劉星光 2020/04/10 -----<<<<<

            // 処理月
            if (!InputDateEditCheack(this.AddUpYearMonth_tDateEdit))
            {
                errMessage = string.Format("処理月{0}", ct_InputError);
                errComponent = AddUpYearMonth_tDateEdit;
                status = false;
            }

            // 担当者コード
            if ((this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
            }
            
            // 販売エリアコード
            if ((this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_St.GetInt()) > (this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                errMessage = string.Format("地区{0}", ct_RangeError);
                errComponent = this.tNedit_SalesAreaCode_St;
                status = false;
            }
            
            // 得意先コード
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            
			return status;
		}
		#endregion

        #region ◎ 年月入力チェック処理
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="control">チェック対象コントロール</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br></br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // 日付を数値型で取得
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if (date == 0) return false;

            // システムサポートチェック
            if (yy < 1900) return false;

            // 年・月・日別入力チェック
            switch (control.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // 月        表示時
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // 日        表示時
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMM", date / 100);
            // 単純日付妥当性チェック
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
        }
        #endregion

		#region ◎ 抽出条件設定処理(画面→抽出条件)
		/// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br></br>
        /// <br>Update Note : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/04/10</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(SumExtrInfo_BillBalance extraInfo)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 拠点オプション
				extraInfo.IsOptSection = this._isOptSection;
				// 企業コード
				extraInfo.EnterpriseCode = this._enterpriseCode;
				// 選択拠点
                extraInfo.CollectAddupSecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
				// 処理月
                Int32 idate = this.AddUpYearMonth_tDateEdit.GetLongDate();
                if ((idate % 100) == 0)
                {
                    // 編集かけると日付が"00"となり、GetDateTime()で値を取得できなくなる対応
                    idate++;
                    this.AddUpYearMonth_tDateEdit.SetLongDate(idate);
                }
                else
                {
                    int imanyDay = idate % 100;
                    if (imanyDay != 1)
                    {
                        // カレンダー入力により日付が"01"以外の場合、日付を"01"に変更
                        idate -= (imanyDay - 1);
                        this.AddUpYearMonth_tDateEdit.SetLongDate(idate);
                    }
                }
                DateTime compDate = this.AddUpYearMonth_tDateEdit.GetDateTime();
                DateTime startMonthDate;
                DateTime endMonthDate;
                this._dateGet.GetDaysFromMonth(compDate, out startMonthDate, out endMonthDate);
                extraInfo.AddUpYearMonth = compDate;
                extraInfo.AddUpDate = endMonthDate;
                
                // 出力順
                extraInfo.SortOrderDiv = (int)this.tce_SortOrderDiv.SelectedItem.DataValue;
				// 得意先コード
                extraInfo.St_ClaimCode = this.tNedit_CustomerCode_St.GetInt();	// 開始
				extraInfo.Ed_ClaimCode = this.tNedit_CustomerCode_Ed.GetInt();	// 終了
                // 販売エリアコード
                extraInfo.St_SalesAreaCode = this.tNedit_SalesAreaCode_St.GetInt(); // 開始
                extraInfo.Ed_SalesAreaCode = this.tNedit_SalesAreaCode_Ed.GetInt(); // 終了
                // 担当者区分
                extraInfo.EmployeeKindDiv = (int)this.tce_EmployeeKindDiv.SelectedItem.DataValue;
                // 担当者コード
                
                // 開始
                if (this.tEdit_EmployeeCode_St.Text.Trim() == "")
                {
                    extraInfo.St_EmployeeCode = "";
                }
                else
                {
                    extraInfo.St_EmployeeCode = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');   // 開始担当者
                }
                // 終了
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == "")
                {
                    extraInfo.Ed_EmployeeCode = "";
                }
                else
                {
                    extraInfo.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了担当者
                }
                
                // 出力金額区分
                extraInfo.OutMoneyDiv = (int)this.tce_OutMoneyDiv.SelectedItem.DataValue;

                // 改頁
                extraInfo.NewPageType = (int)this.tComboEditor_NewPageType.Value;
                // 入金区分
                extraInfo.DepoDtlDiv = (int)this.DepositDtl_tComboEditor.Value;

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 税別内訳印字区分
                extraInfo.TaxPrintDiv = Convert.ToInt32(tComboEditor_TaxPrintDiv.SelectedIndex);

                // 税別内訳印字する
                if (extraInfo.TaxPrintDiv == 0)
                {
                    TaxRatePrintInfo taxInfo = null;
                    string errMsg = string.Empty;

                    status = Deserialize(out taxInfo, out errMsg);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // 税率1
                        extraInfo.TaxRate1 = Convert.ToDouble(taxInfo.TaxRate1);
                        // 税率2
                        extraInfo.TaxRate2 = Convert.ToDouble(taxInfo.TaxRate2);
                    }
                }
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
			}
			catch ( Exception )
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
        /// <br></br>
        /// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
		{
			TMsgDisp.Show( 
				iLevel, 							// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				ct_PrintName,						// プログラム名称
				"", 								// 処理名称
				"",									// オペレーション
				message,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
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
        /// <br></br>
        /// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				ct_PrintName,						// プログラム名称
				procnm, 							// 処理名称
				"",									// オペレーション
				errMessage,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}
		#endregion
		#endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
		#endregion ■ Private Method

		#region ■ Control Event
		#region ◆ PMHNB02270UA
        #region ◎ PMHNB02270UA_Load Event
        /// <summary>
        /// PMHNB02270UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br></br>
        /// </remarks>
        private void PMHNB02270UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
        }
		#endregion
        #endregion ◆ PMHNB02270UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br></br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintOderGroup ) ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) ||
                ( e.Group.Key == ct_ExBarGroupNm_SalesPrintGroup))
			{
				// グループの縮小をキャンセル
				e.Cancel = true;
			}
		}
		#endregion

		#region ◎ GroupExpanding Event
		/// <summary>
		/// GroupExpanding Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br></br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintOderGroup ) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_SalesPrintGroup))
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}
		}
		#endregion
		#endregion ◆ ueb_MainExplorerBar Event
		#endregion

		#region ◆ Initialize_Timer
		#region ◎ Tick Event
		/// <summary>
		/// Tick Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Initialize_Timer_Tick ( object sender, EventArgs e )
		{
			Initialize_Timer.Enabled = false;
			string errMsg = string.Empty;

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// コントロール初期化
				int status = this.InitializeScreen(out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
					return;
				}

                // 出力順
                this.InitializeSortOrderDiv();

				// ガイドボタンのアイコン設定
				this.SetIconImage( this.ub_St_CustomerCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCdGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_SalesAreaGuid, Size16_Index.STAR1);
                this.SetIconImage( this.ub_Ed_SalesAreaGuid, Size16_Index.STAR1);
                this.SetIconImage( this.ub_St_EmployeeCdGuid, Size16_Index.STAR1);
                this.SetIconImage( this.ub_Ed_EmployeeCdGuid, Size16_Index.STAR1);

				ParentToolbarSettingEvent( this );	// ツールバー設定イベント
			}
			finally
			{
                this.AddUpYearMonth_tDateEdit.Focus();

				this.Cursor = Cursors.Default;
			}
		}
		#endregion
		#endregion ◆ Initialize_Timer

		#region ◆ ub_St_CustomerCdGuid
		#region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_CustomerCdGuid_Click ( object sender, EventArgs e )
		{
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd;
            this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            if (this._customerTag.CompareTo("1") == 0)
            {
                beCustCd = this.tNedit_CustomerCode_St.GetInt();
            }
            else
            {
                beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._customerTag.CompareTo("1") == 0)
            {
                if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
                {
                    // ガイド呼出前と違う、クリアされていない場合
                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
                {
                    // ガイド呼出前と違う、クリアされていない場合
                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
		}
		#endregion
		#endregion ◆ ub_St_CustomerCdGuid

        #region ■ Private Event
        #region ◆ 得意先選択時発生イベント
        /// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        :得意先ガイドで得意先を選択した時に発生します</br>
        /// <br></br>
        /// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

            //得意先コードをセット     
			if ( this._customerTag.CompareTo("1") == 0 )
			{
				this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
			}
			else
			{
				this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
			}

		}
        #endregion

        #region ◆ ub_St_SalesAreaGuid
        #region ◎ Click Event
        /// <summary>
        /// ub_St_SalesAreaGuid_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_SalesAreaGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // インスタンス確認
            if (this._userGuideAcs == null)
                this._userGuideAcs = new UserGuideAcs();

            UserGdHd userGdHd;
            UserGdBd userGdBd;

            // ユーザーガイド起動
            status = this._userGuideAcs.ExecuteGuid(_enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (status == 0)
            {
                if (((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    this.tNedit_SalesAreaCode_St.DataText = userGdBd.GuideCode.ToString();
                }
                else
                {
                    this.tNedit_SalesAreaCode_Ed.DataText = userGdBd.GuideCode.ToString();
                }
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion
        #endregion ◆ ub_St_SalesAreaGuid

        #region ◆ ub_St_EmployeeCdGuid
        #region ◎ Click Event
        /// <summary>
        /// ub_St_EmployeeCdGuid_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EmployeeCdGuid_Click(object sender, EventArgs e)
        {
            int status = -1;
            
            // インスタンス確認
            if (this._employeeAcs == null)
                this._employeeAcs = new EmployeeAcs();

            // ガイド起動
            Employee employee = new Employee();
            status = this._employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                if (((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                }
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion
        #endregion ◆ ub_St_EmployeeCdGuid

        #region ◎ tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始)→地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→出力金額区分
                        e.NextCtrl = this.tce_OutMoneyDiv;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tce_OutMoneyDiv)
                    {
                        // 対象日(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)→地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }
                }
            }
        }
        #endregion

        #endregion

        // --- ADD START 3H 劉星光 2020/04/10---------->>>>>
        # region [印刷用税率情報XML]
        /// <summary>
        /// 印刷用税率情報
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>印刷用税率設定情報税率１</summary>
            private string _taxRate1;

            /// <summary>印刷用税率設定情報税率２</summary>
            private string _taxRate2;

            /// <summary>印刷用税率設定情報税率１</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>印刷用税率設定情報税率２</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }

        # region
        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <returns>デシリアライズ結果</returns>
        /// <remarks> 
        /// </remarks>
        public static Int32 Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out String errmsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errmsg = string.Empty;
            taxRatePrintInfo = null;

            // 印刷用税率情報XMLファイル存在の判断
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_PrintXmlFileName)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_PrintXmlFileName));
                    // 税率設定情報税率１
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // 税率設定情報税率２
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // 税率未設定の場合、
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // 同じ税率値の場合
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // 数字以外の場合、
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // 税率値は0以下の場合
                        (dTaxRate1 <= 0) || (dTaxRate2 <= 0) ||
                        // 税率値は10以上の場合
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errmsg = "税率設定情報が正しく設定されていません。";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errmsg = "税率設定情報が正しく設定されていません。";
                    return status;
                }
            }
            else
            {
                errmsg = "税率設定情報ファイル(" + ct_PrintXmlFileName + ")が存在しません。";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        # endregion
        # endregion
        // --- ADD END 3H 劉星光 2020/04/10----------<<<<<
    }
}