//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�f�[�^�����e�i���X
// �v���O�����T�v   : ��`�f�[�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/04/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �C �� ��  2010/05/16  �C�����e : ��Q�Ή� redmine#7606�F�����`�[���͂œ��͂������z����`���E�B���h�ł��\�������Q���C��
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �C �� ��  2010/06/28  �C�����e : ��Q�Ή� redmine#10551�F��`�f�[�^�����e�i���X�@�e��d�l�ύX�^��Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{
// �C �� ��  2012/10/18  �C�����e : ��Q�Ή� ����`���������̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{
// �C �� ��  2012/10/24  �C�����e : ��Q�Ή� ����`�������Ɏx����`�����N���A
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{
// �C �� ��  2012/10/29  �C�����e : ��Q�Ή� ����`�������̏������E�����̓N���A���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : zhuhh
// �C �� ��  2013/01/10  �C�����e : 2013/03/13�z�M�� Redmine #34123
//                                  ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{
// �C �� ��  2012/02/15  �C�����e : ��Q�Ή�
//                         �@��ʃ��C�A�E�g�ύX(��s�E�U�o���̈ʒu��#34123�C���O�ɖ߂�)
//                           ����`�̏d���`�F�b�N�͎�`�ԍ��̓��͎��ƐV�K�o�^���ɍs��
//                         �A�����`�I����ʂ̖߂�{�^��Caption�ύX�i�߂����߂�j
//                         �B�폜�ώ�`���ݎ��̃��b�Z�[�W���C���i�폜���Ă��܂����폜����Ă��܂��j
//                         �C�x����`�ԍ��m�莞�̊m�F���b�Z�[�W�C��
//                         �D�����`�ԍ��I����ʂň�����/�_���폜��`�̑I�����Ɋm�F���b�Z�[�W��\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{
// �C �� ��  2013/02/22  �C�����e : ��Q�Ή�
//                         �@�����`�ԍ��I����ʂőI����̕ҏW�m�F���b�Z�[�W�Łu�͂��v��I�������ꍇ�̂�
//                           �I����`����`�f�[�^�p�����[�^�Ɋi�[����
//                         �A���͂���N���̊m�莞�Ɋ����f�[�^�̑��݃`�F�b�N���s��
//                           �i�������͂���N�����͓o�^�ώ���`�̊m��s�j
//                         �B�x����`�ԍ��m���(���͂���N��)�A�t�H�[�J�X����`��ʂɈړ�
//                         �C���͂���N���̊m�莞�Ɋ����f�[�^�����݂��Ȃ��ꍇ(�V�K�o�^���s��)��
//                           ��`�f�[�^�p�����[�^���N���A����
//                           �������f�[�^�����ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�A�r���ƂȂ邽��
//                         �D�m�莞�̊�����`�̈����m�F�Łu�͂��v��I�������ꍇ�ɊY�������`�f�[�^��
//                           ��`�f�[�^�p�����[�^�Ɋi�[����
//                         �E��`���`�[�C���̎�`��ʂɂĕύX�Ȃ��Ŋm�肵���ꍇ�͊����`�F�b�N���s��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{
// �C �� ��  2013/03/04  �C�����e : ���������̕��򔻒���C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901273-00 �쐬�S�� : ���N
// �C �� ��  2013/04/02  �C�����e : 2013/05/15�z�M�� Redmine #35247
//                                  �d�������I�v�V�����̒���
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��`�f�[�^�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�f�[�^�����e�i���X�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.04.22</br>
	/// <br>UpdateNote : 2010.05.16 �I�M redmine#7606�̑Ή�</br>
    /// <br>UpdateNote : 2010.05.19 ���R redmine#7892�̑Ή�</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
    /// <br>UpdateNote : 2013/04/02 ���N</br>
    /// <br>�Ǘ��ԍ�   : 10901273-00 2013/05/15�z�M�� </br>
    /// <br>           : Redmine #35247 �d�������I�v�V�����̒���</br>
    /// <br></br>
    /// </remarks>
    public partial class PMTEG09101UA : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �R���X�g���N�^
        /// <summary>
        /// ��`�f�[�^�����e�i���X�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��`�f�[�^�����e�i���X�̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>UpdateNote : 2013/04/02 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/05/15�z�M��</br>
        /// <br>           : redmine #35247 �d�������I�v�V�����̒���</br>
        /// </remarks>
        public PMTEG09101UA(object draftDataParam)
        {
            // ���͉�ʂ���̋N���敪
            this._startType = START_TYPE_CALL;

            // �p�����[�^�Ƃ��āA��`�f�[�^�p�����[�^���擾
            if (draftDataParam is RcvDraftData)
            {
                this._rcvDraftData = (RcvDraftData)draftDataParam;
                this._rcvDraftData.SectionCode = this._rcvDraftData.SectionCode.Trim();// ADD zhuhh 2013/01/10 for Redmine #34123
                this._rcvDraftDataOrg = _rcvDraftData.Clone();
                this._rcvDraftDataClear = this._rcvDraftData.Clone();
                // ��`�敪
                _draftMode = DRAFT_DIV_RCV;
                // ����`�f�[�^�A�N�Z�X�N���X
                _rcvDraftDataAcs = new RcvDraftDataAcs();
                // ��`�ԍ��@�ꉞ�ۑ�
                if (this._rcvDraftData.RcvDraftNo != "")
                    this._draftNo = this._rcvDraftData.RcvDraftNo;
            }
            else
            {
                this._payDraftData = (PayDraftData)draftDataParam;
                this._payDraftData.SectionCode = this._payDraftData.SectionCode.Trim();// ADD zhuhh 2013/01/10 for Redmine #34123
                this._payDraftDataOrg = _payDraftData.Clone();
                this._payDraftDataClear = this._payDraftData.Clone();
                // ��`�敪
                _draftMode = DRAFT_DIV_PAY;
                // �x����`�f�[�^�A�N�Z�X�N���X
                _payDraftDataAcs = new PayDraftDataAcs();
                // ��`�ԍ��@�ꉞ�ۑ�
                if (this._payDraftData.PayDraftNo != "")
                    this._draftNo = this._payDraftData.PayDraftNo;
                // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                // �x����`���(���z�E�����`�F�b�N�p)
                this._payDraftDataInfo = this._payDraftData.Clone();
                // ����`�f�[�^�A�N�Z�X�N���X
                this._rcvDraftDataAcs = new RcvDraftDataAcs();
                // --- ADD 2012/10/18 --------------------------------------------------<<<<<
            }

            // ����������
            this.InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���O�C�����_(�����_)
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // ���_���A�N�Z�X�N���X
            this._secInfoAcs = new SecInfoAcs();
            // ���_�A�N�Z�X�N���X
            this._secInfoSetAcs = new SecInfoSetAcs();
            // �d����A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();
            // ���Ӑ�A�N�Z�X�N���X
            this._customerInfoAcs = new CustomerInfoAcs();
            // ���[�U�[�K�C�h�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();

            CacheOptionInfo(); // ADD ���N 2013/04/02 Redmine#35247
        }
        /// <summary>
        /// ��`�f�[�^�����e�i���X�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��`�f�[�^�����e�i���X�̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.22</br>
        /// </remarks>
        public PMTEG09101UA()
        {
            // ����������
            this.InitializeComponent();

            // ���ړI�ɂ���̋N���敪
            this._startType = START_TYPE_DIRECT;

            // ��`�敪
            this._draftMode = DRAFT_DIV_RCV;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���O�C�����_(�����_)
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // ���_���A�N�Z�X�N���X
            this._secInfoAcs = new SecInfoAcs();
            // ���_�A�N�Z�X�N���X
            this._secInfoSetAcs = new SecInfoSetAcs();
            // �d����A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();
            // ���Ӑ�A�N�Z�X�N���X
            this._customerInfoAcs = new CustomerInfoAcs();
            // ���[�U�[�K�C�h�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();
            // ����`�f�[�^�A�N�Z�X�N���X
            this._rcvDraftDataAcs = new RcvDraftDataAcs();
            // ����`�f�[�^
            this._rcvDraftData = new RcvDraftData();
            this._rcvDraftDataClear = this._rcvDraftData.Clone();
            // �x����`�f�[�^�A�N�Z�X�N���X
            this._payDraftDataAcs = new PayDraftDataAcs();
            // �x����`�f�[�^
            this._payDraftData = new PayDraftData();
            this._payDraftDataClear = this._payDraftData.Clone();

        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        # region Private Constant

        // �c�[���o�[�c�[���L�[�ݒ�
        // ����
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        // �ۑ�
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";
        // �N���A
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        // ����
        private const string TOOLBAR_REVIVAL_KEY = "ButtonTool_Revival";
        // �폜
        private const string TOOLBAR_LOGICALDELETE_KEY = "ButtonTool_LogicalDelete";
        // ���S�폜
        private const string TOOLBAR_DELETE_KEY = "ButtonTool_Delete";
        //���O�C�����_
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LableTool_LoginSection";
        private const string TOOLBAR_LOGINSECTIONLABEL_TITLE = "LableTool_LoginSectionTitle";
        //���O�C���S����
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        // �v���O����ID
        private const string PGID = "PMTEG09101U";

        // ��`�敪
        private const string DRAFT_DIV_NAME_RCV = "����`";
        private const string DRAFT_DIV_NAME_PAY = "�x����`";

        // �v���O�����N������
        // ���ڋN��
        private const int START_TYPE_DIRECT = 0;
        // ���͂���N��
        private const int START_TYPE_CALL = 1;
        // ��`���
        private const string DRAFT_KIND_HAND = "�莝��`";
        private const string DRAFT_KIND_GET = "�旧��`";
        private const string DRAFT_KIND_DISC = "������`";
        private const string DRAFT_KIND_TRANS = "���n��`";
        private const string DRAFT_KIND_MORTGAGE = "�S�ێ�`";
        private const string DRAFT_KIND_DISHONOR = "�s�n��`";
        private const string DRAFT_KIND_PAY = "�x����`";
        private const string DRAFT_KIND_POST = "��t��`";
        private const string DRAFT_KIND_SETTLE = "���ώ�`";

        // �����U�敪
        private const string TRANS_SELF = "���U";
        private const string TRANS_OTHER = "���U";

        //�@�������[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        // ��`�敪 0:���U
        private const int DRAFT_DIV_PAY = 0;
        // ��`�敪 1:���U
        private const int DRAFT_DIV_RCV = 1;
        // ���[�h�敪 0:�V�K
        private const int MODE_TYPE_INSERT = 0;
        // ���[�h�敪 1:�X�V
        private const int MODE_TYPE_UPDATE = 1;
        // ���[�h�敪 2:�폜
        private const int MODE_TYPE_DELETE = 2;
        // �_���폜�敪 0:�L��
        private const int DEL_CD_USE = 0;
        // �_���폜�敪 1:�_���폜
        private const int DEL_CD_LOG_DEL = 1;
        // �_���폜�敪 3:���S�폜
        private const int DEL_CD_DEL = 3;
        #endregion

        # region Private Members
        // ��ƃR�[�h�擾�p
        private string _enterpriseCode;
        // ���O�C�����_(�����_)
        private string _loginSectionCode;
        // ��`�敪
        private int _draftMode;
        // ���[�h�^�C�v
        private int _modeType;
        // �ۑ��t���O
        private bool _saveFlg = false;
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        // ����`�����t���O
        private bool _rcvDraftFlg;
        private bool _rcvDraftFlgOrg;
        // �x����`���(���z�E�����`�F�b�N�p)
        private PayDraftData _payDraftDataInfo = null;
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<
        // ����t���O
        private bool _closingFlg = false;
        // �������t���O
        private bool _initFlg = false;
        // ��`�ԍ�
        private string _draftNo;
        // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
        //��s�̑O��l
        private string _bankCdBefore = string.Empty;
        //�x�X�̑O��l
        private string _branchCdBefore = string.Empty;
        // --- ADD 2010.06.28 redmine#10551 ���` ----------<<<<<
        // ����`�f�[�^
        private RcvDraftData _rcvDraftData = null;
        private RcvDraftData _rcvDraftDataOrg = null;
        private RcvDraftData _rcvDraftDataClear = null;

        // �x����`�f�[�^
        private PayDraftData _payDraftData = null;
        private PayDraftData _payDraftDataOrg = null;
        private PayDraftData _payDraftDataClear = null;

        //���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;

        // �N���敪
        private int _startType;
        private ImageList _imageList16 = null;											// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _logicDeleteButton;		// �_���폜
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;				// �폜
        private Infragistics.Win.UltraWinToolbars.ButtonTool _revivalButton;			// ����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;	// ���O�C�����_����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionLabel;			// ���O�C�����_����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		    // ���O�C���S���Җ���

        private SupplierAcs _supplierAcs = null;            // �d����A�N�Z�X�N���X
        private CustomerInfoAcs _customerInfoAcs = null;    // ���Ӑ�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs = null;              // ���_���A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        private RcvDraftDataAcs _rcvDraftDataAcs = null;    // ����`�f�[�^�A�N�Z�X�N���X
        private PayDraftDataAcs _payDraftDataAcs = null;	// �x����`�f�[�^�A�N�Z�X�N���X

        // �x����񌟍��N���X
        private PaymentSlpSearch _paymentSlpSearch;
        // �����`�[���͉��(�����^)�A�N�Z�X�N���X
        private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>������`�I����ʃN���X</summary>
        private PMTEG09101UC _selectForm;
        //��`�ۑ��O�̃`�F�b�N�t���O
        private bool _chkflg = false;
        //�I���u�������v�t���O
        private bool _clickflg = false;
        // �S���������t���O
        private bool _secondsearchflg = false;
        // �x��
        private bool _payflag = false;
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

        // ----- ADD ���N 2013/04/02 Redmine#35247 ----- >>>>>
        // �d�������I�v�V�����t���O
        private bool _supplierSummary;
        // ----- ADD ���N 2013/04/02 Redmine#35247 ----- <<<<<

        # endregion

        #region �v���p�e�B
        /// public propaty name  :  SaveFlg
        /// <summary>�ۑ��t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۑ��t���O�v���p�e�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.22</br>
        /// </remarks>
        public bool SaveFlg
        {
            get { return _saveFlg; }
            set { _saveFlg = value; }
        }
        /// public propaty name  :  RcvDraftFlg
        /// <summary>����`�����t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note       : ����`�����t���O�v���p�e�B</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2012/10/18</br>
        /// </remarks>
        public bool RcvDraftFlg
        {
            get { return _rcvDraftFlg; }
            set { _rcvDraftFlg = value; }
        }
        /// public propaty name  :  PayDraftData
        /// <summary>�x����`�f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����`�f�[�^�v���p�e�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public PayDraftData PayDraftData
        {
            get { return _payDraftData; }
            set { _payDraftData = value; }
        }
        /// public propaty name  :  RcvDraftData
        /// <summary>����`�f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�f�[�^�v���p�e�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public RcvDraftData RcvDraftData
        {
            get { return _rcvDraftData; }
            set { _rcvDraftData = value; }
        }
        #endregion

        # region ��ʏ�����
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // �c�[���o�[�����ݒ菈��
            this.ToolBarInitilSetting();

            // �{�^���A�C�R���ݒ�
            this.SetGuidButtonIcon();
           
            // �c�[���{�^��Enable�ݒ菈��
            if (this._startType == START_TYPE_DIRECT)
            {
                //�V�K���[�h
                this.SetControlEnabled(INSERT_MODE);
                this._modeType = MODE_TYPE_INSERT;
            }
            else
            {
                // ���[�h���x�����\���ɂ���
                this.Mode_Label.Visible = false;

                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    if (this._rcvDraftData.RcvDraftNo != "")
                    {
                        // �X�V���[�h             
                        this.SetControlEnabled(UPDATE_MODE);
                        this._modeType = MODE_TYPE_UPDATE;  
                    }
                    else
                    {
                        //�V�K���[�h
                        this.SetControlEnabled(INSERT_MODE);
                        this._modeType = MODE_TYPE_INSERT;
                    }
                }
                else
                {
                    if (this._payDraftData.PayDraftNo != "")
                    {
                        // �X�V���[�h             
                        this.SetControlEnabled(UPDATE_MODE);
                        this._modeType = MODE_TYPE_UPDATE;         
                    }
                    else
                    {
                        //�V�K���[�h
                        this.SetControlEnabled(INSERT_MODE);
                        this._modeType = MODE_TYPE_INSERT;
                    }
                }
            }
            // ������ʃf�[�^�ݒ�
            this.InitialScreenData();
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // �I���̃A�C�R���ݒ�
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            if (this._closeButton != null)
            {
                this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CLOSE];
            }

            // �ۑ��̃A�C�R���ݒ�
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY];
            if (this._saveButton != null)
            {
                if (this._startType == START_TYPE_CALL)
                {
                    this._saveButton.SharedProps.Caption = "�m��(&S)";
                    this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DECISION];
                }
                else
                    this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
            }



            // �N���A�̃A�C�R���ݒ�
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            if (this._clearButton != null)
            {
                this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.ALLCANCEL];
            }

            // �_���폜
            this._logicDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGICALDELETE_KEY];
            {
                this._logicDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // �폜
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_DELETE_KEY];
            {
                this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // ����
            this._revivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_REVIVAL_KEY];
            {
                this._revivalButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.UNDO];
            }

            // ���O�C�����_�̃A�C�R���ݒ�
            this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABEL_TITLE];
            if (this._loginSectionTitleLabel != null)
            {
                this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.BASE]; ;
            }

            // ���O�C���S���҂̃A�C�R���ݒ�
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // ���O�C�����_��
            this._loginSectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            if (this._loginSectionLabel != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    this._loginSectionLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }

            // ���O�C���S���Җ�
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            if (this._loginNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                this._loginNameLabel.SharedProps.Caption = employee.Name;
            }

        }

        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CustSecCdGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BankBranchGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.DraftGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; //ADD 2012/10/18
        }

        /// <summary>
        /// ������ʃf�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // ��`�敪
            this.tComboEditor_DraftDiv.Items.Clear();
            this.tComboEditor_DraftDiv.Items.Add("0", DRAFT_DIV_NAME_RCV);
            this.tComboEditor_DraftDiv.Items.Add("1", DRAFT_DIV_NAME_PAY);

            // ��`���
            this.tComboEditor_DraftKind.Clear();
            this.tComboEditor_DraftKind.Items.Add("0", DRAFT_KIND_HAND);
            this.tComboEditor_DraftKind.Items.Add("1", DRAFT_KIND_GET);
            this.tComboEditor_DraftKind.Items.Add("2", DRAFT_KIND_DISC);
            this.tComboEditor_DraftKind.Items.Add("3", DRAFT_KIND_TRANS);
            this.tComboEditor_DraftKind.Items.Add("4", DRAFT_KIND_MORTGAGE);
            this.tComboEditor_DraftKind.Items.Add("5", DRAFT_KIND_DISHONOR);
            this.tComboEditor_DraftKind.Items.Add("6", DRAFT_KIND_PAY);
            this.tComboEditor_DraftKind.Items.Add("7", DRAFT_KIND_POST);
            this.tComboEditor_DraftKind.Items.Add("9", DRAFT_KIND_SETTLE);

            // �����U�敪
            this.tComboEditor_SelfOtherTransDiv.Clear();
            this.tComboEditor_SelfOtherTransDiv.Items.Add("0", TRANS_SELF);
            this.tComboEditor_SelfOtherTransDiv.Items.Add("1", TRANS_OTHER);
        }


        # endregion ��ʏ�����

        /// <summary>
        /// ��ʃf�[�^�\������
        /// </summary>
        /// <param name="draftDivChanged">��`�敪�ύX���画�f�p</param>
        /// <remarks>
        /// <br>Note       : ��ʃf�[�^�\���������s���B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
		/// <br>UpdateNote  : 2010.05.16 �I�M redmine#7606�̑Ή�</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// <br>UpdateNote : 2013/04/02 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/05/15�z�M��</br>
        /// <br>           : redmine #35247  �d�������I�v�V�����̒���</br>
        /// </remarks>
        private void SetDataDisp(bool draftDivChanged)
        {
            // �V�K���[�h�̏ꍇ
            if (this._modeType == MODE_TYPE_INSERT)
            {
                // ���ڋN��
                if (this._startType == START_TYPE_DIRECT)
                {
                    if (!draftDivChanged)
                    {
                        // ��`�敪
                        this.tComboEditor_DraftDiv.Value = "0";
                    }
                    // �����U�敪
                    this.tComboEditor_SelfOtherTransDiv.Value = "1";
                    // ��`���
                    this.tComboEditor_DraftKind.Value = "0";
                    // �U�o��
                    this.tDateEdit_DrawingDate.Clear();
                    // ����
                    this.tDateEdit_ValidityData.Clear();
                    // ������
                    this.tDateEdit_ProcDate.SetDateTime(DateTime.Now);
                    // ����拒�_�R�[�h
                    this.tNedit_CustSecCd.Clear();
                    // ����擾�Ӑ�/�d����R�[�h
                    this.tNedit_CustCd.Clear();
                    // ����擾�Ӑ�/�d���於��
                    this.CustName_Label.Text = "";
                    // �T�C�g
                    this.tNedit_Site.SetInt(0);
					// --- ADD 2010/05/16 -------------->>>>>
					// ���z
					this.tNedit_Amounts.SetInt(0);
					// --- ADD 2010/05/16 --------------<<<<<
                }
                // �ԐڋN��
                else
                {
                    // �x����`
                    if (this._draftMode == DRAFT_DIV_PAY)
                    {
                        // ��`�敪
                        this.tComboEditor_DraftDiv.Value = "1";
                        // �����U�敪
                        this.tComboEditor_SelfOtherTransDiv.Value = this._payDraftData.DraftDivide.ToString();
                        // �U�o��
                        this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                        // ����
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._payDraftData.ValidityTerm));
                        // ��`���
                        this.tComboEditor_DraftKind.Value = this._payDraftData.DraftKindCd.ToString();
                        // ������
                        this.tDateEdit_ProcDate.SetDateTime(this.ChangeDateTime(this._payDraftData.ProcDate));
                        // ����拒�_�R�[�h
                        this.tNedit_CustSecCd.Value = this._payDraftData.AddUpSecCode;
                        // ����擾�Ӑ�/�d����R�[�h
                        this.tNedit_CustCd.SetInt(this._payDraftData.SupplierCd);
                        // ����擾�Ӑ�/�d���於��
                        this.CustName_Label.Text = this._payDraftData.SupplierSnm;
						// --- ADD 2010/05/16 -------------->>>>>
						//�@���z
						this.tNedit_Amounts.SetValue(this._payDraftData.Payment);
						// --- ADD 2010/05/16 --------------<<<<<
                        // ----- ADD ���N 2013/04/02 Redmine#35247 ----->>>>>
                        // ���O�C�����_
                        this.tNedit_Section.Value = this._payDraftData.SectionCode.Trim();
                        // ���O�C�����_��
                        SecInfoSet secInfoSet = new SecInfoSet();
                        this._secInfoAcs.GetSecInfo(this._payDraftData.SectionCode.PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                        if (secInfoSet != null)
                        {
                            this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                        }
                        // ----- ADD ���N 2013/04/02 Redmine#35247 -----<<<<<
                    }
                    // ����`
                    else
                    {
                        // ��`�敪
                        this.tComboEditor_DraftDiv.Value = "0";
                        // �����U�敪
                        this.tComboEditor_SelfOtherTransDiv.Value = this._rcvDraftData.DraftDivide.ToString();
                        // �U�o��
                        this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                        // ����
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._rcvDraftData.ValidityTerm));
                        // ��`���
                        this.tComboEditor_DraftKind.Value = this._rcvDraftData.DraftKindCd.ToString();
                        // ������
                        this.tDateEdit_ProcDate.SetDateTime(this.ChangeDateTime(this._rcvDraftData.ProcDate));
                        // ����拒�_�R�[�h
                        this.tNedit_CustSecCd.Value = this._rcvDraftData.AddUpSecCode;
                        // ����擾�Ӑ�/�d����R�[�h
                        this.tNedit_CustCd.SetInt(this._rcvDraftData.CustomerCode);
                        // ����擾�Ӑ�/�d���於��
                        this.CustName_Label.Text = this._rcvDraftData.CustomerSnm;
						// --- ADD 2010/05/16 -------------->>>>>
						//�@���z
						this.tNedit_Amounts.SetValue(this._rcvDraftData.Deposit);
						// --- ADD 2010/05/16 --------------<<<<<
                        // ----- ADD ���N 2013/04/02 Redmine#35247 ----->>>>>
                        // ���O�C�����_
                        this.tNedit_Section.Value = this._loginSectionCode.Trim();
                        // ���O�C�����_��
                        this.SectionName_Label.Text = this._loginSectionLabel.SharedProps.Caption;
                        // ----- ADD ���N 2013/04/02 Redmine#35247 -----<<<<<
                    }
                    // �T�C�g
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.Value = timeSpan.Days.ToString();
                }
                // ��`�ԍ�
                this.tNedit_DraftNo.Value = "";
                // ���O�C�����_
                //this.tNedit_Section.Value = this._loginSectionCode;// DEL zhuhh 2013/01/10 for Redmine #34123
                //this.tNedit_Section.Value = this._loginSectionCode.Trim();// ADD zhuhh 2013/01/10 for Redmine #34123 //DEL ���N 2013/04/02 Redmine#35247
                // ���O�C�����_��
                //this.SectionName_Label.Text = this._loginSectionLabel.SharedProps.Caption;//DEL ���N 2013/04/02 Redmine#35247
				// --- DEL 2010/05/16 -------------->>>>>
				//// ���z
				//this.tNedit_Amounts.SetInt(0);
				// --- DEL 2010/05/16 --------------<<<<<
                // ��s�R�[�h
                this.tNedit_BankCd.Value = "";
                // �x�X�R�[�h
                this.tNedit_BranchCd.Value = "";
                // ��s����
                this.BankName_Label.Text = "";
                // �E�v�P
                this.tEdit_Outline1.Value = "";
                // �E�v�Q
                this.tEdit_Outline2.Value = "";

            }
            // �C���A�폜���[�h�̏ꍇ
            else
            {
                // �x����`
                if (this._draftMode == DRAFT_DIV_PAY && this._payDraftData != null)
                {
                    // �x����`
                    this.tComboEditor_DraftDiv.Value = "1";
                    // ��`�ԍ�
                    this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                    // ���O�C�����_
                    this.tNedit_Section.Value = this._payDraftData.SectionCode;
                    // ���O�C�����_��
                    SecInfoSet secInfoSet = new SecInfoSet();
                    this._secInfoAcs.GetSecInfo(this._payDraftData.SectionCode.PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                    if (secInfoSet != null)
                    {
                        this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                    }
                    // ��`���
                    this.tComboEditor_DraftKind.Value = this._payDraftData.DraftKindCd.ToString();
                    // �����U�敪
                    this.tComboEditor_SelfOtherTransDiv.Value = this._payDraftData.DraftDivide.ToString();
                    // �U�o��
                    this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                    // ����
                    this.tDateEdit_ValidityData.SetLongDate(this._payDraftData.ValidityTerm);
                    // ������
                    this.tDateEdit_ProcDate.SetLongDate(this._payDraftData.ProcDate);
                    // �T�C�g
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.Value = timeSpan.Days.ToString();
                    //�@���z
                    this.tNedit_Amounts.SetValue(this._payDraftData.Payment);
                    // ����拒�_�R�[�h
                    this.tNedit_CustSecCd.Value = this._payDraftData.AddUpSecCode;
                    // ����擾�Ӑ�/�d����R�[�h
                    this.tNedit_CustCd.SetInt(this._payDraftData.SupplierCd);
                    // ����擾�Ӑ�/�d���於��
                    this.CustName_Label.Text = this._payDraftData.SupplierSnm;
                    // ��s�R�[�h
                    this.tNedit_BankCd.SetInt(this._payDraftData.BankAndBranchCd / 1000);
                    // �x�X�R�[�h
                    this.tNedit_BranchCd.SetInt(this._payDraftData.BankAndBranchCd % 1000);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    if (this._payDraftData.BankAndBranchCd == 0)
                    {
                        // ��s�R�[�h
                        this.tNedit_BankCd.Value = "";
                        // �x�X�R�[�h
                        this.tNedit_BranchCd.Value = "";
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    // ��s����
                    this.BankName_Label.Text = this._payDraftData.BankAndBranchNm;
                    // �E�v�P
                    this.tEdit_Outline1.Value = this._payDraftData.Outline1;
                    // �E�v�Q
                    this.tEdit_Outline2.Value = this._payDraftData.Outline2;
                    // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                    // ��`����
                    RcvDraft_Label.Visible = this._rcvDraftFlg;
                    // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                }
                // ����`
                else if (this._draftMode == DRAFT_DIV_RCV && this._rcvDraftData != null)
                {
                    // ����`
                    this.tComboEditor_DraftDiv.Value = "0";
                    // ��`�ԍ�
                    this.tNedit_DraftNo.Value = this._rcvDraftData.RcvDraftNo;
                    // ���O�C�����_
                    this.tNedit_Section.Value = this._rcvDraftData.SectionCode;
                    // ���O�C�����_��
                    SecInfoSet secInfoSet = new SecInfoSet();
                    this._secInfoAcs.GetSecInfo(this._rcvDraftData.SectionCode.PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                    if (secInfoSet != null)
                    {
                        this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                    }
                    // ��`���
                    this.tComboEditor_DraftKind.Value = this._rcvDraftData.DraftKindCd.ToString();
                    // �����U�敪
                    this.tComboEditor_SelfOtherTransDiv.Value = this._rcvDraftData.DraftDivide.ToString();
                    // �U�o��
                    this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                    // ����
                    this.tDateEdit_ValidityData.SetLongDate(this._rcvDraftData.ValidityTerm);
                    // ������
                    this.tDateEdit_ProcDate.SetLongDate(this._rcvDraftData.ProcDate);
                    // �T�C�g
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.Value = timeSpan.Days.ToString();
                    //�@���z
                    this.tNedit_Amounts.SetValue(this._rcvDraftData.Deposit);
                    // ����拒�_�R�[�h
                    this.tNedit_CustSecCd.Value = this._rcvDraftData.AddUpSecCode;
                    // ����擾�Ӑ�/�d����R�[�h
                    this.tNedit_CustCd.SetInt(this._rcvDraftData.CustomerCode);
                    // ����擾�Ӑ�/�d���於��
                    this.CustName_Label.Text = this._rcvDraftData.CustomerSnm;
                    // ��s�R�[�h
                    this.tNedit_BankCd.SetInt(this._rcvDraftData.BankAndBranchCd / 1000);
                    // �x�X�R�[�h
                    this.tNedit_BranchCd.SetInt(this._rcvDraftData.BankAndBranchCd % 1000);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    if (this._rcvDraftData.BankAndBranchCd == 0)
                    {
                        // ��s�R�[�h
                        this.tNedit_BankCd.Value = "";
                        // �x�X�R�[�h
                        this.tNedit_BranchCd.Value = "";
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    // ��s����
                    this.BankName_Label.Text = this._rcvDraftData.BankAndBranchNm;
                    // �E�v�P
                    this.tEdit_Outline1.Value = this._rcvDraftData.Outline1;
                    // �E�v�Q
                    this.tEdit_Outline2.Value = this._rcvDraftData.Outline2;

                }
            }
            // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
            if (this.tComboEditor_DraftDiv.Value.ToString() == "0")
            {
                this._draftMode = DRAFT_DIV_RCV;
            }
            else
            {
                this._draftMode = DRAFT_DIV_PAY;
            }
            // --- ADD 2010.06.28 redmine#10551 ���` ----------<<<<<
        }

        /// <summary>
        /// �R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �R���g���[����Enabled������s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                // �V�K
                case INSERT_MODE:
                    {
                        // ��`�敪
                        if (this._startType == START_TYPE_DIRECT)
                        {

                            // �d���x���Ǘ��I�v�V�������������Ă���ꍇ
                            if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment) == PurchaseStatus.Contract ||
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment) == PurchaseStatus.Trial_Contract)
                            {
                                tComboEditor_DraftDiv.Enabled = true;
                            }
                            else
                            {
                                tComboEditor_DraftDiv.Enabled = false;
                            }
                        }
                        else
                        {
                            tComboEditor_DraftDiv.Enabled = false;
                        }
                        // ��`�ԍ�
                        tNedit_DraftNo.Enabled = true;
                        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                        // ��`�K�C�h�{�^��
                        if (this._startType != START_TYPE_DIRECT &&
                            this._draftMode == DRAFT_DIV_PAY)
                        {
                            DraftGuide_Button.Visible = true;
                        }
                        else
                        {
                            DraftGuide_Button.Visible = false;
                        }
                        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // ���_
                            tNedit_Section.Enabled = true;
                            // ���_�K�C�h�{�^��
                            SectionGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // ���_
                            tNedit_Section.Enabled = false;
                            // ���_�K�C�h�{�^��
                            SectionGuide_Button.Enabled = false;
                        }

                        // ��`���
                        tComboEditor_DraftKind.Enabled = true;
                        // �����U�敪
                        tComboEditor_SelfOtherTransDiv.Enabled = true;
                        // �U�o��
                        tDateEdit_DrawingDate.Enabled = true;
                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // ����
                            tDateEdit_ValidityData.Enabled = true;
                            // ���z
                            tNedit_Amounts.Enabled = true;
                            // �����@���_
                            tNedit_CustSecCd.Enabled = true;
                            // �����@���_�K�C�h�{�^��
                            CustSecCdGuide_Button.Enabled = true;
                            // �����@���Ӑ�^�d����
                            tNedit_CustCd.Enabled = true;
                            // �����@���Ӑ�^�d����K�C�h�{�^��
                            CustomerGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // ����
                            tDateEdit_ValidityData.Enabled = false;
                            // ���z
                            tNedit_Amounts.Enabled = false;
                            // �����@���_
                            tNedit_CustSecCd.Enabled = false;
                            // �����@���_�K�C�h�{�^��
                            CustSecCdGuide_Button.Enabled = false;
                            // �����@���Ӑ�^�d����
                            tNedit_CustCd.Enabled = false;
                            // �����@���Ӑ�^�d����K�C�h�{�^��
                            CustomerGuide_Button.Enabled = false;
                        }
                      
                        // ��s�R�[�h
                        tNedit_BankCd.Enabled = true;
                        // �x�X�R�[�h
                        tNedit_BranchCd.Enabled = true;
                        // ��s�x�X�K�C�h
                        BankBranchGuide_Button.Enabled = true;
                        // �E�v�P
                        tEdit_Outline1.Enabled = true;
                        // �E�v�Q
                        tEdit_Outline2.Enabled = true;
                        // ����{�^��
                        this._saveButton.SharedProps.Visible = true;
                        this._clearButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }

                // �X�V
                case UPDATE_MODE:
                    {
                        // ��`�敪
                        tComboEditor_DraftDiv.Enabled = false;
                        // --- DEL 2010.06.28 redmine#10551 ���` ---------->>>>>
                        // ���_
                        //tNedit_Section.Enabled = false;
                        // ���_�K�C�h�{�^��
                        //SectionGuide_Button.Enabled = false;
                        // --- DEL 2010.06.28 redmine#10551 ���` ----------<<<<<

                        // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // ���_
                            tNedit_Section.Enabled = true;
                            // ���_�K�C�h�{�^��
                            SectionGuide_Button.Enabled = true;
                            // ����拒�_
                            tNedit_CustSecCd.Enabled = true;
                            // �����@���_�K�C�h�{�^��
                            CustSecCdGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // ���_
                            tNedit_Section.Enabled = false;
                            // ���_�K�C�h�{�^��
                            SectionGuide_Button.Enabled = false;
                            // ����拒�_
                            tNedit_CustSecCd.Enabled = false;
                            // �����@���_�K�C�h�{�^��
                            CustSecCdGuide_Button.Enabled = false;
                        }
                        // --- ADD 2010.06.28 redmine#10551 ���` ----------<<<<<

                        // �U�o��
                        //tDateEdit_DrawingDate.Enabled = true;// DEL zhuhh 2013/01/10 for Redmine #34123

                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // ��`�ԍ�
                            tNedit_DraftNo.Enabled = false;
                            // --- DEL 2010.06.28 redmine#10551 ���` ---------->>>>>
                            // ��`���
                            //tComboEditor_DraftKind.Enabled = false;
                            // �����U�敪
                            //tComboEditor_SelfOtherTransDiv.Enabled = false;
                            // --- DEL 2010.06.28 redmine#10551 ���` ----------<<<<<
                            // ����
                            tDateEdit_ValidityData.Enabled = true;
                            // ���z
                            tNedit_Amounts.Enabled = true;
                            // �����@���Ӑ�^�d����
                            tNedit_CustCd.Enabled = true;
                            // �����@���Ӑ�^�d����K�C�h�{�^��
                            CustomerGuide_Button.Enabled = true;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            this.tNedit_BankCd.Enabled = false;
                            this.tNedit_BranchCd.Enabled = false;
                            this.BankBranchGuide_Button.Enabled = false;
                            this.tDateEdit_DrawingDate.Enabled = false;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        }
                        else
                        {
                            // ��`�ԍ�
                            tNedit_DraftNo.Enabled = true;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            // ��s�R�[�h
                            tNedit_BankCd.Enabled = true;
                            // �x�X�R�[�h
                            tNedit_BranchCd.Enabled = true;
                            // ��s�x�X�K�C�h
                            BankBranchGuide_Button.Enabled = true;
                            // �U�o��
                            this.tDateEdit_DrawingDate.Enabled = true;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                            // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                            // ��`�K�C�h�{�^��
                            if (this._draftMode == DRAFT_DIV_PAY)
                            {
                                DraftGuide_Button.Visible = true;
                            }
                            else
                            {
                                DraftGuide_Button.Visible = false;
                            }
                            // --- ADD 2012/10/18 --------------------------------------------------<<<<<

                            // --- DEL 2010.06.28 redmine#10551 ���` ---------->>>>>
                            // ��`���
                            //tComboEditor_DraftKind.Enabled = true;
                            // �����U�敪
                            //tComboEditor_SelfOtherTransDiv.Enabled = true;
                            // --- DEL 2010.06.28 redmine#10551 ���` ----------<<<<<
                            // ����
                            tDateEdit_ValidityData.Enabled = false;
                            // ���z
                            tNedit_Amounts.Enabled = false;
                            // �����@���Ӑ�^�d����
                            tNedit_CustCd.Enabled = false;
                            // �����@���Ӑ�^�d����K�C�h�{�^��
                            CustomerGuide_Button.Enabled = false;
                        }
                        // --- DEL 2010.06.28 redmine#10551 ���` ---------->>>>>
                        // �����@���_
                        //tNedit_CustSecCd.Enabled = false;
                        // �����@���_�K�C�h�{�^��
                        //CustSecCdGuide_Button.Enabled = false;
                        // --- DEL 2010.06.28 redmine#10551 ���` ----------<<<<<
                        // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
                        // ��`���
                        tComboEditor_DraftKind.Enabled = true;
                        // �����U�敪
                        tComboEditor_SelfOtherTransDiv.Enabled = true;
                        // --- ADD 2010.06.28 redmine#10551 ���` ----------<<<<<
                        /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        // ��s�R�[�h
                        tNedit_BankCd.Enabled = true;
                        // �x�X�R�[�h
                        tNedit_BranchCd.Enabled = true;
                        // ��s�x�X�K�C�h
                        BankBranchGuide_Button.Enabled = true;
                           ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                        // �E�v�P
                        tEdit_Outline1.Enabled = true;
                        // �E�v�Q
                        tEdit_Outline2.Enabled = true;

                        // ����{�^��
                        this._saveButton.SharedProps.Visible = true;
                        this._clearButton.SharedProps.Visible = true;
                        if(this._startType == START_TYPE_DIRECT)
                            this._logicDeleteButton.SharedProps.Visible = true;
                        else
                            this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = UPDATE_MODE;
                        break;
                    }
                // �폜
                case DELETE_MODE:
                    {
                        // ��`�敪
                        tComboEditor_DraftDiv.Enabled = false;
                        // ��`�ԍ�
                        tNedit_DraftNo.Enabled = false;
                        // ���_
                        tNedit_Section.Enabled = false;
                        // ���_�K�C�h�{�^��
                        SectionGuide_Button.Enabled = false;
                        // ��`���
                        tComboEditor_DraftKind.Enabled = false;
                        // �����U�敪
                        tComboEditor_SelfOtherTransDiv.Enabled = false;
                        // �U�o��
                        tDateEdit_DrawingDate.Enabled = false;
                        // ����
                        tDateEdit_ValidityData.Enabled = false;
                        // ���z
                        tNedit_Amounts.Enabled = false;
                        // �����@���_
                        tNedit_CustSecCd.Enabled = false;
                        // �����@���_�K�C�h�{�^��
                        CustSecCdGuide_Button.Enabled = false;
                        // �����@���Ӑ�^�d����
                        tNedit_CustCd.Enabled = false;
                        // �����@���Ӑ�^�d����K�C�h�{�^��
                        CustomerGuide_Button.Enabled = false;
                        // ��s�R�[�h
                        tNedit_BankCd.Enabled = false;
                        // �x�X�R�[�h
                        tNedit_BranchCd.Enabled = false;
                        // ��s�x�X�K�C�h
                        BankBranchGuide_Button.Enabled = false;
                        // �E�v�P
                        tEdit_Outline1.Enabled = false;
                        // �E�v�Q
                        tEdit_Outline2.Enabled = false;
                        // ����{�^��
                        this._saveButton.SharedProps.Visible = false;
                        this._clearButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = true;
                        this._revivalButton.SharedProps.Visible = true;

                        this.Mode_Label.Text = DELETE_MODE;

                        break;
                    }
            }
        }


        # region �ۑ�����
        /// <summary>
        ///�@�ۑ�����(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool bStatus = false;

            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕۑ������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return (false);
            }

            // ���̓`�F�b�N
            bStatus = this.CheckInputScreen();

            if (bStatus != true)
            {
                return (false);
            }

            // ADD 2013/02/22�A T.Miyamoto ------------------------------>>>>>
            bool InsChkFlg = false;
            if (this._startType == START_TYPE_DIRECT) // ���ڋN��
            {
                if (this._modeType == MODE_TYPE_INSERT) // �V�K���[�h
                {
                    // ���ڋN���ŐV�K���[�h�͏d���`�F�b�N�����s
                    InsChkFlg = true;
                }
            }
            else
            {
                // UPD 2013/02/22�E T.Miyamoto ------------------------------>>>>>
                //if ((this._draftMode == DRAFT_DIV_RCV) ||
                if (((this._draftMode == DRAFT_DIV_RCV) && ((this._rcvDraftData.RcvDraftNo != this._rcvDraftDataOrg.RcvDraftNo) ||
                                                            (this._rcvDraftData.BankAndBranchCd != this._rcvDraftDataOrg.BankAndBranchCd) ||
                                                            (this._rcvDraftData.DraftDrawingDate != this._rcvDraftDataOrg.DraftDrawingDate))) ||
                // UPD 2013/02/22�E T.Miyamoto ------------------------------>>>>>
                    ((this._draftMode == DRAFT_DIV_PAY) && ((this._payDraftData.PayDraftNo != this._payDraftDataOrg.PayDraftNo) ||
                                                            (this._payDraftData.BankAndBranchCd != this._payDraftDataOrg.BankAndBranchCd) ||
                                                            (this._payDraftData.DraftDrawingDate != this._payDraftDataOrg.DraftDrawingDate))))
                {
                    // �������͂���N���܂���
                    // �x�����͂���N���ŃL�[���ڂɕύX���������ꍇ�A�d���`�F�b�N�����s
                    InsChkFlg = true;
                }
            }
            if (InsChkFlg)
            {
                if (!DraftInsertCheck())
                {
                    return (false);
                }
            }
            // ADD 2013/02/22�A T.Miyamoto ------------------------------<<<<<

            this.ScreenToDraftData();

            this.DrafDataSetExceptScreen();

            if (this._startType == START_TYPE_DIRECT)
            {
                // DEL 2013/02/22�A T.Miyamoto ------------------------------<<<<<
                //// ADD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                //// �V�K���[�h�̏ꍇ�A��`�d���`�F�b�N�����s
                //if (this._modeType == MODE_TYPE_INSERT)
                //{
                //    if (!DraftInsertCheck())
                //    {
                //        return (false);
                //    }
                //}
                //// ADD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                // DEL 2013/02/22�A T.Miyamoto ------------------------------<<<<<

                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // �x����`
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    List<PayDraftData> payDraftDataList = new List<PayDraftData>();
                    payDraftDataList.Add(this._payDraftData);
                    status = this._payDraftDataAcs.Write(ref payDraftDataList);
                }
                else
                {
                    List<RcvDraftData> rcvDraftDataList = new List<RcvDraftData>();
                    rcvDraftDataList.Add(this._rcvDraftData);
                    status = this._rcvDraftDataAcs.Write(ref rcvDraftDataList);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);                     
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status);

                            return false;
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "SaveProc",
                                           "�ۑ������Ɏ��s���܂����B",
                                           status,
                                           MessageBoxButtons.OK);
                                                

                            return false;
                        }
                }
                
            }

            this._saveFlg = true;

            return true;
        }
        # endregion �ۑ�����

        # region �`�F�b�N����
        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private bool CheckInputScreen()
        {
            string errMsg = "";

            try
            {
                // ��`�ԍ�
                if (this.tNedit_DraftNo.DataText.Trim() == "")
                {
                    errMsg = "��`�ԍ�����͂��ĉ������B";

                    this.tNedit_DraftNo.Focus();
                    return (false);
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                // ��s�R�[�h
                else if (this.tNedit_BankCd.DataText == "")
                {
                    errMsg = "��s����͂��ĉ������B";
                    this.tNedit_BankCd.Focus();
                    return (false);
                }
                // �x�X�R�[�h
                else if (this.tNedit_BranchCd.DataText == "")
                {
                    errMsg = "��s����͂��ĉ������B";
                    this.tNedit_BranchCd.Focus();
                    return (false);
                }
                // �U�o��
                else if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "�U�o������͂��ĉ������B";

                    this.tDateEdit_DrawingDate.Focus();
                    return (false);
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                // ���_
                else if (this.tNedit_Section.DataText.Trim() == "" && this._startType == START_TYPE_DIRECT)
                {
                    errMsg = "���_����͂��ĉ������B";

                    this.tNedit_Section.Focus();
                    return (false);
                }
                /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                // �U�o��
                else if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "�U�o������͂��ĉ������B";

                    this.tDateEdit_DrawingDate.Focus();
                    return (false);
                }
                   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                // ����
                else if (this.tDateEdit_ValidityData.GetDateTime() == DateTime.MinValue && this._startType == START_TYPE_DIRECT)
                {
                    errMsg = "��������͂��ĉ������B";

                    this.tDateEdit_ValidityData.Focus();
                    return (false);
                }
                // ���z
                else if (this.tNedit_Amounts.GetInt() == 0 && this._startType == START_TYPE_DIRECT)
                {
                    errMsg = "���z����͂��ĉ������B";

                    this.tNedit_Amounts.Focus();
                    return (false);
                }
                // ����拒�_
                else if (this.tNedit_CustSecCd.GetInt() == 0 && this._startType == START_TYPE_DIRECT)
                {
                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                    //errMsg = "���_����͂��ĉ������B";
                    if (_draftMode == DRAFT_DIV_PAY)
                        errMsg = "�d�������͂��ĉ������B";
                    else
                        errMsg = "���Ӑ����͂��ĉ������B";
                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                    
                    this.tNedit_CustSecCd.Focus();
                    return (false);
                }
                // ����擾�Ӑ�/�����d����
                else if (this.tNedit_CustCd.GetInt() == 0 && this._startType == START_TYPE_DIRECT)
                {
                    // �x����`
                    if (_draftMode == DRAFT_DIV_PAY)
                        errMsg = "�d�������͂��ĉ������B";
                    else
                        errMsg = "���Ӑ����͂��ĉ������B";

                    this.tNedit_CustCd.Focus();
                    return (false);
                }
                /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                // ��s�R�[�h
                else if (this.tNedit_BankCd.DataText == "")
                {
                    errMsg = "��s����͂��ĉ������B";
                    this.tNedit_BankCd.Focus();
                    return (false);
                }
                // �x�X�R�[�h
                else if (this.tNedit_BranchCd.DataText == "")
                {
                    errMsg = "��s����͂��ĉ������B";
                    this.tNedit_BranchCd.Focus();
                    return (false);
                }
                 ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 , this.ToString()
                                 , errMsg
                                 , 0
                                 , MessageBoxButtons.OK);

                }
            }

            return true;
        }
        # endregion

        // ADD 2013/02/15 T.Miyamoto ------------------------------>>>>>
        # region ��`�f�[�^�d���`�F�b�N����
        /// <summary>
        /// ��`�f�[�^�d���`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��`�f�[�^�̏d���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2013.02.15</br>
        /// </remarks>
        private bool DraftInsertCheck()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (this._draftMode == DRAFT_DIV_RCV)
            {
                // ����`
                List<RcvDraftData> retList = new List<RcvDraftData>();
                RcvDraftData paraRcvDraftData = new RcvDraftData();
                paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                paraRcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);
                // ADD 2013/02/22�C T.Miyamoto ------------------------------>>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    this._rcvDraftData = new RcvDraftData();
                }
                // ADD 2013/02/22�C T.Miyamoto ------------------------------<<<<<
            }
            else
            {
                // �x����`
                List<PayDraftData> retList = new List<PayDraftData>();
                PayDraftData paraPayDraftData = new PayDraftData();
                paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                paraPayDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                // ADD 2013/02/22�C T.Miyamoto ------------------------------>>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    this._payDraftData = new PayDraftData();
                }
                // ADD 2013/02/22�C T.Miyamoto ------------------------------<<<<<
                // ADD 2013/02/22�A T.Miyamoto ------------------------------>>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if ((this._startType == START_TYPE_CALL) &&
                        (this._draftMode == DRAFT_DIV_PAY))
                    {
                        PayDraftData payDraftDataGet = retList[0];
                        if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            if (payDraftDataGet.PaymentSlipNo != 0)
                            {
                                SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                             , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B", ""
                                             , payDraftDataGet.PayDraftNo
                                             , payDraftDataGet.BankAndBranchCd / 1000
                                             , payDraftDataGet.BankAndBranchCd % 1000
                                             , payDraftDataGet.DraftDrawingDate);
                                return false;
                            }
                            else
                            {
                                DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                   , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɓo�^����Ă��܂��B", "�����������s���܂����H"
                                                                   , payDraftDataGet.PayDraftNo
                                                                   , payDraftDataGet.BankAndBranchCd / 1000
                                                                   , payDraftDataGet.BankAndBranchCd % 1000
                                                                   , payDraftDataGet.DraftDrawingDate);
                                if (result != DialogResult.Yes)
                                {
                                    return false;
                                }
                                // ADD 2013/02/22�D T.Miyamoto ------------------------------>>>>>
                                else
                                {
                                    // �X�V���[�h�̏������������s��
                                    this._modeType = MODE_TYPE_UPDATE;
                                    // �R���g���[��Enabled����
                                    this.SetControlEnabled(UPDATE_MODE);

                                    // �x����`���ێ�(���z�E�����`�F�b�N�p)
                                    this._payDraftDataInfo = payDraftDataGet.Clone();

                                    // ��ʏ��𔽉f
                                    int ProcDate = this.tDateEdit_ProcDate.GetLongDate();                     // ������
                                    payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // ����
                                    payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // ���z

                                    // �������Đݒ�
                                    this._payDraftData = payDraftDataGet.Clone();
                                    this._payDraftDataOrg = payDraftDataGet.Clone();
                                }
                                // ADD 2013/02/22�D T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        else
                        {
                            SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                         , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", ""
                                         , payDraftDataGet.PayDraftNo
                                         , payDraftDataGet.BankAndBranchCd / 1000
                                         , payDraftDataGet.BankAndBranchCd % 1000
                                         , payDraftDataGet.DraftDrawingDate);
                            return false;
                        }
                        return true;
                    }
                }
                // ADD 2013/02/22�A T.Miyamoto ------------------------------<<<<<
            }
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                SearchMsgShow(emErrorLevel.ERR_LEVEL_EXCLAMATION, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                             ,"���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɑ��݂��܂��B", ""
                             , this.tNedit_DraftNo.Text.Trim()
                          �@ , this.tNedit_BankCd.GetInt()
                             , this.tNedit_BranchCd.GetInt()
                             , this.tDateEdit_DrawingDate.GetDateTime());
                return false;
            }
            return true;
        }
        # endregion
        // ADD 2013/02/15 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// ��`�f�[�^���ύX�`�F�b�N����
        /// </summary>
        /// <param name="saveFlg">�ۑ��t���O</param>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂪕ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private bool CompareDraftData(ref bool saveFlg)
        {
            this.ScreenToDraftData();
            // �f�[�^��r
            // �x����`
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                if (this._payDraftData.Equals(this._payDraftDataOrg))
                {
                    return true;
                }
                else
                {
                    string msg;
                    if (_startType == START_TYPE_CALL)
                        msg = "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n\r\n" + "�m�肵�Ă��悢�ł����H";
                    else
                        msg = "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n\r\n" + "�o�^���Ă��悢�ł����H";

                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,                   // �G���[���x��
                        PGID, 			                                      // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
            // ����`
            else
            {
                if (this._rcvDraftData.Equals(this._rcvDraftDataOrg))
                {
                    return true;
                }
                else
                {
                    string msg;
                    if (_startType == START_TYPE_CALL)
                        msg = "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n\r\n" + "�m�肵�Ă��悢�ł����H";
                    else
                        msg = "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n\r\n" + "�o�^���Ă��悢�ł����H";

                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,                   // �G���[���x��
                        PGID, 			                                      // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// ��`�f�[�^���ύX�`�F�b�N����(��ׂ�t���O���p)
        /// </summary>
        /// <param name="saveFlg">�ۑ��t���O</param>
        /// <param name="compareFlg">��ׂ�t���O</param>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂪕ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private bool CompareDraftDataWithCompareFlg(ref bool saveFlg, ref bool compareFlg)
        {
            this.ScreenToDraftData();
            // �f�[�^��r
            // �x����`
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                if (this._payDraftData.Equals(this._payDraftDataOrg))
                {
                    compareFlg = true;
                    return true;
                }
                else
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PGID, 			                                      // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
            // ����`
            else
            {
                if (this._rcvDraftData.Equals(this._rcvDraftDataOrg))
                {
                    compareFlg = true;
                    return true;
                }
                else
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PGID, 			                                      // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
        }

        # region ��ʏ��擾
        /// <summary>
        /// ��ʏ�����`�f�[�^�Ɋi�[����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂��`�f�[�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void ScreenToDraftData()
        {
            // �x����`
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                // ��`�ԍ�
                this._payDraftData.PayDraftNo = this.tNedit_DraftNo.Text;
                // ���O�C�����_
                this._payDraftData.SectionCode = this.tNedit_Section.Text;
                // ��`���
                this._payDraftData.DraftKindCd = System.Convert.ToInt32(this.tComboEditor_DraftKind.Value);
                // �����U�敪
                this._payDraftData.DraftDivide = System.Convert.ToInt32(this.tComboEditor_SelfOtherTransDiv.Value);
                // �U�o��
                this._payDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                // ����
                this._payDraftData.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate();
                // ������
                this._payDraftData.ProcDate = this.tDateEdit_ProcDate.GetLongDate();
                // ���z
                this._payDraftData.Payment = this.tNedit_Amounts.GetInt();
                // ����拒�_�R�[�h
                this._payDraftData.AddUpSecCode = this.tNedit_CustSecCd.Text;
                // ����擾�Ӑ�/�d����R�[�h
                this._payDraftData.SupplierCd = this.tNedit_CustCd.GetInt();
                // ����擾�Ӑ於�̗���
                this._payDraftData.SupplierSnm = this.CustName_Label.Text;
                // ��s�x�X�R�[�h
                this._payDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                // ��s����
                this._payDraftData.BankAndBranchNm = this.BankName_Label.Text;
                // �E�v�P
                this._payDraftData.Outline1 = this.tEdit_Outline1.Text;
                // �E�v�Q
                this._payDraftData.Outline2 = this.tEdit_Outline2.Text;
            }
            // ����`
            else
            {
                // ��`�ԍ�
                this._rcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text;
                // ���O�C�����_
                this._rcvDraftData.SectionCode = this.tNedit_Section.Text;
                // ��`���
                this._rcvDraftData.DraftKindCd = System.Convert.ToInt32(this.tComboEditor_DraftKind.Value);
                // �����U�敪
                this._rcvDraftData.DraftDivide = System.Convert.ToInt32(this.tComboEditor_SelfOtherTransDiv.Value);
                // �U�o��
                this._rcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                // ����
                this._rcvDraftData.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate();
                // ������
                this._rcvDraftData.ProcDate = this.tDateEdit_ProcDate.GetLongDate();
                // ���z
                this._rcvDraftData.Deposit = this.tNedit_Amounts.GetInt();
                // ����拒�_�R�[�h
                this._rcvDraftData.AddUpSecCode = this.tNedit_CustSecCd.Text;
                // ����擾�Ӑ�/�d����R�[�h
                this._rcvDraftData.CustomerCode = this.tNedit_CustCd.GetInt();
                // ����擾�Ӑ於�̗���
                this._rcvDraftData.CustomerSnm = this.CustName_Label.Text;
                // ��s�x�X�R�[�h
                this._rcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                // ��s����
                this._rcvDraftData.BankAndBranchNm = this.BankName_Label.Text;
                // �E�v�P
                this._rcvDraftData.Outline1 = this.tEdit_Outline1.Text;
                // �E�v�Q
                this._rcvDraftData.Outline2 = this.tEdit_Outline2.Text;

            }
        }
        # endregion

        # region ���̂Ƃ��납����擾
        /// <summary>
        /// ���̂Ƃ��납�������`�f�[�^�Ɋi�[����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ������`�f�[�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void DrafDataSetExceptScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // �x����`
            if (this._draftMode == DRAFT_DIV_PAY)
            {

                // ��`���ϓ�
                // ��`��ʂ��9:���ϣ
                if (this._payDraftData.DraftKindCd == 9)
                    this._payDraftData.DraftStmntDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                else
                    this._payDraftData.DraftStmntDate = 0;

                // �x�����t
                if( this._modeType  == MODE_TYPE_INSERT)
                    this._payDraftData.PaymentDate = DateTime.Now;

                // �d���於1 �d���於2
                Supplier supplier = new Supplier();
                status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_CustCd.GetInt());
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this._payDraftData.SupplierNm1 = supplier.SupplierNm1;
                    this._payDraftData.SupplierNm2 = supplier.SupplierNm1;
                }
            }
            else
            {
                // ��`���ϓ�
                // ��`��ʂ��9:���ϣ
                if (this._rcvDraftData.DraftKindCd == 9)
                    this._rcvDraftData.DraftStmntDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                else
                    this._rcvDraftData.DraftStmntDate = 0;
                // �������t
                if (this._modeType == MODE_TYPE_INSERT)
                    this._rcvDraftData.DepositDate = DateTime.Now;

                // ���Ӑ於1 ���Ӑ於2
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this.tNedit_CustCd.GetInt(), true, out customerInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.CustName_Label.Text = customerInfo.CustomerSnm;
                    this.tNedit_CustSecCd.Value = customerInfo.MngSectionCode;
                    this._rcvDraftData.CustomerName = customerInfo.Name;
                    this._rcvDraftData.CustomerName2 = customerInfo.Name2;
                }
            }
        }
        # endregion

        #region ��ʃC�x���g
        #region FormLoading�C�x���g
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void PMTEG09101UA_Load(object sender, EventArgs e)
        {
            //�@�������t���O��True�ɐݒ�
            this._initFlg = true;

            // ��ʏ�����
            InitialScreenSetting();

            // ���ڋN��
            if (this._startType == START_TYPE_DIRECT)
            {
                this.tNedit_CustCd.MaxLength = 8;
            }
            // �ԐڋN��
            else
            {
                if (_draftMode == DRAFT_DIV_PAY)
                    this.tNedit_CustCd.MaxLength = 6;
                else
                    this.tNedit_CustCd.MaxLength = 8;
            }
            if (this.tNedit_CustCd.MaxLength == 6)
                this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            else
                this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));

            // ��ʕ\������
            this.SetDataDisp(false);

            // ���ڋN��
            if (this._startType == START_TYPE_DIRECT)
            {
                // ��ʐݒ肩��A�������ɕۑ�����
                this.SaveNewDraftMemory();
            }
            // �����t�H�[�J�X�ݒ�
            this.tComboEditor_DraftDiv.Select();

            // --- ADD 2012/10/18 -------------------------------------------------->>>>>
            // �x����`���擾
            this.PayDraftInfoGet();
            // ����`�f�[�^�����t���O
            this._rcvDraftFlgOrg = this._rcvDraftFlg;
            // --- ADD 2012/10/18 --------------------------------------------------<<<<<

            //�@�������t���O��False�ɐݒ�
            this._initFlg = false;
        }
        #endregion

        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        #region FormShown�C�x���g
        /// <summary>
        /// FormShown�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʕ\�����ɔ������܂��B</br>      
        /// <br>Programmer  : �{�{</br>
        /// <br>Date        : 2012/10/18</br>
        /// </remarks>
        private void PMTEG09101UA_Shown(object sender, EventArgs e)
        {
            // �x����`���`�F�b�N����
            this.PayDraftCheck();
        }
        #endregion
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        #region FormClosing�C�x���g
        /// <summary>
        /// FormClosing�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		:	�t�H�[����������O�ɔ������܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void PMTEG09101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._closingFlg)
            {
                bool saveFlg = false;
                // ���͒��̃f�[�^�`�F�b�N
                if (this.CompareDraftData(ref saveFlg))
                {
                    if (saveFlg)
                    {
                        // ��ʏ�����
                        this.InitDisp();
                        // ���鑀���������
                        e.Cancel = true;

                    }
                }
                else
                {
                    // ���鑀���������
                    e.Cancel = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            bool saveFlg = false;
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // ���͒��̃f�[�^�`�F�b�N
                        if (this.CompareDraftData(ref saveFlg))
                        {
                            if (this._startType == START_TYPE_DIRECT)
                            {
                                if (saveFlg)
                                {
                                    // ��ʏ�����
                                    this.InitDisp();
                                }
                                else
                                {
                                    this._closingFlg = true;
                                    this.Close();
                                }
                            }
                            else
                            {
                                this._closingFlg = true;
                                this.Close();
                            }
                        }
                        break;
                    }
                // �ۑ�
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        if (this.SaveProc())
                        {
                            if (this._startType == START_TYPE_DIRECT)
                            {
                                // ��ʏ�����
                                this.InitDisp();
                                this.tNedit_DraftNo.Focus(); // ADD 2010.06.28 ���`
                            }
                            else
                            {
                                this._closingFlg = true;
                                this.Close();
                            }
                        }
                        break;
                    }
                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        // ���͒��̃f�[�^�`�F�b�N
                        if (this.CompareDraftData(ref saveFlg))
                        {
                            if (this._startType == START_TYPE_DIRECT)
                            {
                                // ��ʏ�����
                                this.InitDisp();
                                this.tNedit_DraftNo.Focus(); // ADD 2010.06.28 ���`
                            }
                            else
                            {
                                if (saveFlg)
                                {
                                    this._closingFlg = true;
                                    this.Close();
                                }
                                else
                                {
                                    if (this._draftMode == DRAFT_DIV_RCV)
                                    {
                                        this._rcvDraftData = this._rcvDraftDataClear.Clone();
                                        this._rcvDraftDataOrg = this._rcvDraftDataClear.Clone();
                                    }
                                    else
                                    {
                                        this._payDraftData = this._payDraftDataClear.Clone();
                                        this._payDraftDataOrg = this._payDraftDataClear.Clone();
                                        this._rcvDraftFlg = this._rcvDraftFlgOrg; // ADD 2012/10/18
                                    }
                                    this._initFlg = true;
                                    this.SetDataDisp(false);
                                    this._initFlg = false;
                                    this.tNedit_DraftNo.Focus(); // ADD 2010.06.28 ���`
                                }
                            }
                        }
                        break;
                    }
                // �_���폜
                case TOOLBAR_LOGICALDELETE_KEY:
                    {
                        DateTime targetDate;
                        DialogResult dr;

                        // �I�t���C����ԃ`�F�b�N
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "��ʘ_���폜�����Ɏ��s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // �x����`
                        if (this._draftMode == DRAFT_DIV_PAY)
                        {
                            if (this._paymentSlpSearch == null)
                                this._paymentSlpSearch = new PaymentSlpSearch();

                            targetDate = this._paymentSlpSearch.GetHisTotalDayMonthlyAccPay(this.tNedit_CustSecCd.Text.Trim());
                            if (targetDate != DateTime.MinValue)
                            {
                                // ���������O�񌎎��X�V���ȑO�̏ꍇ
                                if (this._payDraftData.ProcDate <= Convert.ToInt32(targetDate.ToString("yyyyMMdd")))
                                {
                                    dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 PGID,
                                                 "���������O��d�������X�V���ȑO�ł��B" + "\r\n" + "�f�[�^��_���폜���āA��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.Yes)
                                    {
                                        // �_���폜����
                                        this.LogicalDeleteProc();
                                    }
                                    break;
                                }
                            }
                        }
                        // ����`
                        else
                        {
                            if (this._inputDepositNormalTypeAcs == null)
                                this._inputDepositNormalTypeAcs = new InputDepositNormalTypeAcs();
                            targetDate = this._inputDepositNormalTypeAcs.GetHisTotalDayMonthlyAccRec(this.tNedit_CustSecCd.Text.Trim());
                            if (targetDate != DateTime.MinValue)
                            {
                                // ���������O�񌎎��X�V���ȑO�̏ꍇ
                                if (this._rcvDraftData.ProcDate <= Convert.ToInt32(targetDate.ToString("yyyyMMdd")))
                                {
                                    dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 PGID,
                                                 "���������O�񔄏㌎���X�V���ȑO�ł��B" + "\r\n" + "�f�[�^��_���폜���āA��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.Yes)
                                    {
                                        // �_���폜����
                                        this.LogicalDeleteProc();
                                    }
                                    break;
                                }
                            }
                        }

                        // ���ϓ��`�F�b�N
                        bool checkFlg = false;
                        if (_draftMode == DRAFT_DIV_RCV)
                        {
                            if (this._rcvDraftData.DraftStmntDate == 0)
                            {
                                checkFlg = true;
                            }
                        }
                        else
                        {
                            if (this._payDraftData.DraftStmntDate == 0)
                            {
                                checkFlg = true;
                            }
                        }
                        if (checkFlg)
                        {

                            dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                    PGID,
                                                    "�����ς̎�`�ł��B" + "\r\n" + "�f�[�^��_���폜���āA��낵���ł����H",
                                                    0,
                                                    MessageBoxButtons.YesNo);

                            if (dr == DialogResult.Yes)
                            {
                                // �_���폜����
                                this.LogicalDeleteProc();
                                break;
                            }
                            else
                                break;
                        }

                        dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 PGID,
                                                 "�f�[�^��_���폜���܂��B" + "\r\n" + "��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            // �_���폜����
                            this.LogicalDeleteProc();
                        }

                        break;
                    }
                // �폜
                case TOOLBAR_DELETE_KEY:
                    {
                        // �I�t���C����ԃ`�F�b�N
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "��ʕ����폜�����Ɏ��s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                  PGID,
                                  "�f�[�^�����S�폜���܂��B" + "\r\n" + "��낵���ł����H",
                                  0,
                                  MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            this.DeleteProc();
                        }
                        break;
                    }
                // ����
                case TOOLBAR_REVIVAL_KEY:
                    {
                        // �I�t���C����ԃ`�F�b�N
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "��ʕ��������Ɏ��s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        this.RevivalProc();
                        break;
                    }
            }
        }
        
        /// <summary>
        /// ��`�敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��`�敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : gejun</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_DraftDiv_ValueChanged(object sender, EventArgs e)
        {
            // �������̏ꍇ
            if (_initFlg)
                return;

            bool saveFlg = false;
            bool compareFlg = false;

            // ���͒��̃f�[�^�`�F�b�N
            if (this.CompareDraftDataWithCompareFlg(ref saveFlg, ref compareFlg))
            {
                if (!compareFlg)
                {
                    this._draftMode = DRAFT_DIV_RCV;
                    this.tNedit_CustCd.MaxLength = 8;
                    this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));

                    // ��ʏ�����
                    this.InitDisp();
                }
                else
                {
                    if (this.tComboEditor_DraftDiv.Value.ToString() == "0")
                    {
                        this._draftMode = DRAFT_DIV_RCV;
                        this.tNedit_CustCd.MaxLength = 8;
                        this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
                    }
                    else
                    {
                        this._draftMode = DRAFT_DIV_PAY;
                        this.tNedit_CustCd.MaxLength = 6;
                        this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));

                    }
                    // ��ʏ�����
                    this.SetDataDisp(true);
                    // �������ۑ�
                    this.SaveNewDraftMemory();
                }
            }
            else
            {
                this._initFlg = true;
                // �ύX������������
                if (this.tComboEditor_DraftDiv.Value.ToString() == "0")
                    this.tComboEditor_DraftDiv.Value = "1";
                else
                    this.tComboEditor_DraftDiv.Value = "0";
                this._initFlg = false;

            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
            /*
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            if (e.Key == Keys.Down)
            {
                if (e.PrevCtrl == this.tNedit_Amounts)
                {
                    // ���z�������(���_����)
                    e.NextCtrl = this.tNedit_CustSecCd;
                }
                else if (e.PrevCtrl == this.tNedit_DraftNo)
                {
                    e.NextCtrl = this.tNedit_BankCd;
                }
                else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
                {
                    if (this.tNedit_Section.Enabled)
                    {
                        e.NextCtrl = this.tNedit_Section;
                    }
                    else
                    {
                        e.NextCtrl = this.tComboEditor_DraftKind;
                    }
                }
                else if (e.PrevCtrl == this.tComboEditor_SelfOtherTransDiv)
                {
                    if (this.tDateEdit_ValidityData.Enabled)
                    {
                        e.NextCtrl = this.tDateEdit_ValidityData;
                    }
                    else 
                    {
                        e.NextCtrl = this.tEdit_Outline1;
                    }
                }
                else if (e.PrevCtrl == this.BankBranchGuide_Button)
                {
                    e.NextCtrl = this.tDateEdit_DrawingDate;
                }
                else if (e.PrevCtrl == this.SectionGuide_Button)
                {
                    e.NextCtrl = this.tComboEditor_DraftKind;
                }
                else if (e.PrevCtrl == this.DraftGuide_Button)
                {
                    e.NextCtrl = this.tNedit_BankCd;
                }
            }
            else if (e.Key == Keys.Up)
            {
                if (e.PrevCtrl == this.tEdit_Outline1 && this.tNedit_CustSecCd.Enabled)
                {
                    // �E�v�P�����_�R�[�h
                    e.NextCtrl = this.tNedit_CustSecCd;
                }
                else if (e.PrevCtrl == this.tEdit_Outline1 && this.tNedit_CustSecCd.Enabled == false)
                {
                    //�E�v�P�������U�敪
                    e.NextCtrl = this.tComboEditor_SelfOtherTransDiv;
                }
                else if (e.PrevCtrl == this.CustomerGuide_Button)
                {
                    if (this.tNedit_Amounts.Enabled)
                    {
                        e.NextCtrl = this.tNedit_Amounts;
                    }
                    else
                    {
                        e.NextCtrl = this.tComboEditor_SelfOtherTransDiv;
                    }
                }
                else if (e.PrevCtrl == this.SectionGuide_Button)
                {
                    if (this.tDateEdit_DrawingDate.Enabled)
                        e.NextCtrl = this.tDateEdit_DrawingDate;
                }
                else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
                {
                    e.NextCtrl = this.tNedit_BankCd;
                }
                else if (e.PrevCtrl == this.BankBranchGuide_Button)
                {
                    e.NextCtrl = this.tNedit_DraftNo;
                }
            }
            else if (e.Key == Keys.Right)
            {
                if (e.PrevCtrl == this.tComboEditor_DraftDiv)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tNedit_DraftNo)
                {
                    if (this.DraftGuide_Button.Visible == false)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.SectionGuide_Button)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tComboEditor_DraftKind)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tComboEditor_SelfOtherTransDiv)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tDateEdit_ValidityData)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tNedit_Amounts)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tEdit_Outline1)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tEdit_Outline2)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.DraftGuide_Button)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            // ��`�ԍ�
            if (e.PrevCtrl == this.tNedit_DraftNo && this.tNedit_DraftNo.Text != "")
            {
                string draftNo = this.tNedit_DraftNo.Value.ToString();
                bool serchflg = false;
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    bool temp = false;
                    if (this._secondsearchflg && this.tNedit_BankCd.Text!="" && this.tNedit_BranchCd.Text!="" && this.tDateEdit_DrawingDate.GetDateTime()!=DateTime.MinValue)
                    {
                        temp = true;
                    }
                    else if (draftNo != this._rcvDraftData.RcvDraftNo)
                    {
                        temp = true;
                    }
                    if (temp)
                    {
                        // ��������
                        serchflg = this.SearchProc();
                        if (this._chkflg && this._clickflg)
                        {
                            this.tNedit_DraftNo.Text = "";
                            this._clickflg = false;
                            this._chkflg = false;
                            this._secondsearchflg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else 
                        {
                            this._secondsearchflg = false;
                        }
                        if (this._chkflg && this._payflag)
                        {
                            this._payflag = false;
                            this._chkflg = false;
                            this.tNedit_DraftNo.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        if (!serchflg)
                        {
                            this.ScreenToDraftData();
                            return;
                        }
                    }
                }
                else
                {
                    bool temp = false;
                    if (this._secondsearchflg && this.tNedit_BankCd.Text!="" && this.tNedit_BranchCd.Text!="" && this.tDateEdit_DrawingDate.GetDateTime()!=DateTime.MinValue)
                    {
                        temp = true;
                    }
                    else if (draftNo != this._payDraftData.PayDraftNo)
                    {
                        temp = true;
                    }
                    if (temp) 
                    {
                        this._rcvDraftFlg = false;
                        RcvDraft_Label.Visible = false;
                        // ��������
                        serchflg = this.SearchProc();
                        if (this._chkflg && this._clickflg)
                        {
                            this.tNedit_DraftNo.Text = "";
                            this._clickflg = false;
                            this._chkflg = false;
                            this._secondsearchflg = true;
                        }
                        else 
                        {
                            this._secondsearchflg = false;
                        }
                        if (this._chkflg && this._payflag)
                        {
                            this._payflag = false;
                            this._chkflg = false;
                            this.tNedit_DraftNo.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        if (!serchflg)
                        {
                            this.ScreenToDraftData();
                            return;
                        }
                    } 
                }
            }
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
            */
            // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
            ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> // DEL 2013/02/15 T.Miyamoto �ȍ~����
            // ��`�ԍ�
            if (e.PrevCtrl == this.tNedit_DraftNo && this.tNedit_DraftNo.Text != "")
            {
                string draftNo = this.tNedit_DraftNo.Value.ToString();
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    if (draftNo != this._rcvDraftData.RcvDraftNo && draftNo != this._draftNo)
                        // ��������
                        if (!this.SearchProc())
                        {
                            //e.NextCtrl = e.PrevCtrl;// DEL zhuhh 2013/01/10 for Redmine #34123                            
                            return;
                        }
                }
                else
                {
                    if (draftNo != this._payDraftData.PayDraftNo && draftNo != this._draftNo)
                    // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                    {
                        this._rcvDraftFlg = false;
                        RcvDraft_Label.Visible = false;
                    // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                        // ��������
                        if (!this.SearchProc())
                        {
                            e.NextCtrl = e.PrevCtrl;
                            return;
                        }
                        // ADD 2013/02/22�B T.Miyamoto ------------------------------>>>>>
                        // ���͂���̋N�����ɍē��͕s�v�̏ꍇ�͎�`��ʂɃt�H�[�J�X�ړ�
                        if (this._startType == START_TYPE_CALL)
                        {
                            e.NextCtrl = tComboEditor_DraftKind;
                        }
                        // ADD 2013/02/22�B T.Miyamoto ------------------------------<<<<<
                    } // 2012/10/18 ADD
                 }
            }
            //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */ // DEL 2013/02/15 T.Miyamoto �ȏ㕜��

            // ���_
            else if (e.PrevCtrl == this.tNedit_Section && this.tNedit_Section.GetInt() != 0)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this.tNedit_Section.Value.ToString().PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                if (secInfoSet != null)
                {
                    this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���_�����݂��܂���B", 0, MessageBoxButtons.OK);
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tNedit_Section.Value = this._rcvDraftData.SectionCode;
                    else
                        this.tNedit_Section.Value = this._payDraftData.SectionCode;
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }
            // �U�o��
            else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
            {
                int longdate = this.tDateEdit_DrawingDate.GetLongDate();
                int year = this.tDateEdit_DrawingDate.GetDateYear();
                int month = this.tDateEdit_DrawingDate.GetDateMonth();
                int day = this.tDateEdit_DrawingDate.GetDateDay();
                // �����͎��̓N���A
                // �N�������͎��̓N���A
                // �N�������͎��̓N���A
                // 12���ȍ~�̕s�������͎��̓N���A�i���̖����͕s�j
                // ���t�̗L����Check
                if (((longdate == 0) ||
                    (this.tDateEdit_DrawingDate.GetLongDate().ToString().Length != 8) ||
                    (year == 0) ||
                    (month == 0) ||
                    (month > 12)) ||
                    ((day != 0) &&
                    (day > TDateTime.GetLastDate(year, month))))
                {
                    this.tDateEdit_DrawingDate.Clear();
                }
                ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> // DEL 2013/02/15 T.Miyamoto �ȍ~����
                if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue || this.tDateEdit_ValidityData.GetDateTime() == DateTime.MinValue)
                    return;
                // �U�o���������ƂȂ���t������
                if (this.tDateEdit_DrawingDate.GetDateTime() > this.tDateEdit_ValidityData.GetDateTime())
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "�����ȉ��̓��t����͂��ĉ������B", 0, MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                    else
                        this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                    return;
                }

                if (this.tDateEdit_DrawingDate.GetDateTime() != DateTime.MinValue && this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                {
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.SetValue(timeSpan.Days);
                }
                //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */ // DEL 2013/02/15 T.Miyamoto �ȏ㕜��
                // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                /*
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                if (this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                {
                    // �U�o���������ƂȂ���t������
                    if (this.tDateEdit_DrawingDate.GetDateTime() > this.tDateEdit_ValidityData.GetDateTime())
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "�����ȉ��̓��t����͂��ĉ������B", 0, MessageBoxButtons.OK);
                        e.NextCtrl = e.PrevCtrl;
                        if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                            this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                        else
                            this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                        return;
                    }

                    if (this.tDateEdit_DrawingDate.GetDateTime() != DateTime.MinValue && this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                    {
                        TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                        this.tNedit_Site.SetValue(timeSpan.Days);
                    }  
                }
                DateTime dateTimeTemp = this.tDateEdit_DrawingDate.GetDateTime();
                bool temp = false;
                string draftNo = this.tNedit_DraftNo.Text.Trim();            
                if ((!String.IsNullOrEmpty(draftNo))&&(this.tNedit_BankCd.GetInt()!=0) && (this.tNedit_BranchCd.GetInt() != 0) &&dateTimeTemp != DateTime.MinValue)
                {
                    if(this._draftMode == DRAFT_DIV_RCV)
                    {
                       if(dateTimeTemp != this._rcvDraftData.DraftDrawingDate )
                           temp=true;
                    }
                    else
                    {
                       if(dateTimeTemp != this._payDraftData.DraftDrawingDate)
                           temp=true;
                    }
                    if (this._secondsearchflg)
                    {
                        temp = true;
                    }
                   
                    if ((!String.IsNullOrEmpty(draftNo))&&(this.tNedit_BankCd.GetInt()!=0) && (this.tNedit_BranchCd.GetInt() != 0)&&temp)
                    {
                        // ��������
                        bool searchflg = false;
                        searchflg = this.SearchProc();
                        if (this._chkflg && this._clickflg)
                        {
                            this.tDateEdit_DrawingDate.SetDateTime(DateTime.MinValue);
                            this._clickflg = false;
                            this._chkflg = false;
                            this._secondsearchflg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else 
                        {
                            this._secondsearchflg = false;
                        }
                        if (this._chkflg && this._payflag)
                        {
                            this._payflag = false;
                            this._chkflg = false;
                            this.tDateEdit_DrawingDate.SetDateTime(DateTime.MinValue);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        if (!searchflg)
                        {
                            this.ScreenToDraftData();
                            return;
                        } 
                    }
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                */
                // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
            }
            // ����
            else if (e.PrevCtrl == this.tDateEdit_ValidityData)
            {

                int longdate = this.tDateEdit_ValidityData.GetLongDate();
                int year = this.tDateEdit_ValidityData.GetDateYear();
                int month = this.tDateEdit_ValidityData.GetDateMonth();
                int day = this.tDateEdit_ValidityData.GetDateDay();
                // �����͎��̓N���A
                // �N�������͎��̓N���A
                // �N�������͎��̓N���A
                // 12���ȍ~�̕s�������͎��̓N���A�i���̖����͕s�j
                // ���t�̗L����Check
                if (((longdate == 0) ||
                    (this.tDateEdit_ValidityData.GetLongDate().ToString().Length != 8) ||
                    (year == 0) ||
                    (month == 0) ||
                    (month > 12)) ||
                    ((day != 0) &&
                    (day > TDateTime.GetLastDate(year, month))))
                {
                    this.tDateEdit_ValidityData.Clear();
                }

                if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue || this.tDateEdit_ValidityData.GetDateTime() == DateTime.MinValue)
                    return;
                // �U�o���������ƂȂ���t������
                if (this.tDateEdit_DrawingDate.GetDateTime() > this.tDateEdit_ValidityData.GetDateTime())
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "�U�o���ȏ�̓��t����͂��ĉ������B", 0, MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._rcvDraftData.ValidityTerm));
                    else
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._payDraftData.ValidityTerm));
                    return;
                }

                if (this.tDateEdit_DrawingDate.GetDateTime() != DateTime.MinValue && this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                {
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.SetValue(timeSpan.Days);
                }
            }
            // ������_
            else if (e.PrevCtrl == this.tNedit_CustSecCd && this.tNedit_CustSecCd.GetInt() != 0)
            {

                SecInfoSet secInfoSet = new SecInfoSet();

                this._secInfoAcs.GetSecInfo(this.tNedit_CustSecCd.GetValue().ToString().PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                if (secInfoSet == null)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���_�����݂��܂���B", 0, MessageBoxButtons.OK);
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tNedit_CustSecCd.Value = this._rcvDraftData.AddUpSecCode;
                    else
                        this.tNedit_CustSecCd.Value = this._payDraftData.AddUpSecCode;
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }
            //  �����R�[�h
            else if (e.PrevCtrl == this.tNedit_CustCd && this.tNedit_CustCd.GetInt() != 0)
            {
                // �x����`
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    Supplier supplier = new Supplier();
                    status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_CustCd.GetInt());
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        this.CustName_Label.Text = supplier.SupplierSnm;
                        this.tNedit_CustSecCd.Value = supplier.PaymentSectionCode;
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�d���悪���݂��܂���B", 0, MessageBoxButtons.OK);
                        this.tNedit_CustCd.SetInt(this._payDraftData.SupplierCd);
                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }
                }
                else
                {
                    CustomerInfo customerInfo;
                    status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this.tNedit_CustCd.GetInt(), true, out customerInfo);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        this.CustName_Label.Text = customerInfo.CustomerSnm;
                        this.tNedit_CustSecCd.Value = customerInfo.MngSectionCode;
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���Ӑ悪���݂��܂���B", 0, MessageBoxButtons.OK);
                        this.tNedit_CustCd.SetInt(this._rcvDraftData.CustomerCode);
                        e.NextCtrl = e.PrevCtrl;
                        return;

                    }
                }

            }
            // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
            //  �����R�[�h
            else if (e.PrevCtrl == this.tNedit_CustCd && this.tNedit_CustCd.GetInt() == 0)
            {
                //���ނ��N���A���Ă����̂��N���A����
                this.CustName_Label.Text = string.Empty;
            }
            // --- ADD 2010.06.28 redmine#10551 ���` ----------<<<<<
            // ��s/�x�X�R�[�h
            //else if (e.PrevCtrl == this.tNedit_BranchCd || e.PrevCtrl == this.tNedit_BankCd ) // DEL 2010.06.28 redmine#10551 ���`
            else if (e.PrevCtrl == this.tNedit_BranchCd)// ADD 2010.06.28 redmine#10551 ���`
            {
                // --- DEL 2010.06.28 redmine#10551 ���` ---------->>>>>
                //// ��s�R�[�h �t�H�[�J�X�A�E�g����ƁA0000�ŕ⑫
                //if (e.PrevCtrl == this.tNedit_BankCd && this.tNedit_BankCd.DataText == "")
                //    this.tNedit_BankCd.SetInt(0);

                //// �x�X�R�[�h �t�H�[�J�X�A�E�g����ƁA000�ŕ⑫
                //if (e.PrevCtrl == this.tNedit_BranchCd && this.tNedit_BranchCd.DataText == "")
                //    this.tNedit_BranchCd.SetInt(0);
                // --- DEL 2010.06.28 redmine#10551 ���` ----------<<<<<

                if (this.tNedit_BankCd.DataText != "" && this.tNedit_BranchCd.DataText != "")
                {
                    int bankBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                    bool checkFlg = false;
                    bool haveFlg = false;
                    ArrayList userDgBdList = null;
                    //this._userGuideAcs.SearchAllDivCodeBody(out userDgBdList, this._enterpriseCode, 46, UserGuideAcsData.OfferDivCodeMergeBodyData); // DEL 2010.06.28 redmine#10551 ���`
                    this._userGuideAcs.SearchDivCodeBody(out userDgBdList, this._enterpriseCode, 46, UserGuideAcsData.OfferDivCodeMergeBodyData);// ADD 2010.06.28 redmine#10551 ���`
                    foreach (UserGdBd userGdBd in userDgBdList)
                    {
                        if (userGdBd.GuideCode == bankBranchCd)
                        {
                            this.BankName_Label.Text = userGdBd.GuideName;
                            checkFlg = true;
                            // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
                            _bankCdBefore = this.tNedit_BankCd.Text;
                            _branchCdBefore = this.tNedit_BranchCd.Text;
                            // --- ADD 2010.06.28 redmine#10551 ���` ----------<<<<<
                        }
                    }
                    if (!checkFlg)
                    {
                        int bankCd;
                        int branchCd;
                        if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        {
                            // ��s�R�[�h
                            bankCd = this._rcvDraftData.BankAndBranchCd / 1000;
                            // �x�X�R�[�h
                            branchCd = this._rcvDraftData.BankAndBranchCd % 1000;
                        }
                        else
                        {
                            // ��s�R�[�h
                            bankCd = this._payDraftData.BankAndBranchCd / 1000;
                            // �x�X�R�[�h
                            branchCd = this._payDraftData.BankAndBranchCd % 1000;
                        }

                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "��s�����݂��܂���B", 0, MessageBoxButtons.OK);
                        // --- DEL 2010.06.28 redmine#10551 ���` ---------->>>>>
                        //if (e.PrevCtrl == this.tNedit_BankCd)
                        //{
                        // --- DEL 2010.06.28 redmine#10551 ���` ----------<<<<<
                        foreach (UserGdBd userGdBd in userDgBdList)
                        {
                            if (userGdBd.GuideCode == (bankCd * 1000 + branchCd))
                            {
                                this.tNedit_BankCd.SetInt(bankCd);
                                haveFlg = true;
                                break;
                            }
                        }
                        // ��s�E�x�X�����݂��Ă��Ȃ�
                        if (!haveFlg)
                            //this.tNedit_BankCd.Text = ""; // DEL 2010.06.28 redmine#10551 ���`
                            this.tNedit_BankCd.Text = _bankCdBefore; // ADD 2010.06.28 redmine#10551 ���`
                        //}// DEL 2010.06.28 redmine#10551 ���`

                        if (e.PrevCtrl == this.tNedit_BranchCd)
                        {
                            foreach (UserGdBd userGdBd in userDgBdList)
                            {
                                if (userGdBd.GuideCode == (bankCd * 1000 + branchCd))
                                {
                                    this.tNedit_BranchCd.SetInt(branchCd);
                                    haveFlg = true;
                                    break;
                                }
                            }
                            // ��s�E�x�X�����݂��Ă��Ȃ�
                            if (!haveFlg)
                                //this.tNedit_BranchCd.Text = ""; // DEL 2010.06.28 redmine#10551 ���`
                                this.tNedit_BranchCd.Text = _branchCdBefore; // ADD 2010.06.28 redmine#10551 ���`
                        }
                        //e.NextCtrl = e.PrevCtrl;// DEL 2010.06.28 redmine#10551 ���`
                        //this.tNedit_BankCd.Focus(); // ADD 2010.06.28 redmine#10551 ���` // DEL zhuhh 2013/01/10 for Redmine #34123
                        this.tNedit_BranchCd.Focus(); // ADD zhuhh 2013/01/10 for Redmine #34123
                        return;
                    }
                    // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>
                    /*
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    else 
                    {
                        // ��s�E�x�X�����݂���ꍇ
                        int bankAndBranchCd = Convert.ToInt32(this.tNedit_BankCd.Value.ToString()+this.tNedit_BranchCd.Value.ToString());
                        if(!String.IsNullOrEmpty(this.tNedit_DraftNo.Text))
                        {
                            if(this._draftMode == DRAFT_DIV_RCV?(bankAndBranchCd!=this._rcvDraftData.BankAndBranchCd):(bankAndBranchCd!=this._payDraftData.BankAndBranchCd))
                            {
                                bool searchflg = false;
                                searchflg = this.SearchProc();
                                if (this._chkflg && this._clickflg)
                                {
                                    this.tNedit_BankCd.Text = "";
                                    this.tNedit_BranchCd.Text = "";
                                    this.BankName_Label.Text = "";
                                    this._clickflg = false;
                                    this._chkflg = false;
                                    this._secondsearchflg = true;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else 
                                {
                                    this._secondsearchflg = false;
                                }
                                if (this._chkflg && this._payflag)
                                {
                                    this._payflag = false;
                                    this._chkflg = false;
                                    this.tNedit_BankCd.Text = "";
                                    this.tNedit_BranchCd.Text = "";
                                    this.BankName_Label.Text = "";
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                if (!searchflg)
                                {
                                    this.ScreenToDraftData();
                                    return;
                                }
                            }
                            else if(this._draftMode == DRAFT_DIV_RCV?(bankAndBranchCd==this._rcvDraftData.BankAndBranchCd):(bankAndBranchCd==this._payDraftData.BankAndBranchCd))
                            {
                                if(this._secondsearchflg)
                                {
                                    bool searchflg = false;
                                    searchflg = this.SearchProc();
                                    if (this._chkflg && this._clickflg)
                                    {
                                        this.tNedit_BankCd.Text = "";
                                        this.tNedit_BranchCd.Text = "";
                                        this.BankName_Label.Text = "";
                                        this._clickflg = false;
                                        this._chkflg = false;
                                        this._secondsearchflg = true;
                                    }
                                    else 
                                    {
                                        this._secondsearchflg = false;
                                    }
                                    if (this._chkflg && this._payflag)
                                    {
                                        this._payflag = false;
                                        this._chkflg = false;
                                        this.tNedit_BankCd.Text = "";
                                        this.tNedit_BranchCd.Text = "";
                                        this.BankName_Label.Text = "";
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    if (!searchflg)
                                    {
                                        this.ScreenToDraftData();
                                        return;
                                    }    
                                }else{return;}
                            }
                        }
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    */
                    // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                }
                // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
                else if (string.IsNullOrEmpty(this.tNedit_BankCd.DataText)
                    && string.IsNullOrEmpty(this.tNedit_BranchCd.DataText))
                {
                    //���ނ��N���A���Ă����̂��N���A����
                    this.BankName_Label.Text = string.Empty;
                }
                // --- ADD 2010.06.28 redmine#10551 ���` ----------<<<<<
            }
            ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> // UPD 2013/02/15 T.Miyamoto �ȍ~����
            // --- ADD 2010.06.28 redmine#10551 ���` ---------->>>>>
            if (e.Key == Keys.Down)
            {
                if (e.PrevCtrl == this.tNedit_Amounts)
                {
                    // ���z�������(���_����)
                    e.NextCtrl = this.tNedit_CustSecCd;
                }                
            }
            else if (e.Key == Keys.Up)
            {
                if (e.PrevCtrl == this.tEdit_Outline1)
                {
                    // �E�v�P����s�R�[�h
                    e.NextCtrl = this.tNedit_BankCd;
                    //e.NextCtrl = this.tNedit_CustSecCd;// ADD zhuhh 2013/01/10 for Redmine #34123 // DEL 2013/02/15 T.Miyamoto
                }              
            } 
            //  ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */ // UPD 2013/02/15 T.Miyamoto �ȏ㕜��
            // �������ۑ�
            this.ScreenToDraftData();
        }

        /// <summary>
        /// Button_Click �C�x���g(Guide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote  : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private void Guide_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ���_�K�C�h�{�^��
            if (sender == this.SectionGuide_Button)
            {
                // �I�t���C����ԃ`�F�b�N	
                if (!CheckOnline())
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Text,
                        "���_�K�C�h" + "��ʏ����������Ɏ��s���܂����B",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return;
                }
                SecInfoSet secInfoSet;
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {

                    this.tNedit_Section.Value = secInfoSet.SectionCode;
                    this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                    // �t�H�[�J�X�ړ�
                    this.tComboEditor_DraftKind.Focus();
                }
            }
            // ���Ӑ�A�d����̋��_�K�C�h�{�^��
            else if (sender == this.CustSecCdGuide_Button)
            {
                // �I�t���C����ԃ`�F�b�N	
                if (!CheckOnline())
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Text,
                        "���_�K�C�h" + "��ʏ����������Ɏ��s���܂����B",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return;
                }
                SecInfoSet secInfoSet;
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {

                    this.tNedit_CustSecCd.Value = secInfoSet.SectionCode;
                    // �t�H�[�J�X�ړ�
                    this.tNedit_CustCd.Focus();
                }
            }
            // ���Ӑ�A�d����K�C�h�{�^��
            else if (sender == this.CustomerGuide_Button)
            {
                // �x����`
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    // �d����K�C�h�N��
                    // �K�C�h�N��
                    Supplier supplier = new Supplier();
                    status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // ���_�R�[�h
                        this.tNedit_CustSecCd.Value = supplier.MngSectionCode;
                        // �d����R�[�h
                        this.tNedit_CustCd.SetValue(supplier.SupplierCd);
                        // �d���於��
                        this.CustName_Label.Text = supplier.SupplierSnm;
                        // �t�H�[�J�X�ړ�
                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>
                        ////this.tNedit_BankCd.Focus();// DEL zhuhh 2013/01/10 for Redmine #34123
                        //this.tEdit_Outline1.Focus();// ADD zhuhh 2013/01/24 for Redmine #34123
                        this.tNedit_BankCd.Focus();
                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<

                    }
                }
                // ����`
                else
                {
                    _customerGuideOK = false;

                    // ���Ӑ�K�C�h�N��
                    PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                    customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
                    customerSearchForm.ShowDialog(this);
                    if (_customerGuideOK)
                    {
                        // �t�H�[�J�X�ړ�
                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>
                        ////this.tNedit_BankCd.Focus();// DEL zhuhh 2013/01/10 for Redmine #34123
                        //this.tEdit_Outline1.Focus();// ADD zhuhh 2013/01/24 for Redmine #34123
                        this.tNedit_BankCd.Focus();
                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                    }
                }
            }
            //��s�x�X�K�C�h�{�^��
            else if (sender == this.BankBranchGuide_Button)
            {
                UserGdHd userGdHd;
                UserGdBd userGdBd;
                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 46);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ��s�R�[�h
                    this.tNedit_BankCd.SetInt(userGdBd.GuideCode / 1000);
                    // �x�X�R�[�h
                    this.tNedit_BranchCd.SetInt(userGdBd.GuideCode % 1000);
                    this.BankName_Label.Text = userGdBd.GuideName;
                    this._bankCdBefore = this.tNedit_BankCd.Text; // ADD 2010.06.28 redmine#10551 ���`
                    this._branchCdBefore = this.tNedit_BranchCd.Text; // ADD 2010.06.28 redmine#10551 ���`
                    // �t�H�[�J�X�ړ�
                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                    ////this.tEdit_Outline1.Focus();// DEL zhuhh 2013/01/10 for Redmine #34123
                    //this.tDateEdit_DrawingDate.Focus();// ADD zhuhh 2013/01/10 for Redmine #34123
                    this.tEdit_Outline1.Focus();
                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                }
                // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                /*
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                int bankAndBranchCdAfterGuid = 0;
                if (String.IsNullOrEmpty(this.tNedit_BankCd.Text))
                {
                    if (!String.IsNullOrEmpty(this.tNedit_BranchCd.Text))
                    {
                        bankAndBranchCdAfterGuid = Convert.ToInt32(this.tNedit_BranchCd.Value.ToString());
                    }
                }
                else 
                {
                    if (!String.IsNullOrEmpty(this.tNedit_BranchCd.Text))
                    {
                        bankAndBranchCdAfterGuid = Convert.ToInt32(this.tNedit_BankCd.Value.ToString()) * 1000 + Convert.ToInt32(this.tNedit_BranchCd.Value.ToString());
                    }
                    else 
                    {
                        bankAndBranchCdAfterGuid = Convert.ToInt32(this.tNedit_BankCd.Value.ToString()) * 1000;
                    }
                    
                }
                 
                if ((!String.IsNullOrEmpty(this.tNedit_DraftNo.Text)) && (this._draftMode == DRAFT_DIV_RCV ? (bankAndBranchCdAfterGuid != this._rcvDraftData.BankAndBranchCd) : (bankAndBranchCdAfterGuid != this._payDraftData.BankAndBranchCd)))
                {                   
                    this.SearchProc();
                    if (this._chkflg && this._clickflg)
                    {
                        this.tNedit_BankCd.Text = "";
                        this.tNedit_BranchCd.Text = "";
                        this.BankName_Label.Text = "";
                        this._clickflg = false;
                        this._chkflg = false;
                        this._secondsearchflg = true;
                    }
                    else 
                    {
                        this._secondsearchflg = true;
                    }
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                */
                // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
            }
            // --- ADD 2012/10/18 -------------------------------------------------->>>>>
            //��`�K�C�h�{�^��
            else if (sender == this.DraftGuide_Button)
            {
                //��`�莝��������ʕ\��
                PMTEG09101UB salesSlipNumDlg = new PMTEG09101UB();
                DialogResult ret = salesSlipNumDlg.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    this._rcvDraftFlg = true; // ����`�f�[�^�̃K�C�h�ďo

                    this.tNedit_DraftNo.Value = salesSlipNumDlg._rcvDraftData.RcvDraftNo;
                    this._rcvDraftData = salesSlipNumDlg._rcvDraftData;

                    // ��������
                    // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                    /*
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    bool searchflg = false;
                    searchflg = this.SearchProc();
                    if(this._chkflg&&this._clickflg)
                    {
                        this.tNedit_DraftNo.Text="";
                        this._clickflg=false;
                        this._clickflg=false;
                        this.tNedit_DraftNo.Focus();
                    }
                    if(!searchflg)
                    {
                        this.tNedit_DraftNo.Focus();
                    }
                    else
                    {
                        // �t�H�[�J�X�ړ�
                        this.tComboEditor_DraftKind.Focus();
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    */
                    // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                    ///* ----- DEL zhuhh 2013/01/10 for Redmime #34123 ----->>>>> // UPD 2013/02/15 T.Miyamoto �ȍ~����
                    if (!this.SearchProc())
                    {
                        this.tNedit_DraftNo.Focus();
                    }
                    else
                    {
                        // �t�H�[�J�X�ړ�
                        this.tComboEditor_DraftKind.Focus();
                    }
                    //   ----- DEL zhuhh 2013/01/10 for Redmime #34123 -----<<<<< */ // UPD 2013/02/15 T.Miyamoto �ȏ㕜��
                }
            }
            // --- ADD 2012/10/18 --------------------------------------------------<<<<<
            // �������ۑ�
            this.ScreenToDraftData();
        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // �K�C�h�N��
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;
            // ���ڂɓW�J
            // ���_�R�[�h
            this.tNedit_CustSecCd.Value = customerInfo.MngSectionCode;
            // ���Ӑ��R�[�h
            this.tNedit_CustCd.SetInt( customerInfo.CustomerCode);
            // ���Ӑ於��
            this.CustName_Label.Text = customerInfo.CustomerSnm;

            _customerGuideOK = true;
        }
        #endregion

        #region �V�K�������ۑ�����
        /// <summary>
        /// �������N���A����
        /// </summary>
        /// <remarks> 
        /// <br>Note       : �������������������ŉ񕜂���</br> 
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void SaveNewDraftMemory()
        {
            // ��ʐݒ肩��A�������ɕۑ�����
            if (this._draftMode == DRAFT_DIV_RCV)
            {
                this._rcvDraftData = this._rcvDraftDataClear.Clone();
                this.ScreenToDraftData();
                this._rcvDraftDataOrg = this._rcvDraftData.Clone();
            }
            else
            {
                this._payDraftData = this._payDraftDataClear.Clone();
                this.ScreenToDraftData();
                this._payDraftDataOrg = this._payDraftData.Clone();
            }
        }
        #endregion

        #region ��ʏ�����
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks> 
        /// <br>Note       : ��ʂ�����������</br> 
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private void InitDisp()
        {
            // �������t���O
            this._initFlg = true;
            // �V�K���[�h�ύX
            this._modeType = MODE_TYPE_INSERT;
            // �R���g���[��Enabled����
            this.SetControlEnabled(INSERT_MODE);
            // ��ʃN���A
            this.SetDataDisp(false);
            // �������t���O
            this._initFlg = false;
            // �������ۑ�
            this.SaveNewDraftMemory();
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            //��`�ۑ��O�̃`�F�b�N�t���O
            this._chkflg = false;
            //�I���u�������v�t���O
            this._clickflg = false;
            // �S���������t���O
            this._secondsearchflg = false;
            this._payflag = false;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
        }
        #endregion

        #region �I�t���C����ԃ`�F�b�N����
        /// <summary>				
        /// ���O�I�����I�����C����ԃ`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
        public static bool CheckOnline()
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
        /// �����[�g�ڑ��\����				
        /// </summary>				
        /// <returns>���茋��</returns>				
        private static bool CheckRemoteOn()
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

        #region ���l����DataTime�ɕύX����
        /// <summary>
        /// ���l����DataTime�ɕύX����
        /// </summary>
        /// <param name="dateInt">�������l</param>
        /// <remarks> 
        /// <br>Note       : ���l����DataTime�ɕύX����</br> 
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private DateTime ChangeDateTime(int dateInt)
        {
            string dataStr = dateInt.ToString();
            if (dataStr.Length != 8)
            {
                return DateTime.MinValue;
            }
            else
            {
                return new DateTime(System.Convert.ToInt32(dataStr.Substring(0, 4)), 
                    System.Convert.ToInt32(dataStr.Substring(4, 2)), System.Convert.ToInt32(dataStr.Substring(6, 2)));
            }
        }
        #endregion

        # region DB����
        # region ��������
        /// <summary>
        ///�@��������(SearchProc())
        /// </summary>
        /// <returns>�`�F�b�N�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �����������s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// <br>UpdateNote : 2013/04/02 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/05/15�z�M��</br>
        /// <br>           : redmine #35247 �d�������I�v�V�����̒���</br>
        /// </remarks>
        private bool SearchProc()
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʌ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���ڋN��
            if (this._startType == START_TYPE_DIRECT)
            {
                // ����`
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    List<RcvDraftData> retList = new List<RcvDraftData>();
                    RcvDraftData paraRcvDraftData = new RcvDraftData();
                    paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                    paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>                    
                    if (!String.IsNullOrEmpty(paraRcvDraftData.RcvDraftNo))
                    {
                        paraRcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraRcvDraftData.BankAndBranchCd==0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithoutBabCd(out retList, 0, paraRcvDraftData);
                            this._chkflg = false;
                        }
                        else if (paraRcvDraftData.BankAndBranchCd == 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraRcvDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.SearchWithBabCd(out retList, 0, paraRcvDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (retList.Count == 1)
                        {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        RcvDraftData rcvDraftDataGet = (RcvDraftData)retList[0];
                        // �_���폜�敪 = 0:�L��
                        if (rcvDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //        //"���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B" + "\r\n" + "�ҏW���s���܂����H",// DEL zhuhh 2013/01/10 for Redmine #34123
                            //        "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + rcvDraftDataGet.RcvDraftNo + "�@��s�E�x�X�R�[�h�F" + (rcvDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (rcvDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + rcvDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z\r\n" + "�ҏW���s���܂����H",// ADD zhuhh 2013/01/10 for Redmine #34123
                            //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B","�ҏW���s���܂����H"
                                                               , rcvDraftDataGet.RcvDraftNo
                                                               , rcvDraftDataGet.BankAndBranchCd / 1000
                                                               , rcvDraftDataGet.BankAndBranchCd % 1000
                                                               , rcvDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // �ҏW���[�h
                                this._modeType = MODE_TYPE_UPDATE;
                                // �R���g���[��Enabled����
                                this.SetControlEnabled(UPDATE_MODE);
                                // �������Đݒ�
                                this._rcvDraftData = rcvDraftDataGet.Clone();
                                this._rcvDraftDataOrg = rcvDraftDataGet.Clone();
                                this._initFlg = true;
                                // ��ʍĕ\��
                                this.SetDataDisp(false);
                                this._initFlg = false;
                                this.tNedit_Section.Focus();// ADD zhuhh 2013/01/10 for Redmine #34123
                            }
                            else
                            {
                                // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this.tNedit_DraftNo.Clear();
                                //this.tNedit_DraftNo.Focus();
                                //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this._clickflg = true;
                                //this.tNedit_BankCd.Focus();
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                                this._clickflg = true;
                                // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        // �_���폜�敪 = 1:�_���폜
                        else if (rcvDraftDataGet.LogicalDeleteCode == DEL_CD_LOG_DEL)
                        {
                            /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", 0, MessageBoxButtons.OK);
                            // �폜���[�h�̏������������s��
                            this._modeType = MODE_TYPE_DELETE;
                            // �R���g���[��Enabled����
                            this.SetControlEnabled(DELETE_MODE);
                            // �������Đݒ�
                            this._rcvDraftData = rcvDraftDataGet.Clone();
                            this._rcvDraftDataOrg = rcvDraftDataGet.Clone();
                            this._initFlg = true;
                            // ��ʍĕ\��
                            this.SetDataDisp(false);
                            this._initFlg = false;
                               ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //    "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɍ폜����Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + rcvDraftDataGet.RcvDraftNo + "�@��s�E�x�X�R�[�h�F" + (rcvDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (rcvDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + rcvDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z\r\n" + "�ҏW���s���܂����H",
                            //0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɍ폜����Ă��܂��B", "�ҏW���s���܂����H"
                                                               , rcvDraftDataGet.RcvDraftNo
                                                               , rcvDraftDataGet.BankAndBranchCd / 1000
                                                               , rcvDraftDataGet.BankAndBranchCd % 1000
                                                               , rcvDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // �폜���[�h�̏������������s��
                                this._modeType = MODE_TYPE_DELETE;
                                // �R���g���[��Enabled����
                                this.SetControlEnabled(DELETE_MODE);
                                // �������Đݒ�
                                this._rcvDraftData = rcvDraftDataGet.Clone();
                                this._rcvDraftDataOrg = rcvDraftDataGet.Clone();
                                this._initFlg = true;
                                // ��ʍĕ\��
                                this.SetDataDisp(false);
                                this._initFlg = false;
                            }
                            else 
                            {
                                this._clickflg = true;
                            }
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        }
                        else
                        {
                            this.tNedit_DraftNo.Clear();
                            this.tNedit_DraftNo.Focus();
                            return false; // ADD 2013/02/15 T.Miyamoto
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        }
                        else if (retList.Count > 1)
                        {
                            if (this._selectForm == null)
                            {
                                this._selectForm = new PMTEG09101UC();
                            }
                            DialogResult dr = this._selectForm.SelectGoodsGuideShow(this,ref retList);
                            if (dr == DialogResult.OK)
                            {
                                // UPD 2013/02/22�@ T.Miyamoto ------------------------------>>>>>
                                //// �������Đݒ�
                                //this._rcvDraftData = this._selectForm.RcvDraftDataLst.Clone();
                                //this._rcvDraftDataOrg = this._selectForm.RcvDraftDataLst.Clone();
                                //if (this._rcvDraftData.LogicalDeleteCode == DEL_CD_USE)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //// �ҏW���[�h
                                //    //this._modeType = MODE_TYPE_UPDATE;
                                //    //// �R���g���[��Enabled����
                                //    //this.SetControlEnabled(UPDATE_MODE);
                                //    //this._initFlg = true;
                                //    //// ��ʍĕ\��
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false;
                                //    //this.tNedit_Section.Focus();
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B", "�ҏW���s���܂����H"
                                //                                       , this._rcvDraftData.RcvDraftNo
                                //                                       , this._rcvDraftData.BankAndBranchCd / 1000
                                //                                       , this._rcvDraftData.BankAndBranchCd % 1000
                                //                                       , this._rcvDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // �ҏW���[�h
                                //        this._modeType = MODE_TYPE_UPDATE;
                                //        // �R���g���[��Enabled����
                                //        this.SetControlEnabled(UPDATE_MODE);
                                //        this._initFlg = true;
                                //        // ��ʍĕ\��
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //        this.tNedit_Section.Focus();
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                //else if (this._rcvDraftData.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //// �폜���[�h�̏������������s��
                                //    //this._modeType = MODE_TYPE_DELETE;
                                //    //// �R���g���[��Enabled����
                                //    //this.SetControlEnabled(DELETE_MODE);
                                //    //this._initFlg = true;
                                //    //// ��ʍĕ\��
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false; 
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɍ폜����Ă��܂��B", "�ҏW���s���܂����H"
                                //                                       , this._rcvDraftData.RcvDraftNo
                                //                                       , this._rcvDraftData.BankAndBranchCd / 1000
                                //                                       , this._rcvDraftData.BankAndBranchCd % 1000
                                //                                       , this._rcvDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // �폜���[�h�̏������������s��
                                //        this._modeType = MODE_TYPE_DELETE;
                                //        // �R���g���[��Enabled����
                                //        this.SetControlEnabled(DELETE_MODE);
                                //        this._initFlg = true;
                                //        // ��ʍĕ\��
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                RcvDraftData rcvDraftDataChk = this._selectForm.RcvDraftDataLst.Clone(); // �`�F�b�N�p
                                if (rcvDraftDataChk.LogicalDeleteCode == DEL_CD_USE)
                                {
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B", "�ҏW���s���܂����H"
                                                                       , rcvDraftDataChk.RcvDraftNo
                                                                       , rcvDraftDataChk.BankAndBranchCd / 1000
                                                                       , rcvDraftDataChk.BankAndBranchCd % 1000
                                                                       , rcvDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // �ҏW���[�h
                                        this._modeType = MODE_TYPE_UPDATE;
                                        // �R���g���[��Enabled����
                                        this.SetControlEnabled(UPDATE_MODE);
                                        this._initFlg = true;
                                        // �������Đݒ�
                                        this._rcvDraftData = this._selectForm.RcvDraftDataLst.Clone();
                                        this._rcvDraftDataOrg = this._selectForm.RcvDraftDataLst.Clone();
                                        // ��ʍĕ\��
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                        this.tNedit_Section.Focus();
                                    }
                                }
                                else if (rcvDraftDataChk.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                {
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɍ폜����Ă��܂��B", "�ҏW���s���܂����H"
                                                                       , rcvDraftDataChk.RcvDraftNo
                                                                       , rcvDraftDataChk.BankAndBranchCd / 1000
                                                                       , rcvDraftDataChk.BankAndBranchCd % 1000
                                                                       , rcvDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // �폜���[�h�̏������������s��
                                        this._modeType = MODE_TYPE_DELETE;
                                        // �R���g���[��Enabled����
                                        this.SetControlEnabled(DELETE_MODE);
                                        this._initFlg = true;
                                        // �������Đݒ�
                                        this._rcvDraftData = this._selectForm.RcvDraftDataLst.Clone();
                                        this._rcvDraftDataOrg = this._selectForm.RcvDraftDataLst.Clone();
                                        // ��ʍĕ\��
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                    }
                                }
                                // UPD 2013/02/22�@ T.Miyamoto ------------------------------<<<<<
                                else 
                                {
                                    this.tNedit_DraftNo.Clear();
                                    this.tNedit_DraftNo.Focus();
                                }
                            }
                            else
                            {
                                // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //this.tNedit_BankCd.Focus();
                                // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        else 
                        {
                            if (this.tNedit_DraftNo.Focused) { this.tNedit_BranchCd.Focus(); }
                            if (this.tNedit_BranchCd.Focused) { this.tNedit_Section.Focus(); }
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }

                }
                // �x����`�f�[�^
                else
                {
                    List<PayDraftData> retList = new List<PayDraftData>();
                    PayDraftData paraPayDraftData = new PayDraftData();
                    paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                    paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>                    
                    if (!String.IsNullOrEmpty(paraPayDraftData.PayDraftNo))
                    {
                        paraPayDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate==DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithoutBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        else if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.SearchWithBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (retList.Count == 1)
                        {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        PayDraftData payDraftDataGet = (PayDraftData)retList[0];
                        // �_���폜�敪 = 0:�L��
                        if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //        //"���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B" + "\r\n" + "�ҏW���s���܂����H",// DEL zhuhh 2013/01/10 for Redmine #34123
                            //        "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + payDraftDataGet.PayDraftNo + "�@��s�E�x�X�R�[�h�F" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z\r\n" + "�ҏW���s���܂����H",// ADD zhuhh 2013/01/10 for Redmine #34123
                            //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            string sMsg = "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɓo�^����Ă��܂��B";
                            if (payDraftDataGet.PaymentSlipNo != 0)
                                sMsg = "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B";
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , sMsg, "�ҏW���s���܂����H"
                                                               , payDraftDataGet.PayDraftNo
                                                               , payDraftDataGet.BankAndBranchCd / 1000
                                                               , payDraftDataGet.BankAndBranchCd % 1000
                                                               , payDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // �X�V���[�h�̏������������s��
                                this._modeType = MODE_TYPE_UPDATE;
                                // �R���g���[��Enabled����
                                this.SetControlEnabled(UPDATE_MODE);
                                // �������Đݒ�
                                this._payDraftData = payDraftDataGet.Clone();
                                this._payDraftDataOrg = payDraftDataGet.Clone();
                                this._initFlg = true;
                                // ��ʍĕ\��
                                this.SetDataDisp(false);
                                this._initFlg = false;
                                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                this.tNedit_BankCd.Enabled = false;
                                this.tNedit_BranchCd.Enabled = false;
                                this.BankBranchGuide_Button.Enabled = false;
                                this.tNedit_Section.Focus();
                                this.tDateEdit_DrawingDate.Enabled = false;
                                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                            }
                            else
                            {
                                // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this.tNedit_DraftNo.Clear();
                                //this.tNedit_DraftNo.Focus();
                                //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this._clickflg = true;
                                //this.tNedit_BankCd.Focus();
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                                this._clickflg = true;
                                // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        // �_���폜�敪 = 1:�_���폜
                        else if (payDraftDataGet.LogicalDeleteCode == DEL_CD_LOG_DEL)
                        {
                            /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", 0, MessageBoxButtons.OK);
                            // �폜���[�h�̏������������s��
                            this._modeType = MODE_TYPE_DELETE;
                            // �R���g���[��Enabled����
                            this.SetControlEnabled(DELETE_MODE);
                            // �������Đݒ�
                            this._payDraftData = payDraftDataGet.Clone();
                            this._payDraftDataOrg = payDraftDataGet.Clone();
                            this._initFlg = true;
                            // ��ʍĕ\��
                            this.SetDataDisp(false);
                            this._initFlg = false;
                            ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //    "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜���Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + payDraftDataGet.PayDraftNo + "�@��s�E�x�X�R�[�h�F" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z\r\n" + "�ҏW���s���܂����H",
                            //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", "�ҏW���s���܂����H"
                                                               , payDraftDataGet.PayDraftNo
                                                               , payDraftDataGet.BankAndBranchCd / 1000
                                                               , payDraftDataGet.BankAndBranchCd % 1000
                                                               , payDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // �폜���[�h�̏������������s��
                                this._modeType = MODE_TYPE_DELETE;
                                // �R���g���[��Enabled����
                                this.SetControlEnabled(DELETE_MODE);
                                // �������Đݒ�
                                this._payDraftData = payDraftDataGet.Clone();
                                this._payDraftDataOrg = payDraftDataGet.Clone();
                                this._initFlg = true;
                                // ��ʍĕ\��
                                this.SetDataDisp(false);
                                this._initFlg = false;
                            }
                            else 
                            {
                                this._clickflg = true;
                            }
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        }
                        else
                        {
                            this.tNedit_DraftNo.Clear();
                            this.tNedit_DraftNo.Focus();
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>> 
                        }
                        else if (retList.Count > 1)
                        {
                            if (this._selectForm == null)
                                this._selectForm = new PMTEG09101UC();
                            DialogResult dr = this._selectForm.SelectGoodsGuideShow(this, ref retList);
                            if (dr == DialogResult.OK)
                            {
                                // UPD 2013/02/22�@ T.Miyamoto ------------------------------>>>>>
                                //// DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                ////// �ҏW���[�h
                                ////this._modeType = MODE_TYPE_UPDATE;
                                ////// �R���g���[��Enabled����
                                ////this.SetControlEnabled(UPDATE_MODE);
                                //// DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //// �������Đݒ�
                                //this._payDraftData = this._selectForm.PayDraftDataLst.Clone();
                                //this._payDraftDataOrg = this._selectForm.PayDraftDataLst.Clone();
                                //
                                //if (this._payDraftData.LogicalDeleteCode == DEL_CD_USE)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //this._initFlg = true;
                                //    //// ��ʍĕ\��
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false;
                                //    //this.tNedit_BankCd.Enabled = false;
                                //    //this.tNedit_BranchCd.Enabled = false;
                                //    //this.BankBranchGuide_Button.Enabled = false;
                                //    //this.tNedit_Section.Focus();
                                //    string sMsg = "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɓo�^����Ă��܂��B";
                                //    if (this._payDraftData.PaymentSlipNo != 0)
                                //        sMsg = "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B";
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , sMsg, "�ҏW���s���܂����H"
                                //                                       , this._payDraftData.PayDraftNo
                                //                                       , this._payDraftData.BankAndBranchCd / 1000
                                //                                       , this._payDraftData.BankAndBranchCd % 1000
                                //                                       , this._payDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // �ҏW���[�h
                                //        this._modeType = MODE_TYPE_UPDATE;
                                //        // �R���g���[��Enabled����
                                //        this.SetControlEnabled(UPDATE_MODE);
                                //        
                                //        this._initFlg = true;
                                //        // ��ʍĕ\��
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //        this.tNedit_BankCd.Enabled = false;
                                //        this.tNedit_BranchCd.Enabled = false;
                                //        this.BankBranchGuide_Button.Enabled = false;
                                //        this.tNedit_Section.Focus();
                                //    }
                                //    else
                                //    {
                                //        this._clickflg = true;
                                //        this.tNedit_BankCd.Focus();
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                //else if (this._payDraftData.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //// �폜���[�h�̏������������s��
                                //    //this._modeType = MODE_TYPE_DELETE;
                                //    //// �R���g���[��Enabled����
                                //    //this.SetControlEnabled(DELETE_MODE);
                                //    //this._initFlg = true;
                                //    //// ��ʍĕ\��
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false;
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", "�ҏW���s���܂����H"
                                //                                       , this._payDraftData.PayDraftNo
                                //                                       , this._payDraftData.BankAndBranchCd / 1000
                                //                                       , this._payDraftData.BankAndBranchCd % 1000
                                //                                       , this._payDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // �폜���[�h�̏������������s��
                                //        this._modeType = MODE_TYPE_DELETE;
                                //        // �R���g���[��Enabled����
                                //        this.SetControlEnabled(DELETE_MODE);
                                //        this._initFlg = true;
                                //        // ��ʍĕ\��
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //    }
                                //    else
                                //    {
                                //        this._clickflg = true;
                                //        this.tNedit_BankCd.Focus();
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                PayDraftData payDraftDataChk = this._selectForm.PayDraftDataLst.Clone(); // �`�F�b�N�p
                                if (payDraftDataChk.LogicalDeleteCode == DEL_CD_USE)
                                {
                                    string sMsg = "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɓo�^����Ă��܂��B";
                                    if (payDraftDataChk.PaymentSlipNo != 0)
                                        sMsg = "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B";
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , sMsg, "�ҏW���s���܂����H"
                                                                       , payDraftDataChk.PayDraftNo
                                                                       , payDraftDataChk.BankAndBranchCd / 1000
                                                                       , payDraftDataChk.BankAndBranchCd % 1000
                                                                       , payDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // �ҏW���[�h
                                        this._modeType = MODE_TYPE_UPDATE;
                                        // �R���g���[��Enabled����
                                        this.SetControlEnabled(UPDATE_MODE);
                                        this._initFlg = true;
                                        // �������Đݒ�
                                        this._payDraftData = this._selectForm.PayDraftDataLst.Clone();
                                        this._payDraftDataOrg = this._selectForm.PayDraftDataLst.Clone();
                                        // ��ʍĕ\��
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                        this.tNedit_BankCd.Enabled = false;
                                        this.tNedit_BranchCd.Enabled = false;
                                        this.BankBranchGuide_Button.Enabled = false;
                                    }
                                    else
                                    {
                                        this._clickflg = true;
                                    }
                                }
                                else if (payDraftDataChk.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                {
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", "�ҏW���s���܂����H"
                                                                       , payDraftDataChk.PayDraftNo
                                                                       , payDraftDataChk.BankAndBranchCd / 1000
                                                                       , payDraftDataChk.BankAndBranchCd % 1000
                                                                       , payDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // �폜���[�h�̏������������s��
                                        this._modeType = MODE_TYPE_DELETE;
                                        // �R���g���[��Enabled����
                                        this.SetControlEnabled(DELETE_MODE);
                                        this._initFlg = true;
                                        // �������Đݒ�
                                        this._payDraftData = this._selectForm.PayDraftDataLst.Clone();
                                        this._payDraftDataOrg = this._selectForm.PayDraftDataLst.Clone();
                                        // ��ʍĕ\��
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                    }
                                    else
                                    {
                                        this._clickflg = true;
                                    }
                                }
                                // UPD 2013/02/22�@ T.Miyamoto ------------------------------<<<<<
                                else 
                                {
                                    this.tNedit_DraftNo.Clear();
                                    this.tNedit_DraftNo.Focus();
                                }
                            }
                            else
                            {
                                this._clickflg = true;
                                this.tNedit_BankCd.Focus();
                            }
                        }
                        else 
                        {
                            if (this.tNedit_DraftNo.Focused) { this.tNedit_BranchCd.Focus(); }
                            if (this.tNedit_BranchCd.Focused) { this.tNedit_Section.Focus(); }
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }
                }
            }
            // ���͂���N��
            else
            {
                List<RcvDraftData> rcvRetListTemp = null;// ADD zhuhh 2013/01/10 for Redmine #34123
                // ����`
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<RcvDraftData> retList = new List<RcvDraftData>();
                    RcvDraftData paraRcvDraftData = new RcvDraftData();
                    paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                    paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                       ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<RcvDraftData> retList = new List<RcvDraftData>();
                    RcvDraftData paraRcvDraftData = new RcvDraftData();
                    paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                    paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                    paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                    if (!String.IsNullOrEmpty(this.tNedit_DraftNo.Text))
                    {

                        paraRcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraRcvDraftData.BankAndBranchCd == 0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithoutBabCd(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = false;
                        }
                        else if (paraRcvDraftData.BankAndBranchCd == 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.SearchWithBabCd(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    else 
                    {
                        return false;
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                }
                // �x����`�f�[�^
                else
                {
                    // ��ʂ̎�`��ʂ�ێ�
                    int DraftKindCd = this._payDraftData.DraftKindCd;
                    /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<PayDraftData> retList = new List<PayDraftData>();
                    PayDraftData paraPayDraftData = new PayDraftData();
                    paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                    paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                       ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<PayDraftData> retList = new List<PayDraftData>();
                    PayDraftData paraPayDraftData = new PayDraftData();
                    paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                    paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                    paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                    if (!String.IsNullOrEmpty(this.tNedit_DraftNo.Text))
                    {
                        paraPayDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithoutBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        else if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.SearchWithBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    else 
                    {
                        return false;
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                    bool payChkFlg = false; // ������`�������� // ADD 2013/02/22 T.Miyamoto
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        PayDraftData payDraftDataGet = (PayDraftData)retList[0];
                        // �_���폜�敪 = 0:�L��
                        if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            if (payDraftDataGet.PaymentSlipNo != 0)
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B", 0, MessageBoxButtons.OK);
                                this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                                return false;
                            }
                            // �X�V���[�h�̏������������s��
                            this._modeType = MODE_TYPE_UPDATE;
                            // �R���g���[��Enabled����
                            this.SetControlEnabled(UPDATE_MODE);

                            // �x����`���ێ�(���z�E�����`�F�b�N�p)
                            this._payDraftDataInfo = payDraftDataGet.Clone();

                            // ��ʏ��𔽉f
                            int ProcDate = this.tDateEdit_ProcDate.GetLongDate();         // ������
                            payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // ����
                            payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // ���z

                            // �������Đݒ�
                            this._payDraftData = payDraftDataGet.Clone();
                            this._payDraftDataOrg = payDraftDataGet.Clone();
                        }
                        // �_���폜�敪 = 1:�_���폜
                        else if (payDraftDataGet.LogicalDeleteCode == DEL_CD_LOG_DEL)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", 0, MessageBoxButtons.OK);
                            // ��`�ԍ���߂�
                            this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                            return false;
                        }
                           ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (retList.Count == 1)
                        {
                            PayDraftData payDraftDataGet = retList[0];
                            if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                            {
                                if (payDraftDataGet.PaymentSlipNo != 0)
                                {
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                    //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + payDraftDataGet.PayDraftNo + "�@��s�E�x�X�R�[�h�F" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z", 0, MessageBoxButtons.OK);
                                    SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                                 , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B", ""
                                                 , payDraftDataGet.PayDraftNo
                                                 , payDraftDataGet.BankAndBranchCd / 1000
                                                 , payDraftDataGet.BankAndBranchCd % 1000
                                                 , payDraftDataGet.DraftDrawingDate);
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                    this.tNedit_DraftNo.Focus();
                                    this._clickflg = true;
                                    //return false; // DEL 2013/02/22�B T.Miyamoto
                                }
                                else 
                                {
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                    //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                                    //    "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɓo�^����Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + payDraftDataGet.PayDraftNo + "�@��s�E�x�X�R�[�h�F" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z\r\n" + "�����������s���܂����H",
                                    //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɓo�^����Ă��܂��B", "�����������s���܂����H"
                                                                       , payDraftDataGet.PayDraftNo
                                                                       , payDraftDataGet.BankAndBranchCd / 1000
                                                                       , payDraftDataGet.BankAndBranchCd % 1000
                                                                       , payDraftDataGet.DraftDrawingDate);
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                    if (result == DialogResult.Yes)
                                    {
                                        // �X�V���[�h�̏������������s��
                                        this._modeType = MODE_TYPE_UPDATE;
                                        // �R���g���[��Enabled����
                                        this.SetControlEnabled(UPDATE_MODE);

                                        // �x����`���ێ�(���z�E�����`�F�b�N�p)
                                        this._payDraftDataInfo = payDraftDataGet.Clone();

                                        // ��ʏ��𔽉f
                                        int ProcDate = this.tDateEdit_ProcDate.GetLongDate();         // ������
                                        payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // ����
                                        payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // ���z

                                        // �������Đݒ�
                                        this._payDraftData = payDraftDataGet.Clone();
                                        this._payDraftDataOrg = payDraftDataGet.Clone();
                                        this._payflag = false;

                                        payChkFlg = true; // ������`�������� // ADD 2013/02/22 T.Miyamoto
                                    }
                                    else 
                                    {
                                        this._payflag = true;
                                        //return false; // DEL 2013/02/22�B T.Miyamoto
                                    }
                                }                                                               
                            }
                            else 
                            {
                                // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + payDraftDataGet.PayDraftNo + "�@��s�E�x�X�R�[�h�F" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z", 0, MessageBoxButtons.OK);
                                SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                             , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", ""
                                             , payDraftDataGet.PayDraftNo
                                             , payDraftDataGet.BankAndBranchCd / 1000
                                             , payDraftDataGet.BankAndBranchCd % 1000
                                             , payDraftDataGet.DraftDrawingDate);
                                // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                this._clickflg = true;
                                //return false; // DEL 2013/02/22�B T.Miyamoto
                            }
                        }
                        else if (retList.Count > 1)
                        {
                            if (this._selectForm == null)
                                this._selectForm = new PMTEG09101UC();
                            DialogResult dr = this._selectForm.SelectGoodsGuideShow(this, ref retList);
                            if (dr == DialogResult.OK)
                            {
                                PayDraftData payDraftDataGet = this._selectForm.PayDraftDataLst.Clone();
                                if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                                {
                                    if (payDraftDataGet.PaymentSlipNo != 0)
                                    {
                                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                        //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + payDraftDataGet.PayDraftNo + "�@��s�E�x�X�R�[�h�F" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z", 0, MessageBoxButtons.OK);
                                        SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                                     , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��Ɉ������Ă��܂��B", ""
                                                     , payDraftDataGet.PayDraftNo
                                                     , payDraftDataGet.BankAndBranchCd / 1000
                                                     , payDraftDataGet.BankAndBranchCd % 1000
                                                     , payDraftDataGet.DraftDrawingDate);
                                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                        this.tNedit_DraftNo.Focus();
                                        //return false; // DEL 2013/02/22�B T.Miyamoto
                                    }
                                    else
                                    {
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------>>>>>
                                        // ��`�I����ʂőI��������`���o�^��(������)�̏ꍇ�A�m�F���b�Z�[�W��\��
                                        DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                           , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɓo�^����Ă��܂��B", "�����������s���܂����H"
                                                                           , payDraftDataGet.PayDraftNo
                                                                           , payDraftDataGet.BankAndBranchCd / 1000
                                                                           , payDraftDataGet.BankAndBranchCd % 1000
                                                                           , payDraftDataGet.DraftDrawingDate);
                                        if (result == DialogResult.Yes)
                                        {
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------<<<<<
                                            // �X�V���[�h�̏������������s��
                                            this._modeType = MODE_TYPE_UPDATE;
                                            // �R���g���[��Enabled����
                                            this.SetControlEnabled(UPDATE_MODE);

                                            // �x����`���ێ�(���z�E�����`�F�b�N�p)
                                            this._payDraftDataInfo = payDraftDataGet.Clone();

                                            // ��ʏ��𔽉f
                                            int ProcDate = this.tDateEdit_ProcDate.GetLongDate();         // ������
                                            payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // ����
                                            payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // ���z

                                            // �������Đݒ�
                                            this._payDraftData = payDraftDataGet.Clone();
                                            this._payDraftDataOrg = payDraftDataGet.Clone();
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------>>>>>
                                            payChkFlg = true; // ������`��������
                                        }
                                        else
                                        {
                                            this._payflag = true;
                                        }
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------<<<<<
                                    }
                                }
                                else 
                                {
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                    //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + payDraftDataGet.PayDraftNo + "�@��s�E�x�X�R�[�h�F" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "�z", 0, MessageBoxButtons.OK);
                                    SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                                 , "���͂��ꂽ�ԍ��̎�`�f�[�^�͊��ɍ폜����Ă��܂��B", ""
                                                 , payDraftDataGet.PayDraftNo
                                                 , payDraftDataGet.BankAndBranchCd / 1000
                                                 , payDraftDataGet.BankAndBranchCd % 1000
                                                 , payDraftDataGet.DraftDrawingDate);
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                    this._clickflg = true;
                                    //return false; // DEL 2013/02/22�B T.Miyamoto
                                }
                            }
                            else 
                            {
                                //this.tNedit_BankCd.Focus(); // DEL 2013/02/22�B T.Miyamoto
                                //return false;               // DEL 2013/02/22�B T.Miyamoto
                            }
                        }
                        else { return false; }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }

                    if (this._rcvDraftFlg)
                    {
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                        {
                            // --- ADD 2012/10/29 -------------------------------------------------->>>>>
                            // ��ʏ���ێ�
                            int ProcDate = this._payDraftData.ProcDate;            // ������
                            string AddUpSecCode = this._payDraftData.AddUpSecCode; // ����拒�_�R�[�h
                            int SupplierCd = this._payDraftData.SupplierCd;        // �����R�[�h
                            string SupplierSnm = this._payDraftData.SupplierSnm;   // ����於��
                            // --- ADD 2012/10/29 --------------------------------------------------<<<<<
                            string sectionCode = this._payDraftData.SectionCode;   // ���_�@// ADD ���N 2013/04/02 Redmine#35247

                            // �x����`�f�[�^�������ł��Ȃ��ꍇ
                            this._payDraftData = new PayDraftData(); // 2012/10/24 ADD

                            // --- ADD 2012/10/29 -------------------------------------------------->>>>>
                            // ��ʏ��𔽉f
                            this._payDraftData.ProcDate = ProcDate;         // ������
                            this._payDraftData.AddUpSecCode = AddUpSecCode; // ����拒�_�R�[�h
                            this._payDraftData.SupplierCd = SupplierCd;     // �����R�[�h
                            this._payDraftData.SupplierSnm = SupplierSnm;   // ����於��
                            // --- ADD 2012/10/29 --------------------------------------------------<<<<<
                            this._payDraftData.SectionCode = sectionCode;   // ���_�@// ADD ���N 2013/04/02 Redmine#35247

                            // �X�V���[�h�̏������������s��
                            this._modeType = MODE_TYPE_UPDATE;
                            // �R���g���[��Enabled����
                            this.SetControlEnabled(UPDATE_MODE);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //========================================
                        // ����`�f�[�^�K�C�h�����̏ꍇ
                        //========================================
                        RcvDraft_Label.Visible = true;

                        // ������������`�f�[�^���x����`�f�[�^�i�[�̈�ɓW�J��
                        // ��`�ԍ�
                        this._payDraftData.PayDraftNo = this._rcvDraftData.RcvDraftNo;
                        // ----- ADD ���N 2013/04/02 Redmine#35247 ----->>>>>
                        if (!this._supplierSummary)
                        {
                        // ----- ADD ���N 2013/04/02 Redmine#35247 -----<<<<<
                        // ���O�C�����_
                        this._payDraftData.SectionCode = this._rcvDraftData.SectionCode;
                        }// ADD ���N 2013/04/02 Redmine#35247 
                        // ��`���
                        this._payDraftData.DraftKindCd = DraftKindCd;
                        // �����U�敪
                        this._payDraftData.DraftDivide = this._rcvDraftData.DraftDivide;
                        // �U�o��
                        this._payDraftData.DraftDrawingDate = this._rcvDraftData.DraftDrawingDate;
                        // ����
                        this._payDraftData.ValidityTerm = this._rcvDraftData.ValidityTerm;
                        //�@���z
                        this._payDraftData.Payment = this._rcvDraftData.Deposit;
                        // ��s�E�x�X�R�[�h
                        this._payDraftData.BankAndBranchCd = this._rcvDraftData.BankAndBranchCd;
                        // ��s����
                        this._payDraftData.BankAndBranchNm = this._rcvDraftData.BankAndBranchNm;
                        // �E�v�P
                        this._payDraftData.Outline1 = this._rcvDraftData.Outline1;
                        // �E�v�Q
                        this._payDraftData.Outline2 = this._rcvDraftData.Outline2;

                        payChkFlg = true; // ������`�������� // ADD 2013/02/22 T.Miyamoto
                    }
                    // UPD 2013/02/22 T.Miyamoto ------------------------------>>>>>
                    //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) && (payChkFlg))
                    // UPD 2013/02/22 T.Miyamoto ------------------------------<<<<<
                    {
                        this._initFlg = true;
                        // ��ʍĕ\��
                        this.SetDataDisp(false);
                        this._initFlg = false;

                        // �x����`���`�F�b�N����
                        this.PayDraftCheck();
                    }
                    // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                }
                // --- UPD 2012/10/18 -------------------------------------------------->>>>>
                //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                if (this._draftMode == DRAFT_DIV_RCV &&
                    status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                // --- UPD 2012/10/18 --------------------------------------------------<<<<<
                {
                    /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 , this.ToString()
                                 , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B"
                                 , 0
                                 , MessageBoxButtons.OK);
                    // ��`�ԍ���߂�
                    if (this._draftMode == DRAFT_DIV_RCV)
                        this.tNedit_DraftNo.Value = this._rcvDraftData.RcvDraftNo;
                    else
                        this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                     * ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        RcvDraftData rcvDraftDataTemp = null;
                        if (rcvRetListTemp.Count == 1) 
                        {
                            rcvDraftDataTemp = rcvRetListTemp[0];
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                            //       , this.ToString()
                            //       , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + rcvDraftDataTemp.RcvDraftNo + "�@��s�E�x�X�R�[�h�F" + (rcvDraftDataTemp.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (rcvDraftDataTemp.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + rcvDraftDataTemp.DraftDrawingDate.ToString("yyyyMMdd") + "�z"
                            //       , 0
                            //       , MessageBoxButtons.OK);
                            SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                         , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B", ""
                                         , rcvDraftDataTemp.RcvDraftNo
                                         , rcvDraftDataTemp.BankAndBranchCd / 1000
                                         , rcvDraftDataTemp.BankAndBranchCd % 1000
                                         , rcvDraftDataTemp.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            this._clickflg = true;
                            this.tNedit_BankCd.Focus();
                        }
                        else if (rcvRetListTemp.Count > 1)
                        {
                            if (this._selectForm == null)
                                this._selectForm = new PMTEG09101UC();
                            DialogResult dr=this._selectForm.SelectGoodsGuideShow(this, ref rcvRetListTemp);
                            if (dr == DialogResult.OK)
                            {
                               rcvDraftDataTemp = this._selectForm.RcvDraftDataLst.Clone();
                               // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                               //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                               //   , this.ToString()
                               //   , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B" + "\r\n" + "�y��`�ԍ��F" + rcvDraftDataTemp.RcvDraftNo + "�@��s�E�x�X�R�[�h�F" + (rcvDraftDataTemp.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "�]" + (rcvDraftDataTemp.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  �U�o���F" + rcvDraftDataTemp.DraftDrawingDate.ToString("yyyyMMdd") + "�z"
                               //   , 0
                               //   , MessageBoxButtons.OK);
                               SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                            , "���͂��ꂽ�ԍ��̎�`�f�[�^�����ɓo�^����Ă��܂��B", ""
                                            , rcvDraftDataTemp.RcvDraftNo
                                            , rcvDraftDataTemp.BankAndBranchCd / 1000
                                            , rcvDraftDataTemp.BankAndBranchCd % 1000
                                            , rcvDraftDataTemp.DraftDrawingDate);
                               // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                            this._clickflg = true;
                            this.tNedit_BankCd.Focus();
                        }                    
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    return false;
                }
            }
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        string draftNo = "";
                        // �����ł��Ȃ��ꍇ�A�V�K����
                        if (this._draftMode == DRAFT_DIV_RCV)
                        {
                            draftNo = this._rcvDraftData.RcvDraftNo;
                            this._rcvDraftData = new RcvDraftData();
                            this.ScreenToDraftData();
                            this._rcvDraftDataOrg = this._rcvDraftData.Clone();
                            this._rcvDraftDataOrg.RcvDraftNo = draftNo;
                        }
                        else
                        {
                            draftNo = this._payDraftData.PayDraftNo;
                            this._payDraftData = new PayDraftData();
                            this.ScreenToDraftData();
                            this._payDraftDataOrg = this._payDraftData.Clone();
                            this._payDraftDataOrg.PayDraftNo = draftNo;
                        }
                           ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (this._draftMode == DRAFT_DIV_RCV)
                        {
                            this._rcvDraftData = new RcvDraftData();
                            this.ScreenToDraftData();                           
                        }
                        else
                        {
                            this._payDraftData = new PayDraftData();
                            this.ScreenToDraftData();                            
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        break;
                    }
                default:
                    {
                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                        //if (this._modeType == DRAFT_DIV_PAY)
                        if (this._draftMode == DRAFT_DIV_PAY)
                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                        {
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                                PGID,							        // �A�Z���u��ID
                                this.Text,                              // �v���O��������
                                "Search",                               // ��������
                                TMsgDisp.OPE_GET,                       // �I�y���[�V����
                                "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                                status,									// �X�e�[�^�X�l
                                this._payDraftDataAcs,					// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,					// �\������{�^��
                                MessageBoxDefaultButton.Button1);		// �����\���{�^��
                        }
                        else
                        {
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                                PGID,							        // �A�Z���u��ID
                                this.Text,                              // �v���O��������
                                "Search",                               // ��������
                                TMsgDisp.OPE_GET,                       // �I�y���[�V����
                                "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                                status,									// �X�e�[�^�X�l
                                this._rcvDraftDataAcs,					 // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,					// �\������{�^��
                                MessageBoxDefaultButton.Button1);		// �����\���{�^��
                        }

                        return false;
                    }
            }

            return true;
        }
        # endregion ��������

        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        # region �x����`���擾����(�����N����)
        /// <summary>
        ///�@�x����`���擾����(PayDraftInfoGet())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �x����`���̎擾���s���܂��B</br>
        /// <br>Programmer  : �{�{</br>
        /// <br>Date        : 2012/10/18</br>
        /// </remarks>
        private void PayDraftInfoGet()
        {
            if (this._startType == START_TYPE_CALL)
            {
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    if (this._payDraftData.PayDraftNo != "")
                    {
                        List<PayDraftData> retList = new List<PayDraftData>();
                        PayDraftData paraPayDraftData = new PayDraftData();
                        paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                        paraPayDraftData.PayDraftNo = this._payDraftData.PayDraftNo;
                        int status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            PayDraftData payDraftDataGet = (PayDraftData)retList[0];
                            // �_���폜�敪 = 0:�L��
                            if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                                this._payDraftDataInfo = payDraftDataGet.Clone();
                        }
                    }
                }
            }
        }
        # endregion �x����`���擾����(�����N����)

        # region �x����`���`�F�b�N����
        /// <summary>
        ///�@�x����`���`�F�b�N����(PayDraftChk())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ���z�Ɗ����̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �{�{</br>
        /// <br>Date        : 2012/10/18</br>
        /// </remarks>
        private bool PayDraftCheck()
        {
            if (this._startType == START_TYPE_CALL)
            {
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    if (this._payDraftDataInfo.PayDraftNo != "")
                    {
                        string errMsg = "";
                        if (this._payDraftDataInfo.ValidityTerm != this._payDraftData.ValidityTerm)
                        {
                            errMsg = "�������m�F���Ă��������B";
                        }
                        if (this._payDraftDataInfo.Payment != this._payDraftData.Payment)
                        {
                            if (errMsg.Length > 0)
                            errMsg = errMsg + "\r\n";
                            errMsg = errMsg + "���z���m�F���Ă��������B";
                        }
                        if (errMsg.Length > 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                                        , this.ToString()
                                        , errMsg
                                        , 0
                                        , MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        # endregion �x����`���`�F�b�N����
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        # region �_���폜����
        /// <summary>
        /// �_���폜�N���b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �_���폜�{�^�����N���b�N���ꂽ�Ƃ��ɔ���</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (_draftMode == DRAFT_DIV_RCV)
            {
                List<RcvDraftData> rcvDraftDataList = new List<RcvDraftData>();
                rcvDraftDataList.Add(this._rcvDraftData);
                status = this._rcvDraftDataAcs.LogicalDelete(ref rcvDraftDataList);
                }
            else
            {
                List<PayDraftData> payDraftDataList = new List<PayDraftData>();
                payDraftDataList.Add(this._payDraftData);
                status = this._payDraftDataAcs.LogicalDelete(ref payDraftDataList);
               }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ��ʏ�����
                        this.InitDisp();
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion �_���폜����

        # region �����폜����
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��`�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (_draftMode == DRAFT_DIV_RCV)
            {
                List<RcvDraftData> deleteList = new List<RcvDraftData>();
                deleteList.Add(this._rcvDraftData);
                // �����폜
                status = this._rcvDraftDataAcs.Delete(deleteList);
            }
            else
            {
                List<PayDraftData> deleteList = new List<PayDraftData>();
                deleteList.Add(this._payDraftData);
                // �����폜
                status = this._payDraftDataAcs.Delete(deleteList);
            }        
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ��ʏ�����
                        this.InitDisp();
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "���S�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion �����폜����

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��`�f�[�^�𕜊����܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (_draftMode == DRAFT_DIV_RCV)
            {
                List<RcvDraftData> rcvDraftDataList = new List<RcvDraftData>();
                rcvDraftDataList.Add(this._rcvDraftData);
                status�@= this._rcvDraftDataAcs.Revival(ref rcvDraftDataList);
                // �������ۑ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._rcvDraftData = rcvDraftDataList[0];
                    this._rcvDraftDataOrg = this._rcvDraftData.Clone();
                }
            }
            else
            {
                List<PayDraftData> payDraftDataList = new List<PayDraftData>();
                payDraftDataList.Add(this._payDraftData);
                status = this._payDraftDataAcs.Revival(ref payDraftDataList);
                // �������ۑ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._payDraftData = payDraftDataList[0];
                    this._payDraftDataOrg = this._payDraftData.Clone();
                }
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h
                        this._modeType = MODE_TYPE_UPDATE;
                        // �R���g���[��Enabled����
                        this.SetControlEnabled(UPDATE_MODE);
                        this._initFlg = true;
                        // ��ʍĕ\��
                        this.SetDataDisp(false);
                        this._initFlg = false;
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "���������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion

        # region �r������
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �r��������s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
           
        }
        # endregion �r������
        # endregion

        # region ���b�Z�[�W�{�b�N�X�\��

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         PGID,                              // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                dialogResult = TMsgDisp.Show(this, 						    // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         PGID, 		  �@�@			        // �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._payDraftDataAcs,				// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }
            else
            {
                dialogResult = TMsgDisp.Show(this, 						    // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         PGID, 		  �@�@			        // �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._rcvDraftDataAcs,				// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }
            return dialogResult;
        }

        # endregion ���b�Z�[�W�{�b�N�X�\��

        # region �������b�Z�[�W�\��
        // ADD 2013/02/15 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �������b�Z�[�W�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ��`�f�[�^������̃��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2013.02.15</br>
        /// </remarks>
        private DialogResult SearchMsgShow(emErrorLevel errLevel, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton
                                          , string message1, string message2
                                          , string PayDraftNo, int BankCd, int BranchCd, DateTime DraftDrawingDate)
        {
            string sMsg = message1
                        + "\r\n" + "�@�y��`�ԍ��@�z�F" + PayDraftNo
                        + "\r\n" + "�@�y��s�^�x�X�z�F" + (BankCd + "").PadLeft(4, '0') + "�]" + (BranchCd + "").PadLeft(3, '0')
                        + "\r\n" + "�@�y�U�o���@�@�z�F" + DraftDrawingDate.ToString("yyyy/MM/dd")
                        + "\r\n" + message2;

            DialogResult dialogResult = TMsgDisp.Show(errLevel, PGID, sMsg, status, msgButton, defaultButton);
            return dialogResult;
        }
        // ADD 2013/02/15 T.Miyamoto ------------------------------<<<<<
        # endregion ���b�Z�[�W�{�b�N�X�\��

        #region �I�v�V�������L���b�V��
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2013/04/02</br>
        /// <br>�Ǘ��ԍ��@ : 10901273-00 2013/05/15�z�M��</br>
        /// <br>           : Redmine#35247 �d�������I�v�V�����̒���</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���d���摍���I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._supplierSummary = true;
            }
            else
            {
                this._supplierSummary = false;
            }
            #endregion
        }
        #endregion �I�v�V�������L���b�V��
    }
   
}