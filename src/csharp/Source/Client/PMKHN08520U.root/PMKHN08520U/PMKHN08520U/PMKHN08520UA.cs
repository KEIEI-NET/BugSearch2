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
    /// 従業員マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public partial class PMKHN08520UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 従業員マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08520UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._employeeSetAcs = new EmployeeSetAcs();

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
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private EmployeePrintWork _employeePrintWork;

        // データアクセス
        private EmployeeSetAcs _employeeSetAcs;

        private SecInfoSetAcs _secInfoSetAcs;

        // 担当者ガイド用
        private EmployeeAcs _employeeAcs;

        private Hashtable secInfoSetTable;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08520UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08520U";
        //// 帳票名称
        private string _printName = "従業員マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "EMPLOYEESET";

        // dataview名称用
        private const string EMPLOYEECODE = "employeecode";
        private const string NAME = "name";
        private const string KANA = "kana";
        private const string SHORTNAME = "shortname";
        private const string SEXNAME = "sexname";
        private const string BIRTHDAY = "birthday";
        private const string COMPANYTELNO = "companytelno";
        private const string PORTABLETELNO = "portabletelno";
        private const string AUTHORITYLEVEL1 = "authoritylevel1";
        private const string AUTHORITYLEVELNM1 = "authoritylevelnm1";
        private const string AUTHORITYLEVEL2 = "authoritylevel2";
        private const string AUTHORITYLEVELNM2 = "authoritylevelnm2";
        private const string BELONGSECTIONCODE = "belongsectioncode";
        private const string SECTIONGUIDENM = "sectionguidenm";
        private const string BELONGSUBSECTIONCODE = "belongsubsectioncode";
        private const string SUBSECTIONNAME = "subsectionname";
        private const string ENTERCOMPANYDATE = "entercompanydate";
        private const string RETIREMENTDATE = "retirementdate";
        private const string EMPLOYANALYSCODE1 = "employanalyscode1";
        private const string EMPLOYANALYSCODE2 = "employanalyscode2";
        private const string EMPLOYANALYSCODE3 = "employanalyscode3";
        private const string EMPLOYANALYSCODE4 = "employanalyscode4";
        private const string EMPLOYANALYSCODE5 = "employanalyscode5";
        private const string EMPLOYANALYSCODE6 = "employanalyscode6";

        private const string EMPLOYEECODE_TITLE = "ｺｰﾄﾞ";
        private const string NAME_TITLE = "名称";
        private const string KANA_TITLE = "ｶﾅ";
        private const string SHORTNAME_TITLE = "略称";
        private const string SEXNAME_TITLE = "性別";
        private const string BIRTHDAY_TITLE = "生年月日";
        private const string COMPANYTELNO_TITLE = "電話番号（社内）";
        private const string PORTABLETELNO_TITLE = "電話番号（携帯）";
        private const string AUTHORITYLEVEL1_TITLE = "職種";
        private const string AUTHORITYLEVELNM1_TITLE = "ロール（業務）";
        private const string AUTHORITYLEVEL2_TITLE = "雇用形態";
        private const string AUTHORITYLEVELNM2_TITLE = "ロール（権限）";
        private const string BELONGSECTIONCODE_TITLE = "所属拠点コード";
        private const string SECTIONGUIDENM_TITLE = "所属拠点";
        private const string BELONGSUBSECTIONCODE_TITLE = "所属部門コード";
        private const string SUBSECTIONNAME_TITLE = "所属部門";
        private const string ENTERCOMPANYDATE_TITLE = "入社日";
        private const string RETIREMENTDATE_TITLE = "退職日";
        private const string EMPLOYANALYSCODE1_TITLE = "分析コード１";
        private const string EMPLOYANALYSCODE2_TITLE = "分析コード２";
        private const string EMPLOYANALYSCODE3_TITLE = "分析コード３";
        private const string EMPLOYANALYSCODE4_TITLE = "分析コード４";
        private const string EMPLOYANALYSCODE5_TITLE = "分析コード５";
        private const string EMPLOYANALYSCODE6_TITLE = "分析コード６";

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
                status = this._employeeSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._employeePrintWork);
            }
            else
            {
                status = this._employeeSetAcs.SearchAll(
                    out PrintSets,
                    this._enterpriseCode,
                    this._employeePrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 従業員クラスをデータセットへ展開する
                        int index = 0;
                        foreach (EmployeeSet employeeSet in PrintSets)
                        {

                            SecPrintSetToDataSet(employeeSet.Clone(), index);
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
                            "PMKHN08520U", 						// アセンブリＩＤまたはクラスＩＤ
                            "従業員マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._employeeSetAcs, 				// エラーが発生したオブジェクト
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
            printInfo.jyoken = this._employeePrintWork;
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
            this._employeePrintWork = new EmployeePrintWork();

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
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // １行目
            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 160;
            sizeHeader.Width = 160;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 135;
            sizeHeader.Width = 135;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 2行目

            sizeCell.Width = 260;
            sizeHeader.Width = 260;
            UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 160;
            sizeHeader.Width = 160;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 135;
            sizeHeader.Width = 135;
            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVEL1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVEL2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BELONGSECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BELONGSUBSECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVEL1].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVEL2].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[BELONGSECTIONCODE].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[BELONGSUBSECTIONCODE].Hidden = true;

            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].Header.Caption = EMPLOYEECODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[NAME].Header.Caption = NAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[KANA].Header.Caption = KANA_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].Header.Caption = SHORTNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].Header.Caption = SEXNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].Header.Caption = BIRTHDAY_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].Header.Caption = COMPANYTELNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].Header.Caption = PORTABLETELNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVEL1].Header.Caption = AUTHORITYLEVEL1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].Header.Caption = AUTHORITYLEVELNM1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVEL2].Header.Caption = AUTHORITYLEVEL2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].Header.Caption = AUTHORITYLEVELNM2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BELONGSECTIONCODE].Header.Caption = BELONGSECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].Header.Caption = SECTIONGUIDENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BELONGSUBSECTIONCODE].Header.Caption = BELONGSUBSECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].Header.Caption = SUBSECTIONNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].Header.Caption = ENTERCOMPANYDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].Header.Caption = RETIREMENTDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].Header.Caption = EMPLOYANALYSCODE1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].Header.Caption = EMPLOYANALYSCODE2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].Header.Caption = EMPLOYANALYSCODE3_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].Header.Caption = EMPLOYANALYSCODE4_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].Header.Caption = EMPLOYANALYSCODE5_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].Header.Caption = EMPLOYANALYSCODE6_TITLE;

            // フォーマットの設定
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].Format = "yyyy/MM/dd";

            #region 列配置
            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].RowLayoutColumnInfo.SpanY = 4;

            UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[NAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SHORTNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BIRTHDAY].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERCOMPANYDATE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].RowLayoutColumnInfo.OriginX = 18;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].RowLayoutColumnInfo.OriginX = 20;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE3].RowLayoutColumnInfo.SpanY = 2;

            // ２行目
            UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.SpanX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[KANA].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SEXNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[AUTHORITYLEVELNM2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUBSECTIONNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PORTABLETELNO].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[RETIREMENTDATE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].RowLayoutColumnInfo.OriginX = 18;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].RowLayoutColumnInfo.OriginX = 20;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYANALYSCODE6].RowLayoutColumnInfo.SpanY = 2;
            #endregion 列配置
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            // 開始拠点区分
            if (this._employeePrintWork.SectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了拠点区分
            if (this._employeePrintWork.SectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            // 開始従業員ｺｰﾄﾞ
            if (this._employeePrintWork.EmployeeCodeSt != this.tEdit_EmployeeCode_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了従業員ｺｰﾄﾞ
            if (this._employeePrintWork.EmployeeCodeEd != this.tEdit_EmployeeCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            // 削除指定
            if (this._employeePrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._employeePrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._employeePrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.ub_St_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_EmployeeGuide, Size16_Index.STAR1);

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // 初期フォーカスセット
                this.tEdit_SectionCode_St.Focus();
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


            // 拠点コード
            if (
                (this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this.tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("拠点{0}", ct_RangeError);
                errComponent = this.tEdit_SectionCode_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // 担当者コード
            if (
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this.tEdit_EmployeeCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
                errComponent = this.tEdit_EmployeeCode_St;
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
                // 開始拠点
                this._employeePrintWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText;
                // 終了拠点
                this._employeePrintWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText;
                // 開始拠点
                this._employeePrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText;
                // 終了拠点
                this._employeePrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText;

                // 削除指定区分
                this._employeePrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._employeePrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._employeePrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
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
        /// 従業員クラスデータセット展開処理
        /// </summary>
        /// <param name="employeeSet">従業員クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 従業員クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(EmployeeSet employeeSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (employeeSet.EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYEECODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYEECODE] = employeeSet.EmployeeCode.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][NAME] = employeeSet.Name;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][KANA] = employeeSet.Kana;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHORTNAME] = employeeSet.ShortName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SEXNAME] = employeeSet.SexName;
            if (employeeSet.Birthday == DateTime.MinValue)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BIRTHDAY] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BIRTHDAY] = employeeSet.Birthday;
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYTELNO] = employeeSet.CompanyTelNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PORTABLETELNO] = employeeSet.PortableTelNo;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][AUTHORITYLEVEL1] = employeeSet.AuthorityLevel1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][AUTHORITYLEVELNM1] = employeeSet.AuthorityLevelNm1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][AUTHORITYLEVEL2] = employeeSet.AuthorityLevel2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][AUTHORITYLEVELNM2] = employeeSet.AuthorityLevelNm2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BELONGSECTIONCODE] = employeeSet.BelongSectionCode;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDENM] = employeeSet.SectionGuideNm;
            if (employeeSet.BelongSubSectionCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BELONGSUBSECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BELONGSUBSECTIONCODE] = employeeSet.BelongSubSectionCode;
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUBSECTIONNAME] = employeeSet.SubSectionName;
            if (employeeSet.EnterCompanyDate == DateTime.MinValue)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERCOMPANYDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERCOMPANYDATE] = employeeSet.EnterCompanyDate;
            }
            if (employeeSet.RetirementDate == DateTime.MinValue)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][RETIREMENTDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][RETIREMENTDATE] = employeeSet.RetirementDate;
            }
            if (employeeSet.EmployAnalysCode1 == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE1] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE1] = employeeSet.EmployAnalysCode1.ToString("000");
            }
            if (employeeSet.EmployAnalysCode2 == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE2] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE2] = employeeSet.EmployAnalysCode2.ToString("000");
            }
            if (employeeSet.EmployAnalysCode3 == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE3] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE3] = employeeSet.EmployAnalysCode3.ToString("000");
            }
            if (employeeSet.EmployAnalysCode4 == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE4] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE4] = employeeSet.EmployAnalysCode4.ToString("000");
            }
            if (employeeSet.EmployAnalysCode5 == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE5] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE5] = employeeSet.EmployAnalysCode5.ToString("000");
            }
            if (employeeSet.EmployAnalysCode6 == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE6] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYANALYSCODE6] = employeeSet.EmployAnalysCode6.ToString("000");
            }


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
            PrintSetTable.Columns.Add(EMPLOYEECODE, typeof(string));		    // 従業員コード
            PrintSetTable.Columns.Add(NAME, typeof(string));		            // 名称
            PrintSetTable.Columns.Add(KANA, typeof(string));		            // カナ
            PrintSetTable.Columns.Add(SHORTNAME, typeof(string));		        // 短縮名称
            PrintSetTable.Columns.Add(SEXNAME, typeof(string));		            // 性別名称
            PrintSetTable.Columns.Add(BIRTHDAY, typeof(DateTime));		        // 生年月日
            PrintSetTable.Columns.Add(COMPANYTELNO, typeof(string));		    // 電話番号（会社）
            PrintSetTable.Columns.Add(PORTABLETELNO, typeof(string));		    // 電話番号（携帯）
            PrintSetTable.Columns.Add(AUTHORITYLEVEL1, typeof(Int32));		    // 職種
            PrintSetTable.Columns.Add(AUTHORITYLEVELNM1, typeof(string));		// 職種名称
            PrintSetTable.Columns.Add(AUTHORITYLEVEL2, typeof(Int32));		    // 雇用形態
            PrintSetTable.Columns.Add(AUTHORITYLEVELNM2, typeof(string));		// 雇用形態名称
            PrintSetTable.Columns.Add(BELONGSECTIONCODE, typeof(string));		// 所属拠点コード
            PrintSetTable.Columns.Add(SECTIONGUIDENM, typeof(string));		    // 拠点ガイド名称
            PrintSetTable.Columns.Add(BELONGSUBSECTIONCODE, typeof(Int32));		// 所属部門コード
            PrintSetTable.Columns.Add(SUBSECTIONNAME, typeof(string));		    // 部門名称
            PrintSetTable.Columns.Add(ENTERCOMPANYDATE, typeof(DateTime));		// 入社日
            PrintSetTable.Columns.Add(RETIREMENTDATE, typeof(DateTime));		// 退職日
            PrintSetTable.Columns.Add(EMPLOYANALYSCODE1, typeof(Int32));		// 従業員分析コード１
            PrintSetTable.Columns.Add(EMPLOYANALYSCODE2, typeof(Int32));		// 従業員分析コード２
            PrintSetTable.Columns.Add(EMPLOYANALYSCODE3, typeof(Int32));		// 従業員分析コード３
            PrintSetTable.Columns.Add(EMPLOYANALYSCODE4, typeof(Int32));		// 従業員分析コード４
            PrintSetTable.Columns.Add(EMPLOYANALYSCODE5, typeof(Int32));		// 従業員分析コード５
            PrintSetTable.Columns.Add(EMPLOYANALYSCODE6, typeof(Int32));		// 従業員分析コード６


            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08520UA
        #region ◎ PMKHN08520UA_Load Event
        /// <summary>
        /// PMKHN08520UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08520UA_Load(object sender, EventArgs e)
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

        #endregion ◆ PMKHN08520UA

        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
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

            // ADD 2008/11/27 不具合対応[8309] ---------->>>>>
            if (status != 0)
            {
                return;
            }
            // ADD 2008/11/27 不具合対応[8309] ----------<<<<<

            // コード展開
            targetControl.DataText = secInfoSet.SectionCode.Trim();
            // フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// 担当者ガイドクリック
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