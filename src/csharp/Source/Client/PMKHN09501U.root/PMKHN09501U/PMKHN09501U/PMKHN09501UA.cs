//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品不可設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/29  修正内容 : PVCS#299 画面のモード表示 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/10  修正内容 : PVCS#327 クリア処理後のモード変更 
//                                  PVCS#328 売上伝票番号の入力不正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 返品不可設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品不可設定のフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.20</br>
    /// </remarks>
    public partial class PMKHN09501UA : Form
    {
        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region ■Const Members
        private const string PGID = "PMKHN09500U.EXE(PMKHN09501UA)";
        private const string MARK_1 = "/";
        private const string MARK_2 = "";
        private const string MARK_3 = ":";
        private const int MAXCOUNT = 99;
        private const int COLUMN_COUNT = 6;                    // 列数
        //private const int ROW_COUNT = 20;                       // 行数
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private ControlScreenSkin _controlScreenSkin;
        private ImageList _imageList16 = null;
        private PMKHN09501UB _goodsNotReturnInput;
        private GoodsNotReturnAcs _goodsNotReturnAcs;
        private GoodsNotReturnDataSet _dataSet;
        private GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable _goodsNotReturnDetailDataTable;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private Control _prevControl = null;
        private SecInfoAcs _secInfoAcs = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private string salesSlipNumberTemp = string.Empty;
        ArrayList goodsNotReturnList = null;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 返品不可設定フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 返品不可設定のフォームクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        public PMKHN09501UA()
        {
            InitializeComponent();
            // 変数初期化
            _goodsNotReturnInput = new PMKHN09501UB(this);
            this._goodsNotReturnAcs = GoodsNotReturnAcs.GetInstance();
            this._controlScreenSkin = new ControlScreenSkin();
            this._dataSet = new GoodsNotReturnDataSet();
            this._goodsNotReturnDetailDataTable = this._goodsNotReturnAcs.GoodsNotReturnDetailDataTable;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Cancel"];
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            _goodsNotReturnInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            _secInfoAcs = new SecInfoAcs();
            goodsNotReturnList = new ArrayList();
        }
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.uButton_SalesSlipNumber.ImageList = this._imageList16;
            this.uButton_SalesSlipNumber.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// 返品不可設定クリア処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note	   : 返品不可設定を処理する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        private bool Clear()
        {
            // 画面初期化処理
            this.InitializeScreen();
            // ADD 譚洪 2009/07/10 --->>>
            this.Mode_Label.Text = "新規モード";
            // ADD 譚洪 2009/07/10 ---<<<

            // 出荷取消明細クリア処理
            this._goodsNotReturnInput.Clear();
            salesSlipNumberTemp = string.Empty;
            this.tEdit_SalesSlipNumber.Focus();

            return true;
        }

        /// <summary>
        /// 画面データの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面データのを行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private void InitializeScreen()
        {

            // 売上伝票番号
            this.tEdit_SalesSlipNumber.Text = MARK_2;

            // 拠点コード
            this.uLabel_SectionCode.Text = MARK_2;

            // 拠点名称
            this.uLabel_SectionName.Text = MARK_2;

            // 得意先コード
            this.uLabel_CustomerCode.Text = MARK_2;

            // 得意先名称
            this.uLabel_CustomerName.Text = MARK_2;

            // 売上日
            this.uLabel_Year.Text = MARK_2;
            this.uLabel_Month.Text = MARK_2;
            this.uLabel_Day.Text = MARK_2;

            this._goodsNotReturnInput.Enabled = false;
        }

        /// <summary>
        /// 画面データの検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面データの検索を行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private bool SearchSalesSlip(string enterpriseCode, string salesSlipNum)
        {

            bool isSearch = true;
            this.InitializeScreen();
            this._goodsNotReturnInput.Clear();
            string retMessage = string.Empty;
            salesSlipNumberTemp = string.Empty;

            bool retupperCntFlag = false;

            int salesSlipNumLen = 0;
            // ADD 譚洪 2009/07/10 --->>>
            if (salesSlipNum.Length < 9)
            {
                salesSlipNumLen = 9 - salesSlipNum.Length;
                for (int i = 0; i < salesSlipNumLen; i++)
                {
                    salesSlipNum = "0" + salesSlipNum;
                }
            }
            // ADD 譚洪 2009/07/10 ---<<<

            // 売上伝票データ検索処理
            this.Cursor = Cursors.WaitCursor;
            int status = this._goodsNotReturnAcs.ReadDBData(enterpriseCode, salesSlipNum, out goodsNotReturnList, out retMessage);
            this.Cursor = Cursors.Default;

            foreach (GoodsNotReturnWork work in goodsNotReturnList)
            {
                if (work.UpdateDateTime == DateTime.MinValue)
                {
                    work.RetUpperCnt = work.ShipmentCnt;
                }
                else
                {
                    retupperCntFlag = true;
                }
            }

            // ADD 2009/06/29 --->>>
            if (!retupperCntFlag)
            {
                this.Mode_Label.Text = "新規モード";
            }
            else
            {
                this.Mode_Label.Text = "修正モード";
            }
            // ADD 2009/06/29 ---<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (null != goodsNotReturnList && goodsNotReturnList.Count > 0)
                {
                    GoodsNotReturnWork goodsNotReturnWork = (GoodsNotReturnWork)goodsNotReturnList[0];
                    // 売上伝票が削除データの場合は「削除伝票は呼び出せません。」
                    if (0 != goodsNotReturnWork.LogicalDeleteCode)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "削除伝票は呼び出せません。",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    // 取得した売上伝票が返品伝票か返品伝票の場合は「返品伝票は呼び出せません。」
                    if (1 == goodsNotReturnWork.SalesSlipCd)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "返品伝票は呼び出せません。",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    // 取得した売上伝票明細情報毎にの受注残数＝0の場合、「既に返品済みの売上伝票です。」
                    bool isReturn = true;
                    // 値引明細を除外した結果、対象明細が１件もない場合は
                    // 数量がマイナスの明細を除外した結果、対象明細が１件もない場合は
                    bool isDiscount = true;

                    foreach (GoodsNotReturnWork work in goodsNotReturnList)
                    {
                        // 値引明細を除外した結果、数量がマイナスの明細を除外した結果
                        if (work.SalesSlipCdDtl != 2 && work.ShipmentCnt >= 0)
                        {
                            isDiscount = false;
                            // 受注残数＝0の場合
                            if (work.AcptAnOdrRemainCnt != 0)
                            {
                                isReturn = false;
                            }
                        }
                    }
                    if (isDiscount)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "全明細が設定不可能なため呼び出せません。",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    if (isReturn)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "既に返品済みの売上伝票です。",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    // 売上伝票番号
                    this.tEdit_SalesSlipNumber.Text = salesSlipNum;
                    // 拠点コード
                    this.uLabel_SectionCode.Text = goodsNotReturnWork.SectionCode;
                    // 拠点名称
                    this.uLabel_SectionName.Text = goodsNotReturnWork.SectionGuideNm;
                    // 得意先コード
                    string customerCode = Convert.ToString(goodsNotReturnWork.CustomerCode);
                    if ("0".Equals(customerCode))
                    {
                        customerCode = string.Empty;
                    }
                    else
                    {
                        int customerCodeLen = customerCode.Length;

                        for (int i = customerCodeLen; i < 8; i++)
                        {
                            customerCode = "0" + customerCode;
                        }
                    }


                    this.uLabel_CustomerCode.Text = customerCode;
                    // 得意先名称
                    this.uLabel_CustomerName.Text = goodsNotReturnWork.CustomerName;
                    // 売上日
                    DateTime salesDt = goodsNotReturnWork.SalesDate;
                    string salesStr = Convert.ToString(salesDt);

                    if (salesDt == DateTime.MinValue)
                    {
                        this.uLabel_Year.Text = string.Empty;
                        this.uLabel_Month.Text = string.Empty;
                        this.uLabel_Day.Text = string.Empty;
                    }
                    else
                    {
                        salesStr = salesStr.Replace(MARK_1, MARK_2);
                        salesStr = salesStr.Replace(MARK_3, MARK_2);
                        this.uLabel_Year.Text = salesStr.Substring(0, 4);
                        this.uLabel_Month.Text = salesStr.Substring(4, 2);
                        this.uLabel_Day.Text = salesStr.Substring(6, 2);
                    }


                    this._goodsNotReturnInput.Enabled = true;
                    ArrayList goodsNotReturnListTmp = this._goodsNotReturnAcs.goodsNotReturnCache(goodsNotReturnList);

                    for (int i = 0; i < goodsNotReturnListTmp.Count; i++)
                    {
                        GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnListTmp[i];
                        if (work.AcptAnOdrRemainCnt == 0)
                        {
                            this._goodsNotReturnInput.uGrid_Details.DisplayLayout.Rows[i].Cells[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Activation = Activation.NoEdit;
                        }
                        if (i == MAXCOUNT)
                        {
                            break;
                        }
                    }

                    salesSlipNumberTemp = salesSlipNum;
                }
            }
            // 検索結果＝0件の場合、
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_SalesSlipNumber.Focus();
                isSearch = false;
                return isSearch;
            }
            // 検索エラーの場合、
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "売上データの取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
                isSearch = false;
                return isSearch;
            }
            return isSearch;
        }

        /// <summary>
        /// 売上伝票照会画面処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 売上伝票照会画面処理を行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private void uButton_SalesSlipNumber_Click(object sender, EventArgs e)
        {
            MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
            salesSlipGuide.TComboEditor_SalesFormalCode = false;
            salesSlipGuide.AcptAnOdrStatus = 30;
            SalesSlipSearchResult searchResult;
            DialogResult result;
            string retMessage = string.Empty;
            // 売上伝票照会画面
            result = salesSlipGuide.ShowGuide(this, _enterpriseCode, 30, 0, out searchResult);

            if (result == DialogResult.OK)
            {
                if (searchResult != null)
                {

                    if (!salesSlipNumberTemp.Equals(searchResult.SalesSlipNum))
                    {
                        GoodsNotReturnWork goodsNotReturnWork = null;
                        ArrayList updGoodsNotReturnList = new ArrayList();
                        // 売上伝票番号検索結果件数
                        int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                        // 返品上限数
                        string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                        for (int i = 0; i < rowNo; i++)
                        {
                            goodsNotReturnWork = new GoodsNotReturnWork();
                            // 返品上限データの更新日時
                            goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                            // 企業コード
                            goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                            // 受注ステータス
                            goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                            // 返品上限数
                            if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                            {
                                goodsNotReturnWork.RetUpperCnt = -1;
                            }
                            else
                            {
                                goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                            }
                            // 売上明細通番
                            goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;
                            updGoodsNotReturnList.Add(goodsNotReturnWork);
                        }

                        int acptAnOdrStatus = 0;
                        long salesSlipDtlNum = 0;
                        double retUpperCnt = 0;
                        bool isChange = false;
                        for (int i = 0; i < updGoodsNotReturnList.Count; i++)
                        {
                            GoodsNotReturnWork updWork = (GoodsNotReturnWork)updGoodsNotReturnList[i];
                            acptAnOdrStatus = updWork.AcptAnOdrStatus;
                            salesSlipDtlNum = updWork.SalesSlipDtlNum;
                            retUpperCnt = updWork.RetUpperCnt;

                            for (int j = 0; j < goodsNotReturnList.Count; j++)
                            {
                                GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnList[j];
                                if (acptAnOdrStatus == work.AcptAnOdrStatus
                                    && salesSlipDtlNum == work.SalesSlipDtlNum)
                                {
                                    if (retUpperCnt == work.RetUpperCnt)
                                    {
                                        isChange = false;
                                    }
                                    else
                                    {
                                        isChange = true;
                                        break;
                                    }
                                }
                            }

                            if (isChange)
                            {
                                break;
                            }
                        }

                        if (isChange)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                "登録してもよろしいですか？",
                                0,
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // 更新処理
                                int status = this.UpdateProcess(updGoodsNotReturnList);

                                // 既に他端末更新の場合、
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "既に他端末より更新されています。",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // 既に他端末削除の場合、
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "既に他端末より削除されています。",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // 更新完了の場合、
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    bool isSearch = this.SearchSalesSlip(_enterpriseCode, searchResult.SalesSlipNum);
                                    this.tEdit_SalesSlipNumber.Text = searchResult.SalesSlipNum;
                                    this.tEdit_SalesSlipNumber.Focus();
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    salesSlipNumberTemp = searchResult.SalesSlipNum;


                                    return;
                                }
                                // 更新エラーの場合、
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    PGID + "返品上限データの保存に失敗しました。ST=" + Convert.ToString(status),
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                bool isSearch = this.SearchSalesSlip(_enterpriseCode, searchResult.SalesSlipNum);
                                if (!isSearch)
                                {
                                    this.tEdit_SalesSlipNumber.Text = searchResult.SalesSlipNum;
                                    this.tEdit_SalesSlipNumber.Focus();
                                }
                            }
                            // キャンセルの場合、
                            else
                            {
                                this.tEdit_SalesSlipNumber.Text = salesSlipNumberTemp;
                                this.tEdit_SalesSlipNumber.Focus();
                            }
                        }
                        // データが変更ない場合、
                        else
                        {
                            bool isSearch = this.SearchSalesSlip(_enterpriseCode, searchResult.SalesSlipNum);
                            if (!isSearch)
                            {
                                //this.tEdit_SalesSlipNumber.Text = searchResult.SalesSlipNum;
                                this.tEdit_SalesSlipNumber.Text = string.Empty;
                                salesSlipNumberTemp = string.Empty;
                                this.tEdit_SalesSlipNumber.Focus();
                            }
                        }
                    }

                    //// 売上伝票データ検索処理
                    //bool isSearch = this.SearchSalesSlip(searchResult.EnterpriseCode, searchResult.SalesSlipNum);
                }
            }

        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベントを行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this._goodsNotReturnInput.uGrid_Details.ActiveCell != null)
                        {
                            this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // 終了処理
                        GoodsNotReturnWork goodsNotReturnWork = null;
                        ArrayList updGoodsNotReturnList = new ArrayList();
                        // 売上伝票番号検索結果件数
                        int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                        // 返品上限数
                        string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                        for (int i = 0; i < rowNo; i++)
                        {
                            goodsNotReturnWork = new GoodsNotReturnWork();
                            // 返品上限データの更新日時
                            goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                            // 企業コード
                            goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                            // 受注ステータス
                            goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                            // 返品上限数
                            if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                            {
                                goodsNotReturnWork.RetUpperCnt = -1;
                            }
                            else
                            {
                                goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                            }
                            // 売上明細通番
                            goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;
                            updGoodsNotReturnList.Add(goodsNotReturnWork);
                        }

                        int acptAnOdrStatus = 0;
                        long salesSlipDtlNum = 0;
                        double retUpperCnt = 0;
                        bool isChange = false;
                        for (int i = 0; i < updGoodsNotReturnList.Count; i++)
                        {
                            GoodsNotReturnWork updWork = (GoodsNotReturnWork)updGoodsNotReturnList[i];
                            acptAnOdrStatus = updWork.AcptAnOdrStatus;
                            salesSlipDtlNum = updWork.SalesSlipDtlNum;
                            retUpperCnt = updWork.RetUpperCnt;

                            for (int j = 0; j < goodsNotReturnList.Count; j++)
                            {
                                GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnList[j];
                                if (acptAnOdrStatus == work.AcptAnOdrStatus
                                    && salesSlipDtlNum == work.SalesSlipDtlNum)
                                {
                                    if (retUpperCnt == work.RetUpperCnt)
                                    {
                                        isChange = false;
                                    }
                                    else
                                    {
                                    isChange = true;
                                    break;
                                    }

                                }

                            }

                            if (isChange)
                            {
                                break;
                            }
                        }

                        if (isChange)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                "登録してもよろしいですか？",
                                0,
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // 更新処理
                                int status = this.UpdateProcess(updGoodsNotReturnList);

                                // 既に他端末更新の場合、
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "既に他端末より更新されています。",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // 既に他端末削除の場合、
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "既に他端末より削除されています。",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // 更新完了の場合、
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 登録完了
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    this.Close();
                                    return;
                                }
                                // 更新エラーの場合、
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    PGID + "返品上限データの保存に失敗しました。ST=" + Convert.ToString(status),
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.tEdit_SalesSlipNumber.Focus();
                            }
                        }
                        else
                        {
                            this.Close();
                        }
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 売上伝票番号を未入力する場合、エラーとする。
                        if (string.IsNullOrEmpty(this.tEdit_SalesSlipNumber.Text.Trim()))
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "売上伝票番号を指定してください。",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }
                        // 売上伝票番号検索結果がないの場合、エラーとする。
                        if (this._goodsNotReturnInput.uGrid_Details.Rows.Count == 0)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "保存対象データが存在しません。",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }


                        if (this._prevControl != null)
                        {
                            ChangeFocusEventArgs e2 = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                            this.tArrowKeyControl1_ChangeFocus(this, e2);
                        }

                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this._goodsNotReturnInput.uGrid_Details.ActiveCell != null)
                        {
                            this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        GoodsNotReturnWork goodsNotReturnWork = null;
                        ArrayList updGoodsNotReturnList = new ArrayList();
                        // 売上伝票番号検索結果件数
                        int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                        double shipmentNo = 0;
                        double returnNo = 0;
                        // 返品上限数
                        string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                        for (int i = 0; i < rowNo; i++)
                        {
                            goodsNotReturnWork = new GoodsNotReturnWork();
                            // 返品上限データの更新日時
                            goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                            // 企業コード
                            goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                            // 受注ステータス
                            goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                            // 返品上限数
                            if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                            {
                                goodsNotReturnWork.RetUpperCnt = -1;
                            }
                            else
                            {
                                goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                            }
                            // 売上明細通番
                            goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;

                            shipmentNo = this._goodsNotReturnDetailDataTable[i].ShipmentNo;
                            if (goodsNotReturnWork.RetUpperCnt > shipmentNo)
                            {
                                //DialogResult dialogResult = TMsgDisp.Show(
                                //   this,
                                //   emErrorLevel.ERR_LEVEL_INFO,
                                //   this.Name,
                                //   "返品上限数が出荷数を超えています。",
                                //   -1,
                                //   MessageBoxButtons.OK);

                                return;
                            }
                            returnNo = this._goodsNotReturnDetailDataTable[i].ReturnNo;
                            // 入力返品上限数＜返品済数の場合、「返品上限数は返品済数以上の値を入力して下さい。」というメッセージダイアログ（OKのみ）が表示される。
                            if (goodsNotReturnWork.RetUpperCnt < returnNo)
                            {
                                //TMsgDisp.Show(
                                //   this,
                                //   emErrorLevel.ERR_LEVEL_INFO,
                                //   this.Name,
                                //   "返品上限数は返品済数以上の値を入力して下さい。",
                                //   -1,
                                //   MessageBoxButtons.OK);
                                //this._goodsNotReturnInput.uGrid_Details.Rows[i].Cells[6].Activated = true;
                                //this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                return;
                            }
                            // 入力返品上限数＜0の場合、「返品上限数は0以上の値を入力して下さい。」というメッセージダイアログ（OKのみ）が表示される。
                            if (goodsNotReturnWork.RetUpperCnt < 0)
                            {
                                //TMsgDisp.Show(
                                //   this,
                                //   emErrorLevel.ERR_LEVEL_INFO,
                                //   this.Name,
                                //   "返品上限数は0以上の値を入力して下さい。",
                                //   -1,
                                //   MessageBoxButtons.OK);

                                return;
                            }
                            updGoodsNotReturnList.Add(goodsNotReturnWork);
                        }

                        // 更新処理
                        int status = this.UpdateProcess(updGoodsNotReturnList);

                        // 既に他端末更新の場合、
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "既に他端末より更新されています。",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }
                        // 既に他端末削除の場合、
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "既に他端末より削除されています。",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }
                        // 更新完了の場合、
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 売上伝票番号
                            this.tEdit_SalesSlipNumber.Text = MARK_2;

                            // 拠点コード
                            this.uLabel_SectionCode.Text = MARK_2;

                            // 拠点名称
                            this.uLabel_SectionName.Text = MARK_2;

                            // 得意先コード
                            this.uLabel_CustomerCode.Text = MARK_2;

                            // 得意先名称
                            this.uLabel_CustomerName.Text = MARK_2;

                            // 売上日
                            this.uLabel_Year.Text = MARK_2;
                            this.uLabel_Month.Text = MARK_2;
                            this.uLabel_Day.Text = MARK_2;

                            this._goodsNotReturnInput.Clear();
                            this.tEdit_SalesSlipNumber.Focus();

                        }
                        // 更新エラーの場合、
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            PGID + "返品上限データの保存に失敗しました。ST=" + Convert.ToString(status),
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }

                        // 登録完了
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        salesSlipNumberTemp = string.Empty;

                        break;
                    }
                case "ButtonTool_Cancel":
                    {
                        // クリア処理
                        this.Clear();
                        this._goodsNotReturnInput.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// 終了の確認ダイアログ表示処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <returns>確認後OK 確認後NG</returns>
        /// <remarks>		
        /// <br>Note		: 終了の確認ダイアログ表示処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private bool ShowSaveCheckDialog(bool isConfirm)
        {
            bool checkedValue = false;

            if ((isConfirm) && (!"".Equals(this.tEdit_SalesSlipNumber.Text.Trim())
                || this._goodsNotReturnInput.uGrid_Details.Rows.Count != 0))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    checkedValue = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    checkedValue = true;
                }
            }
            else
            {
                checkedValue = true;
            }

            return checkedValue;
        }

        /// <summary>
        /// 返品上限データ更新処理
        /// </summary>
        /// <remarks>
        /// <param name="updGoodsNotReturnList">更新データリスト</param>
        /// <br>Note		: 返品上限データ更新処理を行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private int UpdateProcess(ArrayList updGoodsNotReturnList)
        {
            string retMessage = string.Empty;
            // 返品上限データを更新する
            int status = _goodsNotReturnAcs.UpdateReturnUpper(updGoodsNotReturnList, out retMessage);

            return status;
        }

        /// <summary>
        /// 詳細グリッド最上位行アプイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 詳細グリッド最上位行アプウン時に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            Control control = this.tEdit_SalesSlipNumber;

            if (control != null)
            {
                control.Focus();
            }

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動を処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this._goodsNotReturnInput.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this._goodsNotReturnInput.uGrid_Details.ActiveCell != null))
            {
                if ((!this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.Hidden) &&
                    (this._goodsNotReturnInput.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                if (performActionResult)
                {
                    if ((this._goodsNotReturnInput.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this._goodsNotReturnInput.uGrid_Details.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// フォカス変更時にイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォカス変更時に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
                case "uGrid_Details":
                    {
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                        {
                            if (this._goodsNotReturnInput.uGrid_Details.ActiveCell == null)
                            {
                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.NextCell);
                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                                return;
                            }

                            int activeRowIndex = this._goodsNotReturnInput.uGrid_Details.ActiveCell.Row.Index;
                            int activeColumnIndex = this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.Index;

                            if (e.ShiftKey == false)
                            {
                                for (int rowIndex = activeRowIndex; rowIndex < this._goodsNotReturnInput.uGrid_Details.Rows.Count - 1; rowIndex++)
                                {
                                    if (rowIndex == activeRowIndex)
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                }

                                // gridの最後のcell
                                if ((activeRowIndex + 1 == this._goodsNotReturnInput.uGrid_Details.Rows.Count) && (activeColumnIndex == COLUMN_COUNT))
                                {
                                    this._goodsNotReturnInput.uGrid_Details.Rows[activeRowIndex].Cells[6].Activated = false;
                                    this._goodsNotReturnInput.uGrid_Details.Rows[activeRowIndex].Cells[6].Selected = false;
                                    e.NextCtrl = this.tEdit_SalesSlipNumber;
                                    return;
                                }
                                else
                                {
                                    this._goodsNotReturnInput.uGrid_Details.Rows[activeRowIndex].Cells[6].Activate();
                                    this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    e.NextCtrl = null;
                                    return;
                                }
                            }
                            else
                            {
                                for (int rowIndex = activeRowIndex; rowIndex >= 0; rowIndex--)
                                {
                                    if (rowIndex == 0)
                                    {
                                        if (activeColumnIndex == COLUMN_COUNT)
                                        {
                                            e.NextCtrl = this.tEdit_SalesSlipNumber;
                                            return;
                                        }
                                        else
                                        {
                                            if (this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit)
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SalesSlipNumber;
                                                return;
                                            }

                                        }
                                    }

                                    if (rowIndex == activeRowIndex)
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if (this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activation == Activation.AllowEdit)
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "uButton_SalesSlipNumber":
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Down:
                            case Keys.Return:
                                if (this._goodsNotReturnDetailDataTable.Rows.Count > 0)
                                {
                                    for (int i = 0; i < this._goodsNotReturnDetailDataTable.Rows.Count; i++ )
                                    {
                                        // 返品不可設定グリッド
                                        if (this._goodsNotReturnInput.uGrid_Details.Rows[i].Cells[6].Activation == Activation.AllowEdit)
                                        {
                                            this._goodsNotReturnInput.uGrid_Details.Rows[i].Cells[6].Activate();
                                            this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    // 返品不可設定グリッド
                                    e.NextCtrl = this.tEdit_SalesSlipNumber;
                                }
                                break;
                        }
                        break;
                    }
                case "tEdit_SalesSlipNumber":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesSlipNumber.Text))
                        {
                            int salesslipNo = 0;
                            if (int.TryParse(this.tEdit_SalesSlipNumber.Text, out salesslipNo))
                            {
                                if (salesslipNo == 0)
                                {
                                    this.tEdit_SalesSlipNumber.Text = string.Empty;
                                    // 画面初期化処理
                                    this.InitializeScreen();

                                    // 返品不可設定クリア処理
                                    this._goodsNotReturnInput.Clear();

                                    salesSlipNumberTemp = string.Empty;
                                    return;
                                }
                            }

                            if (!this.tEdit_SalesSlipNumber.Text.Equals(salesSlipNumberTemp))
                            {
                                string retMessage = string.Empty;
                                GoodsNotReturnWork goodsNotReturnWork = null;
                                ArrayList updGoodsNotReturnList = new ArrayList();
                                // 売上伝票番号検索結果件数
                                int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                                // 返品上限数
                                string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                                for (int i = 0; i < rowNo; i++)
                                {
                                    goodsNotReturnWork = new GoodsNotReturnWork();
                                    // 返品上限データの更新日時
                                    goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                                    // 企業コード
                                    goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                                    // 受注ステータス
                                    goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                                    // 返品上限数
                                    if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                                    {
                                        goodsNotReturnWork.RetUpperCnt = -1;
                                    }
                                    else
                                    {
                                        goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                                    }
                                    // 売上明細通番
                                    goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;
                                    updGoodsNotReturnList.Add(goodsNotReturnWork);
                                }

                                int acptAnOdrStatus = 0;
                                long salesSlipDtlNum = 0;
                                double retUpperCnt = 0;
                                bool isChange = false;
                                for (int i = 0; i < updGoodsNotReturnList.Count; i++)
                                {
                                    GoodsNotReturnWork updWork = (GoodsNotReturnWork)updGoodsNotReturnList[i];
                                    acptAnOdrStatus = updWork.AcptAnOdrStatus;
                                    salesSlipDtlNum = updWork.SalesSlipDtlNum;
                                    retUpperCnt = updWork.RetUpperCnt;

                                    for (int j = 0; j < goodsNotReturnList.Count; j++)
                                    {
                                        GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnList[j];
                                        if (acptAnOdrStatus == work.AcptAnOdrStatus
                                            && salesSlipDtlNum == work.SalesSlipDtlNum)
                                        {
                                            if (retUpperCnt == work.RetUpperCnt)
                                            {
                                                isChange = false;
                                            }
                                            else
                                            {
                                                isChange = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (isChange)
                                    {
                                        break;
                                    }
                                }

                                if (isChange)
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                        "登録してもよろしいですか？",
                                        0,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxDefaultButton.Button1);

                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        // 更新処理
                                        int status = this.UpdateProcess(updGoodsNotReturnList);

                                        // 既に他端末更新の場合、
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "既に他端末より更新されています。",
                                            0,
                                            MessageBoxButtons.OK);
                                            return;
                                        }
                                        // 既に他端末削除の場合、
                                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "既に他端末より削除されています。",
                                            0,
                                            MessageBoxButtons.OK);
                                            return;
                                        }
                                        // 更新完了の場合、
                                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            bool isSearch = this.SearchSalesSlip(_enterpriseCode, this.tEdit_SalesSlipNumber.Text);
                                            e.NextCtrl = this.tEdit_SalesSlipNumber;
                                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                                            dialog.ShowDialog(2);
                                            salesSlipNumberTemp = string.Empty;

                                            return;
                                        }
                                        // 更新エラーの場合、
                                        else
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            PGID + "返品上限データの保存に失敗しました。ST=" + Convert.ToString(status),
                                            0,
                                            MessageBoxButtons.OK);
                                            return;
                                        }
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {
                                        bool isSearch = this.SearchSalesSlip(_enterpriseCode, this.tEdit_SalesSlipNumber.Text);
                                        if (!isSearch)
                                        {
                                            e.NextCtrl = this.tEdit_SalesSlipNumber;
                                        }
                                    }
                                    // キャンセルの場合、
                                    else
                                    {
                                        this.tEdit_SalesSlipNumber.Text = salesSlipNumberTemp;
                                        e.NextCtrl = this.tEdit_SalesSlipNumber;
                                    }
                                }
                                // データが変更ない場合、
                                else
                                {
                                    bool isSearch = this.SearchSalesSlip(_enterpriseCode, this.tEdit_SalesSlipNumber.Text);
                                    if (!isSearch)
                                    {
                                        this.tEdit_SalesSlipNumber.Text = string.Empty;
                                        salesSlipNumberTemp = string.Empty;
                                        e.NextCtrl = this.tEdit_SalesSlipNumber;
                                        // ↓ 2009.07.07 劉洋 追記
                                        return;
                                        // ↑ 2009.07.07 劉洋
                                    }
                                }
                            }

                        }
                        // データがない場合、
                        else
                        {
                            // 画面初期化処理
                            this.InitializeScreen();

                            // 出荷取消明細クリア処理
                            this._goodsNotReturnInput.Clear();

                            salesSlipNumberTemp = string.Empty;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.uButton_SalesSlipNumber;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this._goodsNotReturnInput.uGrid_Details.Rows.Count > 0)
                                {
                                    e.NextCtrl = this._goodsNotReturnInput.uGrid_Details;
                                    this._goodsNotReturnInput.uGrid_Details.Rows[this._goodsNotReturnInput.uGrid_Details.Rows.Count - 1].Cells[6].Activate();
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_SalesSlipNumber;
                                }
                            }
                        }

                        break;
                    }
            }
        }
        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region ■Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォカス変更時に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks> 
        private void PMKHN09501UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._goodsNotReturnInput);

            this.ButtonInitialSetting();

            panel_Detail.Controls.Add(this._goodsNotReturnInput);
            this._goodsNotReturnInput.Dock = DockStyle.Fill;

            // クリア処理
            this.Clear();

            Infragistics.Win.UltraWinToolbars.LabelTool sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_SectionName"];
            SecInfoSet secInfoSet = new SecInfoSet();
            this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // ログイン拠点の設定
                sectionNameLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
            }

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            this._goodsNotReturnInput.Enabled = false;
        }
        #endregion
    }
}