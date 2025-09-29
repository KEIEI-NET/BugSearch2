//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動確認表
// プログラム概要   : 在庫移動確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 久保 将太
// 作 成 日  2007/03/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/02  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/10  修正内容 : 不具合対応[12213]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/02  修正内容 : 不具合対応[13061]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 不具合対応[13061](再修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/11  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 脇田 靖之
// 修 正 日  2012/11/06  修正内容 : 仕様変更対応（出庫追加）
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

using Broadleaf.Application.Controller;
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
    /// 在庫・倉庫移動確認表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫・倉庫移動確認表UIフォームクラス</br>
    /// <br>Programmer : 22013 久保 将太</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br>Update     : 2008/10/02 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>           : 2009/03/10 照田 貴志　不具合対応[12213]</br>
    /// <br>　           ※発行タイプ「全て」を削除、「出庫」→「未入荷」、「入庫」→「入荷済」にそれぞれ変更</br>
    /// <br>           : 2009/04/02 上野 俊治　不具合対応[13061]</br>
    /// <br>           : 2009/04/07 上野 俊治　不具合対応[13061](再修正)</br>
    /// <br>           : 2012/11/06 脇田 靖之　仕様変更対応</br>
    /// <br>　           ※発行タイプ「出庫」追加</br>
    /// </remarks>
	public partial class MAZAI02030UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫・倉庫移動確認表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動確認表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.14</br>
		/// <br></br>
		/// </remarks>
		public MAZAI02030UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            // ADD 2009/06/11 ------>>>
            // 在庫管理全体設定アクセスクラス
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            // ADD 2009/06/11 ------<<<
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

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
		private StockMoveCndtn _stockMoveCndtn;

		// 拠点ガイド用
		SecInfoSet _secInfoSet;
		SecInfoSetAcs _secInfoSetAcs;
		// 倉庫ガイド用
		Warehouse _wareHouse;
		WarehouseAcs _wareHouseAcs;
		// メーカーガイド用
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //Maker _makerInfo;
        //MakerUMnt _makerInfo;         // DEL 2008.08.08
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		
        //MakerAcs _makerInfoAcs;       // DEL 2008.08.08
		// 商品コード用
		MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        //GoodsUnitData _goodsUnitData; // DEL 2008.08.08
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // 担当者ガイド用
        EmployeeAcs _employeeAcs;
        Employee _employee;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // ガイド後次項目ディクショナリ
        //private Dictionary<Control, Control> _nextControl;    // DEL 2008.08.12

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // ADD 2009/06/11 ------>>>
        // 在庫管理全体設定アクセスクラス
        StockMngTtlStAcs _stockMngTtlStAcs;
        // 在庫管理全体設定データクラス
        StockMngTtlSt _stockMngTtlSt;
        // ADD 2009/06/11 ------<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID			= "MAZAI02030UA";
		// プログラムID
		private const string ct_PGID			= "MAZAI02030U";
		//// 帳票名称
		private string _printName				= "";
        // 帳票キー	
        private string _printKey				= "";
		#endregion ◆ Interface member

		// ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_ReportSortGroup = "ReportSortGroup";           // ソート順
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件

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
        /// <br>Date		: 2007.03.14</br>
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

            //printInfo.PrintPaperSetCd	= (int)this._stockMoveCndtn.StockMoveFormalDiv;     // DEL 2008.08.12

            printInfo.PrintPaperSetCd = 1;

			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._stockMoveCndtn;
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
        /// <br>Date		: 2007.03.14</br>
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
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		public void Show ( object parameter )
		{
			this._stockMoveCndtn = new StockMoveCndtn();

            //--- DEL 2008.08.12 ---------->>>>>
            //// 抽出条件に起動パラメータをセット
            //if ( parameter.ToString().CompareTo( "1" ) == 0 )
            //{
            //    this._stockMoveCndtn.StockMoveFormalDiv = StockMoveCndtn.StockMoveFormalDivState.StockMove;
            //    this._printKey = "461a402f-20c6-4b5e-817f-790237550131";
            //}
            //else if ( parameter.ToString().CompareTo( "2" ) == 0 )
            //{
            //    this._stockMoveCndtn.StockMoveFormalDiv = StockMoveCndtn.StockMoveFormalDivState.WareHouseMove;
            //    this._printKey = "edded41e-2702-4de3-95b7-3518c5fae7b1";
            //}
            //else
            //    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK );

            //this._printName = this._stockMoveCndtn.StockMoveFormalDivName;
            //--- DEL 2008.08.12 ----------<<<<<

            //--- ADD 2008.08.12 ---------->>>>>
            this._stockMoveCndtn.StockMoveFormalDiv = StockMoveCndtn.StockMoveFormalDivState.StockMove;
            this._printKey = "461a402f-20c6-4b5e-817f-790237550131";
            this._printName = "在庫移動確認表";
            //--- ADD 2008.08.12 ----------<<<<<

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
        /// <br>Date		: 2007.03.14</br>
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


            //--- DEL 2008.08.12 ---------->>>>>
            //// 倉庫ガイドEnabled設定
            //// 拠点リストの要素が1つだけで1番目の要素が全社ではないときにTrueになる。
            //if ( ( this._selectedSectionList.Count == 1 ) && ( !this._selectedSectionList.ContainsKey( "0" ) ) )
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_MainBfAfEnterWarehGuid, this.ub_Ed_MainBfAfEnterWarehGuid, 
            //        string.Empty, string.Empty );

            //    // 倉庫移動の時には絞込み倉庫ガイド(ボタンは絞込み拠点)のEnabledも操作する
            //    if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.WareHouseMove )
            //    {
            //        ExtractWareHouseGuidSetProc( 
            //            this.ub_St_ExtractSectionGuid, this.ub_Ed_ExtractSectionGuid, 
            //            string.Empty, string.Empty );
            //    }
            //}
            //else
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_MainBfAfEnterWarehGuid, this.ub_Ed_MainBfAfEnterWarehGuid, 
            //        "0", string.Empty );

            //    // 倉庫移動の時には絞込み倉庫ガイド(ボタンは絞込み拠点)のEnabledも操作する
            //    if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.WareHouseMove )
            //    {
            //        ExtractWareHouseGuidSetProc( 
            //            this.ub_St_ExtractSectionGuid, this.ub_Ed_ExtractSectionGuid, 
            //            "0", string.Empty );
            //    }
            //}
            //--- DEL 2008.08.12 ----------<<<<<

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
        /// <br>Date		: 2007.03.14</br>
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
        /// <br>Date		: 2007.03.14</br>
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
        /// <br>Date		: 2007.03.14</br>
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
        /// <br>Date		: 2007.03.14</br>
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
            get { return this._printName; }
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
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                //--- DEL 2008.08.12 ---------->>>>>
                //// 主倉庫コード
                //this.te_St_WarehouseCode.DataText = string.Empty;
                //// 処理区分
                //if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
                //{
                //    // 在庫移動一覧表の設定
                //    InitialStockMoveListSetting();
                //}
                //else if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.WareHouseMove )
                //{
                //    // 倉庫移動一覧表の設定
                //    InitialWareHouseMoveListSetting();
                //}
                //else
                //{
                //    errMsg = "不正なパラメータが渡されました。処理を終了します。";
                //    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return status;
                //}
                //--- DEL 2008.08.12 ----------<<<<<

                // ガイド後次項目の設定
                SettingGuideNextControl();


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 集計単位
                //this.uos_GrossPrintDiv.CheckedIndex = StockMoveCndtn.GrossPrintDivState.ProductNo;	// 製品番号
                //this._stockMoveCndtn.GrossPrintDiv = StockMoveCndtn.GrossPrintDivState.ProductNo;		// 製品番号
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                /* --- DEL 2008/10/02 対象日を必須とする為 ---------------------------------------->>>>>
				// 入力日付
				this.tde_St_CreateDate.SetDateTime( TDateTime.GetSFDateNow() );
                this.tde_Ed_CreateDate.SetDateTime(TDateTime.GetSFDateNow());
                   --- DEL 2008/10/02 -------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/02 ------------------------------------------------------------->>>>>
                // 対象日
                this.tde_St_ShipArrivalDate.SetDateTime(TDateTime.GetSFDateNow());      // From
                this.tde_Ed_ShipArrivalDate.SetDateTime(TDateTime.GetSFDateNow());      // To
                // --- ADD 2008/10/02 -------------------------------------------------------------<<<<<
                //--- DEL 2008.08.12 ---------->>>>>
                //// 絞込み拠点
                //this.te_St_ExtractSectionCd.DataText = string.Empty;
                //this.te_Ed_ExtractSectionCd.DataText = string.Empty;
                //// 絞込み倉庫
                //this.te_St_ExtractWareHouseCd.DataText = string.Empty;
                //this.te_Ed_ExtractWareHouseCd.DataText = string.Empty;
                //// 移動伝票番号
                //this.tne_St_StockMoveSlipNo.SetInt( 0 );
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////this.tne_Ed_StockMoveSlipNo.SetInt( 999999999 );
                //this.tne_Ed_StockMoveSlipNo.SetInt( 0 );
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //// メーカーコード
                //this.tne_St_MakerCode.SetInt( 0 );
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////this.tne_Ed_MakerCode.SetInt( 999 );
                //this.tne_Ed_MakerCode.SetInt( 0 );
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //// 商品コード
                //this.te_St_GoodsNo.DataText = string.Empty;
                //this.te_Ed_GoodsNo.DataText = string.Empty;
                //--- DEL 2008.08.12 ----------<<<<<

				// タイトル設定
				this.SetLabelText();

				// ボタン設定
				this.SetIconImage( this.ub_St_MainBfAfEnterWarehGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_MainBfAfEnterWarehGuid, Size16_Index.STAR1 );
                /* --- DEL 2008/10/02 入庫拠点削除の為 -------------------------------->>>>>
				this.SetIconImage( this.ub_St_ExtractSectionGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_ExtractSectionGuid, Size16_Index.STAR1 );
                   --- DEL 2008/10/02 -------------------------------------------------<<<<< */
                this.SetIconImage( this.ub_St_ExtractWareHouseGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_ExtractWareHouseGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_St_ExtractWareHouseGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_ExtractWareHouseGuid, Size16_Index.STAR1 );
                //--- DEL 2008.08.08 ---------->>>>>
                //this.SetIconImage( this.ub_St_MakerCodeGuid, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_MakerCodeGuid, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_GoodsGuid, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_GoodsGuid, Size16_Index.STAR1 );
                //--- DEL 2008.08.08 ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this.SetIconImage(this.ub_St_StockMvEmpGuid, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_StockMvEmpGuid, Size16_Index.STAR1);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // ADD 2009/06/11 ------>>>
                this.ce_PrintType.Items.Clear();
                if (this._stockMngTtlSt.StockMoveFixCode == 1)
                {
                    // 在庫移動確定区分：入荷確定あり
                    this.ce_PrintType.Items.Add(0, "未入荷");
                    this.ce_PrintType.Items.Add(1, "入荷済");
                    // --- ADD 2012/11/06 Y.Wakita ---------->>>>>
                    this.ce_PrintType.Items.Add(2, "出庫");
                    // --- ADD 2012/11/06 Y.Wakita ----------<<<<<
                }
                else if (this._stockMngTtlSt.StockMoveFixCode == 2)
                {
                    // 在庫移動確定区分：入荷確定なし
                    this.ce_PrintType.Items.Add(0, "出庫");
                    this.ce_PrintType.Items.Add(1, "入庫");
                    this.ce_PrintType.Items.Add(-1, "全て");
                }
                this.ce_PrintType.MaxDropDownItems = this.ce_PrintType.Items.Count;
                // ADD 2009/06/11 ------<<<

				// 初期フォーカスセット
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
				//this.te_St_MainBfAfEnterWarehCd.Focus();
                this.tde_St_ShipArrivalDate.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //--- ADD 2008.08.12 ---------->>>>>
                this.ce_NewPage.SelectedIndex = 0;          // 改頁
                this.ce_OutputOrder.SelectedIndex = 0;      // 出力順
                this.ce_PrintType.SelectedIndex = 0;        // 発行タイプ
                this.ce_OutputDesignat.SelectedIndex = 0;   // 出力指定
                this.ce_PriceDesignat.SelectedIndex = 0;    // 金額指定
                //--- ADD 2008.08.12 ----------<<<<<
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// ガイド後次項目の設定
        /// </summary>
        private void SettingGuideNextControl()
        {
            //--- DEL 2008.08.12 ---------->>>>>
            //// コントロールのリストを生成
            //List<Control> controls = new List<Control>();

            //controls.Add( te_St_WarehouseCode );
            //controls.Add( te_Ed_WarehouseCode );

            //// 入出荷区分（在庫移動用）
            //if ( uos_ShipmentArrivalDiv_Stock.Visible )
            //{
            //    controls.Add( uos_ShipmentArrivalDiv_Stock );
            //}
            //// 入出荷区分（倉庫移動用）
            //if ( uos_ShipmentArrivalDiv_WareHouse.Visible )
            //{
            //    controls.Add( uos_ShipmentArrivalDiv_WareHouse );
            //}

            //// パネル１
            //if ( pnl_Cndtn1.Visible )
            //{
            //    controls.Add( te_St_ExtractSectionCd );
            //    controls.Add( te_Ed_ExtractSectionCd );
            //}

            // パネル２
            //if ( pnl_Cndtn2.Visible )
            //{
            //    controls.Add(te_St_ExtractWareHouseCd);
            //    controls.Add( te_Ed_ExtractWareHouseCd );

            //    controls.Add(tne_St_StockMoveSlipNo);
            //    controls.Add( tne_Ed_StockMoveSlipNo );

            //    controls.Add( tne_St_MakerCode );
            //    controls.Add( tne_Ed_MakerCode );

            //    controls.Add( te_St_GoodsNo );
            //    controls.Add( te_Ed_GoodsNo );

            //    controls.Add( te_St_EmployeeCode );
            //    controls.Add( te_Ed_EmployeeCode );
            //}

            //// 最終項目は最後に２重に格納する
            //controls.Add( controls[controls.Count - 1] );


            //// リストからディクショナリを生成
            //_nextControl = new Dictionary<Control, Control>();
            //for ( int index = 0; index < controls.Count-1; index++ )
            //{
            //    _nextControl.Add( controls[index], controls[index + 1] );
            //}
            //--- DEL 2008.08.12 ----------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		#endregion

		#region ◎ 在庫移動一覧表初期処理
		/// <summary>
		/// 在庫移動一覧表初期処理
		/// </summary>
		private void InitialStockMoveListSetting()
		{
            //--- DEL 2008.08.12 ---------->>>>>
            //// 処理区分
            //InitialShipmentArrivalDiv( 
            //    this.uos_ShipmentArrivalDiv_Stock, 
            //    this.uos_ShipmentArrivalDiv_WareHouse, 
            //    StockMoveCndtn.ShipmentArrivalDivState.UnShipment );
            //this._stockMoveCndtn.ShipmentArrivalDiv = StockMoveCndtn.ShipmentArrivalDivState.UnShipment;
            //--- DEL 2008.08.12 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 絞込み対象倉庫コード
            //this.ul_ExtractWareHouseTitle.Visible = true;
            //this.te_St_ExtractWareHouseCd.Visible = true;
            //this.te_Ed_ExtractWareHouseCd.Visible = true;
            //this.ub_St_ExtractWareHouseGuid.Visible = true;
            //this.ub_Ed_ExtractWareHouseGuid.Visible = true;
            //this.ul_ExtractWareHouseChilda.Visible = true;

            pnl_Cndtn1.Visible = true;
            pnl_Cndtn2.Visible = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}
		#endregion

		#region ◎ 倉庫移動一覧表初期処理
		/// <summary>
		/// 倉庫移動一覧表初期処理
		/// </summary>
		private void InitialWareHouseMoveListSetting()
		{
            //--- DEL 2008.08.12 ---------->>>>>
            //// 処理区分
            //InitialShipmentArrivalDiv( 
            //    this.uos_ShipmentArrivalDiv_WareHouse,
            //    this.uos_ShipmentArrivalDiv_Stock,
            //    StockMoveCndtn.ShipmentArrivalDivState.Shipment );
            //this._stockMoveCndtn.ShipmentArrivalDiv = StockMoveCndtn.ShipmentArrivalDivState.Shipment;
            //--- DEL 2008.08.12 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 絞込み対象倉庫コード
            //this.ul_ExtractWareHouseTitle.Visible = false;
            //this.te_St_ExtractWareHouseCd.Visible = false;
            //this.te_Ed_ExtractWareHouseCd.Visible = false;
            //this.ub_St_ExtractWareHouseGuid.Visible = false;
            //this.ub_Ed_ExtractWareHouseGuid.Visible = false;
            //this.ul_ExtractWareHouseChilda.Visible = false;

            //ul_ExtractSectionTitle.Visible = false;
            //te_St_ExtractSectionCd.Visible = false;
            //te_Ed_ExtractSectionCd.Visible = false;
            //ub_St_ExtractSectionGuid.Visible = false;
            //ub_Ed_ExtractSectionGuid.Visible = false;
            //ul_ExtractSectionChilda.Visible = false;

            pnl_Cndtn1.Visible = false;
            pnl_Cndtn2.Visible = true;
            pnl_Cndtn2.Top = pnl_Cndtn1.Top;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}
		#endregion

		#region ◎ 処理区分初期化処理
		/// <summary>
		/// 処理区分初期化処理
		/// </summary>
		/// <param name="activeControl">有効コントロール</param>
		/// <param name="inActiveControl">無効コントロール</param>
		/// <param name="checkedIndex">有効コントロールにセットするインデックス</param>
		private void InitialShipmentArrivalDiv( UltraOptionSet activeControl, UltraOptionSet inActiveControl, StockMoveCndtn.ShipmentArrivalDivState checkedIndex )
		{
			// VisibleSet
			activeControl.Visible = true;
			inActiveControl.Visible = false;

			// CheckedIndexSet
			activeControl.Value = (int)checkedIndex;
		}
		#endregion

		#region ◎ 項目タイトル設定処理
		/// <summary>
		/// 項目タイトル設定処理
		/// </summary>
		private void SetLabelText( )
		{
            //--- DEL 2008.08.12 ---------->>>>>
            //// 主倉庫コード
            //this.ul_MainWareHouseTitle.Text = string.Format( "{0}倉庫コード", this._stockMoveCndtn.MainExtractTitle );
            //// 抽出日付
            //this.ul_ShipArrivalDateTitle.Text = string.Format( "{0}", this._stockMoveCndtn.ExtractDateTitle );

            //// 在庫移動・倉庫移動でタイトルを変更
            //if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
            //{
            //    // 抽出拠点コード
            //    this.ul_ExtractSectionTitle.Text = string.Format( "{0}拠点コード", this._stockMoveCndtn.ExtractTitle );
            //    // 抽出倉庫コード
            //    this.ul_ExtractWareHouseTitle.Text = string.Format( "{0}倉庫コード", this._stockMoveCndtn.ExtractTitle );
            //}
            //else
            //{
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //// 抽出倉庫コード(倉庫移動のときは拠点コードを倉庫コードとして扱う)
            //    //this.ul_ExtractSectionTitle.Text = string.Format( "{0}倉庫コード", this._stockMoveCndtn.ExtractTitle );

            //    // 抽出倉庫コード
            //    this.ul_ExtractWareHouseTitle.Text = string.Format( "{0}倉庫コード", this._stockMoveCndtn.ExtractTitle );
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            //--- DEL 2008.08.12 ----------<<<<<
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
		/// 入力チェック処理
		/// </summary>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <param name="errComponent">エラー発生コンポーネント</param>
		/// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            // 項目のゼロ詰め
            this.AddZero();         //ADD 2008/10/02

			const string ct_InputError = "の入力が不正です";
            //const string ct_NoInput = "を入力して下さい";                             //DEL 2008/10/02 未使用の為
			const string ct_RangeError = "の範囲指定に誤りがあります";
            //const string ct_FullRangeError = "は１ヶ月の範囲で入力して下さい";        //DEL 2008/10/02 3ヵ月に変更の為
            const string ct_FullRangeError = "は３ヶ月の範囲で入力して下さい";          //ADD 2008/10/02

            DateGetAcs.CheckDateRangeResult cdrResult;

            //--- DEL 2008.08.12 ---------->>>>>
            //// 出荷日（開始・終了）
            //if ( CallCheckDateRange( out cdrResult, ref tde_St_ShipArrivalDate, ref tde_Ed_ShipArrivalDate ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "開始日{0}", ct_NoInput );
            //                errComponent = this.tde_St_ShipArrivalDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "開始日{0}", ct_InputError );
            //                errComponent = this.tde_St_ShipArrivalDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "終了日{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_ShipArrivalDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "終了日{0}", ct_InputError );
            //                errComponent = this.tde_St_ShipArrivalDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "日付{0}", ct_RangeError );
            //                errComponent = this.tde_St_ShipArrivalDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "日付{0}", ct_FullRangeError );
            //                errComponent = this.tde_St_ShipArrivalDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //// 倉庫コード
            //else if (
            //    (this.te_St_WarehouseCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_WarehouseCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_WarehouseCode.DataText.TrimEnd().CompareTo( this.te_Ed_WarehouseCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "{0}{1}", this.ul_MainWareHouseTitle.Text, ct_RangeError );
            //    errComponent = this.te_St_WarehouseCode;
            //    status = false;
            //}
            //// 抽出拠点コード
            //else if (
            //    (this.te_St_ExtractSectionCd.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_ExtractSectionCd.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_ExtractSectionCd.DataText.TrimEnd().CompareTo( this.te_Ed_ExtractSectionCd.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "{0}{1}", this.ul_ExtractSectionTitle.Text, ct_RangeError );
            //    errComponent = this.te_St_ExtractSectionCd;
            //    status = false;
            //}
            //// 抽出倉庫コード
            //else if ( (this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove) &&
            //     ((this.te_St_ExtractWareHouseCd.DataText.TrimEnd() != string.Empty) &&
            //       (this.te_Ed_ExtractWareHouseCd.DataText.TrimEnd() != string.Empty) &&
            //       (this.te_St_ExtractWareHouseCd.DataText.TrimEnd().CompareTo( this.te_Ed_ExtractWareHouseCd.DataText.TrimEnd() ) > 0)
            //     ) )
            //{
            //    errMessage = string.Format( "{0}{1}", this.ul_ExtractWareHouseTitle.Text, ct_RangeError );
            //    errComponent = this.te_St_ExtractWareHouseCd;
            //    status = false;
            //}
            //// 移動伝票番号
            //else if ( this.tne_St_StockMoveSlipNo.GetInt() > GetEndCode( this.tne_Ed_StockMoveSlipNo ) )
            //{
            //    errMessage = string.Format( "移動伝票番号{0}", ct_RangeError );
            //    errComponent = this.tne_St_StockMoveSlipNo;
            //    status = false;
            //}
            //// メーカーコード
            //else if ( this.tne_St_MakerCode.GetInt() > GetEndCode( this.tne_Ed_MakerCode ) )
            //{
            //    errMessage = string.Format( "メーカーコード{0}", ct_RangeError );
            //    errComponent = this.tne_St_MakerCode;
            //    status = false;
            //}
            //// 商品コード
            //else if (
            //    (this.te_St_GoodsNo.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_GoodsNo.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_GoodsNo.DataText.TrimEnd().CompareTo( this.te_Ed_GoodsNo.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "商品コード{0}", ct_RangeError );
            //    errComponent = this.te_St_GoodsNo;
            //    status = false;
            //}
            //--- DEL 2008.08.12 ----------<<<<<
            //--- ADD 2008.08.12 ---------->>>>>
            // 対象日付（開始・終了）
            //if (CallCheckDateRange(out cdrResult, ref tde_St_ShipArrivalDate, ref tde_Ed_ShipArrivalDate) == false) // DEL 2009/04/02
            if (CallCheckDateRangeAllowNoInput(out cdrResult, ref tde_St_ShipArrivalDate, ref tde_Ed_ShipArrivalDate) == false) // ADD 2009/04/02
            {
                switch (cdrResult)
                {
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format("開始対象日付{0}", ct_NoInput);
                    //        errComponent = this.tde_St_ShipArrivalDate;
                    //    }
                    //    break;
                    // --- DEL 2009/04/02 -------------------------------->>>>>
                    //// --- ADD 2008/10/02 ----------------------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format("開始対象日{0}", ct_InputError);
                    //        errComponent = this.tde_St_ShipArrivalDate;
                    //        status = false;
                    //    }
                    //    break;
                    //// --- ADD 2008/10/02 -----------------------------------------------<<<<<
                    // --- DEL 2009/04/02 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            //errMessage = string.Format("開始対象日付{0}", ct_InputError);     //DEL 2008/10/02 文言変更
                            errMessage = string.Format("開始対象日{0}", ct_InputError);         //ADD 2008/10/02
                            errComponent = this.tde_St_ShipArrivalDate;
                            //status = false; // DEL 2009/04/07
                            return false; // ADD 2009/04/07
                        }
                    //break; // DEL 2009/04/07
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format("終了対象日付{0}", ct_NoInput);
                    //        errComponent = this.tde_Ed_ShipArrivalDate;
                    //    }
                    //    break;
                    // --- DEL 2009/04/02 -------------------------------->>>>>
                    //// --- ADD 2008/10/02 ----------------------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format("終了対象日{0}", ct_InputError);
                    //        errComponent = this.tde_Ed_ShipArrivalDate;
                    //        status = false;
                    //    }
                    //    break;
                    //// --- ADD 2008/10/02 -----------------------------------------------<<<<<
                    // --- DEL 2009/04/02 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            //errMessage = string.Format("終了対象日付{0}", ct_InputError);     //DEL 2008/10/02 文言変更
                            errMessage = string.Format("終了対象日{0}", ct_InputError);         //ADD 2008/10/02
                            //errComponent = this.tde_St_ShipArrivalDate;
                            errComponent = this.tde_Ed_ShipArrivalDate;
                            //status = false; // DEL 2009/04/07
                            return false;// ADD 2009/04/07
                        }
                    //break; // DEL 2009/04/07
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            //errMessage = string.Format("対象日付{0}", ct_RangeError);         //DEL 2008/10/02 文言変更
                            errMessage = string.Format("対象日{0}", ct_RangeError);             //ADD 2008/10/02
                            errComponent = this.tde_St_ShipArrivalDate;
                            //status = false; // DEL 2009/04/07
                            return false;// ADD 2009/04/07
                        }
                    //break; // DEL 2009/04/07
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            //errMessage = string.Format("対象日付{0}", ct_FullRangeError);     //DEL 2008/10/02 文言変更
                            errMessage = string.Format("対象日{0}", ct_FullRangeError);         //ADD 2008/10/02
                            errComponent = this.tde_St_ShipArrivalDate;
                            //status = false; // DEL 2009/04/07
                            return false; // ADD 2009/04/07
                        }
                    //break; // DEL 2009/04/07
                }
            }
            // 入力日付（開始・終了）
            /* --- DEL 2008/10/02 修正が多い為、全てコメントアウト----------------------------------------->>>>>
            // ・必須条件を外す CallCheckDateRange()→CallCheckDateRangeAllowNoInput()
            // ・対象項目変更　tde_St_ShipArrivalDate→tde_St_CreateDate、tde_Ed_ShipArrivalDate→tde_Ed_CreateDate
            // ・文言変更「日付」→「日」
            else if (CallCheckDateRange(out cdrResult, ref tde_St_CreateDate, ref tde_Ed_CreateDate) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始入力日付{0}", ct_NoInput);
                            errComponent = this.tde_St_ShipArrivalDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始入力日付{0}", ct_InputError);
                            errComponent = this.tde_St_ShipArrivalDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了入力日付{0}", ct_NoInput);
                            errComponent = this.tde_Ed_ShipArrivalDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了入力日付{0}", ct_InputError);
                            errComponent = this.tde_St_ShipArrivalDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日付{0}", ct_RangeError);
                            errComponent = this.tde_St_ShipArrivalDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("入力日付{0}", ct_FullRangeError);
                            errComponent = this.tde_St_ShipArrivalDate;
                        }
                        break;
                }
                status = false;
            }
               --- DEL 2008/10/02 -------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/02 ------------------------------------------------------------------------->>>>>
            if (CallCheckDateRangeAllowNoInput(out cdrResult, ref tde_St_CreateDate, ref tde_Ed_CreateDate) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始入力日{0}", ct_InputError);
                            errComponent = this.tde_St_CreateDate;
                            return false;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了入力日{0}", ct_InputError);
                            errComponent = this.tde_Ed_CreateDate;
                            return false;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日{0}", ct_RangeError);
                            errComponent = this.tde_St_CreateDate;
                            return false;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("入力日{0}", ct_FullRangeError);
                            errComponent = this.tde_St_CreateDate;
                            return false;
                        }
                }
            }
            // --- ADD 2008/10/02 -------------------------------------------------------------------------<<<<<
            // 出庫倉庫（開始・終了）
            //else if ( (this.te_St_MainBfAfEnterWarehCd.DataText.TrimEnd() != string.Empty) &&         //DEL 2008/10/02 CallCheckDateRange=falseでも未入力の場合は出庫倉庫以降のチェックを行う必要がある為
            if ( (this.te_St_MainBfAfEnterWarehCd.DataText.TrimEnd() != string.Empty) &&                //ADD 2008/10/02
                (this.te_Ed_MainBfAfEnterWarehCd.DataText.TrimEnd() != string.Empty) &&
                (this.te_St_MainBfAfEnterWarehCd.DataText.TrimEnd().CompareTo(this.te_Ed_MainBfAfEnterWarehCd.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("{0}{1}", this.ul_MainBfAfEnterWarehTitle.Text, ct_RangeError);
                errComponent = this.te_St_MainBfAfEnterWarehCd;
                status = false;
            }
            /* --- DEL 2008/10/02 入庫拠点削除の為 -------------------------------------------------------------------------------->>>>>
            // 入庫拠点（開始・終了）
            else if ((this.te_St_ShipArrivalSectionCd.DataText.TrimEnd() != string.Empty) &&
                (this.te_Ed_ShipArrivalSectionCd.DataText.TrimEnd() != string.Empty) &&
                (this.te_St_ShipArrivalSectionCd.DataText.TrimEnd().CompareTo(this.te_Ed_ShipArrivalSectionCd.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("{0}{1}", this.ul_ShipArrivalSectionTitle.Text, ct_RangeError);
                errComponent = this.te_St_ShipArrivalSectionCd;
                status = false;
            }
               --- DEL 2008/10/02 -------------------------------------------------------------------------------------------------<<<<< */
            // 入庫倉庫（開始・終了）
            else if ((this.te_St_ShipArrivalEnterWarehCd.DataText.TrimEnd() != string.Empty) &&
                (this.te_Ed_ShipArrivalEnterWarehCd.DataText.TrimEnd() != string.Empty) &&
                (this.te_St_ShipArrivalEnterWarehCd.DataText.TrimEnd().CompareTo(this.te_Ed_ShipArrivalEnterWarehCd.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("{0}{1}", this.ul_ShipArrivalEnterWarehTitle.Text, ct_RangeError);
                errComponent = this.te_St_ShipArrivalEnterWarehCd;
                status = false;
            }
            //--- ADD 2008.08.12 ---------->>>>>
            // 入力担当者コード
            else if (
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format( "入力担当者コード{0}", ct_RangeError );       //DEL 2008/10/02 文言変更の為
                errMessage = string.Format("担当者コード{0}", ct_RangeError);               //ADD 2008/10/02
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
            }
			return status;
		}
        /// <summary>
        /// 日付範囲チェック呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate )
        {
            //cdrResult = _dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 1, ref startDate, ref endDate, false, false );      //DEL 2008/10/02 3ヵ月に変更
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDate, ref endDate, false, false);          //ADD 2008/10/02
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // --- ADD 2008/10/02 -------------------------------------------------------------------------------------------------------------------------------->>>>>
        /// <summary>
        /// 日付チェック処理呼び出し(範囲チェックなし、未入力OK)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRangeAllowNoInput(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // --- ADD 2008/10/02 --------------------------------------------------------------------------------------------------------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>数値コード項目の内容を取得する</br>
        /// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        /// <br>　コード値≠ゼロ　→　入力値</br>
        /// </remarks>
        private int GetEndCode( TNedit tNedit )
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode( tNedit, Int32.Parse( new string( '9', (tNedit.ExtEdit.Column) ) ) );
        }
        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode( TNedit tNedit, int endCodeOnDB )
        {
            if ( tNedit.GetInt() == 0 )
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
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
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 全拠点を選択した場合
                bool allSection = false;
                foreach ( object obj in this._selectedSectionList.Values )
                {
                    if ( obj is string )
                    {
                        if ( (obj as string) == "0" )
                        {
                            allSection = true;
                            break;
                        }
                    }
                }
                if ( allSection )
                {
                    this._selectedSectionList.Clear();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


				// 拠点オプション
				this._stockMoveCndtn.IsOptSection = this._isOptSection;
				// 企業コード
				this._stockMoveCndtn.EnterpriseCode = this._enterpriseCode;
				// 選択拠点
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
				//this._stockMoveCndtn.MainSectionCd = (string[])new ArrayList( this._selectedSectionList.Values ).ToArray( typeof ( string ) );
                this._stockMoveCndtn.BfAfSectionCd = ( string[] ) new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //--- DEL 2008.08.12 ---------->>>>>
                //// 倉庫コード
                //this._stockMoveCndtn.St_MainBfAfEnterWarehCd = this.te_St_WarehouseCode.DataText;
                //this._stockMoveCndtn.Ed_MainBfAfEnterWarehCd = this.te_Ed_WarehouseCode.DataText;
                //--- DEL 2008.08.12 ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 集計単位
                //this._stockMoveCndtn.GrossPrintDiv = (StockMoveCndtn.GrossPrintDivState)this.uos_GrossPrintDiv.CheckedIndex;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				// 出荷日
				this._stockMoveCndtn.St_ShipArrivalDate = this.tde_St_ShipArrivalDate.GetDateTime();
				this._stockMoveCndtn.Ed_ShipArrivalDate = this.tde_Ed_ShipArrivalDate.GetDateTime();

                //--- DEL 2008.08.12 ---------->>>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 入力日 (予備項目)
                //this._stockMoveCndtn.St_CreateDate = DateTime.MinValue;
                //this._stockMoveCndtn.Ed_CreateDate = DateTime.MaxValue;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //--- DEL 2008.08.12 ----------<<<<<

                //--- DEL 2008.08.08 ---------->>>>>
                //// 移動伝票番号
                //this._stockMoveCndtn.St_StockMoveSlipNo = this.tne_St_StockMoveSlipNo.GetInt();
                //this._stockMoveCndtn.Ed_StockMoveSlipNo = GetEndCode( this.tne_Ed_StockMoveSlipNo, 999999999 );
				
                //// メーカーコード
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////this._stockMoveCndtn.St_MakerCd = this.tne_St_MakerCode.GetInt();
                ////this._stockMoveCndtn.Ed_MakerCd = this.tne_Ed_MakerCode.GetInt();
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //this._stockMoveCndtn.St_GoodsMakerCd = this.tne_St_MakerCode.GetInt();
                //this._stockMoveCndtn.Ed_GoodsMakerCd = GetEndCode( this.tne_Ed_MakerCode, 999999 );
				
                //// 商品コード
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////this._stockMoveCndtn.St_GoodsCd = this.te_St_GoodsCd.DataText;
                ////this._stockMoveCndtn.Ed_GoodsCd = this.te_Ed_GoodsCd.DataText;
                //this._stockMoveCndtn.St_GoodsNo = this.te_St_GoodsNo.DataText;
                //this._stockMoveCndtn.Ed_GoodsNo = this.te_Ed_GoodsNo.DataText;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //--- DEL 2008.08.08 ----------<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 入力担当者コード
                this._stockMoveCndtn.St_StockMvEmpCode = this.tEdit_EmployeeCode_St.DataText;
                this._stockMoveCndtn.Ed_StockMvEmpCode = this.tEdit_EmployeeCode_Ed.DataText;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //--- DEL 2008/08/12 ---------->>>>>
                //if (this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove)
                //{
                //    // 在庫移動確認表
                //    // 処理区分
                //    this._stockMoveCndtn.ShipmentArrivalDiv = ((StockMoveCndtn.ShipmentArrivalDivState)this.uos_ShipmentArrivalDiv_Stock.Value);
		
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //    ////// 抽出拠点コード
                //    ////this._stockMoveCndtn.St_ExtractSectionCd = this.te_St_ExtractSectionCd.DataText;
                //    ////this._stockMoveCndtn.Ed_ExtractSectionCd = this.te_Ed_ExtractSectionCd.DataText;
                //    ////// 抽出倉庫コード
                //    ////this._stockMoveCndtn.St_ExtractWareHouseCd = this.te_St_ExtractWareHouseCd.DataText;
                //    ////this._stockMoveCndtn.Ed_ExtractWareHouseCd = this.te_Ed_ExtractWareHouseCd.DataText;
                //    //// 抽出拠点コード
                //    //this._stockMoveCndtn.St_ShipArrivalSectionCd = this.te_St_ExtractSectionCd.DataText;
                //    //this._stockMoveCndtn.Ed_ShipArrivalSectionCd = this.te_Ed_ExtractSectionCd.DataText;
                //    //// 抽出倉庫コード
                //    //this._stockMoveCndtn.St_ShipArrivalEnterWarehCd = this.te_St_ExtractWareHouseCd.DataText;
                //    //this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd = this.te_Ed_ExtractWareHouseCd.DataText;
                //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //    // 抽出拠点コード
                //    this._stockMoveCndtn.St_ShipArrivalSectionCd = this.te_St_ExtractSectionCd.DataText;
                //    this._stockMoveCndtn.Ed_ShipArrivalSectionCd = this.te_Ed_ExtractSectionCd.DataText;
                //    // 抽出倉庫コード
                //    this._stockMoveCndtn.St_ShipArrivalEnterWarehCd = this.te_St_ExtractWareHouseCd.DataText;
                //    this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd = this.te_Ed_ExtractWareHouseCd.DataText;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //}
                //else
                //{
                //    // 倉庫移動確認表
                //    // 処理区分
                //    this._stockMoveCndtn.ShipmentArrivalDiv = ((StockMoveCndtn.ShipmentArrivalDivState)this.uos_ShipmentArrivalDiv_WareHouse.Value);
					
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //    //// 抽出倉庫コード(表示の切り替えをしているから)
                //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //    ////this._stockMoveCndtn.St_ExtractWareHouseCd = this.te_St_ExtractSectionCd.DataText;
                //    ////this._stockMoveCndtn.Ed_ExtractWareHouseCd = this.te_St_ExtractSectionCd.DataText;
                //    //this._stockMoveCndtn.St_ShipArrivalEnterWarehCd = this.te_St_ExtractSectionCd.DataText;
                //    //this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd = this.te_Ed_ExtractSectionCd.DataText;
                //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //    this._stockMoveCndtn.St_ShipArrivalEnterWarehCd = this.te_St_ExtractWareHouseCd.DataText;
                //    this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd = this.te_Ed_ExtractWareHouseCd.DataText;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //}
                //--- DEL 2008/08/12 ----------<<<<<


                //--- ADD 2008/08/08 ---------->>>>>
                // 開始入力日付
                this._stockMoveCndtn.St_CreateDate = tde_St_CreateDate.GetDateTime();
                // 終了入力日付
                this._stockMoveCndtn.Ed_CreateDate = tde_Ed_CreateDate.GetDateTime();
                // 改頁
                this._stockMoveCndtn.NewPage = (StockMoveCndtn.NewPageDivState)this.ce_NewPage.Value;
                // 出力順
                this._stockMoveCndtn.OutputOrder = (StockMoveCndtn.OutputOrderDivState)this.ce_OutputOrder.Value;
                // 開始出庫倉庫
                this._stockMoveCndtn.St_MainBfAfEnterWarehCd = this.te_St_MainBfAfEnterWarehCd.DataText;
                // 終了出庫倉庫
                this._stockMoveCndtn.Ed_MainBfAfEnterWarehCd = this.te_Ed_MainBfAfEnterWarehCd.DataText;
                // 発行タイプ
                //this._stockMoveCndtn.PrintType = (StockMoveCndtn.PrintTypeDivState)this.ce_PrintType.Value;   // DEL 2009/06/11
                this._stockMoveCndtn.PrintType = (int)this.ce_PrintType.Value;  // ADD 2009/06/11
                /* --- DEL 2008/10/02 入庫拠点削除の為 ------------------------------------------------->>>>>
                // 開始入庫拠点
                this._stockMoveCndtn.St_ShipArrivalSectionCd = this.te_St_ShipArrivalSectionCd.DataText;
                // 終了入庫拠点
                this._stockMoveCndtn.Ed_ShipArrivalSectionCd = this.te_Ed_ShipArrivalSectionCd.DataText;
                   --- DEL 2008/10/02 ------------------------------------------------------------------<<<<< */
                // 開始入庫倉庫
                this._stockMoveCndtn.St_ShipArrivalEnterWarehCd = this.te_St_ShipArrivalEnterWarehCd.DataText;
                // 終了入庫倉庫
                this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd = this.te_Ed_ShipArrivalEnterWarehCd.DataText;
                // 出力指定
                this._stockMoveCndtn.OutputDesignat = (StockMoveCndtn.OutputDesignatDivState)this.ce_OutputDesignat.Value;
                // 金額指定
                this._stockMoveCndtn.PriceDesignat = (StockMoveCndtn.PriceDesignatDivState)this.ce_PriceDesignat.Value;
                //--- ADD 2008/08/08 ----------<<<<<

                // ADD 2009/06/11 ------>>>
                // 在庫移動確定区分
                this._stockMoveCndtn.StockMoveFixCode = this._stockMngTtlSt.StockMoveFixCode;
                // ADD 2009/06/11 ------<<<
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 渡された文字列(絞込み拠点コード)が同じならばガイドボタンをクリック可能にする
            //if ( compareStr1.CompareTo( compareStr2 ) == 0 ) 
            //{
            //    targetSt.Enabled = true;
            //    targetEd.Enabled = true;
            //}
            //else
            //{
            //    targetSt.Enabled = false;
            //    targetEd.Enabled = false;
            //}
            targetSt.Enabled = true;
            targetEd.Enabled = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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

        // ADD 2009/06/11 ------>>>
        #region ◆ 在庫管理全体設定マスタ読込
        private void GetStockMngTtlSt()
        {
            int status;
            ArrayList retList;

            this._stockMngTtlSt = new StockMngTtlSt();

            status = this._stockMngTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockMngTtlSt wkStockMngTtlSt in retList)
                {
                    if (wkStockMngTtlSt.SectionCode.Trim() == "00")
                    {
                        this._stockMngTtlSt = wkStockMngTtlSt.Clone();
                        break;
                    }
                }
            }
        }
        #endregion
        // ADD 2009/06/11 ------<<<
        
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ MAZAI02030UA
        #region ◎ MAZAI02030UA_Load Event
        /// <summary>
        /// MAZAI02030UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void MAZAI02030UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;

            // --- ADD 2008/10/02 --------------------------------------------------------->>>>>
            // 必須色設定
            //this.tde_St_ShipArrivalDate.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);   // 対象日From // DEL 2009/04/02
            //this.tde_Ed_ShipArrivalDate.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);   // 対象日To // DEL 2009/04/02
            this.ce_PrintType.Appearance.BackColor = Color.FromArgb(179, 219, 231);                 // 発行タイプ
            this.ce_NewPage.Appearance.BackColor = Color.FromArgb(179, 219, 231);                   // 改頁
            this.ce_OutputOrder.Appearance.BackColor = Color.FromArgb(179, 219, 231);               // 出力順
            // --- ADD 2008/10/02 ---------------------------------------------------------<<<<<

            // ADD 2009/06/11 ------>>>
            // 在庫管理全体設定マスタの読込
            GetStockMngTtlSt();
            // ADD 2009/06/11 ------<<<

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
		}
		#endregion
        #endregion ◆ MAZAI02030UA

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
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
            if ( (e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
                 (e.Group.Key == ct_ExBarGroupNm_ReportSortGroup) ||
                 (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) )
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
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
            if ( (e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
                 (e.Group.Key == ct_ExBarGroupNm_ReportSortGroup) ||
                 (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) )
            {
                // グループの展開をキャンセル
				e.Cancel = true;
			}

		}
		#endregion
		#endregion ◆ ueb_MainExplorerBar

		#region ◆ ub_St_MainBfAfEnterWarehGuid
		#region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがクリックされたときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
        private void ub_St_MainBfAfEnterWarehGuid_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";
            if (this._wareHouseAcs == null)
                this._wareHouseAcs = new WarehouseAcs();

            // Todo:ガイド呼び出し
            this._wareHouse = new Warehouse();

            // 選択拠点取得
            if ((((UltraButton)sender).Tag.ToString().CompareTo("1") == 0) || (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0))
            {
                //// 主倉庫コードの場合はスライダーの拠点コードをもとにガイド起動
                //if ( this._selectedSectionList.Count == 1 )
                //{
                //    foreach( DictionaryEntry de in this._selectedSectionList )
                //    {
                //        sectionCode = de.Value.ToString().TrimEnd();
                //    }
                //}
                sectionCode = GetWarehouseGuideSection(this._selectedSectionList);
            }
            else
            {
                //--- DEL 2008.08.12 ---------->>>>>
                //// 絞込み倉庫コードの場合は絞り込み拠点コードをもとにガイド起動
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////sectionCode = this.te_St_ExtractSectionCd.Text.TrimEnd();
                //if ( this.te_St_ExtractSectionCd.Text == this.te_Ed_ExtractSectionCd.Text )
                //{
                //    sectionCode = this.te_St_ExtractSectionCd.Text.TrimEnd();
                //}
                //else
                //{
                //    sectionCode = string.Empty;
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //--- DEL 2008.08.12 ----------<<<<<
            }

            status = this._wareHouseAcs.ExecuteGuid(out this._wareHouse, this._enterpriseCode, sectionCode);
            if (status != 0) return;

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            //--- DEL 2008.08.12 ---------->>>>>
            //if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )		targetControl = this.te_St_WarehouseCode;
            //else if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )	targetControl = this.te_Ed_WarehouseCode;
            //else if (((UltraButton)sender).Tag.ToString().CompareTo("3") == 0) targetControl = this.te_St_ExtractWareHouseCd;
            //else if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "4" ) == 0 )	targetControl = this.te_Ed_ExtractWareHouseCd;
            //--- DEL 2008.08.12 ----------<<<<<
            //--- ADD 2008.08.12 ---------->>>>>
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0) targetControl = this.te_St_MainBfAfEnterWarehCd;
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0) targetControl = this.te_Ed_MainBfAfEnterWarehCd;
            else if (((UltraButton)sender).Tag.ToString().CompareTo("3") == 0) targetControl = this.te_St_ShipArrivalEnterWarehCd;
            else if (((UltraButton)sender).Tag.ToString().CompareTo("4") == 0) targetControl = this.te_Ed_ShipArrivalEnterWarehCd;
            //--- ADD 2008.08.12 ----------<<<<<
            else return;

            // コード展開
            targetControl.DataText = this._wareHouse.WarehouseCode.TrimEnd();
            //_nextControl[targetControl].Focus(); // DEL 2008.08.12
            // --- ADD 2008/10/02 ------------------------------------------------------------------------------------------>>>>>
            // フォーカス遷移　※次項目へ
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0) this.te_Ed_MainBfAfEnterWarehCd.Focus();
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0) this.te_St_ShipArrivalEnterWarehCd.Focus();
            else if (((UltraButton)sender).Tag.ToString().CompareTo("3") == 0) this.te_Ed_ShipArrivalEnterWarehCd.Focus();
            else if (((UltraButton)sender).Tag.ToString().CompareTo("4") == 0) this.ce_OutputDesignat.Focus();
            else return;
            // --- ADD 2008/10/02 ------------------------------------------------------------------------------------------<<<<<
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 倉庫ガイド用拠点コード取得処理
        /// </summary>
        /// <param name="selectedSectionList"></param>
        /// <returns>倉庫ガイド用の指定拠点コード</returns>
        /// <remarks>
        /// <br>出力対象拠点の選択状況に応じて、拠点コードを返します</br>
        /// </remarks>
        private string GetWarehouseGuideSection( Hashtable selectedSectionList )
        {
            if ( selectedSectionList.Count >= 2 )
            {
                // 複数拠点が選択されていたら、未指定
                return string.Empty;
            }
            else if ( selectedSectionList.Count == 0 )
            {
                // 拠点が選択されていなければ、未指定
                return string.Empty;
            }
            else if ( selectedSectionList.Contains( "0" ) )
            {
                // 「全拠点」が選択されていたら、未指定
                return string.Empty;
            }

            // 選択されている拠点コードを返す
            foreach ( object obj in selectedSectionList.Values )
            {
                if ( obj is string )
                {
                    return (obj as string);
                }
            }

            return string.Empty;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		#endregion
		#endregion ◆ ub_St_MainBfAfEnterWarehGuid

		#region ◆ ub_St_ExtractSectionGuid
		#region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがクリックされたときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void ub_St_ExtractSectionGuid_Click ( object sender, EventArgs e )
		{
			int status = 0;
			string getCode = "";
            //string sectionCode = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
            //{
            //    // 在庫移動時
            //    if ( this._secInfoSetAcs == null ) this._secInfoSetAcs = new SecInfoSetAcs();
            //    this._secInfoSet = null;

            //    status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out this._secInfoSet );

            //    if ( status != 0 ) return;

            //    getCode = this._secInfoSet.SectionCode.TrimEnd();
            //}
            //else
            //{
            //    // 倉庫移動
            //    if ( this._wareHouseAcs == null ) this._wareHouseAcs = new WarehouseAcs();
            //    this._wareHouse = null;
            //    // 選択拠点取得
            //    if ( this._selectedSectionList.Count == 1 )
            //    {
            //        foreach( DictionaryEntry de in this._selectedSectionList )
            //        {
            //            sectionCode = de.Value.ToString().TrimEnd();
            //        }
            //    }

            //    status = this._wareHouseAcs.ExecuteGuid( out this._wareHouse, this._enterpriseCode, sectionCode);

            //    if ( status != 0 ) return;

            //    getCode = this._wareHouse.WarehouseCode.TrimEnd();
            //}

            // 在庫移動時
            if ( this._secInfoSetAcs == null )
                this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoSet = null;

            status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out this._secInfoSet );

            if ( status != 0 )
                return;

            getCode = this._secInfoSet.SectionCode.TrimEnd();

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            /* --- DEL 2008/10/02 入庫拠点削除の為 ----------------------------------->>>>>
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.te_St_ShipArrivalSectionCd.DataText = getCode;
                //_nextControl[te_St_ExtractSectionCd].Focus();     // DEL 2008.08.12
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.te_Ed_ShipArrivalSectionCd.DataText = getCode;
                //_nextControl[te_Ed_ExtractSectionCd].Focus();     // DEL 2008.08.12
            }
               --- DEL 2008/10/02 ----------------------------------------------------<<<<< */
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
            //{
            //    // 在庫移動のときは倉庫移動のガイドの表示判断
            //    if ( ( this.te_St_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0 ) || ( this.te_Ed_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0 ) )
            //    {
            //        ExtractWareHouseGuidSetProc( 
            //            this.ub_St_ExtractWareHouseGuid, this.ub_Ed_ExtractWareHouseGuid, 
            //            this.te_St_ExtractSectionCd.DataText, this.te_Ed_ExtractSectionCd.DataText );
            //    }
            //}

            //--- DEL 2008.08.12 ---------->>>>>
            //// 在庫移動のときは倉庫移動のガイドの表示判断
            //if ( (this.te_St_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0) || (this.te_Ed_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0) )
            //{
            //    ExtractWareHouseGuidSetProc(
            //        this.ub_St_ExtractWareHouseGuid, this.ub_Ed_ExtractWareHouseGuid,
            //        this.te_St_ExtractSectionCd.DataText, this.te_Ed_ExtractSectionCd.DataText );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //--- DEL 2008.08.12 ----------<<<<<
        }
		#endregion
		#endregion ◆ ub_St_ExtractSectionGuid

        //--- DEL 2008/08/08 ---------->>>>>
        #region ◆ ub_St_MakerCodeGuid
		#region ◎ Click Event
        ///// <summary>
        ///// Click Event
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note		: コントロールがクリックされたときに発生する。</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.14</br>
        ///// </remarks>
        //private void ub_St_MakerCodeGuid_Click ( object sender, EventArgs e )
        //{
        //    if ( this._makerInfoAcs == null ) {	this._makerInfoAcs = new MakerAcs(); }
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //this._makerInfo = new Maker();
        //    this._makerInfo = new MakerUMnt();
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    int status = this._makerInfoAcs.ExecuteGuid( this._enterpriseCode, out this._makerInfo );

        //    if ( status != 0 )
        //    {
        //        return;
        //    }

        //    if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
        //    {
        //        this.tne_St_MakerCode.SetInt( this._makerInfo.GoodsMakerCd );
        //        _nextControl[tne_St_MakerCode].Focus();
        //    }
        //    else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
        //    {
        //        this.tne_Ed_MakerCode.SetInt( this._makerInfo.GoodsMakerCd );
        //        _nextControl[tne_Ed_MakerCode].Focus();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        #endregion
        #endregion ◆ ub_St_MakerCodeGuid
        //--- DEL 2008/08/08 ----------<<<<<

        //--- DEL 2008/08/08 ---------->>>>>
        #region ◆ ub_St_GoodsGuid
		#region ◎ Click Event
        ///// <summary>
        ///// Click Event
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note		: コントロールがクリックされたときに発生する。</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.14</br>
        ///// </remarks>
        //private void ub_St_GoodsGuid_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsGuid == null )
        //    {
        //        this._goodsGuid = new MAKHN04110UA();
        //    }

        //    this._goodsUnitData = null;
        //    DialogResult status = this._goodsGuid.ShowGuide(this, this._enterpriseCode, out this._goodsUnitData );

        //    if ( status != DialogResult.OK )
        //    {
        //        return;
        //    }

        //    if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
        //    { 
        //        this.te_St_GoodsNo.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
        //        _nextControl[te_St_GoodsNo].Focus();
        //    }
        //    else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 ) 
        //    { 
        //        this.te_Ed_GoodsNo.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
        //        _nextControl[te_Ed_GoodsNo].Focus();
        //    }
        //    else
        //    {
        //        return;
        //    }


        //}
        #endregion
		#endregion ◆ ub_St_GoodsGuid
        //--- DEL 2008/08/08 ----------<<<<<

		#region ◆ tne_St_StockMoveSlipNo
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void tne_St_StockMoveSlipNo_Leave ( object sender, EventArgs e )
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( (TNedit)sender ).DataText == string.Empty )
            //{
            //    ( (TNedit)sender ).SetInt( 0 );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}
		#endregion
		#endregion ◆ tne_St_StockMoveSlipNo

		#region ◆ tne_Ed_StockMoveSlipNo
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void tne_Ed_StockMoveSlipNo_Leave ( object sender, EventArgs e )
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白またはゼロの場合は初期値をセット
            //if ( ( ( (TNedit)sender ).DataText == string.Empty ) || ( ( (TNedit)sender ).GetInt() == 0 ) ) 
            //{
            //    ( (TNedit)sender ).SetInt( 999999999 );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}
		#endregion
		#endregion ◆ tne_Ed_StockMoveSlipNo

		#region ◆ tne_St_MakerCode
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void tne_St_MakerCode_Leave ( object sender, EventArgs e )
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( (TNedit)sender ).DataText == string.Empty )
            //{
            //    ( (TNedit)sender ).SetInt( 0 );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}
		#endregion
		#endregion ◆ tne_St_MakerCode_Leave

		#region ◆ tne_Ed_MakerCode
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void tne_Ed_MakerCode_Leave ( object sender, EventArgs e )
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( ((TNedit)sender).DataText == string.Empty ) || ( ((TNedit)sender).GetInt() == 0 ) )
            //{
            //    ((TNedit)sender).SetInt( 999999 );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}
		#endregion
		#endregion ◆ tne_Ed_MakerCode

		#region ◆ te_St_ExtractSectionCd
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void te_St_ExtractSectionCd_Leave ( object sender, EventArgs e )
		{
            //--- DEL 2008.08.12 ---------->>>>>
            //if (this.te_St_ExtractSectionCd.DataText.TrimEnd().CompareTo("") != 0)
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_ExtractWareHouseGuid, this.ub_Ed_ExtractWareHouseGuid, 
            //        this.te_St_ExtractSectionCd.DataText, this.te_Ed_ExtractSectionCd.DataText );
            //}
            //--- DEL 2008.08.12 ----------<<<<<
        }
		#endregion
		#endregion ◆ te_St_ExtractSectionCd

		#region ◆ te_Ed_ExtractSectionCd
		#region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.14</br>
        /// </remarks>
		private void te_Ed_ExtractSectionCd_Leave ( object sender, EventArgs e )
		{
            //--- DEL 2008.08.12 ---------->>>>>
            //if ( this.te_Ed_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0 )
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_ExtractWareHouseGuid, this.ub_Ed_ExtractWareHouseGuid, 
            //        this.te_St_ExtractSectionCd.DataText, this.te_Ed_ExtractSectionCd.DataText );
            //}
            //--- DEL 2008.08.12 ----------<<<<<
        }
		#endregion
		#endregion ◆ te_Ed_ExtractSectionCd

        //--- DEL 2008.08.12 ---------->>>>>
		#region ◆ uos_ShipmentArrivalDiv_Stock
		#region ◎ ValueChanged Event
        ///// <summary>
        ///// ValueChanged Event
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note		: コントロールの値が変更されたときに発生する。</br>
        ///// <br>Programmer	: 22013 久保 将太</br>
        ///// <br>Date		: 2007.03.14</br>
        ///// </remarks>
        //private void uos_ShipmentArrivalDiv_Stock_ValueChanged ( object sender, EventArgs e )
        //{
        //    // 在庫・倉庫両方の処理区分をここで取得
        //    UltraOptionSet targetOptionSet = (UltraOptionSet)sender;

        //    // 抽出条件に展開
        //    this._stockMoveCndtn.ShipmentArrivalDiv  = ((StockMoveCndtn.ShipmentArrivalDivState)targetOptionSet.Value);

        //    // ラベル名称をセット
        //    SetLabelText();
        //}
		#endregion
		#endregion ◆ uos_ShipmentArrivalDiv_Stock
        //--- DEL 2008.08.12 ----------<<<<<
        #endregion ■ Control Event


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_StockMvEmpGuid_Click ( object sender, EventArgs e )
        {
            if ( this._employeeAcs == null )
            {
                this._employeeAcs = new EmployeeAcs();
            }

            this._employee = null;
            int status = this._employeeAcs.ExecuteGuid( this._enterpriseCode, true, out this._employee );

            if ( status != 0 )
                return;

            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 ) 
            { 
                this.tEdit_EmployeeCode_St.DataText = this._employee.EmployeeCode.TrimEnd();
                //_nextControl[te_St_EmployeeCode].Focus(); // DEL 2008.08.12
                this.tEdit_EmployeeCode_Ed.Focus();     //ADD 2008/10/02
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                this.tEdit_EmployeeCode_Ed.DataText = this._employee.EmployeeCode.TrimEnd();
                //_nextControl[te_Ed_EmployeeCode].Focus(); // DEL 2008.08.12
                this.tde_St_ShipArrivalDate.Focus();    //ADD 2008/10/02
            }
            else
            {
                return;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //--- ADD 2008.08.12 ---------->>>>>
        /// <summary>
        /// 発行タイプ変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ce_PrintType_ValueChanged(object sender, EventArgs e)
        {
            if ((int)ce_PrintType.Value == 1)
            {
                ul_MainBfAfEnterWarehTitle.Text = "入庫倉庫";
                //ul_ShipArrivalSectionTitle.Text = "出庫拠点";         //DEL 2008/10/02 入庫拠点削除の為
                ul_ShipArrivalEnterWarehTitle.Text = "出庫倉庫";
            }
            else
            {
                ul_MainBfAfEnterWarehTitle.Text = "出庫倉庫";
                //ul_ShipArrivalSectionTitle.Text = "入庫拠点";         //DEL 2008/10/02 入庫拠点削除の為
                ul_ShipArrivalEnterWarehTitle.Text = "入庫倉庫";
            }
        }
        //--- ADD 2008.08.12 ----------<<<<<
        //--- ADD 2008/10/02 ------------------------------------------------------->>>>>
        private void AddZero()
        {
            // 全項目に対して0詰め

            // 出庫倉庫From
            if (string.IsNullOrEmpty(this.te_St_MainBfAfEnterWarehCd.Text) == false)
            {
                this.te_St_MainBfAfEnterWarehCd.Text = this.te_St_MainBfAfEnterWarehCd.Text.PadLeft(4, '0');           
            }
            // 出庫倉庫To
            if (string.IsNullOrEmpty(this.te_Ed_MainBfAfEnterWarehCd.Text) == false)
            {
                this.te_Ed_MainBfAfEnterWarehCd.Text = this.te_Ed_MainBfAfEnterWarehCd.Text.PadLeft(4, '0');
            }
            // 入庫倉庫From
            if (string.IsNullOrEmpty(this.te_St_ShipArrivalEnterWarehCd.Text) == false)
            {
                this.te_St_ShipArrivalEnterWarehCd.Text = this.te_St_ShipArrivalEnterWarehCd.Text.PadLeft(4, '0');
            }
            // 入庫倉庫To
            if (string.IsNullOrEmpty(this.te_Ed_ShipArrivalEnterWarehCd.Text) == false)
            {
                this.te_Ed_ShipArrivalEnterWarehCd.Text = this.te_Ed_ShipArrivalEnterWarehCd.Text.PadLeft(4, '0');
            }
       }
        //--- ADD 2008/10/02 -------------------------------------------------------<<<<<
    }
}