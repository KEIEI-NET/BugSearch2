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
using Broadleaf.Application.Remoting.ParamData;//ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller.Facade;
using Infragistics.Excel;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// ������яƉ�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ������яƉ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 30462 �s�V�@�m��</br>
    /// <br>Date       : 2008.12.01</br>
    /// <br>Update Note: 2009.01.28 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10034(�O���t�{�^���A�ݒ�{�^�����폜)</br>
    /// <br>Update Note: 2009.03.12 30414 �E �K�j</br>
    /// <br>            �E��Q�Ή�12305</br>
    /// <br>Update Note: 2009/09/07 22008 ���� ���n</br>
    /// <br>            �E��Q�Ή�14011</br>
    /// <br>Update Note: 2010/02/18 980035 ���� ��`</br>
    /// <br>            �EMANTIS�Ή�14998 �O���t�@�\�̕���</br>
    /// <br>Update Note: 2010/03/15 980035 ���� ��`</br>
    /// <br>            �EMANTIS�Ή�14998 �O���t�@�\�̕����i�ו��̏C���j</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/30 30517 �Ė� �x��</br>
    /// <br>            �EMANTIS�Ή�15351 �O���t����</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/20 ����p</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/12 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13019</br>
    /// <br>Update Note: 2010/08/19�A2010/08/20 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13278</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13482</br>
    /// <br>Update Note: 2010/08/25 chenyd</br>
    /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/09/1 yangmj</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13278</br>
    /// <br>Update Note: 2011/02/16 liyp</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2011/03/23 liyp</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2014/06/19 RedMine#42650 zhujw</br>
    /// <br>            �E���Ӑ�d�q�������甄��N�Ԏ��яƉ���N�����A
    /// <br>              ����N�Ԏ��яƉ�̌������s���ƁA���Ӑ�d�q�������O�ʕ\�������</br>
    /// <br>Update Note: 2024/11/29 ���O</br>
    /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// </remarks>
	public partial class DCHNB04180UA : Form
	{

		# region �R���X�g���N�^
		/// <summary>
        /// ������яƉ�̃R���X�g���N�^�ł��B
		/// </summary>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2024/11/29 ���O</br>
        /// <br>�Ǘ��ԍ�   : 12070203-00</br>
        /// <br>           : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
		public DCHNB04180UA()
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
			this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
			this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            // --- DEL 2009/01/28 -------------------------------->>>>>
            //this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            //this._graphButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"];
            // --- DEL 2009/01/28 --------------------------------<<<<<
            // --- ADD 2010/02/18 -------------------------------->>>>>
            this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            this._graphButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"];
            // --- ADD 2010/02/18 --------------------------------<<<<<
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._textButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"];
            this._excelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"];
            // --- ADD 2010/07/20 --------------------------------<<<<<

			this._controlScreenSkin = new ControlScreenSkin();
			this._SelesAnnualDataAcs = new SelesAnnualDataAcs();
			this._dataSet = this._SelesAnnualDataAcs.DataSet;

            this._secInfoAcs = new SecInfoAcs(1);
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �{��/���_�����擾����
            this._mainOfficeFunc = this.IsMainOfficeFunc();


            this._depositStAcs = new DepositStAcs();
            _userSetupFrm = new DCHNB04180UC(); // ADD 2010/08/23

            #region ���I�v�V�������
            this.CacheOptionInfo();�@// ADD 2010/07/20
            #endregion
            //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�---->>>>>
            TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs();//�e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�\�������̑Ώ�
            //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�----<<<<<
		}
		# endregion

		# region �v���C�x�[�g�ϐ�
        private SelesAnnualDataAcs _SelesAnnualDataAcs;
		private DateTime _baseDate = DateTime.MinValue;
		private ImageList _imageList16 = null;
		private ControlScreenSkin _controlScreenSkin;
		private InventoryUpdateDataSet _dataSet;
		private Image _guideButtonImage;
        private SecInfoAcs _secInfoAcs;                         // ���_�}�X�^�A�N�Z�X�N���X

        private string _enterpriseCode;                         // ��ƃR�[�h
        private bool _mainOfficeFunc;                           // �{��/���_���
        private int _financialYear;                             // ��v�N�x
        private int _companyBiginMonth;

        //private DCHNB04180UC _userSetupFrm = null;              // ���[�U�[�ݒ��� // DEL 2009/01/28
        private DCHNB04180UC _userSetupFrm = null;              // ���[�U�[�ݒ��� // ADD 2010/02/18

        private DCHNB04180UE _extractSetupFrm = null;           // �o�͏����ݒ��� // ADD 2010/07/20
        //private DCHNB04180UC _userSettingFrm = null;            // ���[�U�[�ݒ��� // ADD 2010/07/20  // DEL 2010/08/02

        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        private bool isSearch = false;                          // �����{�^�����N���b�N���邩�ǂ��� // ADD 2010/07/20
        private bool isError = false;                              // ADD 2010/09/25
        // private bool _excOrtxtDiv = false;                      // �e�L�X�g�o��orExcel�o�͋敪 // ADD 2011/02/16 // DEL 2011/03/23

        private InventoryUpdateDataSet _resultData;

        private DepositStAcs _depositStAcs;
        private bool CustomerCk = false;
        private bool startflg = false;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// �I�������{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// �����{�^��
        // --- DEL 2009/01/28 -------------------------------->>>>>
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;					// �ݒ�{�^��
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _graphButton;					// �O���t�{�^��
        // --- DEL 2009/01/28 --------------------------------<<<<<
        // --- ADD 2010/02/18 -------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;					// �ݒ�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _graphButton;					// �O���t�{�^��
        // --- ADD 2010/02/18 --------------------------------<<<<<
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;			// ���O�C���S���҃^�C�g��
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;				// ���O�C���S���Җ���

        // --- ADD 2010/07/20 -------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _textButton;                   // �e�L�X�g�o�̓{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _excelButton;                  // Excel�o�̓{�^��
        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_TextOutput;
        // --- ADD 2010/07/20 --------------------------------<<<<<

        private const string TOTALDIV_ALL  = "�S��";
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

        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        // ���\�b�h��
        private const string MethodNm = "outputTextData";
        private const string MethodNm2 = "outputExcelData";
        // �o�͌���
        private const string CountNumStr = "�f�[�^�o�͌���:{0},";
        /// <summary>����N�Ԏ��яƉ�PGID</summary>
        private const string CT_SALES_YEAR_RESULT_PGID = "DCHNB04180U";
        // �A�Z���u����
        private const string AssemblyNm = "����N�Ԏ��яƉ�";
        // �e�L�X�g��Excel�o�͏���
        private const string Con = "�W�v�敪:{0},���_:{1} �` {2},�Ώ۔N�x:{3},�o�̓t�@�C����:{4}";
        private const string Con2 = "�W�v�敪:{0},���_:{1} �` {2},{3}:{4} �` {5},�Ώ۔N�x:{6},�o�̓t�@�C����:{7}";
        // �ŏ�����
        private const string StartStr = "�ŏ�����";
        // �Ō�܂�
        private const string EndStr = "�Ō�܂�";
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

        private int _beforFinancialYear = 0;
        private string _befortEditSectionCode = "";
        private int _befortEditSelectionCode = 0;
        private string _beforEmployeeCode = "";
        private string _beforEditSelectionName = "";

        private int[] _depositStKindCd = null;
        private int[] _depositcd = null;
		# endregion

        # region �O���[�o���ϐ�
        public const string programID = "DCHNB04170U";  // �v���O�����h�c
        // 2010/07/20 Add >>>
        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // ���쌠���̐��䃊�X�g
        // 2010/07/20 Add <<<


        // ---------ADD 2010/07/20---------->>>>>
        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�������
        /// </summary>
        public int Opt_TextOutput
        {
            get { return this._opt_TextOutput; }
            set { this._opt_TextOutput = value; }
        }

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

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("DCHNB04170U", this);
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
        # endregion

        // ---------ADD 2010/07/20----------<<<<<

        # region �v���C�x�[�g���\�b�h
        /// <summary>
        /// ������яƉ�f�[�^�̌������s���܂��B
		/// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="selectionCodeInt">�I�����ڃR�[�h�i���l�j</param>
        /// <param name="selectionCodeStr">�I�����ڃR�[�h�i�����j</param>
        /// <param name="totalDiv">0:���_ 1:���Ӑ� 2:�S���� 3:�󒍎� 4:���s�� 5:�n�� 6:�Ǝ�</param>
        /// <returns>STATUS</returns>
        private int Search(string enterpriseCode, string sectionCode,  int selectionCodeInt, string selectionCodeStr, int totalDiv)
		{
            // --------------- ADD 2010/09/25 -------------------------->>>>>
            // ���_
            if (this.tEdit_SectionCode.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCode, this.tEdit_SectionCode);
                this.tEdit_SectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SectionCode.Name, this.tEdit_SectionCode.Text);
                tArrowKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    return -1;
                }
            }
            // --------------- ADD 2010/09/25 --------------------------<<<<<

            //���Ӑ�R�[�h
            if ((this.tComboEditor_TotalDiv.SelectedIndex == 1) && (this.tNedit_SelectionCode.GetInt() == 0))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���Ӑ�R�[�h�̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_SelectionCode.Focus();
                return -1;
            }
            //�S���҃R�[�h
            else if ((this.tComboEditor_TotalDiv.SelectedIndex == 2) && (this.tEdit_EmployeeCode.DataText.Trim() == ""))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�S���҂̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_EmployeeCode.Focus();
                return -1;
            }
            //�󒍎҃R�[�h
            else if ((this.tComboEditor_TotalDiv.SelectedIndex == 3) && (this.tEdit_EmployeeCode.DataText.Trim() == ""))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�󒍎҂̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_EmployeeCode.Focus();
                return -1;
            }
            //���s�҃R�[�h
            else if ((this.tComboEditor_TotalDiv.SelectedIndex == 4) && (this.tEdit_EmployeeCode.DataText.Trim() == ""))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���s�҂̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_EmployeeCode.Focus();
                return -1;
            }

            // --------------- ADD 2010/09/25 -------------------------->>>>>
            // ���Ӑ�E�n��E�Ǝ�
            if (this.tNedit_SelectionCode.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_SelectionCode, this.tNedit_SelectionCode);
                this.tNedit_SelectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tNedit_SelectionCode.Name, this.tNedit_SelectionCode.Text);
                tArrowKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    return -1;
                }
            }
            // �S���ҁE�󒍎ҁE���s��
            if (this.tEdit_EmployeeCode.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_EmployeeCode, this.tEdit_EmployeeCode);
                this.tEdit_EmployeeCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_EmployeeCode.Name, this.tEdit_EmployeeCode.Text);
                tArrowKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    return -1;
                }
            }
            // --------------- ADD 2010/09/25 --------------------------<<<<<

            //�n��R�[�h
            // 2010/04/30 >>>
            //else if ((this.tComboEditor_TotalDiv.SelectedIndex == 5) && (this.tNedit_SelectionCode.GetInt() == 0))
            else if ((this.tComboEditor_TotalDiv.SelectedIndex == 5) && (string.IsNullOrEmpty(this.tNedit_SelectionCode.DataText.Trim())))
            // 2010/04/30 <<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�n��R�[�h�̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_SelectionCode.Focus();
                return -1;
            }
            //�Ǝ�R�[�h
            // 2010/04/30 >>>
            //else if ((this.tComboEditor_TotalDiv.SelectedIndex == 6) && (this.tNedit_SelectionCode.GetInt() == 0))
            else if ((this.tComboEditor_TotalDiv.SelectedIndex == 6) && (string.IsNullOrEmpty(this.tNedit_SelectionCode.DataText.Trim())))
            // 2010/04/30 <<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Ǝ�R�[�h�̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_SelectionCode.Focus();
                return -1;
            }
            // �Ώ۔N�x
            else if (this.tDateEdit_FinancialYear.GetDateYear() == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�N�x�̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tDateEdit_FinancialYear.Focus();
                return -1;
            }
            else if (this.tDateEdit_FinancialYear.GetDateYear() > this._financialYear)
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���N�x�͓��͏o���܂���B",
                        -1,
                        MessageBoxButtons.OK);

                this.tDateEdit_FinancialYear.Focus();
                return -1;
            }

			int status = -1;

			SFCMN00299CA msgForm = new SFCMN00299CA();
			msgForm.Title  = "���o��";
			msgForm.Message = "����N�Ԏ��уf�[�^�̒��o���ł��B";
			try
			{
				msgForm.Show();	// �_�C�A���O�\��

                this._resultData = new InventoryUpdateDataSet();
                status = this._SelesAnnualDataAcs.Search(enterpriseCode, sectionCode,  selectionCodeInt, selectionCodeStr, totalDiv, out _resultData);

                this.Activate(); // ADD BY zhujw 2014/06/19 RedMine#42650 
            }
			catch (Exception ex)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					ex.Message,
					-1,
					MessageBoxButtons.OK);

				return -1;
            }
			finally
			{
				msgForm.Close();
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                if (this.tComboEditor_TotalDiv.SelectedIndex == 0)
                {
                    // ���_�ʂ̏ꍇ�A�u�o�׎��яƉ�v�ւ̓W�J����
                    this.SetShipment();
                }
                else if (this.tComboEditor_TotalDiv.SelectedIndex == 1)
                {
                    // ���Ӑ�ʂ̏ꍇ�A�u�c���Ɖ�v�ւ̓W�J����
                    this.SetBalanceInquiry();
                }
			}
			else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�Y���f�[�^�����݂��܂���B",
					-1,
					MessageBoxButtons.OK);

				this.timer_InitFocusSetting.Enabled = true;

                return -1;  // 2010/04/30 Add
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"����N�Ԏ��уf�[�^�̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

				this.timer_InitFocusSetting.Enabled = true;

                return -1;  // 2010/04/30 Add
			}
		
            return 0;
        }

		/// <summary>
		/// ��ʂ����������܂��B
		/// </summary>
		private void Clear()
		{
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tEdit_SectionCode.DataText = "00";
            this.tEdit_SectionName.DataText = TOTALDIV_ALL;
            this._befortEditSectionCode = this.tEdit_SectionCode.Text.Trim();

            this.tNedit_SelectionCode.Clear();
            this._befortEditSelectionCode = this.tNedit_SelectionCode.GetInt();

            this.tEdit_EmployeeCode.Clear();
            this._beforEmployeeCode = tEdit_EmployeeCode.Text.Trim();

            this.tEdit_SelectionName.Clear();
            this.tEdit_TotalDay.Clear();
            this.tEdit_CollectCondName.Clear();
            this.tEdit_CollectMoneyName.Clear();
            this.tEdit_CollectMoneyDay.Clear();

            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false; // DEL 2009/01/28
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false; // ADD 2010/02/18
            this.isSearch = false; // ADD 2010/09/20

        }

        /// <summary>
        /// GRID�̏��������s���܂��B
        /// </summary>
        private void ViewGrid()
        {
            this._SelesAnnualDataAcs.Clear();
            this._SelesAnnualDataAcs.ViewGrid(this.tDateEdit_FinancialYear.GetDateYear(),this.tComboEditor_TotalDiv.SelectedIndex);
            if (this.tDateEdit_FinancialYear.GetDateYear() == this._financialYear)
            {
                this.ultraLabel1.Text = "��������";
            }
            else
            {
                this.ultraLabel1.Text = "�Ώ۔N�x����";
            }

            // ���v�s�F�ύX
            this.uGrid_Result.DisplayLayout.Rows[12].Appearance.BackColor = Color.LightGray;
            this.uGrid_Result.DisplayLayout.Rows[12].Appearance.BackColor2 = Color.LightGray;
            this.uGrid_Result.DisplayLayout.Rows[13].Appearance.BackColor = Color.LightGray;
            this.uGrid_Result.DisplayLayout.Rows[13].Appearance.BackColor2 = Color.LightGray;


            // �N�Ԏ��яƉ�^�u�������I�ɕ\��
            this.utc_InventTab.SelectedTab = this.utc_InventTab.Tabs["ResultsTab"];
        }

        // --- DEL 2009/01/28 -------------------------------->>>>>
        ///// <summary>
        ///// �O���t�̕\�����s���܂�
        ///// </summary>
        //private void ViewGraph()
        //{
        //    if ((this._resultData == null) || (this._resultData.MonthResult.Count == 0)) return;

        //    // ���ʏ�������ʐ���
        //    SFCMN00299CA progressForm = new SFCMN00299CA();
        //    progressForm.DispCancelButton = false;
        //    progressForm.Title = "���̓`���[�g�쐬��";
        //    progressForm.Message = "���݁A���̓`���[�g�쐬���ł��D�D�D";

        //    try
        //    {
        //        // ���ʏ�������ʕ\��
        //        progressForm.Show();

        //        // �^�u�y�[�W�Ɋ��ɃR���g���[�����L��ꍇ�̓N���A����
        //        if (this.ultraTabPageControl2.Controls.Count > 0)
        //        {
        //            this.ultraTabPageControl2.Controls.Remove(this.ultraTabPageControl2.Controls[0]);
        //        }

        //        AnalysisChartViewForm viewForm = new AnalysisChartViewForm(this);
        //        viewForm.TopLevel = false;
        //        viewForm.FormBorderStyle = FormBorderStyle.None;
        //        viewForm.ShowMe(this._resultData);

        //        // �^�u�y�[�W�ɕ��̓`���[�g�r���[�t�H�[����ǉ�
        //        ultraTabPageControl2.Controls.Add(viewForm);
        //        viewForm.Dock = DockStyle.Fill;

        //        this.utc_InventTab.Tabs["GraphTab"].Visible = true;
        //        this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
        //        //this.utc_InventTab.Scroll(Infragistics.Win.UltraWinTabs.ScrollType.First);
        //    }
        //    catch (Exception ex)
        //    {
        //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "�^�u��ʂ̏������Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
        //    }
        //    finally
        //    {
        //        // ���ʏ�������ʏI��
        //        progressForm.Close();
        //    }
        //}
        // --- DEL 2009/01/28 --------------------------------<<<<<
        // --- ADD 2010/02/18 -------------------------------->>>>>
        /// <summary>
        /// �O���t�̕\�����s���܂�
        /// </summary>
        private void ViewGraph()
        {
            if ((this._resultData == null) || (this._resultData.MonthResult.Count == 0)) return;

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
                viewForm.ShowMe(this._resultData);

                // �^�u�y�[�W�ɕ��̓`���[�g�r���[�t�H�[����ǉ�
                ultraTabPageControl2.Controls.Add(viewForm);
                viewForm.Dock = DockStyle.Fill;

                this.utc_InventTab.Tabs["GraphTab"].Visible = true;
                //this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
                //this.utc_InventTab.Scroll(Infragistics.Win.UltraWinTabs.ScrollType.First);
                this.utc_InventTab.SelectedTab = this.utc_InventTab.Tabs["GraphTab"];
                
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "�^�u��ʂ̏������Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                // ���ʏ�������ʏI��
                progressForm.Close();
            }
        }
        // --- ADD 2010/02/18 --------------------------------<<<<<

        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>
        /// EXCEL�f�[�^�o��
        /// </summary>
        /// <param name="excelFlg">�o�̓t���O</param>
        /// <remarks>
        /// <br>Note       : �N�Ԏ��яƉ��EXCEL�f�[�^�o�͂��܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2024/11/29 ���O</br>
        /// <br>           : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        private void exportIntoExcelData(bool excelFlg)
        {
            this._extractSetupFrm = new DCHNB04180UE();
            // �o�͌`��
            this._extractSetupFrm.ExcelFlg = excelFlg;
            // �W�v�敪
            this._extractSetupFrm.TotalDiv = this.tComboEditor_TotalDiv.SelectedIndex;
            // �Ώ۔N��
            this._extractSetupFrm.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();

            this._extractSetupFrm.OutputData += new DCHNB04180UE.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
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
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<
            
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
            //    //this._SelesAnnualDataAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList, this._extractSetupFrm.TotalDiv, this._extractSetupFrm.FinancialYear); // DEL 2010/08/25
            //    this._SelesAnnualDataAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.St_SelectionCode, this._extractSetupFrm.Ed_SelectionCode, this._extractSetupFrm.SearDiv, this._extractSetupFrm.TotalDiv, this._extractSetupFrm.FinancialYear);// ADD 2010/08/25
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            //if (this._dataSet.MonthResult.Count == 0)
            //{
            //    this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
            //    this.listReView();
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "�����ɍ��v����f�[�^�����݂��܂���B",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}
            //this.InitializeGridColumns(true, this._extractSetupFrm.TotalDiv);
            //try
            //{
            //    if (this.ultraGridExcelExporter1.Export(this.uGrid_Result, this._extractSetupFrm.SettingFileName) != null)
            //    {
            //        this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
            //        this.listReView();
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
            //    this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
            //    this.listReView();
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
        /// �N�Ԏ��яƉ���e�L�X�g�o�͂��܂��B
        /// </summary>
        /// <param name="excelFlg">�o�̓t���O</param>
        /// <remarks>
        /// <br>Note       : �N�Ԏ��яƉ���e�L�X�g�o�͂��܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2024/11/29 ���O</br>
        /// <br>           : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        private void ExportIntoTextFile(bool excelFlg)
        {
            this._extractSetupFrm = new DCHNB04180UE();
            // �o�͌`��
            this._extractSetupFrm.ExcelFlg = excelFlg;
            // �W�v�敪
            this._extractSetupFrm.TotalDiv = this.tComboEditor_TotalDiv.SelectedIndex;
            // �Ώ۔N��
            this._extractSetupFrm.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();

            this._extractSetupFrm.OutputData += new DCHNB04180UE.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
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
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

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
            //    //this._SelesAnnualDataAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList, this._extractSetupFrm.TotalDiv, this._extractSetupFrm.FinancialYear); // DEL 2010/08/25
            //    this._SelesAnnualDataAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.St_SelectionCode, this._extractSetupFrm.Ed_SelectionCode, this._extractSetupFrm.SearDiv, this._extractSetupFrm.TotalDiv, this._extractSetupFrm.FinancialYear); // ADD 2010/08/25
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            //if (this._dataSet.MonthResult.Count == 0)
            //{
            //    this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
            //    this.listReView();
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "�����ɍ��v����f�[�^�����݂��܂���B",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //this.InitializeGridColumns(true, this._extractSetupFrm.TotalDiv);

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

            //DataTable targetTable = this._dataSet.MonthResult;
            //// ---------------------- ADD  2010/09/08 --------------------------------->>>>>
            //targetTable.Columns["SectionCode"].Caption = "���_";
            //// ---------------------- ADD  2010/09/08 ---------------------------------<<<<<

            //switch (this._extractSetupFrm.TotalDiv)
            //{
            //    case 1:
            //        {
            //            // ---------------------- ADD  2010/09/08 --------------------------------->>>>>
            //            //targetTable.Columns["SelectionCode"].Caption = "���Ӑ�R�[�h";
            //            //targetTable.Columns["SelectionName"].Caption = "���Ӑ於��";
            //            targetTable.Columns["SelectionCode"].Caption = "���Ӑ�";
            //            targetTable.Columns["SelectionName"].Caption = "���Ӑ於";
            //            // ---------------------- ADD  2010/09/08 ---------------------------------<<<<<
            //            break;
            //        }
            //    case 2:
            //        {
            //            // ---------------------- ADD  2010/09/08 --------------------------------->>>>>
            //            //targetTable.Columns["SelectionCode"].Caption = "�S���҃R�[�h";
            //            //targetTable.Columns["SelectionName"].Caption = "�S���Җ���";
            //            targetTable.Columns["SelectionCode"].Caption = "�S����";
            //            targetTable.Columns["SelectionName"].Caption = "�S���Җ�";
            //            // ---------------------- ADD  2010/09/08 ---------------------------------<<<<<
            //            break;
            //        }
            //    case 3:
            //        {
            //            // ---------------------- ADD  2010/09/08 --------------------------------->>>>>
            //            //targetTable.Columns["SelectionCode"].Caption = "�󒍎҃R�[�h";
            //            //targetTable.Columns["SelectionName"].Caption = "�󒍎Җ���";
            //            targetTable.Columns["SelectionCode"].Caption = "�󒍎�";
            //            targetTable.Columns["SelectionName"].Caption = "�󒍎Җ�";
            //            // ---------------------- ADD  2010/09/08 ---------------------------------<<<<<
            //            break;
            //        }
            //    case 4:
            //        {
            //            // ---------------------- ADD  2010/09/08 --------------------------------->>>>>
            //            //targetTable.Columns["SelectionCode"].Caption = "���s�҃R�[�h";
            //            //targetTable.Columns["SelectionName"].Caption = "���s�Җ���";
            //            targetTable.Columns["SelectionCode"].Caption = "���s��";
            //            targetTable.Columns["SelectionName"].Caption = "���s�Җ�";
            //            // ---------------------- ADD  2010/09/08 ---------------------------------<<<<<
            //            break;
            //        }
            //    case 5:
            //        {
            //            // ---------------------- ADD  2010/09/08 --------------------------------->>>>>
            //            //targetTable.Columns["SelectionCode"].Caption = "�n��R�[�h";
            //            //targetTable.Columns["SelectionName"].Caption = "�n�於��";
            //            targetTable.Columns["SelectionCode"].Caption = "�n��";
            //            targetTable.Columns["SelectionName"].Caption = "�n�於";
            //            // ---------------------- ADD  2010/09/08 ---------------------------------<<<<<
            //            break;
            //        }
            //    case 6:
            //        {
            //            // ---------------------- ADD  2010/09/08 --------------------------------->>>>>
            //            //targetTable.Columns["SelectionCode"].Caption = "�Ǝ�R�[�h";
            //            //targetTable.Columns["SelectionName"].Caption = "�Ǝ햼��";
            //            targetTable.Columns["SelectionCode"].Caption = "�Ǝ�";
            //            targetTable.Columns["SelectionName"].Caption = "�Ǝ햼";
            //            // ---------------------- ADD  2010/09/08 ---------------------------------<<<<<
            //            break;
            //        }
            //}

            ////�N����ݒ�
            //int companyBiginMonth = this._companyBiginMonth;
            //string[] monthFlg = new string[12];
            //for (int ix = 0; ix < 12; ix++)
            //{
            //    int biginMonth = companyBiginMonth + ix;
            //    if (biginMonth > 12) { biginMonth = biginMonth - 12; }
            //    monthFlg[ix] = biginMonth.ToString() + "��";
            //}
            //targetTable.Columns["SalesMoney"].Caption = "�������сE����(" + monthFlg[0] + ")";
            //targetTable.Columns["ReturnedGoodsPrice"].Caption = "�������сE�ԕi(" + monthFlg[0] + ")";
            //targetTable.Columns["DiscountPrice"].Caption = "�������сE�l��(" + monthFlg[0] + ")";
            //targetTable.Columns["GenuineSalesMoney"].Caption = "�������сE������(" + monthFlg[0] + ")"; ;
            //targetTable.Columns["TargetMoney"].Caption = "�������сE����ڕW(" + monthFlg[0] + ")";
            //targetTable.Columns["AchievementRate"].Caption = "�������сE����B����(" + monthFlg[0] + ")";
            //targetTable.Columns["GrossProfitMoney"].Caption = "�������сE�e��(" + monthFlg[0] + ")";
            //targetTable.Columns["GrossProfitTargetMoney"].Caption = "�������сE�e���ڕW(" + monthFlg[0] + ")";
            //targetTable.Columns["GrossProfitAchievRate"].Caption = "�������сE�e���B����(" + monthFlg[0] + ")";
            //targetTable.Columns["StockDummy"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[0] + ")";
            //targetTable.Columns["OrderDummy"].Caption = "�o�׉񐔁E���(" + monthFlg[0] + ")";
            //targetTable.Columns["SalesMoney1"].Caption = "�������сE����(" + monthFlg[1] + ")";
            //targetTable.Columns["ReturnedGoodsPrice1"].Caption = "�������сE�ԕi(" + monthFlg[1] + ")";
            //targetTable.Columns["DiscountPrice1"].Caption = "�������сE�l��(" + monthFlg[1] + ")";
            //targetTable.Columns["GenuineSalesMoney1"].Caption = "�������сE������(" + monthFlg[1] + ")"; ;
            //targetTable.Columns["TargetMoney1"].Caption = "�������сE����ڕW(" + monthFlg[1] + ")";
            //targetTable.Columns["AchievementRate1"].Caption = "�������сE����B����(" + monthFlg[1] + ")";
            //targetTable.Columns["GrossProfitMoney1"].Caption = "�������сE�e��(" + monthFlg[1] + ")";
            //targetTable.Columns["GrossProfitTargetMoney1"].Caption = "�������сE�e���ڕW(" + monthFlg[1] + ")";
            //targetTable.Columns["GrossProfitAchievRate1"].Caption = "�������сE�e���B����(" + monthFlg[1] + ")";
            //targetTable.Columns["StockDummy1"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[1] + ")";
            //targetTable.Columns["OrderDummy1"].Caption = "�o�׉񐔁E���(" + monthFlg[1] + ")";
            //targetTable.Columns["SalesMoney2"].Caption = "�������сE����(" + monthFlg[2] + ")";
            //targetTable.Columns["ReturnedGoodsPrice2"].Caption = "�������сE�ԕi(" + monthFlg[2] + ")";
            //targetTable.Columns["DiscountPrice2"].Caption = "�������сE�l��(" + monthFlg[2] + ")";
            //targetTable.Columns["GenuineSalesMoney2"].Caption = "�������сE������(" + monthFlg[2] + ")"; ;
            //targetTable.Columns["TargetMoney2"].Caption = "�������сE����ڕW(" + monthFlg[2] + ")";
            //targetTable.Columns["AchievementRate2"].Caption = "�������сE����B����(" + monthFlg[2] + ")";
            //targetTable.Columns["GrossProfitMoney2"].Caption = "�������сE�e��(" + monthFlg[2] + ")";
            //targetTable.Columns["GrossProfitTargetMoney2"].Caption = "�������сE�e���ڕW(" + monthFlg[2] + ")";
            //targetTable.Columns["GrossProfitAchievRate2"].Caption = "�������сE�e���B����(" + monthFlg[2] + ")";
            //targetTable.Columns["StockDummy2"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[2] + ")";
            //targetTable.Columns["OrderDummy2"].Caption = "�o�׉񐔁E���(" + monthFlg[2] + ")";
            //targetTable.Columns["SalesMoney3"].Caption = "�������сE����(" + monthFlg[3] + ")";
            //targetTable.Columns["ReturnedGoodsPrice3"].Caption = "�������сE�ԕi(" + monthFlg[3] + ")";
            //targetTable.Columns["DiscountPrice3"].Caption = "�������сE�l��(" + monthFlg[3] + ")";
            //targetTable.Columns["GenuineSalesMoney3"].Caption = "�������сE������(" + monthFlg[3] + ")"; ;
            //targetTable.Columns["TargetMoney3"].Caption = "�������сE����ڕW(" + monthFlg[3] + ")";
            //targetTable.Columns["AchievementRate3"].Caption = "�������сE����B����(" + monthFlg[3] + ")";
            //targetTable.Columns["GrossProfitMoney3"].Caption = "�������сE�e��(" + monthFlg[3] + ")";
            //targetTable.Columns["GrossProfitTargetMoney3"].Caption = "�������сE�e���ڕW(" + monthFlg[3] + ")";
            //targetTable.Columns["GrossProfitAchievRate3"].Caption = "�������сE�e���B����(" + monthFlg[3] + ")";
            //targetTable.Columns["StockDummy3"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[3] + ")";
            //targetTable.Columns["OrderDummy3"].Caption = "�o�׉񐔁E���(" + monthFlg[3] + ")";
            //targetTable.Columns["SalesMoney4"].Caption = "�������сE����(" + monthFlg[4] + ")";
            //targetTable.Columns["ReturnedGoodsPrice4"].Caption = "�������сE�ԕi(" + monthFlg[4] + ")";
            //targetTable.Columns["DiscountPrice4"].Caption = "�������сE�l��(" + monthFlg[4] + ")";
            //targetTable.Columns["GenuineSalesMoney4"].Caption = "�������сE������(" + monthFlg[4] + ")"; ;
            //targetTable.Columns["TargetMoney4"].Caption = "�������сE����ڕW(" + monthFlg[4] + ")";
            //targetTable.Columns["AchievementRate4"].Caption = "�������сE����B����(" + monthFlg[4] + ")";
            //targetTable.Columns["GrossProfitMoney4"].Caption = "�������сE�e��(" + monthFlg[4] + ")";
            //targetTable.Columns["GrossProfitTargetMoney4"].Caption = "�������сE�e���ڕW(" + monthFlg[4] + ")";
            //targetTable.Columns["GrossProfitAchievRate4"].Caption = "�������сE�e���B����(" + monthFlg[4] + ")";
            //targetTable.Columns["StockDummy4"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[4] + ")";
            //targetTable.Columns["OrderDummy4"].Caption = "�o�׉񐔁E���(" + monthFlg[4] + ")";
            //targetTable.Columns["SalesMoney5"].Caption = "�������сE����(" + monthFlg[5] + ")";
            //targetTable.Columns["ReturnedGoodsPrice5"].Caption = "�������сE�ԕi(" + monthFlg[5] + ")";
            //targetTable.Columns["DiscountPrice5"].Caption = "�������сE�l��(" + monthFlg[5] + ")";
            //targetTable.Columns["GenuineSalesMoney5"].Caption = "�������сE������(" + monthFlg[5] + ")"; ;
            //targetTable.Columns["TargetMoney5"].Caption = "�������сE����ڕW(" + monthFlg[5] + ")";
            //targetTable.Columns["AchievementRate5"].Caption = "�������сE����B����(" + monthFlg[5] + ")";
            //targetTable.Columns["GrossProfitMoney5"].Caption = "�������сE�e��(" + monthFlg[5] + ")";
            //targetTable.Columns["GrossProfitTargetMoney5"].Caption = "�������сE�e���ڕW(" + monthFlg[5] + ")";
            //targetTable.Columns["GrossProfitAchievRate5"].Caption = "�������сE�e���B����(" + monthFlg[5] + ")";
            //targetTable.Columns["StockDummy5"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[5] + ")";
            //targetTable.Columns["OrderDummy5"].Caption = "�o�׉񐔁E���(" + monthFlg[5] + ")";
            //targetTable.Columns["SalesMoney6"].Caption = "�������сE����(" + monthFlg[6] + ")";
            //targetTable.Columns["ReturnedGoodsPrice6"].Caption = "�������сE�ԕi(" + monthFlg[6] + ")";
            //targetTable.Columns["DiscountPrice6"].Caption = "�������сE�l��(" + monthFlg[6] + ")";
            //targetTable.Columns["GenuineSalesMoney6"].Caption = "�������сE������(" + monthFlg[6] + ")"; ;
            //targetTable.Columns["TargetMoney6"].Caption = "�������сE����ڕW(" + monthFlg[6] + ")";
            //targetTable.Columns["AchievementRate6"].Caption = "�������сE����B����(" + monthFlg[6] + ")";
            //targetTable.Columns["GrossProfitMoney6"].Caption = "�������сE�e��(" + monthFlg[6] + ")";
            //targetTable.Columns["GrossProfitTargetMoney6"].Caption = "�������сE�e���ڕW(" + monthFlg[6] + ")";
            //targetTable.Columns["GrossProfitAchievRate6"].Caption = "�������сE�e���B����(" + monthFlg[6] + ")";
            //targetTable.Columns["StockDummy6"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[6] + ")";
            //targetTable.Columns["OrderDummy6"].Caption = "�o�׉񐔁E���(" + monthFlg[6] + ")";
            //targetTable.Columns["SalesMoney7"].Caption = "�������сE����(" + monthFlg[7] + ")";
            //targetTable.Columns["ReturnedGoodsPrice7"].Caption = "�������сE�ԕi(" + monthFlg[7] + ")";
            //targetTable.Columns["DiscountPrice7"].Caption = "�������сE�l��(" + monthFlg[7] + ")";
            //targetTable.Columns["GenuineSalesMoney7"].Caption = "�������сE������(" + monthFlg[7] + ")"; ;
            //targetTable.Columns["TargetMoney7"].Caption = "�������сE����ڕW(" + monthFlg[7] + ")";
            //targetTable.Columns["AchievementRate7"].Caption = "�������сE����B����(" + monthFlg[7] + ")";
            //targetTable.Columns["GrossProfitMoney7"].Caption = "�������сE�e��(" + monthFlg[7] + ")";
            //targetTable.Columns["GrossProfitTargetMoney7"].Caption = "�������сE�e���ڕW(" + monthFlg[7] + ")";
            //targetTable.Columns["GrossProfitAchievRate7"].Caption = "�������сE�e���B����(" + monthFlg[7] + ")";
            //targetTable.Columns["StockDummy7"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[7] + ")";
            //targetTable.Columns["OrderDummy7"].Caption = "�o�׉񐔁E���(" + monthFlg[7] + ")";
            //targetTable.Columns["SalesMoney8"].Caption = "�������сE����(" + monthFlg[8] + ")";
            //targetTable.Columns["ReturnedGoodsPrice8"].Caption = "�������сE�ԕi(" + monthFlg[8] + ")";
            //targetTable.Columns["DiscountPrice8"].Caption = "�������сE�l��(" + monthFlg[8] + ")";
            //targetTable.Columns["GenuineSalesMoney8"].Caption = "�������сE������(" + monthFlg[8] + ")"; ;
            //targetTable.Columns["TargetMoney8"].Caption = "�������сE����ڕW(" + monthFlg[8] + ")";
            //targetTable.Columns["AchievementRate8"].Caption = "�������сE����B����(" + monthFlg[8] + ")";
            //targetTable.Columns["GrossProfitMoney8"].Caption = "�������сE�e��(" + monthFlg[8] + ")";
            //targetTable.Columns["GrossProfitTargetMoney8"].Caption = "�������сE�e���ڕW(" + monthFlg[8] + ")";
            //targetTable.Columns["GrossProfitAchievRate8"].Caption = "�������сE�e���B����(" + monthFlg[8] + ")";
            //targetTable.Columns["StockDummy8"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[8] + ")";
            //targetTable.Columns["OrderDummy8"].Caption = "�o�׉񐔁E���(" + monthFlg[8] + ")";
            //targetTable.Columns["SalesMoney9"].Caption = "�������сE����(" + monthFlg[9] + ")";
            //targetTable.Columns["ReturnedGoodsPrice9"].Caption = "�������сE�ԕi(" + monthFlg[9] + ")";
            //targetTable.Columns["DiscountPrice9"].Caption = "�������сE�l��(" + monthFlg[9] + ")";
            //targetTable.Columns["GenuineSalesMoney9"].Caption = "�������сE������(" + monthFlg[9] + ")"; ;
            //targetTable.Columns["TargetMoney9"].Caption = "�������сE����ڕW(" + monthFlg[9] + ")";
            //targetTable.Columns["AchievementRate9"].Caption = "�������сE����B����(" + monthFlg[9] + ")";
            //targetTable.Columns["GrossProfitMoney9"].Caption = "�������сE�e��(" + monthFlg[9] + ")";
            //targetTable.Columns["GrossProfitTargetMoney9"].Caption = "�������сE�e���ڕW(" + monthFlg[9] + ")";
            //targetTable.Columns["GrossProfitAchievRate9"].Caption = "�������сE�e���B����(" + monthFlg[9] + ")";
            //targetTable.Columns["StockDummy9"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[9] + ")";
            //targetTable.Columns["OrderDummy9"].Caption = "�o�׉񐔁E���(" + monthFlg[9] + ")";
            //targetTable.Columns["SalesMoney10"].Caption = "�������сE����(" + monthFlg[10] + ")";
            //targetTable.Columns["ReturnedGoodsPrice10"].Caption = "�������сE�ԕi(" + monthFlg[10] + ")";
            //targetTable.Columns["DiscountPrice10"].Caption = "�������сE�l��(" + monthFlg[10] + ")";
            //targetTable.Columns["GenuineSalesMoney10"].Caption = "�������сE������(" + monthFlg[10] + ")"; ;
            //targetTable.Columns["TargetMoney10"].Caption = "�������сE����ڕW(" + monthFlg[10] + ")";
            //targetTable.Columns["AchievementRate10"].Caption = "�������сE����B����(" + monthFlg[10] + ")";
            //targetTable.Columns["GrossProfitMoney10"].Caption = "�������сE�e��(" + monthFlg[10] + ")";
            //targetTable.Columns["GrossProfitTargetMoney10"].Caption = "�������сE�e���ڕW(" + monthFlg[10] + ")";
            //targetTable.Columns["GrossProfitAchievRate10"].Caption = "�������сE�e���B����(" + monthFlg[10] + ")";
            //targetTable.Columns["StockDummy10"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[10] + ")";
            //targetTable.Columns["OrderDummy10"].Caption = "�o�׉񐔁E���(" + monthFlg[10] + ")";
            //targetTable.Columns["SalesMoney11"].Caption = "�������сE����(" + monthFlg[11] + ")";
            //targetTable.Columns["ReturnedGoodsPrice11"].Caption = "�������сE�ԕi(" + monthFlg[11] + ")";
            //targetTable.Columns["DiscountPrice11"].Caption = "�������сE�l��(" + monthFlg[11] + ")";
            //targetTable.Columns["GenuineSalesMoney11"].Caption = "�������сE������(" + monthFlg[11] + ")"; ;
            //targetTable.Columns["TargetMoney11"].Caption = "�������сE����ڕW(" + monthFlg[11] + ")";
            //targetTable.Columns["AchievementRate11"].Caption = "�������сE����B����(" + monthFlg[11] + ")";
            //targetTable.Columns["GrossProfitMoney11"].Caption = "�������сE�e��(" + monthFlg[11] + ")";
            //targetTable.Columns["GrossProfitTargetMoney11"].Caption = "�������сE�e���ڕW(" + monthFlg[11] + ")";
            //targetTable.Columns["GrossProfitAchievRate11"].Caption = "�������сE�e���B����(" + monthFlg[11] + ")";
            //targetTable.Columns["StockDummy11"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[11] + ")";
            //targetTable.Columns["OrderDummy11"].Caption = "�o�׉񐔁E���(" + monthFlg[11] + ")";

            //Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Result.DisplayLayout.Bands[0].Columns;
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
            //tw.DataSource = this.uGrid_Result.DataSource;

            //# region [�t�H�[�}�b�g���X�g]
            //Dictionary<string, string> formatList = new Dictionary<string, string>();
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Result.DisplayLayout.Bands[0].Columns)
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

            //this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
            //this.listReView();
            //if (status == 9)// �ُ�I��
            //{
            //    // �o�͎��s
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
            //}
            //else
            //{
            //    // �o�͐���
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", -1, MessageBoxButtons.OK);
            //}
            // --- DEL 2010/10/09 ----------<<<<<
        }

        //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>
        /// �W�v�敪���O���
        /// </summary>
        /// <param name="totalDiv">�W�v�敪</param>
        /// <returns>�W�v�敪��</returns>
        /// <remarks>
        /// <br>Note       : �W�v�敪���O���</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2024/11/29</br>
        /// </remarks>
        private string GetNameByTotalDiv(int totalDiv)
        {
            string res = null;
            switch (totalDiv)
            {
                case 0:
                    res = TOTALDIV_SECT;
                    break;
                case 1:
                    res = TOTALDIV_CUST;
                    break;
                case 2:
                    res = TOTALDIV_SEMP;
                    break;
                case 3:
                    res = TOTALDIV_FEMP;
                    break;
                case 4:
                    res = TOTALDIV_INPU;
                    break;
                case 5:
                    res = TOTALDIV_AREA;
                    break;
                case 6:
                    res = TOTALDIV_TYPE;
                    break;
                default:
                    res = "";
                    break;
            }
            return res;
        }

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
        /// <br>Date       : 2024/11/29</br>
        /// </remarks>
        private int TextOutPutWrite(int mode, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                string outPutCon = string.Empty;
                textOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
                // ���O�f�[�^�ΏۃA�Z���u��ID
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = CT_SALES_YEAR_RESULT_PGID;
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
                // �Ώ۔N��
                string checkDate = this._extractSetupFrm.FinancialYear.ToString();
                if (this._extractSetupFrm.TotalDiv == 0)
                {
                    //���_�̏ꍇ
                    //Con = "�W�v�敪:{0},���_:{1} �` {2},�Ώ۔N�x:{3},�o�̓t�@�C����:{4}";
                    outPutCon = string.Format(Con, GetNameByTotalDiv(this._extractSetupFrm.TotalDiv), sectionCdSt, sectionCdEd, checkDate, this._extractSetupFrm.SettingFileName);
                }
                else
                {
                    // ���Ӑ斔�͒S���Җ��͎󒍎Җ��͔��s�Җ��͒n�斔�͋Ǝ�̏ꍇ
                    string selectionCdSt = this._extractSetupFrm.St_SelectionCode.Trim();
                    selectionCdSt = string.IsNullOrEmpty(selectionCdSt) ? StartStr : selectionCdSt;
                    string selectionCdEd = this._extractSetupFrm.Ed_SelectionCode.Trim();
                    selectionCdEd = string.IsNullOrEmpty(selectionCdEd) ? EndStr : selectionCdEd;
                    //Con2 = "�W�v�敪:{0},���_:{1} �` {2},{3}:{4} �` {5},�Ώ۔N�x:{6},�o�̓t�@�C����:{7}";
                    outPutCon = string.Format(Con2, GetNameByTotalDiv(this._extractSetupFrm.TotalDiv), sectionCdSt, sectionCdEd, GetNameByTotalDiv(this._extractSetupFrm.TotalDiv),
                        selectionCdSt, selectionCdEd, checkDate, this._extractSetupFrm.SettingFileName);
                }
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
        //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

        // --- ADD 2010/10/09 ---------->>>>>
        /// <summary>
        /// Excel�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note :2024/11/29 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputExcelData()
        {
            this._SelesAnnualDataAcs.ExcOrtxtDiv = false; // ADD  2011/03/23
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            SFCMN00299CA processingDialog = new SFCMN00299CA();
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������u�G�N�Z���o�́v
            int logStatus = TextOutPutWrite((int)OperationCode.ExcelOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
            try
            {
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
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
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
                processingDialog.Title = "���o����";
                processingDialog.Message = "���݁A�f�[�^���o���ł��B";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);
                this._SelesAnnualDataAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.St_SelectionCode, this._extractSetupFrm.Ed_SelectionCode, this._extractSetupFrm.SearDiv, this._extractSetupFrm.TotalDiv, this._extractSetupFrm.FinancialYear);
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (this._dataSet.MonthResult.Count == 0)
            {
                this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
                this.listReView();
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�����ɍ��v����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            this.InitializeGridColumns(true, this._extractSetupFrm.TotalDiv);
            try
            {
                if (this.ultraGridExcelExporter1.Export(this.uGrid_Result, this._extractSetupFrm.SettingFileName) != null)
                {

                    int outputCount = ((DataView)this.uGrid_Result.DataSource).Count; //ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
                    this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
                    this.listReView();
                    // ����
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "EXCEL�f�[�^���o�͂��܂����B",
                        -1,
                        MessageBoxButtons.OK);

                    //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
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
                    //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<
                }
            }
            catch (Exception ex)
            {
                this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
                this.listReView();
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

        /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note: 2011/02/16 liyp</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2011/03/23 liyp</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note :2024/11/29 ���O</br>
        /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputTextData()
        {
            // this._excOrtxtDiv = true; // ADD 2011/02/16 //DEL 2011/03/23
            this._SelesAnnualDataAcs.ExcOrtxtDiv = true; // ADD  2011/03/23
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            SFCMN00299CA processingDialog = new SFCMN00299CA();
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������u�e�L�X�g�o�́v
            int logStatus = TextOutPutWrite((int)OperationCode.TextOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
            try
            {
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
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
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
                processingDialog.Title = "���o����";
                processingDialog.Message = "���݁A�f�[�^���o���ł��B";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);
                this._SelesAnnualDataAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.St_SelectionCode, this._extractSetupFrm.Ed_SelectionCode, this._extractSetupFrm.SearDiv, this._extractSetupFrm.TotalDiv, this._extractSetupFrm.FinancialYear);
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (this._dataSet.MonthResult.Count == 0)
            {
                this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
                this.listReView();
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�����ɍ��v����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            this.InitializeGridColumns(true, this._extractSetupFrm.TotalDiv);

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

            DataTable targetTable = this._dataSet.MonthResult;
            targetTable.Columns["SectionCode"].Caption = "���_";

            switch (this._extractSetupFrm.TotalDiv)
            {
                case 1:
                    {
                        targetTable.Columns["SelectionCode"].Caption = "���Ӑ�";
                        targetTable.Columns["SelectionName"].Caption = "���Ӑ於";
                        break;
                    }
                case 2:
                    {
                        targetTable.Columns["SelectionCode"].Caption = "�S����";
                        targetTable.Columns["SelectionName"].Caption = "�S���Җ�";
                        break;
                    }
                case 3:
                    {
                        targetTable.Columns["SelectionCode"].Caption = "�󒍎�";
                        targetTable.Columns["SelectionName"].Caption = "�󒍎Җ�";
                        break;
                    }
                case 4:
                    {
                        targetTable.Columns["SelectionCode"].Caption = "���s��";
                        targetTable.Columns["SelectionName"].Caption = "���s�Җ�";
                        break;
                    }
                case 5:
                    {
                        targetTable.Columns["SelectionCode"].Caption = "�n��";
                        targetTable.Columns["SelectionName"].Caption = "�n�於";
                        break;
                    }
                case 6:
                    {
                        targetTable.Columns["SelectionCode"].Caption = "�Ǝ�";
                        targetTable.Columns["SelectionName"].Caption = "�Ǝ햼";
                        break;
                    }
            }

            //�N����ݒ�
            int companyBiginMonth = this._companyBiginMonth;
            string[] monthFlg = new string[12];
            for (int ix = 0; ix < 12; ix++)
            {
                int biginMonth = companyBiginMonth + ix;
                if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                monthFlg[ix] = biginMonth.ToString() + "��";
            }
            targetTable.Columns["SalesMoney"].Caption = "�������сE����(" + monthFlg[0] + ")";
            targetTable.Columns["ReturnedGoodsPrice"].Caption = "�������сE�ԕi(" + monthFlg[0] + ")";
            targetTable.Columns["DiscountPrice"].Caption = "�������сE�l��(" + monthFlg[0] + ")";
            targetTable.Columns["GenuineSalesMoney"].Caption = "�������сE������(" + monthFlg[0] + ")"; ;
            targetTable.Columns["TargetMoney"].Caption = "�������сE����ڕW(" + monthFlg[0] + ")";
            targetTable.Columns["AchievementRate"].Caption = "�������сE����B����(" + monthFlg[0] + ")";
            targetTable.Columns["GrossProfitMoney"].Caption = "�������сE�e��(" + monthFlg[0] + ")";
            targetTable.Columns["GrossProfitTargetMoney"].Caption = "�������сE�e���ڕW(" + monthFlg[0] + ")";
            targetTable.Columns["GrossProfitAchievRate"].Caption = "�������сE�e���B����(" + monthFlg[0] + ")";
            targetTable.Columns["StockDummy"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[0] + ")";
            targetTable.Columns["OrderDummy"].Caption = "�o�׉񐔁E���(" + monthFlg[0] + ")";
            targetTable.Columns["SalesMoney1"].Caption = "�������сE����(" + monthFlg[1] + ")";
            targetTable.Columns["ReturnedGoodsPrice1"].Caption = "�������сE�ԕi(" + monthFlg[1] + ")";
            targetTable.Columns["DiscountPrice1"].Caption = "�������сE�l��(" + monthFlg[1] + ")";
            targetTable.Columns["GenuineSalesMoney1"].Caption = "�������сE������(" + monthFlg[1] + ")"; ;
            targetTable.Columns["TargetMoney1"].Caption = "�������сE����ڕW(" + monthFlg[1] + ")";
            targetTable.Columns["AchievementRate1"].Caption = "�������сE����B����(" + monthFlg[1] + ")";
            targetTable.Columns["GrossProfitMoney1"].Caption = "�������сE�e��(" + monthFlg[1] + ")";
            targetTable.Columns["GrossProfitTargetMoney1"].Caption = "�������сE�e���ڕW(" + monthFlg[1] + ")";
            targetTable.Columns["GrossProfitAchievRate1"].Caption = "�������сE�e���B����(" + monthFlg[1] + ")";
            targetTable.Columns["StockDummy1"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[1] + ")";
            targetTable.Columns["OrderDummy1"].Caption = "�o�׉񐔁E���(" + monthFlg[1] + ")";
            targetTable.Columns["SalesMoney2"].Caption = "�������сE����(" + monthFlg[2] + ")";
            targetTable.Columns["ReturnedGoodsPrice2"].Caption = "�������сE�ԕi(" + monthFlg[2] + ")";
            targetTable.Columns["DiscountPrice2"].Caption = "�������сE�l��(" + monthFlg[2] + ")";
            targetTable.Columns["GenuineSalesMoney2"].Caption = "�������сE������(" + monthFlg[2] + ")"; ;
            targetTable.Columns["TargetMoney2"].Caption = "�������сE����ڕW(" + monthFlg[2] + ")";
            targetTable.Columns["AchievementRate2"].Caption = "�������сE����B����(" + monthFlg[2] + ")";
            targetTable.Columns["GrossProfitMoney2"].Caption = "�������сE�e��(" + monthFlg[2] + ")";
            targetTable.Columns["GrossProfitTargetMoney2"].Caption = "�������сE�e���ڕW(" + monthFlg[2] + ")";
            targetTable.Columns["GrossProfitAchievRate2"].Caption = "�������сE�e���B����(" + monthFlg[2] + ")";
            targetTable.Columns["StockDummy2"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[2] + ")";
            targetTable.Columns["OrderDummy2"].Caption = "�o�׉񐔁E���(" + monthFlg[2] + ")";
            targetTable.Columns["SalesMoney3"].Caption = "�������сE����(" + monthFlg[3] + ")";
            targetTable.Columns["ReturnedGoodsPrice3"].Caption = "�������сE�ԕi(" + monthFlg[3] + ")";
            targetTable.Columns["DiscountPrice3"].Caption = "�������сE�l��(" + monthFlg[3] + ")";
            targetTable.Columns["GenuineSalesMoney3"].Caption = "�������сE������(" + monthFlg[3] + ")"; ;
            targetTable.Columns["TargetMoney3"].Caption = "�������сE����ڕW(" + monthFlg[3] + ")";
            targetTable.Columns["AchievementRate3"].Caption = "�������сE����B����(" + monthFlg[3] + ")";
            targetTable.Columns["GrossProfitMoney3"].Caption = "�������сE�e��(" + monthFlg[3] + ")";
            targetTable.Columns["GrossProfitTargetMoney3"].Caption = "�������сE�e���ڕW(" + monthFlg[3] + ")";
            targetTable.Columns["GrossProfitAchievRate3"].Caption = "�������сE�e���B����(" + monthFlg[3] + ")";
            targetTable.Columns["StockDummy3"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[3] + ")";
            targetTable.Columns["OrderDummy3"].Caption = "�o�׉񐔁E���(" + monthFlg[3] + ")";
            targetTable.Columns["SalesMoney4"].Caption = "�������сE����(" + monthFlg[4] + ")";
            targetTable.Columns["ReturnedGoodsPrice4"].Caption = "�������сE�ԕi(" + monthFlg[4] + ")";
            targetTable.Columns["DiscountPrice4"].Caption = "�������сE�l��(" + monthFlg[4] + ")";
            targetTable.Columns["GenuineSalesMoney4"].Caption = "�������сE������(" + monthFlg[4] + ")"; ;
            targetTable.Columns["TargetMoney4"].Caption = "�������сE����ڕW(" + monthFlg[4] + ")";
            targetTable.Columns["AchievementRate4"].Caption = "�������сE����B����(" + monthFlg[4] + ")";
            targetTable.Columns["GrossProfitMoney4"].Caption = "�������сE�e��(" + monthFlg[4] + ")";
            targetTable.Columns["GrossProfitTargetMoney4"].Caption = "�������сE�e���ڕW(" + monthFlg[4] + ")";
            targetTable.Columns["GrossProfitAchievRate4"].Caption = "�������сE�e���B����(" + monthFlg[4] + ")";
            targetTable.Columns["StockDummy4"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[4] + ")";
            targetTable.Columns["OrderDummy4"].Caption = "�o�׉񐔁E���(" + monthFlg[4] + ")";
            targetTable.Columns["SalesMoney5"].Caption = "�������сE����(" + monthFlg[5] + ")";
            targetTable.Columns["ReturnedGoodsPrice5"].Caption = "�������сE�ԕi(" + monthFlg[5] + ")";
            targetTable.Columns["DiscountPrice5"].Caption = "�������сE�l��(" + monthFlg[5] + ")";
            targetTable.Columns["GenuineSalesMoney5"].Caption = "�������сE������(" + monthFlg[5] + ")"; ;
            targetTable.Columns["TargetMoney5"].Caption = "�������сE����ڕW(" + monthFlg[5] + ")";
            targetTable.Columns["AchievementRate5"].Caption = "�������сE����B����(" + monthFlg[5] + ")";
            targetTable.Columns["GrossProfitMoney5"].Caption = "�������сE�e��(" + monthFlg[5] + ")";
            targetTable.Columns["GrossProfitTargetMoney5"].Caption = "�������сE�e���ڕW(" + monthFlg[5] + ")";
            targetTable.Columns["GrossProfitAchievRate5"].Caption = "�������сE�e���B����(" + monthFlg[5] + ")";
            targetTable.Columns["StockDummy5"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[5] + ")";
            targetTable.Columns["OrderDummy5"].Caption = "�o�׉񐔁E���(" + monthFlg[5] + ")";
            targetTable.Columns["SalesMoney6"].Caption = "�������сE����(" + monthFlg[6] + ")";
            targetTable.Columns["ReturnedGoodsPrice6"].Caption = "�������сE�ԕi(" + monthFlg[6] + ")";
            targetTable.Columns["DiscountPrice6"].Caption = "�������сE�l��(" + monthFlg[6] + ")";
            targetTable.Columns["GenuineSalesMoney6"].Caption = "�������сE������(" + monthFlg[6] + ")"; ;
            targetTable.Columns["TargetMoney6"].Caption = "�������сE����ڕW(" + monthFlg[6] + ")";
            targetTable.Columns["AchievementRate6"].Caption = "�������сE����B����(" + monthFlg[6] + ")";
            targetTable.Columns["GrossProfitMoney6"].Caption = "�������сE�e��(" + monthFlg[6] + ")";
            targetTable.Columns["GrossProfitTargetMoney6"].Caption = "�������сE�e���ڕW(" + monthFlg[6] + ")";
            targetTable.Columns["GrossProfitAchievRate6"].Caption = "�������сE�e���B����(" + monthFlg[6] + ")";
            targetTable.Columns["StockDummy6"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[6] + ")";
            targetTable.Columns["OrderDummy6"].Caption = "�o�׉񐔁E���(" + monthFlg[6] + ")";
            targetTable.Columns["SalesMoney7"].Caption = "�������сE����(" + monthFlg[7] + ")";
            targetTable.Columns["ReturnedGoodsPrice7"].Caption = "�������сE�ԕi(" + monthFlg[7] + ")";
            targetTable.Columns["DiscountPrice7"].Caption = "�������сE�l��(" + monthFlg[7] + ")";
            targetTable.Columns["GenuineSalesMoney7"].Caption = "�������сE������(" + monthFlg[7] + ")"; ;
            targetTable.Columns["TargetMoney7"].Caption = "�������сE����ڕW(" + monthFlg[7] + ")";
            targetTable.Columns["AchievementRate7"].Caption = "�������сE����B����(" + monthFlg[7] + ")";
            targetTable.Columns["GrossProfitMoney7"].Caption = "�������сE�e��(" + monthFlg[7] + ")";
            targetTable.Columns["GrossProfitTargetMoney7"].Caption = "�������сE�e���ڕW(" + monthFlg[7] + ")";
            targetTable.Columns["GrossProfitAchievRate7"].Caption = "�������сE�e���B����(" + monthFlg[7] + ")";
            targetTable.Columns["StockDummy7"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[7] + ")";
            targetTable.Columns["OrderDummy7"].Caption = "�o�׉񐔁E���(" + monthFlg[7] + ")";
            targetTable.Columns["SalesMoney8"].Caption = "�������сE����(" + monthFlg[8] + ")";
            targetTable.Columns["ReturnedGoodsPrice8"].Caption = "�������сE�ԕi(" + monthFlg[8] + ")";
            targetTable.Columns["DiscountPrice8"].Caption = "�������сE�l��(" + monthFlg[8] + ")";
            targetTable.Columns["GenuineSalesMoney8"].Caption = "�������сE������(" + monthFlg[8] + ")"; ;
            targetTable.Columns["TargetMoney8"].Caption = "�������сE����ڕW(" + monthFlg[8] + ")";
            targetTable.Columns["AchievementRate8"].Caption = "�������сE����B����(" + monthFlg[8] + ")";
            targetTable.Columns["GrossProfitMoney8"].Caption = "�������сE�e��(" + monthFlg[8] + ")";
            targetTable.Columns["GrossProfitTargetMoney8"].Caption = "�������сE�e���ڕW(" + monthFlg[8] + ")";
            targetTable.Columns["GrossProfitAchievRate8"].Caption = "�������сE�e���B����(" + monthFlg[8] + ")";
            targetTable.Columns["StockDummy8"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[8] + ")";
            targetTable.Columns["OrderDummy8"].Caption = "�o�׉񐔁E���(" + monthFlg[8] + ")";
            targetTable.Columns["SalesMoney9"].Caption = "�������сE����(" + monthFlg[9] + ")";
            targetTable.Columns["ReturnedGoodsPrice9"].Caption = "�������сE�ԕi(" + monthFlg[9] + ")";
            targetTable.Columns["DiscountPrice9"].Caption = "�������сE�l��(" + monthFlg[9] + ")";
            targetTable.Columns["GenuineSalesMoney9"].Caption = "�������сE������(" + monthFlg[9] + ")"; ;
            targetTable.Columns["TargetMoney9"].Caption = "�������сE����ڕW(" + monthFlg[9] + ")";
            targetTable.Columns["AchievementRate9"].Caption = "�������сE����B����(" + monthFlg[9] + ")";
            targetTable.Columns["GrossProfitMoney9"].Caption = "�������сE�e��(" + monthFlg[9] + ")";
            targetTable.Columns["GrossProfitTargetMoney9"].Caption = "�������сE�e���ڕW(" + monthFlg[9] + ")";
            targetTable.Columns["GrossProfitAchievRate9"].Caption = "�������сE�e���B����(" + monthFlg[9] + ")";
            targetTable.Columns["StockDummy9"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[9] + ")";
            targetTable.Columns["OrderDummy9"].Caption = "�o�׉񐔁E���(" + monthFlg[9] + ")";
            targetTable.Columns["SalesMoney10"].Caption = "�������сE����(" + monthFlg[10] + ")";
            targetTable.Columns["ReturnedGoodsPrice10"].Caption = "�������сE�ԕi(" + monthFlg[10] + ")";
            targetTable.Columns["DiscountPrice10"].Caption = "�������сE�l��(" + monthFlg[10] + ")";
            targetTable.Columns["GenuineSalesMoney10"].Caption = "�������сE������(" + monthFlg[10] + ")"; ;
            targetTable.Columns["TargetMoney10"].Caption = "�������сE����ڕW(" + monthFlg[10] + ")";
            targetTable.Columns["AchievementRate10"].Caption = "�������сE����B����(" + monthFlg[10] + ")";
            targetTable.Columns["GrossProfitMoney10"].Caption = "�������сE�e��(" + monthFlg[10] + ")";
            targetTable.Columns["GrossProfitTargetMoney10"].Caption = "�������сE�e���ڕW(" + monthFlg[10] + ")";
            targetTable.Columns["GrossProfitAchievRate10"].Caption = "�������сE�e���B����(" + monthFlg[10] + ")";
            targetTable.Columns["StockDummy10"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[10] + ")";
            targetTable.Columns["OrderDummy10"].Caption = "�o�׉񐔁E���(" + monthFlg[10] + ")";
            targetTable.Columns["SalesMoney11"].Caption = "�������сE����(" + monthFlg[11] + ")";
            targetTable.Columns["ReturnedGoodsPrice11"].Caption = "�������сE�ԕi(" + monthFlg[11] + ")";
            targetTable.Columns["DiscountPrice11"].Caption = "�������сE�l��(" + monthFlg[11] + ")";
            targetTable.Columns["GenuineSalesMoney11"].Caption = "�������сE������(" + monthFlg[11] + ")"; ;
            targetTable.Columns["TargetMoney11"].Caption = "�������сE����ڕW(" + monthFlg[11] + ")";
            targetTable.Columns["AchievementRate11"].Caption = "�������сE����B����(" + monthFlg[11] + ")";
            targetTable.Columns["GrossProfitMoney11"].Caption = "�������сE�e��(" + monthFlg[11] + ")";
            targetTable.Columns["GrossProfitTargetMoney11"].Caption = "�������сE�e���ڕW(" + monthFlg[11] + ")";
            targetTable.Columns["GrossProfitAchievRate11"].Caption = "�������сE�e���B����(" + monthFlg[11] + ")";
            targetTable.Columns["StockDummy11"].Caption = "�o�׉񐔁E�݌�(" + monthFlg[11] + ")";
            targetTable.Columns["OrderDummy11"].Caption = "�o�׉񐔁E���(" + monthFlg[11] + ")";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Result.DisplayLayout.Bands[0].Columns;
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
            tw.DataSource = this.uGrid_Result.DataSource;

            # region [�t�H�[�}�b�g���X�g]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Result.DisplayLayout.Bands[0].Columns)
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

            this.InitializeGridColumns(false, this._extractSetupFrm.TotalDiv);
            this.listReView();
            if (status == 9)// �ُ�I��
            {
                // �o�͎��s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // �o�͐���
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", -1, MessageBoxButtons.OK);

                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
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
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

                return true;
            }
        }
        // --- ADD 2010/10/09 ----------<<<<<

        /// <summary>
        /// ��ʃO���b�h���o�͑O�̃��C�A�E�g�ɖ߂��܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃO���b�h���o�͑O�̃��C�A�E�g�ɖ߂��܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void listReView()
        {
            this.ViewGrid();
            this._resultData = new InventoryUpdateDataSet();
            if (isSearch)
            {
                this._SelesAnnualDataAcs.Search(this._enterpriseCode,
                                                this.tEdit_SectionCode.DataText,
                                                this.tNedit_SelectionCode.GetInt(),
                                                this.tEdit_EmployeeCode.DataText,
                                                this.tComboEditor_TotalDiv.SelectedIndex,
                                                out _resultData);
            }
        }

        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        /// <param name="excelFlg">�o�̓t���O</param>
        /// <param name="totalDiv">�W�v�敪</param>
        /// <remarks>
        /// <br>Note       :�@�O���b�h��̏������\�����܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�13019</br>
        /// <br>Update Note: 2010/08/19 chenyd</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�13278</br>
        /// <br>Update Note: 2010/09/1 yangmj</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�13278</br>
        /// <br>Update Note: 2011/02/16 liyp</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2011/03/23 liyp</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void InitializeGridColumns(bool excelFlg, int totalDiv)
        {
            // �o�͗p
            if (excelFlg)
            {
                this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

                string moneyFormat = "#,###,##0;-#,###,##0;0";
                // --------------ADD 2011/02/16 --------------------->>>>>
                // if(this._excOrtxtDiv) // DEL 2011/03/23
                if (this._SelesAnnualDataAcs.ExcOrtxtDiv) // ADD 2011/03/23
                {
                    moneyFormat = "";
                    // this._excOrtxtDiv = false; // DEL 2011/03/23
                }
                // --------------ADD 2011/02/16 ---------------------<<<<<
                int titlWidth = 61;
                int defoWidth = 176;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Result.DisplayLayout.Bands[0].Columns)
                {
                    // �S�Ă̗�����������\���ɂ���B
                    col.Hidden = true;
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                    col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                    // �t�H���g�T�C�Y�F9
                    col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX
                    col.Format = moneyFormat;
                    col.Width = defoWidth;
                }
                // --- ADD 2010/09/10 -------------------------------->>>>>
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                // --- ADD 2010/09/10 --------------------------------<<<<<
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

                moneyFormat = "0.00;-0.00;0";
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Format = moneyFormat;
                // --- ADD 2010/08/19 -------------------------------->>>>>
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate1Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate1Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate2Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate2Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate3Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate3Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate4Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate4Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate5Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate5Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate6Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate6Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate7Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate7Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate8Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate8Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate9Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate9Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate10Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate10Column.ColumnName].Format = moneyFormat;
                // ����B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate11Column.ColumnName].Format = moneyFormat;
                // �e���B����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate11Column.ColumnName].Format = moneyFormat;
                // --- ADD 2010/08/19 --------------------------------<<<<<
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionCodeColumn.ColumnName].Format = "";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Format = "";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Format = "";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Format = "";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionCodeColumn.ColumnName].Width = 100;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Width = 140;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Width = 100;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Width = 220;

                // �\�����ݒ�
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.SizeInPoints = 11.25f;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Width = titlWidth;

                // ��\�����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Hidden = true;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionCodeColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPriceColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPriceColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate1Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate2Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate3Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate4Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate5Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate6Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate7Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate8Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate9Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate10Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney11Column.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate11Column.ColumnName].Hidden = false;
                if (totalDiv == 0) // ADD 2010/08/12
                {       // ADD 2010/08/12
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockGenuineSalesMoneyColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockGrossProfitMoneyColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummySumColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderGenuineSalesMoneyColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderGrossProfitMoneyColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummySumColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummyColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummyColumn.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy1Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy1Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy2Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy2Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy3Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy3Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy4Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy4Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy5Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy5Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy6Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy6Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy7Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy7Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy8Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy8Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy9Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy9Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy10Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy10Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy11Column.ColumnName].Hidden = false;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy11Column.ColumnName].Hidden = false;
                // --- ADD 2010/08/12 -------------------------------->>>>>
                }
                else
                {
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockGenuineSalesMoneyColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockGrossProfitMoneyColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummySumColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderGenuineSalesMoneyColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderGrossProfitMoneyColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummySumColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummyColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummyColumn.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy1Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy1Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy2Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy2Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy3Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy3Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy4Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy4Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy5Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy5Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy6Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy6Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy7Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy7Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy8Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy8Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy9Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy9Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy10Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy10Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy11Column.ColumnName].Hidden = true;
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy11Column.ColumnName].Hidden = true;
                }
                // --- ADD 2010/08/12 --------------------------------<<<<<

                //�N����ݒ�
                int companyBiginMonth = this._companyBiginMonth;
                string[] monthFlg = new string[12];
                for (int ix = 0; ix < 12; ix++)
                {
                    int biginMonth = companyBiginMonth + ix;
                    if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                    monthFlg[ix] = biginMonth.ToString() + "��";
                }
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoneyColumn.ColumnName].Header.Caption = "�������сE����("+monthFlg[0] +")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPriceColumn.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPriceColumn.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoneyColumn.ColumnName].Header.Caption = "�������сE������(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoneyColumn.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoneyColumn.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoneyColumn.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[0] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney1Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice1Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice1Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney1Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney1Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate1Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney1Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney1Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate1Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[1] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney2Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice2Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice2Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney2Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney2Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate2Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney2Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney2Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate2Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[2] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney3Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice3Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice3Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney3Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney3Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate3Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney3Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney3Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate3Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[3] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney4Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice4Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice4Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney4Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney4Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate4Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney4Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney4Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate4Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[4] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney5Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice5Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice5Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney5Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney5Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate5Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney5Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney5Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate5Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[5] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney6Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice6Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice6Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney6Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney6Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate6Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney6Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney6Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate6Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[6] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney7Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice7Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice7Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney7Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney7Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate7Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney7Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney7Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate7Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[7] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney8Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice8Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice8Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney8Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney8Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate8Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney8Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney8Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate8Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[8] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney9Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice9Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice9Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney9Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney9Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate9Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney9Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney9Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate9Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[9] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney10Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice10Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice10Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney10Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney10Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate10Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney10Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney10Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate10Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[10] + ")";


                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoney11Column.ColumnName].Header.Caption = "�������сE����(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPrice11Column.ColumnName].Header.Caption = "�������сE�ԕi(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPrice11Column.ColumnName].Header.Caption = "�������сE�l��(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoney11Column.ColumnName].Header.Caption = "�������сE������(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoney11Column.ColumnName].Header.Caption = "�������сE����ڕW(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRate11Column.ColumnName].Header.Caption = "�������сE����B����(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoney11Column.ColumnName].Header.Caption = "�������сE�e��(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoney11Column.ColumnName].Header.Caption = "�������сE�e���ڕW(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRate11Column.ColumnName].Header.Caption = "�������сE�e���B����(" + monthFlg[11] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummyColumn.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[0] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummyColumn.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[0] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy1Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[1] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy1Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[1] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy2Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[2] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy2Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[2] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy3Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[3] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy3Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[3] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy4Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[4] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy4Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[4] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy5Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[5] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy5Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[5] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy6Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[6] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy6Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[6] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy7Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[7] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy7Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[7] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy8Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[8] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy8Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[8] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy9Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[9] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy9Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[9] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy10Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[10] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy10Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[10] + ")";

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummy11Column.ColumnName].Header.Caption = "�o�׉񐔁E�݌�(" + monthFlg[11] + ")";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummy11Column.ColumnName].Header.Caption = "�o�׉񐔁E���(" + monthFlg[11] + ")";

                switch (totalDiv)
                {
                    case 0:
                        {
                            //-----ADD 2010/09/09---------->>>>>
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionCodeColumn.ColumnName].Header.Caption = "���_";
                            //-----ADD 2010/09/09----------<<<<<

                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Hidden = true;
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Hidden = true;
                            break;
                        }
                    case 1:
                        {
                            //-----ADD 2010/09/09---------->>>>>
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Hidden = true;
                            //-----ADD 2010/09/09----------<<<<<
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Hidden = false;
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Hidden = false;
                            //-----ADD 2010/09/09---------->>>>>
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "���Ӑ於��";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "���Ӑ�";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "���Ӑ於";
                            //-----ADD 2010/09/09----------<<<<<
                            break;
                        }
                    case 2:
                        {
                            //-----ADD 2010/09/09---------->>>>>
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Hidden = true;
                            //-----ADD 2010/09/09----------<<<<<
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Hidden = false;
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Hidden = false;
                            //-----ADD 2010/09/09---------->>>>>
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�S���҃R�[�h";
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�S���Җ���";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�S����";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�S���Җ�";
                            //-----ADD 2010/09/09----------<<<<<
                            break;
                        }
                    case 3:
                        {
                            //-----ADD 2010/09/09---------->>>>>
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Hidden = true;
                            //-----ADD 2010/09/09----------<<<<<
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Hidden = false;
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Hidden = false;
                            //-----ADD 2010/09/09---------->>>>>
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�󒍎҃R�[�h";
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�󒍎Җ���";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�󒍎�";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�󒍎Җ�";
                            //-----ADD 2010/09/09----------<<<<<
                            break;
                        }
                    case 4:
                        {
                            //-----ADD 2010/09/09---------->>>>>
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Hidden = true;
                            //-----ADD 2010/09/09----------<<<<<
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Hidden = false;
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Hidden = false;
                            //-----ADD 2010/09/09---------->>>>>
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "���s�҃R�[�h";
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "���s�Җ���";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "���s��";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "���s�Җ�";
                            //-----ADD 2010/09/09----------<<<<<
                            break;
                        }
                    case 5:
                        {
                            //-----ADD 2010/09/09---------->>>>>
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Hidden = true;
                            //-----ADD 2010/09/09----------<<<<<
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Hidden = false;
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Hidden = false;
                            //-----ADD 2010/09/09---------->>>>>
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�n��R�[�h";
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�n�於��";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�n��";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�n�於";
                            //-----ADD 2010/09/09----------<<<<<
                            break;
                        }
                    case 6:
                        {
                            //-----ADD 2010/09/09---------->>>>>
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SectionNameColumn.ColumnName].Hidden = true;
                            //-----ADD 2010/09/09----------<<<<<
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Hidden = false;
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Hidden = false;
                            //-----ADD 2010/09/09---------->>>>>
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�Ǝ�R�[�h";
                            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�Ǝ햼��";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionCodeColumn.ColumnName].Header.Caption = "�Ǝ�";
                            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SelectionNameColumn.ColumnName].Header.Caption = "�Ǝ햼";
                            //-----ADD 2010/09/09----------<<<<<
                            break;
                        }
                }
            }
            // �����p
            else
            {
                this.uLabel_HeaderTitle.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.uLabel_HeaderTitle.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.ultraLabel1.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.ultraLabel1.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.ultraLabel2.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.ultraLabel2.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;

                this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

                string moneyFormat = "#,###,##0;-#,###,##0;0";
                // �t�H���g�T�C�Y�F9
                int titlWidth = 61;
                int defoWidth = 94;     //�i13���j
                int discWidth = 94;     //�i13���j
                int rateWidth = 54;     //�i 6���j
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Result.DisplayLayout.Bands[0].Columns)
                {
                    // �S�Ă̗�����������\���ɂ���B
                    col.Hidden = true;
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                    col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                    col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX
                    col.Format = moneyFormat;
                    //col.Width = 95;
                    col.Width = defoWidth;

                }

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

                moneyFormat = "0.00;-0.00;0";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Format = moneyFormat;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Format = moneyFormat;

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.SizeInPoints = 11.25f;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Width = titlWidth;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPriceColumn.ColumnName].Width = discWidth;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPriceColumn.ColumnName].Width = discWidth;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Width = rateWidth;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Width = rateWidth;

                // ��\�����
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPriceColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPriceColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.BeforeGenuineSalesMoneyColumn.ColumnName].Hidden = false;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.BeforeGrossProfitMoneyColumn.ColumnName].Hidden = false;

                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoneyColumn.ColumnName].Header.Caption = "����";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPriceColumn.ColumnName].Header.Caption = "�ԕi";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPriceColumn.ColumnName].Header.Caption = "�l��";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoneyColumn.ColumnName].Header.Caption = "������";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoneyColumn.ColumnName].Header.Caption = "�ڕW";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Header.Caption = "�B����";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoneyColumn.ColumnName].Header.Caption = "�e��";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoneyColumn.ColumnName].Header.Caption = "�ڕW";
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Header.Caption = "�B����";
            }
        }
		# endregion

        # region [Excel�G�N�X�|�[�^�C�x���g����]
        // --- DEL 2010/08/20-------------------------------->>>>>
        ///// <summary>
        ///// �Z���̃R���N�V�����C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^�N���X</param>
        ///// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        ///// <br>Programmer : ����p</br>
        ///// <br>Date       : 2010/07/20</br>
        //private void ultraGridExcelExporter1_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
        //{
        //    int index = e.CurrentRowIndex;
        //    for (int celIndex = 0; celIndex < 122; celIndex++)
        //    {
        //        IWorksheetCellFormat tmCF = e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat;
        //        tmCF.FormatString = "#,###,##0;-#,###,##0;0";
        //        e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
        //        // --- ADD 2010/08/19 -------------------------------->>>>>

        //        if (celIndex == 7 || celIndex == 10 || celIndex == 16 || celIndex == 19 || celIndex == 25
        //        || celIndex == 28 || celIndex == 34 || celIndex == 37 || celIndex == 43 || celIndex == 46
        //        || celIndex == 52 || celIndex == 55 || celIndex == 61 || celIndex == 64 || celIndex == 70
        //        || celIndex == 73 || celIndex == 79 || celIndex == 82 || celIndex == 88 || celIndex == 91
        //        || celIndex == 97 || celIndex == 100 || celIndex == 106 || celIndex == 109)
        //        {
        //            tmCF.FormatString = "0.00;-0.00;0";
        //            e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
        //        }
        //        // --- ADD 2010/08/19 --------------------------------<<<<<
        //    }
        //}
        // --- ADD 2010/07/20--------------------------------<<<<<
        // --- DEL 2010/08/20--------------------------------<<<<<
        # endregion
        
        # region [ExcelExporter�C�x���g����]
        // --- ADD 2010/08/20-------------------------------->>>>>
        /// <summary>
        /// �Z���̃R���N�V�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/20</br>
        private void ultraGridExcelExporter_InitializeColumn(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.InitializeColumnEventArgs e)
        {
            // �O���b�h�J�����̃t�H�[�}�b�g��Excel�Z���ɃR�s�[����B
            try
            {
                string format = e.Column.Format;

                // �R�[�h�p�t�H�[�}�b�g��(�[���󔒂ɂ���ꍇ)�O���b�h�ƃG�N�Z���ňقȂ�̂ŕ␳����B
                // �u0000;-0000;''�v���u0000;-0000;�v
                if (format.EndsWith(";''"))
                {
                    format = format.Substring(0, format.Length - 2);
                }
                e.ExcelFormatStr = format;
            }
            catch
            {
                e.ExcelFormatStr = string.Empty;
            }
        }
        // --- ADD 2010/08/20--------------------------------<<<<<
        # endregion

		# region �e��R���g���[���C�x���g����
		/// <summary>
        /// ������яƉ�[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		private void MAZAI05150UA_Load(object sender, EventArgs e)
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
			this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // --- DEL 2009/01/28 -------------------------------->>>>>
            //this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            //this._graphButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1;
            // --- DEL 2009/01/28 --------------------------------<<<<<
            // --- ADD 2010/02/18 -------------------------------->>>>>
            this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            this._graphButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1;
            // --- ADD 2010/02/18 --------------------------------<<<<<
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._textButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            this._excelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            // --- ADD 2010/07/20 --------------------------------<<<<<

			// �X�L�����[�h
			List<string> controlNameList = new List<string>();
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			this.uGrid_Result.DataSource = this._SelesAnnualDataAcs.DataView;
			this.uGrid_StockResult.DataSource = this._SelesAnnualDataAcs.ErrorDataView;

            // �R���{�{�b�N�X�ɏ��Z�b�g
            this.tComboEditor_TotalDiv.Items.Clear();
            this.tComboEditor_TotalDiv.Items.Add(0, TOTALDIV_SECT);
            this.tComboEditor_TotalDiv.Items.Add(1, TOTALDIV_CUST);
            this.tComboEditor_TotalDiv.Items.Add(2, TOTALDIV_SEMP);
            this.tComboEditor_TotalDiv.Items.Add(3, TOTALDIV_FEMP);
            this.tComboEditor_TotalDiv.Items.Add(4, TOTALDIV_INPU);
            this.tComboEditor_TotalDiv.Items.Add(5, TOTALDIV_AREA);
            this.tComboEditor_TotalDiv.Items.Add(6, TOTALDIV_TYPE);
            this.tComboEditor_TotalDiv.MaxDropDownItems = this.tComboEditor_TotalDiv.Items.Count;
            this.tComboEditor_TotalDiv.SelectedIndex = 0;

            // ���ڂ̈ʒu�ݒ�
            Point point = new Point();
            point = this.tNedit_SelectionCode.Location;
            this.tEdit_EmployeeCode.Location = point;

			// ��ʂ�����������B
			this.Clear();

			this.timer_InitFocusSetting.Enabled = true;

            // ��v�N�x�擾
            this._SelesAnnualDataAcs.GetCompanyInf(this._enterpriseCode, out this._financialYear, out this._companyBiginMonth);
            tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);
            this._beforFinancialYear = this.tDateEdit_FinancialYear.GetDateYear();

            // GRID������������B
            this.ViewGrid();

            // ���_�p�^�u�̏�����
            this.ShipmentInit();

            // ���Ӑ�p�^�u�̏�����
            this.BalanceInquiryInit();
        }

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // �t�H�[�J�X���� ============================================ //
            if ((e.PrevCtrl == this.tNedit_SelectionCode) ||
                (e.PrevCtrl == this.tEdit_EmployeeCode) ||
                (e.PrevCtrl == this.uButton_SelectionGuide))
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if ((this.tNedit_SelectionCode.Visible == false) && (this.tEdit_EmployeeCode.Visible == false) &&
               ((e.PrevCtrl == this.tEdit_SectionCode) || (e.PrevCtrl == this.uButton_SectionGuide)))
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }


			// ���̎擾 ============================================ //
            int totalDiv = this.tComboEditor_TotalDiv.SelectedIndex;
            switch (e.PrevCtrl.Name)
            {
                // ���_
                case "tEdit_SectionCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SectionCode.Text.Trim();
                        string name = TOTALDIV_ALL;

                        if (code != "")
                        {
                            SecInfoSet secInfoSet = new SecInfoSet();
                            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, code);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ------- ADD 2010/09/20 ------------------------>>>>>
                                if (secInfoSet.LogicalDeleteCode == 0)
                                {
                                // ------- ADD 2010/09/20 ------------------------<<<<<
                                    name = secInfoSet.SectionGuideNm;

                                    if (this._befortEditSectionCode.Equals(code) == false)
                                    {
                                        this.ViewGrid();
                                        this.ShipmentInit();
                                        this.BalanceInquiryInit();
                                        // 2010/04/30 Add >>>
                                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                        // 2010/04/30 Add <<<

                                        this._befortEditSectionCode = code;
                                    }
                                // ------- ADD 2010/09/20 ------------------------>>>>>
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���_�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                    isError = true; // ADD 2010/09/25
                                    code = "";
                                    canChangeFocus = false;
                                }
                                // ------- ADD 2010/09/20 ------------------------<<<<<
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���_�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                isError = true; // ADD 2010/09/25
                                code = "";
                                canChangeFocus = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "���_�̎擾�Ɏ��s���܂����B",
                                    status,
                                    MessageBoxButtons.OK);

                                isError = true; // ADD 2010/09/25
                                code = "";
                                canChangeFocus = false;
                            }
                        }
                        else
                        {
                            code = "00";
                        }
                        // �R�[�h�E���̃Z�b�g
                        this.tEdit_SectionCode.Text = code;
                        this.tEdit_SectionName.Text = name;

                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tEdit_SectionCode.Text.Trim().Length == 0)
                                        {
                                            e.NextCtrl = this.uButton_SectionGuide;
                                        }
                                        else
                                        {
                                            switch (totalDiv)
                                            {
                                                case 0: // ���_
                                                    e.NextCtrl = this.tDateEdit_FinancialYear;
                                                    break;
                                                case 2: // �S����
                                                case 3: // �󒍎�
                                                case 4: // ���s��
                                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                                    break;
                                                default:
                                                    e.NextCtrl = this.tNedit_SelectionCode;
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }

                // �W�v���ځi���l�j
                case "tNedit_SelectionCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_SelectionCode.GetInt();
                        string name = "";

                        if (code != 0)
                            {
                            if (totalDiv == 1)
                            {
                                // ���Ӑ�
                                CustomerInfo customerInfo;
                                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    isError = false; // ADD 2010/09/21
                                    name = customerInfo.CustomerSnm;

                                    // -- UPD 2009/09/07 ------------------------------>>>
                                    //if (customerInfo.MngSectionCode == customerInfo.ClaimSectionCode &&
                                    //    customerInfo.CustomerCode == customerInfo.ClaimCode)
                                    if (customerInfo.MngSectionCode.Trim() == customerInfo.ClaimSectionCode.Trim() &&
                                        customerInfo.CustomerCode == customerInfo.ClaimCode &&
                                        customerInfo.ClaimSectionCode.Trim() == this.tEdit_SectionCode.Text.Trim())
                                    // -- UPD 2009/09/07 ------------------------------<<<
                                    {
                                        CustomerCk = true;
                                    }
                                    else
                                    {
                                        CustomerCk = false;
                                    }

                                    if (this._befortEditSelectionCode != code)
                                    {
                                        this.ViewGrid();
                                        this.ShipmentInit();
                                        this.BalanceInquiryInit();
                                        // 2010/04/30 Add >>>
                                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                        // 2010/04/30 Add <<<
                                        
                                        this._befortEditSelectionCode = code;
                                    }

                                    // ������Z�b�g
                                    CollectMoneySelect(customerInfo);
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���Ӑ悪���݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    isError = true; // ADD 2010/09/21
                                    code = 0;
                                    CollectMoneySelect();
                                    canChangeFocus = false;
                                }
                                else
                                {
                                    isError = false; // ADD 2010/09/21
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���Ӑ�̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    isError = true; // ADD 2010/09/21
                                    code = 0;
                                    CollectMoneySelect();
                                    canChangeFocus = false;
                                }
                            }
                        }   // 2010/04/30 Add
                        // 2010/04/30 >>>
                        //else if ((totalDiv == 5) || (totalDiv == 6))
                        // �n��E�Ǝ�
                        if ((totalDiv == 5) || (totalDiv == 6))
                        // 2010/04/30 <<<
                        {
                            // 2010/04/30 Add >>>
                            if (string.IsNullOrEmpty(this.tNedit_SelectionCode.DataText))
                            {
                                code = -1;
                            }
                            else
                            {
                                // 2010/04/30 Add <<<
                                // �n��E�Ǝ�
                                UserGuideAcs _userGuideAcs = new UserGuideAcs();
                                UserGdHd userGdHd = new UserGdHd();
                                ArrayList userGdBdList = new ArrayList();
                                Boolean chkflg = false;
                                int userGuideDivCd;
                                if (totalDiv == 5) { userGuideDivCd = 21; } // �n��i�̔��G���A�j
                                else { userGuideDivCd = 33; } // �Ǝ�

                                //userGdBdList = null;
                                // 2010/04/30 >>>
                                //int status = _userGuideAcs.SearchAllBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData);
                                int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData);
                                // 2010/04/30 <<<

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    isError = false; // ADD 2010/09/21
                                    foreach (UserGdBd userGdBd in userGdBdList)
                                    {
                                        if ((userGdBd.UserGuideDivCd == userGuideDivCd) && (userGdBd.GuideCode == code))
                                        {
                                            name = userGdBd.GuideName;
                                            chkflg = true;

                                            // 2010/04/30 >>>
                                            if (this._befortEditSelectionCode != code)
                                            //if (this._befortEditSelectionCode != code || this._beforEditSelectionName != name)
                                            // 2010/04/30 <<<
                                            {
                                                this.ViewGrid();
                                                this.ShipmentInit();
                                                this.BalanceInquiryInit();
                                                // 2010/04/30 Add >>>
                                                this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                                // 2010/04/30 Add <<<

                                                this._befortEditSelectionCode = code;
                                            }
                                            break;

                                        }
                                    }
                                }
                                if (chkflg == false)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                    // 2010/04/30 >>>
                                    //code = 0;
                                    code = -1;
                                    // 2010/04/30 <<<
                                    canChangeFocus = false;
                                    isError = true; // ADD 2010/09/21
                                }
                            }   // 2010/04/30 Add
                        }
                        //}   // 2010/04/30 Del
                        // �R�[�h�E���̃Z�b�g
                        // 2010/04/30 Add >>>
                        if (code == -1)
                            this.tNedit_SelectionCode.Clear();
                        else
                        // 2010/04/30 Add <<<
                            this.tNedit_SelectionCode.SetInt(code);
                        this.tEdit_SelectionName.Text = name;

                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_SelectionCode.Text.Trim().Length == 0)
                                        {
                                            e.NextCtrl = this.uButton_SelectionGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_FinancialYear;
                                        }
                                        
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }

                // �W�v���ځi�����j
                case "tEdit_EmployeeCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_EmployeeCode.Text.Trim();
                        string name = "";

                        if (code != "")
                        {
                            // �S���ҁE�󒍎ҁE���s��
                            EmployeeAcs employeeAcs = new EmployeeAcs();
                            Employee employee;
                            int status = employeeAcs.Read(out employee, this._enterpriseCode, code);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                isError = false; // ADD 2010/09/21
                                // ----- ADD 2010/09/20 ------------------>>>>>
                                if (employee.LogicalDeleteCode == 0)
                                {
                                // ----- ADD 2010/09/20 ------------------<<<<<
                                    name = employee.Name;

                                    if (this._beforEmployeeCode.Equals(code) == false)
                                    {
                                        this.ViewGrid();
                                        this.ShipmentInit();
                                        this.BalanceInquiryInit();
                                        // 2010/04/30 Add >>>
                                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                        // 2010/04/30 Add <<<

                                        this._beforEmployeeCode = code;
                                    }
                                // ----- ADD 2010/09/20 ------------------>>>>>
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    uLabel_SelectionCodeTitle.Text.Trim() + "�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                    isError = true; // ADD 2010/09/21
                                    code = "";
                                    canChangeFocus = false;
                                }
                                // ----- ADD 2010/09/20 ------------------<<<<<
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    uLabel_SelectionCodeTitle.Text.Trim() + "�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                isError = true; // ADD 2010/09/21
                                code = "";
                                canChangeFocus = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    uLabel_SelectionCodeTitle.Text.Trim() + "�̎擾�Ɏ��s���܂����B",
                                    status,
                                    MessageBoxButtons.OK);

                                code = "";
                                canChangeFocus = false;
                            }
                        }
                        // �R�[�h�E���̃Z�b�g
                        this.tEdit_EmployeeCode.Text = code;
                        this.tEdit_SelectionName.Text = name;

                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tEdit_EmployeeCode.Text.Trim().Length == 0)
                                        {
                                            e.NextCtrl = this.uButton_SelectionGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_FinancialYear;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }

                // �Ώ۔N�x
                case "tDateEdit_FinancialYear":
                    {
                        int code = this.tDateEdit_FinancialYear.GetDateYear();
                        //if (code == 0)  // DEL 2009/09/07
                        if (code == 0 || code == 1) // ADD 2009/09/07  �N�x��1����͂����ꍇ�ɃG���[�ŗ����邽�߉������
                        {
                            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);
                            e.NextCtrl = e.PrevCtrl;
                        }

                        if (this._beforFinancialYear != this.tDateEdit_FinancialYear.GetDateYear())
                        {
                            this.ViewGrid();
                            this.ShipmentInit();
                            this.BalanceInquiryInit();
                            // 2010/04/30 Add >>>
                            this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                            // 2010/04/30 Add <<<
                            
                            this._beforFinancialYear = this.tDateEdit_FinancialYear.GetDateYear();
                        }
                        break;
                    }
            }
		}

		/// <summary>
		/// ���ѕ\���O���b�h���C�A�E�g�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
            this.uLabel_HeaderTitle.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uLabel_HeaderTitle.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraLabel1.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraLabel1.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraLabel2.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraLabel2.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

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
            int titlWidth = 61;
            int defoWidth = 94;     //�i13���j
            int discWidth = 94;     //�i13���j
            int rateWidth = 54;     //�i 6���j
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Result.DisplayLayout.Bands[0].Columns)
			{
				// �S�Ă̗�����������\���ɂ���B
				col.Hidden = true;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
				col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX
                col.Format = moneyFormat;
                //col.Width = 95;
                col.Width = defoWidth;
                
            }

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

            moneyFormat = "0.00;-0.00;0";
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Format = moneyFormat;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Format = moneyFormat;

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.SizeInPoints = 11.25f;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Width = titlWidth;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPriceColumn.ColumnName].Width = discWidth;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPriceColumn.ColumnName].Width = discWidth;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Width = rateWidth;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Width = rateWidth;

            // ��\�����
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.SalesMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.ReturnedGoodsPriceColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.DiscountPriceColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GenuineSalesMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.TargetMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.AchievementRateColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitTargetMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.GrossProfitAchievRateColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.BeforeGenuineSalesMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.BeforeGrossProfitMoneyColumn.ColumnName].Hidden = false;
            //---DEL 2010/07/20---------------------->>>>>
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockGenuineSalesMoneyColumn.ColumnName].Hidden = true;
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockGrossProfitMoneyColumn.ColumnName].Hidden = true;
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummySumColumn.ColumnName].Hidden = true;
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderGenuineSalesMoneyColumn.ColumnName].Hidden = true;
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderGrossProfitMoneyColumn.ColumnName].Hidden = true;
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummySumColumn.ColumnName].Hidden = true;
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.StockDummyColumn.ColumnName].Hidden = true;
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.MonthResult.OrderDummyColumn.ColumnName].Hidden = true;
            //---DEL 2010/07/20----------------------<<<<<
        }

		/// <summary>
		/// �݌Ɏ��ѕ\���O���b�h���C�A�E�g�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_StockResult_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
            this.uGrid_StockResult.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_StockResult.DisplayLayout.Bands[0].ColHeadersVisible = false;

            string moneyFormat = "#,###,##0;-#,###,##0;0";
            // �t�H���g�T�C�Y�F11
            //int titlWidth = 59;
            //int defoWidth = 95;   //�i11���j
            //int discWidth = 88;   //�i10���j
            //int rateWidth = 57;   //�i 6���j
            //// �t�H���g�T�C�Y�F10
            //int titlWidth = 61;
            //int defoWidth = 97;     //�i13���j
            //int discWidth = 83;     //�i11���j
            //int rateWidth = 54;     //�i 6���j
            // �t�H���g�T�C�Y�F9
            int titlWidth = 61;
            int defoWidth = 94;     //�i13���j
            int discWidth = 94;     //�i13���j
            int rateWidth = 54;     //�i 6���j
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_StockResult.DisplayLayout.Bands[0].Columns)
			{
				// �S�Ă̗�����������\���ɂ���B
				col.Hidden = true;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
				col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
				col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX

                col.Format = moneyFormat;
                //col.Width = 95;
                col.Width = defoWidth;
            }
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].CellAppearance.BackColor = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].CellAppearance.BackColor2 = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].CellAppearance.BackColor = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].CellAppearance.BackColor2 = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;

            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.FontData.SizeInPoints = 11.25f;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.FontData.SizeInPoints = 11.25f;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].Width            = titlWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.ReturnedGoodsPriceColumn.ColumnName].Width  = discWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.DiscountPriceColumn.ColumnName].Width       = discWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].Width = defoWidth + rateWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].Width = defoWidth + rateWidth + defoWidth + defoWidth;
            
            // ��\�����
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.SalesMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.ReturnedGoodsPriceColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.DiscountPriceColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.GenuineSalesMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.GrossProfitMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].Hidden = false;

            // �Z���̌���
            List<string> mergedColumnListStockTitle = new List<string>();
            mergedColumnListStockTitle.Add(this._dataSet.StockResult.TitleColumn.ColumnName);

            foreach (string key in mergedColumnListStockTitle)
            {
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText;

            }
        }

		/// <summary>
		/// �c�[���o�[�c�[���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "ButtonTool_Close":
				{
					this.Close();
					break;
				}
				case "ButtonTool_Clear":
				{
                    this.ViewGrid();
                    this.ShipmentInit();
                    this.BalanceInquiryInit();
					this.Clear();
					this.timer_InitFocusSetting.Enabled = true;

                    //this.utc_InventTab.Tabs["GraphTab"].Visible = false; // DEL 2010/02/18
                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                    this.utc_InventTab.Tabs["GraphTab"].Visible = false; // ADD 2010/02/18
                    this.isSearch = false; // ADD 2010/09/20
                    break;
				}
				case "ButtonTool_Search":
				{
                    this.ViewGrid();
                    this.ShipmentInit();
                    this.BalanceInquiryInit();
                    this.isSearch = true; // ADD 2010/07/20
                    // 2010/04/30 >>>
                    //this.Search(this._enterpriseCode,
                    //            this.tEdit_SectionCode.DataText,
                    //            this.tNedit_SelectionCode.GetInt(),
                    //            this.tEdit_EmployeeCode.DataText,
                    //            this.tComboEditor_TotalDiv.SelectedIndex);
                    int status = this.Search(this._enterpriseCode,
                                             this.tEdit_SectionCode.DataText,
                                             this.tNedit_SelectionCode.GetInt(),
                                             this.tEdit_EmployeeCode.DataText,
                                             this.tComboEditor_TotalDiv.SelectedIndex);
                    // 2010/04/30 >>>

                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                    //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = true; // DEL 2009/01/28
                    if (status == 0)   // 2010/04/30 Add
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = true; // ADD 2010/02/18
                    break;
				}
            // --- DEL 2009/01/28 -------------------------------->>>>>
                //case "ButtonTool_Graph":
                //{
                //    this.ViewGraph();
                //    this.utc_InventTab.Focus();
                //    break;
                //}
                //case "ButtonTool_Setup":
                //{
                //    if (this._userSetupFrm == null)
                //        this._userSetupFrm = new DCHNB04180UC();

                //    this._userSetupFrm.ShowDialog();
                //    break;
                //}
            // --- DEL 2009/01/28 --------------------------------<<<<<
            // --- ADD 2010/02/18 -------------------------------->>>>>
                case "ButtonTool_Graph":
                {
                    this.ViewGraph();
                    this.utc_InventTab.Focus();
                    break;
                }
                case "ButtonTool_Setup":
                {
                    if (this._userSetupFrm == null)
                        this._userSetupFrm = new DCHNB04180UC();
                    
                    this._userSetupFrm.ShowDialog();
                    break;
                }
            // --- ADD 2010/02/18 --------------------------------<<<<<
            // --- ADD 2010/07/20 -------------------------------->>>>>
            case "ButtonTool_Text":
                {
                    this.ExportIntoTextFile(false);
                    break;
                }
            case "ButtonTool_Excel":
                {
                    this.exportIntoExcelData(true);
                    break;
                }
            // --- ADD 2010/07/20 --------------------------------<<<<<
            }
		}

		/// <summary>
		/// �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_InitFocusSetting_Tick(object sender, EventArgs e)
		{
			this.timer_InitFocusSetting.Enabled = false;
            this.tComboEditor_TotalDiv.Focus();

            // ��ʏ����ݒ菈��
            //�A�C�R��(��) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionGuide.ImageList = imageList16;
            this.uButton_SelectionGuide.ImageList = imageList16;
            this.uButton_SectionGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SelectionGuide.Appearance.Image = Size16_Index.STAR1;
        }

		/// <summary>
		/// ����f�[�^�O���b�h�Z���A�N�e�B�u��C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
		{
			//
		}

		/// <summary>
		/// ����f�[�^�O���b�h�G���^�[�C�x���g
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
		/// ����f�[�^�O���b�h���[�u�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_Leave(object sender, EventArgs e)
		{
			this.uStatusBar_Main.Text = "";
		}

		/// <summary>
		/// �t�H�[���I���O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void MAHNB04110UA_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		/// <summary>
		/// ����f�[�^�O���b�h�L�[�_�E���C�x���g
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

		/// <summary>
		/// �O���b�h�}�E�X�G���^�[�G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
			}
		}

		/// <summary>
		/// �O���b�h�}�E�X���[���G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
		}

		# endregion

        #region �K�C�h�{�^���N���b�N�C�x���g

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                tEdit_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                if (this._befortEditSectionCode.Equals(secInfoSet.SectionCode.Trim()) == false)
                {
                    this.ViewGrid();
                    this.ShipmentInit();
                    this.BalanceInquiryInit();
                    // 2010/04/30 Add >>>
                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                    // 2010/04/30 Add <<<
                    
                    this._befortEditSectionCode = this.tEdit_SectionCode.Text.Trim();
                }
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SelectionGuide_Click(object sender, EventArgs e)
        {
            int totalDiv = this.tComboEditor_TotalDiv.SelectedIndex;

            if (totalDiv == 1)
            {

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);
            }
            else if ((totalDiv == 2) || (totalDiv == 3) || (totalDiv == 4))
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                Employee employee;
                int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tEdit_EmployeeCode.Text = employee.EmployeeCode.Trim();
                    tEdit_SelectionName.Text = employee.Name.Trim();

                    if (this._beforEmployeeCode.Equals(tEdit_EmployeeCode.Text.Trim()) == false)
                    {
                        this.ViewGrid();
                        this.ShipmentInit();
                        this.BalanceInquiryInit();
                        // 2010/04/30 Add >>>
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        // 2010/04/30 Add <<<
                        
                        this._beforEmployeeCode = tEdit_EmployeeCode.Text.Trim();
                    }
                }
            }
            else if ((totalDiv == 5) || (totalDiv == 6))
            {
                int userGuideDivCd;
                if (totalDiv == 5) { userGuideDivCd = 21; } // �n��i�̔��G���A�j
                else               { userGuideDivCd = 33; } // �Ǝ�

                UserGuideAcs _userGuideAcs = new UserGuideAcs();
                UserGdHd userGdHd = new UserGdHd();
                UserGdBd userGdBd = new UserGdBd();
                int status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, userGuideDivCd);

                if (status == 0)
                {
                    tNedit_SelectionCode.SetInt(userGdBd.GuideCode);
                    tEdit_SelectionName.Text = userGdBd.GuideName;
                    // 2010/04/30 >>>
                    //if (this._befortEditSelectionCode != this.tNedit_SelectionCode.GetInt())
                    if (this._befortEditSelectionCode != this.tNedit_SelectionCode.GetInt() || this._beforEditSelectionName != this.tEdit_SelectionName.Text)
                    // 2010/04/30 <<<
                    {
                        this.ViewGrid();
                        this.ShipmentInit();
                        this.BalanceInquiryInit();
                        // 2010/04/30 Add >>>
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        // 2010/04/30 Add <<<

                        this._befortEditSelectionCode = this.tNedit_SelectionCode.GetInt();
                        this._beforEditSelectionName = this.tEdit_SelectionName.Text;   // 2010/04/30 Add
                    }
                }
            }
        }

        #endregion

        #region Private Method
        /// <summary>
        /// �W�v�敪�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tComboEditor_TotalDiv_SelectionChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            Point point = new Point();
            int totalDiv = this.tComboEditor_TotalDiv.SelectedIndex;

            size.Height = this.tNedit_SelectionCode.Size.Height;
            point.Y = this.tNedit_SelectionCode.Location.Y;

            // �W�v�Ώە\���ݒ�
            if (totalDiv == 0)
            {
                this.uLabel_SelectionCodeTitle.Visible = false;
                this.tEdit_SelectionName.Visible = false;
                this.uButton_SelectionGuide.Visible = false;
            }
            else
            {
                this.uLabel_SelectionCodeTitle.Visible = true;
                this.tEdit_SelectionName.Visible = true;
                this.uButton_SelectionGuide.Visible = true;
            }

            // �����\���ݒ�
            if (totalDiv == 1)
            {
                this.uLabel_TotalDayTitle.Visible = true;
                this.uLabel_Title.Visible = true;
                this.tEdit_TotalDay.Visible = true;
                this.tEdit_CollectCondName.Visible = true;
                this.tEdit_CollectMoneyName.Visible = true;
                this.tEdit_CollectMoneyDay.Visible = true;
            }
            else
            {
                this.uLabel_TotalDayTitle.Visible = false;
                this.uLabel_Title.Visible = false;
                this.tEdit_TotalDay.Visible = false;
                this.tEdit_CollectCondName.Visible = false;
                this.tEdit_CollectMoneyName.Visible = false;
                this.tEdit_CollectMoneyDay.Visible = false;
            }

            switch (totalDiv)
            {
                case 0: // ���_
                    {
                        this.tNedit_SelectionCode.Visible = false;
                        this.tEdit_EmployeeCode.Visible = false;
                        size.Width = SELECT_CUST;

                        this.utc_InventTab.Tabs["ShipmentTab"].Visible = true;
                        this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = false;
                        break;
                    }
                case 1: // ���Ӑ�
                    {
                        this.uLabel_SelectionCodeTitle.Text = TOTALDIV_CUST;
                        this.tNedit_SelectionCode.Visible = true;
                        this.tNedit_SelectionCode.ExtEdit.Column = 8;
                        this.tEdit_EmployeeCode.Visible = false;
                        size.Width = SELECT_CUST;
                        CustomerCk = false;

                        this.utc_InventTab.Tabs["ShipmentTab"].Visible = false;
                        this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = true;
                        this.tNedit_SelectionCode.NumEdit.ZeroDisp = false; // 2010/04/30 Add
                        break;
                    }
                case 2: // �S����
                case 3: // �󒍎�
                case 4: // ���s��
                    {
                        if      (totalDiv == 2) { this.uLabel_SelectionCodeTitle.Text = TOTALDIV_SEMP; }
                        else if (totalDiv == 3) { this.uLabel_SelectionCodeTitle.Text = TOTALDIV_FEMP; }
                        else if (totalDiv == 4) { this.uLabel_SelectionCodeTitle.Text = TOTALDIV_INPU; }
                        this.tNedit_SelectionCode.Visible = false;
                        this.tEdit_EmployeeCode.Visible = true;
                        size.Width = SELECT_EMP;

                        this.utc_InventTab.Tabs["ShipmentTab"].Visible = false;
                        this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = false;
                        this.tNedit_SelectionCode.NumEdit.ZeroDisp = false; // 2010/04/30 Add
                        break;
                    }
                case 5: // �n��
                    {
                        this.uLabel_SelectionCodeTitle.Text = TOTALDIV_AREA;
                        this.tNedit_SelectionCode.Visible = true;
                        this.tNedit_SelectionCode.ExtEdit.Column = 4;
                        this.tEdit_EmployeeCode.Visible = false;
                        size.Width = SELECT_AREA;

                        this.utc_InventTab.Tabs["ShipmentTab"].Visible = false;
                        this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = false;
                        this.tNedit_SelectionCode.NumEdit.ZeroDisp = true; // 2010/04/30 Add
                        break;
                    }
                case 6: // �Ǝ�
                    {
                        this.uLabel_SelectionCodeTitle.Text = TOTALDIV_TYPE;
                        this.tNedit_SelectionCode.Visible = true;
                        this.tNedit_SelectionCode.ExtEdit.Column = 4;
                        this.tEdit_EmployeeCode.Visible = false;
                        size.Width = SELECT_TYPE;

                        this.utc_InventTab.Tabs["ShipmentTab"].Visible = false;
                        this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = false;
                        this.tNedit_SelectionCode.NumEdit.ZeroDisp = true; // 2010/04/30 Add
                        break;
                    }
            }

            this.tNedit_SelectionCode.Size = size;

            point.X = this.tNedit_SelectionCode.Location.X + this.tNedit_SelectionCode.Size.Width + 2;
            this.tEdit_SelectionName.Location = point;

            point.X = point.X + this.tEdit_SelectionName.Size.Width + 2;
            this.uButton_SelectionGuide.Location = point;
                        
            this.Clear();
                       
        }

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        public bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // ���_����A�N�Z�X�N���X�C���X�^���X������
            //this.CreateSecInfoAcs();

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // �{�Ћ@�\���H
                if (secInfoSet.MainOfficeFuncFlag == 1)
                {
                    isMainOfficeFunc = true;
                }
            }

            return isMainOfficeFunc;
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            this.tNedit_SelectionCode.SetInt(customerInfo.CustomerCode);
            this.tEdit_SelectionName.Text = customerInfo.CustomerSnm;

            // -- UPD 2009/09/07 ------------------------------>>>
            //if (customerInfo.MngSectionCode == customerInfo.ClaimSectionCode &&
            //    customerInfo.CustomerCode == customerInfo.ClaimCode)
            if (customerInfo.MngSectionCode.Trim() == customerInfo.ClaimSectionCode.Trim() &&
                customerInfo.CustomerCode == customerInfo.ClaimCode &&
                customerInfo.ClaimSectionCode.Trim() == this.tEdit_SectionCode.Text.Trim())
            // -- UPD 2009/09/07 ------------------------------<<<
            {
                CustomerCk = true;
            }
            else
            {
                CustomerCk = false;
            }

            if (this._befortEditSelectionCode != this.tNedit_SelectionCode.GetInt())
            {
                this.ViewGrid();
                this.ShipmentInit();
                this.BalanceInquiryInit();
                // 2010/04/30 Add >>>
                this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                // 2010/04/30 Add <<<
                
                this._befortEditSelectionCode = this.tNedit_SelectionCode.GetInt();
            }
            // ������Z�b�g
            CollectMoneySelect(customerInfo);
        }

        /// <summary>
        /// ������\������
        /// </summary>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        private void CollectMoneySelect(CustomerInfo customerInfo)
        {
            this.tEdit_TotalDay.DataText = customerInfo.TotalDay.ToString() + "��";
            this.tEdit_CollectMoneyName.DataText = customerInfo.CollectMoneyName;
            this.tEdit_CollectMoneyDay.DataText = customerInfo.CollectMoneyDay.ToString() + "��";

            string condName = this._depositStAcs.GetDepsitStKindNm(this._enterpriseCode, customerInfo.CollectCond);
            this.tEdit_CollectCondName.DataText = condName;
            
        }

        /// <summary>
        /// ������\�������i�N���A�����j
        /// </summary>
        private void CollectMoneySelect()
        {
            this.tEdit_TotalDay.DataText = "";
            this.tEdit_CollectMoneyName.DataText = "";
            this.tEdit_CollectMoneyDay.DataText = "";
            this.tEdit_CollectCondName.DataText = "";
        }

        /// <summary>
        /// ���_�p�^�u����������
        /// </summary>
        private void ShipmentInit()
        {
            #region ���l���ڂ̃R���g���[���z��
            Broadleaf.Library.Windows.Forms.TNedit[] tNeditctl;
            tNeditctl = new Broadleaf.Library.Windows.Forms.TNedit[]{this.tNedit_StockSales,
                                                                    this.tNedit_StockGross,
                                                                    this.tNedit_StockSalesTimes,
                                                                    this.tNedit_OrderSales,
                                                                    this.tNedit_OrderGross,
                                                                    this.tNedit_OrderSalesTimes,
                                                                    this.tNedit_SumSales,
                                                                    this.tNedit_SumGross,
                                                                    this.tNedit_SumSalesTimes,
                                                                    this.tNedit_SlipSales,
                                                                    this.tNedit_SlipGross,
                                                                    this.tNedit_SlipSalesTimes,
                                                                    this.tNedit_Stock01,
                                                                    this.tNedit_Stock02,
                                                                    this.tNedit_Stock03,
                                                                    this.tNedit_Stock04,
                                                                    this.tNedit_Stock05,
                                                                    this.tNedit_Stock06,
                                                                    this.tNedit_Stock07,
                                                                    this.tNedit_Stock08,
                                                                    this.tNedit_Stock09,
                                                                    this.tNedit_Stock10,
                                                                    this.tNedit_Stock11,
                                                                    this.tNedit_Stock12,
                                                                    this.tNedit_Order01,
                                                                    this.tNedit_Order02,
                                                                    this.tNedit_Order03,
                                                                    this.tNedit_Order04,
                                                                    this.tNedit_Order05,
                                                                    this.tNedit_Order06,
                                                                    this.tNedit_Order07,
                                                                    this.tNedit_Order08,
                                                                    this.tNedit_Order09,
                                                                    this.tNedit_Order10,
                                                                    this.tNedit_Order11,
                                                                    this.tNedit_Order12,
                                                                    this.tNedit_Sum01,
                                                                    this.tNedit_Sum02,
                                                                    this.tNedit_Sum03,
                                                                    this.tNedit_Sum04,
                                                                    this.tNedit_Sum05,
                                                                    this.tNedit_Sum06,
                                                                    this.tNedit_Sum07,
                                                                    this.tNedit_Sum08,
                                                                    this.tNedit_Sum09,
                                                                    this.tNedit_Sum10,
                                                                    this.tNedit_Sum11,
                                                                    this.tNedit_Sum12,
                                                                    this.tNedit_Slip01,
                                                                    this.tNedit_Slip02,
                                                                    this.tNedit_Slip03,
                                                                    this.tNedit_Slip04,
                                                                    this.tNedit_Slip05,
                                                                    this.tNedit_Slip06,
                                                                    this.tNedit_Slip07,
                                                                    this.tNedit_Slip08,
                                                                    this.tNedit_Slip09,
                                                                    this.tNedit_Slip10,
                                                                    this.tNedit_Slip11,
                                                                    this.tNedit_Slip12};
            #endregion

            #region ���ڃT�C�Y�ݒ聕���ڂ̏�����
            Size ctlsize = new Size(131, 26);
            for (int ix = 0; ix < tNeditctl.Length; ix++)
            {
                tNeditctl[ix].Size = ctlsize;
                tNeditctl[ix].Text = string.Empty;
            }
            #endregion

            #region �N�����x���̃R���g���[���z��
            Infragistics.Win.Misc.UltraLabel[] lblctl;

            lblctl = new Infragistics.Win.Misc.UltraLabel[]{this.lblMonth01,
                                                            this.lblMonth02,
                                                            this.lblMonth03,
                                                            this.lblMonth04,
                                                            this.lblMonth05,
                                                            this.lblMonth06,
                                                            this.lblMonth07,
                                                            this.lblMonth08,
                                                            this.lblMonth09,
                                                            this.lblMonth10,
                                                            this.lblMonth11,
                                                            this.lblMonth12};
            #endregion
            
            //�N����ݒ�
            int companyBiginMonth = this._companyBiginMonth;
            for (int ix = 0; ix < 12; ix++)
            {
                int biginMonth = companyBiginMonth + ix;
                if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                lblctl[ix].Text = biginMonth.ToString() + "��";
            }

        }

        /// <summary>
        /// �o�׎��яƉ��ʂɒl��ݒ�
        /// </summary>
        private void SetShipment()
        {
            long stockval = 0;
            long orderval = 0;
            long sumval = 0;
            long slipval = 0;

            #region ���l���ڂ̃R���g���[���z��
            Broadleaf.Library.Windows.Forms.TNedit[] tNeditStockctl;
            tNeditStockctl = new Broadleaf.Library.Windows.Forms.TNedit[]{
                                                                    this.tNedit_Stock01,
                                                                    this.tNedit_Stock02,
                                                                    this.tNedit_Stock03,
                                                                    this.tNedit_Stock04,
                                                                    this.tNedit_Stock05,
                                                                    this.tNedit_Stock06,
                                                                    this.tNedit_Stock07,
                                                                    this.tNedit_Stock08,
                                                                    this.tNedit_Stock09,
                                                                    this.tNedit_Stock10,
                                                                    this.tNedit_Stock11,
                                                                    this.tNedit_Stock12};

            Broadleaf.Library.Windows.Forms.TNedit[] tNeditOrderctl;
            tNeditOrderctl = new Broadleaf.Library.Windows.Forms.TNedit[]{
                                                                    this.tNedit_Order01,
                                                                    this.tNedit_Order02,
                                                                    this.tNedit_Order03,
                                                                    this.tNedit_Order04,
                                                                    this.tNedit_Order05,
                                                                    this.tNedit_Order06,
                                                                    this.tNedit_Order07,
                                                                    this.tNedit_Order08,
                                                                    this.tNedit_Order09,
                                                                    this.tNedit_Order10,
                                                                    this.tNedit_Order11,
                                                                    this.tNedit_Order12};

            Broadleaf.Library.Windows.Forms.TNedit[] tNeditSumctl;
            tNeditSumctl = new Broadleaf.Library.Windows.Forms.TNedit[]{
                                                                    this.tNedit_Sum01,
                                                                    this.tNedit_Sum02,
                                                                    this.tNedit_Sum03,
                                                                    this.tNedit_Sum04,
                                                                    this.tNedit_Sum05,
                                                                    this.tNedit_Sum06,
                                                                    this.tNedit_Sum07,
                                                                    this.tNedit_Sum08,
                                                                    this.tNedit_Sum09,
                                                                    this.tNedit_Sum10,
                                                                    this.tNedit_Sum11,
                                                                    this.tNedit_Sum12};

            Broadleaf.Library.Windows.Forms.TNedit[] tNeditSlipctl;
            tNeditSlipctl = new Broadleaf.Library.Windows.Forms.TNedit[]{
                                                                    this.tNedit_Slip01,
                                                                    this.tNedit_Slip02,
                                                                    this.tNedit_Slip03,
                                                                    this.tNedit_Slip04,
                                                                    this.tNedit_Slip05,
                                                                    this.tNedit_Slip06,
                                                                    this.tNedit_Slip07,
                                                                    this.tNedit_Slip08,
                                                                    this.tNedit_Slip09,
                                                                    this.tNedit_Slip10,
                                                                    this.tNedit_Slip11,
                                                                    this.tNedit_Slip12};
            #endregion

            for (int ix = 0; ix < _dataSet.ShipmentResult.Count; ix++)
            {
                if (_dataSet.ShipmentResult[ix].IsStockNull())
                {
                    tNeditStockctl[ix].Text = string.Empty;
                    tNeditOrderctl[ix].Text = string.Empty;
                    tNeditSumctl[ix].Text = string.Empty;
                    tNeditSlipctl[ix].Text = string.Empty;
                }
                else
                {
                    tNeditStockctl[ix].Text = _dataSet.ShipmentResult[ix].Stock.ToString("#,##0");
                    tNeditOrderctl[ix].Text = _dataSet.ShipmentResult[ix].Order.ToString("#,##0");
                    tNeditSumctl[ix].Text = _dataSet.ShipmentResult[ix].Sum.ToString("#,##0");
                    tNeditSlipctl[ix].Text = _dataSet.ShipmentResult[ix].Slip.ToString("#,##0");

                    stockval = stockval + _dataSet.ShipmentResult[ix].Stock;
                    orderval = orderval + _dataSet.ShipmentResult[ix].Order;
                    sumval = sumval + _dataSet.ShipmentResult[ix].Sum;
                    slipval = slipval + _dataSet.ShipmentResult[ix].Slip;
                }
            }

            // �o�׉񐔐ݒ�
            this.tNedit_StockSalesTimes.Text = stockval.ToString("#,##0");
            this.tNedit_OrderSalesTimes.Text = orderval.ToString("#,##0");
            this.tNedit_SumSalesTimes.Text = sumval.ToString("#,##0");
            this.tNedit_SlipSalesTimes.Text = slipval.ToString("#,##0");
            
            //�@�����さ�e��
            this.tNedit_StockSales.Text = _dataSet.StockResult[3].GenuineSalesMoney.ToString("#,##0");
            this.tNedit_StockGross.Text = _dataSet.StockResult[3].GrossProfitMoney.ToString("#,##0");
            this.tNedit_OrderSales.Text = _dataSet.StockResult[4].GenuineSalesMoney.ToString("#,##0");
            this.tNedit_OrderGross.Text = _dataSet.StockResult[4].GrossProfitMoney.ToString("#,##0");
            this.tNedit_SumSales.Text = _dataSet.StockResult[5].GenuineSalesMoney.ToString("#,##0");
            this.tNedit_SumGross.Text = _dataSet.StockResult[5].GrossProfitMoney.ToString("#,##0");
        }

        /// <summary>
        /// ���Ӑ�p�^�u����������
        /// </summary>
        private void BalanceInquiryInit()
        {
            #region �������̂�ݒ�
            DepositSt depositSt;
            int status = this._depositStAcs.Read(out depositSt, this._enterpriseCode, 0);

            this._depositStKindCd = new int[8] { depositSt.DepositStKindCd1, depositSt.DepositStKindCd2, depositSt.DepositStKindCd3, depositSt.DepositStKindCd4, depositSt.DepositStKindCd5, depositSt.DepositStKindCd6, depositSt.DepositStKindCd7, depositSt.DepositStKindCd8 };
            this._depositcd = new int[8] { 51, 52, 53, 54, 56, 58, 59, 60 };
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.lblDeposit01.Text = depositSt.DepositStKindCdNm1.Replace("���o�^", string.Empty);
                this.lblDeposit02.Text = depositSt.DepositStKindCdNm2.Replace("���o�^", string.Empty);
                this.lblDeposit03.Text = depositSt.DepositStKindCdNm3.Replace("���o�^", string.Empty);
                this.lblDeposit04.Text = depositSt.DepositStKindCdNm4.Replace("���o�^", string.Empty);
                this.lblDeposit05.Text = depositSt.DepositStKindCdNm5.Replace("���o�^", string.Empty);
                this.lblDeposit06.Text = depositSt.DepositStKindCdNm6.Replace("���o�^", string.Empty);
                this.lblDeposit07.Text = depositSt.DepositStKindCdNm7.Replace("���o�^", string.Empty);
                this.lblDeposit08.Text = depositSt.DepositStKindCdNm8.Replace("���o�^", string.Empty);
            }
            else
            {
                this.lblDeposit01.Text = string.Empty;
                this.lblDeposit02.Text = string.Empty;
                this.lblDeposit03.Text = string.Empty;
                this.lblDeposit04.Text = string.Empty;
                this.lblDeposit05.Text = string.Empty;
                this.lblDeposit06.Text = string.Empty;
                this.lblDeposit07.Text = string.Empty;
                this.lblDeposit08.Text = string.Empty;
            }
            #endregion

            #region ���l���ڂ̃R���g���[���z��
            Broadleaf.Library.Windows.Forms.TNedit[] tNeditctl;
            tNeditctl = new Broadleaf.Library.Windows.Forms.TNedit[]{this.tNedit_3MthDemand,
                                                                    this.tNedit_3MthMonth,
                                                                    this.tNedit_2MthDemand,
                                                                    this.tNedit_2MthMonth,
                                                                    this.tNedit_1MthDemand,
                                                                    this.tNedit_1MthMonth,
                                                                    this.tNeditDepositDemand01,
                                                                    this.tNeditDepositDemand02,
                                                                    this.tNeditDepositDemand03,
                                                                    this.tNeditDepositDemand04,
                                                                    this.tNeditDepositDemand05,
                                                                    this.tNeditDepositDemand06,
                                                                    this.tNeditDepositDemand07,
                                                                    this.tNeditDepositDemand08,
                                                                    this.tNeditDepositDemand09,
                                                                    this.tNeditDepositDemand10,
                                                                    this.tNeditDepositDemandSum,
                                                                    this.tNeditDepositMonth01,
                                                                    this.tNeditDepositMonth02,
                                                                    this.tNeditDepositMonth03,
                                                                    this.tNeditDepositMonth04,
                                                                    this.tNeditDepositMonth05,
                                                                    this.tNeditDepositMonth06,
                                                                    this.tNeditDepositMonth07,
                                                                    this.tNeditDepositMonth08,
                                                                    this.tNeditDepositMonth09,
                                                                    this.tNeditDepositMonth10,
                                                                    this.tNeditDepositMonthSum,
                                                                    this.tNedit_SlipDemand,
                                                                    this.tNedit_SlipMonth,
                                                                    this.tNedit_SlipTerm,
                                                                    this.tNedit_PureSalesDemand,
                                                                    this.tNedit_PureReturnedDemand,
                                                                    this.tNedit_PureDiscountDemand,
                                                                    this.tNedit_PureGenuineSalesDemand,
                                                                    this.tNedit_PureGrossDemand,
                                                                    this.tNedit_PureSalesMonth,
                                                                    this.tNedit_PureReturnedMonth,
                                                                    this.tNedit_PureDiscountMonth,
                                                                    this.tNedit_PureGenuineSalesMonth,
                                                                    this.tNedit_PureGrossMonth,
                                                                    this.tNedit_PureSalesTerm,
                                                                    this.tNedit_PureReturnedTerm,
                                                                    this.tNedit_PureDiscountTerm,
                                                                    this.tNedit_PureGenuineSalesTerm,
                                                                    this.tNedit_PureGrossTerm,
                                                                    this.tNedit_SuperiorSalesDemand,
                                                                    this.tNedit_SuperiorReturnedDemand,
                                                                    this.tNedit_SuperiorDiscountDemand,
                                                                    this.tNedit_SuperiorGenuineSalesDemand,
                                                                    this.tNedit_SuperiorGrossDemand,
                                                                    this.tNedit_SuperiorSalesMonth,
                                                                    this.tNedit_SuperiorReturnedMonth,
                                                                    this.tNedit_SuperiorDiscountMonth,
                                                                    this.tNedit_SuperiorGenuineSalesMonth,
                                                                    this.tNedit_SuperiorGrossMonth,
                                                                    this.tNedit_SuperiorSalesTerm,
                                                                    this.tNedit_SuperiorReturnedTerm,
                                                                    this.tNedit_SuperiorDiscountTerm,
                                                                    this.tNedit_SuperiorGenuineSalesTerm,
                                                                    this.tNedit_SuperiorGrossTerm,
                                                                    this.tNedit_SumSalesDemand,
                                                                    this.tNedit_SumReturnedDemand,
                                                                    this.tNedit_SumDiscountDemand,
                                                                    this.tNedit_SumGenuineSalesDemand,
                                                                    this.tNedit_SumGrossDemand,
                                                                    this.tNedit_SumSalesMonth,
                                                                    this.tNedit_SumReturnedMonth,
                                                                    this.tNedit_SumDiscountMonth,
                                                                    this.tNedit_SumGenuineSalesMonth,
                                                                    this.tNedit_SumGrossMonth,
                                                                    this.tNedit_SumSalesTerm,
                                                                    this.tNedit_SumReturnedTerm,
                                                                    this.tNedit_SumDiscountTerm,
                                                                    this.tNedit_SumGenuineSalesTerm,
                                                                    this.tNedit_SumGrossTerm,
                                                                    this.tNedit_TaxDemand,
                                                                    this.tNedit_TaxMonth,
                                                                    this.tNedit_NowDemand,
                                                                    this.tNedit_NowMonth};
            #endregion

            #region ���ڃT�C�Y�ݒ聕���ڂ̏�����
            Size ctlsize = new Size(131, 26);
            for (int ix = 0; ix < tNeditctl.Length; ix++)
            {
                tNeditctl[ix].Size = ctlsize;
                tNeditctl[ix].Text = string.Empty;
            }
            #endregion
        }

        /// <summary>
        /// �c���Ɖ��ʂɒl��ݒ�
        /// </summary>
        private void SetBalanceInquiry()
        {

            this.tNedit_3MthDemand.Text = _dataSet.StockOrderResult[0].AcpOdrTtl3TmBfBlDmd.ToString("#,##0");
            this.tNedit_2MthDemand.Text = _dataSet.StockOrderResult[0].AcpOdrTtl2TmBfBlDmd.ToString("#,##0");
            this.tNedit_1MthDemand.Text = _dataSet.StockOrderResult[0].LastTimeDemand.ToString("#,##0");
            this.tNedit_1MthMonth.Text = _dataSet.StockOrderResult[0].LastTimeAccRec.ToString("#,##0");

            long DepositDemand = 0;
            long SepositMonth = 0;
            for (int i = 0; i < 8; i++)
            {
                #region �Ώےl�̕ۑ�
                switch (i)
                {
                    case 0:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand01;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth01;
                        break;
                    case 1:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand02;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth02;
                        break;
                    case 2:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand03;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth03;
                        break;
                    case 3:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand04;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth04;
                        break;
                    case 4:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand05;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth05;
                        break;
                    case 5:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand06;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth06;
                        break;
                    case 6:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand07;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth07;
                        break;
                    case 7:
                        DepositDemand = _dataSet.StockOrderResult[0].DepositDemand08;
                        SepositMonth = _dataSet.StockOrderResult[0].DepositMonth08;
                        break;
                }
                #endregion

                if (this._depositStKindCd[0] == _depositcd[i])
                {
                    this.tNeditDepositDemand01.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth01.Text = SepositMonth.ToString("#,##0");
                }
                if (this._depositStKindCd[1] == _depositcd[i])
                {
                    this.tNeditDepositDemand02.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth02.Text = SepositMonth.ToString("#,##0");
                }
                if (this._depositStKindCd[2] == _depositcd[i])
                {
                    this.tNeditDepositDemand03.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth03.Text = SepositMonth.ToString("#,##0");
                }
                if (this._depositStKindCd[3] == _depositcd[i])
                {
                    this.tNeditDepositDemand04.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth04.Text = SepositMonth.ToString("#,##0");
                }
                if (this._depositStKindCd[4] == _depositcd[i])
                {
                    this.tNeditDepositDemand05.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth05.Text = SepositMonth.ToString("#,##0");
                }
                if (this._depositStKindCd[5] == _depositcd[i])
                {
                    this.tNeditDepositDemand06.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth06.Text = SepositMonth.ToString("#,##0");
                }
                if (this._depositStKindCd[6] == _depositcd[i])
                {
                    this.tNeditDepositDemand07.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth07.Text = SepositMonth.ToString("#,##0");
                }
                if (this._depositStKindCd[7] == _depositcd[i])
                {
                    this.tNeditDepositDemand08.Text = DepositDemand.ToString("#,##0");
                    this.tNeditDepositMonth08.Text = SepositMonth.ToString("#,##0");
                }
            }

            
            this.tNeditDepositDemand09.Text = _dataSet.StockOrderResult[0].ThisTimeFeeDmdNrml.ToString("#,##0");
            this.tNeditDepositDemand10.Text = _dataSet.StockOrderResult[0].ThisTimeDisDmdNrml.ToString("#,##0");
            this.tNeditDepositDemandSum.Text = _dataSet.StockOrderResult[0].ThisTimeSumDmdNrml.ToString("#,##0");
            this.tNeditDepositMonth09.Text = _dataSet.StockOrderResult[0].ThisMThisTimeFeeDmdNrml.ToString("#,##0");
            this.tNeditDepositMonth10.Text = _dataSet.StockOrderResult[0].ThisMThisTimeDisDmdNrml.ToString("#,##0");
            this.tNeditDepositMonthSum.Text = _dataSet.StockOrderResult[0].ThisMThisTimeSumDmdNrml.ToString("#,##0");
            this.tNedit_SlipDemand.Text = _dataSet.StockOrderResult[0].SlipDemand.ToString("#,##0");
            this.tNedit_SlipMonth.Text = _dataSet.StockOrderResult[0].SlipMonth.ToString("#,##0");

            this.tNedit_PureSalesDemand.Text = _dataSet.StockOrderResult[0].PureSalesDemand.ToString("#,##0");
            // -- UPD 2009/09/07 -------------------------------------->>>
            //�����𔽓]�����ĕ\������
            //this.tNedit_PureReturnedDemand.Text = _dataSet.StockOrderResult[0].PureReturnedDemand.ToString("#,##0");
            //this.tNedit_PureDiscountDemand.Text = _dataSet.StockOrderResult[0].PureDiscountDemand.ToString("#,##0");
            this.tNedit_PureReturnedDemand.Text = (_dataSet.StockOrderResult[0].PureReturnedDemand * -1).ToString("#,##0");
            this.tNedit_PureDiscountDemand.Text = (_dataSet.StockOrderResult[0].PureDiscountDemand * -1).ToString("#,##0");
            // -- UPD 2009/09/07 --------------------------------------<<<
            this.tNedit_PureGenuineSalesDemand.Text = _dataSet.StockOrderResult[0].PureGenuineSalesDemand.ToString("#,##0");
            this.tNedit_PureSalesMonth.Text = _dataSet.StockOrderResult[0].PureSalesMonth.ToString("#,##0");
            // -- UPD 2009/09/07 -------------------------------------->>>
            //�����𔽓]�����ĕ\������
            //this.tNedit_PureReturnedMonth.Text = _dataSet.StockOrderResult[0].PureReturnedMonth.ToString("#,##0");
            //this.tNedit_PureDiscountMonth.Text = _dataSet.StockOrderResult[0].PureDiscountMonth.ToString("#,##0");
            this.tNedit_PureReturnedMonth.Text = (_dataSet.StockOrderResult[0].PureReturnedMonth * -1).ToString("#,##0");
            this.tNedit_PureDiscountMonth.Text = (_dataSet.StockOrderResult[0].PureDiscountMonth * -1).ToString("#,##0");
            // -- UPD 2009/09/07 --------------------------------------<<<
            this.tNedit_PureGenuineSalesMonth.Text = _dataSet.StockOrderResult[0].PureGenuineSalesMonth.ToString("#,##0");
            this.tNedit_PureGrossMonth.Text = _dataSet.StockOrderResult[0].PureGrossMonth.ToString("#,##0");
            this.tNedit_SuperiorSalesDemand.Text = _dataSet.StockOrderResult[0].SuperiorSalesDemand.ToString("#,##0");
            // -- UPD 2009/09/07 -------------------------------------->>>
            //�����𔽓]�����ĕ\������
            //this.tNedit_SuperiorReturnedDemand.Text = _dataSet.StockOrderResult[0].SuperiorReturnedDemand.ToString("#,##0");
            //this.tNedit_SuperiorDiscountDemand.Text = _dataSet.StockOrderResult[0].SuperiorDiscountDemand.ToString("#,##0");
            this.tNedit_SuperiorReturnedDemand.Text = (_dataSet.StockOrderResult[0].SuperiorReturnedDemand * -1).ToString("#,##0");
            this.tNedit_SuperiorDiscountDemand.Text = (_dataSet.StockOrderResult[0].SuperiorDiscountDemand * -1).ToString("#,##0");
            // -- UPD 2009/09/07 --------------------------------------<<<
            this.tNedit_SuperiorGenuineSalesDemand.Text = _dataSet.StockOrderResult[0].SuperiorGenuineSalesDemand.ToString("#,##0");
            this.tNedit_SuperiorSalesMonth.Text = _dataSet.StockOrderResult[0].SuperiorSalesMonth.ToString("#,##0");
            // -- UPD 2009/09/07 -------------------------------------->>>
            //�����𔽓]�����ĕ\������
            //this.tNedit_SuperiorReturnedMonth.Text = _dataSet.StockOrderResult[0].SuperiorReturnedMonth.ToString("#,##0");
            //this.tNedit_SuperiorDiscountMonth.Text = _dataSet.StockOrderResult[0].SuperiorDiscountMonth.ToString("#,##0");
            this.tNedit_SuperiorReturnedMonth.Text = (_dataSet.StockOrderResult[0].SuperiorReturnedMonth * -1).ToString("#,##0");
            this.tNedit_SuperiorDiscountMonth.Text = (_dataSet.StockOrderResult[0].SuperiorDiscountMonth * -1).ToString("#,##0");
            // -- UPD 2009/09/07 --------------------------------------<<<
            this.tNedit_SuperiorGenuineSalesMonth.Text = _dataSet.StockOrderResult[0].SuperiorGenuineSalesMonth.ToString("#,##0");
            this.tNedit_SuperiorGrossMonth.Text = _dataSet.StockOrderResult[0].SuperiorGrossMonth.ToString("#,##0");
            this.tNedit_SumSalesDemand.Text = _dataSet.StockOrderResult[0].SumSalesDemand.ToString("#,##0");
            // -- UPD 2009/09/07 -------------------------------------->>>
            //�����𔽓]�����ĕ\������
            //this.tNedit_SumReturnedDemand.Text = _dataSet.StockOrderResult[0].SumReturnedDemand.ToString("#,##0");
            //this.tNedit_SumDiscountDemand.Text = _dataSet.StockOrderResult[0].SumDiscountDemand.ToString("#,##0");
            this.tNedit_SumReturnedDemand.Text = (_dataSet.StockOrderResult[0].SumReturnedDemand * -1).ToString("#,##0");
            this.tNedit_SumDiscountDemand.Text = (_dataSet.StockOrderResult[0].SumDiscountDemand * -1).ToString("#,##0");
            // -- UPD 2009/09/07 --------------------------------------<<<
            this.tNedit_SumGenuineSalesDemand.Text = _dataSet.StockOrderResult[0].SumGenuineSalesDemand.ToString("#,##0");
            this.tNedit_SumSalesMonth.Text = _dataSet.StockOrderResult[0].SumSalesMonth.ToString("#,##0");
            // -- UPD 2009/09/07 -------------------------------------->>>
            //�����𔽓]�����ĕ\������
            //this.tNedit_SumReturnedMonth.Text = _dataSet.StockOrderResult[0].SumReturnedMonth.ToString("#,##0");
            //this.tNedit_SumDiscountMonth.Text = _dataSet.StockOrderResult[0].SumDiscountMonth.ToString("#,##0");
            this.tNedit_SumReturnedMonth.Text = (_dataSet.StockOrderResult[0].SumReturnedMonth * -1).ToString("#,##0");
            this.tNedit_SumDiscountMonth.Text = (_dataSet.StockOrderResult[0].SumDiscountMonth * -1).ToString("#,##0");
            // -- UPD 2009/09/07 --------------------------------------<<<
            this.tNedit_SumGenuineSalesMonth.Text = _dataSet.StockOrderResult[0].SumGenuineSalesMonth.ToString("#,##0");
            this.tNedit_SumGrossMonth.Text = _dataSet.StockOrderResult[0].SumGrossMonth.ToString("#,##0");
            this.tNedit_TaxDemand.Text = _dataSet.StockOrderResult[0].OfsThisSalesTax.ToString("#,##0");
            this.tNedit_TaxMonth.Text = _dataSet.StockOrderResult[0].ThisMOfsThisSalesTax.ToString("#,##0");
            this.tNedit_NowDemand.Text = _dataSet.StockOrderResult[0].BalanceDemand.ToString("#,##0");
            this.tNedit_NowMonth.Text = _dataSet.StockOrderResult[0].BalanceMonth.ToString("#,##0");

            // �`�[����
            long slipval = 0;

            for (int ix = 0; ix < _dataSet.ShipmentResult.Count; ix++)
            {
                if (_dataSet.ShipmentResult[ix].IsStockNull() == false)                
                {
                    slipval = slipval + _dataSet.ShipmentResult[ix].Slip;
                }
            }

            this.tNedit_SlipTerm.Text = slipval.ToString("#,##0");

            //�@�������D�ǁ����v�i�����j
            this.tNedit_PureSalesTerm.Text = _dataSet.StockResult[2].SalesMoney.ToString("#,##0");
            this.tNedit_PureReturnedTerm.Text = _dataSet.StockResult[2].ReturnedGoodsPrice.ToString("#,##0");
            this.tNedit_PureDiscountTerm.Text = _dataSet.StockResult[2].DiscountPrice.ToString("#,##0");
            this.tNedit_PureGenuineSalesTerm.Text = _dataSet.StockResult[2].GenuineSalesMoney.ToString("#,##0");
            this.tNedit_PureGrossTerm.Text = _dataSet.StockResult[2].GrossProfitMoney.ToString("#,##0");
            this.tNedit_SuperiorSalesTerm.Text = _dataSet.StockResult[5].SalesMoney.ToString("#,##0");
            this.tNedit_SuperiorReturnedTerm.Text = _dataSet.StockResult[5].ReturnedGoodsPrice.ToString("#,##0");
            this.tNedit_SuperiorDiscountTerm.Text = _dataSet.StockResult[5].DiscountPrice.ToString("#,##0");
            this.tNedit_SuperiorGenuineSalesTerm.Text = _dataSet.StockResult[5].GenuineSalesMoney.ToString("#,##0");
            this.tNedit_SuperiorGrossTerm.Text = _dataSet.StockResult[5].GrossProfitMoney.ToString("#,##0");
            this.tNedit_SumSalesTerm.Text = _dataSet.StockResult[8].SalesMoney.ToString("#,##0");
            this.tNedit_SumReturnedTerm.Text = _dataSet.StockResult[8].ReturnedGoodsPrice.ToString("#,##0");
            this.tNedit_SumDiscountTerm.Text = _dataSet.StockResult[8].DiscountPrice.ToString("#,##0");
            this.tNedit_SumGenuineSalesTerm.Text = _dataSet.StockResult[8].GenuineSalesMoney.ToString("#,##0");
            this.tNedit_SumGrossTerm.Text = _dataSet.StockResult[8].GrossProfitMoney.ToString("#,##0");
        }

        /// <summary>
        /// �^�u�؂�ւ����̐���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void utc_InventTab_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab == null) return;
            
            string key = e.Tab.Key;

            if (key.Equals("BalanceInquiryTab"))
            {
                // ���N�x�̂�
                if (this.tDateEdit_FinancialYear.GetDateYear() != this._financialYear)
                {
                    // �N�Ԏ��яƉ�^�u�������I�ɕ\��
                    this.utc_InventTab.SelectedTab = this.utc_InventTab.Tabs["ResultsTab"];
                    //�@���b�Z�[�W��\��
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�{�N�x�̂ݑI���\�ł��B",
                            -1,
                            MessageBoxButtons.OK);

                    return;
                }

                //�������Ӑ�ł͂Ȃ��ꍇ
                if (CustomerCk == false)
                {
                    // �N�Ԏ��яƉ�^�u�������I�ɕ\��
                    this.utc_InventTab.SelectedTab = this.utc_InventTab.Tabs["ResultsTab"];
                    //�@���b�Z�[�W��\��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�������Ӑ�ȊO�͎Q�Ƃł��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// �W�v�敪�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_TotalDiv_ValueChanged(object sender, EventArgs e)
        {
            if (this.startflg == true)
            {
                this.ViewGrid();
                this.ShipmentInit();
                this.BalanceInquiryInit();

                // �O���b�g�\��
                this.uGrid_StockResult_LayoutSet();
            }
            this.startflg = true;
        }
        
�@�@�@�@#region ���I�v�V������񐧌䏈��

        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : xuhj </br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>             �e�L�X�g�o�́AExcel�o�͋@�\���I�v�V����������悤�ɏC��</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            //Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps; // DEL 2010/08/02

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
            //�e�L�X�g�o�̓I�v�V�������L���̏ꍇ
            if (this._opt_TextOutput == (int)Option.ON)
            {
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = true;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = true;
                //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                this._userSetupFrm.uTabControlSet(true); // ADD 2010/08/23
            }
            //�e�L�X�g�o�̓I�v�V�����������̏ꍇ
            else
            {
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                //�ݒ��ʂ̃e�L�X�g�o�̓^�u��\������
                this._userSetupFrm.uTabControlSet(false);// ADD 2010/08/23
            }
            #endregion
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
                this._userSetupFrm.uTabControlSet(false);// ADD 2010/08/23
            }
        }
        #endregion ���I�v�V������񐧌䏈��

        /// <summary>
        /// �O���b�g�\������
        /// </summary>
        private void uGrid_StockResult_LayoutSet()
        {
            this.uGrid_StockResult.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_StockResult.DisplayLayout.Bands[0].ColHeadersVisible = false;

            string moneyFormat = "#,###,##0;-#,###,##0;0";
            // �t�H���g�T�C�Y�F9
            int titlWidth = 61;
            int defoWidth = 94;     //�i13���j
            int discWidth = 94;     //�i13���j
            int rateWidth = 54;     //�i 6���j
            float size = 11.25f;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_StockResult.DisplayLayout.Bands[0].Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                col.CellAppearance.FontData.SizeInPoints = 9f;   // �t�H���g�T�C�Y�ύX

                col.Format = moneyFormat;
                col.Width = defoWidth;
            }

            if (this.tComboEditor_TotalDiv.SelectedIndex == 1)
            {
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.FontData.SizeInPoints = 10.5f;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].Width = 20;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
                this.uGrid_StockResult.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
                titlWidth = titlWidth - 20;
                size = 10.5F;
            }
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].CellAppearance.BackColor = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].CellAppearance.BackColor2 = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].CellAppearance.BackColor = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].CellAppearance.BackColor2 = this.uGrid_StockResult.DisplayLayout.Override.RowAppearance.BorderColor;

            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.FontData.SizeInPoints = size;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].Width = titlWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.ReturnedGoodsPriceColumn.ColumnName].Width = discWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.DiscountPriceColumn.ColumnName].Width = discWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].Width = defoWidth + rateWidth;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].Width = defoWidth + rateWidth + defoWidth + defoWidth;


            // ��\�����
            if (this.tComboEditor_TotalDiv.SelectedIndex == 1)
            {
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.TitleColumn.ColumnName].Hidden = false;
            }
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.RowTitleColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.SalesMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.ReturnedGoodsPriceColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.DiscountPriceColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.GenuineSalesMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy01Column.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.GrossProfitMoneyColumn.ColumnName].Hidden = false;
            this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[this._dataSet.StockResult.Dummy02Column.ColumnName].Hidden = false;

            // �Z���̌���
            List<string> mergedColumnListStockTitle = new List<string>();
            mergedColumnListStockTitle.Add(this._dataSet.StockResult.TitleColumn.ColumnName);

            foreach (string key in mergedColumnListStockTitle)
            {
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                this.uGrid_StockResult.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText;

            }
        }
        #endregion
    }
}