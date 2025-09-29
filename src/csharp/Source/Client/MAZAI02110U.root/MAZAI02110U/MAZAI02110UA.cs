//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �I���֘A�ꗗ�\
// �v���O�����T�v   : �I���֘A�ꗗ�\ �t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� �m
// �� �� ��  2007/04/09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2007/09/05  �C�����e : DC.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/02/13  �C�����e : �s��Ή��iDC.NS�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2008/10/07  �C�����e : PM.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/13  �C�����e : ��Q�Ή�13108
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2009/12/04  �C�����e : �s��Ή�(PM.NS�ێ�˗��B�Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : ������
// �C �� ��  2010/02/20  �C�����e : �s��Ή�(PM1005)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : liyp
// �C �� ��  2011/01/11  �C�����e : �s��Ή�(PM1101B)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2011/01/11  �C�����e : �I����Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2011/02/17  �C�����e : �I�������\�̒I�ԃu���C�N�敪�̗L�������̃`�F�b�N�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/11/14  �C�����e : 2013/01/16�z�M���ARedmine#33271
//                                  �󎚐���̋敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���j��
// �� �� ��  2012/12/25  �C�����e : 2013/01/16�z�M���ARedmine#33271
//                                  ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵����
//                                  �̂��L�������邱�Ƃ̐ݒ��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11000606-00 �쐬�S�� : licb
// �� �� ��  K2014/03/10 �C�����e : �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����                                 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData; // 2008.02.13 �ǉ�
using Broadleaf.Library.Windows;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �I���֘A�ꗗ�\ �t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I���֘A�ꗗ�\ �t�h�N���X�̏o�͏������͂��s���܂��B</br>
    /// <br>Programmer : 23010 ���� �m</br>
    /// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.05 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.02.13 980035 ���� ��`</br>
    /// <br>			 �E�s��Ή��iDC.NS�Ή��j</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.10.07</br>
    /// <br>Update Note: 2009/04/13 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�13108</br>
    /// <br>Update Note: 2009/12/04 ������</br>
    /// <br>			 �s��Ή�(PM.NS�ێ�˗��B�Ή�)</br>
    /// <br>Update Note: 2010/02/20 ������</br>
    /// <br>			 �s��Ή�(PM1005)</br> 
    /// <br>Update Note: 2011/01/11 �c����</br>
    /// <br>			 �I����Q�Ή�</br> 
    /// <br>Update Note: 2011/02/17 �c����</br>
    /// <br>			 �I�������\�̒I�ԃu���C�N�敪�̗L�������̃`�F�b�N�ɂ���</br>
    /// <br>Update Note: 2012/11/14 ������</br>
    ///	<br>			 Redmine#33271 �󎚐���̋敪�̒ǉ�</br> 
    /// <br>Update Note: 2012/12/25 ���j��</br>
    ///	<br>			 Redmine#33271 ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵�����̂��L�������邱�Ƃ̐ݒ��ǉ�����</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
    /// <br></br>
    /// </remarks>
    public partial class MAZAI02110UA : Form,
                                        IPrintConditionInpType,						// ���[����(�������̓^�C�v)
                                        IPrintConditionInpTypeSelectedSection,		// ���[�Ɩ�(��������)���_�I��
                                        IPrintConditionInpTypePdfCareer,            // ���[�Ɩ�(��������)PDF�o�͗����Ǘ�
        �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@// --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
                                        IPrintConditionInpTypeTextOutPut,           //�e�L�X�g�o�́@
                                        IPrintConditionInpTypeTextOutControl        //�I�v�V�����̐���
    �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@// --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
    {

        #region Constructor
        // <summary>
        /// �I���֘A�ꗗ�\ �t�h�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���֘A�ꗗ�\ �t�h�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 23010 ���� �m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2012/12/25 ���j��</br>
        ///	<br>			 Redmine#33271 ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵�����̂��L�������邱�Ƃ̐ݒ��ǉ�����</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
        /// <br></br>
        /// </remarks>
        public MAZAI02110UA()
        {
            InitializeComponent();
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //�L�����A�p���X�g
            this._carrierList = new SortedList();
            //��ʃf�U�C���ύX�N���X
            this._controlScreenSkin = new ControlScreenSkin();

   
			// ���O�C����񐶐� //
			if (LoginInfoAcquisition.Employee != null)
			{
				Employee _employee = new Employee();
				_employee = LoginInfoAcquisition.Employee;
     
				// ��ƃR�[�h
				this._enterpriseCode = _employee.EnterpriseCode;
                // ���_�R�[�h
                this._sectionCode = _employee.BelongSectionCode;             
				// ���O�C���]�ƈ��R�[�h
				this._employeeCode = _employee.EmployeeCode;
				// ���O�C���]�ƈ�����
				this._employeeName = _employee.Name;
			}

            // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 >>>>>>START
            ////���Ӑ���A�N�Z�X�N���X
            //this._customerInfoAcs = new CustomerInfoAcs();
            // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 <<<<<<END
            
            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            //�I�����������A�N�Z�X�N���X
            this._inventoryPrepareAcs = new InventoryPrepareAcs();
            // 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2008.10.08 30413 ���� �d����K�C�h�A�N�Z�X�N���X�̒ǉ� >>>>>>START
            // �d����A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();
            // 2008.10.08 30413 ���� �d����K�C�h�A�N�Z�X�N���X�̒ǉ� <<<<<<END

            // 2008.11.26 30413 ���� BL�O���[�v�A�N�Z�X�N���X�̒ǉ� >>>>>>START
            this._blGroupUAcs = new BLGroupUAcs();
            // 2008.11.26 30413 ���� BL�O���[�v�A�N�Z�X�N���X�̒ǉ� <<<<<<END

            // 2008.11.26 30413 ���� �݌ɊǗ��S�̐ݒ�A�N�Z�X�N���X�̒ǉ� >>>>>>START
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            // 2008.11.26 30413 ���� �݌ɊǗ��S�̐ݒ�A�N�Z�X�N���X�̒ǉ� <<<<<<END

            //---ADD ���j�� 2012/12/25 for Redmine#33271-------------->>>>>
            tComboEditor_LineMaSqOfChDiv0.Visible = false;
            tComboEditor_LineMaSqOfChDiv1.Visible = false;
            tComboEditor_LineMaSqOfChDiv2.Visible = false;
            //---ADD ���j�� 2012/12/25 for Redmine#33271--------------<<<<<
            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            this._inventoryListCmnAcs = new InventoryListCmnAcs();
            this._warehouseAcs = new WarehouseAcs();
            //�d����ArrayList
            _supplierAl = new ArrayList();
            _warehouseAl = new ArrayList();
            _MakerAl = new ArrayList();
            _stockMngTtlStAl = new ArrayList();
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

        }
        #endregion

        # region �G���g�� �|�C���g
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAZAI02110UA());
        }
        #endregion

        #region Events
        /// <summary>�t���[���c�[���o�[�ݒ�C�x���g</summary>
        public event Broadleaf.Application.Common.ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Private Members
        // ��ƃR�[�h
        private string _enterpriseCode = "";       
        // ���o�����N���X
        private InventSearchCndtnUI _inventSearchCndtnUI = new InventSearchCndtnUI();      
        //�݌ɍX�V���_�R�[�h(�q�ɃK�C�h���Ɏg�p)
        //private string _stockUpdateSecCd = "";
        // �݌ɍX�V���_���
        //private SecInfoSet _stockSecInfoSet;
        private string _employeeCode;		// �S���҃R�[�h
		private string _employeeName;		// �S���Җ���
        //���O�C�����_
        private string _sectionCode;    

        // ------------------------------
        // IPrintConditionInpType�̃v���p�e�B�p�ϐ�
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

        // ------------------------------
        // IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ�
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L���v���p�e�B
        private bool _isOptSection = false;
        // �{�Ћ@�\�L���v���p�e�B
        private bool _isMainOfficeFunc = false;

        // ------------------------------
        // IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ�
        // ���[����
        private string _printName = "";
        // ���[�L�[
        private string _printKey = "";

        // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
        //IPrintConditionInpTypeTextOutPut�̃v���p�e�B�p�ϐ�
        private bool _isCanTextOutPut = false;
        private string _outPutFileName = string.Empty;
        private ArrayList _supplierAl;
        private InventoryListCmnAcs _inventoryListCmnAcs = null;    // �I���֘A�ꗗ�\�A�N�Z�X�N���X
        private MAZAI02110UB _textOutDialog;
        private WarehouseAcs _warehouseAcs;
        private ArrayList _warehouseAl;
        private ArrayList _MakerAl;
        private ArrayList _stockMngTtlStAl;
        private StockMngTtlSt _stockMngTtlSt;
        // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
             
        //�N�����[
        private int _selPrintMode;  // 0:�I���L���\1:�I�����ٕ\:2:�I���\
        ///��ʃf�U�C���ύX�N���X
        private ControlScreenSkin _controlScreenSkin;

        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 >>>>>>START
        ////�d����K�C�h�N��������C���f�b�N�X
        //private int _custmerGuideIndex;
        ////�ϑ���K�C�h�N��������C���f�b�N�X
        //private int _shipCustmerGuideIndex;
        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 <<<<<<END

        ///���[�J�[�}�X�^�A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;

        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 >>>>>>START
        /////���i�敪�O���[�v�}�X�^�A�N�Z�X�N���X
        //private LGoodsGanreAcs _lGoodsGanreAcs = null;
        /////���i�敪�}�X�^�A�N�Z�X�N���X
        //private MGoodsGanreAcs _mGoodsGanreAcs = null;
        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 <<<<<<END
        
        //�L�����A�p���X�g
        private SortedList _carrierList = null;

        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 >>>>>>START
        ////���Ӑ���A�N�Z�X�N���X
        //private CustomerInfoAcs _customerInfoAcs;
        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 <<<<<<END
        
        // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
        ////���Ǝ҃}�X�^�A�N�Z�X�N���X
        //private CarrierEpAcs _carrierEpGuide = null;
        ////�L�����A�K�C�h
        //private CarrierOdrAcs _carrierOdrAcs = null;
        ////�@��K�C�h
        //private CellphoneModelAcs _cellphoneModelAcs = null;

        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 >>>>>>START
        ////���i�敪�ڍ׃}�X�^�A�N�Z�X�N���X
        //private DGoodsGanreAcs _dGoodsGanreAcs = null;
        ////���Е��ރK�C�h
        //private UserGuideGuide _userGuideGuide = null;
        // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 <<<<<<END
        
        //�a�k���i�}�X�^�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs = null;
        // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<

        // 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
        // �I�����������A�N�Z�X�N���X
        private InventoryPrepareAcs _inventoryPrepareAcs = null;
        // 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<

        // 2008.10.08 30413 ���� �d����K�C�h�A�N�Z�X�N���X�̒ǉ� >>>>>>START
        // �d����K�C�h
        private SupplierAcs _supplierAcs;
        // 2008.10.08 30413 ���� �d����K�C�h�A�N�Z�X�N���X�̒ǉ� <<<<<<END

        // 2008.11.26 30413 ���� BL�O���[�v�A�N�Z�X�N���X�̒ǉ� >>>>>>START
        BLGroupUAcs _blGroupUAcs = null;
        // 2008.11.26 30413 ���� BL�O���[�v�A�N�Z�X�N���X�̒ǉ� <<<<<<END
        
        // 2008.11.26 30413 ���� �݌ɊǗ��S�̐ݒ�A�N�Z�X�N���X�̒ǉ� >>>>>>START
        StockMngTtlStAcs _stockMngTtlStAcs = null;
        // 2008.11.26 30413 ���� �݌ɊǗ��S�̐ݒ�A�N�Z�X�N���X�̒ǉ� <<<<<<END

        List<Control> ctrlList = new List<Control>();//ADD ���j�� 2012/12/25 for Redmine#33271
        #endregion

        #region Private Constant
        // �N���XID
        private const string CT_CLASSID = "MAZAI02110UA";
        // �v���O����ID
        private const string CT_PGID = "MAZAI02110U";
        // �v���O��������
        private const string CT_PGNM = "�I���֘A�ꗗ�\";
        // �L�[���
        private const string PRINT_KEY01 = "baa409ca-5d89-41eb-a5f0-82bf716c0641";
        private const string PRINT_KEY02 = "d45e41e1-3f42-46f5-aac3-00ac832e4a07";
        private const string PRINT_KEY03 = "b0fa554d-13d9-481a-b71b-34b202de9cfb";
      
        private const string PRINT_NAME_01 = "�I���L���\";
        private const string PRINT_NAME_02 = "�I�����ٕ\";
        private const string PRINT_NAME_03 = "�I���\";
    
        //�o�͏�
        private const string CHANGEPAGEDIV1_01    = "�d�����";
        private const string CHANGEPAGEDIV1_02    = "���Ӑ��";
        private const string CHANGEPAGEDIV1_03    = "���Ǝҕ�";

        //�o�͍���
        private const string CTOUTPUTPATERN01 = "���됔�O�o��";
        private const string CTOUTPUTPATERN02 = "�I�����O�o��";
        //���t����
        private const string CTDATENAMEPATERN01 = "�I������������";
        private const string CTDATENAMEPATERN02 = "�I����";

        // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
        /// <summary> �q�ɃR�[�h </summary>
        private const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ� </summary>
        private const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> �I�� </summary>
        private const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> �i�� </summary>
        private const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> �i�� </summary>
        private const string ct_Col_GoodsName = "GoodsName";
        /// <summary> �d����R�[�h </summary>
        private const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> �d���於 </summary>
        private const string ct_Col_SupplierName = "SupplierName";
        /// <summary> BL�R�[�h </summary>
        private const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> ���[�J�[�R�[�h </summary>
        private const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[�� </summary>
        private const string ct_Col_MakerName = "MakerName";
        /// <summary> �I���� </summary>
        private const string ct_Col_StockCount = "StockCount";
        /// <summary> �W�����i </summary>
        private const string ct_Col_ListPrice = "ListPrice";
        /// <summary> �݌ɒP�� </summary>
        private const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> �I�����z</summary>
        private const string ct_Col_StockAmountPrice = "StockAmountPrice";
        /// <summary> �I���A��</summary>
        private const string ct_Col_InventorySeqNo = "InventorySeqNo";

        // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
                  
        #endregion
        
        #region Properties
        // ------------------------------
        // IPrintConditionInpType�̃v���p�e�B
        /// <summary>
        /// ���o�{�^����Ԏ擾�v���p�e�B
        /// </summary>
        public bool CanExtract
        {
            get
            {
                return this._canExtract;
            }
        }

        /// <summary>
        /// PDF�o�̓{�^����Ԏ擾�v���p�e�B
        /// </summary>
        public bool CanPdf
        {
            get
            {
                return this._canPdf;
            }
        }

        /// <summary>
        /// ����{�^����Ԏ擾�v���p�e�B
        /// </summary>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>
        /// ���o�{�^���\���L���v���p�e�B
        /// </summary>
        public bool VisibledExtractButton
        {
            get
            {
                return this._visibledExtractButton;
            }
        }

        /// <summary>
        /// PDF�o�̓{�^���\���L���v���p�e�B
        /// </summary>
        public bool VisibledPdfButton
        {
            get
            {
                return this._visibledPdfButton;
            }
        }

        /// <summary>
        /// ����{�^���\���L���v���p�e�B
        /// </summary>
        public bool VisibledPrintButton
        {
            get
            {
                return this._visibledPrintButton;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypeSelectedSection�̃v���p�e�B
        /// <summary>
        /// �v�㋒�_�I��\���擾�v���p�e�B
        /// </summary>
        public bool VisibledSelectAddUpCd
        {
            get
            {
                return this._visibledSelectAddUpCd;
            }
        }

        /// <summary>
        /// ���_�I�v�V�����L���v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get
            {               
                return this._isOptSection;
            }
            set
            {
                this._isOptSection = value;
            }
        }

        /// <summary>
        /// �{�Ћ@�\�L���v���p�e�B
        /// </summary>
        public bool IsMainOfficeFunc
        {
            get
            {
                return this._isMainOfficeFunc;
            }
            set
            {
                this._isMainOfficeFunc = value;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ�
        /// <summary>
        /// ���[����
        /// </summary>
        public string PrintName
        {
            get
            {
                return this._printName;
            }
        }

        /// <summary>
        /// ���[�L�[
        /// </summary>
        public string PrintKey
        {
            get
            {
                return this._printKey;
            }
        }

        // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
        // IPrintConditionInpTypeTextOutPut�̃v���p�e�B�p�ϐ�
        /// <summary>
        /// �o�͋@�\�̐���
        /// </summary>
        public bool CanTextOutPut
        {
            get
            {
                return this._isCanTextOutPut;
            }
        }
        // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
        #endregion

        #region Public Methods

        // ------------------------------
        // IPrintConditionInpType�̃v���p�e�B
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">���[�ݒ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʕ\���������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._selPrintMode = 0;
            //�^�`�F�b�N�iString���ǂ����j
            if (parameter is string)
            {
                //�N�����[�h���擾���܂��i0�F�I�������\�A1:�I�����ٕ\�A2:�I���\�j
                this._selPrintMode = TStrConv.StrToIntDef((string)parameter, 0);
            }
            //�N�����[�h��0�A1�A2�ȊO�̒l�ł���΁A�f�t�H���g(�I�������\)�Ƃ���
            if ((this._selPrintMode != 0) && (this._selPrintMode != 1) && (this._selPrintMode != 2))
            {
                this._selPrintMode = 0;
            }

            switch (this._selPrintMode)
            {
                case 0:
                    {
                        this._printName = PRINT_NAME_01;
                        this._printKey = PRINT_KEY01;
                        //---ADD ���j�� 2012/12/25 for Redmine#33271-------------->>>>>
                        ctrlList.Clear();
                        ctrlList.Add(tComboEditor_LineMaSqOfChDiv0);        // �r����
                        uiMemInput1.OptionCode = "0";//�i0�F�I�������\�A1:�I�����ٕ\�A2:�I���\�j
                        //---ADD ���j�� 2012/12/25 for Redmine#33271--------------<<<<<
                        break;
                    }
                case 1:
                    {
                        this._printName = PRINT_NAME_02;
                        this._printKey = PRINT_KEY02;
                        //---ADD ���j�� 2012/12/25 for Redmine#33271-------------->>>>>
                        ctrlList.Clear();
                        ctrlList.Add(tComboEditor_LineMaSqOfChDiv1);        // �r����
                        uiMemInput1.OptionCode = "1";//�i0�F�I�������\�A1:�I�����ٕ\�A2:�I���\�j
                        //---ADD ���j�� 2012/12/25 for Redmine#33271--------------<<<<<
                        break;
                    }
                case 2:
                    {
                        this._printName = PRINT_NAME_03;
                        this._printKey = PRINT_KEY03;
                        //---ADD ���j�� 2012/12/25 for Redmine#33271-------------->>>>>
                        ctrlList.Clear();
                        ctrlList.Add(tComboEditor_LineMaSqOfChDiv2);        // �r����
                        uiMemInput1.OptionCode = "2";//�i0�F�I�������\�A1:�I�����ٕ\�A2:�I���\�j
                        //---ADD ���j�� 2012/12/25 for Redmine#33271--------------<<<<<
                        // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
                        PurchaseStatus sletuPurchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinetsuInventoryListCtl);
                        if (sletuPurchaseStatus == PurchaseStatus.Contract ||// �_���
                                sletuPurchaseStatus == PurchaseStatus.Trial_Contract)// �̌��Ō_���
                        {
                            this._isCanTextOutPut = true;
                        }
                        if (TextOutControlCall != null)
                        {
                            this.TextOutControlCall();
                        }
                        // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
                        break;
                    }
            }
            uiMemInput1.TargetControls = ctrlList;//ADD ���j�� 2012/12/25 for Redmine#33271
            this.Show();
        }

        /// <summary>
        /// ����O���̓`�F�b�N
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ����O���̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool result = true;

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

                result = false;
            }

            return result;
        }
      		
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">������p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = CT_PGID;// �N��PGID
            //�N�����[�h�ʂɐݒ�R�[�h���Z�b�g
            switch(this._selPrintMode)
            {
                //�I�������\
                case 0:
                {
                    printInfo.PrintPaperSetCd = 0;
                    break;
                }
                //�I�����ٕ\
                case 1:
                {
                    printInfo.PrintPaperSetCd = 10;
                    break;
                }
                //�I���\
                case 2:
                {
                    printInfo.PrintPaperSetCd = 20;
                    break;
                }
            }
            
            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // ��ʁ����o�����N���X
            int status = this.SetExtrInfoFromScreen(ref this._inventSearchCndtnUI);
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._inventSearchCndtnUI;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">������p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // ���o�����͖���
            //return 0;//DEL licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����
            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            PurchaseStatus sletuPurchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinetsuInventoryListCtl);
            if (sletuPurchaseStatus == PurchaseStatus.Contract ||// �_���
                    sletuPurchaseStatus == PurchaseStatus.Trial_Contract)// �̌��Ō_���
            {
                SFCMN06002C outTextInfo = (SFCMN06002C)parameter;
                if (_textOutDialog == null)
                {
                    _textOutDialog = new MAZAI02110UB();
                }
                if (_textOutDialog.ShowDialog() == DialogResult.OK)
                {
                    //�o�̓t�@�C����
                    this._outPutFileName = _textOutDialog._outPutFileName;
                    string resultMessage = "";
                    emErrorLevel iLevel = emErrorLevel.ERR_LEVEL_INFO;
                    SFCMN00299CA form = new SFCMN00299CA();
                    // �\��������ݒ�
                    form.Title = "�e�L�X�g���o��";
                    form.Message = "���݁A�f�[�^�𒊏o���ł��B" + "\r\n" + "���΂炭���҂���������";
                    try
                    {
                        // �_�C�A���O�\��
                        form.Show();
                        this.Cursor = Cursors.WaitCursor;
                        InventSearchCndtnUI textOutInventSearchCndtnUI = new InventSearchCndtnUI();

                        // ��ʁ����o�����N���X
                        this.SetExtrInfoFromScreen(ref textOutInventSearchCndtnUI);

                        //����
                        //�f�[�^�擾
                        string message = string.Empty;
                        status = this._inventoryListCmnAcs.Search(textOutInventSearchCndtnUI, out message);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �t�B���^�[������
                            string strFilter = string.Empty;
                            // �\�[�g��������擾
                            string strSort = this.MakeSortingOrderString(textOutInventSearchCndtnUI);

                            DataView dv = new DataView(this._inventoryListCmnAcs._printDataSet.Tables[MAZAI02114EA.InventoryListDataTable], strFilter, strSort, DataViewRowState.CurrentRows);

                            if (dv.Count > 0)
                            {
                                // �f�[�^���Z�b�g
                                outTextInfo.rdData = dv;
                                outTextInfo.jyoken = textOutInventSearchCndtnUI;
                                parameter = (object)outTextInfo;

                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                resultMessage = "�Y������f�[�^������܂���B";
                                iLevel = emErrorLevel.ERR_LEVEL_INFO;
                            }
                        }
                        //// �Y���f�[�^����
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            resultMessage = "�Y������f�[�^������܂���B";
                            iLevel = emErrorLevel.ERR_LEVEL_INFO;
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        // �_�C�A���O�����
                        form.Close();
                    }
                    // ���b�Z�[�W�\��
                    if (!string.IsNullOrEmpty(resultMessage))
                    {
                        TMsgDisp.Show(iLevel, CT_PGID, resultMessage, 0, MessageBoxButtons.OK);
                    }
                }
            }
                return status;
            
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

        }

        // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
        #region IPrintConditionInpTypeTextOutPut �����o
        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="parameter">�o��Info</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        public int OutPutText(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            //�d��������擾
            this.GetSupplierInfo();
            //�q�ɏ����擾
            this.GetWareHouseInfo();
            //���[�J�[�����擾
            this.GetMakerInfo();
            //�݌ɊǗ��S�̐ݒ�����擾
            this.GetStockMngTtl();

            SFCMN06002C outPutTextInfo = (SFCMN06002C)parameter;
            DataTable dataTable = new DataTable();

            //DataTable��Columns��ǉ�����
            this.CreateDataTable(ref dataTable);

            DataView dv = outPutTextInfo.rdData as DataView;
            char[] zero ={'0'};
            DataTable dt = dv.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                // �q�ɃR�[�h 
                dataRow[ct_Col_WarehouseCode] = dt.Rows[i][MAZAI02114EA.ctCol_WarehouseCode].ToString().TrimStart(zero);
                //�q�ɖ�
                dataRow[ct_Col_WarehouseName] = this.GetWareHouseName(dt.Rows[i][MAZAI02114EA.ctCol_WarehouseCode].ToString());
                //�I��
                dataRow[ct_Col_WarehouseShelfNo] = dt.Rows[i][MAZAI02114EA.ctCol_WarehouseShelfNo];
                //�i��
                dataRow[ct_Col_GoodsNo] = dt.Rows[i][MAZAI02114EA.ctCol_GoodsNo];
                //�i��
                dataRow[ct_Col_GoodsName] = dt.Rows[i][MAZAI02114EA.ctCol_GoodsName];
                //�d����R�[�h
                dataRow[ct_Col_SupplierCd] = dt.Rows[i][MAZAI02114EA.ctCol_SupplierCd];
                //�d���於
                dataRow[ct_Col_SupplierName] = this.GetSupplierName((Int32)dt.Rows[i][MAZAI02114EA.ctCol_SupplierCd]);
                //BL�R�[�h
                dataRow[ct_Col_BLGoodsCode] = dt.Rows[i][MAZAI02114EA.ctCol_BLGoodsCode];
                //���[�J�[�R�[�h
                dataRow[ct_Col_GoodsMakerCd] = dt.Rows[i][MAZAI02114EA.ctCol_GoodsMakerCd];
                //���[�J�[��
                dataRow[ct_Col_MakerName] = this.GetMakerName((Int32)dt.Rows[i][MAZAI02114EA.ctCol_GoodsMakerCd]);
                //�I����
                dataRow[ct_Col_StockCount] = Math.Floor(GetStockCount(dt.Rows[i]));
                //�W�����i
                dataRow[ct_Col_ListPrice] = Math.Round(Convert.ToDouble(dt.Rows[i][MAZAI02114EA.ctCol_ListPriceTextOut]), 0);
                //�݌ɒP��
                dataRow[ct_Col_StockUnitPriceFl] = Math.Round(Convert.ToDouble(dt.Rows[i][MAZAI02114EA.ctCol_StockUnitPriceFl]), 2);
                //�I�����z
                dataRow[ct_Col_StockAmountPrice] = (long)Math.Floor(GetStockCount(dt.Rows[i]) * Convert.ToDouble(dataRow[ct_Col_StockUnitPriceFl]) + 0.5);
                //�I���A��
                dataRow[ct_Col_InventorySeqNo] = dt.Rows[i][MAZAI02114EA.ctCol_InventorySeqNo];

                dataTable.Rows.Add(dataRow);

            }

            // ���o�f�[�^�擾
            FormattedTextWriter printInfo = new FormattedTextWriter();
            Object paraInfo = (object)printInfo;

            // CSV�o�͏�񏈗�
            this.GetCSVInfo(ref paraInfo, dataTable, _outPutFileName);

            emErrorLevel iLevel = emErrorLevel.ERR_LEVEL_INFO;
            string resultMessage = string.Empty;
            // CSV�o�͏���
            status = this.DoOutPut(ref paraInfo, ref resultMessage, ref iLevel);
            // ���b�Z�[�W�\��
            if (!string.IsNullOrEmpty(resultMessage))
            {
                TMsgDisp.Show(iLevel, CT_PGID, resultMessage, 0, MessageBoxButtons.OK);
            }

            return status;

        }

        /// <summary>
        /// �I�������擾
        /// </summary>
        /// <param name="dataRow">DataRow</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �I�������擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private double GetStockCount(DataRow dataRow)
        {
            double stockCount = 0;
            if (_stockMngTtlSt.InventoryMngDiv == 1) // �I���^�p�敪��PM7
            {
                //�I���� = �I���݌ɐ��iInventoryStockCnt�j
                stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_InventoryStockCntTextOut]);
                try
                {
                    DateTime dt = this.GetDateTime((dataRow[MAZAI02114EA.ctCol_InventoryDay].ToString()));
                    if (dt == DateTime.MinValue)           // �I�������͂̃��R�[�h
                      
                    {
                        //�I���� = �݌ɑ����iStockTotal�j
                        stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_StockTotal]);
                    }
                }
                catch
                {
                    //�I���� = �݌ɑ����iStockTotal�j
                    stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_StockTotal]);
                }
            }
            else                                        // �I���^�p�敪��PM.NS
            {
                //�I���� = �݌ɑ����iStockTotal�j + �I�����ِ��iInventoryTolerancCnt�j
                stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_StockTotal]) +  Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_InventoryTolerancCnt]);
            }

            return stockCount;
        }

        /// <summary>
        ///string����DateTime�ɓ]��
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Int64����DateTime�ɓ]���B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private  DateTime GetDateTime(string date)
        {
            DateTime dt = DateTime.MinValue;
            try
            {
                if (date.ToString().Length == 8)
                {
                    string DateStr = date.ToString();
                    int year = Convert.ToInt32(DateStr.Substring(0, 4));
                    int month = Convert.ToInt32(DateStr.Substring(4, 2));
                    int day = Convert.ToInt32(DateStr.Substring(6, 2));

                    dt = new DateTime(year, month, day);
                }
            }
            catch
            {
                 dt = DateTime.MinValue;
            }
            return dt;

        }

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add(ct_Col_WarehouseCode, typeof(Int32));// �q�ɃR�[�h
            dataTable.Columns.Add(ct_Col_WarehouseName, typeof(string));//�q�ɖ�
            dataTable.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));//�I��
            dataTable.Columns.Add(ct_Col_GoodsNo, typeof(string));//�i��
            dataTable.Columns.Add(ct_Col_GoodsName, typeof(string));//�i��
            dataTable.Columns.Add(ct_Col_SupplierCd, typeof(Int32));//�d����R�[�h
            dataTable.Columns.Add(ct_Col_SupplierName, typeof(string));//�d���於
            dataTable.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));//BL�R�[�h
            dataTable.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));//���[�J�[�R�[�h
            dataTable.Columns.Add(ct_Col_MakerName, typeof(string));//���[�J�[��
            dataTable.Columns.Add(ct_Col_StockCount, typeof(long));//�I����
            dataTable.Columns.Add(ct_Col_ListPrice, typeof(Int32));//�W�����i
            dataTable.Columns.Add(ct_Col_StockUnitPriceFl, typeof(double));//�݌ɒP��
            dataTable.Columns.Add(ct_Col_StockAmountPrice, typeof(long));//�I�����z
            dataTable.Columns.Add(ct_Col_InventorySeqNo, typeof(long));//�I���A��
        }

        /// <summary>
        ///�d��������擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetSupplierInfo()
        {
            ArrayList tempAl = new ArrayList();

            this._supplierAcs.SearchAll(out tempAl, _enterpriseCode);

            _supplierAl = tempAl;

        }

        /// <summary>
        ///�q�ɏ����擾
        /// </summary>
        /// <remarks>
        /// <br>Note       :�@�q�ɏ����擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetWareHouseInfo()
        {
            ArrayList tempAl = new ArrayList();

            this._warehouseAcs.SearchAll(out tempAl, _enterpriseCode);

            _warehouseAl = tempAl;

        }

        /// <summary>
        ///���[�J�[�����擾
        /// </summary>
        /// <remarks>
        /// <br>Note       :�@���[�J�[�����擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetMakerInfo()
        {
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();
            }
            ArrayList tempAl = new ArrayList();
            this._makerAcs.SearchAll(out tempAl, _enterpriseCode);
            _MakerAl = tempAl;
        }

        /// <summary>
        ///�݌ɑS�̐ݒ�����擾
        /// </summary>
        /// <remarks>
        /// <br>Note       :�@�݌ɑS�̐ݒ�����擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetStockMngTtl()
        {
            StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
            if(_stockMngTtlStAcs == null)
            {
                _stockMngTtlStAcs =new StockMngTtlStAcs();
            }
            if (_stockMngTtlSt == null)
            {
                _stockMngTtlSt = new StockMngTtlSt();
            }
             ArrayList tempAl = new ArrayList();
             this._stockMngTtlStAcs.SearchAll(out tempAl, _enterpriseCode);
             _stockMngTtlStAl = tempAl;
             foreach (StockMngTtlSt TempStockMngTtlSt in _stockMngTtlStAl)
             {
                 if ((TempStockMngTtlSt.LogicalDeleteCode == 0) && (TempStockMngTtlSt.SectionCode.Trim() == "00"))
                 {
                     _stockMngTtlSt = TempStockMngTtlSt;
                     break;
                 }
             }
        }

        /// <summary>
        /// �d���於�̂��擾
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �d���於�̂��擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string GetSupplierName(int supplierCode)
        {
           
            string resultName = string.Empty;
            bool flag = false;
            int logicalDel = 0;
            if (supplierCode != 0)
            {
                foreach (Supplier supplier in _supplierAl)
                {
                    if (supplier.SupplierCd == supplierCode)
                    {
                        resultName = supplier.SupplierSnm;
                        logicalDel = supplier.LogicalDeleteCode;
                        flag = true;
                        break;
                    }

                }
                //�L�����_���폜�̃f�[�^
                if (flag)
                {
                    if (logicalDel == 1)
                    {
                        resultName = "��" + resultName;
                    }
                }
                //���S�폜�̏ꍇ
                else
                {
                    resultName = "���o�^";
                }
            }

            return resultName;
        }

        /// <summary>
        /// �q�ɖ��̂��擾
        /// </summary>
        /// <param name="wareHouseCode">�d����R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̂��擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string GetWareHouseName(string wareHouseCode)
        {
            string resultName = string.Empty;
            bool flag = false;
            int logicalDel = 0;
            if (!string.IsNullOrEmpty(wareHouseCode))
            {
                foreach (Warehouse warehouse in _warehouseAl)
                {
                    if (warehouse.WarehouseCode.Trim().Equals(wareHouseCode.Trim()))
                    {
                        resultName = warehouse.WarehouseName;
                        logicalDel = warehouse.LogicalDeleteCode;
                        flag = true;
                        break;
                    }

                }
                //�L�����_���폜�̃f�[�^
                if (flag)
                {
                    if (logicalDel == 1)
                    {
                        resultName = "��" + resultName;
                    }
                }
                //���S�폜�̏ꍇ
                else
                {
                    resultName = "���o�^";
                }
            }

            return resultName;
 
        }

        /// <summary>
        /// ���[�J���̂��擾
        /// </summary>
        /// <param name="makerCode">�d����R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�J���̂��擾�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string resultName = string.Empty;
            bool flag = false;
            int logicalDel = 0;
            if (makerCode != 0)
            {
                foreach (MakerUMnt makerUMnt in _MakerAl)
                {
                    if (makerUMnt.GoodsMakerCd == makerCode)
                    {
                        resultName = makerUMnt.MakerName;
                        logicalDel = makerUMnt.LogicalDeleteCode;
                        flag = true;
                        break;
                    }

                }
                //�L�����_���폜�̃f�[�^
                if (flag)
                {
                    if (logicalDel == 1)
                    {
                        resultName = "��" + resultName;
                    }
                }
                //���S�폜�̏ꍇ
                else
                {
                    resultName = "���o�^";
                }
            }

            return resultName;

        }

        /// <summary>
        /// CSV�o�͏�񏈗�
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <param name="dt">�f�[�^</param>
        /// <param name="outPutFileName">�o�̓p�[�X</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private int GetCSVInfo(ref object parameter, DataTable dt, string outPutFileName)
        {
            List<string> schemeList = new List<string>();

            //�q�ɃR�[�h  
            schemeList.Add(ct_Col_WarehouseCode);
            //�q�ɖ�
            schemeList.Add(ct_Col_WarehouseName);
            //�I�� 
            schemeList.Add(ct_Col_WarehouseShelfNo);
            //�i��
            schemeList.Add(ct_Col_GoodsNo);
            //�i��
            schemeList.Add(ct_Col_GoodsName);
            //�d����R�[�h 
            schemeList.Add(ct_Col_SupplierCd);
            //�d���於 
            schemeList.Add(ct_Col_SupplierName);
            //BL�R�[�h 
            schemeList.Add(ct_Col_BLGoodsCode);
            //���[�J�[�R�[�h 
            schemeList.Add(ct_Col_GoodsMakerCd);
            //���[�J�[�� 
            schemeList.Add(ct_Col_MakerName);
            //�I���� 
            schemeList.Add(ct_Col_StockCount);
            //�W�����i 
            schemeList.Add(ct_Col_ListPrice);
            //�݌ɒP�� 
            schemeList.Add(ct_Col_StockUnitPriceFl);
            //�I�����z
            schemeList.Add(ct_Col_StockAmountPrice);
            //�I���A��
            schemeList.Add(ct_Col_InventorySeqNo);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());
            enclosingTypeList.Add(typeof(System.Int32));
            enclosingTypeList.Add(typeof(System.Int64));
            enclosingTypeList.Add(typeof(System.Double));
            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();

            maxLengthList.Add(ct_Col_WarehouseCode, 4);
            maxLengthList.Add(ct_Col_WarehouseName, 40);
            maxLengthList.Add(ct_Col_WarehouseShelfNo, 8);
            maxLengthList.Add(ct_Col_GoodsNo, 24);
            maxLengthList.Add(ct_Col_GoodsName, 40);
            maxLengthList.Add(ct_Col_SupplierCd, 6);
            maxLengthList.Add(ct_Col_SupplierName, 20);
            maxLengthList.Add(ct_Col_BLGoodsCode, 5);
            maxLengthList.Add(ct_Col_GoodsMakerCd, 4);
            maxLengthList.Add(ct_Col_MakerName, 30);
            maxLengthList.Add(ct_Col_StockCount, 7);
            maxLengthList.Add(ct_Col_ListPrice, 7);
            maxLengthList.Add(ct_Col_StockUnitPriceFl, 10);
            maxLengthList.Add(ct_Col_StockAmountPrice, 9);
            maxLengthList.Add(ct_Col_InventorySeqNo, 9);

            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;
            formattedTextWriter.DataSource = dt;
            formattedTextWriter.DataMember = String.Empty;
            //�e�L�X�g�t�@�C���o�̓p�X�̎擾
            formattedTextWriter.OutputFileName = outPutFileName;
            //�e�L�X�g�o�͂��鍀�ږ��̃��X�g
            formattedTextWriter.SchemeList = schemeList;
            formattedTextWriter.Splitter = ",";
            formattedTextWriter.Encloser = "\"";
            formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            Dictionary<string, string> formatDic= new Dictionary<string, string>();
            //�q�ɃR�[�h  
            formatDic.Add(ct_Col_WarehouseCode,string.Empty);
            //�q�ɖ�
            formatDic.Add(ct_Col_WarehouseName, string.Empty);
            //�I�� 
            formatDic.Add(ct_Col_WarehouseShelfNo, string.Empty);
            //�i��
            formatDic.Add(ct_Col_GoodsNo, string.Empty);
            //�i��
            formatDic.Add(ct_Col_GoodsName, string.Empty);
            //�d����R�[�h 
            formatDic.Add(ct_Col_SupplierCd, string.Empty);
            //�d���於 
            formatDic.Add(ct_Col_SupplierName, string.Empty);
            //BL�R�[�h 
            formatDic.Add(ct_Col_BLGoodsCode, string.Empty);
            //���[�J�[�R�[�h 
            formatDic.Add(ct_Col_GoodsMakerCd, string.Empty);
            //���[�J�[�� 
            formatDic.Add(ct_Col_MakerName, string.Empty);
            //�I���� 
            formatDic.Add(ct_Col_StockCount, string.Empty);
            //�W�����i 
            formatDic.Add(ct_Col_ListPrice, string.Empty);
            //�݌ɒP�� 
            formatDic.Add(ct_Col_StockUnitPriceFl, "0.00");
            //�I�����z
            formatDic.Add(ct_Col_StockAmountPrice, string.Empty);
            //�I���A��
            formatDic.Add(ct_Col_InventorySeqNo, string.Empty);
            formattedTextWriter.FormatList = formatDic;
            formattedTextWriter.CaptionOutput = false;
            formattedTextWriter.FixedLength = true;
            formattedTextWriter.ReplaceList = null;
            formattedTextWriter.MaxLengthList = maxLengthList;

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="parameter">�o��Info</param>
        /// <param name="iLevel"></param>
        /// <param name="resultMessage"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private int DoOutPut(ref object parameter, ref string resultMessage, ref emErrorLevel iLevel)
        {
            int status = 0;
            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;

            try
            {
                int totalCount;
                status = formattedTextWriter.SietuTextOut(out totalCount);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    return status;
                }
            }
            catch
            {
                status = -1;
            }
            switch (status)
            {
                case 0:    // ��������
                    _textOutDialog.WriteMemInput();
                    resultMessage = "���o�������I�����܂����B";
                    iLevel = emErrorLevel.ERR_LEVEL_INFO;
                    break;
                case 1:    // �Ώۃf�[�^�Ȃ�
                    resultMessage = "�o�͏����𒆒f���܂����B";
                    iLevel = emErrorLevel.ERR_LEVEL_INFO;
                    break;
                default:    // ���̑��G���[
                    resultMessage = "�e�L�X�g�t�@�C���̏������݂Ɏ��s���܂����B";
                    iLevel = emErrorLevel.ERR_LEVEL_STOP;
                    break;
            }

            return status;
        }

        /// <summary>
        /// �\�[�g������쐬����
        /// </summary>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note	   : �\�[�g������쐬�����B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string MakeSortingOrderString(InventSearchCndtnUI searchCndtn)
        {
            string sortStr = "";
            switch (searchCndtn.SortDiv)
            {

                case 0:             // �I�ԏ�
                    {

                        break;
                    }
                case 1:             // �d���揇
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�d����
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 2:             // �a�k�R�[�h��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�a�k�R�[�h
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGoodsCode, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 3:             // �O���[�v�R�[�h��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�O���[�v�R�[�h
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGroupCode, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 4:             // ���[�J�[��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
                case 5:             // �d����E�I�ԏ�
                    {

                        break;
                    }
                case 6:             // �d����E���[�J�[��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�d����
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
            }

            return sortStr;
        }

        /// <summary>
        /// �\�[�g�p������쐬����
        /// </summary>
        /// <param name="colName">�񖼏�</param>
        /// <param name="ascDescDiv">�����E�~���敪[0:����, 1:�~��]</param>
        /// <param name="strQuery">�\�[�g�p������</param>
        /// <remarks>
        /// <br>Note	   : �\�[�g�p������쐬�����B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
        {
            if (strQuery == null)
            {
                strQuery = "";
            }

            if (strQuery == "")
            {
                strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
            else
            {
                strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
        }

        #endregion

        #region IPrintConditionInpTypeTextOutControl �����o
        /// <summary>
        /// �e�L�X�g�o�̓{�^���̐���
        /// </summary>
        public event TextOutControl TextOutControlCall;

        #endregion

        // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

        // ------------------------------
        // IPrintConditionInpTypeSelectedSection�̃v���p�e�B
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��
        /// </summary>
        /// <param name="addUpCd">�I�����_���</param>
        /// <remarks>
        /// <br>Note       : �I������Ă���v�㋒�_��ݒ肵�܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // ���g�p
        }

        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_</param>
        /// <param name="checkState"></param>
        /// <remarks>
        /// <br>Note       : ���_�I���������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, System.Windows.Forms.CheckState checkState)
        {
           //������
        }       

        /// <summary>
        /// �v�㋒�_�I������
        /// </summary>
        /// <param name="addUpCd">�I�����_���</param>
        /// <remarks>
        /// <br>Note       : �v�㋒�_�I������</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // ���g�p
        }

        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �I������Ă��鋒�_��ݒ肵�܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            if (sectionCodeLst.Length == 0)
            {
                return;
            }        
        }

        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">�����\���L���X�e�[�^�X</param>
        /// <returns>�ύX��\���L���X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�I���X���C�_�[�̕\���L���𔻒肵�܂��B</br>
        /// <br>           : ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            //���_�I���X���C�_�[���\���ɂ���
            return false;
        }
        #endregion

        #region Private Methods

        #region ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏������������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2009/12/04 ������</br>
        /// <br>             �I�����̎擾�s���Ή�</br>
        /// <br>Update Note: 2011/01/11 liyp</br>
        /// <br>             �o�͏����ɐ��ʂƒI�ԂɊւ�������w���ǉ�����i�v�]�j</br>
        /// <br>Update Note: 2011/01/11 �c����</br>
        /// <br>			 �I����Q�Ή�</br> 
        /// <br>Update Note: 2012/11/14 ������</br>
        ///	<br>			 Redmine#33271 �󎚐���̋敪�̒ǉ�</br>
        /// <br>Update Note : 2012/12/25 ���j��</br>
        ///	<br>			  Redmine#33271 ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵�����̂��L�������邱�Ƃ̐ݒ��ǉ�����</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
           
            // 2008.10.07 30413 ���� �����ʂ̉�ʏ�����������ύX >>>>>>START
            //���[�̎�ނɂ�菈���𕪂���
            switch(this._selPrintMode)
            {
                case 0:
                {
                    //�I�������\�H
                    //this.Condition_panel1.Visible = true;
                    //this.Condition_panel2.Visible = false;
                    //// 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel3.Visible = true;
                    //this.Condition_panel3.Visible = false;
                    //// 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    //this.Condition_panel4.Visible = false;
                    //this.Condition_panel5.Visible = true;                  
                    ////this.Condition_panel6.Visible = true;
                    //// 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel7.Visible = true;
                    //this.Condition_panel6.Visible = true;
                    //// 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    
                    // �o�͏��� �\���ݒ�
                    this.Condition_panel1.Visible = true;
                    this.Condition_panel2.Visible = true;
                    this.Condition_panel3.Visible = true;
                    this.Condition_panel4.Visible = false;
                    //this.Condition_panel5.Visible = false;// DEL 2010/02/20
                    this.Condition_panel6.Visible = true;
                    this.Condition_panel8.Visible = false;
                    this.Condition_panel7.Visible = false;
                    // -----------ADD 2010/02/20---------->>>>>
                    this.Condition_panel5.Visible = true;
                    this.CustomerPrintDiv_Title.Visible = true;
                    this.tComboEditor_SubtotalPrint.Visible = false;
                    // �v��(�����\)
                    this.CustomerPrintDivTemp_Title.Visible = true;
                    this.tComboEditor_SubtotalPrintTemp.Visible = true;
                    // -----------ADD 2010/02/20----------<<<<<
                  
                    //this.ZeroExtraDiv_Title.Text = CTOUTPUTPATERN01;
                    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this.Date_Title.Text = CTDATENAMEPATERN01;
                    //this.Date_Title.Text = CTDATENAMEPATERN02;
                    // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;

                    // �o�͏����̍�������
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;// DEL 2010/02/20
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 145;// ADD 2010/02/20 //DEL 2012/11/14 ������ for Redmine#33271
                    this.Main_UltraExplorerBar.Groups[0].Container.Height = 174;//ADD 2012/11/14 ������ for Redmine#33271
                    // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    //�R���{�{�b�N�X�Ƀ\�[�g�����Z�b�g
                    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods));
                    //// 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv));
                    //// 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker));
                    // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.SequenceNumber,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.SequenceNumber));
   
                    //this.ChangePageDiv_tComboEditor.MaxDropDownItems = this.ChangePageDiv_tComboEditor.Items.Count;
                    
                   

                    break;
                }
                case 1:
                {
                    //�I�����ٕ\
                    ////2007/04/24
                    ////���됔�O�o�͂���ʂ�������B
                    ////����ɂ�蒠�됔�O�̕��͏�ɏo�͂����
                    //this.Condition_panel1.Visible = true;
                    //this.Condition_panel2.Visible = true;
                    //// 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel3.Visible = true;
                    //this.Condition_panel3.Visible = false;
                    //// 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    //this.Condition_panel4.Visible = false;
                    //this.Condition_panel5.Visible = true;                  
                    ////this.Condition_panel6.Visible = false;
                    //// 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel7.Visible = false;
                    //this.Condition_panel6.Visible = true;
                    //// 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

                    // �o�͏��� �\���ݒ�
                    this.Condition_panel1.Visible = true;
                    this.Condition_panel2.Visible = false;
                    this.Condition_panel3.Visible = true;
                    this.Condition_panel4.Visible = false;
                    this.Condition_panel5.Visible = true;
                    this.Condition_panel6.Visible = true;
                    this.Condition_panel7.Visible = false;
                    this.Condition_panel8.Visible = false;

                    //this.ZeroExtraDiv_Title.Text = CTOUTPUTPATERN01;
                    //this.Date_Title.Text = CTDATENAMEPATERN02;
                    //�R���e�i�̕��𒲐�
                    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;

                    // �o�͏����̍�������
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;//DEL 2012/11/14 ������ for Redmine#33271
                    this.Main_UltraExplorerBar.Groups[0].Container.Height = 145;//ADD 2012/11/14 ������ for Redmine#33271
                    // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    //�R���{�{�b�N�X�Ƀ\�[�g�����Z�b�g
                    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods));
                    //// 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv));
                    //// 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker));
                    //// 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    ////this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.SequenceNumber,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.SequenceNumber));   

                    //this.ChangePageDiv_tComboEditor.MaxDropDownItems = this.ChangePageDiv_tComboEditor.Items.Count;

                    // ----- UPD 2011/01/11 ------------------------------------->>>>>
                    //// ���o���� �\���ݒ�
                    //this.uLabel_LendExtraDiv.Visible = false;
                    //this.tComboEditor_LendExtraDiv.Visible = false;
                    //this.uLabel_DelayPaymentDiv.Visible = false;
                    //this.tComboEditor_DelayPaymentDiv.Visible = false;
                    ////���o�����̍�������
                    //this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height - 58;

                    // ���o���� �\���ݒ�
                    this.uLabel_LendExtraDiv.Visible = true;
                    this.tComboEditor_LendExtraDiv.Visible = true;
                    this.uLabel_DelayPaymentDiv.Visible = true;
                    this.tComboEditor_DelayPaymentDiv.Visible = true;
                    // ----- UPD 2011/01/11 -------------------------------------<<<<<

                    break;
                }
                case 2:
                {
                    //�I���\
                    //this.Condition_panel1.Visible = true;
                    //this.Condition_panel2.Visible = false;
                    //this.Condition_panel3.Visible = true;
                    //this.Condition_panel4.Visible = true;
                    //this.Condition_panel5.Visible = true;                  
                    ////this.Condition_panel6.Visible = false;
                    //// 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel7.Visible = false;
                    //this.Condition_panel6.Visible = true;
                    //// 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

                    // �o�͏��� �\���ݒ�
                    this.Condition_panel1.Visible = true;
                    this.Condition_panel2.Visible = false;
                    this.Condition_panel3.Visible = true;
                    this.Condition_panel4.Visible = true;
                    this.Condition_panel5.Visible = true;
                    this.Condition_panel6.Visible = true;
                    this.Condition_panel7.Visible = true;
                    this.Condition_panel8.Visible = true;


                    //this.ZeroExtraDiv_Title.Text = CTOUTPUTPATERN02;
                    //this.Date_Title.Text = CTDATENAMEPATERN02;
                    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;

                    // �o�͏����̍�������
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 145;//DEL 2011/01/11
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 202;//ADD 2011/01/11 //DEL 2012/11/14 ������ for Redmine#33271
                    this.Main_UltraExplorerBar.Groups[0].Container.Height = 231;//ADD 2012/11/14 ������ for Redmine#33271
                    // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    //�R���{�{�b�N�X�Ƀ\�[�g�����Z�b�g
                    //�ʔԂ��܂܂Ȃ�
                    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods));
                    //// 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv));
                    //// 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker));
                    // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                 
                    //this.ChangePageDiv_tComboEditor.MaxDropDownItems = this.ChangePageDiv_tComboEditor.Items.Count;

                    // ���o���� �\���ݒ�
                    //----------------DEL 2011/01/11--------------->>>>>
                    //this.uLabel_LendExtraDiv.Visible = false;
                    //this.tComboEditor_LendExtraDiv.Visible = false;
                    //this.uLabel_DelayPaymentDiv.Visible = false;
                    //this.tComboEditor_DelayPaymentDiv.Visible = false;
                    //----------------DEL 2011/01/11---------------<<<<<
                    //���o�����̍�������
                    //this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height - 58;
                    this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height;

                    break;
                }
            }
            
            // �o�͏����̏����l�ݒ�
            // �o�͎w��
            this.tComboEditor_OutputAppointDiv.Value = 0;
            // �݌ɋ敪
            this.tComboEditor_StockDiv.Value = 1;
            // �I�������͋敪
            this.tComboEditor_InventoryNonInputDiv.Value = 0;//ADD 2011/01/11
            
            //�I�ԏo�͋敪
            this.tComboEditor_WarehouseShelfOutputDiv.Value = 0;
            // ���v��
            this.tComboEditor_SubtotalPrint.Value = 0;
            // -----------ADD 2010/02/20----------->>>>>
            // �v��
            this.tComboEditor_SubtotalPrintTemp.Value = 0;
            // -----------ADD 2010/02/20-----------<<<<<
            // ���y�[�W
            this.tComboEditor_NewPageDiv.Value = 0;
            // --- ADD ������ 2012/11/14 for Redmine#33271---------->>>>>
            //�r���󎚋敪
            this.tComboEditor_LineMaSqOfChDiv.Value = 0;
            // --- ADD ������ 2012/11/14 for Redmine#33271----------<<<<<

            // 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            ////���o��ʂ̍�������
            //this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height - 29;
            //�I�ԃu���C�N�敪���f�t�H���g�őI��
            this.ShelfNoBreakDiv_tComboEditor.SelectedIndex = 0;
            // 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // ���o�����̏����l�ݒ�
            // �ݏo��
            this.tComboEditor_LendExtraDiv.Value = 0;
            // �����v�㕪
            this.tComboEditor_DelayPaymentDiv.Value = 0;
            //----------------ADD 2011/01/11--------------->>>>>
            if ((int)this.tComboEditor_InventoryNonInputDiv.Value == 0)
            {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "�S�ďo��");
                tComboEditor_NumOutputDiv.Items.Add(1, "�I�����P�ȏ�o��");
                tComboEditor_NumOutputDiv.Items.Add(2, "�I�����O�ȉ��o��");
                tComboEditor_NumOutputDiv.Items.Add(3, "�I�����O�̂ݏo��");
            }
            else {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "�S�ďo��");
                tComboEditor_NumOutputDiv.Items.Add(4, "�����͂̂ݏo��");
                tComboEditor_NumOutputDiv.Items.Add(5, "�����͈ȊO�o��");
            }
            //���ʏo�͋敪
            this.tComboEditor_NumOutputDiv.Value = 0;
            //----------------ADD 2011/01/11---------------<<<<<

            //---ADD ���j�� 2012/12/25 for Redmine#33271 ---->>>>>>>>>
            tComboEditor_LineMaSqOfChDiv0.Value = 0;
            tComboEditor_LineMaSqOfChDiv1.Value = 0;
            tComboEditor_LineMaSqOfChDiv2.Value = 0;
            //---ADD ���j�� 2012/12/25 for Redmine#33271 ----<<<<<<<<<

            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            //�I���Ώ۔N�����ɃV�X�e�����t���Z�b�g
            //this.EndDate_tDateEdit.SetDateTime(TDateTime.GetSFDateNow());

            // 2008.12.10 30413 ���� �I�����������������{�̏ꍇ�͋󔒂Ƃ��� >>>>>>START
            //// 2008.12.02 30413 ���� �����l�ɃV�X�e�����t���Z�b�g >>>>>>START
            //// �����l�Ƃ��ăV�X�e�����t���Z�b�g
            //this.StartDate_tDateEdit.SetDateTime(DateTime.Now);
            //// 2008.12.02 30413 ���� �����l�ɃV�X�e�����t���Z�b�g <<<<<<END
            // 2008.12.10 30413 ���� �I�����������������{�̏ꍇ�͋󔒂Ƃ��� <<<<<<END
            
            //�Ώ۔N�����ɍŏI�I�������������t���Z�b�g
            //�����f�[�^�擾
            //--------- UPD 2009/12/04 --------->>>>>
            DataSet prtIvntHisDataSet;
            DataView dv = new DataView();
            DataView dataView = new DataView();
            this._inventoryPrepareAcs.Read(out prtIvntHisDataSet);
            dv.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            dataView.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            // ���O�C�����_
            dv.RowFilter = String.Format("{0}={1}", InventoryPrepareAcs.ctSectionCode, this._sectionCode);
            // �\�[�g���F�X�V���t
            dv.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";
            // ���O�C�����_�ɊY������f�[�^�L��F���O�C�����_�ɊY������ŐV�f�[�^����I�������擾
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    // �폜���������f�[�^�͑ΏۊO
                    if ((int)drv[InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((drv[InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)drv[InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.StartDate_tDateEdit.SetLongDate((int)drv[InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // ���O�C�����_�ɊY������f�[�^�����F���_�Ɋ֌W�Ȃ��ŐV�f�[�^����I�������擾
            else
            {
                // �\�[�g���F�X�V���t
                dataView.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";

                // �I����
                foreach (DataRowView drv in dataView)
                {
                    // �폜���������f�[�^�͑ΏۊO
                    if ((int)drv[InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((drv[InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)drv[InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.StartDate_tDateEdit.SetLongDate((int)drv[InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // �\�[�g���ݒ�
            //dv.Sort = InventoryPrepareAcs.ctInventoryDate_Int + "," + InventoryPrepareAcs.ctInventoryPreprDate_Int + " DESC," + InventoryPrepareAcs.ctInventoryPreprTime_Int + " DESC";
            //for (int ix = 0; ix < dv.Count; ix++)
            //{
            //    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
            //    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
            //        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
            //    {
            //        this.StartDate_tDateEdit.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
            //        break;
            //    }
            //}
            //--------- UPD 2009/12/04 ---------<<<<<
            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<

            ////�q��-���i���f�t�H���g�őI��
            //this.ChangePageDiv_tComboEditor.SelectedIndex = 0;
            // �݌ɊǗ��S�̐ݒ�}�X�^����I������������ݒ�敪���擾
            int invntryPrtOdrIniDiv = 0;
            ArrayList retList = new ArrayList();
            int status = this._stockMngTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (StockMngTtlSt stockMngTtlStl in retList)
                {
                    if (this._sectionCode.TrimEnd() == stockMngTtlStl.SectionCode.TrimEnd())
                    {
                        // �����_�̃f�[�^������
                        invntryPrtOdrIniDiv = stockMngTtlStl.InvntryPrtOdrIniDiv;
                        break;
                    }

                    if (stockMngTtlStl.SectionCode.TrimEnd() == "00")
                    {
                        // �S�Аݒ�͎擾�����s��
                        invntryPrtOdrIniDiv = stockMngTtlStl.InvntryPrtOdrIniDiv;
                    }
                }                
            }
            // �o�͏���ݒ�
            this.ChangePageDiv_tComboEditor.Value = invntryPrtOdrIniDiv;

            // 2008.10.07 30413 ���� �����ʂ̉�ʏ�����������ύX <<<<<<END            
        }
        #endregion

        #region ���o�����i�[����
        /// <summary>
        /// ���o����UI�N���X�f�[�^�i�[����(��ʏ��˒��o����UI�N���X)
        /// </summary>
        /// <param name="extraInfo">���o����UI�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���o�����ڍ׏�����ʂ���擾���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2011/01/11 liyp</br>
        /// <br>            �o�͏����ɐ��ʂƒI�ԂɊւ�������w���ǉ�����i�v�]�j</br>
        /// </remarks>
        private int SetExtrInfoFromScreen(ref InventSearchCndtnUI extraInfo)
        {
            const string ctPROCNM = "SetExtrInfoFromScreen";
            int status = 0;

            if (extraInfo == null)
            {
                extraInfo = new InventSearchCndtnUI();
            }

            try
            {
                // 2008.10.07 30413 ���� ��ʏ��ƒ��o�����ݒ��ύX >>>>>>START
                // 2007.09.05 �폜 >>>>>>>>>>>>>>>>>>>>
                ////���_�I�v�V�����L��
                //extraInfo.IsOptSection = this._isOptSection;
                // 2007.09.05 �폜 <<<<<<<<<<<<<<<<<<<<
                //��ƃR�[�h
                extraInfo.EnterpriseCode = this._enterpriseCode;
                //���_�R�[�h(�����_)
                extraInfo.SectionCode = this._sectionCode;
                ////��ʏ�񁨏����N���X                                 
                // 2007.09.05 �폜 >>>>>>>>>>>>>>>>>>>>
                ////�W�v�P�ʋ敪             
                //extraInfo.GrossPrintDiv = this.GrossPrintDiv_ultraOptionSet.CheckedIndex;                        
                // 2007.09.05 �폜 <<<<<<<<<<<<<<<<<<<<
                // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                ////�݌ɒ��o�敪
                ////���Ѝ݌�
                //if(this.CmpStockDiv_CheckEditor.Checked)
                //{
                //    //���o����
                //    extraInfo.CompanyStockExtraDiv = 0;
                //}
                //else
                //{
                //    //���o���Ȃ�
                //    extraInfo.CompanyStockExtraDiv = 1;
                //}
                ////����݌�
                //if(this.TrsStockDiv_CheckEditor.Checked)
                //{
                //    //���o����
                //    extraInfo.TrustStockExtraDiv = 0;
                //}
                //else
                //{
                //    //���o���Ȃ�
                //    extraInfo.TrustStockExtraDiv = 1;
                //}
                ////�ϑ��݌�(����)
                //if(this.EntrustCmpStockDiv_CheckEditor.Checked)
                //{
                //    //���o����
                //    extraInfo.EntrustCmpStockExtraDiv = 0;
                //}
                //else
                //{
                //    //���o���Ȃ�
                //    extraInfo.EntrustCmpStockExtraDiv = 1;
                //}
                ////�ϑ��݌�(����)
                //if(this.EntrustTrsStockDiv_CheckEditor.Checked)
                //{
                //    //���o����
                //    extraInfo.EntrustTrtStockExtraDiv = 0;
                //}
                //else
                //{
                //    //���o���Ȃ�
                //    extraInfo.EntrustTrtStockExtraDiv = 1;
                //}
                // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<

                // 2008.10.31 30413 ���� 0�l�ߑΉ� >>>>>>START
                //�q�ɃR�[�h
                //extraInfo.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                //extraInfo.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;

                // �q�ɃR�[�h(�J�n)
                if (this.tEdit_WarehouseCode_St.Text.TrimEnd() == "")
                {
                    extraInfo.St_WarehouseCode = "";
                }
                else
                {
                    extraInfo.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text.TrimEnd().PadLeft(4, '0');
                }

                // �q�ɃR�[�h(�I��)
                if (this.tEdit_WarehouseCode_Ed.Text.TrimEnd() == "")
                {
                    extraInfo.Ed_WarehouseCode = "";
                }
                else
                {
                    extraInfo.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text.TrimEnd().PadLeft(4, '0');
                }
                // 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //�I��
                //extraInfo.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText;
                //extraInfo.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText;

                // �I��(�J�n)
                if (this.tEdit_WarehouseShelfNo_St.Text.TrimEnd() == "")
                {
                    extraInfo.St_WarehouseShelfNo = "";
                }
                else
                {
                    //extraInfo.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text.TrimEnd().PadLeft(8, '0');
                    extraInfo.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text.Trim();
                }

                // �I��(�I��)
                if (this.tEdit_WarehouseShelfNo_Ed.Text.TrimEnd() == "")
                {
                    extraInfo.Ed_WarehouseShelfNo = "";
                }
                else
                {
                    //extraInfo.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text.TrimEnd().PadLeft(8, '0');
                    extraInfo.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text.Trim();
                }
                // 2008.10.31 30413 ���� 0�l�ߑΉ� <<<<<<END
                
                // �d����
                extraInfo.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                extraInfo.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();

                //�a�k�R�[�h
                extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                
                // �O���[�v�R�[�h
                extraInfo.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                extraInfo.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();

                // 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
                //���[�J�[�R�[�h
                extraInfo.St_MakerCode = this.tNedit_GoodsMakerCd_St.GetInt();
                extraInfo.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // �o�͎w��敪
                extraInfo.OutputAppointDiv = (int)this.tComboEditor_OutputAppointDiv.Value;
                
                // �݌ɋ敪
                extraInfo.StockDiv = (int)this.tComboEditor_StockDiv.Value;

                // -----------ADD 2011/01/11----------------------------------->>>>>
                // ���ʏo�͋敪
                extraInfo.NumOutputDiv = (int)this.tComboEditor_NumOutputDiv.Value;

                // �I�ԏo�͋敪
                extraInfo.WarehouseShelfOutputDiv = (int)this.tComboEditor_WarehouseShelfOutputDiv.Value;

                // -----------ADD 2011/01/11-----------------------------------<<<<<

                // �I�������͋敪
                extraInfo.InventoryNonInputDiv = (int)this.tComboEditor_InventoryNonInputDiv.Value;

                // ���v�敪
                extraInfo.SubtotalPrintDiv = (int)this.tComboEditor_SubtotalPrint.Value;

                // -------------ADD 2010/02/20--------------->>>>>
                // �v��(�I�������\�p)
                extraInfo.SubtotalPrintDivTemp = (int)this.tComboEditor_SubtotalPrintTemp.Value;
                // -------------ADD 2010/02/20---------------<<<<<

                //���y�[�W�w��敪
                extraInfo.TurnOoverThePagesDiv = (int)this.tComboEditor_NewPageDiv.Value;
                
                // �ݏo���o�敪
                extraInfo.LendExtraDiv = (int)this.tComboEditor_LendExtraDiv.Value;

                // �����v�㒊�o�敪
                extraInfo.DelayPaymentDiv = (int)this.tComboEditor_DelayPaymentDiv.Value;

                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_MakerCode = this.EndMakerCode_tNedit.GetInt();
                //if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
                //{
                //    extraInfo.Ed_MakerCode = 999999;
                //}
                //else
                //{
                //    extraInfo.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();
                //}
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                ////���i�R�[�h
                //extraInfo.St_GoodsNo = this.StartGoodsCode_tEdit.DataText;
                //extraInfo.Ed_GoodsNo = this.EndGoodsCode_tEdit.DataText;
                       
                ////���i�敪�O���[�v�R�[�h
                //extraInfo.St_LargeGoodsGanreCode = this.StartLargeGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_LargeGoodsGanreCode = this.EndLargeGoodsGanreCode_tEdit.DataText;
                ////���i�敪�R�[�h
                //extraInfo.St_MediumGoodsGanreCode = this.StartMediumGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_MediumGoodsGanreCode = this.EndMediumGoodsGanreCode_tEdit.DataText;
                ////���i�敪�ڍ׃R�[�h
                //extraInfo.St_DetailGoodsGanreCode = this.StartDetailGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_DetailGoodsGanreCode = this.EndDetailGoodsGanreCode_tEdit.DataText;
                ////���Е��ރR�[�h
                //extraInfo.St_EnterpriseGanreCode = this.StartEnterpriseGanreCode_tNedit.GetInt();
                //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_EnterpriseGanreCode = this.EndCmpClassificationCode_tNedit.GetInt();
                //if (this.EndEnterpriseGanreCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = 9999;
                //}
                //else
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
                //}
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                ////�a�k�R�[�h
                //extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                //extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_BLGoodsCode = this.EndBLGoodsCode_tNedit.GetInt();
                //if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                //{
                //    extraInfo.Ed_BLGoodsCode = 99999999;
                //}
                //else
                //{
                //    extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                //}
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<

                //�\�[�g�敪
                extraInfo.SortDiv = (int)this.ChangePageDiv_tComboEditor.Value;
               
                ////���Ӑ�R�[�h(�d����)
                //extraInfo.St_CustomerCode = this.StartCustomerCode_tNedit.GetInt();
                //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_CustomerCode = this.EndCustomerCode_tNedit.GetInt();
                //if (this.EndCustomerCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_CustomerCode = 999999999;
                //}
                //else
                //{
                //    extraInfo.Ed_CustomerCode = this.EndCustomerCode_tNedit.GetInt();
                //}
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                ////�o�א擾�Ӑ�R�[�h(�ϑ���)
                //extraInfo.St_ShipCustomerCode = this.StartShipCustomerCode_tNedit.GetInt();
                //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_ShipCustomerCode = this.EndShipCustomerCode_tNedit.GetInt();
                //if (this.EndShipCustomerCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_ShipCustomerCode = 999999999;
                //}
                //else
                //{
                //    extraInfo.Ed_ShipCustomerCode = this.EndShipCustomerCode_tNedit.GetInt();
                //}
                //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                ////���Ӑ�󎚋敪(0:�d����,1:�ϑ���)
                //extraInfo.CustomerPrintDiv = this.CustomerPrintDiv_ultraOptionSet.CheckedIndex;

                //// 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                ////�I�������͋敪
                //extraInfo.InventoryInputDiv = this.InventoryInputDiv_ultraOptionSet.CheckedIndex;
                ////�o�͎w��敪
                //extraInfo.OutputAppointDiv = this.OutputAppointDiv_ultraOptionSet.CheckedIndex;
                ////���y�[�W�w��敪
                //extraInfo.TurnOoverThePagesDiv = this.TurnOoverThePagesDiv_ultraOptionSet.CheckedIndex;
                //�I�ԃu���C�N�敪
                extraInfo.ShelfNoBreakDiv = this.ShelfNoBreakDiv_tComboEditor.SelectedIndex;
                // 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // --- ADD ������ 2012/11/14 for Redmine#33271---------->>>>>
                //�r���󎚋敪
                extraInfo.LineMaSqOfChDiv = (int)this.tComboEditor_LineMaSqOfChDiv.Value;
                // --- ADD ������ 2012/11/14 for Redmine#33271----------<<<<<

                //TODO:���̂Ƃ��떢�g�p
                //�ʔ�
                extraInfo.St_InventorySeqNo = 0;
                extraInfo.Ed_InventorySeqNo = 999999;
    
                //�N�����Ă��钠�[�ɂ���ĕω��������
                switch(this._selPrintMode)
                {
                    case 0:
                    {
                        #region �I�������\�̏ꍇ
                       
                        //�I������������
                        extraInfo.St_InventoryPreprDayDateTime = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryPreprDayDateTime = this.EndDate_tDateEdit.GetDateTime();
                        // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<
                        extraInfo.St_InventoryPreprDay = this.StartDate_tDateEdit.GetLongDate();
                        // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryPreprDay = this.EndDate_tDateEdit.GetLongDate();
                        // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<
                        //�I�����{���ɂ�MinValu���Z�b�g
                        extraInfo.St_InventoryDayDateTime = DateTime.MinValue;
                        extraInfo.Ed_InventoryDayDateTime = DateTime.MinValue;

                        // 2008.12.10 30413 ���� �I�����̐ݒ� >>>>>>START
                        // �I����
                        extraInfo.InventoryDate = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.12.10 30413 ���� �I�����̐ݒ� <<<<<<END
                        
                        //���ٕ����o�敪(�S��)
                        extraInfo.DifCntExtraDiv = 0;

                        ////�݌ɐ��O��
                        //switch (this.ZeroExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //���o����
                        //        extraInfo.StockCntZeroExtraDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //���o���Ȃ�
                        //        extraInfo.StockCntZeroExtraDiv = 1;
                        //        break;
                        //    }
                        //}

                        //////���됔��(����)
                        //switch (this.StockCntPrintDiv_UOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //�󎚂���
                        //        extraInfo.StockCntPrintDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //�󎚂��Ȃ�
                        //        extraInfo.StockCntPrintDiv = 1;
                        //        break;
                        //    }
                        //}

                        ////�I�����O��(���o����)
                        extraInfo.IvtStkCntZeroExtraDiv = 0;
                        //���[���
                        // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.SelctedPaperKindDiv = 0;
                        extraInfo.SelectedPaperKind = 0;    // 0:�I�������\
                        // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //���o�Ώۓ��t�敪 0:�I������������,1:�I�����{��,2:�I���X�V��
                        extraInfo.TargetDateExtraDiv = 0;

                        break;
                         
                        #endregion
                    }
                    case 1:
                    {
                        #region �I�����ٕ\�̏ꍇ
                       
                        //�I�������������ɂ�MinValu���Z�b�g
                        extraInfo.St_InventoryPreprDayDateTime = DateTime.MinValue;
                        extraInfo.Ed_InventoryPreprDayDateTime = DateTime.MinValue;
                        //�I�����{��
                        extraInfo.St_InventoryDayDateTime = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDayDateTime = this.EndDate_tDateEdit.GetDateTime();
                        // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<
                        extraInfo.St_InventoryDay = this.StartDate_tDateEdit.GetLongDate();
                        // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDay = this.EndDate_tDateEdit.GetLongDate();
                        // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 ���� �I�����̐ݒ� >>>>>>START
                        // �I����
                        extraInfo.InventoryDate = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.12.10 30413 ���� �I�����̐ݒ� <<<<<<END

                        ////���ٕ����o�敪
                        //switch (this.DifCntExtraDiv_OptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //�S��
                        //        extraInfo.DifCntExtraDiv = 0;
                        //        break;
                        //    }
                        //    // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //    //case 1:
                        //    //{
                        //    //    //���ٕ��̂�
                        //    //    extraInfo.DifCntExtraDiv = 1;
                        //    //    break;
                        //    //}
                        //    case 1:
                        //    {
                        //        //�������͕��̂�
                        //        extraInfo.DifCntExtraDiv = 1;
                        //        break;
                        //    }
                        //    case 2:
                        //    {
                        //        //�����͕��̂�
                        //        extraInfo.DifCntExtraDiv = 2;
                        //        break;
                        //    }
                        //    case 3:
                        //    {
                        //        //���ٕ��̂�
                        //        extraInfo.DifCntExtraDiv = 3;
                        //        break;
                        //    }
                        //    // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //}

                        ////�݌ɐ��O��
                        //switch (this.ZeroExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //���o����
                        //        extraInfo.StockCntZeroExtraDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //���o���Ȃ�
                        //        extraInfo.StockCntZeroExtraDiv = 1;
                        //        break;
                        //    }
                        //}
                                                
                        //�I�����O��(���o����)
                        extraInfo.IvtStkCntZeroExtraDiv = 0;
                        //���[���
                        // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.SelctedPaperKindDiv = 1;
                        extraInfo.SelectedPaperKind = 1;        // 1:�I�����ٕ\
                        // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 ���� �I�����ٕ\��1:�I�����{���Ƃ��� >>>>>>START
                        //// 2008.12.05 30413 ���� �I�����ٕ\��0:�I�������������Ƃ��� >>>>>>START
                        ////���o�Ώۓ��t�敪 0:�I������������,1:�I�����{��,2:�I���X�V��
                        ////extraInfo.TargetDateExtraDiv = 1;

                        ////// 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
                        ////extraInfo.TargetDateExtraDiv = 1;
                        ////// 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<

                        //extraInfo.TargetDateExtraDiv = 0;
                        //// 2008.12.05 30413 ���� �I�����ٕ\��0:�I�������������Ƃ��� <<<<<<END
                        
                        extraInfo.TargetDateExtraDiv = 1;
                        // 2008.12.10 30413 ���� �I�����ٕ\��1:�I�����{���Ƃ��� <<<<<<END
                        
                        break;
                        #endregion
                    }
                    case 2:
                    {
                        #region �I���\�̏ꍇ 
                     
                        //�I�������������ɂ�MinValu���Z�b�g
                        extraInfo.St_InventoryPreprDayDateTime = DateTime.MinValue;
                        extraInfo.Ed_InventoryPreprDayDateTime = DateTime.MinValue;
                        //�I�����{��
                        extraInfo.St_InventoryDayDateTime = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDayDateTime = this.EndDate_tDateEdit.GetDateTime();
                        // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<
                        extraInfo.St_InventoryDay = this.StartDate_tDateEdit.GetLongDate();
                        // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDay = this.EndDate_tDateEdit.GetLongDate();
                        // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 ���� �I�����̐ݒ� >>>>>>START
                        // �I����
                        extraInfo.InventoryDate = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.12.10 30413 ���� �I�����̐ݒ� <<<<<<END

                        //���ٕ����o�敪(�S��)
                        extraInfo.DifCntExtraDiv = 0;

                        //�݌ɐ��O��
                        extraInfo.StockCntZeroExtraDiv = 0;
                                             
                        ////�I�����O��
                        //switch (this.ZeroExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //���o����
                        //        extraInfo.IvtStkCntZeroExtraDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //���o���Ȃ�
                        //        extraInfo.IvtStkCntZeroExtraDiv = 1;
                        //        break;
                        //    }
                        //}

                        //���[���
                        // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.SelctedPaperKindDiv = 2;
                        extraInfo.SelectedPaperKind = 2;        // 2:�I���\
                        // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 ���� �I���\��1:�I�����{���Ƃ��� >>>>>>START
                        //// 2008.12.05 30413 ���� �I���\��0:�I�������������Ƃ��� >>>>>>START
                        ////TODO:�I���X�V�̋@�\���ł��A�I���f�[�^�}�X�^�ɒI���X�V����������悤�ɂȂ�����
                        ////2:�I���X�V���������Ƃ��ăZ�b�g����B����܂ł�1���Z�b�g
                        ////UI���ŃR���{�{�b�N�X�őI���ł���悤�ɂȂ邩������Ȃ��̂ł��̎��͕ʓr�Ή����K�v
                        ////���o�Ώۓ��t�敪 0:�I������������,1:�I�����{��,2:�I���X�V��
                        ////extraInfo.TargetDateExtraDiv = 1;
                        ////extraInfo.TargetDateExtraDiv = 2;

                        //extraInfo.TargetDateExtraDiv = 0;
                        //// 2008.12.05 30413 ���� �I���\��0:�I�������������Ƃ��� >>>>>>START

                        extraInfo.TargetDateExtraDiv = 1;
                        // 2008.12.10 30413 ���� �I���\��1:�I�����{���Ƃ��� <<<<<<END
                        
                        break;
                        #endregion                
                    }                 
                }
                // 2008.10.07 30413 ���� ��ʏ��ƒ��o�����ݒ��ύX <<<<<<END
            }
            catch (Exception ex)
            {
                status = -1;
                MsgDispProc("���o�����̎擾�Ɏ��s���܂����B", status, ctPROCNM, ex);
            }

            return status;
        }
    
        #endregion

        #region �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                CT_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                CT_PGNM,							// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.03.24</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                CT_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                CT_PGNM,							// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion       

        #region ��ʓ��̓`�F�b�N
        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�ΏۃR���g���[��</param>
        /// <returns>�`�F�b�N����(true/false)</returns>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���A�G���[���̓��b�Z�[�W�ƑΏۂ̃R���g���[����Ԃ��܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool result = false;

            // 2008.10.07 30413 ���� ��ʓ��̓`�F�b�N��ύX >>>>>>START
            //�o�͒��[�N���̃`�F�b�N1
            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            //result = DateCheck(this.StartDate_tDateEdit, this.EndDate_tDateEdit, ref errMessage, ref errComponent);
            result = DateCheck(this.StartDate_tDateEdit, ref errMessage, ref errComponent);
            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            if (!result)
            {
                return result;
            }

            //�q��
            if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseCode_St.DataText.Trim().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.Trim()) > 0)
                {         
                    //errMessage = "�q�ɃR�[�h�͈͎̔w��Ɍ�肪����܂��B";
                    errMessage = "�q�ɂ͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tEdit_WarehouseCode_St;
                    result = false;
                    return result;
                }
            }

            // 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //�I��
            if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseShelfNo_St.DataText.Trim().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.Trim()) > 0)
                {
                    //errMessage = this.WarehouseShelfNo_Title.Text.Trim() + "�͈͎̔w��Ɍ�肪����܂��B";
                    errMessage = "�I�Ԃ͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tEdit_WarehouseShelfNo_St;
                    result = false;
                    return result;
                }
            }
            // 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

            //�d����
            if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") && (this.tNedit_SupplierCd_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
                {
                    errMessage = "�d����͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tNedit_SupplierCd_St;
                    result = false;
                    return result;
                }
            }

            //�a�k�R�[�h
            if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") && (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
                {
                    errMessage = "�a�k�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tNedit_BLGoodsCode_St;
                    result = false;
                    return result;
                }
            }

            // �O���[�v�R�[�h
            if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") && (this.tNedit_BLGloupCode_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_BLGloupCode_St.DataText.Trim().CompareTo(this.tNedit_BLGloupCode_Ed.DataText.Trim()) > 0)
                {
                    errMessage = "�O���[�v�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tNedit_BLGloupCode_St;
                    result = false;
                    return result;
                }
            }

            //���[�J�[
            if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") && (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
                {         
                    errMessage = "���[�J�[�͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tNedit_GoodsMakerCd_St;
                    result = false;
                    return result;
                }
            }

            ////�d����R�[�h
            //if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") && (this.tNedit_SupplierCd_Ed.DataText.Trim() != ""))
            //{
            //    if (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            //    {         
            //        errMessage = "�d����R�[�h�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.tNedit_SupplierCd_St;
            //        result = false;
            //        return result;
            //    }
            //}
            ////�ϑ���R�[�h
            //if ((this.StartShipCustomerCode_tNedit.DataText.Trim() != "") && (this.EndShipCustomerCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartShipCustomerCode_tNedit.GetInt() > this.EndShipCustomerCode_tNedit.GetInt())
            //    {         
            //        errMessage = "�ϑ���R�[�h�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartShipCustomerCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}
            ////���i�敪�O���[�v�R�[�h
            //if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") && (this.tNedit_BLGloupCode_Ed.DataText.Trim() != ""))
            //{
            //    if (this.tNedit_BLGloupCode_St.DataText.Trim().CompareTo(this.tNedit_BLGloupCode_Ed.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "���i�敪�O���[�v�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.tNedit_BLGloupCode_St;
            //        result = false;
            //        return result;
            //    }
            //}

            
            ////���i�敪�R�[�h
            //if ((this.StartMediumGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndMediumGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartMediumGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndMediumGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "���i�敪�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartMediumGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}

            // 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            ////���i�敪�ڍ׃R�[�h
            //if ((this.StartDetailGoodsGanreCode_tEdit.DataText.Trim() != "") &&	(this.EndDetailGoodsGanreCode_tEdit.DataText.Trim() != "") &&
            //    (this.StartDetailGoodsGanreCode_tEdit.DataText.CompareTo(this.EndDetailGoodsGanreCode_tEdit.DataText) > 0))
            //{
            //    errMessage = this.DetailGoodsGanreCode_Title.Text + "�͈͎̔w��Ɍ�肪����܂��B";
            //    errComponent = this.StartDetailGoodsGanreCode_tEdit;
            //    result = false;
            //    return result;           
            //}
            //// 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    
            ////���i�R�[�h
            //if ((this.StartGoodsCode_tEdit.DataText.Trim() != "") && (this.EndGoodsCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartGoodsCode_tEdit.DataText.Trim().CompareTo(this.EndGoodsCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "���i�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartGoodsCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}

            //// 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            ////���Е��ރR�[�h
            //if ((this.StartEnterpriseGanreCode_tNedit.DataText.Trim() != "") && (this.EndEnterpriseGanreCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartEnterpriseGanreCode_tNedit.GetInt() > this.EndEnterpriseGanreCode_tNedit.GetInt())
            //    {
            //        errMessage = "���Е��ރR�[�h�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartEnterpriseGanreCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}

            ////�a�k�R�[�h
            //if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") && (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != ""))
            //{
            //    if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            //    {
            //        errMessage = "�a�k�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.tNedit_BLGoodsCode_St;
            //        result = false;
            //        return result;
            //    }
            //}
            // 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.09.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //�݌ɒ��o�敪
            //if (this.CmpStockDiv_CheckEditor.Checked == false && this.TrsStockDiv_CheckEditor.Checked == false &&
            //  this.EntrustCmpStockDiv_CheckEditor.Checked == false && this.EntrustTrsStockDiv_CheckEditor.Checked == false)
            //{
            //    //����`�F�b�N����Ă��Ȃ�
            //    errMessage = StockExtraDiv_Title.Text + "�͍Œ��͑I�����Ă��������B";
            //    errComponent = this.CmpStockDiv_CheckEditor;
            //    result = false;
            //    return result;             
            //}
            // 2007.09.05 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2008.10.07 30413 ���� ��ʓ��̓`�F�b�N��ύX <<<<<<END

            return result;
        }
        #endregion     

        #region ���t���̓`�F�b�N
        /// <summary>
        /// ���t���ړ��̓`�F�b�N�֐�
        /// </summary>
        /// <param name="startDateEdit">�J�n���t�R���|�[�l���g</param>
        /// <param name="endDateEdit">�I�����t�R���|�[�l���g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>   
        /// <param name="errComponent">���̓G���[�R���g���[��</param>
        /// <returns>true:���� false:�ُ�</returns>
        // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
        //private bool DateCheck(TDateEdit startDateEdit, TDateEdit endDateEdit, ref string msg, ref Control errComponent)
        private bool DateCheck(TDateEdit startDateEdit, ref string msg, ref Control errComponent)
        // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            bool status = true;

            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (IsErrorTDateEdit(startDateEdit, true))
            if (IsErrorTDateEdit(startDateEdit, false))
            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                //msg += "�J�n���̓��t������������܂���B";
                msg += "�I�����̓��t������������܂���B";
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                errComponent = startDateEdit;
                status = false;
                return status;
            }

            // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (IsErrorTDateEdit(endDateEdit, true))
            //{
            //    msg += "�I�����̓��t������������܂���B";
            //    errComponent = endDateEdit;
            //    status = false;
            //    return status;
            //}

            //if ((startDateEdit.GetDateTime() != DateTime.MinValue) && (endDateEdit.GetDateTime() != DateTime.MinValue))
            //{
            //    if (startDateEdit.GetLongDate() > endDateEdit.GetLongDate())
            //    {
            //        msg += "�J�n�����I�����𒴂��Ă��܂��B";
            //        errComponent = startDateEdit;
            //        status = false;
            //        return status;
            //    }
            //}
            // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<
            return status;
        }
        
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="canEmpty">�����̓t���O(true:�����͉�,false:�����͕s��)</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool canEmpty)
        {
            if (tDateEdit.CheckInputData() != null) return true;

            // ���t�𐔒l�^�Ŏ擾
            int date = tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // �����̓t���O�`�F�b�N
            if (canEmpty)
            {
                // �����͉Ŗ����͂̏ꍇ�͐���
                if (date == 0) return false;
            }

            // ���t�����̓`�F�b�N
            if (date == 0) return true;

            // �V�X�e���T�|�[�g�`�F�b�N
            if ((yy > 0) && (yy < 1900)) return true;

            // �N�E���E���ʓ��̓`�F�b�N
            switch (tDateEdit.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    {
                        if (yy == 0 || mm == 0 || dd == 0) return true;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    {
                        if (yy == 0 || mm == 0) return true;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date / 100 * 100 + 1);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    {
                        if (yy == 0) return false;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date / 10000 * 10000 + 101);
                        break;
                    }
                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    {
                        if (mm == 0 || dd == 0) return true;
                        break;
                    }
                // ��        �\����
                case emDateFormat.df2M:
                    {
                        if (mm == 0) return true;
                        break;
                    }
                // ��        �\����
                case emDateFormat.df2D:
                    {
                        if (dd == 0) return true;
                        break;
                    }
            }

            return false;
        }

        #endregion

        // 2008.10.08 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���Ӑ�(�d����)�I���������C�x���g
        ///// <summary>
        ///// ���Ӑ�(�d����)�I���������C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        ///// <<remarks>
        ///// <br>Note        :���Ӑ�K�C�h�œ��Ӑ��I���������ɔ������܂�</br>
        ///// <br>Programmer  :23010 �����@�m</br>
        ///// <br>Date        :2007.04.17</br>
        ///// </remarks>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustSuppli custSuppli;

        //    //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
        //    int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
			
        //    if(customerSearchRet == null) return;

        //    //���Ӑ�(�d����)�R�[�h���Z�b�g
        //    switch(this._custmerGuideIndex)
        //    {
        //        //�J�n�d����
        //        case 1:
        //        {
        //            this.tNedit_SupplierCd_St.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //        //�I���d����
        //        case 2:
        //        {
        //            this.tNedit_SupplierCd_Ed.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //    }
	          
        //}    
        #endregion
        // 2008.10.08 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region �o�א擾�Ӑ�(�ϑ���)�I���������C�x���g
        ///// <summary>
        ///// �o�א擾�Ӑ�(�ϑ���)�I���������C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        ///// <<remarks>
        ///// <br>Note        :���Ӑ�K�C�h�ŏo�א擾�Ӑ��I���������ɔ������܂�</br>
        ///// <br>Programmer  :23010 �����@�m</br>
        ///// <br>Date        :2007.04.17</br>
        ///// </remarks>
        //private void CustomerSearchForm_ShipCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
			
        //    //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
        //    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
			
        //    if(customerSearchRet == null) return;
					
        //    //�o�א擾�Ӑ�(�ϑ���)�R�[�h���Z�b�g
        //    switch(this._shipCustmerGuideIndex)
        //    {
        //        //�J�n�ϑ���
        //        case 1:
        //        {
        //            this.StartShipCustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //        //�I���ϑ���
        //        case 2:
        //        {
        //            this.EndShipCustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //    }
	          
        //}    
        #endregion
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        
        #endregion

        #region ControlEvent

        #region Form Load �C�x���g
        /// <summary>
        /// Form.Load �C�x���g (MAZAI02110UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������߂ĕ\������钼�O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note : 2012/12/25 ���j��</br>
        ///	<br>			  Redmine#33271 ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵�����̂��L�������邱�Ƃ̐ݒ��ǉ�����</br> 
        /// </remarks>
        private void MAZAI02110UA_Load(object sender, EventArgs e)
        {
            //�A�C�R��(��) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
            // 2008.10.07 30413 ���� �K�C�h�{�^���̃C���[�W�ݒ��ύX >>>>>>START
            //�q�ɃK�C�h
            this.St_WarehouseGuide_Button.ImageList = imageList16;
            this.Ed_WarehouseGuide_Button.ImageList = imageList16;
            this.St_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;           
            this.Ed_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //���[�J�[�K�C�h
            this.St_MakerGuide_Button.ImageList = imageList16;
            this.Ed_MakerGuide_Button.ImageList = imageList16;
            this.St_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //���Ӑ�(�d����)�K�C�h
            this.St_SupplierGuide_Button.ImageList = imageList16;
            this.Ed_SupplierGuide_Button.ImageList = imageList16;
            this.St_SupplierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_SupplierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////�o�א擾�Ӑ�(�ϑ���)�K�C�h
            //this.St_ShipCustomerGuide_Button.ImageList = imageList16;
            //this.Ed_ShipCustomerGuide_Button.ImageList = imageList16;
            //this.St_ShipCustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_ShipCustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////���i�K�C�h
            //this.St_GoodsGuide_Button.ImageList = imageList16;
            //this.Ed_GoodsGuide_Button.ImageList = imageList16;
            //this.St_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //���i�敪�O���[�v�K�C�h
            this.St_BLGloupGuide_Button.ImageList = imageList16;
            this.Ed_BLGloupGuide_Button.ImageList = imageList16;
            this.St_BLGloupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_BLGloupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////���i�敪�K�C�h
            //this.St_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////���i�敪�ڍ׃K�C�h
            //this.St_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////���Е��ރK�C�h
            //this.St_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.Ed_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.St_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //�a�k�R�[�h�K�C�h
            this.St_BLGoodsGuide_Button.ImageList = imageList16;
            this.Ed_BLGoodsGuide_Button.ImageList = imageList16;
            this.St_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2008.10.07 30413 ���� �K�C�h�{�^���̃C���[�W�ݒ��ύX <<<<<<END
            
            //��ʏ����ݒ�
            this.ScreenInitialSetting();

            // ---- ADD ���j�ā@2012/12/25 for Redmine#33271 ------------>>>>>>>>>>>
            uiMemInput1.ReadMemInput();
            switch (this._selPrintMode)
            {
                case 0:
                    {
                        this.tComboEditor_LineMaSqOfChDiv.Value = tComboEditor_LineMaSqOfChDiv0.Value;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_LineMaSqOfChDiv.Value = tComboEditor_LineMaSqOfChDiv1.Value;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_LineMaSqOfChDiv.Value = tComboEditor_LineMaSqOfChDiv2.Value;
                        break;
                    }
            }
            
            // ---- ADD ���j�ā@2012/12/25 for Redmine#33271 ------------<<<<<<<<<<<

            // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 >>>>>>START
            //TurnOoverThePagesDiv_ultraOptionSet_ValueChanged(sender, e);
            // 2008.10.08 30413 ���� ���g�p�̂��ߍ폜 <<<<<<END
            
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            if (this.ParentToolbarSettingEvent != null)
            {
                this.ParentToolbarSettingEvent(this);
            }
        }
        #endregion

        #region Form VisibleChanged �C�x���g
        /// <summary>
        /// Form.VisibleChanged �C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ύX�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2006.07.31</br>
        /// </remarks>    
        private void Main_UltraExplorerBar_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                // �����t�H�[�J�X�ݒ�
                this.StartDate_tDateEdit.Focus();
            }
        }
        #endregion

        #region UltraExplorerBar �C�x���g
        /// <summary>
        /// UltraExplorerBar.GroupExpanding �C�x���g (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroup���W�J�����O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortConditionGroup") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// UltraExplorerBar.GroupCollapsing �C�x���g (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroup���k�������O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortConditionGroup") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        #endregion

        #region Control Leave �C�x���g
       
        /// <summary>
        /// Control.Leave �C�x���g (StartMakerCode_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���̓t�H�[�J�X���R���g���[���𗣂��Ɣ������܂��B</br>
        /// <br>Programmer : 23010 ���� �m</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void StartMakerCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // �󗓂�0�̎������l���Z�b�g
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                //if (tNedit.Equals(this.StartMakerCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.StartLargeGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(0);                  
                //}
                //else if(tNedit.Equals(this.StartMediumGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.EndMakerCode_tNedit))
                //{
                //    tNedit.SetInt(999);
                //}
                //else if (tNedit.Equals(this.EndLargeGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(999);
                //}
                //else if (tNedit.Equals(this.EndMediumGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(999);
                //}
                //else if(tNedit.Equals(this.StartCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.EndCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(999999999);
                //}
                // else if(tNedit.Equals(this.StartShipCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.EndShipCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(999999999);
                //}
                //else if(tNedit.Equals(this.StartCmpClassificationCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.EndCmpClassificationCode_tNedit))
                //{
                //    tNedit.SetInt(99);
                //}
                tNedit.Clear();
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            }

        }

        /// <summary>
        /// Control.Leave �C�x���g (StartCarrierEpCode_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���̓t�H�[�J�X���R���g���[���𗣂��Ɣ������܂��B</br>
        /// <br>Programmer : 23010 ���� �m</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void StartCarrierEpCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // �󗓂�0�̎������l���Z�b�g
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                //if (tNedit.Equals(this.StartBLGoodsCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.EndBLGoodsCode_tNedit))
                //{
                //    tNedit.SetInt(99999);
                //}
                tNedit.Clear();
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            }
        }
  
        #endregion

        // 2008.10.08 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region Value Changed �C�x���g
        ///// <summary>
        ///// ValueChanged �C�x���g (TurnOoverThePagesDiv_ultraOptionSet)
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���̓t�H�[�J�X���R���g���[���𗣂��Ɣ������܂��B</br>
        ///// <br>Programmer : 980035 ���� ��`</br>
        ///// <br>Date       : 2007.09.05</br>
        ///// </remarks>
        //private void TurnOoverThePagesDiv_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        //{
        //    // 2008.10.07 30413 ���� �b��I�ɃR�����g >>>>>>START
        //    //int checkIndex = this.TurnOoverThePagesDiv_ultraOptionSet.CheckedIndex;
        //    int checkIndex = 0;
        //    // 2008.10.07 30413 ���� �b��I�ɃR�����g <<<<<<END
        //    int selectIndex = this.ChangePageDiv_tComboEditor.SelectedIndex;

        //    if ((checkIndex == 1) && ((selectIndex == 0) || (selectIndex == 4)))
        //    {
        //        ShelfNoBreakDiv_tComboEditor.Enabled = true;
        //    }
        //    else
        //    {
        //        ShelfNoBreakDiv_tComboEditor.Enabled = false;
        //    }
        //}
        #endregion
        // 2008.10.08 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        
        #region �K�C�h�ďo������

        #region ���[�J�[�K�C�h
        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            if(this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();               
            }
            //���[�J�[�K�C�h�N��
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            switch(status)
            {
                //�擾
                case 0:
                {
                    if (makerUMnt != null)
                    {
                        //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                        if((Infragistics.Win.Misc.UltraButton)sender == this.St_MakerGuide_Button)
                        {
                            //�J�n
                            this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                        }
                        else
                        {
                            //�I��
                            this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                        }

                        // ���̃R���g���[���փt�H�[�J�X���ړ�
                        this.SelectNextControl((Control)sender, true, true, true, true);
                    }           
                    break;
                }
                //�L�����Z��
                case 1:
                {
                    
                    break;
                }
            }
        }

        #endregion

        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���i�敪�O���[�v�K�C�h
        ///// <summary>
        ///// ���i�敪�O���[�v�K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���i�敪�O���[�v�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.04.09</br>
        ///// </remarks>    
        //private void LargeGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    LGoodsGanre lGoodsGanre = null;
        //    if(this._lGoodsGanreAcs == null)
        //    {
        //        this._lGoodsGanreAcs = new LGoodsGanreAcs();               
        //    }
        //    //�]�ƈ��K�C�h�N��(���J�A��t�A�̔���S�Ċ܂�)���v�ύX
        //    int status = this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,out lGoodsGanre);

        //    switch(status)
        //    {
        //        //�擾
        //        case 0:
        //        {                  
        //            if(lGoodsGanre != null)
        //            {
        //                //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGloupGuide_Button)
        //                {
        //                    //�J�n
        //                    this.tNedit_BLGloupCode_St.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //�I��
        //                    this.tNedit_BLGloupCode_Ed.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
        //                }           
                                  
        //            }
        //            break;
        //        }
        //        //�L�����Z��
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END

        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���i�敪�K�C�h
        ///// <summary>
        ///// ���i�敪�K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���i�敪�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.04.09</br>
        ///// </remarks>    
        //private void MidiumGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    MGoodsGanre mGoodsGanre = null;
        //    if(this._mGoodsGanreAcs == null)
        //    {
        //        this._mGoodsGanreAcs = new MGoodsGanreAcs();               
        //    }
        //    //���i�敪�K�C�h�N��(�����ɏ��i�O���[�v�R�[�h���c���Ă���̂ŋ󕶎����Z�b�g)
        //    //int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 0);
        //    int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 1);

        //    switch(status)
        //    {
        //        //�擾
        //        case 0:
        //        {                  
        //            if(mGoodsGanre != null)
        //            {
        //                //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_MidiumGoodsGanreGuide_Button)
        //                {
        //                    //�J�n
        //                    this.StartMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //�I��
        //                    this.EndMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }           
                                  
        //            }
        //            break;
        //        }
        //        //�L�����Z��
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END

        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���i�敪�ڍ׃K�C�h
        ///// <summary>
        ///// ���i�敪�ڍ׃K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���i�敪�ڍ׃K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 980035 ����@��`</br>
        ///// <br>Date       : 2007.09.05</br>
        ///// </remarks>    
        //private void St_CellphoneModelGuide_Button_Click(object sender, EventArgs e)
        //{
        //    DGoodsGanre dGoodsGanre = null;
        //    if (this._dGoodsGanreAcs == null)
        //    {
        //        this._dGoodsGanreAcs = new DGoodsGanreAcs();
        //    }

        //    //���i�敪�ڍ׃K�C�h�N��
        //    int status = this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre);

        //    switch (status)
        //    {
        //        //�擾
        //        case 0:
        //            {
        //                if (dGoodsGanre != null)
        //                {
        //                    //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_DetailGoodsGanreGuide_Button)
        //                    {
        //                        //�J�n
        //                        this.StartDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }
        //                    else
        //                    {
        //                        //�I��
        //                        this.EndDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }
        //                }
        //                break;
        //            }
        //        //�L�����Z��
        //        case 1:
        //            {

        //                break;
        //            }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END

        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���i�K�C�h
        ///// <summary>
        ///// ���i�K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���i�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.03.13</br>
        ///// </remarks>    
        //private void GoodsGuide_Button_Click(object sender, EventArgs e)
        //{     
        //    GoodsUnitData goodsUnitData = null;
        //    MAKHN04110UA goodsGuide = new MAKHN04110UA();

        //    DialogResult ret = goodsGuide.ShowGuide(this,this._enterpriseCode,out goodsUnitData);

        //    if(ret == DialogResult.OK)
        //    {
        //        if(goodsUnitData != null)
        //        {
        //            //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //            if((Infragistics.Win.Misc.UltraButton)sender == this.St_GoodsGuide_Button)
        //            {
        //                //�J�n
        //                // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
        //                //this.StartGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
        //                this.StartGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo.TrimEnd();
        //                // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
        //            }
        //            else
        //            {
        //                //�I��
        //                // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
        //                //this.EndGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
        //                this.EndGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo.TrimEnd();
        //                // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
        //            }           
                              
        //        }
        //    }
        //    else
        //    {
        //        //�L�����Z���Ȃ̂łȂɂ����Ȃ�
        //    }

        //}
        #endregion
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        
        #region �q�ɃK�C�h
        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.03.13</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            WarehouseAcs _warehouseGuide = new WarehouseAcs();

            int status = _warehouseGuide.ExecuteGuid(out warehouseData,this._enterpriseCode,this._sectionCode);

            if(status == 0)
            {
                if(warehouseData != null)
                {
                    //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                    if((Infragistics.Win.Misc.UltraButton)sender == this.St_WarehouseGuide_Button)
                    {
                        //�J�n
                        this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else
                    {
                        //�I��
                        this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);          
                }
            }
            else
            {
                //�L�����Z���Ȃ̂łȂɂ����Ȃ�
            }
        }

        #endregion

        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region �o�א擾�Ӑ�(�ϑ���)�K�C�h
        ///// <summary>
        ///// �o�א擾�Ӑ�(�ϑ���)�K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       :���Ӑ�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.04.13</br>
        ///// </remarks>    
        //private void St_ShipCustomerGuide_Button_Click(object sender, EventArgs e)
        //{
        //    Infragistics.Win.Misc.UltraButton uButton = sender as Infragistics.Win.Misc.UltraButton;

        //    if (uButton == null)
        //    {
        //        return;
        //    }

        //    //�J�n�d����{�^��
        //    if(uButton.Equals(this.St_ShipCustomerGuide_Button))
        //    {
        //        this._shipCustmerGuideIndex = 1;
        //    }
        //    //�I���d����{�^��
        //    else if(uButton.Equals(this.Ed_ShipCustomerGuide_Button))
        //    {
        //        this._shipCustmerGuideIndex = 2;
        //    }

        //    //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_ACCEPT_WHOLE_SALE, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_ShipCustomerSelect);
        //    customerSearchForm.ShowDialog(this);
        //}
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        #endregion

        #region ���Ӑ�(�d����)�K�C�h
        /// <summary>
        /// ���Ӑ�(�d����)�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       :���Ӑ�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>    
        private void St_SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            // 2008.10.08 30413 ���� �d����K�C�h�ɕύX >>>>>>START
            //Infragistics.Win.Misc.UltraButton uButton = sender as Infragistics.Win.Misc.UltraButton;

            //if (uButton == null)
            //{
            //    return;
            //}

            ////�J�n�d����{�^��
            //if(uButton.Equals(this.St_SupplierGuide_Button))
            //{
            //    this._custmerGuideIndex = 1;
            //}
            ////�I���d����{�^��
            //else if(uButton.Equals(this.Ed_SupplierGuide_Button))
            //{
            //    this._custmerGuideIndex = 2;
            //}

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            int status = -1;
            string supplierTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            
            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                if (supplierTag.CompareTo("1") == 0)
                {
                    this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                }
                else
                {
                    this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                }

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.08 30413 ���� �d����K�C�h�ɕύX <<<<<<END
        }

        #endregion

        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���Е��ރK�C�h
        ///// <summary>
        ///// ���Е��ރK�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���Е��ރK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 980035 ����@��`</br>
        ///// <br>Date       : 2007.09.05</br>
        ///// </remarks>    
        //private void St_EnterpriseGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    UserGdBd userGdBd = null;
        //    if (this._userGuideGuide == null)
        //    {
        //        this._userGuideGuide = new UserGuideGuide();
        //    }

        //    //���Е��ރK�C�h�N��
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(41, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        //�擾
        //        if (userGdBd != null)
        //        {
        //            //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //            if ((Infragistics.Win.Misc.UltraButton)sender == this.St_EnterpriseGanreGuide_Button)
        //            {
        //                //�J�n
        //                this.StartEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //            else
        //            {
        //                //�I��
        //                this.EndEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //        }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        
        #region �a�k�R�[�h�K�C�h
        /// <summary>
        /// �a�k�R�[�h�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.05</br>
        /// </remarks>    
        private void St_BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status == 0)
            {
                if (blGoodsCdUMnt != null)
                {
                    //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGoodsGuide_Button)
                    {
                        //�J�n
                        this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    }
                    else
                    {
                        //�I��
                        this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                //�L�����Z���Ȃ̂łȂɂ����Ȃ�
            }
        }

        #endregion

        #region �O���[�v�R�[�h�K�C�h
        /// <summary>
        /// �O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.11.26</br>
        /// </remarks>    
        private void St_BLGloupGuide_Button_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupU = new BLGroupU();
            if (this._blGoodsCdAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = _blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                if (blGroupU != null)
                {
                    //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGloupGuide_Button)
                    {
                        //�J�n
                        this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                    }
                    else
                    {
                        //�I��
                        this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                //�L�����Z���Ȃ̂łȂɂ����Ȃ�
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        // �q��(�J�n)���q��(�I��)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // �q��(�I��)���I��(�J�n)
                        e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)��BL�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BL�R�[�h(�J�n)��BL�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BL�R�[�h(�I��)���O���[�v�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // �O���[�v�R�[�h(�J�n)���O���[�v�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // �O���[�v�R�[�h(�I��)�����[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // ���[�J�[(�J�n)�����[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        if (this.tComboEditor_LendExtraDiv.Visible)
                        {
                            // ���[�J�[(�I��)���ݏo��
                            e.NextCtrl = this.tComboEditor_LendExtraDiv;
                        }
                        else
                        {
                            // ���[�J�[(�I��)���I����
                            e.NextCtrl = this.StartDate_tDateEdit;
                        }
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if ((e.PrevCtrl == this.StartDate_tDateEdit) && (!this.tComboEditor_LendExtraDiv.Visible))
                    {
                        // �I���������[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LendExtraDiv)
                    {
                        // �ݏo�������[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // ���[�J�[(�I��)�����[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // ���[�J�[(�J�n)���O���[�v�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // �O���[�v�R�[�h(�I��)���O���[�v�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // �O���[�v�R�[�h(�J�n)��BL�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BL�R�[�h(�I��)��BL�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BL�R�[�h(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseShelfNo_St)
                    {
                        // �I��(�J�n)���q��(�I��)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // �q��(�I��)���q��(�J�n)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                }
            }
        }

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion

        /// <summary>
        /// ValueChanged �C�x���g (tComboEditor_NewPageDiv)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���ł̒l��ύX����Ɣ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.09</br>
        /// <br>Update Note: 2009/12/04 ������</br>
        /// <br>			 ��ʐ���̕ύX�Ή�</br>
        /// </remarks>
        private void tComboEditor_NewPageDiv_ValueChanged(object sender, EventArgs e)
        {
            //-------- UPD 2009/12/04 ------->>>>>
            //int selectIndex = this.tComboEditor_NewPageDiv.SelectedIndex;
            //if (selectIndex == 1)
            //{
            //    // �o�͏��̏ꍇ�͗L��
            //    ShelfNoBreakDiv_tComboEditor.Enabled = true;
            //}
            //else
            //{
            //    // ��L�ȊO�͖���
            //    ShelfNoBreakDiv_tComboEditor.Enabled = false;
            //}
            if (this._selPrintMode == 1 || this._selPrintMode == 2)
            {
                // �I�ԏ�
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    // ���v���
                    switch (this.tComboEditor_SubtotalPrint.SelectedIndex)
                    {
                        // ����
                        case 0:
                            ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            break;
                        // ���Ȃ�
                        case 1:
                            // ����:�q��
                            if (this.tComboEditor_NewPageDiv.SelectedIndex == 0)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            // ����:�o�͏�
                            else if (this.tComboEditor_NewPageDiv.SelectedIndex == 1)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            }
                            // ����:���Ȃ�
                            else
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            break;
                    }

                }
                // �I�ԏ��ȊO
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }
            //-------- UPD 2009/12/04 -------<<<<<
        }
        /// <summary>
        /// �o�͏��ύX���I�ԃu���C�N�敪�̐ݒ���s���B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �o�͏��ύX���I�ԃu���C�N�敪�̐ݒ���s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.12.04</br>
        /// <br>Update Note: 2011/02/17 �c����</br>
        /// <br>			 �I�������\�̒I�ԃu���C�N�敪�̗L�������̃`�F�b�N�ɂ���</br>
        /// </remarks>
        private void ChangePageDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._selPrintMode == 1 || this._selPrintMode == 2)
            {
                // �I�ԏ�
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    // ���v���
                    switch (this.tComboEditor_SubtotalPrint.SelectedIndex)
                    {
                        // ����
                        case 0:
                            ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            break;
                        // ���Ȃ�
                        case 1:
                            // ����:�q��
                            if (this.tComboEditor_NewPageDiv.SelectedIndex == 0)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            // ����:�o�͏�
                            else if (this.tComboEditor_NewPageDiv.SelectedIndex == 1)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            }
                            // ����:���Ȃ�
                            else
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            break;
                    }

                }
                // �I�ԏ��ȊO
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }

            // ---------- ADD 2011/02/17 ------------------------------>>>>>
            // �I�������\
            if (this._selPrintMode == 0)
            {
                // �I�ԏ�
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = true;
                }
                // �I�ԏ��ȊO
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }
            // ---------- ADD 2011/02/17 ------------------------------<<<<<

        }
        /// <summary>
        /// ���v����ύX���I�ԃu���C�N�敪�̐ݒ���s���B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���v����ύX���I�ԃu���C�N�敪�̐ݒ���s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.12.04</br>
        /// </remarks>
        private void tComboEditor_SubtotalPrint_ValueChanged(object sender, EventArgs e)
        {
            if (this._selPrintMode == 1 || this._selPrintMode == 2)
            {
                // �I�ԏ�
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    // ���v���
                    switch (this.tComboEditor_SubtotalPrint.SelectedIndex)
                    {
                        // ����
                        case 0:
                            ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            break;
                        // ���Ȃ�
                        case 1:
                            // ����:�q��
                            if (this.tComboEditor_NewPageDiv.SelectedIndex == 0)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            // ����:�o�͏�
                            else if (this.tComboEditor_NewPageDiv.SelectedIndex == 1)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            }
                            // ����:���Ȃ�
                            else
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            break;
                    }

                }
                // �I�ԏ��ȊO
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }
        }
        // -----------------------ADD 2011/01/11------------------------>>>>>
        /// <summary>
        /// �I�������͋敪�ύX�����ʏo�͋敪�̐ݒ���s���B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �I�������͋敪�ύX�����ʏo�͋敪�̐ݒ���s���B</br>
        /// <br>Programmer	: liyp</br>
        /// <br>Date		: 2011/01/11</br>
        /// </remarks>
        private void tComboEditor_InventoryNonInputDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_InventoryNonInputDiv.Value == 0)
            {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "�S�ďo��");
                tComboEditor_NumOutputDiv.Items.Add(1, "�I�����P�ȏ�o��");
                tComboEditor_NumOutputDiv.Items.Add(2, "�I�����O�ȉ��o��");
                tComboEditor_NumOutputDiv.Items.Add(3, "�I�����O�̂ݏo��");
            }
            else
            {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "�S�ďo��");
                tComboEditor_NumOutputDiv.Items.Add(4, "�����͂̂ݏo��");
                tComboEditor_NumOutputDiv.Items.Add(5, "�����͈ȊO�o��");
            }
            tComboEditor_NumOutputDiv.Value = 0;
        }
        // -----------------------ADD 2011/01/11------------------------<<<<<
        // --- ADD ���j�� 2012/12/25  for Redmine#33271--------->>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵�����̂̎擾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵�����̂̎擾</br>
        /// <br>Programmer	: ���j��</br>
        /// <br>Date		: 2012/12/25</br>
        /// </remarks>
        private void tComboEditor_LineMaSqOfChDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (this._selPrintMode)
            {
                case 0:
                    {
                        tComboEditor_LineMaSqOfChDiv0.Value = this.tComboEditor_LineMaSqOfChDiv.Value;
                        break;
                    }
                case 1:
                    {
                        tComboEditor_LineMaSqOfChDiv1.Value = this.tComboEditor_LineMaSqOfChDiv.Value;
                        break;
                    }
                case 2:
                    {
                        tComboEditor_LineMaSqOfChDiv2.Value = this.tComboEditor_LineMaSqOfChDiv.Value;
                        break;
                    }
            }

        }
        // --- ADD ���j�� 2012/12/25  for Redmine#33271---------<<<<<<<<<<<<<<<<<<<<<<<
        
    }
}
