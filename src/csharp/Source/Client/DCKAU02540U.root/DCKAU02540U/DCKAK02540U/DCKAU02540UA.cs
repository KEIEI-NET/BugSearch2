//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売掛残高一覧表
// プログラム概要   ：売掛残高一覧表の印刷を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/10/01     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：照田 貴志
// 修正日    2009/03/05     修正内容：不具合対応[12163]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/15     修正内容：Mantis【13528】初期表示の処理月取得処理を修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/01/04     修正内容：Mantis【14764】処理月の初期表示を前回処理月にする
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：李亜博
// 作 成 日  2012/11/14     修正内容：2013/01/16配信分、Redmine#33271
//                                    印字制御の区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 董桂鈺
// 作 成 日  2012/12/25  修正内容 : 2013/01/16配信分、Redmine#33271
//                                  帳票の罫線印字（する・しない）を前回指定したも
//                                  のを記憶させることの設定を追加する
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 作 成 日  2020/02/28  修正内容 : 軽減税率対応
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
// --- ADD 3H 劉星光 2020/02/28---------->>>>>
using Broadleaf.Application.Resources;
using System.Text.RegularExpressions;
using System.IO;
// --- ADD 3H 劉星光 2020/02/28----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売掛残高一覧表 UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高一覧表 UIフォームクラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.10.24</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.10.01</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 2009/03/05 照田 貴志　不具合対応[12163]</br>
    /// <br>Update Note: 2012/11/14 李亜博</br>
    ///	<br>			 Redmine#33271 印字制御の区分の追加</br>
    /// <br>Update Note: 2012/12/25 董桂鈺</br>
    ///	<br>			 Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/02/28</br>
    /// </remarks>
	public partial class DCKAU02540UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 売掛残高一覧表 UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売掛残高一覧表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.24</br>
        /// <br>Update Note: 2012/12/25 董桂鈺</br>
        ///	<br>			 Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/02/28</br>
		/// <br></br>
		/// </remarks>
		public DCKAU02540UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

			// 売掛残高一覧表アクセスクラス
            this._custAccRecMainAcs = new CustAccRecMainAcs();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // ログイン担当者
            this._loginEmployee = LoginInfoAcquisition.Employee.Clone();

            //---ADD 董桂鈺 2012/12/25 for Redmine#33271-------------->>>>>
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tComboEditor_LineMaSqOfChDiv);        // 罫線印字
            uiMemInput1.TargetControls = ctrlList;
            //---ADD 董桂鈺 2012/12/25 for Redmine#33271--------------<<<<<

            // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
			// 税別内訳印字区分
            ctrlList.Add(this.tComboEditor_TaxPrintDiv);
            // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<
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
		// 売掛残高一覧表アクセスクラス
        private CustAccRecMainAcs _custAccRecMainAcs;

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
		private const string ct_ClassID			= "DCKAU02540UA";
		// プログラムID
		private const string ct_PGID			= "DCKAU02540U";
		// 帳票名称
        private const string ct_PrintName		= "売掛残高一覧表";
        // 帳票キー	
        private const string ct_PrintKey        = "32dd64d0-337b-40fe-810f-cc6f416e21f9";
		#endregion ◆ Interface member

   		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintOderGroup			= "PrintOderGroup";			// ソート順
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
        private const string ct_ExBarGroupNm_SalesPrintGroup = "SalesPrintGroup";               // 売掛印刷条件

        // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
        // 税率設定ファイル
        private const string ct_PrintXmlFileName = "TaxRate_UserSetting.XML";
        // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<
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
        /// <br>Date		: 2007.10.24</br>
        /// <br>Update Note : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/02/28</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
            // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
            // 税率内訳印字メッセージ追加
            if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_ClassID, "消費税率別の内訳を印字すると、処理が遅くなる可能性があります。\nよろしいですか？", 0, MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return -1;
                }
            }
            // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<

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
            CustAccRecMainCndtn extrInfo = new CustAccRecMainCndtn();

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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date		: 2007.10.24</br>
        /// <br>Update Note : 2012/11/14 李亜博</br>
        ///	<br>			  Redmine#33271 印字制御の区分の追加</br> 
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

            // 2008.10.01 30413 犬飼 処理年月の取得を変更 >>>>>>START
            // 処理年月を取得
            //DateTime yearMonth;
            //this._dateGet.GetThisYearMonth(out yearMonth);

   			try
			{
                //this.AddUpYearMonth_tDateEdit.DateFormat = emDateFormat.df4Y2M;
                //this.AddUpYearMonth_tDateEdit.SetDateTime(yearMonth);

                this.AddUpYearMonth_tDateEdit.DateFormat = emDateFormat.df4Y2M;
                
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                /* ---DEL 2009/03/05 不具合対応[12163] ------------------------------------------------------------------->>>>>
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(this._loginEmployee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out this._baseDate, out currentTotalMonth);
                   ---DEL 2009/03/05 不具合対応[12163] -------------------------------------------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12163] ------------------------------------------------------------------->>>>>
                //totalDayCalculator.InitializeHisMonthly();  // 2010/01/04 Del
                //totalDayCalculator.GetHisTotalDayMonthly(this._loginEmployee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out this._baseDate, out currentTotalMonth);    // DEL 2009/06/16
                // ---ADD 2009/03/05 不具合対応[12163] -------------------------------------------------------------------<<<<<
                // ADD 2009/06/16 ------>>>
                // 全社共通の月次更新日を取得
                //totalDayCalculator.GetHisTotalDayMonthly("", out prevTotalDay, out currentTotalDay, out this._baseDate, out currentTotalMonth); // 2010/01/04 Del
                // ADD 2009/06/16 ------<<<

                // 2010/01/04 Add >>>
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec("", out prevTotalDay, out currentTotalDay, out this._baseDate, out currentTotalMonth);
                // 2010/01/04 Add <<<

                // 2009.02.25 30413 犬飼 今回締処理月に修正 >>>>>>START
                //if (this._baseDate != DateTime.MinValue)
                // 2010/01/04 >>>
                //if (currentTotalMonth != DateTime.MinValue)
                if (this._baseDate != DateTime.MinValue)
                // 2010/01/04 <<<
                {
                    //// 前回締処理月を設定
                    //this.AddUpYearMonth_tDateEdit.SetDateTime(this._baseDate);
                    // 今回締処理月を設定
                    // 2010/01/04 >>>
                    //this.AddUpYearMonth_tDateEdit.SetDateTime(currentTotalMonth);
                    this.AddUpYearMonth_tDateEdit.SetDateTime(this._baseDate);
                    // 2010/01/04 <<<
                }
                // 2009.02.25 30413 犬飼 今回締処理月に修正 <<<<<<END
                else
                {
                    // 現在処理年月を設定
                    //_dateGet.GetThisYearMonth(out this._baseDate);
                    //this.AddUpYearMonth_tDateEdit.SetDateTime(this._baseDate);
                    // 2010/01/04 Del >>>
                    //DateTime nowYearMonth;
                    //_dateGet.GetThisYearMonth(out nowYearMonth);
                    //this.AddUpYearMonth_tDateEdit.SetDateTime(nowYearMonth);
                    // 2010/01/04 Del <<<
                    // 2010/01/04 Add >>>
                    this.AddUpYearMonth_tDateEdit.SetDateTime(DateTime.MinValue);
                    // 2010/01/04 Add <<<
                }
                // 2008.10.01 30413 犬飼 処理年月の取得を変更 <<<<<<END                

                // 2008.10.01 30413 犬飼 改頁、入金区分の追加 >>>>>>START
                // 改頁
                this.tComboEditor_NewPageType.Value = 0;
                // 入金区分
                this.DepositDtl_tComboEditor.Value = 0;
                // 2008.10.01 30413 犬飼 改頁の追加 <<<<<<END                

                // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
                //罫線印字区分
                this.tComboEditor_LineMaSqOfChDiv.Value = 0;
                // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<
                // 得意先コード
				this.tNedit_CustomerCode_St.Clear();
				this.tNedit_CustomerCode_Ed.Clear();
                // 2008.10.01 30413 犬飼 得意先カナ削除 >>>>>>START
                //// 得意先カナ
                //this.CustomerKanaStrat_Edit.DataText = "";
                //this.CustomerKanaEnd_Edit.DataText   = "";
                // 2008.10.01 30413 犬飼 得意先カナ削除 <<<<<<END
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

                // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
                // 税別内訳印字区分
                this.tComboEditor_TaxPrintDiv.SelectedIndex = 1;
                // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
        /// </remarks>
        private void InitializeSortOrderDiv()
        {
            // 出力順
            this.tce_SortOrderDiv.Items.Clear();
            // 得意先順
            this.tce_SortOrderDiv.Items.Add(CustAccRecMainCndtn.SortOrderDivState.CustomerCode, CustAccRecMainCndtn.ct_SortOrderDiv_CustomerCode);
            // 2008.10.01 30413 犬飼 出力順の変更 >>>>>>START
            //// 得意先カナ順
            //this.tce_SortOrderDiv.Items.Add(CustAccRecMainCndtn.SortOrderDivState.CustomerKana, CustAccRecMainCndtn.ct_SortOrderDiv_CustomerKana);
            //// 担当者→得意先コード順
            //this.tce_SortOrderDiv.Items.Add(CustAccRecMainCndtn.SortOrderDivState.EmployeeCustomer, CustAccRecMainCndtn.ct_SortOrderDiv_EmployeeCustomer);
            //// 担当者→得意先カナ順
            //this.tce_SortOrderDiv.Items.Add(CustAccRecMainCndtn.SortOrderDivState.EmployeeCustomerKana, CustAccRecMainCndtn.ct_SortOrderDiv_EmployeeCustomerKana);
            // 担当者順
            this.tce_SortOrderDiv.Items.Add(CustAccRecMainCndtn.SortOrderDivState.EmployeeCode, CustAccRecMainCndtn.ct_SortOrderDiv_Employee);
            // 2008.10.01 30413 犬飼 出力順の変更 <<<<<<END
            // 地区順
            this.tce_SortOrderDiv.Items.Add(CustAccRecMainCndtn.SortOrderDivState.SalesAreaCode, CustAccRecMainCndtn.ct_SortOrderDiv_SalesAreaCode);

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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
        /// </remarks>
        private void InitializeEmployeeKindDiv()
        {
            // 担当者区分
            this.tce_EmployeeKindDiv.Items.Clear();
            // 顧客担当者
            this.tce_EmployeeKindDiv.Items.Add(CustAccRecMainCndtn.EmployeeKindDivState.Customer, CustAccRecMainCndtn.ct_EmployeeKindDiv_Customer);
            // 集金担当
            this.tce_EmployeeKindDiv.Items.Add(CustAccRecMainCndtn.EmployeeKindDivState.BillCollecter, CustAccRecMainCndtn.ct_EmployeeKindDiv_BillCollecter);

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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
        /// <br>UpdateNote  : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/02/28</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
            bool status = true;

            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";

            // 対象年月
            if (!InputDateEditCheack(this.AddUpYearMonth_tDateEdit))
            {
                errMessage = string.Format("対象年月{0}", ct_InputError);
                errComponent = AddUpYearMonth_tDateEdit;
                status = false;
            }

            // --- ADD START 3H 劉星光 2020/02/28 ----->>>>>
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
            // --- ADD END 3H 劉星光 2020/02/28 -----<<<<<

            // 2008.10.07 30413 犬飼 チェック順序を変更 >>>>>>START
            //// 得意先コード
            //if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            //{
            //    errMessage = string.Format("得意先コード{0}", ct_RangeError);
            //    errComponent = this.tNedit_CustomerCode_St;
            //    status = false;
            //}
            // 2008.10.07 30413 犬飼 チェック順序を変更 <<<<<<END
            
            // 2008.10.01 30413 犬飼 得意先カナ削除 >>>>>>START
            //// 得意先カナ範囲チェック
            //if ((this.CustomerKanaStrat_Edit.DataText != "") && (this.CustomerKanaEnd_Edit.DataText != ""))
            //{
            //    if (this.CustomerKanaStrat_Edit.DataText.CompareTo(this.CustomerKanaEnd_Edit.DataText) > 0)
            //    {
            //        errMessage = "得意先カナの範囲指定に誤りがあります。";
            //        errComponent = this.CustomerKanaStrat_Edit;
            //        status = false;
            //    }
            //}
            // 2008.10.01 30413 犬飼 得意先カナ削除 <<<<<<END

            // 2008.10.07 30413 犬飼 入力チェックを変更 >>>>>>START
            // 担当者コード
            //else if (
            if ((this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()) > 0))
            {
                // 2008.10.01 30413 犬飼 エラーメッセージの変更 >>>>>>START
                //errMessage = string.Format("担当者コード{0}", ct_RangeError);
                errMessage = string.Format("担当者{0}", ct_RangeError);
                // 2008.10.01 30413 犬飼 エラーメッセージの変更 <<<<<<END
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
            }
            
            // 販売エリアコード
            //else if (this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt())
            if ((this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_St.GetInt()) > (this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                // 2008.10.01 30413 犬飼 エラーメッセージの変更 >>>>>>START
                //errMessage = string.Format("販売エリアコード{0}", ct_RangeError);
                errMessage = string.Format("地区{0}", ct_RangeError);
                // 2008.10.01 30413 犬飼 エラーメッセージの変更 <<<<<<END
                errComponent = this.tNedit_SalesAreaCode_St;
                status = false;
            }
            // 2008.10.07 30413 犬飼 入力チェックを変更 <<<<<<END
            
            // 2008.10.07 30413 犬飼 チェック順序を変更 >>>>>>START
            // 得意先コード
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            // 2008.10.07 30413 犬飼 チェック順序を変更 <<<<<<END
            
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.24</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
        /// <br>Update Note : 2012/11/14 李亜博</br>
        ///	<br>			  Redmine#33271 印字制御の区分の追加</br>
        /// <br>Update Note : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/02/28</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(CustAccRecMainCndtn extraInfo)
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
				// 対象月
                // 2008.10.01 30413 犬飼 DateTime型に変更 >>>>>>START
                Int32 idate = this.AddUpYearMonth_tDateEdit.GetLongDate();
                if ((idate % 100) == 0)
                {
                    // 編集かけると日付が"00"となり、GetDateTime()で値を取得できなくなる対応
                    idate++;
                    this.AddUpYearMonth_tDateEdit.SetLongDate(idate);
                }
                // 2008.12.17 30413 犬飼 カレンダー表示に伴う処理を追加 >>>>>>START
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
                // 2008.12.17 30413 犬飼 カレンダー表示に伴う処理を追加 <<<<<<END
                DateTime compDate = this.AddUpYearMonth_tDateEdit.GetDateTime();
                //if (this._baseDate < compDate)
                //{
                //    // 前回月次処理年月より未来日を設定
                //    DateTime startMonthDate;
                //    DateTime endMonthDate;
                //    this._dateGet.GetDaysFromMonth(compDate, out startMonthDate, out endMonthDate);
                //    extraInfo.AddUpYearMonth = compDate;
                //    extraInfo.AddUpDate = startMonthDate.AddDays(1.0);
                //}
                //else
                //{
                //    extraInfo.AddUpYearMonth = compDate;
                //    extraInfo.AddUpDate = DateTime.MinValue;
                //}
                // 2009.02.10 30413 犬飼 月次更新未処理フラグは拠点毎に設定するように修正 >>>>>>START
                //if (this._baseDate < compDate)
                //{
                //    // 未来日の場合、月次更新未処理フラグを立てる
                //    extraInfo.MonAddUpNonProcFlg = true;
                //}
                // 2009.02.10 30413 犬飼 月次更新未処理フラグは拠点毎に設定するように修正 <<<<<<END
                
                DateTime startMonthDate;
                DateTime endMonthDate;
                this._dateGet.GetDaysFromMonth(compDate, out startMonthDate, out endMonthDate);
                extraInfo.AddUpYearMonth = compDate;
                // 2009.01.27 30413 犬飼 リモートの要望により月度終了日を設定するように修正 >>>>>>START
                //extraInfo.AddUpDate = startMonthDate;
                extraInfo.AddUpDate = endMonthDate;
                // 2009.01.27 30413 犬飼 リモートの要望により月度終了日を設定するように修正 <<<<<<END
                // 2008.10.01 30413 犬飼 DateTime型に変更 <<<<<<END

                // 出力順
                extraInfo.SortOrderDiv = (CustAccRecMainCndtn.SortOrderDivState)this.tce_SortOrderDiv.SelectedItem.DataValue;
				// 得意先コード
                extraInfo.St_ClaimCode = this.tNedit_CustomerCode_St.GetInt();	// 開始
				extraInfo.Ed_ClaimCode = this.tNedit_CustomerCode_Ed.GetInt();	// 終了
                // 2008.10.01 30413 犬飼 得意先カナ削除 >>>>>>START
                //// 得意先カナ
                //extraInfo.St_ClaimKana = this.CustomerKanaStrat_Edit.DataText.TrimEnd();  // 開始
                //extraInfo.Ed_ClaimKana = this.CustomerKanaEnd_Edit.DataText.TrimEnd();  // 終了
                // 2008.10.01 30413 犬飼 得意先カナ削除 <<<<<<END
                // 販売エリアコード
                extraInfo.St_SalesAreaCode = this.tNedit_SalesAreaCode_St.GetInt(); // 開始
                extraInfo.Ed_SalesAreaCode = this.tNedit_SalesAreaCode_Ed.GetInt(); // 終了
                // 担当者区分
                extraInfo.EmployeeKindDiv = (CustAccRecMainCndtn.EmployeeKindDivState)this.tce_EmployeeKindDiv.SelectedItem.DataValue;
                // 担当者コード
                // 2008.10.01 30413 犬飼 0埋め対応 >>>>>>START
                //extraInfo.St_EmployeeCode = this.tEdit_EmployeeCode_St.DataText.TrimEnd();	// 開始
                //extraInfo.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.DataText.TrimEnd();	// 終了

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
                // 2008.10.01 30413 犬飼 0埋め対応 <<<<<<END
                
                // 出力金額区分
                extraInfo.OutMoneyDiv = (CustAccRecMainCndtn.OutMoneyDivState)this.tce_OutMoneyDiv.SelectedItem.DataValue;

                // 2008.10.01 30413 犬飼 改頁と入金区分を追加 >>>>>>START
                // 改頁
                extraInfo.NewPageType = (int)this.tComboEditor_NewPageType.Value;
                // 入金区分
                extraInfo.DepoDtlDiv = (int)this.DepositDtl_tComboEditor.Value;
                // 2008.10.01 30413 犬飼 改頁と入金区分を追加 <<<<<<END
                // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
                ////罫線印字区分 
                extraInfo.LineMaSqOfChDiv = (int)this.tComboEditor_LineMaSqOfChDiv.Value;
                // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

                // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
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
                // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<
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
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Date	   : 2007.10.24</br>
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
		#region ◆ DCKAU02540UA
        #region ◎ DCKAU02540UA_Load Event
        /// <summary>
        /// DCKAU02540UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
        /// </remarks>
        private void DCKAU02540UA_Load(object sender, EventArgs e)
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
        #endregion ◆ DCKAU02540UA

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
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.24</br>
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
        /// <br>Update Note: 2012/12/25 董桂鈺</br>
        ///	<br>			 Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br>
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
                uiMemInput1.ReadMemInput();//ADD 董桂鈺　2012/12/25 for Redmine#33271

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
            // 2008.10.01 30413 犬飼 得意先ガイドのクラスを変更、ガイドボタンのフォーカス制御を変更 >>>>>>START
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

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);
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
            // 2008.10.01 30413 犬飼 得意先ガイドのクラスを変更、ガイドボタンのフォーカス制御を変更 <<<<<<END
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
        /// <br>Programmer  :20081 疋田 勇人</br>
        /// <br>Date        :2007.10.24</br>
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
        private void ub_St_SalesAreaGuid_Click(object sender, EventArgs e)
        {
            // 2008.10.01 30413 犬飼 フォーカス制御を追加 >>>>>>START
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
            // 2008.10.01 30413 犬飼 フォーカス制御を追加 <<<<<<END
        }
        #endregion
        #endregion ◆ ub_St_SalesAreaGuid

        #region ◆ ub_St_EmployeeCdGuid
        #region ◎ Click Event
        /// <summary>
        /// Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EmployeeCdGuid_Click(object sender, EventArgs e)
        {
            // 2008.10.01 30413 犬飼 フォーカス制御を追加 >>>>>>START
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
            // 2008.10.01 30413 犬飼 フォーカス制御を追加 <<<<<<END
        }
        #endregion

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
        #endregion ◆ ub_St_EmployeeCdGuid

        #endregion

        // --- ADD 3H 劉星光 2020/02/28---------->>>>>
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
        // --- ADD 3H 劉星光 2020/02/28----------<<<<<
    }
}