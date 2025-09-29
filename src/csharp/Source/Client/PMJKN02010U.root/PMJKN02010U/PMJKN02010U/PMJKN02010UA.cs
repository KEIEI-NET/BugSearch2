//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタ（印刷） 入力フォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
// 管理番号              作成担当 : gaoyh
// 作 成 日  2010/05/16  修正内容 : #7649 自由検索部品マスタ印刷の修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自由検索部品マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/27</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMJKN02010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 自由検索部品マスタ印刷UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタ印刷UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// <br></br>
        /// </remarks>
        public PMJKN02010UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._freeSearchPartsAcs = new FreeSearchPartsAcs();

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

        # endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";

        private string _loginSectionCode = "";

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private FreeSearchPartsPrint _freeSearchPartsPrint;

        // データアクセス
        private FreeSearchPartsAcs _freeSearchPartsAcs;

        # endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMJKN02010UA";
        // プログラムID
        private const string ct_PGID = "PMJKN02010U";
        // 帳票名称
        private string _printName = "自由検索部品マスタ";
        // 帳票キー	
        private string _printKey = "6b345896-fc12-4e99-9af3-55fcd2bd7078";   // 保留
        # endregion ◆ Interface member

        private const string PRINTSET_TABLE = "FREESEARCHMODEL";

        // dataview名称用
        private const string MODELCODE = "ModelCode";
        private const string MODELFULLNAME = "ModelFullName";
        private const string FULLMODEL = "FullModel";
        private const string BLANK1 = "Blank1";
        private const string GOODSNO = "GoodsNo";
        private const string MAKERCODE = "MakerCode";
        private const string TBSPARTSCODE = "TbsPartsCode";
        private const string BLGOODSHALFNAME = "BLGoodsHalfName";
        private const string PARTSQTY = "PartsQty";
        private const string LISTPRICE = "ListPrice";
        private const string BLANK2 = "Blank2";
        private const string PRODUCETYPEOFYEAR = "ProduceTypeOfYear";
        private const string FRAMENO = "FrameNo";
        private const string GRADENM = "GradeNm";
        private const string BODYNAME = "BodyName";
        private const string DOORCOUNT = "DoorCount";
        private const string ENGINEMODELNM = "EngineModelNm";
        private const string ENGINEDISPLACENM = "EngineDisplaceNm";
        private const string EDIVNM = "EDivNm";
        private const string TRANSMISSIONNM = "TransmissionNm";
        private const string WHEELDRIVEMETHODNM = "WheelDriveMethodNm";
        private const string SHIFTNM = "ShiftNm";
        private const string PARTSOPNM = "PartsOpNm";

        private const string MODELCODE_TITLE = "車種";
        private const string MODELFULLNAME_TITLE = "車種名";
        private const string FULLMODEL_TITLE = "型式";
        private const string BLANK1_TITLE = "";
        private const string GOODSNO_TITLE = "品番";
        private const string MAKERCODE_TITLE = "部品メーカー";
        private const string TBSPARTSCODE_TITLE = "BLｺｰﾄﾞ";
        private const string BLGOODSHALFNAME_TITLE = "品名";
        private const string PARTSQTY_TITLE = "QTY";
        private const string LISTPRICE_TITLE = "標準価格";
        private const string BLANK2_TITLE = "";
        private const string PRODUCETYPEOFYEAR_TITLE = "生産年式";
        private const string FRAMENO_TITLE = "車台番号";
        private const string GRADENM_TITLE = "グレード";
        private const string BODYNAME_TITLE = "ボディ";
        private const string DOORCOUNT_TITLE = "ドア";
        private const string ENGINEMODELNM_TITLE = "エンジン";
        private const string ENGINEDISPLACENM_TITLE = "排気量";
        private const string EDIVNM_TITLE = "Ｅ区分";
        private const string TRANSMISSIONNM_TITLE = "ミッション";
        private const string WHEELDRIVEMETHODNM_TITLE = "駆動方式";
        private const string SHIFTNM_TITLE = "シフト";
        private const string PARTSOPNM_TITLE = "摘要";

        # endregion ■ Private Const

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        # endregion ◆ Public Event

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

        # endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList PrintSets = null;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();

            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            this._freeSearchPartsPrint.EnterpriseCode = this._enterpriseCode;
            this._freeSearchPartsPrint.SectionCode = this._loginSectionCode;

            status = this._freeSearchPartsAcs.SearchAll(
                out PrintSets,
                this._freeSearchPartsPrint);    

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // BLコードクラスをデータセットへ展開する
                        int index = 0;
                        foreach (FreeSearchPartsSet freeSearchPartsSet in PrintSets)
                        {
                            SecPrintSetToDataSet(freeSearchPartsSet.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_ERROR:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMJKN02010U", 						// アセンブリＩＤまたはクラスＩＤ
                            "自由検索部品マスタ（印刷）", 	// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this, 				// TODO:エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }
        # endregion ◎ 抽出処理

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
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
            printInfo.jyoken = this._freeSearchPartsPrint;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        # endregion ◎ 印刷処理

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
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
        # endregion ◎ 印刷前確認処理

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._freeSearchPartsPrint = new FreeSearchPartsPrint();

            this.Show();
            return;
        }
        # endregion ◎ 画面表示処理

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note        : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
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

            editBand.UseRowLayout = true;
            
            // 列幅の自動調整方法
            UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            editBand.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            editBand.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            editBand.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            editBand.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

            #region 項目のサイズを設定
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            sizeCell.Height = 22;
            sizeCell.Width = 100;
            sizeHeader.Height = 20;
            sizeHeader.Width = 100;

            // 車種
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // １行目
            // 車種名
            sizeCell.Width = 285;
            sizeHeader.Width = 285;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 型式
            sizeCell.Width = 230;
            sizeHeader.Width = 230;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // ブランク1
            sizeCell.Width = 490;
            sizeHeader.Width = 490;
            editBand.Columns[BLANK1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[BLANK1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ２行目
            // 品番
            sizeCell.Width = 285;
            sizeHeader.Width = 285;
            editBand.Columns[GOODSNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[GOODSNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 部品メーカー
            sizeCell.Width = 230;
            sizeHeader.Width = 230;
            editBand.Columns[MAKERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[MAKERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // BLｺｰﾄﾞ
            sizeCell.Width = 60;
            sizeHeader.Width = 60;
            editBand.Columns[TBSPARTSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[TBSPARTSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 品名
            sizeCell.Width = 180;
            sizeHeader.Width = 180;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // QTY
            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            editBand.Columns[PARTSQTY].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[PARTSQTY].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 標準価格
            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            editBand.Columns[LISTPRICE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[LISTPRICE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // ブランク2
            sizeCell.Width = 205;
            sizeHeader.Width = 205;
            editBand.Columns[BLANK2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[BLANK2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ３行目
            // 生産年式
            sizeCell.Width = 135;
            sizeHeader.Width = 135;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 車台番号
            sizeCell.Width = 150;
            sizeHeader.Width = 150;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // グレード
            sizeCell.Width = 115;
            sizeHeader.Width = 115;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // ボディ
            sizeCell.Width = 115;
            sizeHeader.Width = 115;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // ドア
            sizeCell.Width = 60;
            sizeHeader.Width = 60;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // エンジン
            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 排気量
            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // Ｅ区分
            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // ミッション
            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 駆動方式
            sizeCell.Width = 115;
            sizeHeader.Width = 115;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // シフト
            sizeCell.Width = 90;
            sizeHeader.Width = 90;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ４行目
            // 摘要
            sizeCell.Width = 1140;
            sizeHeader.Width = 1140;
            editBand.Columns[PARTSOPNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[PARTSOPNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion 項目のサイズを設定

            #region LabelSpanの設定
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[BLANK1].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[GOODSNO].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[MAKERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[TBSPARTSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[PARTSQTY].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[LISTPRICE].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[BLANK2].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[PARTSOPNM].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            #region ヘッダ名称を設定
            // ヘッダ名称を設定
            editBand.Columns[MODELCODE].Header.Caption = MODELCODE_TITLE;
            editBand.Columns[MODELFULLNAME].Header.Caption = MODELFULLNAME_TITLE;
            editBand.Columns[FULLMODEL].Header.Caption = FULLMODEL_TITLE;
            editBand.Columns[BLANK1].Header.Caption = BLANK1_TITLE;
            editBand.Columns[GOODSNO].Header.Caption = GOODSNO_TITLE;
            editBand.Columns[MAKERCODE].Header.Caption = MAKERCODE_TITLE;
            editBand.Columns[TBSPARTSCODE].Header.Caption = TBSPARTSCODE_TITLE;
            editBand.Columns[BLGOODSHALFNAME].Header.Caption = BLGOODSHALFNAME_TITLE;
            editBand.Columns[PARTSQTY].Header.Caption = PARTSQTY_TITLE;
            editBand.Columns[LISTPRICE].Header.Caption = LISTPRICE_TITLE;
            editBand.Columns[BLANK2].Header.Caption = BLANK2_TITLE;
            editBand.Columns[PRODUCETYPEOFYEAR].Header.Caption = PRODUCETYPEOFYEAR_TITLE;
            editBand.Columns[FRAMENO].Header.Caption = FRAMENO_TITLE;
            editBand.Columns[GRADENM].Header.Caption = GRADENM_TITLE;
            editBand.Columns[BODYNAME].Header.Caption = BODYNAME_TITLE;
            editBand.Columns[DOORCOUNT].Header.Caption = DOORCOUNT_TITLE;
            editBand.Columns[ENGINEMODELNM].Header.Caption = ENGINEMODELNM_TITLE;
            editBand.Columns[ENGINEDISPLACENM].Header.Caption = ENGINEDISPLACENM_TITLE;
            editBand.Columns[EDIVNM].Header.Caption = EDIVNM_TITLE;
            editBand.Columns[TRANSMISSIONNM].Header.Caption = TRANSMISSIONNM_TITLE;
            editBand.Columns[WHEELDRIVEMETHODNM].Header.Caption = WHEELDRIVEMETHODNM_TITLE;
            editBand.Columns[SHIFTNM].Header.Caption = SHIFTNM_TITLE;
            editBand.Columns[PARTSOPNM].Header.Caption = PARTSOPNM_TITLE;
            # endregion ヘッダ名称を設定

            #region 列配置

            // 車種
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.OriginX = 0;
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.OriginY = 0;
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.SpanY = 8;
            // 1行目
            // 車種名
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.OriginX = 2;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.OriginY = 0;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.SpanX = 4;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.SpanY = 2;
            // 型式
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.OriginX = 6;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.OriginY = 0;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.SpanX = 4;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.SpanY = 2;
            // ブランク1
            editBand.Columns[BLANK1].RowLayoutColumnInfo.OriginX = 10;
            editBand.Columns[BLANK1].RowLayoutColumnInfo.OriginY = 0;
            editBand.Columns[BLANK1].RowLayoutColumnInfo.SpanX = 14;
            editBand.Columns[BLANK1].RowLayoutColumnInfo.SpanY = 2;
            // ２行目
            // 品番
            editBand.Columns[GOODSNO].RowLayoutColumnInfo.OriginX = 2;
            editBand.Columns[GOODSNO].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[GOODSNO].RowLayoutColumnInfo.SpanX = 4;
            editBand.Columns[GOODSNO].RowLayoutColumnInfo.SpanY = 2;
            // 部品メーカー
            editBand.Columns[MAKERCODE].RowLayoutColumnInfo.OriginX = 6;
            editBand.Columns[MAKERCODE].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[MAKERCODE].RowLayoutColumnInfo.SpanX = 4;
            editBand.Columns[MAKERCODE].RowLayoutColumnInfo.SpanY = 2;
            // BLｺｰﾄﾞ
            editBand.Columns[TBSPARTSCODE].RowLayoutColumnInfo.OriginX = 10;
            editBand.Columns[TBSPARTSCODE].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[TBSPARTSCODE].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[TBSPARTSCODE].RowLayoutColumnInfo.SpanY = 2;
            // 品名
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginX = 12;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanX = 4;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanY = 2;
            // QTY
            editBand.Columns[PARTSQTY].RowLayoutColumnInfo.OriginX = 16;
            editBand.Columns[PARTSQTY].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[PARTSQTY].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[PARTSQTY].RowLayoutColumnInfo.SpanY = 2;
            // 標準価格
            editBand.Columns[LISTPRICE].RowLayoutColumnInfo.OriginX = 18;
            editBand.Columns[LISTPRICE].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[LISTPRICE].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[LISTPRICE].RowLayoutColumnInfo.SpanY = 2;
            // ブランク2
            editBand.Columns[BLANK2].RowLayoutColumnInfo.OriginX = 20;
            editBand.Columns[BLANK2].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[BLANK2].RowLayoutColumnInfo.SpanX = 4;
            editBand.Columns[BLANK2].RowLayoutColumnInfo.SpanY = 2;
            // ３行目
            // 生産年式
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.OriginX = 2;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.SpanY = 2;
            // 車台番号
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.OriginX = 4;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.SpanY = 2;
            // グレード
            editBand.Columns[GRADENM].RowLayoutColumnInfo.OriginX = 6;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.SpanY = 2;
            // ボディ
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.OriginX = 8;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.SpanY = 2;
            // ドア
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.OriginX = 10;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.SpanY = 2;
            // エンジン
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.OriginX = 12;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.SpanY = 2;
            // 排気量
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.OriginX = 14;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.SpanY = 2;
            // Ｅ区分
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.OriginX = 16;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.SpanY = 2;
            // ミッション
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.OriginX = 18;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.SpanY = 2;
            // 駆動方式
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.OriginX = 20;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.SpanY = 2;
            // シフト
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.OriginX = 22;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.OriginY = 4;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.SpanY = 2;
            // ４行目
            // 摘要
            editBand.Columns[PARTSOPNM].RowLayoutColumnInfo.OriginX = 2;
            editBand.Columns[PARTSOPNM].RowLayoutColumnInfo.OriginY = 6;
            editBand.Columns[PARTSOPNM].RowLayoutColumnInfo.SpanX = 22;
            editBand.Columns[PARTSOPNM].RowLayoutColumnInfo.SpanY = 2;
            #endregion 列配置

            editBand.Columns[MODELCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[MODELCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            editBand.Columns[MODELFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[FULLMODEL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLANK1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[GOODSNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[MAKERCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[TBSPARTSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLGOODSHALFNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[PARTSQTY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[LISTPRICE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[BLANK2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[PRODUCETYPEOFYEAR].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[FRAMENO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[GRADENM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BODYNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[DOORCOUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[ENGINEMODELNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[ENGINEDISPLACENM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[EDIVNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[TRANSMISSIONNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[WHEELDRIVEMETHODNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[SHIFTNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[PARTSOPNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            //車種メーカーコード（開始）
            if (this._freeSearchPartsPrint.CarMakerCodeSt != this.tNedit_St_MakerCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種メーカーコード（終了）
            if (this._freeSearchPartsPrint.CarMakerCodeEd != this.tNedit_Ed_ModelCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種コード（開始）
            if (this._freeSearchPartsPrint.CarModelCodeSt != this.tNedit_St_ModelSubCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種コード（終了）
            if (this._freeSearchPartsPrint.CarModelCodeEd != this.tNedit_Ed_MakerCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種サブコード（開始）
            if (this._freeSearchPartsPrint.CarModelSubCodeSt != this.tNedit_Ed_ModelCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種サブコード（終了）
            if (this._freeSearchPartsPrint.CarModelSubCodeEd != this.tNedit_Ed_ModelSubCode.GetInt())
            {
                status = false;
                return status;
            }
            //型式
            if (this._freeSearchPartsPrint.ModelName != this.tEdit_CarMode.Text)
            {
                status = false;
                return status;
            }
            //メーカー（開始）
            if (this._freeSearchPartsPrint.MakerCodeSt != this.tNedit_St_GoodsMakerCd.GetInt())
            {
                status = false;
                return status;
            }
            //メーカー（終了）
            if (this._freeSearchPartsPrint.MakerCodeEd != this.tNedit_Ed_GoodsMakerCd.GetInt())
            {
                status = false;
                return status;
            }
            //BL商品コード（開始）
            if (this._freeSearchPartsPrint.BLGoodsCodeSt != this.tNedit_St_BLGoodsCode.GetInt())
            {
                status = false;
                return status;
            }
            //BL商品コード（終了）
            if (this._freeSearchPartsPrint.BLGoodsCodeEd != this.tNedit_Ed_BLGoodsCode.GetInt())
            {
                status = false;
                return status;
            }
            //登録日
            if (this._freeSearchPartsPrint.CreateDateTime != this.tDateEdit_RegDay.GetLongDate())
            {
                status = false;
                return status;
            }
            //登録日（条件）
            if (this._freeSearchPartsPrint.CreateDateTimeCode != (int)this.tComboEditor_RegDay.Value)
            {
                status = false;
                return status;
            }

            return status;
        }

        # endregion ◆ Public Method
        # endregion ■ IPrintConditionInpType メンバ

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

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tNedit_St_MakerCode.Text = string.Empty;
                this.tNedit_St_ModelCode.Text = string.Empty;
                this.tNedit_St_ModelSubCode.Text = string.Empty;
                this.tNedit_Ed_MakerCode.Text = string.Empty;
                this.tNedit_Ed_ModelCode.Text = string.Empty;
                this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                this.tEdit_CarMode.Text = string.Empty;
                this.tNedit_St_GoodsMakerCd.Text = string.Empty;
                this.tNedit_Ed_GoodsMakerCd.Text = string.Empty;
                this.tNedit_St_BLGoodsCode.Text = string.Empty;
                this.tNedit_Ed_BLGoodsCode.Text = string.Empty;
                this.tDateEdit_RegDay.SetDateTime(DateTime.Now);

                // 車種入力制御
                this.tNedit_St_MakerCode.Enabled = true;
                this.tNedit_St_ModelCode.Enabled = false;
                this.tNedit_St_ModelSubCode.Enabled = false;
                this.tNedit_Ed_MakerCode.Enabled = true;
                this.tNedit_Ed_ModelCode.Enabled = false;
                this.tNedit_Ed_ModelSubCode.Enabled = false;

                // 登録日（条件）「以前」
                this.tComboEditor_RegDay.Value = 0;

                // 改頁「しない」
                this.uos_NewPageDiv.Value = 0;

                // ボタン設定
                this.SetIconImage(this.ub_St_ModelFullGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_ModelFullGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_MakerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MakerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                // 初期フォーカスセット
                this.tNedit_St_MakerCode.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        # endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note       : ボタンアイコン設定処理</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        # endregion

        #region ◎ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // 車種（開始/終了)
            if (this.tNedit_St_MakerCode.GetInt() > GetEndCode(this.tNedit_Ed_MakerCode))
            {
                errMessage = "車種の範囲指定に誤りがあります。";
                errComponent = this.tNedit_Ed_MakerCode;
                status = false;
            }
            else if (this.tNedit_St_MakerCode.GetInt() == GetEndCode(this.tNedit_Ed_MakerCode) && this.tNedit_St_ModelCode.GetInt() > GetEndCode(this.tNedit_Ed_ModelCode))
            {
                errMessage = "車種の範囲指定に誤りがあります。";
                errComponent = this.tNedit_Ed_ModelCode;
                status = false;
            }
            else if (this.tNedit_St_MakerCode.GetInt() == GetEndCode(this.tNedit_Ed_MakerCode) && this.tNedit_St_ModelCode.GetInt() == GetEndCode(this.tNedit_Ed_ModelCode) && this.tNedit_St_ModelSubCode.GetInt() > GetEndCode(this.tNedit_Ed_ModelSubCode))
            {
                errMessage = "車種の範囲指定に誤りがあります。";
                errComponent = this.tNedit_Ed_ModelSubCode;
                status = false;
            }
            else
            // メーカー（開始/終了)
            if (this.tNedit_St_GoodsMakerCd.GetInt() > GetEndCode(this.tNedit_Ed_GoodsMakerCd))
            {
                errMessage = "部品メーカーの範囲指定に誤りがあります。";
                errComponent = this.tNedit_Ed_GoodsMakerCd;
                status = false;
            }
            else
            // BL商品コード（開始/終了)
            if (this.tNedit_St_BLGoodsCode.GetInt() > GetEndCode(this.tNedit_Ed_BLGoodsCode))
            {
                errMessage = "BLコードの範囲指定に誤りがあります。";
                errComponent = this.tNedit_Ed_BLGoodsCode;
                status = false;
            }
            else
            //登録日
            if (IsErrorTDateEdit(this.tDateEdit_RegDay, "登録日", out errMessage) == false)
            {
                errComponent = this.tDateEdit_RegDay;
                status = false;
                return status;
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="errItem">エラー項目</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note        : 日付の入力チェックを行います。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, string errItem, out string errMsg)
        {
            errMsg = errItem + "の入力が不正です。";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (year < 1900)
            {
                return (false);
            }

            if (month > 12)
            {
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                return (false);
            }

            return (true);
        }
        # endregion

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 車種メーカーコード（開始）
                this._freeSearchPartsPrint.CarMakerCodeSt = this.tNedit_St_MakerCode.GetInt();
                if (this.tNedit_St_MakerCode.GetInt() == 0)
                {
                    this.tNedit_St_MakerCode.Text = string.Empty;
                }
                // 車種メーカーコード（終了）
                this._freeSearchPartsPrint.CarMakerCodeEd = this.tNedit_Ed_MakerCode.GetInt();
                if (this.tNedit_Ed_MakerCode.GetInt() == 0)
                {
                    this.tNedit_Ed_MakerCode.Text = string.Empty;
                    this._freeSearchPartsPrint.CarMakerCodeEd = 999;
                }
                // 車種コード（開始）
                this._freeSearchPartsPrint.CarModelCodeSt = this.tNedit_St_ModelCode.GetInt();
                if (this.tNedit_St_ModelCode.GetInt() == 0)
                {
                    this.tNedit_St_ModelCode.Text = string.Empty;
                }
                // 車種コード（終了）
                this._freeSearchPartsPrint.CarModelCodeEd = this.tNedit_Ed_ModelCode.GetInt();
                if (this.tNedit_Ed_ModelCode.GetInt() == 0)
                {
                    this.tNedit_Ed_ModelCode.Text = string.Empty;
                    this._freeSearchPartsPrint.CarModelCodeEd = 999;
                }
                // 車種サブコード（開始）
                this._freeSearchPartsPrint.CarModelSubCodeSt = this.tNedit_St_ModelSubCode.GetInt();
                if (this.tNedit_St_ModelSubCode.GetInt() == 0)
                {
                    this.tNedit_St_ModelSubCode.Text = string.Empty;
                }
                // 車種サブコード（終了）
                this._freeSearchPartsPrint.CarModelSubCodeEd = this.tNedit_Ed_ModelSubCode.GetInt();
                if (this.tNedit_Ed_ModelSubCode.GetInt() == 0)
                {
                    this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                    this._freeSearchPartsPrint.CarModelSubCodeEd = 999;
                }

                // メーカーコード（開始）
                this._freeSearchPartsPrint.MakerCodeSt = this.tNedit_St_GoodsMakerCd.GetInt();
                if (this.tNedit_St_GoodsMakerCd.GetInt() == 0)
                {
                    this.tNedit_St_GoodsMakerCd.Text = string.Empty;
                }
                // メーカーコード（終了）
                this._freeSearchPartsPrint.MakerCodeEd = this.tNedit_Ed_GoodsMakerCd.GetInt();
                if (this.tNedit_Ed_GoodsMakerCd.GetInt() == 0)
                {
                    this.tNedit_Ed_GoodsMakerCd.Text = string.Empty;
                }

                // BL商品コード（開始）
                this._freeSearchPartsPrint.BLGoodsCodeSt = this.tNedit_St_BLGoodsCode.GetInt();
                if (this.tNedit_St_BLGoodsCode.GetInt() == 0)
                {
                    this.tNedit_St_BLGoodsCode.Text = string.Empty;
                }
                // BL商品コード（終了）
                this._freeSearchPartsPrint.BLGoodsCodeEd = this.tNedit_Ed_BLGoodsCode.GetInt();
                if (this.tNedit_Ed_BLGoodsCode.GetInt() == 0)
                {
                    this.tNedit_Ed_BLGoodsCode.Text = string.Empty;
                }

                // 型式
                this._freeSearchPartsPrint.ModelName = this.tEdit_CarMode.Text;

                // 登録日（条件）
                this._freeSearchPartsPrint.CreateDateTimeCode = (int)this.tComboEditor_RegDay.Value;
                // 登録日
                this._freeSearchPartsPrint.CreateDateTime = this.tDateEdit_RegDay.GetLongDate();

                // 改頁
                this._freeSearchPartsPrint.NewPageDiv = (int)this.uos_NewPageDiv.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// AB商品コードﾞクラスデータセット展開処理
        /// </summary>
        /// <param name="freeSearchPartsSet">AB商品コードﾞクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : AB商品コードﾞクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(FreeSearchPartsSet freeSearchPartsSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;
            }

            // 車種
            if (freeSearchPartsSet.MakerCode == 0 && freeSearchPartsSet.ModelCode == 0 && freeSearchPartsSet.ModelSubCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELCODE] = string.Empty;
            }
            else
            {
                string makerCode = freeSearchPartsSet.MakerCode.ToString("000");
                string modelCode = freeSearchPartsSet.ModelCode.ToString("000");
                string modelSubCode = freeSearchPartsSet.ModelSubCode.ToString("000");
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELCODE] = makerCode + "-" + modelCode + "-" + modelSubCode;
            }
            // 車種名
            if (string.IsNullOrEmpty(freeSearchPartsSet.ModelFullName))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELFULLNAME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELFULLNAME] = freeSearchPartsSet.ModelFullName;
            }
            // 型式
            if (string.IsNullOrEmpty(freeSearchPartsSet.FullModel))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FULLMODEL] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FULLMODEL] = freeSearchPartsSet.FullModel;
            }
            // ブランク1
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLANK1] = string.Empty;
            // 品番
            if (string.IsNullOrEmpty(freeSearchPartsSet.GoodsNo))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNO] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNO] = freeSearchPartsSet.GoodsNo;
            }
            // 部品メーカー
            if (freeSearchPartsSet.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERCODE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERCODE] = freeSearchPartsSet.GoodsMakerCd.ToString("0000") + " " + freeSearchPartsSet.MakerName;
            }
            // BLｺｰﾄﾞ
            if (freeSearchPartsSet.TbsPartsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TBSPARTSCODE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TBSPARTSCODE] = freeSearchPartsSet.TbsPartsCode.ToString("00000");
            }
            // 品名
            if (string.IsNullOrEmpty(freeSearchPartsSet.BLGoodsHalfName))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSHALFNAME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSHALFNAME] = freeSearchPartsSet.BLGoodsHalfName;
            }
            // QTY
            if (freeSearchPartsSet.PartsQty == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSQTY] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSQTY] = freeSearchPartsSet.PartsQty;
            }
            // 標準価格
            if (freeSearchPartsSet.ListPrice == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][LISTPRICE] = 0;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][LISTPRICE] = string.Format("{0:0,0}",freeSearchPartsSet.ListPrice);
            }
            // ブランク2
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLANK2] = string.Empty;
            // 生産年式
            if (freeSearchPartsSet.ModelPrtsAdptYm == 0 && freeSearchPartsSet.ModelPrtsAblsYm == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRODUCETYPEOFYEAR] = string.Empty;
            }
            else
            {

                string stProduceTypeOfYear = new DateTime(freeSearchPartsSet.ModelPrtsAdptYm / 100, freeSearchPartsSet.ModelPrtsAdptYm % 100, 1).ToString("yyyy/MM");
                string edProduceTypeOfYear = new DateTime(freeSearchPartsSet.ModelPrtsAblsYm / 100, freeSearchPartsSet.ModelPrtsAblsYm % 100, 1).ToString("yyyy/MM");
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRODUCETYPEOFYEAR] = stProduceTypeOfYear + "～" + edProduceTypeOfYear;
            }
            // 車台番号
            if (freeSearchPartsSet.ModelPrtsAdptFrameNo == 0 && freeSearchPartsSet.ModelPrtsAblsFrameNo == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRAMENO] = string.Empty;
            }
            else
            {
                string stProduceFrameNo = freeSearchPartsSet.ModelPrtsAdptFrameNo.ToString("00000000");
                string edProduceFrameNo = freeSearchPartsSet.ModelPrtsAblsFrameNo.ToString("00000000");
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRAMENO] = stProduceFrameNo + "～" + edProduceFrameNo;
            }
            // グレード
            if (string.IsNullOrEmpty(freeSearchPartsSet.ModelGradeNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GRADENM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GRADENM] = freeSearchPartsSet.ModelGradeNm;
            }
            // ボディ
            if (string.IsNullOrEmpty(freeSearchPartsSet.BodyName))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BODYNAME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BODYNAME] = freeSearchPartsSet.BodyName;
            }
            // ドア
            if (freeSearchPartsSet.DoorCount == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DOORCOUNT] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DOORCOUNT] = freeSearchPartsSet.DoorCount;
            }
            // エンジン
            if (string.IsNullOrEmpty(freeSearchPartsSet.EngineModelNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEMODELNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEMODELNM] = freeSearchPartsSet.EngineModelNm;
            }
            // 排気量
            if (string.IsNullOrEmpty(freeSearchPartsSet.EngineDisplaceNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEDISPLACENM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEDISPLACENM] = freeSearchPartsSet.EngineDisplaceNm;
            }
            // Ｅ区分
            if (string.IsNullOrEmpty(freeSearchPartsSet.EDivNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EDIVNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EDIVNM] = freeSearchPartsSet.EDivNm;
            }
            // ミッション
            if (string.IsNullOrEmpty(freeSearchPartsSet.TransmissionNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TRANSMISSIONNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TRANSMISSIONNM] = freeSearchPartsSet.TransmissionNm;
            }
            // 駆動方式
            if (string.IsNullOrEmpty(freeSearchPartsSet.WheelDriveMethodNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WHEELDRIVEMETHODNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WHEELDRIVEMETHODNM] = freeSearchPartsSet.WheelDriveMethodNm;
            }
            // シフト
            if (string.IsNullOrEmpty(freeSearchPartsSet.ShiftNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIFTNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIFTNM] = freeSearchPartsSet.ShiftNm;
            }
            //摘要
            if (string.IsNullOrEmpty(freeSearchPartsSet.PartsOpNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSOPNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSOPNM] = freeSearchPartsSet.PartsOpNm;
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(MODELCODE, typeof(string));		    // 車種;
            PrintSetTable.Columns.Add(MODELFULLNAME, typeof(string));		// 車種名;
            PrintSetTable.Columns.Add(FULLMODEL, typeof(string));		    // 型式;
            PrintSetTable.Columns.Add(BLANK1, typeof(string));		        // ブランク1;
            PrintSetTable.Columns.Add(GOODSNO, typeof(string));		        // 品番";
            PrintSetTable.Columns.Add(MAKERCODE, typeof(string));		    // 部品メーカー";
            PrintSetTable.Columns.Add(TBSPARTSCODE, typeof(string));		// BLｺｰﾄﾞ";
            PrintSetTable.Columns.Add(BLGOODSHALFNAME, typeof(string));		// 品名";
            PrintSetTable.Columns.Add(PARTSQTY, typeof(string));		    // QTY";
            PrintSetTable.Columns.Add(LISTPRICE, typeof(string));		    // 標準価格";
            PrintSetTable.Columns.Add(BLANK2, typeof(string));		        // ブランク2;
            PrintSetTable.Columns.Add(PRODUCETYPEOFYEAR, typeof(string));	// 生産年式;
            PrintSetTable.Columns.Add(FRAMENO, typeof(string));		        // 車台番号;
            PrintSetTable.Columns.Add(GRADENM, typeof(string));		        // グレード;
            PrintSetTable.Columns.Add(BODYNAME, typeof(string));		    // ボディ;
            PrintSetTable.Columns.Add(DOORCOUNT, typeof(string));		    // ドア;
            PrintSetTable.Columns.Add(ENGINEMODELNM, typeof(string));		// エンジン;
            PrintSetTable.Columns.Add(ENGINEDISPLACENM, typeof(string));	// 排気量;
            PrintSetTable.Columns.Add(EDIVNM, typeof(string));		        // Ｅ区分;
            PrintSetTable.Columns.Add(TRANSMISSIONNM, typeof(string));		// ミッション;
            PrintSetTable.Columns.Add(WHEELDRIVEMETHODNM, typeof(string));	// 駆動方式;
            PrintSetTable.Columns.Add(SHIFTNM, typeof(string));		        // シフト;
            PrintSetTable.Columns.Add(PARTSOPNM, typeof(string));		    // 摘要;

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
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
        # endregion ◎ エラーメッセージ表示処理

        # endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMJKN02010UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private void PMJKN02010UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動

            this._freeSearchPartsAcs.Owner = this;
        }

        /// <summary>
        /// 車種ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            ModelNameU modelNameU;
            int makerCode;
            int modelCode;
            int modelSubCode;
            if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_ModelFullGuide)
            {
                makerCode = this.tNedit_St_MakerCode.GetInt();
                modelCode = this.tNedit_St_ModelCode.GetInt();
                modelSubCode = this.tNedit_St_ModelSubCode.GetInt();
            }
            else
            {
                makerCode = this.tNedit_Ed_MakerCode.GetInt();
                modelCode = this.tNedit_Ed_ModelCode.GetInt();
                modelSubCode = this.tNedit_Ed_ModelSubCode.GetInt();
            }
            int status = modelNameUAcs.ExecuteGuid2(makerCode, modelCode, modelSubCode, this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //開始、終了どちらのボタンが押されたか？
                if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_ModelFullGuide)
                {
                    //開始
                    this.tNedit_St_MakerCode.SetInt(modelNameU.MakerCode);
                    this.tNedit_St_ModelCode.SetInt(modelNameU.ModelCode);
                    this.tNedit_St_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                }
                else
                {
                    //終了
                    this.tNedit_Ed_MakerCode.SetInt(modelNameU.MakerCode);
                    this.tNedit_Ed_ModelCode.SetInt(modelNameU.ModelCode);
                    this.tNedit_Ed_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                }
                // ----- ADD 2010/05/16 ------------------->>>>>
                if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_ModelFullGuide)
                {
                    //開始
                    this.tNedit_St_ModelCode.Enabled = false;
                    this.tNedit_St_ModelSubCode.Enabled = false;
                }
                else
                {
                    //終了
                    this.tNedit_Ed_ModelCode.Enabled = false;
                    this.tNedit_Ed_ModelSubCode.Enabled = false;
                }
                // ----- ADD 2010/05/16 -------------------<<<<<
                // 次の項目へフォーカス移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            MakerAcs _makerAcs = new MakerAcs();
            //メーカーガイド起動
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            switch (status)
            {
                //取得
                case 0:
                    {
                        if (makerUMnt != null)
                        {
                            //開始、終了どちらのボタンが押されたか？
                            if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_MakerGuide)
                            {
                                //開始
                                this.tNedit_St_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            }
                            else
                            {
                                //終了
                                this.tNedit_Ed_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            }

                            // 次のコントロールへフォーカスを移動
                            this.SelectNextControl((Control)sender, true, true, true, true);
                        }
                        break;
                    }
                //キャンセル
                case 1:
                    {

                        break;
                    }
            }
        }

        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ＢＬコードガイドボタンがクリック時に発生します。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private void BLGoodsCodeGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;
            BLGoodsCdAcs _blGoodsCdAcs = new BLGoodsCdAcs();
            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            //if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0) // DEL 2010/05/16
            if ((UltraButton)sender == this.ub_St_BLGoodsCodeGuide) // ADD 2010/05/16
            {
                this.tNedit_St_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
            }
            //else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0) // DEL 2010/05/16
            else if ((UltraButton)sender == this.ub_Ed_BLGoodsCodeGuide) // ADD 2010/05/16
            {
                this.tNedit_Ed_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
            }
            else
            {
                return;
            }

            // 次のコントロールへフォーカスを移動
            this.SelectNextControl((Control)sender, true, true, true, true);
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : ChangeFocus イベントを行う</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br> 
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 車種メーカーコード（開始）
                case "tNedit_St_MakerCode":
                    {
                        if (this.tNedit_St_MakerCode.GetInt() == 0)
                        {
                            this.tNedit_St_MakerCode.Text = string.Empty;
                            this.tNedit_St_ModelCode.Enabled = false;
                        }
                        break;
                    }
                // 車種メーカーコード（終了）
                case "tNedit_Ed_MakerCode":
                    {
                        if (this.tNedit_Ed_MakerCode.GetInt() == 0)
                        {
                            this.tNedit_Ed_MakerCode.Text = string.Empty;
                            this.tNedit_Ed_ModelCode.Enabled = false;
                        }
                        break;
                    }
                // 車種コード（開始）
                case "tNedit_St_ModelCode":
                    {
                        if (this.tNedit_St_ModelCode.GetInt() == 0)
                        {
                            this.tNedit_St_ModelCode.Text = string.Empty;
                            this.tNedit_St_ModelSubCode.Enabled = false;
                        }
                        break;
                    }
                // 車種コード（終了）
                case "tNedit_Ed_ModelCode":
                    {
                        if (this.tNedit_Ed_ModelCode.GetInt() == 0)
                        {
                            this.tNedit_Ed_ModelCode.Text = string.Empty;
                            this.tNedit_Ed_ModelSubCode.Enabled = false;
                        }
                        break;
                    }
                // 車種サブコード（開始）
                case "tNedit_St_ModelSubCode":
                    {
                        if (this.tNedit_St_ModelSubCode.GetInt() == 0)
                        {
                            this.tNedit_St_ModelSubCode.Text = string.Empty;
                        }
                        break;
                    }
                // 車種サブコード（終了）
                case "tNedit_Ed_ModelSubCode":
                    {
                        if (this.tNedit_Ed_ModelSubCode.GetInt() == 0)
                        {
                            this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyUp イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : KeyUp イベントを行う</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br> 
        /// </remarks>
        private void tNedit_St_MakerCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.tNedit_St_MakerCode.Text == string.Empty)
            {
                this.tNedit_St_ModelCode.Enabled = false;
                this.tNedit_St_ModelCode.Text = string.Empty;
                this.tNedit_St_ModelSubCode.Enabled = false;
                this.tNedit_St_ModelSubCode.Text = string.Empty;
            }
            else
            {
                this.tNedit_St_ModelCode.Enabled = true;
            }
        }

        /// <summary>
        /// KeyUp イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : KeyUp イベントを行う</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br> 
        /// </remarks>
        private void tNedit_St_ModelCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.tNedit_St_ModelCode.Text == string.Empty)
            {
                this.tNedit_St_ModelSubCode.Enabled = false;
                this.tNedit_St_ModelSubCode.Text = string.Empty;
            }
            else
            {
                this.tNedit_St_ModelSubCode.Enabled = true;
            }
        }

        /// <summary>
        /// KeyUp イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : KeyUp イベントを行う</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br> 
        /// </remarks>
        private void tNedit_Ed_MakerCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.tNedit_Ed_MakerCode.Text == string.Empty)
            {
                this.tNedit_Ed_ModelCode.Enabled = false;
                this.tNedit_Ed_ModelCode.Text = string.Empty;
                this.tNedit_Ed_ModelSubCode.Enabled = false;
                this.tNedit_Ed_ModelSubCode.Text = string.Empty;
            }
            else
            {
                this.tNedit_Ed_ModelCode.Enabled = true;
            }
        }

        /// <summary>
        /// KeyUp イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : KeyUp イベントを行う</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br> 
        /// </remarks>
        private void tNedit_Ed_ModelCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.tNedit_Ed_ModelCode.Text == string.Empty)
            {
                this.tNedit_Ed_ModelSubCode.Enabled = false;
                this.tNedit_Ed_ModelSubCode.Text = string.Empty;
            }
            else
            {
                this.tNedit_Ed_ModelSubCode.Enabled = true;
            }
        }

        # endregion ■ Control Event
    }
}