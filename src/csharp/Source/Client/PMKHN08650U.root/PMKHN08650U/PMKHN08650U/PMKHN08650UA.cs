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
    /// 代替マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 代替マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public partial class PMKHN08650UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 代替マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 代替マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08650UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._partsSubstSetAcs = new PartsSubstSetAcs();


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
        private PartsSubstPrintWork _partsSubstPrintWork;

        // データアクセス
        private PartsSubstSetAcs _partsSubstSetAcs;

        private GoodsAcs _goodsAcs;

        private Hashtable secInfoSetTable;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08650UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08650U";
        //// 帳票名称
        private string _printName = "代替マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "PARTSSUBSTSET";

        // dataview名称用
        private const string CHGSRCMAKERCD = "chgsrcmakercd";
        private const string CHGSRCMAKERNAME = "chgsrcmakername";
        private const string CHGSRCGOODSNO = "chgsrcgoodsno";
        private const string CHGDESTMAKERCD = "chgdestmakercd";
        private const string CHGDESTMAKERNAME = "chgdestmakername";
        private const string CHGDESTGOODSNO = "chgdestgoodsno";
        private const string APPLYSTADATE = "applystadate";
        private const string APPLYENDDATE = "applyenddate";

        private const string CHGSRCMAKERCD_TITLE = "ｺｰﾄﾞ";
        private const string CHGSRCMAKERNAME_TITLE = "名称";
        private const string CHGSRCGOODSNO_TITLE = "代替元品番";
        private const string CHGDESTMAKERCD_TITLE = "代替先メーカー";
        private const string CHGDESTMAKERNAME_TITLE = "代替先メーカー名";
        private const string CHGDESTGOODSNO_TITLE = "代替先品番";
        private const string APPLYSTADATE_TITLE = "適用開始日";
        private const string APPLYENDDATE_TITLE = "適用終了日";


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
                status = this._partsSubstSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._partsSubstPrintWork);
            }
            else
            {
                status = this._partsSubstSetAcs.SearchAll(
                    out PrintSets,
                    this._enterpriseCode,
                    this._partsSubstPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 代替クラスをデータセットへ展開する
                        int index = 0;
                        foreach (PartsSubstSet partsSubstSet in PrintSets)
                        {

                            SecPrintSetToDataSet(partsSubstSet.Clone(), index);
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
                            "PMKHN08650U", 						// アセンブリＩＤまたはクラスＩＤ
                            "代替マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._partsSubstSetAcs, 				// エラーが発生したオブジェクト
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
            printInfo.jyoken = this._partsSubstPrintWork;
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
            this._partsSubstPrintWork = new PartsSubstPrintWork();

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
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // １行目
            sizeCell.Width = 270;
            sizeHeader.Width = 270;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            sizeCell.Width = 270;
            sizeHeader.Width = 270;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 120;
            sizeHeader.Width = 120;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            sizeCell.Width = 270;
            sizeHeader.Width = 270;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 270;
            sizeHeader.Width = 270;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].Header.Caption = CHGSRCMAKERCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].Header.Caption = CHGSRCMAKERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].Header.Caption = CHGSRCGOODSNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].Header.Caption = CHGDESTMAKERCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].Header.Caption = CHGDESTMAKERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].Header.Caption = CHGDESTGOODSNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Header.Caption = APPLYSTADATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Header.Caption = APPLYENDDATE_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Format = "yyyy/MM/dd";

            #region 列配置
            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERCD].RowLayoutColumnInfo.SpanY = 4;

            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCMAKERNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGSRCGOODSNO].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERCD].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTMAKERNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CHGDESTGOODSNO].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.SpanY = 2;
            #endregion 列配置
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            // 開始代替元メーカー
            if (this._partsSubstPrintWork.ChgSrcMakerCdSt != this.tNedit_GoodsMakerCd_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了代替元メーカー
            if (this._partsSubstPrintWork.ChgSrcMakerCdEd != this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始代替元品番
            if (this._partsSubstPrintWork.ChgSrcGoodsNoSt != this.tEdit_GoodsNo_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了代替元品番
            if (this._partsSubstPrintWork.ChgSrcGoodsNoEd != this.tEdit_GoodsNo_Ed.DataText)
            {
                status = false;
                return status;
            }            
            // 削除指定
            if (this._partsSubstPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._partsSubstPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._partsSubstPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // 初期フォーカスセット
                this.tNedit_GoodsMakerCd_St.Focus();
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


            // 代替
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("代替元メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
            }

            // カナ
            if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_GoodsNo_St.DataText.CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0)
            {
                errMessage = string.Format("代替元品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
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
                // 開始代替元メーカー
                this._partsSubstPrintWork.ChgSrcMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了代替元メーカー
                this._partsSubstPrintWork.ChgSrcMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // 開始代替元品番
                this._partsSubstPrintWork.ChgSrcGoodsNoSt = this.tEdit_GoodsNo_St.DataText;
                // 終了代替元品番
                this._partsSubstPrintWork.ChgSrcGoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;
                // 削除指定区分
                this._partsSubstPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._partsSubstPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._partsSubstPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
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
        /// 代替クラスデータセット展開処理
        /// </summary>
        /// <param name="partsSubstSet">代替クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 代替クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(PartsSubstSet partsSubstSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            if (partsSubstSet.ChgSrcMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGSRCMAKERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGSRCMAKERCD] = partsSubstSet.ChgSrcMakerCd.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGSRCMAKERNAME] = partsSubstSet.ChgSrcMakerName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGSRCGOODSNO] = partsSubstSet.ChgSrcGoodsNo;
            if (partsSubstSet.ChgDestMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGDESTMAKERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGDESTMAKERCD] = partsSubstSet.ChgDestMakerCd.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGDESTMAKERNAME] = partsSubstSet.ChgDestMakerName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CHGDESTGOODSNO] = partsSubstSet.ChgDestGoodsNo;
            if (partsSubstSet.ApplyEndDate == DateTime.MinValue)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYSTADATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYSTADATE] = partsSubstSet.ApplyStaDate;
            }
            if ((partsSubstSet.ApplyEndDate == DateTime.Parse("9999/12/31")) ||
                    (partsSubstSet.ApplyEndDate == DateTime.MaxValue))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYENDDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYENDDATE] = partsSubstSet.ApplyEndDate;
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
            PrintSetTable.Columns.Add(CHGSRCMAKERCD, typeof(string));		// 	ｺｰﾄﾞ
            PrintSetTable.Columns.Add(CHGSRCMAKERNAME, typeof(string));		// 	名称
            PrintSetTable.Columns.Add(CHGSRCGOODSNO, typeof(string));		// 	代替元品番
            PrintSetTable.Columns.Add(CHGDESTMAKERCD, typeof(string));		// 	代替先メーカー
            PrintSetTable.Columns.Add(CHGDESTMAKERNAME, typeof(string));		// 	代替先メーカー名
            PrintSetTable.Columns.Add(CHGDESTGOODSNO, typeof(string));		// 	代替先品番
            PrintSetTable.Columns.Add(APPLYSTADATE, typeof(DateTime));		// 	適用開始日
            PrintSetTable.Columns.Add(APPLYENDDATE, typeof(DateTime));		// 	適用終了日

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08650UA
        #region ◎ PMKHN08650UA_Load Event
        /// <summary>
        /// PMKHN08650UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08650UA_Load(object sender, EventArgs e)
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

        #endregion ◆ PMKHN08650UA

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            MakerUMnt maker;
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }
            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();

            // 次フォーカス
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
        #endregion ■ Control Event


    }
}