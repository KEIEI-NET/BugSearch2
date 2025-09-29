//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーンマスタ印刷
// プログラム概要   : 抽出結果より出力結果イメージ表示・ＰＤＦ出力・印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/12  修正内容 : Redmine#22927 抽出条件の発行タイプを変更して印刷・PDF出力を押すと、抽出処理が行われませんの修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーンマスタ（印刷）UIフォームクラスコンストラクタ
    /// </summary>
    /// <remarks>
    /// <br>Note        : キャンペーンマスタ（印刷）UIフォームクラスコンストラクタ</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/04/25</br>
    /// </remarks>
    public partial class PMKHN08700UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// キャンペーンマスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーンマスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>UpdateNote : 2011/07/12 譚洪 Redmine#22927 抽出条件の発行タイプを変更して印刷・PDF出力を押すと、抽出処理が行われませんの修正</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08700UA()
        {
            InitializeComponent();
            
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // 変数初期化
            this._campaignMasterAcs = new CampaignMasterAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            
            this.secInfoSetTable = new Hashtable();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // ----- ADD 2011/07/12 ------- >>>>>>>>>
            this._goodsAcs = new GoodsAcs();
            String retMessage = string.Empty;
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._ownSectionCode, out retMessage);
            // ----- ADD 2011/07/12 ------- <<<<<<<<<
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

        //拠点ガイド用
        private SecInfoSetAcs _secInfoSetAcs;

        private GoodsAcs _goodsAcs = null;    // ADD 2011/07/12
        private IWin32Window _owner = null;   // ADD 2011/07/12

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private CampaignMasterPrintWork _campaignMasterPrintWork;

        // データアクセス
        private CampaignMasterAcs _campaignMasterAcs;

        //キャンペーンガイド用
        private CampaignLinkAcs _campaignLinkAcs;

        // グループコードガイド
        private BLGroupUAcs _bLGroupUAcs;

        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;

        /// <summary>メーカーマスタ　アクセスクラス</summary>
        private MakerAcs _makerAcs;

        // ユーザーガイド用
        private UserGuideAcs _userGuideAcs;

        private Hashtable secInfoSetTable;
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08700UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08700U";
        //// 帳票名称
        private string _printName = "キャンペーンマスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "CAMPAIGNSSET";

        // dataview名称用
        private const string UPDATEDATETIME = "updatedatetime";
        private const string CREATEDATETIME = "createdatetime";
        private const string CAMPAIGNCODE = "campaigncode";
        private const string CAMPAIGNNAME = "campaignname";
        private const string SECTIONCODE = "sectioncode";
        private const string SECTIONGUIDESNM = "sectionguidesnm";
        private const string CAMPAIGNOBJDIV = "campaignobjdiv";
        private const string APPLYSTADATE = "applystadate";
        private const string APPLYENDDATE = "applyenddate";
        private const string CUSTOMERCODE = "customercode";
        private const string CUSTOMERSNM = "customersnm";
        private const string GOODSNO = "goodsno";
        private const string GOODSNAME = "goodsname";
        private const string GOODSMAKERCD = "goodsmakercd";
        private const string MAKERNAME = "makername";
        private const string BLGOODSCODE = "blgoodscode";
        private const string BLGOODSHALFNAME = "blgoodshalfname";
        private const string BLGROUPCODE = "blgroupcode";
        private const string BLGROUPNAME = "blgroupname";
        private const string SALESCODE = "salescode";
        private const string GUIDENAME = "guidename";
        private const string RATEVAL = "rateval";
        private const string PRICEFL = "pricefl";
        private const string DISCOUNTRATE = "discountrate";
        private const string PRICESTARTDATE = "pricestartdate";
        private const string PRICEENDDATE = "priceenddate";
        private const string APPLYDATE = "applydate";
        private const string PRICEDATE = "pricedate";
        private const string SALESPRICESETDIV = "salespricesetdiv";

        private const string UPDATEDATETIME_TITLE = "更新日";
        private const string CREATEDATETIME_TITLE = "作成日";
        private const string CAMPAIGNCODE_TITLE = "ｺｰﾄﾞ";
        private const string CAMPAIGNNAME_TITLE = "名称";
        private const string SECTIONCODE_TITLE = "拠点";
        private const string SECTIONGUIDESNM_TITLE = "拠点名";
        private const string CAMPAIGNOBJDIV_TITLE = "対象得意先区分";
        private const string APPLYSTADATE_TITLE = "適用開始日";
        private const string APPLYENDDATE_TITLE = "適用終了日";
        private const string CUSTOMERCODE_TITLE = "得意先";
        private const string CUSTOMERSNM_TITLE = "得意先名";
        private const string GOODSNO_TITLE = "品番";
        private const string GOODSNAME_TITLE = "品名";
        private const string GOODSMAKERCD_TITLE = "ﾒｰｶｰ";
        private const string MAKERNAME_TITLE = "ﾒｰｶｰ名";
        private const string BLGOODSCODE_TITLE = "BLｺｰﾄﾞ";
        private const string BLGOODSHALFNAME_TITLE = "BLｺｰﾄﾞ名";
        private const string BLGROUPCODE_TITLE = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
        private const string BLGROUPNAME_TITLE = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名";
        private const string SALESCODE_TITLE = "販売区分";
        private const string GUIDENAME_TITLE = "販売区分名";
        private const string RATEVAL_TITLE = "売価率";
        private const string PRICEFL_TITLE = "売価額";
        private const string DISCOUNTRATE_TITLE = "値引率";
        private const string PRICESTARTDATE_TITLE = "価格開始日";
        private const string PRICEENDDATE_TITLE = "価格終了日";
        private const string APPLYDATE_TITLE = "適用期間";
        private const string PRICEDATE_TITLE = "価格日";
        private const string SALESPRICESETDIV_TITLE = "売価設定区分";

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
        /// <remarks>
        /// <br>Note		: 抽出処理を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
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
                status = this._campaignMasterAcs.Search(out PrintSets, this._enterpriseCode,  this._campaignMasterPrintWork);
            }
            else
            {
                status = this._campaignMasterAcs.SearchDelete(out PrintSets, this._enterpriseCode, this._campaignMasterPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {

                        // 商品クラスをデータセットへ展開する
                        int index = 0;
                        foreach (CampaignMaster campaignMaster in PrintSets)
                        {

                            SecPrintSetToDataSet(campaignMaster.Clone(), index);
                            ++index;
                        }
                        
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN08700U", 						// アセンブリＩＤまたはクラスＩＤ
                            "キャンペーンマスタ（印刷）", 	    // プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._campaignMasterAcs, 	        // エラーが発生したオブジェクト
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
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
            printInfo.jyoken = this._campaignMasterPrintWork;
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._campaignMasterPrintWork = new CampaignMasterPrintWork();

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
        /// <br>Programmer : 李永平</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <remarks>
        /// <br>Note		: メインフレームグリットレイアウト設定</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid)
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = UGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn uGrid in editBand.Columns)
            {
                uGrid.Hidden = false;
            }

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
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 名称
            sizeCell.Width = 180;
            sizeHeader.Width = 180;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 拠点
            sizeCell.Width = 50;
            sizeHeader.Width = 50;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 拠点名
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 対象得意先区分
            sizeCell.Width = 120;
            sizeHeader.Width = 120;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 適用開始日
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 適用終了日
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 作成日
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 更新日
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 得意先
            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 得意先名
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 品番
            sizeCell.Width = 200;
            sizeHeader.Width = 200;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 品名
            sizeCell.Width = 250;
            sizeHeader.Width = 250;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ﾒｰｶｰ
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ﾒｰｶｰ名
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BLｺｰﾄﾞ
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BLｺｰﾄﾞ名
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ名
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 販売区分
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 販売区分名
            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 売価率
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 売価率
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 売価額
            sizeCell.Width = 180;
            sizeHeader.Width = 180;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 価格開始日
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 価格終了日
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 適用期間
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 価格日
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 売価設定区分
            sizeCell.Width = 50;
            sizeHeader.Width = 50;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            #region ヘッダ名称
            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].Header.Caption = CAMPAIGNCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].Header.Caption = CAMPAIGNNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Header.Caption = SECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Header.Caption = SECTIONGUIDESNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Header.Caption = CAMPAIGNOBJDIV_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Header.Caption = APPLYSTADATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Header.Caption = APPLYENDDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Header.Caption = GOODSNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Header.Caption = GOODSNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Header.Caption = GOODSMAKERCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Header.Caption = MAKERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Header.Caption = BLGOODSHALFNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Header.Caption = BLGROUPCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Header.Caption = BLGROUPNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Header.Caption = SALESCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Header.Caption = GUIDENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].Header.Caption = DISCOUNTRATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].Header.Caption = RATEVAL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Header.Caption = PRICEFL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Header.Caption = PRICESTARTDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].Header.Caption = PRICEENDDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].Header.Caption = APPLYDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].Header.Caption = PRICEDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].Header.Caption = SALESPRICESETDIV_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].Header.Caption = UPDATEDATETIME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].Header.Caption = CREATEDATETIME_TITLE;
            #endregion

            #region 非表示処理
            //非表示処理
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].Hidden = true;          // 適用期間
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].Hidden = true;          // 価格日
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].Hidden = true;   // 売価設定区分

            if ((int)this.tComboEditor_PrintType.Value == 1) //メーカー＋品番
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;

            }
            else if ((int)this.tComboEditor_PrintType.Value == 2) //メーカー＋ＢＬコード
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;


                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = false;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 3) //メーカー＋グループコード
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 4) //メーカー
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
             else if ((int)this.tComboEditor_PrintType.Value == 5) //ＢＬコード
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
             else if ((int)this.tComboEditor_PrintType.Value == 6) //販売区分
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
             else if ((int)this.tComboEditor_PrintType.Value == 7) //マスタリスト
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].Hidden = true;
            }
            #endregion

            // 文字表示位置の設定
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 表示フォーマットの設定
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Format = "#,##0.00";
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].Format = "0.00";
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].Format = "0.00";
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].Format = "yyyy/MM/dd";

            #region 列配置


            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanY = 2;

            if ((int)this.tComboEditor_PrintType.Value == 1) // メーカー＋品番
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 30;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 32;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

            }
            else if ((int)this.tComboEditor_PrintType.Value == 2) // メーカー＋ＢＬコード
            {
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 30;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }            
            else if ((int)this.tComboEditor_PrintType.Value == 3) // メーカー＋グループコード
            {
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 30;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 4) // メーカー
            {
                

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 5) //ＢＬコード
            {
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 6) //販売区分
            {
                

                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 7) //マスタリスト
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;
            }
            #endregion 列配置
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 抽出条件チェック処理</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// <br>UpdateNote  : 2011/07/12 譚洪 Redmine#22927 抽出条件の発行タイプを変更して印刷・PDF出力を押すと、抽出処理が行われませんの修正</br>
        /// </remarks>
        public bool DataCheck()
        {
            bool status = true;

            // ----- ADD 2011/07/12 ------- >>>>>>>>>
            //印刷パターン
            if (this._campaignMasterPrintWork.PrintType != (int)this.tComboEditor_PrintType.SelectedIndex)
            {
                status = false;
                return status;
            }
            // ----- ADD 2011/07/12 ------- <<<<<<<<<

            // 開始キャンペーン
            if (this._campaignMasterPrintWork.CampaignCodeSt != this.tNedit_CampaignCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了キャンペーン
            if (this._campaignMasterPrintWork.CampaignCodeEd != this.tNedit_CampaignCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始拠点
            if (this._campaignMasterPrintWork.SectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了拠点
            if (this._campaignMasterPrintWork.SectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            // 開始メーカー
            if (this._campaignMasterPrintWork.GoodsMakerCodeSt != this.tNedit_GoodsMakerCd_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了メーカー
            if (this._campaignMasterPrintWork.GoodsMakerCodeSt != this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始ＢＬコード
            if (this._campaignMasterPrintWork.BLGoodsCodeSt != this.tNedit_BLGoodsCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了ＢＬコード
            if (this._campaignMasterPrintWork.BLGoodsCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始ＢＬグループコード
            if (this._campaignMasterPrintWork.BLGroupCodeSt != this.tNedit_BLGroupCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了ＢＬグループコード
            if (this._campaignMasterPrintWork.BLGroupCodeEd != this.tNedit_BLGroupCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始販売区分
            if (this._campaignMasterPrintWork.BLGoodsCodeSt != this.tNedit_SalesCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了販売区分
            if (this._campaignMasterPrintWork.BLGoodsCodeEd != this.tNedit_SalesCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始品番
            if (this._campaignMasterPrintWork.GoodsNoSt != this.tEdit_GoodsNo_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了品番
            if (this._campaignMasterPrintWork.GoodsNoEd != this.tEdit_GoodsNo_Ed.DataText)
            {
                status = false;
                return status;
            }            

            // 削除指定
            if (this._campaignMasterPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._campaignMasterPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._campaignMasterPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
        /// <br>Programmer	: 李永平</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tNedit_CampaignCode_St.DataText = string.Empty;
                this.tNedit_CampaignCode_Ed.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.tNedit_PriceFl.DataText = string.Empty;
                this.tNedit_RateVal.DataText = string.Empty;
                this.tNedit_DiscountRate.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.ub_St_CampaignCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CampaignCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SectionCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SectionCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SalesCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SalesCodeGuide, Size16_Index.STAR1);

                // コンボの初期化
                this.tComboEditor_PrintType.Value = 1;
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.tComboEditor_PriceFlDiv.Value = 0;
                this.tComboEditor_RateValDiv.Value = 0;
                this.tCmb_DiscountRate.Value = 0;

                // 条件指定の使用不可
                this.pn_BLCode.Visible = false;
                this.pn_BLGroupCode.Visible = false;
                this.pn_SalesCode.Visible = false;

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

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
        /// <remarks >
        /// <br>Note		: ボタンアイコン設定処理 </br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";


            // キャンペーン
            if (
                (this.tNedit_CampaignCode_St.GetInt() != 0) &&
                (this.tNedit_CampaignCode_Ed.GetInt() != 0) &&
                this.tNedit_CampaignCode_St.GetInt() > this.tNedit_CampaignCode_Ed.GetInt())
            {
                errMessage = string.Format("キャンペーンコード{0}", ct_RangeError);
                errComponent = this.tNedit_CampaignCode_St;
                status = false;
                return status;
            }

            int sectionCodeSt = 0;
            int sectionCodeEd = 0;
            int.TryParse(this.tEdit_SectionCode_St.Text, out sectionCodeSt);
            int.TryParse(this.tEdit_SectionCode_Ed.Text, out sectionCodeEd);
            // 拠点
            if (
                !string.IsNullOrEmpty(this.tEdit_SectionCode_St.Text) &&
                !string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.Text) &&
                sectionCodeSt > sectionCodeEd)
            {
                errMessage = string.Format("拠点{0}", ct_RangeError);
                errComponent = this.tEdit_SectionCode_St;
                status = false;
                return status;
            }

            // メーカー
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // BLコード
            if (
                (this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return status;
            }

            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            if (
                (this.tNedit_BLGroupCode_St.GetInt() != 0) &&
                (this.tNedit_BLGroupCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGroupCode_St.GetInt() > this.tNedit_BLGroupCode_Ed.GetInt())
            {
                errMessage = string.Format("ＢＬグループ{0}", ct_RangeError);
                errComponent = this.tNedit_BLGroupCode_St;
                status = false;
                return status;
            }

            // 品番
            if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_GoodsNo_St.DataText.CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0)
            {
                errMessage = string.Format("品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
                return status;
            }

            // 販売区分
            if (
                (this.tNedit_SalesCode_St.GetInt() != 0) &&
                (this.tNedit_SalesCode_Ed.GetInt() != 0) &&
                this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt())
            {
                errMessage = string.Format("販売区分{0}", ct_RangeError);
                errComponent = this.tNedit_SalesCode_St;
                status = false;
                return status;
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                this._campaignMasterPrintWork.EnterpriseCode = this._enterpriseCode;

                // 発行タイプ
                this._campaignMasterPrintWork.PrintType = (int)this.tComboEditor_PrintType.SelectedIndex;

                // 改頁
                this._campaignMasterPrintWork.ChangePage = (int)this.ChangePage_ultraOptionSet.Value;

                // 開始キャンペーンコード
                this._campaignMasterPrintWork.CampaignCodeSt = this.tNedit_CampaignCode_St.GetInt();

                // 終了キャンペーンコード
                this._campaignMasterPrintWork.CampaignCodeEd = this.tNedit_CampaignCode_Ed.GetInt();

                // 開始拠点コード
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText))
                {
                    this._campaignMasterPrintWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignMasterPrintWork.SectionCodeSt))
                    {
                        this._campaignMasterPrintWork.SectionCodeSt = string.Empty;
                    }
                }
                else
                {
                    this._campaignMasterPrintWork.SectionCodeSt = string.Empty;
                }
                

                // 終了拠点コード
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText))
                {
                    this._campaignMasterPrintWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignMasterPrintWork.SectionCodeEd))
                    {
                        this._campaignMasterPrintWork.SectionCodeEd = string.Empty;
                    }
                }
                else
                {
                    this._campaignMasterPrintWork.SectionCodeEd = string.Empty;
                }

                // 開始商品メーカーコード
                this._campaignMasterPrintWork.GoodsMakerCodeSt = this.tNedit_GoodsMakerCd_St.GetInt();

                // 終了商品メーカーコード
                this._campaignMasterPrintWork.GoodsMakerCodeEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // 開始BL商品コード
                this._campaignMasterPrintWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();

                // 終了BL商品コード
                this._campaignMasterPrintWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();

                // 開始BLグループコード
                this._campaignMasterPrintWork.BLGroupCodeSt = this.tNedit_BLGroupCode_St.GetInt();

                // 終了BLグループコード
                 this._campaignMasterPrintWork.BLGroupCodeEd = this.tNedit_BLGroupCode_Ed.GetInt();

                // 開始販売区分
                 this._campaignMasterPrintWork.SalesCodeSt = this.tNedit_SalesCode_St.GetInt();

                // 終了販売区分
                this._campaignMasterPrintWork.SalesCodeEd = this.tNedit_SalesCode_Ed.GetInt();

                // 値引率
                if (!string.IsNullOrEmpty(this.tNedit_DiscountRate.DataText))
                {
                    double discountRate = 0;
                    double.TryParse(this.tNedit_DiscountRate.Text, out discountRate);
                    this._campaignMasterPrintWork.DiscountRate = discountRate;
                }
                else
                {
                    this._campaignMasterPrintWork.DiscountRate = 0.00;
                }

                // 値引率区分
                this._campaignMasterPrintWork.DiscountRateDiv = this.tCmb_DiscountRate.SelectedIndex;

                // 売価率
                if (!string.IsNullOrEmpty(this.tNedit_RateVal.DataText))
                {
                    double rateVal = 0;
                    double.TryParse(this.tNedit_RateVal.Text, out rateVal);
                    this._campaignMasterPrintWork.RateVal = rateVal;
                }
                else
                {
                    this._campaignMasterPrintWork.RateVal = 0.00;
                }

                // 売価率区分
                this._campaignMasterPrintWork.RateValDiv = this.tComboEditor_RateValDiv.SelectedIndex;

                // 売価額
                if (!string.IsNullOrEmpty(this.tNedit_PriceFl.DataText))
                {
                    double priceFl = 0;
                    double.TryParse(this.tNedit_PriceFl.Text, out priceFl);
                    this._campaignMasterPrintWork.PriceFl = priceFl;
                }
                else
                {
                    this._campaignMasterPrintWork.PriceFl = 0.00;
                }

                // 売価額区分
                this._campaignMasterPrintWork.PriceFlDiv = this.tComboEditor_PriceFlDiv.SelectedIndex;

                // 開始商品番号
                this._campaignMasterPrintWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;

                // 終了商品番号
                this._campaignMasterPrintWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;              

                // 削除指定区分
                this._campaignMasterPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._campaignMasterPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._campaignMasterPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
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
        /// <br>Note		: 数値項目　終了コード取得処理。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
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
        /// <remarks >
        /// <br>Note		: 数値項目　終了コード取得処理。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <param name="campaignMaster">商品クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 商品クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>UpdateNote : 2011/07/12 譚洪 Redmine#22927 発行タイプが”メーカー＋品番”の場合に、品名が取得されませんの対応</br>
        /// </remarks>
        private void SecPrintSetToDataSet(CampaignMaster campaignMaster, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;
            }

            // キャンペーンコード
            if (campaignMaster.CampaignCode.ToString().Trim().PadLeft(6, '0').Equals("000000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = campaignMaster.CampaignCode.ToString().Trim().PadLeft(6, '0');
            }

            // キャンペーンコード名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNNAME] = campaignMaster.CampaignName;

            // キャンペーン対象区分
            if (campaignMaster.CampaignObjDiv == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNOBJDIV] = "全得意先";
            }
            else if (campaignMaster.CampaignObjDiv == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNOBJDIV] = "対象得意先";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNOBJDIV] = "中止";
            }

            // 適用開始日
            if (campaignMaster.ApplyStaDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYSTADATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYSTADATE] = campaignMaster.ApplyStaDate.ToString("####/##/##");
            }
            // 適用終了日
            if (campaignMaster.ApplyEndDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYENDDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYENDDATE] = campaignMaster.ApplyEndDate.ToString("####/##/##");
            }

            // 適用期間
            string ApplyDate = "[ " + campaignMaster.ApplyStaDate.ToString("####/##/##") + " ～ " + campaignMaster.ApplyEndDate.ToString("####/##/##") + " ]";
            if (ApplyDate == "[ // ～ // ]")
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYDATE] = ApplyDate;
            }

            // キャンペーン実施拠点
            if (campaignMaster.SectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = "00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = campaignMaster.SectionCode.Trim().PadLeft(2, '0');
            }

            // 拠点略称
            if (string.IsNullOrEmpty(campaignMaster.SectionGuideSnm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = "全社";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = campaignMaster.SectionGuideSnm;
            }

            // 得意先コード
            if (campaignMaster.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = campaignMaster.CustomerCode.ToString().Trim().PadLeft(8, '0'); ;
            }

            // 得意先略称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERSNM] = campaignMaster.CustomerSnm;

            // BL商品コード
            if (campaignMaster.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = campaignMaster.BLGoodsCode.ToString().Trim().PadLeft(5,'0'); ;
            }

            // 商品メーカーコード
            if (campaignMaster.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = campaignMaster.GoodsMakerCd.ToString().Trim().PadLeft(4,'0');
            }

            // 商品番号
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNO] = campaignMaster.GoodsNo;

            // BLグループコード
            if (campaignMaster.BLGroupCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = campaignMaster.BLGroupCode.ToString().Trim().PadLeft(5,'0');
            }

            // 販売区分コード
            if (campaignMaster.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = campaignMaster.SalesCode.ToString().Trim().PadLeft(4, '0');
            }          

            // 価格（浮動）
            if (campaignMaster.PriceFl == 0.0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEFL] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEFL] = campaignMaster.PriceFl.ToString("#,##0.00");
            }

            // 掛率
            if (campaignMaster.RateVal == 0.0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][RATEVAL] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][RATEVAL] = campaignMaster.RateVal.ToString ("0.00");
            }

            // 売価率
            if (campaignMaster.DiscountRate == 0.0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DISCOUNTRATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DISCOUNTRATE] = campaignMaster.DiscountRate.ToString("0.00");
            }
            // 価格開始日
            if (campaignMaster.PriceStartDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESTARTDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESTARTDATE] = campaignMaster.PriceStartDate.ToString("####/##/##");
            }

            // 価格終了日
            if (campaignMaster.PriceEndDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEENDDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEENDDATE] = campaignMaster.PriceEndDate.ToString("####/##/##");
            }

            // 適用期間
            string PriceDate = campaignMaster.PriceStartDate.ToString("####/##/##") + " ～ " + campaignMaster.PriceEndDate.ToString("####/##/##");
            if (PriceDate == "// ～ //")
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEDATE] = PriceDate;
            }

            // 売価設定区分
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESPRICESETDIV] = campaignMaster.SalesPriceSetDiv;

            // ＢＬコード名称（半角）
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSHALFNAME] = campaignMaster.BLGoodsHalfName;
            // メーカー名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERNAME] = campaignMaster.MakerName;

            // ----- UPD 2011/07/12 ------- >>>>>>>>>
            // 品番、メーカーの場合、
            if (this.tComboEditor_PrintType.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(campaignMaster.GoodsName))
                {
                    List<GoodsUnitData> goodsUnitDataList;
                    PartsInfoDataSet partsInfoDataSet;
                    string msg = string.Empty;

                    // 抽出条件の作成
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.GoodsMakerCd = campaignMaster.GoodsMakerCd;
                    goodsCndtn.GoodsNo = campaignMaster.GoodsNo;
                    goodsCndtn.IsSettingSupplier = 1;

                    this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

                    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                    {
                        if (goodsUnitData.LogicalDeleteCode == 0)
                        {
                            // 商品名称
                            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNAME] = goodsUnitData.GoodsName;
                        }
                    }
                }
                else
                {
                    // 商品名称
                    this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNAME] = campaignMaster.GoodsName;
                }
            }
            // ----- UPD 2011/07/12 ------- <<<<<<<<<

            // グループコード名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPNAME] = campaignMaster.BLGroupName;
            // ガイド名称
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GUIDENAME] = campaignMaster.GuideName;
            // 作成日
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CREATEDATETIME] = campaignMaster.CreateDateTime.ToShortDateString();
            // 更新日
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][UPDATEDATETIME] = campaignMaster.UpdateDateTime.ToShortDateString();
        }
       
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(CAMPAIGNCODE, typeof(string));		    // ｺｰﾄ
            PrintSetTable.Columns.Add(CAMPAIGNNAME, typeof(string));		    // 名称
            PrintSetTable.Columns.Add(SECTIONCODE, typeof(string));		        // 拠点
            PrintSetTable.Columns.Add(SECTIONGUIDESNM, typeof(string));		    // 拠点名
            PrintSetTable.Columns.Add(CAMPAIGNOBJDIV, typeof(string));		    // 対象得意先区分
            PrintSetTable.Columns.Add(APPLYSTADATE, typeof(string));		    // 適用開始日
            PrintSetTable.Columns.Add(APPLYENDDATE, typeof(string));		    // 適用終了日
            PrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		    // 得意先
            PrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));		        // 得意先名
            PrintSetTable.Columns.Add(GOODSNO, typeof(string));		            // 品番
            PrintSetTable.Columns.Add(GOODSNAME, typeof(string));		        // 品名
            PrintSetTable.Columns.Add(GOODSMAKERCD, typeof(string));		    // ﾒｰｶｰ
            PrintSetTable.Columns.Add(MAKERNAME, typeof(string));		        // ﾒｰｶｰ名
            PrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));	            // BLｺｰﾄﾞ
            PrintSetTable.Columns.Add(BLGOODSHALFNAME, typeof(string));		    // BLｺｰﾄﾞ名
            PrintSetTable.Columns.Add(BLGROUPCODE, typeof(string));		        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            PrintSetTable.Columns.Add(BLGROUPNAME, typeof(string));		        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ名
            PrintSetTable.Columns.Add(SALESCODE, typeof(string));		        // 販売区分
            PrintSetTable.Columns.Add(GUIDENAME, typeof(string));		        // 販売区分名
            PrintSetTable.Columns.Add(DISCOUNTRATE, typeof(string));		    // 売価率
            PrintSetTable.Columns.Add(RATEVAL, typeof(string));		            // 売価率
            PrintSetTable.Columns.Add(PRICEFL, typeof(string));		            // 売価額
            PrintSetTable.Columns.Add(PRICESTARTDATE, typeof(string));	        // 価格開始日
            PrintSetTable.Columns.Add(PRICEENDDATE, typeof(string));		    // 価格終了日
            PrintSetTable.Columns.Add(APPLYDATE, typeof(string));	            // 適用期間
            PrintSetTable.Columns.Add(PRICEDATE, typeof(string));		        // 価格日
            PrintSetTable.Columns.Add(SALESPRICESETDIV, typeof(Int32));		    // 売価設定区分
            PrintSetTable.Columns.Add(CREATEDATETIME, typeof(string));	        // 作成日
            PrintSetTable.Columns.Add(UPDATEDATETIME, typeof(string));		    // 更新日
            
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        
        #region ◎ PMKHN08700UA_Load Event
        /// <summary>
        /// PMKHN08700UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void PMKHN08700UA_Load(object sender, EventArgs e)
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
        #endregion // ◎ PMKHN08700UA_Load Event

        #region [グループ圧縮・展開]
        /// <summary>
        /// グループ圧縮イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グループ圧縮イベント</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
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
        /// <remarks>
        /// <br>Note       : グループ展開イベント</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        #endregion // グループ圧縮・展開

        #region [ガイドのクリック]

        /// <summary>
        /// キャンペーンガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ャンペーンガイドをクリックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_CampaignCodeGuide_Click(object sender, EventArgs e)
        {
            CampaignSt campaignSt;
            TEdit targetControl = null;
            Control nextControl = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ガイド起動
                int status = _campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    string tag = (string)((UltraButton)sender).Tag;

                    if (tag.ToString().CompareTo("1") == 0)
                    {
                        targetControl = this.tNedit_CampaignCode_St;
                        nextControl = this.tNedit_CampaignCode_Ed;
                    }
                    else if (tag.ToString().CompareTo("2") == 0)
                    {
                        targetControl = this.tNedit_CampaignCode_Ed;
                        nextControl = this.tEdit_SectionCode_St;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                // コード展開
                targetControl.DataText = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                // フォーカス
                nextControl.Focus();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 拠点ガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドをクリックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_SectionCodeGuide_Click(object sender, EventArgs e)
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
                    case 1: //メーカー＋品番
                    case 2: //メーカー＋ＢＬコード
                    case 3: //メーカー＋グループコード
                    case 4: //メーカー
                        nextControl = this.tNedit_GoodsMakerCd_St;
                        break;
                    case 5: //ＢＬコード
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                    case 6: //販売区分
                        nextControl = this.tNedit_SalesCode_St;
                        break;
                    case 7: //マスタリスト 
                        nextControl = this.ChangePage_ultraOptionSet;
                        break;
                }

            }
            else
            {
                return;
            }

            if (status != 0)
            {
                return;
            }

            // コード展開
            targetControl.DataText = secInfoSet.SectionCode.Trim();
            // フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : メーカーガイドをクリックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

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
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 1: //メーカー＋品番
                        nextControl = this.tEdit_GoodsNo_St;
                        break;
                    case 2: //メーカー＋ＢＬコード
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                    case 3: //メーカー＋グループコード
                        nextControl = this.tNedit_BLGroupCode_St;
                        break;
                    case 4: //メーカー
                        nextControl = this.tNedit_RateVal;
                        break;
                }

            }
            else
            {
                return;
            }
            targetControl.DataText = makerUMnt.GoodsMakerCd.ToString().TrimEnd();

            // 次フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// BLコードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BLコードガイドをクリックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            BLGoodsCdUMnt bLGoodsCdUmnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUmnt);
            if (status != 0) return;

            TNedit targetControl= null;
            Control nextControl= null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 2: //メーカー＋ＢＬコード
                    case 5: //ＢＬコード
                        nextControl = this.tNedit_RateVal;
                        break;
                }
            }
            else
            {
                return;
            }

            targetControl.SetInt(bLGoodsCdUmnt.BLGoodsCode);
            nextControl.Focus();
        }

        /// <summary>
        /// BLグループガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BLグループガイドをクリックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_BLGroupCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // ガイドデータサーチモード(1:リモート)
            if (status != 0) return;

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGroupCode_St;
                nextControl = this.tNedit_BLGroupCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGroupCode_Ed;
                nextControl = this.tNedit_RateVal;
            }
            else
            {
                return;
            }
            targetControl.DataText = bLGroupU.BLGroupCode.ToString().PadLeft(5, '0');
            nextControl.Focus();
        }

        /// <summary>
        /// 販売区分ガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 販売区分ガイドをクリックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_SalesCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 0; // 
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 6: //販売区分 
                    GuideNo = 71;
                    break;
            }

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SalesCode_St;
                nextControl = this.tNedit_SalesCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SalesCode_Ed;
                nextControl = this.tNedit_RateVal;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // フォーカス移動
            nextControl.Focus();
        }

        #endregion // ガイドのクリック

        #region [発行タイプ変更]
        /// <summary>
        /// 発行タイプ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 発行タイプ変更。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //メーカー＋品番 
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_GoodsNo.Visible = true;
                    this.pn_GoodsNo2.Visible = true;                           
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_BLCode.Location;
                    this.pn_PriceFl.Visible = true;
                    this.pn_PriceFl.Location = this.pn_BLGroupCode.Location;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_SalesCode.Location;
                    this.pn_BLCode.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;

                    break;
                case 2: //メーカー＋ＢＬコード
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_BLCode.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo2.Location;
                    this.pn_BLCode.Visible = true;
                    this.pn_BLCode.Location = this.pn_GoodsNo.Location;
                                        
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 3: //メーカー＋グループコード
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_BLGroupCode.Visible = true;
                    this.pn_BLGroupCode.Location = this.pn_GoodsNo.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo2.Location;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_BLCode.Location;
                    
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 4: //メーカー 
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_changePage.Visible = true;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo.Location;
                    this.pn_changePage.Location = this.pn_GoodsNo2.Location;

                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 5: //ＢＬコード 
                    initializeLayout();
                    this.pn_BLCode.Visible = true;
                    this.pn_BLCode.Location = this.pn_Maker.Location;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_GoodsNo2.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo.Location;

                    this.pn_Maker.Visible = false;
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 6: //販売区分
                    initializeLayout();
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_GoodsNo2.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo.Location;
                    this.pn_SalesCode.Visible = true;
                    this.pn_SalesCode.Location = this.pn_Maker.Location;
                                        
                    this.pn_Maker.Visible = false;
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 7: //マスタリスト
                    initializeLayout();
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_Maker.Location;

                    this.pn_SalesCode.Visible = false;
                    this.pn_Maker.Visible = false;
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_PriceFl.Visible = false;
                    this.pn_RateVal.Visible = false;
                    break;

            }

            this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
            this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
            this.tNedit_BLGroupCode_St.DataText = string.Empty;
            this.tNedit_BLGroupCode_Ed.DataText = string.Empty;
            this.tNedit_BLGoodsCode_St.DataText = string.Empty;
            this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
            this.tNedit_SalesCode_St.DataText = string.Empty;
            this.tNedit_SalesCode_Ed.DataText = string.Empty;
            this.tEdit_GoodsNo_St.DataText = string.Empty;
            this.tEdit_GoodsNo_Ed.DataText = string.Empty;
            this.tNedit_PriceFl.DataText = string.Empty;
            this.tComboEditor_PriceFlDiv.Value = 0;
            this.tNedit_DiscountRate.DataText = string.Empty;
            this.tCmb_DiscountRate.Value = 0;
            this.tNedit_RateVal.DataText = string.Empty;
            this.tComboEditor_RateValDiv.Value = 0;
        }
        #endregion // 発行タイプ変更

        #region[画面項目位置の初期化処理]
        /// <summary>
        /// 画面項目位置の初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面項目位置の初期化処理。</br>
        /// <br>Programmer : 李永平</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void initializeLayout()
        {
            this.pn_Maker.Location = new System.Drawing.Point(3, 91);
            this.pn_GoodsNo.Location = new System.Drawing.Point(3, 117);
            this.pn_GoodsNo2.Location = new System.Drawing.Point(3, 142);
            this.pn_BLCode.Location = new System.Drawing.Point(3, 169);
            this.pn_BLGroupCode.Location = new System.Drawing.Point(3, 195);
            this.pn_SalesCode.Location = new System.Drawing.Point(3, 221);
            this.pn_RateVal.Location = new System.Drawing.Point(3, 247);
            this.pn_PriceFl.Location = new System.Drawing.Point(3, 273);
            this.pn_changePage.Location = new System.Drawing.Point(3, 299);
        }
        #endregion

        #region [削除指定変更]
        /// <summary>
        /// 削除指定設定時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 発行タイプ変更。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
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
        #endregion // 削除指定変更

        #endregion ■ Control Event

    }
}
