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
    /// 仕入先マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// <br>Update Note: 2009/03/25 30452 上野 俊治</br>
    /// <br>            ・障害対応12785</br>
    /// </remarks>
    public partial class PMKHN08560UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 仕入先マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08560UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._supplierSetAcs = new SupplierSetAcs();


            // 変数初期化
            this.secInfoSetTable = new Hashtable();

            // データセット列情報構築処理
            DataSetColumnConstruction();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;


        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private SupplierPrintWork _supplierPrintWork;

        // データアクセス
        private SupplierSetAcs _supplierSetAcs;

        private static SupplierAcs _supplierAcs;


        private Hashtable secInfoSetTable;

        // --- ADD 2009/03/25 -------------------------------->>>>>
        private MoneyKindAcs _moneyKindAcs;
        private Dictionary<int, MoneyKind> _moneyKindDic;
        // --- ADD 2009/03/25 --------------------------------<<<<<

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08560UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08560U";
        //// 帳票名称
        private string _printName = "仕入先マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "SUPPLIERSET";

        // dataview名称用
        private const string SUPPLIERCD = "suppliercd";
        private const string SUPPLIERSNM = "suppliersnm";
        private const string SUPPLIERKANA = "supplierkana";
        private const string SUPPLIERTELNO = "suppliertelno";
        private const string SUPPLIERTELNO1 = "suppliertelno1";
        private const string SUPPLIERTELNO2 = "suppliertelno2";
        private const string SUPPLIERPOSTNO = "supplierpostno";
        private const string SUPPLIERADDRALL = "supplieraddrall";
        private const string SUPPLIERADDR1 = "supplieraddr1";
        private const string SUPPLIERADDR3 = "supplieraddr3";
        private const string SUPPLIERADDR4 = "supplieraddr4";
        private const string PAYMENTTOTALDAY = "paymenttotalday";
        private const string PAYMENTCOND = "paymentcond";
        private const string PAYMENTMONTHDAY = "paymentmonthday";
        private const string PAYMENTMONTHNAME = "paymentmonthname";
        private const string PAYMENTDAY = "paymentday";
        private const string STOCKAGENTCODE = "stockagentcode";
        private const string STOCKAGENTNAME = "stockagentname";
        private const string MNGSECTIONCODE = "mngsectioncode";
        private const string SECTIONGUIDENM = "sectionguidenm";
        private const string PAYMENTSECTIONCODE = "paymentsectioncode";
        private const string PAYEECODE = "payeecode";
        private const string PAYEESNM = "payeesnm";

        private const string SUPPLIERCD_TITLE = "仕入先";
        private const string SUPPLIERSNM_TITLE = "仕入先名";
        private const string SUPPLIERKANA_TITLE = "ｶﾅ";
        private const string SUPPLIERTELNO_TITLE = "電話番号１";
        private const string SUPPLIERTELNO1_TITLE = "電話番号２";
        private const string SUPPLIERTELNO2_TITLE = "FAX";
        private const string SUPPLIERPOSTNO_TITLE = "郵便番号";
        private const string SUPPLIERADDRALL_TITLE = "住所";
        private const string SUPPLIERADDR1_TITLE = "住所１";
        private const string SUPPLIERADDR3_TITLE = "住所２";
        private const string SUPPLIERADDR4_TITLE = "住所３";
        private const string PAYMENTTOTALDAY_TITLE = "締日";
        private const string PAYMENTCOND_TITLE = "支払条件";
        private const string PAYMENTMONTHDAY_TITLE = "支払月日";
        private const string PAYMENTMONTHNAME_TITLE = "支払月";
        private const string PAYMENTDAY_TITLE = "支払日";
        private const string STOCKAGENTCODE_TITLE = "担当者";
        private const string STOCKAGENTNAME_TITLE = "担当者名";
        private const string MNGSECTIONCODE_TITLE = "拠点";
        private const string SECTIONGUIDENM_TITLE = "拠点名";
        private const string PAYMENTSECTIONCODE_TITLE = "支払先拠点";
        private const string PAYEECODE_TITLE = "支払先";
        private const string PAYEESNM_TITLE = "支払先名";

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color ct_REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color ct_MINUS_FONT_COLOR = Color.Red;
        private static readonly Color ct_GOODSDISCOUNT_CELL_COLOR = Color.Pink;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        private static readonly Color ct_ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));

        private static readonly Color ct_MARGIN_LESS_COLOR = Color.Orchid;
        private static readonly Color ct_MARGIN_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_MARGIN_OVER_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

        private static readonly Color ct_UNITPRICE_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_UNITPRICE_CHANGE_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

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
        public int Extract(ref object parameter)
        {

            int status = 0;
            ArrayList PrintSets = null;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._supplierSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._supplierPrintWork);
            }
            else
            {
                status = this._supplierSetAcs.SearchAll(
                    out PrintSets,
                    this._enterpriseCode,
                    this._supplierPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 仕入先クラスをデータセットへ展開する
                        int index = 0;
                        foreach (SupplierSet supplierSet in PrintSets)
                        {

                            SecPrintSetToDataSet(supplierSet.Clone(), index);
                            ++index;
                        }

                        // DEL 2008/12/03 不具合対応[8649] ---------->>>>>
                        // ADD 2008/11/27 不具合対応[8318] ---------->>>>>
                        //if (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count == 0)
                        //{
                        //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
                        //}
                        // ADD 2008/11/27 不具合対応[8318] ----------<<<<<
                        // DEL 2008/12/03 不具合対応[8649] ----------<<<<<
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN08560U", 						// アセンブリＩＤまたはクラスＩＤ
                            "仕入先マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._supplierSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
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
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._supplierPrintWork;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
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
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
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
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._supplierPrintWork = new SupplierPrintWork();

            this.Show();
            return;
        }
        #endregion

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.03.18</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// メインフレームグリットレイアウト設定
        /// </summary>
        /// <param name="UGrid"></param>
        public void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid)
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = UGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            UGrid.DisplayLayout.Bands[0].UseRowLayout = true;

            // 列幅の自動調整方法
            UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            UGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            UGrid.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            UGrid.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;


            UGrid.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            UGrid.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            #region 項目のサイズを設定
            sizeCell.Height = 22;
            sizeCell.Width = 60;
            sizeHeader.Height = 20;
            sizeHeader.Width = 60;

            // コード
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // １行目
            sizeCell.Width = 420;
            sizeHeader.Width = 420;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;


            sizeCell.Width = 150;
            sizeHeader.Width = 150;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 40;
            sizeHeader.Width = 40;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 500;
            sizeHeader.Width = 500;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            // 2行目
            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 721;
            sizeHeader.Width = 721;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 50;
            sizeHeader.Width = 50;
            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 270;
            sizeHeader.Width = 270;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTDAY].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].Header.Caption = SUPPLIERCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].Header.Caption = SUPPLIERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].Header.Caption = SUPPLIERKANA_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].Header.Caption = SUPPLIERTELNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].Header.Caption = SUPPLIERTELNO1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].Header.Caption = SUPPLIERTELNO2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].Header.Caption = SUPPLIERPOSTNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].Header.Caption = SUPPLIERADDRALL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR1].Header.Caption = SUPPLIERADDR1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR3].Header.Caption = SUPPLIERADDR3_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR4].Header.Caption = SUPPLIERADDR4_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].Header.Caption = PAYMENTTOTALDAY_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].Header.Caption = PAYMENTCOND_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].Header.Caption = PAYMENTMONTHDAY_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHNAME].Header.Caption = PAYMENTMONTHNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTDAY].Header.Caption = PAYMENTDAY_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].Header.Caption = STOCKAGENTCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].Header.Caption = STOCKAGENTNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].Header.Caption = MNGSECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].Header.Caption = SECTIONGUIDENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].Header.Caption = PAYMENTSECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].Header.Caption = PAYEECODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].Header.Caption = PAYEESNM_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR1].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR3].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDR4].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHNAME].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTDAY].Hidden = true;

            #region 列配置
            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.SpanY = 4;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.SpanX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERTELNO2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTTOTALDAY].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTCOND].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTMONTHDAY].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].RowLayoutColumnInfo.OriginX = 18;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].RowLayoutColumnInfo.OriginX = 20;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKAGENTNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].RowLayoutColumnInfo.OriginX = 22;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYMENTSECTIONCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].RowLayoutColumnInfo.OriginX = 24;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEECODE].RowLayoutColumnInfo.SpanY = 2;
                        
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].RowLayoutColumnInfo.OriginX = 26;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].RowLayoutColumnInfo.SpanX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[PAYEESNM].RowLayoutColumnInfo.SpanY = 2;
            
            // ２行目
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERKANA].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERPOSTNO].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].RowLayoutColumnInfo.SpanX = 20;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERADDRALL].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.OriginX = 26;
            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginX = 28;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanY = 2;
            #endregion 列配置
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            // 開始仕入先
            if (this._supplierPrintWork.SupplierCdSt != this.tNedit_SupplierCd_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了仕入先
            if (this._supplierPrintWork.SupplierCdEd != this.tNedit_SupplierCd_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始カナ
            if (this._supplierPrintWork.SupplierKanaSt != this.tEdit_SupplierNm_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了カナ
            if (this._supplierPrintWork.SupplierKanaEd != this.tEdit_SupplierNm_Ed.DataText)
            {
                status = false;
                return status;
            }
            // 削除指定
            if (this._supplierPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._supplierPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._supplierPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            return status;
        }
        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpType メンバ

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
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tNedit_SupplierCd_St.DataText = string.Empty;
                this.tNedit_SupplierCd_Ed.DataText = string.Empty;
                this.tEdit_SupplierNm_St.DataText = string.Empty;
                this.tEdit_SupplierNm_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.CustomerCdSt_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.CustomerCdEd_GuideBtn, Size16_Index.STAR1);

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // 初期フォーカスセット
                this.tNedit_SupplierCd_St.Focus();
            }
            catch (Exception ex)
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
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
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
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";


            // 仕入先
            if (
                (this.tNedit_SupplierCd_St.GetInt() != 0) &&
                (this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // カナ
            if (
                (this.tEdit_SupplierNm_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SupplierNm_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_SupplierNm_St.DataText.CompareTo(this.tEdit_SupplierNm_Ed.DataText.TrimEnd()) > 0)
            {
                errMessage = string.Format("カナ{0}", ct_RangeError);
                errComponent = this.tEdit_SupplierNm_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // 削除日付
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    status = false;
                    return status;  // ADD 2008/11/27 不具合対応[8320]
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    status = false;
                    return status;  // ADD 2008/11/27 不具合対応[8320]
                }

                // 範囲チェック
                if ((this.SerchSlipDataStRF_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.SerchSlipDataEdRF_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.SerchSlipDataStRF_tDateEdit.GetDateTime() > this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
                    {
                        errMessage = "削除日付の範囲指定に誤りがあります。";
                        this.SerchSlipDataStRF_tDateEdit.Focus();
                        return (false);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="minValueCheck">未入力チェックフラグ(True:未入力不可 False:未入力可)</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMsg = "日付を指定してください。";
                    return (false);
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }

                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMsg = "日付を指定してください。";
                    return (false);
                }
            }

            if (year < 1900)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            return (true);
        }
        #endregion


        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 開始仕入先
                this._supplierPrintWork.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先
                this._supplierPrintWork.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
                // 開始カナ
                this._supplierPrintWork.SupplierKanaSt = this.tEdit_SupplierNm_St.DataText;
                // 終了カナ
                this._supplierPrintWork.SupplierKanaEd = this.tEdit_SupplierNm_Ed.DataText;

                // 削除指定区分
                this._supplierPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._supplierPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._supplierPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
            }
            catch (Exception)
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
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
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
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
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
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region DataSet関連
        /// <summary>
        /// 仕入先クラスデータセット展開処理
        /// </summary>
        /// <param name="supplierSet">仕入先クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 仕入先クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(SupplierSet supplierSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (supplierSet.SupplierCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERCD] = supplierSet.SupplierCd.ToString("000000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERSNM] = supplierSet.SupplierSnm;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERKANA] = supplierSet.SupplierKana;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERTELNO] = supplierSet.SupplierTelNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERTELNO1] = supplierSet.SupplierTelNo1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERTELNO2] = supplierSet.SupplierTelNo2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERPOSTNO] = supplierSet.SupplierPostNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERADDRALL] = supplierSet.SupplierAddr1.Trim() + " " + supplierSet.SupplierAddr3.Trim() + " " + supplierSet.SupplierAddr4.Trim();
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERADDR1] = supplierSet.SupplierAddr1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERADDR3] = supplierSet.SupplierAddr3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERADDR4] = supplierSet.SupplierAddr4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTTOTALDAY] = supplierSet.PaymentTotalDay;
            //if (Supplier.GetPaymentCondName(supplierSet.PaymentCond).Equals(string.Empty)) // DEL 2009/03/25
            if (this.GetPaymentCondName(supplierSet.PaymentCond).Equals(string.Empty)) // ADD 2009/03/25
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTCOND] = supplierSet.PaymentCond.ToString();
            }
            else
            {
                //this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTCOND] = supplierSet.PaymentCond.ToString() + ":" + Supplier.GetPaymentCondName(supplierSet.PaymentCond); // DEL 2009/03/25
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTCOND] = supplierSet.PaymentCond.ToString() + ":" + this.GetPaymentCondName(supplierSet.PaymentCond); // ADD 2009/03/25
            }
            if (supplierSet.PaymentDay == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTMONTHDAY] = supplierSet.PaymentMonthName;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTMONTHDAY] = supplierSet.PaymentMonthName + supplierSet.PaymentDay;
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTMONTHNAME] = supplierSet.PaymentMonthName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTDAY] = supplierSet.PaymentDay;
            if (supplierSet.StockAgentCode.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKAGENTCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKAGENTCODE] = supplierSet.StockAgentCode.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKAGENTNAME] = supplierSet.StockAgentName;
            if (supplierSet.MngSectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MNGSECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MNGSECTIONCODE] = supplierSet.MngSectionCode.Trim().PadLeft(2, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDENM] = supplierSet.SectionGuideNm;
            if (supplierSet.PaymentSectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTSECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYMENTSECTIONCODE] = supplierSet.PaymentSectionCode.Trim().PadLeft(2, '0');
            }
            if (supplierSet.PayeeCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYEECODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYEECODE] = supplierSet.PayeeCode.ToString("000000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PAYEESNM] = supplierSet.PayeeSnm;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(SUPPLIERCD, typeof(string));				// 仕入先コード 
            PrintSetTable.Columns.Add(SUPPLIERSNM, typeof(string));				// 仕入先略称 
            PrintSetTable.Columns.Add(SUPPLIERKANA, typeof(string));			// 仕入先カナ
            PrintSetTable.Columns.Add(SUPPLIERTELNO, typeof(string));			// 仕入先電話番号 
            PrintSetTable.Columns.Add(SUPPLIERTELNO1, typeof(string));			// 仕入先電話番号1 
            PrintSetTable.Columns.Add(SUPPLIERTELNO2, typeof(string));			// 仕入先電話番号2 
            PrintSetTable.Columns.Add(SUPPLIERPOSTNO, typeof(string));			// 仕入先郵便番号 
            PrintSetTable.Columns.Add(SUPPLIERADDRALL, typeof(string));			// 仕入先住所ALL
            PrintSetTable.Columns.Add(SUPPLIERADDR1, typeof(string));			// 仕入先住所1（都道府県市区郡・町村・字） 
            PrintSetTable.Columns.Add(SUPPLIERADDR3, typeof(string));			// 仕入先住所3（番地） 
            PrintSetTable.Columns.Add(SUPPLIERADDR4, typeof(string));			// 仕入先住所4（アパート名称） 
            PrintSetTable.Columns.Add(PAYMENTTOTALDAY, typeof(Int32));			// 支払締日 
            PrintSetTable.Columns.Add(PAYMENTCOND, typeof(string));				// 支払条件 
            PrintSetTable.Columns.Add(PAYMENTMONTHDAY, typeof(string));		    // 支払月日
            PrintSetTable.Columns.Add(PAYMENTMONTHNAME, typeof(string));		// 支払月区分名称 
            PrintSetTable.Columns.Add(PAYMENTDAY, typeof(Int32));				// 支払日 
            PrintSetTable.Columns.Add(STOCKAGENTCODE, typeof(string));			// 仕入担当者コード 
            PrintSetTable.Columns.Add(STOCKAGENTNAME, typeof(string));			// 仕入担当者名
            PrintSetTable.Columns.Add(MNGSECTIONCODE, typeof(string));			// 管理拠点コード 
            PrintSetTable.Columns.Add(SECTIONGUIDENM, typeof(string));			// 拠点ガイド名称 
            PrintSetTable.Columns.Add(PAYMENTSECTIONCODE, typeof(string));		// 支払拠点コード 
            PrintSetTable.Columns.Add(PAYEECODE, typeof(string));				// 支払先コード 
            PrintSetTable.Columns.Add(PAYEESNM, typeof(string));				// 支払先先略称 


            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet関連

        // --- ADD 2009/03/25 -------------------------------->>>>>
        #region 仕入先情報取得
        /// <summary>
        /// 金種名称取得処理
        /// </summary>
        /// <param name="paymentCond"></param>
        /// <returns></returns>
        private string GetPaymentCondName(int paymentCond)
        {
            // 金額種別設定マスタ読込
            if (this._moneyKindDic == null || this._moneyKindDic.Count == 0)
            {
                this.ReadMoneyKind();
            }

            if (this._moneyKindDic != null && this._moneyKindDic.Count != 0)
            {
                if (this._moneyKindDic.ContainsKey(paymentCond))
                {
                    return this._moneyKindDic[paymentCond].MoneyKindName;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 金額種別設定マスタ読込
        /// </summary>
        private void ReadMoneyKind()
        {
            this._moneyKindDic = new Dictionary<int, MoneyKind>();

            int status;
            ArrayList retList = new ArrayList();

            if (this._moneyKindAcs == null)
            {
                this._moneyKindAcs = new MoneyKindAcs();
            }

            status = this._moneyKindAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (MoneyKind moneyKind in retList)
                {
                    // 金額設定区分が「0:入金」を使用
                    if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                    {
                        this._moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }
            }
        }
        #endregion
        // --- ADD 2009/03/25 --------------------------------<<<<<
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08560UA
        #region ◎ PMKHN08560UA_Load Event
        /// <summary>
        /// PMKHN08560UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08560UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;


            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }
        #endregion

        #endregion ◆ PMKHN08560UA

        /// <summary>
        /// 仕入先ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // インスタンス生成
                    _supplierAcs = new SupplierAcs();
                }

                // ガイド起動
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // 項目に展開
                string tag = (string)((UltraButton)sender).Tag;
                TNedit targetControl = null;
                Control nextControl = null;
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this.tNedit_SupplierCd_St;
                    nextControl = this.tNedit_SupplierCd_Ed;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this.tNedit_SupplierCd_Ed;
                    nextControl = this.tEdit_SupplierNm_St;
                }
                else
                {
                    return;
                }

                // ADD 2008/11/27 不具合対応[8311] ---------->>>>>
                if (status != 0)
                {
                    return;
                }
                // ADD 2008/11/27 不具合対応[8311] ----------<<<<<


                // コード展開
                targetControl.SetInt(supplier.SupplierCd);
                // フォーカス
                nextControl.Focus();

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 数値項目終了脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// グループ圧縮イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        
        /// <summary>
        /// 削除指定設定時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_LogicalDeleteCode_ValueChanged(object sender, EventArgs e)
        {
            if ((int)tComboEditor_LogicalDeleteCode.Value == 1)
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.Now);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.Now);
            }
            else
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
            }
        }
        #endregion ■ Control Event

    }
}