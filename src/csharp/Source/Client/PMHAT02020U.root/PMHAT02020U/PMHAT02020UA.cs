//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g
// �v���O�����T�v   : �����_�ݒ�}�X�^���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�gUI�t�H�[���N���X                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^���X�gUI�t�H�[�����s���B</br>      
    /// <br>Programmer : ������</br>                                   
    /// <br>Date       : 2009.03.26</br>                                       
    /// </remarks>
    public partial class PMHAT02020UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer	        // ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
       #region �� Constructor
        /// <summary>
        /// �����_�ݒ�}�X�^���X�gUI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���X�gUI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.03.26</br>                                       
        /// <br></br>
        /// </remarks>
        public PMHAT02020UA()
        {
           InitializeComponent();

           // ��ƃR�[�h�擾
           this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

           // ���O�C���S���� 
           this._employee = LoginInfoAcquisition.Employee.Clone();

           // ���_�R�[�h
           this._loginSectionCode = this._employee.BelongSectionCode;

       }
        #endregion �� Constructor

       #region �� Private Member
       #region �� Interface member
       //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
       // ���o�{�^����Ԏ擾�v���p�e�B
       private bool _canExtract = false;
       // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
       private bool _canPdf = true;
       // ����{�^����Ԏ擾�v���p�e�B
       private bool _canPrint = true;
       // ���o�{�^���\���L���v���p�e�B
       private bool _visibledExtractButton = false;
       // PDF�o�̓{�^���\���L���v���p�e�B	
       private bool _visibledPdfButton = true;
       // ����{�^���\���L���v���p�e�B
       private bool _visibledPrintButton = true;
       #endregion �� Interface member

       // ��ƃR�[�h
       private string _enterpriseCode = string.Empty;

       // ��ʃC���[�W�R���g���[�����i
       private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

       // ���_�R�[�h
       private string _loginSectionCode;

       // �q�ɃK�C�h�p
       WarehouseAcs _wareHouseAcs;

       // �d����K�C�h�p
       private SupplierAcs _supplierAcs;

       // ���[�J�[�K�C�h�p
       private MakerAcs _makerAcs;

       // ���i�����ރK�C�h�p
       private GoodsGroupUAcs _goodsGroupUAcs;

       // �O���[�v�R�[�h�K�C�h�p
       private BLGroupUAcs _blGroupUAcs;

       // BL�R�[�h�K�C�h�p
       private BLGoodsCdAcs _blGoodsCdAcs;

       // �S����
       private Employee _employee;
       
       // �t�H�[�J�XControl
       private Control _prevControl = null;

       // �`�F�b�N�G���[
       private bool hasCheckError = false;

       #endregion �� Private Member

       #region �� Private Const
       #region �� Interface member
       //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
       // �N���XID
       private const string ct_ClassID = "PMHAT02020UA";
       // �v���O����ID
       private const string ct_PGID = "PMHAT02020U";
       //// ���[����
       private const string PDF_PRINT_NAME = "�����_�ݒ�}�X�^";
       private string _printName = PDF_PRINT_NAME;
       // ���[�L�[	
        private const string PDF_PRINT_KEY = "97714852-acbf-4219-a389-29f3a7b9ba96";
       private string _printKey = PDF_PRINT_KEY;
       #endregion �� Interface member

       // ExporerBar �O���[�v����
       private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����
       //�G���[�������b�Z�[�W
       // const string ct_NoInput = "����͂��Ă��������B"; // DEL 2009/07/13 PVCS334
       const string ct_RangeError = "�͈̔͂Ɍ�肪����܂��B";

       // �J�n�K�C�h�t���O
       private const string ST_GUID = "1";

       // �I���K�C�h�t���O
       private const string ED_GUID = "2";
       #endregion
       
       #region �� Control Event
       #region �� PMHAT02020UA
       #region �� PMHAT02020UA_Load Event
       /// <summary>
       /// PMHAT02020UA_Load Event
       /// </summary>
       /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
       /// <param name="e">�C�x���g�p�����[�^</param>
       /// <remarks>
       /// <br>Note		  : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
       /// <br>Programmer : ������</br>                                   
       /// <br>Date       : 2009.03.26</br>                                       
       /// </remarks>
       private void PMHAT02020UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            // �R���g���[��������
            this.InitializeScreen();
            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��  
            // �������t�H�[�J�X
            this.Cursor = Cursors.WaitCursor;
            tNedit_PatterNo_St.Focus();
            _prevControl = tNedit_PatterNo_St;
            this.Cursor = Cursors.Default;

        }
       #endregion
       #endregion �� PMHAT02020UA

       #region �� ueb_MainExplorerBar
       #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
       #endregion

       #region �� GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }
       #endregion
       #endregion �� ueb_MainExplorerBar

       # region  �� tArrowKeyControl1_ChangeFocus
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_PatterNo_St)
                    {
                        // �ݒ�R�[�h(�J�n)���ݒ�R�[�h(�I��)
                        tNedit_PatterNo_St_AfterExitEditMode(e.PrevCtrl, null);
                        e.NextCtrl = this.tNedit_PatterNo_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PatterNo_Ed)
                    {
                        tNedit_PatterNo_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �ݒ�R�[�h(�I��)���q�ɃR�[�h(�J�n)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        tEdit_WarehouseCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �q��(�J�n)���q��(�I��)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        tEdit_WarehouseCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �q��(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        tNedit_SupplierCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �d����(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        tNedit_SupplierCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �d����(�I��)�����[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        tNedit_GoodsMakerCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // ���[�J�[(�J�n)�����[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        tNedit_GoodsMakerCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ���[�J�[(�I��)��������(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        tNedit_GoodsMGroup_St_AfterExitEditMode(e.PrevCtrl, null);
                        // ������(�J�n)��������(�I��)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        tNedit_GoodsMGroup_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ������(�I��)���O���[�v(�J�n)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        tNedit_BLGloupCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �O���[�v(�J�n)���O���[�v(�I��)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        tNedit_BLGloupCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �O���[�v(�I��)��bL�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        tNedit_BLGoodsCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // bL�R�[�h(�J�n)��bL�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        tNedit_BLGoodsCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // bL�R�[�h(�I��)�� ���s�^�C�v
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // ���s�^�C�v��  �ݒ�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_PatterNo_St;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    // �ݒ�R�[�h(�J�n)�����s�^�C�v
                    if (e.PrevCtrl == this.tNedit_PatterNo_St)
                    {
                        tNedit_PatterNo_St_AfterExitEditMode(e.PrevCtrl, null);
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // ���s�^�C�v�� bL�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        tNedit_BLGoodsCode_Ed_AfterExitEditMode(e.PrevCtrl, null);                        
                        // bL�R�[�h(�I��)�� bL�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        tNedit_BLGoodsCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // bL�R�[�h(�J�n)�� �O���[�v(�I��)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        tNedit_BLGloupCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �O���[�v(�I��)���O���[�v(�J�n)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        tNedit_BLGloupCode_St_AfterExitEditMode(e.PrevCtrl, null);                        
                        // �O���[�v(�J�n)��������(�I��)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        tNedit_GoodsMGroup_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ������(�I��)��������(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        tNedit_GoodsMGroup_St_AfterExitEditMode(e.PrevCtrl, null);
                        // ������(�J�n)�����[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        tNedit_GoodsMakerCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ���[�J�[(�I��)�����[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        tNedit_GoodsMakerCd_St_AfterExitEditMode(e.PrevCtrl, null);                        
                        // ���[�J�[(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        tNedit_SupplierCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �d����(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        tNedit_SupplierCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �d����(�J�n)���q��(�I��)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        tEdit_WarehouseCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �q��(�I��)���q��(�J�n)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        tEdit_WarehouseCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �q��(�J�n)���ݒ�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_PatterNo_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PatterNo_Ed)
                    {
                        tNedit_PatterNo_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �ݒ�R�[�h(�I��)���ݒ�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_PatterNo_St;
                    }
                }
            }
        }
        #endregion

       # region �� �K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �q�ɃK�C�h���N���b�N����Ƃ��ɔ�������</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_WareHouse_Click(object sender, EventArgs e)
        {
            if (this._wareHouseAcs == null)
            {
                this._wareHouseAcs = new WarehouseAcs();
            }
            // �q�ɃK�C�h�N��
            Warehouse warehouse;
            int status = this._wareHouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status != 0) return;
            // �q�ɊJ�n�K�C�h��I������ꍇ
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseCode_Ed.Focus();
            }
            // �q�ɏI���K�C�h��I������ꍇ
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tNedit_SupplierCd_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// �d����K�C�h�N���b�N
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �d����K�C�h���N���b�N����Ƃ��ɔ�������</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_SupplierCd_Click(object sender, EventArgs e)
        {
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            // �d����K�C�h�N��
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");
            if (status != 0) return;

            // �d����J�n�K�C�h��I������ꍇ
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tNedit_SupplierCd_Ed.Focus();
            }
            // �d����I���K�C�h��I������ꍇ
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                this.tNedit_GoodsMakerCd_St.Focus();
            }
            else
            {
                return;
            }

        }
        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�J�[�K�C�h���N���b�N����Ƃ��ɔ�������</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_Maker_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            // ���[�J�[�K�C�h�N��
            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            // ���[�J�[�J�n�K�C�h��I������ꍇ
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            // ���[�J�[�I���K�C�h��I������ꍇ
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMGroup_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// ���i�����ރK�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �����ރK�C�h���N���b�N����Ƃ��ɔ�������</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_GoodsMGroupCd_Click(object sender, EventArgs e)
        {
            // ���i�����ރK�C�h�N��
            GoodsGroupU goodgroupU;

            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);
            if (status != 0) return;
            // ���i�����ފJ�n�K�C�h��I������ꍇ
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_GoodsMGroup_Ed.Focus();
            }
            // ���i�����ޏI���K�C�h��I������ꍇ
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_BLGloupCode_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// �O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �O���[�v�K�C�h���N���b�N����Ƃ��ɔ�������</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_Group_Click(object sender, EventArgs e)
        {
            // �O���[�v�K�C�h�N��
            BLGroupU blGroupU;

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            // �O���[�v�J�n�K�C�h��I������ꍇ
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            // �O���[�v�I���K�C�h��I������ꍇ
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// �a�k�R�[�h�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �a�k�R�[�h�K�C�h���N���b�N����Ƃ��ɔ�������</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_BLGoodsCode_Click(object sender, EventArgs e)
        {
            // �a�k�R�[�h�K�C�h�N��
            BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            // �a�k�R�[�h�J�n�K�C�h��I������ꍇ
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            // �a�k�R�[�h�I���K�C�h��I������ꍇ
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tComboEditor_PrintType.Focus();

            }
            else
            {
                return;
            }
        }
        #endregion

       #region �� �t�H�[�J�X�A�E�g
        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ݒ�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_PatterNo_St_AfterExitEditMode(object sender, EventArgs e)
        {
            if (0 == this.tNedit_PatterNo_St.GetInt())
            {
                this.tNedit_PatterNo_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ݒ�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_PatterNo_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �ݒ�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_PatterNo_Ed.GetInt())
            {
                this.tNedit_PatterNo_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �q�ɃR�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (!IsNumber(this.tEdit_WarehouseCode_St.Text))
            {
                this.tEdit_WarehouseCode_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }

        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �q�ɃR�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (!IsNumber(this.tEdit_WarehouseCode_Ed.Text))
            {
                this.tEdit_WarehouseCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }

        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �d����R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_SupplierCd_St.GetInt())
            {
                this.tNedit_SupplierCd_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �d����R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_SupplierCd_Ed.GetInt())
            {
                this.tNedit_SupplierCd_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMakerCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���[�J�[�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMakerCd_St.GetInt())
            {
                this.tNedit_GoodsMakerCd_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMakerCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���[�J�[�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                this.tNedit_GoodsMakerCd_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �����ރR�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �����ރR�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMGroup_St.GetInt())
            {
                this.tNedit_GoodsMGroup_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �����ރR�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �����ރR�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMGroup_Ed.GetInt())
            {
                this.tNedit_GoodsMGroup_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �O���[�v�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGloupCode_St.GetInt())
            {
                this.tNedit_BLGloupCode_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �O���[�v�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
            {
                this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // BL�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGoodsCode_St.GetInt())
            {
                this.tNedit_BLGoodsCode_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // BL�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }
        #endregion

       #region �� �����𔻒f����
        /// <summary>
        /// �����𔻒f����
        /// </summary>
        /// <param name="s">������</param>
        /// <remarks>
        /// <br>Note		: �����𔻒f�������s��</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.04.16</br>
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
        #endregion

       #endregion �� Control Event

       #region �� Private Method
       #region �� ��ʏ������֌W
       #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R����ݒ肷��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

       #endregion

       #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.27</br>                                       
        /// </remarks>
        public void InitializeScreen()
        {
            //�ݒ�R�[�h
            this.tNedit_PatterNo_St.Clear();
            this.tNedit_PatterNo_Ed.Clear();
            //�q��
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_WarehouseCode_St.Clear();
            //�d����
            this.tNedit_SupplierCd_St.Clear();
            this.tNedit_SupplierCd_Ed.Clear();
            //���[�J�[
            this.tNedit_GoodsMakerCd_Ed.Clear();
            this.tNedit_GoodsMakerCd_St.Clear();
            //������
            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
            //�O���[�v
            this.tNedit_BLGoodsCode_Ed.Clear();
            this.tNedit_BLGloupCode_St.Clear();
            //�a�k�R�[�h
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();

            // ���s�^�C�v= �u0:�ʏ�v
            tComboEditor_PrintType.Value = 0;
           
            // �{�^���ݒ�
            this.SetIconImage(this.uButton_Ed_BLGoodsCode, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_GoodsMGroupCd, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_Group, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_Maker, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_WareHouse, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_SupplierCd, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_BLGoodsCode, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_GoodsMGroupCd, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_Group, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_Maker, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_WareHouse, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_SupplierCd, Size16_Index.STAR1);

        }
       #endregion �� ��ʏ���������
       #endregion �� ��ʏ������֌W

       #region �� ����O����
       #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.27</br>                                       
        /// </remarks>s		
        public bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
           
            //�ݒ�R�[�h
            /* ----DEL 2009/07/13 PVCS334 ---------->>>>>
            if (this.tNedit_PatterNo_St.DataText.TrimEnd() == string.Empty)
            {
                errMessage = string.Format("�ݒ�R�[�h{0}", ct_NoInput);
                errComponent = this.tNedit_PatterNo_St;
                status = false;
            }
            ------DEL 2009/07/13 PVCS334 ----------<<<<< */
            if ((this.tNedit_PatterNo_St.DataText.TrimEnd() != string.Empty)
              && (this.tNedit_PatterNo_Ed.DataText.TrimEnd() != string.Empty)
              && (this.tNedit_PatterNo_St.GetInt() > this.tNedit_PatterNo_Ed.GetInt()))
            {
                errMessage = string.Format("�ݒ�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_PatterNo_St;
                status = false;
            }
            //�q��
            else if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty)
              && (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty)
              && (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�q�ɃR�[�h{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            //�d����
            else if ((this.tNedit_SupplierCd_St.DataText.TrimEnd() != string.Empty)
                 && (this.tNedit_SupplierCd_Ed.DataText.TrimEnd() != string.Empty)
                 && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
                {
                errMessage = string.Format("�d����R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            //���[�J�[
            else if ((this.tNedit_GoodsMakerCd_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMakerCd_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            {
                errMessage = string.Format("���[�J�[�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            //������
            else if ((this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()))
            {
                errMessage = string.Format("�����ރR�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            //�O���[�v
            else if ((this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()))
            {
                errMessage = string.Format("�O���[�v�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            //�a�k�R�[�h
            else if ((this.tNedit_BLGoodsCode_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGoodsCode_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            return status;
        }
        #endregion �� ���̓`�F�b�N����

       #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <param name="_orderSetMasListPara">���o����</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note	   : ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.03.31</br>                                       
        /// </remarks>
        private int SetExtraInfoFromScreen( ref OrderSetMasListPara _orderSetMasListPara)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                _orderSetMasListPara.EnterpriseCode = this._enterpriseCode;

                // �ݒ�R�[�h(�J�n)
                // --- ADD 2009/07/13 PVCS334 ---------->>>>>
                if (0 != this.tNedit_PatterNo_St.GetInt())
                {
                    _orderSetMasListPara.StartSetCode = this.tNedit_PatterNo_St.GetInt().ToString("D3");
                }
                else
                {
                    _orderSetMasListPara.StartSetCode = string.Empty;
                }
                //--- ADD 2009/07/13 PVCS334----------<<<<<
                // DEL 2009/07/13 PVCS334
                // _orderSetMasListPara.StartSetCode = this.tNedit_PatterNo_St.GetInt().ToString("D3");
                // �ݒ�R�[�h(�I��)
                if (0 != this.tNedit_PatterNo_Ed.GetInt())
                {
                    _orderSetMasListPara.EndSetCode = this.tNedit_PatterNo_Ed.GetInt().ToString("D3");
                }
                else
                {
                    _orderSetMasListPara.EndSetCode = string.Empty;
                }
                // �q�ɃR�[�h(�J�n)
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode_St.Text))
                {
                    _orderSetMasListPara.StartWarehouseCode = this.tEdit_WarehouseCode_St.Text.Trim();
                }
                else 
                {
                    _orderSetMasListPara.StartWarehouseCode = string.Empty;
                }
                // �q�ɃR�[�h(�I��)
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode_Ed.Text))
                {
                    _orderSetMasListPara.EndWarehouseCode = this.tEdit_WarehouseCode_Ed.Text.Trim();
                }
                else
                {
                    _orderSetMasListPara.EndWarehouseCode = string.Empty;
                }
                // �d����R�[�h(�J�n)
                _orderSetMasListPara.StartSupplierCd = tNedit_SupplierCd_St.GetInt();
                // �d����R�[�h(�I��)
                _orderSetMasListPara.EndSupplierCd = tNedit_SupplierCd_Ed.GetInt();
                // ���[�J�[�R�[�h(�J�n)
                _orderSetMasListPara.StartGoodsMakerCd = tNedit_GoodsMakerCd_St.GetInt();
                // ���[�J�[�R�[�h(�I��)
                _orderSetMasListPara.EndGoodsMakerCd = tNedit_GoodsMakerCd_Ed.GetInt();
                // �����ރR�[�h(�J�n)
                _orderSetMasListPara.StartGoodsMGroup = tNedit_GoodsMGroup_St.GetInt();
                // �����ރR�[�h(�I��)
                _orderSetMasListPara.EndGoodsMGroup = tNedit_GoodsMGroup_Ed.GetInt();
                // �O���[�v�R�[�h(�J�n)
                _orderSetMasListPara.StartBLGroupCode = tNedit_BLGloupCode_St.GetInt();
                // �O���[�v�R�[�h(�I��)
                _orderSetMasListPara.EndBLGroupCode = tNedit_BLGloupCode_Ed.GetInt();
                // �a�k�R�[�h(�J�n)
                _orderSetMasListPara.StartBLGoodsCode = tNedit_BLGoodsCode_St.GetInt();
                // �a�k�R�[�h(�I��)
                _orderSetMasListPara.EndBLGoodsCode = tNedit_BLGoodsCode_Ed.GetInt();
                // ���s�^�C�v
                _orderSetMasListPara.PrintType = (int)tComboEditor_PrintType.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
       
       #endregion �� ����O����

       #region �� �G���[���b�Z�[�W ��
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.03.26</br>                                       
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
       #endregion �� �G���[���b�Z�[�W ��
       #endregion �� Private Method 

       #region �� IPrintConditionInpType �����o
       #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

       #region �� Public Property
        /// <summary> ���o�{�^�����</summary>
        /// <value>CanExtract</value>               
        /// <remarks>���o�{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^�����</summary>
        /// <value>CanPdf</value>               
        /// <remarks>PDF�o�̓{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^�����</summary>
        /// <value>CanPrint</value>               
        /// <remarks>����{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>���o�{�^���\���L���擾�v���p�e�B </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L��</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF�o�̓{�^���\���L���v���p�e�B�擾�v���p�e�B </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\��</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>����{�^���\���擾�v���p�e�B </remarks> 
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� Public Property

       #region �� Public Method
       #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : ���o���s���܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
       #endregion

       #region �� �������
       /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
       public int Print(ref object parameter)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnlineStatus("PDF�̃f�[�^�o�͏���"))
            {
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;
            printInfo.PrintPaperSetCd = 0;

            // ���o�����N���X
            OrderSetMasListPara _orderSetMasListPara = new OrderSetMasListPara();


            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen(ref _orderSetMasListPara);
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = _orderSetMasListPara;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y���f�[�^������܂���B", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
       #endregion

       #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }
            // �t�H�[�J�X�A�E�g����
            if (this._prevControl != null)
            {
                hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tArrowKeyControl1_ChangeFocus(this, e);
            }
            if (hasCheckError)
            {
                status = false;
            }

            return status;
        }
        #endregion    

       #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }

        #endregion

        #endregion �� Public Method
       #endregion �� IPrintConditionInpType �����o

       #region �� IPrintConditionInpTypePdfCareer �����o
       #region �� Public Property

        /// <summary> ���[�L�[</summary>
        /// <value>PrintKey</value>               
        /// <remarks>���[�L�[�擾�v���p�e�B </remarks>  
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> ���[��</summary>
        /// <value>PrintName</value>               
        /// <remarks>���[���擾�v�v���p�e�B </remarks>  
        public string PrintName
        {
            get { return _printName; }
        }

        #endregion �� Public Method
       #endregion �� IPrintConditionInpTypePdfCareer �����o

       #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>
        /// �I�t���C���`�F�b�N���O�o�͂��鏈��
        /// </summary>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: �I�t���C���`�F�b�N���O�o�͂��鏈�����s���B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private bool CheckOnlineStatus(String msg)
        {
            bool succFlg = true;

            // �I�t���C����ԃ`�F�b�N									
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    msg + "�Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                succFlg = false;
            }

            return succFlg;
        }
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// �����[�g�ڑ��\���菈��
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note		: �����[�g�ڑ��\���菈�����s���B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private bool CheckRemoteOn()
        {

            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

       
 
    }
}