using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
// --- ADD 2010/07/20-------------------------------->>>>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Infragistics.Excel;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller.Facade;
// --- ADD 2010/07/20--------------------------------<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// �d����N�Ԏ��яƉ�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d����N�Ԏ��яƉ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.12.11</br>
    /// <br>Update Note: 2009.01.28 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10587,10588,10589,10595,10596</br> 
    /// <br>Update Note: 2009.01.29 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10590,10609</br> 
    /// <br>Update Note: 2009.01.30 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10717(���Z��敪�̎擾�������C��)</br> 
    /// <br>Update Note: 2009.02.02 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10701(�d���Ə��d�����t�ɂȂ��Ă����̂��C��)</br>
    /// <br>Update Note: 2009.02.13 30414 �E �K�j</br>
    /// <br>            �E�����擾���@��ύX</br>
    /// <br>Update Note: 2009.02.13 30452 ��� �r��</br>
    /// <br>            �E���В����擾���@��ύX</br>
    /// <br>            �E�x����񍇌v��ݒ�</br>
    /// <br>Update Note: 2009.03.12 30414 �E �K�j</br>
    /// <br>            �E��QID:12299�Ή�</br>
    /// <br>Update Note: 2010/02/18 22008 ���� ���n</br>
    /// <br>            �E�O���t�@�\�̒ǉ�</br>
    /// <br>Update Note: 2010/02/22 980035 ���� ��`</br>
    /// <br>            �E�O���b�h���̃t�H���g�T�C�Y�ύX</br>
    /// <br>Update Note: 2010/03/15 980035 ���� ��`</br>
    /// <br>            �E�O���t�̃f�[�^�e�[�u���̋��z���ڂ�"int"����"double"�ɕύX</br>
    /// <br>            �@(10���̋��z���Z�b�g����Ă��鎞�A�G���[�ɂȂ邽��)</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/30 30517 �Ė� �x��</br>
    /// <br>            �EMANTIS�Ή�15359 �O���t����</br>
    /// <br>Update Note: 2010/07/20 �m�u��</br>
    /// <br>            �E�e�L�X�g�AExcek�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13482</br>
    /// <br>Update Note : 2010/09/08 �k���r</br>
    /// <br>            �E��QID:14443 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note : 2010/09/21 ���i��</br>
    /// <br>            �E��QID:14876 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note : 2010/09/26 tianjw</br>
    /// <br>            : Redmine#14876�Ή�</br>
    /// <br>Update Note: 2010/10/09 tianjw</br>
    /// <br>           : #15881 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/11/01 tianjw</br>
    /// <br>            redmine#16602 �e�L�X�g�o�͑Ή� �s��C��</br>
    /// <br>Update Note :2011/02/16 liyp</br>
    /// <br>             �e�L�X�g�o�͋@�\�̏ꍇ�݂̂̏C��</br>
    /// <br>Update Note : 2012/09/18 FSI���� ���T</br>
    /// <br>              �d���摍���Ή��ɔ����Ή�</br>
    /// <br>Update Note : 2012/11/08 FSI���� ���T</br>
    /// <br>              �c���Ɖ�o�͌��ʂ̏C��</br>
    /// <br>Update Note : 2024/11/22 ���O</br>
    /// <br>              PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// <br></br>
    /// </remarks>
	public partial class PMKOU04110UA : Form
	{
		# region Inner Class
        /// <summary>
        /// �Z�����������N���X�iIMergedCellEvaluator �C���^�t�F�[�X���C���v�������g�j
        /// </summary>
        private class CustomMergedCellEvaluatorRowNo : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>
            /// �Z�������������菈��
            /// </summary>
            /// <param name="row1">�s�P</param>
            /// <param name="row2">�s�Q</param>
            /// <param name="column">��</param>
            /// <returns>��Ɋ֘A�t����ꂽrow1��row2�̃Z�������������ꍇ�ATrue��Ԃ��܂�</returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                string Title1 = row1.Cells["Title"].Value.ToString();
                string Title2 = row2.Cells["Title"].Value.ToString();
                return (true);

                //if ((Title1.Trim() == "") || (Title2.Trim() == "")) return false;
                //return (Title1 == Title2);
            }
        }
        # endregion

        #region �v���C�x�[�g�ϐ�

        /// <summary>�d����N�Ԏ��яƉ� �A�N�Z�X�N���X</summary>
        private SuppYearResultAcs _suppYearResultAcs = null;

        /// <summary>�d����N�Ԏ��яƉ� ���������N���X</summary>
        SuppYearResultCndtn _suppYearResultCndtn = null;

        /// <summary>�d����N�Ԏ��яƉ� �������ʃf�[�^�Z�b�g</summary>
        private InventoryUpdateDataSet _dataSet;

        /// <summary>PMKHN09022A)�d����</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>PMKHN09021E)�d������f�[�^�N���X</summary>
        //private Supplier _supplier = null; // �v���C�x�[�g�ɂ��Ȃ�

        /// <summary>SFSIR09021E)�x���ݒ� �A�N�Z�X�N���X</summary>
        private PaymentSetAcs _paymentSetAcs;

        /// <summary>PMCMN00102A)���ߓ��Z�o���W���[��</summary>
        private TotalDayCalculator _totalDayCalculator;

        private PMKOU04110UC _userSetupFrm = null;              // ���[�U�[�ݒ��� // ADD 2010/02/18

        private PMKOU04110UE _extractSetupFrm = null;           // �o�͏����ݒ��� // ADD 2010/07/20

        private bool isError = false; // ADD 2010/09/26
        // --- DEL 2009/01/30 -------------------------------->>>>>
        ///// <summary>���Z��敪</summary>
        ///// <remarks>�d����}�X�^�̎d����R�[�h=�x����R�[�h�̏ꍇ�͐e(0)�A�����łȂ���Ύq(1)/�����l�͎q�i�c���Ɖ�^�u���J�����Ȃ��j</remarks>
        //private int _accDiv = 1;
        // --- DEL 2009/01/30 --------------------------------<<<<<

        /// <summary>�d�������</summary>
        /// <remarks>�N����</remarks>
        private DateTime _suppTotalDay = DateTime.MinValue;

        /// <summary>�@��N����</summary>
        /// <remarks>�N��</remarks>
        private DateTime _companyBeginDate = DateTime.MinValue;

        /// <summary>�����J�n�N���x</summary>
        /// <remarks>�N��</remarks>
        private DateTime _this_YearMonth = DateTime.MinValue;

        /// <summary>�v��N��</summary>
        /// <remarks>���ݏ������N���i�N���j</remarks>
        private DateTime _addUpYearMonth = DateTime.MinValue;

        /// <summary>���В���</summary>
        /// <remarks>�N����</remarks>
        private DateTime _secTotalDay = DateTime.MinValue;

        /// <summary>�d����N�Ԏ��яƉ� �������ʃf�[�^�Z�b�g</summary>
        private DateTime _baseDate = DateTime.MinValue;

        /// <summary>�d�����z�[�������R�[�h�i���z�̊ۂ߂ɕK�v�j</summary>
        private int _stockPriceFrcProcCd = 0;

        //private PMKOU04110UC _userSetupFrm = null;              // ���[�U�[�ݒ���

        /// <summary>SFKTN09002A)���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>�{�Ћ@�\�t���O</summary>
        private bool _mainOfficeFunc;

        /// <summary>����v�N�x</summary>
        /// <remarks>�J�n���Ɏ��Аݒ肩��擾���A�ύX����܂���</remarks>
        private int _currentFinancialYear;

        /// <summary>��v�N�x</summary>
        private int _financialYear;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>���_�R�[�h�X�^�[�g</summary>
        private string _sectionCodeSt = "";

        /// <summary>���_�R�[�h�I��</summary>
        private string _sectionCodeEnd = "";

        /// <summary>�d����R�[�h�X�^�[�g</summary>
        private Int32 _supplierCdSt;

        /// <summary>�d����R�[�h�I��</summary>
        private Int32 _supplierCdEnd;

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_TextOutput;

        /// <summary>�f�[�^�Z�b�g��null���ǂ����t���O</summary>
        private bool _monthResultNullFlg;
        
        private const int WM_COPYDATA = 0x004A;

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // ���쌠���̐��䃊�X�g(���ڎQ�Ƃ���ƒx���̂Ńf�B�N�V���i����)
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>�N�x�J�n��</summary>
        private int _companyBeginMonth;

        //private bool CustomerCk = false; // DEL 2009/01/30
        //private bool startflg = false; // DEL 2009/01/30

        // 2010/04/30 Add >>>
        private string _befortEditSectionCode = "";
        private string _befortEditSectionName = "";
        private int _beforFinancialYear = 0;
        private int _beforSupplierCode = 0;
        private string _beforSupplierName = "";
        private bool isSearch = false;                          // �����{�^�����N���b�N���邩�ǂ��� // ADD 2010/10/27
        // 2010/04/30 Add <<<

        private bool _checkInputScreenErr = false; // ADD 2010/09/09

        // --- ADD 2012/09/18 ---------->>>>>
        // �d���摍���̃I�v�V�����R�[�h���p�ېݒ�p�t���O
        // true �� �d���摍���g�p����B false �� �d���摍���g�p���Ȃ��B
        private bool _optSuppSumEnable = false;
        // --- ADD 2012/09/18 ----------<<<<<
        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        // ���\�b�h��
        private const string MethodNm = "outputTextData";
        private const string MethodNm2 = "outputExcelData";
        // �o�͌���
        private const string CountNumStr = "�f�[�^�o�͌���:{0},";
        /// <summary>�d����N�Ԏ��яƉ�PGID</summary>
        private const string CT_SUPPLIER_YEAR_RESULT_PGID = "PMKOU04110U";
        // �A�Z���u����
        private const string AssemblyNm = "�d���N�Ԏ��яƉ�";
        // �e�L�X�g��Excel�o�͏���
        private const string Con = "���_:{0} �` {1},�d����:{2} �` {3},�Ώ۔N�x:{4},�o�̓t�@�C����:{5}";
        // �ŏ�����
        private const string StartStr = "�ŏ�����";
        // �Ō�܂�
        private const string EndStr = "�Ō�܂�";
        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        #endregion // �v���C�x�[�g�ϐ�

        #region ��ʐݒ�p

        /// <summary>ControlScreenSkin�N���X</summary>
        private ControlScreenSkin _controlScreenSkin;

        /// <summary>�{�^���C���[�W�p �C���[�W���X�g</summary>
        private ImageList _imageList16 = null;

        #endregion // ��ʐݒ�p

        # region �v���O�����h�c

        /// <summary>�v���O�����h�c</summary>
        public const string programID = "PMKOU04100U";

        # endregion // �v���O�����h�c

        // --- ADD 2010/07/20-------------------------------->>>>>
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
            ExcelOut = 2
        }
        #endregion
        // --- ADD 2010/07/20--------------------------------<<<<<

        #region �R���X�g���N�^
        /// <summary>
        /// �d����N�Ԏ��яƉ�̃R���X�g���N�^�ł��B
		/// </summary>
        /// <remarks>
        /// <br>Update Note: 2024/11/22 ���O</br>
        /// <br>�Ǘ��ԍ�   : 12070203-00</br>
        /// <br>           : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        public PMKOU04110UA()
		{
			InitializeComponent();

        // --- ADD 2010/07/20-------------------------------->>>>>
            this._userSetupFrm = new PMKOU04110UC();

            #region ���I�v�V�������
            this.CacheOptionInfo();
            #endregion
        // --- ADD 2010/07/20--------------------------------<<<<<
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�---->>>>>
            TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs();  //�e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������X�N���X�Ώ�
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�----<<<<<
        }

        /// <summary>
        /// �d�����яƉ�[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKOU04110UA_Load(object sender, EventArgs e)
        {

            #region �A�N�Z�X�N���X�����ݒ�

            // ���_
            this._secInfoSetAcs = new SecInfoSetAcs();

            // �d����
            this._supplierAcs = new SupplierAcs();

            // �x���ݒ�
            this._paymentSetAcs = new PaymentSetAcs();

            // �����擾���W���[��
            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthlyAccPay();  // ���Д��|�����擾����������

            // �R���g���[���X�L��
            this._controlScreenSkin = new ControlScreenSkin();

            #endregion // �A�N�Z�X�N���X�����ݒ�

            // �d���N�Ԏ��яƉ�A�N�Z�X�N���X�������A���ʃf�[�^�Z�b�g�擾
            this._suppYearResultAcs = new SuppYearResultAcs();
            this._dataSet = this._suppYearResultAcs.DataSet;

            #region ���O�C�����擾

            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            #endregion //���O�C�����擾

            // �{��/���_�����擾����
            this._mainOfficeFunc = this.IsMainOfficeFunc();

            #region ��ʐݒ�

            // �{�^���ݒ�
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // �c�[���o�[�{�^���A�C�R���\��
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1; // ADD 2010/02/18

            // --- ADD 2010/07/20-------------------------------->>>>>
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            // --- ADD 2010/07/20--------------------------------<<<<<

            // �{�^���A�C�R���\��
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SupplierGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.Appearance.Image = Size16_Index.STAR1;

            // ���O�C�����\��
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // �X�L�����[�h
            List<string> controlNameList = new List<string>();
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // ��ʐݒ�
            
            // ��v�N�x�擾
            this._suppYearResultAcs.GetCompanyInf(this._enterpriseCode, out this._currentFinancialYear, out this._companyBeginMonth);
            this._financialYear = this._currentFinancialYear;

            // �����l�ݒ�
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);

            // ��ʃN���A
            this.ClearScreen();

            #region �f�[�^�O���b�h�ݒ�

            // --- ADD 2010/07/20-------------------------------->>>>>
            this.ultraGrid_OutPut.DataSource = this._suppYearResultAcs.OutPutDataView;
            InitializeOutGrid(this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns);
            // --- ADD 2010/07/20--------------------------------<<<<<

            // �f�[�^�r���[��ݒ�
            this.uGrid_Result.DataSource = this._suppYearResultAcs.DataView;

            // �f�[�^�O���b�h������
            //InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns); // DEL 2010/07/20
            InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns, true); // ADD 2010/07/20

            // �c���Ɖ�^�u�̏�����
            this.BalanceInquiryInit();

            #endregion // �f�[�^�O���b�h�ݒ�

            // ��ʂ̏����l��ݒ�
            this.tEdit_SectionCode.Text = CT_SECTIONCODE_WHOLE;
            this.tEdit_SectionName.Text = CT_SECTIONNAME_WHOLE;
        }

        /// <summary>
        /// �����t�H�[�J�X�ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PMKOU04110UA_Shown(object sender, System.EventArgs e)
        {
            // ���_�������t�H�[�J�X
            this.tEdit_SectionCode.Focus();
        }

		# endregion

		# region �v���C�x�[�g�ϐ�
        
        
        private const string TOTALDIV_SECT = "���_";
        private const string TOTALDIV_CUST = "���Ӑ�";
        private const string TOTALDIV_SEMP = "�S����";
        private const string TOTALDIV_FEMP = "�󒍎�";
        private const string TOTALDIV_INPU = "���s��";
        private const string TOTALDIV_AREA = "�n��";
        private const string TOTALDIV_TYPE = "�Ǝ�";

        private const int SELECT_CUST = 77;
        private const int SELECT_EMP = 44;
        private const int SELECT_AREA = 44;
        private const int SELECT_TYPE = 44;

		# endregion

        #region �萔

        /// <summary>�萔�F�S�ЃR�[�h�u00�v</summary>
        private const string CT_SECTIONCODE_WHOLE = "00";

        /// <summary>�萔�F�u�S�Ёv</summary>
        private const string CT_SECTIONNAME_WHOLE = "�S��";

        /// <summary>�G���[���b�Z�[�W�F�u�d����R�[�h�̎w�肪�s���ł��B�v</summary>
        private const string CT_INVALID_SUPPLIERCODE = "�d����R�[�h�̎w�肪�s���ł��B";

        /// <summary>�G���[���b�Z�[�W�F�u�N�x�̎w�肪�s���ł��B�v</summary>
        private const string CT_INVALID_FINANCIALYEAR = "�N�x�̎w�肪�s���ł��B";

        /// <summary>�G���[���b�Z�[�W�F�u�Y���f�[�^�����݂��܂���B�v</summary>
        private const string CT_DATA_NOT_FOUND = "�Y���f�[�^�����݂��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�d���N�Ԏ��уf�[�^�̎擾�Ɏ��s���܂����B�v</summary>
        private const string CT_FAILED_TO_GET_RESULT = "�d���N�Ԏ��уf�[�^�̎擾�Ɏ��s���܂����B";

        /// <summary>���b�Z�[�W�F�u���o���v</summary>
        private const string CT_UNDER_PROCESSING_TITLE = "���o��";

        /// <summary>���b�Z�[�W�F�u�d���N�Ԏ��уf�[�^�̒��o���ł��B�v</summary>
        private const string CT_UNDER_PROCESSING = "�d���N�Ԏ��уf�[�^�̒��o���ł��B";

        /// <summary>�G���[���b�Z�[�W�F�u���N�x�͓��͏o���܂���B�v</summary>
        private const string CT_CANNOT_INPUT_FOLLOWING = "���N�x�͓��͏o���܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�{�N�x�̂ݑI���\�ł��B�v</summary>
        private const string CT_SHOW_ONLY_CURRENTYEAR = "�{�N�x�̂ݑI���\�ł��B";

        /// <summary>�G���[���b�Z�[�W�F�u�{�N�x�܂��͍�N�x�̂ݓ��͉\�ł��B�v</summary>
        private const string CT_CAN_INPUT_ONLY_TWICE = "�{�N�x�܂��͍�N�x�̂ݓ��͉\�ł��B";

        /// <summary>�G���[���b�Z�[�W�F�u�x���d����ȊO�͎Q�Ƃł��܂���B�v</summary>
        private const string CT_CANNOT_SHOW_CHILD_SUPPLIER = "�x���d����ȊO�͎Q�Ƃł��܂���B";

        #endregion

        #region �O���b�h�z�F

        /// <summary>�O���b�h �w�b�_�[�J���[1</summary>
        private readonly Color _headerBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>�O���b�h �w�b�_�[�J���[2</summary>
        private readonly Color _headerBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>�O���b�h �����F1</summary>
        private readonly Color _headerForeColor1 = Color.FromArgb(255, 255, 255);

        #endregion // �O���b�h�z�F

        # region �v���C�x�[�g�֐�

        #region �p�����[�^�`�F�b�N

        /// <summary>
        /// �p�����[�^�`�F�b�N
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool CheckParameters(out string message)
        {
            message = string.Empty;

            // �d����R�[�h�i�K�{�j
            if (this.tNedit_SupplierCode.GetInt() == 0)
            {
                message = CT_INVALID_SUPPLIERCODE;
                this.tNedit_SupplierCode.Focus();
                return false;
            }

            // �Ώ۔N�x�i�K�{�j
            if (this.tDateEdit_FinancialYear.GetDateYear() == 0)
            {
                message = CT_INVALID_FINANCIALYEAR;
                this.tDateEdit_FinancialYear.Focus();
                return false;
            }

            return true;
        }

        #endregion // �p�����[�^�`�F�b�N

        #region �p�����[�^�쐬

        /// <summary>
        /// �p�����[�^�쐬
        /// </summary>
        private void GetParameter()
        {
            _suppYearResultCndtn = new SuppYearResultCndtn();

            // ��ƃR�[�h
            _suppYearResultCndtn.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            if (String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()) ||
                this.tEdit_SectionCode.Text.Trim() == CT_SECTIONCODE_WHOLE)
            {
                _suppYearResultCndtn.SectionCode = string.Empty;
                //_suppYearResultCndtn.AccDiv = 1; // DEL 2009/01/29
                //_suppYearResultCndtn.AccDiv = this._accDiv; // ADD 2009/01/29 DEL 2009/01/30
            }
            else
            {
                _suppYearResultCndtn.SectionCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
                // ���Z��敪
                //_suppYearResultCndtn.AccDiv = this._accDiv;// DEL 2009/01/30
            }

            // ���Z��敪
            _suppYearResultCndtn.AccDiv = this.GetAccDiv(); // ADD 2009/01/30

            // �d����R�[�h
            _suppYearResultCndtn.SupplierCd = this.tNedit_SupplierCode.GetInt();

            // �d�������
            _suppYearResultCndtn.SuppTotalDay = this._suppTotalDay;

            // ����N����
            _suppYearResultCndtn.CompanyBiginDate = this._companyBeginDate;

            // �����J�n�N���x
            _suppYearResultCndtn.This_YearMonth = this._this_YearMonth;

            // �v��N��
            _suppYearResultCndtn.AddUpYearMonth = this._addUpYearMonth;

            // ���В���
            _suppYearResultCndtn.SecTotalDay = this._secTotalDay;

        }
        #endregion // �p�����[�^�쐬

        #region ����

        /// <summary>
        /// �d���N�Ԏ��яƉ�f�[�^�̌������s���܂��B
		/// </summary>
        /// <remarks>
        /// <param name="div">��ʋ敪</param>
        /// </remarks>
        /// <returns>STATUS</returns>
        //private int Search() // DEL 2010/07/20
        private int Search(string div) // ADD 2010/07/20
		{

            // �p�����[�^�`�F�b�N
            string errorMessage = string.Empty;
            if (!"SubMain".Equals(div) && !CheckParameters(out errorMessage))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    errorMessage, -1, MessageBoxButtons.OK);
                return -1;
            }
            // ��ʂ���p�����[�^�쐬
            GetParameter();
            // --- ADD 2010/07/20-------------------------------->>>>>
            _suppYearResultCndtn.MainDiv = div;
            if ("SubMain".Equals(div))
            {
                // ���_�R�[�hFrom�`To
                _suppYearResultCndtn.SectionCodeSt = this._sectionCodeSt;
                _suppYearResultCndtn.SectionCodeEnd = this._sectionCodeEnd;

                // �d����R�[�hFrom�`To
                _suppYearResultCndtn.SupplierCdSt = this._supplierCdSt;
                _suppYearResultCndtn.SupplierCdEnd = this._supplierCdEnd;
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            // ���t�Ȃǂ��擾
            DateTime paramDate;
            this._suppYearResultAcs.GetCompanyBeginDate(this._enterpriseCode, this._financialYear, out paramDate);

            // ���t�ݒ���Ď擾
            this._suppYearResultAcs.GetDateParams(this._financialYear, paramDate, this._enterpriseCode);

            // ���������ɓ��t�Ȃǂ�ݒ�
            this._suppYearResultCndtn.CompanyBiginDate = this._suppYearResultAcs.CompanyBeginDate;
            this._suppYearResultCndtn.This_YearMonth = this._suppYearResultAcs.This_YearMonth;

            if (this._financialYear != this._currentFinancialYear)
            {
                // �O�N�̎��͔N�x�I����
                this._suppYearResultCndtn.AddUpYearMonth = this._suppYearResultAcs.CompanyBeginDate.AddYears(1).AddDays(-1);
            }
            else
            {
                this._suppYearResultCndtn.AddUpYearMonth = this._suppYearResultAcs.AddUpYearMonth;
            }

            // -- ADD 2010/02/18 ----------------->>>
            //����N���x���璊�o�̏I���N���x��1�N�𒴂����ꍇ���l���B
            DateTime dt = this._suppYearResultCndtn.This_YearMonth.AddMonths(11);
            if (dt < this._suppYearResultCndtn.AddUpYearMonth)
            {
                //����N������P�N�𒴂����ꍇ�́A�����I�ɂP�Q������̔N���ɂ���
                _suppYearResultCndtn.AddUpYearMonth = dt;
            }
            // -- ADD 2010/02/18 -----------------<<<

            int status = 0;

            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = CT_UNDER_PROCESSING_TITLE;
            msgForm.Message = CT_UNDER_PROCESSING;
			try
			{
				msgForm.Show();	// �_�C�A���O�\��

                // �d�����z�[�������敪��n��
                this._suppYearResultAcs.StockPriceFrcProcCd = this._stockPriceFrcProcCd;

                status = this._suppYearResultAcs.Search(this._suppYearResultCndtn);

            }
			catch (Exception ex)
            {
				TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
					ex.Message,	-1, MessageBoxButtons.OK);
				return -1;
            }
			finally
			{
				msgForm.Close();
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                if (this._dataSet.MonthResult.Rows.Count == 0)
                {
                    // �f�[�^�Z�b�g�ɍs���쐬
                    this._suppYearResultAcs.SetDataSetBase();
                }
                #region ��ʏ�ɓW�J

                // ��ʏ�ɓW�J
                if (this._dataSet.AccPayResult.Rows.Count > 0)
                {
                    DataRow row = this._dataSet.AccPayResult.Rows[0];   // ��s�̂�
                    this.tNedit_bc_1MthMonth.Text = ((Int64)row[this._dataSet.AccPayResult.MonthLastTimeAccPayColumn.ColumnName]).ToString("#,##0");
                    this.tNedit_bc_1MthPayment.Text = ((Int64)row[this._dataSet.AccPayResult.LastTimePaymenColumn.ColumnName]).ToString("#,##0");
                    this.tNedit_bc_2MthPayment.Text = ((Int64)row[this._dataSet.AccPayResult.StockTtl2TmBfBlPayColumn.ColumnName]).ToString("#,##0");
                    this.tNedit_bc_3MthPayment.Text = ((Int64)row[this._dataSet.AccPayResult.StockTtl3TmBfBlPayColumn.ColumnName]).ToString("#,##0");

                    // �`�[����[�x��]
                    this.tNedit_bc_SlipPayment.Text = ((Int32)row[this._dataSet.AccPayResult.StockSlipCountColumn.ColumnName]).ToString("#,##0");
                    // �d��[�x��] = ����d���z
                    this.tNedit_bc_StockPricePayment.Text = ((Int64)row[this._dataSet.AccPayResult.ThisTimeStockPriceColumn.ColumnName]).ToString("#,##0");
                    // ����ԕi���z[�x��] = ����ԕi���z
                    this.tNedit_bc_StckPricRgdsPayment.Text = ((Int64)row[this._dataSet.AccPayResult.ThisStckPricRgdsColumn.ColumnName]).ToString("#,##0");
                    // ����l�����z[�x��] = ����l�����z
                    this.tNedit_bc_StckPricDisPayment.Text = ((Int64)row[this._dataSet.AccPayResult.ThisStckPricDisColumn.ColumnName]).ToString("#,##0");
                    // ���d��[�x��] = ���E�㍡��d�����z
                    this.tNedit_bc_OfsStockPayment.Text = ((Int64)row[this._dataSet.AccPayResult.OfsThisTimeStockColumn.ColumnName]).ToString("#,##0");
                    // �����[�x��] = ���E�㍡��d�������
                    this.tNedit_bc_OfsStockTaxPayment.Text = ((Int64)row[this._dataSet.AccPayResult.OfsThisStockTaxColumn.ColumnName]).ToString("#,##0");

                    // �`�[����[����]
                    this.tNedit_bc_Slip.Text = ((Int32)row[this._dataSet.AccPayResult.MonthStockSlipCountColumn.ColumnName]).ToString("#,##0");
                    // �d��[����] = ��������d���z
                    this.tNedit_bc_StockPrice.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisTimeStockPriceColumn.ColumnName]).ToString("#,##0");
                    // ����ԕi���z[����] = ��������ԕi���z
                    this.tNedit_bc_StckPricRgds.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisStckPricRgdsColumn.ColumnName]).ToString("#,##0");
                    // ����l�����z[����] = ��������l�����z
                    this.tNedit_bc_StckPricDis.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisStckPricDisColumn.ColumnName]).ToString("#,##0");
                    // ���d��[����] = �������E�㍡��d�����z
                    this.tNedit_bc_OfsStock.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOfsThisTimeStockColumn.ColumnName]).ToString("#,##0");
                    // �����[����] = �������E�㍡��d�������
                    this.tNedit_bc_OfsStockTax.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOfsThisStockTaxColumn.ColumnName]).ToString("#,##0");

                    // �`�[����[����]
                    this.tNedit_bc_SlipTerm.Text = ((Int32)row[this._dataSet.AccPayResult.YearStockSlipCountColumn.ColumnName]).ToString("#,##0");
                    // �d��[����] = ��������d���z
                    this.tNedit_bc_StockPriceTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearThisTimeStockPriceColumn.ColumnName]).ToString("#,##0");
                    // ����ԕi���z[����] = ��������ԕi���z
                    this.tNedit_bc_StckPricRgdsTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearThisStckPricRgdsColumn.ColumnName]).ToString("#,##0");
                    // ����l�����z[����] = ��������l�����z
                    this.tNedit_bc_StckPricDisTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearThisStckPricDisColumn.ColumnName]).ToString("#,##0");
                    // ���d��[����] = �������E�㍡��d�����z
                    this.tNedit_bc_OfsStockTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearOfsThisTimeStockColumn.ColumnName]).ToString("#,##0");
                    // �����[����] = �������E�㍡��d�������
                    this.tNedit_bc_OfsStockTaxTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearOfsThisStockTaxColumn.ColumnName]).ToString("#,##0");

                    // �x���c��[�x��] = �d�����v�c���i�x���v�j
                    this.tNedit_bc_TotalPayBalance.Text = ((Int64)row[this._dataSet.AccPayResult.StockTotalPayBalanceColumn.ColumnName]).ToString("#,##0");
                    // �x���c��[����] = �����d�����v�c���i���|�v�j
                    this.tNedit_bc_TtlAccPayBalance.Text = ((Int64)row[this._dataSet.AccPayResult.MonthStckTtlAccPayBalanceColumn.ColumnName]).ToString("#,##0");


                    // �x�����(����)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.CashePaymenColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment01.Text = ((Int64)row[this._dataSet.AccPayResult.CashePaymenColumn.ColumnName]).ToString("#,##0");
                    }
                    // �x�����(�U��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.TrfrPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment02.Text = ((Int64)row[this._dataSet.AccPayResult.TrfrPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �x�����(���؎�)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.CheckKPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment03.Text = ((Int64)row[this._dataSet.AccPayResult.CheckKPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �x�����(��`)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.DraftPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment04.Text = ((Int64)row[this._dataSet.AccPayResult.DraftPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �x�����(���E)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.OffsetPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment05.Text = ((Int64)row[this._dataSet.AccPayResult.OffsetPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- DEL 2012/09/18 ---------------------------->>>>>
                    //// �x�����(�����U��)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment06.Text = ((Int64)row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// �x�����(E-Money)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment07.Text = ((Int64)row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// �x�����(���̑�)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment08.Text = ((Int64)row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    // --- DEL 2012/09/18 ----------------------------<<<<<
                    // --- ADD 2012/09/18 ---------------------------->>>>>
                    // �x�����(���̑�)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment06.Text = ((Int64)row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �x�����(�����U��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment07.Text = ((Int64)row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �x�����(E-Money)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment08.Text = ((Int64)row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2012/09/18 ----------------------------<<<<<
                    // �x�����(�萔��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.ThisTimeFeePayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment09.Text = ((Int64)row[this._dataSet.AccPayResult.ThisTimeFeePayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // �x�����(�l��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.ThisTimeDisPayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment10.Text = ((Int64)row[this._dataSet.AccPayResult.ThisTimeDisPayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 -------------------------------->>>>>
                    // �x�����(���v)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.PaymentInfoSumColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_PaymentSum.Text = ((Int64)row[this._dataSet.AccPayResult.PaymentInfoSumColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 --------------------------------<<<<<

                    // �����x�����(����)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthCashePaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment01c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthCashePaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �����x�����(�U��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment02c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- DEL 2012/09/18 ---------------------------->>>>>
                    //// �����x�����(���؎�)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment03c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    // --- DEL 2012/09/18 ----------------------------<<<<<
                    // --- ADD 2012/09/18 ---------------------------->>>>>
                    // �����x�����(���؎�)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthCheckKPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment03c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthCheckKPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2012/09/18 ----------------------------<<<<<
                    // �����x�����(��`)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthDraftPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment04c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthDraftPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �����x�����(���E)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthOffsetPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment05c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOffsetPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- DEL 2012/09/18 ---------------------------->>>>>
                    //// �����x�����(�����U��)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment06c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// �����x�����(E-Money)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment07c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// �����x�����(���̑�)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment08c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    // --- DEL 2012/09/18 ----------------------------<<<<<
                    // --- ADD 2012/09/18 ---------------------------->>>>>
                    // �����x�����(���̑�)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment06c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �����x�����(�����U��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment07c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // �����x�����(E-Money)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment08c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2012/09/18 ----------------------------<<<<<
                    // �����x�����(�萔��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthThisTimeFeePayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment09c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisTimeFeePayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // �����x�����(�l��)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthThisTimeDisPayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment10c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisTimeDisPayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 -------------------------------->>>>>
                    // �����x�����(���v)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthPaymentInfoSumColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_PaymentSumc.Text = ((Int64)row[this._dataSet.AccPayResult.MonthPaymentInfoSumColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 --------------------------------<<<<<
                }
                #endregion // ��ʏ�ɓW�J

                // --- DEL 2009/02/13 -------------------------------->>>>>
                //// �x�����(���v)
                //this.tNedit_bc_PaymentSum.Text = "0";
                //// �����x�����(���v)
                //this.tNedit_bc_PaymentSumc.Text = "0";
                // --- DEL 2009/02/13 --------------------------------<<<<<

                // --- DEL 2009/01/29 -------------------------------->>>>>
                //// �^�u��������悤��
                //if (this._suppYearResultCndtn.AccDiv == 0)
                //{
                //    this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = true;
                //}
                // --- DEL 2009/01/29 -------------------------------->>>>>
			}
			else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
			{
                this.uGrid_Result.SuspendLayout();
                this._dataSet.MonthResult.Rows.Clear();
                _monthResultNullFlg = true; // ADD 2010/07/20
                this._suppYearResultAcs.SetDataSetBase();
                this.uGrid_Result.ResumeLayout();

                if (!"SubMain".Equals(div)) // ADD 2010/07/20
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        CT_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

				//this.timer_InitFocusSetting.Enabled = true;
			}
			else
			{
                this.uGrid_Result.SuspendLayout();
                this._dataSet.MonthResult.Rows.Clear();
                _monthResultNullFlg = true; // ADD 2010/07/20
                this._suppYearResultAcs.SetDataSetBase();
                this.uGrid_Result.ResumeLayout();

                if (!"SubMain".Equals(div)) // ADD 2010/07/20
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                        CT_FAILED_TO_GET_RESULT, status, MessageBoxButtons.OK);
				//this.timer_InitFocusSetting.Enabled = true;
			}
		

            // test
            //this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = true;
            return 0;
        }

        #endregion // ����

        #region ��ʂ�������

        /// <summary>
		/// ��ʂ����������܂��B
		/// </summary>
		private void ClearScreen()
		{
            // ���_
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tEdit_SectionCode.DataText = CT_SECTIONCODE_WHOLE;
            this.tEdit_SectionName.DataText = CT_SECTIONNAME_WHOLE;

            // �d����
            this.tNedit_SupplierCode.Clear();
            this.tEdit_SupplierName.Clear();

            // �Ώ۔N�x
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);

            // ����
            this.tEdit_PaymentTotalDay.Clear();

            // ����
            this.tEdit_PaymentCondName.Clear();
            this.tEdit_PaymentMonthDivName.Clear();
            this.tEdit_PaymentDay.Clear();

            // �O���t�\���{�^���������Ȃ�����
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;  // ADD 2010/02/18

            // 2009.01.07 add [9774]
            // �f�[�^�Z�b�g���N���A
            this._suppYearResultAcs.ClearDataset();

            // �c���Ɖ�̃^�u�������ݒ�
            this._suppYearResultAcs.SetDataSetBase();

            // --- DEL 2009/01/29 -------------------------------->>>>>
            //// �c���\���^�u���\������Ă���Δ�\����
            //// �^�u��������悤��
            //this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = false;
            // --- DEL 2009/01/29 --------------------------------<<<<<
            // 2009.01.07 add [9774]

            this.isSearch = false; // ADD 2010/10/27

        }

        #endregion // ��ʂ�������

        #region �O���b�h������

        /// <summary>
        /// �O���b�h������
        /// </summary>
        /// <param name="Columns"></param>
        /// <br>Update Note : 2010/09/08 �k���r</br>
        /// <br>            �E��QID:14443 �e�L�X�g�o�͑Ή�</br>
        //private void InitializeGrid(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns) // DEL 2010/07/20
        private void InitializeGrid(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, bool hidleFlg) // ADD 2010/07/20
        {
            this.uLabel_HeaderTitle.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uLabel_HeaderTitle.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraLabel1.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraLabel1.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraLabel2.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraLabel2.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;

            // ��I���{�^����\��
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            // ���z�\��
            string moneyFormat = "#,###,##0;-#,###,##0;0";

            // �t�H���g�T�C�Y�F11
            //int titlWidth = 59;
            //int defoWidth = 95;   //�i11���j
            //int discWidth = 88;   //�i10���j
            //int rateWidth = 57;   //�i 6���j
            // �t�H���g�T�C�Y�F10
            //int titlWidth = 69;
            //int defoWidth = 97;   //�i13���j
            //int discWidth = 88;   //�i10���j
            //int rateWidth = 50;   //�i 6���j
            ////int titlWidth = 61;
            ////int defoWidth = 97;     //�i13���j
            ////int discWidth = 83;     //�i11���j
            ////int rateWidth = 54;     //�i 6���j
            // �t�H���g�T�C�Y�F9
            //int defaultWidth13 = 94;     //�i13���j
            //int titlWidth = 61; // DEL 2009/01/30
            //int discWidth = 94;     //�i13���j // DEL 2009/01/30
            //int rateWidth = 54;     //�i 6���j // DEL 2009/01/30
            // �t�H���g�T�C�Y�F8
            //int defaultWidth13 = 80;     //�i13���j // DEL 2010/02/22
            //int titleWidth = 53;
            //int titleWidth = 45;                    // DEL 2010/02/22
            int titleWidth = 48;
            int defaultWidth13 = 90;     //�i13���jADD 2010/02/22
            int defaultWidth10 = 71;     //�i10���jADD 2010/02/22


            // �S�Ă̗�����������\����
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in Columns)
            {
                col.Hidden = true;
                
                // �w�b�_�ݒ�
                col.Header.Appearance.BackColor = _headerBackColor1;
                col.Header.Appearance.BackColor2 = _headerBackColor2;
                col.Header.Appearance.ForeColor = _headerForeColor1;
                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

                // ���ʕ�����ݒ�
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                //col.CellAppearance.FontData.SizeInPoints = 8f;   // �t�H���g�T�C�Y�ύX// DEL 2010/02/22
                col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX  // ADD 2010/02/22

                col.Format = moneyFormat;
                col.Width = defaultWidth13;
            }

            // �S�Ă̗��ݒ�
            int visiblePosition = 1;

            // �^�C�g����(����/���v/����)
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Width = titleWidth;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Header.Caption = string.Empty;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- ADD 2010/07/20-------------------------------->>>>>
            // --- ADD 2010/09/08-------------------------------->>>>>
            // ���_�R�[�h
            Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Header.Caption = "���_�R�[�h";
            Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Header.Caption = "���_";
            Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���_����
            //Columns[this._dataSet.MonthResult.SectionGuideNmColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.SectionGuideNmColumn.ColumnName].Header.Caption = "���_����";
            //Columns[this._dataSet.MonthResult.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �d����R�[�h
            Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
            Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Header.Caption = "�d����";
            Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �d���於��
            Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Header.Caption = "�d���於��";
            Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Header.Caption = "�d���於";
            Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2010/09/08--------------------------------<<<<<
            // --- ADD 2010/07/20--------------------------------<<<<<

            // �݌Ɂi�d���j
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.Caption = "�d��";
            //Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.Caption = "�d��";
            Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // �݌Ɂi�ԕi�j
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Header.Caption = "�ԕi";
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // �݌Ɂi�l���j
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Header.Caption = "�l��";
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // �݌Ɂi���d���j
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.Caption = "���d��";
            //Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.Caption = "���d��";
            Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // ���i�d���j
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.Caption = "�d��";
            //Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.Caption = "�d��";
            Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // ���i�ԕi�j
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Header.Caption = "�ԕi";
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // ���i�l���j
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Header.Caption = "�l��";
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // ���i���d���j
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.Caption = "���d��";
            //Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.Caption = "���d��";
            Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // ���v�i�d���j
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.Caption = "�d��";
            //Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.Caption = "�d��";
            Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // ���v�i�ԕi�j
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Header.Caption = "�ԕi";
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // ���v�i�l���j
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Header.Caption = "�l��";
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // ���v�i���d���j
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.Caption = "���d��";
            //Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.Caption = "���d��";
            Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // --- ADD 2010/07/20-------------------------------->>>>>
            if(hidleFlg)
            {
            // --- ADD 2010/07/20--------------------------------<<<<<
                // ���v�s�F�ύX
                // --- ADD 2009/01/29 -------------------------------->>>>>
                this.uGrid_Result.DisplayLayout.Rows[12].Appearance.BackColor = Color.LightGray;
                this.uGrid_Result.DisplayLayout.Rows[12].Appearance.BackColor2 = Color.LightGray;
                this.uGrid_Result.DisplayLayout.Rows[13].Appearance.BackColor = Color.LightGray;
                this.uGrid_Result.DisplayLayout.Rows[13].Appearance.BackColor2 = Color.LightGray;
                // --- ADD 2009/01/29 --------------------------------<<<<<
            }
        } // ADD 2010/07/20

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// �O���b�h������
        /// </summary>
        /// <param name="Columns"></param>
        /// <br>Update Note : 2010/09/08 �k���r</br>
        /// <br>            �E��QID:14443 �e�L�X�g�o�͑Ή�</br>
        private void InitializeOutGrid(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {

            // ��I���{�^����\��
            this.ultraGrid_OutPut.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            // ���z�\��
            string moneyFormat = "#,###,##0;-#,###,##0;0";
            int defaultWidth13 = 90;
            int defaultWidth10 = 140;


            // �S�Ă̗�����������\����
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in Columns)
            {
                col.Hidden = true;

                // �w�b�_�ݒ�
                col.Header.Appearance.BackColor = _headerBackColor1;
                col.Header.Appearance.BackColor2 = _headerBackColor2;
                col.Header.Appearance.ForeColor = _headerForeColor1;
                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

                // ���ʕ�����ݒ�
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX

                col.Format = moneyFormat;
                col.Width = defaultWidth13;
            }

            //�N����ݒ�
            int companyBiginMonth = this._companyBeginMonth;
            string[] monthFlg = new string[12];
            for (int ix = 0; ix < 12; ix++)
            {
                int biginMonth = companyBiginMonth + ix;
                if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                monthFlg[ix] = biginMonth.ToString() + "��";
            }

            // �S�Ă̗��ݒ�
            int visiblePosition = 1;
            // --- ADD 2010/09/08-------------------------------->>>>>
            // ���_�R�[�h
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Header.Caption = "���_�R�[�h";
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Header.Caption = "���_";
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���_����
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].Header.Caption = "���_����";
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �d����R�[�h
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Header.Caption = "�d����";
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �d���於��
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Header.Caption = "�d���於��";
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Header.Caption = "�d���於";
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2010/09/08--------------------------------<<<<<
            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�d��
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.Caption = "�������сE�d��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�ԕi
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE�l��
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // �������сE���d��
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Header.Caption = "�������сE���d��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�d��
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�d��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�ԕi
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�ԕi(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE�l��
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Header.Caption = "�݌ɁE�l��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // �݌ɁE���d��
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Header.Caption = "�݌ɁE���d��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.Caption = "���E�d��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�ԕi
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.Caption = "���E�ԕi(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E�l��
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Header.Caption = "���E�l��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // ���E���d��
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Header.Caption = "���E���d��(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Width = defaultWidth10;

        }
        // --- ADD 2010/07/20--------------------------------<<<<<


        /// <summary>
        /// GRID�̏��������s���܂��B
        /// </summary>
        private void ViewGrid()
        {
            //this._suppYearResultAcs.Clear();
            //this._suppYearResultAcs.SetDataSetBase(this.tDateEdit_FinancialYear.GetDateYear(),this.tComboEditor_TotalDiv.SelectedIndex);
            //if (this.tDateEdit_FinancialYear.GetDateYear() == this._financialYear)
            //{
            //    this.ultraLabel1.Text = "��������";
            //}
            //else
            //{
            //    this.ultraLabel1.Text = "�Ώ۔N�x����";
            //}


        }

        #endregion // �O���b�h������

        #region �O���t�\��

        /// <summary>
		/// �O���t�̕\�����s���܂�
		/// </summary>
        private void ViewGraph()
        {
            #region �폜
            //if ((this._resultData == null) || (this._resultData.MonthResult.Count == 0)) return;

            //// ���ʏ�������ʐ���
            //SFCMN00299CA progressForm = new SFCMN00299CA();
            //progressForm.DispCancelButton = false;
            //progressForm.Title = "���̓`���[�g�쐬��";
            //progressForm.Message = "���݁A���̓`���[�g�쐬���ł��D�D�D";

            //try
            //{
            //    // ���ʏ�������ʕ\��
            //    progressForm.Show();

            //    // �^�u�y�[�W�Ɋ��ɃR���g���[�����L��ꍇ�̓N���A����
            //    if (this.ultraTabPageControl2.Controls.Count > 0)
            //    {
            //        this.ultraTabPageControl2.Controls.Remove(this.ultraTabPageControl2.Controls[0]);
            //    }

            //    AnalysisChartViewForm viewForm = new AnalysisChartViewForm(this);
            //    viewForm.TopLevel = false;
            //    viewForm.FormBorderStyle = FormBorderStyle.None;
            //    viewForm.ShowMe(this._resultData);

            //    // �^�u�y�[�W�ɕ��̓`���[�g�r���[�t�H�[����ǉ�
            //    ultraTabPageControl2.Controls.Add(viewForm);
            //    viewForm.Dock = DockStyle.Fill;

            //    this.utc_InventTab.Tabs["GraphTab"].Visible = true;
            //    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
            //    //this.utc_InventTab.Scroll(Infragistics.Win.UltraWinTabs.ScrollType.First);
            //}
            //catch (Exception ex)
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "�^�u��ʂ̏������Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            //}
            //finally
            //{
            //    // ���ʏ�������ʏI��
            //    progressForm.Close();
            //}
            #endregion

            // -- ADD 2010/02/18 --------------------------->>>
            if ((this._dataSet == null) || (this._dataSet.MonthResult.Count == 0)) return;

            // ���ʏ�������ʐ���
            SFCMN00299CA progressForm = new SFCMN00299CA();
            progressForm.DispCancelButton = false;
            progressForm.Title = "���̓`���[�g�쐬��";
            progressForm.Message = "���݁A���̓`���[�g�쐬���ł��D�D�D";

            try
            {
                // ���ʏ�������ʕ\��
                progressForm.Show();

                // �^�u�y�[�W�Ɋ��ɃR���g���[�����L��ꍇ�̓N���A����
                if (this.ultraTabPageControl2.Controls.Count > 0)
                {
                    this.ultraTabPageControl2.Controls.Remove(this.ultraTabPageControl2.Controls[0]);
                }

                AnalysisChartViewForm viewForm = new AnalysisChartViewForm(this);
                viewForm.TopLevel = false;
                viewForm.FormBorderStyle = FormBorderStyle.None;
                viewForm.ShowMe(this._dataSet);

                // �^�u�y�[�W�ɕ��̓`���[�g�r���[�t�H�[����ǉ�
                ultraTabPageControl2.Controls.Add(viewForm);
                viewForm.Dock = DockStyle.Fill;

                this.utc_InventTab.Tabs["GraphTab"].Visible = true;
                //this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
                this.utc_InventTab.SelectedTab = this.utc_InventTab.Tabs["GraphTab"];

                //this.utc_InventTab.Scroll(Infragistics.Win.UltraWinTabs.ScrollType.First);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "�^�u��ʂ̏������Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                // ���ʏ�������ʏI��
                progressForm.Close();
            }
            // -- ADD 2010/02/18 ---------------------------<<<

        }

        #endregion �O���t�\��

        // --- ADD 2009/01/30 -------------------------------->>>>>
        #region ���Z��敪�擾
        /// <summary>
        /// ���Z��敪�擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>0:�x���d����(�c���Ɖ��)�A1:�x���d����łȂ�</remarks>
        private int GetAccDiv()
        {
            if (String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim())
                || this.tNedit_SupplierCode.GetInt() == 0)
            {
                // ���_�A�d����̓��͂�������Ύq(1)
                return 1;
            }

            Supplier supplier;

            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCode.GetInt());

            if (status == 0)
            {
                if (supplier.MngSectionCode.TrimEnd() == this.tEdit_SectionCode.Text
                    && supplier.MngSectionCode == supplier.PaymentSectionCode
                    && supplier.SupplierCd == supplier.PayeeCode)
                {
                    // �u�Ǘ����_=��ʎw��̋��_�v���u�Ǘ����_=�x�����_�v���u�d����R�[�h=�x����R�[�h�v
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
        #endregion

        #endregion
        // --- ADD 2009/01/30 --------------------------------<<<<<

        # region �e��R���g���[���C�x���g����

        #region �t�H�[�J�X�R���g���[��

        /// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note : 2010/09/21 ���i��</br>
        /// <br>            : Redmine#14876�Ή�</br>
        /// <br>Update Note : 2010/09/26 tianjw</br>
        /// <br>            : Redmine#14876�Ή�</br>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

            //// �t�H�[�J�X���� ============================================ //
            //if ((e.PrevCtrl == this.tNedit_SupplierCode) ||
            //    (e.PrevCtrl == this.tEdit_EmployeeCode) ||
            //    (e.PrevCtrl == this.uButton_SupplierGuide))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        e.NextCtrl = e.PrevCtrl;
            //    }
            //}
            //if ((this.tNedit_SupplierCode.Visible == false) && (this.tEdit_EmployeeCode.Visible == false) &&
            //   ((e.PrevCtrl == this.tEdit_SectionCode) || (e.PrevCtrl == this.uButton_SectionGuide)))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        e.NextCtrl = e.PrevCtrl;
            //    }
            //}

			// ���̎擾 ============================================ //
            switch (e.PrevCtrl.Name)
            {
                #region ���_�R�[�h
                case "tEdit_SectionCode":
                    {
                        //string code = this.tEdit_SectionCode.Text.PadLeft(2, '0'); // DEL 2010/09/26
                        string code = this.tEdit_SectionCode.Text.Trim(); // ADD 2010/09/26
                        string name = CT_SECTIONNAME_WHOLE;
                        this._checkInputScreenErr = false;
                        if (code != "")
                        {
                            SecInfoSet secInfoSet;
                            int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, code);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // --------UPD 2010/09/21-------->>>>>
                                //code = sectionInfo.SectionCode.TrimEnd();
                                //name = sectionInfo.SectionGuideSnm.TrimEnd();
                                //return true;

                                if (secInfoSet.LogicalDeleteCode != 0)
                                {
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���_�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    isError = true; // 2010/09/26
                                    // �R�[�h�߂�
                                    this.tEdit_SectionCode.Text = _befortEditSectionCode;
                                    this.tEdit_SectionName.Text = _befortEditSectionName;
                                    this.tEdit_SectionCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    _checkInputScreenErr = true;
                                    return;
                                }
                                else
                                {
                                    code = secInfoSet.SectionCode.TrimEnd();
                                    name = secInfoSet.SectionGuideSnm.TrimEnd();
                                }
                                // --------UPD 2010/09/21--------<<<<<
                                // 2010/04/30 Add >>>
                                if (this._befortEditSectionCode.Equals(code) == false)
                                {
                                    this.BalanceInquiryInit();
                                    this._suppYearResultAcs.ClearDataset();
                                    this._suppYearResultAcs.SetDataSetBase();
                                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                    this._befortEditSectionCode = code;
                                    this._befortEditSectionName = name;
                                }
                                // 2010/04/30 Add <<<
                                name = secInfoSet.SectionGuideNm.Trim();

                                //status = GetTotalDay(code); // DEL 2009/02/13

                                // --- ADD 2009/02/13 -------------------------------->>>>>
                                // ���������擾
                                if (this.tNedit_SupplierCode.GetInt() != 0)
                                {
                                    status = GetTotalDay(code, this.tNedit_SupplierCode.GetInt());
                                }
                                // --- ADD 2009/02/13 --------------------------------<<<<<
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                    "���_�����݂��܂���B", -1, MessageBoxButtons.OK);
                                isError = true; // 2010/09/26
                                code = CT_SECTIONCODE_WHOLE;
                                this.tEdit_SectionCode.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                    "���_�̎擾�Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
                                code = CT_SECTIONCODE_WHOLE;
                            }
                        }
                        else
                        {
                            code = CT_SECTIONCODE_WHOLE;
                        }
                        // �R�[�h�E���̃Z�b�g
                        this.tEdit_SectionCode.Text = code;
                        this.tEdit_SectionName.Text = name;
                        this._befortEditSectionCode = code;
                        this._befortEditSectionName = name;

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SectionGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_SupplierCode;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���_�R�[�h

                #region �d����R�[�h
                case "tNedit_SupplierCode":
                    {
                        int code = this.tNedit_SupplierCode.GetInt();
                        string name = "";
                        this._checkInputScreenErr = false;
                        if (code > 0)
                        {
                            Supplier supplier;
                            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // --------UPD 2010/09/21-------->>>>>

                                if (supplier.LogicalDeleteCode != 0)
                                {
                                    // �G���[��
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "�d����R�[�h�����݂��܂���B", -1, MessageBoxButtons.OK);

                                    isError = true; // 2010/09/26
                                    // �R�[�h�߂�
                                    this.tNedit_SupplierCode.Text = this._beforSupplierCode + "";
                                    this.tEdit_SupplierName.Text = this._beforSupplierName;
                                    this.tNedit_SupplierCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    _checkInputScreenErr = true;
                                    return;
                                }
                                else
                                {
                                    code = supplier.SupplierCd;
                                    name = supplier.SupplierSnm.TrimEnd();
                                }
                                // --------UPD 2010/09/21--------<<<<<

                                // 2010/04/30 Add >>>
                                if (this._beforSupplierCode.Equals(code) == false)
                                {
                                    this.BalanceInquiryInit();
                                    this._suppYearResultAcs.ClearDataset();
                                    this._suppYearResultAcs.SetDataSetBase();
                                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                }
                                // 2010/04/30 Add <<<
                                this._beforSupplierCode = code;
                                this._beforSupplierName = name;
                                this.tNedit_SupplierCode.SetInt(code);
                                this.tEdit_SupplierName.Text = name;

                                // ���Z��敪���擾
                                GetSettingFromSupplierInfo(supplier);

                                // --- ADD 2009/02/13 -------------------------------->>>>>
                                // ���������擾
                                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
                                {
                                    status = GetTotalDay(this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0'), supplier.SupplierCd);
                                }
                                // --- ADD 2009/02/13 --------------------------------<<<<<
                            }
                            else
                            {
                                // --- ADD 2009/01/28 -------------------------------->>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "�d����R�[�h�����݂��܂���B", -1, MessageBoxButtons.OK);
                                    isError = true; // 2010/09/26
                                }
                                else
                                {
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "�d����R�[�h�̎擾�Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
                                }
                                // --- ADD 2009/01/28 --------------------------------<<<<<

                                this.tNedit_SupplierCode.Clear();
                                this.tEdit_SupplierName.Clear();

                                // �d���悩��擾�����������Z�b�g
                                GetSettingFromSupplierInfo(null);
                            }
                        }
                        else
                        {
                            // 2009.01.05 add [9652]
                            this.tEdit_SupplierName.Clear();
                            GetSettingFromSupplierInfo(null);
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_SupplierCode.Text.Trim())) // 2009.01.05 [9651]
                                    {
                                        e.NextCtrl = this.uButton_SupplierGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tDateEdit_FinancialYear;
                                    }

                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �d����R�[�h

                #region �Ώ۔N�x
                case "tDateEdit_FinancialYear":
                    {
                        int year = this.tDateEdit_FinancialYear.GetDateYear();
                        if (year == 0)
                        {
                            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            // 2010/04/30 Add >>>
                            if (this._beforFinancialYear.Equals(year) == false)
                            {
                                this.BalanceInquiryInit();
                                this._suppYearResultAcs.ClearDataset();
                                this._suppYearResultAcs.SetDataSetBase();
                                this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                                this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                this._beforFinancialYear = year;
                            }
                            // 2010/04/30 Add <<<
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCode;
                                    }
                                    break;
                            }
                        }
                        break;
                    }

                #endregion // �Ώ۔N�x
            }
        }

        #endregion // �t�H�[�J�X�R���g���[��

        #region �c�[���o�[

        /// <summary>
		/// �c�[���o�[�c�[���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note : 2010/09/21 ���i��</br>
        /// <br>            : Redmine#14876�Ή�</br>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
            {
                #region ����
                case "ButtonTool_Close":
				    {
					    this.Close();
					    break;
                    }
                #endregion // ����

                #region �N���A
                case "ButtonTool_Clear":
				    {
                        this.ViewGrid();
                        //this.ShipmentInit();
                        this.BalanceInquiryInit();
					    this.ClearScreen();
					    this.timer_InitFocusSetting.Enabled = true;

                        //this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;  // ADD 2010/02/18
                        this.isSearch = false; // ADD 2010/10/27
                        break;
                    }
                #endregion // �N���A

                #region ����
                case "ButtonTool_Search":
				    {
                        //this.SetDataSetBase();
                        //this.ShipmentInit();
                        //this.BalanceInquiryInit();
                        // 2010/04/30 >>>
                        //this.Search();
                        //int status = this.Search(); // DEL 2010/07/20

                        this.isSearch = true; // ADD 2010/10/27
                        // ---------------UPD 2010/09/21--------------<<<<<
                        if (this.tEdit_SectionCode.Focused)
                        {
                            ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCode, this.tNedit_SupplierCode);
                            this.tEdit_SectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SectionCode.Name, this.tEdit_SectionCode.Text);
                            tArrowKeyControl1_ChangeFocus(null, eArgs);
                            if (isError == true)
                            {
                                isError = false;
                                return;
                            }
                        }

                        if (this.tNedit_SupplierCode.Focused)
                        {
                            ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_SupplierCode, this.tDateEdit_FinancialYear);
                            this.tDateEdit_FinancialYear.Text = this.uiSetControl1.GetZeroPaddedText(this.tDateEdit_FinancialYear.Name, this.tDateEdit_FinancialYear.Text);
                            tArrowKeyControl1_ChangeFocus(null, eArgs);
                            if (isError == true)
                            {
                                isError = false;
                                return;
                            }
                        }

                        if (!_checkInputScreenErr)
                        {
                            int status = this.Search("Main"); // ADD 2010/07/20
                            // 2010/04/30 <<<

                            //this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                            this.utc_InventTab.Tabs["GraphTab"].Visible = false;  // ADD 2010/02/18
                            this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = true;
                            if (status == 0)   // 2010/04/30 Add
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = true; // ADD 2010/02/18
                        }
                        // ---------------UPD 2010/09/21-------------->>>>>
                            break;
                    }
                #endregion // ����

                // --- DEL 2009/01/28 -------------------------------->>>>>
                //#region �O���t�\��
                //case "ButtonTool_Graph":
                //    {
                //        this.ViewGraph();
                //        this.utc_InventTab.Focus();
                //        break;
                //    }
                //#endregion // �O���t�\��

                //#region �ݒ�
                //case "ButtonTool_Setup":
                //    {
                //        //if (this._userSetupFrm == null)
                //        //    this._userSetupFrm = new PMKOU04110UC();

                //        //this._userSetupFrm.ShowDialog();
                //        break;
                //    }
                //#endregion // �ݒ�
                // --- DEL 2009/01/28 --------------------------------<<<<<

                // -- ADD 2010/02/18 ------------------->>>
                #region �O���t�\��
                case "ButtonTool_Graph":
                    {
                        this.ViewGraph();
                        this.utc_InventTab.Focus();
                        break;
                    }
                #endregion // �O���t�\��
                #region �ݒ�
                case "ButtonTool_Setup":
                    {
                        if (this._userSetupFrm == null)
                            this._userSetupFrm = new PMKOU04110UC();

                        this._userSetupFrm.ShowDialog();
                        break;
                    }
                #endregion // �ݒ�
                // -- ADD 2010/02/18 -------------------<<<
                // --- ADD 2010/07/20-------------------------------->>>>>
                case "ButtonTool_Text":
                    {
                        this.ExportIntoTextFile(false);
                        break;
                    }
                case "ButtonTool_Excel":
                    {
                        this.ExportIntoExcelFile(true);
                        break;
                    }
                // --- ADD 2010/07/20--------------------------------<<<<<

            }
        }

        #endregion // �c�[���o�[

        #region �K�C�h�{�^��

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                this.tEdit_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                // 2010/04/30 Add >>>
                string code = this.tEdit_SectionCode.Text.Trim();
                string name = this.tEdit_SectionName.Text.Trim();
                if (this._befortEditSectionCode.Equals(code) == false)
                {
                    this.BalanceInquiryInit();
                    this._suppYearResultAcs.ClearDataset();
                    this._suppYearResultAcs.SetDataSetBase();
                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                    this._befortEditSectionCode = code;
                    this._befortEditSectionName = name;
                }
                // 2010/04/30 Add <<<
                
                // ���_���Ƃ̒��ߓ����擾
                //GetTotalDay(secInfoSet.SectionCode.Trim().PadLeft(2, '0')); // DEL 2009/02/13
                // --- ADD 2009/02/13 -------------------------------->>>>>
                if (this.tNedit_SupplierCode.GetInt() != 0)
                {
                    this.GetTotalDay(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), this.tNedit_SupplierCode.GetInt());
                }
                // --- ADD 2009/02/13 --------------------------------<<<<<
            }
            // --- DEL 2009/01/28 -------------------------------->>>>>
            //else
            //{
            //    GetTotalDay(CT_SECTIONCODE_WHOLE);
            //}
            // --- DEL 2009/01/28 --------------------------------<<<<<
        }

        /// <summary>
        /// �d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�\��
            int status = 0;
            Supplier supplier;
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
            {
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0'));
            }
            else
            {
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, CT_SECTIONCODE_WHOLE);
            }

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCode.SetInt(supplier.SupplierCd);
                this.tEdit_SupplierName.Text = supplier.SupplierSnm.Trim();

                // 2010/04/30 Add >>>
                int code = this.tNedit_SupplierCode.GetInt();
                if (this._beforSupplierCode.Equals(code) == false)
                {
                    this.BalanceInquiryInit();
                    this._suppYearResultAcs.ClearDataset();
                    this._suppYearResultAcs.SetDataSetBase();
                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                    this._beforSupplierCode = code;
                }
                // 2010/04/30 Add <<<
                
                // ���Z��敪���擾
                GetSettingFromSupplierInfo(supplier);

                // --- ADD 2009/02/13 -------------------------------->>>>>
                // ���_���Ƃ̒��ߓ����擾
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
                {
                    this.GetTotalDay(this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0'), supplier.SupplierCd);
                }
                // --- ADD 2009/02/13 --------------------------------<<<<<
            }
            // --- DEL 2009/01/28 -------------------------------->>>>>
            //else
            //{
            //    this.tNedit_SupplierCode.Clear();
            //    this.tEdit_SupplierName.Text = "";

            //    // �d���悩��擾�����������Z�b�g
            //    GetSettingFromSupplierInfo(null);
            //}
            // --- DEL 2009/01/28 --------------------------------<<<<<
        }

        #endregion // �K�C�h�{�^��

        #region �f�[�^�O���b�h�C�x���g

        /// <summary>
        /// �f�[�^�O���b�h�Z���A�N�e�B�u��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// �f�[�^�O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_Enter(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Result.ActiveRow;


            if (this.uGrid_Result.Rows.Count > 0)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                this.uGrid_Result.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// �f�[�^�O���b�h���[�u�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_Leave(object sender, EventArgs e)
        {
            this.uStatusBar_Main.Text = "";
        }



        /// <summary>
        /// �f�[�^�O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.uGrid_Result.ActiveRow != null)
                        {
                            if (this.uGrid_Result.ActiveRow.Index == 0)
                            {
                                //this.tDateEdit_InventoryDayStart.Focus();
                            }
                        }

                        break;
                    }
            }
        }

        #endregion

        #region �{�Ћ@�\�^���_�@�\�`�F�b�N����

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        private bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (secInfoSet.MainOfficeFuncFlag == 1) // �{�Ћ@�\���H
                {
                    isMainOfficeFunc = true;
                }
            }

            return isMainOfficeFunc;
        }

        #endregion // �{�Ћ@�\�^���_�@�\�`�F�b�N����

        #region ���_�R�[�h������������擾

        /// <summary>
        /// ���_�R�[�h������������擾
        /// </summary>
        /// <param name="sectionCd"></param>
        /// <returns></returns>
        //private int GetTotalDay(string sectionCd) // DEL 2009/02/13
        private int GetTotalDay(string sectionCd, int supplierCd) // ADD 2009/02/13
        {
            int status = 0;

            // �S�ЃR�[�h����ы󔒂͒��������Z�b�g
            if (sectionCd == CT_SECTIONCODE_WHOLE || String.IsNullOrEmpty(sectionCd))
            {
                // --- DEL 2012/11/08 ---------->>>>>
                //this._secTotalDay = DateTime.MinValue;

                //return -1;
                // --- DEL 2012/11/08 ----------<<<<<
                // --- ADD 2012/11/08 ---------->>>>>
                // �S�ЃR�[�h���w�肳�ꂽ�ꍇ�ɂ͋��_�R�[�h���󕶎��w��Œ����擾�����s����
                DateTime prevTotalDay;
                status = this._suppYearResultAcs.GetTotalDayMonthlyAccPay(this._enterpriseCode, "", supplierCd, out prevTotalDay);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._secTotalDay = prevTotalDay;
                }
                // --- ADD 2012/11/08 ----------<<<<<
            }
            else
            {
                DateTime prevTotalDay;
                //status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCd, out prevTotalDay); // DEL 2009/02/13
                // --- DEL 2012/11/08 ---------->>>>>
                //status = this._totalDayCalculator.GetTotalDayMonthlyAccPay(sectionCd, supplierCd, out prevTotalDay); // ADD 2009/02/13
                // --- DEL 2012/11/08 ----------<<<<<
                // --- ADD 2012/11/08 ---------->>>>>
                status = this._suppYearResultAcs.GetTotalDayMonthlyAccPay(this._enterpriseCode, sectionCd, supplierCd, out prevTotalDay);
                // --- ADD 2012/11/08 ----------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._secTotalDay = prevTotalDay;
                }
            }
            return status;
        }

        #endregion // ���_�R�[�h������������擾

        #region �d�����񂩂�e��ݒ�l���擾

        /// <summary>
        /// �d�����񂩂�e��ݒ�l���擾
        /// </summary>
        /// <param name="supplier">�d������N���X</param>
        /// <remarks>������Null�̏ꍇ�͐ݒ�l���N���A�̂ݍs��</remarks>
        private void GetSettingFromSupplierInfo(Supplier supplier)
        {
            //// �p�����[�^��������
            //this._accDiv = 1;   // �q // DEL 2009/01/30

            // �������N���A
            this.tEdit_PaymentTotalDay.Clear();

            // �x�����������N���A
            this.tEdit_PaymentMonthDivName.Clear();
            this.tEdit_PaymentDay.Clear();
            this.tEdit_PaymentCondName.Clear();

            // �������܂ł͍s��
            if (supplier == null) return;

            // --- DEL 2009/01/30 -------------------------------->>>>>
            //// ���Z�敪�`�F�b�N
            //if (supplier.SupplierCd == supplier.PayeeCode)
            //{
            //    this._accDiv = 0;
            //}
            // --- DEL 2009/01/30 --------------------------------<<<<<

            // �x������
            this.tEdit_PaymentTotalDay.Text = supplier.PaymentTotalDay.ToString() + "��";

            // �x��������
            // �x�����敪����
            this.tEdit_PaymentMonthDivName.Text = supplier.PaymentMonthName;
            // �x����
            this.tEdit_PaymentDay.Text = supplier.PaymentDay.ToString() + "��";
            // �x������
            int paymentCondCode = supplier.PaymentCond;
            string paymentCondName = string.Empty;
            this._suppYearResultAcs.GetMoneyKindName(paymentCondCode, out paymentCondName, this._enterpriseCode);
            this.tEdit_PaymentCondName.Text = paymentCondName;

            // �v���C�x�[�g�ϐ��ɒl���Z�b�g(�p�����[�^�ɃZ�b�g�����̂�GetParameter()�̃^�C�~���O)
            // �d����̍ŏI���N����
            // --- CHG 2009/02/13 �����擾���@�ύX------------------------------------------------------>>>>>
            //int status = this._totalDayCalculator.GetTotalDayMonthlyAccPay(supplier.SupplierCd, out this._suppTotalDay);
            int status = this._totalDayCalculator.GetTotalDayPayment(supplier.SupplierCd, out this._suppTotalDay);
            // --- CHG 2009/02/13 �����擾���@�ύX------------------------------------------------------<<<<<

            // �d�����z�[�������R�[�h
            this._stockPriceFrcProcCd = supplier.StockMoneyFrcProcCd;
        }

        #endregion // �d�����񂩂�e��ݒ�l���擾

        #region �x���������N���A����

        /// <summary>
        /// �x���������N���A����
        /// </summary>
        private void CollectMoneySelect()
        {
            this.tEdit_PaymentTotalDay.DataText = "";
            this.tEdit_PaymentMonthDivName.DataText = "";
            this.tEdit_PaymentDay.DataText = "";
            this.tEdit_PaymentCondName.DataText = "";
        }

        #endregion // �x���������N���A����

        #region �c���Ɖ�^�u�ݒ�

        /// <summary>
        /// �c���Ɖ�^�u�ݒ�
        /// </summary>
        private void BalanceInquiryInit()
        {
            #region �x�����̐ݒ�

            PaymentSet paymentSet;
            int status = this._paymentSetAcs.Read(out paymentSet, this._enterpriseCode, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.lblPayment01.Text = paymentSet.PayStMoneyKindNm1.Replace("���o�^", string.Empty);
                this.lblPayment02.Text = paymentSet.PayStMoneyKindNm2.Replace("���o�^", string.Empty);
                this.lblPayment03.Text = paymentSet.PayStMoneyKindNm3.Replace("���o�^", string.Empty);
                this.lblPayment04.Text = paymentSet.PayStMoneyKindNm4.Replace("���o�^", string.Empty);
                this.lblPayment05.Text = paymentSet.PayStMoneyKindNm5.Replace("���o�^", string.Empty);
                this.lblPayment06.Text = paymentSet.PayStMoneyKindNm6.Replace("���o�^", string.Empty);
                this.lblPayment07.Text = paymentSet.PayStMoneyKindNm7.Replace("���o�^", string.Empty);
                this.lblPayment08.Text = paymentSet.PayStMoneyKindNm8.Replace("���o�^", string.Empty);
            }
            else
            {
                this.lblPayment01.Text = string.Empty;
                this.lblPayment02.Text = string.Empty;
                this.lblPayment03.Text = string.Empty;
                this.lblPayment04.Text = string.Empty;
                this.lblPayment05.Text = string.Empty;
                this.lblPayment06.Text = string.Empty;
                this.lblPayment07.Text = string.Empty;
                this.lblPayment08.Text = string.Empty;
            }

            #endregion

            #region ���l���ڂ̃R���g���[���̕��𒲐�

            Broadleaf.Library.Windows.Forms.TNedit[] ControlList_TNEDIT;
            ControlList_TNEDIT = new Broadleaf.Library.Windows.Forms.TNedit[]{
                                                                    this.tNedit_bc_1MthMonth,
                                                                    this.tNedit_bc_1MthPayment,
                                                                    this.tNedit_bc_2MthMonth,
                                                                    this.tNedit_bc_2MthPayment,
                                                                    this.tNedit_bc_3MthMonth,
                                                                    this.tNedit_bc_3MthPayment,
                                                                    this.tNedit_bc_OfsStock,
                                                                    this.tNedit_bc_OfsStockPayment,
                                                                    this.tNedit_bc_OfsStockTax,
                                                                    this.tNedit_bc_OfsStockTaxPayment,
                                                                    this.tNedit_bc_OfsStockTaxTerm,
                                                                    this.tNedit_bc_OfsStockTerm,
                                                                    this.tNedit_bc_Payment01,
                                                                    this.tNedit_bc_Payment01c,
                                                                    this.tNedit_bc_Payment02,
                                                                    this.tNedit_bc_Payment02c,
                                                                    this.tNedit_bc_Payment03,
                                                                    this.tNedit_bc_Payment03c,
                                                                    this.tNedit_bc_Payment04,
                                                                    this.tNedit_bc_Payment04c,
                                                                    this.tNedit_bc_Payment05,
                                                                    this.tNedit_bc_Payment05c,
                                                                    this.tNedit_bc_Payment06,
                                                                    this.tNedit_bc_Payment06c,
                                                                    this.tNedit_bc_Payment07,
                                                                    this.tNedit_bc_Payment07c,
                                                                    this.tNedit_bc_Payment08,
                                                                    this.tNedit_bc_Payment08c,
                                                                    this.tNedit_bc_Payment09,
                                                                    this.tNedit_bc_Payment09c,
                                                                    this.tNedit_bc_Payment10,
                                                                    this.tNedit_bc_Payment10c,
                                                                    this.tNedit_bc_PaymentSum,
                                                                    this.tNedit_bc_PaymentSumc,
                                                                    this.tNedit_bc_Slip,
                                                                    this.tNedit_bc_SlipPayment,
                                                                    this.tNedit_bc_SlipTerm,
                                                                    this.tNedit_bc_StckPricDis,
                                                                    this.tNedit_bc_StckPricDisPayment,
                                                                    this.tNedit_bc_StckPricDisTerm,
                                                                    this.tNedit_bc_StckPricRgds,
                                                                    this.tNedit_bc_StckPricRgdsPayment,
                                                                    this.tNedit_bc_StckPricRgdsTerm,
                                                                    this.tNedit_bc_StockPrice,
                                                                    this.tNedit_bc_StockPricePayment,
                                                                    this.tNedit_bc_StockPriceTerm,
                                                                    this.tNedit_bc_TotalPayBalance,
                                                                    this.tNedit_bc_TtlAccPayBalance};
            Size controlSize = new Size(131, 26);
            for (int ix = 0; ix < ControlList_TNEDIT.Length; ix++)
            {
                ControlList_TNEDIT[ix].Size = controlSize;
                ControlList_TNEDIT[ix].Clear();
            }

            #endregion
        }

        #endregion // �c���Ɖ�^�u�ݒ�

        #region �^�u�ؑ֐���

        /// <summary>
        /// �^�u�؂�ւ����̐���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraTab_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            if (e.Tab == null) return;

            e.Cancel = false;
            string key = e.Tab.Key;

            if (key.Equals("BalanceInquiryTab"))
            {
                // �x���d����ł͂Ȃ��ꍇ
                //if (this._accDiv == 1) // DEL 2009/01/30
                // --- DEL 2012/09/18 ---------->>>>>
                //if (this.GetAccDiv() == 1)  // ADD 2009/01/30
                // --- DEL 2012/09/18 ----------<<<<<
                // --- ADD 2012/09/18 ---------->>>>>
                if (!this._optSuppSumEnable && this.GetAccDiv() == 1)
                // --- ADD 2012/09/18 ----------<<<<<
                {
                    // ���b�Z�[�W��\��
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        CT_CANNOT_SHOW_CHILD_SUPPLIER, -1, MessageBoxButtons.OK);

                    // �^�u�����ɖ߂�
                    e.Cancel = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Selected = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Active = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Appearance = this.utc_InventTab.Tabs["ResultsTab"].ActiveAppearance;
                    return;
                }

                // �{�N�x�ł͂Ȃ��ꍇ
                if (this._financialYear != this._currentFinancialYear)
                {
                    // ���b�Z�[�W��\��
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        CT_SHOW_ONLY_CURRENTYEAR, -1, MessageBoxButtons.OK);

                    // �^�u�����ɖ߂�
                    e.Cancel = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Selected = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Active = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Appearance = this.utc_InventTab.Tabs["ResultsTab"].ActiveAppearance;
                    return;
                }
            }
        }

        #endregion // �^�u�ؑ֐���

        #region �N�x�ύX��

        /// <summary>
        /// �N�x�ύX��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tDateEdit_FinancialYear_Leave(object sender, EventArgs e)
        {
            // ��v�N�x�v�Z
            if (this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear ||
                this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear - 1)
            {
                this._financialYear = this.tDateEdit_FinancialYear.GetDateYear();
            }
            else if (this.tDateEdit_FinancialYear.GetDateYear() > this._currentFinancialYear)
            {
                // ���N�x�֏C��
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                // ���b�Z�[�W�\��
                //TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                //    CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK); // DEL 2009/01/28
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK); // ADD 2009/01/28
                return;
            }
            else
            {
                // ���N�x�֏C��
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                // ���b�Z�[�W�\��
                //TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                //    CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK); // DEL 2009/01/28
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK); // ADD 2009/01/28

                return;
            }

            // ��v�N�x�J�n�����擾
            DateTime paramDate;
            if (!this._suppYearResultAcs.GetCompanyBeginDate(this._enterpriseCode, this._financialYear, out paramDate))
            {
                return;
            }
            else
            {
                // ���t�ݒ���Ď擾
                this._suppYearResultAcs.GetDateParams(this._financialYear, paramDate, this._enterpriseCode);

                //// �c���Ɖ�^�u���Đݒ�
                //this.BalanceInquiryInit(); // DEL 2009/01/29
            }
        }

        #endregion // �N�x�ύX��

        #region �e�X�g�f�[�^�쐬

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            // �e�X�g�f�[�^�}��
            DataRow row = this._dataSet.MonthResult.NewRow();
            row[this._dataSet.MonthResult.RowNoColumn.ColumnName] = 0;
            row[this._dataSet.MonthResult.RowMonthColumn.ColumnName] = 1;
            row[this._dataSet.MonthResult.RowSetFlgColumn.ColumnName] = 0;
            row[this._dataSet.MonthResult.RowTitleColumn.ColumnName] = "12��";
            row[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.St_StockPriceConsTaxColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockPriceConsTaxColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockPriceConsTaxColumn.ColumnName] = 9999999999;

            this._dataSet.MonthResult.Rows.Add(row);

            DataView dv = this._dataSet.MonthResult.DefaultView;
            this.uGrid_Result.DataSource = dv;

        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// �Z���̃R���N�V�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/11/01 tianjw</br>
        /// <br>            redmine#16602 �e�L�X�g�o�͑Ή� �s��C��</br>
        private void ultraGridExcelExport_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
        {
            int index = e.CurrentRowIndex;
            // ---------- UPD 2010/11/01 ------------------------------------->>>>>
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns;
            
            if (Columns != null)
            {
                //for (int celIndex = 0; celIndex < 24; celIndex++) 
                for (int celIndex = 0; celIndex < Columns.Count; celIndex++)
                {
                    IWorksheetCellFormat tmCF = e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat;
                    tmCF.FormatString = "#,###,##0;-#,###,##0;0";
                    e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
                }
            }
            // ---------- UPD 2010/11/01 -------------------------------------<<<<<
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        #endregion //�e�X�g�f�[�^�쐬

        # endregion

        // --- ADD 2010/07/20-------------------------------->>>>>
        #region ���e�L�X�g�AExcsl�o�͏���
        /// <summary>
        /// �d���N�Ԏ��т�Excel�o�͂��܂��B
        /// </summary>
        /// <remarks>
        /// <param name="excelFlg">�o�͌`���t���O�F
        /// �@�@�@�@�@�@�@�@�@�@�@�@False:�e�L�X�g�o��
        /// �@�@�@�@�@�@�@�@�@�@�@�@True:Excel�o��</param>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2024/11/22 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        private void ExportIntoExcelFile(bool excelFlg)
        {
            this._extractSetupFrm = new PMKOU04110UE();
            this._extractSetupFrm.FormcloseFlg = false;
            // �Ώ۔N�x
            this._extractSetupFrm.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();

            // �o�͌`��
            this._extractSetupFrm.ExcelFlg = excelFlg;
            this._extractSetupFrm.parentHanPtr = this.Handle;

            this._extractSetupFrm.OutputData += new PMKOU04110UE.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

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
                    DialogResult dialogResult = TMsgDisp.Show(
                        form, 
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Name,
                        errMsg,
                        logStatus,
                        MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // ���~
                return;
            }
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // -------- DEL 2010/10/09 ------------------------------------------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //// �J�n���_�R�[�h
            //this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            //// �I�����_�R�[�h
            //this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            //// �J�n�d����R�[�h
            //this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            //// �I���d����R�[�h
            //this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;
 
            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "���o����";
            //    processingDialog.Message = "���݁A�f�[�^���o���ł��B";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this.Search("SubMain");
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}

            //if (this._dataSet.OutPutResult.Count == 0 && this._dataSet.AccPayResult.Count == 0)
            //{
            //    // �f�[�^�Z�b�g���N���A
            //    tDateEdit_FinancialYear_Leave(null, null);
            //    this._suppYearResultCndtn.MainDiv = "Main";
            //    string errorMessage = string.Empty;
            //    if (CheckParameters(out errorMessage))
            //        this._suppYearResultAcs.Search(this._suppYearResultCndtn);
            //    else
            //    {
            //        this._dataSet.MonthResult.Rows.Clear();
            //        this._suppYearResultAcs.SetDataSetBase();
            //    }

            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "�����ɍ��v����f�[�^�����݂��܂���B",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //try
            //{
            //    if (this.ultraGridExcelExport.Export(this.ultraGrid_OutPut, this._extractSetupFrm.SettingFileName) != null)
            //    {
            //        // �f�[�^�Z�b�g���N���A
            //        tDateEdit_FinancialYear_Leave(null, null);
            //        this._suppYearResultCndtn.MainDiv = "Main";
            //        string errorMessage = string.Empty;
            //        if (CheckParameters(out errorMessage))
            //            this._suppYearResultAcs.Search(this._suppYearResultCndtn);
            //        else
            //        {
            //            this._dataSet.MonthResult.Rows.Clear();
            //            this._suppYearResultAcs.SetDataSetBase();
            //        }

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
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        ex.Message,
            //        -1,
            //        MessageBoxButtons.OK);
            //}
            // -------- DEL 2010/10/09 -------------------------------------------<<<<<
        }

        /// <summary>
        /// �d���N�Ԏ��т��e�L�X�g�o�͂��܂��B
        /// </summary>
        /// <remarks>
        /// <param name="excelFlg">�o�͌`���t���O�F
        /// �@�@�@�@�@�@�@�@�@�@�@�@False:�e�L�X�g�o��
        /// �@�@�@�@�@�@�@�@�@�@�@�@True:Excel�o��</param>
        /// </remarks>
        /// <br>Update Note : 2010/09/08 �k���r</br>
        /// <br>            �E��QID:14443 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note : 2024/11/22 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private void ExportIntoTextFile(bool excelFlg)
        {
            this._extractSetupFrm = new PMKOU04110UE();

            this._extractSetupFrm.FormcloseFlg = false;

            // �Ώ۔N�x
            this._extractSetupFrm.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();

            // �o�͌`��
            this._extractSetupFrm.ExcelFlg = excelFlg;
            this._extractSetupFrm.parentHanPtr = this.Handle;

            this._extractSetupFrm.OutputData += new PMKOU04110UE.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

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
                    DialogResult dialogResult = TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Name,
                        errMsg,
                        logStatus,
                        MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // ���~
                return;
            }
            //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // -------- DEL 2010/10/09 ------------------------------------------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //// �J�n���_�R�[�h
            //this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            //// �I�����_�R�[�h
            //this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            //// �J�n�d����R�[�h
            //this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            //// �I���d����R�[�h
            //this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;

            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "���o����";
            //    processingDialog.Message = "���݁A�f�[�^���o���ł��B";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this.Search("SubMain");
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}

            //if (this._dataSet.MonthResult.Count == 0 || _monthResultNullFlg)
            //{
            //    _monthResultNullFlg = false;
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "�����ɍ��v����f�[�^�����݂��܂���B",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

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

            //DataTable targetTable = this._dataSet.OutPutResult;


            ////�N����ݒ�
            //int companyBiginMonth = this._companyBeginMonth;
            //string[] monthFlg = new string[12];
            //for (int ix = 0; ix < 12; ix++)
            //{
            //    int biginMonth = companyBiginMonth + ix;
            //    if (biginMonth > 12) { biginMonth = biginMonth - 12; }
            //    monthFlg[ix] = biginMonth.ToString() + "��";
            //}
            //targetTable.Columns["To_StockPriceTaxExc_1_Month"].Caption = "�������сE�d��(" + monthFlg[0] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_1_Month"].Caption = "�������сE�ԕi(" + monthFlg[0] + ")";
            //targetTable.Columns["To_StockTotalDiscount_1_Month"].Caption = "�������сE�l��(" + monthFlg[0] + ")";
            //targetTable.Columns["To_StockPriceSum_1_Month"].Caption = "�������сE���d��(" + monthFlg[0] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_2_Month"].Caption = "�������сE�d��(" + monthFlg[1] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_2_Month"].Caption = "�������сE�ԕi(" + monthFlg[1] + ")";
            //targetTable.Columns["To_StockTotalDiscount_2_Month"].Caption = "�������сE�l��(" + monthFlg[1] + ")";
            //targetTable.Columns["To_StockPriceSum_2_Month"].Caption = "�������сE���d��(" + monthFlg[1] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_3_Month"].Caption = "�������сE�d��(" + monthFlg[2] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_3_Month"].Caption = "�������сE�ԕi(" + monthFlg[2] + ")";
            //targetTable.Columns["To_StockTotalDiscount_3_Month"].Caption = "�������сE�l��(" + monthFlg[2] + ")";
            //targetTable.Columns["To_StockPriceSum_3_Month"].Caption = "�������сE���d��(" + monthFlg[2] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_4_Month"].Caption = "�������сE�d��(" + monthFlg[3] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_4_Month"].Caption = "�������сE�ԕi(" + monthFlg[3] + ")";
            //targetTable.Columns["To_StockTotalDiscount_4_Month"].Caption = "�������сE�l��(" + monthFlg[3] + ")";
            //targetTable.Columns["To_StockPriceSum_4_Month"].Caption = "�������сE���d��(" + monthFlg[3] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_5_Month"].Caption = "�������сE�d��(" + monthFlg[4] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_5_Month"].Caption = "�������сE�ԕi(" + monthFlg[4] + ")";
            //targetTable.Columns["To_StockTotalDiscount_5_Month"].Caption = "�������сE�l��(" + monthFlg[4] + ")";
            //targetTable.Columns["To_StockPriceSum_5_Month"].Caption = "�������сE���d��(" + monthFlg[4] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_6_Month"].Caption = "�������сE�d��(" + monthFlg[5] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_6_Month"].Caption = "�������сE�ԕi(" + monthFlg[5] + ")";
            //targetTable.Columns["To_StockTotalDiscount_6_Month"].Caption = "�������сE�l��(" + monthFlg[5] + ")";
            //targetTable.Columns["To_StockPriceSum_6_Month"].Caption = "�������сE���d��(" + monthFlg[5] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_7_Month"].Caption = "�������сE�d��(" + monthFlg[6] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_7_Month"].Caption = "�������сE�ԕi(" + monthFlg[6] + ")";
            //targetTable.Columns["To_StockTotalDiscount_7_Month"].Caption = "�������сE�l��(" + monthFlg[6] + ")";
            //targetTable.Columns["To_StockPriceSum_7_Month"].Caption = "�������сE���d��(" + monthFlg[6] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_8_Month"].Caption = "�������сE�d��(" + monthFlg[7] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_8_Month"].Caption = "�������сE�ԕi(" + monthFlg[7] + ")";
            //targetTable.Columns["To_StockTotalDiscount_8_Month"].Caption = "�������сE�l��(" + monthFlg[7] + ")";
            //targetTable.Columns["To_StockPriceSum_8_Month"].Caption = "�������сE���d��(" + monthFlg[7] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_9_Month"].Caption = "�������сE�d��(" + monthFlg[8] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_9_Month"].Caption = "�������сE�ԕi(" + monthFlg[8] + ")";
            //targetTable.Columns["To_StockTotalDiscount_9_Month"].Caption = "�������сE�l��(" + monthFlg[8] + ")";
            //targetTable.Columns["To_StockPriceSum_9_Month"].Caption = "�������сE���d��(" + monthFlg[8] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_10_Month"].Caption = "�������сE�d��(" + monthFlg[9] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_10_Month"].Caption = "�������сE�ԕi(" + monthFlg[9] + ")";
            //targetTable.Columns["To_StockTotalDiscount_10_Month"].Caption = "�������сE�l��(" + monthFlg[9] + ")";
            //targetTable.Columns["To_StockPriceSum_10_Month"].Caption = "�������сE���d��(" + monthFlg[9] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_11_Month"].Caption = "�������сE�d��(" + monthFlg[10] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_11_Month"].Caption = "�������сE�ԕi(" + monthFlg[10] + ")";
            //targetTable.Columns["To_StockTotalDiscount_11_Month"].Caption = "�������сE�l��(" + monthFlg[10] + ")";
            //targetTable.Columns["To_StockPriceSum_11_Month"].Caption = "�������сE���d��(" + monthFlg[10] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_12_Month"].Caption = "�������сE�d��(" + monthFlg[11] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_12_Month"].Caption = "�������сE�ԕi(" + monthFlg[11] + ")";
            //targetTable.Columns["To_StockTotalDiscount_12_Month"].Caption = "�������сE�l��(" + monthFlg[11] + ")";
            //targetTable.Columns["To_StockPriceSum_12_Month"].Caption = "�������сE���d��(" + monthFlg[11] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_1_Month"].Caption = "�݌ɁE�d��(" + monthFlg[0] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_1_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[0] + ")";
            //targetTable.Columns["St_StockTotalDiscount_1_Month"].Caption = "�݌ɁE�l��(" + monthFlg[0] + ")";
            //targetTable.Columns["St_StockPriceSum_1_Month"].Caption = "�݌ɁE���d��(" + monthFlg[0] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_2_Month"].Caption = "�݌ɁE�d��(" + monthFlg[1] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_2_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[1] + ")";
            //targetTable.Columns["St_StockTotalDiscount_2_Month"].Caption = "�݌ɁE�l��(" + monthFlg[1] + ")";
            //targetTable.Columns["St_StockPriceSum_2_Month"].Caption = "�݌ɁE���d��(" + monthFlg[1] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_3_Month"].Caption = "�݌ɁE�d��(" + monthFlg[2] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_3_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[2] + ")";
            //targetTable.Columns["St_StockTotalDiscount_3_Month"].Caption = "�݌ɁE�l��(" + monthFlg[2] + ")";
            //targetTable.Columns["St_StockPriceSum_3_Month"].Caption = "�݌ɁE���d��(" + monthFlg[2] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_4_Month"].Caption = "�݌ɁE�d��(" + monthFlg[3] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_4_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[3] + ")";
            //targetTable.Columns["St_StockTotalDiscount_4_Month"].Caption = "�݌ɁE�l��(" + monthFlg[3] + ")";
            //targetTable.Columns["St_StockPriceSum_4_Month"].Caption = "�݌ɁE���d��(" + monthFlg[3] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_5_Month"].Caption = "�݌ɁE�d��(" + monthFlg[4] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_5_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[4] + ")";
            //targetTable.Columns["St_StockTotalDiscount_5_Month"].Caption = "�݌ɁE�l��(" + monthFlg[4] + ")";
            //targetTable.Columns["St_StockPriceSum_5_Month"].Caption = "�݌ɁE���d��(" + monthFlg[4] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_6_Month"].Caption = "�݌ɁE�d��(" + monthFlg[5] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_6_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[5] + ")";
            //targetTable.Columns["St_StockTotalDiscount_6_Month"].Caption = "�݌ɁE�l��(" + monthFlg[5] + ")";
            //targetTable.Columns["St_StockPriceSum_6_Month"].Caption = "�݌ɁE���d��(" + monthFlg[5] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_7_Month"].Caption = "�݌ɁE�d��(" + monthFlg[6] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_7_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[6] + ")";
            //targetTable.Columns["St_StockTotalDiscount_7_Month"].Caption = "�݌ɁE�l��(" + monthFlg[6] + ")";
            //targetTable.Columns["St_StockPriceSum_7_Month"].Caption = "�݌ɁE���d��(" + monthFlg[6] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_8_Month"].Caption = "�݌ɁE�d��(" + monthFlg[7] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_8_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[7] + ")";
            //targetTable.Columns["St_StockTotalDiscount_8_Month"].Caption = "�݌ɁE�l��(" + monthFlg[7] + ")";
            //targetTable.Columns["St_StockPriceSum_8_Month"].Caption = "�݌ɁE���d��(" + monthFlg[7] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_9_Month"].Caption = "�݌ɁE�d��(" + monthFlg[8] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_9_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[8] + ")";
            //targetTable.Columns["St_StockTotalDiscount_9_Month"].Caption = "�݌ɁE�l��(" + monthFlg[8] + ")";
            //targetTable.Columns["St_StockPriceSum_9_Month"].Caption = "�݌ɁE���d��(" + monthFlg[8] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_10_Month"].Caption = "�݌ɁE�d��(" + monthFlg[9] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_10_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[9] + ")";
            //targetTable.Columns["St_StockTotalDiscount_10_Month"].Caption = "�݌ɁE�l��(" + monthFlg[9] + ")";
            //targetTable.Columns["St_StockPriceSum_10_Month"].Caption = "�݌ɁE���d��(" + monthFlg[9] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_11_Month"].Caption = "�݌ɁE�d��(" + monthFlg[10] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_11_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[10] + ")";
            //targetTable.Columns["St_StockTotalDiscount_11_Month"].Caption = "�݌ɁE�l��(" + monthFlg[10] + ")";
            //targetTable.Columns["St_StockPriceSum_11_Month"].Caption = "�݌ɁE���d��(" + monthFlg[10] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_12_Month"].Caption = "�݌ɁE�d��(" + monthFlg[11] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_12_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[11] + ")";
            //targetTable.Columns["St_StockTotalDiscount_12_Month"].Caption = "�݌ɁE�l��(" + monthFlg[11] + ")";
            //targetTable.Columns["St_StockPriceSum_12_Month"].Caption = "�݌ɁE���d��(" + monthFlg[11] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_1_Month"].Caption = "���E�d��(" + monthFlg[0] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_1_Month"].Caption = "���E�ԕi(" + monthFlg[0] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_1_Month"].Caption = "���E�l��(" + monthFlg[0] + ")";
            //targetTable.Columns["Or_StockPriceSum_1_Month"].Caption = "���E���d��(" + monthFlg[0] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_2_Month"].Caption = "���E�d��(" + monthFlg[1] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_2_Month"].Caption = "���E�ԕi(" + monthFlg[1] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_2_Month"].Caption = "���E�l��(" + monthFlg[1] + ")";
            //targetTable.Columns["Or_StockPriceSum_2_Month"].Caption = "���E���d��(" + monthFlg[1] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_3_Month"].Caption = "���E�d��(" + monthFlg[2] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_3_Month"].Caption = "���E�ԕi(" + monthFlg[2] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_3_Month"].Caption = "���E�l��(" + monthFlg[2] + ")";
            //targetTable.Columns["Or_StockPriceSum_3_Month"].Caption = "���E���d��(" + monthFlg[2] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_4_Month"].Caption = "���E�d��(" + monthFlg[3] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_4_Month"].Caption = "���E�ԕi(" + monthFlg[3] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_4_Month"].Caption = "���E�l��(" + monthFlg[3] + ")";
            //targetTable.Columns["Or_StockPriceSum_4_Month"].Caption = "���E���d��(" + monthFlg[3] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_5_Month"].Caption = "���E�d��(" + monthFlg[4] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_5_Month"].Caption = "���E�ԕi(" + monthFlg[4] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_5_Month"].Caption = "���E�l��(" + monthFlg[4] + ")";
            //targetTable.Columns["Or_StockPriceSum_5_Month"].Caption = "���E���d��(" + monthFlg[4] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_6_Month"].Caption = "���E�d��(" + monthFlg[5] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_6_Month"].Caption = "���E�ԕi(" + monthFlg[5] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_6_Month"].Caption = "���E�l��(" + monthFlg[5] + ")";
            //targetTable.Columns["Or_StockPriceSum_6_Month"].Caption = "���E���d��(" + monthFlg[5] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_7_Month"].Caption = "���E�d��(" + monthFlg[6] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_7_Month"].Caption = "���E�ԕi(" + monthFlg[6] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_7_Month"].Caption = "���E�l��(" + monthFlg[6] + ")";
            //targetTable.Columns["Or_StockPriceSum_7_Month"].Caption = "���E���d��(" + monthFlg[6] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_8_Month"].Caption = "���E�d��(" + monthFlg[7] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_8_Month"].Caption = "���E�ԕi(" + monthFlg[7] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_8_Month"].Caption = "���E�l��(" + monthFlg[7] + ")";
            //targetTable.Columns["Or_StockPriceSum_8_Month"].Caption = "���E���d��(" + monthFlg[7] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_9_Month"].Caption = "���E�d��(" + monthFlg[8] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_9_Month"].Caption = "���E�ԕi(" + monthFlg[8] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_9_Month"].Caption = "���E�l��(" + monthFlg[8] + ")";
            //targetTable.Columns["Or_StockPriceSum_9_Month"].Caption = "���E���d��(" + monthFlg[8] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_10_Month"].Caption = "���E�d��(" + monthFlg[9] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_10_Month"].Caption = "���E�ԕi(" + monthFlg[9] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_10_Month"].Caption = "���E�l��(" + monthFlg[9] + ")";
            //targetTable.Columns["Or_StockPriceSum_10_Month"].Caption = "���E���d��(" + monthFlg[9] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_11_Month"].Caption = "���E�d��(" + monthFlg[10] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_11_Month"].Caption = "���E�ԕi(" + monthFlg[10] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_11_Month"].Caption = "���E�l��(" + monthFlg[10] + ")";
            //targetTable.Columns["Or_StockPriceSum_11_Month"].Caption = "���E���d��(" + monthFlg[10] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_12_Month"].Caption = "���E�d��(" + monthFlg[11] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_12_Month"].Caption = "���E�ԕi(" + monthFlg[11] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_12_Month"].Caption = "���E�l��(" + monthFlg[11] + ")";
            //targetTable.Columns["Or_StockPriceSum_12_Month"].Caption = "���E���d��(" + monthFlg[11] + ")";
            //// ---------ADD 2010/09/08----------->>>>>
            //targetTable.Columns["StockSectionCd"].Caption = "���_";
            //targetTable.Columns["SupplierCd"].Caption = "�d����";
            //targetTable.Columns["SupplierNm"].Caption = "�d���於";
            //// ---------ADD 2010/09/08-----------<<<<<
            //Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns;
            //int dispOrder;
            //string columnName;
            //for (int i = 0; i < Columns.Count; i++)
            //{
            //    // ---------ADD 2010/09/08----------->>>>>
            //    if (Columns[i].Header.Caption == "���_����")
            //    {
            //        Columns[i].Hidden = true;
            //    }
            //    // ---------ADD 2010/09/08-----------<<<<<

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
            //tw.DataSource = this.ultraGrid_OutPut.DataSource;

            //# region [�t�H�[�}�b�g���X�g]
            //Dictionary<string, string> formatList = new Dictionary<string, string>();
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns)
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
            //InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns, true);

            //if (status == 9)// �ُ�I��
            //{
            //    // �o�͎��s
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
            //}
            //else
            //{
            //    // �f�[�^�Z�b�g���N���A
            //    tDateEdit_FinancialYear_Leave(null, null);
            //    this._suppYearResultCndtn.MainDiv = "Main";

            //    string errorMessage = string.Empty;
            //    if (CheckParameters(out errorMessage))
            //        this._suppYearResultAcs.Search(this._suppYearResultCndtn);
            //    else
            //    {
            //        this._dataSet.MonthResult.Rows.Clear();
            //        this._suppYearResultAcs.SetDataSetBase();
            //    }
                    
            //    // �o�͐���
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", -1, MessageBoxButtons.OK);
            //}
            // -------- DEL 2010/10/09 -------------------------------------------<<<<<
        }

        // ------------ ADD 2010/10/09 --------------------------------------------------------->>>>>
        /// <summary>
        /// Excel�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note :2024/11/22 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputExcelData()
        {
            this._suppYearResultAcs.ExcOrtxtDiv = false; // ADD 2011/03/23
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }
            // �J�n���_�R�[�h
            this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            // �I�����_�R�[�h
            this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            // �J�n�d����R�[�h
            this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            // �I���d����R�[�h
            this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;

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
                // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\������[Excel�o��]
                logStatus = TextOutPutWrite((int)OperationCode.ExcelOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

                // ���O�o�^�ُ�ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(
                            form, 
                            emErrorLevel.ERR_LEVEL_STOP, 
                            this.Name,
                            errMsg, 
                            logStatus, 
                            MessageBoxButtons.OK);
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
                this.Search("SubMain");
            }
            finally
            {
                processingDialog.Dispose();
            }

            if (this._dataSet.OutPutResult.Count == 0 && this._dataSet.AccPayResult.Count == 0)
            {
                // �f�[�^�Z�b�g���N���A
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                // ----------UPD 2010/10/27 ----------<<<<<
                //string errorMessage = string.Empty;
                //if (CheckParameters(out errorMessage))
                //    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                //else
                //{
                //    this._dataSet.MonthResult.Rows.Clear();
                //    this._suppYearResultAcs.SetDataSetBase();
                //}
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                // ----------UPD 2010/10/27 ----------<<<<<
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�����ɍ��v����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            try
            {
                if (this.ultraGridExcelExport.Export(this.ultraGrid_OutPut, this._extractSetupFrm.SettingFileName) != null)
                {
                    int outputCount = ((DataView)this.ultraGrid_OutPut.DataSource).Count;//ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
                    // �f�[�^�Z�b�g���N���A
                    tDateEdit_FinancialYear_Leave(null, null);
                    this._suppYearResultCndtn.MainDiv = "Main";
                    // ----------UPD 2010/10/27 ----------<<<<<
                    //string errorMessage = string.Empty;
                    //if (CheckParameters(out errorMessage))
                    //    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                    //else
                    //{
                    //    this._dataSet.MonthResult.Rows.Clear();
                    //    this._suppYearResultAcs.SetDataSetBase();
                    //}
                    if (isSearch)
                    {
                        this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                    }
                    // ----------UPD 2010/10/27 ----------<<<<<
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
                            DialogResult dialogResult = TMsgDisp.Show(
                                form,
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Name,
                                errMsg,
                                logStatus,
                                MessageBoxButtons.OK);
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
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = CT_SUPPLIER_YEAR_RESULT_PGID;
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
                        // ���O�I�y���[�V�����f�[�^
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
                string sectionCdSt = this._extractSetupFrm.SectionCodeSt.Trim();
                sectionCdSt = string.IsNullOrEmpty(sectionCdSt) ? StartStr : sectionCdSt;
                string sectionCdEd = this._extractSetupFrm.SectionCodeEd.Trim();
                sectionCdEd = string.IsNullOrEmpty(sectionCdEd) ? EndStr : sectionCdEd;
                // �d����
                string supplierCdSt = this._extractSetupFrm.SuppPrtPprCodeSt.ToString();
                supplierCdSt = string.IsNullOrEmpty(supplierCdSt) ? StartStr : supplierCdSt;
                string supplierCdEd = this._extractSetupFrm.SuppPrtPprCodeEd.ToString();
                supplierCdEd = string.IsNullOrEmpty(supplierCdEd) ? EndStr : supplierCdEd;
                // �Ώ۔N��
                string checkDate = this._extractSetupFrm.FinancialYear.ToString();
                outPutCon = string.Format(Con, sectionCdSt, sectionCdEd, supplierCdSt, supplierCdEd,
                    checkDate, this._extractSetupFrm.SettingFileName);
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
        //----- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<


        /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note :2011/02/16 liyp</br>
        /// <br>             �e�L�X�g�o�͋@�\�̏ꍇ�݂̂̏C��</br>
        /// <br>Update Note :2011/03/23 liyp</br>
        /// <br>             �e�L�X�g�o�͏C��</br>
        /// <br>Update Note :2024/11/22 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputTextData()
        {
            this._suppYearResultAcs.ExcOrtxtDiv = true; // ADD 2011/03/23
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            // �J�n���_�R�[�h
            this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            // �I�����_�R�[�h
            this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            // �J�n�d����R�[�h
            this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            // �I���d����R�[�h
            this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;

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
                // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\������[�e�L�X�g�o��]
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
                this.Search("SubMain");
            }
            finally
            {
                processingDialog.Dispose();
            }

            if (this._dataSet.MonthResult.Count == 0 || _monthResultNullFlg)
            {
                _monthResultNullFlg = false;
                // ------------ADD 2010/10/27 ----------------<<<<<
                // �f�[�^�Z�b�g���N���A
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                // ------------ADD 2010/10/27 ---------------->>>>>
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�����ɍ��v����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }


            
            // ------------ADD 2010/10/27 ----------------<<<<<
            if (this._dataSet.OutPutResult.Count == 0)
            {
                // �f�[�^�Z�b�g���N���A
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�����ɍ��v����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            // ------------ADD 2010/10/27 ----------------<<<<<

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

            DataTable targetTable = this._dataSet.OutPutResult;


            //�N����ݒ�
            int companyBiginMonth = this._companyBeginMonth;
            string[] monthFlg = new string[12];
            for (int ix = 0; ix < 12; ix++)
            {
                int biginMonth = companyBiginMonth + ix;
                if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                monthFlg[ix] = biginMonth.ToString() + "��";
            }
            targetTable.Columns["To_StockPriceTaxExc_1_Month"].Caption = "�������сE�d��(" + monthFlg[0] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_1_Month"].Caption = "�������сE�ԕi(" + monthFlg[0] + ")";
            targetTable.Columns["To_StockTotalDiscount_1_Month"].Caption = "�������сE�l��(" + monthFlg[0] + ")";
            targetTable.Columns["To_StockPriceSum_1_Month"].Caption = "�������сE���d��(" + monthFlg[0] + ")";

            targetTable.Columns["To_StockPriceTaxExc_2_Month"].Caption = "�������сE�d��(" + monthFlg[1] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_2_Month"].Caption = "�������сE�ԕi(" + monthFlg[1] + ")";
            targetTable.Columns["To_StockTotalDiscount_2_Month"].Caption = "�������сE�l��(" + monthFlg[1] + ")";
            targetTable.Columns["To_StockPriceSum_2_Month"].Caption = "�������сE���d��(" + monthFlg[1] + ")";

            targetTable.Columns["To_StockPriceTaxExc_3_Month"].Caption = "�������сE�d��(" + monthFlg[2] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_3_Month"].Caption = "�������сE�ԕi(" + monthFlg[2] + ")";
            targetTable.Columns["To_StockTotalDiscount_3_Month"].Caption = "�������сE�l��(" + monthFlg[2] + ")";
            targetTable.Columns["To_StockPriceSum_3_Month"].Caption = "�������сE���d��(" + monthFlg[2] + ")";

            targetTable.Columns["To_StockPriceTaxExc_4_Month"].Caption = "�������сE�d��(" + monthFlg[3] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_4_Month"].Caption = "�������сE�ԕi(" + monthFlg[3] + ")";
            targetTable.Columns["To_StockTotalDiscount_4_Month"].Caption = "�������сE�l��(" + monthFlg[3] + ")";
            targetTable.Columns["To_StockPriceSum_4_Month"].Caption = "�������сE���d��(" + monthFlg[3] + ")";

            targetTable.Columns["To_StockPriceTaxExc_5_Month"].Caption = "�������сE�d��(" + monthFlg[4] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_5_Month"].Caption = "�������сE�ԕi(" + monthFlg[4] + ")";
            targetTable.Columns["To_StockTotalDiscount_5_Month"].Caption = "�������сE�l��(" + monthFlg[4] + ")";
            targetTable.Columns["To_StockPriceSum_5_Month"].Caption = "�������сE���d��(" + monthFlg[4] + ")";

            targetTable.Columns["To_StockPriceTaxExc_6_Month"].Caption = "�������сE�d��(" + monthFlg[5] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_6_Month"].Caption = "�������сE�ԕi(" + monthFlg[5] + ")";
            targetTable.Columns["To_StockTotalDiscount_6_Month"].Caption = "�������сE�l��(" + monthFlg[5] + ")";
            targetTable.Columns["To_StockPriceSum_6_Month"].Caption = "�������сE���d��(" + monthFlg[5] + ")";

            targetTable.Columns["To_StockPriceTaxExc_7_Month"].Caption = "�������сE�d��(" + monthFlg[6] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_7_Month"].Caption = "�������сE�ԕi(" + monthFlg[6] + ")";
            targetTable.Columns["To_StockTotalDiscount_7_Month"].Caption = "�������сE�l��(" + monthFlg[6] + ")";
            targetTable.Columns["To_StockPriceSum_7_Month"].Caption = "�������сE���d��(" + monthFlg[6] + ")";

            targetTable.Columns["To_StockPriceTaxExc_8_Month"].Caption = "�������сE�d��(" + monthFlg[7] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_8_Month"].Caption = "�������сE�ԕi(" + monthFlg[7] + ")";
            targetTable.Columns["To_StockTotalDiscount_8_Month"].Caption = "�������сE�l��(" + monthFlg[7] + ")";
            targetTable.Columns["To_StockPriceSum_8_Month"].Caption = "�������сE���d��(" + monthFlg[7] + ")";

            targetTable.Columns["To_StockPriceTaxExc_9_Month"].Caption = "�������сE�d��(" + monthFlg[8] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_9_Month"].Caption = "�������сE�ԕi(" + monthFlg[8] + ")";
            targetTable.Columns["To_StockTotalDiscount_9_Month"].Caption = "�������сE�l��(" + monthFlg[8] + ")";
            targetTable.Columns["To_StockPriceSum_9_Month"].Caption = "�������сE���d��(" + monthFlg[8] + ")";

            targetTable.Columns["To_StockPriceTaxExc_10_Month"].Caption = "�������сE�d��(" + monthFlg[9] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_10_Month"].Caption = "�������сE�ԕi(" + monthFlg[9] + ")";
            targetTable.Columns["To_StockTotalDiscount_10_Month"].Caption = "�������сE�l��(" + monthFlg[9] + ")";
            targetTable.Columns["To_StockPriceSum_10_Month"].Caption = "�������сE���d��(" + monthFlg[9] + ")";

            targetTable.Columns["To_StockPriceTaxExc_11_Month"].Caption = "�������сE�d��(" + monthFlg[10] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_11_Month"].Caption = "�������сE�ԕi(" + monthFlg[10] + ")";
            targetTable.Columns["To_StockTotalDiscount_11_Month"].Caption = "�������сE�l��(" + monthFlg[10] + ")";
            targetTable.Columns["To_StockPriceSum_11_Month"].Caption = "�������сE���d��(" + monthFlg[10] + ")";

            targetTable.Columns["To_StockPriceTaxExc_12_Month"].Caption = "�������сE�d��(" + monthFlg[11] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_12_Month"].Caption = "�������сE�ԕi(" + monthFlg[11] + ")";
            targetTable.Columns["To_StockTotalDiscount_12_Month"].Caption = "�������сE�l��(" + monthFlg[11] + ")";
            targetTable.Columns["To_StockPriceSum_12_Month"].Caption = "�������сE���d��(" + monthFlg[11] + ")";

            targetTable.Columns["St_StockPriceTaxExc_1_Month"].Caption = "�݌ɁE�d��(" + monthFlg[0] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_1_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[0] + ")";
            targetTable.Columns["St_StockTotalDiscount_1_Month"].Caption = "�݌ɁE�l��(" + monthFlg[0] + ")";
            targetTable.Columns["St_StockPriceSum_1_Month"].Caption = "�݌ɁE���d��(" + monthFlg[0] + ")";

            targetTable.Columns["St_StockPriceTaxExc_2_Month"].Caption = "�݌ɁE�d��(" + monthFlg[1] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_2_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[1] + ")";
            targetTable.Columns["St_StockTotalDiscount_2_Month"].Caption = "�݌ɁE�l��(" + monthFlg[1] + ")";
            targetTable.Columns["St_StockPriceSum_2_Month"].Caption = "�݌ɁE���d��(" + monthFlg[1] + ")";

            targetTable.Columns["St_StockPriceTaxExc_3_Month"].Caption = "�݌ɁE�d��(" + monthFlg[2] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_3_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[2] + ")";
            targetTable.Columns["St_StockTotalDiscount_3_Month"].Caption = "�݌ɁE�l��(" + monthFlg[2] + ")";
            targetTable.Columns["St_StockPriceSum_3_Month"].Caption = "�݌ɁE���d��(" + monthFlg[2] + ")";

            targetTable.Columns["St_StockPriceTaxExc_4_Month"].Caption = "�݌ɁE�d��(" + monthFlg[3] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_4_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[3] + ")";
            targetTable.Columns["St_StockTotalDiscount_4_Month"].Caption = "�݌ɁE�l��(" + monthFlg[3] + ")";
            targetTable.Columns["St_StockPriceSum_4_Month"].Caption = "�݌ɁE���d��(" + monthFlg[3] + ")";

            targetTable.Columns["St_StockPriceTaxExc_5_Month"].Caption = "�݌ɁE�d��(" + monthFlg[4] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_5_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[4] + ")";
            targetTable.Columns["St_StockTotalDiscount_5_Month"].Caption = "�݌ɁE�l��(" + monthFlg[4] + ")";
            targetTable.Columns["St_StockPriceSum_5_Month"].Caption = "�݌ɁE���d��(" + monthFlg[4] + ")";

            targetTable.Columns["St_StockPriceTaxExc_6_Month"].Caption = "�݌ɁE�d��(" + monthFlg[5] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_6_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[5] + ")";
            targetTable.Columns["St_StockTotalDiscount_6_Month"].Caption = "�݌ɁE�l��(" + monthFlg[5] + ")";
            targetTable.Columns["St_StockPriceSum_6_Month"].Caption = "�݌ɁE���d��(" + monthFlg[5] + ")";

            targetTable.Columns["St_StockPriceTaxExc_7_Month"].Caption = "�݌ɁE�d��(" + monthFlg[6] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_7_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[6] + ")";
            targetTable.Columns["St_StockTotalDiscount_7_Month"].Caption = "�݌ɁE�l��(" + monthFlg[6] + ")";
            targetTable.Columns["St_StockPriceSum_7_Month"].Caption = "�݌ɁE���d��(" + monthFlg[6] + ")";

            targetTable.Columns["St_StockPriceTaxExc_8_Month"].Caption = "�݌ɁE�d��(" + monthFlg[7] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_8_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[7] + ")";
            targetTable.Columns["St_StockTotalDiscount_8_Month"].Caption = "�݌ɁE�l��(" + monthFlg[7] + ")";
            targetTable.Columns["St_StockPriceSum_8_Month"].Caption = "�݌ɁE���d��(" + monthFlg[7] + ")";

            targetTable.Columns["St_StockPriceTaxExc_9_Month"].Caption = "�݌ɁE�d��(" + monthFlg[8] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_9_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[8] + ")";
            targetTable.Columns["St_StockTotalDiscount_9_Month"].Caption = "�݌ɁE�l��(" + monthFlg[8] + ")";
            targetTable.Columns["St_StockPriceSum_9_Month"].Caption = "�݌ɁE���d��(" + monthFlg[8] + ")";

            targetTable.Columns["St_StockPriceTaxExc_10_Month"].Caption = "�݌ɁE�d��(" + monthFlg[9] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_10_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[9] + ")";
            targetTable.Columns["St_StockTotalDiscount_10_Month"].Caption = "�݌ɁE�l��(" + monthFlg[9] + ")";
            targetTable.Columns["St_StockPriceSum_10_Month"].Caption = "�݌ɁE���d��(" + monthFlg[9] + ")";

            targetTable.Columns["St_StockPriceTaxExc_11_Month"].Caption = "�݌ɁE�d��(" + monthFlg[10] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_11_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[10] + ")";
            targetTable.Columns["St_StockTotalDiscount_11_Month"].Caption = "�݌ɁE�l��(" + monthFlg[10] + ")";
            targetTable.Columns["St_StockPriceSum_11_Month"].Caption = "�݌ɁE���d��(" + monthFlg[10] + ")";

            targetTable.Columns["St_StockPriceTaxExc_12_Month"].Caption = "�݌ɁE�d��(" + monthFlg[11] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_12_Month"].Caption = "�݌ɁE�ԕi(" + monthFlg[11] + ")";
            targetTable.Columns["St_StockTotalDiscount_12_Month"].Caption = "�݌ɁE�l��(" + monthFlg[11] + ")";
            targetTable.Columns["St_StockPriceSum_12_Month"].Caption = "�݌ɁE���d��(" + monthFlg[11] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_1_Month"].Caption = "���E�d��(" + monthFlg[0] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_1_Month"].Caption = "���E�ԕi(" + monthFlg[0] + ")";
            targetTable.Columns["Or_StockTotalDiscount_1_Month"].Caption = "���E�l��(" + monthFlg[0] + ")";
            targetTable.Columns["Or_StockPriceSum_1_Month"].Caption = "���E���d��(" + monthFlg[0] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_2_Month"].Caption = "���E�d��(" + monthFlg[1] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_2_Month"].Caption = "���E�ԕi(" + monthFlg[1] + ")";
            targetTable.Columns["Or_StockTotalDiscount_2_Month"].Caption = "���E�l��(" + monthFlg[1] + ")";
            targetTable.Columns["Or_StockPriceSum_2_Month"].Caption = "���E���d��(" + monthFlg[1] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_3_Month"].Caption = "���E�d��(" + monthFlg[2] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_3_Month"].Caption = "���E�ԕi(" + monthFlg[2] + ")";
            targetTable.Columns["Or_StockTotalDiscount_3_Month"].Caption = "���E�l��(" + monthFlg[2] + ")";
            targetTable.Columns["Or_StockPriceSum_3_Month"].Caption = "���E���d��(" + monthFlg[2] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_4_Month"].Caption = "���E�d��(" + monthFlg[3] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_4_Month"].Caption = "���E�ԕi(" + monthFlg[3] + ")";
            targetTable.Columns["Or_StockTotalDiscount_4_Month"].Caption = "���E�l��(" + monthFlg[3] + ")";
            targetTable.Columns["Or_StockPriceSum_4_Month"].Caption = "���E���d��(" + monthFlg[3] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_5_Month"].Caption = "���E�d��(" + monthFlg[4] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_5_Month"].Caption = "���E�ԕi(" + monthFlg[4] + ")";
            targetTable.Columns["Or_StockTotalDiscount_5_Month"].Caption = "���E�l��(" + monthFlg[4] + ")";
            targetTable.Columns["Or_StockPriceSum_5_Month"].Caption = "���E���d��(" + monthFlg[4] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_6_Month"].Caption = "���E�d��(" + monthFlg[5] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_6_Month"].Caption = "���E�ԕi(" + monthFlg[5] + ")";
            targetTable.Columns["Or_StockTotalDiscount_6_Month"].Caption = "���E�l��(" + monthFlg[5] + ")";
            targetTable.Columns["Or_StockPriceSum_6_Month"].Caption = "���E���d��(" + monthFlg[5] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_7_Month"].Caption = "���E�d��(" + monthFlg[6] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_7_Month"].Caption = "���E�ԕi(" + monthFlg[6] + ")";
            targetTable.Columns["Or_StockTotalDiscount_7_Month"].Caption = "���E�l��(" + monthFlg[6] + ")";
            targetTable.Columns["Or_StockPriceSum_7_Month"].Caption = "���E���d��(" + monthFlg[6] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_8_Month"].Caption = "���E�d��(" + monthFlg[7] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_8_Month"].Caption = "���E�ԕi(" + monthFlg[7] + ")";
            targetTable.Columns["Or_StockTotalDiscount_8_Month"].Caption = "���E�l��(" + monthFlg[7] + ")";
            targetTable.Columns["Or_StockPriceSum_8_Month"].Caption = "���E���d��(" + monthFlg[7] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_9_Month"].Caption = "���E�d��(" + monthFlg[8] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_9_Month"].Caption = "���E�ԕi(" + monthFlg[8] + ")";
            targetTable.Columns["Or_StockTotalDiscount_9_Month"].Caption = "���E�l��(" + monthFlg[8] + ")";
            targetTable.Columns["Or_StockPriceSum_9_Month"].Caption = "���E���d��(" + monthFlg[8] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_10_Month"].Caption = "���E�d��(" + monthFlg[9] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_10_Month"].Caption = "���E�ԕi(" + monthFlg[9] + ")";
            targetTable.Columns["Or_StockTotalDiscount_10_Month"].Caption = "���E�l��(" + monthFlg[9] + ")";
            targetTable.Columns["Or_StockPriceSum_10_Month"].Caption = "���E���d��(" + monthFlg[9] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_11_Month"].Caption = "���E�d��(" + monthFlg[10] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_11_Month"].Caption = "���E�ԕi(" + monthFlg[10] + ")";
            targetTable.Columns["Or_StockTotalDiscount_11_Month"].Caption = "���E�l��(" + monthFlg[10] + ")";
            targetTable.Columns["Or_StockPriceSum_11_Month"].Caption = "���E���d��(" + monthFlg[10] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_12_Month"].Caption = "���E�d��(" + monthFlg[11] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_12_Month"].Caption = "���E�ԕi(" + monthFlg[11] + ")";
            targetTable.Columns["Or_StockTotalDiscount_12_Month"].Caption = "���E�l��(" + monthFlg[11] + ")";
            targetTable.Columns["Or_StockPriceSum_12_Month"].Caption = "���E���d��(" + monthFlg[11] + ")";
            // ---------ADD 2010/09/08----------->>>>>
            targetTable.Columns["StockSectionCd"].Caption = "���_";
            targetTable.Columns["SupplierCd"].Caption = "�d����";
            targetTable.Columns["SupplierNm"].Caption = "�d���於";
            // ---------ADD 2010/09/08-----------<<<<<
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns;
            int dispOrder;
            string columnName;
            for (int i = 0; i < Columns.Count; i++)
            {
                // ---------ADD 2010/09/08----------->>>>>
                if (Columns[i].Header.Caption == "���_����")
                {
                    Columns[i].Hidden = true;
                }
                // ---------ADD 2010/09/08-----------<<<<<

                if (Columns[i].Hidden == false)
                {
                    dispOrder = Columns[i].Header.VisiblePosition;
                    columnName = targetTable.Columns[Columns[i].Index].ColumnName;
                    sortList.Add(dispOrder, columnName);
                }
                Columns[i].Format = ""; // ADD 2011/02/16
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
            tw.DataSource = this.ultraGrid_OutPut.DataSource;

            # region [�t�H�[�}�b�g���X�g]

            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns)
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
            InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns, true);
            if (status == 9)// �ُ�I��
            {
                // �o�͎��s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // �f�[�^�Z�b�g���N���A
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                // -----------UPD 2010/10/27-------------<<<<<
                //string errorMessage = string.Empty;
                //if (CheckParameters(out errorMessage))
                //    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                //else
                //{
                //    this._dataSet.MonthResult.Rows.Clear();
                //    this._suppYearResultAcs.SetDataSetBase();
                //}
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                // -----------UPD 2010/10/27------------->>>>>
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
        // ------------ ADD 2010/10/09 ---------------------------------------------------------<<<<<

        #endregion

        #region ���I�v�V������񐧌䏈��

        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/21</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
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
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = true;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = true;
                //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                this._userSetupFrm.uTabControlSet(true);
            }
            //�e�L�X�g�o�̓I�v�V�����������̏ꍇ
            else
            {
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                this._userSetupFrm.uTabControlSet(false);
            }

            // ���쌠���̐���
            if (!OpeAuthDictionary[OperationCode.TextOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Shortcut = Shortcut.None;
            }
            if (!OpeAuthDictionary[OperationCode.ExcelOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Shortcut = Shortcut.None;
            }
            if ((!OpeAuthDictionary[OperationCode.TextOut]) && (!OpeAuthDictionary[OperationCode.ExcelOut])) // ADD 2010/08/23
            {
                //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                this._userSetupFrm.uTabControlSet(false); // ADD 2010/08/23
            }
            #endregion

            // --- ADD 2012/09/18 ---------->>>>>
            #region ���d�������@�\�i�ʁj�I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optSuppSumEnable = true;
            }
            else
            {
                this._optSuppSumEnable = false;
            }
            #endregion
            // --- ADD 2012/09/18 ----------<<<<<

        }

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMKOU04110U", this);
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
        #endregion ���I�v�V������񐧌䏈��

        #region ���v���p�e�B
        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�������
        /// </summary>
        public int Opt_TextOutput
        {
            get { return this._opt_TextOutput; }
            set { this._opt_TextOutput = value; }
        }
        #endregion

        # region ��[�O���b�h�J������� �ۑ��E����]
        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <param name="targetGrid">�O���b�h</param>
        /// <param name="settingList"></param>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in settingList)
            {
                Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                ultraGridColumn.Hidden = columnInfo.Hidden;
                ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                ultraGridColumn.Width = columnInfo.Width;
            }
            this._suppYearResultCndtn.MainDiv = "Main";
            this._suppYearResultAcs.Search(this._suppYearResultCndtn);
        }
        # endregion

        # region ��[ColumnInfo]
        /// <summary>
        /// ColumnInfo
        /// </summary>
        [Serializable]
        public struct ColumnInfo
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
            public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
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
        /// �|�b�v�A�b�v��ʂ���̃p�����[�^�[�̏���
        /// </summary>
        /// <param name="m">Message</param>
        /// <br>Note       : �|�b�v�A�b�v��ʂ���̃p�����[�^�[�̏������s��</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    int year = m.LParam.ToInt32();
                    // ��v�N�x�v�Z
                    if (year == this._currentFinancialYear ||
                        year == this._currentFinancialYear - 1)
                    {
                        this._financialYear = year;
                    }
                    else if (year > this._currentFinancialYear)
                    {
                        // ���N�x�֏C��
                        this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                        // ���b�Z�[�W�\��
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        // ���N�x�֏C��
                        this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                        // ���b�Z�[�W�\��
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK);

                        return;
                    }

                    // ��v�N�x�J�n�����擾
                    DateTime paramDate;
                    if (!this._suppYearResultAcs.GetCompanyBeginDate(this._enterpriseCode, this._financialYear, out paramDate))
                    {
                        return;
                    }
                    else
                    {
                        // ���t�ݒ���Ď擾
                        this._suppYearResultAcs.GetDateParams(this._financialYear, paramDate, this._enterpriseCode);
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }

        }

        // --- ADD 2010/07/20--------------------------------<<<<<
    }
}