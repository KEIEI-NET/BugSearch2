//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.Misc;
using System.IO;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 卸商商品価格改正UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 卸商商品価格改正UIフォームクラス</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    public partial class PMKHN02301UA : Form,
                                        IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                        IPrintConditionInpTypeUpdate,       //帳票業務(条件入力タイプ)実行
                                        IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Private Const
        /// <summary> クラスID </summary>
        /// <remarks>なし</remarks>
        private const string ct_ClassID = "PMKHN02301UA";
        /// <summary> プログラムID </summary>
        /// <remarks>なし</remarks>
        private const string ct_PGID = "PMKHN02301U";
        /// <summary> 帳票名称 </summary>
        /// <remarks>なし</remarks>
        private const string ct_PrintName = "卸商商品価格改正";
        /// <summary> 帳票キー </summary>
        /// <remarks>なし</remarks>
        private const string ct_PrintKey = "0c38d05b-a581-4548-b794-25cbfcbf2070";
        /// <summary> 件　単位 </summary>
        /// <remarks>なし</remarks>
        private const string ct_Ken = "件";
        /// <summary> 0 </summary>
        /// <remarks>なし</remarks>
        private const string ct_Zero = "0";
        /// <summary>コーディング</summary>
        /// <remarks>なし</remarks>
        public const string ENCODING_CODE = "shift_jis";
        #endregion ■ Private Const


        #region ■ Private Members

        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ 
        private bool _canPdf = false;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = false;
        // 確定ボタン表示有無プロパティ
        private bool _canUpdate = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;
        //メーカーアクセスクラス
        private MakerAcs _makerAcs;
        //BL商品コードクセスクラス
        private BLGoodsCdAcs _bLGoodsCdAcs;
        //仕入先クセスクラス
        private SupplierAcs _supplierAcs;
        //企業コード
        private string _enterpriseCode;
        //卸商商品価格改正アクセスクラス
        private GoodsInfoAcs _goodsInfoAcs;

        //private bool _updateFlg;

        //ファイルデータ
        ArrayList _data;
        //チェック後データ
        List<List<GoodsInfoData>> _checkData;

        //チェック後Pdfデータ
        List<List<GoodsInfoStringData>> _checkPdfData;

        #endregion ■ Private Members


        # region ■ Constractor
        /// <summary>
        /// 卸商商品価格改正UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 卸商商品価格改正UIフォームクラスコンストラクタ</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02301UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //卸商商品価格改正アクセスクラス
            this._goodsInfoAcs = new GoodsInfoAcs();

            //メーカーアクセスクラス
            this._makerAcs = new MakerAcs();

            //BL商品コードクセスクラス
            this._bLGoodsCdAcs = new BLGoodsCdAcs();

            //仕入先クセスクラス
            this._supplierAcs = new SupplierAcs();

            //_updateFlg = false;
        }
        # endregion ■ Constractor


        #region ■ IPrintConditionInpType メンバ

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

        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
            return 0;
        }

        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行います。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            //if (!this._updateFlg)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "確定ボタンを行う。", 0);
            //    return -1;
            //}

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            ////ファイルデータ
            //this._data = null;
            //status = this.ReadData(out _data);

            //if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "ファイルを読み込むが失敗します。", 0);
            //    return status;
            //}

            //if (_data.Count == 0)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "テキストファイルの中に、データが見つかりませんでした。", 0);
            //    return status;
            //}

            //this._checkData = null;
            //this._checkPdfData = null;
            //status = this.CheckData(ref _data, out _checkData, out _checkPdfData);

            //if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "ファイルデータをチェックが失敗します。", 0);
            //    return status;
            //}

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            printInfo.enterpriseCode = this._enterpriseCode;	// 企業コード
            printInfo.kidopgid = ct_PGID;				        // 起動PGID
            printInfo.key = ct_PrintKey;			            // PDF出力履歴用
            printInfo.prpnm = ct_PrintName;			            // PDF出力履歴用

            // 抽出条件クラス
            GoodsInfoCndtn extrInfo = new GoodsInfoCndtn();

            // 抽出条件設定処理(画面→抽出条件)
            SetExtrInfo(ref extrInfo);

            // 抽出条件の設定
            printInfo.PrintPaperSetCd = 0;
            printInfo.jyoken = extrInfo;

            //// 更新後の場合、既にデータを取得済みなので再検索を行わない
            //if (this._updateFlg == true)
            //{
            //    printInfo.rdData = this._dataView;
            //}
            //else
            //{
            //    printInfo.rdData = null;
            //}

            DataTable dataTable = new DataTable();
            PMKHN02306EA.CreateDataTableGoodsWarnErrorCheck(ref dataTable);
            //this.SetDataTable(ref dataTable, _checkData);
            this.SetDataTable(ref dataTable, _checkPdfData);
            // フィルター文字列
            string strFilter = string.Empty;
            // ソート文字列を取得
            //string strSort = MakeSortingOrderString();
            string strSort = PMKHN02306EA.ct_Col_Orderby + " ASC";

            // 抽出結果テーブルから指定されたフィルタ・ソート条件でデータビューを作成
            DataView dv = new DataView(dataTable, strFilter, strSort, DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                // データをセット
                printInfo.rdData = dv;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
                return status;
            }

            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            printDialog.ShowDialog();

            //if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "対象商品が存在しません。", 0);
            //}

            parameter = printInfo;

            this._canPdf = false;
            this._canPrint = false;
            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);

            return printInfo.status;
        }

        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行います。(入力チェックなど)</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {

            string errMessage = "";
            Control errComponent = null;

            // 入力チェック処理
            if (!ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null) errComponent.Focus();

                return (false);
            }

            return (true);
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行います。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:起動パラメータを変更する場合はここで行う。
            this.Show();
        }

        /// <summary> 抽出ボタン表示有無プロパティ</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>抽出ボタン表示有無取得プロパティ </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF出力ボタン表示有無プロパティ取得プロパティ </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>印刷ボタン表示取得プロパティ </remarks> 
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion ■ IPrintConditionInpType メンバ


        #region ■ IPrintConditionInpTypePdfCareer メンバ

        /// <summary> 帳票キー</summary>
        /// <value>PrintKey</value>               
        /// <remarks>帳票キー取得プロパティ </remarks>  
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> 帳票名</summary>
        /// <value>PrintName</value>               
        /// <remarks>帳票名取得ププロパティ </remarks> 
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        #endregion ■ IPrintConditionInpTypePdfCareer メンバ


        #region ■ IPrintConditionInpTypeUpdate メンバ

        /// <summary> 実行ボタン状態</summary>
        /// <value>CanUpdate</value>               
        /// <remarks>実行ボタン状態取得ププロパティ </remarks> 
        public bool CanUpdate
        {
            get { return this._canUpdate; }
        }

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 更新＋印刷処理を行います。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "卸商商品価格改正" + "データ更新に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL; ;
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //ファイルデータ
            this._data = null;
            status = this.ReadData(out _data);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "ファイルを読み込むが失敗します。", 0);
                return status;
            }

            if (_data.Count == 0)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "テキストファイルの中に、データが見つかりませんでした。", 0);
                return status;
            }

            this._checkData = null;
            this._checkPdfData = null;
            //データをチェックする
            status = this.CheckData(ref _data, out _checkData, out _checkPdfData);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "ファイルデータをチェックが失敗します。", 0);
                return status;
            }

            List<GoodsInfoData> errorLst = new List<GoodsInfoData>();
            List<GoodsInfoData> normalLst = new List<GoodsInfoData>();
            List<GoodsInfoData> warnLst = new List<GoodsInfoData>();
            normalLst = _checkData[0] as List<GoodsInfoData>;
            warnLst = _checkData[1] as List<GoodsInfoData>;
            errorLst = _checkData[2] as List<GoodsInfoData>;

            // 更新処理
            if (((null != warnLst) && (warnLst.Count > 0))
                || ((null != errorLst) && (errorLst.Count > 0)))
            {
                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                        ct_ClassID,
                                                        "エラー・警告が発生しました。印刷／PDF出力を行い、内容を確認して下さい。",
                                                        0,
                                                        MessageBoxButtons.OK);
                this._canPdf = true;
                this._canPrint = true;
                // ツールバー設定イベント
                ParentToolbarSettingEvent(this);
                //this._updateFlg = true;
            }
            else
            {
                this._canPdf = false;
                this._canPrint = false;
                // ツールバー設定イベント
                ParentToolbarSettingEvent(this);
                //this._updateFlg = false;
            }

            // 抽出条件設定処理(画面→抽出条件)
            GoodsInfoCndtn extrInfo = new GoodsInfoCndtn();
            SetExtrInfo(ref extrInfo);

            object countNum = null;
            object writeError;
            string errMsg = string.Empty;
            // 更新
            if (((null != normalLst) && (normalLst.Count > 0)) || ((null != warnLst) && (warnLst.Count > 0)))
            {
                status = this._goodsInfoAcs.WriteGoodsInfo(out countNum, out writeError, extrInfo, normalLst, warnLst, out  errMsg);
            }

            ArrayList ret = countNum as ArrayList;

            //入力件数
            this.ultraLabel_InsertNum.Text = NumberFormat(this._data.Count) + ct_Ken;

            if (null != countNum && null != ret && ret.Count > 0)
            {
                //更新件数
                this.ultraLabel_UpdateNum.Text = NumberFormat(Convert.ToInt32(ret[0])) + ct_Ken;
                //追加件数
                this.ultraLabel_AddNum.Text = NumberFormat(Convert.ToInt32(ret[1])) + ct_Ken;
            }
            else
            {
                //更新件数
                this.ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
                //追加件数
                this.ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            }

            //警告件数
            if ((null != warnLst) && (warnLst.Count > 0))
            {
                this.ultraLabel_WarnNum.Text = NumberFormat(warnLst.Count) + ct_Ken;
            }
            else
            {
                this.ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            }

            //エラー件数
            if ((null != errorLst) && (errorLst.Count > 0))
            {
                this.ultraLabel_ErrorNum.Text = NumberFormat(errorLst.Count) + ct_Ken;
            }
            else
            {
                this.ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;
            }

            this.tEdit_FileName.Focus();


            if (null != countNum && null != ret && ret.Count > 0)
            {
                if (Convert.ToInt32(ret[0]) > 0 || Convert.ToInt32(ret[1]) > 0)
                {
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                }
            }
            return (status);
            // 印刷処理
            //return Print(ref parameter);
        }

        #endregion ■ IPrintConditionInpTypeUpdate メンバ


        #region ■ Private Methods
        /// <summary>
        /// 画面情報初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報初期設定処理</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // 商品マスタ更新区分
            InitializeUpdateType();

            // ガイドボタンのアイコン設定
            this.SetIconImage(this.ultraButton_FileName, Size16_Index.STAR1);

        }

        /// <summary>
        /// 商品マスタ更新区分
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品マスタ更新区分の初期化を行う</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void InitializeUpdateType()
        {
            this.tComboEditor_UpdateType.Items.Clear();

            this.tComboEditor_UpdateType.Items.Add(GoodsInfoCndtn.ct_UpdateZero, GoodsInfoCndtn.ct_UpdateZeroName);
            this.tComboEditor_UpdateType.Items.Add(GoodsInfoCndtn.ct_UpdateOne, GoodsInfoCndtn.ct_UpdateOneName);
            this.tComboEditor_UpdateType.Items.Add(GoodsInfoCndtn.ct_UpdateTwo, GoodsInfoCndtn.ct_UpdateTwoName);

            this.tComboEditor_UpdateType.MaxDropDownItems = this.tComboEditor_UpdateType.Items.Count;
            this.tComboEditor_UpdateType.SelectedIndex = 0;
        }

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコン設定処理を行う</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion


        /// <summary>
        /// 抽出条件設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件設定処理</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void SetExtrInfo(ref GoodsInfoCndtn goodsInfoCndtn)
        {
            // 企業コード
            goodsInfoCndtn.EnterpriseCode = this._enterpriseCode;

            //ファイル名称
            goodsInfoCndtn.FileName = this.tEdit_FileName.Text;

            //商品マスタ更新区分
            goodsInfoCndtn.UpdateType = Convert.ToInt32(this.tComboEditor_UpdateType.SelectedItem.DataValue);

        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コントロール</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: 入力内容のチェック処理を行います。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_MustInputError = "を入力してください。";
            const string ct_ExistError = "が見つかりませんでした。";

            if (!string.IsNullOrEmpty(this.tEdit_FileName.Text))
            {
                if ((!File.Exists(this.tEdit_FileName.Text)))
                {
                    errMessage = string.Format("{0}{1}", this.tEdit_FileName.Text, ct_ExistError);
                    errComponent = this.tEdit_FileName;
                    return (false);
                }
            }
            else
            {
                errMessage = string.Format("入力ファイル名{0}", ct_MustInputError);
                errComponent = this.tEdit_FileName;
                return (false);
            }
            return (true);
        }

        /// <summary>
        /// 入力ファイルRead処理
        /// </summary>
        /// <param name="textCode">変換後対象</param>
        /// <returns>戻り値：0:正常 3:EOF</returns>
        /// <remarks>
        /// <br>Note       : 特になし。</br>
        /// <br>Programmer : 汪千来</br>            
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private int ReadData(out ArrayList data)
        {
            data = new ArrayList();
            string fileName = this.tEdit_FileName.Text;
            if (!File.Exists(fileName))
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            StreamReader sr;
            sr = new StreamReader(fileName, Encoding.GetEncoding(ENCODING_CODE));
            int i = 0;
            try
            {
                //GoodsInfoData temGoodsAddData = null;
                GoodsInfoStringData temStringData = null;

                while (sr.Peek() >= 0)
                {
                    string lineText = sr.ReadLine();
                    string lineTextTmp;
                    string ret;
                    if (lineText.Trim().Length != 0)
                    {
                        //    textCode = GetTextCode(lineText.Split('='), true, null);
                        //    return 0;
                        //temGoodsAddData = new GoodsInfoData();



                        //if (119 != lineText.Length)
                        if ((lineText.Length < 109) && (lineText.Length > 119))
                        {
                            sr.Close();
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        temStringData = new GoodsInfoStringData();
                        lineTextTmp = lineText.Clone() as string;


                        //// 企業コード
                        //temGoodsAddData.EnterpriseCode = this._enterpriseCode;
                        ////仕入先ｺｰﾄﾞ		4 	4 	1 
                        //temGoodsAddData.SupplierCd = Convert.ToInt32(lineText.Substring(0, 4));
                        ////ﾒｰｶｰｺｰﾄﾞ		4 	4 	5 
                        //temGoodsAddData.GoodsMakerCd = Convert.ToInt32(lineText.Substring(4, 4));
                        ////分類ｺｰﾄﾞ		4 	4 	9 
                        //temGoodsAddData.KindCd = lineText.Substring(8, 4);
                        ////翼ｺｰﾄﾞ		4 	4 	13 
                        //temGoodsAddData.BLGoodsCode = Convert.ToInt32(lineText.Substring(12, 4));
                        ////品　番		18 	18 	17 
                        //temGoodsAddData.GoodsNo = lineText.Substring(16, 18);
                        ////品　名		20 	20 	35 
                        //temGoodsAddData.GoodsName = lineText.Substring(34, 20);
                        ////定　価		7 	7 	55 
                        //temGoodsAddData.Price = Convert.ToDouble(lineText.Substring(54, 7));
                        ////部品商原価１		7 	7 	62 
                        //temGoodsAddData.Price1 = Convert.ToDouble(lineText.Substring(61, 7));
                        ////部品商原価２		7 	7 	69 
                        //temGoodsAddData.Price2 = Convert.ToDouble(lineText.Substring(68, 7));
                        ////部品商原価３		7 	7 	76 
                        //temGoodsAddData.Price3 = Convert.ToDouble(lineText.Substring(75, 7));
                        ////価格実施日		8 	8 	83 
                        //temGoodsAddData.PriceStartDate = Convert.ToInt64(lineText.Substring(82, 8));
                        ////登録区分		1 	1 	91 
                        //temGoodsAddData.LoginFlg = lineText.Substring(90, 1);
                        ////売価率		5 	5 	92 
                        //temGoodsAddData.StockRate = Convert.ToDouble(lineText.Substring(91, 5));
                        ////売　価		9 	9 	97 
                        //temGoodsAddData.SalesUnitCost = Convert.ToDouble(lineText.Substring(96, 9));
                        ////部品商ｺｰﾄﾞ		6 	6 	106 
                        //temGoodsAddData.GoodsTraderCd = lineText.Substring(105, 6);
                        ////作成日付		8 	8 	112 
                        //temGoodsAddData.FileCreateDateTime = Convert.ToInt64(lineText.Substring(111, 8));

                        // 企業コード
                        temStringData.EnterpriseCode = this._enterpriseCode;
                        //仕入先ｺｰﾄﾞ		4 	4 	1 
                        temStringData.SupplierCd = lineText.Substring(0, 4);
                        //ﾒｰｶｰｺｰﾄﾞ		4 	4 	5 
                        temStringData.GoodsMakerCd = lineText.Substring(4, 4);
                        //分類ｺｰﾄﾞ		4 	4 	9 
                        temStringData.KindCd = lineText.Substring(8, 4);
                        //翼ｺｰﾄﾞ		4 	4 	13 
                        temStringData.BLGoodsCode = lineText.Substring(12, 4);
                        //品　番		18 	18 	17 
                        temStringData.GoodsNo = lineText.Substring(16, 18);
                        //品　名		20 	20 	35 
                        //temStringData.GoodsName = lineText.Substring(34, 20);
                        //temStringData.GoodsName = GetStringToByte(lineTextTmp.Substring(34), 20);
                        int index = GetGoodsName(lineTextTmp, 34, 20, out ret);
                        temStringData.GoodsName = ret;
                        //定　価		7 	7 	55 
                        //temStringData.Price = lineText.Substring(54, 7);
                        temStringData.Price = lineText.Substring(index, 7);
                        //部品商原価１		7 	7 	62 
                        //temStringData.Price1 = lineText.Substring(61, 7);
                        temStringData.Price1 = lineText.Substring(index + 7, 7);
                        //部品商原価２		7 	7 	69 
                        //temStringData.Price2 = lineText.Substring(68, 7);
                        temStringData.Price2 = lineText.Substring(index + 14, 7);
                        //部品商原価３		7 	7 	76 
                        //temStringData.Price3 = lineText.Substring(75, 7);
                        temStringData.Price3 = lineText.Substring(index + 21, 7);
                        //価格実施日		8 	8 	83 
                        //temStringData.PriceStartDate = lineText.Substring(82, 8);
                        temStringData.PriceStartDate = lineText.Substring(index + 28, 8);
                        //登録区分		1 	1 	91 
                        //temStringData.LoginFlg = lineText.Substring(90, 1);
                        temStringData.LoginFlg = lineText.Substring(index + 36, 1);
                        //売価率		5 	5 	92 
                        //temStringData.StockRate = lineText.Substring(91, 5);
                        temStringData.StockRate = lineText.Substring(index + 37, 5);
                        //売　価		9 	9 	97 
                        //temStringData.SalesUnitCost = lineText.Substring(96, 9);
                        temStringData.SalesUnitCost = lineText.Substring(index + 42, 9);
                        //部品商ｺｰﾄﾞ		6 	6 	106 
                        //temStringData.GoodsTraderCd = lineText.Substring(105, 6);
                        temStringData.GoodsTraderCd = lineText.Substring(index + 51, 6);
                        //作成日付		8 	8 	112 
                        //temStringData.FileCreateDateTime = lineText.Substring(111, 8);
                        temStringData.FileCreateDateTime = lineText.Substring(index + 57, 8);
                        //印字順
                        temStringData.Orderby = i++;

                        data.Add(temStringData);
                    }
                }
                sr.Close();
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch
            {
                sr.Close();
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }

        int GetGoodsName(string srcStr, int startIndex, int byteLength, out string ret)
        {
            string tempStr = srcStr.Substring(startIndex);
            int index = 0;
            ret = string.Empty;
            int byteCount = 0;
            for (int i = 0; i < tempStr.Length; i++)
            {
                string str = tempStr[i].ToString();
                if (ValidString(str))
                {
                    byteCount += 2;
                }
                else
                {
                    byteCount++;
                }
                if (byteCount == byteLength)
                {
                    ret = tempStr.Substring(0, i + 1);
                    index = i + startIndex + 1;
                    break;
                }
            }
            return index;
        }

        static bool ValidString(string value)
        {
            if (Regex.IsMatch(value, @"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        /// <summary>
        /// データ位数を制限処理
        /// </summary>
        /// <param name="useName"></param>
        /// <param name="byteLength"></param>
        /// <returns>制限後文字</returns>
        /// <remarks>
        /// <br>Note       : データ位数を制限処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private string GetStringToByte(string useName, int byteLength)
        {
            string str = useName.Clone() as string;
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(str);
            int n = 0;  //  当該の漢字
            int i;  //  表示の漢字
            if (bytes.GetLength(0) < byteLength)
            {
                return str;
            }
            for (i = 0; i < bytes.GetLength(0) && n < byteLength; i++)
            {
                if (i % 2 == 0)
                {
                    n++;
                }
                else
                {
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

            }
            if (i % 2 == 1)
            {
                if (bytes[i] > 0)
                    i = i - 1;
                else
                    i = i + 1;
            }
            string ret = System.Text.Encoding.Unicode.GetString(bytes, 0, i);
            return ret;
        }

        /// <summary>
        /// データテーブル設定処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        /// <param name="trustStockResultList">卸商商品価格改正帳票データリスト</param>
        /// <remarks>
        /// <br>Note       : 卸商商品価格改正帳票データをデータテーブルに設定します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void SetDataTable(ref DataTable dataTable, List<List<GoodsInfoStringData>> checkPdfData)
        {
            List<GoodsInfoStringData> warnPdfLst = checkPdfData[1] as List<GoodsInfoStringData>;
            List<GoodsInfoStringData> errorPdfLst = checkPdfData[2] as List<GoodsInfoStringData>;

            if (((warnPdfLst != null) && (warnPdfLst.Count > 0)) || ((null != errorPdfLst) && (errorPdfLst.Count > 0)))
            {
                if ((warnPdfLst != null) && (warnPdfLst.Count > 0))
                {
                    foreach (GoodsInfoStringData temGoodsInfoPdfData in warnPdfLst)
                    {
                        DataRow dr = dataTable.NewRow();
                        //仕入先ｺｰﾄﾞ
                        dr[PMKHN02306EA.ct_Col_SupplierCd] = temGoodsInfoPdfData.SupplierCd;
                        //メーカー
                        dr[PMKHN02306EA.ct_Col_GoodsMakerCd] = temGoodsInfoPdfData.GoodsMakerCd;
                        //ＢＬコード
                        dr[PMKHN02306EA.ct_Col_BLGoodsCode] = temGoodsInfoPdfData.BLGoodsCode;
                        //品番
                        dr[PMKHN02306EA.ct_Col_GoodsNo] = temGoodsInfoPdfData.GoodsNo;
                        //品名
                        dr[PMKHN02306EA.ct_Col_GoodsName] = temGoodsInfoPdfData.GoodsName;
                        //定価
                        dr[PMKHN02306EA.ct_Col_Price] = temGoodsInfoPdfData.Price;
                        //仕入率
                        dr[PMKHN02306EA.ct_Col_SaleRate] = temGoodsInfoPdfData.StockRate;
                        //原価
                        dr[PMKHN02306EA.ct_Col_SalesUnitCost] = temGoodsInfoPdfData.SalesUnitCost;

                        //状態
                        if (GoodsInfoData.ct_PdfStatusForWarn.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForWarnName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForError.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForErrorName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForNormal.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForNormalName;
                        }
                        //チェック
                        dr[PMKHN02306EA.ct_Col_CheckMessage] = temGoodsInfoPdfData.CheckMessage;
                        //印字順
                        dr[PMKHN02306EA.ct_Col_Orderby] = temGoodsInfoPdfData.Orderby;

                        dataTable.Rows.Add(dr);
                    }
                }

                if ((errorPdfLst != null) && (errorPdfLst.Count > 0))
                {
                    foreach (GoodsInfoStringData temGoodsInfoPdfData in errorPdfLst)
                    {
                        DataRow dr = dataTable.NewRow();
                        //仕入先ｺｰﾄﾞ
                        dr[PMKHN02306EA.ct_Col_SupplierCd] = temGoodsInfoPdfData.SupplierCd;
                        //メーカー
                        dr[PMKHN02306EA.ct_Col_GoodsMakerCd] = temGoodsInfoPdfData.GoodsMakerCd;
                        //ＢＬコード
                        dr[PMKHN02306EA.ct_Col_BLGoodsCode] = temGoodsInfoPdfData.BLGoodsCode;
                        //品番
                        dr[PMKHN02306EA.ct_Col_GoodsNo] = temGoodsInfoPdfData.GoodsNo;
                        //品名
                        dr[PMKHN02306EA.ct_Col_GoodsName] = temGoodsInfoPdfData.GoodsName;
                        //定価
                        dr[PMKHN02306EA.ct_Col_Price] = temGoodsInfoPdfData.Price;
                        //仕入率
                        dr[PMKHN02306EA.ct_Col_SaleRate] = temGoodsInfoPdfData.StockRate;
                        //原価
                        dr[PMKHN02306EA.ct_Col_SalesUnitCost] = temGoodsInfoPdfData.SalesUnitCost;
                        //状態
                        if (GoodsInfoData.ct_PdfStatusForWarn.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForWarnName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForError.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForErrorName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForNormal.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForNormalName;
                        }
                        //チェック
                        dr[PMKHN02306EA.ct_Col_CheckMessage] = temGoodsInfoPdfData.CheckMessage;

                        //印字順
                        dr[PMKHN02306EA.ct_Col_Orderby] = temGoodsInfoPdfData.Orderby;

                        dataTable.Rows.Add(dr);
                    }
                }
            }
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        ///// <summary>
        ///// エラーメッセージ表示処理
        ///// </summary>
        ///// <param name="message">表示メッセージ</param>
        ///// <param name="status">ステータス</param>
        ///// <param name="procnm">発生メソッドID</param>
        ///// <param name="ex">例外情報</param>
        ///// <remarks>
        ///// <br>Note       : エラーメッセージの表示を行います。</br>
        ///// <br>Programmer : 汪千来</br>
        ///// <br>Date       : 2009/04/28</br>
        ///// </remarks>
        //private void MsgDispProc(string message, int status, string procnm, Exception ex)
        //{
        //    string errMessage = message + "\r\n" + ex.Message;

        //    TMsgDisp.Show(
        //        this, 								// 親ウィンドウフォーム
        //        emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
        //        ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
        //        ct_PrintName,						// プログラム名称
        //        procnm, 							// 処理名称
        //        "",									// オペレーション
        //        errMessage,							// 表示するメッセージ
        //        status, 							// ステータス値
        //        null, 								// エラーが発生したオブジェクト
        //        MessageBoxButtons.OK, 				// 表示するボタン
        //        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        //}


        #region ◎ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #endregion ■ Private Methods


        #region ■ Control Events
        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームをロードした時に発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void PMKHN02301UA_Load(object sender, EventArgs e)
        {
            // 画面情報初期設定
            SetScreenInitialSetting();
            //string st = "1000000";


            //空白をセットする
            ultraLabel_InsertNum.Text = ct_Zero + ct_Ken;
            ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
            ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);

            // 初期フォーカス設定
            this.tEdit_FileName.Focus();
        }


        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }
            return ret;
        }


        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 入力ファイル名ボタンをクリックした時に発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // タイトルバーの文字列
                    openFileDialog.Title = "商品追加データファイル選択";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                    //「ファイルの種類」を指定
                    //openFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";
                    openFileDialog.Filter = "すべてのファイル (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_FileName.Text = openFileDialog.FileName;
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// データをチェックする
        /// </summary>
        /// <param name="data">ファイルデータ</param>
        /// <param name="checkData">チェックする後データ</param>
        /// <remarks>
        /// <br>Note       : データをチェックすることを行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private int CheckData(ref  ArrayList data, out List<List<GoodsInfoData>> checkData, out List<List<GoodsInfoStringData>> checkPdfData)
        {
            // 品　番スペース
            const string SPACE18 = "                  ";
            // 品　名スペース
            const string SPACE20 = "                    ";

            //品番エラーフラグ
            bool goodsNoErrFlg = false;

            //品名警告フラグ
            bool goodsNameWarnFlg = false;

            //メーカーエラーフラグ
            bool goodsMakerCdErrFlg = false;
            //メーカー警告フラグ
            bool goodsMakerCdWarnFlg = false;

            //BLコードエラーフラグ
            bool bLGoodsCodeErrFlg = false;

            //BLコード警告フラグ
            bool bLGoodsCodeWarnFlg = false;

            //仕入先コードエラーフラグ
            bool supplierCdErrFlg = false;

            //仕入先コード警告フラグ
            bool supplierCdWarnFlg = false;

            //定価エラーフラグ
            bool priceErrFlg = false;

            //売価率エラーフラグ
            bool stockRateErrFlg = false;
            //売　価エラーフラグ
            bool salesUnitCostErrFlg = false;


            ArrayList _makerLst = new ArrayList();
            ArrayList _bLGoodsCdLst = new ArrayList();
            ArrayList _supplierLst = new ArrayList();

            this.SearchAllMaker(out _makerLst);
            this.SearchAllBLGoodsCd(out _bLGoodsCdLst);
            this.SearchAllSupplierCode(out _supplierLst);

            int makerLstLen = _makerLst.Count;
            int bLGoodsCdLstLen = _bLGoodsCdLst.Count;
            int supplierLstLen = _supplierLst.Count;


            //チェックメッセージ文字列
            StringBuilder strBuilder = null;
            checkData = new List<List<GoodsInfoData>>();
            List<GoodsInfoData> errorLst = new List<GoodsInfoData>();
            List<GoodsInfoData> normalLst = new List<GoodsInfoData>();
            List<GoodsInfoData> warnLst = new List<GoodsInfoData>();
            checkData.Add(normalLst);
            checkData.Add(warnLst);
            checkData.Add(errorLst);

            checkPdfData = new List<List<GoodsInfoStringData>>();
            List<GoodsInfoStringData> errorPdfLst = new List<GoodsInfoStringData>();
            List<GoodsInfoStringData> normalPdfLst = new List<GoodsInfoStringData>();
            List<GoodsInfoStringData> warnPdfLst = new List<GoodsInfoStringData>();
            checkPdfData.Add(normalPdfLst);
            checkPdfData.Add(warnPdfLst);
            checkPdfData.Add(errorPdfLst);

            GoodsInfoData temData = null;


            try
            {
                foreach (GoodsInfoStringData tmpGoodsInfoStringData in data)
                {
                    temData = new GoodsInfoData();
                    strBuilder = new StringBuilder(string.Empty);
                    goodsNoErrFlg = false;
                    goodsNameWarnFlg = false;
                    goodsMakerCdErrFlg = false;
                    goodsMakerCdWarnFlg = false;
                    bLGoodsCodeErrFlg = false;
                    bLGoodsCodeWarnFlg = false;
                    supplierCdErrFlg = false;
                    supplierCdWarnFlg = false;
                    priceErrFlg = false;
                    stockRateErrFlg = false;
                    salesUnitCostErrFlg = false;

                    //未使用項目
                    temData.EnterpriseCode = this._enterpriseCode;
                    temData.KindCd = tmpGoodsInfoStringData.KindCd;
                    temData.Price1 = tmpGoodsInfoStringData.Price1;
                    temData.Price2 = tmpGoodsInfoStringData.Price2;
                    temData.Price3 = tmpGoodsInfoStringData.Price3;
                    temData.LoginFlg = tmpGoodsInfoStringData.LoginFlg;
                    temData.GoodsTraderCd = tmpGoodsInfoStringData.GoodsTraderCd;
                    temData.FileCreateDateTime = tmpGoodsInfoStringData.FileCreateDateTime;
                    temData.PriceStartDate = Convert.ToInt64(tmpGoodsInfoStringData.PriceStartDate);

                    //品番チェック	
                    //スペースの場合はエラーとします。
                    if (string.IsNullOrEmpty(tmpGoodsInfoStringData.GoodsNo)
                        || SPACE18.Equals(tmpGoodsInfoStringData.GoodsNo))
                    {
                        goodsNoErrFlg = true;
                    }
                    temData.GoodsNo = tmpGoodsInfoStringData.GoodsNo;
                    //品名チェック	
                    //スペースの場合は警告とします。
                    if (string.IsNullOrEmpty(tmpGoodsInfoStringData.GoodsName)
                        || SPACE20.Equals(tmpGoodsInfoStringData.GoodsName))
                    {
                        goodsNameWarnFlg = true;
                    }
                    temData.GoodsName = tmpGoodsInfoStringData.GoodsName;
                    //メーカーチェック	
                    try
                    {
                        //１～９９９９以外はエラーとします。
                        temData.GoodsMakerCd = Convert.ToInt32(tmpGoodsInfoStringData.GoodsMakerCd);
                        if (temData.GoodsMakerCd < 1 || temData.GoodsMakerCd > 9999)
                        {
                            goodsMakerCdErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.GoodsMakerCd = temData.GoodsMakerCd.ToString("d04");
                        }

                        //メーカーマスタ未登録は警告とします。
                        if (makerLstLen > 0)
                        {
                            if (!ExistMaker(_makerLst, temData.GoodsMakerCd))
                            {
                                goodsMakerCdWarnFlg = true;
                            }
                        }
                        else
                        {
                            goodsMakerCdWarnFlg = true;
                        }
                    }
                    catch
                    {
                        goodsMakerCdErrFlg = true;
                        goodsMakerCdWarnFlg = true;
                    }




                    //BLコードチェック	
                    try
                    {
                        //０～９９９９以外はエラーとします。
                        temData.BLGoodsCode = Convert.ToInt32(tmpGoodsInfoStringData.BLGoodsCode);
                        if (temData.BLGoodsCode < 0 || temData.BLGoodsCode > 9999)
                        {
                            bLGoodsCodeErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.BLGoodsCode = temData.BLGoodsCode.ToString("d05");
                        }
                        //BLコードマスタ未登録は警告とします。
                        if (bLGoodsCdLstLen > 0)
                        {
                            if (!ExistBLGoodsCd(_bLGoodsCdLst, temData.BLGoodsCode))
                            {
                                bLGoodsCodeWarnFlg = true;
                            }
                        }
                        else
                        {
                            bLGoodsCodeWarnFlg = true;
                        }
                    }
                    catch
                    {
                        bLGoodsCodeErrFlg = true;
                        bLGoodsCodeWarnFlg = true;
                    }


                    //仕入先コードチェック	
                    try
                    {
                        //０～９９９９以外はエラーとします。
                        temData.SupplierCd = Convert.ToInt32(tmpGoodsInfoStringData.SupplierCd);
                        if (temData.SupplierCd < 0 || temData.SupplierCd > 9999)
                        {
                            supplierCdErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.SupplierCd = ((temData.SupplierCd)*100).ToString("d06");
                        }
                        //仕入先マスタ未登録は警告とします。
                        if (supplierLstLen > 0)
                        {
                            if (!ExistSupplierCode(_supplierLst, temData.SupplierCd))
                            {
                                supplierCdWarnFlg = true;
                            }
                        }
                        else
                        {
                            supplierCdWarnFlg = true;
                        }
                    }
                    catch
                    {
                        supplierCdErrFlg = true;
                        supplierCdWarnFlg = true;
                    }

                    //定価チェック	
                    try
                    {
                        //０～９,９９９,９９９以外はエラーとします。
                        temData.Price = Convert.ToDouble(tmpGoodsInfoStringData.Price);
                        if (temData.Price < 0 || temData.Price > 9999999)
                        {
                            priceErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.Price = NumberFormat(temData.Price);
                        }
                        //tmpGoodsInfoStringData.Price = Convert.ToString((temData.Price));
                        temData.Price = (temData.Price);
                    }
                    catch
                    {
                        priceErrFlg = true;
                    }

                    //売価率チェック	
                    try
                    {
                        //０～９９９９９以外はエラーとします。
                        temData.StockRate = Convert.ToDouble(tmpGoodsInfoStringData.StockRate);
                        if (temData.StockRate < 0 || temData.StockRate > 9999999)
                        {
                            stockRateErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.StockRate = ((temData.StockRate) / 100).ToString("0.00");
                        }
                        //tmpGoodsInfoStringData.StockRate = Convert.ToString((temData.StockRate) / 100);
                        temData.StockRate = (temData.StockRate);
                    }
                    catch
                    {
                        stockRateErrFlg = true;
                    }

                    //売価チェック	
                    try
                    {
                        //０～９９９９９９９９９以外はエラーとします。
                        temData.SalesUnitCost = Convert.ToDouble(tmpGoodsInfoStringData.SalesUnitCost);
                        //tmpGoodsInfoStringData.SalesUnitCost = Convert.ToString(temData.SalesUnitCost);
                        if (temData.SalesUnitCost < 0 || temData.SalesUnitCost > 999999999)
                        {
                            salesUnitCostErrFlg = true;
                        }
                        else 
                        {
                            //tmpGoodsInfoStringData.SalesUnitCost = NumberFormat(temData.SalesUnitCost);
                            tmpGoodsInfoStringData.SalesUnitCost = NumberFormat(temData.SalesUnitCost/100);
                        }
                    }
                    catch
                    {
                        salesUnitCostErrFlg = true;
                    }

                    //pdf状態をセットする
                    if (goodsNoErrFlg ||
                        goodsMakerCdErrFlg ||
                        bLGoodsCodeErrFlg ||
                        supplierCdErrFlg ||
                        priceErrFlg ||
                        stockRateErrFlg ||
                        salesUnitCostErrFlg)
                    {
                        tmpGoodsInfoStringData.PdfStatus = GoodsInfoData.ct_PdfStatusForError;
                        temData.PdfStatus = GoodsInfoData.ct_PdfStatusForError;
                        errorLst.Add(temData);
                        errorPdfLst.Add(tmpGoodsInfoStringData);
                    }
                    else if ((goodsNameWarnFlg
                                    || goodsMakerCdWarnFlg
                                    || bLGoodsCodeWarnFlg
                                    || supplierCdWarnFlg))
                    {
                        tmpGoodsInfoStringData.PdfStatus = GoodsInfoData.ct_PdfStatusForWarn;
                        temData.PdfStatus = GoodsInfoData.ct_PdfStatusForWarn;
                        warnLst.Add(temData);
                        warnPdfLst.Add(tmpGoodsInfoStringData);
                    }
                    else
                    {
                        tmpGoodsInfoStringData.PdfStatus = GoodsInfoData.ct_PdfStatusForNormal;
                        temData.PdfStatus = GoodsInfoData.ct_PdfStatusForNormal;
                        normalLst.Add(temData);
                        normalPdfLst.Add(tmpGoodsInfoStringData);
                    }

                    //チェックメッセージ
                    //仕入先コードチェック
                    if (supplierCdErrFlg || supplierCdWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_Supplier);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_Supplier);
                        }
                    }
                    //メーカーチェック
                    if (goodsMakerCdErrFlg || goodsMakerCdWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_GoodsMaker);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_GoodsMaker);
                        }
                    }
                    //BLコードチェック
                    if (bLGoodsCodeErrFlg || bLGoodsCodeWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_BLGoodsCode);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_BLGoodsCode);
                        }
                    }
                    //品番チェック
                    if (goodsNoErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_GoodsNo);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_GoodsNo);
                        }
                    }
                    //品名チェック
                    if (goodsNameWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_GoodsName);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_GoodsName);
                        }
                    }


                    //定価チェック
                    if (priceErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_Price);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_Price);
                        }
                    }
                    //売価率チェック
                    if (stockRateErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_StockRate);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_StockRate);
                        }
                    }
                    //売価チェック
                    if (salesUnitCostErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_SalesUnitCost);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_SalesUnitCost);
                        }
                    }
                    //チェックメッセージをセットする
                    tmpGoodsInfoStringData.CheckMessage = strBuilder.ToString();
                    temData.CheckMessage = strBuilder.ToString();
                }
                return 0;
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }


        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(double number)
        {
            string ret;
            if (Math.Abs(number) > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }
            return ret;
        }

        /// <summary>
        /// メーカー存在する
        /// </summary>
        /// <param name="_makerLst">メーカーリスト</param>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : メーカーを存在することを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool ExistMaker(ArrayList _makerLst, int goodsMakerCd)
        {
            bool result = false;
            foreach (MakerUMnt makerUMnt in _makerLst)
            {
                if (makerUMnt.GoodsMakerCd.Equals(goodsMakerCd))
                {
                    result = true;
                    break;

                }
            }
            return result;
        }



        /// <summary>
        /// メーカーRead
        /// </summary>
        /// <param name="_makerLst">メーカーリスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : メーカーReadを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool SearchAllMaker(out ArrayList _makerLst)
        {
            bool result = false;
            // 読み込み
            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            //MakerUMnt makerUMnt;
            //int status = _makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

            int status = _makerAcs.SearchAll(out _makerLst, this._enterpriseCode);

            if (status == 0 && _makerLst != null)
            {
                // 存在します
                result = true;
            }
            else
            {

                // 存在しません
                result = false;
            }
            return result;
        }

        /// <summary>
        /// BL商品コード存在
        /// </summary>
        /// <param name="_bLGoodsCdLst">BL商品コードリスト</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : BL商品コードを存在することを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool ExistBLGoodsCd(ArrayList _bLGoodsCdLst, int bLGoodsCode)
        {
            bool result = false;
            foreach (BLGoodsCdUMnt bLGoodsCdUMnt in _bLGoodsCdLst)
            {
                if (bLGoodsCdUMnt.BLGoodsCode.Equals(bLGoodsCode))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// BL商品コードRead
        /// </summary>
        /// <param name="_bLGoodsCdLst">BL商品コードリスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : BL商品コードReadを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool SearchAllBLGoodsCd(out ArrayList _bLGoodsCdLst)
        {
            bool result = false;
            // 読み込み
            if (_bLGoodsCdAcs == null)
            {
                _bLGoodsCdAcs = new BLGoodsCdAcs();
            }

            //BLGoodsCdUMnt bLGoodsCdUMnt;
            //int status = _bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCode);

            int status = _bLGoodsCdAcs.SearchAll(out _bLGoodsCdLst, this._enterpriseCode);
            if (status == 0 && _bLGoodsCdLst != null)
            {
                // 存在します
                result = true;
            }
            else
            {

                // 存在しません
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 仕入先コード存在する
        /// </summary>
        /// <param name="_supplierLst">仕入先コードリスト</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 仕入先コード存在することを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool ExistSupplierCode(ArrayList _supplierLst, int supplierCode)
        {
            bool result = false;
            int supplierCodeCmp = supplierCode * 100;
            foreach (Supplier supplier in _supplierLst)
            {
                if (supplier.SupplierCd.Equals(supplierCodeCmp))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 仕入先コードRead
        /// </summary>
        /// <param name="_supplierLst">仕入先コードリスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 仕入先コードReadを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool SearchAllSupplierCode(out ArrayList _supplierLst)
        {
            bool result = false;
            // 読み込み
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }

            //Supplier supplier;
            //int status = _supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
            int status = _supplierAcs.SearchAll(out _supplierLst, this._enterpriseCode);

            if (status == 0 && _supplierLst != null)
            {
                // 存在します
                result = true;
            }
            else
            {

                // 存在しません
                result = false;
            }
            return result;
        }

        /// <summary>
        /// エクスプローラーバー グループ縮小 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void uebMainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "ExtractConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// エクスプローラーバー グループ展開 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが展開される前に発生します。</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void uebMainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "ExtractConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 入力ファイル名 ValueChanged イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : 入力ファイル名 ValueChanged イベントを発生します。</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void tEdit_FileName_ValueChanged(object sender, EventArgs e)
        {
            this._canPdf = false;
            this._canPrint = false;

            //空白をセットする
            ultraLabel_InsertNum.Text = ct_Zero + ct_Ken;
            ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
            ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);

            // 初期フォーカス設定
            this.tEdit_FileName.Focus();

        }

        /// <summary>
        /// 商品マスタ更新区分 ValueChanged イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : 商品マスタ更新区分 ValueChanged イベントを発生します。</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void tComboEditor_UpdateType_ValueChanged(object sender, EventArgs e)
        {
            this._canPdf = false;
            this._canPrint = false;

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);

            //空白をセットする
            ultraLabel_InsertNum.Text = ct_Zero + ct_Ken;
            ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
            ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;

        }

        #endregion ■ Control Events




    }
}