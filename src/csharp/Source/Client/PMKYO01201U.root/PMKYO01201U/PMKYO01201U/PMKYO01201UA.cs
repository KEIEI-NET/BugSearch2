//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/16  �C�����e : PVCS�[#172�}�X�^����M�����̒��o�����ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/17  �C�����e : PVCS�[#161 ���o�Ώۃf�[�^�����݂��Ȃ��ꍇ�̃��O�ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �}�X�^����M�����̂`�o�o���b�N�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �C �� ��  2011/07/25  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �C �� ��  2011/08/19  �C�����e : #23817 �f�[�^���M��ʂ�FormatException�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/23  �C�����e : #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/27  �C�����e : #23922 ��M�����őΏۊO�̍��ڂ���M����Ă��܂��܂��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/29  �C�����e : #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/30  �C�����e : #24191 ���M������ �I�������}�X�^�ɂ����`�F�b�N��������ԂɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X��
// �C �� ��  2011/09/05  �C�����e : Redmine #23936����M�֘A�̋��_�K�C�h�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/05  �C�����e : #24047 ���M���s���̑Ώ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/14  �C�����e : #24542 ���_�I���ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : FSI���� �f��
// �C �� ��  2012/07/26  �C�����e : ���o�����敪�ɏ]�ƈ��A���[�U�[�K�C�h(�̔��敪)�A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : ���O
// �� �� ��  2021/04/12  �C�����e : ���Ӑ惁�����̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �}�X�^����M����
    /// </summary>
    /// <remarks>
    /// Note       : �}�X�^����M�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.02<br />
    /// <br>Update Note: 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
    /// </remarks>
    public partial class PMKYO01201UA : Form
    {

        #region �� Const Memebers ��
        private const string PROGRAM_ID = "PMKYO01201UA";
        private const string ALL_SECTIONCODE = "00"; //ADD 2011/07/25
        private const string ERROR_BATU = "�~";
        private static readonly string ctTableName_DataReceiveResult = "DataReceiveResult";
        private const string PROGRAM_NAME = "�}�X�^����M����";
        private const string MST_SECINFOSET = "���_�ݒ�}�X�^";
        private const string MST_SUBSECTION = "����ݒ�}�X�^";
        private const string MST_WAREHOUSE = "�q�ɐݒ�}�X�^";
        private const string MST_EMPLOYEE = "�]�ƈ��ݒ�}�X�^";
        private const string MST_USERGDAREADIVU = "���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j";
        private const string MST_USERGDBUSDIVU = "���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j";
        private const string MST_USERGDCATEU = "���[�U�[�K�C�h�}�X�^�i�Ǝ�j";
        private const string MST_USERGDBUSU = "���[�U�[�K�C�h�}�X�^�i�E��j";
        private const string MST_USERGDGOODSDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDCUSGROUPU = "���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j";
        private const string MST_USERGDBANKU = "���[�U�[�K�C�h�}�X�^�i��s�j";
        private const string MST_USERGDPRIDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDDELIDIVU = "���[�U�[�K�C�h�}�X�^�i�[�i�敪�j";
        private const string MST_USERGDGOODSBIGU = "���[�U�[�K�C�h�}�X�^�i���i�啪�ށj";
        private const string MST_USERGDBUYDIVU = "���[�U�[�K�C�h�}�X�^�i�̔��敪�j";
        private const string MST_USERGDSTOCKDIVOU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j";
        private const string MST_USERGDSTOCKDIVTU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j";
        private const string MST_USERGDRETURNREAU = "���[�U�[�K�C�h�}�X�^�i�ԕi���R�j";
        private const string MST_RATEPROTYMNG = "�|���D��Ǘ��}�X�^";
        private const string MST_RATE = "�|���}�X�^";
        private const string MST_SALESTARGET = "����ڕW�ݒ�}�X�^";
        private const string MST_CUSTOME = "���Ӑ�}�X�^";
        private const string MST_SUPPLIER = "�d����}�X�^";
        private const string MST_JOINPARTSU = "�����}�X�^";
        private const string MST_GOODSSET = "�Z�b�g�}�X�^";
        private const string MST_TBOSEARCHU = "�s�a�n�}�X�^";
        private const string MST_MODELNAMEU = "�Ԏ�}�X�^";
        private const string MST_BLGOODSCDU = "�a�k�R�[�h�}�X�^";
        private const string MST_MAKERU = "���[�J�[�}�X�^";
        private const string MST_GOODSMGROUPU = "���i�����ރ}�X�^";
        private const string MST_BLGROUPU = "�O���[�v�R�[�h�}�X�^";
        private const string MST_BLCODEGUIDE = "BL�R�[�h�K�C�h�}�X�^";
        private const string MST_GOODSU = "���i�}�X�^";
        private const string MST_STOCK = "�݌Ƀ}�X�^";
        private const string MST_PARTSSUBSTU = "��փ}�X�^";
        private const string MST_PARTSPOSCODEU = "���ʃ}�X�^";

        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        private const string FILEID_CUSTOMER = "CustomerRF";
        private const string FILEID_GOODS = "GoodsURF";
        private const string FILEID_STOCK = "StockRF";
        private const string FILEID_SUPPLIER = "SupplierRF";
        private const string FILEID_RATE = "RateRF";
        // --- ADD 2012/07/26 ---------------------------->>>>>
        private const string FILEID_EMPLOYEE = "EmployeeDtlRF";
        private const string FILEID_JOINPARTSU = "JoinPartsURF";
        private const string FILEID_USERGDU = "UserGdBdURF";
        // --- ADD 2012/07/26 ----------------------------<<<<<
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        private const string UI_XML_NAME = "PMKYO01201U_SectionSetting.xml";//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
        #endregion �� Const Memebers ��

        # region �� private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _extractDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _settingButton;
        private Infragistics.Win.UltraWinToolbars.PopupMenuTool _detailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _custDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _suppDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _goodsDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _stockDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rateDetailButton;
        // --- ADD 2012/07/26 --------------------------------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _employeeDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _joinPartsUrateDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _userGdBuyDivUrateDetailButton;
        // --- ADD 2012/07/26 ---------------------------------------------------------<<<<<
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // ���M���f�[�^�e�[�u��
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // ���M�����f�[�^�e�[�u��
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        // ��M���f�[�^�e�[�u��
        private ReceiveInfoDataSet.ReceiveInfoDataTable _receiveInfoDataTable;
        // ��M�����f�[�^�e�[�u��
        private ReceiveConditionDataSet.ReceiveConditionDataTable _receiveConditionDataTable;
        private MstUpdCountAcs _mstUpdCountAcs;
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private DateTime _startTime = new DateTime();
        private ArrayList _secMngSetArrList = new ArrayList();
        private string _baseCode = string.Empty;
        private ArrayList masterNameList = new ArrayList();
        private ArrayList masterDivList = new ArrayList();
        private ArrayList masterDtlDivList = new ArrayList();
        private ArrayList baseCodeNameList = new ArrayList();
        // �f�t�H���g�s�̊O�ϐݒ�
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();
        // �I�����̍s�O�ϐݒ�
        private readonly Color _selBackColor = Color.FromArgb(251, 230, 148);
        private readonly Color _selBackColor2 = Color.FromArgb(238, 149, 21);
        private int _connectPointDiv = 0;
        private ReceiveInfoDataSet _receiveDataSet;
        private DataTable _receiveInfoTable;
        private Control _prevControl = null;
        private DateTime _preDataTime = DateTime.MinValue;
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _preSectionCode;
        private ArrayList sendDestSecList = new ArrayList();
        private ArrayList selectMstNameList = new ArrayList();
        private ArrayList selectMstDivList = new ArrayList();
        private ArrayList selectMstDtlDivList = new ArrayList();
        private ArrayList selectbaseCodeNameList = new ArrayList();
        private ArrayList _sndRcvHisList = new ArrayList();
        private ArrayList _sndRcvEtrList = new ArrayList();
        private ContextMenu _contextMenu;
        private APSupplierProcParamWork _supplierProcParam; //�d����}�X�^���o����
        private APCustomerProcParamWork _customerProcParam; //���Ӑ�}�X�^���o����
        private APGoodsProcParamWork _goodsProcParam; //���i�}�X�^���o����
        private APStockProcParamWork _stockProcParam; //�݌Ƀ}�X�^���o����
        private APRateProcParamWork _rateProcParam; //�|���}�X�^���o����
        // --- ADD 2012/07/26 ------------------------->>>>>
        private APEmployeeProcParamWork _employeeProcParam; // �]�ƈ��ݒ�}�X�^���o����
        private APJoinPartsUProcParamWork _joinPartsUProcParam; // �����}�X�^���o����
        private APUserGdBuyDivUProcParamWork _userGdBuyDivUProcParam; // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j���o����
        // --- ADD 2012/07/26 -------------------------<<<<<
        private Dictionary<string, SndRcvEtrWork> sndRcvEtrDic = new Dictionary<string, SndRcvEtrWork>();
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        private DataSet _uiDataSet;//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
        private string _initSecCode = "00";//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���

        # endregion �� private field ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this._extractDetailButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;
            this._settingButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS2;
            this._detailButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion �� �{�^�������ݒ菈�� ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKYO01201UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this._extractDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ExtractDetail"];
            this._settingButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Setting"];
            this._detailButton = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Detail"];
            this._custDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Customer"];
            this._suppDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Supplier"];
            this._goodsDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Goods"];
            this._stockDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Stock"];
            this._rateDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Rate"];
            // --- ADD 2012/07/26 ------------------------------------------------------------------------------------------------------------------------>>>>>
            this._employeeDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Employee"];
            this._joinPartsUrateDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_JoinPartsU"];
            this._userGdBuyDivUrateDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_UserGdBuyDivU"];
            // --- ADD 2012/07/26 ------------------------------------------------------------------------------------------------------------------------<<<<<
            this._preSectionCode = string.Empty;
            _supplierProcParam = new APSupplierProcParamWork();
            _customerProcParam = new APCustomerProcParamWork();
            _goodsProcParam = new APGoodsProcParamWork();
            _stockProcParam = new APStockProcParamWork();
            _rateProcParam = new APRateProcParamWork();
            // --- ADD 2012/07/26 ------------------------->>>>>
            _employeeProcParam = new APEmployeeProcParamWork();
            _joinPartsUProcParam = new APJoinPartsUProcParamWork();
            _userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
            // --- ADD 2012/07/26 -------------------------<<<<<
            this.SectionGuide_Button.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._mstUpdCountAcs = MstUpdCountAcs.GetInstance();
            this._updateResultDataTable = this._mstUpdCountAcs.UpdateResultDataTable;
            this._extractionConditionDataTable = this._mstUpdCountAcs.ExtractionConditionDataTable;
            this._receiveInfoDataTable = this._mstUpdCountAcs.ReceiveInfoDataTable;
            this._receiveConditionDataTable = this._mstUpdCountAcs.ReceiveConditionDataTable;
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            if (_receiveDataSet == null)
            {
                // �X�V�e�[�u���ݒ�
                _receiveDataSet = new ReceiveInfoDataSet();
                _receiveDataSet.Tables.Add(new DataTable(ctTableName_DataReceiveResult));
                this._receiveInfoTable = _receiveDataSet.Tables[ctTableName_DataReceiveResult];
            }


            // ����M�敪
            this.tce_SendAndReceKubun.SelectedIndex = 0;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //���o�����敪
            this.tce_ExtractCondDiv.SelectedIndex = 0;
            //ADD 2011/09/14 sundx #24542 ���_�I���ɂ���--------------------------------->>>>>
            InitSecCode();
            _initSecCode = this.tEdit_SectionCode.DataText.PadLeft(2, '0');
            //ADD 2011/09/14 sundx #24542 ���_�I���ɂ���---------------------------------<<<<<
            //���M�拒�_
            if (this.Condition_Grid.Rows.Count > 0)
            {
				this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            }

            _contextMenu = this.BCondition_Grid.ContextMenu;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

			//-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			//if (0 != this.Condition_Grid.Rows.Count)
			//{
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
			//}
			//-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this.timer_InitialSetFocus.Enabled = true;
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
                    secCode = _uiDataSet.Tables[0].Rows[0][0].ToString();
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
                    if (_uiDataSet.Tables.Count == 0)
                    {
                        DataTable dt = new DataTable("Section");
                        DataColumn col = new DataColumn("SecCode", typeof(string));
                        dt.Columns.Add(col);
                        _uiDataSet.Tables.Add(dt);
                    }
                    _uiDataSet.Tables[0].Clear();
                    DataRow row = _uiDataSet.Tables[0].NewRow();
                    row[0] = secCode;
                    _uiDataSet.Tables[0].Rows.Add(row);
                    _uiDataSet.WriteXml(fileName);
                }
            }
            catch
            {
                status = 1000;
            }
            return status;
        }
        /// <summary>
        /// ���_������
        /// </summary>
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
                    this.tEdit_SectionCode.DataText = this._preSectionCode;
                }
                else
                {
                    this.tEdit_SectionCode.DataText = secCode.Trim();
                    this.tEdit_SectionName.DataText = GetSectionName(secCode.Trim());
                    this._preSectionCode = secCode.Trim();
                    ResetGridCol();
                }                
            }
            finally
            { }
        }
        # endregion �� ��ʐݒ�t�@�C������ ��

        # region �� ��ʏ�������C�x���g ��
        /// <summary>
        /// ��ʏ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ�������C�x���g�����������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.30</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;

            this.tce_SendAndReceKubun.Select();
            this.tce_SendAndReceKubun.Focus();
            // �ڑ���`�F�b�N����
            string errMsg = null;
            if (!_mstUpdCountAcs.CheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                return;
            }
        }
        #endregion

        # region �� �}�X�^���M���b�\�h�֘A ��

        # region �� ���M�O���b�h�񏉊��ݒ菈�� ��
        /// <summary>
        /// ���M���O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M���O���b�h�����ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialAccSettingGridCol()
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
            //this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 15; //DEL 2011/07/25
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 30;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Width = 40;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Width = 350;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            //this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Width = 300; //DEL 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Width = 100;


            // �Œ��ݒ�
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/07/25
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
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].CellClickAction = CellClickAction.CellSelect; //ADD 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; //ADD 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // Style�ݒ�
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox; //ADD 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //Hidden��ݒ�
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Hidden = true;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        }

        /// <summary>
        /// ���M�����O���b�h�񏉊��ݒ菈��
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
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 130;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 60;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 50;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 60;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 50;
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Width = 30;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 200;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 120;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<


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

            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/07/25
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/07/25
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // CellAppearance�ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // ���͋��ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;//ADD 2011/07/25
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // Style�ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;//ADD 2011/07/25
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //Hidden��ݒ�
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Hidden = true;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Hidden = true;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.InitBeginningTimeColumn.ColumnName].Hidden = true;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        }

        # endregion �� ���M�O���b�h�񏉊��ݒ菈�� ��

        /// <summary>
        /// ���M�V���N���s���t�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M�V���N���s���t�ݒ菈���ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchSyncExecDate()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            //int status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList);//DEL 2011/07/25
            int status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList, 1);//ADD 2011/07/25
        }

        /// <summary>
        /// ���M�}�X�^���̐ݒ�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M�}�X�^���̐ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchMasterName()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }
            // ���M�}�X�^���̂��擾����B
            int status = _mstUpdCountAcs.LoadMstName(_enterpriseCode, out masterNameList);
        }

        /// <summary>
        /// ���M�}�X�^�敪�ݒ�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M�}�X�^�敪�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchMasterDoDiv()
        {
            int status = _mstUpdCountAcs.LoadMstDoDiv(_enterpriseCode, out masterDivList);
        }

        /// <summary>
        /// ���M���O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M���O���b�h�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialAccDataGridCol()
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //rowNo = rowNo + 1;
                //row = _updateResultDataTable.NewUpdateResultRow();
                //row.RowNo = rowNo;
                //row.ExtractionData = work.MasterName;
                //row.ExtractionCount = string.Empty;
                //_updateResultDataTable.Rows.Add(row);
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //���M�拒�_���X�g���쐬����
                if (ALL_SECTIONCODE.Equals(this.tEdit_SectionCode.DataText.Trim()))
                {
                    this.sendDestSecList = baseCodeNameList;
                }
                else if (string.Empty.Equals(this.tEdit_SectionCode.DataText.Trim()))
                {
                    this.sendDestSecList = new ArrayList();
                }
                else
                {
                    this.sendDestSecList = new ArrayList();
                    for (int k = 0; k < baseCodeNameList.Count; k++)
                    {
                        if (((BaseCodeNameWork)baseCodeNameList[k]).SectionCode.Trim().Equals(this.tEdit_SectionCode.DataText.Trim()))
                        {
                            this.sendDestSecList.Add((BaseCodeNameWork)baseCodeNameList[k]);
                            break;
                        }
                    }
                }
                //���_�Ǘ��ݒ�}�X�^�ɓo�^�������M�拒�_�𑗐M���O���b�h�ɒǉ�
                int colCnt = _updateResultDataTable.Columns.Count;
                for (int j = colCnt - 1; j > this.Acc_Grid.DisplayLayout.Bands[0].Columns[_updateResultDataTable.ExtractionCountColumn.ColumnName].Index; j--)
                {
                    _updateResultDataTable.Columns.RemoveAt(j);
                }
                for (int i = 0; i < this.sendDestSecList.Count; i++)
                {
                    BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.sendDestSecList[i];
                    if (!_updateResultDataTable.Columns.Contains(baseCodeNameWork.SectionCode.Trim()))
                    {
                        _updateResultDataTable.Columns.Add(baseCodeNameWork.SectionCode.Trim());
                        this.Acc_Grid.DisplayLayout.Bands[0].Columns[baseCodeNameWork.SectionCode.Trim()].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        _updateResultDataTable.Columns[baseCodeNameWork.SectionCode.Trim()].Caption = baseCodeNameWork.SectionGuideNm;
                    }
                }
                //�����̏ꍇ�A
                if (tce_ExtractCondDiv.SelectedIndex == 0)
                {
                    rowNo = rowNo + 1;
                    row = _updateResultDataTable.NewUpdateResultRow();
                    row.RowNo = rowNo;
                    row.ExtractionData = work.MasterName;
                    row.ExtractionCount = string.Empty;
                    for (int i = 0; i < this.sendDestSecList.Count; i++)
                    {
                        BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.sendDestSecList[i];
                        row[baseCodeNameWork.SectionCode.Trim()] = string.Empty;
                    }
                    _updateResultDataTable.Rows.Add(row);

                    this._extractDetailButton.SharedProps.Enabled = false;
                }
                //�����̏ꍇ�A
                else
                {
                    // --- DEL 2012/07/26 ------------------>>>>>
                    //if (MST_STOCK.Equals(work.MasterName) || MST_GOODSU.Equals(work.MasterName) || MST_CUSTOME.Equals(work.MasterName)
                    //    || MST_SUPPLIER.Equals(work.MasterName) || MST_RATE.Equals(work.MasterName))
                    // --- DEL 2012/07/26 ------------------<<<<<
                    // --- ADD 2012/07/26 ------------------>>>>>
                    if (MST_STOCK.Equals(work.MasterName)
                     || MST_GOODSU.Equals(work.MasterName)
                     || MST_CUSTOME.Equals(work.MasterName)
                     || MST_SUPPLIER.Equals(work.MasterName)
                     || MST_RATE.Equals(work.MasterName)
                     || MST_EMPLOYEE.Equals(work.MasterName)
                     || MST_JOINPARTSU.Equals(work.MasterName)
                     || MST_USERGDBUYDIVU.Equals(work.MasterName))
                    // --- ADD 2012/07/26 ------------------<<<<<
                    {
                        rowNo = rowNo + 1;
                        row = _updateResultDataTable.NewUpdateResultRow();
                        row.RowNo = rowNo;
                        row.ExtractionData = work.MasterName;
                        //ADD 2011/08/30 #24191 ���M�������I�������}�X�^�ɂ����`�F�b�N��������ԂɏC��---->>>>>
                        if (selectMstNameList.Count > 0)
                        {
                            row.SendDest = false;
                            foreach (SecMngSndRcvWork selectWork in selectMstNameList)
                            {
                                if (work.MasterName.Equals(selectWork.MasterName))
                                {
                                    row.SendDest = true;
                                    break;
                                }
                            }
                        }
                        //ADD 2011/08/30 #24191 ���M�������I�������}�X�^�ɂ����`�F�b�N��������ԂɏC��----<<<<<
                        row.ExtractionCount = string.Empty;
                        for (int i = 0; i < this.sendDestSecList.Count; i++)
                        {
                            BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.sendDestSecList[i];
                            row[baseCodeNameWork.SectionCode.Trim()] = string.Empty;
                        }
                        _updateResultDataTable.Rows.Add(row);

                        this._extractDetailButton.SharedProps.Enabled = true;
                    }
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
        }

        /// <summary>
        /// ���M���O���b�h�G���[�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M���O���b�h�G���[�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchResultErrGridCol()
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = rowNo;
                row.ExtractionData = work.MasterName;
                row.ExtractionCount = ERROR_BATU;
                _updateResultDataTable.Rows.Add(row);
            }
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
        #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
        ///// <summary>
        ///// ���M���O���b�h�v���ݒ菈��
        ///// </summary>
        ///// <remarks>		
        ///// <br>Note		: ���M���O���b�h�v���ݒ菈�����s���B</br>
        ///// <br>Programmer	: 杍^</br>	
        ///// <br>Date		: 2009.04.02</br>
        ///// </remarks>
        //private void SearchResultDataGridCol(MstSearchCountWorkWork searchCountWork)
        //{
        //    UpdateResultDataSet.UpdateResultRow row = null;
        //    int rowNo = 0;
        //    foreach (SecMngSndRcvWork work in masterNameList)
        //    {
        //        rowNo = rowNo + 1;
        //        row = _updateResultDataTable.NewUpdateResultRow();
        //        row.RowNo = rowNo;
        //        row.ExtractionData = work.MasterName;
        //        // ���_�ݒ�}�X�^
        //        if (MST_SECINFOSET.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.SecInfoSetCount);
        //        }
        //        // ����ݒ�}�X�^
        //        else if (MST_SUBSECTION.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.SubSectionCount);
        //        }
        //        // �q�ɐݒ�}�X�^
        //        else if (MST_WAREHOUSE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.WarehouseCount);
        //        }
        //        // �]�ƈ��ݒ�}�X�^
        //        else if (MST_EMPLOYEE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
        //        else if (MST_USERGDAREADIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdAreaDivUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
        //        else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBusDivUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
        //        else if (MST_USERGDCATEU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdCateUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�E��j
        //        else if (MST_USERGDBUSU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBusUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
        //        else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
        //        else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i��s�j
        //        else if (MST_USERGDBANKU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBankUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
        //        else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdPriDivUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
        //        else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdDeliDivUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
        //        else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
        //        else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBuyDivUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
        //        else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdStockDivOUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
        //        else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdStockDivTUCount);
        //        }
        //        // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
        //        else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdReturnReaUCount);
        //        }
        //        // �|���D��Ǘ��}�X�^
        //        else if (MST_RATEPROTYMNG.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.RateProtyMngCount);
        //        }
        //        // �|���}�X�^
        //        else if (MST_RATE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.RateCount);
        //        }
        //        // ����ڕW�ݒ�}�X�^
        //        else if (MST_SALESTARGET.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);
        //        }
        //        // ���Ӑ�}�X�^
        //        else if (MST_CUSTOME.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
        //                + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);
        //        }
        //        // �d����}�X�^
        //        else if (MST_SUPPLIER.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.SupplierCount);
        //        }
        //        // �����}�X�^
        //        else if (MST_JOINPARTSU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.JoinPartsUCount);
        //        }
        //        // �Z�b�g�}�X�^
        //        else if (MST_GOODSSET.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.GoodsSetCount);
        //        }
        //        // �s�a�n�}�X�^
        //        else if (MST_TBOSEARCHU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.TBOSearchUCount);
        //        }
        //        // �Ԏ�}�X�^
        //        else if (MST_MODELNAMEU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.ModelNameUCount);
        //        }
        //        // �a�k�R�[�h�}�X�^
        //        else if (MST_BLGOODSCDU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.BLGoodsCdUCount);
        //        }
        //        // ���[�J�[�}�X�^
        //        else if (MST_MAKERU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.MakerUCount);
        //        }
        //        // ���i�����ރ}�X�^
        //        else if (MST_GOODSMGROUPU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.GoodsMGroupUCount);
        //        }
        //        // �O���[�v�R�[�h�}�X�^
        //        else if (MST_BLGROUPU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.BLGroupUCount);
        //        }
        //        // BL�R�[�h�K�C�h�}�X�^
        //        else if (MST_BLCODEGUIDE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.BLCodeGuideCount);
        //        }
        //        // ���i�}�X�^
        //        else if (MST_GOODSU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
        //                + searchCountWork.IsolIslandPrcCount);
        //        }
        //        // �݌Ƀ}�X�^
        //        else if (MST_STOCK.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.StockCount);
        //        }
        //        // ��փ}�X�^
        //        else if (MST_PARTSSUBSTU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.PartsSubstUCount);
        //        }
        //        // ���ʃ}�X�^
        //        else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.PartsPosCodeUCount);
        //        }
        //        _updateResultDataTable.Rows.Add(row);
        //    }
        //}
        #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        /// <summary>
        /// ���M���O���b�h�v���ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M���O���b�h�v���ݒ菈�����s���B</br>
        /// <br>Programmer	: �g���Y</br>	
        /// <br>Date		: 2011/07/25</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        private void SearchResultDataGridCol(Dictionary<string, MstSearchCountWorkWork> searchCntDic, ArrayList errSectionCodeList)
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                if ((this.tce_ExtractCondDiv.SelectedIndex == 0) ||
                    (this.tce_ExtractCondDiv.SelectedIndex == 1 &&
                    // --- DEL 2012/07/26 ------------------>>>>>
                    //(MST_STOCK.Equals(work.MasterName) || MST_GOODSU.Equals(work.MasterName) || MST_CUSTOME.Equals(work.MasterName)
                    //    || MST_SUPPLIER.Equals(work.MasterName) || MST_RATE.Equals(work.MasterName))))
                    // --- DEL 2012/07/26 ------------------<<<<<
                    // --- ADD 2012/07/26 ------------------>>>>>
                     (MST_STOCK.Equals(work.MasterName)
                     || MST_GOODSU.Equals(work.MasterName)
                     || MST_CUSTOME.Equals(work.MasterName)
                     || MST_SUPPLIER.Equals(work.MasterName)
                     || MST_RATE.Equals(work.MasterName)
                     || MST_EMPLOYEE.Equals(work.MasterName)
                     || MST_JOINPARTSU.Equals(work.MasterName)
                     || MST_USERGDBUYDIVU.Equals(work.MasterName))))
                    // --- ADD 2012/07/26 ------------------<<<<<
                {
                    rowNo = rowNo + 1;
                    row = _updateResultDataTable.NewUpdateResultRow();
                    row.RowNo = rowNo;
                    row.ExtractionData = work.MasterName;
                    row.SendDest = false;
                    foreach (SecMngSndRcvWork selectWork in selectMstNameList)
                    {
                        if (work.MasterName.Equals(selectWork.MasterName))
                        {
                            row.SendDest = true;
                            foreach (string sectionCode in searchCntDic.Keys)
                            {
                                MstSearchCountWorkWork searchCountWork = searchCntDic[sectionCode];
                                // ���_�ݒ�}�X�^
                                if (MST_SECINFOSET.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.SecInfoSetCount);
                                }
                                // ����ݒ�}�X�^
                                else if (MST_SUBSECTION.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.SubSectionCount);
                                }
                                // �q�ɐݒ�}�X�^
                                else if (MST_WAREHOUSE.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.WarehouseCount);
                                }
                                // �]�ƈ��ݒ�}�X�^
                                else if (MST_EMPLOYEE.Equals(work.MasterName))
                                {
                                    // --- DEL 2012/07/26 ---------------------------->>>>>
                                    //row[sectionCode] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
                                    // --- DEL 2012/07/26 ----------------------------<<<<<
                                    // --- ADD 2012/07/26 ---------------------------->>>>>
                                    // �����̏ꍇ
                                    if (tce_ExtractCondDiv.SelectedIndex == 0)
                                    {
                                        row[sectionCode] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
                                    }
                                    else
                                    {
                                        row[sectionCode] = this.IntConvert(searchCountWork.EmployeeCount);
                                    }
                                    // --- ADD 2012/07/26 ----------------------------<<<<<
                                }
                                // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                                else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdAreaDivUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                                else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBusDivUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                                else if (MST_USERGDCATEU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdCateUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�E��j
                                else if (MST_USERGDBUSU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBusUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                                else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                                else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i��s�j
                                else if (MST_USERGDBANKU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBankUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                                else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdPriDivUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                                else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdDeliDivUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                                else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                                else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBuyDivUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                                else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdStockDivOUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                                else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdStockDivTUCount);
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                                else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdReturnReaUCount);
                                }
                                // �|���D��Ǘ��}�X�^
                                else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.RateProtyMngCount);
                                }
                                // �|���}�X�^
                                else if (MST_RATE.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.RateCount);
                                }
                                // ����ڕW�ݒ�}�X�^
                                else if (MST_SALESTARGET.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);
                                }
                                // ���Ӑ�}�X�^
                                else if (MST_CUSTOME.Equals(work.MasterName))
                                {
                                    // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                                    //row[sectionCode] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                    //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);
                                    row[sectionCode] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                        + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount);
                                    // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                                }
                                // �d����}�X�^
                                else if (MST_SUPPLIER.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.SupplierCount);
                                }
                                // �����}�X�^
                                else if (MST_JOINPARTSU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.JoinPartsUCount);
                                }
                                // �Z�b�g�}�X�^
                                else if (MST_GOODSSET.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.GoodsSetCount);
                                }
                                // �s�a�n�}�X�^
                                else if (MST_TBOSEARCHU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.TBOSearchUCount);
                                }
                                // �Ԏ�}�X�^
                                else if (MST_MODELNAMEU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.ModelNameUCount);
                                }
                                // �a�k�R�[�h�}�X�^
                                else if (MST_BLGOODSCDU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.BLGoodsCdUCount);
                                }
                                // ���[�J�[�}�X�^
                                else if (MST_MAKERU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.MakerUCount);
                                }
                                // ���i�����ރ}�X�^
                                else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.GoodsMGroupUCount);
                                }
                                // �O���[�v�R�[�h�}�X�^
                                else if (MST_BLGROUPU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.BLGroupUCount);
                                }
                                // BL�R�[�h�K�C�h�}�X�^
                                else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.BLCodeGuideCount);
                                }
                                // ���i�}�X�^
                                else if (MST_GOODSU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                        + searchCountWork.IsolIslandPrcCount);
                                }
                                // �݌Ƀ}�X�^
                                else if (MST_STOCK.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.StockCount);
                                }
                                // ��փ}�X�^
                                else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.PartsSubstUCount);
                                }
                                // ���ʃ}�X�^
                                else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.PartsPosCodeUCount);
                                }
                            }
                            foreach (string errSectionCode in errSectionCodeList)
                            {
                                row[errSectionCode] = ERROR_BATU;
                            }
                            break;
                        }
                    }
                    _updateResultDataTable.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// �X�V������ő��M�����^�u���Đݒ肷��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M�����̎��Ԑݒ菈�����s���B</br>
        /// <br>Programmer	: �g���Y</br>	
        /// <br>Date		: 2011/07/25</br>
        /// </remarks>
        private void SearchCondtionGridCol()
        {
            this.SearchSyncExecDate();
            if (!ALL_SECTIONCODE.Equals(tEdit_SectionCode.DataText))
            {
                //�u00:�S�Ёv�ł͂Ȃ��ꍇ�A���͂������M�拒�_������ۗ�
                ArrayList indexList = new ArrayList();
                for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
                {
                    ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
                    if (!row.BaseCode.Trim().Equals(tEdit_SectionCode.DataText.Trim()))
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
                for (int j = 0; j < selectbaseCodeNameList.Count; j++)
                {
                    BaseCodeNameWork selectbaseCodeNamework = (BaseCodeNameWork)selectbaseCodeNameList[j];
                    if (row.BaseCode.Trim().Equals(selectbaseCodeNamework.SectionCode.Trim()))
                    {
                        row.SendDestCond = true;
                        break;
                    }
                }
                if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                {
                    if (row.SendDestCond == false)
                    {
                        row.BeginningDate = DateTime.MinValue;
                        row.BeginningTime = string.Empty;
                        row.EndDate = DateTime.MinValue;
                        row.EndTime = string.Empty;
                        row.InitBeginningDate = DateTime.MinValue;
                        row.InitBeginningTime = string.Empty;
                        //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--------------------------------------->>>>>
                        Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].SetValue(DBNull.Value, true);
                        Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].SetValue(DBNull.Value, true);
                        Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Selected = false;
                        //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---------------------------------------<<<<<
                    }
                }
            }
            
        }
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        /// <summary>
        /// ���M���O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M���O���b�h�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void UpdateResultAccDataGridCol()
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = rowNo;
                row.ExtractionData = work.MasterName;
                row.ExtractionCount = string.Empty;
                _updateResultDataTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// �}�X�^���M����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �f�[�^���M�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void UpdateProcess()
        {
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���M������";
            form.Message = "���M�������ł�";

            #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            //string beginningDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString();
            //string beginningTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString();

            //string endingDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString();
            //string endingTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString();

            //string baseCode = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();
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
            //MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            //// �f�[�^���M����
            //int status = _mstUpdCountAcs.SendProc(_connectPointDiv, masterDivList, masterNameList, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginEmplooyCode, baseCode, out searchCountWork, out isEmpty);
            #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            form.Show();
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            Dictionary<string, MstSearchCountWorkWork> searchCntDic = new Dictionary<string, MstSearchCountWorkWork>();
            int status = 0;
            bool isEmpty = true;
            string pmEnterpriseCode = string.Empty;
            string beginningDate;
            string beginningTime;
            string endingDate;
            string endingTime;
            string initBeginningDate;
            string initBeginningTime;
            string baseCode;

            //-----ADD 2011.08.19 #23817----->>>>>
            DateTime dtBeginDate = DateTime.MinValue;
            DateTime dtEndDate = DateTime.MinValue;
            DateTime dtInitBeginDate = DateTime.MinValue;
            //-----ADD 2011.08.19 #23817-----<<<<<
            DateTime beginDateTime = DateTime.MinValue;
            DateTime endDateTime = DateTime.MinValue;
            DateTime initBeginDateTime = DateTime.MinValue;
            ArrayList errSectionCodeList = new ArrayList();
            ArrayList stockMaxList = new ArrayList();
            ArrayList goodsMaxList = new ArrayList();
            int errorStatus = -1;//ADD 2011/09/05 #24047
            string errMsg = "";//ADD 2011/09/05 #24047
            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //-----ADD 2011.08.19 #23817----->>>>>
                if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value != null
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString()))
                {
                    dtBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value;
                }
                if(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value != null 
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString()))
                {
                    dtEndDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value;
                }
                //-----ADD 2011.08.19 #23817-----<<<<<
                beginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString();
                beginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString();

                endingDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString();
                endingTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString();

                //-----ADD 2011.08.19 #23817----->>>>>
                dtInitBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value;
                //-----ADD 2011.08.19 #23817-----<<<<<
                initBeginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value.ToString();
                initBeginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningTimeColumn.ColumnName].Value.ToString();

                baseCode = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();
                // �J�n���t
                if (!string.IsNullOrEmpty(beginningDate) && !string.IsNullOrEmpty(beginningTime))
                {
                    //-----DEL 2011.08.19 #23817----->>>>>
                    //beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
                    //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                    //    int.Parse(beginningTime.Substring(6, 2)));
                    //-----DEL 2011.08.19 #23817-----<<<<<
                    //-----ADD 2011.08.19 #23817----->>>>>
                    beginDateTime = new DateTime(dtBeginDate.Year, dtBeginDate.Month, dtBeginDate.Day,
                        int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                        int.Parse(beginningTime.Substring(6, 2)));
                    //-----ADD 2011.08.19 #23817-----<<<<<
                }
                else
                {
                    beginDateTime = DateTime.MinValue;
                }
                // �I�����t
                if (!string.IsNullOrEmpty(endingDate) && !string.IsNullOrEmpty(endingTime))
                {
                    //-----DEL 2011.08.19 #23817----->>>>>
                    //endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
                    //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                    //    int.Parse(endingTime.Substring(6, 2)));
                    //-----DEL 2011.08.19 #23817-----<<<<<
                    //-----ADD 2011.08.19 #23817----->>>>>
                    endDateTime = new DateTime(dtEndDate.Year, dtEndDate.Month, dtEndDate.Day,
                        int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                        int.Parse(endingTime.Substring(6, 2)));
                    //-----ADD 2011.08.19 #23817-----<<<<<
                }
                else
                {
                    endDateTime = DateTime.MinValue;
                }

                // �����J�n���t
                if (!string.IsNullOrEmpty(initBeginningDate) && !string.IsNullOrEmpty(initBeginningTime))
                {
                    //-----DEL 2011.08.19 #23817----->>>>>
                    //initBeginDateTime = new DateTime(int.Parse(initBeginningDate.Substring(0, 4)), int.Parse(initBeginningDate.Substring(5, 2)),
                    //    int.Parse(initBeginningDate.Substring(8, 2)), int.Parse(initBeginningTime.Substring(0, 2)), int.Parse(initBeginningTime.Substring(3, 2)),
                    //    int.Parse(initBeginningTime.Substring(6, 2)));
                    //-----DEL 2011.08.19 #23817-----<<<<<
                    //-----ADD 2011.08.19 #23817----->>>>>
                    initBeginDateTime = new DateTime(dtInitBeginDate.Year, dtInitBeginDate.Month, dtInitBeginDate.Day,
                        int.Parse(initBeginningTime.Substring(0, 2)), int.Parse(initBeginningTime.Substring(3, 2)),
                        int.Parse(initBeginningTime.Substring(6, 2)));
                    //-----ADD 2011.08.19 #23817-----<<<<<

                }

                if (beginDateTime.Year == initBeginDateTime.Year && beginDateTime.Month == initBeginDateTime.Month && beginDateTime.Day == initBeginDateTime.Day
                    && beginDateTime.Hour == initBeginDateTime.Hour && beginDateTime.Minute == initBeginDateTime.Minute && beginDateTime.Second == initBeginDateTime.Second)
                {
                    //beginDateTime = initBeginDateTime;//DEL 2011/08/27 #23922 ��M�����őΏۊO�̍��ڂ���M����Ă��܂��܂��B
                    beginDateTime = dtInitBeginDate;//ADD 2011/08/27 #23922 ��M�����őΏۊO�̍��ڂ���M����Ă��܂��܂��B
                }

                long beginDtLong = beginDateTime.Ticks;
                long endDtLong = endDateTime.Ticks;
                bool b_Empty = true;
                baseCode = baseCode.Trim();
                MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
                {
                    //�`�F�b�N����Ȃ����M�拒�_�֑��M���Ȃ�
                    continue;
                }
                DateTime _initBegTime = ((ExtractionConditionDataSet.ExtractionConditionRow)this._extractionConditionDataTable.Rows[i]).InitBeginningDate;
                //�}�X�^���o�����p�����[�^���X�g���쐬
                ArrayList paramList = new ArrayList();
                foreach (SecMngSndRcvWork work in selectMstNameList)
                {
                    if (MST_RATE.Equals(work.MasterName))
                    {
                        _rateProcParam.UpdateDateTimeBegin = beginDtLong;
                        _rateProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_rateProcParam);
                    }
                    else if (MST_STOCK.Equals(work.MasterName))
                    {
                        _stockProcParam.UpdateDateTimeBegin = beginDtLong;
                        _stockProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_stockProcParam);
                    }
                    else if (MST_CUSTOME.Equals(work.MasterName))
                    {
                        _customerProcParam.UpdateDateTimeBegin = beginDtLong;
                        _customerProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_customerProcParam);
                    }
                    else if (MST_SUPPLIER.Equals(work.MasterName))
                    {
                        _supplierProcParam.UpdateDateTimeBegin = beginDtLong;
                        _supplierProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_supplierProcParam);
                    }
                    else if (MST_GOODSU.Equals(work.MasterName))
                    {
                        _goodsProcParam.UpdateDateTimeBegin = beginDtLong;
                        _goodsProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_goodsProcParam);
                    }
                    // --- ADD 2012/07/26 ------------------>>>>>
                    else if (MST_EMPLOYEE.Equals(work.MasterName))
                    {
                        _employeeProcParam.UpdateDateTimeBegin = beginDtLong;
                        _employeeProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_employeeProcParam);
                    }
                    else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                    {
                        _userGdBuyDivUProcParam.UpdateDateTimeBegin = beginDtLong;
                        _userGdBuyDivUProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_userGdBuyDivUProcParam);
                    }
                    else if (MST_JOINPARTSU.Equals(work.MasterName))
                    {
                        _joinPartsUProcParam.UpdateDateTimeBegin = beginDtLong;
                        _joinPartsUProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_joinPartsUProcParam);
                    }
                    // --- ADD 2012/07/26 ------------------<<<<<
                }
                _mstUpdCountAcs.SeachPmCode(_enterpriseCode, baseCode, out pmEnterpriseCode);
                // �f�[�^���M����
                status = _mstUpdCountAcs.SendProc(this.tce_ExtractCondDiv.SelectedIndex, _connectPointDiv, paramList, pmEnterpriseCode, masterDivList, masterNameList, beginDtLong, endDtLong, _initBegTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, out searchCountWork, out b_Empty);
                if (!b_Empty)
                {
                    isEmpty = false;
                }
                // ����0���̏ꍇ�A
                if (b_Empty)
                {
                    searchCntDic.Add(baseCode, searchCountWork);
                }
                // �����G���[�̏ꍇ�A 
                else if (-1 == searchCountWork.ErrorKubun || -2 == searchCountWork.ErrorKubun)
                {
                    errSectionCodeList.Add(baseCode);
                    //ADD 2011/09/05 #24047 --------------->>>>>
                    errorStatus = status;
                    errMsg = "���������Ɏ��s���܂����B";
                    //ADD 2011/09/05 #24047 ---------------<<<<<
                }
                else if (-3 == searchCountWork.ErrorKubun)
                {
                    goodsMaxList.Add(baseCode);
                    continue;
                }
                else if (-4 == searchCountWork.ErrorKubun)
                {
                    stockMaxList.Add(baseCode);
                    continue;
                }
                //ADD 2011/09/05 #24047 --------------->>>>>
                else if (-5 == searchCountWork.ErrorKubun)
                {
                    errSectionCodeList.Add(baseCode);
                    errorStatus = status;
                    errMsg = "�X�V�����Ɏ��s���܂����B";
                }
                //ADD 2011/09/05 #24047 ---------------<<<<<
                else
                {
                    searchCntDic.Add(baseCode, searchCountWork);
                }
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            
            // �_�C�A���O�����
            form.Close();
            this.Cursor = Cursors.Default;
            //�X�V���ʍĐݒ�
            if (isEmpty && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���M���e�[�u���N���A����
                this._updateResultDataTable.Clear();
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                //���M�����e�[�u���N���A
                //DEL 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--->>>>>
                //this._extractionConditionDataTable.Clear();
                //this.SearchCondtionGridCol();
                //DEL 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---<<<<<
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--->>>>>
                if (this.tce_ExtractCondDiv.SelectedIndex != 1)
                {
                    this._extractionConditionDataTable.Clear();
                    this.SearchCondtionGridCol();
                }
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---<<<<<
                
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);
            }
            else
            {
                string errSecCode = "";
                for (int i = 0; i < stockMaxList.Count; i++)
                {
                    errSecCode = errSecCode + "���_[" + stockMaxList[i] + "]�F�݌Ƀ}�X�^�̒��o������20000���𒴂��邽�߁A�������Đݒ肵�Ă��������B\r\n";
                }
                for (int i = 0; i < goodsMaxList.Count; i++)
                {
                    errSecCode = errSecCode + "���_[" + goodsMaxList[i] + "]�F���i�}�X�^�̒��o������20000���𒴂��邽�߁A�������Đݒ肵�Ă��������B\r\n";
                }
                //ADD 2011/09/05 #24047--------------------------------------->>>>>
                if (!string.IsNullOrEmpty(errMsg))
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, errorStatus);
                }                
                //ADD 2011/09/05 #24047---------------------------------------<<<<<
                if (errSecCode != "")
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errSecCode, 0);
                }
                // ���M���e�[�u���N���A����
                this._updateResultDataTable.Clear();
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);

                //���M�����e�[�u���N���A                
                //DEL 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--->>>>>
                //this._extractionConditionDataTable.Clear();
                //this.SearchCondtionGridCol();
                //DEL 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---<<<<<
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--->>>>>
                if (this.tce_ExtractCondDiv.SelectedIndex != 1)
                {
                    this._extractionConditionDataTable.Clear();
                    this.SearchCondtionGridCol();
                }
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---<<<<<
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            }
            #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            //// ����0���̏ꍇ�A
            //if (isEmpty)
            //{

            //    // ���M���e�[�u���N���A����
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultDataGridCol(searchCntDic);

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //    // ���b�Z�[�W��\��
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);

            //}
            //// �����G���[�̏ꍇ�A 
            //else if (-1 == searchCountWork.ErrorKubun)
            //{
            //    // ���M���e�[�u���N���A����
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultErrGridCol();

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //}
            //else if (-2 == searchCountWork.ErrorKubun)
            //{
            //    // ���M���e�[�u���N���A����
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultErrGridCol();

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //    // ���b�Z�[�W��\��
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B", 0);
            //}
            //else
            //{
            //    // ���M���e�[�u���N���A����
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultDataGridCol(searchCntDic);

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //}
            #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
        }


        /// <summary>
        /// ���M�X�V�`�F�b�N����
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

            #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            //// ���t�͈̔̓`�F�b�N�p(�J�n�� > �I���� �� NG)
            //foreach (ExtractionConditionDataSet.ExtractionConditionRow row in this._mstUpdCountAcs.ExtractionConditionDataTable)
            //{
            //    if (row.IsNull(this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            //        || row.IsNull(this._extractionConditionDataTable.BeginningDateColumn.ColumnName)
            //        || row.IsNull(this._extractionConditionDataTable.EndDateColumn.ColumnName)
            //        || row.IsNull(this._extractionConditionDataTable.EndTimeColumn.ColumnName))
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

            //String beginningDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString().Trim();
            //String beginningTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim();
            //String endDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim();
            //String endTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim();

            //// �J�n���t
            //if (beginningDate == string.Empty)
            //{
            //    errMessage = string.Format("���o�J�n���t{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];

            //    status = false;

            //    return status;
            //}
            //// �J�n����
            //if (this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
            //{
            //    errMessage = string.Format("���o�J�n����{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName];
            //    status = false;

            //    return status;
            //}
            //// �I�����t
            //if (this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim() == string.Empty)
            //{
            //    errMessage = string.Format("���o�I�����t{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName];
            //    status = false;

            //    return status;
            //}
            //// �I������
            //if (this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
            //{
            //    errMessage = string.Format("���o�I������{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName];
            //    status = false;

            //    return status;
            //}

            //// ���t�͈̔͂��`�F�b�N(�J�n�� > �I���� �� NG)
            //if (begDateTime > endDateTime)
            //{
            //    errMessage = ct_RangeError;
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
            //    status = false;
            //    return status;
            //}

            //// �X�V��ʂ̊J�n���t�`�F�b�N
            //if (!this.UpdateOverData())
            //{
            //    errMessage = "���M�Ώۋ��_���ݒ肳��Ă��܂���B";
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
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
            //            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
            //            status = false;
            //            return status;
            //        }
            //    }
            //}
            #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            if (string.IsNullOrEmpty(tEdit_SectionCode.DataText))
            {
                errMessage = string.Format("���M��{0}", ct_NoInput);
                tEdit_SectionCode.Focus();
                status = false;

                return status;
            }
            DateTime initbegDateTime = new DateTime();
            selectbaseCodeNameList = new ArrayList();
            ArrayList newSndDestCodeList = new ArrayList();
            _mstUpdCountAcs.ReloadSecMngSetInfo(_enterpriseCode, out newSndDestCodeList);
            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //�`�F�b�N�I�����ꂽ���M�������R�[�h�̓`�F�b�N���s���B
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
                {
                    selectbaseCodeNameList.Add(this.sendDestSecList[i]);
                    //�I�����Ă��鑗�M��R�[�h���폜���ꂽ���ǂ����`�F�b�N
                    if (!newSndDestCodeList.Contains(((BaseCodeNameWork)this.sendDestSecList[i]).SectionCode))
                    {
                        errMessage = string.Format("�폜���ꂽ���M�悪���݂��܂��B");
                        status = false;
                        return status;
                    }
                    //----- ADD 2011.08.19 #23817----->>>>>
                    DateTime dtBeginDate = DateTime.MinValue;
                    if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value != null
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString()))
                    {
                        dtBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value;

                    }
                    DateTime dtEndDate = DateTime.MinValue;
                    if(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value != null 
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString()))
                    {
                        dtEndDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value;
                    }
                    DateTime dtInitBeginDate = DateTime.MinValue;
                    if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value != null
                        && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value.ToString()))
                    {
                        dtInitBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value;

                    }
                    //----- ADD 2011.08.19 #23817-----<<<<<
                    String initbeginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value.ToString().Trim();
                    String initbeginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningTimeColumn.ColumnName].Value.ToString().Trim();
                    String beginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString().Trim();
                    String beginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim();
                    String endDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim();
                    String endTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim();

                    //���o�����敪���������̏ꍇ�A�J�n���t�A�J�n���ԁA�I�����t�A�I�����Ԃ̓��̓`�F�b�N���s��
                    if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                    {
                        // �J�n���t
                        if (beginningDate == string.Empty)
                        {
                            errMessage = string.Format("���o�J�n���t{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }
                        // �J�n����
                        if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            errMessage = string.Format("���o�J�n����{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }
                        // �I�����t
                        if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            errMessage = string.Format("���o�I�����t{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }
                        // �I������
                        if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            errMessage = string.Format("���o�I������{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }

                        //----- DEL 2011.08.19 #23817----->>>>>
                        //int initbeginningDateYear = int.Parse(initbeginningDate.Substring(0, 4));
                        //int initbeginningDateMonth = int.Parse(initbeginningDate.Substring(5, 2));
                        //int initbeginningDateDay = int.Parse(initbeginningDate.Substring(8, 2));
                        //----- DEL 2011.08.19 #23817-----<<<<<
                        //----- ADD 2011.08.19 #23817----->>>>>
                        int initbeginningDateYear = dtInitBeginDate.Year;
                        int initbeginningDateMonth = dtInitBeginDate.Month;
                        int initbeginningDateDay = dtInitBeginDate.Day;
                        //----- ADD 2011.08.19 #23817-----<<<<<
                        int initbeginningTimeHours = int.Parse(initbeginningTime.Substring(0, 2));
                        int initbeginningTimeMinutes = int.Parse(initbeginningTime.Substring(3, 2));
                        int initbeginningTimeSeconds = int.Parse(initbeginningTime.Substring(6, 2));

                        //----- DEL 2011.08.19 #23817----->>>>>
                        //int beginningDateYear = int.Parse(beginningDate.Substring(0, 4));
                        //int beginningDateMonth = int.Parse(beginningDate.Substring(5, 2));
                        //int beginningDateDay = int.Parse(beginningDate.Substring(8, 2));
                        //----- DEL 2011.08.19 #23817-----<<<<<
                        //----- ADD 2011.08.19 #23817----->>>>>
                        int beginningDateYear = dtBeginDate.Year;
                        int beginningDateMonth = dtBeginDate.Month;
                        int beginningDateDay = dtBeginDate.Day;
                        //----- ADD 2011.08.19 #23817-----<<<<<
                        int beginningTimeHours = int.Parse(beginningTime.Substring(0, 2));
                        int beginningTimeMinutes = int.Parse(beginningTime.Substring(3, 2));
                        int beginningTimeSeconds = int.Parse(beginningTime.Substring(6, 2));

                        //----- DEL 2011.08.19 #23817----->>>>>
                        //int endDateYear = int.Parse(endDate.Substring(0, 4));
                        //int endDateMonth = int.Parse(endDate.Substring(5, 2));
                        //int endDateDay = int.Parse(endDate.Substring(8, 2));
                        //----- DEL 2011.08.19 #23817-----<<<<<
                        //----- ADD 2011.08.19 #23817----->>>>>
                        int endDateYear = dtEndDate.Year;
                        int endDateMonth = dtEndDate.Month;
                        int endDateDay = dtEndDate.Day;
                        //----- ADD 2011.08.19 #23817-----<<<<<
                        int endDateHours = int.Parse(endTime.Substring(0, 2));
                        int endDateMinutes = int.Parse(endTime.Substring(3, 2));
                        int endDateSeconds = int.Parse(endTime.Substring(6, 2));

                        //�����J�n��
                        initbegDateTime = new DateTime(initbeginningDateYear, initbeginningDateMonth, initbeginningDateDay,
                           initbeginningTimeHours, initbeginningTimeMinutes, initbeginningTimeSeconds);
                        // �J�n��
                        begDateTime = new DateTime(beginningDateYear, beginningDateMonth, beginningDateDay,
                           beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
                        // �I����
                        endDateTime = new DateTime(endDateYear, endDateMonth, endDateDay,
                            endDateHours, endDateMinutes, endDateSeconds);

                        // ���t�͈̔͂��`�F�b�N(�J�n�� > �I���� �� NG)
                        if (begDateTime > endDateTime)
                        {
                            errMessage = ct_RangeError;
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;
                            return status;
                        }
                        
                        // �X�V��ʂ̊J�n���t�`�F�b�N
                        //if (!this.UpdateOverData())
                        //{
                        //    errMessage = "���M�Ώۋ��_���ݒ肳��Ă��܂���B";
                        //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                        //    status = false;
                        //    return status;
                        //}

                        if (initbegDateTime.Year == begDateTime.Year && initbegDateTime.Month == begDateTime.Month && initbegDateTime.Day == begDateTime.Day
                                && initbegDateTime.Hour == begDateTime.Hour && initbegDateTime.Minute == begDateTime.Minute && initbegDateTime.Second == begDateTime.Second)
                        {
                            status = true;
                        }
                        else
                        {
                            // �V�b�N���ԃ`�F�b�N
                            if (begDateTime < initbegDateTime)
                            {
                                if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
                                {
                                    errMessage = string.Format("���o�J�n���t{0}", ct_BeginTimeError);
                                    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                    status = false;
                                    return status;
                                }
                            }
                        }
                    }
                    //���o�����敪���������̏ꍇ
                    else
                    {
                        ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)this._mstUpdCountAcs.ExtractionConditionDataTable[i];

                        if ((!string.IsNullOrEmpty(beginningDate) && row.BeginningDate != DateTime.MinValue) 
                            || (!string.IsNullOrEmpty(beginningTime)))
                        {
                            //�J�n���t�����͂���Ȃ��ꍇ
                            if (string.IsNullOrEmpty(beginningDate))
                            {
                                errMessage = string.Format("���o�J�n���t{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;
                                return status;
                            }
                            //�J�n���Ԃ����͂���Ȃ��ꍇ
                            if (string.IsNullOrEmpty(beginningTime))
                            {
                                errMessage = string.Format("���o�J�n����{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;

                                return status;
                            }
                        }

                        if ((!string.IsNullOrEmpty(endDate) && row.EndDate != DateTime.MinValue)
                            || !string.IsNullOrEmpty(endTime))
                        {
                            //�I�����t�����͂���Ȃ��ꍇ
                            if (string.IsNullOrEmpty(endDate))
                            {
                                errMessage = string.Format("���o�I�����t{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;
                                return status;
                            }
                            //�I�����Ԃ����͂���Ȃ��ꍇ
                            if (string.IsNullOrEmpty(endTime))
                            {
                                errMessage = string.Format("���o�I������{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;

                                return status;
                            }
                        }

                        //�J�n���t�ƏI�����t�����͂��ꂽ�ꍇ�A�͈̓`�F�b�N���s��
                        if ((!string.IsNullOrEmpty(beginningDate) && row.BeginningDate != DateTime.MinValue)
                            && (!string.IsNullOrEmpty(endDate) && row.EndDate != DateTime.MinValue))
                        {
                            //----- DEL 2011.08.19 #23817----->>>>>
                            //int beginningDateYear = int.Parse(beginningDate.Substring(0, 4));
                            //int beginningDateMonth = int.Parse(beginningDate.Substring(5, 2));
                            //int beginningDateDay = int.Parse(beginningDate.Substring(8, 2));
                            //----- DEL 2011.08.19 #23817-----<<<<<
                            //----- ADD 2011.08.19 #23817----->>>>>
                            int beginningDateYear = dtBeginDate.Year;
                            int beginningDateMonth = dtBeginDate.Month;
                            int beginningDateDay = dtBeginDate.Day;
                            //----- ADD 2011.08.19 #23817-----<<<<<
                            int beginningTimeHours = int.Parse(beginningTime.Substring(0, 2));
                            int beginningTimeMinutes = int.Parse(beginningTime.Substring(3, 2));
                            int beginningTimeSeconds = int.Parse(beginningTime.Substring(6, 2));

                            //----- DEL 2011.08.19 #23817----->>>>>
                            //int endDateYear = int.Parse(endDate.Substring(0, 4));
                            //int endDateMonth = int.Parse(endDate.Substring(5, 2));
                            //int endDateDay = int.Parse(endDate.Substring(8, 2));
                            //----- DEL 2011.08.19 #23817-----<<<<<
                            //----- ADD 2011.08.19 #23817----->>>>>
                            int endDateYear = dtEndDate.Year;
                            int endDateMonth = dtEndDate.Month;
                            int endDateDay = dtEndDate.Day;
                            //----- ADD 2011.08.19 #23817-----<<<<<
                            int endDateHours = int.Parse(endTime.Substring(0, 2));
                            int endDateMinutes = int.Parse(endTime.Substring(3, 2));
                            int endDateSeconds = int.Parse(endTime.Substring(6, 2));

                            // �J�n��
                            begDateTime = new DateTime(beginningDateYear, beginningDateMonth, beginningDateDay,
                               beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
                            // �I����
                            endDateTime = new DateTime(endDateYear, endDateMonth, endDateDay,
                                endDateHours, endDateMinutes, endDateSeconds);

                            // ���t�͈̔͂��`�F�b�N(�J�n�� > �I���� �� NG)
                            if (begDateTime > endDateTime)
                            {
                                errMessage = ct_RangeError;
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                                status = false;
                                return status;
                            }

                            this._customerProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._customerProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._goodsProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._goodsProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._stockProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._stockProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._supplierProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._supplierProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._rateProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._rateProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            this._employeeProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._employeeProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._userGdBuyDivUProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._userGdBuyDivUProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._joinPartsUProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._joinPartsUProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            // --- ADD 2012/07/26 -------------------------<<<<<
                        }
                        else
                        {
                            this._customerProcParam.UpdateDateTimeBegin = 0;
                            this._customerProcParam.UpdateDateTimeEnd = 0;
                            this._goodsProcParam.UpdateDateTimeBegin = 0;
                            this._goodsProcParam.UpdateDateTimeEnd = 0;
                            this._stockProcParam.UpdateDateTimeBegin = 0;
                            this._stockProcParam.UpdateDateTimeEnd = 0;
                            this._supplierProcParam.UpdateDateTimeBegin = 0;
                            this._supplierProcParam.UpdateDateTimeEnd = 0;
                            this._rateProcParam.UpdateDateTimeBegin = 0;
                            this._rateProcParam.UpdateDateTimeEnd = 0;
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            this._employeeProcParam.UpdateDateTimeBegin = 0;
                            this._employeeProcParam.UpdateDateTimeEnd = 0;
                            this._userGdBuyDivUProcParam.UpdateDateTimeBegin = 0;
                            this._userGdBuyDivUProcParam.UpdateDateTimeEnd = 0;
                            this._joinPartsUProcParam.UpdateDateTimeBegin = 0;
                            this._joinPartsUProcParam.UpdateDateTimeEnd = 0;
                            // --- ADD 2012/07/26 -------------------------<<<<<
                        }
                    }
                }
            }
            //���M�悪1�ł��`�F�b�N�I������Ȃ��ꍇ
            if (selectbaseCodeNameList.Count == 0)
            {
                errMessage = "���M�拒�_���I������Ă��܂���B";
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                status = false;
                return status;
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            return status;
        }

        /// <summary>
        /// ���M�X�V���Ԃ̐ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M�X�V���ԏ������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private bool UpdateOverData()
        {
            bool isUpdate = true;
            DateTime startTimeBak = new DateTime();
            isUpdate = _mstUpdCountAcs.SendUpdateProc(_enterpriseCode, baseCodeNameList, out startTimeBak);
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

        #endregion �� �}�X�^���M���b�\�h�֘A ��

        # region �� �}�X�^��M���b�\�h�֘A ��


        /// <summary>
        /// �}�X�^���M�����̓��̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �}�X�^���M�����̓��̓`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            bool status = true;

            string errMessage = "";

            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(ref errMessage))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                status = false;
                return status;
            }

            if (0 == this.Acc_Grid.Rows.Count)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "����M�Ώۃ}�X�^���ݒ肳��Ă��܂���B", 0);

                status = false;
                return status;
            }

            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //�������M�̏ꍇ�A���M�Ώۂ�I���`�F�b�N
            selectMstNameList = new ArrayList();
            for (int i = 0; i < this.Acc_Grid.Rows.Count; i++)
            {
                if ((bool)this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value)
                {
                    foreach(SecMngSndRcvWork work in masterNameList)
                    {
                        if (work.MasterName.Equals(this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Value.ToString()))
                        {
                            selectMstNameList.Add(work);
                        }
                    }
                }
            }
            //���o�����敪���������̏ꍇ�A���M�Ώۂ�1�ł��`�F�b�N�I������Ȃ��ꍇ
            if (this.tce_ExtractCondDiv.SelectedIndex == 1 && selectMstNameList.Count == 0)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M�Ώۂ��I������Ă��܂���B", 0);

                status = false;
                return status;
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // ���M�Ώۃ}�X�^�`�F�b�N����
            //if (!_mstUpdCountAcs.CheckMasterDiv(_enterpriseCode, masterNameList))
            //{
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M�Ώۃ}�X�^�����ɑ��[�����X�V����Ă��܂��B", 0);

            //    status = false;
            //    return status;
            //}

            // �ڑ���`�F�b�N���� 
            if (!_mstUpdCountAcs.CheckConnect(_enterpriseCode, out _connectPointDiv, out errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// �}�X�^��M�����̓��̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �}�X�^��M�����̓��̓`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool ReceUpdateBeforeCheck()
        {
            bool status = true;

            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //string errMessage = "";

            //if (!this.ReceScreenInputCheck(ref errMessage))
            //{

            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

            //    status = false;
            //    return status;
            //}
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            if (0 == this.Bcc_Grid.Rows.Count)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "����M�Ώۃ}�X�^���ݒ肳��Ă��܂���B", 0);

                status = false;
                return status;
            }

            // ���M�Ώۃ}�X�^�`�F�b�N����
            //if (!_mstUpdCountAcs.CheckMasterDiv(_enterpriseCode, masterNameList))
            //{
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M�Ώۃ}�X�^�����ɑ��[�����X�V����Ă��܂��B", 0);

            //    status = false;
            //    return status;
            //}

            // �ڑ���`�F�b�N���� 
            string errMsg = string.Empty;
            if (!_mstUpdCountAcs.CheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// ��M���O���b�h�v���ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M���O���b�h�v���ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void ReceSearchResultDataGridCol(Hashtable countTable)
        {

            DataRow row = null;

            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _receiveInfoTable.NewRow();
                row[_receiveInfoDataTable.RowNoColumn.ColumnName] = rowNo;
                row[_receiveInfoDataTable.MasterNameColumn.ColumnName] = work.MasterName;
                row[_receiveInfoDataTable.DisplayOrderColumn.ColumnName] = work.DisplayOrder; //ADD 2011/07/25
                //for (int i = 0; i < baseCodeNameList.Count; i++)//DEL 2011/07/25
                for (int i = 0; i < _sndRcvHisList.Count; i++)//ADD 2011/07/25
                {
                    //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                    //BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.baseCodeNameList[i];
                    //MstSearchCountWorkWork searchCountWork = (MstSearchCountWorkWork)countTable[baseCodeNameWork.SectionCode];
                    //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._sndRcvHisList[i];
                    string key = sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString();
                    MstSearchCountWorkWork searchCountWork = (MstSearchCountWorkWork)countTable[key];
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    // �X�V�G���[�ƌ����G���[�̏ꍇ�A
                    if (searchCountWork.ErrorKubun == -1 || searchCountWork.ErrorKubun == -2)
                    {
                        // ���_�ݒ�}�X�^
                        if (MST_SECINFOSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ����ݒ�}�X�^
                        else if (MST_SUBSECTION.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �q�ɐݒ�}�X�^
                        else if (MST_WAREHOUSE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �]�ƈ��ݒ�}�X�^
                        else if (MST_EMPLOYEE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                        else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                        else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                        else if (MST_USERGDCATEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�E��j
                        else if (MST_USERGDBUSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                        else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i��s�j
                        else if (MST_USERGDBANKU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                        else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                        else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                        else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                        else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                        else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                        else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �|���D��Ǘ��}�X�^
                        else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �|���}�X�^
                        else if (MST_RATE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ����ڕW�ݒ�}�X�^
                        else if (MST_SALESTARGET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���Ӑ�}�X�^
                        else if (MST_CUSTOME.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �d����}�X�^
                        else if (MST_SUPPLIER.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �����}�X�^
                        else if (MST_JOINPARTSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �Z�b�g�}�X�^
                        else if (MST_GOODSSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �s�a�n�}�X�^
                        else if (MST_TBOSEARCHU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �Ԏ�}�X�^
                        else if (MST_MODELNAMEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �a�k�R�[�h�}�X�^
                        else if (MST_BLGOODSCDU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���[�J�[�}�X�^
                        else if (MST_MAKERU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���i�����ރ}�X�^
                        else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �O���[�v�R�[�h�}�X�^
                        else if (MST_BLGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // BL�R�[�h�K�C�h�}�X�^
                        else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���i�}�X�^
                        else if (MST_GOODSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // �݌Ƀ}�X�^
                        else if (MST_STOCK.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ��փ}�X�^
                        else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ���ʃ}�X�^
                        else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }

                        if (searchCountWork.ErrorKubun == -2)
                        {
                            // ���b�Z�[�W��\��
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B", 0);
                        }
                    }
                    else
                    {
                        // ���_�ݒ�}�X�^
                        if (MST_SECINFOSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.SecInfoSetCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.SecInfoSetCount);//ADD 2011/07/25
                        }
                        // ����ݒ�}�X�^
                        else if (MST_SUBSECTION.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.SubSectionCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.SubSectionCount);//ADD 2011/07/25
                        }
                        // �q�ɐݒ�}�X�^
                        else if (MST_WAREHOUSE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.WarehouseCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.WarehouseCount);//ADD 2011/07/25
                        }
                        // �]�ƈ��ݒ�}�X�^
                        else if (MST_EMPLOYEE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);//DEL 2011/07/25
                            // --- DEL 2012/07/26 ---------------------------->>>>>
                            //row[key] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);//ADD 2011/07/25
                            // --- DEL 2012/07/26 ----------------------------<<<<<
                            // --- ADD 2012/07/26 ---------------------------->>>>>
                            // �����̏ꍇ
                            if (sndRcvHisWork.SndLogExtraCondDiv == 0)
                            {
                                row[key] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
                            }
                            else
                            {
                                row[key] = this.IntConvert(searchCountWork.EmployeeCount);
                            }
                            // --- ADD 2012/07/26 ----------------------------<<<<<
                        }
                        // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                        else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdAreaDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdAreaDivUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                        else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBusDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBusDivUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                        else if (MST_USERGDCATEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdCateUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdCateUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�E��j
                        else if (MST_USERGDBUSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBusUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBusUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                        else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i��s�j
                        else if (MST_USERGDBANKU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBankUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBankUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdPriDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdPriDivUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                        else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdDeliDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdDeliDivUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                        else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                        else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBuyDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBuyDivUCount);//ADD 2011/07/25
                        }
                        // MOD 2009/06/16 ---->>>
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                        else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdStockDivOUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdStockDivOUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                        else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdStockDivTUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdStockDivTUCount);//ADD 2011/07/25
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                        else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdReturnReaUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdReturnReaUCount);//ADD 2011/07/25
                        }
                        // MOD 2009/06/16 ----<<<
                        // �|���D��Ǘ��}�X�^
                        else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.RateProtyMngCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.RateProtyMngCount);//ADD 2011/07/25
                        }
                        // �|���}�X�^
                        else if (MST_RATE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.RateCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.RateCount);//ADD 2011/07/25
                        }
                        // ����ڕW�ݒ�}�X�^
                        else if (MST_SALESTARGET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);//ADD 2011/07/25
                        }
                        // ���Ӑ�}�X�^
                        else if (MST_CUSTOME.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);//DEL 2011/07/25
                            // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                            //row[key] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);//ADD 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount);
                            // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                        }
                        // �d����}�X�^
                        else if (MST_SUPPLIER.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.SupplierCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.SupplierCount);//ADD 2011/07/25
                        }
                        // �����}�X�^
                        else if (MST_JOINPARTSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.JoinPartsUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.JoinPartsUCount);//ADD 2011/07/25
                        }
                        // �Z�b�g�}�X�^
                        else if (MST_GOODSSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.GoodsSetCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.GoodsSetCount);//ADD 2011/07/25
                        }
                        // �s�a�n�}�X�^
                        else if (MST_TBOSEARCHU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.TBOSearchUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.TBOSearchUCount);//ADD 2011/07/25
                        }
                        // �Ԏ�}�X�^
                        else if (MST_MODELNAMEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.ModelNameUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.ModelNameUCount);//ADD 2011/07/25
                        }
                        // �a�k�R�[�h�}�X�^
                        else if (MST_BLGOODSCDU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.BLGoodsCdUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.BLGoodsCdUCount);//ADD 2011/07/25
                        }
                        // ���[�J�[�}�X�^
                        else if (MST_MAKERU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.MakerUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.MakerUCount);//ADD 2011/07/25
                        }
                        // ���i�����ރ}�X�^
                        else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.GoodsMGroupUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.GoodsMGroupUCount);//ADD 2011/07/25
                        }
                        // �O���[�v�R�[�h�}�X�^
                        else if (MST_BLGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.BLGroupUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.BLGroupUCount);//ADD 2011/07/25
                        }
                        // BL�R�[�h�K�C�h�}�X�^
                        else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.BLCodeGuideCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.BLCodeGuideCount);//ADD 2011/07/25
                        }
                        // ���i�}�X�^
                        else if (MST_GOODSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                            //    + searchCountWork.IsolIslandPrcCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                + searchCountWork.IsolIslandPrcCount);//ADD 2011/07/25
                        }
                        // �݌Ƀ}�X�^
                        else if (MST_STOCK.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.StockCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.StockCount);//ADD 2011/07/25
                        }
                        // ��փ}�X�^
                        else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.PartsSubstUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.PartsSubstUCount);//ADD 2011/07/25
                        }
                        // ���ʃ}�X�^
                        else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.PartsPosCodeUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.PartsPosCodeUCount);//ADD 2011/07/25
                        }
                    }
                }
                _receiveInfoTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// ��M�X�V�`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̎�M�X�V�`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool ReceScreenInputCheck(ref string errMessage)
        {
            bool status = true;

            const string ct_NoInput = "�������͂ł��B";
            const string ct_RangeError = "���o���t�͈̔͂��s���ł��B";
            const string ct_BeginTimeError = "�̕ύX���͓��ꌎ���̂ݐݒ肪�\�ł��B";

            DateTime begDateTime = new DateTime();
            DateTime endDateTime = new DateTime();

            String beginningDate = string.Empty;
            String beginningTime = string.Empty;
            String endDate = string.Empty;
            String endTime = string.Empty;

            Int32 rowConut = 0;
            // ���t�͈̔̓`�F�b�N�p(�J�n�� > �I���� �� NG)
            foreach (ReceiveConditionDataSet.ReceiveConditionRow row in this._mstUpdCountAcs.ReceiveConditionDataTable)
            {
                // �J�n���t
                if (row.IsNull(this._receiveConditionDataTable.BeginningDateColumn.ColumnName))
                {
                    beginningDate = string.Empty;
                }
                else
                {
                    beginningDate = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString().Trim();
                }
                // �J�n����
                if (row.IsNull(this._receiveConditionDataTable.BeginningTimeColumn.ColumnName))
                {
                    beginningTime = string.Empty;
                }
                else
                {
                    beginningTime = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim();
                }
                // �I�����t
                if (row.IsNull(this._receiveConditionDataTable.EndDateColumn.ColumnName))
                {
                    endDate = string.Empty;
                }
                else
                {
                    endDate = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim();
                }
                // �I������
                if (row.IsNull(this._receiveConditionDataTable.EndTimeColumn.ColumnName))
                {
                    endTime = string.Empty;
                }
                else
                {
                    endTime = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim();
                }

                // �J�n���t
                if (beginningDate == string.Empty)
                {
                    errMessage = string.Format("���o�J�n���t{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];

                    status = false;

                    return status;
                }
                // �J�n����
                if (beginningTime == string.Empty)
                {
                    errMessage = string.Format("���o�J�n����{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName];
                    status = false;

                    return status;
                }
                // �I�����t
                if (endDate == string.Empty)
                {
                    errMessage = string.Format("���o�I�����t{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName];
                    status = false;

                    return status;
                }
                // �I������
                if (endTime == string.Empty)
                {
                    errMessage = string.Format("���o�I������{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndTimeColumn.ColumnName];
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
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];
                    status = false;
                    return status;
                }
                bool isTimeOut = false;
                // �X�V��ʂ̊J�n���t�`�F�b�N
                if (!this.ReceUpdateOverData(out isTimeOut))
                {
                    //errMessage = "��M�Ώۋ��_���ݒ肳��Ă��܂���B";//DEL 2011/08/23 #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
                    errMessage = "���o�Ώۂ̃f�[�^�����݂��܂���B";//ADD 2011/08/23 #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];
                    status = false;
                    return status;
                }
                // ADD 2009/07/06 --->>>
                if (isTimeOut)
                {
                    errMessage = "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B";
                    status = false;
                    return status;
                }
                // ADD 2009/07/06 ---<<<
                string baseCodeTemp = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();

                foreach (APMSTSecMngSetWork work in _secMngSetArrList)
                {
                    if (baseCodeTemp.Equals(work.SectionCode))
                    {
                        if (work.SyncExecDate.Year == begDateTime.Year && work.SyncExecDate.Month == begDateTime.Month && work.SyncExecDate.Day == begDateTime.Day
                             && work.SyncExecDate.Hour == begDateTime.Hour && work.SyncExecDate.Minute == begDateTime.Minute && work.SyncExecDate.Second == begDateTime.Second)
                        {
                            status = true;
                        }
                        else
                        {
                            // �V�b�N���ԃ`�F�b�N
                            if (begDateTime < work.SyncExecDate)
                            {
                                if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
                                {
                                    errMessage = string.Format("�J�n���t{0}", ct_BeginTimeError);
                                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[0].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];
                                    status = false;
                                    return status;
                                }
                            }
                        }
                    }
                }


                rowConut++;
            }

            return status;
        }

        /// <summary>
        /// ��M���O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M���O���b�h�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialBccSettingGridCol()
        {
            this.Bcc_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Bcc_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //�uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._receiveInfoDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }
            this.Bcc_Grid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Bcc_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // Filter�ݒ�
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �\�����ݒ�
            this.Bcc_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Width = 30;
            //this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Width = 600;//DEL 2011/07/25
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Width = 350;//ADD 2011/07/25

            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.DisplayOrderColumn.ColumnName].Hidden = true; //ADD 2011/07/25
            // �Œ��ݒ�
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Header.Fixed = false;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Header.Fixed = false;

            // CellAppearance�ݒ�
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // ���͋��ݒ�
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // Style�ݒ�
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
            //{
            //    // Filter�ݒ�
            //    editBand.Columns[baseCodeNameWork.SectionCode].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //    // �\�����ݒ�
            //    editBand.Columns[baseCodeNameWork.SectionCode].Width = 100;
            //    // �Œ��ݒ�
            //    editBand.Columns[baseCodeNameWork.SectionCode].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            //    editBand.Columns[baseCodeNameWork.SectionCode].Header.Fixed = false;
            //    // CellAppearance�ݒ�
            //    editBand.Columns[baseCodeNameWork.SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    // ���͋��ݒ�
            //    editBand.Columns[baseCodeNameWork.SectionCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //    // Style�ݒ�
            //    editBand.Columns[baseCodeNameWork.SectionCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //}
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            foreach (SndRcvHisWork sndRcvHisWork in _sndRcvHisList)
            {
                string key = sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString();
                // Filter�ݒ�
                editBand.Columns[key].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                // �\�����ݒ�
                editBand.Columns[key].Width = 100;
                // �Œ��ݒ�
                editBand.Columns[key].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                editBand.Columns[key].Header.Fixed = false;
                // CellAppearance�ݒ�
                editBand.Columns[key].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                // ���͋��ݒ�
                editBand.Columns[key].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                // Style�ݒ�
                editBand.Columns[key].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        }

        /// <summary>
        /// ��M�����O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M�����O���b�h�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialBConSettingGridCol()
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.BCondition_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //�uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._receiveConditionDataTable.BaseCodeColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // Filter�ݒ�
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �\�����ݒ�
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Width = 130;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Width = 60;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Width = 50;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Width = 60;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Width = 50;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Width = 120;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Width = 10;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Width = 100;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Width = 100;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // �Œ��ݒ�
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Header.Fixed = false;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Header.Fixed = false;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Header.Fixed = false;

            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            // CellAppearance�ݒ�
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // ���͋��ݒ�
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // Style�ݒ�
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            // Hidden��ݒ�
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Hidden = true;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Hidden = true;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Hidden = true;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Hidden = true;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        }

        /// <summary>
        /// ��M���_�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M���_�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitReceInfoSet()
        {
            this._receiveInfoDataTable.BeginLoadData();
            try
            {
                Int32 columnsLen = _receiveInfoTable.Columns.Count;

                for (int i = 0; i < columnsLen; i++)
                {
                    this._receiveInfoTable.Columns.Remove(this._receiveInfoTable.Columns[i].ColumnName);
                    i--;
                    columnsLen--;
                }
                // �X�V�O���b�h��ݒ肷��
                // �ԍ�
                this._receiveInfoTable.Columns.Add(_receiveInfoDataTable.RowNoColumn.ColumnName, typeof(int));
                this._receiveInfoTable.Columns[_receiveInfoDataTable.RowNoColumn.ColumnName].DefaultValue = 0;
                this._receiveInfoTable.Columns[_receiveInfoDataTable.RowNoColumn.ColumnName].Caption = "No.";
                // �X�V�f�[�^
                this._receiveInfoTable.Columns.Add(_receiveInfoDataTable.MasterNameColumn.ColumnName, typeof(string));
                this._receiveInfoTable.Columns[_receiveInfoDataTable.MasterNameColumn.ColumnName].DefaultValue = string.Empty;
                this._receiveInfoTable.Columns[_receiveInfoDataTable.MasterNameColumn.ColumnName].Caption = "�}�X�^����";
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                this._receiveInfoTable.Columns.Add(_receiveInfoDataTable.DisplayOrderColumn.ColumnName, typeof(int));
                this._receiveInfoTable.Columns[_receiveInfoDataTable.DisplayOrderColumn.ColumnName].DefaultValue = 0;
                this._receiveInfoTable.Columns[_receiveInfoDataTable.DisplayOrderColumn.ColumnName].Caption = "DisplayOrder";
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                // �X�V����
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //for ( int j = 0; j < baseCodeNameList.Count; j++ )
                //{
                //    BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.baseCodeNameList[j];
                //    this._receiveInfoTable.Columns.Add(baseCodeNameWork.SectionCode, typeof(string));
                //    this._receiveInfoTable.Columns[baseCodeNameWork.SectionCode].DefaultValue = string.Empty;
                //    this._receiveInfoTable.Columns[baseCodeNameWork.SectionCode].Caption = baseCodeNameWork.SectionGuideNm;
                //}
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                for (int j = 0; j < _sndRcvHisList.Count; j++)
                {
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._sndRcvHisList[j];
                    string key = sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString();
                    this._receiveInfoTable.Columns.Add(key, typeof(string));
                    this._receiveInfoTable.Columns[key].DefaultValue = string.Empty;
                    SecInfoAcs secInfoAcs = new SecInfoAcs();
                    try
                    {
                        this._receiveInfoTable.Columns[key].Caption = string.Empty;
                        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                        {
                            if (secInfoSet.SectionCode.Trim() == sndRcvHisWork.SectionCode.Trim().PadLeft(2, '0'))
                            {
                                this._receiveInfoTable.Columns[key].Caption = secInfoSet.SectionGuideNm.Trim();
                                break;
                            }
                        }
                    }
                    catch
                    {
                        this._receiveInfoTable.Columns[key].Caption = string.Empty;
                    }
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            finally
            {
                this._receiveInfoTable.EndLoadData();
            }
        }

        /// <summary>
        /// ��M�}�X�^���̐ݒ�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M�}�X�^���̐ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceMasterName()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            int status = _mstUpdCountAcs.LoadReceMstName(_enterpriseCode, out masterNameList);
        }

        /// <summary>
        /// ��M�V���N���s���t�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M�V���N���s���t�ݒ菈���ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceSyncExecDate()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            //int status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out _secMngSetArrList, out baseCodeNameList);//DEL 2011/07/25
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            int status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out _secMngSetArrList, out baseCodeNameList, out _sndRcvHisList, out _sndRcvEtrList);
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                PROGRAM_ID,
                "",
                "",
                "",
                "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                0,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ��M�X�V���Ԃ̐ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M�X�V���ԏ������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private bool ReceUpdateOverData(out bool isTimeOut)
        {
            bool isUpdate = true;
            ArrayList secMngSetArrList = new ArrayList();
            isUpdate = _mstUpdCountAcs.ReceUpdateProc(_enterpriseCode, baseCodeNameList, out secMngSetArrList, out isTimeOut);
            if (isUpdate)
            {
                _secMngSetArrList = secMngSetArrList;
            }
            else
            {
                isUpdate = false;
            }
            return isUpdate;
        }


        /// <summary>
        /// ��M�}�X�^�敪�ݒ�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M�}�X�^�敪�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceMasterDoDiv()
        {
            int status = _mstUpdCountAcs.LoadReceMstDoDiv(_enterpriseCode, out masterDivList);
        }

        /// <summary>
        /// ��M�}�X�^���׋敪�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���M�}�X�^���׋敪�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceMasterDtlDoDiv()
        {
            int status = _mstUpdCountAcs.LoadReceMstDtlDoDiv(_enterpriseCode, out masterDtlDivList);
        }

        /// <summary>
        /// �}�X�^��M����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �}�X�^���M�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void ReceUpdateProcess()
        {
            Int32 rowCount = 0;
            string pmCode = string.Empty;
            bool isEmpty = false;
            bool isTotalEmpty = true;
            MstSearchCountWorkWork searchCountWork = null;
            Hashtable countTable = new Hashtable();

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "��M������";
            form.Message = "��M�������ł�";


            this.Cursor = Cursors.WaitCursor;
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            // �_�C�A���O�\��
            form.Show();
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            foreach (ReceiveConditionDataSet.ReceiveConditionRow row in this._mstUpdCountAcs.ReceiveConditionDataTable)
            {
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //string beginningDate = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString();
                //string beginningTime = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString();

                //string endingDate = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName].Value.ToString();
                //string endingTime = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Value.ToString();

                //string baseCode = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Value.ToString();
                //// �J�n���t
                //DateTime beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
                //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                //    int.Parse(beginningTime.Substring(6, 2)));
                //// �I�����t
                //DateTime endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
                //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                //    int.Parse(endingTime.Substring(6, 2)));
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                string baseCodeTemp = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();

                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //foreach (APMSTSecMngSetWork work in _secMngSetArrList)
                //{
                //    if (baseCodeTemp.Equals(work.SectionCode))
                //    {
                //        if (beginDateTime.Year == work.SyncExecDate.Year && beginDateTime.Month == work.SyncExecDate.Month && beginDateTime.Day == work.SyncExecDate.Day
                //            && beginDateTime.Hour == work.SyncExecDate.Hour && beginDateTime.Minute == work.SyncExecDate.Minute && beginDateTime.Second == work.SyncExecDate.Second)
                //        {
                //            beginDateTime = work.SyncExecDate;
                //        }
                //        break;
                //    }
                //}
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                ArrayList paramList = new ArrayList();
                //���M����ƃR�[�h
                string sendDestEnterpriseCode = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Value.ToString();
                //���M�����_�R�[�h
                string sendDestSecCode = baseCodeTemp;
                //����M�������O���M�ԍ�
                int sndRcvHisConsNo = (int)this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Value;
                GetSelectSndRcvEtr(sendDestEnterpriseCode, sendDestSecCode, sndRcvHisConsNo);
                if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_CUSTOMER]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_GOODS]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_STOCK]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_SUPPLIER]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_RATE]);
                }
                // --- ADD 2012/07/26 ---------------------------->>>>>
                if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_EMPLOYEE]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_JOINPARTSU]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_USERGDU]);
                }
                // --- ADD 2012/07/26 ----------------------------<<<<<
                // �J�n���t
                DateTime beginDateTime = DateTime.MinValue;
                // �I�����t
                DateTime endDateTime = DateTime.MinValue;
                SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
                foreach (SndRcvHisWork work in _sndRcvHisList)
                {
                    if (sendDestSecCode.Equals(work.SectionCode) && sendDestEnterpriseCode.Equals(work.EnterpriseCode)
                        && sndRcvHisConsNo == work.SndRcvHisConsNo)
                    {
                        beginDateTime = work.SndObjStartDate;
                        endDateTime = work.SndObjEndDate;
                        sndRcvHisWork = work;
                        break;
                    }
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<


                //int status = _mstUpdCountAcs.SeachPmCode(_enterpriseCode, baseCodeTemp, out pmCode);//DEL 2011/07/25
                long beginDtLong = beginDateTime.Ticks;
                long endDtLong = endDateTime.Ticks;
                searchCountWork = new MstSearchCountWorkWork();
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //// �_�C�A���O�\��
                //form.Show();
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                //status = _mstUpdCountAcs.ReceProc(_enterpriseCode, _connectPointDiv, masterDivList, masterDtlDivList, masterNameList, beginDtLong, endDtLong, _secMngSetArrList, pmCode, _loginEmplooyCode, baseCodeTemp, out searchCountWork, out isEmpty);//DEL 2011/07/25
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                int status = _mstUpdCountAcs.ReceProc(_enterpriseCode, _connectPointDiv, masterDivList, masterDtlDivList, masterNameList, beginDtLong, endDtLong, _secMngSetArrList, paramList, sndRcvHisWork, sendDestEnterpriseCode, _loginEmplooyCode, baseCodeTemp, out searchCountWork, out isEmpty);//ADD 2011/07/25
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //// �_�C�A���O�����
                //form.Close();
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                if (!isEmpty)
                {
                    isTotalEmpty = false;
                }
                //countTable.Add(baseCodeTemp, searchCountWork);//DEL 2011/07/25
                countTable.Add(sendDestEnterpriseCode + sendDestSecCode.Trim() + sndRcvHisConsNo.ToString(), searchCountWork);//ADD 2011/07/25
                rowCount++;
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            // �_�C�A���O�����
            form.Close();
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            this.Cursor = Cursors.Default;

            // ����0���̏ꍇ�A
            if (isTotalEmpty)
            {
                OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                // MOD 2009/06/17 --->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                // MOD 2009/06/17 ---<<<
                // ���M���e�[�u���N���A����
                this._receiveInfoTable.Clear();

                this.ReceSearchResultDataGridCol(countTable);

                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs["updateTab"];

                // ���b�Z�[�W��\��
                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);//DEL 2011/08/23 #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���

            }
            else
            {
                // ���M���e�[�u���N���A����
                this._receiveInfoTable.Clear();

                this.ReceSearchResultDataGridCol(countTable);

                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs["updateTab"];
            }
        }

        #endregion �� �}�X�^��M���b�\�h�֘A ��

        #region �� ����M���ʏ��� ��
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
                        // �X�V����
                        bool inputCheck = false;
                        if (tce_SendAndReceKubun.SelectedIndex == 0)
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

                            inputCheck = this.UpdateBeforeCheck();

                            if (inputCheck)
                            {
                                this.DataGetAgain();
                                this.UpdateProcess();
                            }
                        }
                        else
                        {
                            if (0 == this.BCondition_Grid.Rows.Count)
                            {
                                // ���b�Z�[�W��\��
                                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "��M�Ώۋ��_���ݒ肳��Ă��܂���B", 0);//DEL 2011/08/23 #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
                                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���o�Ώۂ̃f�[�^�����݂��܂���B", 0);//ADD 2011/08/23 #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "��M�Ώۂ̃f�[�^�����݂��܂���B", 0);//ADD 2011/08/23 #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
                                return;
                            }

                            // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                            if (this.BCondition_Grid.ActiveCell != null)
                            {
                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            inputCheck = this.ReceUpdateBeforeCheck();

                            if (inputCheck)
                            {
                                this.DataGetAgain();
                                this.ReceUpdateProcess();
                            }
                        }
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // ���ɖ߂�����
                        this.Retry();

                        break;
                    }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                case "ButtonTool_ExtractDetail":
                    {
                        //���M���o�����ڍ׏���
                        ExtractDetailShow();
                        break;
                    }
                case "ButtonTool_Setting":
                    {
                        //�ݒ�{�^������
                        SendDestSet();
                        break;
                    }
                case "ButtonTool_Customer":
                    {
                        //���Ӑ�}�X�^���o����
                        PMKYO01301UA _PMKYO01301UA = new PMKYO01301UA();
                        _PMKYO01301UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_CUSTOMER];
                            this._customerProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._customerProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                            this._customerProcParam.KanaBeginRF = sndRcvEtrWork.StartCond2;
                            this._customerProcParam.KanaEndRF = sndRcvEtrWork.EndCond2;
                            this._customerProcParam.MngSectionCodeBeginRF = sndRcvEtrWork.StartCond3;
                            this._customerProcParam.MngSectionCodeEndRF = sndRcvEtrWork.EndCond3;
                            this._customerProcParam.CustomerAgentCdBeginRF = sndRcvEtrWork.StartCond4;
                            this._customerProcParam.CustomerAgentCdEndRF = sndRcvEtrWork.EndCond4;
                            this._customerProcParam.SalesAreaCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
                            this._customerProcParam.SalesAreaCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
                            this._customerProcParam.BusinessTypeCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
                            this._customerProcParam.BusinessTypeCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
                        }
                        _PMKYO01301UA._customerProcParam = this._customerProcParam;
                        _PMKYO01301UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Supplier":
                    {
                        //�d����}�X�^���o����
                        PMKYO01501UA _PMKYO01501UA = new PMKYO01501UA();
                        _PMKYO01501UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_SUPPLIER];
                            this._supplierProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._supplierProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                        }
                        _PMKYO01501UA._supplierProcParam = this._supplierProcParam;
                        _PMKYO01501UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Goods":
                    {
                        //���i�}�X�^���o����
                        PMKYO01401UA _PMKYO01401UA = new PMKYO01401UA();
                        _PMKYO01401UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_GOODS];
                            this._goodsProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._goodsProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                            this._goodsProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
                            this._goodsProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
                            this._goodsProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._goodsProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._goodsProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond4;
                            this._goodsProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond4;
                        }
                        _PMKYO01401UA._goodsProcParam = this._goodsProcParam;
                        _PMKYO01401UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Stock":
                    {
                        //�݌Ƀ}�X�^���o����
                        PMKYO01701UA _PMKYO01701UA = new PMKYO01701UA();
                        _PMKYO01701UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_STOCK];
                            this._stockProcParam.WarehouseCodeBeginRF = sndRcvEtrWork.StartCond1;
                            this._stockProcParam.WarehouseCodeEndRF = sndRcvEtrWork.EndCond1;
                            this._stockProcParam.WarehouseShelfNoBeginRF = sndRcvEtrWork.StartCond2;
                            this._stockProcParam.WarehouseShelfNoEndRF = sndRcvEtrWork.EndCond2;
                            this._stockProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._stockProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._stockProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
                            this._stockProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
                            this._stockProcParam.BLGloupCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
                            this._stockProcParam.BLGloupCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
                            this._stockProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond6;
                            this._stockProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond6;
                        }
                        _PMKYO01701UA._stockProcParam = this._stockProcParam;
                        _PMKYO01701UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Rate":
                    {
                        //�|���}�X�^���o����
                        PMKYO01601UA _PMKYO01601UA = new PMKYO01601UA();
                        _PMKYO01601UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_RATE];
                            this._rateProcParam.UnitPriceKindRF = sndRcvEtrWork.StartCond1;
                            this._rateProcParam.SetFunRF = sndRcvEtrWork.EndCond1;
                            // --- DEL 2012/07/26 ------------------------->>>>>
                            //this._rateProcParam.RateSettingDivideRF = sndRcvEtrWork.StartCond2;
                            // --- DEL 2012/07/26 -------------------------<<<<<
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            this._rateProcParam.SectionCodeBeginRF = sndRcvEtrWork.StartCond2;
                            this._rateProcParam.SectionCodeEndRF = sndRcvEtrWork.EndCond2;
                            // --- ADD 2012/07/26 -------------------------<<<<<
                            this._rateProcParam.CustRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._rateProcParam.CustRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._rateProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
                            this._rateProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
                            this._rateProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
                            this._rateProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
                            this._rateProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
                            this._rateProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
                            this._rateProcParam.GoodsRateRankBeginRF = sndRcvEtrWork.StartCond7;
                            this._rateProcParam.GoodsRateRankEndRF = sndRcvEtrWork.EndCond7;
                            this._rateProcParam.GoodsRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond8);
                            this._rateProcParam.GoodsRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond8);
                            this._rateProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond9);
                            this._rateProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond9);
                            this._rateProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond10;
                            this._rateProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond10;
                        }
                        _PMKYO01601UA._rateProcParam = this._rateProcParam;
                        _PMKYO01601UA.ShowDialog();
                        break;
                    }
                // --- ADD 2012/07/26 ------------------------------------->>>>>
                case "ButtonTool_Employee":
                    {
                        // �]�ƈ��ݒ�}�X�^���o����
                        PMKYO01511UA _PMKYO01511UA = new PMKYO01511UA();
                        _PMKYO01511UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_EMPLOYEE];
                            this._employeeProcParam.BelongSectionCdBeginRF = sndRcvEtrWork.StartCond1;
                            this._employeeProcParam.BelongSectionCdEndRF = sndRcvEtrWork.EndCond1;
                            this._employeeProcParam.EmployeeCdBeginRF = sndRcvEtrWork.StartCond2;
                            this._employeeProcParam.EmployeeCdEndRF = sndRcvEtrWork.EndCond2;
                        }
                        _PMKYO01511UA._employeeProcParam = this._employeeProcParam;
                        _PMKYO01511UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_JoinPartsU":
                    {
                        // �����}�X�^���o����
                        PMKYO01521UA _PMKYO01521UA = new PMKYO01521UA();
                        _PMKYO01521UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_JOINPARTSU];
                            this._joinPartsUProcParam.JoinSourPartsNoWithHBeginRF = sndRcvEtrWork.StartCond1;
                            this._joinPartsUProcParam.JoinSourPartsNoWithHEndRF = sndRcvEtrWork.EndCond1;
                            this._joinPartsUProcParam.JoinSourceMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
                            this._joinPartsUProcParam.JoinSourceMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
                            this._joinPartsUProcParam.JoinDispOrderBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._joinPartsUProcParam.JoinDispOrderEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._joinPartsUProcParam.JoinDestMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
                            this._joinPartsUProcParam.JoinDestMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
                        }
                        _PMKYO01521UA._joinPartsUProcParam = this._joinPartsUProcParam;
                        _PMKYO01521UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_UserGdBuyDivU":
                    {
                        // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j���o����
                        PMKYO01531UA _PMKYO01531UA = new PMKYO01531UA();
                        _PMKYO01531UA.Mode = 2; //2:�Q�ƃ��[�h
                        if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_USERGDU];
                            this._userGdBuyDivUProcParam.GuideCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._userGdBuyDivUProcParam.GuideCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                        }
                        _PMKYO01531UA._userGdBuyDivUProcParam = this._userGdBuyDivUProcParam;
                        _PMKYO01531UA.ShowDialog();
                        break;
                    }
                // --- ADD 2012/07/26 -------------------------------------<<<<<
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
        }

        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���ɖ߂������ł��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Retry()
        {
            //this.SendClear(); //DEL 2011/07/25
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.SendClear(0);
            this.tce_ExtractCondDiv.SelectedIndex = 0;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            //ADD 2011/09/14 sundx #24542 ���_�I���ɂ���----->>>>>
            SetSecCode(_initSecCode);
            InitSecCode();
            //ADD 2011/09/14 sundx #24542 ���_�I���ɂ���-----<<<<<

        }

        /// <summary>
        /// �X�V�̏ꍇ�A����M��ʏ�������x�擾����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �X�V�̏ꍇ�A����M��ʏ�������x�擾�����ł��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void DataGetAgain()
        {
            // ���M�̏ꍇ�A
            if (tce_SendAndReceKubun.SelectedIndex == 0)
            {
                this._updateResultDataTable.Clear();
                // ���M���f�[�^�ݒ�
                this.Acc_Grid.DataSource = this._updateResultDataTable;
                // ���M���O���b�h�����ݒ�
                this.InitialAccSettingGridCol();
                // �}�X�^���̂��擾����B
                this.SearchMasterName();
                // �}�X�^���̂��擾�敪�B
                this.SearchMasterDoDiv();
                // ����M�Ώېݒ�}�X�^���A�}�X�^���̏����ݒ�
                this.InitialAccDataGridCol();
            }
            // ��M�̏ꍇ�A
            else
            {
                this._receiveInfoTable.Clear();
                // �}�X�^���̂��擾����B
                this.SearchReceMasterName();
                // �}�X�^���̂��擾�敪�B
                this.SearchReceMasterDoDiv();
                // �f�[�^�X�V�敪���擾����B
                this.SearchReceMasterDtlDoDiv();
                // ���_�ݒ菈��
                this.InitReceInfoSet();
                // ��M���f�[�^�ݒ�
                this.Bcc_Grid.DataSource = this._receiveInfoTable;
                // ��M���O���b�h�����ݒ�
                this.InitialBccSettingGridCol();
            }
        }

        /// <summary>
        /// �h���v�_���ύX����
        /// </summary>
        /// <param name="mode">0:������ 1:����M�敪�ύX 2:���o�����敪�ύX</param>
        /// <remarks>		
        /// <br>Note		: �h���v�_���ύX�����ł��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        //private void SendClear() //DEL 2011/07/25
        private void SendClear(int mode) //ADD 2011/07/25
        {
            // ���M�̏ꍇ�A
            if (tce_SendAndReceKubun.SelectedIndex == 0)
            {
                this._extractionConditionDataTable.Clear();
                this._updateResultDataTable.Clear();
                this._receiveConditionDataTable.Clear();
                this._receiveInfoTable.Clear();

                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                // ���M��ݒ�
                this.SearchSyncExecDate();
                if (mode == 0 || mode == 1)
                {
                    //0:�������A�܂���1:����M�敪�ύX�̏ꍇ�A���M�拒�_���Đݒ�
                    if (baseCodeNameList.Count == 0)
                    {
                        this.tEdit_SectionCode.DataText = string.Empty;
                        this.tEdit_SectionName.DataText = string.Empty;
                    }
                    else if (baseCodeNameList.Count == 1)
                    {
                        this.tEdit_SectionCode.DataText = ((BaseCodeNameWork)baseCodeNameList[0]).SectionCode.Trim();
                        this.tEdit_SectionName.DataText = ((BaseCodeNameWork)baseCodeNameList[0]).SectionGuideNm;
                    }
                    else
                    {
                        this.tEdit_SectionCode.DataText = ALL_SECTIONCODE;
                        this.tEdit_SectionName.DataText = "�S��";
                    }
                    this.sendDestSecList = baseCodeNameList;
                    this._preSectionCode = this.tEdit_SectionCode.DataText;
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                // ���M���true
                this.ultraTabControl1.Visible = true;
                // ��M���false
                this.ultraTabControl2.Visible = false;
                // ���M���f�[�^�ݒ�
                this.Acc_Grid.DataSource = this._updateResultDataTable;
                // ���M�����f�[�^�ݒ�
                this.Condition_Grid.DataSource = this._extractionConditionDataTable;
                // ���M���O���b�h�����ݒ�
                this.InitialAccSettingGridCol();
                // �}�X�^���̂��擾����B
                this.SearchMasterName();
                // �}�X�^���̂��擾�敪�B
                this.SearchMasterDoDiv();
                // �V���N���s���t���擾����B
                //this.SearchSyncExecDate();//DEL 2011/07/25
                // ����M�Ώېݒ�}�X�^���A�}�X�^���̏����ݒ�
                this.InitialAccDataGridCol();
                // ���M�����O���b�h�����ݒ�
                this.InitialConSettingGridCol();
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                // ���M�����O���b�h�Đݒ�
                this.ResetConSettingGridCol();
                //��ʃR���g���[���\�������ݒ�
                this._extractDetailButton.SharedProps.Visible = true;
                this._settingButton.SharedProps.Visible = false;
                this._detailButton.SharedProps.Visible = false;
                this.uLabel_SectionCode.Visible = true;
                this.tEdit_SectionCode.Visible = true;
                this.tEdit_SectionName.Visible = true;
                this.SectionGuide_Button.Visible = true;
                this.uLabel_ExtractCondDiv.Visible = true;
                this.tce_ExtractCondDiv.Visible = true;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                if (this.Condition_Grid.Rows.Count > 0)
                {
					//this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];//DEL 2011/07/25
					this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];//ADD 2011/07/25
                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
                }
            }
            // ��M�̏ꍇ�A
            else
            {
                this._extractionConditionDataTable.Clear();
                this._updateResultDataTable.Clear();
                this._receiveConditionDataTable.Clear();
                this._receiveInfoTable.Clear();

                // ���M���false
                this.ultraTabControl1.Visible = false;
                // ��M���true
                this.ultraTabControl2.Visible = true;
                // �}�X�^���̂��擾����B
                this.SearchReceMasterName();
                // �}�X�^���̂��擾�敪�B
                this.SearchReceMasterDoDiv();
                // �f�[�^�X�V�敪���擾����B
                this.SearchReceMasterDtlDoDiv();
                // �V���N���s���t���擾����B
                this.SearchReceSyncExecDate();
                // ���_�ݒ菈��
                this.InitReceInfoSet();
                // ��M���f�[�^�ݒ�
                this.Bcc_Grid.DataSource = this._receiveInfoTable;
                // ��M�����f�[�^�ݒ�
                this.BCondition_Grid.DataSource = this._receiveConditionDataTable;
                // ��M���O���b�h�����ݒ�
                this.InitialBccSettingGridCol();
                // ��M�����O���b�h�����ݒ�
                this.InitialBConSettingGridCol();
                // ����M�Ώېݒ�}�X�^���A�}�X�^���̏����ݒ�
                this.UpdateResultBccDataGridCol();
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //��ʃR���g���[���\�������ݒ�
                this._extractDetailButton.SharedProps.Visible = false;
                this._settingButton.SharedProps.Visible = true;
                this._detailButton.SharedProps.Visible = true;
                this.uLabel_SectionCode.Visible = false;
                this.tEdit_SectionCode.Visible = false;
                this.tEdit_SectionName.Visible = false;
                this.SectionGuide_Button.Visible = false;
                this.uLabel_ExtractCondDiv.Visible = false;
                this.tce_ExtractCondDiv.Visible = false;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--------------------------------------->>>>>
                //�J�n���t�A�J�n���ԁA�I�����t�A�I�����Ԃɋ󔒂�ݒ肷��
                for (int i = 0; i < this._receiveConditionDataTable.Rows.Count; i++)
                {
                    ReceiveConditionDataSet.ReceiveConditionRow row = (ReceiveConditionDataSet.ReceiveConditionRow)_receiveConditionDataTable.Rows[i];
                    if (row.BeginningDate.Equals(DateTime.MinValue))
                    {
                        BCondition_Grid.Rows[i].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].SetValue(DBNull.Value, true);
                    }
                    if (row.EndDate.Equals(DateTime.MinValue))
                    {
                        BCondition_Grid.Rows[i].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName].SetValue(DBNull.Value, true);
                    }             
                }
                if (BCondition_Grid.ActiveCell != null)
                {
                    BCondition_Grid.ActiveCell.Selected = false;
                    BCondition_Grid.ActiveCell.Activated = false;
                }
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---------------------------------------<<<<<
                if (this.BCondition_Grid.Rows.Count > 0)
                {
                    //this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[0].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];//DEL 2011/07/25
                    this.BCondition_Grid.Rows[0].Activate();//ADD 2011/07/25
                    this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs["updateTab"];
                }
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //���͂����}�X�^���o�������N���A
            this._customerProcParam = new APCustomerProcParamWork();
            this._supplierProcParam = new APSupplierProcParamWork();
            this._stockProcParam = new APStockProcParamWork();
            this._goodsProcParam = new APGoodsProcParamWork();
            this._rateProcParam = new APRateProcParamWork();
            // --- ADD 2012/07/26 ------------------------->>>>>
            this._employeeProcParam = new APEmployeeProcParamWork();
            this._joinPartsUProcParam = new APJoinPartsUProcParamWork();
            this._userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
            // --- ADD 2012/07/26 -------------------------<<<<<
            this.sndRcvEtrDic.Clear();
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        }

        /// <summary>
        /// ��M���O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ��M���O���b�h�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void UpdateResultBccDataGridCol()
        {
            DataRow row = null;

            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _receiveInfoTable.NewRow();
                row[_receiveInfoDataTable.RowNoColumn.ColumnName] = rowNo;
                row[_receiveInfoDataTable.MasterNameColumn.ColumnName] = work.MasterName;
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //for (int i = 0; i < baseCodeNameList.Count; i++ ) 
                //{
                //    BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.baseCodeNameList[i];
                //    row[baseCodeNameWork.SectionCode] = string.Empty;
                //}
                //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                row[_receiveInfoDataTable.DisplayOrderColumn.ColumnName] = work.DisplayOrder;
                for (int i = 0; i < _sndRcvHisList.Count; i++)
                {
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._sndRcvHisList[i];
                    row[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString()] = string.Empty;
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                _receiveInfoTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// �G���[���b�Z�[�W����
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:�`�F�b�N���� false:�`�F�b�N������</returns>
        /// <remarks>
        /// <br>Note		: �G���[���b�Z�[�W���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        #endregion region �� ����M���ʏ��� ��

        #region �� �O���b�h ��

        /// <summary>
        /// ���M�����O���b�h�L�[�v���X�C�x���g
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
        /// <param name="selstart">���͒l</param>
        /// <param name="sellength">���͒l</param>
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
        /// ���M�����O���b�h�L�[�h���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Condition_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

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
												// add by �g���Y 2011/07/25 ----------------------------->>>>>>
												while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
													"SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
													e.Handled = true;
												}
												// add by �g���Y 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.Condition_Grid.ActiveCell.SelStart >= this.Condition_Grid.ActiveCell.Text.Length)
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
												// add by �g���Y 2011/07/25 ----------------------------->>>>>>
												while (!this.Condition_Grid.ActiveCell.IsInEditMode)
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
													e.Handled = true;
												}
												// add by �g���Y 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
										// add by �g���Y 2011/07/25 ----------------------------->>>>>>
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
										// add by �g���Y 2011/07/25 -----------------------------<<<<<<
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
												// add by �g���Y 2011/07/25 ----------------------------->>>>>>
												while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
													"SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
													e.Handled = true;
												}
												// add by �g���Y 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
												// add by �g���Y 2011/07/25 ----------------------------->>>>>>
												while (!this.Condition_Grid.ActiveCell.IsInEditMode)
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
													e.Handled = true;
												}
												// add by �g���Y 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
										// add by �g���Y 2011/07/25 ----------------------------->>>>>>
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
										// add by �g���Y 2011/07/25 -----------------------------<<<<<<
                                    }
                                    break;
                                }
                        }
                    } // add by �g���Y 2011/07/25 ----------------------------->>>>>>
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
                    // add by �g���Y 2011/07/25 -----------------------------<<<<<<

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
								//bool isMove = MoveNextAllowEditCell(false);// del 2011/07/25

                                break;
                            }
                    }
                }
        }

        /// <summary>
        /// ���M�����O���b�hEnter�L�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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
        }

        /// <summary>
        /// ���M�����O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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
        /// ���M�����O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Condition_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            string errMsg = string.Empty;
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                errMsg = "�J�n���Ԃ͎���6���œ��͂��ĉ������B";
            }
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                errMsg = "�I�����Ԃ͎���6���œ��͂��ĉ������B";
            }


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
                           errMsg,
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
                                errMsg,
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
                                   errMsg,
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
        /// ����M�敪�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tce_SendAndReceKubun_ValueChanged(object sender, EventArgs e)
        {
            //this.SendClear(); //DEL 2011/07/25
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            this.SendClear(1);
            if (this.tce_SendAndReceKubun.SelectedIndex == 0)
            {                
                InitSecCode();//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
                this.tce_ExtractCondDiv.SelectedIndex = 0;
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        }

        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        /// <summary>
        /// ���o�����敪�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tce_ExtractCondDiv_ValueChanged(object sender, EventArgs e)
        {
            this.SendClear(2);
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Hidden = false;
            }
            else
            {
                this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Hidden = true;
            }
        }
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        /// <summary>
        /// ��M�����O���b�h�L�[�v���X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void BCondition_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;

            // ActiveCell�����ʂ̏ꍇ
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
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
        /// ��M�����O���b�h�L�[�h���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void BCondition_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;

                    // �ҏW���ł������ꍇ
                    if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.BCondition_Grid.ActiveCell.StyleResolved)
                        {
                            // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.BCondition_Grid.ActiveCell.SelStart == 0)
                                            {
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.BCondition_Grid.ActiveCell.SelStart >= this.BCondition_Grid.ActiveCell.Text.Length)
                                            {
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
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
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.BCondition_Grid.ActiveCell != null) && (this.BCondition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if ((this.BCondition_Grid.ActiveCell != null) && (this.BCondition_Grid.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                bool isMove = BMoveNextAllowEditCell(false);
                                break;
                            }
                    }
                }
        }

        /// <summary>
        /// ��M�����O���b�hEnter�L�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void BCondition_Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;
            String value = cell.Value.ToString().Trim();

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                // �J�n���ԕϊ�
                if (value.Length == 8)
                {
                    this._receiveConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ActiveCell���I�����Ԃ̏ꍇ
            else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                // �I�����ԕϊ�
                if (value.Length == 8)
                {
                    this._receiveConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            else if (cell.Column.Key == this._receiveConditionDataTable.BeginningDateColumn.ColumnName
                     || cell.Column.Key == this._receiveConditionDataTable.EndDateColumn.ColumnName)
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
        }

        /// <summary>
        /// �^�u�̏���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
            //{
            //    this.Bcc_Grid.Visible = false;
            //    this.BCondition_Grid.Visible = true;
            //}
            //else
            //{
            //    this.Bcc_Grid.Visible = true;
            //    this.BCondition_Grid.Visible = false;
            //}
            //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
            {
                this._settingButton.SharedProps.Enabled = false;
                if (this.BCondition_Grid.Rows.Count > 0 && this.BCondition_Grid.ActiveRow != null &&
                    (int)this.BCondition_Grid.ActiveRow.Cells[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Value == 1)
                {
                    this._detailButton.SharedProps.Enabled = true;
                    this._custDetailButton.SharedProps.Visible = true;
                    this._suppDetailButton.SharedProps.Visible = true;
                    this._goodsDetailButton.SharedProps.Visible = true;
                    this._stockDetailButton.SharedProps.Visible = true;
                    this._rateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ------------------------------------>>>>>
                    this._employeeDetailButton.SharedProps.Visible = true;
                    this._joinPartsUrateDetailButton.SharedProps.Visible = true;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ------------------------------------<<<<<
                    this._custDetailButton.SharedProps.Enabled = false;
                    this._suppDetailButton.SharedProps.Enabled = false;
                    this._goodsDetailButton.SharedProps.Enabled = false;
                    this._stockDetailButton.SharedProps.Enabled = false;
                    this._rateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 ------------------------------------->>>>>
                    this._employeeDetailButton.SharedProps.Enabled = false;
                    this._joinPartsUrateDetailButton.SharedProps.Enabled = false;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 -------------------------------------<<<<<

                    GetSelectSndRcvEtr(this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Value.ToString(),
                        this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString(),
                        (int)this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Value);
                    if (sndRcvEtrDic != null)
                    {
                        if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                        {
                            this._custDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                        {
                            this._goodsDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                        {
                            this._stockDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                        {
                            this._suppDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                        {
                            this._rateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ---------------------------->>>>>
                        if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                        {
                            this._employeeDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                        {
                            this._joinPartsUrateDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                        {
                            this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ----------------------------<<<<<
                    }
                    this.BCondition_Grid.ContextMenu = _contextMenu;
                }
                else
                {
                    this.BCondition_Grid.ContextMenu = null;
                    this._detailButton.SharedProps.Enabled = false;
                }
            }
            else
            {
                if (this.Bcc_Grid.ActiveRow != null &&
                    (MST_GOODSU.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value) ||
                    (MST_STOCK.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value))))
                {
                    this._settingButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._settingButton.SharedProps.Enabled = false;
                }

                this._detailButton.SharedProps.Enabled = false;
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        }

        /// <summary>
        /// �^�u�̏���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
            {
                this.Acc_Grid.Visible = false;
                this.Condition_Grid.Visible = true;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                this._extractDetailButton.SharedProps.Enabled = false;
                this._settingButton.SharedProps.Visible = false;
                this._detailButton.SharedProps.Visible = false;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            else
            {
                this.Acc_Grid.Visible = true;
                this.Condition_Grid.Visible = false;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                {
                    this._extractDetailButton.SharedProps.Enabled = true;
                }
                this._settingButton.SharedProps.Visible = false;
                this._detailButton.SharedProps.Visible = false;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
        }

        /// <summary>
        /// ��M�����O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void BCondition_Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;


            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // �J�n���ԕϊ�
                if (value.Length == 6)
                {
                    this._receiveConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
            // ActiveCell���I�����Ԃ̏ꍇ
            else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // �I�����ԕϊ�
                if (value.Length == 6)
                {
                    this._receiveConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
        }

        /// <summary>
        /// ��M�����O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void BCondition_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            string errMsg = string.Empty;
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                errMsg = "�J�n���Ԃ͎���6���œ��͂��ĉ������B";
            }
            else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                errMsg = "�I�����Ԃ͎���6���œ��͂��ĉ������B";
            }

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
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
                           errMsg,
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
                                errMsg,
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
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
                                {
                                    this._receiveConditionDataTable[rowIndex].BeginningTime = startTime.Substring(0, 2) + ":"
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }
                                else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
                                {
                                    this._receiveConditionDataTable[rowIndex].EndTime = startTime.Substring(0, 2) + ":"
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
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                case "tEdit_SectionCode":
                    {
                        bool flag = true;
                        try
                        {
                            // ���_�R�[�h�擾
                            string sectionCode = this.tEdit_SectionCode.DataText;

                            if (sectionCode.Trim().Equals(""))
                            {
                                //�N���A�����Ɠ���
                                SendClear(0);
                                //flag = false;//DEL 2011/07/25
                                if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.Trim())) flag = false;//ADD 2011/07/25
                                return;
                            }

                            if (sectionCode.Trim().Equals(this._preSectionCode))
                            {
                                flag = true;
                                return;
                            }

                            // ���_���̎擾
                            string sectionName = GetSectionName(sectionCode);

                            if (sectionName.Trim() != string.Empty)
                            {
                                this.tEdit_SectionName.DataText = sectionName;
                                this.tEdit_SectionCode.Text = sectionCode.Trim().PadLeft(2, '0');
                                this._preSectionCode = sectionCode.Trim().PadLeft(2, '0');
                                flag = true;
                                SetSecCode(this.tEdit_SectionCode.Text);//ADD 2011/09/14 sundx #24542 ���_�I���ɂ���
                                //ADD 2011/08/30 #24191 ���M�������I�������}�X�^�ɂ����`�F�b�N��������ԂɏC��---->>>>>
                                //�������M�̏ꍇ�A���M�Ώۂ�I���`�F�b�N
                                if (selectMstNameList == null)
                                {
                                    selectMstNameList = new ArrayList();
                                }
                                else
                                {
                                    selectMstNameList.Clear();
                                }
                                for (int i = 0; i < this.Acc_Grid.Rows.Count; i++)
                                {
                                    if ((bool)this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value)
                                    {
                                        foreach (SecMngSndRcvWork work in masterNameList)
                                        {
                                            if (work.MasterName.Equals(this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Value.ToString()))
                                            {
                                                selectMstNameList.Add(work);
                                            }
                                        }
                                    }
                                }
                                //ADD 2011/08/30 #24191 ���M�������I�������}�X�^�ɂ����`�F�b�N��������ԂɏC��----<<<<<

                                ResetGridCol();
                                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                                //���͂����}�X�^���o�������N���A
                                this._customerProcParam = new APCustomerProcParamWork();
                                this._supplierProcParam = new APSupplierProcParamWork();
                                this._stockProcParam = new APStockProcParamWork();
                                this._goodsProcParam = new APGoodsProcParamWork();
                                this._rateProcParam = new APRateProcParamWork();
                                // --- ADD 2012/07/26 ------------------------->>>>>
                                this._employeeProcParam = new APEmployeeProcParamWork();
                                this._joinPartsUProcParam = new APJoinPartsUProcParamWork();
                                this._userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
                                // --- ADD 2012/07/26 -------------------------<<<<<
                                this.sndRcvEtrDic.Clear();
                                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            }
                            else
                            {
                                TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                this.Name,							    // �A�Z���u��ID
                                "���M�拒�_�R�[�h�����݂��܂���B",	// �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��

                                this.tEdit_SectionCode.DataText = this._preSectionCode;
                                flag = false;
                            }
                        }
                        finally
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (flag)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tce_ExtractCondDiv;
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.SectionGuide_Button;
                                    }
                                }
                            }
                        }
                        break;
                    }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                case "ultraTabControl1":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
                                    {
                                        if (this.Condition_Grid.ActiveCell != null)
                                        {
											//if (MoveNextAllowEditCell(false))// del 2011/07/25
											if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
											{
												e.NextCtrl = null;
											}
											else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
											{
												//e.NextCtrl = this.tce_SendAndReceKubun;
												this.Condition_Grid.Rows[0].Cells[0].Activate();
												this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
											}
											else
											{
												e.NextCtrl = e.PrevCtrl;
											}
                                        }
                                    }
                                    break;
                                }
                            case Keys.Tab:
                                {
                                    if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
                                    {
										//if (MoveNextAllowEditCell(false))// del 2011/07/25
										if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = null;
                                            this.Condition_Grid.Rows[0].Cells[0].Activate();
                                            this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }

                case "ultraTabControl2":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
                                    {
                                        if (this.BCondition_Grid.ActiveCell != null)
                                        {
                                            if (BMoveNextAllowEditCell(false))
                                            {
                                                e.NextCtrl = null;
                                            }
                                            else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                            {
                                                //e.NextCtrl = this.tce_SendAndReceKubun;
                                                this.BCondition_Grid.Rows[0].Cells[2].Activate();
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            }
                                            else
                                            {
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                        }
                                    }
                                    break;
                                }
                            case Keys.Tab:
                                {
                                    if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
                                    {
                                        if (BMoveNextAllowEditCell(false))
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = null;
                                            this.BCondition_Grid.Rows[0].Cells[2].Activate();
                                            this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }

                case "Condition_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.Condition_Grid.ActiveCell != null)
                                    {
										//if (MoveNextAllowEditCell(false))// del 2011/07/25
										if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = this.tce_SendAndReceKubun;
                                            //this.Condition_Grid.Rows[0].Cells[2].Activate();
                                            //this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
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
									//if (MoveNextAllowEditCell(false))// del 2011/07/25
									if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                    {
                                        e.NextCtrl = this.tce_SendAndReceKubun;
                                        //this.Condition_Grid.Rows[0].Cells[2].Activate();
                                        //this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
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

                case "BCondition_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.BCondition_Grid.ActiveCell != null)
                                    {
                                        if (BMoveNextAllowEditCell(false))
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = this.tce_SendAndReceKubun;
                                            //this.Condition_Grid.Rows[0].Cells[2].Activate();
                                            //this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
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
                                    if (BMoveNextAllowEditCell(false))
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                    {
                                        e.NextCtrl = this.tce_SendAndReceKubun;
                                        //this.BCondition_Grid.Rows[0].Cells[2].Activate();
                                        //this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
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

        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "�S��";
                return sectionName;
            }

            for (int i = 0; i < baseCodeNameList.Count; i++)
            {
                if (sectionCode.PadLeft(2, '0').Equals(((BaseCodeNameWork)baseCodeNameList[i]).SectionCode.Trim()))
                {
                    sectionName = ((BaseCodeNameWork)baseCodeNameList[i]).SectionGuideNm;
                    return sectionName;
                }
            }

            return sectionName;
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                //status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);//DEL by Liangsd 2011/09/05
                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);    //ADD by Liangsd 2011/09/05
                if (status == 0)
                {
                    if (string.Empty.Equals(GetSectionName(secInfoSet.SectionCode.Trim())))
                    {
                        TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                this.Name,							    // �A�Z���u��ID
                                "���M�拒�_�R�[�h�����݂��܂���B",	    // �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��

                        this.tEdit_SectionCode.DataText = this._preSectionCode;
                    }
                    else
                    {
                        this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();
                        this._preSectionCode = secInfoSet.SectionCode.Trim();
                        ResetGridCol();
                        SetSecCode(this.tEdit_SectionCode.Text);//ADD 2011/09/14 sundx #24542
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �O���b�h�����Đݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  :�O���b�h�����Đݒ�B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void ResetGridCol()
        {
            this._extractionConditionDataTable.Clear();
            this._updateResultDataTable.Clear();
            this._receiveConditionDataTable.Clear();
            this._receiveInfoTable.Clear();

            // ���M���f�[�^�ݒ�
            this.Acc_Grid.DataSource = this._updateResultDataTable;
            // ���M�����f�[�^�ݒ�
            this.Condition_Grid.DataSource = this._extractionConditionDataTable;
            // ���M���O���b�h�����ݒ�
            this.InitialAccSettingGridCol();
            // �}�X�^���̂��擾����B
            this.SearchMasterName();
            // �}�X�^���̂��擾�敪�B
            this.SearchMasterDoDiv();
            // �V���N���s���t���擾����B
            this.SearchSyncExecDate();
            // ����M�Ώېݒ�}�X�^���A�}�X�^���̏����ݒ�
            this.InitialAccDataGridCol();
            // ���M�����O���b�h�����ݒ�
            this.InitialConSettingGridCol();
            // ���M�����O���b�h�Đݒ�
            this.ResetConSettingGridCol();
        }

        /// <summary>
        /// ���M�����O���b�h�Đݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  :���M�����O���b�h�Đݒ�B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void ResetConSettingGridCol()
        {
            if (!ALL_SECTIONCODE.Equals(tEdit_SectionCode.DataText))
            {
                //�u00:�S�Ёv�ł͂Ȃ��ꍇ�A���͂������M�拒�_������ۗ�
                ArrayList indexList = new ArrayList();
                for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
                {
                    ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
                    if (!row.BaseCode.Trim().Equals(tEdit_SectionCode.DataText.Trim()))
                    {
                        indexList.Add(i);
                    }
                }
                for (int j = indexList.Count - 1; j >= 0; j--)
                {
                    _extractionConditionDataTable.Rows.RemoveAt((int)indexList[j]);
                }
            }
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                //�J�n���t�A�J�n���ԁA�I�����t�A�I�����Ԃɋ󔒂�ݒ肷��
                for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
                {
                    ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
                    row.BeginningDate = DateTime.MinValue;
                    row.BeginningTime = string.Empty;
                    row.EndDate = DateTime.MinValue;
                    row.EndTime = string.Empty;
                    row.InitBeginningDate = DateTime.MinValue;
                    row.InitBeginningTime = string.Empty;
                    //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--------------------------------------->>>>>
                    Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].SetValue(DBNull.Value, true);
                    Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].SetValue(DBNull.Value, true);                    
                    //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---------------------------------------<<<<<                    
                }
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���--------------------------------------->>>>>
                if (Condition_Grid.Rows.Count > 0)
                {
                    Condition_Grid.Rows[Condition_Grid.Rows.Count - 1].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Activated = false;
                    Condition_Grid.Rows[Condition_Grid.Rows.Count - 1].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Selected = false;
                }
                //ADD 2011/08/29 #23934 �������M�̊J�n���t���ԁE�I�����t���Ԃ̏����l�ɂ���---------------------------------------<<<<<
            }
        }

        /// <summary>
        /// ���M���_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  :���M�����O���b�h�Đݒ�B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Acc_Grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (this.tce_ExtractCondDiv.SelectedIndex != 1) return;
            if (e.Cell == null) return;
            if (e.Cell.Column.Index == this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Index)
            {
                return;
            }
            ExtractDetailShow();
        }

        /// <summary>
        /// ���o�����ڍ׉�ʂ��|�b�v�A�b�v����
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  :�Ή��}�X�^�̒��o������ʂ��|�b�v�A�b�v����B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void ExtractDetailShow()
        {
            UltraGridRow row = Acc_Grid.ActiveRow;
            if (row == null) return;
            string colMasterNm = row.Cells[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Value.ToString();
            if (MST_RATE.Equals(colMasterNm))
            {
                //�|���}�X�^���o�����ڍ�
                PMKYO01601UA _PMKYO01601UA = new PMKYO01601UA();
                _PMKYO01601UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01601UA._rateProcParam = this._rateProcParam;
                _PMKYO01601UA.ShowDialog();
                this._rateProcParam = _PMKYO01601UA._rateProcParam;
            }
            else if (MST_SUPPLIER.Equals(colMasterNm))
            {
                //�d����}�X�^���o�����ڍ�
                PMKYO01501UA _PMKYO01501UA = new PMKYO01501UA();
                _PMKYO01501UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01501UA._supplierProcParam = this._supplierProcParam;
                _PMKYO01501UA.ShowDialog();
                this._supplierProcParam = _PMKYO01501UA._supplierProcParam;
            }
            else if (MST_STOCK.Equals(colMasterNm))
            {
                //�݌Ƀ}�X�^���o�����ڍ�
                PMKYO01701UA _PMKYO01701UA = new PMKYO01701UA();
                _PMKYO01701UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01701UA._stockProcParam = this._stockProcParam;
                _PMKYO01701UA.ShowDialog();
                this._stockProcParam = _PMKYO01701UA._stockProcParam;
            }
            else if (MST_CUSTOME.Equals(colMasterNm))
            {
                //���Ӑ�}�X�^���o�����ڍ�
                PMKYO01301UA _PMKYO01301UA = new PMKYO01301UA();
                _PMKYO01301UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01301UA._customerProcParam = this._customerProcParam;
                _PMKYO01301UA.ShowDialog();
                this._customerProcParam = _PMKYO01301UA._customerProcParam;
            }
            else if (MST_GOODSU.Equals(colMasterNm))
            {
                //���i�}�X�^���o�����ڍ�
                PMKYO01401UA _PMKYO01401UA = new PMKYO01401UA();
                _PMKYO01401UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01401UA._goodsProcParam = this._goodsProcParam;
                _PMKYO01401UA.ShowDialog();
                this._goodsProcParam = _PMKYO01401UA._goodsProcParam;
            }
            // --- ADD 2012/07/26 ------------------------------------->>>>>
            else if (MST_EMPLOYEE.Equals(colMasterNm))
            {
                // �]�ƈ��ݒ�}�X�^���o�����ڍ�
                PMKYO01511UA _PMKYO01511UA = new PMKYO01511UA();
                _PMKYO01511UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01511UA._employeeProcParam = this._employeeProcParam;
                _PMKYO01511UA.ShowDialog();
                this._employeeProcParam = _PMKYO01511UA._employeeProcParam;
            }
            else if (MST_JOINPARTSU.Equals(colMasterNm))
            {
                // �����}�X�^���o�������o�����ڍ�
                PMKYO01521UA _PMKYO01521UA = new PMKYO01521UA();
                _PMKYO01521UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01521UA._joinPartsUProcParam = this._joinPartsUProcParam;
                _PMKYO01521UA.ShowDialog();
                this._joinPartsUProcParam = _PMKYO01521UA._joinPartsUProcParam;
            }
            else if (MST_USERGDBUYDIVU.Equals(colMasterNm))
            {
                // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j���o�������o�����ڍ�
                PMKYO01531UA _PMKYO01531UA = new PMKYO01531UA();
                _PMKYO01531UA.Mode = 1; //1:�V�K���[�h
                _PMKYO01531UA._userGdBuyDivUProcParam = this._userGdBuyDivUProcParam;
                _PMKYO01531UA.ShowDialog();
                this._userGdBuyDivUProcParam = _PMKYO01531UA._userGdBuyDivUProcParam;
            }
            // --- ADD 2012/07/26 -------------------------------------<<<<<
        }

        /// <summary>
        /// �s�I������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  :���M�����O���b�h�Đݒ�B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Bcc_Grid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
            {
                this._settingButton.SharedProps.Enabled = false;

                if (this.BCondition_Grid.ActiveRow != null &&
                    (int)this.BCondition_Grid.ActiveRow.Cells[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Value == 1)
                {
                    this._detailButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._detailButton.SharedProps.Enabled = false;
                }
            }
            else
            {
                if (this.Bcc_Grid.ActiveRow != null &&
                    (MST_GOODSU.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value) ||
                    (MST_STOCK.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value))))
                {
                    this._settingButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._settingButton.SharedProps.Enabled = false;
                }

                this._detailButton.SharedProps.Enabled = false;
            }
        }

        /// <summary>
        /// ��M���O���b�h�_�u���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  :���M�����O���b�h�Đݒ�B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Bcc_Grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell == null) return;
            //���M�Ώېݒ�
            SendDestSet();
        }

        /// <summary>
        /// ���M�Ώېݒ��ʂ��|�b�v�A�b�v����
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  :���M�Ώېݒ��ʂ��|�b�v�A�b�v����B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void SendDestSet()
        {
            UltraGridRow row = Bcc_Grid.ActiveRow;
            if (row == null) return;
            if ((!MST_STOCK.Equals(row.Cells[_receiveInfoDataTable.MasterNameColumn.ColumnName].Value))
                && (!MST_GOODSU.Equals(row.Cells[_receiveInfoDataTable.MasterNameColumn.ColumnName].Value))) return;
            //�݌Ƀ}�X�^�A�܂��͏��i�}�X�^�̏ꍇ���M�Ώۂ�ݒ�\
            PMKYO09200UA _PMKYO09200UA = new PMKYO09200UA();
            _PMKYO09200UA._callForm = true;
            _PMKYO09200UA._callPara = Convert.ToInt32(row.Cells[_receiveInfoDataTable.DisplayOrderColumn.ColumnName].Value);
            _PMKYO09200UA.ShowDialog();
        }

        /// <summary>
        /// �s�I������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  :��M�����O���b�h�s�I���B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void BCondition_Grid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
            {
                this._settingButton.SharedProps.Enabled = false;

                if (this.BCondition_Grid.ActiveRow != null &&
                    (int)this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Value == 1)
                {
                    this._detailButton.SharedProps.Enabled = true;
                    this._custDetailButton.SharedProps.Visible = true;
                    this._suppDetailButton.SharedProps.Visible = true;
                    this._goodsDetailButton.SharedProps.Visible = true;
                    this._stockDetailButton.SharedProps.Visible = true;
                    this._rateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ---------->>>>>
                    this._employeeDetailButton.SharedProps.Visible = true;
                    this._joinPartsUrateDetailButton.SharedProps.Visible = true;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ----------<<<<<
                    this._custDetailButton.SharedProps.Enabled = false;
                    this._suppDetailButton.SharedProps.Enabled = false;
                    this._goodsDetailButton.SharedProps.Enabled = false;
                    this._stockDetailButton.SharedProps.Enabled = false;
                    this._rateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 ---------->>>>>
                    this._employeeDetailButton.SharedProps.Enabled = false;
                    this._joinPartsUrateDetailButton.SharedProps.Enabled = false;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 ----------<<<<<

                    GetSelectSndRcvEtr(this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Value.ToString(),
                        this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString(),
                        (int)this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Value);
                    if (sndRcvEtrDic != null)
                    {
                        if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                        {
                            this._custDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                        {
                            this._goodsDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                        {
                            this._stockDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                        {
                            this._suppDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                        {
                            this._rateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ---------------------------->>>>>
                        if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                        {
                            this._employeeDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                        {
                            this._joinPartsUrateDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                        {
                            this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ----------------------------<<<<<
                    }
                    this.BCondition_Grid.ContextMenu = _contextMenu;
                }
                else
                {
                    this._detailButton.SharedProps.Enabled = false;
                    this.BCondition_Grid.ContextMenu = null;
                }
            }
        }

        /// <summary>
        /// �������O�f�[�^�ɑ΂��钊�o�����������O�f�[�^���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sndRcvHisConsNo">����M�������O���M�ԍ�</param>
        /// <returns>���o�����������O�f�[�^���X�g</returns>
        private void GetSelectSndRcvEtr(string enterpriseCode, string sectionCode, Int32 sndRcvHisConsNo)
        {
            sndRcvEtrDic.Clear();
            if (_sndRcvEtrList != null && _sndRcvEtrList.Count > 0)
            {
                foreach (SndRcvEtrWork work in _sndRcvEtrList)
                {
                    if (work.EnterpriseCode.Equals(enterpriseCode) && work.SectionCode.Trim().Equals(sectionCode.Trim())
                        && work.SndRcvHisConsNo == sndRcvHisConsNo)
                    {
                        if (work.FileId.Equals(FILEID_CUSTOMER))
                        {
                            sndRcvEtrDic.Add(FILEID_CUSTOMER, work);
                        }
                        else if (work.FileId.Equals(FILEID_GOODS))
                        {
                            sndRcvEtrDic.Add(FILEID_GOODS, work);
                        }
                        else if (work.FileId.Equals(FILEID_STOCK))
                        {
                            sndRcvEtrDic.Add(FILEID_STOCK, work);
                        }
                        else if (work.FileId.Equals(FILEID_SUPPLIER))
                        {
                            sndRcvEtrDic.Add(FILEID_SUPPLIER, work);
                        }
                        else if (work.FileId.Equals(FILEID_RATE))
                        {
                            sndRcvEtrDic.Add(FILEID_RATE, work);
                        }
                        // --- ADD 2012/07/26 ---------------------------->>>>>
                        else if (work.FileId.Equals(FILEID_EMPLOYEE))
                        {
                            sndRcvEtrDic.Add(FILEID_EMPLOYEE, work);
                        }
                        else if (work.FileId.Equals(FILEID_JOINPARTSU))
                        {
                            sndRcvEtrDic.Add(FILEID_JOINPARTSU, work);
                        }
                        else if (work.FileId.Equals(FILEID_USERGDU))
                        {
                            sndRcvEtrDic.Add(FILEID_USERGDU, work);
                        }
                        // --- ADD 2012/07/26 ----------------------------<<<<<
                    }
                }
            }
        }

        /// <summary>
        /// �}�E�X�E�N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  :��M�����O���b�h�̃}�E�X�E�N���b�N�����B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void BCondition_Grid_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender == this.BCondition_Grid && e.Button == MouseButtons.Right)
            {
                UltraGrid ug = (UltraGrid)sender;
                Infragistics.Win.UIElement aUIElement = ug.DisplayLayout.UIElement.ElementFromPoint(
                                 new Point(e.X, e.Y));

                if (aUIElement == null) return;

                // ���O�s
                UltraGridRow aRow = (UltraGridRow)aUIElement.GetContext(typeof(UltraGridRow));
                // ���Ocell
                UltraGridCell aCell = (UltraGridCell)aUIElement.GetContext(typeof(UltraGridCell));
            }
        }

        /// <summary>
        /// KeyDown����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���M���O���b�h�̃}�E�X�E�N���b�N�����B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Acc_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                if (Acc_Grid.ActiveRow != null)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        // [�폜]�J�����̒l��ݒ�
                        bool flag = (bool)this.Acc_Grid.ActiveRow.Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value;
                        this.Acc_Grid.ActiveRow.Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value = !flag;
                    }
                }
            }
        }

        /// <summary>
        /// BeforeCellActivate����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���M���O���b�h�̃}�E�X�E�N���b�N�����B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Acc_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                Acc_Grid.Selected.Rows.Clear();
                bool val = !((bool)e.Cell.Value);
                e.Cell.Value = val;

                if (Acc_Grid.Selected.Rows.Count == 0 || e.Cell.Row != Acc_Grid.Selected.Rows[0])
                    e.Cell.Row.Selected = true;
                e.Cancel = true;
            }
        }
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <param name="isShift">true:Shift�L�[����������� false:Shift�L�[����������Ȃ�</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
		//private bool MoveNextAllowEditCell(bool activeCellCheck) // DEL 2011/07/25
		private bool MoveNextAllowEditCell(bool activeCellCheck, bool isShift)// ADD 2011/07/25
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
				//-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				if (isShift)
				{
					performActionResult = this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
				}
				else
				{
				//-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
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
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private bool BMoveNextAllowEditCell(bool activeCellCheck)
        {
            this.Condition_Grid.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.Condition_Grid.ActiveCell != null))
            {
                if ((!this.BCondition_Grid.ActiveCell.Column.Hidden) &&
                    (this.BCondition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.BCondition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                if (performActionResult)
                {
                    if ((this.BCondition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.BCondition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.BCondition_Grid.ResumeLayout();
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

        #endregion �O���b�h
    }
}