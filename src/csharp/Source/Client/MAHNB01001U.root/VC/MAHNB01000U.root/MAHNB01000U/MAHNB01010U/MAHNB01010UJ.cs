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
    /// ���d���������̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̎d�������͂��s���R���g���[���N���X�ł��B�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.01.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.01.21 20056 ���n ��� �V�K�쐬</br>
    /// </remarks>
    public partial class MAHNB01010UJ : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
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
            // �d�����̓^�u�̓^�u�I�����Ƀ��[�h�����ׁA�R���|�̐ݒ肪�L���ɂȂ�Ȃ��̂�
            // �d�����͉�ʃ��[�h�O��UiSetControl�̊e��ݒ菈�����s��
            //------------------------------------------------------------------------------
            this.uiSetControl1.SettingFormBeforeLoad();

        }
        #endregion

        //// ===================================================================================== //
        //// �f���Q�[�g&�C�x���g
        //// ===================================================================================== //
        //# region ��Delegate&Event
        ///// <summary>���׃R���|�擾�f���Q�[�g</summary>
        ///// <returns>���ׂ̃R���|�[�l���g</returns>
        //internal delegate Control GetDetailControlEventHandler();

        //internal GetDetailControlEventHandler GetDetailControl;
        //#endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Private Members
        private ImageList _imageList16 = null;											// �C���[�W���X�g
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesSlipStockInfoInputAcs _salesSlipStockInfoInputAcs;

        private List<Control> _clearControlList;
        private List<Control> _stockControlList; // �d�����^�C�g���R���g���[�����X�g
        private List<Control> _orderControlList; // �������^�C�g���R���g���[�����X�g
        private List<Control> _writeAfterList; // ������R���g���[�����X�g
        private List<Control> _addUpSyncList; // �v�㎞�R���g���[�����X�g
        
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
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ��Public Methods
        /// <summary>
        /// �t�H�[�J�X�ύX���\�b�h�iChangeFocus��e�t�H�[���ŃL���b�`����̂ŁA���̃��\�b�h�Ń`�F�b�N�����s���܂��j
        /// </summary>
        /// <param name="prevCtrl">���݂̃t�H�[�J�X�R���g���[��</param>
        /// <param name="nextCtrl">���̃t�H�[�J�X�R���g���[��</param>
        public void StockInfo_ChangeFocus(ref Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (this._salesSlipStockInfoInputAcs.StockTemp == null) return;

            StockTemp stockTempCurrent = this._salesSlipStockInfoInputAcs.StockTemp.Clone();
            StockTemp stockTemp = stockTempCurrent.Clone();
            bool reCalcUnitPrice = false;		// �|���ɂ�锄��P���A�艿�A���㌴���P���Čv�Z�L��
            bool reCalcStockPrice = false;		// ������z�Čv�Z�L��
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
                #region �d���S��
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
                                            "�]�ƈ������݂��܂���B",
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

                #region �d����
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
                                    // ���Ӑ�i�d����j���ݒ菈��
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
                                    // �d������ݒ菈��
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
                                        "�d���悪���݂��܂���B",
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
                                        "�d����̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // ��ʊi�[����
                            this.SetDisplay(stockTemp);
                        }

                        // NextCtrl����
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

                #region �q�ɃR�[�h
                //---------------------------------------------------------------
                // �q�ɃR�[�h
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
                                        "�q�ɂ����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                    code = "";
                                }

                                stockTemp.WarehouseCode = code;
                                stockTemp.WarehouseName = name;
                            }

                            // �d���f�[�^�N���X����ʊi�[����
                            this.SetDisplay(stockTemp);
                        }

                        // NextCtrl����
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

                #region �`�[���
                case "tComboEditor_SupplierFormal":
                    {

                        // �`�[��ʃR���{�G�f�B�^�I��l�ύX�m���C�x���g���ꎞ�I�ɉ���
                        this.tComboEditor_SupplierFormal.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChangeCommitted);

                        this.tComboEditor_SupplierFormal_SelectionChangeCommitted(this.tComboEditor_AccPayDivCd, new EventArgs());

                        // �R���{�G�f�B�^�̃C�x���g�ōX�V����Ă���\��������̂ōēx�L���b�V��
                        stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

                        // �`�[��ʃR���{�G�f�B�^�I��l�ύX�m���C�x���g��}��
                        this.tComboEditor_SupplierFormal.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChangeCommitted);

                        break;

                    }
                #endregion

                #region �`�[�敪
                case "tComboEditor_SupplierSlipDisplay":
                    {

                        // �`�[�敪�R���{�G�f�B�^�I��l�ύX�m���C�x���g���ꎞ�I�ɉ���
                        this.tComboEditor_SupplierSlipDisplay.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SupplierSlipCdDisplay_SelectionChangeCommitted);

                        this.tComboEditor_SupplierSlipCdDisplay_SelectionChangeCommitted(this.tComboEditor_SupplierSlipDisplay, new EventArgs());

                        // �R���{�G�f�B�^�̃C�x���g�ōX�V����Ă���\��������̂ōēx�L���b�V��
                        stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

                        // �`�[�敪�R���{�G�f�B�^�I��l�ύX�m���C�x���g��}��
                        this.tComboEditor_SupplierSlipDisplay.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SupplierSlipCdDisplay_SelectionChangeCommitted);

                        break;

                    }
                #endregion

                #region ���ד�
                case "tDateEdit_ArrivalGoodsDay":
                    {

                        DateTime value = this.tDateEdit_ArrivalGoodsDay.GetDateTime();

                        if (value != stockTempCurrent.ArrivalGoodsDay)
                        {
                            stockTemp.ArrivalGoodsDay = value;
                            stockTemp.ExpectDeliveryDate = DateTime.MinValue;
                            if (stockTemp.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Order) stockTemp.ExpectDeliveryDate = value;

                            // ���ד`�[�̏ꍇ
                            if (stockTemp.SupplierFormal == 1)
                            {
                                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "���ד����ύX����܂����B" + "\r\n" + "\r\n" +
                                    "���i���i���Ď擾���܂����H",
                                    0,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxDefaultButton.Button1);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    reCalcUnitPrice = true;
                                    //reCalcCost = true;
                                }

                                double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(value);

                                // �ŗ����ς�����ꍇ�A���i���i���Ď擾���Ȃ����̂ݐŗ��Čv�Z
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

                #region �d����
                case "tDateEdit_StockDate":
                    {

                        DateTime value = this.tDateEdit_StockDate.GetDateTime();

                        if (value != stockTempCurrent.StockDate)
                        {
                            stockTemp.StockDate = value;

                            // �v����̍ăZ�b�g
                            this._salesSlipStockInfoInputAcs.SettingAddUpDate(ref stockTemp);

                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�d�������ύX����܂����B" + "\r\n" + "\r\n" +
                                "���i���i���Ď擾���܂����H",
                                0,
                                MessageBoxButtons.YesNo,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                reCalcUnitPrice = true;
                                //reCalcCost = true;
                            }

                            double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(value);

                            // �ŗ����ς�����ꍇ�A���i���i���Ď擾���Ȃ����̂ݐŗ��Čv�Z
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

                #region �����`��
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

                #region ���א��^������
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
                                // �����@���@�󒍐��ƃ`�F�b�N
                                salesTargetCnt = this._salesSlipStockInfoInputAcs.SalesDetailRow.AcceptAnOrderCntDisplay;
                                if (stockCount != 0)
                                {
                                    // �v�㖾�ׂ̏ꍇ�͎c���`�F�b�N
                                    if (stockTemp.EditStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                                    {
                                        if (Math.Abs(addUpEnableCnt) < Math.Abs(stockCount))
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "���ʂ��c���ʂ�����ׁA���͂ł��܂���B",
                                                -1,
                                                MessageBoxButtons.OK);
                                            canChangeFocus = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // �d���^���ׁ@���@�o�א��ƃ`�F�b�N
                                salesTargetCnt = this._salesSlipStockInfoInputAcs.SalesDetailRow.ShipmentCntDisplay;

                                if (stockCount != 0)
                                {
                                    // �v�㖾�ׂ̏ꍇ�͎c���`�F�b�N
                                    if (stockTemp.EditStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                                    {
                                        if (Math.Abs(addUpEnableCnt) < Math.Abs(stockCount))
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "���ʂ��c���ʂ�����ׁA���͂ł��܂���B",
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

                                // �|������P���ĎZ�o
                                reCalcUnitPrice = true;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                                getNextCtrl = false;
                            }

                            // ��ʊi�[����
                            this.SetDisplay(stockTemp);
                        }

                        break;

                    }
                #endregion

                #region �艿
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

                #region �d���P��
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

                #region �������@
                case "tComboEditor_WayToOrder":
                    {
                        // �������@�R���{�G�f�B�^�I��l�ύX�m���C�x���g���ꎞ�I�ɉ���
                        this.tComboEditor_WayToOrder.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_WayToOrder_SelectionChangeCommitted);

                        this.tComboEditor_WayToOrder_SelectionChangeCommitted(this.tComboEditor_WayToOrder, new EventArgs());

                        // �R���{�G�f�B�^�̃C�x���g�ōX�V����Ă���\��������̂ōēx�L���b�V��
                        stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

                        // �������@�R���{�G�f�B�^�I��l�ύX�m���C�x���g��}��
                        this.tComboEditor_WayToOrder.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_WayToOrder_SelectionChangeCommitted);

                        break;
                    }
                #endregion

                #region �����ԍ�
                case "tEdit_OrderNumber":
                    {
                        string value = this.tEdit_OrderNumber.Text.ToString().Trim();
                        if (value != stockTemp.OrderNumber.Trim()) stockTemp.OrderNumber = value;
                        break;
                    }
                #endregion

                #region ���ה��l
                case "tEdit_DtlNote":
                    {
                        string value = this.tEdit_DtlNote.Text.ToString().Trim();
                        if (value != stockTemp.StockDtiSlipNote1.Trim()) stockTemp.StockDtiSlipNote1 = value;
                        break;
                    }
                #endregion
            }

            // �ŗ��ύX
            if (taxChange)
            {
                reCalcStockPrice = true;
            }

            // �P���Čv�Z�L��(�|������ꊇ�擾)
            if (reCalcUnitPrice)
            {
                // �P���Z�o
                this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);

                reCalcStockPrice = true;		// �d�����z���Čv�Z
            }

            // �d�����z�Čv�Z
            if (reCalcStockPrice)
            {
                // �d�����z�Čv�Z
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


            // ��������̓��e�Ɣ�r����
            ArrayList arRetList = stockTemp.Compare(stockTempCurrent);

            if (arRetList.Count > 0)
            {
                // �d���f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

                // �d���f�[�^�N���X����ʊi�[����
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
        /// �K�C�h�{�^��Enabled
        /// </summary>
        /// <param name="nextControl"></param>
        /// <returns></returns>
        public bool GuideButtonEnabled(Control nextControl)
        {
            return (this._guideEnableControlDictionary.ContainsKey(nextControl.Name)) ? true : false;
        }

        /// <summary>
        /// �K�C�h�{�^���^�O
        /// </summary>
        /// <param name="nextControl"></param>
        /// <returns></returns>
        public string GuideButtonTag(Control nextControl)
        {
            return (this._guideEnableControlDictionary.ContainsKey(nextControl.Name)) ? this._guideEnableControlDictionary[nextControl.Name] : "";
        }

        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        /// <param name="tag"></param>
        public void ExecuteGuide(string tag)
        {
            switch (tag)
            {
                // ���Ӑ�K�C�h
                case ctGUIDE_NAME_CustomerGuide:
                    {
                        this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, new EventArgs());
                        break;
                    }
                // �S���҃K�C�h
                case ctGUIDE_NAME_EmployeeGuide:
                    {
                        this.uButton_EmployeeGuide_Click(this.uButton_EmployeeGuide, new EventArgs());
                        break;
                    }
                // �q�ɃK�C�h
                case ctGUIDE_NAME_WarehouseGuide:
                    {
                        this.uButton_WarehouseGuide_Click(this.uButton_WarehouseGuide, new EventArgs());
                        break;
                    }
                // �d���P�����K�C�h
                case ctGUIDE_NAME_StockUnitPriceInfo:
                    {
                        this.ExecuteUnitPriceInfoGuide();
                        break;
                    }
            }
        }

        /// <summary>
        /// �^�u�ύX�������C�x���g
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
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// �d�����f�[�^��\�����܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����f�[�^�I�u�W�F�N�g</param>
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
                    // Visible�ݒ�
                    bool visibleOrder = SalesSlipInputAcs.diverge<bool>(stockTemp.SupplierFormal == 2, true, false);
                    ComponentBlanketControl.SetVisible(this._orderControlList, visibleOrder);
                    bool visibleStock = SalesSlipInputAcs.diverge<bool>(stockTemp.SupplierFormal != 2, true, false);
                    ComponentBlanketControl.SetVisible(this._stockControlList, visibleStock);

                    // Enabled�ݒ�
                    bool enabled = (stockTemp.StockSlipCdDtl == 0) ? true : false;
                    ComponentBlanketControl.SetEnabled(this._clearControlList, enabled);
                    this.tNedit_StockPriceDisplay.Enabled = false; // �d�����z�͏�ɖ���

                    this.SupplierFormalComboEditorItemSetting(stockTemp);

                    // �`�[�敪�̐ݒ�
                    this.StockSlipCdComboEditorItemSetting(stockTemp.SupplierSlipCd, stockTemp.SupplierFormal);

                    // �d���`���̐ݒ�
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

                    // ���z�\���ɂ���ĕς�鍀��
                    switch (stockTemp.SuppTtlAmntDspWayCd)
                    {
                        // ���z�\�����Ȃ�
                        case 0:
                            {
                                // ���ŕi�̏ꍇ�̂ݐō��݋��z��\������
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
                        // ���z�\������
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
        /// ��ʂ��N���A���܂��B
        /// </summary>
        /// <param name="isRefresh">True:�N���A�Ԃ̍��ڍĕ`����~�߂܂��B</param>
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
        /// �d���`���ݒ菈��
        /// </summary>
        /// <param name="supplierSlipCd">�d���`�[�敪</param>
        private void SupplierFormalComboEditorItemSetting(StockTemp stockTemp)
        {
            this.tComboEditor_SupplierFormal.Items.Clear();
            if (stockTemp.EditStatus != SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
            {
                // �ʏ����
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 1;
                item0.DataValue = 0;
                item0.DisplayText = "�d��";
                this.tComboEditor_SupplierFormal.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 2;
                item1.DataValue = 1;
                item1.DisplayText = "����";
                this.tComboEditor_SupplierFormal.Items.Add(item1);
                Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                item2.Tag = 3;
                item2.DataValue = 2;
                item2.DisplayText = "����";
                this.tComboEditor_SupplierFormal.Items.Add(item2);
            }
            else
            {
                // �v�����
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 1;
                item0.DataValue = 0;
                item0.DisplayText = "�d��";
                this.tComboEditor_SupplierFormal.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 2;
                item1.DataValue = 1;
                item1.DisplayText = "����";
                this.tComboEditor_SupplierFormal.Items.Add(item1);
            }

            this.tComboEditor_SupplierFormal.Value = stockTemp.SupplierFormal;

        }

        /// <summary>
        /// �`�[�敪�i�\���j���A���̓`�[�敪�̓`�[�敪�A���|�敪�ƕύX���ꂽ���`�F�b�N���܂��B
        /// </summary>
        /// <param name="supplierSlipDisplay">�`�[�敪</param>
        /// <param name="stockTemp">�d�����f�[�^�I�u�W�F�N�g</param>
        /// <returns>True:�ύX�L��AFalse:�ύX����</returns>
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
        /// �d���`�[�敪�ݒ菈��
        /// </summary>
        /// <param name="supplierSlipCd">�d���`�[�敪</param>
        private void StockSlipCdComboEditorItemSetting(int stockSlipCd, int supplierFormal)
        {
            this.tComboEditor_SupplierSlipDisplay.Items.Clear();

            switch (stockSlipCd)
            {
                // �d��
                case 10:
                    {

                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 1;
                        item0.DataValue = 10;
                        item0.DisplayText = "�|�d��";
                        this.tComboEditor_SupplierSlipDisplay.Items.Add(item0);

                        if (supplierFormal == 0)
                        {
                            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                            item1.Tag = 2;
                            item1.DataValue = 30;
                            item1.DisplayText = "�����d��";
                            this.tComboEditor_SupplierSlipDisplay.Items.Add(item1);
                        }

                        this.tComboEditor_SupplierSlipDisplay.Value = 10;

                        break;
                    }
                // �ԕi
                case 20:
                    {
                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 1;
                        item0.DataValue = 20;
                        item0.DisplayText = "�|�ԕi";
                        this.tComboEditor_SupplierSlipDisplay.Items.Add(item0);

                        if (supplierFormal == 0)
                        {
                            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                            item1.Tag = 2;
                            item1.DataValue = 40;
                            item1.DisplayText = "�����ԕi";
                            this.tComboEditor_SupplierSlipDisplay.Items.Add(item1);
                        }

                        this.tComboEditor_SupplierSlipDisplay.Value = 20;

                        break;
                    }
            }
        }

        /// <summary>
        /// �R���g���[���C���f�b�N�X�擾����
        /// </summary>
        /// <param name="prevCtrl">���݂̃R���g���[���̖���</param>
        /// <param name="mode">0:�ォ�� 1:������</param>
        /// <returns>�R���g���[���C���f�b�N�X</returns>
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
        /// �l�N�X�g�R���g���[���擾����
        /// </summary>
        /// <param name="prevCtrl">���݂̃R���g���[��</param>
        /// <param name="mode">0:�ォ�� 1:������</param>
        /// <returns>���̃R���g���[��</returns>
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
        /// �P�����K�C�h�N������
        /// </summary>
        /// <param name="displayType">��ʃ^�C�v</param>
        private void ExecuteUnitPriceInfoGuide()
        {
            // ���݂̓�����������擾
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

            // ��ʃ^�C�v�ɏ]�����P������ʃp�����[�^�𐶐�
            DCKHN01050UA unitPriceInfo = new DCKHN01050UA();

            UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

            unPrcInfoConf = this._salesSlipStockInfoInputAcs.GetUnitPriceInfoConf(stockTemp);

            DialogResult dialogResult = unitPriceInfo.ShowDialog(this, DCKHN01050UA.DisplayType.UnitCost, unPrcInfoConf);

            if (dialogResult == DialogResult.OK)
            {
                // �P�����ݒ菈��
                this._salesSlipStockInfoInputAcs.UnPrcInfoSetting(unitPriceInfo.UnPrcInfoConfRet, ref stockTemp);

                // ������z�Čv�Z
                this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);

                // �f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

                // �f�[�^�N���X����ʊi�[����
                this.SetDisplay(stockTemp);
            }
        }
        #endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region ��Control Events
        /// <summary>
        /// Load�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void MAHNB01010UJ_Load(object sender, EventArgs e)
        {
            // �K�C�h�{�^���C���[�W�ݒ�
            this.uButton_EmployeeGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// �d���S���S���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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

                // �d�����f�[�^�N���X����ʊi�[����
                this.SetDisplay(stockTemp);

                // �d�����f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

            }
        }

        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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

                // �d�����f�[�^�N���X����ʊi�[����
                this.SetDisplay(stockTemp);

                // �d�����f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }
        }

        /// <summary>
        /// ���Ӑ�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            Supplier supplier;
            this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
            this.SettingSupplier(false, supplier);
        }

        /// <summary>
        /// �d������ݒ菈��
        /// </summary>
        /// <param name="isClear">true:�N���A���� false:�N���A���Ȃ�</param>
        /// <param name="supplier">�d������f�[�^�N���X</param>
        private void SettingSupplier(bool isClear, Supplier supplier)
        {
            if (isClear)
            {
                // ��ʏ���������
                this.Clear(true);
            }

            // �d����������Őݒ�
            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

            bool reCalcUnitPrice = false;		// �|���ɂ�锄��P���A�艿�A���㌴���P���Čv�Z�L��
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
                        "�I�������d����͎d��������͂��s���Ă��Ȃ��ׁA�g�p�ł��܂���B",
                        status,
                        MessageBoxButtons.OK);

                    return;
                }
                else
                {
                    if (supplierTemp.SupplierCd != stockTemp.SupplierCd)
                    {
                        reCalcUnitPrice = true;
                        // ���Ӑ�i�d����j���ݒ菈��
                        this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplierTemp);

                        // �P���Čv�Z
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
                    "�d���悪���݂��܂���B",
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
                    "�d����̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }

            if (reCalcUnitPrice)
            {
                // �P���Z�o
                this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);

                // ������z�Čv�Z
                this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);
            }

            // �L���b�V������
            this._salesSlipStockInfoInputAcs.Cache(stockTemp);

            // ��ʊi�[����
            this.SetDisplay(stockTemp);

        }

        /// <summary>
        /// �`�[��ʃR���{�G�f�B�^�I��l�ύX�m���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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
                    // �d���`�����u�d���v�̏ꍇ
                    case 0:
                        {
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// �d����
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // �v���

                            break;
                        }
                    // �d���`�����u���ׁv�̏ꍇ
                    case 1:
                        {
                            stockTemp.AccPayDivCd = 1;							// ���|�L��Œ�
                            stockTemp.StockAddUpADate = DateTime.MinValue;		// �v������N���A����
                            stockTemp.StockDate = DateTime.MinValue;			// ��������N���A����
                            break;
                        }
                    // �d���`�����u�����v�̏ꍇ
                    case 2:
                        {
                            stockTemp.AccPayDivCd = 1;							// ���|�L��Œ�
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// ������
                            }

                            if (stockTemp.ExpectDeliveryDate == DateTime.MinValue)
                            {
                                stockTemp.ExpectDeliveryDate = stockTemp.ArrivalGoodsDay;
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // �v���

                            break;
                        }
                }

                // �d�����f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }

            // �d�����f�[�^�N���X����ʊi�[����
            this.SetDisplay(stockTemp);
        }

        /// <summary>
        /// �`�[��ʕύX�㏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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
                    // �d���`�����u�d���v�̏ꍇ
                    case 0:
                        {
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// �d����
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // �v���

                            break;
                        }
                    // �d���`�����u���ׁv�̏ꍇ
                    case 1:
                        {
                            stockTemp.AccPayDivCd = 1;							// ���|�L��Œ�
                            stockTemp.StockAddUpADate = DateTime.MinValue;		// �v������N���A����
                            stockTemp.StockDate = DateTime.MinValue;			// ��������N���A����
                            break;
                        }
                    // �d���`�����u�����v�̏ꍇ
                    case 2:
                        {
                            stockTemp.AccPayDivCd = 1;							// ���|�L��Œ�
                            if (stockTemp.StockDate == DateTime.MinValue)
                            {
                                stockTemp.StockDate = stockTemp.ArrivalGoodsDay;	// ������
                            }

                            if (stockTemp.ExpectDeliveryDate == DateTime.MinValue)
                            {
                                stockTemp.ExpectDeliveryDate = stockTemp.ArrivalGoodsDay;
                            }
                            stockTemp.StockAddUpADate = stockTemp.StockDate;        // �v���

                            break;
                        }
                }

                // �d�����f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            
        }

        /// <summary>
        /// �������@�R���{�G�f�B�^�I��l�ύX�m���C�x���g
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
                    // ���͂���Index���͈͓��̏ꍇ�A���͒l���e����ݒ�
                    stockTemp.WayToOrder = code;
                }
                else
                {
                    // ���͂���Index���͈͊O�̏ꍇ�A�����l�ݒ�
                    stockTemp.WayToOrder = 0;
                }

                // �d�����f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);

                // �d�����f�[�^�N���X����ʊi�[����
                this.SetDisplay(stockTemp);
            }
        }

        /// <summary>
        /// �`�[�敪�R���{�G�f�B�^�I��l�ύX�m���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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

                // ����f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }

            // ����f�[�^�N���X����ʊi�[����
            this.SetDisplay(stockTemp);
        }

        /// <summary>
        /// �x����m�F�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_PaymentConfirmation_Click(object sender, EventArgs e)
        {

            StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp;

            if (stockTemp.SupplierCd == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�d���悪���͂���Ă��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            // �E�C���h�E�N��
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


                // �d�����f�[�^�N���X����ʊi�[����
                this.SetDisplay(stockTemp);

                // �d�����f�[�^�L���b�V������
                this._salesSlipStockInfoInputAcs.Cache(stockTemp);
            }
        }
        #endregion
    }
}
