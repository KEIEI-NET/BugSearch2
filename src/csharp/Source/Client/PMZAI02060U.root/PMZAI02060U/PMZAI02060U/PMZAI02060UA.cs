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
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 委託在庫補充処理UIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 委託在庫補充処理UIフォームクラス</br>
	/// <br>Programmer : 30414 忍 幸史</br>
	/// <br>Date       : 2008/11/12</br>
    /// <br>Update Note: 2009.02.02 30452 上野 俊治</br>
    /// <br>            ・排他制御処理追加</br>
    /// <br>Update Note: 2009.11.26 30452 工藤 恵優</br>
    /// <br>            ・MANTIS対応[14685]：月次更新後の在庫データの更新は不可</br>
    /// </remarks>
	public partial class PMZAI02060UA : Form,
                                        IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                        IPrintConditionInpTypeUpdate,
                                        IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Private Const

        /// <summary> クラスID </summary>
        private const string ct_ClassID = "PMZAI02060UA";
        /// <summary> プログラムID </summary>
        private const string ct_PGID = "PMZAI02060U";
        /// <summary> 帳票名称 </summary>
        private const string ct_PrintName = "委託在庫補充一覧表";
        /// <summary> 帳票キー </summary>
        private const string ct_PrintKey = "0c38d05b-a580-4548-b794-25cbfcbf2070";

        #endregion ■ Private Const


        #region ■ Private Members

        private bool _canExtract = false;
        private bool _canPdf = true;
        private bool _canPrint = false;
        private bool _canUpdate = true;
        private bool _visibledExtractButton = false;
        private bool _visibledPdfButton = true;
        private bool _visibledPrintButton = false;

        private bool _updateFlg;
        private DataView _dataView;

        private string _enterpriseCode;

        private DateGetAcs _dateGetAcs;
        private WarehouseAcs _warehouseAcs;
        private MakerAcs _makerAcs;
        private TrustStockOrderAcs _trustStockOrderAcs;

        #endregion ■ Private Members


        # region ■ Constractor
        /// <summary>
        /// 委託在庫補充処理UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 委託在庫補充処理UIフォームクラスコンストラクタ</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
		public PMZAI02060UA()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();
            this._warehouseAcs = new WarehouseAcs();
            this._makerAcs = new MakerAcs();
            this._trustStockOrderAcs = new TrustStockOrderAcs();
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
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            if ((int)this.tComboEditor_PrintAll.Value == 1)
            {
                // 一覧表印刷をしない場合
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "対象商品が存在しません。", 0);
                return (0);
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            printInfo.enterpriseCode = this._enterpriseCode;	// 企業コード
            printInfo.kidopgid = ct_PGID;				        // 起動PGID
            printInfo.key = ct_PrintKey;			            // PDF出力履歴用
            printInfo.prpnm = ct_PrintName;			            // PDF出力履歴用

            // 抽出条件クラス
            TrustStockOrderCndtn extrInfo = new TrustStockOrderCndtn();

            // 抽出条件設定処理(画面→抽出条件)
            SetExtrInfo(ref extrInfo);

            // 抽出条件の設定
            printInfo.PrintPaperSetCd = 0;
            printInfo.jyoken = extrInfo;

            // 更新後の場合、既にデータを取得済みなので再検索を行わない
            if (this._updateFlg == true)
            {
                printInfo.rdData = this._dataView;
            }
            else
            {
                printInfo.rdData = null;
            }

            printDialog.PrintInfo = printInfo;
            
            // 帳票選択ガイド
            printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "対象商品が存在しません。", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行います。(入力チェックなど)</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            string errMessage = "";
            Control errComponent = null;

            this._updateFlg = false;

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
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:起動パラメータを変更する場合はここで行う。
            this.Show();
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

        #endregion ■ IPrintConditionInpType メンバ


        #region ■ IPrintConditionInpTypePdfCareer メンバ

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

        #endregion ■ IPrintConditionInpTypePdfCareer メンバ


        #region ■ IPrintConditionInpTypeUpdate メンバ

        /// <summary> 実行ボタン状態取得プロパティ </summary>
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
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            // 更新処理
            if ((int)this.tComboEditor_StockUpdate.Value == 0)
            {
                // ADD 2009/11/26 MANTIS対応[14685]：月次更新後の在庫データの更新は不可 ---------->>>>>
                // TODO:月次更新後であれば在庫データの更新は行えない
                if (!MAKHN09280UA.CanWrite(DateTime.Now)) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                // ADD 2009/11/26 MANTIS対応[14685]：月次更新後の在庫データの更新は不可 ----------<<<<<

                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            ct_ClassID,
                                            "更新してもよろしいですか？",
                                            0,
                                            MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                List<TrustStockResult> trustStockResultList;

                // データ検索
                int status = SearchTrustStockOrder(out trustStockResultList);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "対象商品が存在しません。", status);
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    return (status);
                }

                // 在庫マスタ更新
                status = this._trustStockOrderAcs.WriteStock(trustStockResultList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            string errMsg;
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                errMsg = "既に他端末により削除されています。";
                            }
                            else
                            {
                                errMsg = "既に他端末により更新されています。";
                            }

                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, status);
                            return (status);
                        }
                    // --- ADD 2009/02/02 -------------------------------->>>>>
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            string errMsg;
                            errMsg = "シェアチェックエラー(企業ロック)です。" + "\r\n"
                                + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。";

                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, status);
                            return (status);
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            string errMsg;
                            errMsg = "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                                + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。";

                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, status);
                            return (status);
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            string errMsg;
                            errMsg = "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                                + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。";

                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, status);
                            return (status);
                        }
                    // --- ADD 2009/02/02 --------------------------------<<<<<
                    default:
                        {
                            MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "更新処理に失敗しました。", status);
                            return (status);
                        }
                }
                
                this._updateFlg = true;

                if ((int)this.tComboEditor_PrintAll.Value == 1)
                {
                    // 一覧表印刷をしない場合
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    return (status);
                }
            }

            // 印刷処理
            return Print(ref parameter);
        }

        #endregion ■ IPrintConditionInpTypeUpdate メンバ


        #region ■ Private Methods
        /// <summary>
        /// 画面情報初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報初期設定処理</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // コントロールサイズ設定
            SetControlSize();

            // アイコン設定
            this.WarehouseGuideSt_Button.ImageList = IconResourceManagement.ImageList16;
            this.WarehouseGuideSt_Button.Appearance.Image = (int)Size16_Index.STAR1;
            this.WarehouseGuideEd_Button.ImageList = IconResourceManagement.ImageList16;
            this.WarehouseGuideEd_Button.Appearance.Image = (int)Size16_Index.STAR1;
            this.MakerGuideSt_Button.ImageList = IconResourceManagement.ImageList16;
            this.MakerGuideSt_Button.Appearance.Image = (int)Size16_Index.STAR1;
            this.MakerGuideEd_Button.ImageList = IconResourceManagement.ImageList16;
            this.MakerGuideEd_Button.Appearance.Image = (int)Size16_Index.STAR1;

            // 補充更新(初期表示:しない)
            this.tComboEditor_StockUpdate.Items.Clear();
            this.tComboEditor_StockUpdate.Items.Add(0, "する");
            this.tComboEditor_StockUpdate.Items.Add(1, "しない");
            this.tComboEditor_StockUpdate.Value = 1;

            // 補充元在庫不足時(初期表示:未更新)
            this.tComboEditor_ReplenishLackStock.Items.Clear();
            this.tComboEditor_ReplenishLackStock.Items.Add(0, "未更新");
            this.tComboEditor_ReplenishLackStock.Items.Add(1, "無視して更新");
            this.tComboEditor_ReplenishLackStock.Items.Add(2, "ゼロまで更新");
            this.tComboEditor_ReplenishLackStock.Value = 0;

            // 補充元商品無し時(初期表示:未更新)
            this.tComboEditor_ReplenishNoneGoods.Items.Clear();
            this.tComboEditor_ReplenishNoneGoods.Items.Add(0, "未更新");
            this.tComboEditor_ReplenishNoneGoods.Items.Add(1, "無視して更新");
            this.tComboEditor_ReplenishNoneGoods.Value = 0;

            // 一覧表印刷(初期表示:しない)
            this.tComboEditor_PrintAll.Items.Clear();
            this.tComboEditor_PrintAll.Items.Add(0, "する");
            this.tComboEditor_PrintAll.Items.Add(1, "しない");
            this.tComboEditor_PrintAll.Value = 1;

            // 改頁(初期表示:しない)
            this.tComboEditor_NewPage.Items.Clear();
            this.tComboEditor_NewPage.Items.Add(0, "しない");
            this.tComboEditor_NewPage.Items.Add(1, "メーカー");
            this.tComboEditor_NewPage.Value = 0;
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールサイズ設定処理</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_WarehouseCode_St.Size = new Size(44, 24);
            this.tEdit_WarehouseCode_Ed.Size = new Size(44, 24);
            this.tNedit_GoodsMakerCd_St.Size = new Size(44, 24);
            this.tNedit_GoodsMakerCd_Ed.Size = new Size(44, 24);
            this.tEdit_GoodsNo_St.Size = new Size(203, 24);
            this.tEdit_GoodsNo_Ed.Size = new Size(203, 24);
        }

        /// <summary>
        /// 抽出条件設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件設定処理</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void SetExtrInfo(ref TrustStockOrderCndtn trustStockOrderCndtn)
        {
            // 企業コード
            trustStockOrderCndtn.EnterpriseCode = this._enterpriseCode;
            // 倉庫コード(開始)
            trustStockOrderCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.Trim();
            // 倉庫コード(終了)
            trustStockOrderCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.Trim();
            // メーカーコード(開始)
            trustStockOrderCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
            // メーカーコード(終了)
            trustStockOrderCndtn.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
            // 品番(開始)
            trustStockOrderCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.DataText.Trim();
            // 品番(終了)
            trustStockOrderCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.DataText.Trim();
            // 補充元在庫不足時
            if (this.tComboEditor_ReplenishLackStock.Value != null)
            {
                trustStockOrderCndtn.ReplenishLackStock = (int)this.tComboEditor_ReplenishLackStock.Value;
            }
            // 補充元商品無し時
            if (this.tComboEditor_ReplenishNoneGoods.Value != null)
            {
                trustStockOrderCndtn.ReplenishNoneGoods = (int)this.tComboEditor_ReplenishNoneGoods.Value;
            }
            // 補充更新
            if (this.tComboEditor_StockUpdate.Value != null)
            {
                trustStockOrderCndtn.StockUpdate = (int)this.tComboEditor_StockUpdate.Value;
            }
            // 一覧表印刷
            if (this.tComboEditor_PrintAll.Value != null)
            {
                trustStockOrderCndtn.PrintAll = (int)this.tComboEditor_PrintAll.Value;
            }
            // 改頁
            if (this.tComboEditor_NewPage.Value != null)
            {
                trustStockOrderCndtn.NewPage = (int)this.tComboEditor_NewPage.Value;
            }
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コントロール</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: 入力内容のチェック処理を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            // 補充更新
            if (this.tComboEditor_StockUpdate.Value == null)
            {
                errMessage = "補充更新を選択してください。";
                errComponent = this.tComboEditor_StockUpdate;
                return (false);
            }
            
            // 補充元在庫不足時
            if (this.tComboEditor_ReplenishLackStock.Value == null)
            {
                errMessage = "補充元在庫不足時を選択してください。";
                errComponent = this.tComboEditor_ReplenishLackStock;
                return (false);
            }

            // 補充元商品無し時
            if (this.tComboEditor_ReplenishNoneGoods.Value == null)
            {
                errMessage = "補充元商品無し時を選択してください。";
                errComponent = this.tComboEditor_ReplenishNoneGoods;
                return (false);
            }

            // 一覧表印刷
            if (this.tComboEditor_PrintAll.Value == null)
            {
                errMessage = "一覧表印刷を選択してください。";
                errComponent = this.tComboEditor_PrintAll;
                return (false);
            }

            // 改頁
            if (this.tComboEditor_NewPage.Value == null)
            {
                errMessage = "改頁を選択してください。";
                errComponent = this.tComboEditor_NewPage;
                return (false);
            }

            if (((int)this.tComboEditor_StockUpdate.Value == 1) && ((int)this.tComboEditor_PrintAll.Value == 1))
            {
                errMessage = "選択出来ない区分です。";
                errComponent = this.tComboEditor_StockUpdate;
                return (false);
            }

            // 委託倉庫
            if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
            {
                string warehouseCodeSt = this.tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0');
                string warehouseCodeEd = this.tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0');

                if (warehouseCodeSt.CompareTo(warehouseCodeEd) > 0)
                {
                    errMessage = "委託倉庫の範囲指定が不正です。";
                    errComponent = this.tEdit_WarehouseCode_St;
                    return (false);
                }
            }

            // メーカー
            if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                if (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
                {
                    errMessage = "メーカーの範囲指定が不正です。";
                    errComponent = this.tNedit_GoodsMakerCd_St;
                    return (false);
                }
            }

            // 品番
            if ((this.tEdit_GoodsNo_St.DataText.Trim() != "") && (this.tEdit_GoodsNo_Ed.DataText.Trim() != ""))
            {
                string goodsNoSt = this.tEdit_GoodsNo_St.DataText.Trim();
                string goodsNoEd = this.tEdit_GoodsNo_Ed.DataText.Trim();

                if (goodsNoSt.CompareTo(goodsNoEd) > 0)
                {
                    errMessage = "品番の範囲指定が不正です。";
                    errComponent = this.tEdit_GoodsNo_St;
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// 委託在庫補充処理データ検索処理
        /// </summary>
        /// <param name="trustStockResultList">委託在庫補充処理データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 委託在庫補充処理データを検索し、バッファに保持します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private int SearchTrustStockOrder(out List<TrustStockResult> trustStockResultList)
        {
            DataTable dataTable;
            trustStockResultList = new List<TrustStockResult>();

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出条件設定処理(画面→抽出条件)
            TrustStockOrderCndtn extrInfo = new TrustStockOrderCndtn();
            SetExtrInfo(ref extrInfo);

            string errMsg;
            
            // データ検索
            status = this._trustStockOrderAcs.Search(extrInfo, out dataTable, out trustStockResultList, out errMsg);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ソート文字列を取得
                string strSort = PMZAI02068EA.MakeSortingOrderString();

                // 抽出結果テーブルから指定されたフィルタ・ソート条件でデータビューを作成
                DataView dv = new DataView(dataTable, "", strSort, DataViewRowState.CurrentRows);
                if (dv.Count > 0)
                {
                    // バッファに保持
                    this._dataView = dv;
                }
                // 該当データ無し
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    return (status);
                }
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                return (status);
            }

            return (status);
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
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

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
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

        #endregion ■ Private Methods


        #region ■ Control Events
        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームをロードした時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void PMZAI02060UA_Load(object sender, EventArgs e)
        {
            // 画面情報初期設定
            SetScreenInitialSetting();

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);

            // 初期フォーカス設定
            this.tComboEditor_StockUpdate.Focus();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンをクリックした時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            UltraButton uButton = (UltraButton)sender;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Warehouse warehouse;

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
                if (status == 0)
                {
                    if (uButton.Name == "WarehouseGuideSt_Button")
                    {
                        this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.Trim();

                        // フォーカス設定
                        this.tEdit_WarehouseCode_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.Trim();

                        // フォーカス設定
                        this.tNedit_GoodsMakerCd_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンをクリックした時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            UltraButton uButton = (UltraButton)sender;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (uButton.Name == "MakerGuideSt_Button")
                    {
                        this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);

                        // フォーカス設定
                        this.tNedit_GoodsMakerCd_Ed.Focus();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);

                        // フォーカス設定
                        this.tEdit_GoodsNo_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 一覧表印刷の値が変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void tComboEditor_PrintAll_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_PrintAll.Value == null)
            {
                return;
            }

            if ((int)this.tComboEditor_PrintAll.Value == 0)
            {
                // する
                this.tComboEditor_NewPage.Enabled = true;
            }
            else
            {
                // しない
                this.tComboEditor_NewPage.Value = 0;
                this.tComboEditor_NewPage.Enabled = false;
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 倉庫コード(開始)
                case "tEdit_WarehouseCode_St":
                    {
                        if ((e.ShiftKey == false) && 
                            ((e.Key == Keys.Tab) || (e.Key == Keys.Enter)))
                        {
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                            return;
                        }
                        break;
                    }
                // 倉庫コード(終了)
                case "tEdit_WarehouseCode_Ed":
                    {
                        if ((e.ShiftKey == false) &&
                            ((e.Key == Keys.Tab) || (e.Key == Keys.Enter)))
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                            return;
                        }
                        else if ((e.ShiftKey == true) && (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                            return;
                        }
                        break;
                    }
                // メーカーコード(開始)
                case "tNedit_GoodsMakerCd_St":
                    {
                        if ((e.ShiftKey == false) &&
                            ((e.Key == Keys.Tab) || (e.Key == Keys.Enter)))
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                            return;
                        }
                        else if ((e.ShiftKey == true) && (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                            return;
                        }
                        break;
                    }
                // メーカーコード(終了)
                case "tNedit_GoodsMakerCd_Ed":
                    {
                        if ((e.ShiftKey == false) &&
                            ((e.Key == Keys.Tab) || (e.Key == Keys.Enter)))
                        {
                            e.NextCtrl = this.tEdit_GoodsNo_St;
                            return;
                        }
                        else if ((e.ShiftKey == true) && (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                            return;
                        }
                        break;
                    }
                // 品番(開始)
                case "tEdit_GoodsNo_St":
                    {
                        if ((e.ShiftKey == true) && (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                            return;
                        }
                        else if ((e.ShiftKey == false) && (e.Key == Keys.Up))
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                            return;
                        }
                        break;
                    }
                // 一覧表印刷
                case "tComboEditor_PrintAll":
                    {
                        if ((e.ShiftKey == false) && (e.Key == Keys.Down))
                        {
                            if (this.tComboEditor_NewPage.Enabled == false)
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode_St;
                            }
                            return;
                        }
                        break;
                    }
                // 改頁
                case "tComboEditor_NewPage":
                    {
                        if ((e.ShiftKey == false) && (e.Key == Keys.Down))
                        {
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                            return;
                        }
                        break;
                    }
            }
        }
        #endregion ■ Control Events

        private void uebMainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "ExtractConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        private void uebMainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "ExtractConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }
    }
}