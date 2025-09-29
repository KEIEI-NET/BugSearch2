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
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Controller.Util; // ADD 2008/12/09

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上仕入対比表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上仕入対比表UIフォームクラス</br>
    /// <br>Programmer : 96186 立花 裕輔</br>
    /// <br>Date       : 2007.09.03</br>
    /// <br>Update Note: 2008.12.09 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12193]</br>
    /// </remarks>
	public partial class DCTOK02150UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 売上仕入対比表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上仕入対比表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.09.03</br>
		/// <br></br>
		/// </remarks>
		public DCTOK02150UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            //this._employeeAcs = new EmployeeAcs(); // DEL 2008/12/09

			//日付取得部品
			this._dateGet = DateGetAcs.GetInstance();

            // ガイドアクセスクラス初期化
            this._supplierAcs = new SupplierAcs(); // ADD 2008/12/09

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl(); // ADD 2008/12/09

            // --- DEL 2008/12/09 -------------------------------->>>>>
            ////自社情報の取得
            //this._companyInfAcs = new CompanyInfAcs();

            //_companyInf = new CompanyInf();
            //int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    //financialYear = this._companyInf.FinancialYear;
            //}
            // --- DEL 2008/12/09 --------------------------------<<<<<
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
		private SalStcCompMonthYearReport _salStcCompMonthYearReport;

		// ガイド系アクセスクラス
        // --- DEL 2008/12/09 -------------------------------->>>>>
        //EmployeeAcs _employeeAcs;
        //private CompanyInfAcs _companyInfAcs;
        //private CompanyInf _companyInf;
        // --- DEL 2008/12/09 --------------------------------<<<<<

		//日付取得部品
		private DateGetAcs _dateGet;

        // 仕入先ガイド
        private SupplierAcs _supplierAcs; // ADD 2008/12/09

        // --- ADD 2008/12/09 -------------------------------->>>>>
        /// <summary>金額単位ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uos_MoneyUnitRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uos_CrModeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// 金額単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>金卓単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper Uos_MoneyUnitRadioKeyPressHelper
        {
            get { return _uos_MoneyUnitRadioKeyPressHelper; }
        }

        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper Uos_CrModeRadioKeyPressHelper
        {
            get { return _uos_CrModeRadioKeyPressHelper; }
        }
        // --- ADD 2008/12/09 --------------------------------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID = "DCTOK02150UA";
		// プログラムID
		private const string ct_PGID = "DCTOK02150U";
		//// 帳票名称
		private const string PDF_PRINT_NAME = "売上仕入対比表";
		private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
		private const string PDF_PRINT_KEY = "461a402f-20c6-4b5e-817f-790237550131";
		private string _printKey = PDF_PRINT_KEY;
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件

		//エラー条件メッセージ
		const string ct_InputError = "の入力が不正です";
		const string ct_NoInput = "を入力して下さい";
		const string ct_RangeError = "の範囲指定に誤りがあります";
		//const string ct_RangeOverError = "は期首月より１２ヶ月の範囲内で入力して下さい";
		const string ct_RangeOverError = "は同一年度内で入力して下さい";
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
			printInfo.PrintPaperSetCd	= (int)this._salStcCompMonthYearReport.StockMoveFormalDiv;
#endif
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._salStcCompMonthYearReport;
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		public void Show( object parameter )
		{
			this._salStcCompMonthYearReport = new SalStcCompMonthYearReport();

			// 引数型チェック
			int result = 0;
			if (Int32.TryParse(parameter.ToString(), out result) == false)
			{
				//TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
				//return;
			}
			else
			{
				// 引数値チェック
				switch (Int32.Parse(parameter.ToString()))
				{
					//0:営業所別 1:担当者別 2:仕入先別 3:担当別仕入先別
					case 0:
					case 1:
					case 2:
					case 3:
						this._mode = Int32.Parse(parameter.ToString());
						break;
					//default:
						//TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
						//return;
				}
			}

#if False
			// 抽出条件に起動パラメータをセット
			if ( parameter.ToString().CompareTo( "1" ) == 0 )
			{
				this._salStcCompMonthYearReport.StockMoveFormalDiv = SalStcCompMonthYearReport.StockMoveFormalDivState.StockMove;
				this._printKey = "461a402f-20c6-4b5e-817f-790237550131";
			}
			else if ( parameter.ToString().CompareTo( "2" ) == 0 )
			{
				this._salStcCompMonthYearReport.StockMoveFormalDiv = SalStcCompMonthYearReport.StockMoveFormalDivState.WareHouseMove;
				this._printKey = "edded41e-2702-4de3-95b7-3518c5fae7b1";
			}
			else
				TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK );

			this._printName = this._salStcCompMonthYearReport.StockMoveFormalDivName;
#endif
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

#if False			
			// 倉庫ガイドEnabled設定
			// 拠点リストの要素が1つだけで1番目の要素が全社ではないときにTrueになる。
			if ( ( this._selectedSectionList.Count == 1 ) && ( !this._selectedSectionList.ContainsKey( "0" ) ) )
			{
				ExtractWareHouseGuidSetProc( 
					this.ub_St_MainBfAfEnterWarehGuid, this.ub_Ed_MainBfAfEnterWarehGuid, 
					string.Empty, string.Empty );

				// 倉庫移動の時には絞込み倉庫ガイド(ボタンは絞込み拠点)のEnabledも操作する
				if ( this._salStcCompMonthYearReport.StockMoveFormalDiv == SalStcCompMonthYearReport.StockMoveFormalDivState.WareHouseMove )
				{
					ExtractWareHouseGuidSetProc( 
						this.ub_St_ExtractSectionGuid, this.ub_Ed_ExtractSectionGuid, 
						string.Empty, string.Empty );
				}
			}
			else
			{
				ExtractWareHouseGuidSetProc( 
					this.ub_St_MainBfAfEnterWarehGuid, this.ub_Ed_MainBfAfEnterWarehGuid, 
					"0", string.Empty );

				// 倉庫移動の時には絞込み倉庫ガイド(ボタンは絞込み拠点)のEnabledも操作する
				if ( this._salStcCompMonthYearReport.StockMoveFormalDiv == SalStcCompMonthYearReport.StockMoveFormalDivState.WareHouseMove )
				{
					ExtractWareHouseGuidSetProc( 
						this.ub_St_ExtractSectionGuid, this.ub_Ed_ExtractSectionGuid, 
						"0", string.Empty );
				}
			}
#endif
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
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
				// 売上日
                /* ---DEL 2009/03/05 不具合対応[12193] -------------------------------->>>>>
                // --- DEL 2008/12/09 -------------------------------->>>>>
                //int year = 0;
                //int addyears = 0;
                //DateTime stDate;
                //DateTime edDate;
                //_dateGet.GetYearFromMonth(DateTime.Now, out year, out addyears, out stDate, out edDate);

                //DateTime staratDate;
                //DateTime endDate;
                //this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastMonths, 1, out staratDate, out endDate);

                //this.tde_SalesDateSt.SetDateTime(stDate);
                //this.tde_SalesDateEd.SetDateTime(endDate);
                // --- DEL 2008/12/09 -------------------------------->>>>>
                // --- ADD 2008/12/09 -------------------------------->>>>>
                // 処理年月を取得
                DateTime yearMonth;
                this._dateGet.GetThisYearMonth(out yearMonth);

                this.tde_SalesDateSt.SetDateTime(yearMonth);
                this.tde_SalesDateEd.SetDateTime(yearMonth);
                // --- ADD 2008/12/09 --------------------------------<<<<<
                   ---DEL 2009/03/05 不具合対応[12193] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12193] -------------------------------->>>>>
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                if (currentTotalMonth != DateTime.MinValue)
                {
                    // 売上今回月次更新日を設定
                    this.tde_SalesDateSt.SetDateTime(currentTotalMonth);
                    this.tde_SalesDateEd.SetDateTime(currentTotalMonth);
                }
                else
                {
                    // 当月を設定
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.tde_SalesDateSt.SetDateTime(nowYearMonth);
                    this.tde_SalesDateEd.SetDateTime(nowYearMonth);
                }
                // ---ADD 2009/03/05 不具合対応[12193] --------------------------------<<<<<

				// 得意先
				this.tNedit_SupplierCd_St.Clear();
				this.tNedit_SupplierCd_Ed.Clear();

				//帳票種別
				this.tComboEditor_PrintType.Value = 0;

				//金額単位
                //this.tComboEditor_MoneyUnit.Value = 0; // DEL 2008/12/09
                this.uos_MoneyUnit.CheckedIndex = 0; // ADD 2008/12/09

				// 改頁
                //uos_CrMode.CheckedIndex = 1;// DEL 2008/12/09
                uos_CrMode.CheckedIndex = 0;// ADD 2008/12/09

				// ボタン設定
				this.SetIconImage(this.uButton_SupplierCdStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.uButton_SupplierCdEdGuid, Size16_Index.STAR1);

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput(); // ADD 2008/12/09

				// 初期フォーカスセット
				this.tde_SalesDateSt.Focus();
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
			cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, true);
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

			// 対象日付
			// 入力日付（開始～終了）
			if (CallCheckDateRange(out cdrResult, ref tde_SalesDateSt, ref tde_SalesDateEd) == false)
			{
				switch (cdrResult)
				{
					case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
						{
							errMessage = string.Format("開始対象年月{0}", ct_NoInput);
							errComponent = this.tde_SalesDateSt;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
						{
                            errMessage = string.Format("開始対象年月{0}", ct_InputError);
							errComponent = this.tde_SalesDateSt;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
						{
                            errMessage = string.Format("終了対象年月{0}", ct_NoInput);
							errComponent = this.tde_SalesDateEd;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
						{
                            errMessage = string.Format("終了対象年月{0}", ct_InputError);
							errComponent = this.tde_SalesDateEd;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
						{
                            errMessage = string.Format("対象年月{0}", ct_RangeError);
							errComponent = this.tde_SalesDateSt;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
					case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
						{
                            errMessage = string.Format("対象年月{0}", ct_RangeOverError);
							errComponent = this.tde_SalesDateSt;
						}
						break;
				}
				status = false;
			}
			// 仕入先コード
			else if((this.tNedit_SupplierCd_St.Text.Trim() != "")
				&& (this.tNedit_SupplierCd_Ed.Text.Trim() != "")
				&& (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
			{
				errMessage = string.Format("仕入先コード{0}", ct_RangeError);
				errComponent = this.tNedit_SupplierCd_St;
				status = false;
			}
			return status;
		}
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
#if False
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
#endif
			// システムサポートチェック
			if( yy < 1900 )
			{
				status = false;
			}
			// 年月日別入力チェック
			else if( ( yy == 0 ) || ( mm <= 0 ) || (mm > 12))
			{
				status = false;
			}
#if False
			// 単純日付妥当性チェック
			else if( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
			{
				status = false;
			}
#endif

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
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
#if false
				//終了日付の算出
				int eYY = tde_SalesDateEd.GetDateYear();
				int eMM = tde_SalesDateEd.GetDateMonth();
				int eDD = this._companyInf.CompanyTotalDay;
				DateTime eDate = new DateTime(eYY, eMM, eDD);

				//期首日付の算出
				int bYY = tde_SalesDateEd.GetDateYear();
				int bMM = this._companyInf.CompanyBiginMonth;
				int bDD = this._companyInf.CompanyTotalDay;
				DateTime bDate = new DateTime(bYY, bMM, bDD);
				bDate = bDate.AddDays(1);

				if (bDate >= eDate)
				{
					bDate = bDate.AddYears(-1);
				}
				bDD = bDate.Day;

				//開始日付の算出
				int sYY = tde_SalesDateSt.GetDateYear();
				int sMM = tde_SalesDateSt.GetDateMonth();
				DateTime sDate = new DateTime(sYY, sMM, bDD);
#endif				

				// 企業コード
				this._salStcCompMonthYearReport.EnterpriseCode = this._enterpriseCode;
				
				// 選択拠点
				//this._salStcCompMonthYearReport.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

				// 拠点オプションありのとき
				if (IsOptSection)
				{
					ArrayList secList = new ArrayList();
					// 全社選択かどうか
					if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
					{
						//extraInfo.SectionCd = new string[1];
						//extraInfo.SectionCd[0] = "0";
                        //_salStcCompMonthYearReport.SectionCodes = new string[0]; // DEL 2008/12/09
                        _salStcCompMonthYearReport.SectionCodes = null; // ADD 2008/12/09
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
						_salStcCompMonthYearReport.SectionCodes = (string[])secList.ToArray(typeof(string));
					}
				}
				// 拠点オプションなしの時
				else
				{
                    //_salStcCompMonthYearReport.SectionCodes = new string[0]; // DEL 2008/12/09
                    _salStcCompMonthYearReport.SectionCodes = null; // ADD 2008/12/09
				}

				//売上日付
                // --- DEL 2008/12/09 -------------------------------->>>>>
                ////this._salStcCompMonthYearReport.SalesDatePrnSt = this.tde_SalesDateSt.GetDateTime();
                ////this._salStcCompMonthYearReport.SalesDatePrnEd = this.tde_SalesDateEd.GetDateTime();

                //DateTime st, ed;

                //_dateGet.GetDaysFromMonth(this.tde_SalesDateSt.GetDateTime(),out st, out ed);
                //this._salStcCompMonthYearReport.SalesDateSt = st;

                //_dateGet.GetDaysFromMonth(this.tde_SalesDateEd.GetDateTime(), out st, out ed);
                //this._salStcCompMonthYearReport.SalesDateEd = ed;


                //売上累計日付
                //this._salStcCompMonthYearReport.MonthReportDateSt = bDate;
                //this._salStcCompMonthYearReport.MonthReportDateEd = eDate;

                //int year = 0;
                //int addyears = 0;
                //DateTime startDate;
                //DateTime endDate;

                //_dateGet.GetYearFromMonth(this._salStcCompMonthYearReport.SalesDateSt, out year, out addyears, out startDate, out endDate);

                //DateTime GetDaysFromMonthSt, GetDaysFromMonthEd;
                //_dateGet.GetDaysFromMonth(startDate, out GetDaysFromMonthSt, out GetDaysFromMonthEd);

                //this._salStcCompMonthYearReport.MonthReportDateSt = GetDaysFromMonthSt;
                //this._salStcCompMonthYearReport.MonthReportDateEd = this._salStcCompMonthYearReport.SalesDateEd;
                // --- DEL 2008/12/09 --------------------------------<<<<<
                // --- ADD 2008/12/17 -------------------------------->>>>>
                this._salStcCompMonthYearReport.SalesDateSt = this.tde_SalesDateSt.GetLongDate() / 100;
                this._salStcCompMonthYearReport.SalesDateEd = this.tde_SalesDateEd.GetLongDate() / 100;

                // 対象年度取得
                int year;
                int addYearFromThis;
                DateTime startYearDate;
                DateTime endYearDate;
                this._dateGet.GetYearFromMonth(this.tde_SalesDateSt.GetDateTime(), out year, out addYearFromThis, out startYearDate, out endYearDate);

                this._salStcCompMonthYearReport.MonthReportDateSt = startYearDate.Year * 100 + startYearDate.Month;
                this._salStcCompMonthYearReport.MonthReportDateEd = this.tde_SalesDateEd.GetLongDate() / 100;
                // --- ADD 2008/12/17 --------------------------------<<<<<

				//得意先コード
				this._salStcCompMonthYearReport.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
				this._salStcCompMonthYearReport.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();

				//帳票種別
				this._salStcCompMonthYearReport.PrintType = Convert.ToInt32(this.tComboEditor_PrintType.SelectedItem.DataValue);

                //金額単位
                //this._salStcCompMonthYearReport.MoneyUnit = Convert.ToInt32(this.tComboEditor_MoneyUnit.SelectedItem.DataValue); // DEL 2008/12/09
                this._salStcCompMonthYearReport.MoneyUnit = Convert.ToInt32(this.uos_MoneyUnit.CheckedItem.DataValue); // ADD 2008/12/09

				//改頁
                //this._salStcCompMonthYearReport.CrMode = this.uos_CrMode.CheckedIndex; // DEL 2008/12/09
                this._salStcCompMonthYearReport.CrMode = (int)this.uos_CrMode.CheckedItem.DataValue; // ADD 2008/12/09
			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
		#endregion
		#endregion ◆ 印刷前処理

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            //saveCtrAry.Add(this.tde_SalesDateSt);             //DEL 2009/03/05 不具合対応[12193]
            //saveCtrAry.Add(this.tde_SalesDateEd);             //DEL 2009/03/05 不具合対応[12193]
            saveCtrAry.Add(this.uos_MoneyUnit);
            saveCtrAry.Add(this.uos_CrMode);
            saveCtrAry.Add(this.tComboEditor_PrintType);
            saveCtrAry.Add(this.tNedit_SupplierCd_St);
            saveCtrAry.Add(this.tNedit_SupplierCd_Ed);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

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
		#region ◆ MAUKK02010UA
		#region ◎ MAUKK02010UA_Load Event
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
		private void MAUKK02010UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;

			// コントロール初期化
			int status = this.InitializeScreen( out errMsg );
			if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

			ParentToolbarSettingEvent( this );						// ツールバーボタン設定イベント起動

            // --- ADD 2008/12/09 -------------------------------->>>>>
            Uos_MoneyUnitRadioKeyPressHelper.ControlList.Add(this.uos_MoneyUnit);
            Uos_MoneyUnitRadioKeyPressHelper.StartSpaceKeyControl();

            Uos_CrModeRadioKeyPressHelper.ControlList.Add(this.uos_CrMode);
            Uos_CrModeRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2008/12/09 --------------------------------<<<<<
		}
		#endregion
		#endregion ◆ MAUKK02010UA

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
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
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
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}

		}
		#endregion
		#endregion ◆ ueb_MainExplorerBar

        // --- ADD 2008/12/09 -------------------------------->>>>>
        /// <summary>
        /// 発注先ガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierCdStGuid_Click(object sender, EventArgs e)
        {
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tNedit_SupplierCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                this.tde_SalesDateSt.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // タブ、Enterキーでのガイド遷移不可
            if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                if (e.NextCtrl == uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                if (e.NextCtrl == uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
                else if (e.NextCtrl == uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tde_SalesDateSt;
                }
            }
            else if (e.PrevCtrl == this.tde_SalesDateSt)
            {
                if (e.NextCtrl == uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
            }
        }
        // --- ADD 2008/12/09 --------------------------------<<<<<

		#endregion ■ Control Event

        ///// <summary>
        ///// 仕入先コード(開始)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void ub_St_CustomerCodeGuid_Click(object sender, EventArgs e)
        //{
        //    SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
        //    customerSearchForm.ShowDialog(this);
        //}

        ///// <summary>
        ///// 仕入先コード(終了)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void ub_Ed_CustomerCodeGuid_Click(object sender, EventArgs e)
        //{
        //    SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
        //    customerSearchForm.ShowDialog(this);
        //}

        ///// <summary>
        ///// 仕入先(開始)選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 取得した仕入先コード(開始)を画面に表示する
        //        this.tne_CustomerCodeSt.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した仕入先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);
        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "得意先情報の取得に失敗しました。",
        //            status,
        //            MessageBoxButtons.OK);
        //        return;
        //    }
        //}

        ///// <summary>
        ///// 仕入先(終了)選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 取得した仕入先コード(開始)を画面に表示する
        //        this.tne_CustomerCodeEd.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した仕入先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);
        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "仕入先情報の取得に失敗しました。",
        //            status,
        //            MessageBoxButtons.OK);
        //        return;
        //    }
        //}

        
	}
}