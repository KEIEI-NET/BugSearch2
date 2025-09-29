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
    /// 商品マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public partial class PMKHN08610UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 商品マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08610UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._goodsSetAcs = new GoodsSetAcs();


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
        private GoodsPrintWork _goodsPrintWork;

        // データアクセス
        private GoodsSetAcs _goodsSetAcs;

        private GoodsAcs _goodsAcs;
        private static SupplierAcs _supplierAcs;

        private Hashtable secInfoSetTable;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN08610UA";
        // プログラムID
        private const string ct_PGID = "PMKHN08610U";
        //// 帳票名称
        private string _printName = "商品マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件


        private const string PRINTSET_TABLE = "GOODSSET";

        // dataview名称用
        private const string UPDATEDATETIME = "updatedatetime";
        private const string GOODSMAKERCD = "goodsmakercd";
        private const string MAKERSHORTNAME = "makershortname";
        private const string GOODSNO = "goodsno";
        private const string BLGOODSCODE = "blgoodscode";
        private const string GOODSNAME = "goodsname";
        private const string SUPPLIERCD = "suppliercd";
        private const string SUPPLIERSNM = "suppliersnm";
        private const string LISTPRICE = "listprice";
        private const string STOCKRATE = "stockrate";
        private const string SALESUNITCOST = "salesunitcost";
        private const string GOODSRATERANK = "goodsraterank";
        private const string SUPPLIERLOT = "supplierlot";
        private const string GOODSSPECIALNOTE = "goodsspecialnote";
        private const string GOODSNOTE1 = "goodsnote1";
        private const string GOODSNOTE2 = "goodsnote2";
        private const string PRICESTARTDATE = "pricestartdate";
        private const string NEWLISTPRICE = "newlistprice";
        private const string GOODSKINDCODE = "goodskindcode";
        private const string TAXATIONDIVCD = "taxationdivcd";
        private const string ENTERPRISEGANRECODE = "enterpriseganrecode";
        private const string ENTERPRISEGANRECODENAME = "enterpriseganrecodename";
        private const string OFFERDATADIV = "offerdatadiv";

        private const string UPDATEDATETIME_TITLE = "登録日";
        private const string GOODSMAKERCD_TITLE = "メーカー";
        private const string MAKERSHORTNAME_TITLE = "メーカー名";
        private const string GOODSNO_TITLE = "品番";
        private const string BLGOODSCODE_TITLE = "BLｺｰﾄﾞ";
        private const string GOODSNAME_TITLE = "品名";
        private const string SUPPLIERCD_TITLE = "仕入先";
        private const string SUPPLIERSNM_TITLE = "仕入先名";
        private const string LISTPRICE_TITLE = "標準価格";
        private const string STOCKRATE_TITLE = "仕入率";
        private const string SALESUNITCOST_TITLE = "原単価";
        private const string GOODSRATERANK_TITLE = "層別";
        private const string SUPPLIERLOT_TITLE = "ロット";
        private const string GOODSSPECIALNOTE_TITLE = "規格・特記事項";
        private const string GOODSNOTE1_TITLE = "備考１";
        private const string GOODSNOTE2_TITLE = "備考２";
        private const string PRICESTARTDATE_TITLE = "適用日";
        private const string NEWLISTPRICE_TITLE = "新標準価格";
        private const string GOODSKINDCODE_TITLE = "純優";
        private const string TAXATIONDIVCD_TITLE = "税区分";
        private const string ENTERPRISEGANRECODE_TITLE = "商品区分";
        private const string ENTERPRISEGANRECODENAME_TITLE = "商品区分名";
        private const string OFFERDATADIV_TITLE = "提供区分";


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
                status = this._goodsSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._goodsPrintWork);
            }
            else
            {
                status = this._goodsSetAcs.SearchDelete(
                    out PrintSets,
                    this._enterpriseCode,
                    this._goodsPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {

                        // 商品クラスをデータセットへ展開する
                        int index = 0;
                        foreach (GoodsSet goodsSet in PrintSets)
                        {

                            SecPrintSetToDataSet(goodsSet.Clone(), index);
                            ++index;
                        }

                        GetDataCheck();
                        switch (this._goodsPrintWork.PrintOdr)
                        {
                            case 0: // メーカー順 
                                this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = GOODSMAKERCD;
                                break;
                            case 1: // BLコード順 
                                this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = BLGOODSCODE;
                                break;
                            case 2: // 仕入先順 
                                this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = SUPPLIERCD;
                                break;
                            case 3: // 品番順
                                this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = GOODSNO;
                                break;
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
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN08610U", 						// アセンブリＩＤまたはクラスＩＤ
                            "商品マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsSetAcs, 				// エラーが発生したオブジェクト
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
            printInfo.jyoken = this._goodsPrintWork;
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
            this._goodsPrintWork = new GoodsPrintWork();

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
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 項目
            sizeCell.Width = 180;
            sizeHeader.Width = 180;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 470;
            sizeHeader.Width = 470;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 180;
            sizeHeader.Width = 180;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            #region ヘッダ名称
            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].Header.Caption = UPDATEDATETIME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Header.Caption = GOODSMAKERCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].Header.Caption = MAKERSHORTNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Header.Caption = GOODSNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Header.Caption = GOODSNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].Header.Caption = SUPPLIERCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].Header.Caption = SUPPLIERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].Header.Caption = LISTPRICE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].Header.Caption = STOCKRATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].Header.Caption = SALESUNITCOST_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].Header.Caption = GOODSRATERANK_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].Header.Caption = SUPPLIERLOT_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].Header.Caption = GOODSSPECIALNOTE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].Header.Caption = GOODSNOTE1_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].Header.Caption = GOODSNOTE2_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Header.Caption = PRICESTARTDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].Header.Caption = NEWLISTPRICE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].Header.Caption = GOODSKINDCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].Header.Caption = TAXATIONDIVCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Header.Caption = ENTERPRISEGANRECODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Header.Caption = ENTERPRISEGANRECODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].Header.Caption = OFFERDATADIV_TITLE;
            #endregion

            #region 非表示処理
            //非表示処理
            if ((int)this.tComboEditor_printType.Value == 0)
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].Hidden = true;

            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].Hidden = false;
            }
            #endregion

            // 文字表示位置の設定
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 表示フォーマットの設定
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].Format = "#,##0.00";
            UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].Format = "0.00";
            UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].Format = "#,##0.00";
            //UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].Format = "#,##0.00";      // DEL 2008/11/27 不具合対応[8327]
            UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].Format = "#,##0.00";
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].Format = "yyyy/MM/dd";

            #region 列配置


            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
            if ((int)this.tComboEditor_printType.Value == 0)
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;
            }
            else
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 4;
            }            

            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERSHORTNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERCD].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERSNM].RowLayoutColumnInfo.SpanY = 2;

            if ((int)this.tComboEditor_printType.Value == 1)
            {
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 4;
            }

            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].RowLayoutColumnInfo.OriginX = 16;
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[LISTPRICE].RowLayoutColumnInfo.SpanY = 2;

            if ((int)this.tComboEditor_printType.Value == 0)
            {
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            if ((int)this.tComboEditor_printType.Value == 1)
            {
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.SpanX = 4;
                UGrid.DisplayLayout.Bands[0].Columns[STOCKRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SALESUNITCOST].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSRATERANK].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SUPPLIERLOT].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                // ２列目
                UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].RowLayoutColumnInfo.OriginX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].RowLayoutColumnInfo.SpanX = 4;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSSPECIALNOTE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].RowLayoutColumnInfo.OriginX = 6;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].RowLayoutColumnInfo.SpanX = 4;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE1].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].RowLayoutColumnInfo.SpanX = 4;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNOTE2].RowLayoutColumnInfo.SpanY = 2;


                UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[NEWLISTPRICE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSKINDCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[TAXATIONDIVCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[OFFERDATADIV].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.OriginY = 2;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.SpanX = 4;
                UGrid.DisplayLayout.Bands[0].Columns[ENTERPRISEGANRECODENAME].RowLayoutColumnInfo.SpanY = 2;
            }
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
            if (this._goodsPrintWork.SupplierCdSt != this.tNedit_SupplierCd_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了仕入先
            if (this._goodsPrintWork.SupplierCdEd != this.tNedit_SupplierCd_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始メーカー
            if (this._goodsPrintWork.GoodsMakerCdSt != this.tNedit_GoodsMakerCd_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了メーカー
            if (this._goodsPrintWork.GoodsMakerCdEd != this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始ＢＬコード
            if (this._goodsPrintWork.BLGoodsCodeSt != this.tNedit_BLGoodsCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了ＢＬコード
            if (this._goodsPrintWork.BLGoodsCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 開始品番
            if (this._goodsPrintWork.GoodsNoSt != this.tEdit_GoodsNo_St.DataText)
            {
                status = false;
                return status;
            }
            // 終了品番
            if (this._goodsPrintWork.GoodsNoEd != this.tEdit_GoodsNo_Ed.DataText)
            {
                status = false;
                return status;
            }
            // 条件指定
            if (this._goodsPrintWork.WhereType != (int)this.tComboEditor_printType.Value)
            {
                status = false;
                return status;
            }
            if (this._goodsPrintWork.WhereType == 1)
            {
                // 定価指定
                if (this._goodsPrintWork.ListPrice != this.tNedit_ListPrice.GetInt())
                {
                    status = false;
                    return status;
                }
                // 定価指定区分
                if (this._goodsPrintWork.ListPriceDiv != (int)this.tComboEditor_ListPriceDiv.Value)
                {
                    status = false;
                    return status;
                }
                // 原価指定
                if (this._goodsPrintWork.SalesUnitCost != this.tNedit_SalesUnitCost.GetInt())
                {
                    status = false;
                    return status;
                }
                // 原価指定区分
                if (this._goodsPrintWork.SalesUnitCostDiv != (int)this.tComboEditor_SalesUnitCostDiv.Value)
                {
                    status = false;
                    return status;
                }
            }


            // 削除指定
            if (this._goodsPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._goodsPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._goodsPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.tNedit_ListPrice.DataText = string.Empty;
                this.tNedit_SalesUnitCost.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.CustomerCdSt_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.CustomerCdEd_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                // コンボの初期化
                this.tComboEditor_printType.Value = 0;
                this.tComboEditor_sort.Value = 0;
                this.tComboEditor_WhereType.Value = 0;
                this.tComboEditor_ListPriceDiv.Value = 0;
                this.tComboEditor_SalesUnitCostDiv.Value = 0;

                // 条件指定の使用不可
                this.tNedit_ListPrice.Enabled = false;
                this.tComboEditor_ListPriceDiv.Enabled = false;
                this.tNedit_SalesUnitCost.Enabled = false;
                this.tComboEditor_SalesUnitCostDiv.Enabled = false;

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

            // メーカー
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;  // ADD 2008/11/27 不具合対応[8320]
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
                return status;  // ADD 2008/11/27 不具合対応[8320]
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
                //開始仕入先コード
                this._goodsPrintWork.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();

                //終了仕入先コード
                this._goodsPrintWork.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();

                //開始商品メーカーコード
                this._goodsPrintWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();

                //終了商品メーカーコード
                this._goodsPrintWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

                //開始BL商品コード
                this._goodsPrintWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();

                //終了BL商品コード
                this._goodsPrintWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();

                //開始商品番号
                this._goodsPrintWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;

                //終了商品番号
                this._goodsPrintWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;

                //発行タイプ
                this._goodsPrintWork.PrintType = (int)this.tComboEditor_printType.Value;

                //印刷順
                this._goodsPrintWork.PrintOdr = (int)this.tComboEditor_sort.Value;

                //条件指定
                this._goodsPrintWork.WhereType = (int)this.tComboEditor_WhereType.Value;
                if ((int)this.tComboEditor_WhereType.Value == 0)
                {
                    //定価指定
                    this._goodsPrintWork.ListPrice = 0;

                    //定価指定区分
                    this._goodsPrintWork.ListPriceDiv = 1;

                    //原価指定
                    this._goodsPrintWork.SalesUnitCost = 0;

                    //原価指定区分
                    this._goodsPrintWork.SalesUnitCostDiv = 1;
                }
                else
                {
                    //定価指定
                    this._goodsPrintWork.ListPrice = this.tNedit_ListPrice.GetInt();

                    //定価指定区分
                    this._goodsPrintWork.ListPriceDiv = (int)this.tComboEditor_ListPriceDiv.Value;

                    //原価指定
                    this._goodsPrintWork.SalesUnitCost = this.tNedit_SalesUnitCost.GetInt();

                    //原価指定区分
                    this._goodsPrintWork.SalesUnitCostDiv = (int)this.tComboEditor_SalesUnitCostDiv.Value;
                }
                // 削除指定区分
                this._goodsPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._goodsPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._goodsPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
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
        /// 商品クラスデータセット展開処理
        /// </summary>
        /// <param name="goodsSet">商品クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 商品クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(GoodsSet goodsSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][UPDATEDATETIME] = goodsSet.UpdateDateTime;
            if (goodsSet.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = goodsSet.GoodsMakerCd.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERSHORTNAME] = goodsSet.MakerShortName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNO] = goodsSet.GoodsNo;
            if (goodsSet.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = goodsSet.BLGoodsCode.ToString("00000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNAME] = goodsSet.GoodsName;
            if (goodsSet.SupplierCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERCD] = goodsSet.SupplierCd.ToString("000000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERSNM] = goodsSet.SupplierSnm;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][LISTPRICE] = goodsSet.ListPrice;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKRATE] = goodsSet.StockRate;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESUNITCOST] = goodsSet.SalesUnitCost;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSRATERANK] = goodsSet.GoodsRateRank;
            // ADD 2008/11/27 不具合対応[8327] ---------->>>>>
            if (goodsSet.SupplierLot == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERLOT] = DBNull.Value;
            }
            else
            {
            // ADD 2008/11/27 不具合対応[8327] ----------<<<<<
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERLOT] = goodsSet.SupplierLot;
            // ADD 2008/11/27 不具合対応[8327] ---------->>>>>
            }
            // ADD 2008/11/27 不具合対応[8327] ----------<<<<<
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSSPECIALNOTE] = goodsSet.GoodsSpecialNote;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNOTE1] = goodsSet.GoodsNote1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNOTE2] = goodsSet.GoodsNote2;
            if (goodsSet.PriceStartDate == DateTime.MinValue)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESTARTDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESTARTDATE] = goodsSet.PriceStartDate;
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][NEWLISTPRICE] = goodsSet.NewListPrice;
            if (goodsSet.GoodsKindCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSKINDCODE] = "純正";
            }
            else if (goodsSet.GoodsKindCode == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSKINDCODE] = "その他";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSKINDCODE] = DBNull.Value;
            }
            if (goodsSet.TaxationDivCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TAXATIONDIVCD] = "課税";
            }
            else if (goodsSet.TaxationDivCd == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TAXATIONDIVCD] = "非課税";
            }
            else if (goodsSet.TaxationDivCd == 2)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TAXATIONDIVCD] = "課税（内税）";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TAXATIONDIVCD] = DBNull.Value;
            }
            if (goodsSet.EnterpriseGanreCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERPRISEGANRECODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERPRISEGANRECODE] = goodsSet.EnterpriseGanreCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENTERPRISEGANRECODENAME] = goodsSet.EnterpriseGanreCodeName;
            if (goodsSet.OfferDataDiv == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][OFFERDATADIV] = "ユーザー";
            }
            else if (goodsSet.OfferDataDiv == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][OFFERDATADIV] = "提供";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][OFFERDATADIV] = DBNull.Value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void GetDataCheck()
        {
            
            DataTable dt2 = this.Bind_DataSet.Tables[PRINTSET_TABLE].Clone();

            DataView dv = new DataView(this.Bind_DataSet.Tables[PRINTSET_TABLE]);
            dv.Sort = GOODSMAKERCD + " , " + GOODSNO + " , " + SUPPLIERCD + " , " + PRICESTARTDATE + " DESC";
            foreach (DataRowView drv in dv)
            {
                dt2.ImportRow(drv.Row);
            }

            // 重複データの削除
            string str_goodsmakercd = "";
            string str_goodsno = "";
            string str_suppliercd = "";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (str_goodsmakercd == dt2.Rows[i][GOODSMAKERCD].ToString() &&
                    str_goodsno == dt2.Rows[i][GOODSNO].ToString() &&
                    str_suppliercd == dt2.Rows[i][SUPPLIERCD].ToString())
                {
                    dt2.Rows[i].Delete();
                    i = i - 1;
                }
                else
                {
                    str_goodsmakercd = dt2.Rows[i][GOODSMAKERCD].ToString();
                    str_goodsno = dt2.Rows[i][GOODSNO].ToString();
                    str_suppliercd = dt2.Rows[i][SUPPLIERCD].ToString();
                }
            }

            // 整形したデータを保存
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();
            DataRow r = null;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                r = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                for (int n = 0; n < dt2.Rows[i].ItemArray.Length; n++)
                {
                    r[n] = dt2.Rows[i][n];
                }
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(r);
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
            PrintSetTable.Columns.Add(GOODSMAKERCD, typeof(string));		        // 	メーカー
            PrintSetTable.Columns.Add(MAKERSHORTNAME, typeof(string));		        // 	メーカー名
            PrintSetTable.Columns.Add(GOODSNO, typeof(string));		                // 	品番
            PrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));		            // 	BLｺｰﾄﾞ
            PrintSetTable.Columns.Add(GOODSNAME, typeof(string));		            // 	BLｺｰﾄﾞ名
            PrintSetTable.Columns.Add(SUPPLIERCD, typeof(string));		            // 	仕入先
            PrintSetTable.Columns.Add(SUPPLIERSNM, typeof(string));		            // 	仕入先名
            PrintSetTable.Columns.Add(LISTPRICE, typeof(Double));		            // 	標準価格
            PrintSetTable.Columns.Add(STOCKRATE, typeof(Double));		            // 	仕入率
            PrintSetTable.Columns.Add(SALESUNITCOST, typeof(Double));		        // 	原単価
            PrintSetTable.Columns.Add(GOODSRATERANK, typeof(string));		        // 	層別
            //PrintSetTable.Columns.Add(SUPPLIERLOT, typeof(Int32));		        // 	ロット  // DEL 2008/11/27 不具合対応[8327]
            PrintSetTable.Columns.Add(SUPPLIERLOT, typeof(string));		            // 	ロット  // ADD 2008/11/27 不具合対応[8327]
            PrintSetTable.Columns.Add(GOODSSPECIALNOTE, typeof(string));	        // 	規格・特記事項
            PrintSetTable.Columns.Add(GOODSNOTE1, typeof(string));		            // 	備考１
            PrintSetTable.Columns.Add(GOODSNOTE2, typeof(string));		            // 	備考２
            PrintSetTable.Columns.Add(PRICESTARTDATE, typeof(DateTime));		    // 	適用日
            PrintSetTable.Columns.Add(NEWLISTPRICE, typeof(Double));		        // 	新標準価格
            PrintSetTable.Columns.Add(GOODSKINDCODE, typeof(string));		        // 	純優
            PrintSetTable.Columns.Add(TAXATIONDIVCD, typeof(string));		        // 	税区分
            PrintSetTable.Columns.Add(ENTERPRISEGANRECODE, typeof(string));		    // 	商品区分
            PrintSetTable.Columns.Add(ENTERPRISEGANRECODENAME, typeof(string));	    // 	商品区分名
            PrintSetTable.Columns.Add(OFFERDATADIV, typeof(string));		        // 	提供区分
            PrintSetTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));		    // 	登録日

            
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08610UA
        #region ◎ PMKHN08610UA_Load Event
        /// <summary>
        /// PMKHN08610UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.24</br>
        /// </remarks>
        private void PMKHN08610UA_Load(object sender, EventArgs e)
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

        #endregion ◆ PMKHN08610UA


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
                nextControl = this.tNedit_BLGoodsCode_St;
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
        /// BLコードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._goodsAcs.ExecuteBLGoodsCd(out blGoodsCdUMnt);
            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt(blGoodsCdUMnt.BLGoodsCode);
            nextControl.Focus();
        }

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
                    nextControl = this.tNedit_GoodsMakerCd_St;
                }
                else
                {
                    return;
                }

                // ADD 2008/11/27 不具合対応[8319] ---------->>>>>
                if (status != 0)
                {
                    return;
                }
                // ADD 2008/11/27 不具合対応[8319] ----------<<<<<

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
        /// 条件指定設定時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_WhereType_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_WhereType.Value == 0)
            {
                this.tNedit_ListPrice.Enabled = false;
                this.tComboEditor_ListPriceDiv.Enabled = false;
                this.tNedit_SalesUnitCost.Enabled = false;
                this.tComboEditor_SalesUnitCostDiv.Enabled = false;
            }
            else
            {
                this.tNedit_ListPrice.Value = 0;
                this.tNedit_ListPrice.Enabled = true;
                this.tComboEditor_ListPriceDiv.Enabled = true;
                this.tNedit_SalesUnitCost.Enabled = true;
                this.tComboEditor_SalesUnitCostDiv.Enabled = true;
            }
        }
        #endregion ■ Control Event


    }
}