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

using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.AppStyling;
using System.ComponentModel.Design;
using System.Drawing.Design;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入先元帳UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先元帳UIフォームクラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br>Programmer : 30365 宮津 銀次郎</br>
    /// <br>Date       : 2009.1.28 PM.NS対応。プログラムIDが変更され、仕様変更より金額区分削除。</br>
    /// <br>Update Note: 2014/02/26 田建委</br>
    /// <br>           : Redmine#42188 出力金額区分追加</br>
    /// <br>Update Note: 2014/09/16 時シン</br>
    /// <br>           : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
    /// </remarks>
	public partial class PMKOU02030UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
        /// 仕入先元帳UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入先元帳UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
        /// <br>Update Note: 2014/09/16 時シン</br>
        /// <br>           : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
		/// <br></br>
		/// </remarks>
		public PMKOU02030UA ()
		{
            try
            {
                InitializeComponent();

                // 企業コード取得
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // 拠点用のHashtable作成
                this._selectedSectionList = new Hashtable();

                // 仕入先元帳アクセスクラス
                this._supplierLedgerAcs = new SupplierLedgerAcs();

                // 日付取得部品
                _dateGet = DateGetAcs.GetInstance();

                // 月次締更新
                //_monthlyAddUpHis = new MonthlyAddUpHis();//TODO

                //----- ADD 2014/02/26 田建委 Redmine#42188 ---------->>>>>
                List<Control> ctrlList = new List<Control>();
                ctrlList.Add(this.PrintMoneyDiv_tComboEditor);
                ctrlList.Add(this.SlipNoPrintDiv_tComboEditor);//  ADD 2014/09/16 時シン 伝票番号印字区分の追加
                uiMemInput1.TargetControls = ctrlList;
                //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        // 仕入先元帳アクセスクラス
        private SupplierLedgerAcs _supplierLedgerAcs;

        // 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        //// 得意先ガイド用
        //private string _customerTag = "";

        //仕入先アクセス
        private SupplierAcs _supplierAcs = new SupplierAcs();

        // 日付取得部品
        private DateGetAcs _dateGet;

        //private MonthlyAddUpHis _monthlyAddUpHis;//TODO
		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID			= "PMKOU02030UA";
		// プログラムID
		private const string ct_PGID			= "PMKOU02030U";
		// 帳票名称
        private const string ct_PrintName		= "仕入先元帳";
        // 帳票キー	
        private const string ct_PrintKey        = "32dd64d0-337b-40fe-810f-cc6f416e21f9";
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
		#endregion

		#region ■ IPrintConditionInpType メンバ
		#region ◆ Public Event
		/// <summary> 親ツールバー設定イベント </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion ◆ Public Event

		#region ◆ Public Property

        /// <summary> 拠点オプション(仕様から末梢されたが無いと継承元が怒る) </summary>
        public bool IsOptSection
		{
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
		}

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
        /// <br>Date		: 2007.11.26</br>
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
            LedgerCmnCndtn extrInfo = new LedgerCmnCndtn();
            //SuplierPayInfGetParameter extrInfo = new SuplierPayInfGetParameter();

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
        /// <br>Date		: 2007.11.26</br>
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
        /// <br>Date		: 2007.11.26</br>
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
        /// <br>Date		: 2007.11.26</br>
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
        /// <br>Date		: 2007.11.26</br>
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
        /// <br>Date		: 2007.11.26</br>
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
        /// <br>Date		: 2007.11.26</br>
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
        /// <br>Date		: 2007.11.26</br>
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
        /// <br>Date		: 2007.11.26</br>
        /// <br>Update Note : 2014/02/26 田建委</br>
        /// <br>            : Redmine#42188 出力金額区分追加</br>
        /// <br>Update Note : 2014/09/16 時シン</br>
        /// <br>            : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                DateTime yearMonth;
                this._dateGet.GetThisYearMonth(out yearMonth);
                this.St_AddUpYearMonth_tDateEdit.DateFormat = emDateFormat.df4Y2M;
                this.St_AddUpYearMonth_tDateEdit.SetDateTime(yearMonth);
                this.Ed_AddUpYearMonth_tDateEdit.DateFormat = emDateFormat.df4Y2M;
                this.Ed_AddUpYearMonth_tDateEdit.SetDateTime(yearMonth);
                // (年月日yyyyMMdd→年月yyyyMM→年月日yyyyMM01に変換)
                this.St_AddUpYearMonth_tDateEdit.LongDate = this.St_AddUpYearMonth_tDateEdit.LongDate / 100 * 100 + 1;
                this.Ed_AddUpYearMonth_tDateEdit.LongDate = this.Ed_AddUpYearMonth_tDateEdit.LongDate / 100 * 100 + 1;

                // 得意先コード
				this.tne_St_CustomerCode.SetInt( 0 );
				this.tne_Ed_CustomerCode.SetInt( 0 );
                // 出力区分
                this.tce_OutDiv.SelectedIndex = 0;

                this.PrintMoneyDiv_tComboEditor.SelectedIndex = 0; // ADD 2014/02/26 田建委 Redmine#42188
                this.SlipNoPrintDiv_tComboEditor.SelectedIndex = 0; //  ADD 2014/09/16 時シン 伝票番号印字区分の追加
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
        /// <br>Date		: 2007.11.26</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

			const string ct_InputError = "の入力が不正です";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_RangeError1 = "の範囲指定に誤りがあります(１２ヶ月以内で設定して下さい)";

            this.St_AddUpYearMonth_tDateEdit.LongDate = this.St_AddUpYearMonth_tDateEdit.LongDate / 100 * 100 + 1;
            this.Ed_AddUpYearMonth_tDateEdit.LongDate = this.Ed_AddUpYearMonth_tDateEdit.LongDate / 100 * 100 + 1;

            // 未出荷経過（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref St_AddUpYearMonth_tDateEdit, ref Ed_AddUpYearMonth_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("処理月(開始){0}", ct_InputError);
                            errComponent = St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("処理月(開始){0}", ct_InputError);
                            errComponent = St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("処理月(終了){0}", ct_InputError);
                            errComponent = Ed_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("処理月(終了){0}", ct_InputError);
                            errComponent = Ed_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("処理月{0}", ct_RangeError);
                            errComponent = this.St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("処理月{0}", ct_RangeError1);
                            errComponent = this.St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                }
                status = false;
            }
			// 仕入先コード
            else if ((this.tne_St_CustomerCode.GetInt() > this.tne_Ed_CustomerCode.GetInt()) && (this.tne_Ed_CustomerCode.GetInt() != 0))
			{
				errMessage		= string.Format( "仕入先コード{0}", ct_RangeError );
				errComponent	= this.tne_St_CustomerCode;
				status			= false;
			}

			return status;
		}
		#endregion

		#region ◎ 年月入力チェック処理
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpYearMonth"></param>
        /// <param name="tde_Ed_AddUpYearMonth"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpYearMonth, ref TDateEdit tde_Ed_AddUpYearMonth)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
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
        /// <br>Date		: 2007.11.26</br>
        /// <br>Update Note : 2014/02/26 田建委</br>
        /// <br>            : Redmine#42188 出力金額区分追加</br>
        /// <br>Update Note : 2014/09/16 時シン</br>
        /// <br>            : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(LedgerCmnCndtn extraInfo)
        //private int SetExtraInfoFromScreen(SuplierPayInfGetParameter extraInfo)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 企業コード
				extraInfo.EnterpriseCode = this._enterpriseCode;
                
                // 選択拠点
                string[] SecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                ArrayList secList = new ArrayList();

                foreach (string wk in SecCodeList)
                {
                    secList.Add(wk);
                }
                extraInfo.AddupSecCodeList = secList;

                // 対象年月
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;

                iSMonth = this.St_AddUpYearMonth_tDateEdit.GetLongDate() / 100;
                iEMonth = this.Ed_AddUpYearMonth_tDateEdit.GetLongDate() / 100;

                extraInfo.StartTargetYearMonth = iSMonth;
                extraInfo.EndTargetYearMonth = iEMonth;

                // 得意先コード
                extraInfo.StartCustomerCode = this.tne_St_CustomerCode.GetInt();				// 開始
                extraInfo.EndCustomerCode   = this.tne_Ed_CustomerCode.GetInt();				// 終了
                // 出力帳票区分
                extraInfo.ListDivCode = (int)this.tce_OutDiv.SelectedItem.DataValue;

                // 出力金額区分
                extraInfo.OutMoneyDiv = (LedgerCmnCndtn.OutMoneyDivState)this.PrintMoneyDiv_tComboEditor.SelectedIndex; // ADD 2014/02/26 田建委 Redmine#42188

                // 伝票番号印字区分
                extraInfo.PrintDiv = this.SlipNoPrintDiv_tComboEditor.SelectedIndex; //  ADD 2014/09/16 時シン 伝票番号印字区分の追加
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
        /// <br>Date	   : 2007.11.26</br>
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
        /// <br>Date	   : 2007.11.26</br>
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
		#region ◆ PMKOU02030UA
        #region ◎ PMKOU02030UA_Load Event
        /// <summary>
        /// PMKOU02030UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.11.26</br>
        /// </remarks>
        private void PMKOU02030UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // 初期データ読込(拠点情報等を取得しStaticで取って置く)
            string message;
            int status = this._supplierLedgerAcs.InitSettingDataRead(this._enterpriseCode, out message);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                emErrorLevel errLevel = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    errLevel = emErrorLevel.ERR_LEVEL_STOPDISP;
                }
                MsgDispProc(errLevel, message, status);
                return;
            }
        }

		#endregion
        #endregion ◆ PMKOU02030UA

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
        /// <br>Date		: 2007.11.26</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
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
        /// <br>Date		: 2007.11.26</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
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
        /// <remarks>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
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

				// ガイドボタンのアイコン設定
				this.SetIconImage( this.ub_St_CustomerCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCdGuid, Size16_Index.STAR1 );

				ParentToolbarSettingEvent( this );	// ツールバー設定イベント
			}
			finally
			{
                uiMemInput1.ReadMemInput(); // ADD 2014/02/26 田建委 Redmine#42188
                this.St_AddUpYearMonth_tDateEdit.Focus();

				this.Cursor = Cursors.Default;
			}
		}
		#endregion
		#endregion ◆ Initialize_Timer

		#region ◆ ub_St_CustomerCdGuid
		#region DEL[◎ Click Event]
        ///// <summary>
        ///// Click Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_CustomerCdGuid_Click ( object sender, EventArgs e )
        //{
        //    SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
        //    customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
        //    customerSearchForm.ShowDialog(this);
        //}
		#endregion
		#endregion ◆ ub_St_CustomerCdGuid

        #region ■ Private Event
        #region DEL済[◆ 得意先(支払先)選択時発生イベント]

        ///// <summary>
        ///// 得意先(支払先)選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        ///// <remarks>
        ///// <br>Note        :得意先ガイドで得意先を選択した時に発生します</br>
        ///// <br>Programmer  :20081 疋田 勇人</br>
        ///// <br>Date        :2007.11.26</br>
        ///// </remarks>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    //得意先(仕入先)コードをセット     
        //    if ( this._customerTag.CompareTo("1") == 0 )
        //    {
        //        this.tne_St_CustomerCode.SetInt(customerSearchRet.CustomerCode);
        //    }
        //    else
        //    {
        //        this.tne_Ed_CustomerCode.SetInt(customerSearchRet.CustomerCode);
        //    }

        //}
    
        #endregion

        private void ultraLabel11_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void ub_St_CustomerCdGuid_Click(object sender, EventArgs e)
        {
            string supplierName = ((UltraButton)sender).Name;

            Supplier supplier;
            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            if (status == 0)
            {
                if (supplierName == "ub_St_CustomerCdGuid")
                {
                    this.tne_St_CustomerCode.SetInt(supplier.SupplierCd);

                    this.tne_Ed_CustomerCode.Focus();
                }
                else
                {
                    this.tne_Ed_CustomerCode.SetInt(supplier.SupplierCd);

                    this.St_AddUpYearMonth_tDateEdit.Focus();
                }
            }
        }

    }
}