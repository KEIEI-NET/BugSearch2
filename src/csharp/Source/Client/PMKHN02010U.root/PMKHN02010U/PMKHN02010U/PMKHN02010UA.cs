//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率マスタ印刷
// プログラム概要   ：掛率マスタの印刷を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/10/15     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/10/29     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/11     修正内容：Mantis【13470】掛率設定区分ガイドのエラー対応
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：李占川
// 修正日    2011/07/22     修正内容：NSユーザー改良要望一覧の連番898の対応
// ---------------------------------------------------------------------//

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
using Broadleaf.Application.Controller.Util;  
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
    /// 掛率マスタ印刷UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ印刷UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.15</br>
    /// ---------------------------------------------------------------
    /// <br>UpdateNote   : 2008/10/29 30462 行澤 仁美　バグ修正</br>
    /// ---------------------------------------------------------------
    /// <br>Update Note  : 2011/07/22 李占川 NSユーザー改良要望一覧の連番898の対応</br>
    /// </remarks>
	public partial class PMKHN02010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
        /// 掛率マスタ印刷UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 掛率マスタ印刷UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
		/// <br></br>
		/// </remarks>
		public PMKHN02010UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

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
        private RatePrtReqCndtn _ratePrtReqCndtn;

        // 掛率設定区分ガイド用
        private RateProtyMngAcs _rateProtyMngAcs = null;

        // 得意先ガイド選択フラグ
        private bool _cusotmerGuideSelected;
        private string _cusotmerGuidecode;
        // 仕入先
        SupplierAcs _supplierAcs;

        // 商品コード用
        private MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        private GoodsAcs _goodsAcs;
        private GoodsUnitData _goodsUnitData;

        // 商品掛率ｸﾞﾙｰﾌﾟ
        GoodsGroupUAcs _goodsGroupUAcs;

        // BLグループ
        BLGroupUAcs _bLGroupUAcs;

        // BLアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;			

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "PMKHN02010UA";
		// プログラムID
        private const string ct_PGID            = "PMKHN02010U";
		//// 帳票名称
        private string _printName               = "掛率マスタ印刷";
        // 帳票キー	
        private string _printKey                = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件

        // 出力区分
        private const string LOGICALDELETECODE_1 = "標準";
        private const string LOGICALDELETECODE_2 = "削除分";
        private const string LOGICALDELETECODE_3 = "全て";
        // 単価種類
        private const string UNITPRICEKIND_1 = "売価設定";
        private const string UNITPRICEKIND_2 = "原価設定";
        private const string UNITPRICEKIND_3 = "価格設定";
        // 設定方法
        private const string UNITPRICEKINDWAY_0 = "単品設定";
        private const string UNITPRICEKINDWAY_1 = "グループ設定";

        // --- ADD 2011/07/22 ---------->>>>>
        private const string USERPRICEAPPOINT_1 = "全て";
        private const string USERPRICEAPPOINT_2 = "商品マスタ価格＞ユーザー価格";
        private const string USERPRICEAPPOINT_3 = "商品マスタ価格＝ユーザー価格";
        // --- ADD 2011/07/22  ----------<<<<<

        // ADD 2009/06/11 ------>>>
        // 全社共通
        private const string SECTION_CODE_ALL = "00";
        // ADD 2009/06/11 ------<<<
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
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

			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
            printInfo.jyoken            = this._ratePrtReqCndtn;
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._ratePrtReqCndtn = new RatePrtReqCndtn();

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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>Update Note : 2011/07/22 李占川 NSユーザー改良要望一覧の連番898の対応</br>
        /// <br>              ユーザー価格指定を追加する</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // 出力区分
                this.LogicalDeleteCode_tComboEditor.Items.Clear();
                this.LogicalDeleteCode_tComboEditor.Items.Add("1", LOGICALDELETECODE_1);
                this.LogicalDeleteCode_tComboEditor.Items.Add("2", LOGICALDELETECODE_2);
                this.LogicalDeleteCode_tComboEditor.Items.Add("3", LOGICALDELETECODE_3);
                this.LogicalDeleteCode_tComboEditor.Value = "1";

                // 単価種類
                this.UnitPriceKind_tComboEditor.Items.Clear();
                this.UnitPriceKind_tComboEditor.Items.Add("1", UNITPRICEKIND_1);
                this.UnitPriceKind_tComboEditor.Items.Add("2", UNITPRICEKIND_2);
                this.UnitPriceKind_tComboEditor.Items.Add("3", UNITPRICEKIND_3);
                this.UnitPriceKind_tComboEditor.Value = "1";

                // 設定方法
                this.UnitPriceKindWay_tComboEditor.Items.Clear();
                this.UnitPriceKindWay_tComboEditor.Items.Add("1", UNITPRICEKINDWAY_1);
                this.UnitPriceKindWay_tComboEditor.Items.Add("0", UNITPRICEKINDWAY_0);
                this.UnitPriceKindWay_tComboEditor.Value = "1";

                // --- ADD 2011/07/22 ---------->>>>>
                // ユーザー定価指定
                this.UserPriceAppoint_tComboEditor.Items.Clear();
                this.UserPriceAppoint_tComboEditor.Items.Add("1", USERPRICEAPPOINT_1);
                this.UserPriceAppoint_tComboEditor.Items.Add("2", USERPRICEAPPOINT_2);
                this.UserPriceAppoint_tComboEditor.Items.Add("3", USERPRICEAPPOINT_3);
                this.UserPriceAppoint_tComboEditor.Value = "0";
                this.UserPriceAppoint_tComboEditor.Enabled = false;
                // --- ADD 2011/07/22  ----------<<<<<

                // 初期値セット・文字列
                this.tEdit_RateSettingDivide_St.DataText = string.Empty;
                this.tEdit_RateSettingDivide_Ed.DataText = string.Empty;
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                this.tNedit_CustRateGrpCode_St.DataText = string.Empty;
                this.tNedit_CustRateGrpCode_Ed.DataText = string.Empty;
                this.tNedit_SupplierCd_St.DataText = string.Empty;
                this.tNedit_SupplierCd_Ed.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tEdit_GoodsRateRank_St.DataText = string.Empty;
                this.tEdit_GoodsRateRank_Ed.DataText = string.Empty;
                this.tNedit_GoodsMGroup_St.DataText = string.Empty;
                this.tNedit_GoodsMGroup_Ed.DataText = string.Empty;
                this.tNedit_BLGloupCode_St.DataText = string.Empty;
                this.tNedit_BLGloupCode_Ed.DataText = string.Empty;
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;

                // ボタン設定
                this.SetIconImage( this.ub_St_RateSettingDivide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_RateSettingDivide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage( this.ub_Ed_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage( this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage( this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_MediumGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_MediumGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_DetailGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_DetailGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_BLGoodsCode, Size16_Index.STAR1);
                this.SetIconImage( this.ub_Ed_BLGoodsCode, Size16_Index.STAR1);

                // 初期フォーカスセット
                this.LogicalDeleteCode_tComboEditor.Focus();
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
		/// 入力チェック処理
		/// </summary>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <param name="errComponent">エラー発生コンポーネント</param>
		/// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";

            // 出力区分
            if (this.LogicalDeleteCode_tComboEditor.Value == null)
            {
                errMessage = string.Format("出力区分を選択してください");
                errComponent = this.LogicalDeleteCode_tComboEditor;
                status = false;
            }	
            // 単価種類
            else if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                errMessage = string.Format("単価種別を選択してください");
                errComponent = this.UnitPriceKind_tComboEditor;
                status = false;
            }			
            // 掛率設定区分コード
            else if (
                (this.tEdit_RateSettingDivide_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_RateSettingDivide_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_RateSettingDivide_St.DataText.TrimEnd().CompareTo( this.tEdit_RateSettingDivide_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format( "掛率設定区分{0}", ct_RangeError );
                errComponent = this.tEdit_RateSettingDivide_St;
                status = false;
            }
            // 得意先（開始 > 終了 → NG）
            else if (this.tNedit_CustomerCode_St.GetInt() > GetEndCode(this.tNedit_CustomerCode_Ed))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            // 得意先掛率ｸﾞﾙｰﾌﾟ（開始 > 終了 → NG）
            else if (this.tNedit_CustRateGrpCode_St.GetInt() > GetEndCode(this.tNedit_CustRateGrpCode_Ed))
            {
                errMessage = string.Format("得意先掛率ｸﾞﾙｰﾌﾟ{0}", ct_RangeError);
                errComponent = this.tNedit_CustRateGrpCode_St;
                status = false;
            }
            // 仕入先（開始 > 終了 → NG）
            else if ( this.tNedit_SupplierCd_St.GetInt() > GetEndCode( this.tNedit_SupplierCd_Ed ) )
            {
                errMessage = string.Format( "仕入先{0}", ct_RangeError );
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // メーカー（開始 > 終了 → NG）
            else if ( this.tNedit_GoodsMakerCd_St.GetInt() > GetEndCode( this.tNedit_GoodsMakerCd_Ed ) )
            {
                errMessage = string.Format( "メーカー{0}", ct_RangeError );
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 層別
            else if (
                     (this.tEdit_GoodsRateRank_St.DataText.TrimEnd() != string.Empty) &&
                     (this.tEdit_GoodsRateRank_Ed.DataText.TrimEnd() != string.Empty) &&
                     (this.tEdit_GoodsRateRank_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsRateRank_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("層別{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsRateRank_St;
                status = false;
            }
            // 商品掛率ｸﾞﾙｰﾌﾟ
            else if (this.tNedit_GoodsMGroup_St.GetInt() > GetEndCode(this.tNedit_GoodsMGroup_Ed))         
            {
                errMessage = string.Format("商品掛率ｸﾞﾙｰﾌﾟ{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // グループコード
            else if (this.tNedit_BLGloupCode_St.GetInt() > GetEndCode(this.tNedit_BLGloupCode_Ed))          
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);     
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // BLコード
            else if (this.tNedit_BLGoodsCode_St.GetInt() > GetEndCode(this.tNedit_BLGoodsCode_Ed))          
            {
                errMessage = string.Format("ＢＬｺｰﾄﾞ{0}", ct_RangeError);     
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // 品番
            else if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
            (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>Update Note : 2011/07/22 李占川 NSユーザー改良要望一覧の連番898の対応</br>
        /// <br>              ユーザー価格指定を追加する</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                // 「全拠点」が選択されている場合はリストをクリア
                bool allSections = false;

                foreach ( object obj in _selectedSectionList.Values )
                {
                    if ( obj is string )
                    {
                        if ( (obj as string) == "0" )
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if ( allSections )
                {
                    _selectedSectionList.Clear();
                }
                
                // 拠点オプション
                this._ratePrtReqCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._ratePrtReqCndtn.EnterpriseCode = this._enterpriseCode;

                // 拠点コード
                this._ratePrtReqCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 出力区分
                this._ratePrtReqCndtn.LogicalDeleteCode = int.Parse((string)this.LogicalDeleteCode_tComboEditor.Value);
                // 単価種類
                this._ratePrtReqCndtn.UnitPriceKind = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
                // 設定方法
                this._ratePrtReqCndtn.RateMngGoodsCdKind = int.Parse((string)this.UnitPriceKindWay_tComboEditor.Value);
                // --- ADD 2011/07/22 ---------->>>>>
                // ユーザー価格指定
                if (this.UserPriceAppoint_tComboEditor.Value == null)
                {
                    this._ratePrtReqCndtn.UserPriceAppoint = 0;
                }
                else
                {
                    this._ratePrtReqCndtn.UserPriceAppoint = int.Parse((string)this.UserPriceAppoint_tComboEditor.Value);
                }
                // --- ADD 2011/07/22  ----------<<<<<
                // 開始掛率設定区分
                this._ratePrtReqCndtn.RateSettingDivideSt = this.tEdit_RateSettingDivide_St.DataText;
                // 終了掛率設定区分
                this._ratePrtReqCndtn.RateSettingDivideEd = this.tEdit_RateSettingDivide_Ed.DataText;
                // 開始得意先コード
                this._ratePrtReqCndtn.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                // 終了得意先コード
                this._ratePrtReqCndtn.CustomerCodeEd = GetEndCode(this.tNedit_CustomerCode_Ed, 99999999);
                // 開始得意先掛率グループコード
                this._ratePrtReqCndtn.CustRateGrpCodeSt = this.tNedit_CustRateGrpCode_St.GetInt();
                // 終了得意先掛率グループコード
                this._ratePrtReqCndtn.CustRateGrpCodeEd = GetEndCode(this.tNedit_CustRateGrpCode_Ed, 9999);
                // 開始仕入先コード
                this._ratePrtReqCndtn.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                this._ratePrtReqCndtn.SupplierCdEd = GetEndCode(this.tNedit_SupplierCd_Ed, 999999);
                // 開始商品メーカーコード
                this._ratePrtReqCndtn.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカーコード
                this._ratePrtReqCndtn.GoodsMakerCdEd = GetEndCode(this.tNedit_GoodsMakerCd_Ed, 9999);
                // 開始商品掛率ランク
                this._ratePrtReqCndtn.GoodsRateRankSt = this.tEdit_GoodsRateRank_St.DataText;
                // 終了商品掛率ランク
                this._ratePrtReqCndtn.GoodsRateRankEd = this.tEdit_GoodsRateRank_Ed.DataText;
                // 開始商品掛率グループコード
                this._ratePrtReqCndtn.GoodsRateGrpCodeSt = this.tNedit_GoodsMGroup_St.GetInt();
                // 終了商品掛率グループコード
                this._ratePrtReqCndtn.GoodsRateGrpCodeEd = GetEndCode(this.tNedit_GoodsMGroup_Ed, 9999);
                // 開始BLグループコード
                this._ratePrtReqCndtn.BLGroupCodeSt = this.tNedit_BLGloupCode_St.GetInt();
                // 終了BLグループコード
                this._ratePrtReqCndtn.BLGroupCodeEd = GetEndCode(this.tNedit_BLGloupCode_Ed, 99999);
                // 開始BL商品コード
                this._ratePrtReqCndtn.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了BL商品コード
                this._ratePrtReqCndtn.BLGoodsCodeEd = GetEndCode(this.tNedit_BLGoodsCode_Ed, 99999);
                // 開始商品番号
                this._ratePrtReqCndtn.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;
                // 終了商品番号
                this._ratePrtReqCndtn.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;

            }
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
        
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
        /// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.15</br>
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
        /// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.15</br>
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
        
        // --- ADD 2011/07/22 ---------->>>>>
        # region ユーザー定価指定コンボボックスの有効と無効設定
        /// <summary>
        /// ユーザー定価指定コンボボックスの有効と無効設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー定価指定コンボボックスの有効と無効設定</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/02/11</br>
        /// </remarks>
        private void UserPriceAppointEnableChange()
        {
            // 単価種類：価格設定と設定方法：単品設定　場合
            if (UnitPriceKind_tComboEditor.SelectedIndex == 2
                && UnitPriceKindWay_tComboEditor.SelectedIndex == 1)
            {
                // 有効になる
                this.UserPriceAppoint_tComboEditor.Enabled = true;
                this.UserPriceAppoint_tComboEditor.Value = "1";
            }
            else
            {
                // 無効になる
                this.UserPriceAppoint_tComboEditor.Enabled = false;
                this.UserPriceAppoint_tComboEditor.Value = "0";
            }

        }
        # endregion 
        // --- ADD 2011/07/22  ----------<<<<<
		#endregion ■ Private Method

		#region ■ Control Event
		#region ◆ PMKHN02010UA
		#region ◎ PMKHN02010UA_Load Event
		/// <summary>
        /// PMKHN02010UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.15</br>
        /// </remarks>
        private void PMKHN02010UA_Load(object sender, EventArgs e)
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
		}
		#endregion

        #endregion ◆ PMKHN02010UA

        /// <summary>
        /// 掛率設定区分ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_RateSettingDivide_Click(object sender, EventArgs e)
        {
            int status = 0;
            
            if (this._rateProtyMngAcs == null)
                this._rateProtyMngAcs = new RateProtyMngAcs();

            RateProtyMng rateProtyMng = new RateProtyMng();


            // 拠点コード
            string sectionCode = GetWarehouseGuideSection(this._selectedSectionList);
            // 単価種類
            int unitPriceKind = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
            // 設定方法
            int unitPriceKindWay = int.Parse((string)this.UnitPriceKindWay_tComboEditor.Value);

            // 掛率設定区分ガイド表示
            status = this._rateProtyMngAcs.ExecuteGuid(this._enterpriseCode, sectionCode, unitPriceKind,
                                                       unitPriceKindWay, out rateProtyMng);
                       
            string tag = ( string ) ( ( UltraButton ) sender ).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            {
                targetControl = this.tEdit_RateSettingDivide_St;
                nextControl = this.tEdit_RateSettingDivide_Ed;
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                targetControl = this.tEdit_RateSettingDivide_Ed;
                nextControl = this.tNedit_CustomerCode_St;
            }
            else
            {
                return;
            }

            //targetControl.DataText = rateProtyMng.RateSettingDivide; // DEL 2008/10/29 不具合対応[7163]

            // ADD 2008/10/29 不具合対応[7163] ---------->>>>>
            if (!rateProtyMng.RateSettingDivide.Trim().Equals(string.Empty))
            {
                // コード展開
                targetControl.DataText = rateProtyMng.RateSettingDivide;
            }
            // ADD 2008/10/29 不具合対応[7163] ----------<<<<<
            // フォーカス
            nextControl.Focus();
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 掛率設定区分ガイド用拠点コード取得処理
        /// </summary>
        /// <param name="selectedSectionList"></param>
        /// <returns>掛率設定区分ガイド用の指定拠点コード</returns>
        /// <remarks>
        /// <br>出力対象拠点の選択状況に応じて、拠点コードを返します</br>
        /// </remarks>
        private string GetWarehouseGuideSection( Hashtable selectedSectionList )
        {
            if ( selectedSectionList.Count >= 2 )
            {
                //// 複数拠点が選択されていたら、未指定
                //return string.Empty;      // DEL 2009/06/11
                // 「全社共通」を指定
                return SECTION_CODE_ALL;    // ADD 2009/06/11
            }
            else if ( selectedSectionList.Count == 0 )
            {
                //// 拠点が選択されていなければ、未指定
                //return string.Empty;      // DEL 2009/06/11
                // 「全社共通」を指定
                return SECTION_CODE_ALL;    // ADD 2009/06/11
            }
            else if ( selectedSectionList.Contains( "0" ) )
            {
                //// 「全拠点」が選択されていたら、未指定
                //return string.Empty;      // DEL 2009/06/11
                // 「全社共通」を指定
                return SECTION_CODE_ALL;    // ADD 2009/06/11
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

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_CustomerGuide_Click(object sender, EventArgs e)
        {

            this._cusotmerGuideSelected = false;
            this._cusotmerGuidecode = string.Empty;

            // 得意先ガイド
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_CustomerCode_St;
                nextControl = this.tNedit_CustomerCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_CustomerCode_Ed;
                nextControl = this.tNedit_CustRateGrpCode_St;
            }
            else
            {
                return;
            }

            // コード展開
            if (this._cusotmerGuideSelected == true)
            {
                targetControl.DataText = this._cusotmerGuidecode;
            }
            // フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.16</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 得意先コード
            this._cusotmerGuidecode = customerSearchRet.CustomerCode.ToString().PadLeft(8, '0');

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            Supplier supplier = new Supplier();

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SupplierCd_St;
                nextControl = this.tNedit_SupplierCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SupplierCd_Ed;
                nextControl = this.tNedit_GoodsMakerCd_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt(supplier.SupplierCd);

            // フォーカス移動
            nextControl.Focus();
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click( object sender, EventArgs e )
        {
            if ( this._goodsAcs == null )
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            }

            MakerUMnt maker;
            int status = this._goodsAcs.ExecuteMakerGuid( this._enterpriseCode, out maker );
            if ( status != 0 )
                return;

            TNedit targetControl;
            Control nextControl;
            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                nextControl = this.tEdit_GoodsRateRank_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt( maker.GoodsMakerCd );
            nextControl.Focus();
        }
                
        /// <summary>
        /// 商品掛率ｸﾞﾙｰﾌﾟガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU,false);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_St;
                nextControl = this.tNedit_GoodsMGroup_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_Ed;
                nextControl = this.tNedit_BLGloupCode_St;
            }
            else
            {
                return;
            }
            targetControl.SetInt(goodsGroupU.GoodsMGroup);

            // フォーカス移動
            nextControl.Focus();
        }
        /// <summary>
        /// BLグループガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_DetailGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_St;
                nextControl = this.tNedit_BLGloupCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_Ed;
                nextControl = this.tNedit_BLGoodsCode_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt(bLGroupU.BLGroupCode);

            // フォーカス移動
            nextControl.Focus();
        }
        /// <summary>
        /// 商品番号ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsNoGuid_Click( object sender, EventArgs e )
        {
            if ( this._goodsGuid == null )
            {
                this._goodsGuid = new MAKHN04110UA();
            }

            this._goodsUnitData = null;
            DialogResult status = this._goodsGuid.ShowGuide( this, this._enterpriseCode, out this._goodsUnitData );

            if ( status != DialogResult.OK )
                return;

            TEdit targetControl;
            Control nextControl;
            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            {
                targetControl = this.tEdit_GoodsNo_St;
                nextControl = this.tEdit_GoodsNo_Ed;
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                targetControl = this.tEdit_GoodsNo_Ed;
                nextControl = targetControl;
            }
            else
            {
                return;
            }

            targetControl.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
            nextControl.Focus();
        }

        /// <summary>
        /// ＢＬｺｰﾄﾞガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCode_Click(object sender, EventArgs e)
        {
            int status;
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }


            BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

            // BLコードガイド表示
            status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt(blGoodsCdUMnt.BLGoodsCode);

            // フォーカス移動
            nextControl.Focus();
        }

        /// <summary>
        /// 数値項目開始脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    ( ( TNedit ) sender ).SetInt(0);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// 数値項目終了脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    string maxValueText = new string('9', ((TNedit)sender).ExtEdit.Column);
            //    ( ( TNedit ) sender ).SetInt(Int32.Parse(maxValueText));
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        
        /// <summary>
        /// グループ圧縮イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }

        // --- ADD 2011/07/22 ---------->>>>>
        /// <summary>
        /// 単価種類ValueChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 単価種類ValueChange イベントを行います</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void UnitPriceKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // ユーザー定価指定コンボボックスの有効と無効設定
            this.UserPriceAppointEnableChange();
        }
        
        // --- ADD 2011/07/22 ---------->>>>>
        /// <summary>
        /// 設定方法ValueChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 設定方法ValueChange イベントを行います</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void UnitPriceKindWay_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // ユーザー定価指定コンボボックスの有効と無効設定
            this.UserPriceAppointEnableChange();
        }
        // --- ADD 2011/07/22  ----------<<<<<
		#endregion ■ Control Event
    }
}