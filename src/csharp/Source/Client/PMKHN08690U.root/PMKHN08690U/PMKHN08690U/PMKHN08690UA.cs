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
    /// 拠点情報マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点情報マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public partial class PMKHN08690UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 拠点情報マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08690UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secPrintSetAcs = new SecPrintSetAcs();

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
        private SectionPrintWork _sectionPrintWork;

        // データアクセス
        private SecPrintSetAcs _secPrintSetAcs;

        private SecInfoSetAcs _secInfoSetAcs;

        private Hashtable secInfoSetTable;

        private string _Companytelno1_title = "電話番号１";
        private string _Companytelno2_title = "電話番号２";
        private string _Companytelno3_title = "ＦＡＸ";

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08690UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08690U";
        //// 帳票名称
        private string _printName = "拠点情報マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "SECPRINTSET";

        // dataview名称用
        private const string SECTIONCODE = "sectioncode";
        private const string COMPANYNAMECD1 = "companynamecd1";
        private const string COMPANYNAME1 = "companyname1";
        private const string COMPANYNAME2 = "companyname2";
        private const string SECTIONGUIDESNM = "sectionguidesnm";
        private const string SECTIONGUIDENM = "sectionguidenm";
        private const string POSTNO = "postno";
        private const string ADDRESS1 = "address1";
        private const string ADDRESS3 = "address3";
        private const string ADDRESS4 = "address4";
        private const string COMPANYTELNO1 = "companytelno1";
        private const string COMPANYTELNO2 = "companytelno2";
        private const string COMPANYTELNO3 = "companytelno3";
        private const string COMPANYTELTITLE1 = "companyteltitle1";
        private const string COMPANYTELTITLE2 = "companyteltitle2";
        private const string COMPANYTELTITLE3 = "companyteltitle3";
        private const string SECTWAREHOUSECD1 = "sectwarehousecd1";
        private const string SECTWAREHOUSECD2 = "sectwarehousecd2";
        private const string SECTWAREHOUSECD3 = "sectwarehousecd3";
        private const string WAREHOUSENAME1 = "warehousename1";
        private const string WAREHOUSENAME2 = "warehousename2";
        private const string WAREHOUSENAME3 = "warehousename3";
        private const string COMPANYSETNOTE1 = "companysetnote1";
        private const string COMPANYSETNOTE2 = "companysetnote2";

        private const string SECTIONCODE_TITLE = "ｺｰﾄﾞ";
        private const string COMPANYNAMECD1_TITLE = "名称コード";
        private const string COMPANYNAME1_TITLE = "名称１";
        private const string COMPANYNAME2_TITLE = "名称２";
        private const string SECTIONGUIDESNM_TITLE = "略称";
        private const string SECTIONGUIDENM_TITLE = "ガイド名称";
        private const string POSTNO_TITLE = "郵便番号";
        private const string ADDRESS1_TITLE = "住所１";
        private const string ADDRESS3_TITLE = "住所２";
        private const string ADDRESS4_TITLE = "住所３";
        private const string SECTWAREHOUSECD1_TITLE = "拠点倉庫１";
        private const string SECTWAREHOUSECD2_TITLE = "拠点倉庫２";
        private const string SECTWAREHOUSECD3_TITLE = "拠点倉庫３";
        private const string WAREHOUSENAME1_TITLE = "拠点倉庫名１";
        private const string WAREHOUSENAME2_TITLE = "拠点倉庫名２";
        private const string WAREHOUSENAME3_TITLE = "拠点倉庫名３";
        private const string COMPANYSETNOTE1_TITLE = "備考１";
        private const string COMPANYSETNOTE2_TITLE = "備考２";

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
            ArrayList secPrintSets = null;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._secPrintSetAcs.Search(
                    out secPrintSets,
                    this._enterpriseCode,
                    this._sectionPrintWork);
            }
            else
            {
                status = this._secPrintSetAcs.SearchAll(
                    out secPrintSets,
                    this._enterpriseCode,
                    this._sectionPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 拠点情報クラスをデータセットへ展開する
                        int index = 0;
                        foreach (SecPrintSet secPrintSet in secPrintSets)
                        {

                            SecPrintSetToDataSet(secPrintSet.Clone(), index);
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
                            "PMKHN08690U", 						// アセンブリＩＤまたはクラスＩＤ
                            "拠点情報マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._secPrintSetAcs, 				// エラーが発生したオブジェクト
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
            printInfo.jyoken = this._sectionPrintWork;
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
            this._sectionPrintWork = new SectionPrintWork();

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
            sizeCell.Width = 40;
            sizeHeader.Height = 20;
            sizeHeader.Width = 40;

            // コード
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // １行目
            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 480;
            sizeHeader.Width = 480;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 2行目

            sizeCell.Width = 160;
            sizeHeader.Width = 160;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 135;
            sizeHeader.Width = 135;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 480;
            sizeHeader.Width = 480;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 3行目

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 480;
            sizeHeader.Width = 480;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAMECD1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELTITLE1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELTITLE2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELTITLE3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAMECD1].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELTITLE1].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELTITLE2].Hidden = true;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELTITLE3].Hidden = true;

            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Header.Caption = SECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAMECD1].Header.Caption = COMPANYNAMECD1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].Header.Caption = COMPANYNAME1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].Header.Caption = COMPANYNAME2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Header.Caption = SECTIONGUIDESNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].Header.Caption = SECTIONGUIDENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].Header.Caption = POSTNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].Header.Caption = ADDRESS1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].Header.Caption = ADDRESS3_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].Header.Caption = ADDRESS4_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].Header.Caption = this._Companytelno1_title;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].Header.Caption = this._Companytelno2_title;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].Header.Caption = this._Companytelno3_title;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].Header.Caption = SECTWAREHOUSECD1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].Header.Caption = SECTWAREHOUSECD2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].Header.Caption = SECTWAREHOUSECD3_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].Header.Caption = WAREHOUSENAME1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].Header.Caption = WAREHOUSENAME2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].Header.Caption = WAREHOUSENAME3_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].Header.Caption = COMPANYSETNOTE1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].Header.Caption = COMPANYSETNOTE2_TITLE;


            #region 列配置
            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanY = 6;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].RowLayoutColumnInfo.SpanX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].RowLayoutColumnInfo.SpanX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYNAME2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[POSTNO].RowLayoutColumnInfo.SpanY = 6;

            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].RowLayoutColumnInfo.OriginX = 18;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME1].RowLayoutColumnInfo.SpanY = 2;



            // ２行目
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDENM].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYTELNO3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].RowLayoutColumnInfo.OriginX = 18;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].RowLayoutColumnInfo.OriginY = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME2].RowLayoutColumnInfo.SpanY = 2;

            // ３行目
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].RowLayoutColumnInfo.OriginY = 4;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].RowLayoutColumnInfo.SpanX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].RowLayoutColumnInfo.OriginY = 4;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].RowLayoutColumnInfo.SpanX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[COMPANYSETNOTE2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.OriginY = 4;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ADDRESS4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].RowLayoutColumnInfo.OriginY = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTWAREHOUSECD3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].RowLayoutColumnInfo.OriginX = 18;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].RowLayoutColumnInfo.OriginY = 4;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[WAREHOUSENAME3].RowLayoutColumnInfo.SpanY = 2;
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
            if (this._sectionPrintWork.SectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了拠点区分
            if (this._sectionPrintWork.SectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            // 削除指定
            if (this._sectionPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._sectionPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._sectionPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
                this._sectionPrintWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText;
                // 終了拠点
                this._sectionPrintWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText;

                // 削除指定区分
                this._sectionPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._sectionPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._sectionPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
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
        /// <param name="secPrintSet">拠点情報クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 拠点情報クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(SecPrintSet secPrintSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            // 拠点コード
            if (secPrintSet.SectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = secPrintSet.SectionCode.Trim().PadLeft(2, '0');
            }
            // 自社名称コード
            if (secPrintSet.CompanyNameCd1 == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYNAMECD1] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYNAMECD1] = secPrintSet.CompanyNameCd1.ToString("0000");
            }
            // 自社名称1
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYNAME1] = secPrintSet.CompanyName1;
            // 自社名称2
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYNAME2] = secPrintSet.CompanyName2;
            // 拠点ガイド名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDENM] = secPrintSet.SectionGuideNm;
            // 拠点ガイド略称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = secPrintSet.SectionGuideSnm;
            // 郵便番号
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][POSTNO] = secPrintSet.PostNo;
            // 住所１
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ADDRESS1] = secPrintSet.Address1;
            // 住所２
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ADDRESS3] = secPrintSet.Address3;
            // 住所３
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ADDRESS4] = secPrintSet.Address4;
            // 電話番号1
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYTELNO1] = secPrintSet.CompanyTelNo1;
            // 電話番号2
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYTELNO2] = secPrintSet.CompanyTelNo2;
            // 電話番号3
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYTELNO3] = secPrintSet.CompanyTelNo3;
            // 電話番号名称1
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYTELTITLE1] = secPrintSet.CompanyTelTitle1;
            // 電話番号名称2
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYTELTITLE2] = secPrintSet.CompanyTelTitle2;
            // 電話番号名称3
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYTELTITLE3] = secPrintSet.CompanyTelTitle3;
            //拠点倉庫コード1
            if (secPrintSet.SectWarehouseCd1.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTWAREHOUSECD1] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTWAREHOUSECD1] = secPrintSet.SectWarehouseCd1.Trim().PadLeft(4, '0');
            }
            //拠点倉庫名称1
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSENAME1] = secPrintSet.WarehouseName1;
            //拠点倉庫コード2
            if (secPrintSet.SectWarehouseCd2.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTWAREHOUSECD2] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTWAREHOUSECD2] = secPrintSet.SectWarehouseCd2.Trim().PadLeft(4, '0');
            }
            //拠点倉庫名称2
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSENAME2] = secPrintSet.WarehouseName2;
            //拠点倉庫コード3
            if (secPrintSet.SectWarehouseCd3.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTWAREHOUSECD3] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTWAREHOUSECD3] = secPrintSet.SectWarehouseCd3.Trim().PadLeft(4, '0');
            }
            //拠点倉庫名称3
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSENAME3] = secPrintSet.WarehouseName3;
            //備考1
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYSETNOTE1] = secPrintSet.CompanySetNote1;
            //備考2
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][COMPANYSETNOTE2] = secPrintSet.CompanySetNote2;

            // 電話タイトル名設定
            this._Companytelno1_title = secPrintSet.CompanyTelTitle1;
            this._Companytelno2_title = secPrintSet.CompanyTelTitle2;
            this._Companytelno3_title = secPrintSet.CompanyTelTitle3;

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
            DataTable secPrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            secPrintSetTable.Columns.Add(SECTIONCODE, typeof(string));			    // 	拠点コード
            secPrintSetTable.Columns.Add(COMPANYNAMECD1, typeof(Int32));			    // 	自社名称コード1
            secPrintSetTable.Columns.Add(COMPANYNAME1, typeof(string));			    // 	自社名称1
            secPrintSetTable.Columns.Add(COMPANYNAME2, typeof(string));			    // 	自社名称2
            secPrintSetTable.Columns.Add(SECTIONGUIDESNM, typeof(string));			// 	拠点ガイド略称
            secPrintSetTable.Columns.Add(SECTIONGUIDENM, typeof(string));			    // 	拠点ガイド名称
            secPrintSetTable.Columns.Add(POSTNO, typeof(string));			            // 	郵便番号
            secPrintSetTable.Columns.Add(ADDRESS1, typeof(string));			        // 	住所1（都道府県市区郡・町村・字）
            secPrintSetTable.Columns.Add(ADDRESS3, typeof(string));			        // 	住所3（番地）
            secPrintSetTable.Columns.Add(ADDRESS4, typeof(string));			        // 	住所4（アパート名称）
            secPrintSetTable.Columns.Add(COMPANYTELNO1, typeof(string));			    // 	自社電話番号1
            secPrintSetTable.Columns.Add(COMPANYTELNO2, typeof(string));			    // 	自社電話番号2
            secPrintSetTable.Columns.Add(COMPANYTELNO3, typeof(string));			    // 	自社電話番号3
            secPrintSetTable.Columns.Add(COMPANYTELTITLE1, typeof(string));			// 	自社電話番号タイトル1
            secPrintSetTable.Columns.Add(COMPANYTELTITLE2, typeof(string));			// 	自社電話番号タイトル2
            secPrintSetTable.Columns.Add(COMPANYTELTITLE3, typeof(string));			// 	自社電話番号タイトル3
            secPrintSetTable.Columns.Add(SECTWAREHOUSECD1, typeof(string));			// 	拠点倉庫コード１
            secPrintSetTable.Columns.Add(SECTWAREHOUSECD2, typeof(string));			// 	拠点倉庫コード２
            secPrintSetTable.Columns.Add(SECTWAREHOUSECD3, typeof(string));			// 	拠点倉庫コード３
            secPrintSetTable.Columns.Add(WAREHOUSENAME1, typeof(string));			    // 	倉庫名称1
            secPrintSetTable.Columns.Add(WAREHOUSENAME2, typeof(string));			    // 	倉庫名称2
            secPrintSetTable.Columns.Add(WAREHOUSENAME3, typeof(string));			    // 	倉庫名称3
            secPrintSetTable.Columns.Add(COMPANYSETNOTE1, typeof(string));			// 	自社設定摘要1
            secPrintSetTable.Columns.Add(COMPANYSETNOTE2, typeof(string));			// 	自社設定摘要2

            this.Bind_DataSet.Tables.Add(secPrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08690UA
        #region ◎ PMKHN08690UA_Load Event
        /// <summary>
        /// PMKHN08690UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08690UA_Load(object sender, EventArgs e)
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

        #endregion ◆ PMKHN08690UA

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
                nextControl = this.tComboEditor_LogicalDeleteCode;
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