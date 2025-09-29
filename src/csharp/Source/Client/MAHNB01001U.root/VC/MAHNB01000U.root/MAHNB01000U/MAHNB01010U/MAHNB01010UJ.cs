using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売仕入同時入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の仕入情報入力を行うコントロールクラスです。フォームクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.01.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.01.21 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    public partial class MAHNB01010UJ : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        public MAHNB01010UJ()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerInfoAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
            this._supplierAcs = new SupplierAcs();
            this._supplierAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();

            this._salesSlipStockInfoInputAcs = SalesSlipStockInfoInputAcs.GetInstance();
            this._salesSlipStockInfoInputAcs.SetDisplay += new SalesSlipStockInfoInputAcs.SetDisplayStockInfoEventHandler(this.SetDisplay);

            this._demandConfirm = new DCKOU01050UA();
            this._demandConfirm.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;

            this._clearControlList = new List<Control>();
            this._clearControlList.Add(this.tEdit_StockAgentCode);
            this._clearControlList.Add(this.uLabel_StockAgentName);
            this._clearControlList.Add(this.uButton_EmployeeGuide);
            this._clearControlList.Add(this.tNedit_CustomerCode);
            this._clearControlList.Add(this.uLabel_CustomerName);
            this._clearControlList.Add(this.uButton_CustomerGuide);
            this._clearControlList.Add(this.uButton_PaymentConfirmation);
            this._clearControlList.Add(this.tEdit_WarehouseCode);
            this._clearControlList.Add(this.uLabel_WarehouseName);
            this._clearControlList.Add(this.uButton_WarehouseGuide);
            this._clearControlList.Add(this.tComboEditor_SupplierFormal);
            this._clearControlList.Add(this.tComboEditor_SupplierSlipDisplay);
            this._clearControlList.Add(this.tDateEdit_ArrivalGoodsDay);
            this._clearControlList.Add(this.tDateEdit_StockDate);
            this._clearControlList.Add(this.tEdit_PartySaleSlipNum);
            this._clearControlList.Add(this.tNedit_StockCount);
            this._clearControlList.Add(this.tComboEditor_UnitCode);
            this._clearControlList.Add(this.tNedit_ListPrice);
            this._clearControlList.Add(this.tNedit_StockUnitPriceDisplay);
            this._clearControlList.Add(this.tNedit_StockPriceDisplay);
            this._clearControlList.Add(this.tComboEditor_WayToOrder);
            this._clearControlList.Add(this.tComboEditor_StockBargainCd);
            this._clearControlList.Add(this.tEdit_OrderNumber);
            this._clearControlList.Add(this.tEdit_DtlNote);

            this._stockControlList = new List<Control>();
            this._stockControlList.Add(uButton_PaymentConfirmation);
            //this._stockControlList.Add(panel_BargainInfo);

            this._orderControlList = new List<Control>();
            this._orderControlList.Add(this.panel_OrderInfo1);
            this._orderControlList.Add(this.panel_OrderInfo2);
            this._orderControlList.Add(this.panel_OrderInfo3);
            this._orderControlList.Add(this.panel_OrderInfo4);
            this._orderControlList.Add(this.panel_OrderInfo5);
            this._orderControlList.Add(this.panel_OrderInfo6);
            this._orderControlList.Add(this.panel_OrderInfo7);
            this._orderControlList.Add(this.panel_OrderInfo8);

            this._writeAfterList = new List<Control>();
            this._writeAfterList.Add(this.tEdit_StockAgentCode);
            this._writeAfterList.Add(this.tNedit_CustomerCode);
            this._writeAfterList.Add(this.tComboEditor_SupplierFormal);
            this._writeAfterList.Add(this.tComboEditor_SupplierSlipDisplay);
            this._writeAfterList.Add(this.tEdit_WarehouseCode);
            this._writeAfterList.Add(this.uButton_CustomerGuide);
            this._writeAfterList.Add(this.uButton_EmployeeGuide);
            this._writeAfterList.Add(this.uButton_PaymentConfirmation);
            this._writeAfterList.Add(this.uButton_WarehouseGuide);
            this._writeAfterList.Add(this.tDateEdit_ArrivalGoodsDay);
            this._writeAfterList.Add(this.tDateEdit_StockDate);
            this._writeAfterList.Add(this.tEdit_PartySaleSlipNum);

            this._addUpSyncList = new List<Control>();
            //this._addUpSyncList.Add(this.tEdit_StockAgentCode);
            this._addUpSyncList.Add(this.tNedit_CustomerCode);
            //this._addUpSyncList.Add(this.tComboEditor_SupplierFormal);
            //this._addUpSyncList.Add(this.tComboEditor_SupplierSlipDisplay);
            this._addUpSyncList.Add(this.tEdit_WarehouseCode);
            this._addUpSyncList.Add(this.uButton_CustomerGuide);
            //this._addUpSyncList.Add(this.uButton_EmployeeGuide);
            this._addUpSyncList.Add(this.uButton_PaymentConfirmation);
            this._addUpSyncList.Add(this.uButton_WarehouseGuide);
            //this._addUpSyncList.Add(this.tDateEdit_ArrivalGoodsDay);
            //this._addUpSyncList.Add(this.tDateEdit_StockDate);
            this._addUpSyncList.Add(this.tEdit_PartySaleSlipNum);

            int controlIndexForword = 0;
            this._controlIndexForwordDictionary.Add(this.tEdit_StockAgentCode.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.uButton_PaymentConfirmation.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tEdit_WarehouseCode.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_SupplierFormal.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_SupplierSlipDisplay.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tDateEdit_ArrivalGoodsDay.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tDateEdit_StockDate.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_StockCount.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_UnitCode.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_ListPrice.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_StockUnitPriceDisplay.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_WayToOrder.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_StockBargainCd.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tEdit_OrderNumber.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tEdit_DtlNote.Name, controlIndexForword++);

            int controlIndexBack = 99;
            this._controlIndexBackDictionary.Add(this.tEdit_DtlNote.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tEdit_OrderNumber.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_StockBargainCd.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_WayToOrder.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_StockUnitPriceDisplay.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_ListPrice.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_UnitCode.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_StockCount.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tDateEdit_StockDate.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tDateEdit_ArrivalGoodsDay.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_SupplierSlipDisplay.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_SupplierFormal.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tEdit_WarehouseCode.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.uButton_PaymentConfirmation.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tEdit_StockAgentCode.Name, controlIndexBack--);

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._guideEnableControlDictionary = new Dictionary<string, string>();
            this._guideEnableControlDictionary.Add(this.tEdit_StockAgentCode.Name, ctGUIDE_NAME_EmployeeGuide);
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);
            this._guideEnableControlDictionary.Add(this.tEdit_WarehouseCode.Name, ctGUIDE_NAME_WarehouseGuide);
            this._guideEnableControlDictionary.Add(this.tNedit_StockUnitPriceDisplay.Name, ctGUIDE_NAME_StockUnitPriceInfo);

            this.Clear(true);

            //------------------------------------------------------------------------------
            // 仕入入力タブはタブ選択時にロードされる為、コンポの設定が有効にならないので
            // 仕入入力画面ロード前にUiSetControlの各種設定処理を行う
            //------------------------------------------------------------------------------
            this.uiSetControl1.SettingFormBeforeLoad();

        }
        #endregion

        //// ===================================================================================== //
        //// デリゲート&イベント
        //// ===================================================================================== //
        //# region ■Delegate&Event
        ///// <summary>明細コンポ取得デリゲート</summary>
        ///// <returns>明細のコンポーネント</returns>
        //internal delegate Control GetDetailControlEventHandler();

        //internal GetDetailControlEventHandler GetDetailControl;
        //#endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Private Members
        private ImageList _imageList16 = null;											// イメージリスト
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesSlipStockInfoInputAcs _salesSlipStockInfoInputAcs;

        private List<Control> _clearControlList;
        private List<Control> _stockControlList; // 仕入情報タイトルコントロールリスト
        private List<Control> _orderControlList; // 発注情報タイトルコントロールリスト
        private List<Control> _writeAfterList; // 書込後コントロールリスト
        private List<Control> _addUpSyncList; // 計上時コントロールリスト
        
        private CustomerInfoAcs _customerInfoAcs;
        private SupplierAcs _supplierAcs;
        private string _enterpriseCode;
        private Dictionary<string, int> _controlIndexForwordDictionary = new Dictionary<string, int>();
        private Dictionary<string, int> _controlIndexBackDictionary = new Dictionary<string, int>();
        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();

        private DCKOU01050UA _demandConfirm;

        private const string ctGUIDE_NAME_EmployeeGuide = "EmployeeGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
        private const string ctGUIDE_NAME_WarehouseGuide = "WarehouseGuide";
        private const string ctGUIDE_NAME_StockUnitPriceInfo = "StockUnitPriceInfo";

        private const string ctTAB_KEY_StockInfo = "StockInfo";

        private static readonly Color ct_MARGIN_LESS_COLOR = Color.Pink;
        private static readonly Color ct_MARGIN_NORMAL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
        private static readonly Color ct_MARGIN_OVER_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■Public Methods
        /// <summary>
        /// フォーカス変更メソッド（ChangeFocusを親フォームでキャッチするので、このメソッドでチェック等を行います）
        /// </summary>
        /// <param name="prevCtrl">現在のフォーカスコントロール</param>
        /// <param name="nextCtrl">次のフォーカスコントロール</param>
        public void StockInfo_ChangeFocus(ref Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (this._salesSlipStockInfoInputAcs.StockTemp == null) return;

            StockTemp stockTempCurrent = this._salesSlipStockInfoInputAcs.StockTemp.Clone();
            StockTemp stockTemp = stockTempCurrent.Clone();
            bool reCalcUnitPrice = false;		// 掛率による売上単価、定価、売上原価単価再計算有無
            bool reCalcStockPrice = false;		// 売上金額再計算有無
            bool getNextCtrl = true;
            bool taxChange = false;
            bool canChangeFocus = true;

            Control prevCtrl = e.PrevCtrl;

            if (e.PrevCtrl == this)
            {
                if ((this.ContainsFocus) && (this.ActiveControl is Control))
                {
                    if ((this.ActiveControl.Parent != null) && (this.ActiveControl.Parent.Parent != null) && (this.ActiveControl.Parent.Parent is TDateEdit))
                    {
                        prevCtrl = (Control)this.ActiveControl.Parent.Parent;
                    }
                    else if ((this.ActiveControl.Parent != null) && (((this.ActiveControl.Parent is TNedit) || (this.ActiveControl.Parent is TEdit) || (this.ActiveControl.Parent is TComboEditor) || (this.ActiveControl.Parent is TDateEdit))))
                    {
                        prevCtrl = (Control)this.ActiveControl.Parent;
                    }
                    else
                    {
                        prevCtrl = (Control)this.ActiveControl;
                    }
                }
            }

            switch (prevCtrl.Name)
            {
                #region 仕入担当
                case "tEdit_StockAgentCode":
                    {

                        canChangeFocus = true;

                        string code = this.tEdit_StockAgentCode.Text.Trim();

                        if (stockTempCurrent.StockAgentCode.Trim() != code)
                        {
                            bool codeChange = true;

                            if (codeChange)
                            {
                                if (code == "")
                                {
                                    stockTemp.StockAgentCode = code;
                                    stockTemp.StockAgentName = "";
                                    stockTemp.SubSectionCode = 0;
                                }
                                else
                                {
                                    string name = this._salesSlipInputInitDataAcs.GetName_FromEmployee(code);

                                    if (name.Trim() == "")
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "従業員が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        code = "";
                                    }

                                    stockTemp.StockAgentCode = code;
                                    stockTemp.StockAgentName = name;
                                    if (stockTemp.StockAgentName.Length > 16)
                                    {
                                        stockTemp.StockAgentName = stockTemp.StockAgentName.Substring(0, 16);
                                    }
                                    this._salesSlipStockInfoInputAcs.SettingStockTempStockFromAgentBelongInfo(ref stockTemp);

                                }
                            }
                        }

                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_StockAgentCode.Text.Trim() == "")
                                        {
                                            e.NextCtrl = this.uButton_EmployeeGuide;
                                            getNextCtrl = false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            getNextCtrl = false;
                        }
                        break;

                    }
                #endregion

                #region 仕入先
                case "tNedit_CustomerCode":
                    {
                        canChangeFocus = true;
                        int code = this.tNedit_CustomerCode.GetInt();

                        if (stockTempCurrent.SupplierCd != code)
                        {
                            if (code == 0)
                            {
                                try
                                {
                                    // 得意先（仕入先）情報設定処理
                                    this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, null);

                                }
                                catch (Exception ex)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        ex.Message,
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }
                            else
                            {
                                Supplier supplier;
								this.Cursor = Cursors.WaitCursor;
                                int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);
								this.Cursor = Cursors.Default;
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 仕入先情報設定処理
                                    this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplier);

                                    if (supplier.SupplierCd != stockTempCurrent.SupplierCd)
                                    {
                                        reCalcUnitPrice = true;
                                        reCalcStockPrice = true;
                                    }

                                    this._salesSlipStockInfoInputAcs.SettingStockTempStockFromAgentBelongInfo(ref stockTemp);

                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "仕入先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "仕入先の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // 画面格納処理
                            this.SetDisplay(stockTemp);
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            getNextCtrl = true;
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tNedit_CustomerCode.GetInt() == 0)
                                        {
                                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, EventArgs.Empty);
                                        }

                                        if (this.tNedit_CustomerCode.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_CustomerGuide;
                                            getNextCtrl = false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            getNextCtrl = false;
                        }
                        break;

                    }
                #endregion

                #region 倉庫コード
                //---------------------------------------------------------------
                // 倉庫コード
                //---------------------------------------------------------------
                case "tEdit_WarehouseCode":
                    {
                        getNextCtrl = true;

                        canChangeFocus = true;
                        string code = this.tEdit_WarehouseCode.Text.Trim();

                        if (stockTempCurrent.WarehouseCode != code)
                        {
                            if (code == "")
                            {
                                stockTemp.WarehouseCode = code;
                                stockTemp.WarehouseName = "";
                            }
                            else
                            {
                                string selectedSectionCode = this._salesSlipInputInitDataAcs.OwnSectionCode.Trim();
                                string name = this._salesSlipInputInitDataAcs.OwnSectionName;
                                if (name == "")
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "倉庫が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                    code = "";
                                }

                                stockTemp.WarehouseCode = code;
                                stockTemp.WarehouseName = name;
                            }

                            // 仕入データクラス→画面格納処理
                            this.SetDisplay(stockTemp);
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {

                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
                                        {
                                            e.NextCtrl = this.tComboEditor_SupplierFormal;
                                            getNextCtrl = false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            getNextCtrl = false;
                        }

                        break;
                    }
                #endregion

                #region 伝票種別
                case "tComboEditor_SupplierFormal":
                    {

                        // 伝票種別コンボエディタ選択値変更確定後イベントを一時的に解除
                        this.tComboEditor_SupplierFormal.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChangeCommitted);

                        this.tComboEditor_SupplierFormal_SelectionChangeCommitted(this.tComboEditor_AccPayDivCd, new EventArgs());

                        // コンボエディタのイベントで更新されている可能性があるので再度キャッシュ
                        stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

                        // 伝票種別コンボエディタ選択値変更確定後イベントを挿入
                        this.tComboEditor_SupplierFormal.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChangeCommitted);

                        break;

                    }
                #endregion

                #region 伝票区分
                case "tComboEditor_SupplierSlipDisplay":
                    {

                        // 伝票区分コンボエディタ選択値変更確定後イベントを一時的に解除
                        this.tComboEditor_SupplierSlipDisplay.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SupplierSlipCdDisplay_SelectionChangeCommitted);

                        this.tComboEditor_SupplierSlipCdDisplay_SelectionChangeCommitted(this.tComboEditor_SupplierSlipDisplay, new EventArgs());

                        // コンボエディタのイベントで更新されている可能性があるので再度キャッシュ
                        stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

                        // 伝票区分コンボエディタ選択値変更確定後イベントを挿入
                        this.tComboEditor_SupplierSlipDisplay.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SupplierSlipCdDisplay_SelectionChangeCommitted);

                        break;

                    }
                #endregion

                #region 入荷日
                case "tDateEdit_ArrivalGoodsDay":
                    {

                        DateTime value = this.tDateEdit_ArrivalGoodsDay.GetDateTime();

                        if (value != stockTempCurrent.ArrivalGoodsDay)
                        {
                            stockTemp.ArrivalGoodsDay = value;
                            stockTemp.ExpectDeliveryDate = DateTime.MinValue;
                            if (stockTemp.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Order) stockTemp.ExpectDeliveryDate = value;

                            // 入荷伝票の場合
                            if (stockTemp.SupplierFormal == 1)
                            {
                                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "入荷日が変更されました。" + "\r\n" + "\r\n" +
                                    "商品価格を再取得しますか？",
                                    0,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxDefaultButton.Button1);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    reCalcUnitPrice = true;
                                    //reCalcCost = true;
                                }

                                double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(value);

                                // 税率が変わった場合、商品価格を再取得しない時のみ税率再計算
                                if (taxRate != stockTempCurrent.SupplierConsTaxRate)
                                {
                                    stockTemp.SupplierConsTaxRate = taxRate;

                                    if (!reCalcUnitPrice)
                                    {
                                        taxChange = true;
                                    }
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 仕入日
                case "tDateEdit_StockDate":
                    {

                        DateTime value = this.tDateEdit_StockDate.GetDateTime();

                        if (value != stockTempCurrent.StockDate)
                        {
                            stockTemp.StockDate = value;

                            // 計上日の再セット
                            this._salesSlipStockInfoInputAcs.SettingAddUpDate(ref stockTemp);

                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "仕入日が変更されました。" + "\r\n" + "\r\n" +
                                "商品価格を再取得しますか？",
                                0,
                                MessageBoxButtons.YesNo,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                reCalcUnitPrice = true;
                                //reCalcCost = true;
                            }

                            double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(value);

                            // 税率が変わった場合、商品価格を再取得しない時のみ税率再計算
                            if (taxRate != stockTempCurrent.SupplierConsTaxRate)
                            {
                                stockTemp.SupplierConsTaxRate = taxRate;

                                if (!reCalcUnitPrice)
                                {
                                    taxChange = true;
                                }
                            }

                        }

                        break;

                    }
                #endregion

                #region 相手先伝番
                case "tEdit_PartySaleSlipNum":
                    {

                        string value = this.tEdit_PartySaleSlipNum.Text.Trim();

                        if (value != stockTempCurrent.PartySaleSlipNum)
                        {
                            stockTemp.PartySaleSlipNum = value;
                        }

                        break;

                    }
                #endregion

                #region 入荷数／発注数
                case "tNedit_StockCount":
                    {
                        canChangeFocus = true;
                        double stockCount = this.tNedit_StockCount.GetValue();
                        double addUpEnableCnt = stockTemp.AddUpEnableCnt;

                        if (stockCount != stockTempCurrent.StockCount)
                        {
                            if (stockTemp.SupplierSlipCd == 20)
                            {
                                stockCount = Math.Abs(stockCount) * -1;
                            }
                            else
                            {
                                stockCount = Math.Abs(stockCount);
                            }

                            double salesTargetCnt = 0;
                            if (stockTempCurrent.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Order)
                            {
                                // 発注　→　受注数とチェック
                                salesTargetCnt = this._salesSlipStockInfoInputAcs.SalesDetailRow.AcceptAnOrderCntDisplay;
                                if (stockCount != 0)
                                {
                                    // 計上明細の場合は残数チェック
                                    if (stockTemp.EditStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                                    {
                                        if (Math.Abs(addUpEnableCnt) < Math.Abs(stockCount))
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "数量が残数量を上回る為、入力できません。",
                                                -1,
                                                MessageBoxButtons.OK);
                                            canChangeFocus = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // 仕入／入荷　→　出荷数とチェック
                                salesTargetCnt = this._salesSlipStockInfoInputAcs.SalesDetailRow.ShipmentCntDisplay;

                                if (stockCount != 0)
                                {
                                    // 計上明細の場合は残数チェック
                                    if (stockTemp.EditStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                                    {
                                        if (Math.Abs(addUpEnableCnt) < Math.Abs(stockCount))
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "数量が残数量を上回る為、入力できません。",
                                                -1,
                                                MessageBoxButtons.OK);
                                            canChangeFocus = false;
                                        }
                                    }
                                }
                            }

                            if (canChangeFocus)
                            {

                                this._salesSlipStockInfoInputAcs.SettingStockTempStockCnt(ref stockTemp, stockCount);

                                // 掛率から単価再算出
                                reCalcUnitPrice = true;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                                getNextCtrl = false;
                            }

                            // 画面格納処理
                            this.SetDisplay(stockTemp);
                        }

                        break;

                    }
                #endregion

                #region 定価
                case "tNedit_ListPrice":
                    {

                        double value = this.tNedit_ListPrice.GetValue();

                        if (value != this._salesSlipStockInfoInputAcs.GetListPriceDisplay(stockTempCurrent))
                        {
                            this._salesSlipStockInfoInputAcs.ListPriceSetting(ref stockTemp, value);

                            reCalcUnitPrice = true;
                            //reCalcSalesUnitPrice = this._salesSlipStockInfoInputAcs.SalesUnitPriceReCalcCheck(stockTemp);
                        }

                        break;

                    }
                #endregion

                #region 仕入単価
                case "tNedit_StockUnitPriceDisplay":
                    {

                        double value = this.tNedit_StockUnitPriceDisplay.GetValue();

                        if (value != this._salesSlipStockInfoInputAcs.GetUnitPriceDisplay(stockTempCurrent))
                        {
                            this._salesSlipStockInfoInputAcs.UnitPriceSetting(ref stockTemp, value);
                            reCalcStockPrice = true;
                        }

                        break;

                    }
                #endregion

                #region 注文方法
                case "tComboEditor_WayToOrder":
                    {
                        // 注文方法コンボエディタ選択値変更確定後イベントを一時的に解除
                        this.tComboEditor_WayToOrder.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_WayToOrder_SelectionChangeCommitted);

                        this.tComboEditor_WayToOrder_SelectionChangeCommitted(this.tComboEditor_WayToOrder, new EventArgs());

                        // コンボエディタのイベントで更新されている可能性があるので再度キャッシュ
                        stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

                        // 注文方法コンボエディタ選択値変更確定後イベントを挿入
                        this.tComboEditor_WayToOrder.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_WayToOrder_SelectionChangeCommitted);

                        break;
                    }
                #endregion

                #region 発注番号
                case "tEdit_OrderNumber":
                    {
                        string value = this.tEdit_OrderNumber.Text.ToString().Trim();
                        if (value != stockTemp.OrderNumber.Trim()) stockTemp.OrderNumber = value;
                        break;
                    }
                #endregion

                #region 明細備考
                case "tEdit_DtlNote":
                    {
                        string value = this.tEdit_DtlNote.Text.ToString().Trim();
                        if (value != stockTemp.StockDtiSlipNote1.Trim()) stockTemp.StockDtiSlipNote1 = value;
                        break;
                    }
                #endregion
            }

            // 税率変更
            if (taxChange)
            {
                reCalcStockPrice = true;
            }

            // 単価再計算有り(掛率から一括取得)
            if (reCalcUnitPrice)
            {
                // 単価算出
                this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);

                reCalcStockPrice = true;		// 仕入金額を再計算
            }

            // 仕入金額再計算
            if (reCalcStockPrice)
            {
                // 仕入金額再計算
                this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);
            }

            if (getNextCtrl)
            {
                Control nextCtrl = null;
                if (e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            nextCtrl = this.GetNextControl(e.PrevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            nextCtrl = this.GetNextControl(e.PrevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
                            break;
                        default:
                            break;
                    }
                }
                if (nextCtrl != null) e.NextCtrl = nextCtrl;
            }


            // メモリ上の内容と比較する
            ArrayList arRetList = stockTemp.Compare(stockTempCurrent);

            if (arRetList.Count > 0)
            {
                // 仕入データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

                // 仕入データクラス→画面格納処理
                this.SetDisplay(stockTemp);
            }

            //if (canChangeFocus)
            //{
            //    if (e.PrevCtrl == this.tComboEditor_SupplierFormal)
            //    {
            //        if (!e.ShiftKey)
            //        {
            //            switch (e.Key)
            //            {
            //                case Keys.Up:
            //                    {
            //                        if (this.GetDetailControl != null)
            //                        {
            //                            e.NextCtrl = this.GetDetailControl();
            //                        }
            //                        break;
            //                    }
            //            }
            //        }
            //    }
            //    else if (e.PrevCtrl == this.tDateEdit_ArrivalGoodsDay)
            //    {
            //        if (!e.ShiftKey)
            //        {
            //            switch (e.Key)
            //            {
            //                case Keys.Up:
            //                    {
            //                        if (this.GetDetailControl != null)
            //                        {
            //                            e.NextCtrl = this.GetDetailControl();
            //                        }
            //                        break;
            //                    }
            //            }
            //        }
            //    }
            //    else if (e.PrevCtrl == this.tEdit_StockAgentCode)
            //    {
            //        if (!e.ShiftKey)
            //        {
            //            switch (e.Key)
            //            {
            //                case Keys.Left:
            //                case Keys.Up:
            //                    {
            //                        if (this.GetDetailControl != null)
            //                        {
            //                            e.NextCtrl = this.GetDetailControl();
            //                        }
            //                        break;
            //                    }
            //            }
            //        }
            //        else
            //        {
            //            switch (e.Key)
            //            {
            //                case Keys.Tab:
            //                    {
            //                        if (this.GetDetailControl != null)
            //                        {
            //                            e.NextCtrl = this.GetDetailControl();
            //                        }
            //                        break;
            //                    }
            //            }

            //        }
            //    }
            //}

        }
        
        /// <summary>
        /// ガイドボタンEnabled
        /// </summary>
        /// <param name="nextControl"></param>
        /// <returns></returns>
        public bool GuideButtonEnabled(Control nextControl)
        {
            return (this._guideEnableControlDictionary.ContainsKey(nextControl.Name)) ? true : false;
        }

        /// <summary>
        /// ガイドボタンタグ
        /// </summary>
        /// <param name="nextControl"></param>
        /// <returns></returns>
        public string GuideButtonTag(Control nextControl)
        {
            return (this._guideEnableControlDictionary.ContainsKey(nextControl.Name)) ? this._guideEnableControlDictionary[nextControl.Name] : "";
        }

        /// <summary>
        /// ガイド起動処理
        /// </summary>
        /// <param name="tag"></param>
        public void ExecuteGuide(string tag)
        {
            switch (tag)
            {
                // 得意先ガイド
                case ctGUIDE_NAME_CustomerGuide:
                    {
                        this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, new EventArgs());
                        break;
                    }
                // 担当者ガイド
                case ctGUIDE_NAME_EmployeeGuide:
                    {
                        this.uButton_EmployeeGuide_Click(this.uButton_EmployeeGuide, new EventArgs());
                        break;
                    }
                // 倉庫ガイド
                case ctGUIDE_NAME_WarehouseGuide:
                    {
                        this.uButton_WarehouseGuide_Click(this.uButton_WarehouseGuide, new EventArgs());
                        break;
                    }
                // 仕入単価情報ガイド
                case ctGUIDE_NAME_StockUnitPriceInfo:
                    {
                        this.ExecuteUnitPriceInfoGuide();
                        break;
                    }
            }
        }

        /// <summary>
        /// タブ変更時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="key"></param>
        public void TabChanged(object sender, string key)
        {
            if (key != MAHNB01010UJ.ctTAB_KEY_StockInfo)
                return;

            if ((this.tEdit_StockAgentCode.Visible) && (this.tEdit_StockAgentCode.Enabled) && (!this.tEdit_StockAgentCode.ReadOnly))
            {
                this.tEdit_StockAgentCode.Focus();
            }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// 仕入情報データを表示します。
        /// </summary>
        /// <param name="stockTemp">仕入情報データオブジェクト</param>
        private void SetDisplay(StockTemp stockTemp)
        {
            ComponentBlanketControl.BeginUpdate(this._clearControlList);
            ComponentBlanketControl.SuspendLayout(this._clearControlList);

            try
            {
                if (stockTemp == null)
                {
                    ComponentBlanketControl.Clear(this._clearControlList);
                    ComponentBlanketControl.SetEnabled(this._clearControlList, false);
                    ComponentBlanketControl.SetVisible(this._orderControlList, false);
                    ComponentBlanketControl.SetVisible(this._stockControlList, true);
                }
                else
                {
                    // Visible設定
                    bool visibleOrder = SalesSlipInputAcs.diverge<bool>(stockTemp.SupplierFormal == 2, true, false);
                    ComponentBlanketControl.SetVisible(this._orderControlList, visibleOrder);
                    bool visibleStock = SalesSlipInputAcs.diverge<bool>(stockTemp.SupplierFormal != 2, true, false);
                    ComponentBlanketControl.SetVisible(this._stockControlList, visibleStock);

                    // Enabled設定
                    bool enabled = (stockTemp.StockSlipCdDtl == 0) ? true : false;
                    ComponentBlanketControl.SetEnabled(this._clearControlList, enabled);
                    this.tNedit_StockPriceDisplay.Enabled = false; // 仕入金額は常に無効

                    this.SupplierFormalComboEditorItemSetting(stockTemp);

                    // 伝票区分の設定
                    this.StockSlipCdComboEditorItemSetting(stockTemp.SupplierSlipCd, stockTemp.SupplierFormal);

                    // 仕入形式の設定
                    this.ChangeSupplierFormal(ref stockTemp);

                    this.tNedit_StockCount.SetValue(stockTemp.StockCount);

                    this.tEdit_StockAgentCode.Text = stockTemp.StockAgentCode;
                    this.uLabel_StockAgentName.Text = stockTemp.StockAgentName;
                    this.tNedit_CustomerCode.SetInt(stockTemp.SupplierCd);
                    this.tNedit_CustomerCode.Refresh();
                    this.uLabel_CustomerName.Text = stockTemp.SupplierSnm;
                    ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, stockTemp.SupplierFormal, true);
                    ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierSlipDisplay, SalesSlipStockInfoInputAcs.GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockTemp.SupplierSlipCd, stockTemp.AccPayDivCd), true);
                    switch ((SalesSlipStockInfoInputAcs.SupplierFormal)stockTemp.SupplierFormal)
                    {
                        case SalesSlipStockInfoInputAcs.SupplierFormal.Stock:
                            this.tDateEdit_ArrivalGoodsDay.SetDateTime(stockTemp.ArrivalGoodsDay);
                            this.tDateEdit_StockDate.Enabled = true;
                            break;
                        case SalesSlipStockInfoInputAcs.SupplierFormal.ArrivalGoods:
                            this.tDateEdit_ArrivalGoodsDay.SetDateTime(stockTemp.ArrivalGoodsDay);
                            this.tDateEdit_StockDate.Enabled = false;
                            break;
                        case SalesSlipStockInfoInputAcs.SupplierFormal.Order:
                            this.tDateEdit_ArrivalGoodsDay.SetDateTime(stockTemp.ExpectDeliveryDate);
                            this.tDateEdit_StockDate.Enabled = true;
                            break;
                    }
                    this.tDateEdit_StockDate.SetDateTime(stockTemp.StockDate);
                    this.tEdit_PartySaleSlipNum.Text = stockTemp.PartySaleSlipNum;
                    if ((stockTemp.GoodsNo != "") && (stockTemp.GoodsMakerCd != 0))
                    {
                        ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_WayToOrder, stockTemp.WayToOrder, true);
                    }

                    // 総額表示によって変わる項目
                    switch (stockTemp.SuppTtlAmntDspWayCd)
                    {
                        // 総額表示しない
                        case 0:
                            {
                                // 内税品の場合のみ税込み金額を表示する
                                if (stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                                {
                                    this.tNedit_ListPrice.SetValue(stockTemp.ListPriceTaxIncFl);
                                    this.tNedit_StockUnitPriceDisplay.SetValue(stockTemp.StockUnitTaxPriceFl);
                                    this.tNedit_StockPriceDisplay.SetValue(stockTemp.StockPriceTaxInc);
                                }
                                else
                                {
                                    this.tNedit_ListPrice.SetValue(stockTemp.ListPriceTaxExcFl);
                                    this.tNedit_StockUnitPriceDisplay.SetValue(stockTemp.StockUnitPriceFl);
                                    this.tNedit_StockPriceDisplay.SetValue(stockTemp.StockPriceTaxExc);
                                }
                                break;
                            }
                        // 総額表示する
                        case 1:
                            {
                                this.tNedit_ListPrice.SetValue(stockTemp.ListPriceTaxIncFl);
                                this.tNedit_StockUnitPriceDisplay.SetValue(stockTemp.StockUnitTaxPriceFl);
                                this.tNedit_StockPriceDisplay.SetValue(stockTemp.StockPriceTaxInc);
                                break;
                            }

                    }

                    this.tEdit_WarehouseCode.Text = stockTemp.WarehouseCode;
                    this.uLabel_WarehouseName.Text = stockTemp.WarehouseName;
                    this.tEdit_DtlNote.Text = stockTemp.StockDtiSlipNote1;
                    this.tEdit_OrderNumber.Text = stockTemp.OrderNumber;

                    if (stockTemp.EditStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                    {
                        ComponentBlanketControl.SetEnabled(this._addUpSyncList, false);
                    }
                    if (stockTemp.SupplierFormal != (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock)
                    {
                        this.uButton_PaymentConfirmation.Enabled = false;
                    }
                }
            }
            finally
            {
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
                ComponentBlanketControl.ResumeLayout(this._clearControlList);
                ComponentBlanketControl.EndUpdate(this._clearControlList);
            }
        }

        /// <summary>
        /// 画面をクリアします。
        /// </summary>
        /// <param name="isRefresh">True:クリア間の項目再描画を止めます。</param>
        private void Clear(bool isRefresh)
        {
            if (isRefresh)
            {
                ComponentBlanketControl.BeginUpdate(this._clearControlList);
            }
            try
            {
                ComponentBlanketControl.Clear(this._clearControlList);
            }
            finally
            {
                if (isRefresh)
                {
                    ComponentBlanketControl.EndUpdate(this._clearControlList);
                }
            }
        }

        /// <summary>
        /// 仕入形式設定処理
        /// </summary>
        /// <param name="supplierSlipCd">仕入伝票区分</param>
        private void SupplierFormalComboEditorItemSetting(StockTemp stockTemp)
        {
            this.tComboEditor_SupplierFormal.Items.Clear();
            if (stockTemp.EditStatus != SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
            {
                // 通常入力
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 1;
                item0.DataValue = 0;
                item0.DisplayText = "仕入";
                this.tComboEditor_SupplierFormal.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 2;
                item1.DataValue = 1;
                item1.DisplayText = "入荷";
                this.tComboEditor_SupplierFormal.Items.Add(item1);
                Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                item2.Tag = 3;
                item2.DataValue = 2;
                item2.DisplayText = "発注";
                this.tComboEditor_SupplierFormal.Items.Add(item2);
            }
            else
            {
                // 計上入力
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 1;
                item0.DataValue = 0;
                item0.DisplayText = "仕入";
                this.tComboEditor_SupplierFormal.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 2;
                item1.DataValue = 1;
                item1.DisplayText = "入荷";
                this.tComboEditor_SupplierFormal.Items.Add(item1);
            }

            this.tComboEditor_SupplierFormal.Value = stockTemp.SupplierFormal;

        }

        /// <summary>
        /// 伝票区分（表示）が、元の伝票区分の伝票区分、買掛区分と変更されたかチェックします。
        /// </summary>
        /// <param name="supplierSlipDisplay">伝票区分</param>
        /// <param name="stockTemp">仕入情報データオブジェクト</param>
        /// <returns>True:変更有り、False:変更無し</returns>
        private bool ChangeStockSlipDisplay(int stockSlipDisplay, StockTemp stockTemp)
        {
            int oldSupplierSlipDisplay = SalesSlipStockInfoInputAcs.GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockTemp.SupplierSlipCd, stockTemp.AccPayDivCd);

            if (oldSupplierSlipDisplay != stockSlipDisplay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 仕入伝票区分設定処理
        /// </summary>
        /// <param name="supplierSlipCd">仕入伝票区分</param>
        private void StockSlipCdComboEditorItemSetting(int stockSlipCd, int supplierFormal)
        {
            this.tComboEditor_SupplierSlipDisplay.Items.Clear();

            switch (stockSlipCd)
            {
                // 仕入
                case 10:
                    {

                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 1;
                        item0.DataValue = 10;
                        item0.DisplayText = "掛仕入";
                        this.tComboEditor_SupplierSlipDisplay.Items.Add(item0);

                        if (supplierFormal == 0)
                        {
                            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                            item1.Tag = 2;
                            item1.DataValue = 30;
                            item1.DisplayText = "現金仕入";
                            this.tComboEditor_SupplierSlipDisplay.Items.Add(item1);
                        }

                        this.tComboEditor_SupplierSlipDisplay.Value = 10;

                        break;
                    }
                // 返品
                case 20:
                    {
                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 1;
                        item0.DataValue = 20;
                        item0.DisplayText = "掛返品";
                        this.tComboEditor_SupplierSlipDisplay.Items.Add(item0);

                        if (supplierFormal == 0)
                        {
                            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                            item1.Tag = 2;
                            item1.DataValue = 40;
                            item1.DisplayText = "現金返品";
                            this.tComboEditor_SupplierSlipDisplay.Items.Add(item1);
                        }

                        this.tComboEditor_SupplierSlipDisplay.Value = 20;

                        break;
                    }
            }
        }

        /// <summary>
        /// コントロールインデックス取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロールの名称</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>コントロールインデックス</returns>
        private int GetGontrolIndex(string prevCtrl, SalesSlipInputAcs.MoveMethod mode)
        {
            int controlIndex = -1;

            switch (mode)
            {
                case SalesSlipInputAcs.MoveMethod.NextMove:
                    {
                        if (this._controlIndexForwordDictionary.ContainsKey(prevCtrl))
                        {
                            controlIndex = this._controlIndexForwordDictionary[prevCtrl];
                        }

                        break;
                    }
                case SalesSlipInputAcs.MoveMethod.PrevMove:
                    {
                        if (this._controlIndexBackDictionary.ContainsKey(prevCtrl))
                        {
                            controlIndex = this._controlIndexBackDictionary[prevCtrl];
                        }

                        break;
                    }
            }
            return controlIndex;
        }

        /// <summary>
        /// ネクストコントロール取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロール</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>次のコントロール</returns>
        private Control GetNextControl(Control prevCtrl, SalesSlipInputAcs.MoveMethod mode)
        {
            Control control = null;

            switch (mode)
            {
                case SalesSlipInputAcs.MoveMethod.NextMove:
                    {
                        int prevControlIndex = this.GetGontrolIndex(prevCtrl.Name, mode);

                        if ((this.tEdit_StockAgentCode.Enabled) && (!this.tEdit_StockAgentCode.ReadOnly) && (this.tEdit_StockAgentCode.Visible) && (prevCtrl != this.tEdit_StockAgentCode) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_StockAgentCode.Name, mode)))
                        {
                            control = this.tEdit_StockAgentCode;
                        }
                        else if ((this.tNedit_CustomerCode.Enabled) && (!this.tNedit_CustomerCode.ReadOnly) && (this.tNedit_CustomerCode.Visible) && (prevCtrl != this.tNedit_CustomerCode) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_CustomerCode.Name, mode)))
                        {
                            control = this.tNedit_CustomerCode;
                        }
                        else if ((this.uButton_PaymentConfirmation.Enabled) && (this.uButton_PaymentConfirmation.Visible) && (prevCtrl != this.uButton_PaymentConfirmation) && (prevControlIndex < this.GetGontrolIndex(this.uButton_PaymentConfirmation.Name, mode)))
                        {
                            control = this.uButton_PaymentConfirmation;
                        }
                        else if ((this.tEdit_WarehouseCode.Enabled) && (!this.tEdit_WarehouseCode.ReadOnly) && (this.tEdit_WarehouseCode.Visible) && (prevCtrl != this.tEdit_WarehouseCode) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_WarehouseCode.Name, mode)))
                        {
                            control = this.tEdit_WarehouseCode;
                        }
                        else if ((this.tComboEditor_SupplierFormal.Enabled) && (!this.tComboEditor_SupplierFormal.ReadOnly) && (this.tComboEditor_SupplierFormal.Visible) && (prevCtrl != this.tComboEditor_SupplierFormal) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_SupplierFormal.Name, mode)))
                        {
                            control = this.tComboEditor_SupplierFormal;
                        }
                        else if ((this.tComboEditor_SupplierSlipDisplay.Enabled) && (!this.tComboEditor_SupplierSlipDisplay.ReadOnly) && (this.tComboEditor_SupplierSlipDisplay.Visible) && (prevCtrl != this.tComboEditor_SupplierSlipDisplay) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_SupplierSlipDisplay.Name, mode)))
                        {
                            control = this.tComboEditor_SupplierSlipDisplay;
                        }
                        else if ((this.tDateEdit_ArrivalGoodsDay.Enabled) && (!this.tDateEdit_ArrivalGoodsDay.ReadOnly) && (this.tDateEdit_ArrivalGoodsDay.Visible) && (prevCtrl != this.tDateEdit_ArrivalGoodsDay) && (prevControlIndex < this.GetGontrolIndex(this.tDateEdit_ArrivalGoodsDay.Name, mode)))
                        {
                            control = this.tDateEdit_ArrivalGoodsDay;
                        }
                        else if ((this.tDateEdit_StockDate.Enabled) && (!this.tDateEdit_StockDate.ReadOnly) && (this.tDateEdit_StockDate.Visible) && (prevCtrl != this.tDateEdit_StockDate) && (prevControlIndex < this.GetGontrolIndex(this.tDateEdit_StockDate.Name, mode)))
                        {
                            control = this.tDateEdit_StockDate;
                        }
                        else if ((this.tEdit_PartySaleSlipNum.Enabled) && (!this.tEdit_PartySaleSlipNum.ReadOnly) && (this.tEdit_PartySaleSlipNum.Visible) && (this.tEdit_PartySaleSlipNum.Visible) && (prevCtrl != this.tEdit_PartySaleSlipNum) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_PartySaleSlipNum.Name, mode)))
                        {
                            control = this.tEdit_PartySaleSlipNum;
                        }
                        else if ((this.tNedit_StockCount.Enabled) && (!this.tNedit_StockCount.ReadOnly) && (this.tNedit_StockCount.Visible) && (prevCtrl != this.tNedit_StockCount) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_StockCount.Name, mode)))
                        {
                            control = this.tNedit_StockCount;
                        }
                        else if ((this.tComboEditor_UnitCode.Enabled) && (!this.tComboEditor_UnitCode.ReadOnly) && (this.tComboEditor_UnitCode.Visible) && (prevCtrl != this.tComboEditor_UnitCode) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_UnitCode.Name, mode)))
                        {
                            control = this.tComboEditor_UnitCode;
                        }
                        else if ((this.tNedit_ListPrice.Enabled) && (!this.tNedit_ListPrice.ReadOnly) && (this.tNedit_ListPrice.Visible) && (prevCtrl != this.tNedit_ListPrice) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_ListPrice.Name, mode)))
                        {
                            control = this.tNedit_ListPrice;
                        }
                        else if ((this.tNedit_StockUnitPriceDisplay.Enabled) && (!this.tNedit_StockUnitPriceDisplay.ReadOnly) && (this.tNedit_StockUnitPriceDisplay.Visible) && (prevCtrl != this.tNedit_StockUnitPriceDisplay) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_StockUnitPriceDisplay.Name, mode)))
                        {
                            control = this.tNedit_StockUnitPriceDisplay;
                        }
                        else if ((this.tNedit_StockPriceDisplay.Enabled) && (!this.tNedit_StockPriceDisplay.ReadOnly) && (this.tNedit_StockPriceDisplay.Visible) && (prevCtrl != this.tNedit_StockPriceDisplay) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_StockPriceDisplay.Name, mode)))
                        {
                            control = this.tNedit_StockPriceDisplay;
                        }
                        else if ((this.tComboEditor_WayToOrder.Enabled) && (!this.tComboEditor_WayToOrder.ReadOnly) && (this.tComboEditor_WayToOrder.Visible) && (prevCtrl != this.tComboEditor_WayToOrder) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_WayToOrder.Name, mode)))
                        {
                            control = this.tComboEditor_WayToOrder;
                        }
                        else if ((this.tComboEditor_StockBargainCd.Enabled) && (!this.tComboEditor_StockBargainCd.ReadOnly) && (this.tComboEditor_StockBargainCd.Visible) && (prevCtrl != this.tComboEditor_StockBargainCd) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_StockBargainCd.Name, mode)))
                        {
                            control = this.tComboEditor_StockBargainCd;
                        }
                        else if ((this.tEdit_OrderNumber.Enabled) && (!this.tEdit_OrderNumber.ReadOnly) && (this.tEdit_OrderNumber.Visible) && (prevCtrl != this.tEdit_OrderNumber) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_OrderNumber.Name, mode)))
                        {
                            control = this.tEdit_OrderNumber;
                        }
                        else if ((this.tEdit_DtlNote.Enabled) && (!this.tEdit_DtlNote.ReadOnly) && (this.tEdit_DtlNote.Visible) && (prevCtrl != this.tEdit_DtlNote) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_DtlNote.Name, mode)))
                        {
                            control = this.tEdit_DtlNote;
                        }

                        break;
                    }
                case SalesSlipInputAcs.MoveMethod.PrevMove:
                    {
                        int prevControlIndex = this.GetGontrolIndex(prevCtrl.Name, mode);

                        if ((this.tEdit_DtlNote.Enabled) && (!this.tEdit_DtlNote.ReadOnly) && (this.tEdit_DtlNote.Visible) && (prevCtrl != this.tEdit_DtlNote) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_DtlNote.Name, mode)))
                        {
                            control = this.tEdit_DtlNote;
                        } 
                        else if ((this.tEdit_OrderNumber.Enabled) && (!this.tEdit_OrderNumber.ReadOnly) && (this.tEdit_OrderNumber.Visible) && (prevCtrl != this.tEdit_OrderNumber) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_OrderNumber.Name, mode)))
                        {
                            control = this.tEdit_OrderNumber;
                        }
                        else if ((this.tComboEditor_StockBargainCd.Enabled) && (!this.tComboEditor_StockBargainCd.ReadOnly) && (this.tComboEditor_StockBargainCd.Visible) && (prevCtrl != this.tComboEditor_StockBargainCd) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_StockBargainCd.Name, mode)))
                        {
                            control = this.tComboEditor_StockBargainCd;
                        }
                        else if ((this.tComboEditor_WayToOrder.Enabled) && (!this.tComboEditor_WayToOrder.ReadOnly) && (this.tComboEditor_WayToOrder.Visible) && (prevCtrl != this.tComboEditor_WayToOrder) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_WayToOrder.Name, mode)))
                        {
                            control = this.tComboEditor_WayToOrder;
                        }
                        else if ((this.tNedit_StockPriceDisplay.Enabled) && (!this.tNedit_StockPriceDisplay.ReadOnly) && (this.tNedit_StockPriceDisplay.Visible) && (prevCtrl != this.tNedit_StockPriceDisplay) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_StockPriceDisplay.Name, mode)))
                        {
                            control = this.tNedit_StockPriceDisplay;
                        }
                        else if ((this.tNedit_StockUnitPriceDisplay.Enabled) && (!this.tNedit_StockUnitPriceDisplay.ReadOnly) && (this.tNedit_StockUnitPriceDisplay.Visible) && (prevCtrl != this.tNedit_StockUnitPriceDisplay) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_StockUnitPriceDisplay.Name, mode)))
                        {
                            control = this.tNedit_StockUnitPriceDisplay;
                        }
                        else if ((this.tNedit_ListPrice.Enabled) && (!this.tNedit_ListPrice.ReadOnly) && (this.tNedit_ListPrice.Visible) && (prevCtrl != this.tNedit_ListPrice) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_ListPrice.Name, mode)))
                        {
                            control = this.tNedit_ListPrice;
                        }
                        else if ((this.tComboEditor_UnitCode.Enabled) && (!this.tComboEditor_UnitCode.ReadOnly) && (this.tComboEditor_UnitCode.Visible) && (prevCtrl != this.tComboEditor_UnitCode) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_UnitCode.Name, mode)))
                        {
                            control = this.tComboEditor_UnitCode;
                        }
                        else if ((this.tNedit_StockCount.Enabled) && (!this.tNedit_StockCount.ReadOnly) && (this.tNedit_StockCount.Visible) && (prevCtrl != this.tNedit_StockCount) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_StockCount.Name, mode)))
                        {
                            control = this.tNedit_StockCount;
                        }
                        else if ((this.tEdit_PartySaleSlipNum.Enabled) && (!this.tEdit_PartySaleSlipNum.ReadOnly) && (this.tEdit_PartySaleSlipNum.Visible) && (this.tEdit_PartySaleSlipNum.Visible) && (prevCtrl != this.tEdit_PartySaleSlipNum) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_PartySaleSlipNum.Name, mode)))
                        {
                            control = this.tEdit_PartySaleSlipNum;
                        }
                        else if ((this.tDateEdit_StockDate.Enabled) && (!this.tDateEdit_StockDate.ReadOnly) && (this.tDateEdit_StockDate.Visible) && (prevCtrl != this.tDateEdit_StockDate) && (prevControlIndex < this.GetGontrolIndex(this.tDateEdit_StockDate.Name, mode)))
                        {
                            control = this.tDateEdit_StockDate;
                        }
                        else if ((this.tDateEdit_ArrivalGoodsDay.Enabled) && (!this.tDateEdit_ArrivalGoodsDay.ReadOnly) && (this.tDateEdit_ArrivalGoodsDay.Visible) && (prevCtrl != this.tDateEdit_ArrivalGoodsDay) && (prevControlIndex < this.GetGontrolIndex(this.tDateEdit_ArrivalGoodsDay.Name, mode)))
                        {
                            control = this.tDateEdit_ArrivalGoodsDay;
                        }
                        else if ((this.tComboEditor_SupplierSlipDisplay.Enabled) && (!this.tComboEditor_SupplierSlipDisplay.ReadOnly) && (this.tComboEditor_SupplierSlipDisplay.Visible) && (prevCtrl != this.tComboEditor_SupplierSlipDisplay) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_SupplierSlipDisplay.Name, mode)))
                        {
                            control = this.tComboEditor_SupplierSlipDisplay;
                        }
                        else if ((this.tComboEditor_SupplierFormal.Enabled) && (!this.tComboEditor_SupplierFormal.ReadOnly) && (this.tComboEditor_SupplierFormal.Visible) && (prevCtrl != this.tComboEditor_SupplierFormal) && (prevControlIndex < this.GetGontrolIndex(this.tComboEditor_SupplierFormal.Name, mode)))
                        {
                            control = this.tComboEditor_SupplierFormal;
                        }
                        else if ((this.tEdit_WarehouseCode.Enabled) && (!this.tEdit_WarehouseCode.ReadOnly) && (this.tEdit_WarehouseCode.Visible) && (prevCtrl != this.tEdit_WarehouseCode) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_WarehouseCode.Name, mode)))
                        {
                            control = this.tEdit_WarehouseCode;
                        }
                        else if ((this.uButton_PaymentConfirmation.Enabled) && (this.uButton_PaymentConfirmation.Visible) && (prevCtrl != this.uButton_PaymentConfirmation) && (prevControlIndex < this.GetGontrolIndex(this.uButton_PaymentConfirmation.Name, mode)))
                        {
                            control = this.uButton_PaymentConfirmation;
                        }
                        else if ((this.tNedit_CustomerCode.Enabled) && (!this.tNedit_CustomerCode.ReadOnly) && (this.tNedit_CustomerCode.Visible) && (prevCtrl != this.tNedit_CustomerCode) && (prevControlIndex < this.GetGontrolIndex(this.tNedit_CustomerCode.Name, mode)))
                        {
                            control = this.tNedit_CustomerCode;
                        }
                        else if ((this.tEdit_StockAgentCode.Enabled) && (!this.tEdit_StockAgentCode.ReadOnly) && (this.tEdit_StockAgentCode.Visible) && (prevCtrl != this.tEdit_StockAgentCode) && (prevControlIndex < this.GetGontrolIndex(this.tEdit_StockAgentCode.Name, mode)))
                        {
                            control = this.tEdit_StockAgentCode;
                        }
                        
                        break;
                    }
            }

            return control;
        }

        /// <summary>
        /// 単価情報ガイド起動処理
        /// </summary>
        /// <param name="displayType">画面タイプ</param>
        private void ExecuteUnitPriceInfoGuide()
        {
            // 現在の同時売上情報を取得
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

            // 画面タイプに従った単価情報画面パラメータを生成
            DCKHN01050UA unitPriceInfo = new DCKHN01050UA();

            UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

            unPrcInfoConf = this._salesSlipStockInfoInputAcs.GetUnitPriceInfoConf(stockTemp);

            DialogResult dialogResult = unitPriceInfo.ShowDialog(this, DCKHN01050UA.DisplayType.UnitCost, unPrcInfoConf);

            if (dialogResult == DialogResult.OK)
            {
                // 単価情報設定処理
                this._salesSlipStockInfoInputAcs.UnPrcInfoSetting(unitPriceInfo.UnPrcInfoConfRet, ref stockTemp);

                // 売上金額再計算
                this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);

                // データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

                // データクラス→画面格納処理
                this.SetDisplay(stockTemp);
            }
        }
        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region ■Control Events
        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAHNB01010UJ_Load(object sender, EventArgs e)
        {
            // ガイドボタンイメージ設定
            this.uButton_EmployeeGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// 仕入担当担当ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employeeAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;

                stockTemp.StockAgentCode = employee.EmployeeCode.Trim();
                stockTemp.StockAgentName = employee.Name.Trim();

                int subSectionCode;
                this._salesSlipInputInitDataAcs.GetSubSection_FromEmployeeDtl(stockTemp.StockAgentCode, out subSectionCode);
                stockTemp.SubSectionCode = subSectionCode;

                if (stockTemp.StockAgentName.Length > 16)
                {
                    stockTemp.StockAgentName = stockTemp.StockAgentName.Substring(0, 16);
                }

                this._salesSlipStockInfoInputAcs.SettingStockTempStockFromAgentBelongInfo(ref stockTemp);

                // 仕入情報データクラス→画面格納処理
                this.SetDisplay(stockTemp);

                // 仕入情報データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

            }
        }

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;
            string selectedSectionCode = stockTemp.SectionCode;
            Warehouse warehouse;

            WarehouseAcs warehouseAcs = new WarehouseAcs();
            warehouseAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
            int status = warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, selectedSectionCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;
                stockTemp.WarehouseCode = warehouse.WarehouseCode.Trim();
                stockTemp.WarehouseName = warehouse.WarehouseName;

                // 仕入情報データクラス→画面格納処理
                this.SetDisplay(stockTemp);

                // 仕入情報データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }
        }

        /// <summary>
        /// 得意先ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            Supplier supplier;
            this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
            this.SettingSupplier(false, supplier);
        }

        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="isClear">true:クリアする false:クリアしない</param>
        /// <param name="supplier">仕入先情報データクラス</param>
        private void SettingSupplier(bool isClear, Supplier supplier)
        {
            if (isClear)
            {
                // 画面初期化処理
                this.Clear(true);
            }

            // 仕入先を自動で設定
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

            bool reCalcUnitPrice = false;		// 掛率による売上単価、定価、売上原価単価再計算有無
            Supplier supplierTemp;
            this.Cursor = Cursors.WaitCursor;
            int status = this._supplierAcs.Read(out supplierTemp, supplier.EnterpriseCode, supplier.SupplierCd);
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (supplierTemp == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した仕入先は仕入先情報入力が行われていない為、使用できません。",
                        status,
                        MessageBoxButtons.OK);

                    return;
                }
                else
                {
                    if (supplierTemp.SupplierCd != stockTemp.SupplierCd)
                    {
                        reCalcUnitPrice = true;
                        // 得意先（仕入先）情報設定処理
                        this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplierTemp);

                        // 単価再計算
                        this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);

                        this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);

                    }
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "仕入先が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "仕入先の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }

            if (reCalcUnitPrice)
            {
                // 単価算出
                this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);

                // 売上金額再計算
                this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);
            }

            // キャッシュ処理
            this._salesSlipStockInfoInputAcs.Cache(stockTemp);

            // 画面格納処理
            this.SetDisplay(stockTemp);

        }

        /// <summary>
        /// 伝票種別コンボエディタ選択値変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_SupplierFormal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SupplierFormal, ComboEditorGetDataType.TAG);

            if (code != stockTemp.SupplierFormal)
            {
                if (code != -1)
                {
                    stockTemp.SupplierFormal = code;
                }
                else
                {
                    stockTemp.SupplierFormal = (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock;
                }

                switch (stockTemp.SupplierFormal)
                {
                    // 仕入形式が「仕入」の場合
                    case 0:
                        {
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// 仕入日
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // 計上日

                            break;
                        }
                    // 仕入形式が「入荷」の場合
                    case 1:
                        {
                            stockTemp.AccPayDivCd = 1;							// 買掛有り固定
                            stockTemp.StockAddUpADate = DateTime.MinValue;		// 計上日をクリアする
                            stockTemp.StockDate = DateTime.MinValue;			// 売上日をクリアする
                            break;
                        }
                    // 仕入形式が「発注」の場合
                    case 2:
                        {
                            stockTemp.AccPayDivCd = 1;							// 買掛有り固定
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// 発注日
                            }

                            if (stockTemp.ExpectDeliveryDate == DateTime.MinValue)
                            {
                                stockTemp.ExpectDeliveryDate = stockTemp.ArrivalGoodsDay;
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // 計上日

                            break;
                        }
                }

                // 仕入情報データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }

            // 仕入情報データクラス→画面格納処理
            this.SetDisplay(stockTemp);
        }

        /// <summary>
        /// 伝票種別変更後処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ChangeSupplierFormal(ref StockTemp stockTemp)
        {
            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SupplierFormal, ComboEditorGetDataType.TAG);

                if (code != -1)
                {
                    stockTemp.SupplierFormal = code;
                }
                else
                {
                    stockTemp.SupplierFormal = (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock;
                }

                switch (stockTemp.SupplierFormal)
                {
                    // 仕入形式が「仕入」の場合
                    case 0:
                        {
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// 仕入日
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // 計上日

                            break;
                        }
                    // 仕入形式が「入荷」の場合
                    case 1:
                        {
                            stockTemp.AccPayDivCd = 1;							// 買掛有り固定
                            stockTemp.StockAddUpADate = DateTime.MinValue;		// 計上日をクリアする
                            stockTemp.StockDate = DateTime.MinValue;			// 売上日をクリアする
                            break;
                        }
                    // 仕入形式が「発注」の場合
                    case 2:
                        {
                            stockTemp.AccPayDivCd = 1;							// 買掛有り固定
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// 発注日
                            }

                            if (stockTemp.ExpectDeliveryDate == DateTime.MinValue)
                            {
                                stockTemp.ExpectDeliveryDate = stockTemp.ArrivalGoodsDay;
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // 計上日

                            break;
                        }
                }

                // 仕入情報データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            
        }

        /// <summary>
        /// 注文方法コンボエディタ選択値変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_WayToOrder_SelectionChangeCommitted(object sender, EventArgs e)
        {
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_WayToOrder, ComboEditorGetDataType.TAG);

            string name = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_WayToOrder, code);

            if (code != stockTemp.WayToOrder)
            {
                if (code != -1)
                {
                    // 入力したIndexが範囲内の場合、入力値より各種情報設定
                    stockTemp.WayToOrder = code;
                }
                else
                {
                    // 入力したIndexが範囲外の場合、初期値設定
                    stockTemp.WayToOrder = 0;
                }

                // 仕入情報データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

                // 仕入情報データクラス→画面格納処理
                this.SetDisplay(stockTemp);
            }
        }

        /// <summary>
        /// 伝票区分コンボエディタ選択値変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_SupplierSlipCdDisplay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;
            bool changeSupplierSlipDisplay = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SupplierSlipDisplay, ComboEditorGetDataType.TAG);

            if (code == -1)
            {
                code = 0;
            }

            changeSupplierSlipDisplay = ChangeStockSlipDisplay(code, stockTemp);

            if (changeSupplierSlipDisplay)
            {
                SalesSlipStockInfoInputAcs.SetSlipCdAndAccPayDivCdFromDisplay(code, ref stockTemp);

                // 売上データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }

            // 売上データクラス→画面格納処理
            this.SetDisplay(stockTemp);
        }

        /// <summary>
        /// 支払先確認ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_PaymentConfirmation_Click(object sender, EventArgs e)
        {

            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;

            if (stockTemp.SupplierCd == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "仕入先が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            // ウインドウ起動
            DialogResult dialogResult = _demandConfirm.ShowDialog(this, stockTemp.PayeeCode, stockTemp.StockAddUpSectionCd, tDateEdit_StockDate.GetDateTime(), stockTemp.StockAddUpADate, stockTemp.DelayPaymentDiv, CustomerClaimConfAcs.GuideType.Payment);

            if (dialogResult == DialogResult.OK)
            {
                CustomerClaimConf retCustomerClaimConf = this._demandConfirm.CustomerClaimConf;
                stockTemp.PayeeCode = retCustomerClaimConf.CustomerCode;
                stockTemp.PayeeSnm = retCustomerClaimConf.CustomerSnm;
                stockTemp.SuppCTaxLayCd = retCustomerClaimConf.ConsTaxLayMethod;
                stockTemp.DelayPaymentDiv = retCustomerClaimConf.CollectMoneyCode;
                stockTemp.StockAddUpADate = retCustomerClaimConf.AddUpADate;
                stockTemp.SuppTtlAmntDspWayCd = retCustomerClaimConf.TotalAmountDispWayCd;
                stockTemp.SuppCTaxLayCd = retCustomerClaimConf.ConsTaxLayMethod;
                stockTemp.StockSectionCd = retCustomerClaimConf.AddUpSectionCode;
                stockTemp.DelayPaymentDiv = retCustomerClaimConf.CollectMoneyCode;
                stockTemp.TotalDay = retCustomerClaimConf.TotalDay;
                stockTemp.NTimeCalcStDate = retCustomerClaimConf.NTimeCalcStDate;


                // 仕入情報データクラス→画面格納処理
                this.SetDisplay(stockTemp);

                // 仕入情報データキャッシュ処理
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }
        }
        #endregion
    }
}
