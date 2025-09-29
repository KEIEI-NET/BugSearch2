using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12900]～[12906]：スペースキーでの項目選択機能を実装
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上日報月報UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上日報月報UIフォームクラス</br>
    /// <br>Programmer : 96186 立花 裕輔</br>
    /// <br>Date       : 2007.09.03</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 犬飼</br>
    /// <br>Date	   : 2008.08.11</br>
    /// <br>UpdateNote : PM1012A売上日報月報対応</br>
    /// <br>Programmer : 朱 猛</br>
    /// <br>Date	   : 2010/08/12</br>
    /// <br>UpdateNote : 2012/12/28 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34098 罫線印字制御を追加する</br>
    /// <br>UpdateNote : 2013/02/27 王君</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34098 罫線印字制御を追加する</br>
    /// <br>UpdateNote : 2013/03/08 cheq</br>
    /// <br>管理番号   : 10900690-00 2013/03/26配信分</br>
    /// <br>           : Redmine#34987 帳票redmine#34098の残分の対応</br>
    /// <br>UpdateNote : 2013/04/05 宮本 利明</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>           : 出力順からフォーカス移動時に値に変更がない場合は改頁の制御を行わない</br>
    /// <br>UpdateNote : 2014/12/04 周洋</br>
    /// <br>           : Redmine #43991の#33 担当者コード等の桁数が4桁表示されない件の対応</br>
    /// <br></br>
    /// </remarks>
	public partial class DCTOK02010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer,		// 帳票業務（条件入力）PDF出力履歴管理
                                IPrintConditionInpTypeGuidExecuter      // F5：ガイドの表示非表示 // ADD 2010/08/12
	{
		#region ■ Constructor
		/// <summary>
		/// 売上日報月報UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上日報月報UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.09.03</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34098 罫線印字制御を追加する</br>
		/// <br></br>
		/// </remarks>
		public DCTOK02010UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

			this._employeeAcs = new EmployeeAcs();

            // 2008.08.27 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
            this._userGuideAcs = new UserGuideAcs();
            // 2008.08.27 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END

			//自社情報の取得
			this._companyInfAcs = new CompanyInfAcs();

			_companyInf = new CompanyInf();
			int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				//financialYear = this._companyInf.FinancialYear;
			}

			//日付取得部品
			this._dateGet = DateGetAcs.GetInstance();

            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
            List<Control> saveCtrlList = new List<Control>();
            saveCtrlList.Add(this.tComboEditor_LineMaSqOfCh);

            this.uiMemInput1.TargetControls = saveCtrlList;
            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
		}
		#endregion ■ Constructor

		#region ■ Private Member
		#region ◆ Interface member

		private int _mode = 0; 

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

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
		private SalesDayMonthReport _salesDayMonthReport;

		// ガイド系アクセスクラス
		EmployeeAcs _employeeAcs;
		private CompanyInfAcs _companyInfAcs;
		private CompanyInf _companyInf;

		//日付取得部品
		private DateGetAcs _dateGet;

        // ADD 2009/03/31 不具合対応[12900]～[12906]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>集計方法ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _ttlTypeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 集計方法ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>集計方法ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper TtlTypeRadioKeyPressHelper
        {
            get { return _ttlTypeRadioKeyPressHelper; }
        }

        /// <summary>金額単位ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _moneyUnitRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 金額単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>金額単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper MoneyUnitRadioKeyPressHelper
        {
            get { return _moneyUnitRadioKeyPressHelper; }
        }

        /// <summary>日計無し印刷ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _daySumPrtRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 日計無し印刷ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>日計無し印刷ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper DaySumPrtRadioKeyPressHelper
        {
            get { return _daySumPrtRadioKeyPressHelper; }
        }

        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _crModeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper CrModeRadioKeyPressHelper
        {
            get { return _crModeRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 不具合対応[12900]～[12906]：スペースキーでの項目選択機能を実装 ----------<<<<<

        // ---ADD 2010/08/12-------------------->>>
        private object _preComboEditorValue = 0;
        // ---ADD 2010/08/12--------------------<<<

        private object _preComboEditor_LineMaSqOfChValue;// ADD zhuhh 2012/12/28 for Redmine #34098

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID = "DCTOK02010UA";
		// プログラムID
		private const string ct_PGID = "DCTOK02010U";
		//// 帳票名称
		private const string PDF_PRINT_NAME = "売上日報月報";
		private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
		private const string PDF_PRINT_KEY = "461a402f-20c6-4b5e-817f-790237550131";
		private string _printKey = PDF_PRINT_KEY;
		#endregion ◆ Interface member

        // 2008.08.27 30413 犬飼 ユーザーガイドアクセスクラスの削除 >>>>>>START
        ///// <summary> ユーザーガイドアクセスクラス </summary>
        //private UserGuideGuide _userGuideGuide = null;
        // 2008.08.27 30413 犬飼 ユーザーガイドアクセスクラスの削除 <<<<<<END
        
        // 2008.08.27 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
        UserGuideAcs _userGuideAcs;
        // 2008.08.27 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
        // 2008.09.23 30413 犬飼 ソート順をグループに追加 >>>>>>START
        private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";                 // ソート順
        // 2008.09.23 30413 犬飼 ソート順をグループに追加 <<<<<<END
            
		//エラー条件メッセージ
		const string ct_InputError = "の入力が不正です";
		const string ct_NoInput = "を入力して下さい";
		const string ct_RangeError = "の範囲指定に誤りがあります";
		const string ct_RangeOverError = "は締日より１ヶ月の範囲内で入力して下さい";
		#endregion

        // 2008.08.18 30413 犬飼 出力順コンボのタイトル追加 >>>>>>START
        #region 出力順コンボのタイトル
        const string ct_Sort_Customer = "得意先";
        const string ct_Sort_Section = "拠点";
        const string ct_Sort_Cust_Sec = "得意先－拠点";
        const string ct_Sort_MngSection = "管理拠点";
        const string ct_Sort_SalesEmployee = "担当者";
        const string ct_Sort_SalesEmp_Sec = "担当者－拠点";
        const string ct_Sort_FrontEmployee = "受注者";
        const string ct_Sort_FrontEmp_Sec = "受注者－拠点";
        const string ct_Sort_SalesInput = "発行者";
        const string ct_Sort_SalesInp_Sec = "発行者－拠点";
        const string ct_Sort_Area = "地区";
        const string ct_Sort_Area_Sec = "地区－拠点";
        const string ct_Sort_BusinessType = "業種";
        const string ct_Sort_BusiTyp_Sec = "業種－拠点";
        #endregion
        // 2008.08.18 30413 犬飼 出力順コンボのタイトル追加 <<<<<<END
        
        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent; // ADD 2010/08/12

        // --- ADD 2010/08/26 ---------->>>>>
        private Control _preControl = null;
        public event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
			SFCMN06001U printDialog	= new SFCMN06001U();		// 帳票選択ガイド
			SFCMN06002C printInfo	= parameter as SFCMN06002C;	// 印刷情報パラメータ

			// 企業コードをセット
			printInfo.enterpriseCode	= this._enterpriseCode;
			printInfo.kidopgid			= ct_PGID;				// 起動PGID

			// PDF出力履歴用
			printInfo.key				= this._printKey;
			printInfo.prpnm				= this._printName;

#if False
			printInfo.PrintPaperSetCd	= (int)this._salesDayMonthReport.StockMoveFormalDiv;
#endif

            //起動モード別に設定コードをセット
            if (this._mode != 6)
            {
                // 2009.03.19 30413 犬飼 PDFファイル名の修正対応 >>>>>>START
                // 販売区分別以外
                //printInfo.PrintPaperSetCd = 0;
                printInfo.PrintPaperSetCd = this._mode;
                // 2009.03.19 30413 犬飼 PDFファイル名の修正対応 <<<<<<END
            }
            else
            {
                // 販売区分別
                printInfo.PrintPaperSetCd = 6;                     
            }

			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._salesDayMonthReport;
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

            // --- ADD 2010/08/26 ---------->>>>>
            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this._preControl, this._preControl);
            this.tArrowKeyControl1_ChangeFocus(this, evt);
            // --- ADD 2010/08/26 ----------<<<<<
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

            // 2008.12.09 30413 犬飼 改頁の設定を変更 >>>>>>START
            ////集計方法が全社時は改頁なしを設定
            //Int32 ttlType = Convert.ToInt32(this.uos_TtlType.CheckedIndex);
            //if (ttlType == 0)
            //{
            //    this.uos_CrMode.CheckedIndex = 0;
            //}
            // 2008.12.09 30413 犬飼 改頁の設定を変更 <<<<<<END
			
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		public void Show( object parameter )
		{
			this._salesDayMonthReport = new SalesDayMonthReport();

			// 引数型チェック
			int result = 0;
			if (Int32.TryParse(parameter.ToString(), out result) == false)
			{
				//TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
				//return;
			}
			else
			{
                // 2008.08.27 30413 犬飼 引数値チェックの変更 >>>>>>START
                // 引数値チェック
                //switch (Int32.Parse(parameter.ToString()))
                //{
                //    //0:拠点別 1:部署別 2:地区別 3:業種別 4:担当者別 5:受注者別 6:発行者別
                //    //7:得意先別 8:地区別得意先別 9:業種別得意先別 10:担当者別得意先別
                //    case 0:
                //    case 1:
                //    case 2:
                //    case 3:
                //    case 4:
                //    case 5:
                //    case 6:
                //    case 7:
                //    case 8:
                //    case 9:
                //    case 10:
                //        this._mode = Int32.Parse(parameter.ToString());
                //        break;
                //    //default:
                //        //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
                //        //return;
                //}
                switch (Int32.Parse(parameter.ToString()))
                {
                    case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                    case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分別
                        this._mode = Int32.Parse(parameter.ToString());
                        break;
                    //default:
                    //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
                    //return;
                }
                // 2008.08.27 30413 犬飼 引数値チェックの変更 <<<<<<END                
			}

			this.Show();


            // 2008.08.18 30413 犬飼 拠点別出力の削除 >>>>>>START
            ////拠点別出力時は、集計方法を拠点・改頁なしを設定
            //if (_mode == 0)
            //{
            //    this.uos_TtlType.CheckedIndex = 1;
            //    this.uos_CrMode.CheckedIndex = 0;
            //    this.uos_TtlType.Enabled = false;
            //    this.uos_CrMode.Enabled = false;
            //}
            // 2008.08.18 30413 犬飼 拠点別出力の削除 <<<<<<END
            
			return;
		}
		#endregion

        // --- ADD 2010/08/12 ---------->>>
        #region ■ F5：ガイドの実行
        /// <summary>
        /// F5：ガイドの実行
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tNedit_CustomerCode_St.Focused)
            {
                ub_St_CustomerCodeGuid_Click(ub_CustomerCodeStGuid, e);
            }
            else if (this.tNedit_CustomerCode_Ed.Focused)
            {
                ub_Ed_CustomerCodeGuid_Click(ub_CustomerCodeEdGuid, e);
            }
            else if (this.tEdit_SalesEmployeeCode_St.Focused)
            {
                ub_SalesEmployeeCdStGuid_Click(ub_SalesEmployeeCdStGuid, e);
            }
            else if (this.tEdit_SalesEmployeeCode_Ed.Focused)
            {
                ub_SalesEmployeeCdEdGuid_Click(ub_SalesEmployeeCdEdGuid, e);
            }
            else if (this.tEdit_FrontEmployeeCode_St.Focused)
            {
                ub_FrontEmployeeCdStGuid_Click(ub_FrontEmployeeCdStGuid, e);
            }
            else if (this.tEdit_FrontEmployeeCode_Ed.Focused)
            {
                ub_FrontEmployeeCdEdGuid_Click(ub_FrontEmployeeCdEdGuid, e);
            }
            else if (this.tEdit_SalesInputCode_St.Focused)
            {
                ub_St_StockAgentCodeGuid_Click(ub_SalesInputCodeStGuid, e);
            }
            else if (this.tEdit_SalesInputCode_Ed.Focused)
            {
                ub_Ed_StockAgentCodeGuid_Click(ub_SalesInputCodeEdGuid, e);
            }
            else if (this.tNedit_SalesAreaCode_St.Focused)
            {
                ub_SalesAreaCodeStGuid_Click(ub_SalesAreaCodeStGuid, e);
            }
            else if (this.tNedit_SalesAreaCode_Ed.Focused)
            {
                ub_SalesAreaCodeEdGuid_Click(ub_SalesAreaCodeEdGuid, e);
            }
            else if (this.tNedit_BusinessTypeCode_St.Focused)
            {
                ub_BusinessTypeCodeStGuid_Click(ub_BusinessTypeCodeStGuid, e);
            }
            else if (this.tNedit_BusinessTypeCode_Ed.Focused)
            {
                ub_BusinessTypeCodeEdGuid_Click(ub_BusinessTypeCodeEdGuid, e);
            }
            else if (this.tNedit_SalesCode_St.Focused)
            {
                ub_SalesCodeStGuid_Click(ub_SalesCodeStGuid, e);
            }
            else if (this.tNedit_SalesCode_Ed.Focused)
            {
                ub_SalesCodeEdGuid_Click(ub_SalesCodeEdGuid, e);
            };
        }
        #endregion
        // ---ADD 2010/08/12 ----------<<<

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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
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
					this._selectedSectionList.Add(sectionCode, checkState);
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		public void InitSelectSection ( string[] sectionCodeLst )
		{
            // 選択リスト初期化
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
				this._selectedSectionList.Add(wk, CheckState.Checked);
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34098 罫線印字制御を追加する</br>
        /// <br>UpdateNote : 2013/02/27 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34098 罫線印字制御を追加する</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // 2008.08.18 30413 犬飼 出力順コンボの初期設定 >>>>>>START
                Infragistics.Win.ValueListItem listItem = new Infragistics.Win.ValueListItem();

                // 帳票の種類により処理を分ける
                switch (this._mode)
                {
                    case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                        {
                            // 得意先
                            listItem.DataValue = 0;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Customer;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Customer;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 1;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Section;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Section;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 得意先－拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 2;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Cust_Sec;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Cust_Sec;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 管理拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 3;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_MngSection;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_MngSection;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:         // 担当者別
                        {
                            // 担当者
                            listItem.DataValue = 0;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_SalesEmployee;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_SalesEmployee;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 得意先
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 1;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Customer;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Customer;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 担当者－拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 2;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_SalesEmp_Sec;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_SalesEmp_Sec;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 管理拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 3;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_MngSection;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_MngSection;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:         // 受注者別
                        {
                            // 受注者
                            listItem.DataValue = 0;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_FrontEmployee;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_FrontEmployee;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 得意先
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 1;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Customer;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Customer;
                            // ---UPD 2010/08/12-------------------->>>
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 受注者－拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 2;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_FrontEmp_Sec;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_FrontEmp_Sec;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 管理拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 3;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_MngSection;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_MngSection;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:            // 発行者別
                        {
                            // 発行者
                            listItem.DataValue = 0;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_SalesInput;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_SalesInput;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 得意先
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 1;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Customer;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Customer;
                            // ---UPD 2010/08/12-------------------->>>
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 発行者－拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 2;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_SalesInp_Sec;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_SalesInp_Sec;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 管理拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 3;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_MngSection;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_MngSection;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.Area:                  // 地区別
                        {
                            // 地区
                            listItem.DataValue = 0;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Area;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Area;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 得意先
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 1;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Customer;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Customer;
                            // ---UPD 2010/08/12-------------------->>>
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 地区－拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 2;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Area_Sec;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Area_Sec;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:          // 業種別
                        {
                            // 業種
                            listItem.DataValue = 0;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_BusinessType;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_BusinessType;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 得意先
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 1;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_Customer;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_Customer;
                            // ---UPD 2010/08/12-------------------->>>
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            // 業種－拠点
                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.DataValue = 2;
                            // ---UPD 2010/08/12-------------------->>>
                            //listItem.DisplayText = ct_Sort_BusiTyp_Sec;
                            listItem.DisplayText = listItem.DataValue.ToString() + ":" + ct_Sort_BusiTyp_Sec;
                            // ---UPD 2010/08/12--------------------<<<
                            this.PrintOder_tComboEditor.Items.Add(listItem);
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:              // 販売区分
                        {
                            // 販売区分は、ソート順を非表示
                            this.ueb_MainExplorerBar.Groups[1].Visible = false;
                            break;
                        }
                }
                this.PrintOder_tComboEditor.SelectedIndex = 0;
                // 2008.08.18 30413 犬飼 出力順コンボの初期設定 <<<<<<END

                // 2008.08.22 30413 犬飼 改頁の初期値設定を集計方法より先に >>>>>>START
                // 改頁
                uos_CrMode.CheckedIndex = 1;
                // 2008.08.22 30413 犬飼 改頁の初期値設定を集計方法より先に <<<<<<END

				// 集計方法
				this.uos_TtlType.CheckedIndex = 1;
                this.uos_TtlType.FocusedIndex = 1;  // ADD 2008/03/31 不具合対応[12900]～[12906]：スペースキーでの項目選択機能を実装

				// 売上日
				DateTime staratDate;
				DateTime endDate;
				this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

				this.tde_SalesDateSt.SetDateTime(staratDate);
				this.tde_SalesDateEd.SetDateTime(endDate);

				// 得意先
				this.tNedit_CustomerCode_St.Clear();
				this.tNedit_CustomerCode_Ed.Clear();

				//発行者
				this.tEdit_SalesInputCode_St.DataText = string.Empty;
				this.tEdit_SalesInputCode_Ed.DataText = string.Empty;

				//受注者
				this.tEdit_FrontEmployeeCode_St.DataText = string.Empty;
				this.tEdit_FrontEmployeeCode_Ed.DataText = string.Empty;

				//発行者
				this.tEdit_SalesEmployeeCode_St.DataText = string.Empty;
				this.tEdit_SalesEmployeeCode_Ed.DataText = string.Empty;

				//販売エリア
				this.tNedit_SalesAreaCode_St.Clear();
				this.tNedit_SalesAreaCode_Ed.Clear();

				//業種
				this.tNedit_BusinessTypeCode_St.Clear();
				this.tNedit_BusinessTypeCode_Ed.Clear();

                // 2008.08.18 販売区分を追加 >>>>>>START
                // 販売区分
                this.tNedit_SalesCode_St.Clear();
                this.tNedit_SalesCode_Ed.Clear();
                // 2008.08.18 販売区分を追加 <<<<<<END
                
				//金額単位
				this.uos_MoneyUnit.CheckedIndex = 0;

                // 2008.08.18 日計無し印刷を追加 >>>>>>START
                // 日計無し印刷
                this.uos_DaySumPrtDiv.CheckedIndex = 0;
                // 2008.08.18 日計無し印刷を追加 <<<<<<END                

                //// 改頁
                //uos_CrMode.CheckedIndex = 1;

                // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                this.tComboEditor_LineMaSqOfCh.Items.Clear();
                this.tComboEditor_LineMaSqOfCh.Items.Add(0,"0:印字する");
                this.tComboEditor_LineMaSqOfCh.Items.Add(1,"1:印字しない");
                this.tComboEditor_LineMaSqOfCh.Value = 0;

                this.uiMemInput1.ReadMemInput();
                this._preComboEditor_LineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;
                // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

                // ボタン設定
				this.SetIconImage(this.ub_CustomerCodeStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.ub_CustomerCodeEdGuid, Size16_Index.STAR1);

				this.SetIconImage(this.ub_SalesInputCodeStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.ub_SalesInputCodeEdGuid, Size16_Index.STAR1);

				this.SetIconImage(this.ub_FrontEmployeeCdStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.ub_FrontEmployeeCdEdGuid, Size16_Index.STAR1);

				this.SetIconImage(this.ub_SalesEmployeeCdStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.ub_SalesEmployeeCdEdGuid, Size16_Index.STAR1);

				this.SetIconImage(this.ub_SalesAreaCodeStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.ub_SalesAreaCodeEdGuid, Size16_Index.STAR1);

				this.SetIconImage(this.ub_BusinessTypeCodeStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.ub_BusinessTypeCodeEdGuid, Size16_Index.STAR1);

                // 2008.08.18 販売区分ボタンを追加 >>>>>>START
                this.SetIconImage(this.ub_SalesCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SalesCodeEdGuid, Size16_Index.STAR1);
                // 2008.08.18 販売区分ボタンを追加 <<<<<<END
                

                // 2008.08.11 既存の抽出条件の設定を削除 >>>>>>START
                #region 入力可能な抽出条件の設定
                ////入力可能な抽出条件の設定
                ////0:拠点別 1:部署別 2:地区別 3:業種別 4:担当者別 5:受注者別 6:発行者別
                ////7:得意先別 8:地区別得意先別 9:業種別得意先別 10:担当者別得意先別
                //switch (_mode)
                //{
                //    case 0:
                //        #region 拠点別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = false;
                //        this.tne_CustomerCodeEd.Enabled = false;
                //        ub_CustomerCodeStGuid.Enabled = false;
                //        ub_CustomerCodeEdGuid.Enabled = false;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        //担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //    #endregion
                //    case 1:
                //        #region 部署別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = false;
                //        this.tne_CustomerCodeEd.Enabled = false;
                //        ub_CustomerCodeStGuid.Enabled = false;
                //        ub_CustomerCodeEdGuid.Enabled = false;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        //担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //    case 2:
                //        #region 地区別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = false;
                //        this.tne_CustomerCodeEd.Enabled = false;
                //        ub_CustomerCodeStGuid.Enabled = false;
                //        ub_CustomerCodeEdGuid.Enabled = false;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        //担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = true;
                //        this.tne_SalesAreaCodeEd.Enabled = true;
                //        ub_SalesAreaCodeStGuid.Enabled = true;
                //        ub_SalesAreaCodeEdGuid.Enabled = true;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //    case 3:
                //        #region 業種別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = false;
                //        this.tne_CustomerCodeEd.Enabled = false;
                //        ub_CustomerCodeStGuid.Enabled = false;
                //        ub_CustomerCodeEdGuid.Enabled = false;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        //担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = true;
                //        this.tne_BusinessTypeCodeEd.Enabled = true;
                //        ub_BusinessTypeCodeStGuid.Enabled = true;
                //        ub_BusinessTypeCodeEdGuid.Enabled = true;
                //        break;
                //        #endregion
                //    case 4:
                //        #region 担当者別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = false;
                //        this.tne_CustomerCodeEd.Enabled = false;
                //        ub_CustomerCodeStGuid.Enabled = false;
                //        ub_CustomerCodeEdGuid.Enabled = false;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        //担当者
                //        this.te_SalesEmployeeCdSt.Enabled = true;
                //        this.te_SalesEmployeeCdEd.Enabled = true;
                //        ub_SalesEmployeeCdStGuid.Enabled = true;
                //        ub_SalesEmployeeCdEdGuid.Enabled = true;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //    case 5:
                //        #region 受注者別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = false;
                //        this.tne_CustomerCodeEd.Enabled = false;
                //        ub_CustomerCodeStGuid.Enabled = false;
                //        ub_CustomerCodeEdGuid.Enabled = false;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = true;
                //        this.te_FrontEmployeeCdEd.Enabled = true;
                //        ub_FrontEmployeeCdStGuid.Enabled = true;
                //        ub_FrontEmployeeCdEdGuid.Enabled = true;

                //        // 担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //    case 6:
                //        #region 発行者別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = false;
                //        this.tne_CustomerCodeEd.Enabled = false;
                //        ub_CustomerCodeStGuid.Enabled = false;
                //        ub_CustomerCodeEdGuid.Enabled = false;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = true;
                //        this.te_SalesInputCodeEd.Enabled = true;
                //        ub_SalesInputCodeStGuid.Enabled = true;
                //        ub_SalesInputCodeEdGuid.Enabled = true;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        // 担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //    case 7:
                //        #region 得意先別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = true;
                //        this.tne_CustomerCodeEd.Enabled = true;
                //        ub_CustomerCodeStGuid.Enabled = true;
                //        ub_CustomerCodeEdGuid.Enabled = true;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        // 担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //    case 8:
                //        #region 地区別得意先別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = true;
                //        this.tne_CustomerCodeEd.Enabled = true;
                //        ub_CustomerCodeStGuid.Enabled = true;
                //        ub_CustomerCodeEdGuid.Enabled = true;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        // 担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = true;
                //        this.tne_SalesAreaCodeEd.Enabled = true;
                //        ub_SalesAreaCodeStGuid.Enabled = true;
                //        ub_SalesAreaCodeEdGuid.Enabled = true;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //    case 9:
                //        #region 業種別得意先別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = true;
                //        this.tne_CustomerCodeEd.Enabled = true;
                //        ub_CustomerCodeStGuid.Enabled = true;
                //        ub_CustomerCodeEdGuid.Enabled = true;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        // 担当者
                //        this.te_SalesEmployeeCdSt.Enabled = false;
                //        this.te_SalesEmployeeCdEd.Enabled = false;
                //        ub_SalesEmployeeCdStGuid.Enabled = false;
                //        ub_SalesEmployeeCdEdGuid.Enabled = false;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = true;
                //        this.tne_BusinessTypeCodeEd.Enabled = true;
                //        ub_BusinessTypeCodeStGuid.Enabled = true;
                //        ub_BusinessTypeCodeEdGuid.Enabled = true;
                //        break;
                //        #endregion
                //    case 10:
                //        #region 担当者別得意先別
                //        // 得意先
                //        this.tne_CustomerCodeSt.Enabled = true;
                //        this.tne_CustomerCodeEd.Enabled = true;
                //        ub_CustomerCodeStGuid.Enabled = true;
                //        ub_CustomerCodeEdGuid.Enabled = true;

                //        //発行者
                //        this.te_SalesInputCodeSt.Enabled = false;
                //        this.te_SalesInputCodeEd.Enabled = false;
                //        ub_SalesInputCodeStGuid.Enabled = false;
                //        ub_SalesInputCodeEdGuid.Enabled = false;

                //        //受注者
                //        this.te_FrontEmployeeCdSt.Enabled = false;
                //        this.te_FrontEmployeeCdEd.Enabled = false;
                //        ub_FrontEmployeeCdStGuid.Enabled = false;
                //        ub_FrontEmployeeCdEdGuid.Enabled = false;

                //        // 担当者
                //        this.te_SalesEmployeeCdSt.Enabled = true;
                //        this.te_SalesEmployeeCdEd.Enabled = true;
                //        ub_SalesEmployeeCdStGuid.Enabled = true;
                //        ub_SalesEmployeeCdEdGuid.Enabled = true;

                //        //販売エリア
                //        this.tne_SalesAreaCodeSt.Enabled = false;
                //        this.tne_SalesAreaCodeEd.Enabled = false;
                //        ub_SalesAreaCodeStGuid.Enabled = false;
                //        ub_SalesAreaCodeEdGuid.Enabled = false;

                //        //業種
                //        this.tne_BusinessTypeCodeSt.Enabled = false;
                //        this.tne_BusinessTypeCodeEd.Enabled = false;
                //        ub_BusinessTypeCodeStGuid.Enabled = false;
                //        ub_BusinessTypeCodeEdGuid.Enabled = false;
                //        break;
                //        #endregion
                //}
                #endregion
                // 2008.08.11 既存の抽出条件の設定を削除 <<<<<<END
                
                // 2008.08.11 30413 犬飼 抽出条件表示制御の追加 >>>>>>START
                #region < 抽出条件表示制御 >
                Point point = new Point();
                point.X = 0;
                point.Y = 7;

                // 帳票の種類により処理を分ける
                switch (this._mode)
                {
                    case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                        {
                            this.Customer_panel.Location = point;
                            this.Customer_panel.Visible = true;
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                        {
                            this.SalesEmployee_panel.Location = point;
                            this.SalesEmployee_panel.Visible = true;

                            point.Y = point.Y + 30;
                            this.Customer_panel.Location = point;
                            this.Customer_panel.Visible = true;
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                        {
                            this.FrontEmployee_panel.Location = point;
                            this.FrontEmployee_panel.Visible = true;

                            point.Y = point.Y + 30;
                            this.Customer_panel.Location = point;
                            this.Customer_panel.Visible = true;
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                        {
                            this.SalesInput_panel.Location = point;
                            this.SalesInput_panel.Visible = true;

                            point.Y = point.Y + 30;
                            this.Customer_panel.Location = point;
                            this.Customer_panel.Visible = true;
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                        {
                            this.SalesArea_panel.Location = point;
                            this.SalesArea_panel.Visible = true;

                            point.Y = point.Y + 30;
                            this.Customer_panel.Location = point;
                            this.Customer_panel.Visible = true;
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                        {
                            this.BusinessType_panel.Location = point;
                            this.BusinessType_panel.Visible = true;

                            point.Y = point.Y + 30;
                            this.Customer_panel.Location = point;
                            this.Customer_panel.Visible = true;
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分別
                        {
                            this.Sales_panel.Location = point;
                            this.Sales_panel.Visible = true;

                            point.Y = point.Y + 30;
                            this.Customer_panel.Location = point;
                            this.Customer_panel.Visible = true;
                            break;
                        }
                }

                // 抽出条件のエクスプローラーバー高さの変更
                this.ueb_MainExplorerBar.Groups[2].Visible = true;
                switch (this._mode)
                {
                    case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                        {
                            this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 50;
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者
                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者
                    case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
                        {
                            this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 80;
                            break;
                        }
                }
                #endregion
                // 2008.08.11 30413 犬飼 抽出条件表示制御の追加 <<<<<<END

                // 2008.08.18 30413 犬飼 出力条件表示制御の追加 >>>>>>START
                point = new Point();
                point.X = 0;
                point.Y = 100;

                // 抽出条件のエクスプローラーバー高さの変更
                this.ueb_MainExplorerBar.Groups[2].Visible = true;
                switch (this._mode)
                {
                    case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者
                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者
                    case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                        {
                            this.DaySumPrtDiv_panel.Location = point;
                            this.DaySumPrtDiv_panel.Visible = true;

                            //point.Y = point.Y + 30;//DEL 王君 2013/02/27 for Redmine #34098
                            point.Y = point.Y + 60;//ADD 王君 2013/02/27 for Redmine #34098
                            this.CrMode_panel.Location = point;
                            this.CrMode_panel.Visible = true;

                            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                            //point.Y = point.Y + 30;//DEL 王君 2013/02/27 for Redmine #34098
                            point.Y = point.Y - 30;//ADD 王君 2013/02/27 for Redmine #34098
                            this.LineMaSqOfCh_Panel.Location = point;
                            this.LineMaSqOfCh_Panel.Visible = true;
                            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

                            //this.ueb_MainExplorerBar.Groups[0].Settings.ContainerHeight = 180;// DEL zhuhh 2012/12/28 for Redmine #34098
                            this.ueb_MainExplorerBar.Groups[0].Settings.ContainerHeight = 200;// ADD zhuhh 2012/12/28 for Redmine #34098
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
                        {
                            point.Y = point.Y + 30;//ADD 王君 2013/02/27 for Redmine #34098
                            this.CrMode_panel.Location = point;
                            this.CrMode_panel.Visible = true;

                            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                            //point.Y = point.Y + 30;//DEL 王君 2013/02/27 for Redmine #34098
                            point.Y = point.Y - 30;//ADD 王君 2013/02/27 for Redmine #34098
                            this.LineMaSqOfCh_Panel.Location = point;
                            this.LineMaSqOfCh_Panel.Visible = true;
                            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

                            //this.ueb_MainExplorerBar.Groups[0].Settings.ContainerHeight = 150;// DEL zhuhh 2012/12/28 for Redmine #34098
                            this.ueb_MainExplorerBar.Groups[0].Settings.ContainerHeight = 170;// ADD zhuhh 2012/12/28 for Redmine #34098
                            break;
                        }
                }       
                // 2008.08.18 30413 犬飼 出力条件表示制御の追加 <<<<<<END

                // 2008.12.11 30413 犬飼 初期フォーカスを集計方法に変更 >>>>>>START
				// 初期フォーカスセット
                //this.tde_SalesDateSt.Focus();
                this.uos_TtlType.Focus();
                // 2008.12.11 30413 犬飼 初期フォーカスを集計方法に変更 <<<<<<END
            }
			catch ( Exception ex )
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
		private void SetIconImage ( object settingControl, Size16_Index iconIndex )
		{
			((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((UltraButton)settingControl).Appearance.Image = iconIndex;
		}
		#endregion
		#endregion ◆ 画面初期化関係

		#region ◆ 印刷前処理
		#region ◎ 入力チェック処理

		/// <summary>
		/// 日付チェック処理呼び出し
		/// </summary>
		/// <param name="cdrResult"></param>
		/// <param name="tde_St_OrderDataCreateDate"></param>
		/// <param name="tde_Ed_OrderDataCreateDate"></param>
		/// <returns></returns>
		private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
		{
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, true);
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;
			DateGetAcs.CheckDateRangeResult cdrResult;

			// 売上日
			// 入力日付（開始～終了）
			if (CallCheckDateRange(out cdrResult, ref tde_SalesDateSt, ref tde_SalesDateEd) == false)
			{
				switch (cdrResult)
				{
					case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
						{
							errMessage = string.Format("開始対象日{0}", ct_NoInput);
							errComponent = this.tde_SalesDateSt;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
						{
							errMessage = string.Format("開始対象日{0}", ct_InputError);
							errComponent = this.tde_SalesDateSt;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
						{
							errMessage = string.Format("終了対象日{0}", ct_NoInput);
							errComponent = this.tde_SalesDateEd;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
						{
							errMessage = string.Format("終了対象日{0}", ct_InputError);
							errComponent = this.tde_SalesDateEd;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
						{
							errMessage = string.Format("対象日{0}", ct_RangeError);
							errComponent = this.tde_SalesDateSt;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
					case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
						{
							errMessage = string.Format("対象日{0}", ct_RangeOverError);
							errComponent = this.tde_SalesDateSt;
						}
						break;
				}
				status = false;
			}
			
			// 発行者コード
			else if (
			    (this.tEdit_SalesInputCode_St.DataText.TrimEnd() != string.Empty) && 
			    (this.tEdit_SalesInputCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesInputCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_SalesInputCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
			{
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 >>>>>>START
                //errMessage = string.Format("発行者コード{0}", ct_RangeError);
                errMessage = string.Format("発行者{0}", ct_RangeError);
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 <<<<<<END
                errComponent = this.tEdit_SalesInputCode_St;
			    status			= false;
			}

			// 受注者コード
			else if (
			  (this.tEdit_FrontEmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
			  (this.tEdit_FrontEmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
              (this.tEdit_FrontEmployeeCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_FrontEmployeeCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
			{
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 >>>>>>START
                //errMessage = string.Format("受注者コード{0}", ct_RangeError);
                errMessage = string.Format("受注者{0}", ct_RangeError);
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 <<<<<<END
                errComponent = this.tEdit_FrontEmployeeCode_St;
				status = false;
			}

			// 担当者コード
			else if (
			  (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
			  (this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
              (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
			{
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 >>>>>>START
                //errMessage = string.Format("担当者コード{0}", ct_RangeError);
                errMessage = string.Format("担当者{0}", ct_RangeError);
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 <<<<<<END
                errComponent = this.tEdit_SalesEmployeeCode_St;
				status = false;
			}

            // 2008.12.03 30413 犬飼 得意先のチェック順を変更 >>>>>>START
            //// 得意先コード
            //else if((tNedit_CustomerCode_St.DataText.Trim() != "")
            //    && (tNedit_CustomerCode_Ed.DataText.Trim() != "")
            //    && (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
            //{
            //    // 2008.08.18 30413 犬飼 エラーメッセージの変更 >>>>>>START
            //    //errMessage = string.Format("得意先コード{0}", ct_RangeError);
            //    errMessage = string.Format("得意先{0}", ct_RangeError);
            //    // 2008.08.18 30413 犬飼 エラーメッセージの変更 <<<<<<END
            //    errComponent = this.tNedit_CustomerCode_St;
            //    status			= false;
            //}
            // 2008.12.03 30413 犬飼 得意先のチェック順を変更 <<<<<<END
            
            // 販売エリアコード
			else if((tNedit_SalesAreaCode_St.DataText.Trim() != "")
                && (tNedit_SalesAreaCode_Ed.DataText.Trim() != "")
                && (this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt()))
			{
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 >>>>>>START
                //errMessage = string.Format("地区コード{0}", ct_RangeError);
                errMessage = string.Format("地区{0}", ct_RangeError);
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 <<<<<<END
                errComponent = this.tNedit_SalesAreaCode_St;
				status = false;
			}
			// 業種コード
			else if((this.tNedit_BusinessTypeCode_St.DataText.Trim() != "")
                && (this.tNedit_BusinessTypeCode_Ed.DataText.Trim() != "")
                && (this.tNedit_BusinessTypeCode_St.GetInt() > this.tNedit_BusinessTypeCode_Ed.GetInt()))
			{
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 >>>>>>START
                //errMessage = string.Format("業種コード{0}", ct_RangeError);
                errMessage = string.Format("業種{0}", ct_RangeError);
                // 2008.08.18 30413 犬飼 エラーメッセージの変更 <<<<<<END
                errComponent = this.tNedit_BusinessTypeCode_St;
			    status			= false;
			}
            // 2008.08.18 30413 犬飼 販売区分の追加 >>>>>>START
            // 販売区分
            else if ((this.tNedit_SalesCode_St.DataText.Trim() != "")
                && (this.tNedit_SalesCode_Ed.DataText.Trim() != "")
                && (this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt()))
            {
                errMessage = string.Format("販売区分{0}", ct_RangeError);
                // --- UPD 2010/08/26 --- >>>>>
                //errComponent = this.tNedit_BusinessTypeCode_St;
                errComponent = this.tNedit_SalesCode_St;
                // --- UPD 2010/08/26 --- >>>>>
                status = false;
            }
            // 2008.08.18 30413 犬飼 販売区分の追加 <<<<<<END

            // 2008.12.03 30413 犬飼 得意先のチェック順を変更 >>>>>>START
            // 得意先コード
            else if ((tNedit_CustomerCode_St.DataText.Trim() != "")
                 && (tNedit_CustomerCode_Ed.DataText.Trim() != "")
                 && (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            // 2008.12.03 30413 犬飼 得意先のチェック順を変更 <<<<<<END

            return status;
		}

        // ---ADD 2010/08/12-------------------->>>
        /// <summary>
        /// リスト項目をコードからでも入力可能へ変更
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Note        : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }
        // ---ADD 2010/08/12--------------------<<<
		#endregion

		#region ◎ 日付入力チェック処理
		/// <summary>
		/// 日付入力チェック処理
		/// </summary>
		/// <param name="targetDateEdit">チェック対象コントロール</param>
		/// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
		/// <returns>チェック結果(true/false)</returns>
		/// <remarks>
		/// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowEmpty )
		{
			bool status = true;

			// 入力日付を数値型で取得
			int date = targetDateEdit.GetLongDate();
			int yy = date / 10000;
			int mm = ( date / 100 ) % 100;
			int dd = date % 100;

			// 日付未入力チェック
			if( targetDateEdit.GetDateTime() == DateTime.MinValue )
			{
				if( allowEmpty == true ) 
				{
					return status;
				}
				else 
				{
					status = false;
				}
			}
			// システムサポートチェック
			else if( yy < 1900 )
			{
				status = false;
			}
			// 年月日別入力チェック
			else if( ( yy == 0 ) || ( mm == 0 ) || ( dd == 0 ) )
			{
				status = false;
			}
			// 単純日付妥当性チェック
			else if( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
			{
				status = false;
			}

			return status;
		}
		#endregion

		#region ◎ 抽出条件設定処理(画面→抽出条件)
		/// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34098 罫線印字制御を追加する</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 企業コード
				this._salesDayMonthReport.EnterpriseCode = this._enterpriseCode;
				// 選択拠点
				//this._salesDayMonthReport.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));


				// 拠点オプションありのとき
				if (IsOptSection)
				{
					ArrayList secList = new ArrayList();
					// 全社選択かどうか
					if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
					{
						//extraInfo.SectionCd = new string[1];
						//extraInfo.SectionCd[0] = "0";
						_salesDayMonthReport.SectionCodes = new string[0];
					}
					else
					{
						foreach (DictionaryEntry dicEntry in this._selectedSectionList)
						{
							if ((CheckState)dicEntry.Value == CheckState.Checked)
							{
								secList.Add(dicEntry.Key);
							}
						}
						_salesDayMonthReport.SectionCodes = (string[])secList.ToArray(typeof(string));
					}
				}
				// 拠点オプションなしの時
				else
				{
					_salesDayMonthReport.SectionCodes = new string[0];
				}

				//集計方法
				this._salesDayMonthReport.TtlType = Convert.ToInt32(this.uos_TtlType.CheckedIndex);

				//売上日付
				this._salesDayMonthReport.SalesDateSt = this.tde_SalesDateSt.GetDateTime();
				this._salesDayMonthReport.SalesDateEd = this.tde_SalesDateEd.GetDateTime();

				//売上累計日付
				DateTime yearMonth, startMonthDate, endMonthDate;
				Int32 year;
				_dateGet.GetYearMonth(this._salesDayMonthReport.SalesDateSt, out yearMonth, out year, out startMonthDate, out endMonthDate);

				this._salesDayMonthReport.MonthReportDateSt = startMonthDate;
				this._salesDayMonthReport.MonthReportDateEd = this.tde_SalesDateEd.GetDateTime();

                // 2009.01.16 30413 犬飼 対象年月(目標期間)を追加 >>>>>>START
                this._salesDayMonthReport.TargetYearMonthSt = yearMonth;
                this._salesDayMonthReport.TargetYearMonthEd = yearMonth;
                // 2009.01.16 30413 犬飼 対象年月(目標期間)を追加 <<<<<<END

                // 2008.08.18 30413 犬飼 削除プロパティ >>>>>>START
                ////売上累計日付
                //this._salesDayMonthReport.TargetMonth = yearMonth;
                // 2008.08.18 30413 犬飼 削除プロパティ <<<<<<END
                
#if False
				//売上累計日付
				int yYYY = this._salesDayMonthReport.SalesDateEd.Year;
				int mM = this._salesDayMonthReport.SalesDateEd.Month;
				int dD = this._companyInf.CompanyTotalDay;
				DateTime endDate = new DateTime(yYYY, mM, dD);

				if (endDate >= this._salesDayMonthReport.SalesDateEd)
				{
					endDate = endDate.AddMonths(-1);
					endDate = endDate.AddDays(1);
				}
				else
				{
					endDate = endDate.AddDays(1);
				}

				this._salesDayMonthReport.MonthReportDateSt = endDate;
				this._salesDayMonthReport.MonthReportDateEd = this.tde_SalesDateEd.GetDateTime();
				//月間目標月
				DateTime targetMonthTmp = new DateTime(yYYY, mM, 1);
				DateTime targetMonth = new DateTime(yYYY, mM, 1);
				if (this._salesDayMonthReport.SalesDateEd.Day <= this._companyInf.CompanyTotalDay)
				{
					targetMonth = targetMonthTmp.AddMonths(-1);
				}

				this._salesDayMonthReport.TargetMonth = targetMonth;
#endif

				//得意先コード
				this._salesDayMonthReport.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                // 2008.09.24 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す >>>>>>START
                //if (this.tNedit_CustomerCode_Ed.GetInt() == 0)
                //{
                //    // 未入力の場合は、最大値を設定
                //    this._salesDayMonthReport.CustomerCodeEd = 99999999;
                //}
                //else
                //{
                //    this._salesDayMonthReport.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                //}
                this._salesDayMonthReport.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                // 2008.09.24 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す <<<<<<END
                
                // 2008.08.18 30413 犬飼 削除プロパティ >>>>>>START
                ////担当者コード
                //this._salesDayMonthReport.SalesInputCodeSt = this.te_SalesInputCodeSt.DataText;
                //this._salesDayMonthReport.SalesInputCodeEd = this.te_SalesInputCodeEd.DataText;

                ////受注者コード
                //this._salesDayMonthReport.FrontEmployeeCdSt = this.te_FrontEmployeeCdSt.DataText;
                //this._salesDayMonthReport.FrontEmployeeCdEd = this.te_FrontEmployeeCdEd.DataText;

                ////発行者コード
                //this._salesDayMonthReport.SalesEmployeeCdSt = this.te_SalesEmployeeCdSt.DataText;
                //this._salesDayMonthReport.SalesEmployeeCdEd = this.te_SalesEmployeeCdEd.DataText;

                ////地区コード
                //this._salesDayMonthReport.SalesAreaCodeSt = this.tne_SalesAreaCodeSt.GetInt();
                //this._salesDayMonthReport.SalesAreaCodeEd = this.tne_SalesAreaCodeEd.GetInt();

                ////業種コード
                //this._salesDayMonthReport.BusinessTypeCodeSt = this.tne_BusinessTypeCodeSt.GetInt();
                //this._salesDayMonthReport.BusinessTypeCodeEd = this.tne_BusinessTypeCodeEd.GetInt();
                // 2008.08.18 30413 犬飼 削除プロパティ <<<<<<END

                // 2008.08.18 30413 犬飼 帳票種別で検索コードを設定 >>>>>>START
                ////帳票種別
                ////0:拠点別 1:部署別 2:地区別 3:業種別 4:担当者別 5:受注者別 6:発行者別
                ////7:得意先別 8:地区別得意先別 9:業種別得意先別 10:担当者別得意先別
                //switch (this._mode)
                //{
                //    case 0: this._salesDayMonthReport.TotalType = 0; break; //拠点別
                //    case 1: this._salesDayMonthReport.TotalType = 1; break; //部署別
                //    case 2: this._salesDayMonthReport.TotalType = 3; break; //地区別
                //    case 3: this._salesDayMonthReport.TotalType = 4; break; //業種別
                //    case 4: this._salesDayMonthReport.TotalType = 5; break; //担当者別
                //    case 5: this._salesDayMonthReport.TotalType = 6; break; //受注者別
                //    case 6: this._salesDayMonthReport.TotalType = 7; break; //発行者別
                //    case 7: this._salesDayMonthReport.TotalType = 8; break; //得意先別
                //    case 8: this._salesDayMonthReport.TotalType = 9; break; //地区別得意先別
                //    case 9: this._salesDayMonthReport.TotalType =10; break; //業種別得意先別
                //    case 10:this._salesDayMonthReport.TotalType =11; break; //担当者別得意先別
                //}

                // 集計単位
                this._salesDayMonthReport.TotalType = this._mode;
                            
                // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                // 罫線印字区分
                this._salesDayMonthReport.LineMaSqOfChDiv =(int) this.tComboEditor_LineMaSqOfCh.Value;
                // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                            
                // 帳票種別
                switch (this._mode)
                {
                    case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                        {
                            // 出力順
                            this._salesDayMonthReport.OutType = (int)this.PrintOder_tComboEditor.Value;
                            // 開始検索コード
                            this._salesDayMonthReport.SrchCodeSt = "";
                            // 終了検索コード
                            this._salesDayMonthReport.SrchCodeEd = "";
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                        {
                            // 出力順
                            this._salesDayMonthReport.OutType = (int)this.PrintOder_tComboEditor.Value;
                            // 2008.09.24 30413 犬飼 0埋め対応 >>>>>>START
                            //// 開始検索コード
                            //this._salesDayMonthReport.SrchCodeSt = this.tEdit_SalesEmployeeCode_St.Text.Trim();   // 開始担当者
                            //// 終了検索コード
                            //this._salesDayMonthReport.SrchCodeEd = this.tEdit_SalesEmployeeCode_Ed.Text.Trim();   // 終了担当者

                            // 開始検索コード
                            if (this.tEdit_SalesEmployeeCode_St.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeSt = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeSt = this.tEdit_SalesEmployeeCode_St.Text.Trim().PadLeft(4, '0');   // 開始担当者
                            }
                            // 終了検索コード
                            if (this.tEdit_SalesEmployeeCode_Ed.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeEd = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeEd = this.tEdit_SalesEmployeeCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了担当者
                            }
                            // 2008.09.24 30413 犬飼 0埋め対応 <<<<<<END
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                        {
                            // 出力順
                            this._salesDayMonthReport.OutType = (int)this.PrintOder_tComboEditor.Value;
                            // 2008.09.24 30413 犬飼 0埋め対応 >>>>>>START
                            //// 開始検索コード
                            //this._salesDayMonthReport.SrchCodeSt = this.tEdit_FrontEmployeeCode_St.Text.Trim();   // 開始受注者
                            //// 終了検索コード
                            //this._salesDayMonthReport.SrchCodeEd = this.tEdit_FrontEmployeeCode_Ed.Text.Trim();   // 終了受注者

                            // 開始検索コード
                            if (this.tEdit_FrontEmployeeCode_St.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeSt = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeSt = this.tEdit_FrontEmployeeCode_St.Text.Trim().PadLeft(4, '0');   // 開始受注者
                            }
                            // 終了検索コード
                            if (this.tEdit_FrontEmployeeCode_Ed.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeEd = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeEd = this.tEdit_FrontEmployeeCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了受注者
                            }
                            // 2008.09.24 30413 犬飼 0埋め対応 <<<<<<END
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                        {
                            // 出力順
                            this._salesDayMonthReport.OutType = (int)this.PrintOder_tComboEditor.Value;
                            // 2008.09.24 30413 犬飼 0埋め対応 >>>>>>START
                            //// 開始検索コード
                            //this._salesDayMonthReport.SrchCodeSt = this.tEdit_SalesInputCode_St.Text.Trim();   // 開始発行者
                            //// 終了検索コード
                            //this._salesDayMonthReport.SrchCodeEd = this.tEdit_SalesInputCode_Ed.Text.Trim();   // 終了発行者

                            // 開始検索コード
                            if (this.tEdit_SalesInputCode_St.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeSt = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeSt = this.tEdit_SalesInputCode_St.Text.Trim().PadLeft(4, '0');   // 開始発行者
                            }
                            // 終了検索コード
                            if (this.tEdit_SalesInputCode_Ed.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeEd = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeEd = this.tEdit_SalesInputCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了発行者
                            }
                            // 2008.09.24 30413 犬飼 0埋め対応 <<<<<<END
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                        {
                            // 出力順
                            this._salesDayMonthReport.OutType = (int)this.PrintOder_tComboEditor.Value;
                            // 2008.09.24 30413 犬飼 0埋め対応 >>>>>>START
                            //// 開始検索コード
                            //this._salesDayMonthReport.SrchCodeSt = this.tNedit_SalesAreaCode_St.Text.Trim();   // 開始地区
                            //// 終了検索コード
                            //this._salesDayMonthReport.SrchCodeEd = this.tNedit_SalesAreaCode_Ed.Text.Trim();   // 終了地区

                            // 開始検索コード
                            if (this.tNedit_SalesAreaCode_St.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeSt = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeSt = this.tNedit_SalesAreaCode_St.Text.Trim().PadLeft(4, '0');   // 開始地区
                            }
                            // 終了検索コード
                            if (this.tNedit_SalesAreaCode_Ed.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeEd = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeEd = this.tNedit_SalesAreaCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了地区
                            }
                            // 2008.09.24 30413 犬飼 0埋め対応 <<<<<<END
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                        {
                            // 出力順
                            this._salesDayMonthReport.OutType = (int)this.PrintOder_tComboEditor.Value;
                            // 2008.09.24 30413 犬飼 0埋め対応 >>>>>>START
                            //// 開始検索コード
                            //this._salesDayMonthReport.SrchCodeSt = this.tNedit_BusinessTypeCode_St.Text.Trim();   // 開始業種
                            //// 終了検索コード
                            //this._salesDayMonthReport.SrchCodeEd = this.tNedit_BusinessTypeCode_Ed.Text.Trim();   // 終了業種

                            // 開始検索コード
                            if (this.tNedit_BusinessTypeCode_St.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeSt = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeSt = this.tNedit_BusinessTypeCode_St.Text.Trim().PadLeft(4, '0');   // 開始業種
                            }
                            // 終了検索コード
                            if (this.tNedit_BusinessTypeCode_Ed.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeEd = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeEd = this.tNedit_BusinessTypeCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了業種
                            }
                            // 2008.09.24 30413 犬飼 0埋め対応 <<<<<<END
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分別
                        {
                            // 出力順
                            this._salesDayMonthReport.OutType = 0;
                            // 2008.09.24 30413 犬飼 0埋め対応 >>>>>>START
                            //// 開始検索コード
                            //this._salesDayMonthReport.SrchCodeSt = this.tNedit_SalesCode_St.Text.Trim();   // 開始販売区分
                            //// 終了検索コード
                            //this._salesDayMonthReport.SrchCodeEd = this.tNedit_SalesCode_Ed.Text.Trim();   // 終了販売区分

                            // 開始検索コード
                            if (this.tNedit_SalesCode_St.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeSt = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeSt = this.tNedit_SalesCode_St.Text.Trim().PadLeft(4, '0');   // 開始販売区分
                            }
                            // 終了検索コード
                            if (this.tNedit_SalesCode_Ed.Text.Trim() == "")
                            {
                                this._salesDayMonthReport.SrchCodeEd = "";
                            }
                            else
                            {
                                this._salesDayMonthReport.SrchCodeEd = this.tNedit_SalesCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了販売区分
                            }
                            // 2008.09.24 30413 犬飼 0埋め対応 <<<<<<END
                            break;
                        }
                }
                // 2008.08.18 30413 犬飼 帳票種別で検索コードを設定 <<<<<<END
                

				//金額単位
				this._salesDayMonthReport.MoneyUnit = Convert.ToInt32(this.uos_MoneyUnit.CheckedIndex);

                // 2008.12.11 日計無し印刷を追加 >>>>>>START
                // 日計無し印刷
                this._salesDayMonthReport.DaySumPrtDiv = Convert.ToInt32(this.uos_DaySumPrtDiv.CheckedIndex);
                // 2008.12.11 日計無し印刷を追加 <<<<<<END

				//改頁
				this._salesDayMonthReport.CrMode = (int)this.uos_CrMode.Value;
			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
		#endregion
		#endregion ◆ 印刷前処理

		#region ◆ ControlEventからCall
		#region ◎ 絞込み倉庫ガイドEnabledセット処理
		/// <summary>
		/// 絞込み倉庫ガイドEnabledセット処理
		/// </summary>
		/// <param name="targetSt">Enabledセット対象ボタン</param>
		/// <param name="targetEd">Enabledセット対象ボタン</param>
		/// <param name="compareStr1">比較対象文字列1</param>
		/// <param name="compareStr2">比較対象文字列2</param>
		private void ExtractWareHouseGuidSetProc( UltraButton targetSt, UltraButton targetEd, string compareStr1, string compareStr2 )
		{
			// 渡された文字列(絞込み拠点コード)が同じならばガイドボタンをクリック可能にする
			if ( compareStr1.CompareTo( compareStr2 ) == 0 ) 
			{
				targetSt.Enabled = true;
				targetEd.Enabled = true;
			}
			else
			{
				targetSt.Enabled = false;
				targetEd.Enabled = false;
			}
		}
		#endregion
		#endregion

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
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
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
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
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
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}
		#endregion
		#endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
		#endregion ■ Private Method

		#region ■ Control Event
        #region ◆ DCTOK02010UA
        #region ◎ DCTOK02010UA_Load Event
        /// <summary>
		/// MAUKK02010UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		private void DCTOK02010UA_Load ( object sender, EventArgs e )
		{
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
            ParentToolbarGuideSettingEvent(true); // ADD 2010/08/12

            // ADD 2009/03/31 不具合対応[12900]～[12906]：スペースキーでの項目選択機能を実装 ---------->>>>>
            TtlTypeRadioKeyPressHelper.ControlList.Add(this.uos_TtlType);
            TtlTypeRadioKeyPressHelper.StartSpaceKeyControl();

            MoneyUnitRadioKeyPressHelper.ControlList.Add(this.uos_MoneyUnit);
            MoneyUnitRadioKeyPressHelper.StartSpaceKeyControl();

            DaySumPrtRadioKeyPressHelper.ControlList.Add(this.uos_DaySumPrtDiv);
            DaySumPrtRadioKeyPressHelper.StartSpaceKeyControl();

            CrModeRadioKeyPressHelper.ControlList.Add(this.uos_CrMode);
            CrModeRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[12900]～[12906]：スペースキーでの項目選択機能を実装 ----------<<<<<
		}
		#endregion
        #endregion ◆ DCTOK02010UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
            // 2008.09.23 30413 犬飼 ソート順をグループに追加 >>>>>>START
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
                // グループの縮小をキャンセル
				e.Cancel = true;
			}
            // 2008.09.23 30413 犬飼 ソート順をグループに追加 <<<<<<END
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
            // 2008.09.23 30413 犬飼 ソート順をグループに追加 >>>>>>START
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
               (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
               (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}
            // 2008.09.23 30413 犬飼 ソート順をグループに追加 <<<<<<END
		}
		#endregion
		#endregion ◆ ueb_MainExplorerBar

		#endregion ■ Control Event

		/// <summary>
		/// 得意先コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
		private void ub_St_CustomerCodeGuid_Click(object sender, EventArgs e)
		{
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
            
            // 2008.08.27 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.08.27 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // ---ADD 2010/08/12-------------------->>>
                ParentToolbarGuideSettingEvent(true);
                // ---ADD 2010/08/12--------------------<<<
            }
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
        }

		/// <summary>
		/// 得意先コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
		private void ub_Ed_CustomerCodeGuid_Click(object sender, EventArgs e)
		{
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
            
            // 2008.08.27 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.08.27 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
            {
                // ---UPD 2010/08/12-------------------->>>
                //// ガイド呼出前と違う、クリアされていない場合
                //// 次のコントロールへフォーカスを移動
                //this.SelectNextControl((Control)sender, true, true, true, true);

                SFCMN06002C printInfo = new SFCMN06002C();
                printInfo.printmode = 3;
                printInfo.pdfopen = false;
                printInfo.pdftemppath = "";

                IPrintConditionInpType childObj = this as IPrintConditionInpType;

                // 印刷前チェック
                if (!childObj.PrintBeforeCheck())
                {
                    return;
                }

                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                Object parameter = (object)printInfo;

                // チャート出力あり？
                if (this is IPrintConditionInpTypeChart)
                {
                    // 抽出処理
                    status = childObj.Extract(ref parameter);
                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return;
                    }
                }

                // 印刷処理
                childObj.Print(ref parameter);
                // ---UPD 2010/08/12--------------------<<<
            }
            // ---ADD 2010/08/12-------------------->>>
            this.tNedit_CustomerCode_Ed.Focus();
            ParentToolbarGuideSettingEvent(true);
            // ---ADD 2010/08/12--------------------<<<
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
		}

		/// <summary>
		/// 担当者コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
		private void ub_St_StockAgentCodeGuid_Click(object sender, EventArgs e)
		{
			int status = -1;

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // ---ADD 2010/08/12-------------------->>>
                ParentToolbarGuideSettingEvent(true);
                // ---ADD 2010/08/12--------------------<<<
			}

		}

		/// <summary>
		/// 担当者コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void ub_Ed_StockAgentCodeGuid_Click(object sender, EventArgs e)
		{
			int status = -1;

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
			}

		}

		/// <summary>
		/// 受注者コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
		private void ub_FrontEmployeeCdStGuid_Click(object sender, EventArgs e)
		{
			int status = -1;

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.tEdit_FrontEmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // ---ADD 2010/08/12-------------------->>>
                ParentToolbarGuideSettingEvent(true);
                // ---ADD 2010/08/12--------------------<<<
			}
		}

		/// <summary>
		/// 受注者コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void ub_FrontEmployeeCdEdGuid_Click(object sender, EventArgs e)
		{
			int status = -1;

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.tEdit_FrontEmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		/// <summary>
		/// 発行者コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
		private void ub_SalesEmployeeCdStGuid_Click(object sender, EventArgs e)
		{
			int status = -1;

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.tEdit_SalesEmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // ---ADD 2010/08/12-------------------->>>
                ParentToolbarGuideSettingEvent(true);
                // ---ADD 2010/08/12--------------------<<<
			}
		}

		/// <summary>
		/// 発行者コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void ub_SalesEmployeeCdEdGuid_Click(object sender, EventArgs e)
		{
			int status = -1;

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.tEdit_SalesEmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		/// <summary>
		/// 販売エリアコード(開始)ガイド起動ボタン起動イベント
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
		private void ub_SalesAreaCodeStGuid_Click(object sender, EventArgs e)
		{
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 >>>>>>START
            //if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            //UserGdBd userGdBd = new UserGdBd();
            //System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(21, 0, this._enterpriseCode, ref userGdBd);

            //if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            //{
            //    this.tne_SalesAreaCodeSt.SetInt(userGdBd.GuideCode);
            //}

            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // ---ADD 2010/08/12-------------------->>>
                ParentToolbarGuideSettingEvent(true);
                // ---ADD 2010/08/12--------------------<<<
            }
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 <<<<<<END
        }

		/// <summary>
		/// 販売エリアコード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void ub_SalesAreaCodeEdGuid_Click(object sender, EventArgs e)
		{
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 >>>>>>START
            //if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            //UserGdBd userGdBd = new UserGdBd();
            //System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(21, 0, this._enterpriseCode, ref userGdBd);

            //if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            //{
            //    this.tne_SalesAreaCodeEd.SetInt(userGdBd.GuideCode);
            //}

            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 <<<<<<END
		}

		/// <summary>
		/// 業種コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
		private void ub_BusinessTypeCodeStGuid_Click(object sender, EventArgs e)
		{
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 >>>>>>START
            //if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            //UserGdBd userGdBd = new UserGdBd();
            //System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(33, 0, this._enterpriseCode, ref userGdBd);

            //if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            //{
            //    this.tne_BusinessTypeCodeSt.SetInt(userGdBd.GuideCode);
            //}

            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // ---ADD 2010/08/12-------------------->>>
                ParentToolbarGuideSettingEvent(true);
                // ---ADD 2010/08/12--------------------<<<
            }
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 <<<<<<END
		}

		/// <summary>
		/// 業種コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void ub_BusinessTypeCodeEdGuid_Click(object sender, EventArgs e)
		{
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 >>>>>>START
            //if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            //UserGdBd userGdBd = new UserGdBd();
            //System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(33, 0, this._enterpriseCode, ref userGdBd);

            //if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            //{
            //    this.tne_BusinessTypeCodeEd.SetInt(userGdBd.GuideCode);
            //}

            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.08.27 30413 犬飼 ユーザーガイドクラスの変更 <<<<<<END
		}

		/// <summary>
		/// 得意先(開始)選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

			int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 取得した得意先コード(開始)を画面に表示する
				this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した得意先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

				return;
			}
		}

		/// <summary>
		/// 得意先(終了)選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

			int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 取得した得意先コード(開始)を画面に表示する
				this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した得意先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

				return;
			}
		}

        /// <summary>
        /// 集計方法の選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uos_TtlType_ValueChanged(object sender, EventArgs e)
		{
            // 2008.08.22 30413 犬飼 改頁ラジオボタンの更新 >>>>>>START
            //if (this.uos_TtlType.CheckedIndex == 0)
            //{
            //    this.uos_CrMode.CheckedIndex = 0;
            //    this.uos_CrMode.Enabled = false;
            //}
            //else
            //{
            //    this.uos_CrMode.Enabled = true;
            //}
            // 改頁ラジオボタンの制御
            ChangeCrModeItem();
            // 2008.08.22 30413 犬飼 改頁ラジオボタンの更新 <<<<<<END
		}

        /// <summary>
        /// 出力順の選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PrintOder_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {
            ChangeCrModeItem();         
        }

        /// <summary>
        /// 改頁ラジオボタンのアイテム制御
        /// </summary>
        private void ChangeCrModeItem()
        {
            if (this._mode == (int)SalesDayMonthReport.TotalTypeState.SalesDiv)
            {
                // 販売区分別
                if (this.uos_CrMode.Value == null)
                {
                    return;
                }
            }
            else
            {
                // 販売区分別以外
                if ((this.PrintOder_tComboEditor.Value == null) || (this.uos_CrMode.Value == null))
                {
                    return;
                }
            }

            // 改頁ラジオボタンの更新開始
            this.uos_CrMode.BeginUpdate();

            // 帳票の種類により処理を分ける
            switch (this._mode)
            {
                case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                    {
                        if (this.uos_TtlType.CheckedIndex == 0)
                        {
                            // 集計方法が全社
                            this.uos_CrMode.CheckedIndex = 0;
                            if (this.uos_CrMode.Items.Count > 1)
                            {                
                                // ”拠点単位”を削除
                                this.uos_CrMode.Items.RemoveAt(1);
                            }
                        }
                        else
                        {
                            // 集計方法が拠点
                            if ((int)PrintOder_tComboEditor.Value == 1)
                            {
                                // 出力順が「拠点」
                                this.uos_CrMode.CheckedIndex = 0;
                                if (this.uos_CrMode.Items.Count > 1)
                                {
                                    // ”拠点単位”を削除
                                    this.uos_CrMode.Items.RemoveAt(1);
                                }
                            }
                            else
                            {
                                // 出力順が「拠点」以外
                                if (this.uos_CrMode.Items.Count < 2)
                                {
                                    // ”拠点単位”を追加
                                    Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                                    item.DataValue = 1;
                                    item.DisplayText = "";
                                    this.uos_CrMode.Items.Add(item);
                                }

                                if ((int)PrintOder_tComboEditor.Value == 2)
                                {
                                    // 出力順が「得意先－拠点」
                                    this.uos_CrMode.Items[1].DisplayText = "得意先単位";
                                }
                                else
                                {
                                    // 出力順が「得意先－拠点」以外
                                    this.uos_CrMode.Items[1].DisplayText = "拠点単位";
                                    this.uos_CrMode.CheckedIndex = 1;
                                }
                            }
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                    {
                        if (this.uos_TtlType.CheckedIndex == 0)
                        {
                            // 集計方法が全社
                            this.uos_CrMode.CheckedIndex = 0;
                            while (this.uos_CrMode.Items.Count > 1)
                            {
                                // ”改頁なし”以外を削除
                                this.uos_CrMode.Items.RemoveAt(1);
                            }

                            // XXX単位を追加
                            Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                            item.DataValue = 2;
                            switch (this._mode)
                            {
                                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                                    {
                                        item.DisplayText = "担当者単位";
                                        break;
                                    }
                                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                                    {
                                        item.DisplayText = "受注者単位";
                                        break;
                                    }
                                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                                    {
                                        item.DisplayText = "発行者単位";
                                        break;
                                    }
                            }
                            this.uos_CrMode.Items.Add(item);

                            // 2008.12.12 30413 犬飼 「XXX－拠点」を追加 >>>>>>START
                            //if (((int)PrintOder_tComboEditor.Value == 0) || ((int)PrintOder_tComboEditor.Value == 3))
                            if (((int)PrintOder_tComboEditor.Value == 0) || ((int)PrintOder_tComboEditor.Value == 3) ||
                                ((int)PrintOder_tComboEditor.Value == 2))
                            {
                                // 出力順が「XXX」または「管理拠点」または「XXX－拠点」
                                this.uos_CrMode.CheckedIndex = 0;
                                this.uos_CrMode.Items.RemoveAt(1);
                            }
                            // 2008.12.12 30413 犬飼 「XXX－拠点」を追加  <<<<<<END
                        }
                        else
                        {
                            // 集計方法が拠点
                            if (this.uos_CrMode.Items.Count < 3)
                            {
                                // ”改頁なし”以外が存在する
                                int tmpVal = (int)this.uos_CrMode.Value;
                                this.uos_CrMode.CheckedIndex = 0;

                                while (this.uos_CrMode.Items.Count > 1)
                                {
                                    // ”改頁なし”以外を削除
                                    this.uos_CrMode.Items.RemoveAt(1);
                                }

                                // ”拠点単位”の追加
                                Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                                item.DataValue = 1;
                                item.DisplayText = "拠点単位";
                                this.uos_CrMode.Items.Add(item);

                                // XXX単位を追加
                                item = new Infragistics.Win.ValueListItem();
                                item.DataValue = 2;
                                switch (this._mode)
                                {
                                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                                        {
                                            item.DisplayText = "担当者単位";
                                            break;
                                        }
                                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                                        {
                                            item.DisplayText = "受注者単位";
                                            break;
                                        }
                                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                                        {
                                            item.DisplayText = "発行者単位";
                                            break;
                                        }
                                }
                                this.uos_CrMode.Items.Add(item);

                                this.uos_CrMode.Value = tmpVal;
                            }

                            if (((int)PrintOder_tComboEditor.Value == 0) || ((int)PrintOder_tComboEditor.Value == 3))
                            {
                                // 出力順が「XXX」または「管理拠点」
                                this.uos_CrMode.CheckedIndex = 1;
                                this.uos_CrMode.Items.RemoveAt(2);                                
                            }
                            else if ((int)PrintOder_tComboEditor.Value == 2)
                            {
                                // 出力順が「XXX－拠点」
                                this.uos_CrMode.CheckedIndex = 0;
                                this.uos_CrMode.Items.RemoveAt(1);  
                            }
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    {
                        if (this.uos_TtlType.CheckedIndex == 0)
                        {
                            // 集計方法が全社
                            this.uos_CrMode.CheckedIndex = 0;
                            while (this.uos_CrMode.Items.Count > 1)
                            {
                                // ”改頁なし”以外を削除
                                this.uos_CrMode.Items.RemoveAt(1);
                            }

                            // XXX単位を追加
                            Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                            item.DataValue = 2;
                            switch (this._mode)
                            {
                                case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                                    {
                                        item.DisplayText = "地区単位";
                                        break;
                                    }
                                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                                    {
                                        item.DisplayText = "業種単位";
                                        break;
                                    }
                            }
                            this.uos_CrMode.Items.Add(item);

                            // 2008.12.12 30413 犬飼 「XXX－拠点」を追加 >>>>>>START
                            //if ((int)PrintOder_tComboEditor.Value == 0)
                            if (((int)PrintOder_tComboEditor.Value == 0) || ((int)PrintOder_tComboEditor.Value == 2))
                            {
                                // 出力順が「XXX」または「XXX－拠点」
                                this.uos_CrMode.CheckedIndex = 0;
                                this.uos_CrMode.Items.RemoveAt(1);
                            }
                            // 2008.12.12 30413 犬飼 「XXX－拠点」を追加 <<<<<<END
                        }
                        else
                        {
                            // 集計方法が拠点
                            if (this.uos_CrMode.Items.Count < 3)
                            {
                                // ”改頁なし”以外が存在する
                                int tmpVal = (int)this.uos_CrMode.Value;
                                this.uos_CrMode.CheckedIndex = 0;

                                while (this.uos_CrMode.Items.Count > 1)
                                {
                                    // ”改頁なし”以外を削除
                                    this.uos_CrMode.Items.RemoveAt(1);
                                }

                                // ”拠点単位”の追加
                                Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                                item.DataValue = 1;
                                item.DisplayText = "拠点単位";
                                this.uos_CrMode.Items.Add(item);

                                // ”XXX単位”の追加
                                item = new Infragistics.Win.ValueListItem();
                                item.DataValue = 2;
                                switch (this._mode)
                                {
                                    case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                                        {
                                            item.DisplayText = "地区単位";
                                            break;
                                        }
                                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                                        {
                                            item.DisplayText = "業種単位";
                                            break;
                                        }
                                }
                                this.uos_CrMode.Items.Add(item);

                                this.uos_CrMode.Value = tmpVal;
                            }

                            if ((int)PrintOder_tComboEditor.Value == 0)
                            {
                                // 出力順が「XXX」
                                this.uos_CrMode.CheckedIndex = 1;
                                this.uos_CrMode.Items.RemoveAt(2);
                            }
                            else if ((int)PrintOder_tComboEditor.Value == 2)
                            {
                                // 出力順が「XXX－拠点」
                                this.uos_CrMode.CheckedIndex = 0;
                                this.uos_CrMode.Items.RemoveAt(1);
                            }
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分別
                    {
                        if (this.uos_TtlType.CheckedIndex == 0)
                        {
                            // 集計方法が全社
                            this.uos_CrMode.CheckedIndex = 0;
                            while (this.uos_CrMode.Items.Count > 1)
                            {
                                // ”改頁なし”以外を削除
                                this.uos_CrMode.Items.RemoveAt(1);
                            }
                        }
                        else
                        {
                            if (this.uos_CrMode.Items.Count == 1)
                            {
                                // 集計方法が拠点
                                Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                                item.DataValue = 1;
                                item.DisplayText = "拠点単位";
                                this.uos_CrMode.Items.Add(item);
                                this.uos_CrMode.CheckedIndex = 1;
                            }
                        }
                        break;
                    }
            }

            // 2008.12.03 30413 犬飼 フォーカスindexをチェックindexと同じにする >>>>>>START
            this.uos_CrMode.FocusedIndex = this.uos_CrMode.CheckedIndex;
            // 2008.12.03 30413 犬飼 フォーカスindexをチェックindexと同じにする <<<<<<END
            
            // 改頁ラジオボタンの更新終了
            this.uos_CrMode.EndUpdate();
        }

        /// <summary>
        /// 販売区分(開始)ガイド起動ボタン起動イベント
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void ub_SalesCodeStGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesCode_St.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // ---ADD 2010/08/12-------------------->>>
                ParentToolbarGuideSettingEvent(true);
                // ---ADD 2010/08/12--------------------<<<
            }
        }

        /// <summary>
        /// 販売区分(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void ub_SalesCodeEdGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesCode_Ed.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34098 罫線印字制御を追加する</br>
        /// <br>UpdateNote  : 2013/03/08 cheq</br>
        /// <br>管理番号    : 10900690-00 2013/03/26配信分</br>
        /// <br>            : Redmine#34987 帳票redmine#34098の残分の対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ---ADD 2010/08/12-------------------->>>
            // リスト項目をコードからでも入力可能へ変更
            if (e.PrevCtrl == this.PrintOder_tComboEditor)
            {
                if ((int)this._preComboEditorValue != (int)this.PrintOder_tComboEditor.Value) // ADD 2013/04/05 T.Miyamoto
                {
                    setTComboEditorByName(this.PrintOder_tComboEditor.Name);
                    this._preComboEditorValue = this.PrintOder_tComboEditor.Value;
                    // --- ADD 2010/08/27 --- >>>>>
                    ChangeCrModeItem();
                    // --- ADD 2010/08/27 --- <<<<<
                }
            }
            // ---ADD 2010/08/12--------------------<<<
            // --- ADD 2010/08/26 --- >>>>>
            this._preControl = e.NextCtrl;
            // --- ADD 2010/08/26 --- <<<<<
            // 2008.09.23 30413 犬飼 ガイドボタン遷移制御 >>>>>>START
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                // ---UPD 2010/08/12-------------------->>>
                //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Right))
                // ---UPD 2010/08/12--------------------<<<
                {
                    if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_St)
                    {
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_SalesEmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_Ed)
                    {
                        // 担当者(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_St)
                    {
                        // 受注者(開始)→受注者(終了)
                        e.NextCtrl = this.tEdit_FrontEmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_Ed)
                    {
                        // 受注者(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        // 発行者(開始)→発行者(終了)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // 発行者(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
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
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
                    {
                        // 業種(開始)→業種(終了)
                        e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_Ed)
                    {
                        // 業種(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_St)
                    {
                        // 販売区分(開始)→販売区分(終了)
                        e.NextCtrl = this.tNedit_SalesCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_Ed)
                    {
                        // 販売区分(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ---UPD 2010/08/12-------------------->>>
                        //// 得意先(終了)→対象日(開始)
                        //e.NextCtrl = this.tde_SalesDateSt;
                        // 得意先（終了）の中身を全表示する
                        // --- UPD 2010/08/26 ---------->>>>>
                        if (ParentPrintCall != null)
                        {
                            this.ParentPrintCall();
                        }

                        // フォーカス設定
                        e.NextCtrl = null;
                        // --- UPD 2010/08/26 ----------<<<<<
                        // ---UPD 2010/08/12--------------------<<<
                    }
                    // ---ADD 2010/08/12-------------------->>>
                    else if (e.PrevCtrl == this.uos_TtlType)
                    {
                        // 集計方法→対象日(開始)
                        e.NextCtrl = this.tde_SalesDateSt;
                    }
                    else if (e.PrevCtrl == this.tde_SalesDateEd)
                    {
                        // 対象日(終了)→金額単位
                        e.NextCtrl = this.uos_MoneyUnit;
                        this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.uos_MoneyUnit)
                    {
                        if (this.uos_DaySumPrtDiv.Visible)
                        {
                            // 金額単位→日計無し印刷
                            e.NextCtrl = this.uos_DaySumPrtDiv;
                            this.uos_DaySumPrtDiv.FocusedIndex = (int)this.uos_DaySumPrtDiv.CheckedItem.DataValue;
                        }
                        else
                        {
                            // ---- DEL cheq 2013/03/08 for Redmine #34987 ---->>>>>
                            // 金額単位→改頁
                            //e.NextCtrl = this.uos_CrMode;
                            // this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                            // ---- DEL cheq 2013/03/08 for Redmine #34987 ----<<<<<
                            // 金額単位→罫線印字
                            e.NextCtrl = this.tComboEditor_LineMaSqOfCh;//ADD cheq 2013/03/08 for Redmine #34987
                        }
                    }
                    else if (e.PrevCtrl == this.uos_DaySumPrtDiv)
                    {
                        //----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        // 日計無し印刷→改頁
                        //e.NextCtrl = this.uos_CrMode;
                        // this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                        //----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<<
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;// ADD cheq 2013/03/08 for Redmine #34987
                    }
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.uos_CrMode)
                    {
                        // 改頁→罫線印字
                        //e.NextCtrl = this.tComboEditor_LineMaSqOfCh; // DEL cheq 2013/03/08 for Redmine #34987
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        if (this.PrintOder_tComboEditor.Visible)
                        {
                            // 改頁→出力順
                            e.NextCtrl = this.PrintOder_tComboEditor;
                        }
                        // 出力順なし
                        else
                        {
                            switch (this._mode)
                            {
                                // 得意先別
                                case (int)SalesDayMonthReport.TotalTypeState.Customer:
                                    {
                                        // 改頁→得意先（開始）
                                        e.NextCtrl = this.tNedit_CustomerCode_St;
                                        break;
                                    }
                                // 担当者別
                                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:
                                    {
                                        // 改頁→担当者（開始）
                                        e.NextCtrl = this.tEdit_SalesEmployeeCode_St;
                                        break;
                                    }
                                // 受注者別
                                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:
                                    {
                                        // 改頁→受注者（開始）
                                        e.NextCtrl = this.tEdit_FrontEmployeeCode_St;
                                        break;
                                    }
                                // 発行者別
                                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:
                                    {
                                        // 改頁→発行者（開始）
                                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                                        break;
                                    }
                                // 地区別
                                case (int)SalesDayMonthReport.TotalTypeState.Area:
                                    {
                                        // 改頁→地区（開始）
                                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                                        break;
                                    }
                                // 業種別
                                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:
                                    {
                                        // 改頁→業種（開始）
                                        e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                                        break;
                                    }
                                // 販売区分別
                                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:
                                    {
                                        // 改頁→販売区分（開始）
                                        e.NextCtrl = this.tNedit_SalesCode_St;
                                        break;
                                    }
                            }
                        }
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 -----<<<<<
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                    //else if (e.PrevCtrl == this.uos_CrMode)// DEL zhuhh 2012/12/28 for Redmine #34098
                    {
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                        bool errorFlag = true;
                        foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_LineMaSqOfCh.Items)
                        {
                            if (item.DataValue == this.tComboEditor_LineMaSqOfCh.Value)
                            {
                                errorFlag = false;
                                break;
                            }
                        }
                        if (errorFlag)
                        {
                            this.tComboEditor_LineMaSqOfCh.Value = this._preComboEditor_LineMaSqOfChValue;
                        }
                        else
                        {
                            this._preComboEditor_LineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;
                        }
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                        /* ----- DEL cheq 2013/03/08 for Redmine34987 ----->>>>>
                        // 出力順あり
                        if (this.PrintOder_tComboEditor.Visible)
                        {
                            // 改頁→出力順
                            e.NextCtrl = this.PrintOder_tComboEditor;
                        }
                        // 出力順なし
                        else
                        {
                            switch (this._mode)
                            {
                                // 得意先別
                                case (int)SalesDayMonthReport.TotalTypeState.Customer:
                                    {
                                        // 改頁→得意先（開始）
                                        e.NextCtrl = this.tNedit_CustomerCode_St;
                                        break;
                                    }
                                // 担当者別
                                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:
                                    {
                                        // 改頁→担当者（開始）
                                        e.NextCtrl = this.tEdit_SalesEmployeeCode_St;
                                        break;
                                    }
                                // 受注者別
                                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:
                                    {
                                        // 改頁→受注者（開始）
                                        e.NextCtrl = this.tEdit_FrontEmployeeCode_St;
                                        break;
                                    }
                                // 発行者別
                                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:
                                    {
                                        // 改頁→発行者（開始）
                                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                                        break;
                                    }
                                // 地区別
                                case (int)SalesDayMonthReport.TotalTypeState.Area:
                                    {
                                        // 改頁→地区（開始）
                                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                                        break;
                                    }
                                // 業種別
                                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:
                                    {
                                        // 改頁→業種（開始）
                                        e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                                        break;
                                    }
                                // 販売区分別
                                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:
                                    {
                                        // 改頁→販売区分（開始）
                                        e.NextCtrl = this.tNedit_SalesCode_St;
                                        break;
                                    }
                            }
                        }
                         ----- DEL cheq 2013/03/08 for Redmine34987 -----<<<<<*/
                        // ----- ADD cheq 2013/03/08 for Redmine34987 ----->>>>>
                        e.NextCtrl = this.uos_CrMode;
                        // UPD 2013/04/05 T.Miyamoto ------------------------------>>>>>
                        //this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                        this.uos_CrMode.FocusedIndex = this.uos_CrMode.CheckedIndex;
                        // UPD 2013/04/05 T.Miyamoto ------------------------------<<<<<
                        // ----- ADD cheq 2013/03/08 for Redmine34987 -----<<<<<
                    }
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        switch (this._mode)
                        {
                            // 得意先別
                            case (int)SalesDayMonthReport.TotalTypeState.Customer:
                                {
                                    // 出力順→得意先（開始）
                                    e.NextCtrl = this.tNedit_CustomerCode_St;
                                    break;
                                }
                            // 担当者別
                            case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:
                                {
                                    // 出力順→担当者（開始）
                                    e.NextCtrl = this.tEdit_SalesEmployeeCode_St;
                                    break;
                                }
                            // 受注者別
                            case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:
                                {
                                    // 出力順→受注者（開始）
                                    e.NextCtrl = this.tEdit_FrontEmployeeCode_St;
                                    break;
                                }
                            // 発行者別
                            case (int)SalesDayMonthReport.TotalTypeState.SalesInput:
                                {
                                    // 出力順→発行者（開始）
                                    e.NextCtrl = this.tEdit_SalesInputCode_St;
                                    break;
                                }
                            // 地区別
                            case (int)SalesDayMonthReport.TotalTypeState.Area:
                                {
                                    // 出力順→地区（開始）
                                    e.NextCtrl = this.tNedit_SalesAreaCode_St;
                                    break;
                                }
                            // 業種別
                            case (int)SalesDayMonthReport.TotalTypeState.BusinessType:
                                {
                                    // 出力順→業種（開始）
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                                    break;
                                }
                            // 販売区分別
                            case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:
                                {
                                    // 出力順→販売区分（開始）
                                    e.NextCtrl = this.tNedit_SalesCode_St;
                                    break;
                                }
                        }
                    }
                    else if (e.PrevCtrl == this.ub_CustomerCodeEdGuid)
                    {
                        // 得意先（終了）ボタン→対象日(開始)
                        e.NextCtrl = this.tde_SalesDateSt;
                    }
                    // ---ADD 2010/08/12--------------------<<<
                }
                // ---ADD 2010/08/12-------------------->>>
                else if (e.Key == Keys.Left)
                {
                    if (e.PrevCtrl == this.uos_TtlType)
                    {
                        // 集計方法→得意先(終了)
                        e.NextCtrl = null;
                    }
                    else if (e.PrevCtrl == this.tde_SalesDateSt)
                    {
                        // 対象日(開始)→集計方法
                        e.NextCtrl = this.uos_TtlType;
                        this.uos_TtlType.FocusedIndex = (int)this.uos_TtlType.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        switch (this._mode)
                        {
                            // 得意先別
                            case (int)SalesDayMonthReport.TotalTypeState.Customer:
                                {
                                    // 得意先（開始）→出力順
                                    e.NextCtrl = this.PrintOder_tComboEditor;
                                    break;
                                }
                            // 担当者別
                            case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:
                                {
                                    // 得意先（開始）→担当者（終了）
                                    e.NextCtrl = this.tEdit_SalesEmployeeCode_Ed;
                                    break;
                                }
                            // 受注者別
                            case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:
                                {
                                    // 得意先（開始）→受注者（終了）
                                    e.NextCtrl = this.tEdit_FrontEmployeeCode_Ed;
                                    break;
                                }
                            // 発行者別
                            case (int)SalesDayMonthReport.TotalTypeState.SalesInput:
                                {
                                    // 得意先（開始）→発行者（終了）
                                    e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                                    break;
                                }
                            // 地区別
                            case (int)SalesDayMonthReport.TotalTypeState.Area:
                                {
                                    // 得意先（開始）→地区（終了）
                                    e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                                    break;
                                }
                            // 業種別
                            case (int)SalesDayMonthReport.TotalTypeState.BusinessType:
                                {
                                    // 得意先（開始）→業種（終了）
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                                    break;
                                }
                            // 販売区分別
                            case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:
                                {
                                    // 得意先（開始）→販売区分（終了）
                                    e.NextCtrl = this.tNedit_SalesCode_Ed;
                                    break;
                                }
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_Ed)
                    {
                        // 担当者（終了）→担当者（開始）
                        e.NextCtrl = this.tEdit_SalesEmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_Ed)
                    {
                        // 受注者（終了）→受注者（開始）
                        e.NextCtrl = this.tEdit_FrontEmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // 発行者（終了）→発行者（開始）
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区（終了）→地区（開始）
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_Ed)
                    {
                        // 業種（終了）→業種（開始）
                        e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_Ed)
                    {
                        // 販売区分（終了）→販売区分（開始）
                        e.NextCtrl = this.tNedit_SalesCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_St)
                    {
                        // 担当者（開始）→出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_St)
                    {
                        // 受注者（開始）→出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        // 発行者（開始）→出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区（開始）→出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
                    {
                        // 業種（開始）→出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_St)
                    {
                        // 販売区分（開始）→改頁
                        e.NextCtrl = this.uos_CrMode;
                        this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                    }
                    /* ----- DEL zhuhh 2012/12/28 for Redmine #340987 ----->>>>>
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // 出力順→改頁
                        e.NextCtrl = this.uos_CrMode;
                        this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                    }
                       ----- DEL zhuhh 2012/12/28 for Redmine #34098 -----<<<<< */
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                        bool errorFlag = true;
                        foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_LineMaSqOfCh.Items)
                        {
                            if (item.DataValue == this.tComboEditor_LineMaSqOfCh.Value)
                            {
                                errorFlag = false;
                                break;
                            }
                        }
                        if (errorFlag)
                        {
                            this.tComboEditor_LineMaSqOfCh.Value = this._preComboEditor_LineMaSqOfChValue;
                        }
                        else
                        {
                            this._preComboEditor_LineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;
                        }
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                        // 出力順→罫線印字
                        //e.NextCtrl = this.tComboEditor_LineMaSqOfCh; // DEL cheq 2013/03/08 for Redmine #34987
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 ---->>>>>
                        e.NextCtrl = this.uos_CrMode;
                        // UPD 2013/04/05 T.Miyamoto ------------------------------>>>>>
                        //this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                        this.uos_CrMode.FocusedIndex = this.uos_CrMode.CheckedIndex;
                        // UPD 2013/04/05 T.Miyamoto ------------------------------<<<<<
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 ----<<<<<
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                        // ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        //罫線印字→改頁
                        //e.NextCtrl = this.uos_CrMode;
                        //this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                        // ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<<
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        if (this.uos_DaySumPrtDiv.Visible)
                        {
                            // 改頁→日計無し印刷
                            e.NextCtrl = this.uos_DaySumPrtDiv;
                            this.uos_DaySumPrtDiv.FocusedIndex = (int)this.uos_DaySumPrtDiv.CheckedItem.DataValue;
                        }
                        else
                        {
                            // 改頁→金額単位
                            e.NextCtrl = this.uos_MoneyUnit;
                            this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                        }
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 -----<<<<<
                    }
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                    else if (e.PrevCtrl == this.uos_CrMode)
                    {
                        /* ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        if (this.uos_DaySumPrtDiv.Visible)
                        {
                            // 改頁→日計無し印刷
                            e.NextCtrl = this.uos_DaySumPrtDiv;
                            this.uos_DaySumPrtDiv.FocusedIndex = (int)this.uos_DaySumPrtDiv.CheckedItem.DataValue;
                        }
                        else
                        {
                            // 改頁→金額単位
                            e.NextCtrl = this.uos_MoneyUnit;
                            this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                        }
                         ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<< */
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh; // ADD cheq 2013/03/08 for Redmine #34987 
                    }
                    else if (e.PrevCtrl == this.uos_DaySumPrtDiv)
                    {
                        // 日計無し印刷→金額単位
                        e.NextCtrl = this.uos_MoneyUnit;
                        this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.uos_MoneyUnit)
                    {
                        // 金額単位→対象日(終了)
                        e.NextCtrl = this.tde_SalesDateEd.Controls[3];
                    }
                    else if (e.PrevCtrl == this.tde_SalesDateEd)
                    {
                        // 対象日(終了)→対象日(開始)
                        e.NextCtrl = this.tde_SalesDateSt;
                    }

                }
                // ---ADD 2010/08/12--------------------<<<
            }
            else
            {
                // SHIFTキー押下
                // ---UPD 2010/08/12-------------------->>>
                //if (e.Key == Keys.Tab)
                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                // ---UPD 2010/08/12--------------------<<<
                {
                    if (e.PrevCtrl == this.tde_SalesDateSt)
                    {
                        // ---UPD 2010/08/12-------------------->>>
                        //// 対象日(開始)→得意先(終了)
                        //e.NextCtrl = this.tNedit_CustomerCode_Ed;
                        // 対象日(開始)→集計方法
                        e.NextCtrl = this.uos_TtlType;
                        this.uos_TtlType.FocusedIndex = (int)this.uos_TtlType.CheckedItem.DataValue;
                        // ---UPD 2010/08/12--------------------<<<
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)
                        if (e.NextCtrl == this.PrintOder_tComboEditor)
                        {
                            ;
                        }
                        else if (e.NextCtrl == this.ub_SalesEmployeeCdEdGuid)
                        {
                            // →担当者(終了)
                            e.NextCtrl = this.tEdit_SalesEmployeeCode_Ed;
                        }
                        else if (e.NextCtrl == this.ub_FrontEmployeeCdEdGuid)
                        {
                            // →受注者(終了)
                            e.NextCtrl = this.tEdit_FrontEmployeeCode_Ed;
                        }
                        else if (e.NextCtrl == this.ub_SalesInputCodeEdGuid)
                        {
                            // →発行者(終了)
                            e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                        }
                        else if (e.NextCtrl == this.ub_SalesAreaCodeEdGuid)
                        {
                            // →地区(終了)
                            e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                        }
                        else if (e.NextCtrl == this.ub_BusinessTypeCodeEdGuid)
                        {
                            // →業種(終了)
                            e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                        }
                        else if (e.NextCtrl == this.ub_SalesCodeEdGuid)
                        {
                            // →販売区分(終了)
                            e.NextCtrl = this.tNedit_SalesCode_Ed;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_Ed)
                    {
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_SalesEmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_Ed)
                    {
                        // 受注者(終了)→受注者(開始)
                        e.NextCtrl = this.tEdit_FrontEmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // 発行者(終了)→発行者(開始)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)→地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_Ed)
                    {
                        // 業種(終了)→業種(開始)
                        e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_Ed)
                    {
                        // 販売区分(終了)→販売区分(開始)
                        e.NextCtrl = this.tNedit_SalesCode_St;
                    }
                    // ---ADD 2010/08/12-------------------->>>
                    else if (e.PrevCtrl == this.uos_TtlType)
                    {
                        // 集計方法→得意先(終了)
                        e.NextCtrl = null;
                    }
                    else if (e.NextCtrl == this.uos_MoneyUnit)
                    {
                        // →金額単位
                        this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                    }
                    else if (e.NextCtrl == this.uos_DaySumPrtDiv)
                    {
                        // →日計無し印刷
                        this.uos_DaySumPrtDiv.FocusedIndex = (int)this.uos_DaySumPrtDiv.CheckedItem.DataValue;
                    }
                    else if (e.NextCtrl == this.uos_CrMode)
                    {
                        // →改頁
                        // UPD 2013/04/05 T.Miyamoto ------------------------------>>>>>
                        //this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                        this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedIndex;
                        // UPD 2013/04/05 T.Miyamoto ------------------------------<<<<<
                    }
                    // ---ADD 2010/08/12--------------------<<<
                    // ----- ADD cheq 2013/03/08 for Redmine #34987 ----->>>>>
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        e.NextCtrl = this.uos_CrMode;
                        // UPD 2013/04/05 T.Miyamoto ------------------------------>>>>>
                        //this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                        this.uos_CrMode.FocusedIndex = this.uos_CrMode.CheckedIndex;
                        // UPD 2013/04/05 T.Miyamoto ------------------------------<<<<<
                    }
                    else if (e.PrevCtrl == this.uos_CrMode)
                    {
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                    }
                    else if (e.NextCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                        if (this.uos_DaySumPrtDiv.Enabled && this.uos_DaySumPrtDiv.Visible)
                        {
                            e.NextCtrl = this.uos_DaySumPrtDiv;
                            this.uos_DaySumPrtDiv.FocusedIndex = (int)this.uos_DaySumPrtDiv.CheckedItem.DataValue;
                        }
                        else
                        {
                            e.NextCtrl = this.uos_MoneyUnit;
                            this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                        }
                    }
                    // ----- ADD cheq 2013/03/08 for Redmine #34987 -----<<<<<
                }
            }
            // 2008.09.23 30413 犬飼 ガイドボタン遷移制御 <<<<<<END
            // ---ADD 2010/08/12-------------------->>>
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_CustomerCode_St":
                    case "tNedit_CustomerCode_Ed":
                    case "tEdit_SalesEmployeeCode_St":
                    case "tEdit_SalesEmployeeCode_Ed":
                    case "tEdit_FrontEmployeeCode_St":
                    case "tEdit_FrontEmployeeCode_Ed":
                    case "tEdit_SalesInputCode_St":
                    case "tEdit_SalesInputCode_Ed":
                    case "tNedit_SalesAreaCode_St":
                    case "tNedit_SalesAreaCode_Ed":
                    case "tNedit_BusinessTypeCode_St":
                    case "tNedit_BusinessTypeCode_Ed":
                    case "tNedit_SalesCode_St":
                    case "tNedit_SalesCode_Ed":
                        {
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    default:
                        {
                            if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                || e.NextCtrl is TDateEdit || e.NextCtrl is UltraOptionSet || e.NextCtrl is UltraButton)
                            {
                                ParentToolbarGuideSettingEvent(false);
                            }
                            break;
                        }
                }
            }
            // ---ADD 2010/08/12--------------------<<<
        }

        #region ■ KeyDown Event
        // ---ADD 2010/08/12-------------------->>>
        /// <summary>
        /// 集計方法でキー押下イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void uos_TtlType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                // 集計方法→対象日(開始)
                this.tde_SalesDateSt.Focus();
            }
        }

        /// <summary>
        /// 金額単位でキー押下イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>UpdateNote  : 2013/03/08 cheq</br>
        /// <br>管理番号    : 10900690-00 2013/03/26配信分</br>
        /// <br>            : Redmine#34987 帳票redmine#34098の残分の対応</br>
        /// </remarks>
        private void uos_MoneyUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (this.uos_DaySumPrtDiv.Visible)
                {
                    // 金額単位→日計無し印刷
                    this.uos_DaySumPrtDiv.FocusedIndex = (int)this.uos_DaySumPrtDiv.CheckedItem.DataValue;
                    this.uos_DaySumPrtDiv.Focus();
                }
                else
                {
                    // ----- DEL cheq 2013/03/08 for Redmine #34987 ---->>>>>
                    // 金額単位→改頁
                    //this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                    //this.uos_CrMode.Focus();
                    // ----- DEL cheq 2013/03/08 for Redmine #34987 ----<<<<<
                    this.tComboEditor_LineMaSqOfCh.Focus();// ADD cheq 2013/03/08 for Redmine #34987
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                // 金額単位→対象日（終了）
                this.tde_SalesDateEd.Focus();
            }
        }

        /// <summary>
        /// 日計無し印刷でキー押下イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>UpdateNote  : 2013/03/08 cheq</br>
        /// <br>管理番号    : 10900690-00 2013/03/26配信分</br>
        /// <br>            : Redmine#34987 帳票redmine#34098の残分の対応</br>
        /// </remarks>
        private void uos_DaySumPrtDiv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                // ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                // 日計無し印刷→改頁
                //this.uos_CrMode.FocusedIndex = (int)this.uos_CrMode.CheckedItem.DataValue;
                //this.uos_CrMode.Focus();
                // ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<<
                this.tComboEditor_LineMaSqOfCh.Focus();// ADD cheq 2013/03/08 for Redmine #34987
            }
            else if (e.KeyCode == Keys.Left)
            {
                // 日計無し印刷→金額単位
                this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                this.uos_MoneyUnit.Focus();
            }
        }

        /// <summary>
        /// 改頁でキー押下イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012A 朱 猛</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void uos_CrMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                // 出力順あり
                if (this.PrintOder_tComboEditor.Visible)
                {
                    // 改頁→出力順
                    this.PrintOder_tComboEditor.Focus();
                }
                // 出力順なし
                else
                {
                    switch (this._mode)
                    {
                        // 得意先別
                        case (int)SalesDayMonthReport.TotalTypeState.Customer:
                            {
                                // 改頁→得意先（開始）
                                this.tNedit_CustomerCode_St.Focus();
                                break;
                            }
                        // 担当者別
                        case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:
                            {
                                // 改頁→担当者（開始）
                                this.tEdit_SalesEmployeeCode_St.Focus();
                                break;
                            }
                        // 受注者別
                        case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:
                            {
                                // 改頁→受注者（開始）
                                this.tEdit_FrontEmployeeCode_St.Focus();
                                break;
                            }
                        // 発行者別
                        case (int)SalesDayMonthReport.TotalTypeState.SalesInput:
                            {
                                // 改頁→発行者（開始）
                                this.tEdit_SalesInputCode_St.Focus();
                                break;
                            }
                        // 地区別
                        case (int)SalesDayMonthReport.TotalTypeState.Area:
                            {
                                // 改頁→地区（開始）
                                this.tNedit_SalesAreaCode_St.Focus();
                                break;
                            }
                        // 業種別
                        case (int)SalesDayMonthReport.TotalTypeState.BusinessType:
                            {
                                // 改頁→業種（開始）
                                this.tNedit_BusinessTypeCode_St.Focus();
                                break;
                            }
                        // 販売区分別
                        case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:
                            {
                                // 改頁→販売区分（開始）
                                this.tNedit_SalesCode_St.Focus();
                                break;
                            }
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                /* ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                if (this.uos_DaySumPrtDiv.Visible)
                {
                    // 改頁→日計無し印刷
                    this.uos_DaySumPrtDiv.FocusedIndex = (int)this.uos_DaySumPrtDiv.CheckedItem.DataValue;
                    this.uos_DaySumPrtDiv.Focus();
                }
                else
                {
                    // 改頁→金額単位
                    this.uos_MoneyUnit.FocusedIndex = (int)this.uos_MoneyUnit.CheckedItem.DataValue;
                    this.uos_MoneyUnit.Focus();
                }
                ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<<*/
                this.tComboEditor_LineMaSqOfCh.Focus();//ADD cheq 2013/03/08 for Redmine #34987
            }
        }
        // ---ADD 2010/08/12--------------------<<<
        #endregion



	}
}