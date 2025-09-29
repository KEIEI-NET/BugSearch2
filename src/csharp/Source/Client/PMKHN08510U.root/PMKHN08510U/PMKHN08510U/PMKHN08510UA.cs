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
    /// 倉庫マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 倉庫マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public partial class PMKHN08510UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 倉庫マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08510UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._warehousePrintSetAcs = new WarehousePrintSetAcs();


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
        // ログイン拠点(自拠点)
        private string _loginSectionCode;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private WarehousePrintWork _warehousePrintWork;

        // データアクセス
        private WarehousePrintSetAcs _warehousePrintSetAcs;

        //倉庫ガイド
        private WarehouseAcs _warehouseGuideAcs = null;

        private Hashtable secInfoSetTable;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08510UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08510U";
        //// 帳票名称
        private string _printName = "倉庫マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "WAREHOUSEPRINTSET";

        // dataview名称用
        private const string WAREHOUSECODE = "warehousecode";
        private const string WAREHOUSENAME = "warehousename";
        private const string SECTIONCODE = "sectioncode";
        private const string SECTIONGUIDENM = "sectionguidenm";
        private const string CUSTOMERCODE = "customercode";
        private const string CUSTOMERSNM = "customersnm";
        private const string MAINMNGWAREHOUSECD = "mainmngwarehousecd";
        private const string MAINWAREHOUSENAME = "mainwarehousename";
        private const string STOCKBLNKTREMARK = "stockblnktremark";

        private const string WAREHOUSECODE_TITLE = "ｺｰﾄﾞ";
        private const string WAREHOUSENAME_TITLE = "倉庫名";
        private const string SECTIONCODE_TITLE = "管理拠点";
        private const string SECTIONGUIDENM_TITLE = "管理拠点名";
        private const string CUSTOMERCODE_TITLE = "得意先";
        private const string CUSTOMERSNM_TITLE = "得意先名";
        private const string MAINMNGWAREHOUSECD_TITLE = "主管倉庫";
        private const string MAINWAREHOUSENAME_TITLE = "主管倉庫名";
        private const string STOCKBLNKTREMARK_TITLE = "リマーク";

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
            ArrayList warehousePrintSets = null;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._warehousePrintSetAcs.Search(
                    out warehousePrintSets,
                    this._enterpriseCode,
                    this._warehousePrintWork);
            }
            else
            {
                status = this._warehousePrintSetAcs.SearchAll(
                    out warehousePrintSets,
                    this._enterpriseCode,
                    this._warehousePrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 倉庫情報クラスをデータセットへ展開する
                        int index = 0;
                        foreach (WarehousePrintSet warehousePrintSet in warehousePrintSets)
                        {

                            SecPrintSetToDataSet(warehousePrintSet.Clone(), index);
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
                            "PMKHN08510U", 						// アセンブリＩＤまたはクラスＩＤ
                            "倉庫マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._warehousePrintSetAcs, 				// エラーが発生したオブジェクト
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
            printInfo.prpnm = "倉庫マスタ";

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._warehousePrintWork;
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
            this._warehousePrintWork = new WarehousePrintWork();

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
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // １行目
            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 40;
            sizeHeader.Width = 40;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 80;
            sizeHeader.Width = 80;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

         
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].Header.Caption = WAREHOUSECODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].Header.Caption = WAREHOUSENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Header.Caption = SECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].Header.Caption = SECTIONGUIDENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].Header.Caption = MAINMNGWAREHOUSECD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].Header.Caption = MAINWAREHOUSENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].Header.Caption = STOCKBLNKTREMARK_TITLE;

            #region 列配置
            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSECODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAINMNGWAREHOUSECD].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAINWAREHOUSENAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKBLNKTREMARK].RowLayoutColumnInfo.SpanY = 2;          
            #endregion 列配置
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            // 開始倉庫区分
            if (this._warehousePrintWork.WarehouseCodeSt != this.tEdit_WarehouseCode_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了倉庫区分
            if (this._warehousePrintWork.WarehouseCodeEd != this.tEdit_WarehouseCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            // 削除指定
            if (this._warehousePrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._warehousePrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._warehousePrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.St_WarehouseGuide_Button, Size16_Index.STAR1);
                this.SetIconImage(this.Ed_WarehouseGuide_Button, Size16_Index.STAR1);

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // 初期フォーカスセット
                this.tEdit_WarehouseCode_St.Focus();
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

            //倉庫コード
            if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseCode_St.DataText.Trim().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.Trim()) > 0)
                {
                    errMessage = "倉庫の範囲指定に誤りがあります。";
                    errComponent = this.tEdit_WarehouseCode_St;
                    status = false;
                    return status;
                }
            }

            // 削除日付
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    status = false;
                    return status;
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    status = false;
                    return status;
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
                // 開始倉庫
                this._warehousePrintWork.WarehouseCodeSt = this.tEdit_WarehouseCode_St.DataText;
                // 終了倉庫
                this._warehousePrintWork.WarehouseCodeEd = this.tEdit_WarehouseCode_Ed.DataText;

                // 削除指定区分
                this._warehousePrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._warehousePrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._warehousePrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
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
        /// 拠点情報クラスデータセット展開処理
        /// </summary>
        /// <param name="warehousePrintSet">拠点情報クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 拠点情報クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(WarehousePrintSet warehousePrintSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            // 倉庫コード
            if (warehousePrintSet.WarehouseCode.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSECODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSECODE] = warehousePrintSet.WarehouseCode.Trim().PadLeft(4, '0');
            }
            // 倉庫名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSENAME] = warehousePrintSet.WarehouseName;
            // 管理拠点コード
            if (warehousePrintSet.SectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = warehousePrintSet.SectionCode.Trim().PadLeft(2, '0');
            }
            // 管理拠点名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDENM] = warehousePrintSet.SectionGuideNm;
            // 得意先コード
            if (warehousePrintSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = warehousePrintSet.CustomerCode.ToString("00000000");
            }
            // 得意先名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERSNM] = warehousePrintSet.CustomerSnm;
            // 主管倉庫コード
            if (warehousePrintSet.MainMngWarehouseCd.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAINMNGWAREHOUSECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAINMNGWAREHOUSECD] = warehousePrintSet.MainMngWarehouseCd.Trim().PadLeft(4, '0');
            }
            // 主管倉庫名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAINWAREHOUSENAME] = warehousePrintSet.MainWarehouseName;
            // 在庫一括リマーク
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKBLNKTREMARK] = warehousePrintSet.StockBlnktRemark;


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
            DataTable warehousePrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            warehousePrintSetTable.Columns.Add(WAREHOUSECODE, typeof(string));          // 倉庫コード
            warehousePrintSetTable.Columns.Add(WAREHOUSENAME, typeof(string));          // 倉庫名称
            warehousePrintSetTable.Columns.Add(SECTIONCODE, typeof(string));            // 管理拠点コード
            warehousePrintSetTable.Columns.Add(SECTIONGUIDENM, typeof(string));         // 管理拠点名称
            warehousePrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));            // 得意先コード
            warehousePrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));            // 得意先名称
            warehousePrintSetTable.Columns.Add(MAINMNGWAREHOUSECD, typeof(string));     // 主管倉庫コード
            warehousePrintSetTable.Columns.Add(MAINWAREHOUSENAME, typeof(string));      // 主管倉庫名称
            warehousePrintSetTable.Columns.Add(STOCKBLNKTREMARK, typeof(string));       // 在庫一括リマーク


            this.Bind_DataSet.Tables.Add(warehousePrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08510UA
        #region ◎ PMKHN08510UA_Load Event
        /// <summary>
        /// PMKHN08510UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08510UA_Load(object sender, EventArgs e)
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

        #endregion ◆ PMKHN08510UA


        #region 倉庫ガイド
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }

            // 倉庫ガイド起動
            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._loginSectionCode);

            if (status == 0)
            {
                if (warehouseData != null)
                {
                    // 開始、終了どちらのボタンが押されたか？
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_WarehouseGuide_Button)
                    {
                        // 開始
                        this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                        // 次のコントロールにフォーカス移動
                        this.tEdit_WarehouseCode_Ed.Focus();
                    }
                    else
                    {
                        // 終了
                        this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                        // 次のコントロールにフォーカス移動
                        this.tComboEditor_LogicalDeleteCode.Focus();
                    }
                }
            }
            else
            {
                // キャンセルなのでなにもしない
            }

        }
        #endregion

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