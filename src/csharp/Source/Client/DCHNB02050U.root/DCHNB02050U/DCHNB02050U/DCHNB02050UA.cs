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
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12916]：スペースキーでの項目選択機能を実装
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
    /// 売上順位表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上順位表UIフォームクラス</br>
    /// <br>Programmer : 96186 立花 裕輔</br>
    /// <br>Date       : 2007.09.03</br>
    /// <br>Update Note: 2008.09.24 30452 上野 俊治</br>
    /// <br>             ・PM.NS対応</br>
    /// <br>           : 2008/10/27       照田 貴志</br>
    /// <br>             ・バグ修正、仕様変更対応</br>
    /// <br>           : 2008/12/9  30452 上野 俊治</br>
    /// <br>             ・得意先(終了)ガイド設定成功時のフォーカス制御を追加(障害ID8839)</br>
    /// <br>Update Note: 2009.02.12 30452 上野 俊治</br>
    /// <br>            ・障害対応11380</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12184]</br>
    /// <br>Update Note: 2010/01/07 30517 夏野 駿希</br>
    /// <br>            ・Mantis:14874　対象年月入力範囲エラーのコメント修正</br>
    /// <br>Update Note: 2011/08/16 周雨</br>
    /// <br>            ・連番905の障害確認　抽出条件のコード入力しても、右側に対象項目名が出てこない（現場では帳票発行ミスが多発している）</br>
    /// <br>Update Note: 2011/08/30 王飛３</br>
    /// <br>            ・障害報告 #24164　名称のフォント色が全て黒（Black）で統一。</br>
    /// <br>            ・本体ソス改修なし</br>
    /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
    /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
    /// <br>Update Note: 2011/10/31 凌小青</br>
    /// <br>            ・障害報告 #26322</br>
    /// <br>Update Note: 2014/12/16 劉超</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           :・明治産業様Seiken品番変更</br>
    /// <br>Update Note: 2015/03/27 時シン</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : Redmine#44209の#423品番集計区分の名称変更</br>
    /// </remarks>
	public partial class DCHNB02050UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 売上順位表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上順位表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.09.03</br>
		/// <br></br>
		/// </remarks>
		public DCHNB02050UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

			this._employeeAcs = new EmployeeAcs();
            this._supplierAcs = new SupplierAcs(); // ADD 2008/09/24
            this._goodsGroupUAcs = new GoodsGroupUAcs(); // ADD 2008/09/24
            this._userGuideAcs = new UserGuideAcs(); // ADD 2008/09/24
            this._blGroupUAcs = new BLGroupUAcs(); // ADD 2008/09/24
            // ---------------- ADD 2011/08/16 -------------->>>>>>
            this._customerSearchAcs = new CustomerSearchAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            // ---------------- ADD 2011/08/16 --------------<<<<<<
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

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl(); // ADD 2008/09/24
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
		private ShipmGoodsOdrReport _shipmGoodsOdrReport;

		// ガイド系アクセスクラス
		EmployeeAcs _employeeAcs;
		private CompanyInfAcs _companyInfAcs;
		private CompanyInf _companyInf;
        // 仕入先ガイド
        private SupplierAcs _supplierAcs; // ADD 2008/09/24
        // ユーザマスタガイド（商品大分類用）
        private UserGuideAcs _userGuideAcs;
        // 商品中分類ガイド
        private GoodsGroupUAcs _goodsGroupUAcs; // ADD 2008/09/24
        // グループコードガイド
        private BLGroupUAcs _blGroupUAcs; // ADD 2008/09/24
        //----------------------- ADD 2011/08/16------------------->>>>>
        //得意先
        private CustomerSearchAcs _customerSearchAcs;
        //メーカー
        private MakerAcs _makerAcs;
        //BLコード
        private BLGoodsCdAcs _blGoodsCdAcs;
        //----------------------- ADD 2011/08/16-------------------<<<<<
        // 得意先ガイド処理結果
        private bool _customerGuideOK;

		//日付取得部品
		private DateGetAcs _dateGet;

        // 初期設定完了フラグ(イベント制御用)
        private bool _initializeFinished; // ADD 2008/12/09
        //----------------------- ADD 2011/08/16------------------->>>>>
        //仕入先
        private ArrayList _supplierList;
        //得意先
        private CustomerSearchRet[] _customerList;
        //担当者
        private ArrayList _employeeList;
        //メーカー
        private ArrayList _makerList;
        //商品大分類
        private ArrayList _userGuideList;
        //商品中分類
        private ArrayList _goodsGroupUList;
        //BLコード
        private ArrayList _blGoodsCdList;
        //グループコード
        private ArrayList _blGroupUList;
        //未登入
        private string NOT_FOUND = "未登入";
        //----------------------- ADD 2011/08/16-------------------<<<<<

        // ADD 2009/03/31 不具合対応[12916]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>構成比単位ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _constUnitRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 構成比単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>構成比単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper ConstUnitRadioKeyPressHelper
        {
            get { return _constUnitRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 不具合対応[12916]：スペースキーでの項目選択機能を実装 ----------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID = "DCHNB02050UA";
		// プログラムID
		private const string ct_PGID = "DCHNB02050U";
		//// 帳票名称
		private const string PDF_PRINT_NAME = "売上順位表";
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
		const string ct_RangeOverError = "は１ヶ月の範囲内で入力して下さい";
        // 2010/01/07 >>>
        //const string ct_NotOnYearError = "は同一年度内で入力して下さい";
        const string ct_NotOnYearError = "は１２ヶ月の範囲で指定して下さい";
        // 2010/01/07 <<<
        //const string ct_NotOnYearError = "は１２か月以内で入力して下さい";

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

            // 2009.03.19 30413 犬飼 PDFファイル名の修正対応 >>>>>>START
            // --- ADD 2008/09/24 -------------------------------->>>>>
            //起動モード別に帳票の設定コードをセット
            switch (this._mode)
            {
                //商品別、得意先別、担当者別
                case 0:
                //case 2:
                //case 3:
                    {
                        printInfo.PrintPaperSetCd = 0;
                        break;
                    }
                //BLコード別
                case 1:
                    {
                        printInfo.PrintPaperSetCd = 1;
                        break;
                    }
                // 得意先別
                case 2:
                    {
                        printInfo.PrintPaperSetCd = 2;
                        break;
                    }
                // 担当者別
                case 3:
                    {
                        printInfo.PrintPaperSetCd = 3;
                        break;
                    }
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<
            // 2009.03.19 30413 犬飼 PDFファイル名の修正対応 <<<<<<END
            
#if False
			printInfo.PrintPaperSetCd	= (int)this._shipmGoodsOdrReport.StockMoveFormalDiv;
#endif
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._shipmGoodsOdrReport;
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

            // 同条件で、改頁を選択不可に修正したため、チェック不要。
            // --- DEL 2008/12/11 -------------------------------->>>>>
            //// --- ADD 2008/12/11 -------------------------------->>>>>
            //// 集計方法「全社」かつ改頁「拠点」選択時、改頁ができないので警告
            //if (status)
            //{
            //    if ((int)this.tComboEditor_TtlType.SelectedItem.DataValue == 0
            //        && (int)this.tComboEditor_CrMode.SelectedItem.DataValue == 1) // 拠点
            //    {
            //        string message = "集計方法が全社のため改頁されませんが、よろしいですか？";

            //        // メッセージを表示
            //        DialogResult result = this.WarnMsgDispProc(emErrorLevel.ERR_LEVEL_QUESTION, message, 0);

            //        if (result == DialogResult.Yes)
            //        {
            //            // 続行
            //            return true;
            //        }
            //        else
            //        {
            //            // 処理を中断して改頁にフォーカス
            //            this.tComboEditor_CrMode.Focus();
            //            return false;
            //        }
            //    }
            //}
            //// --- ADD 2008/12/11 --------------------------------<<<<<
            //// --- ADD 2008/09/24 -------------------------------->>>>>
            //// 改頁と小計印刷のチェック
            //if (status)
            //{
            //    // 商品別で改頁"仕入先"で明細単位に仕入先が含まれない場合は警告
            //    if (this._mode == 0
            //        && (int)this.tComboEditor_CrMode.SelectedItem.DataValue == 4
            //        && ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 1
            //            || (int)this.tComboEditor_Detail.SelectedItem.DataValue == 3
            //            || (int)this.tComboEditor_Detail.SelectedItem.DataValue == 4))
            //    {
            //        string message = "仕入先が明細単位に含まれないので改頁されませんが、よろしいですか？";
                    
            //        // メッセージを表示
            //        DialogResult result = this.WarnMsgDispProc(emErrorLevel.ERR_LEVEL_QUESTION, message, 0);

            //        if (result == DialogResult.Yes)
            //        {
            //            // 続行
            //            return true;
            //        }
            //        else
            //        {
            //            // 処理を中断して改頁にフォーカス
            //            this.tComboEditor_CrMode.Focus();
            //            return false;
            //        }
            //    }
            //}
            //// --- ADD 2008/09/24 --------------------------------<<<<<
            // --- DEL 2008/12/11 --------------------------------<<<<<

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
			this._shipmGoodsOdrReport = new ShipmGoodsOdrReport();

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
					//0:商品別 1:BLコード別 2:得意先別 3:担当者別
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

                // --- ADD 2008/09/24 -------------------------------->>>>>
                // UI設定保存コンポーネント設定
                this.uiMemInput1.OptionCode = this._mode.ToString();
                // --- ADD 2008/09/24 --------------------------------<<<<<
			}

#if False
			// 抽出条件に起動パラメータをセット
			if ( parameter.ToString().CompareTo( "1" ) == 0 )
			{
				this._shipmGoodsOdrReport.StockMoveFormalDiv = ShipmGoodsOdrReport.StockMoveFormalDivState.StockMove;
				this._printKey = "461a402f-20c6-4b5e-817f-790237550131";
			}
			else if ( parameter.ToString().CompareTo( "2" ) == 0 )
			{
				this._shipmGoodsOdrReport.StockMoveFormalDiv = ShipmGoodsOdrReport.StockMoveFormalDivState.WareHouseMove;
				this._printKey = "edded41e-2702-4de3-95b7-3518c5fae7b1";
			}
			else
				TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK );

			this._printName = this._shipmGoodsOdrReport.StockMoveFormalDivName;
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
				if ( this._shipmGoodsOdrReport.StockMoveFormalDiv == ShipmGoodsOdrReport.StockMoveFormalDivState.WareHouseMove )
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
				if ( this._shipmGoodsOdrReport.StockMoveFormalDiv == ShipmGoodsOdrReport.StockMoveFormalDivState.WareHouseMove )
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
		/// ----------------------------------------------------------------------------------
		/// <br>Note		: 印刷範囲の初期値を「1～999999999」から「設定しない」に変更</br>
		/// <br>Programmer	: 30191 馬淵 愛</br>
		/// <br>Date		: 2008.04.07</br>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
		/// </remarks>
		private int InitializeScreen( out string errMsg )
		{
            // --- DEL 2008/09/24 -------------------------------->>>>>
            //Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            //Infragistics.Win.ValueListItem sec0 = new Infragistics.Win.ValueListItem();
            //Infragistics.Win.ValueListItem sec1 = new Infragistics.Win.ValueListItem();
            //Infragistics.Win.ValueListItem sec2 = new Infragistics.Win.ValueListItem();
            //Infragistics.Win.ValueListItem sec3 = new Infragistics.Win.ValueListItem();
            // --- DEL 2008/09/24 --------------------------------<<<<<

            this._initializeFinished = false;

            Infragistics.Win.ValueListItem listItem; // ADD 2008/09/24

			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
            {
                #region 出力条件
                //売上日付
                /* ---ADD 2009/03/05 不具合対応[12184] -------------------------------->>>>>
				DateTime staratDate;
				DateTime endDate;
				this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

				this.tde_SalesDateSt.SetDateTime(staratDate);
				this.tde_SalesDateEd.SetDateTime(endDate);
                   ---ADD 2009/03/05 不具合対応[12184] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12184] -------------------------------->>>>>
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
                    this.tde_SalesDateEd.SetDateTime(currentTotalMonth);
                    this.tde_SalesDateSt.SetDateTime(currentTotalMonth.AddMonths(-11));
                }
                else
                {
                    // 当月を設定
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);
                    this.tde_SalesDateEd.SetDateTime(nowYearMonth);
                    this.tde_SalesDateSt.SetDateTime(nowYearMonth.AddMonths(-11));
                }
                // ---ADD 2009/03/05 不具合対応[12184] --------------------------------<<<<<

                //集計方法
                this.tComboEditor_TtlType.Value = 1;

                //売上在庫取寄せ区分(在取区分)
                this.tComboEditor_SalesOrderDivCd.Value = 0;

                //金額単位
                this.tComboEditor_MoneyUnit.Value = 0;

                //順位付設定1
				this.tComboEditor_Order1.Value = 0;

				//順位付設定2
				this.tComboEditor_Order2.Value = 0;

				//順位付設定3
				this.tNedit_Order3.SetInt(999999999);

                //印刷範囲指定
                //08.04.07 Mabuchi Delete START------------------
                //this.tNedit_PrintRangeSt.SetInt(1);
                //this.tNedit_PrintRangeEd.SetInt(999999999);
                //08.04.07 Mabuchi Delete END--------------------

                //小計印刷
                // --- DEL 2008/09/24 -------------------------------->>>>>
                //this.CheckEditor_SubtotalSection.Checked = true;
                //this.CheckEditor_SubtotalMaker.Checked = true;
                ////this.CheckEditor_SubtotalGoods.Checked = true; // DEL 2008/09/24
                //this.CheckEditor_SubtotalBl.Checked = true;
                //this.CheckEditor_SubtotalCustomer.Checked = true;
                //this.CheckEditor_SubtotalSalesEmployee.Checked = true;
                // --- DEL 2008/09/24 --------------------------------<<<<<
                // --- ADD 2008/09/24 -------------------------------->>>>>
                
                // 高さ調整
                this.ueb_MainExplorerBar.Groups[0].Settings.ContainerHeight = 180; // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
                
                if (_mode == 0) // 商品別
                {
                    // --- DEL 2008/12/11 -------------------------------->>>>>
                    ////改頁listBox
                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 0;
                    //listItem.DataValue = 0;
                    //listItem.DisplayText = "なし";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 1;
                    //listItem.DataValue = 1;
                    //listItem.DisplayText = "拠点";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 4;
                    //listItem.DataValue = 4;
                    //listItem.DisplayText = "仕入先";
                    //this.tComboEditor_CrMode.Items.Add(listItem);
                    // --- DEL 2008/12/11 -------------------------------->>>>>

                    // 印刷範囲を表示
                    this.printRange_panel.Visible = true;
                    this.subtotal_panel.Location = this.constUnit_panel.Location;

                    // 小計印刷項目設定
                    this.CheckEditor_SubtotalSection.Visible = true;
                    this.CheckEditor_SubtotalSupplier.Visible = true;
                    this.CheckEditor_SubtotalMaker.Visible = true;
                    this.CheckEditor_SubtotalGoodsMGroup.Visible = true;
                    this.CheckEditor_SubtotalBl.Visible = true;

                    this.CheckEditor_SubtotalSection.Checked = true;
                    this.CheckEditor_SubtotalSupplier.Checked = true;
                    this.CheckEditor_SubtotalMaker.Checked = true;
                    this.CheckEditor_SubtotalGoodsMGroup.Checked = true;
                    this.CheckEditor_SubtotalBl.Checked = true;

                    //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                    // 品番集計区分
                    this.ultraLabel30.Visible = true;
                    this.ultraLabel30.Location = new Point(3, 28);
                    this.tComboEditor_GoodsNoTtlDiv.Visible = true;
                    this.tComboEditor_GoodsNoTtlDiv.Location = new Point(140, 27);
                    this.tComboEditor_GoodsNoTtlDiv.Value = 0;
                    

                    // 品番表示区分
                    this.ultraLabel17.Visible = true;
                    this.ultraLabel17.Location = new Point(298, 28);
                    this.tComboEditor_GoodsNoShowDiv.Visible = true;
                    this.tComboEditor_GoodsNoShowDiv.Value = 0;
                    this.tComboEditor_GoodsNoShowDiv.Location = new Point(407, 27);
                    //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                    // 位置調整
                    this.CheckEditor_SubtotalGoodsMGroup.Location = new Point(360, 3);
                    this.CheckEditor_SubtotalBl.Location = new Point(465, 3);

                    // 高さ調整
                    this.ueb_MainExplorerBar.Groups[0].Settings.ContainerHeight = 210; // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
                }
                else if (_mode == 1) // BLコード別
                {
                    // --- DEL 2008/12/11 -------------------------------->>>>>
                    ////改頁listBox
                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 0;
                    //listItem.DataValue = 0;
                    //listItem.DisplayText = "なし";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 1;
                    //listItem.DataValue = 1;
                    //listItem.DisplayText = "拠点";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 4;
                    //listItem.DataValue = 4;
                    //listItem.DisplayText = "仕入先";
                    //this.tComboEditor_CrMode.Items.Add(listItem);
                    // --- DEL 2008/12/11 --------------------------------<<<<<

                    // 構成比単位を表示
                    this.constUnit_panel.Visible = true;
                    this.subtotal_panel.Location = this.constUnit_panel.Location;
                    this.constUnit_panel.Location = this.printRange_panel.Location;

                    // 小計印刷項目設定
                    this.CheckEditor_SubtotalSection.Visible = true;
                    this.CheckEditor_SubtotalSupplier.Visible = true;
                    this.CheckEditor_SubtotalMaker.Visible = true;
                    this.CheckEditor_SubtotalGoodsLGroup.Visible = true;
                    this.CheckEditor_SubtotalGoodsMGroup.Visible = true;
                    this.CheckEditor_SubtotalGroupCode.Visible = true;

                    this.CheckEditor_SubtotalSection.Checked = true;
                    this.CheckEditor_SubtotalSupplier.Checked = true;
                    this.CheckEditor_SubtotalMaker.Checked = true;
                    this.CheckEditor_SubtotalGoodsLGroup.Checked = true;
                    this.CheckEditor_SubtotalGoodsMGroup.Checked = true;
                    this.CheckEditor_SubtotalGroupCode.Checked = true;
                    //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                    // 品番集計区分
                    this.tComboEditor_GoodsNoTtlDiv.Enabled = false;
                    // 品番表示区分
                    this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                    //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                }
                else if (_mode == 2) // 得意先別
                {
                    // --- DEL 2008/12/11 -------------------------------->>>>>
                    ////改頁listBox
                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 0;
                    //listItem.DataValue = 0;
                    //listItem.DisplayText = "なし";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 1;
                    //listItem.DataValue = 1;
                    //listItem.DisplayText = "拠点";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 2;
                    //listItem.DataValue = 2;
                    //listItem.DisplayText = "得意先";
                    //this.tComboEditor_CrMode.Items.Add(listItem);
                    // --- DEL 2008/12/11 --------------------------------<<<<<

                    // 印刷範囲を表示
                    this.printRange_panel.Visible = true;
                    this.subtotal_panel.Location = this.constUnit_panel.Location;

                    // 小計印刷項目設定
                    this.CheckEditor_SubtotalSection.Visible = true;
                    this.CheckEditor_SubtotalCustomer.Visible = true;
                    this.CheckEditor_SubtotalMaker.Visible = true;
                    this.CheckEditor_SubtotalGroupCode.Visible = true;

                    this.CheckEditor_SubtotalSection.Checked = true;
                    this.CheckEditor_SubtotalCustomer.Checked = true;
                    this.CheckEditor_SubtotalMaker.Checked = true;
                    this.CheckEditor_SubtotalGroupCode.Checked = true;

                    // 位置調整
                    this.CheckEditor_SubtotalCustomer.Location = new Point(199, 3);
                    this.CheckEditor_SubtotalMaker.Location = new Point(273, 3);
                    this.CheckEditor_SubtotalGroupCode.Location = new Point(359, 3);
                    //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                    // 品番集計区分
                    this.tComboEditor_GoodsNoTtlDiv.Enabled = false;
                    // 品番表示区分
                    this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                    //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                }
                else if (_mode == 3) // 担当者別
                {
                    // --- DEL 2008/12/11 -------------------------------->>>>>
                    ////改頁listBox
                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 0;
                    //listItem.DataValue = 0;
                    //listItem.DisplayText = "なし";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 1;
                    //listItem.DataValue = 1;
                    //listItem.DisplayText = "拠点";
                    //this.tComboEditor_CrMode.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 3;
                    //listItem.DataValue = 3;
                    //listItem.DisplayText = "担当者";
                    //this.tComboEditor_CrMode.Items.Add(listItem);
                    // --- DEL 2008/12/11 -------------------------------->>>>>

                    // 印刷範囲を表示
                    this.printRange_panel.Visible = true;
                    this.subtotal_panel.Location = this.constUnit_panel.Location;

                    // 小計印刷項目設定
                    this.CheckEditor_SubtotalSection.Visible = true;
                    this.CheckEditor_SubtotalSalesEmployee.Visible = true;
                    this.CheckEditor_SubtotalMaker.Visible = true;

                    this.CheckEditor_SubtotalSection.Checked = true;
                    this.CheckEditor_SubtotalSalesEmployee.Checked = true;
                    this.CheckEditor_SubtotalMaker.Checked = true;
                    //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                    // 品番集計区分
                    this.tComboEditor_GoodsNoTtlDiv.Enabled = false;
                    // 品番表示区分
                    this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                    //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                    // 位置調整
                    this.CheckEditor_SubtotalSalesEmployee.Location = new Point(199, 3);
                    this.CheckEditor_SubtotalMaker.Location = new Point(275, 3);
                }

                // 高さ調整
                //this.ueb_MainExplorerBar.Groups[0].Settings.ContainerHeight = 180; // DEL 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
                // --- ADD 2008/09/24 --------------------------------<<<<<
                #endregion

                #region 発行タイプ

                // --- DEL 2008/09/24 -------------------------------->>>>>
                ////明細単位
                //this.tComboEditor_Detail.Value = 0;
                //SettComboEditor_Detail();

                ////順位設定
                //this.tComboEditor_SortItem.Value = 0;

                ////印刷タイプ
                //this.tComboEditor_PrintType.Value = 0;
                // --- DEL 2008/09/24 --------------------------------<<<<<

                if (_mode == 0) // 商品別
                {
                    //明細単位表示
                    this.detail_panel.Visible = true;
                    this.sort_panel.Visible = true;

                    //明細単位
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 0;
                    listItem.DataValue = 0;
                    listItem.DisplayText = "仕入先＋メーカー＋商品中分類＋ＢＬコード＋品番";
                    this.tComboEditor_Detail.Items.Add(listItem);

                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 1;
                    listItem.DataValue = 1;
                    listItem.DisplayText = "メーカー＋商品中分類＋ＢＬコード＋品番";
                    this.tComboEditor_Detail.Items.Add(listItem);

                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 2;
                    listItem.DataValue = 2;
                    listItem.DisplayText = "仕入先＋メーカー＋品番";
                    this.tComboEditor_Detail.Items.Add(listItem);

                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 3;
                    listItem.DataValue = 3;
                    listItem.DisplayText = "メーカー＋品番";
                    this.tComboEditor_Detail.Items.Add(listItem);

                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 4;
                    listItem.DataValue = 4;
                    listItem.DisplayText = "メーカー＋商品中分類＋品番";
                    this.tComboEditor_Detail.Items.Add(listItem);

                    //----------ADD BY  凌小青　on 2011/10/31 for Redmine#26322------------>>>>>>>>>>>>>
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 5;
                    listItem.DataValue = 5;
                    listItem.DisplayText = "品番";
                    this.tComboEditor_Detail.Items.Add(listItem);
                    //----------ADD BY  凌小青　on 2011/10/31 for Redmine#26322------------<<<<<<<<<<<<<

                    // 明細単位初期値(仕入先＋メーカー＋商品中分類＋ＢＬコード＋品番)
                    this.tComboEditor_Detail.Value = 0;

                    // 順位設定
                    this.SetSortItemList();

                    // 印刷タイプ
                    this.ultraLabel_PrintType.Visible = true;
                    this.tComboEditor_PrintType.Visible = true;
                    this.tComboEditor_PrintType.Value = 0;
                }
                else if (_mode == 1) // BLコード別
                {
                    //明細単位非表示
                    this.sort_panel.Visible = true;
                    this.sort_panel.Location = this.detail_panel.Location;

                    // 順位設定
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 0;
                    listItem.DataValue = 2;
                    listItem.DisplayText = "売上金額";
                    this.tComboEditor_SortItem.Items.Add(listItem);

                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 1;
                    listItem.DataValue = 3;
                    listItem.DisplayText = "粗利金額";
                    this.tComboEditor_SortItem.Items.Add(listItem);

                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 2;
                    listItem.DataValue = 0;
                    listItem.DisplayText = "数量";
                    this.tComboEditor_SortItem.Items.Add(listItem);

                    // 初期値(数量)
                    this.tComboEditor_SortItem.Value = 2;

                    // 高さ調整
                    this.ueb_MainExplorerBar.Groups[1].Settings.ContainerHeight = 40;
                }
                else if (_mode == 2) // 得意先別
                {
                    //明細単位表示
                    this.detail_panel.Visible = true;
                    this.sort_panel.Visible = true;

                    //明細単位
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 0;
                    listItem.DataValue = 0;
                    listItem.DisplayText = "品番";
                    this.tComboEditor_Detail.Items.Add(listItem);

                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 1;
                    listItem.DataValue = 1;
                    listItem.DisplayText = "グループコード";
                    this.tComboEditor_Detail.Items.Add(listItem);

                    // 明細単位初期値(品番)
                    this.tComboEditor_Detail.Value = 0;

                    // 順位設定
                    this.SetSortItemList();

                    // 印刷タイプ
                    this.ultraLabel_PrintType.Visible = true;
                    this.tComboEditor_PrintType.Visible = true;
                    this.tComboEditor_PrintType.Value = 0;
                }
                else if (_mode == 3) // 担当者別
                {
                    //明細単位非表示
                    this.sort_panel.Visible = true;
                    this.sort_panel.Location = this.detail_panel.Location;

                    // 順位設定
                    this.SetSortItemList();

                    // 印刷タイプ
                    this.ultraLabel_PrintType.Visible = true;
                    this.tComboEditor_PrintType.Visible = true;
                    this.tComboEditor_PrintType.Value = 0;

                    // 高さ調整
                    this.ueb_MainExplorerBar.Groups[1].Settings.ContainerHeight = 40;
                }

                // --- ADD 2008/12/11 -------------------------------->>>>>
                // 改頁設定
                this.SetNewPageDiv();

                // 改頁初期値(拠点)
                this.tComboEditor_CrMode.Value = 1;
                // --- ADD 2008/12/11 --------------------------------<<<<<

                #endregion

                #region 抽出条件
                // --- DEL 2008/09/24 -------------------------------->>>>>
                ////商品メーカーコード
                //this.tNedit_GoodsMakerCd_St.Clear();
                //this.tNedit_GoodsMakerCd_Ed.Clear();
                                
                ////商品区分グループコード
                //this.tEdit_LargeGoodsGanreCodeSt.DataText = string.Empty;
                //this.tEdit_LargeGoodsGanreCodeEd.DataText = string.Empty;

                ////商品区分コード
                //this.tEdit_MediumGoodsGanreCodeSt.DataText = string.Empty;
                //this.tEdit_MediumGoodsGanreCodeEd.DataText = string.Empty;

                ////商品区分詳細コード
                //this.tEdit_DetailGoodsGanreCodeSt.DataText = string.Empty;
                //this.tEdit_DetailGoodsGanreCodeEd.DataText = string.Empty;
                
                //// 得意先
                //this.tNedit_CustomerCode_St.Clear();
                //this.tNedit_CustomerCode_Ed.Clear();

                ////BL商品コード
                //this.tNedit_BLGoodsCode_St.Clear();
                //this.tNedit_BLGoodsCode_Ed.Clear();

                ////商品番号
                //this._shipmGoodsOdrReport.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;
                //this._shipmGoodsOdrReport.GoodsNoEd = this.tEdit_GoodsNo_St.DataText;

                ////得意先コード
                //this.tNedit_CustomerCode_St.Clear();
                //this.tNedit_CustomerCode_Ed.Clear();

                ////販売従業員コード
                //this._shipmGoodsOdrReport.SalesEmployeeCdSt = this.tEdit_EmployeeCode_St.DataText;
                //this._shipmGoodsOdrReport.SalesEmployeeCdEd = this.tEdit_EmployeeCode_Ed.DataText;
                // --- DEL 2008/09/24 --------------------------------<<<<<

                // --- ADD 2008/09/24 -------------------------------->>>>>
                if (_mode == 0) // 商品別
                {
                    this.supplier_panel.Visible = true;
                    this.maker_panel.Visible = true;
                    this.goodsLGroup_panel.Visible = true;
                    this.goodsMGroup_panel.Visible = true;
                    this.blGloupRange_panel.Visible = true;
                    this.blGloup_panel.Visible = true;
                    this.blGoods_panel.Visible = true;
                    this.goodsNo_panel.Visible = true;

                    // 位置調整                   
                    this.goodsNo_panel.Location = this.blGloup_panel.Location;
                    this.blGoods_panel.Location = this.blGloupRange_panel.Location;
                    this.blGloup_panel.Location = this.goodsMGroup_panel.Location;
                    this.blGloupRange_panel.Location = this.goodsLGroup_panel.Location;
                    this.goodsMGroup_panel.Location = this.maker_panel.Location;
                    this.goodsLGroup_panel.Location = this.customer_panel.Location;
                    this.maker_panel.Location = this.salesEmployee_panel.Location;

                    // 高さ調整
                    this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 225;
                }
                else if (_mode == 1) // BLコード別
                {
                    this.supplier_panel.Visible = true;
                    this.maker_panel.Visible = true;
                    this.goodsLGroup_panel.Visible = true;
                    this.goodsMGroup_panel.Visible = true;
                    this.blGloupRange_panel.Visible = true;
                    this.blGloup_panel.Visible = true;
                    this.blGoods_panel.Visible = true;

                    // 位置調整                   
                    this.blGoods_panel.Location = this.blGloupRange_panel.Location;
                    this.blGloup_panel.Location = this.goodsMGroup_panel.Location;
                    this.blGloupRange_panel.Location = this.goodsLGroup_panel.Location;
                    this.goodsMGroup_panel.Location = this.maker_panel.Location;
                    this.goodsLGroup_panel.Location = this.customer_panel.Location;
                    this.maker_panel.Location = this.salesEmployee_panel.Location;

                    // 高さ調整
                    this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 195;
                }
                else if (_mode == 2) // 得意先別
                {
                    this.customer_panel.Visible = true;
                    this.maker_panel.Visible = true;
                    this.goodsLGroup_panel.Visible = true;
                    this.goodsMGroup_panel.Visible = true;
                    this.blGloupRange_panel.Visible = true;
                    this.blGoods_panel.Visible = true;
                    this.goodsNo_panel.Visible = true;

                    // 位置調整                   
                    this.goodsNo_panel.Location = this.blGloupRange_panel.Location;
                    this.blGoods_panel.Location = this.goodsMGroup_panel.Location;
                    this.blGloupRange_panel.Location = this.goodsLGroup_panel.Location;
                    this.goodsMGroup_panel.Location = this.maker_panel.Location;
                    this.goodsLGroup_panel.Location = this.customer_panel.Location;
                    this.maker_panel.Location = this.salesEmployee_panel.Location;
                    this.customer_panel.Location = this.supplier_panel.Location;

                    // 高さ調整
                    this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 195;
                }
                else if (_mode == 3) // 担当者別
                {
                    this.salesEmployee_panel.Visible = true;
                    this.maker_panel.Visible = true;
                    this.blGoods_panel.Visible = true;

                    // 位置調整
                    this.blGoods_panel.Location = this.customer_panel.Location;
                    this.maker_panel.Location = this.salesEmployee_panel.Location;
                    this.salesEmployee_panel.Location = this.supplier_panel.Location;

                    // 高さ調整
                    this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 85;
                }
                // --- ADD 2008/09/24 --------------------------------<<<<<

				// ガイドボタン設定
                this.SetIconImage(this.uButton_SupplierCdStGuid, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_SupplierCdEdGuid, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_EmployeeCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdEdGuid, Size16_Index.STAR1);
				this.SetIconImage(this.uButton_CustomerCodeStGuid, Size16_Index.STAR1);
				this.SetIconImage(this.uButton_CustomerCodeEdGuid, Size16_Index.STAR1);
				this.SetIconImage(this.uButton_GoodsMakerCdStGuide, Size16_Index.STAR1);
				this.SetIconImage(this.uButton_GoodsMakerCdEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GoodsLGroupStGuide, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_GoodsLGroupEdGuide, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_GoodsMGroupStGuide, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_GoodsMGroupEdGuide, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_BLGroupCodeStGuide, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_BLGroupCodeEdGuide, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_BLGroupCodeGuide, Size16_Index.STAR1); // ADD 2008/09/24
                this.SetIconImage(this.uButton_BLGoodsCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_BLGoodsCodeEdGuid, Size16_Index.STAR1);
                //this.SetIconImage(this.uButton_GoodsNoStGuide, Size16_Index.STAR1); // DEL 2008/09/24
                //this.SetIconImage(this.uButton_GoodsNoEdGuide, Size16_Index.STAR1); // DEL 2008/09/24
                //this.SetIconImage(this.uButton_GoodsGanreCodeStGuid, Size16_Index.STAR1); // DEL 2008/09/24
                //this.SetIconImage(this.uButton_GoodsGanreCodeEdGuid, Size16_Index.STAR1); // DEL 2008/09/24
                #endregion

                // --- DEL 2008/09/24 -------------------------------->>>>>
                #region 削除
                ////商品別
                //if (_mode == 0)
                //{
                //    //小計：得意先
                //    CheckEditor_SubtotalCustomer.Enabled = false;
                //    CheckEditor_SubtotalCustomer.Checked = false;
                //    //小計：担当者
                //    CheckEditor_SubtotalSalesEmployee.Enabled = false;
                //    CheckEditor_SubtotalSalesEmployee.Checked = false;

                //    //抽出条件：得意先
                //    tNedit_CustomerCode_St.Enabled = false;
                //    tNedit_CustomerCode_Ed.Enabled = false;
                //    uButton_CustomerCodeStGuid.Enabled = false;
                //    uButton_CustomerCodeEdGuid.Enabled = false;

                //    //抽出条件：担当者
                //    tEdit_EmployeeCode_St.Enabled = false;
                //    tEdit_EmployeeCode_Ed.Enabled = false;
                //    uButton_EmployeeCdStGuid.Enabled = false;
                //    uButton_EmployeeCdEdGuid.Enabled = false;
                //}
                ////得意先別
                //else if (_mode == 1)
                //{
                //    //発行タイプ：明細
                //    tComboEditor_Detail.Enabled = false;
                //    this.tComboEditor_Detail.Value = -1;

                //    //小計：商品区分
                //    //CheckEditor_SubtotalGoods.Enabled = false; // DEL 2008/09/24
                //    //CheckEditor_SubtotalGoods.Checked = false; // DEL 2008/09/24

                //    //小計：ＢＬ
                //    CheckEditor_SubtotalBl.Enabled = false;
                //    CheckEditor_SubtotalBl.Checked = false;

                //    //小計：担当者
                //    CheckEditor_SubtotalSalesEmployee.Enabled = false;
                //    CheckEditor_SubtotalSalesEmployee.Checked = false;

                //    //抽出条件：担当者
                //    tEdit_EmployeeCode_St.Enabled = false;
                //    tEdit_EmployeeCode_Ed.Enabled = false;
                //    uButton_EmployeeCdStGuid.Enabled = false;
                //    uButton_EmployeeCdEdGuid.Enabled = false;

                //    //抽出条件：商品番号
                //    tEdit_GoodsNo_St.Enabled = false;
                //    tEdit_GoodsNo_Ed.Enabled = false;
                //    uButton_GoodsNoStGuide.Enabled = false;
                //    uButton_GoodsNoEdGuide.Enabled = false;

                //    //抽出条件：商品区分グループ
                //    tEdit_LargeGoodsGanreCodeSt.Enabled = false;
                //    tEdit_LargeGoodsGanreCodeEd.Enabled = false;
                //    tEdit_MediumGoodsGanreCodeSt.Enabled = false;
                //    tEdit_MediumGoodsGanreCodeEd.Enabled = false;
                //    tEdit_DetailGoodsGanreCodeSt.Enabled = false;
                //    tEdit_DetailGoodsGanreCodeEd.Enabled = false;
                //    uButton_GoodsGanreCodeStGuid.Enabled = false;
                //    uButton_GoodsGanreCodeEdGuid.Enabled = false;
                //}
                ////担当者別
                //else
                //{
                //    //発行タイプ：明細
                //    tComboEditor_Detail.Enabled = false;
                //    this.tComboEditor_Detail.Value = -1;

                //    //小計：商品区分
                //    //CheckEditor_SubtotalGoods.Enabled = false; // DEL 2008/09/24
                //    //CheckEditor_SubtotalGoods.Checked = false; // DEL 2008/09/24

                //    //小計：ＢＬ
                //    CheckEditor_SubtotalBl.Enabled = false;
                //    CheckEditor_SubtotalBl.Checked = false;

                //    //小計：得意先
                //    CheckEditor_SubtotalCustomer.Enabled = false;
                //    CheckEditor_SubtotalCustomer.Checked = false;

                //    //抽出条件：得意先
                //    tNedit_CustomerCode_St.Enabled = false;
                //    tNedit_CustomerCode_Ed.Enabled = false;
                //    uButton_CustomerCodeStGuid.Enabled = false;
                //    uButton_CustomerCodeEdGuid.Enabled = false;

                //    //抽出条件：商品番号
                //    tEdit_GoodsNo_St.Enabled = false;
                //    tEdit_GoodsNo_Ed.Enabled = false;
                //    uButton_GoodsNoStGuide.Enabled = false;
                //    uButton_GoodsNoEdGuide.Enabled = false;

                //    //抽出条件：商品区分グループ
                //    tEdit_LargeGoodsGanreCodeSt.Enabled = false;
                //    tEdit_LargeGoodsGanreCodeEd.Enabled = false;
                //    tEdit_MediumGoodsGanreCodeSt.Enabled = false;
                //    tEdit_MediumGoodsGanreCodeEd.Enabled = false;
                //    tEdit_DetailGoodsGanreCodeSt.Enabled = false;
                //    tEdit_DetailGoodsGanreCodeEd.Enabled = false;
                //    uButton_GoodsGanreCodeStGuid.Enabled = false;
                //    uButton_GoodsGanreCodeEdGuid.Enabled = false;
                //}
                // --- DEL 2008/09/24 --------------------------------<<<<<

                // --- DEL 2008/09/24 -------------------------------->>>>>
                ////改頁
                //for (int i = 0; i < valueList.ValueListItems.Count; i++)
                //{
                //    //tComboEditor_CrMode.Items.Add(valueList.ValueListItems[i]);

                //    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                //    vlltem.Tag = valueList.ValueListItems[i].Tag;
                //    vlltem.DataValue = valueList.ValueListItems[i].DataValue;
                //    vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;
                //    tComboEditor_CrMode.Items.Add(vlltem);
                //}

                //if (valueList.ValueListItems.Count > 0)
                //{
                //    tComboEditor_CrMode.MaxDropDownItems = valueList.ValueListItems.Count;
                //}
                //this.tComboEditor_CrMode.Value = 1;
                #endregion
                // --- DEL 2008/09/24 --------------------------------<<<<<

                // 小計印刷の制御
                this.SettComboEditor_Detail();

                this._initializeFinished = true;

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

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
			cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false);
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
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;

            // 売上日
            // 対象年月（開始～終了）
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
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("対象年月{0}", ct_NotOnYearError);
                            errComponent = this.tde_SalesDateSt;
                        }
                        break;
                }
                status = false;
                return status;
            }
            //印刷範囲指定
            //else if (this.tNedit_PrintRangeSt.DataText.TrimEnd() != string.Empty
            //    && this.tNedit_PrintRangeEd.DataText.TrimEnd() != string.Empty
            //    && this.tNedit_PrintRangeSt.GetInt() > this.tNedit_PrintRangeEd.GetInt()) // ADD 2009/02/10
            else if (this.tNedit_PrintRangeSt.Text != string.Empty
                && this.tNedit_PrintRangeEd.Text != string.Empty
                && this.tNedit_PrintRangeSt.GetInt() > this.tNedit_PrintRangeEd.GetInt())
            {
                errMessage = string.Format("印刷範囲（数量）{0}", ct_RangeError);
                errComponent = this.tNedit_PrintRangeSt;
                status = false;
            }
            // 仕入先
            else if ((this.tNedit_SupplierCd_St.Text.Trim() != "")
                && (this.tNedit_SupplierCd_Ed.Text.Trim() != "")
                && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
                return status;
            }
            // 担当者
            else if (
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
                return status;
            }
            // 得意先
            else if ((this.tNedit_CustomerCode_St.Text.Trim() != "")
                && (this.tNedit_CustomerCode_Ed.Text.Trim() != "")
                && (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
                return status;
            }
            // メーカー
            else if ((this.tNedit_GoodsMakerCd_St.Text.Trim() != "")
                && (this.tNedit_GoodsMakerCd_Ed.Text.Trim() != "")
                && (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }
            // 商品大分類
            else if ((this.tNedit_GoodsLGroup_St.Text.Trim() != "")
                && (this.tNedit_GoodsLGroup_Ed.Text.Trim() != "")
                && (this.tNedit_GoodsLGroup_St.GetInt() > this.tNedit_GoodsLGroup_Ed.GetInt()))
            {
                errMessage = string.Format("商品大分類{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
                return status;
            }
            // 商品中分類
            else if ((this.tNedit_GoodsMGroup_St.Text.Trim() != "")
                && (this.tNedit_GoodsMGroup_Ed.Text.Trim() != "")
                && (this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()))
            {
                errMessage = string.Format("商品中分類{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
                return status;
            }
            // グループコード
            /* --- DEL 2008/10/27 tNedit_BLGoodsCode→tNedit_BLGloupCode ---------------------->>>>>
            else if ((this.tNedit_BLGoodsCode_St.Text.Trim() != "")
                && (this.tNedit_BLGoodsCode_Ed.Text.Trim() != "")
                && (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            // --- DEL 2008/10/27 -------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/27 ------------------------------------------------------------->>>>>
            else if ((this.tNedit_BLGloupCode_St.Text.Trim() != "")
                && (this.tNedit_BLGloupCode_Ed.Text.Trim() != "")
                && (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()))
            // --- ADD 2008/10/27 -------------------------------------------------------------<<<<<
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);
                //errComponent = this.tNedit_BLGoodsCode_St;        //DEL 2008/10/27　tNedit_BLGoodsCode→tNedit_BLGloupCode
                errComponent = this.tNedit_BLGloupCode_St;          //ADD 2008/10/27
                status = false;
                return status;
            }
            // BLコード
            else if ((this.tNedit_BLGoodsCode_St.Text.Trim() != "")
           && (this.tNedit_BLGoodsCode_Ed.Text.Trim() != "")
           && (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            {
                errMessage = string.Format("BLコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return status;
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
                return status;
            }
            
            // --- DEL 2008/09/24 -------------------------------->>>>>
            ////商品区分グループコード
            //else if (
            //    (this.tEdit_LargeGoodsGanreCodeSt.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_LargeGoodsGanreCodeEd.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_LargeGoodsGanreCodeSt.DataText.TrimEnd().CompareTo(this.tEdit_LargeGoodsGanreCodeEd.DataText.TrimEnd()) > 0))
            //{
            //    errMessage = string.Format("商品区分グループコード{0}", ct_RangeError);
            //    errComponent = this.tEdit_LargeGoodsGanreCodeSt;
            //    status = false;
            //}
            ////商品区分コード
            //else if (
            //    (this.tEdit_MediumGoodsGanreCodeSt.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_MediumGoodsGanreCodeEd.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_MediumGoodsGanreCodeSt.DataText.TrimEnd().CompareTo(this.tEdit_MediumGoodsGanreCodeEd.DataText.TrimEnd()) > 0))
            //{
            //    errMessage = string.Format("商品区分コード{0}", ct_RangeError);
            //    errComponent = this.tEdit_MediumGoodsGanreCodeSt;
            //    status = false;
            //}
            ////商品区分詳細コード
            //else if (
            //    (this.tEdit_DetailGoodsGanreCodeSt.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_DetailGoodsGanreCodeEd.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_DetailGoodsGanreCodeSt.DataText.TrimEnd().CompareTo(this.tEdit_DetailGoodsGanreCodeEd.DataText.TrimEnd()) > 0))
            //{
            //    errMessage = string.Format("商品区分詳細コード{0}", ct_RangeError);
            //    errComponent = this.tEdit_DetailGoodsGanreCodeSt;
            //    status = false;
            //}
            ////順位付け設定
            //else if (tNedit_Order3.GetInt() <= 0)
            //{
            //    errMessage = string.Format("順位付け設定{0}", ct_InputError);
            //    errComponent = this.tNedit_Order3;
            //    status = false;
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<

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
			else if ((yy == 0) || (mm <= 0) || (mm > 12))
			{
				status = false;
			}
			// 単純日付妥当性チェック
			//else if( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
			//{
			//	status = false;
			//}

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
        /// <br>Update Note : 2014/12/16 劉超</br>
        /// <br>管理番号    : 11070263-00</br>
        /// <br>            : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                //集計単位
                this._shipmGoodsOdrReport.TotalType = _mode;

				// 企業コード
				this._shipmGoodsOdrReport.EnterpriseCode = this._enterpriseCode;
				
				// 選択拠点
				//this._shipmGoodsOdrReport.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

				// 拠点オプションありのとき
				if (IsOptSection)
				{
					ArrayList secList = new ArrayList();
					// 全社選択かどうか
					if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
					{
						//extraInfo.SectionCd = new string[1];
						//extraInfo.SectionCd[0] = "0";

                        //_shipmGoodsOdrReport.SectionCodes = new string[0]; // DEL 2008/09/24
                        _shipmGoodsOdrReport.SectionCodes = null; // ADD 2008/09/24

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
						_shipmGoodsOdrReport.SectionCodes = (string[])secList.ToArray(typeof(string));
					}
				}
				// 拠点オプションなしの時
				else
				{
                    //_shipmGoodsOdrReport.SectionCodes = new string[0]; // DEL 2008/09/24
                    _shipmGoodsOdrReport.SectionCodes = null; // ADD 2008/09/24
				}

                // 対象年月
                this._shipmGoodsOdrReport.SalesDateSt = this.tde_SalesDateSt.GetDateTime();
                this._shipmGoodsOdrReport.SalesDateEd = this.tde_SalesDateEd.GetDateTime();

				//集計方法
				this._shipmGoodsOdrReport.TtlType = Convert.ToInt32(this.tComboEditor_TtlType.SelectedItem.DataValue);

                //売上在庫取寄せ区分
                this._shipmGoodsOdrReport.SalesOrderDivCd = Convert.ToInt32(this.tComboEditor_SalesOrderDivCd.SelectedItem.DataValue);

                //金額単位
                this._shipmGoodsOdrReport.MoneyUnit = Convert.ToInt32(this.tComboEditor_MoneyUnit.SelectedItem.DataValue);

                //改頁
                if (this._mode == 0
                    && (int)this.tComboEditor_CrMode.SelectedItem.DataValue == 4
                    && ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 1
                        || (int)this.tComboEditor_Detail.SelectedItem.DataValue == 3
                        || (int)this.tComboEditor_Detail.SelectedItem.DataValue == 4))
                {
                    // 商品別、改頁指定"仕入先"、明細単位に仕入先がない場合は改頁なしと同じにする
                    this._shipmGoodsOdrReport.CrMode = 0;
                }
                else
                {
                    this._shipmGoodsOdrReport.CrMode = Convert.ToInt32(this.tComboEditor_CrMode.SelectedItem.DataValue);
                }

                //順位付設定1
                this._shipmGoodsOdrReport.Order1 = Convert.ToInt32(this.tComboEditor_Order1.SelectedItem.DataValue);

                //順位付設定2
                this._shipmGoodsOdrReport.Order2 = Convert.ToInt32(this.tComboEditor_Order2.SelectedItem.DataValue);

                //順位付設定3
                if (this.tNedit_Order3.GetInt() == 0)
                {
                    // 入力がない場合は1位指定と同じにする
                    this._shipmGoodsOdrReport.Order3 = 1;
                }
                else
                {
                    this._shipmGoodsOdrReport.Order3 = this.tNedit_Order3.GetInt();
                }

                //印刷範囲指定
                // --- DEL 2009/02/10 -------------------------------->>>>>
                //this._shipmGoodsOdrReport.PrintRangeSt = this.tNedit_PrintRangeSt.GetInt();
                ////this._shipmGoodsOdrReport.PrintRangeEd = this.GetEndCode(this.tNedit_PrintRangeEd);       //DEL 2008/10/27　""とALL9の区別をつける為 
                //this._shipmGoodsOdrReport.PrintRangeEd = this.tNedit_PrintRangeEd.GetInt();                 //ADD 2008/10/27
                // --- DEL 2009/02/10 --------------------------------<<<<<
                // --- ADD 2009/02/10 -------------------------------->>>>>
                if (this.tNedit_PrintRangeSt.Text == string.Empty)
                {
                    this._shipmGoodsOdrReport.PrintRangeSt = -99999999;
                    this._shipmGoodsOdrReport.PrintRangeStNoInput = true; // 未入力フラグ
                }
                else
                {
                    this._shipmGoodsOdrReport.PrintRangeSt = this.tNedit_PrintRangeSt.GetInt();
                    this._shipmGoodsOdrReport.PrintRangeStNoInput = false; // 未入力フラグ
                }

                if (this.tNedit_PrintRangeEd.Text == string.Empty)
                {
                    this._shipmGoodsOdrReport.PrintRangeEd = 999999999;
                    this._shipmGoodsOdrReport.PrintRangeEdNoInput = true; // 未入力フラグ
                }
                else
                {
                    this._shipmGoodsOdrReport.PrintRangeEd = this.tNedit_PrintRangeEd.GetInt();
                    this._shipmGoodsOdrReport.PrintRangeEdNoInput = false; // 未入力フラグ
                }
                // --- ADD 2009/02/10 --------------------------------<<<<<

                // 構成比単位
                this._shipmGoodsOdrReport.ConstUnit = this.ConstUnit_ultraOptionSet.CheckedIndex;

                //小計印刷
                // 拠点
                if (this.CheckEditor_SubtotalSection.Checked) this._shipmGoodsOdrReport.SubtotalSection = 1;
                else this._shipmGoodsOdrReport.SubtotalSection = 0;

                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                if (_mode == 0) // 商品別
                {
                    // 品番集計区分
                    this._shipmGoodsOdrReport.GoodsNoTtlDiv = Convert.ToInt32(this.tComboEditor_GoodsNoTtlDiv.SelectedItem.DataValue);

                    // 品番表示区分
                    if (this._shipmGoodsOdrReport.GoodsNoTtlDiv == 1)
                    {
                        this._shipmGoodsOdrReport.GoodsNoShowDiv = Convert.ToInt32(this.tComboEditor_GoodsNoShowDiv.SelectedItem.DataValue);
                    }
                } 
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                // 仕入先
                if (this.CheckEditor_SubtotalSupplier.Checked) this._shipmGoodsOdrReport.SubtotalSupplier = 1;
                else this._shipmGoodsOdrReport.SubtotalSupplier = 0;

                // メーカー
                if (this.CheckEditor_SubtotalMaker.Checked) this._shipmGoodsOdrReport.SubtotalMaker = 1;
                else this._shipmGoodsOdrReport.SubtotalMaker = 0;

                //if (this.CheckEditor_SubtotalGoods.Checked)			this._shipmGoodsOdrReport.SubtotalGoods = 1; // DEL 2008/09/24
                //else												this._shipmGoodsOdrReport.SubtotalGoods = 0; // DEL 2008/09/24

                // 商品大分類
                if (this.CheckEditor_SubtotalGoodsLGroup.Checked) this._shipmGoodsOdrReport.SubtotalGoodsLGroup = 1;
                else this._shipmGoodsOdrReport.SubtotalGoodsLGroup = 0;

                // 商品中分類
                if (this.CheckEditor_SubtotalGoodsMGroup.Checked) this._shipmGoodsOdrReport.SubtotalGoodsMGroup = 1;
                else this._shipmGoodsOdrReport.SubtotalGoodsMGroup = 0;

                // グループコード
                if (this.CheckEditor_SubtotalGroupCode.Checked) this._shipmGoodsOdrReport.SubtotalGroupCode = 1;
                else this._shipmGoodsOdrReport.SubtotalGroupCode = 0;

                // BLコード
                if (this.CheckEditor_SubtotalBl.Checked) this._shipmGoodsOdrReport.SubtotalBl = 1;
                else this._shipmGoodsOdrReport.SubtotalBl = 0;

                // 得意先
                if (this.CheckEditor_SubtotalCustomer.Checked) this._shipmGoodsOdrReport.SubtotalCustomer = 1;
                else this._shipmGoodsOdrReport.SubtotalCustomer = 0;

                // 担当者
                if (this.CheckEditor_SubtotalSalesEmployee.Checked) this._shipmGoodsOdrReport.SubtotalSalesEmployee = 1;
                else this._shipmGoodsOdrReport.SubtotalSalesEmployee = 0;

				//売上日付
				//DateTime st, ed;
				//_dateGet.GetDaysFromMonth(this.tde_SalesDateSt.GetDateTime(), out st, out ed);
				//this._shipmGoodsOdrReport.SalesDateSt = st;

				//_dateGet.GetDaysFromMonth(this.tde_SalesDateEd.GetDateTime(), out st, out ed);
				//this._shipmGoodsOdrReport.SalesDateEd = ed;

				//売上日付(印刷用)
                this._shipmGoodsOdrReport.PrnSalesDateSt = this.tde_SalesDateSt.GetDateTime();
                this._shipmGoodsOdrReport.PrnSalesDateEd = this.tde_SalesDateEd.GetDateTime();

                //明細単位
                if (_mode == 0 || _mode == 2)
                {
                    this._shipmGoodsOdrReport.Detail = Convert.ToInt32(this.tComboEditor_Detail.SelectedItem.DataValue);
                }
                else
                {
                    //this._shipmGoodsOdrReport.Detail = 0; // DEL 2008/09/24
                    this._shipmGoodsOdrReport.Detail = -1; // ADD 2008/09/24
                }

                //順位設定
                this._shipmGoodsOdrReport.SortItem = Convert.ToInt32(this.tComboEditor_SortItem.SelectedItem.DataValue);

                //印刷タイプ
                if (_mode != 1) // BLコード別以外
                {
                    
                    this._shipmGoodsOdrReport.PrintType = Convert.ToInt32(this.tComboEditor_PrintType.SelectedItem.DataValue);
                }
                else
                {
                    //印刷タイプ
                    this._shipmGoodsOdrReport.PrintType = -1;
                }
				// --- DEL 2008/09/24 -------------------------------->>>>>
                ////商品区分グループコード
                //this._shipmGoodsOdrReport.LargeGoodsGanreCodeSt = this.tEdit_LargeGoodsGanreCodeSt.DataText;
                //this._shipmGoodsOdrReport.LargeGoodsGanreCodeEd = this.tEdit_LargeGoodsGanreCodeEd.DataText;

                ////商品区分コード
                //this._shipmGoodsOdrReport.MediumGoodsGanreCodeSt = this.tEdit_MediumGoodsGanreCodeSt.DataText;
                //this._shipmGoodsOdrReport.MediumGoodsGanreCodeEd = this.tEdit_MediumGoodsGanreCodeEd.DataText;

                ////商品区分詳細コード
                //this._shipmGoodsOdrReport.DetailGoodsGanreCodeSt = this.tEdit_DetailGoodsGanreCodeSt.DataText;
                //this._shipmGoodsOdrReport.DetailGoodsGanreCodeEd = this.tEdit_DetailGoodsGanreCodeEd.DataText;

                ////販売従業員コード
                //this._shipmGoodsOdrReport.SalesEmployeeCdSt = this.tEdit_EmployeeCode_St.DataText;
                //this._shipmGoodsOdrReport.SalesEmployeeCdEd = this.tEdit_EmployeeCode_Ed.DataText;
                // --- DEL 2008/09/24 --------------------------------<<<<<

                /*  --- DEL 2008/10/27 Toを印字時、""とALL9の区別をつける必要がある為、値はそのまま渡す ------------>>>>>
                // 仕入先
                this._shipmGoodsOdrReport.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
                this._shipmGoodsOdrReport.SupplierCdEd = this.GetEndCode(this.tNedit_SupplierCd_Ed);
                
                // 担当者
                if (this.tEdit_EmployeeCode_St.DataText == "") this._shipmGoodsOdrReport.EmployeeCodeSt = "0000";
                else this._shipmGoodsOdrReport.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.PadLeft(4, '0');

                if (this.tEdit_EmployeeCode_Ed.DataText == "") this._shipmGoodsOdrReport.EmployeeCodeEd = "9999";
                else this._shipmGoodsOdrReport.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.PadLeft(4, '0');

                // 得意先
                this._shipmGoodsOdrReport.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                this._shipmGoodsOdrReport.CustomerCodeEd = this.GetEndCode(this.tNedit_CustomerCode_Ed);
                
                // メーカー
                this._shipmGoodsOdrReport.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                this._shipmGoodsOdrReport.GoodsMakerCdEd = this.GetEndCode(this.tNedit_GoodsMakerCd_Ed);
                
                // 商品大分類
                this._shipmGoodsOdrReport.GoodsLGroupSt = this.tNedit_GoodsLGroup_St.GetInt();
                this._shipmGoodsOdrReport.GoodsLGroupEd = this.GetEndCode(this.tNedit_GoodsLGroup_Ed);
                
                // 商品中分類
                this._shipmGoodsOdrReport.GoodsMGroupSt = this.tNedit_GoodsMGroup_St.GetInt();
                this._shipmGoodsOdrReport.GoodsMGroupEd = this.GetEndCode(this.tNedit_GoodsMGroup_Ed);
                
                // グループコード(範囲)
                this._shipmGoodsOdrReport.BLGroupCodeSt = this.tNedit_BLGloupCode_St.GetInt();
                this._shipmGoodsOdrReport.BLGroupCodeEd = this.GetEndCode(this.tNedit_BLGloupCode_Ed);
                   --- DEL 2008/10/27 ------------------------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/27 ------------------------------------------------------------------------------>>>>>
                // 仕入先
                this._shipmGoodsOdrReport.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
                this._shipmGoodsOdrReport.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();

                // 担当者
                if (this.tEdit_EmployeeCode_St.DataText == "") this._shipmGoodsOdrReport.EmployeeCodeSt = "0000";
                else this._shipmGoodsOdrReport.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.PadLeft(4, '0');

                if (this.tEdit_EmployeeCode_Ed.DataText == "") this._shipmGoodsOdrReport.EmployeeCodeEd = "";
                else this._shipmGoodsOdrReport.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.PadLeft(4, '0');

                // 得意先
                this._shipmGoodsOdrReport.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                this._shipmGoodsOdrReport.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();

                // メーカー
                this._shipmGoodsOdrReport.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                this._shipmGoodsOdrReport.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // 商品大分類
                this._shipmGoodsOdrReport.GoodsLGroupSt = this.tNedit_GoodsLGroup_St.GetInt();
                this._shipmGoodsOdrReport.GoodsLGroupEd = this.tNedit_GoodsLGroup_Ed.GetInt();

                // 商品中分類
                this._shipmGoodsOdrReport.GoodsMGroupSt = this.tNedit_GoodsMGroup_St.GetInt();
                this._shipmGoodsOdrReport.GoodsMGroupEd = this.tNedit_GoodsMGroup_Ed.GetInt();

                // グループコード(範囲)
                this._shipmGoodsOdrReport.BLGroupCodeSt = this.tNedit_BLGloupCode_St.GetInt();
                this._shipmGoodsOdrReport.BLGroupCodeEd = this.tNedit_BLGloupCode_Ed.GetInt();
                // --- ADD 2008/10/27 ------------------------------------------------------------------------------<<<<<

                // グループコード(単体)
                List<int> groupCodeAry = new List<int>();

                if (this.tNedit_BLGroupCode1.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode1.GetInt());
                if (this.tNedit_BLGroupCode2.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode2.GetInt());
                if (this.tNedit_BLGroupCode3.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode3.GetInt());
                if (this.tNedit_BLGroupCode4.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode4.GetInt());
                if (this.tNedit_BLGroupCode5.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode5.GetInt());
                if (this.tNedit_BLGroupCode6.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode6.GetInt());
                if (this.tNedit_BLGroupCode7.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode7.GetInt());
                if (this.tNedit_BLGroupCode8.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode8.GetInt());
                if (this.tNedit_BLGroupCode9.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode9.GetInt());
                if (this.tNedit_BLGroupCode10.GetInt() != 0) groupCodeAry.Add(this.tNedit_BLGroupCode10.GetInt());

                this._shipmGoodsOdrReport.BLGroupCodeAry = groupCodeAry.ToArray();

				// BLコード
				this._shipmGoodsOdrReport.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
                //this._shipmGoodsOdrReport.BLGoodsCodeEd = this.GetEndCode(this.tNedit_BLGoodsCode_Ed);    //DEL 2008/10/27　""とALL9の区別をつける為 
                this._shipmGoodsOdrReport.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();              //ADD 2008/10/27
                
				// 品番
                this._shipmGoodsOdrReport.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;
                this._shipmGoodsOdrReport.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;

                //if (this.tEdit_GoodsNo_St.DataText == "") this._shipmGoodsOdrReport.GoodsNoSt = "000000000000000000000000";
                //else this._shipmGoodsOdrReport.GoodsNoSt = this.tEdit_GoodsNo_St.DataText.PadLeft(24, '0');

                //if (this.tEdit_GoodsNo_Ed.DataText == "") this._shipmGoodsOdrReport.GoodsNoEd = "999999999999999999999999";
                //else this._shipmGoodsOdrReport.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText.PadLeft(24, '0');
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
        private DialogResult WarnMsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            DialogResult result = TMsgDisp.Show(
                                    iLevel, 							// エラーレベル
                                    ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                                    this._printName,					// プログラム名称
                                    "", 								// 処理名称
                                    "",									// オペレーション
                                    message,							// 表示するメッセージ
                                    status, 							// ステータス値
                                    null, 								// エラーが発生したオブジェクト
                                    MessageBoxButtons.YesNo,			// 表示するボタン
                                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return result;
        }
        #endregion
		#endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region ◆ 画面表示制御
        /// <summary>
        /// （商品別）小計チェックＢＯＸの制御
        /// </summary>
        void SettComboEditor_Detail()
        {

            // 小計印刷 拠点
            if (this.tComboEditor_TtlType.SelectedIndex == 0) // 集計方法が全社
            {
                this.CheckEditor_SubtotalSection.Checked = false;
                this.CheckEditor_SubtotalSection.Enabled = false;
            }
            else
            {
                this.CheckEditor_SubtotalSection.Enabled = true;
            }

            if (_mode == 0) // 商品別
            {
                // --- DEL 2008/09/24 -------------------------------->>>>>
                ////明細単位
                //Int32 cd = Convert.ToInt32(this.tComboEditor_Detail.SelectedItem.DataValue);
                //switch (cd)
                //{
                //    //0:メーカーコード＋商品区分コード＋ＢＬコード＋商品コード
                //    case 0:
                //        //メーカー
                //        //this.CheckEditor_SubtotalMaker.Checked = false;
                //        this.CheckEditor_SubtotalMaker.Enabled = true;

                //        //商品区分
                //        //this.CheckEditor_SubtotalGoods.Checked = false;
                //        //this.CheckEditor_SubtotalGoods.Enabled = true; // DEL 2008/09/24

                //        //ＢＬコード
                //        //this.CheckEditor_SubtotalBl.Checked = false;
                //        this.CheckEditor_SubtotalBl.Enabled = true;
                //        break;
                //    //1:商品区分コード＋ＢＬコード＋商品コード
                //    case 1:
                //        //メーカー
                //        this.CheckEditor_SubtotalMaker.Checked = false;
                //        this.CheckEditor_SubtotalMaker.Enabled = false;

                //        //商品区分
                //        //this.CheckEditor_SubtotalGoods.Checked = false;
                //        //this.CheckEditor_SubtotalGoods.Enabled = true; // DEL 2008/09/24

                //        //ＢＬコード
                //        //this.CheckEditor_SubtotalBl.Checked = false;
                //        this.CheckEditor_SubtotalBl.Enabled = true;
                //        break;
                //    //2:メーカーコード＋商品コード
                //    case 2:
                //        //メーカー
                //        //this.CheckEditor_SubtotalMaker.Checked = false;
                //        this.CheckEditor_SubtotalMaker.Enabled = true;

                //        //商品区分
                //        //this.CheckEditor_SubtotalGoods.Checked = false; // DEL 2008/09/24
                //        //this.CheckEditor_SubtotalGoods.Enabled = false; // DEL 2008/09/24

                //        //ＢＬコード
                //        this.CheckEditor_SubtotalBl.Checked = false;
                //        this.CheckEditor_SubtotalBl.Enabled = false;
                //        break;
                //    //3:商品区分コード＋商品コード
                //    case 3:
                //        //メーカー
                //        this.CheckEditor_SubtotalMaker.Checked = false;
                //        this.CheckEditor_SubtotalMaker.Enabled = false;

                //        //商品区分
                //        //this.CheckEditor_SubtotalGoods.Checked = false;
                //        //this.CheckEditor_SubtotalGoods.Enabled = true; // DEL 2008/09/24

                //        //ＢＬコード
                //        this.CheckEditor_SubtotalBl.Checked = false;
                //        this.CheckEditor_SubtotalBl.Enabled = false;
                //        break;
                //    //4:商品コード
                //    case 4:
                //        //メーカー
                //        this.CheckEditor_SubtotalMaker.Checked = false;
                //        this.CheckEditor_SubtotalMaker.Enabled = false;

                //        //商品区分
                //        //this.CheckEditor_SubtotalGoods.Checked = false; // DEL 2008/09/24
                //        //this.CheckEditor_SubtotalGoods.Enabled = false; // DEL 2008/09/24

                //        //ＢＬコード
                //        this.CheckEditor_SubtotalBl.Checked = false;
                //        this.CheckEditor_SubtotalBl.Enabled = false;
                //        break;
                //}
                // --- DEL 2008/09/24 --------------------------------<<<<<

                // 小計印刷 仕入先
                if (this.tComboEditor_Detail.SelectedIndex == 1
                    || this.tComboEditor_Detail.SelectedIndex == 3
                    //|| this.tComboEditor_Detail.SelectedIndex == 4) //DEL BY 凌小青
                //--------ADD BY 凌小青------->>>>>>
                    || this.tComboEditor_Detail.SelectedIndex == 4
                    || this.tComboEditor_Detail.SelectedIndex == 5)
                //--------ADD BY 凌小青-------<<<<<<
                {
                    this.CheckEditor_SubtotalSupplier.Checked = false;
                    this.CheckEditor_SubtotalSupplier.Enabled = false;
                }
                else
                {
                    this.CheckEditor_SubtotalSupplier.Enabled = true;
                }

                // 小計印刷 商品中分類
                if (this.tComboEditor_Detail.SelectedIndex == 2
                    //|| this.tComboEditor_Detail.SelectedIndex == 3)//DEL BY 凌小青
                    //--------ADD BY 凌小青------->>>>>>
                    || this.tComboEditor_Detail.SelectedIndex == 3
                    || this.tComboEditor_Detail.SelectedIndex == 5)
                    //--------ADD BY 凌小青-------<<<<<<
                {
                    this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                    this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;
                }
                else
                {
                    this.CheckEditor_SubtotalGoodsMGroup.Enabled = true;
                }

                // 小計印刷 BLコード
                if (this.tComboEditor_Detail.SelectedIndex == 2
                    || this.tComboEditor_Detail.SelectedIndex == 3
                    //|| this.tComboEditor_Detail.SelectedIndex == 4)//DEL BY 凌小青
                    //--------ADD BY 凌小青------->>>>>>
                    || this.tComboEditor_Detail.SelectedIndex == 4
                    || this.tComboEditor_Detail.SelectedIndex == 5)
                    //--------ADD BY 凌小青-------<<<<<<
                {
                    this.CheckEditor_SubtotalBl.Checked = false;
                    this.CheckEditor_SubtotalBl.Enabled = false;
                }
                else
                {
                    this.CheckEditor_SubtotalBl.Enabled = true;
                }
                //------------ADD BY  凌小青 on 2011/10/31 for Redmine#26322 ------------>>>>>>>>>>>>
                // 小計印刷 メーカー
                if (this.tComboEditor_Detail.SelectedIndex == 5)
                {
                    this.CheckEditor_SubtotalMaker.Checked = false;
                    this.CheckEditor_SubtotalMaker.Enabled = false;
                }
                else
                {
                    this.CheckEditor_SubtotalMaker.Enabled = true;
                }
                //------------ADD BY  凌小青 on 2011/10/31 for Redmine#26322 ------------<<<<<<<<<<<<
            }
            else if (_mode == 2) // 得意先別
            {
                // 小計印刷 グループコード
                if (this.tComboEditor_Detail.SelectedIndex == 1) // 明細単位 グループコード
                {
                    this.CheckEditor_SubtotalGroupCode.Checked = false;
                    this.CheckEditor_SubtotalGroupCode.Enabled = false;
                }
                else
                {
                    this.CheckEditor_SubtotalGroupCode.Enabled = true;
                }
            }
        }

        // --- ADD 2008/09/24 -------------------------------->>>>>
        /// <summary>
        /// 順位設定リストボックス初期設定
        /// </summary>
        private void SetSortItemList()
        {
            Infragistics.Win.ValueListItem listItem;

            // 順位設定
            listItem = new Infragistics.Win.ValueListItem();
            listItem.Tag = 0;
            listItem.DataValue = 0;
            listItem.DisplayText = "数量";
            this.tComboEditor_SortItem.Items.Add(listItem);

            listItem = new Infragistics.Win.ValueListItem();
            listItem.Tag = 1;
            listItem.DataValue = 1;
            listItem.DisplayText = "回数";
            this.tComboEditor_SortItem.Items.Add(listItem);

            listItem = new Infragistics.Win.ValueListItem();
            listItem.Tag = 2;
            listItem.DataValue = 2;
            listItem.DisplayText = "売上金額";
            this.tComboEditor_SortItem.Items.Add(listItem);

            listItem = new Infragistics.Win.ValueListItem();
            listItem.Tag = 3;
            listItem.DataValue = 3;
            listItem.DisplayText = "粗利金額";
            this.tComboEditor_SortItem.Items.Add(listItem);

            listItem = new Infragistics.Win.ValueListItem();
            listItem.Tag = 4;
            listItem.DataValue = 4;
            listItem.DisplayText = "順位無し";
            this.tComboEditor_SortItem.Items.Add(listItem);

            // 初期値(数量)
            this.tComboEditor_SortItem.Value = 0;
        }

        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            //saveCtrAry.Add(this.tde_SalesDateSt);     //DEL 2009/03/05 不具合対応[12184]
            //saveCtrAry.Add(this.tde_SalesDateEd);     //DEL 2009/03/05 不具合対応[12184]
            saveCtrAry.Add(this.tComboEditor_TtlType);
            saveCtrAry.Add(this.tComboEditor_SalesOrderDivCd);
            saveCtrAry.Add(this.tComboEditor_MoneyUnit);
            saveCtrAry.Add(this.tComboEditor_CrMode);
            saveCtrAry.Add(this.tComboEditor_Order1);
            saveCtrAry.Add(this.tComboEditor_Order2);
            saveCtrAry.Add(this.tNedit_Order3);
            //saveCtrAry.Add(this.tNedit_PrintRangeSt); // DEL 2009/02/10
            //saveCtrAry.Add(this.tNedit_PrintRangeEd); // DEL 2009/02/10
            saveCtrAry.Add(this.ConstUnit_ultraOptionSet);
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            saveCtrAry.Add(this.tComboEditor_GoodsNoTtlDiv);
            saveCtrAry.Add(this.tComboEditor_GoodsNoShowDiv);
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            saveCtrAry.Add(this.tComboEditor_Detail);
            saveCtrAry.Add(this.tComboEditor_SortItem);
            saveCtrAry.Add(this.tComboEditor_PrintType);
            saveCtrAry.Add(this.tNedit_SupplierCd_St);
            saveCtrAry.Add(this.tNedit_SupplierCd_Ed);
            saveCtrAry.Add(this.tEdit_EmployeeCode_St);
            saveCtrAry.Add(this.tEdit_EmployeeCode_Ed);
            saveCtrAry.Add(this.tNedit_CustomerCode_St);
            saveCtrAry.Add(this.tNedit_CustomerCode_Ed);
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_St);
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_Ed);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_Ed);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_Ed);
            saveCtrAry.Add(this.tNedit_BLGloupCode_St);
            saveCtrAry.Add(this.tNedit_BLGloupCode_Ed);
            saveCtrAry.Add(this.tNedit_BLGroupCode1);
            saveCtrAry.Add(this.tNedit_BLGroupCode2);
            saveCtrAry.Add(this.tNedit_BLGroupCode3);
            saveCtrAry.Add(this.tNedit_BLGroupCode4);
            saveCtrAry.Add(this.tNedit_BLGroupCode5);
            saveCtrAry.Add(this.tNedit_BLGroupCode6);
            saveCtrAry.Add(this.tNedit_BLGroupCode7);
            saveCtrAry.Add(this.tNedit_BLGroupCode8);
            saveCtrAry.Add(this.tNedit_BLGroupCode9);
            saveCtrAry.Add(this.tNedit_BLGroupCode10);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_St);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_Ed);
            saveCtrAry.Add(this.tEdit_GoodsNo_St);
            saveCtrAry.Add(this.tEdit_GoodsNo_Ed);
            // --------------------- ADD 2011/08/16 ------------------->>>>>
            saveCtrAry.Add(this.tEdit_SupplierCd_St);
            saveCtrAry.Add(this.tEdit_SupplierCd_Ed);
            saveCtrAry.Add(this.tEdit_EmployeeCode_St_Name);
            saveCtrAry.Add(this.tEdit_EmployeeCode_Ed_Name);
            saveCtrAry.Add(this.tEdit_CustomerCode_St);
            saveCtrAry.Add(this.tEdit_CustomerCode_Ed);
            saveCtrAry.Add(this.tEdit_GoodsMakerCd_St);
            saveCtrAry.Add(this.tEdit_GoodsMakerCd_Ed);
            saveCtrAry.Add(this.tEdit_GoodsLGroup_St);
            saveCtrAry.Add(this.tEdit_GoodsLGroup_Ed);
            saveCtrAry.Add(this.tEdit_GoodsMGroup_St);
            saveCtrAry.Add(this.tEdit_GoodsMGroup_Ed);
            saveCtrAry.Add(this.tEdit_BLGloupCode_St);
            saveCtrAry.Add(this.tEdit_BLGloupCode_Ed);
            saveCtrAry.Add(this.tEdit_BLGoodsCode_St);
            saveCtrAry.Add(this.tEdit_BLGoodsCode_Ed);
            // --------------------- ADD 2011/08/16 -------------------<<<<<

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        // --- ADD 2008/09/24 --------------------------------<<<<<

        // --- ADD 2008/12/11 -------------------------------->>>>>
        /// <summary>
        /// 改頁リストボックス設定
        /// </summary>
        private void SetNewPageDiv()
        {
            Infragistics.Win.ValueListItem listItem;

            if (_mode == 0) // 商品別
            {
                //改頁listBox
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "なし";
                this.tComboEditor_CrMode.Items.Add(listItem);

                // 集計方法「全社」の場合、拠点を表示しない
                if ((int)this.tComboEditor_TtlType.SelectedItem.DataValue != 0)
                {
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 1;
                    listItem.DataValue = 1;
                    listItem.DisplayText = "拠点";
                    this.tComboEditor_CrMode.Items.Add(listItem);
                }

                // 明細単位に「仕入先」が含まれない場合、仕入先を表示しない
                if ((int)this.tComboEditor_Detail.SelectedItem.DataValue != 1
                    && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 3
                    && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 4)
                {
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 4;
                    listItem.DataValue = 4;
                    listItem.DisplayText = "仕入先";
                    this.tComboEditor_CrMode.Items.Add(listItem);
                }
            }
            else if (_mode == 1) // BLコード別
            {
                //改頁listBox
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "なし";
                this.tComboEditor_CrMode.Items.Add(listItem);

                if ((int)this.tComboEditor_TtlType.SelectedItem.DataValue != 0)
                {
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 1;
                    listItem.DataValue = 1;
                    listItem.DisplayText = "拠点";
                    this.tComboEditor_CrMode.Items.Add(listItem);
                }

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 4;
                listItem.DataValue = 4;
                listItem.DisplayText = "仕入先";
                this.tComboEditor_CrMode.Items.Add(listItem);
            }
            else if (_mode == 2) // 得意先別
            {
                //改頁listBox
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "なし";
                this.tComboEditor_CrMode.Items.Add(listItem);

                if ((int)this.tComboEditor_TtlType.SelectedItem.DataValue != 0)
                {
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 1;
                    listItem.DataValue = 1;
                    listItem.DisplayText = "拠点";
                    this.tComboEditor_CrMode.Items.Add(listItem);
                }

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "得意先";
                this.tComboEditor_CrMode.Items.Add(listItem);
            }
            else if (_mode == 3) // 担当者別
            {
                //改頁listBox
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "なし";
                this.tComboEditor_CrMode.Items.Add(listItem);

                if ((int)this.tComboEditor_TtlType.SelectedItem.DataValue != 0)
                {
                    listItem = new Infragistics.Win.ValueListItem();
                    listItem.Tag = 1;
                    listItem.DataValue = 1;
                    listItem.DisplayText = "拠点";
                    this.tComboEditor_CrMode.Items.Add(listItem);
                }

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                listItem.DisplayText = "担当者";
                this.tComboEditor_CrMode.Items.Add(listItem);
            }
        }
        // --- ADD 2008/12/11 --------------------------------<<<<<
        #endregion

        // ------------------ ADD 2011/08/16 -------------------->>>>>
        #region ◆ 名称取得
        /// <summary>
        /// 名称取得処理
        /// </summary>
        /// <param name="code">コード</param>
        /// <param name="nameDiv">名称区分[0:仕入先,1:担当者,2:得意先,3:メーカー,4:商品大分類,5:商品中分類,6:グループコード]</param>
        /// <returns>名称</returns>
        /// <remarks>
        /// <br>Note       : 名称を取得します。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
        /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
        /// </remarks>
        private string GetNameFromCode(string code,int nameDiv)
        {
            string name = string.Empty;

            if (code == string.Empty)
                code = "0";

            switch (nameDiv)
            {
                //仕入先
                case 0:
                    {
                        int supplierCode = Convert.ToInt32(code);
                        if (_supplierList == null ||  _supplierList.Count == 0)
                        {
                            ArrayList outSupplierList;
                            int status = this._supplierAcs.SearchAll(out outSupplierList, this._enterpriseCode, "");
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _supplierList = outSupplierList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "仕入先情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }

                        if (_supplierList.Count != 0)
                        {
                            foreach (Supplier supplier in _supplierList)
                            {
                                if (supplier.SupplierCd == supplierCode)
                                {
                                    name = supplier.SupplierSnm;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //担当者
                case 1:
                    {
                        if (code == "0")
                            code = string.Empty;

                        if (_employeeList == null || _employeeList.Count == 0)
                        {
                            ArrayList outList;
                            ArrayList outList1;
                            int status = this._employeeAcs.SearchAll(out outList, out outList1, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _employeeList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "担当者情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }

                        if (_employeeList.Count != 0)
                        {
                            foreach (Employee employee in _employeeList)
                            {
                                if (employee.EmployeeCode.Trim() == code)
                                {
                                    name = employee.Name;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //得意先
                case 2:
                    {
                        int customerCode = Convert.ToInt32(code);
                        if (_customerList == null || _customerList.Length == 0)
                        {
                            CustomerSearchPara para = new CustomerSearchPara();
                            CustomerSearchRet[] retArray;
                            para.EnterpriseCode = this._enterpriseCode;

                            // 検索処理実行
                            int status = _customerSearchAcs.Serch(out retArray, para);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _customerList = retArray;
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
                                return NOT_FOUND;
                            }
                        }

                        if (_customerList.Length != 0)
                        {
                            foreach (CustomerSearchRet customerSearchRet in _customerList)
                            {
                                if (customerSearchRet.CustomerCode == customerCode)
                                {
                                    name = customerSearchRet.Snm;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //メーカー
                case 3:
                    {
                        int makerCode = Convert.ToInt32(code);
                        if (_makerList == null || _makerList.Count == 0)
                        {
                            ArrayList outList;
                            int status = this._makerAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _makerList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "メーカー情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_makerList.Count != 0)
                        {
                            foreach (MakerUMnt makerUMnt in _makerList)
                            {
                                if (makerUMnt.GoodsMakerCd == makerCode)
                                {
                                    name = makerUMnt.MakerName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //商品大分類
                case 4:
                    {
                        int userGuideCode = Convert.ToInt32(code);
                        if (_userGuideList == null || _userGuideList.Count == 0)
                        {
                            ArrayList outList;
                            int status = this._userGuideAcs.SearchAllBody(out outList, this._enterpriseCode, UserGuideAcsData.UserBodyData);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _userGuideList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "商品大分類情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_userGuideList.Count != 0)
                        {
                            foreach (UserGdBd userGdBd in _userGuideList)
                            {
                                if (userGdBd.GuideCode == userGuideCode && userGdBd.UserGuideDivCd == 70)
                                {
                                    name = userGdBd.GuideName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //商品中分類
                case 5:
                    {
                        int goodsGroupUCode = Convert.ToInt32(code);
                        if (_goodsGroupUList == null || _goodsGroupUList.Count == 0)
                        {
                            ArrayList outList;
                            int status = this._goodsGroupUAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _goodsGroupUList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "商品中分類情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_goodsGroupUList.Count != 0)
                        {
                            foreach (GoodsGroupU goodgroupU in _goodsGroupUList)
                            {
                                if (goodgroupU.GoodsMGroup == goodsGroupUCode)
                                {
                                    name = goodgroupU.GoodsMGroupName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //グループコード
                case 6:
                    {
                        int blGroupUCode = Convert.ToInt32(code);
                        if (_blGroupUList == null || _blGroupUList.Count == 0)
                        {
                            ArrayList outList;
                            int status = this._blGroupUAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _blGroupUList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "グループコード情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_blGroupUList.Count != 0)
                        {
                            foreach (BLGroupU blGroupU in _blGroupUList)
                            {
                                if (blGroupU.BLGroupCode == blGroupUCode)
                                {
                                    //--- UPD 2011/09/09 ------------>>>>>
                                    //name = blGroupU.BLGroupName;
                                    name = blGroupU.BLGroupKanaName;
                                    if (name == string.Empty)
                                    {
                                        name = " ";
                                    }
                                    //--- UPD 2011/09/09 ------------<<<<<
                                    break;
                                }
                            }
                        }
                        break;
                    }
                //BLコード
                case 7:
                    {
                        int blGoodsCdCode = Convert.ToInt32(code);
                        if (_blGoodsCdList == null || _blGoodsCdList.Count == 0)
                        {
                            ArrayList outList;
                            int status = this._blGoodsCdAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _blGoodsCdList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "BLコード情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_blGoodsCdList.Count != 0)
                        {
                            foreach (BLGoodsCdUMnt bLGoodsCdUMnt in _blGoodsCdList)
                            {
                                if (bLGoodsCdUMnt.BLGoodsCode == blGoodsCdCode)
                                {
                                    name = bLGoodsCdUMnt.BLGoodsHalfName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                default:
                    break;
            }
            if (name == string.Empty)
                return NOT_FOUND;
            else
                return name;
        }
        #endregion
        // ------------------ ADD 2011/08/16 --------------------<<<<<

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
        private int GetEndCode(TNedit tNedit)
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        

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

            // ADD 2009/03/31 不具合対応[12916]：スペースキーでの項目選択機能を実装 ---------->>>>>
            ConstUnitRadioKeyPressHelper.ControlList.Add(this.ConstUnit_ultraOptionSet);
            ConstUnitRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[12916]：スペースキーでの項目選択機能を実装 ----------<<<<<
		}
		#endregion

        #region ◎ ガイド処理
        /// <summary>
        /// 得意先ガイド（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCodeStGuid_Click(object sender, EventArgs e)
        {
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);

            // --- ADD 2008/09/24 -------------------------------->>>>>
            this._customerGuideOK = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._customerGuideOK)
            {
                this.tNedit_CustomerCode_Ed.Focus();
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<
        }
        /// <summary>
        /// 得意先ガイド（終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCodeEdGuid_Click(object sender, EventArgs e)
        {
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);

            //--- ADD 2008.08.14 ---------->>>>>
            this._customerGuideOK = false;

            // 得意先ガイド
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._customerGuideOK)
            {
                this.tNedit_GoodsMakerCd_St.Focus();
            }
            //--- ADD 2008.08.14 ----------<<<<<
        }
        /// <summary>
        /// 得意先先(開始)選択時発生イベント
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
                this.tEdit_CustomerCode_St.DataText = customerInfo.CustomerSnm;   // ADD 2011/08/16
                this._customerGuideOK = true;
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
                this.tEdit_CustomerCode_Ed.DataText = customerInfo.CustomerSnm;   // ADD 2011/08/16
                this._customerGuideOK = true; // ADD 2008/12/09
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
        /// 担当者ガイド（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EmployeeCdStGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                this.tEdit_EmployeeCode_St_Name.DataText = employee.Name;  //ADD 2011/08/16
                this.tEdit_EmployeeCode_Ed.Focus();
            }
        }

        /// <summary>
        /// 担当者ガイド（終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EmployeeCdEdGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                this.tEdit_EmployeeCode_Ed_Name.DataText = employee.Name;  //ADD 2011/08/16
                this.tNedit_GoodsMakerCd_St.Focus();
            }
        }

        /// <summary>
        /// 商品ガイド（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsGuide_Click(object sender, EventArgs e)
        {
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
            GoodsUnitData goodsUnitData;
            //GoodsCndtn para = new GoodsCndtn();
            //para.EnterpriseCode = this._enterpriseCode;

            //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, para, out goodsUnitData);
            DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

            if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
            {
                this.tEdit_GoodsNo_St.Text = goodsUnitData.GoodsNo;
            }
        }
        /// <summary>
        /// 商品ガイド（終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsNoEdGuid_Click(object sender, EventArgs e)
        {
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            GoodsUnitData goodsUnitData;
            GoodsCndtn para = new GoodsCndtn();
            para.EnterpriseCode = this._enterpriseCode;

            DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, para, out goodsUnitData);

            if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
            {
                this.tEdit_GoodsNo_Ed.Text = goodsUnitData.GoodsNo;
            }
        }
        /// <summary>
        /// メーカーガイド（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdStGuide_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_GoodsMakerCd_St.DataText = makerUMnt.MakerName;  //ADD 2011/08/16
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
        }

        /// <summary>
        /// メーカーガイド（終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdEdGuide_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_GoodsMakerCd_Ed.DataText = makerUMnt.MakerName;  //ADD 2011/08/16

                if (this._mode == 3) // 担当者別
                {
                    this.tNedit_BLGoodsCode_St.Focus();
                }
                else
                {
                    this.tNedit_GoodsLGroup_St.Focus();
                }
            }
        }

        /// <summary>
        /// 商品区分グループガイド（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsGanreCodeStGuid_Click(object sender, EventArgs e)
        {
            if (sender is UltraButton)
            {
                DGoodsGanreAcs dGoodsGanreAcs = new DGoodsGanreAcs();
                DGoodsGanre dGoodsGanre = new DGoodsGanre();

                if (dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1) == 0)
                {
                    // --- DEL 2008/09/24 -------------------------------->>>>>
                    ////大分類
                    //this.tEdit_LargeGoodsGanreCodeSt.Text = dGoodsGanre.LargeGoodsGanreCode;

                    ////中分類
                    //this.tEdit_MediumGoodsGanreCodeSt.Text = dGoodsGanre.MediumGoodsGanreCode;


                    ////小分類
                    //this.tEdit_DetailGoodsGanreCodeSt.Text = dGoodsGanre.DetailGoodsGanreCode;

                    //this.tEdit_LargeGoodsGanreCodeSt.Focus();
                    // --- DEL 2008/09/24 --------------------------------<<<<<
                }
            }
        }
        /// <summary>
        /// 商品区分グループガイド（終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsGanreCodeEdGuid_Click(object sender, EventArgs e)
        {
            if (sender is UltraButton)
            {
                DGoodsGanreAcs dGoodsGanreAcs = new DGoodsGanreAcs();
                DGoodsGanre dGoodsGanre = new DGoodsGanre();

                if (dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1) == 0)
                {
                    // --- DEL 2008/09/24 -------------------------------->>>>>
                    ////大分類
                    //this.tEdit_LargeGoodsGanreCodeEd.Text = dGoodsGanre.LargeGoodsGanreCode;

                    ////中分類
                    //this.tEdit_MediumGoodsGanreCodeEd.Text = dGoodsGanre.MediumGoodsGanreCode;


                    ////小分類
                    //this.tEdit_DetailGoodsGanreCodeEd.Text = dGoodsGanre.DetailGoodsGanreCode;

                    //this.tEdit_LargeGoodsGanreCodeSt.Focus();
                    // --- DEL 2008/09/24 --------------------------------<<<<<
                }
            }
        }
        /// <summary>
        /// ＢＬガイド（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCodeStGuid_Click(object sender, EventArgs e)
        {
            BLGoodsCdAcs BLGoodsCdAcs = new BLGoodsCdAcs();
            BLGoodsCdUMnt bLGoodsCdUMnt;
            int status = BLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_BLGoodsCode_St.DataText = bLGoodsCdUMnt.BLGoodsHalfName;  //ADD 2011/08/16
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
        }
        /// <summary>
        /// ＢＬガイド（終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCodeEdGuid_Click(object sender, EventArgs e)
        {
            BLGoodsCdAcs BLGoodsCdAcs = new BLGoodsCdAcs();
            BLGoodsCdUMnt bLGoodsCdUMnt;
            int status = BLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_BLGoodsCode_Ed.DataText = bLGoodsCdUMnt.BLGoodsHalfName;  //ADD 2011/08/16

                if (this._mode == 0 || this._mode == 2) // 商品別、得意先別
                {
                    this.tEdit_GoodsNo_St.Focus();
                }
                else
                {
                    this.tde_SalesDateSt.Focus();
                }
            }
        }

        /// <summary>
        /// 仕入先(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierCdStGuid_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tEdit_SupplierCd_St.DataText = supplier.SupplierSnm;  //ADD 2011/08/16
                this.tNedit_SupplierCd_Ed.Focus();
            }
        }

        /// <summary>
        /// 仕入先(終了)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierCdEdGuid_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                this.tEdit_SupplierCd_Ed.DataText = supplier.SupplierSnm;   //ADD 2011/08/16
                this.tNedit_GoodsMakerCd_St.Focus();
            }
        }

        /// <summary>
        /// 商品大分類(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsLGroupStGuide_Click(object sender, EventArgs e)
        {
            UserGdBd userGdBd;
            UserGdHd userGdHd;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                this.tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);
                this.tEdit_GoodsLGroup_St.DataText = userGdBd.GuideName;  //ADD 2011/08/16
                this.tNedit_GoodsLGroup_Ed.Focus();
            }
        }

        /// <summary>
        /// 商品大分類(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsLGroupEdGuide_Click(object sender, EventArgs e)
        {
            UserGdBd userGdBd;
            UserGdHd userGdHd;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                this.tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);
                this.tEdit_GoodsLGroup_Ed.DataText = userGdBd.GuideName;  //ADD 2011/08/16
                this.tNedit_GoodsMGroup_St.Focus();
            }
        }

        /// <summary>
        /// 商品中分類(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMGroupStGuide_Click(object sender, EventArgs e)
        {
            // 商品中分類ガイド起動
            GoodsGroupU goodgroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);
                this.tEdit_GoodsMGroup_St.DataText = goodgroupU.GoodsMGroupName;  //ADD 2011/08/16
                this.tNedit_GoodsMGroup_Ed.Focus();
            }
        }

        /// <summary>
        /// 商品中分類(終了)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMGroupEdGuide_Click(object sender, EventArgs e)
        {
            // 商品中分類ガイド起動
            GoodsGroupU goodgroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);
                this.tEdit_GoodsMGroup_Ed.DataText = goodgroupU.GoodsMGroupName;  //ADD 2011/08/16
                this.tNedit_BLGloupCode_St.Focus();
            }
        }

        /// <summary>
        /// グループコード(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
        /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
        /// </remarks>
        private void uButton_BLGroupCodeStGuide_Click(object sender, EventArgs e)
        {
            // BLグループガイド起動
            BLGroupU blGroupU;

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                //this.tEdit_BLGloupCode_St.DataText = blGroupU.BLGroupName;  //ADD 2011/08/16 //DEL 2011/09/09
                this.tEdit_BLGloupCode_St.DataText = this.GetNameFromCode(blGroupU.BLGroupCode.ToString(),6);//ADD 2011/09/09
                this.tNedit_BLGloupCode_Ed.Focus();
            }
        }

        /// <summary>
        /// グループコード(終了)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
        /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
        /// </remarks>
        private void uButton_BLGroupCodeEdGuide_Click(object sender, EventArgs e)
        {
            // BLグループガイド起動
            BLGroupU blGroupU;

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                //this.tEdit_BLGloupCode_Ed.DataText = blGroupU.BLGroupName;  //ADD 2011/08/16 //DEL 2011/09/09
                this.tEdit_BLGloupCode_Ed.DataText = this.GetNameFromCode(blGroupU.BLGroupCode.ToString(),6);// ADD 2011/09/09

                if (this._mode == 0 || this._mode == 1) // 商品別、BLコード別
                {
                    this.tNedit_BLGroupCode1.Focus();
                }
                else if (this._mode == 2) // 得意先別
                {
                    this.tNedit_BLGoodsCode_St.Focus();
                }
            }
        }

        /// <summary>
        /// グループコード(単体)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGroupCodeGuide_Click(object sender, EventArgs e)
        {
            // BLグループガイド起動
            BLGroupU blGroupU;

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this.tNedit_BLGroupCode1.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode1.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode2.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode2.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode3.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode3.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode4.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode4.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode5.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode5.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode6.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode6.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode7.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode7.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode8.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode8.SetInt(blGroupU.BLGroupCode);
                }
                else if (this.tNedit_BLGroupCode9.GetInt() == 0)
                {
                    this.tNedit_BLGroupCode9.SetInt(blGroupU.BLGroupCode);
                }
                else
                {
                    // すべて埋まっている場合は10番目を上書き
                    this.tNedit_BLGroupCode10.SetInt(blGroupU.BLGroupCode);
                }
            }
        }

        #endregion

        #region ◎ UI保存関連

        /// <summary>
        /// UI保存コンポーネント書込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/09/08</br>
        /// <br>改行条件チェックボックスの状態を保存する。</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            //customizeData = new string[9]; // DEL 2009/02/10
            customizeData = new string[11]; // ADD 2009/02/10

            if (this.CheckEditor_SubtotalSection.Checked) customizeData[0] = "1";
            else customizeData[0] = "0";

            if (this.CheckEditor_SubtotalSupplier.Checked) customizeData[1] = "1";
            else customizeData[1] = "0";

            if (this.CheckEditor_SubtotalMaker.Checked) customizeData[2] = "1";
            else customizeData[2] = "0";

            if (this.CheckEditor_SubtotalGoodsLGroup.Checked) customizeData[3] = "1";
            else customizeData[3] = "0";

            if (this.CheckEditor_SubtotalGoodsMGroup.Checked) customizeData[4] = "1";
            else customizeData[4] = "0";

            if (this.CheckEditor_SubtotalGroupCode.Checked) customizeData[5] = "1";
            else customizeData[5] = "0";

            if (this.CheckEditor_SubtotalBl.Checked) customizeData[6] = "1";
            else customizeData[6] = "0";

            if (this.CheckEditor_SubtotalSalesEmployee.Checked) customizeData[7] = "1";
            else customizeData[7] = "0";

            if (this.CheckEditor_SubtotalCustomer.Checked) customizeData[8] = "1";
            else customizeData[8] = "0";

            // --- ADD 2009/02/10 -------------------------------->>>>>
            // 印刷範囲が0か未入力を分ける
            if (this.tNedit_PrintRangeSt.Text == string.Empty)
            {
                customizeData[9] = string.Empty;
            }
            else
            {
                customizeData[9] = this.tNedit_PrintRangeSt.GetInt().ToString();
            }

            if (this.tNedit_PrintRangeEd.Text == string.Empty)
            {
                customizeData[10] = string.Empty;
            }
            else
            {
                customizeData[10] = this.tNedit_PrintRangeEd.GetInt().ToString();
            }
            // --- ADD 2009/02/10 --------------------------------<<<<<
        }

        /// <summary>
        /// UI保存コンポーネント読込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/09/08</br>
        /// <br>改行条件チェックボックスの状態を復元する。</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                if (customizeData[0] == "1") this.CheckEditor_SubtotalSection.Checked = true;
                else this.CheckEditor_SubtotalSection.Checked = false;

                if (customizeData[1] == "1") this.CheckEditor_SubtotalSupplier.Checked = true;
                else this.CheckEditor_SubtotalSupplier.Checked = false;

                if (customizeData[2] == "1") this.CheckEditor_SubtotalMaker.Checked = true;
                else this.CheckEditor_SubtotalMaker.Checked = false;

                if (customizeData[3] == "1") this.CheckEditor_SubtotalGoodsLGroup.Checked = true;
                else this.CheckEditor_SubtotalGoodsLGroup.Checked = false;

                if (customizeData[4] == "1") this.CheckEditor_SubtotalGoodsMGroup.Checked = true;
                else this.CheckEditor_SubtotalGoodsMGroup.Checked = false;

                if (customizeData[5] == "1") this.CheckEditor_SubtotalGroupCode.Checked = true;
                else this.CheckEditor_SubtotalGroupCode.Checked = false;

                if (customizeData[6] == "1") this.CheckEditor_SubtotalBl.Checked = true;
                else this.CheckEditor_SubtotalBl.Checked = false;

                if (customizeData[7] == "1") this.CheckEditor_SubtotalSalesEmployee.Checked = true;
                else this.CheckEditor_SubtotalSalesEmployee.Checked = false;

                if (customizeData[8] == "1") this.CheckEditor_SubtotalCustomer.Checked = true;
                else this.CheckEditor_SubtotalCustomer.Checked = false;

                // --- ADD 2009/02/10 -------------------------------->>>>>
                if (customizeData[9] == string.Empty) this.tNedit_PrintRangeSt.Text = string.Empty;
                else this.tNedit_PrintRangeSt.SetInt(Convert.ToInt32(customizeData[9]));

                if (customizeData[10] == string.Empty) this.tNedit_PrintRangeEd.Text = string.Empty;
                else this.tNedit_PrintRangeEd.SetInt(Convert.ToInt32(customizeData[10]));
                // --- ADD 2009/02/10 --------------------------------<<<<<
            }
        }

        #endregion

        /// <summary>
        /// 集計方法 変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_TtlType_ValueChanged(object sender, EventArgs e)
        {
            // --- ADD 2008/12/09 -------------------------------->>>>>
            if (this._initializeFinished)
            {
                // 改頁制御
                // 選択値を保存
                object tmpObj;

                if (this.tComboEditor_CrMode.SelectedItem != null)
                {
                    tmpObj = this.tComboEditor_CrMode.SelectedItem.DataValue;
                }
                else
                {
                    tmpObj = 0;
                }

                this.tComboEditor_CrMode.ResetItems();

                this.SetNewPageDiv();

                this.tComboEditor_CrMode.Value = tmpObj;

                if (this.tComboEditor_CrMode.SelectedItem == null)
                {
                    this.tComboEditor_CrMode.SelectedIndex = 0;
                }

                if (this.tComboEditor_CrMode.Items.Count == 0
                    || this.tComboEditor_CrMode.Items.Count == 1)
                {
                    this.tComboEditor_CrMode.Enabled = false;
                }
                else
                {
                    this.tComboEditor_CrMode.Enabled = true;
                }
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<

            // 小計印刷のチェック
            SettComboEditor_Detail();

        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>
        /// 品番集計区分SelectionChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GoodsNoTtlDiv_SelectionChanged(object sender, EventArgs e)
        {
            // 品番集計区分が「合算」時
            if (this.tComboEditor_GoodsNoTtlDiv.SelectedIndex == 1)
            {
                this.tComboEditor_GoodsNoShowDiv.Enabled = true;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
            }
            else
            {
                this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
            }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// <summary>
        /// 明細単位 変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_Detail_ValueChanged(object sender, EventArgs e)
        {
            // --- ADD 2008/12/09 -------------------------------->>>>>
            if (this._initializeFinished)
            {
                // 改頁制御
                // 選択値を保存
                object tmpObj;

                if (this.tComboEditor_CrMode.SelectedItem != null)
                {
                    tmpObj = this.tComboEditor_CrMode.SelectedItem.DataValue;
                }
                else
                {
                    tmpObj = 0;
                }

                this.tComboEditor_CrMode.ResetItems();

                this.SetNewPageDiv();

                this.tComboEditor_CrMode.Value = tmpObj;

                if (this.tComboEditor_CrMode.SelectedItem == null)
                {
                    this.tComboEditor_CrMode.SelectedIndex = 0;
                }

                if (this.tComboEditor_CrMode.Items.Count == 0
                    || this.tComboEditor_CrMode.Items.Count == 1)
                {
                    this.tComboEditor_CrMode.Enabled = false;
                }
                else
                {
                    this.tComboEditor_CrMode.Enabled = true;
                }
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<

            // 小計印刷のチェック
            SettComboEditor_Detail();
        }

        /// <summary>
        /// リターンキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

            // --------------------- 2011/08/16 ------------------- >>>>>
            // 仕入先
            if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                //仕入先コード取得
                string supplierCd = this.tNedit_SupplierCd_St.DataText;
                // 仕入先名称取得
                if (!string.IsNullOrEmpty((supplierCd)))
                    this.tEdit_SupplierCd_St.DataText = GetNameFromCode(supplierCd, 0);
                else
                    this.tEdit_SupplierCd_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                //仕入先コード取得
                string supplierCd = this.tNedit_SupplierCd_Ed.DataText;
                // 仕入先名称取得
                if (!string.IsNullOrEmpty((supplierCd)))
                    this.tEdit_SupplierCd_Ed.DataText = GetNameFromCode(supplierCd, 0);
                else
                    this.tEdit_SupplierCd_Ed.DataText = "";
            }

            //担当者
            if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
            {
                //担当者コード取得
                string employeeCode = this.tEdit_EmployeeCode_St.DataText;
                // 担当者名称取得
                if (!string.IsNullOrEmpty((employeeCode)))
                    this.tEdit_EmployeeCode_St_Name.DataText = GetNameFromCode(employeeCode, 1);
                else
                    this.tEdit_EmployeeCode_St_Name.DataText = ""; 
            }

            if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
            {
                //担当者コード取得
                string employeeCode = this.tEdit_EmployeeCode_Ed.DataText;
                // 担当者名称取得
                if (!string.IsNullOrEmpty((employeeCode)))
                    this.tEdit_EmployeeCode_Ed_Name.DataText = GetNameFromCode(employeeCode, 1);
                else
                    this.tEdit_EmployeeCode_Ed_Name.DataText = "";
            }

            //得意先
            if (e.PrevCtrl == this.tNedit_CustomerCode_St)
            {
                //得意先コード取得
                string code = this.tNedit_CustomerCode_St.DataText;
                // 得意先名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_CustomerCode_St.DataText = GetNameFromCode(code, 2);
                else
                    this.tEdit_CustomerCode_St.DataText = "";

            }

            if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
            {
                //得意先コード取得
                string code = this.tNedit_CustomerCode_Ed.DataText;
                //得意先名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_CustomerCode_Ed.DataText = GetNameFromCode(code, 2);
                else
                    this.tEdit_CustomerCode_Ed.DataText = "";

            }
            //メーカー
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMakerCd_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_GoodsMakerCd_St.DataText = GetNameFromCode(code, 3);
                else
                    this.tEdit_GoodsMakerCd_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMakerCd_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_GoodsMakerCd_Ed.DataText = GetNameFromCode(code, 3);
                else
                    this.tEdit_GoodsMakerCd_Ed.DataText = "";
            }
            //商品大分類
            if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsLGroup_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_GoodsLGroup_St.DataText = GetNameFromCode(code, 4);
                else
                    this.tEdit_GoodsLGroup_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsLGroup_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_GoodsLGroup_Ed.DataText = GetNameFromCode(code, 4);
                else
                    this.tEdit_GoodsLGroup_Ed.DataText = "";

            }
            //商品中分類
            if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMGroup_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_GoodsMGroup_St.DataText = GetNameFromCode(code, 5);
                else
                    this.tEdit_GoodsMGroup_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMGroup_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_GoodsMGroup_Ed.DataText = GetNameFromCode(code, 5);
                else
                    this.tEdit_GoodsMGroup_Ed.DataText = "";
            }
            //グループコード
            if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGloupCode_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_BLGloupCode_St.DataText = GetNameFromCode(code, 6);
                else
                    this.tEdit_BLGloupCode_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGloupCode_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_BLGloupCode_Ed.DataText = GetNameFromCode(code, 6);
                else
                    this.tEdit_BLGloupCode_Ed.DataText = "";
            }
            //BLコード
            if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGoodsCode_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_BLGoodsCode_St.DataText = GetNameFromCode(code, 7);
                else
                    this.tEdit_BLGoodsCode_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGoodsCode_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty((code)))
                    this.tEdit_BLGoodsCode_Ed.DataText = GetNameFromCode(code, 7);
                else
                    this.tEdit_BLGoodsCode_Ed.DataText = "";
            }
            // --------------------- 2011/08/16 ------------------- <<<<<
            if (e.PrevCtrl == this.tde_SalesDateSt)
            {
                int longdate = this.tde_SalesDateSt.GetLongDate();

                longdate = (longdate / 100) * 100 + 1;

                this.tde_SalesDateSt.SetLongDate(longdate);
            }

            if (e.PrevCtrl == this.tde_SalesDateEd)
            {
                int longdate = this.tde_SalesDateEd.GetLongDate();

                longdate = (longdate / 100) * 100 + 1;

                this.tde_SalesDateEd.SetLongDate(longdate);
            }


            /* --- DEL 2008/10/27 MAX値入力時、空白としない為 --------------------------------------------------------------->>>>>
            if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                if (this.tNedit_SupplierCd_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_SupplierCd_Ed.ExtEdit.Column))))
                {
                    this.tNedit_SupplierCd_Ed.SetInt(0);
                }
            }

            if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
            {
                if (this.tEdit_EmployeeCode_Ed.Text == "9999")
                {
                    this.tEdit_EmployeeCode_Ed.Text = "";
                }
            }

            if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
            {
                if (this.tNedit_CustomerCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_CustomerCode_Ed.ExtEdit.Column))))
                {
                    this.tNedit_CustomerCode_Ed.SetInt(0);
                }
            }

            if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                if (this.tNedit_GoodsMakerCd_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_GoodsMakerCd_Ed.ExtEdit.Column))))
                {
                    this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                }
            }

            if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
            {
                if (this.tNedit_GoodsLGroup_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_GoodsLGroup_Ed.ExtEdit.Column))))
                {
                    this.tNedit_GoodsLGroup_Ed.SetInt(0);
                }
            }

            if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
            {
                if (this.tNedit_GoodsMGroup_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_GoodsMGroup_Ed.ExtEdit.Column))))
                {
                    this.tNedit_GoodsMGroup_Ed.SetInt(0);
                }
            }

            if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            {
                if (this.tNedit_BLGloupCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_BLGloupCode_Ed.ExtEdit.Column))))
                {
                    this.tNedit_BLGloupCode_Ed.SetInt(0);
                }
            }

            if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                if (this.tNedit_BLGoodsCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_BLGoodsCode_Ed.ExtEdit.Column))))
                {
                    this.tNedit_BLGoodsCode_Ed.SetInt(0);
                }
            }

            if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
            {
                if (this.tEdit_GoodsNo_Ed.Text == "999999999999999999999999")
                {
                    this.tEdit_GoodsNo_Ed.Text = "";
                }
            }
               --- DEL 2008/10/27 -------------------------------------------------------------------------------------------<<<<< */
        }
        // --- ADD 2008/09/24 --------------------------------<<<<<

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
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}

		}
		#endregion

		#endregion ◆ ueb_MainExplorerBar

		#endregion ■ Control Event
       
	}
}