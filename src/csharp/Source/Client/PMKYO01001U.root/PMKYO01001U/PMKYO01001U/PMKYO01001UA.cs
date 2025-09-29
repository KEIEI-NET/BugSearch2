//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/04/22  �C�����e : �݌Ɍn�f�[�^�̏����ƏW�v�@�Ή��̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/28  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/19  �C�����e : Redmine #23807,#23817�\�[�X���r���[���ʂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/19  �C�����e : Redmine #23808�\�[�X���r���[���ʂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/25  �C�����e : Redmine #23980���M���ʌ����s���ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X��
// �C �� ��  2011/09/05  �C�����e : Redmine #23936����M�֘A�̋��_�K�C�h�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/14  �C�����e : #24542 ���_�I���ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : yangmj
// �C �� ��  2011/10/10  �C�����e : #25776 ���M�拒�_���͂Ɏ����_�R�[�h���w��\�̕ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : dingjx
// �C �� ��  2011/11/01  �C�����e : #26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : xupz
// �C �� ��  2011/11/01  �C�����e : #26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : xupz
// �C �� ��  2011/11/10  �C�����e : #26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : xupz
// �C �� ��  2011/11/11  �C�����e : #26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : zhlj
// �C �� ��  2013/02/07  �C�����e : 10900690-00 2013/3/13�z�M���ً̋}�Ή�
//                                  Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : 杍^
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �f�[�^���M����
    /// </summary>
    /// <remarks>
    /// Note       : �f�[�^���M�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.02<br />
    /// Update Note: 2020/09/25 杍^<br />
    /// �Ǘ��ԍ�   : 11600006-00<br />
    ///            : PMKOBETSU-3877�̑Ή�<br />
    /// </remarks>
    public partial class PMKYO01001UA : Form
    {
        #region �� Const Memebers ��
        private const string ct_ClassID = "PMKYO01001UA";
        private const string ERROR_BATU = "�~";
        private const string UI_XML_NAME = "PMKYO01001UA_SectionSetting.xml";//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
        #endregion �� Const Memebers ��

        # region �� private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _getButton;//ADD 2013/02/07 zhlj For Redmine#34588
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // �X�V���ʃf�[�^�e�[�u��
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // ���o�����f�[�^�e�[�u��
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        private UpdateCountInputAcs _updateCountInputAcs;
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private DateTime _startTime = new DateTime();
        private string _baseCode = string.Empty;
        /// <summary>�f�t�H���g�s�̊O�ϐݒ�</summary>
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();
        /// <summary>�I�����̍s�O�ϐݒ�</summary>
        private readonly Color _selBackColor = Color.FromArgb(251, 230, 148);
        private readonly Color _selBackColor2 = Color.FromArgb(238, 149, 21);
        private int _connectPointDiv = 0;
        // ADD 2009/05/20 --->>>
        private Control _prevControl = null;
        private DateTime _preDataTime = DateTime.MinValue;
        // ADD 2009/05/20 ---<<<
        private ArrayList _sendDataList = null;

		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        /// <summary>���_</summary>
        private SecInfoSetAcs _secInfoSetAcs;
		private string _preSectionCode;
		private ArrayList sendDestSecList = new ArrayList();
		private ArrayList _searchSecMngList = null;
		private const string ALL_SECTIONCODE = "00"; 
		private ArrayList _allConditionDataList =new ArrayList();
		private ArrayList selectSendInfoList = new ArrayList();
		private ExtractionConditionDataSet.ExtractionConditionDataTable _allConditionDataTable;
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		private ArrayList _compareSecmngList = new ArrayList();
		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        private DataSet _uiDataSet;//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
        private string _initSecCode = "00";//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
        private DateGetAcs _dateGetAcs; // ADD 2011/11/11 xupz
        private const string MESSAGE_InvalidDate = "�L���ȓ��t�ł͂���܂���B"; // ADD 2011/11/11 xupz
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// <summary>���o���ʂ��邩�ǂ����敪</summary>
        private bool _isEmpty = true;
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
        # endregion �� private field ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKYO01001UA()
        {
	        InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Update"];
            this._getButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Get"];//ADD 2013/02/07 zhlj For Redmine#34588
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._updateCountInputAcs = UpdateCountInputAcs.GetInstance();
            this._updateResultDataTable = this._updateCountInputAcs.UpdateResultDataTable;
            this._extractionConditionDataTable = this._updateCountInputAcs.ExtractionConditionDataTable;

			this._secInfoSetAcs = new SecInfoSetAcs();//ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j
            // ----- ADD 2011/11/11 xupz---------->>>>>
            this._dateGetAcs = DateGetAcs.GetInstance();
            this.tDateEditSt.SetDateTime(System.DateTime.Now);
            this.tDateEditEd.SetDateTime(System.DateTime.Now);
            // ----- ADD 2011/11/11 xupz----------<<<<<
        }
        # endregion �� �R���X�g���N�^ ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._getButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;//ADD 2013/02/07 zhlj For Redmine#34588
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			this.uButton_SectionGuide.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];//ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j

        }
        # endregion �� �{�^�������ݒ菈�� ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.03.26</br>
        /// <br>Update      : dingjx</br>
        /// <br>Note        : Redmine #26228</br>
        /// </remarks>
        private void PMKYO01001UA_Load(object sender, EventArgs e)
        {
            _initSecCode = GetSection();//ADD 2011/09/14 sundx #24542
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			// ���M�揉��������
			GuidInitProc();
			this.timer_InitialSetFocus.Enabled = true;
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            this.Acc_Grid.DataSource = this._updateResultDataTable;
            this.Condition_Grid.DataSource = this._extractionConditionDataTable;

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            if (0 != this.Condition_Grid.Rows.Count) 
			{
				//this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];// DEL 2011/07/25
				this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];// ADD 2011/07/25
            }
            InitSecCode();//ADD 2011/09/14 sundx #24542

            //  ADD dingjx  2011/11/01  --------------------------->>>>>>
            //���o�����敪
            this.tce_ExtractCondDiv.SelectedIndex = Convert.ToInt32(this.GetExtractCondDiv());
            this.ChangeConditionGrid();
            //  ADD dingjx  2011/11/01  ---------------------------<<<<<<
        }
        # endregion �� �t�H�[�����[�h ��

        # region �� ��ʐݒ�t�@�C������ ADD sundx #24542 ���_�I���ɂ��� ��
        /// <summary>
        /// �O���I���̋��_�R�[�h���擾
        /// </summary>
        /// <returns>���_�R�[�h</returns>
        public string GetSection()
        {
            string secCode = string.Empty;
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }

                    _uiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    //secCode = _uiDataSet.Tables[0].Rows[0][0].ToString(); //  DEL dingjx  2011/11/01
                    secCode = _uiDataSet.Tables["Section"].Rows[0][0].ToString(); //  ADD dingjx  2011/11/01
                }
            }
            catch { }
            return secCode;
        }
        /// <summary>
        /// �I���������_�R�[�h��XML�t�@�C���ɕۑ�
        /// </summary>
        /// <param name="secCode">���_�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SetSecCode(string secCode)
        {
            int status = 0;
            try
            {
                if (!string.IsNullOrEmpty(secCode))
                {
                    string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);
                    fileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName);
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }
                    //if (_uiDataSet.Tables.Count == 0) //  DEL dingjx  2011/11/01
                    if (_uiDataSet.Tables["Section"] == null)   //  ADD dingjx  2011/11/01
                    {
                        DataTable dt = new DataTable("Section");
                        DataColumn col = new DataColumn("SecCode", typeof(string));
                        dt.Columns.Add(col);
                        _uiDataSet.Tables.Add(dt);
                    }
                    //  DEL dingjx  2011/11/01  ------------------>>>>>>
                    //_uiDataSet.Tables[0].Clear();
                    //DataRow row = _uiDataSet.Tables[0].NewRow();
                    //row[0] = secCode;
                    //_uiDataSet.Tables[0].Rows.Add(row);
                    //  DEL dingjx  2011/11/01  ------------------<<<<<<
                    //  ADD dingjx  2011/11/01  ------------------>>>>>>
                    _uiDataSet.Tables["Section"].Clear();
                    DataRow row = _uiDataSet.Tables["Section"].NewRow();
                    row[0] = secCode;
                    _uiDataSet.Tables["Section"].Rows.Add(row);
                    //  ADD dingjx  2011/11/01  ------------------>>>>>>
                    _uiDataSet.WriteXml(fileName);
                }
            }
            catch
            {
                status = 1000;
            }
            return status;
        }
        private void InitSecCode()
        {
            try
            {
                string secCode = GetSection();
                if (string.IsNullOrEmpty(secCode) || "".Equals(secCode.Trim()))
                {
                    return;
                }
                if (string.Empty.Equals(GetSectionName(secCode.Trim())))
                {
                    this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode;
                }
                else
                {
                    this.tEdit_SectionCodeAllowZero.Text = secCode.Trim();
                    this.uLabel_SectionNm.Text = GetSectionName(secCode.Trim());
                    this._preSectionCode = secCode.Trim();
                    ResetGridCol();
                }

            }
            finally
            { }
        }
        # endregion �� ��ʐݒ�t�@�C������ ��

        # region �� �O���b�h�����ݒ�֘A ��
        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �O���b�h�����ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
		private void InitialAccSettingGridCol(ArrayList sendDtList)
        {
            this.Acc_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Acc_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //�uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._updateResultDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.Acc_Grid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // Filter�ݒ�
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;


            // �\�����ݒ�
			//this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 15;//DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 30;//ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Width = 300;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Width = 100;


            // �Œ��ݒ�
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Header.Fixed = false;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Header.Fixed = false;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Header.Fixed = false;

            // CellAppearance�ݒ�
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // ���͋��ݒ�
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

			// Style�ݒ�
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			//Hidden��ݒ�
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Hidden = true;
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �O���b�h�����ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialConSettingGridCol()
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Condition_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //�uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._extractionConditionDataTable.BaseCodeColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // Filter�ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

			// �\�����ݒ�
			# region [DEL 2011/07/28]
			//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 130;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 60;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 50;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 60;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 50;
			//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
			# endregion
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Width = 40;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].Width = 50;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].Width = 200;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 200;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 120;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
			
            // �Œ��ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.Fixed = false;

            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
           
			// CellAppearance�ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // ���͋��ݒ�

			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;  //ADD 2011/07/28
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // Style�ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			//Hidden��ݒ�
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Hidden = true;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].Hidden = true;
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
		}

        /// <summary>
        /// �O���b�h�����ݒ�̐ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �O���b�h�����ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialConDataGridCol()
        {
            this.LoadBaseData();

			_allConditionDataTable = new ExtractionConditionDataSet.ExtractionConditionDataTable();
			for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
			{
				ExtractionConditionDataSet.ExtractionConditionRow newRow = _allConditionDataTable.NewExtractionConditionRow();
				ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
				newRow.SendDestCond = row.SendDestCond;
				newRow.SendCode = row.SendCode;
				newRow.SendName = row.SendName;
				newRow.BaseCode = row.BaseCode;
				newRow.BaseName = row.BaseName;
				newRow.BeginningDate = row.BeginningDate;
				newRow.BeginningTime = row.BeginningTime;
				newRow.EndDate = row.EndDate;
				newRow.EndTime = row.EndTime;
				_allConditionDataTable.Rows.Add(newRow);
			}

		}

        /// <summary>
        /// ��ʏ����̐ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��ʏ����̐ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void LoadBaseData()
        {
            if (!_updateCountInputAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }
			ArrayList secMngSetWorkList = new ArrayList();
			_startTime = _updateCountInputAcs.LoadProc(_enterpriseCode, out _baseCode, out secMngSetWorkList);
			_compareSecmngList = secMngSetWorkList; // ADD 2011.08.25
        }

        /// <summary>
        /// �X�V���Ԃ̐ݒ�
        /// </summary>
		/// <param name="baseCd"></param>
		/// <param name="sendCd"></param>
        /// <remarks>		
        /// <br>Note		: �X�V���ԏ������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
		//private bool UpdateOverData()
		private bool UpdateOverData(string baseCd, string sendCd)
        {
            bool isUpdate = true;
            DateTime startTimeBak = new DateTime(); 
			//isUpdate = _updateCountInputAcs.UpdateOverProc(_enterpriseCode, _baseCode, out startTimeBak);
			isUpdate = _updateCountInputAcs.UpdateOverProc(_enterpriseCode, baseCd, sendCd, out startTimeBak);
            if (isUpdate) 
            {
                _startTime = startTimeBak;
            } 
            else
            {
                isUpdate = false;
            }
            return isUpdate;
        }
        /// <summary>
        /// �O���b�h��X�^�C���ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �O���b�h��X�^�C���ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialAccDataGridCol()
        {
            // ���M�Ώۃf�[�^���O���b�h�֐ݒ肷��
            for (int i = 0; i < this._sendDataList.Count; i++)
			{
				# region [DEL 2011/07/28]
				//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				//SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
				//UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
				//row.RowNo = i + 1;
				//row.ExtractionData = secMngSndRcv.MasterName;
				//row.ExtractionCount = string.Empty;
				//_updateResultDataTable.Rows.Add(row);
				//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
				# endregion

				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				//���M�拒�_���X�g���쐬����
				if (ALL_SECTIONCODE.Equals(this.tEdit_SectionCodeAllowZero.DataText))
				{
					this.sendDestSecList = _searchSecMngList;
				}
				else if (string.Empty.Equals(this.tEdit_SectionCodeAllowZero.DataText))
				{
					this.sendDestSecList = new ArrayList();
				}
				else
				{
					this.sendDestSecList = new ArrayList();
					foreach (SecMngSet secMngSet0 in _searchSecMngList)
					{
						if (secMngSet0.SendDestSecCode.Trim().Equals(this.tEdit_SectionCodeAllowZero.DataText)
							&& secMngSet0.LogicalDeleteCode == 0
							&& secMngSet0.Kind == 0)
						{
							this.sendDestSecList.Add(secMngSet0);
						}
					}
				}
				//���_�Ǘ��ݒ�}�X�^�ɓo�^�������M�拒�_�𑗐M���O���b�h�ɒǉ�
				int colCnt = _updateResultDataTable.Columns.Count;
				for (int j = colCnt - 1; j > this.Acc_Grid.DisplayLayout.Bands[0].Columns[_updateResultDataTable.ExtractionCountColumn.ColumnName].Index; j--)
				{
					_updateResultDataTable.Columns.RemoveAt(j);
				}

				foreach (SecMngSet secMngSet2 in sendDestSecList)
				{
					if (!_updateResultDataTable.Columns.Contains(secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim() ))
					{
						_updateResultDataTable.Columns.Add(secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim());
						this.Acc_Grid.DisplayLayout.Bands[0].Columns[secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim()].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
						//_updateResultDataTable.Columns[ secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim()].Caption = GetSectionName(secMngSet2.SendDestSecCode.Trim());
						_updateResultDataTable.Columns[secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim()].Caption = GetSectionName(secMngSet2.SendDestSecCode.Trim()) + "(" + GetSectionName(secMngSet2.SectionCode.Trim())+")";
					}
				}

				SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
				UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
				row.RowNo = i + 1;
				row.ExtractionData = secMngSndRcv.MasterName;
				row.ExtractionCount = string.Empty;

				foreach (SecMngSet secMngSet3 in sendDestSecList)
				{
					row[secMngSet3.SectionCode.Trim() + secMngSet3.SendDestSecCode.Trim()] = string.Empty;
				}

				_updateResultDataTable.Rows.Add(row);
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
        }

        /// <summary>
        /// ���M���O���b�h�����ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ���M���O���b�h�����ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Acc_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // ���M���̎擾
            this._updateCountInputAcs.GetSecMngSendData(this._enterpriseCode, out this._sendDataList);

			string secCd = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2,'0');
			ArrayList sendDtList = new ArrayList();
			if (!secCd.Equals("00") && _searchSecMngList.Count > 0)
			{
				foreach (SecMngSet tmpSecMngSet in _searchSecMngList)
				{
					if (tmpSecMngSet.SendDestSecCode.Equals(secCd))
					{
						sendDtList.Add(tmpSecMngSet);
					}

				}
			}
			else
			{
				sendDtList = _searchSecMngList;
			}

			this.InitialAccSettingGridCol(sendDtList);
            this.InitialAccDataGridCol();
        }

        /// <summary>
        /// �����O���b�h�����ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �����O���b�h�����ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Condition_Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.InitialConSettingGridCol();
            // �[���I����@�ݒ�
            e.Layout.Override.SelectTypeCell = SelectType.SingleAutoDrag;
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
            e.Layout.Override.SelectTypeCol = SelectType.SingleAutoDrag;
            this.InitialConDataGridCol();
        }

        # endregion �� �O���b�h�����ݒ�֘A ��

        #region  �� �f�[�^���o���M���� ��
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// <summary>
        /// �f�[�^���o���M����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �f�[�^���o���M�������s���B</br>
        /// <br>            : 10900690-00 2013/3/13�z�M���ً̋}�Ή�</br>
        /// <br>            : Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// <br>Update Note : 2020/09/25 杍^</br>
        /// <br>�Ǘ��ԍ�    : 11600006-00</br>
        /// <br>            : PMKOBETSU-3877�̑Ή�</br>
        /// </remarks>
        private void GetProcess()
        {
            // ���o����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

            // �\��������ݒ�
            form.Title = "���o������";
            form.Message = "���o�������ł�";

			int errStatus = 0;
			this.Cursor = Cursors.WaitCursor;
			// �_�C�A���O�\��
            ToolbarOff();
			form.Show();
			Dictionary<string, SearchCountWork> searchCntDic = new Dictionary<string, SearchCountWork>();
			String beginningDate;
			String beginningTime;
			String endingDate;
			String endingTime;
			String baseCode;
			String sendCode;
			DateTime beginDateTime;
			DateTime endDateTime;

			bool isEmpty = true;
			ArrayList errSectionCodeList = new ArrayList();
			ArrayList sendDestEpCodeList = new ArrayList();
			EnterpriseSetAcs _enterpriseSetAcs = new EnterpriseSetAcs();

            // ���M���_�ꗗ���擾����
			_enterpriseSetAcs.SearchAll(out sendDestEpCodeList, this._enterpriseCode);

            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //�`�F�b�N�I�����ꂽ���M�������R�[�h�̓`�F�b�N���s���B
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
                {
                    beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString();
                    beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString();
                    DateTime tmpStDate = (DateTime)this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value;

                    endingDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString();
                    endingTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString();
                    DateTime tmpEdDate = (DateTime)this.Condition_Grid.Rows[i].Cells["EndDate"].Value;

                    baseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();
                    sendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();

                    _startTime = DateTime.MinValue;
                    for (int n = 0; n < _compareSecmngList.Count; n++)
                    {
                        APSecMngSetWork secMngSetWork = (APSecMngSetWork)_compareSecmngList[n];
                        if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
                        && sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
                        {
                            _startTime = secMngSetWork.SyncExecDate;
                        }
                    }

                    // �J�n���t
                    beginDateTime = new DateTime(tmpStDate.Year, tmpStDate.Month, tmpStDate.Day, int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                        int.Parse(beginningTime.Substring(6, 2)));

                    // �I�����t
                    endDateTime = new DateTime(tmpEdDate.Year, tmpEdDate.Month, tmpEdDate.Day, int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                        int.Parse(endingTime.Substring(6, 2)));

                    if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
                        && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second)
                    {
                        beginDateTime = _startTime;
                    }

                    long beginDtLong = 0;
                    long endDtLong = 0;
                    if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                    {
                        beginDtLong = beginDateTime.Ticks;
                        endDtLong = endDateTime.Ticks;
                    }
                    else if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                    {
                        beginDtLong = Convert.ToInt32(this.tDateEditSt.GetDateTime().ToString("yyyyMMdd"));
                        endDtLong = Convert.ToInt32(this.tDateEditEd.GetDateTime().ToString("yyyyMMdd"));
                    }
                    bool b_Empty = true;
                    baseCode = baseCode.Trim();
                    sendCode = sendCode.Trim();
                    // �t�@�C��ID�z��
                    string[] fileIds = new string[this._sendDataList.Count];
                    string[] fileNms = new string[this._sendDataList.Count];
                    // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                    int acptAnOdrSendDiv = 0;
                    int shipmentSendDiv = 0;
                    int estimateSendDiv = 0;
                    // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                    for (int j = 0; j < this._sendDataList.Count; j++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                        fileIds[j] = secMngSndRcv.FileId;
                        fileNms[j] = secMngSndRcv.FileNm;
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                        if (secMngSndRcv.FileNm.Equals("����f�[�^"))
                        {
                            //�󒍃f�[�^���M�敪
                            acptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                            //�ݏo�f�[�^���M�敪
                            shipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                            //���σf�[�^���M�敪
                            estimateSendDiv = secMngSndRcv.EstimateSendDiv;
                        }
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                    }

                    // ���M�f�[�^�̌��ʌ������[�N
                    SearchCountWork searchCountWork = new SearchCountWork();
                    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
                    {
                        //�`�F�b�N����Ȃ����M�拒�_�֑��M���Ȃ�
                        continue;
                    }

                    // ���o�Ώۃf�[�^���ʌ������擾����
                    searchCountWork = _updateCountInputAcs.SearchDataProc(
                        this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong,
                        _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode,
                        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                        //baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList);
                        baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList, acptAnOdrSendDiv, shipmentSendDiv, estimateSendDiv);
                    // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                     
                    this.Cursor = Cursors.Default;

                    // ��������̏ꍇ
                    if (searchCountWork.Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                    }
                }
            }

            // �_�C�A���O�����
            form.Close();
            ToolbarOn();
            // ���M���e�[�u���N���A����
            this._updateResultDataTable.Clear();
            this._isEmpty = true;
            // ���M���e�[�u���ݒ菈��(0:���M�O)
            this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 0);
            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            if (this._isEmpty)
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);
                // ���M���e�[�u���N���A����
                this._updateResultDataTable.Clear();
                // ���M���e�[�u���ݒ菈��
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
                return;
            }

            // ���M�����m�F���
            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "���M�������J�n���܂����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            // �u�͂��v�̏ꍇ
            if (dialogResult == DialogResult.Yes)
            {
                searchCntDic.Clear();
                // �\��������ݒ�
                form.Title = "���M������";
                form.Message = "���M�������ł�";
                this.Cursor = Cursors.WaitCursor;
                // �_�C�A���O�\��
                this.Update();
                ToolbarOff();
                form.Show();

			    for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
			    {
				    //�`�F�b�N�I�����ꂽ���M�������R�[�h�̓`�F�b�N���s���B
				    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
				    {

					    beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString();
					    beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString();
					    DateTime tmpStDate = (DateTime)this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value;

					    endingDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString();
					    endingTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString();
					    DateTime tmpEdDate = (DateTime)this.Condition_Grid.Rows[i].Cells["EndDate"].Value;


					    baseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();
					    sendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();

					    _startTime = DateTime.MinValue;
					    for (int n = 0; n < _compareSecmngList.Count; n++)
					    {
						    APSecMngSetWork secMngSetWork = (APSecMngSetWork)_compareSecmngList[n];
						    if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
						    && sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
						    {
							    _startTime = secMngSetWork.SyncExecDate;
						    }
					    }

					    // �J�n���t
					    beginDateTime = new DateTime(tmpStDate.Year, tmpStDate.Month,tmpStDate.Day, int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
						    int.Parse(beginningTime.Substring(6, 2)));

					    // �I�����t
					    endDateTime = new DateTime(tmpEdDate.Year, tmpEdDate.Month, tmpEdDate.Day, int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
						    int.Parse(endingTime.Substring(6, 2)));

					    if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
						    && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second)
					    {
						    beginDateTime = _startTime;
					    }

                        long beginDtLong = 0;
                        long endDtLong = 0;
                        if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                        {
                            beginDtLong = beginDateTime.Ticks;
                            endDtLong = endDateTime.Ticks;
                        }
                        else if(this.tce_ExtractCondDiv.SelectedIndex == 1)
                        {
                            beginDtLong = Convert.ToInt32(this.tDateEditSt.GetDateTime().ToString("yyyyMMdd"));
                            endDtLong = Convert.ToInt32(this.tDateEditEd.GetDateTime().ToString("yyyyMMdd"));
                        }

					    bool b_Empty = true;
					    baseCode = baseCode.Trim();
					    sendCode = sendCode.Trim();
					    // �t�@�C��ID�z��
					    string[] fileIds = new string[this._sendDataList.Count];
					    string[] fileNms = new string[this._sendDataList.Count];
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                        int acptAnOdrSendDiv = 0;
                        int shipmentSendDiv = 0;
                        int estimateSendDiv = 0;
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
					    for (int j = 0; j < this._sendDataList.Count; j++)
					    {
						    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
						    fileIds[j] = secMngSndRcv.FileId;
						    fileNms[j] = secMngSndRcv.FileNm;
                            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                            if (secMngSndRcv.FileNm.Equals("����f�[�^"))
                            {
                                //�󒍃f�[�^���M�敪
                                acptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                                //�ݏo�f�[�^���M�敪
                                shipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                                //���σf�[�^���M�敪
                                estimateSendDiv = secMngSndRcv.EstimateSendDiv;
                            }
                            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
					    }
					    
					    SearchCountWork searchCountWork = new SearchCountWork();
					    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
					    {
						    //�`�F�b�N����Ȃ����M�拒�_�֑��M���Ȃ�
						    continue;
					    }
                        // �f�[�^���M����
                        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                        //searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList); 
                        searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList, acptAnOdrSendDiv, shipmentSendDiv, estimateSendDiv);
                        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
					    // ����0���ȊO�̏ꍇ
					    if (!b_Empty)
					    {
						    isEmpty = false;
					    }

					    if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != searchCountWork.Status)
					    {
						    errStatus = searchCountWork.Status;
						    errSectionCodeList.Add(baseCode + sendCode.Trim());
					    }
					    else
					    {

						    if (!b_Empty)
						    {
							    searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
						    }
						    else
						    {
							    searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
						    }
					    }
				    }
			    }
            }
            // �u�������v�̏ꍇ
            else
            {
                // ���M���e�[�u���N���A����
                this._updateResultDataTable.Clear();
                // ���M���e�[�u���ݒ菈��(2:�����M)
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 2);
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                return;
            }
			
			this.Cursor = Cursors.Default;
            // �_�C�A���O�����
            form.Close();
            ToolbarOn();

			// �X�V���ʍĐݒ�
            // ���M�f�[�^0���̏ꍇ
			if (isEmpty)
			{
				// ���M���e�[�u���N���A����
				this._updateResultDataTable.Clear();
                // ���M���e�[�u���ݒ菈��
				this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
				this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

				// ���M�����e�[�u���N���A
				this._extractionConditionDataTable.Clear();
                // �X�V������ő��M�����^�u���Đݒ肷��
				this.SearchCondtionGridCol();

				// ���b�Z�[�W��\��
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);
			}
			else
			{

				// ���M���e�[�u���N���A����
				this._updateResultDataTable.Clear();
                // ���M���e�[�u���ݒ菈��(1:���M����)
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 1);
				this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

				// ���M�����e�[�u���N���A
				this._extractionConditionDataTable.Clear();
                // �X�V������ő��M�����^�u���Đݒ肷��
				this.SearchCondtionGridCol();

				if (0 == errStatus)
				{
					// �X�V����̏ꍇ
                    // ���M�������b�Z�[�W
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                         ct_ClassID,
                                         "���M�������������܂����B",
                                         0,
                                         MessageBoxButtons.OK);
				}
				else if (-1 == errStatus)
				{
					// �����G���[�̏ꍇ�A 
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "���������Ɏ��s���܂����B", errStatus);
				}
				else if (-2 == errStatus)
				{
					// AP���b�N�̃^�C���A�E�g�̏ꍇ
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B", 0);
				}
				else if (-3 == errStatus)
				{
					// DB��SQL�G���[�̏ꍇ�A
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "SQL�G���[���������܂����B", errStatus);
				}
				else if (5 == errStatus)
				{
					// ��Ӑ���G���[�̏ꍇ�A
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�X�V�����Ɏ��s���܂����B", errStatus);
				}
				else
				{
					// �V�X�e���Ƃ��̑��G���[�̏ꍇ�A
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�r�������Ɏ��s���܂����B", (int)ConstantManagement.DB_Status.ctDB_ERROR);
				}
			}

            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                this.ChangeConditionGrid();
            }
		}
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        /// <summary>
        /// �f�[�^���M����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �f�[�^���M�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// <br>Update Note : 2020/09/25 杍^</br>
        /// <br>�Ǘ��ԍ�    : 11600006-00</br>
        /// <br>            : PMKOBETSU-3877�̑Ή�</br>
        /// </remarks>
        private void UpdateProcess()
        {
            // ADD 2009/05/20 --->>>
            // ���o����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���M������";
            form.Message = "���M�������ł�";
            // ADD 2009/05/20 ---<<<

            # region [DEL 2011/07/28]
            //-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //String beginningDate = this.Condition_Grid.Rows[0].Cells["BeginningDate"].Value.ToString();
            //String beginningTime = this.Condition_Grid.Rows[0].Cells["BeginningTime"].Value.ToString();

            //String endingDate = this.Condition_Grid.Rows[0].Cells["EndDate"].Value.ToString();
            //String endingTime = this.Condition_Grid.Rows[0].Cells["EndTime"].Value.ToString();

            //String baseCode = this.Condition_Grid.Rows[0].Cells["BaseCode"].Value.ToString();
            //// �J�n���t
            //DateTime beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
            //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
            //    int.Parse(beginningTime.Substring(6, 2)));
            //// �I�����t
            //DateTime endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
            //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
            //    int.Parse(endingTime.Substring(6, 2)));

            //if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
            //    && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second) 
            //{
            //    beginDateTime = _startTime;
            //}

            //long beginDtLong = beginDateTime.Ticks;
            //long endDtLong = endDateTime.Ticks;
            //bool isEmpty = false;
            //baseCode = baseCode.Trim();

            //this.Cursor = Cursors.WaitCursor;

            //// �_�C�A���O�\��
            //form.Show();    // ADD 2009/05/20

            //// �t�@�C��ID�z��
            //string[] fileIds = new string[this._sendDataList.Count];
            //// ADD 2009/06/23 ---->>>
            //string[] fileNms = new string[this._sendDataList.Count];
            //// ADD 2009/06/23 ----<<<
            //for (int i = 0; i < this._sendDataList.Count; i++)
            //{
            //    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
            //    fileIds[i] = secMngSndRcv.FileId;
            //    // ADD 2009/06/23 ---->>>
            //    fileNms[i] = secMngSndRcv.FileNm;
            //    // ADD 2009/06/23 ----<<<
            //}
            //// �f�[�^���M����
            //// MOD 2009/06/23 ---->>>
            ////SearchCountWork searchCountWork = _updateCountInputAcs.UpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginEmplooyCode, baseCode, out isEmpty, this._connectPointDiv, fileIds);
            //SearchCountWork searchCountWork = _updateCountInputAcs.UpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginEmplooyCode, baseCode, out isEmpty, this._connectPointDiv, fileIds, fileNms);
            //// MOD 2009/06/23 ----<<<
            //-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            # endregion

            //-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            int errStatus = 0;
            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            ToolbarOff();//ADD 2013/02/07 zhlj For Redmine#34588
            form.Show();
            Dictionary<string, SearchCountWork> searchCntDic = new Dictionary<string, SearchCountWork>();
            String beginningDate;
            String beginningTime;
            String endingDate;
            String endingTime;
            String baseCode;
            String sendCode;
            DateTime beginDateTime;
            DateTime endDateTime;
            //bool isEmpty = false;
            bool isEmpty = true;
            ArrayList errSectionCodeList = new ArrayList();

            ArrayList sendDestEpCodeList = new ArrayList();
            EnterpriseSetAcs _enterpriseSetAcs = new EnterpriseSetAcs();
            _enterpriseSetAcs.SearchAll(out sendDestEpCodeList, this._enterpriseCode);

            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //�`�F�b�N�I�����ꂽ���M�������R�[�h�̓`�F�b�N���s���B
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
                {

                    beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString();
                    beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString();
                    DateTime tmpStDate = (DateTime)this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value;// ADD 2011.08.19

                    endingDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString();
                    endingTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString();
                    DateTime tmpEdDate = (DateTime)this.Condition_Grid.Rows[i].Cells["EndDate"].Value;// ADD 2011.08.19


                    baseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();
                    sendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();

                    // ADD 2011.08.25---------->>>>>
                    _startTime = DateTime.MinValue;
                    for (int n = 0; n < _compareSecmngList.Count; n++)
                    {
                        APSecMngSetWork secMngSetWork = (APSecMngSetWork)_compareSecmngList[n];
                        if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
                        && sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
                        {
                            _startTime = secMngSetWork.SyncExecDate;
                        }
                    }
                    // ADD 2011.08.25----------<<<<<

                    // �J�n���t
                    // DEL 2011.08.19
                    //beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
                    //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                    //    int.Parse(beginningTime.Substring(6, 2)));
                    // ADD 2011.08.19
                    beginDateTime = new DateTime(tmpStDate.Year, tmpStDate.Month, tmpStDate.Day, int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                        int.Parse(beginningTime.Substring(6, 2)));

                    // �I�����t
                    // DEL 2011.08.19
                    //endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
                    //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                    //    int.Parse(endingTime.Substring(6, 2)));
                    // ADD 2011.08.19
                    endDateTime = new DateTime(tmpEdDate.Year, tmpEdDate.Month, tmpEdDate.Day, int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                        int.Parse(endingTime.Substring(6, 2)));

                    if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
                        && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second)
                    {
                        beginDateTime = _startTime;
                    }

                    // ----- DEL xupz 2011/11/01 ---------->>>>>
                    //long beginDtLong = beginDateTime.Ticks;
                    //long endDtLong = endDateTime.Ticks;
                    // ----- DEL xupz 2011/11/01 ----------<<<<<
                    // ----- ADD xupz 2011/11/01 ---------->>>>>
                    long beginDtLong = 0;
                    long endDtLong = 0;
                    if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                    {
                        beginDtLong = beginDateTime.Ticks;
                        endDtLong = endDateTime.Ticks;
                    }
                    else if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                    {
                        // ----- DEL 2011/11/11 xupz---------->>>>>
                        //beginDtLong = Convert.ToInt32(beginDateTime.ToString("yyyyMMdd"));
                        //endDtLong = Convert.ToInt32(endDateTime.ToString("yyyyMMdd"));
                        // ----- DEL 2011/11/11 xupz----------<<<<<
                        // ----- ADD 2011/11/11 xupz---------->>>>>
                        beginDtLong = Convert.ToInt32(this.tDateEditSt.GetDateTime().ToString("yyyyMMdd"));
                        endDtLong = Convert.ToInt32(this.tDateEditEd.GetDateTime().ToString("yyyyMMdd"));
                        // ----- ADD 2011/11/11 xupz----------<<<<<
                    }
                    // ----- ADD xupz 2011/11/01 ----------<<<<<
                    bool b_Empty = true;
                    baseCode = baseCode.Trim();
                    sendCode = sendCode.Trim();
                    // �t�@�C��ID�z��
                    string[] fileIds = new string[this._sendDataList.Count];
                    string[] fileNms = new string[this._sendDataList.Count];
                    // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                    int acptAnOdrSendDiv = 0;
                    int shipmentSendDiv = 0;
                    int estimateSendDiv = 0;
                    // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                    for (int j = 0; j < this._sendDataList.Count; j++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                        fileIds[j] = secMngSndRcv.FileId;
                        fileNms[j] = secMngSndRcv.FileNm;
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                        if (secMngSndRcv.FileNm.Equals("����f�[�^"))
                        {
                            //�󒍃f�[�^���M�敪
                            acptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                            //�ݏo�f�[�^���M�敪
                            shipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                            //���σf�[�^���M�敪
                            estimateSendDiv = secMngSndRcv.EstimateSendDiv;
                        }
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                    }
                    // �f�[�^���M����
                    SearchCountWork searchCountWork = new SearchCountWork();
                    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
                    {
                        //�`�F�b�N����Ȃ����M�拒�_�֑��M���Ȃ�
                        //searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                        continue;
                    }
                    //searchCountWork = _updateCountInputAcs.UpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList);   //  DEL dingjx  2011/11/01
                    // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                    //searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList); //  ADD dingjx  2011/11/01
                    searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList, acptAnOdrSendDiv, shipmentSendDiv, estimateSendDiv);
                    // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                    // ����0���ȊO�̏ꍇ�A
                    if (!b_Empty)
                    {
                        isEmpty = false;
                    }

                    // ADD 2011.09.05 ------>>>>>
                    if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != searchCountWork.Status)
                    {
                        errStatus = searchCountWork.Status;
                        errSectionCodeList.Add(baseCode + sendCode.Trim());
                    }
                    else
                    {
                        // ADD 2011.09.05 ------<<<<<

                        if (!b_Empty)
                        {
                            searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                        }
                        else
                        {
                            searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                        }
                    }
                }
            }

            this.Cursor = Cursors.Default;
            // �_�C�A���O�����
            form.Close();
            ToolbarOn();//ADD 2013/02/07 zhlj For Redmine#34588
            //�X�V���ʍĐݒ�
            if (isEmpty)
            {
                // ���M���e�[�u���N���A����
                this._updateResultDataTable.Clear();
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                //���M�����e�[�u���N���A
                this._extractionConditionDataTable.Clear();
                this.SearchCondtionGridCol();

                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);
            }
            else
            {
                // ���M���e�[�u���N���A����
                this._updateResultDataTable.Clear();
                //this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);//DEL 2013/02/07 zhlj For Redmine#34588
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                // �O���b�h��X�^�C���ݒ菈��(1:���M����)
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 1);
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                //���M�����e�[�u���N���A
                this._extractionConditionDataTable.Clear();
                this.SearchCondtionGridCol();

                // ADD 2011.09.05 �G���[����---------->>>>>
                if (0 == errStatus)
                {
                    // �X�V����̏ꍇ
                    // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                    // ���M�������b�Z�[�W
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                         ct_ClassID,
                                         "���M�������������܂����B",
                                         0,
                                         MessageBoxButtons.OK);
                    // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                }
                else if (-1 == errStatus)
                {
                    // �����G���[�̏ꍇ�A 
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "���������Ɏ��s���܂����B", errStatus);
                }
                else if (-2 == errStatus)
                {
                    // AP���b�N�̃^�C���A�E�g�̏ꍇ
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B", 0);
                }
                else if (-3 == errStatus)
                {
                    // DB��SQL�G���[�̏ꍇ�A
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "SQL�G���[���������܂����B", errStatus);
                }
                else if (5 == errStatus)
                {
                    // ��Ӑ���G���[�̏ꍇ�A
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�X�V�����Ɏ��s���܂����B", errStatus);
                }
                else
                {
                    // �V�X�e���Ƃ��̑��G���[�̏ꍇ�A
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�r�������Ɏ��s���܂����B", (int)ConstantManagement.DB_Status.ctDB_ERROR);
                }
                // ADD 2011.09.05 �G���[����----------<<<<<
            }

            //-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            //  ADD dingjx  2011/11/01  --------------------------------->>>>>>
            // Update records of ConditionGrid
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                this.ChangeConditionGrid();
            }
            //  ADD dingjx  2011/11/01  ---------------------------------<<<<<<

            # region [DEL 2011/07/28]
            //-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //this.Cursor = Cursors.Default;
            //// �_�C�A���O�����
            //form.Close();   // ADD 2009/05/20
            //// ����0���̏ꍇ�A
            //if (isEmpty)
            //{

            //    // ���M���e�[�u���N���A����
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultDataGridCol(searchCountWork);

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //    // ���b�Z�[�W��\��
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);

            //}
            //else
            //{
            //    // �X�V����̏ꍇ�A 
            //    if (0 == searchCountWork.Status)
            //    {
            //        // ���M���e�[�u���N���A����
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultDataGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //    }
            //    // �����G���[�̏ꍇ�A 
            //    else if (-1 == searchCountWork.Status)
            //    {
            //        // ���M���e�[�u���N���A����
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultErrGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //    }
            //    // AP���b�N�̃^�C���A�E�g�̏ꍇ�A
            //    else if (-2 == searchCountWork.Status)
            //    {
            //        // ���M���e�[�u���N���A����
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultErrGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //        // ���b�Z�[�W��\��
            //        this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B", 0);
            //    }
            //    // DB��SQL�G���[�̏ꍇ�A
            //    else if (-3 == searchCountWork.Status)
            //    {
            //        // ���M���e�[�u���N���A����
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultErrGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //    }
            //    // �V�X�e���Ƃ��̑��G���[�̏ꍇ�A
            //    else
            //    {
            //        // ���M���e�[�u���N���A����
            //        this._updateResultDataTable.Clear();

            //        // ���M��񏉊�������
            //        this.InitialAccDataGridCol();

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //        // ���b�Z�[�W��\��
            //        this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�r�������Ɏ��s���܂����B", (int)ConstantManagement.DB_Status.ctDB_ERROR);
            //    }
            //}
            //-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            # endregion
        }

        /// <summary>
        /// ���������t�H�[�}�b�g�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���������t�H�[�}�b�g�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (searchCountLen <= 3)
            {
                searchCountStr = searchCountStr + " ��";
            }
            else if (3 < searchCountLen && searchCountLen <= 6) 
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + " ��";
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + "," 
                    + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                    + searchCountStr.Substring(searchCountLen - 3) + " ��";
            }
            return searchCountStr;
		}

		# region [DEL 2011/07/28]
		//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
		///// <summary>
		///// �O���b�h��X�^�C���ݒ�
		///// </summary>
		///// <remarks>		
		///// <br>Note		: �O���b�h��X�^�C���ݒ菈�����s���B</br>
		///// <br>Programmer	: 杍^</br>	
		///// <br>Date		: 2009.04.02</br>
		///// </remarks>
		//private void SearchResultDataGridCol(SearchCountWork searchCountWork)
		//{
		//    // ���M�Ώۃf�[�^���O���b�h�֐ݒ肷��
		//    for (int i = 0; i < this._sendDataList.Count; i++)
		//    {
		//        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
		//        UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
		//        row.RowNo = i + 1;
		//        row.ExtractionData = secMngSndRcv.MasterName;
		//        switch (secMngSndRcv.FileId)
		//        {
		//            // ����f�[�^
		//            case "SalesSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesSlipCount);
		//                break;
		//            // ���㖾�׃f�[�^
		//            case "SalesDetailRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesDetailCount);
		//                break;
		//            // ���㗚���f�[�^
		//            case "SalesHistoryRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesHistoryCount);
		//                break;
		//            // ���㗚�𖾍׃f�[�^
		//            case "SalesHistDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesHistDtlCount);
		//                break;
		//            // �����f�[�^
		//            case "DepsitMainRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.DepsitMainCount);
		//                break;
		//            // �������׃f�[�^
		//            case "DepsitDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.DepsitDtlCount);
		//                break;
		//            // �d���f�[�^
		//            case "StockSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockSlipCount);
		//                break;
		//            // �d�����׃f�[�^
		//            case "StockDetailRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockDetailCount);
		//                break;
		//            // �d�������f�[�^
		//            case "StockSlipHistRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockSlipHistCount);
		//                break;
		//            // �d�����𖾍׃f�[�^
		//            case "StockSlHistDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockSlHistDtlCount);
		//                break;
		//            // �x���`�[�}�X�^
		//            case "PaymentSlpRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.PaymentSlpCount);
		//                break;
		//            // �x�����׃f�[�^
		//            case "PaymentDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.PaymentDtlCount);
		//                break;
		//            // �󒍃}�X�^
		//            case "AcceptOdrRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.AcceptOdrCount);
		//                break;
		//            // �󒍃}�X�^�i�ԗ��j
		//            case "AcceptOdrCarRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.AcceptOdrCarCount);
		//                break;
		//            // ���㌎���W�v�f�[�^
		//            case "MTtlSalesSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.MTtlSalesSlipCount);
		//                break;
		//            // ���i�ʔ��㌎���W�v�f�[�^
		//            case "GoodsMTtlSaSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
		//                break;
		//            // �d�������W�v�f�[�^
		//            case "MTtlStockSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.MTtlStockSlipCount);
		//                break;
		//            // �݌ɒ����f�[�^
		//            case "StockAdjustRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockAdjustCount);
		//                break;
		//            // �݌ɒ������׃f�[�^
		//            case "StockAdjustDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockAdjustDtlCount);
		//                break;
		//            // �݌Ɉړ��f�[�^
		//            case "StockMoveRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockMoveCount);
		//                break;
		//            // �݌Ɏ󕥗����f�[�^
		//            case "StockAcPayHistRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockAcPayHistCount);
		//                break;
		//        }
		//        _updateResultDataTable.Rows.Add(row);
		//    }
		//}
		//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
		# endregion

		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
		/// <summary>
		/// �O���b�h��X�^�C���ݒ�
		/// </summary>
		/// <remarks>		
		/// <br>Note		: �O���b�h��X�^�C���ݒ菈�����s���B</br>
		/// <br>Programmer	: ����</br>	
		/// <br>Date		: 2011.07.28</br>
		/// </remarks>
		private void SearchResultDataGridCol(Dictionary<string, SearchCountWork> searchCntDic, ArrayList errSectionCodeList)
		{
			UpdateResultDataSet.UpdateResultRow row = null;
			// ���M�Ώۃf�[�^���O���b�h�֐ݒ肷��
			for (int i = 0; i < this._sendDataList.Count; i++)
			{
				SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
				row = _updateResultDataTable.NewUpdateResultRow();
				row.RowNo = i + 1;
				row.ExtractionData = secMngSndRcv.MasterName;
				row.ExtractionCount = string.Empty;
				foreach (string sectionCode in searchCntDic.Keys)
				{
					SearchCountWork searchCountWork = searchCntDic[sectionCode];
					switch (secMngSndRcv.FileId)
					{
						// ����f�[�^
						case "SalesSlipRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesSlipCount);
							break;
						// ���㖾�׃f�[�^
						case "SalesDetailRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesDetailCount);
							break;
						// ���㗚���f�[�^
						case "SalesHistoryRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesHistoryCount);
							break;
						// ���㗚�𖾍׃f�[�^
						case "SalesHistDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesHistDtlCount);
							break;
						// �����f�[�^
						case "DepsitMainRF":
							row[sectionCode] = this.IntConvert(searchCountWork.DepsitMainCount);
							break;
						// �������׃f�[�^
						case "DepsitDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.DepsitDtlCount);
							break;
						// �d���f�[�^
						case "StockSlipRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockSlipCount);
							break;
						// �d�����׃f�[�^
						case "StockDetailRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockDetailCount);
							break;
						// �d�������f�[�^
						case "StockSlipHistRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockSlipHistCount);
							break;
						// �d�����𖾍׃f�[�^
						case "StockSlHistDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockSlHistDtlCount);
							break;
						// �x���`�[�}�X�^
						case "PaymentSlpRF":
							row[sectionCode] = this.IntConvert(searchCountWork.PaymentSlpCount);
							break;
						// �x�����׃f�[�^
						case "PaymentDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.PaymentDtlCount);
							break;
						// �󒍃}�X�^
						case "AcceptOdrRF":
							row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCount);
							break;
						// �󒍃}�X�^�i�ԗ��j
						case "AcceptOdrCarRF":
							row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCarCount);
							break;
						// DEL 2011.08.19 ------->>>>>
						//// ���㌎���W�v�f�[�^
						//case "MTtlSalesSlipRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    break;
						//// ���i�ʔ��㌎���W�v�f�[�^
						//case "GoodsMTtlSaSlipRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    break;
						//// �d�������W�v�f�[�^
						//case "MTtlStockSlipRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    break;
						// DEL 2011.08.19 -------<<<<<
						// �݌ɒ����f�[�^
						case "StockAdjustRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustCount);
							break;
						// �݌ɒ������׃f�[�^
						case "StockAdjustDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustDtlCount);
							break;
						// �݌Ɉړ��f�[�^
						case "StockMoveRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockMoveCount);
							break;
						// DEL 2011.08.19 ------->>>>>
						//// �݌Ɏ󕥗����f�[�^
						//case "StockAcPayHistRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    break;
						// DEL 2011.08.19 -------<<<<<
						// ���������}�X�^
						case "DepositAlwRF":
							row[sectionCode] = this.IntConvert(searchCountWork.DepositAlwCount);
							break;
						// ����`�f�[�^
						case "RcvDraftDataRF":
							row[sectionCode] = this.IntConvert(searchCountWork.RcvDraftDataCount);
							break;
						// �x����`�f�[�^
						case "PayDraftDataRF":
							row[sectionCode] = this.IntConvert(searchCountWork.PayDraftDataCount);
							break;
					}
				}

				foreach (string errSectionCode in errSectionCodeList)
				{
					row[errSectionCode] = ERROR_BATU;
				}
				_updateResultDataTable.Rows.Add(row);
			}
		}
		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        /// <summary>
        /// �O���b�h�񌟍��G���[�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �O���b�h�񌟍��G���[�ݒ�u�~�v���s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchResultErrGridCol(SearchCountWork searchCountWork)
        {
            // ���M�Ώۃf�[�^���O���b�h�֐ݒ肷��
            for (int i = 0; i < this._sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
                UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = i + 1;
                row.ExtractionData = secMngSndRcv.MasterName;
                row.ExtractionCount = ERROR_BATU;
                _updateResultDataTable.Rows.Add(row);
            }
        }

        # endregion �� �f�[�^���M���� ��

        #region  �� Private Method ��

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Update":
                    {
                        if (0 == this.Condition_Grid.Rows.Count)
                        {
                            // ���b�Z�[�W��\��
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M�Ώۋ��_���ݒ肳��Ă��܂���B", 0);
                            return;
                        }

                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this.Condition_Grid.ActiveCell != null)
                        {
                            this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // �X�V����
                        bool inputCheck = this.UpdateBeforeCheck();
                        if (inputCheck)
                        {
                            this.UpdateProcess();
                        }
                        break;
                    }
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                case "ButtonTool_Get":
                    {
                        if (0 == this.Condition_Grid.Rows.Count)
                        {
                            // ���b�Z�[�W��\��
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۋ��_���ݒ肳��Ă��܂���B", 0);
                            return;
                        }

                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this.Condition_Grid.ActiveCell != null)
                        {
                            this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // �X�V����
                        bool inputCheck = this.UpdateBeforeCheck();
                        if (inputCheck)
                        {
                            this.GetProcess();
                        }
                        break;
                    }
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                case "ButtonTool_Clear":
                    {
                        // ���ɖ߂�����
                        this.Retry();

                        break;
                    }
            }
        }

        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2008.11.26</br>
        /// </remarks>
        private void Retry()
        {
            this.Clear();
        }

        #region �� �f�[�^���M�N���A���� ��
        /// <summary>
        /// �f�[�^���M�N���A����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note	   : �Ȃ��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        private void Clear()
        {
            // ��ʏ���������
            this.InitializeScreen();
            ResetGridCol();//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
        }

        /// <summary>
        /// �f�[�^���M�N���A����������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �f�[�^���M�N���A���s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void InitializeScreen()
        {
			GuidInitProc();
            // ���M���e�[�u���N���A����
            this._updateResultDataTable.Clear();
            // ���o�����e�[�u���N���A����
            this._extractionConditionDataTable.Clear();
            // ���M���̎擾
            this._updateCountInputAcs.GetSecMngSendData(this._enterpriseCode, out this._sendDataList);
            // ���M��񏉊�������
            this.InitialAccDataGridCol();
            // ���o��������������
            this.InitialConDataGridCol();

            if (this.Condition_Grid.Rows.Count > 0)
            {
				//this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];// DEL 2011/07/25
				this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];// ADD 2011/07/25
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            }

            // ----- ADD 2011/11/11 xupz---------->>>>>
            this.tDateEditSt.SetDateTime(DateTime.Now);
            this.tDateEditEd.SetDateTime(DateTime.Now);
            // ----- ADD 2011/11/11 xupz----------<<<<<
        }
        #endregion �� �f�[�^���M�N���A���� ��

        #region �� ���̓`�F�b�N���� ��
        /// <summary>
        /// �f�[�^���M�����̓��̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �f�[�^���M�����̓��̓`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            bool status = true;

            string errMessage = "";

            if (!this.ScreenInputCheck(ref errMessage))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                status = false;
            }

            return status;
        }

        /// <summary>
        /// �X�V�`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̍X�V�`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;

            const string ct_NoInput = "�������͂ł��B";
            const string ct_RangeError = "���o���t�͈̔͂��s���ł��B";
            const string ct_BeginTimeError = "�̕ύX���͓��ꌎ���̂ݐݒ肪�\�ł��B";

            DateTime begDateTime = new DateTime();
            DateTime endDateTime = new DateTime();

            // ���M�Ώۃf�[�^�̑��݃`�F�b�N
            if (this._sendDataList.Count == 0)
            {
                errMessage = "����M�Ώېݒ�}�X�^���ݒ肳��Ă��܂���B";
                return false;
			}

			# region [DEL 2011/07/28]
			//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			//// ���t�͈̔̓`�F�b�N�p(�J�n�� > �I���� �� NG)
			//foreach (ExtractionConditionDataSet.ExtractionConditionRow row in this._updateCountInputAcs.ExtractionConditionDataTable)
			//{
			//    if (row.IsNull("BeginningTime") || row.IsNull("BeginningDate") || row.IsNull("EndDate") || row.IsNull("EndTime"))
			//    {
			//        break;
			//    }
			//    String beginningTimeStr = row.BeginningTime;
			//    String endDateTimeStr = row.EndTime;

			//    if (string.IsNullOrEmpty(beginningTimeStr) || string.IsNullOrEmpty(endDateTimeStr))
			//    {
			//        break;
			//    }
			//    int beginningTimeHours = int.Parse(beginningTimeStr.Substring(0, 2));
			//    int beginningTimeMinutes = int.Parse(beginningTimeStr.Substring(3, 2));
			//    int beginningTimeSeconds = int.Parse(beginningTimeStr.Substring(6, 2));
                
			//    int endDateHours = int.Parse(endDateTimeStr.Substring(0, 2));
			//    int endDateMinutes = int.Parse(endDateTimeStr.Substring(3, 2));
			//    int endDateSeconds = int.Parse(endDateTimeStr.Substring(6, 2));
			//    // �J�n��
			//    begDateTime = new DateTime(row.BeginningDate.Year, row.BeginningDate.Month, row.BeginningDate.Day,
			//        beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
			//    // �I����
			//    endDateTime = new DateTime(row.EndDate.Year, row.EndDate.Month, row.EndDate.Day,
			//        endDateHours, endDateMinutes, endDateSeconds);
			//}

			//String beginningDate = this.Condition_Grid.Rows[0].Cells["BeginningDate"].Value.ToString().Trim();
			//String beginningTime = this.Condition_Grid.Rows[0].Cells["BeginningTime"].Value.ToString().Trim();
			//String endDate = this.Condition_Grid.Rows[0].Cells["EndDate"].Value.ToString().Trim();
			//String endTime = this.Condition_Grid.Rows[0].Cells["EndTime"].Value.ToString().Trim();

			//// �J�n���t
			//if (beginningDate == string.Empty)
			//{
			//    errMessage = string.Format("���o�J�n���t{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell =  this.Condition_Grid.Rows[0].Cells["BeginningDate"];

			//    status = false;

			//    return status;
			//}
			//// �J�n����
			//if (this.Condition_Grid.Rows[0].Cells["BeginningTime"].Value.ToString().Trim() == string.Empty)
			//{
			//    errMessage = string.Format("���o�J�n����{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningTime"];
			//    status = false;

			//    return status;
			//}
			//// �I�����t
			//if (this.Condition_Grid.Rows[0].Cells["EndDate"].Value.ToString().Trim() == string.Empty)
			//{
			//    errMessage = string.Format("���o�I�����t{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["EndDate"];
			//    status = false;

			//    return status;
			//}
			//// �I������
			//if (this.Condition_Grid.Rows[0].Cells["EndTime"].Value.ToString().Trim() == string.Empty)
			//{
			//    errMessage = string.Format("���o�I������{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["EndTime"];
			//    status = false;

			//    return status;
			//}

			//// ���t�͈̔͂��`�F�b�N(�J�n�� > �I���� �� NG)
			//if (begDateTime > endDateTime)
			//{
			//    errMessage = ct_RangeError;
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];
			//    status = false;
			//    return status;
			//}

			//// �X�V��ʂ̊J�n���t�`�F�b�N
			//if (!this.UpdateOverData())
			//{
			//    errMessage = "���M�Ώۋ��_���ݒ肳��Ă��܂���B";
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];
			//    status = false;
			//    return status;
			//}

			//if (_startTime.Year == begDateTime.Year && _startTime.Month == begDateTime.Month && _startTime.Day == begDateTime.Day
			//     && _startTime.Hour == begDateTime.Hour && _startTime.Minute == begDateTime.Minute && _startTime.Second == begDateTime.Second)
			//{ 
			//    status = true;
			//}
			//else
			//{
			//    // �V�b�N���ԃ`�F�b�N
			//    if (begDateTime < _startTime)
			//    {
			//        if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
			//        {
			//            errMessage = string.Format("�J�n���t{0}", ct_BeginTimeError);
			//            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];
			//            status = false;
			//            return status;
			//        }
			//    }
			//}

			//-----DEL 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
			# endregion

			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.DataText))
			{
				errMessage = string.Format("���M��{0}", ct_NoInput);
				tEdit_SectionCodeAllowZero.Focus();
				status = false;

				return status;
			}
			bool checkCountFlg = false;
			selectSendInfoList = new ArrayList();

			ArrayList newSndDestCodeList = new ArrayList();
			_updateCountInputAcs.ReloadSecMngSetInfo(_enterpriseCode, out newSndDestCodeList);

			for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
			{
				//�`�F�b�N�I�����ꂽ���M�������R�[�h�̓`�F�b�N���s���B
				if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
				{
					checkCountFlg = true;
					// ���t�͈̔̓`�F�b�N�p(�J�n�� > �I���� �� NG)
					ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)this._updateCountInputAcs.ExtractionConditionDataTable.Rows[i];
					selectSendInfoList.Add(this.sendDestSecList[i]);

					//�I�����Ă��鑗�M��R�[�h���폜���ꂽ���ǂ����`�F�b�N
					if (!newSndDestCodeList.Contains(((SecMngSet)this.sendDestSecList[i]).SendDestSecCode.Trim()))
					{
						errMessage = string.Format("�폜���ꂽ���M�悪���݂��܂��B");
						status = false;
						return status;
					}

                    
                    if ((int)this.tce_ExtractCondDiv.Value == 0) //ADD 2011/11/11 xupz
                    {     //ADD 2011/11/11 xupz
                        String beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString().Trim();
                        String beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString().Trim();
                        String endDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString().Trim();
                        String endTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString().Trim();

                        // �J�n���t
                        if (beginningDate == string.Empty)
                        {
                            errMessage = string.Format("���o�J�n���t{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
                            status = false;
                            return status;
                        }
                        // �J�n����
                        if (beginningTime == string.Empty)
                        {
                            errMessage = string.Format("���o�J�n����{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningTime"];
                            status = false;
                            return status;
                        }
                        // �I�����t
                        if (endDate == string.Empty)
                        {
                            errMessage = string.Format("���o�I�����t{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["EndDate"];
                            status = false;
                            return status;
                        }
                        // �I������
                        if (endTime == string.Empty)
                        {
                            errMessage = string.Format("���o�I������{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["EndTime"];
                            status = false;
                            return status;
                        }

                        String beginningTimeStr = row.BeginningTime;
                        String endDateTimeStr = row.EndTime;

                        int beginningTimeHours = int.Parse(beginningTimeStr.Substring(0, 2));
                        int beginningTimeMinutes = int.Parse(beginningTimeStr.Substring(3, 2));
                        int beginningTimeSeconds = int.Parse(beginningTimeStr.Substring(6, 2));

                        int endDateHours = int.Parse(endDateTimeStr.Substring(0, 2));
                        int endDateMinutes = int.Parse(endDateTimeStr.Substring(3, 2));
                        int endDateSeconds = int.Parse(endDateTimeStr.Substring(6, 2));
                        // �J�n��
                        begDateTime = new DateTime(row.BeginningDate.Year, row.BeginningDate.Month, row.BeginningDate.Day,
                            beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
                        // �I����
                        endDateTime = new DateTime(row.EndDate.Year, row.EndDate.Month, row.EndDate.Day,
                            endDateHours, endDateMinutes, endDateSeconds);

                        // ���t�͈̔͂��`�F�b�N(�J�n�� > �I���� �� NG)
                        if (begDateTime > endDateTime)
                        {
                            errMessage = ct_RangeError;
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
                            status = false;
                            return status;
                        }
                    } //ADD 2011/11/11 xupz

					string tmpBaseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();// ADD 2011.08.25
					string tmpSendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();// ADD 2011.08.25
					// �X�V��ʂ̊J�n���t�`�F�b�N
					//if (!this.UpdateOverData()) // DEL 2011.08.25
					if (!this.UpdateOverData(tmpBaseCode, tmpSendCode)) // ADD 2011.08.25
					{
						errMessage = "���M�Ώۋ��_���ݒ肳��Ă��܂���B";
						this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
						status = false;
						return status;
					}

                    if ((int)this.tce_ExtractCondDiv.Value == 0) //ADD 2011/11/11 xupz
                    {     //ADD 2011/11/11 xupz
                        if (_startTime.Year == begDateTime.Year && _startTime.Month == begDateTime.Month && _startTime.Day == begDateTime.Day
                             && _startTime.Hour == begDateTime.Hour && _startTime.Minute == begDateTime.Minute && _startTime.Second == begDateTime.Second)
                        {
                            status = true;
                        }
                        else
                        {
                            // �V�b�N���ԃ`�F�b�N
                            if (begDateTime < _startTime)
                            {
                                if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
                                {
                                    errMessage = string.Format("�J�n���t{0}", ct_BeginTimeError);
                                    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
                                    status = false;
                                    return status;
                                }
                            }
                        }
                    } //ADD 2011/11/11 xupz
				}
			}
            // ----- ADD 2011/11/11 xupz---------->>>>>
            if ((int)this.tce_ExtractCondDiv.Value == 1)
            {
                DateTime dateSt = this.tDateEditSt.GetDateTime();
                DateTime dateEd = this.tDateEditEd.GetDateTime();

                DateGetAcs.CheckDateResult cdr;
                // �J�n���t
                cdr = this._dateGetAcs.CheckDate(ref this.tDateEditSt, false);
                if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    this.tDateEditSt.Focus();
                    errMessage = string.Format(MESSAGE_InvalidDate);
                    status = false;
                    return status;
                }
                else if (cdr == DateGetAcs.CheckDateResult.ErrorOfNoInput)
                {
                    errMessage = string.Format("���o�J�n���t{0}", ct_NoInput);
                    this.tDateEditSt.Focus();
                    status = false;
                    return status; 
                }
                // �I�����t
                cdr = this._dateGetAcs.CheckDate(ref this.tDateEditEd, false);
                if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    this.tDateEditEd.Focus();
                    errMessage = string.Format(MESSAGE_InvalidDate);
                    status = false;
                    return status;
                }
                else if (cdr == DateGetAcs.CheckDateResult.ErrorOfNoInput)
                {
                    errMessage = string.Format("���o�I�����t{0}", ct_NoInput);
                    this.tDateEditEd.Focus();
                    status = false;
                    return status; 
                }

                // �`�[���t�̓��t�͈͂��`�F�b�N(�J�n�� > �I���� �� NG)
                if (dateSt > dateEd)
                {
                    errMessage = ct_RangeError;
                    this.tDateEditSt.Focus();
                    status = false;
                    return status;
                }

                if (_startTime.Year == dateSt.Year && _startTime.Month == dateSt.Month && _startTime.Day == dateSt.Day
                     && _startTime.Hour == dateSt.Hour && _startTime.Minute == dateSt.Minute && _startTime.Second == dateSt.Second)
                {
                    status = true;
                }
                else
                {
                    // �V�b�N���ԃ`�F�b�N
                    if (dateSt < _startTime)
                    {
                        if (dateSt.Year != dateEd.Year || dateSt.Month != dateEd.Month)
                        {
                            errMessage = string.Format("�J�n���t{0}", ct_BeginTimeError);
                            this.tDateEditSt.Focus();
                            status = false;
                            return status;
                        }
                    }
                }
            }
            // ----- ADD 2011/11/11 xupz----------<<<<<

			//���M�悪1�ł��`�F�b�N�I������Ȃ��ꍇ
			if (!checkCountFlg && this.Condition_Grid.Rows.Count>0)
			{
				errMessage = "���M�拒�_���I������Ă��܂���B";
				status = false;
				return status;
			}
			
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // �ڑ���`�F�b�N
            if (!_updateCountInputAcs.CheckConnect(_enterpriseCode, false, out _connectPointDiv, out errMessage))
            {
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// �G���[���b�Z�[�W����
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:�o�׎������ false:�o�׎��������</returns>
        /// <remarks>
        /// <br>Note		: �G���[���b�Z�[�W���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                ct_ClassID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        #endregion  �� ���̓`�F�b�N���� ��


        /// <summary>
        /// �O���b�h�L�[�v���X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Condition_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

            // ActiveCell�����ʂ̏ꍇ
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(e.KeyChar, cell.Text, cell.SelStart, cell.SelLength))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="prevVal">���͒l</param>
        /// <param name="selstart">�J�n�ʒu</param>
        /// <param name="sellength">����</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        private bool KeyPressNumCheck(char key, string prevVal, int selstart, int sellength)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > 6)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Enter�L�[�̏���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: Enter�L�[���N�b���N���鎞�A�������s���܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void Condition_Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;


            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // �J�n���ԕϊ�
                if (value.Length == 6)
                {
                    this._extractionConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
            // ActiveCell���I�����Ԃ̏ꍇ
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // �I�����ԕϊ�
                if (value.Length == 6)
                {
                    this._extractionConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
        }

        /// <summary>
        /// Enter�L�[�̏���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: Enter�L�[���N�b���N���鎞�A�������s���܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void Condition_Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;
            String value = cell.Value.ToString().Trim();

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                // �J�n���ԕϊ�
                if (value.Length == 8)
                {
                    this._extractionConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ActiveCell���I�����Ԃ̏ꍇ
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                // �I�����ԕϊ�
                if (value.Length == 8)
                {
                    this._extractionConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ADD 2009/05/20 --->>>
            else if (cell.Column.Key == this._extractionConditionDataTable.BeginningDateColumn.ColumnName
               || cell.Column.Key == this._extractionConditionDataTable.EndDateColumn.ColumnName)
            {
                if (cell.Value is DBNull)
                {
                    this._preDataTime = DateTime.MinValue;
                }
                else
                {
                    this._preDataTime = Convert.ToDateTime(cell.Value);
                }
            }
            // ADD 2009/05/20 ---<<<
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �O���b�h�Z���A�b�v�f�[�g��C�x���g�����������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Condition_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            // ADD 2009/05/20 --->>>
            string errMsg = string.Empty;
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                errMsg = "�J�n���Ԃ͎���6���œ��͂��ĉ������B";
            }
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                errMsg = "�I�����Ԃ͎���6���œ��͂��ĉ������B";
            }
            // ADD 2009/05/20 ---<<<

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                string startTime = cell.Value.ToString().Trim();
                // �`�F�b�N����
                if (!string.IsNullOrEmpty(startTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < startTime.Length; i++)
                    {
                        if (!char.IsNumber(startTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           // UPD 2009/05/20 --->>>
                           // "�f�[�^�l���X�V�ł��܂���:�G�f�B�^�̒l�͖����ł��B",
                           errMsg,
                            // UPD 2009/05/20 ---<<<
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // ���`�F�b�N
                        if (startTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                // UPD 2009/05/20 --->>>
                                // "�f�[�^�l���X�V�ł��܂���:�G�f�B�^�̒l�͖����ł��B",
                                errMsg,
                                // UPD 2009/05/20 ---<<<
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // ���ԗL�����`�F�b�N
                            int hour = Convert.ToInt32(startTime.Substring(0, 2));
                            int minute = Convert.ToInt32(startTime.Substring(2, 2));
                            int second = Convert.ToInt32(startTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                    // UPD 2009/05/20 --->>>
                                    // "�f�[�^�l���X�V�ł��܂���:�G�f�B�^�̒l�͖����ł��B",
                                    errMsg,
                                    // UPD 2009/05/20 ---<<<
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
                                {
                                    this._extractionConditionDataTable[rowIndex].BeginningTime = startTime.Substring(0, 2) + ":" 
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }
                                else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName) 
                                {
                                    this._extractionConditionDataTable[rowIndex].EndTime = startTime.Substring(0, 2) + ":"
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Condition_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
                // Shift�L�[�̏ꍇ
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.Condition_Grid.ActiveCell = null;
                                this.Condition_Grid.ActiveRow = cell.Row;
                                this.Condition_Grid.Selected.Rows.Clear();
                                this.Condition_Grid.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.Condition_Grid.ActiveCell = null;
                                this.Condition_Grid.ActiveRow = cell.Row;
                                this.Condition_Grid.Selected.Rows.Clear();
                                this.Condition_Grid.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
								 //EnterNextEditableCellDetail(cell, -1);
                                break;
                            }
                    }
                }
                // Alt�L�[�̏ꍇ
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                // s
                                break;
                            }
                    }
                }
                else
                {
                    // �ҏW���ł������ꍇ
					if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.Condition_Grid.ActiveCell.StyleResolved)
                        {
                            // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.Condition_Grid.ActiveCell.SelStart == 0)
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                                // ADD ���� 2011/07/28 ----------------------------->>>>>>
                                                while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
                                                    "SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD ���� 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.Condition_Grid.ActiveCell.SelStart >= this.Condition_Grid.ActiveCell.Text.Length)
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                                // ADD ���� 2011/07/28 ----------------------------->>>>>>
                                                while (!this.Condition_Grid.ActiveCell.IsInEditMode )
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD ���� 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ADD ���� 2011/07/28 ----------------------------->>>>>>
                                        // ���L�[
                                        case Keys.Down:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Up:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ADD ���� 2011/07/28 -----------------------------<<<<<<
                                    }
                                }
                                break;
                            // ��L�ȊO�̃X�^�C��
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                                // ADD ���� 2011/07/28 ----------------------------->>>>>>
                                                while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
                                                    "SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD ���� 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                                // ADD ���� 2011/07/28 ----------------------------->>>>>>
                                                while (!this.Condition_Grid.ActiveCell.IsInEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD ���� 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ADD ���� 2011/07/28 ----------------------------->>>>>>
                                        // ���L�[
                                        case Keys.Down:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Up:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ADD ���� 2011/07/28 -----------------------------<<<<<<
                                    }
                                    break;
                                }
                        }
                    }
                    // ADD ���� 2011/07/28 ----------------------------->>>>>>
                    else
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Left:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                    e.Handled = true;
                                    while (!(this.Condition_Grid.ActiveCell.IsInEditMode || 
                                        "SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                    {
                                        this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                        e.Handled = true;
                                    }
                                    e.Handled = true;
                                    break;
                                }
                            case Keys.Right:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                    e.Handled = true;
                                    while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
                                        "BeginningDate".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                    {
                                        this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                        e.Handled = true;
                                    }
                                    e.Handled = true;
                                    break;
                                }
                            // ���L�[
                            case Keys.Down:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                    if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                    {
                                        this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    e.Handled = true;
                                }
                                break;
                            // ���L�[
                            case Keys.Up:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                    if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                    {
                                        this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    e.Handled = true;
                                }
                                break;
                        }
                    }
                    // ADD ���� 2011/07/28 -----------------------------<<<<<<

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                break;
                            }
                    }
                }
            }

            else if (this.Condition_Grid.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.Condition_Grid.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            // Del�L�[�̑���
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ��ʏ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ�������C�x���g�����������܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.30</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            // �ڑ���`�F�b�N����
            string errMsg = null;
            if (!_updateCountInputAcs.CheckConnect(_enterpriseCode, false, out _connectPointDiv, out errMsg))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                return;
            }
        }

        // ADD 2009/05/20 --->>>
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.05.20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				case "tEdit_SectionCodeAllowZero":
					{
						// ���_�R�[�h�擾
						string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
						if (sectionCode.Trim().Equals(""))
						{
							// ���ɖ߂�����
							this.Retry();
							return;
						}

						if (this._preSectionCode !=null && sectionCode.Trim().Equals(this._preSectionCode.PadLeft(2, '0')))
						{
							return;
						}
                        // DEL 2011/10/10------------>>>>>
                        //// ADD 2011.08.19--------->>>>>>
                        //if (sectionCode.Trim().Equals(_loginSectionCode.Trim()))
                        //{
                        //    TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
                        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        //                ct_ClassID,							// �A�Z���u��ID
                        //                "�����_�͑I���ł��܂���B",	    // �\�����郁�b�Z�[�W
                        //                0,									    // �X�e�[�^�X�l
                        //                MessageBoxButtons.OK);					// �\������{�^��

                        //    this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
                        //    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                        //    return;
                        //}
                        //// ADD 2011.08.19---------<<<<<<
                        // DEL 2011/10/10------------<<<<<
						// ���_���̎擾
						string sectionName = GetSectionName(sectionCode);

						if (sectionName.Trim() != string.Empty)
						{
							//���_�Ǘ��ݒ�}�X�^�Ƀ`�F�b�N
							if (!sectionCode.PadLeft(2, '0').Equals("00"))
							{
								if (_searchSecMngList.Count > 0)
								{

									bool sameFlg = false;
									for (int i = 0; i < _searchSecMngList.Count; i++)
									{
										SecMngSet tSecMngSet = _searchSecMngList[i] as SecMngSet;
										if (tSecMngSet.SendDestSecCode.Trim().PadLeft(2, '0').Equals(sectionCode.PadLeft(2, '0')))
										{
											sameFlg = true;
										}
									}

									if (!sameFlg)
									{
										TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
										emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
										ct_ClassID,							// �A�Z���u��ID
										//"���M�拒�_�R�[�h�����݂��Ȃ��B",	    // �\�����郁�b�Z�[�W // DEL 2011.08.19 Redmine#23807
										"���M�拒�_�R�[�h�����݂��܂���B",	    // �\�����郁�b�Z�[�W// ADD 2011.08.19 Redmine#23807
										0,									    // �X�e�[�^�X�l
										MessageBoxButtons.OK);					// �\������{�^��

										this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
										e.NextCtrl = this.tEdit_SectionCodeAllowZero;
										return;
									}
								}

								else
								{
									TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
										   emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
										   ct_ClassID,							// �A�Z���u��ID
										   //"���M�拒�_�R�[�h�����݂��Ȃ��B",	    // �\�����郁�b�Z�[�W // DEL 2011.08.19 Redmine#23807
										   "���M�拒�_�R�[�h�����݂��܂���B",	    // �\�����郁�b�Z�[�W// ADD 2011.08.19 Redmine#23807
										   0,									    // �X�e�[�^�X�l
										   MessageBoxButtons.OK);					// �\������{�^��

									this.tEdit_SectionCodeAllowZero.DataText = string.Empty;
									e.NextCtrl = this.tEdit_SectionCodeAllowZero;
									return;

								}
							}
							this._preSectionCode = sectionCode;
							this.uLabel_SectionNm.Text = sectionName;
							this.tEdit_SectionCodeAllowZero.Text = sectionCode.Trim().PadLeft(2, '0');

							ResetGridCol();
                            SetSecCode(this.tEdit_SectionCodeAllowZero.Text);//ADD 2011/09/14 sundx #24542
						}
						else
						{
							TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
							ct_ClassID,							// �A�Z���u��ID
							"�w�肵�����_�R�[�h�͑��݂��܂���B",	                // �\�����郁�b�Z�[�W
							0,									    // �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��

							this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
							e.NextCtrl = this.tEdit_SectionCodeAllowZero;
						}

                        ChangeConditionGrid();  //  ADD dingjx  2011/11/01
						break;
					}
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>

                case "Condition_Grid":
                    {
						switch (e.Key)
						{
							case Keys.Return:
								{
									if (this.Condition_Grid.ActiveCell != null)
									{
										//if (MoveNextAllowEditCell(false) // DEl 2011/07/28
										if (MoveNextAllowEditCell(false, e.ShiftKey)) // ADD 2011/07/28
										{
											e.NextCtrl = null;
										}
										else if (this.Condition_Grid.Rows[this._updateCountInputAcs.ExtractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
										{
											e.NextCtrl = null;
											this.Condition_Grid.Rows[0].Cells[2].Activate();
											this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
										}
										else
										{
											e.NextCtrl = e.PrevCtrl;
										}
									}

									break;
								}
							case Keys.Tab:
								{
									//if (MoveNextAllowEditCell(false) // DEl 2011/07/28
									if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/28
									{
										e.NextCtrl = null;
									}
									else if (this.Condition_Grid.Rows[this._updateCountInputAcs.ExtractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
									{
										e.NextCtrl = null;
										this.Condition_Grid.Rows[0].Cells[2].Activate();
										this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
									}
									else
									{
										e.NextCtrl = e.PrevCtrl;
									}

									break;
								}
						}
						break;
						
                    }
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
		//private bool MoveNextAllowEditCell(bool activeCellCheck)// DEl 2011/07/28
		private bool MoveNextAllowEditCell(bool activeCellCheck, bool shiftFlg)// ADD 2011/07/28
        {
            this.Condition_Grid.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.Condition_Grid.ActiveCell != null))
            {
                if ((!this.Condition_Grid.ActiveCell.Column.Hidden) &&
                    (this.Condition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.Condition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                if (shiftFlg)
                {
                    performActionResult = this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                }
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                else
                {
                    performActionResult = this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                }

                if (performActionResult)
                {
                    if ((this.Condition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.Condition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.Condition_Grid.ResumeLayout();
            return performActionResult;
        }


        /// <summary>
        /// �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void Condition_Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.Condition_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.Condition_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.Condition_Grid.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.Condition_Grid.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.Condition_Grid.ActiveCell.Value = 0;
                    }
                    // �ʏ����				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.Condition_Grid.ActiveCell.Column.DataType);
                            this.Condition_Grid.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.Condition_Grid.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�	
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
                else if (this.Condition_Grid.ActiveCell.Column.DataType == typeof(TimeSpan))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;

                        if (editorBase.TextLength == 6)
                        {
                            string value = editorBase.CurrentEditText;

                            editorBase.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                            this.Condition_Grid.ActiveCell.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�f�[�^�l���X�V�ł��܂���:�G�f�B�^�̒l�͖����ł��B",
                                -1,
                                MessageBoxButtons.OK);

                            editorBase.Value = null;
                            this.Condition_Grid.ActiveCell.Value = null;
                        }
                    }
                    catch
                    {

                    }
                }
                else if (this.Condition_Grid.ActiveCell.Column.DataType == typeof(DateTime))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;
                        Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

                        if (cell.Column.Key == this._extractionConditionDataTable.BeginningDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�J�n���t�͓��t8���œ��͂��ĉ������B",
                                -1,
                                MessageBoxButtons.OK);

                            if (this._preDataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.Condition_Grid.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this._preDataTime;
                                this.Condition_Grid.ActiveCell.Value = this._preDataTime;
                            }
                        }
                        else if (cell.Column.Key == this._extractionConditionDataTable.EndDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "�I�����t�͓��t8���œ��͂��ĉ������B",
                               -1,
                               MessageBoxButtons.OK);

                            if (this._preDataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.Condition_Grid.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this._preDataTime;
                                this.Condition_Grid.ActiveCell.Value = this._preDataTime;
                            }
                        }
                    }
                    catch
                    {

                    }

                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�	
                }
            }
        }
        // ADD 2009/05/20 ---<<<


		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        /// <summary>
        /// ���M��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click_1(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;

            // �S�Е\���K�C�h���S�Д�\���K�C�h�֕ύX
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo); //DEL by Liangsd 2011/09/05
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);     //ADD by Liangsd 2011/09/05
            // DEL 2011/10/10------------>>>>>
            //// ADD 2011.08.19------------>>>>>
            //if (sectionInfo.SectionCode.Trim().Equals(_loginSectionCode.Trim()))
            //{
            //    TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
            //                ct_ClassID,							// �A�Z���u��ID
            //                "�����_�͑I���ł��܂���B",	    // �\�����郁�b�Z�[�W
            //                0,									    // �X�e�[�^�X�l
            //                MessageBoxButtons.OK);					// �\������{�^��

            //    this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
            //    return;
            //}
            //// ADD 2011.08.19------------<<<<<
            // DEL 2011/10/10------------<<<<<
            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
				//���_�Ǘ��ݒ�}�X�^�Ƀ`�F�b�N
                //if (_searchSecMngList.Count > 0 && !sectionInfo.SectionCode.Trim().Equals("00")) //DEL by Liangsd 2011/09/05
                if (_searchSecMngList.Count >= 0 && !sectionInfo.SectionCode.Trim().Equals("00"))//ADD by Liangsd 2011/09/05
				{
					bool sameFlg = false;
					for (int i = 0; i < _searchSecMngList.Count; i++)
					{
						SecMngSet tSecMngSet = _searchSecMngList[i] as SecMngSet;
						if (tSecMngSet.SendDestSecCode.Trim().Equals(sectionInfo.SectionCode.Trim()))
						{
							sameFlg = true;
						}
					}

                    if (!sameFlg)
                    {
                        TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        ct_ClassID,							// �A�Z���u��ID
                            //"���M�拒�_�R�[�h�����݂��Ȃ��B",	    // �\�����郁�b�Z�[�W // DEL 2011.08.19 Redmine#23807
                        "���M�拒�_�R�[�h�����݂��܂���B",	    // �\�����郁�b�Z�[�W// ADD 2011.08.19 Redmine#23807
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��

                        this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
                        return;
                    }                    
				}
				this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.Trim();
				this._preSectionCode = sectionInfo.SectionCode.Trim();
				ResetGridCol();
                SetSecCode(this.tEdit_SectionCodeAllowZero.Text);//ADD 2011/09/14 sundx #24542
                // ���t�H�[�J�X
                this.ultraTabControl1.Focus();
            }
            ChangeConditionGrid();  //  ADD dingjx  2011/11/01
        }

        /// <summary>
        ///	���M�揉��������
        /// </summary>
        /// <remarks>
        /// <br>Note	    : ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer  : ���X</br>
        /// <br>Date        : 2011/07/28</br>
        private void GuidInitProc()
        {
            string secCode = CheckSecMng();
            // ��ʂ̏����l���Z�b�g
			if (string.Empty.Equals(secCode))
			{
				this.tEdit_SectionCodeAllowZero.Text = string.Empty;
				this.uLabel_SectionNm.Text = string.Empty;
			}
			else
			{
				this.tEdit_SectionCodeAllowZero.Text = secCode.Trim().PadLeft(2, '0');
				this._preSectionCode = secCode.Trim().PadLeft(2, '0');
				this.uLabel_SectionNm.Text = GetSectionName(secCode);
			}
            // �t�H�J�X�̐ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>				
        /// ���_�Ǘ��ݒ�}�X�^�`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
        private string CheckSecMng()
        {
            // ���_�Ǘ��ݒ�}�X�^�̃f�[�^����������
            SecMngSetAcs secMngSetAcs = new SecMngSetAcs();
            ArrayList secMngSetList = new ArrayList();
			_searchSecMngList = new ArrayList();
			string secCd = "";
			Hashtable sendSecCdHt = new Hashtable();

            int status = secMngSetAcs.SearchAll(out secMngSetList, this._enterpriseCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secMngSetList.Count > 0)
			{
				foreach (SecMngSet tmpSecMngSet in secMngSetList)
				{
					if (tmpSecMngSet.Kind.Equals(0) &&
						tmpSecMngSet.ReceiveCondition.Equals(0) &&
						tmpSecMngSet.LogicalDeleteCode.Equals(0))
					{
						_searchSecMngList.Add(tmpSecMngSet);
						if (!sendSecCdHt.Contains(tmpSecMngSet.SendDestSecCode.Trim()))
						{
							sendSecCdHt.Add(tmpSecMngSet.SendDestSecCode.Trim(), tmpSecMngSet);
						}
					}
				}
				if (1 == sendSecCdHt.Count)
				{
					//���_�Ǘ��ݒ�}�X�^�ɂ͒P��f�[�^������ꍇ
					SecMngSet tSecMngSet = _searchSecMngList[0] as SecMngSet;
					secCd = tSecMngSet.SendDestSecCode;
				}
				else if (sendSecCdHt.Count > 1)
				{
					//���_�Ǘ��ݒ�}�X�^�ɂ͕����f�[�^������ꍇ
					secCd = "00";
                    //ADD 2011/09/14 sundx #24542 ---------------------------------->>>>>
                    if (_initSecCode == secCd || sendSecCdHt.Contains(_initSecCode))
                    {
                        secCd = _initSecCode;
                        SetSecCode(_initSecCode);
                    }
                    //ADD 2011/09/14 sundx #24542 ----------------------------------<<<<<
				}
			}
			else
			{
				secCd = string.Empty;
			}
            return secCd;
        }

		/// <summary>
		/// ���_���̎擾����
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>���_����</returns>
		/// <remarks>
		/// </remarks>
		private string GetSectionName(string sectionCode)
		{
			string sectionName = string.Empty;

			if (sectionCode.Trim().PadLeft(2, '0') == "00")
			{
				sectionName = "�S��";
				return sectionName;
			}

			ArrayList retList = new ArrayList();
			SecInfoAcs secInfoAcs = new SecInfoAcs();

			try
			{
				foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
					{
						sectionName = secInfoSet.SectionGuideNm.Trim();
						return sectionName;
					}
				}
			}
			catch
			{
				sectionName = string.Empty;
			}

			return sectionName;
		}

		/// <summary>
		/// �O���b�h�����Đݒ�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  :�O���b�h�����Đݒ�B</br>
		/// <br>Programmer  : ����</br>
		/// <br>Date        : 2011/07/28</br>
		/// </remarks>
		private void ResetGridCol()
		{
			this.LoadBaseData();
			this.CheckSecMng();

			this._extractionConditionDataTable.Clear();
			this._updateResultDataTable.Clear();

			// ���M���f�[�^�ݒ�
			this.Acc_Grid.DataSource = this._updateResultDataTable;
			// ���M�����f�[�^�ݒ�
			this.Condition_Grid.DataSource = this._extractionConditionDataTable;
			// ����M�ΏۃO���b�h�����ݒ�
			this.InitialAccDataGridCol();
			// �O���b�h�����ݒ�̐ݒ�
			this.InitialConDataGridCol();
			// ���M�����O���b�h�Đݒ�
			this.ResetConSettingGridCol();
		}

		/// <summary>
		/// ���M�����O���b�h�Đݒ�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  :���M�����O���b�h�Đݒ�B</br>
		/// <br>Programmer  : ����</br>
		/// <br>Date        : 2011/07/28</br>
		/// </remarks>
		private void ResetConSettingGridCol()
		{
			this._extractionConditionDataTable.Clear();
			//�u00:�S�Ёv�ł͂Ȃ��ꍇ�A���͂������M�拒�_������ۗ�
			for (int i = 0; i < this._allConditionDataTable.Rows.Count; i++)
			{
				ExtractionConditionDataSet.ExtractionConditionRow newRow = _extractionConditionDataTable.NewExtractionConditionRow();
				ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_allConditionDataTable.Rows[i];
				newRow.SendDestCond = row.SendDestCond;
				newRow.SendCode = row.SendCode;
				newRow.SendName = row.SendName;
				newRow.BaseCode = row.BaseCode;
				newRow.BaseName = row.BaseName;

                // ----- DEL 2011/11/10 xupz---------->>>>>
                //newRow.BeginningDate = row.BeginningDate;
                //newRow.BeginningTime = row.BeginningTime;
                //newRow.EndDate = row.EndDate;
                //newRow.EndTime = row.EndTime;
                // ----- DEL 2011/11/10 xupz----------<<<<<

                // ----- ADD 2011/11/10 xupz---------->>>>>
                //�f�[�^���M���o�����敪���u�����v�̏ꍇ
                if(tce_ExtractCondDiv.SelectedIndex == 0)
                {
                    newRow.BeginningDate = row.BeginningDate;
                    newRow.BeginningTime = row.BeginningTime;
                    newRow.EndDate = row.EndDate;
                    newRow.EndTime = row.EndTime;
                }
                //�f�[�^���M���o�����敪���u�`�[���t�v�̏ꍇ
                else if (tce_ExtractCondDiv.SelectedIndex == 1)
                {
                    string StartTime = DateTime.MinValue.ToLongTimeString().ToString();
                    newRow.BeginningDate = DateTime.Now.Date;
                    newRow.BeginningTime = StartTime.PadLeft(8,'0');
                    newRow.EndDate = DateTime.Now.Date ;
                    newRow.EndTime = DateTime.Now.ToLongTimeString().ToString();
                }
                // ----- ADD 2011/11/10 xupz----------<<<<<

                if (ALL_SECTIONCODE.Equals(tEdit_SectionCodeAllowZero.DataText))
				{
					_extractionConditionDataTable.Rows.Add(newRow);
				}
				else
				{
					if (row.SendCode.Trim().Equals(tEdit_SectionCodeAllowZero.DataText.Trim()))
					{
						_extractionConditionDataTable.Rows.Add(newRow);
					}
				}
			}
		}

		/// <summary>
		/// �X�V������ő��M�����^�u���Đݒ肷��
		/// </summary>
		/// <remarks>		
		/// <br>Note		: ���M�����̎��Ԑݒ菈�����s���B</br>
		/// <br>Programmer	: ����</br>	
		/// <br>Date		: 2011/07/28</br>
		/// </remarks>
		private void SearchCondtionGridCol()
		{
			this.LoadBaseData();
			if (!ALL_SECTIONCODE.Equals(this.tEdit_SectionCodeAllowZero.DataText))
			{
				//�u00:�S�Ёv�ł͂Ȃ��ꍇ�A���͂������M�拒�_������ۗ�
				ArrayList indexList = new ArrayList();
				for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
				{
					ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
					if (!row.SendCode.Trim().Equals(tEdit_SectionCodeAllowZero.DataText.Trim()))
					{
						indexList.Add(i);
					}
				}

				for (int j = indexList.Count - 1; j >= 0; j--)
				{
					_extractionConditionDataTable.Rows.RemoveAt((int)indexList[j]);
				}
			}
			for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
			{
				ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
				row.SendDestCond = false;
				for (int j = 0; j < selectSendInfoList.Count; j++)
				{
					SecMngSet secMngSetWork = (SecMngSet)selectSendInfoList[j];
					if (row.BaseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
						&& row.SendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
					{
						row.SendDestCond = true;
						break;
					}
				}
			}

		}
		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

		// ADD 2011.08.23------->>>>>
		/// <summary>
		/// SelectedTabChanged
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (e.Tab.Key.Equals("updateTab"))
			{
				ultraLabel1.Visible = true;
			}
			else
			{
				ultraLabel1.Visible = false;
			}
		}
		// ADD 2011.08.23-------<<<<<
		
        //  ADD dingjx  2011/11/01  ------------------------>>>>>>
        /// <summary>
        /// tce_ExtractCondDiv value changed event.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">event param</param>
        /// <remarks>
        /// <br>Programmer  : dingjx</br>
        /// <br>Note        : Redmine #26228</br>
        /// </remarks>
        private void tce_ExtractCondDiv_ValueChanged(object sender, EventArgs e)
        {
            this.ChangeConditionGrid();
        }

        /// <summary>
        /// Change ConditionGrid's value
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : dingjx</br>
        /// <br>Note        : Redmine #26228</br>
        /// </remarks>
        private void ChangeConditionGrid()
        {
            string MINVALUE = "000000"; // The time minvalue.
            string[] time = (DateTime.Now.ToString()).Split(' ');   // Get now time and split it.

            // ����
            if (tce_ExtractCondDiv.SelectedIndex == 0)
            {
                this.SetExtractCondDiv(this.tce_ExtractCondDiv.SelectedIndex.ToString());    // Save selected index into local.

                this._extractionConditionDataTable.Clear();
                this.SearchCondtionGridCol();
                // ----- ADD 2011/11/11 xupz---------->>>>>
                this.tDateEditSt.Visible = false;
                this.ultraLabel2.Visible = false;
                this.tDateEditEd.Visible = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningDate"].Hidden = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningTime"].Hidden = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndDate"].Hidden = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndTime"].Hidden = false;
                // �\�����ݒ�
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Width = 40;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].Width = 50;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].Width = 200;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 200;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 120;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
                // ----- ADD 2011/11/11 xupz----------<<<<<
            }
            // �`�[���t
            else
            {
                this.SetExtractCondDiv(this.tce_ExtractCondDiv.SelectedIndex.ToString());    // Save selected index into local.

                for (int i = 0; i < Condition_Grid.Rows.Count; i++)
                {
                    this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value = time[0];
                    this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value = MINVALUE;
                    this.Condition_Grid.Rows[i].Cells["EndDate"].Value = time[0];

                    // If geted time format is 0:00:00, then change it to 00:00:00
                    if (time[1].ToString().Length < 8)
                        time[1] = time[1].PadLeft(8, '0');
                    this.Condition_Grid.Rows[i].Cells["EndTime"].Value = time[1].ToString().Replace(":", "");   // Replace format from 00:00:00 to 000000.
                }
                // ----- ADD 2011/11/11 xupz---------->>>>>
                this.tDateEditSt.Visible = true;
                this.ultraLabel2.Visible = true;
                this.tDateEditEd.Visible = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningDate"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningDate"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningTime"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndDate"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndTime"].Hidden = true;
                // ----- ADD 2011/11/11 xupz----------<<<<<
            }
            //  Check the checkbox and quit edit mode.
            for (int i = 0; i < Condition_Grid.Rows.Count; i++)
            {
                this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value = true;   //  Check the checkbox
                //  quit edit mode.
                this.Condition_Grid.Rows[i].Activated = true;
            }
            this.Condition_Grid.Rows[0].Activated = true;   //  quit edit mode.
        }

        # region �� ���o�����敪�ۑ� ADD dingjx #26228 ���o�����敪�ɂ��� ��
        /// <summary>
        /// �O���I���̒��o�����敪���擾
        /// </summary>
        /// <returns>���o�����敪</returns>
        public string GetExtractCondDiv()
        {
            string div = "0";
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }

                    _uiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    div = _uiDataSet.Tables["Div"].Rows[0][0].ToString();
                }
            }
            catch { }
            return div;
        }
        /// <summary>
        /// �I���������o�����敪��XML�t�@�C���ɕۑ�
        /// </summary>
        /// <param name="selectedIndex">���o�����敪</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SetExtractCondDiv(string selectedIndex)
        {
            int status = 0;
            try
            {
                if (!string.IsNullOrEmpty(selectedIndex))
                {
                    string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);
                    fileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName);
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }
                    if (_uiDataSet.Tables["Div"] == null)
                    {
                        DataTable dt = new DataTable("Div");
                        DataColumn col = new DataColumn("SelectedIndex", typeof(string));
                        dt.Columns.Add(col);
                        _uiDataSet.Tables.Add(dt);
                    }
                    _uiDataSet.Tables["Div"].Clear();
                    DataRow row = _uiDataSet.Tables["Div"].NewRow();
                    row[0] = selectedIndex;
                    _uiDataSet.Tables["Div"].Rows.Add(row);
                    _uiDataSet.WriteXml(fileName);
                }
            }
            catch
            {
                status = 1000;
            }
            return status;
        }

        # endregion �� ���o�����敪�ۑ� ��
        //  ADD dingjx  2011/11/01  ------------------------<<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        # region �� �O���b�h��X�^�C���ݒ菈�� ��
        /// <summary>
        /// �O���b�h��X�^�C���ݒ菈��
        /// </summary>
        /// <param name="searchCntDic">���M�f�[�^Dic</param>
        /// <param name="errSectionCodeList">���M���s���_�ꗗ</param>
        /// <param name="mode">���M��ԃ��[�h</param>
        /// <remarks>		
        /// <br>Note		: �O���b�h��X�^�C���ݒ菈�����s���B</br>
        /// <br>            : 10900690-00 2013/3/13�z�M���ً̋}�Ή�</br>
        /// <br>            : Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// </remarks>
        private void SearchResultDataGridCol(Dictionary<string, SearchCountWork> searchCntDic, ArrayList errSectionCodeList, int mode)
        {
            // ���M���
            string strplus = string.Empty;
            if (mode == 1)
            {
                strplus = " ���M����";
            }
            else if (mode == 2)
            {
                strplus = " �����M";
            }
            UpdateResultDataSet.UpdateResultRow row = null;
            // ���M�Ώۃf�[�^���O���b�h�֐ݒ肷��
            for (int i = 0; i < this._sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
                row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = i + 1;
                row.ExtractionData = secMngSndRcv.MasterName;
                row.ExtractionCount = string.Empty;
                foreach (string sectionCode in searchCntDic.Keys)
                {
                    SearchCountWork searchCountWork = searchCntDic[sectionCode];
                    switch (secMngSndRcv.FileId)
                    {
                        // ����f�[�^
                        case "SalesSlipRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesSlipCount) + strplus;
                            if (searchCountWork.SalesSlipCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // ���㖾�׃f�[�^
                        case "SalesDetailRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesDetailCount) + strplus;
                            if (searchCountWork.SalesDetailCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // ���㗚���f�[�^
                        case "SalesHistoryRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesHistoryCount) + strplus;
                            if (searchCountWork.SalesHistoryCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // ���㗚�𖾍׃f�[�^
                        case "SalesHistDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesHistDtlCount) + strplus;
                            if (searchCountWork.SalesHistDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �����f�[�^
                        case "DepsitMainRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.DepsitMainCount) + strplus;
                            if (searchCountWork.DepsitMainCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �������׃f�[�^
                        case "DepsitDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.DepsitDtlCount) + strplus;
                            if (searchCountWork.DepsitDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �d���f�[�^
                        case "StockSlipRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockSlipCount) + strplus;
                            if (searchCountWork.StockSlipCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �d�����׃f�[�^
                        case "StockDetailRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockDetailCount) + strplus;
                            if (searchCountWork.StockDetailCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �d�������f�[�^
                        case "StockSlipHistRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockSlipHistCount) + strplus;
                            if (searchCountWork.StockSlipHistCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �d�����𖾍׃f�[�^
                        case "StockSlHistDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockSlHistDtlCount) + strplus;
                            if (searchCountWork.StockSlHistDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �x���`�[�}�X�^
                        case "PaymentSlpRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.PaymentSlpCount) + strplus;
                            if (searchCountWork.PaymentSlpCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �x�����׃f�[�^
                        case "PaymentDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.PaymentDtlCount) + strplus;
                            if (searchCountWork.PaymentDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �󒍃}�X�^
                        case "AcceptOdrRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCount) + strplus;
                            if (searchCountWork.AcceptOdrCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �󒍃}�X�^�i�ԗ��j
                        case "AcceptOdrCarRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCarCount) + strplus;
                            if (searchCountWork.AcceptOdrCarCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �݌ɒ����f�[�^
                        case "StockAdjustRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustCount) + strplus;
                            if (searchCountWork.StockAdjustCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �݌ɒ������׃f�[�^
                        case "StockAdjustDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustDtlCount) + strplus;
                            if (searchCountWork.StockAdjustDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �݌Ɉړ��f�[�^
                        case "StockMoveRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockMoveCount) + strplus;
                            if (searchCountWork.StockMoveCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // ���������}�X�^
                        case "DepositAlwRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.DepositAlwCount) + strplus;
                            if (searchCountWork.DepositAlwCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // ����`�f�[�^
                        case "RcvDraftDataRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.RcvDraftDataCount) + strplus;
                            if (searchCountWork.RcvDraftDataCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // �x����`�f�[�^
                        case "PayDraftDataRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.PayDraftDataCount) + strplus;
                            if (searchCountWork.PayDraftDataCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                    }
                }

                foreach (string errSectionCode in errSectionCodeList)
                {
                    row[errSectionCode] = ERROR_BATU;
                }
                _updateResultDataTable.Rows.Add(row);
            }
        }
        # endregion �� �O���b�h��X�^�C���ݒ菈�� ��

        # region �� �c�[���o�[�N���p�t���O ��
        /// <summary>
        /// �c�[���o�[�N���p�t���O
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �c�[���o�[�N���p�������s���B</br>
        /// <br>            : 10900690-00 2013/3/13�z�M���ً̋}�Ή�</br>
        /// <br>            : Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// </remarks>
        private void ToolbarOn()
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Update"].SharedProps.Enabled = true;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Get"].SharedProps.Enabled = true;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
        }
        # endregion �� �c�[���o�[�N���p�t���O ��

        # region �� �c�[���o�[�߂�p�t���O ��
        /// <summary>
        /// �c�[���o�[�߂�p�t���O
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �c�[���o�[�߂�p�������s���B</br>
        /// <br>            : 10900690-00 2013/3/13�z�M���ً̋}�Ή�</br>
        /// <br>            : Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// </remarks>
        private void ToolbarOff()
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = false;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Update"].SharedProps.Enabled = false;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Get"].SharedProps.Enabled = false;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = false;
        }
        # endregion �� �c�[���o�[�߂�p�t���O ��
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        #endregion  �� Private Method ��
    }
}