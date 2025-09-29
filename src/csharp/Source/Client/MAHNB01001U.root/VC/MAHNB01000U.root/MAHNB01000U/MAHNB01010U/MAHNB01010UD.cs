using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources; // ADD T.Miyamoto 2012/11/13

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����`�[�ԍ����̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����`�[�ԍ��̓��͂��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n�@���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 ���n ��� �V�K�쐬</br>
    /// <br>2009/09/10 20056 ���n ��� MANTIS[0014027] �`�[�Ɖ�I�����ADispose��ǉ�</br>
    /// <br>UpdateNote : K2011/08/12 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10703874-00</br>
    /// <br>�쐬���e   : �C�X�R�ʑΉ�</br>
    /// <br>Update Note: K2011/12/09 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10703874-00</br>
    /// <br>�쐬���e   : �C�X�R�ʑΉ�</br>
    /// <br>Update Note: 2011/12/14 yangmj</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
    /// <br>             redmine#27359 �`�[�����̉�ʕ\���̑Ή�</br>
    /// <br>Update Note: 2012/11/13 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��1668</br>
    /// <br>             ����ߋ����t������ʃI�v�V�������i�C�X�R�܂��̓I�v�V��������œ��t����j</br>
    /// <br>Update Note: 2015/05/12  �C������</br>
    /// <br>�Ǘ��ԍ�   : 11175123-00</br>
    /// <br>           : Redmine#45799 �A���C����l ��12 �f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή�</br>
    /// <br>Update Note: 2015/11/27 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11170204-00 ����`�[���͂̏�Q�Ή�</br>
    /// <br>           : Redmine#45799 #67�Ńf���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή�</br>
    /// </remarks>
    public partial class MAHNB01010UD : Form
    {
        public MAHNB01010UD(int acptAnOdrStatus, string salesSlipNum, bool canAcptAnOdrStatusChange, int mode)
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._canAcptAnOdrStatusChange = canAcptAnOdrStatusChange;
            this._mode = mode;
        }

        private ImageList _imageList16 = null;

        private SalesSlipInputAcs _salesSlipInputAcs;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string login_EnterpriseCode = "0123130012020600"; // ADD K2011/12/09
        private bool _canAcptAnOdrStatusChange = false;
        private int _mode = ct_MODE_Normal;
        private SalesSlip _salesSlip = null;
        private SalesSlip _baseSalesSlip = null;
        private List<SalesDetail> _salesDetailList = null;
        private List<SalesDetail> _addUpSrcDetailList = null;
        private SearchDepsitMain _depsitMain = null;
        private SearchDepositAlw _depositAlw = null;
        private List<StockWork> _stockWorkList = null;
        private List<AcceptOdrCar> _acceptOdrCarList = null;

        private List<StockSlipWork> _stockSlipWorkList = null;
        private List<StockDetailWork> _stockDetailWorkList = null;
        private List<AddUpOrgStockDetailWork> _addUpOrgStockDetailList = null;
        private List<PaymentSlpWork> _paymentSlpWorkList = null;
        private List<UOEOrderDtlWork> _uoeOrderDtlWorkList = null;
        //>>>2010/02/26
        private UserSCMOrderHeaderRecord _scmHeader = null;
        private UserSCMOrderCarRecord _scmCar = null;
        private List<UserSCMOrderDetailRecord> _scmDetailList = null;
        private List<UserSCMOrderAnswerRecord> _scmAnswerList = null;
        //<<<2010/02/26

        private int _acptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales;
        private string _salesSlipNum = "";
        public static readonly int ct_MODE_Normal = 0;
        public static readonly int ct_MODE_RetGoods = 1;
        public static readonly int ct_MODE_Estimate = 2;
        public static readonly int ct_MODE_RedSlip = 3;

        public static readonly bool ct_AcptAnOdrStatusEnable_True = true;
        public static readonly bool ct_AcptAnOdrStatusEnable_False = false;

        DialogResult _result = DialogResult.Cancel;

        /// <summary>����f�[�^�v���p�e�B</summary>
        internal SalesSlip SalesSlip
        {
            get { return _salesSlip; }
        }
        /// <summary>�Ď擾�O����f�[�^�v���p�e�B</summary>
        internal SalesSlip BaseSalesSlip
        {
            get { return _baseSalesSlip; }
        }
        /// <summary>���㖾�׃f�[�^���X�g�v���p�e�B</summary>
        internal List<SalesDetail> SalesDetailList
        {
            get { return _salesDetailList; }
        }
        /// <summary>�v�㌳���׃��X�g�v���p�e�B</summary>
        internal List<SalesDetail> AddUpSrcDetailList
        {
            get { return _addUpSrcDetailList; }
        }
        /// <summary>�����f�[�^�v���p�e�B</summary>
        internal SearchDepsitMain DepsitMain
        {
            get { return _depsitMain; }
        }
        /// <summary>���������f�[�^�v���p�e�B</summary>
        internal SearchDepositAlw DepositAlw
        {
            get { return _depositAlw; }
        }
        /// <summary>�݌Ƀ��[�N���X�g�v���p�e�B</summary>
        internal List<StockWork> StockWorkList
        {
            get { return _stockWorkList; }
        }
        /// <summary>�󒍃}�X�^�i�ԗ��j���X�g�v���p�e�B</summary>
        internal List<AcceptOdrCar> AcceptOdrCarList
        {
            get { return _acceptOdrCarList; }
        }
        /// <summary>�d���f�[�^���X�g�v���p�e�B</summary>
        internal List<StockSlipWork> StockSlipWorkList
        {
            get { return _stockSlipWorkList; }
        }
        /// <summary>�d�����׃f�[�^���X�g�v���p�e�B</summary>
        internal List<StockDetailWork> StockDetailWorkList
        {
            get { return _stockDetailWorkList; }
        }
        /// <summary>�v�㌳�d�����׃f�[�^���X�g�v���p�e�B</summary>
        internal List<AddUpOrgStockDetailWork> addUpOrgStockDetailList
        {
            get { return _addUpOrgStockDetailList; }
        }
        /// <summary>�x���f�[�^���X�g�v���p�e�B</summary>
        internal List<PaymentSlpWork> paymentSlpWorkList
        {
            get { return _paymentSlpWorkList; }
        }
        /// <summary>UOE�����f�[�^���[�N���X�g�v���p�e�B</summary>
        internal List<UOEOrderDtlWork> uoeOrderDtlWorkList
        {
            get { return _uoeOrderDtlWorkList; }
        }
// add yangmj
        /// <summary>����f�[�^�v���p�e�B</summary>
        public SalesSlip DfSalesSlip
        {
            get { return _salesSlip; }
        }
        /// <summary>�Ď擾�O����f�[�^�v���p�e�B</summary>
        public SalesSlip DfBaseSalesSlip
        {
            get { return _baseSalesSlip; }
        }
        /// <summary>���㖾�׃f�[�^���X�g�v���p�e�B</summary>
        public List<SalesDetail> DfSalesDetailList
        {
            get { return _salesDetailList; }
        }
        /// <summary>�v�㌳���׃��X�g�v���p�e�B</summary>
        public List<SalesDetail> DfAddUpSrcDetailList
        {
            get { return _addUpSrcDetailList; }
        }
        /// <summary>�����f�[�^�v���p�e�B</summary>
        public SearchDepsitMain DfDepsitMain
        {
            get { return _depsitMain; }
        }
        /// <summary>���������f�[�^�v���p�e�B</summary>
        public SearchDepositAlw DfDepositAlw
        {
            get { return _depositAlw; }
        }
        /// <summary>�݌Ƀ��[�N���X�g�v���p�e�B</summary>
        public List<StockWork> DfStockWorkList
        {
            get { return _stockWorkList; }
        }
        /// <summary>�󒍃}�X�^�i�ԗ��j���X�g�v���p�e�B</summary>
        public List<AcceptOdrCar> DfAcceptOdrCarList
        {
            get { return _acceptOdrCarList; }
        }
        /// <summary>�d���f�[�^���X�g�v���p�e�B</summary>
        public List<StockSlipWork> DfStockSlipWorkList
        {
            get { return _stockSlipWorkList; }
        }
        /// <summary>�d�����׃f�[�^���X�g�v���p�e�B</summary>
        public List<StockDetailWork> DfStockDetailWorkList
        {
            get { return _stockDetailWorkList; }
        }
        /// <summary>�v�㌳�d�����׃f�[�^���X�g�v���p�e�B</summary>
        public List<AddUpOrgStockDetailWork> DfaddUpOrgStockDetailList
        {
            get { return _addUpOrgStockDetailList; }
        }
        /// <summary>�x���f�[�^���X�g�v���p�e�B</summary>
        public List<PaymentSlpWork> DfpaymentSlpWorkList
        {
            get { return _paymentSlpWorkList; }
        }
        /// <summary>UOE�����f�[�^���[�N���X�g�v���p�e�B</summary>
        public List<UOEOrderDtlWork> DfuoeOrderDtlWorkList
        {
            get { return _uoeOrderDtlWorkList; }
        }
        // end add yangmj
        //>>>2010/02/26
        /// <summary>SCM�󒍃f�[�^�v���p�e�B</summary>
        public UserSCMOrderHeaderRecord scmHeader
        {
            get { return _scmHeader; }
        }
        /// <summary>SCM�󒍃f�[�^(�ԗ����)�v���p�e�B</summary>
        public UserSCMOrderCarRecord scmCar
        {
            get { return _scmCar; }
        }
        /// <summary>SCM�󒍖��׃f�[�^(�⍇���E����)�v���p�e�B</summary>
        public List<UserSCMOrderDetailRecord> scmDetailList
        {
            get { return _scmDetailList; }
        }
        /// <summary>SCM�󒍖��׃f�[�^(��)�v���p�e�B</summary>
        public List<UserSCMOrderAnswerRecord> scmAnswerList
        {
            get { return _scmAnswerList; }
        }
        //<<<2010/02/26

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>true:�ۑ����� false:�ۑ����s</returns>
        /// <br>Update Note: K2011/12/09 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10703874-00</br>
        /// <br>�쐬���e   : �C�X�R�ʑΉ�</br>
        private bool Save()
        {
            if (this.tNedit_SalesSlipNum.GetInt() == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�`�[�ԍ������͂���Ă��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
            else
            {
                bool customerError = false;
                SalesSlip salesSlip;
                SalesSlip baseSalesSlip;
                List<SalesDetail> salesDetailList;
                List<SalesDetail> addUpSrcDetailList;
                SearchDepsitMain depsitMain;
                SearchDepositAlw depositAlw;
                List<StockWork> stockWorkList;
                List<StockSlipWork> stockSlipWorkList;
                List<StockDetailWork> stockDetailWorkList;
                List<AddUpOrgStockDetailWork> addUpOrgStockDetailList;
                List<AcceptOdrCar> acceptOdrCarList;
                List<UOEOrderDtlWork> uoeOrderDtlWorkList;
                //>>>2010/02/26
                UserSCMOrderHeaderRecord scmHeader;
                UserSCMOrderCarRecord scmCar;
                List<UserSCMOrderDetailRecord> scmDetailList;
                List<UserSCMOrderAnswerRecord> scmAnswerList;
                //<<<2010/02/26
                int acptAnOdrStatus = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_AcptAnOdrStatus);
                int svAcptAnOdrStatus = acptAnOdrStatus;
                if ((acptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate) ||
                    (acptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)) acptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate;

                // �f�[�^���[�h����
                //>>>2010/02/26
                //int status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, acptAnOdrStatus, this.tNedit_SalesSlipNum.Text.PadLeft(9, '0'), false, true, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList);
                int status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, acptAnOdrStatus, this.tNedit_SalesSlipNum.Text.PadLeft(9, '0'), false, true, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
                //<<<2010/02/26

                // ���ς͒ʏ팩�ς̂݁A�P�����ς͒P�����ς̂݁A�������ς͌������ς̂ݓǂݍ��݉\�Ƃ���
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (svAcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate)
                    {
                        if (salesSlip.EstimateDivide != (int)SalesSlipInputAcs.EstimateDivide.Estimate) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else if (svAcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate)
                    {
                        if (salesSlip.EstimateDivide != (int)SalesSlipInputAcs.EstimateDivide.UnitPriceEstimate) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else if (svAcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)
                    {
                        if (salesSlip.EstimateDivide != (int)SalesSlipInputAcs.EstimateDivide.SearchEstimate)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        else
                        {
                            if (salesSlip.CustomerCode == 0)
                            {
                                customerError = true;
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._result = DialogResult.OK;
                    this._salesSlip = salesSlip;
                    this._baseSalesSlip = baseSalesSlip;
                    this._salesDetailList = salesDetailList;
                    this._addUpSrcDetailList = addUpSrcDetailList;
                    this._depsitMain = depsitMain;
                    this._depositAlw = depositAlw;
                    this._stockWorkList = stockWorkList;
                    this._acceptOdrCarList = acceptOdrCarList;

                    this._stockSlipWorkList = stockSlipWorkList;
                    this._stockDetailWorkList = stockDetailWorkList;
                    this._addUpOrgStockDetailList = addUpOrgStockDetailList;

                    this._uoeOrderDtlWorkList = uoeOrderDtlWorkList;
                    //>>>2010/02/26
                    this._scmHeader = scmHeader;
                    this._scmCar = scmCar;
                    this._scmDetailList = scmDetailList;
                    this._scmAnswerList = scmAnswerList;
                    //<<<2010/02/26
                }
                else
                {
                    if (customerError)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���Ӑ悪�ݒ肳��Ă��Ȃ��`�[�͎w��ł��܂���B",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    else
                    {
                        // ----- ADD K2011/12/09 --------------------------->>>>>
                        // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
                        //if (this._enterpriseCode == login_EnterpriseCode)
                        Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                        ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SalesDateControl);
                        if ((ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract) ||
                            (this._enterpriseCode == login_EnterpriseCode))
                        // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
                        {
                            if (this._salesSlipInputAcs.SalesSlipCanEditDivCd == false) return false;
                        }
                        // ----- ADD K2011/12/09 ---------------------------<<<<<
                        //if (this._salesSlipInputAcs.SalesSlipCanEditDivCd == false) return false; // ADD K2011/08/12 // DEL K2011/12/09
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�Y���f�[�^�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // ����`�[�ԍ� ============================================ //
                case "tNedit_SalesSlipNum":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    int code = this.tNedit_SalesSlipNum.GetInt();

                                    if (code != 0)
                                    {
                                        bool canSave = this.Save();

                                        if (canSave)
                                        {
                                            this.Close();
                                        }
                                        else
                                        {
                                            this.uButton_SalesSlipGuide.Focus();
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// �m��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            bool canSave = this.Save();

            if (canSave)
            {
                this.Close();
            }
            else
            {
                this.tNedit_SalesSlipNum.Focus();
            }
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �t�H�[���N���[�Y�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void MAKON01110UD_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = this._result;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void MAKON01110UD_Load(object sender, EventArgs e)
        {
            this.uButton_SalesSlipGuide.ImageList = this._imageList16;
            this.uButton_SalesSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.SettingAcptAnOdrStatusComboEditor(this._mode);

            ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_AcptAnOdrStatus, this._acptAnOdrStatus, true);
            this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(this._salesSlipNum, 0));

            if (this._canAcptAnOdrStatusChange)
            {
                this.tComboEditor_AcptAnOdrStatus.Enabled = true;
            }
            else
            {
                this.tComboEditor_AcptAnOdrStatus.Enabled = false;
            }

            this.timer_InitialSetFocus.Enabled = true;
        }

        /// <summary>
        /// �󒍃X�e�[�^�XComboEditor�ݒ�
        /// </summary>
        /// <param name="mode"></param>
        private void SettingAcptAnOdrStatusComboEditor(int mode)
        {
            if (mode == ct_MODE_RetGoods)
            {
                // �ԕi���[�h���́u����A�ݏo�v�̂ݑI����
                this.tComboEditor_AcptAnOdrStatus.Items.Clear();
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 0;
                item0.DataValue = 30;
                item0.DisplayText = "����";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 1;
                item1.DataValue = 40;
                item1.DisplayText = "�ݏo";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item1);
            }
            else if (mode == ct_MODE_Estimate)
            {
                // ���σ��[�h���́u���ρA�P�����ρA�������ρv�̂ݑI����
                this.tComboEditor_AcptAnOdrStatus.Items.Clear();
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 0;
                item0.DataValue = 10;
                item0.DisplayText = "����";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 1;
                item1.DataValue = 15;
                item1.DisplayText = "�P������";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item1);
                Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                item2.Tag = 2;
                item2.DataValue = 16;
                item2.DisplayText = "��������";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item2);
            }
            else
            {
                // �ʏ탂�[�h
                this.tComboEditor_AcptAnOdrStatus.Items.Clear();
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 0;
                item0.DataValue = 30;
                item0.DisplayText = "����";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 1;
                item1.DataValue = 40;
                item1.DisplayText = "�ݏo";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item1);
                Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                item2.Tag = 2;
                item2.DataValue = 20;
                item2.DisplayText = "��";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item2);
                Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
                item3.Tag = 3;
                item3.DataValue = 10;
                item3.DisplayText = "����";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item3);
                Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
                item4.Tag = 4;
                item4.DataValue = 15;
                item4.DisplayText = "�P������";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item4);
            }
        }

        /// <summary>
        /// �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            this.tNedit_SalesSlipNum.Focus();
        }

        // ----- DEL 2015/11/27 ���V�� Redmine#45799 #67�Ńf���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� ----->>>>>
        ////------ ADD START �C������ 2015/05/12 for Redmine#45799�̃A���C����No.12  �f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� ------>>>>>
        ///// <summary>
        ///// IWin32Window�N���X�̃��b�p�[�N���X
        ///// ���C���E�C���h�E(delphi�̉�ʁ@MAHNB01001U.exe)�̃n���h����ݒ肷�邽�߂ɍ쐬
        ///// �g�p�ӏ��̓f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : �g�p�ӏ��̓f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu��ݒ肷��B</br>
        ///// <br>Programmer : �C������</br>
        ///// <br>Date       : 2015/05/12</br>
        ///// </remarks>
        //private class IWin32WindowWrapper : System.Windows.Forms.IWin32Window
        //{
        //    private IntPtr _handle;
        //    public IntPtr Handle
        //    {
        //        get { return _handle; }
        //    }

        //    public IWin32WindowWrapper(IntPtr handle)
        //    {
        //        _handle = handle;
        //    }
        //}
        ////------ ADD END �C������ 2015/05/12 for Redmine#45799�̃A���C����No.12  �f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� ------<<<<<
        // ----- DEL 2015/11/27 ���V�� Redmine#45799 #67�Ńf���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� -----<<<<<

        /// <summary>
        /// ����`�[�����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note: 2011/12/14 yangmj</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
        /// <br>             redmine#27359 �`�[�����̉�ʕ\���̑Ή�</br>
        /// <br>Update Note: 2015/05/12  �C������</br>
        /// <br>�Ǘ��ԍ�   : 11175123-00</br>
        /// <br>           : Redmine#45799 �A���C����l ��12 �f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή�</br>
        /// <br>Update Note: 2015/11/27 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00 ����`�[���͂̏�Q�Ή�</br>
        /// <br>           : Redmine#45799 #67�Ńf���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή�</br>
        private void uButton_SalesSlipGuide_Click(object sender, EventArgs e)
        {
            int acptAnOdrStatusDisplay = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_AcptAnOdrStatus);
            int acptAnOdrStatus = acptAnOdrStatusDisplay;
            int estimateDivide;
            SalesSlipInputAcs.GetAcptAnOdrStatusAndEstimateDivideFromDisplay(acptAnOdrStatusDisplay, ref acptAnOdrStatus, out estimateDivide);
            
            MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
            // 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region 2009/09/10 DEL
            //salesSlipGuide.TComboEditor_SalesFormalCode = false;
            //salesSlipGuide.AutoSearch = true;
            //salesSlipGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
            //salesSlipGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
            //salesSlipGuide.AcptAnOdrStatus = acptAnOdrStatusDisplay;
            //switch (this._mode)
            //{
            //    case 0: // �ʏ�
            //        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
            //        salesSlipGuide.SalesSlipCd = 0;
            //        break;
            //    case 2: // ����
            //        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
            //        salesSlipGuide.SalesSlipCd = 0;
            //        break;
            //    case 1: // �ԕi
            //    case 3: // �ԓ`
            //        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.Sales;
            //        salesSlipGuide.SalesSlipCd = 0;
            //        break;
            //}

            //SalesSlipSearchResult searchResult;
            //DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult);

            //if (result == DialogResult.OK)
            //{
            //    if (searchResult != null)
            //    {
            //        this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(searchResult.SalesSlipNum, 0));

            //        bool canSave = this.Save();

            //        if (canSave)
            //        {
            //            this.Close();
            //        }
            //        else
            //        {
            //            this.tNedit_SalesSlipNum.Focus();
            //        }
            //    }
            //}
            #endregion
            try
            {
                salesSlipGuide.TComboEditor_SalesFormalCode = false;
                //salesSlipGuide.AutoSearch = true;//DEL 2011/12/14 YANGMJ REDMINE#27359
                salesSlipGuide.AutoSearch = false;//ADD 2011/12/14 YANGMJ REDMINE#27359
                salesSlipGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
                salesSlipGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
                salesSlipGuide.AcptAnOdrStatus = acptAnOdrStatusDisplay;
                salesSlipGuide.StartMode = 1;//ADD 2011/12/14 YANGMJ REDMINE#27359
                switch (this._mode)
                {
                    case 0: // �ʏ�
                        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
                        salesSlipGuide.SalesSlipCd = 0;
                        break;
                    case 2: // ����
                        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
                        salesSlipGuide.SalesSlipCd = 0;
                        break;
                    case 1: // �ԕi
                    case 3: // �ԓ`
                        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.Sales;
                        salesSlipGuide.SalesSlipCd = 0;
                        break;
                }

                SalesSlipSearchResult searchResult;
                //DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult); // DEL �C������ 2015/05/12 for Redmine#45799
                //------ ADD START �C������ 2015/05/12 for Redmine#45799�̃A���C����No.12  �f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� ------>>>>>
                // �E�B���h�̕\���ʒu���Z�b�g����
                salesSlipGuide.StartPosition = FormStartPosition.CenterScreen;
                // ----- DEL 2015/11/27 ���V�� Redmine#45799 #67�Ńf���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� ----->>>>>
                //IntPtr handle;
                //try
                //{
                //    handle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                //}
                //catch
                //{

                //}
                //DialogResult result;
                //if (handle != null)
                //{
                //    // IWin32Window���b�p�[�N���X�̃C���X�^���X�ɁA���C���E�B���h�E�̃n���h����ݒ�
                //    IWin32WindowWrapper wrp = new IWin32WindowWrapper(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
                //    result = salesSlipGuide.ShowGuide(wrp, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult);
                //}
                //else
                //{
                //    result = salesSlipGuide.ShowGuide(this._salesSlipInputAcs.Owner, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult);
                //}
                // ----- DEL 2015/11/27 ���V�� Redmine#45799 #67�Ńf���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� -----<<<<<
                //------ ADD END �C������ 2015/05/12 for Redmine#45799�̃A���C����No.12  �f���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή� ------<<<<<
                DialogResult result = salesSlipGuide.ShowGuide(this._salesSlipInputAcs.Owner, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult); // ADD 2015/11/27 ���V�� Redmine#45799 #67�Ńf���A�����j�^�Ŏg�p�����ۂ̃K�C�h�E�B���h�̕\���ʒu�̑Ή�

                if (result == DialogResult.OK)
                {
                    if (searchResult != null)
                    {
                        this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(searchResult.SalesSlipNum, 0));

                        bool canSave = this.Save();

                        if (canSave)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.tNedit_SalesSlipNum.Focus();
                        }
                    }
                }
            }
            finally
            {
                salesSlipGuide.Dispose();
            }
            // 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        }
    }
}