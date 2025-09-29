//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（エクスポート）
// プログラム概要   : 在庫マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/23  修正内容 : PVCS245 ソート順不正
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫マスタ（エクスポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ（エクスポート）UIフォームクラス</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN07250UA : Form, IExportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// 在庫マスタ（エクスポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（エクスポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07250UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._stockSetExpAcs = new StockSetExpAcs();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

            DataSetColumnConstruction();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN07150UA";
        // プログラムID
        private const string ct_PGID = "PMKHN07150U";
        // CSV名称
        private string _printName = "在庫マスタ（エクスポート）";
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        // ログイン拠点(自拠点)
        private string _loginSectionCode;

        private GoodsAcs _goodsAcs;

        //倉庫ガイド
        private WarehouseAcs _warehouseGuideAcs = null;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private StockExpWork _stockExpWork;

        // データアクセス
        private StockSetExpAcs _stockSetExpAcs;

        #endregion ■ Private Member

        #region ■ Private Const

        // dataview名称用
        private const string SECTIONCODE = "SectionCode"; // 管理拠点
        private const string WAREHOUSECODE = "WarehouseCode"; // 倉庫
        private const string GOODSMAKERCD = "GoodsMakerCd"; // メーカー
        private const string GOODSNO = "GoodsNo"; // 品番
        private const string STOCKUNITPRICEFL = "StockUnitPriceFl";// 棚卸評価単価
        private const string SUPPLIERSTOCK = "SupplierStock";// 仕入在庫数
        private const string SHIPMENTCNT = "ShipmentCnt";// 入荷数（未計上）
        private const string ARRIVALCNT = "ArrivalCnt";// 貸出数（未計上）
        private const string ACPODRCOUNT = "AcpOdrCount";// 受注数
        private const string MOVINGSUPLISTOCK = "MovingSupliStock";// 移動中在庫仕入数
        private const string SHIPMENTPOSCNT = "ShipmentPosCnt";// 現在庫数
        private const string SALESORDERCOUNT = "SalesOrderCount";// 発注残
        private const string STOCKDIV = "StockDiv";// 在庫区分
        private const string MINIMUMSTOCKCNT = "MinimumStockCnt";// 最低在庫数
        private const string MAXIMUMSTOCKCNT = "MaximumStockCnt";// 最高在庫数
        private const string SALESORDERUNIT = "SalesOrderUnit";// 発注ロット
        private const string STOCKSUPPLIERCODE = "StockSupplierCode";// 発注先
        private const string WAREHOUSESHELFNO = "WarehouseShelfNo";// 棚番
        private const string DUPLICATIONSHELFNO1 = "DuplicationShelfNo1";// 重複棚番１
        private const string DUPLICATIONSHELFNO2 = "DuplicationShelfNo2";// 重複棚番２
        private const string PARTSMANAGEMENTDIVIDE1 = "PartsManagementDivide1";// 管理区分１
        private const string PARTSMANAGEMENTDIVIDE2 = "PartsManagementDivide2";// 管理区分２
        private const string STOCKNOTE1 = "StockNote1";// 在庫備考１
        private const string STOCKNOTE2 = "StockNote2";// 在庫備考２

        private const string PRINTSET_TABLE = "STOCKRF";
        private const string PMKHN07250U_PRPID = "PMKHN07250U.xml";

        private const string NUMBER_FORMAT9 = "##0.00";
        private const string NUMBER_FORMAT8 = "##0.00";
        #endregion

        #region ■ IExportConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Method
        /// <summary>
        /// ｴｸｽﾎﾟｰﾄ前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ｴｸｽﾎﾟｰﾄ前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public bool ExportBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            // 入力チェック処理
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

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// 抽出データ処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = 0;

            this.uLabel_OutPutNum.Text = "0";

            ArrayList exportSets = null;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "エクスポート中";
            form.Message = "現在、データをエクスポート中です。";

            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._stockSetExpAcs.Search(
                    out exportSets,
                    this._enterpriseCode,
                    this._stockExpWork);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // 在庫マスタクラスをデータセットへ展開する
                        int index = 0;
                        foreach (StockSetExp stockSetExp in exportSets)
                        {
                            SecExportSetToDataSet(stockSetExp.Clone(), index);
                            ++index;
                        }
                        // ADD 2009/06/23 --->>>
                        // ソート順不正
                        this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = SECTIONCODE + "," + WAREHOUSECODE + "," + GOODSMAKERCD + "," + GOODSNO;
                        // ADD 2009/06/23 ---<<<
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN07250U", 						// アセンブリＩＤまたはクラスＩＤ
                            "在庫マスタ（ｴｸｽﾎﾟｰﾄ）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockSetExpAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// CSV出力情報処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07250U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return 0;
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._stockExpWork = new StockExpWork();

            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = "0";

            // 画面表示
            this.Show();
            return;
        }

        /// <summary>
        /// ｴｸｽﾎﾟｰﾄ完了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ｴｸｽﾎﾟｰﾄ完了処理を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");
        }
        #endregion  ◆ Public Method
        #endregion ■ IExportConditionInpType メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 入力項目の初期化を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
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
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.tEdit_TextFileName.DataText = string.Empty;

                // ボタン設定
                this.SetIconImage(this.ub_St_MarkerGuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MarkerGuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

                // 初期フォーカスセット
                this.tEdit_WarehouseCode_St.Focus();

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion ◎ 画面初期化処理

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note	   : ボタンアイコン設定処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion ◎ ボタンアイコン設定処理
        #endregion ◆ 画面初期化関係

        #region ◆ ｴｸｽﾎﾟｰﾄ前処理
        #region ◎ 入力チェック処理
        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 李占川</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            // 倉庫
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode_St.DataText.TrimEnd()) && !r.IsMatch(this.tEdit_WarehouseCode_St.DataText))
            {
                this.tEdit_WarehouseCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tEdit_WarehouseCode_Ed.DataText))
            {
                this.tEdit_WarehouseCode_Ed.Text = String.Empty;
            }

            // メーカー
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_St.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_St.DataText))
            {
                this.tNedit_GoodsMakerCd_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_Ed.DataText))
            {
                this.tNedit_GoodsMakerCd_Ed.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_St.DataText.Contains("　") || this.tEdit_GoodsNo_St.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_Ed.DataText.Contains("　") || this.tEdit_GoodsNo_Ed.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
            Regex r1 = new Regex(@"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$");
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_St.DataText))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_Ed.DataText))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // Coopyチェック
            WordCoopyCheck();

            const string ct_RangeError = "の範囲指定に誤りがあります。";

            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = "テキストファイル名を入力してください。";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            {
                errMessage = "CSVファイルパスが不正です。";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            // 倉庫（開始～終了）
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode_St.DataText.TrimEnd()) &&
                !String.IsNullOrEmpty(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) &&
                Int32.Parse(this.tEdit_WarehouseCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("倉庫{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
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

            // 品番
            if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty &&
                this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
                return status;
            }

            return status;
        }
        #endregion ◎ 入力チェック処理

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// ｴｸｽﾎﾟｰﾄ条件設定処理(画面→ｴｸｽﾎﾟｰﾄ条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		 : 画面→ｴｸｽﾎﾟｰﾄ条件へ設定する。</br>
        /// <br>Programmer 　: 李占川</br>
        /// <br>Date       　: 2009.05.14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 開始倉庫コード
                this._stockExpWork.WarehouseCodeSt = this.tEdit_WarehouseCode_St.DataText.Trim();
                // 終了倉庫コード
                this._stockExpWork.WarehouseCodeEd = this.tEdit_WarehouseCode_Ed.DataText.Trim();
                // 開始メーカー
                this._stockExpWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了メーカー
                this._stockExpWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // 開始メーカー
                this._stockExpWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;
                // 終了メーカー
                this._stockExpWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 抽出条件設定処理(画面→抽出条件)
        #endregion ◆ ｴｸｽﾎﾟｰﾄ前処理

        #region ◆ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
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
        #endregion ◆ エラーメッセージ表示処理

        #region DataSet関連
        /// <summary>
        /// 在庫マスタクラスデータセット展開処理
        /// </summary>
        /// <param name="stockSetExp">在庫マスタクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 在庫マスタクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SecExportSetToDataSet(StockSetExp stockSetExp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (String.IsNullOrEmpty(stockSetExp.SectionCode.Trim()))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = "00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = stockSetExp.SectionCode; // 管理拠点
            }
            if (String.IsNullOrEmpty(stockSetExp.WarehouseCode.Trim()))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSECODE] = "0000";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSECODE] = stockSetExp.WarehouseCode; // 倉庫
            }

            if (stockSetExp.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = "0"; // メーカー
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = stockSetExp.GoodsMakerCd.ToString("0000"); // メーカー
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNO] = stockSetExp.GoodsNo;// 品番
            if (stockSetExp.StockUnitPriceFl == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKUNITPRICEFL] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKUNITPRICEFL] = stockSetExp.StockUnitPriceFl.ToString(NUMBER_FORMAT9); // 棚卸評価単価
            }
            if (stockSetExp.SupplierStock == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERSTOCK] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERSTOCK] = stockSetExp.SupplierStock.ToString(NUMBER_FORMAT9); // 仕入在庫数
            }
            if (stockSetExp.ShipmentCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTCNT] = stockSetExp.ShipmentCnt.ToString(NUMBER_FORMAT9); // 入荷数（未計上）
            }
            if (stockSetExp.ArrivalCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ARRIVALCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ARRIVALCNT] = stockSetExp.ArrivalCnt.ToString(NUMBER_FORMAT8); // 貸出数（未計上）
            }

            if (stockSetExp.AcpOdrCount == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ACPODRCOUNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ACPODRCOUNT] = stockSetExp.AcpOdrCount.ToString(NUMBER_FORMAT8); // 受注数
            }
            if (stockSetExp.MovingSupliStock == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MOVINGSUPLISTOCK] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MOVINGSUPLISTOCK] = stockSetExp.MovingSupliStock.ToString(NUMBER_FORMAT8); // 移動中在庫仕入数
            }
            if (stockSetExp.ShipmentPosCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTPOSCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTPOSCNT] = stockSetExp.ShipmentPosCnt.ToString(NUMBER_FORMAT8); // 現在庫数
            }
            if (stockSetExp.SalesOrderCount == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESORDERCOUNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESORDERCOUNT] = stockSetExp.SalesOrderCount.ToString(NUMBER_FORMAT8); // 発注残
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKDIV] = stockSetExp.StockDiv.ToString(); // 在庫区分

            if (stockSetExp.MinimumStockCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MINIMUMSTOCKCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MINIMUMSTOCKCNT] = stockSetExp.MinimumStockCnt.ToString(NUMBER_FORMAT8); // 最低在庫数
            }
            if (stockSetExp.MaximumStockCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAXIMUMSTOCKCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAXIMUMSTOCKCNT] = stockSetExp.MaximumStockCnt.ToString(NUMBER_FORMAT8); // 最高在庫数
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESORDERUNIT] = stockSetExp.SalesOrderUnit.ToString(); // 発注ロット

            if (stockSetExp.StockSupplierCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKSUPPLIERCODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKSUPPLIERCODE] = stockSetExp.StockSupplierCode.ToString("000000"); // 発注先
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSESHELFNO] = stockSetExp.WarehouseShelfNo; // 棚番
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DUPLICATIONSHELFNO1] = stockSetExp.DuplicationShelfNo1; // 重複棚番１
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DUPLICATIONSHELFNO2] = stockSetExp.DuplicationShelfNo2; // 重複棚番２
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSMANAGEMENTDIVIDE1] = stockSetExp.PartsManagementDivide1; // 管理区分１
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSMANAGEMENTDIVIDE2] = stockSetExp.PartsManagementDivide2; // 管理区分２
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKNOTE1] = stockSetExp.StockNote1; // 在庫備考１
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKNOTE2] = stockSetExp.StockNote2; // 在庫備考２
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(SECTIONCODE, typeof(string));// 管理拠点
            PrintSetTable.Columns.Add(WAREHOUSECODE, typeof(string));// 倉庫
            PrintSetTable.Columns.Add(GOODSMAKERCD, typeof(string));// メーカー
            PrintSetTable.Columns.Add(GOODSNO, typeof(string));// 品番
            PrintSetTable.Columns.Add(STOCKUNITPRICEFL, typeof(string));// 棚卸評価単価
            PrintSetTable.Columns.Add(SUPPLIERSTOCK, typeof(string));// 仕入在庫数
            PrintSetTable.Columns.Add(ARRIVALCNT, typeof(string));// 入荷数（未計上）
            PrintSetTable.Columns.Add(SHIPMENTCNT, typeof(string));// 貸出数（未計上）
            PrintSetTable.Columns.Add(ACPODRCOUNT, typeof(string));// 受注数
            PrintSetTable.Columns.Add(MOVINGSUPLISTOCK, typeof(string));// 移動中在庫仕入数
            PrintSetTable.Columns.Add(SHIPMENTPOSCNT, typeof(string));// 現在庫数
            PrintSetTable.Columns.Add(SALESORDERCOUNT, typeof(string));// 発注残
            PrintSetTable.Columns.Add(STOCKDIV, typeof(string));// 在庫区分
            PrintSetTable.Columns.Add(MINIMUMSTOCKCNT, typeof(string));// 最低在庫数
            PrintSetTable.Columns.Add(MAXIMUMSTOCKCNT, typeof(string));// 最高在庫数
            PrintSetTable.Columns.Add(SALESORDERUNIT, typeof(string));// 発注ロット
            PrintSetTable.Columns.Add(STOCKSUPPLIERCODE, typeof(string));// 発注先
            PrintSetTable.Columns.Add(WAREHOUSESHELFNO, typeof(string));// 棚番
            PrintSetTable.Columns.Add(DUPLICATIONSHELFNO1, typeof(string));// 重複棚番１
            PrintSetTable.Columns.Add(DUPLICATIONSHELFNO2, typeof(string));// 重複棚番２
            PrintSetTable.Columns.Add(PARTSMANAGEMENTDIVIDE1, typeof(string));// 管理区分１
            PrintSetTable.Columns.Add(PARTSMANAGEMENTDIVIDE2, typeof(string));// 管理区分２
            PrintSetTable.Columns.Add(STOCKNOTE1, typeof(string));// 在庫備考１
            PrintSetTable.Columns.Add(STOCKNOTE2, typeof(string));// 在庫備考２

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }
        #endregion DataSet関連
        #endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMKHN07250U_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void PMKHN07150U_Load(object sender, EventArgs e)
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

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : メーカーガイドをクリックときに発生する</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void MakerGuideCode_Click(object sender, EventArgs e)
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
            Control nextControl;
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

            // フォーカス移動
            nextControl.Focus();
        }

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>  
        private void WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }

            // 倉庫ガイド起動
            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._loginSectionCode);

            TEdit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tEdit_WarehouseCode_St;
                nextControl = this.tEdit_WarehouseCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tEdit_WarehouseCode_Ed;
                nextControl = this.tNedit_GoodsMakerCd_St;
            }
            else
            {
                return;
            }

            if (status != 0)
            {
                return;
            }
            targetControl.DataText = warehouseData.WarehouseCode.TrimEnd();

            // フォーカス移動
            nextControl.Focus();
        }

        /// <summary>
        /// CSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : CSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // タイトルバーの文字列
                saveFileDialog.Title = "出力ファイル選択";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.OverwritePrompt = false;

                if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
                {
                    saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }

                //「ファイルの種類」を指定
                saveFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // Coopyチェック
            WordCoopyCheck();
        }
        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : フォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopyチェック
            WordCoopyCheck();
        }
        #endregion ■ Control Event
    }
}