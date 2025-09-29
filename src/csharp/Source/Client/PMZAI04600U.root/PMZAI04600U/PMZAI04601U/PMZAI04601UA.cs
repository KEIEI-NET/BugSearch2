//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉړ��d�q����
// �v���O�����T�v   : �݌Ɉړ��d�q���� �t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw
// �� �� ��  2011/05/11  �C�����e : redmine #20966
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/05/18  �C�����e : redmine #21429
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/05/08  �C�����e : redmine #21627
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��r��
// �� �� ��  2011/05/20  �C�����e : redmine #21657
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��r��
// �� �� ��  2011/05/21  �C�����e : redmine #21678
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/05/23  �C�����e : redmine #21681
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;      // ConstantManagement�̎g�p�ɕK�v(SFCMN00006C)
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

using Infragistics.Win;
using System.Reflection;
using System.Threading;
using Broadleaf.Library.Globarization; // SFCMN00002C
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ɉړ��d�q���� �t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��d�q�����̂t�h�N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br>Update Note: 2011/05/11 tianjw</br>
    /// <br>             redmine #20966</br>
    /// <br></br>
    /// </remarks>
    public partial class PMZAI04601UA : Form
    {
        #region �v���C�x�[�g�ϐ�

        // **** �A�v���P�[�V�������ʕϐ� ****
        private string _enterpriseCode = string.Empty;	    	// ��ƃR�[�h
        private string _invokerPgId = string.Empty;             // �Ăяo�����v���O����ID

        // **** ���O�C�����[�U�[�f�[�^�ۑ� ****
        private string _loginSectionCode = string.Empty;		// �����_�R�[�h
        private string _loginSectionName = string.Empty;		// �����_��

        private string _loginUserCd = string.Empty;             // ���O�C�����[�U�[
        private string _loginUserName = string.Empty;           // ���O�C�����[�U�[��
        private string slipCd = string.Empty;

        private int _checkCount = 0;                       // ��{������Check�� 

        // �݌ɊǗ��S�̐ݒ�}�X�^�A�N�Z�X�N���X
        private StockMngTtlStAcs _stockMngTglStAcs;        

        /// <summary>�`�[�\���^�u ��T�C�Y���������l</summary>
        private bool _columnWidthAutoAdjust = false;

        /// <summary>���׃O���b�h�I�����_�R�[�h</summary>
        private string _selectedSectionCd = string.Empty;

        /// <summary>SFKTN09002A)���_</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>SFTOK09382A)�]�ƈ�</summary>
        private EmployeeAcs _employeeAcs;
        /// <summary>MAKHN09112A)���[�J�[</summary>
        private MakerAcs _makerAcs;
        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>MAKHN09332A)�q��</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>PMKHN09022A)�d����</summary>
        private SupplierAcs _supplierAcs;
        /// <summary>SFTOK9402)���l�ݒ�</summary>
        private NoteGuidAcs _noteGuidAcs;

        // **** �݌Ɉړ��d�q�����v���W�F�N�g�N���X ****
        /// <summary>PMZAI04603A)�݌Ɉړ��d�q����</summary>
        private StockMoveSlipSearchAcs _stockMoveSlipSearchAcs;

        /// <summary>PMZAI04604UA)�ݒ�t�H�[��</summary>
        private PMZAI04604UA _settingForm;

        // **** ���o�����N���X ****
        /// <summary>���������N���X (PMZAI04602EA)</summary>
        private StockMovePpr _stockMovePpr = null;

        //���o�����ɕύX�����������ǂ����̔��f�p(�O�񌟍����ƍ��񌟍����O�̒l���r)

        /// <summary>�O�񌟍������o�����N���X(PMZAI04602EB)</summary>
        private string _rl_RemainTypeBackup = string.Empty;


        // **** ���׃f�[�^�i�[�f�[�^�Z�b�g�I�u�W�F�N�g **** 
        /// <summary>���׃f�[�^�i�[�f�[�^�Z�b�g</summary>

        private StockMoveDetailDataSet _stockMoveDataSet;

        // **** ���ߓ��֘A ****
        /// <summary>���ߓ��擾�p�N���X</summary>
        TotalDayCalculator _tCalcAcs = null;
        /// <summary>�����������</summary>
        private DateTime _currentTotalDay;
        /// <summary>�����������</summary>
        private DateTime _currentTotalMonth;
        /// <summary>�O���������</summary>
        private DateTime _prevTotalDay;
        /// <summary>�O���������</summary>
        private DateTime _prevTotalMonth;

        /// <summary>���t�擾���i</summary>
        private DateGetAcs _dateGetAcs;

        // **** ��ʐݒ�p ****

        // **** �����T�C�Y ****
        /// <summary>�����T�C�Y</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        // **** �{�^���p�C���[�W���X�g ****
        private ImageList _imageList16 = null;                  // �C���[�W���X�g

        // **** �X�L���ݒ�p�N���X ****
        private ControlScreenSkin _controlScreenSkin;

        /// <summary>���݂̃R���g���[���ʒuX (�X���C�_�[)</summary>
        int _currentLocationX = 0;
        /// <summary>���݂̃R���g���[���ʒuY (�X���C�_�[)</summary>
        int _currentLocationY = 0;

        // **** �e�L�X�g�o�͗p ****
        private string _txtexp_FileName = string.Empty;         // �o�̓t�@�C����
        private StockMoveUserConst _userSetting;             // �o�͐ݒ�XML����̎擾�ݒ�
        private string[] _patternSetting;                       // �ݒ�l
        private List<String> _exportColumnNameList;             // �o�̓J������

        // **** �����܂��������s�����ڗp ****
        /// <summary>���l�P</summary>
        private string _srSlipNote = string.Empty;
        /// <summary>���l�P(*����������)</summary>
        private string _srRvSlipNote = string.Empty;
        /// <summary>�i��</summary>
        private string _srGoodsName = string.Empty;
        /// <summary>�i��(*����������)</summary>
        private string _srRvGoodsName = string.Empty;
        /// <summary>�i��</summary>
        private string _srGoodsNo = string.Empty;
        /// <summary>�i��(*����������)</summary>
        private string _srRvGoodsNo = string.Empty;
        /// <summary>�I��</summary>
        private string _srWarehouseShelfNo = string.Empty;
        /// <summary>�I��(*����������)</summary>
        private string _srRvWarehouseShelfNo = string.Empty;

        // **** �R�[�h�������̂�؂�ւ��鍀�ڗp ****
        /// <summary>�S���҃R�[�h</summary>
        private string _swSalesEmployeeCd = string.Empty;
        /// <summary>�S���Җ�</summary>
        private string _swSalesEmployeeName = string.Empty;
        /// <summary>BL�R�[�h</summary>
        private int _swBLGoodsCode = 0;
        /// <summary>BL�R�[�h��</summary>
        private string _swBLGoodsName = string.Empty;
        /// <summary>���苒�_�R�[�h</summary>
        //private int _swAfSectionCode = 0; // DEL 2010/05/18
        private string _swAfSectionCode = string.Empty; // ADD 2010/05/18
        /// <summary>���苒�_��</summary>
        private string _swAfSectionName = string.Empty;
        /// <summary>����q�ɃR�[�h</summary>
        private string _swAfEnterWarehCode = string.Empty;
        /// <summary>����q�ɖ�</summary>
        private string _swAfEnterWarehName = string.Empty;
        /// <summary>���[�J�[�R�[�h</summary>
        private int _swGoodsMakerCd = 0;
        /// <summary>���[�J�[��</summary>
        private string _swGoodsMakerName = string.Empty;
        /// <summary>�d����R�[�h</summary>
        private int _swSupplierCd = 0;
        /// <summary>�d���於</summary>
        private string _swSupplierName = string.Empty;

        /// <summary>�폜�w��敪</summary>
        private int _logicalDelDiv = 0;

        /// <summary>�݌ɊǗ��S�̐ݒ�</summary>
        private StockMngTtlSt _stockMngTtlSt;

        /// <summary>�O����͒l</summary>
        private PrevInputValue _prevInputValue;

        /// <summary>���f�_�C�A���O</summary>
        private SFCMN00299CA _processingDialog = null;

        // **** �R���g���[�� ****
        private Control _prevControl;

        // �O���b�h����̖߂��R���g���[��(�ڍ׏����̒���Control)
        private Control _gridUpKeyBackControl;

        // **** �O���b�h�\���p ****
        // �����Z���̕\���ݒ�
        private Infragistics.Win.Appearance _margedCellAppearance;

        // �O���b�h�E�J�����`���[�U�[����
        GridColumnChooserControl _gridColumnChooserControl;

        //private bool tabFlg = true;

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // ���쌠���̐��䃊�X�g(���ڎQ�Ƃ���ƒx���̂Ńf�B�N�V���i����)

        //���s�����ԓ`�̐擪�̖��ׂ̌����`�[�ԍ�
        private string _searchSalesSlipNum = string.Empty;

        // �}�E�X�Őԓ`�^�u�Ɉړ������A�G���[�̏ꍇ�A�t�H�[�J�X�ݒ�p
        private Control _control = null;

        private int _stockMoveFixCode; // �݌Ɉړ��m��敪

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_TextOutput;

        /// <summary>�O�񌟍������o�����N���X(PMKAU04002EA)</summary>
        private StockMovePpr _stockMovePprBackUp = null;
        private int _logicalDelDivBackUp = -1;

        /// <summary>�}�X�^�`�F�b�N�t���O</summary>
        private bool _isError = false;
        /// <summary>�t�H�[�J�X�̃R���g���[��</summary>
        private Control _nextControl;
        private bool _doSearchFlg = true;

        private bool _initFlg = true;

        // �`�[�O���b�h�J��������
        private GridColPosFixController _stockMoveGridColPosCtrl;

        #region Private Const

        #region �v���C�x�[�g�萔
        /// <summary>�����܂������u�ƈ�v�v�X�e�[�^�X</summary>
        private const int CT_FUZZY_MATCHWITH = 0;
        /// <summary>�����܂������u�Ŏn��v�X�e�[�^�X</summary>
        private const int CT_FUZZY_STARTWITH = 1;
        /// <summary>�����܂������u���܂ށv�X�e�[�^�X</summary>
        private const int CT_FUZZY_INCLUDEWITH = 2;
        /// <summary>�����܂������u�ŏI��v�X�e�[�^�X</summary>
        private const int CT_FUZZY_ENDWITH = 3;

        /// <summary>�d����d�q����PGID</summary>
        private const string CT_SUPPLIER_ERECNOTE_PGID = "PMKOU04001U";
        /// <summary>�݌Ɉړ��d�q����PGID</summary>
        private const string CT_CUSTOMER_ERECNOTE_PGID = "PMZAI04601U";

        /// <summary>�݌Ɉړ��d�q�����A�Z���u��ID</summary>
        private const string ctAssemblyName = "PMZAI04601UA";

        /// <summary>�\����(��{����)</summary>
        private const int CT_INITIA_COMMONL_ROW_COUNT =2;
        /// <summary>�\����(���o����)</summary>
        private const int CT_INITIAL_EXTRA_ROW_COUNT = 3;
        /// <summary>�����\���ʒu ����X</summary>
        private const int CT_INITIAL_FIELD_POSITION_X = 13;
        /// <summary>�\���ʒu ����X</summary>
        private const int CT_INITIAL_FIELD_POSITION_X_2 = 360;
        /// <summary>�\���ʒu ����X</summary>
        private const int CT_INITIAL_FIELD_POSITION_X_3 = 700;
        /// <summary>�����\���ʒu ����Y</summary>
        private const int CT_INITIAL_FIELD_POSITION_Y = 1;
        /// <summary>�\���Ԋu �]��</summary>
        private const int CT_FIELD_INTERVAL_X = 10;
        /// <summary>�\���Ԋu�F���x��</summary>
        private const int CT_INTERVAL_LABEL = 100;
        /// <summary>�\���Ԋu�F�R���{�{�b�N�X</summary>
        private const int CT_INTERVAL_COMBOBOX = 200;
        /// <summary>�\���Ԋu�F���͈�(tNedit/tEdit)(�t���R���g���[���Ȃ�)</summary>
        private const int CT_INTERVAL_EDIT = 200;
        /// <summary>�\���Ԋu�F���͈�(tNedit/tEdit)(�{�^������)</summary>
        private const int CT_INTERVAL_EDIT_WITHBUTTON = 175;
        /// <summary>�\���Ԋu�F���͈�(tNedit/tEdit)(�����܂���������)</summary>
        private const int CT_INTERVAL_EDIT_WITHCOMBO = 124;
        /// <summary>�\���Ԋu�F�{�^��</summary>
        private const int CT_INTERVAL_BUTTON = 25;
        /// <summary>�\���Ԋu�F�����܂������p�R���{�{�b�N�X</summary>
        private const int CT_INTERVAL_FUZZYCOMBO = 76;

        /// <summary>�\���Ԋu�F�s</summary>
        private const int CT_INTERVAL_HEIGHT = 26;
        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>���׃f�[�^���o�ő匏��</summary>
        private const long DATA_COUNT_MAX = 20000;

        #endregion // �v���C�x�[�g�萔

        #region ���b�Z�[�W�萔

        /// <summary>���������b�Z�[�W�u�݌Ɉړ��f�[�^�̎擾�Ɏ��s���܂����B�v</summary>
        private const string MSG_FAILED2GET_SLIP_DATA = "�݌Ɉړ��f�[�^�̎擾�Ɏ��s���܂����B";

        /// <summary>���������b�Z�[�W�u�����ɍ��v����f�[�^�����݂��܂���B�v</summary>
        private const string MSG_MATCHED_DATA_NOT_FOUND = "�����ɍ��v����f�[�^�����݂��܂���B";

        /// <summary>�`�F�b�N�����b�Z�[�W�u�J�n�����I����������ɂ��邱�Ƃ͂ł��܂���B�v</summary>
        private const string MSG_MUST_BE_CORRECT_CALENDER = "�J�n�����I����������ɂ��邱�Ƃ͂ł��܂���B";

        /// <summary>�`�F�b�N�����b�Z�[�W�u���㌎�������擾�̏��������ŃG���[���������܂����B�v</summary>
        private const string MSG_TOTALDAY_INITIALIE_FAILED = "���㌎�������擾�̏��������ŃG���[���������܂����B";

        /// <summary>�`�F�b�N�����b�Z�[�W�u�o�̓t�@�C�������w�肳��Ă��܂���B�ݒ�{�^������ݒ���s���Ă��������B�v</summary>
        private const string MSG_OUTPUTFILENAME_NOTFOUND = "�o�̓t�@�C�������w�肳��Ă��܂���B�ݒ�{�^������ݒ���s���Ă��������B";

        /// <summary>�`�F�b�N�����b�Z�[�W�u�t�@�C���ւ̏o�͂Ɏ��s���܂����B�v</summary>
        private const string MSG_OUTPUTFILE_FAILED = "�t�@�C���ւ̏o�͂Ɏ��s���܂����B";

        /// <summary>�e�L�X�g�G�N�X�|�[�g���������b�Z�[�W�u �s�̃f�[�^���t�@�C���֏o�͂��܂����B�v</summary>
        private const string MSG_OUTPUTFILE_SUCCEEDED = "�s�̃f�[�^���t�@�C���֏o�͂��܂����B";

        /// <summary>�`�F�b�N�����b�Z�[�W�u�o�̓t�@�C�������w�肳��Ă��܂���B�v</summary>
        private const string MSG_OUTPUTEXCEL_NOFILENAME = "�o�̓t�@�C�������w�肳��Ă��܂���B";

        /// <summary>EXCEL�G�N�X�|�[�g���������b�Z�[�W�uEXCEL�f�[�^���o�͂��܂����B�v</summary>
        private const string MSG_OUTPUTEXCEL_SUCCEEDED = "EXCEL�f�[�^���o�͂��܂����B";

        /// <summary>���������b�Z�[�W�u�w�肳�ꂽ�����񂪑��݂���s�͂���܂���B�v</summary>
        private const string MSG_ROWSEARCH_NOT_FOUND = "�w�肳�ꂽ�����񂪑��݂���s�͂���܂���B";

        /// <summary>�`�F�b�N�����b�Z�[�W�u���s���ł��v</summary>
        private const string MSG_SALESDATE_ERROR = "���s���ł��B";
        /// <summary>�`�F�b�N�����b�Z�[�W�u���s���ł��v</summary>
        private const string MSG_ST_SALESDATE_ERROR = "�J�n";
        /// <summary>�`�F�b�N�����b�Z�[�W�u���s���ł��v</summary>
        private const string MSG_ED_SALESDATE_ERROR = "�I��";

        /// <summary>�`�F�b�N�����b�Z�[�W�u�J�n���͓����s���ł��v</summary>
        private const string MSG_ST_INPUTDATE_ERROR = "�J�n���͓����s���ł��B";
        /// <summary>�`�F�b�N�����b�Z�[�W�u�I�����͓����s���ł��v</summary>
        private const string MSG_ED_INPUTDATE_ERROR = "�I�����͓����s���ł��B";
        /// <summary>�N���A�m�F���b�Z�[�W�u�\�����e�����������Ă�낵���ł����H�v</summary>
        private const string MSG_CONFIRM_CLEARINPUT = "�\�����e�����������Ă�낵���ł����H";

        /// <summary>���s�m�F�p���b�Z�[�W�u�`�[���Ĕ��s���Ă�낵���ł����v</summary>
        private const string MSG_CONFIRM_PRINTDISP = "�`�[���Ĕ��s���Ă�낵���ł����H";

        #endregion // ���b�Z�[�W�萔   
   
        #endregion // Private Const

        #region �e��ݒ�l

        /// <summary>���׃O���b�h �I���s�J���[(�O���f�[�V����color1)</summary>
        private readonly Color _selectedRowBackColor_Detail = Color.FromArgb(253, 235, 216);

        /// <summary>���׃O���b�h �I���s�J���[(�O���f�[�V����color2)</summary>
        private readonly Color _selectedRowBackColor2_Detail = Color.FromArgb(218, 144, 101);

        #endregion // �e��ݒ�l

        #endregion // �v���C�x�[�g�ϐ�

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }

        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        public enum OperationCode : int
        {
            /// <summary>�e�L�X�g�o��</summary>
            TextOut = 1,
            /// <summary>�G�N�Z���o��</summary>
            ExcelOut = 2,
            /// <summary>�Ĕ��s</summary>
            ReissueSlip = 3
        }
        #endregion

        # region �\����
        # region [�O��l�ێ�]
        /// <summary>
        /// �O��l�ێ�
        /// </summary>
        private struct PrevInputValue
        {
            /// <summary>���͋��_�R�[�h</summary>
            private string _inputSectionCode;
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode;
            /// <summary>�q�ɃR�[�h</summary>
            private string _warehouseCode;

            /// <summary>
            /// ���͋��_�R�[�h
            /// </summary>
            public string InputSectionCode
            {
                get { return _inputSectionCode; }
                set { _inputSectionCode = value; }
            }
            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// �q�ɃR�[�h
            /// </summary>
            public string WarehouseCode
            {
                get { return _warehouseCode; }
                set { _warehouseCode = value; }
            }

        }
        # endregion
        # endregion

        #region �v���p�e�B

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMZAI04600U", this);
                }
                return _operationAuthority;
            }
        }
        /// <summary>���쌠���̐��䃊�X�g</summary>
        private Dictionary<OperationCode, bool> OpeAuthDictionary
        {
            get
            {
                if (_operationAuthorityList == null)
                {
                    _operationAuthorityList = new Dictionary<OperationCode, bool>();
                    _operationAuthorityList.Add(OperationCode.TextOut, !MyOpeCtrl.Disabled((int)OperationCode.TextOut));
                    _operationAuthorityList.Add(OperationCode.ExcelOut, !MyOpeCtrl.Disabled((int)OperationCode.ExcelOut));
                }
                return _operationAuthorityList;
            }
        }

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public PMZAI04601UA()
        {
            InitializeComponent();

            // �ݒ�t�H�[������
            _settingForm = new PMZAI04604UA();
            _settingForm.ClearSettingStockMoveGrid += new EventHandler(SettingForm_ClearSettingStockMoveGrid);

            // �ݒ�ǂݍ���
            _settingForm.Deserialize();

            // �O���b�h���̌����Z���ݒ�
            _margedCellAppearance = new Infragistics.Win.Appearance();
            _margedCellAppearance.BackColor = Color.Lavender;
            _margedCellAppearance.BackColorAlpha = Alpha.Opaque;
            _margedCellAppearance.ForeColor = Color.Black;

            // tRetKeyControl
            // �O���b�h����Return�L�[�������̏��������������Circulate=true�ɂ���B
            tRetKeyControl.Circulate = true;

            _gridColumnChooserControl = new GridColumnChooserControl();

            #region ���I�v�V�������
            this.CacheOptionInfo();
            #endregion
        }

        /// <summary>
        /// �Ăяo�����v���O����ID���݂̃R���X�g���N�^
        /// </summary>
        /// <param name="invokerPgId">�Ăяo�����v���O����ID</param>
        /// <remarks>
        /// <br>Note       : �Ăяo�����v���O����ID���݂̃R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public PMZAI04601UA(string invokerPgId)
        {
            InitializeComponent();

            // �v���C�x�[�g���x����PGID��ۑ�
            this._invokerPgId = invokerPgId;

            // �ݒ�t�H�[������
            _settingForm = new PMZAI04604UA();

            // �ݒ�ǂݍ���
            _settingForm.Deserialize();

            // �O���b�h���̌����Z���ݒ�
            _margedCellAppearance = new Infragistics.Win.Appearance();
            _margedCellAppearance.BackColor = Color.Lavender;
            _margedCellAppearance.BackColorAlpha = Alpha.Opaque;
            _margedCellAppearance.ForeColor = Color.Black;

            // tRetKeyControl
            // �O���b�h����Return�L�[�������̏��������������Circulate=true�ɂ���B
            tRetKeyControl.Circulate = true;

        }

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�֐�

        /// <summary>Form.Load �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : Form.Load �C�x���g�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04601UA_Load(object sender, System.EventArgs e)
        {
            // �O���b�h�J�����T�C�Y���������`�F�b�N�̕���
            # region [�O���b�h�J�����T�C�Y���������̕���]
            _columnWidthAutoAdjust = _settingForm.UserSetting.AutoAdjustStockMove;
            # endregion
            // �ϐ��Ȃǂ�������
            InitializeVariable();

            // �O���[�v�W�J��Ԃ̕���
            # region [�O���[�v�W�J��Ԃ̕���]
            uExGroupBox_BalanceChart.Expanded = _settingForm.UserSetting.BalanceChartExpanded;
            uExGroupBox_ExtraCondition.Expanded = _settingForm.UserSetting.ExtraConditionExpanded;
            # endregion

            // �ڍ׏����̕���
            # region [�O��g�p���̏ڍ׏����𕜌�]

            if (_settingForm.UserSetting.EnabledCommonConditionList != null)
            {
                // ��{�����̃`�F�b�N��Ԃ̕���
                this._checkCount = 0;
                foreach (Control control in panel_Base.Controls)
                {
                    if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                    {
                        // �u�Q�F�o�׊m��Ȃ��v����u1�F�o�׊m�肠��v�֕ύX����ꍇ
                        if (this._stockMoveFixCode == 1)
                        {
                            if (this._checkCount > 3)
                            {
                                // �`�F�b�N���t���Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
                                if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
                                {
                                    string controlName = control.Name.Replace("_base", "");
                                    foreach (Control controlSelect in panel_SelectItem.Controls)
                                    {
                                        if (controlSelect is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                                        {
                                            if (controlName.Equals(controlSelect.Name))
                                            {
                                                // ���X�g�ɖ��O������΁A�`�F�b�N����
                                                (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
                                                // ���X�g�ɖ��O������΁AEnable����
                                                (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                                }
                                continue;
                            }
                        }

                        // �`�F�b�N���t���Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
                        if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
                        {
                            //�Q�F�o�׊m��Ȃ��̏ꍇ
                            if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag_base".Equals(control.Name))
                            {
                                // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
                                continue;
                            }
                            else
                            {
                                // ���X�g�ɖ��O������΁A�`�F�b�N����
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
                                this._checkCount++;
                            }
                        }
                        else
                        {
                            // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
                            (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                        }
                    }
                }
            }

            if (_settingForm.UserSetting.EnabledConditionList != null)
            {
                // �`�F�b�N��Ԃ̕���
                foreach (Control control in panel_SelectItem.Controls)
                {
                    if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                    {

                        // �`�F�b�N���t���Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
                        if (_settingForm.UserSetting.EnabledConditionList.Contains(control.Name))
                        {
                            //�Q�F�o�׊m��Ȃ��̏ꍇ
                            if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag".Equals(control.Name))
                            {
                                // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                            }
                            else
                            {
                                // ���X�g�ɖ��O������΁A�`�F�b�N����
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
                            }
                        }
                        else
                        {
                            // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
                            (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                        }
                        if (_settingForm.UserSetting.EnabledList != null)
                        {
                            // �`�F�b�N��Enable�Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
                            if (_settingForm.UserSetting.EnabledList.Contains(control.Name))
                            {
                                if (this._stockMoveFixCode == 1 && "uCheckArrivalGoodsFlag".Equals(control.Name) && !this.uCheckArrivalGoodsFlag_base.Checked)
                                {
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
                                }
                                else
                                {
                                // ���X�g�ɖ��O������΁AEnable����
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = false;
                                }
                            }
                            else
                            {
                                //�Q�F�o�׊m��Ȃ��̏ꍇ
                                if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag".Equals(control.Name))
                                {
                                    // ���O���Ȃ���΁AEnable���Ȃ�
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = false;
                                }
                                else
                                {
                                    // ���O���Ȃ���΁AEnable���Ȃ�
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            //if (_settingForm.UserSetting.EnabledCommonConditionList != null)
            //{
            //    // ��{�����̃`�F�b�N��Ԃ̕���
            //    this._checkCount = 0;
            //    foreach (Control control in panel_Base.Controls)
            //    {
            //        if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
            //        {
            //            // �u�Q�F�o�׊m��Ȃ��v����u1�F�o�׊m�肠��v�֕ύX����ꍇ
            //            if (this._stockMoveFixCode == 1)
            //            {
            //                if (this._checkCount > 3)
            //                {
            //                    // �`�F�b�N���t���Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
            //                    if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
            //                    {
            //                        string controlName = control.Name.Replace("_base", "");
            //                        foreach (Control controlSelect in panel_SelectItem.Controls)
            //                        {
            //                            if (controlSelect is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
            //                            {
            //                                if (controlName.Equals(controlSelect.Name))
            //                                {
            //                                    // ���X�g�ɖ��O������΁A�`�F�b�N����
            //                                    (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
            //                                    // ���X�g�ɖ��O������΁AEnable����
            //                                    (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
            //                                }
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
            //                        (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
            //                    }
            //                    continue;
            //                }
            //            }
                        
            //            // �`�F�b�N���t���Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
            //            if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
            //            {
            //                //�Q�F�o�׊m��Ȃ��̏ꍇ
            //                if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag_base".Equals(control.Name))
            //                {
            //                    // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    continue;
            //                }
            //                else
            //                {
            //                    // ���X�g�ɖ��O������΁A�`�F�b�N����
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    this._checkCount++;
            //                }
            //            }
            //            else
            //            {
            //                // ���O���Ȃ���΁A�`�F�b�N���Ȃ�
            //                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
            //            }
            //        }
            //    }
            //}
            // �\�����e�ɔ��f
            if ((_settingForm.UserSetting.EnabledCommonConditionList != null) || (_settingForm.UserSetting.EnabledConditionList != null))
            {
                ultraDockManager_PaneHidden(sender, null);
            }

            # endregion

            // �O���b�h�J�������̕���
            # region [�O���b�h�J�������̕���]
            this.LoadGridColumnsSetting(ref uGrid_StockMove, _settingForm.UserSetting.StockMoveColumnsList);
            # endregion

            // �ݒ�t�H�[���ւ̃J�����ꗗ�n��
            _settingForm.SlipColCollection = uGrid_StockMove.DisplayLayout.Bands[0].Columns;

            // �O���b�h�J��������
            _stockMoveGridColPosCtrl = new GridColPosFixController(uGrid_StockMove);

            // ��ʂ��g�p�\��
            this.Enabled = true;

            // �c�[���o�[�����ݒ菈��
            ToolbarManagerCustomizeSettingAcs.LoadToolManagerCustomizeInfo(ctAssemblyName, ref this.tToolbarsManager);

            // �u�񎩓������v�`�F�b�N�Ɋւ��鏉����Ԃ̍X�V�ׁ̈ACheckedChanged�C�x���g�ł̏��������s
            uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(null, null);

            //�o�͋敪
            if (this.tComboEditor_OutputDiv.Visible)
            {
                this.tComboEditor_OutputDiv.SelectedIndex = _settingForm.UserSetting.OutPutDiv;
            }

            // �`�[�敪
            if (this.tComboEditor_SalesSlipDiv.Visible)
            {
                this.tComboEditor_SalesSlipDiv.SelectedIndex = _settingForm.UserSetting.SalesSlipDiv;
            }
        }

        /// <summary>
        /// �t�H�[���\����̏���(�����t�H�[�J�X�̃Z�b�g)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H�[���\����̏���(�����t�H�[�J�X�̃Z�b�g)�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        void PMZAI04601UA_Shown(object sender, System.EventArgs e)
        {
            if (_stockMngTtlSt == null) Close();

            // �����t�H�[�J�X(�o�͋敪�܂��͓`�[�敪)
            if (this._stockMoveFixCode == 1) {
                this.tEdit_WarehouseCd.Focus();
            }
            else if (this._stockMoveFixCode == 2)
            {
                this.tEdit_InputSectionCode.Focus();
            }
            this._initFlg = false;
        }

        /// <summary>
        /// �t�H�[���N���[�W���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���[�W���O�C�x���g�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04601UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory;
            //����ݒ���̕ۑ�(�v���O�����I�����Ɏ���)
            ToolbarManagerCustomizeSettingAcs.SaveToolManagerCustomizeInfo(ctAssemblyName, this.tToolbarsManager);
        }

        /// <summary>
        /// �v���C�x�[�g���x���̕ϐ��Ȃǂ�����������я����擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���C�x�[�g���x���̕ϐ��Ȃǂ�����������я����擾�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeVariable()
        {
            int status;

            #region �Z�b�V���������l�擾

            // �A�v���P�[�V�����ɕK�v�ƂȂ�l��ݒ肷��
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �����_�R�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            // ���O�C�����[�U�[�R�[�h
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;

            // ���O�C�����[�U�[��
            this._loginUserName = LoginInfoAcquisition.Employee.Name;

            #endregion // �Z�b�V���������l�擾

            #region �A�N�Z�X�N���X������

            // �A�N�Z�X�N���X��������
            this._stockMngTglStAcs = new StockMngTtlStAcs();

            //this._customerInfoAcs = new CustomerInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();

            this._employeeAcs = new EmployeeAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._supplierAcs = new SupplierAcs();

            this._noteGuidAcs = new NoteGuidAcs();

            #endregion // �A�N�Z�X�N���X������

            // �����_��
            SecInfoSet secInfoSet;
            _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode.Trim());
            this._loginSectionName = secInfoSet.SectionGuideNm;

            //// ���������N���X��������
            this._stockMovePpr = new StockMovePpr();

            //// �O�񌟍������o�����N���X
            this._stockMovePprBackUp = null;

            //--------------------------
            // ��ʂ̃Z�b�e�B���O
            //--------------------------

            #region �{�^���C���[�W�ݒ�

            // �C���[�W���X�g���w��(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // �{�^���C���[�W��ݒ�
            // ���ʕ���
            this.uButton_InputSectionGuide.ImageList = this._imageList16;
            this.uButton_InputSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SecGuide.ImageList = this._imageList16;
            this.uButton_SecGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SalesEmployeeCd.ImageList = this._imageList16;
            this.uButton_SalesEmployeeCd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SupplierCd.ImageList = this._imageList16;
            this.uButton_SupplierCd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_MakerCd.ImageList = this._imageList16;
            this.uButton_MakerCd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_BlGoodsCode.ImageList = this._imageList16;
            this.uButton_BlGoodsCode.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_AfSectionCode.ImageList = this._imageList16;
            this.uButton_AfSectionCode.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_AfEnterWarehCode.ImageList = this._imageList16;
            this.uButton_AfEnterWarehCode.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SlipNote.ImageList = this._imageList16;
            this.uButton_SlipNote.Appearance.Image = (int)Size16_Index.STAR1;

            this.tToolbarsManager.ImageListSmall = this._imageList16;
            this.tToolbarsManager.Tools["LabelTool_RowSearchTitle"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            this.tToolbarsManager.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            this.tToolbarsManager.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;

            this.tToolbarsManager.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;

            this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SLIP;
            this.tToolbarsManager.Tools["ButtonTool_Configuration"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SETUP1;
            this.tToolbarsManager.Tools["ButtonTool_RowSelect"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DETAILS;

            this.tToolbarsManager.Tools["ButtonTool_SalesSlipSelect"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager.Tools["ButtonTool_CommonCondition"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.INDICATIONCHANGE;
            this.tToolbarsManager.Tools["ButtonTool_ExtraCondition"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.INDICATIONCHANGE;
            this.tToolbarsManager.Tools["ButtonTool_TotalShow"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.INDICATIONCHANGE;

            #endregion // �{�^���C���[�W�ݒ�

            // �S�Ă̏ڍ׌����������\���ɂ��A�g�����������̊g���\�O���[�v�{�b�N�X��s����
            SetAllDetailSearchCondition2Hidden();
            this.uExGroupBox_ExtraCondition.Visible = false;

            #region �݌ɊǗ��S�̐ݒ�擾

            // �݌ɊǗ��S�̐ݒ���擾
            ArrayList retList;

            status = this._stockMngTglStAcs.Search(out retList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �݌ɊǗ��S�̐ݒ�
                # region [�݌ɊǗ��S�̐ݒ� �擾]
                _stockMngTtlSt = null;
                StockMngTtlSt allStockMngTtlSt = null;
                status = this._stockMngTglStAcs.Search(out retList, this._enterpriseCode);
                foreach (StockMngTtlSt tockMngTtlSt in retList)
                {
                    if (tockMngTtlSt.SectionCode.Trim() == this._loginSectionCode.Trim())
                    {
                        // ���_�ʐݒ�
                        _stockMngTtlSt = tockMngTtlSt;
                        break;
                    }
                    else if (tockMngTtlSt.SectionCode.Trim() == string.Empty || tockMngTtlSt.SectionCode.Trim() == "00")
                    {
                        // �S�Аݒ�
                        allStockMngTtlSt = tockMngTtlSt;
                        continue;
                    }
                }
                // ���_�ʐݒ肪������ΑS�Аݒ���g�p
                if (_stockMngTtlSt == null)
                {
                    _stockMngTtlSt = allStockMngTtlSt;
                }
                # endregion

                // ���_�ʐݒ���S�Аݒ��������ΏI��
                if (_stockMngTtlSt == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�݌ɊǗ��S�̐ݒ�}�X�^�̓o�^���s���ĉ������B",
                        status, MessageBoxButtons.OK);
                    this.timer_Close.Enabled = true;
                    return;
                }

                this._stockMoveFixCode = _stockMngTtlSt.StockMoveFixCode;

                // �݌ɊǗ��S�̐ݒ�ɂ�鍀�ڕ\���E��\���ݒ�
                # region [�\���E��\���ݒ�]
                // �݌Ɉړ��m��敪
                switch (_stockMngTtlSt.StockMoveFixCode)
                {
                    // 1�F�o�׊m�肠��A�Q�F�o�׊m��Ȃ� 
                    case 1:
                        {
                            #region ��{�����̕\���E��\���ݒ�
                            // ��{�����̕\���E��\���ݒ�
                            this.uLabel_SalesSlipDiv.Visible = false;
                            this.tComboEditor_SalesSlipDiv.Visible = false;

                            this.uLabel_InputSectionCodeTitle.Visible = false;
                            this.tEdit_InputSectionCode.Visible = false;
                            this.ultraLabel_InputSectionName.Visible = false;
                            this.uButton_InputSectionGuide.Visible = false;

                            this.uLabel_SecCd.Location = new Point(this.uLabel_SecCd.Location.X, this.uLabel_SecCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.tEdit_SecCd.Location = new Point(this.tEdit_SecCd.Location.X, this.tEdit_SecCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.ultraLabel_SecName.Location = new Point(this.ultraLabel_SecName.Location.X, this.ultraLabel_SecName.Location.Y - CT_INTERVAL_HEIGHT);
                            this.uButton_SecGuide.Location = new Point(this.uButton_SecGuide.Location.X, this.uButton_SecGuide.Location.Y - CT_INTERVAL_HEIGHT);

                            this.uLabel_WarehouseCd.Location = new Point(this.uLabel_WarehouseCd.Location.X, this.uLabel_WarehouseCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.tEdit_WarehouseCd.Location = new Point(this.tEdit_WarehouseCd.Location.X, this.tEdit_WarehouseCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.ultraLabel_WarehouseName.Location = new Point(this.ultraLabel_WarehouseName.Location.X, this.ultraLabel_WarehouseName.Location.Y - CT_INTERVAL_HEIGHT);
                            this.uButton_WarehouseGuide.Location = new Point(this.uButton_WarehouseGuide.Location.X, this.uButton_WarehouseGuide.Location.Y - CT_INTERVAL_HEIGHT);
                            this.uExGroupBox_CommonCondition.Size = new Size(this.uExGroupBox_CommonCondition.Size.Width, this.uExGroupBox_CommonCondition.Size.Height - CT_INTERVAL_HEIGHT);

                            #endregion

                            break;
                        }
                    case 2:
                        {
                            #region ��{�����̕\���E��\���ݒ�
                            // ��{�����̕\���E��\���ݒ�
                            this.uLabel_OutputDiv.Visible = false;
                            this.tComboEditor_OutputDiv.Visible = false;
                            this.uLabel_SalesSlipDiv.Location = this.uLabel_OutputDiv.Location;
                            this.tComboEditor_SalesSlipDiv.Location = this.tComboEditor_OutputDiv.Location;

                            this.uLabel_SecCd.Visible = false;
                            this.tEdit_SecCd.Enabled = false;
                            this.ultraLabel_SecName.Enabled = false;
                            this.uButton_SecGuide.Enabled = false;
                            this.tEdit_SecCd.Clear();
                            this.ultraLabel_SecName.Text = string.Empty;

                            this.uLabel_WarehouseCd.Visible = false;
                            this.tEdit_WarehouseCd.Enabled = false;
                            this.ultraLabel_WarehouseName.Enabled = false;
                            this.uButton_WarehouseGuide.Enabled = false;

                            this.uLabel_DateTitle.Text = "�`�[���t";

                            // �I��
                            this.tEdit_WarehouseShelfNo.Enabled = false;
                            this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = false;

                            // ���苒�_
                            this.tEdit_AfSectionCode.Enabled = false;
                            this.uButton_AfSectionCode.Enabled = false;

                            // ����q��
                            this.tEdit_AfEnterWarehCode.Enabled = false;
                            this.uButton_AfEnterWarehCode.Enabled = false;

                            #endregion

                            #region ���v�̕\���E��\���ݒ�
                            // ���v�̕\���E��\���ݒ�
                            this.uLabel_LeftTitle1.Text = "�o��";
                            this.uLabel_LeftTitle2.Text = "����";
                            this.uLabel_LeftTitle3.Visible = false;
                            this.uLabel_Count3.Visible = false;
                            this.uLabel_Money3.Visible = false;
                            this.uLabel_Cost3.Visible = false;
                            this.tLine11.Visible = false;

                            this.tLine23.Height = this.tLine23.Height - 24;
                            this.tLine24.Height = this.tLine24.Height - 24;
                            this.tLine25.Height = this.tLine25.Height - 24;
                            this.tLine26.Height = this.tLine26.Height - 24;
                            this.tLine34.Height = this.tLine34.Height - 24;

                            // �u��{�����E���o�����I����ʁv�̕\���E��\���ݒ�
                            this.uCheckArrivalGoodsFlag_base.Visible = false;
                            this.uCheckDeleteFlag_base.Location = this.uCheckNote_base.Location;
                            this.uCheckNote_base.Location = this.uCheckArrivalGoodsFlag_base.Location;

                            this.uCheckArrivalGoodsFlag.Visible = false;
                            this.uCheckDeleteFlag.Location = this.uCheckNote.Location;
                            this.uCheckNote.Location = this.uCheckArrivalGoodsFlag.Location;
                            #endregion

                            break;
                        }
                    default: break;
                }
                # endregion
            }
            else
            {
                if (_stockMngTtlSt == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�݌ɊǗ��S�̐ݒ�}�X�^�̓o�^���s���ĉ������B",
                        status, MessageBoxButtons.OK);
                    this.timer_Close.Enabled = true;
                    return;
                }
            }

            #endregion // �݌ɊǗ��S�̐ݒ�擾

            #region ���ߓ��擾

            // ���t�擾���i
            _dateGetAcs = DateGetAcs.GetInstance();

            _tCalcAcs = TotalDayCalculator.GetInstance();

            #endregion // ���ߓ��擾

            // �A�N�Z�X�N���X�����������A�f�[�^�Z�b�g���擾
            this._stockMoveSlipSearchAcs = new StockMoveSlipSearchAcs();

            this._stockMoveDataSet = this._stockMoveSlipSearchAcs.DataSet;

            // �O���b�h���Ɏg�p����f�[�^�r���[���쐬

            DataView dViewStockMove = new DataView(this._stockMoveDataSet.StockMoveDetail);

            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_StockMove.DataSource = dViewStockMove;

            // �O���b�h���쐬
            // �O���b�h�񏉊��ݒ菈��
            InitializeGridColumns(this.uGrid_StockMove.DisplayLayout.Bands[0].Columns);

            // �S�ẴO���b�h�̎�������
            autoColumnAdjust(this._columnWidthAutoAdjust);
            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = this._columnWidthAutoAdjust;

            // �s�I���{�^��OFF
            this.tToolbarsManager.Tools["ButtonTool_RowSelect"].SharedProps.Enabled = false;

            // �X�L�������[�h
            this._controlScreenSkin = new ControlScreenSkin();
            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExGroupBox_CommonCondition.Name);
            controlNameList.Add(this.uExGroupBox_ExtraCondition.Name);
            controlNameList.Add(this.uExGroupBox_BalanceChart.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �����T�C�Y�ݒ�
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }

            this.tComboEditor_StatusBar_FontSize.Text = CT_DEF_FONT_SIZE.ToString();

            // ���O�C������\��
            this.tToolbarsManager.Tools["LabelTool_LoginCharge"].SharedProps.Caption = this._loginUserName;


            // �d����d�q��������Ăяo���ꂽ�ꍇ�́A�d����d�q�����ւ̃����N���폜
            if (this._invokerPgId.Equals(CT_SUPPLIER_ERECNOTE_PGID))
            {
                this.tToolbarsManager.Tools["ButtonTool_W_SuppPrtPprRef"].SharedProps.Visible = false;
            }

            // ������
            ClearInputProc();
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����������ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearInputProc()
        {
            int status;

            // �����擾�O��������
            status = _tCalcAcs.InitializeHisMonthlyAccRec();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���񂨂�ёO��̒��ߓ�/�����擾(���Ɠ��͈قȂ�ꍇ������)
                status = _tCalcAcs.GetHisTotalDayMonthlyAccRec(this._loginSectionCode, out this._prevTotalDay, out this._currentTotalDay, out this._prevTotalMonth, out this._currentTotalMonth);

                if (_prevTotalDay == DateTime.MinValue)
                {
                    DateTime today = DateTime.Today;
                    this.tDateEdit_DateSt.SetDateTime(today);
                    this.tDateEdit_DateEd.SetDateTime(today);
                }
                else
                {
                    this.tDateEdit_DateSt.SetDateTime(this._prevTotalDay.AddDays(1));
                    this.tDateEdit_DateEd.SetDateTime(DateTime.Today);
                    if (this._prevTotalDay.AddDays(1) > DateTime.Today)
                    {
                        this.tDateEdit_DateEd.SetDateTime(this._prevTotalDay.AddDays(1));
                    }
                }
            }
            else
            {
                // �����������s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_TOTALDAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
            }

            setToolbarSearchSurface();

            ClearAllField();

            // �����_��
            SecInfoSet secInfoSet;
            _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode.Trim());
            this._loginSectionName = secInfoSet.SectionGuideNm;

            if (this._stockMoveFixCode == 1) // 1�F�o�׊m�肠��
            {
                if (this._initFlg)
                {
                    this.tComboEditor_OutputDiv.SelectedIndex = 0;
                }
                this.tEdit_SecCd.Text = this._loginSectionCode.Trim();
                this.ultraLabel_SecName.Text = this._loginSectionName.Trim();
                this.tEdit_WarehouseCd.Text = string.Empty;
                this.ultraLabel_WarehouseName.Text = string.Empty;

                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
            }
            else if (this._stockMoveFixCode == 2) // �Q�F�o�׊m��Ȃ� 
            {
                if (this._initFlg)
                {
                    this.tComboEditor_SalesSlipDiv.SelectedIndex = 0;
                }
                this.tEdit_InputSectionCode.Text = this._loginSectionCode.Trim();
                this.ultraLabel_InputSectionName.Text = this._loginSectionName.Trim();
                this.tEdit_SecCd.Text = string.Empty;
                this.ultraLabel_SecName.Text = string.Empty;
                this.tEdit_WarehouseCd.Text = string.Empty;
                this.ultraLabel_WarehouseName.Text = string.Empty;
            }

            // �O����͒l�ێ��p
            _prevInputValue = new PrevInputValue();

            // �O��l�Ƃ��Ă̏����l�Z�b�g
            _prevInputValue.InputSectionCode = this.tEdit_InputSectionCode.Text.Trim();
            _prevInputValue.SectionCode = this.tEdit_SecCd.Text.Trim();
            _prevInputValue.WarehouseCode = this.tEdit_WarehouseCd.Text.Trim();
            
            // �f�[�^�Z�b�g���N���A
            this._stockMovePprBackUp = null;

            adjustButtonEnable();
        }

        /// <summary>
        /// �o�͋敪�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �o�͋敪�ύX�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_OutputDiv_ValueChanged(object sender, EventArgs e)
        {
            // �o�͋敪
            switch ((int)this.tComboEditor_OutputDiv.Value)
            {
                case 0: // �o�ו�
                    {
                        this.uLabel_SecCd.Text = "�o�ɋ��_";
                        this.uLabel_WarehouseCd.Text = "�o�ɑq��";
                        this.uLabel_DateTitle.Text = "�o�ד�";

                        // ���׋敪����:��
                        this.tComboEditor_ArrivalGoodsFlag.SelectedIndex = 0;
                        this.tComboEditor_ArrivalGoodsFlag.Enabled = true;
                        break;
                    }
                case 1: // ���׍ϕ�
                    {
                        this.uLabel_SecCd.Text = "���ɋ��_";
                        this.uLabel_WarehouseCd.Text = "���ɑq��";
                        this.uLabel_DateTitle.Text = "���ד�";

                        // ���׋敪����:�s��
                        this.tComboEditor_ArrivalGoodsFlag.SelectedIndex = 1;
                        this.tComboEditor_ArrivalGoodsFlag.Enabled = false;
                        break;
                    }
                case 2: // �����ו�
                    {
                        this.uLabel_SecCd.Text = "���ɋ��_";
                        this.uLabel_WarehouseCd.Text = "���ɑq��";
                        this.uLabel_DateTitle.Text = "�o�ד�";

                        // ���׋敪����:�s��
                        this.tComboEditor_ArrivalGoodsFlag.SelectedIndex = 2;
                        this.tComboEditor_ArrivalGoodsFlag.Enabled = false;
                        break;
                    }
                default: break;
            }
            if (this._stockMoveFixCode == 1 && this._stockMoveDataSet.StockMoveDetail.Rows.Count == 0)
            {
                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
            }
        }

        /// <summary>
        /// �`�[�敪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �`�[�敪�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_SalesSlipDiv_ValueChanged(object sender, EventArgs e)
        {
            // �`�[�敪
            switch ((int)this.tComboEditor_SalesSlipDiv.Value)
            {
                case 0: // �S��
                    {
                        this.uLabel_SecCd.Visible = false;
                        this.tEdit_SecCd.Enabled = false;
                        this.ultraLabel_SecName.Enabled = false;
                        this.uButton_SecGuide.Enabled = false;

                        this.tEdit_SecCd.Clear();
                        this.ultraLabel_SecName.Text = string.Empty;
                        this._prevInputValue.SectionCode = string.Empty;


                        this.uLabel_WarehouseCd.Visible = false;
                        this.tEdit_WarehouseCd.Enabled = false;
                        this.ultraLabel_WarehouseName.Enabled = false;
                        this.uButton_WarehouseGuide.Enabled = false;

                        this.tEdit_WarehouseCd.Clear();
                        this.ultraLabel_WarehouseName.Text = string.Empty;
                        this._prevInputValue.WarehouseCode = string.Empty;

                        // �I��
                        this.tEdit_WarehouseShelfNo.Clear();
                        this._srWarehouseShelfNo = string.Empty;
                        this.tEdit_WarehouseShelfNo.Enabled = false;
                        this.tComboEditor_WarehouseShelfNoFuzzy.SelectedIndex = 0;
                        this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = false;

                        // ���苒�_
                        this.tEdit_AfSectionCode.Clear();
                        //this._swAfSectionCode = 0; // DEL 2010/05/18
                        this._swAfSectionCode = string.Empty; // ADD 2010/05/18
                        this.tEdit_AfSectionCode.Enabled = false;
                        this.uButton_AfSectionCode.Enabled = false;

                        // ����q��
                        this.tEdit_AfEnterWarehCode.Clear();
                        this._swAfEnterWarehCode = string.Empty;
                        this.tEdit_AfEnterWarehCode.Enabled = false;
                        this.uButton_AfEnterWarehCode.Enabled = false;

                        break;
                    }
                case 1: // �o��
                    {
                        if (!this.uLabel_SecCd.Visible)
                        {
                            this.tEdit_SecCd.Text = "00";
                            this.ultraLabel_SecName.Text = "�S��";
                        }

                        this.uLabel_SecCd.Visible = true;

                        this.tEdit_SecCd.Enabled = true;
                        this.uButton_SecGuide.Enabled = true;


                        this.uLabel_WarehouseCd.Visible = true;

                        this.tEdit_WarehouseCd.Enabled = true;
                        this.uButton_WarehouseGuide.Enabled = true;

                        this.uLabel_SecCd.Text = "�o�ɋ��_";
                        this.uLabel_WarehouseCd.Text = "�o�ɑq��";

                        // �I��
                        this.tEdit_WarehouseShelfNo.Enabled = true;
                        this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = true;

                        // ���苒�_
                        this.tEdit_AfSectionCode.Enabled = true;
                        this.uButton_AfSectionCode.Enabled = true;

                        // ����q��
                        this.tEdit_AfEnterWarehCode.Enabled = true;
                        this.uButton_AfEnterWarehCode.Enabled = true;
                        
                        break;
                    }
                case 2: // ����
                    {
                        if (!this.uLabel_SecCd.Visible)
                        {
                            this.tEdit_SecCd.Text = "00";
                            this.ultraLabel_SecName.Text = "�S��";

                        }

                        this.uLabel_SecCd.Visible = true;

                        this.tEdit_SecCd.Enabled = true;
                        this.uButton_SecGuide.Enabled = true;


                        this.uLabel_WarehouseCd.Visible = true;

                        this.tEdit_WarehouseCd.Enabled = true;
                        this.uButton_WarehouseGuide.Enabled = true;

                        this.uLabel_SecCd.Text = "���ɋ��_";
                        this.uLabel_WarehouseCd.Text = "���ɑq��";

                        // �I��
                        this.tEdit_WarehouseShelfNo.Enabled = true;
                        this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = true;

                        // ���苒�_
                        this.tEdit_AfSectionCode.Enabled = true;
                        this.uButton_AfSectionCode.Enabled = true;

                        // ����q��
                        this.tEdit_AfEnterWarehCode.Enabled = true;
                        this.uButton_AfEnterWarehCode.Enabled = true;

                        break;
                    }
                default: break;
            }
        }

        #region �c�[���o�[

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region �I���{�^��
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                #endregion // �I���{�^��

                # region �N���A�{�^��
                case "ButtonTool_Clear":
                    {
                        this.ClearInput();
                        break;
                    }
                # endregion

                #region �����{�^��
                case "ButtonTool_Search":
                    // �����{�^��
                    {
                        _stockMovePprBackUp = null;
                        ChangeFocusEventArgs eArgs = null;
                        bool findFocusItem = false;
                        if (_nextControl == null
                            || _nextControl.Name == "tEdit_InputSectionCode"
                            || _nextControl.Name == "tEdit_SecCd"
                            || _nextControl.Name == "tEdit_WarehouseCd"
                            || _nextControl.Name == "tEdit_SalesEmployeeCd"
                            || _nextControl.Name == "tEdit_SupplierCd"
                            || _nextControl.Name == "tEdit_MakerCd"
                            || _nextControl.Name == "tEdit_BlGoodsCode"
                            || _nextControl.Name == "tEdit_AfSectionCode"
                            || _nextControl.Name == "tEdit_AfEnterWarehCode"
                            || _nextControl.Name == "tEdit_GoodsNo"
                            || _nextControl.Name == "tEdit_GoodsName"
                            || _nextControl.Name == "tEdit_WarehouseShelfNo"
                            || _nextControl.Name == "tEdit_SlipNote")
                        {
                            if (this.ultraExpandableGroupBoxPanel1.Visible)
                            {
                                foreach (Control control in this.ultraExpandableGroupBoxPanel1.Controls)
                                {
                                    if (control.ContainsFocus)
                                    {
                                        eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, control, control);
                                        findFocusItem = true;
                                        break;
                                    }
                                }
                            }
                            if (!findFocusItem && this.ultraExpandableGroupBoxPanel2.Visible)
                            {
                                foreach (Control control in this.ultraExpandableGroupBoxPanel2.Controls)
                                {
                                    if (control.ContainsFocus)
                                    {
                                        eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, control, control);
                                        break;
                                    }
                                }
                            }
                            if (eArgs != null)
                            {
                                this._doSearchFlg = false;
                                tArrowKeyControl_ChangeFocus(null, eArgs);
                                if (_isError == true)
                                {
                                    _isError = false;
                                    return;
                                }
                            }
                        }
                        Control errorControl = this.SearchOnChangeFocus(null);
                        // �G���[�R���g���[���Ɉړ�
                        if (errorControl != null)
                        {
                            errorControl.Focus();
                        }
                        break;
                    }
                #endregion // �����{�^��

                #region �`�[�I���{�^��
                case "ButtonTool_SalesSlipSelect":
                    {
                        this.stockMoveSlipSelectSetting();
                        break;
                    }
                #endregion

                #region ��{�����{�^��
                case "ButtonTool_CommonCondition":
                    {
                        this.commonConditionSetting();
                        break;
                    }
                #endregion

                #region ���o�����{�^��
                case "ButtonTool_ExtraCondition":
                    {
                        this.extraConditionSetting();
                        break;
                    }
                #endregion

                #region ���v�\���{�^��
                case "ButtonTool_TotalShow":
                    {
                        this.totalShowSetting();
                        break;
                    }
                #endregion

                #region �`�[�Ĕ��s�{�^��
                case "ButtonTool_ReissueSlip":
                    {
                        this.ReisssueSlip();
                        break;
                    }
                #endregion �`�[�Ĕ��s�{�^��

                #region �e�L�X�g�o��
                case "ButtonTool_ExtractText":
                    {
                        exportIntoTextFile();
                        break;
                    }
                #endregion // �e�L�X�g�o��

                #region EXCEL�o��
                case "ButtonTool_ExtractExcel":
                    {
                        exportIntoExcelData();
                        break;
                    }
                #endregion // EXCEL�o��

                #region �ݒ�{�^��
                case "ButtonTool_Configuration":
                    {
                        this.openSetting();
                        break;
                    }
                #endregion

                #region �s�����{�^��
                case "ButtonTool_RowSearchStart":
                    {
                        this.rowSearchStart();
                        break;
                    }
                #endregion // �s�����{�^��

                default: break;
            }

            _nextControl = null;
        }
        #endregion // �c�[���o�[

        #region �N���A
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃN���A�����ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearInput()
        {
            // �m�F�_�C�A���O
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_CLEARINPUT,
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // �`���~ ������
            this.SuspendLayout();
            try
            {
                // ���ʏ����O���[�v�������I�ɓW�J��Ԃɂ���
                uExGroupBox_CommonCondition.Expanded = true;

                // �����t�H�[�J�X(�o�͋敪�܂��͓`�[�敪)
                if (this._stockMoveFixCode == 1)
                {
                    this.tEdit_WarehouseCd.Focus();
                }
                else if (this._stockMoveFixCode == 2)
                {
                    this.tEdit_InputSectionCode.Focus();
                }

                // ������
                ClearInputProc();

                this._stockMovePpr = new StockMovePpr();

                // �ڍ׏����̃N���A
                this.ClearExtraConditions();

                this._stockMoveDataSet.StockMoveDetail.Clear();

                this.adjustButtonEnable();

            }
            finally
            {
                // �`��ĊJ ������
                this.ResumeLayout();
            }
        }
        #endregion // �N���A

        #region ����

        /// <summary>
        /// �t�H�[�J�X�ړ����̌�������
        /// </summary>
        /// <param name="prevControl"></param>
        /// <remarks>PM7���l�̑��쐫����������ׂ̏���</remarks>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ����̌��������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control SearchOnChangeFocus(Control prevControl)
        {
            Control nextControl = prevControl;

            // �������s
            Control errorControl = this.SearchSlipDetailList();
            if (errorControl != null)
            {
                nextControl = errorControl;
            }
            else
            {
                if (this.uGrid_StockMove.Rows.Count > 0)
                {
                    this.uGrid_StockMove.Focus();
                    uGrid_StockMove.Rows[0].Cells[0].Activate();
                    uGrid_StockMove.Rows[0].Cells[0].Selected = true;
                    return null;
                }
            }

            return nextControl;
        }

        #region ��ʁ����������N���X
        /// <summary>
        /// ��ʂ̒l�����������N���X�ɕۑ�
        /// </summary>
        /// <returns>����ɕϊ� true, �l���s�� false</returns>
        /// <br>Note       : �i�����͗�Enter�C�x���g</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool SetDisplaySearchConditionClass()
        {
            // �݌Ɉړ��m��敪
            this._stockMovePpr.StockMoveFixCode = this._stockMoveFixCode;

            // �������
            this._stockMovePpr.SearchCnt = DATA_COUNT_MAX + 1;

            // ��ƃR�[�h
            this._stockMovePpr.EnterpriseCode = this._enterpriseCode;

            // �o�͋敪
            this._stockMovePpr.OutputDiv = (int)this.tComboEditor_OutputDiv.SelectedIndex;

            // �`�[�敪
            this._stockMovePpr.SalesSlipDiv = (int)this.tComboEditor_SalesSlipDiv.SelectedIndex;

            // ���͋��_�R�[�h
            if (String.IsNullOrEmpty(this.tEdit_InputSectionCode.Text.Trim()) || this.tEdit_InputSectionCode.Text.Trim() == "00")
            {
                this._stockMovePpr.InputSectionCode = null;
            }
            else
            {
                this._stockMovePpr.InputSectionCode = this.tEdit_InputSectionCode.Text.Trim();
            }

            // ���_�R�[�h
            if (String.IsNullOrEmpty(this.tEdit_SecCd.Text.Trim()) || this.tEdit_SecCd.Text.Trim() == "00")
            {
                this._stockMovePpr.SectionCode = null;
            }
            else
            {
                this._stockMovePpr.SectionCode = this.tEdit_SecCd.Text.Trim();
            }

            // �q�ɃR�[�h
            this._stockMovePpr.WarehouseCode = this.tEdit_WarehouseCd.Text.Trim();

            // �J�n������t
            this._stockMovePpr.St_Date = this.tDateEdit_DateSt.GetDateTime();

            // �I��������t
            this._stockMovePpr.Ed_Date = this.tDateEdit_DateEd.GetDateTime();

            // �`�[�ԍ�
            this._stockMovePpr.SalesSlipNum = this.tEdit_StockMoveSlipNum.Text.Trim();

            // �J�n���͓��t
            this._stockMovePpr.St_AddUpADate = this.tDateEdit_AddUpADateSt.GetDateTime();

            // �I�����͓��t
            this._stockMovePpr.Ed_AddUpADate = this.tDateEdit_AddUpADateEd.GetDateTime();

            // �S����
            this._stockMovePpr.SalesEmployeeCd = this._swSalesEmployeeCd;

            // BL�R�[�h
            this._stockMovePpr.BLGoodsCode = this._swBLGoodsCode;

            // ���[�J�[�R�[�h
            this._stockMovePpr.GoodsMakerCd = this._swGoodsMakerCd;

            // �d����
            this._stockMovePpr.SupplierCd = this._swSupplierCd;

            // �i��
            this._stockMovePpr.GoodsName = _srGoodsName.Replace("*", "%");

            // �i��
            this._stockMovePpr.GoodsNo = _srGoodsNo.Replace("*", "%");

            // ���ה��l
            this._stockMovePpr.SlipNote = _srSlipNote.Replace("*", "%");

            // �I��
            this._stockMovePpr.WarehouseShelfNo = _srWarehouseShelfNo.Replace("*", "%");

            // ���苒�_
            //if (String.IsNullOrEmpty(this._swAfSectionCode.ToString()) || this._swAfSectionCode.ToString() == "0") // DEL 2010/05/18
            if (String.IsNullOrEmpty(this._swAfSectionCode)) // ADD 2010/05/18
            {
                this._stockMovePpr.AfSectionCode = null;
            }
            else
            {
                //this._stockMovePpr.AfSectionCode = this._swAfSectionCode.ToString(); // DEL 2010/05/18
                this._stockMovePpr.AfSectionCode = this._swAfSectionCode; // ADD 2010/05/18
            }

            // ����q��
            if (String.IsNullOrEmpty(this._swAfEnterWarehCode))
            {
                this._stockMovePpr.AfEnterWarehCode = null;
            }
            else
            {
                this._stockMovePpr.AfEnterWarehCode = this._swAfEnterWarehCode;
            }


            // ���׋敪
            this._stockMovePpr.ArrivalGoodsFlag = (int)this.tComboEditor_ArrivalGoodsFlag.SelectedIndex;

            // �폜�w��敪
            this._stockMovePpr.DeleteFlag = (int)this.tComboEditor_DeleteFlag.SelectedIndex;
            return true;
        }

        #endregion // ��ʁ����������N���X

        #region �������s����
        /// <summary>
        /// �������s����
        /// </summary>
        /// <returns>�G���[�R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �G���[�R���g���[���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control SearchSlipDetailList()
        {
            long dataCount = 0;
            _stockMoveSlipSearchAcs.ExtractCancelFlag = false;

            Control errorControl = null;

            int status = 0;

            // �K�{���̓`�F�b�N
            if (!CheckItemValues(out errorControl)) return errorControl;

            // ��ʏ�̍��ڂ���p�����[�^���쐬
            if (!SetDisplaySearchConditionClass())
            {
                return null;
            }

            if (CompareStockMovePpr(this._stockMovePpr, _stockMovePprBackUp))
            {
                return null;
            }
            // �폜�w��敪
            this._logicalDelDiv = (int)tComboEditor_DeleteFlag.SelectedItem.DataValue;

            // �s�I���{�^��OFF
            this.tToolbarsManager.Tools["ButtonTool_RowSelect"].SharedProps.Enabled = false;

            // �N���A
            this._stockMoveDataSet.StockMoveDetail.Clear();
            this._stockMoveDataSet.StockMoveTotal.Clear();

            if (this._stockMoveFixCode == 1)
            {
                if (this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden)
                {
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden = false;
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden = true;
                }
                else
                {
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
                }
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else if (this._stockMoveFixCode == 2)
            {
                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "�`�[���t";
            }

            _processingDialog = new SFCMN00299CA();
            SFCMN00299CA processingDialog = _processingDialog;
            try
            {
                processingDialog.Title = "���o����";
                processingDialog.Message = "���݁A�f�[�^���o���ł��B(ESC�Œ��f���܂�)";
                processingDialog.DispCancelButton = true;
                processingDialog.CancelButtonClick += new EventHandler(processingDialog_CancelButtonClick);
                processingDialog.Show((Form)this.Parent);
                // �p�����[�^�N���X���g���Č����J�n
                if (_stockMoveSlipSearchAcs.ExtractCancelFlag == false)
                {
                    status = this._stockMoveSlipSearchAcs.Search(this._stockMovePpr, this._logicalDelDiv, out dataCount);
                }
            }
            finally
            {
                processingDialog.Dispose();
            }

            SetGridCheckBoxEnabled();

            if (this._stockMoveDataSet.StockMoveTotal.Rows.Count > 0)
            {
                //--------------------
                // ���v�\���^�u
                //--------------------
                // �o��/�o�� ���v����
                uLabel_Count1.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ShipmentCount_TotalColumn.ColumnName]).ToString("#,##0.00;-#,##0.00;");

                // �o��/�o�� ���v���z
                uLabel_Money1.Text = ((long)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ShipmentPrice_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // �o��/�o�� ���v�W�����i
                uLabel_Cost1.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ShipmentListPriceFl_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // ���׍�/���� ���v����
                uLabel_Count2.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ArrivalCount_TotalColumn.ColumnName]).ToString("#,##0.00;-#,##0.00;");

                // ���׍�/���� ���v���z
                uLabel_Money2.Text = ((long)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ArrivalPrice_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // ���׍�/���� ���v�W�����i
                uLabel_Cost2.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ArrivalListPriceFl_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // ������ ���v����
                uLabel_Count3.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.NotArrivalCount_TotalColumn.ColumnName]).ToString("#,##0.00;-#,##0.00;");

                // ������ ���v���z
                uLabel_Money3.Text = ((long)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.NotArrivalPrice_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // ������ ���v�W�����i
                uLabel_Cost3.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.NotArrivalListPriceFl_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // �`�[����
                uLabel_SlipCount.Text = ((int)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.SlipCountColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // ���א�
                if (dataCount > DATA_COUNT_MAX)
                {
                    uLabel_DetailCount.Text = (((int)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.DetailCountColumn.ColumnName])).ToString("#,##0;-#,##0;");
                }
                else
                {
                    uLabel_DetailCount.Text = ((int)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.DetailCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                }

                if (this._stockMoveFixCode == 1)
                {
                    switch (this.tComboEditor_OutputDiv.SelectedIndex)
                    {
                        case 0:
                            {
                                this.uLabel_Count2.Text = string.Empty;
                                this.uLabel_Money2.Text = string.Empty;
                                this.uLabel_Cost2.Text = string.Empty;

                                this.uLabel_Count3.Text = string.Empty;
                                this.uLabel_Money3.Text = string.Empty;
                                this.uLabel_Cost3.Text = string.Empty;
                            }
                            break;
                        case 1:
                            {
                                this.uLabel_Count1.Text = string.Empty;
                                this.uLabel_Money1.Text = string.Empty;
                                this.uLabel_Cost1.Text = string.Empty;

                                this.uLabel_Count3.Text = string.Empty;
                                this.uLabel_Money3.Text = string.Empty;
                                this.uLabel_Cost3.Text = string.Empty;
                            }
                            break;
                        case 2:
                            {
                                this.uLabel_Count1.Text = string.Empty;
                                this.uLabel_Money1.Text = string.Empty;
                                this.uLabel_Cost1.Text = string.Empty;

                                this.uLabel_Count2.Text = string.Empty;
                                this.uLabel_Money2.Text = string.Empty;
                                this.uLabel_Cost2.Text = string.Empty;
                            }
                            break;
                    }
                }
                else if (this._stockMoveFixCode == 2)
                {
                    switch (this.tComboEditor_SalesSlipDiv.SelectedIndex)
                    {
                        case 0:
                            break;
                        case 1:
                            {
                                this.uLabel_Count2.Text = string.Empty;
                                this.uLabel_Money2.Text = string.Empty;
                                this.uLabel_Cost2.Text = string.Empty;
                            }
                            break;
                        case 2:
                            {
                                this.uLabel_Count1.Text = string.Empty;
                                this.uLabel_Money1.Text = string.Empty;
                                this.uLabel_Cost1.Text = string.Empty;
                            }
                            break;
                    }
                }
            }
            else
            {
                this.uLabel_Count1.Text = string.Empty;
                this.uLabel_Money1.Text = string.Empty;
                this.uLabel_Cost1.Text = string.Empty;

                this.uLabel_Count2.Text = string.Empty;
                this.uLabel_Money2.Text = string.Empty;
                this.uLabel_Cost2.Text = string.Empty;

                this.uLabel_Count3.Text = string.Empty;
                this.uLabel_Money3.Text = string.Empty;
                this.uLabel_Cost3.Text = string.Empty;

                this.uLabel_SlipCount.Text = string.Empty;
                this.uLabel_DetailCount.Text = string.Empty;
            }

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // �����ɍ����f�[�^�Ȃ�
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);
                //�O�񌟍������i�[
                this._stockMovePprBackUp = null;
                this._logicalDelDivBackUp = -1;
                //_clearFlg = true;
                if (this.tEdit_InputSectionCode.Visible)
                {
                    errorControl = this.tEdit_InputSectionCode;
                }
                else
                {
                    errorControl = this.tEdit_SecCd;
                }
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ����ȊO�̃X�e�[�^�X
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_FAILED2GET_SLIP_DATA, status, MessageBoxButtons.OK);

                if (this.tEdit_InputSectionCode.Visible)
                {
                    errorControl = this.tEdit_InputSectionCode;
                }
                else
                {
                    errorControl = this.tEdit_SecCd;
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ����I�����͖��בI���s�́u�I���v�Ɉړ�����
                if (uGrid_StockMove.Rows.Count > 0)
                {
                    // �݌Ɉړ��m��敪�����׊m�肠��
                    if (this._stockMoveFixCode == 1)
                    {
                        // �o�͋敪�����׍ϕ�
                        if (this._stockMovePpr.OutputDiv == 1)
                        {
                            this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "���ד�";
                        }
                        else
                        {
                            this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "�o�ד�";
                        }

                    }
                    // �݌Ɉړ��m��敪�����׊m��Ȃ�
                    else if (this._stockMoveFixCode == 2)
                    {
                        this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "�`�[���t";
                    }
                }

                //�O�񌟍������i�[
                this._stockMovePprBackUp = this._stockMovePpr.Clone();
                this._logicalDelDivBackUp = this._logicalDelDiv;
            }

            adjustButtonEnable();

            if (_stockMoveSlipSearchAcs.ExtractCancelFlag == true)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    "�����𒆒f���܂����B",
                    status, MessageBoxButtons.OK);

                if (this.tEdit_InputSectionCode.Visible)
                {
                    return this.tEdit_InputSectionCode;
                }
                else
                {
                    return this.tEdit_SecCd;
                }
            }
            else if (dataCount > DATA_COUNT_MAX)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    string.Format("�f�[�^������{0:#,##0}���𒴂��܂����B", DATA_COUNT_MAX),
                    status, MessageBoxButtons.OK);
            }
            _stockMoveSlipSearchAcs.ExtractCancelFlag = false;
            return errorControl;
        }
        #endregion // �������s����

        #region �K�{���ڃ`�F�b�N
        /// <summary>
        /// �K�{���ڃ`�F�b�N
        /// </summary>
        /// <param name="errorControl"></param>
        /// <returns>�K�{�����𖞂��� true, �ᔽ false</returns>
        /// <br>Note       : �K�{���ڃ`�F�b�N</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool CheckItemValues(out Control errorControl)
        {
            errorControl = null;
            DateGetAcs.CheckDateRangeResult cdrResult;

            //-----------------------------------------------------------
            // ���o�ד��i�J�n�`�I���j
            //-----------------------------------------------------------
            # region [���o�ד�]
            if (CheckDateRangeForSlip(ref tDateEdit_DateSt, ref tDateEdit_DateEd, out cdrResult, true) == false)
            {
                string errorMessage = string.Empty;
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        errorMessage = MSG_ST_SALESDATE_ERROR + this.uLabel_DateTitle.Text + MSG_SALESDATE_ERROR;
                        errorControl = tDateEdit_DateSt;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        errorMessage = MSG_ED_SALESDATE_ERROR + this.uLabel_DateTitle.Text + MSG_SALESDATE_ERROR;
                        errorControl = tDateEdit_DateEd;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        errorMessage = MSG_MUST_BE_CORRECT_CALENDER;
                        errorControl = tDateEdit_DateSt;
                        break;
                }

                if (errorMessage != string.Empty && errorControl != null)
                {
                    // ���b�Z�[�W�\��
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        errorMessage, -1, MessageBoxButtons.OK);

                    return false;
                }
            }
            # endregion

            //-----------------------------------------------------------
            // ���͓��i�J�n�`�I���j
            //-----------------------------------------------------------
            # region [���͓�]

            string errorMessage2 = string.Empty;

            if (CheckDateRangeForSlip(ref tDateEdit_AddUpADateSt, ref tDateEdit_AddUpADateEd, out cdrResult, true) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        errorMessage2 = MSG_ST_INPUTDATE_ERROR;
                        errorControl = tDateEdit_AddUpADateSt;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        errorMessage2 = MSG_ED_INPUTDATE_ERROR;
                        errorControl = tDateEdit_AddUpADateEd;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        errorMessage2 = MSG_MUST_BE_CORRECT_CALENDER;
                        errorControl = tDateEdit_AddUpADateSt;
                        break;
                }
            }
            if (errorMessage2 != string.Empty && errorControl != null)
            {
                // ���b�Z�[�W�\��
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    errorMessage2, -1, MessageBoxButtons.OK);

                return false;
            }
            # endregion

            // �S�Đ��펞�̂�true
            return true;
        }

        #endregion // �K�{���ڃ`�F�b�N

        #region ���f�{�^������
        /// <summary>
        /// ���f�{�^������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : ���t�͈̓`�F�b�N����</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void processingDialog_CancelButtonClick(object sender, EventArgs e)
        {
            // ���o�L�����Z��
            CancelExtract();
        }

        # region ���o�L�����Z������
        /// <summary>
        /// ���o�L�����Z��
        /// </summary>
        /// <br>Note       : ���o�L�����Z������</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void CancelExtract()
        {
            // ���o�L�����Z��
            _stockMoveSlipSearchAcs.ExtractCancelFlag = true;
            if (_processingDialog != null)
            {
                _processingDialog.Message = "���f���܂��B";
            }
        }
        # endregion // ���o�L�����Z������
        #endregion // ���f�{�^������
        #endregion ����

        #region �`�[�I��

        /// <summary>
        /// �`�[�I��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�[�I���ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void stockMoveSlipSelectSetting()
        {
            try
            {
                this.uGrid_StockMove.BeginUpdate();
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                string stockMoveSlipNo = string.Empty;
                DateTime date;
                int stockMoveFormalCd;
                if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                {
                    this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                }
                if (this.uGrid_StockMove.ActiveCell != null)
                {
                    gridRow = this.uGrid_StockMove.ActiveCell.Row;

                    stockMoveSlipNo = gridRow.Cells[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Value.ToString();
                    date = (DateTime)gridRow.Cells[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Value;
                    stockMoveFormalCd = (int)gridRow.Cells[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName].Value;
                    // ���ו\��DataTable�̃r���[�𐶐�
                    DataView detailView = new DataView(this._stockMoveDataSet.StockMoveDetail);
                    // (�t�B���^)
                    detailView.RowFilter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName, stockMoveSlipNo,
                                                            this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName, date,
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName, stockMoveFormalCd);
                    // (�\�[�g)
                    detailView.Sort = string.Format("{0},{1},{2}",
                                                            this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName,
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName,
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName);

                    if (detailView.Count > 0)
                    {
                        int rowNo = 0;
                        bool selectionCheckFlg = true;
                        foreach (DataRowView rowView in detailView)
                        {
                            // RowView�ɑΉ�����Row���擾
                            DataRow detailRow = rowView.Row;

                            // �s��I��
                            rowNo = Int32.Parse(detailRow["RowNo"].ToString());

                            // ���׍s��I��
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridDetailRow in this.uGrid_StockMove.Rows)
                            {
                                if (gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Hidden == false &&
                                    (int)gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].Value == rowNo &&
                                    gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value != DBNull.Value &&
                                    (bool)gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value == false)
                                {
                                    selectionCheckFlg = false;
                                    break;
                                }
                            }
                            if (!selectionCheckFlg) break;
                        }

                        foreach (DataRowView dataRowView in detailView)
                        {
                            // dataRowView�ɑΉ�����Row���擾
                            DataRow detailRow = dataRowView.Row;

                            // �s��I��
                            rowNo = Int32.Parse(detailRow["RowNo"].ToString());

                            // ���׍s��I��
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridDetailRow in this.uGrid_StockMove.Rows)
                            {
                                if (gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Hidden == false &&
                                    (int)gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].Value == rowNo &&
                                    gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value != DBNull.Value)
                                {
                                    // �`�[�̖��׍s���S���I�������ꍇ
                                    if (selectionCheckFlg)
                                    {
                                        this.RowSelectClicked(false, gridDetailRow);
                                    }
                                    else
                                    {
                                        this.RowSelectClicked(true, gridDetailRow);
                                    }
                                    
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                this.uGrid_StockMove.EndUpdate();
                // �O���b�h���X�V
                this.uGrid_StockMove.Refresh();
            }

        }
        #endregion

        #region ��{����
        /// <summary>
        /// ��{�����O���[�v�a�n�w�̓W�J�Ək����؂�ւ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��{�����O���[�v�a�n�w�̓W�J�Ək����؂�ւ���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void commonConditionSetting()
        {
            if (this.uExGroupBox_CommonCondition.Expanded)
            {
                this.uExGroupBox_CommonCondition.Expanded = false;
            }
            else
            {
                this.uExGroupBox_CommonCondition.Expanded = true;
            }
        }
        #endregion

        #region ���o����
        /// <summary>
        /// ���o�����O���[�v�a�n�w�̓W�J�Ək����؂�ւ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�����O���[�v�a�n�w�̓W�J�Ək����؂�ւ���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void extraConditionSetting()
        {
            if (this.uExGroupBox_ExtraCondition.Expanded)
            {
                this.uExGroupBox_ExtraCondition.Expanded = false;
            }
            else
            {
                this.uExGroupBox_ExtraCondition.Expanded = true;
            }
        }
        #endregion

        #region ���v�\��
        /// <summary>
        /// ���v�O���[�v�a�n�w�̓W�J�Ək����؂�ւ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���v�O���[�v�a�n�w�̓W�J�Ək����؂�ւ���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void totalShowSetting()
        {
            if (this.uExGroupBox_BalanceChart.Expanded)
            {
                // �k��
                this.uExGroupBox_BalanceChart.Expanded = false;
            }
            else
            {
                // �W�J
                this.uExGroupBox_BalanceChart.Expanded = true;
            }
        }
        #endregion

        #region �`�[�Ĕ��s

        /// <summary>
        /// �`�[�Ĕ��s
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�������f�[�^�A�`�[�Ĕ��s�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ReisssueSlip()
        {
            DataRow[] rows = this._stockMoveDataSet.StockMoveDetail.Select("SelectionCheck = true");
            // �`�[���I������Ă���ꍇ�̂�
            if (rows == null) return;
            if (rows.Length > 0)
            {
                // ��������
                DCCMN02000UA printDisp = new DCCMN02000UA(); // �`�[������ݒ��ʃC���X�^���X����
                StockMoveSlipPrintCndtn.StockMoveSlipKey key = new StockMoveSlipPrintCndtn.StockMoveSlipKey(); // �`�[����pKey�C���X�^���X����
                List<StockMoveSlipPrintCndtn.StockMoveSlipKey> keyList = new List<StockMoveSlipPrintCndtn.StockMoveSlipKey>(); // �`�[����pKeyList�C���X�^���X����

                // keyList���쐬����B
                foreach (DataRow row in rows)
                {
                    key = new StockMoveSlipPrintCndtn.StockMoveSlipKey();

                    // �ړ��`��
                    key.StockMoveFormal = (int)row[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName];
                    // �ړ��`�[�ԍ�
                    key.StockMoveSlipNo = (int)row[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName];
                    if (keyList.Count == 0 || !keyList.Contains(key))
                    {
                        keyList.Add(key);
                    }
                }

                // ������p�����[�^�Z�b�g
                StockMoveSlipPrintCndtn stockMoveSlipPrintCndtn = new StockMoveSlipPrintCndtn();
                stockMoveSlipPrintCndtn.EnterpriseCode = this._enterpriseCode;
                stockMoveSlipPrintCndtn.ReissueDiv = true; // �Ĕ��s=true
                stockMoveSlipPrintCndtn.StockMoveSlipKeyList = keyList;

                // �m�F�_�C�A���O
                if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_CONFIRM_PRINTDISP,
                    -1, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (keyList.Count > 0)
                {
                    printDisp.Print(stockMoveSlipPrintCndtn);
                }

                #region �^�u�`�F�b�N�폜
                string selectionColName = this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName;
                string rowNoColName = this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName;

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow salesDetailRow in this.uGrid_StockMove.Rows)
                {
                    if (salesDetailRow.Cells[selectionColName].Value != DBNull.Value && (bool)salesDetailRow.Cells[selectionColName].Value == true)
                    {
                        DataRow denRow = this._stockMoveDataSet.StockMoveDetail.Rows.Find((int)salesDetailRow.Cells[rowNoColName].Value);
                        denRow[selectionColName] = false;
                        this.RowBackColorChange(false, salesDetailRow);
                    }
                }

                this.uGrid_StockMove.Refresh();
                this.adjustButtonEnable();
                #endregion

            }
        }

        #endregion

        #region �e�L�X�g�o��

        /// <summary>
        /// �e�L�X�g�o��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�́B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void exportIntoTextFile()
        {
            PMZAI04604UA settingConstForm = this._settingForm;

            // �ݒ�I�u�W�F�N�g���擾
            this._userSetting = settingConstForm.UserSetting;
            string outputFileName = this._userSetting.OutputFileName;
            if (String.IsNullOrEmpty(this._userSetting.OutputFileName))
            {
                // �t�@�C�������w�肳��Ă��Ȃ��ƃG���[
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILENAME_NOTFOUND, -1, MessageBoxButtons.OK);

                return;
            }

            // �m�F�_�C�A���O�����E�\��
            PMZAI04604UB textOutDialog = new PMZAI04604UB();
            textOutDialog.UserSetting = _userSetting;
            if (textOutDialog.ShowDialog() != DialogResult.OK)
            {
                // ���~
                return;
            }

            // ShowDialog�ɂ��A_userSetting�͏����ς���Ă���̂Őݒ�XML�X�V
            settingConstForm.Serialize();

            String typeStr = string.Empty;
            Char typeChar = new char();
            Byte typeByte = new byte();
            DateTime typeDate = new DateTime();

            Int16 typeInt16 = new short();
            Int32 typeInt32 = new int();
            Int64 typeInt64 = new long();
            Single typeSingle = new float();
            Double typeDouble = new double();
            Decimal typeDecimal = new decimal();

            FormattedTextWriter tw = new FormattedTextWriter();

            // �p�^�[���𕪉�
            _patternSetting = new string[9];
            settingConstForm.Degradation(this._userSetting.SelectedPatternName, out _patternSetting);

            // �p�^�[���̍\��
            // ��؂蕶��(�^�u�E�C�ӁE�Œ蒷�j/��؂蕶���C��/  0-1
            // ���蕶��(�h�E�C�Ӂj/���蕶���C��/                2-3
            // ���l����i����^���Ȃ�)                          4
            // ��������i����^���Ȃ�)                          5
            // �^�C�g���s�i����^�Ȃ��j                         6
            // �o�͍��ڃ��X�g (xx����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��StockMoveDetail�̏��ɕ���ł��� 7


            // �J�������ꗗ���쐬
            // ����
            _exportColumnNameList = settingConstForm.GetColumnNameList(_patternSetting[7], false);
            string[] gridSetting;
            getGridSettingPattern(_patternSetting[7], out gridSetting);
            List<String> schemeList;
            getSchemeList(gridSetting, out schemeList);

            // �o�͍��ږ�
            tw.SchemeList = schemeList;

            // �Œ蒷�F����
            SalesDtlMaxLength(ref tw);

            if (_stockMoveFixCode == 1)
            {
                // �o�͋敪�����׍ϕ�
                if (this._stockMovePpr.OutputDiv == 1)
                {
                    this._stockMoveDataSet.StockMoveDetail.DateColumn.Caption = "���ד�";
                }
                else
                {
                    this._stockMoveDataSet.StockMoveDetail.DateColumn.Caption = "�o�ד�";
                }

            }
            else if (_stockMoveFixCode == 2)
            {
                this._stockMoveDataSet.StockMoveDetail.DateColumn.Caption = "�`�[���t";
            }
            tw.DataSource = this.uGrid_StockMove.DataSource;

            // �O���b�h�̃\�[�g����K�p����
            if (tw.DataSource is DataView)
            {
                (tw.DataSource as DataView).Sort = GetSortingColumns(this.uGrid_StockMove);
            }

            # region [�t�H�[�}�b�g���X�g]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in uGrid_StockMove.DisplayLayout.Bands[0].Columns)
            {
                formatList.Add(col.Key, col.Format);
            }
            tw.FormatList = formatList;
            # endregion

            #region �I�v�V�����Z�b�g
            // �t�@�C����
            tw.OutputFileName = this._userSetting.OutputFileName;
            // ��؂蕶��
            if (this._patternSetting[0] == "0")
            {
                tw.Splitter = "\t";
            }
            else if (this._patternSetting[0] == "1")
            {
                tw.Splitter = this._patternSetting[1];
            }
            else
            {
                tw.Splitter = string.Empty;
            }
            // ���ڊ��蕶��
            if (this._patternSetting[2] == "0")
            {
                tw.Encloser = "\"";
            }
            else if (this._patternSetting[2] == "1")
            {
                tw.Encloser = this._patternSetting[3];
            }
            // �Œ蕝
            if (this._patternSetting[0] == "2")
            {
                tw.FixedLength = true;
            }
            else
            {
                tw.FixedLength = false;
            }
            // �^�C�g���s�o��
            if (this._patternSetting[6] == "1")
            {
                tw.CaptionOutput = false;
            }
            else
            {
                tw.CaptionOutput = true;
            }
            // ���ڊ���K�p
            List<Type> enclosingList = new List<Type>();
            if (this._patternSetting[4] == "0")
            {
                enclosingList.Add(typeInt16.GetType());
                enclosingList.Add(typeInt32.GetType());
                enclosingList.Add(typeInt64.GetType());
                enclosingList.Add(typeDouble.GetType());
                enclosingList.Add(typeDecimal.GetType());
                enclosingList.Add(typeSingle.GetType());
            }
            if (this._patternSetting[5] == "0")
            {
                enclosingList.Add(typeStr.GetType());
                enclosingList.Add(typeChar.GetType());
                enclosingList.Add(typeByte.GetType());
                enclosingList.Add(typeDate.GetType());
            }
            tw.EnclosingTypeList = enclosingList;
            #endregion

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);

            if (status == 9)// �ُ�I��
            {
                // �o�͎��s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILE_FAILED, -1, MessageBoxButtons.OK);
            }
            else
            {
                // �o�͐���
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + MSG_OUTPUTFILE_SUCCEEDED, -1, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// �Œ蒷�F����
        /// </summary>
        /// <param name="tw"></param>
        /// <remarks>
        /// <br>Note       : �Œ蒷�F���ׁB</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 ��r�� �d����Ǝd���於��ǉ����܂�</br>
        /// </remarks>
        private void SalesDtlMaxLength(ref FormattedTextWriter tw)
        {
            #region

            tw.MaxLengthList = new Dictionary<string, int>();
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName, 10);          //���o�ד�/�`�[���t
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName, 9);    //�`�[�ԍ�
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName, 6);         //�sNo
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName, 4);       //�敪
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName, 20);    //�S���Җ�
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName, 80);         //�i��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName, 24);          //�i��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName, 6);       //���[�J�[�R�[�h
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName, 60);       �@//���[�J�[����
            // ADD 2011/05/20 ---------------->>>>>>
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName, 6);       //�d����R�[�h
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName, 40);       �@//�d���於
            // ADD 2011/05/20 ----------------<<<<<<
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName, 6);        //BL�R�[�h
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName, 12); //�ړ��P��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName, 8);        //����
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName, 9);     //�W�����i
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName, 12);       �@//�ړ����z
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName, 8);        //���͋��_�R�[�h
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName, 20); //���͋��_��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName, 8);        //�o�ɋ��_�R�[�h
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName, 20);     //�o�ɋ��_��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName, 8);       �@//�o�ɑq��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName, 40);        //�o�ɑq�ɖ�
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName, 8); //�o�ɒI��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName, 8);        //���ɋ��_�R�[�h
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName, 20);     //���ɋ��_��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName, 8);     //���ɑq��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName, 40);        //���ɑq�ɖ�
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName, 8);     //���ɒI��
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName, 8);       �@//���׋敪
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName, 10);        //�o�ד�
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName, 10);        //���ד�
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName, 10);        //���͓�
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName, 80);     //���l

            #endregion
        }

        /// <summary>
        /// �O���b�h�̃Z�b�e�B���O�𕶎��񂩂���o��
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃Z�b�e�B���O�𕶎��񂩂���o���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting)
        {
            int count = patternStr.Length / (PMZAI04604UA.ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for (int i = 0; i < count; i++)
            {
                gridSetting[i] = patternStr.Substring(i * (PMZAI04604UA.ct_ColumnCountLength + 1), (PMZAI04604UA.ct_ColumnCountLength + 1));
            }
        }

        /// <summary>
        /// �X�L�[�}���X�g���擾����
        /// </summary>
        /// <param name="gridSetting"></param>
        /// <param name="schemeList"></param>
        /// <remarks>
        /// <br>Note       : �X�L�[�}���X�g���擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool getSchemeList(string[] gridSetting, out List<String> schemeList)
        {
            schemeList = new List<string>();

            Dictionary<int, string> sortList = new Dictionary<int, string>();
            string displayFlag = string.Empty;
            string displayOrder = string.Empty;
            int columnOrder = 0;
            DataTable targetTable;
            targetTable = _stockMoveDataSet.StockMoveDetail;

            foreach (string settings in gridSetting)
            {
                if (targetTable.Columns.Count <= columnOrder) break;

                // �S���̐��l�Ȃ̂łP�{�R�ɕ���
                displayFlag = settings.Substring(0, 1);
                displayOrder = settings.Substring(1, PMZAI04604UA.ct_ColumnCountLength);

                // �\������ł����Dictionary�ɒǉ�
                if (displayFlag == "0")
                {
                    sortList.Add(int.Parse(displayOrder), targetTable.Columns[columnOrder].ColumnName);
                }
                columnOrder++;
            }

            List<int> keyList = new List<int>(sortList.Keys);
            keyList.Sort();


            foreach (int key in keyList)
            {
                schemeList.Add(sortList[key]);
            }

            return true;
        }

        #endregion

        #region EXCEL�o��

        /// <summary>
        /// EXCEL�f�[�^�o��
        /// </summary>
        /// <remarks>
        /// <br>Note       : EXCEL�f�[�^�o�́B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void exportIntoExcelData()
        {
            string fileName = string.Empty;

            // �t�@�C���ۑ��_�C�A���O�\��
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = "Excel�t�@�C��(*.xls) | *.xls";
            this.openFileDialog.FilterIndex = 0;

            fileName = string.Empty;

            // �t�@�C���I��
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }

            if (String.IsNullOrEmpty(fileName))
            {
                // �t�@�C�������w�肳��Ă��Ȃ�
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTEXCEL_NOFILENAME, -1, MessageBoxButtons.OK);

                return;
            }

            try
            {
                if (this.ultraGridExcelExporter.Export(this.uGrid_StockMove, fileName) != null)
                {
                    // ����
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        MSG_OUTPUTEXCEL_SUCCEEDED, -1, MessageBoxButtons.OK);
                };
            }
            catch (Exception e)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    e.Message, -1, MessageBoxButtons.OK);
            }
        }

        #endregion // EXCEL�o��

        #region �ݒ�

        /// <summary>
        /// �ݒ�_�C�A���O��\�����܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ݒ�_�C�A���O��\�����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void openSetting()
        {
            DialogResult dialogResult = _settingForm.ShowDialog(this);
        }

        #endregion // �ݒ�

        #region �c�[���o�[����

        #region ��R���{�{�b�N�X����

        /// <summary>
        /// �c�[���o�[�̗�R���{�{�b�N�X�𒲐�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̗�R���{�{�b�N�X�𒲐��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void setToolbarSearchSurface()
        {
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"];

            ValueList list = new ValueList();
            ValueListItemsCollection collection = list.ValueListItems;
            ValueListItem item = null;

            collection.Clear();

            // �S�Ă̗��ǉ�
            item = new ValueListItem();
            item.DisplayText = "�S�Ă̗�";
            item.DataValue = "*all*";
            collection.Add(item);

            // �S�Ă̐݌v���ꂽ���ǉ�(uGrid�̗�ݒ菀��)
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.uGrid_StockMove.DisplayLayout.Bands[0].Columns)
            {
                if (!column.Hidden)
                {
                    item = new ValueListItem();
                    item.DisplayText = column.Header.Caption;
                    item.DataValue = column.Key;

                    if (!String.IsNullOrEmpty(item.DisplayText))
                    {
                        collection.Add(item);
                    }
                }
            }

            comboTool.ValueList = list;
            comboTool.Text = "�S�Ă̗�";
        }

        #endregion // ��R���{�{�b�N�X����

        #region �s�����J�n

        /// <summary>
        /// �c�[���o�[����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rowSearchStart()
        {
            // ������������擾
            Infragistics.Win.UltraWinToolbars.TextBoxTool textTool = (Infragistics.Win.UltraWinToolbars.TextBoxTool)this.tToolbarsManager.Tools["TextBoxTool_SearchWord"];
            string searchStr = textTool.Text;
            if (String.IsNullOrEmpty(searchStr))
            {
                return;
            }

            // �ΏۂƂȂ����擾
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"];
            ValueListItem item = (ValueListItem)comboTool.SelectedItem;
            string valueStr = item.DataValue.ToString();
            string textStr = item.DisplayText;

            if (String.IsNullOrEmpty(valueStr) || String.IsNullOrEmpty(textStr))
            {
                return;
            }

            bool continueFlag = false;
            Infragistics.Win.UltraWinGrid.UltraGridRow selectRow = null;

            #region ����

            // ���ݑI������Ă���s���Ȃ���΍ŏ�����
            if (this.uGrid_StockMove.ActiveRow == null) continueFlag = true;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_StockMove.Rows)
            {
                if (continueFlag)
                {
                    if (valueStr != "*all*")
                    {
                        if (gridRow.Cells[valueStr].Value.ToString().IndexOf(searchStr) > -1)
                        {
                            selectRow = gridRow;
                            break;
                        }
                    }
                    else
                    {
                        // �S�Ă̗�Ō���
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
                        {
                            if (cell.Value.ToString().IndexOf(searchStr) > -1)
                            {
                                selectRow = gridRow;
                                break;
                            }
                        }
                        if (selectRow != null) break;
                    }
                }

                // ���݂̍s�ɒB�����玟�̍s���猟�����s��
                if (!continueFlag && gridRow == this.uGrid_StockMove.ActiveRow) continueFlag = true;
            }

            // �Ō�܂Ō������Ă��Ȃ��Ȃ�ŏ�����
            if (selectRow == null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_StockMove.Rows)
                {
                    // ���݂̍s�ɒB������I��
                    if (gridRow == this.uGrid_StockMove.ActiveRow) break;

                    if (valueStr != "*all*")
                    {
                        if (gridRow.Cells[valueStr].Value.ToString().IndexOf(searchStr) > -1)
                        {
                            selectRow = gridRow;
                            break;
                        }
                    }
                    else
                    {
                        // �S�Ă̗�Ō���
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
                        {
                            if (cell.Value.ToString().IndexOf(searchStr) > -1)
                            {
                                selectRow = gridRow;
                                break;
                            }
                        }
                        if (selectRow != null) break;
                    }
                }
            }

            // �I�����ꂽ�s�����ݍs�ɐݒ�
            if (selectRow != null)
            {
                // �I��
                if (this.uGrid_StockMove.ActiveRow != null)
                {
                    this.uGrid_StockMove.Rows[this.uGrid_StockMove.ActiveRow.Index].Selected = false;
                }
                else
                {
                    this.uGrid_StockMove.Rows[0].Selected = false;
                }
                this.uGrid_StockMove.Rows[selectRow.Index].Selected = true;

                this.uGrid_StockMove.ActiveRow = selectRow;
                return;
            }
            else
            {
                // ������܂���
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_ROWSEARCH_NOT_FOUND, -1, MessageBoxButtons.OK);
                return;
            }

            #endregion // ����
        }

        #endregion // �s�����J�n

        #endregion // �c�[���o�[����

        #region �񕝎��������ύX

        /// <summary>
        /// �񕝎��������`�F�b�N�{�b�N�X�̕ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �񕝎��������`�F�b�N�{�b�N�X�̕ύX�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            this._columnWidthAutoAdjust = this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked;
            autoColumnAdjust(this._columnWidthAutoAdjust);
        }

        #endregion // �񕝎��������ύX

        #region �񕝎�������

        /// <summary>
        /// �񕝎�������
        /// </summary>
        /// <param name="autoAdjust">�����������邩�ǂ���</param>
        /// <remarks>
        /// <br>Note       : �񕝎��������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
        {
            if (this.uGrid_StockMove.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                 this.uGrid_StockMove.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) return;

            // ���������v���p�e�B�𒲐�
            if (autoAdjust)
            {
                this.uGrid_StockMove.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_StockMove.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }
            // �S�Ă̗�ŃT�C�Y����
            for (int i = 0; i < this.uGrid_StockMove.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
            return;
        }

        #endregion //�񕝎�������

        #region �t�H���g�T�C�Y�ύX

        /// <summary>
        /// �t�H���g�T�C�Y�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H���g�T�C�Y�ύX�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            this.uGrid_StockMove.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this.uGrid_StockMove.Refresh();

            uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(null, null);
        }

        /// <summary>
        /// StrToInt�]��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : StrToInt�]���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }

        #endregion // �t�H���g�T�C�Y�ύX        

        /// <summary>
        /// ��{������CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��{������CheckedChanged�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uCheckStockMoveDtl_base_CheckedChanged(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender;
            bool status = true;
            string checkMessage = string.Empty;
            int maxCount = 0;

            // 1�F�o�׊m�肠��A�Q�F�o�׊m��Ȃ�
            if (this._stockMoveFixCode == 1)
            {
                checkMessage = "�I���\�ȍ��ڂ͂S���ڂ܂łł��B";
                maxCount = 4;
            }
            else if (this._stockMoveFixCode == 2)
            {
                checkMessage = "�I���\�ȍ��ڂ͂U���ڂ܂łł��B";
                maxCount = 6;
            }

            #region[�`�[�ԍ�]
            // �`�[�ԍ�
            if (uCheckEditor == this.uCheckSalesSlipNum_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckSalesSlipNum.Checked = true;
                        this.uCheckSalesSlipNum.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckSalesSlipNum.Checked = false;
                    this.uCheckSalesSlipNum.Enabled = true;

                }
            }
            #endregion

            #region [���͓��J�n]
            // ���͓��J�n
            else if (uCheckEditor == this.uCheckAddUpADateSt_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAddUpADateSt.Checked = true;
                        this.uCheckAddUpADateSt.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAddUpADateSt.Checked = false;
                    this.uCheckAddUpADateSt.Enabled = true;

                }
            }
            #endregion

            #region [���͓��I��]
            // ���͓��I��
            else if (uCheckEditor == this.uCheckAddUpADateEd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAddUpADateEd.Checked = true;
                        this.uCheckAddUpADateEd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAddUpADateEd.Checked = false;
                    this.uCheckAddUpADateEd.Enabled = true;

                }
            }
            #endregion

            #region [�S����]
            // �S����
            else if (uCheckEditor == this.uCheckSalesEmployeeCd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckSalesEmployeeCd.Checked = true;
                        this.uCheckSalesEmployeeCd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckSalesEmployeeCd.Checked = false;
                    this.uCheckSalesEmployeeCd.Enabled = true;

                }
            }
            #endregion

            #region [�d����]
            // �d����
            else if (uCheckEditor == this.uCheckSupplierCd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckSupplierCd.Checked = true;
                        this.uCheckSupplierCd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckSupplierCd.Checked = false;
                    this.uCheckSupplierCd.Enabled = true;

                }
            }
            #endregion

            #region [���[�J�[]
            // �S����
            else if (uCheckEditor == this.uCheckGoodsMakerCd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckGoodsMakerCd.Checked = true;
                        this.uCheckGoodsMakerCd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckGoodsMakerCd.Checked = false;
                    this.uCheckGoodsMakerCd.Enabled = true;

                }
            }
            #endregion

            #region [BL�R�[�h]
            // BL�R�[�h
            else if (uCheckEditor == this.uCheckBLGoodsCode_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckBLGoodsCode.Checked = true;
                        this.uCheckBLGoodsCode.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckBLGoodsCode.Checked = false;
                    this.uCheckBLGoodsCode.Enabled = true;

                }
            }
            #endregion

            #region [�i��]
            // �i��
            else if (uCheckEditor == this.uCheckGoodsNo_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckGoodsNo.Checked = true;
                        this.uCheckGoodsNo.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckGoodsNo.Checked = false;
                    this.uCheckGoodsNo.Enabled = true;

                }
            }
            #endregion

            #region [�i��]
            // �i��
            else if (uCheckEditor == this.uCheckGoodsName_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckGoodsName.Checked = true;
                        this.uCheckGoodsName.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckGoodsName.Checked = false;
                    this.uCheckGoodsName.Enabled = true;

                }
            }
            #endregion

            #region [�I��]
            // �I��
            else if (uCheckEditor == this.uCheckWarehouseShelfNo_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckWarehouseShelfNo.Checked = true;
                        this.uCheckWarehouseShelfNo.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckWarehouseShelfNo.Checked = false;
                    this.uCheckWarehouseShelfNo.Enabled = true;

                }
            }
            #endregion

            #region [���苒�_]
            // ���苒�_
            else if (uCheckEditor == this.uCheckAfSectionCode_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAfSectionCode.Checked = true;
                        this.uCheckAfSectionCode.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAfSectionCode.Checked = false;
                    this.uCheckAfSectionCode.Enabled = true;

                }
            }
            #endregion

            #region [����q��]
            // ����q��
            else if (uCheckEditor == this.uCheckAfEnterWarehCode_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAfEnterWarehCode.Checked = true;
                        this.uCheckAfEnterWarehCode.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAfEnterWarehCode.Checked = false;
                    this.uCheckAfEnterWarehCode.Enabled = true;

                }
            }
            #endregion

            #region [���׋敪]
            // ���׋敪
            else if (uCheckEditor == this.uCheckArrivalGoodsFlag_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckArrivalGoodsFlag.Checked = true;
                        this.uCheckArrivalGoodsFlag.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckArrivalGoodsFlag.Checked = false;
                    this.uCheckArrivalGoodsFlag.Enabled = true;

                }
            }
            #endregion

            #region [���l]
            // ���l
            else if (uCheckEditor == this.uCheckNote_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckNote.Checked = true;
                        this.uCheckNote.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckNote.Checked = false;
                    this.uCheckNote.Enabled = true;

                }
            }
            #endregion

            #region [�폜�w��敪]
            // �폜�w��敪
            else if (uCheckEditor == this.uCheckDeleteFlag_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckDeleteFlag.Checked = true;
                        this.uCheckDeleteFlag.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckDeleteFlag.Checked = false;
                    this.uCheckDeleteFlag.Enabled = true;

                }
            }
            #endregion

            if (status == false)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMZAI04601U",							// �A�Z���u��ID
                    checkMessage,	                        // �\�����郁�b�Z�[�W
                    0,									    // �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
        }

        /// <summary>
        /// �ڍ׏����O���[�v�̏k���E�W�J �ύX������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ڍ׏����O���[�v�̏k���E�W�J �ύX�������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uExGroupBox_ExtraCondition_ExpandedStateChanged(object sender, EventArgs e)
        {
            if (uExGroupBox_ExtraCondition.Expanded)
            {
                this.SuspendLayout();
                try
                {
                    DisplayExtraConditions();
                }
                finally
                {
                    this.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// �g�����������̕\���ݒ�p�y�C������\���ɂȂ����^�C�~���O�ł̃C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���̃^�C�~���O�Ń`�F�b�N�{�b�N�X��ݒ���擾���A�\�����ڂ𒲐�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        void ultraDockManager_PaneHidden(object sender, Infragistics.Win.UltraWinDock.PaneHiddenEventArgs e)
        {
            // ��ʂ̍X�V���~
            this.SuspendLayout();

            DisplayExtraConditions();

            // ��ʍX�V���ĊJ
            this.ResumeLayout();

        }

        #region �ڍ׏����̕\��
        /// <summary>
        /// �ڍ׏����̕\��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׏����̕\���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void DisplayExtraConditions()
        {
            int displayedItemCount = 0;     // �\������Ă��錟�������̍��ڐ�

            // �S�Ă̍��ڂ�Hidden��
            SetAllDetailSearchCondition2Hidden();

            int tabIndex = 0;
            #region [��{����]
            DisplayCommonConditions(out tabIndex);
            #endregion

            this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
            this._currentLocationY = CT_INITIAL_FIELD_POSITION_Y;

            _gridUpKeyBackControl = null;

            // �`�F�b�N�{�b�N�X�̐ݒ�����ׂĎ擾�A�`�F�b�N�����Ă��鍀�ڂ�\��
            // �^�O�ňꊇ�Ǘ����悤���Ƃ��l�����������������o�Ă������Ȃ̂Œ��ڊǗ�

            #region �`�[�ԍ�
            // �`�[�ԍ�
            if ((this.uCheckSalesSlipNum.Checked) && (this.uCheckSalesSlipNum.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_StockMoveSlipNum;
                }

                // �`�[�ԍ����x��
                this.uLabel_SalesSlipNumTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �`�[�ԍ�tNedit
                this.tEdit_StockMoveSlipNum.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_StockMoveSlipNum.Visible = true;
                this.tEdit_StockMoveSlipNum.Width = 150;
                this._currentLocationX += 155;

                // �`�[�ԍ����x���Q
                this.uLabel_SalesSlipNumEnd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumEnd.Visible = true;
                this.uLabel_SalesSlipNumEnd.Width = 50;

                this.tEdit_StockMoveSlipNum.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckSalesSlipNum_base.Checked)
                {
                    tEdit_StockMoveSlipNum.Clear();
                }
            }
            #endregion // �`�[�ԍ�

            #region ���͓��J�n
            // ���͓��J�n
            if ((this.uCheckAddUpADateSt.Checked) && (this.uCheckAddUpADateSt.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tDateEdit_AddUpADateSt;
                }

                // ���͓��J�n���x��
                this.uLabel_AddUpADateTitle_St.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_St.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���͓��J�ntDateEdit
                this.tDateEdit_AddUpADateSt.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateSt.Visible = true;
                this.tDateEdit_AddUpADateSt.Width = 176;
                this.tDateEdit_AddUpADateSt.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAddUpADateSt_base.Checked)
                {
                    tDateEdit_AddUpADateSt.Clear();
                }
            }
            #endregion // ���͓��J�n

            #region ���͓��I��
            // ���͓��I��
            if ((this.uCheckAddUpADateEd.Checked) && ((this.uCheckAddUpADateEd.Enabled == true)))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tDateEdit_AddUpADateEd;
                }

                // ���͓��I�����x��
                this.uLabel_AddUpADateTitle_Ed.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_Ed.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���͓��I��tDateEdit
                this.tDateEdit_AddUpADateEd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateEd.Visible = true;
                this.tDateEdit_AddUpADateEd.Width = 176;
                this.tDateEdit_AddUpADateEd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAddUpADateEd_base.Checked)
                {
                    tDateEdit_AddUpADateEd.Clear();
                }
            }
            #endregion // ���͓��I��

            #region �S����
            // �S����
            if ((this.uCheckSalesEmployeeCd.Checked) && (this.uCheckSalesEmployeeCd.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_SalesEmployeeCd;
                }

                // �S���҃��x��
                this.uLabel_SalesEmployeeCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesEmployeeCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �S����tEdit
                this.tEdit_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SalesEmployeeCd.Visible = true;
                this.tEdit_SalesEmployeeCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SalesEmployeeCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // �S���҃K�C�h�{�^��
                this.uButton_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SalesEmployeeCd.Visible = true;
                this.uButton_SalesEmployeeCd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckSalesEmployeeCd_base.Checked)
                {
                    _swSalesEmployeeCd = string.Empty;
                    _swSalesEmployeeName = string.Empty;
                    tEdit_SalesEmployeeCd.Text = string.Empty;
                }
            }
            #endregion // �S����

            #region �d����
            // �d����
            if ((this.uCheckSupplierCd.Checked) && (this.uCheckSupplierCd.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_SupplierCd;
                }

                // �d���惉�x��
                this.uLabel_SupplierCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SupplierCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �d����tEdit
                this.tEdit_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SupplierCd.Visible = true;
                this.tEdit_SupplierCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SupplierCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // �d����K�C�h�{�^��
                this.uButton_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SupplierCd.Visible = true;
                this.uButton_SupplierCd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckSupplierCd_base.Checked)
                {
                    _swSupplierCd = 0;
                    _swSupplierName = string.Empty;
                    tEdit_SupplierCd.Text = string.Empty;
                }
            }
            #endregion // �d����

            #region ���[�J�[
            // ���[�J�[
            if ((this.uCheckGoodsMakerCd.Checked) && (this.uCheckGoodsMakerCd.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_MakerCd;
                }

                // ���[�J�[���x��
                this.uLabel_MakerCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_MakerCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���[�J�[tEdit
                this.tEdit_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_MakerCd.Visible = true;
                this.tEdit_MakerCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_MakerCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // ���[�J�[�K�C�h�{�^��
                this.uButton_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_MakerCd.Visible = true;
                this.uButton_MakerCd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckGoodsMakerCd_base.Checked)
                {
                    _swGoodsMakerCd = 0;
                    _swGoodsMakerName = string.Empty;
                    tEdit_MakerCd.Text = string.Empty;
                }
            }
            #endregion // ���[�J�[

            #region BL�R�[�h
            // BL�R�[�h
            if ((this.uCheckBLGoodsCode.Checked) && (this.uCheckBLGoodsCode.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_BlGoodsCode;
                }

                // BL�R�[�h���x��
                this.uLabel_BlGoodsCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_BlGoodsCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // BL�R�[�htEdit
                this.tEdit_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_BlGoodsCode.Visible = true;
                this.tEdit_BlGoodsCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_BlGoodsCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // BL�R�[�h�K�C�h�{�^��
                this.uButton_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_BlGoodsCode.Visible = true;
                this.uButton_BlGoodsCode.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckBLGoodsCode_base.Checked)
                {
                    _swBLGoodsCode = 0;
                    _swBLGoodsName = string.Empty;
                    tEdit_BlGoodsCode.Text = string.Empty;
                }
            }
            #endregion // BL�R�[�h

            #region �i��
            // �i��
            if ((this.uCheckGoodsNo.Checked) && (this.uCheckGoodsNo.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_GoodsNo;
                }

                // �i�ԃ��x��
                this.uLabel_GoodsNoTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNoTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �i��tEdit
                this.tEdit_GoodsNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsNo.Visible = true;
                this.tEdit_GoodsNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // �i�ԞB������
                this.tComboEditor_GoodsNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNoFuzzy.Visible = true;
                this.tComboEditor_GoodsNoFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckGoodsNo_base.Checked)
                {
                    tEdit_GoodsNo.Text = string.Empty;
                }
            }
            #endregion // �i��

            #region �i��
            // �i��
            if ((this.uCheckGoodsName.Checked) && (this.uCheckGoodsName.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_GoodsName;
                }

                // �i�����x��
                this.uLabel_GoodsNameTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNameTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �i��tEdit
                this.tEdit_GoodsName.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsName.Visible = true;
                this.tEdit_GoodsName.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsName.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // �i���B������
                this.tComboEditor_GoodsNameFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNameFuzzy.Visible = true;
                this.tComboEditor_GoodsNameFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckGoodsName_base.Checked)
                {
                    tEdit_GoodsName.Text = string.Empty;
                }
            }
            #endregion // �i��

            # region [�I��]
            // �I��
            if ((this.uCheckWarehouseShelfNo.Checked) && (this.uCheckWarehouseShelfNo.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tEdit_WarehouseShelfNo.Enabled == true)
                {
                    this._gridUpKeyBackControl = tEdit_WarehouseShelfNo;
                }

                // �I�ԃ��x��
                this.uLabel_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_WarehouseShelfNo.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �I��tEdit
                this.tEdit_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_WarehouseShelfNo.Visible = true;
                this.tEdit_WarehouseShelfNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_WarehouseShelfNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // �I�ԞB������
                this.tComboEditor_WarehouseShelfNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_WarehouseShelfNoFuzzy.Visible = true;
                this.tComboEditor_WarehouseShelfNoFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckWarehouseShelfNo_base.Checked)
                {
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                }
            }
            # endregion

            # region [���苒�_]
            // ���苒�_
            if ((this.uCheckAfSectionCode.Checked) && (this.uCheckAfSectionCode.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tEdit_AfSectionCode.Enabled == true)
                {
                    this._gridUpKeyBackControl = tEdit_AfSectionCode;
                }

                // ���苒�_���x��
                this.uLabel_AfSectionCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfSectionCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���苒�_tEdit
                this.tEdit_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfSectionCode.Visible = true;
                this.tEdit_AfSectionCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfSectionCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // ���苒�_�K�C�h�{�^��
                this.uButton_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfSectionCode.Visible = true;
                this.uButton_AfSectionCode.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAfSectionCode_base.Checked)
                {
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                    //_swAfSectionCode = 0; // DEL 2010/05/18
                    _swAfSectionCode = string.Empty; // ADD 2010/05/18
                    _swAfSectionName = string.Empty;
                    tEdit_AfSectionCode.Text = string.Empty;
                }
            }
            # endregion

            # region [����q��]
            // ����q��
            if ((this.uCheckAfEnterWarehCode.Checked) && (this.uCheckAfEnterWarehCode.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tEdit_AfEnterWarehCode.Enabled == true)
                {
                    this._gridUpKeyBackControl = tEdit_AfEnterWarehCode;
                }

                // ����q�Ƀ��x��
                this.uLabel_AfEnterWarehCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfEnterWarehCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ����q��tEdit
                this.tEdit_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfEnterWarehCode.Visible = true;
                this.tEdit_AfEnterWarehCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfEnterWarehCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // ����q�ɃK�C�h�{�^��
                this.uButton_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfEnterWarehCode.Visible = true;
                this.uButton_AfEnterWarehCode.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAfEnterWarehCode_base.Checked)
                {
                    _swAfEnterWarehCode = string.Empty;
                    _swAfEnterWarehName = string.Empty;
                    tEdit_AfEnterWarehCode.Text = string.Empty;
                }
            }
            # endregion

            # region [���׋敪]
            // ���׋敪
            if ((this.uCheckArrivalGoodsFlag.Checked) && (this.uCheckArrivalGoodsFlag.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tComboEditor_ArrivalGoodsFlag.Enabled == true)
                {
                    this._gridUpKeyBackControl = tComboEditor_ArrivalGoodsFlag;
                }

                // ���׋敪���x��
                this.uLabel_ArrivalGoodsFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_ArrivalGoodsFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���׋敪�R���{�{�b�N�X
                this.tComboEditor_ArrivalGoodsFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_ArrivalGoodsFlag.Visible = true;
                this.tComboEditor_ArrivalGoodsFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_ArrivalGoodsFlag.TabIndex = tabIndex++;

                displayedItemCount++;

                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckArrivalGoodsFlag_base.Checked)
                {
                    tComboEditor_ArrivalGoodsFlag.SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                }
            }
            # endregion

            #region ���l
            // ���l
            if ((this.uCheckNote.Checked) && (this.uCheckNote.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_SlipNote;
                }

                // ���l���x��
                this.uLabel_SlipNoteTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SlipNoteTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���ltEdit
                this.tEdit_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SlipNote.Visible = true;
                this.tEdit_SlipNote.Width = CT_INTERVAL_LABEL + CT_FIELD_INTERVAL_X - 1;
                this.tEdit_SlipNote.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_LABEL + 1;

                // ���l�P�K�C�h
                this.uButton_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SlipNote.Visible = true;
                this._currentLocationX += 24 + 1;
                this.uButton_SlipNote.TabIndex = tabIndex++;

                // ���l�B������
                this.tComboEditor_SlipNoteFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_SlipNoteFuzzy.Visible = true;
                this.tComboEditor_SlipNoteFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckNote_base.Checked)
                {
                    tEdit_SlipNote.Text = string.Empty;
                }
            }
            #endregion // ���l

            #region �폜�w��敪
            // �폜�w��敪
            if ((this.uCheckDeleteFlag.Checked) && (this.uCheckDeleteFlag.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tComboEditor_DeleteFlag;
                }

                // �폜�w��敪���x��
                this.uLabel_DeleteFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_DeleteFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �폜�w��敪�R���{�{�b�N�X
                this.tComboEditor_DeleteFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_DeleteFlag.Visible = true;
                this.tComboEditor_DeleteFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_DeleteFlag.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckDeleteFlag_base.Checked)
                {
                    _logicalDelDiv = 0;
                    tComboEditor_DeleteFlag.SelectedIndex = 0;
                }
            }
            #endregion // �폜�w��敪

            // �g�����������G���A�̕\��/��\����ݒ�
            if (displayedItemCount > 0)
            {
                // ��ł����ڂ��`�F�b�N����Ă���Ε\��
                this.uExGroupBox_ExtraCondition.Visible = true;
            }
            else
            {
                // ���ڂ�����`�F�b�N����Ă��Ȃ���Δ�\��
                this.uExGroupBox_ExtraCondition.Visible = false;
            }

            // �g�����������G���A�̍������v�Z
            if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0) this._currentLocationY -= CT_INTERVAL_HEIGHT;  // ���ڐ���3�̔{���̎��͉��s����Ă���̂ŉ��s���폜
            this.uExGroupBox_ExtraCondition.Height = this._currentLocationY + CT_INTERVAL_HEIGHT + CT_INTERVAL_HEIGHT;
        }

        #endregion

        #region �ڍ׌���������\��

        /// <summary>
        /// �ڍ׌��������G���A�̃R���g���[�������ׂĔ�\��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׌��������G���A�̃R���g���[�������ׂĔ�\���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SetAllDetailSearchCondition2Hidden()
        {
            // �`�[�ԍ�
            this.uLabel_SalesSlipNumTitle.Visible = false;
            this.tEdit_StockMoveSlipNum.Visible = false;
            this.uLabel_SalesSlipNumEnd.Visible = false;

            // ���͓��J�n
            this.uLabel_AddUpADateTitle_St.Visible = false;
            this.tDateEdit_AddUpADateSt.Visible = false;

            // ���͓��I��
            this.uLabel_AddUpADateTitle_Ed.Visible = false;
            this.tDateEdit_AddUpADateEd.Visible = false;

            // �S����
            this.uLabel_SalesEmployeeCdTitle.Visible = false;
            this.tEdit_SalesEmployeeCd.Visible = false;
            this.uButton_SalesEmployeeCd.Visible = false;

            // �d����
            this.uLabel_SupplierCdTitle.Visible = false;
            this.tEdit_SupplierCd.Visible = false;
            this.uButton_SupplierCd.Visible = false;

            // ���[�J�[
            this.uLabel_MakerCdTitle.Visible = false;
            this.tEdit_MakerCd.Visible = false;
            this.uButton_MakerCd.Visible = false;

            // �a�k�R�[�h
            this.uLabel_BlGoodsCodeTitle.Visible = false;
            this.tEdit_BlGoodsCode.Visible = false;
            this.uButton_BlGoodsCode.Visible = false;

            // �i��
            this.uLabel_GoodsNoTitle.Visible = false;
            this.tEdit_GoodsNo.Visible = false;
            this.tComboEditor_GoodsNoFuzzy.Visible = false;

            // �i��
            this.uLabel_GoodsNameTitle.Visible = false;
            this.tEdit_GoodsName.Visible = false;
            this.tComboEditor_GoodsNameFuzzy.Visible = false;

            // �I��
            this.uLabel_WarehouseShelfNo.Visible = false;
            this.tEdit_WarehouseShelfNo.Visible = false;
            this.tComboEditor_WarehouseShelfNoFuzzy.Visible = false;

            // ���苒�_
            this.uLabel_AfSectionCodeTitle.Visible = false;
            this.tEdit_AfSectionCode.Visible = false;
            this.uButton_AfSectionCode.Visible = false;

            // ���苒�_
            this.uLabel_AfEnterWarehCodeTitle.Visible = false;
            this.tEdit_AfEnterWarehCode.Visible = false;
            this.uButton_AfEnterWarehCode.Visible = false;

            // ���׋敪
            this.uLabel_ArrivalGoodsFlagTitle.Visible = false;
            this.tComboEditor_ArrivalGoodsFlag.Visible = false;

            // ���l
            this.uLabel_SlipNoteTitle.Visible = false;
            this.tEdit_SlipNote.Visible = false;
            this.uButton_SlipNote.Visible = false;
            this.tComboEditor_SlipNoteFuzzy.Visible = false;

            // �폜�w��敪
            this.uLabel_DeleteFlagTitle.Visible = false;
            this.tComboEditor_DeleteFlag.Visible = false;
        }

        #endregion // �ڍ׌���������\��

        #region ��{�����̕\��
        /// <summary>
        /// ��{�����̕\��
        /// </summary>
        /// <param name="tabIndex">tabIndex</param>
        /// <remarks>
        /// <br>Note       : ��{�����̕\���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/21 ��r�� Redmine#21678 ���苒�_�E����q�ɁE���׋敪�̕\���̉��C</br>
        /// <br></br>
        /// </remarks>
        private void DisplayCommonConditions(out int tabIndex)
        {
            tabIndex = 0;
            this._currentLocationX = 375;
            this._currentLocationY = 27;
            int displayedItemCount = 0;     // �\������Ă��錟�������̍��ڐ�
            int startLocationX = 375;

            #region �`�[�ԍ�
            // �`�[�ԍ�
            if (this.uCheckSalesSlipNum_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_StockMoveSlipNum))
                {
                    // �`�[�ԍ�
                    tEdit_StockMoveSlipNum.Clear();
                }
                
                // �`�[�ԍ����x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SalesSlipNumTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SalesSlipNumTitle);
                this.uLabel_SalesSlipNumTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �`�[�ԍ�tNedit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_StockMoveSlipNum);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_StockMoveSlipNum);
                this.tEdit_StockMoveSlipNum.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_StockMoveSlipNum.Visible = true;
                this.tEdit_StockMoveSlipNum.Width = 150;
                this.tEdit_StockMoveSlipNum.TabIndex = tabIndex++;
                this._currentLocationX += 155;

                // �`�[�ԍ����x���Q
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SalesSlipNumEnd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SalesSlipNumEnd);
                this.uLabel_SalesSlipNumEnd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumEnd.Visible = true;
                this.uLabel_SalesSlipNumEnd.Width = 50;
                this._currentLocationX += 55; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;
                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SalesSlipNumTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_StockMoveSlipNum);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SalesSlipNumEnd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesSlipNumTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_StockMoveSlipNum);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesSlipNumEnd);
                if (!this.uCheckSalesSlipNum.Checked)
                {
                    tEdit_StockMoveSlipNum.Clear();
                }
            }
            #endregion // �`�[�ԍ�

            #region ���͓��J�n
            // ���͓��J�n
            if (this.uCheckAddUpADateSt_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tDateEdit_AddUpADateSt))
                {
                    // ���͓��J�n
                    tDateEdit_AddUpADateSt.Clear();
                }

                // ���͓��J�n���x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AddUpADateTitle_St);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AddUpADateTitle_St);
                this.uLabel_AddUpADateTitle_St.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_St.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���͓��J�ntDateEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tDateEdit_AddUpADateSt);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_AddUpADateSt);
                this.tDateEdit_AddUpADateSt.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateSt.Visible = true;
                this.tDateEdit_AddUpADateSt.Width = 176;
                this.tDateEdit_AddUpADateSt.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AddUpADateTitle_St);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tDateEdit_AddUpADateSt);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AddUpADateTitle_St);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_AddUpADateSt);
                if (!this.uCheckAddUpADateSt.Checked)
                {
                    tDateEdit_AddUpADateSt.Clear();
                }
            }

            #endregion // ���͓��J�n

            #region ���͓��I��
            // ���͓��I��
            if (this.uCheckAddUpADateEd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tDateEdit_AddUpADateEd))
                {
                    // ���͓��I��
                    tDateEdit_AddUpADateEd.Clear();
                }
                // ���͓��I�����x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AddUpADateTitle_Ed);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AddUpADateTitle_Ed);
                this.uLabel_AddUpADateTitle_Ed.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_Ed.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���͓��I��tDateEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tDateEdit_AddUpADateEd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_AddUpADateEd);
                this.tDateEdit_AddUpADateEd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateEd.Visible = true;
                this.tDateEdit_AddUpADateEd.Width = 176;
                this.tDateEdit_AddUpADateEd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AddUpADateTitle_Ed);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tDateEdit_AddUpADateEd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AddUpADateTitle_Ed);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_AddUpADateEd);
                if (!this.uCheckAddUpADateEd.Checked)
                {
                    tDateEdit_AddUpADateEd.Clear();
                }
            }
            #endregion // ���͓��I��

            #region �S����
            // �S����
            if (this.uCheckSalesEmployeeCd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_SalesEmployeeCd))
                {
                    // �S����
                    _swSalesEmployeeCd = string.Empty;
                    _swSalesEmployeeName = string.Empty;
                    tEdit_SalesEmployeeCd.Text = string.Empty;
                }

                // �S���҃��x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SalesEmployeeCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SalesEmployeeCdTitle);
                this.uLabel_SalesEmployeeCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesEmployeeCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �S����tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SalesEmployeeCd);
                this.tEdit_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SalesEmployeeCd.Visible = true;
                this.tEdit_SalesEmployeeCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SalesEmployeeCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // �S���҃K�C�h�{�^��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SalesEmployeeCd);
                this.uButton_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SalesEmployeeCd.Visible = true;
                this.uButton_SalesEmployeeCd.TabIndex = tabIndex++;
                this._currentLocationX += 35;  // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SalesEmployeeCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesEmployeeCdTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SalesEmployeeCd);
                if (!this.uCheckSalesEmployeeCd.Checked)
                {
                    _swSalesEmployeeCd = string.Empty;
                    _swSalesEmployeeName = string.Empty;
                    tEdit_SalesEmployeeCd.Text = string.Empty;
                }
            }
            #endregion // �S����

            #region �d����
            // �d����
            if (this.uCheckSupplierCd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_SupplierCd))
                {
                    // �d����
                    _swSupplierCd = 0;
                    _swSupplierName = string.Empty;
                    tEdit_SupplierCd.Text = string.Empty;
                }

                // �d���惉�x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SupplierCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SupplierCdTitle);
                this.uLabel_SupplierCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SupplierCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �d����tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_SupplierCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SupplierCd);
                this.tEdit_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SupplierCd.Visible = true;
                this.tEdit_SupplierCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SupplierCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // �d����K�C�h�{�^��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_SupplierCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SupplierCd);
                this.uButton_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SupplierCd.Visible = true;
                this.uButton_SupplierCd.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SupplierCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_SupplierCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_SupplierCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SupplierCdTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SupplierCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SupplierCd);
                if (!this.uCheckSupplierCd.Checked)
                {
                    _swSupplierCd = 0;
                    _swSupplierName = string.Empty;
                    tEdit_SupplierCd.Text = string.Empty;
                }
            }
            #endregion // �d����

            #region ���[�J�[
            // ���[�J�[
            if (this.uCheckGoodsMakerCd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_MakerCd))
                {
                    // ���[�J�[
                    _swGoodsMakerCd = 0;
                    _swGoodsMakerName = string.Empty;
                    tEdit_MakerCd.Text = string.Empty;
                }

                // ���[�J�[���x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_MakerCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_MakerCdTitle);
                this.uLabel_MakerCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_MakerCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���[�J�[tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_MakerCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_MakerCd);
                this.tEdit_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_MakerCd.Visible = true;
                this.tEdit_MakerCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_MakerCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // ���[�J�[�K�C�h�{�^��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_MakerCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_MakerCd);
                this.uButton_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_MakerCd.Visible = true;
                this.uButton_MakerCd.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_MakerCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_MakerCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_MakerCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_MakerCdTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_MakerCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_MakerCd);
                if (!this.uCheckGoodsMakerCd.Checked)
                {
                    _swGoodsMakerCd = 0;
                    _swGoodsMakerName = string.Empty;
                    tEdit_MakerCd.Text = string.Empty;
                }
            }
            #endregion // ���[�J�[

            #region BL�R�[�h
            // BL�R�[�h
            if (this.uCheckBLGoodsCode_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_BlGoodsCode))
                {
                    // BL�R�[�h
                    _swBLGoodsCode = 0;
                    _swBLGoodsName = string.Empty;
                    tEdit_BlGoodsCode.Text = string.Empty;
                }

                // BL�R�[�h���x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_BlGoodsCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_BlGoodsCodeTitle);
                this.uLabel_BlGoodsCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_BlGoodsCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // BL�R�[�htEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_BlGoodsCode);
                this.tEdit_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_BlGoodsCode.Visible = true;
                this.tEdit_BlGoodsCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_BlGoodsCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // BL�R�[�h�K�C�h�{�^��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_BlGoodsCode);
                this.uButton_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_BlGoodsCode.Visible = true;
                this.uButton_BlGoodsCode.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_BlGoodsCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_BlGoodsCodeTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_BlGoodsCode);
                if (!this.uCheckBLGoodsCode.Checked)
                {
                    _swBLGoodsCode = 0;
                    _swBLGoodsName = string.Empty;
                    tEdit_BlGoodsCode.Text = string.Empty;
                }
            }
            #endregion // BL�R�[�h

            #region �i��
            // �i��
            if (this.uCheckGoodsNo_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_GoodsNo))
                {
                    // �i��
                    tEdit_GoodsNo.Text = string.Empty;
                    tComboEditor_GoodsNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsNo = string.Empty;
                    _srRvGoodsNo = string.Empty;
                }

                // �i�ԃ��x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_GoodsNoTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_GoodsNoTitle);
                this.uLabel_GoodsNoTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNoTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �i��tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_GoodsNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_GoodsNo);
                this.tEdit_GoodsNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsNo.Visible = true;
                this.tEdit_GoodsNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // �i�ԞB������
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_GoodsNoFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_GoodsNoFuzzy);
                this.tComboEditor_GoodsNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNoFuzzy.Visible = true;
                this.tComboEditor_GoodsNoFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_GoodsNoTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_GoodsNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_GoodsNoFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_GoodsNoTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_GoodsNo);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_GoodsNoFuzzy);
                if (!this.uCheckGoodsNo.Checked)
                {
                    tEdit_GoodsNo.Text = string.Empty;
                    tComboEditor_GoodsNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsNo = string.Empty;
                    _srRvGoodsNo = string.Empty;
                }
            }
            #endregion // �i��

            #region �i��
            // �i��
            if (this.uCheckGoodsName_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_GoodsName))
                {
                    // �i��
                    tEdit_GoodsName.Text = string.Empty;
                    tComboEditor_GoodsNameFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsName = string.Empty;
                    _srRvGoodsName = string.Empty;
                }

                // �i�����x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_GoodsNameTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_GoodsNameTitle);
                this.uLabel_GoodsNameTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNameTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �i��tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_GoodsName);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_GoodsName);
                this.tEdit_GoodsName.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsName.Visible = true;
                this.tEdit_GoodsName.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsName.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // �i���B������
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_GoodsNameFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_GoodsNameFuzzy);
                this.tComboEditor_GoodsNameFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNameFuzzy.Visible = true;
                this.tComboEditor_GoodsNameFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_GoodsNameTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_GoodsName);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_GoodsNameFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_GoodsNameTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_GoodsName);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_GoodsNameFuzzy);
                if (!this.uCheckGoodsName.Checked)
                {
                    tEdit_GoodsName.Text = string.Empty;
                    tComboEditor_GoodsNameFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsName = string.Empty;
                    _srRvGoodsName = string.Empty;
                }
            }
            #endregion // �i��

            # region [�I��]
            // �I��
            if (this.uCheckWarehouseShelfNo_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_WarehouseShelfNo))
                {
                    // �I��
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                    tComboEditor_WarehouseShelfNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srWarehouseShelfNo = string.Empty;
                    _srRvWarehouseShelfNo = string.Empty;
                }

                // �I�ԃ��x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_WarehouseShelfNo);
                this.uLabel_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_WarehouseShelfNo.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �I��tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_WarehouseShelfNo);
                this.tEdit_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_WarehouseShelfNo.Visible = true;
                this.tEdit_WarehouseShelfNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_WarehouseShelfNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // �I�ԞB������
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_WarehouseShelfNoFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_WarehouseShelfNoFuzzy);
                this.tComboEditor_WarehouseShelfNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_WarehouseShelfNoFuzzy.Visible = true;
                this.tComboEditor_WarehouseShelfNoFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_WarehouseShelfNoFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_WarehouseShelfNoFuzzy);
                if (!this.uCheckWarehouseShelfNo.Checked)
                {
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                    tComboEditor_WarehouseShelfNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srWarehouseShelfNo = string.Empty;
                    _srRvWarehouseShelfNo = string.Empty;
                }
            }
            # endregion

            # region [���苒�_]
            // ���苒�_
            if (this.uCheckAfSectionCode_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_AfSectionCode))
                {
                    // ���苒�_
                    //_swAfSectionCode = 0; // DEL 2010/05/18
                    _swAfSectionCode = string.Empty; // ADD 2010/05/18
                    _swAfSectionName = string.Empty;
                    tEdit_AfSectionCode.Text = string.Empty;
                }

                // ���苒�_���x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AfSectionCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AfSectionCodeTitle);
                this.uLabel_AfSectionCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfSectionCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���苒�_tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_AfSectionCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_AfSectionCode);
                this.tEdit_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfSectionCode.Visible = true;
                this.tEdit_AfSectionCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfSectionCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // ���苒�_�K�C�h�{�^��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_AfSectionCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_AfSectionCode);
                this.uButton_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfSectionCode.Visible = true;
                this.uButton_AfSectionCode.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AfSectionCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_AfSectionCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_AfSectionCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AfSectionCodeTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_AfSectionCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_AfSectionCode);
                // if (!this.uCheckSupplierCd.Checked) // DEL 2011/05/21
                if (!this.uCheckAfSectionCode.Checked) // ADD 2011/05/21
                {
                    // ���苒�_
                    //_swAfSectionCode = 0; // DEL 2010/05/18
                    _swAfSectionCode = string.Empty; // ADD 2010/05/18
                    _swAfSectionName = string.Empty;
                    tEdit_AfSectionCode.Text = string.Empty;
                }
            }
            # endregion

            # region [����q��]
            // ����q��
            if (this.uCheckAfEnterWarehCode_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_AfEnterWarehCode))
                {
                    // ����q��
                    _swAfEnterWarehCode = string.Empty;
                    _swAfEnterWarehName = string.Empty;
                    tEdit_AfEnterWarehCode.Text = string.Empty;
                }

                // ����q�Ƀ��x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AfEnterWarehCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AfEnterWarehCodeTitle);
                this.uLabel_AfEnterWarehCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfEnterWarehCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ����q��tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_AfEnterWarehCode);
                this.tEdit_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfEnterWarehCode.Visible = true;
                this.tEdit_AfEnterWarehCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfEnterWarehCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // ����q�ɃK�C�h�{�^��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_AfEnterWarehCode);
                this.uButton_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfEnterWarehCode.Visible = true;
                this.uButton_AfEnterWarehCode.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AfEnterWarehCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AfEnterWarehCodeTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_AfEnterWarehCode);
                // if (!this.uCheckSupplierCd.Checked) // DEL 2011/05/21
                if (!this.uCheckAfEnterWarehCode.Checked) // ADD 2011/05/21
                {
                    // ����q��
                    _swAfEnterWarehCode = string.Empty;
                    _swAfEnterWarehName = string.Empty;
                    tEdit_AfEnterWarehCode.Text = string.Empty;
                }
            }

            # endregion

            # region [���׋敪]
             // ���׋敪
            if (this.uCheckArrivalGoodsFlag_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tComboEditor_ArrivalGoodsFlag))
                {
                    // ���׋敪
                        tComboEditor_ArrivalGoodsFlag.SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                    }

                // ���׋敪���x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_ArrivalGoodsFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_ArrivalGoodsFlagTitle);
                this.uLabel_ArrivalGoodsFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_ArrivalGoodsFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���׋敪�R���{�{�b�N�X
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_ArrivalGoodsFlag);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_ArrivalGoodsFlag);
                this.tComboEditor_ArrivalGoodsFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_ArrivalGoodsFlag.Visible = true;
                this.tComboEditor_ArrivalGoodsFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_ArrivalGoodsFlag.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_ArrivalGoodsFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_ArrivalGoodsFlag);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_ArrivalGoodsFlagTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_ArrivalGoodsFlag);
                // if (!this.uCheckDeleteFlag.Checked) // DEL 2011/05/21
                if (!this.uCheckArrivalGoodsFlag.Checked) // ADD 2011/05/21
                {
                    // ���׋敪
                    tComboEditor_ArrivalGoodsFlag.SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                }
            }
            #endregion // ���׋敪

            #region ���l
            // ���l
            if (this.uCheckNote_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_SlipNote))
                {
                    // ���l
                    tEdit_SlipNote.Text = string.Empty;
                    tComboEditor_SlipNoteFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srSlipNote = string.Empty;
                    _srRvSlipNote = string.Empty;
                }

                // ���l���x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SlipNoteTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SlipNoteTitle);
                this.uLabel_SlipNoteTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SlipNoteTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // ���ltEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SlipNote);
                this.tEdit_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SlipNote.Visible = true;
                this.tEdit_SlipNote.Width = CT_INTERVAL_LABEL + CT_FIELD_INTERVAL_X - 1;
                this.tEdit_SlipNote.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_LABEL + 1;


                // ���l�P�K�C�h
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SlipNote);
                this.uButton_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SlipNote.Visible = true;
                this._currentLocationX += 24 + 1;
                this.uButton_SlipNote.TabIndex = tabIndex++;


                // ���l�B������
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_SlipNoteFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_SlipNoteFuzzy);
                this.tComboEditor_SlipNoteFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_SlipNoteFuzzy.Visible = true;
                this.tComboEditor_SlipNoteFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;
                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SlipNoteTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_SlipNoteFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SlipNoteTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SlipNote);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SlipNote);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_SlipNoteFuzzy);
                if (!this.uCheckNote.Checked)
                {
                    tEdit_SlipNote.Text = string.Empty;
                    tComboEditor_SlipNoteFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srSlipNote = string.Empty;
                    _srRvSlipNote = string.Empty;
                }
            }
            #endregion // ���l

            #region �폜�w��敪
            // �폜�w��敪
            if (this.uCheckDeleteFlag_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tComboEditor_DeleteFlag))
                {
                    // �폜�w��敪
                    _logicalDelDiv = 0;
                    tComboEditor_DeleteFlag.SelectedIndex = 0;
                }

                // �폜�w��敪���x��
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_DeleteFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_DeleteFlagTitle);
                this.uLabel_DeleteFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_DeleteFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // �폜�w��敪�R���{�{�b�N�X
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_DeleteFlag);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_DeleteFlag);
                this.tComboEditor_DeleteFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_DeleteFlag.Visible = true;
                this.tComboEditor_DeleteFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_DeleteFlag.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_DeleteFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_DeleteFlag);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_DeleteFlagTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_DeleteFlag);
                if (!this.uCheckDeleteFlag.Checked)
                {
                    _logicalDelDiv = 0;
                    tComboEditor_DeleteFlag.SelectedIndex = 0;
                }
            }
            #endregion // �폜�w��敪

        }
        #endregion

        #region �\������Ă��鎟�̃R���g���[�����擾����
        /// <summary>
        /// �g����{�����ŁA�\������Ă��鎟�̃R���g���[�����擾����
        /// </summary>
        /// <remarks>
        /// <param name="controlName">controlName</param>
        /// <returns>���̃R���g���[��</returns>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// </remarks>
        private Control GetNextCommonControl(string controlName)
        {
            Control nextCtrl = null;

            // �o�ד�
            if (controlName == "tDateEdit_DateEd")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum_base.Checked) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetNextCommonControl("tEdit_StockMoveSlipNum");

            }

            // �`�[�ԍ�
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateSt_base.Checked) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetNextCommonControl("tDateEdit_AddUpADateSt");
            }

            // ���͓��J�n
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd_base.Checked) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetNextCommonControl("tDateEdit_AddUpADateEd");
            }

            // ���͓��I��
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd_base.Checked) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetNextCommonControl("tEdit_SalesEmployeeCd");
            }

            // �S����
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && String.IsNullOrEmpty(this.tEdit_SalesEmployeeCd.Text.Trim()) && this.uCheckSalesEmployeeCd_base.Checked)
                {
                    nextCtrl = this.uButton_SalesEmployeeCd;
                }
                else
                {
                    if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.tEdit_SupplierCd;
                    else nextCtrl = GetNextCommonControl("tEdit_SupplierCd");
                }
            }

            // �S���҃K�C�h
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetNextCommonControl("tEdit_SupplierCd");
            }

            // �d����
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && String.IsNullOrEmpty(this.tEdit_SupplierCd.Text.Trim()) && this.uCheckSupplierCd_base.Checked)
                {
                    nextCtrl = this.uButton_SupplierCd;
                }
                else
                {
                    if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.tEdit_MakerCd;
                    else nextCtrl = GetNextCommonControl("tEdit_MakerCd");
                }
            }

            // �d����K�C�h
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetNextCommonControl("tEdit_MakerCd");
            }

            // ���[�J�[�R�[�h
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && String.IsNullOrEmpty(this.tEdit_MakerCd.Text.Trim()) && this.uCheckGoodsMakerCd_base.Checked)
                {
                    nextCtrl = this.uButton_MakerCd;
                }
                else
                {
                    if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.tEdit_BlGoodsCode;
                    else nextCtrl = GetNextCommonControl("tEdit_BlGoodsCode");
                }
            }

            // ���[�J�[�K�C�h
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetNextCommonControl("tEdit_BlGoodsCode");
            }

            // BL�R�[�h
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && String.IsNullOrEmpty(this.tEdit_BlGoodsCode.Text.Trim()) && this.uCheckBLGoodsCode_base.Checked)
                {
                    nextCtrl = this.uButton_BlGoodsCode;
                }
                else
                {
                    if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tEdit_GoodsNo;
                    else nextCtrl = GetNextCommonControl("tEdit_GoodsNo");
                }
            }

            // BL�R�[�h�K�C�h
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetNextCommonControl("tEdit_GoodsNo");
            }

            // �i��
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_GoodsNo.Visible && String.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()) && this.uCheckGoodsNo_base.Checked)
                {
                    nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                }
                else
                {
                    if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tEdit_GoodsName;
                    else nextCtrl = GetNextCommonControl("tEdit_GoodsName");
                }
            }

            // �i�Ԃ����܂�����
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetNextCommonControl("tEdit_GoodsName");
            }

            // �i��
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsName.Visible && String.IsNullOrEmpty(this.tEdit_GoodsName.Text.Trim()) && this.uCheckGoodsName_base.Checked)
                {
                    nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                }
                else
                {
                    if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tEdit_WarehouseShelfNo;
                    else nextCtrl = GetNextCommonControl("tEdit_WarehouseShelfNo");
                }
            }

            // �i�������܂�����
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetNextCommonControl("tEdit_WarehouseShelfNo");
            }

            // �I��
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && String.IsNullOrEmpty(this.tEdit_WarehouseShelfNo.Text.Trim()) && this.uCheckWarehouseShelfNo_base.Checked)
                {
                    nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                }
                else
                {
                    if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.tEdit_AfSectionCode;
                    else nextCtrl = GetNextCommonControl("tEdit_AfSectionCode");
                }
            }

            // �I�Ԃ����܂�����
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetNextCommonControl("tEdit_AfSectionCode");
            }

            // ���苒�_
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()) && this.uCheckAfSectionCode_base.Checked)
                {
                    nextCtrl = this.uButton_AfSectionCode;
                }
                else
                {
                    if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.tEdit_AfEnterWarehCode;
                    else nextCtrl = GetNextCommonControl("tEdit_AfEnterWarehCode");
                }
            }

            // ���苒�_�K�C�h
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetNextCommonControl("tEdit_AfEnterWarehCode");
            }

            // ����q��
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfEnterWarehCode.Text.Trim()) && this.uCheckAfEnterWarehCode_base.Checked)
                {
                    nextCtrl = this.uButton_AfEnterWarehCode;
                }
                else
                {
                    if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag_base.Checked && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                    else nextCtrl = GetNextCommonControl("tComboEditor_ArrivalGoodsFlag");
                }
            }

            // ����q�ɃK�C�h
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag_base.Checked && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetNextCommonControl("tComboEditor_ArrivalGoodsFlag");
            }

            // ���׋敪
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetNextCommonControl("tEdit_SlipNote");
            }

            // ���l
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && String.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim()) && this.uCheckNote_base.Checked)
                {
                    nextCtrl = this.uButton_SlipNote;
                }
                else
                {
                    if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag_base.Checked) nextCtrl = this.tComboEditor_DeleteFlag;
                    else nextCtrl = GetNextCommonControl("tComboEditor_DeleteFlag");
                }
            }

            // ���l�K�C�h
            if (controlName == "uButton_SlipNote")
            {
                if (this.tComboEditor_SlipNoteFuzzy.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetNextCommonControl("tComboEditor_SlipNoteFuzzy");
            }

            // ���l�����܂�����
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag_base.Checked) nextCtrl = this.tComboEditor_DeleteFlag;
                else nextCtrl = GetNextCommonControl("tComboEditor_DeleteFlag");
            }

            // �폜�w��敪
            if (controlName == "tComboEditor_DeleteFlag")
            {
                // ���o����
                if (this.uExGroupBox_ExtraCondition.Visible)
                {
                    if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum.Checked && this.uCheckSalesSlipNum.Enabled == true)
                    {
                        nextCtrl = this.tEdit_StockMoveSlipNum;
                    }
                    else
                    {
                        //�g�����������̕\����Ԃ𒲂ׂĎ���
                        nextCtrl = this.GetNextControl("tEdit_StockMoveSlipNum");
                    }
                }
                //else nextCtrl = this.SearchOnChangeFocus(nextCtrl);
                else nextCtrl = uGrid_StockMove;
            }

            return nextCtrl;
        }

        /// <summary>
        /// �g�����������ŁA�\������Ă��鎟�̃R���g���[�����擾����
        /// </summary>
        /// <param name="controlName">controlName</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �g�����������ŁA�\������Ă��鎟�̃R���g���[�����擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control GetNextControl(string controlName)
        {
            Control nextCtrl = null;

            // �o�ד��i�I���j
            if (controlName == "tDateEdit_DateEd")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum.Checked && this.uCheckSalesSlipNum.Enabled == true) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetNextControl("tEdit_StockMoveSlipNum");
            }
            // �`�[�ԍ�
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateSt.Checked && this.uCheckAddUpADateSt.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetNextControl("tDateEdit_AddUpADateSt");
            }

            // ���͓��J�n
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd.Checked && this.uCheckAddUpADateEd.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetNextControl("tDateEdit_AddUpADateEd");
            }

            // ���͓��I��
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetNextControl("tEdit_SalesEmployeeCd");
            }

            // �S����
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && String.IsNullOrEmpty(this.tEdit_SalesEmployeeCd.Text.Trim()) &&
                    this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true)
                {
                    nextCtrl = this.uButton_SalesEmployeeCd;
                }
                else
                {
                    if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.tEdit_SupplierCd;
                    else nextCtrl = GetNextControl("tEdit_SupplierCd");
                }
            }

            // �S���҃K�C�h
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetNextControl("tEdit_SupplierCd");
            }

            // �d����
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && String.IsNullOrEmpty(this.tEdit_SupplierCd.Text.Trim()) &&
                    this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true)
                {
                    nextCtrl = this.uButton_SupplierCd;
                }
                else
                {
                    if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.tEdit_MakerCd;
                    else nextCtrl = GetNextControl("tEdit_MakerCd");
                }
            }

            // �d����K�C�h
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetNextControl("tEdit_MakerCd");
            }

            // ���[�J�[�R�[�h
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && String.IsNullOrEmpty(this.tEdit_MakerCd.Text.Trim()) &&
                    this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true)
                {
                    nextCtrl = this.uButton_MakerCd;
                }
                else
                {
                    if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.tEdit_BlGoodsCode;
                    else nextCtrl = GetNextControl("tEdit_BlGoodsCode");
                }
            }

            // ���[�J�[�K�C�h
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetNextControl("tEdit_BlGoodsCode");
            }

            // BL�R�[�h
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && String.IsNullOrEmpty(this.tEdit_BlGoodsCode.Text.Trim()) &&
                    this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true)
                {
                    nextCtrl = this.uButton_BlGoodsCode;
                }
                else
                {
                    if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tEdit_GoodsNo;
                    else nextCtrl = GetNextControl("tEdit_GoodsNo");
                }
            }

            // BL�R�[�h�K�C�h
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetNextControl("tEdit_GoodsNo");
            }

            // �i��
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_GoodsNo.Visible && String.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()) &&
                    this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true)
                {
                    nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                }
                else
                {
                    if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tEdit_GoodsName;
                    else nextCtrl = GetNextControl("tEdit_GoodsName");
                }
            }

            // �i�Ԃ����܂�����
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetNextControl("tEdit_GoodsName");
            }

            // �i��
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsName.Visible && String.IsNullOrEmpty(this.tEdit_GoodsName.Text.Trim()) &&
                    this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true)
                {
                    nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                }
                else
                {
                    if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tEdit_WarehouseShelfNo;
                    else nextCtrl = GetNextControl("tEdit_WarehouseShelfNo");
                }
            }

            // �i�������܂�����
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetNextControl("tEdit_WarehouseShelfNo");
            }

            // �I��
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && String.IsNullOrEmpty(this.tEdit_WarehouseShelfNo.Text.Trim()) &&
                    this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true)
                {
                    nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                }
                else
                {
                    if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.tEdit_AfSectionCode;
                    else nextCtrl = GetNextControl("tEdit_AfSectionCode");
                }
            }

            // �I�Ԃ����܂�����
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_AfSectionCode.Visible && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetNextControl("tEdit_AfSectionCode");
            }

            // ���苒�_
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()) &&
                    this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true)
                {
                    nextCtrl = this.uButton_AfSectionCode;
                }
                else
                {
                    if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.tEdit_AfEnterWarehCode;
                    else nextCtrl = GetNextControl("tEdit_AfEnterWarehCode");
                }
            }

            // ���苒�_�K�C�h
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetNextControl("tEdit_AfEnterWarehCode");
            }

            // ����q��
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfEnterWarehCode.Text.Trim()) &&
                    this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true)
                {
                    nextCtrl = this.uButton_AfEnterWarehCode;
                }
                else
                {
                    if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag.Checked && this.uCheckArrivalGoodsFlag.Enabled == true && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                    else nextCtrl = GetNextControl("tComboEditor_ArrivalGoodsFlag");
                }
            }

            // ����q�ɃK�C�h
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag.Checked && this.uCheckArrivalGoodsFlag.Enabled == true && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetNextControl("tComboEditor_ArrivalGoodsFlag");
            }

            // ���׋敪
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetNextControl("tEdit_SlipNote");
            }

            // ���l
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && String.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim()) &&
                    this.uCheckNote.Checked && this.uCheckNote.Enabled == true)
                {
                    nextCtrl = this.uButton_SlipNote;
                }
                else
                {
                    if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag.Checked && this.uCheckDeleteFlag.Enabled == true) nextCtrl = this.tComboEditor_DeleteFlag;
                    else nextCtrl = GetNextControl("tComboEditor_DeleteFlag");
                }
            }

            // ���l�K�C�h
            if (controlName == "uButton_SlipNote")
            {
                if (this.tComboEditor_SlipNoteFuzzy.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetNextControl("tComboEditor_SlipNoteFuzzy");
            }

            // ���l�����܂�����
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag.Checked && this.uCheckDeleteFlag.Enabled == true) nextCtrl = this.tComboEditor_DeleteFlag;
                else nextCtrl = GetNextControl("tComboEditor_DeleteFlag");
            }

            // �폜�w��敪
            if (controlName == "tComboEditor_DeleteFlag")
            {
                // �������s�E�t�H�[�J�X�ړ�
                nextCtrl = uGrid_StockMove;
            }
            return nextCtrl;
        }
        #endregion // �\������Ă��鎟�̃R���g���[�����擾����

        #region �\������Ă���O�̃R���g���[�����擾����
        /// <summary>
        /// �g����{�����ŁA�\������Ă���O�̃R���g���[�����擾����
        /// </summary>
        /// <param name="controlName">controlName</param>
        /// <returns>�O�̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �g����{�����ŁA�\������Ă���O�̃R���g���[�����擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control GetBeforeCommonControl(string controlName)
        {
            Control nextCtrl = null;

            // �`�[�ԍ�
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                nextCtrl = this.tDateEdit_DateEd;
            }

            // ���͓��J�n
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum_base.Checked) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetBeforeCommonControl("tEdit_StockMoveSlipNum");
            }

            // ���͓��I��
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateSt_base.Checked) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetBeforeCommonControl("tDateEdit_AddUpADateSt");
            }

            // �S����
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd_base.Checked) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetBeforeCommonControl("tDateEdit_AddUpADateEd");
            }

            // �S���҃K�C�h
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd_base.Checked) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SalesEmployeeCd");
            }

            // �d����
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd_base.Checked) nextCtrl = this.uButton_SalesEmployeeCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SalesEmployeeCd");
            }

            // �d����K�C�h
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SupplierCd");
            }

            // ���[�J�[�R�[�h
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.uButton_SupplierCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SupplierCd");
            }

            // ���[�J�[�K�C�h
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_MakerCd");
            }

            // BL�R�[�h
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.uButton_MakerCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_MakerCd");
            }

            // BL�R�[�h�K�C�h
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_BlGoodsCode");
            }

            // �i��
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.uButton_BlGoodsCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_BlGoodsCode");
            }

            // �i�Ԃ����܂�����
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsNo");
            }

            // �i��
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsNo");
            }

            // �i�������܂�����
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsName");
            }

            // �I��
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsName");
            }

            // �I�Ԃ����܂�����
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetBeforeCommonControl("tEdit_WarehouseShelfNo");
            }

            // ���苒�_
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_WarehouseShelfNo");
            }

            // ���苒�_�K�C�h
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfSectionCode");
            }

            // ����q�ɃR�[�h
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.uButton_AfSectionCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfSectionCode");
            }

            // ����q�ɃK�C�h
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfEnterWarehCode");
            }

            // ���׋敪
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.uButton_AfEnterWarehCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfEnterWarehCode");
            }

            // ���l
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag_base.Checked && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetBeforeCommonControl("tComboEditor_ArrivalGoodsFlag");
            }

            // ���l�K�C�h
            if (controlName == "uButton_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetBeforeCommonControl("tEdit_SlipNote");
            }

            // ���l�����܂�����
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.uButton_SlipNote;
                else nextCtrl = GetBeforeCommonControl("tEdit_SlipNote");
            }

            // ���׋敪
            if (controlName == "tComboEditor_DeleteFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_SlipNote");
            }
            return nextCtrl;
        }

        /// <summary>
        /// �g�����o�����ŁA�\������Ă���O�̃R���g���[�����擾����
        /// </summary>
        /// <param name="controlName">controlName</param>
        /// <returns>�O�̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �g�����o�����ŁA�\������Ă���O�̃R���g���[�����擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control GetBeforeControl(string controlName)
        {
            Control nextCtrl = null;

            // �`�[�ԍ�
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                // ��{����
                if (this.uExGroupBox_CommonCondition.Visible)
                {
                    if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag_base.Checked)
                    {
                        nextCtrl = this.tComboEditor_DeleteFlag;
                    }
                    else
                    {
                        //�g�����������̕\����Ԃ𒲂ׂĎ���
                        nextCtrl = this.GetBeforeCommonControl("tComboEditor_DeleteFlag");
                    }
                }
                else nextCtrl = null;
            }

            // ���͓��J�n
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum.Checked && this.uCheckSalesSlipNum.Enabled == true) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetBeforeControl("tEdit_StockMoveSlipNum");
            }

            // ���͓��I��
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateEd.Checked && this.uCheckAddUpADateEd.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetBeforeControl("tDateEdit_AddUpADateSt");
            }

            // �S����
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd.Checked && this.uCheckAddUpADateEd.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetBeforeControl("tDateEdit_AddUpADateEd");
            }

            // �S���҃K�C�h
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetBeforeControl("tEdit_SalesEmployeeCd");
            }

            // �d����
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true) nextCtrl = this.uButton_SalesEmployeeCd;
                else nextCtrl = GetBeforeControl("tEdit_SalesEmployeeCd");
            }

            // �d����K�C�h
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetBeforeControl("tEdit_SupplierCd");
            }

            // ���[�J�[�R�[�h
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.uButton_SupplierCd;
                else nextCtrl = GetBeforeControl("tEdit_SupplierCd");
            }

            // ���[�J�[�K�C�h
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetBeforeControl("tEdit_MakerCd");
            }

            // BL�R�[�h
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.uButton_MakerCd;
                else nextCtrl = GetBeforeControl("tEdit_MakerCd");
            }

            // BL�R�[�h�K�C�h
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetBeforeControl("tEdit_BlGoodsCode");
            }

            // �i��
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.uButton_BlGoodsCode;
                else nextCtrl = GetBeforeControl("tEdit_BlGoodsCode");
            }

            // �i�Ԃ����܂�����
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetBeforeControl("tEdit_GoodsNo");
            }

            // �i��
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_GoodsNo");
            }

            // �i�������܂�����
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetBeforeControl("tEdit_GoodsName");
            }

            // �I��
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_GoodsName");
            }

            // �I�Ԃ����܂�����
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetBeforeControl("tEdit_WarehouseShelfNo");
            }

            // ���苒�_
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_WarehouseShelfNo");
            }

            // ���苒�_�K�C�h
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetBeforeControl("tEdit_AfSectionCode");
            }

            // ����q��
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.uButton_AfSectionCode;
                else nextCtrl = GetBeforeControl("tEdit_AfSectionCode");
            }

            // ����q�ɃK�C�h
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetBeforeControl("tEdit_AfEnterWarehCode");
            }

            // ���׋敪
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.uButton_AfEnterWarehCode;
                else nextCtrl = GetBeforeControl("tEdit_AfEnterWarehCode");
            }

            // ���l
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag.Checked && this.uCheckArrivalGoodsFlag.Enabled == true && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetBeforeControl("tComboEditor_ArrivalGoodsFlag");
            }

            // ���l�K�C�h
            if (controlName == "uButton_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetBeforeControl("tEdit_SlipNote");
            }


            // ���l�����܂�����
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.uButton_SlipNote;
                else nextCtrl = GetBeforeControl("tEdit_SlipNote");
            }

            // �폜�w��敪
            if (controlName == "tComboEditor_DeleteFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_SlipNote");
            }
            return nextCtrl;
        }

        #endregion // �\������Ă���O�̃R���g���[�����擾����

        # region [�����܂������p�e�L�X�g��������]
        /// <summary>
        /// �����܂������p�e�L�X�g��������
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="searchText"></param>
        /// <param name="fuzzyValue"></param>
        /// <remarks>
        /// <br>Note       : �����܂������p�e�L�X�g���������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void GetFuzzyInput(string inputValue, out string searchText, out int fuzzyValue)
        {
            if (!string.IsNullOrEmpty(inputValue))
            {
                fuzzyValue = 0;     // �R���{�{�b�N�X�̒l

                if (!inputValue.Contains("*"))
                {
                    // [*]�Ȃ��i�u�ƈ�v�v�j
                    fuzzyValue = CT_FUZZY_MATCHWITH;
                }
                else if (inputValue.StartsWith("*") && inputValue.EndsWith("*"))
                {
                    // [*]�c[*]�i�u���܂ށv�j
                    fuzzyValue = CT_FUZZY_INCLUDEWITH;
                }
                else if (inputValue.StartsWith("*"))
                {
                    // [*]�c�i�u�ŏI��v�j
                    fuzzyValue = CT_FUZZY_ENDWITH;
                }
                else if (inputValue.EndsWith("*"))
                {
                    // �c[*]�i�u�Ŏn��v�j
                    fuzzyValue = CT_FUZZY_STARTWITH;
                }
                searchText = inputValue.Replace("*", ""); // [*]����������
            }
            else
            {
                // �N���A
                searchText = string.Empty;
                fuzzyValue = 0;
            }
        }
        # endregion

        # region [�����܂������p�e�L�X�g�ϊ�����] 
        /// <summary>
        /// �����܂������p�e�L�X�g�ϊ�����
        /// </summary>
        /// <param name="fuzzyValue"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����܂������p�e�L�X�g�ϊ������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetFuzzyInputOnChangeFuzzyValue(int fuzzyValue, string searchValue)
        {
            string fullValue = searchValue;

            switch (fuzzyValue)
            {
                // ���S��v
                case CT_FUZZY_MATCHWITH:
                default:
                    fullValue = searchValue;
                    break;
                // �����܂�
                case CT_FUZZY_INCLUDEWITH:
                    fullValue = "*" + searchValue + "*";
                    break;
                // �����v
                case CT_FUZZY_ENDWITH:
                    fullValue = "*" + searchValue;
                    break;
                // �O����v
                case CT_FUZZY_STARTWITH:
                    fullValue = searchValue + "*";
                    break;
            }

            return fullValue;
        }
        # endregion        

        #region ���̎擾
        #region ���͋��_
        /// <summary>
        /// ���͋��_���̎擾����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���͋��_���̎擾�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadInputSectionCodeAllowZeroName(out string code, out string name)
        {
            // ���͒l���擾
            string sectionCode = this.tEdit_InputSectionCode.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = ultraLabel_InputSectionName.Text;

            if (_prevInputValue.InputSectionCode == sectionCode)
            {
                this.tEdit_InputSectionCode.Text = sectionCode;
                return true;
            }

            // 00:�S��
            if (sectionCode == "00")
            {
                sectionCode = "00";
                _prevInputValue.InputSectionCode = sectionCode;
                code = sectionCode;
                name = "�S��";
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // ���_�����擾
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                {

                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    _prevInputValue.InputSectionCode = code;
                    return true;
                }
                else
                {
                    _isError = true;
                    code = uiSetControl1.GetZeroPadCanceledText("tEdit_InputSectionCode", _prevInputValue.InputSectionCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.InputSectionCode = code;
                return true;
            }
        }
        #endregion

        #region �o�ɋ��_
        /// <summary>
        /// �o�ɋ��_���̎擾����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �o�ɋ��_���̎擾�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSectionCodeAllowZeroName(out string code, out string name)
        {
            // ���͒l���擾
            string sectionCode = this.tEdit_SecCd.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = ultraLabel_SecName.Text;

            if (_prevInputValue.SectionCode == sectionCode)
            {
                this.tEdit_SecCd.Text = sectionCode;
                return true;
            }

            // 00:�S��
            if (sectionCode == "00")
            {
                sectionCode = "00";
                _prevInputValue.SectionCode = sectionCode;
                code = sectionCode;
                name = "�S��";
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // ���_�����擾
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                {

                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    _prevInputValue.SectionCode = code;
                    return true;
                }
                else
                {
                    _isError = true;
                    code = uiSetControl1.GetZeroPadCanceledText("tEdit_SecCd", _prevInputValue.SectionCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.SectionCode = code;
                return true;
            }
        }
        #endregion

        #region �o�ɑq��
        /// <summary>
        /// �q�ɖ��̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̎擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadWarehouseName(out string code, out string name)
        {
            // ���͒l���擾
            string inputValue = this.tEdit_WarehouseCd.Text.Trim().PadLeft(4, '0');
            code = inputValue;
            name = ultraLabel_WarehouseName.Text;

            // ��łȂ���Ώ����J�n
            if ("0000".Equals(inputValue))
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.WarehouseCode = code;
                return true;
            }
            else if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != _prevInputValue.WarehouseCode)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        Warehouse warehouseInfo;
                        int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInfo.LogicalDeleteCode == 0)
                        {
                            code = warehouseInfo.WarehouseCode.Trim();
                            name = warehouseInfo.WarehouseName;
                            _prevInputValue.WarehouseCode = code;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // �߂�
                            code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _prevInputValue.WarehouseCode);
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _prevInputValue.WarehouseCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.WarehouseCode = code;
                return true;
            }
        }
        #endregion // �o�ɑq��

        #region �S����
        /// <summary>
        /// �S���Җ��̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �S���Җ��̎擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSalesEmployeeName(out string code)
        {
            // ���͒l���擾
            string inputValue = this.tEdit_SalesEmployeeCd.Text.Trim();
            code = inputValue;

            // ��łȂ���Ώ����J�n
            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swSalesEmployeeCd)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        Employee employeeInfo;
                        int status = this._employeeAcs.Read(out employeeInfo, this._enterpriseCode, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInfo.LogicalDeleteCode == 0)
                        {
                            this._swSalesEmployeeCd = inputValue;
                            this._swSalesEmployeeName = employeeInfo.Name;
                            code = _swSalesEmployeeCd;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // �߂�
                            code = uiSetControl1.GetZeroPadCanceledText(tEdit_SalesEmployeeCd.Name, _swSalesEmployeeCd);
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = uiSetControl1.GetZeroPadCanceledText(tEdit_SalesEmployeeCd.Name, _swSalesEmployeeCd);
                    return false;
                }
            }
            else
            {
                this._swSalesEmployeeCd = string.Empty;
                this._swSalesEmployeeName = string.Empty;
                code = _swSalesEmployeeCd;
                return true;
            }
        }

        /// <summary>
        /// �S���ғ��͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �S���ғ��͗�Enter�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_SalesEmployeeCd_Enter(object sender, System.EventArgs e)
        {
            // �S���҃R�[�h���ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._swSalesEmployeeCd))
            {
                this.tEdit_SalesEmployeeCd.Text = this._swSalesEmployeeCd.Trim();
            }
        }

        #endregion // �S����

        #region BL�R�[�h 
        /// <summary>
        /// BL�R�[�h���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̎擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadBlCodeName(out int code)
        {
            // ���͒l���擾
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_BlGoodsCode.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // ��łȂ���Ώ����J�n
            if (inputValue != 0)
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swBLGoodsCode)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        BLGoodsCdUMnt blGoodsCd;
                        int status = _blGoodsCdAcs.Read(out blGoodsCd, this._enterpriseCode, inputValue);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCd.LogicalDeleteCode == 0)
                        {
                            this._swBLGoodsCode = inputValue;
                            this._swBLGoodsName = blGoodsCd.BLGoodsHalfName;
                            code = _swBLGoodsCode;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // �߂�
                            code = _swBLGoodsCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = _swBLGoodsCode;
                    return false;
                }
            }
            else
            {
                this._swBLGoodsCode = 0;
                this._swBLGoodsName = string.Empty;
                code = _swBLGoodsCode;
                return true;
            }
        }

        /// <summary>
        /// BL�R�[�h���͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���͗�Enter�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_BlGoodsCode_Enter(object sender, System.EventArgs e)
        {
            // BL�R�[�h���ۑ�����Ă���Βu������
            if (this._swBLGoodsCode > 0)
            {
                this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString();
            }

        }

        #endregion

        #region ���[�J�[ 
        /// <summary>
        /// ���[�J�[���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̎擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadGoodsMakerName(out int code)
        {
            // ���͒l���擾
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_MakerCd.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // ��łȂ���Ώ����J�n
            if (inputValue != 0)
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swGoodsMakerCd)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        MakerUMnt makerInfo;
                        int status = this._makerAcs.Read(out makerInfo, this._enterpriseCode, inputValue);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerInfo.LogicalDeleteCode == 0)
                        {
                            this._swGoodsMakerCd = inputValue;
                            this._swGoodsMakerName = makerInfo.MakerKanaName;
                            code = _swGoodsMakerCd;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // �߂�
                            code = _swGoodsMakerCd;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = _swGoodsMakerCd;
                    return false;
                }
            }
            else
            {
                this._swGoodsMakerCd = 0;
                this._swGoodsMakerName = string.Empty;
                code = _swGoodsMakerCd;
                return true;
            }
        }

        /// <summary>
        /// ���[�J�[���͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���[�J�[���͗�Enter�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_MakerCd_Enter(object sender, System.EventArgs e)
        {
            // ���[�J�[�R�[�h���ۑ�����Ă���Βu������
            if (this._swGoodsMakerCd > 0)
            {
                this.tEdit_MakerCd.Text = this._swGoodsMakerCd.ToString();
            }
        }

        #endregion // ���[�J�[

        #region �d���� 
        /// <summary>
        /// �d���於�̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �d���於�̎擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSupplierName(out int code)
        {
            // ���͒l���擾
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_SupplierCd.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // ��łȂ���Ώ����J�n
            if (inputValue != 0)
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swSupplierCd)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        Supplier supplierInfo;
                        int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInfo.LogicalDeleteCode == 0)
                        {
                            this._swSupplierCd = inputValue;
                            // �d����}�X�^.�d���旪�̂����͂���Ă����ꍇ�ɂ͎d����}�X�^.�d���旪�̂�\��
                            if (!string.IsNullOrEmpty(supplierInfo.SupplierSnm))
                            {
                                this._swSupplierName = supplierInfo.SupplierSnm;
                            }
                            // �d����}�X�^.�d���旪�̂������͂̏ꍇ�ɂ͎d����}�X�^.�d���於1��\��
                            else if (!string.IsNullOrEmpty(supplierInfo.SupplierNm1))
                            {
                                this._swSupplierName = supplierInfo.SupplierNm1;
                            }
                            // �d����}�X�^.�d���於��1�������͂̏ꍇ�ɂ͎d����}�X�^.�d����J�i��\��
                            else
                            {
                                this._swSupplierName = supplierInfo.SupplierKana;
                            }
                            code = _swSupplierCd;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // �߂�
                            code = _swSupplierCd;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = _swSupplierCd;
                    return false;
                }
            }
            else
            {
                this._swSupplierCd = 0;
                this._swSupplierName = string.Empty;
                code = _swSupplierCd;
                return true;
            }
        }

        /// <summary>
        /// �d������͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �d������͗�Enter�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_SupplierCd_Enter(object sender, System.EventArgs e)
        {
            // �d����R�[�h���ۑ�����Ă���Βu������
            if (this._swSupplierCd > 0)
            {
                this.tEdit_SupplierCd.Text = this._swSupplierCd.ToString();
            }
        }

        #endregion // �d����

        #region ���苒�_ 
        /// <summary>
        /// ���苒�_���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <br>Note       : ���苒�_���̎擾</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        //private bool ReadAfSectionName(out int code) // DEL 2010/05/18
        private bool ReadAfSectionName(out string code) // ADD 2010/05/18
        {
            // ���͒l���擾
            //int inputValue; // DEL 2010/05/18
            string inputValue; // ADD 2010/05/18
            try
            {
                //inputValue = Int32.Parse(this.tEdit_AfSectionCode.Text.Trim()); // DEL 2010/05/18
                inputValue = this.tEdit_AfSectionCode.Text.Trim(); // ADD 2010/05/18
            }
            catch
            {
                //inputValue = 0; // DEL 2010/05/18
                inputValue = string.Empty; // ADD 2010/05/18
            }
            code = inputValue;

            // ��łȂ���Ώ����J�n
            //if (inputValue != 0) // DEL 2010/05/18
            if (!string.IsNullOrEmpty(inputValue)) // ADD 2010/05/18
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swAfSectionCode)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        SecInfoSet sectionInfo;
                        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this.tEdit_AfSectionCode.Text.Trim().PadLeft(2, '0'));
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                        {
                            this._swAfSectionCode = inputValue;
                            this._swAfSectionName = sectionInfo.SectionGuideNm;
                            code = _swAfSectionCode;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // �߂�
                            code = _swAfSectionCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = _swAfSectionCode;
                    return false;
                }
            }
            else
            {
                //TODO:��ꍇ�A[00:�S��]��\������
                //this._swAfSectionCode = 0; // DEL 2010/05/18
                this._swAfSectionCode = string.Empty; // ADD 2010/05/18
                this._swAfSectionName = "�S��";
                code = _swAfSectionCode;
                return true;
            }
        }

        /// <summary>
        /// ���苒�_����Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : ���苒�_����Enter�C�x���g</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_AfSectionCode_Enter(object sender, System.EventArgs e)
        {
            // ���苒�_�R�[�h���ۑ�����Ă���Βu������
            //if (this._swAfSectionCode > 0) // ADD 2010/05/18
            if (!string.IsNullOrEmpty(this._swAfSectionCode)) // DEL 2010/05/18
            {
                //this.tEdit_AfSectionCode.Text = this._swAfSectionCode.ToString(); // DEL 2010/05/18
                this.tEdit_AfSectionCode.Text = this._swAfSectionCode; // ADD 2010/05/18
            }
        }

        #endregion // �d����

        #region ����q��
        /// <summary>
        /// �q�ɖ��̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <br>Note       : �q�ɖ��̎擾</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool ReadAfEnterWarehName(out string code)
        {
            // ���͒l���擾
            string inputValue;
            try
            {
                inputValue = this.tEdit_AfEnterWarehCode.Text.Trim();
            }
            catch
            {
                inputValue = string.Empty;
            }
            code = inputValue;
            // ��łȂ���Ώ����J�n
            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swAfEnterWarehCode)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        Warehouse warehouseInfo;
                        //int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, inputValue); // DEL 2010/05/18
                        int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, this.tEdit_AfEnterWarehCode.Text.Trim().PadLeft(4, '0')); // ADD 2010/05/18
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInfo.LogicalDeleteCode == 0)
                        {
                            this._swAfEnterWarehCode = inputValue;
                            this._swAfEnterWarehName = warehouseInfo.WarehouseName;
                            code = _swAfEnterWarehCode;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // �߂�
                            code = _swAfEnterWarehCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = _swAfEnterWarehCode;
                    return false;
                }
            }
            else
            {
                this._swAfEnterWarehCode = string.Empty;
                this._swAfEnterWarehName = string.Empty;
                code = _swAfEnterWarehCode;
                return true;
            }
        }

        /// <summary>
        /// �q�ɓ��͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : �q�ɓ��͗�Enter�C�x���g</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_AfEnterWarehCode_Enter(object sender, System.EventArgs e)
        {
            // �q�ɃR�[�h���ۑ�����Ă���Βu������
            if (!string.IsNullOrEmpty(this._swAfEnterWarehCode))
            {
                this.tEdit_AfEnterWarehCode.Text = this._swAfEnterWarehCode;
            }
        }

        #endregion // ����q��
        #endregion // ���̎擾                

        /// <summary>
        /// ���t�͈̓`�F�b�N�����i�`�[�E���ג��o�̔�����t�E���͓��t�p�j
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <param name="result"></param>
        /// <param name="allowNoInput"></param>
        /// <returns></returns>
        /// <br>Note       : ���t�͈̓`�F�b�N����</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool CheckDateRangeForSlip(ref TDateEdit stEdit, ref TDateEdit edEdit, out DateGetAcs.CheckDateRangeResult result, bool allowNoInput)
        {
            int range = 3;
            if (allowNoInput) range = 0;

            result = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref stEdit, ref edEdit, allowNoInput);
            return (result == DateGetAcs.CheckDateRangeResult.OK);
        }

        #region ���I�v�V������񐧌䏈��

        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V�������L���b�V���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20966</br>
        /// <br></br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            #region �� �e�L�X�g�o�̓I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TextOutput = (int)Option.ON;
            }
            else
            {
                this._opt_TextOutput = (int)Option.OFF;
            }
            #region[�e�L�X�g�o�́AExcel�o��]
            //�e�L�X�g�o�̓I�v�V�������L���̏ꍇ
            if (this._opt_TextOutput == (int)Option.ON)
            {
                // �e�L�X�g�o�̓Z�L�����e�B����
                if (OpeAuthDictionary[OperationCode.TextOut])
                {
                    // �e�L�X�g�o��
                    this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Visible = true;
                    //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                    this._settingForm.uTabControlSet(true);
                }
                else
                {
                    // �e�L�X�g�o��
                    this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
                    //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                    this._settingForm.uTabControlSet(false);
                }
                // EXCEL�o�̓Z�L�����e�B����
                if (OpeAuthDictionary[OperationCode.ExcelOut])
                {
                    // EXCEL�o��
                    this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = true;
                    //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                    //this._settingForm.uTabControlSet(true); // DEL 2011/05/11 tianjw
                }
                else
                {
                    // EXCEL�o��
                    this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = false;
                    //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                    //this._settingForm.uTabControlSet(false); // DEL 2011/05/11 tianjw
                }
            }
            //�e�L�X�g�o�̓I�v�V�����������̏ꍇ
            else
            {
                // �e�L�X�g�o��
                this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
                // EXCEL�o��
                this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = false;
                //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                this._settingForm.uTabControlSet(false);
            }
            #endregion

            #endregion

            //if (!OpeAuthDictionary[OperationCode.ReissueSlip])
            //{
            //    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Visible = false;
            //    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Shortcut = Shortcut.None;
            //}

        }
        #endregion ���I�v�V������񐧌䏈��
    
    �@�@/// <summary>
        /// ���ו\���ݒ菉�����C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���ו\���ݒ菉�����C�x���g�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SettingForm_ClearSettingStockMoveGrid(object sender, EventArgs e)
        {
            InitializeGridColumns(this.uGrid_StockMove.DisplayLayout.Bands[0].Columns);
            LoadGridColumnsSetting(ref uGrid_StockMove, _settingForm.UserSetting.StockMoveColumnsList);

            autoColumnAdjust(this._columnWidthAutoAdjust);
        }

        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�J�������̓ǂݍ��݁B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // �J�����ݒ����\�����Ń\�[�g����
            settingList.Sort(new ColumnInfoComparer());

            // ��x�A�S�ẴJ������Fixed����������
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;

                    if (this._stockMoveFixCode == 1)
                    {
                        switch (columnInfo.ColumnName)
                        {
                            case "StockMoveFormalDisplay":
                            case "UpdateSecCd":
                            case "UpdateSecGuideSnm":
                                {
                                    ultraGridColumn.Hidden = true;
                                    break;
                                }
                            default:
                                {
                                    ultraGridColumn.Hidden = columnInfo.Hidden;
                                    break;
                                } 
                        }
                    }
                    else
                    {
                        switch (columnInfo.ColumnName)
                        {
                            case "MoveStatus":
                            case "ShipmentFixDay":
                            case "ArrivalGoodsDay":
                                {
                                    ultraGridColumn.Hidden = true;
                                    break;
                                }
                            default:
                                {
                                    ultraGridColumn.Hidden = columnInfo.Hidden;
                                    break;
                                } 
                        }
                    }

                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }

            // ����ъ�����A�܂Ƃ߂�Fixed��ݒ肷��B
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        /// <param name="Columns"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h��̏������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 ��r�� �d����Ǝd���於��ǉ����܂�</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // �\���`���̂����Ŏg�p
            string formatCurrency = "#,##0;-#,##0;";
            string formatFraction = "#,##0.00;-#,##0.00;";
            string formatDate = "yyyy/MM/dd";
            string formatSlipNo = "000000000";
            string formatSectionCode = "0#";
            string formatWarehCode = "000#";

            // �\���ʒu�����l
            int visiblePosition = 1;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                column.Header.Fixed = false;
            }

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            // �I���`�F�b�N�{�b�N�X
            // �J�����`���[�U�F�ΏۊO�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Hidden = false;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Width = 50;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.Caption = "�I��";

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].CellAppearance.BackColor = _margedCellAppearance.BackColor;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].CellAppearance.BackColor2 = _margedCellAppearance.BackColor2;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.Fixed = true;

            // �sNo
            // ��\��
            // �J�����`���[�U�F�ΏۊO�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].Hidden = true;
            Columns[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;

            // �`�[���t
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���t�iyyyy/mm/dd�j
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            // �݌Ɉړ��m��敪�����׊m�肠��̏ꍇ
            if (this._stockMoveFixCode == 1)
            {
                if (this._stockMoveDataSet.StockMoveDetail.Rows.Count == 0) {
                    Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
                }
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else if (this._stockMoveFixCode == 2)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "�`�[���t";
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Fixed = true;
            SettingMergedCell(Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName]);

            // �`�[�ԍ�
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Format = formatSlipNo;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.Fixed = true;
            SettingMergedCell(Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName]);


            // �sNo
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Width = 40;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Header.Caption = "�sNo";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �敪�R�[�h
            // �J�����`���[�U�F�ΏۊO�@�t�H�[�}�b�g�F��\��
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName].Hidden = true;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;

            // �敪�\��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Width = 70;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Header.Caption = "�敪";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �S���Җ�
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Header.Caption = "�S���Җ�";
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���[�J�[�R�[�h
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���l�����\���͒ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "���[�J�[�R�[�h";
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Format = GetMakerFormat();

            // ���[�J�[
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Header.Caption = "���[�J�[��";
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            
            // ADD 2011/05/20 -------------------------------->>>>>>
            // �d����R�[�h
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���l�����\���͒ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Format = GetFormat("tEdit_SupplierCd");

            // ���[�J�[
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Header.Caption = "�d���於";
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // ADD 2011/05/20 --------------------------------<<<<<<

            // BL�R�[�h
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Width = 90;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����";
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Format = GetBLCodeFormat();

            // �ړ��P��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���z
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Format = formatFraction;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Header.Caption = "�ړ��P��";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ����
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���l
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Width = 70;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Format = formatFraction;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Header.Caption = "����";
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �W�����i
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���z
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Format = formatCurrency;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Header.Caption = "�W�����i";
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �ړ����z�i���ׁj
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���z
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Format = formatCurrency;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Header.Caption = "�ړ����z";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���͋��_�R�[�h
            // �J�����`���[�U�F�ΏۊO�@�t�H�[�}�b�g�F�R�[�h
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Format = formatSectionCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Header.Caption = "���͋��_�R�[�h";
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            // ���͋��_��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Header.Caption = "���͋��_��";
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �o�ɋ��_�R�[�h
            // �J�����`���[�U�F�ΏۊO�@�t�H�[�}�b�g�F�R�[�h
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Format = formatSectionCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Header.Caption = "�o�ɋ��_�R�[�h";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �o�ɋ��_��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Header.Caption = "�o�ɋ��_��";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �o�ɑq�ɃR�[�h
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Format = formatWarehCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Header.Caption = "�o�ɑq��";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �o�ɑq�ɖ�
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Header.Caption = "�o�ɑq�ɖ�";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �o�ɒI��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Header.Caption = "�o�ɒI��";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ɋ��_�R�[�h
            // �J�����`���[�U�F�ΏۊO�@�t�H�[�}�b�g�F�R�[�h
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Format = formatSectionCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Header.Caption = "���ɋ��_�R�[�h";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ɋ��_��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Header.Caption = "���ɋ��_��";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ɑq�ɃR�[�h
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Format = formatWarehCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Header.Caption = "���ɑq��";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ɑq�ɖ�
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Header.Caption = "���ɑq�ɖ�";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ɒI��
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Header.Caption = "���ɒI��";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���׋敪
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Header.Caption = "���׋敪";
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �o�ד�
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���t�iyyyy/mm/dd�j
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Header.Caption = "�o�ד�";
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ד�
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���t�iyyyy/mm/dd�j
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            // �݌Ɉړ��m��敪�����׊m��Ȃ��̏ꍇ
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Header.Caption = "���ד�";
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���͓�
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���t�iyyyy/mm/dd�j
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Header.Caption = "���͓�";
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���l
            // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F�ʏ�
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Header.Caption = "���l";
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            //--------------------------------------------------------------------------------
            //  �J�����`���[�U��L���ɂ���
            //--------------------------------------------------------------------------------
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorWidth = 24;
            _gridColumnChooserControl.Add(this.uGrid_StockMove);

            // �J�����`���[�U�{�^���̊O�ς�ݒ�		
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
            this.uGrid_StockMove.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // �񕝎���������ݒ�l�ɂ��������čs��
            autoColumnAdjust(_columnWidthAutoAdjust);

        }

        /// <summary>
        /// �Z�������ݒ菈��
        /// </summary>
        /// <param name="column"></param>
        /// <remarks>
        /// <br>Note       : �Z�������ݒ菈���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SettingMergedCell(Infragistics.Win.UltraWinGrid.UltraGridColumn column)
        {
            //--------------------------------------------------
            // CellAppearance�������I�ɓ��ꂷ��
            //--------------------------------------------------
            column.MergedCellAppearance = _margedCellAppearance;
            column.CellAppearance.BackColor = _margedCellAppearance.BackColor;
            column.CellAppearance.BackColor2 = _margedCellAppearance.BackColor2;
            column.CellAppearance.TextVAlign = VAlign.Top;

            //--------------------------------------------------
            // �Z�������ݒ�
            //--------------------------------------------------
            column.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            column.MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText;
            column.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;

            // �Z����������N���X
            CustomMergedCellEvaluator customMergedCellEvaluator = new CustomMergedCellEvaluator();

            if (column.Key == _stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName)
            {
                // ���t
                customMergedCellEvaluator.JoinColList.Add(_stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName);
            }
            else
            {
                // �`�[�ԍ�
                customMergedCellEvaluator.JoinColList.Add(_stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName);
                // (�`�[�敪)
                customMergedCellEvaluator.JoinColList.Add(_stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName);
            }
            column.MergedCellEvaluator = customMergedCellEvaluator;
        }

        # region [�O���b�h�Z����������N���X]
        /// <summary>
        /// �O���b�h�Z����������N���X(�J�X�^�}�C�Y)
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z����������N���X(�J�X�^�}�C�Y)�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>���������Z�����X�g</summary>
            private List<string> _joinColList;
            /// <summary>
            /// ���������Z�����X�g
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }

            /// <summary>
            /// �Z���������菈��
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            /// <remarks>
            /// <br>Note       : �Z���������菈���B</br>
            /// <br>Programmer : ����</br>
            /// <br>Date       : 2011/04/06</br>
            /// <br></br>
            /// </remarks>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                foreach (string joinColName in JoinColList)
                {
                    if (!EqualCellValue(row1, row2, joinColName)) return false;
                }
                return true;
            }
            /// <summary>
            /// �Z��Value��r����
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            /// <remarks>
            /// <br>Note       : �Z��Value��r�����B</br>
            /// <br>Programmer : ����</br>
            /// <br>Date       : 2011/04/06</br>
            /// <br></br>
            /// </remarks>
            private bool EqualCellValue(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName)
            {
                return (row1.Cells[columnName].Value.ToString() == row2.Cells[columnName].Value.ToString());
            }
        }
        # endregion

        # region [�R�[�h�t�H�[�}�b�g�擾����]
        /// <summary>
        /// ���[�J�[�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�t�H�[�}�b�g�擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetMakerFormat()
        {
            return GetFormat("tNedit_GoodsMakerCd");
        }
        /// <summary>
        /// �a�k�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�t�H�[�}�b�g�擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetBLCodeFormat()
        {
            return GetFormat("tNedit_BLGoodsCode");
        }
        /// <summary>
        /// �ėp�t�H�[�}�b�g�擾����
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ėp�t�H�[�}�b�g�擾�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetFormat(string editName)
        {
            string format = string.Empty;

            UiSet uiset;
            this.uiSetControl1.ReadUISet(out uiset, editName);
            if (uiset != null)
            {
                format = string.Format("{0};-{0};''", new string('0', uiset.Column));
            }

            return format;
        }
        # endregion        

        /// <summary>
        /// �{�^���̗L��/�����ؑ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^���̗L��/�����ؑցB</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void adjustButtonEnable()
        {
            #region ���׈ꗗ

            if (this._stockMoveDataSet != null)
            {
                DataRow[] dataRow = this._stockMoveDataSet.StockMoveDetail.Select("SelectionCheck = true");
                //DataRow[] dataRow = ((DataView)this.uGrid_StockMove.DataSource).Table.Select("SelectionCheck = true");

                if (dataRow.Length == 0)
                {
                    // �`�[�Ĕ��s
                    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Enabled = false;
                }
                else
                {
                    // �`�[�Ĕ��s
                    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Enabled = true;
                }
            }

            if (this._stockMoveDataSet != null && this._stockMoveDataSet.StockMoveDetail.Rows.Count > 0)
            {
                // �e�L�X�g�o��
                this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = true;
                // EXCEL�o��
                this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Enabled = true;
                // �s����������
                this.tToolbarsManager.Tools["TextBoxTool_SearchWord"].SharedProps.Enabled = true;
                // ������
                this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"].SharedProps.Enabled = true;
                // �s�����{�^��
                this.tToolbarsManager.Tools["ButtonTool_RowSearchStart"].SharedProps.Enabled = true;
            }
            else
            {
                // �e�L�X�g�o��
                this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
                // EXCEL�o��
                this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Enabled = false;
                // �s����������
                this.tToolbarsManager.Tools["TextBoxTool_SearchWord"].SharedProps.Enabled = false;
                // ������
                this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"].SharedProps.Enabled = false;
                // �s�����{�^��
                this.tToolbarsManager.Tools["ButtonTool_RowSearchStart"].SharedProps.Enabled = false;
            }

            #endregion // ���׈ꗗ
        }

        /// <summary>
        /// ���݃\�[�g���J�����擾����
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���݃\�[�g���J�����擾�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetSortingColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            string sortText = string.Empty;
            bool firstCol = true;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].SortedColumns)
            {
                if (firstCol == false)
                {
                    sortText += ",";
                }

                // �񖼂��擾
                sortText += ultraGridColumn.Key;

                // ��̃\�[�g����(����,�~��)���擾
                if (ultraGridColumn.SortIndicator == Infragistics.Win.UltraWinGrid.SortIndicator.Ascending)
                {
                    sortText += " ASC";
                }
                else
                {
                    sortText += " DESC";
                }

                firstCol = false;
            }

            return sortText;
        }

        #region �N���b�N�C�x���g

        /// <summary>
        /// �`�[���׃O���b�h �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�O���b�h�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �`�[���׃O���b�h �N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_StockMove_Click(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;


            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElement���擾
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // ��w�b�_�N���b�N���ǂ����𔻒�
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));
            if (objHeader != null) return;

            // �s�N���b�N���ǂ����𔻒�
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            // �I���`�F�b�N
            if (objCell == objRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName])
            {
                RowSelectClicked(null, objRow);
            }
        }

        /// <summary>
        /// �I���`�F�b�N�{�b�N�X �N���b�N����
        /// </summary>
        /// <param name="checkValue"></param>
        /// <param name="gridRow"></param>
        /// <remarks>
        /// <br>Note       : �I���`�F�b�N�{�b�N�X �N���b�N�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void RowSelectClicked(object checkValue, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            // �֐��Ăяo���Ɏg�p����ϐ�
            string tableName = string.Empty;
            string selectionColName = string.Empty;
            string rowNoColName = string.Empty;

            // �ΏۂƂ���O���b�h�̊e�J���������擾
            selectionColName = this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName;
            rowNoColName = this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName;
            tableName = "StockMoveDetail";

            if (gridRow.Cells[selectionColName].Value == DBNull.Value) return; 
            // �I���`�F�b�N�{�b�N�X�̒l���擾
            bool newSelectedValue = !(bool)gridRow.Cells[selectionColName].Value;

            if (checkValue != null)
            {
                newSelectedValue = (bool)checkValue;
            }

            // �s���擾�iRowNo�J�������L�[�ݒ肳��Ă���j
            DataRow row = this._stockMoveDataSet.Tables[tableName].Rows.Find((int)gridRow.Cells[rowNoColName].Value);
            if (!gridRow.Cells[selectionColName].Hidden)
            {
                row[selectionColName] = newSelectedValue;

                // �w�i�F�ύX���\�b�h
                RowBackColorChange(newSelectedValue, gridRow);

                this.adjustButtonEnable();
            }

            // �O���b�h���X�V
            this.uGrid_StockMove.Refresh();
        }



        #endregion // �N���b�N�C�x���g

        #region �s�̔w�i�F�ύX����(�`�[�敪���Ƃ̑O�i�F�E�w�i�F)

        /// <summary>
        /// �s�̔w�i�F�ύX����(�`�[�敪���Ƃ̑O�i�F�E�w�i�F)
        /// </summary>
        /// <param name="isSelected">bool �I������Ă���</param>
        /// <param name="gridRow">�s�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �s�̔w�i�F�ύX����(�`�[�敪���Ƃ̑O�i�F�E�w�i�F)�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void RowBackColorChange(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            Infragistics.Win.Appearance cellApp = new Infragistics.Win.Appearance();
            cellApp.ForeColor = Color.Black; // ������

            if (isSelected)
            {
                // ���׈ꗗ�p�̐F��ݒ�
                cellApp.BackColor = _selectedRowBackColor_Detail;
                cellApp.BackColor2 = _selectedRowBackColor2_Detail;

                // �O���f�[�V������ݒ�
                cellApp.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            else
            {
                // �w�i�F��W���̔z�F�ɖ߂�
                cellApp.BackColor = Color.White;
                cellApp.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
            {
                if (cell.Column.Key == _stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName ||
                     cell.Column.Key == _stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName ||
                     cell.Column.Key == _stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName)
                {
                    continue;
                }
                cell.Appearance.BackColor = cellApp.BackColor;
                cell.Appearance.BackColor2 = cellApp.BackColor2;
                cell.Appearance.BackGradientStyle = cellApp.BackGradientStyle;
                cell.Appearance.ForeColor = cellApp.ForeColor;
            }
        }

        #endregion // �s�̔w�i�F�ύX����(�`�[�敪���Ƃ̑O�i�F�E�w�i�F)               

        # region [�t�H�[���N���[�Y�O����]
        /// <summary>
        /// �t�H�[���N���[�Y�O����
        /// </summary>
        /// <remarks>FormClosing�C�x���g���Ɓ~�{�^�����ɔ����Ă��܂��̂ŁAParent�ŃE�B���h�E���b�Z�[�W������</remarks>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���[�Y�O�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void BeforeFormClose()
        {
            //-----------------------------------------
            // �t�H�[������鎞(�~�{�^�����܂�)
            //-----------------------------------------
            // ���[�U�[�ݒ�ۑ�(��XML��������)
            SaveSettings();
        }
        /// <summary>
        /// ���[�U�[�ݒ�ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�ݒ�ۑ������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SaveSettings()
        {
            // �O���[�v�̓W�J��Ԃ�ۑ�����
            # region [�O���[�v�W�J���]
            _settingForm.UserSetting.BalanceChartExpanded = uExGroupBox_BalanceChart.Expanded;
            _settingForm.UserSetting.ExtraConditionExpanded = uExGroupBox_ExtraCondition.Expanded;
            # endregion

            // �ڍ׏����̃`�F�b�N��Ԃ�ۑ�����
            # region [�ڍ׏���]
            List<string> cndtnList = new List<string>();
            List<string> enableList = new List<string>();
            // ���o�����I���p�l�����̑S�ẴR���g���[���ɑ΂��ď���
            foreach (Control control in panel_SelectItem.Controls)
            {
                if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                {
                    // �`�F�b�N���t���Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
                    if ((control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked)
                    {
                        cndtnList.Add(control.Name);
                    }
                    // �`�F�b�N��Enable�Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
                    if ((control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled == false)
                    {
                        enableList.Add(control.Name);
                    }
                }

            }
            _settingForm.UserSetting.EnabledConditionList = cndtnList;
            _settingForm.UserSetting.EnabledList = enableList;

            # endregion

            // ��{�����̃`�F�b�N��Ԃ�ۑ�����
            # region [��{����]
            List<string> commonCndtnList = new List<string>();

            // ���o�����I���p�l�����̑S�ẴR���g���[���ɑ΂��ď���
            foreach (Control control in panel_Base.Controls)
            {
                if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                {
                    // �`�F�b�N���t���Ă���`�F�b�N�{�b�N�X�̖��̂����X�g�ɒǉ�
                    if ((control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked)
                    {
                        commonCndtnList.Add(control.Name);
                    }
                }
            }
            _settingForm.UserSetting.EnabledCommonConditionList = commonCndtnList;

            # endregion

            // �O���b�h�̃J��������ۑ�����
            # region [�O���b�h�J����]
            // �O���b�h
            List<ColumnInfo> stockMoveColumnsList;
            this.SaveGridColumnsSetting(uGrid_StockMove, out stockMoveColumnsList);
            _settingForm.UserSetting.StockMoveColumnsList = stockMoveColumnsList;
            # endregion

            // �O���b�h�̃J�����T�C�Y����������Ԃ�ۑ�����
            # region  [�O���b�h�J������������]
            // �O���b�h
            _settingForm.UserSetting.AutoAdjustStockMove = _columnWidthAutoAdjust;
            # endregion

            if (this.tComboEditor_OutputDiv.Visible)
            {
                _settingForm.UserSetting.OutPutDiv = this.tComboEditor_OutputDiv.SelectedIndex;
            }
            if (this.tComboEditor_SalesSlipDiv.Visible)
            {
                _settingForm.UserSetting.SalesSlipDiv = this.tComboEditor_SalesSlipDiv.SelectedIndex;
            }
            // �ݒ�ۑ�
            _settingForm.Serialize();
        }
        # endregion

        # region [�O���b�h�J������� �ۑ��E����]
        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�J�������̕ۑ��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        
        # endregion        

        #region �S�Ă̓��͗����N���A

        /// <summary>
        /// �S�Ă̓��͗����N���A���܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�Ă̓��͗����N���A���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearAllField()
        {
            // ���v�\�����G���A
            this.uLabel_Count1.Text = string.Empty;
            this.uLabel_Count2.Text = string.Empty;
            this.uLabel_Count3.Text = string.Empty;

            this.uLabel_Cost1.Text = string.Empty;
            this.uLabel_Cost2.Text = string.Empty;
            this.uLabel_Cost3.Text = string.Empty;

            this.uLabel_Money1.Text = string.Empty;
            this.uLabel_Money2.Text = string.Empty;
            this.uLabel_Money3.Text = string.Empty;

            this.uLabel_SlipCount.Text = string.Empty;
            this.uLabel_DetailCount.Text = string.Empty;
        }

        #endregion // �S�Ă̓��͗����N���A

        /// <summary>
        /// �ڍ׏����̃N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׏����̃N���A�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearExtraConditions()
        {
            # region [�t�h���͒l�̃N���A]
            // �ڍ׏����p�l�����̑S�R���g���[���ɑ΂��ď�������
            foreach (Control targetControl in this.ultraExpandableGroupBoxPanel2.Controls)
            {
                if (targetControl is TNedit)
                {
                    // ���e�N���A
                    (targetControl as TNedit).Clear();
                }
                else if (targetControl is TEdit)
                {
                    // ���e�N���A
                    (targetControl as TEdit).Text = string.Empty;
                }
                else if (targetControl is TComboEditor)
                {
                    if (targetControl.Name != "tComboEditor_ArrivalGoodsFlag")
                    {
                        // �擪�A�C�e����I��
                        (targetControl as TComboEditor).SelectedIndex = 0;
                    }
                    else
                    {
                        (targetControl as TComboEditor).SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                    }
                }
                else if (targetControl is TDateEdit)
                {
                    // ���e�N���A
                    (targetControl as TDateEdit).Clear();
                }
            }

            foreach (Control targetControl in this.ultraExpandableGroupBoxPanel1.Controls)
            {
                if (targetControl.Name != "tComboEditor_OutputDiv" && targetControl.Name != "tComboEditor_SalesSlipDiv" &&
                    targetControl.Name != "tEdit_InputSectionCode" && targetControl.Name != "tEdit_SecCd"
                    && targetControl.Name != "tEdit_WarehouseCd" && targetControl.Name != "tDateEdit_DateSt"
                    && targetControl.Name != "tDateEdit_DateEd")
                {
                    if (targetControl is TNedit)
                    {
                        // ���e�N���A
                        (targetControl as TNedit).Clear();
                    }
                    else if (targetControl is TEdit)
                    {
                        // ���e�N���A
                        (targetControl as TEdit).Text = string.Empty;
                    }
                    else if (targetControl is TComboEditor)
                    {
                        if (targetControl.Name != "tComboEditor_ArrivalGoodsFlag")
                        {
                            // �擪�A�C�e����I��
                            (targetControl as TComboEditor).SelectedIndex = 0;
                        }
                        else
                        {
                            (targetControl as TComboEditor).SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                        }
                    }
                    else if (targetControl is TDateEdit)
                    {
                        // ���e�N���A
                        (targetControl as TDateEdit).Clear();
                    }
                }
            }

            # endregion

            # region [�ޔ�l�̃N���A]
            // **** �����܂��������s�����ڗp ****
            _srSlipNote = string.Empty;
            _srRvSlipNote = string.Empty;
            _srGoodsName = string.Empty;
            _srRvGoodsName = string.Empty;
            _srGoodsNo = string.Empty;
            _srRvGoodsNo = string.Empty;
            _srSlipNote = string.Empty;
            _srRvSlipNote = string.Empty;
            _srWarehouseShelfNo = string.Empty;
            _srRvWarehouseShelfNo = string.Empty;

            // **** �R�[�h�������̂�؂�ւ��鍀�ڗp ****
            _swSalesEmployeeCd = string.Empty;
            _swSalesEmployeeName = string.Empty;
            _swBLGoodsCode = 0;
            _swBLGoodsName = string.Empty;
            //_swAfSectionCode = 0; // DEL 2010/05/18
            _swAfSectionCode = string.Empty; // ADD 2010/05/18
            _swAfSectionName = string.Empty;
            _swAfEnterWarehCode = string.Empty;
            _swAfEnterWarehName = string.Empty;
            _swGoodsMakerCd = 0;
            _swGoodsMakerName = string.Empty;
            _swSupplierCd = 0;
            _swSupplierName = string.Empty;

            _logicalDelDiv = 0;
            # endregion
        }

        /// <summary>
        /// ���͒l��r
        /// </summary>
        /// <param name="stockMovePpr"></param>
        /// <param name="stockMovePprBackUp"></param>
        /// <returns>True�F�ύX�Ȃ��AFalse�F�ύX����</returns>
        /// <remarks>
        /// <br>Note       : ���͒l��r�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool CompareStockMovePpr(StockMovePpr stockMovePpr, StockMovePpr stockMovePprBackUp)
        {
            if (stockMovePprBackUp == null)
            {
                return false;
            }

            ArrayList arrayList = stockMovePpr.Compare(stockMovePprBackUp);

            // �z��ȊO�̔�r
            if (arrayList.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// �N���[�Y�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �N���[�Y�^�C�}�[�N���C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void timer_Close_Tick(object sender, EventArgs e)
        {
            this.timer_Close.Enabled = false;
            this.Close();
        }

        /// <summary>
        /// Excel�G�N�X�|�[�g�E�J�����������C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Excel�G�N�X�|�[�g�E�J�����������C�x���g�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ultraGridExcelExporter_InitializeColumn( object sender, Infragistics.Win.UltraWinGrid.ExcelExport.InitializeColumnEventArgs e )
        {
            // �O���b�h�J�����̃t�H�[�}�b�g��Excel�Z���ɃR�s�[����B
            try
            {
                string format = e.Column.Format;

                // �R�[�h�p�t�H�[�}�b�g��(�[���󔒂ɂ���ꍇ)�O���b�h�ƃG�N�Z���ňقȂ�̂ŕ␳����B
                // �u0000;-0000;''�v���u0000;-0000;�v
                if ( format.EndsWith( ";''" ) )
                {
                    format = format.Substring( 0, format.Length - 2 );
                }
                e.ExcelFormatStr = format;
            }
            catch
            {
                e.ExcelFormatStr = string.Empty;
            }
        }

        /// <summary>
        /// �I���`�F�b�N�{�b�N�X�̔�\��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���`�F�b�N�{�b�N�X�̔�\���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SetGridCheckBoxEnabled()
        {
            // ���ו\���O���b�h
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_StockMove.Rows)
            {
                // DBNull�Ȃ�`�F�b�N�{�b�N�X�\�����Ȃ�
                if (row.Cells[_stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value == DBNull.Value)
                {
                    row.Cells[_stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                }
            }
        }

        #endregion // �v���C�x�[�g�֐�

        #region �C�x���g

        #region �K�C�h����
        /// <summary>
        /// ���͋��_�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���͋��_�K�C�h�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_InputSectionGuide_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_InputSectionCode.Text = sectionInfo.SectionCode.Trim();
                this.ultraLabel_InputSectionName.Text = sectionInfo.SectionGuideNm.Trim();
                _prevInputValue.InputSectionCode = sectionInfo.SectionCode.Trim();
                // ���t�H�[�J�X(�o�ɋ��_)
                this.tEdit_SecCd.Focus();
            }
        }

        /// <summary>
        /// �o�ɋ��_�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �o�ɋ��_�K�C�h�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SecGuide_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SecCd.Text = sectionInfo.SectionCode.Trim();
                this.ultraLabel_SecName.Text = sectionInfo.SectionGuideNm.Trim();
                _prevInputValue.SectionCode = sectionInfo.SectionCode.Trim();
                // ���t�H�[�J�X(�o�ɑq��)
                this.tEdit_WarehouseCd.Focus();
            }
        }

        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            // ���_�R�[�h���擾
            string sectioncode = this.tEdit_SecCd.Text.Trim();
            int status = 0;

            // �R�[�h���疼�̂֕ϊ�
            Warehouse warehouseInfo;

            // ���_�R�[�h�����͂���Ă���΋��_���A�Ȃ���ΑS���_�\��
            if (!String.IsNullOrEmpty(sectioncode))
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode, sectioncode);
            }
            else
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode);
            }

            // �߂�l������ł����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UI��ɂ͖��O���Z�b�g�A�R�[�h�̓��������Ɋi�[
                this.tEdit_WarehouseCd.Text = warehouseInfo.WarehouseCode.Trim();
                this.ultraLabel_WarehouseName.Text = warehouseInfo.WarehouseName.Trim();
                _prevInputValue.WarehouseCode = warehouseInfo.WarehouseCode.Trim();
                // ���t�H�[�J�X(���o�ד�)
                this.tDateEdit_DateSt.Focus();
            }
        }
        /// <summary>
        /// �S���҃K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �S���҃K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SalesEmployeeCd_Click(object sender, EventArgs e)
        {
            // �K�C�h�\��
            Employee employeeInfo;
            int status;

            status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employeeInfo);

            // �X�e�[�^�X������̏ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���O��UI�ɃZ�b�g�A�R�[�h�̓��������ɕۑ�
                this._swSalesEmployeeName = employeeInfo.Name.TrimEnd();
                this._swSalesEmployeeCd = employeeInfo.EmployeeCode;
                if (!string.IsNullOrEmpty(_swSalesEmployeeCd))
                {
                    this.tEdit_SalesEmployeeCd.Text = this._swSalesEmployeeCd.Trim().PadLeft(4, '0') + ":" + _swSalesEmployeeName;
                }

                Control nextControl = null;
                if (this.uCheckSalesEmployeeCd_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_SalesEmployeeCd.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_SalesEmployeeCd.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// �d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �d����K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SupplierCd_Click(object sender, EventArgs e)
        {

            // �R�[�h���疼�̂֕ϊ�
            Supplier supplierInfo;
            int status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._swSupplierCd = supplierInfo.SupplierCd;
                // �d����}�X�^.�d���旪�̂����͂���Ă����ꍇ�ɂ͎d����}�X�^.�d���旪�̂�\��
                if (!string.IsNullOrEmpty(supplierInfo.SupplierSnm))
                {
                    this._swSupplierName = supplierInfo.SupplierSnm;
                }
                // �d����}�X�^.�d���旪�̂������͂̏ꍇ�ɂ͎d����}�X�^.�d���於1��\��
                else if (!string.IsNullOrEmpty(supplierInfo.SupplierNm1))
                {
                    this._swSupplierName = supplierInfo.SupplierNm1;
                }
                // �d����}�X�^.�d���於��1�������͂̏ꍇ�ɂ͎d����}�X�^.�d����J�i��\��
                else
                {
                    this._swSupplierName = supplierInfo.SupplierKana;
                }
                if (_swSupplierCd != 0)
                {
                    this.tEdit_SupplierCd.Text = this._swSupplierCd.ToString("D6") + ":" + this._swSupplierName;
                }
                Control nextControl = null;
                if (this.uCheckSupplierCd_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_SupplierCd.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_SupplierCd.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_MakerCd_Click(object sender, EventArgs e)
        {
            // �R�[�h���疼�̂֕ϊ�
            MakerUMnt makerInfo;
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._swGoodsMakerCd = makerInfo.GoodsMakerCd;
                this._swGoodsMakerName = makerInfo.MakerKanaName;
                if (_swGoodsMakerCd != 0)
                {
                    this.tEdit_MakerCd.Text = _swGoodsMakerCd.ToString("D4") + ":" + _swGoodsMakerName;
                }
                Control nextControl = null;
                if (this.uCheckGoodsMakerCd_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_MakerCd.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_MakerCd.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_BlGoodsCode_Click(object sender, EventArgs e)
        {
            // �R�[�h���疼�̂֕ϊ�
            BLGoodsCdUMnt blGoodsUnit;
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._swBLGoodsCode = blGoodsUnit.BLGoodsCode;

                this._swBLGoodsName = blGoodsUnit.BLGoodsHalfName;
                if (_swBLGoodsCode != 0)
                {
                    this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString("D5") + ":" + _swBLGoodsName;
                }
                Control nextControl = null;
                if (this.uCheckBLGoodsCode_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_BlGoodsCode.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_BlGoodsCode.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// ���苒�_�K�C�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���苒�_�K�C�h�N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_AfSectionCode_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this._swAfSectionCode = Int32.Parse(sectionInfo.SectionCode); // DEL 2010/05/18
                //this._swAfSectionCode = sectionInfo.SectionCode; // ADD 2010/05/18
                this._swAfSectionCode = sectionInfo.SectionCode.Trim() ; // ADD 2010/05/20

                this._swAfSectionName = sectionInfo.SectionGuideNm;
                //this.tEdit_AfSectionCode.Text = this._swAfSectionCode.ToString("D2") + ":" + _swAfSectionName; // DEL 2010/05/18
                this.tEdit_AfSectionCode.Text = this._swAfSectionCode + ":" + _swAfSectionName; // ADD 2010/05/18
                Control nextControl = null;
                if (this.uCheckAfSectionCode_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_AfSectionCode.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_AfSectionCode.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// ����q�ɃK�C�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ����q�ɃK�C�h�N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_AfEnterWarehCode_Click(object sender, EventArgs e)
        {
            // TODO:���_�R�[�h���擾
            string sectioncode = this.tEdit_SecCd.Text.Trim();
            int status = 0;

            // �R�[�h���疼�̂֕ϊ�
            Warehouse warehouseInfo;

            // ���_�R�[�h�����͂���Ă���΋��_���A�Ȃ���ΑS���_�\��
            if (!String.IsNullOrEmpty(sectioncode))
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode, sectioncode);
            }
            else
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode);
            }

            // �߂�l������ł����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UI��ɂ͖��O���Z�b�g�A�R�[�h�̓��������Ɋi�[
                this._swAfEnterWarehCode = warehouseInfo.WarehouseCode.Trim();

                this._swAfEnterWarehName = warehouseInfo.WarehouseName;
                if (_swAfEnterWarehCode != string.Empty)
                {
                    this.tEdit_AfEnterWarehCode.Text = this._swAfEnterWarehCode + ":" + _swAfEnterWarehName;
                }
                Control nextControl = null;
                if (this.uCheckAfEnterWarehCode_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_AfEnterWarehCode.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_AfEnterWarehCode.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// ���l�K�C�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�N���b�N�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SlipNote_Click(object sender, EventArgs e)
        {
            const int ctSlipNote1Div = 105;

            NoteGuidBd noteGuidBd;
            int status = _noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, ctSlipNote1Div);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���l�Z�b�g
                tEdit_SlipNote.Text = noteGuidBd.NoteGuideName;

                // �ޔ�
                _srSlipNote = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_SlipNoteFuzzy.Value, tEdit_SlipNote.Text);

                // ���t�H�[�J�X
                Control nextControl = null;
                if (this.uCheckNote_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_SlipNote.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_SlipNote.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }
        #endregion // �K�C�h����        

        #region Enter�C�x���g
        /// <summary>
        /// �i�ԓ��͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : �i�ԓ��͗�Enter�C�x���g</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_GoodsNo_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̕i�Ԃ��ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srGoodsNo))
            {
                this.tEdit_GoodsNo.Text = this._srGoodsNo;
            }
        }

        /// <summary>
        /// �i�����͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : �i�����͗�Enter�C�x���g</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_GoodsName_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̕i�����ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srGoodsName))
            {
                this.tEdit_GoodsName.Text = this._srGoodsName;
            }

        }

        /// <summary>
        /// �I�ԓ��͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : �I�ԓ��͗�Enter�C�x���g</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_WarehouseShelfNo_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̒I�Ԃ��ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srWarehouseShelfNo))
            {
                this.tEdit_WarehouseShelfNo.Text = this._srWarehouseShelfNo;
            }
        }

        /// <summary>
        /// ���l���͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : �i�����͗�Enter�C�x���g</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_SlipNote_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̔��l���ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srSlipNote))
            {
                this.tEdit_SlipNote.Text = this._srSlipNote;
            }
        }
        #endregion // Enter�C�x���g        

        # region �t�H�[�J�X�ϊ�����
        /// <summary>
        /// �A���[�L�[�R���g���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �A���[�L�[�R���g���[���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ���o�L�����Z��
            if (e.Key == Keys.Escape)
            {
                CancelExtract();
            }

            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            // PrevCtrl�ݒ�
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
                this._control = prevCtrl;
            }
            // �t�b�^���ڂֈړ������ꍇ�͈ړ��L�����Z��
            if (e.NextCtrl == tComboEditor_StatusBar_FontSize)
            {
                if (!e.ShiftKey && (e.Key == Keys.Down || e.Key == Keys.Right || e.Key == Keys.Tab || e.Key == Keys.Return))
                {
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }

            // ���O�ɂ�蕪��
            switch (prevCtrl.Name)
            {
                # region �o�͋敪

                case "tComboEditor_OutputDiv":
                case "tComboEditor_SalesSlipDiv":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.tEdit_InputSectionCode.Visible)
                                    {
                                        e.NextCtrl = this.tEdit_InputSectionCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_SecCd;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���͋��_�R�[�h
                case "tEdit_InputSectionCode":
                    {
                        string inputValue = this.tEdit_InputSectionCode.Text;

                        string code;
                        string name;
                        bool status = ReadInputSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_InputSectionCode.Text = code;
                            this.ultraLabel_InputSectionName.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = this.tComboEditor_SalesSlipDiv;
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_InputSectionCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_InputSectionGuide;
                                            }
                                            else
                                            {
                                                if (this.tEdit_SecCd.Enabled)
                                                {
                                                    e.NextCtrl = this.tEdit_SecCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tDateEdit_DateSt;
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = this.tComboEditor_SalesSlipDiv;
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tEdit_InputSectionCode.Text = code;
                            this.tEdit_InputSectionCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                # region ���͋��_�K�C�h
                case "uButton_InputSectionGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tEdit_SecCd.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_SecCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_DateSt;
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.uButton_SecGuide.Enabled && !this.uButton_WarehouseGuide.Enabled)
                                        {
                                            if (this.uExGroupBox_ExtraCondition.Visible)
                                            {
                                                // �g�����������̕\����Ԃ𒲂ׂĎ���(������"tDateEdit_AddUpADateEd"���w�肵�ďI�����͓��̎����ڂ�T��)
                                                e.NextCtrl = this.GetNextControl("tDateEdit_DateEd");
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tEdit_InputSectionCode;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region �o�ɋ��_
                case "tEdit_SecCd":
                    {
                        string inputValue = this.tEdit_SecCd.Text;

                        string code;
                        string name;
                        bool status = ReadSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_SecCd.Text = code;
                            this.ultraLabel_SecName.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Up:
                                        {
                                            if (this.tEdit_InputSectionCode.Visible)
                                            {
                                                e.NextCtrl = this.tEdit_InputSectionCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_OutputDiv;
                                            }
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_SecCd.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SecGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCd;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tEdit_InputSectionCode.Visible)
                                            {
                                                e.NextCtrl = this.uButton_InputSectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_OutputDiv;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tEdit_SecCd.Text = code;
                            this.tEdit_SecCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                # region �o�ɋ��_�K�C�h
                case "uButton_SecGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    e.NextCtrl = this.tEdit_WarehouseCd;
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tEdit_SecCd;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region �o��/���ɑq��
                case "tEdit_WarehouseCd":
                    {
                        string inputValue = this.tEdit_WarehouseCd.Text;

                        string code;
                        string name;
                        bool status = ReadWarehouseName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_WarehouseCd.Text = code;
                            this.ultraLabel_WarehouseName.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = this.tEdit_SecCd;
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_WarehouseCd.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_DateSt;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = uButton_SecGuide;
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�q�ɂ����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tEdit_WarehouseCd.Text = code;
                            this.tEdit_WarehouseCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                # region �o��/���ɑq�ɃK�C�h
                case "uButton_WarehouseGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    e.NextCtrl = this.tDateEdit_DateSt;
                                    break;
                                case Keys.Down:
                                    {
                                        if (this.uExGroupBox_ExtraCondition.Visible)
                                        {
                                            // �g�����������̕\����Ԃ𒲂ׂĎ���(������"tDateEdit_AddUpADateEd"���w�肵�ďI�����͓��̎����ڂ�T��)
                                            e.NextCtrl = this.GetNextControl("tDateEdit_DateEd");
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tEdit_WarehouseCd;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���o�ד��i�J�n�j
                // ���o�ד��i�J�n�j
                case "tDateEdit_DateSt":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_DateEd;// ���o�ד��i�I���j
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uButton_WarehouseGuide.Enabled)
                                        {
                                            e.NextCtrl = this.uButton_WarehouseGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_InputSectionGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���o�ד��i�I���j
                // ������i�I���j
                case "tDateEdit_DateEd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = this.tDateEdit_DateSt;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���͓��J�n
                // ���͓��J�n
                case "tDateEdit_AddUpADateSt":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.uCheckAddUpADateSt_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAddUpADateSt_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���͓��I��
                // ���͓��I��
                case "tDateEdit_AddUpADateEd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.uCheckAddUpADateEd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAddUpADateEd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region �`�[�ԍ�
                // �`�[�ԍ�
                case "tEdit_StockMoveSlipNum":
                    {
                        this.tEdit_StockMoveSlipNum.Text = this.uiSetControl1.GetZeroPaddedText("tEdit_SalesSlipNum", this.tEdit_StockMoveSlipNum.Text);
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckSalesSlipNum_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckSalesSlipNum_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region ���׋敪
                // ���׋敪
                case "tComboEditor_ArrivalGoodsFlag":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckArrivalGoodsFlag_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckArrivalGoodsFlag_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region �폜�w��敪
                // �폜�w��敪
                case "tComboEditor_DeleteFlag":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckDeleteFlag_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckDeleteFlag_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region �S���҃K�C�h

                case "uButton_SalesEmployeeCd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckSalesEmployeeCd_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckSalesEmployeeCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region �d����K�C�h
                case "uButton_SupplierCd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckSupplierCd_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckSupplierCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region ���[�J�[�K�C�h
                case "uButton_MakerCd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsMakerCd_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsMakerCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region BL�R�[�h�K�C�h
                // BL�R�[�h�K�C�h
                case "uButton_BlGoodsCode":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckBLGoodsCode_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckBLGoodsCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region ���苒�_�K�C�h
                // ���苒�_�K�C�h
                case "uButton_AfSectionCode":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckAfSectionCode_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAfSectionCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region ����q�ɃK�C�h
                // ����q�ɃK�C�h
                case "uButton_AfEnterWarehCode":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckAfEnterWarehCode_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAfEnterWarehCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region ���l�K�C�h
                // ���l�P�K�C�h
                case "uButton_SlipNote":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckNote_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckNote_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region [�R�[�h�������� �؂�ւ�����]

                # region [�S����]
                // �S����
                case "tEdit_SalesEmployeeCd":
                    {
                        string inputValue = tEdit_SalesEmployeeCd.Text;

                        string code;
                        bool status = ReadSalesEmployeeName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            if (!string.IsNullOrEmpty(_swSalesEmployeeCd))
                            {
                                tEdit_SalesEmployeeCd.Text = _swSalesEmployeeCd.Trim().PadLeft(4, '0') + ":" + _swSalesEmployeeName;
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckSalesEmployeeCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckSalesEmployeeCd_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�S���҂����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_SalesEmployeeCd.Text = code;
                            tEdit_SalesEmployeeCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [BL�R�[�h]
                // BL�R�[�h
                case "tEdit_BlGoodsCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_BlGoodsCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadBlCodeName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            if (_swBLGoodsCode != 0)
                            {
                                this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString("D5") + ":" + _swBLGoodsName;
                            }

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckBLGoodsCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckBLGoodsCode_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�a�k�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_BlGoodsCode.Text = code.ToString();
                            tEdit_BlGoodsCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [���[�J�[]
                // ���[�J�[
                case "tEdit_MakerCd":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_MakerCd.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadGoodsMakerName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            if (_swGoodsMakerCd != 0)
                            {
                                tEdit_MakerCd.Text = _swGoodsMakerCd.ToString("D4") + ":" + _swGoodsMakerName;
                            }

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckGoodsMakerCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckGoodsMakerCd_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���[�J�[�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_MakerCd.Text = code.ToString();
                            tEdit_MakerCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [�q��]
                // �q��
                case "tEdit_AfEnterWarehCode":
                    {
                        string inputValue = tEdit_AfEnterWarehCode.Text;

                        string code;
                        bool status = ReadAfEnterWarehName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            if (_swAfEnterWarehCode != string.Empty)
                            {
                                this._swAfEnterWarehCode = this._swAfEnterWarehCode.PadLeft(4, '0'); // ADD 2010/05/18
                                this.tEdit_AfEnterWarehCode.Text = this._swAfEnterWarehCode + ":" + _swAfEnterWarehName;
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckAfEnterWarehCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckAfEnterWarehCode_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�q�ɂ����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_AfEnterWarehCode.Text = code;
                            tEdit_AfEnterWarehCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [�d����]
                // �d����
                case "tEdit_SupplierCd":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_SupplierCd.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadSupplierName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            if (_swSupplierCd != 0)
                            {
                                tEdit_SupplierCd.Text = this._swSupplierCd.ToString("D6") + ":" + this._swSupplierName;
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckSupplierCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckSupplierCd_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�d���悪���݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_SupplierCd.Text = code.ToString();
                            tEdit_SupplierCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [���苒�_]
                // ���苒�_
                case "tEdit_AfSectionCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_AfSectionCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        //int code; // DEL 2010/05/18
                        string code; // ADD 2010/05/18
                        bool status = ReadAfSectionName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            //if (_swAfSectionCode != 0) // DEL 2010/05/18
                            if (!string.IsNullOrEmpty(_swAfSectionCode)) // ADD 2010/05/18
                            {
                                //tEdit_AfSectionCode.Text = this._swAfSectionCode.ToString("D2") + ":" + this._swAfSectionName; // DEL 2010/05/18
                                this._swAfSectionCode = this._swAfSectionCode.PadLeft(2, '0'); // ADD 2010/05/18
                                tEdit_AfSectionCode.Text = this._swAfSectionCode + ":" + this._swAfSectionName; // ADD 2010/05/18
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckAfSectionCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckAfSectionCode_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_AfSectionCode.Text = code.ToString();
                            tEdit_AfSectionCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # endregion

                # region [�����܂���������]

                # region [���l]
                // ���l
                case "tEdit_SlipNote":
                    {
                        string inputValue = tEdit_SlipNote.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_SlipNote.Text = searchText;
                        tComboEditor_SlipNoteFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srSlipNote = inputValue;
                        _srRvSlipNote = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckNote_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckNote_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }

                        # endregion
                    }
                    break;
                // ���l1�����܂�����
                case "tComboEditor_SlipNoteFuzzy":
                    {
                        // �ޔ�
                        _srSlipNote = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_SlipNoteFuzzy.Value, tEdit_SlipNote.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckNote_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckNote_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                # endregion

                # region [�i��]
                // �i��
                case "tEdit_GoodsName":
                    {
                        string inputValue = tEdit_GoodsName.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_GoodsName.Text = searchText;
                        tComboEditor_GoodsNameFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srGoodsName = inputValue;
                        _srRvGoodsName = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsName_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsName_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // �i�������܂�����
                case "tComboEditor_GoodsNameFuzzy":
                    {
                        // �ޔ�
                        _srGoodsName = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNameFuzzy.Value, tEdit_GoodsName.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsName_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsName_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                # endregion

                # region [�i��]
                // �i��
                case "tEdit_GoodsNo":
                    {
                        string inputValue = tEdit_GoodsNo.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_GoodsNo.Text = searchText;
                        tComboEditor_GoodsNoFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srGoodsNo = inputValue;
                        _srRvGoodsNo = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // �i�Ԃ����܂�����
                case "tComboEditor_GoodsNoFuzzy":
                    {
                        // �ޔ�
                        _srGoodsNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNoFuzzy.Value, tEdit_GoodsNo.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                # endregion

                # region [�I��]
                // �I��
                case "tEdit_WarehouseShelfNo":
                    {
                        string inputValue = tEdit_WarehouseShelfNo.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_WarehouseShelfNo.Text = searchText;
                        tComboEditor_WarehouseShelfNoFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srWarehouseShelfNo = inputValue;
                        _srRvWarehouseShelfNo = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckWarehouseShelfNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckWarehouseShelfNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // �I�Ԃ����܂�����
                case "tComboEditor_WarehouseShelfNoFuzzy":
                    {
                        // �ޔ�
                        _srWarehouseShelfNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_WarehouseShelfNoFuzzy.Value, tEdit_WarehouseShelfNo.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckWarehouseShelfNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckWarehouseShelfNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #region ���׈ꗗ
                //---------------------------------------------------------------
                // ���׈ꗗ
                //---------------------------------------------------------------
                case "uGrid_StockMove":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.uGrid_StockMove.ActiveCell != null)
                                    {
                                        this.uGrid_StockMove.ActiveCell.Row.Activate();
                                    }

                                    if (this.uGrid_StockMove.ActiveRow != null)
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else
                                    {
                                        e.NextCtrl = uCheckEditor_StatusBar_AutoFillToGridColumn;
                                    }
                                }
                                break;
                            case Keys.Tab:
                                if (!e.ShiftKey)
                                {
                                    //�o�͋敪
                                    if (this.tComboEditor_OutputDiv.Visible)
                                    {
                                        e.NextCtrl = this.tComboEditor_OutputDiv;
                                    }

                                    // �`�[�敪
                                    if (this.tComboEditor_SalesSlipDiv.Visible)
                                    {
                                        e.NextCtrl = this.tComboEditor_SalesSlipDiv;
                                    }
                                }
                                break;
                        }
                    }
                    break;
                #endregion

                # endregion
                # endregion
            }

            // ���v�^�uor���׃^�u�Ɉړ�����ꍇ�͌������s�`�F�b�N����
            if ((e.NextCtrl == uGrid_StockMove || e.NextCtrl == uTabControl_BlDspRslt) && this._doSearchFlg)
            {
                if (!e.ShiftKey && (e.Key == Keys.Down || e.Key == Keys.Right || e.Key == Keys.Tab || e.Key == Keys.Return))
                {
                    // �������s
                    e.NextCtrl = SearchOnChangeFocus(e.PrevCtrl);
                    return;
                }
            }
            else if (e.NextCtrl == uButton_SlipNote)
            {
                if (!e.ShiftKey && (e.Key == Keys.Up || e.Key == Keys.Down))
                {
                    e.NextCtrl = tEdit_SlipNote;
                }
            }

            this._nextControl = e.NextCtrl;
            this._doSearchFlg = true;
        }
        # endregion

        #region �O���b�hKeyDown�C�x���g
        /// <summary>
        /// KeyDown�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : KeyDown�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_StockMove_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                this.uGrid_StockMove.BeginUpdate();

                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                            {
                                this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                            }
                            if (this.uGrid_StockMove.ActiveCell != null)
                            {
                                this.stockMoveSlipSelectSetting();
                            }
                        }
                        break;
                    case Keys.Left:
                        {
                            if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                            {
                                this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                            }

                            // ���[��VisiblePosition���擾
                            int firstPosition = this.GetGridFirstPosition(this.uGrid_StockMove);

                            // ���[����O�s�E�[�Ɉړ������Ȃ�
                            if (this.uGrid_StockMove.ActiveCell.Column.Header.VisiblePosition == firstPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        break;
                    case Keys.Right:
                        {
                            if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                            {
                                this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                            }

                            // �E�[��VisiblePosition���擾
                            int lastPosition = this.GetGridLastPosition(this.uGrid_StockMove);

                            if (this.uGrid_StockMove.ActiveCell == null) break; 
                            // �E�[���玟�s���[�Ɉړ������Ȃ�
                            if (this.uGrid_StockMove.ActiveCell.Column.Header.VisiblePosition == lastPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        break;
                    case Keys.Up:
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridRow row = uGrid_StockMove.ActiveRow;
                            if (row == null && uGrid_StockMove.ActiveCell != null)
                            {
                                row = uGrid_StockMove.ActiveCell.Row;
                            }

                            if (row != null && row.Index == 0)
                            {
                                // �擪�s�����ړ�
                                Control nextControl = GetNextControlForGridUpKey();
                                if (nextControl != null)
                                {
                                    if (uGrid_StockMove.ActiveCell != null)
                                    {
                                        uGrid_StockMove.ActiveCell.Selected = false;
                                        uGrid_StockMove.ActiveCell = null;
                                    }
                                    if (uGrid_StockMove.ActiveRow != null)
                                    {
                                        uGrid_StockMove.ActiveRow.Selected = false;
                                        uGrid_StockMove.ActiveRow = null;
                                    }
                                    nextControl.Focus();
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                this.uGrid_StockMove.EndUpdate();
            }
        }

        /// <summary>
        /// �O���b�h���̍ŏ���VisiblePosition�擾
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridFirstPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = grid.ActiveRow.Cells.Count;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount > grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// �O���b�h���̍Ō��VisiblePosition�擾
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridLastPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 0;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount < grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// �O���b�h�擪�s�����Up�L�[�߂��擾
        /// </summary>
        /// <returns></returns>
        private Control GetNextControlForGridUpKey()
        {
            DisplayExtraConditions();

            if (uExGroupBox_ExtraCondition.Expanded && _gridUpKeyBackControl != null)
            {
                // �ڍ׏���
                return _gridUpKeyBackControl;
            }
            else if (uExGroupBox_CommonCondition.Expanded)
            {
                // ��{����
                if (tEdit_WarehouseCd.Enabled == true)
                {
                    return this.tEdit_WarehouseCd;
                }
                else
                {
                    // ���׊m�肠��
                    if (this._stockMoveFixCode == 1)
                    {
                        return this.tEdit_SecCd;
                    }
                    // ���׊m��Ȃ�
                    else
                    {
                        return this.tEdit_InputSectionCode;
                    }
                }
            }
            else
            {
                // �ړ����Ȃ�
                return null;
            }
        }
        #endregion // �O���b�hKeyDown�C�x���g

        /// <summary>
        /// ���׋敪�̕ύX�G�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ValueChanged�C�x���g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/05/23</br>
        /// <br>Update Note: #21681</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_ArrivalGoodsFlag_ValueChanged(object sender, EventArgs e)
        {
            // ���׋敪���u���׍ρv�̏ꍇ
            if (this.tComboEditor_ArrivalGoodsFlag.SelectedIndex == 1)
            {
                // �폜�w��敪����͕s�Ƃ��A�u�ʏ�v�Œ�Ƃ���B
                this.tComboEditor_DeleteFlag.SelectedIndex = 0;
                this.tComboEditor_DeleteFlag.Enabled = false;
            }
            else
            {
                this.tComboEditor_DeleteFlag.Enabled = true;
            }
        }

        #endregion // �C�x���g
    }
    
    # region [�O���b�h�J�����|�W�V����Fix����N���X]
    /// <summary>
    /// �O���b�h�J�����|�W�V����Fix����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O���b�h�J�����|�W�V����Fix����N���X�B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    internal class GridColPosFixController
    {
        private Infragistics.Win.UltraWinGrid.UltraGrid _targetGrid;
        private Dictionary<string, int> _fixPosDic;
        private Dictionary<string, bool> _fixDic;

        # region [�v���p�e�B]
        /// <summary>
        /// �ΏۃO���b�h
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid TargetGrid
        {
            get { return _targetGrid; }
            set
            {
                // �ΏۃO���b�h�����ɐݒ�ς݂Ȃ�΃C�x���g�n���h���̓o�^���폜����
                if (_targetGrid != null)
                {
                    _targetGrid.BeforeColPosChanged -= Grid_BeforeColPosChanged;
                    _targetGrid.AfterColPosChanged -= Grid_AfterColPosChanged;
                }

                // �O���b�h
                _targetGrid = value;

                // �O���b�h�C�x���g
                _targetGrid.BeforeColPosChanged += Grid_BeforeColPosChanged;
                _targetGrid.AfterColPosChanged += Grid_AfterColPosChanged;

                // �����g�p����t�B�[���h������
                _fixPosDic = new Dictionary<string, int>();
                _fixDic = new Dictionary<string, bool>();
            }
        }
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public GridColPosFixController()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GridColPosFixController(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
            : this()
        {
            this.TargetGrid = targetGrid;
        }
        # endregion

        # region [�Ώۂ̃O���b�h�ɒǉ�����C�x���g����]
        /// <summary>
        /// �J�����|�W�V�����ύX�O�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �J�����|�W�V�����ύX�O�C�x���g�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void Grid_BeforeColPosChanged(object sender, Infragistics.Win.UltraWinGrid.BeforeColPosChangedEventArgs e)
        {
            // Moved�ȊO�͖�������
            if (e.PosChanged != Infragistics.Win.UltraWinGrid.PosChanged.Moved) return;

            if (_fixDic.ContainsKey(e.ColumnHeaders[0].Column.Key))
            {
                if (_fixDic[e.ColumnHeaders[0].Column.Key] != e.ColumnHeaders[0].Fixed)
                {
                    if (e.ColumnHeaders[0].Fixed == true)
                    {
                        int fixedColCount = 0;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in _targetGrid.DisplayLayout.Bands[0].Columns)
                        {
                            if (!col.Hidden && col.Header.Fixed) fixedColCount++;
                        }

                        // �ύX�O�̃|�W�V������ޔ�����(fixed�ɂȂ��Ă���J�������͏���)
                        _fixPosDic[e.ColumnHeaders[0].Column.Key] = e.ColumnHeaders[0].VisiblePosition - fixedColCount;
                    }
                }
            }
            else
            {
                int fixedColCount = 0;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in _targetGrid.DisplayLayout.Bands[0].Columns)
                {
                    if (!col.Hidden && col.Header.Fixed) fixedColCount++;
                }

                // �ǉ����Ď���ȍ~�̕ύX�ŏ���
                _fixDic.Add(e.ColumnHeaders[0].Column.Key, false);
                _fixPosDic.Add(e.ColumnHeaders[0].Column.Key, e.ColumnHeaders[0].VisiblePosition - fixedColCount);
            }
        }
        /// <summary>
        /// �J�����|�W�V�����ύX��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �J�����|�W�V�����ύX��C�x���g�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void Grid_AfterColPosChanged(object sender, Infragistics.Win.UltraWinGrid.AfterColPosChangedEventArgs e)
        {
            if (e.PosChanged != Infragistics.Win.UltraWinGrid.PosChanged.Moved) return;

            if (_fixDic.ContainsKey(e.ColumnHeaders[0].Column.Key) && _fixDic[e.ColumnHeaders[0].Column.Key] != e.ColumnHeaders[0].Fixed)
            {
                // Fix��Ԃ��ύX���ꂽ
                if (e.ColumnHeaders[0].Fixed == false)
                {
                    int fixedColCount = 0;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in _targetGrid.DisplayLayout.Bands[0].Columns)
                    {
                        if (!col.Hidden && col.Header.Fixed) fixedColCount++;
                    }

                    // �|�W�V������߂��ifixed�ɂȂ��Ă���J���������l������j
                    e.ColumnHeaders[0].VisiblePosition = _fixPosDic[e.ColumnHeaders[0].Column.Key] + fixedColCount;

                    // �߂����Ƃő��̃J�����ɉe������
                    List<string> dicKeyList = new List<string>();
                    foreach (string colKey in _fixPosDic.Keys)
                    {
                        if (_fixPosDic[colKey] > _fixPosDic[e.ColumnHeaders[0].Column.Key])
                        {
                            dicKeyList.Add(colKey);
                        }
                    }
                    foreach (string colKey in dicKeyList)
                    {
                        _fixPosDic[colKey]--;
                    }
                }

                // �O��ޔ�l�X�V
                _fixDic[e.ColumnHeaders[0].Column.Key] = e.ColumnHeaders[0].Fixed;
            }
        }
        # endregion

    }
    # endregion

}