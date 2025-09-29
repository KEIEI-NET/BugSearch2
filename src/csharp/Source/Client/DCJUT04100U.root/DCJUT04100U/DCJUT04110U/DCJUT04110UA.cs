//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 発注残照会
// プログラム概要   : 発注残照会の伝票検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/02/25  修正内容 : 障害ID:7882対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/04/03  修正内容 : 障害ID:13078対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/08  修正内容 : 障害ID:12784対応
//----------------------------------------------------------------------------//
// 管理番号  11175085-00 作成担当 : gaocheng
// 作 成 日  2015/05/08  修正内容 : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注残照会 メインＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 伝票検索を行います。</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2007.10.15</br>
    /// <br>Update Note : 2009/02/25 30414 忍 幸史 障害ID:7882対応</br>
    /// <br>Update Note : 2009/04/03 30452 上野 俊治 障害ID:13078対応</br>
    /// <br>Update Note: 2015/05/08 gaocheng</br>
    /// <br>管理番号   : 11175085-00 </br>
    /// <br>           : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>  
    /// </remarks>
    public partial class DCJUT04110UA : Form
	{
		#region ■Private Members
		private DCJUT04110UB _detailForm;

        private AcptAnOdrRemainRefAcs _acptAnOdrRemainRefAcs;
        private DisplayType _displayType;
		
        private DCCMN04000UB _printControl = null;
        private AcptAnOdrRemainRefSearchPara _parentSetCndtn;    // 起動元PGからの受け渡し用
        private AcptAnOdrRemainRefCndtn _inputCndtnCache;   // 前回入力退避用
        private SecInfoSetAcs _secInfoSetAcs;
        private SubSectionAcs _subSectionAcs;
        private MinSectionAcs _minSectionAcs;
        private WarehouseAcs _warehouseAcs;
        private DateGetAcs _dateGetAcs; // ADD 2009/04/03

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
        private SalesTtlStAcs _salesTtlStAcs;               // 売上全体設定アクセスクラス
        private int _inpAgentDispDiv;                       // 設定値保存用：売上全体設定．発行者表示区分

        // 発行者表示区分(DCKHN09211Eの区分と合わせる必要あり)
        private const int INP_AGT_DISP = 0;         // 0:する
        private const int INP_AGT_NODISP = 1;       // 1:しない
        private const int INP_AGT_NESSESALY = 2;    // 2:必須
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

        // 2008.11.17 add start [7914]
        private DateTime _prevTotalDay;
        private DateTime _currentTotalDay;
        private DateTime _prevTotalMonth;
        private DateTime _currentTotalMonth;
        // 2008.11.17 add end [7914]

        private string _enterpriseCode;             // 企業コード
        private string _loginSectionCode;           // 自拠点コード
        private bool _optSection;                   // 拠点オプション有無フラグ
        private bool _mainOfficeFunc;               // 本社/拠点判断フラグ
        private ImageList _imageList16 = null;									// イメージリスト

        private bool _loaded;   // Load処理済みフラグ

        private Infragistics.Win.UltraWinToolbars.ButtonTool _pursuitButton;    // 受注追跡ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;		// 印刷ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _previewButton;	// 印刷ボタン
		private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogRes = DialogResult.Cancel;

        private const string MESSAGE_StartEndError = "開始≦終了となるよう設定してください。";
        private const string MESSAGE_NoInput = "必須入力項目です。";
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。";
        // 2008.11.17 add start [7914]
        private const string MESSAGE_RangeOverError = "は３ヶ月の範囲内で入力して下さい。";
        // 2008.11.17 add end [7914]

		private const string cTAB_MAIN = "Main";
		private const string cTAB_PREVIEW = "Preview";

        private int _defaultSelectedValue = 0;

		#endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		# region Enums
		/// <summary>
		/// 表示タイプ
		/// </summary>
		public enum DisplayType : int
		{
			/// <summary>表示のみ</summary>
			DisplayOnly = 0,
			/// <summary>表示,選択機能</summary>
			DisplayAndSelect = 1,
		}
        /// <summary>
        /// 入荷状況区分
        /// </summary>
        public enum ArrivalState : int
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>入荷済のみ</summary>
            Arrival = 1,
            /// <summary>未入荷のみ</summary>
            NonArrival = 2,
        }
		#endregion


        // ===================================================================================== //
        // クラス
        // ===================================================================================== //
        # region class
        /// <summary>
        /// 抽出条件クラス（外部から照会UIを呼び出す場合に使用）
        /// </summary>
        public class AcptAnOdrRemainRefSearchPara
        {
            private string _sectionCode = string.Empty;
            private string _sectionName = string.Empty;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA DEL START
            //private int _subsectionCode = 0;
            //private string _subsectionName = string.Empty;
            //private int _minsectionCode = 0;
            //private string _minsectionName = string.Empty;
            //private string _partySlipNumDtl = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA DEL END
            private int _customerCode = 0;
            private string _customerName = string.Empty;
            private DateTime _st_SalesDate = DateTime.MinValue;
            private DateTime _ed_SalesDate = DateTime.MinValue;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA DEL START
            //private DateTime _st_DeliGdsCmpltDueDate = DateTime.MinValue;
            //private DateTime _ed_DeliGdsCmpltDueDate = DateTime.MinValue;
            //private DateTime _st_ArrivalDate = DateTime.MinValue;
            //private DateTime _ed_ArrivalDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA DEL END
            private ArrivalState _arrivalStateDiv = ArrivalState.All;
            private string _goodsNo = string.Empty;
            private string _goodsName = string.Empty;
            private string _goodsNameForSearch = string.Empty;
            private int _goodsMakerCd = 0;
            private string _makerName = string.Empty;
            private string _salesEmployeeCode = string.Empty;
            private string _salesEmployeeName = string.Empty;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            private int _claimCode = 0;
            private string _claimName = string.Empty;
            private int _acpOdrStateDiv = 0;
            private string _fullModel = string.Empty;
            private DateTime _st_SearchSlipDate = DateTime.MinValue;
            private DateTime _ed_SearchSlipDate = DateTime.MaxValue;
            private string _st_SalesSlipNum = string.Empty;
            private string _ed_SalesSlipNum = string.Empty;
            private string _salesInputCode = string.Empty;
            private string _salesInputName = string.Empty;
            private string _frontEmployeeCd = string.Empty;
            private string _frontEmployeeNm = string.Empty;
            private bool _goodsNmVagueSrch = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

            /// <summary>拠点コード</summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>拠点名称</summary>
            public string SectionName
            {
                get { return _sectionName; }
                set { _sectionName = value; }
            }
            ///// <summary>部門コード</summary>
            //public int SubSectionCode
            //{
            //    get { return _subsectionCode; }
            //    set { _subsectionCode = value; }
            //}
            ///// <summary>部門名称</summary>
            //public string SubSectionName
            //{
            //    get { return _subsectionName; }
            //    set { _subsectionName = value; }
            //}
            ///// <summary>課コード</summary>
            //public int MinSectionCode
            //{
            //    get { return _minsectionCode; }
            //    set { _minsectionCode = value; }
            //}
            ///// <summary>課名称</summary>
            //public string MinSectionName
            //{
            //    get { return _minsectionName; }
            //    set { _minsectionName = value; }
            //}
            /// <summary>得意先コード</summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>得意先名称</summary>
            public string CustomerName
            {
                get { return _customerName; }
                set { _customerName = value; }
            }
            ///// <summary>得意先注番</summary>
            //public string PartySlipNumDtl
            //{
            //    get { return _partySlipNumDtl; }
            //    set { _partySlipNumDtl = value; }
            //}
            /// <summary>受注日開始</summary>
            public DateTime St_SalesDate
            {
                get { return _st_SalesDate; }
                set { _st_SalesDate = value; }
            }
            /// <summary>受注日終了</summary>
            public DateTime Ed_SalesDate
            {
                get { return _ed_SalesDate; }
                set { _ed_SalesDate = value; }
            }
            ///// <summary>客先納期開始</summary>
            //public DateTime St_DeliGdsCmpltDueDate
            //{
            //    get { return _st_DeliGdsCmpltDueDate; }
            //    set { _st_DeliGdsCmpltDueDate = value; }
            //}
            ///// <summary>客先納期終了</summary>
            //public DateTime Ed_DeliGdsCmpltDueDate
            //{
            //    get { return _ed_DeliGdsCmpltDueDate; }
            //    set { _ed_DeliGdsCmpltDueDate = value; }
            //}
            /// <summary>入荷状況</summary>
            public ArrivalState ArrivalStateDiv
            {
                get { return _arrivalStateDiv; }
                set { _arrivalStateDiv = value; }
            }
            ///// <summary>入荷日付開始</summary>
            //public DateTime St_ArrivalDate
            //{
            //    get { return _st_ArrivalDate; }
            //    set { _st_ArrivalDate = value; }
            //}
            ///// <summary>入荷日付終了</summary>
            //public DateTime Ed_ArrivalDate
            //{
            //    get { return _ed_ArrivalDate; }
            //    set { _ed_ArrivalDate = value; }
            //}
            /// <summary>商品番号</summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>商品名称(表示用)</summary>
            public string GoodsName
            {
                get { return _goodsName; }
                set { _goodsName = value; }
            }
            /// <summary>商品名称(検索用)</summary>
            public string GoodsNameForSearch
            {
                get { return _goodsNameForSearch; }
                set { _goodsNameForSearch = value; }
            }
            /// <summary>メーカーコード</summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>メーカー名称</summary>
            public string MakerName
            {
                get { return _makerName; }
                set { _makerName = value; }
            }
            /// <summary>担当者コード</summary>
            public string SalesEmployeeCode
            {
                get { return _salesEmployeeCode; }
                set { _salesEmployeeCode = value; }
            }
            /// <summary>担当者名称</summary>
            public string SalesEmployeeName
            {
                get { return _salesEmployeeName; }
                set { _salesEmployeeName = value; }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START

            public int ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
            public string ClaimName
            {
                get { return _claimName; }
                set { _claimName = value; }
            }
            public int AcpOdrStateDiv
            {
                get { return _acpOdrStateDiv; }
                set { _acpOdrStateDiv = value; }
            }
            public string FullModel
            {
                get { return _fullModel; }
                set { _fullModel = value; }
            }
            public DateTime St_SearchSlipDate
            {
                get { return _st_SearchSlipDate; }
                set { _st_SearchSlipDate = value; }
            }
            public DateTime Ed_SearchSlipDate
            {
                get { return _ed_SearchSlipDate; }
                set { _ed_SearchSlipDate = value; }
            }
            public string St_SalesSlipNum
            {
                get { return _st_SalesSlipNum; }
                set { _st_SalesSlipNum = value; }
            }
            public string Ed_SalesSlipNum
            {
                get { return _ed_SalesSlipNum; }
                set { _ed_SalesSlipNum = value; }
            }
            public string SalesInputCode
            {
                get { return _salesInputCode; }
                set { _salesInputCode = value; }
            }
            public string SalesInputName
            {
                get { return _salesInputName; }
                set { _salesInputName = value; }
            }
            public string FrontEmployeeCd
            {
                get { return _frontEmployeeCd; }
                set { _frontEmployeeCd = value; }
            }
            public string FrontEmployeeNm
            {
                get { return _frontEmployeeNm; }
                set { _frontEmployeeNm = value; }
            }
            public bool GoodsNmVagurSrch
            {
                get { return _goodsNmVagueSrch; }
                set { _goodsNmVagueSrch = value; }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public AcptAnOdrRemainRefSearchPara()
            {
            }
        }
        # endregion

        #region■Public Methods
        /// <summary>
		/// 呼出制御処理
		/// </summary>
		/// <param name="owner">呼出元オブジェクト</param>
		public new DialogResult ShowDialog( IWin32Window owner )
		{
            if ( this.MaxSelectCount > 0 )
            {
                this._displayType = DisplayType.DisplayAndSelect;
            }
            else
            {
                this._displayType = DisplayType.DisplayOnly;
            }

            if ( this._parentSetCndtn == null )
            {
                this._parentSetCndtn = new AcptAnOdrRemainRefSearchPara();
            }

            // DEL 2009/06/08 ------>>>
            // 初期値を未計上分(2)へ
            //this.ce_ArrivalStateDiv.SelectedIndex = 2;
            //this._defaultSelectedValue = 2;
            // DEL 2009/06/08 ------<<<

            // ADD 2009/06/08 ------>>>
            // 初期値を全て(0)に変更
            this.ce_ArrivalStateDiv.SelectedIndex = 0;
            this._defaultSelectedValue = 0;
            // ADD 2009/06/08 ------<<<
            
		    return base.ShowDialog(owner);
		}
        ///// <summary>
        ///// 呼出制御処理（表示のみ）
        ///// </summary>
        ///// <param name="owner"></param>
        ///// <param name="maxSelectCount"></param>
        ///// <param name="autoSearch"></param>
        ///// <returns></returns>
        //public DialogResult ShowDialog( IWin32Window owner, bool autoSearch )
        //{
        //    this._displayType = DisplayType.DisplayOnly;
        //    this._parentSetCndtn = new AcptAnOdrRemainRefCndtn();
        //    this._autoSearch = autoSearch;

        //    return base.ShowDialog( owner );
        //}
        ///// <summary>
        ///// 呼出制御処理（選択可能）
        ///// </summary>
        ///// <param name="owner"></param>
        ///// <param name="maxSelectCount"></param>
        ///// <param name="autoSearch"></param>
        ///// <returns></returns>
        //public DialogResult ShowDialog( IWin32Window owner, bool autoSearch, int maxSelectCount )
        //{
        //    this._displayType = DisplayType.DisplayAndSelect;
        //    this._detailForm.MaxSelectCount = maxSelectCount;
        //    this._parentSetCndtn = new AcptAnOdrRemainRefCndtn();
        //    this._autoSearch = autoSearch;

        //    return base.ShowDialog( owner );
        //}
        ///// <summary>
        ///// 呼出制御処理（選択可能）
        ///// </summary>
        ///// <param name="owner"></param>
        ///// <param name="maxSelectCount"></param>
        ///// <param name="autoSearch"></param>
        ///// <returns></returns>
        //public DialogResult ShowDialog( IWin32Window owner, bool autoSearch, int maxSelectCount, AcptAnOdrRemainRefCndtn searchCndtn )
        //{
        //    this._displayType = DisplayType.DisplayAndSelect;
        //    this._detailForm.MaxSelectCount = maxSelectCount;

        //    if ( searchCndtn == null )
        //    {
        //        this._parentSetCndtn = new AcptAnOdrRemainRefCndtn();
        //    }
        //    else
        //    {
        //        this._parentSetCndtn = searchCndtn;
        //    }
        //    this._autoSearch = autoSearch;

        //    return base.ShowDialog( owner );
        //}
        #endregion

        # region ■ 呼び出し元ＰＧ受け渡し用 ■
        /// <summary>起動時自動検索開始</summary>
        private bool _autoSearch;
        ///// <summary>拠点コード</summary>
        //private string _sectionCode;
        ///// <summary>拠点ガイド名称</summary>
        //private string _sectionGuidNm;
        ///// <summary>得意先コード</summary>
        //private int _customerCode;
        ///// <summary>得意先名称</summary>
        //private string _customerName;
        ///// <summary>開始受注日</summary>
        //private DateTime _st_SalesDate;
        ///// <summary>終了受注日</summary>
        //private DateTime _ed_SalesDate;
        ///// <summary>拠点コード固定フラグ</summary>
        //private bool _sectionCodeFix;
        /// <summary>得意先コード固定フラグ</summary>
        private bool _customerCodeFix;

        
        ///// <summary>（検索条件）拠点コード　プロパティ</summary>
        //public string SectionCode
        //{
        //    get { return _sectionCode; }
        //    set { _sectionCode = value; }
        //}
        ///// <summary>（検索条件）拠点ガイド名称　プロパティ</summary>
        //public string SectionGuidNm
        //{
        //    get { return _sectionGuidNm; }
        //    set { _sectionGuidNm = value; }
        //}
        ///// <summary>（検索条件）得意先コード　プロパティ</summary>
        //public int CustomerCode
        //{
        //    get { return _customerCode; }
        //    set { _customerCode = value; }
        //}
        ///// <summary>（検索条件）得意先名称　プロパティ</summary>
        //public string CustomerName
        //{
        //    get { return _customerName; }
        //    set { _customerName = value; }
        //}
        ///// <summary>（検索条件）開始受注日　プロパティ</summary>
        //public DateTime St_SalesDate
        //{
        //    get { return _st_SalesDate; }
        //    set { _st_SalesDate = value; }
        //}
        ///// <summary>（検索条件）終了受注日　プロパティ</summary>
        //public DateTime Ed_SalesDate
        //{
        //    get { return _ed_SalesDate; }
        //    set { _ed_SalesDate = value; }
        //}
        ///// <summary>（検索ＵＩ制御）拠点コード固定フラグ</summary>
        //public bool SectionCodeFix
        //{
        //    get { return _sectionCodeFix; }
        //    set { _sectionCodeFix = value; }
        //}
        /// <summary>（検索ＵＩ制御）得意先コード固定フラグ</summary>
        public bool CustomerCodeFix
        {
            get { return _customerCodeFix; }
            set { _customerCodeFix = value; }
        }
        /// <summary>条件項目圧縮</summary>
        public bool Standard_UGroupBox_Expand
        {
            get { return this.Standard_UGroupBox.Expanded; }
            set { this.Standard_UGroupBox.Expanded = value; }
        }
        /// <summary>抽出条件</summary>
        public AcptAnOdrRemainRefSearchPara SearchCndtn
        {
            get 
            {
                if ( this._parentSetCndtn == null )
                {
                    this._parentSetCndtn = new AcptAnOdrRemainRefSearchPara();
                }
                return this._parentSetCndtn; 
            }
            set { this._parentSetCndtn = value; }
        }
        /// <summary>選択可能件数</summary>
        public int MaxSelectCount
        {
            get { return this._detailForm.MaxSelectCount; }
            set { this._detailForm.MaxSelectCount = value; }
        }
        /// <summary>自動抽出開始</summary>
        public bool AutoSearch
        {
            get { return _autoSearch; }
            set { _autoSearch = value; }
        }
        # endregion ■ 呼び出し元ＰＧ受け渡し用 ■

        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DCJUT04110UA ()
        {
            InitializeComponent();

            // 変数初期化
            this._acptAnOdrRemainRefAcs = new AcptAnOdrRemainRefAcs();
            this._acptAnOdrRemainRefAcs.SelectedDataChange += new EventHandler( AcptAnOdrRemainRefAcs_SelectedDataChange );

            this._detailForm = new DCJUT04110UB(this._acptAnOdrRemainRefAcs);

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];
            this._previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Preview"];
            this._pursuitButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Pursuit"];
            this._controlScreenSkin = new ControlScreenSkin();

            this._detailForm.StatusBarMessageSetting += new DCJUT04110UB.SettingStatusBarMessageEventHandler( this.SetStatusBarMessage );
            this._acptAnOdrRemainRefAcs.StatusBarMessageSetting += new AcptAnOdrRemainRefAcs.SettingStatusBarMessageEventHandler( this.SetStatusBarMessage );
            //this._detailForm.CloseMain += new DCJUT04110UB.CloseMainEventHandler( this.CloseForm );
            //this._detailForm.SetMainDialogResult += new DCJUT04110UB.SetDialogResEventHandler( this.SetDialogRes );

            // 表示モード初期化（表示のみ）
            this._displayType = DisplayType.DisplayOnly;

            // アクセスクラス生成
            this._secInfoSetAcs = new SecInfoSetAcs();
            //this._subSectionAcs = new SubSectionAcs();
            //this._minSectionAcs = new MinSectionAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._dateGetAcs = DateGetAcs.GetInstance(); // ADD 2009/04/03

            // 画面入力前回値退避用
            this._inputCndtnCache = new AcptAnOdrRemainRefCndtn();

            //// 起動元ＰＧ受け渡しプロパティ
            //this._sectionCode = string.Empty;
            //this._sectionGuidNm = string.Empty;
            //this._customerCode = 0;
            //this._customerName = string.Empty;
            //this._st_SalesDate = DateTime.Today;
            //this._ed_SalesDate = DateTime.Today;


            // パラメータ初期値
            if ( this._parentSetCndtn == null )
            {
                this._parentSetCndtn = new AcptAnOdrRemainRefSearchPara();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 仕様変更の為、削除
                //this._parentSetCndtn.ArrivalStateDiv = ArrivalState.NonArrival;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            
            // 受注追跡照会・詳細表示　不可
            this._pursuitButton.SharedProps.Enabled = false;

            // Load済みフラグ（Form_LoadまたはInitialSearchにてtrueにする）
            _loaded = false;
        }

        /// <summary>
        /// アクセスクラス　データ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AcptAnOdrRemainRefAcs_SelectedDataChange ( object sender, EventArgs e )
        {
            int count = this._acptAnOdrRemainRefAcs.GetRowCountOfSelected();

            if ( count == 0 )
            {
                // 確定　不可
                this._decisionButton.SharedProps.Enabled = false;
            }
            else
            {
                // 確定　可能
                this._decisionButton.SharedProps.Enabled = true;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // single選択モード動作
                if ( MaxSelectCount == 1 )
                {
                    SetDialogRes( DialogResult.OK );
                    this.Close();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
        }

        #endregion

        # region ■ フォームロードイベント ■
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCJUT04110UA_Load( object sender, EventArgs e )
		{
            // 初期化処理
            InitializeOnLoad();
　      }
        /// <summary>
        /// フォームロード時の初期化処理
        /// </summary>
        private void InitializeOnLoad()
        {
            // 既にLoad処理済みならば処理しない
            if ( _loaded )
            {
                return;
            }

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            //this.Form1_Fill_Panel.Visible = false;

            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add( this.Standard_UGroupBox.Name );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA ADD START
            excCtrlNm.Add(this.ultraExpandableGroupBox1.Name);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA ADD END
            //excCtrlNm.Add(this.Detail_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl( excCtrlNm );

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin( this );
            this._controlScreenSkin.SettingScreenSkin( this._detailForm );

            // MAKON01320UB を、panel_Detailを親としたコントロールにする

            //bool select = ( this._displayType == DisplayType.DisplayAndSelect ) ? true : false;
            bool select = false;
            if ( this._displayType == DisplayType.DisplayAndSelect && this.MaxSelectCount > 1 )
            {
                select = true;
            }

            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 自拠点コードを取得する
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 拠点オプション有無を取得する
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION ) > 0);
            // 本社/拠点情報を取得する
            this._mainOfficeFunc = this._acptAnOdrRemainRefAcs.IsMainOfficeFunc();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            // 売上全体設定を取得
            // TODO このSearchAllは将来的にSearchメソッドに変わる可能性あり。
            int status;
            ArrayList retSalesTtlSt;
            SalesTtlSt sale;
            this._salesTtlStAcs = new SalesTtlStAcs();
            //int status = _salesTtlStAcs.Read(out sale, this._enterpriseCode);
            status = _salesTtlStAcs.SearchAll(out retSalesTtlSt, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                bool found = false;
                foreach (SalesTtlSt salesTtlSt in retSalesTtlSt)
                {
                    if (salesTtlSt.SectionCode.Trim() == this._loginSectionCode.Trim())
                    //if (sale.SectionCode.Trim() == this._loginSectionCode.Trim())
                    {
                        // 0:する　1:しない　 2:必須
                        this._inpAgentDispDiv = salesTtlSt.InpAgentDispDiv;
                        found = true;
                        break;
                    }
                }

                // ログイン拠点コードがなければ全社設定をチェック（自拠点が優先のため２回）
                if (!found)
                {
                    foreach (SalesTtlSt salesTtlSt in retSalesTtlSt)
                    {
                        if (salesTtlSt.SectionCode.Trim() == "00")
                        {
                            // 0:する　1:しない　 2:必須
                            this._inpAgentDispDiv = salesTtlSt.InpAgentDispDiv;
                            break;
                        }
                    }
                }
            }
            this.ce_ArrivalStateDiv.Text = "全て";

            // 締め日取得処理

            // 自拠点の前回締め日情報を取得
            TotalDayCalculator tCalcAcs = TotalDayCalculator.GetInstance();
            // 締日取得前初期処理
            status = tCalcAcs.InitializeHisMonthlyAccRec();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 今回および前回の締め日/月を取得(月と日は異なる場合がある)
                status = tCalcAcs.GetHisTotalDayMonthlyAccRec(this._loginSectionCode, out _prevTotalDay, out _currentTotalDay, out _prevTotalMonth, out _currentTotalMonth);
                // 2008.11.17 modify start [7914]
                if (status != 0 || _prevTotalDay == DateTime.MinValue || _prevTotalDay > DateTime.Today)
                {
                    // 締め日が設定されていない
                    //this._parentSetCndtn.St_SalesDate = DateTime.MinValue;
                    //this._parentSetCndtn.Ed_SalesDate = DateTime.MinValue;
                    this._parentSetCndtn.St_SalesDate = DateTime.Today.AddMonths(-3).AddDays(1);
                    this._parentSetCndtn.Ed_SalesDate = DateTime.Today;
                    // 2008.11.17 modify end [7914]
                }
                else
                {
                    // 但し、（前回月次処理日＋１日）＞（当日）の時、終了売上日＝（前回月次処理日＋１日）とします。
                    if (_prevTotalDay.AddDays(1).CompareTo(DateTime.Now) > 0)
                    {
                        this._parentSetCndtn.St_SalesDate = _prevTotalDay.AddDays(1); // 前回締処理日 + 1
                        this._parentSetCndtn.Ed_SalesDate = _prevTotalDay.AddDays(1); // 前回締処理日 + 1
                    }
                    else
                    {
                        this._parentSetCndtn.St_SalesDate = _prevTotalDay.AddDays(1); // 前回締処理日 + 1
                        this._parentSetCndtn.Ed_SalesDate = DateTime.Now; // 当日
                    }
                }
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END
            // 発行者表示フラグセット
            this._acptAnOdrRemainRefAcs.InpAgentDispDiv = this._inpAgentDispDiv;

            this._detailForm.DisplayModeSetting(select, this._inpAgentDispDiv);
            this.panel_Detail.Controls.Add(this._detailForm);
            this._detailForm.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            this.uTabControl.Tabs[cTAB_PREVIEW].Visible = false;
            // 元に戻す処理
            this.ClearDisplayHeader();
            this.SetDisplayHeaderInfo();
            this._acptAnOdrRemainRefAcs.ClearTable();

            // 画面初期情報設定処理
            this.SetInitialInput();

            // （※Load処理済み扱いにする）
            _loaded = true;
        }
        # endregion ■ フォームロードイベント ■

        /// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        /// <remarks>
        /// <br>呼び出し元ＰＧから渡された抽出条件を初期表示セットする。</br>
        /// </remarks>
        private void SetInitialInput()
        {
            // ※条件がNULLならば初期化
            if ( _parentSetCndtn == null )
            {
                _parentSetCndtn = new AcptAnOdrRemainRefSearchPara();
            }

            // 拠点
            if ( _parentSetCndtn.SectionCode != string.Empty )
            {
                this.tEdit_SectionCode.Text = _parentSetCndtn.SectionCode.Trim();
                this.uLabel_SectionNm.Text = _parentSetCndtn.SectionName;
            }
            //// 部門
            //if ( _parentSetCndtn.SubSectionCode > 0 )
            //{
            //    this.tne_SubSectionCode.SetInt( _parentSetCndtn.SubSectionCode );
            //    this.lb_SubSectionName.Text = _parentSetCndtn.SubSectionName;
            //}
            //// 課
            //if ( _parentSetCndtn.MinSectionCode > 0 )
            //{
            //    this.tne_MinSectionCode.SetInt( _parentSetCndtn.MinSectionCode );
            //    this.lb_MinSectionName.Text = _parentSetCndtn.MinSectionName;
            //}
            // 得意先
            if ( _parentSetCndtn.CustomerCode > 0 )
            {
                this.tNedit_CustomerCode.SetInt( _parentSetCndtn.CustomerCode );
                this.uLabel_CustomerName.Text = _parentSetCndtn.CustomerName;

                // 得意先固定
                if ( _customerCodeFix )
                {
                    this.tNedit_CustomerCode.Enabled = false;
                    this.ub_CustomerGuide.Enabled = false;
                }
            }
            //// 得意先注番
            //if ( _parentSetCndtn.PartySlipNumDtl != string.Empty )
            //{
            //    this.te_PartySlipNumDtl.Text = _parentSetCndtn.PartySlipNumDtl;
            //}
            // 受注日
            if (_parentSetCndtn.St_SalesDate != DateTime.MinValue)
            {
                this.tde_St_SalesDate.SetDateTime(_parentSetCndtn.St_SalesDate);
            }
            if (_parentSetCndtn.Ed_SalesDate != DateTime.MinValue)
            {
                this.tde_Ed_SalesDate.SetDateTime(_parentSetCndtn.Ed_SalesDate);
            }
            // 2008.11.17 del start [7914]
            // 仕入日
            //if (_parentSetCndtn.St_SearchSlipDate != DateTime.MinValue)
            //{
            //    this.tde_St_ArrivalDate.SetDateTime(_parentSetCndtn.St_SearchSlipDate);
            //}
            //if (_parentSetCndtn.Ed_SearchSlipDate != DateTime.MinValue)
            //{
            //    this.tde_Ed_ArrivalDate.SetDateTime(_parentSetCndtn.Ed_SearchSlipDate);
            //}
            //this.tde_St_ArrivalDate.SetDateTime(DateTime.Now);  // 仕入日
            //this.tde_Ed_ArrivalDate.SetDateTime(DateTime.Now);
            // 2008.11.17 del end [7914]
            //// 客先納期
            //if ( _parentSetCndtn.St_DeliGdsCmpltDueDate != DateTime.MinValue )
            //{
            //    this.tde_St_DeliGdsCmpltDueDate.SetDateTime( _parentSetCndtn.St_DeliGdsCmpltDueDate );
            //}
            //if ( _parentSetCndtn.Ed_DeliGdsCmpltDueDate != DateTime.MinValue )
            //{
            //    this.tde_Ed_DeliGdsCmpltDueDate.SetDateTime( _parentSetCndtn.Ed_DeliGdsCmpltDueDate );
            //}
            //// 入荷状況
            //this.ce_ArrivalStateDiv.SelectedIndex = (int)_parentSetCndtn.ArrivalStateDiv;
            //// 入荷日
            //if ( _parentSetCndtn.St_ArrivalDate != DateTime.MinValue )
            //{
            //    this.tde_St_ArrivalDate.SetDateTime( _parentSetCndtn.St_ArrivalDate );
            //}
            //if ( _parentSetCndtn.Ed_ArrivalDate != DateTime.MinValue )
            //{
            //    this.tde_Ed_ArrivalDate.SetDateTime( _parentSetCndtn.Ed_ArrivalDate );
            //}
            // 品番
            if ( _parentSetCndtn.GoodsNo != string.Empty )
            {
                this.te_GoodsNo.Text = _parentSetCndtn.GoodsNo;
                this.lb_GoodsNameView.Text = _parentSetCndtn.GoodsName; // 品名(表示用)
            }
            // 品名
            if ( _parentSetCndtn.GoodsNameForSearch != string.Empty )
            {
                this.te_GoodsName.Text = _parentSetCndtn.GoodsNameForSearch;    // 品名(検索用)
            }
            // メーカー
            if ( _parentSetCndtn.GoodsMakerCd > 0 )
            {
                this.tne_GoodsMakerCd.SetInt( _parentSetCndtn.GoodsMakerCd );
                this.lb_MakerName.Text = _parentSetCndtn.MakerName;
            }
            // 担当者
            if ( _parentSetCndtn.SalesEmployeeCode != string.Empty )
            {
                this.te_SalesEmployeeCode.Text = _parentSetCndtn.SalesEmployeeCode;
                this.lb_SalesEmployeeName.Text = _parentSetCndtn.SalesEmployeeName;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            // 伝票番号
            if (_parentSetCndtn.St_SalesSlipNum != string.Empty)
            {
                this.tEdit_SalesSlipNum_St.Text = _parentSetCndtn.St_SalesSlipNum;
            }
            if (_parentSetCndtn.Ed_SalesSlipNum != string.Empty)
            {
                this.tEdit_SalesSlipNum_Ed.Text = _parentSetCndtn.Ed_SalesSlipNum;
            }
            // 請求先
            if (_parentSetCndtn.ClaimCode > 0)
            {
                this.tNedit_ClaimCode.SetInt(_parentSetCndtn.ClaimCode);
                this.uLabel_ClaimName.Text = _parentSetCndtn.ClaimName;
            }
            // 発行者
            // 売上全体設定で発行者表示区分が「する」以外の場合は飛ばす
            if (this._inpAgentDispDiv == INP_AGT_DISP)
            {
                if (_parentSetCndtn.SalesInputCode != string.Empty)
                {
                    this.tEdit_SalesInputCode.Text = _parentSetCndtn.SalesInputCode;
                    this.uLabel_SalesInputName.Text = _parentSetCndtn.SalesInputName;
                }
            }
            else
            {
                // 画面上から消してしまう
                this.tEdit_SalesInputCode.Visible = false;
                this.uLabel_SalesInputName.Visible = false;
                this.uButton_SalesInputGuide.Visible = false;
                this.uLabel_SalesInputTitle.Visible = false;
            }
            // 受注者
            if (_parentSetCndtn.FrontEmployeeCd != string.Empty)
            {
                this.tEdit_FrontEmployeeCode.Text = _parentSetCndtn.FrontEmployeeCd;
                this.uLabel_FrontEmployeeName.Text = _parentSetCndtn.FrontEmployeeNm;
            }
            // 絞込型式
            if (_parentSetCndtn.FullModel != string.Empty)
            {
                this.tEdit_FullModel.Text = _parentSetCndtn.FullModel;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

        }

        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplayHeader()
        {
			this.tEdit_SectionCode.Clear();					// 拠点
            this.uLabel_SectionNm.Text = string.Empty;      
            //this.tne_SubSectionCode.Clear();            // 部門
            //this.lb_SubSectionName.Text = string.Empty;
            //this.tne_MinSectionCode.Clear();            // 課
            //this.lb_MinSectionName.Text = string.Empty;
            this.tNedit_CustomerCode.Clear();              // 得意先コード
            this.uLabel_CustomerName.Text = string.Empty;   // 得意先名
            //this.te_PartySlipNumDtl.Clear();            // 得意先注番

            // 2008.11.17 modify start [7914]
            // 自拠点の前回締め日情報を取得
            TotalDayCalculator tCalcAcs = TotalDayCalculator.GetInstance();
            // 締日取得前初期処理
            //status = tCalcAcs.InitializeHisMonthlyAccRec();
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            // 今回および前回の締め日/月を取得(月と日は異なる場合がある)
            int status = tCalcAcs.GetHisTotalDayMonthlyAccRec(this._loginSectionCode, out _prevTotalDay, out _currentTotalDay, out _prevTotalMonth, out _currentTotalMonth);
            // 2008.11.17 modify start [7914]
            if (status != 0 || _prevTotalDay == DateTime.MinValue || _prevTotalDay > DateTime.Today)
            {
                // 締め日が設定されていない
                this._parentSetCndtn.St_SalesDate = DateTime.Today.AddMonths(-3).AddDays(1);
                this._parentSetCndtn.Ed_SalesDate = DateTime.Today;
            }
            else
            {
                // 但し、（前回月次処理日＋１日）＞（当日）の時、終了売上日＝（前回月次処理日＋１日）とします。
                if (_prevTotalDay.AddDays(1).CompareTo(DateTime.Now) > 0)
                {
                    this._parentSetCndtn.St_SalesDate = _prevTotalDay.AddDays(1); // 前回締処理日 + 1
                    this._parentSetCndtn.Ed_SalesDate = _prevTotalDay.AddDays(1); // 前回締処理日 + 1
                }
                else
                {
                    this._parentSetCndtn.St_SalesDate = _prevTotalDay.AddDays(1); // 前回締処理日 + 1
                    this._parentSetCndtn.Ed_SalesDate = DateTime.Now; // 当日
                }
            }
            //}
            this.tde_St_SalesDate.SetDateTime(this._parentSetCndtn.St_SalesDate);
            this.tde_Ed_SalesDate.SetDateTime(this._parentSetCndtn.Ed_SalesDate);
            //this.tde_St_SalesDate.SetDateTime( DateTime.Now );  // 受注日
            //this.tde_Ed_SalesDate.SetDateTime( DateTime.Now );

            this.tde_St_ArrivalDate.Clear();//.SetDateTime(DateTime.Now);  // 仕入日
            this.tde_Ed_ArrivalDate.Clear();//.SetDateTime(DateTime.Now);
            // 2008.11.17 modify end [7914]
            //this.tde_St_DeliGdsCmpltDueDate.Clear();    // 客先納期
            //this.tde_Ed_DeliGdsCmpltDueDate.Clear();
            //this.ce_ArrivalStateDiv.SelectedIndex = 2;  // 入荷状況（2:未入荷）
            // 入荷状況をデフォルトにセット(ShowDialogで呼び出された場合は2, それ以外は0)
            this.ce_ArrivalStateDiv.SelectedIndex = _defaultSelectedValue;
            //this.tde_St_ArrivalDate.Clear();            // 入荷日
            //this.tde_Ed_ArrivalDate.Clear();
            this.te_GoodsNo.Clear();                    // 商品番号
            this.te_GoodsName.Clear();                  // 商品名称
            this.tne_GoodsMakerCd.Clear();              // メーカーコード
            this.lb_MakerName.Text = "";                // メーカー名
            this.te_SalesEmployeeCode.Clear();          // 担当者
            this.lb_SalesEmployeeName.Text = "";        // 担当者名

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            this.tNedit_ClaimCode.Clear();                          // 請求先コード
            this.uLabel_ClaimName.Text = string.Empty;              // 請求先名
            this.tEdit_SalesSlipNum_St.Clear();                     // 伝票番号(開始)
            this.tEdit_SalesSlipNum_Ed.Clear();                     // 伝票番号(終了)
            this.tEdit_SalesInputCode.Clear();                      // 発行者コード
            this.uLabel_SalesInputName.Text = string.Empty;         // 発行者名
            this.tEdit_FrontEmployeeCode.Clear();                   // 受注者コード
            this.uLabel_FrontEmployeeName.Text = string.Empty;      // 受注者名
            this.tEdit_FullModel.Clear();                           // 絞込型式
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

            this.ChangeDecisionButtonEnable(false);

            this.timer_InitialSetFocus.Enabled = true;

            // 受注追跡照会・詳細表示　不可
            this._pursuitButton.SharedProps.Enabled = false;
        }

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayHeaderInfo()
        {
            // 受注日
            // 2008.11.17 modify start [7914]
			//this.tde_St_SalesDate.SetDateTime(DateTime.Now);
			//this.tde_Ed_SalesDate.SetDateTime(DateTime.Now);
            this.tde_St_SalesDate.SetDateTime(this._parentSetCndtn.St_SalesDate);
            this.tde_Ed_SalesDate.SetDateTime(this._parentSetCndtn.Ed_SalesDate);
            // 2008.11.17 modify end [7914]
            this._inputCndtnCache.St_SalesDate = TDateTime.DateTimeToLongDate(DateTime.Now);
            this._inputCndtnCache.Ed_SalesDate = TDateTime.DateTimeToLongDate(DateTime.Now);

            // 拠点設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA MODIFY START
            this.tEdit_SectionCode.Text = this._loginSectionCode.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA MODIFY END
            this._inputCndtnCache.SectionCode = this._loginSectionCode;

            SecInfoSet secInfoSet;
			int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
			}
        }

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA MODIFY START
			this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA MODIFY END
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
			this._previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            this._pursuitButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;

			//imageList16
            this.ub_SectionGuide.ImageList = this._imageList16;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA DEL START
            //this.ub_SubSectionGuide.ImageList = this._imageList16;
            //this.ub_MinSectionGuide.ImageList = this._imageList16;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA DEL END
            this.ub_CustomerGuide.ImageList = this._imageList16;
            this.ub_GoodsMakerGuide.ImageList = this._imageList16;
            this.ub_GoodsGuide.ImageList = this._imageList16;
			this.ub_SalesEmployeeGuide.ImageList = this._imageList16;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA ADD START
            this.uButton_ClaimGuide.ImageList = this._imageList16;
            this.uButton_FrontEmployeeGuide.ImageList = this._imageList16;
            this.uButton_SalesInputGuide.ImageList = this._imageList16;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA ADD END

			//STAR1
            this.ub_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA DEL START
            //this.ub_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            //this.ub_MinSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA DEL END
            this.ub_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.ub_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.ub_GoodsGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.ub_SalesEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA ADD START
            this.uButton_ClaimGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_FrontEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesInputGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA ADD END

			if (this._displayType == DisplayType.DisplayOnly)
			{
				this._decisionButton.SharedProps.Visible = false;
			}
			else
			{
				this._decisionButton.SharedProps.Visible = true;
			}

			this._printButton.SharedProps.Enabled = false;
			this._previewButton.SharedProps.Enabled = false;
		}


        /// <summary>
        /// 終了項目値自動設定処理(TEdit)
        /// </summary>
        /// <param name="startEdit">開始日付項目TEdit</param>
        /// <param name="endEdit">終了日付項目TEdit</param>
        private void AutoSetEndValue(TEdit startEdit, TEdit endEdit)
        {
            if (endEdit.Text == "")
            {
                endEdit.Text = startEdit.Text;
            }
        }

        /// <summary>
        /// 読込条件パラメータ設定処理
        /// </summary>
        /// <return> 読込条件パラメータクラス </return>
        /// <remarks>
        /// <br>画面コントロール入力値から検索条件を生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtn GetSearchParaFromDisplay()
        {
            AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn = new AcptAnOdrRemainRefCndtn();

            acptAnOdrRemainRefCndtn.EnterpriseCode = this._enterpriseCode;
            string secCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
            if (secCode == "00")
            {
                acptAnOdrRemainRefCndtn.SectionCode = string.Empty;
            }
            else
            {
                acptAnOdrRemainRefCndtn.SectionCode = secCode;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA DEL START
            //acptAnOdrRemainRefCndtn.SubSectionCode = this.tne_SubSectionCode.GetInt();
            //acptAnOdrRemainRefCndtn.MinSectionCode = this.tne_MinSectionCode.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA DEL END
            acptAnOdrRemainRefCndtn.CustomerCode = this.tNedit_CustomerCode.GetInt();
            acptAnOdrRemainRefCndtn.SalesInputCode = this.tEdit_SalesInputCode.Text;//string.Empty;      // 未使用
            acptAnOdrRemainRefCndtn.FrontEmployeeCd = this.tEdit_FrontEmployeeCode.Text;//string.Empty;     // 未使用
            if (this._inpAgentDispDiv == INP_AGT_DISP)
            {
                acptAnOdrRemainRefCndtn.SalesEmployeeCd = this.te_SalesEmployeeCode.Text;
            }
            else
            {
                acptAnOdrRemainRefCndtn.SalesEmployeeCd = string.Empty;
            }
            acptAnOdrRemainRefCndtn.St_SalesDate = this.tde_St_SalesDate.GetLongDate();//GetDateTime();
            acptAnOdrRemainRefCndtn.Ed_SalesDate = this.tde_Ed_SalesDate.GetLongDate();//GetDateTime();
            acptAnOdrRemainRefCndtn.GoodsMakerCd = this.tne_GoodsMakerCd.GetInt();
            //acptAnOdrRemainRefCndtn.GoodsNo = this.te_GoodsNo.Text;

            // 2008.10.14 add start
            int searchType;
            string goodsNo = this.te_GoodsNo.Text.Trim();

            if (goodsNo.Trim().Length > 0)
            {
                int targetIndex = goodsNo.IndexOf("*");
                if (targetIndex == -1)
                {
                    // 完全一致
                    acptAnOdrRemainRefCndtn.GoodsNoSrchTyp = 0;
                    acptAnOdrRemainRefCndtn.GoodsNo = goodsNo;
                }
                else if (goodsNo.StartsWith("*") && goodsNo.EndsWith("*"))
                {
                    // 曖昧検索
                    acptAnOdrRemainRefCndtn.GoodsNoSrchTyp = 3;
                    acptAnOdrRemainRefCndtn.GoodsNo = goodsNo.Replace("*", "");
                }
                else if (goodsNo.EndsWith("*"))
                {
                    // 前方一致
                    acptAnOdrRemainRefCndtn.GoodsNoSrchTyp = 1;
                    acptAnOdrRemainRefCndtn.GoodsNo = goodsNo.Replace("*", "");
                }
                else if (goodsNo.StartsWith("*"))
                {
                    // 後方一致
                    acptAnOdrRemainRefCndtn.GoodsNoSrchTyp = 2;
                    acptAnOdrRemainRefCndtn.GoodsNo = goodsNo.Replace("*", "");
                }
            }
            else
            {
                acptAnOdrRemainRefCndtn.GoodsNoSrchTyp = 0;
                acptAnOdrRemainRefCndtn.GoodsNo = string.Empty;
            }
            // 2008.10.14 add end
            
            //acptAnOdrRemainRefCndtn.GoodsName = this.te_GoodsName.Text;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA DEL START
            //acptAnOdrRemainRefCndtn.PartySlipNumDtl = this.te_PartySlipNumDtl.Text;
            //acptAnOdrRemainRefCndtn.St_DeliGdsCmpltDueDate = this.tde_St_DeliGdsCmpltDueDate.GetDateTime();
            //acptAnOdrRemainRefCndtn.Ed_DeliGdsCmpltDueDate = this.tde_Ed_DeliGdsCmpltDueDate.GetDateTime();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA DEL END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA MODIFY START
            //acptAnOdrRemainRefCndtn.ArrivalStateDiv = this.ce_ArrivalStateDiv.SelectedIndex;
            acptAnOdrRemainRefCndtn.AcpOdrStateDiv = this.ce_ArrivalStateDiv.SelectedIndex;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA MODIFY END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA DEL START
            //acptAnOdrRemainRefCndtn.St_ArrivalDate = this.tde_St_ArrivalDate.GetDateTime();
            //acptAnOdrRemainRefCndtn.Ed_ArrivalDate = this.tde_Ed_ArrivalDate.GetDateTime();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA ADD START
            acptAnOdrRemainRefCndtn.ClaimCode = this.tNedit_ClaimCode.GetInt();
            acptAnOdrRemainRefCndtn.St_SalesSlipNum = this.tEdit_SalesSlipNum_St.Text.Trim();
            acptAnOdrRemainRefCndtn.Ed_SalesSlipNum = this.tEdit_SalesSlipNum_Ed.Text.Trim();
            acptAnOdrRemainRefCndtn.St_SalesDate = this.tde_St_SalesDate.GetLongDate();
            acptAnOdrRemainRefCndtn.Ed_SalesDate = this.tde_Ed_SalesDate.GetLongDate();
            acptAnOdrRemainRefCndtn.St_SearchSlipDate = this.tde_St_ArrivalDate.GetLongDate();
            acptAnOdrRemainRefCndtn.Ed_SearchSlipDate = this.tde_Ed_ArrivalDate.GetLongDate();

            // 入力された文字列から曖昧検索条件を割り出す
            string goodsName = this.te_GoodsName.Text.Trim();
            if (goodsName.Trim().Length > 0)
            {
                int targetIndex = goodsName.IndexOf("*");
                if (targetIndex == -1)
                {
                    // 完全一致
                    acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 0;
                    acptAnOdrRemainRefCndtn.GoodsName = goodsName;
                }
                else if (goodsName.StartsWith("*") && goodsName.EndsWith("*"))
                {
                    // 曖昧検索
                    acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 3;
                    acptAnOdrRemainRefCndtn.GoodsName = goodsName.Replace("*", "");
                }
                else if (goodsName.EndsWith("*"))
                {
                    // 前方一致
                    acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 1;
                    acptAnOdrRemainRefCndtn.GoodsName = goodsName.Replace("*", "");
                }
                else if (goodsName.StartsWith("*"))
                {
                    // 後方一致
                    acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 2;
                    acptAnOdrRemainRefCndtn.GoodsName = goodsName.Replace("*", "");
                }
            }
            else
            {
                acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 0;
                acptAnOdrRemainRefCndtn.GoodsName = string.Empty;
            }

            // 絞り込み検索
            // 2008.12.12 modify start [9101]
            //acptAnOdrRemainRefCndtn.FullModel = this.tEdit_FullModel.Text.Trim();
            // 入力された文字列から曖昧検索条件を割り出す
            string fullModel = this.tEdit_FullModel.Text.Trim();
            if (fullModel.Trim().Length > 0)
            {
                int targetIndex = fullModel.IndexOf("*");
                if (targetIndex == -1)
                {
                    // 完全一致
                    acptAnOdrRemainRefCndtn.FullModelSrchTyp = 0;
                    acptAnOdrRemainRefCndtn.FullModel = fullModel;
                }
                else if (fullModel.StartsWith("*") && fullModel.EndsWith("*"))
                {
                    // 曖昧検索
                    acptAnOdrRemainRefCndtn.FullModelSrchTyp = 3;
                    acptAnOdrRemainRefCndtn.FullModel = fullModel.Replace("*", "");
                }
                else if (fullModel.EndsWith("*"))
                {
                    // 前方一致
                    acptAnOdrRemainRefCndtn.FullModelSrchTyp = 1;
                    acptAnOdrRemainRefCndtn.FullModel = fullModel.Replace("*", "");
                }
                else if (fullModel.StartsWith("*"))
                {
                    // 後方一致
                    acptAnOdrRemainRefCndtn.FullModelSrchTyp = 2;
                    acptAnOdrRemainRefCndtn.FullModel = fullModel.Replace("*", "");
                }
            }
            else
            {
                acptAnOdrRemainRefCndtn.FullModelSrchTyp = 0;
                acptAnOdrRemainRefCndtn.FullModel = string.Empty;
            }
            // 2008.12.12 modify end [9101]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA ADD END

            return acptAnOdrRemainRefCndtn;
		}

        /// <summary>
        /// Valueチェック処理（int）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer	: 22018　鈴木 正臣</br>
        /// <br>Date		: 2007.10.15</br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                dest = Convert.ToInt32(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// 選択データ取得処理
        /// </summary>
        /// <returns></returns>
        public List<AcptAnOdrRemainRefData> GetSelectDataList ()
        {
            // 表示オンリーなら空のリストを返す
            if ( this._displayType == DisplayType.DisplayOnly )
            {
                return new List<AcptAnOdrRemainRefData>();
            }

            // アクセスクラスより、選択済みデータの一覧を取得
            if ( this.DialogResult == DialogResult.OK )
            {
                // OKの場合
                return this._acptAnOdrRemainRefAcs.GetRefDataListOfSelected();
            }
            else
            {
                // キャンセルの場合、空のリストを返す
                return new List<AcptAnOdrRemainRefData>();
            }
        }
       
        /// <summary>
        /// 画面終了処理
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        private Control CheckInputPara()
        {
            DateTime retDateTime;

            // --- DEL 2009/04/03 -------------------------------->>>>>
            ////-------------------------------------------------------------------------
            //// 入力日
            ////-------------------------------------------------------------------------
            //// 開始
            //if (this.tde_St_SalesDate.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tde_St_SalesDate.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tde_St_SalesDate.Focus();
            //        SetStatusBarMessage( this, MESSAGE_InvalidDate );
            //        return tde_St_SalesDate;
            //    }
            //}
            //else
            //{
            //    this.tde_St_SalesDate.Focus();
            //    SetStatusBarMessage( this, MESSAGE_NoInput );
            //    return tde_St_SalesDate;                
            //}
            //// 終了
            //if (this.tde_Ed_SalesDate.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tde_Ed_SalesDate.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tde_Ed_SalesDate.Focus();
            //        SetStatusBarMessage( this, MESSAGE_InvalidDate );
            //        return tde_Ed_SalesDate;
            //    }
            //}
            //else
            //{
            //    this.tde_Ed_SalesDate.Focus();
            //    SetStatusBarMessage( this, MESSAGE_NoInput );
            //    return tde_Ed_SalesDate;                
            //}

            //// --- CHG 2009/02/25 障害ID:7882対応------------------------------------------------------>>>>>
            ////// 開始＞終了エラー判定
            ////if (this.tde_St_ArrivalDate.LongDate > this.tde_Ed_ArrivalDate.LongDate)
            ////{
            ////    this.tde_St_ArrivalDate.Focus();
            ////    SetStatusBarMessage( this, MESSAGE_StartEndError );
            ////    return tde_St_ArrivalDate;
            ////}
            //if (this.tde_St_ArrivalDate.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tde_St_ArrivalDate.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tde_St_ArrivalDate.Focus();
            //        SetStatusBarMessage(this, MESSAGE_InvalidDate);
            //        return tde_St_ArrivalDate;
            //    }
            //}

            //if (this.tde_Ed_ArrivalDate.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tde_Ed_ArrivalDate.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tde_Ed_ArrivalDate.Focus();
            //        SetStatusBarMessage(this, MESSAGE_InvalidDate);
            //        return tde_Ed_ArrivalDate;
            //    }
            //}
            //// --- CHG 2009/02/25 髫懷ｮｳID:7882蟇ｾ蠢・-----------------------------------------------------<<<<<

            //if (this.tde_St_SalesDate.LongDate > this.tde_Ed_SalesDate.LongDate)
            //{
            //    this.tde_St_SalesDate.Focus();
            //    SetStatusBarMessage( this, MESSAGE_StartEndError );
            //    return tde_St_SalesDate;
            //}

            ////2008.11.17 add start [7914]
            //// 3ヵ月以上はエラー
            //if (this.tde_St_SalesDate.GetDateTime().AddMonths(3) < this.tde_Ed_SalesDate.GetDateTime())
            //{
            //    this.tde_St_SalesDate.Focus();
            //    // 2008.12.03 modify start [7914]
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        "受注日" + MESSAGE_RangeOverError, 0, MessageBoxButtons.OK);
            //    //SetStatusBarMessage(this, "受注日" + MESSAGE_RangeOverError);
            //    // 2008.12.03 modify end [7914]
            //    return tde_St_SalesDate;
            //}
            ////2008.11.17 add end [7914]
            // --- DEL 2009/04/03 -------------------------------->>>>>
            // --- ADD 2009/04/03 -------------------------------->>>>>
            DateGetAcs.CheckDateResult cdr;
            
            // 受注日
            cdr = this._dateGetAcs.CheckDate(ref this.tde_St_SalesDate, true);

            if (cdr != DateGetAcs.CheckDateResult.OK)
            {
                this.tde_St_SalesDate.Focus();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                MESSAGE_InvalidDate, 0, MessageBoxButtons.OK);
                return tde_St_SalesDate;
            }

            cdr = this._dateGetAcs.CheckDate(ref this.tde_Ed_SalesDate, true);

            if (cdr != DateGetAcs.CheckDateResult.OK)
            {
                this.tde_Ed_SalesDate.Focus();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                MESSAGE_InvalidDate, 0, MessageBoxButtons.OK);
                return tde_Ed_SalesDate;
            }

            if (this.tde_St_SalesDate.GetDateTime() != DateTime.MinValue
                && this.tde_Ed_SalesDate.GetDateTime() != DateTime.MinValue)
            {
                // 開始、終了の大小比較
                if (this.tde_St_SalesDate.GetLongDate() > this.tde_Ed_SalesDate.GetLongDate())
                {
                    this.tde_St_SalesDate.Focus();
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MESSAGE_StartEndError, 0, MessageBoxButtons.OK);
                    return tde_St_SalesDate;
                }
            }

            // 入力日
            cdr = this._dateGetAcs.CheckDate(ref this.tde_St_ArrivalDate, true);

            if (cdr != DateGetAcs.CheckDateResult.OK)
            {
                this.tde_St_ArrivalDate.Focus();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                MESSAGE_InvalidDate, 0, MessageBoxButtons.OK);
                return tde_St_ArrivalDate;
            }

            cdr = this._dateGetAcs.CheckDate(ref this.tde_Ed_ArrivalDate, true);

            if (cdr != DateGetAcs.CheckDateResult.OK)
            {
                this.tde_Ed_ArrivalDate.Focus();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                MESSAGE_InvalidDate, 0, MessageBoxButtons.OK);
                return tde_Ed_ArrivalDate;
            }

            if (this.tde_St_ArrivalDate.GetDateTime() != DateTime.MinValue
                && this.tde_Ed_ArrivalDate.GetDateTime() != DateTime.MinValue)
            {
                // 開始、終了の大小比較
                if (this.tde_St_ArrivalDate.GetLongDate() > this.tde_Ed_ArrivalDate.GetLongDate())
                {
                    this.tde_St_ArrivalDate.Focus();
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MESSAGE_StartEndError, 0, MessageBoxButtons.OK);
                    return tde_St_ArrivalDate;
                }
            }
            // --- ADD 2009/04/03 --------------------------------<<<<<

            // 伝票番号
            string start_str = this.tEdit_SalesSlipNum_St.Text.Trim();
            string end_Str = this.tEdit_SalesSlipNum_Ed.Text.Trim();
            if (!String.IsNullOrEmpty(start_str) && !String.IsNullOrEmpty(end_Str))
            {
                try
                {
                    int s = Int32.Parse(start_str);
                    int e = Int32.Parse(end_Str);

                    if (s > e)
                    {
                        this.tEdit_SalesSlipNum_Ed.Focus();
                        //TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            //MESSAGE_StartEndError, 0, MessageBoxButtons.OK);
                        //SetStatusBarMessage(this, MESSAGE_StartEndError); // DEL 2009/04/03
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        MESSAGE_StartEndError, 0, MessageBoxButtons.OK); // ADD 2009/04/03
                        return tEdit_SalesSlipNum_Ed;
                    }
                }
                catch
                {
                    // 何もしない
                }
            }

			return null;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 伝票検索実行処理（）
        /// </summary>
        private Control SearchDataForInitialSearch()
        {
            // 入力項目チェック処理
            Control control = this.CheckInputPara();

            if ( control != null )
            {
                return control;
            }

            // 読込条件パラメータクラス設定処理
            AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn = GetSearchParaForInitialSearch();
            SetInitialInput();

            // 検索処理呼び出し
            CallSearch( acptAnOdrRemainRefCndtn );

            return null;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /// <summary>
        /// 伝票検索実行処理
        /// </summary>
        private Control SearchData()
        {
            // 伝票番号の0埋め
            string slipNo = this.tEdit_SalesSlipNum_St.Text.Trim();
            if (!String.IsNullOrEmpty(slipNo))
            {
                this.tEdit_SalesSlipNum_St.Text = slipNo.PadLeft(9, '0');
            }
            slipNo = this.tEdit_SalesSlipNum_Ed.Text.Trim();
            if (!String.IsNullOrEmpty(slipNo))
            {
                this.tEdit_SalesSlipNum_Ed.Text = slipNo.PadLeft(9, '0');
            }

            // 入力項目チェック処理
            Control control = this.CheckInputPara();

            if ( control != null )
            {
                return control;
            }

            // 読込条件パラメータクラス設定処理
            AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn = this.GetSearchParaFromDisplay();

            // 検索処理呼び出し
            CallSearch( acptAnOdrRemainRefCndtn );

			return null;
        }
        /// <summary>
        /// 検索処理呼び出し
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn"></param>
        private int CallSearch( AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn )
        {
            bool setEnable = false;

            // 伝票情報読込・データセット格納処理
            int status = 0;
            SFCMN00299CA progressDialog = new SFCMN00299CA();
            try
            {
                progressDialog.Title = "データ読込";
                progressDialog.Message = "現在、データを読み込み中です。";
                progressDialog.Show();

                status = this._acptAnOdrRemainRefAcs.Search( acptAnOdrRemainRefCndtn );
            }
            finally
            {
                progressDialog.Close();
            }

            // 抽出結果により制御
            if ( status == 0 )
            {
                setEnable = this._detailForm.SetGridEnable();

                if ( setEnable == true )
                {
                    this._detailForm.uGrid_Details.Focus();
                    this._detailForm.timer_GridSetFocus.Enabled = true;
                }
                else
                {
                }

                // 受注追跡照会・詳細表示　可能
                this._pursuitButton.SharedProps.Enabled = true;
            }
            else
            {
                // 受注追跡照会・詳細表示　不可
                this._pursuitButton.SharedProps.Enabled = false;
            }

            // 明細の「全て選択」可・不可制御
            this._detailForm.SettingAllSelectEnable();


            return status;
        }

        /// <summary>
        /// 表示前抽出処理
        /// </summary>
        /// <returns>True: データあり／False: データなし</returns>
        public bool InitialSearch()
        {
            // フォームLoad処理
            // (※本来はForm_Loadイベントで行う初期化処理だが、
            //    このInitialSearch実行時はShowDialog前に処理する必要がある為、
            //    このタイミングで処理する)
            InitializeOnLoad();

            // 検索呼び出し
            AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn = GetSearchParaForInitialSearch();
            int status = CallSearch( acptAnOdrRemainRefCndtn );

            // 結果を返却（true:データあり）
            if ( status == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 初期検索用　抽出条件取得処理
        /// </summary>
        /// <returns></returns>
        private AcptAnOdrRemainRefCndtn GetSearchParaForInitialSearch()
        {
            // 呼び出し元からのパラメータが無ければ新規作成
            if ( _parentSetCndtn == null )
            {
                _parentSetCndtn = new AcptAnOdrRemainRefSearchPara();
            }

            AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn = new AcptAnOdrRemainRefCndtn();

            acptAnOdrRemainRefCndtn.EnterpriseCode = this._enterpriseCode;
            acptAnOdrRemainRefCndtn.SectionCode = _parentSetCndtn.SectionCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA DEL START
            //acptAnOdrRemainRefCndtn.SubSectionCode = _parentSetCndtn.SubSectionCode;
            //acptAnOdrRemainRefCndtn.MinSectionCode = _parentSetCndtn.MinSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA DEL END
            acptAnOdrRemainRefCndtn.CustomerCode = _parentSetCndtn.CustomerCode;
            if (this._inpAgentDispDiv == INP_AGT_DISP)
            {
                acptAnOdrRemainRefCndtn.SalesInputCode = _parentSetCndtn.SalesInputCode;
                //acptAnOdrRemainRefCndtn.SalesInputCode = string.Empty;      // 未使用
            }
            else
            {
                acptAnOdrRemainRefCndtn.SalesInputCode = string.Empty;
            }
            acptAnOdrRemainRefCndtn.FrontEmployeeCd = _parentSetCndtn.FrontEmployeeCd;//string.Empty;     // 未使用
            acptAnOdrRemainRefCndtn.SalesEmployeeCd = _parentSetCndtn.SalesEmployeeCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //acptAnOdrRemainRefCndtn.St_SalesDate = _parentSetCndtn.St_SalesDate;
            //acptAnOdrRemainRefCndtn.Ed_SalesDate = _parentSetCndtn.Ed_SalesDate;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA MODIFY START
            if (_parentSetCndtn.St_SalesDate != DateTime.MinValue)
            {
                //acptAnOdrRemainRefCndtn.St_SalesDate = _parentSetCndtn.St_SalesDate;
                acptAnOdrRemainRefCndtn.St_SalesDate = TDateTime.DateTimeToLongDate(_parentSetCndtn.St_SalesDate);
            }
            else
            {
                acptAnOdrRemainRefCndtn.St_SalesDate = TDateTime.DateTimeToLongDate(DateTime.Today);
                
            }
            if ( _parentSetCndtn.Ed_SalesDate != DateTime.MinValue )
            {
                acptAnOdrRemainRefCndtn.Ed_SalesDate = TDateTime.DateTimeToLongDate(_parentSetCndtn.Ed_SalesDate);
            }
            else
            {
                acptAnOdrRemainRefCndtn.Ed_SalesDate = TDateTime.DateTimeToLongDate(DateTime.Today);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            acptAnOdrRemainRefCndtn.GoodsMakerCd = _parentSetCndtn.GoodsMakerCd;
            acptAnOdrRemainRefCndtn.GoodsNo = _parentSetCndtn.GoodsNo;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA MODIFY START
            // 入力された文字列から曖昧検索条件を割り出す
            //acptAnOdrRemainRefCndtn.GoodsName = _parentSetCndtn.GoodsNameForSearch; // 品名検索用
            string searchNameString = _parentSetCndtn.GoodsNameForSearch;
            int targetIndex = searchNameString.IndexOf("*");

            if (targetIndex == -1)
            {
                // 完全一致
                acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 0;
                acptAnOdrRemainRefCndtn.GoodsName = searchNameString;
            }
            else if (searchNameString.StartsWith("*") && searchNameString.EndsWith("*"))
            {
                // 曖昧検索
                acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 3;
                acptAnOdrRemainRefCndtn.GoodsName = searchNameString.Replace("*", "");
            }
            else if (searchNameString.EndsWith("*"))
            {
                // 前方一致
                acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 1;
                acptAnOdrRemainRefCndtn.GoodsName = searchNameString.Replace("*", "");
            }
            else if (searchNameString.StartsWith("*"))
            {
                // 後方一致
                acptAnOdrRemainRefCndtn.GoodsNmVagueSrch = 2;
                acptAnOdrRemainRefCndtn.GoodsName = searchNameString.Replace("*", "");
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA MODIFY END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA DEL START
            //acptAnOdrRemainRefCndtn.PartySlipNumDtl = _parentSetCndtn.PartySlipNumDtl;
            //acptAnOdrRemainRefCndtn.St_DeliGdsCmpltDueDate = _parentSetCndtn.St_DeliGdsCmpltDueDate;
            //acptAnOdrRemainRefCndtn.Ed_DeliGdsCmpltDueDate = _parentSetCndtn.Ed_DeliGdsCmpltDueDate;
            //acptAnOdrRemainRefCndtn.St_ArrivalDate = _parentSetCndtn.St_ArrivalDate;
            //acptAnOdrRemainRefCndtn.Ed_ArrivalDate = _parentSetCndtn.Ed_ArrivalDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA DEL END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA MODIFY START
            acptAnOdrRemainRefCndtn.AcpOdrStateDiv = (int)_parentSetCndtn.ArrivalStateDiv;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.13 TOKUNAGA MODIFY END

            return acptAnOdrRemainRefCndtn;
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        public void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
        /// <param name="enableSet">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            this._decisionButton.SharedProps.Enabled = enableSet;
        }


        # region 各コントロールイベント処理

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // 終了処理
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        this.SetDialogRes( DialogResult.OK );
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._acptAnOdrRemainRefAcs.ClearTable();

                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        SearchData();
                        break;
                    }
                case "ButtonTool_Pursuit":
                    {
                        // 受注追跡照会表示
                        ShowPursuitReference();
                        break;
                    }
			}
        }
        /// <summary>
        /// 受注追跡照会・詳細表示処理
        /// </summary>
        private void ShowPursuitReference()
        {
            // 追跡・詳細フォーム
            DCJUT04130UC detailViewForm = new DCJUT04130UC();
            // 追跡アクセス
            AcceptAnOrderChaseAcs acceptAnOrderChaseAcs = new AcceptAnOrderChaseAcs();

            // アクティブ行の共通通番を取得
            int commonSeqNo = this._detailForm.GetRowCommonSeq();
            if ( commonSeqNo < 0 )
            {
                return;
            }

            // 読込条件パラメータクラス設定処理
            ExtrInfo_OrderPursuitInquiryDtl extrInfo_OrderPursuitInquiryDtl = this.GetReadParaFromDisplay( commonSeqNo );
            ExtrInfo_OrderPursuitInquiryDtlWork cndtn = acceptAnOrderChaseAcs.CopyToOrderPursuitInquiryDtlWorkFromCndtn( extrInfo_OrderPursuitInquiryDtl );

            // 詳細情報表示起動
            try
            {
                detailViewForm.ShowDialog( cndtn );
            }
            catch
            {
                // エラー発生
            }
        }
        /// <summary>
        /// 受注追跡照会・詳細　表示条件取得
        /// </summary>
        /// <param name="commonSeqNo"></param>
        /// <returns></returns>
        private ExtrInfo_OrderPursuitInquiryDtl GetReadParaFromDisplay( int commonSeqNo )
        {
            ExtrInfo_OrderPursuitInquiryDtl orderPursuitInquiryDtl = new ExtrInfo_OrderPursuitInquiryDtl();

            orderPursuitInquiryDtl.EnterpriseCode = this._enterpriseCode;
            orderPursuitInquiryDtl.CommonSeqNo = commonSeqNo;

            return orderPursuitInquiryDtl;
        }

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Search_Button_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        # region ■ ChangeFocsu ■

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2015/05/08 gaocheng</br>
        /// <br>管理番号    : 11175085-00</br>
        /// <br>            : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SetStatusBarMessage(this, "");

            // フォーカス制御 ============================================ //
            if ( e.PrevCtrl == this.te_GoodsName )
            {
                if ( e.Key == Keys.Down )
                {
                    e.NextCtrl = this._detailForm.uGrid_Details;
                }
            }

            if ((e.PrevCtrl.Parent.Parent == this.Standard_UGroupBox)  &&
                ((e.NextCtrl.Parent == this.panel_Detail) ||
                 (e.NextCtrl == this._detailForm.uGrid_Details)))
            {
                Control control = SearchData();
                if ((this._detailForm.uGrid_Details.Rows.Count > 0) &&
                   (this._detailForm.uGrid_Details.Enabled == true))
                {
                    e.NextCtrl = this._detailForm.uGrid_Details;
                }
                else
                {
					if (control == null)
					{
						e.NextCtrl = e.PrevCtrl;
					}
					else
					{
						e.NextCtrl = control;
					}
                }
            }
			// 名称取得 ============================================ //
            switch (e.PrevCtrl.Name)
            {
                #region 拠点 [tEdit_SectionCode]
                // 拠点
                case "tEdit_SectionCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SectionCode.Text.Trim();
                        string name = "";

                        // 0を許容しない
                        if (String.IsNullOrEmpty(code))
                        {
                            // 拠点コード・名称セット
                            this.tEdit_SectionCode.Text = "00";
                            this.uLabel_SectionNm.Text = "全社";

                            this._inputCndtnCache.SectionCode = string.Empty;
                        }
                        else
                        {
                            if (this._inputCndtnCache.SectionCode.Trim() != code)
                            {
                                SecInfoSet secInfoSet = new SecInfoSet();
                                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                                int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, code);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    name = secInfoSet.SectionGuideNm;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                    code = string.Empty;
                                    name = string.Empty;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "拠点の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                    code = string.Empty;
                                    name = string.Empty;
                                }
                                // 拠点コード・名称セット
                                this.tEdit_SectionCode.Text = code;
                                this.uLabel_SectionNm.Text = name;

                                this._inputCndtnCache.SectionCode = code;
                            }
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            if (String.IsNullOrEmpty(this._inputCndtnCache.SectionCode))
                                            {
                                                // 空白の場合はガイドボタンへ
                                                e.NextCtrl = this.ub_SectionGuide;
                                            }
                                            // else // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            else if (tNedit_CustomerCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            {
                                                // 入力されていれば得意先コードへ
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                                            else
                                            {
                                                e.NextCtrl = tNedit_ClaimCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<

                                            break;
                                        }
                                }
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion // 拠点

                #region 受注状況 [ce_ArrivalStateDiv]
                // 拠点
                case "ce_ArrivalStateDiv":
                    {
                        // NextCtrl制御
                        bool canChangeFocus = true;
                        if (canChangeFocus)
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 請求先
                                            e.NextCtrl = this.tNedit_ClaimCode;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }

                #endregion // 拠点

                #region DELETED
                //#region 部門
                //// 部門
                //case "tne_SubSectionCode":
                //    {
                //        # region [tne_SubSectionCode]
                //        bool canChangeFocus = true;
                //        int code = this.tne_SubSectionCode.GetInt();
                //        string name = "";

                //        if ( this._inputCndtnCache.SubSectionCode != code )
                //        {
                //            SubSection subsection;
                //            SubSectionAcs subsectionAcs = new SubSectionAcs();
                //            int status = subsectionAcs.Read( out subsection, this._enterpriseCode, tEdit_SectionCode.Text, code );

                //            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //            {
                //                name = subsection.SubSectionName;
                //            }
                //            else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                //            {
                //                TMsgDisp.Show(
                //                    this,
                //                    emErrorLevel.ERR_LEVEL_INFO,
                //                    this.Name,
                //                    "部門が存在しません。",
                //                    -1,
                //                    MessageBoxButtons.OK );

                //                canChangeFocus = false;
                //                code = 0;
                //                name = string.Empty;
                //            }
                //            else
                //            {
                //                TMsgDisp.Show(
                //                    this,
                //                    emErrorLevel.ERR_LEVEL_STOPDISP,
                //                    this.Name,
                //                    "部門の取得に失敗しました。",
                //                    status,
                //                    MessageBoxButtons.OK );

                //                canChangeFocus = false;
                //                code = 0;
                //                name = string.Empty;
                //            }
                //            // 拠点コード・名称セット
                //            this.tne_SubSectionCode.SetInt( code );
                //            this.lb_SubSectionName.Text = name;

                //            this._inputCndtnCache.SubSectionCode = code;
                //        }

                //        // NextCtrl制御
                //        if ( canChangeFocus )
                //        {
                //            switch ( e.Key )
                //            {
                //                case Keys.Return:
                //                case Keys.Tab:
                //                    {
                //                        e.NextCtrl = this.ub_SubSectionGuide;

                //                        break;
                //                    }
                //            }
                //        }
                //        else
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }
                //        # endregion

                //        break;
                //    }
                //#endregion // 部門

                //#region 課
                //// 課
                //case "tne_MinSectionCode":
                //    {
                //        # region [tne_MinSectionCode]
                //        bool canChangeFocus = true;
                //        int code = this.tne_MinSectionCode.GetInt();
                //        string name = "";

                //        if ( this._inputCndtnCache.MinSectionCode != code )
                //        {
                //            MinSection minsection;
                //            MinSectionAcs minsectionAcs = new MinSectionAcs();
                //            int status = minsectionAcs.Read( out minsection, this._enterpriseCode, tEdit_SectionCode.Text, tne_SubSectionCode.GetInt(), code );

                //            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //            {
                //                name = minsection.MinSectionName;
                //            }
                //            else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                //            {
                //                TMsgDisp.Show(
                //                    this,
                //                    emErrorLevel.ERR_LEVEL_INFO,
                //                    this.Name,
                //                    "課が存在しません。",
                //                    -1,
                //                    MessageBoxButtons.OK );

                //                canChangeFocus = false;
                //                code = 0;
                //                name = string.Empty;
                //            }
                //            else
                //            {
                //                TMsgDisp.Show(
                //                    this,
                //                    emErrorLevel.ERR_LEVEL_STOPDISP,
                //                    this.Name,
                //                    "課の取得に失敗しました。",
                //                    status,
                //                    MessageBoxButtons.OK );

                //                canChangeFocus = false;
                //                code = 0;
                //                name = string.Empty;
                //            }
                //            // 拠点コード・名称セット
                //            this.tne_MinSectionCode.SetInt( code );
                //            this.lb_MinSectionName.Text = name;

                //            this._inputCndtnCache.MinSectionCode = code;
                //        }

                //        // NextCtrl制御
                //        if ( canChangeFocus )
                //        {
                //            switch ( e.Key )
                //            {
                //                case Keys.Return:
                //                case Keys.Tab:
                //                    {
                //                        e.NextCtrl = this.ub_MinSectionGuide;

                //                        break;
                //                    }
                //            }
                //        }
                //        else
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }
                //        # endregion

                //        break;
                //    }
                //#endregion // 課
                #endregion // DELETED

                #region 担当者 [te_SalesEmployeeCode]
                // 担当者
                case "te_SalesEmployeeCode":
                    {
                        bool canChangeFocus = true;
						string code = this.te_SalesEmployeeCode.Text.Trim();
						string name = "";

                        //if (code == "")
                        if (!String.IsNullOrEmpty(code))
                        {
                            code = code.PadLeft(4, '0');
                            if (this._inputCndtnCache.SalesEmployeeCd.Trim() != code)
                            {
                                name = this._acptAnOdrRemainRefAcs.GetName_FromEmployee(code);

                                if (name.Trim() == "")
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "担当者が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                    code = string.Empty;
                                    name = string.Empty;
                                }
                                // 従業員コード・名称セット
                                this.te_SalesEmployeeCode.Text = code;
                                this.lb_SalesEmployeeName.Text = name;
                            }
                            else
                            {
                                this.te_SalesEmployeeCode.Text = code;
                            }
                            this._inputCndtnCache.SalesEmployeeCd = code;
                        }
                        else
                        {
                            this.te_SalesEmployeeCode.Clear();
                            this.lb_SalesEmployeeName.Text = "";
                            this._inputCndtnCache.SalesEmployeeCd = code;
                        }

						// NextCtrl制御
						if (canChangeFocus)
						{
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            //if (this.te_SalesEmployeeCode.Text.Trim() == String.Empty)
                                            if (String.IsNullOrEmpty(this._inputCndtnCache.SalesEmployeeCd))
                                            {
                                                // 入力されていなければガイドボタンへ
                                                e.NextCtrl = this.ub_SalesEmployeeGuide;
                                            }
                                            else
                                            {
                                                // 入力されていれば発行者コードへ
                                                // [9110]
                                                if (this.tEdit_SalesInputCode.Visible)
                                                {
                                                    e.NextCtrl = this.tEdit_SalesInputCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tEdit_FrontEmployeeCode;
                                                }
                                            }

                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 伝票場号（終了）
                                            e.NextCtrl = this.tEdit_SalesSlipNum_Ed;
                                            break;
                                        }
                                }
                            }
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion // 担当者

                #region メーカー [tne_GoodsMakerCd]
                // メーカー
				case "tne_GoodsMakerCd":
                    {
                        bool canChangeFocus = true;
						int code = this.tne_GoodsMakerCd.GetInt();
                        this.tne_GoodsMakerCd.SetInt( code );
                        string name = this.lb_MakerName.Text;

                        if (!String.IsNullOrEmpty(this.tne_GoodsMakerCd.Text.Trim()))
                        {
                            if (this._inputCndtnCache.GoodsMakerCd != code)
                            {
                                name = this._acptAnOdrRemainRefAcs.GetName_FromGoodsMaker(code);

                                if (name.Trim() == "")
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "メーカーが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                    code = 0;
                                    name = "";
                                    this.tne_GoodsMakerCd.Clear();
                                    this.lb_MakerName.Text = "";
                                }
                                else
                                {
                                    // メーカーコード・名称セット
                                    this.tne_GoodsMakerCd.Text = code.ToString().PadLeft(4, '0');
                                    this.lb_MakerName.Text = name;
                                }
                            }
                            this._inputCndtnCache.GoodsMakerCd = code;
                        }
                        else
                        {
                            this._inputCndtnCache.GoodsMakerCd = code;
                            this.tne_GoodsMakerCd.Clear();
                            this.lb_MakerName.Text = "";
                        }

						// NextCtrl制御
						if (canChangeFocus)
						{
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            if (this._inputCndtnCache.GoodsMakerCd == 0)
                                            {
                                                // 入力されていなければガイドボタンへ
                                                e.NextCtrl = this.ub_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                // 入力されていれば品名検索へ
                                                e.NextCtrl = this.te_GoodsNo; // 2008.12.12 modify [9091]
                                            }

                                            break;
                                        }
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = this.tEdit_FullModel;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                // [SHIFT + TAB]
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 受注者
                                            e.NextCtrl = this.tEdit_FrontEmployeeCode;
                                            break;
                                        }
                                }
                            }
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion // メーカー

                #region 得意先 [tNedit_CustomerCode]
                // 得意先
                case "tNedit_CustomerCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_CustomerCode.GetInt();
                        this.tNedit_CustomerCode.SetInt( code );

                        if (this._inputCndtnCache.CustomerCode != code)
                        {
                            if (code == 0)
                            {
                                this._inputCndtnCache.CustomerCode = code;
                                this.tNedit_CustomerCode.Text = "";
                                this.uLabel_CustomerName.Text = "";
                            }
                            else
                            {
                                canChangeFocus = this.GetCustomerName(code);
                            }
                        }
                        this._inputCndtnCache.CustomerCode = code;

                        #region deleted
                        //        CustomerInfo customerInfo;
                        //        //CustSuppli custSuppli;
                        //        CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                        //        //int status = customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo, out custSuppli);
                        //        int status = customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo );

                        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        {
                        //            // 得意先コード・名称セット
                        //            this.tNedit_CustomerCode.SetInt( code );
                        //            this.uLabel_CustomerName.Text = customerInfo.Name;
                        //        }
                        //        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_INFO,
                        //                this.Name,
                        //                "得意先が存在しません。",
                        //                -1,
                        //                MessageBoxButtons.OK);

                        //            canChangeFocus = false;
                        //            this.tNedit_CustomerCode.Text = "";
                        //            this.uLabel_CustomerName.Text = "";
                        //            code = 0;
                        //        }
                        //        else
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_STOPDISP,
                        //                this.Name,
                        //                "得意先の取得に失敗しました。",
                        //                status,
                        //                MessageBoxButtons.OK);

                        //            canChangeFocus = false;
                        //            this.tNedit_CustomerCode.Text = "";
                        //            this.uLabel_CustomerName.Text = "";
                        //            code = 0;
                        //        }
                        //    }
                        //}
                        #endregion // deleted

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            //if (this.tNedit_CustomerCode.GetInt() == 0)
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))//.GetInt() == 0)
                                            {
                                                e.NextCtrl = this.ub_CustomerGuide;
                                            }
                                            else
                                            {
                                                // 入力されていれば請求先コードへ
                                                e.NextCtrl = this.tNedit_ClaimCode;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 拠点
                                            e.NextCtrl = this.tEdit_SectionCode;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion // 得意先

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA ADD START
                #region 請求先 [tNedit_ClaimCode]
                // 請求先
                case "tNedit_ClaimCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_ClaimCode.GetInt();
                        this.tNedit_ClaimCode.SetInt(code);

                        if (this._inputCndtnCache.ClaimCode != code)
                        {
                            if (code == 0)
                            {
                                this._inputCndtnCache.ClaimCode = code;
                                this.tNedit_ClaimCode.Text = "";
                                this.uLabel_ClaimName.Text = "";
                            }
                            else
                            {
                                canChangeFocus = this.GetClaimName(code);
                            }
                        }
                        this._inputCndtnCache.ClaimCode = code;

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            if (this.tNedit_ClaimCode.GetInt() == 0)
                                            {
                                                // 請求先ガイドボタンへ
                                                e.NextCtrl = this.uButton_ClaimGuide;
                                            }
                                            else
                                            {
                                                // 受注状況へ
                                                e.NextCtrl = this.ce_ArrivalStateDiv;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 得意先
                                            // e.NextCtrl = this.tNedit_CustomerCode; // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                                            if (this.tNedit_CustomerCode.Enabled)
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ub_SectionGuide;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion // 請求先

                #region 発行者 [tEdit_SalesInputCode]
                // 発行者
                case "tEdit_SalesInputCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesInputCode.Text.Trim();
                        string name = "";

                        if (!String.IsNullOrEmpty(code))
                        {
                            code = code.PadLeft(4, '0');
                            if (this._inputCndtnCache.SalesInputCode.Trim() != code)
                            {
                                if (code == "")
                                {
                                    this._inputCndtnCache.SalesInputCode = code;
                                }
                                else
                                {
                                    name = this._acptAnOdrRemainRefAcs.GetName_FromEmployee(code);

                                    if (name.Trim() == "")
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "担当者が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        code = string.Empty;
                                        name = string.Empty;
                                    }
                                }
                                // 従業員コード・名称セット
                                this.tEdit_SalesInputCode.Text = code;
                                this.uLabel_SalesInputName.Text = name;
                            }
                            else
                            {
                                this.tEdit_SalesInputCode.Text = code;
                            }
                            this._inputCndtnCache.SalesInputCode = code;
                        }
                        else
                        {
                            this.tEdit_SalesInputCode.Clear();
                            this.uLabel_SalesInputName.Text = "";
                            this._inputCndtnCache.SalesInputCode = code;
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            // 発行者ガイドボタンへ
                                            if (String.IsNullOrEmpty(this.tEdit_SalesInputCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SalesInputGuide;
                                            }
                                            else
                                            {
                                                // 入力されていれば受注者コードへ
                                                e.NextCtrl = this.tEdit_FrontEmployeeCode;
                                            }

                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 担当者コード
                                            e.NextCtrl = this.te_SalesEmployeeCode;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion // 発行者

                #region 受注者 [tEdit_FrontEmployeeCode]
                // 受注者
                case "tEdit_FrontEmployeeCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_FrontEmployeeCode.Text.Trim();
                        string name = "";

                        if (!String.IsNullOrEmpty(code))
                        {
                            code = code.PadLeft(4, '0');
                            if (this._inputCndtnCache.FrontEmployeeCd.Trim() != code)
                            {
                                if (code == "")
                                {
                                    this._inputCndtnCache.FrontEmployeeCd = code;
                                }
                                else
                                {
                                    name = this._acptAnOdrRemainRefAcs.GetName_FromEmployee(code);

                                    if (name.Trim() == "")
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "担当者が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        code = string.Empty;
                                        name = string.Empty;
                                    }
                                }
                                // 従業員コード・名称セット
                                this.tEdit_FrontEmployeeCode.Text = code;
                                this.uLabel_FrontEmployeeName.Text = name;
                            }
                            else
                            {
                                this.tEdit_FrontEmployeeCode.Text = code;
                            }
                            this._inputCndtnCache.FrontEmployeeCd = code;
                        }
                        else
                        {
                            this.tEdit_FrontEmployeeCode.Clear();
                            this.uLabel_FrontEmployeeName.Text = "";
                            this._inputCndtnCache.FrontEmployeeCd = code;
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            // 受注者ガイドボタンへ
                                            if (String.IsNullOrEmpty(this.tEdit_FrontEmployeeCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_FrontEmployeeGuide;
                                            }
                                            else
                                            {
                                                // メーカーコード
                                                e.NextCtrl = this.tne_GoodsMakerCd;
                                            }

                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 発行者
                                            // [9110]
                                            if (this.tEdit_SalesInputCode.Visible)
                                            {
                                                e.NextCtrl = this.tEdit_SalesInputCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.te_SalesEmployeeCode;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }

                case "uButton_FrontEmployeeGuide":
                    {
                        bool canChangeFocus = true;

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // メーカーコード
                                        e.NextCtrl = this.tne_GoodsMakerCd;

                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion // 受注者

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA ADD END

                #region 品番 [te_GoodsNo]
                // 品番
                case "te_GoodsNo":
                    {
                        bool canChangeFocus = true;
                        string code = this.te_GoodsNo.Text.Trim();
                        string name = this.lb_GoodsNameView.Text.Trim();
                        bool existFlg = false;
                        #region del
                        //if (this._inputCndtnCache.GoodsNo.Trim() != code)
                        //{
                        //    if (code == "")
                        //    {
                        //        this._inputCndtnCache.GoodsNo = code;
                        //        name = "";
                        //    }
                            //else
                            //{
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.20 TOKUNAGA ADD START
                            //    this._acptAnOdrRemainRefAcs.SectionCode = this._inputCndtnCache.SectionCode;
                            //    // メーカーコードがあれば
                            //    if (this._inputCndtnCache.GoodsMakerCd != 0)
                            //    {
                            //        this._acptAnOdrRemainRefAcs.MakerCode = this._inputCndtnCache.GoodsMakerCd;
                            //    }
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.20 TOKUNAGA ADD END

                            //    existFlg = this._acptAnOdrRemainRefAcs.CheckGoodsExist(code, out name);

                            //    if (existFlg == false)
                            //    {
                            //        TMsgDisp.Show(
                            //            this,
                            //            emErrorLevel.ERR_LEVEL_INFO,
                            //            this.Name,
                            //            "商品が存在しません。",
                            //            -1,
                            //            MessageBoxButtons.OK);

                            //        canChangeFocus = false;
                            //        code = string.Empty;
                            //        name = string.Empty;
                            //    }
                            //}
                            //// 商品コード・名称セット
                            //this.te_GoodsNo.Text = code;
                            //this.lb_GoodsNameView.Text = name;
                        //}
                        #endregion // del
                        this._inputCndtnCache.GoodsNo = code;

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            // 品名
                                            e.NextCtrl = this.te_GoodsName;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // メーカーコード
                                            e.NextCtrl = this.tne_GoodsMakerCd;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }

                #region del
                //case "ub_GoodsGuide":
                //    {
                //        bool canChangeFocus = true;

                //        // NextCtrl制御
                //        if (canChangeFocus)
                //        {
                //            if (!e.ShiftKey)
                //            {
                //                switch (e.Key)
                //                {
                //                    case Keys.Return:
                //                    case Keys.Tab:
                //                    case Keys.Down:
                //                        {
                //                            // 品名
                //                            e.NextCtrl = this.te_GoodsName;
                //                            break;
                //                        }
                //                }
                //            }
                //            else
                //            {
                //                switch (e.Key)
                //                {
                //                    case Keys.Tab:
                //                        {
                //                            // 品番
                //                            e.NextCtrl = this.te_GoodsNo;
                //                            break;
                //                        }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }
                //        break;
                //    }
                #endregion // del
                #endregion // 品番

                #region 型式

                case "tEdit_FullModel":
                    {
                        bool canChangeFocus = true;

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            // 受注日開始
                                            e.NextCtrl = this.tde_St_SalesDate;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 受注状況
                                            e.NextCtrl = this.ce_ArrivalStateDiv;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }

                #endregion // 型式

                #region 品名検索

                case "te_GoodsName":
                    {
                        bool canChangeFocus = true;

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Up:
                                        {
                                            // 拠点
                                            e.NextCtrl = this.tEdit_SectionCode;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Up:
                                        {
                                            // 品番
                                            e.NextCtrl = this.te_GoodsNo;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }

                #endregion // 品名検索

                #region 伝票番号

                case "tEdit_SalesSlipNum_St":
                    {
                        string slipNo = this.tEdit_SalesSlipNum_St.Text.Trim();
                        if (!String.IsNullOrEmpty(slipNo))
                        {
                            this.tEdit_SalesSlipNum_St.Text = slipNo.PadLeft(9, '0');
                        }
                        break;
                    }

                case "tEdit_SalesSlipNum_Ed":
                    {
                        string slipNo = this.tEdit_SalesSlipNum_Ed.Text.Trim();
                        if (!String.IsNullOrEmpty(slipNo))
                        {
                            this.tEdit_SalesSlipNum_Ed.Text = slipNo.PadLeft(9, '0');
                        }
                        break;
                    }

                #endregion // 伝票番号
            }

            // RetKeyControl用処理
            if ((e.Key == Keys.Return) ||
                (e.Key == Keys.Tab))
            {
                // MAKON01320UBのグリッドでのEnterキー押下処理で、MAKON01320UAのtRetKeyControlに制御を奪われるため
                // イベントが発生しなくなる現象の回避策
                if (e.PrevCtrl == this._detailForm.uGrid_Details)
                {
                    // グリッド上でのEnterキー押下では、他コントロールにフォーカスを移さない
                    e.NextCtrl = e.PrevCtrl;
                    // グリッド行選択処理タイマー発動
                    this._detailForm.timer_SelectRow.Enabled = true;
                }
				if (e.NextCtrl.Parent == this.panel_Detail)
				{
					Control control = SearchData();

					if (( this._detailForm.uGrid_Details.Rows.Count > 0 ) &&
					   ( this._detailForm.uGrid_Details.Enabled == true ))
					{
						e.NextCtrl = this._detailForm.uGrid_Details;
					}
					else
					{
						if (control == null)
						{
							e.NextCtrl = e.PrevCtrl;
						}
						else
						{
							e.NextCtrl = control;
						}
					}
				}
            }
        }

        # endregion ■ ChangeFocus ■

        /// <summary>
        /// 初期フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_InitialSetFocus_Tick ( object sender, EventArgs e )
        {
            this.timer_InitialSetFocus.Enabled = false;
            this._detailForm.uGrid_Details.Enabled = false;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 起動時自動検索するならばSearch実行

            if ( _autoSearch )
            {
                // 検索処理
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //SearchData();
                SearchDataForInitialSearch();
                this._detailForm.uGrid_Details.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            else
            {
                this.tEdit_SectionCode.Focus();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAKON01320UA_FormClosed(object sender, FormClosedEventArgs e)
        {
			if (this._printControl != null)
			{
				this._printControl.Dispose();
			}

            DialogResult = _dialogRes;
        }

        # region ■ ガイドボタンクリック ■

        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2015/05/08 gaocheng</br>
        /// <br>管理番号    : 11175085-00</br>
        /// <br>            : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br> 
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionNm.Text = secInfoSet.SectionGuideNm.Trim();
				this._inputCndtnCache.SectionCode = secInfoSet.SectionCode.Trim();
                // this.tNedit_CustomerCode.Focus();// [9091] // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                if (this.tNedit_CustomerCode.Enabled)
                {
                    this.tNedit_CustomerCode.Focus();
                }
                else
                {
                    this.tNedit_ClaimCode.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
            }
        }


        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
				if (sender == ub_SalesEmployeeGuide)
				{
					te_SalesEmployeeCode.Text = employee.EmployeeCode.Trim();
					lb_SalesEmployeeName.Text = employee.Name.Trim();
					this._inputCndtnCache.SalesEmployeeCd = employee.EmployeeCode.Trim();
                    // [9091]
                    if (this.tEdit_SalesInputCode.Visible)
                    {
                        this.tEdit_SalesInputCode.Focus();
                    }
                    else
                    {
                        this.tEdit_FrontEmployeeCode.Focus();
                    }
				}
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA ADD START
        /// <summary>
        /// 発行者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SalesInputGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SalesInputCode.Text = employee.EmployeeCode.Trim();
                uLabel_SalesInputName.Text = employee.Name.Trim();
                this._inputCndtnCache.SalesInputCode = employee.EmployeeCode.Trim();
                this.tEdit_FrontEmployeeCode.Focus(); // [9091]
            }
        }

        /// <summary>
        /// 担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_FrontEmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_FrontEmployeeCode.Text = employee.EmployeeCode.Trim();
                uLabel_FrontEmployeeName.Text = employee.Name.Trim();
                this._inputCndtnCache.FrontEmployeeCd = employee.EmployeeCode.Trim();
                this.tne_GoodsMakerCd.Focus(); // [9091]
            }
        }

        /// <summary>
        /// 請求先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_ClaimGuide_Click(object sender, EventArgs e)
        {
            // アセンブリ変更による修正
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA MODIFY START
            Infragistics.Win.Misc.UltraButton _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_ClaimSelect);
            DialogResult result = customerSearchForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.ce_ArrivalStateDiv.Focus(); //[9091]
            }
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA MODIFY END
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA ADD END

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
        {
            // アセンブリ変更による修正
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA MODIFY START
            Infragistics.Win.Misc.UltraButton _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.tNedit_ClaimCode.Focus(); //[9091]
            }

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            // 仕入先の名称変換を行う
            //GetCustomerName();

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA MODIFY END
        }

		/// <summary>
		/// メーカーガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;
			int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				tne_GoodsMakerCd.Text = makerUMnt.GoodsMakerCd.ToString().PadLeft(4, '0');
				lb_MakerName.Text = makerUMnt.MakerName.Trim();

                this._inputCndtnCache.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                this.te_GoodsNo.Focus(); // [9091]
            }
		}
        /// <summary>
        /// 商品ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">メッセージ</param>
        private void uButton_GoodsGuide_Click(object sender, EventArgs e)
        {
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            GoodsUnitData goodsUnitData;
            DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

            if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
            {
                // 商品コード設定処理
				this.te_GoodsNo.Text = goodsUnitData.GoodsNo;
                this.lb_GoodsNameView.Text = goodsUnitData.GoodsName;

                this._inputCndtnCache.GoodsNo = goodsUnitData.GoodsNo;
			}
        }
        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            this.uLabel_CustomerName.Text = customerSearchRet.Name;
            this._inputCndtnCache.CustomerCode = customerSearchRet.CustomerCode;

            //CustomerInfo customerInfo;
            //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            //int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);

            //if ( status == 0 )
            //{
            //    this.tNedit_CustomerCode.SetInt( customerSearchRet.CustomerCode );
            //    this.uLabel_CustomerName.Text = customerSearchRet.Name;
            //    this._inputCndtnCache.CustomerCode = customerSearchRet.CustomerCode;
            //}
		}

        /// <summary>
        /// 請求先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_ClaimSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            this.tNedit_ClaimCode.SetInt(customerSearchRet.CustomerCode);
            this.uLabel_ClaimName.Text = customerSearchRet.Name;
            this._inputCndtnCache.ClaimCode = customerSearchRet.CustomerCode;
        }

        /// <summary>
        /// 部門ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_SubSectionGuide_Click ( object sender, EventArgs e )
        {
            //// 拠点コード
            //string sectionCode = this.tEdit_SectionCode.Text.Trim();
            
            //SubSection subsection;
            //int status = this._subSectionAcs.ExecuteGuid( out subsection, this._enterpriseCode, sectionCode );

            //if ( status == 0 )
            //{
            //    this.tne_SubSectionCode.SetInt(subsection.SubSectionCode);
            //    this.lb_SubSectionName.Text = subsection.SubSectionName;
            //    this._inputCndtnCache.SubSectionCode = subsection.SubSectionCode;

            //    // 拠点コード修正
            //    if ( subsection.SectionCode != this.tEdit_SectionCode.Text )
            //    {
            //        DialogResult result =
            //            TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_QUESTION,
            //                this.Name,
            //                "部門の拠点コードに書き換えてよろしいですか？",
            //                status,
            //                MessageBoxButtons.OKCancel );

            //        if ( result == DialogResult.OK )
            //        {
            //            this.tEdit_SectionCode.Text = subsection.SectionCode;
            //            this.uLabel_SectionNm.Text = subsection.SectionGuideNm;
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 課ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_MinSection_Click ( object sender, EventArgs e )
        {
            //// 拠点コード
            //string sectionCode = this.tEdit_SectionCode.Text.Trim();

            //MinSection minsection;
            //int status = this._minSectionAcs.ExecuteGuid( out minsection, this._enterpriseCode, sectionCode );

            //if ( status == 0 )
            //{
            //    this.tne_MinSectionCode.SetInt( minsection.MinSectionCode );
            //    this.lb_MinSectionName.Text = minsection.MinSectionName;

            //    // 拠点コード修正
            //    if ( minsection.SectionCode != this.tEdit_SectionCode.Text ||
            //         minsection.SubSectionCode != this.tne_SubSectionCode.GetInt() ) 
            //    {
            //        DialogResult result =
            //            TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_QUESTION,
            //                this.Name,
            //                "課の拠点コード・部門コードに書き換えてよろしいですか？",
            //                status,
            //                MessageBoxButtons.OKCancel );

            //        if ( result == DialogResult.OK )
            //        {
            //            this.tEdit_SectionCode.Text = minsection.SectionCode;
            //            this.uLabel_SectionNm.Text = minsection.SectionGuideNm;
            //            this.tne_SubSectionCode.SetInt( minsection.SubSectionCode );
            //            this.lb_SubSectionName.Text = minsection.SubSectionName;
            //        }
            //    }
            //}
        }
        # endregion ■ ガイドボタンクリック ■

        # region ■ 名称変換 ■

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.18 TOKUNAGA ADD START
        
        private bool GetCustomerName(int code)
        {
            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 得意先コード・名称セット
                this.tNedit_CustomerCode.SetInt(code);
                this.uLabel_CustomerName.Text = customerInfo.Name;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "得意先が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_CustomerCode.Text = "";
                this.uLabel_CustomerName.Text = "";
                code = 0;
                return false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                this.tNedit_CustomerCode.Text = "";
                this.uLabel_CustomerName.Text = "";
                code = 0;
                return false;
            }
            return true;
        }

        private bool GetClaimName(int code)
        {
            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 請求先コード・名称セット
                this.tNedit_ClaimCode.SetInt(code);
                this.uLabel_ClaimName.Text = customerInfo.Name;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "請求先が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_ClaimCode.Text = "";
                this.uLabel_ClaimName.Text = "";
                code = 0;
                return false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "請求先の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                this.tNedit_ClaimCode.Text = "";
                this.uLabel_ClaimName.Text = "";
                code = 0;
                return false;
            }
            return true;
            //int code = this.tNedit_ClaimCode.GetInt();
            //this.tNedit_ClaimCode.SetInt(code);

            //if (this._inputCndtnCache.ClaimCode != code)
            //{
            //    if (code == 0)
            //    {
            //        this._inputCndtnCache.ClaimCode = code;
            //        this.tNedit_ClaimCode.Text = "";
            //        this.uLabel_ClaimName.Text = "";
            //    }
            //    else
            //    {
            //CustomerInfo customerInfo;
            //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            //int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // 得意先コード・名称セット
            //    this.tNedit_ClaimCode.SetInt(code);
            //    this.uLabel_ClaimName.Text = customerInfo.Name;
            //}
            //else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_INFO,
            //        this.Name,
            //        "得意先が存在しません。",
            //        -1,
            //        MessageBoxButtons.OK);

            //    this.tNedit_ClaimCode.Text = "";
            //    this.uLabel_ClaimName.Text = "";
            //    code = 0;
            //    return false;
            //}
            //else
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_STOPDISP,
            //        this.Name,
            //        "得意先の取得に失敗しました。",
            //        status,
            //        MessageBoxButtons.OK);

            //    this.tNedit_ClaimCode.Text = "";
            //    this.uLabel_ClaimName.Text = "";
            //    code = 0;
            //    return false;
            //    //    }
            //    //}
            //}
            //this._inputCndtnCache.ClaimCode = code;
            return true;
        }


        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.18 TOKUNAGA ADD END

        #endregion

        # endregion

    }
}