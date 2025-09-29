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
    /// 支払一覧表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払一覧表UIフォームクラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.09.10</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.11.06</br>
    /// <br></br>
    /// </remarks>
	public partial class DCKAK02501UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 支払一覧表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払一覧表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// <br></br>
		/// </remarks>
		public DCKAK02501UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

			// 支払一覧表アクセスクラス
            this._suplierPayMainAcs = new SuplierPayMainAcs();

            // 2008.11.07 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
            this._supplierAcs = new SupplierAcs();
            // 2008.11.07 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END        
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
		// 支払一覧表アクセスクラス
        private SuplierPayMainAcs _suplierPayMainAcs;

        // 2008.11.07 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
        SupplierAcs _supplierAcs;
        // 2008.11.07 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END
        
        // 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 得意先ガイド用
		private string _customerTag = "";

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID			= "DCKAK02501UA";
		// プログラムID
		private const string ct_PGID			= "DCKAK02501U";
		// 帳票名称
        private const string ct_PrintName		= "支払一覧表";
        // 帳票キー	
        private const string ct_PrintKey        = "32dd64d0-337b-40fe-810f-cc6f416e21f9";
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintOderGroup			= "PrintOderGroup";			// ソート順
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
        private const string ct_ExBarGroupNm_PayPrintGroup = "PayPrintGroup";	// 支払印刷条件 
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
            SuplierPayMainCndtn extrInfo = new SuplierPayMainCndtn();

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
                // 2008.11.06 30413 犬飼 締日の取得を変更 >>>>>>START
				// 締日
                //this.tde_St_StartCAddUpUpdDate.SetDateTime( TDateTime.GetSFDateNow() );
                //this.tde_Ed_StartCAddUpUpdDate.SetDateTime( TDateTime.GetSFDateNow() );

                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                totalDayCalculator.InitializeHisPayment();
                totalDayCalculator.GetHisTotalDayPayment(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay);
                if (currentTotalDay != DateTime.MinValue)
                {
                    // 2009.01.28 30413 犬飼 前回締処理日を設定するように修正 >>>>>>START
                    //// 今回締処理日を設定
                    //this.tde_CAddUpUpdDate.SetDateTime(currentTotalDay);
                    // 前回締処理日を設定
                    this.tde_CAddUpUpdDate.SetDateTime(prevTotalDay);
                    // 2009.01.28 30413 犬飼 前回締処理日を設定するように修正 <<<<<<END
                }
                else
                {
                    // 現在日時を設定
                    this.tde_CAddUpUpdDate.SetDateTime(DateTime.Now);
                }
                // 2008.11.06 30413 犬飼 締日の取得を変更 <<<<<<END
                
                // 2008.11.14 30413 犬飼 改頁の設定 >>>>>>START
                this.NewPageDiv_tComboEditor.Value = 0;
                // 2008.11.14 30413 犬飼 改頁の設定 <<<<<<END

                // 支払先コード
				this.tNedit_PayeeCode_St.Clear();
				this.tNedit_PayeeCode_Ed.Clear();

                // 2008.11.07 30413 犬飼 支払印刷条件の設定 >>>>>>START
                // 2009.03.19 30413 犬飼 出力金額区分の初期値を請求初期値マスタから設定 >>>>>>START
                //this.tComboEditor_OutputMoneyDiv.Value = 0;
                this.tComboEditor_OutputMoneyDiv.Value = this._suplierPayMainAcs.BillPrtStData.BillTableOutCd;
                // 2009.03.19 30413 犬飼 出力金額区分の初期値を請求初期値マスタから設定 <<<<<<END
                this.tComboEditor_PayeeDetail.Value = 1;
                this.tComboEditor_BalancePayeeDetail.Value = 1;
                // 2008.11.07 30413 犬飼 支払印刷条件の設定 <<<<<<END

                // 2009.01.22 30413 犬飼 親支払先内訳の追加 >>>>>>START
                this.PrPayeeDtl_tComboEditor.Value = 0;
                // 2009.01.22 30413 犬飼 親支払先内訳の追加 <<<<<<END
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
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

			const string ct_InputError = "の入力が不正です";
			const string ct_NoInput	   = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";

            // 2008.11.14 30413 犬飼 開始日→締日 >>>>>>START
			// 開始日のチェック
			if( !this.DateEditInputCheck( this.tde_CAddUpUpdDate, false ) )
			{
                //errMessage		= string.Format( "開始日{0}", ct_InputError );
                errMessage = string.Format("締日{0}", ct_InputError);
				errComponent	= this.tde_CAddUpUpdDate;
				status			= false;
			}
			else if ( this.tde_CAddUpUpdDate.GetDateTime() == DateTime.MinValue )
			{
                //errMessage		= string.Format( "開始日{0}", ct_NoInput );
                errMessage = string.Format("締日{0}", ct_NoInput);
				errComponent	= this.tde_CAddUpUpdDate;
				status			= false;
			}
            // 2008.11.14 30413 犬飼 開始日→締日 <<<<<<END
			
            // 2008.11.06 30413 犬飼 締日(終了日)の削除 >>>>>>START
            //// 終了日のチェック
            //else if (!this.DateEditInputCheck(this.tde_Ed_StartCAddUpUpdDate, false))
            //{
            //    errMessage		= string.Format( "終了日{0}", ct_InputError );
            //    errComponent    = this.tde_Ed_StartCAddUpUpdDate;
            //    status			= false;
            //}
            //else if (this.tde_Ed_StartCAddUpUpdDate.GetDateTime() == DateTime.MinValue)
            //{
            //    errMessage		= string.Format( "終了日{0}", ct_NoInput );
            //    errComponent    = this.tde_Ed_StartCAddUpUpdDate;
            //    status			= false;
            //}
            //// 日付の範囲をチェック(開始日 > 終了日 → NG)
            //else if (this.tde_St_StartCAddUpUpdDate.GetLongDate() > this.tde_Ed_StartCAddUpUpdDate.GetLongDate())
            //{
            //    errMessage		= string.Format( "日付{0}", ct_RangeError );
            //    errComponent	= this.tde_St_StartCAddUpUpdDate;
            //    status			= false;
            //}
            // 2008.11.06 30413 犬飼 締日(終了日)の削除 <<<<<<END

            // 2008.11.14 30413 犬飼 支払先コード→仕入先 >>>>>>START
            // 支払先コード
            else if ((this.tNedit_PayeeCode_St.GetInt() > this.tNedit_PayeeCode_Ed.GetInt()) && (this.tNedit_PayeeCode_Ed.GetInt() != 0))
			{
                //errMessage		= string.Format( "支払先コード{0}", ct_RangeError );
                errMessage = string.Format("仕入先{0}", ct_RangeError);
				errComponent	= this.tNedit_PayeeCode_St;
				status			= false;
			}
            // 2008.11.14 30413 犬飼 支払先コード→仕入先 <<<<<<END
            
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
        /// <br>Date		: 2007.09.10</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(SuplierPayMainCndtn extraInfo)
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
				// 締日
                //extraInfo.St_CAddUpUpdExecDate = this.tde_St_StartCAddUpUpdDate.GetDateTime();		// 開始
                extraInfo.CAddUpUpdExecDate = this.tde_CAddUpUpdDate.GetDateTime();
                // 2008.11.06 30413 犬飼 締日(終了日)の削除 >>>>>>START
                //extraInfo.Ed_CAddUpUpdExecDate = this.tde_Ed_StartCAddUpUpdDate.GetDateTime();		// 終了
                // 2008.11.06 30413 犬飼 締日(終了日)の削除 <<<<<<END

                // 2008.11.14 30413 犬飼 改頁の設定 >>>>>>START
                extraInfo.NewPageDiv = (int)this.NewPageDiv_tComboEditor.Value;
                // 2008.11.14 30413 犬飼 改頁の設定 <<<<<<END
                
                // 支払先コード
				extraInfo.St_PayeeCode = this.tNedit_PayeeCode_St.GetInt();				// 開始
				extraInfo.Ed_PayeeCode = this.tNedit_PayeeCode_Ed.GetInt();				// 終了

                // 2008.11.06 30413 犬飼 支払印刷条件の追加 >>>>>>START
                extraInfo.OutputMoneyDiv = (int)this.tComboEditor_OutputMoneyDiv.Value;             // 出力金額区分
                extraInfo.PayeeDetail = (int)this.tComboEditor_PayeeDetail.Value;                   // 支払先内訳
                extraInfo.BalancePayeeDetail = (int)this.tComboEditor_BalancePayeeDetail.Value;     // 残高支払内訳
                // 2008.11.06 30413 犬飼 支払印刷条件の追加 <<<<<<END

                // 2009.01.22 30413 犬飼 親支払先内訳の追加 >>>>>>START
                extraInfo.PrPayeeDtl = (int)this.PrPayeeDtl_tComboEditor.Value;                     // 親支払先内訳
                // 2009.01.22 30413 犬飼 親支払先内訳の追加 <<<<<<END                
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
		#region ◆ DCKAK02501UA
        #region ◎ DCKAK02501UA_Load Event
        /// <summary>
        /// DCKAK02501UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.09.10</br>
        /// </remarks>
        private void DCKAK02501UA_Load(object sender, EventArgs e)
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
        #endregion ◆ DCKAK02501UA

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
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) ||
                ( e.Group.Key == ct_ExBarGroupNm_PayPrintGroup))
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
                ( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
                ( e.Group.Key == ct_ExBarGroupNm_PayPrintGroup))
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
		private void Initialize_Timer_Tick ( object sender, EventArgs e )
		{
			Initialize_Timer.Enabled = false;
			string errMsg = string.Empty;

			try
			{
				this.Cursor = Cursors.WaitCursor;

                // 2009.03.19 30413 犬飼 請求初期値設定から末日印字区分の取得 >>>>>>START
                // 請求初期値設定の取得
                int status = this._suplierPayMainAcs.ReadBillPrtSt(LoginInfoAcquisition.EnterpriseCode, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    this.ParentForm.Close();
                    return;
                }
                // 2009.03.19 30413 犬飼 請求初期値設定から末日印字区分の取得 <<<<<<END
                
				// コントロール初期化
                //int status = this.InitializeScreen(out errMsg);
                status = this.InitializeScreen(out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
					return;
				}

				// ガイドボタンのアイコン設定
				this.SetIconImage( this.ub_St_PayeeCodeGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_PayeeCodeGuid, Size16_Index.STAR1 );

				ParentToolbarSettingEvent( this );	// ツールバー設定イベント
			}
			finally
			{
				this.tde_CAddUpUpdDate.Focus();

				this.Cursor = Cursors.Default;
			}
		}
		#endregion
		#endregion ◆ Initialize_Timer

        // 2009.01.22 30413 犬飼 未使用メソッドのコメント化 >>>>>>START
		#region ◆ ub_St_CustomerCdGuid
		#region ◎ Click Event
        ///// <summary>
        ///// Click Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_CustomerCdGuid_Click ( object sender, EventArgs e )
        //{
        //    SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
        //    customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
        //    customerSearchForm.ShowDialog(this);
        //}
		#endregion
		#endregion ◆ ub_St_CustomerCdGuid
        // 2009.01.22 30413 犬飼 未使用メソッドのコメント化 <<<<<<END

        // 2009.01.22 30413 犬飼 未使用メソッドのコメント化 >>>>>>START
        #region ■ Private Event
        #region ◆ 得意先(支払先)選択時発生イベント

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
        //        this.tNedit_PayeeCode_St.SetInt(customerSearchRet.CustomerCode);
        //    }
        //    else
        //    {
        //        this.tNedit_PayeeCode_Ed.SetInt(customerSearchRet.CustomerCode);
        //    }

        //}
    
        #endregion
        // 2009.01.22 30413 犬飼 未使用メソッドのコメント化 <<<<<<END

        /// <summary>
        /// Control.Click イベント(ub_St_PayeeCodeGuid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 仕入先（開始）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.07</br>
        /// </remarks>
        private void ub_St_PayeeCodeGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_PayeeCode_St.SetInt(supplier.SupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// Control.Click イベント(ub_Ed_PayeeCodeGuid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 仕入先（終了）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.07</br>
        /// </remarks>
        private void ub_Ed_PayeeCodeGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_PayeeCode_Ed.SetInt(supplier.SupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

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
                    if (e.PrevCtrl == this.tNedit_PayeeCode_St)
                    {
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_PayeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PayeeCode_Ed)
                    {
                        // 仕入先(終了)→出力金額区分
                        e.NextCtrl = this.tComboEditor_OutputMoneyDiv;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_OutputMoneyDiv)
                    {
                        // 出力金額区分→仕入先(終了)
                        e.NextCtrl = this.tNedit_PayeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PayeeCode_Ed)
                    {
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_PayeeCode_St;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// 支払先内訳のテキスト変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note 　　  : 支払先内訳のテキスト変更イベントを処理します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.22</br>
        /// </remarks>
        private void tComboEditor_PayeeDetail_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)((TComboEditor)sender).Value;

            if (value == 1)
            {
                // 支払先内訳が支払先
                this.PrPayeeDtl_tComboEditor.Value = 0;
                this.PrPayeeDtl_tComboEditor.Enabled = false;
            }
            else
            {
                // 支払先内訳が支払先以外
                this.PrPayeeDtl_tComboEditor.Enabled = true;
            }
        }

    }
}