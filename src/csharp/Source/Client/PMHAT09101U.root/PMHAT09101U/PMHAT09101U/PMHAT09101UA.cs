//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定処理
// プログラム概要   : 発注点設定処理UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/07/27  修正内容 : 確定、PDF表示ボタン実行時の各処理とメッセージの変更
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注点設定処理UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定処理UIフォームクラス</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.13</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMHAT09101UA : Form,
                                IPrintConditionInpTypeUpdate,           // 帳票共通（更新）
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {

        #region ■ Constructor
        /// <summary>
        /// 発注点設定処理UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注点設定処理UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br></br>
        /// </remarks>
        public PMHAT09101UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 発注点設定処理アクセスクラス
            this._orderPointStSimulationAcs = new OrderPointStSimulationAcs();
            // 発注点設定マスタメンテナンスアクセス
            this._orderPointStAcs = new OrderPointStAcs();
            // 倉庫マスタアクセスクラス
            this._wareHouseAcs = new WarehouseAcs();
            // 仕入先マスタアクセスクラス
            this._supplierAcs = new SupplierAcs();
            // メーカーマスタアクセスクラス
            this._makerAcs = new MakerAcs();
            // ユーザーガイドアクセスクラス
            this._userGuideAcs = new UserGuideAcs();
            // 商品中分類アクセスクラス
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            // BLグループアクセスクラス
            this._blGroupUAcs = new BLGroupUAcs();
            // BLコードアクセスクラス
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            // 発注点設定マスタワーククラス
            this._orderPointStList = new List<OrderPointSt>();
        }
        #endregion

        #region ■ Private Member
        #region ◆ Interface member
        // 実行ボタン状態取得プロパティ
        private bool _canUpdate = false;
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = false;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = false;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = false;
        // 前回設定コード
        private string _patterNo;
        #endregion ◆ Interface member

        // 拠点コード
        private string _enterpriseCode = "";
        // 発注点設定処理アクセスクラス
        private OrderPointStSimulationAcs _orderPointStSimulationAcs;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // 発注点設定マスタメンテナンスアクセス
        private OrderPointStAcs _orderPointStAcs;
        // ガイドアクセスクラス
        // 倉庫マスタアクセスクラス
        private WarehouseAcs _wareHouseAcs;
        // 仕入先マスタアクセスクラス
        private SupplierAcs _supplierAcs;
        // メーカーマスタアクセスクラス
        private MakerAcs _makerAcs;
        // ユーザーガイドアクセスクラス
        private UserGuideAcs _userGuideAcs;
        // 商品中分類アクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs;
        // BLグループアクセスクラス
        private BLGroupUAcs _blGroupUAcs;
        // BLコードアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;
        // 発注点設定マスタワーククラス
        private List<OrderPointSt> _orderPointStList;
        // 設定コードのフォーカス移動かどうか
        private bool isPatterNoReaded = false;
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMHAT09101UA";
        // プログラムID
        private const string ct_PGID = "PMHAT09101U";
        // 帳票名称
        private const string ct_PrintName = "発注点設定処理";
        // 帳票キー	
        private const string ct_PrintKey = "0db9c72a-5463-49e0-b738-08780ca74f53";
        // 更新ボタンフラグ
        private bool _updateFlg = false;

        // 発注適用区分
        // ADD 2009/07/14
        private  Int32 _orderApplyDiv = 0;
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件
        #endregion

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// <summary> 実行ボタン状態取得プロパティ </summary>
        public bool CanUpdate
        {
            get { return this._canUpdate; }
        }

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
            // 抽出処理は無いので処理終了
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
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // 印刷ボタンを押して、シミュレーションが「印刷しない」場合、入力エラー
            //upd by liuxz on 2009/07/27 for PDFボタンを押して、シミュレーションが「印刷しない」場合、エラーメッセージ変更 start
            //if (this._updateFlg == false && (int)this.tComboEditor_Simulation.Value == 1)
            if ((int)this.tComboEditor_Simulation.Value == 1)
            //upd by liuxz on 2009/07/27 for PDFボタンを押して、シミュレーションが「印刷しない」場合、エラーメッセージ変更 end
            {
                this.tComboEditor_Simulation.Select();
                //upd by liuxz on 2009/07/27 for PDFボタンを押して、シミュレーションが「印刷しない」場合、エラーメッセージ変更 start
                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "選択出来ない区分です。", 0);
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "ＰＤＦ表示は選択出来ません。", 0);
                //upd by liuxz on 2009/07/27 for PDFボタンを押して、シミュレーションが「印刷しない」場合、エラーメッセージ変更 end
                return -1;
            }
            SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // 抽出条件クラス
            ExtrInfo_OrderPointStSimulationWorkTbl extrInfo = new ExtrInfo_OrderPointStSimulationWorkTbl();

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = extrInfo;

            // 帳票選択ガイド
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            // プレビューの場合
            if (printDialog.EnablePreview == 1)
            {
                // プレビュー画面を閉じる場合
                if (printInfo.status == -1)
                {
                    printInfo.status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
            }

            // 戻りステータス
            switch (printInfo.status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    break;
                default:
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "帳票レイアウトの取得に失敗しました。", 0);
                    break;
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
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;
            bool isSetCodeErr = false;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent, out isSetCodeErr))
            {
                // メッセージを表示
                if (isSetCodeErr)
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMessage, 0);
                }
                else
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                }

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

        #region ◎ 実行処理
        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 更新＋印刷処理を行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;
            this._updateFlg = true;

            //add by liuxz on 2009/07/27 for 確定ボタンのエラーチェック追加 start
            // 印刷しないと更新しない場合、エラーとする
            if (this.UpdateBeforeCheck() == false)
            {
                return status;
            }
            //add by liuxz on 2009/07/27 for 確定ボタンのエラーチェック追加 end

            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            try
            {
                // 印刷する場合
                if ((int)this.tComboEditor_Simulation.Value == 0)
                {
                    // 印刷処理
                    status = Print(ref parameter);

                    // 印刷完了処理
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // 更新する場合
                        if ((int)this.tComboEditor_Update.Value == 1)
                        {
                            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_ClassID,
                                "印刷が完了しました。\n在庫マスタを更新してもよろしいですか？", 0, MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                // 表示文字を設定
                                form.Title = "更新中";
                                form.Message = "現在、データを更新中です。";
                                // ダイアログ表示
                                form.Show();
                                SFCMN06002C printInfo = parameter as SFCMN06002C;
                                DataSet dataSet = printInfo.rdData as DataSet;
                                // 在庫マスタ更新処理
                                status = StockUpdate(dataSet, out errMsg);
                                // ダイアログを閉じる
                                form.Close();
                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
                                        break;
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        // 登録完了
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により削除されています。", 0);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により更新されています。", 0);
                                        break;
                                    default:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    // 更新する場合
                    if ((int)this.tComboEditor_Update.Value == 1)
                    {
                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_ClassID,
                            "在庫マスタを更新してもよろしいですか？", 0, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            // 表示文字を設定
                            form.Title = "抽出中";
                            form.Message = "現在、データを抽出中です。";
                            // ダイアログ表示
                            form.Show();
                            // 抽出条件クラス
                            ExtrInfo_OrderPointStSimulationWorkTbl paramWork = new ExtrInfo_OrderPointStSimulationWorkTbl();

                            // 画面→抽出条件クラス
                            status = this.SetExtraInfoFromScreen(paramWork);

                            // 発注点設定処理データ取得
                            status = this._orderPointStSimulationAcs.Search(paramWork, out errMsg);
                            // ダイアログを閉じる
                            form.Close();
                            // 戻りステータス
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                // 表示文字を設定
                                form.Title = "更新中";
                                form.Message = "現在、データを更新中です。";
                                // ダイアログ表示
                                form.Show();
                                DataSet dataSet = this._orderPointStSimulationAcs.DataSet;
                                // 在庫マスタ更新処理
                                status = StockUpdate(dataSet, out errMsg);
                                // ダイアログを閉じる
                                form.Close();
                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
                                        break;
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        // 登録完了
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により削除されています。", 0);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により更新されています。", 0);
                                        break;
                                    default:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                                        break;
                                }
                            }
                            else
                            {
                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
                                        break;
                                    default:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "帳票レイアウトの取得に失敗しました。", 0);
                                        break;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // ダイアログを閉じる
                form.Close();
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            this._updateFlg = false;
            return status;
        }
        #endregion

        #region ◎ 確定前のチェック処理
        //add by liuxz on 2009/07/27 for 確定ボタンのエラーチェック追加 start
        /// <summary>
        /// 確定前のチェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 実行前のチェック処理を行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.07.27</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            bool ret = true;

            // 印刷しないと更新しない場合 
            if ((int)this.tComboEditor_Simulation.Value == 1 && (int)this.tComboEditor_Update.Value == 0)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "確定は選択出来ません。", 0);
                this.tComboEditor_Simulation.Focus();
                ret = false;
            }

            return ret;
        }
        //add by liuxz on 2009/07/27 for 確定ボタンのエラーチェック追加 end
        #endregion ◎ 実行前のチェック処理

        #region ◎ 在庫マスタ更新処理
        /// <summary>
        /// 在庫マスタ更新処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: 在庫マスタ更新処理を行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private int StockUpdate(DataSet ds, out string errMsg)
        {
            int status = this._orderPointStSimulationAcs.StockUpdate(ds, this._orderPointStList, out errMsg);

            return status;
        }
        #endregion ◎ 在庫マスタ更新処理

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:起動パラメータを変更する場合はここで行う。
            this.Show();
            return;
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return ct_PrintName; }
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
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // PDFと確定の制御
                this._canPdf = false;
                this._canUpdate = false;
                ParentToolbarSettingEvent(this);

                // 画面項目の制御
                this.SetControlEnable();

                // 設定コード
                this.tNEdit_PatterNo.Clear();
                // 倉庫
                this.tEdit_WarehouseCode_St.Clear();
                this.tEdit_WarehouseCode_Ed.Clear();                
                // 仕入先
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();                
                // メーカー
                this.tNedit_GoodsMakerCd_St.Clear();
                this.tNedit_GoodsMakerCd_Ed.Clear();                
                // 商品中分類
                this.tNedit_GoodsMGroup_St.Clear();
                this.tNedit_GoodsMGroup_Ed.Clear();                
                // グループコード
                this.tNedit_BLGloupCode_St.Clear();
                this.tNedit_BLGloupCode_Ed.Clear();                
                // BLコード
                this.tNedit_BLGoodsCode_St.Clear();
                this.tNedit_BLGoodsCode_Ed.Clear();
                // 集計方法
                this.tComboEditor_SumMethod.SelectedIndex = 0;
                // シュミレーション
                this.tComboEditor_Simulation.SelectedIndex = 0;                
                // 出力順
                this.tComboEditor_OutputDiv.SelectedIndex = 0;
                // 在庫マスタ更新
                this.tComboEditor_Update.SelectedIndex = 0;
                // 管理区分１
                foreach (int index in this.clb_ManagerDiv1.CheckedIndices)
                {
                    this.clb_ManagerDiv1.SetItemChecked(index, false);
                }
                this.clb_ManagerDiv1.SelectedItems.Clear();
                // 管理区分２
                foreach (int index in this.clb_ManagerDiv2.CheckedIndices)
                {
                    this.clb_ManagerDiv2.SetItemChecked(index, false);
                }
                this.clb_ManagerDiv2.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region ◎ 画面項目の制御処理
        /// <summary>
        /// 画面項目の制御処理
        /// </summary>
        private void SetControlEnable()
        {
            // 倉庫コード
            this.tEdit_WarehouseCode_St.ReadOnly = true;
            this.tEdit_WarehouseCode_Ed.ReadOnly = true;
            this.ub_St_WarehouseCodeGuide.Enabled = false;
            this.ub_Ed_WarehouseCodeGuide.Enabled = false;
            // 仕入先コード 
            this.tNedit_SupplierCd_St.ReadOnly = true;
            this.tNedit_SupplierCd_Ed.ReadOnly = true;
            this.ub_St_SupplierCodeGuide.Enabled = false;
            this.ub_Ed_SupplierCodeGuide.Enabled = false;
            // メーカー
            this.tNedit_GoodsMakerCd_St.ReadOnly = true;
            this.tNedit_GoodsMakerCd_Ed.ReadOnly = true;
            this.ub_St_GoodsMakerCdGuide.Enabled = false;
            this.ub_Ed_GoodsMakerCdGuide.Enabled = false;
            // 中分類
            this.tNedit_GoodsMGroup_St.ReadOnly = true;
            this.tNedit_GoodsMGroup_Ed.ReadOnly = true;
            this.ub_St_GoodsMGroupGuide.Enabled = false;
            this.ub_Ed_GoodsMGroupGuide.Enabled = false;
            // グループ
            this.tNedit_BLGloupCode_St.ReadOnly = true;
            this.tNedit_BLGloupCode_Ed.ReadOnly = true;
            this.ub_St_BLGloupCodeGuide.Enabled = false;
            this.ub_Ed_BLGloupCodeGuide.Enabled = false;
            // BLコード
            this.tNedit_BLGoodsCode_St.ReadOnly = true;
            this.tNedit_BLGoodsCode_Ed.ReadOnly = true;
            this.ub_St_BLGoodsCodeGuide.Enabled = false;
            this.ub_Ed_BLGoodsCodeGuide.Enabled = false;
        }
        #endregion ◎ 画面項目の制御処理

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
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
        /// <param name="isSetCodeErr">設定コード存在かどうか</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent, out bool isSetCodeErr)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります。";
            
            errMessage = "";
            errComponent = null;
            isSetCodeErr = false;

            // 設定コード
            if (String.IsNullOrEmpty(this.tNEdit_PatterNo.DataText.TrimEnd()))
            {
                errMessage = "設定コードを入力してください。";
                errComponent = this.tNEdit_PatterNo;
                status = false;
            }
            else
            {
                if (this._orderPointStList.Count > 0)
                {
                    OrderPointSt orderPointSt = (OrderPointSt)this._orderPointStList[0];
                    if (orderPointSt.PatterNo != this.tNEdit_PatterNo.GetInt() || isPatterNoReaded == false)
                    {
                        // 発注点の存在チェック処理
                        if (this.SetCodeCheck() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            errMessage = "該当するデータが存在しません。";
                            errComponent = this.tNEdit_PatterNo;
                            isSetCodeErr = true;
                            status = false;
                        }
                        // 画面データの設定処理
                        this.SetScreenDataInfo(this._orderPointStList);
                    }
                }
                else
                {
                    // 発注点の存在チェック処理
                    if (this.SetCodeCheck() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        errMessage = "該当するデータが存在しません。";
                        errComponent = this.tNEdit_PatterNo;
                        isSetCodeErr = true;
                        status = false;
                    }
                    if (isPatterNoReaded == false)
                    {
                        // 画面データの設定処理
                        this.SetScreenDataInfo(this._orderPointStList);
                    }
                }
            }
            // 倉庫チェック
            if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
            {
                errMessage = string.Format("倉庫{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // 仕入先チェック
            else if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // メーカーチェック
            else if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            {
                errMessage = string.Format("メーカーコード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 商品中分類チェック
            else if ((this.tNedit_GoodsMGroup_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()))
            {
                errMessage = string.Format("中分類{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // グループコードチェック
            else if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()))
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // BLコードチェック
            else if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            {
                errMessage = string.Format("BLコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }

            //del by liuxz on 2009/07/27 for PDFボタンを押して、シミュレーションが「印刷しない」場合、エラーメッセージ変更 start
            ///*------DEL 2009/07/14 PVCS341----->>>>>
            //// 印刷しないと更新しない場合 
            //// if ((int)this.tComboEditor_Simulation.Value == 1 && (int)this.tComboEditor_Update.Value == 0)
            // ------DEL 2009/07/14 PVCS341-----<<<<<*/
            //// 印刷しない場合
            //if ((int)this.tComboEditor_Simulation.Value == 1) // ADD 2009/07/14 PVCS341
            //{
            //    // errMessage = "選択出来ない区分です。"; // DEL 2009/07/14 PVCS341
            //    errMessage = "ＰＤＦ表示は選択出来ません。";
            //    errComponent = this.tComboEditor_Simulation;
            //    status = false;
            //}
            //del by liuxz on 2009/07/27 for PDFボタンを押して、シミュレーションが「印刷しない」場合、エラーメッセージ変更 end
            return status;
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <param name="paramWork">抽出条件クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(ExtrInfo_OrderPointStSimulationWorkTbl paramWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ADD 2009/07/14
                // 発注適用区分
                paramWork.OrderApplyDiv = this._orderApplyDiv;
                // 企業コード
                paramWork.EnterpriseCode = this._enterpriseCode;
                // 設定コード
                paramWork.SettingCode = this.tNEdit_PatterNo.GetInt();
                // 倉庫
                // 開始
                if (this.tEdit_WarehouseCode_St.Text.TrimEnd() == "")
                {
                    paramWork.St_WarehouseCode = "";
                }
                else
                {
                    paramWork.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text.TrimEnd().PadLeft(4, '0');
                }
                // 終了
                if (this.tEdit_WarehouseCode_Ed.Text.TrimEnd() == "")
                {
                    paramWork.Ed_WarehouseCode = "";
                }
                else
                {
                    paramWork.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text.TrimEnd().PadLeft(4, '0');
                }
                // 仕入先
                paramWork.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                paramWork.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
                // メーカーコード
                paramWork.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                paramWork.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // 商品中分類
                paramWork.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                paramWork.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // グループコード
                paramWork.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                paramWork.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // BLコード
                paramWork.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                paramWork.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                // 集計方法
                paramWork.SumMethodCd = Convert.ToInt32(this.tComboEditor_SumMethod.Value);
                paramWork.SumMethodNm = this.tComboEditor_SumMethod.Text;
                // 出力順
                paramWork.OutPutDiv = Convert.ToInt32(this.tComboEditor_OutputDiv.Value);
                // 在庫出荷対象開始月
                paramWork.StckShipMonthSt = (this._orderPointStList[0] as OrderPointSt).StckShipMonthSt;
                // 在庫出荷対象終了月
                paramWork.StckShipMonthEd = (this._orderPointStList[0] as OrderPointSt).StckShipMonthEd;
                // 在庫登録日
                paramWork.StockCreateDate = (this._orderPointStList[0] as OrderPointSt).StockCreateDate;
                // 管理区分１
                string[] managerDiv1 = new string[this.clb_ManagerDiv1.CheckedItems.Count];
                for (int i = 0; i < this.clb_ManagerDiv1.CheckedItems.Count; i++)
                {
                    object checkedItem = this.clb_ManagerDiv1.CheckedItems[i];
                    int itemIndex = this.clb_ManagerDiv1.Items.IndexOf(checkedItem);
                    managerDiv1[i] = itemIndex.ToString();
                }
                paramWork.ManagementDivide1 = managerDiv1;
                // 管理区分２
                string[] managerDiv2 = new string[this.clb_ManagerDiv2.CheckedItems.Count];
                for (int i = 0; i < this.clb_ManagerDiv2.CheckedItems.Count; i++)
                {
                    object checkedItem = this.clb_ManagerDiv2.CheckedItems[i];
                    int itemIndex = this.clb_ManagerDiv2.Items.IndexOf(checkedItem);
                    managerDiv2[i] = itemIndex.ToString();
                }
                paramWork.ManagementDivide2 = managerDiv2;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◎ 発注点の存在チェック処理
        /// <summary>
        /// 発注点の存在チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 発注点の存在チェック処理を行います。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int SetCodeCheck()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            List<OrderPointSt> retList = null;
            try
            {
                if (!String.IsNullOrEmpty(this.tNEdit_PatterNo.DataText.TrimEnd()))
                {
                    if (!IsNumber(this.tNEdit_PatterNo.DataText.TrimEnd()))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    else
                    {
                        int patterNo = this.tNEdit_PatterNo.GetInt();
                        this._orderPointStAcs.Search(out retList, patterNo, this._enterpriseCode);
                        if (retList.Count > 0)
                        {
                            List<OrderPointSt> list = new List<OrderPointSt>();
                            foreach (OrderPointSt orderPointSt in retList)
                            {
                                // 論理削除のデータをチェックする
                                if (orderPointSt.LogicalDeleteCode == 1)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                    return status;
                                }
                                else
                                {
                                    // 発注点処理更新フラグ
                                    orderPointSt.OrderPProcUpdFlg = 1;
                                    // ADD 2009/07/14
                                    this._orderApplyDiv = orderPointSt.OrderApplyDiv;
                                    list.Add(orderPointSt);
                                }
                            }
                            this._orderPointStList = list;

                            // 前回設定コード
                            this._patterNo = this.tNEdit_PatterNo.Text;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                    }
                }
                else
                {
                    // 前回設定コード
                    this._patterNo = string.Empty;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 発注点の存在チェック処理

        #region ◎ 画面データの設定処理
        /// <summary>
        /// 画面データの設定処理
        /// </summary>
        /// <param name="orderPointStWorkList">データリスト</param>
        /// <remarks>
        /// <br>Note        : 画面データの設定処理を行います。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int SetScreenDataInfo(List<OrderPointSt> orderPointStWorkList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                OrderPointSt orderPointSt = orderPointStWorkList[0] as OrderPointSt;

                // 画面制御
                this.SetControlEnable();

                // 倉庫
                if (string.IsNullOrEmpty(orderPointSt.WarehouseCode.TrimEnd()) || Convert.ToInt32(orderPointSt.WarehouseCode.TrimEnd()) == 0)
                {
                    this.tEdit_WarehouseCode_St.Text = string.Empty;
                    this.tEdit_WarehouseCode_Ed.Text = string.Empty;
                    this.tEdit_WarehouseCode_St.ReadOnly = false;
                    this.tEdit_WarehouseCode_Ed.ReadOnly = false;
                    this.ub_St_WarehouseCodeGuide.Enabled = true;
                    this.ub_Ed_WarehouseCodeGuide.Enabled = true;
                }
                else
                {
                    this.tEdit_WarehouseCode_St.Text = orderPointSt.WarehouseCode;
                    this.tEdit_WarehouseCode_Ed.Text = orderPointSt.WarehouseCode;
                }
                // 仕入先
                this.tNedit_SupplierCd_St.SetInt(orderPointSt.SupplierCd);
                this.tNedit_SupplierCd_Ed.SetInt(orderPointSt.SupplierCd);
                if (orderPointSt.SupplierCd == 0)
                {
                    this.tNedit_SupplierCd_St.ReadOnly = false;
                    this.tNedit_SupplierCd_Ed.ReadOnly = false;
                    this.ub_St_SupplierCodeGuide.Enabled = true;
                    this.ub_Ed_SupplierCodeGuide.Enabled = true;
                }
                // メーカー
                this.tNedit_GoodsMakerCd_St.SetInt(orderPointSt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.SetInt(orderPointSt.GoodsMakerCd);
                if (orderPointSt.GoodsMakerCd == 0)
                {
                    this.tNedit_GoodsMakerCd_St.ReadOnly = false;
                    this.tNedit_GoodsMakerCd_Ed.ReadOnly = false;
                    this.ub_St_GoodsMakerCdGuide.Enabled = true;
                    this.ub_Ed_GoodsMakerCdGuide.Enabled = true;
                }
                // 商品中分類
                this.tNedit_GoodsMGroup_St.SetInt(orderPointSt.GoodsMGroup);
                this.tNedit_GoodsMGroup_Ed.SetInt(orderPointSt.GoodsMGroup);
                if (orderPointSt.GoodsMGroup == 0)
                {
                    this.tNedit_GoodsMGroup_St.ReadOnly = false;
                    this.tNedit_GoodsMGroup_Ed.ReadOnly = false;
                    this.ub_St_GoodsMGroupGuide.Enabled = true;
                    this.ub_Ed_GoodsMGroupGuide.Enabled = true;
                }
                // グループコード
                this.tNedit_BLGloupCode_St.SetInt(orderPointSt.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.SetInt(orderPointSt.BLGroupCode);
                if (orderPointSt.BLGroupCode == 0)
                {
                    this.tNedit_BLGloupCode_St.ReadOnly = false;
                    this.tNedit_BLGloupCode_Ed.ReadOnly = false;
                    this.ub_St_BLGloupCodeGuide.Enabled = true;
                    this.ub_Ed_BLGloupCodeGuide.Enabled = true;
                }
                // BLコード
                this.tNedit_BLGoodsCode_St.SetInt(orderPointSt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.SetInt(orderPointSt.BLGoodsCode);
                if (orderPointSt.BLGoodsCode == 0)
                {
                    this.tNedit_BLGoodsCode_St.ReadOnly = false;
                    this.tNedit_BLGoodsCode_Ed.ReadOnly = false;
                    this.ub_St_BLGoodsCodeGuide.Enabled = true;
                    this.ub_Ed_BLGoodsCodeGuide.Enabled = true;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 画面データの設定処理

        #region ◎ 数字のチェック処理
        /// <summary>
        /// 数字のチェック処理
        /// </summary>
        /// <param name="s">文字列</param>
        /// <remarks>
        /// <br>Note		: 数字のチェック処理を行い</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.06.02</br>
        /// </remarks>
        private static bool IsNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion ◎ 数字のチェック処理

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
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
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
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
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

        #region ◆ エラーメッセージ表示
        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMZAI02020UA
        #region ◎ PMZAI02020UA_Load Event
        /// <summary>
        /// PMHAT09101UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        /// 
        private void PMHAT09101UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // コンボボックスの初期化
            this.InitComboBox();

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }
        #endregion

        /// <summary>
        /// コンボボックスの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note		: コンボボックスの初期化を行う</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        /// 
        private void InitComboBox()
        {
            Infragistics.Win.ValueListItem listItem = new Infragistics.Win.ValueListItem();
            // 集計方法
            // 取寄せ分を含む
            listItem.DataValue = 0;
            listItem.DisplayText = "取寄せ分を含む";
            this.tComboEditor_SumMethod.Items.Add(listItem);
            // 在庫分のみ
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "在庫分のみ";
            this.tComboEditor_SumMethod.Items.Add(listItem);

            // シュミレーション
            // 印刷する
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 0;
            listItem.DisplayText = "印刷する";
            this.tComboEditor_Simulation.Items.Add(listItem);
            // 印刷しない
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "印刷しない";
            this.tComboEditor_Simulation.Items.Add(listItem);

            // 出力順
            // 品番順
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 0;
            listItem.DisplayText = "品番順";
            this.tComboEditor_OutputDiv.Items.Add(listItem);
            // 棚番順
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "棚番順";
            this.tComboEditor_OutputDiv.Items.Add(listItem);
            // メーカー・品番順
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 2;
            listItem.DisplayText = "メーカー・品番順";
            this.tComboEditor_OutputDiv.Items.Add(listItem);
            // メーカー・棚番順
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 3;
            listItem.DisplayText = "メーカー・棚番順";
            this.tComboEditor_OutputDiv.Items.Add(listItem);

            // 在庫マスタ更新
            // 更新しない
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 0;
            listItem.DisplayText = "更新しない";
            this.tComboEditor_Update.Items.Add(listItem);
            // 更新する
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "更新する";
            this.tComboEditor_Update.Items.Add(listItem);
        }

        #region ◎ 設定コードのローストフォーカスイベント
        /// <summary>
        /// 設定コードのローストフォーカスイベント
        /// </summary>
        private bool ub_PatterNo_Leave()
        {
            Int32 prePatterNo = -1;
            if (!string.IsNullOrEmpty(this._patterNo) && IsNumber(this._patterNo))
            {
                prePatterNo = Convert.ToInt32(this._patterNo);
            }
            if (this.tNEdit_PatterNo.DataText.TrimEnd() == "0" ||
                this.tNEdit_PatterNo.DataText.TrimEnd() == "00" ||
                this.tNEdit_PatterNo.DataText.TrimEnd() == "000")
            {
                string errMsg = string.Empty;
                // 画面の初期化処理
                this.InitializeScreen(out errMsg);
                return false;
            }

            if (prePatterNo == -1 || this.tNEdit_PatterNo.GetInt() != prePatterNo)
            {
                // 発注点設定コードの存在チェック処理
                if (this.SetCodeCheck() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 前回設定コード
                    this.tNEdit_PatterNo.Text = this._patterNo;
                    this.tNEdit_PatterNo.Select();
                    // メッセージを表示
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータが存在しません。", 0);
                    return false;
                }
                if (string.IsNullOrEmpty(this.tNEdit_PatterNo.Text))
                {
                    string errMsg = string.Empty;
                    // 画面の初期化処理
                    this.InitializeScreen(out errMsg);
                }
                else
                {
                    // 画面データの設定処理
                    this.SetScreenDataInfo(this._orderPointStList);

                    // PDFと確定の制御
                    this._canPdf = true;
                    this._canUpdate = true;
                    ParentToolbarSettingEvent(this);
                }
            }

            return true;
        }
        #endregion

        #endregion ◆ PMZAI02020UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
        #endregion

        #region ◎ GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }
        #endregion
        #endregion ◆ ueb_MainExplorerBar Event

        #region ◎ 開始倉庫ガイドボタンクリックイベント
        /// <summary>
        /// 開始倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // ガイド起動
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = wareHouse.WarehouseCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了倉庫ガイドボタンクリックイベント
        /// <summary>
        /// 終了倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // ガイド起動
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = wareHouse.WarehouseCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始仕入先ガイドボタンクリックイベント
        /// <summary>
        /// 開始仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了仕入先ガイドボタンクリックイベント
        /// <summary>
        /// 終了仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始メーカーガイドボタンクリックイベント
        /// <summary>
        /// 開始メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了メーカーガイドボタンクリックイベント
        /// <summary>
        /// 終了メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;
            
            // ガイド起動
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始商品中分類ガイドボタンクリックイベント
        /// <summary>
        /// 開始商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            GoodsGroupU goodgroupU;            
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了商品中分類ガイドボタンクリックイベント
        /// <summary>
        /// 終了商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            GoodsGroupU goodgroupU;
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始グループコードガイドボタンクリックイベント
        /// <summary>
        /// 開始グループコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了グループコードガイドボタンクリックイベント
        /// <summary>
        /// 終了グループコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始BLコードガイドボタンクリックイベント
        /// <summary>
        /// 開始BLコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了BLコードガイドボタンクリックイベント
        /// <summary>
        /// 終了BLコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            bool isMouseClick = true;
            Int32 patterNo = 0;

            // 設定コードのフォーカス移動処理
            if (e.PrevCtrl == this.tNEdit_PatterNo)
            {
                if (!string.IsNullOrEmpty(this._patterNo) && IsNumber(this._patterNo))
                {
                    patterNo = Convert.ToInt32(this._patterNo);
                }
                // 設定コードのローストフォーカスイベント
                if (!this.ub_PatterNo_Leave())
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                    return;
                }
                isPatterNoReaded = true;

                if (this.tNEdit_PatterNo.GetInt() != patterNo)
                {
                    // ほかの項目を初期化する
                    // 集計方法
                    this.tComboEditor_SumMethod.SelectedIndex = 0;
                    // シュミレーション
                    this.tComboEditor_Simulation.SelectedIndex = 0;
                    // 出力順
                    this.tComboEditor_OutputDiv.SelectedIndex = 0;
                    // 在庫マスタ更新
                    this.tComboEditor_Update.SelectedIndex = 0;
                    // 管理区分１
                    foreach (int index in this.clb_ManagerDiv1.CheckedIndices)
                    {
                        this.clb_ManagerDiv1.SetItemChecked(index, false);
                    }
                    // 管理区分２
                    foreach (int index in this.clb_ManagerDiv2.CheckedIndices)
                    {
                        this.clb_ManagerDiv2.SetItemChecked(index, false);
                    }
                }
            }

            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    isMouseClick = false;
                    if (e.PrevCtrl == this.tNEdit_PatterNo)
                    {
                        if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 設定コード→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 設定コード→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 設定コード→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 設定コード→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 設定コード→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 設定コード→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 設定コード→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 設定コード→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 設定コード→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 設定コード→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 設定コード→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 設定コード→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 設定コード→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 設定コード→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 設定コード→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 設定コード→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 設定コード→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 設定コード→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 設定コード→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 設定コード→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 設定コード→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 設定コード→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 設定コード→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 設定コード→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 設定コード→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 設定コード→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 設定コード→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 設定コード→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 設定コード→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 設定コード→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 設定コード→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 設定コード→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 設定コード→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // Lコード(終了)→集計方法
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // Lコード(終了)→集計方法
                        e.NextCtrl = this.tComboEditor_SumMethod;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SumMethod)
                    {
                        // 集計方法→シュミレーション
                        e.NextCtrl = this.tComboEditor_Simulation;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Simulation)
                    {
                        // シュミレーション→出力順
                        e.NextCtrl = this.tComboEditor_OutputDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_OutputDiv)
                    {
                        // 出力順→在庫マスタ更新
                        e.NextCtrl = this.tComboEditor_Update;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Update)
                    {
                        // 在庫マスタ更新→管理区分１
                        e.NextCtrl = this.clb_ManagerDiv1;
                    }
                    else if (e.PrevCtrl == this.clb_ManagerDiv1)
                    {
                        // 管理区分１→管理区分２
                        e.NextCtrl = this.clb_ManagerDiv2;
                    }
                    else if (e.PrevCtrl == this.clb_ManagerDiv2)
                    {
                        // 管理区分２→設定コード
                        e.NextCtrl = this.tNEdit_PatterNo;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    isMouseClick = false;
                    if (e.PrevCtrl == this.clb_ManagerDiv2)
                    {
                        // 管理区分２→管理区分１
                        e.NextCtrl = this.clb_ManagerDiv1;
                    }
                    else if (e.PrevCtrl == this.clb_ManagerDiv1)
                    {
                        // 管理区分１→在庫マスタ更新
                        e.NextCtrl = this.tComboEditor_Update;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Update)
                    {
                        // 在庫マスタ更新→出力順
                        e.NextCtrl = this.tComboEditor_OutputDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_OutputDiv)
                    {
                        // 出力順→シュミレーション
                        e.NextCtrl = this.tComboEditor_Simulation;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Simulation)
                    {
                        // シュミレーション→集計方法
                        e.NextCtrl = this.tComboEditor_SumMethod;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SumMethod)
                    {
                        if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // 集計方法→BLコード(終了)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 集計方法→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 集計方法→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 集計方法→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 集計方法→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 集計方法→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 集計方法→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // 集計方法→BLコード(開始)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 集計方法→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 集計方法→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 集計方法→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 集計方法→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 集計方法→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // 集計方法→グループコード(終了)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 集計方法→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 集計方法→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 集計方法→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 集計方法→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // 集計方法→グループコード(開始)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 集計方法→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 集計方法→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 集計方法→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // 集計方法→商品中分類(終了)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 集計方法→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 集計方法→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // 集計方法→商品中分類(開始)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 集計方法→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // 集計方法→メーカー(終了)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // 集計方法→メーカー(開始)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // 集計方法→仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // 集計方法→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // 集計方法→倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // 集計方法→倉庫(開始)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // 集計方法→設定コード
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        // 倉庫(開始)→設定コード
                        e.NextCtrl = this.tNEdit_PatterNo;
                    }
                    else if (e.PrevCtrl == this.tNEdit_PatterNo)
                    {
                        // 設定コード→管理区分２
                        e.NextCtrl = this.clb_ManagerDiv2;
                    }
                }
            }

            if (isMouseClick)
            {
                // 倉庫(開始)→設定コード
                if (e.NextCtrl == this.tEdit_WarehouseCode_St && this.tEdit_WarehouseCode_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // 倉庫(終了)→設定コード
                if (e.NextCtrl == this.tEdit_WarehouseCode_Ed && this.tEdit_WarehouseCode_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // 仕入先(開始)→設定コード
                if (e.NextCtrl == this.tNedit_SupplierCd_St && this.tNedit_SupplierCd_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // 仕入先(終了)→設定コード
                if (e.NextCtrl == this.tNedit_SupplierCd_Ed && this.tNedit_SupplierCd_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // メーカー(開始)→設定コード
                if (e.NextCtrl == this.tNedit_GoodsMakerCd_St && this.tNedit_GoodsMakerCd_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // メーカー(終了)→設定コード
                if (e.NextCtrl == this.tNedit_GoodsMakerCd_Ed && this.tNedit_GoodsMakerCd_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // 中分類(開始)→設定コード
                if (e.NextCtrl == this.tNedit_GoodsMGroup_St && this.tNedit_GoodsMGroup_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // 中分類(終了)→設定コード
                if (e.NextCtrl == this.tNedit_GoodsMGroup_Ed && this.tNedit_GoodsMGroup_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // グループ(開始)→設定コード
                if (e.NextCtrl == this.tNedit_BLGloupCode_St && this.tNedit_BLGloupCode_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // グループ(終了)→設定コード
                if (e.NextCtrl == this.tNedit_BLGloupCode_Ed && this.tNedit_BLGloupCode_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // BLコード(開始)→設定コード
                if (e.NextCtrl == this.tNedit_BLGoodsCode_St && this.tNedit_BLGoodsCode_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // BLコード(終了)→設定コード
                if (e.NextCtrl == this.tNedit_BLGoodsCode_Ed && this.tNedit_BLGoodsCode_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
            }
        }
        #endregion
        #endregion ■ Control Event

        #region ◆ Initialize_Timer
        #region ◎ Tick Event
        /// <summary>
        /// Tick Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コントロール初期化
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }
                
                // ガイドボタンのアイコン設定
                this.SetIconImage(this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                ParentToolbarSettingEvent(this);	// ツールバー設定イベント
            }
            finally
            {
                // 初期フォーカス
                this.tNEdit_PatterNo.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion ◆ Initialize_Timer

        #region ■ フォーカスアウト
        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 設定コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNEdit_PatterNo_AfterExitEditMode(object sender, EventArgs e)
        {
            if (0 == this.tNEdit_PatterNo.GetInt())
            {
                this.tNEdit_PatterNo.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 倉庫コード開始の値は数字ではない場合
            if (!IsNumber(this.tEdit_WarehouseCode_St.Text))
            {
                this.tEdit_WarehouseCode_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 倉庫コード終了の値は数字ではない場合
            if (!IsNumber(this.tEdit_WarehouseCode_Ed.Text))
            {
                this.tEdit_WarehouseCode_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 仕入先コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 仕入先コード開始の値は数字ではない場合
            if (0 == this.tNedit_SupplierCd_St.GetInt())
            {
                this.tNedit_SupplierCd_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 仕入先コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 仕入先コード終了の値は数字ではない場合
            if (0 == this.tNedit_SupplierCd_Ed.GetInt())
            {
                this.tNedit_SupplierCd_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーコード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_GoodsMakerCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // メーカーコード開始の値は数字ではない場合
            if (0 == this.tNedit_GoodsMakerCd_St.GetInt())
            {
                this.tNedit_GoodsMakerCd_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーコード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks>
        private void tNedit_GoodsMakerCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // メーカーコード終了の値は数字ではない場合
            if (0 == this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                this.tNedit_GoodsMakerCd_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 中分類コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 中分類コード開始の値は数字ではない場合
            if (0 == this.tNedit_GoodsMGroup_St.GetInt())
            {
                this.tNedit_GoodsMGroup_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 中分類コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 中分類コード終了の値は数字ではない場合
            if (0 == this.tNedit_GoodsMGroup_Ed.GetInt())
            {
                this.tNedit_GoodsMGroup_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グループコード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // グループコード開始の値は数字ではない場合
            if (0 == this.tNedit_BLGloupCode_St.GetInt())
            {
                this.tNedit_BLGloupCode_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グループコード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // グループコード終了の値は数字ではない場合
            if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
            {
                this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : BLコード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // BLコード開始の値は数字ではない場合
            if (0 == this.tNedit_BLGoodsCode_St.GetInt())
            {
                this.tNedit_BLGoodsCode_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : BLコード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // BLコード終了の値は数字ではない場合
            if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// チェックリストボックスフォーカスEnter時、選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : チェックリストボックスフォーカスEnterに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void CheckedListBox_Enter(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                // 選択状態
                ((ListBox)sender).SetSelected(0, true);
            }
        }

        /// <summary>
        /// チェックリストボックスフォーカスLeave時、選択解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : チェックリストボックスフォーカスLeaveに発生します。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void CheckedListBox_Leave(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox listBox = (ListBox)sender;

                // 選択状態解除
                if (listBox.SelectedItem != null)
                {
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        #endregion
    }
}
