//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：見積全体設定マスタ
// プログラム概要   ：見積全体設定の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30415 柴田 倫幸
// 修正日    2008/06/04     修正内容：データ項目の追加/削除による修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008/09/16     修正内容：保存時の拠点コードチェック追加
//                                    拠点ガイド既入力時のリターンキー移動制御追加
//                                    全社（拠点コード"00"）の論理削除を不可に修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤 恵優
// 修正日    2008/09/26     修正内容：不具合対応[5659]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/10/09     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【12585】最新情報取得と更新チェックの判定を修正
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：王飛３
// 修正日    2011/09/07     修正内容：障害報告 #24169　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　　　　　　　　　 拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
// ---------------------------------------------------------------------//


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/26 不具合対応[5659]
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/26 不具合対応[5659]
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 見積初期値設定フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 見積初期値の設定を行うクラスです。</br>
	/// <br>Programmer : 980035 金沢　貞義</br>
	/// <br>Date       : 2007.09.27</br>
    /// <br>UpdateNote : 2008.03.14 980035 金沢 貞義</br>
    /// <br>             ・ファイルレイアウト変更対応</br>
    /// <br>UpdateNote : 2008/06/04 30415 柴田 倫幸</br>
    /// <br>        	 ・データ項目の追加/削除による修正</br>
    /// <br>UpdateNote : 2008/09/16 30452 上野 俊治</br>
    /// <br>             ・保存時の拠点コードチェック追加</br>
    /// <br>             ・拠点ガイド既入力時のリターンキー移動制御追加</br>
    /// <br>             ・全社（拠点コード"00"）の論理削除を不可に修正</br>
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote : 2011/09/07 王飛３</br>
    /// <br>        	 ・障害報告 #24169</br>
    /// </remarks>
	public class DCMIT09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region Private Members (Component)
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ListPricePrintDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateTitle1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Broadleaf.Library.Windows.Forms.TEdit EstimateTitle1_tEdit;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.OpenFileDialog TakeInImage_OpenFileDialog;
		private Broadleaf.Library.Windows.Forms.TEdit EstimateNote1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit EstimateNote2_tEdit;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TComboEditor EstmFormNoPickDiv_tComboEditor;
        private TComboEditor EstimatePrtDiv_tComboEditor;
        private TComboEditor ListPricePrintDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EstmFormNoPickDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimatePrtDiv_Title_Label;
        private TEdit EstimateNote3_tEdit;
        private Infragistics.Win.Misc.UltraLabel EstimateNote1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateNote2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateNote3_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TComboEditor ConsTaxPrintDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ConsTaxPrintDiv_Title_Label;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager2;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private TEdit tEdit_SectionCodeAllowZero2;
        private TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateValidityTerm_Title_Label2;
        private Infragistics.Win.Misc.UltraLabel EstimateValidityTerm_Title_Label1;
        private TEdit EstimateValidityTerm_tEdit;
        private TComboEditor EstimateDtCreateDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EstimateDtCreateDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PartsSelectDivCd_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PartsSearchDivCd_Title_Label;
        private TComboEditor PartsSearchDivCd_tComboEditor;
        private TComboEditor PartsSelectDivCd_tComboEditor;
        private TComboEditor RateUseCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel RateUseCode_Title_Label;
        private TComboEditor PartsNoPrtCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel PartsNoPrtCd_Title_Label;
        private TComboEditor OptionPringDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel OptionPringDivCd_Title_Label;
        private TComboEditor FaxEstimatetDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel FaxEstimatetDiv_Title_Label;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		/// <summary>
        /// 見積初期値設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 見積初期値設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public DCMIT09010UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値
			this._canClose							= false;	// 閉じる機能（デフォルトtrue固定）
			this._canDelete							= true;		// 削除機能
			this._canLogicalDeleteDataExtraction	= true;		// 論理削除データ表示機能
			this._canNew							= true;		// 新規作成機能
			this._canPrint							= false;	// 印刷機能
			this._canSpecificationSearch			= false;	// 件数指定検索機能
			this._defaultAutoFillToColumn			= false;	// 列サイズ自動調整機能

			// 企業コード取得
			this._enterpriseCode					= LoginInfoAcquisition.EnterpriseCode;	// 企業コード

			// 初期化
			this._dataIndex							= -1;
            this._estimateDefSetAcs                 = new EstimateDefSetAcs();
            this._secInfoAcs                        = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
			this._estimateDefSetTable				= new Hashtable();

			// _GridIndexバッファ（メインフレーム最小化対応）
			this._indexBuf							= -2;

            // ADD 2008/09/26 不具合対応[5659] ---------->>>>>
            // 拠点ガイドのフォーカス制御
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.EstimatePrtDiv_tComboEditor
            );
            // ADD 2008/09/26 不具合対応[5659] ----------<<<<<
		}
		#endregion

		#region Private Members
        private EstimateDefSetAcs _estimateDefSetAcs;				// 見積初期値設定アクセスクラス
        private SecInfoAcs        _secInfoAcs;                      // 拠点マスタアクセスクラス
        private string            _enterpriseCode;					// 企業コード
		private int				  _logicalDeleteMode;				// モード
        private Hashtable         _estimateDefSetTable;				// 見積初期値設定テーブル

		// 比較用clone
        private EstimateDefSet  _estimateDefSetClone;

		// _GridIndexバッファ（メインフレーム最小化対応）
		private int				_indexBuf;

		// プロパティ用
		private bool	_canClose;
		private bool	_canDelete;
		private bool	_canLogicalDeleteDataExtraction;
		private bool	_canNew;
		private bool	_canPrint;
		private bool	_canSpecificationSearch;
		private int		_dataIndex;
		private bool	_defaultAutoFillToColumn;

        private bool isError = false; // ADD 2011/09/07
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

		// FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string DELETE_DATE                    = "削除日";
        private const string SECTIONCODE_TITLE              = "拠点コード"; // MOD 2008/10/01 不具合対応[5967] "コード"→"拠点コード"
        private const string SECTIONNAME_TITLE              = "拠点名";     // MOD 2008/10/01 不具合対応[5967] "拠点名称"→"拠点名"
        // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
        //private const string FRACTIONPROCCD_TITLE           = "端数処理区分";
        //private const string CONSTAXLAYMETHOD_TITLE         = "消費税転嫁方式";
        // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
        private const string CONSTAXPRINTDIV_TITLE          = "消費税印刷区分";
        // DEL 2008/10/09 不具合対応[6455] ↓
        //private const string LISTPRICEPRINTDIV_TITLE        = "定価印刷区分";
        private const string LISTPRICEPRINTDIV_TITLE        = "価格印刷区分";  // ADD 2008/10/09 不具合対応[6455]
        // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
        //private const string ERANAMEDISPCD1_TITLE           = "元号表示区分";
        //private const string ESTIMATEFORMTOTALPRTCD_TITLE   = "見積合計印刷区分";
        //private const string ESTIMATEFORMPRTCD_TITLE        = "見積書印刷区分";
        //private const string HONORIFICTITLEPRTCD_TITLE      = "敬称印刷区分";
        //private const string ESTIMATEREQUESTCD_TITLE        = "見積依頼区分";
        // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
        private const string ESTMFORMNOPICKDIV_TITLE        = "見積書番号採番区分";
        private const string ESTIMATEPRTDIV_TITLE           = "見積書発行区分";
        // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
        //private const string ESTIMATEREQPRTDIV_TITLE        = "見積依頼書発行区分";
        //private const string ESTIMATECONFPRTDIV_TITLE       = "見積確認書発行区分";
        // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<

        private const string ESTIMATETITLE1_TITLE       = "見積タイトル１";
       private const string ESTIMATENOTE1_TITLE        = "見積備考１";
        private const string ESTIMATENOTE2_TITLE        = "見積備考２";
        private const string ESTIMATENOTE3_TITLE        = "見積備考３";

        // --- ADD 2008/06/04 -------------------------------->>>>>
        private const string FAXESTIMATETDIV_TITLE      = "ＦＡＸ見積区分";
        private const string PARTSNOPRTCD_TITLE         = "品番印字区分";
        private const string OPTIONPRINGDIVCD_TITLE     = "オプション印字区分";
        private const string PARTSSELECTDIVCD_TITLE     = "部品選択区分";
        private const string PARTSSEARCHDIVCD_TITLE     = "部品検索区分";
        private const string ESTIMATEDTCREATEDIV_TITLE  = "見積データ作成区分";
        private const string ESTIMATEVALIDITYTERM_TITLE = "見積書有効期限";
        private const string RATEUSECODE_TITLE          = "掛率使用区分";
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        private const string GUID_TITLE                 = "GUID";
        private const string ESTIMATEDEFSET_TABLE       = "ESTIMATEDEFSET"; // テーブル名
		
		// 編集モード
		private const string INSERT_MODE				= "新規モード";
		private const string UPDATE_MODE				= "更新モード";
		private const string DELETE_MODE				= "削除モード";

        // 端数処理区分
        private const string FRACPROC_CUT               = "切捨";
        private const string FRACPROC_ROUND             = "四捨五入";
        private const string FRACPROC_RAISE             = "切上";

        // 消費税転嫁方式
        private const string CONSTAXLAY_SLIP            = "伝票単位";
        private const string CONSTAXLAY_DETAILS         = "明細単位";
        private const string CONSTAXLAY_CLAIMPARENT     = "請求親";
        private const string CONSTAXLAY_CLAIMCHILD      = "請求子";

        // 元号表示区分
        private const string ERANAME_AD                 = "西暦";
        private const string ERANAME_JAPAN              = "和暦";

        // 共通区分
        private const string DIVISION_YES               = "する";
        private const string DIVISION_NO                = "しない";

        // 見積書番号採番区分
        private const string DIVISION_ON                = "有り";
        private const string DIVISION_OFF               = "無し";

        // 見積合計印刷区分
        private const string ESTIMATETOTALPRTCD_MODEL   = "鑑のみ";
        private const string ESTIMATETOTALPRTCD_END     = "明細末尾";
        private const string ESTIMATETOTALPRTCD_TOTAL   = "合計部";
        private const string ESTIMATETOTALPRTCD_NON     = "印刷しない";

        // 見積書印刷・見積依頼
        private const string ESTIMATEFORMPRTCD_NORMAL   = "通常";
        private const string ESTIMATEFORMPRTCD_PAGEOVER = "１頁に入らない場合明細別紙";
        private const string ESTIMATEFORMPRTCD_ANOTHER  = "明細別紙";

        // --- ADD 2008/06/04 -------------------------------->>>>>
        // 部品検索区分
        private const string PARTSSEARCHDIVCD_PARTS     = "部品検索";
        private const string PARTSSEARCHDIVCD_NO        = "品番検索";
        // 掛率使用区分
        // DEL 2008/10/09 不具合対応[6455] ↓
        //private const string RATEUSECODE_DEFAULT        = "売価=定価";
        private const string RATEUSECODE_DEFAULT        = "売価=価格";  // ADD 2008/10/09 不具合対応[6455]
        private const string RATEUSECODE_RATESELECT     = "掛率指定";
        private const string RATEUSECODE_RATESET        = "掛率設定";
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        // 未設定時に使用
        private const string UNREGISTER = "";

        // ADD 2008/09/26 不具合対応[5659] ---------->>>>>
        /// <summary>拠点ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// 拠点ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>拠点ガイドの制御オブジェクト</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        // ADD 2008/09/26 不具合対応[5659] ----------<<<<<

        #endregion

		#region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCMIT09010UA));
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ListPricePrintDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateTitle1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateTitle1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.TakeInImage_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.EstimateNote1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EstimateNote2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ListPricePrintDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstimatePrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstmFormNoPickDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstmFormNoPickDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimatePrtDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateNote3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EstimateNote1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateNote2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateNote3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxPrintDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxPrintDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraToolTipManager2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateValidityTerm_Title_Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateValidityTerm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EstimateValidityTerm_Title_Label2 = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateDtCreateDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstimateDtCreateDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsSelectDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsSearchDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsSearchDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartsSelectDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RateUseCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RateUseCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsNoPrtCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartsNoPrtCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OptionPringDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.OptionPringDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FaxEstimatetDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.FaxEstimatetDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateTitle1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPricePrintDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatePrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstmFormNoPickDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxPrintDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateValidityTerm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateDtCreateDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSearchDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSelectDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateUseCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPringDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxEstimatetDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(576, 4);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 33;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(176, 442);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 19;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(301, 442);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 20;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(426, 442);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 21;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(551, 442);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 22;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 484);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(684, 23);
            this.ultraStatusBar1.TabIndex = 59;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // SectionCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance2;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(20, 8);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SectionCode_Title_Label.TabIndex = 23;
            this.SectionCode_Title_Label.Text = "拠点";
            // 
            // ListPricePrintDiv_Title_Label
            // 
            appearance86.TextVAlignAsString = "Middle";
            this.ListPricePrintDiv_Title_Label.Appearance = appearance86;
            this.ListPricePrintDiv_Title_Label.Location = new System.Drawing.Point(330, 76);
            this.ListPricePrintDiv_Title_Label.Name = "ListPricePrintDiv_Title_Label";
            this.ListPricePrintDiv_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.ListPricePrintDiv_Title_Label.TabIndex = 25;
            this.ListPricePrintDiv_Title_Label.Text = "価格印刷区分";
            // 
            // EstimateTitle1_Title_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.EstimateTitle1_Title_Label.Appearance = appearance7;
            this.EstimateTitle1_Title_Label.Location = new System.Drawing.Point(20, 198);
            this.EstimateTitle1_Title_Label.Name = "EstimateTitle1_Title_Label";
            this.EstimateTitle1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateTitle1_Title_Label.TabIndex = 32;
            this.EstimateTitle1_Title_Label.Text = "見積タイトル１";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(10, 38);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel17.TabIndex = 42;
            // 
            // EstimateTitle1_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.EstimateTitle1_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.EstimateTitle1_tEdit.Appearance = appearance19;
            this.EstimateTitle1_tEdit.AutoSelect = true;
            this.EstimateTitle1_tEdit.DataText = "";
            this.EstimateTitle1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateTitle1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateTitle1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateTitle1_tEdit.Location = new System.Drawing.Point(171, 198);
            this.EstimateTitle1_tEdit.MaxLength = 16;
            this.EstimateTitle1_tEdit.Name = "EstimateTitle1_tEdit";
            this.EstimateTitle1_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateTitle1_tEdit.TabIndex = 11;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // TakeInImage_OpenFileDialog
            // 
            this.TakeInImage_OpenFileDialog.Filter = "画像ファイル(*.bmp;*.jpg;*.jpeg)|*.bmp;*.jpg;*.jpeg";
            this.TakeInImage_OpenFileDialog.RestoreDirectory = true;
            this.TakeInImage_OpenFileDialog.Title = "自社画像選択";
            // 
            // EstimateNote1_tEdit
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextVAlignAsString = "Middle";
            this.EstimateNote1_tEdit.ActiveAppearance = appearance60;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextVAlignAsString = "Middle";
            this.EstimateNote1_tEdit.Appearance = appearance61;
            this.EstimateNote1_tEdit.AutoSelect = true;
            this.EstimateNote1_tEdit.DataText = "";
            this.EstimateNote1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateNote1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateNote1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateNote1_tEdit.Location = new System.Drawing.Point(171, 235);
            this.EstimateNote1_tEdit.MaxLength = 24;
            this.EstimateNote1_tEdit.Name = "EstimateNote1_tEdit";
            this.EstimateNote1_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateNote1_tEdit.TabIndex = 12;
            // 
            // EstimateNote2_tEdit
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.EstimateNote2_tEdit.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextVAlignAsString = "Middle";
            this.EstimateNote2_tEdit.Appearance = appearance59;
            this.EstimateNote2_tEdit.AutoSelect = true;
            this.EstimateNote2_tEdit.DataText = "";
            this.EstimateNote2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateNote2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateNote2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateNote2_tEdit.Location = new System.Drawing.Point(171, 264);
            this.EstimateNote2_tEdit.MaxLength = 24;
            this.EstimateNote2_tEdit.Name = "EstimateNote2_tEdit";
            this.EstimateNote2_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateNote2_tEdit.TabIndex = 13;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // ListPricePrintDiv_tComboEditor
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPricePrintDiv_tComboEditor.ActiveAppearance = appearance91;
            appearance92.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            this.ListPricePrintDiv_tComboEditor.Appearance = appearance92;
            this.ListPricePrintDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ListPricePrintDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPricePrintDiv_tComboEditor.ItemAppearance = appearance93;
            this.ListPricePrintDiv_tComboEditor.Location = new System.Drawing.Point(481, 76);
            this.ListPricePrintDiv_tComboEditor.MaxDropDownItems = 18;
            this.ListPricePrintDiv_tComboEditor.Name = "ListPricePrintDiv_tComboEditor";
            this.ListPricePrintDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.ListPricePrintDiv_tComboEditor.TabIndex = 6;
            // 
            // EstimatePrtDiv_tComboEditor
            // 
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimatePrtDiv_tComboEditor.ActiveAppearance = appearance80;
            appearance81.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance81.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstimatePrtDiv_tComboEditor.Appearance = appearance81;
            this.EstimatePrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstimatePrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimatePrtDiv_tComboEditor.ItemAppearance = appearance82;
            this.EstimatePrtDiv_tComboEditor.Location = new System.Drawing.Point(171, 45);
            this.EstimatePrtDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstimatePrtDiv_tComboEditor.Name = "EstimatePrtDiv_tComboEditor";
            this.EstimatePrtDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.EstimatePrtDiv_tComboEditor.TabIndex = 3;
            // 
            // EstmFormNoPickDiv_tComboEditor
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmFormNoPickDiv_tComboEditor.ActiveAppearance = appearance75;
            appearance76.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstmFormNoPickDiv_tComboEditor.Appearance = appearance76;
            this.EstmFormNoPickDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstmFormNoPickDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmFormNoPickDiv_tComboEditor.ItemAppearance = appearance77;
            this.EstmFormNoPickDiv_tComboEditor.Location = new System.Drawing.Point(171, 75);
            this.EstmFormNoPickDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstmFormNoPickDiv_tComboEditor.Name = "EstmFormNoPickDiv_tComboEditor";
            this.EstmFormNoPickDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.EstmFormNoPickDiv_tComboEditor.TabIndex = 5;
            // 
            // EstmFormNoPickDiv_Title_Label
            // 
            appearance74.TextVAlignAsString = "Middle";
            this.EstmFormNoPickDiv_Title_Label.Appearance = appearance74;
            this.EstmFormNoPickDiv_Title_Label.Location = new System.Drawing.Point(20, 77);
            this.EstmFormNoPickDiv_Title_Label.Name = "EstmFormNoPickDiv_Title_Label";
            this.EstmFormNoPickDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.EstmFormNoPickDiv_Title_Label.TabIndex = 27;
            this.EstmFormNoPickDiv_Title_Label.Text = "見積書番号採番区分";
            // 
            // EstimatePrtDiv_Title_Label
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.EstimatePrtDiv_Title_Label.Appearance = appearance73;
            this.EstimatePrtDiv_Title_Label.Location = new System.Drawing.Point(20, 46);
            this.EstimatePrtDiv_Title_Label.Name = "EstimatePrtDiv_Title_Label";
            this.EstimatePrtDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.EstimatePrtDiv_Title_Label.TabIndex = 26;
            this.EstimatePrtDiv_Title_Label.Text = "見積書発行区分";
            // 
            // EstimateNote3_tEdit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextVAlignAsString = "Middle";
            this.EstimateNote3_tEdit.ActiveAppearance = appearance42;
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.EstimateNote3_tEdit.Appearance = appearance43;
            this.EstimateNote3_tEdit.AutoSelect = true;
            this.EstimateNote3_tEdit.DataText = "";
            this.EstimateNote3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateNote3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateNote3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateNote3_tEdit.Location = new System.Drawing.Point(171, 293);
            this.EstimateNote3_tEdit.MaxLength = 24;
            this.EstimateNote3_tEdit.Name = "EstimateNote3_tEdit";
            this.EstimateNote3_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateNote3_tEdit.TabIndex = 14;
            // 
            // EstimateNote1_Title_Label
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.EstimateNote1_Title_Label.Appearance = appearance35;
            this.EstimateNote1_Title_Label.Location = new System.Drawing.Point(20, 235);
            this.EstimateNote1_Title_Label.Name = "EstimateNote1_Title_Label";
            this.EstimateNote1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateNote1_Title_Label.TabIndex = 37;
            this.EstimateNote1_Title_Label.Text = "見積備考１";
            // 
            // EstimateNote2_Title_Label
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.EstimateNote2_Title_Label.Appearance = appearance36;
            this.EstimateNote2_Title_Label.Location = new System.Drawing.Point(20, 264);
            this.EstimateNote2_Title_Label.Name = "EstimateNote2_Title_Label";
            this.EstimateNote2_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateNote2_Title_Label.TabIndex = 38;
            this.EstimateNote2_Title_Label.Text = "見積備考２";
            // 
            // EstimateNote3_Title_Label
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.EstimateNote3_Title_Label.Appearance = appearance37;
            this.EstimateNote3_Title_Label.Location = new System.Drawing.Point(20, 293);
            this.EstimateNote3_Title_Label.Name = "EstimateNote3_Title_Label";
            this.EstimateNote3_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateNote3_Title_Label.TabIndex = 39;
            this.EstimateNote3_Title_Label.Text = "見積備考３";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(10, 178);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel1.TabIndex = 44;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(11, 335);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel2.TabIndex = 45;
            this.ultraLabel2.Click += new System.EventHandler(this.ultraLabel2_Click);
            // 
            // ConsTaxPrintDiv_Title_Label
            // 
            appearance90.TextVAlignAsString = "Middle";
            this.ConsTaxPrintDiv_Title_Label.Appearance = appearance90;
            this.ConsTaxPrintDiv_Title_Label.Location = new System.Drawing.Point(330, 46);
            this.ConsTaxPrintDiv_Title_Label.Name = "ConsTaxPrintDiv_Title_Label";
            this.ConsTaxPrintDiv_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.ConsTaxPrintDiv_Title_Label.TabIndex = 24;
            this.ConsTaxPrintDiv_Title_Label.Text = "消費税印刷区分";
            // 
            // ConsTaxPrintDiv_tComboEditor
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxPrintDiv_tComboEditor.ActiveAppearance = appearance87;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConsTaxPrintDiv_tComboEditor.Appearance = appearance88;
            this.ConsTaxPrintDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ConsTaxPrintDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxPrintDiv_tComboEditor.ItemAppearance = appearance89;
            this.ConsTaxPrintDiv_tComboEditor.Location = new System.Drawing.Point(481, 46);
            this.ConsTaxPrintDiv_tComboEditor.MaxDropDownItems = 18;
            this.ConsTaxPrintDiv_tComboEditor.Name = "ConsTaxPrintDiv_tComboEditor";
            this.ConsTaxPrintDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.ConsTaxPrintDiv_tComboEditor.TabIndex = 4;
            // 
            // ultraToolTipManager2
            // 
            this.ultraToolTipManager2.ContainingControl = this;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(207, 7);
            this.SectionGd_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGd_ultraButton.Name = "SectionGd_ultraButton";
            this.SectionGd_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGd_ultraButton.TabIndex = 1;
            this.SectionGd_ultraButton.Click += new System.EventHandler(this.SectionGd_ultraButton_Click);
            // 
            // SectionNm_tEdit
            // 
            this.SectionNm_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance65;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionNm_tEdit.Location = new System.Drawing.Point(238, 7);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance78;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance79;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(172, 7);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(359, 7);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 63;
            this.SectionNm_Label.Text = "※ゼロで共通設定になります";
            // 
            // EstimateValidityTerm_Title_Label1
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_Title_Label1.Appearance = appearance66;
            this.EstimateValidityTerm_Title_Label1.Location = new System.Drawing.Point(20, 137);
            this.EstimateValidityTerm_Title_Label1.Name = "EstimateValidityTerm_Title_Label1";
            this.EstimateValidityTerm_Title_Label1.Size = new System.Drawing.Size(145, 23);
            this.EstimateValidityTerm_Title_Label1.TabIndex = 65;
            this.EstimateValidityTerm_Title_Label1.Text = "見積書有効期限";
            // 
            // EstimateValidityTerm_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_tEdit.Appearance = appearance13;
            this.EstimateValidityTerm_tEdit.AutoSelect = true;
            this.EstimateValidityTerm_tEdit.DataText = "";
            this.EstimateValidityTerm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateValidityTerm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EstimateValidityTerm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EstimateValidityTerm_tEdit.Location = new System.Drawing.Point(171, 137);
            this.EstimateValidityTerm_tEdit.MaxLength = 2;
            this.EstimateValidityTerm_tEdit.Name = "EstimateValidityTerm_tEdit";
            this.EstimateValidityTerm_tEdit.Size = new System.Drawing.Size(28, 24);
            this.EstimateValidityTerm_tEdit.TabIndex = 9;
            // 
            // EstimateValidityTerm_Title_Label2
            // 
            appearance57.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_Title_Label2.Appearance = appearance57;
            this.EstimateValidityTerm_Title_Label2.Location = new System.Drawing.Point(200, 139);
            this.EstimateValidityTerm_Title_Label2.Name = "EstimateValidityTerm_Title_Label2";
            this.EstimateValidityTerm_Title_Label2.Size = new System.Drawing.Size(62, 23);
            this.EstimateValidityTerm_Title_Label2.TabIndex = 66;
            this.EstimateValidityTerm_Title_Label2.Text = "ヶ月間";
            // 
            // EstimateDtCreateDiv_tComboEditor
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimateDtCreateDiv_tComboEditor.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstimateDtCreateDiv_tComboEditor.Appearance = appearance27;
            this.EstimateDtCreateDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstimateDtCreateDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimateDtCreateDiv_tComboEditor.ItemAppearance = appearance28;
            this.EstimateDtCreateDiv_tComboEditor.Location = new System.Drawing.Point(481, 356);
            this.EstimateDtCreateDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstimateDtCreateDiv_tComboEditor.Name = "EstimateDtCreateDiv_tComboEditor";
            this.EstimateDtCreateDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.EstimateDtCreateDiv_tComboEditor.TabIndex = 16;
            // 
            // EstimateDtCreateDiv_Title_Label
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.EstimateDtCreateDiv_Title_Label.Appearance = appearance29;
            this.EstimateDtCreateDiv_Title_Label.Location = new System.Drawing.Point(330, 356);
            this.EstimateDtCreateDiv_Title_Label.Name = "EstimateDtCreateDiv_Title_Label";
            this.EstimateDtCreateDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.EstimateDtCreateDiv_Title_Label.TabIndex = 72;
            this.EstimateDtCreateDiv_Title_Label.Text = "見積データ作成区分";
            // 
            // PartsSelectDivCd_Title_Label
            // 
            appearance46.TextVAlignAsString = "Middle";
            this.PartsSelectDivCd_Title_Label.Appearance = appearance46;
            this.PartsSelectDivCd_Title_Label.Location = new System.Drawing.Point(20, 356);
            this.PartsSelectDivCd_Title_Label.Name = "PartsSelectDivCd_Title_Label";
            this.PartsSelectDivCd_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.PartsSelectDivCd_Title_Label.TabIndex = 74;
            this.PartsSelectDivCd_Title_Label.Text = "部品選択区分";
            // 
            // PartsSearchDivCd_Title_Label
            // 
            appearance47.TextVAlignAsString = "Middle";
            this.PartsSearchDivCd_Title_Label.Appearance = appearance47;
            this.PartsSearchDivCd_Title_Label.Location = new System.Drawing.Point(20, 386);
            this.PartsSearchDivCd_Title_Label.Name = "PartsSearchDivCd_Title_Label";
            this.PartsSearchDivCd_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.PartsSearchDivCd_Title_Label.TabIndex = 75;
            this.PartsSearchDivCd_Title_Label.Text = "部品検索区分";
            // 
            // PartsSearchDivCd_tComboEditor
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSearchDivCd_tComboEditor.ActiveAppearance = appearance48;
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsSearchDivCd_tComboEditor.Appearance = appearance49;
            this.PartsSearchDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsSearchDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSearchDivCd_tComboEditor.ItemAppearance = appearance50;
            this.PartsSearchDivCd_tComboEditor.Location = new System.Drawing.Point(171, 386);
            this.PartsSearchDivCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsSearchDivCd_tComboEditor.Name = "PartsSearchDivCd_tComboEditor";
            this.PartsSearchDivCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PartsSearchDivCd_tComboEditor.TabIndex = 17;
            // 
            // PartsSelectDivCd_tComboEditor
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSelectDivCd_tComboEditor.ActiveAppearance = appearance51;
            appearance52.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance52.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsSelectDivCd_tComboEditor.Appearance = appearance52;
            this.PartsSelectDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsSelectDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSelectDivCd_tComboEditor.ItemAppearance = appearance53;
            this.PartsSelectDivCd_tComboEditor.Location = new System.Drawing.Point(171, 356);
            this.PartsSelectDivCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsSelectDivCd_tComboEditor.Name = "PartsSelectDivCd_tComboEditor";
            this.PartsSelectDivCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PartsSelectDivCd_tComboEditor.TabIndex = 15;
            // 
            // RateUseCode_tComboEditor
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateUseCode_tComboEditor.ActiveAppearance = appearance54;
            appearance55.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance55.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateUseCode_tComboEditor.Appearance = appearance55;
            this.RateUseCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RateUseCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateUseCode_tComboEditor.ItemAppearance = appearance56;
            this.RateUseCode_tComboEditor.Location = new System.Drawing.Point(481, 386);
            this.RateUseCode_tComboEditor.MaxDropDownItems = 18;
            this.RateUseCode_tComboEditor.Name = "RateUseCode_tComboEditor";
            this.RateUseCode_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.RateUseCode_tComboEditor.TabIndex = 18;
            // 
            // RateUseCode_Title_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.RateUseCode_Title_Label.Appearance = appearance3;
            this.RateUseCode_Title_Label.Location = new System.Drawing.Point(330, 386);
            this.RateUseCode_Title_Label.Name = "RateUseCode_Title_Label";
            this.RateUseCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.RateUseCode_Title_Label.TabIndex = 73;
            this.RateUseCode_Title_Label.Text = "掛率使用区分";
            // 
            // PartsNoPrtCd_tComboEditor
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsNoPrtCd_tComboEditor.ActiveAppearance = appearance69;
            appearance70.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsNoPrtCd_tComboEditor.Appearance = appearance70;
            this.PartsNoPrtCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsNoPrtCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsNoPrtCd_tComboEditor.ItemAppearance = appearance71;
            this.PartsNoPrtCd_tComboEditor.Location = new System.Drawing.Point(481, 105);
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsNoPrtCd_tComboEditor.Name = "PartsNoPrtCd_tComboEditor";
            this.PartsNoPrtCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PartsNoPrtCd_tComboEditor.TabIndex = 8;
            // 
            // PartsNoPrtCd_Title_Label
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.PartsNoPrtCd_Title_Label.Appearance = appearance72;
            this.PartsNoPrtCd_Title_Label.Location = new System.Drawing.Point(330, 107);
            this.PartsNoPrtCd_Title_Label.Name = "PartsNoPrtCd_Title_Label";
            this.PartsNoPrtCd_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.PartsNoPrtCd_Title_Label.TabIndex = 78;
            this.PartsNoPrtCd_Title_Label.Text = "品番印字区分";
            // 
            // OptionPringDivCd_tComboEditor
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OptionPringDivCd_tComboEditor.ActiveAppearance = appearance94;
            appearance95.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance95.ForeColorDisabled = System.Drawing.Color.Black;
            this.OptionPringDivCd_tComboEditor.Appearance = appearance95;
            this.OptionPringDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.OptionPringDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OptionPringDivCd_tComboEditor.ItemAppearance = appearance96;
            this.OptionPringDivCd_tComboEditor.Location = new System.Drawing.Point(481, 135);
            this.OptionPringDivCd_tComboEditor.MaxDropDownItems = 18;
            this.OptionPringDivCd_tComboEditor.Name = "OptionPringDivCd_tComboEditor";
            this.OptionPringDivCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.OptionPringDivCd_tComboEditor.TabIndex = 10;
            // 
            // OptionPringDivCd_Title_Label
            // 
            appearance97.TextVAlignAsString = "Middle";
            this.OptionPringDivCd_Title_Label.Appearance = appearance97;
            this.OptionPringDivCd_Title_Label.Location = new System.Drawing.Point(330, 136);
            this.OptionPringDivCd_Title_Label.Name = "OptionPringDivCd_Title_Label";
            this.OptionPringDivCd_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.OptionPringDivCd_Title_Label.TabIndex = 79;
            this.OptionPringDivCd_Title_Label.Text = "オプション印刷区分";
            // 
            // FaxEstimatetDiv_tComboEditor
            // 
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxEstimatetDiv_tComboEditor.ActiveAppearance = appearance83;
            appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            this.FaxEstimatetDiv_tComboEditor.Appearance = appearance84;
            this.FaxEstimatetDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FaxEstimatetDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxEstimatetDiv_tComboEditor.ItemAppearance = appearance85;
            this.FaxEstimatetDiv_tComboEditor.Location = new System.Drawing.Point(171, 105);
            this.FaxEstimatetDiv_tComboEditor.MaxDropDownItems = 18;
            this.FaxEstimatetDiv_tComboEditor.Name = "FaxEstimatetDiv_tComboEditor";
            this.FaxEstimatetDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.FaxEstimatetDiv_tComboEditor.TabIndex = 7;
            // 
            // FaxEstimatetDiv_Title_Label
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.FaxEstimatetDiv_Title_Label.Appearance = appearance68;
            this.FaxEstimatetDiv_Title_Label.Location = new System.Drawing.Point(20, 107);
            this.FaxEstimatetDiv_Title_Label.Name = "FaxEstimatetDiv_Title_Label";
            this.FaxEstimatetDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.FaxEstimatetDiv_Title_Label.TabIndex = 81;
            this.FaxEstimatetDiv_Title_Label.Text = "ＦＡＸ見積区分";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(301, 442);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 20;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // DCMIT09010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 507);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.FaxEstimatetDiv_tComboEditor);
            this.Controls.Add(this.FaxEstimatetDiv_Title_Label);
            this.Controls.Add(this.PartsNoPrtCd_tComboEditor);
            this.Controls.Add(this.PartsNoPrtCd_Title_Label);
            this.Controls.Add(this.OptionPringDivCd_tComboEditor);
            this.Controls.Add(this.OptionPringDivCd_Title_Label);
            this.Controls.Add(this.EstimateDtCreateDiv_tComboEditor);
            this.Controls.Add(this.EstimateDtCreateDiv_Title_Label);
            this.Controls.Add(this.PartsSelectDivCd_Title_Label);
            this.Controls.Add(this.PartsSearchDivCd_Title_Label);
            this.Controls.Add(this.PartsSearchDivCd_tComboEditor);
            this.Controls.Add(this.PartsSelectDivCd_tComboEditor);
            this.Controls.Add(this.RateUseCode_tComboEditor);
            this.Controls.Add(this.RateUseCode_Title_Label);
            this.Controls.Add(this.EstimateValidityTerm_Title_Label2);
            this.Controls.Add(this.EstimateValidityTerm_Title_Label1);
            this.Controls.Add(this.EstimateValidityTerm_tEdit);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.ConsTaxPrintDiv_tComboEditor);
            this.Controls.Add(this.ConsTaxPrintDiv_Title_Label);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.EstimateNote1_Title_Label);
            this.Controls.Add(this.EstimateNote2_Title_Label);
            this.Controls.Add(this.EstimateNote3_Title_Label);
            this.Controls.Add(this.EstimateNote3_tEdit);
            this.Controls.Add(this.EstimatePrtDiv_Title_Label);
            this.Controls.Add(this.EstmFormNoPickDiv_Title_Label);
            this.Controls.Add(this.EstmFormNoPickDiv_tComboEditor);
            this.Controls.Add(this.EstimatePrtDiv_tComboEditor);
            this.Controls.Add(this.ListPricePrintDiv_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.EstimateNote2_tEdit);
            this.Controls.Add(this.EstimateNote1_tEdit);
            this.Controls.Add(this.EstimateTitle1_tEdit);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ListPricePrintDiv_Title_Label);
            this.Controls.Add(this.EstimateTitle1_Title_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCMIT09010UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "見積全体設定";
            this.Load += new System.EventHandler(this.DCMIT09010UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCMIT09010UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DCMIT09010UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateTitle1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPricePrintDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatePrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstmFormNoPickDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxPrintDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateValidityTerm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateDtCreateDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSearchDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSelectDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateUseCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPringDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxEstimatetDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new DCMIT09010UA());
		}
		#endregion

		#region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった時に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region Properties
		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get {
				return this._canClose;
			}
			set {
				this._canClose = value;
			}
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get {
				return this._canDelete;
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get {
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>新規作成可能設定プロパティ</summary>
		/// <value>新規作成が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get {
				return this._canNew;
			}
		}

		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷が可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get {
				return this._canPrint;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
		public bool CanSpecificationSearch
		{
			get {
				return this._canSpecificationSearch;
			}
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get {
				return this._dataIndex;
			}
			set {
				this._dataIndex = value;
			}
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get {
				return this._defaultAutoFillToColumn;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// 削除日
			appearanceTable.Add( DELETE_DATE, 
				new GridColAppearance( MGridColDispType.DeletionDataBoth, 
				ContentAlignment.MiddleLeft, "", Color.Red ) );
            // 拠点コード
            appearanceTable.Add(　SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
            appearanceTable.Add( SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 端数処理区分
            //appearanceTable.Add( FRACTIONPROCCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// 消費税転嫁方式
            //appearanceTable.Add( CONSTAXLAYMETHOD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 定価印刷区分
            appearanceTable.Add( LISTPRICEPRINTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 元号表示区分１
            //appearanceTable.Add( ERANAMEDISPCD1_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// 見積合計印刷区分
            //appearanceTable.Add( ESTIMATEFORMTOTALPRTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// 見積書印刷区分
            //appearanceTable.Add( ESTIMATEFORMPRTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// 敬称印刷区分
            //appearanceTable.Add( HONORIFICTITLEPRTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// 見積依頼区分
            //appearanceTable.Add( ESTIMATEREQUESTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 見積書番号採番区分
            appearanceTable.Add( ESTMFORMNOPICKDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 見積書発行区分
            appearanceTable.Add( ESTIMATEPRTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 見積依頼書発行区分
            //appearanceTable.Add( ESTIMATEREQPRTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// 見積確認書発行区分
            //appearanceTable.Add( ESTIMATECONFPRTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
    
            // 見積タイトル１
            appearanceTable.Add( ESTIMATETITLE1_TITLE,
                new GridColAppearance( MGridColDispType.Both,
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 見積備考１
            appearanceTable.Add( ESTIMATENOTE1_TITLE,
                new GridColAppearance( MGridColDispType.Both,
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 見積備考２
            appearanceTable.Add( ESTIMATENOTE2_TITLE,
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 見積備考３
            appearanceTable.Add( ESTIMATENOTE3_TITLE,
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // 消費税印刷区分
            appearanceTable.Add(CONSTAXPRINTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ＦＡＸ見積区分
            appearanceTable.Add(FAXESTIMATETDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 品番印字区分
            appearanceTable.Add(PARTSNOPRTCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // オプション印字区分
            appearanceTable.Add(OPTIONPRINGDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 部品選択区分
            appearanceTable.Add(PARTSSELECTDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 部品検索区分
            appearanceTable.Add(PARTSSEARCHDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 見積データ作成区分
            appearanceTable.Add(ESTIMATEDTCREATEDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 見積書有効期限
            appearanceTable.Add(ESTIMATEVALIDITYTERM_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 掛率使用区分
            appearanceTable.Add(RATEUSECODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/04 --------------------------------<<<<< 

			// GUID
			appearanceTable.Add( GUID_TITLE, 
				new GridColAppearance( MGridColDispType.None, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );

            return appearanceTable;
		}

		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッド用データセット</param>
		/// <param name="tableName">テーブル名</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet	= this.Bind_DataSet;
			tableName	= ESTIMATEDEFSET_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCnt">全該当件数</param>
		/// <param name="readCnt">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int Search( ref int totalCnt, int readCnt )
		{
			return SearchEstimateDefSet( ref totalCnt, readCnt );
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCnt">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int SearchNext( int readCnt )
		{
			// 未実装
			return ( int )ConstantManagement.DB_Status.ctDB_EOF;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int Delete()
		{
			return LogicalDelete();
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCnt">全該当件数</param>
		/// <param name="readCnt">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int SearchEstimateDefSet( ref int totalCnt, int readCnt )
		{
			int status = 0;
			ArrayList estimateDefSets = null;

			// 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._estimateDefSetAcs.SearchAll(out estimateDefSets, this._enterpriseCode);
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
                    foreach (EstimateDefSet estimateDefSet in estimateDefSets)
                    {
						if( this._estimateDefSetTable.ContainsKey( estimateDefSet.FileHeaderGuid ) == false ) {
							EstimateDefSetToDataSet( estimateDefSet.Clone(), index );
							index++;
						}
					}

					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// サーチ
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                        "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
                        "見積全体設定", 					// プログラム名称
                        "SearchEstimateDefSet", 			// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。", 		// 表示するメッセージ
						status, 							// ステータス値
                        this._estimateDefSetAcs, 			// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					break;
				}
			}
			
			totalCnt = estimateDefSets.Count;

			return status;
		}

		/// <summary>
        /// 見積初期値設定オブジェクト展開処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : 見積初期値設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void EstimateDefSetToDataSet(EstimateDefSet estimateDefSet, int index)
		{
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows.Count))
            {
				// 新規と判断し、行を追加する。
				DataRow dataRow = this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].NewRow();
				this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Add( dataRow );

				// indexを最終行番号にする
				index = this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count - 1;
			}

			// 削除日
			if( estimateDefSet.LogicalDeleteCode == 0 ) {
                this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][DELETE_DATE] = "";
            }
			else {
				//this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ DELETE_DATE ] = estimateDefSet.UpdateDateTimeJpInFormal;
                this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][DELETE_DATE] = estimateDefSet.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][SECTIONCODE_TITLE] = estimateDefSet.SectionCode.TrimEnd();
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/10/02 不具合対応[5966]---------->>>>>
            // 拠点コード（全社共通）
            if (SectionUtil.IsAllSection(estimateDefSet.SectionCode.TrimEnd()))
            {
                this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][SECTIONNAME_TITLE] = SectionUtil.ALL_SECTION_NAME;
            }
            // ADD 2008/10/02 不具合対応[5966]----------<<<<<

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 端数処理区分
            //switch (estimateDefSet.FractionProcCd)
            //{
            //    case 1:
            //        wrkstr = FRACPROC_CUT;           // 切捨
            //        break;
            //    case 2:
            //        wrkstr = FRACPROC_ROUND;         // 四捨五入
            //        break;
            //    case 3:
            //        wrkstr = FRACPROC_RAISE;        // 切上
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][FRACTIONPROCCD_TITLE] = wrkstr;

            //// 消費税転嫁方式
            //switch (estimateDefSet.ConsTaxLayMethod)
            //{
            //    case 0:
            //        wrkstr = CONSTAXLAY_SLIP;       // 伝票単位
            //        break;
            //    case 1:
            //        wrkstr = CONSTAXLAY_DETAILS;    // 明細単位
            //        break;
            //    case 2:
            //        wrkstr = CONSTAXLAY_CLAIMPARENT;// 請求親
            //        break;
            //    case 3:
            //        wrkstr = CONSTAXLAY_CLAIMCHILD; // 請求子
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][CONSTAXLAYMETHOD_TITLE] = wrkstr;
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 定価印刷区分
            switch (estimateDefSet.ListPricePrintDiv)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][LISTPRICEPRINTDIV_TITLE] = wrkstr;

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 元号表示区分
            //switch (estimateDefSet.EraNameDispCd1)
            //{
            //    case 0:
            //        wrkstr = ERANAME_AD;            // 西暦
            //        break;
            //    case 1:
            //        wrkstr = ERANAME_JAPAN;         // 和暦
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ERANAMEDISPCD1_TITLE] = wrkstr;

            
            //// 見積合計印刷区分
            //switch (estimateDefSet.EstimateTotalPrtCd)
            //{
            //    case 0:
            //        wrkstr = ESTIMATETOTALPRTCD_MODEL;  // 鑑のみ
            //        break;
            //    case 1:
            //        wrkstr = ESTIMATETOTALPRTCD_END;    // 明細末尾
            //        break;
            //    case 2:
            //        wrkstr = ESTIMATETOTALPRTCD_TOTAL;  // 合計部
            //        break;
            //    case 3:
            //        wrkstr = ESTIMATETOTALPRTCD_NON;    // 印刷しない
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEFORMTOTALPRTCD_TITLE] = wrkstr;

            //// 見積書印刷区分
            //switch (estimateDefSet.EstimateFormPrtCd)
            //{
            //    case 0:
            //        wrkstr = ESTIMATEFORMPRTCD_NORMAL;  // 通常
            //        break;
            //    case 1:
            //        wrkstr = ESTIMATEFORMPRTCD_PAGEOVER;// １頁に入らない場合明細別紙
            //        break;
            //    case 2:
            //        wrkstr = ESTIMATEFORMPRTCD_ANOTHER; // 明細別紙
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEFORMPRTCD_TITLE] = wrkstr;

            //// 敬称印刷区分
            //switch (estimateDefSet.HonorificTitlePrtCd)
            //{
            //    case 0:
            //        wrkstr = DIVISION_YES;          // する
            //        break;
            //    case 1:
            //        wrkstr = DIVISION_NO;           // しない
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][HONORIFICTITLEPRTCD_TITLE] = wrkstr;

            //// 見積依頼区分
            //switch (estimateDefSet.EstimateRequestCd)
            //{
            //    case 0:
            //        wrkstr = ESTIMATEFORMPRTCD_NORMAL;  // 通常
            //        break;
            //    case 1:
            //        wrkstr = ESTIMATEFORMPRTCD_PAGEOVER;// １頁に入らない場合明細別紙
            //        break;
            //    case 2:
            //        wrkstr = ESTIMATEFORMPRTCD_ANOTHER; // 明細別紙
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEREQUESTCD_TITLE] = wrkstr;
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 見積書番号採番区分
            switch (estimateDefSet.EstmFormNoPickDiv)
            {
                case 0:
                    wrkstr = DIVISION_ON;           // 有り
                    break;
                case 1:
                    wrkstr = DIVISION_OFF;          // 無し
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTMFORMNOPICKDIV_TITLE] = wrkstr;

            // 見積書発行区分
            switch (estimateDefSet.EstimatePrtDiv)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // する
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEPRTDIV_TITLE] = wrkstr;

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 見積依頼書発行区分
            //switch (estimateDefSet.EstimateReqPrtDiv)
            //{
            //    case 0:
            //        wrkstr = DIVISION_YES;          // する
            //        break;
            //    case 1:
            //        wrkstr = DIVISION_NO;           // しない
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEREQPRTDIV_TITLE] = wrkstr;

            //// 見積確認書発行区分
            //switch (estimateDefSet.EstimateConfPrtDiv)
            //{
            //    case 0:
            //        wrkstr = DIVISION_NO;           // しない
            //        break;
            //    case 1:
            //        wrkstr = DIVISION_YES;          // する
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATECONFPRTDIV_TITLE] = wrkstr;
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 見積タイトル１
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATETITLE1_TITLE ] = estimateDefSet.EstimateTitle1;
            // 見積備考１
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATENOTE1_TITLE  ] = estimateDefSet.EstimateNote1;
            // 見積備考２
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATENOTE2_TITLE  ] = estimateDefSet.EstimateNote2;
            // 見積備考３
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATENOTE3_TITLE  ] = estimateDefSet.EstimateNote3;
            // --- ADD 2008/06/04 -------------------------------->>>>>
            // 消費税印刷区分
            switch (estimateDefSet.ConsTaxPrintDiv)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // する
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][CONSTAXPRINTDIV_TITLE] = wrkstr;

            // ＦＡＸ見積区分
            switch (estimateDefSet.FaxEstimatetDiv)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][FAXESTIMATETDIV_TITLE] = wrkstr;

            // 品番印字区分
            switch (estimateDefSet.PartsNoPrtCd)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = wrkstr;

            // オプション印字区分
            switch (estimateDefSet.OptionPringDivCd)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][OPTIONPRINGDIVCD_TITLE] = wrkstr;

            // 部品選択区分
            switch (estimateDefSet.PartsSelectDivCd)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // する
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][PARTSSELECTDIVCD_TITLE] = wrkstr;

            // 部品検索区分
            switch (estimateDefSet.PartsSearchDivCd)
            {
                case 0:
                    wrkstr = PARTSSEARCHDIVCD_PARTS; // 部品検索
                    break;
                case 1:
                    wrkstr = PARTSSEARCHDIVCD_NO;    // 品番検索
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][PARTSSEARCHDIVCD_TITLE] = wrkstr;

            // 見積データ作成区分
            switch (estimateDefSet.EstimateDtCreateDiv)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // する
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // しない
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEDTCREATEDIV_TITLE] = wrkstr;

            // 見積書有効期限
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEVALIDITYTERM_TITLE] = estimateDefSet.EstimateValidityTerm;

            // 掛率使用区分
            switch (estimateDefSet.RateUseCode)
            {
                case 0:
                    wrkstr = RATEUSECODE_DEFAULT;     // 売価=定価
                    break;
                case 1:
                    wrkstr = RATEUSECODE_RATESELECT;  // 掛率指定
                    break;
                case 2:
                    wrkstr = RATEUSECODE_RATESET;     // 掛率設定
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][RATEUSECODE_TITLE] = wrkstr;
            // --- ADD 2008/06/04 --------------------------------<<<<< 

			// GUID
			this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ GUID_TITLE ] = estimateDefSet.FileHeaderGuid;

            if (this._estimateDefSetTable.ContainsKey(estimateDefSet.FileHeaderGuid) == true)
            {
				this._estimateDefSetTable.Remove( estimateDefSet.FileHeaderGuid );
			}
			this._estimateDefSetTable.Add( estimateDefSet.FileHeaderGuid, estimateDefSet );

		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable estimateDefSetTable = new DataTable( ESTIMATEDEFSET_TABLE );
			estimateDefSetTable.Columns.Add( DELETE_DATE, typeof( string ) );

            estimateDefSetTable.Columns.Add( SECTIONCODE_TITLE              , typeof(string) );
			estimateDefSetTable.Columns.Add( SECTIONNAME_TITLE              , typeof(string) );
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSetTable.Columns.Add( FRACTIONPROCCD_TITLE           , typeof(string) );
            //estimateDefSetTable.Columns.Add( CONSTAXLAYMETHOD_TITLE         , typeof(string) );
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            estimateDefSetTable.Columns.Add(CONSTAXPRINTDIV_TITLE           , typeof(string));  // ADD 2008/06/04
			estimateDefSetTable.Columns.Add( LISTPRICEPRINTDIV_TITLE        , typeof(string) );
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSetTable.Columns.Add( ERANAMEDISPCD1_TITLE           , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATEFORMTOTALPRTCD_TITLE   , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATEFORMPRTCD_TITLE        , typeof(string) );
            //estimateDefSetTable.Columns.Add( HONORIFICTITLEPRTCD_TITLE      , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATEREQUESTCD_TITLE        , typeof(string) );
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
			estimateDefSetTable.Columns.Add( ESTMFORMNOPICKDIV_TITLE        , typeof(string) );
			estimateDefSetTable.Columns.Add( ESTIMATEPRTDIV_TITLE           , typeof(string) );
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSetTable.Columns.Add( ESTIMATEREQPRTDIV_TITLE        , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATECONFPRTDIV_TITLE       , typeof(string) );
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<

            estimateDefSetTable.Columns.Add( ESTIMATETITLE1_TITLE   , typeof(string) );
            estimateDefSetTable.Columns.Add( ESTIMATENOTE1_TITLE    , typeof(string) );
            estimateDefSetTable.Columns.Add( ESTIMATENOTE2_TITLE    , typeof(string) );
            estimateDefSetTable.Columns.Add( ESTIMATENOTE3_TITLE    , typeof(string) );
            // --- ADD 2008/06/04 -------------------------------->>>>>
            estimateDefSetTable.Columns.Add(FAXESTIMATETDIV_TITLE       , typeof(string));
            estimateDefSetTable.Columns.Add(PARTSNOPRTCD_TITLE          , typeof(string));
            estimateDefSetTable.Columns.Add(OPTIONPRINGDIVCD_TITLE      , typeof(string));
            estimateDefSetTable.Columns.Add(PARTSSELECTDIVCD_TITLE      , typeof(string));
            estimateDefSetTable.Columns.Add(PARTSSEARCHDIVCD_TITLE      , typeof(string));
            estimateDefSetTable.Columns.Add(ESTIMATEDTCREATEDIV_TITLE   , typeof(string));
            estimateDefSetTable.Columns.Add(ESTIMATEVALIDITYTERM_TITLE  , typeof(string));
            estimateDefSetTable.Columns.Add(RATEUSECODE_TITLE           , typeof(string));
            // --- ADD 2008/06/04 --------------------------------<<<<< 

			estimateDefSetTable.Columns.Add( GUID_TITLE, typeof( Guid ) );

			this.Bind_DataSet.Tables.Add( estimateDefSetTable );
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
			// ボタン配置
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Ok_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Revive_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Ok_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);

            /* --- DEL 2008/06/04 -------------------------------->>>>>
            // 拠点コンボボックスのセット
            this.SectionCode_tComboEditor.Items.Clear();
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                this.SectionCode_tComboEditor.Items.Add(si.SectionCode.TrimEnd(), si.SectionGuideNm);
            }
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 端数処理区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.FractionProcCd_tComboEditor.Items.Clear();
            //this.FractionProcCd_tComboEditor.Items.Add(1, FRACPROC_CUT);
            //this.FractionProcCd_tComboEditor.Items.Add(2, FRACPROC_ROUND);
            //this.FractionProcCd_tComboEditor.Items.Add(3, FRACPROC_RAISE);
            //this.FractionProcCd_tComboEditor.MaxDropDownItems = this.FractionProcCd_tComboEditor.Items.Count;
            //this.FractionProcCd_tComboEditor.Value = 1;

            //// 消費税転嫁方式のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.ConsTaxLayMethod_tComboEditor.Items.Clear();
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(0, CONSTAXLAY_SLIP);
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(1, CONSTAXLAY_DETAILS);
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(2, CONSTAXLAY_CLAIMPARENT);
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(3, CONSTAXLAY_CLAIMCHILD);
            //this.ConsTaxLayMethod_tComboEditor.MaxDropDownItems = this.ConsTaxLayMethod_tComboEditor.Items.Count;

            //// 元号表示区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.EraNameDispCd1_tComboEditor.Items.Clear();
            //this.EraNameDispCd1_tComboEditor.Items.Add(0, ERANAME_AD);
            //this.EraNameDispCd1_tComboEditor.Items.Add(1, ERANAME_JAPAN);
            //this.EraNameDispCd1_tComboEditor.MaxDropDownItems = this.EraNameDispCd1_tComboEditor.Items.Count;
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 定価印刷区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.ListPricePrintDiv_tComboEditor.Items.Clear();
            this.ListPricePrintDiv_tComboEditor.Items.Add(0, DIVISION_NO);
            this.ListPricePrintDiv_tComboEditor.Items.Add(1, DIVISION_YES);
            this.ListPricePrintDiv_tComboEditor.MaxDropDownItems = this.ListPricePrintDiv_tComboEditor.Items.Count;

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 見積合計印刷区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.EstimateTotalPrtCd_tComboEditor.Items.Clear();
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(0, ESTIMATETOTALPRTCD_MODEL);
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(1, ESTIMATETOTALPRTCD_END);
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(2, ESTIMATETOTALPRTCD_TOTAL);
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(3, ESTIMATETOTALPRTCD_NON);
            //this.EstimateTotalPrtCd_tComboEditor.MaxDropDownItems = this.EstimateTotalPrtCd_tComboEditor.Items.Count;

            //// 見積書印刷区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.EstimateFormPrtCd_tComboEditor.Items.Clear();
            //this.EstimateFormPrtCd_tComboEditor.Items.Add(0, ESTIMATEFORMPRTCD_NORMAL);
            //this.EstimateFormPrtCd_tComboEditor.Items.Add(1, ESTIMATEFORMPRTCD_PAGEOVER);
            //this.EstimateFormPrtCd_tComboEditor.Items.Add(2, ESTIMATEFORMPRTCD_ANOTHER);
            //this.EstimateFormPrtCd_tComboEditor.MaxDropDownItems = this.EstimateFormPrtCd_tComboEditor.Items.Count;

            //// 敬称印刷区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.HonorificTitlePrtCd_tComboEditor.Items.Clear();
            //this.HonorificTitlePrtCd_tComboEditor.Items.Add(0, DIVISION_YES);
            //this.HonorificTitlePrtCd_tComboEditor.Items.Add(1, DIVISION_NO);
            //this.HonorificTitlePrtCd_tComboEditor.MaxDropDownItems = this.HonorificTitlePrtCd_tComboEditor.Items.Count;

            //// 見積依頼区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.EstimateRequestCd_tComboEditor.Items.Clear();
            //this.EstimateRequestCd_tComboEditor.Items.Add(0, ESTIMATEFORMPRTCD_NORMAL);
            //this.EstimateRequestCd_tComboEditor.Items.Add(1, ESTIMATEFORMPRTCD_PAGEOVER);
            //this.EstimateRequestCd_tComboEditor.Items.Add(2, ESTIMATEFORMPRTCD_ANOTHER);
            //this.EstimateRequestCd_tComboEditor.MaxDropDownItems = this.EstimateRequestCd_tComboEditor.Items.Count;
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            
            // 見積書番号採番区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.EstmFormNoPickDiv_tComboEditor.Items.Clear();
            this.EstmFormNoPickDiv_tComboEditor.Items.Add(0, DIVISION_ON);
            this.EstmFormNoPickDiv_tComboEditor.Items.Add(1, DIVISION_OFF);
            this.EstmFormNoPickDiv_tComboEditor.MaxDropDownItems = this.EstmFormNoPickDiv_tComboEditor.Items.Count;

            // 見積書発行区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.EstimatePrtDiv_tComboEditor.Items.Clear();
            this.EstimatePrtDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            this.EstimatePrtDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            this.EstimatePrtDiv_tComboEditor.MaxDropDownItems = this.EstimatePrtDiv_tComboEditor.Items.Count;

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 見積依頼書発行区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.EstimateReqPrtDiv_tComboEditor.Items.Clear();
            //this.EstimateReqPrtDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            //this.EstimateReqPrtDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            //this.EstimateReqPrtDiv_tComboEditor.MaxDropDownItems = this.EstimateReqPrtDiv_tComboEditor.Items.Count;

            //// 見積確認書発行区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //this.EstimateConfPrtDiv_tComboEditor.Items.Clear();
            //this.EstimateConfPrtDiv_tComboEditor.Items.Add(0, DIVISION_NO);
            //this.EstimateConfPrtDiv_tComboEditor.Items.Add(1, DIVISION_YES);
            //this.EstimateConfPrtDiv_tComboEditor.MaxDropDownItems = this.EstimateConfPrtDiv_tComboEditor.Items.Count;
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 消費税印刷区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.ConsTaxPrintDiv_tComboEditor.Items.Clear();
            this.ConsTaxPrintDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            this.ConsTaxPrintDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            this.ConsTaxPrintDiv_tComboEditor.MaxDropDownItems = this.ConsTaxPrintDiv_tComboEditor.Items.Count;

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // ＦＡＸ見積区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.FaxEstimatetDiv_tComboEditor.Items.Clear();
            this.FaxEstimatetDiv_tComboEditor.Items.Add(0, DIVISION_NO);
            this.FaxEstimatetDiv_tComboEditor.Items.Add(1, DIVISION_YES);
            this.FaxEstimatetDiv_tComboEditor.MaxDropDownItems = this.FaxEstimatetDiv_tComboEditor.Items.Count;

            // 品番印字区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.PartsNoPrtCd_tComboEditor.Items.Clear();
            this.PartsNoPrtCd_tComboEditor.Items.Add(0, DIVISION_NO);
            this.PartsNoPrtCd_tComboEditor.Items.Add(1, DIVISION_YES);
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = this.PartsNoPrtCd_tComboEditor.Items.Count;

            // オプション印字区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.OptionPringDivCd_tComboEditor.Items.Clear();
            this.OptionPringDivCd_tComboEditor.Items.Add(0, DIVISION_NO);
            this.OptionPringDivCd_tComboEditor.Items.Add(1, DIVISION_YES);
            this.OptionPringDivCd_tComboEditor.MaxDropDownItems = this.OptionPringDivCd_tComboEditor.Items.Count;

            // 部品選択区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.PartsSelectDivCd_tComboEditor.Items.Clear();
            this.PartsSelectDivCd_tComboEditor.Items.Add(0, DIVISION_YES);
            this.PartsSelectDivCd_tComboEditor.Items.Add(1, DIVISION_NO);
            this.PartsSelectDivCd_tComboEditor.MaxDropDownItems = this.PartsSelectDivCd_tComboEditor.Items.Count;

            // 部品検索区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.PartsSearchDivCd_tComboEditor.Items.Clear();
            this.PartsSearchDivCd_tComboEditor.Items.Add(0, PARTSSEARCHDIVCD_PARTS);
            this.PartsSearchDivCd_tComboEditor.Items.Add(1, PARTSSEARCHDIVCD_NO);
            this.PartsSearchDivCd_tComboEditor.MaxDropDownItems = this.PartsSearchDivCd_tComboEditor.Items.Count;

            // 見積データ作成区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.EstimateDtCreateDiv_tComboEditor.Items.Clear();
            this.EstimateDtCreateDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            this.EstimateDtCreateDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            this.EstimateDtCreateDiv_tComboEditor.MaxDropDownItems = this.EstimateDtCreateDiv_tComboEditor.Items.Count;

            // 掛率使用区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.RateUseCode_tComboEditor.Items.Clear();
            this.RateUseCode_tComboEditor.Items.Add(0, RATEUSECODE_DEFAULT);
            this.RateUseCode_tComboEditor.Items.Add(1, RATEUSECODE_RATESELECT);
            this.RateUseCode_tComboEditor.Items.Add(2, RATEUSECODE_RATESET);
            this.RateUseCode_tComboEditor.MaxDropDownItems = this.RateUseCode_tComboEditor.Items.Count;
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void ScreenClear()
		{
            //this.SectionCode_tComboEditor.SelectedIndex = 0;        // 拠点  // DEL 2008/06/04

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.FractionProcCd_tComboEditor.SelectedIndex = 0;     // 端数処理区分
            //this.ConsTaxLayMethod_tComboEditor.SelectedIndex = 0;   // 消費税転嫁方式
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.ListPricePrintDiv_tComboEditor.SelectedIndex = 0;  // 定価印刷区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.EraNameDispCd1_tComboEditor.SelectedIndex = 0;     // 元号表示区分１
            //this.EstimateTotalPrtCd_tComboEditor.SelectedIndex = 0; // 見積合計印刷区分
            //this.EstimateFormPrtCd_tComboEditor.SelectedIndex = 0;  // 見積書印刷区分
            //this.HonorificTitlePrtCd_tComboEditor.SelectedIndex = 0;// 敬称印刷区分
            //this.EstimateRequestCd_tComboEditor.SelectedIndex = 0;  // 見積依頼区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.EstmFormNoPickDiv_tComboEditor.SelectedIndex = 0;  // 見積書番号採番区分
            this.EstimateTitle1_tEdit.Clear();                      // 見積タイトル１		
            this.EstimateNote1_tEdit.Clear();                       // 見積備考１      
            this.EstimateNote2_tEdit.Clear();                       // 見積備考２
            this.EstimateNote3_tEdit.Clear();                       // 見積備考３
            this.EstimatePrtDiv_tComboEditor.SelectedIndex = 0;     // 見積書発行区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.EstimateReqPrtDiv_tComboEditor.SelectedIndex = 0;  // 見積依頼書発行区分
            //this.EstimateConfPrtDiv_tComboEditor.SelectedIndex = 0; // 見積確認書発行区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.ConsTaxPrintDiv_tComboEditor.SelectedIndex = 0;    // 消費税印刷区分

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this.FaxEstimatetDiv_tComboEditor.SelectedIndex = 0;      // ＦＡＸ見積区分
            this.tEdit_SectionCodeAllowZero2.Clear();                  // 拠点コード
            this.SectionNm_tEdit.Clear();                             // 拠点ガイド名称
            this.PartsNoPrtCd_tComboEditor.SelectedIndex = 0;         // 品番印字区分
            this.OptionPringDivCd_tComboEditor.SelectedIndex = 0;     // オプション印字区分
            this.EstimateValidityTerm_tEdit.Clear();                  // 見積書有効期限
            this.PartsSelectDivCd_tComboEditor.SelectedIndex = 0;     // 部品選択区分
            this.PartsSearchDivCd_tComboEditor.SelectedIndex = 0;     // 部品検索区分
            this.EstimateDtCreateDiv_tComboEditor.SelectedIndex = 0;  // 見積データ作成区分
            this.RateUseCode_tComboEditor.SelectedIndex = 0;          // 掛率使用区分
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if( this._dataIndex < 0 ) {
				// 新規モード
				this._logicalDeleteMode = -1;

                EstimateDefSet newEstimateDefSet = new EstimateDefSet();

                // 「見積書有効期限」初期値設定
                newEstimateDefSet.EstimateValidityTerm = 1;  // ADD 2008/06/04

                // 見積初期値設定オブジェクトを画面に展開
				EstimateDefSetToScreen( newEstimateDefSet );

                // クローン作成
				this._estimateDefSetClone = newEstimateDefSet.Clone();
				DispToEstimateDefSet( ref this._estimateDefSetClone );
			}
			else {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
                EstimateDefSet estimateDefSet = (EstimateDefSet)this._estimateDefSetTable[guid];

                // 見積初期値設定オブジェクトを画面に展開
				EstimateDefSetToScreen( estimateDefSet );

                if ( estimateDefSet.LogicalDeleteCode == 0 ) {
					// 更新モード
					this._logicalDeleteMode = 0;

					// クローン作成
					this._estimateDefSetClone = estimateDefSet.Clone();
					DispToEstimateDefSet( ref this._estimateDefSetClone );
				}
				else {
					// 削除モード
					this._logicalDeleteMode = 1;
				}
			}
			// _GridIndexバッファ保持（メインフレーム最小化対応）
			this._indexBuf = this._dataIndex;

			ScreenInputPermissionControl();
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void ScreenInputPermissionControl()
		{
            switch (this._logicalDeleteMode)
            {
				case -1:
				{
					// 新規モード
					this.Mode_Label.Text		= INSERT_MODE;

					// ボタンの表示
					this.Ok_Button.Visible			= true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;
                    // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

					// コントロールの表示設定
					ScreenInputPermissionControl( true );

                    // --- ADD 2008/06/04 -------------------------------->>>>>
                    // 初期フォーカスをセット
                    this.tEdit_SectionCodeAllowZero2.Focus();

                    // 拠点コードのコメント表示
                    SectionNm_Label.Visible = true;
                    // --- ADD 2008/06/04 --------------------------------<<<<< 

					break;
				}
				case 1:
				{
					// 削除モード
					this.Mode_Label.Text		= DELETE_MODE;

					// ボタンの表示
					this.Ok_Button.Visible			= false;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= true;
					this.Delete_Button.Visible		= true;
                    // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = false;
                    // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

					// コントロールの表示設定
					ScreenInputPermissionControl( false );

					// 初期フォーカスをセット
					this.Delete_Button.Focus();

                    // 拠点コードのコメント非表示
                    SectionNm_Label.Visible = false;  // ADD 2008/06/04

					break;
				}
				default:
				{
					// 更新モード
					this.Mode_Label.Text		= UPDATE_MODE;

					// ボタンの表示
					this.Ok_Button.Visible			= true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;
                    // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

					// コントロールの表示設定
					ScreenInputPermissionControl( true );

                    // --- ADD 2008/06/04 -------------------------------->>>>>
                    // 拠点関係のコントロールを使用不可にする
                    tEdit_SectionCodeAllowZero2.Enabled = false;
                    SectionGd_ultraButton.Enabled = false;
                    SectionNm_tEdit.Enabled = false;

                    // 拠点コードのコメント非表示
                    SectionNm_Label.Visible = false;  
                    // --- ADD 2008/06/04 --------------------------------<<<<< 

					// 初期フォーカスをセット
                    this.EstimatePrtDiv_tComboEditor.Focus();

					break;
				}
			}
		}
		
		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		void ScreenInputPermissionControl( bool enabled )
		{
            // this.SectionCode_tComboEditor.Enabled           = enabled;  // 拠点  // DEL 2008/06/04
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.FractionProcCd_tComboEditor.Enabled      = enabled;  // 端数処理区分
            //this.ConsTaxLayMethod_tComboEditor.Enabled    = enabled;  // 消費税転嫁方式
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.ListPricePrintDiv_tComboEditor.Enabled     = enabled;  // 定価印刷区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.EraNameDispCd1_tComboEditor.Enabled      = enabled;  // 元号表示区分１
            //this.EstimateTotalPrtCd_tComboEditor.Enabled	= enabled;  // 見積合計印刷区分
            //this.EstimateFormPrtCd_tComboEditor.Enabled	= enabled;  // 見積書印刷区分
            //this.HonorificTitlePrtCd_tComboEditor.Enabled	= enabled;  // 敬称印刷区分
            //this.EstimateRequestCd_tComboEditor.Enabled	= enabled;  // 見積依頼区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.EstmFormNoPickDiv_tComboEditor.Enabled     = enabled;  // 見積書番号採番区分
            this.EstimateTitle1_tEdit.Enabled				= enabled;  // 見積タイトル１		
            this.EstimateNote1_tEdit.Enabled				= enabled;  // 見積備考１      
            this.EstimateNote2_tEdit.Enabled				= enabled;  // 見積備考２
            this.EstimateNote3_tEdit.Enabled				= enabled;  // 見積備考３
            this.EstimatePrtDiv_tComboEditor.Enabled		= enabled;  // 見積書発行区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.EstimateReqPrtDiv_tComboEditor.Enabled   = enabled;  // 見積依頼書発行区分
            //this.EstimateConfPrtDiv_tComboEditor.Enabled  = enabled;  // 見積確認書発行区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.ConsTaxPrintDiv_tComboEditor.Enabled       = enabled;  // 消費税印刷区分

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this.FaxEstimatetDiv_tComboEditor.Enabled		= enabled;  // ＦＡＸ見積区分
            this.tEdit_SectionCodeAllowZero2.Enabled                  = enabled;  // 拠点コード
            this.SectionGd_ultraButton.Enabled              = enabled;  // ガイドボタン 
            this.SectionNm_tEdit.Enabled                    = enabled;  // 拠点ガイド名称
            this.PartsNoPrtCd_tComboEditor.Enabled          = enabled;  // 品番印字区分
            this.OptionPringDivCd_tComboEditor.Enabled      = enabled;  // オプション印字区分
            this.EstimateValidityTerm_tEdit.Enabled         = enabled;  // 見積書有効期限
            this.PartsSelectDivCd_tComboEditor.Enabled      = enabled;  // 部品選択区分
            this.PartsSearchDivCd_tComboEditor.Enabled      = enabled;  // 部品検索区分
            this.EstimateDtCreateDiv_tComboEditor.Enabled   = enabled;  // 見積データ作成区分
            this.RateUseCode_tComboEditor.Enabled           = enabled;  // 掛率使用区分

            // ちらつき防止の為
            this.Enabled = true;
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

		/// <summary>
        /// 見積初期値設定クラス画面展開処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 見積初期値設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void EstimateDefSetToScreen( EstimateDefSet estimateDefSet)
		{
            //this.SectionCode_tComboEditor.Value         = estimateDefSet.SectionCode.TrimEnd(); // 拠点コード  // DEL 2008/06/04

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //if (estimateDefSet.FractionProcCd == 0)
            //{
            //    this.FractionProcCd_tComboEditor.Value  = 1;		                            // 端数処理区分
            //}
            //else
            //{
            //    this.FractionProcCd_tComboEditor.Value  = estimateDefSet.FractionProcCd;		// 端数処理区分
            //}
            //this.ConsTaxLayMethod_tComboEditor.Value    = estimateDefSet.ConsTaxLayMethod;	    // 消費税転嫁方式
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.ListPricePrintDiv_tComboEditor.Value   = estimateDefSet.ListPricePrintDiv;     // 定価印刷区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.EraNameDispCd1_tComboEditor.Value      = estimateDefSet.EraNameDispCd1;		  // 元号表示区分１
            //this.EstimateTotalPrtCd_tComboEditor.Value  = estimateDefSet.EstimateTotalPrtCd;    // 見積合計印刷区分
            //this.EstimateFormPrtCd_tComboEditor.Value   = estimateDefSet.EstimateFormPrtCd;     // 見積書印刷区分
            //this.HonorificTitlePrtCd_tComboEditor.Value = estimateDefSet.HonorificTitlePrtCd;   // 敬称印刷区分
            //this.EstimateRequestCd_tComboEditor.Value   = estimateDefSet.EstimateRequestCd;     // 見積依頼区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.EstmFormNoPickDiv_tComboEditor.Value   = estimateDefSet.EstmFormNoPickDiv;     // 見積書番号採番区分
            this.EstimateTitle1_tEdit.DataText          = estimateDefSet.EstimateTitle1;        // 見積タイトル１
            this.EstimateNote1_tEdit.DataText           = estimateDefSet.EstimateNote1;         // 見積備考１
            this.EstimateNote2_tEdit.DataText           = estimateDefSet.EstimateNote2;         // 見積備考２
            this.EstimateNote3_tEdit.DataText           = estimateDefSet.EstimateNote3;         // 見積備考３
            this.EstimatePrtDiv_tComboEditor.Value      = estimateDefSet.EstimatePrtDiv;        // 見積書発行区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.EstimateReqPrtDiv_tComboEditor.Value   = estimateDefSet.EstimateReqPrtDiv;     // 見積依頼書発行区分
            //this.EstimateConfPrtDiv_tComboEditor.Value  = estimateDefSet.EstimateConfPrtDiv;    // 見積確認書発行区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            this.ConsTaxPrintDiv_tComboEditor.Value = estimateDefSet.ConsTaxPrintDiv;       // 消費税印刷区分

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this.FaxEstimatetDiv_tComboEditor.Value     = estimateDefSet.FaxEstimatetDiv;         // ＦＡＸ見積区分

            this.tEdit_SectionCodeAllowZero2.Value = estimateDefSet.SectionCode.TrimEnd();                  // 拠点コード
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
                {
                    this.SectionNm_tEdit.Value = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/10/02 不具合対応[5966]---------->>>>>
            // 拠点コード（全社共通）
            if (SectionUtil.IsAllSection(estimateDefSet.SectionCode.TrimEnd()))
            {
                this.SectionNm_tEdit.Value = SectionUtil.ALL_SECTION_NAME;
            }
            // ADD 2008/10/02 不具合対応[5966]----------<<<<<

            this.PartsNoPrtCd_tComboEditor.Value = estimateDefSet.PartsNoPrtCd;                 // 品番印字区分
            this.OptionPringDivCd_tComboEditor.Value = estimateDefSet.OptionPringDivCd;         // オプション印字区分
            this.PartsSelectDivCd_tComboEditor.Value = estimateDefSet.PartsSelectDivCd;         // 部品選択区分
            this.PartsSearchDivCd_tComboEditor.Value = estimateDefSet.PartsSearchDivCd;         // 部品検索区分
            this.EstimateDtCreateDiv_tComboEditor.Value = estimateDefSet.EstimateDtCreateDiv;   // 見積データ作成区分
            this.EstimateValidityTerm_tEdit.Value = estimateDefSet.EstimateValidityTerm;        // 見積書有効期限
            this.RateUseCode_tComboEditor.Value = estimateDefSet.RateUseCode;                   // 掛率使用区分
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

		/// <summary>
        /// 見積初期値設定クラス格納処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報から見積初期値設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void DispToEstimateDefSet(ref EstimateDefSet estimateDefSet)
		{
			if( estimateDefSet == null ) {
                estimateDefSet = new EstimateDefSet();
			}

            estimateDefSet.EnterpriseCode       = this._enterpriseCode;					            // 企業コード

            /* --- DEL 2008/06/04 -------------------------------->>>>>
            if ((this.SectionCode_tComboEditor.SelectedItem != null) &&
                (this.SectionCode_tComboEditor.Value != null))
            {
                estimateDefSet.SectionCode = this.SectionCode_tComboEditor.Value.ToString();        // 拠点コード
            }
            else
            {
                estimateDefSet.SectionCode = "";
            }
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSet.FractionProcCd       = (int)this.FractionProcCd_tComboEditor.Value;      // 端数処理区分
            //estimateDefSet.ConsTaxLayMethod     = (int)this.ConsTaxLayMethod_tComboEditor.Value;    // 消費税転嫁方式
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            estimateDefSet.ListPricePrintDiv    = (int)this.ListPricePrintDiv_tComboEditor.Value;   // 定価印刷区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSet.EraNameDispCd1       = (int)this.EraNameDispCd1_tComboEditor.Value;      // 元号表示区分１
            //estimateDefSet.EstimateTotalPrtCd   = (int)this.EstimateTotalPrtCd_tComboEditor.Value;  // 見積合計印刷区分
            //estimateDefSet.EstimateFormPrtCd    = (int)this.EstimateFormPrtCd_tComboEditor.Value;   // 見積書印刷区分
            //estimateDefSet.HonorificTitlePrtCd  = (int)this.HonorificTitlePrtCd_tComboEditor.Value; // 敬称印刷区分
            //estimateDefSet.EstimateRequestCd    = (int)this.EstimateRequestCd_tComboEditor.Value;   // 見積依頼区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            estimateDefSet.EstmFormNoPickDiv    = (int)this.EstmFormNoPickDiv_tComboEditor.Value;   // 見積書番号採番区分
            estimateDefSet.EstimateTitle1       = this.EstimateTitle1_tEdit.DataText;               // 見積タイトル１
            estimateDefSet.EstimateNote1        = this.EstimateNote1_tEdit.DataText;                // 見積備考１
            estimateDefSet.EstimateNote2        = this.EstimateNote2_tEdit.DataText;                // 見積備考２
            estimateDefSet.EstimateNote3        = this.EstimateNote3_tEdit.DataText;                // 見積備考３
            estimateDefSet.EstimatePrtDiv       = (int)this.EstimatePrtDiv_tComboEditor.Value;      // 見積書発行区分
            // 2008.03.14 削除 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSet.EstimateReqPrtDiv    = (int)this.EstimateReqPrtDiv_tComboEditor.Value;   // 見積依頼書発行区分
            //estimateDefSet.EstimateConfPrtDiv   = (int)this.EstimateConfPrtDiv_tComboEditor.Value;  // 見積確認書発行区分
            // 2008.03.14 削除 <<<<<<<<<<<<<<<<<<<<
            estimateDefSet.ConsTaxPrintDiv      = (int)this.ConsTaxPrintDiv_tComboEditor.Value;     // 消費税印刷区分

            // --- ADD 2008/06/04 -------------------------------->>>>>
            estimateDefSet.FaxEstimatetDiv      = (int)this.FaxEstimatetDiv_tComboEditor.Value;     // ＦＡＸ見積区分

            estimateDefSet.SectionCode          = this.tEdit_SectionCodeAllowZero2.DataText;         // 拠点コード
            // ADD 2008/09/26 不具合対応[5659] ---------->>>>>
            // uiSetControlが""のとき"00"を設定するので、デフォルト値は"00"とする
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                estimateDefSet.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/26 不具合対応[5659] ----------<<<<<

            estimateDefSet.PartsNoPrtCd         = (int)this.PartsNoPrtCd_tComboEditor.Value;        // 品番印字区分
            estimateDefSet.OptionPringDivCd     = (int)this.OptionPringDivCd_tComboEditor.Value;    // オプション印字区分
            estimateDefSet.PartsSelectDivCd     = (int)this.PartsSelectDivCd_tComboEditor.Value;    // 部品選択区分
            estimateDefSet.PartsSearchDivCd     = (int)this.PartsSearchDivCd_tComboEditor.Value;    // 部品検索区分
            estimateDefSet.EstimateDtCreateDiv  = (int)this.EstimateDtCreateDiv_tComboEditor.Value; // 見積データ作成区分
            estimateDefSet.EstimateValidityTerm = Int32.Parse(this.EstimateValidityTerm_tEdit.Value.ToString()); // 見積書有効期限
            estimateDefSet.RateUseCode          = (int)this.RateUseCode_tComboEditor.Value;         // 掛率使用区分
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

        /// <summary>
        /// 見積初期値設定保存処理
		/// </summary>
		/// <returns>結果</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の保存を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private bool SaveProc()
		{
			bool result = false;

			// 入力チェック
			Control control = null;
			string message = null;
			if( !ScreenDataCheck( ref control, ref message ) ) {
				// 入力チェック
				TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
					message, 							// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK );				// 表示するボタン
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //control.Focus();
                //if( control is TNedit ) {
                //    ( ( TNedit )control ).SelectAll();
                //}
                //else if( control is TEdit ) {
                //    ( ( TEdit )control ).SelectAll();
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
				return result;
			}
            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<


            EstimateDefSet estimateDefSet = null;
			if( this._dataIndex >= 0 ) {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
                estimateDefSet = ((EstimateDefSet)this._estimateDefSetTable[guid]).Clone();
			}
			DispToEstimateDefSet( ref estimateDefSet );

            int status = this._estimateDefSetAcs.Write(ref estimateDefSet);
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    // VIEWのデータセットを更新
					EstimateDefSetToDataSet( estimateDefSet.Clone(), this._dataIndex );
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// コード重複
					TMsgDisp.Show( 
						this, 									// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                        "DCMIT09010U", 							// アセンブリＩＤまたはクラスＩＤ
						"このコードは既に使用されています。", 	// 表示するメッセージ
						0, 										// ステータス値
						MessageBoxButtons.OK );					// 表示するボタン
                    //this.SectionCode_tComboEditor.Focus();  // DEL 2008/06/04
                    tEdit_SectionCodeAllowZero2.Focus();                  // ADD 2008/06/04
					return result;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return result;
				}
				default:
				{
					// 登録失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                        "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
                        "見積全体設定", 					// プログラム名称
						"SaveProc", 						// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"登録に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
                        this._estimateDefSetAcs,			// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					CloseForm( DialogResult.Cancel );
					return result;
				}
			}

			result = true;
			return result;
		}

        /// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果(true:OK／false:NG)</returns>
		/// <remarks>
		/// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            /* --- DEL 2008/06/04 -------------------------------->>>>>
			// 拠点コード
            if (this.SectionCode_tComboEditor.Value == null)
            {
                message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.SectionCode_tComboEditor;
                result = false;
            }
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false;
                return result; // ADD 2011/09/07
            }
            // --- ADD 2008/06/04 --------------------------------<<<<< 

            // --- ADD 2008/09/16 -------------------------------->>>>>
            // 拠点コードの存在チェック
            bool existCheck = false;
            // --- ADD 2011/09/07 -------------------------------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.DataText != "")
                this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');
            // --- ADD 2011/09/07 --------------------------------<<<<<

            // ADD 2008/09/26 不具合対応[5659]---------->>>>>
            // 全社共通は拠点マスタに登録されていないため、チェックの対象外
            if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText))
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText)
                    {
                        existCheck = true;
                        break;
                    }
                }
            }
            else
            {
                existCheck = true;
            }
            // ADD 2008/09/26 不具合対応[5659]----------<<<<<
            // DEL 2008/09/26 不具合対応[5659] ---------->>>>>
            //foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //{
            //    if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero.DataText)
            //    {
            //        existCheck = true;
            //        break;
            //    }
            //}
            // DEL 2008/09/26 不具合対応[5659] ----------<<<<<
            if (existCheck)
            {
                result = true;
            }
            else
            {
                message = "指定した拠点コードは存在しません。";

                control = this.tEdit_SectionCodeAllowZero2;

                result = false;
            }
            // --- ADD 2008/09/16 --------------------------------<<<<<

            return result;
		}

		/// <summary>
        /// 見積初期値設定オブジェクト論理削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int LogicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// 情報取得
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
            EstimateDefSet estimateDefSet = ((EstimateDefSet)this._estimateDefSetTable[guid]).Clone();

            // 見積初期値設定が存在していない
			if( estimateDefSet == null ) {
				return -1;
			}

            // --- ADD 2008/09/16 -------------------------------->>>>>
            // 全社（拠点コードが"00"）の場合、削除不可にする。
            if (estimateDefSet.SectionCode.TrimEnd() == "00")
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
                    "全社共通設定は削除出来ません。", 	// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                return -1;
            }
            // --- ADD 2008/09/16 --------------------------------<<<<<

            status = this._estimateDefSetAcs.LogicalDelete(ref estimateDefSet);
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					EstimateDefSetToDataSet( estimateDefSet.Clone(), this._dataIndex );
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, false );
					return status;
				}
				default:
				{
						// 論理削除
						TMsgDisp.Show( 
							this, 								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
                            "見積全体設定", 					// プログラム名称
							"LogicalDelete", 					// 処理名称
							TMsgDisp.OPE_HIDE, 					// オペレーション
							"削除に失敗しました。", 			// 表示するメッセージ
							status, 							// ステータス値
                            this._estimateDefSetAcs,			// エラーが発生したオブジェクト
							MessageBoxButtons.OK, 				// 表示するボタン
							MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					return status;
				}
			}
			return status;
		}

		/// <summary>
        /// 見積初期値設定オブジェクト論理削除復活処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定オブジェクトの論理削除復活を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int Revival()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// 情報取得
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
            EstimateDefSet estimateDefSet = ((EstimateDefSet)this._estimateDefSetTable[guid]).Clone();

            // 見積初期値設定が存在していない
			if( estimateDefSet == null ) {
				return -1;
			}

            status = this._estimateDefSetAcs.Revival(ref estimateDefSet);
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					EstimateDefSetToDataSet( estimateDefSet.Clone(), this._dataIndex );
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// 復活失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                        "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
                        "見積全体設定", 					// プログラム名称
						"Revival", 							// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"復活に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
                        this._estimateDefSetAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

		/// <summary>
        /// 見積初期値設定オブジェクト完全削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定ブジェクトの完全削除を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int PhysicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// 情報取得
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
            EstimateDefSet estimateDefSet = (EstimateDefSet)this._estimateDefSetTable[guid];

            // 見積初期値設定が存在していない
			if( estimateDefSet == null ) {
				return -1;
			}

            // ADD 2008/09/26 不具合対応[5259] ---------->>>>>
            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(estimateDefSet))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name,                     // 処理名称
                    TMsgDisp.OPE_DELETE, 				                    // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/26 不具合対応[5259] ----------<<<<<

            status = this._estimateDefSetAcs.Delete(estimateDefSet);
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    // ハッシュテーブルからデータを削除
					this._estimateDefSetTable.Remove( ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex][ GUID_TITLE ] );
					// データセットからデータを削除
					this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex].Delete();
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// 物理削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                        "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
                        "見積全体設定", 					// プログラム名称
						"PhysicalDelete", 					// 処理名称
						TMsgDisp.OPE_DELETE, 				// オペレーション
						"削除に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
                        this._estimateDefSetAcs,			// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

        // ADD 2008/09/26 不具合対応[5659] ---------->>>>>
        /// <summary>
        /// 全社共通か判定します。
        /// </summary>
        /// <param name="estimateDefSet">見積初期値設定</param>
        /// <returns><c>true</c> :全社共通である。<br/><c>false</c>:全社共通ではない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5659]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/26</br>
        /// </remarks>
        private static bool IsAllSection(EstimateDefSet estimateDefSet)
        {
            return SectionUtil.IsAllSection(estimateDefSet.SectionCode);
        }
        // ADD 2008/09/26 不具合対応[5659] ----------<<<<<

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
		/// <remarks>
		/// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void ExclusiveTransaction( int status, bool hide )
		{
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					if( hide == true ) {
						CloseForm( DialogResult.Cancel );
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					if( hide == true ) {
						CloseForm( DialogResult.Cancel );
					}
					break;
				}
			}
		}

		/// <summary>
		/// フォームクローズ処理）
		/// </summary>
		/// <param name="dialogResult">ダイアログ結果</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void CloseForm( DialogResult dialogResult )
		{
			// 画面非表示イベント
			if ( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( dialogResult );
				UnDisplaying( this, me );
			}

			this.DialogResult = dialogResult;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;
			
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        #endregion

		#region Control Events
		/// <summary>
        /// Form.Load イベント(DCMIT09010UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DCMIT09010UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList							= imageList24;
			this.Cancel_Button.ImageList						= imageList24;
			this.Revive_Button.ImageList						= imageList24;
			this.Delete_Button.ImageList						= imageList24;
            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

            this.Ok_Button.Appearance.Image						= Size24_Index.SAVE;	// 保存ボタン
			this.Cancel_Button.Appearance.Image					= Size24_Index.CLOSE;	// 閉じるボタン
			this.Revive_Button.Appearance.Image					= Size24_Index.REVIVAL;	// 復活ボタン
			this.Delete_Button.Appearance.Image					= Size24_Index.DELETE;	// 完全削除ボタン
            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1]; // ADD 2008/06/04

            // 画面を構築
			ScreenInitialSetting();

            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();  // ADD 2008/09/26 不具合対応[5659]
		}

		/// <summary>
        /// Form.Closing イベント(DCMIT09010UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DCMIT09010UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if( this._canClose == false ) {
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Form.VisibleChanged イベント(DCMIT09010UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DCMIT09010UA_VisibleChanged(object sender, System.EventArgs e)
		{
			if( this.Visible == false ) {
				this.Owner.Activate();
				return;
			}

			// _GridIndexバッファ（メインフレーム最小化対応）
			// ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
			if( this._indexBuf == this._dataIndex ) {
				return;
			}

            // ちらつき防止の為
            this.Enabled = false;

			this.Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Timer.Tick イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : 指定された間隔の時間が経過したときに発生します。
		///                   この処理は、システムが提供するスレッド プール
		///	                  スレッドで実行されます。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;
		
			ScreenReconstruction();
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if( !SaveProc() ) {			// 登録
				return;
			}

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if ( this.Mode_Label.Text == INSERT_MODE )
			{
				ScreenClear();

				// 新規モード
				this._logicalDeleteMode = -1;

                EstimateDefSet newEstimateDefSet = new EstimateDefSet();

                // 「見積書有効期限」初期値設定
                newEstimateDefSet.EstimateValidityTerm = 1;  // ADD 2008/06/04

                // 見積初期値設定オブジェクトを画面に展開
				EstimateDefSetToScreen( newEstimateDefSet );

                // クローン作成
				this._estimateDefSetClone = newEstimateDefSet.Clone();
				DispToEstimateDefSet( ref this._estimateDefSetClone );

				// _GridIndexバッファ保持
				this._indexBuf = this._dataIndex;

				ScreenInputPermissionControl();
			}
			else {
				this.DialogResult = DialogResult.OK;

				// _GridIndexバッファ初期化（メインフレーム最小化対応）
				this._indexBuf = -2;

				if( this._canClose == true ) {
					this.Close();
				}
				else {
					this.Hide();
				}
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if( this.Mode_Label.Text != DELETE_MODE ) {
				// 現在の画面情報を取得する
                EstimateDefSet compareEstimateDefSet = new EstimateDefSet();
				compareEstimateDefSet = this._estimateDefSetClone.Clone();
				DispToEstimateDefSet( ref compareEstimateDefSet );

				// 最初に取得した画面情報と比較
				if ( !( this._estimateDefSetClone.Equals( compareEstimateDefSet ) ))
                {
					// 画面情報が変更されていた場合は、保存確認メッセージを表示する
					// 保存確認
					DialogResult res = TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
						null, 								// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.YesNoCancel );	// 表示するボタン
					switch( res ) {
						case DialogResult.Yes:
						{
							if ( !SaveProc() ) {
								return;
							}
							break;
   						}

						case DialogResult.No:
						{
							break;
						}
						default:
						{
							// 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tEdit_SectionCodeAllowZero2.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
							return;
						}
					}
				}
			}

			if ( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.Cancel );
				UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.Cancel;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if ( this._canClose ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click イベント(Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			if( Revival() != 0 ) {
				return;
			}

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.OK;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// 完全削除確認
			DialogResult result = TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "DCMIT09010U", 						// アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + 
				"よろしいですか？", 				// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.OKCancel, 		// 表示するボタン
				MessageBoxDefaultButton.Button2 );	// 初期表示ボタン

			if( result == DialogResult.OK ) {
				if( PhysicalDelete() != 0 ) {
					return;
				}
            }
            else
            {
				this.Delete_Button.Focus();
                return;
            }

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

            this.DialogResult = DialogResult.OK;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

        /// <summary>
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 不具合対応[6226]
                    return;
                }

                // 取得データ表示
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                // フォーカスを見積書発行区分に変更
                this.EstimatePrtDiv_tComboEditor.Focus(); //ADD 2008/09/08

                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                // 新規モードからモード変更対応
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        SectionGd_ultraButton.Tag = GeneralGuideUIController.CAN_FOCUS;
                        SectionGd_ultraButton.Focus();
                        return;
                    }
                }
                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- DEL 2008/09/22 -------------------------------->>>>>
        ///// <summary>
        ///// 拠点コードEdit Leave処理
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 拠点名称表示処理</br>
        ///// <br>Programmer : 30415 柴田 倫幸</br>
        ///// <br>Date       : 2008/06/04</br>
        ///// </remarks>
        //private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        //{
        //    // 拠点コード入力あり？
        //    if (this.tEdit_SectionCodeAllowZero.Text != "")
        //    {
        //        // 拠点コード名称設定
        //        this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero.Text.Trim());
        //    }
        //    else
        //    {
        //        // 拠点コード名称クリア
        //        this.SectionNm_tEdit.Text = "";
        //    }
        //}
        // --- DEL 2008/09/22 -------------------------------->>>>>

        // --- ADD 2008/09/16 -------------------------------->>>>>
        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        /// <remarks>
        /// <br>Note	   : リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            if (e.PrevCtrl.Name == "tEdit_SectionCodeAllowZero2")
            {
                // --- ADD 2008/09/22 -------------------------------->>>>>
                // 入力がない場合と全社の場合は処理しない
                if (tEdit_SectionCodeAllowZero2.Text != "" &&
                    tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0') != "00")
                {
                    SecInfoSet secInfoSet;
                    int status = this._secInfoAcs.GetSecInfo(this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0').PadRight(6), out secInfoSet);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.TrimEnd();
                        this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                        //// 存在する場合は見積書発行区分にフォーカスを変更
                        //e.NextCtrl = this.EstimatePrtDiv_tComboEditor;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 存在する場合は見積書発行区分にフォーカスを変更
                                e.NextCtrl = this.EstimatePrtDiv_tComboEditor;
                            }
                        }
                    }
                    else
                    {
                        this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');// ADD 2011/09/07
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "指定した拠点コードは存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // 現在の入力をクリア
                        this.tEdit_SectionCodeAllowZero2.DataText = "";
                        this.SectionNm_tEdit.DataText = "";

                        // 存在しない場合はガイドボタンへフォーカスを変更
                        //e.NextCtrl = this.SectionGd_ultraButton; // DEL 2011/09/07
                        e.NextCtrl = this.tEdit_SectionCodeAllowZero2; // ADD 2011/09/07
                    }
                }
                // ADD 2008/09/26 不具合対応[5825]---------->>>>>
                else
                {
                    // uiSetControlが"00"に補正するので、拠点名称は全社共通を設定
                    //this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME; // DEL 2011/09/07
                    // --- ADD 2011/09/07 -------------------------------->>>>>
                    if (this.tEdit_SectionCodeAllowZero2.DataText == "0")
                    {
                        this.tEdit_SectionCodeAllowZero2.DataText = "00";
                    }
                    if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                    {
                        this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME;
                    }
                    // --- ADD 2011/09/07 --------------------------------<<<<<
                }
                // ADD 2008/09/26 不具合対応[5825]----------<<<<<
                // --- ADD 2008/09/22 --------------------------------<<<<<

                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                // ADD 2009/04/07 ------>>>
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                // ADD 2009/04/07 ------<<<
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            }
            // ADD 2009/04/07 ------>>>
            else if (e.PrevCtrl.Name == "Renewal_Button")
            {
                // 最新情報ボタンからの遷移時、更新チェックを追加
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero2")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            // ADD 2009/04/07 ------<<<
                
            return;
        }
        // --- ADD 2008/09/16 --------------------------------<<<<<
        #endregion

        private void ultraLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCMIT09010U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            isError = false;
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "入力されたコードの見積全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCMIT09010U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの見積全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/07
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの見積全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "DCMIT09010U",                          // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true; // ADD 2011/09/07
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コード、名称のクリア
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}
