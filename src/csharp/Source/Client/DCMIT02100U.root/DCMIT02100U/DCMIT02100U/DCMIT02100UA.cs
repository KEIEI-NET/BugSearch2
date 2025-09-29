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
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12907]：スペースキーでの項目選択機能を実装
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
    /// 見積確認表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 見積確認表UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br>UpdateNote : 2009/04/02 30452 上野 俊治</br>
    /// <br>           : 障害対応10232</br>
    /// <br>UpdateNote : 2009/04/03 30452 上野 俊治</br>
    /// <br>           : 障害対応13089</br>
    /// <br>UpdateNote : 2011/11/11 x_zhuxk</br>
    /// <br>           : ＃redmine 26537</br>
    /// <br></br>
    /// </remarks>
	public partial class DCMIT02100UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 見積確認表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 見積確認表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br></br>
		/// </remarks>
		public DCMIT02100UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // ガイド後次項目ディクショナリ生成
            SettingGuideNextControl();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();
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
		private EstimateListCndtn _estimateListCndtn;

        //// 拠点ガイド用
        //SecInfoSetAcs _secInfoSetAcs;

        //// 倉庫ガイド用
        //WarehouseAcs _wareHouseAcs;

        // 仕入先ガイド用
        private UltraButton _customerGuideSender;
        // 2008.07.31 30413 犬飼 不要プロパティ削除 >>>>>>START
        //private SFTOK01370UA _customerGuid;
        // 2008.07.31 30413 犬飼 不要プロパティ削除 <<<<<<END
        
        //// 商品コード用
        //MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        //GoodsAcs _goodsAcs;
        //GoodsUnitData _goodsUnitData;

        // 担当者ガイド用
        EmployeeAcs _employeeAcs;

        //// 在庫検索(自社分類ガイド用)
        //SearchStockAcs _searchStockAcs;

        // ガイド後次項目ディクショナリ
        private Dictionary<Control, Control> _nextControl;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // ADD 2009/03/31 不具合対応[12907]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>メモ印刷ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _memoPrintDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// メモ印刷ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>メモ印刷ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper MemoPrintDivRadioKeyPressHelper
        {
            get { return _memoPrintDivRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 不具合対応[12907]：スペースキーでの項目選択機能を実装 ----------<<<<<
        // --- ADD 2009/04/01 -------------------------------->>>>>
        /// <summary>日計印字ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uosPrintDailyFooterRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 日計印字ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>日計印字ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper UosPrintDailyFooterRadioKeyPressHelper
        {
            get { return _uosPrintDailyFooterRadioKeyPressHelper; }
        }
        // --- ADD 2009/04/01 --------------------------------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "DCMIT02100UA";
        // プログラムID
        private const string ct_PGID = "DCMIT02100U";
        //// 帳票名称
        private string _printName = "見積確認表";
        // 帳票キー	
        private string _printKey = "4604f88e-ebc8-4183-9b31-84f61717ed2a";
        #endregion ◆ Interface member

		// ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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

			printInfo.PrintPaperSetCd	= 0;
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._estimateListCndtn;
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._estimateListCndtn = new EstimateListCndtn();

			// 抽出条件に起動パラメータをセット
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( parameter.ToString().CompareTo( "1" ) == 0 )
            //{
            //    this._estimateListCndtn.StockMoveFormalDiv = StockMoveCndtn.StockMoveFormalDivState.StockMove;
            //    this._printKey = "461a402f-20c6-4b5e-817f-790237550131";
            //}
            //else if ( parameter.ToString().CompareTo( "2" ) == 0 )
            //{
            //    this._estimateListCndtn.StockMoveFormalDiv = StockMoveCndtn.StockMoveFormalDivState.WareHouseMove;
            //    this._printKey = "edded41e-2702-4de3-95b7-3518c5fae7b1";
            //}
            //else
            //    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK );
            //this._printName = this._estimateListCndtn.StockMoveFormalDivName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
                    // 2008.09.01 30413 犬飼 valueをチェックステータスに変更 >>>>>>START
                    //this._selectedSectionList.Add( sectionCode, sectionCode );
                    this._selectedSectionList.Add(sectionCode, checkState);
                    // 2008.09.01 30413 犬飼 valueをチェックステータスに変更 <<<<<<END
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void InitSelectSection ( string[] sectionCodeLst )
		{
            // 選択リスト初期化
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
                // 2008.09.01 30413 犬飼 valueをチェックステータスに変更 >>>>>>START
                //this._selectedSectionList.Add( wk, wk );
                this._selectedSectionList.Add(wk, CheckState.Checked);
                // 2008.09.01 30413 犬飼 valueをチェックステータスに変更 <<<<<<END
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // 2008.07.31 30413 犬飼 見積日にシステム日付を設定 >>>>>>START
                // 初期値セット・日付
                //this.tde_St_SearchSlipDate.SetDateTime( TDateTime.GetSFDateNow() ); // システム日付
                //this.tde_Ed_SearchSlipDate.SetDateTime( TDateTime.GetSFDateNow() ); // システム日付 
                //this.tde_St_SalesDate.LongDate = 0; // 未入力
                //this.tde_Ed_SalesDate.LongDate = 0; // 未入力 
                this.tde_St_SalesDate.SetDateTime(TDateTime.GetSFDateNow()); // システム日付
                this.tde_Ed_SalesDate.SetDateTime(TDateTime.GetSFDateNow()); // システム日付
                this.tde_St_SearchSlipDate.LongDate = 0; // 未入力 
                this.tde_Ed_SearchSlipDate.LongDate = 0; // 未入力 
                // 2008.07.31 30413 犬飼 見積日にシステム日付を設定 <<<<<<END
                
                // 初期値セット・文字列
                this.tEdit_SalesEmployeeCode_St.DataText = string.Empty; 
                this.tEdit_SalesEmployeeCode_Ed.DataText = string.Empty;

                // 初期値セット・数値
                this.tNedit_CustomerCode_St.SetInt( 0 );
                this.tNedit_CustomerCode_Ed.SetInt( 0 );
                //this.tne_Ed_CustomerCode.SetInt( Int32.Parse( new string( '9', this.tne_Ed_CustomerCode.ExtEdit.Column ) ) );

                // 初期値セット・区分
                this.uos_MemoPrintDiv.Value = (int)EstimateListCndtn.MemoPrintDivState.None;

                // 2008.07.31 30413 犬飼 改頁、見積タイプ、発行タイプを追加 >>>>>>START
                this.tComboEditor_NewPageType.SelectedIndex = 0;
                this.tComboEditor_EstimateDivide.SelectedIndex = 0;
                this.tComboEditor_PrintDiv.SelectedIndex = 0;
                // 2008.07.31 30413 犬飼 改頁、見積タイプ、発行タイプを追加 <<<<<<END
                
                // ボタン設定
                this.SetIconImage( this.ub_St_CustomerGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_CustomerGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_EmployeeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_EmployeeGuide, Size16_Index.STAR1 );

                // 2008.07.31 30413 犬飼 初期フォーカスを見積日に変更 >>>>>>START
                // 初期フォーカスセット
                //this.tde_St_SearchSlipDate.Focus();
                this.tde_St_SalesDate.Focus();
                // 2008.07.31 30413 犬飼 初期フォーカスを見積日に変更 <<<<<<END
                // 2011/11/11 x_zhuxk ＃redmine 26537 >>>>>>START
                // 連携伝票出力区分
                Infragistics.Win.ValueList valueList3 = this.GetDetailValueList1();

                this.tComboEditor_AutoAnswerDiv.ResetItems();

                for (int i = 0; i < valueList3.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList3.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList3.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList3.ValueListItems[i].DisplayText;
                    this.tComboEditor_AutoAnswerDiv.Items.Add(vlltem);
                }

                this.tComboEditor_AutoAnswerDiv.Value = 0;

                //連携伝票対象区分
                this.CheckEditor_PCCforNS.Enabled = false;
                this.CheckEditor_BL.Enabled = false;
                // 2011/11/11 x_zhuxk ＃redmine 26537 <<<<<<END

            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}

        // 2011/11/11 x_zhuxk ＃redmine 26537 >>>>>>START
        #region ◎ 連携伝票出力区分ValueList取得
        /// <summary>
        /// 連携伝票出力区分valueList取得
        /// </summary>
        /// <returns></returns>
        private Infragistics.Win.ValueList GetDetailValueList1()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            valueListItem.Tag = 0;
            valueListItem.DataValue = 0;
            valueListItem.DisplayText = "連携伝票を含まない";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 1;
            valueListItem.DataValue = 1;
            valueListItem.DisplayText = "連携伝票を含む";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 2;
            valueListItem.DataValue = 2;
            valueListItem.DisplayText = "連携伝票のみ対象";
            valueList.ValueListItems.Add(valueListItem);

            return valueList;
        }
        #endregion
        // 2011/11/11 x_zhuxk ＃redmine 26537 <<<<<<END


        /// <summary>
        /// ガイド後次項目の設定
        /// </summary>
        private void SettingGuideNextControl()
        {
            // コントロールのガイド後フォーカス順を設定するリストを生成
            List<Control> controls = new List<Control>();

            // リストに追加する
            controls.AddRange( new Control[] { tNedit_CustomerCode_St, tNedit_CustomerCode_Ed } );
            controls.AddRange( new Control[] { tEdit_SalesEmployeeCode_St, tEdit_SalesEmployeeCode_Ed } );


            // 最終項目は最後に２重に格納する
            controls.Add( controls[controls.Count - 1] );

            // コントロールのリストからディクショナリを生成
            _nextControl = new Dictionary<Control, Control>();
            for ( int index = 0; index < controls.Count - 1; index++ )
            {
                _nextControl.Add( controls[index], controls[index + 1] );
            }
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            //DateGetAcs.CheckDateRangeResult cdrResult; // DEL 2009/04/03
            DateGetAcs.CheckDateResult cdResult;

			const string ct_InputError = "の入力が不正です";
			const string ct_NoInput	   = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            // 2008.08.01 30413 犬飼 範囲を３ケ月に変更 >>>>>>START
            //const string ct_FullRangeError = "は１ヶ月の範囲内で入力して下さい";
            //const string ct_FullRangeError = "は３ヶ月の範囲内で入力して下さい"; // DEL 2009/04/03
            // 2008.08.01 30413 犬飼 範囲を３ケ月に変更 <<<<<<END
            
            // 2008.08.01 30413 犬飼 見積日のチェックを先に行う >>>>>>START
            //--------------------------------------------------------------------------
            // 見積日
            //--------------------------------------------------------------------------
            // --- DEL 2009/04/03 -------------------------------->>>>>
            //if (CallCheckDateRange(out cdrResult, ref tde_St_SalesDate, ref tde_Ed_SalesDate) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("開始見積日{0}", ct_NoInput);
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("開始見積日{0}", ct_InputError);
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("終了見積日{0}", ct_NoInput);
            //                errComponent = this.tde_Ed_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("終了見積日{0}", ct_InputError);
            //                errComponent = this.tde_Ed_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format("見積日{0}", ct_RangeError);
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format("見積日{0}", ct_FullRangeError);
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            // --- DEL 2009/04/03 --------------------------------<<<<<
            // --- ADD 2009/04/03 -------------------------------->>>>>
            if (CallCheckDate(out cdResult, ref tde_St_SalesDate) == false)
            {
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("開始見積日{0}", ct_InputError);
                    errComponent = this.tde_St_SalesDate;
                    status = false;
                }
            }
            else if (CallCheckDate(out cdResult, ref tde_Ed_SalesDate) == false)
            {
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("終了見積日{0}", ct_InputError);
                    errComponent = this.tde_St_SalesDate;
                    status = false;
                }
            }
            else if (tde_St_SalesDate.GetDateTime() > GetEndDate(tde_Ed_SalesDate.GetDateTime()))
            {
                // 開始＞終了
                errMessage = string.Format("見積日{0}", ct_RangeError);
                errComponent = this.tde_St_SalesDate;
                status = false;
            }
            // --- ADD 2009/04/03 --------------------------------<<<<<
            //--------------------------------------------------------------------------
            // 入力日
            //--------------------------------------------------------------------------
            else if (CallCheckDate(out cdResult, ref tde_St_SearchSlipDate) == false)
            {
                // 開始日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("開始入力日{0}", ct_InputError);
                            errComponent = this.tde_St_SearchSlipDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("開始入力日{0}", ct_NoInput);
                            errComponent = this.tde_St_SearchSlipDate;
                        }
                        break;
                }
                status = false;
            }
            // 2008.08.01 30413 犬飼 見積日のチェックを先に行う <<<<<<END
            // 2008.08.01 30413 犬飼 入力日は任意チェックに変更 >>>>>>START
            else if (CallCheckDate(out cdResult, ref tde_Ed_SearchSlipDate) == false)
            {
                // 終了日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("終了入力日{0}", ct_InputError);
                            errComponent = this.tde_Ed_SearchSlipDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("終了入力日{0}", ct_NoInput);
                            errComponent = this.tde_Ed_SearchSlipDate;
                        }
                        break;
                }
                status = false;
            }
            else if (tde_St_SearchSlipDate.GetDateTime() > GetEndDate(tde_Ed_SearchSlipDate.GetDateTime()))
            {
                // 開始＞終了
                errMessage = string.Format("入力日{0}", ct_RangeError);
                errComponent = this.tde_St_SearchSlipDate;
                status = false;
            }
            // 2008.08.01 30413 犬飼 入力日は任意チェックに変更 <<<<<<END

            // 2008.08.01 30413 犬飼 既存チェックの削除 >>>>>>START
            ////--------------------------------------------------------------------------
            //// 入力日
            ////--------------------------------------------------------------------------
            //if ( CallCheckDateRange( out cdrResult, ref tde_St_SearchSlipDate, ref tde_Ed_SearchSlipDate ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "開始入力日{0}", ct_NoInput );
            //                errComponent = this.tde_St_SearchSlipDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "開始入力日{0}", ct_InputError );
            //                errComponent = this.tde_St_SearchSlipDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "終了入力日{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_SearchSlipDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "終了入力日{0}", ct_InputError );
            //                errComponent = this.tde_Ed_SearchSlipDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "入力日{0}", ct_RangeError );
            //                errComponent = this.tde_St_SearchSlipDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "入力日{0}", ct_FullRangeError );
            //                errComponent = this.tde_St_SearchSlipDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            // 2008.08.01 30413 犬飼 既存チェックの削除 <<<<<<END
            //--------------------------------------------------------------------------
            // 見積日
            //--------------------------------------------------------------------------
            //else if ( CallCheckDateRangeForSalesDate( out cdrResult, ref tde_St_SalesDate, ref tde_Ed_SalesDate ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "開始見積日{0}", ct_NoInput );
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "開始見積日{0}", ct_InputError );
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "終了見積日{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "終了見積日{0}", ct_InputError );
            //                errComponent = this.tde_Ed_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "見積日{0}", ct_RangeError );
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "見積日{0}", ct_FullRangeError );
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            // 2008.08.01 30413 犬飼 既存チェックの削除 >>>>>>START
            //else if (CallCheckDate(out cdResult, ref tde_St_SalesDate) == false)
            //{
            //    // 開始日
            //    switch ( cdResult )
            //    {
            //        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
            //            {
            //                errMessage = string.Format( "開始見積日{0}", ct_InputError );
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
            //            {
            //                errMessage = string.Format( "開始見積日{0}", ct_NoInput );
            //                errComponent = this.tde_St_SalesDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //else if ( CallCheckDate( out cdResult, ref tde_Ed_SalesDate ) == false )
            //{
            //    // 終了日
            //    switch ( cdResult )
            //    {
            //        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
            //            {
            //                errMessage = string.Format( "終了見積日{0}", ct_InputError );
            //                errComponent = this.tde_Ed_SalesDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
            //            {
            //                errMessage = string.Format( "終了見積日{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_SalesDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //else if ( tde_St_SalesDate.GetDateTime() > GetEndDate( tde_Ed_SalesDate.GetDateTime() ) )
            //{
            //    // 開始＞終了
            //    errMessage = string.Format( "見積日{0}", ct_RangeError );
            //    errComponent = this.tde_St_SalesDate;
            //    status = false;
            //}
            // 2008.08.01 30413 犬飼 既存チェックの削除 <<<<<<END

            // 2008.08.05 30413 犬飼 担当者のチェックを先に行う >>>>>>START
            //--------------------------------------------------------------------------
            // 担当者
            //--------------------------------------------------------------------------
            else if (
                     (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                     (this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                // 2008.10.28 30413 犬飼 比較前に0埋めを行う >>>>>>START
                //(this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd()) > 0))
                     (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
            // 2008.10.28 30413 犬飼 比較前に0埋めを行う <<<<<<END
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
                errComponent = this.tEdit_SalesEmployeeCode_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // 得意先
            //--------------------------------------------------------------------------
            // 得意先 (開始 > 終了 → NG）
            else if (this.tNedit_CustomerCode_St.GetInt() > GetEndCode(this.tNedit_CustomerCode_Ed))
            {
                // 2008.08.05 30413 犬飼 得意先コード→得意先に変更 >>>>>>START
                errMessage = string.Format("得意先{0}", ct_RangeError);
                // 2008.08.05 30413 犬飼 得意先コード→得意先に変更 <<<<<<END
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            ////--------------------------------------------------------------------------
            //// 担当者
            ////--------------------------------------------------------------------------
            //else if (
            //    (this.te_St_EmployeeCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_EmployeeCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_EmployeeCode.DataText.TrimEnd().CompareTo( this.te_Ed_EmployeeCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "担当者コード{0}", ct_RangeError );
            //    errComponent = this.te_St_EmployeeCode;
            //    status = false;
            //}
            // 2008.08.05 30413 犬飼 担当者のチェックを先に行う <<<<<<END
            
            return status;
        }

        /// <summary>
        /// 終了日取得処理（未入力はMax扱いする）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private DateTime GetEndDate( DateTime dateTime )
        {
            if ( dateTime == DateTime.MinValue )
            {
                return DateTime.MaxValue;
            }
            else
            {
                return dateTime;
            }
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit )
        {
            cdrResult = _dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 3, ref startDateEdit, ref endDateEdit, false, false );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        /// <summary>
        /// 日付チェック処理呼び出し（見積日用 単独）
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate( out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit )
        {
            cdResult = _dateGetAcs.CheckDate( ref targetDateEdit, true );
            return (cdResult == DateGetAcs.CheckDateResult.OK);
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
            if ( targetDateEdit.GetLongDate() < 10101 && targetDateEdit.GetDateTime() == DateTime.MinValue )
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                // 拠点オプション
                this._estimateListCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._estimateListCndtn.EnterpriseCode = this._enterpriseCode;

                // 2008.09.01 30413 犬飼 拠点コード設定 >>>>>>START
                // 拠点オプションありのとき
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // 全社選択かどうか
                    if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
                    {
                        //this._estimateListCndtn.SectionCodes = new string[1];
                        //this._estimateListCndtn.SectionCodes[0] = "";
                        this._estimateListCndtn.SectionCodes = new string[0];
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
                        this._estimateListCndtn.SectionCodes = (string[])secList.ToArray(typeof(string));
                    }
                }
                // 拠点オプションなしの時
                else
                {
                    this._estimateListCndtn.SectionCodes = new string[0];
                }
                // 2008.09.01 30413 犬飼 拠点コード設定 <<<<<<END
                

                // 開始見積日
                this._estimateListCndtn.St_SalesDate = this.tde_St_SalesDate.GetDateTime();
                // 終了見積日
                this._estimateListCndtn.Ed_SalesDate = this.tde_Ed_SalesDate.GetDateTime();
                // 開始入力日
                this._estimateListCndtn.St_SearchSlipDate = this.tde_St_SearchSlipDate.GetDateTime();
                // 終了入力日
                this._estimateListCndtn.Ed_SearchSlipDate = this.tde_Ed_SearchSlipDate.GetDateTime();
                // 開始得意先コード
                this._estimateListCndtn.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
                // 2008.09.26 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す >>>>>>START
                // 終了得意先コード
                //this._estimateListCndtn.Ed_CustomerCode = GetEndCode( this.tNedit_CustomerCode_Ed, 999999999 );
                this._estimateListCndtn.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();
                // 2008.09.26 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す <<<<<<END

                // 2008.09.26 30413 犬飼 0埋め対応 >>>>>>START                            
                //// 開始担当者コード
                //this._estimateListCndtn.St_SalesEmployeeCd = this.tEdit_SalesEmployeeCode_St.Text;
                //// 終了得意先コード
                //this._estimateListCndtn.Ed_SalesEmployeeCd = this.tEdit_SalesEmployeeCode_Ed.Text;
                // 開始担当者コード
                if (this.tEdit_SalesEmployeeCode_St.Text.Trim() == "")
                {
                    this._estimateListCndtn.St_SalesEmployeeCd = "";
                }
                else
                {
                    this._estimateListCndtn.St_SalesEmployeeCd = this.tEdit_SalesEmployeeCode_St.Text.Trim().PadLeft(4, '0');   // 開始担当者
                }
                // 終了検索コード
                if (this.tEdit_SalesEmployeeCode_Ed.Text.Trim() == "")
                {
                    this._estimateListCndtn.Ed_SalesEmployeeCd = "";
                }
                else
                {
                    this._estimateListCndtn.Ed_SalesEmployeeCd = this.tEdit_SalesEmployeeCode_Ed.Text.Trim().PadLeft(4, '0');   // 終了担当者
                }
                // 2008.09.24 30413 犬飼 0埋め対応 <<<<<<END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // メモ印刷
                this._estimateListCndtn.MemoPrintDiv = (EstimateListCndtn.MemoPrintDivState)this.uos_MemoPrintDiv.Value;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // --- ADD 2009/04/01 -------------------------------->>>>>
                this._estimateListCndtn.PrintDailyFooter = Convert.ToInt32(this.uos_PrintDailyFooter.CheckedItem.DataValue);
                // --- ADD 2009/04/01 --------------------------------<<<<<

                // 2008.07.31 30413 犬飼 改頁、見積タイプ、発行タイプを追加 >>>>>>START
                // 改頁
                this._estimateListCndtn.NewPageType = Convert.ToInt32(this.tComboEditor_NewPageType.SelectedItem.DataValue);
                // 見積タイプ
                this._estimateListCndtn.EstimateDivide = Convert.ToInt32(this.tComboEditor_EstimateDivide.SelectedItem.DataValue);
                // 発行タイプ
                this._estimateListCndtn.PrintDiv = Convert.ToInt32(this.tComboEditor_PrintDiv.SelectedItem.DataValue);
                // 2008.07.31 30413 犬飼 改頁、見積タイプ、発行タイプを追加 <<<<<<END

                // 2011/11/11 x_zhuxk　＃26537 <<<<<<END
                //連携伝票出力区分
                this._estimateListCndtn.AutoAnswerDivSCMRF = Convert.ToInt32(this.tComboEditor_AutoAnswerDiv.SelectedItem.DataValue);

                //連携伝票対象区分
                if (this.CheckEditor_PCCforNS.Checked && !this.CheckEditor_BL.Checked)
                {
                    this._estimateListCndtn.AcceptOrOrderKindRF = 0;
                }
                else if (!this.CheckEditor_PCCforNS.Checked && this.CheckEditor_BL.Checked)
                {
                    this._estimateListCndtn.AcceptOrOrderKindRF = 1;
                }
                else if (this.CheckEditor_PCCforNS.Checked && this.CheckEditor_BL.Checked)
                {
                    this._estimateListCndtn.AcceptOrOrderKindRF = 2;
                }
                else if (!this.CheckEditor_PCCforNS.Checked && !this.CheckEditor_BL.Checked)
                {
                    this._estimateListCndtn.AcceptOrOrderKindRF = 3;
                }

                // 2008.11.11 朱修凱　＃26537 <<<<<<END
             
   
			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
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
		#endregion ◆ 印刷前処理

        # region ■ エラーメッセージ ■
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
        # endregion ■ エラーメッセージ ■

        #endregion ■ Private Method

        # region ■ コントロールイベント ■

        # region ■ フォームイベント ■
        /// <summary>
		/// DCMIT02100UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void DCMIT02100UA_Load ( object sender, EventArgs e )
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

            // ADD 2009/03/31 不具合対応[12907]：スペースキーでの項目選択機能を実装 ---------->>>>>
            MemoPrintDivRadioKeyPressHelper.ControlList.Add(this.uos_MemoPrintDiv);
            MemoPrintDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[12907]：スペースキーでの項目選択機能を実装 ----------<<<<<
            // --- ADD 2009/04/01 -------------------------------->>>>>
            UosPrintDailyFooterRadioKeyPressHelper.ControlList.Add(this.uos_PrintDailyFooter);
            UosPrintDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2009/04/01 --------------------------------<<<<<
        }
        # endregion ■ フォームイベント ■

        # region ■ コントロール脱出イベント ■
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
        # endregion ■ コントロール脱出イベント ■

        # region ■ ガイドボタンクリックイベント ■
        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_CustomerGuide_Click ( object sender, EventArgs e )
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            // 2008.07.31 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //this._customerGuid = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //this._customerGuid.CustomerSelect += new CustomerSelectEventHandler( customerSearchForm_CustomerSelect );
            //this._customerGuid.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.31 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.10.29 30413 犬飼 フォーカス制御を追加 >>>>>>START
            // ガイド後次フォーカス
            if ( _customerGuideOK )
            {
                //if ( sender == this.ub_St_CustomerGuide )
                //{
                //    _nextControl[tNedit_CustomerCode_St].Focus();
                //}
                //else
                //{
                //    _nextControl[tNedit_CustomerCode_Ed].Focus();
                //}

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.29 30413 犬飼 フォーカス制御を追加 <<<<<<END
        }
        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect ( object sender, CustomerSearchRet customerSearchRet )
        {
            if (customerSearchRet == null) return;

            if ( _customerGuideSender == this.ub_St_CustomerGuide )
            {
                this.tNedit_CustomerCode_St.SetInt( customerSearchRet.CustomerCode );
                _customerGuideOK = true;
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt( customerSearchRet.CustomerCode );
                _customerGuideOK = true;
            }
        }
        /// <summary>
        /// 担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EmployeeGuide_Click ( object sender, EventArgs e )
        {
            if ( this._employeeAcs == null )
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid( this._enterpriseCode, true, out employee);

            // 2008.10.29 30413 犬飼 フォーカス制御を追加 >>>>>>START
            if (status == 0)
            {
                if ( sender == this.ub_St_EmployeeGuide )
                {
                    this.tEdit_SalesEmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    //_nextControl[tEdit_SalesEmployeeCode_St].Focus();
                }
                else
                {
                    this.tEdit_SalesEmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    //_nextControl[tEdit_SalesEmployeeCode_Ed].Focus();
                }

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.29 30413 犬飼 フォーカス制御を追加 <<<<<<END
        }
        # endregion ■ ガイドボタンクリックイベント ■

        # region ■ グループ圧縮・展開イベント ■
        /// <summary>
        /// グループ圧縮イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        # endregion ■ グループ圧縮・展開イベント ■

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ガイドボタン遷移制御
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_St)
                    {
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_SalesEmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_Ed)
                    {
                        // 担当者(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→見積タイプ
                        e.NextCtrl = this.tComboEditor_EstimateDivide;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_EstimateDivide)
                    {
                        // 見積タイプ→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_SalesEmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_Ed)
                    {
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_SalesEmployeeCode_St;
                    }
                }
            }
        }

        # endregion ■ コントロールイベント ■

        // 2011/11/11 x_zhuxk ＃redmine 26537 >>>>>>START
        /// <summary>
        /// 連携伝票出力区分SelectionChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_AutoAnswerDiv_SelectionChanged(object sender, EventArgs e)
        {
            // 連携伝票出力区分が連携伝票を含まないの場合
            if ((int)tComboEditor_AutoAnswerDiv.SelectedItem.DataValue == 0)
            {
                this.CheckEditor_PCCforNS.Enabled = false;
                this.CheckEditor_BL.Enabled = false;
                this.CheckEditor_PCCforNS.Checked = false;
                this.CheckEditor_BL.Checked = false;
            }
            else
            {
                this.CheckEditor_PCCforNS.Enabled = true;
                this.CheckEditor_BL.Enabled = true;
            }
        }
        // 2011/11/11 x_zhuxk ＃redmine 26537 <<<<<<END

    }
}