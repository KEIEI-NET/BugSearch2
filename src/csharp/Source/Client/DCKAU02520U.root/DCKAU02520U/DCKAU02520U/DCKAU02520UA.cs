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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 回収予定表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 回収予定表UIフォームクラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.10.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.11.11</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30414 忍</br>
    /// <br>Date	   : 2009.02.24</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 障害・改良対応8月リリース分</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date	   : 2010/08/05</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : #13691の対応</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date	   : 2010/08/26</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : #14542の対応</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date	   : 2010/09/09</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 空白行印字制御・罫線印字制御の追加</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date	   : 2011/03/14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 連番982 画面にスクロール追加</br>
    /// <br>本体ソッス改修なし</br>
    /// <br>Programmer : 王飛３</br>
    /// <br>Date	   : 2011/08/08</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 2012/06/27配信分 Redmine#29880 回収予定表　得意先マスタの「得意先名」を印字できるようにするの対応</br>
    /// <br>Programmer : gezh</br>
    /// <br>Date	   : 2012/05/22</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
	public partial class DCKAU02520UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 回収予定表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 回収予定表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
        /// <br>UpdateNote : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date	   : 2011/03/14</br>
        /// <br></br>
		/// </remarks>
		public DCKAU02520UA ()
		{
			InitializeComponent();
       
			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList = new Hashtable();

			// 回収予定表アクセスクラス
            this._collectPlanAcs = new CollectPlanAcs();

            // 2008.11.11 30413 犬飼 アクセスクラスの追加 >>>>>>START
            // 入金設定マスタアクセスクラス
            this._depositStAcs = new DepositStAcs();

            this._dicDepositStKind = new Dictionary<int, string>();
            this._dicDepositStRowNo = new Dictionary<int, int>();
            // 2008.11.11 30413 犬飼 アクセスクラスの追加 <<<<<<END

            // 2008.11.20 30413 犬飼 日付取得部品の追加 >>>>>>START
            //日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();
            // 2008.11.20 30413 犬飼 日付取得部品の追加 <<<<<<END

            //---ADD 2011/03/14--------------------------------------->>>>>
            List<Control> ctrlList = new List<Control>();
         
            ctrlList.Add(this.tce_SortOrderDiv);              // 出力順
            ctrlList.Add(this.tComboEditor_NewPageType);                 // 改頁
            ctrlList.Add(this.tNedit_CustomerCode_St);         // 得意先コード (開始)
            ctrlList.Add(this.tNedit_CustomerCode_Ed);     // 得意先コード (終了)
            ctrlList.Add(this.tce_EmployeeKindDiv);           // 担当者区分
            ctrlList.Add(this.tEdit_EmployeeCode_St);           // 担当コード (開始)
            ctrlList.Add(this.tEdit_EmployeeCode_Ed);         // 担当コード (終了)
            ctrlList.Add(this.tce_PrintDiv);          // 印刷区分
            ctrlList.Add(this.tComboEditor_PrintBlLi);          // 空白行印字
            ctrlList.Add(this.tComboEditor_LineMaSqOfCh);        // 罫線印字
            ctrlList.Add(this.tNedit_SalesAreaCode_St);  // 販売エリアコード (開始)
            ctrlList.Add(this.tNedit_SalesAreaCode_Ed);  // 販売エリアコード (終了)
            ctrlList.Add(this.clb_CollectCond);  // 回収条件
            ctrlList.Add(this.tComboEditor_CustomerNamePrint);  // 得意先名称印字  // ADD 2012/05/22 gezh Redmine#29880

            uiMemInput1.TargetControls = ctrlList;
            //---ADD 2011/03/14---------------------------------------<<<<<
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
		// 回収予定表アクセスクラス
        private CollectPlanAcs _collectPlanAcs;
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 得意先ガイド用
		private string _customerTag = "";
		// 担当者ガイド
		private EmployeeAcs _employeeAcs;

        // ユーザーガイドアクセスクラス
        private UserGuideAcs _userGuideAcs;

        // 2008.11.11 30413 犬飼 入金設定マスタ取得プロパティの追加 >>>>>>START
        // 入金設定マスタアクセスクラス
        private DepositStAcs _depositStAcs;

        // 入金設定内訳リスト
        private Dictionary<Int32, String> _dicDepositStKind;
        // 入金設定行番号リスト
        private Dictionary<Int32, Int32> _dicDepositStRowNo;
        // 金種辞書
        /// <summary> 金種辞書(Key:CheckedListのindex, Value:MoneyKindクラス) </summary>
        private Dictionary<int, MoneyKind> _moneyKindDic = new Dictionary<int, MoneyKind>();
        // 2008.11.11 30413 犬飼 入金設定マスタ取得プロパティの追加 <<<<<<END

        // 2008.11.20 30413 犬飼 日付取得部品の追加 >>>>>>START
        // 日付取得部品
        private DateGetAcs _dateGetAcs;
        // 2008.11.20 30413 犬飼 日付取得部品の追加 <<<<<<END

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID			= "DCKAU02520UA";
		// プログラムID
		private const string ct_PGID			= "DCKAU02520U";
		// 帳票名称
        private const string ct_PrintName		= "回収予定表";
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
        /// <br>Date		: 2007.10.23</br>
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
            RsltInfo_CollectPlan extrInfo = new RsltInfo_CollectPlan();

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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
        /// <br>UpdateNote  : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/14</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
				// 処理日付
				this.tde_AddUpADate.SetDateTime( TDateTime.GetSFDateNow() );
				// 得意先コード
				this.tNedit_CustomerCode_St.Clear();
				this.tNedit_CustomerCode_Ed.Clear();
                // 販売エリアコード
                this.tNedit_SalesAreaCode_St.Clear();
                this.tNedit_SalesAreaCode_Ed.Clear();
				// 担当者コード
				this.tEdit_EmployeeCode_St.Clear();
				this.tEdit_EmployeeCode_Ed.Clear();
				// 担当者区分
				this.InitializeEmployeeKindDiv();

                // 2008.11.12 30413 犬飼 改頁の初期値設定 >>>>>>START
                this.tComboEditor_NewPageType.Value = 0;
                // 2008.11.12 30413 犬飼 改頁の初期値設定 <<<<<<END

                //---ADD 2011/03/14-------------------------------------------------------->>>>>
                // 空白行印字
                this.tComboEditor_PrintBlLi.Value = 1;

                // 罫線印字
                this.tComboEditor_LineMaSqOfCh.Value = 0;
                //---ADD 2011/03/14--------------------------------------------------------<<<<<
                this.tComboEditor_CustomerNamePrint.Value = 0;  // 得意先名称印字  // ADD 2012/05/22 gezh Redmine#29880

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
        /// <br>Date		: 2007.10.23</br>
        /// </remarks>
		private void InitializeSortOrderDiv()
		{
			// 出力順
			this.tce_SortOrderDiv.Items.Clear();
			// 得意先コード
            this.tce_SortOrderDiv.Items.Add(RsltInfo_CollectPlan.SortOrderDivState.CustomerCode, RsltInfo_CollectPlan.ct_SortOrderDiv_CustomerCode);
            // 担当者コード順
            this.tce_SortOrderDiv.Items.Add(RsltInfo_CollectPlan.SortOrderDivState.EmployeeCode, RsltInfo_CollectPlan.ct_SortOrderDiv_EmployeeCode);
            // 販売エリアコード順
            this.tce_SortOrderDiv.Items.Add(RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCode, RsltInfo_CollectPlan.ct_SortOrderDiv_SalesAreaCode);
            // 担当者別回収日順
            this.tce_SortOrderDiv.Items.Add(RsltInfo_CollectPlan.SortOrderDivState.EmployeeCollect, RsltInfo_CollectPlan.ct_SortOrderDiv_EmployeeCollect);
            // 販売エリアコード別回収日順
            this.tce_SortOrderDiv.Items.Add(RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCollect, RsltInfo_CollectPlan.ct_SortOrderDiv_SalesAreaCollect);
            // 集金日順
            this.tce_SortOrderDiv.Items.Add(RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDay, RsltInfo_CollectPlan.ct_SortOrderDiv_CollectMoneyDay);
            // 集金日別回収条件順
            this.tce_SortOrderDiv.Items.Add(RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond, RsltInfo_CollectPlan.ct_SortOrderDiv_CollectMoneyDayCond);

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
        /// <br>Date		: 2007.10.23</br>
        /// </remarks>
		private void InitializeEmployeeKindDiv()
		{
			// 担当者区分
			this.tce_EmployeeKindDiv.Items.Clear();
			// 顧客担当者
            this.tce_EmployeeKindDiv.Items.Add(RsltInfo_CollectPlan.EmployeeKindDivState.Customer, RsltInfo_CollectPlan.ct_EmployeeKindDiv_Customer);
            // 集金担当
            this.tce_EmployeeKindDiv.Items.Add(RsltInfo_CollectPlan.EmployeeKindDivState.BillCollecter, RsltInfo_CollectPlan.ct_EmployeeKindDiv_BillCollecter);

			this.tce_EmployeeKindDiv.MaxDropDownItems = this.tce_EmployeeKindDiv.Items.Count;
			this.tce_EmployeeKindDiv.SelectedIndex = 0;
		}
		#endregion

        // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
        // --- DEL 2010/08/05 ------------------------------------------------------>>>>>
        #region ◎ 回収条件ツリー初期化処理
        /// <summary>
        /// 回収条件初期化処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 回収条件の初期化を行う</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.23</br>
        /// </remarks>
        private void InitializeCollectCond()
        {
            SortedList _collectCondList = new SortedList();

            // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 >>>>>>START
            // 2008.11.21 30413 犬飼 金額設定マスタから回収条件を設定していたのを固定に戻す >>>>>>START
            this.clb_CollectCond.Items.Clear();
            // 全てノード追加
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_All_Name, CheckState.Checked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Cash, CheckState.Unchecked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Remittance, CheckState.Unchecked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Check, CheckState.Unchecked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Bill, CheckState.Unchecked);
            //this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Fee, CheckState.Unchecked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Offset, CheckState.Unchecked);
            //this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Discount, CheckState.Unchecked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Others, CheckState.Unchecked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_FundTransfer, CheckState.Unchecked);
            this.clb_CollectCond.Items.Add(RsltInfo_CollectPlan.ct_CollectCondDiv_Factoring, CheckState.Unchecked);

            //for (int index = 1; index <= this._dicDepositStRowNo.Count; index++)
            //{
            //    int rowNo = this._dicDepositStRowNo[index];
            //    // Listに追加
            //    clb_CollectCond.Items.Add(this._dicDepositStKind[rowNo].ToString(), CheckState.Unchecked);
            //}
            // 2008.11.21 30413 犬飼 金額設定マスタから回収条件を設定していたのを固定に戻す <<<<<<END
            // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 <<<<<<END
        }
        #endregion
        // --- DEL 2010/08/05 ------------------------------------------------------<<<<<
        // --- UPD 2010/09/10 ------------------------------------------------------<<<<<

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
        /// <br>Date		: 2007.10.23</br>
        /// <br>Note : 障害・改良対応8月リリース分</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date	   : 2010/08/05</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

			const string ct_InputError = "の入力が不正です";
			const string ct_NoInput	   = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";

            DateGetAcs.CheckDateResult cdrResult;

            // 2008.11.13 30413 犬飼 エラーチェックの修正 >>>>>> START
			// 処理日のチェック
            //if( !this.DateEditInputCheck( this.tde_AddUpADate, false ) )
            //{
            //    errMessage		= string.Format( "処理日{0}", ct_InputError );
            //    errComponent	= this.tde_AddUpADate;
            //    status			= false;
            //}
            //else if ( this.tde_AddUpADate.GetDateTime() == DateTime.MinValue )
            //{
            //    errMessage		= string.Format( "処理日{0}", ct_NoInput );
            //    errComponent	= this.tde_AddUpADate;
            //    status			= false;
            //}

            if (CallCheckDate(out cdrResult, ref tde_AddUpADate) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("処理日{0}", ct_InputError);
                            errComponent = this.tde_AddUpADate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("処理日{0}", ct_NoInput);
                            errComponent = this.tde_AddUpADate;
                        }
                        break;
                }
                status = false;
            }

            //// 得意先コード
            //else if ((this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            //{
            //    errMessage		= string.Format( "得意先コード{0}", ct_RangeError );
            //    errComponent	= this.tNedit_CustomerCode_St;
            //    status			= false;
            //}
            // 担当者コード
			else if ( 
				( this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty ) && 
				( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty )&&
                //( this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() ) > 0 ) )
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
			{
                //errMessage		= string.Format( "担当者コード{0}", ct_RangeError );
                if (this.tce_EmployeeKindDiv.SelectedIndex == 0)
                {
                    errMessage = string.Format("得意先担当{0}", ct_RangeError);
                }
                else
                {
                    errMessage = string.Format("集計担当{0}", ct_RangeError);
                }
                errComponent	= this.tEdit_EmployeeCode_St;
				status			= false;
			}
            // 販売エリアコード
            // 2008.12.12 30413 地区の範囲チェック条件を修正
            else if ((this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                     (this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                //errMessage = string.Format("販売エリアコード{0}", ct_RangeError);
                errMessage = string.Format("地区{0}", ct_RangeError);
                errComponent = this.tNedit_SalesAreaCode_St;
                status = false;
            }
            // 得意先
            else if ((this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            // DEL 2010/08/05--------------------->>>>>
            //// 締日
            //else if (tne_CAddUpUpdExecDate.GetInt() > 31)
            //{
            //    errMessage		= "締日は１～３１日の範囲で入力してください";
            //    errComponent = this.tne_CAddUpUpdExecDate;
            //    status			= false;
            //}
            //// 回収日
            //else if (tne_CollectSchedule.GetInt() > 31)
            //{
            //    errMessage = "回収日は１～３１日の範囲で入力してください";
            //    errComponent = this.tne_CollectSchedule;
            //    status = false;
            //}
            // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
            // 回収条件
            else if (!CheckInputPaymentCondDiv())
            {
                errMessage = "回収条件を選択してください";
                errComponent = this.clb_CollectCond;
                status = false;
            }
            // --- UPD 2010/09/10 ------------------------------------------------------<<<<<
            // DEL 2010/08/05---------------------<<<<<
            // 2008.11.13 30413 犬飼 エラーチェックの修正 <<<<<<END
			
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.23</br>
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

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = _dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }
        // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
        // DEL 2010/08/05--------------------->>>>>
        #region ◎ 回収条件チェック処理
        /// <summary>
        /// 回収条件チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 回収条件の入力をチェック。</br>
        /// <br>Programmer : 20081 疋田　勇人</br>
        /// <br>Date       : 2007.10.23</br>
        /// </remarks>	
        private bool CheckInputPaymentCondDiv()
        {
            // 変数宣言
            bool checkStatus = false;

            if (clb_CollectCond.CheckedItems.Count > 0)
                checkStatus = true;

            return checkStatus;
        }
        #endregion
        // DEL 2010/08/05---------------------<<<<<
        // --- UPD 2010/09/10 ------------------------------------------------------<<<<<
		#region ◎ 抽出条件設定処理(画面→抽出条件)
		/// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.23</br>
        /// <br>Note        : 障害・改良対応8月リリース分</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date	    : 2010/08/05</br>
        /// <br>UpdateNote  : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(RsltInfo_CollectPlan extraInfo)
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
                // 処理日
                extraInfo.AddUpDate = this.tde_AddUpADate.GetDateTime();
				// 出力順
                extraInfo.SortOrderDiv = (RsltInfo_CollectPlan.SortOrderDivState)this.tce_SortOrderDiv.SelectedItem.DataValue;
                // UPD 2010/08/05------------------------------->>>>>
                // 処理日
                //extraInfo.TotalDay = this.tne_CAddUpUpdExecDate.GetInt();
                extraInfo.TotalDay = (int)this.tce_CAddUpUpdExecDate.Value;
                // UPD 2010/08/05-------------------------------<<<<<
                // 改頁
                extraInfo.NewPageDiv = (int)this.tComboEditor_NewPageType.Value;
				// 得意先コード
				extraInfo.St_ClaimCode = this.tNedit_CustomerCode_St.GetInt();				// 開始
				extraInfo.Ed_ClaimCode = this.tNedit_CustomerCode_Ed.GetInt();				// 終了
                // 販売エリアコード
                extraInfo.St_SalesAreaCode = this.tNedit_SalesAreaCode_St.GetInt();		// 開始
                extraInfo.Ed_SalesAreaCode = this.tNedit_SalesAreaCode_Ed.GetInt();		// 終了
				// 担当者区分
                extraInfo.EmployeeKindDiv = (RsltInfo_CollectPlan.EmployeeKindDivState)this.tce_EmployeeKindDiv.SelectedItem.DataValue;
                //// 担当者コード
                //extraInfo.St_EmployeeCode = this.tEdit_EmployeeCode_St.DataText.TrimEnd();	// 開始
                //extraInfo.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.DataText.TrimEnd();	// 終了
                // 担当コード(開始)
                if (this.tEdit_EmployeeCode_St.Text.Trim() == "")
                {
                    extraInfo.St_EmployeeCode = "";
                }
                else
                {
                    extraInfo.St_EmployeeCode = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                }
                // 担当コード(終了)
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == "")
                {
                    extraInfo.Ed_EmployeeCode = "";
                }
                else
                {
                    extraInfo.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                }
                // UPD 2010/08/05------------------------------->>>>>
                // 回収日
                //extraInfo.ExpectedDepositDate = this.tne_CollectSchedule.GetInt();
                extraInfo.ExpectedDepositDate = (int)this.tce_CollectSchedule.Value;

                // 回収条件
                // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
                GetCollectCondDiv(extraInfo);
                //GetCollectCondDivNew(extraInfo);
                // --- UPD 2010/09/10 ------------------------------------------------------<<<<<
                // UPD 2010/08/05-------------------------------<<<<<

                // --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------>>>>>
                // 印刷区分
                extraInfo.PrintExpctDiv = (int)this.tce_PrintDiv.Value;
                // --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------<<<<<


                //---ADD 2011/03/14-------------------------------------------------------->>>>>
                //空白行印字
                extraInfo.PrintBlLiDiv = (int)this.tComboEditor_PrintBlLi.Value;

                //罫線印字
                extraInfo.LineMaSqOfChDiv = (int)this.tComboEditor_LineMaSqOfCh.Value;
                //---ADD 2011/03/14--------------------------------------------------------<<<<<
                extraInfo.CustomerNamePrint = (int)this.tComboEditor_CustomerNamePrint.Value;  // 得意先名称印字  // ADD 2012/05/22 gezh Redmine#29880

                // 2008.11.11 30413 犬飼 項目削除 >>>>>>START
                //// 締日末日指定
                //if (chk_IsLastDay.Enabled)
                //{
                //    extraInfo.IsLastDayTotalDay = this.chk_IsLastDay.Checked;
                //}
                //else
                //{
                //    extraInfo.IsLastDayTotalDay = false;
                //}
                //// 回収予定日末日指定
                //if (chk_IsLastDayCollect.Enabled)
                //{
                //    extraInfo.IsLastDayCollectSchedule = this.chk_IsLastDayCollect.Checked;
                //}
                //else
                //{
                //    extraInfo.IsLastDayCollectSchedule = false;
                //}
                // 2008.11.11 30413 犬飼 項目削除 <<<<<<END   

			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
		#endregion
        // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
        // DEL 2010/08/05--------------------->>>>>
        #region ◎ 回収条件取得処理
        /// <summary>
        /// 回収条件取得処理
        /// </summary>
        /// <param name="extrInfo">回収予定表抽出条件クラス</param>
        /// <remarks>
        /// <br>Note		: 回収条件を取得する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.23</br>
        /// </remarks>
        private void GetCollectCondDiv(RsltInfo_CollectPlan extrInfo)
        {
            extrInfo.CollectCond.Clear();

            // 2008.11.21 30413 犬飼 金額設定マスタから回収条件を設定していたのを固定に戻す >>>>>>START
            // 2008.11.20 30413 犬飼 回収条件の金種コードと名称の取得を変更 >>>>>>START
            // チェックされているアイテムの中に「全て」が存在するか
            if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[0]))
            {
                // 全てが選択されているとき
                extrInfo.CollectCond.Add(RsltInfo_CollectPlan.ct_All_Code, RsltInfo_CollectPlan.ct_All_Name);
            }
            else
            {
                // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 >>>>>>START
                // 「全て」がない場合
                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[1]))
                {
                    // 現金が選択されているとき
                    //extrInfo.CollectCond.Add(10, RsltInfo_CollectPlan.ct_CollectCondDiv_Cash);
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Cash, RsltInfo_CollectPlan.ct_CollectCondDiv_Cash);
                }

                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[2]))
                {
                    // 振込が選択されているとき
                    //extrInfo.CollectCond.Add(20, RsltInfo_CollectPlan.ct_CollectCondDiv_Remittance);
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Remittance, RsltInfo_CollectPlan.ct_CollectCondDiv_Remittance);
                }

                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[3]))
                {
                    // 小切手が選択されているとき
                    //extrInfo.CollectCond.Add(30, RsltInfo_CollectPlan.ct_CollectCondDiv_Check);
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Check, RsltInfo_CollectPlan.ct_CollectCondDiv_Check);
                }

                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[4]))
                {
                    // 手形が選択されているとき
                    //extrInfo.CollectCond.Add(40, RsltInfo_CollectPlan.ct_CollectCondDiv_Bill);
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Bill, RsltInfo_CollectPlan.ct_CollectCondDiv_Bill);
                }

                //if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[5]))
                //{
                //    // 手数料が選択されているとき
                //    extrInfo.CollectCond.Add(50, RsltInfo_CollectPlan.ct_CollectCondDiv_Fee);
                //}

                //if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[6]))
                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[5]))
                {
                    // 相殺が選択されているとき
                    //extrInfo.CollectCond.Add(60, RsltInfo_CollectPlan.ct_CollectCondDiv_Offset);
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Offset, RsltInfo_CollectPlan.ct_CollectCondDiv_Offset);
                }

                //if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[7]))
                //{
                //    // 値引が選択されているとき
                //    extrInfo.CollectCond.Add(70, RsltInfo_CollectPlan.ct_CollectCondDiv_Discount);
                //}

                //if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[8]))
                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[6]))
                {
                    // その他が選択されているとき
                    //extrInfo.CollectCond.Add(80, RsltInfo_CollectPlan.ct_CollectCondDiv_Others);
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Others, RsltInfo_CollectPlan.ct_CollectCondDiv_Others);
                }

                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[7]))
                {
                    // 口座振替が選択されているとき
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.FundTransfer, RsltInfo_CollectPlan.ct_CollectCondDiv_FundTransfer);
                }

                if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[8]))
                {
                    // ファクタリングが選択されているとき
                    extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Factoring, RsltInfo_CollectPlan.ct_CollectCondDiv_Factoring);
                }
                // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 <<<<<<END

                //for (int i = 1; i < this.clb_CollectCond.Items.Count; i++)
                //{
                //    if (this.clb_CollectCond.CheckedItems.Contains(this.clb_CollectCond.Items[i]))
                //    {
                //        // チェック有
                //        int collectCode = this._dicDepositStRowNo[i];               // 金種コード
                //        string collectName = this._dicDepositStKind[collectCode];   // 金種名称
                //        extrInfo.CollectCond.Add(collectCode, collectName);
                //    }
                //}
            }
            // 2008.11.20 30413 犬飼 回収条件の金種コードと名称の取得を変更 <<<<<<END
            // 2008.11.21 30413 犬飼 金額設定マスタから回収条件を設定していたのを固定に戻す <<<<<<END
        }
        #endregion
        // DEL 2010/08/05---------------------<<<<<
        // --- UPD 2010/09/10 ------------------------------------------------------<<<<<
        #endregion ◆ 印刷前処理
        // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
        //// ADD 2010/08/05--------------------->>>>>
        //#region ◎ 回収条件取得処理
        ///// <summary>
        ///// 回収条件取得処理
        ///// </summary>
        ///// <param name="extrInfo">回収予定表抽出条件クラス</param>
        ///// <remarks>
        ///// <br>Note		: 回収条件を取得する。</br>
        ///// <br>Programmer	: 高峰</br>
        ///// <br>Date		: 2010/08/05</br>
        ///// </remarks>
        //private void GetCollectCondDivNew(RsltInfo_CollectPlan extrInfo)
        //{
        //    extrInfo.CollectCond.Clear();

        //    // 選択されているアイテムは「全て」の場合
        //    if (this.tce_CollectCond.SelectedIndex == 0)
        //    {
        //        // 全てが選択されているとき
        //        extrInfo.CollectCond.Add(RsltInfo_CollectPlan.ct_All_Code, RsltInfo_CollectPlan.ct_All_Name);
        //    }
        //    else
        //    {
        //        // 選択されているアイテムは「全て」ではない場合
        //        if (this.tce_CollectCond.SelectedIndex == 1)
        //        {
        //            // 現金が選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Cash, RsltInfo_CollectPlan.ct_CollectCondDiv_Cash);
        //        }

        //        if (this.tce_CollectCond.SelectedIndex == 2)
        //        {
        //            // 振込が選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Remittance, RsltInfo_CollectPlan.ct_CollectCondDiv_Remittance);
        //        }

        //        if (this.tce_CollectCond.SelectedIndex == 3)
        //        {
        //            // 小切手が選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Check, RsltInfo_CollectPlan.ct_CollectCondDiv_Check);
        //        }

        //        if (this.tce_CollectCond.SelectedIndex == 4)
        //        {
        //            // 手形が選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Bill, RsltInfo_CollectPlan.ct_CollectCondDiv_Bill);
        //        }

        //        if (this.tce_CollectCond.SelectedIndex == 5)
        //        {
        //            // 相殺が選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Offset, RsltInfo_CollectPlan.ct_CollectCondDiv_Offset);
        //        }

        //        if (this.tce_CollectCond.SelectedIndex == 6)
        //        {
        //            // その他が選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Others, RsltInfo_CollectPlan.ct_CollectCondDiv_Others);
        //        }

        //        if (this.tce_CollectCond.SelectedIndex == 7)
        //        {
        //            // 口座振替が選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.FundTransfer, RsltInfo_CollectPlan.ct_CollectCondDiv_FundTransfer);
        //        }

        //        if (this.tce_CollectCond.SelectedIndex == 8)
        //        {
        //            // ファクタリングが選択されているとき
        //            extrInfo.CollectCond.Add((int)RsltInfo_CollectPlan.CollectCondDivState.Factoring, RsltInfo_CollectPlan.ct_CollectCondDiv_Factoring);
        //        }
        //    }
        //}
        //#endregion
        //// ADD 2010/08/05---------------------<<<<<
        // --- UPD 2010/09/10 ------------------------------------------------------<<<<<
		#region ◆ ControlEventから呼び出し
		#region ◎ Enabled設定関数
		/// <summary>
		/// Enabled設定関数
		/// </summary>
		/// <param name="isSort">印字順位Enabled</param>
		private void SetCtrlEnablePrintChange(bool isSort)
		{
            tce_SortOrderDiv.Enabled			= isSort;				// 印字順位
		}
		#endregion
		#endregion ◆

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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
		#region ◆ DCKAU02520UA
        #region ◎ DCKAU02520UA_Load Event
        /// <summary>
        /// DCKAU02520UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.23</br>
        /// </remarks>
        /// 
        private void DCKAU02520UA_Load(object sender, EventArgs e)
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
        #endregion ◆ DCKAU02520UA

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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <br>Date		: 2007.10.23</br>
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
        /// <remarks>
        /// <br>Note        : 障害・改良対応8月リリース分</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date	    : 2010/08/05</br>
        /// <br>Update Note : 2010/08/26 楊明俊 #13691の対応</br>
        /// <br>UpdateNote  : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/14</br>
        /// </remarks>
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

                // --- ADD 2010/08/05 ------------------------------------------------------>>>>>
                // 締日
                this.tce_CAddUpUpdExecDate.Items.Clear();
                this.tce_CAddUpUpdExecDate.Items.Add(0, "全締日");
                //-----UPD 2010/08/26---------->>>>> 
                //for (int i = 1; i <= 31; i++)
                for (int i = 1; i <= 27; i++)
                //-----UPD 2010/08/26----------<<<<<
                {
                    this.tce_CAddUpUpdExecDate.Items.Add(i, i.ToString() + "日");
                }

                //-----UPD 2010/08/26---------->>>>> 
                this.tce_CAddUpUpdExecDate.Items.Add(31, "末日");
                //this.tce_CAddUpUpdExecDate.MaxDropDownItems = 32;
                this.tce_CAddUpUpdExecDate.MaxDropDownItems = 29;
                //-----UPD 2010/08/26----------<<<<<

                this.tce_CAddUpUpdExecDate.Value = 0;

                // 回収日
                this.tce_CollectSchedule.Items.Clear();
                //-----UPD 2010/08/26---------->>>>> 
                //this.tce_CollectSchedule.Items.Add(0, "全締日");
                //for (int i = 1; i <= 31; i++)
                this.tce_CollectSchedule.Items.Add(0, "全回収日");

                for (int i = 1; i <= 27; i++)
                //-----UPD 2010/08/26----------<<<<<
                {
                    this.tce_CollectSchedule.Items.Add(i, i.ToString() + "日");
                }
                //-----UPD 2010/08/26---------->>>>> 
                this.tce_CollectSchedule.Items.Add(31, "末日");
                //this.tce_CollectSchedule.MaxDropDownItems = 32;
                this.tce_CollectSchedule.MaxDropDownItems = 29;
                //-----UPD 2010/08/26----------<<<<<
                
                this.tce_CollectSchedule.Value = 0;
                // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
                // 回収条件
                //this.tce_CollectCond.Items.Clear();
                //this.tce_CollectCond.Items.Add(0, "全て");
                //this.tce_CollectCond.Items.Add(1, "現金");
                //this.tce_CollectCond.Items.Add(2, "振込");
                //this.tce_CollectCond.Items.Add(3, "小切手");
                //this.tce_CollectCond.Items.Add(4, "手形");
                //this.tce_CollectCond.Items.Add(5, "相殺");
                //this.tce_CollectCond.Items.Add(6, "その他");
                //this.tce_CollectCond.Items.Add(7, "口座振替");
                //this.tce_CollectCond.Items.Add(8, "ファクタリング");
                //this.tce_CollectCond.MaxDropDownItems = 9;
                //this.tce_CollectCond.Value = 0;

                // --- ADD 2010/08/05 ------------------------------------------------------<<<<<

                // --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------>>>>>
                // 印刷区分
                this.tce_PrintDiv.Items.Clear();
                this.tce_PrintDiv.Items.Add(0, "予定額＜0でも印字する");
                this.tce_PrintDiv.Items.Add(1, "予定額＜0は印字しない");

                this.tce_PrintDiv.MaxDropDownItems = 2;
                this.tce_PrintDiv.Value = 0;
                // --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------<<<<<

                
                //---ADD 2011/03/14-------------------------------------------------------->>>>>
                // 空白行印字
                this.tComboEditor_PrintBlLi.Items.Clear();
                this.tComboEditor_PrintBlLi.Items.Add(0, "印字する");
                this.tComboEditor_PrintBlLi.Items.Add(1, "印字しない");

                this.tComboEditor_PrintBlLi.MaxDropDownItems = 2;
                this.tComboEditor_PrintBlLi.Value = 1;

                // 罫線印字
                this.tComboEditor_LineMaSqOfCh.Items.Clear();
                this.tComboEditor_LineMaSqOfCh.Items.Add(0, "印字する");
                this.tComboEditor_LineMaSqOfCh.Items.Add(1, "印字しない");

                this.tComboEditor_LineMaSqOfCh.MaxDropDownItems = 2;
                this.tComboEditor_LineMaSqOfCh.Value = 0;
                //---ADD 2011/03/14--------------------------------------------------------<<<<<
                // 金種マスタの取得
                GetMoneyKind(out errMsg);

                // 入金設定マスタの取得
                GetDepositSet();
                // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
                //// --- DEL 2010/08/05 ------------------------------------------------------>>>>>
                //// 回収条件
                ////this.InitializeCollectCond();
                //// --- DEL 2010/08/05 ------------------------------------------------------<<<<<
                 //回収条件
                this.InitializeCollectCond();
                // --- UPD 2010/09/10 ------------------------------------------------------<<<<<
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
					return;
				}

				// ガイドボタンのアイコン設定
				this.SetIconImage( this.ub_St_CustomerCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCdGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_SalesAreaGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_SalesAreaGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_St_EmployeeCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_EmployeeCdGuid, Size16_Index.STAR1 );

				ParentToolbarSettingEvent( this );	// ツールバー設定イベント
			}
			finally
            {
                uiMemInput1.ReadMemInput(); // ADD 2011/03/04
				
                this.tde_AddUpADate.Focus();

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
            // 2008.11.11 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            int beCustCd;
            this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();

            // フォーカス制御用、ガイド呼出前の得意先コード
            if (this._customerTag.CompareTo("1") == 0)
            {
                // 開始
                beCustCd = this.tNedit_CustomerCode_St.GetInt();
            }
            else
            {
                // 終了
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
            // 2008.11.11 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END
		}
		#endregion
		#endregion ◆ ub_St_CustomerCdGuid

		#region ◆ ub_St_EmployeeCdGuid
		#region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_EmployeeCdGuid_Click ( object sender, EventArgs e )
		{
            int status = -1;

			// インスタンス確認
			if ( this._employeeAcs == null )
				this._employeeAcs = new EmployeeAcs();

			// ガイド起動
			Employee employee = new Employee();
            status = this._employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
            if (status == 0)
            {
                if (((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                else
                    this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.11.11 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.11.11 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }

		}
		#endregion
        #endregion ◆ ub_St_EmployeeCdGuid

        #region ◆ ub_St_SalesAreaGuid
        #region ◎ Click Event
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
                    this.tNedit_SalesAreaCode_St.DataText = userGdBd.GuideCode.ToString();
                else
                    this.tNedit_SalesAreaCode_Ed.DataText = userGdBd.GuideCode.ToString();

                // 2008.11.11 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.11.11 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }
        #endregion
        #endregion ◆ ub_St_SalesAreaGuid
        // --- UPD 2010/09/10 ------------------------------------------------------>>>>>
        //// DEL 2010/08/05------------------------------->>>>>
        #region ◆ clb_CollectCond
        #region ◎ ItemCheck Event
        /// <summary>
        /// ItemCheck Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : チェック状態が変わろうとしている時に発生。イベント後、チェック状態が変更される。</br>
        /// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.23</br>
        /// </remarks>
        private void clb_CollectCond_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (this.clb_CollectCond.GetItemChecked(0) == false) // これから選択されようとしているので値は逆
                {
                    // 「全て」が選択された場合、「全て」以外の選択を解除
                    for (int i = 1; i < clb_CollectCond.Items.Count; i++)
                    {
                        this.clb_CollectCond.SetItemChecked(i, false);
                    }
                }
                else
                {
                    if (this.clb_CollectCond.CheckedItems.Count == 0)
                    {
                        // 選択項目が全て解除された場合、「全て」を選択状態にする
                        this.clb_CollectCond.SetItemChecked(0, true);
                    }
                }
            }
            else
            {
                if (this.clb_CollectCond.GetItemChecked(e.Index) == false) // これから選択されようとしているので値は逆
                {
                    // 「全て」以外が選択状態にされた場合は、「全て」の選択状態を解除
                    this.clb_CollectCond.SetItemChecked(0, false);
                }
            }
        }
        #endregion
        #endregion ◆ clb_CollectKind
        //// DEL 2010/08/05-------------------------------<<<<<
        // --- UPD 2010/09/10 ------------------------------------------------------<<<<<
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
        /// <br>Date        :2007.10.23</br>
        /// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

            //得意先(仕入先)コードをセット     
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
        #endregion

        // 2008.11.11 30413 犬飼 未使用メソッド削除 >>>>>>START
        //private void chk_IsLastDay_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_IsLastDay.Checked != true)
        //    {
        //        tne_CAddUpUpdExecDate.Enabled = true;
        //    }
        //    else
        //    {
        //        tne_CAddUpUpdExecDate.Value = 99;
        //        tne_CAddUpUpdExecDate.Text = "";
        //        tne_CAddUpUpdExecDate.Enabled = false;
        //    }

        //}
        
        //private void chk_IsLastDayCollect_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_IsLastDayCollect.Checked != true)
        //    {
        //        tne_CollectSchedule.Enabled = true;
        //    }
        //    else
        //    {
        //        tne_CollectSchedule.Value = 99;
        //        tne_CollectSchedule.Text = "";
        //        tne_CollectSchedule.Enabled = false;
        //    }

        //}
        // 2008.11.11 30413 犬飼 未使用メソッド削除 <<<<<<END

        /// <summary>
        /// 金種情報マスタ処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: 金種情報マスタを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008/11/11</br>
        /// </remarks>
        private void GetMoneyKind(out string errMsg)
        {
            SortedList retList = new SortedList();
            errMsg = string.Empty;

            int status = this._collectPlanAcs.SearchMoneyKind(0, out retList, out errMsg);
            if (status == 0)
            {
                this._moneyKindDic = new Dictionary<int, MoneyKind>();

                int listIndex = 1;
                foreach (DictionaryEntry de in retList)
                {
                    // 金種辞書に追加
                    this._moneyKindDic.Add(((MoneyKind)de.Value).MoneyKindCode, (MoneyKind)de.Value);
                    listIndex++;
                }
                return;
            }

            this._moneyKindDic = new Dictionary<int, MoneyKind>();
        }

        /// <summary>
        /// 入金設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入金設定マスタを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008/11/11</br>
        /// </remarks>
        private void GetDepositSet()
        {
            int status;
            int listIndex = 1;
            DepositSt depositSt = new DepositSt();

            status = this._depositStAcs.Read(out depositSt, this._enterpriseCode, 0);
            if (status == 0)
            {
                this._dicDepositStKind = new Dictionary<int, string>();

                if ((depositSt.DepositStKindCd1 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd1)))
                {
                    // 入金設定金種コード１の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd1, this._moneyKindDic[depositSt.DepositStKindCd1].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd1);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd2 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd2)))
                {
                    // 入金設定金種コード２の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd2, this._moneyKindDic[depositSt.DepositStKindCd2].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd2);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd3 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd3)))
                {
                    // 入金設定金種コード３の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd3, this._moneyKindDic[depositSt.DepositStKindCd3].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd3);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd4 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd4)))
                {
                    // 入金設定金種コード４の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd4, this._moneyKindDic[depositSt.DepositStKindCd4].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd4);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd5 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd5)))
                {
                    // 入金設定金種コード５の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd5, this._moneyKindDic[depositSt.DepositStKindCd5].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd5);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd6 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd6)))
                {
                    // 入金設定金種コード６の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd6, this._moneyKindDic[depositSt.DepositStKindCd6].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd6);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd7 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd7)))
                {
                    // 入金設定金種コード７の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd7, this._moneyKindDic[depositSt.DepositStKindCd7].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd7);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd8 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd8)))
                {
                    // 入金設定金種コード８の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd8, this._moneyKindDic[depositSt.DepositStKindCd8].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd8);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd9 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd9)))
                {
                    // 入金設定金種コード９の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd9, this._moneyKindDic[depositSt.DepositStKindCd9].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd9);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd10 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd10)))
                {
                    // 入金設定金種コード１０の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd10, this._moneyKindDic[depositSt.DepositStKindCd10].MoneyKindName.Trim());
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd10);
                    listIndex++;
                }

                return;
            }

            this._dicDepositStKind = new Dictionary<int, string>();
            this._dicDepositStRowNo = new Dictionary<int, int>();
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 障害・改良対応8月リリース分</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date	    : 2010/08/05</br>
        /// <br>UpdateNote : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date	   : 2011/03/14</br>
        /// </remarks>
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
                        // UPD 2010/08/05------------------------------->>>>>
                        // 得意先(終了)→締日
                        //e.NextCtrl = this.tne_CAddUpUpdExecDate;
                        e.NextCtrl = this.tce_CAddUpUpdExecDate;
                        // UPD 2010/08/05-------------------------------<<<<<
                    }
                    //-----ADD 2010/09/10---------->>>>>
                    else if (e.PrevCtrl == this.tce_CollectSchedule)
                    {
                        // 回収日→回収条件
                        e.NextCtrl = this.clb_CollectCond;
                        this.clb_CollectCond.SelectedIndex = 0;
                    }
                    else if (e.PrevCtrl == this.clb_CollectCond)
                    {
                        // 回収日→回収条件
                        e.NextCtrl = this.tce_PrintDiv;
                        this.clb_CollectCond.SelectedIndex = -1;
                    }
                    //-----ADD 2010/09/10----------<<<<<
                    //-----ADD 2011/03/14---------->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_NewPageType)
                    {
                       
                        e.NextCtrl = this.tComboEditor_PrintBlLi;
           
                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintBlLi)
                    {
                        
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                   
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                        
                        //e.NextCtrl = this.tce_SortOrderDiv;  // DEL 2012/05/22 gezh Redmine#29880
                        e.NextCtrl = this.tComboEditor_CustomerNamePrint;  // ADD 2012/05/22 gezh Redmine#29880

                    } 
                    // ADD 2012/05/22 gezh Redmine#29880 --------------------------------->>>>>
                    else if (e.NextCtrl == this.tComboEditor_CustomerNamePrint)
                    {
                        e.NextCtrl = this.tce_SortOrderDiv;
                    }
                    // ADD 2012/05/22 gezh Redmine#29880 ---------------------------------<<<<<
                    //-----ADD 2011/03/14----------<<<<<
                }
                if (e.Key == Keys.Down)
                { 
                    if (e.PrevCtrl == this.tce_CollectSchedule)
                    {
                        // 回収日→回収条件
                        e.NextCtrl = this.clb_CollectCond;
                        this.clb_CollectCond.SelectedIndex = 0;
                    }

                }
                if (e.Key == Keys.Up)
                {
                    if (e.PrevCtrl == this.tce_PrintDiv)
                    {
                        // 回収日→回収条件
                        e.NextCtrl = this.clb_CollectCond;
                        this.clb_CollectCond.SelectedIndex = 0;
                    }

                }
            }
            else
            {
                // SHIFTキー押下
                //-----ADD 2010/09/10---------->>>>>
                //if (e.Key == Keys.Tab)
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                //-----ADD 2010/09/10----------<<<<<
                    // UPD 2010/08/05------------------------------->>>>>
                    //if (e.PrevCtrl == this.tne_CAddUpUpdExecDate)
                    if (e.PrevCtrl == this.tce_CAddUpUpdExecDate)
                    // UPD 2010/08/05-------------------------------<<<<<
                    {
                        // 締日→得意先(終了)
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
                    //-----ADD 2010/09/10---------->>>>>
                    else if (e.PrevCtrl == this.tce_PrintDiv)
                    {
                        // 回収日→回収条件
                        e.NextCtrl = this.clb_CollectCond;
                        this.clb_CollectCond.SelectedIndex = 0;
                    }
                    else if (e.PrevCtrl == this.clb_CollectCond)
                    {
                        // 回収日→回収条件
                        e.NextCtrl = this.tce_CollectSchedule;
                        this.clb_CollectCond.SelectedIndex = -1;
                    }
                    //-----ADD 2010/09/10----------<<<<<

                    //-----ADD 2011/03/14---------->>>>>
                    else if (e.PrevCtrl == this.tce_SortOrderDiv)
                    {
                        
                        //e.NextCtrl = this.tComboEditor_LineMaSqOfCh;  // DEL 2012/05/22 gezh Redmine#29880
                        e.NextCtrl = this.tComboEditor_CustomerNamePrint;  // ADD 2012/05/22 gezh Redmine#29880

                    }
                    // ADD 2012/05/22 gezh Redmine#29880 --------------------------------->>>>>
                    //else if (e.NextCtrl == this.tComboEditor_CustomerNamePrint)  // DEL 2012/05/22 gezh Redmine#29880 
                    else if (e.PrevCtrl == this.tComboEditor_CustomerNamePrint)  // ADD 2012/05/22 gezh Redmine#29880
                    {
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                    }
                    // ADD 2012/05/22 gezh Redmine#29880 ---------------------------------<<<<<
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                   
                        e.NextCtrl = this.tComboEditor_PrintBlLi;

                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintBlLi)
                    {

                        e.NextCtrl = this.tComboEditor_NewPageType;

                    }
                    //-----ADD 2011/03/14----------<<<<<

                }
            }
        }
        private void clb_CollectCond_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}