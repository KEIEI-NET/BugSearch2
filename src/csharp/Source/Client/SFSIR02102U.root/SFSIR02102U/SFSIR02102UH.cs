//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���`�[�K�C�h
// �v���O�����T�v   : �x���`�[�K�C�h�̕\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N
// �C �� ��  2012/12/24  �C�����e : 2013/03/13�z�M�� Redmine#33741�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N
// �C �� ��  2013/02/23  �C�����e : 2013/03/13�z�M�� Redmine#33741�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N
// �C �� ��  2013/03/01  �C�����e : 2013/03/13�z�M�� Redmine#33741�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class SFSIR02102UH : Form
    {
        /// <summary>
        /// �x���`�[�����K�C�h���
        /// </summary>
        /// <remarks>
        /// <br>Note		: �x���`�[�����K�C�h��ʂł��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br>Date		: 2012/12/24</br>
        /// <br>Update Note : 2013/02/23  ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br>Update Note : 2013/03/01  ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br></br>
        public SFSIR02102UH()
        {
            InitializeComponent();
            this._supplierAcs = new SupplierAcs();
        }

        #region[Private Member]
        
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// �����{�^��

        // ���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        private PaymentSlpSearch _paymentSlpSearch;

        private SearchPaySlpInfoParameter _searchPaySlpInfoParameter;

        /// <summary> ���_�R�[�h</summary>
        private string _SectionCode;

        /// <summary>���_�� </summary>
        private string _SectionName;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>�x���`�[�f�[�^</summary>
        private DataTable _paymentInfoTable;

        /// <summary> �d������N���X</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>��ʃt�H�[�J�X�����ݒ�Flag</summary>
        private bool _focusSetFlag;

        // ---- ADD ���N 2013/02/07 Redmine#33741 ---- >>>>>
        /// <summary>�d����R�[�h</summary>
        private int _supCode;

        /// <summary>�d���於</summary>
        private string _supName;

        /// <summary>����Flag</summary>
        private bool _toolSearchFlag;
        // ---- ADD ���N 2013/02/07 Redmine#33741 ---- <<<<<
        #endregion

        #region[Dispose]

        public string EnterpriseCode
        {
            set { _enterpriseCode = value; }
            get { return _enterpriseCode; }
        }

        public string SectionCode
        {
            set { _SectionCode = value; }
            get { return _SectionCode; }
        }

        public string SectionName
        {
            set { _SectionName = value; }
            get { return _SectionName; }
        }

        public PaymentSlpSearch PaymentSlpSearchUH
        {
            set { _paymentSlpSearch = value; }
            get { return _paymentSlpSearch; }
        }

        public SearchPaySlpInfoParameter SearchPaySlpInfoParameter
        {
            set { _searchPaySlpInfoParameter = value; }
            get { return _searchPaySlpInfoParameter; }
        }
        #endregion

        #region[Private Methord]

        /// <summary>�x���K�C�h�O���b�h�����ݒ菈��</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : �x���K�C�h�O���b�h�����ݒ菈�������B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void SetGridLayout()
        {
            // �x���`�[�ԍ�
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Width = 100;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Header.Caption
                = "�x���ԍ�";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].CellAppearance.TextHAlign
                = HAlign.Right;
            // �x�����t
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Width = 110;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Header.Caption
                = "�x����";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Hidden = true;
            // �x�����햼��
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME].Hidden = true;
            // �x�����z
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Header.Caption
                = "�x�����z";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Format = "#,##0";
            // �萔���x���z
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Hidden = true;
            // �l���x���z
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Hidden = true;

            // �x�����z�v
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Header.Caption
                = "�x���v";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Format = "#,##0";
            // �`�[�E�v
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Header.Caption
                = "�E�v";
            // ���t���O
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG].Hidden = true;
            // �ԓ`�敪
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Hidden = true;
            // �x�����͎Җ���
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM].Hidden = true;
            //�d����R�[�h
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].Header.Caption = "�d����R�[�h";
            //�d���於
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME].Header.Caption = "�d���於"; 
        }

        /// <summary>
        ///�d������
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="supplierCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : �d������B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private int GetSupplier(out Supplier supplier, int supplierCode)
        {
            int status;
            supplier = new Supplier();

            try
            {
                status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
                if ((status == 0) && (supplier.LogicalDeleteCode != 0))
                {
                    return 9;
                }
            }
            catch
            {
                status = -1;
                supplier = new Supplier();
            }

            return (status);
        }
        #endregion

        #region [Private Event]
        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks> 
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                this._SectionCode = sectionInfo.SectionCode.TrimEnd();
                this._SectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.DataText = this._SectionCode;
                this.uLabel_SectionName.Text = this._SectionName;
            }
        }

        /// <summary>
        /// �d����K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : �d����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks> 
        private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
        {
            int status;
            Supplier supplier;
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._SectionCode);
            if (status == 0)
            {
                this.tNedit_SupplierCd.DataText = supplier.SupplierCd.ToString();
                this.uLabel_CustomerName.Text = supplier.SupplierSnm;
            }
        }

        /// <summary>
        /// �L�[�R���g���[�� �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Update Note : 10806793-00 2013/02/07  ���N</br>
        /// <br>�Ǘ��ԍ�    : 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br>
        /// <br>Update Note : 10806793-00 2013/03/01  ���N</br>
        /// <br>�Ǘ��ԍ�    : 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (_focusSetFlag && e.NextCtrl!=null)
            {
                // ��ʃt�H�[�J�X�����ݒ菈��
                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                this._focusSetFlag = false;
            }
            if (e.PrevCtrl == null)
            {
                return;
            }
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero":
                    {
                        //------------------------------------
                        // ���_�R�[�h�擾
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();

                        tEdit_SectionCodeAllowZero_Enter(this.tEdit_SectionCodeAllowZero, new EventArgs());
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCodeAllowZero.Name);
                        string sectionCodeZero = new string('0', uiset.Column);
                        if (sectionCode == sectionCodeZero || string.IsNullOrEmpty(sectionCode) || "0".Equals(sectionCode))
                        {
                            this.SectionCode = "00";
                            this.tEdit_SectionCodeAllowZero.DataText = "00";
                            this.uLabel_SectionName.Text = "�S��";
                            this.SectionCode = "00";
                            this._SectionName = "�S��";
                            return;
                        }
                        else if (sectionCode != this._SectionCode)
                        {
                            if (_secInfoSetAcs == null)
                            {
                                _secInfoSetAcs = new SecInfoSetAcs();
                            }
                            if (sectionCode.Length == 1)
                            {
                                sectionCode = sectionCode.PadLeft(2, '0');
                            }
                            SecInfoSet sectionInfo;
                            if (sectionCode != sectionCodeZero)
                            {
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) //DEL ���N 2013/02/07 Redmine#33741
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) //ADD ���N 2013/02/07 Redmine#33741
                                {
                                    // �p�����[�^�ɕۑ�
                                    this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                                    this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                                    this.SectionCode = sectionInfo.SectionCode.TrimEnd();
                                    this._SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                                    //e.NextCtrl = this.tNedit_SupplierCd; // DEL ���N 2013/02/07 Redmine#33741
                                }
                                // ----- DEL ���N 2013/02/07 Redmine#33741 ---->>>>>
                                //else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                // ----- DEL ���N 2013/02/07 Redmine#33741 ----<<<<<
                                // ----- ADD ���N 2013/02/07 Redmine#33741 ---->>>>>
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) || (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode != 0))
                                // ----- ADD ���N 2013/02/07 Redmine#33741 ----<<<<<
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�����݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);
                                    // ---- DEL ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                    //this.tEdit_SectionCodeAllowZero.Clear();
                                    //this.uLabel_SectionName.Text = "";
                                    // ---- DEL ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                    // ----- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ----- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���_���̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);
                                    // ---- DEL ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                    //this.tEdit_SectionCodeAllowZero.Clear();
                                    //this.uLabel_SectionName.Text = "";
                                    // ---- DEL ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                    // ----- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode.ToString();
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ----- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        else
                        {
                            // ----- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                            if (e.ShiftKey == true)
                            {
                                switch(e.Key)
                                {
                                    case Keys.Enter:
                                    case Keys.Tab:
                                        {
                                            if (this.gridPaymentList.Rows.Count > 0)
                                            {
                                                this.gridPaymentList.Focus();
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_StockCustomerGuide;
                                            }
                                            break;
                                        }
                                }
                            }
                            // ----- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                            
                        }
                        break;
                    }
                case "tNedit_SupplierCd":
                    {
                        // �d����R�[�h�擾
                        int supplierCode = this.tNedit_SupplierCd.GetInt();
                        Supplier supplier;
                        //--------------------------------------------------------------------
                        // �d����R�[�h����d����}�X�^���擾���A�x����R�[�h�Ɣ�r
                        //--------------------------------------------------------------------
                        int status = GetSupplier(out supplier, supplierCode);
                        if (supplierCode == 0)
                        {
                            this.uLabel_CustomerName.Text = "";
                        }
                        else
                        {
                            if (status == 0)
                            {
                                this.tNedit_SupplierCd.DataText = supplier.SupplierCd.ToString();
                                this.uLabel_CustomerName.Text = supplier.SupplierSnm;
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ---- >>>>>
                                this._supCode = supplier.SupplierCd;
                                this._supName = supplier.SupplierSnm;
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ---- <<<<<
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������d���悪���݂��܂���B",
                                    status,
                                    MessageBoxButtons.OK);
                                this.tNedit_SupplierCd.Clear();
                                this.uLabel_CustomerName.Text = "";
                                // ----- ADD ���N 2013/02/07 Redmine#33741 ---->>>>>
                                this.tNedit_SupplierCd.DataText = this._supCode.ToString();
                                this.uLabel_CustomerName.Text = this._supName;
                                this._toolSearchFlag = false;
                                // ----- ADD ���N 2013/02/07 Redmine#33741 ----<<<<<
                                e.NextCtrl = this.uButton_StockCustomerGuide;
                            }
                        }
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                                case Keys.Right:
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (status == 0)
                                        {
                                            // ---- ADD ���N�@2013/03/01 Redmine#33741 ----->>>>>
                                            if (this.gridPaymentList.Rows.Count > 0)
                                            {
                                            // ---- ADD ���N�@2013/03/01 Redmine#33741 -----<<<<<
                                                e.NextCtrl = this.gridPaymentList;
                                            // ---- ADD ���N�@2013/03/01 Redmine#33741 ----->>>>>
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_StockCustomerGuide;
                                            }
                                            // ---- ADD ���N�@2013/03/01 Redmine#33741 ----->>>>> 
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_StockCustomerGuide;
                                        }
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        if (this.gridPaymentList.Rows.Count > 0)
                                        {
                                            e.NextCtrl = this.gridPaymentList;
                                        }
                                        // ---- ADD ���N�@2013/02/07 Redmine#33741 ----->>>>>
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                        }
                                        // ---- ADD ���N�@2013/02/07 Redmine#33741 -----<<<<<
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N�@2013/02/07 Redmine#33741 ----->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N�@2013/02/07 Redmine#33741 -----<<<<<
                        break;
                    }
                case "gridPaymentList":
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                    {
                                        if (this.gridPaymentList.Rows.Count > 0 && this.gridPaymentList.ActiveRow != null)
                                        {
                                            gridPaymentList_DoubleClickRow(this.gridPaymentList, new DoubleClickRowEventArgs(this.gridPaymentList.ActiveRow, RowArea.CellArea));
                                        }
                                        // ---- ADD ���N�@2013/03/01 Redmine#33741 ----->>>>>
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        // ---- ADD ���N�@2013/03/01 Redmine#33741 -----<<<<<
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                     // ---- ADD ���N�@2013/02/07 Redmine#33741 ----->>>>>
                case "SectionCodeGuide_ultraButton":
                    {
                        if(e.ShiftKey==true)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uButton_StockCustomerGuide":
                    {
                        if (e.ShiftKey == true)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_SupplierCd;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N�@2013/03/01 Redmine#33741 ----->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.gridPaymentList;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.uButton_StockCustomerGuide;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N�@2013/03/01 Redmine#33741 ----->>>>>
                        break;
                    }
                // ---- ADD ���N�@2013/02/07 Redmine#33741 -----<<<<<
            }
        }

        /// <summary>
        /// ToolBar��click�E�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ToolBar��click�E�C�x���g�B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Update Note : 2013/02/07  ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br>Update Note : 2013/02/23  ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        /* ----- ADD ���N 2013/02/07 Redmine#33741 ---- >>>>>
                        if (!"00".Equals(this.tEdit_SectionCodeAllowZero.DataText.TrimEnd()))
                        {
                            _searchPaySlpInfoParameter.AddUpSecCode = this.tEdit_SectionCodeAllowZero.DataText.TrimEnd();
                        }
                        else
                        {
                            this._searchPaySlpInfoParameter.AddUpSecCode = "";
                        }
                        //----- ADD ���N 2013/02/07 Redmine#33741 ---- <<<<< */
                        // ----- ADD ���N 2013/02/07 Redmine#33741 ----->>>>>
                        this._toolSearchFlag = true;
                        if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero, null));
                        }
                        if (this.tNedit_SupplierCd.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_SupplierCd, null));
                        }
                        if ("00".Equals(this.SectionCode))
                        {
                            this._searchPaySlpInfoParameter.AddUpSecCode = "";
                        }
                        else
                        {
                            this._searchPaySlpInfoParameter.AddUpSecCode = this.SectionCode;
                        }
                        if (!this._toolSearchFlag)
                        {
                            return;
                        }
                        // ----- ADD ���N 2013/02/07 Redmine#33741 -----<<<<<
                        this._searchPaySlpInfoParameter.SupplierCode = this.tNedit_SupplierCd.GetInt();
                        this._searchPaySlpInfoParameter.PaymentSlipNo = 0; // ADD ���N 2013/02/23 Redmine#33741
                        int status = _paymentSlpSearch.SearchPaySlpInfoUH(_searchPaySlpInfoParameter, 31);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    this.gridPaymentList.Rows[0].Activate();
                                    this.gridPaymentList.Focus();
                                    break;
                                }
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        this._paymentSlpSearch.ErrorMessage,
                                        0,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                                  this.Name,
                                                  "�x���`�[�̓Ǎ������Ɏ��s���܂����B" + "\r\n" + this._paymentSlpSearch.ErrorMessage,
                                                  status,
                                                  MessageBoxButtons.OK);
                                    break;
                                }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// DoubleClickRow �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void gridPaymentList_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int guidRowIndex = e.Row.Index;
            string paymentNo = this.gridPaymentList.Rows[guidRowIndex].Cells[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Value.ToString();
            DataRow[] drSlt = this._paymentInfoTable.Select("PaymentSlipNo =" + paymentNo);
            DataRow dr = this._paymentInfoTable.NewRow();
            if (drSlt.Length > 0)
            {
                dr = drSlt[0];
            }
            int supplierNo = Convert.ToInt32(dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].ToString());
            Supplier supplier;
            //--------------------------------------------------------------------
            // �d����R�[�h����d����}�X�^���擾���A�x����R�[�h�Ɣ�r
            //--------------------------------------------------------------------
            int status = GetSupplier(out supplier, supplierNo);
            if (status != 0)
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�d����͑��݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                return;
            }
            this._paymentSlpSearch.ClearPaymentDataTableUH();
            this._paymentSlpSearch.GetPaymentInfoDataTable().ImportRow(dr);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void SFSIR02102UH_Load(object sender, EventArgs e)
        {
            this._paymentInfoTable = _paymentSlpSearch.GetPaymentInfoDataTableH();
            _paymentSlpSearch.ClearPaymentGdDataTable();
            this.tEdit_SectionCodeAllowZero.DataText = this._SectionCode;
            this.uLabel_SectionName.Text = this._SectionName;
            this._enterpriseCode = this._searchPaySlpInfoParameter.EnterpriseCode;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionCodeGuide_ultraButton.ImageList = imageList16;
            this.SectionCodeGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;
            this.uButton_StockCustomerGuide.ImageList = imageList16;
            this.uButton_StockCustomerGuide.Appearance.Image = Size16_Index.STAR1;

            this.tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Search"];
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._closeButton.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;

            this.gridPaymentList.DataSource = _paymentInfoTable;

            SetGridLayout();

            this._focusSetFlag = true;
            this._toolSearchFlag = true; // ADD ���N 2013/02/07 Redmine#33741
        }

        /// <summary>
        /// ���_�R�[�hEnter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���_�R�[�hEnter�C�x���g�B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Enter(object sender, EventArgs e)
        {
            // �[���l�߉���
            this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", this.tEdit_SectionCodeAllowZero.Text);
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : Guid�ɃL�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void gridPaymentList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.gridPaymentList.Rows.Count > 0 && this.gridPaymentList.ActiveRow != null)
                        {
                            if (this.gridPaymentList.Rows[0].Activated)
                            {
                                this.tNedit_SupplierCd.Focus();
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �O���b�h�����ݒ菈��
        /// </summary>
        /// <param name="uGrid">�x���O���b�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private void gridPaymentList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            // �s�I�����[�h�̐ݒ�
            uGrid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;

            // �s�I��ݒ� �s�I�𖳂����[�h(�A�N�e�B�u�̂�)
            uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            // �s�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.RowAppearance.BackColor = Color.White;

            // 1�s�����̊O�ϐݒ�
            uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // �I���s�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // �A�N�e�B�u�s�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // �w�b�_�[�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
            uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Left;
            uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Alpha.Transparent;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

            // �s�Z���N�^�[�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;

            // �s�t�B���^�[�̐ݒ�
            uGrid.DisplayLayout.Override.RowFilterAction = RowFilterAction.HideFilteredOutRows;

            // ���������̃X�N���[���X�^�C��
            uGrid.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            // ������ʕ\��(�X�v���b�^�[)�̕\���ݒ�
            uGrid.DisplayLayout.MaxRowScrollRegions = 1;

            // �X�N���[���o�[�ŏI�s����
            uGrid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

            // �w�b�_�[�N���b�N�A�N�V�����ݒ�
            uGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            // �u�Œ��v�v�b�V���s���A�C�R��������
            uGrid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
        }
        #endregion
    }
}