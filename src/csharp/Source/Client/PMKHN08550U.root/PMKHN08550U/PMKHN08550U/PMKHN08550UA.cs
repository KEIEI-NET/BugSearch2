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
    /// 得意先マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public partial class PMKHN08550UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 得意先マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08550UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._customerSetAcs = new CustomerSetAcs();

            this._secInfoSetAcs = new SecInfoSetAcs();

            // 変数初期化
            this.secInfoSetTable = new Hashtable();
            this._makerAcs = new MakerAcs();
            // マスタ読込
            ReadMakerUMnt();

            // データセット列情報構築処理
            DataSetColumnConstruction();
            DataSetColumnConstruction2();
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
        private CustomerPrintWork _customerPrintWork;

        // データアクセス
        private CustomerSetAcs _customerSetAcs;

        private SecInfoSetAcs _secInfoSetAcs;
        private EmployeeAcs _employeeAcs;
        private UserGuideAcs _userGuideAcs;


        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;
        // 仕入先ガイド用
        private UltraButton _customerGuideSender;


        private MakerAcs _makerAcs;
        private Dictionary<int, MakerUMnt> _makerUMntDic;

        private Hashtable secInfoSetTable;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08550UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08550U";
        //// 帳票名称
        private string _printName = "得意先マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "CUSTOMERSET";
        private const string PRINTSET_TABLE2 = "CUSTOMERSET2";

        // dataview名称用
        private const string CUSTOMERCODE = "customercode";
        private const string KANA = "kana";
        private const string OFFICETELNO = "officetelno";
        private const string PORTABLETELNO = "portabletelno";
        private const string OFFICEFAXNO = "officefaxno";
        private const string TOTALDAY = "totalday";
        private const string COLLECTMONEYNAMEDAY = "collectmoneynameday";
        private const string COLLECTMONEYNAME = "collectmoneyname";
        private const string COLLECTMONEYDAY = "collectmoneyday";
        private const string CUSTOMERAGENTCD = "customeragentcd";
        private const string CUSTOMERAGENTNAME = "customeragentname";
        private const string SALESAREACODE = "salesareacode";
        private const string SALESAREANAME = "salesareaname";
        private const string BUSINESSTYPECODE = "businesstypecode";
        private const string BUSINESSTYPENAME = "businesstypename";
        private const string CLAIMSECTIONCODE = "claimsectioncode";
        private const string CLAIMCODE = "claimcode";
        private const string BILLCOLLECTERCD = "billcollectercd";
        private const string POSTNO = "postno";
        private const string ADDRESSALL = "addressall";
        private const string ADDRESS1 = "address1";
        private const string ADDRESS3 = "address3";
        private const string ADDRESS4 = "address4";
        private const string MNGSECTIONCODE = "mngsectioncode";
        private const string SECTIONGUIDESNM = "sectionguidesnm";
        private const string CUSTWAREHOUSECD = "custwarehousecd";
        private const string NAME = "name";
        private const string NAME2 = "name2";
        private const string CUSTOMERSNM = "customersnm";
        private const string PURECODE = "purecode";
        private const string GOODSMAKERCD = "goodsmakercd";
        private const string CUSTRATEGRPCODE = "custrategrpcode";
        
        private const string CUSTOMERCODE_TITLE = "得意先";
        private const string KANA_TITLE = "ｶﾅ";
        private const string OFFICETELNO_TITLE = "電話番号１";
        private const string PORTABLETELNO_TITLE = "電話番号２";
        private const string OFFICEFAXNO_TITLE = "ＦＡＸ";
        private const string TOTALDAY_TITLE = "締日";
        private const string COLLECTMONEYNAMEDAY_TITLE = "回収月日";
        private const string COLLECTMONEYNAME_TITLE = "回収月";
        private const string COLLECTMONEYDAY_TITLE = "回収日";
        private const string CUSTOMERAGENTCD_TITLE = "担当者";
        private const string CUSTOMERAGENTNAME_TITLE = "担当者名";
        private const string SALESAREACODE_TITLE = "地区";
        private const string SALESAREANAME_TITLE = "地区名";
        private const string BUSINESSTYPECODE_TITLE = "業種";
        private const string BUSINESSTYPENAME_TITLE = "業種名";
        private const string CLAIMSECTIONCODE_TITLE = "請求先拠点";
        private const string CLAIMCODE_TITLE = "請求先";
        private const string BILLCOLLECTERCD_TITLE = "回収担当";
        private const string POSTNO_TITLE = "郵便番号";
        private const string ADDRESSALL_TITLE = "住所";
        private const string ADDRESS1_TITLE = "住所１";
        private const string ADDRESS3_TITLE = "住所３";
        private const string ADDRESS4_TITLE = "住所４";
        private const string MNGSECTIONCODE_TITLE = "拠点";
        private const string SECTIONGUIDESNM_TITLE = "拠点名";
        private const string CUSTWAREHOUSECD_TITLE = "倉庫";
        private const string NAME_TITLE = "名称１";
        private const string NAME2_TITLE = "名称２";
        private const string CUSTOMERSNM_TITLE = "得意先名";
        private const string PURECODE_TITLE = "純正区分";
        private const string GOODSMAKERCD_TITLE = "商品メーカー";
        private const string CUSTRATEGRPCODE_TITLE = "掛率グループ";


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
            this.Bind_DataSet.Tables[PRINTSET_TABLE2].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._customerSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._customerPrintWork);
            }
            else
            {
                status = this._customerSetAcs.SearchDelete(
                    out PrintSets,
                    this._enterpriseCode,
                    this._customerPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 得意先クラスをデータセットへ展開する
                        int index = 0;
                        foreach (CustomerSet customerSet in PrintSets)
                        {
                            if ((int)this.tComboEditor_printType.Value == 2)
                            {
                                SecPrintSetToDataSet2(customerSet.Clone(), index);
                            }
                            else
                            {
                                SecPrintSetToDataSet(customerSet.Clone(), index);
                            }
                            ++index;
                        }
                        
                        // ソート
                        if ((int)this.tComboEditor_printType.Value == 2)
                        {
                            this.Bind_DataSet.Tables[PRINTSET_TABLE2].DefaultView.Sort = CUSTOMERCODE;
                        }
                        else
                        {
                            switch ((int)this.tComboEditor_sort.Value)
                            {
                                case 0: // コード順
                                    this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = CUSTOMERCODE;
                                    break;
                                case 1: // カナ順
                                    this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = KANA;
                                    break;
                                case 2: // 拠点順
                                    this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = MNGSECTIONCODE;
                                    break;
                                case 3: // 担当者順
                                    this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = CUSTOMERAGENTCD;
                                    break;
                                case 4: // 地区順
                                    this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = SALESAREACODE;
                                    break;
                                case 5: // 業種順
                                    this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = BUSINESSTYPECODE;
                                    break;
                            }
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
                            "PMKHN08550U", 						// アセンブリＩＤまたはクラスＩＤ
                            "得意先マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._customerSetAcs, 				// エラーが発生したオブジェクト
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
            printInfo.jyoken = this._customerPrintWork;
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
            this._customerPrintWork = new CustomerPrintWork();

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

            if ((int)this.tComboEditor_printType.Value == 2)
            {
                tableName = PRINTSET_TABLE2;
            }
            else
            {
                tableName = PRINTSET_TABLE;
            }
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
            if ((int)this.tComboEditor_printType.Value == 2)
            {
                // 掛率グループ設定
                UGrid.DisplayLayout.Bands[0].Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
                #region 項目のサイズを設定
                sizeCell.Height = 22;
                sizeCell.Width = 100;
                sizeHeader.Height = 20;
                sizeHeader.Width = 100;

                // コード
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;


                sizeCell.Width = 360;
                sizeHeader.Width = 360;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 100;
                sizeHeader.Width = 100;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                #endregion

                #region LabelSpanの設定
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].RowLayoutColumnInfo.LabelSpan = 2;
                #endregion

                #region ヘッダ名称を設定
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].Header.Caption = "優良";
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].Header.Caption = "純正ALL";
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].Header.Caption = "01" + GetMakerName(1);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].Header.Caption = "02" + GetMakerName(2);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].Header.Caption = "03" + GetMakerName(3);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].Header.Caption = "04" + GetMakerName(4);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].Header.Caption = "05" + GetMakerName(5);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].Header.Caption = "06" + GetMakerName(6);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].Header.Caption = "07" + GetMakerName(7);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].Header.Caption = "08" + GetMakerName(8);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].Header.Caption = "09" + GetMakerName(9);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].Header.Caption = "10" + GetMakerName(10);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].Header.Caption = "11" + GetMakerName(11);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].Header.Caption = "12" + GetMakerName(12);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].Header.Caption = "13" + GetMakerName(13);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].Header.Caption = "14" + GetMakerName(14);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].Header.Caption = "15" + GetMakerName(15);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].Header.Caption = "16" + GetMakerName(16);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].Header.Caption = "17" + GetMakerName(17);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].Header.Caption = "18" + GetMakerName(18);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].Header.Caption = "19" + GetMakerName(19);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].Header.Caption = "20" + GetMakerName(20);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].Header.Caption = "21" + GetMakerName(21);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].Header.Caption = "22" + GetMakerName(22);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].Header.Caption = "23" + GetMakerName(23);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].Header.Caption = "24" + GetMakerName(24);
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].Header.Caption = "25" + GetMakerName(25);
                #endregion

                #region 列配置
                // 1行目
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].RowLayoutColumnInfo.OriginX = 4;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "ALL"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.OriginX = 6;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "00"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "01"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "02"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "03"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "04"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "05"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "06"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "07"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "08"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "09"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].RowLayoutColumnInfo.OriginX = 30;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "10"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].RowLayoutColumnInfo.OriginX = 32;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "11"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].RowLayoutColumnInfo.OriginX = 34;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "12"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].RowLayoutColumnInfo.OriginX = 36;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "13"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].RowLayoutColumnInfo.OriginX = 38;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "14"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].RowLayoutColumnInfo.OriginX = 40;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "15"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].RowLayoutColumnInfo.OriginX = 42;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "16"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].RowLayoutColumnInfo.OriginX = 44;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "17"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].RowLayoutColumnInfo.OriginX = 46;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "18"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].RowLayoutColumnInfo.OriginX = 48;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "19"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].RowLayoutColumnInfo.OriginX = 50;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "20"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].RowLayoutColumnInfo.OriginX = 52;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "21"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].RowLayoutColumnInfo.OriginX = 54;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "22"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].RowLayoutColumnInfo.OriginX = 56;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "23"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].RowLayoutColumnInfo.OriginX = 58;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "24"].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].RowLayoutColumnInfo.OriginX = 60;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE + "25"].RowLayoutColumnInfo.SpanY = 2;

                #endregion
            }
            else
            {

                UGrid.DisplayLayout.Bands[0].Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
                #region 項目のサイズを設定
                sizeCell.Height = 22;
                sizeCell.Width = 100;
                sizeHeader.Height = 20;
                sizeHeader.Width = 100;

                // コード
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                // １行目
                sizeCell.Width = 140;
                sizeHeader.Width = 140;
                UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 50;
                sizeHeader.Width = 50;
                UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 100;
                sizeHeader.Width = 100;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYDAY].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYDAY].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
                
                sizeCell.Width = 100;
                sizeHeader.Width = 100;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 320;
                sizeHeader.Width = 320;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 60;
                sizeHeader.Width = 60;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 240;
                sizeHeader.Width = 240;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 60;
                sizeHeader.Width = 60;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 240;
                sizeHeader.Width = 240;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 100;
                sizeHeader.Width = 100;
                UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                // ２行目
                sizeCell.Width = 300;
                sizeHeader.Width = 300;
                UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 100;
                sizeHeader.Width = 100;
                UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 240;
                sizeHeader.Width = 240;
                UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 100;
                sizeHeader.Width = 100;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                // 得意先住所録
                sizeCell.Width = 500;
                sizeHeader.Width = 500;
                UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[NAME2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[NAME2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                sizeCell.Width = 360;
                sizeHeader.Width = 360;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                // 掛率グループ設定
                UGrid.DisplayLayout.Bands[0].Columns[PURECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[PURECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                #endregion  項目のサイズを設定

                #region LabelSpanの設定
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAME].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYDAY].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[NAME2].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PURECODE].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.LabelSpan = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE].RowLayoutColumnInfo.LabelSpan = 2;
                #endregion LabelSpanの設定

                #region ヘッダ名称を設定
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[KANA].Header.Caption = KANA_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].Header.Caption = OFFICETELNO_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].Header.Caption = PORTABLETELNO_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].Header.Caption = OFFICEFAXNO_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].Header.Caption = TOTALDAY_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].Header.Caption = COLLECTMONEYNAMEDAY_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAME].Header.Caption = COLLECTMONEYNAME_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYDAY].Header.Caption = COLLECTMONEYDAY_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].Header.Caption = CUSTOMERAGENTCD_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].Header.Caption = CUSTOMERAGENTNAME_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Header.Caption = SALESAREACODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].Header.Caption = SALESAREANAME_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Header.Caption = BUSINESSTYPECODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].Header.Caption = BUSINESSTYPENAME_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].Header.Caption = CLAIMSECTIONCODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].Header.Caption = CLAIMCODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].Header.Caption = BILLCOLLECTERCD_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[POSTNO].Header.Caption = POSTNO_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].Header.Caption = ADDRESSALL_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].Header.Caption = ADDRESS1_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].Header.Caption = ADDRESS3_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].Header.Caption = ADDRESS4_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].Header.Caption = MNGSECTIONCODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Header.Caption = SECTIONGUIDESNM_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].Header.Caption = CUSTWAREHOUSECD_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[NAME].Header.Caption = NAME_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[NAME2].Header.Caption = NAME2_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[PURECODE].Header.Caption = PURECODE_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Header.Caption = GOODSMAKERCD_TITLE;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE].Header.Caption = CUSTRATEGRPCODE_TITLE;
                #endregion

                #region 表示制御
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYDAY].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PURECODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTRATEGRPCODE].Hidden = true;
                switch ((int)this.tComboEditor_printType.Value)
                {
                    case 0: // 得意先一覧表
                        UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAME].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYDAY].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = false;

                        UGrid.DisplayLayout.Bands[0].Columns[NAME].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME2].Hidden = true;

                        break;
                    case 1: // 得意先住所録
                        UGrid.DisplayLayout.Bands[0].Columns[NAME].Hidden = false;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME2].Hidden = false;

                        UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAME].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYDAY].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].Hidden = true;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                        break;
                }
                #endregion

                #region 列配置
                // 1行目
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 4;

                switch ((int)this.tComboEditor_printType.Value)
                {
                    case 0: // 得意先一覧表
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.OriginX = 4;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.OriginX = 6;
                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.OriginX = 8;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].RowLayoutColumnInfo.OriginX = 10;
                        UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[TOTALDAY].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].RowLayoutColumnInfo.OriginX = 12;
                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[COLLECTMONEYNAMEDAY].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.OriginX = 14;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.OriginX = 16;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginX = 18;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].RowLayoutColumnInfo.OriginX = 20;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[SALESAREANAME].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.OriginX = 22;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPECODE].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].RowLayoutColumnInfo.OriginX = 24;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[BUSINESSTYPENAME].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].RowLayoutColumnInfo.OriginX = 26;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMSECTIONCODE].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].RowLayoutColumnInfo.OriginX = 28;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CLAIMCODE].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].RowLayoutColumnInfo.OriginX = 30;
                        UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[BILLCOLLECTERCD].RowLayoutColumnInfo.SpanY = 2;

                        //2行目
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.OriginX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.OriginX = 4;
                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.OriginX = 6;
                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.SpanX = 20;
                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.OriginX = 26;
                        UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[MNGSECTIONCODE].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginX = 28;
                        UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].RowLayoutColumnInfo.OriginX = 30;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTWAREHOUSECD].RowLayoutColumnInfo.SpanY = 2;

                        break;
                    case 1: // 得意先住所録
                        UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.OriginX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.SpanX = 4;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[NAME2].RowLayoutColumnInfo.OriginX = 6;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME2].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME2].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[NAME2].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.OriginX = 8;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICETELNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.OriginX = 10;
                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.OriginX = 12;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[OFFICEFAXNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.OriginX = 14;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTCD].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.OriginX = 16;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.OriginY = 0;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERAGENTNAME].RowLayoutColumnInfo.SpanY = 2;

                        //2行目
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.OriginX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.OriginX = 4;
                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.SpanX = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.SpanY = 2;

                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.OriginX = 6;
                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.OriginY = 2;
                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.SpanX = 12;
                        UGrid.DisplayLayout.Bands[0].Columns[ADDRESSALL].RowLayoutColumnInfo.SpanY = 2;
                        break;
                }

                #endregion 列配置
            }
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            //開始得意先コード
            if (this._customerPrintWork.CustomerCodeSt != this.tNedit_CustomerCode_St.GetInt())
            {
                status = false;
                return status;
            }
            //終了得意先コード
            if (this._customerPrintWork.CustomerCodeEd != this.tNedit_CustomerCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            //開始カナ
            if (this._customerPrintWork.KanaSt != this.tEdit_Kana_St.DataText)
            {
                status = false;
                return status;
            }
            //終了カナ
            if (this._customerPrintWork.KanaEd != this.tEdit_Kana_Ed.DataText)
            {
                status = false;
                return status;
            }
            //開始拠点
            if (this._customerPrintWork.MngSectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }
            //終了拠点
            if (this._customerPrintWork.MngSectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            //開始担当者
            if (this._customerPrintWork.CustomerAgentCdSt != this.tEdit_EmployeeCode_St.DataText)
            {
                status = false;
                return status;
            }
            //終了担当者
            if (this._customerPrintWork.CustomerAgentCdEd != this.tEdit_EmployeeCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            //開始地区
            if (this._customerPrintWork.SalesAreaCodeSt != this.tNedit_AreaCode_St.GetInt())
            {
                status = false;
                return status;
            }
            //終了地区
            if (this._customerPrintWork.SalesAreaCodeEd != this.tNedit_AreaCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            //開始業種
            if (this._customerPrintWork.BusinessTypeCodeSt != this.tNedit_businessType_St.GetInt())
            {
                status = false;
                return status;
            }
            //終了業種
            if (this._customerPrintWork.BusinessTypeCodeEd != this.tNedit_businessType_Ed.GetInt())
            {
                status = false;
                return status;
            }
            //発行タイプ
            if (this._customerPrintWork.PrintType != (int)this.tComboEditor_printType.Value)
            {
                status = false;
                return status;
            }
            //ソート順
            if (this._customerPrintWork.Sort != (int)this.tComboEditor_sort.Value)
            {
                status = false;
                return status;
            }


            // 削除指定
            if (this._customerPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._customerPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._customerPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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

            // マスタ読込
            ReadMakerUMnt();

            try
            {
                // 初期値セット・文字列
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                this.tEdit_Kana_St.DataText = string.Empty;
                this.tEdit_Kana_Ed.DataText = string.Empty;
                this.tEdit_SectionCode_St.DataText = string.Empty;
                this.tEdit_SectionCode_Ed.DataText = string.Empty;
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                this.tNedit_AreaCode_St.DataText = string.Empty;
                this.tNedit_AreaCode_Ed.DataText = string.Empty;
                this.tNedit_businessType_St.DataText = string.Empty;
                this.tNedit_businessType_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.CustomerCdSt_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.CustomerCdEd_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_AreaCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_AreaCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_businessType, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_businessType, Size16_Index.STAR1);

                // コンボボックスの設定
                this.tComboEditor_printType.Value = 0;
                this.tComboEditor_sort.Value = 0;

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // 初期フォーカスセット
                this.tNedit_CustomerCode_St.Focus();
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


            // 得意先
            if (
                (this.tNedit_CustomerCode_St.GetInt() != 0) &&
                (this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // カナ
            if (
                (this.tEdit_Kana_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_Kana_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_Kana_St.DataText.CompareTo(this.tEdit_Kana_Ed.DataText.TrimEnd()) > 0)
            {
                errMessage = string.Format("カナ{0}", ct_RangeError);
                errComponent = this.tEdit_Kana_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // 拠点
            // DEL 2008/11/27 不具合対応[8307] ---------->>>>>
            //if (
            //    (this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
            //    this.tEdit_SectionCode_St.DataText.CompareTo(this.tEdit_SectionCode_Ed.DataText.TrimEnd()) > 0)
            // DEL 2008/11/27 不具合対応[8307] ----------<<<<<
            // ADD 2008/11/27 不具合対応[8307] ---------->>>>>
            if (
                (this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0').CompareTo(this.tEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0')) > 0)
            // ADD 2008/11/27 不具合対応[8307] ----------<<<<<
            {
                errMessage = string.Format("拠点{0}", ct_RangeError);
                errComponent = this.tEdit_SectionCode_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // 担当者
            // DEL 2008/11/27 不具合対応[8307] ---------->>>>>
            //if (
            //    (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
            //    (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
            //    this.tEdit_EmployeeCode_St.DataText.CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()) > 0)
            // DEL 2008/11/27 不具合対応[8307] ----------<<<<<
            
            // ADD 2008/11/27 不具合対応[8307] ---------->>>>>
            if (
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0').CompareTo(this.tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0')) > 0)
            // ADD 2008/11/27 不具合対応[8307] ----------<<<<<
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // 地区
            if (
                (this.tNedit_AreaCode_St.GetInt() != 0) &&
                (this.tNedit_AreaCode_Ed.GetInt() != 0) &&
                this.tNedit_AreaCode_St.GetInt() > this.tNedit_AreaCode_Ed.GetInt())
            {
                errMessage = string.Format("地区{0}", ct_RangeError);
                errComponent = this.tNedit_AreaCode_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // 業種
            if (
                (this.tNedit_businessType_St.GetInt() != 0) &&
                (this.tNedit_businessType_Ed.GetInt() != 0) &&
                this.tNedit_businessType_St.GetInt() > this.tNedit_businessType_Ed.GetInt())
            {
                errMessage = string.Format("業種{0}", ct_RangeError);
                errComponent = this.tNedit_businessType_St;
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
                //開始得意先コード
                this._customerPrintWork.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                //終了得意先コード
                this._customerPrintWork.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                //開始カナ
                this._customerPrintWork.KanaSt = this.tEdit_Kana_St.DataText;
                //終了カナ
                this._customerPrintWork.KanaEd = this.tEdit_Kana_Ed.DataText;
                //開始拠点
                this._customerPrintWork.MngSectionCodeSt = this.tEdit_SectionCode_St.DataText;
                //終了拠点
                this._customerPrintWork.MngSectionCodeEd = this.tEdit_SectionCode_Ed.DataText;
                //開始担当者
                this._customerPrintWork.CustomerAgentCdSt = this.tEdit_EmployeeCode_St.DataText;
                //終了担当者
                this._customerPrintWork.CustomerAgentCdEd = this.tEdit_EmployeeCode_Ed.DataText;
                //開始地区
                this._customerPrintWork.SalesAreaCodeSt = this.tNedit_AreaCode_St.GetInt();
                //終了地区
                this._customerPrintWork.SalesAreaCodeEd = this.tNedit_AreaCode_Ed.GetInt();
                //開始業種
                this._customerPrintWork.BusinessTypeCodeSt = this.tNedit_businessType_St.GetInt();
                //終了業種
                this._customerPrintWork.BusinessTypeCodeEd = this.tNedit_businessType_Ed.GetInt();
                //発行タイプ
                this._customerPrintWork.PrintType = (int)this.tComboEditor_printType.Value;
                //ソート順
                this._customerPrintWork.Sort = (int)this.tComboEditor_sort.Value;
                // 削除指定区分
                this._customerPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._customerPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._customerPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
                // メーカー名1	
                this._customerPrintWork.CustRateGrpName01 = GetMakerName(1);
                // メーカー名2	
                this._customerPrintWork.CustRateGrpName02 = GetMakerName(2);
                // メーカー名3	
                this._customerPrintWork.CustRateGrpName03 = GetMakerName(3);
                // メーカー名4	
                this._customerPrintWork.CustRateGrpName04 = GetMakerName(4);
                // メーカー名5	
                this._customerPrintWork.CustRateGrpName05 = GetMakerName(5);
                // メーカー名6	
                this._customerPrintWork.CustRateGrpName06 = GetMakerName(6);
                // メーカー名7	
                this._customerPrintWork.CustRateGrpName07 = GetMakerName(7);
                // メーカー名8	
                this._customerPrintWork.CustRateGrpName08 = GetMakerName(8);
                // メーカー名9	
                this._customerPrintWork.CustRateGrpName09 = GetMakerName(9);
                // メーカー名10	
                this._customerPrintWork.CustRateGrpName10 = GetMakerName(10);
                // メーカー名11	
                this._customerPrintWork.CustRateGrpName11 = GetMakerName(11);
                // メーカー名12	
                this._customerPrintWork.CustRateGrpName12 = GetMakerName(12);
                // メーカー名13	
                this._customerPrintWork.CustRateGrpName13 = GetMakerName(13);
                // メーカー名14	
                this._customerPrintWork.CustRateGrpName14 = GetMakerName(14);
                // メーカー名15	
                this._customerPrintWork.CustRateGrpName15 = GetMakerName(15);
                // メーカー名16	
                this._customerPrintWork.CustRateGrpName16 = GetMakerName(16);
                // メーカー名17	
                this._customerPrintWork.CustRateGrpName17 = GetMakerName(17);
                // メーカー名18	
                this._customerPrintWork.CustRateGrpName18 = GetMakerName(18);
                // メーカー名19	
                this._customerPrintWork.CustRateGrpName19 = GetMakerName(19);
                // メーカー名20	
                this._customerPrintWork.CustRateGrpName20 = GetMakerName(20);
                // メーカー名21	
                this._customerPrintWork.CustRateGrpName21 = GetMakerName(21);
                // メーカー名22	
                this._customerPrintWork.CustRateGrpName22 = GetMakerName(22);
                // メーカー名23	
                this._customerPrintWork.CustRateGrpName23 = GetMakerName(23);
                // メーカー名24	
                this._customerPrintWork.CustRateGrpName24 = GetMakerName(24);
                // メーカー名25	
                this._customerPrintWork.CustRateGrpName25 = GetMakerName(25);

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
        /// 得意先クラスデータセット展開処理
        /// </summary>
        /// <param name="customerSet">得意先クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 得意先クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(CustomerSet customerSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = customerSet.CustomerCode.ToString("00000000");
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][KANA] = customerSet.Kana;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][OFFICETELNO] = customerSet.OfficeTelNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PORTABLETELNO] = customerSet.PortableTelNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][OFFICEFAXNO] = customerSet.OfficeFaxNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TOTALDAY] = customerSet.TotalDay;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COLLECTMONEYNAMEDAY] = customerSet.CollectMoneyName + customerSet.CollectMoneyDay;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COLLECTMONEYNAME] = customerSet.CollectMoneyName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COLLECTMONEYDAY] = customerSet.CollectMoneyDay;
            if (customerSet.CustomerAgentCd.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERAGENTCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERAGENTCD] = customerSet.CustomerAgentCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERAGENTNAME] = customerSet.CustomerAgentName;
            if (customerSet.SalesAreaCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = customerSet.SalesAreaCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREANAME] = customerSet.SalesAreaName;
            if (customerSet.BusinessTypeCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BUSINESSTYPECODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BUSINESSTYPECODE] = customerSet.BusinessTypeCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BUSINESSTYPENAME] = customerSet.BusinessTypeName;
            if (customerSet.ClaimSectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CLAIMSECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CLAIMSECTIONCODE] = customerSet.ClaimSectionCode.Trim().PadLeft(2, '0');
            }
            if (customerSet.ClaimCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CLAIMCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CLAIMCODE] = customerSet.ClaimCode.ToString("00000000");
            }
            if (customerSet.BillCollecterCd.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BILLCOLLECTERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BILLCOLLECTERCD] = customerSet.BillCollecterCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][POSTNO] = customerSet.PostNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ADDRESSALL] = customerSet.Address1.Trim() + " " + customerSet.Address3.Trim() + " " + customerSet.Address4.Trim();
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ADDRESS1] = customerSet.Address1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ADDRESS3] = customerSet.Address3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ADDRESS4] = customerSet.Address4;
            if (customerSet.MngSectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MNGSECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MNGSECTIONCODE] = customerSet.MngSectionCode.Trim().PadLeft(2, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = customerSet.SectionGuideSnm;
            if (customerSet.CustWarehouseCd.Trim().PadLeft(4,'0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTWAREHOUSECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTWAREHOUSECD] = customerSet.CustWarehouseCd.Trim().PadLeft(4,'0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][NAME] = customerSet.Name;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][NAME2] = customerSet.Name2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERSNM] = customerSet.CustomerSnm;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PURECODE] = customerSet.PureCode;
            if (customerSet.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = customerSet.GoodsMakerCd.ToString("0000");
            }
            if (customerSet.CustRateGrpCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTRATEGRPCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTRATEGRPCODE] = customerSet.CustRateGrpCode;
            }
        }

        /// <summary>
        /// 得意先クラスデータセット展開処理
        /// </summary>
        /// <param name="customerSet">得意先クラス</param>
        /// <param name="para_index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 得意先クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet2(CustomerSet customerSet, int para_index)
        {

            int index =-1 ;
            if (para_index != 0)
            {
                for (int i = 0; i < this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows.Count; i++)
                {
                    if (this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[i][CUSTOMERCODE].ToString().Equals(customerSet.CustomerCode.ToString("00000000")))
                    {
                        index = i;
                        break;
                    }
                }
            }
            if (index == -1)
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE2].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows.Count - 1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTOMERCODE] = customerSet.CustomerCode.ToString("00000000");
            this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTOMERSNM] = customerSet.CustomerSnm;

            if (customerSet.PureCode == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "ALL"] = customerSet.CustRateGrpCode.ToString("0000");
            }
            else
            {
                switch (customerSet.GoodsMakerCd)
                {
                    case 0:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "00"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 1:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "01"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 2:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "02"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 3:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "03"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 4:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "04"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 5:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "05"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 6:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "06"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 7:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "07"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 8:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "08"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 9:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "09"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 10:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "10"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 11:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "11"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 12:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "12"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 13:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "13"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 14:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "14"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 15:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "15"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 16:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "16"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 17:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "17"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 18:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "18"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 19:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "19"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 20:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "20"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 21:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "21"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 22:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "22"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 23:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "23"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 24:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "24"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                    case 25:
                        this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "25"] = customerSet.CustRateGrpCode.ToString("0000");
                        break;
                }
            }

            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
            // TODO:得意先掛率グループ列にデフォルト値を設定
            SetDefaultCustRateGrpCodeColumnIf(index);
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
        }

        // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
        #region 得意先掛率グループ

        /// <summary>得意先掛率グループコードが不定時の名称</summary>
        private const string NONE_CUST_RATE_GRP_CODE_NAME = "未設定";

        /// <summary>
        /// 得意先掛率グループ列が<c>DBNull</c>の場合、デフォルト値を設定します。
        /// </summary>
        /// <param name="index">PRINTSET_TABLE2テーブルの行番号</param>
        private void SetDefaultCustRateGrpCodeColumnIf(int index)
        {
            if (this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "ALL"] == DBNull.Value)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + "ALL"] = NONE_CUST_RATE_GRP_CODE_NAME;
            }
            for (int i = 0; i <= 25; i++)
            {
                if (this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + i.ToString("00")] == DBNull.Value)
                {
                    this.Bind_DataSet.Tables[PRINTSET_TABLE2].Rows[index][CUSTRATEGRPCODE + i.ToString("00")] = NONE_CUST_RATE_GRP_CODE_NAME;
                }
            }
        }

        /// <summary>
        /// 得意先掛率グループコード名を取得します。
        /// </summary>
        /// <param name="customerSet">得意先情報</param>
        /// <returns>
        /// <c>customerSet.CustRateGrpCode >= 0 ? customerSet.CustRateGrpCode.ToString("0000") : "未設定";</c>
        /// </returns>
        private static string GetCustRateGrpCodeName(CustomerSet customerSet)
        {
            return customerSet.CustRateGrpCode >= 0 ? customerSet.CustRateGrpCode.ToString("0000") : NONE_CUST_RATE_GRP_CODE_NAME;
        }

        #endregion // 得意先掛率グループ
        // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

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
            PrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		// 得意先コード 
            PrintSetTable.Columns.Add(KANA, typeof(string));		        // カナ 
            PrintSetTable.Columns.Add(OFFICETELNO, typeof(string));		    // 電話番号（勤務先） 
            PrintSetTable.Columns.Add(PORTABLETELNO, typeof(string));		// 電話番号（携帯） 
            PrintSetTable.Columns.Add(OFFICEFAXNO, typeof(string));		    // FAX番号（勤務先） 
            PrintSetTable.Columns.Add(TOTALDAY, typeof(Int32));		        // 締日 
            PrintSetTable.Columns.Add(COLLECTMONEYNAMEDAY, typeof(string));	// 集金月日
            PrintSetTable.Columns.Add(COLLECTMONEYNAME, typeof(string));	// 集金月区分名称 
            PrintSetTable.Columns.Add(COLLECTMONEYDAY, typeof(string));		// 集金日 
            PrintSetTable.Columns.Add(CUSTOMERAGENTCD, typeof(string));		// 顧客担当従業員コード 
            PrintSetTable.Columns.Add(CUSTOMERAGENTNAME, typeof(string));	// 顧客担当従業員名称 
            PrintSetTable.Columns.Add(SALESAREACODE, typeof(string));		// 販売エリアコード 
            PrintSetTable.Columns.Add(SALESAREANAME, typeof(string));		// 販売エリア名称 
            PrintSetTable.Columns.Add(BUSINESSTYPECODE, typeof(string));	// 業種コード 
            PrintSetTable.Columns.Add(BUSINESSTYPENAME, typeof(string));	// 業種名称 
            PrintSetTable.Columns.Add(CLAIMSECTIONCODE, typeof(string));	// 請求拠点コード 
            PrintSetTable.Columns.Add(CLAIMCODE, typeof(string));		    // 請求先コード 
            PrintSetTable.Columns.Add(BILLCOLLECTERCD, typeof(string));		// 集金担当従業員コード 
            PrintSetTable.Columns.Add(POSTNO, typeof(string));		        // 郵便番号 
            PrintSetTable.Columns.Add(ADDRESSALL, typeof(string));		    // 住所
            PrintSetTable.Columns.Add(ADDRESS1, typeof(string));		    // 住所1（都道府県市区郡・町村・字） 
            PrintSetTable.Columns.Add(ADDRESS3, typeof(string));		    // 住所3（番地） 
            PrintSetTable.Columns.Add(ADDRESS4, typeof(string));		    // 住所4（アパート名称） 
            PrintSetTable.Columns.Add(MNGSECTIONCODE, typeof(string));		// 管理拠点コード 
            PrintSetTable.Columns.Add(SECTIONGUIDESNM, typeof(string));		// 拠点ガイド略称 
            PrintSetTable.Columns.Add(CUSTWAREHOUSECD, typeof(string));		// 得意先優先倉庫コード 
            PrintSetTable.Columns.Add(NAME, typeof(string));		        // 名称 
            PrintSetTable.Columns.Add(NAME2, typeof(string));		        // 名称2 
            PrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));		    // 得意先略称 
            PrintSetTable.Columns.Add(PURECODE, typeof(string));		    // 純正区分 
            PrintSetTable.Columns.Add(GOODSMAKERCD, typeof(string));		// 商品メーカーコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE, typeof(string));		// 得意先掛率グループコード 
            
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void DataSetColumnConstruction2()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE2);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		// 得意先コード 
            PrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));		    // 得意先略称 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "ALL", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "00", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "01", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "02", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "03", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "04", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "05", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "06", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "07", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "08", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "09", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "10", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "11", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "12", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "13", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "14", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "15", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "16", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "17", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "18", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "19", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "20", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "21", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "22", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "23", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "24", typeof(string));		// 得意先掛率グループコード 
            PrintSetTable.Columns.Add(CUSTRATEGRPCODE + "25", typeof(string));		// 得意先掛率グループコード 

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }
        #endregion DataSet関連

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// メーカー名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerKanaName.Trim();
            }

            return makerName;
        }
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08550UA
        #region ◎ PMKHN08550UA_Load Event
        /// <summary>
        /// PMKHN08550UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08550UA_Load(object sender, EventArgs e)
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

        #endregion ◆ PMKHN08550UA

        /// <summary>
        /// 開始得意先ガイド
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

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
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
                nextControl = this.tEdit_EmployeeCode_St;
            }
            else
            {
                return;
            }

            // ADD 2008/11/27 不具合対応[8303] ---------->>>>>
            if (status != 0)
            {
                return;
            }
            // ADD 2008/11/27 不具合対応[8303] ----------<<<<<


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
                    //this.tComboEditor_LogicalDeleteCode.Focus();    // DEL 2008/11/27 不具合対応[8303]
                    this.tNedit_AreaCode_St.Focus();    // ADD 2008/11/27 不具合対応[8303]
                }
            }
        }

        /// <summary>
        /// 地区ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_AreaCode_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_AreaCode_St;
                nextControl = this.tNedit_AreaCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_AreaCode_Ed;
                //nextControl = this.tComboEditor_LogicalDeleteCode;  // DEL 2008/11/27 不具合対応[8303]
                nextControl = this.tNedit_businessType_St;  // ADD 2008/11/27 不具合対応[8303]
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
        /// 業種ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_businessType_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_businessType_St;
                nextControl = this.tNedit_businessType_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_businessType_Ed;
                //nextControl = this.tComboEditor_LogicalDeleteCode;  // DEL 2008/11/27 不具合対応[8303]
                nextControl = this.tComboEditor_printType;  // ADD 2008/11/27 不具合対応[8303]
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
        ///  発行タイプ選択時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_printType_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_printType.Value == 2)
            {
                this.tComboEditor_sort.Value = 0;
                this.tComboEditor_sort.Enabled = false;
            }
            else
            {
                this.tComboEditor_sort.Enabled = true;
            }

        }
        #endregion ■ Control Event
       
       
    }
}