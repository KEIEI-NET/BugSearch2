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
    /// 売上目標設定マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上目標設定マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public partial class PMKHN08630UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 売上目標設定マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上目標設定マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08630UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._salesTargetSetAcs = new SalesTargetSetAcs();
            
            this._secInfoSetAcs = new SecInfoSetAcs();
            
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
        private SalesTargetPrintWork _salesTargetPrintWork;

        // データアクセス
        private SalesTargetSetAcs _salesTargetSetAcs;
        
        private SecInfoSetAcs _secInfoSetAcs;

        private SubSectionAcs _subSectionAcs;

        // 担当者ガイド用
        private EmployeeAcs _employeeAcs;

        // ユーザーガイド用
        private UserGuideAcs _userGuideAcs;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;
        private UltraButton _customerGuideSender;

        private Hashtable secInfoSetTable;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08630UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08630U";
        //// 帳票名称
        private string _printName = "売上目標設定マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "SALESTARGETSET";

        // dataview名称用
        private const string SECTIONCODE = "sectioncode";
        private const string SECTIONGUIDESNM = "sectionguidesnm";
        private const string SUBSECTIONCODE = "subsectioncode";
        private const string SUBSECTIONNAME = "subsectionname";
        private const string SALESEMPLOYEECD = "salesemployeecd";
        private const string SALESEMPLOYEENM = "salesemployeenm";
        private const string FRONTEMPLOYEECD = "frontemployeecd";
        private const string FRONTEMPLOYEENM = "frontemployeenm";
        private const string SALESINPUTCODE = "salesinputcode";
        private const string SALESINPUTNAME = "salesinputname";
        private const string SALESCODE = "salescode";
        private const string SALESCODENAME = "salescodename";
        private const string ENTERPRISEGANRECODE = "enterpriseganrecode";
        private const string ENTERPRISEGANRECODENAME = "enterpriseganrecodename";
        private const string CUSTOMERCODE = "customercode";
        private const string CUSTOMERSNM = "customersnm";
        private const string BUSINESSTYPECODE = "businesstypecode";
        private const string BUSINESSTYPECODENAME = "businesstypecodename";
        private const string SALESAREACODE = "salesareacode";
        private const string SALESAREACODENAME = "salesareacodename";
        private const string SALESTARGETMONEY1 = "salestargetmoney1";
        private const string SALESTARGETMONEY2 = "salestargetmoney2";
        private const string SALESTARGETMONEY3 = "salestargetmoney3";
        private const string SALESTARGETMONEY4 = "salestargetmoney4";
        private const string SALESTARGETMONEY5 = "salestargetmoney5";
        private const string SALESTARGETMONEY6 = "salestargetmoney6";
        private const string SALESTARGETMONEY7 = "salestargetmoney7";
        private const string SALESTARGETMONEY8 = "salestargetmoney8";
        private const string SALESTARGETMONEY9 = "salestargetmoney9";
        private const string SALESTARGETMONEY10 = "salestargetmoney10";
        private const string SALESTARGETMONEY11 = "salestargetmoney11";
        private const string SALESTARGETMONEY12 = "salestargetmoney12";
        private const string SALESTARGETMONEYALL = "salestargetmoneyall";
        private const string SALESTARGETPROFIT1 = "salestargetprofit1";
        private const string SALESTARGETPROFIT2 = "salestargetprofit2";
        private const string SALESTARGETPROFIT3 = "salestargetprofit3";
        private const string SALESTARGETPROFIT4 = "salestargetprofit4";
        private const string SALESTARGETPROFIT5 = "salestargetprofit5";
        private const string SALESTARGETPROFIT6 = "salestargetprofit6";
        private const string SALESTARGETPROFIT7 = "salestargetprofit7";
        private const string SALESTARGETPROFIT8 = "salestargetprofit8";
        private const string SALESTARGETPROFIT9 = "salestargetprofit9";
        private const string SALESTARGETPROFIT10 = "salestargetprofit10";
        private const string SALESTARGETPROFIT11 = "salestargetprofit11";
        private const string SALESTARGETPROFIT12 = "salestargetprofit12";
        private const string SALESTARGETPROFITALL = "salestargetprofitall";

        private const string SECTIONCODE_TITLE = "拠点";
        private const string SECTIONGUIDESNM_TITLE = "拠点名";
        private const string SUBSECTIONCODE_TITLE = "部門";
        private const string SUBSECTIONNAME_TITLE = "部門名";
        private const string SALESEMPLOYEECD_TITLE = "担当者";
        private const string SALESEMPLOYEENM_TITLE = "担当者名";
        private const string FRONTEMPLOYEECD_TITLE = "受注者";
        private const string FRONTEMPLOYEENM_TITLE = "受注者名";
        private const string SALESINPUTCODE_TITLE = "発行者";
        private const string SALESINPUTNAME_TITLE = "発行者名";
        private const string SALESCODE_TITLE = "販売区分";
        private const string SALESCODENAME_TITLE = "販売区分名";
        private const string ENTERPRISEGANRECODE_TITLE = "商品区分";
        private const string ENTERPRISEGANRECODENAME_TITLE = "商品区分名";
        private const string CUSTOMERCODE_TITLE = "得意先";
        private const string CUSTOMERSNM_TITLE = "得意先名";
        private const string BUSINESSTYPECODE_TITLE = "業種";
        private const string BUSINESSTYPECODENAME_TITLE = "業種名";
        private const string SALESAREACODE_TITLE = "地区";
        private const string SALESAREACODENAME_TITLE = "地区名";
        private const string SALESTARGETMONEY1_TITLE = "売上１";
        private const string SALESTARGETMONEY2_TITLE = "売上２";
        private const string SALESTARGETMONEY3_TITLE = "売上３";
        private const string SALESTARGETMONEY4_TITLE = "売上４";
        private const string SALESTARGETMONEY5_TITLE = "売上５";
        private const string SALESTARGETMONEY6_TITLE = "売上６";
        private const string SALESTARGETMONEY7_TITLE = "売上７";
        private const string SALESTARGETMONEY8_TITLE = "売上８";
        private const string SALESTARGETMONEY9_TITLE = "売上９";
        private const string SALESTARGETMONEY10_TITLE = "売上１０";
        private const string SALESTARGETMONEY11_TITLE = "売上１１";
        private const string SALESTARGETMONEY12_TITLE = "売上１２";
        private const string SALESTARGETMONEYALL_TITLE = "売上合計";
        private const string SALESTARGETPROFIT1_TITLE = "粗利１";
        private const string SALESTARGETPROFIT2_TITLE = "粗利２";
        private const string SALESTARGETPROFIT3_TITLE = "粗利３";
        private const string SALESTARGETPROFIT4_TITLE = "粗利４";
        private const string SALESTARGETPROFIT5_TITLE = "粗利５";
        private const string SALESTARGETPROFIT6_TITLE = "粗利６";
        private const string SALESTARGETPROFIT7_TITLE = "粗利７";
        private const string SALESTARGETPROFIT8_TITLE = "粗利８";
        private const string SALESTARGETPROFIT9_TITLE = "粗利９";
        private const string SALESTARGETPROFIT10_TITLE = "粗利１０";
        private const string SALESTARGETPROFIT11_TITLE = "粗利１１";
        private const string SALESTARGETPROFIT12_TITLE = "粗利１２";
        private const string SALESTARGETPROFITALL_TITLE = "粗利合計";



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
                status = this._salesTargetSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._salesTargetPrintWork);
            }
            else
            {
                status = this._salesTargetSetAcs.SearchDelete(
                    out PrintSets,
                    this._enterpriseCode,
                    this._salesTargetPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {

                        // 商品クラスをデータセットへ展開する
                        int index = 0;
                        foreach (SalesTargetSet salesTargetSet in PrintSets)
                        {

                            SecPrintSetToDataSet(salesTargetSet.Clone(), index);
                            ++index;
                        }

                        // 基本の並び順を設定
                        string str_sort = SECTIONCODE;
                        switch ((int)this.tComboEditor_PrintType.Value)
                        {
                            case 1: //拠点-部門 
                                str_sort += " , " + SUBSECTIONCODE;
                                break;
                            case 2: //拠点-担当者 
                                str_sort += " , " + SALESEMPLOYEECD;
                                break;
                            case 3: //拠点-受注者 
                                str_sort += " , " + FRONTEMPLOYEECD;
                                break;
                            case 4: //拠点-発行者 
                                str_sort += " , " + SALESINPUTCODE;
                                break;
                            case 5: //拠点-販売区分 
                                str_sort += " , " + SALESCODE;
                                break;
                            case 6: //商品区分 
                                //str_sort += " , " + ENTERPRISEGANRECODE;    // DEL 2008/12/02 不具合対応[8535]
                                str_sort = ENTERPRISEGANRECODE;    // ADD 2008/12/02 不具合対応[8535]
                                break;
                            case 7: //拠点-得意先 
                                str_sort += " , " + CUSTOMERCODE;
                                break;
                            case 8: //拠点-業種 
                                str_sort += " , " + BUSINESSTYPECODE;
                                break;
                            case 9: //拠点-地区
                                str_sort += " , " + SALESAREACODE;
                                break;
                        }

                        this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = str_sort;

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
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        // DEL 2008/12/03 不具合対応[8649] ---------->>>>>
                        //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);  // ADD 2008/11/27 不具合対応[8318]
                        // DEL 2008/12/03 不具合対応[8649] ----------<<<<<
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN08630U", 						// アセンブリＩＤまたはクラスＩＤ
                            "売上目標設定マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._salesTargetSetAcs, 				// エラーが発生したオブジェクト
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
            printInfo.jyoken = this._salesTargetPrintWork;
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
            this._salesTargetPrintWork = new SalesTargetPrintWork();

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
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 金額
            sizeCell.Width = 120;
            sizeHeader.Width = 120;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            sizeCell.Width = 150;
            sizeHeader.Width = 150;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            #region ヘッダ名称
            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Header.Caption = SECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Header.Caption = SECTIONGUIDESNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Header.Caption = SUBSECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Header.Caption = SUBSECTIONNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Header.Caption = SALESEMPLOYEECD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Header.Caption = SALESEMPLOYEENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Header.Caption = FRONTEMPLOYEECD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Header.Caption = FRONTEMPLOYEENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Header.Caption = SALESINPUTCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Header.Caption = SALESINPUTNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Header.Caption = SALESCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Header.Caption = SALESCODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Header.Caption = ENTERPRISEGANRECODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Header.Caption = ENTERPRISEGANRECODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Header.Caption = BUSINESSTYPECODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Header.Caption = BUSINESSTYPECODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Header.Caption = SALESAREACODE_TITLE;            
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Header.Caption = SALESAREACODENAME_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Hidden = false;

            DateTime startMonth = DateTime.Parse(this._salesTargetPrintWork.TargetDivideCodeSt.ToString().Substring(0, 4) + "/" +
                                                 this._salesTargetPrintWork.TargetDivideCodeSt.ToString().Substring(4, 2) + "/01");
            DateTime endMonth = DateTime.Parse(this._salesTargetPrintWork.TargetDivideCodeEd.ToString().Substring(0, 4) + "/" +
                                               this._salesTargetPrintWork.TargetDivideCodeEd.ToString().Substring(4, 2) + "/01");

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Header.Caption = startMonth.Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Header.Caption = startMonth.Month + "月";

            if (startMonth.AddMonths(1) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Header.Caption = startMonth.AddMonths(1).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Header.Caption = startMonth.AddMonths(1).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(2) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Header.Caption = startMonth.AddMonths(2).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Header.Caption = startMonth.AddMonths(2).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(3) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Header.Caption = startMonth.AddMonths(3).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Header.Caption = startMonth.AddMonths(3).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(4) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Header.Caption = startMonth.AddMonths(4).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Header.Caption = startMonth.AddMonths(4).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(5) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Header.Caption = startMonth.AddMonths(5).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Header.Caption = startMonth.AddMonths(5).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(6) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Header.Caption = startMonth.AddMonths(6).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Header.Caption = startMonth.AddMonths(6).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(7) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Header.Caption = startMonth.AddMonths(7).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Header.Caption = startMonth.AddMonths(7).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(8) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Header.Caption = startMonth.AddMonths(8).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Header.Caption = startMonth.AddMonths(8).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(9) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Header.Caption = startMonth.AddMonths(9).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Header.Caption = startMonth.AddMonths(9).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(10) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Header.Caption = startMonth.AddMonths(10).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Header.Caption = startMonth.AddMonths(10).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            if (startMonth.AddMonths(11) <= endMonth)
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Header.Caption = startMonth.AddMonths(11).Month + "月";
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Header.Caption = startMonth.AddMonths(11).Month + "月";
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
            }
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Header.Caption = SALESTARGETMONEY1_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Header.Caption = SALESTARGETMONEY2_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Header.Caption = SALESTARGETMONEY3_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Header.Caption = SALESTARGETMONEY4_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Header.Caption = SALESTARGETMONEY5_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Header.Caption = SALESTARGETMONEY6_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Header.Caption = SALESTARGETMONEY7_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Header.Caption = SALESTARGETMONEY8_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Header.Caption = SALESTARGETMONEY9_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Header.Caption = SALESTARGETMONEY10_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Header.Caption = SALESTARGETMONEY11_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Header.Caption = SALESTARGETMONEY12_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Header.Caption = SALESTARGETPROFIT1_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Header.Caption = SALESTARGETPROFIT2_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Header.Caption = SALESTARGETPROFIT3_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Header.Caption = SALESTARGETPROFIT4_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Header.Caption = SALESTARGETPROFIT5_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Header.Caption = SALESTARGETPROFIT6_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Header.Caption = SALESTARGETPROFIT7_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Header.Caption = SALESTARGETPROFIT8_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Header.Caption = SALESTARGETPROFIT9_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Header.Caption = SALESTARGETPROFIT10_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Header.Caption = SALESTARGETPROFIT11_TITLE;
            //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Header.Caption = SALESTARGETPROFIT12_TITLE;


            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Header.Caption = SALESTARGETMONEYALL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Header.Caption = SALESTARGETPROFITALL_TITLE;

            #endregion

            #region 非表示処理
            switch ((int)this.tComboEditor_PrintDiv.Value)
            {
                case 0:
                    // 粗利を非表示
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Hidden = true;
                    break;
                case 1:
                    // 売上を非表示
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Hidden = true;
                    break;
                case 2:

                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = false;
                    //UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Hidden = false;
                    break;
            }
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 0: //拠点
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 1: //拠点-部門 
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 2: //拠点-担当者 
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 3: //拠点-受注者 
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 4: //拠点-発行者 
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 5: //拠点-販売区分
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 6: //商品区分
                    // ADD 2008/12/02 不具合対応[8535] ---------->>>>>
                    UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Hidden = true;
                    // ADD 2008/12/02 不具合対応[8535] ----------<<<<<

                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 7: //拠点-得意先 
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 8: //拠点-業種 
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 9: //拠点-地区
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = false;
                    break;
            }
            #endregion

            // 文字表示位置の設定
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;


            // 表示フォーマットの設定
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Format = "#,##0";


            #region 列配置

            int i_spanY = 0;
            if ((int)this.tComboEditor_PrintDiv.Value == 2)
            {
                i_spanY = 2;
            }

            // 1行目

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //拠点-部門 

                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 2: //拠点-担当者 
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 3: //拠点-受注者 
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 4: //拠点-発行者 
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 5: //拠点-販売区分
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 6: //商品区分
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.OriginX = 6;  
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 7: //拠点-得意先 
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 8: //拠点-業種 
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 9: //拠点-地区
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginX = 6;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.OriginX = 8;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
            }


            int cnt = 0;

            if ((int)this.tComboEditor_PrintType.Value != 0)
            {
                cnt = 4;
            }
            
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.OriginX = 6 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.OriginX = 8 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.OriginX = 6 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.OriginX = 8 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.SpanY = 2; 

            #endregion 列配置
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            //印刷パターン
            if (this._salesTargetPrintWork.PrintType != (int)this.tComboEditor_PrintType.Value)
            {
                status = false;
                return status;
            }

            //印刷区分
            if (this._salesTargetPrintWork.PrintDiv != (int)this.tComboEditor_PrintDiv.Value)
            {
                status = false;
                return status;
            }

            // 開始年月]
            if (this.TargetDivideCodeSt_tDateEdit.GetLongDate() == 0)
            {
                if (this._salesTargetPrintWork.TargetDivideCodeSt != this.TargetDivideCodeSt_tDateEdit.GetLongDate())
                {
                    status = false;
                    return status;
                }
            }
            else
            {
                if (this._salesTargetPrintWork.TargetDivideCodeSt != Int32.Parse(this.TargetDivideCodeSt_tDateEdit.GetLongDate().ToString().Substring(0, 6)))
                {
                    status = false;
                    return status;
                }
            }

            // 終了年月
            if (this.TargetDivideCodeEd_tDateEdit.GetLongDate() == 0)
            {
                if (this._salesTargetPrintWork.TargetDivideCodeEd != this.TargetDivideCodeEd_tDateEdit.GetLongDate())
                {
                    status = false;
                    return status;
                }
            }
            else
            {
            if (this._salesTargetPrintWork.TargetDivideCodeEd != Int32.Parse(this.TargetDivideCodeEd_tDateEdit.GetLongDate().ToString().Substring(0, 6)))
            {
                status = false;
                return status;
            }
            }

            //開始拠点
            if (this._salesTargetPrintWork.SectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }

            //終了拠点
            if (this._salesTargetPrintWork.SectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //拠点-部門 
                    if (this._salesTargetPrintWork.SubSectionCodeSt != this.tNedit_SubSectionCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._salesTargetPrintWork.SubSectionCodeEd != this.tNedit_SubSectionCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 2: //拠点-担当者 
                case 3: //拠点-受注者 
                case 4: //拠点-発行者 
                    if (this._salesTargetPrintWork.EmployeeCodeSt != this.tEdit_EmployeeCode_St.DataText)
                    {
                        status = false;
                        return status;
                    }
                    if (this._salesTargetPrintWork.EmployeeCodeEd != this.tEdit_EmployeeCode_Ed.DataText)
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 5: //拠点-販売区分 
                    if (this._salesTargetPrintWork.SalesCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._salesTargetPrintWork.SalesCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 6: //商品区分 
                    if (this._salesTargetPrintWork.EnterpriseGanreCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._salesTargetPrintWork.EnterpriseGanreCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 7: //拠点-得意先 
                    if (this._salesTargetPrintWork.CustomerCodeSt != this.tNedit_CustomerCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._salesTargetPrintWork.CustomerCodeEd != this.tNedit_CustomerCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 8: //拠点-業種 
                    if (this._salesTargetPrintWork.BusinessTypeCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._salesTargetPrintWork.BusinessTypeCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 9: //拠点-地区
                    if (this._salesTargetPrintWork.SalesAreaCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._salesTargetPrintWork.SalesAreaCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
            }
            
            // 削除指定
            if (this._salesTargetPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._salesTargetPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._salesTargetPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
                this.tEdit_SectionCode_St.DataText = string.Empty;
                this.tEdit_SectionCode_Ed.DataText = string.Empty;
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                this.tNedit_SubSectionCode_St.DataText = string.Empty;
                this.tNedit_SubSectionCode_Ed.DataText = string.Empty;
                this.tNedit_GuideCode_St.DataText = string.Empty;
                this.tNedit_GuideCode_Ed.DataText = string.Empty;
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                this.TargetDivideCodeSt_tDateEdit.SetDateTime(DateTime.MinValue);
                this.TargetDivideCodeEd_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.ub_St_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SubSectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SubSectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.CustomerCdSt_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.CustomerCdEd_GuideBtn, Size16_Index.STAR1);

                // コンボの初期化
                this.tComboEditor_PrintType.Value = 0;
                this.tComboEditor_PrintDiv.Value = 0;

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // サブ項目の非表示
                this.pn_Employee.Visible = false;
                this.pn_SubSection.Visible = false;
                this.pn_Guide.Visible = false;
                this.pn_Customer.Visible = false;

                // 初期フォーカスセット
                this.tComboEditor_PrintType.Focus();
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
            DateGetAcs _dateGetAcs;
            _dateGetAcs = DateGetAcs.GetInstance();

            // DEL 2008/11/27 不具合対応[8341] ---------->>>>>
            //List<DateTime> startMonthDate;
            //List<DateTime> endMonthDate;
            //List<DateTime> yearMonth;
            // DEL 2008/11/27 不具合対応[8341] ----------<<<<<

            // ADD 2008/11/27 不具合対応[8341] ---------->>>>>
            Int32 year;
            Int32 addYearsFromThis;
            DateTime startYearDate;
            DateTime endYearDate;
            // ADD 2008/11/27 不具合対応[8341] ----------<<<<<

            DateTime wkDate;

            // 年月
            if (IsErrorTDateEdit(this.TargetDivideCodeSt_tDateEdit, false, false, out errMessage) == false)
            {
                errMessage = "年月の指定に誤りがあります。";
                errComponent = this.TargetDivideCodeSt_tDateEdit;
                return (false);
            }

            if (IsErrorTDateEdit(this.TargetDivideCodeEd_tDateEdit, false, false, out errMessage) == false)
            {
                errMessage = "年月の指定に誤りがあります。";
                errComponent = this.TargetDivideCodeEd_tDateEdit;
                return (false);
            }
            
            // 範囲チェック
            if ((this.TargetDivideCodeSt_tDateEdit.GetLongDate() != 0) &&
                (this.TargetDivideCodeEd_tDateEdit.GetLongDate() != 0))
            {

                if (this.TargetDivideCodeSt_tDateEdit.GetLongDate() > this.TargetDivideCodeEd_tDateEdit.GetLongDate())
                {
                    errMessage = "年月の範囲指定に誤りがあります。";
                    errComponent = SerchSlipDataStRF_tDateEdit;
                    return (false);
                }

                wkDate = DateTime.Parse(this.TargetDivideCodeSt_tDateEdit.GetDateYear("yyyy") + "/" + this.TargetDivideCodeSt_tDateEdit.GetDateMonth() + "/01");
                // DEL 2008/11/27 不具合対応[8341] ---------->>>>>
                //_dateGetAcs.GetFinancialYearTable(wkDate, out startMonthDate, out endMonthDate, out yearMonth);
                //if (this.TargetDivideCodeEd_tDateEdit.GetLongDate() > Int32.Parse(yearMonth[11].ToString("yyyyMMdd")))
                // DEL 2008/11/27 不具合対応[8341] ----------<<<<<

                // ADD 2008/11/27 不具合対応[8341] ---------->>>>>
                _dateGetAcs.GetYearFromMonth(wkDate, out year, out addYearsFromThis, out startYearDate, out endYearDate);
                if (this.TargetDivideCodeEd_tDateEdit.GetLongDate() > Int32.Parse(endYearDate.ToString("yyyyMMdd")))
                // ADD 2008/11/27 不具合対応[8341] ----------<<<<<
                {
                    errMessage = "年度の範囲内で指定してください。";
                    errComponent = SerchSlipDataStRF_tDateEdit;
                    return (false);
                }
            }

            // 拠点コード
            if (
                (this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this.tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("拠点{0}", ct_RangeError);
                errComponent = this.tEdit_SectionCode_St;
                return (false);
            }

            // 担当者コード
            if (
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this.tEdit_EmployeeCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
                errComponent = this.tEdit_EmployeeCode_St;
                return (false);
            }

            // ADD 2008/11/27 不具合対応[8351] ---------->>>>>
            // 部門
            if (
                (this.tNedit_SubSectionCode_St.GetInt() != 0) &&
                (this.tNedit_SubSectionCode_Ed.GetInt() != 0) &&
                this.tNedit_SubSectionCode_St.GetInt() > this.tNedit_SubSectionCode_Ed.GetInt())
            {
                errMessage = string.Format("部門{0}", ct_RangeError);
                errComponent = this.tNedit_SubSectionCode_St;
                status = false;
                return (false);
            }

            // 各種コード
            if (
                (this.tNedit_GuideCode_St.GetInt() != 0) &&
                (this.tNedit_GuideCode_Ed.GetInt() != 0) &&
                this.tNedit_GuideCode_St.GetInt() > this.tNedit_GuideCode_Ed.GetInt())
            {
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 5:
                        errMessage = string.Format("販売区分{0}", ct_RangeError);
                        break;
                    case 6:
                        errMessage = string.Format("商品区分{0}", ct_RangeError);
                        break;
                    case 8:
                        errMessage = string.Format("業種{0}", ct_RangeError);
                        break;
                    case 9:
                        errMessage = string.Format("地区{0}", ct_RangeError);
                        break;
                }
                errComponent = this.tNedit_GuideCode_St;
                status = false;
                return (false);
            }

            // 得意先
            if (
                (this.tNedit_CustomerCode_St.GetInt() != 0) &&
                (this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
                return (false);
            }
            
            // ADD 2008/11/27 不具合対応[8351] ----------<<<<<

            // 削除日付
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, true, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    return (false);
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, true, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    return (false);
                }

                // 範囲チェック
                if ((this.SerchSlipDataStRF_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.SerchSlipDataEdRF_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.SerchSlipDataStRF_tDateEdit.GetDateTime() > this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
                    {
                        errMessage = "削除日付の範囲指定に誤りがあります。";
                        errComponent = SerchSlipDataStRF_tDateEdit;
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
        /// <param name="DayCheck"></param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, bool DayCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if (DayCheck)
                {
                    if ((year == 0) || (month == 0) || (day == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
                else
                {
                    if ((year == 0) || (month == 0) )
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }
                if (DayCheck)
                {                   

                    if ((year == 0) || (month == 0) || (day == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
                else
                {
                    if ((year == 0) || (month == 0) )
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
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

            DateGetAcs _dateGetAcs;
            _dateGetAcs = DateGetAcs.GetInstance();

            // DEL 2008/11/27 不具合対応[8341] ---------->>>>>
            //List<DateTime> startMonthDate;
            //List<DateTime> endMonthDate;
            //List<DateTime> yearMonth;
            // DEL 2008/11/27 不具合対応[8341] ----------<<<<<

            // ADD 2008/11/27 不具合対応[8341] ---------->>>>>
            Int32 year;
            Int32 addYearsFromThis;
            DateTime startYearDate;
            DateTime endYearDate;
            // ADD 2008/11/27 不具合対応[8341] ----------<<<<<
            DateTime wkDate;

            try
            {
                //印刷パターン
                this._salesTargetPrintWork.PrintType = (int)this.tComboEditor_PrintType.Value;

                //印刷区分
                this._salesTargetPrintWork.PrintDiv = (int)this.tComboEditor_PrintDiv.Value;
                
                // 開始年月
                if (this.TargetDivideCodeSt_tDateEdit.GetLongDate() == 0)
                {
                    if (this.TargetDivideCodeEd_tDateEdit.GetLongDate() == 0)
                    {
                        wkDate = DateTime.Today;
                    }
                    else
                    {
                        wkDate = DateTime.Parse(this.TargetDivideCodeEd_tDateEdit.GetDateYear("yyyy") + "/" + this.TargetDivideCodeEd_tDateEdit.GetDateMonth() + "/01");
                    
                    }
                    // DEL 2008/11/27 不具合対応[8341] ---------->>>>>                    
                    //_dateGetAcs.GetFinancialYearTable(wkDate, out startMonthDate, out endMonthDate, out yearMonth);
                    //this._salesTargetPrintWork.TargetDivideCodeSt = Int32.Parse(yearMonth[0].ToString("yyyyMM"));
                    // DEL 2008/11/27 不具合対応[8341] ----------<<<<<

                    // ADD 2008/11/27 不具合対応[8341] ---------->>>>>
                    _dateGetAcs.GetYearFromMonth(wkDate, out year, out addYearsFromThis, out startYearDate, out endYearDate);
                    this._salesTargetPrintWork.TargetDivideCodeSt = Int32.Parse(startYearDate.ToString("yyyyMM"));
                    // ADD 2008/11/27 不具合対応[8341] ----------<<<<<
                    
                }
                else
                {
                    this._salesTargetPrintWork.TargetDivideCodeSt = Int32.Parse(this.TargetDivideCodeSt_tDateEdit.GetLongDate().ToString().Substring(0,6));
                }

                // 終了年月
                if (this.TargetDivideCodeEd_tDateEdit.GetLongDate() == 0)
                {
                    if (this.TargetDivideCodeSt_tDateEdit.GetLongDate() == 0)
                    {
                        wkDate = DateTime.Today;
                    }
                    else
                    {
                        wkDate = DateTime.Parse(this.TargetDivideCodeSt_tDateEdit.GetDateYear("yyyy") + "/" + this.TargetDivideCodeSt_tDateEdit.GetDateMonth() + "/01");

                    }
                    // DEL 2008/11/27 不具合対応[8341] ---------->>>>> 
                    //_dateGetAcs.GetFinancialYearTable(wkDate, out startMonthDate, out endMonthDate, out yearMonth);
                    //this._salesTargetPrintWork.TargetDivideCodeEd = Int32.Parse(yearMonth[11].ToString("yyyyMM"));
                    // DEL 2008/11/27 不具合対応[8341] ----------<<<<<

                    // ADD 2008/11/27 不具合対応[8341] ---------->>>>>
                    _dateGetAcs.GetYearFromMonth(wkDate, out year, out addYearsFromThis, out startYearDate, out endYearDate);
                    this._salesTargetPrintWork.TargetDivideCodeEd = Int32.Parse(endYearDate.ToString("yyyyMM"));
                    // ADD 2008/11/27 不具合対応[8341] ----------<<<<<
                }
                else
                {
                    this._salesTargetPrintWork.TargetDivideCodeEd = Int32.Parse(this.TargetDivideCodeEd_tDateEdit.GetLongDate().ToString().Substring(0, 6));
                }                

                //開始拠点
                this._salesTargetPrintWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText;

                //終了拠点
                this._salesTargetPrintWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText;

                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: //拠点
                        this._salesTargetPrintWork.SubSectionCodeSt = 0;
                        this._salesTargetPrintWork.SubSectionCodeEd = 0;
                        this._salesTargetPrintWork.EmployeeCodeSt = "";
                        this._salesTargetPrintWork.EmployeeCodeEd = "";
                        this._salesTargetPrintWork.SalesCodeSt = 0;
                        this._salesTargetPrintWork.SalesCodeEd = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = 0;
                        this._salesTargetPrintWork.CustomerCodeSt = 0;
                        this._salesTargetPrintWork.CustomerCodeEd = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeSt = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeEd = 0;
                        this._salesTargetPrintWork.SalesAreaCodeSt = 0;
                        this._salesTargetPrintWork.SalesAreaCodeEd = 0;
                        break;
                    case 1: //拠点-部門 
                        this._salesTargetPrintWork.SubSectionCodeSt = this.tNedit_SubSectionCode_St.GetInt();
                        this._salesTargetPrintWork.SubSectionCodeEd = this.tNedit_SubSectionCode_Ed.GetInt();
                        this._salesTargetPrintWork.EmployeeCodeSt = "";
                        this._salesTargetPrintWork.EmployeeCodeEd = "";
                        this._salesTargetPrintWork.SalesCodeSt = 0;
                        this._salesTargetPrintWork.SalesCodeEd = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = 0;
                        this._salesTargetPrintWork.CustomerCodeSt = 0;
                        this._salesTargetPrintWork.CustomerCodeEd = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeSt = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeEd = 0;
                        this._salesTargetPrintWork.SalesAreaCodeSt = 0;
                        this._salesTargetPrintWork.SalesAreaCodeEd = 0;
                        break;
                    case 2: //拠点-担当者 
                    case 3: //拠点-受注者 
                    case 4: //拠点-発行者 
                        this._salesTargetPrintWork.SubSectionCodeSt = 0;
                        this._salesTargetPrintWork.SubSectionCodeEd = 0;
                        this._salesTargetPrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText;
                        this._salesTargetPrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText;
                        this._salesTargetPrintWork.SalesCodeSt = 0;
                        this._salesTargetPrintWork.SalesCodeEd = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = 0;
                        this._salesTargetPrintWork.CustomerCodeSt = 0;
                        this._salesTargetPrintWork.CustomerCodeEd = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeSt = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeEd = 0;
                        this._salesTargetPrintWork.SalesAreaCodeSt = 0;
                        this._salesTargetPrintWork.SalesAreaCodeEd = 0;
                        break;
                    case 5: //拠点-販売区分 
                        this._salesTargetPrintWork.SubSectionCodeSt = 0;
                        this._salesTargetPrintWork.SubSectionCodeEd = 0;
                        this._salesTargetPrintWork.EmployeeCodeSt = "";
                        this._salesTargetPrintWork.EmployeeCodeEd = "";
                        this._salesTargetPrintWork.SalesCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._salesTargetPrintWork.SalesCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = 0;
                        this._salesTargetPrintWork.CustomerCodeSt = 0;
                        this._salesTargetPrintWork.CustomerCodeEd = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeSt = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeEd = 0;
                        this._salesTargetPrintWork.SalesAreaCodeSt = 0;
                        this._salesTargetPrintWork.SalesAreaCodeEd = 0;
                        break;
                    case 6: //商品区分 
                        this._salesTargetPrintWork.SubSectionCodeSt = 0;
                        this._salesTargetPrintWork.SubSectionCodeEd = 0;
                        this._salesTargetPrintWork.EmployeeCodeSt = "";
                        this._salesTargetPrintWork.EmployeeCodeEd = "";
                        this._salesTargetPrintWork.SalesCodeSt = 0;
                        this._salesTargetPrintWork.SalesCodeEd = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        this._salesTargetPrintWork.CustomerCodeSt = 0;
                        this._salesTargetPrintWork.CustomerCodeEd = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeSt = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeEd = 0;
                        this._salesTargetPrintWork.SalesAreaCodeSt = 0;
                        this._salesTargetPrintWork.SalesAreaCodeEd = 0;
                        break;
                    case 7: //拠点-得意先 
                        this._salesTargetPrintWork.SubSectionCodeSt = 0;
                        this._salesTargetPrintWork.SubSectionCodeEd = 0;
                        this._salesTargetPrintWork.EmployeeCodeSt = "";
                        this._salesTargetPrintWork.EmployeeCodeEd = "";
                        this._salesTargetPrintWork.SalesCodeSt = 0;
                        this._salesTargetPrintWork.SalesCodeEd = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = 0;
                        this._salesTargetPrintWork.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                        this._salesTargetPrintWork.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                        this._salesTargetPrintWork.BusinessTypeCodeSt = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeEd = 0;
                        this._salesTargetPrintWork.SalesAreaCodeSt = 0;
                        this._salesTargetPrintWork.SalesAreaCodeEd = 0;
                        break;
                    case 8: //拠点-業種 
                        this._salesTargetPrintWork.SubSectionCodeSt = 0;
                        this._salesTargetPrintWork.SubSectionCodeEd = 0;
                        this._salesTargetPrintWork.EmployeeCodeSt = "";
                        this._salesTargetPrintWork.EmployeeCodeEd = "";
                        this._salesTargetPrintWork.SalesCodeSt = 0;
                        this._salesTargetPrintWork.SalesCodeEd = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = 0;
                        this._salesTargetPrintWork.CustomerCodeSt = 0;
                        this._salesTargetPrintWork.CustomerCodeEd = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._salesTargetPrintWork.BusinessTypeCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        this._salesTargetPrintWork.SalesAreaCodeSt = 0;
                        this._salesTargetPrintWork.SalesAreaCodeEd = 0;
                        break;
                    case 9: //拠点-地区
                        this._salesTargetPrintWork.SubSectionCodeSt = 0;
                        this._salesTargetPrintWork.SubSectionCodeEd = 0;
                        this._salesTargetPrintWork.EmployeeCodeSt = "";
                        this._salesTargetPrintWork.EmployeeCodeEd = "";
                        this._salesTargetPrintWork.SalesCodeSt = 0;
                        this._salesTargetPrintWork.SalesCodeEd = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeSt = 0;
                        this._salesTargetPrintWork.EnterpriseGanreCodeEd = 0;
                        this._salesTargetPrintWork.CustomerCodeSt = 0;
                        this._salesTargetPrintWork.CustomerCodeEd = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeSt = 0;
                        this._salesTargetPrintWork.BusinessTypeCodeEd = 0;
                        this._salesTargetPrintWork.SalesAreaCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._salesTargetPrintWork.SalesAreaCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        break;

                }
                // 削除指定区分
                this._salesTargetPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._salesTargetPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._salesTargetPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
            }
            catch (Exception)
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
        /// 商品クラスデータセット展開処理
        /// </summary>
        /// <param name="salesTargetSet">商品クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 商品クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(SalesTargetSet salesTargetSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            if (salesTargetSet.SectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = salesTargetSet.SectionCode.Trim().PadLeft(2, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = salesTargetSet.SectionGuideSnm;
            if (salesTargetSet.SubSectionCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUBSECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUBSECTIONCODE] = salesTargetSet.SubSectionCode.ToString("00");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUBSECTIONNAME] = salesTargetSet.SubSectionName;
            if (salesTargetSet.SalesEmployeeCd.Trim().PadLeft(4, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEECD] = salesTargetSet.SalesEmployeeCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEENM] = salesTargetSet.SalesEmployeeNm;
            if (salesTargetSet.FrontEmployeeCd.Trim().PadLeft(4, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEECD] = salesTargetSet.FrontEmployeeCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEENM] = salesTargetSet.FrontEmployeeNm;
            if (salesTargetSet.SalesInputCode.Trim().PadLeft(4, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTCODE] = salesTargetSet.SalesInputCode.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTNAME] = salesTargetSet.SalesInputName;
            if (salesTargetSet.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = salesTargetSet.SalesCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODENAME] = salesTargetSet.SalesCodeName;
            if (salesTargetSet.EnterpriseGanreCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERPRISEGANRECODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERPRISEGANRECODE] = salesTargetSet.EnterpriseGanreCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERPRISEGANRECODENAME] = salesTargetSet.EnterpriseGanreCodeName;
            if (salesTargetSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = salesTargetSet.CustomerCode.ToString("00000000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERSNM] = salesTargetSet.CustomerSnm;
            if (salesTargetSet.BusinessTypeCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BUSINESSTYPECODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BUSINESSTYPECODE] = salesTargetSet.BusinessTypeCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BUSINESSTYPECODENAME] = salesTargetSet.BusinessTypeCodeName;
            if (salesTargetSet.SalesAreaCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = salesTargetSet.SalesAreaCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODENAME] = salesTargetSet.SalesAreaCodeName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY1] = salesTargetSet.SalesTargetMoney1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY2] = salesTargetSet.SalesTargetMoney2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY3] = salesTargetSet.SalesTargetMoney3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY4] = salesTargetSet.SalesTargetMoney4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY5] = salesTargetSet.SalesTargetMoney5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY6] = salesTargetSet.SalesTargetMoney6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY7] = salesTargetSet.SalesTargetMoney7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY8] = salesTargetSet.SalesTargetMoney8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY9] = salesTargetSet.SalesTargetMoney9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY10] = salesTargetSet.SalesTargetMoney10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY11] = salesTargetSet.SalesTargetMoney11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY12] = salesTargetSet.SalesTargetMoney12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEYALL] = salesTargetSet.SalesTargetMoney1 +
                                                                                        salesTargetSet.SalesTargetMoney2 +
                                                                                        salesTargetSet.SalesTargetMoney3 +
                                                                                        salesTargetSet.SalesTargetMoney4 +
                                                                                        salesTargetSet.SalesTargetMoney5 +
                                                                                        salesTargetSet.SalesTargetMoney6 +
                                                                                        salesTargetSet.SalesTargetMoney7 +
                                                                                        salesTargetSet.SalesTargetMoney8 +
                                                                                        salesTargetSet.SalesTargetMoney9 +
                                                                                        salesTargetSet.SalesTargetMoney10 +
                                                                                        salesTargetSet.SalesTargetMoney11 +
                                                                                        salesTargetSet.SalesTargetMoney12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT1] = salesTargetSet.SalesTargetProfit1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT2] = salesTargetSet.SalesTargetProfit2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT3] = salesTargetSet.SalesTargetProfit3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT4] = salesTargetSet.SalesTargetProfit4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT5] = salesTargetSet.SalesTargetProfit5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT6] = salesTargetSet.SalesTargetProfit6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT7] = salesTargetSet.SalesTargetProfit7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT8] = salesTargetSet.SalesTargetProfit8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT9] = salesTargetSet.SalesTargetProfit9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT10] = salesTargetSet.SalesTargetProfit10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT11] = salesTargetSet.SalesTargetProfit11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT12] = salesTargetSet.SalesTargetProfit12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFITALL] = salesTargetSet.SalesTargetProfit1 +
                                                                                        salesTargetSet.SalesTargetProfit2 +
                                                                                        salesTargetSet.SalesTargetProfit3 +
                                                                                        salesTargetSet.SalesTargetProfit4 +
                                                                                        salesTargetSet.SalesTargetProfit5 +
                                                                                        salesTargetSet.SalesTargetProfit6 +
                                                                                        salesTargetSet.SalesTargetProfit7 +
                                                                                        salesTargetSet.SalesTargetProfit8 +
                                                                                        salesTargetSet.SalesTargetProfit9 +
                                                                                        salesTargetSet.SalesTargetProfit10 +
                                                                                        salesTargetSet.SalesTargetProfit11 +
                                                                                        salesTargetSet.SalesTargetProfit12;


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
            PrintSetTable.Columns.Add(SECTIONCODE, typeof(string));		            // 	拠点
            PrintSetTable.Columns.Add(SECTIONGUIDESNM, typeof(string));		        // 	拠点名
            PrintSetTable.Columns.Add(SUBSECTIONCODE, typeof(string));		        // 	部門
            PrintSetTable.Columns.Add(SUBSECTIONNAME, typeof(string));		        // 	部門名
            PrintSetTable.Columns.Add(SALESEMPLOYEECD, typeof(string));		        // 	担当者
            PrintSetTable.Columns.Add(SALESEMPLOYEENM, typeof(string));		        // 	担当者名
            PrintSetTable.Columns.Add(FRONTEMPLOYEECD, typeof(string));		        // 	受注者
            PrintSetTable.Columns.Add(FRONTEMPLOYEENM, typeof(string));		        // 	受注者名
            PrintSetTable.Columns.Add(SALESINPUTCODE, typeof(string));		        // 	発行者
            PrintSetTable.Columns.Add(SALESINPUTNAME, typeof(string));		        // 	発行者名
            PrintSetTable.Columns.Add(SALESCODE, typeof(string));		            // 	販売区分
            PrintSetTable.Columns.Add(SALESCODENAME, typeof(string));		        // 	販売区分名
            PrintSetTable.Columns.Add(ENTERPRISEGANRECODE, typeof(string));		    // 	商品区分
            PrintSetTable.Columns.Add(ENTERPRISEGANRECODENAME, typeof(string));		// 	商品区分名
            PrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		        // 	得意先
            PrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));		            // 	得意先名
            PrintSetTable.Columns.Add(BUSINESSTYPECODE, typeof(string));		    // 	業種
            PrintSetTable.Columns.Add(BUSINESSTYPECODENAME, typeof(string));		// 	業種名
            PrintSetTable.Columns.Add(SALESAREACODE, typeof(string));		        // 	地区
            PrintSetTable.Columns.Add(SALESAREACODENAME, typeof(string));		    // 	地区名
            PrintSetTable.Columns.Add(SALESTARGETMONEY1, typeof(Int64));		    // 	売上１
            PrintSetTable.Columns.Add(SALESTARGETMONEY2, typeof(Int64));		    // 	売上２
            PrintSetTable.Columns.Add(SALESTARGETMONEY3, typeof(Int64));		    // 	売上３
            PrintSetTable.Columns.Add(SALESTARGETMONEY4, typeof(Int64));		    // 	売上４
            PrintSetTable.Columns.Add(SALESTARGETMONEY5, typeof(Int64));		    // 	売上５
            PrintSetTable.Columns.Add(SALESTARGETMONEY6, typeof(Int64));		    // 	売上６
            PrintSetTable.Columns.Add(SALESTARGETMONEY7, typeof(Int64));		    // 	売上７
            PrintSetTable.Columns.Add(SALESTARGETMONEY8, typeof(Int64));		    // 	売上８
            PrintSetTable.Columns.Add(SALESTARGETMONEY9, typeof(Int64));		    // 	売上９
            PrintSetTable.Columns.Add(SALESTARGETMONEY10, typeof(Int64));		    // 	売上１０
            PrintSetTable.Columns.Add(SALESTARGETMONEY11, typeof(Int64));		    // 	売上１１
            PrintSetTable.Columns.Add(SALESTARGETMONEY12, typeof(Int64));		    // 	売上１２
            PrintSetTable.Columns.Add(SALESTARGETMONEYALL, typeof(Int64));		    // 	売上合計
            PrintSetTable.Columns.Add(SALESTARGETPROFIT1, typeof(Int64));		    // 	粗利１
            PrintSetTable.Columns.Add(SALESTARGETPROFIT2, typeof(Int64));		    // 	粗利２
            PrintSetTable.Columns.Add(SALESTARGETPROFIT3, typeof(Int64));		    // 	粗利３
            PrintSetTable.Columns.Add(SALESTARGETPROFIT4, typeof(Int64));		    // 	粗利４
            PrintSetTable.Columns.Add(SALESTARGETPROFIT5, typeof(Int64));		    // 	粗利５
            PrintSetTable.Columns.Add(SALESTARGETPROFIT6, typeof(Int64));		    // 	粗利６
            PrintSetTable.Columns.Add(SALESTARGETPROFIT7, typeof(Int64));		    // 	粗利７
            PrintSetTable.Columns.Add(SALESTARGETPROFIT8, typeof(Int64));		    // 	粗利８
            PrintSetTable.Columns.Add(SALESTARGETPROFIT9, typeof(Int64));		    // 	粗利９
            PrintSetTable.Columns.Add(SALESTARGETPROFIT10, typeof(Int64));		    // 	粗利１０
            PrintSetTable.Columns.Add(SALESTARGETPROFIT11, typeof(Int64));		    // 	粗利１１
            PrintSetTable.Columns.Add(SALESTARGETPROFIT12, typeof(Int64));		    // 	粗利１２
            PrintSetTable.Columns.Add(SALESTARGETPROFITALL, typeof(Int64));		    // 	粗利合計
            
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08630UA
        #region ◎ PMKHN08630UA_Load Event
        /// <summary>
        /// PMKHN08630UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08630UA_Load(object sender, EventArgs e)
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

        #endregion ◆ PMKHN08630UA

        /// <summary>
        /// 拠点ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_SectionCode_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // 拠点ガイド表示
            status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tEdit_SectionCode_St;
                nextControl = this.tEdit_SectionCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tEdit_SectionCode_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: //拠点 
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                    case 1: //拠点-部門 
                        nextControl = this.tNedit_SubSectionCode_St;
                        break;
                    case 2: //拠点-担当者 
                    case 3: //拠点-受注者 
                    case 4: //拠点-発行者 
                        nextControl = this.tEdit_EmployeeCode_St;
                        break;
                    case 5: //拠点-販売区分 
                    case 6: //商品区分
                    case 8: //拠点-業種 
                    case 9: //拠点-地区
                        nextControl = this.tNedit_GuideCode_St;
                        break;
                    case 7: //拠点-得意先 
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                }
                
            }
            else
            {
                return;
            }

            // ADD 2008/11/27 不具合対応[8337] ---------->>>>>
            if (status != 0)
            {
                return;
            }
            // ADD 2008/11/27 不具合対応[8337] ----------<<<<<

            // コード展開
            targetControl.DataText = secInfoSet.SectionCode.Trim();
            // フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// 担当者ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.ub_St_EmployeeGuide)
                {
                    this.tEdit_EmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.tComboEditor_LogicalDeleteCode.Focus();
                }
            }
        }

        /// <summary>
        /// 部門ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_SubSectionCode_Click(object sender, EventArgs e)
        {


            if (this._subSectionAcs == null)
            {
                this._subSectionAcs = new SubSectionAcs();
            }

            SubSection subSection;

            int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);

            if (status == 0)
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    this.tNedit_SubSectionCode_St.SetInt(subSection.SubSectionCode);
                    this.tNedit_SubSectionCode_Ed.Focus();
                }
                else
                {
                    this.tNedit_SubSectionCode_Ed.SetInt(subSection.SubSectionCode);
                    this.tComboEditor_LogicalDeleteCode.Focus();
                }
            }

        }

        /// <summary>
        /// ユーザーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GuideCode_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 0;
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 5: //拠点-販売区分  
                    GuideNo = 71;
                    break;
                case 6: //商品区分 
                    GuideNo = 41;
                    break;
                case 8: //拠点-業種 
                    GuideNo = 33;
                    break;
                case 9: //拠点-地区
                    GuideNo = 21;
                    break;
            }

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GuideCode_St;
                nextControl = this.tNedit_GuideCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GuideCode_Ed;
                nextControl = this.tComboEditor_LogicalDeleteCode;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // フォーカス移動
            nextControl.Focus();
        }

        /// <summary>
        /// 得意先ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // ガイド後次フォーカス
            if (_customerGuideOK)
            {
                Control nextControl;
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.tNedit_CustomerCode_Ed;
                }
                else
                {
                    nextControl = this.tComboEditor_LogicalDeleteCode;
                }
                // フォーカス移動
                nextControl.Focus();
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (_customerGuideSender == this.CustomerCdSt_GuideBtn)
            {
                this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
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

        /// <summary>
        /// 印刷パターン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            // ADD 2008/12/02 不具合対応[8535] ---------->>>>>
            this.ultraLabel76.Visible = true;
            this.tEdit_SectionCode_St.Visible = true;
            this.tEdit_SectionCode_Ed.Visible = true;
            this.ub_St_SectionCode.Visible = true;
            this.ub_Ed_SectionCode.Visible = true;
            this.ultraLabel77.Visible = true;
            // ADD 2008/12/02 不具合対応[8535] ----------<<<<<

            switch ((int)this.tComboEditor_PrintType.Value)
            {
                // ADD 2008/11/27 不具合対応[8339] ---------->>>>>
                case 0: //拠点
                    this.pn_SubSection.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = false;
                    break;
                // ADD 2008/11/27 不具合対応[8339] ----------<<<<<

                case 1: //拠点-部門 
                    this.pn_SubSection.Visible = true;
                    this.pn_SubSection.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = false;

                    break;
                case 2: //拠点-担当者 
                case 3: //拠点-受注者 
                case 4: //拠点-発行者 
                    this.pn_Employee.Visible = true;
                    this.pn_SubSection.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = false;

                    break;
                case 5: //拠点-販売区分 
                    this.pn_Guide.Visible = true;
                    this.pn_Guide.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_SubSection.Visible = false;
                    this.pn_Customer.Visible = false;

                    this.Lb_Guide.Text = "販売区分";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("販売区分ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk.ToolTipText = "販売区分ガイド";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk);

                    break;
                case 6: //商品区分 
                    this.pn_Guide.Visible = true;
                    //this.pn_Guide.Location = this.pn_Employee.Location; // DEL 2008/12/02 不具合対応[8535]
                    // ADD 2008/12/02 不具合対応[8535] ---------->>>>>
                    this.ultraLabel76.Visible = false;
                    this.tEdit_SectionCode_St.Visible = false;
                    this.tEdit_SectionCode_Ed.Visible = false;
                    this.ub_St_SectionCode.Visible = false;
                    this.ub_Ed_SectionCode.Visible = false;
                    this.ultraLabel77.Visible = false;

                    this.pn_Guide.Top = this.ultraLabel76.Top;
                    // ADD 2008/12/02 不具合対応[8535] ----------<<<<<

                    this.pn_Employee.Visible = false;
                    this.pn_SubSection.Visible = false;
                    this.pn_Customer.Visible = false;

                    this.Lb_Guide.Text = "商品区分";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("商品区分ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk2.ToolTipText = "商品区分ガイド";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk2);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk2);

                    break;
                case 7: //拠点-得意先 
                    this.pn_Customer.Visible = true;
                    this.pn_Customer.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_SubSection.Visible = false;
                    this.pn_Guide.Visible = false;

                    break;
                case 8: //拠点-業種 
                    this.pn_Guide.Visible = true;
                    this.pn_Guide.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_SubSection.Visible = false;
                    this.pn_Customer.Visible = false;

                    this.Lb_Guide.Text = "業種";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("業種ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk3.ToolTipText = "業種ガイド";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk3);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk3);
                    break;
                case 9: //拠点-地区
                    this.pn_Guide.Visible = true;
                    this.pn_Guide.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_SubSection.Visible = false;
                    this.pn_Customer.Visible = false;

                    this.Lb_Guide.Text = "地区";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("地区ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk4.ToolTipText = "地区ガイド";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk4);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk4);
                    break;
            }

            // ADD 2008/11/27 不具合対応[8351] ---------->>>>>
            this.tEdit_EmployeeCode_St.DataText = string.Empty;
            this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
            this.tNedit_SubSectionCode_St.DataText = string.Empty;
            this.tNedit_SubSectionCode_Ed.DataText = string.Empty;
            this.tNedit_GuideCode_St.DataText = string.Empty;
            this.tNedit_GuideCode_Ed.DataText = string.Empty;
            this.tNedit_CustomerCode_St.DataText = string.Empty;
            this.tNedit_CustomerCode_Ed.DataText = string.Empty;
            // ADD 2008/11/27 不具合対応[8351] ----------<<<<<
        }
        #endregion ■ Control Event

  
    }
}