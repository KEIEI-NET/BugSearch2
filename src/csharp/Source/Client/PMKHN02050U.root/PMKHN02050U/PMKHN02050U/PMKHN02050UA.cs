//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表 ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/11  修正内容 : Redmine 仕様変更 #22915、障害報告 #22858 の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/12  修正内容 : Redmine 仕様変更 #22934 の対応
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
using Broadleaf.Application.Controller.Util;
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
    /// キャンペーン実績表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン実績表UIフォームクラス</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/05/19</br>
    /// <br></br>
    /// </remarks>
	public partial class PMKHN02050UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer,			// 帳票業務（条件入力）PDF出力履歴管理
                                IPrintConditionInpTypeGuidExecuter
	{
		#region ■ Constructor
		/// <summary>
		/// キャンペーン実績表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : キャンペーン実績表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
		/// <br></br>
		/// </remarks>
		public PMKHN02050UA ()
		{
			InitializeComponent();
            
			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            this._secInfoSetAcs = new SecInfoSetAcs();          // 拠点

            this._campaignStAcs = new CampaignStAcs();

			//日付取得部品
			this._dateGet = DateGetAcs.GetInstance();
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
		private string _enterpriseCode = string.Empty;
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
        private CampaignRsltList _campaignRsltList;

		// ガイド系アクセスクラス
		EmployeeAcs _employeeAcs;

        // 得意先ガイド用
        private UltraButton _customerGuideSender;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        //キャンペーンガイド用
        private CampaignStAcs _campaignStAcs;

        // ユーザーガイド用
        private UserGuideAcs _userGuideAcs;

        // グループコードガイド用
        private BLGroupUAcs _blGroupUAcs;
        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;

		//日付取得部品
		private DateGetAcs _dateGet;

        // キャンペーンコード（前回値）
        private int _preCampaignCode;

        /// <summary>キャンペーン実施拠点</summary>
        private string _campExecSecCode = string.Empty;

        private Control _errComponent;

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
		private const string ct_ClassID = "PMKHN02050UA";
		// プログラムID
		private const string ct_PGID = "PMKHN02050U";
		//// 帳票名称
		private const string PDF_PRINT_NAME = "キャンペーン実績表";
		private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
		private const string PDF_PRINT_KEY = "461a402f-20c6-4b5e-817f-790237550131";
		private string _printKey = PDF_PRINT_KEY;

        private bool _campaignCodeExistFlg = true;
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintOderGroup         = "PrintOderGroup";
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件

        //エラー条件メッセージ
		const string ct_NoExist = "キャンペーンコードが存在しません。";
        const string ct_GetError = "キャンペーンコードの取得に失敗しました。";
        const string ct_NoInput = "キャンペーンコードを設定して下さい。";
        const string ct_DateNoInput = "を入力して下さい。";
        const string ct_InputError = "の入力が不正です。";
        const string ct_OutRange = "キャンペーン適用日範囲外です。";
        const string ct_RangeError = "の範囲指定に誤りがあります";
        const string ct_NotOnYearError = "12ヶ月以内で入力して下さい。";

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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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

            // 選択可能な帳票のリストは起動時のパラメータで制御
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                    {
                        // 印刷タイプ:期間の場合
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 20;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 10;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 12;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 11;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 22;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 21; 
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 32;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 31;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 42;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 41;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 52;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 51;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachSales: // 販売区分別
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 62;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 61;
                        }
                        break;
                    }
            }
            
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._campaignRsltList;
			printDialog.PrintInfo		= printInfo;
			
			// 帳票選択ガイド
			DialogResult dialogResult = printDialog.ShowDialog();

			if( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) 
            {
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = string.Empty;

            _errComponent = null;
			if( !this.ScreenInputCheck( ref errMessage, ref _errComponent ) )
			{
                if (!string.IsNullOrEmpty(errMessage))
                {
                    // メッセージを表示
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                    // コントロールにフォーカスをセット
                    if (_errComponent != null)
                    {
                        // キャンペーンコード（前回値）
                        if (_errComponent == this.tNedit_CampaignCode)
                        {
                            this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                            if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                            {
                                this.tNedit_CampaignCode.Clear();
                            }
                        }

                        //errComponent.Focus();
                        this.SetControlFocus(_errComponent);
                    }
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public void Show( object parameter )
		{
			this._campaignRsltList = new CampaignRsltList();

            // 抽出条件に起動パラメータをセット
            if (parameter.ToString().CompareTo("0") == 0)
            {
                // 0:商品別
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachGoods;
            }
            else if (parameter.ToString().CompareTo("1") == 0)
            {
                // 1:得意先別
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachCustomer;
            }
            else if (parameter.ToString().CompareTo("2") == 0)
            {
                // 2:担当者別
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachEmployee;
            }
            else if (parameter.ToString().CompareTo("3") == 0)
            {
                // 3:受注者別
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachAcceptOdr;
            }
            else if (parameter.ToString().CompareTo("4") == 0)
            {
                // 4:発行者別
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachPrinter;
            }
            else if (parameter.ToString().CompareTo("5") == 0)
            {
                // 5:地区別
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachArea;
            }
            else if (parameter.ToString().CompareTo("6") == 0)
            {
                // 6:販売区分別
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachSales;
            }

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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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
		}
		#endregion

		#region ◎ 初期選択計上拠点設定処理( 未実装 )
		/// <summary>
		/// 初期選択計上拠点設定処理( 未実装 )
		/// </summary>
		/// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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

        #region ■ IPrintConditionInpTypeGuidExecuter メンバ
        #region ◆ Public Event
        /// <summary> 親印刷設定イベント </summary>
        public event ParentPrint ParentPrintCall;
        /// <summary> 親ツールバーガイド設定イベント </summary>
        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Method
        #region ◎ ガイドボタンの処理
        /// <summary>
        /// ガイドボタンの処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンをクリックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tNedit_CampaignCode.Focused)
            {
                uButton_CampaignCodeGuid_Click(uButton_CampaignGuid, e);
            }
            else if (this.tEdit_SalesEmployeeCode_St.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_EmployeeCdStGuid, e);
            }
            else if (this.tEdit_SalesEmployeeCode_Ed.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_EmployeeCdEdGuid, e);
            }
            else if (this.tEdit_SalesInputCode_St.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_PrinterStGuid, e);
            }
            else if (this.tEdit_SalesInputCode_Ed.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_PrinterEdGuid, e);
            }
            else if (this.tNedit_SalesAreaCode_St.Focused)
            {
                uButton_AreaCdStGuide_Click(uButton_AreaCdStGuide, e);
            }
            else if (this.tNedit_SalesAreaCode_Ed.Focused)
            {
                uButton_AreaCdStGuide_Click(uButton_BLCodeEdGuide, e);
            }
            else if (this.tNedit_CustomerCode_St.Focused)
            {
                uButton_CustomerCdStGuide_Click(uButton_CustomerCdStGuide, e);
            }
            else if (this.tNedit_CustomerCode_Ed.Focused)
            {
                uButton_CustomerCdStGuide_Click(uButton_CustomerCdEdGuide, e);
            }
            else if (this.tNedit_SalesCode_St.Focused)
            {
                uButton_GuideCodeStGuide_Click(uButton_GuideCodeStGuide, e);
            }
            else if (this.tNedit_SalesCode_Ed.Focused)
            {
                uButton_GuideCodeStGuide_Click(uButton_GuideCodeEdGuide, e);
            }
            else if (this.tNedit_GroupCode_St.Focused)
            {
                uButton_GroupCodeStGuide_Click(uButton_GroupCodeStGuide, e);
            }
            else if (this.tNedit_GroupCode_Ed.Focused)
            {
                uButton_GroupCodeStGuide_Click(uButton_GroupCodeEdGuide, e);
            }
            else if (this.tNedit_BLCode_St.Focused)
            {
                uButton_BLCodeStGuide_Click(uButton_BLCodeStGuide, e);
            }
            else if (this.tNedit_BLCode_Ed.Focused)
            {
                uButton_BLCodeStGuide_Click(uButton_BLCodeEdGuide, e);
            }
            else if (this.tEdit_AcceptOdrCode_St.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_AcceptOdrCdStGuid, e);
            }
            else if (this.tEdit_AcceptOdrCode_Ed.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_AcceptOdrCdEdGuid, e);
            }
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypeGuidExecuter メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
		/// 画面初期化処理
		/// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private int InitializeScreen( out string errMsg )
		{            
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
                        
			try
            {                
                #region 出力条件                
                // 印刷タイプ
                this.tComboEditor_PrintType.Value = 0;

                // 明細単位
                this.tComboEditor_Detail.Value = 0;

                // 小計単位
                this.tComboEditor_Total.Value = 0;
               
                #endregion

                #region 画面コンポーネントの制御
                // 出力順
                Infragistics.Win.ValueListItem listItem;

                switch (this._campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                        {
                            // 改ページ
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = false;
                            this.ulCheckEdt_Area.Visible = false;
                            // ソート順
                            this.OutputSort_panel.Visible = false;
                            this.tComboEditor_OutputSort.Value = 0;
                            this.ultraExplorerBarContainerControl1.Height = this.PrintSort_panel.Location.Y + 4;
                            this.PrintSort_panel.Location = this.OutputSort_panel.Location;
                            // 抽出条件
                            this.salesEmployee_panel.Visible = false;
                            // ----- UPD 2011/07/11 ----->>>>>
                            //this.Customer_panel.Visible = false;
                            this.Customer_panel.Visible = true;
                            this.uebcc_ExtractCondition.Height = this.GroupCode_panel.Location.Y + 4;
                            // ----- UPD 2011/07/11 -----<<<<<
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Location = this.salesEmployee_panel.Location;
                            this.BLCode_panel.Location = this.Customer_panel.Location;
                            this.Customer_panel.Location = new Point(this.GuideCode_panel.Location.X, this.GuideCode_panel.Location.Y + 4); // ADD 2011/07/11
                            // this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4; // DEL 2011/07/11
                            
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                        {
                            // 対象日付(開始)(終了) = 空白
                            this.tde_SalesDateSt.Clear();
                            this.tde_SalesDateEd.Clear();
                            // 改ページ
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = true;
                            this.ulCheckEdt_Emp.Text = "得意先毎で改頁";
                            // ソート順
                            this.OutputSort_panel.Visible = true;
                            this.tComboEditor_OutputSort.Value = 0;
                            this.PrintSort_panel.Visible = true;
                            // 抽出条件
                            this.Customer_panel.Visible = true;
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.Customer_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = 35;
                            this.tNedit_CustomerCode_St.Value = string.Empty;
                            this.tNedit_CustomerCode_Ed.Value = string.Empty;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                        {
                            //改ページ
                            this.ulCheckEdt_Section.Checked = true;
                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0：担当者";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1：得意先";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2：担当者－拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3：管理拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;
                            this.Customer_panel.Visible = true;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                        {
                            //改ページ
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = true;
                            this.ulCheckEdt_Emp.Text = "受注者毎で改頁";
                            //抽出条件
                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0：受注者";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1：得意先";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2：受注者－拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3：管理拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;

                            // 非表示の項目制御
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.AcceptOdr_panel.Visible = true;
                            this.AcceptOdr_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                        {
                            //改ページ
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = true;
                            this.ulCheckEdt_Emp.Text = "発行者毎で改頁";
                            //抽出条件
                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0：発行者";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1：得意先";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2：発行者－拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3：管理拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;

                            // 非表示の項目制御
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.Printer_panel.Visible = true;
                            this.Printer_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                        {
                            this.ulCheckEdt_Section.Checked = true;

                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0：地区";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1：得意先";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2：地区－拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3：管理拠点";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;

                            // 非表示の項目制御
                            this.ulCheckEdt_Area.Visible = true;
                            this.ulCheckEdt_Area.Location = this.ulCheckEdt_Emp.Location;

                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.AcceptOdr_panel.Visible = false;
                            this.Area_panel.Visible = true;
                            this.Area_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachSales: // 販売区分別
                        {
                            this.ultraExplorerBarContainerControl1.Height = this.PrintSort_panel.Location.Y + 4;
                            this.uebcc_ExtractCondition.Height = 79 + 4;
                            //改ページ
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = false;
                            //ソート順
                            this.OutputSort_panel.Visible = false;
                            this.PrintSort_panel.Location = this.OutputSort_panel.Location;
                            //抽出条件
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Location = this.salesEmployee_panel.Location;

                            // 非表示の項目制御
                            this.salesEmployee_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            break;
                        }
                }

                // 印刷順
                this.tComboEditor_PrintSort.Value = 0;

				// ガイドボタン設定
                this.SetIconImage(this.uButton_CampaignGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AcceptOdrCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AcceptOdrCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCdStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCdEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GuideCodeStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GuideCodeEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GroupCodeStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GroupCodeEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_BLCodeStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_BLCodeEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCdStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCdEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_PrinterStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_PrinterEdGuid, Size16_Index.STAR1);
                #endregion
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;
            CampaignSt campaignSt;
            int campaignCode = 0;

            // ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ
            if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text) || "000000".Equals(this.tNedit_CampaignCode.Text.PadLeft(6, '0')))
            {
                errMessage = string.Format("{0}", ct_NoInput);
                errComponent = this.tNedit_CampaignCode;

                this.tNedit_CampaignCode.Clear();
                this.tNedit_CampaignName.Clear();
                this.tDateEdit_ApplyDateSt.Clear();
                this.tDateEdit_ApplyDateEd.Clear();

                this._preCampaignCode = 0;

                status = false;
                return status;
            }

            else if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                campaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);

                int campStatus = this._campaignStAcs.Read(out campaignSt, this._enterpriseCode, campaignCode);

                if (campStatus != 0)
                {
                    errMessage = string.Format("{0}", ct_NoExist);
                    errComponent = this.tNedit_CampaignCode;

                    status = false;
                    return status;
                }
                else
                {
                    if (campaignSt.LogicalDeleteCode != 0)
                    {
                        errMessage = string.Format("{0}", ct_NoExist);
                        errComponent = this.tNedit_CampaignCode;

                        status = false;
                        return status;
                    }
                    else
                    {
                        this.tNedit_CampaignCode_Leave(null, null);
                    }
                }
            }
            else
            {
                if (this.checkCampaignCode() != 0)
                {
                    status = false;
                    return status;
                }
            }

            // 対象日付
            if ((int)this.tComboEditor_PrintType.Value != 2 && CallCheckDateRange(out cdrResult, ref tde_SalesDateSt, ref tde_SalesDateEd, false, true, true) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象日付{0}", ct_InputError);
                            errComponent = this.tde_SalesDateSt;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象日付{0}", ct_InputError);
                            errComponent = this.tde_SalesDateEd;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象日付{0}", ct_InputError);
                            errComponent = this.tde_SalesDateSt;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象日付{0}", ct_InputError);
                            errComponent = this.tde_SalesDateEd;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象日付{0}", ct_RangeError);
                            errComponent = this.tde_SalesDateEd;
                            status = false;
                        }
                        break;
                    default:
                        {
                            //範囲が12ヶ月を超える
                            if (!DateCheck(tde_SalesDateEd.GetDateTime(), tde_SalesDateSt.GetDateTime()))
                            {
                                errMessage = string.Format("{0}", ct_NotOnYearError);
                                errComponent = this.tde_SalesDateEd;
                                status = false;
                            }
                        }
                        break;
                }
            }
            else if ((int)this.tComboEditor_PrintType.Value == 2)
            {
                if (CallCheckDateRange(out cdrResult, ref tDateEdit_St, ref tDateEdit_End, false, true, true) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("開始対象日付{0}", ct_DateNoInput);
                                errComponent = this.tDateEdit_St;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("終了対象日付{0}", ct_DateNoInput);
                                errComponent = this.tDateEdit_End;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("開始対象日付{0}", ct_InputError);
                                errComponent = this.tDateEdit_St;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("終了対象日付{0}", ct_InputError);
                                errComponent = this.tDateEdit_End;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("対象日付{0}", ct_RangeError);
                                errComponent = this.tDateEdit_End;
                                status = false;
                            }
                            break;
                        default:
                            {
                                //範囲が12ヶ月を超える
                                if (!DateCheck(tDateEdit_End.GetDateTime(), tDateEdit_St.GetDateTime()))
                                {
                                    errMessage = string.Format("{0}", ct_NotOnYearError);
                                    errComponent = this.tDateEdit_End;
                                    status = false;
                                }
                            }
                            break;
                    }

                }
            }

            if (status)
            {
                if ((int)this.tComboEditor_PrintType.Value != 2)
                {
                    DateTime staratDate1;
                    DateTime endDate1;
                    DateTime staratDate2;
                    DateTime endDate2;
                    this._dateGet.GetDaysFromMonth(this.tde_SalesDateSt.GetDateTime(), out staratDate1, out endDate1);
                    this._dateGet.GetDaysFromMonth(this.tde_SalesDateEd.GetDateTime(), out staratDate2, out endDate2);

                    if (staratDate1 < this.tDateEdit_ApplyDateSt.GetDateTime() &&
                         endDate2 < this.tDateEdit_ApplyDateSt.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tde_SalesDateEd;
                        status = false;
                        return status;
                    }

                    if (staratDate1 > this.tDateEdit_ApplyDateEd.GetDateTime() &&
                         endDate2 > this.tDateEdit_ApplyDateEd.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tde_SalesDateSt;
                        status = false;
                        return status;
                    }
                }
                else
                {
                    if (tDateEdit_St.GetDateTime() < tDateEdit_ApplyDateSt.GetDateTime() && tDateEdit_End.GetDateTime() < tDateEdit_ApplyDateSt.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tDateEdit_End;
                        status = false;
                        return status;
                    }

                    if (tDateEdit_St.GetDateTime() > tDateEdit_ApplyDateEd.GetDateTime() && tDateEdit_End.GetDateTime() > tDateEdit_ApplyDateEd.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tDateEdit_St;
                        status = false;
                        return status;
                    }
                }

                // 担当者
                if (
                    (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd()) > 0))
                {
                    errMessage = string.Format("担当者{0}", ct_RangeError);
                    errComponent = this.tEdit_SalesEmployeeCode_Ed;
                    status = false;
                    return status;
                }

                // 地区
                if (
                    (this.tNedit_SalesAreaCode_St.GetInt() != 0) &&
                    (this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                    this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt())
                {
                    errMessage = string.Format("地区{0}", ct_RangeError);
                    errComponent = this.tNedit_SalesAreaCode_Ed;
                    status = false;
                    return status;
                }

                // 受注者
                if (
                    (this.tEdit_AcceptOdrCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_AcceptOdrCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_AcceptOdrCode_St.DataText.TrimEnd().CompareTo(this.tEdit_AcceptOdrCode_Ed.DataText.TrimEnd()) > 0))
                {
                    errMessage = string.Format("受注者{0}", ct_RangeError);
                    errComponent = this.tEdit_AcceptOdrCode_Ed;
                    status = false;
                    return status;
                }

                // 発行者
                if (
                    (this.tEdit_SalesInputCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesInputCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesInputCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesInputCode_Ed.DataText.TrimEnd()) > 0))
                {
                    errMessage = string.Format("発行者{0}", ct_RangeError);
                    errComponent = this.tEdit_SalesInputCode_Ed;
                    status = false;
                    return status;
                }

                // 得意先
                else if ((this.tNedit_CustomerCode_St.Text.Trim() != string.Empty)
                    && (this.tNedit_CustomerCode_Ed.Text.Trim() != string.Empty)
                    && (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
                {
                    errMessage = string.Format("得意先{0}", ct_RangeError);
                    errComponent = this.tNedit_CustomerCode_Ed;
                    status = false;
                    return status;
                }

                // 販売区分
                if (
                    (this.tNedit_SalesCode_St.GetInt() != 0) &&
                    (this.tNedit_SalesCode_Ed.GetInt() != 0) &&
                    this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt())
                {
                    errMessage = string.Format("販売区分{0}", ct_RangeError);
                    errComponent = this.tNedit_SalesCode_Ed;
                    status = false;
                    return status;
                }

                // グループコード
                if (
                    (this.tNedit_GroupCode_St.GetInt() != 0) &&
                    (this.tNedit_GroupCode_Ed.GetInt() != 0) &&
                    this.tNedit_GroupCode_St.GetInt() > this.tNedit_GroupCode_Ed.GetInt())
                {
                    errMessage = string.Format("グループコード{0}", ct_RangeError);
                    errComponent = this.tNedit_GroupCode_Ed;
                    status = false;
                    return status;
                }

                // ＢＬコード
                if (
                    (this.tNedit_BLCode_St.GetInt() != 0) &&
                    (this.tNedit_BLCode_Ed.GetInt() != 0) &&
                    this.tNedit_BLCode_St.GetInt() > this.tNedit_BLCode_Ed.GetInt())
                {
                    errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                    errComponent = this.tNedit_BLCode_Ed;
                    status = false;
                    return status;
                }
            }
            return status;
        }

        /// <summary>
        /// 設定画面入力の時間チェック処理
        /// </summary>
        ///  <remarks>
        /// <br>Note       : 設定画面入力の時間チェック処理します。 </br>
        /// <returns>FLAG</returns>
        /// </remarks>
        private bool DateCheck(DateTime endDt, DateTime staDt)
        {
            bool flag = true;

            if ((endDt.Year - staDt.Year) > 1)//時間大于１年間の場合
            {
                flag = false;
            }
            else if (endDt.Year - staDt.Year == 1)
            {
                if (endDt.Month > staDt.Month) //月比較
                {
                    flag = false;
                }
                else if ((endDt.Month == staDt.Month) && (endDt.Day >= staDt.Day))
                {
                    flag = false;
                }
            }
            return flag;
        }

		#endregion

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <param name="allowNoInput"></param>
        /// <param name="yearCheck"></param>
        /// <param name="rangeCheck"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput, bool yearCheck, bool rangeCheck)
        {
            int range;
            DateGetAcs.YmdType rangType = DateGetAcs.YmdType.YearMonth;
            if ((int)this.tComboEditor_PrintType.Value == 2)
            {
                rangType = DateGetAcs.YmdType.YearMonthDay;
            }

            range = 0;

            cdrResult = _dateGet.CheckDateRange(rangType, range, ref startDateEdit, ref endDateEdit, allowNoInput, yearCheck);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

		#region ◎ 日付入力チェック処理
		/// <summary>
		/// 日付入力チェック処理
		/// </summary>
		/// <param name="targetDateEdit">チェック対象コントロール</param>
		/// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
		/// <returns>チェック結果(true/false)</returns>
		/// <remarks>
		/// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowEmpty )
		{
            bool status = true;

            // 入力日付を数値型で取得
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if (targetDateEdit.LongDate < 10101 && targetDateEdit.GetDateTime() == DateTime.MinValue)
            {
                if (allowEmpty == true)
                {
                    return status;
                }
                else
                {
                    status = false;
                }
            }
            // システムサポートチェック
            else if (yy < 1900)
            {
                status = false;
            }
            // 年月日別入力チェック
            else if ((yy == 0) || (mm == 0) || (dd == 0))
            {
                status = false;
            }
            // 単純日付妥当性チェック
            else if (TDateTime.IsAvailableDate(targetDateEdit.GetDateTime()) == false)
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
            {
                // 企業コード
                this._campaignRsltList.EnterpriseCode = this._enterpriseCode;

                // 選択拠点
                // 拠点オプションありのとき
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // 全社選択かどうか
                    if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
                    {
                        this._campaignRsltList.SectionCodes = null;

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
                        this._campaignRsltList.SectionCodes = (string[])secList.ToArray(typeof(string));
                    }
                }
                // 拠点オプションなしの時
                else
                {
                    this._campaignRsltList.SectionCodes = null;
                }

                // キャンペーンコード
                this._campaignRsltList.CampaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);

                // キャンペーン期間
                this._campaignRsltList.ApplyStaDate = TDateTime.DateTimeToLongDate(this.tDateEdit_ApplyDateSt.GetDateTime());
                this._campaignRsltList.ApplyEndDate = TDateTime.DateTimeToLongDate(this.tDateEdit_ApplyDateEd.GetDateTime());

                // 印刷タイプ
                this._campaignRsltList.PrintType = (int)this.tComboEditor_PrintType.Value;

                // 対象日付
                if (this._campaignRsltList.PrintType == 2)
                {
                    this._campaignRsltList.AddUpYearMonthDaySt = this.tDateEdit_St.GetDateTime();
                    this._campaignRsltList.AddUpYearMonthDayEd = this.tDateEdit_End.GetDateTime();
                }
                else
                {
                    this._campaignRsltList.AddUpYearMonthSt = this.tde_SalesDateSt.GetDateTime();
                    this._campaignRsltList.AddUpYearMonthEd = this.tde_SalesDateEd.GetDateTime();

                    DateTime startDate1;
                    DateTime endDate1;
                    DateTime startDate2;
                    DateTime endDate2;
                    this._dateGet.GetDaysFromMonth(this._campaignRsltList.AddUpYearMonthSt, out startDate1, out endDate1);
                    this._dateGet.GetDaysFromMonth(this._campaignRsltList.AddUpYearMonthEd, out startDate2, out endDate2);

                    this._campaignRsltList.AddUpYearMonthDaySt = startDate1;
                    this._campaignRsltList.AddUpYearMonthDayEd = endDate2;
                }
                // 明細単位
                this._campaignRsltList.Detail = (int)this.tComboEditor_Detail.Value;

                if (this._campaignRsltList.Detail == 0)
                {
                    // 小計単位
                    this._campaignRsltList.Total = (int)this.tComboEditor_Total.Value;
                    
                    if (this._campaignRsltList.PrintType != 1)
                    {
                        // 印刷順
                        this._campaignRsltList.PrintSort = (int)this.tComboEditor_PrintSort.Value;
                    }
                }

                if (_campaignRsltList.TotalType != CampaignRsltList.TotalTypeState.EachSales)
                {
                    // 出力順
                    this._campaignRsltList.OutputSort = (int)this.tComboEditor_OutputSort.Value;
                }

                // 改頁(拠点毎で改頁)
                if (this.ulCheckEdt_Section.Checked)
                {
                    this._campaignRsltList.CrModeSec = 1;
                }
                else
                {
                    this._campaignRsltList.CrModeSec = 0;
                }
                // 改頁(担当者毎で改頁)
                if (this.ulCheckEdt_Emp.Checked)
                {
                    this._campaignRsltList.CrModeEmp = 1;
                }
                else
                {
                    this._campaignRsltList.CrModeEmp = 0;
                }
                // 改頁(地区毎で改頁)
                if (this.ulCheckEdt_Area.Checked)
                {
                    this._campaignRsltList.CrModeArea = 1;
                }
                else
                {
                    this._campaignRsltList.CrModeArea = 0;
                }

                // ----- UPD 2011/07/11 ----- >>>>>
                //if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachCustomer)
                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachCustomer || _campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachGoods)
                // ----- UPD 2011/07/11 ----- <<<<<
                {
                    // 得意先
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachEmployee)
                {
                    // 担当者
                    if (this.tEdit_SalesEmployeeCode_St.DataText == string.Empty) this._campaignRsltList.EmployeeCodeSt = string.Empty;
                    else this._campaignRsltList.EmployeeCodeSt = this.tEdit_SalesEmployeeCode_St.DataText.PadLeft(4, '0');

                    if (this.tEdit_SalesEmployeeCode_Ed.DataText == string.Empty) this._campaignRsltList.EmployeeCodeEd = string.Empty;
                    else this._campaignRsltList.EmployeeCodeEd = this.tEdit_SalesEmployeeCode_Ed.DataText.PadLeft(4, '0');

                    // 得意先
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachArea)
                {
                    // 地区
                    this._campaignRsltList.AreaCodeSt = this.tNedit_SalesAreaCode_St.GetInt();
                    this._campaignRsltList.AreaCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt();

                    // 得意先
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachSales)
                {
                    // 販売区分
                    this._campaignRsltList.SalesCodeSt = this.tNedit_SalesCode_St.GetInt();
                    this._campaignRsltList.SalesCodeEd = this.tNedit_SalesCode_Ed.GetInt();

                    // 得意先
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachAcceptOdr)
                {
                    // 受注者
                    if (this.tEdit_AcceptOdrCode_St.DataText == string.Empty) this._campaignRsltList.AcceptOdrCodeSt = string.Empty;
                    else this._campaignRsltList.AcceptOdrCodeSt = this.tEdit_AcceptOdrCode_St.DataText.PadLeft(4, '0');

                    if (this.tEdit_AcceptOdrCode_Ed.DataText == string.Empty) this._campaignRsltList.AcceptOdrCodeEd = string.Empty;
                    else this._campaignRsltList.AcceptOdrCodeEd = this.tEdit_AcceptOdrCode_Ed.DataText.PadLeft(4, '0');

                    // 得意先
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachPrinter)
                {
                    // 発行者
                    if (this.tEdit_SalesInputCode_St.DataText == string.Empty) this._campaignRsltList.PrinterCodeSt = string.Empty;
                    else this._campaignRsltList.PrinterCodeSt = this.tEdit_SalesInputCode_St.DataText.PadLeft(4, '0');

                    if (this.tEdit_SalesInputCode_Ed.DataText == string.Empty) this._campaignRsltList.PrinterCodeEd = string.Empty;
                    else this._campaignRsltList.PrinterCodeEd = this.tEdit_SalesInputCode_Ed.DataText.PadLeft(4, '0');

                    // 得意先
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                // グループコード
                this._campaignRsltList.BLGroupCodeSt = this.tNedit_GroupCode_St.GetInt();
                this._campaignRsltList.BLGroupCodeEd = this.tNedit_GroupCode_Ed.GetInt();

                // ＢＬコード
                this._campaignRsltList.BLGoodsCodeSt = this.tNedit_BLCode_St.GetInt();
                this._campaignRsltList.BLGoodsCodeEd = this.tNedit_BLCode_Ed.GetInt();
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
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

        /// <summary>
        /// 対象日付に値のセット
        /// </summary>
        /// <remarks>
        /// <br>Note		: 対象日付に値をセットする。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void SetDateTime()
        {
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            // 印刷タイプが「2：日付」を選択時
            if ((int)this.tComboEditor_PrintType.Value == 2)
            {
                this.panel1.Visible = false;
                this.panel2.Visible = true;

                if (this.tDateEdit_ApplyDateSt.GetDateTime() != DateTime.MinValue)
                {
                    this.tDateEdit_St.SetDateTime(this.tDateEdit_ApplyDateSt.GetDateTime());
                    this.tDateEdit_End.SetDateTime(this.tDateEdit_ApplyDateEd.GetDateTime());
                }
            }
            else
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;

                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                if (currentTotalMonth != DateTime.MinValue)
                {
                    // 売上今回月次更新日を設定
                    this.tde_SalesDateSt.SetDateTime(currentTotalMonth);
                    this.tde_SalesDateEd.SetDateTime(currentTotalMonth);
                }
                else
                {
                    // 当月を設定
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.tde_SalesDateSt.SetDateTime(nowYearMonth);
                    this.tde_SalesDateEd.SetDateTime(nowYearMonth);
                }
            }
        }

        /// <summary>
        /// キャンペーン名称取得
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">取得桁</param>
        /// <returns></returns>
        private string CutSubstring(string str, int length)
        {
            string returnstr = string.Empty;

            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            byte[] bt = System.Text.Encoding.Default.GetBytes(str);
            int btlength = bt.Length;

            if (length == 0)
            {
                return string.Empty;
            }
            else if (length >= btlength)
            {
                return str;
            }
            string sr = "";
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                sr = str.Substring(i, 1);
                byte[] bt2 = System.Text.Encoding.Default.GetBytes(sr);
                if (bt2.Length == 1)
                {
                    num = num + 1;
                }
                if (bt2.Length == 2)
                {
                    num = num + 2;
                }

                if (num <= length)
                {
                    returnstr = returnstr + sr;
                }
                else
                {
                    break;
                }
            }
            return returnstr;
        }

        /// <summary>
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/06/03</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 初期フォーカスセット
            this.tNedit_CampaignCode.Focus();

            if (ParentToolbarSettingEvent != null)
                ParentToolbarSettingEvent(this);	// ツールバーボタン設定イベント起動

            ParentToolbarGuideSettingEvent(true);
        }

        /// <summary>
        /// フォーカスを設定する
        /// </summary>
        /// <param name="control"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/06/03</br>
        /// </remarks>
        private void SetControlFocus(Control control)
        {
            control.Focus();
            switch (control.Name)
            {
                case "tNedit_CampaignCode":     // キャンペーンコード
                case "tEdit_SalesEmployeeCode_St":   // 開始担当者コード
                case "tEdit_SalesEmployeeCode_Ed":   // 終了担当者コード
                case "tEdit_SalesInputCode_St": // 開始発行者コード
                case "tEdit_SalesInputCode_Ed": // 終了発行者コード
                case "tNedit_CustomerCode_St":  // 開始得意先コード
                case "tNedit_CustomerCode_Ed":  // 終了得意先コード
                case "tNedit_SalesCode_St":     // 開始販売区分
                case "tNedit_SalesCode_Ed":     // 終了販売区分
                case "tNedit_GroupCode_St":     // 開始グループコード
                case "tNedit_GroupCode_Ed":     // 終了グループコード
                case "tNedit_BLCode_St":        // 開始ＢＬコード
                case "tNedit_BLCode_Ed":        // 終了ＢＬコード
                case "tNedit_SalesAreaCode_St": // 開始地区コード
                case "tNedit_SalesAreaCode_Ed": // 終了地区コード
                case "tEdit_AcceptOdrCode_St":   // 開始受注者コード
                case "tEdit_AcceptOdrCode_Ed":   // 終了受注者コード
                    {
                        ParentToolbarGuideSettingEvent(true);
                        break;
                    }
                default:
                    {
                        ParentToolbarGuideSettingEvent(false);
                        break;
                    }
            }
        }

        /// <summary>
        /// timer1_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/06/03</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.tNedit_CampaignCode.Leave += new EventHandler(this.tNedit_CampaignCode_Leave);
            if (!this._campaignCodeExistFlg)
            {
                this.SetControlFocus(this.tNedit_CampaignCode);
            }
            this._campaignCodeExistFlg = true;
        }
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN02050UA
        #region ◎ PMKHN02050UA_Load Event
        /// <summary>
		/// PMKHN02050UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		private void PMKHN02050UA_Load ( object sender, EventArgs e )
		{
            this.tComboEditor_PrintType.ValueChanged -= new System.EventHandler(this.tComboEditor_PrintType_ValueChanged);

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

            this.Initial_Timer.Enabled = true;

		}
		#endregion

        /// <summary>
        /// PMKHN02050UA_Shownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 対象日付のValueChangedイベントを追加する。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void PMKHN02050UA_Shown(object sender, EventArgs e)
        {
            this.tComboEditor_PrintType.ValueChanged += new System.EventHandler(this.tComboEditor_PrintType_ValueChanged);
        }

        #region ◎ ガイド処理
        /// <summary>
        /// キャンペーンコードガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 選択されたコード、名称を画面へセットする。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void uButton_CampaignCodeGuid_Click(object sender, EventArgs e)
        {
            CampaignSt campaignSt;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ガイド起動
                int status = this._campaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    this.tNedit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                    this.tNedit_CampaignName.Text = CutSubstring(campaignSt.CampaignName, 40);
                    this.tDateEdit_ApplyDateSt.SetDateTime(campaignSt.ApplyStaDate);
                    this.tDateEdit_ApplyDateEd.SetDateTime(campaignSt.ApplyEndDate);

                    this._preCampaignCode = campaignSt.CampaignCode;

                    // 対象日付のセット
                    this.SetDateTime();

                    // フォーカス
                    this.SetControlFocus(tComboEditor_PrintType);

                }
                else
                {
                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 担当者ガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 抽出する範囲を指定する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void uButton_EmployeeCdStGuid_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.uButton_EmployeeCdStGuid)
                {
                    this.tEdit_SalesEmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tEdit_SalesEmployeeCode_Ed);
                }
                else if (sender == this.uButton_EmployeeCdEdGuid)
                {
                    this.tEdit_SalesEmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tNedit_CustomerCode_St);
                }
                else if (sender == this.uButton_PrinterStGuid)
                {
                    this.tEdit_SalesInputCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tEdit_SalesInputCode_Ed);
                }
                else if (sender == this.uButton_PrinterEdGuid)
                {
                    this.tEdit_SalesInputCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tNedit_CustomerCode_St);
                }
                else if (sender == this.uButton_AcceptOdrCdStGuid)
                {
                    this.tEdit_AcceptOdrCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tEdit_AcceptOdrCode_Ed);
                }
                else if (sender == this.uButton_AcceptOdrCdEdGuid)
                {
                    this.tEdit_AcceptOdrCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tNedit_CustomerCode_St);
                }
            }
        }

        /// <summary>
        /// 得意先ガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 抽出する範囲を指定する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void uButton_CustomerCdStGuide_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                this.SetControlFocus(this.tNedit_CustomerCode_Ed);
            }
        }


        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">イベントパラメータ</param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.uButton_CustomerCdStGuide)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

            _customerGuideOK = true;
        }

        /// <summary>
        /// グループコードガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グループコードガイドのクリックを行う</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void uButton_GroupCodeStGuide_Click(object sender, EventArgs e)
        {
            // グループコードガイド起動
            BLGroupU blGroupU;

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GroupCode_St.SetInt(blGroupU.BLGroupCode);
                this.SetControlFocus(tNedit_GroupCode_Ed);
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GroupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.SetControlFocus(tNedit_BLCode_St);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ＢＬコードガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ＢＬコードガイドのクリックを行う</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void uButton_BLCodeStGuide_Click(object sender, EventArgs e)
        {
            // ＢＬコードガイド起動
            BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.SetControlFocus(tNedit_BLCode_Ed);
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.SetControlFocus(tNedit_CampaignCode);
            }
            else
            {
                return;
            }
        }
        #endregion        

		#endregion ◆ PMKHN02050UA

		#region ◆ ueb_MainExplorerBar
		#region ◎ GroupCollapsing Event
		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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
        
        /// <summary>
        /// キャンペーンコードのLeaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void tNedit_CampaignCode_Leave(object sender, EventArgs e)
        {
            this.tNedit_CampaignCode.Leave -= new EventHandler(this.tNedit_CampaignCode_Leave);
            CampaignSt campaignSt;
            int campaignCode = 0;
            if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                campaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);
            }
            else
            {
                this.tNedit_CampaignName.Clear();
                this.tDateEdit_ApplyDateSt.Clear();
                this.tDateEdit_ApplyDateEd.Clear();
                this._preCampaignCode = 0;
                this.timer1.Enabled = true;
                return ;
            }

            int status = this._campaignStAcs.Read(out campaignSt, this._enterpriseCode, campaignCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (campaignSt.LogicalDeleteCode == 0)
                {
                    if (Int32.Parse(this.tNedit_CampaignCode.Text) != this._preCampaignCode)
                    {
                        this.tNedit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                        this.tNedit_CampaignName.Text = CutSubstring(campaignSt.CampaignName, 40);
                        this.tDateEdit_ApplyDateSt.SetDateTime(campaignSt.ApplyStaDate);
                        this.tDateEdit_ApplyDateEd.SetDateTime(campaignSt.ApplyEndDate);

                        // 対象日付のセット
                        this.SetDateTime();
                        this._campExecSecCode = campaignSt.SectionCode;
                        this._preCampaignCode = campaignSt.CampaignCode;
                    }
                }
                else
                {
                    this.SetControlFocus(tNedit_CampaignCode);
                    // メッセージを表示
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoExist, 0);
                    this._campaignCodeExistFlg = false;

                    this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                    if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                    {
                        this.tNedit_CampaignCode.Clear();
                    }
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.SetControlFocus(tNedit_CampaignCode);
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoExist, 0);
                this._campaignCodeExistFlg = false;

                this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                }
            }
            else
            {
                this.SetControlFocus(tNedit_CampaignCode);
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ct_GetError, 0);
                this._campaignCodeExistFlg = false;

                this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                }
            }
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// マスタチェック有り
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private int checkCampaignCode()
        {
            CampaignSt campaignSt;
            int campaignCode = 0;
            if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                campaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);
            }
            else
            {
                this.tNedit_CampaignName.Clear();
                this.tDateEdit_ApplyDateSt.Clear();
                this.tDateEdit_ApplyDateEd.Clear();
                return -1;
            }

            int status = this._campaignStAcs.Read(out campaignSt, this._enterpriseCode, campaignCode);

            if (status == 0)
            {
                this.tNedit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                this.tNedit_CampaignName.Text = CutSubstring(campaignSt.CampaignName, 40);
                this.tDateEdit_ApplyDateSt.SetDateTime(campaignSt.ApplyStaDate);
                this.tDateEdit_ApplyDateEd.SetDateTime(campaignSt.ApplyEndDate);
                this._campExecSecCode = campaignSt.SectionCode;
                this._preCampaignCode = campaignSt.CampaignCode;
            }
            else
            {
                this.SetControlFocus(tNedit_CampaignCode);
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoExist, 0);

                this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                }
            }
            return status;
        }
        /// <summary>
        /// tComboEditor_PrintTypeのValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 印刷タイプに従って、対象日付を年月の形式に変更する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            this.SetDateTime();

            // 印刷タイプが期間の場合
            if ((int)this.tComboEditor_PrintType.Value == 1)
            {
                // ----- UPD 2011/07/12 ----- >>>>>
                //this.tComboEditor_PrintSort.Items.Clear();
                this.tComboEditor_PrintSort.SelectedIndex = 0;
                // ----- UPD 2011/07/12 ----- <<<<<
                this.tComboEditor_PrintSort.Enabled = false;
            }
            else
            {
                if ((int)this.tComboEditor_Detail.Value == 0)
                {
                    // ----- DEL 2011/07/12 ----- >>>>>
                    //this.tComboEditor_PrintSort.Items.Clear();
                    //Infragistics.Win.ValueListItem listItem;

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 0;
                    //listItem.DataValue = 0;
                    //listItem.DisplayText = "0：品番＋メーカー";
                    //this.tComboEditor_PrintSort.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 1;
                    //listItem.DataValue = 1;
                    //listItem.DisplayText = "1：メーカー＋品番";
                    //this.tComboEditor_PrintSort.Items.Add(listItem);

                    //this.tComboEditor_PrintSort.Value = 0;
                    // ----- DEL 2011/07/12 ----- <<<<<
                    this.tComboEditor_PrintSort.Enabled = true;
                }
                else
                {
                    //this.tComboEditor_PrintSort.Items.Clear(); // DEL 2011/07/12
                    this.tComboEditor_PrintSort.Enabled = false;
                }
            }
        }

        /// <summary>
        /// tComboEditor_DetailのValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 明細単位に従って、小計単位と印刷順の入力状態を制御する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void tComboEditor_Detail_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_Detail.Value != 0)
            {
                // ----- UPD 2011/07/12 ----- >>>>>
                //this.tComboEditor_Total.Items.Clear();
                //this.tComboEditor_PrintSort.Items.Clear();
                this.tComboEditor_Total.SelectedIndex = 0;
                this.tComboEditor_PrintSort.SelectedIndex = 0;
                // ----- UPD 2011/07/12 ----- <<<<<
                this.tComboEditor_Total.Enabled = false;
                this.tComboEditor_PrintSort.Enabled = false;
            }
            else
            {
                // 印刷タイプが期間の場合
                if ((int)this.tComboEditor_PrintType.Value == 1)
                {
                    //this.tComboEditor_PrintSort.Items.Clear(); // DEL 2011/07/12
                    this.tComboEditor_PrintSort.Enabled = false;
                }
                else
                {
                    // ----- DEL 2011/07/12 ----- >>>>>
                    //this.tComboEditor_PrintSort.Items.Clear();
                    //Infragistics.Win.ValueListItem listItemPrint;

                    //listItemPrint = new Infragistics.Win.ValueListItem();
                    //listItemPrint.Tag = 0;
                    //listItemPrint.DataValue = 0;
                    //listItemPrint.DisplayText = "0：品番＋メーカー";
                    //this.tComboEditor_PrintSort.Items.Add(listItemPrint);

                    //listItemPrint = new Infragistics.Win.ValueListItem();
                    //listItemPrint.Tag = 1;
                    //listItemPrint.DataValue = 1;
                    //listItemPrint.DisplayText = "1：メーカー＋品番";
                    //this.tComboEditor_PrintSort.Items.Add(listItemPrint);

                    //this.tComboEditor_PrintSort.Value = 0;
                    // ----- DEL 2011/07/12 ----- <<<<<
                    this.tComboEditor_PrintSort.Enabled = true;
                }

                this.tComboEditor_Total.Items.Clear();
                Infragistics.Win.ValueListItem listItemTotal;

                listItemTotal = new Infragistics.Win.ValueListItem();
                listItemTotal.Tag = 0;
                listItemTotal.DataValue = 0;
                listItemTotal.DisplayText = "0：ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                this.tComboEditor_Total.Items.Add(listItemTotal);

                listItemTotal = new Infragistics.Win.ValueListItem();
                listItemTotal.Tag = 1;
                listItemTotal.DataValue = 1;
                listItemTotal.DisplayText = "1：BLｺｰﾄﾞ";
                this.tComboEditor_Total.Items.Add(listItemTotal);

                this.tComboEditor_Total.Value = 0;
                this.tComboEditor_Total.Enabled = true;
            }
        }
        
        /// <summary>
        /// ユーザーガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ユーザーガイドのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void uButton_GuideCodeStGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            //販売区分 
            int GuideNo = 71;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SalesCode_St;
                nextControl = this.tNedit_SalesCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SalesCode_Ed;
                nextControl = this.tNedit_SalesCode_Ed;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // フォーカス移動
            this.SetControlFocus(nextControl);
        }

        /// <summary>
        /// 地区ガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 地区ガイドのクリックを行う</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/26</br>
        /// </remarks>
        private void uButton_AreaCdStGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            //地区
            int GuideNo = 21;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SalesAreaCode_St;
                nextControl = this.tNedit_SalesAreaCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SalesAreaCode_Ed;
                nextControl = this.tNedit_SalesAreaCode_Ed;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // フォーカス移動
            this.SetControlFocus(nextControl);
        }

        /// <summary>
        /// uebcc_SelectListのSizeChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : コントロールの幅に従って、ランの幅をセットする。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void uebcc_SelectList_SizeChanged(object sender, EventArgs e)
        {
            this.tLine1.Width = this.uebcc_SelectList.Width;
        }    

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.NextCtrl == null) return;
            if (e.PrevCtrl == null) return;

            if (e.PrevCtrl != null && e.PrevCtrl.Name == "tNedit_CampaignCode")
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Enter:
                        case Keys.Tab:
                            {
                                if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
                                {
                                    e.NextCtrl = uButton_CampaignGuid;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_PrintType;
                                }
                                break;
                            }
                        case Keys.Right:
                            {
                                e.NextCtrl = uButton_CampaignGuid;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Enter:
                        case Keys.Tab:
                            {
                                if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
                                {
                                    e.NextCtrl = uButton_CampaignGuid;
                                }
                                else
                                {
                                    // 0:商品別
                                    if (this._campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachGoods)
                                    {
                                        e.NextCtrl = tNedit_BLCode_Ed;
                                    }
                                    else
                                    {
                                        e.NextCtrl = tNedit_CustomerCode_Ed;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            if (e.NextCtrl.Name != "tNedit_CampaignCode" && e.NextCtrl.Name != "uButton_CampaignGuid")
            {
                if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text) || "000000".Equals(this.tNedit_CampaignCode.Text.PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                    this.tNedit_CampaignName.Clear();
                    this.tDateEdit_ApplyDateSt.Clear();
                    this.tDateEdit_ApplyDateEd.Clear();

                    this._preCampaignCode = 0;
                    // メッセージを表示
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoInput, 0);
                    e.NextCtrl = tNedit_CampaignCode;
                }
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CampaignCode":     // キャンペーンコード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_CampaignCode.Value);
                        }
                        catch
                        {
                            if (this._preCampaignCode != 0)
                            {
                                tNedit_CampaignCode.Value = this._preCampaignCode;
                            }
                            else
                            {
                                tNedit_CampaignCode.Clear();
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesEmployeeCode_St":   // 開始担当者コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesEmployeeCode_St.Value);
                        }
                        catch
                        {
                            tEdit_SalesEmployeeCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesEmployeeCode_Ed":   // 終了担当者コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesEmployeeCode_Ed.Value);
                        }
                        catch
                        {
                            tEdit_SalesEmployeeCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesInputCode_St": // 開始発行者コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesInputCode_St.Value);
                        }
                        catch
                        {
                            tEdit_SalesInputCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesInputCode_Ed": // 終了発行者コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesInputCode_Ed.Value);
                        }
                        catch
                        {
                            tEdit_SalesInputCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_CustomerCode_St":  // 開始得意先コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_CustomerCode_St.Value);
                        }
                        catch
                        {
                            tNedit_CustomerCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_CustomerCode_Ed":  // 終了得意先コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_CustomerCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_CustomerCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesCode_St":     // 開始販売区分
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesCode_St.Value);
                        }
                        catch
                        {
                            tNedit_SalesCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesCode_Ed":     // 終了販売区分
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_SalesCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_GroupCode_St":     // 開始グループコード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_GroupCode_St.Value);
                        }
                        catch
                        {
                            tNedit_GroupCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_GroupCode_Ed":     // 終了グループコード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_GroupCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_GroupCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_BLCode_St":        // 開始ＢＬコード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_BLCode_St.Value);
                        }
                        catch
                        {
                            tNedit_BLCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_BLCode_Ed":        // 終了ＢＬコード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_BLCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_BLCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesAreaCode_St": // 開始地区コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesAreaCode_St.Value);
                        }
                        catch
                        {
                            tNedit_SalesAreaCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesAreaCode_Ed": // 終了地区コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesAreaCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_SalesAreaCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_AcceptOdrCode_St":   // 開始受注者コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_AcceptOdrCode_St.Value);
                        }
                        catch
                        {
                            tEdit_AcceptOdrCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_AcceptOdrCode_Ed":   // 終了受注者コード
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_AcceptOdrCode_Ed.Value);
                        }
                        catch
                        {
                            tEdit_AcceptOdrCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
            }

            switch (e.NextCtrl.Name)
            {
                case "tNedit_CampaignCode":     // キャンペーンコード
                case "tEdit_SalesEmployeeCode_St":   // 開始担当者コード
                case "tEdit_SalesEmployeeCode_Ed":   // 終了担当者コード
                case "tEdit_SalesInputCode_St": // 開始発行者コード
                case "tEdit_SalesInputCode_Ed": // 終了発行者コード
                case "tNedit_CustomerCode_St":  // 開始得意先コード
                case "tNedit_CustomerCode_Ed":  // 終了得意先コード
                case "tNedit_SalesCode_St":     // 開始販売区分
                case "tNedit_SalesCode_Ed":     // 終了販売区分
                case "tNedit_GroupCode_St":     // 開始グループコード
                case "tNedit_GroupCode_Ed":     // 終了グループコード
                case "tNedit_BLCode_St":        // 開始ＢＬコード
                case "tNedit_BLCode_Ed":        // 終了ＢＬコード
                case "tNedit_SalesAreaCode_St": // 開始地区コード
                case "tNedit_SalesAreaCode_Ed": // 終了地区コード
                case "tEdit_AcceptOdrCode_St":   // 開始受注者コード
                case "tEdit_AcceptOdrCode_Ed":   // 終了受注者コード
                    {
                        ParentToolbarGuideSettingEvent(true);
                        break;
                    }
                default:
                    {
                        if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                            || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                        {
                            ParentToolbarGuideSettingEvent(false);
                        }
                        break;
                    }
            }

            // ----- ADD 2011/07/11 ----- >>>>>
            if (this.ulCheckEdt_Area.Visible)
            {
                if (!e.ShiftKey)
                {
                    if (e.PrevCtrl.Name == "ulCheckEdt_Area")
                    {
                        e.NextCtrl = this.tComboEditor_OutputSort;
                    }
                }
                else
                {
                    if (e.PrevCtrl.Name == "tComboEditor_OutputSort")
                    {
                        e.NextCtrl = this.ulCheckEdt_Area;
                    }
                }
            }
            // ----- ADD 2011/07/11 ----- <<<<<

            // ----- UPD 2011/07/11 ----- >>>>>
            //if (e.PrevCtrl != null 
            //    && ("tNedit_CustomerCode_Ed".Equals(e.PrevCtrl.Name) 
            //    || "tNedit_BLCode_Ed".Equals(e.PrevCtrl.Name)))
            if (e.PrevCtrl != null
                && ("tNedit_CustomerCode_Ed".Equals(e.PrevCtrl.Name)))
            // ----- UPD 2011/07/11 ----- <<<<<
            {
                if (!e.ShiftKey)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Right))
                    {
                        ParentPrintCall();
                        if (this._errComponent != null)
                        {                            
                            e.NextCtrl = this._errComponent;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        e.NextCtrl.Text = this.uiSetControl1.GetZeroPadCanceledText(e.NextCtrl.Name, e.NextCtrl.Text);
                    }
                }
            }
        }

        /// <summary>
        /// tNedit_CampaignCode_Enterイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void tNedit_CampaignCode_Enter(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
            if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                this.tNedit_CampaignCode.Text = (Convert.ToInt32(this.tNedit_CampaignCode.Text)).ToString();
            }
        }

        /// <summary>
        /// ulCheckEdt_Section_CheckedChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void ulCheckEdt_Section_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_OutputSort.Value == null)
            {
                return;
            }

            if ((int)this.tComboEditor_OutputSort.Value == 2)            
            {
                if (this.ulCheckEdt_Section.Checked == true)
                {
                    this.ulCheckEdt_Emp.Checked = true;
                    this.ulCheckEdt_Emp.Enabled = false;
                    this.ulCheckEdt_Area.Checked = true;
                    this.ulCheckEdt_Area.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Emp.Enabled = true;
                    this.ulCheckEdt_Area.Enabled = true;
                }
            }
        }

        /// <summary>
        /// ulCheckEdt_Emp_CheckedChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void ulCheckEdt_Emp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_OutputSort.Value == null)
            {
                return;
            }

            if ((int)this.tComboEditor_OutputSort.Value != 2)
            {
                if (this.ulCheckEdt_Emp.Checked == true)
                {
                    this.ulCheckEdt_Section.Checked = true;
                    this.ulCheckEdt_Section.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Section.Enabled = true;
                }
            }
        }

        /// <summary>
        /// tComboEditor_OutputSort_ValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void tComboEditor_OutputSort_ValueChanged(object sender, EventArgs e)
        {
            // 出力順 = 得意先－拠点 の場合
            if ((int)tComboEditor_OutputSort.Value == 2)
            {
                // 拠点で改頁チェックONの場合
                if (this.ulCheckEdt_Section.Checked == true)
                {
                    this.ulCheckEdt_Section.Enabled = true;
                    this.ulCheckEdt_Emp.Checked = true;
                    this.ulCheckEdt_Emp.Enabled = false;
                    // 地区毎で改頁について
                    this.ulCheckEdt_Area.Checked = true;
                    this.ulCheckEdt_Area.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Emp.Enabled = true;
                    // 地区毎で改頁について
                    this.ulCheckEdt_Area.Enabled = true;
                }
            }
            // 出力順 = 得意先－拠点 以外の場合
            else
            {
                // 担当者で改頁チェックONの場合
                if (this.ulCheckEdt_Emp.Checked == true)
                {
                    this.ulCheckEdt_Emp.Enabled = true;
                    this.ulCheckEdt_Section.Checked = true;
                    this.ulCheckEdt_Section.Enabled = false;
                }
                // 担当者で改頁チェックOFFの場合
                else
                {
                    this.ulCheckEdt_Section.Enabled = true;
                }

                // 地区毎で改頁について
                if (this.ulCheckEdt_Area.Visible == true)
                {
                    // 地区毎で改頁チェックONの場合
                    if (this.ulCheckEdt_Area.Checked == true)
                    {
                        this.ulCheckEdt_Area.Enabled = true;
                        this.ulCheckEdt_Section.Checked = true;
                        this.ulCheckEdt_Section.Enabled = false;
                    }
                    // 地区毎で改頁チェックOFFの場合
                    else
                    {
                        this.ulCheckEdt_Section.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// ulCheckEdt_Area_CheckedChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer  : 丁建雄</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void ulCheckEdt_Area_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_OutputSort.Value == null)
            {
                return;
            }

            if ((int)this.tComboEditor_OutputSort.Value != 2)
            {
                if (this.ulCheckEdt_Area.Checked == true)
                {
                    this.ulCheckEdt_Section.Checked = true;
                    this.ulCheckEdt_Section.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Section.Enabled = true;
                }
            }
        }
        #endregion ■ Control Event
    }
}