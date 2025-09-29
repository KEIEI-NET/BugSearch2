//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス商品コード変換マスタ（印刷） 入力フォームクラス
// プログラム概要   : 商品コード変換マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/08/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2009/09/07  修正内容 : グリッドに表示する項目と印刷する際の項目名を変更する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 修 正 日  2012/12/07  修正内容 : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// AB商品コードﾞ変換マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : AB商品コードﾞ変換マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.08.03</br>
    /// <br>UpdateNote : 2012/12/07 zhuhh</br>
    /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
    /// </remarks>
    public partial class PMSAE02000UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// AB商品コードﾞ変換マスタ印刷UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : AB商品コードﾞ変換マスタ印刷UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.03</br>
        /// <br></br>
        /// </remarks>
        public PMSAE02000UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._aBGoodsCdChgAcs = new ABGoodsCdChgAcs();

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

        //// 抽出条件クラス
        private ABGoodsCdChgPrint _aBGoodsCdChgPrint;

        //// データアクセス
        private ABGoodsCdChgAcs _aBGoodsCdChgAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;

        # endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMSAE02000UA";
        // プログラムID
        private const string ct_PGID = "PMSAE02000U";
        //// 帳票名称
        private string _printName = "AB商品コードﾞ変換マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "99ee2762-5eab-4c9d-976c-09bbd399858e";   // 保留
        # endregion ◆ Interface member

        private const string PRINTSET_TABLE = "SANDEGOODSCDCHG";

        // dataview名称用
        private const string BLGOODSCODE = "BLGoodsCode";
        private const string ABGOODSCODE = "ABGoodsCode";
        private const string BLGOODSHALFNAME = "BLGoodsHalfName";

        // --- DEL 2009/09/07 ------------------------------->>>>>
        //private const string BLGOODSCODE_TITLE = "ｺｰﾄﾞ";
        //private const string ABGOODSCODE_TITLE = "AB商品ｺｰﾄﾞ";
        //private const string BLGOODSHALFNAME_TITLE = "名称";
        // --- DEL 2009/09/07 ------------------------------<<<<<

        // --- ADD 2009/09/07 ------------------------------->>>>>
        private const string BLGOODSCODE_TITLE = "BLｺｰﾄﾞ";
        private const string ABGOODSCODE_TITLE = "商品ｺｰﾄﾞ";
        private const string BLGOODSHALFNAME_TITLE = "BLｺｰﾄﾞ名";
        // --- ADD 2009/09/07 ------------------------------<<<<<

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
                status = this._aBGoodsCdChgAcs.SearchAll(
                    out PrintSets,
                    this._enterpriseCode,
                    this._aBGoodsCdChgPrint);
            }
            else
            {
                status = this._aBGoodsCdChgAcs.SearchAll(
                    out PrintSets,
                    this._enterpriseCode,
                    this._aBGoodsCdChgPrint);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // BLコードクラスをデータセットへ展開する
                        int index = 0;
                        foreach (ABGoodsCdChgSet aBGoodsCdChgSet in PrintSets)
                        {

                            SecPrintSetToDataSet(aBGoodsCdChgSet.Clone(), index);
                            ++index;
                        }

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
                            "PMSAE02000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "AB商品コードﾞ変換マスタ（印刷）", 	// プログラム名称
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
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.03</br>
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
            printInfo.jyoken = this._aBGoodsCdChgPrint;
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
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.03</br>
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
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._aBGoodsCdChgPrint = new ABGoodsCdChgPrint();

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
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.04</br>
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
            sizeCell.Width = 60;
            sizeHeader.Height = 20;
            sizeHeader.Width = 60;

            // コード
            editBand.Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 名称
            sizeCell.Width = 330;
            sizeHeader.Width = 330;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // AB商品コード
            sizeCell.Width = 110;
            sizeHeader.Width = 110;
            editBand.Columns[ABGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            editBand.Columns[ABGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion 項目のサイズを設定

            #region ヘッダ名称を設定
            // ヘッダ名称を設定
            editBand.Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            editBand.Columns[BLGOODSHALFNAME].Header.Caption = BLGOODSHALFNAME_TITLE;
            editBand.Columns[ABGOODSCODE].Header.Caption = ABGOODSCODE_TITLE;
            # endregion ヘッダ名称を設定

            editBand.Columns[BLGOODSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLGOODSHALFNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[ABGOODSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;

            // 開始BLコード
            if (this._aBGoodsCdChgPrint.BLGoodsCodeSt != this.tNedit_BLGoodsCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // 終了BLコード
            if (this._aBGoodsCdChgPrint.BLGoodsCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // 削除指定
            if (this._aBGoodsCdChgPrint.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._aBGoodsCdChgPrint.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._aBGoodsCdChgPrint.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
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
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // ボタン設定
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // 初期フォーカスセット
                this.tNedit_BLGoodsCode_St.Focus();
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        # endregion

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.04</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります。";


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

            // 削除日付（開始～終了）
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
        /// <br>Note        : 日付の入力チェックを行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.04</br>
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

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.04</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 開始BLコード
                this._aBGoodsCdChgPrint.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
                if (this.tNedit_BLGoodsCode_St.GetInt() == 0)
                {
                    this.tNedit_BLGoodsCode_St.Text = string.Empty;
                }
                // 終了BLコード
                this._aBGoodsCdChgPrint.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();
                if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                {
                    this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                }

                // 削除指定区分
                this._aBGoodsCdChgPrint.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._aBGoodsCdChgPrint.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._aBGoodsCdChgPrint.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
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
        /// <param name="aBGoodsCdChgSet">AB商品コードﾞクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : AB商品コードﾞクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.04</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// </remarks>
        private void SecPrintSetToDataSet(ABGoodsCdChgSet aBGoodsCdChgSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;
            }

            if (aBGoodsCdChgSet.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = aBGoodsCdChgSet.BLGoodsCode.ToString("00000");
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSHALFNAME] = aBGoodsCdChgSet.BLGoodsHalfName;
            if (aBGoodsCdChgSet.ABGoodsCode.Trim() == string.Empty)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ABGOODSCODE] = string.Empty;
            }
            else
            {
                //this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ABGOODSCODE] = decimal.Parse(aBGoodsCdChgSet.ABGoodsCode).ToString("000000");// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ABGOODSCODE] = decimal.Parse(aBGoodsCdChgSet.ABGoodsCode).ToString("00000000");// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));		        // 	ｺｰﾄﾞ
            PrintSetTable.Columns.Add(BLGOODSHALFNAME, typeof(string));		    // 	名称
            PrintSetTable.Columns.Add(ABGOODSCODE, typeof(string));		        // 	AB商品コード

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.04</br>
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
        # endregion

        # endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMSAE02000UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private void PMSAE02000UA_Load(object sender, EventArgs e)
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
        /// ＢＬコードガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: ＢＬコードガイドをクリックときに発生する</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private void ub_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            // BLコードガイド表示
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            // ＢＬコード（開始）
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            // ＢＬコード（終了）
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tComboEditor_LogicalDeleteCode;
            }
            else
            {
                return;
            }

            //　設定
            targetControl.SetInt(blGoodsCdUMnt.BLGoodsCode);
            nextControl.Focus();
        }

        /// <summary>
        /// 削除指定設定時
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 削除指定設定時ときに発生する</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.08.03</br>
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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : ChangeFocus イベントを行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.07</br> 
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ＢＬコード開始
                case "tNedit_BLGoodsCode_St":
                    {
                        if (this.tNedit_BLGoodsCode_St.GetInt() == 0)
                        {
                            this.tNedit_BLGoodsCode_St.Text = string.Empty;
                        }
                        break;
                    }
                // ＢＬコード終了
                case "tNedit_BLGoodsCode_Ed":
                    {
                        if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                        {
                            this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                        }
                        break;
                    }
            }
        }
        # endregion ■ Control Event
    }
}