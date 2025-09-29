//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入金確認表
// プログラム概要   : 入金確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 久保 将太
// 作 成 日  2007/03/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/04  修正内容 : 品管障害対応(管理No.8032) 金種選択コンポーネントをUltraTreeからCheckedListBoxに変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/11/14  修正内容 : DC.NS対応（「入金一覧表」⇒「入金確認表」に変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/01/30  修正内容 : DC.NS対応（不具合修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 修 正 日  2008/02/26  修正内容 : DC.NS対応 共通修正(日付チェック、０埋め対応)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/03/07  修正内容 : DC.NS対応 共通修正DC.NS対応（日付表示修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 修 正 日  2008/07/09  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/06  修正内容 : 障害対応13095
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13095(再修正)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/11/14  修正内容 : 2013/01/16配信分、Redmine#33271
//                                  印字制御の区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 董桂鈺
// 作 成 日  2012/12/25  修正内容 : 2013/01/16配信分、Redmine#33271
//                                  帳票の罫線印字（する・しない）を前回指定したも
//                                  のを記憶させることの設定を追加する
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/05  修正内容 : 2013/03/13配信分 Redmine #33796
//                                  改頁制御を追加する
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 入金確認表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金確認表UIフォームクラス</br>
    /// <br>Programmer : 22013 久保 将太</br>
    /// <br>Date       : 2007.03.06</br>
    /// <br>UpdateNote	: 2007.07.04 22013 kubo</br>
	///					:	・品管障害対応(管理No.8032) 金種選択コンポーネントをUltraTreeからCheckedListBoxに変更
    /// <br>UpdateNote	: 2007.11.14 980035 金沢 貞義</br>
    ///					:	・DC.NS対応（「入金一覧表」⇒「入金確認表」に変更）
    /// <br>UpdateNote  : 2008.01.30 980035 金沢 貞義</br>
    /// <br>                ・DC.NS対応（不具合修正）</br>
    /// <br>UpdateNote  : 2008.02.26 20081 疋田 勇人</br>
    /// <br>                ・DC.NS対応 共通修正(日付チェック、０埋め対応)</br>
    /// <br>UpdateNote  : 2008.03.07 980035 金沢 貞義</br>
    /// <br>                ・DC.NS対応（日付表示修正）</br>
    /// <br>UpdateNote  : 2008.07.09 30413 犬飼</br>
    /// <br>                ・PM.NS対応</br>
    /// <br>Update Note : 2009/04/06 30452 上野 俊治</br>
    /// <br>             ・障害対応13095</br>
    /// <br>Update Note : 2009/04/07 30452 上野 俊治</br>
    /// <br>             ・障害対応13095(再修正)</br>
    /// <br>Update Note : 2012/11/14 李亜博</br>
    ///	<br>			  Redmine#33271 印字制御の区分の追加</br> 
    /// <br>Update Note : 2012/12/25 董桂鈺</br>
    ///	<br>			  Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br> 
    /// <br>UpdateNote 　: 2013/01/05 zhuhh</br>
    /// <br>管理番号     : 10806793-00 2013/03/13配信分</br>
    /// <br>           　: redmine #33796 改頁制御を追加する</br>
    /// </remarks>
	public partial class MAHNB02010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
        /// 入金確認表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入金確認表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.06</br>
        /// <br>Update Note: 2012/12/25 董桂鈺</br>
        ///	<br>			  Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br> 
        /// <br>UpdateNote 　: 2013/01/05 zhuhh</br>
        /// <br>管理番号     : 10806793-00 2013/03/13配信分</br>
        /// <br>           　: redmine #33796 改頁制御を追加する</br>
		/// <br></br>
		/// </remarks>
		public MAHNB02010UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 入金確認表アクセスクラス
			this._depositMainAcs		= new DepositMainAcs();
            
            // 2008.07.09 30413 犬飼 アクセスクラスの追加 >>>>>>START
            // 入金設定マスタアクセスクラス
            this._depositStAcs = new DepositStAcs();

            this._dicDepositStKind = new Dictionary<int, string>();
            this._dicDepositStRowNo = new Dictionary<int, int>();
            // 2008.07.09 30413 犬飼 アクセスクラスの追加 <<<<<<END
        
            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();  // 2008.02.26 add

			#region // 2007.07.04 kubo del
			//// 金種設定中フラグ
			//this._isDepositKindSetting	= false;
			#endregion

            // 2008.07.23 30413 犬飼 未使用プロパティの削除 >>>>>>START
            //// 初期化中フラグ
            //this._isFirstSetting		= true;
            // 2008.07.23 30413 犬飼 未使用プロパティの削除 <<<<<<END

            //---ADD 董桂鈺 2012/12/25 for Redmine#33271-------------->>>>>
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tce_LineMaSqOfChDiv);        // 罫線印字
            ctrlList.Add(this.tComboEditor_NewPageType);   // 改頁　// ADD zhuhh 2013/01/05 for Redmine #33796　
            uiMemInput1.TargetControls = ctrlList;
            //---ADD 董桂鈺 2012/12/25 for Redmine#33271--------------<<<<<
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
        // 入金確認表アクセスクラス
		private DepositMainAcs _depositMainAcs;

        // 2008.07.09 30413 犬飼 入金設定マスタ取得プロパティの追加 >>>>>>START
        // 入金設定マスタアクセスクラス
        private DepositStAcs _depositStAcs;

        // 入金設定内訳リスト
        private Dictionary<Int32, String> _dicDepositStKind;
        // 入金設定行番号リスト
        private Dictionary<Int32, Int32> _dicDepositStRowNo;
        // 2008.07.09 30413 犬飼 入金設定マスタ取得プロパティの追加 <<<<<<END
        
		// 起動パラメータ(未使用)
		// private readonly int _startParam = 0;
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		#region // 2007.07.04 kubo del
		//// 金種設定中フラグ
		//private bool _isDepositKindSetting;
		#endregion

        // 2008.07.23 30413 犬飼 未使用プロパティの削除 >>>>>>START
        //// 初期化中フラグ
        //private bool _isFirstSetting;
        // 2008.07.23 30413 犬飼 未使用プロパティの削除 <<<<<<END
        
		// 得意先ガイド用
		private string _customerTag = "";

        // 2008.07.23 30413 犬飼 担当者ガイド不要のため削除 >>>>>>START
        //// 担当者ガイド
        //private EmployeeAcs _employeeAcs;
        // 2008.07.23 30413 犬飼 担当者ガイド不要のため削除 <<<<<<END
        
        // 日付取得部品
        private DateGetAcs _dateGet;   // 2008.02.26 add

		// 2007.07.04 kubo add ---------------->
		// 金種辞書
		/// <summary> 金種辞書(Key:CheckedListのindex, Value:MoneyKindクラス) </summary>
		private Dictionary<int, MoneyKind> _moneyKindDic = new Dictionary<int,MoneyKind>();
		// 2007.07.04 kubo add <----------------
		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID			= "MAHNB02010UA";
		// プログラムID
		private const string ct_PGID			= "MAHNB02010U";
		// 帳票名称
        // 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
        //private const string ct_PrintName       = "入金一覧表";
        private const string ct_PrintName       = "入金確認表";
        // 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<
        // 帳票キー	
        private const string ct_PrintKey		= "077369c7-6a45-4b34-a29e-1e0dbfe16baf";
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
			DepositMainCndtn extrInfo = new DepositMainCndtn();

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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// <br>Update Note : 2012/11/14 李亜博</br>
        ///	<br>			  Redmine#33271 印字制御の区分の追加</br>
        /// <br>UpdateNote 　: 2013/01/05 zhuhh</br>
        /// <br>管理番号     : 10806793-00 2013/03/13配信分</br>
        /// <br>           　: redmine #33796 改頁制御を追加する</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
				// 入金計上日
                // 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
                //this.tde_St_AddUpADate.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_Ed_AddUpADate.SetDateTime( TDateTime.GetSFDateNow() );
                //// 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                ////this.tde_St_CreateDate.SetDateTime(TDateTime.GetSFDateNow());
                ////this.tde_Ed_CreateDate.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_St_CreateDate.SetDateTime(System.DateTime.MinValue);
                //this.tde_Ed_CreateDate.SetDateTime(System.DateTime.MinValue);
                //// 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

                // 2008.07.09 30413 犬飼 入金日と入力日の初期設定変更 >>>>>>START
                //this.tde_St_CreateDate.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_Ed_CreateDate.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_St_AddUpADate.SetDateTime(System.DateTime.MinValue);
                //this.tde_Ed_AddUpADate.SetDateTime(System.DateTime.MinValue);
                // 入金日
                this.tde_St_AddUpADate.SetDateTime(TDateTime.GetSFDateNow());
                this.tde_Ed_AddUpADate.SetDateTime(TDateTime.GetSFDateNow());
                // 入力日
                this.tde_St_CreateDate.SetDateTime(System.DateTime.MinValue);
                this.tde_Ed_CreateDate.SetDateTime(System.DateTime.MinValue);
                // 2008.07.09 30413 犬飼 入金日と入力日の初期設定変更 <<<<<<END
                
                // 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<

                // 2008.07.23 30413 犬飼 小計区分ごと改ページ区分の削除 >>>>>>START
                //// 小計区分ごと改ページ区分
                //this.uce_ChangePageDiv.Checked = false;
                // 2008.07.23 30413 犬飼 小計区分ごと改ページ区分の削除 <<<<<<END

				// 得意先コード
                // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
                //this.tne_St_CustomerCode.SetInt(0);
				//this.tne_Ed_CustomerCode.SetInt( 999999999 );
                this.tNedit_CustomerCode_St.Clear();
                this.tNedit_CustomerCode_Ed.Clear();
                // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<

                // 2008.07.23 30413 犬飼 得意先カナと担当者コードの削除 >>>>>>START
                //// 得意先カナ
                //this.te_St_CustomerKana.DataText = "";
                //this.te_Ed_CustomerKana.DataText = "";
                //// 担当者コード
                //this.te_St_EmployeeCode.DataText = "";
                //this.te_Ed_EmployeeCode.DataText = "";
                // 2008.07.23 30413 犬飼 得意先カナと担当者コードの削除 <<<<<<END
                
                // 入金番号
                // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
                //this.tne_St_DepositSlipNo.SetInt(0);
				//this.tne_Ed_DepositSlipNo.SetInt( 999999999 );
                this.tNedit_DepositSlipNo_St.Clear();
                this.tNedit_DepositSlipNo_Ed.Clear();
                // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<

                // 2008.07.23 30413 犬飼 担当者区分の削除 >>>>>>START
                //// 担当者区分
                //this.InitializeEmployeeKindDiv();
                // 2008.07.23 30413 犬飼 担当者区分の削除 <<<<<<END
                
                // 入金区分
				this.InitializeDepositCd();
                // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
                //// 個人法人区分
				//this.InitializeCorporateDivCode();
                //// クレジットローン区分
				//this.InitializeCreditOrLoanCd();
                // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
                // 引当状態区分
				this.InitializeAllowanceDiv();
                // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
                //罫線印字区分
                this.tce_LineMaSqOfChDiv.SelectedIndex = 0;
                // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<
                // ----- ADD zhuhh 2013/01/05 for Redmine #33796 ----->>>>>
                //改頁
                this.tComboEditor_NewPageType.Value = 0;
                // ----- ADD zhuhh 2013/01/05 for Redmine #33796 -----<<<<<

			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

        // 2008.07.23 30413 犬飼 不要メソッドの削除 >>>>>>START
        #region ◎ 小計区分初期化処理
        ///// <summary>
        ///// 小計区分初期化処理
        ///// </summary>
        ///// <param name="selIndex">初期表示インデックス</param>
        ///// <remarks>
        ///// <br>Note		: 小計区分の初期化を行う</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.06</br>
        ///// </remarks>
        //private void InitializeSumDiv( out int selIndex )
        //{
        //    // 小計区分
        //    this.tce_SumDiv.Items.Clear();
        //    // 日付
        //    this.tce_SumDiv.Items.Add( DepositMainCndtn.SumDivState.Day				, DepositMainCndtn.ct_SumDiv_Day );
        //    // 得意先
        //    this.tce_SumDiv.Items.Add( DepositMainCndtn.SumDivState.Customer		, DepositMainCndtn.ct_SumDiv_Customer );
        //    // 金種
        //    this.tce_SumDiv.Items.Add(DepositMainCndtn.SumDivState.DepositKind, DepositMainCndtn.ct_SumDiv_DepositKind);
        //    // 入金伝票番号
        //    this.tce_SumDiv.Items.Add( DepositMainCndtn.SumDivState.DepositSlipNo	, DepositMainCndtn.ct_SumDiv_DepositSlipNo );

        //    this.tce_SumDiv.MaxDropDownItems = this.tce_SumDiv.Items.Count;
        //    this.tce_SumDiv.SelectedIndex = -1;
        //    selIndex = 0;

        //}
		#endregion
        // 2008.07.23 30413 犬飼 不要メソッドの削除 <<<<<<END
        
		#region ◎ 出力順初期化処理
		/// <summary>
		/// 出力順初期化処理
		/// </summary>
        /// <remarks>
        /// <br>Note		: 出力順の初期化を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
		private void InitializeSortOrderDiv()
		{
			// 出力順
			this.tce_SortOrderDiv.Items.Clear();

            // 2008.07.09 30413 犬飼 出力順の項目追加 >>>>>>START
            // 入金日順
            this.tce_SortOrderDiv.Items.Add(DepositMainCndtn.SortOrderDivState.AddUpDate, DepositMainCndtn.ct_SortOrderDiv_AddUpDate);
            // 入力日順
            this.tce_SortOrderDiv.Items.Add(DepositMainCndtn.SortOrderDivState.CreateDate, DepositMainCndtn.ct_SortOrderDiv_CreateDate);
            // 伝票番号順
            this.tce_SortOrderDiv.Items.Add(DepositMainCndtn.SortOrderDivState.DepositSlipNo, DepositMainCndtn.ct_SortOrderDiv_DepositSlipNo);
            // 2008.07.09 30413 犬飼 出力順の項目追加 <<<<<<END

            // 2008.07.23 30413 犬飼 既存の出力順を削除 >>>>>>START
            //// 得意先コード
            //this.tce_SortOrderDiv.Items.Add( DepositMainCndtn.SortOrderDivState.CustomerCode	, DepositMainCndtn.ct_SortOrderDiv_CustomerCode );
            //// 得意先カナ
            //this.tce_SortOrderDiv.Items.Add( DepositMainCndtn.SortOrderDivState.CustomerKane	, DepositMainCndtn.ct_SortOrderDiv_CustomerKane );
            //// 担当者コード
            //this.tce_SortOrderDiv.Items.Add( DepositMainCndtn.SortOrderDivState.EmployeeCode , DepositMainCndtn.ct_SortOrderDiv_EmployeeCode );
            // 2008.07.23 30413 犬飼 既存の出力順を削除 <<<<<<END
            
            this.tce_SortOrderDiv.MaxDropDownItems = this.tce_SortOrderDiv.Items.Count;
			this.tce_SortOrderDiv.SelectedIndex = 0;
		}
		#endregion

        // 2008.07.23 30413 犬飼 不要メソッドの削除 >>>>>>START
        #region ◎ 担当者区分初期化処理
        ///// <summary>
        ///// 担当者区分初期化処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: 担当者区分の初期化を行う</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.06</br>
        ///// </remarks>
        //private void InitializeEmployeeKindDiv()
        //{
        //    // 担当者区分
        //    this.tce_EmployeeKindDiv.Items.Clear();
        //    // 得意先担当者
        //    this.tce_EmployeeKindDiv.Items.Add( DepositMainCndtn.EmployeeKindDivState.Customer		, DepositMainCndtn.ct_EmployeeKindDiv_Customer );
        //    // 集金担当者
        //    this.tce_EmployeeKindDiv.Items.Add( DepositMainCndtn.EmployeeKindDivState.CollectMoney	, DepositMainCndtn.ct_EmployeeKindDiv_CollectMoney );
        //    // 入金担当者
        //    this.tce_EmployeeKindDiv.Items.Add( DepositMainCndtn.EmployeeKindDivState.Deposit		, DepositMainCndtn.ct_EmployeeKindDiv_Deposit );
        //    // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
        //    // 入金入力担当者
        //    this.tce_EmployeeKindDiv.Items.Add( DepositMainCndtn.EmployeeKindDivState.DepositInput  , DepositMainCndtn.ct_EmployeeKindDiv_DepositInput );
        //    // 2008.01.30 追加 <<<<<<<<<<<<<<<<<<<<

        //    this.tce_EmployeeKindDiv.MaxDropDownItems = this.tce_EmployeeKindDiv.Items.Count;
        //    this.tce_EmployeeKindDiv.SelectedIndex = 0;
        //}
		#endregion
        // 2008.07.23 30413 犬飼 不要メソッドの削除 <<<<<<END
        
        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 個人法人区分初期化処理
		///// <summary>
		///// 個人法人区分初期化処理
		///// </summary>
        ///// <remarks>
        ///// <br>Note		: 個人法人区分の初期化を行う</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.06</br>
        ///// </remarks>
		//private void InitializeCorporateDivCode()
		//{
		//	this.uce_CorpDiv_Personal.Checked		= true;		// 個人
		//	this.uce_CorpDiv_Juridical.Checked		= true;		// 法人
		//	this.uce_CorpDiv_BigJuridical.Checked	= true;		// 大口法人
		//	this.uce_CorpDiv_Supplier.Checked		= true;		// 業者
		//	this.uce_CorpDiv_Employee.Checked		= true;		// 社員
		//}
		#endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

		#region ◎ 入金区分初期化処理
		/// <summary>
		/// 入金区分初期化処理
		/// </summary>
        /// <remarks>
        /// <br>Note		: 入金区分の初期化を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
		private void InitializeDepositCd()
		{
			// 入金区分
			this.tce_DepositCd.Items.Clear();
            // 2008.07.23 30413 犬飼 預り全てのKeyを変更 >>>>>>START
            // 全て
            this.tce_DepositCd.Items.Add(DepositMainCndtn.DepositCdState.All, DepositMainCndtn.ct_All_Name);
            // 2008.07.23 30413 犬飼 預り全てのKeyを変更 <<<<<<END
            // 通常入金
			this.tce_DepositCd.Items.Add( DepositMainCndtn.DepositCdState.Nomal	, DepositMainCndtn.ct_DepositCd_Nomal );
            // 2008.07.09 30413 犬飼 預り金入金の削除 >>>>>>START
            //// 預り金入金
            //this.tce_DepositCd.Items.Add( DepositMainCndtn.DepositCdState.Keep	, DepositMainCndtn.ct_DepositCd_Keep );
            // 2008.07.09 30413 犬飼 預り金入金の削除 >>>>>>START
            // 自動入金
			this.tce_DepositCd.Items.Add( DepositMainCndtn.DepositCdState.Auto	, DepositMainCndtn.ct_DepositCd_Auto );

			this.tce_DepositCd.MaxDropDownItems = this.tce_DepositCd.Items.Count;
			this.tce_DepositCd.SelectedIndex = 0;
		}
		#endregion

		#region ◎ 入金金種ツリー初期化処理
		/// <summary>
		/// 入金金種初期化処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 入金金種の初期化を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
		private int InitializeDepositKind( out string errMsg)
		{
            // 2008.07.09 30413 犬飼 初期化処理を変更 >>>>>>START
            int status = 0;
            errMsg = string.Empty;

            this.clb_DepositKind.Items.Clear();
            // 全てノード追加
            this.clb_DepositKind.Items.Add(DepositMainCndtn.ct_All_Name, CheckState.Checked);

            for (int index = 1; index <= this._dicDepositStRowNo.Count; index++)
            {
                int rowNo = this._dicDepositStRowNo[index];
                // Listに追加
                clb_DepositKind.Items.Add(this._dicDepositStKind[rowNo].ToString(), CheckState.Unchecked);
            }


            //errMsg = string.Empty;

            //SortedList depositKindList = new SortedList();

            //// 金種マスタの取得(金額設定区分は「0:入金」に固定)
            //int status = this._depositMainAcs.SearchMoneyKind( 0, out depositKindList, out errMsg );

            //if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            //{
            //    // 2007.07.04 kubo add -------------------->
            //    if ( this._moneyKindDic == null )
            //        this._moneyKindDic = new Dictionary<int,MoneyKind>();

            //    this.clb_DepositKind.Items.Clear();
            //    // 全てノード追加
            //    this.clb_DepositKind.Items.Add(DepositMainCndtn.ct_All_Name, CheckState.Checked );

            //    // CheckListに金種を追加
            //    int listIndex = 1;
            //    foreach( DictionaryEntry de in depositKindList )
            //    {
            //        // Listに追加
            //        clb_DepositKind.Items.Add( ((MoneyKind)de.Value).MoneyKindName.TrimEnd(), CheckState.Unchecked );
                    
            //        // 金種辞書に追加
            //        this._moneyKindDic.Add( listIndex, (MoneyKind)de.Value );
            //        listIndex++;
            //    }
            //    // 2007.07.04 kubo add <--------------------

            //    #region // 2007.07.04 kubo del
            //    //// 「全て」ノード追加
            //    //ut_DepositKind.Nodes.Add( DepositMainCndtn.ct_All_Code.ToString(), DepositMainCndtn.ct_All_Name );

            //    //// UltraTreeに金種を追加
            //    //foreach(DictionaryEntry de in depositKindList)
            //    //{
            //    //    ut_DepositKind.Nodes.Add( ((MoneyKind)de.Value).MoneyKindCode.ToString(), ((MoneyKind)de.Value).MoneyKindName );
            //    //}

            //    //// 「全て」にチェックをつける
            //    //this.ut_DepositKind.Nodes[ DepositMainCndtn.ct_All_Code.ToString() ].CheckedState = CheckState.Checked;
            //    #endregion
            //}
            // 2008.07.09 30413 犬飼 初期化処理を変更 <<<<<<END
			return status;
		}

        /// <summary>
        /// 金種情報マスタ処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: 金種情報マスタを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008/07/09</br>
        /// </remarks>
        private void GetMoneyKind(out string errMsg)
        {
            //int status;
            //ArrayList retList = new ArrayList();
            SortedList retList = new SortedList();
            errMsg = string.Empty;

            //status = this._moneyKindAcs.SearchAll(out retList, this._enterpriseCode);
            int status = this._depositMainAcs.SearchMoneyKind(0, out retList, out errMsg);
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
                //foreach (MoneyKind moneyKind in retList)
                //{
                //    // 金額設定区分が「0:入金」を使用
                //    if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                //    {
                //        this._moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                //    }
                //}

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
        /// <br>Date		: 2008/07/09</br>
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
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd1, 1);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd1);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd2 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd2)))
                {
                    // 入金設定金種コード２の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd2, this._moneyKindDic[depositSt.DepositStKindCd2].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd2, 2);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd2);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd3 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd3)))
                {
                    // 入金設定金種コード３の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd3, this._moneyKindDic[depositSt.DepositStKindCd3].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd3, 3);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd3);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd4 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd4)))
                {
                    // 入金設定金種コード４の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd4, this._moneyKindDic[depositSt.DepositStKindCd4].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd4, 4);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd4);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd5 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd5)))
                {
                    // 入金設定金種コード５の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd5, this._moneyKindDic[depositSt.DepositStKindCd5].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd5, 5);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd5);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd6 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd6)))
                {
                    // 入金設定金種コード６の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd6, this._moneyKindDic[depositSt.DepositStKindCd6].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd6, 6);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd6);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd7 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd7)))
                {
                    // 入金設定金種コード７の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd7, this._moneyKindDic[depositSt.DepositStKindCd7].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd7, 7);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd7);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd8 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd8)))
                {
                    // 入金設定金種コード８の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd8, this._moneyKindDic[depositSt.DepositStKindCd8].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd8, 8);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd8);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd9 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd9)))
                {
                    // 入金設定金種コード９の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd9, this._moneyKindDic[depositSt.DepositStKindCd9].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd9, 9);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd9);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd10 != 0) &&
                    (this._moneyKindDic.ContainsKey(depositSt.DepositStKindCd10)))
                {
                    // 入金設定金種コード１０の追加
                    this._dicDepositStKind.Add(depositSt.DepositStKindCd10, this._moneyKindDic[depositSt.DepositStKindCd10].MoneyKindName.Trim());
                    //this._dicDepositStRowNo.Add(depositSt.DepositStKindCd10, 10);
                    this._dicDepositStRowNo.Add(listIndex, depositSt.DepositStKindCd10);
                    listIndex++;
                }
                
                return;
            }

            this._dicDepositStKind = new Dictionary<int, string>();
            this._dicDepositStRowNo = new Dictionary<int, int>();
        }

		#endregion

        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ クレジットローン区分初期化処理
		///// <summary>
		///// クレジットローン区分初期化処理
		///// </summary>
        ///// <remarks>
        ///// <br>Note		: クレジットローン区分の初期化を行う</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.06</br>
        ///// </remarks>
		//private void InitializeCreditOrLoanCd()
		//{
		//	// クレジットローン区分
		//	this.tce_CreditOrLoanCd.Items.Clear();
		//	// 全て
		//	this.tce_CreditOrLoanCd.Items.Add( DepositMainCndtn.CreditOrLoanCdState.All		, DepositMainCndtn.ct_All_Name );
		//	// クレジット
        //	this.tce_CreditOrLoanCd.Items.Add( DepositMainCndtn.CreditOrLoanCdState.Credit	, DepositMainCndtn.ct_CreditOrLoanCd_Credit );
        //	// ローン
        //	this.tce_CreditOrLoanCd.Items.Add( DepositMainCndtn.CreditOrLoanCdState.Loan	, DepositMainCndtn.ct_CreditOrLoanCd_Loan );
        //
        //	this.tce_CreditOrLoanCd.MaxDropDownItems = this.tce_CreditOrLoanCd.Items.Count;
        //	this.tce_CreditOrLoanCd.SelectedIndex = 0;
        //}
        #endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

		#region ◎ 引当状態区分初期化処理
		/// <summary>
		/// 引当状態区分初期化処理
		/// </summary>
        /// <remarks>
        /// <br>Note		: 引当状態区分の初期化を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
		private void InitializeAllowanceDiv()
		{
			// 引当状態区分
			this.tce_AllowanceDiv.Items.Clear();
			// 全て
			this.tce_AllowanceDiv.Items.Add( DepositMainCndtn.AllowanceDivState.All		, DepositMainCndtn.ct_All_Name );
			// 引当済
			this.tce_AllowanceDiv.Items.Add( DepositMainCndtn.AllowanceDivState.Ending	, DepositMainCndtn.ct_Allowance_Ending );
			// 一部引当
			this.tce_AllowanceDiv.Items.Add( DepositMainCndtn.AllowanceDivState.Part	, DepositMainCndtn.ct_Allowance_Part);
			// 未引当
			this.tce_AllowanceDiv.Items.Add( DepositMainCndtn.AllowanceDivState.Still	, DepositMainCndtn.ct_Allowance_Still );

			this.tce_AllowanceDiv.MaxDropDownItems = this.tce_AllowanceDiv.Items.Count;
			this.tce_AllowanceDiv.SelectedIndex = 0;
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

			const string ct_InputError = "の入力が不正です";
            //const string ct_NoInput	   = "を入力して下さい";                                    // 2008.03.07 削除
			const string ct_RangeError = "の範囲指定に誤りがあります";
            // 2008.07.14 30413 犬飼 設定範囲を３ヶ月以内に変更 >>>>>>START
            //const string ct_RangeError1 = "の範囲指定に誤りがあります(１ヶ月以内で設定して下さい)"; // 2008.02.26 add
            //const string ct_RangeError1 = "の範囲指定に誤りがあります(３ヶ月以内で設定して下さい)"; // DEL 2009/04/06
            // 2008.07.14 30413 犬飼 設定範囲を３ヶ月以内に変更 <<<<<<END
            
            // 2008.02.26 upd start ----------------------------------------->>
            //// 開始日のチェック
            //if( !this.DateEditInputCheck( this.tde_St_AddUpADate, false ) )
            //{
            //    errMessage		= string.Format( "開始日{0}", ct_InputError );
            //    errComponent	= this.tde_St_AddUpADate;
            //    status			= false;
            //}
            //else if ( this.tde_St_AddUpADate.GetDateTime() == DateTime.MinValue )
            //{
            //    errMessage		= string.Format( "開始日{0}", ct_NoInput );
            //    errComponent	= this.tde_St_AddUpADate;
            //    status			= false;
            //}
            //// 終了日のチェック
            //else if( !this.DateEditInputCheck( this.tde_Ed_AddUpADate, false ) )
            //{
            //    errMessage		= string.Format( "終了日{0}", ct_InputError );
            //    errComponent	= this.tde_Ed_AddUpADate;
            //    status			= false;
            //}
            //else if ( this.tde_Ed_AddUpADate.GetDateTime() == DateTime.MinValue )
            //{
            //    errMessage		= string.Format( "終了日{0}", ct_NoInput );
            //    errComponent	= this.tde_Ed_AddUpADate;
            //    status			= false;
            //}
            //// 日付の範囲をチェック(開始日 > 終了日 → NG)
            //else if( this.tde_St_AddUpADate.GetLongDate() > this.tde_Ed_AddUpADate.GetLongDate() )
            //{
            //    errMessage		= string.Format( "日付{0}", ct_RangeError );
            //    errComponent	= this.tde_St_AddUpADate;
            //    status			= false;
            //}
            //// 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
            //// 開始日のチェック
            //else if (!this.DateEditInputCheck(this.tde_St_CreateDate, true))
            //{
            //    errMessage = string.Format("開始日{0}", ct_InputError);
            //    errComponent = this.tde_St_CreateDate;
            //    status = false;
            //}
            //// 終了日のチェック
            //else if (!this.DateEditInputCheck(this.tde_Ed_CreateDate, true))
            //{
            //    errMessage = string.Format("終了日{0}", ct_InputError);
            //    errComponent = this.tde_Ed_CreateDate;
            //    status = false;
            //}
            //// 日付の範囲をチェック(開始日 > 終了日 → NG)
            //else if ((this.tde_St_CreateDate.GetDateTime() != DateTime.MinValue) &&
            //         (this.tde_Ed_CreateDate.GetDateTime() != DateTime.MinValue) &&
            //         (this.tde_St_CreateDate.GetLongDate() > this.tde_Ed_CreateDate.GetLongDate()))
            //{
            //    errMessage = string.Format("日付{0}", ct_RangeError);
            //    errComponent = this.tde_St_CreateDate;
            //    status = false;
            //}
            //// 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
            DateGetAcs.CheckDateRangeResult cdrResult;
            // 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
            //// 入金計上日（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("入金計上開始日{0}", ct_InputError);
            //                errComponent = this.tde_St_AddUpADate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("入金計上開始日{0}", ct_InputError);
            //                errComponent = this.tde_St_AddUpADate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("入金計上終了日{0}", ct_InputError);
            //                errComponent = this.tde_Ed_AddUpADate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("入金計上終了日{0}", ct_InputError);
            //                errComponent = this.tde_Ed_AddUpADate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format("入金計上日{0}", ct_RangeError);
            //                errComponent = this.tde_St_AddUpADate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format("入金計上日{0}", ct_RangeError1);
            //                errComponent = this.tde_St_AddUpADate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //// 入力日（開始～終了）
            //else if (CallCheckDateRange(out cdrResult, ref tde_St_CreateDate, ref tde_Ed_CreateDate) == false)

            // 2008.07.14 30413 犬飼 チェックを入金日、入力日の順に変更 >>>>>>START
            //// 入力日（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref tde_St_CreateDate, ref tde_Ed_CreateDate) == false)
            //// 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("入力開始日{0}", ct_InputError);
            //                errComponent = this.tde_St_CreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("入力開始日{0}", ct_InputError);
            //                errComponent = this.tde_St_CreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("入力終了日{0}", ct_InputError);
            //                errComponent = this.tde_Ed_CreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("入力終了日{0}", ct_InputError);
            //                errComponent = this.tde_Ed_CreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format("入力日{0}", ct_RangeError);
            //                errComponent = this.tde_St_CreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format("入力日{0}", ct_RangeError1);
            //                errComponent = this.tde_St_CreateDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //// 2008.02.26 upd end -------------------------------------------<<
            //// 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
            //// 入金計上日（開始～終了）
            //else if (CallCheckDateRange2(out cdrResult, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("入金計上開始日{0}", ct_InputError);
            //                errComponent = this.tde_St_AddUpADate;
            //                status = false;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("入金計上終了日{0}", ct_InputError);
            //                errComponent = this.tde_Ed_AddUpADate;
            //                status = false;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format("入金計上日{0}", ct_RangeError);
            //                errComponent = this.tde_St_AddUpADate;
            //                status = false;
            //            }
            //            break;
            //    }
            //}

            // 2009.01.06 30413 犬飼 入力チェック処理を修正 >>>>>>START
            // 入金日（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate) == false) // DEL 2009/04/06
            if (CallCheckDateRange2(out cdrResult, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate) == false) // ADD 2009/04/06
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        //errMessage = string.Format("入金開始日{0}", ct_InputError); // DEL 2009/04/06
                    //        //errComponent = this.tde_St_AddUpADate; // DEL 2009/04/06
                    //        status = true; // ADD 2009/04/06
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("入金開始日{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpADate;
                            status = false; // ADD 2009/04/06
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        //errMessage = string.Format("入金終了日{0}", ct_InputError); // DEL 2009/04/06
                    //        //errComponent = this.tde_Ed_AddUpADate; // DEL 2009/04/06
                    //        status = true; // ADD 2009/04/06
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("入金終了日{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpADate;
                            status = false; // ADD 2009/04/06
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入金日{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpADate;
                            status = false; // ADD 2009/04/06
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        //errMessage = string.Format("入金日{0}", ct_RangeError1); // DEL 2009/04/06
                    //        //errComponent = this.tde_St_AddUpADate; // DEL 2009/04/06
                    //        status = true; // ADD 2009/04/06
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                //status = false; // DEL 2009/04/06
                return status;
            }
            // 入力日（開始～終了）
            //else if (CallCheckDateRange2(out cdrResult, ref tde_St_CreateDate, ref tde_Ed_CreateDate) == false)
            if (CallCheckDateRange2(out cdrResult, ref tde_St_CreateDate, ref tde_Ed_CreateDate) == false)
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //// ADD 2008/10/09 不具合対応[6361] ---------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        //errMessage = string.Format("入力開始日{0}", ct_InputError);
                    //        //errComponent = this.tde_St_CreateDate;
                    //        //status = false;
                    //        status = true;
                    //    }
                    //    break;
                    //// ADD 2008/10/09 不具合対応[6361] ----------<<<<<
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("入力開始日{0}", ct_InputError);
                            errComponent = this.tde_St_CreateDate;
                            status = false;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //// ADD 2008/10/09 不具合対応[6361] ---------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        //errMessage = string.Format("入力終了日{0}", ct_InputError);
                    //        //errComponent = this.tde_Ed_CreateDate;
                    //        //status = false;
                    //        status = true;
                    //    }
                    //    break;
                    //// ADD 2008/10/09 不具合対応[6361] ----------<<<<<
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("入力終了日{0}", ct_InputError);
                            errComponent = this.tde_Ed_CreateDate;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日{0}", ct_RangeError);
                            errComponent = this.tde_St_CreateDate;
                            status = false;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //// ADD 2008/10/09 不具合対応[6361] ---------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        //errMessage = string.Format("入力日{0}", ct_RangeError);
                    //        //errComponent = this.tde_St_CreateDate;
                    //        //status = false;
                    //        status = true;
                    //    }
                    //    break;
                    //// ADD 2008/10/09 不具合対応[6361] ----------<<<<<
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                //status = false;
            }
            else
            {
                status = true;
            }

            if (!status)
            {
                // 入力日チェックエラー
                return status;
            }
            else
            {
                // 入力日チェックOK
                status = false;
            }
            // 2008.07.14 30413 犬飼 チェックを入金日、入力日の順に変更 <<<<<<END

            // 2008.07.14 30413 犬飼 得意先コードのチェックを変更 >>>>>>START
            // 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<
   			// 得意先コード
			//else if ( this.tne_St_CustomerCode.GetInt() > this.tne_Ed_CustomerCode.GetInt() )
            //else if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
            //         (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                     (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
            // 2008.07.14 30413 犬飼 得意先コードのチェックを変更 <<<<<<END
            {
				errMessage		= string.Format( "得意先コード{0}", ct_RangeError );
				errComponent	= this.tNedit_CustomerCode_St;
				status			= false;
                return status;
			}

            // 2008.07.23 30413 犬飼 得意先カナと担当者コードの削除 >>>>>>START
            //// 得意先カナ
            //else if (
            //    ( this.te_St_CustomerKana.DataText.TrimEnd() != string.Empty ) && 
            //    ( this.te_Ed_CustomerKana.DataText.TrimEnd() != string.Empty )&&
            //    ( this.te_St_CustomerKana.DataText.TrimEnd().CompareTo( this.te_Ed_CustomerKana.DataText.TrimEnd() ) > 0 ) )
            //{
            //    errMessage		= string.Format( "得意先カナ{0}", ct_RangeError );
            //    errComponent	= this.te_St_CustomerKana;
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
            // 2008.07.23 30413 犬飼 担当者区分の削除 >>>>>>START
            
            // 2008.07.14 30413 犬飼 入金番号のチェックを変更 >>>>>>START
            // 入金番号
            //else if ( this.tne_St_DepositSlipNo.GetInt() > this.tne_Ed_DepositSlipNo.GetInt() )
            //else if ((this.tNedit_DepositSlipNo_Ed.GetInt() != 0) &&
            //         (this.tNedit_DepositSlipNo_St.GetInt() > this.tNedit_DepositSlipNo_Ed.GetInt()))
            if ((this.tNedit_DepositSlipNo_Ed.GetInt() != 0) &&
                     (this.tNedit_DepositSlipNo_St.GetInt() > this.tNedit_DepositSlipNo_Ed.GetInt()))
            // 2008.07.14 30413 犬飼 入金番号のチェックを変更 <<<<<<END
            {
				errMessage		= string.Format( "入金番号{0}", ct_RangeError );
				errComponent	= this.tNedit_DepositSlipNo_St;
				status			= false;
                return status;
			}
            // 入金金種
            //else if ( !CheckInputMoneyKind() )
            if (!CheckInputMoneyKind())
			{
				errMessage		= "対象金種を選択してください";
				errComponent	= this.clb_DepositKind;	// 2007.07.04 kubo add
				// errComponent	= this.ut_DepositKind;	// 2007.07.04 kubo del
				status			= false;
                return status;
			}
            // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 個人・法人区分
			//else if (
			//	!( ( this.uce_CorpDiv_Personal.Checked ) || ( this.uce_CorpDiv_Juridical.Checked ) ||
			//	( this.uce_CorpDiv_BigJuridical.Checked ) || ( this.uce_CorpDiv_Supplier.Checked ) ||
			//	( this.uce_CorpDiv_Employee.Checked)))
			//{
			//	errMessage		= "個人・法人区分を選択してください";
			//	errComponent	= this.uce_CorpDiv_Personal;
            //	status			= false;
            //}
            // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

            //return status;
            return true;
            // 2009.01.06 30413 犬飼 入力チェック処理を修正 <<<<<<END
        }
		#endregion

		#region ◎ 日付入力チェック処理
        // 2008.02.26 add start -------------------------------->>
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_Date"></param>
        /// <param name="tde_Ed_Date"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_Date, ref TDateEdit tde_Ed_Date)
        {
            // 2008.08.01 30413 犬飼 範囲を３ケ月に変更 >>>>>>START
            //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_Date, ref tde_Ed_Date, true, false);
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref tde_St_Date, ref tde_Ed_Date, false, false);
            // 2008.08.01 30413 犬飼 範囲を３ケ月に変更 <<<<<<END
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // 2008.02.26 add end ----------------------------------<<

        // 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 日付チェック処理呼び出し（未入力対象外）
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_Date"></param>
        /// <param name="tde_Ed_Date"></param>
        /// <returns></returns>
        private bool CallCheckDateRange2(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_Date, ref TDateEdit tde_Ed_Date)
        {
            // 2009.01.06 30413 犬飼 日付チェックを修正 >>>>>>START
            //cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            //if ((tde_St_Date.GetLongDate() != 0) && (tde_Ed_Date.GetLongDate() != 0))
            //{
            //    // 2008.08.01 30413 犬飼 範囲チェック無しに変更 >>>>>>START
            //    //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_Date, ref tde_Ed_Date, true);
            //    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_Date, ref tde_Ed_Date, false, false);
            //    // 2008.08.01 30413 犬飼 範囲チェック無しに変更 <<<<<<END
            //}
            //else
            //if (((tde_St_Date.GetLongDate() != 0) && (tde_Ed_Date.GetLongDate() == 0)) ||
            //    ((tde_St_Date.GetLongDate() == 0) && (tde_Ed_Date.GetLongDate() != 0)))
            //{
            //    TDateEdit stDate = new TDateEdit();
            //    TDateEdit edDate = new TDateEdit();
            //    if (tde_St_Date.GetLongDate() != 0)
            //    {
            //        stDate = tde_St_Date;
            //    }
            //    else
            //    {
            //        stDate.SetDateTime(DateTime.MinValue);
            //    }
            //    if (tde_Ed_Date.GetLongDate() != 0)
            //    {
            //        edDate = tde_Ed_Date;

            //        DateGetAcs.CheckDateResult cdrResult2 = _dateGet.CheckDate(ref tde_Ed_Date);
            //        if (cdrResult2 != DateGetAcs.CheckDateResult.OK)
            //        {
            //            cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput;
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        edDate.SetDateTime(DateTime.MaxValue);
            //    }
            //    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref stDate, ref edDate, true);
            //}
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_Date, ref tde_Ed_Date, true);
            // 2009.01.06 30413 犬飼 日付チェックを修正 <<<<<<END

            // --- ADD 2009/04/07 -------------------------------->>>>>
            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput
                || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<
            
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// 日付入力チェック処理
		/// </summary>
		/// <param name="targetDateEdit">チェック対象コントロール</param>
		/// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
		/// <returns>チェック結果(true/false)</returns>
		/// <remarks>
		/// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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

		#region ◎ 金種入力チェック処理
		/// <summary>
		/// 金種入力チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 金種の入力をチェック。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>	
		private bool CheckInputMoneyKind()
		{
			// 変数宣言
			bool checkStatus = false;

			// 2007.07.04 kubo add -------------------->
			if ( clb_DepositKind.CheckedItems.Count > 0 )
				checkStatus = true;
			// 2007.07.04 kubo add <--------------------

			#region // 2007.07.04 kubo del
			//foreach(UltraTreeNode checkNode in this.ut_DepositKind.Nodes)
			//{
			//    // チェックがついていたら戻り値用変数をTrueにしてforステートメントをBreakする。
			//    if (checkNode.CheckedState == CheckState.Checked)
			//    {
			//        checkStatus = true;
			//        break;
			//    }
			//}
			#endregion

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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// <br>Update Note : 2012/11/14 李亜博</br>
        ///	<br>			  Redmine#33271 印字制御の区分の追加</br>
        /// <br>UpdateNote 　: 2013/01/05 zhuhh</br>
        /// <br>管理番号     : 10806793-00 2013/03/13配信分</br>
        /// <br>           　: redmine #33796 改頁制御を追加する</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( DepositMainCndtn extraInfo )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 拠点オプション
				extraInfo.IsOptSection = this._isOptSection;
				// 企業コード
				extraInfo.EnterpriseCode = this._enterpriseCode;
				// 選択拠点
				extraInfo.DepositAddupSecCodeList = (string[])new ArrayList( this._selectedSectionList.Values ).ToArray( typeof ( string ) );
				// 入金計上日
				extraInfo.St_AddUpADate = this.tde_St_AddUpADate.GetDateTime();		// 開始
                // 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_AddupADate = this.tde_Ed_AddUpADate.GetDateTime();		// 終了
                if (this.tde_Ed_AddUpADate.GetDateTime() == DateTime.MinValue)
                {
                    extraInfo.Ed_AddupADate = DateTime.MaxValue;                    // 終了
                }
                else
                {
                    extraInfo.Ed_AddupADate = this.tde_Ed_AddUpADate.GetDateTime(); // 終了
                }
                // 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                // 入力日
                extraInfo.St_CreateDate = this.tde_St_CreateDate.GetDateTime();		// 開始
                extraInfo.Ed_CreateDate = this.tde_Ed_CreateDate.GetDateTime();		// 終了
                // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

                // 2008.07.23 30413 犬飼 小計区分の削除 >>>>>>START
                //// 小計区分
                //extraInfo.SumDiv = (DepositMainCndtn.SumDivState)this.tce_SumDiv.SelectedItem.DataValue;
                //// 小計毎改ページ区分
                //extraInfo.IsChangePageDiv = this.uce_ChangePageDiv.Checked;
                // 2008.07.23 30413 犬飼 小計区分の削除 <<<<<<END
                
                // 出力順
				extraInfo.SortOrderDiv = (DepositMainCndtn.SortOrderDivState)this.tce_SortOrderDiv.SelectedItem.DataValue;
				// 得意先コード
				extraInfo.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();				// 開始
                // 2008.07.14 30413 犬飼 終了は未入力時は最大値を設定しないように変更 >>>>>>START
                //// 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_CustomerCode = this.tne_Ed_CustomerCode.GetInt();				// 終了
                //if (this.tne_Ed_CustomerCode.GetInt() == 0)
                //{
                //    extraInfo.Ed_CustomerCode = 999999999;				                    // 終了
                //}
                //else
                //{
                //    extraInfo.Ed_CustomerCode = this.tne_Ed_CustomerCode.GetInt();	        // 終了
                //}
                //// 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
                extraInfo.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();	        // 終了
                // 2008.07.14 30413 犬飼 終了は未入力時は最大値を設定しないように変更 <<<<<<END

                // 2008.07.23 30413 犬飼 得意先カナと担当者区分、担当者コードの削除 >>>>>>START
                //// 得意先カナ
                //extraInfo.St_CustomerKana = this.te_St_CustomerKana.DataText.TrimEnd();		// 開始
                //extraInfo.Ed_CustomerKana = this.te_Ed_CustomerKana.DataText.TrimEnd();		// 終了
                //// 担当者区分
                //extraInfo.EmployeeKindDiv = (DepositMainCndtn.EmployeeKindDivState)this.tce_EmployeeKindDiv.SelectedItem.DataValue;
                //// 担当者コード
                //extraInfo.St_EmployeeCode = this.te_St_EmployeeCode.DataText.TrimEnd();		// 開始
                //extraInfo.Ed_EmployeeCode = this.te_Ed_EmployeeCode.DataText.TrimEnd();		// 終了
                // 2008.07.23 30413 犬飼 得意先カナと担当者区分、担当者コードの削除 <<<<<<END
                
                // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
                //// 個人法人区分
				//GetCorporateDivCode( extraInfo );
                // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
                // 入金番号
                extraInfo.St_DepositSlipNo = this.tNedit_DepositSlipNo_St.GetInt();		// 開始
                // 2008.07.14 30413 犬飼 終了は未入力時は最大値を設定しないように変更 >>>>>>START
                //// 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_DepositSlipNo = this.tne_Ed_DepositSlipNo.GetInt();		// 終了
                //if (this.tne_Ed_DepositSlipNo.GetInt() == 0)
                //{
                //    extraInfo.Ed_DepositSlipNo = 999999999;		                            // 終了
                //}
                //else
                //{
                //    extraInfo.Ed_DepositSlipNo = this.tne_Ed_DepositSlipNo.GetInt();		// 終了
                //}
                //// 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
                extraInfo.Ed_DepositSlipNo = this.tNedit_DepositSlipNo_Ed.GetInt();		// 終了
                // 2008.07.14 30413 犬飼 終了は未入力時は最大値を設定しないように変更 <<<<<<END

                // 入金区分
				extraInfo.DepositCd = (DepositMainCndtn.DepositCdState)this.tce_DepositCd.SelectedItem.DataValue;
				// 入金金種
				GetDepositKind( extraInfo );
                // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
                //// クレジットローン区分
				//extraInfo.CreditOrLoanCd = (DepositMainCndtn.CreditOrLoanCdState)this.tce_CreditOrLoanCd.SelectedItem.DataValue;
                // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
                // 引当状態
				extraInfo.AllowanceDiv = (DepositMainCndtn.AllowanceDivState)this.tce_AllowanceDiv.SelectedItem.DataValue;
                // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
                //罫線印字区分
                extraInfo.LineMaSqOfChDiv = (int)this.tce_LineMaSqOfChDiv.SelectedItem.DataValue;
                // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<
                // ----- ADD zhuhh 2013/01/05 for Redmine #33796 ----->>>>>
                //改頁区分
                extraInfo.NewPageType = (int)this.tComboEditor_NewPageType.Value;
                // ----- ADD zhuhh 2013/01/05 for Redmine #33796 -----<<<<<
			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
		#endregion

        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 個人法人区分取得処理
        ///// <summary>
        ///// 個人法人区分取得処理
        ///// </summary>
        ///// <param name="extrInfo">入金一覧表抽出条件クラス</param>
        ///// <remarks>
        ///// <br>Note		: 個人法人区分を取得する。</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.06</br>
        ///// </remarks>
		//private void GetCorporateDivCode( DepositMainCndtn extrInfo )
		//{
		//	// 個人法人区分
		//	// 個人
		//	if ( this.uce_CorpDiv_Personal.Checked )
		//	{
		//		extrInfo.CorporateDivCode.Add( DepositMainCndtn.CorporateDivCodeState.Personal, this.uce_CorpDiv_Personal.Text ); 
		//	}
		//	// 法人
		//	if ( this.uce_CorpDiv_Juridical.Checked )
		//	{
		//		extrInfo.CorporateDivCode.Add( DepositMainCndtn.CorporateDivCodeState.Juridical, this.uce_CorpDiv_Juridical.Text ); 
		//	}
		//	// 大口法人
		//	if ( this.uce_CorpDiv_BigJuridical.Checked )
		//	{
		//		extrInfo.CorporateDivCode.Add( DepositMainCndtn.CorporateDivCodeState.BigJuridical, this.uce_CorpDiv_BigJuridical.Text ); 
		//	}
		//	// 業者
		//	if ( this.uce_CorpDiv_Supplier.Checked )
		//	{
		//		extrInfo.CorporateDivCode.Add( DepositMainCndtn.CorporateDivCodeState.Supplier, this.uce_CorpDiv_Supplier.Text ); 
		//	}
		//	// 社員
		//	if ( this.uce_CorpDiv_Employee.Checked )
		//	{
		//		extrInfo.CorporateDivCode.Add( DepositMainCndtn.CorporateDivCodeState.Employee, this.uce_CorpDiv_Employee.Text ); 
		//	}
		//}
		#endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

		#region ◎ 入金金種取得処理
		/// <summary>
		/// 入金金種取得処理
		/// </summary>
        /// <param name="extrInfo">入金確認表抽出条件クラス</param>
        /// <remarks>
        /// <br>Note		: 入金金種を取得する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
		private void GetDepositKind( DepositMainCndtn extrInfo )
		{
			// HashTableのクリアー
			extrInfo.DepositKind.Clear();
            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
            ArrayList depositKindCode = new ArrayList();
            // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

			// 2007.07.04 kubo add ------------------------------------>
			// チェックされているアイテムの中に「全て」が存在するか
			if ( this.clb_DepositKind.CheckedItems.Contains( this.clb_DepositKind.Items[0] ) )
			{
			    // 全てが選択されているとき
			    extrInfo.DepositKind.Add(DepositMainCndtn.ct_All_Code, DepositMainCndtn.ct_All_Name);
            }
			else
			{
				// 「全て」がない場合
				int itemIndex = 0;
				MoneyKind moneyKind = new MoneyKind();
				foreach( object checkedItem in this.clb_DepositKind.CheckedItems )
				{
					itemIndex = this.clb_DepositKind.Items.IndexOf( checkedItem );
					moneyKind = null;

                    if (this._dicDepositStRowNo.ContainsKey(itemIndex))
                    {
                        int key = this._dicDepositStRowNo[itemIndex];
                        if (this._moneyKindDic.ContainsKey(key))
                        {
                            moneyKind = this._moneyKindDic[key];

                            if (moneyKind == null)
                                continue;
                            // Key=金種コード, Value=金種名称
                            extrInfo.DepositKind.Add(moneyKind.MoneyKindCode, moneyKind.MoneyKindName);
                            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                            depositKindCode.Add(moneyKind.MoneyKindCode);
                            // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

                        }
                    }

                    //if (this._moneyKindDic.ContainsKey(itemIndex))
                    //{
                    //    moneyKind = this._moneyKindDic[itemIndex];

                    //    if (moneyKind == null)
                    //        continue;
                    //    // Key=金種コード, Value=金種名称
                    //    extrInfo.DepositKind.Add(moneyKind.MoneyKindCode, moneyKind.MoneyKindName);
                    //    // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                    //    depositKindCode.Add(moneyKind.MoneyKindCode);
                    //    // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
                    //}
                }
			}
			// 2007.07.04 kubo add <------------------------------------

            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 全ての金種名称とチェックされている金種を取得
            int itemIndex2 = 0;
            bool chkFlg;
            MoneyKind moneyKind2 = new MoneyKind();
            extrInfo.DepositKindCode = new ArrayList();
            extrInfo.DepositKindName = new SortedList();
            foreach (object item in this.clb_DepositKind.Items)
            {
                itemIndex2 = this.clb_DepositKind.Items.IndexOf(item);
                if (itemIndex2 == 0) continue;
                moneyKind2 = null;
                // 2008.07.09 30413 犬飼 金種データ情報の取得方法を変更 >>>>>>START
                //moneyKind2 = this._moneyKindDic[itemIndex2];
                moneyKind2 = this._moneyKindDic[this._dicDepositStRowNo[itemIndex2]];
                // 2008.07.09 30413 犬飼 金種データ情報の取得方法を変更 <<<<<<END
                if (moneyKind2 == null) continue;

                extrInfo.DepositKindCode.Add(moneyKind2.MoneyKindCode);
                // Key=金種コード, Value=金種名称
                extrInfo.DepositKindName.Add(moneyKind2.MoneyKindCode, moneyKind2.MoneyKindName);
            }
			if ( !this.clb_DepositKind.CheckedItems.Contains( this.clb_DepositKind.Items[0] ) )
			{
                for (int ix = 0; ix < extrInfo.DepositKindCode.Count; ix++)
                {
                    chkFlg = false;
                    for (int ix2 = 0; ix2 < depositKindCode.Count; ix2++)
                    {
                        if ((int)extrInfo.DepositKindCode[ix] == (int)depositKindCode[ix2])
                        {
                            chkFlg = true;
                            break;
                        }
                    }
                    if (chkFlg == false)
                    {
                        extrInfo.DepositKindCode[ix] = -1;
                    }
                }
            }
            // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
            
            #region // 2007.07.04 kubo del
			//if ( this.ut_DepositKind.GetNodeByKey(DepositMainCndtn.ct_All_Code.ToString()).CheckedState == CheckState.Checked )
			//{
			//    // 全てが選択されているとき
			//    extrInfo.DepositKind.Add(DepositMainCndtn.ct_All_Code, DepositMainCndtn.ct_All_Name);
			//}
			//else
			//{
			//    // 金種が選択されているとき
			//    // チェックがついている金種のみ取得する
			//    foreach ( UltraTreeNode utn in this.ut_DepositKind.Nodes )
			//    {
			//        // 全てなら追加しない
			//        if ( utn.Key.CompareTo(DepositMainCndtn.ct_All_Code.ToString()) == 0 )
			//        {
			//            continue;
			//        }
			//        if ( utn.CheckedState == CheckState.Checked )
			//        {
			//            // チェックがついていたらｺｰﾄﾞ用HashTableに追加。
			//            // Key=金種コード, Value=金種名称
			//            extrInfo.DepositKind.Add( TStrConv.StrToIntDef( utn.Key, 0 ), utn.Text);
			//        }
			//    }
			//}
			#endregion
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
            // 2008.07.23 30413 犬飼 小計区分の削除 >>>>>>START
            //tce_SumDiv.Enabled = isSumDiv;				// 小計区分
			tce_SortOrderDiv.Enabled			= isSort;				// 印字順位
            //uce_ChangePageDiv.Enabled			= isChangePage;			// 小計区分ごと改ページ
			tce_AllowanceDiv.Enabled			= isAllowanceDiv;		// 引当状態
            // 2008.07.23 30413 犬飼 小計区分の削除 <<<<<<END
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
		/// <br>Programmer : 22013 kubo</br>
        /// <br>Date		: 2007.03.06</br>
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
		/// <br>Programmer : 22013 kubo</br>
        /// <br>Date		: 2007.03.06</br>
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
        #region ◆ MAHNB02010UA
        #region ◎ MAHNB02010UA_Load Event
        /// <summary>
        /// MAHNB02010UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
		private void MAHNB02010UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;
	
			// 初期化タイマー起動(金種などのリードが走るのでTimerで行う。)
			Initialize_Timer.Enabled = true;

			// 画面イメージ統一
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// 本来ならばここでツールバー設定イベントを走らせるが、Initial_Timerでマスタの取得を行っているので
			// 設定前に印刷ボタンを押されるとおそらく例外が発生すると考えられる。
			// なので、Timerでツールバー設定イベントを実行する。
			//ParentToolbarSettingEvent( this );

		}
		#endregion
        #endregion ◆ MAHNB02010UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
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

		#region ◆ tce_SumDiv
        // 2008.07.23 30413 犬飼 不要メソッドの削除 >>>>>>START
        #region ◎ ValueChanged Event
        ///// <summary>
        ///// ValueChanged Event
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note		: コントロールの値が変更されたときに発生する。</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.07</br>
        ///// </remarks>
        //private void tce_SumDiv_ValueChanged ( object sender, EventArgs e )
        //{
        //    if ( this._isFirstSetting ) return;	// 初期化中は実行しない

        //    // Enabledの制御を行う
        //    if ( (DepositMainCndtn.SumDivState)this.tce_SumDiv.SelectedItem.DataValue == DepositMainCndtn.SumDivState.DepositSlipNo )
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
		#endregion
        // 2008.07.23 30413 犬飼 不要メソッドの削除 <<<<<<END
        #endregion ◆ tce_SumDiv

        #region ◆ tne_St_CustomerCode
        #region ◎ Leave Event
        /// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.07</br>
        /// </remarks>
		private void tne_St_CustomerCode_Leave ( object sender, EventArgs e )
		{
			// 空白の場合は初期値をセット
			if ( ( (TNedit)sender ).DataText == string.Empty )
			{
                // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
				//( (TNedit)sender ).SetInt( 0 );
                ((TNedit)sender).Clear();
                // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.07</br>
        /// </remarks>
		private void tne_Ed_CustomerCode_Leave ( object sender, EventArgs e )
		{
			// 空白またはゼロの場合は初期値をセット
			if ( ( ( (TNedit)sender ).DataText == string.Empty ) || ( ( (TNedit)sender ).GetInt() == 0 ) ) 
			{
                // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
				//( (TNedit)sender ).SetInt( 999999999 );
                ((TNedit)sender).Clear();
                // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
            }
		}
		#endregion
		#endregion ◆ tne_Ed_CustomerCode

		#region // 2007.07.04 kubo del
		//#region ◆ ut_DepositKind
		//#region ◎ AfterCheck Event
		///// <summary>
		///// AfterCheck Event
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントパラメータ</param>
		///// <remarks>
		///// <br>Note		: ツリーノードをチェックした後に発生する。</br>
		///// <br>Programmer	: 22013 久保 将太</br>
		///// <br>Date		: 2007.03.07</br>
		///// </remarks>
		//private void ut_DepositKind_AfterCheck ( object sender, NodeEventArgs e )
		//{
		//    if ( this._isDepositKindSetting )
		//    {
		//        return;
		//    }

		//    try
		//    {
		//        this._isDepositKindSetting = true;		// 金種設定中フラグOn
		//        // 全社ノードを取得
		//        UltraTreeNode allNode = ( (UltraTree)sender ).GetNodeByKey(DepositMainCndtn.ct_All_Code.ToString());

		//        if ( allNode == null )
		//        {
		//            return;
		//        }

		//        // 「全て」が選択されたか
		//        if ( e.TreeNode.Key.Equals(DepositMainCndtn.ct_All_Code.ToString()) )
		//        {
		//            if ( allNode.CheckedState == CheckState.Checked )
		//            {
		//                // 「全て」以外のチェックを外す
		//                foreach ( UltraTreeNode node in this.ut_DepositKind.Nodes )
		//                {
		//                    if ( node.Key != DepositMainCndtn.ct_All_Code.ToString() )
		//                    {
		//                        // リスト選択設定
		//                        node.CheckedState = CheckState.Unchecked;
		//                    }
		//                }
		//            }
		//        }
		//        else
		//        {
		//            // 「全て」にチェックがついているか
		//            if ( allNode.CheckedState == CheckState.Checked )
		//            {
		//                // 「全て」のチェックを外す
		//                this.ut_DepositKind.Nodes[DepositMainCndtn.ct_All_Code.ToString()].CheckedState = CheckState.Unchecked;
		//            }
		//        }
		//    }
		//    finally
		//    {
		//        this._isDepositKindSetting = false;		// 金種設定中フラグOff
		//    }
		//}
		//#endregion

		//#endregion ◆ ut_DepositKind
		#endregion

		#region ◆ Initialize_Timer
		#region ◎ Tick Event
		/// <summary>
		/// Tick Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        /// <br>Update Note : 2012/12/25 董桂鈺</br>
        ///	<br>			  Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br> 
		private void Initialize_Timer_Tick ( object sender, EventArgs e )
		{
			Initialize_Timer.Enabled = false;
			string errMsg = string.Empty;

            // 2008.07.23 30413 犬飼 未使用プロパティの削除 >>>>>>START
            //int sumDivSelIndex = 0;
            // 2008.07.23 30413 犬飼 未使用プロパティの削除 <<<<<<END
        
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

                // 2008.07.23 30413 犬飼 小計区分の削除 >>>>>>START
                //// 小計区分
                //this.InitializeSumDiv( out sumDivSelIndex );
                // 2008.07.23 30413 犬飼 小計区分の削除 <<<<<<END
                
				// 出力順
				this.InitializeSortOrderDiv();

                // 金種マスタの取得
                GetMoneyKind(out errMsg);

                // 入金設定マスタの取得
                GetDepositSet();

				// 入金金種
				status = this.InitializeDepositKind( out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
					return;
				}

				// ガイドボタンのアイコン設定
				this.SetIconImage( this.ub_St_CustomerCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCdGuid, Size16_Index.STAR1 );

                // 2008.07.23 30413 犬飼 担当者ガイドボタンの削除 >>>>>>START
                //this.SetIconImage(this.ub_St_EmployeeCdGuid, Size16_Index.STAR1);
                //this.SetIconImage( this.ub_Ed_EmployeeCdGuid, Size16_Index.STAR1 );
                // 2008.07.23 30413 犬飼 担当者ガイドボタンの削除 <<<<<<END
                
				ParentToolbarSettingEvent( this );	// ツールバー設定イベント
			}
			finally
			{
                uiMemInput1.ReadMemInput();//ADD 董桂鈺　2012/12/25 for Redmine#33271

                // 2008.07.23 30413 犬飼 未使用プロパティの削除 >>>>>>START
                //this._isFirstSetting = false;
                // 2008.07.23 30413 犬飼 未使用プロパティの削除 <<<<<<END
        
                // 2008.07.23 30413 犬飼 小計区分の削除 >>>>>>START
                //this.tce_SumDiv.SelectedIndex = sumDivSelIndex;
                // 2008.07.23 30413 犬飼 小計区分の削除 <<<<<<END
                
                // 2008.07.09 30413 犬飼 初期フォーカスを入金日に変更 >>>>>>START
                // 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
                this.tde_St_AddUpADate.Focus();
                //this.tde_St_CreateDate.Focus();
                // 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<
                // 2008.07.09 30413 犬飼 初期フォーカスを入金日に変更 <<<<<<END
                
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
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
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
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
            
            // 2008.07.09 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            //this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.09 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
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
            // 2008.09.23 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
		}
		#endregion
		#endregion ◆ ub_St_CustomerCdGuid

		#region ◆ ub_St_EmployeeCdGuid
        // 2008.07.23 30413 犬飼 不要メソッドの削除 >>>>>>START
		#region ◎ Click Event
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
		#endregion
        // 2008.07.23 30413 犬飼 不要メソッドの削除 <<<<<<END
        #endregion ◆ ub_St_CustomerCdGuid

		#region ◆ clb_DepositKind
		#region ◎ ItemCheck Event
		/// <summary>
		/// ItemCheck Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note       : チェック状態が変わろうとしている時に発生。イベント後、チェック状態が変更される。</br>
		/// <br>Programmer : 22013 kubo</br>
        /// <br>Date		: 2007.03.06</br>
		/// </remarks>
		private void clb_DepositKind_ItemCheck ( object sender, ItemCheckEventArgs e )
		{
            if (e.Index == 0)
            {
                if (this.clb_DepositKind.GetItemChecked(0) == false) // これから選択されようとしているので値は逆
                {
                    // 「全て」が選択された場合、「全て」以外の選択を解除
                    for (int i = 1; i < clb_DepositKind.Items.Count; i++)
                    {
                        this.clb_DepositKind.SetItemChecked(i, false);
                    }
                }
                else
                {
                    if (this.clb_DepositKind.CheckedItems.Count == 0)
                    {
                        // 選択項目が全て解除された場合、「全て」を選択状態にする
                        this.clb_DepositKind.SetItemChecked(0, true);
                    }
                }
            }
            else
            {
                if (this.clb_DepositKind.GetItemChecked(e.Index) == false) // これから選択されようとしているので値は逆
                {
                    // 「全て」以外が選択状態にされた場合は、「全て」の選択状態を解除
                    this.clb_DepositKind.SetItemChecked(0, false);
                }
            }
		}
		#endregion 
		#endregion ◆ clb_DepositKind
		#endregion ■ Control Event

		#region ■ Private Event
        #region ◆ 得意先(仕入先)選択時発生イベント

        /// <summary>
		/// 得意先(仕入先)選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        :得意先ガイドで得意先を選択した時に発生します</br>
        /// <br>Programmer  :22013 kubo</br>
        /// <br>Date        :2007.05.21</br>
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

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 2008.09.23 30413 犬飼 ガイドボタン遷移制御 >>>>>>START
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→入金区分
                        e.NextCtrl = this.tce_DepositCd;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tce_DepositCd)
                    {
                        // 入金区分→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                }
            }
            // 2008.09.23 30413 犬飼 ガイドボタン遷移制御 <<<<<<END            
        }


		#endregion

	}
}