//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���`�F�b�N����
// �v���O�����T�v   : �d���`�F�b�N�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30418 ���i
// �C �� ��  2008/11/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �C �� ��  2009/02/02  �C�����e : �r�����䏈���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �C �� ��  2009/02/24  �C�����e : ��QID:11877�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �C �� ��  2009/02/25  �C�����e : ��QID:7882�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �C �� ��  2009/03/12  �C�����e : ��QID:8975�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �C �� ��  2009/03/24  �C�����e : ��QID:12789�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ���
// �C �� ��  2009/04/03  �C�����e : ��QID:13068�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/06/29  �C�����e : MANTIS�y13346�z�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2010/10/21  �C�����e : MANTIS�F0016368�A0016384�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/12/05  �C�����e : Redmine#8416�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/12/13  �C�����e : Redmine#26642�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/08/30  �C�����e : 2012/09/12�z�M���ARedmine#31879
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@No.1082�A1157�A1159�@�g�c����@�d���`�F�b�N�����C���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �� ��
// �C �� ��  2012/09/27  �C�����e : 2012/10/17�z�M��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �� ��
// �C �� ��  2012/10/09  �C�����e : 2012/10/17�z�M��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�ԓ`�̏ꍇ�͔w�i�F��Ԃɂ���
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Resources;
using System.IO;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �d���`�F�b�N����
    /// </summary>
    ///<remarks>
    /// <br>Note        : �d���`�F�b�N����UI�t�H�[���N���X</br>
    /// <br>Programmer  : 30418 ���i</br>
    /// <br>Date        : 2008/11/25</br>
    /// <br>Update Note : 2009/02/02 30414 �E �r�����䏈���ǉ�</br>
    /// <br>Update Note : 2009/02/24 30414 �E ��QID:11877�Ή�</br>
    /// <br>Update Note : 2009/02/25 30414 �E ��QID:7882�Ή�</br>
    /// <br>Update Note : 2009/03/12 30414 �E ��QID:8975�Ή�</br>
    /// <br>Update Note : 2009/03/24 30414 �E ��QID:12789�Ή�</br>
    /// <br>Update Note : 2009/04/03 30452 ��� ��QID:13068�Ή�</br>
    /// <br>Update Note : 2010/10/21 �����</br>
    /// <br>              MANTIS�F0016368�A0016384 ���z�A����ŕ\�����e�̕ύX</br>
    /// <br>Update Note : 2011/12/05 ������</br>
    /// <br>              Redmine#8416�̑Ή�</br>
    /// <br>Update Note : 2011/12/13 ������</br>
    /// <br>              Redmine#26642�̑Ή�</br>
    /// <br>Update Note : 2012/08/30 ������</br>
    /// <br>�Ǘ��ԍ�  �@: 10801804-00 2012/09/12�z�M��</br>
    /// <br>              Redmine#31879 No.1082�A1157�A1159�@�g�c����@�d���`�F�b�N�����C���̑Ή�</br>
    /// <br>Update Note : 2012/09/27 �� ��</br>
    /// <br>�Ǘ��ԍ�  �@: 10801804-00 2012/10/17�z�M��</br>
    /// <br>              UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���</br>
    /// <br>Update Note : 2012/10/09 �� ��</br>
    /// <br>�Ǘ��ԍ�  �@: 10801804-00 2012/10/17�z�M��</br>
    /// <br>              �ԓ`�̏ꍇ�͔w�i�F��Ԃɂ���</br>
    /// </remarks>
    public partial class PMKOU01101UA : Form
    {

        #region �v���C�x�[�g�ϐ�

        #region ���[�J���N���X

        /// <summary>�d���`�F�b�N�������o�����N���X</summary>
        private SupplierCheckOrderCndtn _supplierCheckOrderCndtn = null;

        /// <summary>�d���`�F�b�N�����A�N�Z�X�N���X</summary>
        private SupplierCheckAcs _supplierCheckAcs = null;
        //-----ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>>
        // ���[�U�[�ݒ�
        private  SupplierCheckOrderSet _userSetting;
        //-----ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<

        #endregion // ���[�J���N���X

        #region �N���X

        /// <summary>SFKTN01210A)���_�A�N�Z�X�N���X</summary>
        private SecInfoAcs _secInfoAcs;

        /// <summary>SFKTN09002A)���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>SFKTN09001E)���_���f�[�^�N���X</summary>
        private SecInfoSet _sectionInfo;

        /// <summary>PMKHN09022A)�d����</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>PMKHN09021E)�d������f�[�^�N���X</summary>
        private Supplier _supplier = null;

        /// <summary>���Џ��A�N�Z�X�N���X</summary>
        private DateGetAcs _dateGetAcs = null;

        /// <summary>MACMN00001C)UI�X�L���ݒ�R���g���[��</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        #endregion // �N���X

        #region �f�[�^�Z�b�g

        /// <summary>�d���`�F�b�N�������f�[�^�Z�b�g</summary>
        SupplierCheckDataSet _dataSet = null;

        #endregion // �f�[�^�Z�b�g

        #region �R�[�h��

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>�����_�R�[�h</summary>
        private string _loginSectionCode = string.Empty;

        /// <summary>���O�C�����[�U�[�R�[�h</summary>
        private string _loginUserCd = string.Empty;

        /// <summary>���O�C�����[�U�[��</summary>
        private string _loginUserName = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

        /// <summary>�{�^���p�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;

        /// <summary>�����敪 ����:0/����:1</summary>
        /// <remarks>�����敪�R���{���ύX����邽�тɂ��̒l�ɏC�������</remarks>
        private int _procDiv = 0;

        #endregion // �R�[�h��

        #region ���ߓ��֘A 

        /// <summary>PMCMN00102A)���ߓ��擾�p�N���X</summary>
        TotalDayCalculator _tCalcAcs = null;

        /// <summary>�����������</summary>
        private DateTime _currentTotalDay;

        /// <summary>�����������</summary>
        private DateTime _currentTotalMonth;

        /// <summary>�O���������</summary>
        private DateTime _prevTotalDay;

        /// <summary>�O���������</summary>
        private DateTime _prevTotalMonth;

        #endregion // ���ߓ��֘A
        
        #endregion // �v���C�x�[�g�ϐ�

        #region �萔

        /// <summary>�S�ЃR�[�h���́F�����l�u�S�Ёv</summary>
        private const string CT_NAME_ALLSECCODE = "�S��";

        /// <summary>�S�ЃR�[�h�F�����l�u00�v</summary>
        private const string CT_CODE_ALLSECCODE = "00";

        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>�`�F�b�N�{�b�N�X�F�`�F�b�N�Ȃ�</summary>
        private const int CT_CHECKBOXSTATUS_UNCHECK = 0;

        /// <summary>�`�F�b�N�{�b�N�X�F�`�F�b�N</summary>
        private const int CT_CHECKBOXSTATUS_CHECK = 1;

        /// <summary>�`�F�b�N�{�b�N�X�F�s�N��</summary>
        private const int CT_CHECKBOXSTATUS_UNCLEAR = 2;

        /// <summary>�O���b�h �s�N���A���t�@���x�� 128</summary>
        /// <remarks>0����255�̊ԂŐݒ�A�������傫���قǐF�������Ȃ�</remarks>
        private const int CT_UNCLEAR_CHECKBOX_ALPHA = 128;

        #region ���b�Z�[�W�萔

        /// <summary>�G���[���b�Z�[�W�F�u�����敪�͕K�{���ڂł��B�v</summary>
        private const string CT_SLIP_DIV_NOT_SELECTED = "�����敪�͕K�{���ڂł��B";

        /// <summary>�G���[���b�Z�[�W�F�u�d�����͕K�{���ڂł��B�v</summary>
        private const string CT_STOCKDATE_NOT_INPUT = "�d�����͕K�{���ڂł��B";

        /// <summary>�G���[���b�Z�[�W�F�u�I�����ꂽ������͓��ꌎ���ł͂���܂���B�v</summary>
        private const string CT_DATE_NOT_IN_TERM = "�I�����ꂽ������͓��ꌎ���ł͂���܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�`�[�ԍ��͐����œ��͂��Ă��������B�v</summary>
        private const string CT_SLIPNO_NOT_NUMERIC = "�`�[�ԍ��͐����œ��͂��Ă��������B";

        /// <summary>�G���[���b�Z�[�W�F�u�ɐ��������t����͂��Ă��������B�v</summary>
        private const string CT_DATE_INVALID = "�ɐ��������t����͂��Ă��������B";

        /// <summary>�G���[���b�Z�[�W�F�u���t(�I��)�͓��t(�J�n)������̓��t����͂��Ă��������B�v</summary>
        private const string CT_DATEED_MUSTBE_LATER = "���t(�I��)�͓��t(�J�n)������̓��t����͂��Ă��������B";

        /// <summary>�G���[���b�Z�[�W�F�u�`�[�ԍ�(�I��)�͓`�[�ԍ�(�J�n)�����傫�Ȑ�������͂��Ă��������B�v</summary>
        private const string CT_SLIPNOED_MUSTBE_LARGE = "�`�[�ԍ�(�I��)�͓`�[�ԍ�(�J�n)�����傫�Ȑ�������͂��Ă��������B";

        /// <summary>�G���[���b�Z�[�W�F�u�d��SEQ�ԍ�(�I��)�͎d��SEQ�ԍ�(�J�n)�����傫�Ȑ�������͂��Ă��������B�v</summary>
        private const string CT_SUPPSLIPNOED_MUSTBE_LARGE = "�d��SEQ�ԍ�(�I��)�͎d��SEQ�ԍ�(�J�n)�����傫�Ȑ�������͂��Ă��������B";

        /// <summary>�G���[���b�Z�[�W�F�u��ƃR�[�h���擾����Ă��܂���B�v</summary>
        private const string CT_ENTERPRISE_CODE_NOT_QUALIFIED = "��ƃR�[�h���擾����Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�Y������f�[�^��������܂���ł����B�v</summary>
        private const string CT_NOT_FOUND = "�Y������f�[�^��������܂���ł����B";

        /// <summary>���b�Z�[�W�F�u ���̃f�[�^��������܂����B�v</summary>
        private const string CT_FOUND_RECORD = " ���̃f�[�^��������܂����B";

        /// <summary>���b�Z�[�W�F�u�����X�V�̊Ԋu��{0}���ɐݒ肵�܂����B�v</summary>
        private const string CT_AUTOUPDATE_SET_FOR = "�����X�V�̊Ԋu��{0}���ɐݒ肵�܂����B";

        /// <summary>���b�Z�[�W�F�u�ŏI�X�V�����F{0}�v</summary>
        private const string CT_LASTTIMEUPDATE = "�ŏI�X�V�����F{0}";

        /// <summary>�`�F�b�N�����b�Z�[�W�u�d�����������擾�̏��������ŃG���[���������܂����B�v</summary>
        private const string MSG_TOTALDAY_INITIALIZE_FAILED = "�d�����������擾�̏��������ŃG���[���������܂����B";

        /// <summary>���b�Z�[�W�u�X�V���ꂽ���׃f�[�^�͂���܂���B�v</summary>
        private const string MSG_NO_UPDATED_DATA = "�X�V���ꂽ���׃f�[�^�͂���܂���B";

        /// <summary>���b�Z�[�W�u�`�F�b�N��ԍX�V�ŃG���[���������܂����B�v</summary>
        private const string MSG_ERROR_ON_UPDATE_CHECK = "�`�F�b�N��ԍX�V�ŃG���[���������܂����B";

        /// <summary>���b�Z�[�W�u ���̃f�[�^���X�V���܂����B�v</summary>
        private const string MSG_SUCCEED_UPDATE = " ���̃f�[�^���X�V���܂����B";

        //-----ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>>
        /// <summary>���b�Z�[�W�u�d�����A���邢�͓��͓�����͂��ĉ������B�v</summary>
        private const string MSG_ALLDATE_NULL = "�d�����A���邢�͓��͓�����͂��ĉ������B";
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMKOU01100U_Construction.XML";
        //----ADD BY ������ on 2012/08/30 for Redmine#31879--------<<<<<<<<

        #endregion // ���b�Z�[�W�萔

        #region �O���b�h�z�F

        /// <summary>�O���b�h �J���[1</summary>
        private readonly Color _rowFiscalColBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>�O���b�h �J���[2</summary>
        private readonly Color _rowFiscalColBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>�O���b�h �����F1</summary>
        private readonly Color _rowFiscalColForeColor1 = Color.FromArgb(255, 255, 255);

        /// <summary>�O���b�h �w�b�_�[�J���[1</summary>
        private readonly Color _headerBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>�O���b�h �w�b�_�[�J���[2</summary>
        private readonly Color _headerBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>�O���b�h �����F1</summary>
        private readonly Color _headerForeColor1 = Color.FromArgb(255, 255, 255);


        // �ԕi�`�[/�s�l�����ׁF�s���N
        /// <summary>�O���b�h �J���[1</summary>
        private readonly Color _type03BackColor1 = Color.FromArgb(253, 235, 216);
        /// <summary>�O���b�h �J���[2</summary>
        private readonly Color _type03BackColor2 = Color.FromArgb(7, 150, 59);
        /// <summary>�O���b�h �����F1</summary>
        private readonly Color _type03ForeColor1 = Color.FromArgb(255, 0, 0);

        // ���d���������͓`�[�F��
        /// <summary>�O���b�h �J���[1</summary>
        private readonly Color _type04BackColor1 = Color.FromArgb(150, 255, 150);
        /// <summary>�O���b�h �J���[2</summary>
        private readonly Color _type04BackColor2 = Color.FromArgb(7, 150, 59);
        /// <summary>�O���b�h �����F1</summary>
        private readonly Color _type04ForeColor1 = Color.FromArgb(0, 150, 0);

        //------ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>
        //U0E�d���`�[�F�F
        /// <summary>�O���b�h �J���[1</summary>
        private readonly Color _type05BackColor1 = Color.FromArgb(216, 235, 253);
        //------ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<

        #endregion // �O���b�h�z�F

        #endregion // �萔

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKOU01101UA()
        {
            InitializeComponent();
            
            // �����ݒ�
            InitializeVariable();
        }

        /// <summary>
        /// �t�H�[���\����C�x���g�i�����t�H�[�J�X�֘A�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKOU01101UA_Shown(object sender, System.EventArgs e)
        {
            // �����t�H�[�J�X�i���_�j
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�֐�

        #region �����z�u

        /// <summary>
        /// �R���g���[���ޏ����z�u
        /// </summary>
        private void InitializeVariable()
        {
            int status = 0;

            // UI�X�L���ݒ�R���g���[��������
            this._controlScreenSkin = new ControlScreenSkin();

            #region �A�N�Z�X�N���X������

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();          // ���_
            this._supplierAcs = new SupplierAcs();              // �d����
            this._dateGetAcs = DateGetAcs.GetInstance();        // ���Аݒ�擾
            this._userSetting = new SupplierCheckOrderSet();    //���[�U�[�ݒ�//ADD BY ������ on 2012/08/30

            #endregion // �A�N�Z�X�N���X������

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // ��ƃR�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // �����_�R�[�h
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ���O�C�����[�U�[�R�[�h
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ���O�C�����[�U�[��

            #region ���ߓ��擾

            _tCalcAcs = TotalDayCalculator.GetInstance();

            // �����擾�O��������
            status = _tCalcAcs.InitializeHisMonthlyAccPay();    // �d�������擾�p��������

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���񂨂�ёO��̎d�����ߓ�/�����擾(���Ɠ��͈قȂ�ꍇ������)
                status = _tCalcAcs.GetHisTotalDayMonthlyAccPay(this._loginSectionCode, out this._prevTotalDay, out this._currentTotalDay, out this._prevTotalMonth, out this._currentTotalMonth);
            }
            else
            {
                // �����������s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_TOTALDAY_INITIALIZE_FAILED, -1, MessageBoxButtons.OK);
            }

            #endregion // ���ߓ��擾

            #region �{�^���C���[�W�ݒ�

            // �C���[�W���X�g���w��(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // �{�^���C���[�W��ݒ�
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SupplierGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // �c�[���o�[�A�C�R��
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 ��QID:8975�Ή�------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            // --- CHG 2009/03/12 ��QID:8975�Ή�------------------------------------------------------<<<<<
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SAVE;

            #endregion // �{�^���C���[�W�ݒ�

            #region ���������N���X�쐬

            this._supplierCheckOrderCndtn = new SupplierCheckOrderCndtn();
                        
            #endregion // ���������N���X�쐬

            #region �R���g���[���X�L���Ή�

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExpandableGroupBox_Condition.Name);
            controlNameList.Add(this.uExpandableGroupBox_Total.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // �R���g���[���X�L���Ή�

            #region �O���b�h�ݒ�

            // �A�N�Z�X�N���X�����������A�f�[�^�Z�b�g���擾
            this._supplierCheckAcs = new SupplierCheckAcs();
            this._dataSet = this._supplierCheckAcs.DataSet;

            // ��ƃR�[�h���Z�b�g���A�e���}�[�N���擾
            this._supplierCheckAcs.EnterpriseCode = this._enterpriseCode;
            this._supplierCheckAcs.SectionCode = this._loginSectionCode;
            this._supplierCheckAcs.GetProfitMark();

            // �O���b�h�ŕ\���Ɏg�p����f�[�^�r���[���쐬
            DataView dViewS = new DataView(this._dataSet.SlipList);
            DataView dViewD = new DataView(this._dataSet.DetailList);

            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Slip.DataSource = dViewS;
            this.uGrid_Detail.DataSource = dViewD;

            // �O���b�h���ݒ�
            InitializeGridColumns(0, this.uGrid_Slip.DisplayLayout.Bands[0].Columns);
            InitializeGridColumns(1, this.uGrid_Detail.DisplayLayout.Bands[0].Columns);

            

            #endregion // �O���b�h�ݒ�

            // ��ʃN���A
            InitializeScreen();

            // �O���b�h�𒲐����Ă���
            //this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            //this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = true;
            //for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            //{
            //    this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            //}
        }

        #endregion // �����z�u

        #region ���̎擾

        #region ���_

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCd">�������鋒�_�R�[�h</param>
        /// <returns>���_��</returns>
        private string GetSectionName(string sectionCd)
        {
            int status = this._secInfoSetAcs.Read(out _sectionInfo, this._enterpriseCode, sectionCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return _sectionInfo.SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion // ���_

        #region �d����

        /// <summary>
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCd">��������d����R�[�h</param>
        /// <returns>�d���於</returns>
        private string GetSupplierName(int supplierCd)
        {
            int status = this._supplierAcs.Read(out _supplier, this._enterpriseCode, supplierCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return _supplier.SupplierSnm;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion // �d����

        #endregion // ���̎擾

        #region ��ʂ̏�����

        /// <summary>
        /// ��ʂ̏�����
        /// </summary>
        private void InitializeScreen()
        {
            // �S�Ă̍��ڂ��N���A
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierSnm.Clear();
            this.tDateEdit_StockDateSt.Clear();
            this.tDateEdit_StockDateEd.Clear();
            this.tDateEdit_InputDaySt.Clear();
            this.tDateEdit_InputDayEd.Clear();
            this.tNedit_SupplierSlipNoSt.Clear();
            this.tNedit_SupplierSlipNoEd.Clear();
            this.tEdit_PartySalesSlipNumSt.Clear();
            this.tEdit_PartySalesSlipNumEd.Clear();

            // ���v���̃��x�����N���A
            this.uLabel_Total_Amount.Text = string.Empty;
            this.uLabel_Total_ConsumeTax.Text = string.Empty;
            this.uLabel_Total_AmountTaxInc.Text = string.Empty;
            this.uLabel_Total_AmountTaxIncAll.Text = string.Empty;
            this.uLabel_Total_Return.Text = string.Empty;
            this.uLabel_Total_ReturnConsumeTax.Text = string.Empty;
            this.uLabel_Total_ReturnTaxInc.Text = string.Empty;
            this.uLabel_Total_SlipCount.Text = string.Empty;
            this.uLabel_Total_DetailCount.Text = string.Empty;

            // ���v�����N���A
            this.uLabel_DisplaySum.Text = string.Empty;
            this.uLabel_CheckSum.Text = string.Empty;
            this.uLabel_LackSum.Text = string.Empty;

            // �f�[�^�Z�b�g���N���A
            this._dataSet.SlipList.Clear();
            this._dataSet.DetailList.Clear();

            // �����l��\��
            this.tEdit_SectionCodeAllowZero.Text = "00";    // 00
            this.tEdit_SectionName.Text = "�S��";           // �S��
            this.tComboEditor_ProcDiv.SelectedIndex = 0;    // ����
            this.tComboEditor_CheckDiv.SelectedIndex = 1;   // ���`�F�b�N
            this.tComboEditor_SlipDiv.SelectedIndex = 0;    // �S��

            //this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode.Trim().PadLeft(2, '0');
            //this.tEdit_SectionName.Text = GetSectionName(this._loginSectionCode);

            // �d�����i�J�n�F�d�����ݏ������J�n��(�O�����+1),�I���F�V�X�e�����t�j
            // ���͓��i�J�n�F��,�I���F�󔒁j// 2008.12.10 modify [8981]
            // �d�����ݏ������J�n�����擾�ł��Ȃ���΃V�X�e�����t
            if (this._prevTotalDay == DateTime.MinValue)
            {
                this.tDateEdit_StockDateSt.SetDateTime(DateTime.Today);
            }
            else
            {
                this.tDateEdit_StockDateSt.SetDateTime(this._prevTotalDay.AddDays(1));
                
            }
            this.tDateEdit_StockDateEd.SetDateTime(DateTime.Today);
            this.tDateEdit_InputDaySt.Clear();
            this.tDateEdit_InputDayEd.Clear();
            
            // �`�F�b�N�{�b�N�X����
            //this.tComboEditor_ProcDiv_ValueChanged(null, null);
            // �f�[�^�Z�b�g����̏ꍇ�̓`�F�b�N�{�b�N�X�͖���
            if (this._dataSet.DetailList.Rows.Count == 0)
            {
                this.uCheckEditor_Slip_CheckAllDaily.Checked = false;
                this.uCheckEditor_Slip_CheckAllDaily.Enabled = false;
                this.uCheckEditor_Detail_CheckAllDaily.Checked = false;
                this.uCheckEditor_Detail_CheckAllDaily.Enabled = false;
                this.uCheckEditor_Slip_CheckAllCalc.Checked = false;
                this.uCheckEditor_Slip_CheckAllCalc.Enabled = false;
                this.uCheckEditor_Detail_CheckAllCalc.Checked = false;
                this.uCheckEditor_Detail_CheckAllCalc.Enabled = false;
            }

            // ���v�\���͗񂪂Ȃ��ꍇ�͕��Ă���
            if (this._dataSet.TotalList.Rows.Count == 0)
            {
                this.uExpandableGroupBox_Total.Expanded = false;
            }

            // ���O�C�����[�U�[���\��
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;
        }

        #endregion // ��ʂ̏�����

        #region �O���b�h�񏉊���

        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        /// <param name="tabNo">0:�`�[ 1:����</param>
        /// <param name="Columns"></param>
        private void InitializeGridColumns(int tabNo, Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // �\���`���̂����Ŏg�p
            string formatCurrency = "#,##0;-#,##0;";
            string formatQuontity = "#,##0.00;-#,##0.00;";
            string formatPercentage = "##0.00;";

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
            }

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            switch (tabNo)
            {
                #region �`�[�^�u
                case 0:
                    {
                        #region ���ʍ���

                        // �����`�F�b�N
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Width = 25;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Caption = "��";
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �����`�F�b�N
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Width = 35;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Caption = "��";
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �s�ԍ�
                        Columns[this._dataSet.SlipList.RowNoColumn.ColumnName].Hidden = true;
                        //Columns[this._dataSet.SlipList.RowNoColumn.ColumnName].Key = "Slip_RowNo";
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �d����
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Caption = "�d����";
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���͓�
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Caption = "���͓�";
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �d��SEQ�ԍ�
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------>>>>>
                        //Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------<<<<<
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Caption = "�d��SEQ�ԍ�";
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        // --- ADD 2009/03/24 ��QID:12789�Ή�------------------------------------------------------>>>>>
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Format = "D9";
                        // --- ADD 2009/03/24 ��QID:12789�Ή�------------------------------------------------------<<<<<

                        // �`�[�ԍ�
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Width = 130;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �ō����z
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Caption = "�ō����z";
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���z
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Caption = "���z";
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �����
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Caption = "�����";
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        #endregion // ���ʍ���

                        #region �ŗL����

                        // �����
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Caption = "�����";
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ����`�[�ԍ�
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Caption = "����`�[�ԍ�";
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���Ӑ�
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�";
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���Ӑ於
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Width = 130;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ於";
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ������z
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "������z";
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ����S���Җ�
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Width = 80;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Caption = "����S���Җ�";
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ����󒍎Җ�
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Width = 80;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Caption = "����󒍎Җ�";
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���㔭�s�Җ�
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Width = 80;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Caption = "���㔭�s�Җ�";
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���}�[�N1
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Width = 150;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Caption = "���}�[�N1";
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���}�[�N2
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Caption = "���}�[�N2";
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �d����
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Caption = "�d����";
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �d���於
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Width = 120;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Caption = "�d���於";
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �ŗL���ڂ̗񕝍��v 1200

                        #endregion // �ŗL����

                        #region �O���b�h�{�̂̐ݒ�

                        // �t�B���^�s��
                        this.uGrid_Slip.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                        // ��̓���ւ��s��
                        this.uGrid_Slip.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;

                        // ��T�C�Y�ύX�s��
                        //this.uGrid_Slip.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;//DEL BY ������ on 2012/08/30
                        this.uGrid_Slip.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;//ADD BY ������ on 2012/08/30

                        // ��ړ��s��
                        //this.uGrid_Slip.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;//DEL BY ������ on 2012/08/30
                        this.uGrid_Slip.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;//ADD BY ������ on 2012/08/30

                        #endregion // �O���b�h�{�̂̐ݒ�

                        break;
                    }
                #endregion // �`�[�^�u

                #region ���׃^�u
                case 1:
                    {
                        #region ���ʍ���

                        // �����`�F�b�N
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Width = 25;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Caption = "��";
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �����`�F�b�N
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Width = 35;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Caption = "��";
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �s�ԍ�
                        Columns[this._dataSet.DetailList.RowNoColumn.ColumnName].Hidden = true;
                        //Columns[this._dataSet.DetailList.RowNoColumn.ColumnName].Key = "Detail_RowNo";
                        Columns[this._dataSet.DetailList.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �d����
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Caption = "�d����";
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���͓�
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Caption = "���͓�";
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �d��SEQ�ԍ�
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------>>>>>
                        //Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------<<<<<
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Caption = "�d��SEQ�ԍ�";
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        // --- ADD 2009/03/24 ��QID:12789�Ή�------------------------------------------------------>>>>>
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Format = "D9";
                        // --- ADD 2009/03/24 ��QID:12789�Ή�------------------------------------------------------<<<<<

                        // �`�[�ԍ�
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Width = 130;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �ō����z
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Caption = "�ō����z";
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���z
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Caption = "���z";
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �����
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Caption = "�����";
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        #endregion // ���ʍ���

                        #region �ŗL����

                        // �i��
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Width = 180;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ����
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Format = formatQuontity;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Caption = "����";
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // BL����
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Width = 60;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����";
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �i��
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Width = 200;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���P��
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Width = 120;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Caption = "���P��"; // 2008.12.10 modify [9002]
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �W�����i
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "�W�����i";
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ���P��
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Width = 110;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "���P��"; // 2008.12.10 modify [9002]
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // ������z
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Width = 110;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "������z";
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �e���}�[�N
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Width = 20;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Caption = "�e��ϰ�";
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �e��
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Width = 120;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Caption = "�e��";
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // �e����
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Width = 60;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Format = formatPercentage;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Caption = "�e����";
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        #endregion // �ŗL����

                        #region �O���b�h�{�̂̐ݒ�

                        // �t�B���^�s��
                        this.uGrid_Detail.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                        // ��̓���ւ��s��
                        this.uGrid_Detail.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;

                        // ��T�C�Y�ύX�s��
                        //this.uGrid_Detail.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;//DEL BY ������ on 2012/08/30
                        this.uGrid_Detail.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;//ADD BY ������ on 2012/08/30

                        // ��ړ��s��
                        //this.uGrid_Detail.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;//DEL BY ������ on 2012/08/30
                        this.uGrid_Detail.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;//ADD BY ������ on 2012/08/30

                        #endregion // �O���b�h�{�̂̐ݒ�

                        break;
                    }
                #endregion // ���׃^�u

                default: break;
            }
        }

        #endregion // �O���b�h�񏉊���

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        private void Search()
        {
            // ���b�Z�[�W���N���A
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;

            // ��ʂ��猟�������N���X���쐬
            GetParameters();

            // �p�����[�^�`�F�b�N
            string errorMsg = string.Empty;
            Control checkControl = null;
            checkControl = CheckParameter(out errorMsg);
            if (checkControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                checkControl.Focus();
                return;
            }
            else
            {
                int recordCount = 0;

                // �f�[�^�Z�b�g���N���A
                this._dataSet.SlipList.Clear();
                this._dataSet.DetailList.Clear();
                this._dataSet.TotalList.Clear();
                // 2008.12.10 add start [9031]
                this._dataSet.Sum.Clear();
                // 2008.12.10 add end [9031]

                // �������s
                this._supplierCheckAcs.Search(this._supplierCheckOrderCndtn, out recordCount);

                if (recordCount > 0)
                {
                    // �\�[�g�����쐬
                    DataView dViewS = (DataView)this.uGrid_Slip.DataSource;
                    DataView dViewD = (DataView)this.uGrid_Detail.DataSource;
                    dViewS.Sort = "RowNo Asc";
                    dViewD.Sort = "RowNo Asc";

                    // ���v�z��\��
                    if (this._dataSet.TotalList.Rows.Count > 0)
                    {
                        DataRow totalRow = this._dataSet.TotalList.Rows[0];

                        // 2008.12.10 modify start [9009]
                        this.uLabel_Total_Amount.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxIncAll.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncAllColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_Return.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");

                        this.uLabel_Total_SlipCount.Text = ((Int32)totalRow[this._dataSet.TotalList.SlipCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_DetailCount.Text = ((Int32)totalRow[this._dataSet.TotalList.DetailCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        // 2008.12.10 modify end [9009]

                        // ���v�z����܂�Ă���ΓW�J
                        if (!this.uExpandableGroupBox_Total.Expanded)
                        {
                            this.uExpandableGroupBox_Total.Expanded = true;
                        }
                    }

                    // �`�F�b�N�{�b�N�X�𒲐�
                    this.tComboEditor_ProcDiv_ValueChanged(null, null);

                    // �S�Ă̍s�Ń`�F�b�N�{�b�N�X�𒲐�����
                    SetupCheckBox_Slip();

                    // ���v�e�[�u�����쐬
                    ResetTotal();

                    // ���v���֐�����\��
                    SetTotal();
                    //ResetTotal();

                    // �s�̔w�i�F�ύX
                    SetRowBackColor();

                    // 2008.12.10 add start [9015]
                    // �`�[�O���b�h�̐擪�s
                    this.uTabControl_Grid.SelectedTab = this.ultraTabPageControl1.Tab;
                    Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Slip.DisplayLayout.Rows[0];
                    Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_slip = this.uGrid_Slip.DisplayLayout.RowScrollRegions[0];
                    rsr_slip.FirstRow = row;
                    rsr_slip.ScrollRowIntoView(row);
                    this.uGrid_Slip.ActiveRow = row;
                    // 2008.12.10 add end [9015]
                }
                else
                {
                    // �Ȃ���΍��v�z��܂肽����
                    this.uExpandableGroupBox_Total.Expanded = false;

                    SetTotal();
                }
            }
        }

        /// <summary>
        /// �����I�����ɍ��v�l��\��
        /// </summary>
        /// <remarks>�������̂ݎg�p �`�F�b�N�X�V�ɂ��Čv�Z��ResetTotal()���g�p����</remarks>
        private void SetTotal()
        {
            if (this._dataSet.Sum.Rows.Count > 0)
            {
                DataRow row = this._dataSet.Sum.Rows[0];

                this.uLabel_DisplaySum.Text = ((Int64)row[this._dataSet.Sum.DisplaySumColumn]).ToString("#,##0;-#,##0;");
                this.uLabel_CheckSum.Text = ((Int64)row[this._dataSet.Sum.CheckSumColumn]).ToString("#,##0;-#,##0;");
                this.uLabel_LackSum.Text = ((Int64)row[this._dataSet.Sum.LackSumColumn.ColumnName]).ToString("#,##0;-#,##0;");
            }
            else
            {
                // 2008.12.10 add start [9031]
                this.uLabel_DisplaySum.Text = string.Empty;
                this.uLabel_CheckSum.Text = string.Empty;
                this.uLabel_LackSum.Text = string.Empty;
                // 2008.12.10 add end [9031]
            }
        }

        #endregion // ����

        #region ���v�z�X�V

        /// <summary>
        /// ���v�z�X�V
        /// </summary>
        private void ResetTotal()
        {
            // �`�F�b�N���ꂽ�s�̍��v�l���擾
            Int64 consValue = 0;
            string condition = string.Empty;
            // --- UPD 2010/10/21 ---------->>>>>
            if (this._procDiv == 0)
            {
                //condition = "CheckBoxDaily = true";
                condition = "CheckBoxDaily = true AND (CheckBoxDailyStatus = 0 OR CheckBoxDailyStatus = 1)";
            }
            else
            {
                //condition = "CheckBoxCalc = true";
                condition = "CheckBoxCalc = true AND (CheckBoxCalcStatus = 0 OR CheckBoxCalcStatus = 1)";

            }

            //foreach (DataRow row in this._dataSet.DetailList.Select(condition))
            //{
            //    // --- CHG 2009/02/24 ��QID:11877�Ή�------------------------------------------------------>>>>>
            //    //consValue += (Int64)row[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName];
            //    consValue += (Int64)row[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName];
            //    // --- CHG 2009/02/24 ��QID:11877�Ή�------------------------------------------------------<<<<<
            //}

            foreach (DataRow row in this._dataSet.SlipList.Select(condition))
            {
                consValue += (Int64)row[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName];
            }
            // --- UPD 2010/10/21 ----------<<<<<

            // �f�[�^�Z�b�g���X�V
            DataRow sumRow = this._dataSet.Sum.Rows[0];
            // 2008.12.10 modify start [9032]
            Int64 dispSum = (Int64)sumRow[this._dataSet.Sum.DisplaySumColumn.ColumnName];
            sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = consValue;
            sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = dispSum - consValue;
            // 2008.12.10 modify end [9032]

            // �\���X�V
            SetTotal();
        }

        /// <summary>
        /// ���v�z�X�V
        /// </summary>
        // --- UPD 2010/10/21 ---------->>>>>
        //private void ResetTotal(DataRow row, bool check)
        private void ResetTotal(DataRow row, bool check, int supplierSlipNo)
        {
            DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
            int count = 0;
            Int64 consValue = 0;
            bool allFlag = true;
            if (rows.Length >= 1)
            {
                foreach (DataRow row2 in rows)
                {
                    // �I���`�F�b�N
                    if (this._procDiv == 0)
                    {
                        if ((bool)row2[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] == false)
                        {
                            allFlag = false;
                            count++;
                        }
                    }
                    else
                    {
                        if ((bool)row2[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] == false)
                        {
                            allFlag = false;
                            count++;
                        }
                    }
                }

                if (!allFlag && check)
                {
                    return;
                }

                if (count > 1)
                {
                    return;
                }

                DataRow[] slipRows = this._dataSet.Tables["SlipList"].Select(String.Format("SupplierSlipNo = {0}", supplierSlipNo.ToString()));

                if (slipRows.Length == 1)
                {
                    DataRow slipRow = slipRows[0];
                    consValue = (Int64)slipRow[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName];
                }
            }
            // --- UPD 2010/10/21 ----------<<<<<

            // �`�F�b�N���ꂽ�s�̒l���擾
            //Int64 consValue = (Int64)row[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName]; // DEL 2010/10/21
            if (!check) consValue = consValue * -1;

            // �f�[�^�Z�b�g���X�V
            DataRow sumRow = this._dataSet.Sum.Rows[0];
            Int64 checkSum = (Int64)sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName];
            Int64 lackSum = (Int64)sumRow[this._dataSet.Sum.LackSumColumn.ColumnName];
            sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = checkSum + consValue;
            sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = lackSum - consValue;

            // �\���X�V
            SetTotal();
        }

        #endregion // ���v�z�X�V

        #region �X�V

        /// <summary>
        /// �X�V����
        /// </summary>
        private void UpdateCheck()
        {
            DataRow[] rows = null;
            // �X�V�ΏۂƂȂ�̂́A���׃e�[�u���Ń`�F�b�N��Ԃ��X�V���ꂽ���̂̂�
            if (this._procDiv == 0)
            {
                rows = this._dataSet.DetailList.Select(String.Format("{0} <> {1}", 
                                                            this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName,
                                                            this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName));
            }
            else
            {
                rows = this._dataSet.DetailList.Select(String.Format("{0} <> {1}",
                                            this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName,
                                            this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName));

            }

            // �X�V�f�[�^�Ȃ�
            if (rows.Length == 0)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_NO_UPDATED_DATA, -1, MessageBoxButtons.OK);
                return;
            }
            else
            {
                int count = 0;
                if (this._supplierCheckAcs == null)
                {
                    this._supplierCheckAcs = new SupplierCheckAcs();
                }
                this._supplierCheckAcs.EnterpriseCode = this._enterpriseCode;

                int status = this._supplierCheckAcs.Update(this._procDiv, out count);
                // --- CHG 2009/02/02 �r�����䏈���ǉ�------------------------------------------------------>>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                //        MSG_ERROR_ON_UPDATE_CHECK, -1, MessageBoxButtons.OK);
                //    return;
                //}
                //else
                //{
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                //        count.ToString() + MSG_SUCCEED_UPDATE, -1, MessageBoxButtons.OK);
                //}
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                          count.ToString() + MSG_SUCCEED_UPDATE, -1, MessageBoxButtons.OK);
                            break;
                        }
                    // ��ƃ��b�N�^�C���A�E�g
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "PMKOU01101U",
                                          "UpdateCheck",
                                          TMsgDisp.OPE_UPDATE,
                                          "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n" +
                                          "�����X�V���A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                          "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                          status,
                                          this._supplierCheckAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return;
                        }
                    // ���_���b�N�^�C���A�E�g
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "PMKOU01101U",
                                          "UpdateCheck",
                                          TMsgDisp.OPE_UPDATE,
                                          "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n" +
                                          "���X�V���A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B�B" + "\r\n" +
                                          "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                          status,
                                          this._supplierCheckAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return;
                        }
                    // �q�Ƀ��b�N�^�C���A�E�g
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "PMKOU01101U",
                                          "UpdateCheck",
                                          TMsgDisp.OPE_UPDATE,
                                          "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n" +
                                          "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                          "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                          status,
                                          this._supplierCheckAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                          MSG_ERROR_ON_UPDATE_CHECK, -1, MessageBoxButtons.OK);
                            return;
                        }
                }
                // --- CHG 2009/02/02 �r�����䏈���ǉ�------------------------------------------------------<<<<<


                #region �����Ď��s

                // �X�V�����������猟�����Ď��s(�X�V���ԁE���`�F�b�N��ԗ���X�V���邽��)

                // ��ʂ��猟�������N���X���쐬
                GetParameters();

                // �f�[�^�Z�b�g���N���A
                this._dataSet.SlipList.Clear();
                this._dataSet.DetailList.Clear();
                this._dataSet.TotalList.Clear();
                this._dataSet.Sum.Clear();

                // �������s
                int recordCount = 0;
                this._supplierCheckAcs.Search(this._supplierCheckOrderCndtn, out recordCount);

                if (recordCount > 0)
                {
                    // �\�[�g�����쐬
                    DataView dViewS = (DataView)this.uGrid_Slip.DataSource;
                    DataView dViewD = (DataView)this.uGrid_Detail.DataSource;
                    dViewS.Sort = "RowNo Asc";
                    dViewD.Sort = "RowNo Asc";

                    // ���v�z��\��
                    if (this._dataSet.TotalList.Rows.Count > 0)
                    {
                        DataRow totalRow = this._dataSet.TotalList.Rows[0];

                        this.uLabel_Total_Amount.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxIncAll.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncAllColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_Return.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");

                        this.uLabel_Total_SlipCount.Text = ((Int32)totalRow[this._dataSet.TotalList.SlipCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_DetailCount.Text = ((Int32)totalRow[this._dataSet.TotalList.DetailCountColumn.ColumnName]).ToString("#,##0;-#,##0;");

                        // ���v�z����܂�Ă���ΓW�J
                        if (!this.uExpandableGroupBox_Total.Expanded)
                        {
                            this.uExpandableGroupBox_Total.Expanded = true;
                        }
                    }

                    // �`�F�b�N�{�b�N�X�𒲐�
                    this.tComboEditor_ProcDiv_ValueChanged(null, null);

                    // �S�Ă̍s�Ń`�F�b�N�{�b�N�X�𒲐�����
                    SetupCheckBox_Slip();

                    // ���v�e�[�u�����쐬
                    ResetTotal();

                    // ���v���֐�����\��
                    SetTotal();

                    // �s�̔w�i�F�ύX
                    SetRowBackColor();

                    // �`�[�O���b�h�̐擪�s
                    //this.uTabControl_Grid.SelectedTab = this.ultraTabPageControl1.Tab;
                    //Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Slip.DisplayLayout.Rows[0];
                    //Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_slip = this.uGrid_Slip.DisplayLayout.RowScrollRegions[0];
                    //rsr_slip.FirstRow = row;
                    //rsr_slip.ScrollRowIntoView(row);
                    //this.uGrid_Slip.ActiveRow = row;
                }

                #endregion // �����Ď��s
            }

        }

        #endregion // �X�V

        #region ��ʁ��p�����[�^�쐬

        /// <summary>
        /// ��ʁ��p�����[�^�쐬
        /// </summary>
        private void GetParameters()
        {
            this._supplierCheckOrderCndtn = new SupplierCheckOrderCndtn();

            // ��ƃR�[�h
            this._supplierCheckOrderCndtn.EnterpriseCode = this._enterpriseCode;

            // �����敪(Not Null)
            this._supplierCheckOrderCndtn.ProcDiv = (int)this.tComboEditor_ProcDiv.SelectedItem.DataValue;

            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("0") ||
                this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("00"))
            {
                this._supplierCheckOrderCndtn.SectionCode = string.Empty;
            }
            else if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                this._supplierCheckOrderCndtn.SectionCode = string.Empty;
            }
            else
            {
                this._supplierCheckOrderCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            }

            // �d����R�[�h
            this._supplierCheckOrderCndtn.SupplierCd = this.tNedit_SupplierCd.GetInt();

            // �`�[�敪
            if (this.tComboEditor_SlipDiv.SelectedIndex > -1)
            {
                this._supplierCheckOrderCndtn.SlipDiv = (int)this.tComboEditor_SlipDiv.SelectedItem.DataValue;
            }

            // �`�F�b�N�敪
            if (this.tComboEditor_CheckDiv.SelectedIndex > -1)
            {
                this._supplierCheckOrderCndtn.CheckDiv = (int)this.tComboEditor_CheckDiv.SelectedItem.DataValue;
            }

            // �d�����J�n
            this._supplierCheckOrderCndtn.St_StockDate = this.tDateEdit_StockDateSt.GetLongDate();

            // �d�����I��
            this._supplierCheckOrderCndtn.Ed_StockDate = this.tDateEdit_StockDateEd.GetLongDate();

            // ���͓��J�n
            this._supplierCheckOrderCndtn.St_InputDay = this.tDateEdit_InputDaySt.GetLongDate();

            // ���͓��I��
            this._supplierCheckOrderCndtn.Ed_InputDay = this.tDateEdit_InputDayEd.GetLongDate();

            // �d��SEQ�ԍ��J�n
            this._supplierCheckOrderCndtn.St_SupplierSlipNo = this.tNedit_SupplierSlipNoSt.GetInt();

            // �d��SEQ�ԍ��I��
            this._supplierCheckOrderCndtn.Ed_SupplierSlipNo = this.tNedit_SupplierSlipNoEd.GetInt();

            // �`�[�ԍ��J�n
            if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumSt.Text.Trim()))
            {
                this._supplierCheckOrderCndtn.St_PartySaleSlipNum = this.tEdit_PartySalesSlipNumSt.Text.Trim();
            }
            else
            {
                this._supplierCheckOrderCndtn.St_PartySaleSlipNum = string.Empty;
            }

            // �`�[�ԍ��I��
            if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumEd.Text.Trim()))
            {
                this._supplierCheckOrderCndtn.Ed_PartySaleSlipNum = this.tEdit_PartySalesSlipNumEd.Text.Trim();
            }
            else
            {
                this._supplierCheckOrderCndtn.Ed_PartySaleSlipNum = string.Empty;
            }
        }

        #endregion // ��ʁ��p�����[�^�쐬

        #region �p�����[�^�`�F�b�N

        /// <summary>
        /// �p�����[�^�`�F�b�N�֐�
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private Control CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // �p�����[�^���K�{�̂��̂��`�F�b�N

            // �����敪
            if (this._supplierCheckOrderCndtn.ProcDiv != 0 && this._supplierCheckOrderCndtn.ProcDiv != 1)
            {
                errorMsg = CT_SLIP_DIV_NOT_SELECTED;
                return this.tComboEditor_ProcDiv;
            }

            // 2008.12.10 add start [8986]
            // �d��SEQ�ԍ��̑召�`�F�b�N
            if (this.tNedit_SupplierSlipNoEd.GetInt() > 0)
            {
                if (this.tNedit_SupplierSlipNoSt.GetInt() > this.tNedit_SupplierSlipNoEd.GetInt())
                {
                    errorMsg = CT_SUPPSLIPNOED_MUSTBE_LARGE;
                    return this.tNedit_SupplierSlipNoEd;
                }
            }
            // 2008.12.10 add end [8986]

            //// 2008.12.10 add start [8987]
            //// �`�[�ԍ��̑召�`�F�b�N
            //Double dSlipSt = 0;
            //Double dSlipEd = 0;
            //if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumSt.Text.Trim()))
            //{
            //    try
            //    {
            //        dSlipSt = Double.Parse(this.tEdit_PartySalesSlipNumSt.Text.Trim());
            //    }
            //    catch
            //    {
            //        errorMsg = CT_SLIPNO_NOT_NUMERIC;
            //        return this.tEdit_PartySalesSlipNumSt;
            //    }
            //}

            //if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumEd.Text.Trim()))
            //{
            //    try
            //    {
            //        dSlipEd = Double.Parse(this.tEdit_PartySalesSlipNumEd.Text.Trim());
            //    }
            //    catch
            //    {
            //        errorMsg = CT_SLIPNO_NOT_NUMERIC;
            //        return this.tEdit_PartySalesSlipNumEd;
            //    }
            //}

            //// �������͂���Ă���ꍇ�̂ݔ�r(�Е��̂ݓ��͂�OK)
            //if (dSlipEd > 0 && dSlipSt > 0 && dSlipEd - dSlipSt < 0)
            //{
            //    errorMsg = CT_SLIPNOED_MUSTBE_LARGE;
            //    return this.tEdit_PartySalesSlipNumEd;
            //}
            //// 2008.12.10 add end [8987]
            if ((!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumSt.Text.Trim())) &&
                (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumEd.Text.Trim())))
            {
                string st = this.tEdit_PartySalesSlipNumSt.Text.Trim();
                string ed = this.tEdit_PartySalesSlipNumEd.Text.Trim();

                if (String.Compare(st, ed) > 0)
                {
                    errorMsg = "�`�[�ԍ��͈͎̔w�肪�s���ł��B";
                    return this.tEdit_PartySalesSlipNumEd;
                }
            }

            //-----ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>>
            if (this.tDateEdit_StockDateSt.GetLongDate() == 0
                && this.tDateEdit_StockDateEd.GetLongDate() == 0
                && this.tDateEdit_InputDaySt.GetLongDate() == 0
                && this.tDateEdit_InputDayEd.GetLongDate() == 0)
            {
                errorMsg = MSG_ALLDATE_NULL;
                return this.tDateEdit_StockDateSt;
            }
            //-----ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<<

            // 2008.12.10 add start [8979]
            // ���t�̃`�F�b�N
            if (this.tDateEdit_StockDateSt.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_StockDateSt.GetDateTime()))
            {
                errorMsg = "�d����(�J�n)" + CT_DATE_INVALID;
                return this.tDateEdit_StockDateSt;
            }

            if (this.tDateEdit_StockDateEd.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_StockDateEd.GetDateTime()))
            {
                errorMsg = "�d����(�I��)" + CT_DATE_INVALID;
                return this.tDateEdit_StockDateEd;
            }

            // --- CHG 2009/02/25 ��QID:7882�Ή�------------------------------------------------------>>>>>
            //if (this.tDateEdit_InputDaySt.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_InputDaySt.GetDateTime()))
            //{
            //    errorMsg = "���͓�(�J�n)" + CT_DATE_INVALID;
            //    return this.tDateEdit_InputDaySt;
            //}

            //if (this.tDateEdit_InputDayEd.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_InputDayEd.GetDateTime()))
            //{
            //    errorMsg = "���͓�(�I��)" + CT_DATE_INVALID;
            //    return this.tDateEdit_InputDayEd;
            //}
            DateGetAcs.CheckDateResult cdResult;

            if (this.tDateEdit_InputDaySt.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_InputDaySt, true);
                //if (cdResult == DateGetAcs.CheckDateResult.ErrorOfNoInput) // DEL 2009/04/03
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid) // ADD 2009/04/03
                {
                    errorMsg = "���͓�(�J�n)" + CT_DATE_INVALID;
                    return this.tDateEdit_InputDaySt;
                }
            }

            if (this.tDateEdit_InputDayEd.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_InputDayEd, true);
                //if (cdResult == DateGetAcs.CheckDateResult.ErrorOfNoInput) // DEL 2009/04/03
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid) // ADD 2009/04/03
                {
                    errorMsg = "���͓�(�I��)" + CT_DATE_INVALID;
                    return this.tDateEdit_InputDayEd;
                }
            }
            // --- CHG 2009/02/25 ��QID:7882�Ή�------------------------------------------------------<<<<<
            // 2008.12.10 add end [8979]

            // 2008.12.16 add start [8987]

            // �������͂���Ă���ꍇ�̂ݔ�r(�Е��̂ݓ��͂�OK)
            int startDate = this.tDateEdit_StockDateSt.GetLongDate();
            int endDate = this.tDateEdit_StockDateEd.GetLongDate();
            
            // --- DEL 2009/04/03 -------------------------------->>>>>
            //if (startDate == 0 && endDate == 0)
            //{
            //    errorMsg = CT_STOCKDATE_NOT_INPUT;
            //    return this.tDateEdit_StockDateSt;
            //}
            // --- DEL 2009/04/03 --------------------------------<<<<<

            // ���t�̑召�`�F�b�N
            if (startDate != 0 && endDate != 0) // ADD 2009/04/03
            {
                if (startDate - endDate > 0)
                {
                    errorMsg = CT_DATEED_MUSTBE_LATER;
                    return this.tDateEdit_StockDateSt;
                }
            }

            // --- ADD 2009/04/03 -------------------------------->>>>>
            // ���͓��̑召�`�F�b�N
            if (this.tDateEdit_InputDaySt.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_InputDayEd.GetDateTime() != DateTime.MinValue)
            {
                if (this.tDateEdit_InputDaySt.GetLongDate() > this.tDateEdit_InputDayEd.GetLongDate())
                {
                    errorMsg = CT_DATEED_MUSTBE_LATER;
                    return this.tDateEdit_InputDaySt;
                }
            }
            // --- ADD 2009/04/03 --------------------------------<<<<<

            // --- DEL 2009/02/25 ��QID:7882�Ή�------------------------------------------------------>>>>>
            //startDate = this.tDateEdit_InputDaySt.GetLongDate();
            //endDate = this.tDateEdit_InputDayEd.GetLongDate();
            //if (startDate - endDate > 0)
            //{
            //    errorMsg = CT_DATEED_MUSTBE_LATER;
            //    return this.tDateEdit_InputDaySt;
            //}
            // --- DEL 2009/02/25 ��QID:7882�Ή�------------------------------------------------------<<<<<
            // 2008.12.16 add end [8987]


            return null;
        }

        #endregion // �p�����[�^�`�F�b�N

        #region �s�̔w�i�F�ύX����

        /// <summary>
        /// �s�̔w�i�F�ύX����
        /// </summary>
        private void SetRowBackColor()
        {
            int rowNo = 0;
            string salesDateString = string.Empty;
            int supplierSlipCd = 0;
            //------ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>
            int wayToOrder = 0;
            string columnName_WayToOrder = string.Empty;
            //------ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<
            string columnName_SalesDate = string.Empty;       // ������t��ێ����Ă����
            string columnName_SupplierSlipCd = string.Empty;       // �d���敪��ێ����Ă����
            //------ADD BY �� �� on 2012/10/09 for Redmine#31879------->>>>>>>
            int debitNoteDiv = 0;
            string columnName_DebitNoteDiv = string.Empty;
            //------ADD BY �� �� on 2012/10/09 for Redmine#31879-------<<<<<<<

            // �`�[�^�u�̑S�Ă̍s�𒲐�
            columnName_SalesDate = this._dataSet.SlipList.SalesDateStringColumn.ColumnName;
            columnName_SupplierSlipCd = this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName;
            columnName_WayToOrder = this._dataSet.SlipList.WayToOrderColumn.ColumnName;//ADD BY ������ on 2012/08/30 for Redmine#31879
            columnName_DebitNoteDiv = this._dataSet.SlipList.DebitNoteDivColumn.ColumnName;//ADD BY �� �� on 2012/10/09 for Redmine#31879
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
            {
                // UI�s����f�[�^�Z�b�g�s����肵�A�e�s�̃`�F�b�N�{�b�N�X��Ԃ��擾
                rowNo = (int)(gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName]).Value;
                DataRow row = this._dataSet.Tables["SlipList"].Rows.Find(rowNo);
                if (row != null)
                {
                    // ����������݂���Δ��d���������͓`�[
                    salesDateString = (string)row[columnName_SalesDate];
                    if (!String.IsNullOrEmpty(salesDateString))
                    {
                        gridRow.Appearance.BackColor = this._type04BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type04BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type04ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }

                    // �d���敪��[20]�ł���Εԕi�`�[(�ԕi�`�[���D��Ȃ̂ŏ㏑������܂�)
                    supplierSlipCd = (int)row[columnName_SupplierSlipCd];
                    debitNoteDiv = (int)row[columnName_DebitNoteDiv];//ADD BY �� �� on 2012/10/09 for Redmine#31879
                    //if (supplierSlipCd == 20)//DEL BY �� �� on 2012/10/09 for Redmine#31879
                    if (supplierSlipCd == 20 || debitNoteDiv == 1)//�ԕi�Ɛԓ`�̏ꍇ ADD BY �� �� on 2012/10/09 for Redmine#31879
                    {
                        gridRow.Appearance.BackColor = this._type03BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type03BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type03ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }
                    else // ADD BY �� �� on 2012/09/27 for UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���
                    { // ADD BY �� �� on 2012/09/27 for UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���
                        //------ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>
                        wayToOrder = Convert.ToInt32(row[columnName_WayToOrder]);
                        if (wayToOrder == 2)
                        {
                            gridRow.Appearance.BackColor = _type05BackColor1;
                        }
                        //------ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<
                    } // ADD BY �� �� on 2012/09/27 for UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���
                }
            }

            // ���׃^�u�̑S�Ă̍s�𒲐�
            columnName_SalesDate = this._dataSet.DetailList.SalesDateStringColumn.ColumnName;
            columnName_SupplierSlipCd = this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName;
            columnName_WayToOrder = this._dataSet.DetailList.WayToOrderColumn.ColumnName;//ADD BY ������ on 2012/08/30 for Redmine#31879
            columnName_DebitNoteDiv = this._dataSet.DetailList.DebitNoteDivColumn.ColumnName;//ADD BY �� �� on 2012/10/09 for Redmine#31879
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
            {
                // UI�s����f�[�^�Z�b�g�s����肵�A�e�s�̃`�F�b�N�{�b�N�X��Ԃ��擾
                rowNo = (int)(gridRow.Cells[this._dataSet.DetailList.RowNoColumn.ColumnName]).Value;
                DataRow row = this._dataSet.Tables["DetailList"].Rows.Find(rowNo);
                if (row != null)
                {
                    // ����������݂���Δ��d���������͓`�[
                    //if (row[columnName_SalesDate] != DBNull.Value)
                    //{
                    salesDateString = (string)row[columnName_SalesDate];
                    //}
                    if (!String.IsNullOrEmpty(salesDateString))
                    {
                        gridRow.Appearance.BackColor = this._type04BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type04BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type04ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }

                    // �d���敪��[20]�ł���Εԕi�`�[(�ԕi�`�[���D��Ȃ̂ŏ㏑������܂�)
                    supplierSlipCd = (int)row[columnName_SupplierSlipCd];
                    debitNoteDiv = (int)row[columnName_DebitNoteDiv];//ADD BY �� �� on 2012/10/09 for Redmine#31879
                    //if (supplierSlipCd == 20)//DEL BY �� �� on 2012/10/09 for Redmine#31879
                    if (supplierSlipCd == 20 || debitNoteDiv == 1)//�ԕi�Ɛԓ`�̏ꍇ ADD BY �� �� on 2012/10/09 for Redmine#31879
                    {
                        gridRow.Appearance.BackColor = this._type03BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type03BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type03ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }
                    else // ADD BY �� �� on 2012/09/27 for UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���
                    { // ADD BY �� �� on 2012/09/27 for UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���
                        //------ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>
                        wayToOrder = Convert.ToInt32(row[columnName_WayToOrder]);
                        if (wayToOrder == 2)
                        {
                            gridRow.Appearance.BackColor = _type05BackColor1;
                        }
                        //------ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<
                    } // ADD BY �� �� on 2012/09/27 for UOE�ԕi�̏ꍇ�͔w�i�F��Ԃɂ���
                }
            }
        }

        #endregion // �s�̔w�i�F�ύX����

        #region �`�F�b�N�{�b�N�X����

        #region �f�[�^�����ƂɃ`�F�b�N�{�b�N�X�𒲐�

        /// <summary>
        /// �f�[�^�����ƂɃ`�F�b�N�{�b�N�X�𒲐�
        /// </summary>
        private void SetupCheckBox_Slip()
        {
            int rowNo = 0;
            int checkBoxStatus = 0;
            string columnName_CheckBoxStatus = string.Empty;       // �`�F�b�N�{�b�N�X��Ԓl��ێ����Ă����
            string columnName_CheckBox = string.Empty;             // �`�F�b�N�{�b�N�X�̂����

            // �񖼂��擾
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
            }

            // �`�[�^�u�̑S�Ă̍s�𒲐�
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
            {
                // UI�s����f�[�^�Z�b�g�s����肵�A�e�s�̃`�F�b�N�{�b�N�X��Ԃ��擾
                rowNo = (int)(gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName]).Value;
                DataRow row = this._dataSet.Tables["SlipList"].Rows.Find(rowNo);
                if (row != null)
                {
                    checkBoxStatus = (int)row[columnName_CheckBoxStatus];

                    // �`�F�b�N�{�b�N�X�̃X�e�[�^�X�l���A��ʏ�̏�Ԃ��v�Z
                    // ���`�F�b�N�{�b�N�X�X�e�[�^�X�̓N���b�N���ɓ��I�ɕύX�����
                    switch (checkBoxStatus)
                    {
                        // �`�F�b�N�Ȃ�, �`�F�b�N����
                        case CT_CHECKBOXSTATUS_UNCHECK:
                        case CT_CHECKBOXSTATUS_CHECK:
                            {
                                // �A���t�@���x����ύX(0:�N����)
                                gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = 0;
                                break;
                            }
                        // �s�N��
                        case CT_CHECKBOXSTATUS_UNCLEAR:
                            {
                                // �A���t�@���x����ύX(128:�s�N����)
                                gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = CT_UNCLEAR_CHECKBOX_ALPHA;
                                break;
                            }

                        default: break;
                    }
                }
            }
        }

        /// <summary>
        /// �f�[�^�����ƂɃ`�F�b�N�{�b�N�X�𒲐�(�P�s)
        /// </summary>
        /// <param name="row">�s�I�u�W�F�N�g</param>
        private void SetupCheckBox_Slip(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            int rowNo = 0;
            int checkBoxStatus = 0;

            string columnName_CheckBoxStatus = string.Empty;       // �`�F�b�N�{�b�N�X��Ԓl��ێ����Ă����
            string columnName_CheckBox = string.Empty;             // �`�F�b�N�{�b�N�X�̂����

            // �񖼂��擾
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
            }

            // UI�s����f�[�^�Z�b�g�s����肵�A�`�F�b�N�{�b�N�X��Ԃ��擾
            rowNo = (int)(gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName]).Value;
            DataRow row = this._dataSet.Tables["SlipList"].Rows.Find(rowNo);
            if (row != null)
            {
                checkBoxStatus = (int)row[columnName_CheckBoxStatus];

                // �`�F�b�N�{�b�N�X�̃X�e�[�^�X�l���A��ʏ�̏�Ԃ��v�Z
                // ���`�F�b�N�{�b�N�X�X�e�[�^�X�̓N���b�N���ɓ��I�ɕύX�����
                switch (checkBoxStatus)
                {
                    // �`�F�b�N�Ȃ�, �`�F�b�N����
                    case CT_CHECKBOXSTATUS_UNCHECK:
                    case CT_CHECKBOXSTATUS_CHECK:
                        {
                            // �A���t�@���x����ύX(0:�N����)
                            gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = 0;
                            break;
                        }
                    // �s�N��
                    case CT_CHECKBOXSTATUS_UNCLEAR:
                        {
                            // �A���t�@���x����ύX(128:�s�N����)
                            gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = CT_UNCLEAR_CHECKBOX_ALPHA;
                            break;
                        }

                    default: break;
                }
            }
        }

        #endregion // �f�[�^�����ƂɃ`�F�b�N�{�b�N�X�𒲐�

        #region �`�F�b�N�{�b�N�X�N���b�N�C�x���g(�`�[)

        /// <summary>
        /// �`�F�b�N�{�b�N�X�N���b�N�C�x���g(�`�[)
        /// </summary>
        /// <param name="row"></param>
        private void OnClickSlipGridCheck(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            string columnName_CheckBoxStatus = string.Empty;       // �`�F�b�N�{�b�N�X��Ԓl��ێ����Ă����
            string columnName_CheckBox = string.Empty;             // �`�F�b�N�{�b�N�X�̂����

            // �񖼂��擾
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
            }

            // �`�F�b�N�{�b�N�X�̏�Ԃ��擾
            bool check;
            check = (bool)gridRow.Cells[columnName_CheckBox].Value;

            // �s�N���X�e�[�^�X�̏�Ԃ��擾
            int status;
            status = (int)gridRow.Cells[columnName_CheckBoxStatus].Value;

            // �N���b�N���ꂽ�s�̃`�F�b�N�{�b�N�X�𔽓]
            DataRow rowSlip = this._dataSet.Tables["SlipList"].Rows.Find((int)gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName].Value);
            rowSlip[columnName_CheckBox] = !check;

            // �X�e�[�^�X���X�V
            if (!check)
            {
                status = 0;
            }
            else
            {
                status = 1;
            }
            rowSlip[columnName_CheckBoxStatus] = status;

            // �d��SEQ�ԍ�������̖��ׂ��`�F�b�N/�`�F�b�N����
            // ���ׂ͎d��SEQ�ԍ������ꂾ�ƕ\������Ȃ��̂Ŏd��SEQ�ԍ�(�����p)�̗����������
            if (status != 2)
            {
                int supplierSlipNo = (int)gridRow.Cells[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Value;
                DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
                foreach (DataRow row in rows)
                {
                    row[columnName_CheckBox] = !check;
                }
            }
            else
            {
                // �s�N���̏ꍇ�͂�����ƈقȂ�
                int supplierSlipNo = (int)gridRow.Cells[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Value;
                DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
                foreach (DataRow row in rows)
                {
                    // �`�F�b�N�̏�Ԃ���эX�V����/���Ȃ�
                    // �`�[ �� �� �~ �~ (���N���b�N���ꂽ�u�Ԃ̃`�F�b�N���)
                    // ���� �� �~ �� �~
                    // �X�V �� �~ �~ ��
                    if ((bool)row[columnName_CheckBox] == check)
                    {
                        row[columnName_CheckBox] = !check;
                    }
                }
            }
            // �`�F�b�N�{�b�N�X�̒l���C��
            SetupCheckBox_Slip(gridRow);

            // ���v���̍X�V
            ResetTotal();
        }

        #endregion // �`�F�b�N�{�b�N�X�N���b�N�C�x���g(�`�[)

        #region �`�F�b�N�{�b�N�X�N���b�N�C�x���g(����)

        /// <summary>
        /// �`�F�b�N�{�b�N�X�N���b�N�C�x���g(����)
        /// </summary>
        /// <param name="row"></param>
        private void OnClickDetailGridCheck(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            string columnName_Detail_CheckBox = string.Empty;      // ����)�`�F�b�N�{�b�N�X�̂����
            string columnName_CheckBoxStatus = string.Empty;       // �`�[)�`�F�b�N�{�b�N�X��Ԓl��ێ����Ă����
            string columnName_CheckBox = string.Empty;             // �`�[)�`�F�b�N�{�b�N�X�̂����

            // �񖼂��擾
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName;
            }

            // �`�F�b�N�{�b�N�X�̏�Ԃ��擾
            bool check = (bool)gridRow.Cells[columnName_Detail_CheckBox].Value;

            // �N���b�N���ꂽ�s�̃`�F�b�N�{�b�N�X�𔽓]
            DataRow rowValue = this._dataSet.Tables["DetailList"].Rows.Find((int)gridRow.Cells[this._dataSet.DetailList.RowNoColumn.ColumnName].Value);
            rowValue[columnName_Detail_CheckBox] = !check;

            // --- UPD 2010/10/21 ---------->>>>>
            // ���v�z�X�V
            //ResetTotal(rowValue, !check);
            ResetTotal(rowValue, !check, (int)gridRow.Cells[this._dataSet.DetailList.SupplierSlipNoKeyColumn.ColumnName].Value);
            // --- UPD 2010/10/21 ----------<<<<<

            // �d��SEQ�ԍ�������̖��ׂ�S�Ď擾���A�`�[�P�ʂ̃`�F�b�N��Ԃ��v�Z
            // ���ׂă`�F�b�N     ���N����,�`�F�b�N
            // ���ׂă`�F�b�N�Ȃ� ���N����,���`�F�b�N
            // �ꕔ�`�F�b�N       ���s�N����,�`�F�b�N
            bool checkSlip;
            int status = 0;

            int supplierSlipNo = (int)gridRow.Cells[this._dataSet.DetailList.SupplierSlipNoKeyColumn.ColumnName].Value;
            DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
            bool checkFirstRow = true;
            int count = 0;
            if (rows.Length > 1)
            {
                foreach (DataRow row in rows)
                {
                    // ��s�ڂ̃`�F�b�N�{�b�N�X����ƂȂ�
                    if (count == 0)
                    {
                        checkFirstRow = (bool)row[columnName_Detail_CheckBox];

                        // �`�F�b�N����ɏ����l��ύX
                        if (checkFirstRow) status = 1;
                    }
                    else
                    {
                        // �ꌏ�ł��قȂ�Εs�N����
                        if ((bool)row[columnName_Detail_CheckBox] != checkFirstRow)
                        {
                            status = 2;
                            break;
                        }
                    }
                    count++;
                }

                // �X�e�[�^�X�ɂ��`�F�b�N��Ԃ�����
                if (status == 0) // �`�F�b�N���ꂽ���̂��ꌏ���Ȃ�
                {
                    checkSlip = false;
                }
                else
                {
                    checkSlip = true;
                }
            }
            else
            {
                // 1�������Ȃ��ꍇ�͖��ׂ̃`�F�b�N���=�`�[�̃`�F�b�N���
                checkSlip = !check;
                if (checkSlip)
                {
                    status = 1;
                }
            }

            // �`�[�̃`�F�b�N�{�b�N�X��ύX
            DataRow[] slipRows = this._dataSet.Tables["SlipList"].Select(String.Format("SupplierSlipNo = {0}", supplierSlipNo.ToString()));

            if (slipRows.Length == 1)
            {
                DataRow slipRow = slipRows[0];
                slipRow[columnName_CheckBox] = checkSlip;
                slipRow[columnName_CheckBoxStatus] = status;

                // �`�F�b�N�{�b�N�X�F�ύX
                SetupCheckBox_Slip();
            }
        }

        #endregion // �`�F�b�N�{�b�N�X�N���b�N�C�x���g(����)

        #region �S�ă`�F�b�N�N���b�N�C�x���g

        /// <summary>
        /// ����(�S)�`�F�b�N�{�b�N�X�N���b�N(�`�[)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Slip_CheckAllDaily_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(0);
        }

        /// <summary>
        /// ����(�S)�`�F�b�N�{�b�N�X�N���b�N(�`�[)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Slip_CheckAllCalc_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(1);
        }

        /// <summary>
        /// ����(�S)�`�F�b�N�{�b�N�X�N���b�N(����)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Detail_CheckAllDaily_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(2);
        }

        /// <summary>
        /// ����(�S)�`�F�b�N�{�b�N�X�N���b�N(����)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Detail_CheckAllCalc_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(3);
        }

        /// <summary>
        /// �S�`�F�b�N����
        /// </summary>
        /// <param name="checkBoxFrom">�ǂ̃`�F�b�N�{�b�N�X����H</param>
        private void CheckAllSlip(int checkBoxFrom)
        {
            bool check = false;
            string columnName_CheckBox = string.Empty;
            string columnName_Detail_CheckBox = string.Empty;
            string columnName_CheckBoxStatus = string.Empty;
            string columnName_CheckBoxEx = string.Empty;
            string columnName_Detail_CheckBoxEx = string.Empty;
            string columnName_CheckBoxStatusEx = string.Empty;

            switch (checkBoxFrom)
            {
                case 0: // �`�[�^�u�̓���(�S)
                    {
                        check = this.uCheckEditor_Slip_CheckAllDaily.Checked;
                        this.uCheckEditor_Detail_CheckAllDaily.Checked = check;
                        break;
                    }
                case 1: // �`�[�^�u�̒���(�S)
                    {
                        check = this.uCheckEditor_Slip_CheckAllCalc.Checked;
                        this.uCheckEditor_Detail_CheckAllCalc.Checked = check;
                        break;
                    }
                case 2: // ���׃^�u�̓���(�S)
                    {
                        check = this.uCheckEditor_Detail_CheckAllDaily.Checked;
                        this.uCheckEditor_Slip_CheckAllDaily.Checked = check;
                        break;
                    }
                case 3: // ���׃^�u�̒���(�S)
                    {
                        check = this.uCheckEditor_Detail_CheckAllCalc.Checked;
                        this.uCheckEditor_Slip_CheckAllCalc.Checked = check;
                        break;
                    }
            }

            if (this._procDiv == 0)
            {
                // �`�F�b�N�{�b�N�X�̂����
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName;
                // �`�F�b�N�{�b�N�X��Ԓl��ێ����Ă����
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;

                // �擾���̗�
                columnName_CheckBoxEx = this._dataSet.SlipList.CheckBoxDailyExColumn.ColumnName;
                columnName_Detail_CheckBoxEx = this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName;
                columnName_CheckBoxStatusEx = this._dataSet.SlipList.CheckBoxDailyStatusExColumn.ColumnName;
            }
            else
            {
                // �`�F�b�N�{�b�N�X�̂����
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName;
                // �`�F�b�N�{�b�N�X��Ԓl��ێ����Ă����
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;

                // �擾���̗�
                columnName_CheckBoxEx = this._dataSet.SlipList.CheckBoxCalcExColumn.ColumnName;
                columnName_Detail_CheckBoxEx = this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName;
                columnName_CheckBoxStatusEx = this._dataSet.SlipList.CheckBoxCalcStatusExColumn.ColumnName;
            }


            foreach (DataRow row in this._dataSet.SlipList.Rows)
            {
                if (check)
                {
                    // �S�Ẵ`�F�b�N�{�b�N�X���`�F�b�N
                    row[columnName_CheckBox] = true;
                    row[columnName_CheckBoxStatus] = 1; // �`�F�b�N��
                }
                else
                {
                    // �S�Ẵ`�F�b�N�{�b�N�X���N���A
                    row[columnName_CheckBox] = false;
                    row[columnName_CheckBoxStatus] = 0; // ���`�F�b�N

                    //// �擾���ɖ߂�
                    //row[columnName_CheckBox] = (bool)row[columnName_CheckBoxEx];
                    //row[columnName_CheckBoxStatus] = (int)row[columnName_CheckBoxStatusEx];
                }
            }

            // ���ׂ��S�ă`�F�b�N
            foreach (DataRow row in this._dataSet.DetailList.Rows)
            {
                if (check)
                {
                    // �S�Ẵ`�F�b�N�{�b�N�X���`�F�b�N
                    row[columnName_Detail_CheckBox] = true;
                }
                else
                {
                    // �S�Ẵ`�F�b�N�{�b�N�X���N���A
                    row[columnName_Detail_CheckBox] = false;

                    //// �擾���ɖ߂�
                    //row[columnName_Detail_CheckBox] = (bool)row[columnName_Detail_CheckBoxEx];
                }
            }

            // ��ʍX�V
            SetupCheckBox_Slip();

            // 2009.01.07 add [9858]
            ResetTotal();
            // 2009.01.07 add [9858]
        }

        #endregion

        #endregion // �`�F�b�N�{�b�N�X����

        #endregion // �v���C�x�[�g�֐�

        #region �R���g���[�����\�b�h

        #region �K�C�h�{�^��

        #region ���_

        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out _sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = _sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = _sectionInfo.SectionGuideNm.Trim();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tEdit_SectionCodeAllowZero.Clear();
                this.tEdit_SectionName.Text = "";
            }
        }

        #endregion // ���_

        #region �d����

        /// <summary>
        /// �d����K�C�h�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�\��
            int status = 0;
            if (!String.IsNullOrEmpty(this._sectionCode))
            {
                status = this._supplierAcs.ExecuteGuid(out _supplier, this._enterpriseCode, _sectionCode);
            }
            else
            {
                status = this._supplierAcs.ExecuteGuid(out _supplier, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0'));
            }

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd.SetInt(_supplier.SupplierCd);
                this.tEdit_SupplierSnm.Text = _supplier.SupplierSnm.Trim();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierSnm.Text = "";
            }
        }

        #endregion // �d����

        #endregion // �K�C�h�{�^��

        #region �c�[���o�[

        /// <summary>
        /// �c�[���o�[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
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

                #region �m��{�^��
                case "ButtonTool_Decision":
                    {
                        Search();
                        break;
                    }
                #endregion // �m��{�^��

                #region �N���A�{�^��
                case "ButtonTool_Clear":
                    {
                        InitializeScreen();
                        break;
                    }
                #endregion // �N���A�{�^��

                #region �ۑ��{�^��
                case "ButtonTool_Save":
                    {
                        UpdateCheck();
                        break;
                    }
                #endregion // �ۑ��{�^��

                default: break;
            }
        }

        #endregion // �c�[���o�[

        #region �A���[�L�[�R���g���[��

        /// <summary>
        /// �A���[�L�[�R���g���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ���O�ɂ�蕪��
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // �t�B�[���h�Ԉړ�
                //---------------------------------------------------------------

                #region �����敪
                case "tComboEditor_ProcDiv":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 2008.12.10 modify start [8991]
                                    e.NextCtrl = null;
                                    // 2008.12.10 modify end [8991]
                                   
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �����敪

                #region ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SectionGuide; // �K�C�h�{�^��
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_SupplierCd;    // �d����R�[�h
                                    }
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_ProcDiv; // �敪
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���_�R�[�h

                #region ���_�K�C�h
                case "uButton_SectionGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_ProcDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���_�K�C�h

                #region �d����R�[�h
                case "tNedit_SupplierCd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SupplierGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_SlipDiv; // �`�[�敪
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d����R�[�h

                #region �d����K�C�h
                case "uButton_SupplierGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tComboEditor_SlipDiv;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d����K�C�h

                #region �`�[�敪
                case "tComboEditor_SlipDiv":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tComboEditor_CheckDiv;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �����敪

                #region �`�F�b�N�敪
                case "tComboEditor_CheckDiv":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateSt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_SlipDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �`�F�b�N�敪

                #region �d����(�J�n)
                case "tDateEdit_StockDateSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDaySt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_CheckDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d����(�J�n)

                #region �d����(�I��)
                case "tDateEdit_StockDateEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDaySt;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDayEd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_CheckDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d����(�I��)

                #region ���͓�(�J�n)
                case "tDateEdit_InputDaySt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDayEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoSt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateSt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���͓�(�J�n)

                #region ���͓�(�I��)
                case "tDateEdit_InputDayEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoSt;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoEd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���͓�(�I��)

                #region �d��SEQ�ԍ�(�J�n)
                case "tNedit_SupplierSlipNoSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumSt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDaySt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d��SEQ�ԍ�(�J�n)

                #region �d��SEQ�ԍ�(�I��)
                case "tNedit_SupplierSlipNoEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumSt;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumEd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDayEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d��SEQ�ԍ�(�I��)

                #region �`�[�ԍ�(�J�n)
                case "tEdit_PartySalesSlipNumSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    if (this._dataSet.DetailList.Rows.Count > 0)
                                    {
                                        if (this.uTabControl_Grid.ActiveTab.Key == "Tab_Slip")
                                        {
                                            e.NextCtrl = this.uGrid_Slip;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uGrid_Detail;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_ProcDiv;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoSt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �`�[�ԍ�(�J�n)

                #region �`�[�ԍ�(�I��)
                case "tEdit_PartySalesSlipNumEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (this._dataSet.DetailList.Rows.Count > 0)
                                    {
                                        if (this.uTabControl_Grid.ActiveTab.Key == "Tab_Slip")
                                        {
                                            e.NextCtrl = this.uGrid_Slip;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uGrid_Detail;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_ProcDiv;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d��SEQ�ԍ�(�I��)

                // ADD 2011/12/05 gezh redmine#8416 ----------------------------------->>>>>
                #region �`�[
                case "uGrid_Slip":
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Slip.ActiveRow;
                        switch (e.Key)
                        {
                            case Keys.Enter:
                                {
                                    if (ultraGridRow == null) return;
                                    OnClickSlipGridCheck(ultraGridRow);
                                    // ����Row�Ɉړ�
                                    // DEL 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    //bool performActionResult = this.uGrid_Slip.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    //if (performActionResult)
                                    //{
                                    //    e.NextCtrl = this.uGrid_Slip;
                                    //}
                                    // DEL 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    // ADD 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    this.uGrid_Slip.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    e.NextCtrl = this.uGrid_Slip;
                                    // ADD 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    break;
                                }
                        }
                        break;
                    }
                #endregion

                #region ����
                case "uGrid_Detail":
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Detail.ActiveRow;
                        switch (e.Key)
                        {
                            case Keys.Enter:
                                {
                                    if (ultraGridRow == null) return;
                                    OnClickDetailGridCheck(ultraGridRow);
                                    // ���̃Z���Ɉړ�
                                    // DEL 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    //bool performActionResult = this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    //if (performActionResult)
                                    //{
                                    //    e.NextCtrl = this.uGrid_Detail;
                                    //}
                                    // DEL 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    // ADD 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    e.NextCtrl = this.uGrid_Detail;
                                    // ADD 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    break;
                                }
                        }
                        break;
                    }
                #endregion
                // ADD 2011/12/05 gezh redmine#8416 -----------------------------------<<<<<
                default: break;
            }
        }

        #endregion // �A���[�L�[�R���g���[��

        #endregion // �R���g���[�����\�b�h

        #region �R���g���[���C�x���g

        #region ���̕ϊ�(Leave�C�x���g)

        #region ���_�R�[�h

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            // ���̕ϊ�
            this._sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            string sectionName = string.Empty;

            // �S�БΉ�����
            if (this._sectionCode.Equals("0") || this._sectionCode.Equals("00"))
            {
                // �R�[�h�͋K��̑S�̃R�[�h�ցi�������ɂ͋K��̑S�̃R�[�h�̂Ƃ��󔒂ɂ���j
                this._sectionCode = CT_CODE_ALLSECCODE;
                sectionName = CT_NAME_ALLSECCODE;
                this.tEdit_SectionName.Text = sectionName;
            }
            else if (!String.IsNullOrEmpty(this._sectionCode))
            {
                sectionName = this.GetSectionName(this._sectionCode);
                if (!String.IsNullOrEmpty(sectionName))
                {
                    this.tEdit_SectionName.Text = sectionName;
                }
                else
                {
                    // 2008.12.10 add start [9007]
                    // ���o�^�R�[�h��00��
                    this._sectionCode = CT_CODE_ALLSECCODE;
                    sectionName = CT_NAME_ALLSECCODE;
                    this.tEdit_SectionName.Text = sectionName;
                    this.tEdit_SectionCodeAllowZero.Text = "00";
                    // 2008.12.10 add end [9007]
                }
            }
        }

        #endregion // ���_�R�[�h

        #region �d����R�[�h

        /// <summary>
        /// �d����R�[�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_SupplierCd_Leave(object sender, EventArgs e)
        {
            // ���̕ϊ�
            int supplierCd = this.tNedit_SupplierCd.GetInt();
            string supplierName = string.Empty;

            // �ϊ�
            if (supplierCd > 0)
            {
                supplierName = GetSupplierName(supplierCd);
                //if (!String.IsNullOrEmpty(supplierName.Trim()))   // DEL 2009/06/29
                if ((this._supplier != null) && (this._supplier.SupplierCd != 0))   // ADD 2009/06/29
                {
                    this.tEdit_SupplierSnm.Text = supplierName;
                }
                else
                {
                    // 2008.12.10 add start [9005]
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    // 2008.12.10 add end [9005]
                }
            }
            else
            {
                // 2008.12.10 add start [8976]
                this.tEdit_SupplierSnm.Clear();
                // 2008.12.10 add end [8976]
            }
        }

        #endregion // �d����R�[�h

        #endregion // ���̕ϊ�(Leave�C�x���g)

        #region �O���b�h���N���b�N

        /// <summary>
        /// �`�[�ꗗ�O���b�h �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�O���b�h�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void uGrid_Slip_Click(object sender, System.EventArgs e)
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
            if (this._procDiv == 0 && objCell == objRow.Cells[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName])
            {
                OnClickSlipGridCheck(objRow);
            }

            // �I���`�F�b�N
            if (this._procDiv == 1 && objCell == objRow.Cells[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName])
            {
                OnClickSlipGridCheck(objRow);
            }
        }

        /// <summary>
        /// ���׈ꗗ�O���b�h �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�O���b�h�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void uGrid_Detail_Click(object sender, System.EventArgs e)
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
            if (this._procDiv == 0 && objCell == objRow.Cells[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName])
            {
                OnClickDetailGridCheck(objRow);
            }

            // �I���`�F�b�N
            if (this._procDiv == 1 && objCell == objRow.Cells[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName])
            {
                OnClickDetailGridCheck(objRow);
            }
        }

        #endregion // �O���b�h���N���b�N

        #region �敪�R���{�{�b�N�X�ؑ�

        /// <summary>
        /// �敪�R���{�{�b�N�X�ؑ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ProcDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_ProcDiv.SelectedItem.DataValue == 0)
            {
                // ------
                //  ����
                // ------

                // �����̃`�F�b�N�{�b�N�X��L����
                this.uCheckEditor_Slip_CheckAllDaily.Enabled = true;
                this.uCheckEditor_Detail_CheckAllDaily.Enabled = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }


                // �����̃`�F�b�N�{�b�N�X�����ׂĖ�����
                this.uCheckEditor_Slip_CheckAllCalc.Enabled = false;
                this.uCheckEditor_Detail_CheckAllCalc.Enabled = false;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }
            }
            else
            {
                // ------
                //  ����
                // ------

                // �����̃`�F�b�N�{�b�N�X�����ׂĖ�����
                this.uCheckEditor_Slip_CheckAllDaily.Enabled = false;
                this.uCheckEditor_Detail_CheckAllDaily.Enabled = false;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }


                // �����̃`�F�b�N�{�b�N�X��L����
                this.uCheckEditor_Detail_CheckAllCalc.Enabled = true;
                this.uCheckEditor_Slip_CheckAllCalc.Enabled = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
            }

            // �敪��ۑ�
            this._procDiv = (int)this.tComboEditor_ProcDiv.SelectedItem.DataValue;

            // ���v�z�X�V
            // 2009.01.07 add [9858]
            if (this._dataSet.DetailList.Rows.Count > 0)
            {
                ResetTotal();
            }
            // 2009.01.07 add [9858]
        }

        #endregion // �敪�R���{�{�b�N�X�ؑ�

        #region �^�u�ؑ�

        /// <summary>
        /// �^�u�ؑ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTabControl_Grid_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            if (this.uTabControl_Grid.ActiveTab.Key == "Tab_Slip")
            {
                #region �`�[�^�u
                // ���׃O���b�h�̕\���̈您��ѐ擪UI�s�I�u�W�F�N�g���擾
                Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_detail = this.uGrid_Detail.DisplayLayout.RowScrollRegions[0];
                Infragistics.Win.UltraWinGrid.UltraGridRow fr_detail = rsr_detail.FirstRow;

                if (fr_detail != null)
                {
                    // UI�s�I�u�W�F�N�g�����݂���Ƃ��̂�(���������͔�΂�)
                    int supplierSlipNo = (int)fr_detail.Cells["SupplierSlipNoKey"].Value;
                    DataRow[] rows = this._dataSet.Tables["SlipList"].Select(String.Format("{0} = {1}", "SupplierSlipNo", supplierSlipNo.ToString()));
                    if (rows.Length > 0)
                    {
                        // �L�[�ƂȂ�RowNo�̒l���擾���A��������ɓ`�[�^�u��UI�s�I�u�W�F�N�g���擾����
                        int rowNo = (int)rows[0]["RowNo"];
                        Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = this.uGrid_Slip.Rows[rowNo - 1];

                        // �s�X�N���[���̈���擾�A�擾�����s��\���̈��
                        this.uGrid_Slip.DisplayLayout.RowScrollRegions[0].FirstRow = gridRow;
                        
                        // ���X�N���[���o�[�̈ʒu�����킹��i��P�ʂł̎擾���ł��Ȃ����߁j
                        this.uGrid_Slip.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position;
                    }
                }
                #endregion // �`�[�^�u
            }
            else
            {
                #region ���׃^�u
                // �`�[�O���b�h�̕\���̈您��ѐ擪UI�s�I�u�W�F�N�g���擾
                Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_slip = this.uGrid_Slip.DisplayLayout.RowScrollRegions[0];
                Infragistics.Win.UltraWinGrid.UltraGridRow fr_slip = rsr_slip.FirstRow;

                if (fr_slip != null)
                {
                    // UI�s�I�u�W�F�N�g�����݂���Ƃ��̂�(���������͔�΂�)
                    int supplierSlipNo = (int)fr_slip.Cells["SupplierSlipNo"].Value;
                    // ���׌������́A[SupplierSlipNo]����������邱�ƂŁA���ׂ̐擪�s��������
                    DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("{0} = {1}", "SupplierSlipNo", supplierSlipNo.ToString()));
                    if (rows.Length > 0)
                    {
                        // �L�[�ƂȂ�RowNo�̒l���擾���A��������ɓ`�[�^�u��UI�s�I�u�W�F�N�g���擾����
                        int rowNo = (int)rows[0]["RowNo"];
                        Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = this.uGrid_Detail.Rows[rowNo - 1];

                        // �s�X�N���[���̈���擾�A�擾�����s��\���̈��
                        this.uGrid_Detail.DisplayLayout.RowScrollRegions[0].FirstRow = gridRow;

                        // ���X�N���[���o�[�̈ʒu�����킹��i��P�ʂł̎擾���ł��Ȃ����߁j
                        this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Slip.DisplayLayout.ColScrollRegions[0].Position;
                    }
                }
                #endregion // ���׃^�u
            }
        }

        #endregion // �^�u�ؑ�
        // ADD 2011/12/05 gezh redmine#8416 -------------------------->>>>>
        /// <summary>
        /// Control.KeyDown �C�x���g(�`�[�^�u)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void uGrid_Slip_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Slip.ActiveRow;
            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Slip.CurrentState;
            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            if (ultraGridRow == null) return;
                            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.uGrid_Slip, this.uGrid_Slip);
                            this.tArrowKeyControl_ChangeFocus(this.uGrid_Slip, evt);
                            this.uGrid_Slip.ActiveRow.Selected = false;
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// Control.KeyDown �C�x���g(���׃^�u)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void uGrid_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Detail.ActiveRow;
            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Detail.CurrentState;
            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            if (ultraGridRow == null) return;
                            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.uGrid_Detail, this.uGrid_Detail);
                            this.tArrowKeyControl_ChangeFocus(this.uGrid_Detail, evt);
                            this.uGrid_Detail.ActiveRow.Selected = false;
                            break;
                        }
                }
            }
        }
        // ADD 2011/12/05 gezh redmine#8416 --------------------------<<<<<
        #endregion // �R���g���[���C�x���g

        //------ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>
        # region [�O���b�h�J������� �ۑ��E����]
        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="targetGrid">targetGrid</param>
        /// <param name="settingList">settingList</param>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʂ̃O���b�h�J�������̕ۑ��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<DetailColumnInfo> settingList)
        {
            settingList = new List<DetailColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new DetailColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }

        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <param name="targetGrid">targetGrid</param>
        /// <param name="settingList">targetGrid</param>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʂ̃��b�h�J�������̓ǂݍ��݁B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<DetailColumnInfo> settingList)
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

            foreach (DetailColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                    ultraGridColumn.Hidden = columnInfo.Hidden;
                    ultraGridColumn.Width = columnInfo.Width;
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// ColumnInfo��r�N���X�i�\�[�g�p�j
        /// </summary>
        public class ColumnInfoComparer : IComparer<DetailColumnInfo>
        {
            /// <summary>
            /// ColumnInfo��r����
            /// </summary>
            /// <param name="x">x</param>
            /// <param name="y">y</param>
            /// <returns>�X�e�[�^�X</returns>
            /// <remarks>
            /// <br>Note       : ColumnInfo��r�N���X�i�\�[�g�p�j</br>
            /// <br>Programmer : ������</br>
            /// <br>Date       : 2012/08/30</br>
            /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
            /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
            /// <br></br>
            /// </remarks>
            public int Compare(DetailColumnInfo x, DetailColumnInfo y)
            {
                // ��\�����Ŕ�r
                int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
                // ��\��������v����ꍇ�͗񖼂Ŕ�r(�ʏ�͔������Ȃ�)
                if (result == 0)
                {
                    result = x.ColumnName.CompareTo(y.ColumnName);
                }
                return result;
            }
        }

        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʂ̃O���b�h�J�������̓ǂݍ��݁B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        public void LoadSettings()
        {
            // �`�[�O���b�h
            this.LoadGridColumnsSetting(ref uGrid_Slip, this._userSetting.SlipColumnsList);
            // ���׃O���b�h
            this.LoadGridColumnsSetting(ref uGrid_Detail, this._userSetting.DetailColumnsList);
        }

        /// <summary>
        /// PMKAU04901UCA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʂ̃O���b�h�J�������̓ǂݍ��݁B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        private void PMKOU01101UA_Load(object sender, EventArgs e)
        {
            // �ݒ�ǂݍ���
            Deserialize();
            //�O���b�h�J�������̓ǂݍ���
            LoadSettings();
        }

        /// <summary>
        /// �t�H�[���N���[�Y�O����
        /// </summary>
        /// <remarks>FormClosing�C�x���g���Ɓ~�{�^�����ɔ����Ă��܂��̂ŁAParent�ŃE�B���h�E���b�Z�[�W������</remarks>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʂ̃O���b�h�J�������̓ǂݍ��݁B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        public void BeforeFormClose()
        {
            //-----------------------------------------
            // �t�H�[������鎞(�~�{�^�����܂�)
            //-----------------------------------------
            // ���[�U�[�ݒ�ۑ�(��XML��������)
            // �`�[�O���b�h
            List<DetailColumnInfo> slipColumnsList;
            this.SaveGridColumnsSetting(uGrid_Slip, out slipColumnsList);
            this._userSetting.SlipColumnsList = slipColumnsList;

            // ���׃O���b�h
            List<DetailColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Detail, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            //�d���`�F�b�N������ʂ̃V���A���C�Y���s���܂��B
            Serialize();
        }

        /// <summary>
        /// �d���`�F�b�N������ʃO���b�h�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʃO���b�h�ݒ�N���X</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        [Serializable]
        public class SupplierCheckOrderSet
        {
            // �o�͌`��
            private int _outputStyle;

            // �`�[�O���b�h�J�������X�g
            private List<DetailColumnInfo> _slipColumnsList;

            // ���׃O���b�h�J�������X�g
            private List<DetailColumnInfo> _detailColumnsList;

            // ���׃O���b�h�����T�C�Y����
            private bool _autoAdjustDetail;

            # region �R���X�g���N�^
            /// <summary>
            /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�p�O���b�h�ݒ�N���X
            /// </summary>
            public SupplierCheckOrderSet()
            {

            }
            # endregion

            /// <summary>�o�͌^��</summary>
            public int OutputStyle
            {
                get { return this._outputStyle; }
                set { this._outputStyle = value; }
            }

            /// <summary>�`�[�O���b�h�J�������X�g</summary>
            public List<DetailColumnInfo> SlipColumnsList
            {
                get { return this._slipColumnsList; }
                set { this._slipColumnsList = value; }
            }

            /// <summary>���׃O���b�h�J�������X�g</summary>
            public List<DetailColumnInfo> DetailColumnsList
            {
                get { return this._detailColumnsList; }
                set { this._detailColumnsList = value; }
            }

            /// <summary>���׃O���b�h�����T�C�Y����</summary>
            public bool AutoAdjustDetail
            {
                get { return _autoAdjustDetail; }
                set { _autoAdjustDetail = value; }
            }
        }


        # region [DetailColumnInfo]
        /// <summary>
        /// ColumnInfo
        /// </summary>
        [Serializable]
        public struct DetailColumnInfo
        {
            /// <summary>��</summary>
            private string _columnName;
            /// <summary>���я�</summary>
            private int _visiblePosition;
            /// <summary>��\���t���O</summary>
            private bool _hidden;
            /// <summary>��</summary>
            private int _width;
            /// <summary>�Œ�t���O</summary>
            private bool _columnFixed;

            /// <summary>
            /// ��
            /// </summary>
            public string ColumnName
            {
                get { return _columnName; }
                set { _columnName = value; }
            }
            /// <summary>
            /// ���я�
            /// </summary>
            public int VisiblePosition
            {
                get { return _visiblePosition; }
                set { _visiblePosition = value; }
            }
            /// <summary>
            /// ��\���t���O
            /// </summary>
            public bool Hidden
            {
                get { return _hidden; }
                set { _hidden = value; }
            }
            /// <summary>
            /// ��
            /// </summary>
            public int Width
            {
                get { return _width; }
                set { _width = value; }
            }
            /// <summary>
            /// �Œ�t���O
            /// </summary>
            public bool ColumnFixed
            {
                get { return _columnFixed; }
                set { _columnFixed = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="columnName">��</param>
            /// <param name="visiblePosition">���я�</param>
            /// <param name="hidden">��\���t���O</param>
            /// <param name="width">��</param>
            /// <param name="columnFixed">�Œ�t���O</param>
            /// <remarks>
            /// <br>Note       : �R���X�g���N�^</br>
            /// <br>Programmer : ������</br>
            /// <br>Date       : 2012/08/30</br>
            /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
            /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
            /// <br></br>
            /// </remarks>
            public DetailColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
            {
                _columnName = columnName;
                _visiblePosition = visiblePosition;
                _hidden = hidden;
                _width = width;
                _columnFixed = columnFixed;
            }
        }

        # endregion

        /// <summary>
        /// PMKOU01101UA_FormClosing 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : PMKOU01101UA_FormClosing </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        private void PMKOU01101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �t�H�[������鎞(�~�{�^�����܂�)
            //-----------------------------------------
            // ���[�U�[�ݒ�ۑ�(��XML��������)
            // �`�[�O���b�h
            List<DetailColumnInfo> slipColumnsList;
            this.SaveGridColumnsSetting(uGrid_Slip, out slipColumnsList);
            this._userSetting.SlipColumnsList = slipColumnsList;
            // ���׃O���b�h
            List<DetailColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Detail, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            //�d���`�F�b�N������ʂ̃V���A���C�Y���s���܂��B
            Serialize();
        }

        /// <summary>
        /// �d���`�F�b�N������ʂ̃V���A���C�Y���s���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʂ̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// �d���`�F�b�N������ʂ��f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N������ʂ��f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M�� Redmine#31879</br>
        /// <br>                           No.1159�̃O���b�h�̎d�l�ύX�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<SupplierCheckOrderSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new SupplierCheckOrderSet();
                }
            }
        }
        # endregion
        //------ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<
       
    }
}