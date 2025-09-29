//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ印刷
// プログラム概要   : 表示区分マスタ印刷フォーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：姚学剛
// 修 正 日  2012/07/03  修正内容 ：Redmine#30390 表示区分マスタ印刷
//                                  得意先掛率グループ、終了得意先コードとチェックの改良
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 表示区分マスタ印刷
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタ印刷クラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 姚学剛</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>管理番号   : 10801804-00</br>
    /// </remarks>
    public partial class PMKHN08720UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : クラスコンストラクタの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public PMKHN08720UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // データアクセス
            this._priceSelectSetAcs = new PriceSelectSetAcs();

            // データセット列情報構築処理
            DataSetColumnConstruction();
        }
        #endregion

        #region ■ Private member

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

        // 企業コード
        private string _enterpriseCode = "";

        // データアクセス
        private PriceSelectSetAcs _priceSelectSetAcs;

        // 抽出条件クラス
        private PriceSelectSetPrint _priceSelectSetPrintWork;

        // メーカーガイド
        private MakerAcs _makerAcs;

        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;

        // 得意先掛率グループガイド
        private UserGuideAcs _userGuideAcs;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // 得意先ガイド
        private UltraButton _customerGuideSender;
        #endregion ■ Private member

        #region  ■ Private cost
        // クラスID
        private const string ct_ClassID = "PMKHN08720UA";

        // プログラムID
        private const string ct_PGID = "PMKHN08720U";

        // 帳票名称
        private string _printName = "表示区分マスタ（印刷）";

        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留

        // ExporerBar グループ名称
        private const string PRINTSET_TABLE = "PRICESELECTSETRF";

        // dataview名称用
        private const string CUSTOMERCODE = "customercode";         // 得意先
        private const string CUSTOMERNAME = "customername";         // 得意先名
        private const string BLGROUPCODE = "blgroupcode";           // 得意先掛率グループ
        private const string MAKERCODE = "makercode";               // メーカー
        private const string MAKERNAME = "makername";               // メーカー名
        private const string BLGOODSCODE = "blgoodscode";           // BLコード
        private const string BLGOODSNAME = "blgoodsname";           // BLコード名
        private const string PRICESELECTDIV = "priceselectdiv";     // 表示区分

        // 得意先
        private const string CUSTOMERCODE_TITLE = "得意先";
        // 得意先名
        private const string CUSTOMERNAME_TITLE = "得意先名";
        // 得意先掛率グループ
        private const string BLGROUPCODE_TITLE = "得意先掛率グループ";
        // メーカー
        private const string MAKERCODE_TITLE = "メーカー";
        // メーカー名
        private const string MAKERNAME_TITLE = "メーカー名";
        // BLコード
        private const string BLGOODSCODE_TITLE = "BLコード";
        // BLコード名
        private const string BLGOODSNAME_TITLE = "BLコード名";
        // 価格表示区分
        private const string PRICESELECTDIV_TITLE = "価格表示区分";
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
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
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
                status = this._priceSelectSetAcs.Search(out secPrintSets, this._enterpriseCode, this._priceSelectSetPrintWork);
            }

            else
            {
                status = this._priceSelectSetAcs.SearchDelete(out secPrintSets, this._enterpriseCode, this._priceSelectSetPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {

                        // 部位クラスをデータセットへ展開する
                        int index = 0;
                        foreach (PriceSelectSet priceSelectSet in secPrintSets)
                        {

                            SecPrintSetToDataSet(priceSelectSet.Clone(), index);
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
                            ct_ClassID, 					    // アセンブリＩＤまたはクラスＩＤ
                            this._printName, 			        // プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._priceSelectSetAcs, 			// エラーが発生したオブジェクト
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
        /// <br>Note	   : 印刷処理を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				        // 起動PGID

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
            printInfo.jyoken = this._priceSelectSetPrintWork;
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
        /// <br>Note	   : 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
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
        /// <br>Note	　 : 画面表示を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._priceSelectSetPrintWork = new PriceSelectSetPrint();

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
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// メインフレームグリットレイアウト設定
        /// </summary>
        /// <param name="UGrid"></param>
        /// <remarks>
        /// <br>Note       : メインフレームグリットレイアウト設定。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
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

            // 得意先
            sizeCell.Width = 80;
            sizeHeader.Width = 80;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 得意先名
            sizeCell.Width = 220;
            sizeHeader.Width = 220;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 得意先掛率グループ
            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // メーカー
            sizeCell.Width = 70;
            sizeHeader.Width = 70;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // メーカー名
            sizeCell.Width = 330;
            sizeHeader.Width = 330;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BLコード
            sizeCell.Width = 70;
            sizeHeader.Width = 70;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BLコード名
            sizeCell.Width = 270;
            sizeHeader.Width = 270;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 表示区分
            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].Header.Caption = CUSTOMERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Header.Caption = BLGROUPCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Header.Caption = MAKERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Header.Caption = MAKERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].Header.Caption = BLGOODSNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].Header.Caption = PRICESELECTDIV_TITLE;

            // 1行目
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.SpanY = 2;
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件チェック処理を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>Update Note: 2012/07/03 姚学剛</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             Redmine#30390 表示区分マスタ印刷 得意先掛率グループ、終了得意先コードとチェックの改良</br>
        /// </remarks>
        public bool DataCheck()
        {
            bool status = true;

            // 発行タイプ
            if (this._priceSelectSetPrintWork.PrintType != (int)this.tComboEditor_PrintType.Value)
            {
                status = false;
                return status;
            }

            // 開始商品メーカーコード
            if (this._priceSelectSetPrintWork.GoodsMakerCdSt != this.tNedit_GoodsMakerCd_St.GetInt())
            {
                status = false;
                return status;
            }

            // 終了商品メーカーコード
            if (this._priceSelectSetPrintWork.GoodsMakerCdEd != this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                status = false;
                return status;
            }

            // 開始BL商品コード
            if (this._priceSelectSetPrintWork.BLGoodsCodeSt != this.tNedit_BLGoodsCode_St.GetInt())
            {
                status = false;
                return status;
            }

            // 終了BL商品コード
            if (this._priceSelectSetPrintWork.BLGoodsCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                status = false;
                return status;
            }

            // 開始得意先掛率グループ
            // if (this._priceSelectSetPrintWork.BLGroupCodeSt != this.tNedit_BLGoodsCode_St.DataText)  // DEL 2012/07/03 姚学剛 Redmine#30390
            if (this._priceSelectSetPrintWork.BLGroupCodeSt != this.tNedit_CustRateGroupCodeAllowZero_St.DataText)  // ADD 2012/07/03 姚学剛 Redmine#30390
            {
                status = false;
                return status;
            }

            // 終了得意先掛率グループ
            // if (this._priceSelectSetPrintWork.BLGroupCodeEd != this.tNedit_BLGoodsCode_Ed.DataText)  // DEL 2012/07/03 yaoxg Redmine#30390
            if (this._priceSelectSetPrintWork.BLGroupCodeEd != this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText)  // ADD 2012/07/03 姚学剛 Redmine#30390
            {
                status = false;
                return status;
            }

            // 開始得意先コード
            if (this._priceSelectSetPrintWork.CustomerCodeSt != this.tNedit_CustomerCode_St.GetInt())
            {
                status = false;
                return status;
            }

            // 終了得意先コード
            // if (this._priceSelectSetPrintWork.CustomerCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt()) // DEL 2012/07/03 姚学剛 Redmine#30390
            if (this._priceSelectSetPrintWork.CustomerCodeEd != this.tNedit_CustomerCode_Ed.GetInt())   // ADD 2012/07/03 姚学剛 Redmine#30390
            {
                status = false;
                return status;
            }

            // 削除指定
            if (this._priceSelectSetPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }

            // 開始削除年月日
            if (this._priceSelectSetPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetDateTime())
            {
                status = false;
                return status;
            }

            // 終了削除年月日
            if (this._priceSelectSetPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
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

        #endregion
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 入力項目の初期化を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                // メーカーコード（開始）
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                // メーカーコード（終了）
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                // ＢＬコード（開始）
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                // ＢＬコード（終了）
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                // 得意先コード（開始）
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                // 得意先コード（終了）
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                // 得意先掛率グループ（開始） 
                this.tNedit_CustRateGroupCodeAllowZero_St.DataText = string.Empty;
                // 得意先掛率グループ（終了）
                this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText = string.Empty;

                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // ボタン設定
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_DetailGoodsGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_DetailGoodsGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerGuide, Size16_Index.STAR1);

                // コンボの初期化
                this.tComboEditor_PrintType.Value = 0;      //メーカー+ＢＬコード+得意先

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
        /// <remarks>
        /// <br>Note	   : ボタンアイコン設定処理を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
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
        /// <br>Note	   : 画面の入力チェックを行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";

            // メーカー
            if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) && this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // ＢＬコード
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

            // 得意先
            if (
                (this.tNedit_CustomerCode_St.GetInt() != 0) &&
                (this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
                return status;
            }

            // 得意先掛率グループ
            if (
                (!string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_St.Text)) &&
                (!string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_Ed.Text)) &&
                this.tNedit_CustRateGroupCodeAllowZero_St.GetInt() > this.tNedit_CustRateGroupCodeAllowZero_Ed.GetInt())
            {
                errMessage = string.Format("得意先掛率グループ{0}", ct_RangeError);
                errComponent = this.tNedit_CustRateGroupCodeAllowZero_St;
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
                        errMessage = "削除日の範囲指定に誤りがあります。";
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
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note	   : 日付入力チェック処理を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, out string errMessage)
        {
            errMessage = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMessage = "日付を指定してください。";
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
                    errMessage = "日付を指定してください。";
                    return (false);
                }
            }

            if (year < 1900)
            {
                errMessage = "正しい日付を指定してください。";
                return (false);
            }

            if (month > 12)
            {
                errMessage = "正しい日付を指定してください。";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMessage = "正しい日付を指定してください。";
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
        /// <br>Note	   : 画面→抽出条件へ設定する。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 発行タイプ
                this._priceSelectSetPrintWork.PrintType = (int)this.tComboEditor_PrintType.Value;
                // 開始商品メーカー
                this._priceSelectSetPrintWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカー
                this._priceSelectSetPrintWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // 開始BL商品コード
                this._priceSelectSetPrintWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了BL商品コード
                this._priceSelectSetPrintWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();
                // 開始得意先
                this._priceSelectSetPrintWork.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                // 終了得意先
                this._priceSelectSetPrintWork.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                // 開始得意先掛率グループ
                if (string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_St.DataText))
                {
                    this._priceSelectSetPrintWork.BLGroupCodeSt = string.Empty;
                }
                else
                {
                    this._priceSelectSetPrintWork.BLGroupCodeSt = this.tNedit_CustRateGroupCodeAllowZero_St.DataText.PadLeft(4, '0');
                }
                // 終了得意先掛率グループ
                if (string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText))
                {
                    this._priceSelectSetPrintWork.BLGroupCodeEd = string.Empty;
                }
                else
                {
                    this._priceSelectSetPrintWork.BLGroupCodeEd = this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText.PadLeft(4, '0');
                }
                // 削除指定区分
                this._priceSelectSetPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._priceSelectSetPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetDateTime();
                // 終了削除日付
                this._priceSelectSetPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetDateTime();
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
        /// <param name="emErrorLevel">エラーレベル</param>
        /// <param name="errMessage">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel emErrorLevel, string errMessage, int status)
        {
            TMsgDisp.Show(
                emErrorLevel, 						// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        #endregion

        #region DataSet関連

        /// <summary>
        /// 表示区分クラスデータセット展開処理
        /// </summary>
        /// <param name="priceSelectSet">表示区分クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 表示区分クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void SecPrintSetToDataSet(PriceSelectSet priceSelectSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            // 得意先
            if (priceSelectSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = priceSelectSet.CustomerCode.ToString("00000000");
            }

            // 得意先名
            if (priceSelectSet.CustomerCode != 0 && string.IsNullOrEmpty(priceSelectSet.CustomerSnm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERNAME] = "未登録";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERNAME] = priceSelectSet.CustomerSnm;
            }

            // 得意先掛率グループ
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 3: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                case 4: // ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                case 5: // BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = priceSelectSet.BLGroupCode.ToString("0000");
                    break;
                case 0: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                case 1: // ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
                case 2: // BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                case 6: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄ
                case 7: // ﾒｰｶｰｺｰﾄﾞ
                case 8: // BLｺｰﾄﾞ
                    this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
                    break;
                case 9: // 全て
                    {
                        if (priceSelectSet.PriceSelectPtn == 3 || priceSelectSet.PriceSelectPtn == 4 || priceSelectSet.PriceSelectPtn == 5)
                        {
                            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = priceSelectSet.BLGroupCode.ToString("0000");
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
                        }
                        break;
                    }
            }

            // メーカー
            if (priceSelectSet.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERCODE] = priceSelectSet.GoodsMakerCd.ToString("0000");
            }

            // メーカー名
            if (priceSelectSet.GoodsMakerCd != 0 && string.IsNullOrEmpty(priceSelectSet.GoodsMakerSnm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERNAME] = "未登録";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERNAME] = priceSelectSet.GoodsMakerSnm;
            }

            // BLコード
            if (priceSelectSet.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = priceSelectSet.BLGoodsCode.ToString("00000");
            }

            // BLコード名
            if (priceSelectSet.BLGoodsCode != 0 && string.IsNullOrEmpty(priceSelectSet.BLGoodsHalfName))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSNAME] = "未登録";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSNAME] = priceSelectSet.BLGoodsHalfName;
            }

            // 表示区分
            if (priceSelectSet.PriceSelectDiv == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "0:優良";
            }
            if (priceSelectSet.PriceSelectDiv == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "1:純正";
            }
            if (priceSelectSet.PriceSelectDiv == 2)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "2:高い方(1:N)";
            }
            if (priceSelectSet.PriceSelectDiv == 3)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "3:高い方(1:1)";
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable secPrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            secPrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		        // 得意先

            secPrintSetTable.Columns.Add(CUSTOMERNAME, typeof(string));		        // 得意先名

            secPrintSetTable.Columns.Add(BLGROUPCODE, typeof(string));              // 得意先掛率グループ

            secPrintSetTable.Columns.Add(MAKERCODE, typeof(string));		        // メーカー

            secPrintSetTable.Columns.Add(MAKERNAME, typeof(string));		        // メーカー名

            secPrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));              // BLコード

            secPrintSetTable.Columns.Add(BLGOODSNAME, typeof(string));		        // BLコード名

            secPrintSetTable.Columns.Add(PRICESELECTDIV, typeof(string));		    // 表示区分

            this.Bind_DataSet.Tables.Add(secPrintSetTable);
        }

        #endregion DataSet関連
        #endregion ■ Private Method
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKHN08720UA
        #region ◎ PMKHN08720UA_Load Event

        /// <summary>
        /// PMKHN08720UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがフォームを読み込むときに発生する。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void PMKHN08720UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }
        #endregion

        #endregion ◆ PMKHN08720UA

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : メーカーガイドを行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            // メーカーガイド
            MakerUMnt makerUMnt;
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
                    case 0: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    case 3: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    case 6: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄ
                    case 9: // 全て
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                    case 1: // ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 4: // ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                        nextControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                        break;
                    case 7: // ﾒｰｶｰｺｰﾄﾞ
                        nextControl = this.tComboEditor_LogicalDeleteCode;
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
        /// ＢＬコードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ＢＬコードガイドを行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            BLGoodsCdUMnt blGoodsCdUMnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
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
                    case 0: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    case 9: // 全て
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 2: // BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 3: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    case 5: // BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                        nextControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                        break;
                    case 6: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ
                    case 8: // BLｺｰﾄﾞ
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                }
            }
            else
            {
                return;
            }

            targetControl.DataText = blGoodsCdUMnt.BLGoodsCode.ToString().TrimEnd();
            // 次フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// 得意先ｺｰﾄﾞガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 得意先ｺｰﾄﾞガイドを行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void ub_St_CustomerGuide_Click(object sender, EventArgs e)
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
                Control nextControl = null;
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.tNedit_CustomerCode_Ed;
                }
                else
                {
                    switch ((int)this.tComboEditor_PrintType.Value)
                    {
                        case 0: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        case 1: // ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        case 2: // BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                            nextControl = this.tComboEditor_LogicalDeleteCode;
                            break;
                        case 9: // 全て
                            nextControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                            break;
                    }
                }
                // フォーカス移動
                nextControl.Focus();
            }
        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        /// <remarks>
        /// <br>Note	   : 得意先ガイド選択イベントガイドを行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (_customerGuideSender == this.ub_St_CustomerGuide)
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
        /// 得意先掛率グループガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 得意先掛率グループガイドを行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void ub_St_DetailGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 43;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo); // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                nextControl = this.tNedit_CustRateGroupCodeAllowZero_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_CustRateGroupCodeAllowZero_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 3: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    case 4: // ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    case 5: // BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    case 9: // 全て
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                }
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
        /// 削除指定設定時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 削除指定設定時を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
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

        /// <summary>
        /// 発行タイプ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 発行タイプ変更を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 0: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 1: // ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = false;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 2: // BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    this.pn_GoodsMakerCd.Visible = false;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 3: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = true;
                    break;

                case 4: // ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = false;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = true;
                    break;

                case 5: // BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    this.pn_GoodsMakerCd.Visible = false;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = true;
                    break;

                case 6: // ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 7: // ﾒｰｶｰｺｰﾄﾞ
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = false;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 8: // BLｺｰﾄﾞ
                    this.pn_GoodsMakerCd.Visible = false;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 9: // 全て
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = true;
                    break;
            }
            this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
            this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
            this.tNedit_BLGoodsCode_St.DataText = string.Empty;
            this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
            this.tNedit_CustomerCode_St.DataText = string.Empty;
            this.tNedit_CustomerCode_Ed.DataText = string.Empty;
            this.tNedit_CustRateGroupCodeAllowZero_St.DataText = string.Empty;
            this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText = string.Empty;
        }
        #endregion ■ Control Event
    }
}
