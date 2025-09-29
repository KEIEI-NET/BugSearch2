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
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/02 不具合対応[5722]
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
    /// 仕入日報月報UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入日報月報UIフォームクラス</br>
    /// <br>Programmer : 96186 立花 裕輔</br>
    /// <br>Date       : 2007.09.03</br>
    /// <br>UpdateNote : 2008/08/08 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS対応</br> 
    /// </remarks>
	public partial class DCKOU02101UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 仕入日報月報UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入日報月報UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.09.03</br>
		/// <br></br>
		/// </remarks>
		public DCKOU02101UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginWorker = LoginInfoAcquisition.Employee.Clone();
                this._ownSectionCode = this._loginWorker.BelongSectionCode;
            }

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

			//this._employeeAcs = new EmployeeAcs();  // DEL 2008/08/08

			//日付取得部品
			this._dateGet = DateGetAcs.GetInstance();

			//自社情報の取得
			this._companyInfAcs = new CompanyInfAcs();

			_companyInf = new CompanyInf();
			int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				//financialYear = this._companyInf.FinancialYear;
			}

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
		private StockDayMonthReport _stockDayMonthReport;

		// ガイド系アクセスクラス
		//EmployeeAcs _employeeAcs;  // DEL 2008/08/08

		private CompanyInfAcs _companyInfAcs;
		private CompanyInf _companyInf;

        private static SupplierAcs _supplierAcs;

        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";

		//日付取得部品
		private DateGetAcs _dateGet;

        // ADD 2008/10/02 不具合対応[5722]---------->>>>>
        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _pageTypeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper PageTypeRadioKeyPressHelper
        {
            get { return _pageTypeRadioKeyPressHelper; }
        }
        // ADD 2008/10/22 不具合対応[5722]----------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID			= "DCKOU02101UA";
		// プログラムID
		private const string ct_PGID			= "DCKOU02101U";
		//// 帳票名称
		private const string PDF_PRINT_NAME = "仕入日報月報";
		private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
		private const string PDF_PRINT_KEY = "461a402f-20c6-4b5e-817f-790237550131";
		private string _printKey = PDF_PRINT_KEY;

		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
		private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";

		//エラー条件メッセージ
		const string ct_InputError = "の入力が不正です";
		const string ct_NoInput = "を入力して下さい";
		const string ct_RangeError = "の範囲指定に誤りがあります";
		const string ct_RangeOverError = "は締日より１ヶ月の範囲内で入力して下さい";

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
			printInfo.PrintPaperSetCd	= (int)this._stockDayMonthReport.StockMoveFormalDiv;
#endif
            // 2009.03.19 30413 犬飼 PDFファイル名の修正対応 >>>>>>START
            if (this._mode == 2)
            {
                // 仕入先別
                printInfo.PrintPaperSetCd = this._mode;
            }
            // 2009.03.19 30413 犬飼 PDFファイル名の修正対応 <<<<<<END
            
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._stockDayMonthReport;
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
			this._stockDayMonthReport = new StockDayMonthReport();

			// 引数型チェック
			int result = 0;
			if (Int32.TryParse(parameter.ToString(), out result) == false)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
				return;
			}

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //// 引数値チェック
            //switch (Int32.Parse(parameter.ToString()))
            //{
            //    //0:営業所別 1:担当者別 2:仕入先別 3:担当別仕入先別
            //    case 0:
            //    case 1:
            //    case 2:
            //    case 3:
            //        this._mode = Int32.Parse(parameter.ToString());
            //        break;
            //    default:
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
            //        return;
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            // 引数値チェック
            switch (Int32.Parse(parameter.ToString()))
            {
                //1:拠点別 2:仕入先別
                case 1:
                case 2:
                    this._mode = Int32.Parse(parameter.ToString());
                    break;
                default:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK);
                    return;
            }
            // --- ADD 2008/08/08 --------------------------------<<<<<

#if False
			// 抽出条件に起動パラメータをセット
			if ( parameter.ToString().CompareTo( "1" ) == 0 )
			{
#if False
				this._stockDayMonthReport.StockMoveFormalDiv = StockDayMonthReport.StockMoveFormalDivState.StockMove;
#endif
				this._printKey = "461a402f-20c6-4b5e-817f-790237550131";
			}
			else if ( parameter.ToString().CompareTo( "2" ) == 0 )
			{
#if False
				this._stockDayMonthReport.StockMoveFormalDiv = StockDayMonthReport.StockMoveFormalDivState.WareHouseMove;
#endif
				this._printKey = "edded41e-2702-4de3-95b7-3518c5fae7b1";
			}
			else
				TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK );

#if False
			this._printName = this._stockDayMonthReport.StockMoveFormalDivName;
#endif
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
                    this._selectedSectionList.Add( sectionCode, checkState );
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
				if ( this._stockDayMonthReport.StockMoveFormalDiv == StockDayMonthReport.StockMoveFormalDivState.WareHouseMove )
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
				if ( this._stockDayMonthReport.StockMoveFormalDiv == StockDayMonthReport.StockMoveFormalDivState.WareHouseMove )
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
                // --- ADD 2008/08/08 -------------------------------->>>>>
				// 対象日付
                this.tde_St_StockDate.SetDateTime(TDateTime.GetSFDateNow());
                this.tde_Ed_StockDate.SetDateTime(TDateTime.GetSFDateNow());
                // --- ADD 2008/08/08 --------------------------------<<<<<

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //// 仕入日
                //DateTime staratDate;
                //DateTime endDate;
                //this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

                //this.tde_St_StockDate.SetDateTime(staratDate);
                //this.tde_Ed_StockDate.SetDateTime(endDate);

                //// 改頁
                //if (_mode == 0)
                //{
                //    uos_PageType.Visible = false;
                //    ultraLabel5.Visible = false;
                //    uos_PageType.CheckedIndex = 0;
                //}
                //else
                //{
                //    uos_PageType.CheckedIndex = 1;
                //}

                //// 担当者
                //te_St_StockAgentCode.DataText = string.Empty;
                //te_Ed_StockAgentCode.DataText = string.Empty;
                // --- DEL 2008/08/08 --------------------------------<<<<< 

				// 仕入先
				//tne_St_CustomerCode.SetInt( 0 );
				//tne_Ed_CustomerCode.SetInt( 999999999 );
				tNedit_SupplierCd_St.Clear();
				tNedit_SupplierCd_Ed.Clear();

                // --- DEL 2008/08/08 -------------------------------->>>>>
                ////出力順
                //this.PrintOder_tComboEditor.Value = 0;
                // --- DEL 2008/08/08 --------------------------------<<<<< 

				// ボタン設定
                // --- DEL 2008/08/08 -------------------------------->>>>>
                //this.SetIconImage( this.ub_St_StockAgentCodeGuid, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_StockAgentCodeGuid, Size16_Index.STAR1 );
                // --- DEL 2008/08/08 --------------------------------<<<<< 
				this.SetIconImage( this.ub_St_CustomerCodeGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCodeGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_St_CustomerCodeGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCodeGuid, Size16_Index.STAR1 );
				//this.SetIconImage( this.ub_St_BusinessTypeCodeGuid, Size16_Index.STAR1 );
				//this.SetIconImage( this.ub_Ed_BusinessTypeCodeGuid, Size16_Index.STAR1 );

				// 初期フォーカスセット
				this.tde_St_StockDate.Focus();
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

			// 対象日付（開始～終了）
			if (CallCheckDateRange(out cdrResult, ref tde_St_StockDate, ref tde_Ed_StockDate) == false)
			{
				switch (cdrResult)
				{
					case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
						{
							//errMessage = string.Format("開始仕入日{0}", ct_NoInput);  // DEL 2008/08/08
                            errMessage = string.Format("開始対象日付{0}", ct_NoInput);  // ADD 2008/08/08  
							errComponent = this.tde_St_StockDate;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
						{
                            //errMessage = string.Format("開始仕入日{0}", ct_InputError);  // DEL 2008/08/08
                            errMessage = string.Format("開始対象日付{0}", ct_InputError);  // ADD 2008/08/08 
							errComponent = this.tde_St_StockDate;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
						{
                            //errMessage = string.Format("終了仕入日{0}", ct_NoInput);  // DEL 2008/08/08
                            errMessage = string.Format("終了対象日付{0}", ct_NoInput);  // ADD 2008/08/08 
							errComponent = this.tde_Ed_StockDate;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
						{
                            //errMessage = string.Format("終了仕入日{0}", ct_InputError);  // DEL 2008/08/08
                            errMessage = string.Format("終了対象日付{0}", ct_InputError);  // ADD 2008/08/08 
							errComponent = this.tde_Ed_StockDate;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
						{
                            //errMessage = string.Format("仕入日{0}", ct_RangeError);  // DEL 2008/08/08
                            errMessage = string.Format("対象日付{0}", ct_RangeError);  // ADD 2008/08/08 
							errComponent = this.tde_St_StockDate;
						}
						break;
					case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
					case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
						{
                            //errMessage = string.Format("仕入日{0}", ct_RangeOverError);  // DEL 2008/08/08
                            errMessage = string.Format("対象日付{0}", ct_RangeOverError);  // ADD 2008/08/08 
							errComponent = this.tde_St_StockDate;
						}
						break;
				}
				status = false;
			}
            // --- DEL 2008/08/08 -------------------------------->>>>>
            //// 担当者コード
            //else if (
            //    ( this.te_St_StockAgentCode.DataText.TrimEnd() != string.Empty ) && 
            //    ( this.te_Ed_StockAgentCode.DataText.TrimEnd() != string.Empty )&&
            //    (( this.te_St_StockAgentCode.DataText.TrimEnd().CompareTo( this.te_Ed_StockAgentCode.DataText.TrimEnd() ) > 0 )
            //        || (this.te_Ed_StockAgentCode.DataText.TrimEnd().Length < this.te_St_StockAgentCode.DataText.TrimEnd().Length))) 
            //{
            //    errMessage		= string.Format("担当者コード{0}", ct_RangeError);
            //    errComponent	= this.te_St_StockAgentCode;
            //    status			= false;
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 
			// 仕入先コード
			else if ((tNedit_SupplierCd_St.DataText.Trim() != "") && (tNedit_SupplierCd_Ed.DataText.Trim() != "") && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
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
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			try
			{
				// 拠点オプション
				this._stockDayMonthReport.IsSelectAllSection = this._isOptSection;

				// 企業コード
				this._stockDayMonthReport.EnterpriseCode = this._enterpriseCode;

				// 選択拠点
				//this._stockDayMonthReport.SectionCode = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

				// 拠点オプションありのとき
				if (IsOptSection)
				{
					ArrayList secList = new ArrayList();
					// 全社選択かどうか
					if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
					{
						_stockDayMonthReport.SectionCode = new string[0];
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
						_stockDayMonthReport.SectionCode = (string[])secList.ToArray(typeof(string));
					}
				}
				// 拠点オプションなしの時
				else
				{
					_stockDayMonthReport.SectionCode = new string[0];
				}

				// 仕入日(日計)
				this._stockDayMonthReport.DayStockDateSt = this.tde_St_StockDate.GetDateTime();
                this._stockDayMonthReport.DayStockDateEd = this.tde_Ed_StockDate.GetDateTime();

                DateTime startMonthDate;
                DateTime endMonthDate;
                DateTime yearMonth;
                int year;

                // 仕入日(累計)取得
                //this._dateGet.GetDaysFromMonth(DateTime.Parse(this._stockDayMonthReport.DayStockDateEd.ToString("yyyy/mm/dd")), out startMonthDate, out endMonthDate);
                this._dateGet.GetYearMonth(this.tde_St_StockDate.GetDateTime(), out yearMonth, out year, out startMonthDate, out endMonthDate);

                // 仕入日(累計)
                this._stockDayMonthReport.MonthStockDateSt = startMonthDate;
                this._stockDayMonthReport.MonthStockDateEd = this._stockDayMonthReport.DayStockDateEd;

                // --- DEL 2008/08/08 -------------------------------->>>>>
                ////担当者コード
                //this._stockDayMonthReport.StockAgentCodeSt = this.te_St_StockAgentCode.DataText;
                //this._stockDayMonthReport.StockAgentCodeEd = this.te_Ed_StockAgentCode.DataText;

                ////仕入先コード
                //this._stockDayMonthReport.CustomerCodeSt = this.tne_St_CustomerCode.GetInt();
                //this._stockDayMonthReport.CustomerCodeEd = this.tne_Ed_CustomerCode.GetInt();
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                // 仕入先コード
                this._stockDayMonthReport.SupplierCodeSt = this.tNedit_SupplierCd_St.GetInt();

                if (this.tNedit_SupplierCd_Ed.Text != "")
                {
                    this._stockDayMonthReport.SupplierCodeEd = this.tNedit_SupplierCd_Ed.GetInt();
                }
                else
                {
                    this._stockDayMonthReport.SupplierCodeEd = 999999999;
                }
                // --- ADD 2008/08/08 --------------------------------<<<<< 

				//出力順
				//this._stockDayMonthReport.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);  // DEL 2008/08/08

				//帳票種別
				this._stockDayMonthReport.PrintType = _mode; 

				//改頁
				this._stockDayMonthReport.PageType = this.uos_PageType.CheckedIndex;

				//自社締日
				this._stockDayMonthReport.TotalDay = this._companyInf.CompanyTotalDay;
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

            // ADD 2008/10/02 不具合対応[5722]---------->>>>>
            PageTypeRadioKeyPressHelper.ControlList.Add(this.uos_PageType);
            PageTypeRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2008/10/22 不具合対応[5722]----------<<<<<
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
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
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
				( e.Group.Key == ct_ExBarGroupNm_PrintOderGroup ) ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}

		}
		#endregion
		#endregion ◆ ueb_MainExplorerBar

		#endregion ■ Control Event

		/// <summary>
		/// 仕入先コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
		private void ub_St_CustomerCodeGuid_Click(object sender, EventArgs e)
		{
            // --- DEL 2008/08/08 -------------------------------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // インスタンス生成
                    _supplierAcs = new SupplierAcs();
                }

                // ガイド起動
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // 項目に展開
                if (status == 0)
                {
                    this.tNedit_SupplierCd_St.DataText = supplier.SupplierCd.ToString();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/08/08 --------------------------------<<<<< 
		}

		/// <summary>
		/// 仕入先コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void ub_Ed_CustomerCodeGuid_Click(object sender, EventArgs e)
		{
            // --- DEL 2008/08/08 -------------------------------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // インスタンス生成
                    _supplierAcs = new SupplierAcs();
                }

                // ガイド起動
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // 項目に展開
                if (status == 0)
                {
                    this.tNedit_SupplierCd_Ed.DataText = supplier.SupplierCd.ToString();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/08/08 --------------------------------<<<<< 
		}

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// <summary>
        ///// 担当者コード(開始)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void ub_St_StockAgentCodeGuid_Click(object sender, EventArgs e)
        //{
        //    int status = -1;

        //    // ガイド起動
        //    Employee employee = new Employee();
        //    status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

        //    // 項目に展開
        //    if (status == 0)
        //    {
        //        this.te_St_StockAgentCode.DataText = employee.EmployeeCode.TrimEnd();
        //    }

        //}

        ///// <summary>
        ///// 担当者コード(終了)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void ub_Ed_StockAgentCodeGuid_Click(object sender, EventArgs e)
        //{
        //    int status = -1;

        //    // ガイド起動
        //    Employee employee = new Employee();
        //    status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

        //    // 項目に展開
        //    if (status == 0)
        //    {
        //        this.te_Ed_StockAgentCode.DataText = employee.EmployeeCode.TrimEnd();
        //    }

        //}
        // --- DEL 2008/08/08 --------------------------------<<<<< 

		/// <summary>
		/// 仕入先(開始)選択時発生イベント
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
				this.tNedit_SupplierCd_St.SetInt(customerInfo.CustomerCode);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					//"選択した得意先は既に削除されています。",  // DEL 2008/08/08
                    "選択した仕入先は既に削除されています。",    // ADD 2008/08/08
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
                    //"得意先情報の取得に失敗しました。",  // DEL 2008/08/08
                    "仕入先情報の取得に失敗しました。",    // ADD 2008/08/08
					status,
					MessageBoxButtons.OK);

				return;
			}
		}

		/// <summary>
		/// 仕入先(終了)選択時発生イベント
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
				this.tNedit_SupplierCd_Ed.SetInt(customerInfo.CustomerCode);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					//"選択した得意先は既に削除されています。",  // DEL 2008/08/08
                    "選択した仕入先は既に削除されています。",    // ADD 2008/08/08
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
                    //"得意先情報の取得に失敗しました。",  // DEL 2008/08/08
                    "仕入先情報の取得に失敗しました。",    // ADD 2008/08/08
					status,
					MessageBoxButtons.OK);

				return;
			}
		}


	}
}