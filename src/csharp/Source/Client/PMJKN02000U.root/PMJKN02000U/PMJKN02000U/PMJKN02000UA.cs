//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ（印刷） 入力フォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/05/16  修正内容 : #7623 自由検索型式マスタ印刷の修正
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
    /// 自由検索型式マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索型式マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/27</br>
	/// <br>UpdateNote : 2010/05/16 姜凱 redmine#7623の対応</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMJKN02000UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 自由検索型式マスタ印刷UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタ印刷UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// <br></br>
        /// </remarks>
        public PMJKN02000UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._freeSearchModelAcs = new FreeSearchModelAcs();

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

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private FreeSearchModelPrint _freeSearchModelPrint;

        // データアクセス
        private FreeSearchModelAcs _freeSearchModelAcs;

        # endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMJKN02000UA";
        // プログラムID
        private const string ct_PGID = "PMJKN02000U";
        // 帳票名称
        private string _printName = "自由検索型式マスタ";
        // 帳票キー	
        private string _printKey = "6b345896-fc12-4e99-9af3-55fcd2bd7078";   // 保留
        # endregion ◆ Interface member

        private const string PRINTSET_TABLE = "FREESEARCHMODEL";

        // dataview名称用
        private const string MODELCODE = "ModelCode";
        private const string MODELFULLNAME = "ModelFullName";
        private const string FULLMODEL = "FullModel";
        private const string CATEGORYNO = "CategoryNo";
        private const string BLANK = "Blank";
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

        private const string MODELCODE_TITLE = "車種";
        private const string MODELFULLNAME_TITLE = "車種名";
        private const string FULLMODEL_TITLE = "型式";
        private const string CATEGORYNO_TITLE = "類別番号";
        private const string BLANK_TITLE = "";
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

            status = this._freeSearchModelAcs.SearchAll(
                out PrintSets,
                this._enterpriseCode,
                this._freeSearchModelPrint);    

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // BLコードクラスをデータセットへ展開する
                        int index = 0;
                        foreach (FreeSearchModelSet freeSearchModelSet in PrintSets)
                        {

                            SecPrintSetToDataSet(freeSearchModelSet.Clone(), index);
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
                            "PMJKN02000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "自由検索型式マスタ（印刷）", 	// プログラム名称
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
            printInfo.jyoken = this._freeSearchModelPrint;
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
            this._freeSearchModelPrint = new FreeSearchModelPrint();

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
            sizeCell.Width =285;
            sizeHeader.Width = 285;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 型式
            sizeCell.Width = 230;
            sizeHeader.Width = 230;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // 類別番号
            sizeCell.Width = 135;
            sizeHeader.Width = 135;
            editBand.Columns[CATEGORYNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[CATEGORYNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // ブランク
            sizeCell.Width = 475;
            sizeHeader.Width = 475;
            editBand.Columns[BLANK].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[BLANK].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ２行目
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
            sizeCell.Width = 45;
            sizeHeader.Width = 45;
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
            #endregion 項目のサイズを設定

            #region LabelSpanの設定
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[MODELFULLNAME].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[FULLMODEL].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[CATEGORYNO].RowLayoutColumnInfo.LabelSpan = 2;
            editBand.Columns[BLANK].RowLayoutColumnInfo.LabelSpan = 2;
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
            #endregion LabelSpanの設定

            #region ヘッダ名称を設定
            // ヘッダ名称を設定
            editBand.Columns[MODELCODE].Header.Caption = MODELCODE_TITLE;
            editBand.Columns[MODELFULLNAME].Header.Caption = MODELFULLNAME_TITLE;
            editBand.Columns[FULLMODEL].Header.Caption = FULLMODEL_TITLE;
            editBand.Columns[CATEGORYNO].Header.Caption = CATEGORYNO_TITLE;
            editBand.Columns[BLANK].Header.Caption = BLANK_TITLE;
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
            # endregion ヘッダ名称を設定

            #region 列配置

            // 車種
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.OriginX = 0;
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.OriginY = 0;
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[MODELCODE].RowLayoutColumnInfo.SpanY = 4;
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
            // 類別番号
            editBand.Columns[CATEGORYNO].RowLayoutColumnInfo.OriginX = 10;
            editBand.Columns[CATEGORYNO].RowLayoutColumnInfo.OriginY = 0;
            editBand.Columns[CATEGORYNO].RowLayoutColumnInfo.SpanX = 4;
            editBand.Columns[CATEGORYNO].RowLayoutColumnInfo.SpanY = 2;
            // ブランク
            editBand.Columns[BLANK].RowLayoutColumnInfo.OriginX = 14;
            editBand.Columns[BLANK].RowLayoutColumnInfo.OriginY = 0;
            editBand.Columns[BLANK].RowLayoutColumnInfo.SpanX = 10;
            editBand.Columns[BLANK].RowLayoutColumnInfo.SpanY = 2;
            // ２行目
            // 生産年式
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.OriginX = 2;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[PRODUCETYPEOFYEAR].RowLayoutColumnInfo.SpanY = 2;
            // 車台番号
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.OriginX = 4;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[FRAMENO].RowLayoutColumnInfo.SpanY = 2;
            // グレード
            editBand.Columns[GRADENM].RowLayoutColumnInfo.OriginX = 6;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[GRADENM].RowLayoutColumnInfo.SpanY = 2;
            // ボディ
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.OriginX = 8;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[BODYNAME].RowLayoutColumnInfo.SpanY = 2;
            // ドア
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.OriginX = 10;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[DOORCOUNT].RowLayoutColumnInfo.SpanY = 2;
            // エンジン
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.OriginX = 12;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[ENGINEMODELNM].RowLayoutColumnInfo.SpanY = 2;
            // 排気量
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.OriginX = 14;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[ENGINEDISPLACENM].RowLayoutColumnInfo.SpanY = 2;
            // Ｅ区分
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.OriginX = 16;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[EDIVNM].RowLayoutColumnInfo.SpanY = 2;
            // ミッション
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.OriginX = 18;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[TRANSMISSIONNM].RowLayoutColumnInfo.SpanY = 2;
            // 駆動方式
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.OriginX = 20;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[WHEELDRIVEMETHODNM].RowLayoutColumnInfo.SpanY = 2;
            // シフト
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.OriginX = 22;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.OriginY = 2;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.SpanX = 2;
            editBand.Columns[SHIFTNM].RowLayoutColumnInfo.SpanY = 2;
            #endregion 列配置

            editBand.Columns[MODELCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[MODELCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            editBand.Columns[MODELFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[FULLMODEL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[CATEGORYNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLANK].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
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
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            //車種メーカーコード（開始）
            if (this._freeSearchModelPrint.CarMakerCodeSt != this.tNedit_St_MakerCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種メーカーコード（終了）
            if (this._freeSearchModelPrint.CarMakerCodeEd != this.tNedit_St_ModelCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種コード（開始）
            if (this._freeSearchModelPrint.CarModelCodeSt != this.tNedit_St_ModelSubCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種コード（終了）
            if (this._freeSearchModelPrint.CarModelCodeEd != this.tNedit_Ed_MakerCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種サブコード（開始）
            if (this._freeSearchModelPrint.CarModelSubCodeSt != this.tNedit_Ed_ModelCode.GetInt())
            {
                status = false;
                return status;
            }
            //車種サブコード（終了）
            if (this._freeSearchModelPrint.CarModelSubCodeEd != this.tNedit_Ed_ModelSubCode.GetInt())
            {
                status = false;
                return status;
            }
            //型式
            if (this._freeSearchModelPrint.ModelName != this.tEdit_CarMode.Text)
            {
                status = false;
                return status;
            }
            //登録日
            if (this._freeSearchModelPrint.CreateDateTime != this.tDateEdit_RegDay.GetLongDate())
            {
                status = false;
                return status;
            }
            //登録日（条件）
            if (this._freeSearchModelPrint.CreateDateTimeCode != (int)this.tComboEditor_RegDay.Value)
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
                this._freeSearchModelPrint.CarMakerCodeSt = this.tNedit_St_MakerCode.GetInt();
                if (this.tNedit_St_MakerCode.GetInt() == 0)
                {
                    this.tNedit_St_MakerCode.Text = string.Empty;
                }
                // 車種メーカーコード（終了）
                this._freeSearchModelPrint.CarMakerCodeEd = this.tNedit_Ed_MakerCode.GetInt();
                if (this.tNedit_Ed_MakerCode.GetInt() == 0)
                {
                    this.tNedit_Ed_MakerCode.Text = string.Empty;
                    this._freeSearchModelPrint.CarMakerCodeEd = 999;
                }
                // 車種コード（開始）
                this._freeSearchModelPrint.CarModelCodeSt = this.tNedit_St_ModelCode.GetInt();
                if (this.tNedit_St_ModelCode.GetInt() == 0)
                {
                    this.tNedit_St_ModelCode.Text = string.Empty;
                }
                // 車種コード（終了）
                this._freeSearchModelPrint.CarModelCodeEd = this.tNedit_Ed_ModelCode.GetInt();
                if (this.tNedit_Ed_ModelCode.GetInt() == 0)
                {
                    this.tNedit_Ed_ModelCode.Text = string.Empty;
                    this._freeSearchModelPrint.CarModelCodeEd = 999;
                }
                // 車種サブコード（開始）
                this._freeSearchModelPrint.CarModelSubCodeSt = this.tNedit_St_ModelSubCode.GetInt();
                if (this.tNedit_St_ModelSubCode.GetInt() == 0)
                {
                    this.tNedit_St_ModelSubCode.Text = string.Empty;
                }
                // 車種サブコード（終了）
                this._freeSearchModelPrint.CarModelSubCodeEd = this.tNedit_Ed_ModelSubCode.GetInt();
                if (this.tNedit_Ed_ModelSubCode.GetInt() == 0)
                {
                    this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                    this._freeSearchModelPrint.CarModelSubCodeEd = 999;
                }

                // 型式
                this._freeSearchModelPrint.ModelName = this.tEdit_CarMode.Text;

                // 登録日（条件）
                this._freeSearchModelPrint.CreateDateTimeCode = (int)this.tComboEditor_RegDay.Value;
                // 登録日
                this._freeSearchModelPrint.CreateDateTime = this.tDateEdit_RegDay.GetLongDate();

                // 改頁
                this._freeSearchModelPrint.NewPageDiv = (int)this.uos_NewPageDiv.Value;
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
        /// <param name="freeSearchModelSet">AB商品コードﾞクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : AB商品コードﾞクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private void SecPrintSetToDataSet(FreeSearchModelSet freeSearchModelSet, int index)
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
            if (freeSearchModelSet.MakerCode == 0 && freeSearchModelSet.ModelCode == 0 && freeSearchModelSet.ModelSubCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELCODE] = string.Empty;
            }
            else
            {
                string makerCode = freeSearchModelSet.MakerCode.ToString("000");
                string modelCode = freeSearchModelSet.ModelCode.ToString("000");
                string modelSubCode = freeSearchModelSet.ModelSubCode.ToString("000");
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELCODE] = makerCode + "-" + modelCode + "-" + modelSubCode;
            }
            // 車種名
            if (string.IsNullOrEmpty(freeSearchModelSet.ModelFullName))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELFULLNAME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MODELFULLNAME] = freeSearchModelSet.ModelFullName;
            }
            // 型式
            if (string.IsNullOrEmpty(freeSearchModelSet.FullModel))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FULLMODEL] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FULLMODEL] = freeSearchModelSet.FullModel;
            }
            // 類別番号
            if (freeSearchModelSet.ModelDesignationNo == 0 && freeSearchModelSet.CategoryNo == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CATEGORYNO] = string.Empty;
            }
            else
            {
                string modelDesignationNo = freeSearchModelSet.ModelDesignationNo.ToString("00000");
                string categoryNo = freeSearchModelSet.CategoryNo.ToString("0000");
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CATEGORYNO] = modelDesignationNo + "-" + categoryNo;
            }
            // ブランク
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLANK] = string.Empty;
            // 生産年式
            if (freeSearchModelSet.StProduceTypeOfYear == 0 && freeSearchModelSet.EdProduceTypeOfYear == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRODUCETYPEOFYEAR] = string.Empty;
            }
            else
            {

                string stProduceTypeOfYear = new DateTime(freeSearchModelSet.StProduceTypeOfYear / 100, freeSearchModelSet.StProduceTypeOfYear % 100, 1).ToString("yyyy/MM");
                string edProduceTypeOfYear = new DateTime(freeSearchModelSet.EdProduceTypeOfYear / 100, freeSearchModelSet.EdProduceTypeOfYear % 100, 1).ToString("yyyy/MM");
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRODUCETYPEOFYEAR] = stProduceTypeOfYear + "～" + edProduceTypeOfYear;
            }
            // 車台番号
            if (freeSearchModelSet.StProduceFrameNo == 0 && freeSearchModelSet.EdProduceFrameNo == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRAMENO] = string.Empty;
            }
            else
            {
                string stProduceFrameNo = freeSearchModelSet.StProduceFrameNo.ToString("00000000");
                string edProduceFrameNo = freeSearchModelSet.EdProduceFrameNo.ToString("00000000");
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRAMENO] = stProduceFrameNo + "～" + edProduceFrameNo;
            }
            // グレード
            if (string.IsNullOrEmpty(freeSearchModelSet.ModelGradeNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GRADENM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GRADENM] = freeSearchModelSet.ModelGradeNm;
            }
            // ボディ
            if (string.IsNullOrEmpty(freeSearchModelSet.BodyName))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BODYNAME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BODYNAME] = freeSearchModelSet.BodyName;
            }
            // ドア
            if (freeSearchModelSet.DoorCount == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DOORCOUNT] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DOORCOUNT] = freeSearchModelSet.DoorCount;
            }
            // エンジン
            if (string.IsNullOrEmpty(freeSearchModelSet.EngineModelNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEMODELNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEMODELNM] = freeSearchModelSet.EngineModelNm;
            }
            // 排気量
            if (string.IsNullOrEmpty(freeSearchModelSet.EngineDisplaceNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEDISPLACENM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ENGINEDISPLACENM] = freeSearchModelSet.EngineDisplaceNm;
            }
            // Ｅ区分
            if (string.IsNullOrEmpty(freeSearchModelSet.EDivNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EDIVNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EDIVNM] = freeSearchModelSet.EDivNm;
            }
            // ミッション
            if (string.IsNullOrEmpty(freeSearchModelSet.TransmissionNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TRANSMISSIONNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TRANSMISSIONNM] = freeSearchModelSet.TransmissionNm;
            }
            // 駆動方式
            if (string.IsNullOrEmpty(freeSearchModelSet.WheelDriveMethodNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WHEELDRIVEMETHODNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WHEELDRIVEMETHODNM] = freeSearchModelSet.WheelDriveMethodNm;
            }
            // シフト
            if (string.IsNullOrEmpty(freeSearchModelSet.ShiftNm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIFTNM] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIFTNM] = freeSearchModelSet.ShiftNm;
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
            PrintSetTable.Columns.Add(CATEGORYNO, typeof(string));		    // 類別番号;
            PrintSetTable.Columns.Add(BLANK, typeof(string));		    // ブランク;
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
        /// PMJKN02000UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 王海立</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private void PMJKN02000UA_Load(object sender, EventArgs e)
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
				// 次の項目へフォーカス移動
				this.SelectNextControl((Control)sender, true, true, true, true);
            }
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

		// ----- UPD 2010/05/16 ------------------->>>>>
		///// <summary>
		///// KeyUp イベント
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントハンドラ</param>
		///// <remarks> 
		///// <br>Note       : KeyUp イベントを行う</br>
		///// <br>Programmer : 王海立</br>
		///// <br>Date       : 2010/04/27</br> 
		///// </remarks>
		//private void tNedit_St_MakerCode_KeyUp(object sender, KeyEventArgs e)
		//{
		//    if (this.tNedit_St_MakerCode.Text == string.Empty)
		//    {
		//        this.tNedit_St_ModelCode.Enabled = false;
		//        this.tNedit_St_ModelCode.Text = string.Empty;
		//        this.tNedit_St_ModelSubCode.Enabled = false;
		//        this.tNedit_St_ModelSubCode.Text = string.Empty;
		//    }
		//    else
		//    {
		//        this.tNedit_St_ModelCode.Enabled = true;
		//    }
		//}

		///// <summary>
		///// KeyUp イベント
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントハンドラ</param>
		///// <remarks> 
		///// <br>Note       : KeyUp イベントを行う</br>
		///// <br>Programmer : 王海立</br>
		///// <br>Date       : 2010/04/27</br> 
		///// </remarks>
		//private void tNedit_St_ModelCode_KeyUp(object sender, KeyEventArgs e)
		//{
		//    if (this.tNedit_St_ModelCode.Text == string.Empty)
		//    {
		//        this.tNedit_St_ModelSubCode.Enabled = false;
		//        this.tNedit_St_ModelSubCode.Text = string.Empty;
		//    }
		//    else
		//    {
		//        this.tNedit_St_ModelSubCode.Enabled = true;
		//    }
		//}

		///// <summary>
		///// KeyUp イベント
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントハンドラ</param>
		///// <remarks> 
		///// <br>Note       : KeyUp イベントを行う</br>
		///// <br>Programmer : 王海立</br>
		///// <br>Date       : 2010/04/27</br> 
		///// </remarks>
		//private void tNedit_Ed_MakerCode_KeyUp(object sender, KeyEventArgs e)
		//{
		//    if (this.tNedit_Ed_MakerCode.Text == string.Empty)
		//    {
		//        this.tNedit_Ed_ModelCode.Enabled = false;
		//        this.tNedit_Ed_ModelCode.Text = string.Empty;
		//        this.tNedit_Ed_ModelSubCode.Enabled = false;
		//        this.tNedit_Ed_ModelSubCode.Text = string.Empty;
		//    }
		//    else
		//    {
		//        this.tNedit_Ed_ModelCode.Enabled = true;
		//    }
		//}

		///// <summary>
		///// ValueChanged イベント
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントハンドラ</param>
		///// <remarks> 
		///// <br>Note       : KeyUp イベントを行う</br>
		///// <br>Programmer : 王海立</br>
		///// <br>Date       : 2010/04/27</br> 
		///// </remarks>
		//private void tNedit_Ed_ModelCode_KeyUp(object sender, KeyEventArgs e)
		//{
		//    if (this.tNedit_Ed_ModelCode.Text == string.Empty)
		//    {
		//        this.tNedit_Ed_ModelSubCode.Enabled = false;
		//        this.tNedit_Ed_ModelSubCode.Text = string.Empty;
		//    }
		//    else
		//    {
		//        this.tNedit_Ed_ModelSubCode.Enabled = true;
		//    }
		//}

		/// <summary>
		/// ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks> 
		/// <br>Note       : ValueChanged イベントを行う</br>
		/// <br>Programmer : 姜凱</br>
		/// <br>Date       : 2010/05/16</br> 
		/// </remarks>
		private void tNedit_St_MakerCode_ValueChanged(object sender, EventArgs e)
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
		/// ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks> 
		/// <br>Note       : ValueChanged イベントを行う</br>
		/// <br>Programmer : 姜凱</br>
		/// <br>Date       : 2010/05/16</br> 
		/// </remarks>
		private void tNedit_St_ModelCode_ValueChanged(object sender, EventArgs e)
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
		/// ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks> 
		/// <br>Note       : ValueChanged イベントを行う</br>
		/// <br>Programmer : 姜凱</br>
		/// <br>Date       : 2010/05/16</br>  
		/// </remarks>
		private void tNedit_Ed_MakerCode_ValueChanged(object sender, EventArgs e)
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
		/// ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks> 
		/// <br>Note       : ValueChanged イベントを行う</br>
		/// <br>Programmer : 姜凱</br>
		/// <br>Date       : 2010/05/16</br> 
		/// </remarks>
		private void tNedit_Ed_ModelCode_ValueChanged(object sender, EventArgs e)
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
		// ----- UPD 2010/05/16 -------------------<<<<<
        # endregion ■ Control Event
    }
}