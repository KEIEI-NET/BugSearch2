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
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/16 不具合対応[6350]
// --- ADD 2012/10/03 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/10/03 ----------<<<<<
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 支払確認表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払確認表UIフォームクラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br>UpdateNote : 2008/08/05 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS対応</br>
    /// <br>Update Note: 2009/03/30 30452 上野 俊治</br>
    /// <br>            ・障害対応11467</br>
    /// <br>Update Note: 2009/04/03 30452 上野 俊治</br>
    /// <br>            ・障害対応13090</br>
    /// <br>Update Note: 2012/10/03 FSI今野 利裕</br>
    /// <br>            ・仕入先総括対応</br>
    /// <br>Update Note: 2014/09/15 zhangll</br>
    /// <br>            ・㈱陸整自動車用品 罫線印字区分、改頁区分の追加</br>
    /// </remarks>
	public partial class DCKAK02521UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 支払確認表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払確認表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// <br></br>
		/// </remarks>
		public DCKAK02521UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

            // --- ADD 2008/08/05 -------------------------------->>>>>
            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginWorker = LoginInfoAcquisition.Employee.Clone();
                this._ownSectionCode = this._loginWorker.BelongSectionCode;
            }
            // --- ADD 2008/08/05 --------------------------------<<<<< 

            // --- ADD 2012/10/03 ---------->>>>>
            #region ●オプション情報
            this.CacheOptionInfo();
            #endregion
            // --- ADD 2012/10/03 ----------<<<<<

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

			// 支払確認表アクセスクラス
            this._paymentMainAcs = new PaymentMainAcs();

			// 初期化中フラグ
			//this._isFirstSetting		= true;  // DEL 2008/08/05

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // 支払設定マスタ
            _paymentSetAcs = new PaymentSetAcs(); // ADD 2009/03/30

            // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 ----->>>>>
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tce_LineMaSqOfChDiv);        // 罫線印字
            ctrlList.Add(this.tComboEditor_NewPageType);   // 改頁
            uiMemInput1.TargetControls = ctrlList;
            // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 -----<<<<<

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
		// 支払確認表アクセスクラス
        private PaymentMainAcs _paymentMainAcs;
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // --- ADD 2008/08/05 -------------------------------->>>>>
        private static SupplierAcs _supplierAcs;

        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";
        // --- ADD 2008/08/05 --------------------------------<<<<< 

        // 初期化中フラグ
		//private bool _isFirstSetting;  // DEL 2008/08/05

		// 得意先ガイド用
		private string _customerTag = "";

		// 担当者ガイド
		//private EmployeeAcs _employeeAcs;  // DEL 2008/08/05

        // 日付取得部品
        private DateGetAcs _dateGet;

        // 支払設定マスタ
        private PaymentSetAcs _paymentSetAcs; // ADD 2009/03/30

		// 金種辞書
		/// <summary> 金種辞書(Key:CheckedListのindex, Value:MoneyKindクラス) </summary>
		private Dictionary<int, MoneyKind> _moneyKindDic = new Dictionary<int,MoneyKind>();

        // ADD 2008/10/16 不具合対応[6350]---------->>>>>
        /// <summary>範囲指定ガイドのフォーカス制御オブジェクトのリスト</summary>
        private readonly IList<GeneralRangeGuideUIController> _rangeGuideControllerList = new List<GeneralRangeGuideUIController>();
        /// <summary>
        /// 範囲指定ガイドのフォーカス制御オブジェクトのリストを取得します。
        /// </summary>
        /// <value>範囲指定ガイドのフォーカス制御オブジェクトのリスト</value>
        private IList<GeneralRangeGuideUIController> RangeGuideControllerList
        {
            get { return _rangeGuideControllerList; }
        }
        // ADD 2008/10/16 不具合対応[6350]----------<<<<<

        // --- ADD 2012/10/03 ---------->>>>>
        // 仕入先総括のオプションコード利用可否設定用フラグ
        // true → 仕入先総括使用する。 false → 仕入先総括使用しない。
        private bool _optSuppEnable = false;
        // --- ADD 2012/10/03 ----------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID			= "DCKAK02521UA";
		// プログラムID
		private const string ct_PGID			= "DCKAK02521U";
		// 帳票名称
        private const string ct_PrintName		= "支払確認表";
        // 帳票キー	
        private const string ct_PrintKey        = "86aa7f12-55e0-4988-8585-1645e2ffbb5a";
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintOderGroup			= "PrintOderGroup";			// ソート順
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
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
            PaymentMainCndtn extrInfo = new PaymentMainCndtn();

			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen( extrInfo );

			if( status != 0 )
			{
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "抽出条件の設定に失敗しました", 0);

				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= extrInfo;
			printDialog.PrintInfo		= printInfo;

            // --- ADD 2012/10/03 ---------------------------->>>>>
            // 出力順が「支払先-拠点」の場合に、起動パラメータを変更する
            if (this._optSuppEnable && extrInfo.SortOrderDiv == PaymentMainCndtn.SortOrderDivState.SupplSec)
            {
                printInfo.PrintPaperSetCd = 1;
            }
            // --- ADD 2012/10/03 ----------------------------<<<<<
			
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // --- ADD 2008/08/08 -------------------------------->>>>>
                // 支払日
                this.tde_St_AddUpADate.SetDateTime(TDateTime.GetSFDateNow());
                this.tde_Ed_AddUpADate.SetDateTime(TDateTime.GetSFDateNow());
                // 入力日
                this.tde_St_InputDate.Clear();
                this.tde_Ed_InputDate.Clear();
                // --- ADD 2008/08/08 --------------------------------<<<<<

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //// 支払入力日
                //this.tde_St_InputDate.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_Ed_InputDate.SetDateTime(TDateTime.GetSFDateNow());
                //// 支払計上日
                //this.tde_St_AddUpADate.Clear();
                //this.tde_Ed_AddUpADate.Clear();
                //// 小計区分ごと改ページ区分
                //this.uce_ChangePageDiv.Checked = false;
                // --- DEL 2008/08/05 --------------------------------<<<<< 
				// 支払先コード
				this.tNedit_SupplierCd_St.Clear();
				this.tNedit_SupplierCd_Ed.Clear();
                // --- DEL 2008/08/05 -------------------------------->>>>>
                //// 支払先カナ
                //this.te_St_PayeeKana.DataText = "";
                //this.te_Ed_PayeeKana.DataText = "";
                //// 担当者コード
                //this.te_St_EmployeeCode.Clear();
                //this.te_Ed_EmployeeCode.Clear();
                //// 支払番号
                //this.tne_St_PaymentSlipNo.SetInt( 0 );
                //this.tne_Ed_PaymentSlipNo.SetInt( 0 );
                //// 担当者区分
                //this.InitializeEmployeeKindDiv();
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                // --- ADD 2008/08/05 -------------------------------->>>>>
                // 支払番号
                this.tNedit_SupplierSlipNo_St.Clear();
                this.tNedit_SupplierSlipNo_Ed.Clear();
                // --- ADD 2008/08/05 --------------------------------<<<<< 

                // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 ----->>>>>
                //罫線印字区分
                this.tce_LineMaSqOfChDiv.SelectedIndex = 0;
                //改頁
                this.tComboEditor_NewPageType.Value = 0;
                // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 -----<<<<<
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //#region ◎ 小計区分初期化処理
        ///// <summary>
        ///// 小計区分初期化処理
        ///// </summary>
        ///// <param name="selIndex">初期表示インデックス</param>
        ///// <remarks>
        ///// <br>Note		: 小計区分の初期化を行う</br>
        ///// <br>Programmer	: 20081 疋田 勇人</br>
        ///// <br>Date		: 2007.09.10</br>
        ///// </remarks>
        //private void InitializeSumDiv( out int selIndex )
        //{
        //    // 小計区分
        //    this.tce_SumDiv.Items.Clear();
        //    // 日付
        //    this.tce_SumDiv.Items.Add(PaymentMainCndtn.SumDivState.Day, PaymentMainCndtn.ct_SumDiv_Day);
        //    // 支払先
        //    this.tce_SumDiv.Items.Add(PaymentMainCndtn.SumDivState.Payee, PaymentMainCndtn.ct_SumDiv_Payee);
        //    // 金種
        //    this.tce_SumDiv.Items.Add(PaymentMainCndtn.SumDivState.PaymentKind, PaymentMainCndtn.ct_SumDiv_PaymentKind);
        //    // 支払伝票番号
        //    this.tce_SumDiv.Items.Add(PaymentMainCndtn.SumDivState.PaymentSlipNo, PaymentMainCndtn.ct_SumDiv_PaymentSlipNo);

        //    this.tce_SumDiv.MaxDropDownItems = this.tce_SumDiv.Items.Count;
        //    this.tce_SumDiv.SelectedIndex = -1;
        //    selIndex = 0;

        //}
        //#endregion
        // --- DEL 2008/08/05 --------------------------------<<<<< 

		#region ◎ 出力順初期化処理
		/// <summary>
		/// 出力順初期化処理
		/// </summary>
        /// <remarks>
        /// <br>Note		: 出力順の初期化を行う</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		private void InitializeSortOrderDiv()
		{
			// 出力順
			this.tce_SortOrderDiv.Items.Clear();

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //// 支払先コード
            //this.tce_SortOrderDiv.Items.Add(PaymentMainCndtn.SortOrderDivState.PayeeCode, PaymentMainCndtn.ct_SortOrderDiv_PayeeCode);
            //// 支払先カナ
            //this.tce_SortOrderDiv.Items.Add(PaymentMainCndtn.SortOrderDivState.PayeeKana, PaymentMainCndtn.ct_SortOrderDiv_PayeeKana);
            //// 担当者コード
            //this.tce_SortOrderDiv.Items.Add(PaymentMainCndtn.SortOrderDivState.EmployeeCode, PaymentMainCndtn.ct_SortOrderDiv_EmployeeCode);
            // --- DEL 2008/08/05 --------------------------------<<<<< 

            // --- ADD 2008/08/05 -------------------------------->>>>>
            // 支払日順
            this.tce_SortOrderDiv.Items.Add(PaymentMainCndtn.SortOrderDivState.PayeeDate, PaymentMainCndtn.ct_SortOrderDiv_PayeeDate);
            // 入力日順
            this.tce_SortOrderDiv.Items.Add(PaymentMainCndtn.SortOrderDivState.InputDate, PaymentMainCndtn.ct_SortOrderDiv_InputDate);
            // 伝票番号順
            this.tce_SortOrderDiv.Items.Add(PaymentMainCndtn.SortOrderDivState.SlipNo, PaymentMainCndtn.ct_SortOrderDiv_SlipNo);
            // --- ADD 2008/08/05 --------------------------------<<<<<
            // --- ADD 2012/10/03 ---------------------------->>>>>
            if (this._optSuppEnable)
            {
                // 仕入先-拠点順
                this.tce_SortOrderDiv.Items.Add(PaymentMainCndtn.SortOrderDivState.SupplSec, PaymentMainCndtn.ct_SortOrderDiv_SupplSec);
            }
            // --- ADD 2012/10/03 ----------------------------<<<<<

			this.tce_SortOrderDiv.MaxDropDownItems = this.tce_SortOrderDiv.Items.Count;
			this.tce_SortOrderDiv.SelectedIndex = 0;
		}
		#endregion

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //#region ◎ 担当者区分初期化処理
        ///// <summary>
        ///// 担当者区分初期化処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: 担当者区分の初期化を行う</br>
        ///// <br>Programmer	: 20081 疋田 勇人</br>
        ///// <br>Date		: 2007.09.10</br>
        ///// </remarks>
        //private void InitializeEmployeeKindDiv()
        //{
        //    // 担当者区分
        //    this.tce_EmployeeKindDiv.Items.Clear();
        //    // 支払先担当者
        //    this.tce_EmployeeKindDiv.Items.Add(PaymentMainCndtn.EmployeeKindDivState.Payee, PaymentMainCndtn.ct_EmployeeKindDiv_Payee);
        //    // 入力担当者
        //    this.tce_EmployeeKindDiv.Items.Add(PaymentMainCndtn.EmployeeKindDivState.InPayment, PaymentMainCndtn.ct_EmployeeKindDiv_Payment);

        //    this.tce_EmployeeKindDiv.MaxDropDownItems = this.tce_EmployeeKindDiv.Items.Count;
        //    this.tce_EmployeeKindDiv.SelectedIndex = 0;
        //}
        //#endregion
        // --- DEL 2008/08/05 --------------------------------<<<<< 

		#region ◎ 支払金種ツリー初期化処理
		/// <summary>
		/// 支払金種初期化処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払金種の初期化を行う</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
        private int InitializePaymentKind(out string errMsg)
		{
			errMsg = string.Empty;

			SortedList paymentKindList = new SortedList();

			// 金種マスタの取得(金額設定区分は「0:入金」に固定)
            int status = this._paymentMainAcs.SearchMoneyKind(0, out paymentKindList, out errMsg);

            // 支払設定マスタの取得
            PaymentSet paymentSet = this.GetPaymentSet(); // ADD 2009/03/30

			if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                && paymentSet != null) // ADD 2009/03/30
			{
				if ( this._moneyKindDic == null )
					this._moneyKindDic = new Dictionary<int,MoneyKind>();

				this.clb_PaymentKind.Items.Clear();
				// 全てノード追加
                this.clb_PaymentKind.Items.Add(PaymentMainCndtn.ct_All_Name, CheckState.Checked);

				// CheckListに金種を追加
				int listIndex = 1;
                // --- DEL 2009/03/30 -------------------------------->>>>>
                //foreach( DictionaryEntry de in paymentKindList )
                //{
                //    // Listに追加
                //    clb_PaymentKind.Items.Add( ((MoneyKind)de.Value).MoneyKindName.TrimEnd(), CheckState.Unchecked );

                //    // 金種辞書に追加
                //    this._moneyKindDic.Add( listIndex, (MoneyKind)de.Value );
                //    listIndex++;
                //}
                // --- DEL 2009/03/30 --------------------------------<<<<<
                // --- ADD 2009/03/30 -------------------------------->>>>>
                // 支払設定に設定がある＆金種マスタに存在する金種名称を設定
                if (paymentSet.PayStMoneyKindCd1 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd1))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm1.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd1]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd2 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd2))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm2.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd2]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd3 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd3))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm3.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd3]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd4 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd4))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm4.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd4]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd5 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd5))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm5.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd5]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd6 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd6))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm6.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd6]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd7 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd7))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm7.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd7]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd8 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd8))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm8.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd8]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd9 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd9))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm9.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd9]);
                    listIndex++;
                }

                if (paymentSet.PayStMoneyKindCd10 != 0
                    && paymentKindList.Contains(paymentSet.PayStMoneyKindCd10))
                {
                    // Listに追加
                    clb_PaymentKind.Items.Add(paymentSet.PayStMoneyKindNm10.Trim(), CheckState.Unchecked);

                    // 金種辞書に追加
                    this._moneyKindDic.Add(listIndex, (MoneyKind)paymentKindList[paymentSet.PayStMoneyKindCd10]);
                    listIndex++;
                }
                // --- ADD 2009/03/30 --------------------------------<<<<<
			}
			return status;
		}

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// <summary>
        /// 支払設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        private PaymentSet GetPaymentSet()
        {
            PaymentSet paymentSet;

            int status = this._paymentSetAcs.Read(out paymentSet, LoginInfoAcquisition.EnterpriseCode, 0);

            if (status == 0)
            {
                return paymentSet;
            }
            else
            {
                return null;
            }
        }
        // --- ADD 2009/03/30 --------------------------------<<<<<
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

			const string ct_InputError = "の入力が不正です";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            //const string ct_RangeError1 = "の範囲指定に誤りがあります(１ヶ月以内で設定して下さい)";  // DEL 2008/08/05
            const string ct_RangeError1 = "の範囲指定に誤りがあります(３ヶ月以内で設定して下さい)";    // ADD 2008/08/05

            // 支払計上（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false) == false) // DEL 2009/04/03
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false) == false) // ADD 2009/04/03
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            //errMessage = string.Format("支払計上開始日{0}", ct_InputError);  // DEL 2008/08/05
                            errMessage = string.Format("開始支払日{0}", ct_InputError);        // ADD 2008/08/05
                            errComponent = this.tde_St_AddUpADate;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            //errMessage = string.Format("支払計上終了日{0}", ct_InputError);  // DEL 2008/08/05
                            errMessage = string.Format("終了支払日{0}", ct_InputError);        // ADD 2008/08/05
                            errComponent = this.tde_Ed_AddUpADate;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            //errMessage = string.Format("支払計上日{0}", ct_RangeError);  // DEL 2008/08/05
                            errMessage = string.Format("支払日{0}", ct_RangeError);        // ADD 2008/08/05
                            errComponent = this.tde_St_AddUpADate;
                            status = false;
                        }
                        break;
                    // --- ADD 2008/08/05 -------------------------------->>>>>
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            //errMessage = string.Format("支払計上日{0}", ct_RangeError1);  // DEL 2008/08/05
                            errMessage = string.Format("支払日{0}", ct_RangeError1);        // ADD 2008/08/05
                            errComponent = this.tde_Ed_AddUpADate;
                            status = false;
                        }
                        break;
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        //errMessage = string.Format("支払計上開始日{0}", ct_InputError);  // DEL 2008/08/05
                    //        errMessage = string.Format("開始支払日{0}", ct_InputError);        // ADD 2008/08/05
                    //        errComponent = this.tde_St_AddUpADate;
                    //        status = false;
                    //    }
                    //    break;
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        //errMessage = string.Format("支払計上終了日{0}", ct_InputError);  // DEL 2008/08/05
                    //        errMessage = string.Format("終了支払日{0}", ct_InputError);        // ADD 2008/08/05
                    //        errComponent = this.tde_Ed_AddUpADate;
                    //        status = false;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    // --- ADD 2008/08/05 --------------------------------<<<<<

                }
                
            }
            // 支払入力（開始～終了）
            // --- DEL 2008/08/05 -------------------------------->>>>>
            //else if (CallCheckDateRange(out cdrResult, ref tde_St_InputDate, ref tde_Ed_InputDate, false) == false)
            //{
            // --- DEL 2008/08/05 --------------------------------<<<<< 

            // --- ADD 2008/08/05 -------------------------------->>>>>
            if (status == false)
            {
                return status;
            }

            // 値が設定されている場合(両方とも値が設定されていない場合はチェックしない)
            if ((tde_St_InputDate.GetLongDate() != 0) || (tde_Ed_InputDate.GetLongDate() != 0))
            {
            // --- ADD 2008/08/05 --------------------------------<<<<<
                // DEL 2008/10/23 不具合対応[6350]↓
                //if (CallCheckDateRange(out cdrResult, ref tde_St_InputDate, ref tde_Ed_InputDate, false) == false)   // MOD 2008/10/16 不具合対応[6350] CallCheckDateRange()の4パラ目をfalseに修正
                if (CallCheckInputDateRange(out cdrResult, ref tde_St_InputDate, ref tde_Ed_InputDate, false) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        // DEL 2008/10/23 不具合対応[6350] 入力日は開始、終了どちらかの入力があればよい---------->>>>>
                        //{
                        //    //errMessage = string.Format("支払入力開始日{0}", ct_InputError);  // DEL 2008/08/05
                        //    errMessage = string.Format("開始入力日{0}", ct_InputError);        // ADD 2008/08/05
                        //    errComponent = this.tde_St_InputDate;
                        //    status = false;  // ADD 2008/08/14
                        //}
                        // DEL 2008/10/23 不具合対応[6350]----------<<<<<
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                //errMessage = string.Format("支払入力開始日{0}", ct_InputError);  // DEL 2008/08/05
                                errMessage = string.Format("開始入力日{0}", ct_InputError);        // ADD 2008/08/05
                                errComponent = this.tde_St_InputDate;
                                status = false;  // ADD 2008/08/14
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            // DEL 2008/10/23 不具合対応[6350] 入力日は開始、終了どちらかの入力があればよい---------->>>>>
                            //{
                            //    //errMessage = string.Format("支払入力終了日{0}", ct_InputError);  // DEL 2008/08/05
                            //    errMessage = string.Format("終了入力日{0}", ct_InputError);        // ADD 2008/08/05
                            //    errComponent = this.tde_Ed_InputDate;
                            //    status = false;  // ADD 2008/08/14
                            //}
                            // DEL 2008/10/23 不具合対応[6350]----------<<<<<
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                //errMessage = string.Format("支払入力終了日{0}", ct_InputError);  // DEL 2008/08/05
                                errMessage = string.Format("終了入力日{0}", ct_InputError);        // ADD 2008/08/05
                                errComponent = this.tde_Ed_InputDate;
                                status = false;  // ADD 2008/08/14
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                //errMessage = string.Format("支払入力日{0}", ct_RangeError);  // DEL 2008/08/05
                                errMessage = string.Format("入力日{0}", ct_RangeError);        // ADD 2008/08/05
                                errComponent = this.tde_St_InputDate;
                                status = false;  // ADD 2008/08/14
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                // --- DEL 2008/08/05 -------------------------------->>>>>
                                // エラーにしない
                                //errMessage = string.Format("支払入力日{0}", ct_RangeError1);
                                //errComponent = this.tde_St_InputDate;
                                // --- DEL 2008/08/05 --------------------------------<<<<< 
                            }
                            break;
                    }
                }
            }

            if (status == false)
            {
                return status;
            }

			// 支払先コード
			if ((this.tNedit_SupplierCd_St.Text != "") && (this.tNedit_SupplierCd_Ed.Text != ""))
			{
			    if ( this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt() )
			    {
				    errMessage		= string.Format( "支払先{0}", ct_RangeError );
				    errComponent	= this.tNedit_SupplierCd_St;
				    status			= false;
			    }
            }
            // --- DEL 2008/08/05 -------------------------------->>>>>
            //// 支払先カナ
            //else if (
            //    ( this.te_St_PayeeKana.DataText.TrimEnd() != string.Empty ) && 
            //    ( this.te_Ed_PayeeKana.DataText.TrimEnd() != string.Empty )&&
            //    ( this.te_St_PayeeKana.DataText.TrimEnd().CompareTo( this.te_Ed_PayeeKana.DataText.TrimEnd() ) > 0 ) )
            //{
            //    errMessage		= string.Format( "支払先カナ{0}", ct_RangeError );
            //    errComponent	= this.te_St_PayeeKana;
            //    status			= false;
            //}
            //// 担当者コード
            //else if ( 
            //    ( this.te_St_EmployeeCode.DataText.TrimEnd() != string.Empty ) && 
            //    ( this.te_Ed_EmployeeCode.DataText.TrimEnd() != string.Empty )&&
            //    ( this.te_St_EmployeeCode.DataText.TrimEnd().CompareTo( this.te_Ed_EmployeeCode.DataText.TrimEnd() ) > 0 ) )
            //{
            //    errMessage		= string.Format( "担当者コード{0}", ct_RangeError );
            //    errComponent	= this.te_St_EmployeeCode;
            //    status			= false;
            //}
            // --- DEL 2008/08/05 --------------------------------<<<<< 

            if (status == false)
            {
                return status;
            }

			// 支払番号
            if ((this.tNedit_SupplierSlipNo_St.Text != "") && (this.tNedit_SupplierSlipNo_Ed.Text != ""))
            {
                if (this.tNedit_SupplierSlipNo_St.GetInt() > this.tNedit_SupplierSlipNo_Ed.GetInt())
                {
                    errMessage = string.Format("支払番号{0}", ct_RangeError);
                    errComponent = this.tNedit_SupplierSlipNo_St;
                    status = false;
                }
            }

            if (status == false)
            {
                return status;
            }

			// 支払金種
			if ( !CheckInputMoneyKind() )
			{
				errMessage		= "対象金種を選択してください";
				errComponent	= this.clb_PaymentKind;
				status			= false;
			}

			return status;
		}
		#endregion

		#region ◎ 日付入力チェック処理
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <param name="chk"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate, bool chk)
        {
            //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, chk, false);  // DEL 2008/08/05
            //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, chk, false);    // ADD 2008/08/05 // DEL 2009/04/03
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, chk, false);    // ADD 2009/04/03

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        // ADD 2008/10/23 不具合対応[6350]---------->>>>>
        /// <summary>
        /// 入力日付チェック処理呼び出し(範囲チェックなし、未入力OK)
        /// </summary>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="tde_St_AddUpADate">入力日（開始）</param>
        /// <param name="tde_Ed_AddUpADate">入力日（終了）</param>
        /// <param name="chk"></param>
        /// <returns><c>true</c> :OK<br/><c>false</c>:NG</returns>
        private bool CallCheckInputDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit tde_St_AddUpADate,
            ref TDateEdit tde_Ed_AddUpADate,
            bool chk
        )
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // ADD 2008/10/23 不具合対応[6350]----------<<<<<
		#endregion

		#region ◎ 金種入力チェック処理
		/// <summary>
		/// 金種入力チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 金種の入力をチェック。</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>	
		private bool CheckInputMoneyKind()
		{
			// 変数宣言
			bool checkStatus = false;

			if ( clb_PaymentKind.CheckedItems.Count > 0 )
				checkStatus = true;
			
			return checkStatus;
		}
		#endregion

		#region ◎ 抽出条件設定処理(画面→抽出条件)
		/// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(PaymentMainCndtn extraInfo)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 拠点オプション
				extraInfo.IsOptSection = this._isOptSection;
				// 企業コード
				extraInfo.EnterpriseCode = this._enterpriseCode;
				// 選択拠点
                extraInfo.PaymentAddupSecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
				// 支払日
				extraInfo.St_AddUpADate = this.tde_St_AddUpADate.GetDateTime();		// 開始
				extraInfo.Ed_AddupADate = this.tde_Ed_AddUpADate.GetDateTime();		// 終了
                // 入力日
                extraInfo.St_InputDate = this.tde_St_InputDate.GetDateTime();		// 開始
                extraInfo.Ed_InputDate = this.tde_Ed_InputDate.GetDateTime();		// 終了

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //// 小計区分
                //extraInfo.SumDiv = (PaymentMainCndtn.SumDivState)this.tce_SumDiv.SelectedItem.DataValue;
                //// 小計毎改ページ区分
                //extraInfo.IsChangePageDiv = this.uce_ChangePageDiv.Checked;
                // --- DEL 2008/08/05 --------------------------------<<<<< 

				// 出力順
                extraInfo.SortOrderDiv = (PaymentMainCndtn.SortOrderDivState)this.tce_SortOrderDiv.SelectedItem.DataValue;
                // 支払先コード
				extraInfo.St_PayeeCode = this.tNedit_SupplierCd_St.GetInt();				// 開始
				extraInfo.Ed_PayeeCode = this.tNedit_SupplierCd_Ed.GetInt();				// 終了

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //// 支払先カナ
                //extraInfo.St_PayeeKana = this.te_St_PayeeKana.DataText.TrimEnd();		// 開始
                //extraInfo.Ed_PayeeKana = this.te_Ed_PayeeKana.DataText.TrimEnd();		// 終了

                //// 担当者区分
                //extraInfo.EmployeeKindDiv = (PaymentMainCndtn.EmployeeKindDivState)this.tce_EmployeeKindDiv.SelectedItem.DataValue;
                //// 担当者コード
                //extraInfo.St_EmployeeCode = this.te_St_EmployeeCode.DataText.TrimEnd();	// 開始
                //extraInfo.Ed_EmployeeCode = this.te_Ed_EmployeeCode.DataText.TrimEnd();	// 終了
                // --- DEL 2008/08/05 --------------------------------<<<<< 

				// 支払番号
				extraInfo.St_PaymentSlipNo = this.tNedit_SupplierSlipNo_St.GetInt();		// 開始
				extraInfo.Ed_PaymentSlipNo = this.tNedit_SupplierSlipNo_Ed.GetInt();		// 終了
				// 支払金種
                status = GetPaymentKind(extraInfo);

                // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 ----->>>>>
                //罫線印字区分
                extraInfo.LineMaSqOfChDiv = (int)this.tce_LineMaSqOfChDiv.SelectedItem.DataValue;
                //改頁
                extraInfo.NewPageType = (int)this.tComboEditor_NewPageType.Value;
                // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 -----<<<<<
			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
		#endregion

		#region ◎ 支払金種取得処理
		/// <summary>
		/// 支払金種取得処理
		/// </summary>
		/// <param name="extrInfo">支払確認表抽出条件クラス</param>
        /// <remarks>
        /// <br>Note		: 支払金種を取得する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
        private int GetPaymentKind(PaymentMainCndtn extrInfo)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                // HashTableのクリアー
                extrInfo.PaymentKind.Clear();

                // チェックされているアイテムの中に「全て」が存在するか
                if (this.clb_PaymentKind.CheckedItems.Contains(this.clb_PaymentKind.Items[0]))
                {
                    // 全てが選択されているとき
                    extrInfo.PaymentKind.Add(PaymentMainCndtn.ct_All_Code, PaymentMainCndtn.ct_All_Name);
                }
                else
                {
                    // 「全て」がない場合
                    int itemIndex = 0;
                    MoneyKind moneyKind = new MoneyKind();
                    foreach (object checkedItem in this.clb_PaymentKind.CheckedItems)
                    {
                        itemIndex = this.clb_PaymentKind.Items.IndexOf(checkedItem);
                        moneyKind = null;
                        if (this._moneyKindDic.ContainsKey(itemIndex))
                        {
                            moneyKind = this._moneyKindDic[itemIndex];

                            if (moneyKind == null)
                                continue;

                            if (extrInfo.PaymentKind.ContainsKey(moneyKind.MoneyKindCode) == false)
                            {
                                // Key=金種コード, Value=金種名称
                                extrInfo.PaymentKind.Add(moneyKind.MoneyKindCode, moneyKind.MoneyKindName);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
 		}
		#endregion
		#endregion ◆ 印刷前処理

		#region ◆ ControlEventから呼び出し
		#region ◎ Enabled設定関数
		/// <summary>
		/// Enabled設定関数
		/// </summary>
		/// <param name="isSumDiv">小計区分Enabled</param>
		/// <param name="isSort">印字順位Enabled</param>
		/// <param name="isChangePage">小計区分ごと改ページEnabled</param>
		/// <param name="isAllowanceDiv">引当状態Enabled</param>
		private void SetCtrlEnablePrintChange(bool isSumDiv, bool isSort, bool isChangePage, bool isAllowanceDiv)
		{
            tce_SortOrderDiv.Enabled = isSort;				// 印字順位

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //tce_SumDiv.Enabled					= isSumDiv;				// 小計区分
            //uce_ChangePageDiv.Enabled			= isChangePage;			// 小計区分ごと改ページ
            // --- DEL 2008/08/05 --------------------------------<<<<< 
		}
		#endregion
		#endregion ◆

        // --- ADD 2012/10/03 ---------->>>>>
        #region ■オプション情報制御処理

        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/10/03</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●仕入総括機能（個別）オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optSuppEnable = true;
            }
            else
            {
                this._optSuppEnable = false;
            }
            #endregion
        }
        #endregion ■オプション情報制御処理
        // --- ADD 2012/10/03 ----------<<<<<

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
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
		#region ◆ DCKAK02521UA
        #region ◎ DCKAK02521UA_Load Event
        /// <summary>
        /// DCKAK02521UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
        /// 
        private void DCKAK02521UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動(金種などのリードが走るのでTimerで行う。)
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
        }
		#endregion
        #endregion ◆ DCKAK02521UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintOderGroup ) || 
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
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
		#endregion ◆ ueb_MainExplorerBar Event

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //#region ◆ tce_SumDiv
        //#region ◎ ValueChanged Event
        ///// <summary>
        ///// ValueChanged Event
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note		: コントロールの値が変更されたときに発生する。</br>
        ///// <br>Programmer	: 20081 疋田 勇人</br>
        ///// <br>Date		: 2007.09.10</br>
        ///// </remarks>
        //private void tce_SumDiv_ValueChanged ( object sender, EventArgs e )
        //{
        //    if ( this._isFirstSetting ) return;	// 初期化中は実行しない

        //    // Enabledの制御を行う
        //    if ((PaymentMainCndtn.SumDivState)this.tce_SumDiv.SelectedItem.DataValue == PaymentMainCndtn.SumDivState.PaymentSlipNo)
        //    {
        //        // 小計区分で伝票番号が選択されたときはソート順と小計毎改ページのEnabledをfalseにする。
        //        this.tce_SortOrderDiv.Enabled = false;
        //        this.uce_ChangePageDiv.Enabled = false;
        //    }
        //    else
        //    {
        //        this.tce_SortOrderDiv.Enabled = true;
        //        this.uce_ChangePageDiv.Enabled = true;
        //    }
        //}
        //#endregion
        //#endregion ◆ tne_Ed_CustomerCode
        // --- DEL 2008/08/05 --------------------------------<<<<< 

		#region ◆ tne_St_CustomerCode
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		private void tne_St_CustomerCode_Leave ( object sender, EventArgs e )
		{
			// 空白の場合は初期値をセット
			if ( ( (TNedit)sender ).DataText == string.Empty )
			{
				( (TNedit)sender ).SetInt( 0 );
			}
		}
		#endregion
		#endregion ◆ tne_St_CustomerCode

		#region ◆ tne_Ed_CustomerCode
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		private void tne_Ed_CustomerCode_Leave ( object sender, EventArgs e )
		{
			// 空白またはゼロの場合は初期値をセット
			if ( ( ( (TNedit)sender ).DataText == string.Empty ) || ( ( (TNedit)sender ).GetInt() == 0 ) ) 
			{
				( (TNedit)sender ).SetInt( 0 );
			}
		}
		#endregion
		#endregion ◆ tne_Ed_CustomerCode

		//#endregion ◆ ut_DepositKind
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

			//int sumDivSelIndex = 0;  // DEL 2008/08/05

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

				// 小計区分
				//this.InitializeSumDiv( out sumDivSelIndex );  // DEL 2008/08/05

				// 出力順
				this.InitializeSortOrderDiv();

				// 支払金種
				status = this.InitializePaymentKind( out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
					return;
				}

				// ガイドボタンのアイコン設定
				this.SetIconImage( this.ub_St_CustomerCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCdGuid, Size16_Index.STAR1 );

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //this.SetIconImage( this.ub_St_EmployeeCdGuid, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_EmployeeCdGuid, Size16_Index.STAR1 );
                // --- DEL 2008/08/05 --------------------------------<<<<< 

				ParentToolbarSettingEvent( this );	// ツールバー設定イベント

                // ADD 2008/10/16 不具合対応[6350]---------->>>>>
                // 範囲指定ガイドのフォーカス制御オブジェクトの設定
                // 支払先：開始
                RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                    this.tNedit_SupplierCd_St,
                    this.ub_St_CustomerCdGuid,
                    this.tNedit_SupplierCd_Ed
                ));
                // 支払先：終了
                RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                    this.tNedit_SupplierCd_Ed,
                    this.ub_Ed_CustomerCdGuid,
                    this.tNedit_SupplierSlipNo_St
                ));

                foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
                {
                    rangeGuideController.StartControl();
                }
                // ADD 2008/10/16 不具合対応[6350]----------<<<<<
			}
			finally
			{
                uiMemInput1.ReadMemInput();//ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加

                // --- DEL 2008/08/05 -------------------------------->>>>>
				//this._isFirstSetting = false;  

				//this.tce_SumDiv.SelectedIndex = sumDivSelIndex;  

                //this.tde_St_InputDate.Focus();
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                this.tde_St_AddUpADate.Focus();  // ADD 2008/08/05

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
            // --- DEL 2008/08/05 -------------------------------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // --- DEL 2008/08/05 --------------------------------<<<<< 

            // --- ADD 2008/08/05 -------------------------------->>>>>
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
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/16 不具合対応[6350]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/08/05 --------------------------------<<<<< 
		}
		#endregion
		#endregion ◆ ub_St_CustomerCdGuid

        /// <summary>
        /// Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_CustomerCdGuid_Click(object sender, EventArgs e)
        {
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
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/16 不具合対応[6350]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //#region ◆ ub_St_EmployeeCdGuid
        //#region ◎ Click Event
        ///// <summary>
        ///// Click Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_EmployeeCdGuid_Click ( object sender, EventArgs e )
        //{
        //    // インスタンス確認
        //    if ( this._employeeAcs == null )
        //        this._employeeAcs = new EmployeeAcs();

        //    // ガイド起動
        //    Employee employee = new Employee();
        //    this._employeeAcs.ExecuteGuid( LoginInfoAcquisition.EnterpriseCode, true, out employee );

        //    // 項目に展開
        //    if ( ( (Infragistics.Win.Misc.UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 )
        //        this.te_St_EmployeeCode.DataText = employee.EmployeeCode.TrimEnd();
        //    else
        //        this.te_Ed_EmployeeCode.DataText = employee.EmployeeCode.TrimEnd();

        //}
        //#endregion
        //#endregion ◆ ub_St_EmployeeCdGuid
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        #region ◆ clb_PaymentKind
        #region ◎ ItemCheck Event
        /// <summary>
		/// ItemCheck Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note       : チェック状態が変わろうとしている時に発生。イベント後、チェック状態が変更される。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
		/// </remarks>
        private void clb_PaymentKind_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (this.clb_PaymentKind.GetItemChecked(0) == false) // これから選択されようとしているので値は逆
                {
                    // 「全て」が選択された場合、「全て」以外の選択を解除
                    for (int i = 1; i < clb_PaymentKind.Items.Count; i++)
                    {
                        this.clb_PaymentKind.SetItemChecked(i, false);
                    }
                }
                else
                {
                    if (this.clb_PaymentKind.CheckedItems.Count == 0)
                    {
                        // 選択項目が全て解除された場合、「全て」を選択状態にする
                        this.clb_PaymentKind.SetItemChecked(0, true);
                    }
                }
            }
            else
            {
                if (this.clb_PaymentKind.GetItemChecked(e.Index) == false) // これから選択されようとしているので値は逆
                {
                    // 「全て」以外が選択状態にされた場合は、「全て」の選択状態を解除
                    this.clb_PaymentKind.SetItemChecked(0, false);
                }
            }
        }
		#endregion 
        #endregion ◆ clb_PaymentKind

        #region ■ Private Event
        #region ◆ 得意先(支払先)選択時発生イベント

        // --- DEL 2012/10/03 ---------------------------->>>>>
        // CustomerSearchRetの参照元不明のため削除
        ///// <summary>
        ///// 得意先(支払先)選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        ///// <remarks>
        ///// <br>Note        :得意先ガイドで得意先を選択した時に発生します</br>
        ///// <br>Programmer  :20081 疋田 勇人</br>
        ///// <br>Date        :2007.09.10</br>
        ///// </remarks>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    //得意先(仕入先)コードをセット     
        //    if ( this._customerTag.CompareTo("1") == 0 )
        //    {
        //        this.tNedit_SupplierCd_St.SetInt(customerSearchRet.CustomerCode);
        //    }
        //    else
        //    {
        //        this.tNedit_SupplierCd_Ed.SetInt(customerSearchRet.CustomerCode);
        //    }

        //}
        // --- DEL 2012/10/03 ----------------------------<<<<<
    
        #endregion

        // ADD 2008/10/08 不具合対応[5861]---------->>>>>
        /// <summary>
        /// 支払金種チェックボックスリストのEnterイベントのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void clb_PaymentKind_Enter(object sender, EventArgs e)
        {
            // チェックリストボックスフォーカスEnter時、選択
            if (sender is ListBox)
            {
                // 選択状態
                ((ListBox)sender).SetSelected(0, true);
            }
        }

        /// <summary>
        /// 支払金種チェックボックスリストのLeaveイベントのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void clb_PaymentKind_Leave(object sender, EventArgs e)
        {
            // チェックリストボックスフォーカスLeave時、選択解除
            if (sender is ListBox)
            {
                ListBox listBox = (ListBox)sender;

                // 選択状態解除
                if (listBox.SelectedItem != null)
                {
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        // ADD 2008/10/08 不具合対応[5861]----------<<<<<

		#endregion
	}
}