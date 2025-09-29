//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���Ӑ�ߔN�x���яƉ�
// �v���O�����T�v   : ���Ӑ�ߔN�x���яƉ�̌����A�\��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30418 ���i
// �� �� ��  2008/11/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/02/26  �C�����e : ��Q�Ή�11994 ��v�N�x�̎擾�������C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2009/03/09  �C�����e : ��Q�Ή�11994 ��v�N�x�̎擾�������C��
//                                : ���N�x�̊T�O���A���{�I�Ɏd�l���ύX���ꂽ���ߑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2009/03/12  �C�����e : ��Q�Ή�12304
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/05/25  �C�����e : ��Q�Ή�13330
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : �����
// �C �� ��  2010/06/28  �C�����e : �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : �I�M  
// �C �� ��  2010/07/20  �C�����e : Excel�A�e�L�X�g�o�͑Ή��i�U�����ǒǉ��˗����j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenyd  
// �C �� ��  2010/08/12  �C�����e : ��Q�Ή�13026
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw  
// �C �� ��  2010/09/09  �C�����e : redmine #14434�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw  
// �C �� ��  2010/09/13  �C�����e : �e�L�X�g�o�͑Ή��@�s��Ή�#14643
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw  
// �C �� ��  2010/09/21  �C�����e : �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj    
// �C �� ��  2010/10/09  �C�����e : �e�L�X�g�o�͑Ή� �s��Ή�#15879
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp    
// �C �� ��  2011/02/16  �C�����e : �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���O
// �C �� ��  2024/11/22  �C�����e : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.ParamData;//ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Application.Common;       // DEL 2009/05/25
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller.Facade;
using Infragistics.Excel;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�ߔN�x���яƉ�
    /// </summary>
    ///<remarks>
    /// <br>Note        : ���Ӑ�ߔN�x���яƉ�UI�t�H�[���N���X</br>
    /// <br>Programmer  : 30418 ���i</br>
    /// <br>Date        : 2008/11/18</br>
    /// <br>Update Note : 2009/02/26 30452 ��� �r��</br>
    /// <br>             �E��Q�Ή�11994 ��v�N�x�̎擾�������C��</br>
    /// <br>Update Note : 2009/03/09 30414 �E �K�j</br>
    /// <br>             �E��Q�Ή�11994 ��v�N�x�̎擾�������C��</br>
    /// <br>             �@���N�x�̊T�O���A���{�I�Ɏd�l���ύX���ꂽ���ߑΉ�</br>
    /// <br>Update Note : 2009/03/12 30414 �E �K�j</br>
    /// <br>             �E��Q�Ή�12304</br>
    /// <br>Update Note : 2010/06/28 �����</br>
    /// <br>             �E�e�L�X�g�o�͑Ή�</br>
    /// <br>UpdateNote  : 2010/07/20 �I�M</br>
    /// <br>             �EExcel�A�e�L�X�g�o�͑Ή��i�U�����ǒǉ��˗����j</br>
    /// <br>UpdateNote  : 2010/08/12 chenyd</br>
    /// <br>             �E��Q�Ή�13026</br>
    /// <br>UpdateNote  : 2010/08/23 chenyd</br>
    /// <br>             �E��Q�Ή�13482</br>
    /// <br>UpdateNote  : 2010/09/13 tianjw</br>
    /// <br>             �E�e�L�X�g�o�͑Ή��@�s��Ή�#14643</br>
    /// <br>UpdateNote  : 2010/09/21 tianjw</br>
    /// <br>             �E�e�L�X�g�o�͑Ή��@�s��Ή�#14876</br>
    /// <br>Update Note: 2010/10/09 yangmj</br>
    /// <br>            �E�e�L�X�g�o�͑Ή� �s��Ή�#15879</br> 
    /// <br>Update Note: 2011/02/16 liyp</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br> 
    /// <br>Update Note :2024/11/22 ���O</br>
    /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// </remarks>
    public partial class PMHNB04121UA : Form
    {

        #region �v���C�x�[�g�ϐ�

        #region ���[�J���N���X

        /// <summary>���Ӑ�ߔN�x���яƉ�o�����N���X</summary>
        CustomInqOrderCndtn _customInqOrderCndtn = null;

        /// <summary>���Ӑ�ߔN�x���яƉ�A�N�Z�X�N���X</summary>
        CustPastExperienceAcs _custPastExperienceAcs = null;

        #endregion // ���[�J���N���X

        #region �N���X

        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoAcs _secInfoAcs;

        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>���_���f�[�^�N���X</summary>
        private SecInfoSet _sectionInfo;

        /// <summary>���Ӑ挟���A�N�Z�X�N���X</summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>���Ӑ���f�[�^�N���X</summary>
        private CustomerInfo _customerInfo;

        /// <summary>���Џ��A�N�Z�X�N���X</summary>
        private DateGetAcs _dateGetAcs = null;

        /// <summary>UI�X�L���ݒ�R���g���[��</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        // --- ADD 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
        /// <summary>�����Z�o���W���[��</summary>
        private TotalDayCalculator _totalDayCalculator = null;
        // --- ADD 2009/03/09 ��QID:11994�Ή�------------------------------------------------------<<<<<

        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        #endregion // �N���X

        #region �f�[�^�Z�b�g

        /// <summary>���Ӑ�ߔN�x���яƉ���f�[�^�Z�b�g</summary>
        CustomInqOrderDataSet _dataSet = null;

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

        /// <summary>���Ӑ�R�[�h</summary>
        private int _customerCd = 0;

        /// <summary>�{�^���p�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;

        #endregion // �R�[�h��

        #region ��v�N�x�֘A

        /// <summary>���Аݒ�擾�A�N�Z�X�N���X</summary>
        private CompanyInfAcs _companyInfAcs;

        // --- DEL 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
        ///// <summary>�N��</summary>
        //private DateTime _yearMonth;
        // --- DEL 2009/03/09 ��QID:11994�Ή�------------------------------------------------------<<<<<

        /// <summary>��v�N�x</summary>
        private int _fiscalYear = 0;

        // --- DEL 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
        ///// <summary>�N���x�J�n��</summary>
        //private DateTime _fYearStartMonthDate;

        ///// <summary>�N���x�I����</summary>
        //private DateTime _fYearEndMonthDate;

        ///// <summary>�N�x�J�n��</summary>
        //private DateTime _fYearStartYearDate;

        ///// <summary>�N�x�I����</summary>
        //private DateTime _fYearEndYearDate;
        // --- DEL 2009/03/09 ��QID:11994�Ή�------------------------------------------------------<<<<<

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        private PMHNB04121UB _userSetupFrm = null;              // ���[�U�[�ݒ��� 
        private PMHNB04121UC _extractSetupFrm = null;           // �o�͏����ݒ��� 
        private bool isSearch = false;                          // �����{�^�����N���b�N���邩�ǂ���
        private int _opt_TextOutput;                            // �e�L�X�g�o�̓I�v�V�������
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        private bool isError = false; // ADD 2010/09/21

        private DataView _dViewBak = null; // ADD 2010/09/21

        #endregion // ��v�N�x�֘A

        #endregion // �v���C�x�[�g�ϐ�
        #region
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;					// �ݒ�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _textButton;                   // �e�L�X�g�o�̓{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _excelButton;                  // Excel�o�̓{�^��
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        #endregion
        #region �萔

        /// <summary>�S�ЃR�[�h���́F�����l�u�S�Ёv</summary>
        private const string CT_NAME_ALLSECCODE = "�S��";

        /// <summary>�G���[���b�Z�[�W�F�u��v�N�x�J�n�����擾����Ă��܂���B�v</summary>
        private const string CT_FISCAL_START_DATE_NOT_QUALIFIED = "��v�N�x�J�n�����擾����Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u��v�N�x�I�������擾����Ă��܂���B�v</summary>
        private const string CT_FISCAL_END_DATE_NOT_QUALIFIED = "��v�N�x�I�������擾����Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u��ƃR�[�h���擾����Ă��܂���B�v</summary>
        private const string CT_ENTERPRISE_CODE_NOT_QUALIFIED = "��ƃR�[�h���擾����Ă��܂���B";

        // 2008.12.09 modify start [8891]
        /// <summary>�G���[���b�Z�[�W�F�u���Ӑ�R�[�h�����͂���Ă��܂���B�v</summary>
        private const string CT_CUSTOMER_CODE_NOT_QUALIFIED = "���Ӑ�R�[�h�����͂���Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u���͂��ꂽ���_�R�[�h�͎g�p�ł��܂���B�v</summary>
        private const string CT_INVALID_SECTION = "���͂��ꂽ���_�R�[�h�͎g�p�ł��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u���͂��ꂽ�R�[�h�ɊY�����链�Ӑ悪����܂���B�v</summary>
        private const string CT_INVALID_CUSTOMER = "���͂��ꂽ�R�[�h�ɊY�����链�Ӑ悪����܂���B";

        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        // ���\�b�h��
        private const string MethodNm = "outputTextData";
        private const string MethodNm2 = "outputExcelData";
        // �o�͌���
        private const string CountNumStr = "�f�[�^�o�͌���:{0},";
        /// <summary>���Ӑ�ߔN�x���яƉ�PGID</summary>
        private const string CUSTOM_INQ_RESULT_PGID = "PMHNB04121U";
        // �A�Z���u����
        private const string AssemblyNm = "���Ӑ�ߔN�x���яƉ�";
        // �e�L�X�g��Excel�o�͏���
        private const string Con = "���_:{0} �` {1},���Ӑ�:{2} �` {3},�o�̓t�@�C����:{4}";
        // �ŏ�����
        private const string StartStr = "�ŏ�����";
        // �Ō�܂�
        private const string EndStr = "�Ō�܂�";
        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

        #endregion // �萔
        // 2010/07/20 Add >>>
        #region
        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // ���쌠���̐��䃊�X�g
        #endregion
        // 2010/07/20 Add <<<
        #region ���񋓑�

        // 2010/02/22 Add >>>
        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        public enum OperationCode : int
        {
            /// <summary>�e�L�X�g�o��</summary>
            TextOut = 1,
            /// <summary>�G�N�Z���o��</summary>
            ExcelOut = 2
        }
        #endregion

        #region �v���p�e�B

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("MHNB04120U", this);
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
        // 2010/07/20 Add <<<

        #endregion
        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2024/11/22 ���O</br>
        /// <br>�Ǘ��ԍ�   : 12070203-00</br>
        /// <br>           : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        public PMHNB04121UA()
        {
            InitializeComponent();

            InitializeVariable();

            // -----ADD 2010/07/20 ---------------------->>>>>
            // �e�L�X�g�o�̓I�v�V�����̐���@
            this.CacheOptionInfo();
            // -----ADD 2010/07/20 ----------------------<<<<<
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�---->>>>>
            TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs();//�e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�\�������̑Ώ�
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�----<<<<<
        }

        /// <summary>
        /// �t�H�[���\����C�x���g�i�����t�H�[�J�X�֘A�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04121UA_Shown(object sender, System.EventArgs e)
        {
            // �����t�H�[�J�X
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // �R���X�g���N�^

        #region �z�F

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



        #endregion // �z�F

        #region �v���C�x�[�g�֐�

        /// <summary>
        /// �R���g���[���ޏ����z�u
        /// </summary>
        private void InitializeVariable()
        {

            // UI�X�L���ݒ�R���g���[��
            this._controlScreenSkin = new ControlScreenSkin();

            #region �A�N�Z�X�N���X������

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();          // ���_
            this._customerInfoAcs = new CustomerInfoAcs();      // ���Ӑ�
            this._dateGetAcs = DateGetAcs.GetInstance();        // ��v�N�x�擾
            this._companyInfAcs = new CompanyInfAcs();          // ���Аݒ�
            // --- ADD 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
            this._totalDayCalculator = TotalDayCalculator.GetInstance();    // �����Z�o���W���[��
            // --- ADD 2009/03/09 ��QID:11994�Ή�------------------------------------------------------<<<<<

            #endregion // �A�N�Z�X�N���X������

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // ��ƃR�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // �����_�R�[�h
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ���O�C�����[�U�[�R�[�h
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ���O�C�����[�U�[��

            #region �{�^���C���[�W�ݒ�

            // �C���[�W���X�g���w��(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // �{�^���C���[�W��ݒ�
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // �c�[���o�[�A�C�R��
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 ��QID:12304�Ή�------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            // --- CHG 2009/03/12 ��QID:12304�Ή�------------------------------------------------------<<<<<
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;

            // --- ADD 2010/06/28 ---------->>>>>
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SETUP1;
            // --- ADD 2010/06/28 ----------<<<<<
            // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
            this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            this._textButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"];
            this._excelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"];
            // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
            #endregion // �{�^���C���[�W�ݒ�

            #region ���������N���X�쐬

            this._customInqOrderCndtn = new CustomInqOrderCndtn();

            #endregion // ���������N���X�쐬

            #region �R���g���[���X�L���Ή�

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // �R���g���[���X�L���Ή�

            // --- DEL 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
            //#region ��v�N�x�擾(���Џ��}�X�^)

            //// ���Џ��ǂݍ���(��v�N�x���擾)
            //CompanyInf companyInf;
            //int status = this._companyInfAcs.Read(out companyInf, this._enterpriseCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this._fiscalYear = companyInf.FinancialYear;
            //}

            //// ���Џ�����v�N�x�J�n���A�I�������擾
            //// --- DEL 2009/02/26 -------------------------------->>>>>
            ////int year = 0;
            ////_dateGetAcs.GetThisYearMonth(out this._yearMonth,               // *�g�p���܂���*
            ////                            out year,                           // *�g�p���܂���*
            ////                            out this._fYearStartMonthDate,      // *�g�p���܂���*
            ////                            out this._fYearEndMonthDate,        // *�g�p���܂���*
            ////                            out this._fYearStartYearDate,       // ��v�N�x�J�n��
            ////                            out this._fYearEndYearDate);        // ��v�N�x�I����
            //// --- DEL 2009/02/26 --------------------------------<<<<<
            //// --- ADD 2009/02/26 -------------------------------->>>>>
            //List<DateTime> startMonthDateList;
            //List<DateTime> endMonthDateList;
            //List<DateTime> yearMonth;
            //_dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList, out yearMonth);

            //this._fYearStartYearDate = startMonthDateList[0]; // ��v�N�x�J�n��
            //this._fYearEndYearDate = endMonthDateList[11]; // ��v�N�x�I����
            //// --- ADD 2009/02/26 -------------------------------->>>>>

            //#endregion // ��v�N�x�擾(���Џ��}�X�^)
            // --- DEL 2009/03/09 ��QID:11994�Ή�------------------------------------------------------<<<<<

            #region �O���b�h�ݒ�

            // �A�N�Z�X�N���X�����������A�f�[�^�Z�b�g���擾
            this._custPastExperienceAcs = new CustPastExperienceAcs();
            this._dataSet = this._custPastExperienceAcs.DataSet;

            // �O���b�h�ŕ\���Ɏg�p����f�[�^�r���[���쐬
            DataView dView = new DataView(this._dataSet.CustomInqResult);

            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = dView;

            // �O���b�h���ݒ�
            InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

            #endregion // �O���b�h�ݒ�

            // ��ʃN���A
            InitializeScreen();

        }

        #region ���_���̎擾

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCd">�������鋒�_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private string GetSectionName(string sectionCd)
        {
            int status = this._secInfoSetAcs.Read(out _sectionInfo, this._enterpriseCode, sectionCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isError = false; // ADD 2010/09/21
                // 2008.12.02 add start []
                if (_sectionInfo.LogicalDeleteCode == 0)
                {
                    isError = false; // ADD 2010/09/21
                    return _sectionInfo.SectionGuideNm;
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                        CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                    this.tEdit_SectionCodeAllowZero.Clear();
                    isError = true; // ADD 2010/09/21
                    return string.Empty;
                }
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                    CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                this.tEdit_SectionCodeAllowZero.Clear();
                isError = true; // ADD 2010/09/21
                // 2008.12.02 add end []
                return string.Empty;
            }
        }

        #endregion // ���_���̎擾

        #region ���Ӑ於�擾

        /// <summary>
        /// ���Ӑ於�擾����
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private string GetCustomerName(int customerCd)
        {
            int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCd, out _customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isError = false; // ADD 2010/09/21
                //if (_customerInfo == null || String.IsNullOrEmpty(_customerInfo.CustomerSnm.Trim())) //DEL 2010/07/20 
                if (_customerInfo == null)                                                             //ADD 2010/07/20 
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                        CT_INVALID_CUSTOMER, 0, MessageBoxButtons.OK);
                    this.tNedit_CustomerCode.Clear();
                    isError = true; // ADD 2010/09/21
                    this.tNedit_CustomerCode.Focus(); // ADD 2010/09/21
                    return string.Empty;
                }
                else
                {
                    isError = false; // ADD 2010/09/21
                    return _customerInfo.CustomerSnm.Trim(); 
                }
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                    CT_INVALID_CUSTOMER, 0, MessageBoxButtons.OK);
                this.tNedit_CustomerCode.Clear();
                isError = true; // ADD 2010/09/21
                this.tNedit_CustomerCode.Focus(); // ADD 2010/09/21
                return string.Empty;
            }
        }

        #endregion // ���Ӑ於�擾

        #region ��ʂ̏�����

        /// <summary>
        /// ��ʂ̏�����
        /// </summary>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        private void InitializeScreen()
        {
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();

            // �f�[�^�Z�b�g���N���A
            this._dataSet.CustomInqResult.Clear();

            // ���O�C�����[�U�[���\��
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;

            // �t�H�[�J�X�����_��
            this.tEdit_SectionCodeAllowZero.Focus();

            // ----------- ADD 2010/09/21 ---------------------------------->>>>>
            // �O���b�h�ŕ\���Ɏg�p����f�[�^�r���[���쐬
            DataView dataView = new DataView(this._dataSet.CustomInqResult);

            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = dataView;

            this._dViewBak = dataView;
            // ----------- ADD 2010/09/21 ----------------------------------<<<<<
        }

        #endregion // ��ʂ̏�����

        #region �O���b�h�񏉊���

        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        /// <param name="Columns"></param>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // �\���`���̂����Ŏg�p
            string formatCurrency = "#,##0;-#,##0;";

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

            // �N�x
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Width = 130;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Caption = "";
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.ForeColor = _rowFiscalColForeColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.BackColor = _rowFiscalColBackColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.BackColor2 = _rowFiscalColBackColor2;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // ������
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Width = 250;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Caption = "���@���@��";
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ������
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Width = 250;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Caption = "�e�@��";
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        /// <param name="fiscalYear">��v�N�x</param>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            �E��QID:13026 �e�L�X�g�o�͑Ή�</br> 
        /// <br>Update Note: 2010/09/09 tianjw</br>
        /// <br>            �Eredmine #14434�Ή�</br> 
        /// <br>Update Note: 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή��@�s��Ή�#14643</br> 
        private void InitializeGridColumnsForOutput(int fiscalYear)
        {
            string moneyFormat = "#,##0;-#,##0;";

            int defoWidth = 94;     //�i13���j
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                // �t�H���g�T�C�Y�F9
                //col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX  // DEL 2010/08/12 ��QID:13026�Ή�
                col.Width = defoWidth;
            }

            // ���_����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Header.Caption = "���_";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Width = 60;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Format = "";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].MaxLength = 2;

            // ���Ӑ溰��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Format = "";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].MaxLength = 8;

            // ���Ӑ於��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Hidden = false;
            // ----- UPD 2010/09/09 ----->>>>>
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Header.Caption = "���Ӑ於��";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Header.Caption = "���Ӑ於";
            // ----- UPD 2010/09/09 -----<<<<<
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Format = "";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2002�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 7).ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 7).ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Format = moneyFormat;

            // �ߔN�x���сE�e���i��2002�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + (fiscalYear - 7).ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2003�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 6).ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 6).ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE�e���i��2003�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + (fiscalYear - 6).ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2004�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 5).ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 5).ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE�e���i��2004�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + (fiscalYear - 5).ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2005�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 4).ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 4).ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE�e���i��2005�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + (fiscalYear - 4).ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2006�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 3).ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 3).ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE�e���i��2006�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + (fiscalYear - 3).ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2007�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 2).ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 2).ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE�e���i��2007�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + (fiscalYear - 2).ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2008�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 1).ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + (fiscalYear - 1).ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE�e���i��2008�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + (fiscalYear - 1).ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE������i��2009�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + fiscalYear.ToString() + "�N�x�j"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Header.Caption = "�ߔN�x���сE������i" + fiscalYear.ToString() + "�N�x�j"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �ߔN�x���сE�e���i��2009�N�x�j
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Header.Caption = "�ߔN�x���сE�e���i" + fiscalYear.ToString() + "�N�x�j";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        #endregion //

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private void Search()
        {
            // -------- ADD 2010/09/21 ----------------------------------------->>>>>
            // �O���b�h�ŕ\���Ɏg�p����f�[�^�r���[���쐬
            DataView dataView = new DataView(this._dataSet.CustomInqResult);

            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = dataView;
            // -------- ADD 2010/09/21 -----------------------------------------<<<<<

            // ��ʂ��猟�������N���X���쐬

            // ��ƃR�[�h���Z�b�g
            this._customInqOrderCndtn.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h���Z�b�g
            if (this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("0") ||
                this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("00"))
            {
                this._customInqOrderCndtn.AddUpSecCode = string.Empty;
                //this._customInqOrderCndtn.AddUpSecName = string.Empty;
                this._customInqOrderCndtn.AddUpSecName = "�S��";
            }
            else if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                this._customInqOrderCndtn.AddUpSecCode = string.Empty;
                //this._customInqOrderCndtn.AddUpSecName = string.Empty;
                this._customInqOrderCndtn.AddUpSecName = "�S��";
            }
            else
            {
                this._customInqOrderCndtn.AddUpSecCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                this._customInqOrderCndtn.AddUpSecName = this.tEdit_SectionName.Text.Trim();
            }

            // ���Ӑ�R�[�h���Z�b�g
            this._customInqOrderCndtn.CustomerCode = this.tNedit_CustomerCode.GetInt();

            // --- CHG 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
            //// ��v�N�x�J�n�����Z�b�g
            //if (this._fYearStartYearDate != DateTime.MinValue)
            //{
            //    this._customInqOrderCndtn.St_AddUpYearMonth = TDateTime.DateTimeToLongDate(this._fYearStartYearDate.AddYears(-1));
            //}

            //// ��v�N�x�I�������Z�b�g
            //if (this._fYearEndYearDate != DateTime.MinValue)
            //{
            //    this._customInqOrderCndtn.Ed_AddUpYearMonth = TDateTime.DateTimeToLongDate(this._fYearEndYearDate.AddYears(-1));
            //}
            // ��v�N�x���擾
            int startDate;
            int endDate;
            int status = GetFinancialYearInfo(this._customInqOrderCndtn.AddUpSecCode, out this._fiscalYear, out startDate, out endDate);
            if (status == 0)
            {
                this._customInqOrderCndtn.St_AddUpYearMonth = startDate;
                this._customInqOrderCndtn.Ed_AddUpYearMonth = endDate;
            }
            // --- CHG 2009/03/09 ��QID:11994�Ή�------------------------------------------------------<<<<<

            // --------------- ADD 2010/09/21 -------------------------->>>>>
            // ���_
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                EventArgs eArgs = new EventArgs();
                this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl.GetZeroPaddedText(this.tEdit_SectionCodeAllowZero.Name, this.tEdit_SectionCodeAllowZero.Text);
                tEdit_SectionCodeAllowZero_Leave(null, eArgs);
                if (isError == true)
                {
                    return;
                }
            }
            // ���Ӑ�
            if (this.tNedit_CustomerCode.Focused)
            {
                EventArgs eArgs = new EventArgs();
                this.tNedit_CustomerCode.Text = this.uiSetControl.GetZeroPaddedText(this.tNedit_CustomerCode.Name, this.tNedit_CustomerCode.Text);
                tNedit_CustomerCode_Leave(null, eArgs);
                if (isError == true)
                {
                    return;
                }
            }
            // --------------- ADD 2010/09/21 --------------------------<<<<<

            // �p�����[�^�`�F�b�N
            string errorMsg = string.Empty;
            if (!CheckParameter(out errorMsg))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                return;
            }
            else
            {
                // �f�[�^�Z�b�g���N���A
                this._dataSet.CustomInqResult.Clear();

                // ��v�N�x���Z�b�g
                this._custPastExperienceAcs.FiscalYear = _fiscalYear;

                // �������s
                this._custPastExperienceAcs.Search(this._customInqOrderCndtn);

                // �\�[�g�����쐬
                DataView dView = (DataView)this.uGrid_Details.DataSource;
                dView.Sort = "FiscalYear Desc";

                // �S�ẴO���b�h�̔w�i�F�𒲐�
                //RowColorChangeAll(false, 0);

            }
        }

        #endregion // ����

        #region �p�����[�^�`�F�b�N�֐�

        /// <summary>
        /// �p�����[�^�`�F�b�N�֐�
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private bool CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // �p�����[�^���K�{�̂��̂��`�F�b�N

            // �N�x�J�n��
            if (this._customInqOrderCndtn.St_AddUpYearMonth == 0)
            {
                errorMsg = CT_FISCAL_START_DATE_NOT_QUALIFIED;
                return false;
            }

            // �N�x�I����
            if (this._customInqOrderCndtn.Ed_AddUpYearMonth == 0)
            {
                errorMsg = CT_FISCAL_END_DATE_NOT_QUALIFIED;
                return false;
            }

            // ���Ӑ�R�[�h
            if (this._customInqOrderCndtn.CustomerCode == 0)
            {
                errorMsg = CT_CUSTOMER_CODE_NOT_QUALIFIED;
                return false;
            }

            // ��ƃR�[�h
            if (String.IsNullOrEmpty(this._customInqOrderCndtn.EnterpriseCode))
            {
                errorMsg = CT_ENTERPRISE_CODE_NOT_QUALIFIED;
                return false;
            }

            return true;
        }

        #endregion // �p�����[�^�`�F�b�N�֐�

        #region �O���b�h�̔w�i�F��ύX

        /// <summary>
        /// �s�̔w�i�F�ύX����
        /// </summary>
        /// <param name="isSelected">bool �I������Ă���</param>
        /// <param name="gridRow">�s�I�u�W�F�N�g</param>
        private void RowColorChangeAll(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            //// �Ώۍs���I������Ă��邩�����łȂ����Ŕz�F���قȂ�
            //if (isSelected)
            ////{
            //    // �O���b�h�̔w�i�F��ݒ�
            //    gridRow.Appearance.BackColor = _rowBackColor1;
            //    gridRow.Appearance.BackColor2 = _rowBackColor2;
            //    // �O���f�[�V������ݒ�
            //    gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //}
            //else
            //{
            // �w�i�F��W���̔z�F�ɖ߂�
            if (gridRow.Index % 2 == 1)
            {
                gridRow.Appearance.BackColor = Color.Lavender;
            }
            else
            {
                gridRow.Appearance.BackColor = Color.White;
            }
            // �O���f�[�V������ݒ�
            gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            //}
        }

        #endregion // �O���b�h�̔w�i�F��ύX

        // --- ADD 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
        #region ��v�N�x�擾(���񌎎����������Z�o)
        /// <summary>
        /// ��v�N�x���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="financialYear">��v�N�x</param>
        /// <param name="startDate">�N�x�J�n��</param>
        /// <param name="endDate">�N�x�I����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetFinancialYearInfo(string sectionCode, out int financialYear, out int startDate, out int endDate)
        {
            //----------------------------------------------------------------------------------------------
            // ��v�N�x  �F���񌎎����������܂ޔN�x(=���t�擾���i���擾)���Z�b�g
            // �N�x�J�n���F�Ώۂ̉�v�N�x�̊J�n��(=���t�擾���i���擾)���Z�b�g
            // �N�x�I�����F�Ώۂ̉�v�N�x�̏I����(=���t�擾���i���擾)���Z�b�g
            //----------------------------------------------------------------------------------------------

            financialYear = 0;
            startDate = 0;
            endDate = 0;

            // DEL 2009/05/25 ------>>>
            //DateTime prevTotalDay;
            //DateTime currentTotalDay;
            // DEL 2009/05/25 ------<<<
            DateTime dummyDate;
            DateTime startYearDate;
            DateTime endYearDate;

            int status;

            // DEL 2009/05/25 ------>>>
            //// �S��
            //if ((sectionCode.Trim() == "") || (sectionCode.Trim() == "0") || (sectionCode.Trim() == "00"))
            //{
            //    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(String.Empty, out prevTotalDay, out currentTotalDay);
            //    if (status == 0)
            //    {
            //        this._dateGetAcs.GetYearMonth(currentTotalDay, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
            //        startDate = TDateTime.DateTimeToLongDate(startYearDate);
            //        endDate = TDateTime.DateTimeToLongDate(endYearDate);
            //    }
            //}
            //// ���_
            //else
            //{
            //    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode.Trim(), out prevTotalDay, out currentTotalDay);
            //    if (status == 0)
            //    {
            //        this._dateGetAcs.GetYearMonth(currentTotalDay, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
            //        startDate = TDateTime.DateTimeToLongDate(startYearDate);
            //        endDate = TDateTime.DateTimeToLongDate(endYearDate);
            //    }
            //}
            // DEL 2009/05/25 ------<<<

            // ADD 2009/05/25 ------>>>
            // ���Аݒ�}�X�^�̉�v�N�x���擾
            CompanyInf companyInf = this._dateGetAcs.GetCompanyInf();
            status = -1;
            if (companyInf != null)
            {
                // ���Аݒ�}�X�^�̊���N�����ŔN�x�J�n�^�I�������擾
                DateTime dateTime = TDateTime.LongDateToDateTime(companyInf.CompanyBiginDate);
                this._dateGetAcs.GetYearMonth(dateTime, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
                startDate = TDateTime.DateTimeToLongDate(startYearDate);
                endDate = TDateTime.DateTimeToLongDate(endYearDate);
                status = 0;
            }
            // ADD 2009/05/25 ------<<<

            return (status);
        }
        #endregion ��v�N�x�擾(���񌎎����������Z�o)
        // --- ADD 2009/03/09 ��QID:11994�Ή�------------------------------------------------------<<<<<

        #endregion // �v���C�x�[�g�֐�

        #region �R���g���[�����\�b�h

        #region �K�C�h�{�^��

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
            else
            {
                // 2008.12.02 del start [8578]
                //this.tEdit_SectionCodeAllowZero.Clear();
                //this.tEdit_SectionName.Text = "";
                // 2008.12.02 del end [8578]
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ���ݏ����Ȃ�
            }
        }

        #endregion // �K�C�h�{�^��

        #region ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

        /// <summary>
        /// ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender">PMKHN4002E�t�H�[���I�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            // �X�e�[�^�X�ɂ��G���[���b�Z�[�W���o��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status, MessageBoxButtons.OK);
                return;
            }

            // ���Ӑ����UI�ɐݒ�
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.tEdit_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
        }

        #endregion // ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

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
                        _dViewBak = new DataView(this._dataSet.CustomInqResult.Copy()); // ADD 2010/09/21
                        this.isSearch = true; // ADD 2010/07/20
                        break;
                    }
                #endregion // �N���A�{�^��

                #region �N���A�{�^��
                case "ButtonTool_Clear":
                    {
                        InitializeScreen();
                        this.isSearch = false; // ADD 2010/09/14
                        break;
                    }
                #endregion // �N���A�{�^��

                // --- ADD 2010/06/28 ---------->>>>>
                #region �e�L�X�g�o�̓{�^��
                case "ButtonTool_TextOutput":
                    {
                        this.ExportIntoTextFile(false); // ADD 2010/07/20
                        break;
                    }
                #endregion // �e�L�X�g�o�̓{�^��

                #region Excel�o�̓{�^��
                case "ButtonTool_ExcelOutput":
                    {
                        this.exportIntoExcelData(true);// ADD 2010/07/20
                        break;
                    }
                #endregion // Excel�o�̓{�^��

                #region �ݒ�{�^��
                case "ButtonTool_Setup":
                    {
                        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                        if (this._userSetupFrm == null)
                            this._userSetupFrm = new PMHNB04121UB();

                        this._userSetupFrm.ShowDialog();
                        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
                        break;
                    }
                #endregion // �ݒ�{�^��
                // --- ADD 2010/06/28 ----------<<<<<
                default: break;
            }
        }

        #endregion // �c�[���o�[

        #region ���̕ϊ�(Leave�C�x���g)

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
                // �R�[�h��00�ցi�������ɂ�00�̂Ƃ��󔒂ɂ���j
                this._sectionCode = "00";
                sectionName = CT_NAME_ALLSECCODE;
                this.tEdit_SectionName.Text = sectionName;
                this.tNedit_CustomerCode.Focus();
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
                    // 2008.12.09 modify start [8890]
                    sectionName = CT_NAME_ALLSECCODE;
                    this.tEdit_SectionName.Text = sectionName;
                    //this.tEdit_SectionName.Clear();
                    // 2008.12.09 modify end [8890]
                    this.tEdit_SectionCodeAllowZero.Focus(); // ADD 2010/09/21
                }
            }
        }

        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            // ���̕ϊ�
            this._customerCd = this.tNedit_CustomerCode.GetInt();
            string customerName = string.Empty;

            if (_customerCd != 0)
            {
                customerName = this.GetCustomerName(this._customerCd);
                // -------- ADD 2010/09/21 ------>>>>>
                if (isError == true)
                {
                    return;
                }
                // -------- ADD 2010/09/21 ------<<<<<
                if (!String.IsNullOrEmpty(customerName))
                {
                    this.tEdit_CustomerName.Text = customerName;
                }
                else
                {
                    this.tEdit_CustomerName.Clear();
                    // 2008.12.09 add start [8889]
                    this.uButton_CustomerGuide.Focus();
                    // 2008.12.09 add end [8889]
                }
            }
            else
            {
                this.tEdit_CustomerName.Clear();
            }
        }

        #endregion // ���̕ϊ�(Leave�C�x���g)

        #region �A���[�L�[�R���g���[��

        /// <summary>
        /// �A���[�L�[�R���g���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              �e�L�X�g�o�͑Ή�</br>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ���O�ɂ�蕪��
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // �t�B�[���h�Ԉړ�
                //---------------------------------------------------------------

                #region ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        // ------- ADD 2010/09/21 --------------------------------------------------------------->>>>>
                        this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl.GetZeroPaddedText(this.tEdit_SectionCodeAllowZero.Name, this.tEdit_SectionCodeAllowZero.Text);

                        tEdit_SectionCodeAllowZero_Leave(null, null);
                        if (!this.isError)
                        {
                        // ------- ADD 2010/09/21 ---------------------------------------------------------------<<<<<
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_SectionGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                            }
                        // ------- ADD 2010/09/21 --------------------------------------------------------------->>>>>
                        }
                        else
                        {
                            e.NextCtrl = null;
                        }
                        // ------- ADD 2010/09/21 ---------------------------------------------------------------<<<<<
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
                            case Keys.Up:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���_�K�C�h

                #region ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        //if (this.uGrid_Details.Rows.Count > 0)
                                        //{
                                        //    e.NextCtrl = this.uGrid_Details;
                                        //}
                                        //else
                                        //{
                                        e.NextCtrl = uExpandableGroupBox_Condition;// this.tEdit_SectionCodeAllowZero;
                                        //}
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
                #endregion // ���Ӑ�R�[�h

                #region ���Ӑ�K�C�h
                case "uButton_CustomerGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    //if (this.uGrid_Details.Rows.Count > 0)
                                    //{
                                    //    e.NextCtrl = this.uGrid_Details;
                                    //}
                                    //else
                                    //{
                                    e.NextCtrl = uExpandableGroupBox_Condition;
                                    //}
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
                #endregion // ���Ӑ�K�C�h

                default: break;

            }
        }

        #endregion // �A���[�L�[�R���g���[��

        #endregion // �R���g���[�����\�b�h
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        # region �v���C�x�[�g���\�b�h
        /// <summary>
        /// EXCEL�f�[�^�o��
        /// </summary>
        /// <param name="excelFlg">�o�͌`���t���O</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ߔN�x���яƉ��EXCEL�f�[�^�o�͂��܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/19</br>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br> 
        /// <br>Update Note: 2010/10/09 yangmj</br>
        /// <br>            �E�e�L�X�g�o�͑Ή� �s��Ή�#15879</br> 
        /// <br>Update Note: 2024/11/22 ���O</br>
        /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        private void exportIntoExcelData(bool excelFlg)
        {
            //if (this._extractSetupFrm == null) // DEL 2010/09/21
                this._extractSetupFrm = new PMHNB04121UC();
            // �o�͌`��
            this._extractSetupFrm.ExcelFlg = excelFlg;

            this._extractSetupFrm.OutputData += new PMHNB04121UC.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            // �A���[�g�\��
            int logStatus = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // �A���[�g��OK�{�^����������Ȃ��ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, logStatus, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // ���~
                return;
            }
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // --- DEL 2010/10/09 ---------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "���o����";
            //    processingDialog.Message = "���݁A�f�[�^���o���ł��B";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);

            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            //if (this._dataSet.CustomInqResult.Count == 0)
            //{
            //    // �f�[�^�Z�b�g���N���A
            //    this._dataSet.CustomInqResult.Clear();
            //    // �O���b�h���ݒ�
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;

            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "�����ɍ��v����f�[�^�����݂��܂���B",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

            //try
            //{
            //    if (this.ultraGridExcelExporter1.Export(this.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
            //    {
            //        // �f�[�^�Z�b�g���N���A
            //        this._dataSet.CustomInqResult.Clear();
            //        // �O���b�h���ݒ�
            //        InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //        // --------------------- UPD 2010/09/21 ------------>>>>>
            //        this.uGrid_Details.DataSource = _dViewBak;
            //        //if (isSearch)
            //        //{
            //        //    this.Search();
            //        //}
            //        // --------------------- UPD 2010/09/21 ------------<<<<<
            //        // ����
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "EXCEL�f�[�^���o�͂��܂����B",
            //            -1,
            //            MessageBoxButtons.OK);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // �f�[�^�Z�b�g���N���A
            //    this._dataSet.CustomInqResult.Clear();
            //    // �O���b�h���ݒ�
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<

            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        ex.Message,
            //        -1,
            //        MessageBoxButtons.OK);
            //}
            // --- DEL 2010/10/09 ----------<<<<<
        }

        /// <summary>
        /// �e�L�X�g�o��
        /// </summary>
        /// <param name="excelFlg">�o�͌`���t���O</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ߔN�x���яƉ���e�L�X�g�o�͂��܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/19</br>
        /// <br>Update Note: 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή��@�s��Ή�#14643</br>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br> 
        /// <br>Update Note: 2010/10/09 yangmj</br>
        /// <br>            �E�e�L�X�g�o�͑Ή� �s��Ή�#15879</br> 
        /// <br>Update Note : 2024/11/22 ���O</br>
        /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        private void ExportIntoTextFile(bool excelFlg)
        {
            //if (this._extractSetupFrm == null) // DEL 2010/09/21
                this._extractSetupFrm = new PMHNB04121UC();
            // �o�͌`��
            this._extractSetupFrm.ExcelFlg = excelFlg;

            this._extractSetupFrm.OutputData += new PMHNB04121UC.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            // �A���[�g�\��
            int logStatus = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // �A���[�g��OK�{�^����������Ȃ��ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, logStatus, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // ���~
                return;
            }
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // --- DEL 2010/10/09 ---------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "���o����";
            //    processingDialog.Message = "���݁A�f�[�^���o���ł��B";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            //if (this._dataSet.CustomInqResult.Count == 0)
            //{
            //    // �f�[�^�Z�b�g���N���A
            //    this._dataSet.CustomInqResult.Clear();
            //    // �O���b�h���ݒ�
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "�����ɍ��v����f�[�^�����݂��܂���B",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

            //String typeStr = string.Empty;
            //Char typeChar = new char();
            //Byte typeByte = new byte();
            //DateTime typeDate = new DateTime();
            //Int16 typeInt16 = new short();
            //Int32 typeInt32 = new int();
            //Int64 typeInt64 = new long();
            //Single typeSingle = new float();
            //Double typeDouble = new double();
            //Decimal typeDecimal = new decimal();
            //FormattedTextWriter tw = new FormattedTextWriter();

            //Dictionary<int, string> sortList = new Dictionary<int, string>();
            //List<String> schemeList = new List<string>();

            //DataTable targetTable = this._dataSet.CustomInqResult;
            //// -------------------------------------------DEL 2010/09/13 --------------------------------------------------------------------->>>>>
            ////targetTable.Columns["NetSales1"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "�N�x�j";
            ////targetTable.Columns["NetSales2"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "�N�x�j";
            ////targetTable.Columns["NetSales3"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "�N�x�j";
            ////targetTable.Columns["NetSales4"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "�N�x�j";
            ////targetTable.Columns["NetSales5"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "�N�x�j";
            ////targetTable.Columns["NetSales6"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "�N�x�j";
            ////targetTable.Columns["NetSales7"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "�N�x�j";
            ////targetTable.Columns["NetSales8"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear).ToString() + "�N�x�j";
            //// -------------------------------------------DEL 2010/09/13 ---------------------------------------------------------------------<<<<<
            //// -------------------------------------------ADD 2010/09/13 --------------------------------------------------------------------->>>>>
            //targetTable.Columns["NetSales1"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales2"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales3"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales4"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales5"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales6"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales7"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales8"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear).ToString() + "�N�x�j";
            //// -------------------------------------------ADDL 2010/09/13 ---------------------------------------------------------------------<<<<<
            //targetTable.Columns["GrossProfit1"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "�N�x�j";
            //targetTable.Columns["GrossProfit2"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "�N�x�j";
            //targetTable.Columns["GrossProfit3"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "�N�x�j";
            //targetTable.Columns["GrossProfit4"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "�N�x�j";
            //targetTable.Columns["GrossProfit5"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "�N�x�j";
            //targetTable.Columns["GrossProfit6"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "�N�x�j";
            //targetTable.Columns["GrossProfit7"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "�N�x�j";
            //targetTable.Columns["GrossProfit8"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear).ToString() + "�N�x�j";


            //Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            //int dispOrder;
            //string columnName;
            //for (int i = 0; i < Columns.Count; i++)
            //{
            //    if (Columns[i].Hidden == false)
            //    {
            //        dispOrder = Columns[i].Header.VisiblePosition;
            //        columnName = targetTable.Columns[Columns[i].Index].ColumnName;
            //        sortList.Add(dispOrder, columnName);
            //    }
            //}

            //List<int> keyList = new List<int>(sortList.Keys);
            //keyList.Sort();


            //foreach (int key in keyList)
            //{
            //    schemeList.Add(sortList[key]);
            //}

            //// �o�͍��ږ�
            //tw.SchemeList = schemeList;

            //// �f�[�^�\�[�X
            //tw.DataSource = this.uGrid_Details.DataSource;

            //# region [�t�H�[�}�b�g���X�g]
            //Dictionary<string, string> formatList = new Dictionary<string, string>();
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            //{
            //    formatList.Add(col.Key, col.Format);
            //}
            //tw.FormatList = formatList;

            //#endregion // �t�H�[�}�b�g���X�g

            //#region �I�v�V�����Z�b�g
            //// �t�@�C����
            //tw.OutputFileName = this._extractSetupFrm.SettingFileName;
            //// ��؂蕶��
            //tw.Splitter = ",";
            //// ���ڊ��蕶��
            //tw.Encloser = "\"";
            //// �Œ蕝
            //tw.FixedLength = false;
            //// �^�C�g���s�o��
            //tw.CaptionOutput = true;
            //// ���ڊ���K�p
            //List<Type> enclosingList = new List<Type>();
            //enclosingList.Add(typeInt16.GetType());
            //enclosingList.Add(typeInt32.GetType());
            //enclosingList.Add(typeInt64.GetType());
            //enclosingList.Add(typeDouble.GetType());
            //enclosingList.Add(typeDecimal.GetType());
            //enclosingList.Add(typeSingle.GetType());
            //enclosingList.Add(typeStr.GetType());
            //enclosingList.Add(typeChar.GetType());
            //enclosingList.Add(typeByte.GetType());
            //enclosingList.Add(typeDate.GetType());
            //tw.EnclosingTypeList = enclosingList;
            //#endregion

            //int outputCount = 0;
            //int status = tw.TextOut(out outputCount);

            //if (status == 9)// �ُ�I��
            //{
            //    // �f�[�^�Z�b�g���N���A
            //    this._dataSet.CustomInqResult.Clear();
            //    // �O���b�h���ݒ�
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    // �o�͎��s
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
            //}
            //else
            //{
            //    // �f�[�^�Z�b�g���N���A
            //    this._dataSet.CustomInqResult.Clear();
            //    // �O���b�h���ݒ�
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    // �o�͐���
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", -1, MessageBoxButtons.OK);
            //}
            // --- DEL 2010/10/09 ----------<<<<<
        }
        // --- ADD 2010/10/09 ---------->>>>>
                /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note: 2011/02/16 liyp</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br> 
        /// <br>Update Note :2024/11/22 ���O</br>
        /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputTextData()
        {
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            SFCMN00299CA processingDialog = new SFCMN00299CA();
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<
            try
            {
                //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
                // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������u�e�L�X�g�o�́v
                logStatus = TextOutPutWrite((int)OperationCode.TextOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

                // ���O�o�^�ُ�ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // ���~
                    return false;
                }
                //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
                processingDialog.Title = "���o����";
                processingDialog.Message = "���݁A�f�[�^���o���ł��B";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);
                this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);

                // �O���b�h�ŕ\���Ɏg�p����f�[�^�r���[���쐬
                DataView dataView = new DataView(this._dataSet.CustomInqResult);

                // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
                this.uGrid_Details.DataSource = dataView;
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (this._dataSet.CustomInqResult.Count == 0)
            {
                // �f�[�^�Z�b�g���N���A
                this._dataSet.CustomInqResult.Clear();
                // �O���b�h���ݒ�
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�����ɍ��v����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

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

            Dictionary<int, string> sortList = new Dictionary<int, string>();
            List<String> schemeList = new List<string>();

            DataTable targetTable = this._dataSet.CustomInqResult;
            // -------------------------------------------DEL 2010/09/13 --------------------------------------------------------------------->>>>>
            //targetTable.Columns["NetSales1"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales2"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales3"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales4"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales5"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales6"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales7"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "�N�x�j";
            //targetTable.Columns["NetSales8"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear).ToString() + "�N�x�j";
            // -------------------------------------------DEL 2010/09/13 ---------------------------------------------------------------------<<<<<
            // -------------------------------------------ADD 2010/09/13 --------------------------------------------------------------------->>>>>
            targetTable.Columns["NetSales1"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "�N�x�j";
            targetTable.Columns["NetSales2"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "�N�x�j";
            targetTable.Columns["NetSales3"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "�N�x�j";
            targetTable.Columns["NetSales4"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "�N�x�j";
            targetTable.Columns["NetSales5"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "�N�x�j";
            targetTable.Columns["NetSales6"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "�N�x�j";
            targetTable.Columns["NetSales7"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "�N�x�j";
            targetTable.Columns["NetSales8"].Caption = "�ߔN�x���сE������i" + (this._custPastExperienceAcs.FiscalYear).ToString() + "�N�x�j";
            // -------------------------------------------ADDL 2010/09/13 ---------------------------------------------------------------------<<<<<
            targetTable.Columns["GrossProfit1"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "�N�x�j";
            targetTable.Columns["GrossProfit2"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "�N�x�j";
            targetTable.Columns["GrossProfit3"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "�N�x�j";
            targetTable.Columns["GrossProfit4"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "�N�x�j";
            targetTable.Columns["GrossProfit5"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "�N�x�j";
            targetTable.Columns["GrossProfit6"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "�N�x�j";
            targetTable.Columns["GrossProfit7"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "�N�x�j";
            targetTable.Columns["GrossProfit8"].Caption = "�ߔN�x���сE�e���i" + (this._custPastExperienceAcs.FiscalYear).ToString() + "�N�x�j";


            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            int dispOrder;
            string columnName;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Hidden == false)
                {
                    dispOrder = Columns[i].Header.VisiblePosition;
                    columnName = targetTable.Columns[Columns[i].Index].ColumnName;
                    sortList.Add(dispOrder, columnName);
                }
                Columns[i].Format = "";// ADD 2011/02/16
            }

            List<int> keyList = new List<int>(sortList.Keys);
            keyList.Sort();


            foreach (int key in keyList)
            {
                schemeList.Add(sortList[key]);
            }

            // �o�͍��ږ�
            tw.SchemeList = schemeList;

            // �f�[�^�\�[�X
            tw.DataSource = this.uGrid_Details.DataSource;

            # region [�t�H�[�}�b�g���X�g]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                formatList.Add(col.Key, col.Format);
            }
            tw.FormatList = formatList;
            #endregion // �t�H�[�}�b�g���X�g

            #region �I�v�V�����Z�b�g
            // �t�@�C����
            tw.OutputFileName = this._extractSetupFrm.SettingFileName;
            // ��؂蕶��
            tw.Splitter = ",";
            // ���ڊ��蕶��
            tw.Encloser = "\"";
            // �Œ蕝
            tw.FixedLength = false;
            // �^�C�g���s�o��
            tw.CaptionOutput = true;
            // ���ڊ���K�p
            List<Type> enclosingList = new List<Type>();
            enclosingList.Add(typeInt16.GetType());
            enclosingList.Add(typeInt32.GetType());
            enclosingList.Add(typeInt64.GetType());
            enclosingList.Add(typeDouble.GetType());
            enclosingList.Add(typeDecimal.GetType());
            enclosingList.Add(typeSingle.GetType());
            enclosingList.Add(typeStr.GetType());
            enclosingList.Add(typeChar.GetType());
            enclosingList.Add(typeByte.GetType());
            enclosingList.Add(typeDate.GetType());
            tw.EnclosingTypeList = enclosingList;
            #endregion

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);

            if (status == 9)// �ُ�I��
            {
                // �f�[�^�Z�b�g���N���A
                this._dataSet.CustomInqResult.Clear();
                // �O���b�h���ݒ�
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
                // �o�͎��s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // �f�[�^�Z�b�g���N���A
                this._dataSet.CustomInqResult.Clear();
                // �O���b�h���ݒ�
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
                // �o�͐���
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", -1, MessageBoxButtons.OK);

                //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
                // �G���[���b�Z�[�W
                errMsg = string.Empty;
                // ���엚��o�^
                textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
                logStatus = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
                // ���O�o�^�ُ�̏ꍇ�A���O�o�^�ُ탁�b�Z�[�W��\������
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // ���~
                    return false;
                }
                //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

                return true;
            }
        }
        //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
        /// <summary>
        /// �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ�����
        /// </summary>
        /// <param name="mode">���[�h�u�e�L�X�g�o�́F1�@Excel�o�́F2�v</param>
        /// <param name="textOutPutOprtnHisLogWorkObj">�o�^�p�Ώۃ��[�N</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2024/11/22</br>
        /// </remarks>
        private int TextOutPutWrite(int mode, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                string outPutCon = string.Empty;
                textOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
                // ���O�f�[�^�ΏۃA�Z���u��ID
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = CUSTOM_INQ_RESULT_PGID;
                // ���O�f�[�^�ΏۃA�Z���u������
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = AssemblyNm;
                // ���O�f�[�^�ΏۋN���v���O��������
                textOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = AssemblyNm;

                if (mode == (int)OperationCode.TextOut || mode == (int)OperationCode.ExcelOut)
                {
                    if (mode == (int)OperationCode.TextOut)
                    {
                        // �e�L�X�g�o�͂̏ꍇ
                        // ���O�f�[�^�Ώۏ�����:�e�L�X�g�o�̓��\�b�h��
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm;
                    }
                    else
                    {
                        // Excel�o�͂̏ꍇ
                        // ���O�f�[�^�Ώۏ�����:Excel�o�̓��\�b�h��
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm2;
                    }
                }
                // ���O�I�y���[�V�����f�[�^
                // ���_
                string sectionCdSt = this._extractSetupFrm.SectionCodeSt;
                sectionCdSt = string.IsNullOrEmpty(sectionCdSt) ? StartStr : sectionCdSt;
                string sectionCdEd = this._extractSetupFrm.SectionCodeEd;
                sectionCdEd = string.IsNullOrEmpty(sectionCdEd) ? EndStr : sectionCdEd;
                // ���Ӑ�
                string customerCdSt = this._extractSetupFrm.CustomerCodeSt;
                customerCdSt = string.IsNullOrEmpty(customerCdSt) ? StartStr : customerCdSt;
                string customerCdEd = this._extractSetupFrm.CustomerCodeEd;
                customerCdEd = string.IsNullOrEmpty(customerCdEd) ? EndStr : customerCdEd;

                outPutCon = string.Format(Con, sectionCdSt, sectionCdEd, customerCdSt, customerCdEd, this._extractSetupFrm.SettingFileName);
                // ���O�I�y���[�V�����f�[�^
                textOutPutOprtnHisLogWorkObj.LogOperationData = outPutCon;
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }
        //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

        /// <summary>
        /// Excel�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note :2024/11/22 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputExcelData()
        {
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            SFCMN00299CA processingDialog = new SFCMN00299CA();
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
            try
            {
                //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
                // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������u�e�L�X�g�o�́v
                logStatus = TextOutPutWrite((int)OperationCode.ExcelOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

                // ���O�o�^�ُ�ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // ���~
                    return false;
                }
                //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
                processingDialog.Title = "���o����";
                processingDialog.Message = "���݁A�f�[�^���o���ł��B";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);
                this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);
                // �O���b�h�ŕ\���Ɏg�p����f�[�^�r���[���쐬
                DataView dataView = new DataView(this._dataSet.CustomInqResult);

                // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
                this.uGrid_Details.DataSource = dataView;
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (this._dataSet.CustomInqResult.Count == 0)
            {
                // �f�[�^�Z�b�g���N���A
                this._dataSet.CustomInqResult.Clear();
                // �O���b�h���ݒ�
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;

                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�����ɍ��v����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

            try
            {
                if (this.ultraGridExcelExporter1.Export(this.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
                {
                    //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
                    //���O�f�[�^���o�f�[�^����
                    int outputCount = this._dataSet.CustomInqResult.Count;
                    //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<
                    // �f�[�^�Z�b�g���N���A
                    this._dataSet.CustomInqResult.Clear();
                    // �O���b�h���ݒ�
                    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                    // --------------------- UPD 2010/09/21 ------------>>>>>
                    this.uGrid_Details.DataSource = _dViewBak;
                    //if (isSearch)
                    //{
                    //    this.Search();
                    //}
                    // --------------------- UPD 2010/09/21 ------------<<<<<
                    // ����
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "EXCEL�f�[�^���o�͂��܂����B",
                        -1,
                        MessageBoxButtons.OK);

                    //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
                    // �G���[���b�Z�[�W
                    errMsg = string.Empty;
                    // ���엚��o�^
                    textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
                    logStatus = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
                    // ���O�o�^�ُ�̏ꍇ�A���O�o�^�ُ탁�b�Z�[�W��\������
                    if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (!string.IsNullOrEmpty(errMsg))
                        {
                            Form form = new Form();
                            form.TopMost = true;
                            DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                        errMsg, logStatus, MessageBoxButtons.OK);
                            form.TopMost = false;
                        }
                        // ���~
                        return false;
                    }
                    //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<
                }
            }
            catch (Exception ex)
            {
                // �f�[�^�Z�b�g���N���A
                this._dataSet.CustomInqResult.Clear();
                // �O���b�h���ݒ�
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        // --- ADD 2010/10/09 ----------<<<<<
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/19</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TextOutput = 1;
            }
            else
            {
                this._opt_TextOutput = 0;
            }
            #region[�e�L�X�g�o�́AExcel�o��]
            //�e�L�X�g�o�̓I�v�V�������L���̏ꍇ
            if (this._opt_TextOutput == 1)
            {
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Visible = true;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Visible = true;
                //�ݒ���
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = true; //ADD 2010/08/23
            }
            //�e�L�X�g�o�̓I�v�V�����������̏ꍇ
            else
            {
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Visible = false;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Visible = false;
                //�ݒ���
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false; //ADD 2010/08/23

            }
            #endregion
            if (!OpeAuthDictionary[OperationCode.TextOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Shortcut = Shortcut.None;
            }
            if (!OpeAuthDictionary[OperationCode.ExcelOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Shortcut = Shortcut.None;
            }
            if ((!OpeAuthDictionary[OperationCode.TextOut]) && (!OpeAuthDictionary[OperationCode.ExcelOut])) //ADD 2010/08/23
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false; //ADD 2010/08/23
            }
        }
        #endregion // �v���C�x�[�g���\�b�h

        # region [Excel�G�N�X�|�[�^�C�x���g����]
        /// <summary>
        /// �Z���̃R���N�V�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/19</br>
        /// <br>Update Note: 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή��@�s��Ή�#14643</br> 
        private void ultraGridExcelExporter1_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
        {
            int index = e.CurrentRowIndex;
            for (int celIndex = 0; celIndex < 24; celIndex++)
            {
                IWorksheetCellFormat tmCF = e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat;
                tmCF.FormatString = "#,###,##0;-#,###,##0;0";
                e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
                // ------------------ADD 2010/09/13 --------------------------->>>>>
                if (celIndex < 3)
                {
                    e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.Alignment = HorizontalCellAlignment.Left;
                }
                // ------------------ADD 2010/09/13 ---------------------------<<<<<
            }
        }
        # endregion

        // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
    }
}